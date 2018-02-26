﻿using System;
using System.Windows.Forms;

namespace Onyx3DEditor
{
	partial class MainWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}


		private void InitializeCanvas()
		{
			// 
			// renderCanvas
			// 
			this.renderCanvas.BackColor = System.Drawing.Color.Black;
			this.renderCanvas.Name = "renderCanvas";;
			this.renderCanvas.VSync = false;
			this.renderCanvas.Load += new System.EventHandler(this.renderCanvas_Load);
			this.renderCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.renderCanvas_Paint);

		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
			this.renderCanvas = new OpenTK.GLControl();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripButtonNewProject = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonOpenProject = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonSaveProject = new System.Windows.Forms.ToolStripButton();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.toolStripScene = new System.Windows.Forms.ToolStrip();
			this.toolStripButtonChangeScene = new System.Windows.Forms.ToolStripButton();
			this.treeViewSceneHierarchy = new System.Windows.Forms.TreeView();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.selectedObjectInspector = new Onyx3DEditor.SelectedInspectorPanel();
			this.toolStrip3 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.toolStripScene.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.toolStrip3.SuspendLayout();
			this.SuspendLayout();
			// 
			// renderCanvas
			// 
			this.renderCanvas.BackColor = System.Drawing.Color.Magenta;
			this.renderCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
			this.renderCanvas.Location = new System.Drawing.Point(0, 0);
			this.renderCanvas.Name = "renderCanvas";
			this.renderCanvas.Size = new System.Drawing.Size(600, 520);
			this.renderCanvas.TabIndex = 0;
			this.renderCanvas.VSync = false;
			this.renderCanvas.Click += new System.EventHandler(this.renderCanvas_Click);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.toolStripButtonNewProject,
            this.toolStripButtonOpenProject,
            this.toolStripButtonSaveProject});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(979, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripLabel2
			// 
			this.toolStripLabel2.Name = "toolStripLabel2";
			this.toolStripLabel2.Size = new System.Drawing.Size(44, 22);
			this.toolStripLabel2.Text = "Project";
			// 
			// toolStripButtonNewProject
			// 
			this.toolStripButtonNewProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonNewProject.Image = global::Onyx3DEditor.Properties.Resources.if_gtk_new_20536;
			this.toolStripButtonNewProject.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonNewProject.Name = "toolStripButtonNewProject";
			this.toolStripButtonNewProject.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonNewProject.Text = "New Project";
			this.toolStripButtonNewProject.Click += new System.EventHandler(this.toolStripButtonNewProject_Click);
			// 
			// toolStripButtonOpenProject
			// 
			this.toolStripButtonOpenProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonOpenProject.Image = global::Onyx3DEditor.Properties.Resources.if_folder_open_21164;
			this.toolStripButtonOpenProject.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonOpenProject.Name = "toolStripButtonOpenProject";
			this.toolStripButtonOpenProject.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonOpenProject.Text = "Open Project";
			this.toolStripButtonOpenProject.Click += new System.EventHandler(this.toolStripButtonOpenProject_Click);
			// 
			// toolStripButtonSaveProject
			// 
			this.toolStripButtonSaveProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonSaveProject.Image = global::Onyx3DEditor.Properties.Resources.if_stock_save_20659;
			this.toolStripButtonSaveProject.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonSaveProject.Name = "toolStripButtonSaveProject";
			this.toolStripButtonSaveProject.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonSaveProject.Text = "Save Project";
			this.toolStripButtonSaveProject.Click += new System.EventHandler(this.toolStripButtonSaveProject_Click);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 25);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.toolStripScene);
			this.splitContainer1.Panel1.Controls.Add(this.treeViewSceneHierarchy);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Panel2.Controls.Add(this.toolStrip3);
			this.splitContainer1.Size = new System.Drawing.Size(979, 520);
			this.splitContainer1.SplitterDistance = 158;
			this.splitContainer1.TabIndex = 2;
			// 
			// toolStripScene
			// 
			this.toolStripScene.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.toolStripScene.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonChangeScene});
			this.toolStripScene.Location = new System.Drawing.Point(0, 495);
			this.toolStripScene.Name = "toolStripScene";
			this.toolStripScene.Size = new System.Drawing.Size(158, 25);
			this.toolStripScene.TabIndex = 3;
			this.toolStripScene.Text = "toolStrip2";
			// 
			// toolStripButtonChangeScene
			// 
			this.toolStripButtonChangeScene.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButtonChangeScene.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonChangeScene.Image")));
			this.toolStripButtonChangeScene.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonChangeScene.Name = "toolStripButtonChangeScene";
			this.toolStripButtonChangeScene.Size = new System.Drawing.Size(86, 22);
			this.toolStripButtonChangeScene.Text = "Change Scene";
			this.toolStripButtonChangeScene.Click += new System.EventHandler(this.toolStripButtonChangeScene_Click);
			// 
			// treeViewSceneHierarchy
			// 
			this.treeViewSceneHierarchy.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeViewSceneHierarchy.Location = new System.Drawing.Point(0, 0);
			this.treeViewSceneHierarchy.Name = "treeViewSceneHierarchy";
			this.treeViewSceneHierarchy.Size = new System.Drawing.Size(158, 520);
			this.treeViewSceneHierarchy.TabIndex = 0;
			this.treeViewSceneHierarchy.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewSceneHierarchy_NodeSelected);
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(24, 0);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.renderCanvas);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.ControlLight;
			this.splitContainer2.Panel2.Controls.Add(this.selectedObjectInspector);
			this.splitContainer2.Panel2MinSize = 100;
			this.splitContainer2.Size = new System.Drawing.Size(793, 520);
			this.splitContainer2.SplitterDistance = 600;
			this.splitContainer2.SplitterWidth = 1;
			this.splitContainer2.TabIndex = 3;
			// 
			// selectedObjectInspector
			// 
			this.selectedObjectInspector.AutoSize = true;
			this.selectedObjectInspector.BackColor = System.Drawing.SystemColors.Control;
			this.selectedObjectInspector.Dock = System.Windows.Forms.DockStyle.Fill;
			this.selectedObjectInspector.Location = new System.Drawing.Point(0, 0);
			this.selectedObjectInspector.Name = "selectedObjectInspector";
			this.selectedObjectInspector.Size = new System.Drawing.Size(192, 520);
			this.selectedObjectInspector.TabIndex = 0;
			// 
			// toolStrip3
			// 
			this.toolStrip3.Dock = System.Windows.Forms.DockStyle.Left;
			this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripButton1});
			this.toolStrip3.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
			this.toolStrip3.Location = new System.Drawing.Point(0, 0);
			this.toolStrip3.Name = "toolStrip3";
			this.toolStrip3.Size = new System.Drawing.Size(24, 520);
			this.toolStrip3.TabIndex = 2;
			this.toolStrip3.Text = "toolStripContent";
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton2.Image = global::Onyx3DEditor.Properties.Resources.stock_3d_texture;
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(21, 20);
			this.toolStripButton2.Text = "toolStripButtonTextures";
			this.toolStripButton2.Click += new System.EventHandler(this.toolStripButtonTextures_Click);
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = global::Onyx3DEditor.Properties.Resources.stock_3d_texture_and_shading;
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(21, 20);
			this.toolStripButton1.Text = "toolStripButtonMaterials";
			this.toolStripButton1.Click += new System.EventHandler(this.toolStripButtonMaterials_Click);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 14;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(979, 545);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.toolStrip1);
			this.Name = "MainWindow";
			this.Text = "MainWindow";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Activated += new System.EventHandler(this.MainWindow_Activated);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.toolStripScene.ResumeLayout(false);
			this.toolStripScene.PerformLayout();
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.toolStrip3.ResumeLayout(false);
			this.toolStrip3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}


		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton toolStripButtonNewProject;
		private System.Windows.Forms.ToolStripButton toolStripButtonOpenProject;
		private System.Windows.Forms.ToolStripButton toolStripButtonSaveProject;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ToolStrip toolStrip3;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.TreeView treeViewSceneHierarchy;
		private System.Windows.Forms.ToolStripButton toolStripButton2;
		private OpenTK.GLControl renderCanvas;
		private System.Windows.Forms.ToolStrip toolStripScene;
		private ToolStripLabel toolStripLabel2;
		private ToolStripButton toolStripButtonChangeScene;
		private Timer timer1;
		private SplitContainer splitContainer2;
		private SelectedInspectorPanel selectedObjectInspector;
	}
}