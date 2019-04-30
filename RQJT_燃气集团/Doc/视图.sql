

IF EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = N'_viewRecordOut')
	drop view _viewRecordOut

go

CREATE view [dbo].[_viewRecordOut]
as
Select ID,AutoID,cWhName as 仓库,convert(date,dDate) as 出库日期,cCode 出库单号,cBusType as 业务类型,cRdCode as 出库类别编码
	,cDepName 部门,cInvCode as 材料编码,cInvName as 材料名称,cInvStd as 规格型号,cInvM_Unit 计量单位,iQuantity as 数量 
From RecordOutList WHERE isnull(bPuFirst,0)<> 1 and cbustype<>'委外出库'  and  cbustype <> '假退料' 


