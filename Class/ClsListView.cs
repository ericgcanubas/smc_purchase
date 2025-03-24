using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PurchasePrinting
{
    internal class ClsListView
    {

        private static void AutoResizeColumns(ListView listView)
        {
            foreach (ColumnHeader column in listView.Columns)
            {
                column.Width = -2; // Auto-size to fit content
            }
        }
        public static void LoadListView(ListView listView, DataTable dataTable)
        {

            if (dataTable != null)
            {
                listView.Items.Clear();
                listView.Columns.Clear();


                foreach (DataColumn column in dataTable.Columns)
                {
                    listView.Columns.Add(column.ColumnName);
                }

                foreach (DataRow row in dataTable.Rows)
                {
                    ListViewItem item = new ListViewItem(row[0].ToString()); // First column as main item
                    for (int i = 1; i < dataTable.Columns.Count; i++)
                    {
                        item.SubItems.Add(row[i].ToString()); // Remaining columns as subitems
                    }
                    listView.Items.Add(item);
                }
            }
            AutoResizeColumns(listView);
        }
        public static void SetAllChecked(ListView listView, bool check)
        {
            foreach (ListViewItem item in listView.Items)
            {
                item.Checked = check;
            }
        }
        public static void LoadListCheckBoxView(ListView listView, DataTable dataTable)
        {
            if (dataTable != null)
            {
                listView.Items.Clear();
                listView.Columns.Clear();
                listView.CheckBoxes = true; // Enable checkboxes

                listView.Columns.Add(" ", 30); // Checkbox column

                foreach (DataColumn column in dataTable.Columns)
                {
                    listView.Columns.Add(column.ColumnName);
                }

                foreach (DataRow row in dataTable.Rows)
                {
                    ListViewItem item = new ListViewItem();
                    item.Checked = true; // Default unchecked
                    item.SubItems.Add(row[0].ToString()); // First column as main item

                    for (int i = 1; i < dataTable.Columns.Count; i++)
                    {
                        item.SubItems.Add(row[i].ToString()); // Remaining columns as subitems
                    }
                    listView.Items.Add(item);
                }
            }
            AutoResizeColumns(listView);
        }
        public static string[] GetCheckedItems(ListView listView, int columnIndex)
        {
            List<string> checkedItems = new List<string>();

            foreach (ListViewItem item in listView.Items)
            {
                if (item.Checked) // Check if the item is selected
                {
                    checkedItems.Add(item.SubItems[columnIndex].Text); // Assuming the first column after the checkbox is the key
                }
            }

            return checkedItems.ToArray(); // Convert List<string> to string[]
        }

        public static void listViewLayoutDefault(ListView listView)
        {

            listView.View = View.Details;
            listView.GridLines = true;
            listView.FullRowSelect = true;
        }

        public static void listViewLayoutDark(ListView listView)
        {
            listView.View = View.Details;
            listView.GridLines = false;
            listView.BackColor = Color.Black;
            listView.ForeColor = Color.Lime;
            listView.FullRowSelect = true;
        }
    }
}

