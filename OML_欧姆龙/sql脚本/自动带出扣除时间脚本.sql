
-----------------------------�洢����


CREATE proc [dbo].[_proc�Զ������Ӱ൥�۳�ʱ��] (@VoucherID varchar(50))
as

declare @���ڰ�� varchar(50)
declare @���ڰ������ varchar(50)
declare @iCou int
declare @�Ӱ࿪ʼʱ�� datetime
declare @�Ӱ����ʱ�� datetime
declare @��ο�ʼʱ�� datetime
declare @��ν���ʱ�� datetime
declare @��� bit
declare @�Ӱ����� varchar(50)


select @���ڰ�� = isnull(a.vRemark ,''),@�Ӱ࿪ʼʱ�� = a.dDutyTime ,@�Ӱ����ʱ�� = a.dOffTime ,@��� = isnull(a.bAuditFlag ,0)	
	,@�Ӱ����� = a.vJBCode
from HR_TM_OverTimeVoucher a left join hr_tm_OverTimeresult b on a.VoucherID = b.VoucherID
where a.VoucherID = @VoucherID

if @�Ӱ����� = 'CS01'
	return


if  isnull(@VoucherID,'') <> '' 
begin

select @iCou = count(1) from hr_tm_DutyBasic where cDutyCode = @���ڰ�� or vDutyName = @���ڰ��



if @iCou = 0 
begin	
	RAISERROR ('��β�����',16, 0)

	UPDATE HR_TM_OverTimeVoucher set bAuditFlag = 0,cAuditor  = null,cAuditorNum  = null,dAuditTime  = null where VoucherID = @VoucherID 
end
else
begin


UPDATE HR_TM_OverTimeVoucher set cTimeUseless1 = null,cTimeUseless2 = null where VoucherID = @VoucherID 

select @��ο�ʼʱ�� = dDutyStart,@��ν���ʱ�� = dDutyOff,@���ڰ�� =cDutyCode,@���ڰ������ = vDutyName  from hr_tm_DutyBasic where cDutyCode = @���ڰ�� or vDutyName = @���ڰ��



declare @��С��Ϣ��ʼʱ�� datetime
declare @�����Ϣ����ʱ�� datetime
select @��С��Ϣ��ʼʱ�� = min(dtimeBegin),@�����Ϣ����ʱ�� = max(dtimeEnd)  from hr_tm_TimeUseless where vRemark = '0001'

declare @�۳�ʱ��1 varchar(10)
declare @�۳�ʱ��2 varchar(10)


if (@��С��Ϣ��ʼʱ�� > @�Ӱ࿪ʼʱ�� and @�����Ϣ����ʱ�� < @�Ӱ����ʱ��)
begin
	select @�۳�ʱ��1 = cCode from hr_tm_TimeUseless where vRemark = @���ڰ�� + '1'
	update HR_TM_OverTimeVoucher set cTimeUseless1 = @�۳�ʱ��1 where VoucherID = @VoucherID
end
else
begin
	set @�۳�ʱ��1 = ''
	set @�۳�ʱ��2 = ''


	declare @�۳�ʱ��� varchar(10)
	declare @�۳�ʱ���� varchar(50)
	declare @��Ϣ��ʼʱ�� datetime
	declare @��Ϣ����ʱ�� datetime


	DECLARE curList CURSOR
	for
	select cCode,cName,dtimeBegin,dTimeEnd from hr_tm_TimeUseless where vRemark = @���ڰ�� order by dTimeBegin
		
	OPEN curList
	fetch next from curList into @�۳�ʱ���,@�۳�ʱ����,@��Ϣ��ʼʱ��,@��Ϣ����ʱ��
	while @@FETCH_STATUS = 0
	BEGIN
		if (@�Ӱ࿪ʼʱ�� < @��Ϣ��ʼʱ�� and @�Ӱ����ʱ�� > @��Ϣ����ʱ��)
		begin
			if @�۳�ʱ��1 = ''
				set @�۳�ʱ��1 = @�۳�ʱ���
			else
				if @�۳�ʱ��2 = ''
					set @�۳�ʱ��2 = @�۳�ʱ���
		end		


		fetch next from curList into @�۳�ʱ���,@�۳�ʱ����,@��Ϣ��ʼʱ��,@��Ϣ����ʱ��
	END
	close curList
    deallocate  curList
	

		if @�۳�ʱ��1 = ''
			set @�۳�ʱ��1 = null
			
		if @�۳�ʱ��2 = ''
			set @�۳�ʱ��2 = null
	UPDATE HR_TM_OverTimeVoucher set cTimeUseless1 = @�۳�ʱ��1,cTimeUseless2 = @�۳�ʱ��2, vRemark = @���ڰ������ where VoucherID = @VoucherID 
END
end
end

update hr_tm_OverTimeresult set hr_tm_OverTimeresult.cTimeUseless1 = b.cTimeUseless1,hr_tm_OverTimeresult.cTimeUseless2 = b.cTimeUseless2, hr_tm_OverTimeresult.vRemark = b.vRemark 
from HR_TM_OverTimeVoucher b 
where hr_tm_OverTimeresult.VoucherID = b.VoucherID
	and b.VoucherID = @VoucherID

GO

-------------------------������1


create trigger  [dbo].[trig_HR_TM_OverTimeVoucher_Insert] on [dbo].[HR_TM_OverTimeVoucher]
	for insert
as
/*
ˢ��
��֤�Ӱ൥��ע����д�İ����Ϣ�Ƿ���ȷ������ȷ��ʾ���˳�
���ݰ�μ�����Ϣʱ�䣬����۳�ʱ��1���۳�ʱ��2
*/


declare @VoucherID varchar(50)
select @VoucherID = VoucherID from inserted

exec _proc�Զ������Ӱ൥�۳�ʱ�� @VoucherID
GO


-----------------------������2


CREATE trigger  [dbo].[trig_hr_tm_OverTimeresult_Audit] on [dbo].[hr_tm_OverTimeresult]
	for update
as
/*
ˢ��
��֤�Ӱ൥��ע����д�İ����Ϣ�Ƿ���ȷ������ȷ��ʾ���˳�
���ݰ�μ�����Ϣʱ�䣬����۳�ʱ��1���۳�ʱ��2
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
			exec _proc�Զ������Ӱ൥�۳�ʱ�� @VoucherID
		end
		fetch next from curListTrig into @VoucherID,@bAuditFlag
	END
	close curListTrig
    deallocate  curListTrig
GO





