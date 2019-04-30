using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Timers;
using System.Configuration;
using System.Data;

namespace PMMWS
{
    public class Global : System.Web.HttpApplication
    {
        private string[] mails = ConfigurationSettings.AppSettings["PMSMailAddress"].ToString().Split('|');
        private string[] CC = ConfigurationSettings.AppSettings["Mailloop"].ToString().Split('|');
       //private string[] CC = null;
        private string sendMail = ConfigurationSettings.AppSettings["MailReceive"].ToString();
        private int alarmDate = commandMethods.GetMonthLastDate(System.DateTime.Now.Year, System.DateTime.Now.Month);

        protected void Application_Start(object sender, EventArgs e)
        {
            Timer t = new Timer(86400000);//
            t.Elapsed += new ElapsedEventHandler(t_Elapsed);
            t.AutoReset = true; t.Enabled = true;
            Timer t2 = new Timer(86400000);
            t2.Elapsed += new ElapsedEventHandler(t2_Elapsed);
            t2.AutoReset = true; t2.Enabled = true;
        }

        private void t2_Elapsed(object sender, ElapsedEventArgs e)
        {
            string dt1 = System.DateTime.Now.Year.ToString() + "-" + System.DateTime.Now.Month.ToString() + "-" + "01";
            string dt2 = System.DateTime.Now.Year.ToString() + "-" + (System.DateTime.Now.Month + 1).ToString() + "-" + commandMethods.GetMonthLastDate(System.DateTime.Now.Year, System.DateTime.Now.Month + 1).ToString();

            if (System.DateTime.Now.Day == alarmDate - 1)
            {
                IList<PMSPMBackup> pb = PMSPMBackup.FindbyDatetime(dt1, dt2);
                if (pb.Count != 0)
                {
                    string content3 = commandMethods.GetCheckTime(pb);
                    EmailNotificationService mailNotificationService = new EmailNotificationService("mail.ad.ge.com", false, 25, mails[0], mails[1]);
                    mailNotificationService.SendTo("PMS", sendMail, CC, "Special_Equipment_Checking_Alarm", content3);
                }
            }
        }

        private void t_Elapsed(object sender, ElapsedEventArgs e)
        {
            
           IList<PMSMPlan> sp = PMSMPlan.FindbyQtyAlarm();

           EmailNotificationService mailNotificationService = new EmailNotificationService("mail.ad.ge.com", false, 25, mails[0], mails[1]);
           string re = ConfigurationSettings.AppSettings["MailReceive"].ToString();

            //计划维护提醒
            if (System.DateTime.Now.Day == alarmDate - 7 )
           {
              string Contents = commandMethods.GetEmailPMNotFinish(System.DateTime.Now.Month,System.DateTime.Now.Year.ToString()) + commandMethods.GetEmailPMContents(System.DateTime.Now.Month,System.DateTime.Now.Year.ToString());
              mailNotificationService.SendTo("PMS", re, CC, "PM_Scheduled_Notification", Contents);
           }
            //最小库存量提醒
            if (sp.Count != 0)
            {
                string Contents = commandMethods.GetSafeQty(sp);
                mailNotificationService.SendTo("PMS", re, CC, "Safety_Stock_Alarm", Contents);
                for (int i = 0; i < sp.Count; i++)
                {
                    sp[i].IsAlarm = "1";
                    sp[i].Update();
                }
            }
            //计划维护重置
            if (System.DateTime.Now.Day == alarmDate-1)
            {
                int MonthNum = System.DateTime.Now.Month; 
                string Month = "FMonth" + MonthNum.ToString();
                DataTable pmsPMPlan = dBQuery.GetReflectionResult("PMMWS.PMSPMPlan", Month, System.DateTime.Now.Year.ToString());

                //可加入顺序延迟
                for (int i = 0; i < pmsPMPlan.Rows.Count ; i++)
                {
                    int id = Convert.ToInt32(pmsPMPlan.Rows[i]["PMPlanId"].ToString());
                    pmsPMPlan.Rows[i]["IsDown"] = 0 ;
                    dBQuery.UpdateReflectionResultByDataRowInt("PMMWS.PMSPMPlan", MonthNum, pmsPMPlan.Rows[i]);
                }
            }

        
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}