using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Runtime.InteropServices;

namespace PMMWS
{
    public class NotificationHandler
    {
        private static readonly NotificationHandler g_instance = new NotificationHandler();

        /// <summary>

        /// 获取该类的唯一实例。

        /// </summary>

        public static NotificationHandler Instance
        {

            get
            {
                return g_instance;

            }

        }
        /// <summary>

        /// 默认构造方法。

        /// </summary>

        private NotificationHandler()
        {


            this.m_lockObject = new object();

            this.m_mailNotifyInfos = new LinkedList<MailNotifyInfo>();

            this.m_threadEvent = new ManualResetEvent(false);

            this.m_workThread = new Thread(this.ThreadStart);

            this.m_workThread.Start();

        }

        private readonly LinkedList<MailNotifyInfo> m_mailNotifyInfos;

        private readonly Thread m_workThread;

        private readonly ManualResetEvent m_threadEvent;

        private readonly Object m_lockObject;

        /// <summary>

        /// 添加待发送邮件的相关信息。

        /// </summary>

        public void AppendNotification(MailNotifyInfo mailNotifyInfo)
        {

            lock (this.m_lockObject)
            {

                this.m_mailNotifyInfos.AddLast(mailNotifyInfo);

                if (this.m_mailNotifyInfos.Count != 0)
                {
                    this.m_threadEvent.Set();
                }

            }
        }
             /// <summary>

    /// 发送邮件线程的执行方法。

    /// </summary>

    private void ThreadStart() {
        
 

       while (true) {

           this.m_threadEvent.WaitOne();

           MailNotifyInfo mailNotifyInfo = this.m_mailNotifyInfos.First.Value;

           EmailNotificationService mailNotificationService = new EmailNotificationService("smtp.gmail.com", true, 587, "toringzhang@gmail.com", "angelwing12345");

           int monthNum = System.DateTime.Now.Month;
           int year = System.DateTime.Now.Year;

           string content = commandMethods.GetEmailPMNotFinish(monthNum, year.ToString());

          string Contents = commandMethods.GetEmailPMContents(monthNum,year.ToString());
           
           string[] cc = new string[2] {"yizhuo.zhang@ge.com","yimin.zhan@ge.com"};

           mailNotificationService.SendTo("PMS",
                                          mailNotifyInfo.EmailAddress,cc,
                                          "计划保养定期通知",
                                           content + Contents);
           lock (this.m_lockObject) {

              this.m_mailNotifyInfos.Remove(mailNotifyInfo);
              if (this.m_mailNotifyInfos.Count == 0) {
                  this.m_threadEvent.Reset();
              }

           }

       }


        }



    }
}