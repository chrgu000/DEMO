using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using FrameBaseFunction;

namespace TH.DAL
{
    /// <summary>
    /// 数据访问类:生产排产发料计划
    /// </summary>
    public partial class 生产排产产线负荷
    {
        DateTime d生产计划考虑起始日期 = Convert.ToDateTime("2014-6-10");

        public DataTable GetPCList(DateTime dTime1, DateTime dTime2)
        {
            string sCol = "";
            while (dTime1 <= dTime2)
            {
                sCol = sCol + ",sum(case when a.计划生产日期 = '" + dTime1.ToString("yyyy-MM-dd") + "' then 工时 end) as  工时" + dTime1.ToString("yyMMdd");
                sCol = sCol + ",cast(sum(case when a.计划生产日期 = '" + dTime1.ToString("yyyy-MM-dd") + "' then 工时 end) / case when isnull(b.PeopleNO,0) = 0 then 1 else b.PeopleNO end as decimal(16,2)) as 人均工时" + dTime1.ToString("yyMMdd");

                dTime1 = dTime1.AddDays(1);
            }

            string sSQL = @"
select b.[LineNo] as 产线编码,b.LineName as 产线
	111111
from  dbo.ProductionLine b
    left join [SystemDB_SY].[dbo].[生产日计划] a on a.产线 = b.[LineNo]
group by b.[LineNo],b.LineName,b.PeopleNO
order by b.[LineNo]
";
            sSQL = sSQL.Replace("111111", sCol);

            return DbHelperSQL.Query(sSQL);
        }


        /// <summary>
        /// 获得生产排产发料默认天数
        /// </summary>
        public int GetPCDays()
        {
            int i = 0;
            string sSQL = "select * from dbo._Code where sType = '生产排产默认天数'";
            DataTable dt = DbHelperSQL.Query(sSQL);
            i = BaseFunction.BaseFunction.ReturnInt(dt.Rows[0]["cCode"]);

            return i;
        }


     
        public DateTime? GetMaxDate()
        {
            string sSQL = "select max(排产日期) from 生产日计划 where 1=1";
            DateTime? d = BaseFunction.BaseFunction.ReturnDate(DbHelperSQL.Query(sSQL).Rows[0][0]);
            return d;
        }


        public DataTable GetLine()
        {
            string sSQL = "select [LineNo],LineName from dbo.ProductionLine order by [LineNo]";
            return DbHelperSQL.Query(sSQL);
        }
    }
}

