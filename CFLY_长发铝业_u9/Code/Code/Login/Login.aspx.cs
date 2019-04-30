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
    ClsDES clsDES = ClsDES.Instance();
    ClsDataBase clsSQLCommond = new ClsDataBase();
    string sSQL = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //LogName.Attributes.Add("onkeyup", "javascript:SelectLanguange('" + LogName.ClientID + "','" + LogPwd.ClientID + "');");
            //LogName.Attributes.Add("onmouseout", "javascript:SelectLanguange('" + LogName.ClientID + "','" + LogPwd.ClientID + "');");
            //LogPwd.Attributes.Add("onkeyup", "javascript:SelectLanguange('" + LogName.ClientID + "','" + LogPwd.ClientID + "');");
            //DropDownList1.Attributes.Add("onchange", "javascript:SelectLanguangeChange();");
            PublicClass pc = new PublicClass();
            string title = pc.GetCompany();
            Page.Title = title;
            //compname.Value = Session["CompanyName"].ToString();
            Session["uID"] = "游客";
            Session["uName"] = "游客";
            Session["uDeptID"] = "";
            Session["uDeptName"] = "";

            string ltext = pc.GetLanguageLookUpData();
            sSQL = "select * from _LookUpDate where iType=4";
            DataTable dtlookup = clsSQLCommond.ExecQuery(sSQL);

            //ASPxDateEdit1.Value = DateTime.Now;
            //DropDownList1.DataSource = dtlookup;
            //DropDownList1.DataValueField = "iID";
            //DropDownList1.DataTextField = ltext;
            //DropDownList1.DataBind();
            //LogName.Focus();

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
    protected void LoginButton_Click(object sender, EventArgs e)
    {


        string uname = UserName.Text;//获取用户名
        string pwd =Password.Text;
        //string NowDate = ASPxDateEdit1.Value.ToString();
        string upwd = clsDES.Encrypt(pwd);//获取密码
        ULogin(uname, upwd);
        //if (ADLogin("192.168.1.13", uname, pwd) == false)
        //{
        //    ULogin(uname, upwd);
        //}
        
    }



    public void ULogin(string uname, string upwd)
    {
        try
        {
            string sql = "select vchrUid as UserID,vchrName as UserName,vchrPwd,cDepCode from _UserInfo where vchrUid='" + uname + "'";
            DataTable dt = clsSQLCommond.ExecQueryWithoutSession(sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["vchrPwd"].ToString().Trim() == upwd)
                {
                    Session["uID"] = dt.Rows[0]["UserID"].ToString();
                    Session["uName"] = dt.Rows[0]["UserName"].ToString();
//                    sSQL = @"select cDept_num,c.cPsn_Num,a.cUser_Id as cPersonCode,a.cUser_Name as cPersonName from @u8.UA_User a, @u8.UserHRPersonContro b,@u8.hr_hi_person c where a.cUser_Id = b.cUser_Id and b.cPsn_Num = c.cPsn_Num 
//                    and a.cUser_Id='" + dt.Rows[0]["UserID"].ToString() + "'";
//                    DataTable dts = clsSQLCommond.ExecQueryWithoutSession(sSQL);
//                    if (dts.Rows.Count > 0)
//                    {
//                        Session["uDeptID"] = dts.Rows[0]["cDept_num"].ToString();
//                    }
                    //sSQL = "update  _UserInfo set vlanguage='" + DropDownList1.SelectedValue + "' where  vchrUid='" + uname + "'";
                    //clsSQLCommond.Update(sSQL);

                    sSQL = "select vchrUid as UserID,vchrName as UserName,vchrPwd,cDepCode from _UserInfo where  isnull(dtmCreate,getdate())<=getdate() and isnull(dtmClose,getdate())>=getdate() and  vchrUid='" + uname + "'";
                    DataTable dtclose = clsSQLCommond.ExecQueryWithoutSession(sSQL);
                    if (dtclose.Rows.Count == 0)
                    {
                        throw new Exception("账号异常");
                    }
                    else
                    {
                        //Session["NowDate"] = NowDate;
                        //if (((CheckBox)Login1.FindControl("CheckBox1")).Checked == true)
                        //if(CheckBox1.Checked==true)
                        //{
                        //    Response.Redirect("../System/UserInfo_Update2.aspx");
                        //}
                        //else
                        //{
                            Response.Redirect("../List.aspx");
                        //}
                    }
                }
                else
                {
                    throw new Exception("密码错误");
                }
            }
            else
            {
                throw new Exception("登陆失败");

            }
        }
        catch (Exception ee)
        {
            System.Web.HttpContext.Current.Response.Write("<script>alert('"+ee.Message+"！');</script>");
        }
    }

    //public bool ADLogin(string domain, string userName, string password)
    //{
    //    string UserName = userName;
    //    string Domain = WebConfigurationManager.ConnectionStrings["ConnectionString2"].ToString();
    //    if (Domain.Trim() == "")
    //    {
    //        return false;
    //    }

    //    string Password = password;


    //    AD ad = new AD();


    //    if (ad.TryAuthenticate(Domain, userName, password))
    //    {
    //        Session["uID"] = UserName;
    //        Session["uName"] = UserName;
    //        try
    //        {
    //            string sql = "select vchrUid as UserID,vchrName as UserName,vchrPwd from _UserInfo where   vchrUid='" + UserName + "'";
    //            DataTable dt = clsSQLCommond.ExecQueryWithoutSession(sql);
    //            if (dt.Rows.Count == 0)
    //            {
    //                SqlConnection con = new SqlConnection(clsSQLCommond.Online);
    //                SqlCommand cmd = new SqlCommand();
    //                SqlTransaction trans;
    //                con.Open();
    //                cmd.Connection = con;
    //                trans = con.BeginTransaction();
    //                cmd.Transaction = trans;
    //                try
    //                {
    //                    sSQL = "insert into _UserInfo(vchrUid,vchrName,vchrPwd) values('" + UserName + "','" + UserName + "','" + clsDES.Encrypt("123456") + "') ";
    //                    cmd.CommandText = sSQL;
    //                    cmd.ExecuteNonQuery();

    //                    //sSQL = "update  _UserInfo set vlanguage='" + DropDownList1.SelectedValue + "' where  vchrUid='" + UserName + "'";
    //                    //cmd.CommandText = sSQL;
    //                    //cmd.ExecuteNonQuery();

    //                    sSQL = "insert into   _UserRoleInfo (vchrUserID,vchrRoleID) values('" + UserName + "','office')";
    //                    cmd.CommandText = sSQL;
    //                    cmd.ExecuteNonQuery();

    //                    trans.Commit();
    //                }
    //                catch
    //                {
    //                    trans.Rollback();
    //                }
    //                finally
    //                {
    //                    if (con.State == ConnectionState.Open)
    //                    {
    //                        con.Close();
    //                    }
    //                }
    //            }
    //        }
    //        catch
    //        {
    //            return false;
    //        }
    //        Response.Redirect("../Frame/Index.aspx");
    //        return true;

    //    }
    //    else
    //    {
    //        OpenWindow ow = new OpenWindow();
    //        ow.Alert(Page, "登陆失败！");

    //        return false;
    //    }
    //    return true;
    //}
}