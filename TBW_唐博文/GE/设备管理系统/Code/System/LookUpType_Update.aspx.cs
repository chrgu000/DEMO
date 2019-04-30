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

public partial class System_LookUpType_Update : System.Web.UI.Page
{

    ClsDataBase clsSQLCommond = new ClsDataBase();
    string sSQL;
    DataTable dt;
    string tablename = "_LookUpType";
    string tableid = "iID";
    #region 加载页面
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(AjaxMethod));
            YxBtn.HidFormID = "FrmLookUpType";
            Bind();

            YxBtn.BtnSave.Visible = true;

            //UserID.Type = "self";

            if (Request.QueryString["ID"] != "" && Request.QueryString["ID"] != null)
            {
                YxBtn.HidID = Request.QueryString["ID"].ToString();
                
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
        sSQL = "select * from " + tablename + " where " + tableid + "='" + YxBtn.HidID + "'";
        dt = clsSQLCommond.ExecQuery(sSQL);
        if (dt.Rows.Count > 0)
        {
            #region 绑定表
            TextBox1.Text = dt.Rows[0]["iID"].ToString();
            TextBox1.Enabled = false;
            TextBox2.Text = dt.Rows[0]["iType"].ToString();
            TextBox3.Text = dt.Rows[0]["iType2"].ToString();
            TextBox7.Text = dt.Rows[0]["Remark"].ToString();
            #endregion
        }
    }
    #endregion

    #region 保存按钮
    protected void ToSave(object sender, EventArgs e)
    {
        sSQL = "select * from _LookUpType where iID='" + TextBox1.Text + "'";
        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
        if (YxBtn.HidID!="" && dt.Rows.Count > 0)
        {
            OpenWindow ow = new OpenWindow();
            ow.Alert(Page, "序号重复");
        }
        else
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

                sc.ToString("iType", TextBox2.Text);
                sc.ToString("iType2", TextBox3.Text);

                sc.ToString("Remark", TextBox7.Text);

                cmd.CommandText = sc.ReturnSql();
                cmd.ExecuteNonQuery();
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
                Response.Redirect("LookUpType_Index.aspx");
            }
        }
    }
    #endregion

    #region 删除按钮
    protected void ToDel(object sender, EventArgs e)
    {
        if (IsUsed(YxBtn.HidID) == false)
        {
            OpenWindow ow = new OpenWindow();
            ow.Alert(Page, "已使用，不可删除");
        }
        else
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

                sSQL = "delete from  " + tablename + " where " + tableid + "='" + YxBtn.HidID + "'";
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
                Response.Redirect("LookUpType_Index.aspx");
            }
        }
    }

    private bool IsUsed(string iID)
    {
        sSQL = "select * from _LookUpDate where iType='" + iID + "'";
        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
        if (dt.Rows.Count > 0)
        {
            return false;
        }

        return true;
    }
    #endregion

    #region 返回按钮
    protected void ToBeck(object sender, EventArgs e)
    {
        Response.Redirect("LookUpType_Index.aspx");
    }
    #endregion

    #region 
    protected void ToNew(object sender, EventArgs e)
    {
    }
    #endregion

    #region
    protected void ToSelect(object sender, EventArgs e)
    {
    }
    #endregion
}

