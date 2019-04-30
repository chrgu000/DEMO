using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMMWS
{
    public partial class RepairPageForm : System.Web.UI.Page
    {
        private string ScanId;
        private string machineType;
        private string OrderId;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Button1.Attributes.Add("onclick", "return confirm('确认是否完成维修')");
            string[] session = Session["ScanId"].ToString().Split('?');
            ScanId = session[0];
            machineType = session[1];
            string workId = session[2];
            OrderId = session[3];

            if (!IsPostBack)
            {
                Scanning Sc = Scanning.Find(ScanId);
                Worker work = Worker.Find(workId);
                try
                {
                    this.WorkerName.Text = work.WorkerName;
                }
                catch
                {
                    this.WorkerName.Text = work.WorkerId;
                }
                this.RepairManitance.Text = Sc.MachineName;
            }

            IList<Scanning> scs = Scanning.FindbyStatuesAndId("open",ScanId);
            
            this.xOrderGridView.DataSource = scs;
            this.xOrderGridView.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (machineType == "Composite")
                {
                    CMOrder cm = CMOrder.Find(Convert.ToInt32(OrderId));
                    cm.MCT = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                    cm.FaultType = this.Faulttype.Text;
                    cm.Update();
                }
                else if (machineType == "Machining")
                {
                    MAOrder ma = MAOrder.Find(Convert.ToInt32(OrderId));
                    ma.MCT = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                    ma.FaultType = this.Faulttype.Text;
                    ma.Update();
                }
                else if (machineType == "Sheet Metal")
                {
                    SMOrder sm = SMOrder.Find(Convert.ToInt32(OrderId));
                    sm.MCT = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                    sm.FaultType = this.Faulttype.Text;
                    sm.Update();
                }
                else if (machineType == "Actuation")
                {
                    HPOrder  hp = HPOrder.Find(Convert.ToInt32(OrderId));
                    hp.MCT = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                    hp.FaultType = this.Faulttype.Text;
                    hp.Update();
                }

                Session.Clear();
                
                this.Page.RegisterStartupScript("close ", " <script> window.opener=null;window.top.close() </script> "); 
                
                Response.Redirect("OpMainPage.aspx");

            }
            catch
            { 
                
               }
        }

        //protected void xOrderGridView_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
        //{
        //    if (e.GetValue("ScanId").ToString() == ScanId ) 
        //    {
        //        e.Row.BackColor = System.Drawing.Color.Red;
        //    }
        //}


    }
}