using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FSS
{
    class SavingFiles
    {

        public static bool Save(TextBox txtFile, string Description = "Select a folder")
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = Description;
                saveFileDialog.Filter = "Folder Selection|*.folder"; // Fake filter
                saveFileDialog.FileName = "File"; // Dummy filename
               

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string folderPath = Path.GetDirectoryName(saveFileDialog.FileName);
                    txtFile.Text = folderPath;
                    return true;
                }
            }
            return false;
        }

    }
}
