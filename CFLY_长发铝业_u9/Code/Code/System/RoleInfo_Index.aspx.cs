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
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxClasses;

public partial class System_RoleInfo_Index : System.Web.UI.Page
{
    ClsDataBase clsSQLCommond = new ClsDataBase();
    PublicClass pc = new PublicClass();
    string sSQL;
    string tablename = "_RoleInfo";
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
    }


    protected void ToSelect(object sender, EventArgs e)
    {
        //YxBtn.SetViewState(divSel);
        ASPxGridView1.DataBind();
    }

    protected void ToNew(object sender, EventArgs e)
    {
        //Response.Redirect("UserInfo_Update.aspx");
    }

    protected void ToDel(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(clsSQLCommond.Online);
        SqlCommand cmd = new SqlCommand();
        SqlTransaction trans;
        con.Open();
        cmd.Connection = con;
        trans = con.BeginTransaction();
        cmd.Transaction = trans;
        string uID = Session["uID"].ToString();
        string sErr = "";
        try
        {
            GridViewDataColumn column1 = ASPxGridView1.Columns["iCheck"] as GridViewDataColumn;

            for (int i = 0; i < ASPxGridView1.VisibleRowCount; i++)
            {
                ASPxCheckBox checkBox = (ASPxCheckBox)ASPxGridView1.FindRowCellTemplateControl(i, column1, "ASPxCheckBox1");
                if (checkBox != null)
                {
                    bool isVisible = checkBox.Checked;
                    if (isVisible == true)
                    {
                        string ID = ASPxGridView1.GetRowValues(i, "vchrRoleID").ToString();

                        if (ID != "")
                        {
                            if (ID == "administrator" || ID == "systemset")
                            {
                                sErr = sErr + "账号" + ID + "为系统账号，不可删除" + "\\n";
                            }
                            else
                            {
                                sSQL = @"delete from _RoleRight where vchrRoleID='" + ID + "'";
                                cmd.CommandText = sSQL;
                                cmd.ExecuteNonQuery();
                                sSQL = @"delete from _UserRoleInfo where vchrRoleID='" + ID + "'";
                                cmd.CommandText = sSQL;
                                cmd.ExecuteNonQuery();
                                sSQL = @"delete from " + tablename + " where vchrRoleID='" + ID + "'";
                                cmd.CommandText = sSQL;
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            if (sErr != "")
            {
                throw new Exception(sErr);
            }
            trans.Commit();
            System.Web.HttpContext.Current.Response.Write("<script>alert('删除成功！');</script>");
            ASPxGridView1.DataBind();

        }
        catch (Exception ee)
        {
            trans.Rollback();
            System.Web.HttpContext.Current.Response.Write("<script>alert('" + ee.Message + "');</script>");
        }
    }

    #region Check
    /// <summary>
    /// 
    /// </summary>
    /// <param name="e"></param>
    /// <param name="b">0 修改 1 新增</param>
    private void GetCheck(System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs e, int b)
    {
        if (e.InputParameters["vchrRoleID"] == null || e.InputParameters["vchrRoleID"].ToString().Trim() == "")
        {
            throw new Exception("权限编码不可为空");
        }
        if (e.InputParameters["vchrRoleText"] == null || e.InputParameters["vchrRoleText"].ToString().Trim() == "")
        {
            throw new Exception("权限名称不可为空");
        }

        //sSQL = "select vchrName from _UserInfo where vchrUid='" + e.InputParameters["vchrUid"].ToString() + "' or vchrName='" + e.InputParameters["vchrName"].ToString() + "'";
        //if (b == 0)
        //{
        //    sSQL = sSQL + " and vchrUid<>'" + e.InputParameters["vchrUid"].ToString() + "'";
        //}
        //DataTable dt = clsSQLCommond.ExecQuery(sSQL);
        //if (dt.Rows.Count > 0)
        //{
        //    throw new Exception("该发票号已经输入");
        //}
    }
    private void GetDelCheck(System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs e)
    {
        //string iID = e.InputParameters["iID"].ToString();
        //string iType = e.InputParameters["iType"].ToString();
        //string iText = e.InputParameters["iText"].ToString();
        //bool bSystem = DataType.BoolParse(e.InputParameters["bSystem"]);

        //if (!sDate.CheckiID(iID, iType))
        //{
        //    throw new Exception("当前类别序号重复");
        //}
        //else if (!sDate.CheckiText(iID, iType, iText))
        //{
        //    throw new Exception("名称重复");
        //}

    }
    #endregion

    #region ObjectDataSource
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        //e.InputParameters["iType"] = ASPxComboBoxLookUpType.Value;
        //e.InputParameters["vchrRoleID"] = ASPxTextBox1.Value;
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "js", "alert('11');", true);

    }

    protected void ObjectDataSource1_Updating(object sender, ObjectDataSourceMethodEventArgs e)
    {
        GetCheck(e, 0);
    }
    protected void ObjectDataSource1_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        GetCheck(e, 1);
    }
    protected void ObjectDataSource1_Deleting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        GetDelCheck(e);
    }

    protected void ObjectDataSource1_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        //WriteResultMsg("刪除", e);
    }
    protected void ObjectDataSource1_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        ASPxGridView1.PageIndex = ASPxGridView1.PageCount;
    }
    protected void ObjectDataSource1_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {

    }

    #endregion

    protected void ASPxGridView1_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
    {
        //string iID = e.NewValues["iID"].ToString();
    }
    protected void ASPxGridView1_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
    {

    }
    protected void ASPxGridView1_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
    {

    }
    protected void ASPxGridView1_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
    {

    }
    protected void ASPxGridView1_RowDeleted(object sender, DevExpress.Web.Data.ASPxDataDeletedEventArgs e)
    {

    }
    protected void ASPxGridView1_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
    {
        //e.Keys["iType"].ToString();
    }

    protected void ASPxGridView1_CellEditorInitialize(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewEditorEventArgs e)
    {
        if (ASPxGridView1.IsNewRowEditing == false && e.Column.FieldName == "vchrRoleID")
        {
            e.Editor.ReadOnly = true;
        }
    }
}