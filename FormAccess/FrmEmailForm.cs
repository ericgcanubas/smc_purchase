using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FSS
{
    public partial class FrmEmailForm : Form
    {
        int id;
        public FrmEmailForm(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtEmailAddress.Text.Trim().Length == 0)
            {

                MessageBox.Show("Email entry required");
                return;
            }

            if (txtEmailPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show("Password entry required");
                return;
            }

            if (this.id > 0)
            {
                AccessDatabase.ExecuteNonQuery($@"Update [email] set  EmailAddress='{txtEmailAddress.Text}',EmailPassword='{txtEmailPassword.Text}' where ID={this.id} ");

            }
            else
            {
                AccessDatabase.ExecuteNonQuery($@"INSERT into [email] (EmailAddress,EmailPassword) VALUES ('{txtEmailAddress.Text}','{txtEmailPassword.Text}')");

            }



            this.Close();

        }

        private void FrmEmailForm_Load(object sender, EventArgs e)
        {
            if (this.id > 0)
            {
                this.Text = "Edit Email";
                var dt = AccessDatabase.GetFirstRecord($@"select [EmailAddress],[EmailPassword] from [email] where [ID]={id}");
                if (dt != null)
                {
                    txtEmailAddress.Text = (string)dt["EmailAddress"];
                    txtEmailPassword.Text = (string)dt["EmailPassword"];
                }
                btnSave.Text = "Update";
            }
            else
            {
                this.Text = "Add Email";
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://myaccount.google.com/apppasswords");
        }
    }
}
