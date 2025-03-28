namespace PurchasePrinting.Forms
{
    partial class FrmFirstSetup
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.chkPrint = new System.Windows.Forms.CheckBox();
            this.chkEmailSender = new System.Windows.Forms.CheckBox();
            this.grpPrint = new System.Windows.Forms.GroupBox();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.grpEmail = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtFileTransfer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpPrint.SuspendLayout();
            this.grpEmail.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Server name:";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(104, 28);
            this.txtServer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(188, 25);
            this.txtServer.TabIndex = 4;
            // 
            // chkPrint
            // 
            this.chkPrint.AutoSize = true;
            this.chkPrint.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPrint.Location = new System.Drawing.Point(18, 12);
            this.chkPrint.Name = "chkPrint";
            this.chkPrint.Size = new System.Drawing.Size(132, 20);
            this.chkPrint.TabIndex = 6;
            this.chkPrint.Text = "Print and Export";
            this.chkPrint.UseVisualStyleBackColor = true;
            this.chkPrint.CheckedChanged += new System.EventHandler(this.chkPrint_CheckedChanged);
            // 
            // chkEmailSender
            // 
            this.chkEmailSender.AutoSize = true;
            this.chkEmailSender.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEmailSender.Location = new System.Drawing.Point(20, 97);
            this.chkEmailSender.Name = "chkEmailSender";
            this.chkEmailSender.Size = new System.Drawing.Size(109, 20);
            this.chkEmailSender.TabIndex = 7;
            this.chkEmailSender.Text = "Email Sender";
            this.chkEmailSender.UseVisualStyleBackColor = true;
            this.chkEmailSender.CheckedChanged += new System.EventHandler(this.chkEmailSender_CheckedChanged);
            // 
            // grpPrint
            // 
            this.grpPrint.Controls.Add(this.btnTestConnection);
            this.grpPrint.Controls.Add(this.txtServer);
            this.grpPrint.Controls.Add(this.label1);
            this.grpPrint.Enabled = false;
            this.grpPrint.Location = new System.Drawing.Point(12, 15);
            this.grpPrint.Name = "grpPrint";
            this.grpPrint.Size = new System.Drawing.Size(488, 64);
            this.grpPrint.TabIndex = 8;
            this.grpPrint.TabStop = false;
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(295, 28);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(122, 24);
            this.btnTestConnection.TabIndex = 10;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // grpEmail
            // 
            this.grpEmail.Controls.Add(this.btnBrowse);
            this.grpEmail.Controls.Add(this.groupBox3);
            this.grpEmail.Controls.Add(this.txtFileTransfer);
            this.grpEmail.Controls.Add(this.label2);
            this.grpEmail.Enabled = false;
            this.grpEmail.Location = new System.Drawing.Point(13, 100);
            this.grpEmail.Name = "grpEmail";
            this.grpEmail.Size = new System.Drawing.Size(487, 187);
            this.grpEmail.TabIndex = 9;
            this.grpEmail.TabStop = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(405, 45);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(74, 24);
            this.btnBrowse.TabIndex = 9;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtPassword);
            this.groupBox3.Controls.Add(this.txtUsername);
            this.groupBox3.Location = new System.Drawing.Point(12, 80);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(300, 91);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Set a administrator account";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(9, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Password :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(9, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Username :";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(91, 54);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(188, 25);
            this.txtPassword.TabIndex = 6;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(91, 24);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(188, 25);
            this.txtUsername.TabIndex = 5;
            // 
            // txtFileTransfer
            // 
            this.txtFileTransfer.Location = new System.Drawing.Point(12, 45);
            this.txtFileTransfer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtFileTransfer.Name = "txtFileTransfer";
            this.txtFileTransfer.Size = new System.Drawing.Size(390, 25);
            this.txtFileTransfer.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(336, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Choose a destination folder for completed file transfers.";
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(322, 304);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(86, 26);
            this.btnDone.TabIndex = 10;
            this.btnDone.Text = "OK";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(414, 304);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 26);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmFirstSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 341);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.chkEmailSender);
            this.Controls.Add(this.grpEmail);
            this.Controls.Add(this.chkPrint);
            this.Controls.Add(this.grpPrint);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFirstSetup";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "First Time Setup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmFirstSetup_FormClosing);
            this.Load += new System.EventHandler(this.FrmFirstSetup_Load);
            this.grpPrint.ResumeLayout(false);
            this.grpPrint.PerformLayout();
            this.grpEmail.ResumeLayout(false);
            this.grpEmail.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.CheckBox chkPrint;
        private System.Windows.Forms.CheckBox chkEmailSender;
        private System.Windows.Forms.GroupBox grpPrint;
        private System.Windows.Forms.GroupBox grpEmail;
        private System.Windows.Forms.TextBox txtFileTransfer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnCancel;
    }
}