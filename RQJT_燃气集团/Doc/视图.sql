

IF EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = N'_viewRecordOut')
	drop view _viewRecordOut

go

CREATE view [dbo].[_viewRecordOut]
as
Select ID,AutoID,cWhName as �ֿ�,convert(date,dDate) as ��������,cCode ���ⵥ��,cBusType as ҵ������,cRdCode as ����������
	,cDepName ����,cInvCode as ���ϱ���,cInvName as ��������,cInvStd as ����ͺ�,cInvM_Unit ������λ,iQuantity as ���� 
From RecordOutList WHERE isnull(bPuFirst,0)<> 1 and cbustype<>'ί�����'  and  cbustype <> '������' 


