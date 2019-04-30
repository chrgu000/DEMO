using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    class _SendIQCMail
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._SendIQCMail model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
          
            if (model.MailAddress != null)
            {
                strSql1.Append("MailAddress,");
                strSql2.Append("N'" + model.MailAddress + "',");
            }
            if (model.MailSubject != null)
            {
                strSql1.Append("MailSubject,");
                strSql2.Append("N'" + model.MailSubject + "',");
            }
            if (model.MailText != null)
            {
                strSql1.Append("MailText,");
                strSql2.Append("N'" + model.MailText + "',");
            }
            if (model.MailAdjunct != null)
            {
                strSql1.Append("MailAdjunct,");
                strSql2.Append("N'" + model.MailAdjunct + "',");
            }
            if (model.dtmCreate != null)
            {
                strSql1.Append("dtmCreate,");
                strSql2.Append("getdate(),");
            }
            if (model.UidCreate != null)
            {
                strSql1.Append("UidCreate,");
                strSql2.Append("N'" + model.UidCreate + "',");
            }
            if (model.IQCNo != null)
            {
                strSql1.Append("IQCNo,");
                strSql2.Append("N'" + model.IQCNo + "',");
            }

            strSql1.Append("issend,");
            strSql2.Append("0,");

            strSql.Append("insert into _SendIQCMail(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            return (strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(UFIDA.U8.UAP.CustomApp.ControlForm.Model._SendIQCMail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update _SendIQCMail set ");
            if (model.MailAddress != null)
            {
                strSql.Append("MailAddress='" + model.MailAddress + "',");
            }
            else
            {
                strSql.Append("MailAddress= null ,");
            }
            if (model.MailSubject != null)
            {
                strSql.Append("MailSubject='" + model.MailSubject + "',");
            }
            else
            {
                strSql.Append("MailSubject= null ,");
            }
            if (model.MailText != null)
            {
                strSql.Append("MailText='" + model.MailText + "',");
            }
            else
            {
                strSql.Append("MailText= null ,");
            }
            if (model.MailAdjunct != null)
            {
                strSql.Append("MailAdjunct='" + model.MailAdjunct + "',");
            }
            else
            {
                strSql.Append("MailAdjunct= null ,");
            }
            if (model.dtmCreate != null)
            {
                strSql.Append("dtmCreate='" + model.dtmCreate + "',");
            }
            else
            {
                strSql.Append("dtmCreate= null ,");
            }
            if (model.UidCreate != null)
            {
                strSql.Append("UidCreate='" + model.UidCreate + "',");
            }
            else
            {
                strSql.Append("UidCreate= null ,");
            }
            if (model.IQCNo != null)
            {
                strSql.Append("IQCNo='" + model.IQCNo + "',");
            }
            else
            {
                strSql.Append("IQCNo= null ,");
            }
            if (model.issend != null)
            {
                strSql.Append("issend=" + (model.issend ? 1 : 0) + ",");
            }
            else
            {
                strSql.Append("issend= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where IQCNo='" + model.IQCNo + "'");
            return (strSql.ToString());
        }
    }
}
