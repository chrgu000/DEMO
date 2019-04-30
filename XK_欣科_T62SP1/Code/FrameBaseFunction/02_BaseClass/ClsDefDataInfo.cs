using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FrameBaseFunction
{

    /// <summary>
    /// 基础数据定义
    /// </summary>
    public class ClsDefDataInfo
    {
       /// <summary>
       /// 档案换算率
       /// </summary>
       /// <param name="sInvCode"></param>
       /// <returns></returns>
        public static decimal Return换算率(string sInvCode)
        {
            FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
            decimal iRet = -1;
            try
            {
                string sSQL = "select c.iChangRate/b.iChangRate " +
                        "from @u8.inventory a inner join @u8.ComputationUnit  b on a.cComUnitCode = b.cComunitCode " +
                        "	inner join @u8.ComputationUnit c on a.cAssComUnitCode = c.cComunitCode " +
                        "where a.cInvCode = '" + sInvCode + "'";
                iRet = BaseFunction.BaseFunction.ReturnDecimal(clsSQLCommond.ExecGetScalar(sSQL));
            }
            catch
            {

            }
            return iRet;
        }

        /// <summary>
        /// 结存换算率
        /// </summary>
        /// <param name="sInvCode"></param>
        /// <returns></returns>
        public static decimal Return换算率(string sInvCode,string sWhCode)
        {
            FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
            decimal iRet = -1;
            try
            {
                string sSQL = "select iQuantity/iNum from @u8.CurrentStock where cInvCode = '" + sInvCode + "' and cWhCode = '" + sWhCode + "'";
                iRet = BaseFunction.BaseFunction.ReturnDecimal(clsSQLCommond.ExecGetScalar(sSQL));
            }
            catch
            {

            }
            return iRet;
        }

        public static string s出货周(string sSOCode,string iRow)
        {
            string s = "";
            try
            {
                FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
                string sSQL = @"
select a.cSOCode,b.iRowNo,c.*
from @u8.so_somain a inner join @u8.SO_SODetails b on a.ID = b.id
	inner join dbo.外销订单总表 c on b.AutoID = c.销售订单子表ID and 帐套号 = '200'
where 1=1	and isnull(c.出货周,'') <> ''
order by a.cSOCode,b.iRowNo,c.年度
";

                sSQL = sSQL.Replace("200", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3));
                sSQL = sSQL.Replace("2013", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4));
                sSQL = sSQL.Replace("1=1", "1=1 and a.cSOCode = '" + sSOCode + "' and b.iRowNo = '" + iRow + "' ");

                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count < 1)
                {

                }
                else
                {
                    s = dt.Rows[0]["出货周"].ToString().Trim();
                }
            }
            catch (Exception ee)
            {

            }
            return s;
        }
    }
}
