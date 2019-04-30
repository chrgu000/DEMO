
-----------------------------存储过程


CREATE proc [dbo].[_proc自动带出加班单扣除时间] (@VoucherID varchar(50))
as

declare @考勤班次 varchar(50)
declare @考勤班次名称 varchar(50)
declare @iCou int
declare @加班开始时间 datetime
declare @加班结束时间 datetime
declare @班次开始时间 datetime
declare @班次结束时间 datetime
declare @审核 bit
declare @加班类型 varchar(50)


select @考勤班次 = isnull(a.vRemark ,''),@加班开始时间 = a.dDutyTime ,@加班结束时间 = a.dOffTime ,@审核 = isnull(a.bAuditFlag ,0)	
	,@加班类型 = a.vJBCode
from HR_TM_OverTimeVoucher a left join hr_tm_OverTimeresult b on a.VoucherID = b.VoucherID
where a.VoucherID = @VoucherID

if @加班类型 = 'CS01'
	return


if  isnull(@VoucherID,'') <> '' 
begin

select @iCou = count(1) from hr_tm_DutyBasic where cDutyCode = @考勤班次 or vDutyName = @考勤班次



if @iCou = 0 
begin	
	RAISERROR ('班次不存在',16, 0)

	UPDATE HR_TM_OverTimeVoucher set bAuditFlag = 0,cAuditor  = null,cAuditorNum  = null,dAuditTime  = null where VoucherID = @VoucherID 
end
else
begin


UPDATE HR_TM_OverTimeVoucher set cTimeUseless1 = null,cTimeUseless2 = null where VoucherID = @VoucherID 

select @班次开始时间 = dDutyStart,@班次结束时间 = dDutyOff,@考勤班次 =cDutyCode,@考勤班次名称 = vDutyName  from hr_tm_DutyBasic where cDutyCode = @考勤班次 or vDutyName = @考勤班次



declare @最小休息开始时间 datetime
declare @最大休息结束时间 datetime
select @最小休息开始时间 = min(dtimeBegin),@最大休息结束时间 = max(dtimeEnd)  from hr_tm_TimeUseless where vRemark = '0001'

declare @扣除时间1 varchar(10)
declare @扣除时间2 varchar(10)


if (@最小休息开始时间 > @加班开始时间 and @最大休息结束时间 < @加班结束时间)
begin
	select @扣除时间1 = cCode from hr_tm_TimeUseless where vRemark = @考勤班次 + '1'
	update HR_TM_OverTimeVoucher set cTimeUseless1 = @扣除时间1 where VoucherID = @VoucherID
end
else
begin
	set @扣除时间1 = ''
	set @扣除时间2 = ''


	declare @扣除时间号 varchar(10)
	declare @扣除时间名 varchar(50)
	declare @休息开始时间 datetime
	declare @休息结束时间 datetime


	DECLARE curList CURSOR
	for
	select cCode,cName,dtimeBegin,dTimeEnd from hr_tm_TimeUseless where vRemark = @考勤班次 order by dTimeBegin
		
	OPEN curList
	fetch next from curList into @扣除时间号,@扣除时间名,@休息开始时间,@休息结束时间
	while @@FETCH_STATUS = 0
	BEGIN
		if (@加班开始时间 < @休息开始时间 and @加班结束时间 > @休息结束时间)
		begin
			if @扣除时间1 = ''
				set @扣除时间1 = @扣除时间号
			else
				if @扣除时间2 = ''
					set @扣除时间2 = @扣除时间号
		end		


		fetch next from curList into @扣除时间号,@扣除时间名,@休息开始时间,@休息结束时间
	END
	close curList
    deallocate  curList
	

		if @扣除时间1 = ''
			set @扣除时间1 = null
			
		if @扣除时间2 = ''
			set @扣除时间2 = null
	UPDATE HR_TM_OverTimeVoucher set cTimeUseless1 = @扣除时间1,cTimeUseless2 = @扣除时间2, vRemark = @考勤班次名称 where VoucherID = @VoucherID 
END
end
end

update hr_tm_OverTimeresult set hr_tm_OverTimeresult.cTimeUseless1 = b.cTimeUseless1,hr_tm_OverTimeresult.cTimeUseless2 = b.cTimeUseless2, hr_tm_OverTimeresult.vRemark = b.vRemark 
from HR_TM_OverTimeVoucher b 
where hr_tm_OverTimeresult.VoucherID = b.VoucherID
	and b.VoucherID = @VoucherID

GO

-------------------------触发器1


create trigger  [dbo].[trig_HR_TM_OverTimeVoucher_Insert] on [dbo].[HR_TM_OverTimeVoucher]
	for insert
as
/*
刷卡
验证加班单备注栏填写的班次信息是否正确，不正确提示并退出
根据班次加载休息时间，填入扣除时间1，扣除时间2
*/


declare @VoucherID varchar(50)
select @VoucherID = VoucherID from inserted

exec _proc自动带出加班单扣除时间 @VoucherID
GO


-----------------------触发器2


CREATE trigger  [dbo].[trig_hr_tm_OverTimeresult_Audit] on [dbo].[hr_tm_OverTimeresult]
	for update
as
/*
刷卡
验证加班单备注栏填写的班次信息是否正确，不正确提示并退出
根据班次加载休息时间，填入扣除时间1，扣除时间2
*/

 if (update(bAuditFlag))

declare @VoucherID varchar(50)
declare @bAuditFlag  bit
--select @VoucherID = VoucherID,@bAuditFlag = bAuditFlag  from inserted



--		delete _Temp
--		select * from _Temp

DECLARE curListTrig CURSOR
	for
	select VoucherID,bAuditFlag  from inserted
		
	OPEN curListTrig
	fetch next from curListTrig into @VoucherID,@bAuditFlag
	while @@FETCH_STATUS = 0
	BEGIN
		if(@bAuditFlag = 1)
		begin
			exec _proc自动带出加班单扣除时间 @VoucherID
		end
		fetch next from curListTrig into @VoucherID,@bAuditFlag
	END
	close curListTrig
    deallocate  curListTrig
GO





