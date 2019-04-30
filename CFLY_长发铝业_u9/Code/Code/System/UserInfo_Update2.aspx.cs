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
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Text;
using Ajax;

public partial class System_UserInfo_Update2 : System.Web.UI.Page
{

    ClsDataBase clsSQLCommond = new ClsDataBase();
    ClsDES clsDES = ClsDES.Instance();
    string sSQL;
    DataTable dt;
    string tablename = "_UserInfo";
    string tableid = "vchrUid";
    #region 加载页面
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            YxBtn.HidFormID = "FrmUserInfo2";
            Bind();

            YxBtn.BtnSave.Visible = true;

            //UserID.Type = "self";

            if (Request.QueryString["ID"] != "" && Request.QueryString["ID"] != null)
            {
                YxBtn.HidID = Request.QueryString["ID"].ToString();
                
                UpdateBind();
                YxBtn.BtnDel.Visible = true;
            }
            else if (Session["uID"].ToString() != "")
            {
                YxBtn.HidID = Session["uID"].ToString();

                UpdateBind();
                YxBtn.BtnDel.Visible = true;
            }
            else
            {
                NewBind();
            }
        }
    }
    #endregion

    #region 绑定
    protected void Bind()
    {
        GetTitle();
    }

    private void GetTitle()
    {
        PublicClass pc = new PublicClass();
        string ctext = pc.GetLanguageColumn();
        string ltext = pc.GetLanguageLookUpData();
        string atext = pc.GetLanguageAlert();
    }

    #endregion

    #region 新增时绑定
    protected void NewBind()
    {
        YxBtn.boolDel = false;
    }
    #endregion

    #region 修改时绑定
    protected void UpdateBind()
    {
        YxBtn.boolDel = false;
        sSQL = "select * from " + tablename + " where " + tableid + "='" + YxBtn.HidID + "'";
        dt = clsSQLCommond.ExecQuery(sSQL);
        if (dt.Rows.Count > 0)
        {
            #region 绑定表
            TextBox1.Text = dt.Rows[0]["vchrUid"].ToString();
            TextBox1.Enabled = false;
            TextBox2.Text = dt.Rows[0]["vchrName"].ToString();
            #endregion
        }
    }
    #endregion

    #region 保存按钮
    protected void ToSave(object sender, EventArgs e)
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
            #region 主表
            Sql sc = new Sql();
            if (YxBtn.HidID == "")
            {
                sc.Get(tablename, tableid, TextBox1.Text, true);
            }
            else
            {
                sc.Get(tablename, tableid, TextBox1.Text, false);
            }

            sc.ToString("vchrName", TextBox2.Text);
            if (TextBox3.Value == "" || TextBox3.Text != TextBox4.Text)
            {
                throw new Exception("密码不同或为空");
            }
            else
            {
                sc.ToString("vchrPwd", clsDES.Encrypt(TextBox3.Text));
            }
            //sc.ToString("cDepCode", ASPxComboBox1.Value.ToString());
            //sc.ToString("vchrRemark", TextBox7.Text);

            //if (ASPxDateEdit1.Value != null)
            //{
            //    sc.ToString("dtmCreate", ASPxDateEdit1.Value.ToString());
            //}
            //if (ASPxDateEdit2.Value != null)
            //{
            //    sc.ToString("dtmClose", ASPxDateEdit2.Value.ToString());
            //}

            cmd.CommandText = sc.ReturnSql();
            cmd.ExecuteNonQuery();
            #endregion
            

            trans.Commit();

            Page.ClientScript.RegisterStartupScript(this.GetType(), "js", "<script>alert('保存成功');window.location.href ='../List.aspx';</script>");
        }
        catch(Exception ee)
        {
            trans.Rollback();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "js", "<script>alert('"+ee.Message+"');</script>");
        }
        finally
        {
            
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
    #endregion

    #region 删除按钮
    protected void ToDel(object sender, EventArgs e)
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

            sSQL = "delete from  _UserRoleInfo where vchrUserID='" + TextBox1.Text + "'";
            cmd.CommandText = sSQL;
            cmd.ExecuteNonQuery();

            sSQL = "delete from _UserInfo where vchrUid='" + TextBox1.Text + "'";
            cmd.CommandText = sSQL;
            cmd.ExecuteNonQuery();

            trans.Commit();
        }
        catch
        {
            trans.Rollback();
            Response.Redirect("../ErrorPage.aspx");
        }
        finally
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
    #endregion

    #region 返回按钮
    protected void ToBeck(object sender, EventArgs e)
    {
        Response.Redirect("UserInfo_Index.aspx");
    }
    #endregion

}

