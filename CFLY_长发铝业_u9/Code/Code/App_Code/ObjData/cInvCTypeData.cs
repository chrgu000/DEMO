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
using System.Web.Configuration;
    /// <summary>
    ///Public 的摘要说明
    /// </summary>
public class cInvcTypeData : Page
{
    ClsDataBase clsSQLCommond = new ClsDataBase();
    string sSQL = "";
    string tablename = "cInvCType";
    public string dDate
    {
        get { return WebConfigurationManager.ConnectionStrings["ConnectionStringdDate"].ToString(); }
        set { }
    }
    public cInvcTypeData()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    public DataTable Get()
    {
        sSQL = @"SELECT a.cInvCCode,cInvCName,Per
          FROM (select cInvCCode,cInvCName from viewSalesBack group by cInvCCode,cInvCName) a left join  " + tablename + " b on a.cInvCCode=b.cInvCCode ";
        sSQL = sSQL + "  order by cInvCCode";
        DataTable dt = clsSQLCommond.ExecQueryWithoutSession(sSQL);
        return dt;
    }

    public bool Insert(string cInvCCode, decimal Per)
    {
        ArrayList arr = new ArrayList();
        sSQL = "select * from  " + tablename + " where cInvCCode='" + cInvCCode + "'";
        DataTable dt = clsSQLCommond.ExecQueryWithoutSession(sSQL);
        if (dt.Rows.Count > 0)
        {
            sSQL = "update " + tablename + " set Per='" + Per + "' where cInvCCode='" + cInvCCode + "'";
        }
        else
        {
            sSQL = "insert into " + tablename + "(cInvCCode,Per) values('" + cInvCCode + "','" + Per + "')";
        }
        arr.Add(sSQL);
        bool b = clsSQLCommond.ExecSqlTran(arr);
        return true;
    }

 

}
