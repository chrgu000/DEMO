using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace Base.DAL
{
    /// <summary>
    /// 数据访问类:Inventory_History
    /// </summary>
    public partial class Inventory_History
    {
        public Inventory_History()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Base.Model.Inventory_History model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
          
            if (model.cInvCode != null)
            {
                strSql1.Append("cInvCode,");
                strSql2.Append("'" + model.cInvCode + "',");
            }
            if (model.cInvNameOld != null)
            {
                strSql1.Append("cInvNameOld,");
                strSql2.Append("'" + model.cInvNameOld + "',");
            }
            if (model.cInvStdOld != null)
            {
                strSql1.Append("cInvStdOld,");
                strSql2.Append("'" + model.cInvStdOld + "',");
            }
            if (model.cInvNameNew != null)
            {
                strSql1.Append("cInvNameNew,");
                strSql2.Append("'" + model.cInvNameNew + "',");
            }
            if (model.cInvStdNew != null)
            {
                strSql1.Append("cInvStdNew,");
                strSql2.Append("'" + model.cInvStdNew + "',");
            }
            if (model.CreateUid != null)
            {
                strSql1.Append("CreateUid,");
                strSql2.Append("'" + model.CreateUid + "',");
            }
            if (model.dtmCreate != null)
            {
                strSql1.Append("dtmCreate,");
                strSql2.Append("getdate(),");
            }
            strSql.Append("insert into @u8.Inventory_History(");
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

