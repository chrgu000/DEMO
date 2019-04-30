using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using FrameBaseFunction;

namespace Warehouse
{
    class U8ImportUtis
    {
        public static ArrayList aList = new ArrayList();
        public static string WHCode = "";

        public static bool DoBack(SqlTransaction trans, DataTable dtPuBack, DataTable dtOMBack, out string returnMsg)
        {
            FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
            returnMsg = "";
            long iIDArr = 0; //退货单表头Id
            long iIDDetailArr = 0;//退货单明细id
            GetID("PuArrival", out iIDArr, out iIDDetailArr);
            string sSQL = "select isnull(max(cNumber),0) as Maxnumber From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='26' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "')";
            DataTable dtCode = clsSQLCommond.ExecQuery(sSQL);
            
            long iCodeArr = Convert.ToInt64(dtCode.Rows[0]["Maxnumber"]);  //退货单单据号

            long iIDBack = 0; //红字入库单ID
            long iIDBackDetail = 0;//红字入库单明洗
            GetID("rd", out iIDBack, out iIDBackDetail);
            sSQL = "select isnull(max(cNumber),0) as Maxnumber From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='24' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "')";
            DataTable dtCodeBack = clsSQLCommond.ExecQuery(sSQL);
            long iCodeBack = Convert.ToInt64(dtCodeBack.Rows[0]["Maxnumber"]);

            string puMsg = "";
            string omDOMsg = "";
            string omRedMsg = "";


            DoPuBackAction(trans, dtPuBack, ref iCodeArr, ref iIDArr, ref iIDDetailArr, ref iCodeBack,
                ref iIDBack, ref iIDBackDetail, out puMsg);

            DoOMBackAction(trans, dtOMBack, ref iCodeArr, ref iIDArr, ref iIDDetailArr, ref iCodeBack,
                ref iIDBack, ref iIDBackDetail, out omDOMsg);

            GenOMFormRedRdRecord(trans, dtOMBack, ref iCodeBack, ref iIDBack, ref iIDBackDetail, out omRedMsg);


            //打开被退货的所被关闭的订单
            foreach (DataRow row in dtPuBack.Rows)
            {
                string poDId = row["PODId"].ToString();
                sSQL = "update dbo.PO_Podetails set cbCloseDate =null,cbCloser =null,cbCloseTime =null where ID ={0}";
                sSQL = string.Format(sSQL, poDId);
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);
            }


            foreach (DataRow row in dtOMBack.Rows)
            {
                string poDId = row["PODId"].ToString();
                sSQL = "update dbo.OM_MODetails  set cbCloser =null,dbCloseDate =null,dbCloseTime =null where MODetailsID ={0}";
                sSQL = string.Format(sSQL, poDId);
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);
            }



            //更新退货单ID
            sSQL = "update UFSystem..UA_Identity set iFatherID = " + iIDArr + ",iChildID=" + iIDDetailArr + "  where cAcc_Id = '200' and cVouchType = 'PuArrival'";
            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);

            //更新退货单最大单据号
            sSQL = "select count(*) as iCount From VoucherHistory  with (NOLOCK) Where  CardNumber='26' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "')";
            DataTable dtCodeTemp = SqlHelper.ExecuteDataset(trans, CommandType.Text, sSQL).Tables[0];

            if (dtCodeTemp.Rows[0]["iCount"].ToString().Trim() == "0")
            {
                sSQL = "insert into VoucherHistory(cardnumber,ccontent,ccontentrule,cseed,cnumber,bempty)values('26','单据日期','月','" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "','1',0)";
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);
            }
            else
            {
                sSQL = "update VoucherHistory set cNumber = '" + iCodeArr.ToString().Trim() + "' Where  CardNumber='26' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "')";
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);
            }


            sSQL = "update UFSystem..UA_Identity set iFatherID = " + iIDBack + ",iChildID=" + iIDBackDetail + "  where cAcc_Id = '200' and cVouchType = 'rd'";
            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);

            //更改最大单据号
            sSQL = "select count(*) as iCount From VoucherHistory  with (NOLOCK) Where CardNumber='24' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "')";
            dtCodeTemp = SqlHelper.ExecuteDataset(trans, CommandType.Text, sSQL).Tables[0];

            if (dtCodeTemp.Rows[0]["iCount"].ToString().Trim() == "0")
            {
                sSQL = "insert into VoucherHistory(cardnumber,ccontent,ccontentrule,cseed,cnumber,bempty)values('24','日期','月','" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "','1',0)";
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);
            }
            else
            {
                sSQL = "update VoucherHistory set cNumber = '" + iCodeBack.ToString().Trim() + "' Where CardNumber='24' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "')";
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);
            }


            returnMsg = puMsg + omDOMsg + omRedMsg;
            return true;

        }


        #region 采购退货单
        /// <summary>
        /// 生成采购退货单
        /// </summary>
        /// <param name="dtPuBack"></param>
        public static void DoPuBackAction(SqlTransaction trans, DataTable dtPuBack,
            ref long iCodeArr, ref long iIDArr, ref long iIDDetailArr,
            ref long iCodeBack, ref long iIDBack, ref long iIDBackDetail,
            out string returnMsg)
        {
            returnMsg = "";
            aList.Clear();
            string sSQL = "";
            Dictionary<string, string> venLists = new Dictionary<string, string>();

            foreach (DataRow row in dtPuBack.Rows)
            {
                string venCode = row["VenCode"].ToString();
                if (!venLists.ContainsKey(venCode))
                {
                    venLists.Add(venCode, "");
                }
            }


            foreach (KeyValuePair<string, string> item in venLists)
            {

                DataRow[] qtyRows = dtPuBack.Select("ArriveQty>0 and VenCode='" + item.Key + "'");
                if (qtyRows.Length > 0)
                {
                    iIDArr += 1;
                    iCodeArr += 1;

                    DataRow[] dr2 = qtyRows;
                    sSQL = @"select  top 1 d.POID ,
                            d.ID ,
                            d.iQuantity,m.cDepCode ,
                            m.cVenCode ,
                            isnull(iArrQTY,0) as iArrQTY
                    from    dbo.PO_Podetails D
                            left join dbo.PO_Pomain M on D.POID = M.POID
                    where  d.ID ='{0}'";
                    sSQL = string.Format(sSQL, qtyRows[0]["PODId"].ToString());
                    DataTable dtPuInfo = SqlHelper.ExecuteDataset(trans, CommandType.Text, sSQL).Tables[0];

                    string sRDCode = "";
                    string sDepCode = dtPuInfo.Rows[0]["cDepCode"].ToString();
                    string venCode = dtPuInfo.Rows[0]["cVenCode"].ToString();
                    sRDCode = sSetCode(iCodeArr, sDepCode);

                    returnMsg += "由采购定单生成采购退货单:" + sRDCode + "\r\n";

                    //表头
                    sSQL = "Insert Into PU_ArrivalVouch(ivtid,id,ccode,cptcode,ddate,cvencode,cdepcode,cpersoncode,cpaycode,csccode,cexch_name,iexchrate,itaxrate,cmemo," +
                                "cbustype,cmaker,bnegative,cdefine1,cdefine2,cdefine3,cdefine4,cdefine5,cdefine6,cdefine7,cdefine8,cdefine9,cdefine10,cdefine11,cdefine12,cdefine13,cdefine14,cdefine15,cdefine16,ccloser,idiscounttaxtype,ibilltype,cvouchtype,cgeneralordercode,ctmcode,cincotermcode,ctransordercode,dportdate,csportcode,caportcode,csvencode,carrivalplace,dclosedate,idec,bcal,guid,iverifystate,cauditdate,cverifier,iverifystateex,ireturncount,iswfcontrolled,cvenpuomprotocol) " +
                           "Values( 8169," + iIDArr + ",'" + sRDCode + "','01','" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "','" + venCode + "','" + sDepCode + "',NULL,NULL,NULL,N'人民币',1,17,NULL, " +
                                "N'普通采购','" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,2,NULL,0,NULL) ";
                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);

                    sSQL = "update PU_ArrivalVouch  set cverifier='" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',cAuditDate=getdate() ,cAuditTime =getdate() where id=" + iIDArr;
                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);

                    //表体 
                    for (int i = 0; i < dr2.Length; i++)
                    {
                        iIDDetailArr += 1;

                        sSQL = @"select  top 1 d.cInvCode,
                                 d.iQuantity ,d.iNum ,
                                 i.cAssComUnitCode 
                                from    dbo.PO_Podetails D
                                        left join dbo.PO_Pomain M on D.POID = M.POID
                                left join dbo.Inventory I on D.cInvCode =I.cInvCode 
                        where  d.ID ='{0}'";
                        sSQL = string.Format(sSQL, dr2[i]["PODId"].ToString());
                        dtPuInfo = SqlHelper.ExecuteDataset(trans, CommandType.Text, sSQL).Tables[0];

                        string invCode = dtPuInfo.Rows[0]["cInvCode"].ToString();

                        string s1 = "null";
                        if (dtPuInfo.Rows[0]["iNum"].ToString() != "" && dtPuInfo.Rows[0]["iNum"].ToString() != "0")
                        {
                            decimal cRate = decimal.Parse(dtPuInfo.Rows[0]["iQuantity"].ToString()) / decimal.Parse(dtPuInfo.Rows[0]["iNum"].ToString());
                            s1 = (decimal.Parse(dr2[i]["BackQty"].ToString().Trim()) * cRate).ToString();
                        }
                        string s2 = "null";
                        if (dr2[i]["BackQty"].ToString().Trim() != string.Empty)
                            s2 = dr2[i]["BackQty"].ToString().Trim();

                        sSQL = " Insert Into PU_ArrivalVouchs(autoid,id,cwhcode,cinvcode,inum,iquantity," +
                                   "ioricost,ioritaxcost,iorimoney,ioritaxprice,iorisum,icost,imoney,itaxprice,isum,itaxrate," +
                                   "citem_class,citemcode,iposid,citemname,frealquantity,fvalidquantity,bgsp,btaxcost,sodid," +
                                   "sotype,iinvexchrate,csocode,cordercode,rejectsource,iexpiratdatecalcu) Values  " +
                               "(" + iIDDetailArr + "," + iIDArr + ",'" + WHCode + "',N'" + invCode + "'," + "null" + ",0-" + s2 + "," +
                                   "null,null,null,null,null,null,null,null,null,17," +
                                   "null,null," + dr2[i]["PODId"].ToString() + ",null,null,null,0,0,N'" + "" + "'," +
                                   "0,0,null,N'" + "" + "',0,0)";
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);

                        sSQL = "select * from PO_Podetails where ID  = " + dr2[i]["PODId"].ToString();
                        DataTable dtPodetails = SqlHelper.ExecuteDataset(trans, CommandType.Text, sSQL).Tables[0];

                        //原币含税单价  6位
                        //无税单价      6位
                        //数量          6位
                        //价税合计      2位   原币含税单价 * 数量
                        //无税金额      2位   价税合计 / （1 + 税率） 
                        //税额          2位   价税合计 - 无税金额 
                        //税率          2位
                        //----------------------------------------------------------------------------------------------------------------

                        //税率          
                        decimal ipertaxrate = decimal.Round(Convert.ToDecimal(dtPodetails.Rows[0]["iPerTaxRate"]), 2);

                        //单价(不含税)
                        decimal iUnitCost = decimal.Round(Convert.ToDecimal(dtPodetails.Rows[0]["iUnitPrice"].ToString() == "" ? "0" : dtPodetails.Rows[0]["iUnitPrice"].ToString()), 6);
                        //金额(不含税)
                        decimal iPrice = decimal.Round(iUnitCost * decimal.Parse(s2), 2);

                        //原币含税单价
                        decimal iTaxPrice = decimal.Round(Convert.ToDecimal(dtPodetails.Rows[0]["iTaxPrice"].ToString() == "" ? "0" : dtPodetails.Rows[0]["iTaxPrice"].ToString()), 6);
                        //原币价税合计
                        decimal iOriSum = decimal.Round(iTaxPrice * decimal.Round(decimal.Parse(s2), 6), 2);

                        //原币无税金额 
                        decimal iOriMoney = decimal.Round(iOriSum / (1 + ipertaxrate / 100), 2);
                        //原币税额 
                        decimal iOriTaxPrice = iOriSum - iOriMoney;

                        sSQL = "update PU_ArrivalVouchs set iOriCost= " + iUnitCost + ",iOriTaxCost = " + iTaxPrice + ",iOriMoney = 0-" + iOriMoney + ",iOriTaxPrice =0- " + iOriTaxPrice + "," +
                                    "iOriSum =0- " + iOriSum + ",iCost = " + iUnitCost + ",iMoney =0- " + iOriMoney + ",iTaxPrice =0- " + iOriTaxPrice + ",iSum = 0-" + iOriSum + ",iTaxRate = " + ipertaxrate + " " +
                                " where autoid = " + iIDDetailArr;

                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);

                        if (s1 != "null" && s1 != string.Empty && Convert.ToDouble(s1) != 0)
                        {
                            sSQL = "update PU_ArrivalVouchs set iinvexchrate=cast((" + s2 + "/" + s1 + ")  as decimal(18, 8)),inum=0-" + s1 + " " +
                                            " ,cUnitID = '" + dtPuInfo.Rows[0]["cAssComUnitCode"].ToString().Trim() + "' " +
                                   " where autoid = " + iIDDetailArr;
                            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);
                        }

                        if (dtPodetails.Rows[0]["citemName"].ToString().Trim() != string.Empty)
                        {

                            sSQL = "update  PU_ArrivalVouchs set citem_class='" + dtPodetails.Rows[0]["citem_class"] + "',citemcode='" + dtPodetails.Rows[0]["citemcode"] + "',cItemName='" + dtPodetails.Rows[0]["citemName"] + "' " +
                                    " where autoid = " + iIDDetailArr;
                            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);
                        }

                        sSQL = "update PO_Podetails set iArrQTY  =iArrQTY -  " + s2 + ",iArrNum  =iArrNum - " + s1 + ",iArrMoney  =iArrMoney- " + s2 + "*(iSum /iQuantity )," +
                                    "iNatArrMoney  = iNatArrMoney-  " + s1 + " * (iNatSum /iQuantity) ,fPoRetQuantity =fPoRetQuantity +" + s2 + " ," +
                                    "iReceivedQTY=iReceivedQTY -" + s2 + ",iReceivedNum =iReceivedNum -" + s1 + ",iReceivedMoney =iReceivedMoney -" + s2 + "*(iSum /iQuantity )" +
                                    " where ID  = " + dr2[i]["PODId"].ToString();
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);
                    }

                    string redRdCode = GenPoArriveRedRdRecord(trans, iIDArr, ref iCodeBack, ref iIDBack, ref iIDBackDetail);

                    returnMsg += "由采购退货单:" + sRDCode + "生成红字采购入库单:" + redRdCode + "\r\n";
                }


                DataRow[] noArrQtyRow = dtPuBack.Select("ReceiveQty>0 and BackQty>0 and VenCode='" + item.Key + "'");

                if (noArrQtyRow.Length > 0)
                {
                    string redRdCode = GenPoRedRdRecord(trans, noArrQtyRow, ref iCodeBack, ref iIDBack, ref iIDBackDetail);
                    returnMsg += "由采购定单生成红字采购入库单:" + redRdCode + "\r\n";
                }
            }
        }
        #endregion

        #region 委外退货单
        /// <summary>
        /// 生成委外退货单
        /// </summary>
        /// <param name="dtPuBack"></param>
        public static void DoOMBackAction(SqlTransaction trans, DataTable dtPuBack,
            ref long iCodeArr, ref long iIDArr, ref long iIDDetailArr,
            ref long iCodeBack, ref long iIDBack, ref long iIDBackDetail,
            out string returnMsg)
        {

            Dictionary<string, string> venLists = new Dictionary<string, string>();

            foreach (DataRow row in dtPuBack.Rows)
            {
                string venCode = row["VenCode"].ToString();
                if (!venLists.ContainsKey(venCode))
                {
                    venLists.Add(venCode, "");
                }
            }


            string sSQL = "";
            returnMsg = "";

            foreach (KeyValuePair<string, string> item in venLists)
            {
                DataRow[] dr2 = dtPuBack.Select("ArriveQty>0 and VenCode ='" + item.Key + "'");
                if (dr2.Length == 0)
                    continue;

                sSQL = @"select top 1
                                m.cDepCode ,
                                m.cVenCode
                        from    dbo.OM_MOMain M
                                left join dbo.OM_MODetails D on M.MOID = D.MOID
                        where   d.MODetailsID  = '{0}'";

                sSQL = string.Format(sSQL, dr2[0]["PODId"].ToString());

                DataTable dtPuInfo = SqlHelper.ExecuteDataset(trans, CommandType.Text, sSQL).Tables[0];

                string sDepCode = dtPuInfo.Rows[0]["cDepCode"].ToString();
                string venCode = dtPuInfo.Rows[0]["cVenCode"].ToString();

                iCodeArr += 1;
                string sRDCode = sSetCode(iCodeArr, sDepCode);

                returnMsg += "委外定单生成委外退货单:" + sRDCode + "\r\n";

                iIDArr += 1;

                //表头
                sSQL = "Insert Into PU_ArrivalVouch(ivtid,id,ccode,cptcode,ddate,cvencode,cdepcode,cpersoncode,cpaycode,csccode,cexch_name,iexchrate,itaxrate,cmemo," +
                            "cbustype,cmaker,bnegative,cdefine1,cdefine2,cdefine3,cdefine4,cdefine5,cdefine6,cdefine7,cdefine8,cdefine9,cdefine10,cdefine11,cdefine12,cdefine13,cdefine14,cdefine15,cdefine16,ccloser,idiscounttaxtype,ibilltype,cvouchtype,cgeneralordercode,ctmcode,cincotermcode,ctransordercode,dportdate,csportcode,caportcode,csvencode,carrivalplace,dclosedate,idec,bcal,guid,iverifystate,cauditdate,cverifier,iverifystateex,ireturncount,iswfcontrolled,cvenpuomprotocol) " +
                       "Values( 8169," + iIDArr + ",'" + sRDCode + "','02','" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "','" + venCode + "','" + sDepCode + "',NULL,NULL,NULL,N'人民币',1,17,NULL, " +
                            "N'委外加工','" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,2,NULL,0,NULL) ";
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);


                sSQL = "update PU_ArrivalVouch  set cverifier='" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',cAuditDate=getdate() ,caudittime =getdate() where id=" + iIDArr;
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);

                //表体 
                for (int i = 0; i < dr2.Length; i++)
                {
                    iIDDetailArr += 1;

                    sSQL = @"select top 1
                        d.cInvCode ,
                        d.iQuantity ,
                        d.iNum ,
                        i.cAssComUnitCode,
                        m.cCode
                    from    dbo.OM_MOMain M
                            left join dbo.OM_MODetails D on M.MOID = D.MOID
                            left join dbo.Inventory I on D.cInvCode = I.cInvCode
                    where   d.MODetailsID  =  '{0}'";

                    sSQL = string.Format(sSQL, dr2[i]["PODId"].ToString());
                    dtPuInfo = SqlHelper.ExecuteDataset(trans, CommandType.Text, sSQL).Tables[0];

                    string invCode = dtPuInfo.Rows[0]["cInvCode"].ToString();

                    string s1 = "null";
                    if (dtPuInfo.Rows[0]["iNum"].ToString() != "" && dtPuInfo.Rows[0]["iNum"].ToString() != "0")
                    {
                        decimal cRate = decimal.Parse(dtPuInfo.Rows[0]["iQuantity"].ToString()) / decimal.Parse(dtPuInfo.Rows[0]["iNum"].ToString());
                        s1 = (decimal.Parse(dr2[i]["BackQty"].ToString().Trim()) * cRate).ToString();
                    }
                    string s2 = "null";
                    if (dr2[i]["BackQty"].ToString().Trim() != string.Empty)
                        s2 = dr2[i]["BackQty"].ToString().Trim();

                    sSQL = " Insert Into PU_ArrivalVouchs(autoid,id,cwhcode,cinvcode,inum,iquantity," +
                               "ioricost,ioritaxcost,iorimoney,ioritaxprice,iorisum,icost,imoney,itaxprice,isum,itaxrate," +
                               "citem_class,citemcode,iposid,citemname,frealquantity,fvalidquantity,bgsp,btaxcost,sodid," +
                               "sotype,iinvexchrate,csocode,cordercode,rejectsource,iexpiratdatecalcu) Values  " +
                           "(" + iIDDetailArr + "," + iIDArr + ",'" + WHCode + "',N'" + invCode + "'," + "null" + ",0-" + s2 + "," +
                               "null,null,null,null,null,null,null,null,null,17," +
                               "null,null," + dr2[i]["PODId"].ToString() + ",null,null,null,0,0,N'" + "" + "'," +
                               "0,0,null,N'" + dtPuInfo.Rows[0]["cCode"].ToString() + "',0,0)";
                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);


                    sSQL = "select * from OM_MODetails where MODetailsID  = " + dr2[i]["PODId"].ToString();
                    DataTable dtPodetails = SqlHelper.ExecuteDataset(trans, CommandType.Text, sSQL).Tables[0];

                    //原币含税单价  6位
                    //无税单价      6位
                    //数量          6位
                    //价税合计      2位   原币含税单价 * 数量
                    //无税金额      2位   价税合计 / （1 + 税率） 
                    //税额          2位   价税合计 - 无税金额 
                    //----------------------------------------------------------------------------------------------------------------
                    //税率
                    decimal ipertaxrate = decimal.Round(Convert.ToDecimal(dtPodetails.Rows[0]["iTax"]), 6);
                    //单价(不含税)
                    decimal iUnitCost = decimal.Round(Convert.ToDecimal(dtPodetails.Rows[0]["iUnitPrice"]), 6);
                    //金额(不含税)
                    decimal iPrice = decimal.Round(iUnitCost * decimal.Parse(s2), 6);
                    //原币含税单价
                    decimal iTaxPrice = decimal.Round(Convert.ToDecimal(dtPodetails.Rows[0]["iTaxPrice"]), 6);
                    //原币价税合计
                    decimal iOriSum = decimal.Round(iTaxPrice * decimal.Round(decimal.Parse(s2), 6), 6);
                    //原币无税金额 
                    decimal iOriMoney = decimal.Round(iOriSum / (1 + ipertaxrate / 100), 6);
                    //原币税额 
                    decimal iOriTaxPrice = iOriSum - iOriMoney;

                    sSQL = "update PU_ArrivalVouchs set iOriCost= " + iUnitCost + ",iOriTaxCost = " + iTaxPrice + ",iOriMoney = 0-" + iOriMoney + ",iOriTaxPrice =0- " + iOriTaxPrice + "," +
                                "iOriSum =0- " + iOriSum + ",iCost = " + iUnitCost + ",iMoney =0- " + iOriMoney + ",iTaxPrice =0- " + iOriTaxPrice + ",iSum = 0-" + iOriSum + ",iTaxRate = " + ipertaxrate + " " +
                            " where autoid = " + iIDDetailArr;
                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);

                    if (s1 != "null" && s1 != string.Empty && Convert.ToDouble(s1) != 0)
                    {
                        sSQL = "update PU_ArrivalVouchs set iinvexchrate=cast((" + s2 + "/" + s1 + ")  as decimal(18, 8)),inum=0-" + s1 + " " +
                                        " ,cUnitID = '" + dr2[i]["cAssComUnitCode"].ToString().Trim() + "' " +
                               " where autoid = " + iIDDetailArr;
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);
                    }

                    if (dtPodetails.Rows[0]["citemName"].ToString().Trim() != string.Empty)
                    {

                        sSQL = "update PU_ArrivalVouchs set citem_class='" + dtPodetails.Rows[0]["citem_class"] + "',citemcode='" + dtPodetails.Rows[0]["citemcode"] + "',cItemName='" + dtPodetails.Rows[0]["citemName"] + "' " +
                                " where autoid = " + iIDDetailArr;
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);
                    }

                    sSQL = "update OM_MODetails set iArrQTY  =iArrQTY -  " + s2 + ",iArrNum  =iArrNum - " + s1 + ",iArrMoney  =iArrMoney- " + s2 + "*(iSum /iQuantity )," +
                                "iNatArrMoney  = iNatArrMoney-  " + s1 + " * (iNatSum /iQuantity)   where MODetailsID  = " + dr2[i]["PODId"].ToString();
                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);
                }

                string redRdRecord = GenOMBackToRedRdRecord(trans, iIDArr, ref iCodeBack, ref iIDBack, ref iIDBackDetail);
                returnMsg += "委外退货单:" + sRDCode + "生成红字委外入库单:" + redRdRecord + "\r\n"; ;

            }
        }
        #endregion

        #region 根据采购退货单生成红字采购入库单
        private static string GenPoArriveRedRdRecord(SqlTransaction trans, long iIDArr, ref long iCodeBack, ref long iIDBack, ref long iIDBackDetail)
        {
            string whCode = WHCode;
            string sSQL = "";
            sSQL = @"select  D.Autoid ,
                            D.cInvCode ,
                            D.iQuantity  as iQuantity,
                            D.iNum as iNum,
                            a.cVenCode ,
                            a.cDepCode ,
                            d.iOriCost  ,
                            d.iOriTaxCost ,
                            d.iOriMoney as iOriMoney ,
                            d.iOriTaxPrice as  iOriTaxPrice  ,
                            d.iOriSum  as iOriSum,
                            d.iCost  ,
                            d.iMoney  as iMoney,
                            d.iTaxPrice as iTaxPrice ,
                            d.iSum as iSum ,
                            d.iTaxRate,
                            m.cPOID ,
                            pd.ID as PODId,
                            d.Autoid as PUDId,
                            A.cCode  as PUCode
        
                    from    dbo.PU_ArrivalVouch A
                            left join dbo.PU_ArrivalVouchs D on A.ID = D.ID
                            left join dbo.PO_Podetails PD on d.iposid=pd.id
                            left join dbo.PO_Pomain M on PD.POID = M.POID
                    where   a.ID = '{0}'";
            sSQL = string.Format(sSQL, iIDArr);
            DataTable dtBackDetail = SqlHelper.ExecuteDataset(trans, CommandType.Text, sSQL).Tables[0];

            DataRow[] dr2 = dtBackDetail.Select("1=1");

            iCodeBack += 1;
            string sRDCode = sSetInCode(iCodeBack);
            iIDBack += 1;
            //表头
            sSQL = "insert into rdrecord01(id,brdflag,cvouchtype,cbustype,csource,cwhcode,ddate,ccode,crdcode,cdepcode," +
                        "cptcode,cvencode,cmaker,cdefine7,bpufirst,vt_id,bisstqc,ipurorderid,itaxrate,iexchrate,cexch_name," +
                        "bomfirst,idiscounttaxtype,iswfcontrolled,dnmaketime,dnmodifytime,dnverifytime,bcredit,bredvouch )" +
                    "values (" + iIDBack + ",1,N'01',N'普通采购',N'采购到货单',N'" + whCode + "','" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "',N'" + sRDCode + "',N'101',N'" + dtBackDetail.Rows[0]["cDepCode"].ToString() + "'," +
                        "N'02',N'" + dtBackDetail.Rows[0]["cVenCode"].ToString() + "',N'" + FrameBaseFunction.ClsBaseDataInfo.sUserName.Trim() + "',0,0,27,0," + "null" + ",N'0',1,N'人民币'," +
                        "0,N'0',0, '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "', Null , Null ,N'0',1)";
            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);

            sSQL = "update rdrecord01 set dnverifytime =getdate(),cHandler ='" + FrameBaseFunction.ClsBaseDataInfo.sUserName.Trim() + "',dVeriDate =getdate() ," +
                " cOrderCode ='" + dtBackDetail.Rows[0]["cPOID"].ToString() + "',cARVCode ='" + dtBackDetail.Rows[0]["PUCode"].ToString() + "'" +
                " where id=" + iIDBack;
            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);

            for (int i = 0; i < dr2.Length; i++)
            {
                iIDBackDetail += 1;

                string s1 = "null";
                if (dr2[i]["iNum"].ToString().Trim() != string.Empty)
                    s1 = dr2[i]["iNum"].ToString().Trim();

                string s2 = "null";
                if (dr2[i]["iQuantity"].ToString().Trim() != string.Empty)
                    s2 = dr2[i]["iQuantity"].ToString().Trim();


                sSQL = "Insert Into rdrecords01(autoid,id,cinvcode,inum,iquantity," +
                            "isquantity,isnum,imoney,cdefine26,cdefine27,inquantity,innum," +
                            "btaxcost," +
                            "iprocesscost,iprocessfee,iomodid,iOMoMID," +
                            "bcosting,iinvexchrate,iexpiratdatecalcu,isotype,comcode,cMainInvCode," +
                            "iUnitCost,iPrice,iAPrice,iPoSId,fACost," +
                            "iArrsID,iOriTaxCost ,iOriCost,iOriMoney," +
                            "iOriTaxPrice,iOriSum,iTaxRate,iTaxPrice,iSum,cPOID" +
                            " ) " +
                        "Values (" + iIDBackDetail + "," + iIDBack + ",N'" + dr2[i]["cInvcode"].ToString().Trim() + "'," + s1 + "," + s2 +
                            ",0,0,0,0,0," + "0" + "," + "0" + "," +
                            "1" +
                            ",0,0," + "null" + "," + "null" + "," +
                            "1,null,0,null,null,'" + dr2[i]["cInvCode"].ToString().Trim() + "'," +
                            dr2[i]["iOriCost"].ToString().Trim() + "," + dr2[i]["iOriSum"].ToString().Trim() + "," + dr2[i]["iOriSum"].ToString().Trim() + "," + dr2[i]["PODId"].ToString().Trim() + "," + dr2[i]["iOriTaxCost"].ToString().Trim() + "," +
                            dr2[i]["PUDId"].ToString().Trim() + "," + dr2[i]["iOriTaxCost"].ToString().Trim() + "," + dr2[i]["iOriCost"].ToString().Trim() + "," + dr2[i]["iOriMoney"].ToString().Trim() + "," +
                            dr2[i]["iOriTaxPrice"].ToString().Trim() + "," + dr2[i]["iOriSum"].ToString().Trim() + "," + dr2[i]["iTaxRate"].ToString().Trim() + "," + dr2[i]["iOriTaxPrice"].ToString().Trim() + "," + dr2[i]["iSum"].ToString().Trim() + ",'" + dr2[i]["cPOID"].ToString().Trim() + "')";
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);

                sSQL = "update rdrecords01 set cAssUnit = i.cAssComUnitCode from inventory i where i.cinvcode = rdrecords01.cinvcode and rdrecords01.autoid = " + iIDBackDetail;
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);

                sSQL = "update PU_ArrivalVouchs set fValidInQuan  =fValidInQuan+ " + s2 + " where Autoid=" + dr2[i]["PUDId"].ToString().Trim();
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);

                sSQL = "select * from PU_ArrivalVouchs where Autoid = " + dr2[i]["PUDId"].ToString().Trim();
                DataTable dtPodetails = SqlHelper.ExecuteDataset(trans, CommandType.Text, sSQL).Tables[0];
                if (dtPodetails.Rows[0]["citemName"].ToString().Trim() != string.Empty)
                {
                    sSQL = "update rdrecords01 set citem_class='" + dtPodetails.Rows[0]["citem_class"] + "',citemcode='" + dtPodetails.Rows[0]["citemName"] + "',cname='" + dtPodetails.Rows[0]["citemName"] + "',citemcname='外销订单项目' " +
                           " where autoid = " + iIDBackDetail;
                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);
                }

                //////现存量

                if (s1 == "null")
                {
                    sSQL = "if exists(select * from  CurrentStock where cInvCode = '" + dr2[i]["cInvcode"].ToString().Trim() + "' and cWhCode = '" + whCode + "') " +
                  "	update  CurrentStock set iQuantity = isnull(iQuantity,0) " + s2 + "  where cInvCode = '" + dr2[i]["cInvcode"].ToString().Trim() + "' and cWhCode = '" + whCode + "' " +
                          "else " +
                              "begin " +
                              "    declare @itemid varchar(20); " +
                              "declare @iCount int;  " +
                                "select @iCount=count(itemid) from CurrentStock where cInvCode = '" + dr2[i]["cInvcode"].ToString().Trim() + "';   " +
                                "if( @iCount > 0 ) " +
                                "	select @itemid=itemid from CurrentStock where cInvCode = '" + dr2[i]["cInvcode"].ToString().Trim() + "';  " +
                                "else  " +
                                "	 select @itemid=max(itemid+1) from CurrentStock  " +
                              "    insert into CurrentStock(cWhCode,cInvCode,iQuantity,itemid)values('" + whCode + "','" + dr2[i]["cInvcode"].ToString().Trim() + "'," + s2 + ",@itemid) " +
                              "end";

                }
                else
                {
                    sSQL = "if exists(select * from  CurrentStock where cInvCode = '" + dr2[i]["cInvcode"].ToString().Trim() + "' and cWhCode = '" + whCode + "') " +
                    "	update  CurrentStock set iQuantity = isnull(iQuantity,0)  " + s2 + ",iNum = isnull(iNum,0) " + s1 + "  where cInvCode = '" + dr2[i]["cInvcode"].ToString().Trim() + "' and cWhCode = '" + whCode + "' " +
                            "else " +
                                "begin " +
                                "    declare @itemid varchar(20); " +
                              "declare @iCount int;  " +
                                "select @iCount=count(itemid) from CurrentStock where cInvCode = '" + dr2[i]["cInvcode"].ToString().Trim() + "';   " +
                                "if( @iCount > 0 ) " +
                                "	select @itemid=itemid from CurrentStock where cInvCode = '" + dr2[i]["cInvcode"].ToString().Trim() + "';  " +
                                "else  " +
                                "	 select @itemid=max(itemid+1) from CurrentStock  " +
                                "    insert into CurrentStock(cWhCode,cInvCode,iQuantity,iNum,itemid)values('" + whCode + "','" + dr2[i]["cInvcode"].ToString().Trim() + "'," + s2 + "," + s1 + ",@itemid) " +
                                "end";
                }
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);
            }

            return sRDCode;


        }
        #endregion


        #region 根据采购订单直接生成红字采购入库单
        private static string GenPoRedRdRecord(SqlTransaction trans, DataRow[] sourceRows, ref long iCodeBack, ref long iIDBack, ref long iIDBackDetail)
        {
            string whCode = WHCode;
            string sSQL = "";


            sSQL = @"select  pd.ID as Autoid ,
                            pd.cInvCode as  cInvCode ,
                            pd.iQuantity as  iQuantity ,
                            pd.iNum  as  iNum ,
                            m.cVenCode   cVenCode ,
                            m.cDepCode  cDepCode ,
                            iUnitPrice as  iOriCost ,
                            iTax  as iOriTaxCost ,
                            iMoney   as iOriMoney ,
                            iSum as iOriSum ,
                            iSum -iMoney  as iOriTaxPrice ,
                            iNatUnitPrice  as iCost ,
                            iNatMoney as iMoney ,
                            iNatTax as iTaxPrice ,
                            iNatSum as iSum ,
                            iPerTaxRate  as iTaxRate ,
                            m.cPOID ,
                            pd.ID as PODId 
                    from   
                            dbo.PO_Podetails PD 
                            left join dbo.PO_Pomain M on PD.POID = M.POID
                    where   PD.ID = '{0}'";

            sSQL = string.Format(sSQL, sourceRows[0]["PODID"].ToString());

            DataTable dtBackDetail = SqlHelper.ExecuteDataset(trans, CommandType.Text, sSQL).Tables[0];


            iCodeBack += 1;
            string sRDCode = sSetInCode(iCodeBack);

            iIDBack += 1;
            //表头
            sSQL = "insert into rdrecord01(id,brdflag,cvouchtype,cbustype,csource,cwhcode,ddate,ccode,crdcode,cdepcode," +
                        "cptcode,cvencode,cmaker,cdefine7,bpufirst,vt_id,bisstqc,ipurorderid,itaxrate,iexchrate,cexch_name," +
                        "bomfirst,idiscounttaxtype,iswfcontrolled,dnmaketime,dnmodifytime,dnverifytime,bcredit,bredvouch )" +
                    "values (" + iIDBack + ",1,N'01',N'普通采购',N'采购到货单',N'" + whCode + "','" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "',N'" + sRDCode + "',N'101',N'" + dtBackDetail.Rows[0]["cDepCode"].ToString() + "'," +
                        "N'02',N'" + dtBackDetail.Rows[0]["cVenCode"].ToString() + "',N'" + FrameBaseFunction.ClsBaseDataInfo.sUserName.Trim() + "',0,0,27,0," + "null" + ",N'0',1,N'人民币'," +
                        "0,N'0',0, '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "', Null , Null ,N'0',1)";
            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);

            sSQL = "update  rdrecord01 set dnverifytime =getdate(),cHandler ='" + FrameBaseFunction.ClsBaseDataInfo.sUserName.Trim() + "',dVeriDate =getdate() ," +
                " cOrderCode ='" + dtBackDetail.Rows[0]["cPOID"].ToString() + "',cARVCode =null" +
                " where id=" + iIDBack;
            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);

            for (int i = 0; i < sourceRows.Length; i++)
            {
                sSQL = @"select  pd.ID as Autoid ,
                            pd.cInvCode as  cInvCode ,
                            pd.iQuantity as  iQuantity ,
                            pd.iNum  as  iNum ,
                            (case when isnull(pd.iNum,0) =0 then 0 else pd.iQuantity /pd.iNum end ) as Rate,
                            m.cVenCode   cVenCode ,
                            m.cDepCode  cDepCode ,
                            iUnitPrice  ,
                            iTax   ,
                            iMoney    ,
                            iSum  ,
                            iSum -iMoney  as iOriTaxPrice ,
                            iNatUnitPrice   ,
                            iNatMoney  ,
                            iNatTax  ,
                            iNatSum  ,
                            iPerTaxRate   ,
                            m.cPOID ,
                            pd.ID as PODId ,
                            PD.iTaxPrice
                    from   
                            dbo.PO_Podetails PD 
                            left join dbo.PO_Pomain M on PD.POID = M.POID
                    where   PD.ID = '{0}'";

                sSQL = string.Format(sSQL, sourceRows[i]["PODID"].ToString());

                DataTable dtSource = SqlHelper.ExecuteDataset(trans, CommandType.Text, sSQL).Tables[0];
                iIDBackDetail += 1;
                string s1 = "null";
                decimal rate = 0;

                string s2 = "null";
                if (sourceRows[i]["BackQty"].ToString() != string.Empty)
                {
                    s2 = "-" + sourceRows[i]["BackQty"].ToString();
                    if (decimal.Parse(dtSource.Rows[0]["Rate"].ToString()) > 0)
                    {
                        rate = decimal.Parse(dtSource.Rows[0]["Rate"].ToString());
                        s1 = "-" + Math.Round(decimal.Parse(sourceRows[i]["BackQty"].ToString()) / rate, 4);
                    }

                }

                decimal unitPrice = decimal.Round(decimal.Parse(dtSource.Rows[0]["iUnitPrice"].ToString()), 6);//原币无税单价
                decimal oriPrice = decimal.Round(decimal.Parse(dtSource.Rows[0]["iTaxPrice"].ToString()), 6);//原币含税单价
                decimal natunitPrice = decimal.Round(decimal.Parse(dtSource.Rows[0]["iNatUnitPrice"].ToString()), 6);//本币无税单价
                decimal natPrice = decimal.Round(decimal.Parse(dtSource.Rows[0]["iNatUnitPrice"].ToString()) * (1 + decimal.Parse(dtSource.Rows[0]["iPerTaxRate"].ToString()) / 100), 6); //本币含税单价

                decimal oriMoney = decimal.Round(decimal.Parse(s2) * oriPrice, 2); //原币含税金额
                decimal oriUMonety = decimal.Round(decimal.Parse(s2) * unitPrice, 2); //原币无税金额
                decimal oriTaxAmount = decimal.Round(decimal.Parse(s2) * (oriPrice - unitPrice), 2);//原币税额
                decimal natMoney = decimal.Round(decimal.Parse(s2) * natPrice, 2); //本币含税金额
                decimal natTaxAmount = decimal.Round(decimal.Parse(s2) * (natPrice - natunitPrice), 2);//原币税额


                sSQL = "Insert Into rdrecords01(autoid,id,cinvcode,inum,iquantity," +
                            "isquantity,isnum,imoney,cdefine26,cdefine27,inquantity,innum," +
                            "btaxcost," +
                            "iprocesscost,iprocessfee,iomodid,iOMoMID," +
                            "bcosting,iinvexchrate,iexpiratdatecalcu,isotype,comcode,invcode," +
                            "iUnitCost,iPrice,iAPrice,iPoSId,fACost," +
                            "iArrsID,iOriTaxCost ,iOriCost,iOriMoney," +
                            "iOriTaxPrice,iOriSum,iTaxRate,iTaxPrice,iSum,cPOID" +
                            " ) " +
                        "Values (" + iIDBackDetail + "," + iIDBack + ",N'" + dtSource.Rows[0]["cInvcode"].ToString().Trim() + "'," + s1 + "," + s2 +
                            ",0,0,0,0,0," + "0" + "," + "0" + "," +
                            "1" +
                            ",0,0," + "null" + "," + "null" + "," +
                            "1,null,0,null,null,'" + dtSource.Rows[0]["cInvCode"].ToString() + "'," +
                             oriPrice + "," + oriMoney + "," + oriMoney + "," + dtSource.Rows[0]["PODId"].ToString() + "," + oriMoney + "," +
                            "null" + "," + oriPrice + "," + unitPrice + "," + oriUMonety + "," +
                           oriTaxAmount + "," + oriMoney + "," + dtSource.Rows[0]["iPerTaxRate"].ToString() + "," + natTaxAmount + "," + oriMoney
                           + ",'" + dtSource.Rows[0]["cPOID"].ToString() + "')";

                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);

                sSQL = "update rdrecords01 set cAssUnit = i.cAssComUnitCode from inventory i where i.cinvcode = rdrecords01.cinvcode and rdrecords01.autoid = " + iIDBackDetail;
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);

                sSQL = "update PO_Podetails  set iReceivedQTY   =iReceivedQTY + " + s2 + " where id=" + dtSource.Rows[0]["PODId"].ToString().Trim();
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);


                sSQL = "select * from PO_Podetails where id = " + dtSource.Rows[0]["PODId"].ToString().Trim();
                DataTable dtPodetails = SqlHelper.ExecuteDataset(trans, CommandType.Text, sSQL).Tables[0];

                if (dtPodetails.Rows[0]["citemName"].ToString().Trim() != string.Empty)
                {
                    sSQL = "update rdrecords01 set citem_class='" + dtPodetails.Rows[0]["citem_class"] + "',citemcode='" + dtPodetails.Rows[0]["citemName"] + "',cname='" + dtPodetails.Rows[0]["citemName"] + "',citemcname='外销订单项目' " +
                           " where autoid = " + iIDBackDetail;
                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);
                }

                //////现存量

                if (s1 == "null")
                {
                    sSQL = "if exists(select * from  CurrentStock where cInvCode = '" + dtSource.Rows[0]["cInvcode"].ToString().Trim() + "' and cWhCode = '" + whCode + "') " +
                  "	update  CurrentStock set iQuantity = isnull(iQuantity,0) " + s2 + "  where cInvCode = '" + dtSource.Rows[0]["cInvcode"].ToString().Trim() + "' and cWhCode = '" + whCode + "' " +
                          "else " +
                              "begin " +
                              "    declare @itemid varchar(20); " +
                              "declare @iCount int;  " +
                                "select @iCount=count(itemid) from CurrentStock where cInvCode = '" + dtSource.Rows[0]["cInvcode"].ToString().Trim() + "';   " +
                                "if( @iCount > 0 ) " +
                                "	select @itemid=itemid from CurrentStock where cInvCode = '" + dtSource.Rows[0]["cInvcode"].ToString().Trim() + "';  " +
                                "else  " +
                                "	 select @itemid=max(itemid+1) from CurrentStock  " +
                              "    insert into CurrentStock(cWhCode,cInvCode,iQuantity,itemid)values('" + whCode + "','" + dtSource.Rows[0]["cInvcode"].ToString().Trim() + "'," + s2 + ",@itemid) " +
                              "end";

                }
                else
                {
                    sSQL = "if exists(select * from  CurrentStock where cInvCode = '" + dtSource.Rows[0]["cInvcode"].ToString().Trim() + "' and cWhCode = '" + whCode + "') " +
                    "	update  CurrentStock set iQuantity = isnull(iQuantity,0)  " + s2 + ",iNum = isnull(iNum,0) " + s1 + "  where cInvCode = '" + dtSource.Rows[0]["cInvcode"].ToString().Trim() + "' and cWhCode = '" + whCode + "' " +
                            "else " +
                                "begin " +
                                "    declare @itemid varchar(20); " +
                              "declare @iCount int;  " +
                                "select @iCount=count(itemid) from CurrentStock where cInvCode = '" + dtSource.Rows[0]["cInvcode"].ToString().Trim() + "';   " +
                                "if( @iCount > 0 ) " +
                                "	select @itemid=itemid from CurrentStock where cInvCode = '" + dtSource.Rows[0]["cInvcode"].ToString().Trim() + "';  " +
                                "else  " +
                                "	 select @itemid=max(itemid+1) from CurrentStock  " +
                                "    insert into CurrentStock(cWhCode,cInvCode,iQuantity,iNum,itemid)values('" + whCode + "','" + dtSource.Rows[0]["cInvcode"].ToString().Trim() + "'," + s2 + "," + s1 + ",@itemid) " +
                                "end";
                }
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);
            }

            return sRDCode;
        }
        #endregion


        #region 根据委外订单直接生成红字采购入库单
        public static void GenOMFormRedRdRecord(SqlTransaction trans, DataTable dtPuBack, ref long iCodeBack, ref long iIDBack, ref long iIDBackDetail, out  string returnMsg)
        {
            returnMsg = "";

            string whCode = WHCode;
            string sSQL = "";

            Dictionary<string, string> venLists = new Dictionary<string, string>();

            foreach (DataRow row in dtPuBack.Rows)
            {
                string venCode = row["VenCode"].ToString();
                if (!venLists.ContainsKey(venCode))
                {
                    venLists.Add(venCode, "");
                }
            }


            foreach (KeyValuePair<string, string> item in venLists)
            {
                DataRow[] dr2 = dtPuBack.Select("ReceiveQty>0 and VenCode ='" + item.Key + "'");
                if (dr2.Length == 0)
                    continue;

                sSQL = @"select  o.cVenCode ,
                                o.cDepCode
                          from    dbo.OM_MODetails D
                                left join dbo.OM_MOMain O on D.MOID = O.MOID
                          where   d.MODetailsID = {0}";


                sSQL = string.Format(sSQL, dr2[0]["PODID"].ToString());
                DataTable dtPODetail = SqlHelper.ExecuteDataset(trans, CommandType.Text, sSQL).Tables[0];

                iCodeBack += 1;

                string sRDCode = sSetInCode(iCodeBack);
                returnMsg += "委外定单直接生成红字采购入库单:" + sRDCode + "\r\n";

                iIDBack += 1;
                //表头
                sSQL = "insert into rdrecord01(id,brdflag,cvouchtype,cbustype,csource,cwhcode,ddate,ccode,crdcode,cdepcode," +
                            "cptcode,cvencode,cmaker,cdefine7,bpufirst,vt_id,bisstqc,ipurorderid,itaxrate,iexchrate,cexch_name," +
                            "bomfirst,idiscounttaxtype,iswfcontrolled,dnmaketime,dnmodifytime,dnverifytime,bcredit,bredvouch )" +
                        "values (" + iIDBack + ",1,N'01',N'委外加工',N'委外订单',N'" + whCode + "','"
                        + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "',N'" + sRDCode + "',N'211',N'" + dtPODetail.Rows[0]["cDepCode"].ToString() + "',"
                        + "N'02',N'" + dtPODetail.Rows[0]["cVenCode"].ToString() + "',N'" + FrameBaseFunction.ClsBaseDataInfo.sUserName.Trim() + "',0,0,27,0," + "null" + ",N'0',1,N'人民币'," +
                            "0,N'0',0, '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "', Null , Null ,N'0',1)";
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);

                for (int i = 0; i < dr2.Length; i++)
                {

                    sSQL = @"select D.*,m.cCode from OM_MODetails  D
                                left join OM_MOMain M on D.MOID = M.MOID  where D.MODetailsID= " + dr2[i]["PODId"].ToString();
                    DataTable dtPodetails = SqlHelper.ExecuteDataset(trans, CommandType.Text, sSQL).Tables[0];

                    string s1 = "null";
                    if (dtPodetails.Rows[0]["iNum"].ToString() != "" && dtPodetails.Rows[0]["iNum"].ToString() != "0")
                    {
                        decimal cRate = decimal.Parse(dtPodetails.Rows[0]["iQuantity"].ToString()) / decimal.Parse(dtPodetails.Rows[0]["iNum"].ToString());
                        s1 = (decimal.Parse(dr2[i]["BackQty"].ToString().Trim()) * cRate).ToString();
                    }
                    string s2 = "null";
                    if (dr2[i]["BackQty"].ToString().Trim() != string.Empty)
                        s2 = dr2[i]["BackQty"].ToString().Trim();

                    //原币含税单价  6位
                    //无税单价      6位
                    //数量          6位
                    //价税合计      2位   原币含税单价 * 数量
                    //无税金额      2位   价税合计 / （1 + 税率） 
                    //税额          2位   价税合计 - 无税金额 
                    //----------------------------------------------------------------------------------------------------------------

                    //税率
                    decimal ipertaxrate = decimal.Round(Convert.ToDecimal(dtPodetails.Rows[0]["iTax"]), 2);
                    //单价(不含税)
                    decimal iUnitCost = decimal.Round(Convert.ToDecimal(dtPodetails.Rows[0]["iUnitPrice"]), 6);
                    //金额(不含税)
                    decimal iPrice = decimal.Round(iUnitCost * decimal.Parse(s2), 2);
                    //原币含税单价
                    decimal iTaxPrice = decimal.Round(Convert.ToDecimal(dtPodetails.Rows[0]["iTaxPrice"]), 6);
                    //原币价税合计
                    decimal iOriSum = decimal.Round(iTaxPrice * decimal.Round(decimal.Parse(s2), 6), 2);
                    //原币无税金额 
                    decimal iOriMoney = decimal.Round(iOriSum / (1 + ipertaxrate / 100), 2);
                    //原币税额 
                    decimal iOriTaxPrice = iOriSum - iOriMoney;

                    iIDBackDetail += 1;


                    sSQL = "Insert Into rdrecords01(autoid,id,cinvcode,inum,iquantity," +
                                "isquantity,isnum,imoney,cdefine26,cdefine27,inquantity,innum," +
                                "btaxcost,cpoid," +
                                "iprocesscost,iprocessfee,iomodid,iOMoMID," +
                                "bcosting,iinvexchrate,corufts,iexpiratdatecalcu,isotype,comcode,invcode," +
                                "iUnitCost,iPrice,iAPrice,iPoSId,fACost," +
                                "iArrsID,iOriTaxCost ,iOriCost,iOriMoney," +
                                "iOriTaxPrice,iOriSum,iTaxRate,iTaxPrice,iSum" +
                                " ) " +
                            "Values (" + iIDBackDetail + "," + iIDBack + ",N'" + dtPodetails.Rows[0]["cInvcode"].ToString().Trim() + "',0-" + s1 + ",0-" + s2 +
                                ",0,0,0,0,0," + "0" + "," + "0" + "," +
                                "1,N'" + dtPodetails.Rows[0]["cCode"].ToString() + "'," +
                                "0,0," + dtPodetails.Rows[0]["MODetailsID"].ToString() + "," + "null" + "," +
                                 "1,0,N'1610.3418',0,0,'" + "" + "','" + "" + "'," +
                                iTaxPrice + "," + iOriSum + "," + iOriSum + "," + "null" + "," + iTaxPrice + "," +
                                "null" + "," + iTaxPrice + "," + iUnitCost + "," + iOriMoney + "," +
                                iOriTaxPrice + "," + iOriSum + "," + ipertaxrate + "," + iOriTaxPrice + "," + iOriSum +
                               ")";
                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);

                    sSQL = "update rdrecords01 set cAssUnit = i.cAssComUnitCode from inventory i where i.cinvcode = rdrecords01.cinvcode and rdrecords01.autoid = " + iIDBackDetail;
                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);

                    sSQL = "update OM_MODetails set iReceivedQTY =iReceivedQTY-" + s2 + ",iReceivedNum=iReceivedNum-" + s1 + ",iReceivedMoney=iReceivedMoney-" + iOriSum + " where MODetailsID=" + dr2[i]["PODId"].ToString();
                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);
                    //////现存量

                    if (s1 == "null")
                    {
                        sSQL = "if exists(select * from  CurrentStock where cInvCode = '" + dtPodetails.Rows[0]["cInvcode"].ToString().Trim() + "' and cWhCode = '" + whCode + "') " +
                      "	update  CurrentStock set iQuantity = isnull(iQuantity,0) - " + s2 + "  where cInvCode = '" + dtPodetails.Rows[0]["cInvcode"].ToString().Trim() + "' and cWhCode = '" + whCode + "' " +
                              "else " +
                                  "begin " +
                                  "    declare @itemid varchar(20); " +
                                  "declare @iCount int;  " +
                                    "select @iCount=count(itemid) from CurrentStock where cInvCode = '" + dtPodetails.Rows[0]["cInvcode"].ToString().Trim() + "';   " +
                                    "if( @iCount > 0 ) " +
                                    "	select @itemid=itemid from CurrentStock where cInvCode = '" + dtPodetails.Rows[0]["cInvcode"].ToString().Trim() + "';  " +
                                    "else  " +
                                    "	 select @itemid=max(itemid+1) from CurrentStock  " +
                                  "    insert into CurrentStock(cWhCode,cInvCode,iQuantity,itemid)values('" + whCode + "','" + dtPodetails.Rows[0]["cInvcode"].ToString().Trim() + "'," + s2 + ",@itemid) " +
                                  "end";

                    }
                    else
                    {
                        sSQL = "if exists(select * from  CurrentStock where cInvCode = '" + dtPodetails.Rows[0]["cInvcode"].ToString().Trim() + "' and cWhCode = '" + whCode + "') " +
                        "	update  CurrentStock set iQuantity = isnull(iQuantity,0) - " + s2 + ",iNum = isnull(iNum,0) - " + s1 + "  where cInvCode = '" + dtPodetails.Rows[0]["cInvcode"].ToString().Trim() + "' and cWhCode = '" + whCode + "' " +
                                "else " +
                                    "begin " +
                                    "    declare @itemid varchar(20); " +
                                  "declare @iCount int;  " +
                                    "select @iCount=count(itemid) from CurrentStock where cInvCode = '" + dtPodetails.Rows[0]["cInvcode"].ToString().Trim() + "';   " +
                                    "if( @iCount > 0 ) " +
                                    "	select @itemid=itemid from CurrentStock where cInvCode = '" + dtPodetails.Rows[0]["cInvcode"].ToString().Trim() + "';  " +
                                    "else  " +
                                    "	 select @itemid=max(itemid+1) from CurrentStock  " +
                                    "    insert into CurrentStock(cWhCode,cInvCode,iQuantity,iNum,itemid)values('" + whCode + "','" + dtPodetails.Rows[0]["cInvcode"].ToString().Trim() + "'," + s2 + "," + s1 + ",@itemid) " +
                                    "end";
                    }
                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);
                }
            }


        }
        #endregion



        #region 根据委外退货单生成红字采购入库单
        private static string GenOMBackToRedRdRecord(SqlTransaction trans, long iIDArr, ref long iCodeBack, ref long iIDBack, ref long iIDBackDetail)
        {
            aList.Clear();
            string whCode = WHCode;
            string sSQL = "";

            sSQL = @"
                    select  D.Autoid ,
                            D.cInvCode ,
                            D.iQuantity ,
                            D.iNum ,
                            a.cVenCode ,
                            a.cDepCode ,
                            d.iOriCost ,
                            d.iOriTaxCost ,
                            d.iOriMoney ,
                            d.iOriTaxPrice ,
                            d.iOriSum ,
                            d.iCost ,
                            d.iMoney ,
                            d.iTaxPrice ,
                            d.iSum ,
                            d.iTaxRate ,
                            m.cCode  as cPOID ,
                            pd.MODetailsID as PODId ,
                            d.Autoid as PUDId,
                            A.cCode as ArrCode,
                            M.cCode as OrderCode
                    from    dbo.PU_ArrivalVouch A
                            left join dbo.PU_ArrivalVouchs D on A.ID = D.ID
                            left join dbo.OM_MODetails PD on d.iposid = pd.MODetailsID
                            left join dbo.OM_MOMain M on  pd.MOID = M.MOID 
                    where   a.ID = '{0}'";
            sSQL = string.Format(sSQL, iIDArr);
            DataTable dtBackDetail = SqlHelper.ExecuteDataset(trans, CommandType.Text, sSQL).Tables[0];

            DataRow[] dr2 = dtBackDetail.Select("1=1");

            iCodeBack += 1;
            string sRDCode = sSetInCode(iCodeBack);
            iIDBack += 1;
            //表头
            sSQL = "insert into rdrecord01(id,brdflag,cvouchtype,cbustype,csource,cwhcode,ddate,ccode,crdcode,cdepcode," +
                        "cptcode,cvencode,cmaker,cdefine7,bpufirst,vt_id,bisstqc,ipurorderid,itaxrate,iexchrate,cexch_name," +
                        "bomfirst,idiscounttaxtype,iswfcontrolled,dnmaketime,dnmodifytime,dnverifytime,bcredit,bredvouch,cOrderCode,cARVCode )" +
                    "values (" + iIDBack + ",1,N'01',N'委外加工',N'委外到货单',N'" + whCode + "','" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "',N'" + sRDCode + "',N'211',N'" + dtBackDetail.Rows[0]["cDepCode"].ToString() + "'," +
                        "N'02',N'" + dtBackDetail.Rows[0]["cVenCode"].ToString() + "',N'" + FrameBaseFunction.ClsBaseDataInfo.sUserName.Trim() + "',0,0,27,0," + "null" + ",N'0',1,N'人民币'," +
                        "0,N'0',0, '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "', Null , Null ,N'0',1,'" + dtBackDetail.Rows[0]["OrderCode"].ToString() + "','" + dtBackDetail.Rows[0]["ArrCode"].ToString() + "'" +
                        ")";
            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);

            for (int i = 0; i < dr2.Length; i++)
            {
                iIDBackDetail += 1;

                string s1 = "null";
                if (dr2[i]["iNum"].ToString().Trim() != string.Empty)
                    s1 = dr2[i]["iNum"].ToString().Trim();

                string s2 = "null";
                if (dr2[i]["iQuantity"].ToString().Trim() != string.Empty)
                    s2 = dr2[i]["iQuantity"].ToString().Trim();

                sSQL = "Insert Into rdrecords01(autoid,id,cinvcode,inum,iquantity," +
                            "isquantity,isnum,imoney,cdefine26,cdefine27,inquantity,innum," +
                            "btaxcost," +
                            "iprocesscost,iprocessfee,iOMoDID ,iOMoMID ," +
                            "bcosting,iinvexchrate,corufts,iexpiratdatecalcu,isotype,comcode,invcode," +
                            "iUnitCost,iPrice,iAPrice,iPoSId,fACost," +
                            "iArrsID,iOriTaxCost ,iOriCost,iOriMoney," +
                            "iOriTaxPrice,iOriSum,iTaxRate,iTaxPrice,iSum,cPOID" +
                            " ) " +
                        "Values (" + iIDBackDetail + "," + iIDBack + ",N'" + dr2[i]["cInvcode"].ToString().Trim() + "'," + s1 + "," + s2 +
                            ",0,0,0,0,0," + "0" + "," + "0" + "," +
                            "1," +
                            "0,0,'" + dr2[i]["PODId"].ToString().Trim() + "'," + "null" + "," +
                            "1,0,N'1610.3418',0,0,'" + "" + "','" + "" + "'," +
                            dr2[i]["iOriTaxCost"].ToString().Trim() + "," + dr2[i]["iOriSum"].ToString().Trim() + "," + dr2[i]["iOriSum"].ToString().Trim() + "," + dr2[i]["PODId"].ToString().Trim() + "," + dr2[i]["iOriTaxCost"].ToString().Trim() + "," +
                            dr2[i]["PUDId"].ToString().Trim() + "," + dr2[i]["iOriTaxCost"].ToString().Trim() + "," + dr2[i]["iOriCost"].ToString().Trim() + "," + dr2[i]["iOriMoney"].ToString().Trim() + "," +
                            dr2[i]["iOriTaxPrice"].ToString().Trim() + "," + dr2[i]["iOriSum"].ToString().Trim() + "," + dr2[i]["iTaxRate"].ToString().Trim() + "," + dr2[i]["iTaxPrice"].ToString().Trim() + "," + dr2[i]["iSum"].ToString().Trim() + ",'" + dr2[i]["cPOID"].ToString().Trim() + "'" +
                            ")";
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);

                sSQL = "update rdrecords01 set cAssUnit = i.cAssComUnitCode from inventory i where i.cinvcode = rdrecords01.cinvcode and rdrecords01.autoid = " + iIDBackDetail;
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);

                sSQL = "update PU_ArrivalVouchs set fValidInQuan =isnull(fValidInQuan,0)" + s2 + " where Autoid=" + dr2[i]["PUDId"].ToString().Trim();
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);

                //////现存量

                if (s1 == "null")
                {
                    sSQL = "if exists(select * from  CurrentStock where cInvCode = '" + dr2[i]["cInvcode"].ToString().Trim() + "' and cWhCode = '" + whCode + "') " +
                  "	update  CurrentStock set iQuantity = isnull(iQuantity,0)+ " + s2 + "  where cInvCode = '" + dr2[i]["cInvcode"].ToString().Trim() + "' and cWhCode = '" + whCode + "' " +
                          "else " +
                              "begin " +
                              "    declare @itemid varchar(20); " +
                              "declare @iCount int;  " +
                                "select @iCount=count(itemid) from CurrentStock where cInvCode = '" + dr2[i]["cInvcode"].ToString().Trim() + "';   " +
                                "if( @iCount > 0 ) " +
                                "	select @itemid=itemid from CurrentStock where cInvCode = '" + dr2[i]["cInvcode"].ToString().Trim() + "';  " +
                                "else  " +
                                "	 select @itemid=max(itemid+1) from CurrentStock  " +
                              "    insert into CurrentStock(cWhCode,cInvCode,iQuantity,itemid)values('" + whCode + "','" + dr2[i]["cInvcode"].ToString().Trim() + "'," + s2 + ",@itemid) " +
                              "end";

                }
                else
                {
                    sSQL = "if exists(select * from  CurrentStock where cInvCode = '" + dr2[i]["cInvcode"].ToString().Trim() + "' and cWhCode = '" + whCode + "') " +
                    "	update  CurrentStock set iQuantity = isnull(iQuantity,0) +" + s2 + ",iNum = isnull(iNum,0) + " + s1 + "  where cInvCode = '" + dr2[i]["cInvcode"].ToString().Trim() + "' and cWhCode = '" + whCode + "' " +
                            "else " +
                                "begin " +
                                "    declare @itemid varchar(20); " +
                              "declare @iCount int;  " +
                                "select @iCount=count(itemid) from CurrentStock where cInvCode = '" + dr2[i]["cInvcode"].ToString().Trim() + "';   " +
                                "if( @iCount > 0 ) " +
                                "	select @itemid=itemid from CurrentStock where cInvCode = '" + dr2[i]["cInvcode"].ToString().Trim() + "';  " +
                                "else  " +
                                "	 select @itemid=max(itemid+1) from CurrentStock  " +
                                "    insert into CurrentStock(cWhCode,cInvCode,iQuantity,iNum,itemid)values('" + whCode + "','" + dr2[i]["cInvcode"].ToString().Trim() + "'," + s2 + "," + s1 + ",@itemid) " +
                                "end";
                }
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);
            }


            return sRDCode;
        }
        #endregion

        #region 根据物料产生形态转换单
        public static string GenInvChange(SqlTransaction trans, string beforInvCode, string afterInvCode, string beforQty, string afterQty, string afterWHCode)
        {
            aList.Clear();
            string whCode = WHCode;
            string sSQL = "";
            long iCodeBack = 0;


            long iIDBack = 0;
            long iIDBackDetail = 0;

            GetID("as", out iIDBack, out iIDBackDetail);
            sSQL = "select isnull(max(cNumber),0) as Maxnumber From VoucherHistory  with (NOLOCK) Where  CardNumber='0305' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "')";
            DataTable dtCodeBack = SqlHelper.ExecuteDataset(trans, CommandType.Text, sSQL).Tables[0];
            iCodeBack = Convert.ToInt64(dtCodeBack.Rows[0]["Maxnumber"]);

            iCodeBack += 1;

            string sRDCode = sSetInvChangeCode(iCodeBack);
            iIDBack += 1;
            //表头
            sSQL = @"
            insert  into AssemVouch
                    ( cavcode ,
                      cvouchtype ,
                      caccpcode ,
                      davdate ,
                      cdepcode ,
                      cpersoncode ,
                      cirdcode ,
                      cordcode ,
                      iavexpense ,
                      cavmemo ,
                      caccounter ,
                      cmaker ,
                      cdefine1 ,
                      cdefine2 ,
                      cdefine3 ,
                      cdefine4 ,
                      cdefine5 ,
                      cdefine6 ,
                      cdefine7 ,
                      cdefine8 ,
                      cdefine9 ,
                      cdefine10 ,
                      id ,
                      btransflag ,
                      vt_id ,
                      cverifyperson ,
                      dverifydate ,
                      cdefine11 ,
                      cdefine12 ,
                      cdefine13 ,
                      cdefine14 ,
                      cdefine15 ,
                      cdefine16 ,
                      cmodifyperson ,
                      dmodifydate ,
                      dnmaketime ,
                      dnmodifytime ,
                      dnverifytime
                    )
            values  ( N'{3}' ,
                      N'15' ,
                      null ,
                      N'{0}' , --制单时间
                      '801' ,--部门
                      null ,
                      '121' ,--clRdCode
                      '221' ,--coRdCode
                      null ,
                      null ,
                      null ,
                      N'{1}' ,--制单人
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      {2} ,--单据ID
                      0 ,
                      91 ,
                      '{1}' ,
                      '{0}' ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      getdate() ,
                      null ,
                      getdate() 
                    )
                ";
            sSQL = string.Format(sSQL, FrameBaseFunction.ClsBaseDataInfo.sLogDate, FrameBaseFunction.ClsBaseDataInfo.sUserName.Trim(), iIDBack, sRDCode);
            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);

            iIDBackDetail++;
            sSQL = @"insert  into AssemVouchs
                    ( id ,
                      cavcode ,
                      bavtype ,
                      cwhcode ,
                      cinvcode ,
                      rdsid ,
                      iavnum ,
                      iavquantity ,
                      iavacost ,
                      iavaprice ,
                      iavpcost ,
                      iavpprice ,
                      cavbatch ,
                      cfree1 ,
                      cfree2 ,
                      ddisdate ,
                      cdefine22 ,
                      cdefine23 ,
                      cdefine24 ,
                      cdefine25 ,
                      cdefine26 ,
                      cdefine27 ,
                      citemcode ,
                      citem_class ,
                      cname ,
                      citemcname ,
                      autoid ,
                      cbarcode ,
                      cassunit ,
                      cfree3 ,
                      cfree4 ,
                      cfree5 ,
                      cfree6 ,
                      cfree7 ,
                      cfree8 ,
                      cfree9 ,
                      cfree10 ,
                      cdefine28 ,
                      cdefine29 ,
                      cdefine30 ,
                      cdefine31 ,
                      cdefine32 ,
                      cdefine33 ,
                      cdefine34 ,
                      cdefine35 ,
                      cdefine36 ,
                      cdefine37 ,
                      cbvencode ,
                      cinvouchcode ,
                      imassdate ,
                      dmadedate ,
                      cmassunit ,
                      bcosting ,
                      iexpiratdatecalcu ,
                      cexpirationdate ,
                      dexpirationdate ,
                      cbatchproperty1 ,
                      cbatchproperty2 ,
                      cbatchproperty3 ,
                      cbatchproperty4 ,
                      cbatchproperty5 ,
                      cbatchproperty6 ,
                      cbatchproperty7 ,
                      cbatchproperty8 ,
                      cbatchproperty9 ,
                      cbatchproperty10 ,
                      cciqbookcode 
                    )
            values  ( {0} , --表头ID
                      N'{1}' , --单据号
                      N'转换前' ,
                      N'{2}' , --仓库编号
                      N'{3}' , --存货编码
                      null ,
                      null,
                      {4} , --数量
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      {5} , --单据体ID
                      null ,
                      N'{6}' ,--辅计量单位编码
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      1 ,
                      0 ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null 
                    )";
            sSQL = string.Format(sSQL, iIDBack, sRDCode, whCode, beforInvCode, beforQty, iIDBackDetail, "");
            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);

            int assBeforeDId = (int)iIDBackDetail;

            iIDBackDetail++;
            sSQL = @"insert  into AssemVouchs
                    ( id ,
                      cavcode ,
                      bavtype ,
                      cwhcode ,
                      cinvcode ,
                      rdsid ,
                      iavnum ,
                      iavquantity ,
                      iavacost ,
                      iavaprice ,
                      iavpcost ,
                      iavpprice ,
                      cavbatch ,
                      cfree1 ,
                      cfree2 ,
                      ddisdate ,
                      cdefine22 ,
                      cdefine23 ,
                      cdefine24 ,
                      cdefine25 ,
                      cdefine26 ,
                      cdefine27 ,
                      citemcode ,
                      citem_class ,
                      cname ,
                      citemcname ,
                      autoid ,
                      cbarcode ,
                      cassunit ,
                      cfree3 ,
                      cfree4 ,
                      cfree5 ,
                      cfree6 ,
                      cfree7 ,
                      cfree8 ,
                      cfree9 ,
                      cfree10 ,
                      cdefine28 ,
                      cdefine29 ,
                      cdefine30 ,
                      cdefine31 ,
                      cdefine32 ,
                      cdefine33 ,
                      cdefine34 ,
                      cdefine35 ,
                      cdefine36 ,
                      cdefine37 ,
                      cbvencode ,
                      cinvouchcode ,
                      imassdate ,
                      dmadedate ,
                      cmassunit ,
                      bcosting ,
                      iexpiratdatecalcu ,
                      cexpirationdate ,
                      dexpirationdate ,
                      cbatchproperty1 ,
                      cbatchproperty2 ,
                      cbatchproperty3 ,
                      cbatchproperty4 ,
                      cbatchproperty5 ,
                      cbatchproperty6 ,
                      cbatchproperty7 ,
                      cbatchproperty8 ,
                      cbatchproperty9 ,
                      cbatchproperty10 ,
                      cciqbookcode 
                    )
            values  ( {0} , --表头ID
                      N'{1}' , --单据号
                      N'转换后' ,
                      N'{2}' , --仓库编号
                      N'{3}' , --存货编码
                      null ,
                      null,
                      {4} , --数量
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      {5} , --单据体ID
                      null ,
                      N'{6}' ,--辅计量单位编码
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      1 ,
                      0 ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null ,
                      null 
                    )";
            sSQL = string.Format(sSQL, iIDBack, sRDCode, afterWHCode, afterInvCode, afterQty, iIDBackDetail, "");
            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);

            int afterDid = (int)iIDBackDetail;

            sSQL = "update UFSystem..UA_Identity set iFatherID = " + iIDBack + ",iChildID=" + iIDBackDetail + "  where cAcc_Id = '200' and cVouchType = 'as'";
            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);

            //更改最大单据号
            sSQL = "select count(*) as iCount From VoucherHistory  with (NOLOCK) Where CardNumber='0305' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "')";
            DataTable dtCodeTemp = SqlHelper.ExecuteDataset(trans, CommandType.Text, sSQL).Tables[0];

            if (dtCodeTemp.Rows[0]["iCount"].ToString().Trim() == "0")
            {
                sSQL = "insert into VoucherHistory(cardnumber,ccontent,ccontentrule,cseed,cnumber,bempty)values('0305','日期','月','" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "','1',0)";
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);
            }
            else
            {
                sSQL = "update VoucherHistory set cNumber = '" + iCodeBack.ToString().Trim() + "' Where CardNumber='0305' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "')";
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);
            }

            try
            {
                string otherOutCode = "";
                string otherIdCode = "";

                GenInvChangeRD(trans, sRDCode, beforInvCode, afterInvCode, decimal.Parse(beforQty), decimal.Parse(afterQty), assBeforeDId.ToString(), afterDid.ToString(), out otherOutCode, out  otherIdCode, afterWHCode);
                //clsSQLCommond.ExecSqlTran(aList);
                string msg = "生成形态转换单:" + sRDCode + "\r\n";
                msg += "生成其他出库单:" + otherOutCode + "\r\n";
                msg += "生成其他入库单:" + otherIdCode + "\r\n";
                return msg;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }

        }
        #endregion

        #region 根据形态转换产生其他出库，其他入库单

        private static void GenInvChangeRD(SqlTransaction trans, string sourceAsmCode, string beforInvCode, string afterInvCode, decimal beforQty, decimal afterQty, string assBeforDId,
            string assAfterDId, out string otherOutCode, out string otherInCode, string afterWHCode)
        {

            aList.Clear();
            string sSQL = "";
            long iID = 0;
            long iIDDetail = 0;

            GetID("rd", out iID, out iIDDetail);
            sSQL = "select isnull(max(cNumber),0) as Maxnumber From VoucherHistory  with (NOLOCK) Where  CardNumber='0302' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "')";
            DataTable dtCodeBack = SqlHelper.ExecuteDataset(trans, CommandType.Text, sSQL).Tables[0];
            long iCode = Convert.ToInt64(dtCodeBack.Rows[0]["Maxnumber"]);
            iCode += 1;
            string sRDCode = sSetOOutCode(iCode);

            iID += 1;
            iIDDetail += 1;
            //其他出库单表头
            sSQL = @"insert  into rdrecord01
                ( id ,
                  brdflag ,
                  cvouchtype ,
                  cbustype ,
                  csource ,
                  cbuscode ,
                  cwhcode ,
                  ddate ,
                  ccode ,
                  cmaker ,
                  vt_id ,
                  bisstqc ,
                  bomfirst ,
                  ibg_overflag ,
                  cbg_auditor ,
                  cbg_audittime ,
                  controlresult ,
                  iswfcontrolled ,
                  dnmaketime ,
                  dnmodifytime ,
                  cRdCode,
                  cDepCode,
                  dVeriDate,
                  cHandler
                )
        values  ( {0} , --表头ID
                  0 ,
                  N'09' ,
                  N'转换出库' ,
                  N'形态转换' ,
                  N'{1}' , --形态转换单号
                  N'{2}' , --仓库
                  N'{3}' ,--单据日期
                  N'{4}' ,--单据号
                  N'{5}' ,--制单人
                  85 ,
                  0 ,
                  0 ,
                  0 ,
                  N'' ,
                  N'' ,
                  -1 ,
                  0 ,
                  getdate() ,
                  null ,
                  '221',
                  '801',
                  null,
                  null
                )";
            sSQL = string.Format(sSQL, iID, sourceAsmCode, WHCode, FrameBaseFunction.ClsBaseDataInfo.sLogDate, sRDCode, FrameBaseFunction.ClsBaseDataInfo.sUserName.Trim());
            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);

            //其他出库单表体
            sSQL = "Insert Into rdrecords01(autoid,id,cinvcode,inum,iquantity,iTrIds ," +
                        "isquantity,isnum,imoney,cdefine26,cdefine27,inquantity,innum," +
                        "itaxrate,btaxcost,cpoid," +
                        "iprocesscost,iprocessfee,iomodid," +
                        "bcosting,iinvexchrate,corufts,iexpiratdatecalcu,isotype) " +
                    "Values (" + iIDDetail + "," + iID + ",N'" + beforInvCode + "'," + "null" + "," + beforQty + "," + assBeforDId + "," +
                        "0,0,0,0,0," + "null" + "," + "null" + "," +
                        "0,1,N'" + "" +
                        "',0,0," + "null" + "," +
                        "1,0,N'1610.3418',0,0)";
            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);


            sSQL = "update rdrecords01 set cAssUnit = i.cAssComUnitCode from inventory i where i.cinvcode = rdrecords01.cinvcode and rdrecords01.autoid = " + iIDDetail;
            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);


            sSQL = "if exists(select * from  CurrentStock where cInvCode = '" + beforInvCode + "' and cWhCode = '" + WHCode + "') " +
            "	update  CurrentStock set iQuantity = isnull(iQuantity,0) - " + beforQty + ",iNum = isnull(iNum,0) + " + "0" + "  where cInvCode = '" + beforInvCode + "' and cWhCode = '" + WHCode + "' " +
                    "else " +
                        "begin " +
                        "    declare @itemid varchar(20); " +
                      "declare @iCount int;  " +
                        "select @iCount=count(itemid) from CurrentStock where cInvCode = '" + beforInvCode + "';   " +
                        "if( @iCount > 0 ) " +
                        "	select @itemid=itemid from CurrentStock where cInvCode = '" + beforInvCode + "';  " +
                        "else  " +
                        "	 select @itemid=max(itemid+1) from CurrentStock  " +
                        "    insert into CurrentStock(cWhCode,cInvCode,iQuantity,iNum,itemid)values('" + WHCode + "','" + beforInvCode + "',0-" + beforQty + "," + "null" + ",@itemid) " +
                        "end";

            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);

            otherOutCode = sRDCode;

            iID += 1;
            iIDDetail += 1;


            //生成其他入库单
            sSQL = "select isnull(max(cNumber),0) as Maxnumber From VoucherHistory  with (NOLOCK) Where  CardNumber='0301' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "')";
            dtCodeBack = SqlHelper.ExecuteDataset(trans, CommandType.Text, sSQL).Tables[0];
            long iInCode = Convert.ToInt64(dtCodeBack.Rows[0]["Maxnumber"]);
            iInCode += 1;

            sRDCode = sSetOInCode(iInCode);
            otherInCode = sRDCode;


            //其他入库表头
            sSQL = @"insert  into rdrecord01
                ( id ,
                  brdflag ,
                  cvouchtype ,
                  cbustype ,
                  csource ,
                  cbuscode ,
                  cwhcode ,
                  ddate ,
                  ccode ,
                  cmaker ,
                  vt_id ,
                  bisstqc ,
                  bomfirst ,
                  ibg_overflag ,
                  cbg_auditor ,
                  cbg_audittime ,
                  controlresult ,
                  iswfcontrolled ,
                  dnmaketime ,
                  dnmodifytime ,
                  dnverifytime,
                  cRdCode,
                  cDepCode,
                  dVeriDate,
                  cHandler
                  
                )
        values  ( {0} , --表头ID
                  1 ,
                  N'08' ,
                  N'转换入库' ,
                  N'形态转换' ,
                  N'{1}' , --形态转换单号
                  N'{2}' , --仓库
                  N'{3}' ,--单据日期
                  N'{4}' ,--单据号
                  N'{5}' ,--制单人
                  85 ,
                  0 ,
                  0 ,
                  0 ,
                  N'' ,
                  N'' ,
                  -1 ,
                  0 ,
                  getdate() ,
                  null ,
                  getdate() ,
                  '121',
                  '801',
                  null,
                  null
                )";
            sSQL = string.Format(sSQL, iID, sourceAsmCode, afterWHCode, FrameBaseFunction.ClsBaseDataInfo.sLogDate, sRDCode, FrameBaseFunction.ClsBaseDataInfo.sUserName.Trim());
            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);


            sSQL = "Insert Into rdrecords01(autoid,id,cinvcode,inum,iquantity,iTrIds ," +
                        "isquantity,isnum,imoney,cdefine26,cdefine27,inquantity,innum," +
                        "itaxrate,btaxcost,cpoid," +
                        "iprocesscost,iprocessfee,iomodid," +
                        "bcosting,iinvexchrate,corufts,iexpiratdatecalcu,isotype) " +
                    "Values (" + iIDDetail + "," + iID + ",N'" + afterInvCode + "'," + "null" + "," + afterQty + "," + assAfterDId + "," +
                        "0,0,0,0,0," + "null" + "," + "null" + "," +
                        "0,1,N'" + "" +
                        "',0,0," + "null" + "," +
                        "1,0,N'1610.3418',0,0)";
            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);


            sSQL = "update rdrecords01 set cAssUnit = i.cAssComUnitCode from inventory i where i.cinvcode = rdrecords01.cinvcode and rdrecords01.autoid = " + iIDDetail;
            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);


            sSQL = "if exists(select * from  CurrentStock where cInvCode = '" + afterInvCode + "' and cWhCode = '" + WHCode + "') " +
            "	update  CurrentStock set iQuantity = isnull(iQuantity,0) +" + afterQty + ",iNum = isnull(iNum,0) + " + "0" + "  where cInvCode = '" + afterInvCode + "' and cWhCode = '" + WHCode + "' " +
                    "else " +
                        "begin " +
                        "    declare @itemid varchar(20); " +
                      "declare @iCount int;  " +
                        "select @iCount=count(itemid) from CurrentStock where cInvCode = '" + afterInvCode + "';   " +
                        "if( @iCount > 0 ) " +
                        "	select @itemid=itemid from CurrentStock where cInvCode = '" + afterInvCode + "';  " +
                        "else  " +
                        "	 select @itemid=max(itemid+1) from CurrentStock  " +
                        "    insert into CurrentStock(cWhCode,cInvCode,iQuantity,iNum,itemid)values('" + WHCode + "','" + afterInvCode + "'," + afterQty + "," + "null" + ",@itemid) " +
                        "end";

            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);


            sSQL = "update UFSystem..UA_Identity set iFatherID = " + iID + ",iChildID=" + iIDDetail + "  where cAcc_Id = '200' and cVouchType = 'rd'";
            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);

            //更改最大出库单据号
            sSQL = "select count(*) as iCount From VoucherHistory  with (NOLOCK) Where CardNumber='0302' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "')";
            DataTable dtCodeTemp = SqlHelper.ExecuteDataset(trans, CommandType.Text, sSQL).Tables[0];

            if (dtCodeTemp.Rows[0]["iCount"].ToString().Trim() == "0")
            {
                sSQL = "insert into VoucherHistory(cardnumber,ccontent,ccontentrule,cseed,cnumber,bempty)values('0302','日期','月','" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "','1',0)";
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);
            }
            else
            {
                sSQL = "update VoucherHistory set cNumber = '" + iCode.ToString().Trim() + "' Where CardNumber='0302' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "')";
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);
            }


            //更改最大入库单据号
            sSQL = "select count(*) as iCount From VoucherHistory  with (NOLOCK) Where CardNumber='0301' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "')";
            dtCodeTemp = SqlHelper.ExecuteDataset(trans, CommandType.Text, sSQL).Tables[0];

            if (dtCodeTemp.Rows[0]["iCount"].ToString().Trim() == "0")
            {
                sSQL = "insert into VoucherHistory(cardnumber,ccontent,ccontentrule,cseed,cnumber,bempty)values('0301','日期','月','" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "','1',0)";
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);
            }
            else
            {
                sSQL = "update VoucherHistory set cNumber = '" + iCode.ToString().Trim() + "' Where CardNumber='0301' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "')";
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sSQL);
            }

        }
        #endregion

        /// <summary>
        /// 返回出库单单据号
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        private static string sSetOutCode(long s)
        {
            string sCode = s.ToString().Trim();
            for (int i = 0; i < 4; i++)
            {
                if (sCode.Length < 4)
                {
                    sCode = "0" + sCode;
                }
                else
                {
                    break;
                }
            }

            return "OP" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + sCode;
        }


        /// <summary>
        /// 返回形态转换出库单单据号
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        private static string sSetOOutCode(long s)
        {
            string sCode = s.ToString().Trim();
            for (int i = 0; i < 4; i++)
            {
                if (sCode.Length < 4)
                {
                    sCode = "0" + sCode;
                }
                else
                {
                    break;
                }
            }

            return "OO" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + sCode;
        }


        /// <summary>
        /// 形态单据号
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        private static string sSetInvChangeCode(long s)
        {
            string sCode = s.ToString().Trim();
            for (int i = 0; i < 4; i++)
            {
                if (sCode.Length < 4)
                {
                    sCode = "0" + sCode;
                }
                else
                {
                    break;
                }
            }

            return "XT" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + sCode;
        }


        /// <summary>
        /// 返回入库单单据号
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        private static string sSetInCode(long s)
        {
            string sCode = s.ToString().Trim();
            for (int i = 0; i < 4; i++)
            {
                if (sCode.Length < 4)
                {
                    sCode = "0" + sCode;
                }
                else
                {
                    break;
                }
            }

            return "IP" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + sCode;
        }


        /// <summary>
        /// 返回形态入库单单据号
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        private static string sSetOInCode(long s)
        {
            string sCode = s.ToString().Trim();
            for (int i = 0; i < 4; i++)
            {
                if (sCode.Length < 4)
                {
                    sCode = "0" + sCode;
                }
                else
                {
                    break;
                }
            }

            return "IO" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + sCode;
        }

        /// <summary>
        /// 获得单据ID
        /// </summary>
        /// <param name="sType">单据类型  PuArrival，</param>
        private static void GetID(string sType, out long iID, out long iIDDetail)
        {
            FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
            string sSQL = "select iFatherID,iChildID from UFSystem..UA_Identity with (nolock) where cAcc_Id = '200' and cVouchType = '" + sType + "'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            if (dt == null || dt.Rows.Count < 1)
            {
                iID = 0;
                iIDDetail = 0;
            }
            else
            {
                iID = Convert.ToInt64(dt.Rows[0]["iFatherID"]);
                iIDDetail = Convert.ToInt64(dt.Rows[0]["iChildID"]);
            }
        }

        /// <summary>
        /// 返回到货单单据号
        /// </summary>
        /// <param name="s"></param>
        /// <param name="sDepCode"></param>
        /// <returns></returns>
        private static string sSetCode(long s, string sDepCode)
        {
            string sCode = s.ToString().Trim();
            for (int i = 0; i < 4; i++)
            {
                if (sCode.Length < 4)
                {
                    sCode = "0" + sCode;
                }
                else
                {
                    break;
                }
            }

            FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
            string sDCode = "";
            string sSQL = "Select cCode from @u8.Vouchercontrapose Where cContent='Department' and cSeed='" + sDepCode + "'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt != null && dt.Rows.Count > 0)
            {
                sDCode = dt.Rows[0]["cCode"].ToString().Trim();
                sDCode = sDCode.Substring(0, 1);
            }

            return sDCode + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + sCode;
        }
    }
}
