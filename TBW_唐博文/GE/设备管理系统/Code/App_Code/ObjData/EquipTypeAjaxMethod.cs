using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;
using System.Collections;
namespace Ajax
{
    /// <summary>
    /// Summary description for AjaxClass.
    /// </summary>
    public class EquipTypeAjaxMethod : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        string sSQL = "";
        ClsDataBase clsSQLCommond = new ClsDataBase();
        string tablename = "EquipType";

        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.Read)]
        public bool Insert(string iID, string S1, string S2, string S3, string S4, string S5, string S6, string S7, string S8, string S9, string S10, string S11, string S12, string S13, string S14, string S15,
         string Date1, string Date2, string Date3, string Date4, string Date5,
         string D1, string D2, string D3, string D4, string D5, string D6, string D7, string D8, string D9, string D10)
        {
            string uid = Session["uID"].ToString();
            ArrayList arr = new ArrayList();
            Sql sql = new Sql();
            if (iID == "" || iID == null)
            {
                sSQL = "select isnull(max(iID),0)+1 from  " + tablename + "";
                iID = clsSQLCommond.ExecString(sSQL);
                sql.Get(tablename, "iID", iID, true);
                sql.ToString("dCreatesysTime", DateTime.Now);
                sql.ToString("dCreatesysPerson", uid);
            }
            else
            {
                sql.Get(tablename, "iID", iID, false);
                sql.ToString("dChangeVerifyTime", DateTime.Now);
                sql.ToString("dChangeVerifyPerson", uid);
            }
            sql.ToString("S1", S1);
            sql.ToString("S2", S2);
            sql.ToString("S3", S3);
            sql.ToString("S4", S4);
            sql.ToString("S5", S5);
            sql.ToString("S6", S6);
            sql.ToString("S7", S7);
            sql.ToString("S8", S8);
            sql.ToString("S9", S9);
            sql.ToString("S10", S10);
            sql.ToString("S11", S11);
            sql.ToString("S12", S12);
            sql.ToString("S13", S13);
            sql.ToString("S14", S14);
            sql.ToString("S15", S15);
            if (Date1 != "")
            {
                sql.ToString("Date1", DateTime.Parse(Date1));
            }
            else
            {
                sql.ToString("Date1", Date1);
            }
            if (Date2 != "")
            {
                sql.ToString("Date2", DateTime.Parse(Date2));
            }
            else
            {
                sql.ToString("Date2", Date2);
            }
            if (Date3 != "")
            {
                sql.ToString("Date3", DateTime.Parse(Date3));
            }
            else
            {
                sql.ToString("Date3", Date3);
            }
            if (Date4 != "")
            {
                sql.ToString("Date4", DateTime.Parse(Date4));
            }
            else
            {
                sql.ToString("Date4", Date4);
            }
            if (Date5 != "")
            {
                sql.ToString("Date5", DateTime.Parse(Date5));
            }
            else
            {
                sql.ToString("Date5", Date5);
            }
            if (D1 != "")
            {
                sql.ToString("D1", decimal.Parse(D1));
            }
            else
            {
                sql.ToString("D1", null);
            }
            if (D2 != "")
            {
                sql.ToString("D2", decimal.Parse(D2));
            }
            else
            {
                sql.ToString("D2", null);
            }
            if (D3 != "")
            {
                sql.ToString("D3", decimal.Parse(D3));
            }
            else
            {
                sql.ToString("D3", null);
            } if (D4 != "")
            {
                sql.ToString("D4", decimal.Parse(D4));
            }
            else
            {
                sql.ToString("D4", null);
            }
            if (D5 != "")
            {
                sql.ToString("D5", decimal.Parse(D5));
            }
            else
            {
                sql.ToString("D5", null);
            }
            if (D6 != "")
            {
                sql.ToString("D6", decimal.Parse(D6));
            }
            else
            {
                sql.ToString("D6", null);
            }
            if (D7 != "")
            {
                sql.ToString("D7", decimal.Parse(D7));
            }
            else
            {
                sql.ToString("D7", null);
            }
            if (D8 != "")
            {
                sql.ToString("D8", decimal.Parse(D8));
            }
            else
            {
                sql.ToString("D8", null);
            }
            if (D9 != "")
            {
                sql.ToString("D9", decimal.Parse(D9));
            }
            else
            {
                sql.ToString("D9", null);
            }
            if (D10 != "")
            {
                sql.ToString("D10", decimal.Parse(D10));
            }
            else
            {
                sql.ToString("D10", null);
            }
            arr.Add(sql.ReturnSql());
            bool b = clsSQLCommond.ExecSqlTran(arr);
            return b;
        }

        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.Read)]
        public bool Delete(string iID)
        {
            sSQL = "delete from " + tablename + " where iID='" + iID + "'";
            bool b = clsSQLCommond.Update(sSQL);
            return b;
        }

        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.Read)]
        public bool IsDelete(string iID)
        {
            bool b = false;
            sSQL = "select count(*) from Equip where S5='" + iID + "'";
            int count = clsSQLCommond.Int(sSQL);
            if (count > 0)
            {
                b = true;
            }
            return b;
        }

        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.Read)]
        public bool Check(string iID, string S1, string S2)
        {
            bool b = false;
            sSQL = "select count(*) from " + tablename + " where (S1='" + S1 + "' or S2='" + S2 + "')";
            if (iID != "")
            {
                sSQL = sSQL + " and iID<>'" + iID + "'";
            }
            int count = clsSQLCommond.Int(sSQL);
            if (count > 0)
            {
                b = true;
            }
            return b;
        }
    }
}