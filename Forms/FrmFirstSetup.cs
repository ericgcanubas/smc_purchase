using FSS;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
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
            string sourcePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "po.icc");
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


        private bool MakeDSN(string DSN)
        {

            try
            {
                string dsnName = DSN;  // Name of the DSN
                string server = DSN;   // Change to your SQL Server
                string database = "Pegasus"; // Change to your Database

                // DSN Registry Path (HKEY_CURRENT_USER for User DSN)
                string dsnRegistryPath = @"SOFTWARE\ODBC\ODBC.INI\" + dsnName;
                string odbcDriversPath = @"SOFTWARE\ODBC\ODBCINST.INI\ODBC Drivers";

                // ✅ Create DSN Key
                RegistryKey dsnKey = Registry.CurrentUser.CreateSubKey(dsnRegistryPath);
                if (dsnKey == null)
                {
                    MessageBox.Show("Failed to create DSN registry key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                dsnKey.SetValue("Driver", "SQLSRV32.DLL");  // ODBC SQL Server Driver
                dsnKey.SetValue("Server", server);
                dsnKey.SetValue("Database", database);
                dsnKey.SetValue("UID", "sa");  // Replace with actual username
                dsnKey.SetValue("PWD", "");  // Replace with actual password
                dsnKey.SetValue("Trusted_Connection", "No"); /// Use Windows Authentication
                dsnKey.Close();

                // ✅ Ensure "ODBC Drivers" key exists
                RegistryKey odbcKey = Registry.CurrentUser.OpenSubKey(odbcDriversPath, true);
                if (odbcKey == null)
                {
                    odbcKey = Registry.CurrentUser.CreateSubKey(odbcDriversPath);
                }

                odbcKey.SetValue(dsnName, "Installed");
                odbcKey.Close();

                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
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
                if (Directory.Exists(txtFileTransfer.Text) == false)
                {
                    MessageBox.Show("Choose a destination folder for completed file transfers.", "System setup");
                    return;
                }

                if (txtUsername.Text.Trim() == "" || txtPassword.Text.Trim() == "")
                {
                    MessageBox.Show("Please set a administrator username or password", "System setup");
                    return;
                }

                CopyDatabaseToExeFolder();
                AccessDatabase.ExecuteNonQuery($@"INSERT INTO [users] ([username],[password]) VALUES ('{txtUsername.Text}','{txtPassword.Text}')");
            }


            if (chkPrint.Checked == false && chkEmailSender.Checked == false)
            {
                MessageBox.Show("Please select Print and Export or Email Sender", "System setup");
                return;
            }


            makeConfig();
            Close();


        }
        public void makeConfig()
        {
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
                    admin={txtUsername.Text}

                    ";

            File.WriteAllText(configFile, defaultConfig.Trim());
            Console.WriteLine("Config file created successfully.");
        }
        public OdbcConnection GetConnection(string serverName)
        {

            string connectionString = $"DSN={serverName};UID=sa;PWD=;";
            return new OdbcConnection(connectionString);
        }
        public void ConnectionTest()
        {

            try
            {
                using (OdbcConnection conn = GetConnection(txtServer.Text))
                {
                    conn.Open();
                    MessageBox.Show("Connection Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    testConnection = true;
                }
            }
            catch (Exception)
            {
                testConnection = false;
                MessageBox.Show("Invalid connection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void btnTestConnection_Click(object sender, EventArgs e)
        {

            if (txtServer.Text.Length <= 3)
            {
                MessageBox.Show("Invalid Server name");
                return;
            }

            if (MakeDSN(txtServer.Text))
            {


                ConnectionTest();

            }
            //MessageBox.Show("Test connection success");
        }
    }
}
