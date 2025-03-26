using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PurchasePrinting.Forms
{


    public partial class FrmFirstSetup : Form
    {
        bool testConnection = false;
        public FrmFirstSetup()
        {
            InitializeComponent();
        }

        private void FrmFirstSetup_Load(object sender, EventArgs e)
        {

        }

        private void chkPrint_CheckedChanged(object sender, EventArgs e)
        {
            grpPrint.Enabled = chkPrint.Checked;
        }

        private void chkEmailSender_CheckedChanged(object sender, EventArgs e)
        {
            grpEmail.Enabled = chkEmailSender.Checked;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
                {
                    folderDialog.SelectedPath = txtFileTransfer.Text;
                    folderDialog.Description = "Select a folder";
                    folderDialog.ShowNewFolderButton = true; // Allow creating new folders

                    if (folderDialog.ShowDialog() == DialogResult.OK)
                    {
                        string selectedPath = folderDialog.SelectedPath;
                        txtFileTransfer.Text = selectedPath;
                    }
                }
            }
        }
        static void CopyDatabaseToExeFolder()
        {
            string sourcePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data.accdb");
            string destinationPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data.accdb");

            try
            {
                if (File.Exists(sourcePath) && !File.Exists(destinationPath))
                {
                    File.Copy(sourcePath, destinationPath, true);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error copying database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Import the SQLConfigDataSource function from the odbcinst library


        private void MakeDSN(string DSN)
        {

            string dsnName = "SMC2000"; // DSN Name
            string driver = "SQL Server"; // Must match ODBC driver list
            string server = "SMC2000"; // Your SQL Server name
            string database = "Pegasus"; // Target database
            string username = "sa"; // SQL Server login
            string password = ""; // SQL Server password

            // Ensure the DSN command is formatted correctly
            string command = $@"odbcconf.exe /a {{CONFIGSYSDSN ""{driver}"" ""DSN={dsnName}|Server={server}|Database={database}|UID={username}|PWD={password}""}}";

            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = $"/C {command}";
                process.StartInfo.Verb = "runas"; // Run as Administrator
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.Start();
                process.WaitForExit();

                Console.WriteLine("System DSN created successfully with SQL Authentication!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creating DSN: " + ex.Message);
            }

        }
        private void btnDone_Click(object sender, EventArgs e)
        {


            if (chkPrint.Checked == true)
            {
                if (testConnection == false)
                {
                    MessageBox.Show("Test connection success is required", "System setup");
                }
            }


            if (chkEmailSender.Checked == true)
            {

                if (!File.Exists(txtFileTransfer.Text))
                {
                    MessageBox.Show("Choose a distination folder for completed file transfers.", "System setup");
                    return;
                }

                if (txtUsername.Text.Trim() == "" || txtPassword.Text.Trim() == "")
                {
                    MessageBox.Show("Please set a administrator username or password", "System setup");
                    return;
                }

                CopyDatabaseToExeFolder();

            }





            string configFile = "config.ini";
            string defaultConfig = $@"

                    [Mode]
                    printing={chkPrint.Checked}
                    emailsender={chkEmailSender.Checked}

                    [Database]
                    Server={txtServer.Text}    
                    
         
                    [Directory]
                    Export=
                    store=
                    save={txtFileTransfer.Text}

                    [send_prev]
                    email=
                    subject= 
                    message=

                    [users]
                    savelogin=

                    ";







            File.WriteAllText(configFile, defaultConfig.Trim());
            Console.WriteLine("Config file created successfully.");
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {


            testConnection = true;
            MakeDSN(txtServer.Text);
            MessageBox.Show("Test connection success");
        }
    }
}
