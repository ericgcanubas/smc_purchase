using FileSending;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace FSS
{
    public partial class FrmSendFile : Form
    {
        public string saveFile;
        public bool reSend;
        public string pathFile;
        public ListView lvFiles;
        public string _username;
        public FrmSendFile(string pathFile, ListView lvFiles, bool reSend, string userName)
        {
            this._username = userName;
            this.pathFile = pathFile;
            this.lvFiles = lvFiles;
            this.reSend = reSend;

            InitializeComponent();
        }

        private void FrmSendFile_Load(object sender, EventArgs e)
        {
            lblPleaseWait.Visible = false;
            this.UseWaitCursor = false;
            DataTable result = AccessDatabase.dataList("select EmailAddress from email");
            foreach (DataRow dt in result.Rows)
            {
                cmbEmail.Items.Add(dt["EmailAddress"]);
            }


            var config = ConnectionHelper.getDirectory();

            saveFile = config["save"];

            var sen = SendHelper.getPrev();
            txtSubject.Text = sen["subject"];
            txtMessage.Text = sen["message"];
            cmbEmail.Text = sen["email"];


            generateEmailDestination();
        }
        private void hasSaveFile()
        {

            if (Directory.Exists(saveFile) == false)
            {
                btnSendEmail.Enabled = false;
                cmbEmail.Enabled = false;
                return;
            }

            btnSendEmail.Enabled = true;
            cmbEmail.Enabled = true;
        }

        private void getAttach(string SEND_EMAIL)
        {


            foreach (ListViewItem item in this.lvFiles.Items)
            {
                if (item.Checked == true)
                {

                    if (AccessDatabase.RecordExists($"Select * from [fileSend] where [PO_NUMBER] = '{item.SubItems[2].Text}' ") == false)
                    {

                        string Email = getTextEmail(item.SubItems[1].Text);

                        string FileAttachment = this.pathFile + @"\" + item.SubItems[2].Text + $"[{item.SubItems[1].Text}].pdf"; // original
                        string FileAttachment2 = this.pathFile + @"\" + item.SubItems[2].Text + $"[{Email}].pdf"; // original but must store

                        string SaveAttachment = saveFile + @"\" + item.SubItems[2].Text + ".pdf"; // rename
                        File.Move(FileAttachment, SaveAttachment); // transfer
                

                        AccessDatabase.ExecuteNonQuery($@"INSERT INTO [fileSend] ([PO_NUMBER],[EMAIL_ADDRESS],[SAVE_PATH],[SOURCE_PATH],[POSTED],[DATE_SEND],[SEND_EMAIL]) VALUES('{item.SubItems[2].Text}','{Email}','{SaveAttachment}','{FileAttachment2}',0,Now(),'{SEND_EMAIL}')");
                        Application.DoEvents();

                    }


                }

            }


        }
        private void getResend(string SEND_EMAIL)
        {
            foreach (ListViewItem item in this.lvFiles.Items)
            {
                if (item.Checked == true)
                {

                    string Email = getTextEmail(item.Text);

                    AccessDatabase.ExecuteNonQuery($"UPDATE [fileSend] set [POSTED] = 0,[DATE_SEND]=Now(),[SEND_EMAIL]='{SEND_EMAIL}',[EMAIL_ADDRESS]='{Email}' WHERE [ID] = {item.SubItems[2].Text} ");
                }

            }
        }
        private void getHeaderEmail(string emailAddress, string EmailPassword)
        {
            List<string> attachFile = new List<string>();
            DataTable dt = AccessDatabase.dataList("select [EMAIL_ADDRESS] from [fileSend] where [posted] = 0 group by [EMAIL_ADDRESS] ");
            foreach (DataRow row in dt.Rows)
            {
                string SENT_EMAIL = row["EMAIL_ADDRESS"].ToString();
                string[] arrayFiles = getAttachFile(SENT_EMAIL).ToArray();
                MailMessage mail = EmailHelper.mailMsg(emailAddress, txtSubject.Text, txtMessage.Text, SENT_EMAIL, arrayFiles);
                if (mail != null)
                {
                    EmailHelper.Smtp(mail, emailAddress, EmailPassword);
                    AccessDatabase.ExecuteNonQuery($@"update [fileSend] set [posted] = 1,[Username]='{_username}' where [posted] = 0 and [EMAIL_ADDRESS] = '{SENT_EMAIL}' ");
                }
            }
        }

        private void EmailHasChange()
        {
            DataTable dt = AccessDatabase.dataList("select COUNT(*) as [NO_PO],[EMAIL_ADDRESS] from [fileSend] where [posted] = 0 group by [EMAIL_ADDRESS] ");
            FrmConfirmation frm = new FrmConfirmation(dt);
            frm.ShowDialog();
            frm.Dispose();
        }
        private List<string> getAttachFile(string SENT_EMAIL)
        {
            List<string> saveFiles = new List<string>();
            DataTable dtFile = AccessDatabase.dataList($"select [SAVE_PATH] from [fileSend] where [posted] = 0 and [EMAIL_ADDRESS] = '{SENT_EMAIL}' ");
            foreach (DataRow fileRow in dtFile.Rows)
            {
                saveFiles.Add(fileRow["SAVE_PATH"].ToString());
            }

            return saveFiles;
        }
        private void emailSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEmailSetup frm = new FrmEmailSetup();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            if (cmbEmail.SelectedIndex == -1)
            {
                MessageBox.Show("Email not found");
                return;
            }

            try
            {

                var data = AccessDatabase.GetFirstRecord($@"select [EmailAddress],[EmailPassword] From [Email] where [EmailAddress] = '{cmbEmail.Text}'");
                if (data == null)
                {
                    MessageBox.Show("Email record not found");
                    return;
                }

                string emailAddress = (string)data["EmailAddress"];
                string emailPassword = (string)data["EmailPassword"];

                DialogResult result = MessageBox.Show($"Are you sure you want to send this file?", "Message Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }

                if (this.reSend == false)
                {
                    getAttach(emailAddress);
                }
                else
                {
                    getResend(emailAddress);
                }

                //EmailHasChange();

                lblPleaseWait.Visible = true;
                this.UseWaitCursor = true;
                Application.DoEvents();

                getHeaderEmail(emailAddress, emailPassword);
                SendHelper.UpdateIniFile("subject", txtSubject.Text);
                SendHelper.UpdateIniFile("message", txtMessage.Text);
                SendHelper.UpdateIniFile("email", cmbEmail.Text);

                lblPleaseWait.Visible = false;
                this.UseWaitCursor = false;
                Application.DoEvents();
                MessageBox.Show("Email sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            lblPleaseWait.Visible = false;
            this.UseWaitCursor = false;
        }
        public void generateEmailDestination()
        {   
            int IndexId = 0;
            int P = 25;
            int H = 0;
            pnlMain.Controls.Clear();
            int PO_FILE_TOTAL = 0;
            string tmpEmail = "";
            foreach (ListViewItem item in lvFiles.Items)
            {
                if (item.Checked == true)
                {
                    if (tmpEmail != item.SubItems[reSend ? 0 : 1].Text)
                    {
                        PO_FILE_TOTAL = 1;
                        Label lblNew = new Label();
                        lblNew.Name = $"lbl{IndexId}";
                        lblNew.Text = PO_FILE_TOTAL.ToString();
                        lblNew.Size = new Size(70, 23);
                        lblNew.TextAlign = ContentAlignment.MiddleCenter;
                        lblNew.Location = new Point(3, H);
                        pnlMain.Controls.Add(lblNew);

                        TextBox txtBox = new TextBox();
                        txtBox.Name = $"txt{IndexId}";
                        txtBox.Text = item.SubItems[reSend ? 0 :1].Text;
                        txtBox.Size = new Size(282, 23);
                        txtBox.Location = new Point(82, H);
                        pnlMain.Controls.Add(txtBox);
                        H = H + P;

                        IndexId++;
                    }
                    else
                    {
                        Label lbl = pnlMain.Controls.Find($"lbl{IndexId - 1}", true).FirstOrDefault() as Label;
                        PO_FILE_TOTAL++;
                        lbl.Text = PO_FILE_TOTAL.ToString();
                    }

                    tmpEmail = item.SubItems[reSend ? 0 : 1].Text;
                }


            }

        }
        public string getTextEmail(string CurrentEmail)
        {
            int IndexId = 0;
            string tmpEmail = "";
            foreach (ListViewItem item in lvFiles.Items)
            {
                if (item.Checked == true)
                {
                    if (tmpEmail != (reSend ? item.Text :  item.SubItems[1].Text))
                    {
                        TextBox txt = pnlMain.Controls.Find($"txt{IndexId}", true).FirstOrDefault() as TextBox;
                        if ((reSend ? item.Text : item.SubItems[1].Text) == CurrentEmail)
                        {
                            return txt.Text; // if got change
                        }
                        IndexId++;
                    }

                    tmpEmail = (reSend ? item.Text : item.SubItems[1].Text);
                }
            }

            return "";
        }


        public void LoadByHistory(DataTable dtFile)
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
    }

}
