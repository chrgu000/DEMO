

----------------------------------------------------------
------�ƻ�
------2014-9-4
------���ɹ���ⵥ������ɼ���ɨ��������һ��ʱ���������
----------------------------------------------------------

IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[CheckdRecord01Audit]'))
DROP TRIGGER [dbo].[CheckdRecord01Audit]
GO



ALTER trigger [dbo].[CheckdRecord01Audit] on [dbo].[RdRecord01]
for update
as

set nocount on

declare @iCou int
set @iCou = 0

select @iCou = count(1)
from inserted a inner join RdRecords01 b on a.ID = b.ID 
where ISNULL(a.cHandler ,'') <> '' and isnull(b.iQuantity,0) <> isnull(cDefine29,0)

if(@iCou > 0)
begin
	RAISERROR ('ɨ�������뵥����������,�������' , 16, 1) WITH NOWAIT
end

