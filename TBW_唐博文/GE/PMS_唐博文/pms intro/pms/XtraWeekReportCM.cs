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
    public partial class XtraWeekReportCM : DevExpress.XtraReports.UI.XtraReport
    {
        string weeksNum = "";
        
        public XtraWeekReportCM(string WeeksNum)
        {
            InitializeComponent();

            //XmlDocument xd = new XmlDocument();
            //xd.Load(System.Web.HttpContext.Current.Server.MapPath("WeeksNum.xml"));
            //XmlNodeList xn = xd.GetElementsByTagName("WeeksNum");
            //string weeksNum = xn.Item(0).Attributes[0].Value.ToString();

            weeksNum = WeeksNum;
            IList<CMReport> mars = CMReport.FindbyWeeksNumAndTotal(weeksNum,"3","非停机故障");
            IList<CMPOrder> maps = CMPOrder.FindbyWeeksNum(weeksNum);
 


            
            if (mars.Count != 0)
            {

                DataTable dt = commandMethods.ConvertToDataTable<CMReport>(mars);
                dt.TableName = "CMReport";
                this.myDataSet1.Tables.Add(dt);
                this.xrChart1.SeriesDataMember = dt.TableName + "." + "ReportId";

                this.xrChart1.SeriesTemplate.ArgumentDataMember = dt.TableName + "." + "MachineName";

                this.xrChart1.SeriesTemplate.ValueDataMembers.AddRange(new string[] { dt.TableName + "." + "MTime" });
               
                ((DevExpress.XtraCharts.XYDiagram)this.xrChart1.Diagram).AxisX.Label.Angle = -45;
                this.xrChart1.DataSource = this.myDataSet1;

                this.MachineName.DataBindings.Add("Text", this.myDataSet1, "CMReport.MachineName");
                this.FaultInfo.DataBindings.Add("Text", this.myDataSet1, "CMReport.FaultInfo");
                this.ST.DataBindings.Add("Text", this.myDataSet1, "CMReport.ST");
                this.CT.DataBindings.Add("Text", this.myDataSet1, "CMReport.CT");
                this.MST.DataBindings.Add("Text", this.myDataSet1, "CMReport.MST");
                this.MCT.DataBindings.Add("Text", this.myDataSet1, "CMReport.MCT");
                this.MTime.DataBindings.Add("Text", this.myDataSet1, "CMReport.MTime");
                this.StopTime.DataBindings.Add("Text", this.myDataSet1, "CMReport.StopTime");

                
            }
            if (maps.Count != 0)
            {

                DataTable dt2 = commandMethods.ConvertToDataTable<CMPOrder>(maps);
                dt2.TableName = "CMPReport";

                this.myDataSet1.Tables.Add(dt2);

                this.xrChart2.SeriesDataMember = "CMPReport.WeekNum";
                this.xrChart2.SeriesTemplate.ArgumentDataMember = "CMPReport.FaultType";
                this.xrChart2.SeriesTemplate.PointOptions.PointView = DevExpress.XtraCharts.PointView.ArgumentAndValues;
                this.xrChart2.SeriesTemplate.PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;


                this.xrChart2.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "CMPReport.MTimeP" });
                this.xrChart2.DataSource = this.myDataSet1;
             
            }


           
       
        }

    }
}
