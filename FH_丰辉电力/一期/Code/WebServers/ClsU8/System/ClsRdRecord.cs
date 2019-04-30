using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using ClsBaseClass;

namespace ClsU8
{
    public class ClsRdRecord
    {
        string tablename = "RdRecord";
        string tablenames = "RdRecords";
        string tableid = "iID";
        string tableids = "AutoID";
        string Code = "cRdCode";
        string sSQL = "";
        protected ClsGetSQL clsGetSQL = ClsGetSQL.Instance();
        protected ClsDataBase clsSQLCommond = ClsDataBaseFactory.Instance();
        protected SerialNumber serialNumber = new SerialNumber();
        public string dtList(string iCode1, string iCode2, string dDate1, string dDate2, string cInvCode1, string cInvCode2, string cRsCode)
        {
            string s = "";
            try
            {
                sSQL = "select *,convert(varchar(10),dDate,120) as 单据日期, 'edit' as iSave from " + tablename + " a left join " + tablenames + " b on a." + tableid + "=b." + tableid + " where 1=1 and cRsCode='" + cRsCode + "'";
                if (iCode1 != "")
                {
                    sSQL = sSQL + " and a.cRdCode>='" + iCode1 + "'";
                }
                if (iCode2 != "")
                {
                    sSQL = sSQL + " and a.cRdCode<='" + iCode2 + "'";
                }
                if (dDate1 != "")
                {
                    sSQL = sSQL + " and convert(varchar(10),dDate,120)>='" + DateTime.Parse(dDate1).ToString("yyyy-MM-dd") + "'";
                }
                if (dDate2 != "")
                {
                    sSQL = sSQL + " and convert(varchar(10),dDate,120)<='" + DateTime.Parse(dDate2).ToString("yyyy-MM-dd") + "'";
                }
                if (cInvCode1 != "")
                {
                    sSQL = sSQL + " and cInvCode>='" + cInvCode1 + "'";
                }
                if (cInvCode2 != "")
                {
                    sSQL = sSQL + " and cInvCode<='" + cInvCode2 + "'";
                }
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                dt.TableName = tablename;
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string dt(int type, string iID, string cRsCode)
        {
            string s = "";

            try
            {
                switch (type)
                {
                    case 0:
                        sSQL = "select *, 'edit' as iSave,'' as sState from " + tablename + " where " + tableid + "='" + iID + "' and cRsCode='" + cRsCode + "'";
                        break;
                    case 1:
                        sSQL = @"select a.cInvCode,b.AutoID, b.iID, b.iQuantity, b.SQty, b.Remark
,case when b.iID is not null then 'edit' else '' end iSave from Inventory a left join 
(select * from " + tablenames + " where iID='" + iID + "') b on a.cInvCode=b.cInvCode ";
                        break;
                }
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                dt.TableName = tablename;

                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string dtnew(int type)
        {
            string s = "";

            try
            {
                switch (type)
                {
                    case 0:
                        sSQL = "select *, 'edit' as iSave,'' as sState from " + tablename + " where 1=-1";
                        break;
                    case 1:
                        sSQL = @"select a.cInvCode,b.AutoID, b.iID, b.iQuantity, b.SQty,  b.Remark
,case when b.iID is not null then 'edit' else '' end iSave from Inventory a left join 
(select * from " + tablenames + " where 1=-1 ) b on a.cInvCode=b.cInvCode ";
                        break;
                }

                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                switch (type)
                {
                    case 0:
                        dt.TableName = tablename;
                        break;
                    case 1:
                        dt.TableName = tablenames;
                        break;
                }
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string siID(int type, string iID,string cRsCode)
        {
            string s = "";

            try
            {
                if (type == 1)
                {
                    sSQL = "select min(" + tableid + ") as iID from " + tablename + " where 1=1 and cRsCode='" + cRsCode + "'";
                }
                else if (type == 2)
                {
                    sSQL = "select " + tableid + " from " + tablename + " where " + tableid + "<'" + iID + "' and cRsCode='" + cRsCode + "' order by " + tableid + " desc";
                }
                else if (type == 3)
                {
                    sSQL = "select " + tableid + " from " + tablename + " where " + tableid + ">'" + iID + "' and cRsCode='" + cRsCode + "' order by " + tableid + " ";
                }
                else if (type == 4)
                {
                    sSQL = "select max(" + tableid + ") as iID from " + tablename + " where 1=1 and cRsCode='" + cRsCode + "'";
                }
                s = clsSQLCommond.ExecGetScalar(sSQL).ToString();
            }
            catch (Exception ee)
            {
                s = "-1";
            }
            return s;
        }

        public string save(string uid, DataTable dtHead, DataTable dtGrid, string del)
        {
            string sErr = "";
            ArrayList aList = new ArrayList();
            try
            {
                long iID;
                #region 生成表头
                sSQL = "select * from " + tablename + " where 1=-1";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                sSQL = "select isnull(count(*),0) from Project where cCode='" + dtHead.Rows[0]["PCode"].ToString() + "' ";
                long count = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                if (count == 0)
                {
                    throw new Exception("未找到工程 " + dtHead.Rows[0]["PCode"].ToString());
                }

                DataRow dr = dtHead.NewRow();
                if (dtHead.Rows[0]["iID"].ToString().Trim() != "")
                {
                    dr["iID"] = dtHead.Rows[0]["iID"];
                    iID = long.Parse(dtHead.Rows[0]["iID"].ToString());
                    dr["cRdCode"] = dtHead.Rows[0]["cRdCode"].ToString().Trim();
                    dr["dModifyTime"] = DateTime.Now.ToString();
                    dr["dModifyPerson"] = uid;
                    dr["dCreateTime"] = dtHead.Rows[0]["dCreateTime"].ToString().Trim();
                    dr["dCreatePerson"] = dtHead.Rows[0]["dCreatePerson"].ToString().Trim();
                }
                else
                {
                    sSQL = "select isnull(max(iID)+1,1) as iID from " + tablename;
                    iID = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                    dr["cRdCode"] = serialNumber.GetNewSerialNumberContinuous(tablename, "cRdCode");
                    dr["iID"] = iID;
                    dr["dCreateTime"] = DateTime.Now.ToString();
                    dr["dCreatePerson"] = uid;
                    string sState = dtHead.Rows[0]["sState"].ToString().Trim();
                    int iRe = CheState(iID.ToString());
                    if (iRe == -1)
                    {
                        throw new Exception("检查单据状态出错");
                    }
                    if (iRe == 0 && (sState == "edit" || sState == "alter"))
                    {
                        throw new Exception("单据不存在");
                    }
                    if (iRe == 1 && sState == "alter")
                    {
                        throw new Exception("单据未审核");
                    }
                    if (iRe == 2 && sState == "edit")
                    {
                        throw new Exception("单据已审核");
                    }
                    //if (iRe == 3)
                    //{
                    //    throw new Exception("单据已关闭");
                    //}
                }
                dr["cRSCode"] = dtHead.Rows[0]["cRSCode"];
                dr["PCode"] = dtHead.Rows[0]["PCode"];
                dr["dDate"] = dtHead.Rows[0]["dDate"];

                dr["Remark"] = dtHead.Rows[0]["Remark"].ToString().Trim();

                dtHead.Rows.Add(dr);
                if (dtHead.Rows[0]["iSave"].ToString().Trim() == "update")
                {
                    sSQL = clsGetSQL.GetUpdateSQL(ClsBaseDataInfo.sDataBaseName, tablename, dtHead, dtHead.Rows.Count - 1);
                    aList.Add(sSQL);
                }
                if (dtHead.Rows[0]["iSave"].ToString().Trim() == "add")
                {
                    sSQL = clsGetSQL.GetInsertSQL(ClsBaseDataInfo.sDataBaseName, tablename, dtHead, dtHead.Rows.Count - 1);
                    aList.Add(sSQL);
                }
                #endregion

                #region dtGrid
                string[] strdel = del.Trim().Split(',');
                for (int i = 0; i < strdel.Length; i++)
                {
                    if (strdel[i].Trim() != "")
                    {
                        sSQL = "delete  from " + tablenames + " where " + tableids + " ='" + strdel[i] + "'";
                        aList.Add(sSQL);
                    }
                }
                sSQL = "select * from " + tablenames + " where 1=-1";
                DataTable dts = clsSQLCommond.ExecQuery(sSQL);
                sSQL = "select isnull(max(" + tableids + ")+1,1) as AutoID from " + tablenames;
                long AutoID = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                long iCount = 0;
                string cRSCode = dtHead.Rows[0]["cRSCode"].ToString().Trim();
                for (int i = 0; i < dtGrid.Rows.Count; i++)
                {
                    if (dtGrid.Rows[i].RowState != DataRowState.Deleted)
                    {
                        iCount = iCount + 1;
                    }
                    if (dtGrid.Rows[i].RowState != DataRowState.Deleted && (dtGrid.Rows[i]["iSave"].ToString().Trim() == "update" || dtGrid.Rows[i]["iSave"].ToString().Trim() == "add"))
                    {
                        #region 判断
                        if (dtGrid.Rows[i]["cInvCode"].ToString().Trim() == "")
                        {
                            continue;
                        }
                        if (dtGrid.Rows[i]["cInvCode"].ToString().Trim() == "")
                        {
                            sErr = sErr + dtGrid.TableName + "行" + (i + 1) + "存货编码不能为空\n";
                            continue;
                        }
                        if (dtGrid.Rows[i]["iQuantity"].ToString().Trim() == "")
                        {
                            if (cRSCode == "01")
                            {
                                sErr = sErr + dtGrid.TableName + "行" + (i + 1) + "实盘数量不能为空\n";
                            }
                            else if (dtHead.Rows[0]["cRSCode"].ToString().Trim() == "02")
                            {
                                sErr = sErr + dtGrid.TableName + "行" + (i + 1) + "退料数量不能为空\n";
                            }
                            else if (dtHead.Rows[0]["cRSCode"].ToString().Trim() == "03")
                            {
                                sErr = sErr + dtGrid.TableName + "行" + (i + 1) + "出库数量不能为空\n";
                            }
                            else
                            {
                                sErr = sErr + dtGrid.TableName + "行" + (i + 1) + "数量不能为空\n";
                            }
                            continue;
                        }
                        #endregion
                        
                        #region 生成table
                        DataRow dw = dts.NewRow();
                        if (dtGrid.Rows[i]["iID"].ToString().Trim() != "")
                        {
                            dw["iID"] = dtGrid.Rows[i]["iID"].ToString().Trim();
                            dw["AutoID"] = dtGrid.Rows[i]["AutoID"].ToString().Trim();
                        }
                        else
                        {
                            dw["iID"] = iID;
                            dw["AutoID"] = AutoID;
                            AutoID = AutoID + 1;
                        }
                        dw["cInvCode"] = dtGrid.Rows[i]["cInvCode"];
                        dw["SQty"] = dtGrid.Rows[i]["SQty"];
                        dw["iQuantity"] = dtGrid.Rows[i]["iQuantity"];

                        dw["Remark"] = dtGrid.Rows[i]["Remark"];

                        dts.Rows.Add(dw);


                        #endregion

                        if (dtGrid.Rows[i]["iSave"].ToString().Trim() == "update")
                        {
                            sSQL = clsGetSQL.GetUpdateSQL(ClsBaseDataInfo.sDataBaseName, tablenames, dts, dts.Rows.Count - 1);
                            aList.Add(sSQL);
                        }
                        if (dtGrid.Rows[i]["iSave"].ToString().Trim() == "add")
                        {
                            sSQL = clsGetSQL.GetInsertSQL(ClsBaseDataInfo.sDataBaseName, tablenames, dts, dts.Rows.Count - 1);
                            aList.Add(sSQL);
                        }
                        
                    }
                }
                #endregion
                if (iCount == 0)
                {
                    sErr = sErr + "表体不能为空\n";
                }
                if (sErr != "")
                {
                    throw new Exception(sErr);
                }
                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);
                }
            }
            catch (Exception ee)
            {
                sErr = ee.Message;
            }
            if (sErr == "")
            {
                return "ok";
            }
            else
            {
                return sErr;
            }
        }

        public string del(string iID)
        {
            string sErr = "";
            ArrayList aList = new ArrayList();
            try
            {
                if (iID == "")
                {
                    throw new Exception("请选择需删除的单据");
                }

                int iRe = CheState(iID);
                if (iRe == -1)
                {
                    throw new Exception("检查单据状态出错");
                }
                if (iRe == 0)
                {
                    throw new Exception("单据不存在");
                }
                //if (iRe == 1)
                //{
                //    throw new Exception("单据已保存");
                //} 
                if (iRe == 2)
                {
                    throw new Exception("单据已审核");
                }
                //if (iRe == 3)
                //{
                //    throw new Exception("单据已关闭");
                //}
                sSQL = "delete " + tablename + " where iID = '" + iID + "' ";
                aList.Add(sSQL);
                sSQL = "delete " + tablenames + " where iID = '" + iID + "' ";
                aList.Add(sSQL);
                if (sErr != "")
                {
                    throw new Exception(sErr);
                }
                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);
                }
            }
            catch (Exception ee)
            {
                sErr = sErr + ee.Message;
            }
            if (sErr == "")
            {
                return "ok";
            }
            else
            {
                return sErr;
            }
        }

        public string edit(string iID)
        {
            string sErr = "";
            ArrayList aList = new ArrayList();
            try
            {
                if (iID == "")
                {
                    throw new Exception("请选择需要修改的单据");
                }

                int iRe = CheState(iID);
                if (iRe == -1)
                {
                    throw new Exception("检查单据状态出错");
                }
                if (iRe == 0)
                {
                    throw new Exception("单据不存在");
                }
                //if (iRe == 1)
                //{
                //    throw new Exception("单据已保存");
                //} 
                if (iRe == 2)
                {
                    throw new Exception("单据已审核");
                }
                //if (iRe == 3)
                //{
                //    throw new Exception("单据已关闭");
                //}
                return sErr;
            }
            catch (Exception ee)
            {
                sErr = ee.Message;
            }
            return sErr;
        }

        public decimal NowQty(string cInvCode)
        {
            ArrayList aList = new ArrayList();
            try
            {
                sSQL = "select sum(Qty) from (select ISNULL(InQty,0)-ISNULL(OutQty,0) as Qty from ProjectRecord where cInvCode='" + cInvCode + "' union all select iQuantity from RdRecords where cInvCode='" + cInvCode + "') a";
                aList.Add(sSQL);
                if (aList.Count > 0)
                {
                    string qty = clsSQLCommond.ExecGetScalar(sSQL).ToString();
                    if (qty != "")
                    {
                        return decimal.Parse(qty);
                    }
                }
            }
            catch (Exception ee)
            {
                return -1;
            }
            return 0;
        }

        public string audit(string iID, string uid)
        {
            string sErr = "";
            ArrayList aList = new ArrayList();
            try
            {
                if (iID == "")
                {
                    throw new Exception("请选择需要审核的单据");
                }

                int iRe = CheState(iID);
                if (iRe == -1)
                {
                    throw new Exception("检查单据状态出错");
                }
                if (iRe == 0)
                {
                    throw new Exception("单据不存在");
                }
                //if (iRe == 1)
                //{
                //    throw new Exception("单据已保存");
                //} 
                if (iRe == 2)
                {
                    throw new Exception("单据已审核");
                }
                //if (iRe == 3)
                //{
                //    throw new Exception("单据已关闭");
                //}
                sSQL = "update " + tablename + " set dVerifyTime=getdate(),dVerifyPerson='" + uid + "' where " + tableid + "=" + iID + "";
                aList.Add(sSQL);
                sSQL = "select * from " + tablename + " a left join " + tablenames + " b on a.iID=b.iID where a." + tableid + "=" + iID + "  ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("未找到相关单据");
                }

                //sSQL = "select * from ProjectRecord where 1=-1";
                //DataTable dtRecord = clsSQLCommond.ExecQuery(sSQL);
                //sSQL = "select isnull(max(AutoID)+1,1) as AutoID from ProjectRecord";
                //long AutoIDRecord = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));

                //string piID = "";
                //sSQL = "select * from  Project b left join ProjectRecord a  on a.iID=b.iID where b.cCode='" + dt.Rows[0]["PCode"].ToString() + "' ";
                //DataTable dtp = clsSQLCommond.ExecQuery(sSQL);
                //if (dtp.Rows.Count > 0)
                //{
                //    piID = dtp.Rows[0]["iID"].ToString();
                //}
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    string cInvCode = dt.Rows[i]["cInvCode"].ToString();
                //    string cCode = dt.Rows[i]["PCode"].ToString();
                //    string cRSCode = dt.Rows[i]["cRSCode"].ToString();
                    
                //    string Col = "";
                //    if (cRSCode == "11")//出库单
                //    {
                //        Col = "OutQty";
                //    }
                //    else if (cRSCode == "02")//退库单
                //    {
                //        Col = "RQty";
                //    }
                //    if (Col != "")
                //    {
                //        decimal iQuantity = decimal.Parse(dt.Rows[i]["iQuantity"].ToString());
                //        if (iQuantity != 0)
                //        {
                //            DataRow[] dw = dtp.Select("cCode='" + cCode + "' and cInvCode='" + cInvCode + "'");
                //            if (dw.Length == 0)
                //            {
                //                DataRow dwr = dtRecord.NewRow();
                //                dwr["iID"] = piID;
                //                dwr["AutoID"] = AutoIDRecord;
                //                dwr["dCreateTime"] = DateTime.Now.ToString();
                //                dwr["dCreatePerson"] = uid;
                //                AutoIDRecord = AutoIDRecord + 1;
                //                dwr["cInvCode"] = cInvCode;
                //                dtRecord.Rows.Add(dwr);
                //                sSQL = clsGetSQL.GetInsertSQL(ClsBaseDataInfo.sDataBaseName, "ProjectRecord", dtRecord, dtRecord.Rows.Count - 1);
                //                aList.Add(sSQL);
                //            }
                //            sSQL = "update ProjectRecord set " + Col + "=isnull(" + Col + ",0)+" + iQuantity + ",EndQty=isnull(EndQty,0)+" + iQuantity + "  where iID='" + piID + "' and cInvCode='" + cInvCode + "'";
                //            aList.Add(sSQL);
                //        }
                //    }
                //}
                if (sErr != "")
                {
                    throw new Exception(sErr);
                }
                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);
                }
                return sErr;
            }
            catch (Exception ee)
            {
                sErr = ee.Message;
            }
            return sErr;
        }

        public string unAudit(string iID)
        {
            string sErr = "";
            ArrayList aList = new ArrayList();
            try
            {
                if (iID == "")
                {
                    throw new Exception("请选择需要弃审的单据");
                }

                int iRe = CheState(iID);
                if (iRe == -1)
                {
                    throw new Exception("检查单据状态出错");
                }
                if (iRe == 0)
                {
                    throw new Exception("单据不存在");
                }
                if (iRe == 1)
                {
                    throw new Exception("单据未审核");
                }
                //if (iRe == 2)
                //{
                //    throw new Exception("单据已审核");
                //}
                //if (iRe == 3)
                //{
                //    throw new Exception("单据已关闭");
                //}
                sSQL = "update " + tablename + " set dVerifyTime=null,dVerifyPerson=null where " + tableid + "=" + iID + "";
                aList.Add(sSQL);

                sSQL = "select * from " + tablename + " a left join " + tablenames + " b on a.iID=b.iID where a." + tableid + "=" + iID + "  ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("未找到相关单据");
                }

                //sSQL = "select * from ProjectRecord a left join Project b on a.iID=b.iID where b.cCode='" + dt.Rows[0]["PCode"].ToString() + "' ";
                //DataTable dtp = clsSQLCommond.ExecQuery(sSQL);
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    string cInvCode = dt.Rows[i]["cInvCode"].ToString();
                //    string cCode = dt.Rows[i]["PCode"].ToString();
                //    string cRSCode = dt.Rows[i]["cRSCode"].ToString();
                //    string Col = "";
                //    if (cRSCode == "11")//出库单
                //    {
                //        Col = "OutQty";
                //    }
                //    else if (cRSCode == "02")//退库单
                //    {
                //        Col = "RQty";
                //    }
                //    if (Col != "")
                //    {
                //        decimal iQuantity = decimal.Parse(dt.Rows[i]["iQuantity"].ToString());
                //        if (iQuantity != 0)
                //        {
                //            DataRow[] dw = dtp.Select("cCode='" + cCode + "' and cInvCode='" + cInvCode + "'");
                //            if (dw.Length > 0)
                //            {
                //                string siID = dw[0]["iID"].ToString();
                //                sSQL = "update ProjectRecord set " + Col + "=isnull(" + Col + ",0)-" + iQuantity + ",EndQty=isnull(EndQty,0)-" + iQuantity + "  where iID='" + siID + "' and cInvCode='" + cInvCode + "'";
                //                aList.Add(sSQL);
                //            }
                //            else
                //            {
                //                sErr = sErr + "存货编码：" + cInvCode + " 入库数量不能为空\n";
                //            }
                //        }
                //    }
                //}

                if (sErr != "")
                {
                    throw new Exception(sErr);
                }
                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);
                }
                return sErr;
            }
            catch (Exception ee)
            {
                sErr = ee.Message;
            }
            return sErr;
        }

        /// <summary>
        /// 判断单据状态
        /// </summary>
        /// <param name="sCode">单据号</param>
        /// <returns>-1：出错</returns>
        /// <returns>0 ：不存在单据</returns>
        /// <returns>1 ：已保存</returns>
        /// <returns>2 ：已审核</returns>
        /// <returns>3 ：已关闭</returns>
        private int CheState(string iID)
        {
            int iReturn = -1;
            try
            {
                sSQL = "select  isnull(dCreatePerson,'') as 制单人,isnull(dVerifyPerson,'') as 审核人 from " + tablename + " where " + tableid + " = '" + iID + "'";
                DataTable dtTable = clsSQLCommond.ExecQuery(sSQL);
                if (dtTable == null || dtTable.Rows.Count < 1)
                    iReturn = 0;
                else
                {
                    if (dtTable.Rows[0]["制单人"].ToString().Trim() != "")
                    {
                        iReturn = 1;
                    }
                    if (dtTable.Rows[0]["审核人"].ToString().Trim() != "")
                    {
                        iReturn = 2;
                    }
                }
            }
            catch (Exception ee)
            { }
            return iReturn;
        }
    }
}
