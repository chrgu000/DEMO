using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Collections.Generic;
using System.Xml;


namespace PMMWS
{
    public partial class XtraWeekReport : DevExpress.XtraReports.UI.XtraReport
    {
        string weeksNum = "";
        
        public XtraWeekReport(string WeeksNum)
        {
            InitializeComponent();

            //XmlDocument xd = new XmlDocument();
            //xd.Load(System.Web.HttpContext.Current.Server.MapPath("WeeksNum.xml"));
            //XmlNodeList xn = xd.GetElementsByTagName("WeeksNum");
            //string weeksNum = xn.Item(0).Attributes[0].Value.ToString();

            weeksNum = WeeksNum;

            IList<MAReport> mars = MAReport.FindbyWeeksNumAndTotal(weeksNum,"3","非停机故障");
            IList<MAPOrder> maps = MAPOrder.FindbyWeeksNum(weeksNum);

            //IList<HPReport> mars = HPReport.FindbyWeeksNum(weeksNum);
            //IList<HPPOrder> maps = HPPOrder.FindbyWeeksNum(weeksNum);

            if (mars.Count != 0)
            {
                DataTable dt = commandMethods.ConvertToDataTable<MAReport>(mars);
                dt.TableName = "MAReport";

                this.myDataSet1.Tables.Add(dt);

                this.xrChart1.SeriesDataMember = "MAReport.ReportId";
                this.xrChart1.SeriesTemplate.ArgumentDataMember = "MAReport.MachineName";

                this.xrChart1.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "MAReport.MTime" });
                this.xrChart1.DataSource = this.myDataSet1;

                this.MachineName.DataBindings.Add("Text", this.myDataSet1, "MAReport.MachineName");
                this.FaultInfo.DataBindings.Add("Text", this.myDataSet1, "MAReport.FaultType");
                this.ST.DataBindings.Add("Text", this.myDataSet1, "MAReport.ST");
                this.CT.DataBindings.Add("Text", this.myDataSet1, "MAReport.CT");
                this.MST.DataBindings.Add("Text", this.myDataSet1, "MAReport.MST");
                this.MCT.DataBindings.Add("Text", this.myDataSet1, "MAReport.MCT");
                this.MTime.DataBindings.Add("Text", this.myDataSet1, "MAReport.MTime");
                this.StopTime.DataBindings.Add("Text", this.myDataSet1, "MAReport.StopTime");
       
                
            }
            if (maps.Count != 0)
            {
                DataTable dt2 = commandMethods.ConvertToDataTable<MAPOrder>(maps);
                dt2.TableName = "MAPReport";

                this.myDataSet1.Tables.Add(dt2);
                this.xrChart2.SeriesDataMember = "MAPReport.WeekNum";
                this.xrChart2.SeriesTemplate.ArgumentDataMember = "MAPReport.FaultType";
                this.xrChart2.SeriesTemplate.PointOptions.PointView = DevExpress.XtraCharts.PointView.ArgumentAndValues;
                this.xrChart2.SeriesTemplate.PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;

                this.xrChart2.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "MAPReport.MTimeP" });
                this.xrChart2.DataSource = this.myDataSet1;
             
            }

        }

    }
}
