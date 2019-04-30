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

public partial class System_CreateFormMenu_List : System.Web.UI.Page
{
    ClsDataBase clsSQLCommond = new ClsDataBase();
    ClsDES clsDES = ClsDES.Instance();
    string sSQL;
    DataTable dt;
    string tablename = "_Form";
    string tableid = "fchrFrmNameID";

    #region 加载页面
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            YxBtn.HidFormID = "FrmCreateFormMenu";
            AjaxPro.Utility.RegisterTypeForAjax(typeof(AjaxMethod));
            Bind();

            YxBtn.BtnSave.Visible = true;
            YxBtn.BtnBack.Visible = false;

            //UserID.Type = "self";

            

            if (Request.QueryString["dirid"] != "" && Request.QueryString["dirid"] != null)
            {
                YxBtn.HidID = Request.QueryString["dirid"].ToString();
                
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
    }

    #endregion

    #region 新增时绑定
    protected void NewBind()
    {

    }
    #endregion

    #region 修改时绑定
    protected void UpdateBind()
    {
        if (YxBtn.HidID != "")
        {
            sSQL = "select * from _Form where fchrFrmNameID = '" + YxBtn.HidID + "' ORDER BY fIntOrderID";
            DataTable dtFormNew = clsSQLCommond.ExecQuery(sSQL);
            if (dtFormNew.Rows.Count>0)
            {
                TextBox1.Text = dtFormNew.Rows[0]["fchrFrmNameID"].ToString().Trim();
                TextBox2.Text = dtFormNew.Rows[0]["fIntOrderID"].ToString().Trim();
                TextBox3.Text = dtFormNew.Rows[0]["fchrFrmText"].ToString().Trim();
                TextBox4.Text = dtFormNew.Rows[0]["fchrFrmText2"].ToString().Trim();
                
            }

            //if (dtFormNew.Rows[0]["fchrFrmNameID"].ToString().Trim().ToLower().StartsWith("frm"))
            //{
                sSQL = "select 0 as bChoose,*,'' as FormText,'' as FormText2,'' as FormOrder,'' as FormEnable from _BtnBaseInfo order by iOrder ";
                DataTable dts = clsSQLCommond.ExecQuery(sSQL);
                sSQL = "select *,vchrBtnText as FormText,intOrder as FormOrder from dbo._FormBtnInfo where fchrFrmNameID = '" + YxBtn.HidID + "'";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dts.Rows.Count; j++)
                    {
                        if (dt.Rows[i]["vchrBtnID"].ToString().Trim().ToLower() == dts.Rows[j]["btnCode"].ToString().Trim().ToLower())
                        {
                            dts.Rows[j]["bChoose"] =true;
                            dts.Rows[j]["FormText"] = dt.Rows[i]["vchrBtnText"].ToString().Trim();
                            dts.Rows[j]["FormText2"] = dt.Rows[i]["vchrBtnText2"].ToString().Trim();
                            dts.Rows[j]["FormOrder"] = dt.Rows[i]["FormOrder"].ToString().Trim();
                            dts.Rows[j]["FormEnable"] = dt.Rows[i]["intOrder"].ToString().Trim();
                            break;
                        }
                    }
                }

                SmartGridView1.DataSource = dts;
                SmartGridView1.DataBind();
            //}
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

            sc.ToString("fIntOrderID", TextBox2.Text);
            sc.ToString("fchrFrmText", TextBox3.Text);
            sc.ToString("fchrFrmText2", TextBox4.Text);
            //sc.ToString("vchrPwd", clsDES.Encrypt(TextBox3.Text));

            //sc.ToString("vchrRemark", TextBox7.Text);

            //sc.ToString("dtmCreate", Calendar1.Value);
            //sc.ToString("dtmClose", Calendar2.Value);

            cmd.CommandText = sc.ReturnSql();
            cmd.ExecuteNonQuery();
            #endregion
            #region  从表
            sSQL = "delete _FormBtnInfo where fchrFrmNameID = '" + TextBox1.Text + "' ";
            cmd.CommandText = sSQL;
            cmd.ExecuteNonQuery();

            for (int i = 0; i < SmartGridView1.Rows.Count; i++)
            {
                 HtmlInputCheckBox chk = ((HtmlInputCheckBox)SmartGridView1.Rows[i].FindControl("chk"));
                 if (chk.Checked == true)
                 {
                     Sql scc = new Sql();
                     scc.Get("_FormBtnInfo", "fchrFrmNameID", TextBox1.Text, true);
                     scc.ToString("vchrBtnID", ((HiddenField)SmartGridView1.Rows[i].FindControl("hidid")).Value);
                     scc.ToString("vchrBtnText", ((TextBox)SmartGridView1.Rows[i].FindControl("TextBox1")).Text);
                     scc.ToString("vchrBtnText2", ((TextBox)SmartGridView1.Rows[i].FindControl("TextBox2")).Text);
                     scc.ToString("intOrder", ((TextBox)SmartGridView1.Rows[i].FindControl("TextBox3")).Text);
                     scc.ToString("bEnable", "0");
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
            Response.Redirect("CreateFormMenu_List.aspx?dirid="+YxBtn.HidID);
        }
    }
    #endregion

    #region 返回按钮
    protected void ToBeck(object sender, EventArgs e)
    {
        Response.Redirect("RoleInfo_Index.aspx");
    }
    #endregion

    //protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    //{
    //    e.InputParameters["sRoleID"] = YxBtn.HidID;
    //}
    protected void chk_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chk = sender as CheckBox;

        int index = ((GridViewRow)(chk.NamingContainer)).RowIndex;

        if (chk.Checked)
        {
            SmartGridView1.Rows[index].Cells[5].Text = SmartGridView1.Rows[index].Cells[2].Text.Trim();
            SmartGridView1.Rows[index].Cells[6].Text = SmartGridView1.Rows[index].Cells[3].Text.Trim();
            SmartGridView1.Rows[index].Cells[7].Text = SmartGridView1.Rows[index].Cells[4].Text.Trim();
        }
    }
}

