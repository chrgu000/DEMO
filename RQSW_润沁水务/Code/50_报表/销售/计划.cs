using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace 报表
{
    public static class 计划
    {
        public static DataTable 周计划出货(string s年,string s月, string s周)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = "select  iID, S1, S3, S5, cast(D1 as decimal(18, 2)) as D1,cast(D2 as decimal(18, 2)) as  D2, I1, I2, I3, Date1, Date2 from SAPlan where I1=3 and I2='" + s月 + "' and I3='" + s周 + "' and s5 = '" + s年 + "' ";
            return clsSQLCommond.ExecQuery(sSQL);
        }


        public static DataTable 周累计计划出货(string s年, string s月, string s周)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = "select  iID, S1, S3, S5,cast(D1 as decimal(18, 2)) as D1,cast(D2 as decimal(18, 2)) as D2, I1, I2, I3, Date1, Date2 from SAPlan where I1=3 and I2='" + s月 + "' and I3<='" + s周 + "' and s5 = '" + s年 + "' ";
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static DataTable 月计划出货(string s年,string s月)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"
select  iID, S1, S3, S5, cast(D1 as decimal(18, 2)) as D1,cast(D2 as decimal(18, 2)) as D2, I1, I2, I3, Date1, Date2,
            cast(case when D2*0.7>10000 then 10000 else  D2*0.7 end as decimal(18, 2))  保底量 
from SAPlan 
where I1=2 and I2='" + s月 + "'  and s5 = '" + s年 + "' ";
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static DataTable 季计划出货(string s年,string 月)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"
select  iID, S1, S3, S5, cast(D1 as decimal(18, 2)) as D1,cast(D2 as decimal(18, 2)) as D2, I1, I2, I3, Date1, Date2,
            cast(case when D2*0.7>10000 then 10000 else  D2*0.7 end as decimal(18, 2))  保底量 
from SAPlan 
where I1=2 and I2 in (" + 月 + ")  and s5 = '" + s年 + "' ";
            return clsSQLCommond.ExecQuery(sSQL);
        }

    }
}
