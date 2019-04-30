using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace PMMWS
{
    public partial class PublicFacilities : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dBQuery.DBSuzhouInitialize();
            IList<Worker> workers = Worker.FindbyTypeAndCT("2");
            this.grid.DataSource = workers;
            this.grid.DataBind();

            IList<Worker> notfinWorkers = Worker.FindbyTypeAndNULLCT("2");
            this.grid0.DataSource = notfinWorkers;
            this.grid0.DataBind();
            
        }

        protected void ASPxButton3_Click(object sender, EventArgs e)
        {
            if (this.ASPxTextBox1.Text == ConfigurationSettings.AppSettings["PlanAdmin"].ToString())
            {
                this.grid.Columns[0].Visible = true;
                this.grid0.Columns[0].Visible = true;
            }
            
        }

        protected void grid_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string WorkerId = e.Keys["WorkerId"].ToString();
            Worker worker = Worker.Find(WorkerId);

            if (e.NewValues["MachineName"] != null)
            {
                worker.MachineName = e.NewValues["MachineName"].ToString();
            }
            if (e.NewValues["FaultReason"] != null)
            {
                worker.FaultReason = e.NewValues["FaultReason"].ToString();
            }
            if (e.NewValues["Contents"] != null)
            {
                worker.Contents = e.NewValues["Contents"].ToString();
            }
            if (e.NewValues["ST"] != null)
            {
                worker.ST = e.NewValues["ST"].ToString();
            }
            if (e.NewValues["CT"] != null)
            {
                worker.CT = e.NewValues["CT"].ToString();
            }
            if (e.NewValues["EHS"] != null)
            {
                worker.EHS = e.NewValues["EHS"].ToString();
            }
            if (e.NewValues["MWorker"] != null)
            {
                worker.MWorker = e.NewValues["MWorker"].ToString();
            }
            if (e.NewValues["FType"] != null)
            {
                worker.FType = e.NewValues["FType"].ToString();
            }

            worker.Type = "2";
            worker.Update();

            e.Cancel = true;
            this.grid.CancelEdit();
            this.grid0.CancelEdit();
            performCallBack();   

        }

        protected void grid_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
        
               Worker worker = new Worker();
               worker.WorkerId = System.DateTime.Now.ToString("yyyyMMddhhmmss");

               if (e.NewValues["MachineName"] != null)
                {
                    worker.MachineName = e.NewValues["MachineName"].ToString();
                }
               if (e.NewValues["FaultReason"] != null)
                {
                    worker.FaultReason = e.NewValues["FaultReason"].ToString();
                }
               if (e.NewValues["Contents"] != null)
               {
                   worker.Contents = e.NewValues["Contents"].ToString();
               }
               if (e.NewValues["ST"] != null)
               {
                   worker.ST = e.NewValues["ST"].ToString();
               }
               if (e.NewValues["CT"] != null)
               {
                   worker.CT = e.NewValues["CT"].ToString();
               }

               if (e.NewValues["EHS"] != null)
               {
                   worker.EHS = e.NewValues["EHS"].ToString();
               }
               if (e.NewValues["MWorker"] != null)
               {
                   worker.MWorker = e.NewValues["MWorker"].ToString();
               }
               if (e.NewValues["FType"] != null)
               {
                   worker.FType = e.NewValues["FType"].ToString();
               }
              
                worker.Type = "2";
                worker.Create();

                e.Cancel = true;
                this.grid.CancelEdit();
                this.grid0.CancelEdit();
                performCallBack(); 
  
               
        }

        private void performCallBack()
        {
            IList<Worker> workers = Worker.FindbyTypeAndCT("2");

            this.grid.DataSource = workers;
            this.grid.DataBind();

            IList<Worker> notfinWorkers = Worker.FindbyTypeAndNULLCT("2");
            this.grid0.DataSource = notfinWorkers;
            this.grid0.DataBind();


            if (this.ASPxCheckBox1.Checked == true)
                this.ASPxListBox1.Visible = true;
            else
                this.ASPxListBox1.Visible = false;
        }

        protected void grid_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string WorkerId = e.Keys["WorkerId"].ToString();
            Worker worker = Worker.Find(WorkerId);

            worker.Delete();
            
            performCallBack(); 
        }

        protected void ASPxButton4_Click(object sender, EventArgs e)
        {
            this.ASPxGridViewExporter1.WriteXlsToResponse();
        }

        protected void ASPxButton5_Click(object sender, EventArgs e)
        {
            this.ASPxGridViewExporter2.WriteXlsToResponse();
        }

        protected void ASPxButton7_Click(object sender, EventArgs e)
        {
            Worker worker = new Worker();
            worker.WorkerId = System.DateTime.Now.ToString("yyyyMMddhhmmss");
            worker.Type = "2";

            worker.MachineName = this.xMachineName.Text;
            worker.ST = this.ReportTime.Text;
            worker.RName = this.ReportPerson.Text;
            worker.FaultReason = this.Reason.Text;

            if (this.ASPxCheckBox1.Checked == true)
            {
                worker.EHS = "是";
                
            }
            else
            {
                worker.EHS = "否";
            }

            worker.EHS = GetSelectionEHS();

            worker.Create();

            SendEmailToPeople(this.ASPxCheckBox1.Checked,worker);

            performCallBack();

        }

        private string[] mails = ConfigurationSettings.AppSettings["PMSMailAddress"].ToString().Split('|');

        private void SendEmailToPeople(bool IsEHS, Worker worker)
        {
            if (IsEHS == true)
            {
                string content3 = GetEHSContents(worker);


                string sendMail = "Shang.Huning@ge.com";
                string[] CC = new string[] { "Bing.Du@ge.com", "Bo2.Jiang@ge.com","Hu.Chen@ge.com" };

                EmailNotificationService mailNotificationService = new EmailNotificationService("mail.ad.ge.com", false, 25, mails[0], mails[1]);
                mailNotificationService.SendTo("PMS", sendMail, CC, "EHS_Alarm", content3);
            
            }
            
        }

        


        private string GetEHSContents(Worker worker)
        {

            string Contents = "<strong>EHS设备报修通知：EHS device alarm notification:</strong>";
            Contents = Contents.Replace("\n", "<br />") + "<br /> <br />";
            Contents += "<hr /><br />";
            Contents += " <table width = '800' border='1' >" + "<tr><td>";
            Contents += " <strong>设备名称 Device_Name</strong></td>";
            Contents += " <td><strong>故障原因Fault_Des</strong></td>";
            Contents += " <td><strong>时间Time</strong></td>";
            Contents += " <td><strong>报修人Report</strong></td>";
            Contents += " <td><strong>EHS分类Level</strong></td></tr>";


            Contents += "<tr><td>" + worker.MachineName + "</td>";
                Contents += "<td>" + worker.FaultReason + "</td >";
                Contents += "<td>" + worker.ST + "</td> ";
                Contents += "<td>" + worker.RName+ "</td>";
                Contents += "<td>" + worker.EHS + "</td></tr>";
          

            Contents += " </table>";

            Contents += "This mail is created by PMS automatically, please don't reply.";
            return Contents;
        
        }




        private string GetSelectionEHS()
        {
            string a = "";
            
            for (int i = 0; i < this.ASPxListBox1.SelectedItems.Count; i++)
            {
                a = a + this.ASPxListBox1.SelectedItems[i].Text + ";";
            }

            return a;
        
        }


        protected void ASPxCallbackPanel1_Callback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
        {
            if (this.ASPxCheckBox1.Checked == true)
                this.ASPxListBox1.Visible = true;
            else
                this.ASPxListBox1.Visible = false;
        }

     
    }
}