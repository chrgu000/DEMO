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
public class LookUpTypeData : Page
{
    ClsDataBase clsSQLCommond = new ClsDataBase();
    string sSQL = "";
    string tablename = "_LookUpType";
    public LookUpTypeData()
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

   

}
