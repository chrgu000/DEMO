



----------------------------------------------------------
------�ƻ�
------2014-9-4
------������Ʒ��ⵥ������ɼ���ɨ��������һ��ʱ���������
----------------------------------------------------------

IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[CheckdRecord10Audit]'))
DROP TRIGGER [dbo].[CheckdRecord10Audit]
GO



create trigger [dbo].[CheckdRecord10Audit] on [dbo].[RdRecord10]
for update
as

set nocount on

declare @iCou int
set @iCou = 0

select @iCou = count(1)
from inserted a inner join RdRecords10 b on a.ID = b.ID 
where ISNULL(a.cHandler ,'') <> '' and isnull(b.iQuantity,0) <> isnull(cDefine29,0)

if(@iCou > 0)
begin
	RAISERROR ('ɨ�������뵥����������,�������' , 16, 1) WITH NOWAIT
end



