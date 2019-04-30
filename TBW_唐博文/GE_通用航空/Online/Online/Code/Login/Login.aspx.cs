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
using System.DirectoryServices;
using System.Text;
using System.Runtime.InteropServices;   //必要引用
using System.Security.Principal;    //必要引用
using System.Data.SqlClient;
using System.Web.Configuration;
using Ajax;
using System.Web;

public partial class Login_Login : System.Web.UI.Page
{
    系统服务.ClsDES clsDES = 系统服务.ClsDES.Instance();
    ClsDataBase clsSQLCommond = new ClsDataBase();
    string sSQL = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(AjaxMethod));
        if (!IsPostBack)
        {
            //LogName.Attributes.Add("onkeyup", "javascript:SelectLanguange('" + LogName.ClientID + "','" + LogPwd.ClientID + "');");
            //LogName.Attributes.Add("onmouseout", "javascript:SelectLanguange('" + LogName.ClientID + "','" + LogPwd.ClientID + "');");
            //LogPwd.Attributes.Add("onkeyup", "javascript:SelectLanguange('" + LogName.ClientID + "','" + LogPwd.ClientID + "');");
            //DropDownList1.Attributes.Add("onchange", "javascript:SelectLanguangeChange();");
            Page.Title = Session["CompanyName"].ToString();
            compname.InnerHtml = Session["CompanyName"].ToString();
            Session["uID"] = "";
            Session["uName"] = "";
            Session["uDeptID"] = "";
            Session["uDeptName"] = "";

            PublicClass pc = new PublicClass();
            string ltext = pc.GetLanguageLookUpData();
            sSQL = "select * from _LookUpDate where iType=4";
            DataTable dtlookup = clsSQLCommond.ExecQuery(sSQL);
            DropDownList1.DataSource = dtlookup;
            DropDownList1.DataValueField = "iID";
            DropDownList1.DataTextField = ltext;
            DropDownList1.DataBind();

            //sSQL = "select vlanguage from _UserInfo where vchrUid='" + HttpContext.Current.Session["uID"].ToString() + "'";
            //string vlanguage = clsSQLCommond.String(sSQL);
            //if (vlanguage == "" || vlanguage == "1")
            //{
            //    DropDownList1.Items[0].Selected = true;
            //}
            //else
            //{
            //    DropDownList1.Items[1].Selected = true;
            //}

            //Response.Redirect("../Default.aspx");

            //PublicClass.GetCookie();
            //if (Request.Cookies["OnlineuID"] != null && Request.Cookies["OnlineuID"].Value != "")
            //{
            //    Response.Redirect("../Frame/Index.aspx");
            //}
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {


        string uname = this.LogName.Text.Trim();//获取用户名
        string pwd = LogPwd.Text.Trim();
        string upwd = clsDES.Encrypt(pwd);//获取密码

        if (ADLogin("192.168.1.13", uname, pwd) == false)
        {
            ULogin(uname, upwd);
        }
        
    }



    public void ULogin(string uname, string upwd)
    {
        string sql = "select vchrUid as UserID,vchrName as UserName,vchrPwd from _UserInfo where   vchrUid='" + uname + "'";
        DataTable dt = clsSQLCommond.ExecQueryWithoutSession(sql);
        if (dt.Rows.Count > 0)
        {
            //if (dt.Rows[0]["vchrPwd"].ToString().Trim() == clsDES.Encrypt("123456"))
            //{
            //    Session["uID"] = dt.Rows[0]["UserID"].ToString();
            //    Session["uName"] = dt.Rows[0]["UserName"].ToString();
            //    Response.Redirect("../System/UserInfo_Update2.aspx?ID=" + uname);
            //}
            if (dt.Rows[0]["vchrPwd"].ToString().Trim() == upwd)
            {
                Session["uID"] = dt.Rows[0]["UserID"].ToString();
                Session["uName"] = dt.Rows[0]["UserName"].ToString();

                sSQL = "update  _UserInfo set vlanguage='" + DropDownList1.SelectedValue + "' where  vchrUid='" + uname + "'";
                clsSQLCommond.Update(sSQL);

                Response.Redirect("../Frame/Index.aspx");
            }
            else
            {
                OpenWindow ow = new OpenWindow();
                ow.Alert(Page, "密码错误！");
            }
        }
        else
        {
            OpenWindow ow = new OpenWindow();
            ow.Alert(Page, "用户名错误！");

        }
    }

    public bool ADLogin(string domain, string userName, string password)
    {
        string UserName = userName;
        string Domain = WebConfigurationManager.ConnectionStrings["ConnectionString2"].ToString();
        if (Domain.Trim() == "")
        {
            return false;
        }

        string Password = password;

        
        AD ad = new AD();
        

        if (ad.TryAuthenticate(Domain, userName, password))
        {
            Session["uID"] = UserName;
            Session["uName"] = UserName;
            try
            {
                string sql = "select vchrUid as UserID,vchrName as UserName,vchrPwd from _UserInfo where   vchrUid='" + UserName + "'";
                DataTable dt = clsSQLCommond.ExecQueryWithoutSession(sql);
                if (dt.Rows.Count == 0)
                {
                    SqlConnection con = new SqlConnection(clsSQLCommond.Online);
                    SqlCommand cmd = new SqlCommand();
                    SqlTransaction trans;
                    con.Open();
                    cmd.Connection = con;
                    trans = con.BeginTransaction();
                    cmd.Transaction = trans;
                    try
                    {
                        sSQL = "insert into _UserInfo(vchrUid,vchrName,vchrPwd) values('" + UserName + "','" + UserName + "','" + clsDES.Encrypt("123456") + "') ";
                        cmd.CommandText = sSQL;
                        cmd.ExecuteNonQuery();

                        sSQL = "update  _UserInfo set vlanguage='" + DropDownList1.SelectedValue + "' where  vchrUid='" + UserName + "'";
                        cmd.CommandText = sSQL;
                        cmd.ExecuteNonQuery();

                        sSQL = "insert into   _UserRoleInfo (vchrUserID,vchrRoleID) values('" + UserName + "','office')";
                        cmd.CommandText = sSQL;
                        cmd.ExecuteNonQuery();

                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                    }
                    finally
                    {
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
            Response.Redirect("../Frame/Index.aspx");
            return true;

        }
        else
        {
            OpenWindow ow = new OpenWindow();
            ow.Alert(Page, "登陆失败！");

            return false;
        }
        return true;
    }
}