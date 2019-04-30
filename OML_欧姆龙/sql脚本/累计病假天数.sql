

alter  proc _Update累计病假小时数(@Year nvarchar(4),@Month nvarchar(2),	@strPerson nvarchar(50),@strDayResult nvarchar(50),	@strMonthResult nvarchar(50))
as 

select  isnull(userdef008,0)  as 上月累计病假小时数,cPsn_Num
into #a
from hr_tm_MonthResult 
where cYear = @Year and cast(cMonth as int) = cast(@Month  as int) - 1
	and isnull(userdef008,0) <> 0 

declare @strSQL nvarchar(4000)
 set @strSQL = 'update ' + @strMonthResult + ' set userdef008 = (isnull(a.上月累计病假小时数,0) + isnull(nSickLeaveHours ,0)) / 8 from #a a '
				+ 'where ' + @strMonthResult + '.cPsn_Num = a.cPsn_Num'

EXEC(@strSQL)

