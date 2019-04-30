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

public partial class System_RoleInfo_InIndex : System.Web.UI.Page
{
    ControlsClass cc = new ControlsClass();
    ClsDataBase clsSQLCommond = new ClsDataBase();
    string sSQL;
    //string tablename = "Visitors";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            YxBtn.HidFormID = "FrmRoleInfoList";
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
        Response.Redirect("RoleInfo_Update.aspx");
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
        string sErr = "";
        try
        {
            int j = 0;
            for (int i = 0; i < SmartGridView1.Rows.Count; i++)
            {
                CheckBox chk = ((CheckBox)SmartGridView1.Rows[i].FindControl("chk"));
                if (chk.Checked == true)
                {

                    HiddenField hidid = ((HiddenField)SmartGridView1.Rows[i].FindControl("hidid"));
                    if (hidid.Value == "administrator" || hidid.Value == "adminServer")
                    {
                        sErr = sErr + hidid.Value + "不可删除\\n";
                    }
                    sSQL = "delete  from  _RoleRight where vchrRoleID='" + hidid.Value + "'";
                    cmd.CommandText = sSQL;
                    cmd.ExecuteNonQuery();

                    sSQL = "delete from  _UserRoleInfo where vchrRoleID='" + hidid.Value + "'";
                    cmd.CommandText = sSQL;
                    cmd.ExecuteNonQuery();

                    sSQL = "delete from _RoleInfo where vchrRoleID='" + hidid.Value + "'";
                    cmd.CommandText = sSQL;
                    cmd.ExecuteNonQuery();

                    j = j + 1;
                }
            }
            trans.Commit();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "js", "alert('" + sErr + j + "条已删除" + "');window.location.href ='RoleInfo_Index.aspx';", true);
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
