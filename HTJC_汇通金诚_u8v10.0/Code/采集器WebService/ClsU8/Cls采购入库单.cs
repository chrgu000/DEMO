using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using ClsBaseClass;

namespace ClsU8
{
    public class Cls采购入库单
    {
        public string dt采购入库单信息(string s单据号)
        {
            string s = "";

            try
            {
                string sSQL = @"
SELECT a.cCode,a.cAccounter,a.cHandler ,b.cInvCode,b.iQuantity
FROM dbo.RdRecord01 a INNER JOIN dbo.rdrecords01 b ON a.id = b.id
WHERE a.cCode = 'aaaaaa'
order by b.autoid
";
                sSQL = sSQL.Replace("aaaaaa", s单据号);
                DataTable dt = SqlHelper.ExecuteDataset(ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).Tables[0];
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string Save采购入库单(DataTable dtData)
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
                    sSQL = "select * From VoucherHistory  with (ROWLOCK) Where  CardNumber='24'";
                    dtTemp = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp == null || dtTemp.Rows.Count < 1)
                    {
                        iCode = 1;
                    }
                    else
                    {
                        iCode = ClsBaseDataInfo.ReturnObjectToLong(dtTemp.Rows[0]["cNumber"]);
                    }


                    sSQL = "select * from PO_Pomain where cPOID = " + dtData.Rows[0]["单据号"] + " ";
                    DataTable dt采购订单 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt采购订单 == null || dt采购订单.Rows.Count < 1)
                    {
                        throw new Exception("获得采购订单信息失败");
                    }

                    //4. 组装表头
                    lID += 1;
                    string s仓库 =dtData.Rows[0]["仓库"].ToString().Trim();
                    string s供应商 = dtData.Rows[0]["供应商"].ToString().Trim();
                    string s订单号 = dtData.Rows[0]["单据号"].ToString().Trim();
                    string s制单人 =dtData.Rows[0]["制单人"].ToString().Trim();
                    string s采购订单主表标志 = dt采购订单.Rows[0]["POID"].ToString().Trim();
                    iCode += 1;
                    string s单据号 = sGetCode(iCode, 10);
                    sSQL = "insert into rdrecord01(id,brdflag,cvouchtype,cbustype,csource,cwhcode,ddate,ccode,crdcode,cptcode" +
                                    ",cvencode,cordercode,cmaker,bpufirst,vt_id,bisstqc,ipurorderid,itaxrate,iexchrate,cexch_name" +
                                    ",bomfirst,idiscounttaxtype,iswfcontrolled,dnmaketime,dnmodifytime,dnverifytime,bredvouch,bcredit) " +
                           "values (N'" + lID + "',N'1',N'01',N'普通采购',N'采购订单',N'" + s仓库 + "','" + d当前服务器时间.ToString("yyyy-MM-dd") + "',N'" + s单据号 + "',N'11',N'01'" +
                                    ",N'" + s供应商 + "',N'" + s订单号 + "',N'" + s制单人 + "',0,27,0,N'" + s采购订单主表标志 + "',N'17',1,N'人民币'" +
                                    ",0,N'0',0, getdate(), Null , Null ,0,N'0')";
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    //5. [更新采购订单表头] 暂时未发现需要更新的内容

                    for (int i = 0; i < dtData.Rows.Count; i++)
                    {
                        //判断条码是否已经使用
                        sSQL = "select * from rdrecords01 where BarCode = " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["条形码"].ToString()) + " ";
                        int iCou = ClsBaseDataInfo.ReturnObjectToInt(SqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));
                        if (iCou > 0)
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + "已经使用\n";
                            continue;
                        }


                        sSQL = "select * from PO_Pomain a inner join PO_Podetails b on a.POID = b.POID where a.cPOID = '" + dtData.Rows[i]["单据号"] + "' and b.cInvCode = '" + dtData.Rows[i]["存货编码"].ToString().Trim() + "' order by b.ID";
                        DataTable dt采购订单信息 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt采购订单信息 == null || dt采购订单信息.Rows.Count < 1)
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + "获得采购订单信息失败\n";
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
                        int i是否自由项1 =  ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree1"]);
                        if (i是否自由项1 != 0 && dtData.Rows[i]["长度"].ToString().Trim() == "")
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + ":" + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入长度\n";
                            continue;
                        }

                        //组装表体
                        lIDDetail += 1;
                        string s存货编码 = dtData.Rows[i]["存货编码"].ToString().Trim();
                        decimal d数量 = ClsBaseDataInfo.ReturnObjectToDecimal(dtData.Rows[i]["数量"], 6);
                        decimal d税率 = ClsBaseDataInfo.ReturnObjectToDecimal(dt采购订单信息.Rows[0]["iPerTaxRate"], 6);

                        decimal d采购订单数量 = ClsBaseDataInfo.ReturnObjectToDecimal(dt采购订单信息.Rows[0]["iQuantity"], 6);
                        decimal d采购订单件数 = ClsBaseDataInfo.ReturnObjectToDecimal(dt采购订单信息.Rows[0]["iNum"], 6);

                        decimal d累计入库数量 = ClsBaseDataInfo.ReturnObjectToDecimal(dt采购订单信息.Rows[0]["iReceivedQTY"], 6);
                        decimal d累计入库件数 = ClsBaseDataInfo.ReturnObjectToDecimal(dt采购订单信息.Rows[0]["iReceivedNum"], 6);

                        decimal d件数 = 0;
                        if (d采购订单件数 != 0)
                        {
                            d件数 = ClsBaseDataInfo.ReturnObjectToDecimal(d采购订单件数 * d数量 / d采购订单数量, 6);
                        }

                        decimal d入库超额上限 = ClsBaseDataInfo.ReturnObjectToDecimal(dt存货信息.Rows[0]["fInExcess"], 6);
                        if (d采购订单数量 * (1 + d入库超额上限 / 100) < d累计入库数量 + d数量 || d采购订单件数 * (1 + d入库超额上限 / 100) < d累计入库件数 + d件数)
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + ":" + dtData.Rows[i]["存货编码"].ToString().Trim() + "累计入库数量超订单\n";
                            continue;
                        }

                        decimal d含税单价 = ClsBaseDataInfo.ReturnObjectToDecimal(dt采购订单信息.Rows[0]["iTaxPrice"], 6);
                        decimal d含税金额 = ClsBaseDataInfo.ReturnObjectToDecimal(d含税单价 * d数量, 2);
                        decimal d无税金额 = ClsBaseDataInfo.ReturnObjectToDecimal(d含税金额 / (1 + d税率 / 100), 2);
                        decimal d税额 = d含税金额 - d无税金额;
                        decimal d无税单价 = ClsBaseDataInfo.ReturnObjectToDecimal(d无税金额 / d数量, 3);

                        sSQL = "Insert Into rdrecords01(autoid,id,cinvcode,inum,iquantity,iunitcost,iprice,iaprice,ipunitcost,ipprice" +
                                    ",cbatch,cvouchcode,cinvouchcode,cinvouchtype,isoutquantity,isoutnum,cfree1,cfree2,dsdate,itax" +
                                    ",isquantity,isnum,imoney,ifnum,ifquantity,dvdate,cposition,cdefine22,cdefine23,cdefine24" +
                                    ",cdefine25,cdefine26,cdefine27,citem_class,citemcode,iposid,facost,cname,citemcname,cfree3" +
                                    ",cfree4,cfree5,cfree6,cfree7,cfree8,cfree9,cfree10,BarCode,inquantity,innum" +
                                    ",cassunit,dmadedate,imassdate,cdefine28,cdefine29,cdefine30,cdefine31,cdefine32,cdefine33,cdefine34" +
                                    ",cdefine35,cdefine36,cdefine37,icheckids,cbvencode,cgspstate,iarrsid,ccheckcode,icheckidbaks,crejectcode" +
                                    ",irejectids,ccheckpersoncode,dcheckdate,ioritaxcost,ioricost,iorimoney,ioritaxprice,iorisum,itaxrate,itaxprice" +
                                    ",isum,btaxcost,cpoid,cmassunit,imaterialfee,iprocesscost,iprocessfee,dmsdate,ismaterialfee,isprocessfee" +
                                    ",iomodid,strcontractid,strcode,cbaccounter,dbkeepdate,bcosting,isumbillquantity,bvmiused,ivmisettlequantity,ivmisettlenum" +
                                    ",cvmivencode,iinvsncount,impcost,iimosid,iimbsid,cbarvcode,dbarvdate,iinvexchrate,corufts,iexpiratdatecalcu" +
                                    ",cexpirationdate,dexpirationdate,cciqbookcode,ibondedsumqty,iordertype,iorderdid,iordercode,iorderseq,isodid,isotype" +
                                    ",csocode,isoseq,cbatchproperty1,cbatchproperty2,cbatchproperty3,cbatchproperty4,cbatchproperty5,cbatchproperty6,cbatchproperty7,cbatchproperty8" +
                                    ",cbatchproperty9,cbatchproperty10,cbmemo,ifaqty,istax,irowno,strowguid) " +
                            "Values (" + lIDDetail + "," + lID + ",N'" + s存货编码 + "'," + ClsBaseDataInfo.ReturnCol(d件数) + "," + ClsBaseDataInfo.ReturnCol(d数量) + "," + ClsBaseDataInfo.ReturnCol(d无税单价) + "," + ClsBaseDataInfo.ReturnCol(d无税金额) + "," + ClsBaseDataInfo.ReturnCol(d无税金额) + ",Null,Null" +
                                    "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["批号"].ToString()) + ",Null,Null,Null,Null,Null," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["长度"].ToString()) + ",Null,Null,Null" +
                                    ",0,0,0,Null,Null,Null," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["货位"].ToString()) + " ," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["条形码"].ToString()) + ",Null,Null" +
                                    ",Null,Null,Null,Null,Null," + ClsBaseDataInfo.ReturnCol(dt采购订单信息.Rows[0]["ID"].ToString()) + "," + ClsBaseDataInfo.ReturnCol(d无税单价) + ",Null,Null,Null" +
                                    ",Null,Null,Null,Null,Null,Null,Null," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["条形码"].ToString()) + "," + ClsBaseDataInfo.ReturnCol(d数量) + "," + ClsBaseDataInfo.ReturnCol(d件数) + "" +
                                    ",Null,Null,Null,Null,Null,Null,Null,Null,Null,Null" +
                                    ",Null,Null,Null,Null,Null,Null,Null,Null,Null,Null" +
                                    ",Null,Null,Null," + ClsBaseDataInfo.ReturnCol(d含税单价) + "," + ClsBaseDataInfo.ReturnCol(d无税单价) + "," + ClsBaseDataInfo.ReturnCol(d无税金额) + "," + ClsBaseDataInfo.ReturnCol(d税额) + "," + ClsBaseDataInfo.ReturnCol(d含税金额) + "," + ClsBaseDataInfo.ReturnCol(d税率) + "," + ClsBaseDataInfo.ReturnCol(d税额) + "" +
                                    "," + ClsBaseDataInfo.ReturnCol(d含税金额) + ",0," + dtData.Rows[i]["单据号"].ToString() + ",Null,Null,Null,Null,Null,Null,Null" +
                                    ",Null,Null,Null,Null,Null,1,Null,Null,Null,Null" +
                                    ",Null,Null,Null,Null,Null,Null,Null,Null,N'13502.0346',0" +
                                    ",Null,Null,Null,Null,Null,Null,Null,Null,Null,0" +
                                    ",Null,Null,Null,Null,Null,Null,Null," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["炉号"].ToString()) + ",Null,Null" +
                                    ",Null,Null,Null,Null,Null," + ClsBaseDataInfo.ReturnCol(dt采购订单信息.Rows[0]["irowno"].ToString()) + ",Null)";
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
                               "if exists(select * from CurrentStock where cinvcode = '" + s存货编码 + "' and isnull(cFree1,'') = '" + dtData.Rows[i]["长度"].ToString().Trim() + "'  and isnull(cBatch,'') = isnull(" + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["批号"].ToString()) + ",'') and cWhCode = '" + s仓库 + "') " +
                               "    update CurrentStock set iQuantity = isnull(iQuantity,0) + " + ClsBaseDataInfo.ReturnCol(d数量) + ",iNum = isnull(iNum,0) + " + ClsBaseDataInfo.ReturnCol(d件数) + " where cinvcode = '" + s存货编码 + "' and isnull(cBatch,'') = isnull(" + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["批号"].ToString()) + ",'') and cWhCode = '" + s仓库 + "' and isnull(cFree1,'') = '" + dtData.Rows[i]["长度"].ToString().Trim() + "' " +
                               "else " +
                               "    insert into CurrentStock(cWhCode,cInvCode,cBatch,iSoType,iQuantity,iNum,ItemId,cFree1)  " +
                               "    values('" + s仓库 + "', '" + s存货编码 + "','" + dtData.Rows[i]["批号"].ToString() + "',0," + ClsBaseDataInfo.ReturnCol(d数量) + "," + ClsBaseDataInfo.ReturnCol(d件数) + "," + lItemID + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["长度"].ToString()) + ")";
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                        sSQL = "update Po_Podetails set iReceivedQTY = isnull(iReceivedQTY,0) + " + ClsBaseDataInfo.ReturnCol(d数量) + " ,iReceivedNum = isnull(iReceivedNum,0) + " + ClsBaseDataInfo.ReturnCol(d件数) + ",iReceivedMoney = isnull(iReceivedMoney,0) + " + ClsBaseDataInfo.ReturnCol(d含税金额) + " " +
                                "where ID = " + ClsBaseDataInfo.ReturnCol(dt采购订单信息.Rows[0]["ID"].ToString());
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                        //货位登记
                        sSQL = "insert into InvPosition( RdsID, RdID, cWhCode, cPosCode, cInvCode, cBatch, cFree1, cFree2, dVDate, iQuantity" +
                                    ", iNum, cMemo, cHandler, dDate, bRdFlag, cSource, cFree3, cFree4, cFree5, cFree6" +
                                    ", cFree7, cFree8, cFree9, cFree10, cAssUnit, cBVencode, iTrackId,  dMadeDate, iMassDate" +
                                    ", cMassUnit, cvmivencode, iExpiratDateCalcu, cExpirationdate, dExpirationdate, cvouchtype, cInVouchType, cVerifier, dVeriDate, dVouchDate) " +
                                "values(" + lIDDetail + "," + lID + ",'" + s仓库 + "'," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["货位"].ToString()) + ",'" + s存货编码 + "'," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["批号"].ToString()) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["长度"].ToString()) + ",null,null," + ClsBaseDataInfo.ReturnCol(d数量) + " " +
                                "," + ClsBaseDataInfo.ReturnCol(d件数) + ",null,'" + s制单人 + "','" + d当前服务器时间.ToString("yyyy-MM-dd") + "',1,null,null,null,null,null" +
                                ",null,null,null,null," + ClsBaseDataInfo.ReturnCol(dt存货信息.Rows[0]["cAssComUnitCode"].ToString()) + ",null,0,null,null" +
                                ",null,null,0,null,null,'01','',null,null,'" + d当前服务器时间.ToString("yyyy-MM-dd") + "')";
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        sSQL = "if exists( select * from InvPositionSum where cInvCode = '" + s存货编码 + "' and cWhCode = '" + s仓库 + "' and cPosCode = " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["货位"].ToString()) + " and ISNULL(cBatch,'') = '" + dtData.Rows[i]["批号"].ToString().Trim() + "' and isnull(cFree1,'') = '" + dtData.Rows[i]["长度"].ToString().Trim() + "') " +
                            "   update InvPositionSum set iQuantity = iQuantity +  " + ClsBaseDataInfo.ReturnCol(d数量) + ",iNum = iNum +  " + ClsBaseDataInfo.ReturnCol(d件数) + " where cInvCode = '" + s存货编码 + "' and cWhCode = '" + s仓库 + "' and cPosCode = " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["货位"].ToString()) + " and ISNULL(cBatch,'') = '" + dtData.Rows[i]["批号"].ToString().Trim() + "'  and isnull(cFree1,'') = '" + dtData.Rows[i]["长度"].ToString().Trim() + "' " +
                            "else " +
                            "insert InvPositionSum(cWhCode, cPosCode, cInvCode, iQuantity, inum, cBatch, cFree1, cFree2, cFree3" +
                                " , cFree4, cFree5, cFree6, cFree7, cFree8, cFree9, cFree10, iTrackid, cvmivencode, cMassUnit" +
                                ", iMassDate, dMadeDate, dVDate, iExpiratDateCalcu, cExpirationdate, dExpirationdate, cInVouchType) " +
                            "values(  '" + s仓库 + "', " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["货位"].ToString()) + ", '" + s存货编码 + "',  " + ClsBaseDataInfo.ReturnCol(d数量) + ",  " + ClsBaseDataInfo.ReturnCol(d件数) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["批号"].ToString()) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["长度"].ToString()) + ", null, null" +
                                " , null, null, null, null, null, null, null, 0, null, null" +
                                ", null, null, null, 0, null, null, null)";
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    //7. 更新历史单据号表

                    sSQL = "update VoucherHistory set cNumber='" + iCode + "' Where  CardNumber='24' and cContent is NULL";
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                    //8. 更新单据ID号表

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
        /// 条码验证
        /// </summary>
        /// <param name="dtData"></param>
        /// <returns></returns>
        public string Save采购入库单2(DataTable dtData)
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


                    for (int i = 0; i < dtData.Rows.Count; i++)
                    {
                        string s条形码 = dtData.Rows[i]["条形码"].ToString().Trim();
                        if (s条形码.Length != 10)
                        {
                            sErr = sErr + "条形码：" + s条形码 + " 长度不正确\n";
                            continue;
                        }

                        sSQL = @"
SELECT *
FROM dbo.rdrecord01 a inner join rdrecords01 b on a.id = b.id 
    left join (select sum(iQuantity) as iQty,RdsID from InvPosition group by RdsID) rdsp on b.autoid = rdsp.RdsID
	INNER JOIN dbo.条形码信息 c ON a.ccode = c.采购入库单号 AND b.irowno = c.采购入库单行号 
WHERE c.条形码 = 'aaaaaa' 
";
                        sSQL = sSQL.Replace("aaaaaa", s条形码);
                        dtTemp = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtTemp == null || dtTemp.Rows.Count == 0)
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + " 对应单据" + dtTemp.Rows[0]["cCode"].ToString() + "不存在\r\n";
                            continue;
                        }
                        if (dtTemp.Rows[0]["cHandler"].ToString().Trim() != "")
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + " 对应单据" + dtTemp.Rows[0]["cCode"].ToString() + "已审核\r\n";
                            continue;
                        }
                        if (dtTemp.Rows[0]["cAccounter"].ToString().Trim() != "")
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + " 对应单据" + dtTemp.Rows[0]["cCode"].ToString() + "已记账\r\n";
                            continue;
                        }
                        decimal d单据未入货位数量 = ClsBaseDataInfo.ReturnObjectToDecimal(dtTemp.Rows[0]["iQuantity"]) - ClsBaseDataInfo.ReturnObjectToDecimal(dtTemp.Rows[0]["iQty"]);

                        //判断条码是否已经使用
                        sSQL = "select * from rdrecords01 where BarCode = '" + s条形码 + "' and isnull(iQuantity,0) > 0 ";
                        int iCou = ClsBaseDataInfo.ReturnObjectToInt(SqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));
                        if (iCou > 0)
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + "已经使用\n";
                            continue;
                        }

                        sSQL = @"
select a.*,b.cInvName,b.cInvStd,b.bInvBatch,e.cVenCode,e.iQuantity,e.iNum,e.cWhCode,isnull(g.bWhPos ,0) as bWhPos,RdsID,RdID,b.cInvCode,e.cBatch ,b.cAssComUnitCode
    ,f.cVenName
from 条形码信息 a inner join Inventory b on a.存货编码 = b.cInvCode 	
	inner join (
					select a.cCode,b.irowno, d.cVenCode,b.cInvCode,b.iQuantity,b.iNum,a.cWhCode,b.AutoID as RdsID,a.id as RdID,b.cBatch 
					FROM dbo.RdRecord01 a INNER JOIN dbo.rdrecords01 b ON a.id = b.id
	                    INNER JOIN dbo.PO_Podetails c ON c.ID = b.iPOsID
	                    INNER JOIN dbo.PO_Pomain d ON c.POID = d.POID
				) e on e.cInvCode = a.存货编码 AND a.采购入库单号 = e.cCode AND a.采购入库单行号 = e.irowno
    inner join Vendor f on e.cVenCode = f.cVenCode
    inner join Warehouse g on g.cWhCode = e.cWhCode
where a.条形码  = '222222'
";

                        sSQL = sSQL.Replace("222222", s条形码);
                        DataTable dt条码信息 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if(dt条码信息 == null || dt条码信息.Rows.Count == 0 )
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + " 信息获取失败\n";
                            continue;
                        }


                        if (Convert.ToInt32(dt条码信息.Rows[0]["bWhPos"]) == 0)
                        {
                            sSQL = "update rdrecords01 set BarCode = '" + s条形码 + "' where autoid = " + dt条码信息.Rows[0]["RdsID"].ToString().Trim();
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        else
                        {
                            sSQL = "update rdrecords01 set BarCode = '" + s条形码 + "',cPosition = '" + dtData.Rows[i]["货位"].ToString().Trim() + "' where autoid = " + dt条码信息.Rows[0]["RdsID"].ToString().Trim();
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            string s仓库 = dt条码信息.Rows[0]["cWhCode"].ToString().Trim();
                            string lID = dt条码信息.Rows[0]["RdID"].ToString().Trim();
                            string lIDDetail = dt条码信息.Rows[0]["RdsID"].ToString().Trim();
                            string s存货编码 = dt条码信息.Rows[0]["cInvCode"].ToString().Trim();
                            decimal d数量 = ClsBaseDataInfo.ReturnObjectToDecimal(dt条码信息.Rows[0]["iQuantity"]);
                            decimal d件数 = ClsBaseDataInfo.ReturnObjectToDecimal(dt条码信息.Rows[0]["iNum"]);
                            string s制单人 = dtData.Rows[i]["制单人"].ToString().Trim();


                            if (d单据未入货位数量 != d数量)
                            {
                                sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + " 数量与单据不匹配\n";
                                continue;
                            }

                            //货位登记
                            sSQL = "insert into InvPosition( RdsID, RdID, cWhCode, cPosCode, cInvCode, cBatch, cFree1, cFree2, dVDate, iQuantity" +
                                        ", iNum, cMemo, cHandler, dDate, bRdFlag, cSource, cFree3, cFree4, cFree5, cFree6" +
                                        ", cFree7, cFree8, cFree9, cFree10, cAssUnit, cBVencode, iTrackId,  dMadeDate, iMassDate" +
                                        ", cMassUnit, cvmivencode, iExpiratDateCalcu, cExpirationdate, dExpirationdate, cvouchtype, cInVouchType, cVerifier, dVeriDate, dVouchDate) " +
                                    "values(" + lIDDetail + "," + lID + ",'" + s仓库 + "'," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["货位"].ToString()) + ",'" + s存货编码 + "'," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["批号"].ToString()) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["长度"].ToString()) + ",null,null," + ClsBaseDataInfo.ReturnCol(d数量) + " " +
                                    "," + ClsBaseDataInfo.ReturnCol(d件数) + ",null,'" + s制单人 + "','" + d当前服务器时间.ToString("yyyy-MM-dd") + "',1,null,null,null,null,null" +
                                    ",null,null,null,null," + ClsBaseDataInfo.ReturnCol(dt条码信息.Rows[0]["cAssComUnitCode"].ToString()) + ",null,0,null,null" +
                                    ",null,null,0,null,null,'01','',null,null,'" + d当前服务器时间.ToString("yyyy-MM-dd") + "')";
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            sSQL = "if exists( select * from InvPositionSum where cInvCode = '" + s存货编码 + "' and cWhCode = '" + s仓库 + "' and cPosCode = " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["货位"].ToString()) + " and ISNULL(cBatch,'') = '" + dtData.Rows[i]["批号"].ToString().Trim() + "' and isnull(cFree1,'') = '" + dtData.Rows[i]["长度"].ToString().Trim() + "') " +
                                "   update InvPositionSum set iQuantity = iQuantity +  " + ClsBaseDataInfo.ReturnCol(d数量) + ",iNum = iNum +  " + ClsBaseDataInfo.ReturnCol(d件数) + " where cInvCode = '" + s存货编码 + "' and cWhCode = '" + s仓库 + "' and cPosCode = " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["货位"].ToString()) + " and ISNULL(cBatch,'') = '" + dtData.Rows[i]["批号"].ToString().Trim() + "'  and isnull(cFree1,'') = '" + dtData.Rows[i]["长度"].ToString().Trim() + "' " +
                                "else " +
                                "insert InvPositionSum(cWhCode, cPosCode, cInvCode, iQuantity, inum, cBatch, cFree1, cFree2, cFree3" +
                                    " , cFree4, cFree5, cFree6, cFree7, cFree8, cFree9, cFree10, iTrackid, cvmivencode, cMassUnit" +
                                    ", iMassDate, dMadeDate, dVDate, iExpiratDateCalcu, cExpirationdate, dExpirationdate, cInVouchType) " +
                                "values(  '" + s仓库 + "', " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["货位"].ToString()) + ", '" + s存货编码 + "',  " + ClsBaseDataInfo.ReturnCol(d数量) + ",  " + ClsBaseDataInfo.ReturnCol(d件数) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["批号"].ToString()) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["长度"].ToString()) + ", null, null" +
                                    " , null, null, null, null, null, null, null, 0, null, null" +
                                    ", null, null, null, 0, null, null, null)";
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                    }

                    if (sErr.Trim().Length > 0)
                    {
                        throw new Exception(sErr);
                    }

                    tran.Commit();
                    s = "生成入库数据成功";
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
        private string sGetCode(long l,int iLength)
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

        public string Chk采购入库条码是否已经使用(string sBarCode)
        {
            string s = "";

            try
            {
                string sSQL = "select count(1) from rdrecords01 where isnull(BarCode ,'') = '" + sBarCode + "'";
                s = ClsBaseClass.SqlHelper.ExecuteScalar(ClsBaseClass.ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).ToString();
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string dt采购条码信息(string sBarCode)
        {
            string s = "";
            try
            {
                string sSQL = @"
select a.采购入库单号,b.cInvCode AS 存货编码,b.cInvName,b.cInvStd
	,rds.cBatch AS 批号,rds.cBatchProperty6 AS 炉号,rds.cDefine22 AS 公差,rds.cDefine23 AS 喷漆颜色
	,rds.cDefine25 AS 包装规格,rds.cDefine27 AS 倒角,rds.cDefine28 AS 研磨,rds.cDefine29 AS 机台, rds.cBatchProperty7 AS 生产客户,rds.cBatchProperty8 AS 公差2
	,rds.cFree1 AS 长度
    ,v.cVenName,v.cVenCode
    ,rds.iQuantity
	,rds.barcode
	,InvPos.iPosQty
from 条形码信息 a inner join Inventory b on a.存货编码 = b.cInvCode 	
	INNER JOIN rdrecords01 rds ON rds.irowno = a.采购入库单行号
	INNER JOIN rdrecord01 rd ON rds.id = rd.id AND rd.cCode = 采购入库单号
	INNER JOIN PO_Podetails pos ON pos.ID = rds.iPOsID
	INNER JOIN dbo.PO_Pomain po ON po.poid = pos.POID
	INNER JOIN vendor v ON v.cVenCode = po.cVenCode
	left join (select RdsID,RdID ,cInvCode ,sum(iQuantity) as iPosQty  from InvPosition group by RdsID,RdID ,cInvCode) InvPos 
		on InvPos.RdsID = rds.autoid and InvPos.cInvCode = rds.cInvCode and InvPos.RdID = rd.id
where a.条形码  = '222222'
";

                sSQL = sSQL.Replace("222222", sBarCode);

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
