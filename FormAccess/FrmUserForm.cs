using FSS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileSending.FormAccess
{
    public partial class FrmUserForm : Form
    {
        public bool isSave = false;
        private string tempUsername;
        private int _ID;

        public FrmUserForm(int ID)
        {
            _ID = ID;
            InitializeComponent();
        }

        private void FrmUserForm_Load(object sender, EventArgs e)
        {

            if (_ID > 0)
            {
                var dat = AccessDatabase.GetFirstRecord($@"select [username],[password] from [users] where [ID] = {_ID}");
                tempUsername = dat["username"].ToString();
                txtUsername.Text = tempUsername;
                txtPassword.Text = dat["password"].ToString();
                btnSave.Text = "Update";

                this.Text = "Update User Accounts";
                return;
            }


            this.Text = "Create User Accounts";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtUsername.Text.Length == 0)
            {
                MessageBox.Show("Please enter username");
                return;
            }
            if (txtPassword.Text.Length == 0)
            {
                MessageBox.Show("Please enter password");
                return;
            }


            if (AccessDatabase.RecordExists($@"SELECT * from [users] WHERE [username] <> '{tempUsername}' and [username] = '{txtUsername.Text}'") == true)
            {
                MessageBox.Show("Username already exists");
                return;
            }


            if (_ID > 0)
            {   
              

                AccessDatabase.ExecuteNonQuery($@"UPDATE [users]  SET [username] = '{txtUsername.Text}',[password]='{txtPassword.Text}' WHERE [ID] = {_ID} ");
            }
            else
            {


                AccessDatabase.ExecuteNonQuery($@"INSERT INTO [users] ([username],[password]) VALUES ('{txtUsername.Text}','{txtPassword.Text}')");
            }
            isSave = true;
            Close();
        }
    }
}
