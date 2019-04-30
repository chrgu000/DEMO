using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace TH.DAL
{
    /// <summary>
    /// 数据访问类:_产品工序流转统计
    /// </summary>
    public partial class _产品工序流转统计
    {
        public _产品工序流转统计()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public string Exists(string 存货编码, DateTime 期间)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from @u8._产品工序流转统计");
            strSql.Append(" where 存货编码='" + 存货编码 + "' and 期间='" + 期间 + "' ");
            return (strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.Model._产品工序流转统计 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.存货编码 != null)
            {
                strSql1.Append("存货编码,");
                strSql2.Append("'" + model.存货编码 + "',");
            }
            if (model.期间 != null)
            {
                strSql1.Append("期间,");
                strSql2.Append("'" + model.期间 + "',");
            }
            if (model.期初数量 != null)
            {
                strSql1.Append("期初数量,");
                strSql2.Append("" + model.期初数量 + ",");
            }
            if (model.期初金额 != null)
            {
                strSql1.Append("期初金额,");
                strSql2.Append("" + model.期初金额 + ",");
            }
            if (model.领用数量 != null)
            {
                strSql1.Append("领用数量,");
                strSql2.Append("" + model.领用数量 + ",");
            }
            if (model.领用金额 != null)
            {
                strSql1.Append("领用金额,");
                strSql2.Append("" + model.领用金额 + ",");
            }
            if (model.完工数量 != null)
            {
                strSql1.Append("完工数量,");
                strSql2.Append("" + model.完工数量 + ",");
            }
            if (model.完工金额 != null)
            {
                strSql1.Append("完工金额,");
                strSql2.Append("" + model.完工金额 + ",");
            }
            if (model.在制数量 != null)
            {
                strSql1.Append("在制数量,");
                strSql2.Append("" + model.在制数量 + ",");
            }
            if (model.在制金额 != null)
            {
                strSql1.Append("在制金额,");
                strSql2.Append("" + model.在制金额 + ",");
            }
            strSql.Append("insert into @u8._产品工序流转统计(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return (strSql.ToString());
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(string 存货编码, DateTime 期间)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from @u8._产品工序流转统计 ");
            strSql.Append(" where 存货编码='@存货编码' and 期间='@期间' ");
            string sSQL = strSql.ToString();
            sSQL = sSQL.Replace("@存货编码", 存货编码);
            sSQL = sSQL.Replace("@期间", 期间.ToString("yyyy-MM-dd"));
            return sSQL;
        }


        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

