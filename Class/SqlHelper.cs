using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PurchasePrinting.Class
{
    class SqlHelper
    {

        public static DataTable dataList(string query)
        {
            DataTable dataTable = new DataTable();
            try

            {
                using (OdbcConnection connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    using (OdbcCommand command = new OdbcCommand(query, connection))
                    {
                        using (OdbcDataAdapter adapter = new OdbcDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error message");
                Application.Exit();
            }

            return dataTable;
        }

     

        public static int ExecuteNonQuery(string query)
        {
            int rowsAffected = 0;

            try
            {
                using (OdbcConnection connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    using (OdbcCommand command = new OdbcCommand(query, connection))
                    {
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            return rowsAffected;
        }

        public static Dictionary<string, object> GetFirstRecord(string query)
        {
            Dictionary<string, object> result = null;

            try
            {
                using (OdbcConnection connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    using (OdbcCommand command = new OdbcCommand(query, connection))
                    using (OdbcDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // Read only the first record
                        {
                            result = new Dictionary<string, object>();
                            for (int i = 0; i < reader.FieldCount; i++) // Loop through all columns
                            {
                                result[reader.GetName(i)] = reader.GetValue(i); // Store column name & value
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error message");
            }

            return result;
        }
        public static bool RecordExists(string query)
        {
            try
            {
                using (OdbcConnection connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    using (OdbcCommand command = new OdbcCommand(query, connection))
                    using (OdbcDataReader reader = command.ExecuteReader())
                    {
                        return reader.Read(); // Returns true if a record exists, false otherwise
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return false; // Return false in case of an error
            }
        }
    }
}
