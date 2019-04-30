
DECLARE MyCursor CURSOR    
    FOR 
		select a.ID 
		from rdrecord01 a inner join rdrecords01 b on a.id = b.id 
		where a.id not in (select [IDUN] from [dbo].[IA_ST_UnAccountVouch01])
			and dDate > '2015-12-31' and isnull(b.cbaccounter ,'') = ''
--打开一个游标    
OPEN MyCursor

--循环一个游标
DECLARE @RdID int 
    FETCH NEXT FROM  MyCursor INTO @RdID
WHILE @@FETCH_STATUS =0
    BEGIN
		exec IA_SP_WriteUnAccountVouchForST @RdID,'01'
		FETCH NEXT FROM  MyCursor INTO @RdID
    END    

--关闭游标
CLOSE MyCursor
--释放资源
DEALLOCATE MyCursor

DECLARE MyCursor CURSOR    
    FOR 
		select a.ID 
		from rdrecord08 a inner join rdrecords08 b on a.id = b.id 
		where a.id not in (select [IDUN] from [dbo].[IA_ST_UnAccountVouch08])
			and dDate > '2015-12-31' and isnull(b.cbaccounter ,'') = ''
--打开一个游标    
OPEN MyCursor

--循环一个游标
DECLARE @RdID int 
    FETCH NEXT FROM  MyCursor INTO @RdID
WHILE @@FETCH_STATUS =0
    BEGIN
		exec IA_SP_WriteUnAccountVouchForST @RdID,'08'
		FETCH NEXT FROM  MyCursor INTO @RdID
    END    

--关闭游标
CLOSE MyCursor
--释放资源
DEALLOCATE MyCursor


DECLARE MyCursor CURSOR    
    FOR 
		select a.ID 
		from rdrecord09 a inner join rdrecords09 b on a.id = b.id 
		where a.id not in (select [IDUN] from [dbo].[IA_ST_UnAccountVouch09])
			and dDate > '2015-12-31' and isnull(b.cbaccounter ,'') = ''
--打开一个游标    
OPEN MyCursor

--循环一个游标
DECLARE @RdID int 
    FETCH NEXT FROM  MyCursor INTO @RdID
WHILE @@FETCH_STATUS =0
    BEGIN
		if not exists (select * from rdrecords09sub where id = @RdID)
			insert into rdrecords09sub(id,AutoID)
			select a.id ,b.autoid
			from rdrecord09 a inner join rdrecords09 b on a.id = b.id 
			where a.id = @RdID

		exec IA_SP_WriteUnAccountVouchForST @RdID,'09'
		FETCH NEXT FROM  MyCursor INTO @RdID
    END    

--关闭游标
CLOSE MyCursor
--释放资源
DEALLOCATE MyCursor




DECLARE MyCursor CURSOR    
    FOR 
		select a.ID 
		from rdrecord10 a inner join rdrecords10 b on a.id = b.id 
		where a.id not in (select [IDUN] from [dbo].[IA_ST_UnAccountVouch10])
			and dDate > '2015-12-31' and isnull(b.cbaccounter ,'') = ''
--打开一个游标    
OPEN MyCursor

--循环一个游标
DECLARE @RdID int 
    FETCH NEXT FROM  MyCursor INTO @RdID
WHILE @@FETCH_STATUS =0
    BEGIN
		exec IA_SP_WriteUnAccountVouchForST @RdID,'10'
		FETCH NEXT FROM  MyCursor INTO @RdID
    END    

--关闭游标
CLOSE MyCursor
--释放资源
DEALLOCATE MyCursor




DECLARE MyCursor CURSOR    
    FOR 
		select a.ID 
		from rdrecord11 a inner join rdrecords11 b on a.id = b.id 
		where a.id not in (select [IDUN] from [dbo].[IA_ST_UnAccountVouch11])
			and dDate > '2015-12-31' and isnull(b.cbaccounter ,'') = ''
--打开一个游标    
OPEN MyCursor

--循环一个游标
DECLARE @RdID int 
    FETCH NEXT FROM  MyCursor INTO @RdID
WHILE @@FETCH_STATUS =0
    BEGIN
		exec IA_SP_WriteUnAccountVouchForST @RdID,'11'
		FETCH NEXT FROM  MyCursor INTO @RdID
    END    

--关闭游标
CLOSE MyCursor
--释放资源
DEALLOCATE MyCursor


