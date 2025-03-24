using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PurchasePrinting.Forms
{
    public partial class FrmConnectionSetup : Form
    {
        public FrmConnectionSetup()
        {
            InitializeComponent();
        }

        private void FrmConnectionSetup_Load(object sender, EventArgs e)
        {

            try
            {
                var config = DatabaseHelper.getConnectionSource();

                //txtDatabase.Text = config["Database"];
                txtServer.Text = config["Server"];
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DatabaseHelper.UpdateIniFile("Server", txtServer.Text);
                //DatabaseHelper.UpdateIniFile("Database", txtDatabase.Text);
                MessageBox.Show("Successfully save");
            }
            catch (Exception)
            {

                throw;
            }
          
        }
    }
}
