﻿namespace PurchasePrinting.Forms
{
    partial class FrmPRDateReportViewer
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
            this.cryRptView = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cryRptView
            // 
            this.cryRptView.ActiveViewIndex = -1;
            this.cryRptView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cryRptView.Cursor = System.Windows.Forms.Cursors.Default;
            this.cryRptView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cryRptView.EnableDrillDown = false;
            this.cryRptView.Location = new System.Drawing.Point(0, 0);
            this.cryRptView.Name = "cryRptView";
            this.cryRptView.ShowGotoPageButton = false;
            this.cryRptView.ShowGroupTreeButton = false;
            this.cryRptView.ShowLogo = false;
            this.cryRptView.Size = new System.Drawing.Size(1225, 687);
            this.cryRptView.TabIndex = 0;
            this.cryRptView.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FrmPRDateReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 687);
            this.Controls.Add(this.cryRptView);
            this.Name = "FrmPRDateReportViewer";
            this.Text = "PR List Report Viewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmReportViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cryRptView;
    }
}