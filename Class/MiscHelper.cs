using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PurchasePrinting.Class
{
    class MiscHelper
    {
        public static string FormatSQL(string str)
        {
            return str.Replace("'", "`");
        }


    }
}
