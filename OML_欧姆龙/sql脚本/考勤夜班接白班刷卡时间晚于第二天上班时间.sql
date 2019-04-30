USE [UFDATA_003_2015]
GO
/****** Object:  StoredProcedure [dbo].[_Updateˢ��ʱ��]    Script Date: 2015-11-01 18:53:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--------------------------------------------------------------------------------------------
------2015-11-01
------�ƻ�
------�Ű�ʱҹ���ֱ���Űװ࣬���ڶ���װ���٣����ݣ���ҹ���°�ʱ�����ڵڶ����Ű���ϰ�ʱ��
---------------------------------------------------------------------------------------------



--	drop table _TempstrDayResult
--	drop table _TempstrPeriodResult
--	drop table _TempstrOriCardData

--		select * from _TempstrDayResult
--		select * from _TempstrPeriodResult
--		select min(dDateTime) from _TempstrOriCardData where cPsn_Num = '' and dDateTime >= '' and dDateTime < ''


ALTER  procedure [dbo].[_Updateˢ��ʱ��]
    @Startdate nvarchar(10),	--��ʼ����
    @Enddate nvarchar(10),	--��ֹ����
    @strPerson nvarchar(50),	--��Ա��ʱ��
    @strDayResult nvarchar(50),		--�ս����ʱ��
    @strPeriodResult nvarchar(50),	--��ν����ʱ��
    @strOriCardData nvarchar(50)	--ˢ��������ʱ��
as 

--	�ж�ҹ��ת�װࣨǰһ����ҹ�࣬�����ǰװࣩ
--	ˢ��ʱ�䳬���ڶ�����ˢ����ʼʱ��
--	�����ȫ�����

declare @�������� datetime
declare @���ں�һ�� datetime
declare @��Ա���� varchar(50)
declare @������� varchar(50)
declare @��� varchar(50)

--set @�������� = '2015-10-23'
--set @��Ա���� = '05848'
--set @������� = 'AS01'
--set @���  = '0007'

declare @strSQL as nvarchar(4000)
set @strSQL = 'IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N''[dbo].[_TempstrDayResult]'')) DROP TABLE [dbo].[_TempstrDayResult] select * into _TempstrDayResult from  ' + @strDayResult
EXEC(@strSQL)


DECLARE curList CURSOR
	for

	select cPsn_Num,dDutyDate,rDutyType,cDutyCode
	from _TempstrDayResult 
		
	OPEN curList
	fetch next from curList into @��Ա����,@��������,@�������,@���
	while @@FETCH_STATUS = 0
	BEGIN
		set @���ں�һ�� = dateadd(day,1,@��������)

		declare @��һ�������� varchar(50)
		declare @��һ���� varchar(50)
		select @��һ�������� = rDutyType,@��һ���� = cDutyCode from _TempstrDayResult where cPsn_Num = @��Ա���� and dDutyDate = @���ں�һ��

		declare @i������ٵ� int
		select @i������ٵ� = count(*) from hr_tm_LeaveMain a inner join hr_tm_Leave b on a.cVoucherId = b.cVoucherId where b.dBeginDate < dateadd(day,1,@���ں�һ��) and b.dEndDate >= @���ں�һ�� and cPsn_Num = @��Ա���� and b.rLeaveTimeType = 1

		declare @�ڶ��쿪ʼˢ��ʱ�� VARCHAR(50)
		select @�ڶ��쿪ʼˢ��ʱ�� = dStartCTime from hr_tm_DutyBasic where cDutyCode = @��һ����
		set @�ڶ��쿪ʼˢ��ʱ�� = left(CONVERT(char(20), @���ں�һ��, 120),10) + ' ' + @�ڶ��쿪ʼˢ��ʱ��

		declare @ʵ�ʵڶ���ˢ��ʱ�� datetime
		select @ʵ�ʵڶ���ˢ��ʱ�� = min(dDateTime) from _TempstrOriCardData where cPsn_Num = @��Ա���� and dDateTime >= @���ں�һ�� and dDateTime < dateadd(day,1,@���ں�һ��)
		declare @�°�ʱ�� varchar(50)
		set @�°�ʱ�� = CONVERT(varchar(100), @ʵ�ʵڶ���ˢ��ʱ��, 120)

		if @������� = 'AS01' and @��һ�������� = 'AS00' and @i������ٵ� > 0 and @�ڶ��쿪ʼˢ��ʱ�� < @ʵ�ʵڶ���ˢ��ʱ��
		begin
			set @strSQL = 'update ' + @strDayResult + ' set nWorkHours1 = 8,iActualWorkMinute = 480,iAbsentTimes = 0,iAbsentMinute = 0,nActualWorkDays = 1 ,nAbsentHour = 0,iLackCardTimes = 0'
				+ ',T_LastCard = '''+ @�°�ʱ�� + ''''
				+ ', p1EndCard = p1End,p2EndCard = p2End ,p3EndCard = p3End'
				 + ',p4EndCard = '''+  @�°�ʱ�� +''' '
				+ 'where cPsn_Num = ''' + @��Ա���� + '' + ''' and dDutyDate = ''' + left(CONVERT(varchar(100),  @��������, 120),10) + ''''

			EXEC(@strSQL)

			insert into _Temp(a)values(@strSQL)
		end
		fetch next from curList into @��Ա����,@��������,@�������,@���
	END
		
	close curList
    deallocate  curList

if @@ERROR <> 0  Goto Err_Handler

RETURN 0

Err_Handler:

return 1

