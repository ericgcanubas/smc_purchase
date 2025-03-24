using PurchasePrinting.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PurchasePrinting.Forms
{
    public partial class FrmDirectory : Form
    {
        public FrmDirectory()
        {
            InitializeComponent();


        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
                {
                    folderDialog.SelectedPath = txtFiledata.Text;
                    folderDialog.Description = "Select a folder";
                    folderDialog.ShowNewFolderButton = true; // Allow creating new folders

                    if (folderDialog.ShowDialog() == DialogResult.OK)
                    {
                        string selectedPath = folderDialog.SelectedPath;
                        txtFiledata.Text = selectedPath;
                    }
                }
            }
        }

        private void FrmDirectory_Load(object sender, EventArgs e)
        {
            var config = ClsDirectory.getDirectory();
            txtFiledata.Text = config["Export"];

        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            ClsDirectory.UpdateIniFile("Export", txtFiledata.Text);
            MessageBox.Show(this, "Successfully save", "System Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
