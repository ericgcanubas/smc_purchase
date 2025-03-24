using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PurchasePrinting
{
    internal class ClsControl
    {
                
        public static string formatID(int id)
        {
            int number = id;
            string formattedNumber = number.ToString("00000000");
            return formattedNumber;
        }
        public static string formatSubID(int id)
        {
            int number = id;
            string formattedNumber = number.ToString("00000000");
            return formattedNumber;
        }

        private static FrmMain _mdiParent;

        // Set the MDI parent form
        public static void SetMdiParent(FrmMain mdiParent)
        {
            _mdiParent = mdiParent;
        }

        // Get the MDI parent form
        public static FrmMain GetMdiParent()
        {
            return _mdiParent;
        }

        public static void cmbYearSetup(System.Windows.Forms.ComboBox comboBox)
        {

            int startYear = 2008;
            int currentYear = DateTime.Now.Year;

            for (int year = startYear; year <= currentYear; year++)
            {
                comboBox.Items.Add(year);
            }

            // Optionally, set the default selected value
            comboBox.SelectedIndex = comboBox.Items.Count - 1;
        }
    }
}
