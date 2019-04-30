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

                    //拒收单单据ID
                    sSQL = "select isnull(max(id),0) as id ,MAX(autoid) as autoid  from PU_ArrivalVouchs";
                    DataTable dt = ClsBaseClass.SqlHelper.ExecuteDataset(ClsBaseClass.ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).Tables[0];
                    long jsID = 0;
                    long jsautoid = 0;

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        jsID = Convert.ToInt64(dt.Rows[0]["id"].ToString());
                        jsautoid = Convert.ToInt64(dt.Rows[0]["id"].ToString());
                    }

                    //3. 获得单据号
                    long iRdCode = 0;
                    sSQL = "select * From VoucherHistory  with (ROWLOCK) Where  CardNumber='24' and cContent='日期' and cSeed='" + d当前服务器时间 .ToString("yyMM")+ "'";
                    dtTemp = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp == null || dtTemp.Rows.Count < 1)
                    {
                        iRdCode = 1;
                    }
                    else
                    {
                        iRdCode = ClsBaseDataInfo.ReturnObjectToLong(dtTemp.Rows[0]["cNumber"]);
                    }

                    //获得拒收单单据号
                    long iRCode = 0;
                    sSQL = "select * From VoucherHistory  with (ROWLOCK) Where  CardNumber='26' and cContent='日期' and cSeed='" + d当前服务器时间 .ToString("yyMM")+ "'";
                    dtTemp = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp == null || dtTemp.Rows.Count < 1)
                    {
                        iRCode = 1;
                    }
                    else
                    {
                        iRCode = ClsBaseDataInfo.ReturnObjectToLong(dtTemp.Rows[0]["cNumber"]);
                    }

                    #region 入库单表头记录表
                    
                    DataTable dt入库单表头记录表 = new DataTable();
                    DataColumn dc = new DataColumn();
                    dc.ColumnName = "单据号";
                    dt入库单表头记录表.Columns.Add(dc);
                    dc = new DataColumn();
                    dc.ColumnName = "单据ID";
                    dt入库单表头记录表.Columns.Add(dc);
                    dc = new DataColumn();
                    dc.ColumnName = "仓库";
                    dt入库单表头记录表.Columns.Add(dc);

                    #endregion

                    string s采购入库单据号 = "";

                    string s制单人 = dtData.Rows[0]["制单人"].ToString().Trim();

                    //5. [更新采购订单表头] 暂时未发现需要更新的内容

                    DataTable dtgroup = Group(dtData, new string[] { "单据号", "仓库", "制单人" }, "入库数量<>0");
                    for (int p = 0; p < dtgroup.Rows.Count; p++)
                    {
                        #region 采购入库表头
                        iRdCode += 1;


                        sSQL = @"
select * 
from PU_ArrivalVouch 
where cCode = '111111' and 1=1
";

                        sSQL = sSQL.Replace("111111", dtgroup.Rows[p]["单据号"].ToString().Trim());
                        DataTable dt到货单表头信息 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        string s仓库 = dtgroup.Rows[p]["仓库"].ToString().Trim();

                        //4. 组装表头，不同仓库生成不同采购入库单

                        bool b已生成采购入库单表头 = false;
                        for (int j = 0; j < dt入库单表头记录表.Rows.Count; j++)
                        {
                            string s仓库Temp = dt入库单表头记录表.Rows[j]["仓库"].ToString().Trim();
                            if (s仓库Temp == s仓库)
                            {
                                b已生成采购入库单表头 = true;
                            }
                        }

                        if (!b已生成采购入库单表头)
                        {
                            lID += 1;
                            string s单据号 = sGetCode(iRdCode, 4, dt到货单表头信息.Rows[0]["cDepCode"].ToString() + d当前服务器时间.ToString("yyMM"));

                            if (s采购入库单据号 == "")
                            {
                                s采购入库单据号 = s采购入库单据号 + s单据号;
                            }
                            else
                            {
                                s采购入库单据号 = s采购入库单据号 + "," + s单据号;
                            }

                            string s采购类型 = dt到货单表头信息.Rows[0]["cPTCode"].ToString().Trim();
                            string s入库类别 = "";
                            sSQL = "select * from PurchaseType where cPTCode = '" + s采购类型 + "'";
                            dtTemp = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dtTemp != null && dtTemp.Rows.Count > 0)
                            {
                                s入库类别 = dtTemp.Rows[0]["cRdCode"].ToString().Trim();
                            }

                            string 采购订单号 = ClsBaseDataInfo.ReturnCol(dt到货单表头信息.Rows[0]["cpocode"]);

                            sSQL = "insert into rdrecord01(id,brdflag,cvouchtype,cbustype,csource,cwhcode,ddate,ccode,crdcode,cdepcode" +
                                            ",cpersoncode,cptcode,cvencode,cordercode,carvcode,cmemo,cmaker,cdefine1,cdefine2,cdefine3" +
                                            ",cdefine4,cdefine5,cdefine6,cdefine7,cdefine8,cdefine9,cdefine10,cdefine11,cdefine12,cdefine13,cdefine15" +
                                            ",cdefine16,darvdate,vt_id,ipurarriveid,itaxrate,iexchrate,cexch_name,idiscounttaxtype,iswfcontrolled,dnmaketime" +
                                            ",dnmodifytime,dnverifytime,bredvouch,iprintcount,cdefine14) " +
                                   "values (N'" + lID + "',N'1',N'01',N'普通采购',N'采购到货单',N'" + s仓库 + "',N'" + d当前服务器时间.ToString("yyyy-MM-dd") + "',N'" + s单据号 + "',N'" + s入库类别 + "',N'" + dt到货单表头信息.Rows[0]["cDepCode"].ToString().Trim() + "'" +
                                            "," + ClsBaseDataInfo.ReturnCol(dt到货单表头信息.Rows[0]["cPersonCode"]) + "," + ClsBaseDataInfo.ReturnCol(s采购类型) + "," + ClsBaseDataInfo.ReturnCol(dt到货单表头信息.Rows[0]["cvencode"]) + "," + 采购订单号 + "," + ClsBaseDataInfo.ReturnCol(dt到货单表头信息.Rows[0]["cCode"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单表头信息.Rows[0]["cmemo"]) + ",N'" + s制单人 + "'," + ClsBaseDataInfo.ReturnCol(dt到货单表头信息.Rows[0]["cdefine1"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单表头信息.Rows[0]["cdefine2"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单表头信息.Rows[0]["cdefine3"]) + "" +
                                            "," + ClsBaseDataInfo.ReturnCol(dt到货单表头信息.Rows[0]["cdefine4"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单表头信息.Rows[0]["cdefine5"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单表头信息.Rows[0]["cdefine6"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单表头信息.Rows[0]["cdefine7"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单表头信息.Rows[0]["cdefine8"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单表头信息.Rows[0]["cdefine9"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单表头信息.Rows[0]["cdefine10"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单表头信息.Rows[0]["cdefine11"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单表头信息.Rows[0]["cdefine12"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单表头信息.Rows[0]["cdefine13"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单表头信息.Rows[0]["cdefine15"]) + "" +
                                            "," + ClsBaseDataInfo.ReturnCol(dt到货单表头信息.Rows[0]["cdefine16"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单表头信息.Rows[0]["dDate"]) + ",31022," + ClsBaseDataInfo.ReturnCol(dt到货单表头信息.Rows[0]["ID"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单表头信息.Rows[0]["iTaxRate"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单表头信息.Rows[0]["iexchrate"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单表头信息.Rows[0]["cexch_name"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单表头信息.Rows[0]["idiscounttaxtype"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单表头信息.Rows[0]["idiscounttaxtype"]) + ", getdate()" +
                                            ", Null , Null ,0,0,'Y')";
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            //出入库跟踪表
                            sSQL = "Update mainbatch Set ccode = N'" + s单据号 + "' Where rdmId = " + lID + " and cvouchtype =N'01'";
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            //未核销列表
                            sSQL = "exec IA_SP_WriteUnAccountVouchForST  " + lID + ",N'01'  ";
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        #endregion

                        #region 采购入库表体
                        for (int i = 0; i < dtData.Rows.Count; i++)
                        {
                            #region 入库单
                            if (dtgroup.Rows[p]["仓库"].ToString().Trim() == dtData.Rows[i]["仓库"].ToString().Trim() && dtgroup.Rows[p]["制单人"].ToString().Trim() == dtData.Rows[i]["制单人"].ToString().Trim() && SqlHelper.ReturnObjectToDecimal(dtData.Rows[i]["入库数量"]) > 0)
                            {

                                sSQL = @"
select * 
from PU_ArrivalVouch a inner join PU_ArrivalVouchs b on a.ID = b.ID
	inner join dbo._BarCodeInventory c on c.cInvCode = b.cInvCode and isnull(c.cBatch,'') = isnull(b.cBatch,'') and isnull(c.cFree1,'') = isnull(b.cFree1,'')
        and isnull(c.cFree2,'') = isnull(b.cFree2,'') and isnull(c.cFree3,'') = isnull(b.cFree3,'') and isnull(c.cFree4,'') = isnull(b.cFree4,'') and isnull(c.cFree5,'') = isnull(b.cFree5,'')
        and isnull(c.cFree6,'') = isnull(b.cFree6,'') and isnull(c.cFree7,'') = isnull(b.cFree7,'') and isnull(c.cFree8,'') = isnull(b.cFree8,'') and isnull(c.cFree9,'') = isnull(b.cFree9,'') and isnull(c.cFree10,'') = isnull(b.cFree10,'')
where cCode = '111111' and 1=1
";

                                sSQL = sSQL.Replace("111111", dtData.Rows[i]["单据号"].ToString().Trim());
                                sSQL = sSQL.Replace("1=1", "1=1 and c.AutoID = " + SqlHelper.ReturnObjectToLong(dtData.Rows[i]["条形码"]).ToString());
                                sSQL = sSQL.Replace("1=1", "1=1 and b.AutoID = " + SqlHelper.ReturnObjectToLong(dtData.Rows[i]["采购到货单子表ID"]).ToString());
                                DataTable dt到货单信息 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];


                                #region 存货自由项
                                sSQL = "select * from Inventory where cInvCode = '" + dtData.Rows[i]["存货编码"].ToString().Trim() + "'";
                                DataTable dt存货信息 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                if (dt存货信息 == null || dt存货信息.Rows.Count < 1)
                                {
                                    sErr = sErr + "获得存货信息失败\n";
                                    continue;
                                }

                                int i是否批次 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bInvBatch"]);
                                if (i是否批次 != 0 && dtData.Rows[i]["批号"].ToString().Trim() == "")
                                {
                                    sErr = sErr + dtData.Rows[i]["存货编码"].ToString().Trim() + "是批次管理物料，必须输入批号\n";
                                    continue;
                                }
                                else if(i是否批次 == 0 && dtData.Rows[i]["批号"].ToString().Trim() != "")
                                {
                                    sErr = sErr + dtData.Rows[i]["存货编码"].ToString().Trim() + "是不是批次管理物料，不可输入批号\n";
                                    continue;
                                }
                                int i是否自由项1 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree1"]);
                                if (i是否自由项1 != 0 && dtData.Rows[i]["cFree1"].ToString().Trim() == "")
                                {
                                    sErr = sErr + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入自由项1\n";
                                    continue;
                                }
                                int i是否自由项2 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree2"]);
                                if (i是否自由项2 != 0 && dtData.Rows[i]["cFree2"].ToString().Trim() == "")
                                {
                                    sErr = sErr + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入自由项2\n";
                                    continue;
                                }
                                int i是否自由项3 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree3"]);
                                if (i是否自由项3 != 0 && dtData.Rows[i]["cFree3"].ToString().Trim() == "")
                                {
                                    sErr = sErr + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入自由项3\n";
                                    continue;
                                }
                                int i是否自由项4 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree4"]);
                                if (i是否自由项4 != 0 && dtData.Rows[i]["cFree4"].ToString().Trim() == "")
                                {
                                    sErr = sErr + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入自由项4\n";
                                    continue;
                                }
                                int i是否自由项5 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree5"]);
                                if (i是否自由项5 != 0 && dtData.Rows[i]["cFree5"].ToString().Trim() == "")
                                {
                                    sErr = sErr + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入自由项5\n";
                                    continue;
                                }
                                int i是否自由项6 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree6"]);
                                if (i是否自由项6 != 0 && dtData.Rows[i]["cFree6"].ToString().Trim() == "")
                                {
                                    sErr = sErr + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入自由项6\n";
                                    continue;
                                }
                                int i是否自由项7 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree7"]);
                                if (i是否自由项7 != 0 && dtData.Rows[i]["cFree7"].ToString().Trim() == "")
                                {
                                    sErr = sErr + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入自由项7\n";
                                    continue;
                                }
                                int i是否自由项8 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree8"]);
                                if (i是否自由项8 != 0 && dtData.Rows[i]["cFree8"].ToString().Trim() == "")
                                {
                                    sErr = sErr + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入自由项8\n";
                                    continue;
                                }
                                int i是否自由项9 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree9"]);
                                if (i是否自由项9 != 0 && dtData.Rows[i]["cFree9"].ToString().Trim() == "")
                                {
                                    sErr = sErr + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入自由项9\n";
                                    continue;
                                }
                                int i是否自由项10 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree10"]);
                                if (i是否自由项10 != 0 && dtData.Rows[i]["cFree10"].ToString().Trim() == "")
                                {
                                    sErr = sErr + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入自由项10\n";
                                    continue;
                                }
                                #endregion

                                string cFree1 = dtData.Rows[i]["cFree1"].ToString().Trim();
                                string cFree2 = dtData.Rows[i]["cFree2"].ToString().Trim();
                                string cFree3 = dtData.Rows[i]["cFree3"].ToString().Trim();
                                string cFree4 = dtData.Rows[i]["cFree4"].ToString().Trim();
                                string cFree5 = dtData.Rows[i]["cFree5"].ToString().Trim();
                                string cFree6 = dtData.Rows[i]["cFree6"].ToString().Trim();
                                string cFree7 = dtData.Rows[i]["cFree7"].ToString().Trim();
                                string cFree8 = dtData.Rows[i]["cFree8"].ToString().Trim();
                                string cFree9 = dtData.Rows[i]["cFree9"].ToString().Trim();
                                string cFree10 = dtData.Rows[i]["cFree10"].ToString().Trim();
                                string cBatch = dtData.Rows[i]["批号"].ToString().Trim();

                                string 采购订单号 = ClsBaseDataInfo.ReturnCol(dt到货单表头信息.Rows[0]["cpocode"]);
                                //组装表体
                                lIDDetail += 1;
                                string s存货编码 = dtData.Rows[i]["存货编码"].ToString().Trim();
                                decimal d数量 = ClsBaseDataInfo.ReturnObjectToDecimal(dtData.Rows[i]["入库数量"], 6);
                                

                                decimal d到货单数量 = ClsBaseDataInfo.ReturnObjectToDecimal(dt到货单信息.Rows[0]["iQuantity"], 6);
                                decimal d到货单件数 = ClsBaseDataInfo.ReturnObjectToDecimal(dt到货单信息.Rows[0]["iNum"], 6);

                                decimal d累计入库数量 = ClsBaseDataInfo.ReturnObjectToDecimal(dt到货单信息.Rows[0]["fValidInQuan"], 6);
                                decimal d累计入库件数 = ClsBaseDataInfo.ReturnObjectToDecimal(dt到货单信息.Rows[0]["fValidInNum"], 6);

                                decimal d件数 = 0;
                                if (d到货单件数 != 0)
                                {
                                    d件数 = ClsBaseDataInfo.ReturnObjectToDecimal(d到货单件数 * d数量 / d到货单数量, 6);
                                }

                                decimal d入库超额上限 = ClsBaseDataInfo.ReturnObjectToDecimal(dt存货信息.Rows[0]["fInExcess"], 6);
                                if (d到货单数量 * (1 + d入库超额上限 / 100) < d累计入库数量 + d数量 || d到货单件数 * (1 + d入库超额上限 / 100) < d累计入库件数 + d件数)
                                {
                                    sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + ":" + dtData.Rows[i]["存货编码"].ToString().Trim() + "累计入库数量超订单\n";
                                    continue;
                                }

                                decimal d含税单价 = ClsBaseDataInfo.ReturnObjectToDecimal(dt到货单信息.Rows[0]["iOriTaxCost"], 6);
                                decimal d含税金额 = ClsBaseDataInfo.ReturnObjectToDecimal(d含税单价 * d数量, 2);
                                decimal d税率 = ClsBaseDataInfo.ReturnObjectToDecimal(dt到货单信息.Rows[0]["iTaxRate"], 6);
                                decimal d无税金额 = ClsBaseDataInfo.ReturnObjectToDecimal(d含税金额 / (1 + d税率 / 100), 2);
                                decimal d税额 = d含税金额 - d无税金额;
                                decimal d无税单价 = ClsBaseDataInfo.ReturnObjectToDecimal(d无税金额 / d数量, 3);

                                sSQL = "Insert Into rdrecords01(autoid,id,cinvcode,inum,iquantity,iunitcost,iprice,iaprice,ipunitcost,ipprice" +
                                            ",cbatch,cvouchcode,cinvouchcode,cinvouchtype,isoutquantity,isoutnum,cfree1,cfree2,dsdate,itax" +
                                            ",isquantity,isnum,imoney,ifnum,ifquantity,dvdate,cposition,cdefine22,cdefine23,cdefine24" +
                                            ",cdefine25,cdefine26,cdefine27,citem_class,citemcode,iposid,facost,cname,citemcname,cfree3" +
                                            ",cfree4,cfree5,cfree6,cfree7,cfree8,cfree9,cfree10,cbarcode,inquantity,innum" +
                                            ",cassunit,dmadedate,imassdate,cdefine28,cdefine29,cdefine30,cdefine31,cdefine32,cdefine33,cdefine34" +
                                            ",cdefine35,cdefine36,cdefine37,icheckids,cbvencode,cgspstate,iarrsid,ccheckcode,icheckidbaks,crejectcode" +

                                            ",irejectids,ccheckpersoncode,dcheckdate,ioritaxcost,ioricost,iorimoney,ioritaxprice,iorisum,itaxrate,itaxprice" +
                                            ",isum,btaxcost,cpoid,cmassunit,imaterialfee,iprocesscost,iprocessfee,dmsdate,ismaterialfee,isprocessfee" +
                                            ",iomodid,strcontractid,strcode,cbaccounter,dbkeepdate,bcosting,isumbillquantity,bvmiused,ivmisettlequantity,ivmisettlenum" +
                                            ",cvmivencode,iinvsncount,impcost,iimosid,iimbsid,cbarvcode,dbarvdate,iinvexchrate,corufts,iexpiratdatecalcu" +
                                            ",cexpirationdate,dexpirationdate,cciqbookcode,ibondedsumqty,iordertype,iorderdid,iordercode,iorderseq,isodid,isotype" +
                                            ",csocode,isoseq,cbatchproperty1,cbatchproperty2,cbatchproperty3,cbatchproperty4,cbatchproperty5,cbatchproperty6,cbatchproperty7,cbatchproperty8" +
                                            ",cbatchproperty9,cbatchproperty10,cbmemo,ifaqty,istax,irowno,strowguid,idebitids) " +
                                    "Values (" + lIDDetail + "," + lID + ",N'" + s存货编码 + "'," + ClsBaseDataInfo.ReturnCol(d件数) + "," + ClsBaseDataInfo.ReturnCol(d数量) + "," + ClsBaseDataInfo.ReturnCol(d无税单价) + "," + ClsBaseDataInfo.ReturnCol(d无税金额) + "," + ClsBaseDataInfo.ReturnCol(d无税金额) + ",Null,Null" +
                                            "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["批号"].ToString()) + ",Null,Null,Null,Null,Null," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree1"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree2"]) + ",Null," + ClsBaseDataInfo.ReturnCol(d税额) + "" +
                                            ",0,0,0,Null,Null,Null," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["货位"].ToString()) + " ," + ClsBaseDataInfo.ReturnCol(dt到货单信息.Rows[0]["cdefine22"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单信息.Rows[0]["cdefine23"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单信息.Rows[0]["cdefine24"]) + "" +
                                            "," + ClsBaseDataInfo.ReturnCol(dt到货单信息.Rows[0]["cdefine25"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单信息.Rows[0]["cdefine26"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单信息.Rows[0]["cdefine27"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单信息.Rows[0]["citem_class"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单信息.Rows[0]["citemcode"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单信息.Rows[0]["iposid"]) + "," + ClsBaseDataInfo.ReturnCol(d无税单价) + ",Null,Null," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree3"]) + "" +
                                            "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree4"]) + ",NULL,NULL,NULL,NULL,NULL,NULL,Null," + ClsBaseDataInfo.ReturnCol(d数量) + "," + ClsBaseDataInfo.ReturnCol(d件数) + "" +
                                            ",Null,Null,Null," + ClsBaseDataInfo.ReturnCol(dt到货单信息.Rows[0]["cdefine28"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单信息.Rows[0]["cdefine29"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单信息.Rows[0]["cdefine30"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单信息.Rows[0]["cdefine31"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单信息.Rows[0]["cdefine32"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单信息.Rows[0]["cdefine33"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单信息.Rows[0]["cdefine34"]) + "" +
                                            "," + ClsBaseDataInfo.ReturnCol(dt到货单信息.Rows[0]["cdefine35"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单信息.Rows[0]["cdefine36"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单信息.Rows[0]["cdefine37"]) + ",Null,Null,Null," + ClsBaseDataInfo.ReturnCol(dt到货单信息.Rows[0]["Autoid"]) + ",Null,Null,Null" +

                                            ",Null,Null,Null," + ClsBaseDataInfo.ReturnCol(d含税单价) + "," + ClsBaseDataInfo.ReturnCol(d无税单价) + "," + ClsBaseDataInfo.ReturnCol(d无税金额) + "," + ClsBaseDataInfo.ReturnCol(d税额) + "," + ClsBaseDataInfo.ReturnCol(d含税金额) + "," + ClsBaseDataInfo.ReturnCol(d税率) + "," + ClsBaseDataInfo.ReturnCol(d税额) + "" +
                                            "," + ClsBaseDataInfo.ReturnCol(d含税金额) + ",0," + 采购订单号 + ",Null,Null,Null,Null,Null,Null,Null" +
                                            ",Null,Null," + 采购订单号 + ",Null,Null,1,Null,Null,Null,Null" +
                                            ",Null,Null,Null,Null,Null," + ClsBaseDataInfo.ReturnCol(dt到货单信息.Rows[0]["ccode"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单信息.Rows[0]["dDate"]) + ",Null,null,0" +
                                            ",Null,Null,Null,Null,Null,Null,Null,Null,Null,0" +
                                            ",Null,Null,Null,Null,Null,Null,Null,NULL,Null,Null" +
                                            ",Null,Null,Null,Null,Null," + ClsBaseDataInfo.ReturnCol(dt到货单信息.Rows[0]["irowno"].ToString()) + ",Null,Null)";
                                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                //更新现存量

                                sSQL = "select * from SCM_Item where cInvCode = '" + s存货编码 + "' and ISNULL(cFree1,'') = '" + dtData.Rows[i]["cFree1"].ToString().Trim() + "' and ISNULL(cFree2,'') = '" + dtData.Rows[i]["cFree2"].ToString().Trim() + "' and ISNULL(cFree3,'') = '" + dtData.Rows[i]["cFree3"].ToString().Trim() + "' and ISNULL(cFree4,'') = '" + dtData.Rows[i]["cFree4"].ToString().Trim() + "' and ISNULL(cFree5,'') = '" + dtData.Rows[i]["cFree5"].ToString().Trim() + "' and ISNULL(cFree6,'') = '" + dtData.Rows[i]["cFree6"].ToString().Trim() + "' and ISNULL(cFree7,'') = '" + dtData.Rows[i]["cFree7"].ToString().Trim() + "' and ISNULL(cFree8,'') = '" + dtData.Rows[i]["cFree8"].ToString().Trim() + "' and ISNULL(cFree9,'') = '" + dtData.Rows[i]["cFree9"].ToString().Trim() + "' and ISNULL(cFree10,'') = '" + dtData.Rows[i]["cFree10"].ToString().Trim() + "' ";
                                DataTable dtTemp2 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                long lItemID = 0;
                                if (dtTemp2 == null || dtTemp2.Rows.Count == 0)
                                {
                                    try
                                    {
                                        
                                        
                                        sSQL = "insert into SCM_Item(cInvCode,cFree1,cFree2,cFree3,cFree4,cFree5,cFree6,cFree7,cFree8,cFree9,cFree10,PartId) " +
                                                "values('" + s存货编码 + "','" + cFree1 + "','" + cFree2 + "','" + cFree3 + "','" + cFree4 + "','" + cFree5+ "','" + cFree6 + "','" + cFree7 + "','" + cFree8 + "','" + cFree9 + "','" + cFree10 + "',0)";
                                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                                    }
                                    catch
                                    {
                                        throw new Exception("现存量更新有误" + sSQL);
                                    }
                                        sSQL = "select * from SCM_Item where cInvCode = '" + s存货编码 + "' and ISNULL(cFree1,'') = '" + dtData.Rows[i]["cFree1"].ToString().Trim() + "' and ISNULL(cFree2,'') = '" + dtData.Rows[i]["cFree2"].ToString().Trim() + "' and ISNULL(cFree3,'') = '" + dtData.Rows[i]["cFree3"].ToString().Trim() + "' and ISNULL(cFree4,'') = '" + dtData.Rows[i]["cFree4"].ToString().Trim() + "' and ISNULL(cFree5,'') = '" + dtData.Rows[i]["cFree5"].ToString().Trim() + "' and ISNULL(cFree6,'') = '" + dtData.Rows[i]["cFree6"].ToString().Trim() + "' and ISNULL(cFree7,'') = '" + dtData.Rows[i]["cFree7"].ToString().Trim() + "' and ISNULL(cFree8,'') = '" + dtData.Rows[i]["cFree8"].ToString().Trim() + "' and ISNULL(cFree9,'') = '" + dtData.Rows[i]["cFree9"].ToString().Trim() + "' and ISNULL(cFree10,'') = '" + dtData.Rows[i]["cFree10"].ToString().Trim() + "' ";
                                        dtTemp2 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                        lItemID = Convert.ToInt64(dtTemp2.Rows[0]["id"]);
                                    
                                }
                                else
                                {
                                    lItemID = Convert.ToInt64(dtTemp2.Rows[0]["id"]);
                                }
                                
                                sSQL = "declare @itmeid int " +
                                        "select @itmeid = MAX(ItemId) + 1 from CurrentStock " +
                                       "if exists(select * from CurrentStock where cinvcode = '" + s存货编码 + "' and isnull(cBatch,'') = isnull(" + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["批号"].ToString()) + ",'')  and cWhCode = '" + s仓库 + "' and ISNULL(cFree1,'') = '" + dtData.Rows[i]["cFree1"].ToString().Trim() + "' and ISNULL(cFree2,'') = '" + dtData.Rows[i]["cFree2"].ToString().Trim() + "' and ISNULL(cFree3,'') = '" + dtData.Rows[i]["cFree3"].ToString().Trim() + "' and ISNULL(cFree4,'') = '" + dtData.Rows[i]["cFree4"].ToString().Trim() + "' and ISNULL(cFree5,'') = '" + dtData.Rows[i]["cFree5"].ToString().Trim() + "' and ISNULL(cFree6,'') = '" + dtData.Rows[i]["cFree6"].ToString().Trim() + "' and ISNULL(cFree7,'') = '" + dtData.Rows[i]["cFree7"].ToString().Trim() + "' and ISNULL(cFree8,'') = '" + dtData.Rows[i]["cFree8"].ToString().Trim() + "' and ISNULL(cFree9,'') = '" + dtData.Rows[i]["cFree9"].ToString().Trim() + "' and ISNULL(cFree10,'') = '" + dtData.Rows[i]["cFree10"].ToString().Trim() + "') " +
                                       "    update CurrentStock set iQuantity = isnull(iQuantity,0) + " + ClsBaseDataInfo.ReturnCol(d数量) + ",iNum = isnull(iNum,0) + " + ClsBaseDataInfo.ReturnCol(d件数) + " " +
                                       "    where cinvcode = '" + s存货编码 + "' and isnull(cBatch,'') = isnull(" + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["批号"].ToString()) + ",'') and cWhCode = '" + s仓库 + "' and ISNULL(cFree1,'') = '" + dtData.Rows[i]["cFree1"].ToString().Trim() + "' and ISNULL(cFree2,'') = '" + dtData.Rows[i]["cFree2"].ToString().Trim() + "' and ISNULL(cFree3,'') = '" + dtData.Rows[i]["cFree3"].ToString().Trim() + "' and ISNULL(cFree4,'') = '" + dtData.Rows[i]["cFree4"].ToString().Trim() + "' and ISNULL(cFree5,'') = '" + dtData.Rows[i]["cFree5"].ToString().Trim() + "' and ISNULL(cFree6,'') = '" + dtData.Rows[i]["cFree6"].ToString().Trim() + "' and ISNULL(cFree7,'') = '" + dtData.Rows[i]["cFree7"].ToString().Trim() + "' and ISNULL(cFree8,'') = '" + dtData.Rows[i]["cFree8"].ToString().Trim() + "' and ISNULL(cFree9,'') = '" + dtData.Rows[i]["cFree9"].ToString().Trim() + "' and ISNULL(cFree10,'') = '" + dtData.Rows[i]["cFree10"].ToString().Trim() + "' " +
                                       "else " +
                                       "    insert into CurrentStock(cWhCode,cInvCode,cBatch,iSoType,iQuantity,iNum,ItemId,cFree1,cFree2,cFree3,cFree4,cFree5,cFree6,cFree7,cFree8,cFree9,cFree10)  " +
                                       "    values('" + s仓库 + "', '" + s存货编码 + "','" + cBatch + "',0," + ClsBaseDataInfo.ReturnCol(d数量) + "," + ClsBaseDataInfo.ReturnCol(d件数) + "," + lItemID + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree1"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree2"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree3"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree4"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree5"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree6"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree7"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree8"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree9"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree10"]) + ")";
                                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                                sSQL = "update PU_ArrivalVouchs set fValidInQuan  = isnull(fValidInQuan ,0) + " + ClsBaseDataInfo.ReturnCol(d数量) + " ,fValidNum  = isnull(fValidNum ,0) + " + ClsBaseDataInfo.ReturnCol(d件数) + " " +
                                        "where autoid = " + ClsBaseDataInfo.ReturnCol(dt到货单信息.Rows[0]["AutoID"].ToString());
                                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                                sSQL = "update po_podetails set iReceivedQTY  = isnull(iReceivedQTY ,0) + " + ClsBaseDataInfo.ReturnCol(d数量) + " ,iReceivedNum   = isnull(iReceivedNum,0) + " + ClsBaseDataInfo.ReturnCol(d件数) + " " +
                                        "where ID = " + ClsBaseDataInfo.ReturnCol(dt到货单信息.Rows[0]["iPOsID"].ToString());
                                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                //货位登记
                                sSQL = "insert into InvPosition( RdsID, RdID, cWhCode, cPosCode, cInvCode, cBatch, cFree1, cFree2, dVDate, iQuantity" +
                                            ", iNum, cMemo, cHandler, dDate, bRdFlag, cSource, cFree3, cFree4, cFree5, cFree6" +
                                            ", cFree7, cFree8, cFree9, cFree10, cAssUnit, cBVencode, iTrackId,  dMadeDate, iMassDate" +
                                            ", cMassUnit, cvmivencode, iExpiratDateCalcu, cExpirationdate, dExpirationdate, cvouchtype, cInVouchType, cVerifier, dVeriDate, dVouchDate) " +
                                        "values(" + lIDDetail + "," + lID + ",'" + s仓库 + "'," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["货位"].ToString()) + ",'" + s存货编码 + "'," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["批号"].ToString()) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree1"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree2"]) + ",null," + ClsBaseDataInfo.ReturnCol(d数量) + " " +
                                        "," + ClsBaseDataInfo.ReturnCol(d件数) + ",null,'" + s制单人 + "','" + d当前服务器时间.ToString("yyyy-MM-dd") + "',1,null," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree3"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree4"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree5"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree6"]) + "" +
                                        "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree7"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree8"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree9"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree10"]) + "," + ClsBaseDataInfo.ReturnCol(dt存货信息.Rows[0]["cAssComUnitCode"].ToString()) + ",null,0,null,null" +
                                        ",null,null,0,null,null,'01','',null,null,'" + d当前服务器时间.ToString("yyyy-MM-dd") + "')";
                                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                sSQL = "if exists( select * from InvPositionSum where cInvCode = '" + s存货编码 + "' and cWhCode = '" + s仓库 + "' and cPosCode = " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["货位"].ToString()) + " and ISNULL(cBatch,'') = '" + dtData.Rows[i]["批号"].ToString().Trim() + "' " +
                                    "and isnull(cFree1,'') = '" + dtData.Rows[i]["cFree1"].ToString().Trim() + "'  and ISNULL(cFree2,'') = '" + dtData.Rows[i]["cFree2"].ToString().Trim() + "' and ISNULL(cFree3,'') = '" + dtData.Rows[i]["cFree3"].ToString().Trim() + "' and ISNULL(cFree4,'') = '" + dtData.Rows[i]["cFree4"].ToString().Trim() + "' and ISNULL(cFree5,'') = '" + dtData.Rows[i]["cFree5"].ToString().Trim() + "' and ISNULL(cFree6,'') = '" + dtData.Rows[i]["cFree6"].ToString().Trim() + "' and ISNULL(cFree7,'') = '" + dtData.Rows[i]["cFree7"].ToString().Trim() + "' and ISNULL(cFree8,'') = '" + dtData.Rows[i]["cFree8"].ToString().Trim() + "' and ISNULL(cFree9,'') = '" + dtData.Rows[i]["cFree9"].ToString().Trim() + "' and ISNULL(cFree10,'') = '" + dtData.Rows[i]["cFree10"].ToString().Trim() + "') " +
                                    "   update InvPositionSum set iQuantity = iQuantity +  " + ClsBaseDataInfo.ReturnCol(d数量) + ",iNum = iNum +  " + ClsBaseDataInfo.ReturnCol(d件数) + " where cInvCode = '" + s存货编码 + "' and cWhCode = '" + s仓库 + "' and cPosCode = " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["货位"].ToString()) + " and ISNULL(cBatch,'') = '" + dtData.Rows[i]["批号"].ToString().Trim() + "' " +
                                    " and isnull(cFree1,'') = '" + dtData.Rows[i]["cFree1"].ToString().Trim() + "'  and ISNULL(cFree2,'') = '" + dtData.Rows[i]["cFree2"].ToString().Trim() + "' and ISNULL(cFree3,'') = '" + dtData.Rows[i]["cFree3"].ToString().Trim() + "' and ISNULL(cFree4,'') = '" + dtData.Rows[i]["cFree4"].ToString().Trim() + "' and ISNULL(cFree5,'') = '" + dtData.Rows[i]["cFree5"].ToString().Trim() + "' and ISNULL(cFree6,'') = '" + dtData.Rows[i]["cFree6"].ToString().Trim() + "' and ISNULL(cFree7,'') = '" + dtData.Rows[i]["cFree7"].ToString().Trim() + "' and ISNULL(cFree8,'') = '" + dtData.Rows[i]["cFree8"].ToString().Trim() + "' and ISNULL(cFree9,'') = '" + dtData.Rows[i]["cFree9"].ToString().Trim() + "' and ISNULL(cFree10,'') = '" + dtData.Rows[i]["cFree10"].ToString().Trim() + "' " +
                                    "else " +
                                    "insert InvPositionSum(cWhCode, cPosCode, cInvCode, iQuantity, inum, cBatch, cFree1, cFree2, cFree3" +
                                        " , cFree4, cFree5, cFree6, cFree7, cFree8, cFree9, cFree10, iTrackid, cvmivencode, cMassUnit" +
                                        ", iMassDate, dMadeDate, dVDate, iExpiratDateCalcu, cExpirationdate, dExpirationdate, cInVouchType) " +
                                    "values(  '" + s仓库 + "', " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["货位"].ToString()) + ", '" + s存货编码 + "',  " + ClsBaseDataInfo.ReturnCol(d数量) + ",  " + ClsBaseDataInfo.ReturnCol(d件数) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["批号"].ToString()) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree1"].ToString()) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree2"]) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree3"]) + "" +
                                        " , " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree4"]) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree5"]) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree6"]) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree7"]) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree8"]) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree9"]) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree10"]) + ", '0', null, null" +
                                        ", null, null, null, 0, null, null, '')";
                                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                sSQL = "exec IA_SP_WriteUnAccountVouchForST " + lIDDetail + ",'01'";
                                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                            #endregion
                        }
                        #endregion
                    }
                    DataTable dtgroup2 = Group(dtData, new string[] { "单据号", "仓库", "制单人" }, "isnull(拒收数量,0)<>0");
                    for (int p = 0; p < dtgroup2.Rows.Count; p++)
                    {
                        #region 拒收单表头
                        iRCode += 1;
                        sSQL = @"
select * 
from PU_ArrivalVouch 
where cCode = '111111' and 1=1
";

                        sSQL = sSQL.Replace("111111", dtgroup2.Rows[p]["单据号"].ToString().Trim());
                        DataTable dt到货单表头信息 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        jsID += 1;
                        string s单据号 = sGetCode(iRCode, 4, "CGDH" + dt到货单表头信息.Rows[0]["cDepCode"].ToString() + d当前服务器时间.ToString("yyMM"));

                        if (s采购入库单据号 == "")
                        {
                            s采购入库单据号 = s采购入库单据号 + s单据号;
                        }
                        else
                        {
                            s采购入库单据号 = s采购入库单据号 + "," + s单据号;
                        }

                        string s采购类型 = dt到货单表头信息.Rows[0]["cPTCode"].ToString().Trim();

                        sSQL = @"Insert Into PU_ArrivalVouch(ivtid,id,ccode,cptcode,ddate,cvencode,
cdepcode,cpaycode,csccode,cexch_name,iexchrate,itaxrate,cmemo,cbustype,
cmaker,bnegative,cdefine1,cdefine2,cdefine3,cdefine4,cdefine5,cdefine6,cdefine7,cdefine8,cdefine9,cdefine10,
cdefine11,cdefine12,cdefine13,cdefine14,cdefine15,cdefine16,ccloser,idiscounttaxtype,ibilltype,cvouchtype,
cgeneralordercode,ctmcode,cincotermcode,ctransordercode,dportdate,csportcode,caportcode,csvencode,carrivalplace,dclosedate,idec,bcal,guid,iverifystate,cauditdate,cverifier,iverifystateex,ireturncount,
iswfcontrolled,cvenpuomprotocol,cchanger,iflowid,ccleanver,cpocode,csysbarcode,ccurrentauditor) 
Values (8169,'" + jsID + "',N'" + s单据号 + "',N" + ClsBaseDataInfo.ReturnCol(s采购类型) + ",'" + d当前服务器时间.ToString("yyyy-MM-dd") + "',N" + ClsBaseDataInfo.ReturnCol(dt到货单表头信息.Rows[0]["cvencode"]) + "," +
"N'" + dt到货单表头信息.Rows[0]["cDepCode"].ToString().Trim() + "',NULL,N'01',N'人民币',1,17," + ClsBaseDataInfo.ReturnCol(dt到货单表头信息.Rows[0]["cmemo"]) + ",N'普通采购'," +
"N'" + s制单人 + "',1,N" + ClsBaseDataInfo.ReturnCol(dt到货单表头信息.Rows[0]["cCode"]) + ",NULL,N'" + dt到货单表头信息.Rows[0]["cdefine3"] + "',NULL,NULL,NULL,NULL,NULL,NULL,N'" + dt到货单表头信息.Rows[0]["cdefine10"] + "'," +
"NULL,'" + dt到货单表头信息.Rows[0]["cdefine12"] + "',NULL,NULL,NULL,NULL,NULL,0,2,NULL," +
"NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,NULL,NULL,0,NULL,NULL,NULL,NULL)";
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        #endregion

                        for (int i = 0; i < dtData.Rows.Count; i++)
                        {
                            #region 拒收单表体
                            if (dtgroup2.Rows[p]["仓库"].ToString().Trim() == dtData.Rows[i]["仓库"].ToString().Trim() && dtgroup2.Rows[p]["制单人"].ToString().Trim() == dtData.Rows[i]["制单人"].ToString().Trim() && SqlHelper.ReturnObjectToDecimal(dtData.Rows[i]["拒收数量"]) > 0)
                            {

                                sSQL = @"
select * 
from PU_ArrivalVouch a inner join PU_ArrivalVouchs b on a.ID = b.ID
	inner join dbo._BarCodeInventory c on c.cInvCode = b.cInvCode and isnull(c.cBatch,'') = isnull(b.cBatch,'') and isnull(c.cFree1,'') = isnull(b.cFree1,'')
        and isnull(c.cFree2,'') = isnull(b.cFree2,'') and isnull(c.cFree3,'') = isnull(b.cFree3,'') and isnull(c.cFree4,'') = isnull(b.cFree4,'') and isnull(c.cFree5,'') = isnull(b.cFree5,'')
        and isnull(c.cFree6,'') = isnull(b.cFree6,'') and isnull(c.cFree7,'') = isnull(b.cFree7,'') and isnull(c.cFree8,'') = isnull(b.cFree8,'') and isnull(c.cFree9,'') = isnull(b.cFree9,'') and isnull(c.cFree10,'') = isnull(b.cFree10,'')
where cCode = '111111' and 1=1
";

                                sSQL = sSQL.Replace("111111", dtgroup2.Rows[p]["单据号"].ToString().Trim());
                                sSQL = sSQL.Replace("1=1", "1=1 and c.AutoID = " + SqlHelper.ReturnObjectToLong(dtData.Rows[i]["条形码"]).ToString());
                                DataTable dt到货单信息 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                                #region 存货自由项
                                sSQL = "select * from Inventory where cInvCode = '" + dtData.Rows[i]["存货编码"].ToString().Trim() + "'";
                                DataTable dt存货信息 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                if (dt存货信息 == null || dt存货信息.Rows.Count < 1)
                                {
                                    sErr = sErr + "获得存货信息失败\n";
                                    continue;
                                }

                                int i是否批次 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bInvBatch"]);
                                if (i是否批次 != 0 && dtData.Rows[i]["批号"].ToString().Trim() == "")
                                {
                                    sErr = sErr + dtData.Rows[i]["存货编码"].ToString().Trim() + "是批次管理物料，必须输入批号\n";
                                    continue;
                                }
                                int i是否自由项1 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree1"]);
                                if (i是否自由项1 != 0 && dtData.Rows[i]["cFree1"].ToString().Trim() == "")
                                {
                                    sErr = sErr + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入自由项1\n";
                                    continue;
                                }
                                int i是否自由项2 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree2"]);
                                if (i是否自由项2 != 0 && dtData.Rows[i]["cFree2"].ToString().Trim() == "")
                                {
                                    sErr = sErr + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入自由项2\n";
                                    continue;
                                }
                                int i是否自由项3 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree3"]);
                                if (i是否自由项3 != 0 && dtData.Rows[i]["cFree3"].ToString().Trim() == "")
                                {
                                    sErr = sErr + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入自由项3\n";
                                    continue;
                                }
                                int i是否自由项4 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree4"]);
                                if (i是否自由项4 != 0 && dtData.Rows[i]["cFree4"].ToString().Trim() == "")
                                {
                                    sErr = sErr + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入自由项4\n";
                                    continue;
                                }
                                int i是否自由项5 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree5"]);
                                if (i是否自由项5 != 0 && dtData.Rows[i]["cFree5"].ToString().Trim() == "")
                                {
                                    sErr = sErr + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入自由项5\n";
                                    continue;
                                }
                                int i是否自由项6 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree6"]);
                                if (i是否自由项6 != 0 && dtData.Rows[i]["cFree6"].ToString().Trim() == "")
                                {
                                    sErr = sErr + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入自由项6\n";
                                    continue;
                                }
                                int i是否自由项7 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree7"]);
                                if (i是否自由项7 != 0 && dtData.Rows[i]["cFree7"].ToString().Trim() == "")
                                {
                                    sErr = sErr + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入自由项7\n";
                                    continue;
                                }
                                int i是否自由项8 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree8"]);
                                if (i是否自由项8 != 0 && dtData.Rows[i]["cFree8"].ToString().Trim() == "")
                                {
                                    sErr = sErr + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入自由项8\n";
                                    continue;
                                }
                                int i是否自由项9 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree9"]);
                                if (i是否自由项9 != 0 && dtData.Rows[i]["cFree9"].ToString().Trim() == "")
                                {
                                    sErr = sErr + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入自由项9\n";
                                    continue;
                                }
                                int i是否自由项10 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree10"]);
                                if (i是否自由项10 != 0 && dtData.Rows[i]["cFree10"].ToString().Trim() == "")
                                {
                                    sErr = sErr + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入自由项10\n";
                                    continue;
                                }
                                #endregion

                                //组装表体
                                jsautoid += 1;
                                string s存货编码 = dtData.Rows[i]["存货编码"].ToString().Trim();
                                decimal d数量 = ClsBaseDataInfo.ReturnObjectToDecimal(dtData.Rows[i]["入库数量"], 6);
                                decimal d税率 = ClsBaseDataInfo.ReturnObjectToDecimal(dt到货单信息.Rows[0]["iTaxRate"], 6);

                                decimal d到货单数量 = ClsBaseDataInfo.ReturnObjectToDecimal(dt到货单信息.Rows[0]["iQuantity"], 6);
                                decimal d到货单件数 = ClsBaseDataInfo.ReturnObjectToDecimal(dt到货单信息.Rows[0]["iNum"], 6);

                                decimal d累计入库数量 = ClsBaseDataInfo.ReturnObjectToDecimal(dt到货单信息.Rows[0]["fValidInQuan"], 6);
                                decimal d累计入库件数 = ClsBaseDataInfo.ReturnObjectToDecimal(dt到货单信息.Rows[0]["fValidInNum"], 6);

                                decimal d拒收数量 = -ClsBaseDataInfo.ReturnObjectToDecimal(dtData.Rows[i]["拒收数量"], 6);

                                decimal d拒收件数 = 0;
                                if (d拒收数量 != 0)
                                {
                                    d拒收件数 = -ClsBaseDataInfo.ReturnObjectToDecimal(d到货单件数 * d拒收数量 / d拒收数量, 6);
                                }

                                decimal d含税单价 = ClsBaseDataInfo.ReturnObjectToDecimal(dt到货单信息.Rows[0]["iTaxPrice"], 6);
                                decimal d含税金额 = ClsBaseDataInfo.ReturnObjectToDecimal(d含税单价 * d拒收数量, 2);
                                decimal d无税金额 = ClsBaseDataInfo.ReturnObjectToDecimal(d含税金额 / (1 + d税率 / 100), 2);
                                decimal d税额 = d含税金额 - d无税金额;
                                decimal d无税单价 = ClsBaseDataInfo.ReturnObjectToDecimal(d无税金额 / d拒收数量, 3);

                                sSQL = @"Insert Into PU_ArrivalVouchs(autoid,id,cwhcode,cinvcode,inum,iquantity,ioricost,ioritaxcost,
iorimoney,ioritaxprice,iorisum,icost,
imoney,itaxprice,isum,
cfree1,cfree2,cfree3,cfree4,cfree5,cfree6,cfree7,cfree8,cfree9,cfree10,itaxrate,
cdefine22,cdefine23,cdefine24,cdefine25,cdefine26,cdefine27,cdefine28,cdefine29,cdefine30,
cdefine31,cdefine32,cdefine33,cdefine34,cdefine35,cdefine36,cdefine37,
citem_class,citemcode,iposid,
citemname,cunitid,fkpquantity,frealquantity,fvalidquantity,finvalidquantity,ccloser,
icorid,bgsp,cbatch,dvdate,dpdate,frefusequantity,cgspstate,fvalidnum,finvalidnum,frealnum,btaxcost,binspect,frefusenum,
ippartid,ipquantity,iptoseq,
sodid,sotype,contractrowguid,imassdate,cmassunit,bexigency,cbcloser,fdtquantity,finvalidinnum,
fdegradequantity,fdegradenum,fdegradeinquantity,fdegradeinnum,finspectquantity,finspectnum,iinvmpcost,guids,iinvexchrate,objectid_source,
autoid_source,ufts_source,irowno_source,
csocode,isorowno,iorderid,cordercode,iorderrowno,dlineclosedate,contractcode,contractrowno,rejectsource,
iciqbookid,cciqbookcode,cciqcode,fciqchangrate,irejectautoid,iexpiratdatecalcu,cexpirationdate,dexpirationdate,cupsocode,iorderdid,iordertype,
csoordercode,iorderseq,cbatchproperty1,cbatchproperty2,cbatchproperty3,cbatchproperty4,cbatchproperty5,cbatchproperty6,cbatchproperty7,cbatchproperty8,
cbatchproperty9,cbatchproperty10,ivouchrowno,irowno,cbmemo,cbsysbarcode,carrivalcode) 
Values ('" + jsautoid + "','" + jsID + "',N'4100',N'" + s存货编码 + "'," + d拒收件数 + "," + d拒收数量 + "," + ClsBaseDataInfo.ReturnCol(d无税单价) + "," + ClsBaseDataInfo.ReturnCol(d含税单价) + "," +
        "" + ClsBaseDataInfo.ReturnCol(d含税金额) + "," + ClsBaseDataInfo.ReturnCol(d税额) + "," + ClsBaseDataInfo.ReturnCol(d含税金额) + "," + ClsBaseDataInfo.ReturnCol(d无税单价) + "," +
        "" + ClsBaseDataInfo.ReturnCol(d无税金额) + "," + ClsBaseDataInfo.ReturnCol(d税额) + "," + ClsBaseDataInfo.ReturnCol(d含税金额) + "," +
        "" + ClsBaseDataInfo.ReturnCol(dt到货单信息.Rows[0]["cfree1"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单信息.Rows[0]["cfree2"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单信息.Rows[0]["cfree3"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单信息.Rows[0]["cfree4"]) + ",NULL,NULL,NULL,NULL,NULL,NULL,17," +
        "NULL,NULL,NULL," + ClsBaseDataInfo.ReturnCol(dt到货单信息.Rows[0]["cdefine25"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单信息.Rows[0]["cdefine26"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单信息.Rows[0]["cdefine27"]) + ",NULL,NULL,NULL," +
        "NULL,NULL,NULL,NULL,NULL,NULL,NULL," +
        "" + ClsBaseDataInfo.ReturnCol(dt到货单信息.Rows[0]["citem_class"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单信息.Rows[0]["citemcode"]) + "," + ClsBaseDataInfo.ReturnCol(dt到货单信息.Rows[0]["iposid"]) + "" +
        ",NULL,N'02',NULL,NULL,NULL,NULL,NULL," +
        "null,0,N'',NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL," +
        "" + ClsBaseDataInfo.ReturnCol(dt到货单信息.Rows[0]["sodid"]) + ",1,NULL,NULL,NULL,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,NULL,NULL,NULL,NULL," +
        "" + ClsBaseDataInfo.ReturnCol(dt到货单信息.Rows[0]["csocode"]) + ",NULL,NULL," + ClsBaseDataInfo.ReturnCol(dt到货单信息.Rows[0]["cdefine1"]) + ",NULL,NULL,NULL,NULL,0,NULL,NULL,NULL,NULL,NULL,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,N'无',N'无',NULL,NULL," +
        "'" + d当前服务器时间.ToString("yyyy-MM-dd") + "',1,2,NULL,NULL," + ClsBaseDataInfo.ReturnCol(dt到货单信息.Rows[0]["carrivalcode"]) + ")";
                                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);




                            }
                            #endregion
                        }
                    }

                    //7. 更新历史单据号表

                    sSQL = @"
IF EXISTS(select cNumber as Maxnumber From VoucherHistory  with (XLOCK) Where  CardNumber='24' and cContent='日期' and cSeed='111111') 
    update VoucherHistory set cNumber='222222' Where  CardNumber='24' and cContent='日期' and cSeed='111111'
else
    Insert into VoucherHistory(CardNumber,cContent,cContentRule,cSeed,cNumber) values('24','日期','月','111111','222222')


IF EXISTS(select cNumber as Maxnumber From VoucherHistory  with (XLOCK) Where  CardNumber='26' and cContent='日期' and cSeed='111111') 
    update VoucherHistory set cNumber='333333' Where  CardNumber='26' and cContent='日期' and cSeed='111111'
else
    Insert into VoucherHistory(CardNumber,cContent,cContentRule,cSeed,cNumber) values('26','日期','月','111111','333333')
";
                    sSQL = sSQL.Replace("111111", d当前服务器时间.ToString("yyMM"));
                    sSQL = sSQL.Replace("222222", iRdCode.ToString());
                    sSQL = sSQL.Replace("333333", iRCode.ToString());
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
                    s = "生成单据号：" + s采购入库单据号;
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
        private string sGetCode(long l,int iLength,string s前缀)
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

        public string Chk采购入库条码是否已经使用(string sBarCode)
        {
            string s = "";

            try
            {
                string sSQL = "select count(1) from rdrecords01 where isnull(cDefine22 ,'') = '" + sBarCode + "'";
                s = ClsBaseClass.SqlHelper.ExecuteScalar(ClsBaseClass.ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).ToString();
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public static DataTable Group(DataTable dt, string[] ColumnName, string Sel)
        {
            DataRow[] dw = dt.Select(Sel);
            DataTable dts = new DataTable();
            foreach (DataColumn dc in dt.Columns)
            {
                dts.Columns.Add(dc.ColumnName);
            }
            foreach (DataRow dws in dw)
            {
                dts.ImportRow(dws);
            }
            DataView dv = new DataView(dts);
            DataTable dtgroup = dv.ToTable(true, ColumnName);
            return dtgroup;
        }

    }
}
