




select 
	case when pzlx = 2 then '��' when pzlx = 3 then 'ת' when pzlx = 1 then '��' end as ƾ֤���
	, PZH as ƾ֤��,null as �к�,zy as ժҪ,kmdm as ��ƿ�Ŀ
	,j as �跽,d as ����
	,case when ISNULL(j,0) <> 0 then WBJE end as ��ҽ跽,case when ISNULL(d,0) <> 0 then WBJE end as ��Ҵ���
	,null as ����,HL as ����,BMRY as ���ű���,dep.cDepName as ��������
	,a.dqh, a.DWDM, b.pydm_,b.dwmc
	,cus.cCusName as �ͻ����� ,cus.cCusName as �ͻ�����
	,ven.cVenCode as ��Ӧ�̱���,ven.cVenName as ��Ӧ������
	,ZDY as �Ƶ���,PZRQ as �Ƶ�����,2016 as ���,'01' as �ڼ�
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

