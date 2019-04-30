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

public partial class Login_Login : System.Web.UI.Page
{
    系统服务.ClsDES clsDES;
    protected void Page_Load(object sender, EventArgs e)
    {
        clsDES = 系统服务.ClsDES.Instance();
        Page.Title = Session["CompanyName"].ToString();
        Session["uID"] = "";
        Session["uName"] = "";
        Session["uDeptID"] = "";
        Session["uDeptName"] = "";

        if (!IsPostBack)
        {
            
        }

        //Response.Redirect("../Default.aspx");

        //PublicClass.GetCookie();
        //if (Request.Cookies["OnlineuID"] != null && Request.Cookies["OnlineuID"].Value != "")
        //{
        //    Response.Redirect("../Frame/Index.aspx");
        //}
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        string uname = this.LogName.Text.Trim();//获取用户名
        //EncryptClass ec = new EncryptClass();
        string pwd = LogPwd.Text.Trim();
        string upwd = clsDES.Encrypt(pwd);//获取密码
        ULogin(uname, upwd);
    }

    public void ULogin(string uname, string upwd)
    {
        string sql = "select vchrUid as UserID,vchrName as UserName from _UserInfo where  vchrPwd='" + upwd + "'  and vchrUid='" + uname + "'";
        DataTable dt = Conn.DataTableWithoutSession(sql);
        if (dt.Rows.Count > 0)
        {
            Session["uID"] = dt.Rows[0]["UserID"].ToString();
            Session["uName"] = dt.Rows[0]["UserName"].ToString();
            Response.Redirect("../Frame/Index.aspx");

        }
        else
        {
            OpenWindow ow = new OpenWindow();
            ow.Alert(Page, "用户名或密码错误！");

        }
    }
}
