using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace 系统服务
{
    public class ClseMail
    {
        系统服务.ClsDataBase clsSQL = 系统服务.ClsDataBaseFactory.Instance();
        系统服务.ClsDES clsDES = 系统服务.ClsDES.Instance();
        
        private string sPathConfig = Application.StartupPath + @"\EmailInfo.dll";

        public string sMailFrom = "tanghui_mail@163.com";
        public string sMailCC = "tanghui_mail@163.com";
        public string sMailToAddrss;
        public string sMailSubject;
        public string sHost ="smtp.163.com";
        public int sHostPort = 25;
        public string sUid = "tanghui_mail@163.com";
        public string sPwd = "gabc904511";
        string sMCC;

        
        /// <param name="sHost">发送服务器 smtp.163.com</param>
        /// <param name="sHostPort">端口  默认25</param>
        /// <param name="sUid">发件帐号</param>
        /// <param name="sPwd">发件密码</param>
        public ClseMail(string sHost, int sHostPort, string sUid, string sPwd)
        {
            this.sHost = sHost;
            this.sHostPort = sHostPort;
            this.sUid = sUid;
            this.sPwd = sPwd;
        }

        public ClseMail()
        {
            try
            {
                if (File.Exists(sPathConfig))
                {
                    //string sSQL = "select * from dbo._UserInfo where vchrUid = '" + 系统服务.ClsBaseDataInfo.sUid + "'";
                    //DataTable dt = clsSQL.ExecQuery(sSQL);
                    DataSet ds = new DataSet();
                    ds.ReadXml(sPathConfig);

                    DataTable dt = ds.Tables[0];
                    if (dt.Rows != null && dt.Rows.Count > 0)
                    {
                        sMailFrom = dt.Rows[0]["sMailAddress"].ToString().Trim();
                        sMailCC = dt.Rows[0]["sMailAddress"].ToString().Trim();
                        sMCC = dt.Rows[0]["sMailAddress"].ToString().Trim();
                        sHost = dt.Rows[0]["sMailSMTP"].ToString().Trim();
                        sHostPort = Convert.ToInt32(dt.Rows[0]["sMailHost"]);
                        sUid = dt.Rows[0]["sMailUid"].ToString().Trim();
                        sPwd = clsDES.Decrypt(dt.Rows[0]["sMialPwd"].ToString().Trim());
                    }
                }
            }
            catch(Exception ee)
            {

                MessageBox.Show("获得邮件发送设置失败！ "  + ee.Message);
            }
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="sMailToAddress">收件地址</param>
        /// <param name="sMailCC">抄送地址</param>
        /// <param name="sMailSubject">主题</param>
        /// <param name="sText">内容</param>
        public void MailSend(string sMailToAddress,  string sMailSubject, string sText)
        {
            MailAddress from = new MailAddress(sMailFrom, sMailFrom); //邮件的发件人

            MailMessage mail = new MailMessage();

            //设置邮件的标题
            mail.Subject = sMailSubject;

            ////设置邮件的发件人
            ////Pass:如果不想显示自己的邮箱地址，这里可以填符合mail格式的任意名称，真正发mail的用户不在这里设定，这个仅仅只做显示用
            mail.From = from;

            //设置邮件的收件人
            string address = sMailToAddress;
            string displayName = sMailToAddress;


            /**/
            /*  这里这样写是因为可能发给多个联系人，每个地址用 ; 号隔开
          一般从地址簿中直接选择联系人的时候格式都会是 ：用户名1 < mail1 >; 用户名2 < mail 2>; 
          因此就有了下面一段逻辑不太好的代码
          如果永远都只需要发给一个收件人那么就简单了 mail.To.Add("收件人mail");
        */
            string[] mailNames = (address + ";").Split(';');
            foreach (string name in mailNames)
            {
                if (name != string.Empty)
                {
                    if (name.IndexOf('<') > 0)
                    {
                        displayName = name.Substring(0, name.IndexOf('<'));
                        address = name.Substring(name.IndexOf('<') + 1).Replace('>', ' ');
                    }
                    else
                    {
                        displayName = string.Empty;
                        address = name.Substring(name.IndexOf('<') + 1).Replace('>', ' ');
                    }
                    mail.To.Add(new MailAddress(address, displayName));
                }
            }

            //设置邮件的抄送收件人
            //这个就简单多了，如果不想快点下岗重要文件还是CC一份给领导比较好
            //if (sMCC.Trim() != "")
            //{
            //    mail.CC.Add(new MailAddress(sMCC, sMCC));
            //}
            //if (sMCC.Trim() != "")
            //{
            //mail.CC.Add(new MailAddress("68298493@qq.com", "68298493@qq.com"));
            //}
            string[] sMailC = sMailCC.Split(';');
            if (sMailC.Length > 0)
            {
                for (int i = 0; i < sMailC.Length; i++)
                {
                    if (sMailC[i].Trim() == "")
                        continue;

                    mail.CC.Add(new MailAddress(sMailC[i], sMailC[i]));
                }
            }

            //设置邮件的内容
            mail.Body = sText;                          
            //设置邮件的格式
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            //设置邮件的发送级别
            mail.Priority = MailPriority.Normal;

            
            ////设置邮件的附件，将在客户端选择的附件先上传到服务器保存一个，然后加入到mail中
            //string fileName = txtUpFile.PostedFile.FileName.Trim();
            //fileName = @"D:\UpFile\" + fileName.Substring(fileName.LastIndexOf("\") + 1);
            //txtUpFile.PostedFile.SaveAs(fileName); // 将文件保存至服务器
            //mail.Attachments.Add(new Attachment(fileName));

            //mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;

            SmtpClient client = new SmtpClient();
            //设置用于 SMTP 事务的主机的名称，填IP地址也可以了
            client.Host = sHost;
            //设置用于 SMTP 事务的端口，默认的是 25
            client.Port = sHostPort;
            client.UseDefaultCredentials = false;
            
            

            //这里才是真正的邮箱登陆名和密码，比如我的邮箱地址是 hbgx@hotmail， 我的用户名为 hbgx ，我的密码是 xgbh
            client.Credentials = new System.Net.NetworkCredential(sUid, sPwd);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            
            

            //都定义完了，正式发送了，很是简单吧！
            client.Send(mail);
        }
    }
}
