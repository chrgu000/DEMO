using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TH.BaseClass;

namespace DllForTK
{
    public class clsTrialkitting
    {
        DataTable dtBom;

        public void CheckStatus(SqlTransaction tran, long iID)
        {
            string sSQL = @"
SELECT   iID 
FROM      TK_List with (nolock)
where isnull(iState,0) = 4 and iID = {0}
";
            sSQL = string.Format(sSQL, iID);
            DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
            
            if (dt != null && dt.Rows.Count > 0)
            {
                throw new Exception("用户终止");
            }
        }

        public string Trialkitting(long iID, string sUid, string sPath, int iVerTrialkittingType,out string sTKVersion_out)
        {
            try
            {
                int iCou = 0;

                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    ClsWriteLog.WriteLog(sPath, "计算", "计算开始");
                    string sSQL = "";

                    string sProdGroup = "";
                    string sPlanner = "";
                    int iUpload_Type = -1;
                    string sTKVersion_Contrast = "";
                    //int iTK_Type = -1;

                    string sTableName = sUid + "_" + iVerTrialkittingType.ToString().Trim().PadLeft(2, '0') + "_" + DateTime.Now.ToString("yyMMddHHmmss");
                    if (iVerTrialkittingType < 0)
                    {
                        sTableName = sUid + "_" + DateTime.Now.ToString("yyMMddHHmmss");
                    }

                    string sVerTrialkitting = "00-" + DateTime.Now.ToString("yyyyMMdd");

                    if (iID != 0)
                    {
                        sSQL = @"
select * from TK_List  WITH (nolock) where iID = {0}
";
                        sSQL = string.Format(sSQL, iID);
                        DataTable dtList = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtList == null || dtList.Rows.Count == 0)
                        {
                            throw new Exception("获得计算参数失败");
                        }

                        sProdGroup = dtList.Rows[0]["ProdGroup"].ToString().Trim();
                        sPlanner = dtList.Rows[0]["Planner"].ToString().Trim();
                        sVerTrialkitting = dtList.Rows[0]["sVerTrialkitting"].ToString().Trim();

                        //根据参数获得计算规则
                        sSQL = @"
select top 1 a.iID, sDataVersion as sVersion, a.Partid as sPartID,a.Qty, a.dtmPeriod as dDate,null as  [sProductGroup],null as CommonParts
	, a.iUpload_Type, a.sTKVersion_Contrast, a.iTK_Type, a.Remark, a.CreateUid, a.dtmCreate, a.sTKVersion
FROM      TK_Trialkit_Trial_Upload a WITH (nolock)
where a.sTKVersion = '{0}'
order by a.dtmPeriod,a.iID
";
                        sSQL = string.Format(sSQL, sVerTrialkitting);
                        DataTable dtTK = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        iUpload_Type = BaseFunction.ReturnInt(dtTK.Rows[0]["iUpload_Type"]);            //计算类型
                        sTKVersion_Contrast = dtTK.Rows[0]["sTKVersion_Contrast"].ToString().Trim();
                        //iTK_Type = BaseFunction.ReturnInt(dtTK.Rows[0]["iTK_Type"]);                    //暂时无用

                        // 0 按照页面调整计算 
                        // 1 上传数据完整计算
                        // 2 上传数据余量计算 （需要在TK_Trialkit_SupplyDemand扣去对比版本已经占用的数量）
                        // 3 展开一层计算     （在展开BOM时只展开一层，并去除自制件只考虑采购件 ）

                        sSQL = @"
if exists(select * from tempdb..sysobjects where id=object_id('tempdb..#TK_NetRequirement_Sum_{0}'))
	drop table #TK_NetRequirement_Sum_{0}
;
select  a.iID,a.sDataVersion as sVersion,a.Partid as sPartID,a.Qty,a.dtmPeriod as dDate,b.topprodgroup as sProductGroup,b.CommonParts 
into #TK_NetRequirement_Sum_{0}
from [dbo].[TK_Trialkit_Trial_Upload] a
	left join (select distinct toplevel,topprodgroup,CommonParts from TK_BOM WITH (nolock)) b on a.Partid = b.toplevel
where  isnull(a.Qty,0) > 0 and 1=1  and a.sTKVersion = '{1}'
order by a.dtmPeriod,a.iID,b.CommonParts,a.Partid
";
                        sSQL = string.Format(sSQL, sTableName, sVerTrialkitting);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                    else
                    {
                        //定时任务执行
                        sSQL = @"
if exists(select * from tempdb..sysobjects where id=object_id('tempdb..#TK_NetRequirement_Sum_{0}'))
	drop table #TK_NetRequirement_Sum_{0}
;
select a.iID,a.sVersion, a.sPartID, a.Qty, a.dDate,a.[sProductGroup],bom.CommonParts
into #TK_NetRequirement_Sum_{0}
from [dbo].[TK_NetRequirement_Sum] a  WITH (nolock)
	left join (select distinct toplevel,max(CommonParts) as CommonParts from [dbo].[TK_BOM] group by toplevel) bom on a.sPartID = bom.toplevel
	left join [dbo].[TK_Thread] b with (nolock) on a.sProductGroup = b.sProductGroup
where isnull(a.Qty,0) > 0 and 1=1 
order by a.dDate,bom.CommonParts,a.sPartID
";
                        sSQL = string.Format(sSQL, sTableName);

                        //调试时选择部分产品
                        //sSQL = sSQL.Replace("1=1", "1=1 and  a.sPartID in ('1009200-TT')");

                        if (iVerTrialkittingType != -1)
                        {
                            sSQL = sSQL.Replace("1=1", "1=1 and isnull(b.ThreadType,0) = '" + iVerTrialkittingType.ToString() + "'");
                        }
                        iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    ClsWriteLog.WriteLog(sPath, "计算", "\t将静态数据加载到临时表开始");

                    sSQL = @"
if exists(select * from tempdb..sysobjects where id=object_id('tempdb..#TK_Trialkit_SupplyDemand_{0}')) 
	drop table #TK_Trialkit_SupplyDemand_{0}
;
select * ,cast(0 as decimal(16,2)) as dUsed
into #TK_Trialkit_SupplyDemand_{0}
from [dbo].[TK_Trialkit_SupplyDemand]  WITH (nolock)
where isnull(Qty,0) <> 0
order by sPartID ,dDate
";
                    sSQL = string.Format(sSQL, sTableName);
                    iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = @"
if exists(select * from tempdb..sysobjects where id=object_id('tempdb..#TK_Trialkitting_Result_{0}')) 
	drop table #TK_Trialkitting_Result_{0}
;
CREATE TABLE #TK_Trialkitting_Result_{0}(
	[iID] [int] IDENTITY(1,1)  NOT NULL,
	[Guid] [uniqueidentifier]   NOT NULL CONSTRAINT [DF_TK_Trialkitting_Guid_{0}]  DEFAULT (newid()),
	[sTKVersion] [nvarchar](50)  COLLATE Latin1_General_BIN NOT NULL,
	[sTKVersionType] [nvarchar](5)  COLLATE Latin1_General_BIN NULL,
	[sDataVersion] [nvarchar](50)  COLLATE Latin1_General_BIN NULL,
	[CreateUid] [nvarchar](50)  COLLATE Latin1_General_BIN NULL,
	[dtmCreate] [datetime] NULL,
	[Remark] [nvarchar](500)  COLLATE Latin1_General_BIN NULL,
	[DataFrom] [int] NULL,
 CONSTRAINT [PK_TK_Trialkitting_Result_{0}] PRIMARY KEY CLUSTERED 
(
	[sTKVersion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
";
                    sSQL = string.Format(sSQL, sTableName);
                    iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                    sSQL = @"
if exists(select * from tempdb..sysobjects where id=object_id('tempdb..#TK_Trialkit_Net_Temp_{0}')) 
	drop table #TK_Trialkit_Net_Temp_{0}
;
CREATE TABLE #TK_Trialkit_Net_Temp_{0}(
	[sTKVersion] [nvarchar](50) NOT NULL,
	[sTKVersionType] [int] NULL,
	[PartID] [nvarchar](50) NOT NULL,
	[NetQty] [decimal](18, 2) NULL,
	[dDate] [datetime] NULL,
	[ProType] [nvarchar](50) NULL
)
";
                    sSQL = string.Format(sSQL, sTableName);
                    iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                    sSQL = @"
if exists(select * from tempdb..sysobjects where id=object_id('tempdb..#TK_Trialkitting_Results_{0}')) 
	drop table #TK_Trialkitting_Results_{0}
;
CREATE TABLE #TK_Trialkitting_Results_{0}(
	[iID] [int] IDENTITY(1,1) NOT NULL,
	[GUID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_TK_Trialkittings_GUID_{0}]  DEFAULT (newid()),
	[sTKVersion] [nvarchar](50)  COLLATE Latin1_General_BIN  NOT NULL,
	[sTKVersionType] [nvarchar](5)  COLLATE Latin1_General_BIN  NULL,
	[dDate] [date] NULL,
	[Planner] [nvarchar](50)  COLLATE Latin1_General_BIN  NULL,
	[ProdGroup] [nvarchar](50)  COLLATE Latin1_General_BIN  NULL,
	[cInvCode] [nvarchar](50)  COLLATE Latin1_General_BIN  NULL,
	[NetQty] [decimal](18, 2)  NULL,
	[Reorderpolicy] [nvarchar](50)  COLLATE Latin1_General_BIN  NULL,
	[DayWO] [int] NULL,
	[QtyCurr] [decimal](18, 2) NULL,
	[QtyWO] [decimal](18, 2) NULL,
	[Qty] [decimal](18, 2) NULL,
	[dtmQty] [date] NULL,
 CONSTRAINT [PK_TK_Trialkitting_Results_{0}] PRIMARY KEY CLUSTERED 
(
	[iID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
";
                    sSQL = string.Format(sSQL, sTableName);
                    iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = @"
if exists(select * from tempdb..sysobjects where id=object_id('tempdb..#TK_Trialkit_Calculate_{0}')) 
	drop table #TK_Trialkit_Calculate_{0}
;
CREATE TABLE #TK_Trialkit_Calculate_{0}(
	[iID] [int] IDENTITY(1,1) NOT NULL,
	[sTKVersion] [nvarchar](50)  COLLATE Latin1_General_BIN  NULL,
	[sTKVersionType] [nvarchar](5)  COLLATE Latin1_General_BIN  NULL,
	[sDataVersion] [nvarchar](50)  COLLATE Latin1_General_BIN  NULL,
	[iID_NetRequirement_Sum] [int]  NULL,
	[toplevel] [nvarchar](100)  COLLATE Latin1_General_BIN NULL,
	[Qty_toplevel] [decimal](18, 2) NULL,
	[dDate_toplevel] [date] NULL,
	[sProductGroup] [nvarchar](100) COLLATE Latin1_General_BIN  NULL,
	[child] [nvarchar](100) COLLATE Latin1_General_BIN  NULL,
	[childCycle] [int] NULL,
	[childsCycle] [int] NULL,
	[Qty_bom] [decimal](18, 2) NULL,
	[Cumqty_bom] [decimal](18, 2) NULL,
	[childsm] [nvarchar](100)  COLLATE Latin1_General_BIN NULL,
	[depth]  [int] NULL,
	[qtyChild] [decimal](18, 6) NULL,
	[dtmStart] [date] NULL,
	[dtmEnd] [date] NULL,
	[CreateUid] [nvarchar](50)  COLLATE Latin1_General_BIN NULL,
	[dtmCreate] [datetime] NULL,
 CONSTRAINT [PK_TK_Trialkit_Calculate_{0}] PRIMARY KEY CLUSTERED 
(
	[iID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
";
                    sSQL = string.Format(sSQL, sTableName);
                    iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = @"
if exists(select * from tempdb..sysobjects where id=object_id('tempdb..#TK_BOM_{0}')) 
	drop table #TK_BOM_{0}
;
CREATE TABLE #TK_BOM_{0}(
	[iID] [int] IDENTITY(1,1) NOT NULL,
	[depth] [nvarchar](10) COLLATE Latin1_General_BIN  NULL,
	[toplevel] [nvarchar](30)  COLLATE Latin1_General_BIN NOT NULL,
	[parent] [nvarchar](30)  COLLATE Latin1_General_BIN NOT NULL,
	[child] [nvarchar](30)  COLLATE Latin1_General_BIN NOT NULL,
	[Qty] [float] NULL,
	[cumqty] [float] NULL,
	[childsm] [nvarchar](15)  COLLATE Latin1_General_BIN NULL,
	[topprodgroup] [nvarchar](8)  COLLATE Latin1_General_BIN NULL,
	[CommonParts] [int] NULL,
	[Exclude] [bit] NOT NULL CONSTRAINT [DF_TK_BOM_Exclude_{0}]  DEFAULT ((0)),
	[childCycle] [int] NULL,
	[childsCycle] [int] NULL,
	[depths] [int] NULL,
	[sDataVersion] [nvarchar](50)  COLLATE Latin1_General_BIN NULL,
	[bDel] [bit] NULL CONSTRAINT [DF_TK_BOM_bDel_{0}]  DEFAULT ((0)),
 CONSTRAINT [PK_TK_BOM_{0}] PRIMARY KEY CLUSTERED 
(
	[iID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
";
                    sSQL = string.Format(sSQL, sTableName);
                    iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    ClsWriteLog.WriteLog(sPath, "计算", "\t将静态数据加载到临时表成功");

                    sSQL = @"
select iID,sVersion, sPartID, Qty, dDate,[sProductGroup]
from #TK_NetRequirement_Sum_{0}
where sPartID not in (select toplevel from TK_BOM with (nolock))
order by dDate,CommonParts,sPartID
";
                    sSQL = string.Format(sSQL, sTableName);
                    DataTable dtNoBom = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtNoBom != null && dtNoBom.Rows.Count > 0)
                    {
                        for (int iii = 0; iii < dtNoBom.Rows.Count; iii++)
                        {
                            ClsWriteLog.WriteLog(sPath, "计算", "\tBOM错误：" + dtNoBom.Rows[iii]["sPartID"].ToString().Trim());
                        }
                    }

                    if (iUpload_Type == 3)
                    {
                        //只展开一层的可以计算MRP件
                        sSQL = @"
select iID,sVersion, sPartID, Qty, dDate,[sProductGroup]
from #TK_NetRequirement_Sum_{0}
order by dDate,iID,CommonParts,sPartID
";
                        sSQL = string.Format(sSQL, sTableName);
                        DataTable dtNet = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtNet == null || dtNet.Rows.Count == 0)
                        {
                            throw new Exception("没有取到需求数据");
                        }

                        string stoplevel = "";
                        #region 供需计算（根据当前需求计算缺料情况）

                        ClsWriteLog.WriteLog(sPath, "计算", "\t供需计算开始,累计行数：" + dtNet.Rows.Count.ToString());
                        for (int i = 0; i < dtNet.Rows.Count; i++)
                        {
                            CheckStatus(tran, iID);

                            string sPartID = dtNet.Rows[i]["sPartID"].ToString().Trim();
                            decimal dQty = BaseFunction.ReturnDecimal(dtNet.Rows[i]["Qty"]);
                            DateTime dDate = BaseFunction.ReturnDate(dtNet.Rows[i]["dDate"]);
                            long lID = BaseFunction.ReturnLong(dtNet.Rows[i]["iID"]);

                            Model.TK_Trialkit_Net_Temp modeNet = new Model.TK_Trialkit_Net_Temp();
                            modeNet.PartID = sPartID;
                            modeNet.NetQty = dQty;
                            modeNet.dDate = dDate;
                            modeNet.sTKVersion = sVerTrialkitting;
                            modeNet.ProType = "t";
                            modeNet.sTKVersionType = iVerTrialkittingType;
                            DAL.TK_Trialkit_Net_Temp dalNet = new DAL.TK_Trialkit_Net_Temp();
                            sSQL = dalNet.Add(modeNet);
                            sSQL = sSQL.Replace("TK_Trialkit_Net_Temp", "#TK_Trialkit_Net_Temp_{0}");
                            sSQL = string.Format(sSQL, sTableName);
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            try
                            {
                                ClsWriteLog.WriteLog(sPath, "计算", "\t供需计算\t【" + sPartID + "】 开始 行号：" + (i + 1).ToString());

                                #region  母件需求量扣去可用量，然后展开一层BOM

                                sSQL = @"
select distinct toplevel from TK_BOM TK_BOM  WITH (nolock) where parent = '{0}'
";
                                sSQL = string.Format(sSQL, sPartID);
                                DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                if (dtTemp != null && dtTemp.Rows.Count > 0)
                                {
                                    stoplevel = dtTemp.Rows[0]["toplevel"].ToString().Trim();

                                    sSQL = @"
SELECT   depth, toplevel, parent, child, qty as Qty, cumqty, childsm, topprodgroup, CommonParts, Exclude, childCycle	,childsCycle, depths, sDataVersion
    ,cast(null as decimal(16,6)) as dQty,cast(null as decimal(16,6)) as dQtyNow,cast(null as date) as dtmStart ,cast(null as date) as dtmEnd,cast(null as int) as iID
FROM      TK_BOM  WITH (nolock)
where parent = N'{1}' and toplevel = '{2}'
    and  childsm not in ('MANUFACTURED')
ORDER BY toplevel, depth, parent
";
                                    sSQL = string.Format(sSQL, sTableName, sPartID, stoplevel);
                                    dtBom = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                                    decimal dQtyUse = 0;     //可用量
                                    sSQL = @"
select sPartID,sum(Qty) as Qty 
from #TK_Trialkit_SupplyDemand_{0}
where sPartID = '{1}'
group by sPartID 
";
                                    sSQL = string.Format(sSQL, sTableName, sPartID);
                                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                    //扣去可用量获得需求
                                    if (dt != null && dt.Rows.Count > 0)
                                    {
                                        dQtyUse = BaseFunction.ReturnDecimal(dt.Rows[0]["Qty"]);

                                        //可用量超出需求
                                        if (dQtyUse > dQty)
                                        {
                                            sSQL = @"
insert into #TK_Trialkit_SupplyDemand_{0}( sType, sPartID, Qty, dDate)
values('Used','{1}',{2},'{3}')
";
                                            sSQL = string.Format(sSQL, sTableName, sPartID, -1 * dQty, dDate);
                                            iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                            dQty = 0;
                                        }
                                        else
                                        {
                                            //可用量小于需求数量，扣去可用量继续往下展BOM
                                            sSQL = @"
insert into #TK_Trialkit_SupplyDemand_{0}( sType, sPartID, Qty, dDate)
values('Used','{1}',{2},'{3}')
";
                                            sSQL = string.Format(sSQL, sTableName, sPartID, -1 * dQtyUse, dDate);
                                            iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                            dQty = dQty - dQtyUse;
                                        }
                                    }
                                    #endregion

                                    if (dQty <= 0)
                                        continue;


                                    //dr[0]["dQtyNow"] = dQty;        //本次下单数量


                                    InitBomN(tran, lID, sPartID, dQty, dDate, sTableName, sVerTrialkitting, iVerTrialkittingType);

                                    //将供需数据写入临时表
                                    for (int ii = 0; ii < dtBom.Rows.Count; ii++)
                                    {
                                        Model.TK_Trialkit_Calculate modCal = new Model.TK_Trialkit_Calculate();
                                        modCal.sTKVersion = sVerTrialkitting;
                                        modCal.sTKVersionType = iVerTrialkittingType.ToString();
                                        modCal.sDataVersion = dtNet.Rows[i]["sVersion"].ToString().Trim();
                                        modCal.iID_NetRequirement_Sum = BaseFunction.ReturnLong(dtNet.Rows[i]["iID"]);
                                        modCal.toplevel = sPartID;
                                        modCal.Qty_toplevel = BaseFunction.ReturnDecimal(dtNet.Rows[i]["Qty"]);
                                        modCal.dDate_toplevel = BaseFunction.ReturnDate(dtBom.Rows[ii]["dtmStart"]);
                                        modCal.sProductGroup = dtNet.Rows[i]["sProductGroup"].ToString().Trim();
                                        modCal.child = dtBom.Rows[ii]["child"].ToString().Trim();
                                        modCal.childCycle = BaseFunction.ReturnInt(dtBom.Rows[ii]["childCycle"]);
                                        modCal.childsCycle = BaseFunction.ReturnInt(dtBom.Rows[ii]["childsCycle"]);
                                        modCal.Qty_bom = BaseFunction.ReturnDecimal(dtBom.Rows[ii]["Qty"]);
                                        modCal.Cumqty_bom = BaseFunction.ReturnDecimal(dtBom.Rows[ii]["Cumqty"]);
                                        modCal.childsm = dtBom.Rows[ii]["childsm"].ToString().Trim();
                                        modCal.depth = BaseFunction.ReturnInt(dtBom.Rows[ii]["depth"]);
                                        modCal.qtyChild = BaseFunction.ReturnDecimal(dtBom.Rows[ii]["dQtyNow"]);
                                        modCal.dtmStart = BaseFunction.ReturnDate(dtBom.Rows[ii]["dtmStart"]);
                                        modCal.dtmEnd = BaseFunction.ReturnDate(dtBom.Rows[ii]["dtmEnd"]);
                                        modCal.CreateUid = sUid;
                                        modCal.dtmCreate = DateTime.Now;

                                        DAL.TK_Trialkit_Calculate dalCal = new DAL.TK_Trialkit_Calculate();
                                        sSQL = dalCal.Add(modCal);
                                        sSQL = sSQL.Replace("TK_Trialkit_Calculate", "#TK_Trialkit_Calculate_{0}");
                                        sSQL = string.Format(sSQL, sTableName);

                                        iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                                    }
                                }
                                ClsWriteLog.WriteLog(sPath, "计算", "\t供需计算\t【" + sPartID + "】 成功");
                            }
                            catch (Exception ee)
                            {
                                ClsWriteLog.WriteLog(sPath, "计算", "\t供需计算\t【" + sPartID + "】 失败：" + ee.Message);
                            }
                        }

                        sSQL = @"
                        select * from #TK_Trialkit_Calculate_{0}
                        ";
                        sSQL = string.Format(sSQL, sTableName);
                        DataTable dtTemp_temp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        #endregion


                        #region 齐套计算
                        ClsWriteLog.WriteLog(sPath, "计算", "\t齐套计算开始");

                        sSQL = @"
if exists(select * from tempdb..sysobjects where id=object_id('tempdb..#TK_Trialkit_SupplyDemand_{0}')) 
	drop table #TK_Trialkit_SupplyDemand_{0}

select IDENTITY(INT,1,1) AS iID,sPartID,sum(Qty) as Qty,dDate  ,cast(0 as decimal(16,2)) as iUseQty
into #TK_Trialkit_SupplyDemand_{0}
from [dbo].[TK_Trialkit_SupplyDemand]  WITH (nolock)
where isnull(Qty,0) <> 0
    and sPartID in (select child from TK_BOM)
group by sPartID,dDate
order by sPartID ,dDate
";
                        sSQL = string.Format(sSQL, sTableName);
                        iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        Model.TK_Trialkitting_Result modResult = new Model.TK_Trialkitting_Result();
                        modResult.sTKVersion = sVerTrialkitting;
                        modResult.sTKVersionType = iVerTrialkittingType.ToString();
                        modResult.sDataVersion = dtNet.Rows[0]["sVersion"].ToString().Trim();
                        modResult.CreateUid = sUid;
                        modResult.dtmCreate = DateTime.Now;
                        modResult.Guid = Guid.NewGuid();
                        DAL.TK_Trialkitting_Result dal = new DAL.TK_Trialkitting_Result();
                        sSQL = dal.Add(modResult);
                        sSQL = sSQL.Replace("TK_Trialkitting_Result", "#TK_Trialkitting_Result_{0}");
                        sSQL = string.Format(sSQL, sTableName);
                        iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        ClsWriteLog.WriteLog(sPath, "计算", "\t齐套计算\t循环计算开始 累计行数:" + dtNet.Rows.Count.ToString());
                        for (int i = 0; i < dtNet.Rows.Count; i++)
                        {
                            CheckStatus(tran, iID);

                            string sPartID = dtNet.Rows[i]["sPartID"].ToString().Trim();
                            decimal dQty = BaseFunction.ReturnDecimal(dtNet.Rows[i]["Qty"]);
                            DateTime dDate = BaseFunction.ReturnDate(dtNet.Rows[i]["dDate"]);
                            long lID = BaseFunction.ReturnLong(dtNet.Rows[i]["iID"]);

                            try
                            {
                                ClsWriteLog.WriteLog(sPath, "计算", "\t齐套计算\t【" + sPartID + "】 开始  行号：" + (i + 1).ToString());
                                #region 根据产品存量及工单判断产品齐套

                                sSQL = @"
select *,Qty - isnull(iUseQty,0) as iQtyCanUse
from #TK_Trialkit_SupplyDemand_{0}
where 1=1
    and isnull(Qty,0) > isnull(iUseQty,0)
    and sPartID = '{1}' 
";
                                sSQL = string.Format(sSQL, sTableName, sPartID);
                                DataTable dtParentSum = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                if (dtParentSum != null && dtParentSum.Rows.Count > 0)
                                {
                                    for (int ii = 0; ii < dtParentSum.Rows.Count; ii++)
                                    {
                                        decimal dQtyParentSum = BaseFunction.ReturnDecimal(dtParentSum.Rows[ii]["iQtyCanUse"]);

                                        if (dQty > 0)
                                        {
                                            //decimal dQtyParent = BaseFunction.ReturnDecimal(dQtyParentSum);
                                            decimal dNow = 0;
                                            //登记入齐套结果临时表
                                            Model.TK_Trialkitting_Results modResults = new Model.TK_Trialkitting_Results();
                                            modResults.GUID = modResult.Guid;
                                            modResults.sTKVersion = modResult.sTKVersion;
                                            modResults.sTKVersionType = modResult.sTKVersionType;
                                            modResults.dDate = dDate;
                                            modResults.Planner = sPlanner;
                                            modResults.ProdGroup = dtNet.Rows[i]["sProductGroup"].ToString().Trim();
                                            modResults.cInvCode = sPartID;
                                            modResults.NetQty = dQty;
                                            modResults.Reorderpolicy = "MPS";

                                            if (dQtyParentSum >= dQty)
                                            {
                                                dNow = dQty;
                                                modResults.Qty = 0;      //Test 20181121 : modResults.Qty = dQty;
                                                dQty = 0;
                                            }
                                            else
                                            {
                                                dNow = dQtyParentSum;
                                                modResults.Qty = 0;
                                                dQty = dQty - dQtyParentSum;
                                            }
                                            modResults.dtmQty = dDate;
                                            DAL.TK_Trialkitting_Results dalResults = new DAL.TK_Trialkitting_Results();
                                            sSQL = dalResults.Add(modResults);
                                            sSQL = sSQL.Replace("TK_Trialkitting_Results", "#TK_Trialkitting_Results_{0}");
                                            sSQL = string.Format(sSQL, sTableName);
                                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                            sSQL = @"
update  #TK_Trialkit_SupplyDemand_{0} set iUseQty = isnull(iUseQty,0) + isnull({1},0)
where iID = {2}
";
                                            sSQL = string.Format(sSQL, sTableName, dNow, BaseFunction.ReturnLong(dtParentSum.Rows[ii]["iID"]));
                                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                            // test - 
                                            sSQL = @"
select * from #TK_Trialkit_SupplyDemand_{0} where sPartID = '{1}'
";
                                            sSQL = string.Format(sSQL, sTableName, sPartID);
                                            DataTable dttttt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                        }
                                    }
                                }
                                #endregion

                                if (dQty <= 0)
                                    continue;

                                sSQL = @"
select count(1) as iCou
from TK_BOM  WITH (nolock)
where isnull(qty,0) <> 0 and toplevel = '{0}' and parent = '{1}' and child <> '{1}' and  childsm not in ('MANUFACTURED')
";
                                sSQL = string.Format(sSQL, stoplevel, sPartID);
                                int iBomCout = BaseFunction.ReturnInt(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]); // BOM子件种类数

                                bool bConJS = true; //是否继续计算 ，在While循环中符合不计算时用于跳出
                                while (dQty > 0 && bConJS)
                                {
                                    //bConJS = false;
                                    //获得当前过程齐套的数量及日期（最小数量及最大日期，木桶原理）
                                    sSQL = @"
select MIN(bomT) AS bomT,MAX(dDate) as dtm,count(1) as iCou
from
(
    select b.*,b.Qty - isnull(b.iUseQty,0) as iUseCan,bom.BomQTY,FLOOR(((b.Qty - isnull(b.iUseQty,0)) / bom.BomQTY)) as bomT
    from 
    (
        SELECT  sPartID as cInvCode, min(dDate) as dtm
        FROM     #TK_Trialkit_SupplyDemand_{0}
        where isnull(Qty,0) - isnull(iUseQty,0) > 0
        group by sPartID
    ) a  left join #TK_Trialkit_SupplyDemand_{0} b on a.cInvCode = b.sPartID and a.dtm = b.dDate
    inner join 
    (
        select parent as InvCode,child as cInvCode,qty as BomQTY
        from TK_BOM with (nolock)
        where parent = '{1}' and child <>  '{1}' and isnull(qty,0) <> 0 and  toplevel = '{2}'
    ) bom on b.sPartID = bom.cInvCode
) QT
";
                                    sSQL = string.Format(sSQL, sTableName, sPartID, stoplevel);
                                    DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                    if (iBomCout != BaseFunction.ReturnInt(dtTemp.Rows[0]["iCou"]))
                                        break;

                                    decimal dQtybomT = BaseFunction.ReturnDecimal(dtTemp.Rows[0]["bomT"]);
                                    DateTime dtm = BaseFunction.ReturnDate(dtTemp.Rows[0]["dtm"]);

                                    if (dQtybomT <= 0)
                                        break;

                                    //当齐套数据超出订单需求，只需要满足订单需求即可
                                    if (dQtybomT > dQty)
                                    {
                                        dQtybomT = dQty;
                                    }

                                    //将齐套耗用数据记录进_齐套计算临时表，避免下次计算重复使用
                                    sSQL = @"
update a set a.iUseQty = isnull(a.iUseQty,0) + b.BomQTY * {2}
from #TK_Trialkit_SupplyDemand_{0} a 
    inner join 
    (
        select b.iID,bom.BomQTY
        from 
        (
            SELECT  sPartID as cInvCode, min(dDate) as dtm
            FROM    #TK_Trialkit_SupplyDemand_{0}
            where isnull(Qty,0) - isnull(iUseQty,0) > 0
            group by sPartID
        ) a left join #TK_Trialkit_SupplyDemand_{0} b on a.cInvCode = b.sPartID and a.dtm = b.dDate
            inner join 
            (
                select parent as InvCode,child as cInvCode,qty as BomQTY
                from TK_BOM with (nolock)
                where parent = '{1}' and child <>  '{1}'
            ) bom on b.sPartID = bom.cInvCode
    ) b on a.iID = b.iID
                              
";
                                    sSQL = string.Format(sSQL, sTableName, sPartID, dQtybomT);
                                    iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                    sSQL = @"
if exists(select * from #TK_Trialkit_SupplyDemand_{0} where sPartID = '{1}' and dDate = '{3}')
    update #TK_Trialkit_SupplyDemand_{0} set Qty = isnull(Qty,0) + {2}  where  sPartID = '{1}' and dDate = '{3}'
else
    insert into #TK_Trialkit_SupplyDemand_{0}(sPartID, Qty, dDate)
    values('{1}',{2},'{3}')
";
                                    sSQL = string.Format(sSQL, sTableName, sPartID, dQtybomT, dtm);
                                    iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                    //Test - 
                                    sSQL = @"
select * from #TK_Trialkit_SupplyDemand_{0} where sPartID = '{1}'
                                    ";
                                    sSQL = string.Format(sSQL, sTableName, sPartID);
                                    DataTable dtttt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                                    //登记入齐套结果临时表
                                    Model.TK_Trialkitting_Results modResults = new Model.TK_Trialkitting_Results();
                                    modResults.GUID = modResult.Guid;
                                    modResults.sTKVersion = modResult.sTKVersion;
                                    modResults.sTKVersionType = modResult.sTKVersionType;
                                    modResults.dDate = dtm;
                                    modResults.Planner = sPlanner;
                                    modResults.ProdGroup = dtNet.Rows[i]["sProductGroup"].ToString().Trim();
                                    modResults.cInvCode = sPartID;
                                    modResults.NetQty = dQty;
                                    if (stoplevel == sPartID)
                                        modResults.Reorderpolicy = "MPS";
                                    else
                                        modResults.Reorderpolicy = "MRP";

                                    modResults.Qty = dQtybomT;
                                    modResults.dtmQty = dtm;
                                    DAL.TK_Trialkitting_Results dalResults = new DAL.TK_Trialkitting_Results();
                                    sSQL = dalResults.Add(modResults);
                                    sSQL = sSQL.Replace("TK_Trialkitting_Results", "#TK_Trialkitting_Results_{0}");
                                    sSQL = string.Format(sSQL, sTableName);
                                    iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                    dQty = dQty - dQtybomT;


                                    ClsWriteLog.WriteLog(sPath, "计算", "\t齐套计算\t【" + sPartID + "】【" + sPartID + "】 成功");
                                }
                                ClsWriteLog.WriteLog(sPath, "计算", "\t齐套计算\t【" + sPartID + "】成功");
                            }
                            catch (Exception ee)
                            {
                                ClsWriteLog.WriteLog(sPath, "计算", "\t齐套计算\t【" + sPartID + "】失败：" + ee.Message);
                            }
                            ClsWriteLog.WriteLog(sPath, "计算", "\t齐套计算\t循环计算成功");
                        }


                        ClsWriteLog.WriteLog(sPath, "计算", "\t齐套计算成功");
                        #endregion

                    }
                    else
                    {
                        //必须是toplevel才能计算

                        sSQL = @"
select iID,sVersion, sPartID, Qty, dDate,[sProductGroup]
from #TK_NetRequirement_Sum_{0}
where sPartID in (select toplevel from TK_BOM with (nolock))
order by dDate,iID,CommonParts,sPartID
";
                        sSQL = string.Format(sSQL, sTableName);
                        DataTable dtNet = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtNet == null || dtNet.Rows.Count == 0)
                        {
                            throw new Exception("没有取到需求数据");
                        }

                        #region 供需计算（根据当前需求计算缺料情况）

                        ClsWriteLog.WriteLog(sPath, "计算", "\t供需计算开始,累计行数：" + dtNet.Rows.Count.ToString());
                        for (int i = 0; i < dtNet.Rows.Count; i++)
                        {
                            CheckStatus(tran, iID);

                            string sPartID = dtNet.Rows[i]["sPartID"].ToString().Trim();
                            decimal dQty = BaseFunction.ReturnDecimal(dtNet.Rows[i]["Qty"]);
                            DateTime dDate = BaseFunction.ReturnDate(dtNet.Rows[i]["dDate"]);
                            long lID = BaseFunction.ReturnLong(dtNet.Rows[i]["iID"]);

                            Model.TK_Trialkit_Net_Temp modeNet = new Model.TK_Trialkit_Net_Temp();
                            modeNet.PartID = sPartID;
                            modeNet.NetQty = dQty;
                            modeNet.dDate = dDate;
                            modeNet.sTKVersion = sVerTrialkitting;
                            modeNet.sTKVersionType = iVerTrialkittingType;
                            modeNet.ProType = "t";
                            DAL.TK_Trialkit_Net_Temp dalNet = new DAL.TK_Trialkit_Net_Temp();
                            sSQL = dalNet.Add(modeNet);
                            sSQL = sSQL.Replace("TK_Trialkit_Net_Temp", "#TK_Trialkit_Net_Temp_{0}");
                            sSQL = string.Format(sSQL, sTableName);
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            try
                            {
                                ClsWriteLog.WriteLog(sPath, "计算", "\t供需计算\t【" + sPartID + "】 开始 行号：" + (i + 1).ToString());

                                sSQL = @"
SELECT   depth, toplevel, parent, child, qty as Qty, cumqty, childsm, topprodgroup, CommonParts, Exclude, childCycle	,childsCycle, depths, sDataVersion
    ,cast(null as decimal(16,6)) as dQty,cast(null as decimal(16,6)) as dQtyNow,cast(null as date) as dtmStart ,cast(null as date) as dtmEnd,cast(null as int) as iID
FROM      TK_BOM  WITH (nolock)
where toplevel = N'{1}'
ORDER BY toplevel, depth, parent
                        ";
                                sSQL = string.Format(sSQL, sTableName, sPartID);
                                dtBom = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];





                                string sTemp = "[toplevel] = '" + sPartID + "' and [parent] = '" + sPartID + "' and [child] = '" + sPartID + "' ";

                                DataRow[] dr = dtBom.Select(sTemp);
                                if (dr.Length == 0)
                                {
                                    ClsWriteLog.WriteLog(sPath, "计算", "\t供需计算\t【" + sPartID + "】 获得BOM失败 行号：" + (i + 1).ToString());
                                    //throw new Exception("获得BOM失败");
                                    continue;
                                }

                                dr[0]["dQty"] = dQty;
                                dr[0]["dtmStart"] = dDate.AddDays(-1 * BaseFunction.ReturnInt(dr[0]["childCycle"]));
                                dr[0]["dtmEnd"] = dDate;
                                dr[0]["iID"] = lID;

                                #region  母件需求量扣去可用量，然后递归BOM

                                decimal dQtyUse = 0;     //可用量
                                sSQL = @"
select sPartID,sum(Qty) as Qty 
from #TK_Trialkit_SupplyDemand_{0}
where sPartID = '{1}'
group by sPartID 
";
                                sSQL = string.Format(sSQL, sTableName, sPartID);
                                DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                //扣去可用量获得需求
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    dQtyUse = BaseFunction.ReturnDecimal(dt.Rows[0]["Qty"]);

                                    //可用量超出需求
                                    if (dQtyUse > dQty)
                                    {
                                        sSQL = @"
insert into #TK_Trialkit_SupplyDemand_{0}( sType, sPartID, Qty, dDate)
values('Used','{1}',{2},'{3}')
";
                                        sSQL = string.Format(sSQL, sTableName, sPartID, -1 * dQty, dDate);
                                        iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                        dQty = 0;
                                    }
                                    else
                                    {
                                        //可用量小于需求数量，扣去可用量继续往下展BOM
                                        sSQL = @"
insert into #TK_Trialkit_SupplyDemand_{0}( sType, sPartID, Qty, dDate)
values('Used','{1}',{2},'{3}')
";
                                        sSQL = string.Format(sSQL, sTableName, sPartID, -1 * dQtyUse, dDate);
                                        iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                        dQty = dQty - dQtyUse;
                                    }
                                }
                                #endregion

                                if (dQty <= 0)
                                    continue;

                                //                                //Test - 
                                //                                sSQL = @"
                                //select * from #TK_Trialkit_SupplyDemand_{0} where sPartID = '{1}'
                                //                                    ";
                                //                                sSQL = string.Format(sSQL, sTableName, sPartID);
                                //                                DataTable dtttt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                                dr[0]["dQtyNow"] = dQty;        //本次下单数量

                                if (dQty > 0)
                                {
                                    InitBomN(tran, lID, sPartID, sPartID, dQty, BaseFunction.ReturnDate(dr[0]["dtmStart"]), sTableName, sVerTrialkitting, iVerTrialkittingType);

                                    //将供需数据写入临时表
                                    for (int ii = 0; ii < dtBom.Rows.Count; ii++)
                                    {
                                        Model.TK_Trialkit_Calculate modCal = new Model.TK_Trialkit_Calculate();
                                        modCal.sTKVersion = sVerTrialkitting;
                                        modCal.sTKVersionType = iVerTrialkittingType.ToString();
                                        modCal.sDataVersion = dtNet.Rows[i]["sVersion"].ToString().Trim();
                                        modCal.iID_NetRequirement_Sum = BaseFunction.ReturnLong(dtNet.Rows[i]["iID"]);
                                        modCal.toplevel = sPartID;
                                        modCal.Qty_toplevel = BaseFunction.ReturnDecimal(dtNet.Rows[i]["Qty"]);
                                        modCal.dDate_toplevel = BaseFunction.ReturnDate(dtBom.Rows[ii]["dtmStart"]);
                                        modCal.sProductGroup = dtNet.Rows[i]["sProductGroup"].ToString().Trim();
                                        modCal.child = dtBom.Rows[ii]["child"].ToString().Trim();
                                        modCal.childCycle = BaseFunction.ReturnInt(dtBom.Rows[ii]["childCycle"]);
                                        modCal.childsCycle = BaseFunction.ReturnInt(dtBom.Rows[ii]["childsCycle"]);
                                        modCal.Qty_bom = BaseFunction.ReturnDecimal(dtBom.Rows[ii]["Qty"]);
                                        modCal.Cumqty_bom = BaseFunction.ReturnDecimal(dtBom.Rows[ii]["Cumqty"]);
                                        modCal.childsm = dtBom.Rows[ii]["childsm"].ToString().Trim();
                                        modCal.depth = BaseFunction.ReturnInt(dtBom.Rows[ii]["depth"]);
                                        modCal.qtyChild = BaseFunction.ReturnDecimal(dtBom.Rows[ii]["dQtyNow"]);
                                        modCal.dtmStart = BaseFunction.ReturnDate(dtBom.Rows[ii]["dtmStart"]);
                                        modCal.dtmEnd = BaseFunction.ReturnDate(dtBom.Rows[ii]["dtmEnd"]);
                                        modCal.CreateUid = sUid;
                                        modCal.dtmCreate = DateTime.Now;

                                        DAL.TK_Trialkit_Calculate dalCal = new DAL.TK_Trialkit_Calculate();
                                        sSQL = dalCal.Add(modCal);
                                        sSQL = sSQL.Replace("TK_Trialkit_Calculate", "#TK_Trialkit_Calculate_{0}");
                                        sSQL = string.Format(sSQL, sTableName);

                                        iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                                    }
                                }
                                ClsWriteLog.WriteLog(sPath, "计算", "\t供需计算\t【" + sPartID + "】 成功");
                            }
                            catch (Exception ee)
                            {
                                ClsWriteLog.WriteLog(sPath, "计算", "\t供需计算\t【" + sPartID + "】 失败：" + ee.Message);
                            }
                        }

                        //                    sSQL = @"
                        //select * from #TK_Trialkit_Calculate_{0}
                        //";
                        //                    sSQL = string.Format(sSQL, sTableName);
                        //                    DataTable dtTemp_temp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        #endregion

                        #region 理论展开BOM(用于PAD需求数量)

                        //定时任务
                        if (iVerTrialkittingType >= 0)
                        {
                            sSQL = @"

if exists(select * from tempdb..sysobjects where id=object_id('tempdb..#TK_Trialkit_TheoreticalCalculate_{0}')) 
    drop table #TK_Trialkit_TheoreticalCalculate_{0}

CREATE TABLE #TK_Trialkit_TheoreticalCalculate_{0}(
    [iID] [int] IDENTITY(1,1) NOT NULL,
    [GUID] [uniqueidentifier] NULL CONSTRAINT [DF_TheoreticalCalculate_{0}_GUID]  DEFAULT (newid()),
    [sTKVersion] [nvarchar](50) NULL,
    [sTKVersionType] [nvarchar](50) NULL,
    [sDataVersion] [nvarchar](50) NULL,
    [iID_NetRequirement_Sum] [int] NULL,
    [toplevel] [nvarchar](100) NULL,
    [Qty_toplevel] [decimal](18, 2) NULL,
    [dDate_toplevel] [date] NULL,
    [sProductGroup] [nvarchar](100) NULL,
    [child] [nvarchar](100) NULL,
    [childCycle] [int] NULL,
    [childsCycle] [int] NULL,
    [Qty_bom] [decimal](18, 2) NULL,
    [Cumqty_bom] [decimal](18, 2) NULL,
    [childsm] [nvarchar](100) NULL,
    [depth] [int] NULL,
    [qtyChild] [decimal](18, 6) NULL,
    [dtmStart] [date] NULL,
    [dtmEnd] [date] NULL,
    [CreateUid] [nvarchar](50) NULL,
    [dtmCreate] [datetime] NULL,
    CONSTRAINT [PK_TK_Trialkit_TheoreticalCalculate_{0}] PRIMARY KEY CLUSTERED 
(
    [iID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

insert into #TK_Trialkit_TheoreticalCalculate_{0}(sTKVersion, sTKVersionType,sDataVersion, iID_NetRequirement_Sum, toplevel, Qty_toplevel, dDate_toplevel, 
                sProductGroup, child, childCycle, childsCycle, Qty_bom, Cumqty_bom, childsm, depth, qtyChild
                , dtmStart, dtmEnd, CreateUid, dtmCreate)
select '{1}',{3},a.sVersion,a.iID,a.sPartID,a.fOpenQTY,a.dtmRequirement
    ,a.sProductGroup,bom.child,bom.childCycle,bom.childsCycle,bom.qty as Qty,bom.cumqty,bom.childsm,bom.depth,bom.qty * a.fOpenQTY 
    ,DATEADD(day,-1 * childsCycle,a.dtmRequirement)
    ,case when bom.toplevel = bom.parent and bom.parent = bom.child then a.dtmRequirement else DATEADD(day,-1 * childsCycle + isnull(bom.childCycle,0),a.dtmRequirement) end 
    ,'{2}',GETDATE()
from [dbo].[TK_NetRequirement] a	
    inner join TK_BOM bom on a.sPartID = bom.toplevel
	left join [dbo].[TK_Thread] b on a.sProductGroup = b.[sProductGroup]
where isnull(b.[ThreadType],0) = {3}
                    ";
                            sSQL = string.Format(sSQL, sTableName, sVerTrialkitting, sUid, iVerTrialkittingType);
                            iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        else
                        {
                            sSQL = @"

if exists(select * from tempdb..sysobjects where id=object_id('tempdb..#TK_Trialkit_TheoreticalCalculate_{0}')) 
    drop table #TK_Trialkit_TheoreticalCalculate_{0}

CREATE TABLE #TK_Trialkit_TheoreticalCalculate_{0}(
    [iID] [int] IDENTITY(1,1) NOT NULL,
    [GUID] [uniqueidentifier] NULL CONSTRAINT [DF_TheoreticalCalculate_{0}_GUID]  DEFAULT (newid()),
    [sTKVersion] [nvarchar](50) NULL,
    [sTKVersionType] [nvarchar](50) NULL,
    [sDataVersion] [nvarchar](50) NULL,
    [iID_NetRequirement_Sum] [int] NULL,
    [toplevel] [nvarchar](100) NULL,
    [Qty_toplevel] [decimal](18, 2) NULL,
    [dDate_toplevel] [date] NULL,
    [sProductGroup] [nvarchar](100) NULL,
    [child] [nvarchar](100) NULL,
    [childCycle] [int] NULL,
    [childsCycle] [int] NULL,
    [Qty_bom] [decimal](18, 2) NULL,
    [Cumqty_bom] [decimal](18, 2) NULL,
    [childsm] [nvarchar](100) NULL,
    [depth] [int] NULL,
    [qtyChild] [decimal](18, 6) NULL,
    [dtmStart] [date] NULL,
    [dtmEnd] [date] NULL,
    [CreateUid] [nvarchar](50) NULL,
    [dtmCreate] [datetime] NULL,
    CONSTRAINT [PK_TK_Trialkit_TheoreticalCalculate_{0}] PRIMARY KEY CLUSTERED 
(
    [iID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

insert into #TK_Trialkit_TheoreticalCalculate_{0}(sTKVersion, sTKVersionType,sDataVersion, iID_NetRequirement_Sum, toplevel, Qty_toplevel, dDate_toplevel, 
                sProductGroup, child, childCycle, childsCycle, Qty_bom, Cumqty_bom, childsm, depth, qtyChild
                , dtmStart, dtmEnd, CreateUid, dtmCreate)
select '{1}',null,a.sDataVersion,a.iID,a.Partid,a.Qty,a.dDate
    ,null,bom.child,bom.childCycle,bom.childsCycle,bom.qty as Qty,bom.cumqty,bom.childsm,bom.depth,bom.qty * a.Qty 
    ,DATEADD(day,-1 * childsCycle,a.dDate)
    ,case when bom.toplevel = bom.parent and bom.parent = bom.child then a.dDate else DATEADD(day,-1 * childsCycle + isnull(bom.childCycle,0),a.dDate) end 
    ,'{2}',GETDATE()
from [dbo].[TK_Trialkit_Trial_Upload] a	
    inner join TK_BOM bom on a.Partid = bom.toplevel
where a.sTKVersion = '{1}'
                    ";
                            sSQL = string.Format(sSQL, sTableName, sVerTrialkitting, sUid);
                            iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        #endregion

                        #region 齐套计算
                        ClsWriteLog.WriteLog(sPath, "计算", "\t齐套计算开始");

                        sSQL = @"
if exists(select * from tempdb..sysobjects where id=object_id('tempdb..#TK_Trialkit_SupplyDemand_{0}')) 
	drop table #TK_Trialkit_SupplyDemand_{0}

select IDENTITY(INT,1,1) AS iID,sPartID,sum(Qty) as Qty,dDate  ,cast(0 as decimal(16,2)) as iUseQty
into #TK_Trialkit_SupplyDemand_{0}
from [dbo].[TK_Trialkit_SupplyDemand]  WITH (nolock)
where isnull(Qty,0) <> 0
    and sPartID in (select child from TK_BOM)
group by sPartID,dDate
order by sPartID ,dDate
";
                        sSQL = string.Format(sSQL, sTableName);
                        iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        Model.TK_Trialkitting_Result modResult = new Model.TK_Trialkitting_Result();
                        modResult.sTKVersion = sVerTrialkitting;
                        modResult.sTKVersionType = iVerTrialkittingType.ToString();
                        modResult.sDataVersion = dtNet.Rows[0]["sVersion"].ToString().Trim();
                        modResult.CreateUid = sUid;
                        modResult.dtmCreate = DateTime.Now;
                        modResult.Guid = Guid.NewGuid();
                        DAL.TK_Trialkitting_Result dal = new DAL.TK_Trialkitting_Result();
                        sSQL = dal.Add(modResult);
                        sSQL = sSQL.Replace("TK_Trialkitting_Result", "#TK_Trialkitting_Result_{0}");
                        sSQL = string.Format(sSQL, sTableName);
                        iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        ClsWriteLog.WriteLog(sPath, "计算", "\t齐套计算\t循环计算开始 累计行数:" + dtNet.Rows.Count.ToString());
                        for (int i = 0; i < dtNet.Rows.Count; i++)
                        {
                            CheckStatus(tran, iID);

                            string sPartID = dtNet.Rows[i]["sPartID"].ToString().Trim();
                            decimal dQty = BaseFunction.ReturnDecimal(dtNet.Rows[i]["Qty"]);
                            DateTime dDate = BaseFunction.ReturnDate(dtNet.Rows[i]["dDate"]);
                            long lID = BaseFunction.ReturnLong(dtNet.Rows[i]["iID"]);

                            try
                            {
                                ClsWriteLog.WriteLog(sPath, "计算", "\t齐套计算\t【" + sPartID + "】 开始  行号：" + (i + 1).ToString());
                                #region 根据产品存量及工单判断产品齐套

                                sSQL = @"
select *,Qty - isnull(iUseQty,0) as iQtyCanUse
from #TK_Trialkit_SupplyDemand_{0}
where 1=1
    and isnull(Qty,0) > isnull(iUseQty,0)
    and sPartID = '{1}' 
";
                                sSQL = string.Format(sSQL, sTableName, sPartID);
                                DataTable dtParentSum = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                if (dtParentSum != null && dtParentSum.Rows.Count > 0)
                                {
                                    for (int ii = 0; ii < dtParentSum.Rows.Count; ii++)
                                    {
                                        decimal dQtyParentSum = BaseFunction.ReturnDecimal(dtParentSum.Rows[ii]["iQtyCanUse"]);

                                        if (dQty > 0)
                                        {
                                            //decimal dQtyParent = BaseFunction.ReturnDecimal(dQtyParentSum);
                                            decimal dNow = 0;
                                            //登记入齐套结果临时表
                                            Model.TK_Trialkitting_Results modResults = new Model.TK_Trialkitting_Results();
                                            modResults.GUID = modResult.Guid;
                                            modResults.sTKVersion = modResult.sTKVersion;
                                            modResults.sTKVersionType = modResult.sTKVersionType;
                                            modResults.dDate = dDate;
                                            modResults.Planner = sPlanner;
                                            modResults.ProdGroup = dtNet.Rows[i]["sProductGroup"].ToString().Trim();
                                            modResults.cInvCode = sPartID;
                                            modResults.NetQty = dQty;
                                            modResults.Reorderpolicy = "MPS";

                                            if (dQtyParentSum >= dQty)
                                            {
                                                dNow = dQty;
                                                modResults.Qty = 0;      //Test 20181121 : modResults.Qty = dQty;
                                                dQty = 0;
                                            }
                                            else
                                            {
                                                dNow = dQtyParentSum;
                                                modResults.Qty = 0;
                                                dQty = dQty - dQtyParentSum;
                                            }
                                            modResults.dtmQty = dDate;
                                            DAL.TK_Trialkitting_Results dalResults = new DAL.TK_Trialkitting_Results();
                                            sSQL = dalResults.Add(modResults);
                                            sSQL = sSQL.Replace("TK_Trialkitting_Results", "#TK_Trialkitting_Results_{0}");
                                            sSQL = string.Format(sSQL, sTableName);
                                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                            sSQL = @"
update  #TK_Trialkit_SupplyDemand_{0} set iUseQty = isnull(iUseQty,0) + isnull({1},0)
where iID = {2}
";
                                            sSQL = string.Format(sSQL, sTableName, dNow, BaseFunction.ReturnLong(dtParentSum.Rows[ii]["iID"]));
                                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                            // test - 
                                            sSQL = @"
select * from #TK_Trialkit_SupplyDemand_{0} where sPartID = '{1}'
";
                                            sSQL = string.Format(sSQL, sTableName, sPartID);
                                            DataTable dttttt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                        }
                                    }
                                }

                                #endregion

                                if (dQty <= 0)
                                    continue;

                                //判断子件是否满足齐套(从底层BOM往上循环)
                                sSQL = @"
select *
from #TK_Trialkit_Calculate_{0}
where isnull(qtyChild,0) <> 0  and (childsm = 'MANUFACTU' or childsm = 'MANUFACTURED')
    and sTKVersion = '{1}' and iID_NetRequirement_Sum = {2}
order by depth desc
";
                                sSQL = string.Format(sSQL, sTableName, sVerTrialkitting, lID);
                                DataTable dtQT = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                for (int j = 0; j < dtQT.Rows.Count; j++)
                                {
                                    string sChild = dtQT.Rows[j]["child"].ToString().Trim();
                                    decimal dQtyChild = BaseFunction.ReturnDecimal(dtQT.Rows[j]["qtyChild"]);
                                    DateTime dtmStart = BaseFunction.ReturnDate(dtQT.Rows[j]["dtmStart"]);
                                    DateTime dtmEnd = BaseFunction.ReturnDate(dtQT.Rows[j]["dtmEnd"]);

                                    ClsWriteLog.WriteLog(sPath, "计算", "\t齐套计算\t【" + sPartID + "】【" + sChild + "】 开始 母件行号：" + (i + 1).ToString());

                                    if (dQtyChild <= 0)
                                    {
                                        continue;
                                    }

                                    sSQL = @"
select count(1) as iCou
from TK_BOM  WITH (nolock)
where isnull(qty,0) <> 0 and toplevel = '{0}' and parent = '{1}' and child <> '{1}'
";
                                    sSQL = string.Format(sSQL, sPartID, sChild);
                                    int iBomCout = BaseFunction.ReturnInt(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]); // BOM子件种类数

                                    bool bConJS = true; //是否继续计算 ，在While循环中符合不计算时用于跳出
                                    while (dQtyChild > 0 && bConJS)
                                    {
                                        //bConJS = false;
                                        //获得当前过程齐套的数量及日期（最小数量及最大日期，木桶原理）
                                        sSQL = @"
select MIN(bomT) AS bomT,MAX(dDate) as dtm,count(1) as iCou
from
(
    select b.*,b.Qty - isnull(b.iUseQty,0) as iUseCan,bom.BomQTY,FLOOR(((b.Qty - isnull(b.iUseQty,0)) / bom.BomQTY)) as bomT
    from 
    (
        SELECT  sPartID as cInvCode, min(dDate) as dtm
        FROM     #TK_Trialkit_SupplyDemand_{0}
        where isnull(Qty,0) - isnull(iUseQty,0) > 0
        group by sPartID
    ) a  left join #TK_Trialkit_SupplyDemand_{0} b on a.cInvCode = b.sPartID and a.dtm = b.dDate
    inner join 
    (
        select parent as InvCode,child as cInvCode,qty as BomQTY
        from TK_BOM with (nolock)
        where parent = '{1}' and child <>  '{1}' and isnull(qty,0) <> 0 and  toplevel = '{2}'
    ) bom on b.sPartID = bom.cInvCode
) QT
";
                                        sSQL = string.Format(sSQL, sTableName, sChild, sPartID);
                                        DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                        if (iBomCout != BaseFunction.ReturnInt(dtTemp.Rows[0]["iCou"]))
                                            break;

                                        decimal dQtybomT = BaseFunction.ReturnDecimal(dtTemp.Rows[0]["bomT"]);
                                        DateTime dtm = BaseFunction.ReturnDate(dtTemp.Rows[0]["dtm"]);

                                        if (dQtybomT <= 0)
                                            break;

                                        //当齐套数据超出订单需求，只需要满足订单需求即可
                                        if (dQtybomT > dQtyChild)
                                        {
                                            dQtybomT = dQtyChild;
                                        }

                                        //将齐套耗用数据记录进_齐套计算临时表，避免下次计算重复使用
                                        sSQL = @"
update a set a.iUseQty = isnull(a.iUseQty,0) + b.BomQTY * {2}
from #TK_Trialkit_SupplyDemand_{0} a 
    inner join 
    (
        select b.iID,bom.BomQTY
        from 
        (
            SELECT  sPartID as cInvCode, min(dDate) as dtm
            FROM    #TK_Trialkit_SupplyDemand_{0}
            where isnull(Qty,0) - isnull(iUseQty,0) > 0
            group by sPartID
        ) a left join #TK_Trialkit_SupplyDemand_{0} b on a.cInvCode = b.sPartID and a.dtm = b.dDate
            inner join 
            (
                select parent as InvCode,child as cInvCode,qty as BomQTY
                from TK_BOM with (nolock)
                where parent = '{1}' and child <>  '{1}'
            ) bom on b.sPartID = bom.cInvCode
    ) b on a.iID = b.iID
                              
";
                                        sSQL = string.Format(sSQL, sTableName, sChild, dQtybomT);
                                        iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                        sSQL = @"
if exists(select * from #TK_Trialkit_SupplyDemand_{0} where sPartID = '{1}' and dDate = '{3}')
    update #TK_Trialkit_SupplyDemand_{0} set Qty = isnull(Qty,0) + {2}  where  sPartID = '{1}' and dDate = '{3}'
else
    insert into #TK_Trialkit_SupplyDemand_{0}(sPartID, Qty, dDate)
    values('{1}',{2},'{3}')
";
                                        sSQL = string.Format(sSQL, sTableName, sChild, dQtybomT, dtm);
                                        iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                        //                                        //Test - 
                                        //                                        sSQL = @"
                                        //select * from #TK_Trialkit_SupplyDemand_{0} where sPartID = '{1}'
                                        //                                    ";
                                        //                                        sSQL = string.Format(sSQL, sTableName, sChild);
                                        //                                        DataTable dtttt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                                        //登记入齐套结果临时表
                                        Model.TK_Trialkitting_Results modResults = new Model.TK_Trialkitting_Results();
                                        modResults.GUID = modResult.Guid;
                                        modResults.sTKVersion = modResult.sTKVersion;
                                        modResults.sTKVersionType = modResult.sTKVersionType;
                                        modResults.dDate = dtm;
                                        modResults.Planner = sPlanner;
                                        modResults.ProdGroup = dtNet.Rows[i]["sProductGroup"].ToString().Trim();
                                        modResults.cInvCode = sChild;
                                        modResults.NetQty = dQtyChild;
                                        if (sChild == sPartID)
                                            modResults.Reorderpolicy = "MPS";
                                        else
                                            modResults.Reorderpolicy = "MRP";

                                        modResults.Qty = dQtybomT;
                                        modResults.dtmQty = dtm;
                                        DAL.TK_Trialkitting_Results dalResults = new DAL.TK_Trialkitting_Results();
                                        sSQL = dalResults.Add(modResults);
                                        sSQL = sSQL.Replace("TK_Trialkitting_Results", "#TK_Trialkitting_Results_{0}");
                                        sSQL = string.Format(sSQL, sTableName);
                                        iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                        dQtyChild = dQtyChild - dQtybomT;
                                    }
                                    ClsWriteLog.WriteLog(sPath, "计算", "\t齐套计算\t【" + sPartID + "】【" + sChild + "】 成功");
                                }
                                ClsWriteLog.WriteLog(sPath, "计算", "\t齐套计算\t【" + sPartID + "】成功");
                            }
                            catch (Exception ee)
                            {
                                ClsWriteLog.WriteLog(sPath, "计算", "\t齐套计算\t【" + sPartID + "】失败：" + ee.Message);
                            }
                            ClsWriteLog.WriteLog(sPath, "计算", "\t齐套计算\t循环计算成功");
                        }


                        ClsWriteLog.WriteLog(sPath, "计算", "\t齐套计算成功");

                        #endregion
                    }
                    #region 锁表操作放在这里,将计算结果写入记录表


                    ClsWriteLog.WriteLog(sPath, "计算", "\t写入TK_Trialkit_Calculate开始");
                    sSQL = @"
delete TK_Trialkit_Calculate where sTKVersion = '{0}' and sTKVersionType = '{1}'
";
                    sSQL = string.Format(sSQL, sVerTrialkitting, iVerTrialkittingType);
                    iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = @"
delete TK_Trialkit_Calculate where sTKVersion = '{2}' and sTKVersionType = '{1}'

insert into      TK_Trialkit_Calculate( sTKVersion, sTKVersionType, sDataVersion, iID_NetRequirement_Sum, toplevel, Qty_toplevel, dDate_toplevel, 
                sProductGroup, child, childCycle, childsCycle, Qty_bom, Cumqty_bom, childsm, depth, qtyChild, dtmStart, dtmEnd, 
                CreateUid, dtmCreate)
select  '{2}','{1}', sDataVersion, iID_NetRequirement_Sum, toplevel, Qty_toplevel, dDate_toplevel, 
                sProductGroup, child, childCycle, childsCycle, Qty_bom, Cumqty_bom, childsm, depth, qtyChild, dtmStart, dtmEnd, 
                CreateUid, dtmCreate
from #TK_Trialkit_Calculate_{0}
where isnull(qtyChild,0) <> 0
";
                    sSQL = string.Format(sSQL, sTableName, iVerTrialkittingType, sVerTrialkitting);
                    iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    //string sSQL_Test = @"select * from TK_Trialkit_Calculate where s";
                    //DataTable dt_Test = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL_Test).Tables[0];

                    ClsWriteLog.WriteLog(sPath, "计算", "\t写入TK_Trialkit_Calculate成功 执行行数：" + iCou.ToString());

                    ClsWriteLog.WriteLog(sPath, "计算", "\t写入TK_Trialkitting_Result，TK_Trialkitting_Results,TK_Trialkitting_Results_Details 开始");


                    sSQL = @"
if exists(select * from tempdb..sysobjects where id=object_id('tempdb..#TK_Trialkit_SupplyDemand_{0}')) 
	drop table #TK_Trialkit_SupplyDemand_{0}

select * 
into #TK_Trialkit_SupplyDemand_{0}
from [dbo].[TK_Trialkit_SupplyDemand]  WITH (nolock)
where isnull(Qty,0) <> 0
order by sPartID ,dDate
";
                    sSQL = string.Format(sSQL, sTableName, sVerTrialkitting, iVerTrialkittingType);
                    iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = @"
delete TK_Trialkitting_Results_Details where sTKVersion = '{1}' and sTKVersionType = '{2}'
delete TK_Trialkitting_Results where sTKVersion = '{1}' and sTKVersionType = '{2}'
delete TK_Trialkitting_Result where sTKVersion = '{1}' and sTKVersionType = '{2}'
delete TK_Trialkitting_Results_Details_History where sTKVersion = '{1}' and sTKVersionType = '{2}'

insert into TK_Trialkitting_Result( Guid, sTKVersion, sDataVersion, CreateUid, dtmCreate, Remark, DataFrom,sTKVersionType)
select Guid, sTKVersion, sDataVersion, CreateUid, dtmCreate, Remark, DataFrom,sTKVersionType
from #TK_Trialkitting_Result_{0}

insert into TK_Trialkitting_Results_Details( GUID, sTKVersion, dDate, Planner, ProdGroup, cInvCode, NetQty, Reorderpolicy, DayWO, QtyCurr, QtyWO, Qty, dtmQty,sTKVersionType)
select GUID, sTKVersion, dDate, Planner, ProdGroup, cInvCode, NetQty, Reorderpolicy, DayWO, QtyCurr, QtyWO,  Qty, dtmQty,sTKVersionType
from #TK_Trialkitting_Results_{0}

--计算结果写入
insert into TK_Trialkitting_Results(sTKVersion, sTKVersionType, dDate, Planner, ProdGroup, cInvCode, NetQty,Reorderpolicy,Qty)
select sTKVersion, sTKVersionType, dDate, Planner, ProdGroup, cInvCode, sum(Qty),Reorderpolicy, sum(Qty)
from #TK_Trialkitting_Results_{0}
group by sTKVersion, dDate, Planner, ProdGroup, cInvCode, Reorderpolicy,  dtmQty,sTKVersionType

--
insert into TK_Trialkitting_Results(sTKVersion, sTKVersionType, dDate, Planner, ProdGroup, cInvCode, NetQty,Reorderpolicy)
select sTKVersion,sTKVersionType,dtmStart as dDate,null,sProductGroup,[child],sum(qtyChild) as Qty,'MRP'
FROM      #TK_Trialkit_Calculate_{0}  
where childsm = 'MANUFACTURED' and isnull(qtyChild,0) <> 0 and [child] not in (select distinct cInvCode from #TK_Trialkitting_Results_{0})
group by sTKVersion,sTKVersionType,dtmStart,sProductGroup,[child]

update a set a.NetQty = isnull(b.Qty,0)
from TK_Trialkitting_Results a 
    left join (select [child],sum(qtyChild) as Qty,sProductGroup from #TK_Trialkit_Calculate_{0} group by [child],sProductGroup) b on a.cInvCode = b.[child] and a.ProdGroup = b.sProductGroup
where sTKVersion = '{1}' and sTKVersionType = '{2}'


update a set  a.QtyCurr = isnull(b.Qty,0)
from TK_Trialkitting_Results a
 left join 
 (
		select sPartID,sType,sum(Qty) as Qty
		from #TK_Trialkit_SupplyDemand_{0}
        where sType = 'CurrentStock'
		group by sPartID,sType
 )b on a.cInvCode = b.sPartID
where sTKVersion = '{1}' and sTKVersionType = '{2}'

update a set  a.QtyWO = b.Qty
from TK_Trialkitting_Results a
 inner join 
 (
		select sPartID,sType,sum(Qty) as Qty
		from #TK_Trialkit_SupplyDemand_{0}
        where sType = 'WO'
		group by sPartID,sType
 )b on a.cInvCode = b.sPartID
where sTKVersion = '{1}' and sTKVersionType = '{2}'

update a set a.DayWO = c.[iCycle]
from TK_Trialkitting_Results a
    inner join TK_Base_ItemNo_Cycle c on a.cInvCode = c.sItemNo
where sTKVersion = '{1}' and sTKVersionType = '{2}'

update a set a.NetQty  = b.Qty ,a.Reorderpolicy = 'MPS'
from TK_Trialkitting_Results a 
    inner join (select sPartID,sum(Qty) as Qty from #TK_NetRequirement_Sum_{0} group by sPartID) b on a.cInvCode = b.sPartID
where sTKVersion = '{1}' and sTKVersionType = '{2}'
    and cInvCode in (select distinct toplevel from TK_BOM WITH (nolock))

update rs set  rs.Reorderpolicy = b.reorderpolicy
from [dbo].[TK_Trialkitting_Results] rs inner join  _Get_TK_PartMaster b on rs.cInvCode = b.partnum
where rs.Reorderpolicy <> b.reorderpolicy                                                                                   
    and rs.sTKVersion = '{1}' and rs.sTKVersionType = '{2}'


update rsd set  rsd.Reorderpolicy = b.reorderpolicy
from [dbo].[TK_Trialkitting_Results_Details] rsd inner join  _Get_TK_PartMaster b on rsd.cInvCode = b.partnum
where rsd.Reorderpolicy <> b.reorderpolicy
    and rsd.sTKVersion = '{1}' and rsd.sTKVersionType = '{2}'

declare @iYear int
declare @iMonth int
declare @Period01 date
declare @Period02 date
declare @Period03 date
declare @Period04 date
declare @Period05 date
declare @Period06 date
declare @Period07 date
declare @Period08 date
declare @Period09 date
declare @Period10 date
declare @Period11 date
declare @Period12 date
declare @Period13 date
declare @Period14 date
declare @Period15 date
declare @Period16 date
declare @Period17 date
declare @PeriodEnd date

select @iYear = iYear,@iMonth = iMonth,@PeriodEnd = dtmEnd from [dbo].[TK_Base_CalendarPeriod] where getdate() >= dtmStart and getdate() < DATEADD(day,1, dtmEnd)

select @Period01 = Period01
	,@Period02 = Period02
	,@Period03 = Period03
	,@Period04 = Period04
	,@Period05 = Period05
	,@Period06 = Period06
	,@Period07 = Period07
	,@Period08 = Period08
	,@Period09 = Period09
	,@Period10 = Period10
	,@Period11 = Period11
	,@Period12 = Period12
	,@Period13 = Period13
	,@Period14 = Period14
	,@Period15 = Period15
	,@Period16 = Period16
	,@Period17 = Period17
from [dbo].[TK_Period] where [iYear] = @iYear and iMonth = @iMonth

update TK_Trialkitting_Results set dtmQty =
		case when dDate < @Period01 then @Period01
	when dDate >= @Period01 and dDate < @Period02 then @Period01
	when dDate >= @Period02 and dDate < @Period03 then @Period02
	when dDate >= @Period03 and dDate < @Period04 then @Period03
	when dDate >= @Period04 and dDate < @Period05 then @Period04
	when dDate >= @Period05 and dDate < @Period06 then @Period05
	when dDate >= @Period06 and dDate < @Period07 then @Period06
	when dDate >= @Period07 and dDate < @Period08 then @Period07
	when dDate >= @Period08 and dDate < @Period09 then @Period08
	when dDate >= @Period09 and dDate < @Period10 then @Period09
	when dDate >= @Period10 and dDate < @Period11 then @Period10
	when dDate >= @Period11 and dDate < @Period12 then @Period11
	when dDate >= @Period12 and dDate < @Period13 then @Period12
	when dDate >= @Period13 and dDate < @Period14 then @Period13
	when dDate >= @Period14 and dDate < @Period15 then @Period14
	when dDate >= @Period15 and dDate < @Period16 then @Period15
	when dDate >= @Period16 and dDate < @Period17 then @Period16
	when dDate >= @Period17 and dDate < @PeriodEnd then @Period17
	when dDate >= @PeriodEnd then @PeriodEnd end 
where  sTKVersion = '{1}' and sTKVersionType = '{2}'
";
                    sSQL = string.Format(sSQL, sTableName, sVerTrialkitting, iVerTrialkittingType);
                    iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    ClsWriteLog.WriteLog(sPath, "计算", "\t写入TK_Trialkitting_Result，TK_Trialkitting_Results,TK_Trialkitting_Results_Details 成功 执行行数：" + iCou.ToString());


                    if (iVerTrialkittingType >= 0)
                    {
                        sSQL = @"
delete TK_Trialkit_TheoreticalCalculate where sTKVersion = '{1}' and sTKVersionType = '{2}'

insert into TK_Trialkit_TheoreticalCalculate(sTKVersion, sTKVersionType,sDataVersion, iID_NetRequirement_Sum, toplevel, Qty_toplevel, dDate_toplevel, 
                sProductGroup, child, childCycle, childsCycle, Qty_bom, Cumqty_bom, childsm, depth, qtyChild
                , dtmStart, dtmEnd, CreateUid, dtmCreate)
select '{1}', '{2}', sDataVersion,iID_NetRequirement_Sum, toplevel, Qty_toplevel, dDate_toplevel, 
                sProductGroup, child, childCycle, childsCycle, Qty_bom, Cumqty_bom, childsm, depth, qtyChild
                , dtmStart, dtmEnd, CreateUid, dtmCreate 
from #TK_Trialkit_TheoreticalCalculate_{0}
";
                        sSQL = string.Format(sSQL, sTableName, sVerTrialkitting, iVerTrialkittingType);
                        iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        ClsWriteLog.WriteLog(sPath, "计算", "\t写入TK_Trialkit_TheoreticalCalculate 成功 执行行数：" + iCou.ToString());
                    }
                    #endregion

                    sSQL = @"
delete TK_Trialkit_Net_Temp where sTKVersion = '{1}' and sTKVersionType = {2};

insert into TK_Trialkit_Net_Temp(sTKVersion, sTKVersionType, PartID, NetQty, dDate)
select sTKVersion, sTKVersionType, PartID, NetQty, dDate
FROM #TK_Trialkit_Net_Temp_{0}
";
                    sSQL = string.Format(sSQL, sTableName, sVerTrialkitting, iVerTrialkittingType);
                    iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = @"
exec [dbo].[_Get_For_PAD] '{0}'
";
                    sSQL = string.Format(sSQL, sVerTrialkitting);
                    iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    //[dbo].[TK_Trialkit_Net_Details]中扣去 工单量，用于PAD显示
                    sSQL = @"
select distinct PartID
from
(
	select a.iID, a.PartID,a.NetQty,b.WOQty
	from [TK_Trialkit_Net_Details]  a 
		left join (select distinct sTKVersion,PartID,WOQty FROM [dbo].[TK_Trialkit_Net] where sTKVersion = '{0}') b on a.sTKVersion = b.sTKVersion and a.PartID = b.PartID
	where a.sTKVersion = '{0}' and isnull(b.WOQty,0) > 0
)a 
";
                    sSQL = string.Format(sSQL, sVerTrialkitting);
                    DataTable dtForPad = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    for (int i = 0; i < dtForPad.Rows.Count; i++)
                    {
                        string sPartID = dtForPad.Rows[i]["PartID"].ToString().Trim();
                        sSQL = @"
select a.iID, a.PartID,a.NetQty,b.WOQty
from [TK_Trialkit_Net_Details]  a 
	left join (select distinct sTKVersion,PartID,WOQty FROM [dbo].[TK_Trialkit_Net] where sTKVersion = '{0}') b on a.sTKVersion = b.sTKVersion and a.PartID = b.PartID
where a.sTKVersion = '{0}' and isnull(b.WOQty,0) > 0 and a.PartID = '{1}'
order by a.[dtmPeriod]
";
                        sSQL = string.Format(sSQL, sVerTrialkitting, sPartID);
                        DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        decimal dQtyWO = BaseFunction.ReturnDecimal(dtTemp.Rows[0]["WOQty"]);
                        for (int j = 0; j < dtTemp.Rows.Count; j++)
                        {
                            long lID = BaseFunction.ReturnLong(dtTemp.Rows[j]["iID"]);
                            decimal dNetQty = BaseFunction.ReturnDecimal(dtTemp.Rows[j]["NetQty"]);
                            if (dNetQty >= dQtyWO)
                            {
                                dNetQty = dNetQty - dQtyWO;

                                sSQL = @"
update TK_Trialkit_Net_Details set [NetQty_PAD] = {1}
where iID = {0}
";
                                sSQL = string.Format(sSQL, lID, dNetQty);
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                dQtyWO = 0;
                            }
                            else
                            {
                                sSQL = @"
update TK_Trialkit_Net_Details set [NetQty_PAD] = 0
where iID = {0}
";
                                sSQL = string.Format(sSQL, lID);
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                                dQtyWO = dQtyWO - dNetQty;
                            }

                            if (dQtyWO <= 0)
                            {
                                break;
                            }
                        }
                    }

                    tran.Commit();
                    ClsWriteLog.WriteLog(sPath, "计算", "计算成功");

                    sTKVersion_out = sVerTrialkitting;
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    
                    throw new Exception(ee.Message);
                }
                finally
                {

                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
            catch (Exception ee)
            {
                ClsWriteLog.WriteLog(sPath, "计算", "计算失败：" + ee.Message);
                throw new Exception(ee.Message);
                //return ee.Message;
            }

            return "";
        }





        /// <summary>
        /// 递归展BOM（只展一层）
        /// </summary>
        /// <param name="tran"></param>
        /// <param name="lID">TK_NetRequirement_Sum 中的iID</param>
        /// <param name="sInvCode">母件编码</param>
        /// <param name="dQty">需求数量</param>
        /// <param name="dDate">需求日期</param>
        private void InitBomN(SqlTransaction tran, long lID, string sInvCode, decimal dQty, DateTime dDate, string sTableName,string sVersion,int iVerTrialkittingType)
        {
            if (dQty <= 0)
                return;

            if (sInvCode == "1006708")
            {

            }

            string sWhere = "[parent] = '{0}' and [child] <> '{0}'";
            sWhere = string.Format(sWhere, sInvCode);

            DataRow[] drList = dtBom.Select(sWhere);

            foreach (DataRow dr in drList)
            {
                string sChild = dr["child"].ToString().Trim();

                decimal dQtyUse = 0;     //可用量
                string sSQL = @"
select sPartID,sum(Qty) as Qty 
from #TK_Trialkit_SupplyDemand_{0}
where sPartID = '{1}'
group by sPartID 
";
                sSQL = string.Format(sSQL, sTableName, sChild);
                DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    dQtyUse = BaseFunction.ReturnDecimal(dt.Rows[0]["Qty"]);
                }
                decimal dQtyBOM = BaseFunction.ReturnDecimal(dr["Qty"]);

                decimal dQtyNeed = dQty * dQtyBOM;

                if (dr["childsm"].ToString().Trim().ToUpper() == "MANUFACTURED")
                {
                    Model.TK_Trialkit_Net_Temp modeNet = new Model.TK_Trialkit_Net_Temp();
                    modeNet.PartID = sChild;
                    modeNet.NetQty = dQtyNeed;
                    modeNet.dDate = dDate;
                    modeNet.sTKVersion = sVersion;
                    modeNet.sTKVersionType = iVerTrialkittingType;
                    modeNet.ProType = "m";
                    DAL.TK_Trialkit_Net_Temp dalNet = new DAL.TK_Trialkit_Net_Temp();
                    sSQL = dalNet.Add(modeNet);
                    sSQL = sSQL.Replace("TK_Trialkit_Net_Temp", "#TK_Trialkit_Net_Temp_{0}");
                    sSQL = string.Format(sSQL, sTableName);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }
                if (dQtyNeed <= dQtyUse)
                {
                    sSQL = @"
insert into #TK_Trialkit_SupplyDemand_{0}(sType, sPartID, Qty, dDate)
values('Used','{1}',{2},'{3}')
";
                    sSQL = string.Format(sSQL, sTableName, sChild, -1 * dQtyNeed, dDate);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    dQtyNeed = 0;
                }
                else
                {
                    dQtyNeed = dQtyNeed - dQtyUse;

                    sSQL = @"
insert into #TK_Trialkit_SupplyDemand_{0}(sType, sPartID, Qty, dDate)
values('Used','{1}',{2},'{3}')
";
                    sSQL = string.Format(sSQL, sTableName, sChild, -1 * dQtyUse, dDate);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    dQtyUse = 0;
                }


                dr["dQtyNow"] = dQtyNeed;        //本次下单数量
                dr["dtmEnd"] = dDate.AddDays(-1);

                int ichildCycle = BaseFunction.ReturnInt(dr["childCycle"]);
                dr["dtmStart"] = BaseFunction.ReturnDate((dr["dtmEnd"])).AddDays(-1 * ichildCycle);
            }
        }


        /// <summary>
        /// 递归展BOM
        /// </summary>
        /// <param name="tran"></param>
        /// <param name="lID">TK_NetRequirement_Sum 中的iID</param>
        /// <param name="stoplevel">产品编码</param>
        /// <param name="sInvCode">母件编码</param>
        /// <param name="dQty">需求数量</param>
        /// <param name="dDate">需求日期</param>
        private void InitBomN(SqlTransaction tran,long lID,string stoplevel, string sInvCode, decimal dQty, DateTime dDate ,string sTableName,string sVersion, int iVerTrialkittingType)
        {
            if (dQty <= 0)
                return;

            if (sInvCode == "1006708")
            {

            }

            string sWhere = "[toplevel] = '{0}' and  [parent] = '{1}' and [child] <> '{1}'";
            sWhere = string.Format(sWhere, stoplevel, sInvCode);

            DataRow[] drList = dtBom.Select(sWhere);

            foreach (DataRow dr in drList)
            {
                string sChild = dr["child"].ToString().Trim();
                      
                decimal dQtyUse = 0;     //可用量
                string sSQL = @"
select sPartID,sum(Qty) as Qty 
from #TK_Trialkit_SupplyDemand_{0}
where sPartID = '{1}'
group by sPartID 
";
                sSQL = string.Format(sSQL, sTableName, sChild);
                DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    dQtyUse = BaseFunction.ReturnDecimal(dt.Rows[0]["Qty"]);
                }
                decimal dQtyBOM = BaseFunction.ReturnDecimal(dr["Qty"]);

                decimal dQtyNeed = dQty * dQtyBOM;
                
                if (dr["childsm"].ToString().Trim().ToUpper() == "MANUFACTURED")
                {
                    Model.TK_Trialkit_Net_Temp modeNet = new Model.TK_Trialkit_Net_Temp();
                    modeNet.PartID = sChild;
                    modeNet.NetQty = dQtyNeed;
                    modeNet.dDate = dDate;
                    modeNet.sTKVersion = sVersion;
                    modeNet.sTKVersionType = iVerTrialkittingType;
                    modeNet.ProType = "m";
                    DAL.TK_Trialkit_Net_Temp dalNet = new DAL.TK_Trialkit_Net_Temp();
                    sSQL = dalNet.Add(modeNet);
                    sSQL = sSQL.Replace("TK_Trialkit_Net_Temp", "#TK_Trialkit_Net_Temp_{0}");
                    sSQL = string.Format(sSQL, sTableName);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }

                if (dQtyNeed <= dQtyUse)
                {
                    sSQL = @"
insert into #TK_Trialkit_SupplyDemand_{0}(sType, sPartID, Qty, dDate)
values('Used','{1}',{2},'{3}')
";
                    sSQL = string.Format(sSQL, sTableName, sChild, -1 * dQtyNeed, dDate);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    dQtyNeed = 0;
                }
                else
                {
                    dQtyNeed = dQtyNeed - dQtyUse;

                    sSQL = @"
insert into #TK_Trialkit_SupplyDemand_{0}(sType, sPartID, Qty, dDate)
values('Used','{1}',{2},'{3}')
";
                    sSQL = string.Format(sSQL, sTableName, sChild, -1 * dQtyUse, dDate);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    dQtyUse = 0;
                }


                dr["dQtyNow"] = dQtyNeed;        //本次下单数量
                dr["dtmEnd"] = dDate.AddDays(-1);

                int ichildCycle = BaseFunction.ReturnInt(dr["childCycle"]);
                dr["dtmStart"] = BaseFunction.ReturnDate((dr["dtmEnd"])).AddDays(-1 * ichildCycle);

                InitBomN(tran, lID, stoplevel, dr["child"].ToString().Trim(), dQtyNeed, Convert.ToDateTime(Convert.ToDateTime(dr["dtmStart"]).ToString("yyyy-MM-dd")), sTableName, sVersion, iVerTrialkittingType);
            }
        }
    }
}
