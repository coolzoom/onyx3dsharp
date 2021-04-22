﻿using System;
using System.Windows.Forms;
using OpenTK.Graphics;

namespace Onyx3DEditor
{
	partial class MainWindow
	{

        private GraphicsMode graphicMode = new OpenTK.Graphics.GraphicsMode(32, 24, 0, 8);
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
			this.renderCanvas = new OpenTK.GLControl(graphicMode);
			this.renderCanvas.BackColor = System.Drawing.Color.Black;
			this.renderCanvas.Name = "renderCanvas";;
			this.renderCanvas.VSync = false;
			this.renderCanvas.Load += new System.EventHandler(this.renderCanvas_Load);
			this.renderCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.renderCanvas_Paint);

			this.renderCanvas.BackColor = System.Drawing.Color.Magenta;
			this.renderCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
			this.renderCanvas.Location = new System.Drawing.Point(0, 0);
			this.renderCanvas.Size = new System.Drawing.Size(600, 520);
			this.renderCanvas.TabIndex = 0;
			
			this.renderCanvas.Click += new System.EventHandler(this.renderCanvas_Click);
			this.renderCanvas.DoubleClick += new System.EventHandler(this.renderCanvas_DoubleClick);

			splitContainer2.Panel1.Controls.Add(this.renderCanvas);
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.newSceneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSceneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonImportModel = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.duplicateSceneObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setParentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearParentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupObjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createEntityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excludeFromEntityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.bakeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton4 = new System.Windows.Forms.ToolStripDropDownButton();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateMaterialAttributesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadDefaultShaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.sceneHierarchy = new Onyx3DEditor.SceneHierarchyControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemConvertToEntity = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripScene = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonChangeScene = new System.Windows.Forms.ToolStripButton();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.renderInfoLabel = new System.Windows.Forms.Label();
            this.labelLoggerOutput = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonMove = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonScale = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRotate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripCreateQuad = new System.Windows.Forms.ToolStripButton();
            this.toolStripCreateCube = new System.Windows.Forms.ToolStripButton();
            this.toolStripCreateCylinder = new System.Windows.Forms.ToolStripButton();
            this.toolStripCreateSphere = new System.Windows.Forms.ToolStripButton();
            this.toolStripCreateTeapot = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripCreateLight = new System.Windows.Forms.ToolStripButton();
            this.toolStripCreateReflectionProbe = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripCreateEntity = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripCreateCamera = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.selectedObjectInspector = new Onyx3DEditor.SelectedObjectInspector();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonTextureManager = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonMaterialManager = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEntityManager = new System.Windows.Forms.ToolStripButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStripScene.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton3,
            this.toolStripButtonImportModel,
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1305, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSceneToolStripMenuItem,
            this.saveSceneToolStripMenuItem,
            this.toolStripSeparator4,
            this.newProjectToolStripMenuItem,
            this.saveProjectToolStripMenuItem,
            this.openProjectToolStripMenuItem,
            this.toolStripSeparator5,
            this.exitToolStripMenuItem});
            this.toolStripDropDownButton3.Image = global::Onyx3DEditor.Properties.Resources.Diamond;
            this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.Size = new System.Drawing.Size(34, 24);
            this.toolStripDropDownButton3.Text = "toolStripDropDownButton3";
            // 
            // newSceneToolStripMenuItem
            // 
            this.newSceneToolStripMenuItem.Name = "newSceneToolStripMenuItem";
            this.newSceneToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.newSceneToolStripMenuItem.Text = "New Scene";
            this.newSceneToolStripMenuItem.Click += new System.EventHandler(this.newSceneToolStripMenuItem_Click);
            // 
            // saveSceneToolStripMenuItem
            // 
            this.saveSceneToolStripMenuItem.Name = "saveSceneToolStripMenuItem";
            this.saveSceneToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.saveSceneToolStripMenuItem.Text = "Save Scene";
            this.saveSceneToolStripMenuItem.Click += new System.EventHandler(this.saveSceneToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(234, 6);
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.newProjectToolStripMenuItem.Text = "New Project";
            this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonNewProject_Click);
            // 
            // saveProjectToolStripMenuItem
            // 
            this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            this.saveProjectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveProjectToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.saveProjectToolStripMenuItem.Text = "Save Project";
            this.saveProjectToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonSaveProject_Click);
            // 
            // openProjectToolStripMenuItem
            // 
            this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.openProjectToolStripMenuItem.Text = "Open Project";
            this.openProjectToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonOpenProject_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(234, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // toolStripButtonImportModel
            // 
            this.toolStripButtonImportModel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonImportModel.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonImportModel.Image")));
            this.toolStripButtonImportModel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonImportModel.Name = "toolStripButtonImportModel";
            this.toolStripButtonImportModel.Size = new System.Drawing.Size(115, 24);
            this.toolStripButtonImportModel.Text = "Import Model";
            this.toolStripButtonImportModel.Click += new System.EventHandler(this.toolStripButtonImportModel_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.duplicateSceneObjectToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.setParentToolStripMenuItem,
            this.clearParentToolStripMenuItem,
            this.groupObjectsToolStripMenuItem,
            this.createEntityToolStripMenuItem,
            this.excludeFromEntityToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(116, 24);
            this.toolStripDropDownButton1.Text = "SceneObject";
            // 
            // duplicateSceneObjectToolStripMenuItem
            // 
            this.duplicateSceneObjectToolStripMenuItem.Name = "duplicateSceneObjectToolStripMenuItem";
            this.duplicateSceneObjectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.duplicateSceneObjectToolStripMenuItem.Size = new System.Drawing.Size(330, 26);
            this.duplicateSceneObjectToolStripMenuItem.Text = "Duplicate";
            this.duplicateSceneObjectToolStripMenuItem.Click += new System.EventHandler(this.duplicateSceneObjectToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(330, 26);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // setParentToolStripMenuItem
            // 
            this.setParentToolStripMenuItem.Name = "setParentToolStripMenuItem";
            this.setParentToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.setParentToolStripMenuItem.Size = new System.Drawing.Size(330, 26);
            this.setParentToolStripMenuItem.Text = "Set Parent";
            this.setParentToolStripMenuItem.Click += new System.EventHandler(this.setParentToolStripMenuItem_Click);
            // 
            // clearParentToolStripMenuItem
            // 
            this.clearParentToolStripMenuItem.Name = "clearParentToolStripMenuItem";
            this.clearParentToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.P)));
            this.clearParentToolStripMenuItem.Size = new System.Drawing.Size(330, 26);
            this.clearParentToolStripMenuItem.Text = "Clear Parent";
            this.clearParentToolStripMenuItem.Click += new System.EventHandler(this.clearParentToolStripMenuItem_Click_1);
            // 
            // groupObjectsToolStripMenuItem
            // 
            this.groupObjectsToolStripMenuItem.Name = "groupObjectsToolStripMenuItem";
            this.groupObjectsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.groupObjectsToolStripMenuItem.Size = new System.Drawing.Size(330, 26);
            this.groupObjectsToolStripMenuItem.Text = "Group Objects";
            this.groupObjectsToolStripMenuItem.Click += new System.EventHandler(this.groupObjectsToolStripMenuItem_Click);
            // 
            // createEntityToolStripMenuItem
            // 
            this.createEntityToolStripMenuItem.Name = "createEntityToolStripMenuItem";
            this.createEntityToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.createEntityToolStripMenuItem.Size = new System.Drawing.Size(330, 26);
            this.createEntityToolStripMenuItem.Text = "Create Entity";
            this.createEntityToolStripMenuItem.Click += new System.EventHandler(this.createEntityToolStripMenuItem_Click);
            // 
            // excludeFromEntityToolStripMenuItem
            // 
            this.excludeFromEntityToolStripMenuItem.Name = "excludeFromEntityToolStripMenuItem";
            this.excludeFromEntityToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.E)));
            this.excludeFromEntityToolStripMenuItem.Size = new System.Drawing.Size(330, 26);
            this.excludeFromEntityToolStripMenuItem.Text = "Exclude from Entity";
            this.excludeFromEntityToolStripMenuItem.Click += new System.EventHandler(this.excludeFromEntityToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bakeToolStripMenuItem});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(83, 24);
            this.toolStripDropDownButton2.Text = "Lighting";
            // 
            // bakeToolStripMenuItem
            // 
            this.bakeToolStripMenuItem.Name = "bakeToolStripMenuItem";
            this.bakeToolStripMenuItem.Size = new System.Drawing.Size(126, 26);
            this.bakeToolStripMenuItem.Text = "Bake";
            this.bakeToolStripMenuItem.Click += new System.EventHandler(this.bakeToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton4
            // 
            this.toolStripDropDownButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.updateMaterialAttributesToolStripMenuItem,
            this.reloadDefaultShaderToolStripMenuItem});
            this.toolStripDropDownButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton4.Image")));
            this.toolStripDropDownButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton4.Name = "toolStripDropDownButton4";
            this.toolStripDropDownButton4.Size = new System.Drawing.Size(70, 24);
            this.toolStripDropDownButton4.Text = "Assets";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(307, 26);
            this.refreshToolStripMenuItem.Text = "Refresh from directory";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // updateMaterialAttributesToolStripMenuItem
            // 
            this.updateMaterialAttributesToolStripMenuItem.Name = "updateMaterialAttributesToolStripMenuItem";
            this.updateMaterialAttributesToolStripMenuItem.Size = new System.Drawing.Size(307, 26);
            this.updateMaterialAttributesToolStripMenuItem.Text = "Update material attributes";
            this.updateMaterialAttributesToolStripMenuItem.Click += new System.EventHandler(this.revertMaterialsToDefaultToolStripMenuItem_Click);
            // 
            // reloadDefaultShaderToolStripMenuItem
            // 
            this.reloadDefaultShaderToolStripMenuItem.Name = "reloadDefaultShaderToolStripMenuItem";
            this.reloadDefaultShaderToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.reloadDefaultShaderToolStripMenuItem.Size = new System.Drawing.Size(307, 26);
            this.reloadDefaultShaderToolStripMenuItem.Text = "Reload default shader";
            this.reloadDefaultShaderToolStripMenuItem.Click += new System.EventHandler(this.reloadDefaultShaderToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.sceneHierarchy);
            this.splitContainer1.Panel1.Controls.Add(this.toolStripScene);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip3);
            this.splitContainer1.Size = new System.Drawing.Size(1305, 602);
            this.splitContainer1.SplitterDistance = 210;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 2;
            // 
            // sceneHierarchy
            // 
            this.sceneHierarchy.ContextMenuStrip = this.contextMenuStrip1;
            this.sceneHierarchy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sceneHierarchy.Location = new System.Drawing.Point(0, 0);
            this.sceneHierarchy.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.sceneHierarchy.Name = "sceneHierarchy";
            this.sceneHierarchy.Size = new System.Drawing.Size(210, 575);
            this.sceneHierarchy.TabIndex = 4;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemConvertToEntity});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(221, 28);
            // 
            // toolStripMenuItemConvertToEntity
            // 
            this.toolStripMenuItemConvertToEntity.Name = "toolStripMenuItemConvertToEntity";
            this.toolStripMenuItemConvertToEntity.Size = new System.Drawing.Size(220, 24);
            this.toolStripMenuItemConvertToEntity.Text = "Convert Into Prefab";
            // 
            // toolStripScene
            // 
            this.toolStripScene.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripScene.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripScene.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonChangeScene});
            this.toolStripScene.Location = new System.Drawing.Point(0, 575);
            this.toolStripScene.Name = "toolStripScene";
            this.toolStripScene.Size = new System.Drawing.Size(210, 27);
            this.toolStripScene.TabIndex = 3;
            this.toolStripScene.Text = "toolStrip2";
            // 
            // toolStripButtonChangeScene
            // 
            this.toolStripButtonChangeScene.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonChangeScene.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonChangeScene.Image")));
            this.toolStripButtonChangeScene.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonChangeScene.Name = "toolStripButtonChangeScene";
            this.toolStripButtonChangeScene.Size = new System.Drawing.Size(116, 24);
            this.toolStripButtonChangeScene.Text = "Change Scene";
            this.toolStripButtonChangeScene.Click += new System.EventHandler(this.toolStripButtonChangeScene_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(30, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer2.Panel1.Controls.Add(this.renderInfoLabel);
            this.splitContainer2.Panel1.Controls.Add(this.labelLoggerOutput);
            this.splitContainer2.Panel1.Controls.Add(this.toolStrip2);
            this.splitContainer2.Panel1MinSize = 600;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitContainer2.Panel2.Controls.Add(this.selectedObjectInspector);
            this.splitContainer2.Panel2MinSize = 100;
            this.splitContainer2.Size = new System.Drawing.Size(1060, 602);
            this.splitContainer2.SplitterDistance = 700;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 3;
            // 
            // renderInfoLabel
            // 
            this.renderInfoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.renderInfoLabel.BackColor = System.Drawing.Color.Transparent;
            this.renderInfoLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.renderInfoLabel.Location = new System.Drawing.Point(561, 40);
            this.renderInfoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.renderInfoLabel.Name = "renderInfoLabel";
            this.renderInfoLabel.Size = new System.Drawing.Size(132, 20);
            this.renderInfoLabel.TabIndex = 3;
            this.renderInfoLabel.Text = "Rende Info ";
            this.renderInfoLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelLoggerOutput
            // 
            this.labelLoggerOutput.AutoSize = true;
            this.labelLoggerOutput.BackColor = System.Drawing.Color.Black;
            this.labelLoggerOutput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelLoggerOutput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelLoggerOutput.ForeColor = System.Drawing.Color.Red;
            this.labelLoggerOutput.Location = new System.Drawing.Point(0, 587);
            this.labelLoggerOutput.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLoggerOutput.Name = "labelLoggerOutput";
            this.labelLoggerOutput.Size = new System.Drawing.Size(87, 15);
            this.labelLoggerOutput.TabIndex = 2;
            this.labelLoggerOutput.Text = "Label Test";
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonMove,
            this.toolStripButtonScale,
            this.toolStripButtonRotate,
            this.toolStripSeparator1,
            this.toolStripCreateQuad,
            this.toolStripCreateCube,
            this.toolStripCreateCylinder,
            this.toolStripCreateSphere,
            this.toolStripCreateTeapot,
            this.toolStripSeparator2,
            this.toolStripCreateLight,
            this.toolStripCreateReflectionProbe,
            this.toolStripSeparator3,
            this.toolStripCreateEntity,
            this.toolStripSeparator6,
            this.toolStripCreateCamera,
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(700, 27);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButtonMove
            // 
            this.toolStripButtonMove.Checked = true;
            this.toolStripButtonMove.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButtonMove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonMove.Image = global::Onyx3DEditor.Properties.Resources.if_move_118639;
            this.toolStripButtonMove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMove.Name = "toolStripButtonMove";
            this.toolStripButtonMove.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonMove.Text = "toolStripButton3";
            this.toolStripButtonMove.Click += new System.EventHandler(this.toolStripButtonMove_Click);
            // 
            // toolStripButtonScale
            // 
            this.toolStripButtonScale.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonScale.Image = global::Onyx3DEditor.Properties.Resources.if_fullscreen_118670;
            this.toolStripButtonScale.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonScale.Name = "toolStripButtonScale";
            this.toolStripButtonScale.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonScale.Text = "toolStripButton4";
            this.toolStripButtonScale.Click += new System.EventHandler(this.toolStripButtonScale_Click);
            // 
            // toolStripButtonRotate
            // 
            this.toolStripButtonRotate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRotate.Image = global::Onyx3DEditor.Properties.Resources.if_object_rotate_right_23488;
            this.toolStripButtonRotate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRotate.Name = "toolStripButtonRotate";
            this.toolStripButtonRotate.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonRotate.Text = "toolStripButton3";
            this.toolStripButtonRotate.Click += new System.EventHandler(this.toolStripButtonRotate_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripCreateQuad
            // 
            this.toolStripCreateQuad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCreateQuad.Image = global::Onyx3DEditor.Properties.Resources.if_shape_square_16447;
            this.toolStripCreateQuad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripCreateQuad.Name = "toolStripCreateQuad";
            this.toolStripCreateQuad.Size = new System.Drawing.Size(29, 24);
            this.toolStripCreateQuad.Text = "toolStripButton3";
            this.toolStripCreateQuad.Click += new System.EventHandler(this.toolStripCreateQuad_Click);
            // 
            // toolStripCreateCube
            // 
            this.toolStripCreateCube.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCreateCube.Image = global::Onyx3DEditor.Properties.Resources.if_stock_draw_cube_21540;
            this.toolStripCreateCube.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripCreateCube.Name = "toolStripCreateCube";
            this.toolStripCreateCube.Size = new System.Drawing.Size(29, 24);
            this.toolStripCreateCube.Text = "toolStripButton3";
            this.toolStripCreateCube.ToolTipText = "Create Cube";
            this.toolStripCreateCube.Click += new System.EventHandler(this.toolStripCreateCube_Click);
            // 
            // toolStripCreateCylinder
            // 
            this.toolStripCreateCylinder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCreateCylinder.Image = global::Onyx3DEditor.Properties.Resources.if_stock_draw_cylinder_21550;
            this.toolStripCreateCylinder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripCreateCylinder.Name = "toolStripCreateCylinder";
            this.toolStripCreateCylinder.Size = new System.Drawing.Size(29, 24);
            this.toolStripCreateCylinder.Text = "toolStripButton3";
            this.toolStripCreateCylinder.ToolTipText = "Create Cylinder";
            this.toolStripCreateCylinder.Click += new System.EventHandler(this.toolStripCreateCylinder_Click);
            // 
            // toolStripCreateSphere
            // 
            this.toolStripCreateSphere.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCreateSphere.Image = global::Onyx3DEditor.Properties.Resources.stock_draw_sphere__1_;
            this.toolStripCreateSphere.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripCreateSphere.Name = "toolStripCreateSphere";
            this.toolStripCreateSphere.Size = new System.Drawing.Size(29, 24);
            this.toolStripCreateSphere.Text = "toolStripButton4";
            this.toolStripCreateSphere.ToolTipText = "Create Sphere";
            this.toolStripCreateSphere.Click += new System.EventHandler(this.toolStripCreateSphere_Click);
            // 
            // toolStripCreateTeapot
            // 
            this.toolStripCreateTeapot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCreateTeapot.Image = global::Onyx3DEditor.Properties.Resources.if_teapot_93284;
            this.toolStripCreateTeapot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripCreateTeapot.Name = "toolStripCreateTeapot";
            this.toolStripCreateTeapot.Size = new System.Drawing.Size(29, 24);
            this.toolStripCreateTeapot.Text = "toolStripButton3";
            this.toolStripCreateTeapot.ToolTipText = "Create Teapot";
            this.toolStripCreateTeapot.Click += new System.EventHandler(this.toolStripCreateTeapot_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripCreateLight
            // 
            this.toolStripCreateLight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCreateLight.Image = global::Onyx3DEditor.Properties.Resources.light_bulb;
            this.toolStripCreateLight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripCreateLight.Name = "toolStripCreateLight";
            this.toolStripCreateLight.Size = new System.Drawing.Size(29, 24);
            this.toolStripCreateLight.Text = "toolStripButton3";
            this.toolStripCreateLight.ToolTipText = "Create Light";
            this.toolStripCreateLight.Click += new System.EventHandler(this.toolStripCreateLight_Click);
            // 
            // toolStripCreateReflectionProbe
            // 
            this.toolStripCreateReflectionProbe.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCreateReflectionProbe.Image = global::Onyx3DEditor.Properties.Resources.if_stock_draw_sphere_16_94068;
            this.toolStripCreateReflectionProbe.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripCreateReflectionProbe.Name = "toolStripCreateReflectionProbe";
            this.toolStripCreateReflectionProbe.Size = new System.Drawing.Size(29, 24);
            this.toolStripCreateReflectionProbe.Text = "toolStripButton3";
            this.toolStripCreateReflectionProbe.Click += new System.EventHandler(this.toolStripCreateReflectionProbe_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripCreateEntity
            // 
            this.toolStripCreateEntity.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCreateEntity.Image = global::Onyx3DEditor.Properties.Resources.if_plug_extension_62666;
            this.toolStripCreateEntity.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripCreateEntity.Name = "toolStripCreateEntity";
            this.toolStripCreateEntity.Size = new System.Drawing.Size(29, 24);
            this.toolStripCreateEntity.Text = "toolStripButton3";
            this.toolStripCreateEntity.Click += new System.EventHandler(this.toolStripCreateTemplate_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripCreateCamera
            // 
            this.toolStripCreateCamera.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCreateCamera.Image = global::Onyx3DEditor.Properties.Resources.if_film_camera_35mm_45261;
            this.toolStripCreateCamera.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripCreateCamera.Name = "toolStripCreateCamera";
            this.toolStripCreateCamera.Size = new System.Drawing.Size(29, 24);
            this.toolStripCreateCamera.Text = "Create Camera";
            this.toolStripCreateCamera.Click += new System.EventHandler(this.toolStripCreateCamera_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // selectedObjectInspector
            // 
            this.selectedObjectInspector.AutoScroll = true;
            this.selectedObjectInspector.AutoSize = true;
            this.selectedObjectInspector.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.selectedObjectInspector.BackColor = System.Drawing.SystemColors.Control;
            this.selectedObjectInspector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedObjectInspector.Location = new System.Drawing.Point(0, 0);
            this.selectedObjectInspector.Margin = new System.Windows.Forms.Padding(4, 3, 8, 3);
            this.selectedObjectInspector.Name = "selectedObjectInspector";
            this.selectedObjectInspector.Size = new System.Drawing.Size(359, 602);
            this.selectedObjectInspector.TabIndex = 0;
            // 
            // toolStrip3
            // 
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonTextureManager,
            this.toolStripButtonMaterialManager,
            this.toolStripButtonEntityManager});
            this.toolStrip3.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(30, 602);
            this.toolStrip3.TabIndex = 2;
            this.toolStrip3.Text = "toolStripContent";
            // 
            // toolStripButtonTextureManager
            // 
            this.toolStripButtonTextureManager.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonTextureManager.Image = global::Onyx3DEditor.Properties.Resources.stock_3d_texture;
            this.toolStripButtonTextureManager.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTextureManager.Name = "toolStripButtonTextureManager";
            this.toolStripButtonTextureManager.Size = new System.Drawing.Size(27, 24);
            this.toolStripButtonTextureManager.Text = "toolStripButtonTextures";
            this.toolStripButtonTextureManager.Click += new System.EventHandler(this.toolStripButtonTextures_Click);
            // 
            // toolStripButtonMaterialManager
            // 
            this.toolStripButtonMaterialManager.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonMaterialManager.Image = global::Onyx3DEditor.Properties.Resources.stock_3d_texture_and_shading;
            this.toolStripButtonMaterialManager.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMaterialManager.Name = "toolStripButtonMaterialManager";
            this.toolStripButtonMaterialManager.Size = new System.Drawing.Size(27, 24);
            this.toolStripButtonMaterialManager.Text = "toolStripButtonMaterials";
            this.toolStripButtonMaterialManager.Click += new System.EventHandler(this.toolStripButtonMaterials_Click);
            // 
            // toolStripButtonEntityManager
            // 
            this.toolStripButtonEntityManager.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEntityManager.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEntityManager.Image")));
            this.toolStripButtonEntityManager.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEntityManager.Name = "toolStripButtonEntityManager";
            this.toolStripButtonEntityManager.Size = new System.Drawing.Size(27, 24);
            this.toolStripButtonEntityManager.Text = "toolStripButton3";
            this.toolStripButtonEntityManager.ToolTipText = "toolStripButtonEntityManager";
            this.toolStripButtonEntityManager.Click += new System.EventHandler(this.toolStripButtonEntityManager_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 14;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1305, 629);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainWindow";
            this.Text = "Onyx3DSharp";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStripScene.ResumeLayout(false);
            this.toolStripScene.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}


		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ToolStrip toolStrip3;
		private System.Windows.Forms.ToolStripButton toolStripButtonMaterialManager;
		private System.Windows.Forms.ToolStripButton toolStripButtonTextureManager;
		private OpenTK.GLControl renderCanvas;
		private System.Windows.Forms.ToolStrip toolStripScene;
		private ToolStripButton toolStripButtonChangeScene;
		private Timer timer1;
		private SplitContainer splitContainer2;
		private SelectedObjectInspector selectedObjectInspector;
		private ToolStrip toolStrip2;
		private ToolStripButton toolStripCreateCube;
		private ToolStripButton toolStripCreateTeapot;
		private ToolStripButton toolStripButtonMove;
		private ToolStripButton toolStripButtonScale;
		private ToolStripButton toolStripButtonRotate;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripButton toolStripCreateCylinder;
		private ToolStripButton toolStripCreateSphere;
		private SceneHierarchyControl sceneHierarchy;
		private ToolStripSeparator toolStripSeparator2;
		private ToolStripButton toolStripCreateLight;
        private ToolStripButton toolStripCreateQuad;
        private Label labelLoggerOutput;
		private ToolStripButton toolStripButtonImportModel;
        private ToolStripButton toolStripCreateEntity;
        private ToolStripSeparator toolStripSeparator3;
		private ToolStripDropDownButton toolStripDropDownButton1;
		private ToolStripMenuItem duplicateSceneObjectToolStripMenuItem;
		private ToolStripMenuItem deleteToolStripMenuItem;
		private ToolStripButton toolStripCreateReflectionProbe;
		private ToolStripDropDownButton toolStripDropDownButton2;
		private ToolStripMenuItem bakeToolStripMenuItem;
		private ToolStripMenuItem setParentToolStripMenuItem;
		private ContextMenuStrip contextMenuStrip1;
		private ToolStripMenuItem toolStripMenuItemConvertToEntity;
		private ToolStripMenuItem clearParentToolStripMenuItem;
		private ToolStripMenuItem groupObjectsToolStripMenuItem;
		private ToolStripMenuItem createEntityToolStripMenuItem;
		private ToolStripMenuItem excludeFromEntityToolStripMenuItem;
		private ToolStripDropDownButton toolStripDropDownButton3;
		private ToolStripMenuItem newSceneToolStripMenuItem;
		private ToolStripMenuItem saveSceneToolStripMenuItem;
		private ToolStripSeparator toolStripSeparator4;
		private ToolStripMenuItem newProjectToolStripMenuItem;
		private ToolStripMenuItem saveProjectToolStripMenuItem;
		private ToolStripMenuItem openProjectToolStripMenuItem;
		private ToolStripSeparator toolStripSeparator5;
		private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripButton toolStripCreateCamera;
		private ToolStripButton toolStripButtonEntityManager;
		private Label renderInfoLabel;
        private ToolStripDropDownButton toolStripDropDownButton4;
        private ToolStripMenuItem refreshToolStripMenuItem;
		private ToolStripMenuItem updateMaterialAttributesToolStripMenuItem;
        private ToolStripMenuItem reloadDefaultShaderToolStripMenuItem;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
    }
}