using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_科目对照
    /// </summary>
    public partial class _科目对照
    {
        public _科目对照()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public string Exists(string 年度, string 对照科目,string iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from _科目对照");
            strSql.Append(" where 年度=" + 年度 + " and 对照科目='" + 对照科目 + "' ");
            if (iID != "")
            {
                strSql.Append(" and iID<>" + iID + " ");
            }
            return (strSql.ToString());
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._科目对照 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.年度 != null)
            {
                strSql1.Append("年度,");
                strSql2.Append("'" + model.年度 + "',");
            }
            if (model.会计科目 != null)
            {
                strSql1.Append("会计科目,");
                strSql2.Append("'" + model.会计科目 + "',");
            }
            if (model.对照科目 != null)
            {
                strSql1.Append("对照科目,");
                strSql2.Append("'" + model.对照科目 + "',");
            }
            if (model.Remark != null)
            {
                strSql1.Append("Remark,");
                strSql2.Append("'" + model.Remark + "',");
            }
            if (model.RemarkJ != null)
            {
                strSql1.Append("RemarkJ,");
                strSql2.Append("'" + model.RemarkJ + "',");
            }
            if (model.RemarkD != null)
            {
                strSql1.Append("RemarkD,");
                strSql2.Append("'" + model.RemarkD + "',");
            }
            strSql.Append("insert into _科目对照(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return (strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(UFIDA.U8.UAP.CustomApp.ControlForm.Model._科目对照 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update _科目对照 set ");
            if (model.年度 != null)
            {
                strSql.Append("年度='" + model.年度 + "',");
            }
            if (model.会计科目 != null)
            {
                strSql.Append("会计科目='" + model.会计科目 + "',");
            }
            if (model.对照科目 != null)
            {
                strSql.Append("对照科目='" + model.对照科目 + "',");
            }
            if (model.Remark != null)
            {
                strSql.Append("Remark='" + model.Remark + "',");
            }
            else
            {
                strSql.Append("Remark= null ,");
            }
            if (model.RemarkJ != null)
            {
                strSql.Append("RemarkJ='" + model.RemarkJ + "',");
            }
            else
            {
                strSql.Append("RemarkJ= null ,");
            }
            if (model.RemarkD != null)
            {
                strSql.Append("RemarkD='" + model.RemarkD + "',");
            }
            else
            {
                strSql.Append("RemarkD= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where iID=" + model.iID + "");
            return (strSql.ToString());
        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

