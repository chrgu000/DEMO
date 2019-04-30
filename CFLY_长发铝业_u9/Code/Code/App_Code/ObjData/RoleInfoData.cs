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
public class RoleInfoData : Page
{
    ClsDataBase clsSQLCommond = new ClsDataBase();
    string sSQL = "";
    string tablename = "_RoleInfo";
    public RoleInfoData()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    public DataTable Get()
    {
        sSQL = "SELECT * FROM   " + tablename + " where 1=1 ";
        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
        return dt;
    }

    public bool Insert(string vchrRoleID, string vchrRoleText, string vchrRemark)
    {
        string uid = Session["uID"].ToString();
        ArrayList arr = new ArrayList();
        Sql sql = new Sql();
        sSQL = "select * from  " + tablename + " where vchrRoleID='" + vchrRoleID + "'";
        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
        if (dt.Rows.Count == 0)
        {
            sql.Get(tablename, "vchrRoleID", vchrRoleID, true);
        }
        else
        {
            sql.Get(tablename, "vchrRoleID", vchrRoleID, false);
        }
        sql.ToString("vchrRoleText", vchrRoleText);
        sql.ToString("vchrRemark", vchrRemark);
        arr.Add(sql.ReturnSql());
        bool b = clsSQLCommond.ExecSqlTran(arr);
        return true;
    }

}
