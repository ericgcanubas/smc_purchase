namespace PurchasePrinting
{
    partial class FrmPRBatchPrinting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPRBatchPrinting));
            this.label1 = new System.Windows.Forms.Label();
            this.txtSupplierID = new System.Windows.Forms.TextBox();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.grpDate = new System.Windows.Forms.GroupBox();
            this.chkIsLastModify = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.grpPRNumber = new System.Windows.Forms.GroupBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPRnumberEnd = new System.Windows.Forms.TextBox();
            this.txtPRNumberStart = new System.Windows.Forms.TextBox();
            this.rbDate = new System.Windows.Forms.RadioButton();
            this.rbPR = new System.Windows.Forms.RadioButton();
            this.listViewSuppliers = new System.Windows.Forms.ListView();
            this.BtnGenerate = new System.Windows.Forms.Button();
            this.chkAlreadyPrinted = new System.Windows.Forms.CheckBox();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.grpDate.SuspendLayout();
            this.grpPRNumber.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 88);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "SUPPLIER";
            // 
            // txtSupplierID
            // 
            this.txtSupplierID.Location = new System.Drawing.Point(83, 86);
            this.txtSupplierID.Margin = new System.Windows.Forms.Padding(4);
            this.txtSupplierID.MaxLength = 8;
            this.txtSupplierID.Name = "txtSupplierID";
            this.txtSupplierID.Size = new System.Drawing.Size(90, 23);
            this.txtSupplierID.TabIndex = 1;
            this.txtSupplierID.Click += new System.EventHandler(this.txtSupplierID_Click);
            this.txtSupplierID.TextChanged += new System.EventHandler(this.txtSupplierID_TextChanged);
            this.txtSupplierID.Leave += new System.EventHandler(this.txtSupplierID_Leave);
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSupplierName.Location = new System.Drawing.Point(176, 86);
            this.txtSupplierName.Margin = new System.Windows.Forms.Padding(4);
            this.txtSupplierName.MaxLength = 100;
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Size = new System.Drawing.Size(550, 23);
            this.txtSupplierName.TabIndex = 2;
            this.txtSupplierName.Click += new System.EventHandler(this.txtSupplierName_Click);
            this.txtSupplierName.TextChanged += new System.EventHandler(this.txtSupplierName_TextChanged);
            this.txtSupplierName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSupplierName_KeyDown);
            // 
            // grpDate
            // 
            this.grpDate.Controls.Add(this.chkIsLastModify);
            this.grpDate.Controls.Add(this.label3);
            this.grpDate.Controls.Add(this.label2);
            this.grpDate.Controls.Add(this.dtpDateTo);
            this.grpDate.Controls.Add(this.dtpDateFrom);
            this.grpDate.Enabled = false;
            this.grpDate.Location = new System.Drawing.Point(13, 168);
            this.grpDate.Margin = new System.Windows.Forms.Padding(4);
            this.grpDate.Name = "grpDate";
            this.grpDate.Padding = new System.Windows.Forms.Padding(4);
            this.grpDate.Size = new System.Drawing.Size(373, 93);
            this.grpDate.TabIndex = 4;
            this.grpDate.TabStop = false;
            // 
            // chkIsLastModify
            // 
            this.chkIsLastModify.AutoSize = true;
            this.chkIsLastModify.Location = new System.Drawing.Point(35, 69);
            this.chkIsLastModify.Name = "chkIsLastModify";
            this.chkIsLastModify.Size = new System.Drawing.Size(146, 20);
            this.chkIsLastModify.TabIndex = 4;
            this.chkIsLastModify.Text = "Use Last Modify Date";
            this.chkIsLastModify.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(187, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "From";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateTo.Location = new System.Drawing.Point(190, 38);
            this.dtpDateTo.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(144, 23);
            this.dtpDateTo.TabIndex = 1;
            this.dtpDateTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpDateTo_KeyDown);
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFrom.Location = new System.Drawing.Point(35, 38);
            this.dtpDateFrom.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(144, 23);
            this.dtpDateFrom.TabIndex = 0;
            this.dtpDateFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpDateFrom_KeyDown);
            // 
            // grpPRNumber
            // 
            this.grpPRNumber.Controls.Add(this.cmbType);
            this.grpPRNumber.Controls.Add(this.label6);
            this.grpPRNumber.Controls.Add(this.cmbYear);
            this.grpPRNumber.Controls.Add(this.label4);
            this.grpPRNumber.Controls.Add(this.label5);
            this.grpPRNumber.Controls.Add(this.txtPRnumberEnd);
            this.grpPRNumber.Controls.Add(this.txtPRNumberStart);
            this.grpPRNumber.Enabled = false;
            this.grpPRNumber.Location = new System.Drawing.Point(397, 168);
            this.grpPRNumber.Margin = new System.Windows.Forms.Padding(4);
            this.grpPRNumber.Name = "grpPRNumber";
            this.grpPRNumber.Padding = new System.Windows.Forms.Padding(4);
            this.grpPRNumber.Size = new System.Drawing.Size(359, 93);
            this.grpPRNumber.TabIndex = 5;
            this.grpPRNumber.TabStop = false;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(7, 37);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(38, 24);
            this.cmbType.TabIndex = 8;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(53, 18);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Year Base";
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(52, 38);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(104, 24);
            this.cmbYear.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(257, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "To";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(159, 18);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "From";
            // 
            // txtPRnumberEnd
            // 
            this.txtPRnumberEnd.Location = new System.Drawing.Point(260, 38);
            this.txtPRnumberEnd.Margin = new System.Windows.Forms.Padding(4);
            this.txtPRnumberEnd.MaxLength = 10;
            this.txtPRnumberEnd.Name = "txtPRnumberEnd";
            this.txtPRnumberEnd.Size = new System.Drawing.Size(85, 23);
            this.txtPRnumberEnd.TabIndex = 1;
            this.txtPRnumberEnd.Text = "9999999999";
            this.txtPRnumberEnd.Click += new System.EventHandler(this.txtPRnumberEnd_Click);
            this.txtPRnumberEnd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPRnumberEnd_KeyDown);
            this.txtPRnumberEnd.Leave += new System.EventHandler(this.txtPRnumberEnd_Leave);
            // 
            // txtPRNumberStart
            // 
            this.txtPRNumberStart.Location = new System.Drawing.Point(163, 38);
            this.txtPRNumberStart.Margin = new System.Windows.Forms.Padding(4);
            this.txtPRNumberStart.MaxLength = 10;
            this.txtPRNumberStart.Name = "txtPRNumberStart";
            this.txtPRNumberStart.Size = new System.Drawing.Size(89, 23);
            this.txtPRNumberStart.TabIndex = 0;
            this.txtPRNumberStart.Text = "9999999999";
            this.txtPRNumberStart.Click += new System.EventHandler(this.txtPRNumberStart_Click);
            this.txtPRNumberStart.TextChanged += new System.EventHandler(this.txtPRNumberStart_TextChanged);
            this.txtPRNumberStart.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPRNumberStart_KeyDown);
            this.txtPRNumberStart.Leave += new System.EventHandler(this.txtPRNumberStart_Leave);
            // 
            // rbDate
            // 
            this.rbDate.AutoSize = true;
            this.rbDate.Location = new System.Drawing.Point(13, 149);
            this.rbDate.Margin = new System.Windows.Forms.Padding(4);
            this.rbDate.Name = "rbDate";
            this.rbDate.Size = new System.Drawing.Size(92, 20);
            this.rbDate.TabIndex = 6;
            this.rbDate.TabStop = true;
            this.rbDate.Text = "Date Range";
            this.rbDate.UseVisualStyleBackColor = true;
            this.rbDate.CheckedChanged += new System.EventHandler(this.rbDate_CheckedChanged);
            // 
            // rbPR
            // 
            this.rbPR.AutoSize = true;
            this.rbPR.Location = new System.Drawing.Point(405, 148);
            this.rbPR.Margin = new System.Windows.Forms.Padding(4);
            this.rbPR.Name = "rbPR";
            this.rbPR.Size = new System.Drawing.Size(90, 20);
            this.rbPR.TabIndex = 7;
            this.rbPR.TabStop = true;
            this.rbPR.Text = "PR Number";
            this.rbPR.UseVisualStyleBackColor = true;
            this.rbPR.CheckedChanged += new System.EventHandler(this.rbPR_CheckedChanged);
            // 
            // listViewSuppliers
            // 
            this.listViewSuppliers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewSuppliers.FullRowSelect = true;
            this.listViewSuppliers.GridLines = true;
            this.listViewSuppliers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewSuppliers.HideSelection = false;
            this.listViewSuppliers.Location = new System.Drawing.Point(176, 112);
            this.listViewSuppliers.Margin = new System.Windows.Forms.Padding(4);
            this.listViewSuppliers.MultiSelect = false;
            this.listViewSuppliers.Name = "listViewSuppliers";
            this.listViewSuppliers.Size = new System.Drawing.Size(582, 10);
            this.listViewSuppliers.TabIndex = 8;
            this.listViewSuppliers.UseCompatibleStateImageBehavior = false;
            this.listViewSuppliers.View = System.Windows.Forms.View.Details;
            this.listViewSuppliers.SelectedIndexChanged += new System.EventHandler(this.listViewSuppliers_SelectedIndexChanged);
            this.listViewSuppliers.DoubleClick += new System.EventHandler(this.listViewSuppliers_DoubleClick);
            this.listViewSuppliers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewSuppliers_KeyDown);
            this.listViewSuppliers.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listViewSuppliers_KeyPress);
            // 
            // BtnGenerate
            // 
            this.BtnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnGenerate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGenerate.Location = new System.Drawing.Point(618, 281);
            this.BtnGenerate.Margin = new System.Windows.Forms.Padding(4);
            this.BtnGenerate.Name = "BtnGenerate";
            this.BtnGenerate.Size = new System.Drawing.Size(141, 33);
            this.BtnGenerate.TabIndex = 9;
            this.BtnGenerate.Text = "&Generate";
            this.BtnGenerate.UseVisualStyleBackColor = true;
            this.BtnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // chkAlreadyPrinted
            // 
            this.chkAlreadyPrinted.AutoSize = true;
            this.chkAlreadyPrinted.Location = new System.Drawing.Point(16, 281);
            this.chkAlreadyPrinted.Name = "chkAlreadyPrinted";
            this.chkAlreadyPrinted.Size = new System.Drawing.Size(114, 20);
            this.chkAlreadyPrinted.TabIndex = 10;
            this.chkAlreadyPrinted.Text = "Already Printed";
            this.chkAlreadyPrinted.UseVisualStyleBackColor = true;
            // 
            // btnSupplier
            // 
            this.btnSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSupplier.Image = global::PurchasePrinting.Properties.Resources.bullet_arrow_down;
            this.btnSupplier.Location = new System.Drawing.Point(726, 85);
            this.btnSupplier.Margin = new System.Windows.Forms.Padding(4);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(33, 25);
            this.btnSupplier.TabIndex = 3;
            this.btnSupplier.UseVisualStyleBackColor = true;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            this.btnSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSupplier_KeyDown);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(10, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(158, 29);
            this.lblHeader.TabIndex = 11;
            this.lblHeader.Text = "Header Title";
            // 
            // FrmPRBatchPrinting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(775, 327);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.chkAlreadyPrinted);
            this.Controls.Add(this.listViewSuppliers);
            this.Controls.Add(this.BtnGenerate);
            this.Controls.Add(this.rbPR);
            this.Controls.Add(this.rbDate);
            this.Controls.Add(this.grpPRNumber);
            this.Controls.Add(this.grpDate);
            this.Controls.Add(this.btnSupplier);
            this.Controls.Add(this.txtSupplierName);
            this.Controls.Add(this.txtSupplierID);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmPRBatchPrinting";
            this.Text = "PR Multi-File Printing";
            this.Load += new System.EventHandler(this.FrmPRBatchPrinting_Load);
            this.Click += new System.EventHandler(this.FrmPRBatchPrinting_Click);
            this.grpDate.ResumeLayout(false);
            this.grpDate.PerformLayout();
            this.grpPRNumber.ResumeLayout(false);
            this.grpPRNumber.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSupplierID;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.GroupBox grpDate;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.GroupBox grpPRNumber;
        private System.Windows.Forms.TextBox txtPRNumberStart;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.TextBox txtPRnumberEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbDate;
        private System.Windows.Forms.RadioButton rbPR;
        private System.Windows.Forms.ListView listViewSuppliers;
        private System.Windows.Forms.Button BtnGenerate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.CheckBox chkAlreadyPrinted;
        private System.Windows.Forms.CheckBox chkIsLastModify;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblHeader;
    }
}