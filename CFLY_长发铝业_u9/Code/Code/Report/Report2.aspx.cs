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

public partial class Report_Report2 : System.Web.UI.Page
{
    ClsDataBase clsSQLCommond = new ClsDataBase();
    ASPxGridViewShow gridview = new ASPxGridViewShow();
    string sSQL;
    string tablename = "Report";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            YxBtn.HidFormID = "Report2";
            ASPxDateEdit1.Date = DateTime.Parse(DateTime.Now.Year.ToString() + "-01-01");
            ASPxDateEdit2.Date = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
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
        ReportData rep = new ReportData();
        DataTable dt = rep.Report2(ASPxDateEdit1.Text, ASPxDateEdit2.Text);
        WebChartControl1.Series.Clear();
        
        Series series1 = new Series("", ViewType.Line);
        series1.Label.Visible = false;
        for (int j = ASPxDateEdit1.Date.Month; j <= ASPxDateEdit2.Date.Month; j++)
        {
            bool b = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (j.ToString() == dt.Rows[i]["iMonth"].ToString())
                {
                    SeriesPoint point = new SeriesPoint(dt.Rows[i]["iMonth"].ToString() + "月", dt.Rows[i]["iQuantity"].ToString());
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

