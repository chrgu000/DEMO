using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMMWS
{
    public partial class RepairsScan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dBQuery.DBSuzhouInitialize();
           
                IList<Scanning> scanning = Scanning.FindbyStatues("open");
                this.xOrderGridView.DataSource = scanning;
                xOrderGridView.DataBind();

                this.xOrderGridView0.DataSource = scanning;
                xOrderGridView0.DataBind();


                //this.ASPxButton1.Attributes.Add("onclick", "return confirm('确认是否提交报修信息?')");
                


                //this.ASPxButton2.Attributes.Add("onclick", "return confirm('确认是否复机?')");

            
        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
           // string a = e.ToString();

            string machineName = this.equipmentIdTextbox.Text;

            IList<Scanning> sc = Scanning.FindbyMachineName(machineName);
            try
            {
                if (sc[sc.Count - 1].CT == null || sc[sc.Count - 1].CT == "")
                {
                    sc[sc.Count - 1].CT = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                    sc[sc.Count - 1].Update();

                }
                Scanning scc = new Scanning();
                scc.ScanId = System.DateTime.Now.ToString("yyyyMMddhhmmss");
                scc.MachineName = this.equipmentIdTextbox.Text;
                scc.MachineType = this.machineBUComboBox.Value.ToString();
                scc.Statues = "open";
                scc.AlarmCode = this.alarmCodeText.Text;
                scc.ST = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                scc.FaultInfo = this.faultInfoMemo.Text;
                scc.OpWorker = this.workIdTextbox.Text;
                scc.Create();

                performCallback();
            }
            catch { };
        }

        protected void performCallback()
        {
            IList<Scanning> scanning = Scanning.FindbyStatues("open");
            this.xOrderGridView.DataSource = scanning;
            xOrderGridView.DataBind();
            this.xOrderGridView0.DataSource = scanning;
            xOrderGridView0.DataBind();

        }

        protected void ASPxButton2_Click(object sender, EventArgs e)
        {
            string machineName = this.equipmentIdTextbox2.Text;

            try
            {

                IList<Scanning> sc = Scanning.FindbyMachineName(machineName);
                if (sc[sc.Count - 1].CT == null || sc[sc.Count - 1].CT == "")
                {
                    sc[sc.Count - 1].CT = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                    sc[sc.Count - 1].Update();
                }
                performCallback();
            }
            catch { };
        }
    }
}