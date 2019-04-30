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

public partial class Report_Report3 : System.Web.UI.Page
{
    ClsDataBase clsSQLCommond = new ClsDataBase();
    ASPxGridViewShow gridview = new ASPxGridViewShow();
    string sSQL;
    string tablename = "Report";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            YxBtn.HidFormID = "Report3";
            ASPxTextBox1.Value = DateTime.Now.Year.ToString();
            MonthEdit1.Month = DateTime.Now.Month;
            YxBtn.GetViewState(divSel);
            GetTitle();
            ToSelect(null, null);
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
        
        WebChartControl1.Series.Clear();

        int month = 1;
        if (MonthEdit1.Month > 1)
        {
            month = MonthEdit1.Month;
        }

        Series series1 = new Series("发出废料", ViewType.Line);
        series1.Label.Visible = false;
        ReportData rep = new ReportData();
        DataTable dt1 = rep.Report3(ASPxTextBox1.Text.Trim(), 1);
        for (int j = 1; j <= month; j++)
        {
            bool b = false;
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                if (j.ToString() == dt1.Rows[i]["iMonth"].ToString())
                {
                    SeriesPoint point = new SeriesPoint(dt1.Rows[i]["iMonth"].ToString() + "月", dt1.Rows[i]["iQuantity"].ToString());
                    series1.Points.Add(point);
                    b = true;
                }
            }
            if (b == false)
            {
                SeriesPoint point = new SeriesPoint(j.ToString() + "月", 0);
                series1.Points.Add(point);
            }
        }
        WebChartControl1.Series.Add(series1);

        Series series2 = new Series("发出成品", ViewType.Line);
        series2.Label.Visible = false;
        DataTable dt2 = rep.Report3(ASPxTextBox1.Text.Trim(), 2);
        for (int j = 1; j <= month; j++)
        {
            bool b = false;
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                if (j.ToString() == dt2.Rows[i]["iMonth"].ToString())
                {
                    SeriesPoint point = new SeriesPoint(dt2.Rows[i]["iMonth"].ToString() + "月", dt2.Rows[i]["iQuantity"].ToString());
                    series2.Points.Add(point);
                    b = true;
                }
            }
            if (b == false)
            {
                SeriesPoint point = new SeriesPoint(j.ToString() + "月", 0);
                series2.Points.Add(point);
            }
        }
        WebChartControl1.Series.Add(series2);

        Series series3 = new Series("销售订单", ViewType.Line);
        series3.Label.Visible = false;
        DataTable dt3 = rep.Report3(ASPxTextBox1.Text.Trim(), 3);
        for (int j = 1; j <= month; j++)
        {
            bool b = false;
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                if (j.ToString() == dt3.Rows[i]["iMonth"].ToString())
                {
                    SeriesPoint point = new SeriesPoint(dt3.Rows[i]["iMonth"].ToString() + "月", dt3.Rows[i]["iQuantity"].ToString());
                    series3.Points.Add(point);
                    b = true;
                }
            }
            if (b == false)
            {
                SeriesPoint point = new SeriesPoint(j.ToString() + "月", 0);
                series3.Points.Add(point);
            }
        }
        WebChartControl1.Series.Add(series3);
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
        //ASPxGridViewExporter1.WriteXlsxToResponse(YxBtn.Title);
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

}

