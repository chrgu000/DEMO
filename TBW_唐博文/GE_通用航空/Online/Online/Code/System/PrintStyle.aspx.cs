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

public partial class System_PrintStyle : System.Web.UI.Page
{
    ClsDataBase clsSQLCommond = new ClsDataBase();
    系统服务.ClsDES clsDES = 系统服务.ClsDES.Instance();
    string sSQL;
    DataTable dt;

    #region 加载页面
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(AjaxMethod));
            YxBtn.HidFormID = "FrmTableCol";
            Bind();
            YxBtn.BtnBack.Visible = false;
            YxBtn.BtnNew.Visible = false;
            YxBtn.BtnSelect.Visible = false;
            YxBtn.BtnSave.Visible = true;

            UpdateBind();
        }
    }
    #endregion

    #region 绑定
    protected void Bind()
    {
        GetTitle();

        sSQL = "Select Flag FROM PrintStyle group by Flag order by Flag ";
        dt = clsSQLCommond.ExecQuery(sSQL);
        DropDownList1.DataValueField = "Flag";
        DropDownList1.DataTextField = "Flag";
        DropDownList1.DataSource = dt;
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("", ""));
        
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
        string s1 = DropDownList1.SelectedValue.Trim();

        if (s1 != "")
        {
            sSQL = "select *  from PrintStyle where Flag = '" + s1 + "' order by Row";

            SmartGridView1.DataSource = clsSQLCommond.ExecQuery(sSQL);
            SmartGridView1.DataBind();
            
        }
    }
    #endregion

    #region 保存按钮
    protected void ToSave(object sender, EventArgs e)
    {
        string sErr = "";
        SqlConnection con = new SqlConnection(clsSQLCommond.Online);
        SqlCommand cmd = new SqlCommand();
        SqlTransaction trans;
        con.Open();
        cmd.Connection = con;
        trans = con.BeginTransaction();
        cmd.Transaction = trans;
        try
        {
            string s1 = DropDownList1.SelectedValue;
            #region  从表
            for (int i = 0; i < SmartGridView1.Rows.Count; i++)
            {
                HiddenField hid = ((HiddenField)SmartGridView1.Rows[i].FindControl("hidid"));
                HiddenField hidRow = ((HiddenField)SmartGridView1.Rows[i].FindControl("hidrow"));
                TextBox TextBox1 = ((TextBox)SmartGridView1.Rows[i].FindControl("TextBox1"));
                TextBox TextBox2 = ((TextBox)SmartGridView1.Rows[i].FindControl("TextBox2"));
                TextBox TextBox3 = ((TextBox)SmartGridView1.Rows[i].FindControl("TextBox3"));
                if (hid.Value.Trim() == "" || hidRow.Value.Trim() == "" || TextBox1.Text.Trim() == "" || TextBox2.Text.Trim() == "" || TextBox3.Text.Trim() == "")
                {
                    sErr = sErr + hidid.Value + " 不可为空" + " \\n";
                }
                else
                {
                    sSQL = "update PrintStyle set Height='" + TextBox1.Text + "',Width='" + TextBox2.Text + "',FontSize='" + TextBox3.Text + "' where Row='" + hidRow.Value + "' and iID='" + hid.Value + "'";
                    cmd.CommandText = sSQL;
                    cmd.ExecuteNonQuery();
                }

            }
            #endregion

            trans.Commit();
            if (sErr != "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "js", "alert('" + sErr + "');window.location.href ='PrintStyle.aspx';", true);
            }
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
        Response.Redirect("PrintStyle.aspx");
    }
    #endregion

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
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateBind();
    }

    
}

