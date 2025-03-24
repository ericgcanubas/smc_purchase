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
    public partial class FrmNewPrintPR : Form
    {
        string[] prList;
        public FrmNewPrintPR(string[] prList, ref bool IsClosed)
        {
            InitializeComponent();
            this.prList = prList;
            IsClosed = true;

            ClsPrinter.LoadInstalledPrinters(CmbPrinterName);
        }

        private void CmbPrinterName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmNewPrintPR_Load(object sender, EventArgs e)
        {

            this.UseWaitCursor = false;
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            this.BtnPrint.Visible = false;
            this.lblWait.Visible = true;
            try
            {


                string list = "";

                for (int i = 0; i < this.prList.Length; i++)
                {
                    if (list == "")
                    {
                        list += prList[i];
                    }
                    else
                    {
                        list += "," + prList[i];
                    }
                }


                if (list == "")
                {

                    this.BtnPrint.Visible = true;
                    this.lblWait.Visible = false;
                    MessageBox.Show(this,"PR not selected","Invalid message",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                    return;
                }

                this.UseWaitCursor = true;
                var con = DatabaseHelper.getConnectionSource();
                var server = con["Server"];


                PRNew reportDocument = new PRNew();       
                reportDocument.SetParameterValue(0, prList);
                reportDocument.DataSourceConnections[0].SetConnection(server, "Pegasus", "sa", "");
           
                reportDocument.PrintOptions.PrinterName = CmbPrinterName.Text;  // Leave empty for default printer or specify printer name
                reportDocument.PrintToPrinter(1, false, 0, 0); // (copies, collate, start page, end page)
                ClsPurchaseReq.PR_UPDATE_ALLByIn("PRINT P.O.V.", list);
                MessageBox.Show("Report sent to printer successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.UseWaitCursor = false;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.UseWaitCursor = false;
            this.BtnPrint.Visible = true;
            this.lblWait.Visible = false;
        }
    }
}
