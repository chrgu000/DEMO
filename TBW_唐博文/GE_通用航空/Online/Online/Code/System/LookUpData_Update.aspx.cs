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

public partial class System_LookUpData_Update : System.Web.UI.Page
{

    ClsDataBase clsSQLCommond = new ClsDataBase();
    系统服务.ClsDES clsDES = 系统服务.ClsDES.Instance();
    string sSQL;
    DataTable dt;
    string tablename = "_LookUpDate";
    string tableid = "iID";
    
    #region 加载页面
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(AjaxMethod));
            YxBtn.HidFormID = "FrmLookUpData";
            Bind();

            YxBtn.BtnSave.Visible = true;

            //UserID.Type = "self";
            if (Request.QueryString["iType"] != "" && Request.QueryString["iType"] != null)
            {
                hidiType.Value = Request.QueryString["iType"].ToString();
            }
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
            if (hidiType.Value == "6")
            {
                TextBox3.Enabled = false;
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

        sSQL = "select * from  _TableColInfo where  TABLE_NAME in ('_LookUpDate')";
        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            switch (dt.Rows[i]["COLUMN_NAME"].ToString())
            {
                case "iID":
                    Label1.Text = "*" + dt.Rows[i][ctext].ToString();
                    break;

                case "iText":
                    Label2.Text = "*" + dt.Rows[i][ctext].ToString();
                    break;
                case "iText2":
                    Label3.Text = "*" + dt.Rows[i][ctext].ToString();
                    break;
                case "bClose":
                    Label4.Text = dt.Rows[i][ctext].ToString();
                    break;
                case "bSystem":
                    Label5.Text = dt.Rows[i][ctext].ToString();
                    break;
                case "Remark":
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
    }
    #endregion

    #region 修改时绑定
    protected void UpdateBind()
    {
        sSQL = "select * from " + tablename + " where " + tableid + "='" + YxBtn.HidID + "' and iType='" + hidiType.Value + "'";
        dt = clsSQLCommond.ExecQuery(sSQL);
        if (dt.Rows.Count > 0)
        {
            #region 绑定表
            TextBox1.Text = dt.Rows[0]["iID"].ToString();
            TextBox1.Enabled = false;
            TextBox2.Text = dt.Rows[0]["iText"].ToString();
            TextBox3.Text = dt.Rows[0]["iText2"].ToString();
            TextBox7.Text = dt.Rows[0]["Remark"].ToString();
            if (bool.Parse(dt.Rows[0]["bClose"].ToString()) == true)
            {
                CheckBox4.Checked = true;
            }
            if (bool.Parse(dt.Rows[0]["bSystem"].ToString()) == true)
            {
                CheckBox5.Checked = true;
            }

            if (CheckBox5.Checked == true)
            {
                CheckBox5.Enabled = false;
            }

            #endregion
        }
    }
    #endregion

    #region 保存按钮
    protected void ToSave(object sender, EventArgs e)
    {
        sSQL = "select * from " + tablename + " where " + tableid + "='" + TextBox1.Text + "' and iType='" + hidiType.Value + "'";
        DataTable dt = clsSQLCommond.ExecQuery(sSQL);

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

            sc.ToString("iText", TextBox2.Text);
            sc.ToString("iText2", TextBox3.Text);
            sc.ToString("iType", hidiType.Value);
            sc.ToString("Remark", TextBox7.Text);
            sc.ToString("bClose", CheckBox4.Checked);
            sc.ToString("bSystem", CheckBox5.Checked);

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
            Response.Redirect("LookUpData_Index.aspx");
        }

    }
    #endregion

    #region 删除按钮
    protected void ToDel(object sender, EventArgs e)
    {
        if (IsUsed(hidiType.Value, YxBtn.HidID) == false || CheckBox5.Checked == true)
        {
            OpenWindow ow = new OpenWindow();
            ow.Alert(Page, "已使用或系统项，不可删除");
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

                sSQL = "delete from  " + tablename + " where " + tableid + "='" + YxBtn.HidID + "' and iType='"+hidiType.Value+"'";
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
                Response.Redirect("LookUpData_Index.aspx");
            }
        }
    }

    private bool IsUsed(string iType, string iID)
    {
        if (iType == "1")
        {
            sSQL = "select * from Visitors where S3='" + iID + "'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt.Rows.Count > 0)
            {
                return false;
            }
        }
        if (iType == "2")
        {
            sSQL = "select * from Visitors where S7='" + iID + "'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt.Rows.Count > 0)
            {
                return false;
            }
        }
        if (iType == "3")
        {
            sSQL = "select * from Visitors where S9='" + iID + "'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt.Rows.Count > 0)
            {
                return false;
            }
        }
        return true;
    }
    #endregion

    #region 返回按钮
    protected void ToBeck(object sender, EventArgs e)
    {
        Response.Redirect("LookUpData_Index.aspx");
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

