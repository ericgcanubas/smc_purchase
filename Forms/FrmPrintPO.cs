using PurchasePrinting.Class;
using PurchasePrinting.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PurchasePrinting.Forms
{
    public partial class FrmPrintPO : Form
    {

        string[] poList;
        public FrmPrintPO(string[] poList, ref bool IsClosed)
        {
            InitializeComponent();
            this.poList = poList;
            IsClosed = true;
            ClsPrinter.LoadInstalledPrinters(CmbPrinterName);
        }

        private void FrmPrintPO_Load(object sender, EventArgs e)
        {
            this.UseWaitCursor = false;
        }

        private void btnPrintCry_Click(object sender, EventArgs e)
        {
            proccessAction();
        }
        private void proccessAction()
        {

            this.btnPrintCry.Visible = false;
            this.lblWait.Visible = true;
            try
            {
                string list = "";
                for (int i = 0; i < this.poList.Length; i++)
                {
                    if (list == "")
                    {
                        list += "'" + poList[i] + "'";
                    }
                    else
                    {
                        list += ",'" + poList[i] + "'";
                    }
                }
                if (list == "")
                {

                    this.btnPrintCry.Visible = true;
                    this.lblWait.Visible = false;
                    MessageBox.Show(this, "PO not selected", "Invalid message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                this.UseWaitCursor = true;
                var con = DatabaseHelper.getConnectionSource();
                var server = con["Server"];
           
                PONew reportDocument = new PONew();
                reportDocument.SetParameterValue(0, poList);
                reportDocument.SetParameterValue(1, false);
                reportDocument.DataSourceConnections[0].SetConnection(server, "Pegasus", "sa", "");
                reportDocument.PrintOptions.PrinterName = CmbPrinterName.Text;  // Leave empty for default printer or specify printer name
                reportDocument.PrintToPrinter(1, false, 0, 0); // (copies, collate, start page, end page)
                ClsPurchaseOrder.PO_UPDATE_ALLByIn("PRINT P.O.", list);
                MessageBox.Show("Report sent to printer successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.UseWaitCursor = false;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.UseWaitCursor = false;
            this.btnPrintCry.Visible = true;
            this.lblWait.Visible = false;
        }
    }
}
