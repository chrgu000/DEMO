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

public partial class System_LookUpDataIndex : System.Web.UI.Page
{
    ClsDataBase clsSQLCommond = new ClsDataBase();
    ASPxGridViewShow gridview = new ASPxGridViewShow();
    string sSQL;
    LookUpDataData sDate = new LookUpDataData();
    string tablename = "_LookUpDate";
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            YxBtn.HidFormID = "FrmLookUpDataList";
            if (ASPxComboBoxLookUpType.Value == null)
            {
                ASPxComboBoxLookUpType.Value = "1";
            }
            YxBtn.GetViewState(divSel);

            GetTitle();
            //GetGrid();
            
        }
    }

    #region 标题
    private void GetTitle()
    {
    }

    #endregion

    #region 按钮

    private void GetGrid()
    {
        LookUpDataData look = new LookUpDataData();
        DataTable dt = look.Get(ASPxComboBoxLookUpType.Value.ToString());
        ViewState["dtGridBind"] = dt;
        YxBtn.SetViewState(divSel);
        ASPxGridView1.DataSource = dt;
        ASPxGridView1.DataBind();
    }
    protected void ToSelect(object sender, EventArgs e)
    {
        //GetGrid();
        ASPxGridView1.DataBind();
    }

    protected void ToSave(object sender, EventArgs e)
    {

    }

    protected void ToNew(object sender, EventArgs e)
    {
        //DataTable dt = (DataTable)ViewState["dtGridBind"];
        
        //ASPxGridView1.DataSource = dt;
        //ASPxGridView1.DataBind();
        //ASPxGridView1.AddNewRow();
        
    }

    protected void ToDel(object sender, EventArgs e)
    {
        int iRow = ASPxGridView1.FocusedRowIndex;
        string iID = ASPxGridView1.GetRowValues(iRow, "iID").ToString();
        string iType = ASPxGridView1.GetRowValues(iRow, "iType").ToString();
        sSQL = "delete from _LookUpDate where iID='" + iID + "' and iType='" + iType + "'";
        clsSQLCommond.Update(sSQL);
        ASPxGridView1.DataBind();
    }

    protected void ToExport(object sender, EventArgs e)
    {
        //ASPxGridViewExporter1.WriteXlsToResponse(this.Title);
    }

    protected void ToBeck(object sender, EventArgs e)
    {
        Response.Redirect("LookUpData_Index.aspx");
    }
    #endregion

    #region Check
    /// <summary>
    /// 
    /// </summary>
    /// <param name="e"></param>
    /// <param name="b">0 修改 1 新增</param>
    private void GetCheck(System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs e, int b)
    {
        string iID = e.InputParameters["iID"].ToString();
        string iType = e.InputParameters["iType"].ToString();
        string iText = e.InputParameters["iText"].ToString();
        if (gridview.ParameterIsNull(iID))
        {
            throw new Exception("序号不可为空");
        }
        if (gridview.ParameterIsNull(iType))
        {
            throw new Exception("类别不可为空");
        }
        if (gridview.ParameterIsNull(iText))
        {
            throw new Exception("内容不可为空");
        }
        if (b == 1)
        {
            if (!sDate.CheckiID(iID, iType))
            {
                throw new Exception("当前类别序号重复");
            }
            else if (!sDate.CheckiText(iID, iType, iText))
            {
                throw new Exception("名称重复");
            }
        }
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
        e.InputParameters["iType"] = ASPxComboBoxLookUpType.Value;
        //e.InputParameters["eDate1"] = ASPxDateEdit2.Value;
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

    }
    protected void ObjectDataSource1_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {

    }
    
    #endregion

    protected void ASPxGridView1_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
    {
        string iID=e.NewValues["iID"].ToString();
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
}

