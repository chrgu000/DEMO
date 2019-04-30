using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public class 数据源
    {
        public DataTable 收发存汇总(string Conn,string sdate, string edate)
        {
            string sSQL = @"select substring(convert(nvarchar,max(iYPeriod)),5,2),
dateadd(m,1,substring(convert(nvarchar,max(iYPeriod)),0,5) + '-'+substring(convert(nvarchar,max(iYPeriod)),5,2) +'-01') 
,dateadd(d,-1,dateadd(m,1,substring(convert(nvarchar,max(iYPeriod)),0,5) + '-'+substring(convert(nvarchar,max(iYPeriod)),5,2) +'-01') )
from gl_mend with (nolock)  where iYPeriod< 555555 and  bflag_st=1 and iperiod <>0 ";
            sSQL = sSQL.Replace("555555", "'" + Convert.ToDateTime(sdate).ToString("yyyyMM") + "'");
            DataTable dtday = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            //int imonth = int.Parse(dtday.Rows[0][0].ToString());
            //string day =DateTime.Parse(dtday.Rows[0][1].ToString()).ToString("yyyy-MM-dd");
            string sdate2 = DateTime.Parse(dtday.Rows[0][1].ToString()).ToString("yyyy-MM-dd");
            int iyear = DateTime.Parse(dtday.Rows[0][2].ToString()).Year;
            int imonth = DateTime.Parse(dtday.Rows[0][2].ToString()).Month;
            //int iyear = DateTime.Parse(DateTime.Parse(sdate).Year + "-" + DateTime.Parse(sdate).Month+"-01").AddDays(-1).Year;
            //int iyear1 = iyear;
            //if (imonth != 12)
            //{
            //    iyear1 = iyear1 - 1;
            //}
            
            //if (day0 == 12)
            //{
            //    month0 = month0 - 1;
            //}
            //if (DateTime.Compare(Convert.ToDateTime(day), Convert.ToDateTime(sdate)) < 0)
            //{
            //    sdate = day;
            //}
            sSQL = @"

------------------------------------将输入插入暂存表
select id into #rdrecord01 from rdrecord01 RdRecord where 1=1 and ((RdRecord.dDate < 111111 And IsNull(RdRecord.bIsSTQc,0) = 1) Or (RdRecord.dDate >= 111111 And IsNull(RdRecord.bPUFirst,0) = 0 And IsNull(RdRecord.bIAFirst,0) = 0 And IsNull(RdRecord.bOMFirst,0) = 0 And (not (RdRecord.cBusType = N'假退料'and RdRecord.cVouchType = 11)))) AND  dDate <= 333333  AND  dDate >= 666666
select id into #rdrecord08 from rdrecord08 RdRecord where 1=1 and ((RdRecord.dDate < 111111 And IsNull(RdRecord.bIsSTQc,0) = 1) Or (RdRecord.dDate >= 111111 And IsNull(RdRecord.bPUFirst,0) = 0 And IsNull(RdRecord.bIAFirst,0) = 0 And IsNull(RdRecord.bOMFirst,0) = 0 And (not (RdRecord.cBusType = N'假退料'and RdRecord.cVouchType = 11)))) AND  dDate <= 333333  AND  dDate >= 666666
select id into #rdrecord09 from rdrecord09 RdRecord where 1=1 and ((RdRecord.dDate < 111111 And IsNull(RdRecord.bIsSTQc,0) = 1) Or (RdRecord.dDate >= 111111 And IsNull(RdRecord.bPUFirst,0) = 0 And IsNull(RdRecord.bIAFirst,0) = 0 And IsNull(RdRecord.bOMFirst,0) = 0 And (not (RdRecord.cBusType = N'假退料'and RdRecord.cVouchType = 11)))) AND  dDate <= 333333  AND  dDate >= 666666
select id into #rdrecord10 from rdrecord10 RdRecord where 1=1 and ((RdRecord.dDate < 111111 And IsNull(RdRecord.bIsSTQc,0) = 1) Or (RdRecord.dDate >= 111111 And IsNull(RdRecord.bPUFirst,0) = 0 And IsNull(RdRecord.bIAFirst,0) = 0 And IsNull(RdRecord.bOMFirst,0) = 0 And (not (RdRecord.cBusType = N'假退料'and RdRecord.cVouchType = 11)))) AND  dDate <= 333333  AND  dDate >= 666666
select id into #rdrecord11 from rdrecord11 RdRecord where 1=1 and ((RdRecord.dDate < 111111 And IsNull(RdRecord.bIsSTQc,0) = 1) Or (RdRecord.dDate >= 111111 And IsNull(RdRecord.bPUFirst,0) = 0 And IsNull(RdRecord.bIAFirst,0) = 0 And IsNull(RdRecord.bOMFirst,0) = 0 And (not (RdRecord.cBusType = N'假退料'and RdRecord.cVouchType = 11)))) AND  dDate <= 333333  AND  dDate >= 666666
select id into #rdrecord32 from rdrecord32 RdRecord where 1=1 and ((RdRecord.dDate < 111111 And IsNull(RdRecord.bIsSTQc,0) = 1) Or (RdRecord.dDate >= 111111 And IsNull(RdRecord.bPUFirst,0) = 0 And IsNull(RdRecord.bIAFirst,0) = 0 And IsNull(RdRecord.bOMFirst,0) = 0 And (not (RdRecord.cBusType = N'假退料'and RdRecord.cVouchType = 11)))) AND  dDate <= 333333  AND  dDate >= 666666
select id into #rdrecord34 from rdrecord34 RdRecord where 1=1 and ((RdRecord.dDate < 111111 And IsNull(RdRecord.bIsSTQc,0) = 1) Or (RdRecord.dDate >= 111111 And IsNull(RdRecord.bPUFirst,0) = 0 And IsNull(RdRecord.bIAFirst,0) = 0 And IsNull(RdRecord.bOMFirst,0) = 0 And (not (RdRecord.cBusType = N'假退料'and RdRecord.cVouchType = 11)))) AND  dDate <= 333333  AND  dDate >= 666666

------------------------------------统计暂存表至#temp1
--1
Select autoid,rdrecord.cwhcode,cWhName,inventory.cInvCCode ,cInvCName ,rdrecords.cinvcode,inventory.cInvStd,inventory.cInvName,IsNull(cItem_class,N'') AS cItem_class ,
IsNull(cItemCName,N'') AS cItemCName  ,IsNull(cItemCode,N'') AS cItemCode ,IsNull(cName,N'')  As cName,RdRecord.bRdFlag,
isnull(RdRecord.cDefine3,N'') as cDefine3,isnull(RdRecord.cDefine9,N'') as cDefine9,isnull(RdRecord.cDefine1,N'') as cDefine1,isnull(RdRecord.cDefine2,N'') as cDefine2,isnull(RdRecord.cDefine10,N'') as cDefine10,isnull(RdRecords.cDefine22,N'') as cDefine22,isnull(RdRecords.cDefine25,N'') as cDefine25,isnull(RdRecords.cDefine28,N'') as cDefine28,isnull(RdRecords.cDefine31,N'') as cDefine31,isnull(RdRecords.cDefine23,N'') as cDefine23,isnull(RdRecords.cDefine24,N'') as cDefine24,isnull(RdRecords.cDefine26,Null) as cDefine26,isnull(cFree1,N'') as cFree1,isnull(cFree2,N'') as cFree2,isnull(cFree3,N'') as cFree3,isnull(cFree4,N'') as cFree4,
Left(RdRecord.cRdCode,5) As cRdCode, rdrecords.cBatch,cBatchProperty6,cBatchProperty7,cBatchProperty8,cposname,rdrecords.cPosition,
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ELSE 0 END) * convert(decimal(38,8),i.iquantity)  as iquantity, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then i.iquantity/Cu_f.iChangRate else i.iNum end  )  as iNum, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 0 else  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END  END) * convert(decimal(38,8),i.iquantity)  as iQCJCSL, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 0 else  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END  END ) * (case  Inventory.iGroupType when  0 then Null when 1 then i.iquantity/Cu_f.iChangRate else i.iNum end  )  as iQCJCJS, 
convert(decimal(38,3),(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE 0 END ELSE 0 END) * convert(decimal(38,8),i.iquantity))  as iInQuantity, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE 0 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then i.iquantity/Cu_f.iChangRate else i.iNum end  )  as iinNum, 
convert(decimal(38,3),(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then  CASE WHEN RdRecord.bRdFlag <>0 THEN 0 ELSE 1 END ELSE 0 END) * convert(decimal(38,8),i.iquantity))  as ioutQuantity, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then  CASE WHEN RdRecord.bRdFlag <>0 THEN 0 ELSE 1 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then i.iquantity/Cu_f.iChangRate else i.iNum end  )  as ioutNum, 
( CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ) * convert(decimal(38,8),i.iquantity)  as iQMJCSL, 
( CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ) *  (case  Inventory.iGroupType when  0 then Null when 1 then i.iquantity/Cu_f.iChangRate else i.iNum end  )  as iQMJCJS, 
iOriTaxCost  as iUnitCost,  CU_F.cComUnitName as cInvA_Unit
,convert(decimal(18, 3),null) as 累计入库,convert(decimal(18, 3),null) as 累计领料,convert(decimal(18, 3),null) as 累计退库
,convert(decimal(18, 3),(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE 0 END ELSE 0 END) * convert(decimal(38,8),i.iquantity)) as 采购入库
,convert(decimal(18, 3),(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then  CASE WHEN RdRecord.bRdFlag <>0 THEN 0 ELSE 1 END ELSE 0 END) * convert(decimal(38,8),i.iquantity)) as 退货数量
,convert(decimal(18, 3),null) as 累计销售,convert(decimal(18, 3),null) as 累计退货
,convert(decimal(18, 3),null) as 累计其他入库,convert(decimal(18, 3),null) as 累计其他出库,convert(varchar(50),null) as cVouchType
,convert(decimal(18, 3),null) as iQty01,convert(decimal(18, 3),null) as iQty08,convert(decimal(18, 3),null) as iQty09
,convert(decimal(18, 3),null) as iQty10,convert(decimal(18, 3),null) as iQty11,convert(decimal(18, 3),null) as iQty32,convert(datetime,null)  dDate,convert(varchar(50),null) as Flag,convert(varchar(500),null) cCode
,case when ISNULL(cHandler ,'')<>'' then '审核' when isnull(iswfcontrolled,0)=1 and isnull(iverifystate ,0)=1 then '审核中' when ISNULL(cMaker,'')<>'' then '开立' end as 审批状态,cCurrentAuditor as 当前审批人,convert(decimal(18, 3),null) as 采购订单在途
,convert(varchar(500),null) as cCusName,convert(varchar(500),null) as cVenName,rdrecord.cdepcode,department.cdepname
INTO #temp1 from 
rdrecord01 rdrecord left join rdrecords01 rdrecords on rdrecord.id=rdrecords.id 
left join inventory on rdrecords.cinvcode=inventory.cinvcode 
left join warehouse on RdRecord.cWhCode = Warehouse.cWhCode
left JOIN InventoryClass On Inventory.cInvCCode = InventoryClass.cInvCCode
left join department on rdrecord.cdepcode =department.cdepcode 
left join ComputationUnit CU_F on Inventory.cSTComUnitCode = CU_F.cComUnitCode
left join (select rdsid,iquantity,inum,cposname from InvPositionD) i on rdrecords.AutoID=i.rdsid where 1=0 

--2
insert into #temp1  Select autoid,rdrecord.cwhcode,cWhName,inventory.cInvCCode ,cInvCName ,rdrecords.cinvcode,inventory.cInvStd,inventory.cInvName,IsNull(cItem_class,N'') AS cItem_class ,
IsNull(cItemCName,N'') AS cItemCName  ,IsNull(cItemCode,N'') AS cItemCode ,IsNull(cName,N'')  As cName,RdRecord.bRdFlag,
isnull(RdRecord.cDefine3,N'') as cDefine3,isnull(RdRecord.cDefine9,N'') as cDefine9,isnull(RdRecord.cDefine1,N'') as cDefine1,isnull(RdRecord.cDefine2,N'') as cDefine2,isnull(RdRecord.cDefine10,N'') as cDefine10,isnull(RdRecords.cDefine22,N'') as cDefine22,isnull(RdRecords.cDefine25,N'') as cDefine25,isnull(RdRecords.cDefine28,N'') as cDefine28,isnull(RdRecords.cDefine31,N'') as cDefine31,isnull(RdRecords.cDefine23,N'') as cDefine23,isnull(RdRecords.cDefine24,N'') as cDefine24,isnull(RdRecords.cDefine26,Null) as cDefine26,isnull(cFree1,N'') as cFree1,isnull(cFree2,N'') as cFree2,isnull(cFree3,N'') as cFree3,isnull(cFree4,N'') as cFree4,
Left(RdRecord.cRdCode,5) As cRdCode, rdrecords.cBatch,cBatchProperty6,cBatchProperty7,cBatchProperty8,cposname,rdrecords.cPosition,
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ELSE 0 END) * convert(decimal(38,8),i.iquantity)  as iquantity, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then i.iquantity/Cu_f.iChangRate else i.iNum end  )  as iNum, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 0 else 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END  END) * convert(decimal(38,8),i.iquantity)  as iQCJCSL, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 0 else 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END  END ) * (case  Inventory.iGroupType when  0 then Null when 1 then i.iquantity/Cu_f.iChangRate else i.iNum end  )  as iQCJCJS, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE 0 END ELSE 0 END) * convert(decimal(38,8),i.iquantity)  as iInQuantity, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE 0 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then i.iquantity/Cu_f.iChangRate else i.iNum end  )  as iinNum, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 0 ELSE 1 END ELSE 0 END) * convert(decimal(38,8),i.iquantity)  as ioutQuantity, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 0 ELSE 1 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then i.iquantity/Cu_f.iChangRate else i.iNum end  )  as ioutNum, 
( CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ) * convert(decimal(38,8),i.iquantity)  as iQMJCSL, 
( CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ) *  (case  Inventory.iGroupType when  0 then Null when 1 then i.iquantity/Cu_f.iChangRate else i.iNum end  )  as iQMJCJS, 
iOriTaxCost  as iUnitCost,  CU_F.cComUnitName as cInvA_Unit
,convert(decimal(18, 3),null) as 累计入库,convert(decimal(18, 3),null) as 累计领料,convert(decimal(18, 3),null) as 累计退库
,convert(decimal(18, 3),null) as 采购入库,convert(decimal(18, 3),null) as 退货数量
,convert(decimal(18, 3),null) as 累计销售,convert(decimal(18, 3),null) as 累计退货
,convert(decimal(18, 3),null) as 累计其他入库,convert(decimal(18, 3),null) as 累计其他出库,cVouchType
,convert(decimal(18, 3),i.iquantity) as iQty01,convert(decimal(18, 3),null) as iQty08,convert(decimal(18, 3),null) as iQty09
,convert(decimal(18, 3),null) as iQty10,convert(decimal(18, 3),null) as iQty11,convert(decimal(18, 3),null) as iQty32,dDate,'01' as Flag,cCode
,case when ISNULL(cHandler ,'')<>'' then '审核' when isnull(iswfcontrolled,0)=1 and isnull(iverifystate ,0)=1 then '审核中' when ISNULL(cMaker,'')<>'' then '开立' end as 审批状态,cCurrentAuditor as 当前审批人,convert(decimal(18, 3),null) as 采购订单在途
,null as cCusName,cVenName,rdrecord.cdepcode,department.cdepname
from 
rdrecord01 rdrecord left join rdrecords01 rdrecords on rdrecord.id=rdrecords.id 
left join inventory on rdrecords.cinvcode=inventory.cinvcode 
left join warehouse on RdRecord.cWhCode = Warehouse.cWhCode
left JOIN InventoryClass On Inventory.cInvCCode = InventoryClass.cInvCCode
left join department on rdrecord.cdepcode =department.cdepcode 
left join ComputationUnit CU_F on Inventory.cSTComUnitCode = CU_F.cComUnitCode
left join (select rdsid,iquantity,inum,cposname from InvPositionD) i on rdrecords.AutoID=i.rdsid 
left join Vendor cus on rdrecord.cVenCode =cus.cVenCode 
where 2=2 and 
rdrecord.id in (select id from  #rdrecord01 )

--AND (Inventory.cInvCode >= N'BJ0024') and (Inventory.cInvCode <= N'BJ0024')

--3
insert into #temp1  Select autoid,rdrecord.cwhcode,cWhName,inventory.cInvCCode ,cInvCName ,rdrecords.cinvcode,inventory.cInvStd,inventory.cInvName,IsNull(cItem_class,N'') AS cItem_class ,
IsNull(cItemCName,N'') AS cItemCName  ,IsNull(cItemCode,N'') AS cItemCode ,IsNull(cName,N'')  As cName,RdRecord.bRdFlag,
isnull(RdRecord.cDefine3,N'') as cDefine3,isnull(RdRecord.cDefine9,N'') as cDefine9,isnull(RdRecord.cDefine1,N'') as cDefine1,isnull(RdRecord.cDefine2,N'') as cDefine2,isnull(RdRecord.cDefine10,N'') as cDefine10,isnull(RdRecords.cDefine22,N'') as cDefine22,isnull(RdRecords.cDefine25,N'') as cDefine25,isnull(RdRecords.cDefine28,N'') as cDefine28,isnull(RdRecords.cDefine31,N'') as cDefine31,isnull(RdRecords.cDefine23,N'') as cDefine23,isnull(RdRecords.cDefine24,N'') as cDefine24,isnull(RdRecords.cDefine26,Null) as cDefine26,isnull(cFree1,N'') as cFree1,isnull(cFree2,N'') as cFree2,isnull(cFree3,N'') as cFree3,isnull(cFree4,N'') as cFree4,
Left(RdRecord.cRdCode,5) As cRdCode, rdrecords.cBatch,cBatchProperty6,cBatchProperty7,cBatchProperty8,cposname,rdrecords.cPosition,
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ELSE 0 END) * convert(decimal(38,8),i.iquantity)  as iquantity, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then i.iquantity/Cu_f.iChangRate else i.iNum end  )  as iNum, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 0 else 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END  END) * convert(decimal(38,8),i.iquantity)  as iQCJCSL, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 0 else 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END  END ) * (case  Inventory.iGroupType when  0 then Null when 1 then i.iquantity/Cu_f.iChangRate else i.iNum end  )  as iQCJCJS, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then   CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE 0 END ELSE 0 END) * convert(decimal(38,8),i.iquantity)  as iInQuantity, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE 0 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then i.iquantity/Cu_f.iChangRate else i.iNum end  )  as iinNum, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 0 ELSE 1 END ELSE 0 END) * convert(decimal(38,8),i.iquantity)  as ioutQuantity, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 0 ELSE 1 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then i.iquantity/Cu_f.iChangRate else i.iNum end  )  as ioutNum, 
( CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ) * convert(decimal(38,8),i.iquantity)  as iQMJCSL, 
( CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ) *  (case  Inventory.iGroupType when  0 then Null when 1 then i.iquantity/Cu_f.iChangRate else i.iNum end  )  as iQMJCJS, 
iUnitCost,  CU_F.cComUnitName as cInvA_Unit 
,convert(decimal(18, 3),null) as 累计入库,convert(decimal(18, 3),null) as 累计领料,convert(decimal(18, 3),null) as 累计退库
,convert(decimal(18, 3),null) as 采购入库,convert(decimal(18, 3),null) as 退货数量
,convert(decimal(18, 3),null) as 累计销售,convert(decimal(18, 3),null) as 累计退货
,convert(decimal(18, 3),(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then   CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE 0 END ELSE 0 END) * convert(decimal(38,8),i.iquantity)) as 累计其他入库,convert(decimal(18, 3),null) as 累计其他出库,cVouchType
,convert(decimal(18, 3),null) as iQty01,convert(decimal(18, 3),i.iquantity) as iQty08,convert(decimal(18, 3),null) as iQty09
,convert(decimal(18, 3),null) as iQty10,convert(decimal(18, 3),null) as iQty11,convert(decimal(18, 3),null) as iQty32,dDate,'08' as Flag,cCode
,case when ISNULL(cHandler ,'')<>'' then '审核' when isnull(iswfcontrolled,0)=1 and isnull(iverifystate ,0)=1 then '审核中' when ISNULL(cMaker,'')<>'' then '开立' end as 审批状态,cCurrentAuditor as 当前审批人,convert(decimal(18, 3),null) as 采购订单在途
,null as cCusName,null as cVenName,rdrecord.cdepcode,department.cdepname
from 
rdrecord08 rdrecord left join rdrecords08 rdrecords on rdrecord.id=rdrecords.id 
left join inventory on rdrecords.cinvcode=inventory.cinvcode 
left join warehouse on RdRecord.cWhCode = Warehouse.cWhCode
left JOIN InventoryClass On Inventory.cInvCCode = InventoryClass.cInvCCode
left join department on rdrecord.cdepcode =department.cdepcode 
left join ComputationUnit CU_F on Inventory.cSTComUnitCode = CU_F.cComUnitCode
left join (select rdsid,iquantity,inum,cposname from InvPositionD) i on rdrecords.AutoID=i.rdsid
where 2=2 and 
rdrecord.id in (select id from  #rdrecord08 )
--and (rdrecord.cbustype <> N'预留入库' or rdrecord.bisstqc=1 ) 

--AND (Inventory.cInvCode >= N'BJ0024') and (Inventory.cInvCode <= N'BJ0024')
--4
insert into #temp1  Select autoid,rdrecord.cwhcode,cWhName,inventory.cInvCCode ,cInvCName ,rdrecords.cinvcode,inventory.cInvStd,inventory.cInvName,IsNull(cItem_class,N'') AS cItem_class ,
IsNull(cItemCName,N'') AS cItemCName  ,IsNull(cItemCode,N'') AS cItemCode ,IsNull(cName,N'')  As cName,RdRecord.bRdFlag,
isnull(RdRecord.cDefine3,N'') as cDefine3,isnull(RdRecord.cDefine9,N'') as cDefine9,isnull(RdRecord.cDefine1,N'') as cDefine1,isnull(RdRecord.cDefine2,N'') as cDefine2,isnull(RdRecord.cDefine10,N'') as cDefine10,isnull(RdRecords.cDefine22,N'') as cDefine22,isnull(RdRecords.cDefine25,N'') as cDefine25,isnull(RdRecords.cDefine28,N'') as cDefine28,isnull(RdRecords.cDefine31,N'') as cDefine31,isnull(RdRecords.cDefine23,N'') as cDefine23,isnull(RdRecords.cDefine24,N'') as cDefine24,isnull(RdRecords.cDefine26,Null) as cDefine26,isnull(cFree1,N'') as cFree1,isnull(cFree2,N'') as cFree2,isnull(cFree3,N'') as cFree3,isnull(cFree4,N'') as cFree4,
Left(RdRecord.cRdCode,5) As cRdCode, rdrecords.cBatch,cBatchProperty6,cBatchProperty7,cBatchProperty8,cposname,rdrecords.cPosition,
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ELSE 0 END) * convert(decimal(38,8),i.iquantity)  as iquantity, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then i.iquantity/Cu_f.iChangRate else i.iNum end  )  as iNum, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 0 else 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END  END) * convert(decimal(38,8),i.iquantity)  as iQCJCSL, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 0 else 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END  END ) * (case  Inventory.iGroupType when  0 then Null when 1 then i.iquantity/Cu_f.iChangRate else i.iNum end  )  as iQCJCJS, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE 0 END ELSE 0 END) * convert(decimal(38,8),i.iquantity)  as iInQuantity, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE 0 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then i.iquantity/Cu_f.iChangRate else i.iNum end  )  as iinNum, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then  CASE WHEN RdRecord.bRdFlag <>0 THEN 0 ELSE 1 END ELSE 0 END) * convert(decimal(38,8),i.iquantity)  as ioutQuantity, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 0 ELSE 1 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then i.iquantity/Cu_f.iChangRate else i.iNum end  )  as ioutNum, 
( CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ) * convert(decimal(38,8),i.iquantity)  as iQMJCSL, 
( CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ) *  (case  Inventory.iGroupType when  0 then Null when 1 then i.iquantity/Cu_f.iChangRate else i.iNum end  )  as iQMJCJS, 
iUnitCost,  CU_F.cComUnitName as cInvA_Unit
,convert(decimal(18, 3),null) as 累计入库,convert(decimal(18, 3),null) as 累计领料,convert(decimal(18, 3),null) as 累计退库
,convert(decimal(18, 3),null) as 采购入库,convert(decimal(18, 3),null) as 退货数量
,convert(decimal(18, 3),null) as 累计销售,convert(decimal(18, 3),null) as 累计退货
,convert(decimal(18, 3),null) as 累计其他入库,convert(decimal(18, 3),(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then  CASE WHEN RdRecord.bRdFlag <>0 THEN 0 ELSE 1 END ELSE 0 END) * convert(decimal(38,8),i.iquantity) ) as 累计其他出库,cVouchType
,convert(decimal(18, 3),null) as iQty01,convert(decimal(18, 3),null) as iQty08,convert(decimal(18, 3),i.iquantity) as iQty09
,convert(decimal(18, 3),null) as iQty10,convert(decimal(18, 3),null) as iQty11,convert(decimal(18, 3),null) as iQty32,dDate,'09' as Flag,cCode
,case when ISNULL(cHandler ,'')<>'' then '审核' when isnull(iswfcontrolled,0)=1 and isnull(iverifystate ,0)=1 then '审核中' when ISNULL(cMaker,'')<>'' then '开立' end as 审批状态,cCurrentAuditor as 当前审批人,convert(decimal(18, 3),null) as 采购订单在途
,null as cCusName,null as cVenName,rdrecord.cdepcode,department.cdepname
from 
rdrecord09 rdrecord left join rdrecords09 rdrecords on rdrecord.id=rdrecords.id 
left join inventory on rdrecords.cinvcode=inventory.cinvcode 
left join warehouse on RdRecord.cWhCode = Warehouse.cWhCode
left JOIN InventoryClass On Inventory.cInvCCode = InventoryClass.cInvCCode
left join department on rdrecord.cdepcode =department.cdepcode 
left join ComputationUnit CU_F on Inventory.cSTComUnitCode = CU_F.cComUnitCode
left join (select rdsid,iquantity,inum,cposname from InvPositionD) i on rdrecords.AutoID=i.rdsid
where 2=2 and 
rdrecord.id in (select id from  #rdrecord09 )
--and ( rdrecord.cbustype <> N'预留出库' or rdrecord.bisstqc=1 ) 

--AND (Inventory.cInvCode >= N'BJ0024') and (Inventory.cInvCode <= N'BJ0024')

--5
insert into #temp1  Select autoid,rdrecord.cwhcode,cWhName,inventory.cInvCCode ,cInvCName ,rdrecords.cinvcode,inventory.cInvStd,inventory.cInvName,IsNull(cItem_class,N'') AS cItem_class ,
IsNull(cItemCName,N'') AS cItemCName  ,IsNull(cItemCode,N'') AS cItemCode ,IsNull(cName,N'')  As cName,RdRecord.bRdFlag,
isnull(RdRecord.cDefine3,N'') as cDefine3,isnull(RdRecord.cDefine9,N'') as cDefine9,isnull(RdRecord.cDefine1,N'') as cDefine1,isnull(RdRecord.cDefine2,N'') as cDefine2,isnull(RdRecord.cDefine10,N'') as cDefine10,isnull(RdRecords.cDefine22,N'') as cDefine22,isnull(RdRecords.cDefine25,N'') as cDefine25,isnull(RdRecords.cDefine28,N'') as cDefine28,isnull(RdRecords.cDefine31,N'') as cDefine31,isnull(RdRecords.cDefine23,N'') as cDefine23,isnull(RdRecords.cDefine24,N'') as cDefine24,isnull(RdRecords.cDefine26,Null) as cDefine26,isnull(cFree1,N'') as cFree1,isnull(cFree2,N'') as cFree2,isnull(cFree3,N'') as cFree3,isnull(cFree4,N'') as cFree4,
Left(RdRecord.cRdCode,5) As cRdCode, rdrecords.cBatch,cBatchProperty6,cBatchProperty7,cBatchProperty8,cposname,rdrecords.cPosition,
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ELSE 0 END) * convert(decimal(38,8),i.iquantity)  as iquantity, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then i.iquantity/Cu_f.iChangRate else i.iNum end  )  as iNum, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 0 else 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END  END) * convert(decimal(38,8),i.iquantity)  as iQCJCSL, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 0 else 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END  END ) * (case  Inventory.iGroupType when  0 then Null when 1 then i.iquantity/Cu_f.iChangRate else i.iNum end  )  as iQCJCJS, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE 0 END ELSE 0 END) * convert(decimal(38,8),i.iquantity)  as iInQuantity, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE 0 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then i.iquantity/Cu_f.iChangRate else i.iNum end  )  as iinNum, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 0 ELSE 1 END ELSE 0 END) * convert(decimal(38,8),i.iquantity)  as ioutQuantity, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 0 ELSE 1 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then i.iquantity/Cu_f.iChangRate else i.iNum end  )  as ioutNum, 
( CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ) * convert(decimal(38,8),i.iquantity)  as iQMJCSL, 
( CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ) *  (case  Inventory.iGroupType when  0 then Null when 1 then i.iquantity/Cu_f.iChangRate else i.iNum end  )  as iQMJCJS, 
iUnitCost,  CU_F.cComUnitName as cInvA_Unit
,convert(decimal(18, 3),null) as 累计入库,convert(decimal(18, 3),null) as 累计领料,convert(decimal(18, 3),(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE 0 END ELSE 0 END) * convert(decimal(38,8),i.iquantity) ) as 累计退库
,convert(decimal(18, 3),null) as 采购入库,convert(decimal(18, 3),null) as 退货数量
,convert(decimal(18, 3),null) as 累计销售,convert(decimal(18, 3),null) as 累计退货
,convert(decimal(18, 3),null) as 累计其他入库,convert(decimal(18, 3),null) as 累计其他出库,cVouchType
,convert(decimal(18, 3),null) as iQty01,convert(decimal(18, 3),null) as iQty08,convert(decimal(18, 3),null) as iQty09
,convert(decimal(18, 3),i.iquantity) as iQty10,convert(decimal(18, 3),null) as iQty11,convert(decimal(18, 3),null) as iQty32,dDate,'10' as Flag,cCode
,case when ISNULL(cHandler ,'')<>'' then '审核' when isnull(iswfcontrolled,0)=1 and isnull(iverifystate ,0)=1 then '审核中' when ISNULL(cMaker,'')<>'' then '开立' end as 审批状态,cCurrentAuditor as 当前审批人,convert(decimal(18, 3),null) as 采购订单在途
,null as cCusName,null as cVenName,rdrecord.cdepcode,department.cdepname
from 
rdrecord10 rdrecord left join rdrecords10 rdrecords on rdrecord.id=rdrecords.id 
left join inventory on rdrecords.cinvcode=inventory.cinvcode 
left join warehouse on RdRecord.cWhCode = Warehouse.cWhCode
left JOIN InventoryClass On Inventory.cInvCCode = InventoryClass.cInvCCode
left join department on rdrecord.cdepcode =department.cdepcode 
left join ComputationUnit CU_F on Inventory.cSTComUnitCode = CU_F.cComUnitCode
left join (select rdsid,iquantity,inum,cposname from InvPositionD) i on rdrecords.AutoID=i.rdsid
where 2=2 and 
rdrecord.id in (select id from  #rdrecord10 )


--AND (Inventory.cInvCode >= N'BJ0024') and (Inventory.cInvCode <= N'BJ0024')

--6
insert into #temp1  Select autoid,rdrecord.cwhcode,cWhName,inventory.cInvCCode ,cInvCName ,rdrecords.cinvcode,inventory.cInvStd,inventory.cInvName,IsNull(cItem_class,N'') AS cItem_class ,
IsNull(cItemCName,N'') AS cItemCName  ,IsNull(cItemCode,N'') AS cItemCode ,IsNull(cName,N'')  As cName,RdRecord.bRdFlag,
isnull(RdRecord.cDefine3,N'') as cDefine3,isnull(RdRecord.cDefine9,N'') as cDefine9,isnull(RdRecord.cDefine1,N'') as cDefine1,isnull(RdRecord.cDefine2,N'') as cDefine2,isnull(RdRecord.cDefine10,N'') as cDefine10,isnull(RdRecords.cDefine22,N'') as cDefine22,isnull(RdRecords.cDefine25,N'') as cDefine25,isnull(RdRecords.cDefine28,N'') as cDefine28,isnull(RdRecords.cDefine31,N'') as cDefine31,isnull(RdRecords.cDefine23,N'') as cDefine23,isnull(RdRecords.cDefine24,N'') as cDefine24,isnull(RdRecords.cDefine26,Null) as cDefine26,isnull(cFree1,N'') as cFree1,isnull(cFree2,N'') as cFree2,isnull(cFree3,N'') as cFree3,isnull(cFree4,N'') as cFree4,
Left(RdRecord.cRdCode,5) As cRdCode, rdrecords.cBatch,cBatchProperty6,cBatchProperty7,cBatchProperty8,cposname,rdrecords.cPosition,
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ELSE 0 END) * convert(decimal(38,8),i.iquantity)  as iquantity, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then i.iquantity/Cu_f.iChangRate else i.iNum end  )  as iNum, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 0 else CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END  END) * convert(decimal(38,8),i.iquantity)  as iQCJCSL, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 0 else CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END  END ) * (case  Inventory.iGroupType when  0 then Null when 1 then i.iquantity/Cu_f.iChangRate else i.iNum end  )  as iQCJCJS, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE 0 END ELSE 0 END) * convert(decimal(38,8),i.iquantity)  as iInQuantity, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE 0 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then i.iquantity/Cu_f.iChangRate else i.iNum end  )  as iinNum, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then CASE WHEN RdRecord.bRdFlag <>0 THEN 0 ELSE 1 END ELSE 0 END) * convert(decimal(38,8),i.iquantity)  as ioutQuantity, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then CASE WHEN RdRecord.bRdFlag <>0 THEN 0 ELSE 1 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then i.iquantity/Cu_f.iChangRate else i.iNum end  )  as ioutNum, 
( CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ) * convert(decimal(38,8),i.iquantity)  as iQMJCSL, 
( CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ) *  (case  Inventory.iGroupType when  0 then Null when 1 then i.iquantity/Cu_f.iChangRate else i.iNum end  )  as iQMJCJS,
iUnitCost,  CU_F.cComUnitName as cInvA_Unit 
,convert(decimal(18, 3),null) as 累计入库,convert(decimal(18, 3),(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then CASE WHEN RdRecord.bRdFlag <>0 THEN 0 ELSE 1 END ELSE 0 END) * convert(decimal(38,8),i.iquantity) ) as 累计领料,convert(decimal(18, 3),null) as 累计退库
,convert(decimal(18, 3),null) as 采购入库,convert(decimal(18, 3),null) as 退货数量
,convert(decimal(18, 3),null) as 累计销售,convert(decimal(18, 3),null) as 累计退货
,convert(decimal(18, 3),null) as 累计其他入库,convert(decimal(18, 3),null) as 累计其他出库,cVouchType
,convert(decimal(18, 3),null) as iQty01,convert(decimal(18, 3),null) as iQty08,convert(decimal(18, 3),null) as iQty09
,convert(decimal(18, 3),null) as iQty10,convert(decimal(18, 3),i.iquantity) as iQty11,convert(decimal(18, 3),null) as iQty32,dDate,'11' as Flag,cCode
,case when ISNULL(cHandler ,'')<>'' then '审核' when isnull(iswfcontrolled,0)=1 and isnull(iverifystate ,0)=1 then '审核中' when ISNULL(cMaker,'')<>'' then '开立' end as 审批状态,cCurrentAuditor as 当前审批人,convert(decimal(18, 3),null) as 采购订单在途
,null as cCusName,null as cVenName,rdrecord.cdepcode,department.cdepname
from 
rdrecord11 rdrecord left join rdrecords11 rdrecords on rdrecord.id=rdrecords.id 
left join inventory on rdrecords.cinvcode=inventory.cinvcode 
left join warehouse on RdRecord.cWhCode = Warehouse.cWhCode
left JOIN InventoryClass On Inventory.cInvCCode = InventoryClass.cInvCCode
left join department on rdrecord.cdepcode =department.cdepcode 
left join ComputationUnit CU_F on Inventory.cSTComUnitCode = CU_F.cComUnitCode
left join (select rdsid,iquantity,inum,cposname from InvPositionD) i on rdrecords.AutoID=i.rdsid
where 2=2 and 
rdrecord.id in (select id from  #rdrecord11 )


--AND (Inventory.cInvCode >= N'BJ0024') and (Inventory.cInvCode <= N'BJ0024')

--7
insert into #temp1  Select autoid,rdrecord.cwhcode,cWhName,inventory.cInvCCode ,cInvCName ,rdrecords.cinvcode,inventory.cInvStd,inventory.cInvName,IsNull(cItem_class,N'') AS cItem_class ,
IsNull(cItemCName,N'') AS cItemCName  ,IsNull(cItemCode,N'') AS cItemCode ,IsNull(cName,N'')  As cName,RdRecord.bRdFlag,
isnull(RdRecord.cDefine3,N'') as cDefine3,isnull(RdRecord.cDefine9,N'') as cDefine9,isnull(RdRecord.cDefine1,N'') as cDefine1,isnull(RdRecord.cDefine2,N'') as cDefine2,isnull(RdRecord.cDefine10,N'') as cDefine10,isnull(RdRecords.cDefine22,N'') as cDefine22,isnull(RdRecords.cDefine25,N'') as cDefine25,isnull(RdRecords.cDefine28,N'') as cDefine28,isnull(RdRecords.cDefine31,N'') as cDefine31,isnull(RdRecords.cDefine23,N'') as cDefine23,isnull(RdRecords.cDefine24,N'') as cDefine24,isnull(RdRecords.cDefine26,Null) as cDefine26,isnull(cFree1,N'') as cFree1,isnull(cFree2,N'') as cFree2,isnull(cFree3,N'') as cFree3,isnull(cFree4,N'') as cFree4,
Left(RdRecord.cRdCode,5) As cRdCode, rdrecords.cBatch,cBatchProperty6,cBatchProperty7,cBatchProperty8,cposname,rdrecords.cPosition,
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ELSE 0 END) * convert(decimal(38,8),i.iquantity)  as iquantity, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then i.iquantity/Cu_f.iChangRate else i.iNum end  )  as iNum, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 0 else 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END  END) * convert(decimal(38,8),i.iquantity)  as iQCJCSL, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 0 else 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END  END ) * (case  Inventory.iGroupType when  0 then Null when 1 then i.iquantity/Cu_f.iChangRate else i.iNum end  )  as iQCJCJS, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE 0 END ELSE 0 END) * convert(decimal(38,8),i.iquantity)  as iInQuantity, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE 0 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then i.iquantity/Cu_f.iChangRate else i.iNum end  )  as iinNum, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then  CASE WHEN RdRecord.bRdFlag <>0 THEN 0 ELSE 1 END ELSE 0 END) * convert(decimal(38,8),i.iquantity)  as ioutQuantity, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 0 ELSE 1 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then i.iquantity/Cu_f.iChangRate else i.iNum end  )  as ioutNum, 
( CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ) * convert(decimal(38,8),i.iquantity)  as iQMJCSL, 
( CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ) *  (case  Inventory.iGroupType when  0 then Null when 1 then i.iquantity/Cu_f.iChangRate else i.iNum end  )  as iQMJCJS, 
iUnitCost,  CU_F.cComUnitName as cInvA_Unit 
,convert(decimal(18, 3),null) as 累计入库,convert(decimal(18, 3),null) as 累计领料,convert(decimal(18, 3),null) as 累计退库
,convert(decimal(18, 3),null) as 采购入库,convert(decimal(18, 3),null) as 退货数量
,convert(decimal(18, 3),(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then  CASE WHEN RdRecord.bRdFlag <>0 THEN 0 ELSE 1 END ELSE 0 END) * convert(decimal(38,8),i.iquantity) ) as 累计销售
,convert(decimal(18, 3),(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE 0 END ELSE 0 END) * convert(decimal(38,8),i.iquantity) ) as 累计退货
,convert(decimal(18, 3),null) as 累计其他入库,convert(decimal(18, 3),null) as 累计其他出库,cVouchType
,convert(decimal(18, 3),null) as iQty01,convert(decimal(18, 3),null) as iQty08,convert(decimal(18, 3),null) as iQty09
,convert(decimal(18, 3),null) as iQty10,convert(decimal(18, 3),null) as iQty11,convert(decimal(18, 3),i.iquantity) as iQty32,dDate,'32' as Flag,cCode
,case when ISNULL(cHandler ,'')<>'' then '审核' when isnull(iswfcontrolled,0)=1 and isnull(iverifystate ,0)=1 then '审核中' when ISNULL(cMaker,'')<>'' then '开立' end as 审批状态,cCurrentAuditor as 当前审批人,convert(decimal(18, 3),null) as 采购订单在途
,cCusName,null as cVenName,rdrecord.cdepcode,department.cdepname
from 
rdrecord32 rdrecord left join rdrecords32 rdrecords on rdrecord.id=rdrecords.id 
left join inventory on rdrecords.cinvcode=inventory.cinvcode 
left join warehouse on RdRecord.cWhCode = Warehouse.cWhCode
left JOIN InventoryClass On Inventory.cInvCCode = InventoryClass.cInvCCode
left join department on rdrecord.cdepcode =department.cdepcode 
left join ComputationUnit CU_F on Inventory.cSTComUnitCode = CU_F.cComUnitCode
left join (select rdsid,iquantity,inum,cposname from InvPositionD) i on rdrecords.AutoID=i.rdsid
left join Customer cus on rdrecord.cCusCode =cus.cCusCode 
where 2=2 and 
rdrecord.id in (select id from  #rdrecord32 )


--AND (Inventory.cInvCode >= N'BJ0024') and (Inventory.cInvCode <= N'BJ0024')

--8
insert into #temp1  Select autoid,rdrecord.cwhcode,cWhName,inventory.cInvCCode ,cInvCName ,rdrecords.cinvcode,inventory.cInvStd,inventory.cInvName,IsNull(cItem_class,N'') AS cItem_class ,
IsNull(cItemCName,N'') AS cItemCName  ,IsNull(cItemCode,N'') AS cItemCode ,IsNull(cName,N'')  As cName,RdRecord.bRdFlag,
isnull(RdRecord.cDefine3,N'') as cDefine3,isnull(RdRecord.cDefine9,N'') as cDefine9,isnull(RdRecord.cDefine1,N'') as cDefine1,isnull(RdRecord.cDefine2,N'') as cDefine2,isnull(RdRecord.cDefine10,N'') as cDefine10,isnull(RdRecords.cDefine22,N'') as cDefine22,isnull(RdRecords.cDefine25,N'') as cDefine25,isnull(RdRecords.cDefine28,N'') as cDefine28,isnull(RdRecords.cDefine31,N'') as cDefine31,isnull(RdRecords.cDefine23,N'') as cDefine23,isnull(RdRecords.cDefine24,N'') as cDefine24,isnull(RdRecords.cDefine26,Null) as cDefine26,isnull(cFree1,N'') as cFree1,isnull(cFree2,N'') as cFree2,isnull(cFree3,N'') as cFree3,isnull(cFree4,N'') as cFree4,
Left(RdRecord.cRdCode,5) As cRdCode, rdrecords.cBatch,cBatchProperty6,cBatchProperty7,cBatchProperty8,cposname,rdrecords.cPosition,
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ELSE 0 END) * convert(decimal(38,8),i.iquantity)  as iquantity, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then i.iquantity/Cu_f.iChangRate else i.iNum end  )  as iNum, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 0 else 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END  END) * convert(decimal(38,8),i.iquantity)  as iQCJCSL, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 0 else 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END  END ) * (case  Inventory.iGroupType when  0 then Null when 1 then i.iquantity/Cu_f.iChangRate else i.iNum end  )  as iQCJCJS, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE 0 END ELSE 0 END) * convert(decimal(38,8),i.iquantity)  as iInQuantity, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE 0 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then i.iquantity/Cu_f.iChangRate else i.iNum end  )  as iinNum, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 0 ELSE 1 END ELSE 0 END) * convert(decimal(38,8),i.iquantity)  as ioutQuantity, 
(case when  ( dDate>=N444444 and isnull(bisstqc,0)=0) then 
  CASE WHEN RdRecord.bRdFlag <>0 THEN 0 ELSE 1 END ELSE 0 END ) * (case  Inventory.iGroupType when  0 then Null when 1 then i.iquantity/Cu_f.iChangRate else i.iNum end  )  as ioutNum, 
( CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ) * convert(decimal(38,8),i.iquantity)  as iQMJCSL, 
( CASE WHEN RdRecord.bRdFlag <>0 THEN 1 ELSE -1 END ) *  (case  Inventory.iGroupType when  0 then Null when 1 then i.iquantity/Cu_f.iChangRate else i.iNum end  )  as iQMJCJS, 
iUnitCost,  CU_F.cComUnitName as cInvA_Unit 
,convert(decimal(18, 3),null) as 累计入库,convert(decimal(18, 3),null) as 累计领料,convert(decimal(18, 3),null) as 累计退库
,convert(decimal(18, 3),null) as 采购入库,convert(decimal(18, 3),null) as 退货数量
,convert(decimal(18, 3),null) as 累计销售,convert(decimal(18, 3),null) as 累计退货
,convert(decimal(18, 3),null) as 累计其他入库,convert(decimal(18, 3),null) as 累计其他出库,cVouchType
,convert(decimal(18, 3),null) as iQty01,convert(decimal(18, 3),null) as iQty08,convert(decimal(18, 3),null) as iQty09
,convert(decimal(18, 3),null) as iQty10,convert(decimal(18, 3),null) as iQty11,convert(decimal(18, 3),null) as iQty32,dDate,'34' as Flag,cCode
,case when ISNULL(cHandler ,'')<>'' then '审核' when isnull(iswfcontrolled,0)=1 and isnull(iverifystate ,0)=1 then '审核中' when ISNULL(cMaker,'')<>'' then '开立' end as 审批状态,null as 当前审批人,convert(decimal(18, 3),null) as 采购订单在途
,null as cCusName,null as cVenName,rdrecord.cdepcode,department.cdepname
from 
rdrecord34 rdrecord left join rdrecords34 rdrecords on rdrecord.id=rdrecords.id 
left join inventory on rdrecords.cinvcode=inventory.cinvcode 
left join warehouse on RdRecord.cWhCode = Warehouse.cWhCode
left JOIN InventoryClass On Inventory.cInvCCode = InventoryClass.cInvCCode
left join department on rdrecord.cdepcode =department.cdepcode 
left join ComputationUnit CU_F on Inventory.cSTComUnitCode = CU_F.cComUnitCode
left join (select rdsid,iquantity,inum,cposname from InvPositionD) i on rdrecords.AutoID=i.rdsid
where 2=2 and 
rdrecord.id in (select id from  #rdrecord34 )


--AND (Inventory.cInvCode >= N'BJ0024') and (Inventory.cInvCode <= N'BJ0024')

--9

insert into #temp1   Select a.autoid,warehouse.cwhcode,cWhName,inventory.cInvCCode ,cInvCName ,a.cinvcode,inventory.cInvStd,inventory.cInvName,IsNull(cItem_class,N'') AS cItem_class ,
IsNull(cItemCName,N'') AS cItemCName  ,IsNull(cItemCode,N'') AS cItemCode ,IsNull(cName,N'')  As cName,1 as bRdFlag,
isnull(a.cdefine3,N'') as cdefine3,isnull(a.cdefine9,N'') as cdefine9,isnull(a.cdefine1,N'') as cdefine1,isnull(a.cdefine2,N'') as cdefine2,isnull(a.cdefine10,N'') as cdefine10,isnull(a.cdefine22,N'') as cdefine22,isnull(a.cdefine25,N'') as cdefine25,isnull(a.cdefine28,N'') as cdefine28,isnull(a.cdefine31,N'') as cdefine31,isnull(a.cdefine23,N'') as cdefine23,isnull(a.cdefine24,N'') as cdefine24,isnull(a.cdefine26,null) as cdefine26,isnull(cFree1,N'') as cFree1,isnull(cFree2,N'') as cFree2,isnull(cFree3,N'') as cFree3,isnull(cFree4,N'') as cFree4,
Left(a.cRdCode,5) As cRdCode, a.cBatch,null,null,null,cPosName as cposname,cPosition,
0  as iquantity, 
0  as iNum, 
convert(decimal(38,8),iquantity)  as iQCJCSL, 
(case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else a.iNum end  )  as iQCJCJS, 
0  as iInQuantity, 
0  as iinNum, 
0  as ioutQuantity, 
0  as ioutNum, 
convert(decimal(38,8),iquantity)  as iQMJCSL, 
(case  Inventory.iGroupType when  0 then Null when 1 then iquantity/Cu_f.iChangRate else a.iNum end  )  as iQMJCJS, 
0 as iUnitCost,  CU_F.cComUnitName as cInvA_Unit 
,convert(decimal(18, 3),null) as 累计入库,convert(decimal(18, 3),null) as 累计领料,convert(decimal(18, 3),null) as 累计退库
,convert(decimal(18, 3),null) as 采购入库,convert(decimal(18, 3),null) as 退货数量
,convert(decimal(18, 3),null) as 累计销售,convert(decimal(18, 3),null) as 累计退货
,convert(decimal(18, 3),null) as 累计其他入库,convert(decimal(18, 3),null) as 累计其他出库,null
,convert(decimal(18, 3),null) as iQty01,convert(decimal(18, 3),null) as iQty08,convert(decimal(18, 3),null) as iQty09
,convert(decimal(18, 3),null) as iQty10,convert(decimal(18, 3),null) as iQty11,convert(decimal(18, 3),null) as iQty32,null as dDate,null as Flag,null as ccode,null as 审批状态,null as 当前审批人,convert(decimal(18, 3),null) as 采购订单在途
,null as cCusName,null as cVenName,a.cdepcode,department.cdepname
from 
ST_MonthAccounts a left join inventory on a.cinvcode=inventory.cinvcode 
left join warehouse on a.cWhCode = Warehouse.cWhCode  left join Position p on cPosition=p.cPosCode
left JOIN InventoryClass On Inventory.cInvCCode = InventoryClass.cInvCCode
left join department on a.cdepcode =department.cdepcode left join ComputationUnit CU_F on Inventory.cSTComUnitCode = CU_F.cComUnitCode 
where 3=3 and  iYear = " + iyear + " and iMonth =   " + imonth;
            
                    sSQL = sSQL + @"
insert into #temp1   Select null,'',null,i.cInvCCode ,cInvCName ,a.cinvcode,i.cInvStd,i.cInvName,IsNull(cItem_class,N'') AS cItem_class ,
IsNull(null,N'') AS cItemCName  ,IsNull(null,N'') AS cItemCode ,IsNull(null,N'')  As cName,1 as bRdFlag,
isnull(null,N'') as cdefine3,isnull(null,N'') as cdefine9,isnull(null,N'') as cdefine1,isnull(null,N'') as cdefine2,isnull(null,N'') as cdefine10
,isnull(null,N'') as cdefine22,isnull(null,N'') as cdefine25,isnull(null,N'') as cdefine28,isnull(null,N'') as cdefine31,isnull(null,N'') as cdefine23
,isnull(null,N'') as cdefine24,isnull(null,null) as cdefine26,isnull(cFree1,N'') as cFree1,isnull(cFree2,N'') as cFree2,isnull(cFree3,N'') as cFree3,isnull(cFree4,N'') as cFree4,
null As cRdCode,null,null,null,null,null as cposname,cPosition,
0  as iquantity, 
0  as iNum, 
0 as iQCJCSL, 
0 as iQCJCJS, 
0  as iInQuantity, 
0  as iinNum, 
0  as ioutQuantity, 
0  as ioutNum, 
0 as iQMJCSL, 
0  as iQMJCJS, 
0 as iUnitCost,  cComUnitName as cInvA_Unit 
,convert(decimal(18, 3),null) as 累计入库,convert(decimal(18, 3),null) as 累计领料,convert(decimal(18, 3),null) as 累计退库
,convert(decimal(18, 3),null) as 采购入库,convert(decimal(18, 3),null) as 退货数量
,convert(decimal(18, 3),null) as 累计销售,convert(decimal(18, 3),null) as 累计退货
,convert(decimal(18, 3),null) as 累计其他入库,convert(decimal(18, 3),null) as 累计其他出库,null
,convert(decimal(18, 3),null) as iQty01,convert(decimal(18, 3),null) as iQty08,convert(decimal(18, 3),null) as iQty09
,convert(decimal(18, 3),null) as iQty10,convert(decimal(18, 3),null) as iQty11,convert(decimal(18, 3),null) as iQty32,null as dDate,null as Flag,null as ccode,null as 审批状态,null as 当前审批人
,isnull(iQuantity ,0)-isnull(iReceivedQTY ,0) as 采购订单在途
,null as cCusName,null as cVenName,c.cdepcode,department.cdepname
from PO_Podetails a left join inventory i on a.cinvcode=i.cinvcode 
left JOIN InventoryClass On i.cInvCCode = InventoryClass.cInvCCode 
left join po_pomain c on a.POID=c.POID 
left join department on c.cdepcode =department.cdepcode 
left join ComputationUnit CU_F on i.cSTComUnitCode = CU_F.cComUnitCode
where isnull(cVerifier ,'')<>'' And (cPTCode <> N'05') and (left(i.cInvCCode,2)<>'09' and left(i.cInvCCode,2)<>'10') and isnull(a.cbcloser,'')=''

Select a.cInvCCode ,ic1.cInvCCode as cInvCCode1,ic1.cInvCName as cInvCName1,ic2.cInvCCode as cInvCCode2,ic2.cInvCName as cInvCName2,ic3.cInvCCode as cInvCCode3,ic3.cInvCName as cInvCName3
, a.cInvCode, a.cInvName,cInvAddCode,  a.cInvStd, ComputationUnit.CComUnitName  AS 计量单位
,sum(iQCJCSL) AS  期初结存数量  ,sum(iQCJCJS) AS 期初结存件数, convert(decimal(36,2), sum(iQCJCSL * iUnitCost)) AS 期初结存金额, 
sum(iInQuantity) as 总计入库数量,sum(iInNum) as  总计入库件数 ,  convert(decimal(36,2),sum(iInQuantity*iUnitCost))  As 总计入库金额 ,
sum(iOutQuantity) as 总计出库数量,sum(iOutNum) as  总计出库件数 ,  convert(decimal(36,2),sum(iOutQuantity*iUnitCost))  As 总计出库金额 ,
sum(iQMJCSL) AS 期末结存数量,sum(iQMJCJS) AS 期末结存件数,  convert(decimal(36,2),sum(iQMJCSL*iUnitCost))  AS 期末结存金额
,sum(ISNULL(iInQuantity,0)-ISNULL(iOutQuantity,0)) as 本期变动,sum(采购订单在途) as 采购订单在途
,sum(iQty01) as iQty01,sum(iQty08) as iQty08,sum(iQty09) as iQty09
,sum(iQty10) as iQty10,sum(iQty11) as iQty11,sum(iQty32) as iQty32
,sum(isnull(iQty01,0)+isnull(iQty08,0)+isnull(iQty10,0)) as 本期入库
,sum(isnull(iQty09,0)+isnull(iQty11,0)+isnull(iQty32,0)) as 本期出库
from #temp1 A  left join inventory inv on a.cinvcode=inv.cinvcode left join ComputationUnit ON inv.cComUnitCode = ComputationUnit.cComUnitCode 
left join InventoryClass ic1 on ic1.cInvCCode = left(inv.cInvCCode,2)
left join InventoryClass ic2 on ic2.cInvCCode = left(inv.cInvCCode,4)
left join InventoryClass ic3 on ic3.cInvCCode = left(inv.cInvCCode,6) 
--left join (select a.cInvCode,cInvStd,sum(isnull(iQuantity ,0)-isnull(iReceivedQTY ,0))  as 采购订单在途 from PO_Podetails a left join inventory i on a.cinvcode=i.cinvcode left join po_pomain c on a.POID=c.POID 
--where isnull(cVerifier ,'')<>'' And (cPTCode <> N'05') and (left(i.cInvCCode,2)<>'09' and left(i.cInvCCode,2)<>'10') and isnull(a.cbcloser,'')=''
--group by a.cInvCode,cInvStd having sum(isnull(iQuantity,0)-isnull(iReceivedQTY,0))>0) dd on a.cinvcode=dd.cinvcode 
where 4=4 group by a.cInvCCode ,ic1.cInvCCode,ic1.cInvCName,ic2.cInvCCode,ic2.cInvCName,ic3.cInvCCode,ic3.cInvCName
, a.cInvCode, a.cInvName,cInvAddCode,  a.cInvStd, ComputationUnit.CComUnitName order by  a.cInvCode";
            
            sSQL = sSQL.Replace("111111", "'2017-04-01'");
            sSQL = sSQL.Replace("222222", "'" + sdate + "'");
            sSQL = sSQL.Replace("333333", "'" + edate + "'");
            sSQL = sSQL.Replace("444444", "'" + sdate + "'");
            sSQL = sSQL.Replace("666666", "'" + sdate2 + "'");
            
            sSQL = sSQL.Replace("2=2", "2=2 and case when ISNULL(cHandler ,'')<>'' then '审核' when isnull(iswfcontrolled,0)=1 and isnull(iverifystate ,0)=1 then '审核中' when ISNULL(cMaker,'')<>'' then '开立' end='审核'");
                
            DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            return dt;

        }

    }
}
