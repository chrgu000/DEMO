using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public class 数据源
    {
        public DataTable 收发存汇总(string Conn, string cInvCode1, string cInvCode2, string sdate, string edate, int flag, bool bcHandler, bool bcHas, bool bisAll, string cFree3, string cFree4
            , string cWhCode, string cPosCode,string cRdCode,string RdFlag,string cCode,decimal qc)
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
            if (flag == 1)
            {
                if (bisAll == true)
                {
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
                }
                else
                {
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
,sum(case when dDate>=222222 and dDate<=333333 then iQty01 end) as iQty01,sum(case when dDate>=222222 and dDate<=333333 then iQty08 end) as iQty08,sum(case when dDate>=222222 and dDate<=333333 then iQty09 end) as iQty09
,sum(case when dDate>=222222 and dDate<=333333 then iQty10 end) as iQty10,sum(case when dDate>=222222 and dDate<=333333 then iQty11 end) as iQty11,sum(case when dDate>=222222 and dDate<=333333 then iQty32 end) as iQty32
,sum(case when dDate>=222222 and dDate<=333333 then isnull(iQty01,0)+isnull(iQty08,0)+isnull(iQty10,0) end) as 本期入库
,sum(case when dDate>=222222 and dDate<=333333 then isnull(iQty09,0)+isnull(iQty11,0)+isnull(iQty32,0) end) as 本期出库
from #temp1 A  left join inventory inv on a.cinvcode=inv.cinvcode left join ComputationUnit ON inv.cComUnitCode = ComputationUnit.cComUnitCode 
left join InventoryClass ic1 on ic1.cInvCCode = left(inv.cInvCCode,2)
left join InventoryClass ic2 on ic2.cInvCCode = left(inv.cInvCCode,4)
left join InventoryClass ic3 on ic3.cInvCCode = left(inv.cInvCCode,6) 
--left join (select a.cInvCode,cInvStd,sum(isnull(iQuantity ,0)-isnull(iReceivedQTY ,0))  as 采购订单在途 from PO_Podetails a left join inventory i on a.cinvcode=i.cinvcode left join po_pomain c on a.POID=c.POID 
--where isnull(cVerifier ,'')<>'' And (cPTCode <> N'05') and (left(i.cInvCCode,2)<>'09' and left(i.cInvCCode,2)<>'10') and isnull(a.cbcloser,'')=''
--group by a.cInvCode,cInvStd having sum(isnull(iQuantity,0)-isnull(iReceivedQTY,0))>0) dd on a.cinvcode=dd.cinvcode 
where 4=4 And (left(inv.cInvCCode,2)<>'09' and left(inv.cInvCCode,2)<>'10') group by a.cInvCCode ,ic1.cInvCCode,ic1.cInvCName,ic2.cInvCCode,ic2.cInvCName,ic3.cInvCCode,ic3.cInvCName
, a.cInvCode, a.cInvName,cInvAddCode,  a.cInvStd, ComputationUnit.CComUnitName  order by  a.cInvCode";
                }
            }
            else if (flag == 2)
            {
                sSQL = sSQL + @"
Select 
*
from #temp1 A  left join inventory inv on a.cinvcode=inv.cinvcode left join ComputationUnit ON inv.cComUnitCode = ComputationUnit.cComUnitCode 
left join Rd_Style rs on rs.cRdCode=a.cRdCode 
left join VouchType v on a.cVouchType =v.cVouchType 
where 4=4 and iInQuantity>0 or iOutQuantity>0
";
                if (cRdCode != "")
                {
                    sSQL = sSQL.Replace("4=4", "4=4 and a.cRdCode='" + cRdCode + "'");
                }
                if (RdFlag != "")
                {
                    sSQL = sSQL.Replace("4=4", "4=4 and a.Flag='" + RdFlag + "'");
                }
            }
            else if (flag == 3)
            {
                sSQL = sSQL + @"
Select a.ddate,a.cCode,a.cInvCCode ,ic1.cInvCCode as cInvCCode1,ic1.cInvCName as cInvCName1,ic2.cInvCCode as cInvCCode2,ic2.cInvCName as cInvCName2,ic3.cInvCCode as cInvCCode3,ic3.cInvCName as cInvCName3
,cWhCode as 仓库编码, cWhName as 仓库名称, a.cInvCode, a.cInvName,cInvAddCode,  a.cInvStd, ComputationUnit.CComUnitName  AS 计量单位,cInvA_Unit AS 库存单位
,cFree1,cFree2,cFree3,cFree4,cInvDefine1,cInvDefine2,cInvDefine3,cInvDefine4,cInvDefine5,cInvDefine6,cInvDefine7
,cDefine3,cDefine9,cDefine22,cDefine25,cDefine28,cDefine31,cDefine1,cDefine2,cDefine10,cDefine23,cDefine24,cDefine26,a.cRdCode,cRdName,a.cVouchType,v.cVouchName 
,sum(iQCJCSL) AS  期初结存数量  ,sum(iQCJCJS) AS 期初结存件数, convert(decimal(36,2), sum(iQCJCSL * iUnitCost)) AS 期初结存金额, 
sum(iInQuantity) as 总计入库数量,sum(iInNum) as  总计入库件数 ,  convert(decimal(36,2),sum(iInQuantity*iUnitCost))  As 总计入库金额 ,
sum(iOutQuantity) as 总计出库数量,sum(iOutNum) as  总计出库件数 ,  convert(decimal(36,2),sum(iOutQuantity*iUnitCost))  As 总计出库金额 ,
sum(iQMJCSL) AS 期末结存数量,sum(iQMJCJS) AS 期末结存件数,  convert(decimal(36,2),sum(iQMJCSL*iUnitCost))  AS 期末结存金额
,sum(ISNULL(iInQuantity,0)-ISNULL(iOutQuantity,0)) as 本期变动,max(dd.采购订单在途) as 采购订单在途,convert(decimal(36,2),null) as 期初数量,convert(decimal(36,2),null) as 期末数量
from #temp1 A  left join inventory inv on a.cinvcode=inv.cinvcode left join ComputationUnit ON inv.cComUnitCode = ComputationUnit.cComUnitCode 
left join InventoryClass ic1 on ic1.cInvCCode = left(inv.cInvCCode,2)
left join InventoryClass ic2 on ic2.cInvCCode = left(inv.cInvCCode,4)
left join InventoryClass ic3 on ic3.cInvCCode = left(inv.cInvCCode,6) 
left join Rd_Style r on a.cRdCode=r.cRdCode
left join VouchType v on a.cVouchType =v.cVouchType 
left join (select a.cInvCode,cInvStd,sum(isnull(iReceivedQTY ,0)-isnull(freceivedqty ,0))  as 采购订单在途 from PO_Podetails a left join inventory inv on a.cinvcode=inv.cinvcode 
group by a.cInvCode,cInvStd having sum(isnull(iQuantity,0)-isnull(iReceivedQTY  ,0))>0) dd on a.cinvcode=dd.cinvcode
where 4=4 And (left(inv.cInvCCode,2)<>'09' and left(inv.cInvCCode,2)<>'10') group by a.ddate,a.cCode,a.cInvCCode ,ic1.cInvCCode,ic1.cInvCName,ic2.cInvCCode,ic2.cInvCName,ic3.cInvCCode,ic3.cInvCName
,cWhCode , cWhName , a.cInvCode, a.cInvName,cInvAddCode,  a.cInvStd, ComputationUnit.CComUnitName ,cInvA_Unit 
,cFree1,cFree2,cFree3,cFree4,cInvDefine1,cInvDefine2,cInvDefine3,cInvDefine4,cInvDefine5,cInvDefine6,cInvDefine7
,cDefine3,cDefine9,cDefine22,cDefine25,cDefine28,cDefine31,cDefine1,cDefine2,cDefine10,cDefine23,cDefine24,cDefine26,a.cRdCode,cRdName,a.cVouchType,v.cVouchName 
having (sum(iInQuantity)>0 or sum(iOutQuantity)>0)
";
            }
            else if (flag == 4)
            {
                sSQL = sSQL + @"
Select inv.cInvName,inv.cInvStd,rs.cRdName,cVouchName,dDate,cCode,cComUnitName,审批状态,当前审批人,cDefine1,cDefine3,cDefine25,cDefine10,cCusName,cVenName,convert(decimal(18, 3),iUnitCost ) as iUnitCost
,sum(iQty01) as iQty01,sum(iQty08) as iQty08,sum(iQty09) as iQty09
,sum(iQty10) as iQty10,sum(iQty11) as iQty11,sum(iQty32) as iQty32
,cdepcode,cdepname
from #temp1 A  left join inventory inv on a.cinvcode=inv.cinvcode left join ComputationUnit ON inv.cComUnitCode = ComputationUnit.cComUnitCode 
left join Rd_Style rs on rs.cRdCode=a.cRdCode 
left join VouchType v on a.cVouchType =v.cVouchType 
where 4=4 group by inv.cInvName,inv.cInvStd,rs.cRdName,cVouchName,dDate,cCode,cComUnitName,审批状态,当前审批人,cDefine1,cDefine3,cDefine25,cDefine10,cCusName,cVenName,iUnitCost  ,cdepcode,cdepname
order by dDate,cCode
";
                if (cRdCode != "")
                {
                    sSQL = sSQL.Replace("4=4", "4=4 and a.cRdCode='" + cRdCode + "'");
                }
                if (RdFlag != "")
                {
                    sSQL = sSQL.Replace("4=4", "4=4 and a.Flag='" + RdFlag + "'");
                }
                if (sdate != "")
                {
                    sSQL = sSQL.Replace("4=4", "4=4 and convert(varchar(10),dDate,120)>='" + sdate + "'");
                }
                if (edate != "")
                {
                    sSQL = sSQL.Replace("4=4", "4=4 and convert(varchar(10),dDate,120)<='" + edate + "'");
                }
            }
            else if (flag == 5)
            {
                int iyear1 = DateTime.Parse(sdate).Year - 1;
                sSQL = sSQL + @"
select cidefine5,cidefine6,计量单位
,sum(期初库存数量) as 期初库存数量,sum(期初库存金额) as 期初库存金额
,sum(本月增加数量) as 本月增加数量,sum(本月增加金额) as 本月增加金额
,sum(本月减少数量) as 本月减少数量,sum(本月减少金额) as 本月减少金额
,sum(期末库存数量) as 期末库存数量,sum(期末库存金额) as 期末库存金额
,sum(年初库存数量) as 年初库存数量 
from (
            Select case when cidefine5='产成品' then '一、产成品' when cidefine5='半成品' then '二、半成品' when cidefine5='副产品' then '三、副产品' 
when cidefine5='原材料' then '四、原材料' end cidefine5
,case when cidefine5='产成品' then '1' when cidefine5='半成品' then '2' when cidefine5='副产品' then '3' 
when cidefine5='原材料' then '4' end cidefine5_1
, cidefine6,cidefine10, ComputationUnit.CComUnitName  AS 计量单位
            ,convert(decimal(36,2),sum(iQCJCSL)) AS  期初库存数量, convert(decimal(36,2), sum(iQCJCSL * iUnitCost)) AS 期初库存金额, 
            convert(decimal(36,2),sum(iInQuantity)) as 本月增加数量, convert(decimal(36,2),sum(iInQuantity*iUnitCost))  As 本月增加金额 ,
            convert(decimal(36,2),sum(iOutQuantity)) as 本月减少数量, convert(decimal(36,2),sum(iOutQuantity*iUnitCost))  As 本月减少金额 ,
            convert(decimal(36,2),sum(iQMJCSL)) AS 期末库存数量,convert(decimal(36,2),sum(iQMJCSL*iUnitCost))  AS 期末库存金额 ,convert(decimal(36,2),null) as 年初库存数量
            from #temp1 A left join inventory inv on a.cinvcode=inv.cinvcode left join Inventory_extradefine i on a.cinvcode=i.cinvcode 
            left join ComputationUnit ON inv.cComUnitCode = ComputationUnit.cComUnitCode 
            where 4=4 and isnull(cidefine5,'')<>'' and isnull(cidefine6,'')<>'' group by cidefine5, cidefine6,cidefine10, ComputationUnit.CComUnitName 
            union all 
            Select  case when cidefine5='产成品' then '一、产成品' when cidefine5='半成品' then '二、半成品' when cidefine5='副产品' then '三、副产品' 
when cidefine5='原材料' then '四、原材料' end cidefine5
,case when cidefine5='产成品' then '1' when cidefine5='半成品' then '2' when cidefine5='副产品' then '3' 
when cidefine5='原材料' then '4' end cidefine5_1, i.cidefine6,i.cidefine10,ComputationUnit.CComUnitName as 单位,null,null,null,null,null,null,null,null
            ,convert(decimal(36,2),sum(iquantity))  as 年初库存数量
            from 
            ST_MonthAccounts a left join Inventory inv on a.cinvcode=inv.cinvcode   
            left join Inventory_extradefine i on a.cinvcode=i.cinvcode  
            left join ComputationUnit ON inv.cComUnitCode = ComputationUnit.cComUnitCode 
            where 8=8 and isnull(cidefine5,'')<>'' and isnull(cidefine6,'')<>'' and  iYear = " + iyear1 + " and iMonth=12 group by  i.cidefine5, i.cidefine6,cidefine10,ComputationUnit.CComUnitName) a group by cidefine5,cidefine5_1,cidefine6,cidefine10,计量单位 order by cidefine5_1,cidefine10";
                sSQL = sSQL.Replace("2=2", "2=2 and case when ISNULL(cHandler ,'')<>'' then '审核' when isnull(iswfcontrolled,0)=1 and isnull(iverifystate ,0)=1 then '审核中' when ISNULL(cMaker,'')<>'' then '开立' end='审核'");
                if (cInvCode1 != "")
                {
                    sSQL = sSQL.Replace("8=8", "8=8 and a.cinvcode>='" + cInvCode1 + "'");
                }
                if (cInvCode2 != "")
                {
                    sSQL = sSQL.Replace("8=8", "8=8 and a.cinvcode<='" + cInvCode2 + "'");
                }
            }
            sSQL = sSQL.Replace("111111", "'2015-09-01'");
            sSQL = sSQL.Replace("222222", "'" + sdate + "'");
            sSQL = sSQL.Replace("333333", "'" + edate + "'");
            sSQL = sSQL.Replace("444444", "'" + sdate + "'");
            sSQL = sSQL.Replace("666666", "'" + sdate2 + "'");
            
            if (bcHandler == true)
            {
                //sSQL = sSQL.Replace("2=2", "2=2 and case when ISNULL(cHandler ,'')<>'' then '审核' when isnull(iswfcontrolled,0)=1 and isnull(iverifystate ,0)=1 then '审核中' when ISNULL(cMaker,'')<>'' then '开立' end='审核'");
                
            }
            else
            {
                sSQL = sSQL.Replace("2=2", "2=2 and case when ISNULL(cHandler ,'')<>'' then '审核' when isnull(iswfcontrolled,0)=1 and isnull(iverifystate ,0)=1 then '审核中' when ISNULL(cMaker,'')<>'' then '开立' end='审核中'");
                sSQL = sSQL.Replace("3=3", "3=3 and 1=-1");
            }
            if (cInvCode1 != "")
            {
                sSQL = sSQL.Replace("2=2", "2=2 and rdrecords.cinvcode>='" + cInvCode1 + "'");
                sSQL = sSQL.Replace("3=3", "3=3 and a.cinvcode>='" + cInvCode1 + "'");
            }
            if (cInvCode2 != "")
            {
                sSQL = sSQL.Replace("2=2", "2=2 and rdrecords.cinvcode<='" + cInvCode2 + "'");
                sSQL = sSQL.Replace("3=3", "3=3 and a.cinvcode<='" + cInvCode2 + "'");
            }
            if (cFree3 != "")
            {
                sSQL = sSQL.Replace("2=2", "2=2 and rdrecords.cFree3='" + cFree3 + "'");
                sSQL = sSQL.Replace("3=3", "3=3 and a.cFree3='" + cFree3 + "'");
            }
            if (cWhCode != "")
            {
                sSQL = sSQL.Replace("2=2", "2=2 and rdrecord.cWhCode='" + cWhCode + "'");
                sSQL = sSQL.Replace("3=3", "3=3 and a.cWhCode>='" + cWhCode + "'");
            }
            if (bcHas == false)
            {
                sSQL = sSQL + " having sum(ISNULL(iInQuantity,0)-ISNULL(sSQL,0))<>0";
            }
            DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            if (flag == 3)
            {
                decimal iQuantity = 系统服务.规格化.ReturnDecimal(qc, 3);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    decimal iIn = 系统服务.规格化.ReturnDecimal(dt.Rows[i]["总计入库数量"], 3);
                    decimal iOut = 系统服务.规格化.ReturnDecimal(dt.Rows[i]["总计出库数量"], 3);
                    dt.Rows[i]["期初数量"] = iQuantity;
                    iQuantity = iQuantity + iIn - iOut;
                    dt.Rows[i]["期末数量"] = iQuantity;
                }
            }
            return dt;

        }

        public string 检验()
        {
            string sSQL = @"select RdID,RdsID,cWhCode,cPosCode,cInvCode,cBatch,cFree1,cFree2,cFree3,cvouchtype,case when bRdFlag=0 then -iQuantity else iQuantity end iQuantity
,case when o.Conclusion is not null then o.Conclusion when cvouchtype='01' and o.Conclusion is null then '3' else '1'  end Conclusion,o.Remark 
from InvPosition i left join _QCConclusion o on i.RdsID=o.AutoID 
where 1=1 and ((bRdFlag=0 and iquantity<0) or (bRdFlag=1 and iquantity>0))
";
            return sSQL;
        }

        public string 出库()
        {
            string sSQL = @"select RdID,RdsID,cWhCode,cPosCode,cInvCode,cBatch,cFree1,cFree2,cFree3,cvouchtype,case when bRdFlag=1 then -iQuantity else iQuantity end iQuantity
from InvPosition i left join _QCConclusion o on i.RdsID=o.AutoID 
where 1=1 and ((bRdFlag=0 and iquantity>0) or (bRdFlag=1 and iquantity<0))
";
            return sSQL;
        }

        public string 检验明细()
        {
            string sSQL = @"SELECT  AutoID, QCCode, Result FROM _QCResult where isnull(Result,'')!=''
";
            return sSQL;
        }
        public DataTable 库存汇总(string Conn, string cInvCode1, string cInvCode2, string edate, string cFree1, string cposname)
        {
            string sSQL = @"
select AutoID,cBatchProperty6,cBatchProperty7,cBatchProperty8,cbMemo into #b from rdrecords01
insert into #b select AutoID,cBatchProperty6,cBatchProperty7,cBatchProperty8,cbMemo from rdrecords08
insert into #b select AutoID,cBatchProperty6,cBatchProperty7,cBatchProperty8,cbMemo from rdrecords09
insert into #b select AutoID,cBatchProperty6,cBatchProperty7,cBatchProperty8,cbMemo from rdrecords10
insert into #b select AutoID,cBatchProperty6,cBatchProperty7,cBatchProperty8,cbMemo from rdrecords11
insert into #b select AutoID,cBatchProperty6,cBatchProperty7,cBatchProperty8,cbMemo from rdrecords32
insert into #b select AutoID,cBatchProperty6,cBatchProperty7,cBatchProperty8,cbMemo from rdrecords34

select cWhCode,cPosCode,cInvCode,cBatch,cFree1,cFree2,cFree3,cFree4,cFree5,cFree6,cFree7,cFree8,cFree9,cFree10,case when bRdFlag=0 then -iQuantity else iQuantity end iQuantity 
into #a from InvPosition i
where 1=1 and ((bRdFlag=0 and iquantity<0) or (bRdFlag=1 and iquantity>0)) 

insert  into #a select cWhCode,cPosCode,cInvCode,cBatch,cFree1,cFree2,cFree3,cFree4,cFree5,cFree6,cFree7,cFree8,cFree9,cFree10,case when bRdFlag=0 then -iQuantity else iQuantity end iQuantity 
from InvPosition i
where 1=1 and ((bRdFlag=0 and iquantity>0) or (bRdFlag=1 and iquantity<0)) 

select cWhCode,cPosCode,cInvCode,cBatch,cFree1,cFree2,cFree3,cFree4,cFree5,cFree6,cFree7,cFree8,cFree9,cFree10,sum(iQuantity) as iQuantity
into #c from #a group by cWhCode,cPosCode,cInvCode,cBatch,cFree1,cFree2,cFree3,cFree4,cFree5,cFree6,cFree7,cFree8,cFree9,cFree10 having sum(iQuantity)>0
 
select RdsID,o.Remark,convert(decimal(18, 3),case when bRdFlag=0 then -i.iQuantity else i.iQuantity end) as iQuantity,case when isnull(o.Conclusion,'')='' then 
case when (inv.cInvCCode like '0102%' or inv.cInvCCode like '0103%' or inv.cInvCCode like '0104%' or inv.cInvCCode like '03%' or inv.cInvCCode like '05%') then '1' else '2' end 
else o.Conclusion end 质检状态 into #d
from InvPosition i left join _QCConclusion o on i.RdsID=o.AutoID left join Inventory inv on inv.cInvCode = i.cInvCode
left join #c r on i.cPosCode=r.cPosCode and i.cInvCode=r.cInvCode and isnull(i.cBatch,'')=isnull(r.cBatch,'') and i.cWhCode=r.cWhCode
and isnull(i.cFree1,'')=isnull(r.cFree1,'') and isnull(i.cFree2,'')=isnull(r.cFree2,'') and isnull(i.cFree3,'')=isnull(r.cFree3,'') and isnull(i.cFree4,'')=isnull(r.cFree4,'') and isnull(i.cFree5,'')=isnull(r.cFree5,'')
and isnull(i.cFree6,'')=isnull(r.cFree6,'') and isnull(i.cFree7,'')=isnull(r.cFree7,'') and isnull(i.cFree8,'')=isnull(r.cFree8,'') and isnull(i.cFree9,'')=isnull(r.cFree9,'') and isnull(i.cFree10,'')=isnull(r.cFree10,'')

select cWhCode,cPosCode,cInvCode,cBatch,cFree1,cFree2,cFree3,cFree4,cFree5,cFree6,cFree7,cFree8,cFree9,cFree10,sum(case when bRdFlag=0 then iQuantity else -iQuantity end) iQuantity 
into #e from InvPosition i
where 1=1 and ((bRdFlag=0 and iquantity>0) or (bRdFlag=1 and iquantity<0)) group by cWhCode,cPosCode,cInvCode,cBatch,cFree1,cFree2,cFree3,cFree4,cFree5,cFree6,cFree7,cFree8,cFree9,cFree10
 
select ic1.cInvCCode as cInvCCode1,ic1.cInvCName as cInvCName1,ic2.cInvCCode as cInvCCode2,ic2.cInvCName as cInvCName2,ic3.cInvCCode as cInvCCode3,ic3.cInvCName as cInvCName3
,i.cInvCode,i.cFree1,i.cFree2,i.cFree3,i.cFree4,i.cFree5,i.cFree6,i.cFree7,i.cFree8,i.cFree9,i.cFree10,cvouchtype,sum(o.iQuantity) as iQuantity1,inv.cInvName,inv.cInvStd
,isnull(sum(case when isnull(o.质检状态,'')='1' then o.iQuantity end),0) i待检
,isnull(sum(case when isnull(o.质检状态,'')='2' then o.iQuantity end),0) i合格
,isnull(sum(case when isnull(o.质检状态,'')='3' then o.iQuantity end),0) i不合格
,isnull(sum(t.iQuantity),null) as iOutQuantity

,sum(case when cVouchType='10' and bRdFlag=1 then i.iQuantity end) as 累计入库,sum(case when cVouchType='11' and bRdFlag=1 then i.iQuantity end) as 累计领料,sum(case when cVouchType='10' and bRdFlag=0 then -i.iQuantity end) as 累计退库
,sum(case when cVouchType='01' and bRdFlag=1 then i.iQuantity end) as 采购入库,sum(case when cVouchType='01' and bRdFlag=0 then -i.iQuantity end) as 退货数量
,sum(case when cVouchType='32' and bRdFlag=1 then i.iQuantity end) as 累计销售,sum(case when cVouchType='32' and bRdFlag=0 then -i.iQuantity end) as 累计退货
,sum(case when cVouchType='08' and bRdFlag=1 then i.iQuantity end) as 累计其他入库,sum(case when cInVouchType='09' and bRdFlag=0 then i.iQuantity end) as 累计其他出库
1111111111 
into #g1 from InvPosition i left join #d o on i.RdsID=o.RdsID left join #b s on i.RdsID=s.AutoID left join Inventory inv on inv.cInvCode = i.cInvCode  left join Position p on i.cPosCode=p.cPosCode
left join #c r on i.cInvCode=r.cInvCode 
and isnull(i.cFree1,'')=isnull(r.cFree1,'') and isnull(i.cFree2,'')=isnull(r.cFree2,'') and isnull(i.cFree3,'')=isnull(r.cFree3,'') and isnull(i.cFree4,'')=isnull(r.cFree4,'') and isnull(i.cFree5,'')=isnull(r.cFree5,'')
and isnull(i.cFree6,'')=isnull(r.cFree6,'') and isnull(i.cFree7,'')=isnull(r.cFree7,'') and isnull(i.cFree8,'')=isnull(r.cFree8,'') and isnull(i.cFree9,'')=isnull(r.cFree9,'') and isnull(i.cFree10,'')=isnull(r.cFree10,'')
left join #e t on i.cInvCode=t.cInvCode 
and isnull(i.cFree1,'')=isnull(t.cFree1,'') and isnull(i.cFree2,'')=isnull(t.cFree2,'') and isnull(i.cFree3,'')=isnull(t.cFree3,'') and isnull(i.cFree4,'')=isnull(t.cFree4,'') and isnull(i.cFree5,'')=isnull(t.cFree5,'')
and isnull(i.cFree6,'')=isnull(t.cFree6,'') and isnull(i.cFree7,'')=isnull(t.cFree7,'') and isnull(i.cFree8,'')=isnull(t.cFree8,'') and isnull(i.cFree9,'')=isnull(t.cFree9,'') and isnull(i.cFree10,'')=isnull(t.cFree10,'')
left join InventoryClass ic1 on ic1.cInvCCode = left(inv.cInvCCode,2)
left join InventoryClass ic2 on ic2.cInvCCode = left(inv.cInvCCode,4)
left join InventoryClass ic3 on ic3.cInvCCode = left(inv.cInvCCode,6) 
where 1=1 and ((bRdFlag=0 and i.iquantity<0) or (bRdFlag=1 and i.iquantity>0)) and r.cInvCode is not null 
group by ic1.cInvCCode,ic1.cInvCName,ic2.cInvCCode,ic2.cInvCName,ic3.cInvCCode,ic3.cInvCName
,i.cInvCode,i.cFree1,i.cFree2,i.cFree3,i.cFree4,i.cFree5,i.cFree6,i.cFree7,i.cFree8,i.cFree9,i.cFree10,cvouchtype,inv.cInvName,inv.cInvStd

select *,case when i合格-iOutQuantity>0 then i合格-iOutQuantity else 0 end as 合格,case when i合格-iOutQuantity>0 then 0 else iOutQuantity-i合格 end as iOutQuantity1
,case when i合格-iOutQuantity>0 then iQuantity1-iOutQuantity else iQuantity1-i合格 end as iQuantity2 into #g2 from #g1 

select *,case when i待检-iOutQuantity1>0 then i待检-iOutQuantity1 else 0 end as 待检,case when i待检-iOutQuantity1>0 then 0 else iOutQuantity1-i待检 end as iOutQuantity2 
,case when i待检-iOutQuantity1>0 then iQuantity2-iOutQuantity1 else iQuantity2-i待检 end as iQuantity3 into #g3 from #g2 

select *,case when i不合格-iOutQuantity1>0 then i不合格-iOutQuantity2 else 0 end as 不合格,case when i不合格-iOutQuantity2>0 then 0 else i不合格-i待检 end as iOutQuantity3 
,case when i待检-iOutQuantity1>0 then iQuantity3-iOutQuantity2 else iQuantity3-待检 end as iQuantity from #g3 where iOutQuantity<>0
";
            string 仓库 = "";
            DataTable dtck = Warehouse(Conn);
            DataTable dtproj = Project(Conn);
            DataTable dtqc = QC(Conn, cInvCode1, cInvCode2);

            for (int i = 0; i < dtck.Rows.Count; i++)
            {
                仓库 = 仓库 + @"
                    ,sum(case when i.cWhCode='" + dtck.Rows[i]["cWhCode"].ToString().Trim() + "' then convert(decimal(18, 3),o.iquantity) end) as cWhCode_" + dtck.Rows[i]["cWhCode"].ToString().Trim() + "";
            }
            for (int i = 0; i < dtproj.Rows.Count; i++)
            {
                仓库 = 仓库 + @"
                    ,sum(case when i.cFree3='" + dtproj.Rows[i]["cValue"].ToString().Trim() + "' then convert(decimal(18, 3),o.iquantity) end) as Project_" + dtproj.Rows[i]["cValue"].ToString().Trim() + "";
            }

            sSQL = sSQL.Replace("1111111111", 仓库);

            if (cInvCode1.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and i.cInvCode>='" + cInvCode1.Trim() + "'");
            }
            if (cInvCode2.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and i.cInvCode<='" + cInvCode2.Trim() + "'");
            }
            if (edate.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),i.dDate,120)<='" + DateTime.Parse(edate).ToString("yyyy-MM-dd") + "'");
            }
            if (cFree1.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and i.cFree1='" + cFree1.Trim() + "'");
            }
            if (cposname.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and i.cposname='" + cposname.Trim() + "'");
            }

            DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];

            DataView dv = dt.DefaultView;
            dv.Sort = "cInvCCode1 asc,cInvCCode2 asc,cInvCCode3 asc,cInvCode asc";
            return dv.ToTable();
            //return dt;
        }

        public DataTable 库存(string Conn, string cInvCode1, string cInvCode2, string sdate, string edate, string cFree1, string cFree3, string cFree4, string cPosCode, string cWhCode, bool isJY)
        {
            string sSQL = @"
select AutoID,cBatchProperty6,cBatchProperty7,cBatchProperty8,cBatchProperty9,cbMemo,b.cCode ,b.dDate,r.cRdName,'01' as Flag,cHandler  into #b from rdrecords01 a 
left join rdrecord01 b on a.ID=b.ID left join rd_style r on b.cRdCode =r.cRdCode 

insert into #b select AutoID,cBatchProperty6,cBatchProperty7,cBatchProperty8,cBatchProperty9,cbMemo,b.cCode ,b.dDate,r.cRdName,'08' as Flag,cHandler from rdrecords08 a 
left join rdrecord08 b on a.ID=b.ID left join rd_style r on b.cRdCode =r.cRdCode 

insert into #b select AutoID,cBatchProperty6,cBatchProperty7,cBatchProperty8,cBatchProperty9,cbMemo,b.cCode ,b.dDate,r.cRdName,'09' as Flag,cHandler from rdrecords09 a 
left join rdrecord09 b on a.ID=b.ID left join rd_style r on b.cRdCode =r.cRdCode 

insert into #b select AutoID,cBatchProperty6,cBatchProperty7,cBatchProperty8,cBatchProperty9,cbMemo,b.cCode ,b.dDate,r.cRdName,'10' as Flag,cHandler from rdrecords10 a 
left join rdrecord10 b on a.ID=b.ID left join rd_style r on b.cRdCode =r.cRdCode 

insert into #b select AutoID,cBatchProperty6,cBatchProperty7,cBatchProperty8,cBatchProperty9,cbMemo,b.cCode ,b.dDate,r.cRdName,'11' as Flag,cHandler from rdrecords11 a 
left join rdrecord11 b on a.ID=b.ID left join rd_style r on b.cRdCode =r.cRdCode 

insert into #b select AutoID,cBatchProperty6,cBatchProperty7,cBatchProperty8,cBatchProperty9,cbMemo,b.cCode ,b.dDate,r.cRdName,'32' as Flag,cHandler from rdrecords32 a 
left join rdrecord32 b on a.ID=b.ID left join rd_style r on b.cRdCode =r.cRdCode 

insert into #b select AutoID,cBatchProperty6,cBatchProperty7,cBatchProperty8,cBatchProperty9,cbMemo,b.cCode ,b.dDate,r.cRdName,'34' as Flag,cHandler from rdrecords34 a 
left join rdrecord34 b on a.ID=b.ID left join rd_style r on b.cRdCode =r.cRdCode 


select cWhCode,cPosCode,cInvCode,cBatch,cFree1,cFree2,cFree3,cFree4,cFree5,cFree6,cFree7,cFree8,cFree9,cFree10,case when bRdFlag=0 then -iQuantity else iQuantity end iQuantity 
into #a from InvPosition i
where 1=1 and ((bRdFlag=0 and iquantity<0) or (bRdFlag=1 and iquantity>0)) 

insert  into #a select cWhCode,cPosCode,cInvCode,cBatch,cFree1,cFree2,cFree3,cFree4,cFree5,cFree6,cFree7,cFree8,cFree9,cFree10,case when bRdFlag=0 then -iQuantity else iQuantity end iQuantity 
from InvPosition i
where 1=1 and ((bRdFlag=0 and iquantity>0) or (bRdFlag=1 and iquantity<0)) 

select cWhCode,cPosCode,cInvCode,cBatch,cFree1,cFree2,cFree3,cFree4,cFree5,cFree6,cFree7,cFree8,cFree9,cFree10,sum(iQuantity) as iQuantity
into #c from #a group by cWhCode,cPosCode,cInvCode,cBatch,cFree1,cFree2,cFree3,cFree4,cFree5,cFree6,cFree7,cFree8,cFree9,cFree10 having sum(iQuantity)>0
 
select RdsID,o.Remark,convert(decimal(18, 3),case when bRdFlag=0 then -i.iQuantity else i.iQuantity end) as iQuantity,case when isnull(o.Conclusion,'')='' then 
case when (inv.cInvCCode like '0102%' or inv.cInvCCode like '0103%' or inv.cInvCCode like '0104%' or inv.cInvCCode like '03%' or inv.cInvCCode like '05%') then '1' else '2' end 
else o.Conclusion end 质检状态 into #d
from InvPosition i left join _QCConclusion o on i.RdsID=o.AutoID left join Inventory inv on inv.cInvCode = i.cInvCode
left join #c r on i.cPosCode=r.cPosCode and i.cInvCode=r.cInvCode and isnull(i.cBatch,'')=isnull(r.cBatch,'') and i.cWhCode=r.cWhCode
and isnull(i.cFree1,'')=isnull(r.cFree1,'') and isnull(i.cFree2,'')=isnull(r.cFree2,'') and isnull(i.cFree3,'')=isnull(r.cFree3,'') and isnull(i.cFree4,'')=isnull(r.cFree4,'') and isnull(i.cFree5,'')=isnull(r.cFree5,'')
and isnull(i.cFree6,'')=isnull(r.cFree6,'') and isnull(i.cFree7,'')=isnull(r.cFree7,'') and isnull(i.cFree8,'')=isnull(r.cFree8,'') and isnull(i.cFree9,'')=isnull(r.cFree9,'') and isnull(i.cFree10,'')=isnull(r.cFree10,'')

select Flag,ic1.cInvCCode as cInvCCode1,ic1.cInvCName as cInvCName1,ic2.cInvCCode as cInvCCode2,ic2.cInvCName as cInvCName2,ic3.cInvCCode as cInvCCode3,ic3.cInvCName as cInvCName3
,RdID,i.RdsID,cposname,i.cWhCode,i.cPosCode,i.cInvCode,i.cBatch,i.cFree1,i.cFree2,i.cFree3,i.cFree4,i.cFree5,i.cFree6,i.cFree7,i.cFree8,i.cFree9,i.cFree10,cvouchtype,convert(decimal(18, 3),o.iQuantity) as iQuantity,inv.cInvName,inv.cInvStd
,case when isnull(o.质检状态,'')='1' then '待检' when isnull(o.质检状态,'')='2' then '合格' when isnull(o.质检状态,'')='3' then '不合格' end 质检状态,o.Remark
,convert(decimal(18, 3),case when isnull(o.质检状态,'')='1' then o.iQuantity end) 待检
,convert(decimal(18, 3),case when isnull(o.质检状态,'')='2' then o.iQuantity end) 合格
,convert(decimal(18, 3),case when isnull(o.质检状态,'')='3' then o.iQuantity end) 不合格

,cBatchProperty6 as 物料标识,cBatchProperty7 as 包装批号,cBatchProperty8 as 包装备注,cBatchProperty9 as 作业指导书 ,o.Remark as 检验描述,cCode,i.dDate,cRdName,s.cHandler 
,convert(decimal(18, 3),case when 2=2 and cVouchType='10' and bRdFlag=1 then i.iQuantity end) as 累计入库,convert(decimal(18, 3),case when 2=2 and cVouchType='11' and bRdFlag=1 then i.iQuantity end) as 累计领料
,convert(decimal(18, 3),case when 2=2 and cVouchType='10' and bRdFlag=0 then -i.iQuantity end) as 累计退库
,convert(decimal(18, 3),case when 2=2 and cVouchType='01' and bRdFlag=1 then i.iQuantity end) as 采购入库,convert(decimal(18, 3),case when 2=2 and cVouchType='01' and bRdFlag=0 then -i.iQuantity end) as 退货数量
,convert(decimal(18, 3),case when 2=2 and cVouchType='32' and bRdFlag=1 then i.iQuantity end) as 累计销售,convert(decimal(18, 3),case when 2=2 and cVouchType='32' and bRdFlag=0 then -i.iQuantity end) as 累计退货
,convert(decimal(18, 3),case when 2=2 and cVouchType='08' and bRdFlag=1 then i.iQuantity end) as 累计其他入库,convert(decimal(18, 3),case when cInVouchType='09' and bRdFlag=0 then i.iQuantity end) as 累计其他出库
,convert(decimal(18, 3),case when bRdFlag=0 then -i.iQuantity else i.iQuantity end) iInQuantity,convert(decimal(18, 3),null) as iOutQuantity
1111111111 
from InvPosition i left join #d o on i.RdsID=o.RdsID left join #b s on i.RdsID=s.AutoID left join Inventory inv on inv.cInvCode = i.cInvCode  left join Position p on i.cPosCode=p.cPosCode
left join #c r on i.cPosCode=r.cPosCode and i.cInvCode=r.cInvCode and isnull(i.cBatch,'')=isnull(r.cBatch,'') and i.cWhCode=r.cWhCode
and isnull(i.cFree1,'')=isnull(r.cFree1,'') and isnull(i.cFree2,'')=isnull(r.cFree2,'') and isnull(i.cFree3,'')=isnull(r.cFree3,'') and isnull(i.cFree4,'')=isnull(r.cFree4,'') and isnull(i.cFree5,'')=isnull(r.cFree5,'')
and isnull(i.cFree6,'')=isnull(r.cFree6,'') and isnull(i.cFree7,'')=isnull(r.cFree7,'') and isnull(i.cFree8,'')=isnull(r.cFree8,'') and isnull(i.cFree9,'')=isnull(r.cFree9,'') and isnull(i.cFree10,'')=isnull(r.cFree10,'')
left join InventoryClass ic1 on ic1.cInvCCode = left(inv.cInvCCode,2)
left join InventoryClass ic2 on ic2.cInvCCode = left(inv.cInvCCode,4)
left join InventoryClass ic3 on ic3.cInvCCode = left(inv.cInvCCode,6) 
where 1=1 and ((bRdFlag=0 and i.iquantity<0) or (bRdFlag=1 and i.iquantity>0)) and r.cInvCode is not null 
order by case when isnull(o.质检状态,'')='1' then '2' when isnull(o.质检状态,'')='2' then '1' when isnull(o.质检状态,'')='3' then '3' end 
";
            string 仓库 = "";
            DataTable dtck = Warehouse(Conn);
            DataTable dtproj = Project(Conn);
            DataTable dtqc = QC(Conn, cInvCode1, cInvCode2);

            for (int i = 0; i < dtck.Rows.Count; i++)
            {
                仓库 = 仓库 + @"
                    ,case when i.cWhCode='" + dtck.Rows[i]["cWhCode"].ToString().Trim() + "' then convert(decimal(18, 3),o.iquantity) end as cWhCode_" + dtck.Rows[i]["cWhCode"].ToString().Trim() + "";
            }
            for (int i = 0; i < dtproj.Rows.Count; i++)
            {
                仓库 = 仓库 + @"
                    ,case when i.cFree3='" + dtproj.Rows[i]["cValue"].ToString().Trim() + "' then convert(decimal(18, 3),o.iquantity) end as Project_" + dtproj.Rows[i]["cValue"].ToString().Trim() + "";
            }

            sSQL = sSQL.Replace("1111111111", 仓库);

            if (cInvCode1.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and i.cInvCode>='" + cInvCode1.Trim() + "'");
            }
            if (cInvCode2.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and i.cInvCode<='" + cInvCode2.Trim() + "'");
            }
            if (edate.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),i.dDate,120)<='" + DateTime.Parse(edate).ToString("yyyy-MM-dd") + "'");
            }
            
            if (cFree1.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and i.cFree1='" + cFree1.Trim() + "'");
            }
            if (cFree3.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and i.cFree3='" + cFree3.Trim() + "'");
            }
            if (cFree4.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and i.cFree4='" + cFree4.Trim() + "'");
            }
            if (cPosCode.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and i.cPosCode like '" + cPosCode.Trim() + "%'");
            }
            if (cWhCode.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and i.cWhCode = '" + cWhCode.Trim() + "'");
            }
            if (edate != "")
            {
                sSQL = sSQL.Replace("2=2", "2=2 and convert(varchar(10),i.dDate,120)<='" + DateTime.Parse(edate).ToString("yyyy-MM-dd") + "'");
            }
            else if (sdate != "")
            {
                sSQL = sSQL.Replace("2=2", "2=2 and convert(varchar(10),i.dDate,120)>='" + DateTime.Parse(sdate).ToString("yyyy-MM-dd") + "'");
            }
            DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];

            sSQL = @"
select cWhCode,cPosCode,cInvCode,cBatch,cFree1,cFree2,cFree3,cFree4,cFree5,cFree6,cFree7,cFree8,cFree9,cFree10
,convert(decimal(18, 3),case when bRdFlag=0 then -iQuantity else iQuantity end) iQuantity 
into #a from InvPosition i
where 1=1 and ((bRdFlag=0 and iquantity<0) or (bRdFlag=1 and iquantity>0)) 

insert  into #a select cWhCode,cPosCode,cInvCode,cBatch,cFree1,cFree2,cFree3,cFree4,cFree5,cFree6,cFree7,cFree8,cFree9,cFree10
,convert(decimal(18, 3),case when bRdFlag=0 then -iQuantity else iQuantity end) iQuantity 
from InvPosition i
where 1=1 and ((bRdFlag=0 and iquantity>0) or (bRdFlag=1 and iquantity<0)) 

select cWhCode,cPosCode,cInvCode,cBatch,cFree1,cFree2,cFree3,cFree4,cFree5,cFree6,cFree7,cFree8,cFree9,cFree10,sum(iQuantity) as iQuantity
into #c from #a group by cWhCode,cPosCode,cInvCode,cBatch,cFree1,cFree2,cFree3,cFree4,cFree5,cFree6,cFree7,cFree8,cFree9,cFree10 having sum(iQuantity)>0

select RdID,RdsID,cposname,i.cWhCode,i.cPosCode,i.cInvCode,i.cBatch,i.cFree1,i.cFree2,i.cFree3,i.cFree4,i.cFree5,i.cFree6,i.cFree7,i.cFree8,i.cFree9,i.cFree10,cvouchtype,case when bRdFlag=0 then i.iQuantity else -i.iQuantity end iQuantity,convert(decimal(18, 3),0) as iOutQuantity
from InvPosition i left join _QCConclusion o on i.RdsID=o.AutoID left join Position p on i.cPosCode=p.cPosCode
left join #c r on i.cPosCode=r.cPosCode and i.cInvCode=r.cInvCode and isnull(i.cBatch,'')=isnull(r.cBatch,'') and i.cWhCode=r.cWhCode
and isnull(i.cFree1,'')=isnull(r.cFree1,'') and isnull(i.cFree2,'')=isnull(r.cFree2,'') and isnull(i.cFree3,'')=isnull(r.cFree3,'') and isnull(i.cFree4,'')=isnull(r.cFree4,'') and isnull(i.cFree5,'')=isnull(r.cFree5,'')
and isnull(i.cFree6,'')=isnull(r.cFree6,'') and isnull(i.cFree7,'')=isnull(r.cFree7,'') and isnull(i.cFree8,'')=isnull(r.cFree8,'') and isnull(i.cFree9,'')=isnull(r.cFree9,'') and isnull(i.cFree10,'')=isnull(r.cFree10,'')
where 1=1 and ((bRdFlag=0 and i.iquantity>0) or (bRdFlag=1 and i.iquantity<0)) and r.cInvCode is not null order by dDate ";

            if (cInvCode1.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and i.cInvCode>='" + cInvCode1.Trim() + "'");
            }
            if (cInvCode2.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and i.cInvCode<='" + cInvCode2.Trim() + "'");
            }
            if (edate.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),dDate,120)<='" + DateTime.Parse(edate).ToString("yyyy-MM-dd") + "'");
            }
            if (cFree1.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and i.cFree1='" + cFree1.Trim() + "'");
            }
            if (cFree3.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and i.cFree3='" + cFree3.Trim() + "'");
            }
            if (cFree4.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and i.cFree4='" + cFree4.Trim() + "'");
            }
            if (cPosCode.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and i.cPosCode like '" + cPosCode.Trim() + "%'");
            }
            if (cWhCode.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and i.cWhCode = '" + cWhCode.Trim() + "'");
            }
            DataTable dtout = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];

            if (isJY == true)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string Free1 = dt.Rows[i]["cFree1"].ToString();
                    string Free2 = dt.Rows[i]["cFree2"].ToString();
                    string Free3 = dt.Rows[i]["cFree3"].ToString();
                    string Free4 = dt.Rows[i]["cFree4"].ToString();
                    string Free5 = dt.Rows[i]["cFree5"].ToString();
                    string Free6 = dt.Rows[i]["cFree6"].ToString();
                    string Free7 = dt.Rows[i]["cFree7"].ToString();
                    string Free8 = dt.Rows[i]["cFree8"].ToString();
                    string Free9 = dt.Rows[i]["cFree9"].ToString();
                    string Free10 = dt.Rows[i]["cFree10"].ToString();
                    decimal iQuantity = 系统服务.规格化.ReturnDecimal(dt.Rows[i]["iQuantity"],3);

                    if (iQuantity > 0)
                    {
                        //if (dt.Rows[i]["cBatch"].ToString() == "1511261302")
                        //{
                        //    string s = "1";
                        //}
                        DataRow[] dw = dtout.Select("iQuantity-iOutQuantity>0 and cInvCode='" + dt.Rows[i]["cInvCode"].ToString() + "' and cBatch='" + dt.Rows[i]["cBatch"].ToString() + "' and cWhCode='" + dt.Rows[i]["cWhCode"].ToString() + "' and cPosCode='" + dt.Rows[i]["cPosCode"].ToString() + "' and isnull(cFree1,'')='" + Free1 + "' and isnull(cFree2,'')='" + Free2 + "' and isnull(cFree3,'')='" + Free3 + "' and isnull(cFree4,'')='" + Free4 + "' and isnull(cFree5,'')='" + Free5 + "' and isnull(cFree6,'')='" + Free6 + "' and isnull(cFree7,'')='" + Free7 + "' and isnull(cFree8,'')='" + Free8 + "' and isnull(cFree9,'')='" + Free9 + "' and isnull(cFree10,'')='" + Free10 + "'");
                        for (int j = 0; j < dw.Length; j++)
                        {
                            if (iQuantity == 0)
                                continue;
                            decimal iQty = 系统服务.规格化.ReturnDecimal(dw[j]["iQuantity"],3) - 系统服务.规格化.ReturnDecimal(dw[j]["iOutQuantity"],3);

                            if (iQuantity > 0)
                            {
                                decimal iOutQuantity = 系统服务.规格化.ReturnDecimal(dw[j]["iOutQuantity"]);
                                if (iQuantity > iQty)
                                {
                                    dt.Rows[i]["iQuantity"] = iQuantity - iQty;
                                    dw[j]["iOutQuantity"] = iOutQuantity + iQty;
                                    iQuantity = iQuantity - iQty;
                                }
                                else
                                {
                                    dt.Rows[i]["iQuantity"] = 0;
                                    dw[j]["iOutQuantity"] = iOutQuantity + iQuantity;
                                    iQuantity = 0;
                                }
                            }
                            if (系统服务.规格化.ReturnDecimal(dt.Rows[i]["iInQuantity"]) - 系统服务.规格化.ReturnDecimal(dt.Rows[i]["iQuantity"]) == 0)
                            {
                                dt.Rows[i]["iOutQuantity"] = DBNull.Value;
                            }
                            else
                            {
                                dt.Rows[i]["iOutQuantity"] = 系统服务.规格化.ReturnDecimal(dt.Rows[i]["iInQuantity"],3) - 系统服务.规格化.ReturnDecimal(dt.Rows[i]["iQuantity"],3);
                            }
                        }
                    }
                }

                sSQL = @"select a.* from _QCResult  a  left join InvPosition b on a.AutoID=b.RdsID where 1=1 and b.RdsID is not null";
                if (cInvCode1.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.cInvCode>='" + cInvCode1.Trim() + "'");
                }
                if (cInvCode2.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.cInvCode<='" + cInvCode2.Trim() + "'");
                }
                DataTable dtjy = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                for (int s = 0; s < dtqc.Rows.Count; s++)
                {
                    dt.Columns.Add("QCResult_" + dtqc.Rows[s]["QCCode"].ToString().Trim());
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string sWhere = "AutoID='" + dt.Rows[i]["RdsID"].ToString() + "' and  QCCode='" + dtqc.Rows[s]["QCCode"].ToString().Trim() + "'";

                        DataRow[] dw = dtjy.Select(sWhere);
                        if (dw.Length > 0)
                        {
                            dt.Rows[i]["QCResult_" + dtqc.Rows[s]["QCCode"].ToString().Trim()] = dw[0]["Result"];
                        }
                    }
                }

                for (int i = dt.Rows.Count - 1; i > 0; i--)
                {
                    decimal iQuantity = 系统服务.规格化.ReturnDecimal(dt.Rows[i]["iQuantity"]);
                    if (iQuantity == 0)
                    {
                        dt.Rows.Remove(dt.Rows[i]);
                    }
                }

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    decimal iQty = 系统服务.规格化.ReturnDecimal(dt.Rows[i]["iQuantity"]);
                    decimal d1 = 系统服务.规格化.ReturnDecimal(dt.Rows[i]["待检"]);
                    decimal d2 = 系统服务.规格化.ReturnDecimal(dt.Rows[i]["合格"]);
                    decimal d3 = 系统服务.规格化.ReturnDecimal(dt.Rows[i]["不合格"]);
                    if (d1 > 0)
                    {
                        dt.Rows[i]["待检"] = iQty;
                    }
                    else if (d2 > 0)
                    {
                        dt.Rows[i]["合格"] = iQty;
                    }
                    else if (d3 > 0)
                    {
                        dt.Rows[i]["不合格"] = iQty;
                    }
                    for (int j = 0; j < dtck.Rows.Count; j++)
                    {
                        decimal d = 系统服务.规格化.ReturnDecimal(dt.Rows[i]["cWhCode_" + dtck.Rows[j]["cWhCode"].ToString()]);
                        if (d > 0)
                        {
                            dt.Rows[i]["cWhCode_" + dtck.Rows[j]["cWhCode"].ToString()] = iQty;
                        }
                    }
                    for (int j = 0; j < dtproj.Rows.Count; j++)
                    {
                        decimal d = 系统服务.规格化.ReturnDecimal(dt.Rows[i]["Project_" + dtproj.Rows[j]["cValue"].ToString()]);
                        if (d > 0)
                        {
                            dt.Rows[i]["Project_" + dtproj.Rows[j]["cValue"].ToString()] = iQty;
                        }
                    }
                }
            }
            DataView dv = dt.DefaultView;
            dv.Sort = "cInvCCode1 asc,cInvCCode2 asc,cInvCCode3 asc,cInvCode asc";
            return dv.ToTable();
        }

        public DataTable Warehouse(string Conn)
        {
            return SqlHelper.ExecuteDataset(Conn, CommandType.Text, @"select * from Warehouse where dWhEndDate is null").Tables[0];
        }

        public DataTable Project(string Conn)
        {
            return SqlHelper.ExecuteDataset(Conn, CommandType.Text, @"select cValue from UserDefine where cID=28").Tables[0];
        }

        public DataTable QC(string Conn, string cInvCode1, string cInvCode2)
        {
            return SqlHelper.ExecuteDataset(Conn, CommandType.Text, @"select a.* from _QC a left join _QCcInvCode b on a.QCCode=b.QCCode where b.cInvCode>='" + cInvCode1.Trim() + "' and b.cInvCode<='" + cInvCode2.Trim() + "'").Tables[0];
        }

        public DataTable 收发存汇总本期单据联查二级明细(string Conn, string cCode, string cRdName)
        {
            string sSQL = @"
select AutoID,cBatchProperty6 as 物料标识或备注,cBatchProperty7 as 包装批号,cBatchProperty9 as 作业指导书,cFree1 as 包装,cFree3 as 虚拟库,convert(decimal(18, 3),iquantity) as 数量,cBatch as 批号
,cbMemo,b.cCode as 单据号,b.dDate as 单据日期,cu.cComUnitName 单位,a.cInvCode as 物料编码,i.cInvName as 品名,i.cInvStd as 型号,r.cRdName as 出入库类型
,case when ISNULL(b.cHandler ,'')<>'' then '审核' when isnull(b.iswfcontrolled,0)=1 and isnull(b.iverifystate ,0)=1 then '审核中' when ISNULL(b.cMaker,'')<>'' then '开立' end as 审批状态
,'01' as Flag into #b from rdrecords01 a 
left join rdrecord01 b on a.ID=b.ID left join rd_style r on b.cRdCode =r.cRdCode left join Inventory i on a.cInvCode=i.cInvCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode where 1=1

insert into #b select AutoID,cBatchProperty6 as 物料标识或备注,cBatchProperty7 as 包装批号,cBatchProperty9 as 作业指导书,cFree1 as 包装,cFree3 as 虚拟库,iquantity as 数量,cBatch as 批号
,cbMemo,b.cCode as 单据号,b.dDate as 单据日期,cu.cComUnitName 单位,a.cInvCode as 物料编码,i.cInvName as 品名,i.cInvStd as 型号,r.cRdName as 出入库类型
,case when ISNULL(b.cHandler ,'')<>'' then '审核' when isnull(b.iswfcontrolled,0)=1 and isnull(b.iverifystate ,0)=1 then '审核中' when ISNULL(b.cMaker,'')<>'' then '开立' end as 审批状态
,'08' as Flag from rdrecords08 a 
left join rdrecord08 b on a.ID=b.ID left join rd_style r on b.cRdCode =r.cRdCode left join Inventory i on a.cInvCode=i.cInvCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode where 1=1

insert into #b select AutoID,cBatchProperty6 as 物料标识或备注,cBatchProperty7 as 包装批号,cBatchProperty9 as 作业指导书,cFree1 as 包装,cFree3 as 虚拟库,iquantity as 数量,cBatch as 批号
,cbMemo,b.cCode as 单据号,b.dDate as 单据日期,cu.cComUnitName 单位,a.cInvCode as 物料编码,i.cInvName as 品名,i.cInvStd as 型号,r.cRdName as 出入库类型
,case when ISNULL(b.cHandler ,'')<>'' then '审核' when isnull(b.iswfcontrolled,0)=1 and isnull(b.iverifystate ,0)=1 then '审核中' when ISNULL(b.cMaker,'')<>'' then '开立' end as 审批状态
,'09' as Flag from rdrecords09 a 
left join rdrecord09 b on a.ID=b.ID left join rd_style r on b.cRdCode =r.cRdCode left join Inventory i on a.cInvCode=i.cInvCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode where 1=1

insert into #b select AutoID,cBatchProperty6 as 物料标识或备注,cBatchProperty7 as 包装批号,cBatchProperty9 as 作业指导书,cFree1 as 包装,cFree3 as 虚拟库,iquantity as 数量,cBatch as 批号
,cbMemo,b.cCode as 单据号,b.dDate as 单据日期,cu.cComUnitName 单位,a.cInvCode as 物料编码,i.cInvName as 品名,i.cInvStd as 型号,r.cRdName as 出入库类型
,case when ISNULL(b.cHandler ,'')<>'' then '审核' when isnull(b.iswfcontrolled,0)=1 and isnull(b.iverifystate ,0)=1 then '审核中' when ISNULL(b.cMaker,'')<>'' then '开立' end as 审批状态
,'10' as Flag from rdrecords10 a 
left join rdrecord10 b on a.ID=b.ID left join rd_style r on b.cRdCode =r.cRdCode left join Inventory i on a.cInvCode=i.cInvCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode where 1=1

insert into #b select AutoID,cBatchProperty6 as 物料标识或备注,cBatchProperty7 as 包装批号,cBatchProperty9 as 作业指导书,cFree1 as 包装,cFree3 as 虚拟库,iquantity as 数量,cBatch as 批号
,cbMemo,b.cCode as 单据号,b.dDate as 单据日期,cu.cComUnitName 单位,a.cInvCode as 物料编码,i.cInvName as 品名,i.cInvStd as 型号,r.cRdName as 出入库类型
,case when ISNULL(b.cHandler ,'')<>'' then '审核' when isnull(b.iswfcontrolled,0)=1 and isnull(b.iverifystate ,0)=1 then '审核中' when ISNULL(b.cMaker,'')<>'' then '开立' end as 审批状态
,'11' as Flag from rdrecords11 a 
left join rdrecord11 b on a.ID=b.ID left join rd_style r on b.cRdCode =r.cRdCode left join Inventory i on a.cInvCode=i.cInvCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode where 1=1

insert into #b select AutoID,cBatchProperty6 as 物料标识或备注,cBatchProperty7 as 包装批号,cBatchProperty9 as 作业指导书,cFree1 as 包装,cFree3 as 虚拟库,iquantity as 数量,cBatch as 批号
,cbMemo,b.cCode as 单据号,b.dDate as 单据日期,cu.cComUnitName 单位,a.cInvCode as 物料编码,i.cInvName as 品名,i.cInvStd as 型号,r.cRdName as 出入库类型
,case when ISNULL(b.cHandler ,'')<>'' then '审核' when isnull(b.iswfcontrolled,0)=1 and isnull(b.iverifystate ,0)=1 then '审核中' when ISNULL(b.cMaker,'')<>'' then '开立' end as 审批状态
,'32' as Flag from rdrecords32 a 
left join rdrecord32 b on a.ID=b.ID left join rd_style r on b.cRdCode =r.cRdCode left join Inventory i on a.cInvCode=i.cInvCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode where 1=1

insert into #b select AutoID,cBatchProperty6 as 物料标识或备注,cBatchProperty7 as 包装批号,cBatchProperty9 as 作业指导书,cFree1 as 包装,cFree3 as 虚拟库,iquantity as 数量,cBatch as 批号
,cbMemo,b.cCode as 单据号,b.dDate as 单据日期,cu.cComUnitName 单位,a.cInvCode as 物料编码,i.cInvName as 品名,i.cInvStd as 型号,r.cRdName as 出入库类型
,case when ISNULL(b.cHandler ,'')<>'' then '审核' when isnull(b.iswfcontrolled,0)=1 and isnull(b.iverifystate ,0)=1 then '审核中' when ISNULL(b.cMaker,'')<>'' then '开立' end as 审批状态
,'34' as Flag from rdrecords34 a 
left join rdrecord34 b on a.ID=b.ID left join rd_style r on b.cRdCode =r.cRdCode left join Inventory i on a.cInvCode=i.cInvCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode where 1=1

select * from #b 
";
            if (cCode != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and cCode='" + cCode + "'");
            }
            sSQL = sSQL.Replace("1=1", "1=1 and r.cRdName='" + cRdName + "'");
            DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            return dt;
        }
    }
}
