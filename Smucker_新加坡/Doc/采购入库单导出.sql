


select b.cInvCode as ����,cast(b.iQuantity as decimal(16,2)) as ����, isnull(com.cComUnitName,'') as ������λ,isnull(inv.cAddress,'') as ԭ����  ,isnull(inv.cInvDefine13,'') as ���� ,isnull(b.ioriSum,'') as ��ֵ,isnull(cExch_Name,'') as ����, CONVERT(char(10),b.dVDate, 120)  as [���ʽ�ֹ�գ�yyyy-mm-dd��],isnull(b.cbMemo,'') as ���ﱸע 
from rdrecord01 a inner join rdrecords01 b on a.id = b.id
	inner join Inventory inv on b.cInvCode = inv.cInvCode
	inner join ComputationUnit com on com.cComunitCode = inv.cComunitCode 
where a.cCode = 'IP16110006'
order by b.autoid
