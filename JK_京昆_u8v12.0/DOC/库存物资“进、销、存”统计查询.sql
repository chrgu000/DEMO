
--create table #a(���,����,����,����,�������,�������,����ͺ�,��װ,��ĩ�������,�ϸ�,���ϸ�,����,�ֿ����,�ֿ�����,��λ����,��λ����,����,����
--	,�����ۼ����,�����ۼ�����,�����ۼ��˿�,�ɹ����,�ɹ��˻�,�ۼ�����,�ۼ������˻�)
	
	
--select SUBSTRING(cInvCCode,0,3), SUBSTRING(cInvCCode,0,5),* from InventoryClass order by cInvCCode


declare @dDate1 datetime
declare @dDate2 datetime

set @dDate1 = '2015-4-1'
set @dDate2 = '2015-4-30'


if exists (select * from tempdb.dbo.sysobjects where id = object_id(N'tempdb..#a') and type='U')
	drop table #a
	

--	�ɹ����
select distinct invPos.AutoID,rds.cInvCode as �������,inv.cInvName as �������,inv.cInvStd as ������
	,case when len(inv.cInvCCode) = 2 then SUBSTRING(inv.cInvCCode,0,3) else null end as һ���������,case when len(inv.cInvCCode) = 2 then InvC1.cInvCName else null end as һ����������
	,case when len(inv.cInvCCode) = 4 then SUBSTRING(inv.cInvCCode,0,5) else null end as �����������,case when len(inv.cInvCCode) = 4 then InvC1.cInvCName else null end as ������������
	,case when len(inv.cInvCCode) >= 6 then inv.cInvCCode else null end as �����������,case when len(inv.cInvCCode) >= 6 then InvC1.cInvCName else null end as ������������
	,inv.cInvDefine4 as ��װ,null as ��ĩ�������,null as �ϸ�,null as ���ϸ�,null as ����
	,wh.cWhCode as �ֿ����,wh.cWhName as �ֿ�����,Pos.cPosCode as ��λ����,Pos.cPosName as ��λ����
	,curr.iQuantity as �ֿ��ִ���,curr.iNum as �ֿ��ִ����
	,InvPosSum.iQuantity as ��λ�ִ���,invpossum.inum as ��λ�Դ����
	,rds.iQuantity as �ɹ��������,rds.iNum as �ɹ�������
	,cast(null as decimal(16,6)) as �ɹ��˻�����,cast(null as decimal(16,6)) as �ɹ��˻�����
	,cast(null as decimal(16,6)) as �����ۼ��������,cast(null as decimal(16,6)) as �����ۼ�������
	,cast(null as decimal(16,6)) as �����ۼ���������,cast(null as decimal(16,6)) as �����ۼ����ϼ���
	,cast(null as decimal(16,6)) as �����ۼ��˿�����,cast(null as decimal(16,6)) as �����ۼ��˿����
	,cast(null as decimal(16,6)) as �ۼ���������,cast(null as decimal(16,6)) as �ۼ����ۼ���
	,cast(null as decimal(16,6)) as �ۼ������˻�����,cast(null as decimal(16,6)) as �ۼ������˻�����
into #a
from RdRecord01 rd inner join RdRecords01 rds on rd.ID = rds.ID 
	left join InvPosition invPos on invPos.RdsID = rds.AutoID
	inner join inventory inv on rds.cInvCode = inv.cInvCode
	left join Warehouse wh on rd.cWhCode = wh.cWhCode
	left join Position Pos on invPos.cPosCode = Pos.cPosCode
	left join InventoryClass InvC1 on InvC1.cInvCCode = SUBSTRING(inv.cInvCCode,0,3)
	left join InventoryClass InvC2 on InvC2.cInvCCode = SUBSTRING(inv.cInvCCode,0,5)
	left join InventoryClass InvC3 on InvC3.cInvCCode = inv.cInvCCode
	left join currentstock Curr on Curr.cInvCode = rds.cInvCode and Curr.cWhCode = rd.cWhCode 
		and Curr.cFree1 = rds.cFree1	and Curr.cFree2 = rds.cFree2	and Curr.cFree3 = rds.cFree3	and Curr.cFree4 = rds.cFree4	and Curr.cFree5 = rds.cFree5
		and Curr.cFree6 = rds.cFree6	and Curr.cFree7 = rds.cFree7	and Curr.cFree8 = rds.cFree8	and Curr.cFree9 = rds.cFree9	and Curr.cFree10 = rds.cFree10
	left join InvPositionSum InvPosSum on InvPosSum.cInvCode = rds.cInvCode and InvPosSum.cWhCode = rd.cWhCode and InvPosSum.cPosCode = invpos.cPosCode
		and InvPosSum.cFree1 = rds.cFree1	and InvPosSum.cFree2 = rds.cFree2	and InvPosSum.cFree3 = rds.cFree3	and InvPosSum.cFree4 = rds.cFree4	and InvPosSum.cFree5 = rds.cFree5
		and InvPosSum.cFree6 = rds.cFree6	and InvPosSum.cFree7 = rds.cFree7	and InvPosSum.cFree8 = rds.cFree8	and InvPosSum.cFree9 = rds.cFree9	and InvPosSum.cFree10 = rds.cFree10
where isnull(rds.iQuantity,0) > 0
	and rd.dDate >= @dDate1 and rd.dDate <= @dDate2

--�ɹ��˻�
insert into #a
select distinct invPos.AutoID,rds.cInvCode as �������,inv.cInvName as �������,inv.cInvStd as ������
	,case when len(inv.cInvCCode) = 2 then SUBSTRING(inv.cInvCCode,0,3) else null end as һ���������,case when len(inv.cInvCCode) = 2 then InvC1.cInvCName else null end as һ����������
	,case when len(inv.cInvCCode) = 4 then SUBSTRING(inv.cInvCCode,0,5) else null end as �����������,case when len(inv.cInvCCode) = 4 then InvC1.cInvCName else null end as ������������
	,case when len(inv.cInvCCode) >= 6 then inv.cInvCCode else null end as �����������,case when len(inv.cInvCCode) >= 6 then InvC1.cInvCName else null end as ������������
	,inv.cInvDefine4 as ��װ,null as ��ĩ�������,null as �ϸ�,null as ���ϸ�,null as ����
	,wh.cWhCode as �ֿ����,wh.cWhName as �ֿ�����,Pos.cPosCode as ��λ����,Pos.cPosName as ��λ����
	,curr.iQuantity as �ֿ��ִ���,curr.iNum as �ֿ��ִ����
	,InvPosSum.iQuantity as ��λ�ִ���,invpossum.inum as ��λ�Դ����
	,cast(null as decimal(16,6)) as �ɹ��������,cast(null as decimal(16,6)) as �ɹ�������
	,rds.iQuantity as �ɹ��˻�����,rds.iNum as �ɹ��˻�����
	,cast(null as decimal(16,6)) as �����ۼ��������,cast(null as decimal(16,6)) as �����ۼ�������
	,cast(null as decimal(16,6)) as �����ۼ���������,cast(null as decimal(16,6)) as �����ۼ����ϼ���
	,cast(null as decimal(16,6)) as �����ۼ��˿�����,cast(null as decimal(16,6)) as �����ۼ��˿����
	,cast(null as decimal(16,6)) as �ۼ���������,cast(null as decimal(16,6)) as �ۼ����ۼ���
	,cast(null as decimal(16,6)) as �ۼ������˻�����,cast(null as decimal(16,6)) as �ۼ������˻�����
from RdRecord01 rd inner join RdRecords01 rds on rd.ID = rds.ID 
	left join InvPosition invPos on invPos.RdsID = rds.AutoID
	inner join inventory inv on rds.cInvCode = inv.cInvCode
	left join Warehouse wh on rd.cWhCode = wh.cWhCode
	left join Position Pos on invPos.cPosCode = Pos.cPosCode
	left join InventoryClass InvC1 on InvC1.cInvCCode = SUBSTRING(inv.cInvCCode,0,3)
	left join InventoryClass InvC2 on InvC2.cInvCCode = SUBSTRING(inv.cInvCCode,0,5)
	left join InventoryClass InvC3 on InvC3.cInvCCode = inv.cInvCCode
	left join currentstock Curr on Curr.cInvCode = rds.cInvCode and Curr.cWhCode = rd.cWhCode 
		and Curr.cFree1 = rds.cFree1	and Curr.cFree2 = rds.cFree2	and Curr.cFree3 = rds.cFree3	and Curr.cFree4 = rds.cFree4	and Curr.cFree5 = rds.cFree5
		and Curr.cFree6 = rds.cFree6	and Curr.cFree7 = rds.cFree7	and Curr.cFree8 = rds.cFree8	and Curr.cFree9 = rds.cFree9	and Curr.cFree10 = rds.cFree10
	left join InvPositionSum InvPosSum on InvPosSum.cInvCode = rds.cInvCode and InvPosSum.cWhCode = rd.cWhCode and InvPosSum.cPosCode = invpos.cPosCode
		and InvPosSum.cFree1 = rds.cFree1	and InvPosSum.cFree2 = rds.cFree2	and InvPosSum.cFree3 = rds.cFree3	and InvPosSum.cFree4 = rds.cFree4	and InvPosSum.cFree5 = rds.cFree5
		and InvPosSum.cFree6 = rds.cFree6	and InvPosSum.cFree7 = rds.cFree7	and InvPosSum.cFree8 = rds.cFree8	and InvPosSum.cFree9 = rds.cFree9	and InvPosSum.cFree10 = rds.cFree10
where isnull(rds.iQuantity,0) < 0
	and rd.dDate >= @dDate1 and rd.dDate <= @dDate2

-- ��Ʒ���
insert into #a
select distinct invPos.AutoID,rds.cInvCode as �������,inv.cInvName as �������,inv.cInvStd as ������
	,case when len(inv.cInvCCode) = 2 then SUBSTRING(inv.cInvCCode,0,3) else null end as һ���������,case when len(inv.cInvCCode) = 2 then InvC1.cInvCName else null end as һ����������
	,case when len(inv.cInvCCode) = 4 then SUBSTRING(inv.cInvCCode,0,5) else null end as �����������,case when len(inv.cInvCCode) = 4 then InvC1.cInvCName else null end as ������������
	,case when len(inv.cInvCCode) >= 6 then inv.cInvCCode else null end as �����������,case when len(inv.cInvCCode) >= 6 then InvC1.cInvCName else null end as ������������
	,inv.cInvDefine4 as ��װ,null as ��ĩ�������,null as �ϸ�,null as ���ϸ�,null as ����
	,wh.cWhCode as �ֿ����,wh.cWhName as �ֿ�����,Pos.cPosCode as ��λ����,Pos.cPosName as ��λ����
	,curr.iQuantity as �ֿ��ִ���,curr.iNum as �ֿ��ִ����
	,InvPosSum.iQuantity as ��λ�ִ���,invpossum.inum as ��λ�Դ����
	,cast(null as decimal(16,6)),cast(null as decimal(16,6)) as �ɹ�������
	,cast(null as decimal(16,6)) as �ɹ��˻�����,cast(null as decimal(16,6)) as �ɹ��˻�����
	,rds.iQuantity as �����ۼ��������,rds.iNum as �����ۼ�������
	,cast(null as decimal(16,6)) as �����ۼ���������,cast(null as decimal(16,6)) as �����ۼ����ϼ���
	,cast(null as decimal(16,6)) as �����ۼ��˿�����,cast(null as decimal(16,6)) as �����ۼ��˿����
	,cast(null as decimal(16,6)) as �ۼ���������,cast(null as decimal(16,6)) as �ۼ����ۼ���
	,cast(null as decimal(16,6)) as �ۼ������˻�����,cast(null as decimal(16,6)) as �ۼ������˻�����
from rdrecord10 rd inner join rdrecords10 rds on rd.ID = rds.ID 
	left join InvPosition invPos on invPos.RdsID = rds.AutoID
	inner join inventory inv on rds.cInvCode = inv.cInvCode
	left join Warehouse wh on rd.cWhCode = wh.cWhCode
	left join Position Pos on invPos.cPosCode = Pos.cPosCode
	left join InventoryClass InvC1 on InvC1.cInvCCode = SUBSTRING(inv.cInvCCode,0,3)
	left join InventoryClass InvC2 on InvC2.cInvCCode = SUBSTRING(inv.cInvCCode,0,5)
	left join InventoryClass InvC3 on InvC3.cInvCCode = inv.cInvCCode
	left join currentstock Curr on Curr.cInvCode = rds.cInvCode and Curr.cWhCode = rd.cWhCode 
		and Curr.cFree1 = rds.cFree1	and Curr.cFree2 = rds.cFree2	and Curr.cFree3 = rds.cFree3	and Curr.cFree4 = rds.cFree4	and Curr.cFree5 = rds.cFree5
		and Curr.cFree6 = rds.cFree6	and Curr.cFree7 = rds.cFree7	and Curr.cFree8 = rds.cFree8	and Curr.cFree9 = rds.cFree9	and Curr.cFree10 = rds.cFree10
	left join InvPositionSum InvPosSum on InvPosSum.cInvCode = rds.cInvCode and InvPosSum.cWhCode = rd.cWhCode and InvPosSum.cPosCode = invpos.cPosCode
		and InvPosSum.cFree1 = rds.cFree1	and InvPosSum.cFree2 = rds.cFree2	and InvPosSum.cFree3 = rds.cFree3	and InvPosSum.cFree4 = rds.cFree4	and InvPosSum.cFree5 = rds.cFree5
		and InvPosSum.cFree6 = rds.cFree6	and InvPosSum.cFree7 = rds.cFree7	and InvPosSum.cFree8 = rds.cFree8	and InvPosSum.cFree9 = rds.cFree9	and InvPosSum.cFree10 = rds.cFree10
where  isnull(rds.iQuantity,0) > 0
	and rd.dDate >= @dDate1 and rd.dDate <= @dDate2

-- ��Ʒ�˻�
insert into #a
select distinct invPos.AutoID,rds.cInvCode as �������,inv.cInvName as �������,inv.cInvStd as ������
	,case when len(inv.cInvCCode) = 2 then SUBSTRING(inv.cInvCCode,0,3) else null end as һ���������,case when len(inv.cInvCCode) = 2 then InvC1.cInvCName else null end as һ����������
	,case when len(inv.cInvCCode) = 4 then SUBSTRING(inv.cInvCCode,0,5) else null end as �����������,case when len(inv.cInvCCode) = 4 then InvC1.cInvCName else null end as ������������
	,case when len(inv.cInvCCode) >= 6 then inv.cInvCCode else null end as �����������,case when len(inv.cInvCCode) >= 6 then InvC1.cInvCName else null end as ������������
	,inv.cInvDefine4 as ��װ,null as ��ĩ�������,null as �ϸ�,null as ���ϸ�,null as ����
	,wh.cWhCode as �ֿ����,wh.cWhName as �ֿ�����,Pos.cPosCode as ��λ����,Pos.cPosName as ��λ����
	,curr.iQuantity as �ֿ��ִ���,curr.iNum as �ֿ��ִ����
	,InvPosSum.iQuantity as ��λ�ִ���,invpossum.inum as ��λ�Դ����
	,cast(null as decimal(16,6)),cast(null as decimal(16,6)) as �ɹ�������
	,cast(null as decimal(16,6)) as �ɹ��˻�����,cast(null as decimal(16,6)) as �ɹ��˻�����
	,cast(null as decimal(16,6)) as �����ۼ��������,cast(null as decimal(16,6)) as �����ۼ�������
	,rds.iQuantity  as �����ۼ���������,rds.iNum as �����ۼ����ϼ���
	,cast(null as decimal(16,6)) as �����ۼ��˿�����,cast(null as decimal(16,6)) as �����ۼ��˿����
	,cast(null as decimal(16,6)) as �ۼ���������,cast(null as decimal(16,6)) as �ۼ����ۼ���
	,cast(null as decimal(16,6)) as �ۼ������˻�����,cast(null as decimal(16,6)) as �ۼ������˻�����
from rdrecord10 rd inner join rdrecords10 rds on rd.ID = rds.ID 
	left join InvPosition invPos on invPos.RdsID = rds.AutoID
	inner join inventory inv on rds.cInvCode = inv.cInvCode
	left join Warehouse wh on rd.cWhCode = wh.cWhCode
	left join Position Pos on invPos.cPosCode = Pos.cPosCode
	left join InventoryClass InvC1 on InvC1.cInvCCode = SUBSTRING(inv.cInvCCode,0,3)
	left join InventoryClass InvC2 on InvC2.cInvCCode = SUBSTRING(inv.cInvCCode,0,5)
	left join InventoryClass InvC3 on InvC3.cInvCCode = inv.cInvCCode
	left join currentstock Curr on Curr.cInvCode = rds.cInvCode and Curr.cWhCode = rd.cWhCode 
		and Curr.cFree1 = rds.cFree1	and Curr.cFree2 = rds.cFree2	and Curr.cFree3 = rds.cFree3	and Curr.cFree4 = rds.cFree4	and Curr.cFree5 = rds.cFree5
		and Curr.cFree6 = rds.cFree6	and Curr.cFree7 = rds.cFree7	and Curr.cFree8 = rds.cFree8	and Curr.cFree9 = rds.cFree9	and Curr.cFree10 = rds.cFree10
	left join InvPositionSum InvPosSum on InvPosSum.cInvCode = rds.cInvCode and InvPosSum.cWhCode = rd.cWhCode and InvPosSum.cPosCode = invpos.cPosCode
		and InvPosSum.cFree1 = rds.cFree1	and InvPosSum.cFree2 = rds.cFree2	and InvPosSum.cFree3 = rds.cFree3	and InvPosSum.cFree4 = rds.cFree4	and InvPosSum.cFree5 = rds.cFree5
		and InvPosSum.cFree6 = rds.cFree6	and InvPosSum.cFree7 = rds.cFree7	and InvPosSum.cFree8 = rds.cFree8	and InvPosSum.cFree9 = rds.cFree9	and InvPosSum.cFree10 = rds.cFree10
where  isnull(rds.iQuantity,0) < 0
	and rd.dDate >= @dDate1 and rd.dDate <= @dDate2
	
-- ��Ʒ����
insert into #a
select distinct invPos.AutoID,rds.cInvCode as �������,inv.cInvName as �������,inv.cInvStd as ������
	,case when len(inv.cInvCCode) = 2 then SUBSTRING(inv.cInvCCode,0,3) else null end as һ���������,case when len(inv.cInvCCode) = 2 then InvC1.cInvCName else null end as һ����������
	,case when len(inv.cInvCCode) = 4 then SUBSTRING(inv.cInvCCode,0,5) else null end as �����������,case when len(inv.cInvCCode) = 4 then InvC1.cInvCName else null end as ������������
	,case when len(inv.cInvCCode) >= 6 then inv.cInvCCode else null end as �����������,case when len(inv.cInvCCode) >= 6 then InvC1.cInvCName else null end as ������������
	,inv.cInvDefine4 as ��װ,null as ��ĩ�������,null as �ϸ�,null as ���ϸ�,null as ����
	,wh.cWhCode as �ֿ����,wh.cWhName as �ֿ�����,Pos.cPosCode as ��λ����,Pos.cPosName as ��λ����
	,curr.iQuantity as �ֿ��ִ���,curr.iNum as �ֿ��ִ����
	,InvPosSum.iQuantity as ��λ�ִ���,invpossum.inum as ��λ�Դ����
	,cast(null as decimal(16,6)),cast(null as decimal(16,6)) as �ɹ�������
	,cast(null as decimal(16,6)) as �ɹ��˻�����,cast(null as decimal(16,6)) as �ɹ��˻�����
	,cast(null as decimal(16,6)) as �����ۼ��������,cast(null as decimal(16,6)) as �����ۼ�������
	,cast(null as decimal(16,6)) as �����ۼ���������,cast(null as decimal(16,6)) as �����ۼ����ϼ���
	,rds.iQuantity as �����ۼ��˿�����,rds.iNum as �����ۼ��˿����
	,cast(null as decimal(16,6)) as �ۼ���������,cast(null as decimal(16,6)) as �ۼ����ۼ���
	,cast(null as decimal(16,6)) as �ۼ������˻�����,cast(null as decimal(16,6)) as �ۼ������˻�����
from rdrecord11 rd inner join rdrecords11 rds on rd.ID = rds.ID 
	left join InvPosition invPos on invPos.RdsID = rds.AutoID
	inner join inventory inv on rds.cInvCode = inv.cInvCode
	left join Warehouse wh on rd.cWhCode = wh.cWhCode
	left join Position Pos on invPos.cPosCode = Pos.cPosCode
	left join InventoryClass InvC1 on InvC1.cInvCCode = SUBSTRING(inv.cInvCCode,0,3)
	left join InventoryClass InvC2 on InvC2.cInvCCode = SUBSTRING(inv.cInvCCode,0,5)
	left join InventoryClass InvC3 on InvC3.cInvCCode = inv.cInvCCode
	left join currentstock Curr on Curr.cInvCode = rds.cInvCode and Curr.cWhCode = rd.cWhCode 
		and Curr.cFree1 = rds.cFree1	and Curr.cFree2 = rds.cFree2	and Curr.cFree3 = rds.cFree3	and Curr.cFree4 = rds.cFree4	and Curr.cFree5 = rds.cFree5
		and Curr.cFree6 = rds.cFree6	and Curr.cFree7 = rds.cFree7	and Curr.cFree8 = rds.cFree8	and Curr.cFree9 = rds.cFree9	and Curr.cFree10 = rds.cFree10
	left join InvPositionSum InvPosSum on InvPosSum.cInvCode = rds.cInvCode and InvPosSum.cWhCode = rd.cWhCode and InvPosSum.cPosCode = invpos.cPosCode
		and InvPosSum.cFree1 = rds.cFree1	and InvPosSum.cFree2 = rds.cFree2	and InvPosSum.cFree3 = rds.cFree3	and InvPosSum.cFree4 = rds.cFree4	and InvPosSum.cFree5 = rds.cFree5
		and InvPosSum.cFree6 = rds.cFree6	and InvPosSum.cFree7 = rds.cFree7	and InvPosSum.cFree8 = rds.cFree8	and InvPosSum.cFree9 = rds.cFree9	and InvPosSum.cFree10 = rds.cFree10
where 1=1 
	and rd.dDate >= @dDate1 and rd.dDate <= @dDate2
		
-- ����
insert into #a
select distinct invPos.AutoID,rds.cInvCode as �������,inv.cInvName as �������,inv.cInvStd as ������
	,case when len(inv.cInvCCode) = 2 then SUBSTRING(inv.cInvCCode,0,3) else null end as һ���������,case when len(inv.cInvCCode) = 2 then InvC1.cInvCName else null end as һ����������
	,case when len(inv.cInvCCode) = 4 then SUBSTRING(inv.cInvCCode,0,5) else null end as �����������,case when len(inv.cInvCCode) = 4 then InvC1.cInvCName else null end as ������������
	,case when len(inv.cInvCCode) >= 6 then inv.cInvCCode else null end as �����������,case when len(inv.cInvCCode) >= 6 then InvC1.cInvCName else null end as ������������
	,inv.cInvDefine4 as ��װ,null as ��ĩ�������,null as �ϸ�,null as ���ϸ�,null as ����
	,wh.cWhCode as �ֿ����,wh.cWhName as �ֿ�����,Pos.cPosCode as ��λ����,Pos.cPosName as ��λ����
	,curr.iQuantity as �ֿ��ִ���,curr.iNum as �ֿ��ִ����
	,InvPosSum.iQuantity as ��λ�ִ���,invpossum.inum as ��λ�Դ����
	,cast(null as decimal(16,6)),cast(null as decimal(16,6)) as �ɹ�������
	,cast(null as decimal(16,6)) as �ɹ��˻�����,cast(null as decimal(16,6)) as �ɹ��˻�����
	,cast(null as decimal(16,6)) as �����ۼ��������,cast(null as decimal(16,6)) as �����ۼ�������
	,cast(null as decimal(16,6)) as �����ۼ���������,cast(null as decimal(16,6)) as �����ۼ����ϼ���
	,cast(null as decimal(16,6)) as �����ۼ��˿�����,cast(null as decimal(16,6)) as �����ۼ��˿����
	,rds.iQuantity as �ۼ���������,rds.iNum as �ۼ����ۼ���
	,cast(null as decimal(16,6)) as �ۼ������˻�����,cast(null as decimal(16,6)) as �ۼ������˻�����
from rdrecord32 rd inner join rdrecords32 rds on rd.ID = rds.ID 
	left join InvPosition invPos on invPos.RdsID = rds.AutoID
	inner join inventory inv on rds.cInvCode = inv.cInvCode
	left join Warehouse wh on rd.cWhCode = wh.cWhCode
	left join Position Pos on invPos.cPosCode = Pos.cPosCode
	left join InventoryClass InvC1 on InvC1.cInvCCode = SUBSTRING(inv.cInvCCode,0,3)
	left join InventoryClass InvC2 on InvC2.cInvCCode = SUBSTRING(inv.cInvCCode,0,5)
	left join InventoryClass InvC3 on InvC3.cInvCCode = inv.cInvCCode
	left join currentstock Curr on Curr.cInvCode = rds.cInvCode and Curr.cWhCode = rd.cWhCode 
		and Curr.cFree1 = rds.cFree1	and Curr.cFree2 = rds.cFree2	and Curr.cFree3 = rds.cFree3	and Curr.cFree4 = rds.cFree4	and Curr.cFree5 = rds.cFree5
		and Curr.cFree6 = rds.cFree6	and Curr.cFree7 = rds.cFree7	and Curr.cFree8 = rds.cFree8	and Curr.cFree9 = rds.cFree9	and Curr.cFree10 = rds.cFree10
	left join InvPositionSum InvPosSum on InvPosSum.cInvCode = rds.cInvCode and InvPosSum.cWhCode = rd.cWhCode and InvPosSum.cPosCode = invpos.cPosCode
		and InvPosSum.cFree1 = rds.cFree1	and InvPosSum.cFree2 = rds.cFree2	and InvPosSum.cFree3 = rds.cFree3	and InvPosSum.cFree4 = rds.cFree4	and InvPosSum.cFree5 = rds.cFree5
		and InvPosSum.cFree6 = rds.cFree6	and InvPosSum.cFree7 = rds.cFree7	and InvPosSum.cFree8 = rds.cFree8	and InvPosSum.cFree9 = rds.cFree9	and InvPosSum.cFree10 = rds.cFree10
where  isnull(rds.iQuantity,0) > 0
	and rd.dDate >= @dDate1 and rd.dDate <= @dDate2
	
	--case when len(cinvccode) = 2
		
-- �����˻�
insert into #a
select distinct invPos.AutoID,rds.cInvCode as �������,inv.cInvName as �������,inv.cInvStd as ������
	,case when len(inv.cInvCCode) = 2 then SUBSTRING(inv.cInvCCode,0,3) else null end as һ���������,case when len(inv.cInvCCode) = 2 then InvC1.cInvCName else null end as һ����������
	,case when len(inv.cInvCCode) = 4 then SUBSTRING(inv.cInvCCode,0,5) else null end as �����������,case when len(inv.cInvCCode) = 4 then InvC1.cInvCName else null end as ������������
	,case when len(inv.cInvCCode) >= 6 then inv.cInvCCode else null end as �����������,case when len(inv.cInvCCode) >= 6 then InvC1.cInvCName else null end as ������������
	,inv.cInvDefine4 as ��װ,null as ��ĩ�������,null as �ϸ�,null as ���ϸ�,null as ����
	,wh.cWhCode as �ֿ����,wh.cWhName as �ֿ�����,Pos.cPosCode as ��λ����,Pos.cPosName as ��λ����
	,curr.iQuantity as �ֿ��ִ���,curr.iNum as �ֿ��ִ����
	,InvPosSum.iQuantity as ��λ�ִ���,invpossum.inum as ��λ�Դ����
	,cast(null as decimal(16,6)),cast(null as decimal(16,6)) as �ɹ�������
	,cast(null as decimal(16,6)) as �ɹ��˻�����,cast(null as decimal(16,6)) as �ɹ��˻�����
	,cast(null as decimal(16,6)) as �����ۼ��������,cast(null as decimal(16,6)) as �����ۼ�������
	,cast(null as decimal(16,6)) as �����ۼ���������,cast(null as decimal(16,6)) as �����ۼ����ϼ���
	,cast(null as decimal(16,6)) as �����ۼ��˿�����,cast(null as decimal(16,6)) as �����ۼ��˿����
	,cast(null as decimal(16,6)) as �ۼ���������, cast(null as decimal(16,6)) as �ۼ����ۼ���
	,cast(null as decimal(16,6)) as �ۼ������˻�����,cast(null as decimal(16,6)) as �ۼ������˻�����
from rdrecord32 rd inner join rdrecords32 rds on rd.ID = rds.ID 
	left join InvPosition invPos on invPos.RdsID = rds.AutoID
	inner join inventory inv on rds.cInvCode = inv.cInvCode
	left join Warehouse wh on rd.cWhCode = wh.cWhCode
	left join Position Pos on invPos.cPosCode = Pos.cPosCode
	left join InventoryClass InvC1 on InvC1.cInvCCode = SUBSTRING(inv.cInvCCode,0,3)
	left join InventoryClass InvC2 on InvC2.cInvCCode = SUBSTRING(inv.cInvCCode,0,5)
	left join InventoryClass InvC3 on InvC3.cInvCCode = inv.cInvCCode
	left join currentstock Curr on Curr.cInvCode = rds.cInvCode and Curr.cWhCode = rd.cWhCode 
		and Curr.cFree1 = rds.cFree1	and Curr.cFree2 = rds.cFree2	and Curr.cFree3 = rds.cFree3	and Curr.cFree4 = rds.cFree4	and Curr.cFree5 = rds.cFree5
		and Curr.cFree6 = rds.cFree6	and Curr.cFree7 = rds.cFree7	and Curr.cFree8 = rds.cFree8	and Curr.cFree9 = rds.cFree9	and Curr.cFree10 = rds.cFree10
	left join InvPositionSum InvPosSum on InvPosSum.cInvCode = rds.cInvCode and InvPosSum.cWhCode = rd.cWhCode and InvPosSum.cPosCode = invpos.cPosCode
		and InvPosSum.cFree1 = rds.cFree1	and InvPosSum.cFree2 = rds.cFree2	and InvPosSum.cFree3 = rds.cFree3	and InvPosSum.cFree4 = rds.cFree4	and InvPosSum.cFree5 = rds.cFree5
		and InvPosSum.cFree6 = rds.cFree6	and InvPosSum.cFree7 = rds.cFree7	and InvPosSum.cFree8 = rds.cFree8	and InvPosSum.cFree9 = rds.cFree9	and InvPosSum.cFree10 = rds.cFree10
where  isnull(rds.iQuantity,0) < 0
	and rd.dDate >= @dDate1 and rd.dDate <= @dDate2
	
	
select * from #a

--select case when len(cinvccode) = 2 then cinvccode else null end
--	, *
--from InventoryClass

	

	
