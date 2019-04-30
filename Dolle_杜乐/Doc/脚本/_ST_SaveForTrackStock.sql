USE [UFDATA_001_2015]
GO

/****** Object:  StoredProcedure [dbo].[_ST_SaveForTrackStock32]    Script Date: 2016-02-03 11:29:17 ******/
DROP PROCEDURE [dbo].[_ST_SaveForTrackStock32]
GO

/****** Object:  StoredProcedure [dbo].[_ST_SaveForTrackStock11]    Script Date: 2016-02-03 11:29:17 ******/
DROP PROCEDURE [dbo].[_ST_SaveForTrackStock11]
GO

/****** Object:  StoredProcedure [dbo].[_ST_SaveForTrackStock10]    Script Date: 2016-02-03 11:29:17 ******/
DROP PROCEDURE [dbo].[_ST_SaveForTrackStock10]
GO

/****** Object:  StoredProcedure [dbo].[_ST_SaveForTrackStock09]    Script Date: 2016-02-03 11:29:17 ******/
DROP PROCEDURE [dbo].[_ST_SaveForTrackStock09]
GO

/****** Object:  StoredProcedure [dbo].[_ST_SaveForTrackStock08]    Script Date: 2016-02-03 11:29:17 ******/
DROP PROCEDURE [dbo].[_ST_SaveForTrackStock08]
GO

/****** Object:  StoredProcedure [dbo].[_ST_SaveForTrackStock01]    Script Date: 2016-02-03 11:29:17 ******/
DROP PROCEDURE [dbo].[_ST_SaveForTrackStock01]
GO

/****** Object:  StoredProcedure [dbo].[_ST_SaveForTrackStock01]    Script Date: 2016-02-03 11:29:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[_ST_SaveForTrackStock01](
@sd datetime,
@ed datetime
)
AS
if @sd<>'' and @ed<>'' 
begin
	update RdRecords01 set bCosting=1 from RdRecord01 where RdRecord01.id=RdRecords01.id and bCosting=0 and ddate>=@sd and ddate<=@ed and isnull(cbaccounter,'')=''

	DECLARE tnames_cursor CURSOR
	FOR
	SELECT a.id FROM RdRecord01 a left join  RdRecords01 b on a.id=b.id where isnull(cbaccounter,'')='' and ddate>=@sd and ddate<=@ed group by a.ID 
	OPEN tnames_cursor

	DECLARE @sid nvarchar(50)

	FETCH NEXT FROM tnames_cursor INTO @sid
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		exec IA_SP_WriteUnAccountVouchForST @sid,N'01'
		FETCH NEXT FROM tnames_cursor INTO @sid
	END
	CLOSE tnames_cursor
	DEALLOCATE tnames_cursor

end

GO

/****** Object:  StoredProcedure [dbo].[_ST_SaveForTrackStock08]    Script Date: 2016-02-03 11:29:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[_ST_SaveForTrackStock08](
@sd datetime,
@ed datetime
)
AS
if @sd<>'' and @ed<>'' 
begin
    update RdRecords08 set bCosting=1 from RdRecord08 where RdRecord08.id=RdRecords08.id and bCosting=0 and ddate>=@sd and ddate<=@ed and isnull(cbaccounter,'')=''
	DECLARE tnames_cursor CURSOR
	FOR
	SELECT a.id FROM RdRecord08 a left join  RdRecords08 b on a.id=b.id where isnull(cbaccounter,'')='' and ddate>=@sd and ddate<=@ed group by a.ID 
	OPEN tnames_cursor

	DECLARE @sid nvarchar(50)

	FETCH NEXT FROM tnames_cursor INTO @sid
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		exec IA_SP_WriteUnAccountVouchForST @sid,N'08'
		FETCH NEXT FROM tnames_cursor INTO @sid
	END
	CLOSE tnames_cursor
	DEALLOCATE tnames_cursor

end

GO

/****** Object:  StoredProcedure [dbo].[_ST_SaveForTrackStock09]    Script Date: 2016-02-03 11:29:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[_ST_SaveForTrackStock09](
@sd datetime,
@ed datetime
)
AS
if @sd<>'' and @ed<>'' 
begin
    update RdRecords09 set bCosting=1 from RdRecord09 where RdRecord09.id=RdRecords09.id and bCosting=0 and ddate>=@sd and ddate<=@ed and isnull(cbaccounter,'')=''
	DECLARE tnames_cursor CURSOR
	FOR
	SELECT a.id FROM RdRecord09 a left join  RdRecords09 b on a.id=b.id where isnull(cbaccounter,'')='' and ddate>=@sd and ddate<=@ed group by a.ID 
	OPEN tnames_cursor

	DECLARE @sid nvarchar(50)

	FETCH NEXT FROM tnames_cursor INTO @sid
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		exec IA_SP_WriteUnAccountVouchForST @sid,N'09'
		FETCH NEXT FROM tnames_cursor INTO @sid
	END
	CLOSE tnames_cursor
	DEALLOCATE tnames_cursor

end

GO

/****** Object:  StoredProcedure [dbo].[_ST_SaveForTrackStock10]    Script Date: 2016-02-03 11:29:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[_ST_SaveForTrackStock10](
@sd datetime,
@ed datetime
)
AS
if @sd<>'' and @ed<>'' 
begin
    update RdRecords10 set bCosting=1 from RdRecord10 where RdRecord10.id=RdRecords10.id and bCosting=0 and ddate>=@sd and ddate<=@ed and isnull(cbaccounter,'')=''
	DECLARE tnames_cursor CURSOR
	FOR
	SELECT a.id FROM RdRecord10 a left join  RdRecords10 b on a.id=b.id where isnull(cbaccounter,'')='' and ddate>=@sd and ddate<=@ed group by a.ID 
	OPEN tnames_cursor

	DECLARE @sid nvarchar(50)

	FETCH NEXT FROM tnames_cursor INTO @sid
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		exec IA_SP_WriteUnAccountVouchForST @sid,N'10'
		FETCH NEXT FROM tnames_cursor INTO @sid
	END
	CLOSE tnames_cursor
	DEALLOCATE tnames_cursor

end

GO

/****** Object:  StoredProcedure [dbo].[_ST_SaveForTrackStock11]    Script Date: 2016-02-03 11:29:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[_ST_SaveForTrackStock11](
@sd datetime,
@ed datetime
)
AS
if @sd<>'' and @ed<>'' 
begin
    update RdRecords11 set bCosting=1 from RdRecord11 where RdRecord11.id=RdRecords11.id and bCosting=0 and ddate>=@sd and ddate<=@ed and isnull(cbaccounter,'')=''
	DECLARE tnames_cursor CURSOR
	FOR
	SELECT a.id FROM RdRecord11 a left join  RdRecords11 b on a.id=b.id where isnull(cbaccounter,'')='' and ddate>=@sd and ddate<=@ed group by a.ID 
	OPEN tnames_cursor

	DECLARE @sid nvarchar(50)

	FETCH NEXT FROM tnames_cursor INTO @sid
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		exec IA_SP_WriteUnAccountVouchForST @sid,N'11'
		FETCH NEXT FROM tnames_cursor INTO @sid
	END
	CLOSE tnames_cursor
	DEALLOCATE tnames_cursor

end

GO

/****** Object:  StoredProcedure [dbo].[_ST_SaveForTrackStock32]    Script Date: 2016-02-03 11:29:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[_ST_SaveForTrackStock32](
@sd datetime,
@ed datetime
)
AS
if @sd<>'' and @ed<>'' 
begin
    update RdRecords32 set bCosting=1 from RdRecord32 where RdRecord32.id=RdRecords32.id and bCosting=0 and ddate>=@sd and ddate<=@ed and isnull(cbaccounter,'')=''
	DECLARE tnames_cursor CURSOR
	FOR
	SELECT a.id FROM RdRecord32 a left join  RdRecords32 b on a.id=b.id where isnull(cbaccounter,'')='' and ddate>=@sd and ddate<=@ed group by a.ID 
	OPEN tnames_cursor

	DECLARE @sid nvarchar(50)

	FETCH NEXT FROM tnames_cursor INTO @sid
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		exec IA_SP_WriteUnAccountVouchForST @sid,N'32'
		FETCH NEXT FROM tnames_cursor INTO @sid
	END
	CLOSE tnames_cursor
	DEALLOCATE tnames_cursor

end

GO


