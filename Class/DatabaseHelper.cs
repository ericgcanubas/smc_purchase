using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

using System.IO;

namespace PurchasePrinting
{
    internal class DatabaseHelper
    {
        private static string section = "[Database]";
        private static readonly string configFilePath = "config.ini";
        public static Dictionary<string, string> getConnectionSource()
        {
            return ConfigReader.ReadConfig(configFilePath);
        }

        // Method to get a connection
        public static OdbcConnection GetConnection()
        {
            var config = getConnectionSource();

            // Build the connection string
            var server = config["Server"];
            var database = config["Database"];
            // var connectionString = $"Data Source={server};Initial Catalog={database};User ID=sa;Password=";
            var connectionString = $"DSN={server};UID=sa;PWD=;";
            return new OdbcConnection(connectionString);
        }

        public static void CryLogin(CrystalDecisions.CrystalReports.Engine.Table table)
        {

            var config = getConnectionSource();

            // Build the connection string
            var server = config["Server"];
            var database = config["Database"];

            ConnectionInfo connectionInfo = new ConnectionInfo
            {
                ServerName = server,
                DatabaseName = database,
                UserID = "sa",
                Password = ""
            };


            TableLogOnInfo logOnInfo = table.LogOnInfo;
            logOnInfo.ConnectionInfo = connectionInfo;
            table.ApplyLogOnInfo(logOnInfo);


        }

        public static void UpdateIniFile(string key, string newValue)
        {
            string filePath = configFilePath;

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found!");
                return;
            }

            List<string> lines = new List<string>(File.ReadAllLines(filePath));
            bool insideSection = false;

            for (int i = 0; i < lines.Count; i++)
            {
                string line = lines[i].Trim();

                if (line.Equals(section, StringComparison.OrdinalIgnoreCase))
                {
                    insideSection = true;
                    continue;
                }

                if (insideSection && line.StartsWith("[") && line.EndsWith("]"))
                {
                    break; // Stop if a new section starts
                }

                if (insideSection && line.StartsWith(key + "=", StringComparison.OrdinalIgnoreCase))
                {
                    lines[i] = $"{key}={newValue}";
                    File.WriteAllLines(filePath, lines);
                    Console.WriteLine("Config updated successfully.");
                    return;
                }
            }

            Console.WriteLine("Key not found in the specified section.");
        }
    }

}
