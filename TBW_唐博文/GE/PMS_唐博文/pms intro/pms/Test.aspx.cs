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
    public partial class Test : System.Web.UI.Page
    {
        private string[] mails = ConfigurationSettings.AppSettings["PMSMailAddress"].ToString().Split('|');
        private string[] CC = ConfigurationSettings.AppSettings["Mailloop"].ToString().Split('|');
       //private string[] CC = null;
        private string sendMail = ConfigurationSettings.AppSettings["MailReceive"].ToString();
        private int alarmDate = commandMethods.GetMonthLastDate(System.DateTime.Now.Year, System.DateTime.Now.Month);
        string re = ConfigurationSettings.AppSettings["MailReceive"].ToString(); 

        protected void Page_Load(object sender, EventArgs e)
        {
            dBQuery.DBSuzhouInitialize();
            this.Button1.Attributes.Add("onclick", "return confirm('确认是否发送邮件？')");
            this.Button2.Attributes.Add("onclick", "return confirm('确认是否发送邮件？')");
            this.Button3.Attributes.Add("onclick", "return confirm('确认是否发送邮件？')");

        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
           //维护计划 
            EmailNotificationService mailNotificationService = new EmailNotificationService("mail.ad.ge.com", false, 25, mails[0], mails[1]);
            string Contents = commandMethods.GetEmailPMNotFinish(System.DateTime.Now.Month, System.DateTime.Now.Year.ToString()) + commandMethods.GetEmailPMContents(System.DateTime.Now.Month, System.DateTime.Now.Year.ToString());
            mailNotificationService.SendTo("PMS",re,CC, "PM_Scheduled_Notification", Contents);

            //int MonthNum = System.DateTime.Now.Month;
            //string Month = "FMonth" + MonthNum.ToString();
            //DataTable pmsPMPlan = dBQuery.GetReflectionResult("PMMWS.PMSPMPlan", Month, System.DateTime.Now.Year.ToString());
            ////可加入顺序延迟
            //for (int i = 0; i < pmsPMPlan.Rows.Count; i++)
            //{
            //    int id = Convert.ToInt32(pmsPMPlan.Rows[i]["PMPlanId"].ToString());
            //    pmsPMPlan.Rows[i]["IsDown"] = 0;
            //    dBQuery.UpdateReflectionResultByDataRowInt("PMMWS.PMSPMPlan", MonthNum, pmsPMPlan.Rows[i]);
            //}

            //EmailNotificationService mailNotificationService = new EmailNotificationService("mail.ad.ge.com", false, 25, "Functional.Pmsadmingesuzhou@ge.com", "Feb2030P");

            //string[] CC = ConfigurationSettings.AppSettings["Mailloop"].ToString().Split('|');

            ////string[] cc = new string[2] {"yizhuo.zhang@ge.com","toringzhang@gmail.com" };

            ////Plan
            //string content1 = commandMethods.GetEmailPMContents(System.DateTime.Now.Month, System.DateTime.Now.Year.ToString()) ;
            //string content0 = commandMethods.GetEmailPMNotFinish(System.DateTime.Now.Month, System.DateTime.Now.Year.ToString());

            //mailNotificationService.SendTo("PMS", "Shang.Huning@ge.com", CC, "Scheduled_Notification(Test)", content0 + content1);
            
            ////safe stock
            //IList<PMSMPlan> sp = PMSMPlan.FindbyQtyAlarm();
            //string content = commandMethods.GetSafeQty(sp);
            //mailNotificationService.SendTo("PMS", "Shang.Huning@ge.com", CC, "Safety_Stock_Alarm(Test)", content);
            //string dt1 = System.DateTime.Now.Year.ToString() + "-" + (System.DateTime.Now.Month + 3).ToString() + "-" + "01";
            //string dt2 = System.DateTime.Now.Year.ToString() + "-" + (System.DateTime.Now.Month + 3).ToString() + "-" + commandMethods.GetMonthLastDate(System.DateTime.Now.Year, System.DateTime.Now.Month + 1).ToString();
            //IList<PMSPMBackup> pb = PMSPMBackup.FindbyDatetime(dt1, dt2);
            //string content3 = commandMethods.GetCheckTime(pb);
            //mailNotificationService.SendTo("PMS", "Shang.Huning@ge.com", CC, "Special_Equipment_Checking_Alarm(Test)", content3);

        }

        protected void ASPxButton2_Click(object sender, EventArgs e)
        {
            IList<PMSMPlan> sp = PMSMPlan.FindbyQtyAlarm();
            string Contents = commandMethods.GetSafeQty(sp);
            EmailNotificationService mailNotificationService = new EmailNotificationService("mail.ad.ge.com", false, 25, mails[0], mails[1]);
            mailNotificationService.SendTo("PMS", re, CC, "Safety_Stock_Alarm", Contents);
        }

        protected void ASPxButton3_Click(object sender, EventArgs e)
        {
            string dt1 = System.DateTime.Now.Year.ToString() + "-" + System.DateTime.Now.Month.ToString() + "-" + "01";
            string dt2 = System.DateTime.Now.Year.ToString() + "-" + (System.DateTime.Now.Month + 3).ToString() + "-" + commandMethods.GetMonthLastDate(System.DateTime.Now.Year, System.DateTime.Now.Month + 1).ToString();

            IList<PMSPMBackup> pb = PMSPMBackup.FindbyDatetime(dt1, dt2);
            if (pb.Count != 0)
            {
                string content3 = commandMethods.GetCheckTime(pb);
                EmailNotificationService mailNotificationService = new EmailNotificationService("mail.ad.ge.com", false, 25, mails[0], mails[1]);
                mailNotificationService.SendTo("PMS", sendMail, CC, "Special_Equipment_Checking_Alarm", content3);
            }

        }

        protected void ASPxButton4_Click(object sender, EventArgs e)
        {
            if (this.ASPxTextBox1.Text == ConfigurationSettings.AppSettings["PlanAdmin"].ToString())
            {
                this.Button1.Visible = true;
                this.Button2.Visible = true;
                this.Button3.Visible = true;
            }
        }

    }
}