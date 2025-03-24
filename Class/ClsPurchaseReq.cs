using PurchasePrinting.Class;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PurchasePrinting
{
    internal class ClsPurchaseReq
    {
        public static DataTable getInfo(string PRNumber)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (OdbcConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = "SELECT TOP 1 " +
                    "tbl_PO_Req.PK," +
                    "tbl_PO_Req.PRNo," +
                    "tbl_PO_Req.RRTerms," +
                    "tbl_PO_Req.PODelDate," +
                    "tbl_PO_Req.Ref," +
                    "tbl_PO_Req.PO_Qty," +
                    "tbl_PO_Req.PO_Net," +
                    "tbl_PO_Req.REMARKS," +
                    "tbl_PO_Req.POType," +
                    "tbl_PO_Req.POCancelDate," +
                    "FORMAT(tbl_PO_Req.PRDate,'MM/dd/yyyy') as PRDate," +
                    "tbl_Suppliers.SupplierCode AS SuppCode," +
                    "tbl_Suppliers.SupplierName AS SuppName, " +
                    "tbl_PO_Req.Terms," +
                    "tbl_PO_Req.LogInUser," +
                    "tbl_PO_Req.Discount," +
                    "tbl_PO_Req.POrder," +
                    "tbl_PO_Req.DetailHeader," +
                    "tbl_SupplierType.SSupplierType AS SuppType," +
                    "tbl_Departments.DepartmentCode AS DeptCode, " +
                    "tbl_Departments.DepartmentName AS DeptName," +
                    "tbl_Locations.Description AS Location, " +
                    "tbl_POType.Description AS POTypeDesc, " +
                    "tbl_POType.POType AS POTypeCode," +
                    "tbl_Locations.LocationCode AS DelCode," +
                    "tbl_Locations_Type.DelType AS DelTypeDesc, " +
                    "tbl_Suppliers.AlterTermsInRR, " +
                    "tbl_Suppliers.RRTerms as OldTerms, " +
                    "tbl_Suppliers.Address1, " +
                    "tbl_Suppliers.Address2, " +
                    "tbl_Suppliers.Address3,  " +
                    "tbl_Suppliers.Agent, " +
                    "RIGHT(tbl_Suppliers.SupplierCode,5) as SupplierCode, " +
                    "tbl_Suppliers.Phone " +
                    "FROM tbl_PO_Req " +
                    "LEFT OUTER JOIN  tbl_Locations_Type ON tbl_PO_Req.DelType = tbl_Locations_Type.PK " +
                    "LEFT OUTER JOIN  tbl_Locations ON tbl_PO_Req.DelPlace = tbl_Locations.LocationCode " +
                    "LEFT OUTER JOIN  tbl_Suppliers ON tbl_PO_Req.SupplierKey = tbl_Suppliers.PK " +
                    "LEFT OUTER JOIN  tbl_SupplierType ON tbl_Suppliers.SupplierType = tbl_SupplierType.SPK " +
                    "LEFT OUTER JOIN  tbl_POType ON tbl_PO_Req.POType = tbl_POType.PK " +
                    "LEFT OUTER JOIN  tbl_Departments ON tbl_PO_Req.DeptKey = tbl_Departments.PK " +
                    "WHERE (tbl_PO_Req.PRNo = '" + PRNumber + "')  " +
                    "ORDER BY tbl_PO_Req.PRNo";

                    OdbcDataAdapter adapter = new OdbcDataAdapter(query, conn);
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;

            }
            return dataTable;
        }
        public static DataTable getBrandList(int PK)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (OdbcConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = "SELECT tbl_Classes.ClassCode, " +
                        " tbl_Brand.BrandName," +
                        " tbl_Brand.BrandCode," +
                        " tbl_Items.BrandKey " +
                        " FROM tbl_Items " +
                        " LEFT OUTER JOIN tbl_Brand ON tbl_Items.BrandKey = tbl_Brand.PK  " +
                        " LEFT OUTER JOIN tbl_Classes ON tbl_Items.ClassKey = tbl_Classes.PK " +
                        " WHERE (tbl_Items.PK = '" + PK + "')";

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
        public static DataTable getItemList(int PK)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (OdbcConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = "SELECT tbl_PO_ReqDet.Line," +
                        " tbl_Items.ItemCode," +
                        " tbl_Items.StockNumber," +
                        " tbl_Items.ItemDescription," +
                        " ISNULL(tbl_Items.UnitOfMeasure,'') as UnitOfMeasure," +
                        " tbl_PO_ReqDet.BegInv ," +
                        " tbl_PO_ReqDet.EndInv," +
                        " tbl_PO_ReqDet.S_Ord," +
                        " tbl_PO_ReqDet.Cost," +
                        " tbl_Items.GrossSRP,tbl_PO_ReqDet.Date_Recd, " +
                        " tbl_PO_ReqDet.Discount," +
                        " tbl_PO_ReqDet.NetCost," +
                        " tbl_PO_ReqDet.DetailedHeader," +
                        " tbl_PO_ReqDet.BegQtyB4LstRcvd," +
                        " tbl_Items.PK, " +
                        " tbl_PO_ReqDet.LastRcvdQty," +
                        " tbl_PO_ReqDet.TotAvlQty," +
                        " tbl_PO_ReqDet.EndingQty," +
                        " tbl_PO_ReqDet.EndingQtyDateIfZero," +
                        " tbl_PO_ReqDet.DetailedHeader" +
                        " FROM tbl_PO_ReqDet " +
                        " LEFT OUTER JOIN  tbl_Items ON tbl_PO_ReqDet.ItemKey = tbl_Items.PK" +
                        " Where (tbl_PO_ReqDet.PO_ReqKey = " + PK + ") " +
                        " ORDER BY tbl_PO_ReqDet.Line";

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
        public static DataTable getListByPRnumber(string SupplierCode, string PRnumberStart, string PRnumberEnd, bool isPrinted)
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
                    string query = "SELECT tbl_PO_Req.PRNo," +
                "FORMAT(tbl_PO_Req.PRDate,'MM/dd/yyyy') as PRDate," +
                "tbl_Suppliers.SupplierCode AS SuppCode," +
                "tbl_Suppliers.SupplierName AS SuppName, " +
                "tbl_PO_Req.Terms," +
                "tbl_PO_Req.LogInUser," +
                "tbl_PO_Req.Discount," +
                "tbl_PO_Req.PO_Qty as Qty," +
                "FORMAT(tbl_PO_Req.PO_Gross,'N2') as Gross," +
                "FORMAT(tbl_PO_Req.PO_Disc,'N2') as [Disc Amt.]," +
                "FORMAT(tbl_PO_Req.PO_Net,'N2') as Net," +
                "tbl_SupplierType.SSupplierType AS SuppType," +
                "tbl_Departments.DepartmentCode AS DeptCode, " +
                "tbl_Departments.DepartmentName AS DeptName," +
                "tbl_Locations.Description AS Location, " +
                "tbl_POType.Description AS POTypeDesc," +
                "tbl_POType.POType AS POTypeCode," +
                "tbl_Locations.LocationCode AS DelCode," +
                "tbl_Locations_Type.DelType AS DelTypeDesc, " +
                "tbl_Suppliers.AlterTermsInRR, " +
                "tbl_Suppliers.RRTerms as OldTerms " +
                "FROM tbl_PO_Req " +
                "LEFT OUTER JOIN  tbl_Locations_Type ON tbl_PO_Req.DelType = tbl_Locations_Type.PK " +
                "LEFT OUTER JOIN  tbl_Locations ON tbl_PO_Req.DelPlace = tbl_Locations.LocationCode " +
                "LEFT OUTER JOIN  tbl_Suppliers ON tbl_PO_Req.SupplierKey = tbl_Suppliers.PK " +
                "LEFT OUTER JOIN  tbl_SupplierType ON tbl_Suppliers.SupplierType = tbl_SupplierType.SPK " +
                "LEFT OUTER JOIN  tbl_POType ON tbl_PO_Req.POType = tbl_POType.PK " +
                "LEFT OUTER JOIN  tbl_Departments ON tbl_PO_Req.DeptKey = tbl_Departments.PK " +
                "WHERE " + supSQL + " tbl_PO_Req.PRNo BETWEEN '" + PRnumberStart + "' and '" + PRnumberEnd + "' and PR_Printed = " + (isPrinted == true ? 1 : 0) + " " +

                "ORDER BY tbl_PO_Req.PRNo";

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
        public static DataTable getListByDate(string SupplierCode, DateTime dateFrom, DateTime dateTo, bool isPrinted , bool isLastModify)
        {
            string supSQL = "";
            if (SupplierCode.Trim() != "")
            {
                supSQL = " tbl_Suppliers.SupplierCode = '" + ClsControl.formatID(int.Parse(SupplierCode)) + "' and ";
            }


            string dateColumn = (isLastModify == false ? " tbl_PO_Req.PRDate " : " Format([tbl_PO_Req].LastModified,'yyyy-MM-dd') ");
     

            DataTable dataTable = new DataTable();
            try
            {
                using (OdbcConnection conn = DatabaseHelper.GetConnection())
                {

                

                    string query = "SELECT tbl_PO_Req.PRNo," +
                "FORMAT(tbl_PO_Req.PRDate,'MM/dd/yyyy') as PRDate," +
                "tbl_Suppliers.SupplierCode AS SuppCode," +
                "tbl_Suppliers.SupplierName AS SuppName, " +
                "tbl_PO_Req.Terms," +
                "tbl_PO_Req.LogInUser," +
                "tbl_PO_Req.Discount," +
                "tbl_PO_Req.PO_Qty as Qty," +
                "FORMAT(tbl_PO_Req.PO_Gross,'N2') as Gross," +
                "FORMAT(tbl_PO_Req.PO_Disc,'N2') as [Disc Amt.]," +
                "FORMAT(tbl_PO_Req.PO_Net,'N2') as Net," +
                "tbl_SupplierType.SSupplierType AS SuppType," +
                "tbl_Departments.DepartmentCode AS DeptCode, " +
                "tbl_Departments.DepartmentName AS DeptName," +
                "tbl_Locations.Description AS Location, " +
                "tbl_POType.Description AS POTypeDesc," +
                "tbl_POType.POType AS POTypeCode," +
                "tbl_Locations.LocationCode AS DelCode," +
                "tbl_Locations_Type.DelType AS DelTypeDesc, " +
                "tbl_Suppliers.AlterTermsInRR, " +
                "tbl_Suppliers.RRTerms as OldTerms, " +
                "FORMAT(tbl_PO_Req.LastModified,'MM/dd/yyyy') as [Last-Modified]" +
                "FROM tbl_PO_Req " +
                "LEFT OUTER JOIN  tbl_Locations_Type ON tbl_PO_Req.DelType = tbl_Locations_Type.PK " +
                "LEFT OUTER JOIN  tbl_Locations ON tbl_PO_Req.DelPlace = tbl_Locations.LocationCode " +
                "LEFT OUTER JOIN  tbl_Suppliers ON tbl_PO_Req.SupplierKey = tbl_Suppliers.PK " +
                "LEFT OUTER JOIN  tbl_SupplierType ON tbl_Suppliers.SupplierType = tbl_SupplierType.SPK " +
                "LEFT OUTER JOIN  tbl_POType ON tbl_PO_Req.POType = tbl_POType.PK " +
                "LEFT OUTER JOIN  tbl_Departments ON tbl_PO_Req.DeptKey = tbl_Departments.PK " +
                "WHERE " + supSQL + " tbl_PO_Req.PRDate BETWEEN '" + dateFrom.ToString("yyyy-MM-dd") + "'" +
                " and '" + dateTo.ToString("yyyy-MM-dd") + "' and PR_Printed = " + (isPrinted == true ? 1 : 0) + " " +

                "ORDER BY tbl_PO_Req.PRNo";

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
        public static DataTable getPODetdet(int PK)
        {

            DataTable dataTable = new DataTable();
            try
            {
                using (OdbcConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = "SELECT tbl_PO_ReqDet_Det.*  FROM tbl_PO_ReqDet_Det  Where (PO_ReqKey = " + PK + ")";
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
        public static DataTable getPODetdetLine(int PK, int line)
        {

            DataTable dataTable = new DataTable();
            try
            {
                using (OdbcConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = "SELECT tbl_PO_ReqDet_Det.*  FROM tbl_PO_ReqDet_Det  Where (PO_ReqKey = " + PK + ") and (PO_Det_Line = " + line + ")";
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
        public static void PrintPR(PrintPageEventArgs e, string key)
        {
//            DataTable dtInfo = getInfo(key);
//            int cnt = 0;
//            foreach (DataRow row in dtInfo.Rows)
//            {
//                int PK = int.Parse(row["PK"].ToString());
//                string POTypeCode = row["POTypeCode"].ToString();
//                string PRNo = row["PRNo"].ToString();
//                string SuppCode = row["SuppCode"].ToString();
//                string suppname = row["suppname"].ToString();
//                string SuppType = row["SuppType"].ToString();

//                string PRDate = row["PRDate"].ToString();
//                string POrder = row["POrder"].ToString();
//                string locSuppAdd1 = row["Address1"].ToString();
//                string locSuppAdd2 = row["Address2"].ToString();
//                string locSuppAdd3 = row["Phone"].ToString();
//                string Location = row["Location"].ToString();
//                string RRTerms = row["RRTerms"].ToString();
//                string TERMS = row["TERMS"].ToString();
//                string PODelDate = row["PODelDate"].ToString();
//                string POCancelDate = row["POCancelDate"].ToString();
//                string Ref = row["Ref"].ToString();
//                string POType = row["POType"].ToString();
//                string AlterTermsInRR = row["AlterTermsInRR"].ToString();

//                string DeptCode = row["DeptCode"].ToString();
//                string DeptName = row["DeptName"].ToString();
//                string DetailHeader = row["DetailHeader"].ToString();

//                string strTotalQty = decimal.Parse(row["PO_Qty"].ToString()).ToString("0");
//                string strTotalCost = decimal.Parse(row["PO_Net"].ToString()).ToString("##,##0.00");


//                //Courier New
//                // 
//                // Font definitions
//                Font regularFont7 = new Font("Lucida Console", 8);
//                Font regularFontb = new Font("Courier New", 8);
//                Font regularFont8 = new Font("Courier New", 8);
//                Font boldFont = new Font("Courier New", 12, FontStyle.Bold);
//                Font boldFontBottom = new Font("OCR A Extended", 12, FontStyle.Regular);

//                string topHeader = "";
//                // Coordinates for printing
//                float x = 10; // Starting X position
//                float y = 10; // Starting Y position

//                string strResult = "";

//                if (AlterTermsInRR == "1")
//                {
//                    string str = new string(' ', 91 - (DeptCode + "  " + DeptName).Length) + new string(' ', 5) + "P.O. FILE TERMS   : " + (string.IsNullOrEmpty(TERMS) ? "" : TERMS);
//                    strResult = "DEPARTMENT  : " + DeptCode + "  " + DeptName + str;
//                }
//                else
//                {
//                    strResult = "DEPARTMENT  : " +
//                     DeptCode + "  " + DeptName + "\n";

//                }

//                int SafeSpaces(int totalLength) => Math.Max(0, totalLength);
//                int ssLine = 70;

//                string boldLine = "\n\n                                                           " + "No. : (" + POTypeCode.Trim() + ") " + PRNo;
//                e.Graphics.DrawString(boldLine, boldFont, Brushes.Black, new PointF(x, y));
//                y += regularFont7.GetHeight(e.Graphics) * 3; // Move Y position down for the next line

//                topHeader = "\n\nSUPPLIER    : " +
//                   (double.TryParse(SuppCode, out var suppCodeParsed) ? suppCodeParsed.ToString("0000#") : "0000") + "  " + suppname +

//                   new string(' ', SafeSpaces(ssLine - ((double.TryParse(SuppCode, out _) ? suppCodeParsed.ToString("0000#") : "0000") + "  " + suppname).Length)) +
//                   new string(' ', SafeSpaces(5)) + "REQUISITION DATE  : " +
//                   (DateTime.TryParse(PRDate, out var prDateParsed) ? prDateParsed.ToString("MM/dd/yyyy") : "Invalid Date") + "\n" +

//                   " " +
//                   new string(' ', SafeSpaces(13)) + locSuppAdd1 +
//                   new string(' ', SafeSpaces(ssLine - locSuppAdd1.Length)) +
//                   new string(' ', SafeSpaces(8)) +
//                   (POrder == "1" ? "(X) NEW" : "( ) NEW") + new string(' ', SafeSpaces(2)) +
//                   (POrder == "2" ? "(X) REORDER" : "( ) REORDER") + "\n" +

//                    " " +
//                   new string(' ', SafeSpaces(13)) + locSuppAdd2 +
//                   new string(' ', SafeSpaces(ssLine - locSuppAdd2.Length)) + new string(' ', SafeSpaces(5)) +
//                   "REFERENCE #       : " + Ref + "\n" +

//                    " " +
//                   new string(' ', SafeSpaces(13)) + locSuppAdd3 +
//                   new string(' ', SafeSpaces(ssLine - locSuppAdd3.Length)) + new string(' ', SafeSpaces(5)) +
//                   "DELIVERY PLACE    : " + Location + "\n" +

//                   "TYPE        : " +
//                   SuppType +
//                   new string(' ', SafeSpaces(ssLine - SuppType.Length)) + new string(' ', SafeSpaces(5)) +
//                   "DELIVERY DATE     : " +
//                   (DateTime.TryParse(PODelDate, out var poDelDateParsed) ? poDelDateParsed.ToString("MM/dd/yyyy") : "Invalid Date") + "\n" +

//                   "TERMS       : " +
//                   RRTerms +
//                   new string(' ', SafeSpaces(ssLine - RRTerms.Length)) + new string(' ', SafeSpaces(5)) +
//                   "CANCELLATION DATE : " +
//                   (DateTime.TryParse(POCancelDate, out var poCancelDateParsed) ? poCancelDateParsed.ToString("MM/dd/yyyy") : "Invalid Date") + "\n" +

//                   strResult + "";

//                e.Graphics.DrawString(topHeader, regularFont8, Brushes.Black, new PointF(x, y));
//                y += regularFont8.GetHeight(e.Graphics) * 6;




//                string headerItem = "" +
//$"{new string('=', 200)}\n" +
//"            " + new string(' ', 1) + "                              " + new string(' ', 1) + "               " + new string(' ', 1) + "    " + new string(' ', 1) + "    Last" + new string(' ', 1) + "Last Rcd" + new string(' ', 1) + " Tot Avl" + new string(' ', 1) + "  Ending" + "         " + new string(' ', 1) + "         " + new string(' ', 1) + "    " + new string(' ', 1) + "          " + "           \n" +
//"Itemcode    " + new string(' ', 1) + "Description                   " + new string(' ', 1) + "Stock #        " + new string(' ', 1) + "Unit" + new string(' ', 1) + "    Rcvd" + new string(' ', 1) + "     Qty" + new string(' ', 1) + "     Qty" + new string(' ', 1) + "     Qty" + " S. Order" + new string(' ', 1) + "     Cost" + new string(' ', 1) + "Disc" + new string(' ', 1) + "   NetCost" + "        SRP\n" +
//$"{new string('-', 200)}\n";

//                string topDetDet = "";
//                string strHeaderTemp = "";
//                if (DetailHeader != "[ASSORTED]" && DetailHeader != "")
//                {
//                    topDetDet = PO_DETDET_TOP(PK, DetailHeader);
//                    cnt++;
//                }


//                string strPO_DET = PO_DET(PK, ref cnt, PRDate, DetailHeader, ref strHeaderTemp);
//                cnt++;
//                cnt++;


//                string sWrittenData = $"\n" +
//                  new string(' ', 60) +
//                  "<----- Nothing Follows ----->" +
//                  Environment.NewLine;

//                string footer = $"\n";
//                for (int j = 1; j <= (6 - cnt); j++)
//                {
//                    footer += $"" + Environment.NewLine;
//                }

//                string remarks = row["REMARKS"].ToString().Length > 50 ? row["REMARKS"].ToString().Substring(0, 50) : row["REMARKS"].ToString();
//                string formattedRemarks = FORMATINYI(remarks);
//                string totalQtyPadded = new string(' ', 12 - strTotalQty.Length) + strTotalQty;
//                string totalCostPadded = new string(' ', 15 - strTotalCost.Length) + strTotalCost;

//                string footerDetails =
//                    $" " +
//                    "REMARKS : " + formattedRemarks +
//                    new string(' ', 68 - remarks.Length) +
//                    "Total Qty : " +
//                    $"" + totalQtyPadded + $"" +
//                    new string(' ', 3) +
//                    "Total Cost : " +
//                    $"" + totalCostPadded + $"" +
//                    Environment.NewLine;


//                footer += $"{new string('-', 200)}\n";
//                footer += footerDetails;
//                footer += $"{new string('=', 200)}\n\n\n";
//                footer +=
//                            $"\n\n " +
//                            "ENCODED BY : ____________  " +
//                            "CHECKED BY : ____________  " +
//                            "CONFIRMED BY : ____________  " +
//                            "APPROVED BY : ____________  " +
//                            "POSTED BY : ____________" +
//                            Environment.NewLine;

//                footer +=
//                               $" " +
//                               "             POV Clerk     " +
//                               "             Mdsg. Clerk   " +
//                               "               Buyer         " +
//                               "              Mdsg. Asst.   " +
//                               "            POV Clerk   " +
//                               Environment.NewLine;

//                for (int v = 1; v <= 2; v++)
//                {
//                    footer += $"\n";
//                }

//                string bottom = "";

//                if (POType == "2")
//                {
//                    bottom +=
//                        $"" +
//                        $"" +
//                        $"" +
//                        new string(' ', 40) +
//                        "PURCHASE ORDER VERIFICATION (DISCREPANCY)" +
//                        $"" +
//                        $"" +
//                        $"" +
//                        Environment.NewLine;


//                }
//                else
//                {
//                    bottom +=
//                         $"" +
//                        $"" +
//                        $"" +
//                        new string(' ', 52) +
//                        "PURCHASE ORDER VERIFICATION" +
//                        $"" +
//                        $"" +
//                        $"" +
//                        Environment.NewLine;


//                }


//                // Move down for the next section
//                string itemDetails = headerItem + topDetDet + strPO_DET + sWrittenData;

//                y += regularFont7.GetHeight(e.Graphics) * 3;
//                e.Graphics.DrawString(itemDetails, regularFont7, Brushes.Black, new PointF(x, y));

//                y += regularFontb.GetHeight(e.Graphics) * 60;
//                e.Graphics.DrawString(footer, regularFontb, Brushes.Black, new PointF(x, y));

//                y += boldFontBottom.GetHeight(e.Graphics) * 8;
//                e.Graphics.DrawString(bottom, boldFontBottom, Brushes.Black, new PointF(x, y));

//            }



        }

        private static string PO_DET(int PK, ref int cnt, string PRDate, string DetailHeader, ref string strHeaderTemp)
        {

            string gbl_Date_New_PR_Start = "2010-03-04";
            string strDetails = "";

            DataTable dataTable = getItemList(PK);

            foreach (DataRow row in dataTable.Rows)
            {

                cnt++;

                if (DateTime.Parse(PRDate) >= DateTime.Parse(gbl_Date_New_PR_Start.ToString()))
                {


                    string strEndQty = "";
                    if (Convert.ToDouble(row["EndingQty"].ToString()) == 0)
                    {
                        var endingQtyDate = row["EndingQtyDateIfZero"] == DBNull.Value ? "01/01/1900" : row["EndingQtyDateIfZero"].ToString();
                        strEndQty = DateTime.Parse(endingQtyDate) == DateTime.Parse("01/01/1900") ? "" : DateTime.Parse(endingQtyDate).ToString("MM/dd/yy");
                    }
                    else
                    {
                        strEndQty = Convert.ToDouble(row["EndingQty"]).ToString("#,##0");
                    }

                    string ITEM_PK = row["PK"].ToString();
                    string itemCode = row["ItemCode"].ToString();
                    string ItemDescription = row["ItemDescription"].ToString();
                    string StockNumber = row["StockNumber"].ToString();
                    string UnitOfMeasure = row["UnitOfMeasure"].ToString();
                    string Date_Recd = row["Date_Recd"].ToString();
                    string LastRcvdQty = row["LastRcvdQty"].ToString();
                    string TotAvlQty = row["TotAvlQty"].ToString();
                    string S_Ord = row["S_Ord"].ToString();
                    string Cost = row["Cost"].ToString();
                    string DISCOUNT = row["Discount"].ToString();
                    string NetCost = row["NetCost"].ToString();
                    string GrossSRP = row["GrossSRP"].ToString();
                    string DetailedHeader = row["DetailedHeader"].ToString();
                    int Line = int.Parse(row["line"].ToString());

                    strDetails += "" + itemCode.PadRight(12).Substring(0, 12) +
                       new string(' ', 1) + ItemDescription.Substring(0, Math.Min(30, ItemDescription.Length)).PadRight(30, ' ') +
                       new string(' ', 1) + (StockNumber == "" ? "" : StockNumber).PadRight(15).Substring(0, 15) +
                       new string(' ', 1) + UnitOfMeasure.PadRight(4).Substring(0, 4) +
                       new string(' ', 1) + (DateTime.Parse(Date_Recd == "" ? "01/01/1900" : Date_Recd) == DateTime.Parse("01/01/1900") ? "        " : DateTime.Parse(Date_Recd).ToString("MM/dd/yy")) +
                       new string(' ', 1) +
                       new string(' ', 8 - (Convert.ToDouble(LastRcvdQty) == 0 ? "0" : Convert.ToDouble(LastRcvdQty).ToString("##,##0")).Length) +
                       (Convert.ToDouble(LastRcvdQty) == 0 ? "0" : Convert.ToDouble(LastRcvdQty).ToString("##,##0")) +
                       new string(' ', 1) +
                       new string(' ', 8 - (Convert.ToDouble(TotAvlQty) == 0 ? "0" : Convert.ToDouble(TotAvlQty).ToString("##,##0")).Length) +
                       (Convert.ToDouble(TotAvlQty) == 0 ? "0" : Convert.ToDouble(TotAvlQty).ToString("##,##0")) +
                       new string(' ', 1) +
                       new string(' ', 8 - strEndQty.Length) + strEndQty +
                       new string(' ', 1) +
                       new string(' ', 8 - (Convert.ToDouble(S_Ord) == 0 ? "" : S_Ord).Length) +
                       (Convert.ToDouble(S_Ord) == 0 ? "" : S_Ord) +
                       new string(' ', 1) +
                       new string(' ', 10 - Convert.ToDouble(Cost).ToString("##,##0.000").Length) +
                       Convert.ToDouble(Cost).ToString("##,##0.0000").Substring(0, Convert.ToDouble(Cost).ToString("##,##0.000").Length - 1) +
                       new string(' ', 1) +
                       DISCOUNT.PadRight(5).Substring(0, 5) +
                       new string(' ', 1) +
                       new string(' ', 10 - Convert.ToDouble(NetCost).ToString("##,##0.000").Length) +
                       Convert.ToDouble(NetCost).ToString("##,##0.000").Substring(0, Convert.ToDouble(NetCost).ToString("##,##0.000").Length - 1) +
                       new string(' ', 1) +
                       new string(' ', 10 - Convert.ToDouble(GrossSRP).ToString("##,##0.00").Length) +
                       Convert.ToDouble(GrossSRP).ToString("##,##0.00") + "\n" + PO_DET_DET(ITEM_PK, PK, Line, ref cnt, strHeaderTemp, DetailHeader, DetailedHeader);



                }
                else
                {
                    // Implement the else block similarly
                }



            }
            return strDetails;
        }
        private static string OtherRegular(string DetailHeader, ref string strHeaderTemp, string DetailedHeader)
        {
            if (DetailHeader == "[ASSORTED]")
            {
                if (DetailHeader != "REGULAR")
                {
                    if (strHeaderTemp != DetailHeader)
                    {
                        strHeaderTemp = DetailHeader;
                        //cnt++;

                        string[] Array1 = (DetailedHeader == "" ? "" : DetailedHeader).Split(new string[] { " | " }, StringSplitOptions.None);

                        string strDetail = "";
                        for (int j = 0; j < Array1.Length; j++)
                        {
                            string currentValue = Array1[j].Length > (j == 0 ? 15 : 7)
                                                  ? Array1[j].Substring(0, (j == 0 ? 15 : 7))
                                                  : Array1[j];

                            strDetail += new string(' ', (j == 0 ? 15 : 7) - currentValue.Length) + currentValue;
                        }

                        string sWrittenData =
                            $"" +
                            new string(' ', 45) +
                            $"" +
                            FORMATINYI(strDetail) +
                            $"" +
                            Environment.NewLine;

                        return sWrittenData;
                    }
                }
                else
                {
                    strHeaderTemp = DetailedHeader;

                }
            }

            return "";

        }
        private static string Brand(string PK)
        {

            DataTable dataTable = getBrandList(int.Parse(PK));

            foreach (DataRow row in dataTable.Rows)
            {


                string sWrittenData =
                            new string(' ', 1) +
                            new string(' ', 12) +
                            new string(' ', 5) +
                            FORMATINYI(row["ClassCode"].ToString()) +
                            new string(' ', 3) +
                            FORMATINYI(Convert.ToDouble(row["BrandKey"]) == 0 ? "" : row["BrandName"].ToString()) +
                            Environment.NewLine;

                return sWrittenData;
            }
            return "";
        }
        private static string PO_DETDET_TOP(int PK, string DetailHeader)
        {


            DataTable dataTable = getPODetdet(PK);

            foreach (DataRow row in dataTable.Rows)
            {
                string[] Array1 = (DetailHeader == "" ? "" : DetailHeader).Split(new string[] { " | " }, StringSplitOptions.None);

                string strDetail = "";
                for (int j = 0; j < Array1.Length; j++)
                {
                    string currentValue = Array1[j].Length > (j == 0 ? 15 : 7) ? Array1[j].Substring(0, (j == 0 ? 15 : 7)) : Array1[j];
                    strDetail += new string(' ', (j == 0 ? 15 : 7) - currentValue.Length) + currentValue;
                }

                string sWrittenData =
                    $"" +
                    new string(' ', 53) +
                    $"" +
                    FORMATINYI(strDetail) +
                    $"" +
                    $"\n{new string(' ', 63) + new string('_', strDetail.Length)}\n\n";

           
                return sWrittenData;

            }


            return "";

        }
        private static string PO_DET_DET(string ITEM_PK, int PK, int line, ref int cnt, string strHeaderTemp, string DetailHeader, string DetailedHeader)
        {

            string strDetails = Brand(ITEM_PK) + OtherRegular(DetailHeader, ref strHeaderTemp, DetailedHeader);
            cnt++;
            int LongDesc = 0;
            DataTable dataTable = getPODetdetLine(PK, line);

            foreach (DataRow row in dataTable.Rows)
            {
                cnt++;
                string[] Array1 = row["DetailedInfo"].ToString().Split('|');
                string strDetail = "";

                for (int j = 0; j < Array1.Length; j++)
                {
                    string currentValue = Array1[j].Length > (j == 0 ? (LongDesc == 1 ? 30 : 15) : 7)
                                          ? Array1[j].Substring(0, (j == 0 ? (LongDesc == 1 ? 30 : 15) : 7))
                                          : Array1[j];

                    strDetail += new string(' ', (j == 0 ? (LongDesc == 1 ? 30 : 15) : 7) - currentValue.Length) + currentValue;
                }

                string sWrittenData =
                    $"" +
                    new string(' ', (LongDesc == 1 ? 50 : 53)) +
                    FORMATINYI(strDetail) +
                    Environment.NewLine;

                strDetails += sWrittenData;

            }



            return strDetails;

        }
        public static string FORMATINYI(string strFieldVal)
        {
            return strFieldVal.Replace((char)209, (char)165);
        }
        public static void PR_UPDATE(string prNumber, string userAction)
        {

            string UserAccount = "PRINT_ADMIN";

            string strQuery = $"UPDATE tbl_PO_Req " +
                $" SET PR_Printed = 1," +
                $" User_Action ='" + userAction + "'," +
                $" LogInUser='" + UserAccount + "' " +
                $" WHERE (PRNO = '" + prNumber + "')";


            if (ClsQuery.ExecuteQuery(strQuery))
            {
                // nothing   if success
            }

        }
        public static void PR_UPDATE_ALLByIn(string userAction, string prList)
        {


     

            string strQuery = $"UPDATE tbl_PO_Req " +
                $" SET PR_Printed = 1," +
                $" User_Action ='" + userAction + "'" +
                " FROM tbl_PO_Req " +
                " LEFT OUTER JOIN  tbl_Suppliers ON tbl_PO_Req.SupplierKey = tbl_Suppliers.PK " +
                " WHERE tbl_PO_Req.PRNo in (" + prList + ")" +
                " and PR_Printed = 0 ";


            if (ClsQuery.ExecuteQuery(strQuery))
            {
                // nothing   if success
            }

        }

  
    }




}
