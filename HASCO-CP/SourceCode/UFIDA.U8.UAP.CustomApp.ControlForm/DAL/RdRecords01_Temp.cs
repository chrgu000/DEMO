using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:RdRecords01_Temp
    /// </summary>
    public partial class RdRecords01_Temp
    {
        public RdRecords01_Temp()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public string Exists(long AutoID, long ID, string cInvCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from RdRecords01_Temp");
            strSql.Append(" where AutoID=" + AutoID + " and ID=" + ID + " and cInvCode='" + cInvCode + "' ");
            return (strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model.RdRecords01_Temp model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();

            if (model.PONO != null)
            {
                strSql1.Append("PONO,");
                strSql2.Append("'" + model.PONO + "',");
            }
            if (model.cInvCode != null)
            {
                strSql1.Append("cInvCode,");
                strSql2.Append("'" + model.cInvCode + "',");
            }
            if (model.iQuantity != null)
            {
                strSql1.Append("iQuantity,");
                strSql2.Append("" + model.iQuantity + ",");
            }
            strSql.Append("insert into RdRecords01_Temp(");
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
        public string Delete(long AutoID, long ID, string cInvCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from RdRecords01_Temp ");
            strSql.Append(" where AutoID=" + AutoID + " and ID=" + ID + " and cInvCode='" + cInvCode + "' ");
            return (strSql.ToString());
        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

