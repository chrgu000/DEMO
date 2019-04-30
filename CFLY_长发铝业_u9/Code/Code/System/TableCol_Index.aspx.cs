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

public partial class System_TableCol_Index : System.Web.UI.Page
{
    ClsDataBase clsSQLCommond = new ClsDataBase();
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

        sSQL = "Select Name FROM Master..SysDatabases order by Name ";
        dt = clsSQLCommond.ExecQuery(sSQL);
        DropDownList1.DataValueField = "Name";
        DropDownList1.DataTextField = "Name";
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
        string s2 = DropDownList2.SelectedValue.Trim();

        if (s1 != "" && s2 != "")
        {
            sSQL = @"select  iID, a.TABLE_CATALOG, a.TABLE_SCHEMA, a.TABLE_NAME, a.COLUMN_NAME, COLUMN_Text, COLUMN_Text2, VisibleIndex, ShowCol, ColType, ColLink, 
                      ColLinkID, ColLinkText, ColSel, ColSelFlag, IsInput, UpdateVisibleIndex, UpdateEnable, UpdateType, a.DATA_TYPE, COLLATION_ADD, bSystem, bKey,
a.DATA_Type as DATA_Type2,0 as bUsed ,2 as DataType,isnull(t.collation_add,0) as collation_add,case a.COLUMN_NAME when isnull(t.COLUMN_NAME,0) then 0 else 1 end  as newAdd,isnull(t.bKey ,0) as bKey " +
                                "from " + s1 + ".INFORMATION_SCHEMA.COLUMNS a left join dbo._TableColInfo t on a.TABLE_CATALOG = t.TABLE_CATALOG and a.TABLE_NAME=t.TABLE_NAME and a.COLUMN_NAME = t.COLUMN_NAME " +
                                "where a.table_name = '" + s2 + "' " +
                                "order by a.table_name,a.ordinal_position";

            SmartGridView1.DataSource = clsSQLCommond.ExecQuery(sSQL);
            SmartGridView1.DataBind();
            
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
            string s1 = DropDownList1.SelectedValue;
            string s2 = DropDownList2.SelectedValue;
            #region  从表
            for (int i = 0; i < SmartGridView1.Rows.Count; i++)
            {
                HiddenField hid = ((HiddenField)SmartGridView1.Rows[i].FindControl("hid"));
                Sql scc = new Sql();

                if (hid.Value == "")
                {
                    scc.Get("_TableColInfo", "TABLE_CATALOG", s1, true);
                }
                else
                {
                    scc.Get("_TableColInfo", "iID", hid.Value, false);
                    scc.ToString("TABLE_CATALOG", s1);
                }
                scc.ToString("TABLE_SCHEMA", "dbo");
                scc.ToString("TABLE_NAME", s2);
                scc.ToString("COLUMN_NAME", SmartGridView1.Rows[i].Cells[2].Text.Trim());
                scc.ToString("COLUMN_Text", ((TextBox)SmartGridView1.Rows[i].FindControl("TextBoxCOLUMN_Text")).Text);
                scc.ToString("COLUMN_Text2", ((TextBox)SmartGridView1.Rows[i].FindControl("TextBoxCOLUMN_Text2")).Text);
                scc.ToString("VisibleIndex", ((TextBox)SmartGridView1.Rows[i].FindControl("TextBoxVisibleIndex")).Text);
                scc.ToString("ColType", ((TextBox)SmartGridView1.Rows[i].FindControl("TextBoxColType")).Text);
                scc.ToString("ColLink", ((TextBox)SmartGridView1.Rows[i].FindControl("TextBoxColLink")).Text);
                scc.ToString("ColSel", ((TextBox)SmartGridView1.Rows[i].FindControl("TextBoxColSel")).Text);
                scc.ToString("ColSelFlag", ((TextBox)SmartGridView1.Rows[i].FindControl("TextBoxColSelFlag")).Text);
                scc.ToString("IsInput", ((TextBox)SmartGridView1.Rows[i].FindControl("TextBoxIsInput")).Text);
                scc.ToString("UpdateVisibleIndex", ((TextBox)SmartGridView1.Rows[i].FindControl("TextBoxUpdateVisibleIndex")).Text);
                scc.ToString("UpdateType", ((TextBox)SmartGridView1.Rows[i].FindControl("TextBoxUpdateType")).Text);
                scc.ToString("DATA_TYPE", SmartGridView1.Rows[i].Cells[3].Text.Trim());
                scc.ToString("COLLATION_ADD", "0");
                scc.ToString("bSystem", "0");
                scc.ToString("bKey", "0");
                cmd.CommandText = scc.ReturnSql();
                cmd.ExecuteNonQuery();

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
        }
    }
    #endregion

    #region 返回按钮
    protected void ToBeck(object sender, EventArgs e)
    {
        Response.Redirect("RoleInfo_Index.aspx");
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
        sSQL = "Select Name FROM " + DropDownList1.SelectedValue.ToString().Trim() + "..SysObjects Where XType='U' orDER BY Name  ";
        dt = clsSQLCommond.ExecQuery(sSQL);
        DropDownList2.DataValueField = "Name";
        DropDownList2.DataTextField = "Name";
        DropDownList2.DataSource = dt;
        DropDownList2.DataBind();
        DropDownList2.Items[0].Selected = true;
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateBind();
    }

    
}

