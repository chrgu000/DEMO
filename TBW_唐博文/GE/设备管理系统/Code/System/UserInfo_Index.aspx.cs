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

public partial class System_UserInfo_Index : System.Web.UI.Page
{
    ClsDataBase clsSQLCommond = new ClsDataBase();
    PublicClass pc = new PublicClass();
    string sSQL;
    //string tablename = "Visitors";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            YxBtn.HidFormID = "FrmUserInfoList";
            //YxBtn.GetViewState(divSel);
            //GetTitle();
            YxBtn.BtnDel.Visible = true;
        }
    }

    private void GetTitle()
    {

        //sSQL = "select vlanguage from _UserInfo where vchrUid='" + Session["uID"].ToString() + "'";
        //string vlanguage = clsSQLCommond.String(sSQL);
        //string ctext = "";
        //string ftext = "";
        //if (vlanguage == "" || vlanguage == "CHS")
        //{
        //    ctext = "COLUMN_Text";
        //    ftext = "fchrFrmText";
        //}
        //else if (vlanguage == "EN")
        //{
        //    ctext = "COLUMN_Text2";
        //    ftext = "fchrFrmText2";
        //}

        //sSQL = "select * from  _Form where fchrFrmNameID='访客登记'";
        //DataTable dttitle = clsSQLCommond.ExecQuery(sSQL);
        //if (dttitle.Rows.Count > 0)
        //{
        //    YxBtn.Title = dttitle.Rows[0][ftext].ToString();
        //}
        //sSQL = "select * from  _TableColInfo where  TABLE_NAME='Visitors'";
        //DataTable dt = clsSQLCommond.ExecQuery(sSQL);

        //for (int i = 0; i < SmartGridView1.Columns.Count; i++)
        //{
        //    DataRow[] dw = dt.Select("COLUMN_NAME='" + SmartGridView1.Columns[i].SortExpression + "'");
        //    if (dw.Length > 0)
        //    {
        //        SmartGridView1.Columns[i].HeaderText = dw[0][ctext].ToString();
        //    }
        //}
    }


    protected void ToSelect(object sender, EventArgs e)
    {
        //YxBtn.SetViewState(divSel);
        SmartGridView1.DataBind();
    }

    protected void ToNew(object sender, EventArgs e)
    {
        Response.Redirect("UserInfo_Update.aspx");
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

                    sSQL = "delete from  _UserRoleInfo where vchrUserID='" + hidid.Value + "'";
                    cmd.CommandText = sSQL;
                    cmd.ExecuteNonQuery();

                    sSQL = "delete from _UserInfo where vchrUid='" + hidid.Value + "'";
                    cmd.CommandText = sSQL;
                    cmd.ExecuteNonQuery();

                    j = j + 1;
                }
            }
            trans.Commit();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "js", "alert('" + j + " " + pc.GetAlert(5) + "');window.location.href ='UserInfo_Index.aspx';", true);
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
        PublicClass pc = new PublicClass();
        pc.GetSmartGridViewSheet(SmartGridView1);
    }
}
