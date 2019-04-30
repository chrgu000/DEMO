using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;

    /// <summary>
    ///Public 的摘要说明
    /// </summary>
public class LookUpDataData : Page
{
    ClsDataBase clsSQLCommond = new ClsDataBase();
    string sSQL = "";
    string tablename = "_LookUpDate";
    public LookUpDataData()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    public DataTable Get(string iType)
    {
        sSQL = "SELECT * FROM   " + tablename + " where 1=1 ";
        if (iType != "")
        {
            sSQL = sSQL + " and iType='" + iType + "'";
        }

        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
        return dt;
    }

    public bool Insert(string iID, Int32 iType, string iText, string Remark, bool bClose, bool bSystem)
    {
        string uid = Session["uID"].ToString();
        ArrayList arr = new ArrayList();
        Sql sql = new Sql();
        sSQL = "select * from  " + tablename + " where iID='" + iID + "' and iType='" + iType + "'";
        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
        if (dt.Rows.Count==0)
        {
            sql.Get(tablename, "iID", iID, "iType", iType.ToString(), true);
        }
        else
        {
            sql.Get(tablename, "iID", iID, "iType", iType.ToString(), false);
        }
        sql.ToString("iText", iText);
        sql.ToString("Remark", Remark);
        sql.ToString("bClose", bClose);
        sql.ToString("bSystem", bSystem);
        arr.Add(sql.ReturnSql());
        bool b = clsSQLCommond.ExecSqlTran(arr);
        return true;
    }


    public bool Delete(string iID, string iType)
    {
        sSQL = "delete from " + tablename + " where iID='" + iID + "' and iType='" + iType + "'";
        bool b = clsSQLCommond.Update(sSQL);
        return b;
    }

    public bool CheckiID(string iID, string iType)
    {
        sSQL = "SELECT * FROM   " + tablename + " where iID='" + iID + "' and iType='" + iType + "'";
        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
        if (dt.Rows.Count > 0)
        {
            return false;
        }
        return true;
    }
    public bool CheckiText(string iID, string iType, string iText)
    {
        sSQL = "SELECT * FROM   " + tablename + " where iText='" + iText + "' and iType='" + iType + "' ";
        if (iID != "")
        {
            sSQL = sSQL + " and iID<>'" + iID + "'";
        }
        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
        if (dt.Rows.Count > 0)
        {
            return false;
        }
        return true;
    }

    public bool CheckDel(string iID, string iType)
    {
        sSQL = "SELECT * FROM  _TableColInfo where ColSel='LookUpData' and ColSelFlag='" + iType + "' ";
        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            sSQL = "select count(*) from " + dt.Rows[i]["TABLE_CATALOG"].ToString() + "." + dt.Rows[i]["TABLE_SCHEMA"].ToString() + "." + dt.Rows[i]["TABLE_NAME"].ToString() + " where  COLUMN_NAME='" + iID + "' ";
            int iCount = clsSQLCommond.Int(sSQL);
            if (iCount > 0)
            {
                return false;
            }
        }
        return true;
    }
}
