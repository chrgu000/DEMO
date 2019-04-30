

----------------------------------------------------------
------�ƻ�
------2014-9-20
------���������ⵥ������ɼ���ɨ��������һ��ʱ���������
----------------------------------------------------------


IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[CheckdRecord09Audit]'))
DROP TRIGGER [dbo].[CheckdRecord09Audit]
GO



create trigger [dbo].[CheckdRecord09Audit] on [dbo].[RdRecord09]
for update
as

set nocount on

declare @iCou int
set @iCou = 0

select @iCou = count(1)
from inserted a inner join RdRecords08 b on a.ID = b.ID 
where ISNULL(a.cHandler ,'') <> '' and isnull(b.iQuantity,0) <> isnull(cDefine29,0)
	and isnull(a.cDefine1,'') = '��' 

if(@iCou > 0)
begin
	RAISERROR ('ɨ�������뵥����������,�������' , 16, 1) WITH NOWAIT
end
