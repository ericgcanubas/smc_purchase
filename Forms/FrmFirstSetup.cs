using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace PurchasePrinting.Forms
{


    public partial class FrmFirstSetup : Form
    {

        // Import the SQLConfigDataSource function from the odbcinst library
        [DllImport("odbcinst.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern bool SQLConfigDataSource(
            IntPtr hwndParent,
            int fRequest,
            string lpszDriver,
            string lpszAttributes);


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




        private void MakeDSN(string DSN)
        {

            // DSN details
            string dsnName = DSN; // The name of the DSN
            string driverName = "SQL Server"; // ODBC driver name (as shown in ODBC Data Source Admin)
            string serverName = DSN; // SQL Server instance name or IP
            string databaseName = "Pegasus"; // Target database name
            string username = "sa"; // SQL login username
            string password = ""; // SQL login password

            try
            {
                // Path to the system DSN registry key
                string dsnRegistryPath = @"SOFTWARE\ODBC\ODBC.INI\" + dsnName;
                string odbcDataSourcesPath = @"SOFTWARE\ODBC\ODBC.INI\ODBC Data Sources";

                // Create the DSN registry key
                RegistryKey dsnKey = Registry.LocalMachine.CreateSubKey(dsnRegistryPath);
                if (dsnKey != null)
                {
                    dsnKey.SetValue("Driver", $@"C:\WINDOWS\System32\SQLSRV32.dll"); // Path to the driver
                    dsnKey.SetValue("Server", serverName);
                    dsnKey.SetValue("Database", databaseName);
                    dsnKey.SetValue("Trusted_Connection", "No"); // Set to "Yes" for Windows Authentication
                    dsnKey.SetValue("UID", username);
                    dsnKey.SetValue("PWD", password); // Warning: Password will be stored in plaintext
                    dsnKey.Close();
                }

                // Register the DSN in ODBC Data Sources
                RegistryKey odbcKey = Registry.LocalMachine.CreateSubKey(odbcDataSourcesPath);
                if (odbcKey != null)
                {
                    odbcKey.SetValue(dsnName, driverName);
                    odbcKey.Close();
                }

                Console.WriteLine("DSN created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
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
