using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
using System.Text;


namespace PMMWS
{
    public class EmailNotificationService
    {
        /// <summary>

        /// 构造一个邮件通知服务类的实例。

        /// </summary>

        /// <param name="smtpService">SMTP服务器的IP地址</param>

        /// <param name="enableSSL">是否使用SSL连接SMTP服务器器</param>

        /// <param name="port">SMTP服务器端口</param>

        /// <param name="loginName">用于登录SMTP服务器的用户名</param>

        /// <param name="password">登录密码</param>

        public EmailNotificationService(

           string smtpService,

           bool enableSSL,

           int port,

           string loginName,

           string password)
        {



            this.m_smtpService = smtpService;

            this.m_loginName = loginName;

            this.m_password = password;

            this.m_enableSSL = enableSSL;

            this.m_port = port;

        }



        private readonly string m_smtpService;

        private readonly string m_loginName;

        private readonly string m_password;

        private readonly bool m_enableSSL;

        private readonly int m_port;



        /// <summary>

        /// 发送邮件通知到指定的EMAIL地址。

        /// </summary>

        /// <param name="senderName">显示在“发件人”一栏上的名称</param>

        /// <param name="address">目的EMAIL地址</param>

        /// <param name="title">邮件标题</param>

        /// <param name="content">邮件内容</param>

        public void SendTo(string senderName, string address, string[] CCaddress, string title, string content)
        {

            MailMessage mail = new MailMessage();
            
            mail.To.Add(address);

            mail.From = new MailAddress(this.m_loginName, senderName, Encoding.UTF8);

            mail.Subject = title;

            mail.Body = content;

            mail.BodyEncoding = Encoding.UTF8;

            mail.IsBodyHtml = true;

            mail.Priority = MailPriority.Normal;

            if (CCaddress != null)
            {
                for (int i = 0; i < CCaddress.Length; i++)
                {
                    mail.CC.Add(CCaddress[i]);
                }
            }
        


            SmtpClient smtp = new SmtpClient();

            smtp.Credentials = new NetworkCredential(this.m_loginName, this.m_password);

            smtp.Host = this.m_smtpService;

            smtp.EnableSsl = this.m_enableSSL;

            smtp.Port = this.m_port;



            smtp.Send(mail);

        }


    }
}