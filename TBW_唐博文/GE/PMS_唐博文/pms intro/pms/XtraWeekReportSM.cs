﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Collections.Generic;
using System.Xml;


namespace PMMWS
{
    public partial class XtraWeekReportSM : DevExpress.XtraReports.UI.XtraReport
    {
        string weeksNum = "";
        
        public XtraWeekReportSM(string WeeksNum)
        {
            InitializeComponent();

            //XmlDocument xd = new XmlDocument();
            //xd.Load(System.Web.HttpContext.Current.Server.MapPath("WeeksNum.xml"));
            //XmlNodeList xn = xd.GetElementsByTagName("WeeksNum");
            //string weeksNum = xn.Item(0).Attributes[0].Value.ToString();

            weeksNum = WeeksNum;


            IList<SMReport> mars = SMReport.FindbyWeeksNumAndTotal(weeksNum,"3","非停机故障");
            IList<SMPOrder> maps = SMPOrder.FindbyWeeksNum(weeksNum);



            
            if (mars.Count != 0)
            {

                DataTable dt = commandMethods.ConvertToDataTable<SMReport>(mars);
                dt.TableName = "SMReport";
                this.myDataSet1.Tables.Add(dt);

                this.xrChart1.SeriesDataMember = dt.TableName + "." + "ReportId";

                this.xrChart1.SeriesTemplate.ArgumentDataMember = dt.TableName + "." + "MachineName";

                ((DevExpress.XtraCharts.XYDiagram)this.xrChart1.Diagram).AxisX.Label.Angle = -45;

                this.xrChart1.SeriesTemplate.ValueDataMembers.AddRange(new string[] { dt.TableName + "." + "MTime" });
                this.xrChart1.DataSource = this.myDataSet1;
                this.MachineName.DataBindings.Add("Text", this.myDataSet1, "SMReport.MachineName");
                this.FaultInfo.DataBindings.Add("Text", this.myDataSet1, "SMReport.FaultInfo");
                this.ST.DataBindings.Add("Text", this.myDataSet1, "SMReport.ST");
                this.CT.DataBindings.Add("Text", this.myDataSet1, "SMReport.CT");
                this.MST.DataBindings.Add("Text", this.myDataSet1, "SMReport.MST");
                this.MCT.DataBindings.Add("Text", this.myDataSet1, "SMReport.MCT");
                this.MTime.DataBindings.Add("Text", this.myDataSet1, "SMReport.MTime");
                this.StopTime.DataBindings.Add("Text", this.myDataSet1, "SMReport.StopTime");
                
            }
            if (maps.Count != 0)
            {
                DataTable dt2 = commandMethods.ConvertToDataTable<SMPOrder>(maps);
                dt2.TableName = "SMPOrder";

                this.myDataSet1.Tables.Add(dt2);
                this.xrChart2.SeriesDataMember = "SMPOrder.WeekNum";
                this.xrChart2.SeriesTemplate.ArgumentDataMember = "SMPOrder.FaultType";
                this.xrChart2.SeriesTemplate.PointOptions.PointView = DevExpress.XtraCharts.PointView.ArgumentAndValues;
                this.xrChart2.SeriesTemplate.PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;

                this.xrChart2.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "SMPOrder.MTimeP" });
                this.xrChart2.DataSource = this.myDataSet1;
            }


           
       
        }

    }
}
