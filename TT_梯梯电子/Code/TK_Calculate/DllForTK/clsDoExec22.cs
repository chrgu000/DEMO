using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TH.BaseClass;
using System.Data.SqlClient;
using System.Xml;

namespace DllForTK
{
    public class clsDoExec
    {
        public clsDoExec()
        {
            DllForTK.Config.ConnString();
        }

        /// <summary>
        /// 系统定时任务。
        /// 同步静态数据，进行第一轮计算
        /// </summary>
        /// <param name="sPath">日志路径</param>
        public void doAutorun(string sPath)
        {
            #region 清除失败的系统任务

            try
            {
                ClsWriteLog.WriteLog(sPath, "清除失败的系统任务", "开始");
                //DllForTK.Config.ConnString();

                string sSQL = @"
update _AutoRun set dtmEnd = DATEADD(hour, iChkTime, dtmStart)
WHERE   (dtmStart > dtmEnd) AND (DATEADD(hour, iChkTime, dtmStart) < GETDATE())
";
                int iCou = DbHelperSQL.ExecuteSql(sSQL);
                if (iCou > 0)
                {
                    throw new Exception("清除失败的系统任务");
                }
                ClsWriteLog.WriteLog(sPath, "清除失败的系统任务", "成功");
            }
            catch (Exception ee)
            {
                ClsWriteLog.WriteLog(sPath, "清除失败的系统任务", "失败：" + ee.Message);
            }

            #endregion

            #region 执行系统定时任务：定时同步静态数据，并计算第一版
            try
            {
                string sSQL = @"
SELECT   iID, Description, SetStartTime, dtmStart, dtmEnd, Remark,getdate() as dtmNow
FROM      _AutoRun  WITH (nolock)
WHERE   1=1
order by iID
";
                DataTable dt = DbHelperSQL.Query(sSQL);

                int iID = BaseFunction.ReturnInt(dt.Rows[0]["iID"]);
                DateTime dtmNow = BaseFunction.ReturnDate(dt.Rows[0]["dtmNow"]);
                DateTime dtmRumTime = BaseFunction.ReturnDate(dt.Rows[0]["SetStartTime"]);
                DateTime dTime = BaseFunction.ReturnDate(dtmNow.ToString("yyyy-MM-dd") + " " + dtmRumTime.ToString("HH:mm:ss"));
                DateTime dtmStart = BaseFunction.ReturnDate(dt.Rows[0]["dtmStart"]);
                DateTime dtmEnd = BaseFunction.ReturnDate(dt.Rows[0]["dtmEnd"]);
                
                if (dtmStart <= dTime || dtmStart > dtmEnd)
                {
                    sSQL = @"
update _AutoRun set dtmStart = getdate() where iID = {0}
";
                    sSQL = string.Format(sSQL, iID);
                    DbHelperSQL.ExecuteSql(sSQL);

                    
                    ClsWriteLog.WriteLog(sPath, "同步数据", "同步静态数据开始");
                    ClsWriteLog.WriteLog(sPath, "同步数据", "清除静态数据开始");
                    //清除静态数据
                    clsCleanData cls = new DllForTK.clsCleanData();
                    string sReturn = cls.CleanData();
                    if (sReturn == "")
                    {
                        ClsWriteLog.WriteLog(sPath, "同步数据", "清除静态数据成功");
                    }
                    else
                    {
                        ClsWriteLog.WriteLog(sPath, "同步数据", "清除静态数据失败：" + sReturn);
                    }

                    //同步静态数据
                    ClsWriteLog.WriteLog(sPath, "同步数据", "同步静态数据开始");
                    sReturn = LoadBaseData("system", sPath);
                    if (sReturn == "")
                    {
                        ClsWriteLog.WriteLog(sPath, "同步数据", "同步静态数据成功");
                    }
                    else
                    {
                        ClsWriteLog.WriteLog(sPath, "同步数据", "同步静态数据失败：" + sReturn);
                    }
                    //每天第一轮完整计算
                    //Trialkitting(0, "system");

                    sSQL = @"
update _AutoRun set dtmEnd = getdate() where iID = {0}
";
                    sSQL = string.Format(sSQL, iID);
                    DbHelperSQL.ExecuteSql(sSQL);
                }

                if (dt == null)
                {
                    throw new Exception("获得任务清单失败");
                }



            }
            catch (Exception ee)
            {

            }
            #endregion
        }
        
        public void doExec(string sPath)
        {
            try
            {
                //DllForTK.Config.ConnString();
                
                #region 执行人员触发任务：同步静态数据，按照项目组计算
                try
                {
                    //每次只启动一件任务
                    string sSQL = @"
SELECT top 1  iID, sType, dDate, sVerData, sVerTrialkitting, ProdGroup, Planner, iState, sResult, Remark, CreateUid, 
                dtmCreate, dtmStart, dtmEnd
FROM      TK_List WITH (nolock)
WHERE   (ISNULL(iState, 0) = 0)
ORDER BY iID
";
                    DataTable dt = DbHelperSQL.Query(sSQL);

                    if (dt == null || dt.Rows.Count != 0)
                    {
                        //没有数据
                    }

                    //for (int i = 0; i < dt.Rows.Count; i++)
                    //{
                    //标记为执行状态
                    sSQL = @"
update TK_List set iState = 1,dtmStart = getdate() where iID = {0}
";
                    sSQL = string.Format(sSQL, dt.Rows[0]["iID"]);
                    DbHelperSQL.ExecuteSql(sSQL);

                    string sUid = dt.Rows[0]["CreateUid"].ToString().Trim();
                    try
                    {
                        string sReturn = "";
                        switch (dt.Rows[0]["sType"].ToString().Trim().ToLower())
                        {
                            case "basedata":

                                sReturn = LoadBaseData(sUid, sPath);
                                if (sReturn.Trim().Length > 0)
                                {
                                    throw new Exception("iID ：" + dt.Rows[0]["iID"] + "执行失败");
                                }

                                break;

                            case "trialkitting":

                                sReturn = Trialkitting(BaseFunction.ReturnLong(dt.Rows[0]["iID"]), sUid, sPath);
                                if (sReturn.Trim().Length > 0)
                                {
                                    throw new Exception("iID ：" + dt.Rows[0]["iID"] + "执行失败");
                                }
                                break;

                        }

                        sSQL = @"
update TK_List set iState = 2,Remark = '',dtmEnd = getdate() where iID = {0}
";
                        sSQL = string.Format(sSQL, dt.Rows[0]["iID"]);
                        DbHelperSQL.ExecuteSql(sSQL);

                    }
                    catch (Exception ee)
                    {
                        string sRe = ee.Message;
                        if (sRe.Length > 500)
                        {
                            sRe = sRe.Substring(0, 500);
                        }
                        sSQL = @"
update TK_List set dtmEnd = 3,Remark = '{1}' where iID = {0}
";
                        sSQL = string.Format(sSQL, dt.Rows[0]["iID"], sRe);
                        DbHelperSQL.ExecuteSql(sSQL);
                    }
                    //}
                }
                catch (Exception ee)
                {
                    throw new Exception(ee.Message);
                }
                #endregion
            }
            catch (Exception ee)
            {
                    
            }
        }

        /// <summary>
        /// 同步净需求、工单、采购订单、仓库存量
        /// </summary>
        /// <returns></returns>
        public string LoadBaseData(string sUid,string sPath)
        {
            try
            {
                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    string sSQL = @"
select getdate()
";
                    DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    string sVerData = BaseFunction.ReturnDate(dtTemp.Rows[0][0]).ToString("yyyyMMddHHmmss");
                    if (sUid.ToLower().Trim() == "system")
                    {
                        sVerData = BaseFunction.ReturnDate(dtTemp.Rows[0][0]).ToString("yyyyMMdd000000");
                    }

                    //DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    //1. 同步净需求

                    ClsWriteLog.WriteLog(sPath, "同步数据", "净需求 开始");
                    clsGetNetRequirement clsNetRequirement = new clsGetNetRequirement();
                    string sReturn = clsNetRequirement.GetNetRequirement(tran, sVerData, sUid, sPath);
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
                    sReturn = clsWO.GetWO(tran, sVerData, sUid, sPath);
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
                    sReturn = clsWOMaterials.GetWOMaterials(tran, sVerData, sUid, sPath);
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

                    tran.Commit();
                }
                catch (Exception ee)
                {
                    tran.Rollback();
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
        /// 根据现有物料计算产品齐套，并算出齐套日期
        /// </summary>
        /// <param name="iID">TK_List 表中iID数据：0：每天定时任务计算的版本；其他数字：从TK_List表中取的计算状态</param>
        /// <param name="sUid">提交计算人</param>
        /// <returns></returns>
        public string Trialkitting(long iID, string sUid,string sPath)
        {
            try
            {
                ClsWriteLog.WriteLog(sPath, "计算", "开始");
                //执行计算
                clsTrialkitting cls = new DllForTK.clsTrialkitting();
                string sReturn = cls.Trialkitting(iID, sUid, sPath);
                if (sReturn == "")
                {
                    ClsWriteLog.WriteLog(sPath, "计算", "成功");
                }
                else
                {
                    ClsWriteLog.WriteLog(sPath, "计算", "失败：" + sReturn);
                }
            }
            catch (Exception ee)
            {
                return ee.Message;
            }
            return "";
        }
    }
}
