using EmailSenderToSupplier;
using PurchasePrinting.Class;
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
    public partial class FrmLogin : Form
    {
        public bool IsLogin { get; private set; }
        public string Username { get; private set; }
        public bool _IsAdmin;
        public FrmLogin(bool isAdmin = false)
        {
            InitializeComponent();
            _IsAdmin = isAdmin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {


            IsLogin = AccessDatabase.RecordExists($@"SELECT ID FROM [users] WHERE [Username]='{txtUsername.Text}' and [Password]='{txtPassword.Text}' ");

            if (IsLogin == false)
            {
                txtPassword.SelectAll();
                MessageBox.Show(this, "Invalid Username or Password", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.Username = txtUsername.Text.Trim().ToUpper();
            this.Close();

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            IsLogin = false;

            if(_IsAdmin == true)
            {

                var config = UserDirectory.getDirectory();

                txtUsername.Text = config["admin"].ToString();
                txtUsername.Enabled = false;
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Select();
            }
        }
    }
}
