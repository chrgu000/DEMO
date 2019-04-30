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
    系统服务.ClsDES clsDES = 系统服务.ClsDES.Instance();
    string sSQL;
    DataTable dt;
    string tablename = "_UserInfo";
    string tableid = "vchrUid";
    #region 加载页面
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(AjaxMethod));
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

        sSQL = "select * from  _TableColInfo where  TABLE_NAME in ('_UserInfo')";
        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            switch (dt.Rows[i]["COLUMN_NAME"].ToString())
            {
                case "vchrUid":
                    Label1.Text = "*" + dt.Rows[i][ctext].ToString();
                    break;

                case "vchrName":
                    Label2.Text = "*" + dt.Rows[i][ctext].ToString();
                    break;
                case "vchrPwd":
                    Label3.Text = "*" + dt.Rows[i][ctext].ToString();
                    Label4.Text = "*Repeat The " + dt.Rows[i][ctext].ToString();
                    break;
                case "dtmCreate":
                    Label5.Text = dt.Rows[i][ctext].ToString();
                    break;
                case "dtmClose":
                    Label6.Text = dt.Rows[i][ctext].ToString();
                    break;
                case "vchrRemark":
                    Label7.Text = dt.Rows[i][ctext].ToString();
                    break;

            }
        }
    }

    #endregion

    #region 新增时绑定
    protected void NewBind()
    {
        YxBtn.boolDel = false;
        Calendar1.Value = DateTime.Now.ToString("yyyy-MM-dd");
        Calendar2.Value = Convert.ToDateTime("2099-12-31").ToString("yyyy-MM-dd");
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
            TextBox3.Attributes["value"] = clsDES.Decrypt(dt.Rows[0]["vchrPwd"].ToString());
            TextBox4.Attributes["value"] = clsDES.Decrypt(dt.Rows[0]["vchrPwd"].ToString());
            //TextBox5.Text = dt.Rows[0]["S5"].ToString();
            //TextBox6.Text = dt.Rows[0]["S6"].ToString();
            TextBox7.Text = dt.Rows[0]["vchrRemark"].ToString();

            Calendar1.Value = dt.Rows[0]["dtmCreate"].ToString();
            Calendar2.Value = dt.Rows[0]["dtmClose"].ToString();
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
            sc.ToString("vchrPwd", clsDES.Encrypt(TextBox3.Text));

            sc.ToString("vchrRemark", TextBox7.Text);

            sc.ToString("dtmCreate", Calendar1.Value);
            sc.ToString("dtmClose", Calendar2.Value);

            cmd.CommandText = sc.ReturnSql();
            cmd.ExecuteNonQuery();
            #endregion
            #region  从表
            sSQL = "delete from  _UserRoleInfo where vchrUserID='" + TextBox1.Text + "'";
            cmd.CommandText = sSQL;
            cmd.ExecuteNonQuery();

            //for (int i = 0; i < SmartGridView1.Rows.Count; i++)
            //{
            //    CheckBox chk = ((CheckBox)SmartGridView1.Rows[i].FindControl("chk"));
            //    if (chk.Checked == true)
            //    {
            //        Sql scc = new Sql();

            //        scc.Get(" _UserRoleInfo", "vchrUserID", TextBox1.Text, true);
            //        scc.ToString("vchrRoleID", SmartGridView1.Rows[i].Cells[1].Text.ToString());
            //        cmd.CommandText = scc.ReturnSql();
            //        cmd.ExecuteNonQuery();
            //    }
            //}
            #endregion

            trans.Commit();

            Page.ClientScript.RegisterStartupScript(this.GetType(), "js", "<script>alert('保存成功');window.location.href ='UserInfo_Update2.aspx';</script>");
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

