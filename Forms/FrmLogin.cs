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
    public partial class FrmLogin : Form
    {
        public int userId = 0;
        public bool isLogin = false;
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            lblUsername.Text = "";

            LoadUser();
            selectListUser();


            var config = UserDirectory.getDirectory();
            lblUsername.Text = config["savelogin"].ToString();
            var item = lstUser.FindItemWithText(lblUsername.Text);
            if (item != null)
            {
                tabControl1.SelectTab(1);
                txtPassword.SelectAll();
            }

        }
        private void LoadUser()
        {
            lstUser.Items.Clear();
            DataTable dt = SqlHelper.dataList("SELECT UserName, Gender, Picture From tbl_UsersRights ORDER BY UserName");
            foreach (DataRow item in dt.Rows)
            {
                int Imgky = 0;
                if (int.Parse(item["Gender"].ToString()) == 1)
                {
                    // make
                    Imgky = 0;
                }
                else
                {
                    Imgky = 1;
                }
                lstUser.Items.Add(item["UserName"].ToString(), Imgky);

            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string entryPassword = Encryptor.Encrypt(MiscHelper.FormatSQL(txtPassword.Text.Trim()));
            var dt = SqlHelper.GetFirstRecord($@"SELECT tbl_UsersRights.* From tbl_UsersRights WHERE UserName = '{lblUsername.Text}'  AND Password = '{entryPassword}' ");
            if (dt != null)
            {
                userId = (int)dt["PK"];
                UserDirectory.UpdateIniFile("savelogin", lblUsername.Text);
                isLogin = true;
                Close();
            }
            else
            {
                txtPassword.SelectAll();
                MessageBox.Show("Invalid username or password", "System message");
            }



        }

        private void lstUser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstUser_Click(object sender, EventArgs e)
        {
            //selectUser();
        }

        private void lstUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                selectUser();
            }
        }
        private void selectUser()
        {
            if (lstUser.Items.Count > 0)
            {
                lstUser.Select();
                lblUsername.Text = lstUser.FocusedItem.Text;
            }

            if (lblUsername.Text.Length > 0)
            {
                tabControl1.SelectTab(1);
                txtPassword.SelectAll();
            }

        }
        private void selectListUser()
        {
            lblUsername.Text = "";
            txtPassword.Clear();
            if (lstUser.Items.Count > 0)
            {
                lstUser.Select();

            }
            tabControl1.SelectTab(0);
        }

        private void lstUser_DoubleClick(object sender, EventArgs e)
        {
            selectUser();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Back == e.KeyCode)
            {
                if (txtPassword.Text.Length == 0)
                {
                    selectListUser();
                }

            }

            if (Keys.Enter == e.KeyCode)
            {
                btnLogin.PerformClick();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            selectListUser();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lblUsername.Text.Length == 0)
            {
                selectListUser();
            }
            if (tabControl1.SelectedIndex == 0)
            {
                lblUsername.Text = "";
            }
        }
        private void SaveUserlogin()
        {
            var db = ClsDirectory.getDirectory();

        }
    }
}
