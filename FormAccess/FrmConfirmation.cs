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

    public partial class FrmConfirmation : Form
    {

        public DataTable dtFile;
        public FrmConfirmation(DataTable dt)
        {
            this.dtFile = dt;
            InitializeComponent();
        }

        private void FrmConfirmation_Load(object sender, EventArgs e)
        {
            int IndexId = 0;
            int P = 25;
            int H = 0;
            pnlMain.Controls.Clear();
            foreach (DataRow fileRow in dtFile.Rows)
            {
                Label lblNew = new Label();
                lblNew.Name = $"lbl{IndexId}";
                lblNew.Text = fileRow["NO_PO"].ToString();
                lblNew.Size = new Size(70, 23);
                lblNew.TextAlign = ContentAlignment.MiddleCenter;
                lblNew.Location = new Point(3, H);
                pnlMain.Controls.Add(lblNew);

                TextBox txtBox = new TextBox();
                txtBox.Name = $"txt{IndexId}";
                txtBox.Text = fileRow["EMAIL_ADDRESS"].ToString();
                txtBox.Size = new Size(282, 23);
                txtBox.Location = new Point(82, H);
                pnlMain.Controls.Add(txtBox);

                H = H + P;

                IndexId++;


            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int IndexId = 0;
            foreach (DataRow fileRow in dtFile.Rows)
            {
                TextBox txtBox = (TextBox)pnlMain.Controls.Find($"txt{IndexId}", true).FirstOrDefault();
                if (txtBox != null)
                {
                    string email = txtBox.Text;
                    AccessDatabase.ExecuteNonQuery($"UPDATE [fileSend] SET [EMAIL_ADDRESS] = '{email}' WHERE [POSTED] = 0 and [EMAIL_ADDRESS] = '{fileRow["EMAIL_ADDRESS"].ToString()}'");
                }

                IndexId++;
            }

            this.Close();
        }
    }
}
