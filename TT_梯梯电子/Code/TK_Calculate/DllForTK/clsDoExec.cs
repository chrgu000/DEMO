using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TH.BaseClass;
using System.Data.SqlClient;
using System.Xml;
using System.Threading;
using System.Windows.Forms;

namespace DllForTK
{
    public class clsDoExec
    {
        string sPath;

        public clsDoExec()
        {
            DllForTK.Config.ConnString();

            sPath = DbHelperSQL.sLogPath;
        }

        /// <summary>
        /// 清除失败的任务
        /// </summary>
        public void CleanService()
        {
            #region 清除失败的系统任务
            try
            {
                sPath = DbHelperSQL.sLogPath;
                sPath = DbHelperSQL.sLogPath + @"&System-CleanService";


                ClsWriteLog.WriteLog(sPath, "清除失败的系统任务", "开始");
                string sSQL = @"
update _AutoRun set iStatus = 0,GatingStatus = 0
WHERE   iStatus <> 0  and DATEADD(hour,iChkTime,dtmStart) < getdate()
    and dtmStart >= dtmEnd
            ";
                int iCou = DbHelperSQL.ExecuteSql(sSQL);
                ClsWriteLog.WriteLog(sPath, "清除失败的系统任务", "成功");
            }
            catch (Exception ee)
            {
                ClsWriteLog.WriteLog(sPath, "清除失败的系统任务", "失败：" + ee.Message);
            }

            #endregion
        }

        /// <summary>
        /// 系统定时任务。
        /// 执行系统定时任务：定时同步静态数据，并将计算状态置为需要执行
        /// </summary>
        /// <param name="sPath">日志路径</param>
        public void doLoadBase()
        {
            try
            {
                sPath = DbHelperSQL.sLogPath + @"&System-LoadData";

                string sSQL = @"
SELECT top 1  iID, sType, Description, iStatus, SetStartTime, dtmStart, dtmEnd, iChkTime, Remark ,getdate() as dtmNow
FROM      _AutoRun  WITH (nolock)
WHERE sType = 'BaseData' and  1=1 and isnull(iStatus,0) = 0
order by iID
";
                DataTable dt = DbHelperSQL.Query(sSQL);

                int iID = BaseFunction.ReturnInt(dt.Rows[0]["iID"]);
                DateTime dtmNow = BaseFunction.ReturnDate(dt.Rows[0]["dtmNow"]);
                DateTime dtmRumTime = BaseFunction.ReturnDate(dt.Rows[0]["SetStartTime"]);
                DateTime dTime = BaseFunction.ReturnDate(dtmNow.ToString("yyyy-MM-dd") + " " + dtmRumTime.ToString("HH:mm:ss"));
                DateTime dtmStart = BaseFunction.ReturnDate(dt.Rows[0]["dtmStart"]);
                DateTime dtmEnd = BaseFunction.ReturnDate(dt.Rows[0]["dtmEnd"]);

                if (dtmStart <= dTime)
                {
                    sSQL = @"
update _AutoRun set dtmStart = getdate(),iStatus = 1 where iID = {0}
";
                    sSQL = string.Format(sSQL, iID);
                    DbHelperSQL.ExecuteSql(sSQL);

                    //同步静态数据
                    ClsWriteLog.WriteLog(sPath, "同步数据", "同步静态数据开始");
                    string sReturn = LoadBaseData("System");
                    if (sReturn == "")
                    {
                        ClsWriteLog.WriteLog(sPath, "同步数据", "同步静态数据成功");
                        
                        //执行成功后标记为0，等待下一周期执行
                        sSQL = @"
update _AutoRun set dtmEnd = getdate(),iStatus = 0 where iID = {0}
";
                        sSQL = string.Format(sSQL, iID);
                        DbHelperSQL.ExecuteSql(sSQL);

                        //标记需要进行第一轮计算（执行状态，0 未执行；1 执行中; 2 执行成功；3 停止失败）
                        //执行成功，失败的标记为0 用于下次执行；执行状态为1 且超出执行检查时间的也标记为0 用于下次执行。
                        sSQL = @"
update _AutoRun set iStatus = 0,GatingStatus = 0 where (sType = 'Trialkitting' and iStatus <> 1) or (sType = 'Trialkitting' and iStatus = 1 and GETDATE() > dateadd(HOUR,iChkTime,dtmStart))
";
                        sSQL = string.Format(sSQL, iID);
                        DbHelperSQL.ExecuteSql(sSQL);
                    }
                    else
                    {
                        sSQL = @"
update _AutoRun set dtmEnd = getdate(),iStatus = 0 where iID = {0}
";
                        sSQL = string.Format(sSQL, iID);
                        DbHelperSQL.ExecuteSql(sSQL);
                        ClsWriteLog.WriteLog(sPath, "同步数据", "同步静态数据失败：" + sReturn);
                    }
                }
                if (dt == null)
                {
                    throw new Exception("获得任务清单失败");
                }
            }
            catch (Exception ee)
            {

            }
        }

        /// <summary>
        /// 执行人员触发任务：按照项目组计算
        /// </summary>
        public void TrialkittingCalculateByPerson()
        {   
            int iID = -1;
            try
            {
                DllForTK.Config.ConnString();

                string sSQL = @"
SELECT top 1  iID, sType, Description, iStatus, SetStartTime, dtmStart, dtmEnd, iChkTime, Remark ,getdate() as dtmNow
FROM      _AutoRun  WITH (nolock)
WHERE sType = 'BaseData' and  1=1 and isnull(iStatus,0) = 1
order by iID
";
                DataTable dt = DbHelperSQL.Query(sSQL);
                if (dt != null && dt.Rows.Count > 0)
                {
                    throw new Exception("正在同步数据");
                }

                sSQL = @"
SELECT top 1 iID, sType, dDate, sVerData, sVerTrialkitting, ProdGroup, Planner, iState, sResult, Remark, CreateUid
                , dtmCreate, dtmStart, dtmEnd,getdate() as dtmNow
FROM      TK_List  WITH (nolock)
WHERE sType = 'BaseData' and  1=1 and isnull([iState],0) = 1
order by iID
";
                dt = DbHelperSQL.Query(sSQL);
                if (dt != null && dt.Rows.Count > 0)
                {
                    throw new Exception("正在同步数据");
                }
                
                sSQL = @"
select count(1) as iCou from[dbo].[_AutoRun] where sType = 'Trialkitting' and isnull(iStatus, 0) <> 1
";
                dt = DbHelperSQL.Query(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("获取进程数设置失败");
                }
                int iThread = BaseFunction.ReturnInt(dt.Rows[0][0]);        //总进程数

                sSQL = @"
SELECT   COUNT(1) AS iCou
FROM      TK_List
WHERE   (ISNULL(iState, 0) = 1)
";
                dt = DbHelperSQL.Query(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("获取正在执行的进程数失败");
                }
                int iThreadSum = BaseFunction.ReturnInt(dt.Rows[0][0]);        //当前总进程数
                if (iThreadSum >= iThread)
                {
                    throw new Exception("当前进程已满，暂停执行");
                }

                //每次只启动一件任务
                sSQL = @"
SELECT top 1  iID, sType, dDate, sVerData, sVerTrialkitting, ProdGroup, Planner, iState, sResult, Remark, CreateUid, 
                dtmCreate, dtmStart, dtmEnd
FROM      TK_List WITH (nolock)
WHERE   (ISNULL(iState, 0) = 0)
ORDER BY iID
";
                dt = DbHelperSQL.Query(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    return;
                }

                iID = BaseFunction.ReturnInt(dt.Rows[0]["iID"]);
                string sType = dt.Rows[0]["sType"].ToString().Trim();
                string sUid = dt.Rows[0]["CreateUid"].ToString().Trim();

                sPath = DbHelperSQL.sLogPath + @"&" + sUid + "-Calculate";

                sSQL = @"
SELECT   COUNT(1) AS iCou
FROM      TK_List
WHERE   (ISNULL(iState, 0) = 1) and CreateUid = '{0}'
";
                sSQL = string.Format(sSQL, sUid);
                dt = DbHelperSQL.Query(sSQL);
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (BaseFunction.ReturnInt(dt.Rows[0]["iCou"]) > 0)
                    {
                        //throw new Exception("当前用户已经有正在执行的单据");
                        return;
                    }
                }


                //标记为执行状态
                sSQL = @"
update TK_List set iState = 1,dtmStart = getdate() where iID = {0}
";
                sSQL = string.Format(sSQL, iID);
                DbHelperSQL.ExecuteSql(sSQL);

                string sReturn = "";
                string sTKVersion = "";
                if (sType.ToLower() == "BaseData".ToLower())
                {
                    sReturn = LoadBaseData(sUid);
                }
                else
                {
                    //触发执行
                    clsTrialkitting cls = new clsTrialkitting();

                    sReturn = cls.Trialkitting(iID, sUid, sPath, -1,out sTKVersion);
                }

                //标记执行成功
                if (sReturn.Trim() == "")
                {
                    sSQL = @"
update TK_List set iState = 2,dtmEnd = getdate() ,GatingStatus = 0 where iID = {0}
";
                    sSQL = string.Format(sSQL, iID);
                    DbHelperSQL.ExecuteSql(sSQL);
                }
                else
                {
                    sSQL = @"
update TK_List set iState = 3,Remark = N'{1}' where iID = {0}
";
                    sSQL = string.Format(sSQL, iID, sReturn);
                    DbHelperSQL.ExecuteSql(sSQL);
                }

                try
                {
                    if (sTKVersion != string.Empty)
                    {
                        //生成buy的计划数据--将NetQty-CurrQty
                        BuyerGatingData cls = new BuyerGatingData();
                        cls.BuyGatingCalculate(sTKVersion);

                        //生成buy明细数据
                        BuyerGatingData cls2 = new BuyerGatingData();
                        cls2.BuyGatingCalculate(sTKVersion);

                        //生成pm明数据
                        PMGatingData cls3 = new PMGatingData();
                        cls3.PMGatingDataCalculate(sTKVersion);
                    }
                }
                catch (Exception ee)
                { }
            }
            catch (Exception ee)
            {
                string s = ee.Message;
                if (s.Length > 200)
                {
                    s = s.Substring(0, 200);
                }
                string sSQL = @"
update TK_List set iState = 3 where iID = {0}
";
                sSQL = string.Format(sSQL, iID);
                DbHelperSQL.ExecuteSql(sSQL);
            }
        }



        /// <summary>
        /// 同步净需求、工单、采购订单、仓库存量
        /// </summary>
        /// <returns></returns>
        public string LoadBaseData(string sUid)
        {
            try
            {
                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    //ClsWriteLog.WriteLog(sPath, "同步数据", DbHelperSQL.connectionString);

                    string sSQL = @"
select getdate()
";
                    DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    string sVerData = BaseFunction.ReturnDate(dtTemp.Rows[0][0]).ToString("yyyyMMddHHmmss");
                    if (sUid.ToLower().Trim() == "system")
                    {
                        sVerData = BaseFunction.ReturnDate(dtTemp.Rows[0][0]).ToString("yyyyMMdd000000");
                    }

                    ClsWriteLog.WriteLog(sPath, "同步数据", "获得截止日期 开始");
                    //获得截止日期（取的数据日期大1）
                    sSQL = @"
exec _Get_DateScope '{0}'
";
                    sSQL = string.Format(sSQL, BaseFunction.ReturnDate(dtTemp.Rows[0][0]).ToString("yyyy-MM-dd"));
                    dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    DateTime dtmEnd = DateTime.Now.AddMonths(7);
                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                    {
                        dtmEnd = BaseFunction.ReturnDate(dtTemp.Rows[0]["dtmEnd"]);
                    }
                    ClsWriteLog.WriteLog(sPath, "同步数据", "获得截止日期 成功");


                    //0. 清除静态数据
                    sSQL = @"exec CleanData";
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    ClsWriteLog.WriteLog(sPath, "同步数据", "清除静态数据成功");

                    //1. 同步净需求

                    ClsWriteLog.WriteLog(sPath, "同步数据", "净需求 开始");
                    clsGetNetRequirement clsNetRequirement = new clsGetNetRequirement();
                    string sReturn = clsNetRequirement.GetNetRequirement(tran, sVerData, sUid, sPath, dtmEnd);
                    if (sReturn.Trim().Length > 0)
                    {
                        ClsWriteLog.WriteLog(sPath, "同步数据", "净需求 失败：" + sReturn);
                        throw new Exception(sReturn);
                    }
                    else
                    {
                        ClsWriteLog.WriteLog(sPath, "同步数据", "净需求 成功");
                    }

                    //2. 同步当前净需求中Top level的BOM
                    ClsWriteLog.WriteLog(sPath, "同步数据", "BOM 开始");
                    clsGetBOM clsBOM = new DllForTK.clsGetBOM();
                    sReturn = clsBOM.GetBOM(tran, sVerData, sUid, sPath);
                    if (sReturn.Trim().Length > 0)
                    {
                        ClsWriteLog.WriteLog(sPath, "同步数据", "BOM 失败：" + sReturn);
                        throw new Exception(sReturn);
                    }
                    else
                    {
                        ClsWriteLog.WriteLog(sPath, "同步数据", "BOM 成功");
                    }

                    //3. 同步工单
                    ClsWriteLog.WriteLog(sPath, "同步数据", "工单 开始");
                    clsGetWO clsWO = new DllForTK.clsGetWO();
                    sReturn = clsWO.GetWO(tran, sVerData, sUid, sPath, dtmEnd);
                    if (sReturn.Trim().Length > 0)
                    {
                        ClsWriteLog.WriteLog(sPath, "同步数据", "工单 失败：" + sReturn);
                        throw new Exception(sReturn);
                    }
                    else
                    {
                        ClsWriteLog.WriteLog(sPath, "同步数据", "工单 成功");
                    }

                    //4. 同步采购订单
                    ClsWriteLog.WriteLog(sPath, "同步数据", "PO开始");
                    clsGetPO clsPO = new DllForTK.clsGetPO();
                    sReturn = clsPO.GetPO(tran, sVerData, sUid, sPath);
                    if (sReturn.Trim().Length > 0)
                    {
                        ClsWriteLog.WriteLog(sPath, "同步数据", "PO失败：" + sReturn);
                        throw new Exception(sReturn);
                    }
                    else
                    {
                        ClsWriteLog.WriteLog(sPath, "同步数据", "PO成功");
                    }

                    //5. 同步现存量
                    ClsWriteLog.WriteLog(sPath, "同步数据", "仓库存量开始");
                    clsGetCurrentStock clsCurrentStock = new DllForTK.clsGetCurrentStock();
                    sReturn = clsCurrentStock.GetCurrentStock(tran, sVerData, sUid, sPath);
                    if (sReturn.Trim().Length > 0)
                    {
                        ClsWriteLog.WriteLog(sPath, "同步数据", "仓库存量失败：" + sReturn);
                        throw new Exception(sReturn);
                    }
                    else
                    {
                        ClsWriteLog.WriteLog(sPath, "同步数据", "仓库存量成功");
                    }



                    //6. 根据当前工单计算材料需求
                    ClsWriteLog.WriteLog(sPath, "同步数据", "工单材料需求开始");
                    clsGetWOMaterials clsWOMaterials = new clsGetWOMaterials();
                    sReturn = clsWOMaterials.GetWOMaterials(tran, sVerData, sUid, sPath, dtmEnd);
                    if (sReturn.Trim().Length > 0)
                    {
                        ClsWriteLog.WriteLog(sPath, "同步数据", "工单材料需求失败：" + sReturn);
                        throw new Exception(sReturn);
                    }
                    else
                    {
                        ClsWriteLog.WriteLog(sPath, "同步数据", "工单材料需求成功");
                    }

                    //7. 计算物料供需关系
                    ClsWriteLog.WriteLog(sPath, "同步数据", "计算物料供需关系开始");
                    clsSupplyDemand clsSD = new clsSupplyDemand();
                    sReturn = clsSD.SupplyDemand(tran);
                    if (sReturn.Trim().Length > 0)
                    {
                        ClsWriteLog.WriteLog(sPath, "同步数据", "计算物料供需关系失败：" + sReturn);
                        throw new Exception(sReturn);
                    }
                    else
                    {
                        ClsWriteLog.WriteLog(sPath, "同步数据", "计算物料供需关系成功");
                    }

                    //8. 去除没有BOM的净需求
                    sSQL = @"
delete  [TK_NetRequirement_Sum] where sPartID in 
(
	select distinct sPartID
	from [dbo].[TK_NetRequirement_Sum] a
		left join TK_BOM bom on a.sPartID = bom.toplevel
	where bom.toplevel is null 
)
";
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    //9. 获得BOM层级关系，用于按BOM层级顺序显示(跑失败沿用之前的顺序)
                    try
                    {
                        ClsWriteLog.WriteLog(sPath, "同步数据", "计算BOM层级");
                        clsGetBOM clsBOMOrder = new clsGetBOM();
                        clsBOMOrder.Insert(tran);
                        ClsWriteLog.WriteLog(sPath, "同步数据", "计算BOM层级 成功");
                    }
                    catch(Exception ee)
                    {
                        ClsWriteLog.WriteLog(sPath, "同步数据", "计算BOM层级 失败：" + ee.Message);
                    }
                    
                    tran.Commit();

                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                return ee.Message;
            }

            return "";
        }

        /// <summary>
        /// 第一轮计算，按照TK_Thread区分进程执行
        /// </summary>
        public void TrialkittingCalculate()
        {
            try
            {
                //执行状态(iStatus)，0 待执行；1 执行中; 2 执行成功；3 执行失败
                string sSQL = @"
select count(1) as iCou
FROM      _AutoRun
WHERE   (sType = 'BaseData') AND (isnull(iStatus,0) = 1)
";
                DataTable dt = DbHelperSQL.Query(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("加载任务信息失败");
                }
                int iLoadData = BaseFunction.ReturnInt(dt.Rows[0][0]);
                //正在同步静态任务，不执行计算
                if (iLoadData > 0)
                {
                    return;
                }

                sSQL = @"
SELECT   TOP (1) iID, sType, isnull([Description],0) as [Description], iStatus, SetStartTime, dtmStart, dtmEnd, iChkTime, Remark,getdate() as dtmNow
FROM      _AutoRun
WHERE   (sType = 'Trialkitting') AND (iStatus = 0)
ORDER BY iID
";
                dt = DbHelperSQL.Query(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    return;
                }

                int iID = BaseFunction.ReturnInt(dt.Rows[0]["iID"]);
                int iDescription = BaseFunction.ReturnInt(dt.Rows[0]["Description"].ToString().Trim());//BaseData 或者 进程流水号
                DllForTK.Config.ConnString();
                sPath = DbHelperSQL.sLogPath + @"&System-Calculate_" + iDescription.ToString();

                //标记开始执行
                sSQL = @"
update _AutoRun set dtmStart = getdate(),iStatus = 1 where iID = {0}
";
                sSQL = string.Format(sSQL, iID);
                DbHelperSQL.ExecuteSql(sSQL);

                string sTKVersion = "";
                //每天第一轮完整计算
                try
                {
                    clsTrialkitting cls = new clsTrialkitting();
                    string sReturn = cls.Trialkitting(0, "System", sPath, iDescription, out sTKVersion);

                    //执行成功 标记为 2
                    sSQL = @"
update _AutoRun set dtmEnd = getdate() ,iStatus = 2 where iID = {0}
";
                    sSQL = string.Format(sSQL, iID);
                    DbHelperSQL.ExecuteSql(sSQL);
                }
                catch (Exception ee)
                {  
                    //执行失败 标记为 3
                    sSQL = @"
update _AutoRun set dtmEnd = getdate() ,iStatus = 0 where iID = {0}
";
                    sSQL = string.Format(sSQL, iID);
                    DbHelperSQL.ExecuteSql(sSQL);
                }

                try
                {
                    if (sTKVersion != string.Empty)
                    {
                        //生成buy的计划数据--将NetQty-CurrQty
                        BuyerNetQty_BuyerData cls = new BuyerNetQty_BuyerData();
                        cls.BuyerNetQty_BuyerCalculateCalculate(sTKVersion);

                        //生成buy明细数据
                        BuyerGatingData cls2 = new BuyerGatingData();
                        cls2.BuyGatingCalculate(sTKVersion);

                        //生成pm明数据
                        PMGatingData cls3 = new PMGatingData();
                        cls3.PMGatingDataCalculate(sTKVersion);
                    }
                }
                catch (Exception ee)
                { }
            }
            catch (Exception ee)
            {
              
                //throw new Exception("获得任务清单失败");
            }
        }
    }
}
