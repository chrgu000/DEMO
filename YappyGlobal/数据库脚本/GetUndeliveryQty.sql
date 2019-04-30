

-- ������۶��������δ��ȫ�����ĵ���
if exists (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = N'GetUndeliveryQty')
	drop view GetUndeliveryQty
go

create view GetUndeliveryQty
as

select a.cSOCode as DocNo
	,isnull(a.cDefine5,10) as cStatus		-- ʹ���Զ�����5��Ϊ״̬�ֶ�
	,a.cCusCode as cCustCode
	,a.cCusOAddress as cAddrCode
	,b.iRowNo as RowNo
	,b.cInvCode as ItemCode
	,b.cInvName as ItemName
	,b.iQuantity as Qty
	,b.iQuantity - isnull(b.iFHQuantity,0) as UndeliveryQty
	,inv.cComUnitCode  as UOM
	,b.iInvExchRate as CConversion
	,inv.cAssComUnitCode as BoxUOM
	,b.iSOsID
from so_somain a inner join so_sodetails b on a.id = b.id
	inner join Inventory inv on inv.cInvCode =b.cInvCode
where 1=1 
	and isnull(a.cVerifier,'') <> ''
	and isnull(a.cCloser ,'') = ''
	and isnull(b.cSCloser ,'') = ''
	and isnull(b.iQuantity,0) <> isnull(b.iFHQuantity,0)

go