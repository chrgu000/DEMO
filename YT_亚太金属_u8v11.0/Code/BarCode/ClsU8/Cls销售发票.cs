using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using ClsBaseClass;

namespace ClsU8
{
    public class Cls销售发票
    {
        public string Save销售出库单(DataTable dtData)
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

                    //1.  判断是否结账
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
                    sSQL = "select MAX(a.SBVID) as iFatherId,MAX(b.AutoID) as iChildId from salebillvouch a left join salebillvouchs b on a.SBVID=b.SBVID ";
                    DataTable dt = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    long lID = SqlHelper.ReturnObjectToLong(dt.Rows[0]["iFatherId"]);

                    //Select * From VoucherNumber Where CardNumber='13'

                    long lIDMain = lID;
                    long lIDDetail = SqlHelper.ReturnObjectToLong(dt.Rows[0]["iChildId"]);
                    //3. 获得单据号
                    long iCode = 0;
                    sSQL = "select cNumber as Maxnumber From VoucherHistory  with (NOLOCK) Where  CardNumber='13' and cContent='单据日期' and cSeed='2014'";
                    dtTemp = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp == null || dtTemp.Rows.Count < 1)
                    {
                        iCode = 1;
                    }
                    else
                    {
                        iCode = ClsBaseDataInfo.ReturnObjectToLong(dtTemp.Rows[0]["Maxnumber"]);
                    }

                    //4. 组装表头
                    lID += 1;
                    string s仓库 = dtData.Rows[0]["仓库"].ToString().Trim();
                    string s订单号 = dtData.Rows[0]["单据号"].ToString().Trim();
                    string s制单人 = dtData.Rows[0]["制单人"].ToString().Trim();
                    //string s产量 = dt生产订单表头.Rows[0]["Qty"].ToString().Trim();
                    //string s产品编码 = dt生产订单表头.Rows[0]["InvCode"].ToString().Trim();
                    //string s生产订单主表标志 = dt生产订单表头.Rows[0]["MoId"].ToString().Trim();
                    iCode += 1;
                    string s单据号 = sGetCode(iCode, 4, "XSTZ04" + d当前服务器时间.ToString("yyMM"));

                    //sSQL = "select * from DispatchList  where cDLCode  = '" + s订单号 + "' and isnull(bReturnFlag,0) = 0 ";
                    //DataTable dt发货单 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    //if (dt发货单 == null || dt发货单.Rows.Count < 1)
                    //{
                    //    throw new Exception("获得发货单信息失败");
                    //}
                    string s发票类型 = "27";
                    int i红蓝标志 = 0;

                    //获取销售订单
                    sSQL = "select * from SO_SOMain a left join SO_SODetails b on a.ID=b.ID where b.AutoID  = '" + dtData.Rows[0]["销售订单子表ID"].ToString().Trim() + "'";
                    DataTable dt销售订单 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt销售订单.Rows.Count == 0)
                    {
                        throw new Exception("获得销售订单失败");
                    }

                    string 销售类型 = dt销售订单.Rows[0]["cSTCode"].ToString();
                    decimal 汇率 = ClsBaseDataInfo.ReturnObjectToDecimal(dt销售订单.Rows[0]["iExchRate"], 6);
                    decimal 税率 = ClsBaseDataInfo.ReturnObjectToDecimal(dt销售订单.Rows[0]["iTaxRate"], 6);  

                    sSQL = "select * from Customer where cCusCode = '" + dt销售订单.Rows[0]["cCusCode"].ToString().Trim() + "'";
                    DataTable dt客户 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt客户.Rows.Count == 0)
                    {
                        throw new Exception("客户编码不存在");
                    }

                    sSQL = " Insert Into salebillvouch(ivtid,csource,cstcode,cdepcode,ccuscode,ccusbank,ccusaccount,bcashsale,sbvid,csbvcode" +
                                        ",cvouchtype,ddate,csocode,cdefine2,cmaker,cverifier,iexchrate,itaxrate,breturnflag,bfirst" +

                                        ",cbustype,cbcode,cexch_name,ccusname,idisp,cdlcode,cchecker,iflowid,bcredit,ioutgolden" +
                                        ",iverifystate,iswfcontrolled,iprintcount,cgatheringplan,icreditdays,cdefine14) " +

                                   "Values (17,N'销售',N'" + 销售类型 + "',N'" + dt销售订单.Rows[0]["cdepcode"].ToString().Trim() + "',N'" + dt客户.Rows[0]["ccuscode"].ToString().Trim() + "',N'" + dt客户.Rows[0]["cCusBank"].ToString().Trim() + "',N'" + dt客户.Rows[0]["cCusAccount"].ToString().Trim() + "',0," + lID + ",N'" + iCode + "'" +
                                   ",N'" + s发票类型 + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "',Null,Null,N'" + s制单人 + "',Null," + 汇率 + "," + 税率 + "," + i红蓝标志 + ",0" +

                                   ",N'普通销售',null,N'" + dt销售订单.Rows[0]["cexch_name"].ToString().Trim() + "',N'" + dt销售订单.Rows[0]["cCusName"].ToString().Trim() + "',0,Null,Null,Null,0,Null" +
                                   ",0,0,Null,Null,Null,'Y')";
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    for (int i = 0; i < dtData.Rows.Count; i++)
                    {
                        //判断条码是否已经使用
                        //sSQL = "select * from salebillvouch where cdefine28 = " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["条形码"].ToString()) + " ";
                        //int iCou = ClsBaseDataInfo.ReturnObjectToInt(SqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));
                        //if (iCou > 0)
                        //{
                        //    sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + "已经使用\n";
                        //    continue;
                        //}


                        sSQL = "select * from Inventory where cInvCode = '" + dtData.Rows[i]["存货编码"].ToString().Trim() + "'";
                        DataTable dt存货 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt存货.Rows.Count == 0)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "存货不存在\n";
                            continue;
                        }

                        //组装表体
                        sSQL = "select * from CurrentStock where cWhCode = '" + dtData.Rows[i]["仓库"].ToString().Trim() + "' and cInvCode = '" + dtData.Rows[i]["存货编码"].ToString().Trim() + "' and isnull(cBatch,'') = '" + dtData.Rows[i]["批号"].ToString().Trim() + "' "+
                            "and isnull(cFree1,'') = '" + dtData.Rows[i]["材质"].ToString().Trim() + "'  and isnull(cFree2,'') = '" + dtData.Rows[i]["渗层"].ToString().Trim() + "' and isnull(cFree3,'') = '" + dtData.Rows[i]["统一号"].ToString().Trim() + "' and isnull(cFree4,'') = '" + dtData.Rows[i]["工艺要求"].ToString().Trim() + "'  ";
                        DataTable dt现存量 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        //获取销售订单
                        sSQL = "select * from SO_SOMain a left join SO_SODetails b on a.ID=b.ID where b.AutoID  = '" + dtData.Rows[i]["销售订单子表ID"].ToString().Trim() + "'";
                        DataTable dt销售订单s = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt销售订单.Rows.Count == 0)
                        {
                            throw new Exception("获得销售订单失败");
                        }


                        lIDDetail += 1;
                        string s存货编码 = dtData.Rows[i]["存货编码"].ToString().Trim();
                        decimal d数量 = ClsBaseDataInfo.ReturnObjectToDecimal(dtData.Rows[i]["数量"], 6);
                        decimal d件数 = 0;

                        decimal d现存数量 = ClsBaseDataInfo.ReturnObjectToDecimal(dt现存量.Rows[0]["iQuantity"], 6);
                        decimal d现存件数 = ClsBaseDataInfo.ReturnObjectToDecimal(dt现存量.Rows[0]["iNum"], 6);

                        decimal d销售订单数量 = ClsBaseDataInfo.ReturnObjectToDecimal(dt销售订单s.Rows[0]["iQuantity"]);
                        decimal d销售订单件数 = ClsBaseDataInfo.ReturnObjectToDecimal(dt销售订单s.Rows[0]["iNum"]);
                        if (d销售订单件数 > 0)
                        {
                            d件数 = ClsBaseDataInfo.ReturnObjectToDecimal(d数量 * d销售订单件数 / d销售订单数量, 6);
                        }
                        decimal d换算率 = ClsBaseDataInfo.ReturnObjectToDecimal(dt销售订单s.Rows[0]["iInvExchRate"]);

                        if (d数量 > d现存数量)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "现存量小于销售出库单数量不存在\n";
                        }

                        decimal 原币无税单价 = ClsBaseDataInfo.ReturnObjectToDecimal(dt销售订单s.Rows[0]["iUnitPrice"], 6);
                        decimal 原币含税单价 = ClsBaseDataInfo.ReturnObjectToDecimal(dt销售订单s.Rows[0]["iTaxUnitPrice"], 6);
                        decimal 本币无税单价 = ClsBaseDataInfo.ReturnObjectToDecimal(dt销售订单s.Rows[0]["iNatUnitPrice"], 6);

                        decimal 原币无税金额 = ClsBaseDataInfo.ReturnObjectToDecimal(dt销售订单s.Rows[0]["iMoney"], 6) * d数量 / d销售订单数量;
                        decimal 本币价税合计 = ClsBaseDataInfo.ReturnObjectToDecimal(dt销售订单s.Rows[0]["iNatSum"], 6) * d数量 / d销售订单数量;
                        decimal 本币税额 = ClsBaseDataInfo.ReturnObjectToDecimal(dt销售订单s.Rows[0]["iNatTax"], 6) * d数量 / d销售订单数量;
                        decimal 原币税额 = ClsBaseDataInfo.ReturnObjectToDecimal(dt销售订单s.Rows[0]["iTax"], 6) * d数量 / d销售订单数量;
                        decimal 原币价税合计 = ClsBaseDataInfo.ReturnObjectToDecimal(dt销售订单s.Rows[0]["iSum"], 6) * d数量 / d销售订单数量;
                        decimal 本币无税金额 = ClsBaseDataInfo.ReturnObjectToDecimal(dt销售订单s.Rows[0]["iNatMoney"], 6) * d数量 / d销售订单数量;

                        sSQL = "Insert Into salebillvouchs(sbvid,autoid,cwhcode,cinvcode,iquantity,inum,iquotedprice,iunitprice,itaxunitprice,imoney" +
                                       ",itax,isum,idiscount,inatunitprice,inatmoney,inattax,inatsum,inatdiscount,isbvid,imoneysum" +
                                       ",iexchsum,cclue,cincomesub,ctaxsub,ibatch,bsettleall,rdsid,itb,tbquantity" +
                                       ",isosid,idlsid,kl,kl2,cinvname,itaxrate,foutquantity,foutnum,fsalecost,fsaleprice" +
                                       ",iinvexchrate,cunitid,ipbvsid,ccode,csocode,bgsp,ccontractid,ccontracttagcode,ccontractrowguid,cmassunit" +
                                       ",bqaneedcheck,bqaurgency,cbaccounter,bcosting,cordercode,iorderrowno,fcusminprice,irowno,iexpiratdatecalcu,idemandtype" +
                                       ",cdemandcode,cdemandmemo,cdemandid,idemandseq,cbdlcode,iinvsncount,bneedsign,cgathingcode,ftaxpasum,fpasum" +
                                       ",fnattaxpasum,fnatpasum,body_outid,cinvouchtype,icostquantity,icostsum,"+
                                        "cBatch ,cfree1,cfree2,cfree3,cfree4,cfree5,cfree6,cfree7,cfree8,cfree9,cfree10)" +
                             " Values (" + lID + "," + lIDDetail + ",N'" + dtData.Rows[i]["仓库"].ToString().Trim() + "',N'" + dtData.Rows[i]["存货编码"].ToString().Trim() + "'," + d数量 + "," + d件数 + ",0," + 原币无税单价 + "," + 原币含税单价 + "," + 原币无税金额 + "" +
                                       "," + 原币税额 + "," + 原币价税合计 + ",0," + 本币无税单价 + "," + 本币无税金额 + "," + 本币税额 + "," + 本币价税合计 + ",0,0,0" +
                                       ",0,Null,Null,Null,Null,0,Null,0,0" +
                                       ",'" + dtData.Rows[i]["销售订单子表ID"].ToString().Trim() + "',Null,100,100,N'" + dt存货.Rows[0]["cInvName"].ToString().Trim() + "'," + 税率 + ",0,0,0,0" +
                                       "," + d换算率 + ",N'" + dt存货.Rows[0]["cComUnitCode"].ToString().Trim() + "',Null,Null,Null,0,Null,Null,Null,0" +
                                       ",0,0,Null,1,Null,Null,0,1,0,Null" +
                                       ",Null,Null,Null,Null,Null,0,0,Null,0,Null" +
                                       ",0,0,Null,Null,Null,Null,"+
                                        "'" + dtData.Rows[i]["批号"].ToString().Trim() + "','" + dtData.Rows[i]["材质"].ToString().Trim() + "','" + dtData.Rows[i]["渗层"].ToString().Trim() + "','" + dtData.Rows[i]["统一号"].ToString().Trim() + "','" + dtData.Rows[i]["工艺要求"].ToString().Trim() + "',Null,Null,Null,Null,Null,Null)";

                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    //7. 更新历史单据号表
                    sSQL = "update VoucherHistory set cNumber='" + iCode + "' Where  CardNumber='13' and cContent='单据日期' and cSeed='" + ClsBaseDataInfo.sUFDataBaseName + "'";
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    ////8. 更新单据ID号表
                    //sSQL = "update  UFSystem..UA_Identity set iFatherId = " + lID + ",iChildId = " + lIDDetail + " where cVouchType = 'BILLVOUCH' and cAcc_Id =  '" + ClsBaseDataInfo.sUFDataBaseName.Trim().Substring(7, 3) + "'";
                    //SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

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


        public string Chk销售发票条码是否已经使用(string sBarCode, string sCode)
        {
            string s = "";

            try
            {
                string sSQL = "select count(*) from salebillvouchs where cBatch = '333333' and ((isnull(isodid,N'')=N'111111' and ispe=1) or (isnull(isodid,N'')=N'' and ispe=0))";
                sSQL = sSQL.Replace("111111", sCode);
                sSQL = sSQL.Replace("333333", sBarCode);
                s = ClsBaseClass.SqlHelper.ExecuteScalar(ClsBaseClass.ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).ToString();
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string dt销售发票条码信息(string sBarCode, string sWhere)
        {
            string s = "";
            try
            {
                string sSQL = @"
select distinct * ,d.Autoid as 条形码
from salebillvouch a inner join salebillvouchs b on a.SBVID = b.SBVID
    inner join Inventory c on b.cInvCode = c.cInvCode
    left join dbo._BarCodeInventory d on b.cInvCode = d.cInvCode and ISNULL(b.cFree1,'') = ISNULL(d.cFree1,'')
        and ISNULL(b.cFree2,'') = ISNULL(d.cFree2,'') and ISNULL(b.cFree3,'') = ISNULL(d.cFree3,'') and ISNULL(b.cFree4,'') = ISNULL(d.cFree4,'') and ISNULL(b.cFree5,'') = ISNULL(d.cFree5,'')
        and ISNULL(b.cFree6,'') = ISNULL(d.cFree6,'') and ISNULL(b.cFree7,'') = ISNULL(d.cFree7,'') and ISNULL(b.cFree8,'') = ISNULL(d.cFree8,'') and ISNULL(b.cFree9,'') = ISNULL(d.cFree9,'')
        and ISNULL(b.cFree10,'') = ISNULL(d.cFree10,'') and ISNULL(b.cbatch,'') = ISNULL(d.cbatch,'')
where a.cSBVCode  = '111111' and 1=1
";
                sSQL = sSQL.Replace("111111", sBarCode.Trim());
                sSQL = sSQL.Replace("1=1", sWhere.Trim());
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

//select a.*, b.cInvName,b.cInvStd,b.bInvBatch,e.iQuantity,e.iNum
//from _BarCodeInventory a inner join Inventory b on a.cInvCode = b.cInvCode 	
//
//	inner join (
//					select max(b.cInvCode) as cInvCode, sum(b.iQuantity) as iQuantity,sum(b.iNum) as iNum,max(b.cBatch) as cBatch,
//					max(b.cfree1) as cfree1,max(b.cFree2) as cFree2,max(b.cFree3) as cFree3,max(b.cFree4) as cFree4,max(b.cFree5) as cFree5,
//					max(b.cFree6) as cFree6,max(b.cFree7) as cFree7,max(b.cFree8) as cFree8,max(b.cFree9) as cFree9,max(b.cFree10) as cFree10
//                    from salebillvouch a inner join salebillvouchs b on a.SBVID   = b.SBVID
//                    left join SO_SODetails d on b.iSOsID=d.AutoID
//                    from salebillvouch a inner join salebillvouchs b on a.SBVID   = b.SBVID
//                    left join SO_SODetails d on b.iSOsID=d.AutoID and d.cSOCode  = '111111' 
//				) e on e.cInvCode = a.cInvCode and isnull(a.cBatch,'') = isnull(e.cBatch  ,'') and ISNULL(a.cFree1,'') = ISNULL(e.cFree1,'') and ISNULL(a.cFree2,'') = ISNULL(e.cFree2,'') and ISNULL(a.cFree3,'') = ISNULL(e.cFree3,'') and ISNULL(a.cFree4,'') = ISNULL(e.cFree4,'')
//		 and ISNULL(a.cFree5,'') = ISNULL(e.cFree5,'') and ISNULL(a.cFree6,'') = ISNULL(e.cFree6,'') and ISNULL(a.cFree7,'') = ISNULL(e.cFree7,'') and ISNULL(a.cFree8,'') = ISNULL(e.cFree8,'') and ISNULL(a.cFree9,'') = ISNULL(e.cFree9,'') and ISNULL(a.cFree10,'') = ISNULL(e.cFree10,'')
//where a.AutoID  = '333333'