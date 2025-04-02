namespace FileSending
{
    partial class FrmHistory
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
            this.lvFiles = new System.Windows.Forms.ListView();
            this.Email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PO = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PK = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DateSend1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dtDATE = new System.Windows.Forms.DateTimePicker();
            this.btnReSend = new System.Windows.Forms.Button();
            this.lblRecord = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date Process :";
            // 
            // lvFiles
            // 
            this.lvFiles.BackColor = System.Drawing.Color.Black;
            this.lvFiles.CheckBoxes = true;
            this.lvFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Email,
            this.PO,
            this.PK,
            this.DateSend1,
            this.columnHeader1});
            this.lvFiles.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvFiles.ForeColor = System.Drawing.Color.Lime;
            this.lvFiles.FullRowSelect = true;
            this.lvFiles.HideSelection = false;
            this.lvFiles.Location = new System.Drawing.Point(14, 50);
            this.lvFiles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lvFiles.Name = "lvFiles";
            this.lvFiles.Size = new System.Drawing.Size(694, 350);
            this.lvFiles.TabIndex = 17;
            this.lvFiles.UseCompatibleStateImageBehavior = false;
            this.lvFiles.View = System.Windows.Forms.View.Details;
            // 
            // Email
            // 
            this.Email.Text = "Email Address";
            this.Email.Width = 224;
            // 
            // PO
            // 
            this.PO.Text = "PO Number";
            this.PO.Width = 101;
            // 
            // PK
            // 
            this.PK.Text = "PK";
            this.PK.Width = 0;
            // 
            // DateSend1
            // 
            this.DateSend1.Text = "Date Process";
            this.DateSend1.Width = 222;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Username";
            this.columnHeader1.Width = 120;
            // 
            // dtDATE
            // 
            this.dtDATE.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDATE.Location = new System.Drawing.Point(111, 17);
            this.dtDATE.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtDATE.Name = "dtDATE";
            this.dtDATE.ShowCheckBox = true;
            this.dtDATE.Size = new System.Drawing.Size(158, 25);
            this.dtDATE.TabIndex = 18;
            this.dtDATE.ValueChanged += new System.EventHandler(this.dtDATE_ValueChanged);
            // 
            // btnReSend
            // 
            this.btnReSend.Location = new System.Drawing.Point(614, 407);
            this.btnReSend.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReSend.Name = "btnReSend";
            this.btnReSend.Size = new System.Drawing.Size(92, 28);
            this.btnReSend.TabIndex = 19;
            this.btnReSend.Text = "Re-send";
            this.btnReSend.UseVisualStyleBackColor = true;
            this.btnReSend.Click += new System.EventHandler(this.btnReSend_Click);
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.Location = new System.Drawing.Point(14, 412);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(68, 17);
            this.lblRecord.TabIndex = 20;
            this.lblRecord.Text = "Record : 0";
            // 
            // FrmHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 442);
            this.Controls.Add(this.lblRecord);
            this.Controls.Add(this.btnReSend);
            this.Controls.Add(this.dtDATE);
            this.Controls.Add(this.lvFiles);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmHistory";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "History";
            this.Load += new System.EventHandler(this.FrmHistory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvFiles;
        private System.Windows.Forms.ColumnHeader Email;
        private System.Windows.Forms.ColumnHeader PO;
        private System.Windows.Forms.DateTimePicker dtDATE;
        private System.Windows.Forms.Button btnReSend;
        private System.Windows.Forms.ColumnHeader PK;
        private System.Windows.Forms.ColumnHeader DateSend1;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}