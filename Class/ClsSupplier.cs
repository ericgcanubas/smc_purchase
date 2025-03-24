using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Windows.Forms;

namespace PurchasePrinting
{
    internal class ClsSupplier
    {
        public static string getSupCode(string supplerCode)
        {
            if (supplerCode.Trim().ToString() == "")
            {
                return "%";
            }
            return ClsControl.formatSubID(int.Parse(supplerCode));
        }
        public static DataTable GetTopSuppliers(string search = "")
        {



            DataTable dataTable = new DataTable();

            try
            {
                using (OdbcConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = " SELECT TOP 100 vw_Suppliers.SupplierName," +
                        " vw_Suppliers.SupplierCode," +
                        " vw_SupplierType.SSupplierTypeCode," +
                        " vw_SupplierType.SSupplierType " +
                        " FROM vw_Suppliers  LEFT OUTER JOIN  vw_SupplierType ON vw_Suppliers.SupplierType = vw_SupplierType.SPK " +
                        " WHERE (vw_Suppliers.SupplierName + ' - ' + vw_Suppliers.SupplierCode > '" + search + "')" +
                        " OR (vw_Suppliers.SupplierName + ' - ' + vw_Suppliers.SupplierCode = '" + search + "') " +
                        " ORDER BY SupplierName ";

                    OdbcDataAdapter adapter = new OdbcDataAdapter(query, conn);
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception)
            {
                return null;   
              
            }

          

            return dataTable;
        }
        public static string GetSupplierInfo(string code)
        {
            string Result = "";
            DataTable dataTable = new DataTable();
            try
            {
                using (OdbcConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = " SELECT tbl_Suppliers.PK, " +
                                   " tbl_Suppliers.SupplierCode, " +
                                   " tbl_Suppliers.SupplierName, " +
                                   " tbl_Suppliers.SupplierType, " +
                                   " tbl_SupplierType.SSupplierTypeCode , " +
                                   " tbl_SupplierType.SSupplierType,  " +
                                   " tbl_Suppliers.PreTag AS PreTag, " +
                                   " tbl_Suppliers.Remarks, " +
                                   " tbl_Suppliers.Terms, " +
                                   " tbl_Suppliers.AlterTermsInRR, " +
                                   " tbl_Suppliers.CanUsedExisting, " +
                                   " tbl_Suppliers.SStatus, " +
                                   " tbl_Suppliers.PurchaseOrderAlert, " +
                                   " tbl_Suppliers.CurrentlyEdit " +
                                   " FROM tbl_Suppliers LEFT OUTER JOIN " +
                                   " tbl_SupplierType ON tbl_Suppliers.SupplierType = tbl_SupplierType.SPK " +
                                   " WHERE (tbl_Suppliers.SupplierCode = '" + code + "')";

                    OdbcDataAdapter adapter = new OdbcDataAdapter(query, conn);
                    adapter.Fill(dataTable);
                }

                foreach (DataRow row in dataTable.Rows)
                {
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        if (Result == "")
                        {
                            Result = row[i].ToString();
                        }
                        else
                        {
                            Result = Result + "|" + row[i].ToString();
                        }
                    }

                }
            }
            catch (Exception)
            {
                return "";
            }
          
            return Result;

        }


        public static string GetSupplierAddAgent(string PK)
        {
            string Result = "";
            DataTable dataTable = new DataTable();
            try
            {
                using (OdbcConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = "SELECT tbl_Suppliers.Address1, " +
                        "tbl_Suppliers.Address2, " +
                        "tbl_Suppliers.Address3,  " +
                        "tbl_Suppliers.Agent, " +
                        "tbl_Suppliers.RIGHT(SupplierCode,5) as SupplierCode, " +
                        "tbl_Suppliers.SupplierName, " +
                        "tbl_Suppliers.Phone " +
                        "From tbl_Suppliers " +
                        "Where (PK = "+ PK +")";

                    OdbcDataAdapter adapter = new OdbcDataAdapter(query, conn);
                    adapter.Fill(dataTable);
                }

                foreach (DataRow row in dataTable.Rows)
                {
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        if (Result == "")
                        {
                            Result = row[i].ToString();
                        }
                        else
                        {
                            Result = Result + "|" + row[i].ToString();
                        }
                    }

                }
            }
            catch (Exception)
            {
                return "";
            }

            return Result;

        }


    }
}
