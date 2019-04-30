using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class ErrorPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string uid = Session["uID"].ToString();
        string sErr = "";
        if (Server.GetLastError() != null)
        {
            sErr = Server.GetLastError().Message;
        }
        if (uid == "")
        {
            lbl.InnerHtml = "错误原因： 密码失效;请<br />";
        }
        else if (sErr != "")
        {
            lbl.InnerHtml = "错误原因： " + sErr + ";请<br />";
        }
    }
}
