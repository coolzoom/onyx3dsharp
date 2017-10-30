﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Onyx3DEditor
{
	public partial class TextureManager : Form
	{
		private TextureDBEntry mCurrentTexture;

		public TextureManager()
		{
			InitializeComponent();
			FillTexturesList();
		}

		private void FillTexturesList()
		{
			toolStripComboBoxTextures.Items.Clear();
			foreach (TextureDBEntry t in ContentDatabase.Textures)
			{
				toolStripComboBoxTextures.Items.Add(t.id);
			}
		}

		private void toolStripButtonOpen_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog();

			openFileDialog1.InitialDirectory = "c:\\";
			openFileDialog1.Filter = "PNG files (*.png)|*.png|JPG files (*.jpg)|*.jpg";//All files (*.*)|*.*
			openFileDialog1.FilterIndex = 2;
			openFileDialog1.RestoreDirectory = true;

			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				try
				{
					Bitmap bmp = new Bitmap(openFileDialog1.FileName);
					pictureBoxPreview.Image = bmp.GetThumbnailImage(256,256, null, IntPtr.Zero);
					
					mCurrentTexture = new TextureDBEntry();
					mCurrentTexture.path = openFileDialog1.FileName;
					mCurrentTexture.id = "NONE";
					ContentDatabase.Textures.Add(mCurrentTexture);

					UpdateTextureInfo();
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
				}
			}
		}

		private void UpdateTextureInfo()
		{
			textBoxFilePath.Text = mCurrentTexture.path;
			textBoxId.Text = mCurrentTexture.id;
		}

		private void textBoxId_TextChanged(object sender, EventArgs e)
		{
			if (mCurrentTexture != null)
			{
				mCurrentTexture.id = textBoxId.Text;
			}
		}

		private void toolStripComboBoxTextures_SelectedIndexChanged(object sender, EventArgs e)
		{
			mCurrentTexture = ContentDatabase.Textures[toolStripComboBoxTextures.SelectedIndex];
			UpdateTextureInfo();
		}
	}

}