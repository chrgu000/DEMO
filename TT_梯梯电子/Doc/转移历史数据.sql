
---------------------------
insert into [dbo].[TK_Trialkit_Calculate_History]
	( [GUID], sTKVersion, sDataVersion, iID_NetRequirement_Sum, 
      toplevel, Qty_toplevel, dDate_toplevel, sProductGroup, child, childCycle, childsCycle, 
      Qty_bom, Cumqty_bom, childsm, depth, qtyChild, dtmStart, dtmEnd, CreateUid, dtmCreate
)
select [GUID], sTKVersion, sDataVersion, iID_NetRequirement_Sum, 
      toplevel, Qty_toplevel, dDate_toplevel, sProductGroup, child, childCycle, childsCycle, 
      Qty_bom, Cumqty_bom, childsm, depth, qtyChild, dtmStart, dtmEnd, CreateUid, dtmCreate
from [dbo].[TK_Trialkit_Calculate]
where dtmCreate <= DATEADD(day,-2,Convert(varchar(10),getdate(),120))


delete [TK_Trialkit_Calculate] where dtmCreate <= DATEADD(day,-2,Convert(varchar(10),getdate(),120))

---------------------------
insert into [dbo].[TK_Trialkit_Trial_Upload_History]
			([Guid], sTKVersion, sDataVersion, Partid, dDate, dtmPeriod, Qty, iUpload_Type, sTKVersion_Contrast, 
                iTK_Type, Remark, CreateUid, dtmCreate)
select  [Guid], sTKVersion, sDataVersion, Partid, dDate, dtmPeriod, Qty, iUpload_Type, sTKVersion_Contrast, 
                iTK_Type, Remark, CreateUid, dtmCreate
FROM      TK_Trialkit_Trial_Upload
where dtmCreate <= DATEADD(day,-2,Convert(varchar(10),getdate(),120))

delete TK_Trialkit_Trial_Upload where dtmCreate <= DATEADD(day,-2,Convert(varchar(10),getdate(),120))

---------------------------
insert into TK_Trialkitting_Result_History( [Guid], sTKVersion, sDataVersion, CreateUid, dtmCreate, Remark, DataFrom)
select [Guid], sTKVersion, sDataVersion, CreateUid, dtmCreate, Remark, DataFrom
FROM  TK_Trialkitting_Result
where dtmCreate <= DATEADD(day,-2,Convert(varchar(10),getdate(),120))

insert into [dbo].[TK_Trialkitting_Results_History] ([GUID], sTKVersion, dDate, Planner, ProdGroup, cInvCode, NetQty, Reorderpolicy, DayWO, QtyCurr, QtyWO, Qty, dtmQty)
select [GUID], sTKVersion, dDate, Planner, ProdGroup, cInvCode, NetQty, Reorderpolicy, DayWO, QtyCurr, QtyWO, Qty, dtmQty
from [TK_Trialkitting_Results]
where sTKVersion in (select sTKVersion from TK_Trialkitting_Result where dtmCreate <= DATEADD(day,-2,Convert(varchar(10),getdate(),120)))


delete TK_Trialkitting_Results where sTKVersion in (select sTKVersion from TK_Trialkitting_Result where dtmCreate <= DATEADD(day,-2,Convert(varchar(10),getdate(),120)))
delete TK_Trialkitting_Result where dtmCreate <= DATEADD(day,-2,Convert(varchar(10),getdate(),120))


