USE [UFDATA_012_2017]
GO
/****** Object:  StoredProcedure [dbo].[_TH_Get_AP]    Script Date: 2018-11-27 14:01:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--		exec [_TH_Get_AP] '2018-01-31'



ALTER proc [dbo].[_TH_Get_AP] (@dtm datetime)
as

set nocount on 



 if exists(select * from tempdb..sysobjects where id=object_id('tempdb..#tmp1')) drop table #tmp1
 if exists(select * from tempdb..sysobjects where id=object_id('tempdb..#tmp2')) drop table #tmp2
 if exists(select * from tempdb..sysobjects where id=object_id('tempdb..tmpuf_750652645_Ap_Ywzb_836168081')) drop table tempdb..tmpuf_750652645_Ap_Ywzb_836168081


select max(dVouchDate) as dVouchDate1,cFlag as cFlag1,cVouchType as cVouchType1,Max(cTypeName) as cTypeName1,cVouchId as cVouchId1,cDwCode as cDwCode1,cDwName as cDwName1,Max(cSSName) as cProcName,Max(cDeptCode) as cDeptCode1,Max(cPerson) as cPerson1,Max(cCode) as cCode,Max(cDigest) as cDigest1,Max(a.cexch_name) as exchname,Max(iexchrate) as Rate,Max(cItem_Class) as cItem_Class,Max(cItemCode) as cItemCode,Max(cItemName) as cItemName,Max(cContractType) as cContractType,Max(cContractID) as cContractID,Max(case when cpzid is null then null else dPzDate end) as dbill_date1,Max(cGlsign+N'-'+isnull(REPLICATE(N'0',4-len(iGLno_id)),N'')+convert(nvarchar,iGLno_id)) as cPzNum1,Max(cPzId) as cPzId1,max(cordertype) as csource1,max(corderno) as corderno1,max(cdlcode) as cdlcode1, case when max(iperiod)=0 and max(ivouchamount_f) is not null then max(ivouchamount_f) else sum(iDAmount_f+icamount_f) end as iAmount_f1, case when max(iperiod)=0 and max(ivouchamount) is not null then max(ivouchamount) else sum(iDAmount+icamount) end as iAmount1, case when max(iperiod)=0 and max(ivouchamount_s) is not null then max(ivouchamount_s) else sum(iDAmount_s+iCAmount_s) end as iAmount_s1, case when max(iperiod)=0 and max(ivouchamount_f) is not null then max(ivouchamount_f)-sum(iDAmount_f+icamount_f) else 0 end as iAmount_f3, case when max(iperiod)=0 and max(ivouchamount) is not null then max(ivouchamount)-sum(iDAmount+icamount) else 0 end as iAmount3, case when max(iperiod)=0 and max(ivouchamount_s) is not null then max(ivouchamount_s)-sum(iDAmount_s+icamount_s) else 0 end as iAmount_s3 
into #tmp1 
From Ap_DetailVend a with(nolock) where (iflag<=2 or iflag=5) and (cVouchType=cProcStyle Or iFlag=1 Or cProcStyle=N'BZ' Or cProcStyle=N'XJ') And cVouchType like N'4%' And cFlag=N'AP' And ((cProcStyle=N'BZ' And ((cVouchType=N'49' And iDAmount>0) Or (cVouchType=N'48' And iDAmount<0))) Or cProcStyle<>N'BZ') And cFlag=N'AP'  
	And year(a.dVouchDate) = year(@dtm) and month(a.dVouchDate) = month(@dtm) 
Group By cDwCode,cDwName,cFlag,cVouchType,cVouchID order by cDwCode,max(dVouchDate)

select max(auto_id) as auto_id2,max(dVouchDate) as dVouchDate2,max(dRegDate) as dRegDate2,max(cDwCode) as cDwCode2,max(cDwName) as cDwName2,max(cdeptcode) as cDeptCode2,max(cPerson) as cPerson2,max(cProcStyle) as cProcStyle,max(cProcName) as cProcName1,max(ibvid) as ibvid,max(cInvCode) as cInvCode,Max(cInvName) as cInvName,max(cInvStd) as cInvStd,a.cFlag as cFlag2,(case when cVouchType=N'9O' and cCoVouchType like N'4%' then cCoVouchType else cVouchType end) as cVouchType2,(case when cVouchType=N'9O' and cCoVouchType like N'4%' then cCoVouchID else cVouchID end) as cVouchID2,(case when cVouchType=N'9O' and cCoVouchType like N'4%' then cVouchType else cCoVouchType end) as cVouchType,Max(case when cVouchType=N'9O' and cCoVouchType like N'4%' then a.cTypeName else Ap_VouchType.cTypeName end) as cTypeName,(case when cVouchType=N'9O' and cCoVouchType like N'4%' then cVouchID else cCoVouchID end) as cVouchID,cCancelNo,sum(case when cProcStyle in (N'9K',N'9L',N'BZ',N'9N') then -(iDAmount_f+iCAmount_f) else iDAmount_f+iCAmount_f end) as iAmount_f2,sum(case when iflag=4 and a.cFlag=N'AR' and cVouchType=N'48' then iCAmount-iDAmount when iflag=4 and a.cFlag=N'AP' and cVouchType=N'49' then iDAmount-iCAmount  when cProcStyle=N'9M' and a.cFlag=N'AR' and cVouchType=N'49' then iDAmount+iCAmount when cProcStyle=N'9M' and a.cFlag=N'AP' and cVouchType=N'48' then iDAmount+iCAmount else (case when cProcStyle in (N'9K',N'9L',N'9N',N'BZ',N'9M') then -(iDAmount+iCAmount) else iDAmount+iCAmount end) end) as iAmount2,sum(case when cProcStyle in (N'9K',N'9L',N'BZ',N'9N') then -(iDAmount_s+iCAmount_s) else iDAmount_s+iCAmount_s end) as iAmount_s2,Max(case when cpzid is null then null else dPzDate end) as dbill_date2,Max(cGlsign+N'-'+isnull(REPLICATE(N'0',4-len(iGLno_id)),N'')+convert(nvarchar,iGLno_id)) as cPzNum2,Max(cDigest) As cDigest2,Max(a.cexch_name) as exchname1,Max(iexchrate) as Rate1,Max(cPzId) as cPzId2,max(cordertype) as csource2,max(corderno) as corderno2,max(cdlcode) as cdlcode2,max(isnull(dgatheringdate,dexpiredate)) as dexpiredate,max(cDwCode) as cDwCodeBZ 
into #tmp2 
from Ap_DetailVend a with(nolock)  
	Left Join Ap_VouchType on a.cCoVouchType=Ap_VouchType.cTypeCode 
	LEFT JOIN PayCondition with (nolock) ON a.cPayCode = PayCondition.cPayCode 
where (iflag<=2 Or iFlag=4 or iFlag=5) and cCoVouchType<>cProcStyle and iFlag<>1  And ((cProcStyle=N'BZ' 
	And ((cVouchType=N'49' And iDAmount<0) Or (cVouchType=N'48' And iDAmount>0))) Or cProcStyle<>N'BZ') And a.cFlag=N'AP' And (cProcStyle<>N'9P' Or cVouchType<>cCoVouchType)     
Group By cDwCode , cCancelno, a.cFlag, cVouchType, cVouchID, cCoVouchType, cCoVouchID

Insert into #tmp2(dVouchDate2,dRegDate2,cDwCode2,cDwCodeBZ,cProcStyle,cProcName1,cFlag2,cVouchType2,cVouchID2,cVouchType,cTypeName,cVouchID,cCancelNo,iAmount_f2,iAmount2,iAmount_s2,dbill_date2,cPzNum2,cDigest2,exchname1,Rate1,cPzId2) 
select max(dVouchDate) as dVouchDate2,max(dRegDate) as dRegDate2,max(cDwCode) as cDwCode2,max(cDwCode) as cDwCodeBZ,max(cProcStyle) as cProcStyle,max(cProcName) as cProcName1
	,cFlag,cCoVouchType as cVouchType2,cCoVouchID as cVouchID2,cVouchType,Max(cTypeName) as cTypeName,cVouchID,cCancelNo,sum(iCAmount_f-iDAmount_f) as iAmount_f2
	,sum(iCAmount-iDAmount) as iAmount2,sum(iCAmount_s-iDAmount_s) as iAmount_s2,Max(case when cpzid is null then null else dPzDate end) as dbill_date2
	,Max(cGlsign+N'-'+isnull(REPLICATE(N'0',4-len(iGLno_id)),N'')+convert(nvarchar,iGLno_id)) as cPzNum2,Max(cDigest) As cDigest2,Max(a.cexch_name) as exchname1
	,Max(iexchrate) as Rate1,Max(cPzId) as cPzId2 
from Ap_DetailVend a where iflag<=2 and cProcStyle=N'9P' and ((cVouchType=N'48' And cCoVouchType=N'49') Or (cVouchType=N'49' And cCoVouchType=N'48')) And cFlag=N'AP'   
Group By cDwCode , cCancelno, cFlag, cVouchType, cVouchID, cCoVouchType, cCoVouchID having sum(iCAmount_f-iDAmount_f)<>0 Or sum (iCAmount - iDAmount) <> 0

if exists(select 1 from tempdb..sysobjects with(nolock) where name=N'tmpuf_750652645_Ap_Ywzb_836168081' And xtype=N'U')  Truncate table tempdb..tmpuf_750652645_Ap_Ywzb_836168081 else Create Table tempdb..tmpuf_750652645_Ap_Ywzb_836168081(dVouchDate1 datetime,dRegDate1 datetime,cDwCode nvarchar(20),cDwName nvarchar(120),cflag1 nvarchar(2),cvouchtype1 nvarchar(10),ctypename1 nvarchar(50),cvouchid1 nvarchar(30),cDeptCode nvarchar(20),cDepName nvarchar(255),cPerson nvarchar(20),cPersonName nvarchar(120),cCode nvarchar(60),cCode_Name nvarchar(120),cdigest1 nvarchar(255),exchname nvarchar(8),Rate Float,cItem_Class nvarchar(2),cItem_Name nvarchar(60),cItemCode nvarchar(60),cItemName nvarchar(255),ibvid int,BalancesGuid [uniqueidentifier] NULL,cInvCode nvarchar(60),cInvName nvarchar(255),cInvStd nvarchar(255),cContractType nvarchar(12),cContractTypeName nvarchar(40),cContractID nvarchar(64),cContractName nvarchar(400),dbill_date1 datetime,cPzNum1 nvarchar(15),cPzid1 nvarchar(30),csource1 nvarchar(150),corderno1 nvarchar(30),cdlcode1 nvarchar(40),csource2 nvarchar(150),corderno2 nvarchar(30),cdlcode2 nvarchar(40),iAmount_f1 money,iAmount1 money,iAmount_s1 float,cOperator1 nvarchar(20),cCheckMan1 nvarchar(20),cProcName 
nvarchar(20),auto_id2 int,dVouchDate2 datetime,dRegDate2 datetime,cflag2 nvarchar(2),cvouchtype2 nvarchar(10),ctypename2 nvarchar(50),cvouchid2 nvarchar(30),cNoteNo nvarchar(30),cBankAccount nvarchar(50),cBank nvarchar(100),iAmount_f2 money,iAmount2 money,iAmount_s2 float,dbill_date2 datetime,cPzNum2 nvarchar(15),cPzid2 nvarchar(30),cDwCode2 nvarchar(20),cDwName2 nvarchar(120),cDeptCode2 nvarchar(20),cDepName2 nvarchar(255),cPerson2 nvarchar(20),cPersonName2 nvarchar(120),cItem_Class2 nvarchar(2),cItem_Name2 nvarchar(60),cItemCode2 nvarchar(60),cItemName2 nvarchar(255),cContractType2 nvarchar(12),cContractTypeName2 nvarchar(40),cContractID2 nvarchar(64),cContractName2 nvarchar(400),cOperator2 nvarchar(20),cCheckMan2 nvarchar(20),cCancelMan nvarchar(20),cDigest2 nvarchar(255),exchname1 nvarchar(8),Rate1 Float,dexpiredate datetime,iAmount_f3 money,iAmount3 money,iAmount_s3 float,dbill_date3 datetime,cPzNum3 nvarchar(15),[cDefine1] [nvarchar](20) NULL,[cDefine2] [nvarchar](20) NULL,[cDefine3] [nvarchar](20) NULL,[cDefine4] [datetime] NULL,[cDefine5] [int] NULL,[cDefine6] [datetime] NULL,[cDefine7] [float] NULL,[cDefine8] [nvarchar](4) NULL,[cDefine9] [nvarchar](8) NULL,[cDefine10] [nvarchar](60) NULL,[cDefine11] [nvarchar](120) NULL,[cDefine12] [nvarchar](120) NULL,[cDefine13] [nvarchar](120) NULL,[cDefine14] [nvarchar](120) NULL,[cDefine15] [int] NULL,[cDefine16] [float] NULL,[cOppdefine1] [nvarchar](20) NULL,[cOppdefine2] [nvarchar](20) NULL,[cOppdefine3] [nvarchar](20) NULL,[cOppdefine4] [datetime] NULL,[cOppdefine5] [int] NULL,[cOppdefine6] [datetime] NULL,[cOppdefine7] [float] NULL,[cOppdefine8] [nvarchar](4) NULL,[cOppdefine9] [nvarchar](8) NULL,[cOppdefine10] [nvarchar](60) NULL,[cOppdefine11] [nvarchar](120) NULL,[cOppdefine12] [nvarchar](120) NULL,[cOppdefine13] [nvarchar](120) NULL,[cOppdefine14] [nvarchar](120) NULL,[cOppdefine15] [int] NULL,[cOppdefine16] [float] NULL)


insert into tempdb..tmpuf_750652645_Ap_Ywzb_836168081(dVouchDate1,cFlag1,cvouchtype1,ctypename1,cvouchid1,cDwCode,cDwName,cDeptCode,cPerson,cCode,cdigest1,exchname,Rate,cItem_Class,cItemCode,cItemName,cContractType,cContractID,ibvid,cInvCode,cInvName,cInvStd,dbill_date1,cPzNum1,cPzid1, iAmount_f1, iAmount1,iAmount_s1,cprocname,auto_id2,dVouchDate2,dRegDate2,cFlag2,cvouchtype2,ctypename2,cvouchid2,iAmount_f2,iAmount2,iAmount_s2,cDwCode2,cDwName2,cDeptCode2,cPerson2,dbill_date2,cPzNum2,cPzid2,cDigest2,exchname1,Rate1,csource1,corderno1,cdlcode1,csource2,corderno2,cdlcode2,dexpiredate,iAmount_f3,iAmount3,iAmount_s3) select dVouchDate1,cFlag1,cvouchtype1,ctypename1,cvouchid1,cDwCode1,cDwName1,cDeptCode1,cPerson1,cCode,cdigest1,exchname,Rate,cItem_Class,cItemCode,cItemName,cContractType,cContractID,Null,Null,Null,Null,dbill_date1,cPzNum1,cPzid1,iAmount_f1,iAmount1,iAmount_s1,cprocname,auto_id2,dVouchDate2,dRegDate2,cFlag2,case when (cProcStyle=N'9P' or cProcStyle=N'XJ') then cvouchtype else cProcStyle end,case when (cProcStyle=N'9P' or cProcStyle=N'XJ') then ctypename else cProcName1 end,case when (cProcStyle=N'9P' or cProcStyle=N'XJ') then cvouchid else cCancelNo end,iAmount_f2,iAmount2,iAmount_s2,cDwCode2,cDwName2,cDeptCode2,cPerson2,dbill_date2,cPzNum2,cPzid2,cDigest2,exchname1,Rate1,csource1,corderno1,cdlcode1,csource2,corderno2,cdlcode2,dexpiredate,iAmount_f3,iAmount3,iAmount_s3 from #tmp1 a left join #tmp2 b on a.cvouchtype1=b.cvouchtype2 and a.cvouchid1=b.cvouchid2 and a.cdwcode1=b.cdwcodebz

--select * from tempdb..tmpuf_750652645_Ap_Ywzb_836168081

select a.cDwCode,a.cDwName,a.dVouchDate1,a.ctypename1, a.cvouchid1,a.cCode,a.exchname,a.Rate as dRate
		,max(a.iAmount_f1) as iAmount_f1,max(a.iAmount1) as iAmount1
		,sum(a.iAmount_f2) as iAmount_f2
		,cast(sum(a.iAmount_f2 * case when c.cExchRate  is null then isnull(d.iExchRate,0) else isnull(c.cExchRate ,0) end) as decimal(16,2)) as iAmount2

		,max(a.iAmount1) - cast(sum(a.iAmount_f2 * case when c.cExchRate  is null then isnull(d.iExchRate,0) else isnull(c.cExchRate ,0) end) as decimal(16,2)) as HDSY
		--,max(a.iAmount1) , cast(sum(a.iAmount_f2 * case when c.cExchRate  is null then isnull(d.iExchRate,0) else isnull(c.cExchRate ,0) end) as decimal(16,2)), c.cExchRate,d.iExchRate
from tempdb..tmpuf_750652645_Ap_Ywzb_836168081 a
	left join PurBillVouch  c on a.cVouchID2 = c.cPBVCode 
	left join Ap_Detail  d on a.cVouchID2 = d.cVouchID  and d.cvouchtype = 'P0'
where a.Rate <> 1
group by a.cDwCode,a.cDwName,a.ctypename1, a.cvouchid1,a.cCode,a.exchname,a.Rate,a.exchname,a.dVouchDate1
having max(a.iAmount1) - cast(sum(a.iAmount_f2 * case when c.cExchRate  is null then isnull(d.iExchRate,0) else isnull(c.cExchRate ,0) end) as decimal(16,2)) <> 0


