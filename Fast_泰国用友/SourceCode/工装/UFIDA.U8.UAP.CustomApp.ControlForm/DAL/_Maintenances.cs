using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_Maintenances
    /// </summary>
    public partial class _Maintenances
    {
        public _Maintenances()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._Maintenances model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.GUIDHead != null)
            {
                strSql1.Append("GUIDHead,");
                strSql2.Append("N'" + model.GUIDHead.ToString() + "',");
            }
            if (model.cCode != null)
            {
                strSql1.Append("cCode,");
                strSql2.Append("N'" + model.cCode + "',");
            }
            if (model.SerialNo != null)
            {
                strSql1.Append("SerialNo,");
                strSql2.Append("N'" + model.SerialNo + "',");
            }
            if (model.Remark != null)
            {
                strSql1.Append("Remark,");
                strSql2.Append("N'" + model.Remark + "',");
            }
            strSql.Append("insert into _Maintenances(");
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
        public string Update(UFIDA.U8.UAP.CustomApp.ControlForm.Model._Maintenances model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update _Maintenances set ");
            if (model.GUIDHead != null)
            {
                strSql.Append("GUIDHead=N'" + model.GUIDHead + "',");
            }
            else
            {
                strSql.Append("GUIDHead= null ,");
            }
            if (model.Remark != null)
            {
                strSql.Append("Remark=N'" + model.Remark + "',");
            }
            else
            {
                strSql.Append("Remark= null ,");
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

