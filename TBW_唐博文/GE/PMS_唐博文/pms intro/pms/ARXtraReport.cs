using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Collections.Generic;

namespace PMMWS
{
    public partial class ARXtraReport : DevExpress.XtraReports.UI.XtraReport
    {
        public ARXtraReport()
        {
            InitializeComponent();

            string year = (System.DateTime.Now.Year - 1).ToString(); 
            IList<MAReport> maReports = MAReport.FindbyTotalandLastYear("1",year);
            IList<SMReport> smReports = SMReport.FindbyTotalandLastYear("1",year);
            IList<HPReport> hpReports = HPReport.FindbyTotalandLastYear("1",year);
            IList<CMReport> cmReports = CMReport.FindbyTotalandLastYear("1",year);
            IList<MAReport> ttReports = MAReport.FindbyTotalandLastYear("2",year);

            if (maReports.Count != 0)
            {
                DataTable dt = commandMethods.ConvertToDataTable<MAReport>(maReports);
                dt.TableName = "MAAVrate";
                this.myDataSet1.Tables.Add(dt);
                this.xrChart1.SeriesDataMember = "MAAVrate.Year";
                this.xrChart1.SeriesTemplate.ArgumentDataMember = "MAAVrate.Weeks";
                this.xrChart1.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "MAAVrate.Rate" });
           
                this.xrChart1.Series[0].Label.Visible = false;
                ((DevExpress.XtraCharts.PointSeriesView)this.xrChart1.Series[0].View).PointMarkerOptions.Size = 5;
                this.xrChart1.Series[1].Label.Visible = false;
                ((DevExpress.XtraCharts.PointSeriesView)this.xrChart1.Series[1].View).PointMarkerOptions.Size = 5;
                
                this.xrChart1.DataSource = this.myDataSet1;

            }
            if (smReports.Count != 0)
            {
                DataTable dt = commandMethods.ConvertToDataTable<SMReport>(smReports);
                dt.TableName = "SMAVrate";
                this.myDataSet1.Tables.Add(dt);
                this.xrChart2.SeriesDataMember = "SMAVrate.IsTotal";
                this.xrChart2.SeriesTemplate.ArgumentDataMember = "SMAVrate.Weeks";
                this.xrChart2.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "SMAVrate.Rate" });
                this.xrChart2.DataSource = this.myDataSet1;
            }
            if (hpReports.Count != 0)
            {
                DataTable dt = commandMethods.ConvertToDataTable<HPReport>(hpReports);
                dt.TableName = "HPAVrate";
                this.myDataSet1.Tables.Add(dt);
                this.xrChart3.SeriesDataMember = "HPAVrate.IsTotal";
                this.xrChart3.SeriesTemplate.ArgumentDataMember = "HPAVrate.Weeks";
                this.xrChart3.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "HPAVrate.Rate" });
                this.xrChart3.DataSource = this.myDataSet1;
            }
            if (cmReports.Count != 0)
            {
                DataTable dt = commandMethods.ConvertToDataTable<CMReport>(cmReports);
                dt.TableName = "CMAVrate";
                this.myDataSet1.Tables.Add(dt);
                this.xrChart4.SeriesDataMember = "CMAVrate.IsTotal";
                this.xrChart4.SeriesTemplate.ArgumentDataMember = "CMAVrate.Weeks";
                this.xrChart4.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "CMAVrate.Rate" });
                this.xrChart4.DataSource = this.myDataSet1;
            }
            if (ttReports.Count != 0)
            {
                DataTable dt = commandMethods.ConvertToDataTable<MAReport>(ttReports);
                dt.TableName = "TTAVrate";
                this.myDataSet1.Tables.Add(dt);
                this.xrChart5.SeriesDataMember = "TTAVrate.IsTotal";
                this.xrChart5.SeriesTemplate.ArgumentDataMember = "TTAVrate.Weeks";
                this.xrChart5.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "TTAVrate.Rate" });
                this.xrChart5.DataSource = this.myDataSet1;
            }


        }



    }
}
