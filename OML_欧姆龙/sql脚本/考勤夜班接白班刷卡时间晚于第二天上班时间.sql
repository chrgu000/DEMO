USE [UFDATA_003_2015]
GO
/****** Object:  StoredProcedure [dbo].[_Update刷卡时间]    Script Date: 2015-11-01 18:53:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--------------------------------------------------------------------------------------------
------2015-11-01
------唐辉
------排班时夜班后直接排白班，但第二天白班请假（调休），夜班下班时间晚于第二天排班的上班时间
---------------------------------------------------------------------------------------------



--	drop table _TempstrDayResult
--	drop table _TempstrPeriodResult
--	drop table _TempstrOriCardData

--		select * from _TempstrDayResult
--		select * from _TempstrPeriodResult
--		select min(dDateTime) from _TempstrOriCardData where cPsn_Num = '' and dDateTime >= '' and dDateTime < ''


ALTER  procedure [dbo].[_Update刷卡时间]
    @Startdate nvarchar(10),	--开始日期
    @Enddate nvarchar(10),	--截止日期
    @strPerson nvarchar(50),	--人员临时表
    @strDayResult nvarchar(50),		--日结果临时表
    @strPeriodResult nvarchar(50),	--班段结果临时表
    @strOriCardData nvarchar(50)	--刷卡数据临时表
as 

--	判断夜班转白班（前一天是夜班，当天是白班）
--	刷卡时间超出第二天班次刷卡起始时间
--	班次有全天调休

declare @考勤日期 datetime
declare @考勤后一天 datetime
declare @人员编码 varchar(50)
declare @班次类型 varchar(50)
declare @班次 varchar(50)

--set @考勤日期 = '2015-10-23'
--set @人员编码 = '05848'
--set @班次类型 = 'AS01'
--set @班次  = '0007'

declare @strSQL as nvarchar(4000)
set @strSQL = 'IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N''[dbo].[_TempstrDayResult]'')) DROP TABLE [dbo].[_TempstrDayResult] select * into _TempstrDayResult from  ' + @strDayResult
EXEC(@strSQL)


DECLARE curList CURSOR
	for

	select cPsn_Num,dDutyDate,rDutyType,cDutyCode
	from _TempstrDayResult 
		
	OPEN curList
	fetch next from curList into @人员编码,@考勤日期,@班次类型,@班次
	while @@FETCH_STATUS = 0
	BEGIN
		set @考勤后一天 = dateadd(day,1,@考勤日期)

		declare @后一天班次类型 varchar(50)
		declare @后一天班次 varchar(50)
		select @后一天班次类型 = rDutyType,@后一天班次 = cDutyCode from _TempstrDayResult where cPsn_Num = @人员编码 and dDutyDate = @考勤后一天

		declare @i整天请假单 int
		select @i整天请假单 = count(*) from hr_tm_LeaveMain a inner join hr_tm_Leave b on a.cVoucherId = b.cVoucherId where b.dBeginDate < dateadd(day,1,@考勤后一天) and b.dEndDate >= @考勤后一天 and cPsn_Num = @人员编码 and b.rLeaveTimeType = 1

		declare @第二天开始刷卡时间 VARCHAR(50)
		select @第二天开始刷卡时间 = dStartCTime from hr_tm_DutyBasic where cDutyCode = @后一天班次
		set @第二天开始刷卡时间 = left(CONVERT(char(20), @考勤后一天, 120),10) + ' ' + @第二天开始刷卡时间

		declare @实际第二天刷卡时间 datetime
		select @实际第二天刷卡时间 = min(dDateTime) from _TempstrOriCardData where cPsn_Num = @人员编码 and dDateTime >= @考勤后一天 and dDateTime < dateadd(day,1,@考勤后一天)
		declare @下班时间 varchar(50)
		set @下班时间 = CONVERT(varchar(100), @实际第二天刷卡时间, 120)

		if @班次类型 = 'AS01' and @后一天班次类型 = 'AS00' and @i整天请假单 > 0 and @第二天开始刷卡时间 < @实际第二天刷卡时间
		begin
			set @strSQL = 'update ' + @strDayResult + ' set nWorkHours1 = 8,iActualWorkMinute = 480,iAbsentTimes = 0,iAbsentMinute = 0,nActualWorkDays = 1 ,nAbsentHour = 0,iLackCardTimes = 0'
				+ ',T_LastCard = '''+ @下班时间 + ''''
				+ ', p1EndCard = p1End,p2EndCard = p2End ,p3EndCard = p3End'
				 + ',p4EndCard = '''+  @下班时间 +''' '
				+ 'where cPsn_Num = ''' + @人员编码 + '' + ''' and dDutyDate = ''' + left(CONVERT(varchar(100),  @考勤日期, 120),10) + ''''

			EXEC(@strSQL)

			insert into _Temp(a)values(@strSQL)
		end
		fetch next from curList into @人员编码,@考勤日期,@班次类型,@班次
	END
		
	close curList
    deallocate  curList

if @@ERROR <> 0  Goto Err_Handler

RETURN 0

Err_Handler:

return 1

