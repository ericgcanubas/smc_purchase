using PurchasePrinting.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PurchasePrinting
{


    public partial class FrmPRGenerateList : Form
    {
        private string supplierCode;
        private DateTime dateFrom;
        private DateTime dateTo;

        private bool isDate;
        private string PRStart;
        private string PREnd;
        private bool isPrinted;
        private bool IsClosed = false;
        private PrintDocument printDocument;
        private bool isLastModify;
        private string prNo;
        public FrmPRGenerateList(string supplierCode, DateTime dateFrom, DateTime dateTo, bool isDate, string PRStart, string PREnd, bool isPrinted, bool isLastModify)
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

        private void FrmPRGenerateList_Load(object sender, EventArgs e)
        {
            this.Text = this.supplierCode + '|' + this.dateFrom + '|' + this.dateTo;
            ClsListView.listViewLayoutDark(lvList);
            DataTable result = this.isDate ? ClsPurchaseReq.getListByDate(this.supplierCode, this.dateFrom, this.dateTo, this.isPrinted,this.isLastModify) : ClsPurchaseReq.getListByPRnumber(this.supplierCode, this.PRStart, this.PREnd, this.isPrinted);
            ClsListView.LoadListCheckBoxView(lvList, result);
            TsTotal.Text = lvList.Items.Count.ToString();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void print2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void lvList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvList_DoubleClick(object sender, EventArgs e)
        {
            //Process(lvList.SelectedItems[0].Text);
        }
        private void Process(string prNumber)
        {

            this.prNo = prNumber;
            printDocument = new PrintDocument();
            printDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
            printDocument.DefaultPageSettings.Landscape = false; // Set to true for landscape
            foreach (PaperSize ps in printDocument.PrinterSettings.PaperSizes)
            {
                if (ps.PaperName == "Letter") // Change to your preferred size
                {
                    printDocument.DefaultPageSettings.PaperSize = ps;
                    break;
                }
            }

            printDocument.PrintPage += PrintDocument_PrintPage;

            using (PrintDialog printDialog = new PrintDialog())
            {
                printDialog.Document = printDocument;
                printDocument.Print();

            }
        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            this.PrintContext(e, this.prNo);
        }
        private void PrintContext(PrintPageEventArgs e, string key)
        {
            ClsPurchaseReq.PrintPR(e, key);

        }

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            string[] prList = ClsListView.GetCheckedItems(lvList, 1);

            if (prList == null || prList.Length == 0)
            {
                MessageBox.Show(this, "PR not selected", "Invalid message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            FrmNewPrintPR frm = new FrmNewPrintPR(prList, ref this.IsClosed);
            frm.ShowDialog();
            frm.Dispose();

            if (this.IsClosed)
            {
                this.Close();
            }
        }

        private void uncheckAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsListView.SetAllChecked(lvList, false);
        }

        private void checkAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsListView.SetAllChecked(lvList, true);
        }
    }


}
