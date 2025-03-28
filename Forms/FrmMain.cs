using PurchasePrinting.Class;
using PurchasePrinting.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PurchasePrinting
{
    public partial class FrmMain : Form
    {
    
    
        public bool isLogin = false;
        public FrmMain()
        {
            InitializeComponent();
            ClsControl.SetMdiParent(this);
        }

        private void pRBatchPrintingToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if(isLogin == false)
            {

                tryToLogin();
                if(isLogin == false)
                {
                    return;
                }
            }

            FrmPRBatchPrinting frmPRBatchPrinting = new FrmPRBatchPrinting(true, false);
            ClsForm.OpenChild(frmPRBatchPrinting);


        }
 
        private void FrmMain_Load(object sender, EventArgs e)
        {

      
           ConfigFile.AutoCreateFile();
            try
            {
                MenuSetup();
            }
            catch (Exception)
            {

                Application.Exit();
            }
       


        }
        private void MenuSetup()
        {
           var Mode = ClsMode.getMode();

            if (  bool.Parse( Mode["printing"].ToString()) == true)
            {
                purchasesToolStripMenuItem.Visible = true;
            }

            if ( bool.Parse (Mode["emailsender"].ToString()) == true)
            {
                emailToolStripMenuItem.Visible = true;
            }

        }
        private void pOExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isLogin == false)
            {
                tryToLogin();
                if (isLogin == false)
                {
                    return;
                }
            }

            FrmPRBatchPrinting frmPRBatchPrinting = new FrmPRBatchPrinting(false, false);
            ClsForm.OpenChild(frmPRBatchPrinting);
        }

        private void connectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void directoryFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void pOExportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (isLogin == false)
            {

                tryToLogin();
                if (isLogin == false)
                {
                    return;
                }
            }

            FrmPRBatchPrinting frmPRBatchPrinting = new FrmPRBatchPrinting(false, true);
            ClsForm.OpenChild(frmPRBatchPrinting);


        }

        private void fileSenderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmailSenderToSupplier.FrmMain frm = new EmailSenderToSupplier.FrmMain();

            ClsForm.OpenChild(frm);
        }

        private void tryToLogin()
        {
            if (isLogin == false)
            {
                FrmLogin frm = new FrmLogin();
                frm.ShowDialog();
                isLogin = frm.isLogin;
                frm.Dispose();
            }

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void emailSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void userListToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void emailListToolStripMenuItem_Click(object sender, EventArgs e)
        {
    
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileSending.FormAccess.FrmUserList frm = new FileSending.FormAccess.FrmUserList();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void emailListToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FSS.FrmEmailSetup frm = new FSS.FrmEmailSetup();
            frm.ShowDialog();
            frm.Dispose();
        }
    }
}
