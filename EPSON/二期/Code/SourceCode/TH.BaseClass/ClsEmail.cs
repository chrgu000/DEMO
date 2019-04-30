using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.IO;

namespace TH.BaseClass
{
    public class ClsEmail
    {
        //通过普通SMTP 
        public string SendMailUseZj(string sUidInfo, string sAddress, string sSubject, string sText, string sFiles)
        {
            string sErr = "";

            string[] sFile = sFiles.Split(';');

            string[] sUid = sUidInfo.Split('|');

            System.Net.Mail.MailMessage eMail = new System.Net.Mail.MailMessage();
            string[] s = sAddress.Split(';');
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].Trim().Contains("@"))
                {
                    eMail.To.Add(s[i].Trim());
                }
            }

            eMail.From = new MailAddress(sUid[0], sUid[0], System.Text.Encoding.UTF8);
            /* 上面3个参数分别是发件人地址（可以随便写），发件人姓名，编码*/
            eMail.Subject = sSubject;
            eMail.SubjectEncoding = System.Text.Encoding.UTF8;//邮件标题编码    

            eMail.IsBodyHtml = true;
            eMail.Body = sText;
           
            eMail.BodyEncoding = System.Text.Encoding.UTF8;//邮件内容编码    
    
            eMail.Priority = MailPriority.High;//邮件优先级  

            for (int i = 0; i < sFile.Length; i++)
            {
                if (sFile[i].Trim() != "")
                {
                    if(!File.Exists(sFile[i].Trim()))
                    {
                        sErr = sErr + "File [" + sFile[i] + "] is not exists\n";
                        continue;
                    }

                    eMail.Attachments.Add(new Attachment(sFile[i]));
                }
            }

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(sUid[0], sUid[1]);
     
            client.Host = sUid[2];
            client.Port = BaseFunction.ReturnInt(sUid[3], 25);
            object userState = eMail;

            if(sErr.Length >0)
            {
                throw new Exception(sErr);
            }

            try
            {
                client.SendAsync(eMail, userState);
                //简单一点儿可以client.Send(eMail);  
                eMail = null;
                return ("ok");
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                eMail = null;
                return ("Err:" + ex.Message);
            }
        }

    }
}

////通过SSL的SMTP
//public void SendMailUseGmail()    
// {    
// System.Net.Mail.MailMessage eMail = new System.Net.Mail.MailMessage();    
// eMail.To.Add(a@a.com);    
// eMail.To.Add(b@b.com);    
// /*   
//  eMail.To.Add("b@b.com");   
// * eMail.To.Add("b@b.com");   
// * eMail.To.Add("b@b.com");可以发送给多人   
// */    
//eMail.CC.Add(c@c.com);    
// /*   
// * eMail.CC.Add("c@c.com");   
// * eMail.CC.Add("c@c.com");可以抄送给多人   
// */    
//eMail.From = new MailAddress("boys90.com", "dulei", System.Text.Encoding.UTF8);    
// /* 上面3个参数分别是发件人地址（可以随便写），发件人姓名，编码*/    
//eMail.Subject = "这是测试邮件";//邮件标题    
//eMail.SubjectEncoding = System.Text.Encoding.UTF8;//邮件标题编码    
//eMail.Body = "邮件内容";//邮件内容    
//eMail.BodyEncoding = System.Text.Encoding.UTF8;//邮件内容编码    
//eMail.IsBodyHtml = false;//是否是HTML邮件    
//eMail.Priority = MailPriority.High;//邮件优先级    
//SmtpClient client = new SmtpClient();    
// client.Credentials = new System.Net.NetworkCredential("boys90com@gmail.com", "password");    
// //上述写你的GMail邮箱和密码    
//client.Port = 587;//Gmail使用的端口    
//client.Host = "smtp.gmail.com";    
// client.EnableSsl = true;//经过ssl加密    
//object userState = eMail;    
// try    
// {    
// client.SendAsync(eMail, userState);    
// //简单一点儿可以client.Send(eMail);    
// MessageBox.Show("发送成功");    
// }    
//catch (System.Net.Mail.SmtpException ex)    
// {    
// MessageBox.Show(ex.Message, "发送邮件出错");    
// }    
// }
//}
