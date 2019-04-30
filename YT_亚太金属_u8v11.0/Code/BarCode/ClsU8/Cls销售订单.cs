using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using ClsBaseClass;

namespace ClsU8
{
    public class Cls销售订单
    {

        public string dt销售订单信息(string sCode)
        {
            string s = "";

            try
            {
                string sSQL = "select * from SO_SOMain a inner join SO_SODetails b on a.cSOCode  = b.cSOCode  where a.cSOCode  = '" + sCode.Trim() + "' ";
                DataTable dt = SqlHelper.ExecuteDataset(ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).Tables[0];
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string dt销售订单明细信息(string sCode, string sWhere)
        {
            string s = "";

            try
            {
                string sSQL = @"
select distinct * ,d.Autoid as 条形码
from SO_SOMain a inner join SO_SODetails b on a.ID = b.ID
    inner join Inventory c on b.cInvCode = c.cInvCode
    left join dbo._BarCodeInventory d on b.cInvCode = d.cInvCode and ISNULL(b.cFree1,'') = ISNULL(d.cFree1,'')
        and ISNULL(b.cFree2,'') = ISNULL(d.cFree2,'') and ISNULL(b.cFree3,'') = ISNULL(d.cFree3,'') and ISNULL(b.cFree4,'') = ISNULL(d.cFree4,'') and ISNULL(b.cFree5,'') = ISNULL(d.cFree5,'')
        and ISNULL(b.cFree6,'') = ISNULL(d.cFree6,'') and ISNULL(b.cFree7,'') = ISNULL(d.cFree7,'') and ISNULL(b.cFree8,'') = ISNULL(d.cFree8,'') and ISNULL(b.cFree9,'') = ISNULL(d.cFree9,'')
        and ISNULL(b.cFree10,'') = ISNULL(d.cFree10,'') --and ISNULL(b.cbatch,'') = ISNULL(d.cbatch,'')
where a.cSOCode = '111111' and 1=1
";

                sSQL = sSQL.Replace("111111", sCode.Trim());
                sSQL = sSQL.Replace("1=1", sWhere.Trim());
                DataTable dt = SqlHelper.ExecuteDataset(ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).Tables[0];
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }
    }
}
