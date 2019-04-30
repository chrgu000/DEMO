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

public partial class Report_Report5 : System.Web.UI.Page
{
    ClsDataBase clsSQLCommond = new ClsDataBase();
    ASPxGridViewShow gridview = new ASPxGridViewShow();
    string sSQL;
    string tablename = "Report";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            YxBtn.HidFormID = "Report5";
            ASPxTextBox1.Value = DateTime.Now.Year.ToString();
            ASPxTextBox2.Value = DateTime.Now.Year.ToString();
            MonthEdit1.Month = DateTime.Now.AddMonths(-1).Month;
            MonthEdit2.Month = DateTime.Now.Month;
            if (MonthEdit2.Month == 1)
            {
                ASPxTextBox1.Value = DateTime.Now.AddYears(-1).Year.ToString();
            }
            YxBtn.GetViewState(divSel);
            GetTitle();
        }
    }

    #region 标题
    private void GetTitle()
    {
        gridview.GetTitle(ASPxGridView1, tablename);
        ReportData rep = new ReportData();
        DataTable dt = rep.Report5_1();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            GridViewDataTextColumn col = new GridViewDataTextColumn();
            col.FieldName = dt.Rows[i]["cInvCName"].ToString();
            col.Caption = dt.Rows[i]["cInvCName"].ToString();
            ASPxGridView1.Columns.Add(col);

            ASPxSummaryItem sum = new ASPxSummaryItem();
            sum.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            sum.FieldName = dt.Rows[i]["cInvCName"].ToString();
            sum.DisplayFormat = "{0,2}";
            ASPxGridView1.TotalSummary.Add(sum);

            //ASPxSummaryItem sum = new ASPxSummaryItem();
            //sum.FieldName = dt.Rows[i]["cInvCName"].ToString();
            //sum.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            //ASPxGridView1.TotalSummary.Add(sum);
        }
        //GridViewDataTextColumn col1 = new GridViewDataTextColumn();
        //col1.FieldName = "合计";
        //col1.Caption = "合计";
        //ASPxGridView1.Columns.Add(col1);

        //GridViewDataTextColumn col2 = new GridViewDataTextColumn();
        //col2.FieldName = "百分比";
        //col2.Caption = "百分比";
        //ASPxGridView1.Columns.Add(col2);
    }
    #endregion

    #region 按钮
    protected void ToSelect(object sender, EventArgs e)
    {
        YxBtn.SetViewState(divSel);
        ASPxGridView1.DataBind();
        //for (int i = ASPxGridView1.TotalSummary.Count - 1; i >= 0; i--)
        //{
        //    if (ASPxButtonEditcInv.Text.Trim() == "")
        //    {
        //        ASPxGridView1.Columns[ASPxGridView1.TotalSummary[i].FieldName].Visible = true;
        //    }
        //    else
        //    {
        //        if (ASPxGridView1.TotalSummary[i].FieldName == ASPxButtonEditcInv.Text.Trim())
        //        {
        //            ASPxGridView1.Columns[ASPxGridView1.TotalSummary[i].FieldName].Visible = true;
        //        }
        //        else
        //        {
        //            ASPxGridView1.Columns[ASPxGridView1.TotalSummary[i].FieldName].Visible = false;
        //        }
        //    }
        //}
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
        e.InputParameters["Year1"] = ASPxTextBox1.Text;
        e.InputParameters["Year2"] = ASPxTextBox2.Text;
        //e.InputParameters["cCusCode"] = ASPxTextBox3.Text;
        //e.InputParameters["cInvCName"] = ASPxButtonEditcInv.Text;
        e.InputParameters["Month1"] = MonthEdit1.Month;
        e.InputParameters["Month2"] = MonthEdit2.Month;
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

