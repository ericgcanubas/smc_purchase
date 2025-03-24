using FSS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileSending
{
    public partial class FrmHistory : Form
    {
        private string _Username;
        public FrmHistory(string Username)
        {
            this._Username = Username;
            InitializeComponent();
        }

        private void btnReSend_Click(object sender, EventArgs e)
        {
            if (lvFiles.Items.Count == 0)
            {
                MessageBox.Show(this, "Record not found!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool isSelected = false;
            foreach (ListViewItem item in lvFiles.Items)
            {
                if (item.Checked == true)
                {
                    isSelected = true;
                }
            }

            if (isSelected)
            {
                FrmSendFile frm = new FrmSendFile("", lvFiles, true, _Username);
                frm.ShowDialog();
                frm.Dispose();
                RefreshList();
            }
            else
            {
                MessageBox.Show(this, "Po not selected", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void FrmHistory_Load(object sender, EventArgs e)
        {
            RefreshList();
        }
        private void RefreshList()
        {
            DataTable dt = new DataTable();
            lvFiles.Items.Clear();
            if (dtDATE.Checked)
            {
                dt = AccessDatabase.dataList($"SELECT [ID],[PO_NUMBER],[EMAIL_ADDRESS],[DATE_SEND],[POSTED],[USERNAME] FROM [fileSend] WHERE DATEVALUE([DATE_SEND]) = #{dtDATE.Value.ToString("yyyy-MM-dd")}# order by [DATE_SEND] desc ");
            }
            else
            {
                dt = AccessDatabase.dataList($"SELECT [ID],[PO_NUMBER],[EMAIL_ADDRESS],[DATE_SEND],[POSTED],[USERNAME] FROM [fileSend] order by [DATE_SEND] desc ");

            }

            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["EMAIL_ADDRESS"].ToString()); // Adjust column names
                item.SubItems.Add(row["PO_NUMBER"].ToString());
                item.SubItems.Add(row["ID"].ToString());
                item.SubItems.Add(row["DATE_SEND"].ToString());
                item.SubItems.Add(row["USERNAME"].ToString());

                if (bool.Parse(row["POSTED"].ToString()) == false)
                {
                    item.ForeColor = Color.Red;
                }
                //item.SubItems.Add(bool.Parse(row["POSTED"].ToString()) == false ? "Unpost" : "Post");

                lvFiles.Items.Add(item);
            }

            lblRecord.Text = $"Total Record : {lvFiles.Items.Count}";
        }

        private void dtDATE_ValueChanged(object sender, EventArgs e)
        {
            RefreshList();
        }
    }
}
