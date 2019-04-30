using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_SystemSet
    /// </summary>
    public partial class _SystemSet
    {
        public _SystemSet()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public string Exists(string cSTCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from _SystemSet");
            strSql.Append(" where cSTCode='" + cSTCode + "' ");
            return strSql.ToString();
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._SystemSet model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.cSTCode != null)
            {
                strSql1.Append("cSTCode,");
                strSql2.Append("'" + model.cSTCode + "',");
            }
            if (model.cWhCode != null)
            {
                strSql1.Append("cWhCode,");
                strSql2.Append("'" + model.cWhCode + "',");
            }
            if (model.cRdCode != null)
            {
                strSql1.Append("cRdCode,");
                strSql2.Append("'" + model.cRdCode + "',");
            }
            if (model.SAPCode != null)
            {
                strSql1.Append("SAPCode,");
                strSql2.Append("'" + model.SAPCode + "',");
            }
            if (model.SAPWorkCenter != null)
            {
                strSql1.Append("SAPWorkCenter,");
                strSql2.Append("'" + model.SAPWorkCenter + "',");
            }
            if (model.InternalOrder != null)
            {
                strSql1.Append("InternalOrder,");
                strSql2.Append("'" + model.InternalOrder + "',");
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
            strSql.Append("insert into _SystemSet(");
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
        public string Update(UFIDA.U8.UAP.CustomApp.ControlForm.Model._SystemSet model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update _SystemSet set ");
            if (model.cWhCode != null)
            {
                strSql.Append("cWhCode='" + model.cWhCode + "',");
            }
            else
            {
                strSql.Append("cWhCode= null ,");
            }
            if (model.cRdCode != null)
            {
                strSql.Append("cRdCode='" + model.cRdCode + "',");
            }
            else
            {
                strSql.Append("cRdCode= null ,");
            }
            if (model.SAPCode != null)
            {
                strSql.Append("SAPCode='" + model.SAPCode + "',");
            }
            else
            {
                strSql.Append("SAPCode= null ,");
            }
            if (model.SAPWorkCenter != null)
            {
                strSql.Append("SAPWorkCenter='" + model.SAPWorkCenter + "',");
            }
            else
            {
                strSql.Append("SAPWorkCenter= null ,");
            }
            if (model.InternalOrder != null)
            {
                strSql.Append("InternalOrder='" + model.InternalOrder + "',");
            }
            else
            {
                strSql.Append("InternalOrder= null ,");
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
            strSql.Append(" where cSTCode='" + model.cSTCode + "' ");
            return (strSql.ToString());
        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

