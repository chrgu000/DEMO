using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.Configuration;

namespace PMMWS
{
    public partial class ChartingControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           dBQuery.DBSuzhouInitialize();
        }

        private void GetSTime()
        {
            DateTime Monday = commandMethods.GetWeekTime(this.ASPxDateEdit1.Date);
            Session["Monday"] = Monday.ToString("yyyy-MM-dd");
            TimeSpan sp = new TimeSpan(168, 0, 0);
            DateTime EndTime = Monday + sp;

            commandMethods.ComputeMASTime(Monday,EndTime);
            commandMethods.ComputeCMTime(Monday, EndTime);
            commandMethods.ComputeSMTime(Monday, EndTime);
            commandMethods.ComputeHPTime(Monday, EndTime);

            commandMethods.ComputeMADownTime(Monday.ToString("yyyy-MM-dd"));
            commandMethods.ComputeCMDownTime(Monday.ToString("yyyy-MM-dd"));
            commandMethods.ComputeHPDownTime(Monday.ToString("yyyy-MM-dd"));
            commandMethods.ComputeSMDownTime(Monday.ToString("yyyy-MM-dd"));

            commandMethods.ComputeTotalDownTime(Monday.ToString("yyyy-MM-dd"));
        }

        protected void ASPxCallbackPanel1_Callback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
        {
            if (this.ASPxDateEdit1.Text != "")
            {
                
                    GetSTime();
                    //DateTime Monday = commandMethods .GetWeekTime(this.ASPxDateEdit1.Date);
                    //commandMethods.WriteTotheXML(Monday);
                    //Session["Monday"] = Monday.ToString();
                    this.ASPxLabel2.Text = "工作周:" + this.ASPxComboBox1.Text + ",点击下面按钮显示报表：";
                    this.ASPxLabel2.Visible = true;
                    this.ASPxButton2.Visible = true;
              
               
            }
        }

        protected void ASPxComboBox1_Callback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
        {
             DateTime Monday = commandMethods.GetWeekTime(this.ASPxDateEdit1.Date);
             string monday = Monday.Date.ToString("yyyy-MM-dd");
             try
             {
                 string Week = ConfigurationSettings.AppSettings[monday].ToString();
                 this.ASPxComboBox1.Items.Add(Week);
             }
             catch
             { 
                
             }
           
        }

        //protected void ASPxButton3_Click(object sender, EventArgs e)
        //{
        //    IList<MAReport> mas = MAReport.FindAll();

        //    for (int i = 0; i < mas.Count; i++)
        //    {
        //        if (mas[i].Weeks != null & mas[i].Weeks != "")
        //        {
        //            mas[i].Week = Convert.ToInt32(mas[i].Weeks);
        //            mas[i].Update();
        //        }
        //    }
        //    IList<CMReport> cms = CMReport.FindAll();

        //    for (int i = 0; i < cms.Count; i++)
        //    {
        //        if (cms[i].Weeks != null & cms[i].Weeks != "")
        //        {
        //            cms[i].Week = Convert.ToInt32(cms[i].Weeks);
        //            cms[i].Update();
        //        }
        //    }

        //    IList<HPReport> hps = HPReport.FindAll();

        //    for (int i = 0; i < hps.Count; i++)
        //    {
        //        if (hps[i].Weeks != null & hps[i].Weeks != "")
        //        {
        //            hps[i].Week = Convert.ToInt32(hps[i].Weeks);
        //            hps[i].Update();
        //        }
        //    }

        //    IList<SMReport> smc = SMReport.FindAll();
        //    for (int i = 0; i < smc.Count; i++)
        //    {
        //        if (smc[i].Weeks != null & smc[i].Weeks != "")
        //        {
        //            smc[i].Week = Convert.ToInt32(smc[i].Weeks);
        //            smc[i].Update();
        //        }
        //    }
        //}

   



   
    
    }
}