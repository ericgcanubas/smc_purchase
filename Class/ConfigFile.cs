using PurchasePrinting.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PurchasePrinting.Class
{
    class ConfigFile
    {
        public static void AutoCreateFile()
        {

            string configFile = "config.ini";

            if (File.Exists(configFile) == false)
            {


                FrmFirstSetup frm = new FrmFirstSetup();
                frm.ShowDialog();
                frm.Dispose();    
            }
            else
            {
                Console.WriteLine("Config file already exists.");
            }
        }
    }
}
