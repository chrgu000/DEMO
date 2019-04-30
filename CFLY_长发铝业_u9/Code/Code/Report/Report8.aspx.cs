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
using DevExpress.XtraCharts;
using System.Drawing;

public partial class Report_Report8 : System.Web.UI.Page
{
    ClsDataBase clsSQLCommond = new ClsDataBase();
    ASPxGridViewShow gridview = new ASPxGridViewShow();
    string sSQL;
    string tablename = "Report";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            YxBtn.HidFormID = "Report8";
            ASPxDateEdit1.Date = DateTime.Parse(DateTime.Now.AddMonths(-1).ToString("yyyy-MM") + "-01");
            ASPxDateEdit2.Date = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
            YxBtn.GetViewState(divSel);
            ToSelect(null, null);
            GetTitle();
        }
    }

    #region 标题
    private void GetTitle()
    {
        //gridview.GetTitle(ASPxGridView1, tablename);
    }
    #endregion

    #region 按钮
    protected void ToSelect(object sender, EventArgs e)
    {
        YxBtn.SetViewState(divSel);
        ASPxGridView1.DataBind();
        WebChartControl1.Series.Clear();
        ReportData rep = new ReportData();
        DataTable dt = rep.Report8(ASPxDateEdit1.Text, ASPxDateEdit2.Text);
        WebChartControl1.Series.Clear();

        Series series1 = new Series("数量", ViewType.Bar);
        series1.Label.Visible = false;
        //Series series2 = new Series("金额", ViewType.Bar);
        //series2.Label.Visible = false;
        for (int i = 0; i < dt.Rows.Count && i < 15; i++)
        {
            SeriesPoint point1 = new SeriesPoint(dt.Rows[i]["cCusName"].ToString(), dt.Rows[i]["iQuantity"].ToString());
            series1.Points.Add(point1);
            //SeriesPoint point = new SeriesPoint(dt.Rows[i]["cCusName"].ToString(), dt.Rows[i]["iMoney"].ToString());
            //series2.Points.Add(point);
        }
        

        WebChartControl1.Series.Add(series1);
        //WebChartControl1.Series.Add(series2);
        ((XYDiagram)WebChartControl1.Diagram).AxisX.Label.Angle = 330;
        //Series Series1 = new Series("当年数据", ViewType.Bar);
        //Series1.DataSource = data;
        //Series1.ArgumentScaleType = ScaleType.Qualitative;
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

    //protected void ASPxGridView1_PageIndexChanged(object sender, EventArgs e)
    //{
    //    YxBtn.SetViewPage(ASPxGridView1.PageIndex);
    //}
    //protected void ASPxGridView1_PreRender(object sender, EventArgs e)
    //{
    //    int index = YxBtn.GetViewPage();
    //    if (index < ASPxGridView1.PageCount)
    //    {
    //        ASPxGridView1.PageIndex = index;
    //    }
    //    else if (index == 0)
    //    {

    //    }
    //    else
    //    {
    //        ASPxGridView1.PageIndex = ASPxGridView1.PageCount;
    //    }
    //}
}

