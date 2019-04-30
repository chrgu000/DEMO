
问题列表
1. 净需求中有数据，但在BOM中没有该物料

select * 
from [dbo].[TK_NetRequirement]
where sPartID = '15003'



select * 
from [TK_BOM] 
where child = '15003' or parent = '15003'


2. 净需求中怎么确定计划员


3. BOM中很多物料没有采购/加工周期，那这个周期怎么算？