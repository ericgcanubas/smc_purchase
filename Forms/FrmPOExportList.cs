using PurchasePrinting.Class;
using PurchasePrinting.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PurchasePrinting.Forms
{
    public partial class FrmPOExportList : Form
    {

        private string supplierCode;
        private DateTime dateFrom;
        private DateTime dateTo;
        private bool isPrinted;
        private bool isDate;
        private string PRStart;
        private string PREnd;
        private bool isLastModify;

        string configPath;
        public FrmPOExportList(string supplierCode, DateTime dateFrom, DateTime dateTo, bool isDate, string PRStart, string PREnd, bool isPrinted, bool isLastModify)
        {
            InitializeComponent();
            this.supplierCode = supplierCode.Trim();
            this.dateFrom = dateFrom;
            this.dateTo = dateTo;
            this.isDate = isDate;
            this.PRStart = PRStart;
            this.PREnd = PREnd;
            this.isPrinted = isPrinted;
            this.isLastModify = isLastModify;
        }

        private void FrmPOExportList_Load(object sender, EventArgs e)
        {
            this.Text = this.supplierCode + '|' + this.dateFrom + '|' + this.dateTo;
            ClsListView.listViewLayoutDark(lvList);
            DataTable result = this.isDate ? ClsPurchaseOrder.getListByDateExport(this.supplierCode, this.dateFrom, this.dateTo, this.isPrinted, this.isLastModify) : ClsPurchaseOrder.getListByPONumberExport(this.supplierCode, this.PRStart, this.PREnd, this.isPrinted);
            ClsListView.LoadListCheckBoxView(lvList, result);
            TsTotal.Text = lvList.Items.Count.ToString();
            pnlWait.Visible = false;
            this.UseWaitCursor = false;
            var config = ClsDirectory.getDirectory();
             configPath = config["Export"];
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] poList = ClsListView.GetCheckedItems(lvList, 1);

            if (poList == null || poList.Length == 0)
            {
                MessageBox.Show(this, "PO not selected", "Invalid message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            try
            {


                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
                    {
                        folderDialog.SelectedPath = configPath;
                        folderDialog.Description = "Select a folder to save PDF file";
                        folderDialog.ShowNewFolderButton = true; // Allow creating new folders

                        if (folderDialog.ShowDialog() == DialogResult.OK)
                        {
                            string selectedPath = folderDialog.SelectedPath;
                            configPath = selectedPath;

                            ClsDirectory.UpdateIniFile("Export", configPath);

                            pnlWait.Visible = true;
                            this.UseWaitCursor = true;
                            Application.DoEvents();
                            for (int i = 0; i < poList.Length; i++)
                            {
                                string poNumber = poList[i];

                                proccessAction(poNumber);
                            }

                            MessageBox.Show(this, "Export successfully", "System message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();

                        }
                    }
                }


           



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            pnlWait.Visible = false;
            this.UseWaitCursor = false;

        }

        private void proccessAction(string PO)
        {
            var con = DatabaseHelper.getConnectionSource();
            var server = con["Server"];
       


            PONew reportDocument = new PONew();
            reportDocument.SetParameterValue(0, PO);
            reportDocument.SetParameterValue(1, true);
            reportDocument.DataSourceConnections[0].SetConnection(server, "Pegasus", "sa", "");


            var firstRecord = ClsQuery.GetFirstRecord($@" SELECT tbl_Suppliers.SupplierName, tbl_Suppliers.eMailAddress 
                                                          FROM [tbl_PONew]  
                                                          LEFT OUTER JOIN tbl_Suppliers 
                                                          ON [tbl_PONew].SupplierKey = tbl_Suppliers.PK 
                                                          WHERE [tbl_PONew].PONo = '{PO}'");


            if (string.IsNullOrWhiteSpace((string)firstRecord["SupplierName"]))
            {
                MessageBox.Show(this, $"Supplier name not found for PO: {PO}", "System message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            //if (string.IsNullOrWhiteSpace((string)firstRecord["eMailAddress"]))
            //{
            //    MessageBox.Show(this, $"Supplier Email not set", "System message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    return;
            //}


            // Get today's date in YYYY-MM-DD format
            string dateFolder = DateTime.Now.ToString("yyyy-MM-dd");
            // Define supplier-specific directory with date subfolder
            string supplierDirectory = Path.Combine(configPath, dateFolder, (string)firstRecord["SupplierName"]);

            // Ensure the directory exists
            if (!Directory.Exists(supplierDirectory))
            {
                Directory.CreateDirectory(supplierDirectory);
            }


            string fileName = "";

            if ((string)firstRecord["eMailAddress"] == string.Empty)
            {
                fileName = PO + ".pdf";
                // no emailS
            }
            else
            {
                fileName = PO + $"[{(string)firstRecord["eMailAddress"]}].pdf";
            }
            string exportPath = Path.Combine(supplierDirectory, fileName);
            // Export the report to PDF
            reportDocument.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, exportPath);
            Application.DoEvents();
            if (File.Exists(exportPath)) // Check if the file was successfully created
            {
                ClsPurchaseOrder.PO_UPDATE_Exported(PO);
            }

        }
        private void checkAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsListView.SetAllChecked(lvList, true);

        }

        private void uncheckAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsListView.SetAllChecked(lvList, false);

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
