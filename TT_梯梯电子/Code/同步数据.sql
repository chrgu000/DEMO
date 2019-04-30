


select count(1) from [efacdb]..[t_temp_netdemand]


/*
1. ��������ͬ���� TK_NetRequirement
2. �������ݰ������ڻ��ܺ�д�� TK_NetRequirement_SUM
*/

declare @sVersion nvarchar(50)
select @sVersion = CONVERT(varchar(100), GETDATE(), 112)

insert into TK_NetRequirement(
sVersion, SourceID, sNO, sPartID, fQTY, fOpenQTY, dtmDue, dtmRequirement, sPlannerCode, 
                sSourceType, sProductGroup, sRemark, sPreparedBy, dtmPreparedBy)

select @sVersion,reference,reference,partid,open_qty,open_qty,duedate,requesteddate,prodgroup,
	src,prodgroup,null,null,getdate()
from [efacdb]..[t_temp_netdemand]



select sPartID,sum(fOpenQTY) as qty,dtmDue from TK_NetRequirement group by sPartID,dtmDue