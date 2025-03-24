using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PurchasePrinting
{
    internal class ClsPrinter
    {

        public static void LoadInstalledPrinters(ComboBox printerComboBox)
        {
            // Get all installed printers
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                printerComboBox.Items.Add(printer);
            }

            // Select the default printer, if available
            PrinterSettings printerSettings = new PrinterSettings();
            if (printerComboBox.Items.Contains(printerSettings.PrinterName))
            {
                printerComboBox.SelectedItem = printerSettings.PrinterName;
            }
        }
    }
}
