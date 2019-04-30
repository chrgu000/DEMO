using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace ϵͳ����
{
    public class ClseMail
    {
        ϵͳ����.ClsDataBase clsSQL = ϵͳ����.ClsDataBaseFactory.Instance();
        ϵͳ����.ClsDES clsDES = ϵͳ����.ClsDES.Instance();
        
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

        
        /// <param name="sHost">���ͷ����� smtp.163.com</param>
        /// <param name="sHostPort">�˿�  Ĭ��25</param>
        /// <param name="sUid">�����ʺ�</param>
        /// <param name="sPwd">��������</param>
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
                    //string sSQL = "select * from dbo._UserInfo where vchrUid = '" + ϵͳ����.ClsBaseDataInfo.sUid + "'";
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

                MessageBox.Show("����ʼ���������ʧ�ܣ� "  + ee.Message);
            }
        }

        /// <summary>
        /// �����ʼ�
        /// </summary>
        /// <param name="sMailToAddress">�ռ���ַ</param>
        /// <param name="sMailCC">���͵�ַ</param>
        /// <param name="sMailSubject">����</param>
        /// <param name="sText">����</param>
        public void MailSend(string sMailToAddress,  string sMailSubject, string sText)
        {
            MailAddress from = new MailAddress(sMailFrom, sMailFrom); //�ʼ��ķ�����

            MailMessage mail = new MailMessage();

            //�����ʼ��ı���
            mail.Subject = sMailSubject;

            ////�����ʼ��ķ�����
            ////Pass:���������ʾ�Լ��������ַ��������������mail��ʽ���������ƣ�������mail���û����������趨���������ֻ����ʾ��
            mail.From = from;

            //�����ʼ����ռ���
            string address = sMailToAddress;
            string displayName = sMailToAddress;


            /**/
            /*  ��������д����Ϊ���ܷ��������ϵ�ˣ�ÿ����ַ�� ; �Ÿ���
          һ��ӵ�ַ����ֱ��ѡ����ϵ�˵�ʱ���ʽ������ ���û���1 < mail1 >; �û���2 < mail 2>; 
          ��˾���������һ���߼���̫�õĴ���
          �����Զ��ֻ��Ҫ����һ���ռ�����ô�ͼ��� mail.To.Add("�ռ���mail");
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

            //�����ʼ��ĳ����ռ���
            //����ͼ򵥶��ˣ�����������¸���Ҫ�ļ�����CCһ�ݸ��쵼�ȽϺ�
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

            //�����ʼ�������
            mail.Body = sText;                          
            //�����ʼ��ĸ�ʽ
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            //�����ʼ��ķ��ͼ���
            mail.Priority = MailPriority.Normal;

            
            ////�����ʼ��ĸ��������ڿͻ���ѡ��ĸ������ϴ�������������һ����Ȼ����뵽mail��
            //string fileName = txtUpFile.PostedFile.FileName.Trim();
            //fileName = @"D:\UpFile\" + fileName.Substring(fileName.LastIndexOf("\") + 1);
            //txtUpFile.PostedFile.SaveAs(fileName); // ���ļ�������������
            //mail.Attachments.Add(new Attachment(fileName));

            //mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;

            SmtpClient client = new SmtpClient();
            //�������� SMTP ��������������ƣ���IP��ַҲ������
            client.Host = sHost;
            //�������� SMTP ����Ķ˿ڣ�Ĭ�ϵ��� 25
            client.Port = sHostPort;
            client.UseDefaultCredentials = false;
            
            

            //������������������½�������룬�����ҵ������ַ�� hbgx@hotmail�� �ҵ��û���Ϊ hbgx ���ҵ������� xgbh
            client.Credentials = new System.Net.NetworkCredential(sUid, sPwd);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            
            

            //���������ˣ���ʽ�����ˣ����Ǽ򵥰ɣ�
            client.Send(mail);
        }
    }
}
