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
                    string s单据号 = sGetCode(iCode, 4, "CPRK04" + d当前服务器时间.ToString("yyMM"));

                    sSQL = " insert into rdrecord10(id,brdflag,cvouchtype,cbustype,csource,cwhcode,ddate,ccode,cmaker,vt_id" +
                                         ",cmpocode,iproorderid,iswfcontrolled,dnmaketime,dnmodifytime,dnverifytime,cRdCode,cdefine1,cDefine14) " +
                           " values (N'" + lID + "',N'1',N'10',N'成品入库',N'生产订单',N'" + s仓库 + "','" + d当前服务器时间.ToString("yyyy-MM-dd") + "',N'" + s单据号 + "',N'" + s制单人 + "',63" +
                                         ",N'" + s订单号 + "',N'" + s生产订单主表标志 + "',0, getdate(), Null , Null,12 ,N'" + s订单号 + "','Y')";
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    //5. [更新采购订单表头] 暂时未发现需要更新的内容

                    for (int i = 0; i < dtData.Rows.Count; i++)
                    {
                        //判断条码是否已经使用
                        //sSQL = "select * from rdrecords10 where cdefine22 = " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["条形码"].ToString()) + " ";
                        //int iCou = ClsBaseDataInfo.ReturnObjectToInt(SqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));
                        //if (iCou > 0)
                        //{
                        //    sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + "已经使用\n";
                        //    continue;
                        //}

                        sSQL = "select * from mom_order a inner join mom_orderdetail b on a.moid = b.moid where a.mocode = '" + dtData.Rows[i]["单据号"].ToString().Trim() + "' and b.SortSeq = '" + dtData.Rows[i]["行号"].ToString().Trim() + "'";
                        DataTable dt生产订单 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt生产订单 == null || dt生产订单.Rows.Count < 1)
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + "获得生产订单信息失败\n";
                            continue;
                        }
                        #region 存货自由项
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
                        if (i是否自由项1 != 0 && dtData.Rows[i]["cFree1"].ToString().Trim() == "")
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + ":" + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入自由项1\n";
                            continue;
                        }

                        int i是否自由项2 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree2"]);
                        if (i是否自由项2 != 0 && dtData.Rows[i]["cFree2"].ToString().Trim() == "")
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + ":" + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入自由项2\n";
                            continue;
                        }
                        int i是否自由项3 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree3"]);
                        if (i是否自由项3 != 0 && dtData.Rows[i]["cFree3"].ToString().Trim() == "")
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + ":" + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入自由项3\n";
                            continue;
                        }
                        int i是否自由项4 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree4"]);
                        if (i是否自由项4 != 0 && dtData.Rows[i]["cFree4"].ToString().Trim() == "")
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + ":" + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入自由项4\n";
                            continue;
                        }
                        int i是否自由项5 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree5"]);
                        if (i是否自由项5 != 0 && dtData.Rows[i]["cFree5"].ToString().Trim() == "")
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + ":" + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入自由项5\n";
                            continue;
                        }
                        int i是否自由项6 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree6"]);
                        if (i是否自由项6 != 0 && dtData.Rows[i]["cFree6"].ToString().Trim() == "")
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + ":" + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入自由项6\n";
                            continue;
                        }
                        int i是否自由项7 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree7"]);
                        if (i是否自由项7 != 0 && dtData.Rows[i]["cFree7"].ToString().Trim() == "")
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + ":" + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入自由项7\n";
                            continue;
                        }
                        int i是否自由项8 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree8"]);
                        if (i是否自由项8 != 0 && dtData.Rows[i]["cFree8"].ToString().Trim() == "")
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + ":" + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入自由项8\n";
                            continue;
                        }
                        int i是否自由项9 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree9"]);
                        if (i是否自由项9 != 0 && dtData.Rows[i]["cFree9"].ToString().Trim() == "")
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + ":" + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入自由项9\n";
                            continue;
                        }
                        int i是否自由项10 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree10"]);
                        if (i是否自由项10 != 0 && dtData.Rows[i]["cFree10"].ToString().Trim() == "")
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + ":" + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入自由项10\n";
                            continue;
                        }
                        #endregion

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
                         
                        string s销售订单号 = dt生产订单.Rows[0]["OrderCode"].ToString().Trim();
                        string s销售订单行号 =dt生产订单.Rows[0]["OrderSeq"].ToString().Trim();

                        sSQL = "Insert Into rdrecords10(autoid,id,cinvcode,inum,iquantity,iunitcost,iprice,ipunitcost,ipprice,cbatch" +
                                        ",cvouchcode,cinvouchcode,cinvouchtype,isoutquantity,isoutnum,cfree1,cfree2,ifnum,ifquantity,dvdate" +
                                        ",cposition,cdefine22,cdefine23,cdefine24,cdefine25,cdefine26,cdefine27,citem_class,citemcode,cname" +
                                        ",citemcname,cfree3,cfree4,cfree5,cfree6,cfree7,cfree8,cfree9,cfree10,cbarcode" +
                                        ",inquantity,innum,cassunit,dmadedate,imassdate,cdefine28,cdefine29,cdefine30,cdefine31,cdefine32" +
                                        ",cdefine33,cdefine34,cdefine35,cdefine36,cdefine37,impoids,icheckids,cbvencode,ccheckcode,icheckidbaks" +
                                        ",crejectcode,irejectids,ccheckpersoncode,dcheckdate,cmassunit,cmolotcode,brelated,cmworkcentercode,cbaccounter,dbkeepdate" +
                                        ",bcosting,bvmiused,ivmisettlequantity,ivmisettlenum,cvmivencode,iinvsncount,iinvexchrate,corufts,cmocode,imoseq" +
                                        ",iopseq,copdesc,iexpiratdatecalcu,cexpirationdate,dexpirationdate,cciqbookcode,ibondedsumqty,productinids,iorderdid,iordertype" +
                                        ",iordercode,iorderseq,isodid,isotype,csocode,isoseq,cbatchproperty1,cbatchproperty2,cbatchproperty3,cbatchproperty4" +
                                        ",cbatchproperty5,cbatchproperty6,cbatchproperty7,cbatchproperty8,cbatchproperty9,cbatchproperty10,cbmemo,irowno,strowguid,cservicecode) " +
                               "Values (" + lIDDetail + "," + lID + ",N'" + s存货编码 + "'," + ClsBaseDataInfo.ReturnCol(d件数) + "," + ClsBaseDataInfo.ReturnCol(d数量) + ",Null,Null,Null,Null," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["批号"].ToString()) + "" +
                                        ",Null,Null,Null,Null,Null," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cfree1"].ToString().Trim()) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cfree2"].ToString().Trim()) + ",Null,Null,Null" +
                                        "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["货位"].ToString()) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["条形码"].ToString()) + ",null,null,null,Null,Null,Null,Null,Null" +
                                        ",Null," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cfree3"].ToString().Trim()) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cfree4"].ToString().Trim()) + " ,Null,Null,Null,Null,Null,Null,Null" +
                                        "," + d生产订单数量 + "," + d生产订单数件数 + ",N'" + dt存货信息.Rows[0]["cAssComUnitCode"].ToString().Trim() + "',Null,Null,Null,Null,Null,Null,Null" +
                                        ",Null,Null,Null,Null,Null," + dt生产订单.Rows[0]["Modid"] + ",Null,Null,Null,Null" +
                                        ",Null,Null,Null,Null,Null,Null,0,Null,Null,Null" +
                                        ",1,Null,Null,Null,Null,Null," + d换算率 + ",null,N'" + dtData.Rows[i]["单据号"].ToString() + "'," + dtData.Rows[i]["行号"].ToString() + "" +
                                        ",Null,Null,0,Null,Null,Null,Null,Null," + dt生产订单.Rows[0]["Modid"] + ",1" +
                                        ",N'" + s销售订单号 + "','" + s销售订单行号 + "',Null,0,Null,Null,Null,Null,Null,Null" +
                                        ",Null," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["炉号"].ToString()) + ",Null,Null,Null,Null,Null,1,Null,Null)";
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        sSQL = "insert into IA_ST_UnAccountVouch10(idun,idsun,cvoutypeun,cbustypeun)values " +
                                "('" + lID + "','" + lIDDetail + "','10','成品入库')";
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        sSQL = "select * from SCM_Item where cInvCode = '" + s存货编码 + "' and ISNULL(cFree1,'') = '" + dtData.Rows[i]["cFree1"].ToString().Trim() + "' and ISNULL(cFree2,'') = '" + dtData.Rows[i]["cFree2"].ToString().Trim() + "' and ISNULL(cFree3,'') = '" + dtData.Rows[i]["cFree3"].ToString().Trim() + "' and ISNULL(cFree4,'') = '" + dtData.Rows[i]["cFree4"].ToString().Trim() + "' and ISNULL(cFree5,'') = '" + dtData.Rows[i]["cFree5"].ToString().Trim() + "' and ISNULL(cFree6,'') = '" + dtData.Rows[i]["cFree6"].ToString().Trim() + "' and ISNULL(cFree7,'') = '" + dtData.Rows[i]["cFree7"].ToString().Trim() + "' and ISNULL(cFree8,'') = '" + dtData.Rows[i]["cFree8"].ToString().Trim() + "' and ISNULL(cFree9,'') = '" + dtData.Rows[i]["cFree9"].ToString().Trim() + "' and ISNULL(cFree10,'') = '" + dtData.Rows[i]["cFree10"].ToString().Trim() + "' ";
                        DataTable dtTemp2 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        long lItemID = 0;
                        if (dtTemp2 == null || dtTemp2.Rows.Count == 0)
                        {
                            sSQL = "insert into SCM_Item(cInvCode,cFree1,cFree2,cFree3,cFree4,cFree5,cFree6,cFree7,cFree8,cFree9,cFree10,PartId) " +
                                    "values('" + s存货编码 + "','" + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree1"]) + "'," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree1"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree2"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree3"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree4"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree5"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree6"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree7"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree8"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree9"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree10"]) + ",0)";
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            sSQL = "select * from SCM_Item where cInvCode = '" + s存货编码 + "' and ISNULL(cFree1,'') = '" + dtData.Rows[i]["cFree1"].ToString().Trim() + "' and ISNULL(cFree2,'') = '" + dtData.Rows[i]["cFree2"].ToString().Trim() + "' and ISNULL(cFree3,'') = '" + dtData.Rows[i]["cFree3"].ToString().Trim() + "' and ISNULL(cFree4,'') = '" + dtData.Rows[i]["cFree4"].ToString().Trim() + "' and ISNULL(cFree5,'') = '" + dtData.Rows[i]["cFree5"].ToString().Trim() + "' and ISNULL(cFree6,'') = '" + dtData.Rows[i]["cFree6"].ToString().Trim() + "' and ISNULL(cFree7,'') = '" + dtData.Rows[i]["cFree7"].ToString().Trim() + "' and ISNULL(cFree8,'') = '" + dtData.Rows[i]["cFree8"].ToString().Trim() + "' and ISNULL(cFree9,'') = '" + dtData.Rows[i]["cFree9"].ToString().Trim() + "' and ISNULL(cFree10,'') = '" + dtData.Rows[i]["cFree10"].ToString().Trim() + "' ";
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
                                   "if exists(select * from CurrentStock where cinvcode = '" + s存货编码 + "' and isnull(cBatch,'') = isnull(" + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["批号"].ToString()) + ",'')  and cWhCode = '" + s仓库 + "' and ISNULL(cFree1,'') = '" + dtData.Rows[i]["cFree1"].ToString().Trim() + "' and ISNULL(cFree2,'') = '" + dtData.Rows[i]["cFree2"].ToString().Trim() + "' and ISNULL(cFree3,'') = '" + dtData.Rows[i]["cFree3"].ToString().Trim() + "' and ISNULL(cFree4,'') = '" + dtData.Rows[i]["cFree4"].ToString().Trim() + "' and ISNULL(cFree5,'') = '" + dtData.Rows[i]["cFree5"].ToString().Trim() + "' and ISNULL(cFree6,'') = '" + dtData.Rows[i]["cFree6"].ToString().Trim() + "' and ISNULL(cFree7,'') = '" + dtData.Rows[i]["cFree7"].ToString().Trim() + "' and ISNULL(cFree8,'') = '" + dtData.Rows[i]["cFree8"].ToString().Trim() + "' and ISNULL(cFree9,'') = '" + dtData.Rows[i]["cFree9"].ToString().Trim() + "' and ISNULL(cFree10,'') = '" + dtData.Rows[i]["cFree10"].ToString().Trim() + "') " +
                                   "    update CurrentStock set iQuantity = isnull(iQuantity,0) + " + ClsBaseDataInfo.ReturnCol(d数量) + ",iNum = isnull(iNum,0) + " + ClsBaseDataInfo.ReturnCol(d件数) + " " +
                                   "    where cinvcode = '" + s存货编码 + "' and isnull(cBatch,'') = isnull(" + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["批号"].ToString()) + ",'') and cWhCode = '" + s仓库 + "' and ISNULL(cFree1,'') = '" + dtData.Rows[i]["cFree1"].ToString().Trim() + "' and ISNULL(cFree2,'') = '" + dtData.Rows[i]["cFree2"].ToString().Trim() + "' and ISNULL(cFree3,'') = '" + dtData.Rows[i]["cFree3"].ToString().Trim() + "' and ISNULL(cFree4,'') = '" + dtData.Rows[i]["cFree4"].ToString().Trim() + "' and ISNULL(cFree5,'') = '" + dtData.Rows[i]["cFree5"].ToString().Trim() + "' and ISNULL(cFree6,'') = '" + dtData.Rows[i]["cFree6"].ToString().Trim() + "' and ISNULL(cFree7,'') = '" + dtData.Rows[i]["cFree7"].ToString().Trim() + "' and ISNULL(cFree8,'') = '" + dtData.Rows[i]["cFree8"].ToString().Trim() + "' and ISNULL(cFree9,'') = '" + dtData.Rows[i]["cFree9"].ToString().Trim() + "' and ISNULL(cFree10,'') = '" + dtData.Rows[i]["cFree10"].ToString().Trim() + "' " +
                                   "else " +
                                   "    insert into CurrentStock(cWhCode,cInvCode,cBatch,iSoType,iQuantity,iNum,ItemId,cFree1,cFree2,cFree3,cFree4,cFree5,cFree6,cFree7,cFree8,cFree9,cFree10)  " +
                                   "    values('" + s仓库 + "', '" + s存货编码 + "'," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["批号"].ToString()) + ",0," + ClsBaseDataInfo.ReturnCol(d数量) + "," + ClsBaseDataInfo.ReturnCol(d件数) + "," + lItemID + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree1"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree2"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree3"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree4"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree5"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree6"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree7"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree8"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree9"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree10"]) + ")";
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        sSQL = "update mom_orderdetail set QualifiedInQty  = isnull(QualifiedInQty ,0) + " + ClsBaseDataInfo.ReturnCol(d数量) + "  where Modid = " + ClsBaseDataInfo.ReturnCol(dt生产订单.Rows[0]["Modid"].ToString());
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                        //货位登记
                        sSQL = "insert into InvPosition( RdsID, RdID, cWhCode, cPosCode, cInvCode, cBatch, cFree1, cFree2, dVDate, iQuantity" +
                                    ", iNum, cMemo, cHandler, dDate, bRdFlag, cSource, cFree3, cFree4, cFree5, cFree6" +
                                    ", cFree7, cFree8, cFree9, cFree10, cAssUnit, cBVencode, iTrackId,  dMadeDate, iMassDate" +
                                    ", cMassUnit, cvmivencode, iExpiratDateCalcu, cExpirationdate, dExpirationdate, cvouchtype, cInVouchType, cVerifier, dVeriDate, dVouchDate) " +
                                "values(" + lIDDetail + "," + lID + ",'" + s仓库 + "'," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["货位"].ToString()) + ",'" + s存货编码 + "'," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["批号"].ToString()) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree1"].ToString()) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree2"].ToString()) + ",null," + ClsBaseDataInfo.ReturnCol(d数量) + " " +
                                "," + ClsBaseDataInfo.ReturnCol(d件数) + ",null,'" + s制单人 + "','" + d当前服务器时间.ToString("yyyy-MM-dd") + "',1,null," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree3"].ToString()) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree4"].ToString()) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree5"].ToString()) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree6"].ToString()) + "" +
                                "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree7"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree8"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree9"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree10"]) + "," + ClsBaseDataInfo.ReturnCol(dt存货信息.Rows[0]["cAssComUnitCode"].ToString()) + ",null,0,null,null" +
                                ",null,null,0,null,null,'10','',null,null,'" + d当前服务器时间.ToString("yyyy-MM-dd") + "')";
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        sSQL = "if exists( select * from InvPositionSum where cInvCode = '" + s存货编码 + "' and cWhCode = '" + s仓库 + "' and cPosCode = " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["货位"].ToString()) + " and ISNULL(cBatch,'') = '" + dtData.Rows[i]["批号"].ToString().Trim() + "' "+
                            "and isnull(cFree1,'') = '" + dtData.Rows[i]["cFree1"].ToString().Trim() + "'  and ISNULL(cFree2,'') = '" + dtData.Rows[i]["cFree2"].ToString().Trim() + "' and ISNULL(cFree3,'') = '" + dtData.Rows[i]["cFree3"].ToString().Trim() + "' and ISNULL(cFree4,'') = '" + dtData.Rows[i]["cFree4"].ToString().Trim() + "' and ISNULL(cFree5,'') = '" + dtData.Rows[i]["cFree5"].ToString().Trim() + "' and ISNULL(cFree6,'') = '" + dtData.Rows[i]["cFree6"].ToString().Trim() + "' and ISNULL(cFree7,'') = '" + dtData.Rows[i]["cFree7"].ToString().Trim() + "' and ISNULL(cFree8,'') = '" + dtData.Rows[i]["cFree8"].ToString().Trim() + "' and ISNULL(cFree9,'') = '" + dtData.Rows[i]["cFree9"].ToString().Trim() + "' and ISNULL(cFree10,'') = '" + dtData.Rows[i]["cFree10"].ToString().Trim() + "') " +
                            "   update InvPositionSum set iQuantity = iQuantity +  " + ClsBaseDataInfo.ReturnCol(d数量) + ",iNum = iNum +  " + ClsBaseDataInfo.ReturnCol(d件数) + " where cInvCode = '" + s存货编码 + "' and cWhCode = '" + s仓库 + "' and cPosCode = " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["货位"].ToString()) + " and ISNULL(cBatch,'') = '" + dtData.Rows[i]["批号"].ToString().Trim() + "'  "+
                            " and isnull(cFree1,'') = '" + dtData.Rows[i]["cFree1"].ToString().Trim() + "'  and ISNULL(cFree2,'') = '" + dtData.Rows[i]["cFree2"].ToString().Trim() + "' and ISNULL(cFree3,'') = '" + dtData.Rows[i]["cFree3"].ToString().Trim() + "' and ISNULL(cFree4,'') = '" + dtData.Rows[i]["cFree4"].ToString().Trim() + "' and ISNULL(cFree5,'') = '" + dtData.Rows[i]["cFree5"].ToString().Trim() + "' and ISNULL(cFree6,'') = '" + dtData.Rows[i]["cFree6"].ToString().Trim() + "' and ISNULL(cFree7,'') = '" + dtData.Rows[i]["cFree7"].ToString().Trim() + "' and ISNULL(cFree8,'') = '" + dtData.Rows[i]["cFree8"].ToString().Trim() + "' and ISNULL(cFree9,'') = '" + dtData.Rows[i]["cFree9"].ToString().Trim() + "' and ISNULL(cFree10,'') = '" + dtData.Rows[i]["cFree10"].ToString().Trim() + "' " +
                            "else " +
                            "insert InvPositionSum(cWhCode, cPosCode, cInvCode, iQuantity, inum, cBatch, cFree1, cFree2, cFree3" +
                                " , cFree4, cFree5, cFree6, cFree7, cFree8, cFree9, cFree10, iTrackid, cvmivencode, cMassUnit" +
                                ", iMassDate, dMadeDate, dVDate, iExpiratDateCalcu, cExpirationdate, dExpirationdate, cInVouchType) " +
                            "values(  '" + s仓库 + "', " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["货位"].ToString()) + ", '" + s存货编码 + "',  " + ClsBaseDataInfo.ReturnCol(d数量) + ",  " + ClsBaseDataInfo.ReturnCol(d件数) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["批号"].ToString()) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree1"].ToString()) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree2"]) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree3"]) + "" +
                                " , " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree4"]) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree5"]) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree6"]) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree7"]) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree8"]) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree9"]) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree10"]) + ", '" + lIDDetail + "', null, null" +
                                ", null, null, null, 0, null, null, '10')";
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    //7. 更新历史单据号表
                    sSQL = "update VoucherHistory set cNumber='" + iCode + "' Where  CardNumber='0411' and cContent is NULL";
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
        /// 根据序号组装单据号
        /// </summary>
        /// <param name="l"></param>
        /// <param name="iLength"></param>
        /// <param name="s前缀"></param>
        /// <returns></returns>
        private string sGetCode(long l, int iLength, string s前缀)
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
            return s前缀 + sCode;
        }

        public string Chk产品入库条码是否已经使用(string sBarCode)
        {
            string s = "";

            try
            {
                string sSQL = "select count(1) from rdrecords10 where isnull(cDefine22 ,'') = '" + sBarCode + "'";
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
from _BarCodeInventory a inner join Inventory b on a.cInvCode = b.cInvCode 	
	inner join (
					select c.cVenCode,d.cInvCode,sum(d.iQuantity) as iQuantity,SUM(isnull(iReceivedQTY,0)) as iReceivedQTY 
					from PO_Pomain c inner join PO_Podetails d on c.POID = d.POID 
					where c.cPOID = '111111' 
					group by c.cVenCode,d.cInvCode
				) e on e.cInvCode = a.cInvCode
where a.AutoID  = '222222'
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
select a.*, b.cInvName,b.cInvStd,b.bInvBatch,e.生产订单数量 as 数量,e.入库数量,e.报检数量,生产订单号,生产订单行号
from _BarCodeInventory a inner join Inventory b on a.cInvCode = b.cInvCode 	
	inner join (
					select b.InvCode as 母件编码, a.mocode as 生产订单号,b.SortSeq as 生产订单行号,b.Qty as 生产订单数量,b.AuxQty as 生产订单件数,b.QualifiedInQty as 入库数量,b.DeclaredQty  as 报检数量,
					b.Free1,b.Free2,b.Free3,b.Free4,b.Free5,b.Free6,b.Free7,b.Free8,b.Free9,b.Free10 ,b.MoLotCode
                    from mom_order a inner join mom_orderdetail b on a.moid = b.moid
                    where b.Status = 3   
				) e on e.母件编码 = a.cInvCode
				and isnull(a.cBatch,'') = isnull(e.MoLotCode,'') and isnull(a.cFree1,'') = isnull(e.Free1,'')
        and isnull(a.cFree2,'') = isnull(e.Free2,'') and isnull(a.cFree3,'') = isnull(e.Free3,'') and isnull(a.cFree4,'') = isnull(e.Free4,'') and isnull(a.cFree5,'') = isnull(e.Free5,'')
        and isnull(a.cFree6,'') = isnull(e.Free6,'') and isnull(a.cFree7,'') = isnull(e.Free7,'') and isnull(a.cFree8,'') = isnull(e.Free8,'') and isnull(a.cFree9,'') = isnull(e.Free9,'') 
        and isnull(a.cFree10,'') = isnull(e.Free10,'')
where a.AutoID  = '333333'
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
