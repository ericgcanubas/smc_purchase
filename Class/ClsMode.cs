using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PurchasePrinting.Class
{
    class ClsMode
    {
        private static string section = "[Mode]";
        private static readonly string configFilePath = "config.ini";
        public static Dictionary<string, string> getMode()
        {
            return ConfigReader.ReadConfig(configFilePath);
        }
    }
}
