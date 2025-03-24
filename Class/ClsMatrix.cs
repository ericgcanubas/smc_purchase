using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace PurchasePrinting
{
    internal class ClsMatrix
    {
        [DllImport("winspool.drv", SetLastError = true)]
        public static extern bool WritePrinter(
         IntPtr hPrinter,
         IntPtr pBytes,
         int dwCount,
         out int dwWritten);

        [DllImport("winspool.drv", SetLastError = true)]
        public static extern bool OpenPrinter(
            string pPrinterName,
            out IntPtr phPrinter,
            IntPtr pDefault);

        [DllImport("winspool.drv", SetLastError = true)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        // Method to send raw data to the printer
        public static bool PrintRawData(string printerName, string rawData)
        {
            IntPtr hPrinter = IntPtr.Zero;
            IntPtr pBytes = IntPtr.Zero;
            int dwWritten = 0;

            try
            {
                // Open the printer
                if (!OpenPrinter(printerName, out hPrinter, IntPtr.Zero))
                {
                    throw new Exception("Failed to open printer. Error: " + Marshal.GetLastWin32Error());
                }

                // Convert the raw data to a byte array
                byte[] bytes = Encoding.ASCII.GetBytes(rawData);

                // Allocate unmanaged memory for the data
                pBytes = Marshal.AllocHGlobal(bytes.Length);
                Marshal.Copy(bytes, 0, pBytes, bytes.Length);

                // Send the data to the printer
                if (!WritePrinter(hPrinter, pBytes, bytes.Length, out dwWritten))
                {
                    throw new Exception("Failed to write to printer. Error: " + Marshal.GetLastWin32Error());
                }

                return true; // Success
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false; // Failure
            }
            finally
            {
                // Free unmanaged memory
                if (pBytes != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(pBytes);
                }

                // Close the printer handle
                if (hPrinter != IntPtr.Zero)
                {
                    ClosePrinter(hPrinter);
                }
            }
        }

        /// <summary>
        /// Simulates rendering matrix printer ESC/P output.
        /// </summary>
        /// <param name="rawData">Raw ESC/P data string.</param>
        /// <param name="graphics">Graphics object for drawing.</param>
      public  static void SimulateMatrixOutput(string rawData, Graphics graphics)
        {
            // Define default styles
            Font normalFont = new Font("Courier New", 12, FontStyle.Regular);
            Font boldFont = new Font("Courier New", 12, FontStyle.Bold);
            Brush textBrush = Brushes.Black;

            // Split the raw data into lines
            string[] lines = rawData.Split('\n');
            float yPosition = 50; // Initial vertical position

            // Process each line
            foreach (var line in lines)
            {
                Font currentFont = normalFont;

                // Check for ESC/P commands
                if (line.Contains("\x1BE")) // ESC E - Bold ON
                {
                    currentFont = boldFont;
                }
                if (line.Contains("\x1BF")) // ESC F - Bold OFF
                {
                    currentFont = normalFont;
                }

                // Clean ESC/P commands from the text
                string cleanText = line.Replace("\x1BE", "").Replace("\x1BF", "").Replace("\x1B@", "");

                // Draw the text on the page
                graphics.DrawString(cleanText, currentFont, textBrush, new PointF(50, yPosition));
                yPosition += 20; // Move to the next line
            }
        }





    }
}
