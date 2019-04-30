using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using ClsBaseClass;

namespace ClsU8
{
    public class ClsMonthRdRecord
    {
        string tablename = "MonthRdRecord";
        string tablenames = "MonthRdRecords";
        string tableid = "iID";
        string tableids = "AutoID";
        string Code = "mRdCode";
        string sSQL = "";
        protected ClsGetSQL clsGetSQL = ClsGetSQL.Instance();
        protected ClsDataBase clsSQLCommond = ClsDataBaseFactory.Instance();
        protected SerialNumber serialNumber = new SerialNumber();
        public string dtList(string iCode1, string iCode2, string dDate1, string dDate2, string cInvCode1, string cInvCode2)
        {
            string s = "";
            try
            {
                sSQL = "select *,convert(varchar(10),dDate,120) as 单据日期, 'edit' as iSave from " + tablename + " a left join " + tablenames + " b on a." + tableid + "=b." + tableid + " where 1=1 ";
                if (iCode1 != "")
                {
                    sSQL = sSQL + " and a.mRdCode>='" + iCode1 + "'";
                }
                if (iCode2 != "")
                {
                    sSQL = sSQL + " and a.mRdCode<='" + iCode2 + "'";
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

        public string dt(int type, string iID)
        {
            string s = "";

            try
            {
                switch (type)
                {
                    case 0:
                        sSQL = "select *, 'edit' as iSave from " + tablename + " where " + tableid + "='" + iID + "' ";
                        break;
                    case 1:
                        sSQL = @"select a.cInvCode,b.AutoID, b.iID, b.iQuantity, b.Remark
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
                        sSQL = "select *, 'edit' as iSave from " + tablename + " where 1=-1";
                        break;
                    case 1:
                        sSQL = @"select a.cInvCode,b.AutoID, b.iID, b.iQuantity, b.Remark
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

        public string siID(int type, string iID)
        {
            string s = "";

            try
            {
                if (type == 1)
                {
                    sSQL = "select min(" + tableid + ") as iID from " + tablename + " where 1=1 ";
                }
                else if (type == 2)
                {
                    sSQL = "select " + tableid + " from " + tablename + " where " + tableid + "<'" + iID + "' order by " + tableid + " desc";
                }
                else if (type == 3)
                {
                    sSQL = "select " + tableid + " from " + tablename + " where " + tableid + ">'" + iID + "' order by " + tableid + " ";
                }
                else if (type == 4)
                {
                    sSQL = "select max(" + tableid + ") as iID from " + tablename + " where 1=1 ";
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

                DataRow dr = dtHead.NewRow();
                if (dtHead.Rows[0]["iID"].ToString().Trim() != "")
                {
                    dr["iID"] = dtHead.Rows[0]["iID"];
                    iID = long.Parse(dtHead.Rows[0]["iID"].ToString());
                    dr["mRdCode"] = dtHead.Rows[0]["mRdCode"].ToString().Trim();
                    dr["dModifyTime"] = DateTime.Now.ToString();
                    dr["dModifyPerson"] = uid;
                    dr["dCreateTime"] = dtHead.Rows[0]["dCreateTime"].ToString().Trim();
                    dr["dCreatePerson"] = dtHead.Rows[0]["dCreatePerson"].ToString().Trim();
                }
                else
                {
                    sSQL = "select isnull(max(iID)+1,1) as iID from " + tablename;
                    iID = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                    dr["mRdCode"] = serialNumber.GetNewSerialNumberContinuous(tablename, "mRdCode");
                    dr["iID"] = iID;
                    dr["dCreateTime"] = DateTime.Now.ToString();
                    dr["dCreatePerson"] = uid;
                }
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
                            sErr = sErr + dtGrid.TableName + "行" + (i + 1) + "数量不能为空\n";
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

        //public decimal NowQty(string cInvCode)
        //{
        //    ArrayList aList = new ArrayList();
        //    try
        //    {
        //        sSQL = "select sum(Qty) from (select ISNULL(InQty,0)-ISNULL(OutQty,0)+ISNULL(RQty,0) as Qty from ProjectRecord where cInvCode='" + cInvCode + "' union all select AQty from RdRecords where cInvCode='" + cInvCode + "') a";
        //        aList.Add(sSQL);
        //        if (aList.Count > 0)
        //        {
        //            string qty = clsSQLCommond.ExecGetScalar(sSQL).ToString();
        //            if (qty != "")
        //            {
        //                return decimal.Parse(qty);
        //            }
        //        }
        //    }
        //    catch (Exception ee)
        //    {
        //    }
        //    return 0;
        //}
    }
}
