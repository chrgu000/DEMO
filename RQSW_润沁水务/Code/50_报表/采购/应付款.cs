using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace 报表
{
    public static class 应付款
    {
        public static DataTable Table(string endtime, string cCusCode)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = GetSql();
            sSQL = sSQL.Replace("1=1", "1=1 and a.dDate<='" + DateTime.Parse(endtime).ToString("yyyy-MM-dd") + "'");
            sSQL = sSQL.Replace("2=2", "2=2 and Date1<='" + DateTime.Parse(endtime).ToString("yyyy-MM-dd") + "'");

            if (cCusCode != "")
            {
                sSQL = sSQL.Replace("4=4", "4=4 and p.cVenCode='" + cCusCode + "'");
            }
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static string GetSql()
        {
            return @"select p.cVenCode,sum(p.iMoney) as iMoney from 
(
SELECT    a.cVenCode,b.iMoney,a.dDate 
FROM   PurBillVouch AS a LEFT OUTER JOIN PurBillVouchs AS b ON a.ID = b.ID  where 1=1 and a.dVerifysysTime is not null 
union all 
select S1 as cVenCode,D1 as iMoney,Date1 as  dDate 
from AP_First where 2=2 
union all 
select cVenCode,-iAmount,dDate from PO_CloseBill a where 1=1  and dVerifysysTime is not null 
) p where 4=4 group by p.cVenCode having sum(p.iMoney)<>0";
        }

        

        public static DataTable Table(string starttime,string endtime, string cCusCode, string cPersonCode)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = GetSql();
            sSQL = sSQL.Replace("1=1", "1=1 and a.dDate<='" + DateTime.Parse(starttime).ToString("yyyy-MM-dd") + "' and a.dDate<='" + DateTime.Parse(endtime).ToString("yyyy-MM-dd") + "'");
            sSQL = sSQL.Replace("2=2", "2=2 and Date1<='" + DateTime.Parse(starttime).ToString("yyyy-MM-dd") + "' and Date1<='" + DateTime.Parse(endtime).ToString("yyyy-MM-dd") + "'");

            if (cCusCode != "")
            {
                sSQL = sSQL.Replace("4=4", "4=4 and p.cCusCode='" + cCusCode + "'");
            }
            if (cPersonCode != "")
            {
                sSQL = sSQL.Replace("4=4", "4=4 and p.cPersonCode='" + cPersonCode + "'");
            }
            return clsSQLCommond.ExecQuery(sSQL);
        }
    }
}
