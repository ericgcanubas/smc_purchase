namespace PurchasePrinting.Forms
{
    partial class FrmPrintPO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrintPO));
            this.btnPrintCry = new System.Windows.Forms.Button();
            this.CmbPrinterName = new System.Windows.Forms.ComboBox();
            this.lblWait = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPrintCry
            // 
            this.btnPrintCry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintCry.Location = new System.Drawing.Point(239, 43);
            this.btnPrintCry.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnPrintCry.Name = "btnPrintCry";
            this.btnPrintCry.Size = new System.Drawing.Size(81, 25);
            this.btnPrintCry.TabIndex = 7;
            this.btnPrintCry.Text = "&Print";
            this.btnPrintCry.UseVisualStyleBackColor = true;
            this.btnPrintCry.Click += new System.EventHandler(this.btnPrintCry_Click);
            // 
            // CmbPrinterName
            // 
            this.CmbPrinterName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPrinterName.FormattingEnabled = true;
            this.CmbPrinterName.Location = new System.Drawing.Point(14, 13);
            this.CmbPrinterName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.CmbPrinterName.Name = "CmbPrinterName";
            this.CmbPrinterName.Size = new System.Drawing.Size(306, 24);
            this.CmbPrinterName.TabIndex = 5;
            // 
            // lblWait
            // 
            this.lblWait.AutoSize = true;
            this.lblWait.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWait.ForeColor = System.Drawing.Color.Red;
            this.lblWait.Location = new System.Drawing.Point(12, 47);
            this.lblWait.Name = "lblWait";
            this.lblWait.Size = new System.Drawing.Size(225, 16);
            this.lblWait.TabIndex = 8;
            this.lblWait.Text = "Please wait printing in progress...";
            this.lblWait.Visible = false;
            // 
            // FrmPrintPO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 78);
            this.Controls.Add(this.lblWait);
            this.Controls.Add(this.btnPrintCry);
            this.Controls.Add(this.CmbPrinterName);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPrintPO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Print PO";
            this.Load += new System.EventHandler(this.FrmPrintPO_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrintCry;
        private System.Windows.Forms.ComboBox CmbPrinterName;
        private System.Windows.Forms.Label lblWait;
    }
}