




select 
	case when pzlx = 2 then '银' when pzlx = 3 then '转' when pzlx = 1 then '现' end as 凭证类别
	, PZH as 凭证号,null as 行号,zy as 摘要,kmdm as 会计科目
	,j as 借方,d as 贷方
	,case when ISNULL(j,0) <> 0 then WBJE end as 外币借方,case when ISNULL(d,0) <> 0 then WBJE end as 外币贷方
	,null as 币种,HL as 汇率,BMRY as 部门编码,dep.cDepName as 部门名称
	,a.dqh, a.DWDM, b.pydm_,b.dwmc
	,cus.cCusName as 客户编码 ,cus.cCusName as 客户名称
	,ven.cVenCode as 供应商编码,ven.cVenName as 供应商名称
	,ZDY as 制单人,PZRQ as 制单日期,2016 as 年度,'01' as 期间
from dbo.z_pz01 a
	left join UFDATA_001_2016..Department dep on a.BMRY = dep.cDepCode
	left join dwtx b on a.DWDM = b.DWDM and a.dqh = b.dqh
	--left join UFDATA_001_2016..Customer cus on cus.cCusCode = b.pydm_
	--left join UFDATA_001_2016..Vendor ven on ven.cVenCode =  b.pydm_
	left join UFDATA_001_2016..Customer cus on cus.cCusName = b.dwmc or cus.cCusEnName =  b.dwmc --or cus.cCusCode = b.pydm_
	left join UFDATA_001_2016..Vendor ven on ven.cVenName =  b.dwmc or ven.cVenEnName =  b.dwmc --or ven.cVenCode =  b.pydm_
where 1=1
	--and dwmc is not null and (ven.cVenName is null and cus.cCusName is null)

order by id desc

