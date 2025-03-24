using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FSS
{
    public partial class FrmPathSettings : Form
    {
        public FrmPathSettings()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            bool isSuccess = SavingFiles.Save(txtFile, "Select a folder for PDF");
            if (isSuccess)
            {
                ConnectionHelper.UpdateIniFile("store", txtFile.Text);
            }

        }

        private void FrmPathSettings_Load(object sender, EventArgs e)
        {
            var config = ConnectionHelper.getDirectory();
            txtFile.Text = config["store"];
            txtDestination.Text = config["save"];
        }
        private void btnDestination_Click(object sender, EventArgs e)
        {

            bool isSuccess = SavingFiles.Save(txtDestination, "Select a folder for Backup");
            if (isSuccess)
            {
                ConnectionHelper.UpdateIniFile("save", txtDestination.Text);
            }

        }

    }
}
