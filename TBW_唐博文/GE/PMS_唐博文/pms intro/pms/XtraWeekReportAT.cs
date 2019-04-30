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
    public partial class XtraWeekReportAT : DevExpress.XtraReports.UI.XtraReport
    {
        string weeksNum = "";
        
        public XtraWeekReportAT(string WeeksNum)
        {
            InitializeComponent();

            //XmlDocument xd = new XmlDocument();
            //xd.Load(System.Web.HttpContext.Current.Server.MapPath("WeeksNum.xml"));
            //XmlNodeList xn = xd.GetElementsByTagName("WeeksNum");
            //string weeksNum = xn.Item(0).Attributes[0].Value.ToString();

            weeksNum = WeeksNum; 
            
            //IList<MAReport> mars = MAReport.FindbyWeeksNum(weeksNum);
            //IList<MAPOrder> maps = MAPOrder.FindbyWeeksNum(weeksNum);

            IList<HPReport> mars = HPReport.FindbyWeeksNumAndTotal(weeksNum,"3","非停机故障");
            IList<HPPOrder> maps = HPPOrder.FindbyWeeksNum(weeksNum);

            if (mars.Count != 0)
            {
                
                DataTable dt = commandMethods.ConvertToDataTable<HPReport>(mars);
                dt.TableName = "HPReport";

                this.myDataSet1.Tables.Add(dt);

                this.xrChart1.SeriesDataMember = dt.TableName + "." + "ReportId";
                this.xrChart1.SeriesTemplate.ArgumentDataMember = dt.TableName + "." + "MachineName";
                
                ((DevExpress.XtraCharts.XYDiagram)this.xrChart1.Diagram).AxisX.Label.Angle = -45;
                
                this.xrChart1.SeriesTemplate.ValueDataMembers.AddRange(new string[] { dt.TableName + "." + "MTime" });
                this.xrChart1.DataSource = this.myDataSet1;

             
                  
                   
                this.MachineName.DataBindings.Add("Text", this.myDataSet1, "HPReport.MachineName");
                this.FaultInfo.DataBindings.Add("Text", this.myDataSet1, "HPReport.FaultInfo");
                this.ST.DataBindings.Add("Text", this.myDataSet1, "HPReport.ST");
                this.CT.DataBindings.Add("Text", this.myDataSet1, "HPReport.CT");
                this.MST.DataBindings.Add("Text", this.myDataSet1, "HPReport.MST");
                this.MCT.DataBindings.Add("Text", this.myDataSet1, "HPReport.MCT");
                this.MTime.DataBindings.Add("Text", this.myDataSet1, "HPReport.MTime");
                this.StopTime.DataBindings.Add("Text", this.myDataSet1, "HPReport.StopTime");  
        
                
            }
            if (maps.Count != 0)
            {
           DataTable dt2 = commandMethods.ConvertToDataTable<HPPOrder>(maps);
                dt2.TableName = "HPPReport";

                this.myDataSet1.Tables.Add(dt2);
                this.xrChart2.SeriesDataMember = "HPPReport.WeekNum";

                this.xrChart2.SeriesTemplate.ArgumentDataMember = "HPPReport.FaultType";
                this.xrChart2.SeriesTemplate.PointOptions.PointView = DevExpress.XtraCharts.PointView.ArgumentAndValues;
                this.xrChart2.SeriesTemplate.PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;
                this.xrChart2.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "HPPReport.MTimeP" });
                this.xrChart2.DataSource = this.myDataSet1;
             
            }


           
       
        }

    }
}
