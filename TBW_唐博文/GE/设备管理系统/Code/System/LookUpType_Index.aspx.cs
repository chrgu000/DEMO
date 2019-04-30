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

public partial class System_LookUpType_Index : System.Web.UI.Page
{
    ClsDataBase clsSQLCommond = new ClsDataBase();
    string sSQL;
    string tablename = "_LookUpType";
    string tableid = "iID";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            YxBtn.HidFormID = "FrmLookUpTypeList";
            //YxBtn.GetViewState(divSel);
            //GetTitle();
        }
    }

    private void GetTitle()
    {
    }


    protected void ToSelect(object sender, EventArgs e)
    {
        //YxBtn.SetViewState(divSel);
        SmartGridView1.DataBind();
    }

    protected void ToNew(object sender, EventArgs e)
    {
        Response.Redirect("LookUpType_Update.aspx");
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
                    if (IsUsed(hidid.Value) == false )
                    {
                        sErr = sErr + hidid.Value + "不可删除\\n";
                    }
                    else
                    {
                        sSQL = "delete from  " + tablename + " where " + tableid + "='" + hidid.Value + "'";
                        cmd.CommandText = sSQL;
                        cmd.ExecuteNonQuery();

                        j = j + 1;
                    }
                }
            }
            trans.Commit();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "js", "alert('" + sErr + j + "条已删除" + "');window.location.href ='LookUpType_Index.aspx';", true);
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
        PublicClass pc = new PublicClass();
        pc.GetSmartGridViewSheet(SmartGridView1);
    }
}
