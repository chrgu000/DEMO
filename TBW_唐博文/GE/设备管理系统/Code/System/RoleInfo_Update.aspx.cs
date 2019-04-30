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

public partial class System_RoleInfo_Update : System.Web.UI.Page
{
    ClsDataBase clsSQLCommond = new ClsDataBase();
    string sSQL;
    DataTable dt;
    string tablename = "_RoleInfo";
    string tableid = "vchrRoleID";
    #region 加载页面
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(AjaxMethod));
            YxBtn.HidFormID = "FrmRoleInfo";
            Bind();

            YxBtn.BtnSave.Visible = true;

            //UserID.Type = "self";

            if (Request.QueryString["ID"] != "" && Request.QueryString["ID"] != null)
            {
                YxBtn.HidID = Request.QueryString["ID"].ToString();
                
                UpdateBind();
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
        //sSQL = "select vlanguage from _UserInfo where vchrUid='" + Session["uID"].ToString() + "'";
        //string vlanguage = clsSQLCommond.String(sSQL);
        //string ctext = "";
        //string ftext="";
        //if (vlanguage == "" || vlanguage == "CHS")
        //{
        //    ctext = "COLUMN_Text";
        //    ftext="fchrFrmText";
        //}
        //else if (vlanguage == "EN")
        //{
        //    ctext = "COLUMN_Text2";
        //    ftext="fchrFrmText2";
        //}

        //sSQL = "select * from  _Form where fchrFrmNameID='访客登记'";
        //DataTable dttitle = clsSQLCommond.ExecQuery(sSQL);
        //if (dttitle.Rows.Count > 0)
        //{
        //    YxBtnTop.Title = dttitle.Rows[0][ftext].ToString();
        //}
        //sSQL = "select * from  _TableColInfo where  TABLE_NAME='" + tablename + "'";
        //DataTable dt = clsSQLCommond.ExecQuery(sSQL);

        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    switch (dt.Rows[i]["COLUMN_NAME"].ToString())
        //    {
        //        case "S1":
        //            Label1.Text = dt.Rows[i][ctext].ToString();
        //            break;
        //        case "S2":
        //            Label2.Text = dt.Rows[i][ctext].ToString();
        //            break;
        //        case "S3":
        //            Label3.Text = dt.Rows[i][ctext].ToString();
        //            break;
        //        case "S4":
        //            Label4.Text = dt.Rows[i][ctext].ToString();
        //            break;
        //        case "S5":
        //            Label5.Text = dt.Rows[i][ctext].ToString();
        //            break;
        //    }
        //}
    }

    #endregion

    #region 新增时绑定
    protected void NewBind()
    {
        YxBtn.boolDel = false;
        Calendar1.Value = DateTime.Now.ToString("yyyy-MM-dd");
        //Calendar2.Value = Convert.ToDateTime("2099-12-31").ToString("yyyy-MM-dd");
    }
    #endregion

    #region 修改时绑定
    protected void UpdateBind()
    {
        sSQL = "select * from " + tablename + " where " + tableid + "='" + YxBtn.HidID + "'";
        dt = clsSQLCommond.ExecQuery(sSQL);
        if (dt.Rows.Count > 0)
        {
            #region 绑定表
            TextBox1.Text = dt.Rows[0]["vchrRoleID"].ToString();
            TextBox1.Enabled = false;
            TextBox2.Text = dt.Rows[0]["vchrRoleText"].ToString();
            //TextBox5.Text = dt.Rows[0]["S5"].ToString();
            //TextBox6.Text = dt.Rows[0]["S6"].ToString();
            TextBox7.Text = dt.Rows[0]["vchrRemark"].ToString();

            Calendar1.Value = dt.Rows[0]["dtmCreate"].ToString();
            //Calendar2.Value = dt.Rows[0]["dtmClose"].ToString();
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

            sc.ToString("vchrRoleText", TextBox2.Text);
            //sc.ToString("vchrPwd", clsDES.Encrypt(TextBox3.Text));

            sc.ToString("vchrRemark", TextBox7.Text);

            sc.ToString("dtmCreate", Calendar1.Value);
            //sc.ToString("dtmClose", Calendar2.Value);

            cmd.CommandText = sc.ReturnSql();
            cmd.ExecuteNonQuery();
            #endregion
            #region  从表
            sSQL = "delete from  _UserRoleInfo where vchrRoleID='" + TextBox1.Text + "'";
            cmd.CommandText = sSQL;
            cmd.ExecuteNonQuery();

            for (int i = 0; i < SmartGridView1.Rows.Count; i++)
            {
                 CheckBox chk = ((CheckBox)SmartGridView1.Rows[i].FindControl("chk"));
                 if (chk.Checked == true)
                 {
                     Sql scc = new Sql();
                     scc.Get("_UserRoleInfo", "vchrRoleID", TextBox1.Text, true);
                     scc.ToString("vchrUserID", SmartGridView1.Rows[i].Cells[1].Text.ToString());
                     cmd.CommandText = scc.ReturnSql();
                     cmd.ExecuteNonQuery();
                 }
            }
            #endregion

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
            Response.Redirect("RoleInfo_Index.aspx");
        }
    }
    #endregion

    #region 返回按钮
    protected void ToBeck(object sender, EventArgs e)
    {
        Response.Redirect("RoleInfo_Index.aspx");
    }
    #endregion

    #region 删除按钮
    protected void ToDel(object sender, EventArgs e)
    {
        string sErr = "";
        ArrayList arr = new ArrayList();
        if (YxBtn.HidID == "administrator" || YxBtn.HidID == "adminServer")
        {
            sErr = sErr + hidid.Value + "不可删除\\n";
        }
        if (sErr == "")
        {
            arr.Add("delete  from  _RoleRight where vchrRoleID='" + YxBtn.HidID + "'");

            arr.Add("delete from  _UserRoleInfo where vchrRoleID='" + YxBtn.HidID + "'");

            arr.Add("delete from _RoleInfo where vchrRoleID='" + YxBtn.HidID + "'");

            bool b = clsSQLCommond.ExecSqlTran(arr);
            if (b == false)
            {
                OpenWindow ow = new OpenWindow();
                ow.Alert(Page, "删除失败");
            }
            else
            {
                Response.Redirect("../ErrorPage.aspx");
            }
        }
        else
        {
            OpenWindow ow = new OpenWindow();
            ow.Alert(Page, sErr);
        }
    }

    #endregion

    #region 新增
    protected void ToNew(object sender, EventArgs e)
    {
        OpenWindow ow = new OpenWindow();
        ow.Alert(Page, "Error");
    }
    #endregion

    #region 查询
    protected void ToSelect(object sender, EventArgs e)
    {
        OpenWindow ow = new OpenWindow();
        ow.Alert(Page, "Error");
    }
    #endregion

    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["sRoleID"] = YxBtn.HidID;

        PublicClass pc = new PublicClass();
        pc.GetSmartGridViewSheet(SmartGridView1);
    }
}

