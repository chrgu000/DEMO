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

public partial class Report_Report6 : System.Web.UI.Page
{
    ClsDataBase clsSQLCommond = new ClsDataBase();
    ASPxGridViewShow gridview = new ASPxGridViewShow();
    string sSQL;
    string tablename = "Report";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            YxBtn.HidFormID = "Report6";
            ASPxDateEdit1.Date = DateTime.Parse(DateTime.Now.Year.ToString() + "-01-01");
            ASPxDateEdit2.Date = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
            YxBtn.GetViewState(divSel);
            GetTitle();
            
        }
    }

    #region 标题
    private void GetTitle()
    {
        gridview.GetTitle(ASPxGridView1, tablename);
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
        ASPxGridViewExporter1.WriteXlsxToResponse(YxBtn.Title);
    }

    protected void ToAudit(object sender, EventArgs e)
    {

    }

    protected void ToUnAudit(object sender, EventArgs e)
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
        e.InputParameters["sDate"] = ASPxDateEdit1.Text;
        e.InputParameters["eDate"] = ASPxDateEdit2.Text;
        e.InputParameters["cInvCName"] = ASPxButtonEditcInv.Text;
    }

    protected void ObjectDataSource1_Updating(object sender, ObjectDataSourceMethodEventArgs e)
    {
        GetCheck(e, 0);
    }
    protected void ObjectDataSource1_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        GetCheck(e, 1);
    }
    protected void ObjectDataSource1_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
    {

    }
    protected void ObjectDataSource1_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        //WriteResultMsg("刪除", e);
    }
    #endregion

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
    protected void ASPxGridView1_DataBound(object sender, EventArgs e)
    {
        GridViewDataTextColumn col = new GridViewDataTextColumn();
        ASPxGridView1.Columns.Add(col);
    }
}

