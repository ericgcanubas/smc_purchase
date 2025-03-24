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
    public partial class FrmUserList : Form
    {
        public FrmUserList()
        {
            InitializeComponent();
        }

        private void FrmUserList_Load(object sender, EventArgs e)
        {
            getList();
            timer1.Start();
        }
        private void getList()
        {
            lvUser.Items.Clear();
            DataTable dt = AccessDatabase.dataList("select ID,[Username] from [Users]");

            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["ID"].ToString()); // Adjust column names
                item.SubItems.Add(row["Username"].ToString());
                lvUser.Items.Add(item);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmUserForm frm = new FrmUserForm(0);
            frm.ShowDialog();
            if(frm.isSave == true)
            {
                getList();
            }

            frm.Dispose();

        }
        private void userEdit()
        {
            if (lvUser.Items.Count > 0)
            {
                int ID = int.Parse(lvUser.FocusedItem.Text);
                FrmUserForm frm = new FrmUserForm(ID);
                frm.ShowDialog();
                if (frm.isSave == true)
                {
                    getList();
                }

                frm.Dispose();
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            userEdit();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvUser.Items.Count > 0)
            {
                int ID = int.Parse(lvUser.FocusedItem.Text);
                AccessDatabase.ExecuteNonQuery($"DELETE FROM [Users] WHERE [ID] = {ID} ");
                getList();
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
