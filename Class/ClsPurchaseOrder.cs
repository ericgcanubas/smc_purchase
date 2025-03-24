using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PurchasePrinting.Class
{
    internal class ClsPurchaseOrder
    {
        public static DataTable getListByDate(string SupplierCode, DateTime dateFrom, DateTime dateTo, bool isPrinted, bool isLastModify)
        {
            string supSQL = "";
            if (SupplierCode.Trim() != "")
            {
                supSQL = " tbl_Suppliers.SupplierCode = '" + ClsControl.formatID(int.Parse(SupplierCode)) + "' and ";
            }

            DataTable dataTable = new DataTable();
            try
            {
                using (OdbcConnection conn = DatabaseHelper.GetConnection())
                {

                    string dateColumn = (isLastModify == false ?  " tbl_PONew.PODate " : " Format([tbl_PONew].LastModified,'yyyy-MM-dd') ");

                    string query = "SELECT " +
                        " [tbl_PONew].[PONo]" +
                        " ,Format([tbl_PONew].[PODate],'MM/dd/yyyy') as [PO Date]" +
                        " ,tbl_Suppliers.SupplierCode AS SuppCode" +
                        " ,tbl_Suppliers.SupplierName AS SuppName " +
                        " ,[tbl_PONew].[POType]" +
                        " ,Format([tbl_PONew].[PODelDate],'MM/dd/yyyy') as [Del Date] " +
                        " ,Format([tbl_PONew].[POCancelDate],'MM/dd/yyyy') as [Cancel Date]" +
                        " ,[tbl_PONew].[PO_Qty]" +
                        " ,[tbl_PONew].[PO_Gross]" +
                        " ,[tbl_PONew].[PO_Disc]" +
                        " ,[tbl_PONew].[PO_Net]" +
                        " ,tbl_POType.Description AS POTypeDesc," +
                        " tbl_POType.POType AS POTypeCode," +
                        " tbl_Locations.LocationCode AS DelCode," +
                        " tbl_Locations_Type.DelType AS DelTypeDesc, " +
                        " tbl_Suppliers.AlterTermsInRR, " +
                        " tbl_Suppliers.RRTerms as OldTerms, " +
                        " [tbl_PONew].[PRNo], " +
                        " Format([tbl_PONew].[PRDate],'MM/dd/yyyy') as [PR Date]" +
                        " ,Format([tbl_PONew].[LastModified],'MM/dd/yyyy') as [Last Modified]" +
                        " FROM [tbl_PONew] " +
                        " LEFT OUTER JOIN tbl_PO_Req on tbl_PO_Req.PK = [tbl_PONew].PRKey" +
                        " LEFT OUTER JOIN tbl_Locations_Type ON tbl_PO_Req.DelType = tbl_Locations_Type.PK " +
                        " LEFT OUTER JOIN tbl_Locations ON [tbl_PONew].DelPlace = tbl_Locations.LocationCode " +
                        " LEFT OUTER JOIN tbl_Suppliers ON [tbl_PONew].SupplierKey = tbl_Suppliers.PK " +
                        " LEFT OUTER JOIN tbl_SupplierType ON tbl_Suppliers.SupplierType = tbl_SupplierType.SPK " +
                        " LEFT OUTER JOIN tbl_POType ON [tbl_PONew].POType = tbl_POType.PK " +
                        " LEFT OUTER JOIN tbl_Departments ON [tbl_PONew].DeptKey = tbl_Departments.PK " + 
                        " WHERE " + supSQL + "  "+ dateColumn + " BETWEEN '" + dateFrom.ToString("yyyy-MM-dd") + "' and '" + dateTo.ToString("yyyy-MM-dd") + "'" +
                        "  and  tbl_PONew.PO_Printed = '" + (isPrinted == true ? 1 : 0) + "'";

                    OdbcDataAdapter adapter = new OdbcDataAdapter(query, conn);
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "error message");
                return null;
            }



            return dataTable;
        }

        public static DataTable getListByPONumber(string SupplierCode, string PRnumberStart, string PRnumberEnd, bool isPrinted)
        {
            string supSQL = "";
            if (SupplierCode.Trim() != "")
            {
                supSQL = " tbl_Suppliers.SupplierCode = '" + ClsControl.formatID(int.Parse(SupplierCode)) + "' and ";
            }

            DataTable dataTable = new DataTable();
            try
            {
                using (OdbcConnection conn = DatabaseHelper.GetConnection())
                {

                    string query = "SELECT " +
                        " [tbl_PONew].[PONo]" +
                        " ,Format([tbl_PONew].[PODate],'MM/dd/yyyy') as [PO Date]" +
                        " ,tbl_Suppliers.SupplierCode AS SuppCode" +
                        " ,tbl_Suppliers.SupplierName AS SuppName " +
                        " ,[tbl_PONew].[POType]" +
                        " ,Format([tbl_PONew].[PODelDate],'MM/dd/yyyy') as [Del Date] " +
                        " ,Format([tbl_PONew].[POCancelDate],'MM/dd/yyyy') as [Cancel Date]" +
                        " ,[tbl_PONew].[PO_Qty]" +
                        " ,[tbl_PONew].[PO_Gross]" +
                        " ,[tbl_PONew].[PO_Disc]" +
                        " ,[tbl_PONew].[PO_Net]" +
                        " ,tbl_POType.Description AS POTypeDesc," +
                        " tbl_POType.POType AS POTypeCode," +
                        " tbl_Locations.LocationCode AS DelCode," +
                        " tbl_Locations_Type.DelType AS DelTypeDesc, " +
                        " tbl_Suppliers.AlterTermsInRR, " +
                        " tbl_Suppliers.RRTerms as OldTerms, " +
                        " [tbl_PONew].[PRNo], " +
                        " Format([tbl_PONew].[PRDate],'MM/dd/yyyy') as [PR Date]" +
                        " ,Format([tbl_PONew].[LastModified],'MM/dd/yyyy') as [Last Modified]" +
                        " FROM [tbl_PONew] " +
                        " LEFT OUTER JOIN tbl_PO_Req on tbl_PO_Req.PK = [tbl_PONew].PRKey" +
                        " LEFT OUTER JOIN tbl_Locations_Type ON tbl_PO_Req.DelType = tbl_Locations_Type.PK " +
                        " LEFT OUTER JOIN tbl_Locations ON [tbl_PONew].DelPlace = tbl_Locations.LocationCode " +
                        " LEFT OUTER JOIN tbl_Suppliers ON [tbl_PONew].SupplierKey = tbl_Suppliers.PK " +
                        " LEFT OUTER JOIN tbl_SupplierType ON tbl_Suppliers.SupplierType = tbl_SupplierType.SPK " +
                        " LEFT OUTER JOIN tbl_POType ON [tbl_PONew].POType = tbl_POType.PK " +
                        " LEFT OUTER JOIN tbl_Departments ON [tbl_PONew].DeptKey = tbl_Departments.PK " +
                        " WHERE " + supSQL + "  [tbl_PONew].[PONo] BETWEEN '" + PRnumberStart + "' and '" + PRnumberEnd + "'" +
                        "  and  tbl_PONew.PO_Printed = '" + (isPrinted == true ? 1 : 0) + "'";

                    OdbcDataAdapter adapter = new OdbcDataAdapter(query, conn);
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "error message");
                return null;
            }



            return dataTable;
        }

        public static DataTable getListByDateExport(string SupplierCode, DateTime dateFrom, DateTime dateTo, bool isPrinted, bool isLastModify)
        {
            string supSQL = "";
            if (SupplierCode.Trim() != "")
            {
                supSQL = " tbl_Suppliers.SupplierCode = '" + ClsControl.formatID(int.Parse(SupplierCode)) + "' and ";
            }

            DataTable dataTable = new DataTable();
            try
            {
                using (OdbcConnection conn = DatabaseHelper.GetConnection())
                {

                    string dateColumn = (isLastModify == false ? " tbl_PONew.PODate " : " Format([tbl_PONew].LastModified,'yyyy-MM-dd') ");

                    string query = "SELECT " +
                        " [tbl_PONew].[PONo]" +
                        " ,Format([tbl_PONew].[PODate],'MM/dd/yyyy') as [PO Date]" +
                        " ,tbl_Suppliers.SupplierCode AS SuppCode" +
                        " ,tbl_Suppliers.SupplierName AS SuppName " +
                        " ,tbl_Suppliers.eMailAddress AS Email" +
                        " ,[tbl_PONew].[POType]" +
                        " ,Format([tbl_PONew].[PODelDate],'MM/dd/yyyy') as [Del Date] " +
                        " ,Format([tbl_PONew].[POCancelDate],'MM/dd/yyyy') as [Cancel Date]" +
                        " ,[tbl_PONew].[PO_Qty]" +
                        " ,[tbl_PONew].[PO_Gross]" +
                        " ,[tbl_PONew].[PO_Disc]" +
                        " ,[tbl_PONew].[PO_Net]" +
                        " ,tbl_POType.Description AS POTypeDesc," +
                        " tbl_POType.POType AS POTypeCode," +
                        " tbl_Locations.LocationCode AS DelCode," +
                        " tbl_Locations_Type.DelType AS DelTypeDesc, " +
                        " tbl_Suppliers.AlterTermsInRR, " +
                        " tbl_Suppliers.RRTerms as OldTerms, " +
                        " [tbl_PONew].[PRNo], " +
                        " Format([tbl_PONew].[PRDate],'MM/dd/yyyy') as [PR Date]" +
                        " ,Format([tbl_PONew].[LastModified],'MM/dd/yyyy') as [Last Modified]" +
                        " FROM [tbl_PONew] " +
                        " LEFT OUTER JOIN tbl_PO_Req on tbl_PO_Req.PK = [tbl_PONew].PRKey" +
                        " LEFT OUTER JOIN tbl_Locations_Type ON tbl_PO_Req.DelType = tbl_Locations_Type.PK " +
                        " LEFT OUTER JOIN tbl_Locations ON [tbl_PONew].DelPlace = tbl_Locations.LocationCode " +
                        " LEFT OUTER JOIN tbl_Suppliers ON [tbl_PONew].SupplierKey = tbl_Suppliers.PK " +
                        " LEFT OUTER JOIN tbl_SupplierType ON tbl_Suppliers.SupplierType = tbl_SupplierType.SPK " +
                        " LEFT OUTER JOIN tbl_POType ON [tbl_PONew].POType = tbl_POType.PK " +
                        " LEFT OUTER JOIN tbl_Departments ON [tbl_PONew].DeptKey = tbl_Departments.PK " +
                        " WHERE " + supSQL + "  " + dateColumn + " BETWEEN '" + dateFrom.ToString("yyyy-MM-dd") + "' and '" + dateTo.ToString("yyyy-MM-dd") + "'" +
                        "  and  tbl_PONew.PO_Printed=1 and tbl_PONew.PO_Posted=1  and tbl_PONew.PO_Exported = '" + (isPrinted == true ? 1 : 0) + "'";

                    OdbcDataAdapter adapter = new OdbcDataAdapter(query, conn);
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "error message");
                return null;
            }



            return dataTable;
        }

        public static DataTable getListByPONumberExport(string SupplierCode, string PRnumberStart, string PRnumberEnd, bool isPrinted)
        {
            string supSQL = "";
            if (SupplierCode.Trim() != "")
            {
                supSQL = " tbl_Suppliers.SupplierCode = '" + ClsControl.formatID(int.Parse(SupplierCode)) + "' and ";
            }

            DataTable dataTable = new DataTable();
            try
            {
                using (OdbcConnection conn = DatabaseHelper.GetConnection())
                {

                    string query = "SELECT " +
                        " [tbl_PONew].[PONo]" +
                        " ,Format([tbl_PONew].[PODate],'MM/dd/yyyy') as [PO Date]" +
                        " ,tbl_Suppliers.SupplierCode AS SuppCode" +
                        " ,tbl_Suppliers.SupplierName AS SuppName " +
                        " ,tbl_Suppliers.eMailAddress AS Email" +
                        " ,[tbl_PONew].[POType]" +
                        " ,Format([tbl_PONew].[PODelDate],'MM/dd/yyyy') as [Del Date] " +
                        " ,Format([tbl_PONew].[POCancelDate],'MM/dd/yyyy') as [Cancel Date]" +
                        " ,[tbl_PONew].[PO_Qty]" +
                        " ,[tbl_PONew].[PO_Gross]" +
                        " ,[tbl_PONew].[PO_Disc]" +
                        " ,[tbl_PONew].[PO_Net]" +
                        " ,tbl_POType.Description AS POTypeDesc," +
                        " tbl_POType.POType AS POTypeCode," +
                        " tbl_Locations.LocationCode AS DelCode," +
                        " tbl_Locations_Type.DelType AS DelTypeDesc, " +
                        " tbl_Suppliers.AlterTermsInRR, " +
                        " tbl_Suppliers.RRTerms as OldTerms, " +
                        " [tbl_PONew].[PRNo], " +
                        " Format([tbl_PONew].[PRDate],'MM/dd/yyyy') as [PR Date]" +
                        " ,Format([tbl_PONew].[LastModified],'MM/dd/yyyy') as [Last Modified]" +
                        " FROM [tbl_PONew] " +
                        " LEFT OUTER JOIN tbl_PO_Req on tbl_PO_Req.PK = [tbl_PONew].PRKey" +
                        " LEFT OUTER JOIN tbl_Locations_Type ON tbl_PO_Req.DelType = tbl_Locations_Type.PK " +
                        " LEFT OUTER JOIN tbl_Locations ON [tbl_PONew].DelPlace = tbl_Locations.LocationCode " +
                        " LEFT OUTER JOIN tbl_Suppliers ON [tbl_PONew].SupplierKey = tbl_Suppliers.PK " +
                        " LEFT OUTER JOIN tbl_SupplierType ON tbl_Suppliers.SupplierType = tbl_SupplierType.SPK " +
                        " LEFT OUTER JOIN tbl_POType ON [tbl_PONew].POType = tbl_POType.PK " +
                        " LEFT OUTER JOIN tbl_Departments ON [tbl_PONew].DeptKey = tbl_Departments.PK " +
                        " WHERE " + supSQL + "  [tbl_PONew].[PONo] BETWEEN '" + PRnumberStart + "' and '" + PRnumberEnd + "'" +
                        "  and tbl_PONew.PO_Printed=1 and tbl_PONew.PO_Posted=1  and tbl_PONew.PO_Exported =  '" + (isPrinted == true ? 1 : 0) + "'";

                    OdbcDataAdapter adapter = new OdbcDataAdapter(query, conn);
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "error message");
                return null;
            }

            return dataTable;
        }


        public static void PO_UPDATE_ALLByIn(string userAction, string poList)
        {
            string strQuery = $"UPDATE tbl_PONew " +
                $" SET PO_Printed = 1," +
                $" User_Action ='" + userAction + "'" +
                " FROM tbl_PONew " +
                " LEFT OUTER JOIN  tbl_Suppliers ON tbl_PONew.SupplierKey = tbl_Suppliers.PK " +
                " WHERE tbl_PONew.PONo in (" + poList + ")" +
                " and PO_Printed = 0 ";


            if (ClsQuery.ExecuteQuery(strQuery))
            {
                // nothing   if success
            }

        }
        public static void cmbPOTypeSetup(System.Windows.Forms.ComboBox comboBox)
        {

            comboBox.Items.Add("A");
            comboBox.Items.Add("E");
            // Optionally, set the default selected value
            comboBox.SelectedIndex = 0;
        }

        public static void PO_UPDATE_Exported( string PO)
        {

            string strQuery = $"UPDATE tbl_PONew " +
                $" SET PO_Exported = 1" +
                "  FROM tbl_PONew " +
                "  WHERE tbl_PONew.PONo = '" + PO + "'";

            if (ClsQuery.ExecuteQuery(strQuery))
            {
                // nothing   if success
            }

        }

    }
}
