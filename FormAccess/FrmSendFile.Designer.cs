namespace FSS
{
    partial class FrmSendFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSendFile));
            this.cmbEmail = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.lblPleaseWait = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbEmail
            // 
            this.cmbEmail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmail.FormattingEnabled = true;
            this.cmbEmail.Location = new System.Drawing.Point(9, 37);
            this.cmbEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbEmail.Name = "cmbEmail";
            this.cmbEmail.Size = new System.Drawing.Size(373, 24);
            this.cmbEmail.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Email Use :";
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(9, 91);
            this.txtSubject.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(373, 23);
            this.txtSubject.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Subject :";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(9, 145);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(373, 80);
            this.txtMessage.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Message :";
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendEmail.Location = new System.Drawing.Point(286, 234);
            this.btnSendEmail.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(96, 26);
            this.btnSendEmail.TabIndex = 7;
            this.btnSendEmail.Text = "Send";
            this.btnSendEmail.UseVisualStyleBackColor = true;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // lblPleaseWait
            // 
            this.lblPleaseWait.AutoSize = true;
            this.lblPleaseWait.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPleaseWait.ForeColor = System.Drawing.Color.Red;
            this.lblPleaseWait.Location = new System.Drawing.Point(10, 238);
            this.lblPleaseWait.Name = "lblPleaseWait";
            this.lblPleaseWait.Size = new System.Drawing.Size(213, 14);
            this.lblPleaseWait.TabIndex = 16;
            this.lblPleaseWait.Text = "Please wait sending in-progress ..";
            this.lblPleaseWait.Visible = false;
            // 
            // FrmSendFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 271);
            this.Controls.Add(this.lblPleaseWait);
            this.Controls.Add(this.cmbEmail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.btnSendEmail);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMessage);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSendFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Send File";
            this.Load += new System.EventHandler(this.FrmSendFile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSendEmail;
        private System.Windows.Forms.Label lblPleaseWait;
    }
}