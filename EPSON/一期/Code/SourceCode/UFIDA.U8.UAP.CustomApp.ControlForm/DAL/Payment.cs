using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_Payment
    /// </summary>
    public partial class _Payment
    {
        public _Payment()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public string Exists(string U8PaymentTermCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from _Payment");
            strSql.Append(" where U8PaymentTermCode='" + U8PaymentTermCode + "' ");
            return  (strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._Payment model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.U8PaymentTermCode != null)
            {
                strSql1.Append("U8PaymentTermCode,");
                strSql2.Append("'" + model.U8PaymentTermCode + "',");
            }
            if (model.PaymentTermCode != null)
            {
                strSql1.Append("PaymentTermCode,");
                strSql2.Append("'" + model.PaymentTermCode + "',");
            }
            if (model.Remark != null)
            {
                strSql1.Append("Remark,");
                strSql2.Append("'" + model.Remark + "',");
            }
            if (model.CreaterUid != null)
            {
                strSql1.Append("CreaterUid,");
                strSql2.Append("'" + model.CreaterUid + "',");
            }
            if (model.CreaterDate != null)
            {
                strSql1.Append("CreaterDate,");
                strSql2.Append("'" + model.CreaterDate + "',");
            }
            strSql.Append("insert into _Payment(");
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
        public string Update(UFIDA.U8.UAP.CustomApp.ControlForm.Model._Payment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update _Payment set ");
            if (model.PaymentTermCode != null)
            {
                strSql.Append("PaymentTermCode='" + model.PaymentTermCode + "',");
            }
            else
            {
                strSql.Append("PaymentTermCode= null ,");
            }
            if (model.Remark != null)
            {
                strSql.Append("Remark='" + model.Remark + "',");
            }
            else
            {
                strSql.Append("Remark= null ,");
            }
            if (model.CreaterUid != null)
            {
                strSql.Append("CreaterUid='" + model.CreaterUid + "',");
            }
            else
            {
                strSql.Append("CreaterUid= null ,");
            }
            if (model.CreaterDate != null)
            {
                strSql.Append("CreaterDate='" + model.CreaterDate + "',");
            }
            else
            {
                strSql.Append("CreaterDate= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where U8PaymentTermCode='" + model.U8PaymentTermCode + "' ");
            return (strSql.ToString());
        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

