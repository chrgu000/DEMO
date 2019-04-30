using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DevExpress.XtraPrinting;
using DevExpress.XtraCharts.Native;
using DevExpress.XtraPrintingLinks;
using System.IO;

namespace PMMWS
{
    public partial class WeekARate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            dBQuery.DBSuzhouInitialize();

            string year =  (System.DateTime.Now.Year - 1).ToString();    
         
                IList<MAReport> maReports = MAReport.FindbyTotalandLastYear("1",year);
                IList<SMReport> smReports = SMReport.FindbyTotalandLastYear("1", year);
                IList<HPReport> hpReports = HPReport.FindbyTotalandLastYear("1", year);
                IList<CMReport> cmReports = CMReport.FindbyTotalandLastYear("1", year);



                IList<MAReport> ttReports = MAReport.FindbyTotalandLastYear("2", year);
                
                if (maReports.Count != 0)
                {
                    DataTable dt = commandMethods.ConvertToDataTable<MAReport>(maReports);
                    dt.TableName = "MAAVrate";
                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    this.WebChartControl1.SeriesDataMember = "Year";
                    this.WebChartControl1.SeriesTemplate.ArgumentDataMember = "Week";
                    this.WebChartControl1.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Rate" });
                    this.WebChartControl1.DataSource = ds;
                    this.WebChartControl1.DataBind();
                    this.WebChartControl1.Series[0].Label.Visible = false;
                    ((DevExpress.XtraCharts.PointSeriesView)this.WebChartControl1.Series[0].View).PointMarkerOptions.Size = 5;
                    this.WebChartControl1.Series[1].Label.Visible = false;
                    ((DevExpress.XtraCharts.PointSeriesView)this.WebChartControl1.Series[1].View).PointMarkerOptions.Size = 5;
                    this.WebChartControl1.Series[2].Label.Visible = false;
                }
                if (smReports.Count != 0)
                {
                    DataTable dt = commandMethods.ConvertToDataTable<SMReport>(smReports);
                    dt.TableName = "SMVrate";
                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    this.WebChartControl2.SeriesDataMember = "Year";
                    this.WebChartControl2.SeriesTemplate.ArgumentDataMember = "Week";
                    this.WebChartControl2.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Rate" });
                    this.WebChartControl2.DataSource = ds;
                    this.WebChartControl2.DataBind();
                    this.WebChartControl2.Series[0].Label.Visible = false;
                    ((DevExpress.XtraCharts.PointSeriesView)this.WebChartControl2.Series[0].View).PointMarkerOptions.Size = 5;
                    this.WebChartControl2.Series[1].Label.Visible = false;
                    ((DevExpress.XtraCharts.PointSeriesView)this.WebChartControl2.Series[1].View).PointMarkerOptions.Size = 5;
                    this.WebChartControl2.Series[2].Label.Visible = false;
                }
                if (cmReports.Count != 0)
                {
                    DataTable dt = commandMethods.ConvertToDataTable<CMReport>(cmReports);
                    dt.TableName = "CMVrate";
                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    this.WebChartControl3.SeriesDataMember = "Year";
                    this.WebChartControl3.SeriesTemplate.ArgumentDataMember = "Week";
                    this.WebChartControl3.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Rate" });
                    this.WebChartControl3.DataSource = ds;
                    this.WebChartControl3.DataBind();
                    this.WebChartControl3.Series[0].Label.Visible = false;
                    ((DevExpress.XtraCharts.PointSeriesView)this.WebChartControl3.Series[0].View).PointMarkerOptions.Size = 5;
                    this.WebChartControl3.Series[1].Label.Visible = false;
                    ((DevExpress.XtraCharts.PointSeriesView)this.WebChartControl3.Series[1].View).PointMarkerOptions.Size = 5;
                    this.WebChartControl3.Series[2].Label.Visible = false;
                }
                if (hpReports.Count != 0)
                {
                    DataTable dt = commandMethods.ConvertToDataTable<HPReport>(hpReports);
                    dt.TableName = "HPVrate";
                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    this.WebChartControl4.SeriesDataMember = "Year";
                    this.WebChartControl4.SeriesTemplate.ArgumentDataMember = "Week";
                    this.WebChartControl4.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Rate" });
                    this.WebChartControl4.DataSource = ds;
                    this.WebChartControl4.DataBind();
                    this.WebChartControl4.Series[0].Label.Visible = false;
                    ((DevExpress.XtraCharts.PointSeriesView)this.WebChartControl4.Series[0].View).PointMarkerOptions.Size = 5;
                    this.WebChartControl4.Series[1].Label.Visible = false;
                    ((DevExpress.XtraCharts.PointSeriesView)this.WebChartControl4.Series[1].View).PointMarkerOptions.Size = 5;
                    this.WebChartControl4.Series[2].Label.Visible = false;
                }

                if (ttReports.Count != 0)
                {
                    DataTable dt = commandMethods.ConvertToDataTable<MAReport>(ttReports);
                    dt.TableName = "TTVrate";
                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    this.WebChartControl5.SeriesDataMember = "Year";
                    this.WebChartControl5.SeriesTemplate.ArgumentDataMember = "Week";
                    this.WebChartControl5.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Rate" });
                    this.WebChartControl5.DataSource = ds;
                    this.WebChartControl5.DataBind();
                    this.WebChartControl5.Series[0].Label.Visible = false;
                    ((DevExpress.XtraCharts.PointSeriesView)this.WebChartControl5.Series[0].View).PointMarkerOptions.Size = 5;
                    this.WebChartControl5.Series[1].Label.Visible = false;
                    ((DevExpress.XtraCharts.PointSeriesView)this.WebChartControl5.Series[1].View).PointMarkerOptions.Size = 5;
                    this.WebChartControl5.Series[2].Label.Visible = false;
                }

                IList<MAReport> mas = MAReport.FindbyTotalandYear("1",System.DateTime.Now.Year.ToString());
                this.ASPxGridView1.DataSource = mas;
                this.ASPxGridView1.DataBind();


                IList<SMReport> sms = SMReport.FindbyTotalandYear("1", System.DateTime.Now.Year.ToString());
                this.ASPxGridView2.DataSource = sms;
                this.ASPxGridView2.DataBind();

                IList<HPReport> hps = HPReport.FindbyTotalandYear("1",System.DateTime.Now.Year.ToString());
                this.ASPxGridView4.DataSource = hps;
                this.ASPxGridView4.DataBind();

                IList<CMReport> cms = CMReport.FindbyTotalandYear("1", System.DateTime.Now.Year.ToString());
                this.ASPxGridView3.DataSource = cms;
                this.ASPxGridView3.DataBind();
                 
            
        }

        protected void ASPxButton1_Click1(object sender, EventArgs e)
        {
           
            PrintingSystem ps = new PrintingSystem();
            PrintableComponentLink link1 = new PrintableComponentLink();
            link1.Component = ((IChartContainer)WebChartControl1).Chart;
            link1.PrintingSystem = ps;

            PrintableComponentLink link2 = new PrintableComponentLink();
            link2.Component = ((IChartContainer)WebChartControl2).Chart;
            link2.PrintingSystem = ps;

            PrintableComponentLink link3 = new PrintableComponentLink();
            link3.Component = ((IChartContainer)WebChartControl3).Chart;
            link3.PrintingSystem = ps;

            PrintableComponentLink link4 = new PrintableComponentLink();
            link4.Component = ((IChartContainer)WebChartControl4).Chart;
            link4.PrintingSystem = ps;

            PrintableComponentLink link5 = new PrintableComponentLink();
            link5.Component = ((IChartContainer)WebChartControl5).Chart;
            link5.PrintingSystem = ps;

            CompositeLink cLink = new CompositeLink();
            cLink.Links.AddRange(new object[] { link1, link2, link3, link4, link5 });
            cLink.PrintingSystem = ps;

            cLink.CreateDocument();

            using (MemoryStream stream = new MemoryStream()) {
                cLink.PrintingSystem.ExportToXls(stream);
                Response.Clear();
                Response.Buffer = false;
                Response.AppendHeader("Content-Type", "application/excel");
                Response.AppendHeader("Content-Transfer-Encoding","binary");
                Response.AppendHeader("Content-Disposition","attachment;filename=test.xls");
                Response.BinaryWrite(stream.GetBuffer());
                Response.End();
            }
            ps.Dispose();


        }

        protected void ASPxButton2_Click(object sender, EventArgs e)
        {
            PrintingSystem ps = new PrintingSystem();

            PrintableComponentLink link1 = new PrintableComponentLink(ps);
            link1.Component = this.ASPxGridViewExporter1;

            PrintableComponentLink link2 = new PrintableComponentLink(ps);
            link2.Component = this.ASPxGridViewExporter2;

            PrintableComponentLink link3 = new PrintableComponentLink(ps);
            link3.Component = this.ASPxGridViewExporter3;

            PrintableComponentLink link4 = new PrintableComponentLink(ps);
            link4.Component = this.ASPxGridViewExporter4;

            CompositeLink compositeLink = new CompositeLink(ps);
            compositeLink.Links.AddRange(new object[] { link1, link2 ,link3, link4 });

            compositeLink.CreateDocument();
            using (MemoryStream stream = new MemoryStream())
            {
                compositeLink.PrintingSystem.ExportToXls(stream);
                WriteToResponse("filename", true, "xls", stream);
            }
            ps.Dispose();
        }

        void WriteToResponse(string fileName, bool saveAsFile, string fileFormat, MemoryStream stream)
        {
            if (Page == null || Page.Response == null)
                return;
            string disposition = saveAsFile ? "attachment" : "inline";
            Page.Response.Clear();
            Page.Response.Buffer = false;
            Page.Response.AppendHeader("Content-Type", string.Format("application/{0}", fileFormat));
            Page.Response.AppendHeader("Content-Transfer-Encoding", "binary");
            Page.Response.AppendHeader("Content-Disposition",
                string.Format("{0}; filename={1}.{2}", disposition, fileName, fileFormat));
            Page.Response.BinaryWrite(stream.GetBuffer());
            Page.Response.End();
        }

    }
}