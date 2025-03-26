using PurchasePrinting.Class;
using PurchasePrinting.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PurchasePrinting
{
    public partial class FrmPRBatchPrinting : Form
    {

        public bool isPR = false;
        public bool isExport;
        public string[] ArrayInfo;
        private int _;

        public FrmPRBatchPrinting(bool isPR, bool isExport)
        {
            InitializeComponent();

            this.isPR = isPR;
            this.isExport = isExport;
        }

        private void ClickRadio(bool isDate)
        {
            if (isDate)
            {
                grpDate.Enabled = true;
                grpPRNumber.Enabled = false;

                return;
            }

            grpDate.Enabled = false;
            grpPRNumber.Enabled = true;
        }
        private void defaultPRNumber()
        {

            txtPRNumberStart.Text = (isPR == true ? "" : cmbType.Text) + cmbYear.Text + "000000";
            txtPRnumberEnd.Text = (isPR == true ? "" : cmbType.Text) + cmbYear.Text + "999999";
        }
        private void FrmPRBatchPrinting_Load(object sender, EventArgs e)
        {
            ClsListView.listViewLayoutDefault(listViewSuppliers);
            listViewSuppliers.Visible = false;
            rbDate.Checked = true;

            filterSupplier();
            listViewSuppliers.Size = new Size(582, 206);
            ClsControl.cmbYearSetup(cmbYear);
            ClsPurchaseOrder.cmbPOTypeSetup(cmbType);
            cmbYear.Text = DateTime.Now.Year.ToString();


            this.defaultPRNumber();


            if (isPR == false)
            {
                rbPR.Text = "PO Number";
                rbDate.Text = "PO Date";



                cmbType.Visible = true;

                if (isExport)
                {
                    chkAlreadyPrinted.Text = "Already Exported";
                    this.Text = "PURCHASE ORDER [EXPORT]";
                    this.chkIsLastModify.Visible = false;
                    BtnGenerate.Text = "Generate";
                    BackColor = Color.LightYellow;
                }
                else
                {
                    this.chkIsLastModify.Visible = true;
                    this.Text = "PURCHASE ORDER [PRINT]";
                    BtnGenerate.Text = "PO Generate";
                    BackColor = Color.PeachPuff;
                }

            }
            else
            {

                rbDate.Text = "PR Date";
                this.Text = "PURCHASE REQUISITION [PRINT]";
                BtnGenerate.Text = "PR Generate";
                cmbType.Visible = false;
                BackColor = Color.LightCyan;
            }

            lblHeader.Text = this.Text;

        }
        private void filterSupplier()
        {
            DataTable suppliers = ClsSupplier.GetTopSuppliers(txtSupplierName.Text);
            ClsListView.LoadListView(listViewSuppliers, suppliers);

        }
        private void rbDate_CheckedChanged(object sender, EventArgs e)
        {
            ClickRadio(true);
        }
        private void rbPR_CheckedChanged(object sender, EventArgs e)
        {
            ClickRadio(false);
        }
        private void txtSupplierName_TextChanged(object sender, EventArgs e)
        {
            filterSupplier();
            listViewSuppliers.Visible = true;

            if (txtSupplierName.Text.Trim() == "")
            {
                txtSupplierID.Clear();
            }
        }
        private void btnSupplier_Click(object sender, EventArgs e)
        {

            if (listViewSuppliers.Visible)
            {
                listViewSuppliers.Visible = false;
                return;
            }
            listViewSuppliers.Visible = true;
        }

        private void txtSupplierName_Click(object sender, EventArgs e)
        {
            listViewSuppliers.Visible = true;
            txtSupplierName.SelectAll();
        }

        private void txtSupplierName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (listViewSuppliers.Visible)
                {
                    listViewSuppliers.Select();
                    e.Handled = true;
                }
                return;
            }
            if (e.KeyCode == Keys.Down)
            {
                if (listViewSuppliers.Visible)
                {
                    listViewSuppliers.Select();
                    e.Handled = true;
                }
            }
            if (e.KeyCode == Keys.Escape)
            {

                listViewSuppliers.Visible = false;
                e.Handled = true;
                return;
            }
        }

        private void listViewSuppliers_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void listViewSuppliers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                e.Handled = false;
            }
            else if (char.IsLetterOrDigit((char)e.KeyValue) || e.KeyCode == Keys.Back || e.KeyCode == Keys.Escape)
            {
                txtSupplierName.Focus();

                txtSupplierName.SelectionStart = txtSupplierName.Text.Length;
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (listViewSuppliers.Items.Count > 0)
                {
                    supplierSelected();
                    e.Handled |= true;
                    return;
                }

                e.Handled = false;
            }

        }
        private void supplierSelected()
        {
            ArrayInfo = null;
            try
            {
                int selectedIndex = listViewSuppliers.SelectedIndices[0];
                string code = listViewSuppliers.Items[selectedIndex].SubItems[1].Text;

                ArrayInfo = ClsSupplier.GetSupplierInfo(code).Split(new string[] { "|" }, 14, StringSplitOptions.None);


                if (Convert.ToInt32(ArrayInfo[11]) == 1)
                {
                    MessageBox.Show("SUPPLIER WAS INACTIVE ALREADY!", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    listViewSuppliers.Focus();
                    return;
                }

                if (Convert.ToDouble(ArrayInfo[12]) == 1)
                {
                    MessageBox.Show("SUPPLIER WAS ALREADY STOPPED FOR PURCHASE ORDER!", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    listViewSuppliers.Focus();
                    return;
                }

                if (Convert.ToInt32(ArrayInfo[13]) == 1)
                {
                    MessageBox.Show("SUPPLIER IS CURRENTLY IN EDIT MODE!", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    listViewSuppliers.Focus();
                    return;
                }

                string strRemarks = ArrayInfo[7]?.ToString();
                if (!string.IsNullOrWhiteSpace(strRemarks))
                {
                    DialogResult result = MessageBox.Show(
                        $"{strRemarks}\n\nCONTINUE?",
                        "CONFIRM",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button2
                    );

                    if (result == DialogResult.Yes)
                    {

                    }
                    else
                    {
                        return;
                    }

                }



                displaySupplierInfo();
                listViewSuppliers.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }
        private void displaySupplierInfo()
        {
            if (ArrayInfo != null && ArrayInfo.Length > 0)
            {

                txtSupplierID.Text = Convert.ToDouble(ArrayInfo[1]).ToString("00000000");
                txtSupplierName.Text = Convert.ToString(ArrayInfo[2]);
            }
            else
            {
                txtSupplierID.Text = string.Empty;
                txtSupplierName.Text = string.Empty;
            }


        }
        private void listViewSuppliers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewSuppliers_DoubleClick(object sender, EventArgs e)
        {
            supplierSelected();
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {

            if (txtSupplierID.Text.Trim() != "")
            {

                bool dataExist = ClsQuery.DataExist("tbl_Suppliers", "SupplierCode", txtSupplierID.Text);

                if (!dataExist)
                {
                    MessageBox.Show("Supplier not found", "Invalid message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (isPR)
            {
                FrmPRGenerateList PR = new FrmPRGenerateList(txtSupplierID.Text, dtpDateFrom.Value, dtpDateTo.Value, rbDate.Checked, txtPRNumberStart.Text, txtPRnumberEnd.Text, chkAlreadyPrinted.Checked, chkIsLastModify.Checked);
                ClsForm.OpenChild(PR);

                return;
            }

            if (isExport)
            {

                FrmPOExportList EX = new FrmPOExportList(txtSupplierID.Text, dtpDateFrom.Value, dtpDateTo.Value, rbDate.Checked, txtPRNumberStart.Text, txtPRnumberEnd.Text, chkAlreadyPrinted.Checked, chkIsLastModify.Checked);
                ClsForm.OpenChild(EX);
                return;
            }


            FrmPOGenerateList PO = new FrmPOGenerateList(txtSupplierID.Text, dtpDateFrom.Value, dtpDateTo.Value, rbDate.Checked, txtPRNumberStart.Text, txtPRnumberEnd.Text, chkAlreadyPrinted.Checked, chkIsLastModify.Checked);
            ClsForm.OpenChild(PO);

        }

        private void txtSupplierID_TextChanged(object sender, EventArgs e)
        {
            if (txtSupplierID.Text == "")
            {
                txtSupplierName.Clear();
                txtSupplierName.Select();
            }
        }

        private void btnSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                txtSupplierName.Select();


            }
        }

        private void txtSupplierID_Click(object sender, EventArgs e)
        {
            txtSupplierID.SelectAll();
            listViewSuppliers.Visible = false;
        }

        private void txtSupplierID_Leave(object sender, EventArgs e)
        {
            if (txtSupplierID.Text.Trim().Length > 0)
            {
                bool isNumeric = int.TryParse(txtSupplierID.Text, out _);

                if (isNumeric)
                {
                    txtSupplierID.Text = int.Parse(txtSupplierID.Text).ToString("00000000");
                    if (txtSupplierID.Text.Length > 0)
                    {
                        string supName = ClsQuery.GetSingleValue($" SELECT tbl_Suppliers.SupplierName  FROM tbl_Suppliers WHERE tbl_Suppliers.SupplierCode = '{txtSupplierID.Text}' ");
                        txtSupplierName.Text = supName;

                        if (supName.Length > 0)
                        {
                            BtnGenerate.Select();
                            listViewSuppliers.Visible = false;
                        }
                    }
                }
                else
                {

                    txtSupplierID.Clear();
                }

            }
        }

        private void fPrNumberFormat(TextBox textBox)
        {
            if (textBox.Text.Trim().Length > 0)
            {
                bool isNumeric = int.TryParse(textBox.Text, out _);

                if (isNumeric)
                {
                    if (textBox.Text.Length > 6)
                    {
                        textBox.Text = int.Parse(textBox.Text).ToString("0000000000");
                    }
                    else
                    {
                        textBox.Text = (isPR == true ? "" : cmbType.Text) + cmbYear.Text + int.Parse(textBox.Text).ToString((isPR == true ? "000000" : "00000"));
                    }

                }

            }
        }

        private void txtPRNumberStart_Leave(object sender, EventArgs e)
        {
            fPrNumberFormat(txtPRNumberStart);
            txtPRnumberEnd.Text = txtPRNumberStart.Text;
        }

        private void txtPRnumberEnd_Leave(object sender, EventArgs e)
        {
            fPrNumberFormat(txtPRnumberEnd);
        }

        private void txtPRNumberStart_Click(object sender, EventArgs e)
        {
            txtPRNumberStart.SelectAll();
        }

        private void txtPRnumberEnd_Click(object sender, EventArgs e)
        {
            txtPRnumberEnd.SelectAll();
        }

        private void txtPRNumberStart_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmPRBatchPrinting_Click(object sender, EventArgs e)
        {
            listViewSuppliers.Visible = false;
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.defaultPRNumber();

        }

        private void txtPRNumberStart_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtPRnumberEnd.Select();

            }
        }

        private void txtPRnumberEnd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnGenerate.Select();

            }
        }

        private void dtpDateFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpDateTo.Value = dtpDateFrom.Value;
                dtpDateTo.Select();

            }
        }

        private void dtpDateTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnGenerate.Select();

            }
        }
    }
}
