using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PMMWS
{
    public partial class MaintenanceWebInfo : System.Web.UI.Page
    {
        private string orderId;

        protected void Page_Load(object sender, EventArgs e)
        {
            //机加工工单维护

            dBQuery.DBSuzhouInitialize();

            this.saveButton.Attributes.Add("onclick", "return confirm('确认是否保存工单?')");
         
            this.cancelButton.Attributes.Add("onclick", "return confirm('是否取消')");

            orderId = Request["OrderId"];
            
            if (!IsPostBack)
            {
           
                MAOrder mao = MAOrder.Find(Convert.ToInt32(orderId));

                if (mao.OrderNo == null)
                {
                    this.ASPxLabel1.Text = "工单尚未保存";
                }
                else
                {
                    this.ASPxLabel1.Text = "工单尚未结束";
                }

                LoadMachiInfo(orderId,mao); 
            }
        }

        private void LoadMachiInfo(string oderInfo,MAOrder mao)
        {
          

            this.workOrderNum.Text = mao.OrderNo;
            this.alarmCode.Text = mao.AlarmCode;
            this.description.Text = mao.FaultInfo;
            this.reportTime.Text =  mao.ST;
            this.machineName.Text = mao.MachineCode;
            this.xMachineTypeBox.Text = mao.MachineType;
            this.Faulttype.Text = mao.FaultType;
            this.stopTime.Text = mao.CT;
            this.WorkName.Text = mao.WorkerId;
            //try
            //{
            //    Worker wo = Worker.Find(mao.WorkerId);
            //    this.WorkName.Text = wo.WorkerName;
            //}
            //catch
            //{ }

            this.defination.Text = mao.Definition;
            try
            {
                this.AlarmEndTime.Text = Convert.ToDateTime(mao.MCT).ToString("yyyy-MM-dd HH:mm:ss");

            }
            catch
            { }
            try
            {
                this.AlarmsStaterTime.Text = Convert.ToDateTime(mao.MST).ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch
            { }

            this.olcation.Text = mao.Olcation;
            this.Operator.Text  = mao.Operator;
            this.reason.Text = mao.Reason;
            this.remedy.Text = mao.Remedy;
                                    
            if (mao.PartName != null)
            {
                string[] pa = mao.PartName.Split('+');
                string[] pn = mao.PartNO.Split('+');
                string[] pp = mao.PartPrice.Split('+');
                string[] pt = mao.PartType.Split('+');
                string[] pw = mao.PartWaitTime.Split('+');

                if (pa.Length != 0)
                {
                    this.partName0.Text = pa[0];
                    this.partName1.Text = pa[1];
                    this.partName2.Text = pa[2];

                    this.partNum0.Text = pn[0];
                    this.partNum1.Text = pn[1];
                    this.partNum2.Text = pn[2];

                    this.partPrice0.Text = pp[0];
                    this.partPrice1.Text = pp[1];
                    this.partPrice2.Text = pp[2];

                    this.partType0.Text = pt[0];
                    this.partType1.Text = pt[1];
                    this.partType2.Text = pt[2];

                    this.partWaitTime0.Text = pw[0];
                    this.partWaitTime1.Text = pw[1];
                    this.partWaitTime2.Text = pw[2];
                }
            }
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("WorkOrderAdmin.aspx");
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {

            MAOrder mao = MAOrder.Find(Convert.ToInt32(orderId));

             mao.OrderNo = System.DateTime.Now.ToString("yyyymmddhhMMss");

             mao.AlarmCode = this.alarmCode.Text ;
             mao.FaultInfo = this.description.Text ;
             mao.Definition = this.defination.Text ;
             mao.MachineCode = this.machineName.Text;
             mao.MachineType = this.xMachineTypeBox.Text;
             mao.FaultType = this.Faulttype.Text;

             mao.WorkerId = this.WorkName.Text;
             
             mao.MCT = this.AlarmEndTime.Text;
             mao.MST = this.AlarmsStaterTime.Text;
             mao.Olcation = this.olcation.Text;
             mao.Operator = this.Operator.Text;
             mao.Reason = this.reason.Text;
             mao.Remedy = this.remedy.Text;
             mao.CT = this.stopTime.Text;


             mao.PartName = this.partName0.Text + "+" + this.partName1.Text + "+" + this.partName2.Text;
             mao.PartNO = String.Format("{0}+{1}+{2}", this.partNum0.Text, this.partNum1.Text, this.partNum2.Text);
             mao.PartPrice = this.partPrice0.Text + "+" + this.partPrice1.Text + "+" + this.partPrice2.Text;
             mao.PartType = this.partType0.Text + "+" + this.partType1.Text + "+" + this.partType2.Text;
             mao.PartWaitTime = this.partWaitTime0.Text + "+" + this.partWaitTime1.Text + "+" + this.partWaitTime2.Text;

             mao.Update();

             LoadMachiInfo(orderId, mao);

             Response.Redirect("WorkOrderAdmin.aspx");
        }

      

    }
}