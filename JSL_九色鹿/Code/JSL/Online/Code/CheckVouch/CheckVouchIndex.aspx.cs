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

public partial class CheckVouch_CheckVouchIndex : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Cal.ValueStart = DateTime.Now.ToString("yyyy-MM-dd");
            YxBtnIndex.GetViewState(divSel);
            SmartGridView1.Focus();
        }
    }


    protected void ToSelect(object sender, EventArgs e)
    {
        YxBtnIndex.SetViewState(divSel);
        SmartGridView1.DataBind();
        SmartGridView1.Focus();
    }

    protected void ToNew(object sender, EventArgs e)
    {
        Response.Redirect("../CheckVouch/CheckVouchUpdate.aspx");
    }

    protected void ToDel(object sender, EventArgs e)
    {
        string sSQL = "";
        SqlConnection con = new SqlConnection(Conn.Online);
        SqlCommand cmd = new SqlCommand();
        SqlTransaction trans;
        con.Open();
        cmd.Connection = con;
        trans = con.BeginTransaction();
        cmd.Transaction = trans;
        try
        {
            int j = 0;
            for (int i = 0; i < SmartGridView1.Rows.Count; i++)
            {
                CheckBox chk = ((CheckBox)SmartGridView1.Rows[i].FindControl("chk"));
                if (chk.Checked == true)
                {
                    HiddenField hidid = ((HiddenField)SmartGridView1.Rows[i].FindControl("hidid"));
                    HiddenField hidsid = ((HiddenField)SmartGridView1.Rows[i].FindControl("hidsid"));
                    sSQL = "delete CheckVouchs where AutoID = '" + hidsid.Value + "' ";
                    cmd.CommandText = sSQL;
                    cmd.ExecuteNonQuery();
                    sSQL = "select * from CheckVouchs where ID = '" + hidsid.Value + "'";
                    DataTable dt = Conn.DataTable(sSQL);
                    if (dt.Rows.Count == 0)
                    {
                        sSQL = "delete CheckVouch where ID = '" + hidsid.Value + "' ";
                        cmd.CommandText = sSQL;
                        cmd.ExecuteNonQuery();
                    }
                    j = j + 1;
                }
            }
            trans.Commit();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "js", "alert('" + j + "条已删除" + "');window.location.href ='CheckVouchIndex.aspx';", true);
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

    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["sdate"] = Cal.ValueStart;
        e.InputParameters["edate"] = Cal.ValueEnd;
    }
}
