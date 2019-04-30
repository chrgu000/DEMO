





----------------------------------------------------------
------�ƻ�
------2014-9-4
------�����۷�����������ɼ���ɨ��������һ��ʱ���������
----------------------------------------------------------

IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[CheckdDispatchListAudit]'))
DROP TRIGGER [dbo].[CheckdDispatchListAudit]
GO



create trigger [dbo].[CheckdDispatchListAudit] on [dbo].[DispatchList]
for update
as

set nocount on

declare @iCou int
set @iCou = 0

select @iCou = count(1)
from inserted a inner join [DispatchLists] b on a.DLID = b.DLID 
where ISNULL(a.cVerifier ,'') <> '' and isnull(b.iQuantity,0) <> isnull(cDefine31,0)

if(@iCou > 0)
begin
	RAISERROR ('ɨ�������뵥����������,�������' , 16, 1) WITH NOWAIT
end






