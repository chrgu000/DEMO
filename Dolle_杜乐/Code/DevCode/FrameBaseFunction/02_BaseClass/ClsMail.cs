using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace FrameBaseFunction
{
    public class ClseMail
    {
        FrameBaseFunction.ClsDataBase clsSQL = FrameBaseFunction.ClsDataBaseFactory.Instance();
  
        public ClseMail()
        {

        }

        /// <summary>
        /// �����ʼ�
        /// </summary>
        /// <param name="sMailToAddress">�ռ���ַ</param>
        /// <param name="sMailSubject">����</param>
        /// <param name="sText">����</param>
        public void MailSend(string sMailToAddress, string sMailSubject, string sText)
        {
            string sSQL = @"
exec msdb..sp_send_dbmail
          @profile_name='dolle_bpm@dolle.com.cn',
          @recipients='1111111111111111',  --�ռ���
          @subject='2222222222222222 ',
          @body=N'3333333333333333'

";
            sSQL = sSQL.Replace("1111111111111111", sMailToAddress);
            sSQL = sSQL.Replace("2222222222222222", sMailSubject);
            sSQL = sSQL.Replace("3333333333333333", sText);

            clsSQL.ExecSql(sSQL);
        }

    }
}
