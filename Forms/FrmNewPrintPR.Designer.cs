namespace PurchasePrinting.Forms
{
    partial class FrmNewPrintPR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNewPrintPR));
            this.CmbPrinterName = new System.Windows.Forms.ComboBox();
            this.BtnPrint = new System.Windows.Forms.Button();
            this.lblWait = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CmbPrinterName
            // 
            this.CmbPrinterName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPrinterName.FormattingEnabled = true;
            this.CmbPrinterName.Location = new System.Drawing.Point(9, 28);
            this.CmbPrinterName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.CmbPrinterName.Name = "CmbPrinterName";
            this.CmbPrinterName.Size = new System.Drawing.Size(306, 24);
            this.CmbPrinterName.TabIndex = 2;
            this.CmbPrinterName.SelectedIndexChanged += new System.EventHandler(this.CmbPrinterName_SelectedIndexChanged);
            // 
            // BtnPrint
            // 
            this.BtnPrint.Location = new System.Drawing.Point(237, 57);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(78, 27);
            this.BtnPrint.TabIndex = 4;
            this.BtnPrint.Text = "&Print";
            this.BtnPrint.UseVisualStyleBackColor = true;
            this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // lblWait
            // 
            this.lblWait.AutoSize = true;
            this.lblWait.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWait.ForeColor = System.Drawing.Color.Red;
            this.lblWait.Location = new System.Drawing.Point(9, 62);
            this.lblWait.Name = "lblWait";
            this.lblWait.Size = new System.Drawing.Size(225, 16);
            this.lblWait.TabIndex = 5;
            this.lblWait.Text = "Please wait printing in progress...";
            this.lblWait.Visible = false;
            // 
            // FrmNewPrintPR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 102);
            this.Controls.Add(this.lblWait);
            this.Controls.Add(this.BtnPrint);
            this.Controls.Add(this.CmbPrinterName);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNewPrintPR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Printer";
            this.Load += new System.EventHandler(this.FrmNewPrintPR_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox CmbPrinterName;
        private System.Windows.Forms.Button BtnPrint;
        private System.Windows.Forms.Label lblWait;
    }
}