using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Web.Services.Description;
using System.Windows.Forms;

namespace PurchasePrinting.Class
{
    internal class ClsQuery
    {   
        public static bool DataExist(string table, string column, string value)
        {
            bool result = false;
            DataTable dataTable = new DataTable();
            try
            {
                using (OdbcConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = $"SELECT TOP 1 {column} FROM {table} WHERE {column} = '{value}'";

                    using (OdbcCommand cmd = new OdbcCommand(query, conn))
                    {
                   
                        conn.Open();

                        using (OdbcDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows) // If there is at least one row
                            {
                                result = true;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            
                return false;
            }

            return result;
        }
        public static bool ExecuteQuery(string query)
        {

            try
            {
                using (OdbcConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (OdbcCommand cmd = new OdbcCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show("ExecuteQuery Error : " + ex.Message);
                return false;
            }


        }
        public static DataTable GetListQuery(string query)
        {

            DataTable dataTable = new DataTable();
            try
            {
                using (OdbcConnection conn = DatabaseHelper.GetConnection())
                {

                    OdbcDataAdapter adapter = new OdbcDataAdapter(query, conn);
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetListQuery Error : " + ex.Message);
                return null;

            }

            return dataTable;
        }

        public static string GetSingleValue(string query)
        {
            string result = "";

            using (OdbcConnection conn = DatabaseHelper.GetConnection())
            {
                using (OdbcCommand cmd = new OdbcCommand(query, conn))
                {
                    conn.Open();

                    object value = cmd.ExecuteScalar();
                    if (value != null && value != DBNull.Value)
                    {
                        result = value.ToString();
                    }
                }
            }
            return result;
        }
        public static Dictionary<string, object> GetFirstRecord(string query)
        {
            Dictionary<string, object> record = new Dictionary<string, object>();

            using (OdbcConnection conn = DatabaseHelper.GetConnection())
            {
                using (OdbcCommand cmd = new OdbcCommand(query, conn))
                {
                    conn.Open();
                    using (OdbcDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // Read the first record
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                record[reader.GetName(i)] = reader.GetValue(i);
                            }
                        }
                    }
                }
            }

            return record;
        }
    }
}
