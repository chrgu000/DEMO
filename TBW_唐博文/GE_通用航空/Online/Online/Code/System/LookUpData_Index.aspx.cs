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
using System.Data.OleDb;

public partial class System_LookUpData_Index : System.Web.UI.Page
{
    ClsDataBase clsSQLCommond = new ClsDataBase();
    string sSQL;
    string tablename = "_LookUpDate";
    string tableid = "iID";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            YxBtn.HidFormID = "FrmLookUpDataList";

            sSQL = "select * from _LookUpType ";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            string ttext = "iType";
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = ttext;
            DropDownList1.DataValueField = "iID";
            DropDownList1.DataBind();

            YxBtn.GetViewState(divSel);


            GetTitle();
        }
    }

    private void GetTitle()
    {
        PublicClass pc = new PublicClass();
        string ctext = pc.GetLanguageColumn();

        sSQL = "select * from  _TableColInfo where  TABLE_NAME in ('_LookUpDate')";
        DataTable dt = clsSQLCommond.ExecQuery(sSQL);

        for (int i = 0; i < SmartGridView1.Columns.Count; i++)
        {
            DataRow[] dw = dt.Select("COLUMN_NAME='" + SmartGridView1.Columns[i].SortExpression + "'");
            if (dw.Length > 0)
            {
                SmartGridView1.Columns[i].HeaderText = dw[0][ctext].ToString();
                if (SmartGridView1.Columns[i].SortExpression == "iID")
                {
                    SmartGridView1.Columns[i].HeaderText = dw[0][ctext].ToString();
                }
                if (SmartGridView1.Columns[i].SortExpression == "iText")
                {
                    SmartGridView1.Columns[i].HeaderText = dw[0][ctext].ToString();
                }
                if (SmartGridView1.Columns[i].SortExpression == "iText2")
                {
                    SmartGridView1.Columns[i].HeaderText = dw[0][ctext].ToString();
                }
                if (SmartGridView1.Columns[i].SortExpression == "bClose")
                {
                    SmartGridView1.Columns[i].HeaderText = dw[0][ctext].ToString();
                }
                if (SmartGridView1.Columns[i].SortExpression == "bSystem")
                {
                    SmartGridView1.Columns[i].HeaderText = dw[0][ctext].ToString();
                }
                if (SmartGridView1.Columns[i].SortExpression == "Remark")
                {
                    SmartGridView1.Columns[i].HeaderText = dw[0][ctext].ToString();
                }
            }
        }
    }


    protected void ToSelect(object sender, EventArgs e)
    {
        YxBtn.SetViewState(divSel);
        SmartGridView1.DataBind();
    }

    protected void ToNew(object sender, EventArgs e)
    {
        Response.Redirect("LookUpData_Update.aspx?iType="+DropDownList1.SelectedValue);
    }

    protected void ToDel(object sender, EventArgs e)
    {
        string sSQL = "";
        SqlConnection con = new SqlConnection(clsSQLCommond.Online);
        SqlCommand cmd = new SqlCommand();
        SqlTransaction trans;
        con.Open();
        cmd.Connection = con;
        trans = con.BeginTransaction();
        cmd.Transaction = trans;
        try
        {
            int j = 0;
            string sErr = "";
            for (int i = 0; i < SmartGridView1.Rows.Count; i++)
            {
                CheckBox chk = ((CheckBox)SmartGridView1.Rows[i].FindControl("chk"));
                if (chk.Checked == true)
                {
                    HiddenField hidid = ((HiddenField)SmartGridView1.Rows[i].FindControl("hidid"));
                    if (IsUsed(DropDownList1.SelectedValue, hidid.Value) == false || bool.Parse( SmartGridView1.Rows[i].Cells[5].Text)==true)
                    {
                        sErr = sErr + hidid.Value + "不可删除\\n";
                    }
                    else
                    {
                        sSQL = "delete from  " + tablename + " where " + tableid + "='" + hidid.Value + "' and iType='"+DropDownList1.SelectedValue+"'";
                        cmd.CommandText = sSQL;
                        cmd.ExecuteNonQuery();

                        j = j + 1;
                    }
                }
            }
            trans.Commit();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "js", "alert('"+ sErr + j + "条已删除" + "');window.location.href ='LookUpData_Index.aspx';", true);
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

    private bool IsUsed(string iType,string iID)
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
    #region 返回按钮
    protected void ToBeck(object sender, EventArgs e)
    {
        OpenWindow ow = new OpenWindow();
        ow.Alert(Page, "Error");
    }
    #endregion

    #region 
    protected void ToSave(object sender, EventArgs e)
    {
        OpenWindow ow = new OpenWindow();
        ow.Alert(Page, "Error");
    }
    #endregion

    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["iType"] = DropDownList1.SelectedValue;
        if (DropDownList1.SelectedValue == "6")
        {
            SmartGridView1.Columns[3].Visible = false;
        }
        else
        {
            SmartGridView1.Columns[3].Visible = true;
        }
        PublicClass pc = new PublicClass();
        pc.GetSmartGridViewSheet(SmartGridView1);
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        YxBtn.SetViewState(divSel);
        SmartGridView1.DataBind();
    }
}
