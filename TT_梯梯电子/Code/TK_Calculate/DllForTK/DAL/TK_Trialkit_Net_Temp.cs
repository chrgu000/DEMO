using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DllForTK.DAL
{
    /// <summary>
    /// 数据访问类:TK_Trialkit_Net_Temp
    /// </summary>
    public partial class TK_Trialkit_Net_Temp
    {
        public TK_Trialkit_Net_Temp()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(DllForTK.Model.TK_Trialkit_Net_Temp model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
           
            if (model.sTKVersion != null)
            {
                strSql1.Append("sTKVersion,");
                strSql2.Append("'" + model.sTKVersion + "',");
            }
            if (model.sTKVersionType != null)
            {
                strSql1.Append("sTKVersionType,");
                strSql2.Append("" + model.sTKVersionType + ",");
            }
            if (model.PartID != null)
            {
                strSql1.Append("PartID,");
                strSql2.Append("'" + model.PartID + "',");
            }
            if (model.NetQty != null)
            {
                strSql1.Append("NetQty,");
                strSql2.Append("" + model.NetQty + ",");
            }
            if (model.dDate != null)
            {
                strSql1.Append("dDate,");
                strSql2.Append("'" + model.dDate + "',");
            }
            if (model.ProType != null)
            {
                strSql1.Append("ProType,");
                strSql2.Append("'" + model.ProType + "',");
            }
            strSql.Append("insert into TK_Trialkit_Net_Temp(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            return (strSql.ToString());
        }
        
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

