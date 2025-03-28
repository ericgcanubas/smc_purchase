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
    public partial class FrmEmailSetup : Form
    {
        public FrmEmailSetup()
        {
            InitializeComponent();
        }

        private void FrmEmailSetup_Load(object sender, EventArgs e)
        {

            timer1.Start();
            DisplayEmail();
        }
        private void DisplayEmail()
        {
            lvEmail.Items.Clear();
            DataTable dt = AccessDatabase.dataList("select ID,EmailAddress from email");

            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["ID"].ToString()); // Adjust column names
                item.SubItems.Add(row["EmailAddress"].ToString());
                lvEmail.Items.Add(item);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            FrmEmailForm frm = new FrmEmailForm(0);
            frm.ShowDialog();
            frm.Dispose();

            DisplayEmail();

        }

        private void lvEmail_DoubleClick(object sender, EventArgs e)
        {
            editEmail();
        }
        private void editEmail()
        {
            if (lvEmail.Items.Count > 0)
            {
                lvEmail.Select();
                FrmEmailForm frm = new FrmEmailForm(int.Parse(lvEmail.FocusedItem.Text));
                frm.ShowDialog();
                frm.Dispose();

                DisplayEmail();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            editEmail();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvEmail.Items.Count > 0)
            {

                lvEmail.Select();
                DialogResult result = MessageBox.Show($"Are you sure you want to delete?", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    int ID = int.Parse(lvEmail.FocusedItem.Text);
                    AccessDatabase.ExecuteNonQuery($"DELETE FROM [email] WHERE [ID] = {ID} ");
                    DisplayEmail();
                }
             
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            isRun();

        }

        private void isRun()
        {
            FrmLogin frm = new FrmLogin(true);
            frm.ShowDialog();
            if (frm.IsLogin == false)
            {
                Close();
            }
          
            frm.Dispose();



        }
    }
}
