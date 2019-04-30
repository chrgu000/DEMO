using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace 业务.DAL
{
    /// <summary>
    /// 数据访问类:发射器档案设置
    /// </summary>
    public partial class 发射器档案设置
    {
        public 发射器档案设置()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(业务.Model.发射器档案设置 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.发射器ID != null)
            {
                strSql1.Append("发射器ID,");
                strSql2.Append("" + model.发射器ID + ",");
            }
            if (model.CMITiID != null)
            {
                strSql1.Append("CMITiID,");
                strSql2.Append("'" + model.CMITiID + "',");
            }
            if (model.检验工位 != null)
            {
                strSql1.Append("检验工位,");
                strSql2.Append("'" + model.检验工位 + "',");
            }
            if (model.备注 != null)
            {
                strSql1.Append("备注,");
                strSql2.Append("'" + model.备注 + "',");
            }
            strSql.Append("insert into 发射器档案设置(");
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
        public string Update(业务.Model.发射器档案设置 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 发射器档案设置 set ");
            if (model.CMITiID != null)
            {
                strSql.Append("CMITiID='" + model.CMITiID + "',");
            }
            else
            {
                strSql.Append("CMITiID= null ,");
            }
            if (model.检验工位 != null)
            {
                strSql.Append("检验工位='" + model.检验工位 + "',");
            }
            if (model.备注 != null)
            {
                strSql.Append("备注='" + model.备注 + "',");
            }
            else
            {
                strSql.Append("备注= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where iID=" + model.iID + "");
            return (strSql.ToString());

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(int iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from 发射器档案设置 ");
            strSql.Append(" where iID=" + iID + "");
            return (strSql.ToString());

        }	

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

