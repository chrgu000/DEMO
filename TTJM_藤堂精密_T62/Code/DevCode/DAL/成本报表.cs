using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using FrameBaseFunction;

namespace TH.DAL
{
    /// <summary>
    /// 数据访问类:基础档案列表
    /// </summary>
    public partial class 成本报表
    {
        public 成本报表()
        { }

        _GetBaseData _GetBase = new _GetBaseData();

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable Get成本产品数量核对表(DateTime dDate1)
        {
            string sSQL = @"


DECLARE @dDate1 DATE
DECLARE @dDate2 DATE
DECLARE @dDate3 DATE

SET @dDate1 = '111111'
SET @dDate2 = DATEADD(month,1,@dDate1)

set @dDate3 = DATEADD(month,-1,@dDate1)


select a.cinvcode as 存货编码,sum(a.fQuantity) as 生产订单数量
	,null as 落料,null as 入库,null as 未完工,null as 材料领用,null as 上期盘点,null as 本期盘点
INTO #a
from @u8.PP_POMain a INNER JOIN @u8.PP_ProductPO b ON a.ID = b.ID
	inner join @u8.Inventory c on a.cInvCode = c.cInvCode
where b.dDate >= @dDate1 and b.dDate < @dDate2
group by a.cinvcode

insert into #a
select s1,null,sum(isnull(d14,0) ) as iQty,null,null,null,null,null
from SystemDB_TTJM.dbo.工序报表 
where Date1 >= @dDate1 and  Date1 < @dDate2
	and sType = '落料'
group by s1

INSERT INTO #a(存货编码,入库)
select b.cInvCode,SUM(b.iQuantity) AS iQty
from @u8.rdrecord a inner join @u8.RdRecords b on a.ID = b.ID
	INNER JOIN @u8.Inventory c ON b.cinvcode = c.cInvCode
where a.dDate  >= @dDate1 and a.dDate < @dDate2 AND cVouchType = '10' AND c.cinvccode LIKE '04%'
GROUP BY b.cInvCode	


INSERT INTO #a(存货编码,材料领用)
SELECT D.cInvCode,SUM(B.iQuantity) AS iQty
FROM @u8.RdRecord A INNER JOIN @u8.RdRecords B ON A.ID = B.ID
	LEFT JOIN @u8.PP_PODetails C ON C.SubID = B.iMPoIds
	LEFT JOIN @u8.PP_POMain d ON c.MainID = d.ID
	LEFT JOIN @u8.Inventory E ON E.cinvcode = B.cInvCode
WHERE A.dDate  >= @dDate1 and a.dDate < @dDate2
	AND cVouchType = '11'
	AND E.cInvCCode LIKE '01010%'
	AND ISNULL(d.cInvCode,'') <> ''
GROUP BY D.cInvCode 

insert into #a(存货编码,上期盘点)
select 存货编码,SUM(合计)
from  在产品盘点表
where YEAR(盘点年月) = YEAR(@dDate3) and MONTH(盘点年月) = MONTH(@dDate3) 
group by 存货编码

insert into #a(存货编码,本期盘点)
select 存货编码,SUM(合计)
from  在产品盘点表
where YEAR(盘点年月) = YEAR(@dDate1) and MONTH(盘点年月) = MONTH(@dDate1) 
group by 存货编码

select 存货编码,b.cInvAddCode AS 型号,b.cInvName as 存货名称,b.cInvStd as 存货规格
    ,sum(生产订单数量) as 生产订单数量,sum(落料) as 落料
	 ,SUM(入库) AS 入库,SUM(材料领用) AS 材料领用
	 ,ISNULL(sum(生产订单数量),0) - ISNULL(sum(落料),0) AS 订单落料差
	 ,ISNULL(sum(落料),0) - ISNULL(SUM(入库),0) AS 落料入库差
	 ,sum(上期盘点) as 上期盘点
	 ,sum(本期盘点) as 本期盘点
	 ,sum(生产订单数量) + sum(上期盘点) - SUM(入库) as 理论结存
from #a
	LEFT JOIN @u8.inventory b ON #a.存货编码 = b.cInvCode
group by 存货编码,b.cInvAddCode,b.cInvName,b.cInvStd
order by 存货编码 ,b.cInvAddCode


";

            sSQL = sSQL.Replace("111111", dDate1.ToString("yyyy-MM-dd"));
            sSQL = sSQL.Replace("@u8", "UFDATA_" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3) + "_" + dDate1.Year + ".");
            

            return DbHelperSQL.Query(sSQL);
        }
    }
}

