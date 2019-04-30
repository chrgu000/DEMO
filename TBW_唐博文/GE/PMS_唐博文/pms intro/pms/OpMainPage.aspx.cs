using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;
using System.Data;

namespace PMMWS
{
    public partial class OpMainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dBQuery.DBSuzhouInitialize();
         
            //IList<Scanning> scanning = Scanning.FindbyStatues("open");
            //this.xOrderGridView.DataSource = scanning;
            //xOrderGridView.DataBind();

            IList<CMOrder> cmorder = CMOrder.FindbyStatues("0");
            IList<SMOrder> smorder = SMOrder.FindbyStatues("0");
            IList<MAOrder> maorder = MAOrder.FindbyStatues("0");
            IList<HPOrder> hporder = HPOrder.FindbyStatues("0");

            DataTable dt3 = commandMethods.ConvertToDataTable<CMOrder>(cmorder);
            DataTable dt2 = commandMethods.ConvertToDataTable<SMOrder>(smorder);
            DataTable dt1 = commandMethods.ConvertToDataTable<MAOrder>(maorder);
            DataTable dt4 = commandMethods.ConvertToDataTable<HPOrder>(hporder);

            if (dt1 != null)
            {
                if (dt2 != null)
                {
                    dt1.Merge(dt2);
                }
                if (dt3 != null)
                {
                    dt1.Merge(dt3);
                }
                if (dt4 != null)
                {
                    dt1.Merge(dt4);
                }
                this.xOrderGridView.DataSource = dt1;
                xOrderGridView.DataBind();
            }
            else if (dt2 != null)
            {
                if (dt3 != null)
                {
                    dt2.Merge(dt3);
                }
                if (dt4 != null)
                {
                    dt2.Merge(dt4);
                }
                this.xOrderGridView.DataSource = dt2;
                xOrderGridView.DataBind();
            }
            else if (dt3 != null)
            {
                if (dt4 != null)
                {
                    dt3.Merge(dt4);
                }
                this.xOrderGridView.DataSource = dt3;
                xOrderGridView.DataBind();
            }
            else if (dt4 != null)
            {
                this.xOrderGridView.DataSource = dt4;
                xOrderGridView.DataBind();
            }
          
        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            string MachineCode = this.xMachineName.Text.ToString();
            string WorkId = this.xWorkerId.Text.ToString();

            if (WorkId == "admin")
            {
                Response.Redirect("MaintenancePlanForm.aspx");
            }
      
          try
           {
              Machine Ma = Machine.Find(MachineCode);
          
            if (Ma.MachineBu == "液压测试站")
            {
                HPOrder[] hpos = HPOrder.FindbyMachineNameAndStatues(MachineCode, "0");

                if (hpos.Length != 0)
                {
                    HPOrder hpo = HPOrder.Find(hpos[0].OrderId);
                    hpo.WorkerId = WorkId;
                    if (hpo.MST == null)
                    {
                        hpo.MST = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");   
                    } 
                    hpo.Update();
                   Session["ScanId"] = hpo.ScanId + "?" + hpo.MachineType + "?" + hpo.WorkerId + "?" +  hpo.OrderId.ToString();
                   Response.Redirect("RepairPageForm.aspx");
                }

            }
            else if (Ma.MachineBu == "钣金件")
            {
                SMOrder[] smos = SMOrder.FindbyMachineNameAndStatues(MachineCode, "0");
                if (smos.Length != 0)
                {
                    SMOrder smo = SMOrder.Find(smos[0].OrderId);
                     smo.WorkerId = WorkId;
                    if (smo.MST == null)
                    {
                        smo.MST = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                        
                    }
                     smo.Update();
                     Session["ScanId"] = smo.ScanId + "?" + smo.MachineType + "?" + smo.WorkerId + "?" + smo.OrderId.ToString();
                    Response.Redirect("RepairPageForm.aspx");
                }
               
            }
            else if (Ma.MachineBu == "机加工")
            {
                MAOrder[] maos = MAOrder.FindbyMachineNameAndStatues(MachineCode, "0");
                if (maos.Length != 0)
                {
                    MAOrder mao = MAOrder.Find(maos[0].OrderId);
                    
                    mao.WorkerId = WorkId;
                   
                    if (mao.MST == null)
                    {
                        mao.MST = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");  
                    } 
                    mao.Update();
                Session["ScanId"] = mao.ScanId + "?" + mao.MachineType + "?" + mao.WorkerId + "?" + mao.OrderId.ToString();
                Response.Redirect("RepairPageForm.aspx");
                }
              
            }
            else if (Ma.MachineBu == "复合材料")
            {
                CMOrder[] cmos = CMOrder.FindbyMachineNameAndStatues(MachineCode, "0");
                if (cmos.Length != 0)
                {
                    CMOrder cmo = CMOrder.Find(cmos[0].OrderId);
                    
                    cmo.WorkerId = WorkId;
                    
                    if (cmo.MST == null)
                    {
                        cmo.MST = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                    }    
                     cmo.Update();
                  Session["ScanId"] = String.Format("{0}?{1}?{2}?{3}", cmo.ScanId, cmo.MachineType, cmo.WorkerId, cmo.OrderId);
                  Response.Redirect("RepairPageForm.aspx");
                }
            }

            }
            catch
            {
                this.ASPxLabel1.Text = "机床名称或员工Id错误";
            }

        }

  


    }
}