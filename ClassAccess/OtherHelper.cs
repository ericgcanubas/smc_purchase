using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FSS
{
    class OtherHelper
    {
        public static string getPO(string filename)
        {
            // Regular Expression to extract PO number and email
            Match match = Regex.Match(filename, @"^(.*?)\[(.*?)\]\.pdf$");

            if (match.Success)
            {
                string poNumber = match.Groups[1].Value;  // PO001021
                string email = match.Groups[2].Value;     // admin@gmail.com
                return poNumber;
                //Console.WriteLine($"Email: {email}");
            }

            return "";

        }
        public static string getEmail(string filename)
        {
            // Regular Expression to extract PO number and email
            Match match = Regex.Match(filename, @"^(.*?)\[(.*?)\]\.pdf$");
            if (match.Success)
            {

                string email = match.Groups[2].Value;     // admin@gmail.com
                return email;
                //Console.WriteLine($"Email: {email}");
            }

            return "";
        }
    }
}
