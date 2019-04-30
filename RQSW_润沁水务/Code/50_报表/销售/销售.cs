using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace 报表
{
    public static class 销售
    {
        public static DataTable Table(string sdate, string edate)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select b.cDepCode,cPersonCode,a.iMoney from SO_SODetails a left join SO_SOMain b on a.ID=b.ID 
            where 1=1 and b.dVerifysysTime is not null
            union all 
            select b.cDepCode,cPersonCode,a.iMoney from SO_SOReturns a left join SO_SOReturn b on a.ID=b.ID 
            where 1=1 and b.dVerifysysTime is not null
            union all 
            select b.cDepCode,cPersonCode,-a.iMoney from RdRecord b left join RdRecords a on a.ID=b.ID left join RdStyle r on b.cRSCode=r.cRSCode 
            where 1=1 and r.S1=1 and B1=1 and b.dVerifysysTime is not null";

            sSQL = sSQL.Replace("1=1", "1=1 and b.dDate>='" + sdate + "' and b.dDate<='" + edate + "' ");
            return clsSQLCommond.ExecQuery(sSQL);
        }



    }
}
