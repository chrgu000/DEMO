
ALTER view [dbo].[_TH_GET_FLD]
AS


select a.iID as  FPIDs,a.发票号码 as cSBVCode,a.发票日期 as dDate,a.业务员编码 as cPersonCode,a.业务员名称 as cPersonName
	,null as cDepCode,null as cDepName,a.客户编码 as cCusCode,a.客户名称 as cCusName,a.客户名称 as cCusAbbName
	,a.货物编码 as cInvCode,a.货物名称 as cInvName,a.规格型号 as cInvStd,a.单价 as iTaxUnitPrice,a.开票数量 as iQuantity,a.金额 as iSum
	,a.发货单号 as cDLCode
	,cast(null as decimal(16,2)) as iTaxUnitPriceFH
	,cast(null as decimal(16,2)) as iTaxRateCJ
	,cast(null as decimal(16,2)) as iTaxCJ
	,cast(null as decimal(16,2)) as iMoneyFL
	,a.[代码商编码] as DLS,a.代理商名称 as DLSName
	,a.省份编码 as cDCCode ,a.省份名称 as  cDCName 
	,cast(case when isnull(a.金额,0) < 0 then 1 else 0 end as bit) as bRed
from [dbo].[_发票_sap] a
where a.发票号码 in (select 发票号码 from [_回款_sap])
	and isnull(a.金额,0) <> 0


