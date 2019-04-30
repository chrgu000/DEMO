using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxClasses;
using System.Data.SqlClient;
using Ajax;

public partial class Invoice_cInvCType : System.Web.UI.Page
{
    ClsDataBase clsSQLCommond = new ClsDataBase();
    ASPxGridViewShow gridview = new ASPxGridViewShow();
    string sSQL;
    string tablename = "cInvCType";
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(PublicAjaxMethod));
        if (!IsPostBack)
        {
            YxBtn.HidFormID = "cInvCType";
            YxBtn.GetViewState(divSel);
            GetTitle();
            ASPxGridView1.DataBind();
            
        }
    }

    #region 标题
    private void GetTitle()
    {
        
    }
    #endregion

    #region 按钮
    protected void ToSelect(object sender, EventArgs e)
    {
        YxBtn.SetViewState(divSel);
        ASPxGridView1.DataBind();
    }

    protected void ToSave(object sender, EventArgs e)
    {

    }

    protected void ToNew(object sender, EventArgs e)
    {
    }

    protected void ToDel(object sender, EventArgs e)
    {

    }

    protected void ToEdit(object sender, EventArgs e)
    {
    }

    protected void ToExport(object sender, EventArgs e)
    {
       
    }

    protected void ToAudit(object sender, EventArgs e)
    {
        
    }

    protected void ToUnAudit(object sender, EventArgs e)
    {
        
    }

    protected void ToClose(object sender, EventArgs e)
    {
        
    }

    protected void ToOpen(object sender, EventArgs e)
    {
        
    }

    protected void ToBeck(object sender, EventArgs e)
    {

    }
    #endregion

    #region Check
    private void GetCheck(System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs e, int b)
    {

    }
    #endregion

    #region ObjectDataSource
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
    }

    protected void ObjectDataSource1_Updating(object sender, ObjectDataSourceMethodEventArgs e)
    {
    }
    protected void ObjectDataSource1_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        GetCheck(e, 1);
    }
    protected void ObjectDataSource1_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        ASPxGridView1.PageIndex = ASPxGridView1.PageCount;
    }
    protected void ObjectDataSource1_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        //WriteResultMsg("刪除", e);
    }

    protected void ObjectDataSource1_Deleting(object sender, ObjectDataSourceMethodEventArgs e)
    {

    }
    #endregion

    protected void ASPxGridView1_CellEditorInitialize(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewEditorEventArgs e)
    {
        //if (ASPxGridView1.IsNewRowEditing)
        //{
        //    e.Editor.ReadOnly = true;
        //}
    }


    protected void ASPxGridView1_PageIndexChanged(object sender, EventArgs e)
    {
        YxBtn.SetViewPage(ASPxGridView1.PageIndex);
    }
    protected void ASPxGridView1_PreRender(object sender, EventArgs e)
    {
        int index = YxBtn.GetViewPage();
        if (index < ASPxGridView1.PageCount)
        {
            ASPxGridView1.PageIndex = index;
        }
        else if (index == 0)
        {

        }
        else
        {
            ASPxGridView1.PageIndex = ASPxGridView1.PageCount;
        }
    }

    private bool IsChange(string ID)
    {

        return true;
    }
}

