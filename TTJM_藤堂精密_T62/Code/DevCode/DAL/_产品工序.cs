using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using FrameBaseFunction;


namespace TH.DAL
{
    /// <summary>
    /// 数据访问类:_产品工序
    /// </summary>
    public partial class _产品工序
    {
        public _产品工序()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.Model._产品工序 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.iID != null)
            {
                strSql1.Append("iID,");
                strSql2.Append("" + model.iID + ",");
            }
            if (model.cInvCode != null)
            {
                strSql1.Append("cInvCode,");
                strSql2.Append("'" + model.cInvCode + "',");
            }
            if (model.iRow != null)
            {
                strSql1.Append("iRow,");
                strSql2.Append("'" + model.iRow + "',");
            }
            if (model.WorkProcessNo != null)
            {
                strSql1.Append("WorkProcessNo,");
                strSql2.Append("'" + model.WorkProcessNo + "',");
            }
            if (model.Remark != null)
            {
                strSql1.Append("Remark,");
                strSql2.Append("'" + model.Remark + "',");
            }
            if (model.CreateUid != null)
            {
                strSql1.Append("CreateUid,");
                strSql2.Append("'" + model.CreateUid + "',");
            }
            if (model.CreateDate != null)
            {
                strSql1.Append("CreateDate,");
                strSql2.Append("'" + model.CreateDate + "',");
            }
            strSql.Append("insert into _产品工序(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            return (strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(string cInvCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from _产品工序 ");
            strSql.Append(" where cInvCode='" + cInvCode + "' ");
            return (strSql.ToString());
        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

