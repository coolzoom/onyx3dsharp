﻿using Onyx3D;
using OpenTK;
using OpenTK.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Onyx3DEditor
{
	public partial class MainWindow : SingletonForm<MainWindow>
	{
		private bool mCanDraw = false;
		private Onyx3DInstance mOnyxInstance;
		private GridRenderer mGridRenderer;
		private SceneObject mSelectedSceneObject;
		private EntityProxy mSelectedEntity;
		private ObjectHandler mObjectHandler;
		private OnyxViewerNavigation mNavigation = new OnyxViewerNavigation();

		// --------------------------------------------------------------------

		private bool EditingEntity { get { return mSelectedEntity != null; } }

		// --------------------------------------------------------------------

		public MainWindow()
		{
			InitializeComponent();
			InitializeCanvas();

			Selection.OnSelectionChanged += OnSelectionChanged;
			SceneManagement.OnSceneChanged += OnSceneChanged;

			sceneHierarchy.OnEntityEditingChange += OnEntityEditingChange;

			mNavigation.Bind(renderCanvas);

			KeyPreview = true;
		}

		// --------------------------------------------------------------------

		private void InitializeEditor()
		{
			Onyx3DEngine.InitMain(renderCanvas.Context, renderCanvas.WindowInfo);
			mOnyxInstance = Onyx3DEngine.Instance;

			mNavigation.CreateCamera();

			mObjectHandler = new ObjectHandler(mOnyxInstance, renderCanvas, mNavigation.Camera);
			mObjectHandler.OnTransformModified += OnTransformModifiedFromObjectHandler;

			selectedObjectInspector.InspectorChanged += OnInspectorChanged;

			SceneObject grid = new SceneObject("Grid");
			mGridRenderer = grid.AddComponent<GridRenderer>();
			mGridRenderer.GenerateGridMesh(100, 100, 0.25f, 0.25f, Vector3.One);
			mGridRenderer.Material = mOnyxInstance.Resources.GetMaterial(BuiltInMaterial.Unlit);
			mGridRenderer.Material.Properties["color"].Data = new Vector4(1, 1, 1, 0.1f);

			UpdateFormTitle();
            
        }

		// --------------------------------------------------------------------

		private void UpdateFormTitle()
		{
			StringBuilder name = new StringBuilder();
			name.Append("Onyx3DEditor - ");
			name.Append(ProjectManager.Instance.CurrentProjectPath.Length > 0 ? ProjectManager.Instance.CurrentProjectPath : "[Unsaved Project]");

			Text = name.ToString();
		}

		// --------------------------------------------------------------------

		private void OnSelectionChanged(List<SceneObject> selected)
		{
			mSelectedSceneObject = Selection.ActiveObject;
			renderCanvas.Refresh();

			if (mSelectedSceneObject != null)
			{
				selectedObjectInspector.Fill(mSelectedSceneObject);
			}
			else
			{
				selectedObjectInspector.Fill(SceneManagement.ActiveScene);
			}

			mObjectHandler.HandleObject(mSelectedSceneObject);
			RenderScene();
		}

		// --------------------------------------------------------------------

		private void OnInspectorChanged(object sender, EventArgs args)
		{
			RenderScene();
		}

		// --------------------------------------------------------------------

		private void OnTransformModifiedFromObjectHandler()
		{
			selectedObjectInspector.Fill(mSelectedSceneObject);
		}

		// --------------------------------------------------------------------

		private void OnSceneChanged(Scene s)
		{
			sceneHierarchy.SetScene(s);
			renderCanvas.Refresh();
			Selection.ActiveObject = null;
		}

		// --------------------------------------------------------------------

		private void HighlightSelected()
		{
			if (mSelectedSceneObject != null)
			{
				if (EditingEntity)
				{
					mSelectedEntity.CalculateBounds();
				}

				mObjectHandler.Update();

				foreach (SceneObject obj in Selection.Selected)
				{
					Bounds bounds = obj.CalculateBounds();
					mOnyxInstance.Gizmos.DrawBox(bounds.Center, bounds.Size, Color.White.ToVector().Xyz);
				}

				Bounds activeBounds = Selection.ActiveObject.CalculateBounds();
				mOnyxInstance.Gizmos.DrawBox(activeBounds.Center, activeBounds.Size * 1.01f, Color.Orange.ToVector().Xyz);
			}
		}

		// --------------------------------------------------------------------

		private void RenderScene()
		{
			if (!mCanDraw)
				return;

			renderCanvas.MakeCurrent();
			mOnyxInstance.Resources.RefreshDirty();

			mNavigation.UpdateCamera();

			mOnyxInstance.Renderer.MainRender(SceneManagement.ActiveScene, mNavigation.Camera, renderCanvas.Width, renderCanvas.Height);
			mOnyxInstance.Renderer.Render(mGridRenderer, mNavigation.Camera);

			HighlightSelected();

			mOnyxInstance.Gizmos.DrawComponentGizmos(mNavigation.Camera, SceneManagement.ActiveScene);
			
			renderCanvas.SwapBuffers();
		}

		// --------------------------------------------------------------------

		public void UpdateHierarchy()
		{
			sceneHierarchy.UpdateScene();
		}

		// --------------------------------------------------------------------

		private void Select(SceneObject obj)
		{
			if (ModifierKeys.HasFlag(Keys.Control))
			{
				Selection.Add(obj);
			}
			else
			{
				Selection.ActiveObject = obj;
			}
		}

		// --------------------------------------------------------------------

		private void SetEditingEntity(EntityProxy proxy)
		{
			mSelectedEntity = proxy;
			Selection.ActiveObject = null;
		}

		// --------------------------------------------------------------------

		#region RenderCanvas callbacks

		private void renderCanvas_Load(object sender, EventArgs e)
		{
			InitializeEditor();
			SceneManagement.LoadInitScene();

			mCanDraw = true;

			RenderScene();
            renderCanvas.Refresh();
        }

		private void renderCanvas_Paint(object sender, PaintEventArgs e)
		{
			RenderScene();
			renderInfoLabel.Text = string.Format("Render Time: {0}ms", Math.Round(mOnyxInstance.Renderer.RenderTime));
			labelLoggerOutput.Text = Logger.Instance.Content;
			Profiler.Instance.Clear();
		}

		private void renderCanvas_Click(object sender, EventArgs e)
		{
			MouseEventArgs mouseEvent = e as MouseEventArgs;

			if (mouseEvent.Button == MouseButtons.Left && !mObjectHandler.IsHandling)
			{
				Ray clickRay = mNavigation.Camera.ScreenPointToRay(mouseEvent.X, mouseEvent.Y, renderCanvas.Width, renderCanvas.Height);

				RaycastHit hit = new RaycastHit();
				if (!EditingEntity)
				{
					if (Physics.RaycastScene(clickRay, out hit, SceneManagement.ActiveScene))
					{
						Select(hit.Object);
					}
					else
					{
						Selection.ActiveObject = null;
					}
				}
				else
				{
					if (Physics.RaycastEntity(clickRay, out hit, mSelectedEntity))
					{
						Select(hit.Object);
					}
					else
					{
						Selection.ActiveObject = null;
					}
				}

				renderCanvas.Refresh();
			}
		}

		private void renderCanvas_DoubleClick(object sender, EventArgs e)
		{
			if (Selection.ActiveObject != null && Selection.ActiveObject.GetType() == typeof(EntityProxy))
			{
				EntityProxy proxy = (EntityProxy)Selection.ActiveObject;
				sceneHierarchy.EnterEntity(proxy);
				SetEditingEntity(proxy);
			}else if (Selection.ActiveObject == null && EditingEntity)
			{
				sceneHierarchy.ExitEntity();
				SetEditingEntity(null);
			}
		}

		#endregion RenderCanvas callbacks

		// --------------------------------------------------------------------

		#region UI callbacks

		private void timer1_Tick(object sender, EventArgs e)
		{
			mNavigation.OnFrameTick();
		}

		private void toolStripButtonEntityManager_Click(object sender, EventArgs e)
		{
			new EntitySelectorWindow().Show();
		}

		private void toolStripButtonSaveProject_Click(object sender, EventArgs e)
		{
			EditorSceneUtils.Save();
			ProjectLoader.Save();
			Logger.Instance.Clear();
			Logger.Instance.Append("Saved " + DateTime.Now.ToString());
			UpdateFormTitle();
		}

		private void toolStripButtonMaterials_Click(object sender, EventArgs e)
		{
			MaterialEditorWindow matEditor = new MaterialEditorWindow();
			matEditor.Show();
		}

		private void toolStripButtonTextures_Click(object sender, EventArgs e)
		{
			new TextureManagerWindow().Show();
		}

		private void toolStripButtonNewProject_Click(object sender, EventArgs e)
		{
			var confirmResult = MessageBox.Show("Are you sure to start a new project?", "New Project", MessageBoxButtons.YesNo);
			if (confirmResult == DialogResult.Yes)
			{
                mOnyxInstance.Reset();
                ProjectManager.Instance.New();
				SceneManagement.New();
				ProjectLoader.Save();
			}
		}

		private void toolStripButtonOpenProject_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog();

			openFileDialog1.InitialDirectory = "c:\\";
			openFileDialog1.Filter = "Onyx3d project files (*.o3dproj)|*.o3dproj";
			openFileDialog1.FilterIndex = 2;
			openFileDialog1.RestoreDirectory = true;

			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				ProjectManager.Instance.Load(openFileDialog1.FileName);
				SceneManagement.LoadInitScene();
			}
		}

		private void toolStripButtonChangeScene_Click(object sender, EventArgs e)
		{
			SceneSelectorWindow ss = new SceneSelectorWindow();
			ss.OnSceneSelected += OnSceneChanged;
			ss.Show();
		}

		private void toolStripButtonOpenScene_Click(object sender, EventArgs e)
		{
			EditorSceneUtils.Open();
		}

		private void toolStripCreateCube_Click(object sender, EventArgs e)
		{
			EditorSceneObjectUtils.AddPrimitive(BuiltInMesh.Cube, "Cube");
		}

		private void toolStripCreateCylinder_Click(object sender, EventArgs e)
		{
			EditorSceneObjectUtils.AddPrimitive(BuiltInMesh.Cylinder, "Cylinder");
		}

		private void toolStripCreateTeapot_Click(object sender, EventArgs e)
		{
			EditorSceneObjectUtils.AddPrimitive(BuiltInMesh.Teapot, "Teapot");
		}

		private void toolStripCreateSphere_Click(object sender, EventArgs e)
		{
			EditorSceneObjectUtils.AddPrimitive(BuiltInMesh.Sphere, "Sphere");
		}

		private void toolStripCreateQuad_Click(object sender, EventArgs e)
		{
			EditorSceneObjectUtils.AddPrimitive(BuiltInMesh.Quad, "Quad");
		}

		private void toolStripCreateLight_Click(object sender, EventArgs e)
		{
			EditorSceneObjectUtils.AddLight();
		}

		private void toolStripCreateTemplate_Click(object sender, EventArgs e)
		{
			EditorEntityUtils.AddProxy();
		}

		private void toolStripCreateCamera_Click(object sender, EventArgs e)
		{
			EditorSceneObjectUtils.AddCamera();
		}

		private void toolStripButtonMove_Click(object sender, EventArgs e)
		{
			toolStripButtonScale.Checked = false;
			toolStripButtonMove.Checked = true;
			toolStripButtonRotate.Checked = false;
			mObjectHandler.SetAxisAction(ObjectHandler.HandlerAxisAction.Translate);
			renderCanvas.Refresh();
		}

		private void toolStripButtonScale_Click(object sender, EventArgs e)
		{
			toolStripButtonScale.Checked = true;
			toolStripButtonMove.Checked = false;
			toolStripButtonRotate.Checked = false;
			mObjectHandler.SetAxisAction(ObjectHandler.HandlerAxisAction.Scale);
			renderCanvas.Refresh();
		}

		private void toolStripButtonRotate_Click(object sender, EventArgs e)
		{
			toolStripButtonScale.Checked = false;
			toolStripButtonMove.Checked = false;
			toolStripButtonRotate.Checked = true;
			mObjectHandler.SetAxisAction(ObjectHandler.HandlerAxisAction.Rotate);
			renderCanvas.Refresh();
		}

		private void toolStripButtonImportModel_Click(object sender, EventArgs e)
		{
			if (ProjectManager.Instance.CurrentProjectPath.Length == 0)
			{
				ProjectLoader.Save();
				UpdateFormTitle();
			}
			else
			{
				new ModelImporterWindow().Show();
			}
		}

		private void duplicateSceneObjectToolStripMenuItem_Click(object sender, EventArgs e)
		{
			EditorSceneObjectUtils.Duplicate();
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Selection.ActiveObject != null)
				EditorSceneObjectUtils.Delete(Selection.Selected);
		}

		private void toolStripCreateReflectionProbe_Click(object sender, EventArgs e)
		{
			EditorSceneObjectUtils.AddReflectionProbe();
		}

		private void bakeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			renderCanvas.MakeCurrent();
			mOnyxInstance.Renderer.RefreshReflectionProbes(SceneManagement.ActiveScene);
			renderCanvas.Refresh();
		}

		private void setParentToolStripMenuItem_Click(object sender, EventArgs e)
		{
			EditorSceneObjectUtils.SetActiveAsParent();
		}

		private void clearParentToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			EditorSceneObjectUtils.ClearParent();
		}

		private void groupObjectsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			EditorSceneObjectUtils.Group(Selection.Selected);
		}

		private void createEntityToolStripMenuItem_Click(object sender, EventArgs e)
		{
			EditorEntityUtils.CreateFromSelection();
		}

		private void excludeFromEntityToolStripMenuItem_Click(object sender, EventArgs e)
		{
			EditorEntityUtils.ExcludeSelection();
		}

		private void saveSceneToolStripMenuItem_Click(object sender, EventArgs e)
		{
			EditorSceneUtils.Save();
		}

		private void newSceneToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SceneManagement.New();
		}

		private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int newAssets = ProjectManager.Instance.Content.RefreshAssets();
			if (newAssets > 0)
			{
				MessageBox.Show(string.Format("{0} new assets have been imported", newAssets));
			}
		}

		private void revertMaterialsToDefaultToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DefaultMaterial defaultMat = new DefaultMaterial();
			foreach (OnyxProjectAsset matAsset in ProjectManager.Instance.Content.Materials)
			{
				Material mat = AssetLoader<Material>.Load(matAsset.Path, true);

				foreach (KeyValuePair<string, MaterialProperty> prop in defaultMat.Properties)
				{
					if (!mat.Properties.ContainsKey(prop.Key))
					{
						mat.Properties.Add(prop.Key, prop.Value.Clone());
					}
					else
					{
						mat.Properties[prop.Key].Order = prop.Value.Order;
					}

					// TODO - Check if the property type has changed and update it
				}

				AssetLoader<Material>.Save(mat, matAsset.Path);
                ProjectManager.Instance.Content.MarkDirty(mat.LinkedProjectAsset.Guid);
			}
			mOnyxInstance.Resources.RefreshDirty();
		}

		private void OnEntityEditingChange(object sender, OnHierarchyEntityChange e)
		{
			SetEditingEntity(e.EntityProxy);
		}

		#endregion UI callbacks

		private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (SceneManagement.ActiveScene.UnsavedChanges)
			{
				DialogResult result = MessageBox.Show("There are unsaved changes in the scene, do you want to save before closing?", "Unsaved Scene Changes", MessageBoxButtons.YesNo);
				if (result == DialogResult.Yes)
				{
					EditorSceneUtils.Save();
				}
			}

			if (ProjectManager.Instance.IsDirty)
			{
				DialogResult result = MessageBox.Show("There are unsaved changes in the project, do you want to save before closing?", "Unsaved Project Changes", MessageBoxButtons.YesNo);
				if (result == DialogResult.Yes)
				{
					ProjectLoader.Save();
				}
			}
		}

        private void reloadDefaultShaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Shader shader = mOnyxInstance.Resources.GetShader(BuiltInShader.Default);
            String vs = Path.Combine(Application.StartupPath, "Resources/Shaders/VertexShader.glsl");
            String fs = Path.Combine(Application.StartupPath, "Resources/Shaders/FragmentShader.glsl");
            shader.Load(vs,fs);
            renderCanvas.Refresh();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

			//SceneObject grid = new SceneObject("Grid");
			//mGridRenderer = grid.AddComponent<GridRenderer>();
			//mGridRenderer.GenerateGridMesh(100, 100, 0.25f, 0.25f, Vector3.One);
			//mGridRenderer.Material = mOnyxInstance.Resources.GetMaterial(BuiltInMaterial.Unlit);
			//mGridRenderer.Material.Properties["color"].Data = new Vector4(1, 1, 1, 0.1f);

			List<Vector3> lp = new List<Vector3> { };
			List<Vector3> lpCorrect = new List<Vector3> { };
			float maxz = -9999;
			float minz = 9999;
			float zscale = 100;

			//load csv into DT
			string[] content = File.ReadAllLines("C:\\Users\\Administrator\\Desktop\\data2.csv");
			for (int i = 1; i < content.Length; i++)
			{
				string[] l = content[i].Split(',');
				if (l.Length == 3)
				{
					float x = float.Parse(l[0]);
					float y = float.Parse(l[1]);
					float z = float.Parse(l[2]);

					if (z < minz)
					{
						minz = z;
					}
					if (z > maxz )
					{
						maxz = z;
					}
					Vector3 pos = new Vector3(x, y, z);
					Vector3 posCorrect = new Vector3(x, z * zscale, y);
					lp.Add(pos);
					lpCorrect.Add(posCorrect);
				}

			}


			//list points

			float colorfactor = (maxz - minz) ;

			for (int a = 0; a < lp.Count; a++)
			{
				Vector3 pos = lp[a];
				Vector3 posCorrect = new Vector3(pos.X, pos.Z * 100, pos.Y);
				Vector3 sca = new Vector3(0.5f, 0.5f, 0.5f);
				int size = 2;
				//EditorSceneObjectUtils.AddReflectionProbe(pos, size);

				Vector3 up = new Vector3(0, 0, 1);
				Vector3 col = new Vector3(0, 1, 0);
				float colorvalue = (pos.Z - minz) / (maxz - minz);

                //the material shader color is from 0 to 1 but our conversion H is using 0 to 255
                //so we need to convert the range back and force
                //but remeber our l and s are from 0 to 1
                

                //Vector4 color = HlsToRgb( new Vector4(colorvalue * 255, 0.5f, 0.9f, 0.9f)); //transparency
                //                                                                                              //EditorSceneObjectUtils.AddReflectionProbe(pos, size);
                //color.X = color.X / 255;
                //color.Y = color.Y / 255;
                //color.Z = color.Z / 255;


                //build in HSL/HSV to RGB
                //https://zhuanlan.zhihu.com/p/158700586
                var c = Color4.FromHsl(new Vector4(colorvalue, 1f, 0.5f, 0.9f));
                Vector4 color = new Vector4();//  HlsToRgb( new Vector4(colorvalue * 255, 0.5f, 0.9f, 0.9f)); //transparency
                                              //EditorSceneObjectUtils.AddReflectionProbe(pos, size);
                color.X = c.R;
                color.Y = c.G;
                color.Z = c.B;
                color.W = c.A;


                //EditorSceneObjectUtils.AddCircle("Point" + i.ToString(), posCorrect, 0.1f, col, up, 100);
                EditorSceneObjectUtils.AddPrimitive(BuiltInMesh.Sphere, "Point" + a.ToString(), posCorrect, sca, color, false);
			}

			//check 
			int failcount = 0;
			bool bCheckH12 = true;
			bool bCheckSfactor = true;
			double dH12 = 0.015;
			double dSFactor = 0.003;
			string spassfail = "Pass";
			for (int a = 0; a < lp.Count; a++)
			{
				for (int b = a + 1; b < lp.Count; b++)
				{
					
					float Distance = (float)Math.Sqrt(Math.Pow(lp[b].X - lp[a].X, 2.0) + Math.Pow(lp[b].Y - lp[a].Y, 2.0));
					float H12 = lp[b].Z- lp[a].Z;
					float Sfactor = (Distance == 0 && H12 == 0) ? 0 : H12 / Distance;
					bool isfail = false;

					//if both checked, fail when h12>h12 max and sfactor > sfactor limit
					if (bCheckH12 && bCheckSfactor)
					{
						isfail = (Math.Abs(H12) > dH12) && (Sfactor > dSFactor);
					}
					//if only h12 checked,  fail when h12>h12 limit
					if (bCheckH12 && !bCheckSfactor)
					{
						isfail = (Math.Abs(H12) > dH12);
					}
					//if only sfactor checked,  fail when sfactor > sfactor limit
					if (!bCheckH12 && (bool)bCheckSfactor)
					{
						isfail = (Sfactor > dSFactor);
					}

					if (isfail)
					{
						failcount += 1;
						spassfail = "Fail";
						//+1 just for easier look
						//add fail line
						EditorSceneObjectUtils.AddLine("pin" + a.ToString() + "-pin" + b.ToString(), lpCorrect[a], lpCorrect[b], Color.Red.ToVector().Xyz);
					}
					else
					{
						spassfail = "Pass";
					}
				}
			}

			//only update scene until finished
			sceneHierarchy.UpdateScene();

            renderCanvas.Refresh();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
			//EditorSceneObjectUtils.AddLine("line", new Vector3(0,0,0), new Vector3(1, 1, 1), Color.White.ToVector().Xyz);
			EditorSceneObjectUtils.AddLine("line", new Vector3(0, 0, 0), new Vector3(1, 1, 1), Color.Red.ToVector().Xyz);
			//only update scene until finished
			sceneHierarchy.UpdateScene();
		}

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
			Vector3 pos = new Vector3(1, 1, 1);
			Vector3 up = new Vector3(0, 0, 1);
			Vector3 col = new Vector3(0, 1, 0);
			//EditorSceneObjectUtils.AddReflectionProbe(pos, size);

			EditorSceneObjectUtils.AddCircle("circle",pos,0.1f, col, up, 100);
			sceneHierarchy.UpdateScene();
		}

        #region "hslrgbconvert"
        //http://csharphelper.com/blog/2016/08/convert-between-rgb-and-hls-color-models-in-c/
        // Convert an RGB value into an HLS value.
        public static void RgbToHls(int r, int g, int b,
            out double h, out double l, out double s)
        {
            // Convert RGB to a 0.0 to 1.0 range.
            double double_r = r / 255.0;
            double double_g = g / 255.0;
            double double_b = b / 255.0;

            // Get the maximum and minimum RGB components.
            double max = double_r;
            if (max < double_g) max = double_g;
            if (max < double_b) max = double_b;

            double min = double_r;
            if (min > double_g) min = double_g;
            if (min > double_b) min = double_b;

            double diff = max - min;
            l = (max + min) / 2;
            if (Math.Abs(diff) < 0.00001)
            {
                s = 0;
                h = 0;  // H is really undefined.
            }
            else
            {
                if (l <= 0.5) s = diff / (max + min);
                else s = diff / (2 - max - min);

                double r_dist = (max - double_r) / diff;
                double g_dist = (max - double_g) / diff;
                double b_dist = (max - double_b) / diff;

                if (double_r == max) h = b_dist - g_dist;
                else if (double_g == max) h = 2 + r_dist - b_dist;
                else h = 4 + g_dist - r_dist;

                h = h * 60;
                if (h < 0) h += 360;
            }
        }

        // Convert an HLS value into an RGB value.
        public static OpenTK.Vector4 HlsToRgb(OpenTK.Vector4 hls)
        {
            double h = hls.X;
            double l = hls.Y;
            double s = hls.Z;

            double p2;
            if (l <= 0.5) p2 = l * (1 + s);
            else p2 = l + s - l * s;

            double p1 = 2 * l - p2;
            double double_r, double_g, double_b;
            if (s == 0)
            {
                double_r = l;
                double_g = l;
                double_b = l;
            }
            else
            {
                double_r = QqhToRgb(p1, p2, h + 120);
                double_g = QqhToRgb(p1, p2, h);
                double_b = QqhToRgb(p1, p2, h - 120);
            }

            OpenTK.Vector4 rgb = new Vector4();
            // Convert RGB to the 0 to 255 range.
            rgb.X = (int)(double_r * 255.0);
            rgb.Y = (int)(double_g * 255.0);
            rgb.Z = (int)(double_b * 255.0);
            rgb.W = hls.W;
            return rgb;
        }

        // Convert an HLS value into an RGB value.
        public static void HlsToRgb(double h, double l, double s,
            out int r, out int g, out int b)
        {
            double p2;
            if (l <= 0.5) p2 = l * (1 + s);
            else p2 = l + s - l * s;

            double p1 = 2 * l - p2;
            double double_r, double_g, double_b;
            if (s == 0)
            {
                double_r = l;
                double_g = l;
                double_b = l;
            }
            else
            {
                double_r = QqhToRgb(p1, p2, h + 120);
                double_g = QqhToRgb(p1, p2, h);
                double_b = QqhToRgb(p1, p2, h - 120);
            }

            // Convert RGB to the 0 to 255 range.
            r = (int)(double_r * 255.0);
            g = (int)(double_g * 255.0);
            b = (int)(double_b * 255.0);
        }

        private static double QqhToRgb(double q1, double q2, double hue)
        {
            if (hue > 360) hue -= 360;
            else if (hue < 0) hue += 360;

            if (hue < 60) return q1 + (q2 - q1) * hue / 60;
            if (hue < 180) return q2;
            if (hue < 240) return q1 + (q2 - q1) * (240 - hue) / 60;
            return q1;
        }

        #endregion

    }
}