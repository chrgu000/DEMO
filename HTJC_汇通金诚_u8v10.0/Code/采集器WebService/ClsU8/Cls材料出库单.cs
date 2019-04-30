using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using ClsBaseClass;

namespace ClsU8
{
    public class Cls材料出库单
    {
        public string Save材料出库单(DataTable dtData)
        {
            string s = "";
            try
            {
                string sErr = "";

                if (dtData == null || dtData.Rows.Count < 1)
                    throw new Exception("没有需要保存的数据");

                SqlConnection conn = new SqlConnection(ClsBaseClass.ClsBaseDataInfo.sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    string sSQL = "select getdate()";
                    DateTime d当前服务器时间 = Convert.ToDateTime(SqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));

                    //1.   判断是否结账
                    sSQL = "select * from gl_mend where iyear=year(getdate()) and iperiod=month(getdate())";
                    DataTable dtTemp = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp == null || dtTemp.Rows.Count < 1)
                    {
                        throw new Exception("判断模块结账失败");
                    }
                    int iR = ClsBaseDataInfo.ReturnObjectToInt(dtTemp.Rows[0]["bflag_ST"]);
                    if (iR == 1)
                    {
                        throw new Exception("当前月份已经结账");
                    }


                    //2. 获得单据ID
                    long lID = 1;
                    long lIDDetail = 1;
                    ClsU8基础档案 cls = new ClsU8基础档案();
                    cls.GetRdID(out lID, out lIDDetail, ClsBaseDataInfo.sUFDataBaseName.Trim().Substring(7, 3));


                    //3. 获得单据号
                    long iCode = 0;
                    sSQL = "select * From VoucherHistory  with (ROWLOCK) Where  CardNumber='0412'";
                    dtTemp = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp == null || dtTemp.Rows.Count < 1)
                    {
                        iCode = 1;
                    }
                    else
                    {
                        iCode = ClsBaseDataInfo.ReturnObjectToLong(dtTemp.Rows[0]["cNumber"]);
                    }

                    sSQL = "select * from mom_order a inner join mom_orderdetail b on a.moid = b.moid where a.mocode = '" + dtData.Rows[0]["单据号"].ToString().Trim() + "' and b.SortSeq = '" + dtData.Rows[0]["行号"].ToString().Trim() + "'";
                    DataTable dt生产订单表头 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt生产订单表头 == null || dt生产订单表头.Rows.Count < 1)
                    {
                        throw new Exception("获得生产订单信息失败");
                    }

                    //4. 组装表头
                    lID += 1;
                    string s仓库 = dtData.Rows[0]["仓库"].ToString().Trim();
                    string s订单号 = dtData.Rows[0]["单据号"].ToString().Trim();
                    string s行号 = dtData.Rows[0]["行号"].ToString().Trim();
                    string s制单人 = dtData.Rows[0]["制单人"].ToString().Trim();
                    string s产量 = dt生产订单表头.Rows[0]["Qty"].ToString().Trim();
                    string s产品编码 = dt生产订单表头.Rows[0]["InvCode"].ToString().Trim();
                    string s生产订单主表标志 = dt生产订单表头.Rows[0]["MoId"].ToString().Trim();
                    iCode += 1; 
                    string s单据号 = sGetCode(iCode, 10);

                    sSQL = " insert into rdrecord11(id,brdflag,cvouchtype,cbustype,csource,cwhcode,ddate,ccode,crdcode,cdepcode " +
                                 ",cmaker,imquantity,vt_id,cpspcode,cmpocode,iproorderid,bomfirst,biscomplement,iswfcontrolled,dnmaketime " +
                                 ",dnmodifytime,dnverifytime,bmotran,cdefine1)  " +
                             "values (N'" + lID + "',N'0',N'11',N'领料',N'生产订单',N'" + s仓库 + "','" + d当前服务器时间.ToString("yyyy-MM-dd") + "',N'" + s单据号 + "',N'21',N'05' " +
                                 ",N'" + s制单人 + "'," + s产量 + ",65,N'" + s产品编码 + "',N'" + s订单号 + "'," + s生产订单主表标志 + ",0,0,0, getdate()" +
                                 ", Null , Null ,N'0','" + s订单号 + "' )";
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    for (int i = 0; i < dtData.Rows.Count; i++)
                    {
                        //判断条码是否已经使用
                        sSQL = "select * from rdrecords11 where BarCode = " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["条形码"].ToString()) + " ";
                        int iCou = ClsBaseDataInfo.ReturnObjectToInt(SqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));
                        if (iCou > 0)
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + "已经使用\n";
                            continue;
                        }

                        sSQL = "select a.moid, b.MoDId ,c.AllocateId ,c.InvCode ,c.Qty ,c.IssQty  from mom_order a inner join mom_orderdetail b on a.moid = b.moid inner join mom_moallocate c on c.MoDId  = b.Modid where a.mocode = '" + s订单号 + "' and b.SortSeq = '" + s行号 + "' and c.InvCode = '" + dtData.Rows[i]["存货编码"].ToString().Trim() + "' and isnull(LotNo,'') = '" + dtData.Rows[i]["批号"].ToString().Trim().Substring(0, dtData.Rows[i]["批号"].ToString().Trim().Length -3)+ "'";
                        DataTable dt生产订单信息 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt生产订单信息 == null || dt生产订单信息.Rows.Count < 1)
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + "获得生产订单材料信息失败，请核实材料或批号是否匹配\n";
                            continue;
                        }

                        decimal d应领数量 = ClsBaseDataInfo.ReturnObjectToDecimal(dt生产订单信息.Rows[0]["Qty"]);
                        decimal d已领数量 = ClsBaseDataInfo.ReturnObjectToDecimal(dt生产订单信息.Rows[0]["IssQty"]);
                        decimal d数量 = ClsBaseDataInfo.ReturnObjectToDecimal(dtData.Rows[i]["数量"], 6);
                        if(d应领数量 * (decimal)1.2 < d已领数量 + d数量)
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + " 超订单领料\n";
                            continue;
                        }

                        sSQL = "select * from Inventory where cInvCode = '" + dtData.Rows[i]["存货编码"].ToString().Trim() + "'";
                        DataTable dt存货信息 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt存货信息 == null || dt存货信息.Rows.Count < 1)
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + "获得存货信息失败\n";
                            continue;
                        }

                        int i是否批次 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bInvBatch"]);
                        if (i是否批次 != 0 && dtData.Rows[i]["批号"].ToString().Trim() == "")
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + ":" + dtData.Rows[i]["存货编码"].ToString().Trim() + "是批次管理物料，必须输入批号\n";
                            continue;
                        }
                        int i是否自由项1 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree1"]);
                        if (i是否自由项1 != 0 && dtData.Rows[i]["长度"].ToString().Trim() == "")
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + ":" + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入长度\n";
                            continue;
                        }

                        //组装表体
                        sSQL = "select * from CurrentStock where cWhCode = '" + dtData.Rows[i]["仓库"].ToString().Trim() + "' and cInvCode = '" + dtData.Rows[i]["存货编码"].ToString().Trim() + "' and isnull(cBatch,'') = '" + dtData.Rows[i]["批号"].ToString().Trim() + "' and isnull(cFree1,'') = '" + dtData.Rows[i]["长度"].ToString().Trim() + "'   ";
                        DataTable dt现存量 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        lIDDetail += 1;
                        string s存货编码 = dtData.Rows[i]["存货编码"].ToString().Trim();
                        //decimal d数量 = ClsBaseDataInfo.ReturnObjectToDecimal(dtData.Rows[i]["数量"], 6);
                        decimal d件数 = 0;

                        decimal d现存数量 = ClsBaseDataInfo.ReturnObjectToDecimal(dt现存量.Rows[0]["iQuantity"], 6);
                        decimal d现存件数 = ClsBaseDataInfo.ReturnObjectToDecimal(dt现存量.Rows[0]["iNum"], 6);
                        if (d现存件数 > 0)
                        {
                            if (d数量 == d现存数量)
                                d件数 = d现存件数;
                            else
                                d件数 = ClsBaseDataInfo.ReturnObjectToDecimal(d数量 * d现存件数 / d现存数量, 6);
                        }
                      

                        decimal d生产订单子件数量 = ClsBaseDataInfo.ReturnObjectToDecimal(dt生产订单信息.Rows[0]["Qty"], 6);
                        decimal d生产订单子件已领数量 = ClsBaseDataInfo.ReturnObjectToDecimal(dt生产订单信息.Rows[0]["IssQty"], 6);
                        decimal d生产订单待领数量 = d生产订单子件数量 - d生产订单子件已领数量;

                        //if (d生产订单待领数量 < d数量)
                        //{
                        //    sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + ":" + dtData.Rows[i]["存货编码"].ToString().Trim() + "超订单领料\n";
                        //    continue;
                        //}

                        sSQL = "select * from Warehouse where cWhCode = '" + s仓库 + "'";
                        DataTable dtWH = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];


                        sSQL = "Insert Into rdrecords11(autoid,id,cinvcode,inum,iquantity,iunitcost,iprice,ipunitcost,ipprice,cbatch " +
                                "	,cobjcode,cvouchcode,cinvouchcode,cinvouchtype,isoutquantity,isoutnum,coutvouchid,coutvouchtype,isredoutquantity,isredoutnum " +
                                "	,cfree1,cfree2,isquantity,ifnum,ifquantity,dvdate,itrids,cposition,cdefine22,cdefine23 " +
                                "	,cdefine24,cdefine25,cdefine26,cdefine27,citem_class,citemcode,cname,citemcname,cfree3,cfree4 " +
                                "	,cfree5,cfree6,cfree7,cfree8,cfree9,cfree10,BarCode,inquantity,innum,cassunit " +
                                "	,dmadedate,imassdate,cdefine28,cdefine29,cdefine30,cdefine31,cdefine32,cdefine33,cdefine34,cdefine35 " +
                                "	,cdefine36,cdefine37,impoids,icheckids,cbvencode,crejectcode,cmassunit,cmolotcode,imaterialfee,dmsdate " +
                                "	,ismaterialfee,iomodid,iomomid,cmworkcentercode,irsrowno,cbaccounter,dbkeepdate,bcosting,bvmiused,ivmisettlequantity " +
                                "	,ivmisettlenum,cvmivencode,iinvsncount,cwhpersoncode,cwhpersonname,imaids,iinvexchrate,corufts,comcode,cmocode " +
                                "	,invcode,imoseq,iopseq,copdesc,iexpiratdatecalcu,cexpirationdate,dexpirationdate,cciqbookcode,ibondedsumqty,productinids " +
                                "	,iorderdid,iordertype,iordercode,iorderseq,isodid,isotype,csocode,isoseq,ipesodid,ipesotype " +
                                "	,cpesocode,ipesoseq,cbatchproperty1,cbatchproperty2,cbatchproperty3,cbatchproperty4,cbatchproperty5,cbatchproperty6,cbatchproperty7,cbatchproperty8 " +
                                "	,cbatchproperty9,cbatchproperty10,cbmemo,applydid,applycode,irowno,strowguid,cservicecode) " +
                                "Values (" + lIDDetail + "," + lID + ",N'" + s存货编码 + "'," + d件数 + "," + d数量 + ",Null,Null,Null,Null,N'" + dtData.Rows[i]["批号"] + "' " +
                                "	,Null,Null,Null,Null,Null,Null,Null,Null,Null,Null " +
                                "	," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["长度"].ToString().Trim()) + ",Null,Null,Null,Null,Null,Null," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["货位"].ToString()) + ",Null,Null " +
                                "	,Null,Null,Null,Null,Null,Null,Null,Null,Null,Null " +
                                "	,Null,Null,Null,Null,Null,Null,'" + dtData.Rows[i]["条形码"].ToString() + "'," + d数量 + "," + d件数 + ",N'" + dt存货信息.Rows[0]["cAssComUnitCode"] + "' " +
                                "	,Null,Null,Null,Null,Null,Null,Null,Null,Null,Null " +
                                "	,Null,Null," + ClsBaseDataInfo.ReturnCol(dt生产订单信息.Rows[0]["AllocateId"].ToString()) + ",Null,Null,Null,Null,Null,Null,Null " +
                                "	,Null,Null,Null,Null,Null,Null,Null,1,0,Null " +
                                "	,Null,Null,Null,Null,Null,Null,1,N'13497.1105',Null,N'" + s订单号 + "' " +
                                "	,N'" + s产品编码 + "'," + dtData.Rows[i]["行号"].ToString().Trim() + ",N'0000',Null,0,Null,Null,Null,Null,Null " +
                                "	," + dt生产订单信息.Rows[0]["Modid"] + ",1,N'" + s订单号 + "',1,Null,0,Null,Null," + dt生产订单信息.Rows[0]["Modid"] + ",7 " +
                                "	,'" + s订单号 + "'," + dtData.Rows[i]["行号"].ToString().Trim() + ",Null,Null,Null,Null,Null," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["炉号"].ToString().Trim()) + ",Null,Null " +
                                "	,Null,Null,Null,Null,Null,1,Null,Null)";
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        //更新现存量

                        sSQL = "select * from SCM_Item where cInvCode = '" + s存货编码 + "' and ISNULL(cFree1,'') = '" + dtData.Rows[i]["长度"].ToString().Trim() + "' ";
                        DataTable dtTemp2 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        long lItemID = 0;
                        if (dtTemp2 == null || dtTemp2.Rows.Count == 0)
                        {
                            sSQL = "insert into SCM_Item(cInvCode,cFree1,PartId) " +
                                    "values('" + s存货编码 + "','" + dtData.Rows[i]["长度"].ToString().Trim() + "',0)";
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            sSQL = "select * from SCM_Item where cInvCode = '" + s存货编码 + "' and ISNULL(cFree1,'') = '" + dtData.Rows[i]["长度"].ToString().Trim() + "' ";
                            dtTemp2 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            lItemID = Convert.ToInt64(dtTemp2.Rows[0]["id"]);
                        }
                        else
                        {
                            lItemID = Convert.ToInt64(dtTemp2.Rows[0]["id"]);
                        }

                        sSQL = "declare @itmeid int " +
                                "select @itmeid = MAX(ItemId) + 1 from CurrentStock " +
                               "if exists(select * from CurrentStock where cinvcode = '" + s存货编码 + "' and isnull(cBatch,'') = isnull(" + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["批号"].ToString()) + ",'') and cWhCode = '" + s仓库 + "' and isnull(cFree1,'') = '" + dtData.Rows[i]["长度"].ToString().Trim() + "') " +
                               "    update CurrentStock set iQuantity = isnull(iQuantity,0) - " + ClsBaseDataInfo.ReturnCol(d数量) + ",iNum = isnull(iNum,0) - " + ClsBaseDataInfo.ReturnCol(d件数) + " where cinvcode = '" + s存货编码 + "' and isnull(cBatch,'') = isnull(" + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["批号"].ToString()) + ",'') and cWhCode = '" + s仓库 + "' and isnull(cFree1,'') = '" + dtData.Rows[i]["长度"].ToString().Trim() + "' " +
                               "else " +
                               "    insert into CurrentStock(cWhCode,cInvCode,cBatch,iSoType,iQuantity,iNum,ItemId,cFree1)  " +
                               "    values('" + s仓库 + "', '" + s存货编码 + "'," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["批号"].ToString()) + ",0,-" + ClsBaseDataInfo.ReturnCol(d数量) + ",-" + ClsBaseDataInfo.ReturnCol(d件数) + "," + lItemID + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["长度"].ToString()) + ")";
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        sSQL = "update mom_moallocate set IssQty  = isnull(IssQty ,0) + " + ClsBaseDataInfo.ReturnCol(d数量) + "  where AllocateId = " + ClsBaseDataInfo.ReturnCol(dt生产订单信息.Rows[0]["AllocateId"].ToString());
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        if (Convert.ToInt32(dtWH.Rows[0]["bWhPos"]) != 0)
                        {
                            //货位登记
                            sSQL = "insert into InvPosition( RdsID, RdID, cWhCode, cPosCode, cInvCode, cBatch, cFree1, cFree2, dVDate, iQuantity" +
                                        ", iNum, cMemo, cHandler, dDate, bRdFlag, cSource, cFree3, cFree4, cFree5, cFree6" +
                                        ", cFree7, cFree8, cFree9, cFree10, cAssUnit, cBVencode, iTrackId,  dMadeDate, iMassDate" +
                                        ", cMassUnit, cvmivencode, iExpiratDateCalcu, cExpirationdate, dExpirationdate, cvouchtype, cInVouchType, cVerifier, dVeriDate, dVouchDate) " +
                                    "values(" + lIDDetail + "," + lID + ",'" + s仓库 + "'," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["货位"].ToString()) + ",'" + s存货编码 + "'," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["批号"].ToString()) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["长度"].ToString()) + ",null,null," + ClsBaseDataInfo.ReturnCol(d数量) + " " +
                                    "," + ClsBaseDataInfo.ReturnCol(d件数) + ",null,'" + s制单人 + "','" + d当前服务器时间.ToString("yyyy-MM-dd") + "',0,null,null,null,null,null" +
                                    ",null,null,null,null," + ClsBaseDataInfo.ReturnCol(dt存货信息.Rows[0]["cAssComUnitCode"].ToString()) + ",null,0,null,null" +
                                    ",null,null,0,null,null,'11','',null,null,'" + d当前服务器时间.ToString("yyyy-MM-dd") + "')";
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            sSQL = "if exists( select * from InvPositionSum where cInvCode = '" + s存货编码 + "' and cWhCode = '" + s仓库 + "' and cPosCode = " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["货位"].ToString()) + " and ISNULL(cBatch,'') = '" + dtData.Rows[i]["批号"].ToString().Trim() + "' and isnull(cFree1,'') = '" + dtData.Rows[i]["长度"].ToString().Trim() + "') " +
                                "   update InvPositionSum set iQuantity = iQuantity - " + ClsBaseDataInfo.ReturnCol(d数量) + ",iNum = iNum - " + ClsBaseDataInfo.ReturnCol(d件数) + " where cInvCode = '" + s存货编码 + "' and cWhCode = '" + s仓库 + "' and cPosCode = " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["货位"].ToString()) + " and ISNULL(cBatch,'') = '" + dtData.Rows[i]["批号"].ToString().Trim() + "'  and isnull(cFree1,'') = '" + dtData.Rows[i]["长度"].ToString().ToString() + "' " +
                                "else " +
                                "insert InvPositionSum(cWhCode, cPosCode, cInvCode, iQuantity, inum, cBatch, cFree1, cFree2, cFree3" +
                                    " , cFree4, cFree5, cFree6, cFree7, cFree8, cFree9, cFree10, iTrackid, cvmivencode, cMassUnit" +
                                    ", iMassDate, dMadeDate, dVDate, iExpiratDateCalcu, cExpirationdate, dExpirationdate, cInVouchType) " +
                                "values(  '" + s仓库 + "', " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["货位"].ToString()) + ", '" + s存货编码 + "',  -1 * " + ClsBaseDataInfo.ReturnCol(d数量) + ",  -1 * isnull(" + ClsBaseDataInfo.ReturnCol(d件数) + ",0), " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["批号"].ToString()) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["长度"].ToString()) + ", null, null" +
                                    " , null, null, null, null, null, null, null, 0, null, null" +
                                    ", null, null, null, 0, null, null, null)";
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                    }

                    //7. 更新历史单据号表
                    sSQL = "update VoucherHistory set cNumber='" + iCode + "' Where  CardNumber='0412' and cContent is NULL";
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    //8. 登记未记账
                    sSQL = @"exec IA_SP_WriteUnAccountVouchForST aaaaaa,N'11'";
                    sSQL = sSQL.Replace("aaaaaa", lID.ToString());
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    //9. 更新单据ID号表
                    string s1 = lID.ToString().Trim();
                    string s2 = lIDDetail.ToString().Trim();
                    s1 = s1.Substring(1);
                    s2 = s2.Substring(1);
                    lID = Convert.ToInt64(s1);
                    lIDDetail = Convert.ToInt64(s2);
                    sSQL = "update  UFSystem..UA_Identity set iFatherID = " + lID + ",iChildID = " + lIDDetail + " where cAcc_Id = '" + ClsBaseDataInfo.sUFDataBaseName.Trim().Substring(7, 3) + "' and cVouchType = 'rd'";
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    if (sErr.Trim().Length > 0)
                    {
                        throw new Exception(sErr);
                    }


                    tran.Commit();
                    s = "生成单据号：" + s单据号;
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        /// <summary>
        /// 根据序号组装单据号
        /// </summary>
        /// <param name="l"></param>
        /// <param name="iLength"></param>
        /// <returns></returns>
        private string sGetCode(long l, int iLength)
        {
            string sCode = l.ToString();
            for (int i = 0; i < iLength; i++)
            {
                if (sCode.Length < iLength)
                {
                    sCode = "0" + sCode;
                }
                else
                {
                    break;
                }
            }
            return sCode;
        }

        public string Chk材料出库条码是否已经使用(string sBarCode)
        {
            string s = "";

            try
            {
                string sSQL = "select count(1) from rdrecords11 where isnull(BarCode ,'') = '" + sBarCode + "'";
                s = ClsBaseClass.SqlHelper.ExecuteScalar(ClsBaseClass.ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).ToString();
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string dt材料出库条码信息(string sBarCode, string sCode,string sRow)
        {
            string s = "";
            try
            {
                string sSQL = @"
select a.*, b.cInvName,b.cInvStd,b.bInvBatch,substring(f.cBatch,0,LEN(f.cBatch)-3)
	,e.Qty,e.IssQty,e.未领数量 as 未领数量, 
	f.cCode,f.irowno,f.cInvCode,f.iNum 
	,case when isnull(f.cBatch ,'') <> '' then f.cBatch else a.批号 end as cBatch
	,case when isnull(f.cBatchProperty6 ,'') <> '' then f.cBatchProperty6 else a.炉号 end as cBatchProperty6
	,case when isnull(f.cFree1 ,'') <> '' then f.cFree1 else a.长度 end as cFree1
	,case when ltrim(rtrim(isnull(f.cInvCode ,''))) <> '' then f.cInvCode else a.存货编码 end as cInvCode
	,case when isnull(f.iQuantity ,0) <> 0 then f.iQuantity else a.数量 end as iQuantity
from 条形码信息 a 
	left join (
					select a.cCode,b.irowno,b.cInvCode,b.iQuantity,b.iNum,b.cBatch,b.cBatchProperty6 ,b.cFree1  
					from rdrecord01 a inner join rdrecords01 b on a.id = b.ID
				) f on f.cCode = a.采购入库单号 and a.采购入库单行号  = f.irowno and a.存货编码 = f.cInvCode
	inner join Inventory b on a.存货编码 = b.cInvCode 	
	left join (
					select c.InvCode as 子件编码, c.qty,c.issQty,c.Qty - isnull(c.issQty,0) as 未领数量,c.LotNo 
                    from mom_order a inner join mom_orderdetail b on a.moid = b.moid inner join mom_moallocate c on c.MoDId  = b.Modid 
                    where a.mocode = '111111' and b.SortSeq = '222222' 
				) e on e.子件编码 = a.存货编码 
                    and case when isnull(substring(f.cBatch,0,LEN(f.cBatch)-2),'') <> '' then isnull(substring(f.cBatch,0,LEN(f.cBatch)-2),'') else substring(a.批号,0,LEN(a.批号)-2) end = e.LotNo
where a.条形码  = '333333'
";
                

                sSQL = sSQL.Replace("111111", sCode);
                sSQL = sSQL.Replace("222222", sRow);
                sSQL = sSQL.Replace("333333", sBarCode);

                DataTable dt = SqlHelper.ExecuteDataset(ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).Tables[0];
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = "0" + ee.Message;
            }
            return s;
        }
    }
}
