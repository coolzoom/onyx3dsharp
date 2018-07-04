﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Onyx3D;

namespace Onyx3DEditor
{
	public partial class SceneHierarchyControl : UserControl
	{
        private Scene mScene;

		public SceneHierarchyControl()
		{
			InitializeComponent();
			Selection.OnSelectionChanged += OnSelectionChanged;
		}

        public void SetScene(Scene scene)
        {
            mScene = scene;
            UpdateScene();
        }

		public void SetObject(SceneObject obj)
		{
			mScene = null;
			treeViewScene.Nodes.Clear();
			TreeNode root = new TreeNode(obj.Id);
			AddSceneObjectToTreeNode(root, obj, true);
			treeViewScene.Nodes.Add(root);
			treeViewScene.ExpandAll();
		}

		public void UpdateScene()
		{
			treeViewScene.Nodes.Clear();
			TreeNode root = new TreeNode("Scene Name");
			if (mScene.Root.ChildCount > 0)
				AddSceneObjectToTreeNode(root, mScene.Root, true);
			treeViewScene.Nodes.Add(root);
			treeViewScene.ExpandAll();
		}


		private void AddSceneObjectToTreeNode(TreeNode node, SceneObject sceneObject, bool skipAdd)
		{
			SceneTreeNode objectNode = new SceneTreeNode(sceneObject);
			if (!skipAdd)
				node.Nodes.Add(objectNode);
			for (int i = 0; i < sceneObject.ChildCount; ++i)
				AddSceneObjectToTreeNode(skipAdd ? node : objectNode, sceneObject.GetChild(i), false);

		}

		private void OnSelectionChanged(List<SceneObject> obj)
		{
			if (treeViewScene.SelectedNode != null)
				treeViewScene.SelectedNode.BackColor = SystemColors.Window;

			if (Selection.ActiveObject == null)
			{ 
				treeViewScene.SelectedNode = null;
			}

            UpdateScene();
            SearchAndHighlightObject(treeViewScene.Nodes[0]);
			
		}

		private bool SearchAndHighlightObject(TreeNode tn)
		{
		
			foreach (SceneTreeNode node in tn.Nodes)
			{
				if (node.GetType() != typeof(SceneTreeNode))
					continue;

				if (node.BoundSceneObject == Selection.ActiveObject)
				{
					node.BackColor = Color.Gray;
					treeViewScene.SelectedNode = node;
					treeViewScene.Focus();
					return true;
				}
				else
				{
					if (SearchAndHighlightObject(node))
						return true;
				}
			}

			return false;

		}

		private void treeViewScene_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Node.GetType() != typeof(SceneTreeNode))
			{
				Selection.Selected = null;
				return;
			}

			SceneTreeNode sceneTreeeNode = (SceneTreeNode)e.Node;
			if (sceneTreeeNode != null)
			{
				Selection.ActiveObject = sceneTreeeNode.BoundSceneObject;
			}
		}

    }
}
