namespace PurchasePrinting
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.purchasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pRBatchPrintingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pOExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pOExportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.directoryFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSenderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.purchasesToolStripMenuItem,
            this.optionToolStripMenuItem,
            this.emailToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(865, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // purchasesToolStripMenuItem
            // 
            this.purchasesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pRBatchPrintingToolStripMenuItem,
            this.pOExportToolStripMenuItem,
            this.pOExportToolStripMenuItem1});
            this.purchasesToolStripMenuItem.Name = "purchasesToolStripMenuItem";
            this.purchasesToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.purchasesToolStripMenuItem.Text = "&Purchase";
            // 
            // pRBatchPrintingToolStripMenuItem
            // 
            this.pRBatchPrintingToolStripMenuItem.Name = "pRBatchPrintingToolStripMenuItem";
            this.pRBatchPrintingToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.pRBatchPrintingToolStripMenuItem.Text = "Purchase &Requisition (PR)";
            this.pRBatchPrintingToolStripMenuItem.Click += new System.EventHandler(this.pRBatchPrintingToolStripMenuItem_Click);
            // 
            // pOExportToolStripMenuItem
            // 
            this.pOExportToolStripMenuItem.Name = "pOExportToolStripMenuItem";
            this.pOExportToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.pOExportToolStripMenuItem.Text = "Purchase &Order (PO)";
            this.pOExportToolStripMenuItem.Click += new System.EventHandler(this.pOExportToolStripMenuItem_Click);
            // 
            // pOExportToolStripMenuItem1
            // 
            this.pOExportToolStripMenuItem1.Name = "pOExportToolStripMenuItem1";
            this.pOExportToolStripMenuItem1.Size = new System.Drawing.Size(209, 22);
            this.pOExportToolStripMenuItem1.Text = "PO Export";
            this.pOExportToolStripMenuItem1.Click += new System.EventHandler(this.pOExportToolStripMenuItem1_Click);
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionToolStripMenuItem,
            this.directoryFileToolStripMenuItem});
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.optionToolStripMenuItem.Text = "Option";
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.connectionToolStripMenuItem.Text = "Connection";
            this.connectionToolStripMenuItem.Click += new System.EventHandler(this.connectionToolStripMenuItem_Click);
            // 
            // directoryFileToolStripMenuItem
            // 
            this.directoryFileToolStripMenuItem.Name = "directoryFileToolStripMenuItem";
            this.directoryFileToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.directoryFileToolStripMenuItem.Text = "Directory File";
            this.directoryFileToolStripMenuItem.Click += new System.EventHandler(this.directoryFileToolStripMenuItem_Click);
            // 
            // emailToolStripMenuItem
            // 
            this.emailToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileSenderToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.emailSetupToolStripMenuItem,
            this.userListToolStripMenuItem});
            this.emailToolStripMenuItem.Name = "emailToolStripMenuItem";
            this.emailToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.emailToolStripMenuItem.Text = "Email";
            // 
            // fileSenderToolStripMenuItem
            // 
            this.fileSenderToolStripMenuItem.Name = "fileSenderToolStripMenuItem";
            this.fileSenderToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.fileSenderToolStripMenuItem.Text = "File Sender";
            this.fileSenderToolStripMenuItem.Click += new System.EventHandler(this.fileSenderToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.settingsToolStripMenuItem.Text = "Configuration";
            this.settingsToolStripMenuItem.Visible = false;
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // emailSetupToolStripMenuItem
            // 
            this.emailSetupToolStripMenuItem.Name = "emailSetupToolStripMenuItem";
            this.emailSetupToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.emailSetupToolStripMenuItem.Text = "Email Setup";
            this.emailSetupToolStripMenuItem.Click += new System.EventHandler(this.emailSetupToolStripMenuItem_Click);
            // 
            // userListToolStripMenuItem
            // 
            this.userListToolStripMenuItem.Name = "userListToolStripMenuItem";
            this.userListToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.userListToolStripMenuItem.Text = "User List";
            this.userListToolStripMenuItem.Click += new System.EventHandler(this.userListToolStripMenuItem_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 521);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PO - Southwood Mindanao Corporation";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem purchasesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pRBatchPrintingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pOExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem directoryFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pOExportToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem emailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileSenderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userListToolStripMenuItem;
    }
}

