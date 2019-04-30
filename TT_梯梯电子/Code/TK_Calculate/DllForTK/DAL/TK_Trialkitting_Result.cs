using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DllForTK.DAL
{
    /// <summary>
    /// 数据访问类:TK_Trialkitting_Result
    /// </summary>
    public partial class TK_Trialkitting_Result
    {
        public TK_Trialkitting_Result()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(DllForTK.Model.TK_Trialkitting_Result model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.Guid != null)
            {
                strSql1.Append("Guid,");
                strSql2.Append("N'" + Guid.NewGuid().ToString() + "',");
            }
            if (model.sTKVersion != null)
            {
                strSql1.Append("sTKVersion,");
                strSql2.Append("N'" + model.sTKVersion + "',");
            }
            if (model.sTKVersionType != null)
            {
                strSql1.Append("sTKVersionType,");
                strSql2.Append("N'" + model.sTKVersionType + "',");
            }
            if (model.sDataVersion != null)
            {
                strSql1.Append("sDataVersion,");
                strSql2.Append("N'" + model.sDataVersion + "',");
            }
            if (model.CreateUid != null)
            {
                strSql1.Append("CreateUid,");
                strSql2.Append("N'" + model.CreateUid + "',");
            }
            if (model.dtmCreate != null)
            {
                strSql1.Append("dtmCreate,");
                strSql2.Append("N'" + model.dtmCreate + "',");
            }
            if (model.Remark != null)
            {
                strSql1.Append("Remark,");
                strSql2.Append("N'" + model.Remark + "',");
            }
            if (model.DataFrom != null)
            {
                strSql1.Append("DataFrom,");
                strSql2.Append("" + model.DataFrom + ",");
            }
            strSql.Append("insert into TK_Trialkitting_Result(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return (strSql.ToString());
        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

