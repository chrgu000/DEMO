using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using ClsBaseClass;

namespace ClsU8
{
    public class Cls产品入库单
    {
        public string Save产品入库单(DataTable dtData)
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
                    sSQL = "select * From VoucherHistory  with (ROWLOCK) Where  CardNumber='0411'";
                    dtTemp = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp == null || dtTemp.Rows.Count < 1)
                    {
                        iCode = 1;
                    }
                    else
                    {
                        iCode = ClsBaseDataInfo.ReturnObjectToLong(dtTemp.Rows[0]["cNumber"]);
                    }


                    sSQL = "select * from mom_order a inner join mom_orderdetail b on a.moid = b.moid where a.mocode = '" + dtData.Rows[0]["单据号"].ToString().Trim() + "' ";
                    DataTable dt生产订单表头 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt生产订单表头 == null || dt生产订单表头.Rows.Count < 1)
                    {
                        throw new Exception("获得生产订单信息失败");
                    }

                    //4. 组装表头
                    lID += 1;
                    string s仓库 =dtData.Rows[0]["仓库"].ToString().Trim();
                    string s订单号 = dtData.Rows[0]["单据号"].ToString().Trim();
                    string s行号 = dtData.Rows[0]["行号"].ToString().Trim();
                    string s制单人 =dtData.Rows[0]["制单人"].ToString().Trim();
                    string s生产订单主表标志 = dt生产订单表头.Rows[0]["MOID"].ToString().Trim();
                    iCode += 1;
                    string s单据号 = sGetCode(iCode, 10);

                    sSQL = " insert into rdrecord10(id,brdflag,cvouchtype,cbustype,csource,cwhcode,ddate,ccode,cmaker,vt_id" +
                                         ",cmpocode,iproorderid,iswfcontrolled,dnmaketime,dnmodifytime,dnverifytime,cRdCode,cdefine1) " +
                           " values (N'" + lID + "',N'1',N'10',N'成品入库',N'生产订单',N'" + s仓库 + "','" + d当前服务器时间.ToString("yyyy-MM-dd") + "',N'" + s单据号 + "',N'" + s制单人 + "',63" +
                                         ",N'" + s订单号 + "',N'" + s生产订单主表标志 + "',0, getdate(), Null , Null,12 ,N'" + s订单号 + "')";
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    //5. [更新采购订单表头] 暂时未发现需要更新的内容

                    for (int i = 0; i < dtData.Rows.Count; i++)
                    {
                        //判断条码是否已经使用
                        sSQL = "select * from rdrecords10 where BarCode = " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["条形码"].ToString()) + " ";
                        int iCou = ClsBaseDataInfo.ReturnObjectToInt(SqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));
                        if (iCou > 0)
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + "已经使用\n";
                            continue;
                        }

                        sSQL = @"
select * ,d.CompleteQty - b.QualifiedInQty   AS QtyUnIn
from mom_order a inner join mom_orderdetail b on a.moid = b.moid 
	LEFT JOIN sfc_moroutingdetail d ON b.MoDId = d.MoDId AND d.LastFlag = 1 
where a.mocode = '" + dtData.Rows[i]["单据号"].ToString().Trim() + "' and b.SortSeq = '" + dtData.Rows[i]["行号"].ToString().Trim() + "'";


                        DataTable dt生产订单 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt生产订单 == null || dt生产订单.Rows.Count < 1)
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + "获得生产订单信息失败\n";
                            continue;
                        }

                        if (ClsBaseClass.ClsBaseDataInfo.ReturnObjectToDecimal(dt生产订单.Rows[0]["CompleteQty"], 2) == 0 && ClsBaseClass.ClsBaseDataInfo.ReturnObjectToInt(dt生产订单.Rows[0]["MoClass"]) == 1)
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + "对应生产订单订单工序未完成\n";
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


                        decimal d生产订单数量 = ClsBaseDataInfo.ReturnObjectToDecimal(dt生产订单.Rows[0]["Qty"], 6);
                        decimal d生产订单数件数 = ClsBaseDataInfo.ReturnObjectToDecimal(dt生产订单.Rows[0]["AuxQty"], 6);

                        decimal d累计入库数量 = ClsBaseDataInfo.ReturnObjectToDecimal(dt生产订单.Rows[0]["QualifiedInQty"], 6);

                        decimal d件数 = 1;
                        //if (d生产订单数件数 != 0)
                        //{
                        //    d件数 = ClsBaseDataInfo.ReturnObjectToDecimal(d生产订单数件数 * d数量 / d生产订单数量, 6);
                        //}

                        decimal d换算率 = d数量;

                        decimal d入库超额上限 = ClsBaseDataInfo.ReturnObjectToDecimal(dt存货信息.Rows[0]["fInExcess"], 6);
                        //if (d生产订单数量 * (1 + d入库超额上限 / 100) < d累计入库数量 + d数量)
                        //{
                        //    sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + ":" + dtData.Rows[i]["存货编码"].ToString().Trim() + "累计入库数量超订单\n";
                        //    continue;
                        //}


                        sSQL = "select * from Warehouse where cWhCode = '" + s仓库 + "'";
                        DataTable dtWH = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        string s销售订单号 = dt生产订单.Rows[0]["OrderCode"].ToString().Trim();
                        string s销售订单行号 =dt生产订单.Rows[0]["OrderSeq"].ToString().Trim();

                        sSQL = "Insert Into rdrecords10(autoid,id,cinvcode,inum,iquantity,iunitcost,iprice,ipunitcost,ipprice,cbatch" +
                                        ",cvouchcode,cinvouchcode,cinvouchtype,isoutquantity,isoutnum,cfree1,cfree2,ifnum,ifquantity,dvdate" +
                                        ",cposition,cdefine22,cdefine23,cdefine24,cdefine25,cdefine26,cdefine27,citem_class,citemcode,cname" +
                                        ",citemcname,cfree3,cfree4,cfree5,cfree6,cfree7,cfree8,cfree9,cfree10,BarCode" +
                                        ",inquantity,innum,cassunit,dmadedate,imassdate,cdefine28,cdefine29,cdefine30,cdefine31,cdefine32" +
                                        ",cdefine33,cdefine34,cdefine35,cdefine36,cdefine37,impoids,icheckids,cbvencode,ccheckcode,icheckidbaks" +
                                        ",crejectcode,irejectids,ccheckpersoncode,dcheckdate,cmassunit,cmolotcode,brelated,cmworkcentercode,cbaccounter,dbkeepdate" +
                                        ",bcosting,bvmiused,ivmisettlequantity,ivmisettlenum,cvmivencode,iinvsncount,iinvexchrate,corufts,cmocode,imoseq" +
                                        ",iopseq,copdesc,iexpiratdatecalcu,cexpirationdate,dexpirationdate,cciqbookcode,ibondedsumqty,productinids,iorderdid,iordertype" +
                                        ",iordercode,iorderseq,isodid,isotype,csocode,isoseq,cbatchproperty1,cbatchproperty2,cbatchproperty3,cbatchproperty4" +
                                        ",cbatchproperty5,cbatchproperty6,cbatchproperty7,cbatchproperty8,cbatchproperty9,cbatchproperty10,cbmemo,irowno,strowguid,cservicecode) " +
                               "Values (" + lIDDetail + "," + lID + ",N'" + s存货编码 + "'," + ClsBaseDataInfo.ReturnCol(d件数) + "," + ClsBaseDataInfo.ReturnCol(d数量) + ",Null,Null,Null,Null," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["批号"].ToString()) + "" +
                                        ",Null,Null,Null,Null,Null," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["长度"].ToString()) + ",Null,Null,Null,Null" +
                                        "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["货位"].ToString()) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["条形码"].ToString()) + ",null,null,null,Null,Null,Null,Null,Null" +
                                        ",Null,Null,Null,Null,Null,Null,Null,Null,Null," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["条形码"].ToString()) + "" +
                                        "," + d生产订单数量 + "," + d生产订单数件数 + ",N'" + dt存货信息.Rows[0]["cAssComUnitCode"].ToString().Trim() + "',Null,Null,Null,Null,Null,Null,Null" +
                                        ",Null,Null,Null,Null,Null," + dt生产订单.Rows[0]["Modid"] + ",Null,Null,Null,Null" +
                                        ",Null,Null,Null,Null,Null,Null,0,Null,Null,Null" +
                                        ",1,Null,Null,Null,Null,Null," + d换算率 + ",N'13548.9432',N'" + dtData.Rows[i]["单据号"].ToString() + "'," + dtData.Rows[i]["行号"].ToString() + "" +
                                        ",Null,Null,0,Null,Null,Null,Null,Null," + dt生产订单.Rows[0]["Modid"] + ",1" +
                                        ",N'" + s销售订单号 + "','" + s销售订单行号 + "',Null,0,Null,Null,Null,Null,Null,Null" +
                                        ",Null," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["炉号"].ToString()) + ",Null,Null,Null,Null,Null," + (i+1).ToString() + ",Null,Null)";
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        sSQL = "Update 条形码信息 set  产成品入库单号 = '" + s单据号 + "',产成品入库单行号 = " + (i + 1).ToString() + " where 条形码 = '" + dtData.Rows[i]["条形码"].ToString().Trim() + "'";
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        //sSQL = "insert into IA_ST_UnAccountVouch10(idun,idsun,cvoutypeun,cbustypeun)values " +
                        //        "('" + lID + "','" + lIDDetail + "','10','成品入库')";
                        //SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

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


                        //更新现存量
                        sSQL = "declare @itmeid int " +
                              "select @itmeid = MAX(ItemId) + 1 from CurrentStock " +
                              "if exists(select * from CurrentStock where cinvcode = '" + s存货编码 + "' and isnull(cFree1,'') = '" + dtData.Rows[i]["长度"].ToString().Trim() + "'  and isnull(cBatch,'') = '" + dtData.Rows[i]["批号"].ToString() + "' and cWhCode = '" + s仓库 + "') " +
                               "    update CurrentStock set iQuantity = isnull(iQuantity,0) + " + ClsBaseDataInfo.ReturnCol(d数量) + ",iNum = isnull(iNum,0) + " + ClsBaseDataInfo.ReturnCol(d件数) + " where cinvcode = '" + s存货编码 + "' and isnull(cBatch,'') = '" + dtData.Rows[i]["批号"].ToString() + "' and cWhCode = '" + s仓库 + "' and isnull(cFree1,'') = '" + dtData.Rows[i]["长度"].ToString().Trim() + "' " +
                               "else " +
                               "    insert into CurrentStock(cWhCode,cInvCode,cBatch,iSoType,iQuantity,iNum,ItemId,cFree1)  " +
                               "    values('" + s仓库 + "', '" + s存货编码 + "'," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["批号"].ToString()) + ",0," + ClsBaseDataInfo.ReturnCol(d数量) + "," + ClsBaseDataInfo.ReturnCol(d件数) + "," + lItemID + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["长度"].ToString()) + ")";
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                        sSQL = "update mom_orderdetail set QualifiedInQty  = isnull(QualifiedInQty ,0) + " + ClsBaseDataInfo.ReturnCol(d数量) + "  where Modid = " + ClsBaseDataInfo.ReturnCol(dt生产订单.Rows[0]["Modid"].ToString());
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        if (Convert.ToInt32(dtWH.Rows[0]["bWhPos"]) != 0)
                        {
                            //货位登记
                            sSQL = "insert into InvPosition( RdsID, RdID, cWhCode, cPosCode, cInvCode, cBatch, cFree1, cFree2, dVDate, iQuantity" +
                                        ", iNum, cMemo, cHandler, dDate, bRdFlag, cSource, cFree3, cFree4, cFree5, cFree6" +
                                        ", cFree7, cFree8, cFree9, cFree10, cAssUnit, cBVencode, iTrackId,  dMadeDate, iMassDate" +
                                        ", cMassUnit, cvmivencode, iExpiratDateCalcu, cExpirationdate, dExpirationdate, cvouchtype, cInVouchType, cVerifier, dVeriDate, dVouchDate) " +
                                    "values(" + lIDDetail + "," + lID + ",'" + s仓库 + "'," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["货位"].ToString()) + ",'" + s存货编码 + "'," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["批号"].ToString()) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["长度"].ToString()) + ",null,null," + ClsBaseDataInfo.ReturnCol(d数量) + " " +
                                    "," + ClsBaseDataInfo.ReturnCol(d件数) + ",null,'" + s制单人 + "','" + d当前服务器时间.ToString("yyyy-MM-dd") + "',1,null,null,null,null,null" +
                                    ",null,null,null,null," + ClsBaseDataInfo.ReturnCol(dt存货信息.Rows[0]["cAssComUnitCode"].ToString()) + ",null,0,null,null" +
                                    ",null,null,0,null,null,'10','',null,null,'" + d当前服务器时间.ToString("yyyy-MM-dd") + "')";
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            sSQL = "if exists( select * from InvPositionSum where cInvCode = '" + s存货编码 + "' and cWhCode = '" + s仓库 + "' and cPosCode = " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["货位"].ToString()) + " and ISNULL(cBatch,'') = '" + dtData.Rows[i]["批号"].ToString().Trim() + "' and isnull(cFree1,'') = " + dtData.Rows[i]["长度"].ToString().Trim() + ") " +
                                "   update InvPositionSum set iQuantity = iQuantity +  " + ClsBaseDataInfo.ReturnCol(d数量) + ",iNum = iNum +  " + ClsBaseDataInfo.ReturnCol(d件数) + " where cInvCode = '" + s存货编码 + "' and cWhCode = '" + s仓库 + "' and cPosCode = " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["货位"].ToString()) + " and ISNULL(cBatch,'') = '" + dtData.Rows[i]["批号"].ToString().Trim() + "'  and isnull(cFree1,'') = " + dtData.Rows[i]["长度"].ToString().Trim() + " " +
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

                    //更新批次属性档案
                    sSQL = @"

IF Object_id('Tempdb..#STBatchArchief') IS NOT NULL   
	DROP TABLE #STBatchArchief

 select distinct convert(int,1) as autoid , a.cinvcode as cinvcode , isnull(a.cbatch ,'') as cbatch, isnull(a.cfree1,'') as cfree1
	, isnull(a.cfree2,'') as cfree2, isnull(a.cfree3,'') as cfree3, isnull(a.cfree4,'') as cfree4, isnull(a.cfree5,'') as cfree5
	, isnull(a.cfree6,'') as cfree6, isnull(a.cfree7,'') as cfree7, isnull(a.cfree8,'') as cfree8, isnull(a.cfree9,'') as cfree9
	, isnull(a.cfree10,'') as cfree10, a.cBatchProperty1 as cBatchProperty1, a.cBatchProperty2 as cBatchProperty2
	, a.cBatchProperty3 as cBatchProperty3, a.cBatchProperty4 as cBatchProperty4, a.cBatchProperty5 as cBatchProperty5
	, a.cBatchProperty6 as cBatchProperty6, a.cBatchProperty7 as cBatchProperty7, a.cBatchProperty8 as cBatchProperty8
	, a.cBatchProperty9 as cBatchProperty9, a.cBatchProperty10 as cBatchProperty10 
	into #STBatchArchief  
from rdrecords10 a with (nolock)  inner join inventory_sub b   with (nolock)  on a.cinvcode = b.cinvsubcode and isnull(bbatchcreate,0)=1  
where a.id =aaaaaaaaaa and isnull(a.cbatch ,'')<>'' 

 exec Scm_SaveBatchProperty '1','autoid','#STBatchArchief',N'demo'

 drop table #STBatchArchief
 
";
                    sSQL = sSQL.Replace("aaaaaaaaaa", lID.ToString());
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                    //7. 更新历史单据号表
                    sSQL = "update VoucherHistory set cNumber='" + iCode + "' Where  CardNumber='0411' and cContent is NULL";
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                    //8. 登记未记账
                    sSQL = @"exec IA_SP_WriteUnAccountVouchForST aaaaaa,N'10'";
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

        public string Chk产品入库条码是否已经使用(string sBarCode)
        {
            string s = "";

            try
            {
                string sSQL = "select count(1) from rdrecords10 where isnull(BarCode ,'') = '" + sBarCode + "'";
                s = ClsBaseClass.SqlHelper.ExecuteScalar(ClsBaseClass.ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).ToString();
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string dt产品条码信息(string sBarCode, string sCode)
        {
            string s = "";
            try
            {
                string sSQL = @"
select a.*,b.cInvName,b.cInvStd,b.bInvBatch,e.cVenCode,e.iQuantity,e.iReceivedQTY,e.iQuantity - isnull(e.iReceivedQTY,0) as iQty
from 条形码信息 a inner join Inventory b on a.存货编码 = b.cInvCode 	
	inner join (
					select c.cVenCode,d.cInvCode,sum(d.iQuantity) as iQuantity,SUM(isnull(iReceivedQTY,0)) as iReceivedQTY 
					from PO_Pomain c inner join PO_Podetails d on c.POID = d.POID 
					where c.cPOID = '111111' 
					group by c.cVenCode,d.cInvCode
				) e on e.cInvCode = a.存货编码
where a.条形码  = '222222'
";

                sSQL = sSQL.Replace("111111", sCode);
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

        public string dt产品入库条码信息(string sBarCode)
        {
            string s = "";
            try
            {
                string sSQL = @"
select a.*, b.cInvName,b.cInvStd,b.bInvBatch,e.生产订单数量,e.入库数量,e.报检数量
from 条形码信息 a inner join Inventory b on a.存货编码 = b.cInvCode 	
	inner join (
					select b.InvCode as 母件编码, a.mocode,b.SortSeq ,b.Qty as 生产订单数量,b.AuxQty as 生产订单件数,b.QualifiedInQty as 入库数量,b.DeclaredQty  as 报检数量
                    from mom_order a inner join mom_orderdetail b on a.moid = b.moid
                    where b.Status = 3   
				) e on e.母件编码 = a.存货编码 and e.mocode = a.生产订单号 and a.行号 = e.SortSeq
where a.条形码  = '333333'
";
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
