using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.IO;

namespace PurchasePrinting
{
    [RunInstaller(true)]
    public class CustomInstaller : Installer
    {
        public override void Uninstall(System.Collections.IDictionary savedState)
        {
            base.Uninstall(savedState);

            string installPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\Southwood Mindanao Corporation\PrintExportSetup";

            try
            {
                if (Directory.Exists(installPath))
                {
                    Directory.Delete(installPath, true); // Delete all files and subfolders
                    EventLog.WriteEntry("YourApp", "Deleted installation directory successfully.");
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("YourApp", "Error deleting directory: " + ex.Message, EventLogEntryType.Error);
            }
        }
    }
}
