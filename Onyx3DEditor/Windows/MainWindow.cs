﻿using System;
using System.Drawing;
using System.Windows.Forms;

using Onyx3D;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.IO;
using System.Collections.Generic;

namespace Onyx3DEditor
{
	
	public partial class MainWindow : Form
	{
		bool canDraw = false;

		Onyx3DInstance mOnyxInstance;
		OnyxProjectSceneAsset mSceneAsset;
		Scene mScene;
		GridRenderer mGridRenderer;
		SceneObject mSelectedSceneObject;
		Ray mClickRay;
		ObjectHandler mObjectHandler;
		OnyxViewerNavigation mNavigation = new OnyxViewerNavigation();
		

		public MainWindow()
		{
			
			InitializeComponent();
            InitializeCanvas();

            Selection.OnSelectionChanged += OnSelectionChanged;
			mNavigation.Bind(renderCanvas);

            KeyPreview = true;
		}

		private void InitScene()
		{
			Onyx3DEngine.InitMain(renderCanvas.Context, renderCanvas.WindowInfo);
			mOnyxInstance = Onyx3DEngine.Instance;
			
			
			mSceneAsset = ProjectManager.Instance.Content.GetInitScene();
			if (mSceneAsset == null)
			{
				mScene = new Scene();
			}
			else
			{
				mScene = AssetLoader<Scene>.Load(ProjectContent.GetAbsolutePath(mSceneAsset.Path), mOnyxInstance);
			}

			// Test objects

			// Editor objects --------------------------------------

			SceneObject grid = new SceneObject("Grid");
			mGridRenderer = grid.AddComponent<GridRenderer>();
			mGridRenderer.GenerateGridMesh(100, 100, 0.25f, 0.25f, Vector3.One);
			mGridRenderer.Material = mOnyxInstance.Resources.GetMaterial(BuiltInMaterial.Unlit);
			mGridRenderer.Material.Properties["color"].Data = new Vector4(1, 1, 1, 0.1f);

			mNavigation.CreateCamera();

			mObjectHandler = new ObjectHandler(mOnyxInstance, renderCanvas, mNavigation.NavigationCamera);
			// TODO - This could allocate several times (when changing scene)
			mObjectHandler.OnTransformModified += OnTransformModifiedFromObjectHandler;

			sceneHierarchy.SetScene(mScene);
			// TODO - This could allocate several times (when changing scene)
			selectedObjectInspector.InspectorChanged += OnInspectorChanged;
			
        }

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
				selectedObjectInspector.Fill(mScene);
			}

			mObjectHandler.HandleObject(mSelectedSceneObject);
			RenderScene();
		}

		private void OnInspectorChanged(object sender, EventArgs args)
		{
			RenderScene();
		}


		private void OnTransformModifiedFromObjectHandler()
		{
			selectedObjectInspector.Fill(mSelectedSceneObject);
		}

		private void DeleteObject(SceneObject o)
		{
			if (o == null)
				return;

            o.Destroy();
            o = null;
            mScene.SetDirty();
			Selection.ActiveObject = null;
		}

		private void AddPrimitive(int meshType, string name)
		{
            SceneObject primitive = SceneObject.CreatePrimitive(mOnyxInstance.Resources, meshType, name);
            primitive.Parent = mScene.Root;
            Selection.ActiveObject = primitive;
        }

		private void OnSceneSelected(Scene s)
		{
			mScene = s;
			sceneHierarchy.SetScene(mScene);
			renderCanvas.Refresh();
            Selection.ActiveObject = null;
		}

		private void SaveScene()
		{
			
			if (mSceneAsset == null)
			{
				SaveFileDialog saveFileDialog1 = new SaveFileDialog();
				saveFileDialog1.Filter = "Onyx3d scene files (*.o3dscene)|*.o3dscene";
				saveFileDialog1.FilterIndex = 2;
				saveFileDialog1.RestoreDirectory = true;

				if (saveFileDialog1.ShowDialog() == DialogResult.OK)
				{
					AssetLoader<Scene>.Save(mScene, saveFileDialog1.FileName);
					try
					{
						mSceneAsset = new OnyxProjectSceneAsset(saveFileDialog1.FileName);
						ProjectManager.Instance.Content.Scenes.Add(mSceneAsset);
					}
					catch (Exception ex)
					{
						MessageBox.Show("Error saving the scene : " + ex.Message);
					}


				}
			}
			else
			{
				AssetLoader<Scene>.Save(mScene, mSceneAsset.Path);
			}
		}

		private void RenderScene()
		{            
            if (!canDraw)
				return;

            renderCanvas.MakeCurrent();

            mNavigation.UpdateCamera();

            
            mOnyxInstance.Renderer.Render(mScene, mNavigation.NavigationCamera, renderCanvas.Width, renderCanvas.Height);
			mOnyxInstance.Renderer.Render(mGridRenderer, mNavigation.NavigationCamera);

			mOnyxInstance.Gizmos.DrawLine(mClickRay.Origin, mClickRay.Origin + mClickRay.Direction * 10, Vector3.One);
            mOnyxInstance.Gizmos.DrawComponentGizmos(mScene);
            mOnyxInstance.Gizmos.Render(mNavigation.NavigationCamera);

			if (mSelectedSceneObject != null)
			{
				mObjectHandler.Update();

				foreach (SceneObject obj in Selection.Selected)
				{
					Bounds b = obj.GetComponent<MeshRenderer>().Bounds;
					mOnyxInstance.Gizmos.DrawBox(b.Center, b.Size, Color.White.ToVector().Xyz);
				}
//				mOnyxInstance.Gizmos.DrawCircle(1, mSelectedSceneObject.Transform.Position, Vector3.One, Vector3.UnitY);
			}

			renderCanvas.SwapBuffers();
			labelLoggerOutput.Text = Logger.Instance.Content;            
		
		}

		#region RenderCanvas callbacks

		private void renderCanvas_Load(object sender, EventArgs e)
		{
			InitScene();
			canDraw = true;
		}

		private void renderCanvas_Paint(object sender, PaintEventArgs e)
		{
			RenderScene();
		}

		private void renderCanvas_Click(object sender, EventArgs e)
		{
			MouseEventArgs mouseEvent = e as MouseEventArgs;

			if (mouseEvent.Button == MouseButtons.Left && !mObjectHandler.IsHandling)
			{
				mClickRay = mNavigation.NavigationCamera.ScreenPointToRay(mouseEvent.X, mouseEvent.Y, renderCanvas.Width, renderCanvas.Height);

				RaycastHit hit = new RaycastHit();
				if (Physics.Raycast(mClickRay, out hit, mScene))
				{
					if (Control.ModifierKeys.HasFlag(Keys.Control))
					{
						Selection.Add(hit.Object);
					}
					else
					{
						Selection.ActiveObject = hit.Object;
					}
				}
				else
				{
					Selection.ActiveObject = null;
				}

				renderCanvas.Refresh();
			}
		}

	
		#endregion

		#region UI callbacks

		private void timer1_Tick(object sender, EventArgs e)
		{
			//myTeapot.Transform.Rotate(new Vector3(0, 0.1f, 0));
			//renderCanvas.Refresh();
			//mReflectionProbe.Angle += 0.01f;
		}

		private void toolStripButtonSaveProject_Click(object sender, EventArgs e)
		{
			SaveScene();
            ProjectLoader.Save();
		}

		private void toolStripButtonMaterials_Click(object sender, EventArgs e)
		{
            MaterialEditorWindow matEditor = new MaterialEditorWindow();
            matEditor.MaterialSaved += (OnyxProjectMaterialAsset asset) =>
            {
                Onyx3DEngine.Instance.Resources.ReloadMaterial(asset.Guid);
                RenderScene();
            };
            
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
				ProjectManager.Instance.New();
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
				InitScene();
			}
		}

		private void toolStripButtonChangeScene_Click(object sender, EventArgs e)
		{
			SceneSelectorWindow ss = new SceneSelectorWindow();
			ss.OnSceneSelected += OnSceneSelected;
			ss.Show();
		}

		private void toolStripButtonOpenScene_Click(object sender, EventArgs e)
		{

			Stream myStream;
			OpenFileDialog openFileDialog1 = new OpenFileDialog();

			openFileDialog1.InitialDirectory = "c:\\";
			openFileDialog1.Filter = "Onyx3d project files (*.o3dscene)|*.o3dscene";
			openFileDialog1.FilterIndex = 2;
			openFileDialog1.RestoreDirectory = true;

			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				try
				{
					if ((myStream = openFileDialog1.OpenFile()) != null)
					{
						mScene = AssetLoader<Scene>.Load(openFileDialog1.FileName);
						renderCanvas.Refresh();
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
				}
			}
			
		}

		private void toolStripCreateCube_Click(object sender, EventArgs e)
		{
			AddPrimitive(BuiltInMesh.Cube, "Cube");
		}

		private void toolStripCreateCylinder_Click(object sender, EventArgs e)
		{
			AddPrimitive(BuiltInMesh.Cylinder, "Cylinder");
		}

		private void toolStripCreateTeapot_Click(object sender, EventArgs e)
		{
			AddPrimitive(BuiltInMesh.Teapot, "Teapot");
		}

		private void toolStripCreateSphere_Click(object sender, EventArgs e)
		{
			AddPrimitive(BuiltInMesh.Sphere, "Sphere");
		}

        private void toolStripCreateQuad_Click(object sender, EventArgs e)
        {
            AddPrimitive(BuiltInMesh.Quad, "Quad");
        }

        private void toolStripCreateLight_Click(object sender, EventArgs e)
		{
			SceneObject light = new SceneObject("Light");
			Light lightC = light.AddComponent<Light>();
			light.Parent = mScene.Root;
            Selection.ActiveObject = light;
        }

        private void toolStripCreateTemplate_Click(object sender, EventArgs e)
        {
            TemplateProxy tmp = new TemplateProxy("Template");
            tmp.Parent = mScene.Root;
            Selection.ActiveObject = tmp;
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


		#endregion

		private void MainWindow_KeyDown(object sender, KeyEventArgs e)
		{
			
		}

		private void toolStripButtonImportModel_Click(object sender, EventArgs e)
		{
			new ModelImporterWindow().Show();
		}

		private void duplicateSceneObjectToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Selection.ActiveObject == null)
				return;

			SceneObject clone = Selection.ActiveObject.Clone();
			clone.Parent = Selection.ActiveObject.Parent;
			
			Selection.ActiveObject = clone;
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Selection.ActiveObject != null)
				DeleteObject(Selection.ActiveObject);
		}

		private void toolStripCreateReflectionProbe_Click(object sender, EventArgs e)
		{
			SceneObject obj = new SceneObject("ReflectionProbe", mScene);
			obj.Parent = mScene.Root;
			obj.Transform.LocalPosition = new Vector3(0, 0, 0);
			ReflectionProbe mReflectionProbe = obj.AddComponent<ReflectionProbe>();
			mReflectionProbe.Init(64);
			Selection.ActiveObject = obj;
		}

		private void bakeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			renderCanvas.MakeCurrent();
			mOnyxInstance.Renderer.RefreshReflectionProbes();
			renderCanvas.Refresh();
		}

		private void setParentToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Selection.ActiveObject == null)
				return;

			foreach (SceneObject obj in Selection.Selected)
			{
				if (obj != Selection.ActiveObject)
					obj.Parent = Selection.ActiveObject;
			}
			sceneHierarchy.UpdateScene();
		}
		

		private void clearParentToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			if (Selection.ActiveObject == null)
				return;

			foreach (SceneObject obj in Selection.Selected)
			{
				obj.Parent = mScene.Root;
			}

			sceneHierarchy.UpdateScene();
		}

		private void groupObjectsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Selection.ActiveObject == null)
				return;
			
			SceneObject newObj = new SceneObject("New Group", mScene);
			newObj.Transform.LocalPosition = Selection.ActiveObject.Transform.LocalPosition;
			newObj.Parent = Selection.ActiveObject.Parent;
			foreach (SceneObject obj in Selection.Selected)
			{
				obj.Parent = newObj;
			}

			Selection.ActiveObject = newObj;
		}
	}
}