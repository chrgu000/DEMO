using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using TH.WebService.BaseClass;

namespace TH.DAL
{
    /// <summary>
    /// 数据访问类:生产订单产品工序
    /// </summary>
    public partial class 生产订单产品工序
    {
        public 生产订单产品工序()
        { }
        #region  Method
        /// <summary>
        /// 获得生产订单产品工序
        /// </summary>
        public DataTable dt生产订单产品工序(string sWorkIDs)
        {
            string sSQL = @"
SELECT   *
FROM         生产订单产品工序
where WorkDetailsID = @WorkDetailsID
order by WorkProcessNo
";
            sSQL = sSQL.Replace("@WorkDetailsID", sWorkIDs);
            return DbHelperSQL.Query(sSQL);
        }


        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

