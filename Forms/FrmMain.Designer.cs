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
            this.emailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSenderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailListToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.purchasesToolStripMenuItem,
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
            this.purchasesToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.purchasesToolStripMenuItem.Text = "&Print && Export";
            this.purchasesToolStripMenuItem.Visible = false;
            // 
            // pRBatchPrintingToolStripMenuItem
            // 
            this.pRBatchPrintingToolStripMenuItem.Name = "pRBatchPrintingToolStripMenuItem";
            this.pRBatchPrintingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pRBatchPrintingToolStripMenuItem.Text = "Print POV";
            this.pRBatchPrintingToolStripMenuItem.Click += new System.EventHandler(this.pRBatchPrintingToolStripMenuItem_Click);
            // 
            // pOExportToolStripMenuItem
            // 
            this.pOExportToolStripMenuItem.Name = "pOExportToolStripMenuItem";
            this.pOExportToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pOExportToolStripMenuItem.Text = "Print PO";
            this.pOExportToolStripMenuItem.Click += new System.EventHandler(this.pOExportToolStripMenuItem_Click);
            // 
            // pOExportToolStripMenuItem1
            // 
            this.pOExportToolStripMenuItem1.Name = "pOExportToolStripMenuItem1";
            this.pOExportToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.pOExportToolStripMenuItem1.Text = "Export PO";
            this.pOExportToolStripMenuItem1.Click += new System.EventHandler(this.pOExportToolStripMenuItem1_Click);
            // 
            // emailToolStripMenuItem
            // 
            this.emailToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileSenderToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.emailToolStripMenuItem.Name = "emailToolStripMenuItem";
            this.emailToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.emailToolStripMenuItem.Text = "&Email";
            this.emailToolStripMenuItem.Visible = false;
            // 
            // fileSenderToolStripMenuItem
            // 
            this.fileSenderToolStripMenuItem.Name = "fileSenderToolStripMenuItem";
            this.fileSenderToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.fileSenderToolStripMenuItem.Text = "Send a File";
            this.fileSenderToolStripMenuItem.Click += new System.EventHandler(this.fileSenderToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usersToolStripMenuItem,
            this.emailListToolStripMenuItem1});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.usersToolStripMenuItem.Text = "User List";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // emailListToolStripMenuItem1
            // 
            this.emailListToolStripMenuItem1.Name = "emailListToolStripMenuItem1";
            this.emailListToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.emailListToolStripMenuItem1.Text = "Email List";
            this.emailListToolStripMenuItem1.Click += new System.EventHandler(this.emailListToolStripMenuItem1_Click);
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
            this.Text = "Print & Export - PO files";
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
        private System.Windows.Forms.ToolStripMenuItem pOExportToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem emailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileSenderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailListToolStripMenuItem1;
    }
}

