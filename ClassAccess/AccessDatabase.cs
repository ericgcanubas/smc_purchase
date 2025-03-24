using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace FSS
{
    class AccessDatabase
    {
        private static string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=data.accdb;Persist Security Info=False;Jet OLEDB:Database Password=admin123;";

        public static DataTable dataList(string query)
        {
            DataTable dataTable = new DataTable();
            try

            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error message");
            }

            return dataTable;
        }

        public bool AuthenticateUser(string username, string password)
        {
            bool isAuthenticated = false;
            string query = "SELECT COUNT(*) FROM Users WHERE Username = ? AND Password = ?";

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        int count = (int)command.ExecuteScalar();
                        isAuthenticated = count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            return isAuthenticated;
        }

        public static int ExecuteNonQuery(string query)
        {
            int rowsAffected = 0;

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    using (OleDbCommand command = new OleDbCommand(query, connection))
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
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    using (OleDbDataReader reader = command.ExecuteReader())
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
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    using (OleDbDataReader reader = command.ExecuteReader())
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
