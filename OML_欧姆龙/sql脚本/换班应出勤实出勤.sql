
alter  procedure [_Update����Ӧ����ʵ����]
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

declare @��� int
declare @cDutyCode varchar(50)


declare @strSQL as nvarchar(4000)
set @strSQL = 'update ' + @strDayResult + ' set nWorkDays = 0,nWorkHours  = 0,iWorkMinute =0,nWorkHours1 = 8,nActualWorkDays  = 1,iActualWorkMinute = 480
		,iAbsentMinute =0,nAbsentHour =0,iAbsentTimes =0,iLackCardTimes  =0
	where cDutyCode = ''0099'''


EXEC(@strSQL) 
		

