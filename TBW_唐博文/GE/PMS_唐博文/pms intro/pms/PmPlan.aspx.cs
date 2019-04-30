using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

namespace PMMWS
{
    public partial class PmPlan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dBQuery.DBSuzhouInitialize();
 
            string Year = System.DateTime.Now.Year.ToString();
            IList<PMSPMPlan> pmplans = PMSPMPlan.FindbyYear(Year);
            this.grid.DataSource = pmplans;
            this.grid.DataBind();
           
            int month = System.DateTime.Now.Month;
            string method = "FMonth" + month.ToString();

            DataTable pms = dBQuery.GetReflectionResult("PMMWS.PMSPMPlan",method, Year);
            this.grid0.DataSource = pms;
            this.grid0.DataBind();
            this.grid0.Columns[month.ToString() + "月"].Visible = true;

            int date = commandMethods.GetMonthLastDate(System.DateTime.Now.Year, System.DateTime.Now.Month);

            if (System.DateTime.Now.Day >= (date-7))
            {
                this.ASPxPanel1.Visible = true;
                int month1 = System.DateTime.Now.Month + 1;
                string method1 = "FMonth" + month1.ToString();
                DataTable pms1 = dBQuery.GetReflectionResult("PMMWS.PMSPMPlan", method1, Year);
                this.grid1.DataSource = pms1;
                this.grid1.DataBind();
                this.grid1.Columns[month1.ToString() + "月"].Visible = true;
            }
        }

        protected void grid_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            int id = Convert.ToInt32(e.Keys["PMPlanId"].ToString());

            PMSPMPlan pmPlan = PMSPMPlan.Find(id);

            try
            {

                if (e.NewValues["Number"] != null)
                {
                    pmPlan.Number = Convert.ToInt32(e.NewValues["Number"].ToString());
                }
                if (e.NewValues["MachineName"] != null)
                {
                    pmPlan.MachineName = e.NewValues["MachineName"].ToString();
                }
                
                if (e.NewValues["MachineType"] != null)
                {
                    pmPlan.MachineType = e.NewValues["MachineType"].ToString();
                }
                if (e.NewValues["Equipments"] != null)
                {
                    pmPlan.Equipments = e.NewValues["Equipments"].ToString();
                }
                if (e.NewValues["Month1"] != null)
                {
                    pmPlan.Month1 = e.NewValues["Month1"].ToString();
                }
                else
                {
                    pmPlan.Month1 = "";
                }
                if (e.NewValues["Month2"] != null)
                {
                    pmPlan.Month2 = e.NewValues["Month2"].ToString();
                }
                else
                {
                    pmPlan.Month2 = "";
                }
                if (e.NewValues["Month3"] != null)
                {
                    pmPlan.Month3 = e.NewValues["Month3"].ToString();
                }
                else
                {
                    pmPlan.Month3 = "";
                }
                if (e.NewValues["Month4"] != null)
                {
                    pmPlan.Month4 = e.NewValues["Month4"].ToString();
                }
                else
                {
                    pmPlan.Month4 = "";
                }
                if (e.NewValues["Month5"] != null)
                {
                    pmPlan.Month5 = e.NewValues["Month5"].ToString();
                }
                else
                {
                    pmPlan.Month5 = "";
                }
                if (e.NewValues["Month6"] != null)
                {
                    pmPlan.Month6 = e.NewValues["Month6"].ToString();
                }
                else
                {
                    pmPlan.Month6 = "";
                }
                if (e.NewValues["Month7"] != null)
                {
                    pmPlan.Month7 = e.NewValues["Month7"].ToString();
                }
                else
                {
                    pmPlan.Month7 = "";
                }
                if (e.NewValues["Month8"] != null)
                {
                    pmPlan.Month8 = e.NewValues["Month8"].ToString();
                }
                else
                {
                    pmPlan.Month8 = "";
                }
                if (e.NewValues["Month9"] != null)
                {
                    pmPlan.Month9 = e.NewValues["Month9"].ToString();
                }
                else
                {
                    pmPlan.Month9 = "";
                }
                if (e.NewValues["Month10"] != null)
                {
                    pmPlan.Month10 = e.NewValues["Month10"].ToString();
                }
                else
                {
                    pmPlan.Month10 = "";
                }
                if (e.NewValues["Month11"] != null)
                {
                    pmPlan.Month11 = e.NewValues["Month11"].ToString();
                }
                else
                {
                    pmPlan.Month11 = "";
                }
                if (e.NewValues["Month12"] != null)
                {
                    pmPlan.Month12 = e.NewValues["Month12"].ToString();
                }
                else
                {
                    pmPlan.Month12 = "";
                }
                if (e.NewValues["Year"] != null)
                {
                    pmPlan.Year = e.NewValues["Year"].ToString();
                }
                

                pmPlan.Update();
            }
            catch
            {

            }

            e.Cancel = true;
            this.grid.CancelEdit();
            performCallBack();    
        }

        private void performCallBack()
        {

            string Year = System.DateTime.Now.Year.ToString();
            IList<PMSPMPlan> pmplans = PMSPMPlan.FindbyYear(Year);
            this.grid.DataSource = pmplans;
            this.grid.DataBind();
        }

        private void performCallBack1()
        {

            int month = System.DateTime.Now.Month;
            string method = "FMonth" + month.ToString();
            string Year = System.DateTime.Now.Year.ToString();

            DataTable pms = dBQuery.GetReflectionResult("PMMWS.PMSPMPlan",method, Year);
            this.grid0.DataSource = pms;
            this.grid0.DataBind();
            this.grid0.Columns[month + 4].Visible = true;
        }



        private void performCallBack2()
        {

            int month1 = System.DateTime.Now.Month + 1;
            string method1 = "FMonth" + month1.ToString();
            string Year = System.DateTime.Now.Year.ToString();

            DataTable pms1 = dBQuery.GetReflectionResult("PMMWS.PMSPMPlan", method1, Year);
            this.grid1.DataSource = pms1;
            this.grid1.DataBind();
            this.grid1.Columns[month1 + 4].Visible = true;
        }


        protected void ASPxButton2_Click(object sender, EventArgs e)
        {
            this.ASPxGridViewExporter1.WriteXlsToResponse();
        }

        protected void ASPxButton3_Click(object sender, EventArgs e)
        {
            if (this.ASPxTextBox1.Text == ConfigurationSettings.AppSettings["PlanAdmin"].ToString())
            {
                this.grid.Columns[0].Visible = true;
                this.grid0.Columns[0].Visible = true;
            }

        }

        protected void ASPxButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("PmContents.aspx");
        }

        protected void grid0_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            int id = Convert.ToInt32(e.Keys["PMPlanId"].ToString());

            PMSPMPlan pmPlan = PMSPMPlan.Find(id);

            if (e.NewValues["IsDown"] != null)
            {
                pmPlan.IsDown = Convert.ToBoolean(e.NewValues["IsDown"]);
                if (pmPlan.IsDown == true)
                { 
                    //reflect the F + Month; 
                   
                }
            }

            if (e.NewValues["Worker"] != null)
            {
                pmPlan.Worker = e.NewValues["Worker"].ToString();
            }

            if (e.NewValues["Duration"] != null)
            {
                pmPlan.Duration = e.NewValues["Duration"].ToString();
            }
            if (e.NewValues["StartTime"] != null)
            {
                pmPlan.StartTime = e.NewValues["StartTime"].ToString();
            }
        


            pmPlan.Update();
            e.Cancel = true;
            this.grid0.CancelEdit();
            performCallBack1(); 
        }

        protected void ASPxButton5_Click(object sender, EventArgs e)
        {
            if (this.ASPxTextBox2.Text == ConfigurationSettings.AppSettings["PlanAdmin"].ToString())
            {
              
                this.grid1.Columns[0].Visible = true;
            }
        }

        protected void grid1_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            int id = Convert.ToInt32(e.Keys["PMPlanId"].ToString());

            PMSPMPlan pmPlan = PMSPMPlan.Find(id);

            if (e.NewValues["IsDown"] != null)
            {
                pmPlan.IsDown = Convert.ToBoolean(e.NewValues["IsDown"]);
            }

            if (e.NewValues["Worker"] != null)
            {
                pmPlan.Worker = e.NewValues["Worker"].ToString();
            }

            if (e.NewValues["Duration"] != null)
            {
                pmPlan.Duration = e.NewValues["Duration"].ToString();
            }

            pmPlan.Update();
            e.Cancel = true;
            this.grid1.CancelEdit();
            performCallBack2(); 
        }

        protected void ASPxButton6_Click(object sender, EventArgs e)
        {
            this.ASPxGridViewExporter2.WriteXlsToResponse();
        }

        protected void ASPxButton7_Click(object sender, EventArgs e)
        {
            this.ASPxGridViewExporter3.WriteXlsToResponse();
        }

        protected void grid_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
        {
            // if FX has value == 1 then HX cell background changeed.

            try
            {
                e.Row.Cells[1].BackColor = System.Drawing.Color.Blue;

                
            }
            catch { }


            string a=  e.Row.Cells.Count.ToString();

            TableCellCollection ecollection = e.Row.Cells;

           
        }

        protected void grid_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableDataCellEventArgs e)
        {
            if (e.DataColumn.Name == "设备名")
            {
                string a = e.Cell.Text; 
            }
            
            
        }

  

    }
}