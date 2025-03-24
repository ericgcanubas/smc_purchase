using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportAppServer;
using CrystalDecisions.Shared;
using PurchasePrinting.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PurchasePrinting.Forms
{
    public partial class FrmPRDateReportViewer : Form
    {
        private string supplerCode;
        private DateTime DateFrom;
        private DateTime DateTo;
        private bool PR_Printed;
        private string printerName;                                                                                                          
        public FrmPRDateReportViewer(string supplerCode, DateTime DateFrom, DateTime DateTo, bool PR_Printed, string printerName)
        {
            InitializeComponent();

            this.supplerCode = supplerCode;
            this.DateFrom = DateFrom;
            this.DateTo = DateTo;
            this.PR_Printed = PR_Printed;
            this.printerName = printerName;
        }
     
        private void FrmReportViewer_Load(object sender, EventArgs e)
        {


            try
            {
                // Create an instance of the strongly-typed report
                //PRContextByDateRange reportDocument = new PRContextByDateRange();

                //// Set parameter values
                //reportDocument.SetParameterValue(0, this.DateTo.ToString("yyyy-MM-dd"));
                //reportDocument.SetParameterValue(1, this.DateFrom.ToString("yyyy-MM-dd"));
                //reportDocument.SetParameterValue(2, ClsSupplier.getSupCode(this.supplerCode));
                //reportDocument.SetParameterValue(3, (this.PR_Printed == true ? 1 : 0));

                //// Set database login details if required
                //foreach (Table table in reportDocument.Database.Tables)
                //{
                //    TableLogOnInfo logOnInfo = table.LogOnInfo;
                //    logOnInfo.ConnectionInfo.ServerName = "localhost";
                //    logOnInfo.ConnectionInfo.DatabaseName = "pegasus";
                //    logOnInfo.ConnectionInfo.UserID = "sa";
                //    logOnInfo.ConnectionInfo.Password = "";
                //    table.ApplyLogOnInfo(logOnInfo);
                //}

                //// Print the report directly to the default printer
                //reportDocument.PrintOptions.PrinterName = printerName;  // Leave empty for default printer or specify printer name
                //reportDocument.PrintToPrinter(1, false, 0, 0); // (copies, collate, start page, end page)



                //MessageBox.Show("Report sent to printer successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
