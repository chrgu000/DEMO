using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace 系统服务
{
    public static class 收款利润
    {
        public static void Get(string SoAutoID, System.Collections.ArrayList aList)
        {
            string sSQL = "";
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            sSQL = @"select 2 as iType,a.cSOCode as cTypeCode,a.dDate,a.cCusCode,a.cPersonCode,a.cDepCode,a.ECode,a.cPayCode,a.iMoney,sum(c.iReMoney) as iReMoney,AutoID ,订单利润,订单金额 ,最后收款时间,利润分成,a.ID
from (select a.ID,a.cSOCode,a.dDate,a.cCusCode,a.cPersonCode,a.cDepCode,a.ECode,a.cPayCode,sum(b.iMoney+isnull(r.iMoney,0)-isnull(h.iMoney,0))  as iMoney,a.cSTCode,b.AutoID,a.D3 订单利润,b.iMoney as 订单金额,a.D2 as 利润分成 from dbo.SO_SOMain a inner join dbo.SO_SODetails b on a.id = b.id 
left join (select SoAutoID,sum(isnull(iQuantity,0)) as iQuantity,sum(isnull(iNum,0)) as iNum ,sum(isnull(iNatMoney,0)) as iNatMoney ,sum(isnull(iMoney,0)) as iMoney  from SO_SOReturns group by SoAutoID) r on b.AutoID=r.SoAutoID  
left join (select SoAutoID,sum(isnull(iMoney,0)) as iMoney  from SaleVerifications group by SoAutoID) h on b.AutoID=h.SoAutoID 
where isnull(a.dVerifysysPerson,'') <> '' and isnull(a.dClosesysPerson,'') = ''   group by a.ID,b.AutoID,a.cSOCode,a.dDate,a.cCusCode,a.cPersonCode,a.cDepCode,a.ECode,a.cPayCode,a.cSTCode,a.D3,b.iMoney,a.D2) a 
left join (select sum(isnull(iMoneyNow,0)) as iReMoney,max(dDate) as 最后收款时间,cCusCode,cTypeCode from SO_CloseBill a inner join SO_CloseBillDetails b on a.id = b.id group by cCusCode,cTypeCode) c on c.cCusCode = a.cCusCode and c.cTypeCode = a.cSOCode 
where 1=1 and a.AutoID=" + SoAutoID + " group by a.cSOCode,a.dDate,a.cCusCode,a.cPersonCode,a.cDepCode,a.ECode,a.cPayCode,a.iMoney ,a.AutoID,订单利润,订单金额,最后收款时间,利润分成,a.ID having sum(isnull(a.iMoney,0)) <= sum(isnull(c.iReMoney,0))";
            DataTable dtqty = clsSQLCommond.ExecQuery(sSQL);
            if (dtqty.Rows.Count > 0)
            {
                sSQL = @"select a.cSOCode,a.cDepCode,cPersonCode,a.cSTCode,
(case when a.cSTCode='01' then 0.7 else 1 end)*
(
b.iMoney-isnull(b.iQuantity*Cost,0)-
(case when a.cSTCode='02' then 0.9 else 1 end)*ISNULL(e.iMoney,0)--子件金额
-isnull(f.iMoney*a.D5,0)--业务费用
)-isnull(r.F5,0) as iMoney from SO_SOMain a left join SO_SODetails b on a.ID=b.ID 
--left join (select SoAutoID,sum(-b.iQuantity) as iQuantity from SO_SOReturn a left join SO_SOReturns b on a.ID=b.ID where a.dVerifysysTime is not null  group by SoAutoID) c on b.AutoID=c.SoAutoID 
left join (select sum(iQuantity) as iQuantity,sum(isnull(iMoney,0)) as iMoney,sum(case when B3=1 then -F5 when B3=1 then F5 end) as F5,SoAutoID from RdRecord a inner join RdRecords b on a.id = b.id left join RdStyle r on a.cRSCode=r.cRSCode where 收发标志=0 group by SoAutoID) r on r.SoAutoID = b.AutoID 
left join (select a.AutoID,sum(a.D1*a.iQuantity) as iMoney from SO_SOSublist a left join Inventory b on a.cInvCode=b.cInvCode where b.cInvClassCode<>'03' group by a.AutoID) e on b.AutoID=e.AutoID 
left join (select ID,sum((DD1*DD2)) as iMoney from SO_SOMainCommissiion group by ID) f on f.ID=a.ID
left join Inventory i on b.cInvCode=i.cInvCode WHERE b.AutoID='" + SoAutoID + "'";
                DataTable dt2 = clsSQLCommond.ExecQuery(sSQL);
                decimal 订单利润 = 系统服务.规格化.ReturnDecimal(dt2.Rows[0]["iMoney"]);
                decimal 订单金额 = 系统服务.规格化.ReturnDecimal(dtqty.Rows[0]["订单金额"]);
                decimal 收款金额 = 系统服务.规格化.ReturnDecimal(dtqty.Rows[0]["iMoney"]);
                decimal 利润分成 = 系统服务.规格化.ReturnDecimal(dtqty.Rows[0]["利润分成"]);
                string 最后收款时间 = dtqty.Rows[0]["最后收款时间"].ToString().Trim();

                decimal 个人利润 = 系统服务.规格化.ReturnDecimal(订单利润 * 利润分成);

                string id = dtqty.Rows[0]["ID"].ToString().Trim();

                sSQL = "update SO_SOMain set D4='" + 订单利润 + "',Date1='" + 最后收款时间 + "',D6='" + 个人利润 + "' where ID='" + id + "'";
                aList.Add(sSQL);

            }
        }

    }
}
