using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMMWS
{
    public partial class ReportView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dBQuery.DBSuzhouInitialize();

            MergingReports();
            
        }

        protected void MergingReports()
        {

            string weeksNum = Session["Monday"].ToString();

            XtraWeekReport report1 = new XtraWeekReport(weeksNum);
            report1.CreateDocument();
            report1.PrintingSystem.ContinuousPageNumbering = true;
            this.ReportViewer1.Report = report1;
            this.ReportViewer1.Report.Name = "机加工区" + weeksNum; 
            this.ReportViewer1.DataBind();
            
            XtraWeekReportAT report2 = new XtraWeekReportAT(weeksNum);
            report2.CreateDocument();
            report2.PrintingSystem.ContinuousPageNumbering = true;
            this.ReportViewer2.Report = report2;
            this.ReportViewer2.DataBind();
            

            XtraWeekReportCM report3 = new XtraWeekReportCM(weeksNum);
            report3.CreateDocument();
            report3.PrintingSystem.ContinuousPageNumbering = true;
            this.ReportViewer3.Report = report3;
            this.ReportViewer3.DataBind();
            
            XtraWeekReportSM report4 = new XtraWeekReportSM(weeksNum);
            report4.CreateDocument();
            report4.PrintingSystem.ContinuousPageNumbering = true;
            this.ReportViewer4.Report = report4;
            this.ReportViewer4.DataBind();
            
            //report1.Pages.AddRange(report2.Pages);
            //report1.Pages.AddRange(report3.Pages);
            //report1.Pages.AddRange(report4.Pages);           



    

        }
    }
}