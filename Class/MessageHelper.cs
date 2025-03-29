using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PurchasePrinting.Class
{
    class MessageHelper
    {
        public static bool MessageQuestion(string messagTxt, string titleTxt)
        {
            DialogResult result = MessageBox.Show(messagTxt, titleTxt, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                return true;
            }

            return false;
        }
    }
}
