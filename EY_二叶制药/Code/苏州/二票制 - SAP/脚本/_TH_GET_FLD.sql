
ALTER view [dbo].[_TH_GET_FLD]
AS


select a.iID as  FPIDs,a.��Ʊ���� as cSBVCode,a.��Ʊ���� as dDate,a.ҵ��Ա���� as cPersonCode,a.ҵ��Ա���� as cPersonName
	,null as cDepCode,null as cDepName,a.�ͻ����� as cCusCode,a.�ͻ����� as cCusName,a.�ͻ����� as cCusAbbName
	,a.������� as cInvCode,a.�������� as cInvName,a.����ͺ� as cInvStd,a.���� as iTaxUnitPrice,a.��Ʊ���� as iQuantity,a.��� as iSum
	,a.�������� as cDLCode
	,cast(null as decimal(16,2)) as iTaxUnitPriceFH
	,cast(null as decimal(16,2)) as iTaxRateCJ
	,cast(null as decimal(16,2)) as iTaxCJ
	,cast(null as decimal(16,2)) as iMoneyFL
	,a.[�����̱���] as DLS,a.���������� as DLSName
	,a.ʡ�ݱ��� as cDCCode ,a.ʡ������ as  cDCName 
	,cast(case when isnull(a.���,0) < 0 then 1 else 0 end as bit) as bRed
from [dbo].[_��Ʊ_sap] a
where a.��Ʊ���� in (select ��Ʊ���� from [_�ؿ�_sap])
	and isnull(a.���,0) <> 0


