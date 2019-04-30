
alter  procedure [_Update换班应出勤实出勤]
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

declare @序号 int
declare @cDutyCode varchar(50)


declare @strSQL as nvarchar(4000)
set @strSQL = 'update ' + @strDayResult + ' set nWorkDays = 0,nWorkHours  = 0,iWorkMinute =0,nWorkHours1 = 8,nActualWorkDays  = 1,iActualWorkMinute = 480
		,iAbsentMinute =0,nAbsentHour =0,iAbsentTimes =0,iLackCardTimes  =0
	where cDutyCode = ''0099'''


EXEC(@strSQL) 
		

