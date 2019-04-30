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
    public class LookUpDataAjaxMethod : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        string sSQL = "";
        ClsDataBase clsSQLCommond = new ClsDataBase();
        string tablename = "_LookUpDate";

        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.Read)]
        public bool Insert(string iID, string iText, string iText2, string iType, string Remark, string bClose, string bSystem)
        {
            string uid = Session["uID"].ToString();
            ArrayList arr = new ArrayList();
            Sql sql = new Sql();
            if (iID == "" || iID == null)
            {
                sSQL = "select isnull(max(iID),0)+1 from  " + tablename + "";
                iID = clsSQLCommond.ExecString(sSQL);
                sql.Get(tablename, "iID", iID, true);
            }
            else
            {
                sql.Get(tablename, "iID", iID, false);
            }
            sql.ToString("iText", iText);
            sql.ToString("iText2", iText2);
            sql.ToString("iType", iType);
            sql.ToString("Remark", Remark);
            sql.ToString("bClose", bClose);
            sql.ToString("bSystem", bSystem);
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
            sSQL = "select count(*) from WO where (S5='" + iID + "' or S6='" + iID + "')";
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