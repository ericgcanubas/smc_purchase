using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;

public static class ConfigReader
{
    public static Dictionary<string, string> ReadConfig(string filePath)
    {
        var config = new Dictionary<string, string>();

        foreach (var line in File.ReadAllLines(filePath))
        {
            // Skip comments and empty lines
            if (string.IsNullOrWhiteSpace(line) || line.StartsWith(";") || line.StartsWith("#"))
                continue;

            // Parse key-value pairs
            var parts = line.Split('=', (char)2); // Split by the first '='
            if (parts.Length == 2)
            {
                var key = parts[0].Trim();
                var value = parts[1].Trim();
                config[key] = value;
            }
        }

        return config;
    }
}