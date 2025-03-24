using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using PurchasePrinting.Class;
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
    public partial class FrmPOGenerateList : Form
    {

        private string supplierCode;
        private DateTime dateFrom;
        private DateTime dateTo;
        private bool isPrinted;
        private bool isDate;
        private string PRStart;
        private string PREnd;
        private bool IsClosed = false;
        private bool isLastModify;

        public FrmPOGenerateList(string supplierCode, DateTime dateFrom, DateTime dateTo, bool isDate, string PRStart, string PREnd, bool isPrinted, bool isLastModify)
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

        private void FrmPOGenerateList_Load(object sender, EventArgs e)
        {
            this.Text = this.supplierCode + '|' + this.dateFrom + '|' + this.dateTo;
            ClsListView.listViewLayoutDark(lvList);
            DataTable result = this.isDate ? ClsPurchaseOrder.getListByDate(this.supplierCode, this.dateFrom, this.dateTo, this.isPrinted, this.isLastModify) : ClsPurchaseOrder.getListByPONumber(this.supplierCode, this.PRStart, this.PREnd, this.isPrinted);
            ClsListView.LoadListCheckBoxView(lvList, result);

            TsTotal.Text = lvList.Items.Count.ToString();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lvList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string[] poList = ClsListView.GetCheckedItems(lvList, 1);

            if (poList == null || poList.Length == 0)
            {
                MessageBox.Show(this, "PO not selected", "Invalid message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            FrmPrintPO frm = new FrmPrintPO(poList, ref this.IsClosed);
            frm.ShowDialog();
            frm.Dispose();

            if (this.IsClosed)
            {
                this.Close();
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
    }
}
