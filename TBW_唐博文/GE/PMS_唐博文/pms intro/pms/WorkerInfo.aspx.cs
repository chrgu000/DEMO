using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PMMWS
{
    public partial class WorkerInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dBQuery.DBSuzhouInitialize();
            IList<Worker> workers = Worker.FindbyType("1");
            this.grid.DataSource = workers;
            this.grid.DataBind();

            this.Button1.Attributes.Add("OnClick", "return confirm('确认要删除所选择的人员记录？')");

        }

        protected void grid_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string WorkerId = e.Keys["WorkerId"].ToString();
            Worker worker = Worker.Find(WorkerId);

            if (e.NewValues["WorkerName"] != null)
            {
            worker.WorkerName = e.NewValues["WorkerName"].ToString();
            }
            if (e.NewValues["WorkerSSO"] != null)
            {
            worker.WorkerSSO = e.NewValues["WorkerSSO"].ToString();
            }
            worker.Update();

            e.Cancel = true;
            this.grid.CancelEdit();
            performCallBack();   
        }


        protected void grid_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            if (e.NewValues["WorkerId"] != null)
            {
                Worker worker = new Worker();
                worker.WorkerId = e.NewValues["WorkerId"].ToString();

                if (e.NewValues["WorkerName"] != null)
                {
                    worker.WorkerName = e.NewValues["WorkerName"].ToString();
                }
                if (e.NewValues["WorkerSSO"] != null)
                {
                    worker.WorkerSSO = e.NewValues["WorkerSSO"].ToString();
                }

                worker.Type = "1";
              
                worker.Create();
            }

            e.Cancel = true;
            this.grid.CancelEdit();
            performCallBack();   
        }

        private void performCallBack()
        {
            IList<Worker> workers = Worker.FindbyType("1");
            this.grid.DataSource = workers;
            this.grid.DataBind();
        }

        protected void ASPxButton3_Click(object sender, EventArgs e)
        {
            if (this.ASPxTextBox1.Text == System.Configuration.ConfigurationSettings.AppSettings["PlanAdmin"].ToString())
            {
                this.grid.Columns[0].Visible = true;
                this.Button1.Visible = true;
            }
        }

        protected void grid_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string WorkerId = e.Keys["WorkerId"].ToString();
            
            if (WorkerId != null && WorkerId != "")
            {
                Worker worker = Worker.Find(WorkerId);
                try
                {
                    worker.Delete();
                }
                catch
                { }
                e.Cancel = true;
                this.grid.CancelEdit();
                performCallBack();   
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            IList<object> ids = this.grid.GetSelectedFieldValues("WorkerId");

            if (ids.Count != 0)
            {
                try
                {
                    Worker worker = Worker.Find(ids[0].ToString());
                    worker.Delete();
                    performCallBack();   
                }
                catch { }
            }

        }
    }
}