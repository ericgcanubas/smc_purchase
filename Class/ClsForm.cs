using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PurchasePrinting
{
    internal class ClsForm
    {

        public static void OpenChild(System.Windows.Forms.Form form)
        {

            FrmMain frmMain = ClsControl.GetMdiParent();

            // Center the child form on the screen

            form.TopLevel = false; // Make it a child form
            form.Parent = frmMain; // Set the parent form
            form.StartPosition = FormStartPosition.CenterScreen; // Set position manually

            form.Location = new Point(
                   (frmMain.ClientSize.Width - form.Width) / 2,
                   (frmMain.ClientSize.Height - form.Height) / 2
              );


            form.BringToFront();
            form.Show();


        }
    }
}
