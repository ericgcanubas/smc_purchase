using FSS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Data.OleDb;
using FileSending;
using System.Diagnostics;

namespace EmailSenderToSupplier
{
    public partial class FrmMain : Form
    {
        public string Username;

        public FrmMain()
        {
            InitializeComponent();
        }
        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
          

            loadDirectory();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private void isRun()
        {
            FrmLogin frm = new FrmLogin();
            frm.ShowDialog();
            if (frm.IsLogin == false)
            {
                Close();
            }
            else
            {

                Username = frm.Username;
                loadDirectory();
                ReadPdf();
            }

            frm.Dispose();

          

        }
        private void loadDirectory()
        {
            var config = ConnectionHelper.getDirectory();
            txtPath.Text = config["store"];

        }

        private void ReadPdf()
        {
      
            lvFiles.Items.Clear(); // Clear existing items
            if (Directory.Exists(txtPath.Text))
            {

                string[] pdf_files = Directory.GetFiles(txtPath.Text, "*.pdf"); //
                var pdfList = new List<Tuple<string, string, string>>();
                foreach (string pdf in pdf_files)
                {

                    string PO = OtherHelper.getPO(Path.GetFileName(pdf));
                    string Email = OtherHelper.getEmail(Path.GetFileName(pdf));
                    pdfList.Add(new Tuple<string, string, string>(Email, PO, pdf));

         
                }

                pdfList = pdfList.OrderBy(x => x.Item1).ToList();

                lvFiles.Items.Clear();

                int row = 0;
                foreach (var pdf in pdfList)
                {
                    row++;
                    ListViewItem item = new ListViewItem(row.ToString());
                    item.Checked = true;
                    item.SubItems.Add(pdf.Item1);
                    item.SubItems.Add(pdf.Item2);
                    lvFiles.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("File Not found does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadDirectory();
            ReadPdf();
        }


        private void emailSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEmailSetup frm = new FrmEmailSetup();
            frm.ShowDialog();
            frm.Dispose();
        }
        private void btnBrowseSource_Click(object sender, EventArgs e)
        {

            bool isSuccess = SavingFiles.Save(txtPath, "Select a folder for PDF files");

            if (isSuccess)
            {
                ConnectionHelper.UpdateIniFile("store", txtPath.Text);
            }

            loadDirectory();
            ReadPdf();
        }

        private void txtPath_DoubleClick(object sender, EventArgs e)
        {
            btnBrowseSource.PerformClick();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            bool hasSelected = false;
            if (lvFiles.Items.Count > 0)
            {

                foreach (ListViewItem item in lvFiles.Items)
                {
                    if (item.Checked == true)
                    {
                        hasSelected = true;
                    }
                }


                if (hasSelected == true)
                {
                    FrmSendFile frm = new FrmSendFile(txtPath.Text, lvFiles, false, Username);
                    frm.ShowDialog();
                    frm.Dispose();
                    btnRefresh.PerformClick();
                }

            }

        }

        private void btnHistory_Click(object sender, EventArgs e)
        {

            FrmHistory frm = new FrmHistory(Username);
            frm.ShowDialog();
            frm.Dispose();

        }

   

        private void lvFiles_DoubleClick(object sender, EventArgs e)
        {
            if (lvFiles.Items.Count > 0)
            {

                Process.Start($@"{txtPath.Text}\{lvFiles.FocusedItem.SubItems[2].Text}[{lvFiles.FocusedItem.SubItems[1].Text}].pdf");
            }
        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPath_Leave(object sender, EventArgs e)
        {

            try
            {
                ConnectionHelper.UpdateIniFile("store", txtPath.Text);
            }
            catch (Exception)
            {


            }

            loadDirectory();
            ReadPdf();


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            isRun();
               
        }

    }
}
