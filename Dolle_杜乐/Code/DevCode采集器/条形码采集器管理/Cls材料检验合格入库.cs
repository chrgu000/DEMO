using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Collections;

namespace BarCode
{
    public class Cls材料检验合格入库
    {
        MobileBaseDLL.ClsDES clsDES = MobileBaseDLL.ClsDES.Instance();
        MobileBaseDLL.ClsSQLServerCommond clsSQLCommond = new MobileBaseDLL.ClsSQLServerCommond();

        ArrayList aList;
        int iTaxRate_All = MobileBaseDLL.ClsBaseDataInfo.iTaxRate_All_QJ;

        public DataTable GetBarArrInfo(string sBarCode, out string sErr)
        {
            sErr = "";
            DataTable dt = new DataTable();
            try
            {
                if (sBarCode.Trim() == string.Empty)
                {
                    return null;
                }

                string[] s = sBarCode.Trim().Split('$');
                if (s[4] == "")
                {
                    s[4] = "null";
                }

                string sSQL = "";
                //检验合格入库，通过到货单ID区分采购，委外
                if (s[0].Trim() == "5")
                {
                    sSQL = @" 
select cast(null as int) as 序号,cast(null as varchar(50)) as 返回信息
    ,a.CCHECKCODE as 检验单号,a.CINVCODE as 物料编码,c.cInvName as 物料名称,c.cInvStd as 规格型号,a.FQUANTITY as 检验数量,a.FNUM as 检验件数 
    ,isnull(a.FREGQUANTITY,0) + isnull(a.FCONQUANTIY,0) - isnull(a.FsumQuantity,0) as 可入库数量
    ,case when c.cAssComUnitCode is null then null else isnull(a.FREGNUM,0) + isnull(a.FCONNUM,0) - isnull(a.FsumNum,0) end as 可入库件数 " +
    "," + s[3].Trim() + " as 本次入库数量" +
    "," + s[4].Trim() + " as 本次入库件数 " +
    ",a.CITEMCODE as 项目编码 " +
    ",'" + sBarCode + "' as 条形码,cast(null as varchar(50)) as 仓库编码,cast(null as varchar(50)) as 货位编码,c.cAssComUnitCode as 辅计量单位编码 " +
"from @u8.QMCHECKVOUCHER a inner join @u8.QMCHECKVOUCHERs b on a.id = b.id inner join @u8.Inventory c on a.cInvCode = c.cInvCode " +
"where   a.IVERIFYSTATE = 1 " +
"  and  a.ID = " + s[2].Trim();
                }

                dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count != 1)
                {
                    sErr = "没有符合的单据！";
                    dt = null;
                }

                decimal d可入库数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt.Rows[0]["可入库数量"]);
                decimal d可入库件数 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt.Rows[0]["可入库件数"]);
                decimal d本次入库数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt.Rows[0]["本次入库数量"]);
                decimal d本次入库件数 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt.Rows[0]["本次入库件数"]);

                if (d本次入库数量 > d可入库数量)
                {
                    sErr = "入库数量已经超出，请核查！";
                }
            }
            catch (Exception ee)
            {
                dt = null;
            }

            return dt;
        }



        public string Insert入库单(DataTable dt列表, DateTime d单据日期)
        {
            string sReturn = "";
            string s单据号 = "";
            try
            {
                int iYear = int.Parse(Convert.ToDateTime(MobileBaseDLL.ClsBaseDataInfo.sLogDate).ToString("yyyy"));
                int iYear2 = int.Parse(d单据日期.ToString("yyyy"));
                string sSQL = "";

                string s错误 = "";
                if (iYear >= iYear2)
                {
                    sSQL = "select * from @u8.GL_mend where iperiod = month('" + d单据日期.ToString("yyyy-MM-dd") + "')";
                    DataTable dtTemp1 = clsSQLCommond.ExecQuery(sSQL);
                    if (Convert.ToBoolean(dtTemp1.Rows[0]["bflag_ST"]) == true)
                    {
                        s错误 = "当月库存管理已结帐，不能录入数据！";
                    }
                }

                ArrayList aList单据号id = new ArrayList(); //记录单据号ID，用于执行单据允许记账
                aList = new ArrayList();

                //条码入库ID，单据号
                long iID = -1;
                long iIDDetail = -1;
                long iCode = -1;
                GetID("rd", out iID, out iIDDetail);
                sSQL = "select isnull(max(cNumber),0) as Maxnumber From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='24' and (cContent='日期' or cContent='单据日期') and (cSeed='" + d单据日期.ToString("yyyyMM") + "' or cSeed='" + d单据日期.ToString("yyMM") + "')";


                DataTable dtCode2 = clsSQLCommond.ExecQuery(sSQL);
                iCode = Convert.ToInt64(dtCode2.Rows[0]["Maxnumber"]);
                dtCode2 = null;

                for (int i = 0; i < dt列表.Rows.Count; i++)
                {
                    if (MobileBaseDLL.ClsBaseDataInfo.ReturnLong(dt列表.Rows[i]["bUsed"]) > 0)
                    {
                        continue;
                    }

                    string s货位 = dt列表.Rows[i]["货位编码"].ToString().Trim();
                    string s仓库编码 = dt列表.Rows[i]["仓库编码"].ToString().Trim();
                    string s货位信息 = "select * from @u8.Position  where cPosCode = '" + s货位 + "' and cWhCode = '" + s仓库编码 + "' and bPosEnd = 1";
                    DataTable dt货位 = clsSQLCommond.ExecQuery(s货位信息);
                    if (dt货位 == null || dt货位.Rows.Count < 1)
                    {
                        s错误 = s错误 + "行" + (i + 1).ToString() + "货位不存在或货位仓库不对应\r\n";
                    }

                    string[] s条形码 = dt列表.Rows[i]["条形码"].ToString().Trim().Split('$');
                    decimal d本次入库数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt列表.Rows[i]["本次入库数量"]);
                    decimal d本次入库件数 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt列表.Rows[i]["本次入库件数"]);

                    string s行 = "行" + (i + 1).ToString();
                    for (int j = i + 1; j < dt列表.Rows.Count; j++)
                    {
                        if (MobileBaseDLL.ClsBaseDataInfo.ReturnLong(dt列表.Rows[j]["bUsed2"]) > 0)
                        {
                            continue;
                        }

                        string[] s条形码2 = dt列表.Rows[j]["条形码"].ToString().Trim().Split('$');
                        if (s条形码[2].Trim() == s条形码2[2].Trim())
                        {
                            d本次入库数量 = d本次入库数量 + MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt列表.Rows[j]["本次入库数量"]);
                            d本次入库件数 = d本次入库件数 + MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt列表.Rows[j]["本次入库件数"]);
                            s行 = s行 + "," + "行" + (j + 1).ToString();
                            dt列表.Rows[j]["bUsed2"] = j;
                        }
                    }

                    sSQL = " select cast(0 as bit) as 选择 " +
                              "	,a.ID as 检验单ID,a.CCHECKCODE as 检验单号,a.CINSPECTCODE 报检单号,a.CINVCODE as 物料编码,a.FQUANTITY as 检验数量,a.FNUM as 检验件数" +
                              ",a.FsumQuantity as 累计入库数量,a.FsumNum as 累计入库件数 " +
                              "	,isnull(a.FREGQUANTITY,0) + isnull(a.FCONQUANTIY,0) as 可入库数量 " +
                              "   ,case when c.cAssComUnitCode is null then null else isnull(a.FREGNUM,0) + isnull(a.FCONNUM,0) end as 可入库件数 " +
                              "	," + d本次入库数量 + " as 本次入库数量" +
                              "   ," + d本次入库件数 + " as 本次入库件数 " +
                              "	,a.CPOCODE as 订单号,a.CINSPECTDEPCODE as 部门编号,a.INSPECTID as 报检单主表ID,a.INSPECTAUTOID as 报检单子表ID " +
                              "	,a.SOURCEAUTOID as 来源单据子表ID,a.SOURCEID as 来源单据ID,a.SOURCECODE as 到货单号,a.CSOURCE as 来源类型 " +
                              "	,a.CINSPECTDEPCODE as 业务部门编码,a.DARRIVALDATE as 到货日期 " +
                              "	,a.CITEMCLASS as 项目大类编码 ,a.CITEMCNAME as 项目大类名称,a.CITEMCODE as 项目编码 ,a.CITEMNAME as 项目名称  " +
                              "	,a.DDATE as 检验日期,a.CTIME as 检验时间,a.CDEPCODE as 检验部门编码,a.CVENCODE as 供应商编码,'" + dt列表.Rows[i]["仓库编码"] + "' as 仓库编码,'" + dt列表.Rows[i]["货位编码"] + "' as 货位编码 " +
                              "   ,cast(null as varchar(50)) as 条形码,c.cAssComUnitCode as 辅助计量编码,cast(null as varchar(10)) as 单据来源,0 as bUsed,0 as bUsed2,b.AUTOID as 检验单子表ID " +
                          "from @u8.QMCHECKVOUCHER a inner join @u8.QMCHECKVOUCHERS b on a.id = b.id inner join @u8.Inventory c on a.cInvCode = c.cInvCode " +
                          "where  a.id = " + s条形码[2].Trim() + " " +
                          "order by a.CWHCODE,a.CPOSITION,a.CINVCODE,a.CCHECKCODE ";
                    DataTable dt检验单详细信息 = clsSQLCommond.ExecQuery(sSQL);

                    decimal d可入库数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt检验单详细信息.Rows[0]["可入库数量"]);
                    decimal d可入库件数 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt检验单详细信息.Rows[0]["可入库件数"]);
                    decimal d累计入库数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt检验单详细信息.Rows[0]["累计入库数量"]);
                    decimal d累计入库件数 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt检验单详细信息.Rows[0]["累计入库件数"]);
                    if (d可入库数量 < d本次入库数量 + d累计入库数量)
                    {
                        dt列表.Rows[i]["返回信息"] = "超出数量，不能入库";
                        s错误 = s错误 + s行 + "合计数量超出，不能入库\r\n";
                    }

                    sSQL = "select cBusType,cPersonCode,b.* from @u8.PU_ArrivalVouch a inner join @u8.PU_ArrivalVouchs b on a.id = b.id where b.autoid = " + dt检验单详细信息.Rows[0]["来源单据子表ID"].ToString().Trim();
                    DataTable dt到货单 = clsSQLCommond.ExecQuery(sSQL);
                    if (dt到货单 == null || dt到货单.Rows.Count < 1)
                    {
                        dt列表.Rows[i]["返回信息"] = "未能查出单据类型";
                        s错误 = s错误 + "行" + (i + 1).ToString() + "未能查出单据类型\r\n";
                    }

                    if (s错误.Trim() != "")
                    {
                        return s错误;
                    }

                    dt列表.Rows[i]["单据来源"] = dt到货单.Rows[0]["cBusType"].ToString().Trim();
                    dt列表.Rows[i]["bUsed"] = 0;

                    string sPersonCode = "null";
                    if (dt到货单.Rows[0]["cPersonCode"].ToString().Trim() != "")
                    {
                        sPersonCode = "'" + dt到货单.Rows[0]["cPersonCode"].ToString().Trim() + "'";
                    }

                    sSQL = "select top 1 * from [UFDATA_200_2015]..gl_mend where bflag_ST=1 and iyear=aaaaaaaa and iperiod=bbbbbbbb";
                    sSQL = sSQL.Replace("aaaaaaaa", d单据日期.ToString("yyyy"));
                    sSQL = sSQL.Replace("bbbbbbbb", d单据日期.ToString("MM"));
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        s错误 = s错误 + "库存模块已结账\n";
                    }

                    #region 普通采购

                    if (dt列表.Rows[i]["单据来源"].ToString().Trim() == "普通采购")
                    {
                        iID += 1;
                        iCode += 1;

                        Model.RdRecord01 model = new BarCode.Model.RdRecord01();
                        model.ID = iID;
                        model.bRdFlag = 1;
                        model.cVouchType = "01";
                        model.cBusType = "普通采购";
                        model.cSource = "来料检验单";
                        model.cWhCode = dt列表.Rows[i]["仓库编码"].ToString().Trim();
                        model.dDate = d单据日期;
                        model.cCode = sSetCode(iCode, d单据日期);
                        model.cRdCode = "101";
                        model.cDepCode = dt检验单详细信息.Rows[0]["部门编号"].ToString().Trim();
                        model.cPersonCode = MobileBaseDLL.ClsBaseDataInfo.sUserName;
                        model.cPTCode = "01";
                        model.cVenCode = dt检验单详细信息.Rows[0]["供应商编码"].ToString().Trim();
                        model.cOrderCode = dt检验单详细信息.Rows[0]["订单号"].ToString().Trim();
                        model.cARVCode = dt检验单详细信息.Rows[0]["到货单号"].ToString().Trim();
                        model.cHandler = MobileBaseDLL.ClsBaseDataInfo.sUserName;
                        model.bTransFlag = false;
                        model.cMaker = MobileBaseDLL.ClsBaseDataInfo.sUserName;
                        model.bpufirst = false;
                        model.biafirst = false;
                        model.dARVDate = MobileBaseDLL.ClsBaseDataInfo.ReturnDate(dt检验单详细信息.Rows[0]["到货日期"].ToString().Trim());
                        model.cChkCode = dt检验单详细信息.Rows[0]["检验单号"].ToString().Trim();
                        model.VT_ID = 27;
                        model.bIsSTQc = false;
                        model.iTaxRate = iTaxRate_All;
                        model.iExchRate = 1;
                        model.cExch_Name = "人民币";
                        model.bFromPreYear = false;
                        model.bIsComplement = 0;
                        model.iDiscountTaxType = 0;
                        model.ireturncount = 0;
                        model.iverifystate = 0;
                        model.dnmaketime = DateTime.Now;
                        model.bredvouch = 0;
                        DAL.RdRecord01 dal = new BarCode.DAL.RdRecord01();
                        sSQL = dal.Add(model);
                        aList.Add(sSQL);

                        aList单据号id.Add(iID.ToString());

                        s单据号 = s单据号 + model.cCode + "\r\n";

                        string s本次入库件数 = "null";
                        if (d本次入库件数 > 0)
                        {
                            s本次入库件数 = d本次入库件数.ToString().Trim();
                        }
                        if (MobileBaseDLL.ClsBaseDataInfo.ReturnInt(dt列表.Rows[i]["bUsed2"]) == 0)
                        {
                            iIDDetail += 1;
                            //税率
                            decimal d税率 = iTaxRate_All;
                            //单价(不含税)
                            decimal d无税单价 = decimal.Round(Convert.ToDecimal(dt到货单.Rows[0]["iOriCost"]), 6);
                            //金额(不含税)
                            decimal d无税金额 = decimal.Round(d无税单价 * d本次入库数量, 2);
                            //原币含税单价
                            decimal d含税单价 = decimal.Round(Convert.ToDecimal(dt到货单.Rows[0]["iOriTaxCost"]), 6);
                            //原币价税合计
                            decimal d价税合计 = decimal.Round(d含税单价 * decimal.Round(d本次入库数量, 6), 2);
                            //原币税额 
                            decimal d税额 = d价税合计 - d无税金额;


                            string s换算率 = dt到货单.Rows[0]["iinvexchrate"].ToString().Trim();
                            if (s换算率 == "")
                                s换算率 = "null";

                            sSQL = "Insert Into @u8.rdrecords01(autoid,id,cinvcode,inum,iquantity,iunitcost,iprice,iaprice,ipunitcost,ipprice" +
                                        ",cbatch,cvouchcode,cfree1,cfree2,dsdate,itax,isquantity,isnum,imoney,isoutquantity" +
                                        ",isoutnum,ifnum,ifquantity,dvdate,cposition,cdefine22,cdefine23,cdefine24,cdefine25" +
                                        ",cdefine26,cdefine27,citem_class,citemcode,iposid,facost,cname,citemcname,cfree3,cfree4" +
                                        ",cfree5,cfree6,cfree7,cfree8,cfree9,cfree10,cbarcode,inquantity,innum,cassunit" +
                                        ",dmadedate,imassdate,cdefine28,cdefine29,cdefine30,cdefine31,cdefine32,cdefine33,cdefine34,cdefine35" +
                                        ",cdefine36,cdefine37,icheckids,cbvencode,cinvouchcode,cgspstate,iarrsid,ccheckcode,icheckidbaks" +
                                        ",crejectcode,irejectids,ccheckpersoncode,dcheckdate,ioritaxcost,ioricost,iorimoney,ioritaxprice,iorisum,itaxrate" +
                                        ",itaxprice,isum,btaxcost,cpoid,cmassunit,imaterialfee,iprocesscost,iprocessfee,dmsdate,ismaterialfee" +
                                        ",isprocessfee,iomodid,iorderdid,strcontractid,strcode,iordertype,cbaccounter,bcosting,isumbillquantity,bvmiused" +
                                        ",ivmisettlequantity,ivmisettlenum,cvmivencode,iinvsncount,impcost,iimosid,iimbsid,cbarvcode,dbarvdate,iinvexchrate" +
                                        ",iordercode,iorderseq,corufts,iexpiratdatecalcu,cexpirationdate,dexpirationdate,cciqbookcode,ibondedsumqty,isodid,isotype" +
                                        ",csocode,isoseq,cbatchproperty1,cbatchproperty2,cbatchproperty3,cbatchproperty4,cbatchproperty5,cbatchproperty6,cbatchproperty7,cbatchproperty8" +
                                        ",cbatchproperty9,cbatchproperty10) " +
                                    "Values (" + iIDDetail + "," + iID + ",N'" + dt列表.Rows[i]["物料编码"].ToString().Trim() + "'," + s本次入库件数 + "," + d本次入库数量 + "," + d无税单价 + "," + d无税金额 + "," + d无税金额 + ",Null,Null" +
                                        ",Null,Null,Null,Null,Null,null,0,0,0,Null" +
                                        ",Null,Null,Null,Null,Null,Null,Null,Null,Null" +
                                        ",Null,Null,N'00',N'" + dt列表.Rows[i]["项目编码"].ToString().Trim() + "'," + dt到货单.Rows[0]["iPOsID"].ToString().Trim() + "," + d无税单价 + ",N'" + dt列表.Rows[i]["项目编码"].ToString().Trim() + "',N'外销订单项目',Null,Null" +
                                        ",Null,Null,Null,Null,Null,Null,Null,Null,Null,N'" + dt列表.Rows[i]["辅计量单位编码"].ToString().Trim() + "'" +
                                        ",Null,Null,Null,Null,Null,Null,Null,Null,Null,Null" +
                                        ",Null,Null,Null,Null,Null,Null," + dt到货单.Rows[0]["Autoid"].ToString().Trim() + ",N'" + dt列表.Rows[i]["检验单号"].ToString().Trim() + "'," + dt检验单详细信息.Rows[0]["检验单子表ID"].ToString().Trim() + " " +
                                        ",Null,Null,Null,N'" + dt检验单详细信息.Rows[0]["检验日期"].ToString().Trim() + "'," + d含税单价 + "," + d无税单价 + "," + d无税金额 + "," + d税额 + "," + d价税合计 + "," + d税率 + " " +
                                        "," + d税额 + "," + d价税合计 + ",0,N'" + dt到货单.Rows[0]["cordercode"].ToString().Trim() + "',Null,Null,null,null,Null,Null" +
                                        ",Null,Null,Null,Null,Null,Null,Null,1,Null,Null" +
                                        ",Null,Null,Null,Null,Null,Null,Null,N'" + dt检验单详细信息.Rows[0]["到货单号"].ToString().Trim() + "',N'" + dt检验单详细信息.Rows[0]["到货日期"].ToString().Trim() + "'," + s换算率 + " " +
                                        ",Null,Null,N'13959.6528',null,Null,Null,Null,Null,Null,Null" +
                                        ",Null,Null,Null,Null,Null,Null,Null,Null,Null,Null" +
                                        ",Null,Null)";
                            aList.Add(sSQL);

                            sSQL = "update @u8.rdrecords01 set iOriCost = CAST(iOriTaxCost / {0} as decimal(16,6)) " +
                                        ",iOriMoney =  CAST( CAST(iOriTaxCost / {0} as decimal(16,6)) * iQuantity as decimal(16,2)) " +
                                        ",ioriSum = CAST(iOriTaxCost * iQuantity as decimal(16,2))  " +
                                        ",iOriTaxPrice =   CAST(iOriTaxCost * iQuantity as decimal(16,2)) -  CAST( CAST(iOriTaxCost / {0} as decimal(16,6)) * iQuantity as decimal(16,2)) " +
                                        ",iUnitCost = CAST(iOriTaxCost / {0} as decimal(16,6)) " +
                                        ",iPrice =  CAST( CAST(iOriTaxCost / {0} as decimal(16,6)) * iQuantity as decimal(16,2)) " +
                                        ",iTax =  CAST(iOriTaxCost * iQuantity as decimal(16,2)) -  CAST( CAST(iOriTaxCost / {0} as decimal(16,6)) * iQuantity as decimal(16,2)) " +
                                        ",iTaxPrice = CAST(iOriTaxCost * iQuantity as decimal(16,2)) -  CAST( CAST(iOriTaxCost / {0} as decimal(16,6)) * iQuantity as decimal(16,2))" +
                                    "where autoid = " + iIDDetail;
                            sSQL = string.Format(sSQL, "1." + iTaxRate_All.ToString()); 
                            aList.Add(sSQL);

                            sSQL = "if exists(select * from  @u8.CurrentStock where cInvCode = '" + dt列表.Rows[i]["物料编码"].ToString().Trim() + "' and cWhCode = '" + dt列表.Rows[i]["仓库编码"].ToString().Trim() + "') " +
                                        "update  @u8.CurrentStock set iQuantity = isnull(iQuantity,0) + " + d本次入库数量 + " ,iNum = isnull(iNum,0) + " + s本次入库件数 + " where cInvCode = '" + dt列表.Rows[i]["物料编码"].ToString().Trim() + "' and cWhCode = '" + dt列表.Rows[i]["仓库编码"].ToString().Trim() + "' " +
                                  "else " +
                                      "begin " +
                                      "    declare @itemid varchar(20); " +
                                      "declare @iCount int;  " +
                                        "select @iCount=count(itemid) from @u8.CurrentStock where cInvCode = '" + dt列表.Rows[i]["物料编码"].ToString().Trim() + "';   " +
                                        "if( @iCount > 0 ) " +
                                        "	select @itemid=itemid from @u8.CurrentStock where cInvCode = '" + dt列表.Rows[i]["物料编码"].ToString().Trim() + "';  " +
                                        "else  " +
                                        "	 select @itemid=max(itemid+1) from @u8.CurrentStock  " +
                                        "    insert into @u8.CurrentStock(cWhCode,cInvCode,iQuantity,iNum,itemid)values('" + dt列表.Rows[i]["仓库编码"].ToString().Trim() + "','" + dt列表.Rows[i]["物料编码"].ToString().Trim() + "'," + d本次入库数量 + "," + s本次入库件数 + ",@itemid) " +
                                  "end";
                            aList.Add(sSQL);

                            sSQL = " UPDATE @u8.qmcheckvoucher SET FsumQuantity=isnull(FsumQuantity,0)+ " + d本次入库数量 + ",FsumNum=isnull(FsumNum,0)+ " + s本次入库件数 + ",bpuinflag=0 " +
                                    " where ID = " + dt检验单详细信息.Rows[0]["检验单ID"].ToString().Trim();
                            aList.Add(sSQL);

                            sSQL = "update @u8.Pu_ArrivalVouchs set fValidInQuan = ISNULL(fValidInQuan,0) + " + d本次入库数量 + ",fValidInNum = ISNULL(fValidInNum,0) + " + s本次入库件数 + " " +
                                    "where Autoid = " + dt到货单.Rows[0]["Autoid"].ToString().Trim();
                            aList.Add(sSQL);

                            int i货位管理 = Chk货位管理(dt列表.Rows[i]["仓库编码"].ToString().Trim());
                            if (i货位管理 == 1)
                            {
                                decimal d货位数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt列表.Rows[i]["本次入库数量"]);
                                decimal d货位件数 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt列表.Rows[i]["本次入库件数"]);
                                string s货位件数 = "null";
                                if (d货位件数 > 0)
                                    s货位件数 = d货位件数.ToString();

                                Model.InvPosition modelPos = new BarCode.Model.InvPosition();
                                modelPos.RdsID = iIDDetail;
                                modelPos.RdID = iID;
                                modelPos.cWhCode = model.cWhCode;
                                modelPos.cPosCode = dt列表.Rows[i]["货位编码"].ToString().Trim();
                                modelPos.cInvCode = dt列表.Rows[i]["物料编码"].ToString().Trim();
                                modelPos.iQuantity = d货位数量;
                                modelPos.iNum = d货位件数;
                                modelPos.cHandler = MobileBaseDLL.ClsBaseDataInfo.sUserName;
                                modelPos.dDate = model.dDate;
                                modelPos.bRdFlag = 1;
                                modelPos.cAssUnit = dt列表.Rows[i]["辅计量单位编码"].ToString().Trim();
                                modelPos.iTrackId = 0;
                                modelPos.iExpiratDateCalcu = 0;
                                modelPos.cvouchtype = "01";
                                modelPos.dVouchDate = model.dDate;

                                DAL.InvPosition dalPos = new BarCode.DAL.InvPosition();
                                sSQL = dalPos.Add(modelPos);
                                aList.Add(sSQL);

                                sSQL = @"
if exists (select * from @u8.InvPositionSum where  cInvCode = 'aaaaaaaaaa' and cWhCode = 'cccccccccc' and cPosCode = 'bbbbbbbbbb')
    update @u8.InvPositionSum set iQuantity = isnull(iQuantity,0) + dddddddddd,iNum = isnull(iNum,0) + eeeeeeeeee where cInvCode = 'aaaaaaaaaa' and cWhCode = 'cccccccccc' and cPosCode = 'bbbbbbbbbb'
else
    insert into @u8.InvPositionSum(cInvCode,cWhCode,cPosCode,iQuantity,iNum)
    values('aaaaaaaaaa','cccccccccc','bbbbbbbbbb',dddddddddd,eeeeeeeeee)
";
                                sSQL = sSQL.Replace("aaaaaaaaaa", dt列表.Rows[i]["物料编码"].ToString().Trim());
                                sSQL = sSQL.Replace("bbbbbbbbbb", dt列表.Rows[i]["货位编码"].ToString().Trim());
                                sSQL = sSQL.Replace("cccccccccc", model.cWhCode);
                                sSQL = sSQL.Replace("dddddddddd", d货位数量.ToString());

                                if (modelPos.iNum == 0)
                                {
                                    sSQL = sSQL.Replace("eeeeeeeeee", "Null");
                                }
                                else
                                {
                                    sSQL = sSQL.Replace("eeeeeeeeee", modelPos.iNum.ToString());
                                }
                                aList.Add(sSQL);

                                //当一条入库单有多个货位时，置空
                                sSQL = "update @u8.rdrecords01 set cposition=N'" + dt列表.Rows[i]["货位编码"].ToString().Trim() + "' where id = " + iID + " and autoid=" + iIDDetail;
                                aList.Add(sSQL);
                            }
                        }
                    }
                    #endregion
                    #region 委外加工

                    if (dt列表.Rows[i]["单据来源"].ToString().Trim() == "委外加工")
                    {
                        iID += 1;
                        iCode += 1;

                        sSQL = @"insert into @u8.rdrecord01(id,brdflag,cvouchtype,cbustype,csource,cwhcode,ddate,ccode,crdcode,cdepcode
                                    ,cptcode,cvencode,cordercode,carvcode,cmaker,bpufirst,darvdate,vt_id,bisstqc,cdefine14
                                    ,itaxrate,iexchrate,cexch_name,bomfirst,idiscounttaxtype,iswfcontrolled,dnmaketime,dnmodifytime,dnverifytime,bcredit,cPersonCode,
                                    cHandler,dVeriDate) " +
                               "values (" + iID + ",1,N'01',N'委外加工',N'来料检验单',N'" + dt列表.Rows[i]["仓库编码"].ToString().Trim() + "',N'" + d单据日期.ToString("yyyy-MM-dd") + "',N'" + sSetCode(iCode, d单据日期) + "',N'111',N'" + dt检验单详细信息.Rows[0]["部门编号"].ToString().Trim() + "'" +
                                    ",N'01',N'" + dt检验单详细信息.Rows[0]["供应商编码"].ToString().Trim() + "',N'" + dt检验单详细信息.Rows[0]["订单号"].ToString().Trim() + "',N'" + dt检验单详细信息.Rows[0]["到货单号"].ToString().Trim() + "',N'" + MobileBaseDLL.ClsBaseDataInfo.sUserName + "',0,N'" + dt检验单详细信息.Rows[0]["到货日期"].ToString().Trim() + "',27,0,N'" + MobileBaseDLL.ClsBaseDataInfo.sUserName + "'" +
                                    ",N'" + iTaxRate_All.ToString() + "',1,N'人民币',0,N'0',0, getdate(), Null , getdate() ,N'0'," + sPersonCode + "," +
                                    "'" + MobileBaseDLL.ClsBaseDataInfo.sUserName + "','" + d单据日期.ToString("yyyy-MM-dd") + "')";
                        aList.Add(sSQL);

                        aList单据号id.Add(iID.ToString());

                        s单据号 = s单据号 + sSetCode(iCode, d单据日期) + "\r\n";

                        string s本次入库件数 = "null";
                        if (d本次入库件数 > 0)
                        {
                            s本次入库件数 = d本次入库件数.ToString().Trim();
                        }
                        if (MobileBaseDLL.ClsBaseDataInfo.ReturnInt(dt列表.Rows[i]["bUsed2"]) == 0)
                        {
                            iIDDetail += 1;
                            //税率
                            decimal d税率 = iTaxRate_All;
                            //单价(不含税)
                            decimal d无税单价 = decimal.Round(Convert.ToDecimal(dt到货单.Rows[0]["iOriCost"]), 6);
                            //金额(不含税)
                            decimal d无税金额 = decimal.Round(d无税单价 * d本次入库数量, 2);
                            //原币含税单价
                            decimal d含税单价 = decimal.Round(Convert.ToDecimal(dt到货单.Rows[0]["iOriTaxCost"]), 6);
                            //原币价税合计
                            decimal d价税合计 = decimal.Round(d含税单价 * decimal.Round(d本次入库数量, 6), 2);
                            //原币税额 
                            decimal d税额 = d价税合计 - d无税金额;

                            string s换算率 = dt到货单.Rows[0]["iinvexchrate"].ToString().Trim();
                            if (s换算率 == "")
                                s换算率 = "null";

                            sSQL = @"Insert Into @u8.rdrecords01(autoid,id,cinvcode,inum,iquantity,iunitcost,iprice,iaprice,ipunitcost,ipprice
                                        ,isquantity,isnum,imoney
                                        ,citem_class,citemcode,iposid,facost,cname,citemcname,cfree3,cfree4
                                        ,cassunit
                                        ,iarrsid,ccheckcode,icheckidbaks
                                        ,crejectcode,irejectids,ccheckpersoncode,dcheckdate,ioritaxcost,ioricost,iorimoney,ioritaxprice,iorisum,itaxrate
                                        ,itaxprice,isum,btaxcost,cpoid,cmassunit,imaterialfee,iprocesscost,iprocessfee,dmsdate,ismaterialfee
                                        ,isprocessfee,iomodid,iorderdid,strcontractid,strcode,iordertype,cbaccounter,bcosting,isumbillquantity,bvmiused
                                        ,ivmisettlequantity,ivmisettlenum,cvmivencode,iinvsncount,impcost,iimosid,iimbsid,cbarvcode,dbarvdate,iinvexchrate
                                        ) " +
                                    "Values (" + iIDDetail + "," + iID + ",N'" + dt列表.Rows[i]["物料编码"].ToString().Trim() + "'," + s本次入库件数 + "," + d本次入库数量 + "," + d无税单价 + "," + d无税金额 + "," + d无税金额 + ",Null,Null" +
                                        ",0,0,0" +
                                        ",N'00',N'" + dt列表.Rows[i]["项目编码"].ToString().Trim() + "'," + dt到货单.Rows[0]["iPOsID"].ToString().Trim() + "," + d无税单价 + ",N'" + dt列表.Rows[i]["项目编码"].ToString().Trim() + "',N'外销订单项目',Null,Null" +
                                        ",N'" + dt列表.Rows[i]["辅计量单位编码"].ToString().Trim() + "'" +
                                        "," + dt到货单.Rows[0]["Autoid"].ToString().Trim() + ",N'" + dt列表.Rows[i]["检验单号"].ToString().Trim() + "'," + dt检验单详细信息.Rows[0]["检验单子表ID"].ToString().Trim() + " " +
                                        ",Null,Null,Null,N'" + dt检验单详细信息.Rows[0]["检验日期"].ToString().Trim() + "'," + d含税单价 + "," + d无税单价 + "," + d无税金额 + "," + d税额 + "," + d价税合计 + "," + d税率 + " " +
                                        "," + d税额 + "," + d价税合计 + ",0,N'" + dt到货单.Rows[0]["cordercode"].ToString().Trim() + "',Null,Null,Null,Null,Null,Null" +
                                        ",Null," + dt到货单.Rows[0]["iPOsID"].ToString().Trim() + ",Null,Null,Null,Null,Null,1,Null,Null" +
                                        ",Null,Null,Null,Null,Null,Null,Null,N'" + dt检验单详细信息.Rows[0]["到货单号"].ToString().Trim() + "',N'" + dt检验单详细信息.Rows[0]["到货日期"].ToString().Trim() + "'," + s换算率 + " " +
                                        ")";
                            aList.Add(sSQL);

                            sSQL = "update @u8.rdrecords01 set iOriCost = CAST(iOriTaxCost / {0} as decimal(16,6)) " +
                                        ",iOriMoney =  CAST( CAST(iOriTaxCost / {0} as decimal(16,6)) * iQuantity as decimal(16,2)) " +
                                        ",ioriSum = CAST(iOriTaxCost * iQuantity as decimal(16,2))  " +
                                        ",iOriTaxPrice =   CAST(iOriTaxCost * iQuantity as decimal(16,2)) -  CAST( CAST(iOriTaxCost / {0} as decimal(16,6)) * iQuantity as decimal(16,2)) " +
                                        ",iUnitCost = CAST(iOriTaxCost / {0} as decimal(16,6)) " +
                                        ",iPrice =  CAST( CAST(iOriTaxCost / {0} as decimal(16,6)) * iQuantity as decimal(16,2)) " +
                                        ",iTax =  CAST(iOriTaxCost * iQuantity as decimal(16,2)) -  CAST( CAST(iOriTaxCost / {0} as decimal(16,6)) * iQuantity as decimal(16,2)) " +
                                        ",iTaxPrice = CAST(iOriTaxCost * iQuantity as decimal(16,2)) -  CAST( CAST(iOriTaxCost / {0} as decimal(16,6)) * iQuantity as decimal(16,2))" +
                                        ",iProcessCost =  CAST(iOriTaxCost / {0} as decimal(16,6)) " +
                                        ",iProcessFee = CAST( CAST(iOriTaxCost / {0} as decimal(16,6)) * iQuantity as decimal(16,2)) " +
                                   "where autoid = " + iIDDetail;

                            sSQL = string.Format(sSQL, "1." + iTaxRate_All.ToString());
                            aList.Add(sSQL);

                            sSQL = "if exists(select * from  @u8.CurrentStock where cInvCode = '" + dt列表.Rows[i]["物料编码"].ToString().Trim() + "' and cWhCode = '" + dt列表.Rows[i]["仓库编码"].ToString().Trim() + "') " +
                                        "update  @u8.CurrentStock set iQuantity = isnull(iQuantity,0) + " + d本次入库数量 + " ,iNum = isnull(iNum,0) + " + s本次入库件数 + " where cInvCode = '" + dt列表.Rows[i]["物料编码"].ToString().Trim() + "' and cWhCode = '" + dt列表.Rows[i]["仓库编码"].ToString().Trim() + "' " +
                                  "else " +
                                      "begin " +
                                      "    declare @itemid varchar(20); " +
                                      "declare @iCount int;  " +
                                        "select @iCount=count(itemid) from @u8.CurrentStock where cInvCode = '" + dt列表.Rows[i]["物料编码"].ToString().Trim() + "';   " +
                                        "if( @iCount > 0 ) " +
                                        "	select @itemid=itemid from @u8.CurrentStock where cInvCode = '" + dt列表.Rows[i]["物料编码"].ToString().Trim() + "';  " +
                                        "else  " +
                                        "	 select @itemid=max(itemid+1) from @u8.CurrentStock  " +
                                        "    insert into @u8.CurrentStock(cWhCode,cInvCode,iQuantity,iNum,itemid)values('" + dt列表.Rows[i]["仓库编码"].ToString().Trim() + "','" + dt列表.Rows[i]["物料编码"].ToString().Trim() + "'," + d本次入库数量 + "," + s本次入库件数 + ",@itemid) " +
                                  "end";
                            aList.Add(sSQL);


                            //int i检验单完全入库 = 0;
                            //if (d本次入库数量 == MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt列表.Rows[i]["可入库数量"]))
                            //    i检验单完全入库 = 1;

                            sSQL = " UPDATE @u8.qmcheckvoucher SET FsumQuantity=isnull(FsumQuantity,0)+ " + d本次入库数量 + ",FsumNum=isnull(FsumNum,0)+ " + s本次入库件数 + ",bpuinflag=0 " +
                                    " where ID = " + dt检验单详细信息.Rows[0]["检验单ID"].ToString().Trim();
                            aList.Add(sSQL);

                            sSQL = "update @u8.Pu_ArrivalVouchs set fValidInQuan = ISNULL(fValidInQuan,0) + " + d本次入库数量 + ",fValidInNum = ISNULL(fValidInNum,0) + " + s本次入库件数 + " " +
                                    "where Autoid = " + dt到货单.Rows[0]["Autoid"].ToString().Trim();
                            aList.Add(sSQL);


                            int i货位管理 = Chk货位管理(dt列表.Rows[i]["仓库编码"].ToString().Trim());
                            if (i货位管理 == 1)
                            {
                                decimal d货位数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt列表.Rows[i]["本次入库数量"]);
                                decimal d货位件数 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt列表.Rows[i]["本次入库件数"]);
                                string s货位件数 = "null";
                                if (d货位件数 > 0)
                                    s货位件数 = d货位件数.ToString();

                                Model.InvPosition modelPos = new BarCode.Model.InvPosition();
                                modelPos.RdsID = iIDDetail;
                                modelPos.RdID = iID;
                                modelPos.cWhCode = dt列表.Rows[i]["仓库编码"].ToString().Trim();
                                modelPos.cPosCode = dt列表.Rows[i]["货位编码"].ToString().Trim();
                                modelPos.cInvCode = dt列表.Rows[i]["物料编码"].ToString().Trim();
                                modelPos.iQuantity = d货位数量;
                                modelPos.iNum = d货位件数;
                                modelPos.cHandler = MobileBaseDLL.ClsBaseDataInfo.sUserName;
                                modelPos.dDate = d单据日期;
                                modelPos.bRdFlag = 1;
                                modelPos.cAssUnit = dt列表.Rows[i]["辅计量单位编码"].ToString().Trim();
                                modelPos.iTrackId = 0;
                                modelPos.iExpiratDateCalcu = 0;
                                modelPos.cvouchtype = "01";
                                modelPos.dVouchDate = d单据日期;

                                DAL.InvPosition dalPos = new BarCode.DAL.InvPosition();
                                sSQL = dalPos.Add(modelPos);
                                aList.Add(sSQL);

                                sSQL = @"
if exists (select * from @u8.InvPositionSum where  cInvCode = 'aaaaaaaaaa' and cWhCode = 'cccccccccc' and cPosCode = 'bbbbbbbbbb')
    update @u8.InvPositionSum set iQuantity = isnull(iQuantity,0) + dddddddddd,iNum = isnull(iNum,0) + eeeeeeeeee where cInvCode = 'aaaaaaaaaa' and cWhCode = 'cccccccccc' and cPosCode = 'bbbbbbbbbb'
else
    insert into @u8.InvPositionSum(cInvCode,cWhCode,cPosCode,iQuantity,iNum)
    values('aaaaaaaaaa','cccccccccc','bbbbbbbbbb',dddddddddd,eeeeeeeeee)
";
                                sSQL = sSQL.Replace("aaaaaaaaaa", dt列表.Rows[i]["物料编码"].ToString().Trim());
                                sSQL = sSQL.Replace("bbbbbbbbbb", dt列表.Rows[i]["货位编码"].ToString().Trim());
                                sSQL = sSQL.Replace("cccccccccc", dt列表.Rows[i]["仓库编码"].ToString().Trim());
                                sSQL = sSQL.Replace("dddddddddd", d货位数量.ToString());

                                if (modelPos.iNum == 0)
                                {
                                    sSQL = sSQL.Replace("eeeeeeeeee", "Null");
                                }
                                else
                                {
                                    sSQL = sSQL.Replace("eeeeeeeeee", modelPos.iNum.ToString());
                                }
                                aList.Add(sSQL);

                                //当一条入库单有多个货位时，置空
                                sSQL = "update @u8.rdrecords01 set cposition=N'" + dt列表.Rows[i]["货位编码"].ToString().Trim() + "' where id = " + iID + " and autoid=" + iIDDetail;
                                aList.Add(sSQL);

                                //当一条入库单有多个货位时，置空
                                sSQL = "update @u8.rdrecords01 set cposition=N'" + dt列表.Rows[i]["货位编码"].ToString().Trim() + "' where id = " + iID + " and autoid=" + iIDDetail;
                                aList.Add(sSQL);
                            }
                        }
                    }
                    #endregion

                    dt列表.Rows[i]["bUsed"] = iID;


                    #region MyRegion
                    for (int j = i + 1; j < dt列表.Rows.Count; j++)
                    {
                        if (MobileBaseDLL.ClsBaseDataInfo.ReturnLong(dt列表.Rows[j]["bUsed"]) > 0)
                        {
                            continue;
                        }
                        string[] s条形码2 = dt列表.Rows[j]["条形码"].ToString().Trim().Split('$');
                        decimal d本次入库数量2 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt列表.Rows[j]["本次入库数量"]);
                        decimal d本次入库件数2 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt列表.Rows[j]["本次入库件数"]);

                        string s行2 = "行" + (j + 1).ToString();
                        for (int k = j + 1; k < dt列表.Rows.Count; k++)
                        {
                            if (MobileBaseDLL.ClsBaseDataInfo.ReturnLong(dt列表.Rows[k]["bUsed2"]) > 0)
                            {
                                continue;
                            }

                            string[] s条形码3 = dt列表.Rows[k]["条形码"].ToString().Trim().Split('$');
                            if (s条形码3[2].Trim() == s条形码2[2].Trim())
                            {
                                d本次入库数量2 = d本次入库数量2 + MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt列表.Rows[k]["本次入库数量"]);
                                d本次入库件数2 = d本次入库件数2 + MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt列表.Rows[k]["本次入库件数"]);
                                s行2 = s行2 + "," + "行" + (k + 1).ToString();
                                dt列表.Rows[k]["bUsed2"] = k;
                            }
                        }

                        sSQL = " select cast(0 as bit) as 选择 " +
                                  "	,a.ID as 检验单ID,a.CCHECKCODE as 检验单号,a.CINSPECTCODE 报检单号,a.CINVCODE as 物料编码,a.FQUANTITY as 检验数量,a.FNUM as 检验件数" +
                                  ",a.FsumQuantity as 累计入库数量,a.FsumNum as 累计入库件数 " +
                                  "	,isnull(a.FREGQUANTITY,0) + isnull(a.FCONQUANTIY,0) as 可入库数量 " +
                                  "   ,case when c.cAssComUnitCode is null then null else isnull(a.FREGNUM,0) + isnull(a.FCONNUM,0) end as 可入库件数 " +
                                  "	," + d本次入库数量2 + " as 本次入库数量" +
                                  "   ," + d本次入库件数2 + " as 本次入库件数 " +
                                  "	,a.CPOCODE as 订单号,a.CINSPECTDEPCODE as 部门编号,a.INSPECTID as 报检单主表ID,a.INSPECTAUTOID as 报检单子表ID " +
                                  "	,a.SOURCEAUTOID as 来源单据子表ID,a.SOURCEID as 来源单据ID,a.SOURCECODE as 到货单号,a.CSOURCE as 来源类型 " +
                                  "	,a.CINSPECTDEPCODE as 业务部门编码,a.DARRIVALDATE as 到货日期 " +
                                  "	,a.CITEMCLASS as 项目大类编码 ,a.CITEMCNAME as 项目大类名称,a.CITEMCODE as 项目编码 ,a.CITEMNAME as 项目名称  " +
                                  "	,a.DDATE as 检验日期,a.CTIME as 检验时间,a.CDEPCODE as 检验部门编码,a.CVENCODE as 供应商编码,'" + dt列表.Rows[j]["仓库编码"] + "' as 仓库编码,'" + dt列表.Rows[j]["货位编码"] + "' as 货位编码 " +
                                  "   ,cast(null as varchar(50)) as 条形码,c.cAssComUnitCode as 辅助计量编码,cast(null as varchar(10)) as 单据来源,0 as bUsed,0 as bUsed2,b.AUTOID as 检验单子表ID " +
                              "from @u8.QMCHECKVOUCHER a inner join @u8.QMCHECKVOUCHERS b on a.id = b.id inner join @u8.Inventory c on a.cInvCode = c.cInvCode " +
                              "where  a.id = " + s条形码2[2].Trim() + " " +
                              "order by a.CWHCODE,a.CPOSITION,a.CINVCODE,a.CCHECKCODE ";
                        DataTable dt检验单详细信息2 = clsSQLCommond.ExecQuery(sSQL);

                        sSQL = "select cBusType,b.* from @u8.PU_ArrivalVouch a inner join @u8.PU_ArrivalVouchs b on a.id = b.id where b.autoid = " + dt检验单详细信息2.Rows[0]["来源单据子表ID"].ToString().Trim();
                        DataTable dt到货单2 = clsSQLCommond.ExecQuery(sSQL);
                        if (dt到货单2 == null || dt到货单2.Rows.Count < 1)
                        {
                            dt列表.Rows[j]["返回信息"] = "未能查出单据类型";
                            s错误 = s错误 + "行" + (i + 1).ToString() + "未能查出单据类型\r\n";
                        }

                        if (s错误.Trim() != "")
                        {
                            return s错误;
                        }


                        dt列表.Rows[j]["单据来源"] = dt到货单2.Rows[0]["cBusType"].ToString().Trim();
                        dt列表.Rows[j]["bUsed"] = 0;

                        if (dt检验单详细信息.Rows[0]["仓库编码"].ToString().Trim() == dt检验单详细信息2.Rows[0]["仓库编码"].ToString().Trim()
                                && dt检验单详细信息.Rows[0]["供应商编码"].ToString().Trim() == dt检验单详细信息2.Rows[0]["供应商编码"].ToString().Trim()
                                && dt检验单详细信息.Rows[0]["部门编号"].ToString().Trim() == dt检验单详细信息2.Rows[0]["部门编号"].ToString().Trim()
                                && dt列表.Rows[i]["单据来源"].ToString().Trim() == dt列表.Rows[j]["单据来源"].ToString().Trim())
                        {
                            decimal d可入库数量2 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt检验单详细信息2.Rows[0]["可入库数量"]);
                            decimal d可入库件数2 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt检验单详细信息2.Rows[0]["可入库件数"]);
                            decimal d累计入库数量2 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt检验单详细信息2.Rows[0]["累计入库数量"]);
                            decimal d累计入库件数2 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt检验单详细信息2.Rows[0]["累计入库件数"]);
                            if (d可入库数量2 < d本次入库数量2 + d累计入库数量2)
                            {
                                dt列表.Rows[j]["返回信息"] = "超出数量，不能入库";
                                if (s错误.Trim() == "")
                                {
                                    s错误 = s错误 + (j + 1).ToString() + "超出数量，不能入库\r\n";
                                }
                                else
                                {
                                    s错误 = s错误 + "," + (j + 1).ToString() + "超出数量，不能入库\r\n";
                                }
                            }

                            string s本次入库件数2 = "null";
                            if (d本次入库件数2 > 0)
                            {
                                s本次入库件数2 = d本次入库件数2.ToString().Trim();
                            }

                            #region 普通采购

                            if (dt列表.Rows[j]["单据来源"].ToString().Trim() == "普通采购")
                            {
                                if (MobileBaseDLL.ClsBaseDataInfo.ReturnLong(dt列表.Rows[j]["bUsed2"]) == 0)
                                {
                                    iIDDetail += 1;

                                    //税率
                                    decimal d税率2 = decimal.Round(Convert.ToDecimal(dt到货单2.Rows[0]["iTaxRate"]), 2);
                                    //单价(不含税)
                                    decimal d无税单价2 = decimal.Round(Convert.ToDecimal(dt到货单2.Rows[0]["iOriCost"]), 6);
                                    //金额(不含税)
                                    decimal d无税金额2 = decimal.Round(d无税单价2 * d本次入库数量2, 2);
                                    //原币含税单价
                                    decimal d含税单价2 = decimal.Round(Convert.ToDecimal(dt到货单2.Rows[0]["iOriTaxCost"]), 6);
                                    //原币价税合计
                                    decimal d价税合计2 = decimal.Round(d含税单价2 * decimal.Round(d本次入库数量2, 6), 2);
                                    //原币税额 
                                    decimal d税额2 = d价税合计2 - d无税金额2;


                                    string s换算率 = dt到货单2.Rows[0]["iinvexchrate"].ToString().Trim();
                                    if (s换算率 == "")
                                        s换算率 = "null";

                                    sSQL = "Insert Into @u8.rdrecords01(autoid,id,cinvcode,inum,iquantity,iunitcost,iprice,iaprice,ipunitcost,ipprice" +
                                                ",cbatch,cvouchcode,cfree1,cfree2,dsdate,itax,isquantity,isnum,imoney,isoutquantity" +
                                                ",isoutnum,ifnum,ifquantity,dvdate,cposition,cdefine22,cdefine23,cdefine24,cdefine25" +
                                                ",cdefine26,cdefine27,citem_class,citemcode,iposid,facost,cname,citemcname,cfree3,cfree4" +
                                                ",cfree5,cfree6,cfree7,cfree8,cfree9,cfree10,cbarcode,inquantity,innum,cassunit" +
                                                ",dmadedate,imassdate,cdefine28,cdefine29,cdefine30,cdefine31,cdefine32,cdefine33,cdefine34,cdefine35" +
                                                ",cdefine36,cdefine37,icheckids,cbvencode,cinvouchcode,cgspstate,iarrsid,ccheckcode,icheckidbaks" +
                                                ",crejectcode,irejectids,ccheckpersoncode,dcheckdate,ioritaxcost,ioricost,iorimoney,ioritaxprice,iorisum,itaxrate" +
                                                ",itaxprice,isum,btaxcost,cpoid,cmassunit,imaterialfee,iprocesscost,iprocessfee,dmsdate,ismaterialfee" +
                                                ",isprocessfee,iomodid,iorderdid,strcontractid,strcode,iordertype,cbaccounter,bcosting,isumbillquantity,bvmiused" +
                                                ",ivmisettlequantity,ivmisettlenum,cvmivencode,iinvsncount,impcost,iimosid,iimbsid,cbarvcode,dbarvdate,iinvexchrate" +
                                                ",iordercode,iorderseq,corufts,iexpiratdatecalcu,cexpirationdate,dexpirationdate,cciqbookcode,ibondedsumqty,isodid,isotype" +
                                                ",csocode,isoseq,cbatchproperty1,cbatchproperty2,cbatchproperty3,cbatchproperty4,cbatchproperty5,cbatchproperty6,cbatchproperty7,cbatchproperty8" +
                                                ",cbatchproperty9,cbatchproperty10) " +
                                            "Values (" + iIDDetail + "," + iID + ",N'" + dt列表.Rows[j]["物料编码"].ToString().Trim() + "'," + s本次入库件数2 + "," + d本次入库数量2 + "," + d无税单价2 + "," + d无税金额2 + "," + d无税金额2 + ",Null,Null" +
                                                ",Null,Null,Null,Null,Null,null,0,0,0,Null" +
                                                ",Null,Null,Null,Null,Null,Null,Null,Null,Null" +
                                                ",Null,Null,N'00',N'" + dt列表.Rows[j]["项目编码"].ToString().Trim() + "'," + dt到货单.Rows[0]["iPOsID"].ToString().Trim() + "," + d无税单价2 + ",N'" + dt列表.Rows[j]["项目编码"].ToString().Trim() + "',N'外销订单项目',Null,Null" +
                                                ",Null,Null,Null,Null,Null,Null,Null,Null,Null,N'" + dt列表.Rows[j]["辅计量单位编码"].ToString().Trim() + "'" +
                                                ",Null,Null,Null,Null,Null,Null,Null,Null,Null,Null" +
                                                ",Null,Null,Null,Null,Null,Null," + dt到货单2.Rows[0]["Autoid"].ToString().Trim() + ",N'" + dt列表.Rows[j]["检验单号"].ToString().Trim() + "'," + dt检验单详细信息2.Rows[0]["检验单子表ID"].ToString().Trim() + " " +
                                                ",Null,Null,Null,N'" + dt检验单详细信息2.Rows[0]["检验日期"].ToString().Trim() + "'," + d含税单价2 + "," + d无税单价2 + "," + d无税金额2 + "," + d税额2 + "," + d价税合计2 + "," + d税率2 + " " +
                                                "," + d税额2 + "," + d价税合计2 + ",0,N'" + dt到货单2.Rows[0]["cordercode"].ToString().Trim() + "',Null,Null,Null,Null,Null,Null" +
                                                ",Null,Null,Null,Null,Null,Null,Null,1,Null,Null" +
                                                ",Null,Null,Null,Null,Null,Null,Null,N'" + dt检验单详细信息2.Rows[0]["到货单号"].ToString().Trim() + "',N'" + dt检验单详细信息2.Rows[0]["到货日期"].ToString().Trim() + "'," + s换算率 + " " +
                                                ",Null,Null,N'13959.6528',null,Null,Null,Null,Null,Null,Null" +
                                                ",Null,Null,Null,Null,Null,Null,Null,Null,Null,Null" +
                                                ",Null,Null)";
                                    aList.Add(sSQL);

                                    sSQL = "update @u8.rdrecords01 set iOriCost = CAST(iOriTaxCost / {0} as decimal(16,6)) " +
                                                 ",iOriMoney =  CAST( CAST(iOriTaxCost / {0} as decimal(16,6)) * iQuantity as decimal(16,2)) " +
                                                 ",ioriSum = CAST(iOriTaxCost * iQuantity as decimal(16,2))  " +
                                                 ",iOriTaxPrice =   CAST(iOriTaxCost * iQuantity as decimal(16,2)) -  CAST( CAST(iOriTaxCost / {0} as decimal(16,6)) * iQuantity as decimal(16,2)) " +
                                                 ",iUnitCost = CAST(iOriTaxCost / {0} as decimal(16,6)) " +
                                                 ",iPrice =  CAST( CAST(iOriTaxCost / {0} as decimal(16,6)) * iQuantity as decimal(16,2)) " +
                                                 ",iTax =  CAST(iOriTaxCost * iQuantity as decimal(16,2)) -  CAST( CAST(iOriTaxCost / {0} as decimal(16,6)) * iQuantity as decimal(16,2)) " +
                                                 ",iTaxPrice = CAST(iOriTaxCost * iQuantity as decimal(16,2)) -  CAST( CAST(iOriTaxCost / {0} as decimal(16,6)) * iQuantity as decimal(16,2))" +
                                             "where autoid = " + iIDDetail;
                                    sSQL = string.Format(sSQL, "1." + iTaxRate_All.ToString());
                                    aList.Add(sSQL);

                                    sSQL = "if exists(select * from  @u8.CurrentStock where cInvCode = '" + dt列表.Rows[j]["物料编码"].ToString().Trim() + "' and cWhCode = '" + dt列表.Rows[j]["仓库编码"].ToString().Trim() + "') " +
                                                "update  @u8.CurrentStock set iQuantity = isnull(iQuantity,0) + " + d本次入库数量2 + " ,iNum = isnull(iNum,0) + " + s本次入库件数2 + " where cInvCode = '" + dt列表.Rows[j]["物料编码"].ToString().Trim() + "' and cWhCode = '" + dt列表.Rows[j]["仓库编码"].ToString().Trim() + "' " +
                                          "else " +
                                              "begin " +
                                              "    declare @itemid varchar(20); " +
                                              "declare @iCount int;  " +
                                                "select @iCount=count(itemid) from @u8.CurrentStock where cInvCode = '" + dt列表.Rows[j]["物料编码"].ToString().Trim() + "';   " +
                                                "if( @iCount > 0 ) " +
                                                "	select @itemid=itemid from @u8.CurrentStock where cInvCode = '" + dt列表.Rows[j]["物料编码"].ToString().Trim() + "';  " +
                                                "else  " +
                                                "	 select @itemid=max(itemid+1) from @u8.CurrentStock  " +
                                                "    insert into @u8.CurrentStock(cWhCode,cInvCode,iQuantity,iNum,itemid)values('" + dt列表.Rows[j]["仓库编码"].ToString().Trim() + "','" + dt列表.Rows[j]["物料编码"].ToString().Trim() + "'," + d本次入库数量2 + "," + s本次入库件数2 + ",@itemid) " +
                                          "end";
                                    aList.Add(sSQL);

                                    sSQL = " UPDATE @u8.qmcheckvoucher SET FsumQuantity=isnull(FsumQuantity,0)+ " + d本次入库数量2 + ",FsumNum=isnull(FsumNum,0)+ " + s本次入库件数2 + ",bpuinflag=0 " +
                                            " where ID = " + dt检验单详细信息2.Rows[0]["检验单ID"].ToString().Trim();
                                    aList.Add(sSQL);

                                    sSQL = "update @u8.Pu_ArrivalVouchs set fValidInQuan = ISNULL(fValidInQuan,0) + " + d本次入库数量2 + ",fValidInNum = ISNULL(fValidInNum,0) +  " + s本次入库件数2 + " " +
                                            "where Autoid = " + dt到货单2.Rows[0]["Autoid"].ToString().Trim();
                                    aList.Add(sSQL);
                                    int i货位管理 = Chk货位管理(dt列表.Rows[j]["仓库编码"].ToString().Trim());
                                    if (i货位管理 == 1)
                                    {
                                        decimal d货位数量2 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt列表.Rows[j]["本次入库数量"]);
                                        decimal d货位件数2 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt列表.Rows[j]["本次入库件数"]);
                                        string s货位件数2 = "null";
                                        if (d货位件数2 > 0)
                                            s货位件数2 = d货位件数2.ToString();

                                        Model.InvPosition modelPos = new BarCode.Model.InvPosition();
                                        modelPos.RdsID = iIDDetail;
                                        modelPos.RdID = iID;
                                        modelPos.cWhCode = dt列表.Rows[i]["仓库编码"].ToString().Trim();
                                        modelPos.cPosCode = dt列表.Rows[i]["货位编码"].ToString().Trim();
                                        modelPos.cInvCode = dt列表.Rows[i]["物料编码"].ToString().Trim();
                                        modelPos.iQuantity = d货位数量2;
                                        modelPos.iNum = d货位件数2;
                                        modelPos.cHandler = MobileBaseDLL.ClsBaseDataInfo.sUserName;
                                        modelPos.dDate = d单据日期;
                                        modelPos.bRdFlag = 1;
                                        modelPos.cAssUnit = dt列表.Rows[i]["辅计量单位编码"].ToString().Trim();
                                        modelPos.iTrackId = 0;
                                        modelPos.iExpiratDateCalcu = 0;
                                        modelPos.cvouchtype = "01";
                                        modelPos.dVouchDate = d单据日期;

                                        DAL.InvPosition dalPos = new BarCode.DAL.InvPosition();
                                        sSQL = dalPos.Add(modelPos);
                                        aList.Add(sSQL);

                                        sSQL = @"
if exists (select * from @u8.InvPositionSum where  cInvCode = 'aaaaaaaaaa' and cWhCode = 'cccccccccc' and cPosCode = 'bbbbbbbbbb')
    update @u8.InvPositionSum set iQuantity = isnull(iQuantity,0) + dddddddddd,iNum = isnull(iNum,0) + eeeeeeeeee where cInvCode = 'aaaaaaaaaa' and cWhCode = 'cccccccccc' and cPosCode = 'bbbbbbbbbb'
else
    insert into @u8.InvPositionSum(cInvCode,cWhCode,cPosCode,iQuantity,iNum)
    values('aaaaaaaaaa','cccccccccc','bbbbbbbbbb',dddddddddd,eeeeeeeeee)
";
                                        sSQL = sSQL.Replace("aaaaaaaaaa", dt列表.Rows[i]["物料编码"].ToString().Trim());
                                        sSQL = sSQL.Replace("bbbbbbbbbb", dt列表.Rows[i]["货位编码"].ToString().Trim());
                                        sSQL = sSQL.Replace("cccccccccc", dt列表.Rows[i]["仓库编码"].ToString().Trim());
                                        sSQL = sSQL.Replace("dddddddddd", d货位数量2.ToString());

                                        if (modelPos.iNum == 0)
                                        {
                                            sSQL = sSQL.Replace("eeeeeeeeee", "Null");
                                        }
                                        else
                                        {
                                            sSQL = sSQL.Replace("eeeeeeeeee", modelPos.iNum.ToString());
                                        }
                                        aList.Add(sSQL);

                                        //当一条入库单有多个货位时，置空
                                        sSQL = "update @u8.rdrecords01 set cposition=N'" + dt列表.Rows[j]["货位编码"].ToString().Trim() + "' where id = " + iID + " and autoid=" + iIDDetail;
                                        aList.Add(sSQL);
                                    }
                                }
                            }
                            #endregion

                            #region 委外加工

                            if (dt列表.Rows[i]["单据来源"].ToString().Trim() == "委外加工")
                            {
                                if (MobileBaseDLL.ClsBaseDataInfo.ReturnLong(dt列表.Rows[j]["bUsed2"]) == 0)
                                {
                                    iIDDetail += 1;

                                    //税率
                                    decimal d税率2 = decimal.Round(Convert.ToDecimal(dt到货单2.Rows[0]["iTaxRate"]), 2);
                                    //单价(不含税)
                                    decimal d无税单价2 = decimal.Round(Convert.ToDecimal(dt到货单2.Rows[0]["iOriCost"]), 6);
                                    //金额(不含税)
                                    decimal d无税金额2 = decimal.Round(d无税单价2 * d本次入库数量2, 2);
                                    //原币含税单价
                                    decimal d含税单价2 = decimal.Round(Convert.ToDecimal(dt到货单2.Rows[0]["iOriTaxCost"]), 6);
                                    //原币价税合计
                                    decimal d价税合计2 = decimal.Round(d含税单价2 * decimal.Round(d本次入库数量2, 6), 2);
                                    //原币税额 
                                    decimal d税额2 = d价税合计2 - d无税金额2;

                                    string s换算率 = dt到货单2.Rows[0]["iinvexchrate"].ToString().Trim();
                                    if (s换算率 == "")
                                        s换算率 = "null";

                                    sSQL = "Insert Into @u8.rdrecords01(autoid,id,cinvcode,inum,iquantity,iunitcost,iprice,iaprice,ipunitcost,ipprice" +
                                                ",cbatch,cvouchcode,cfree1,cfree2,dsdate,itax,isquantity,isnum,imoney,isoutquantity" +
                                                ",isoutnum,ifnum,ifquantity,dvdate,cposition,cdefine22,cdefine23,cdefine24,cdefine25" +
                                                ",cdefine26,cdefine27,citem_class,citemcode,iposid,facost,cname,citemcname,cfree3,cfree4" +
                                                ",cfree5,cfree6,cfree7,cfree8,cfree9,cfree10,cbarcode,inquantity,innum,cassunit" +
                                                ",dmadedate,imassdate,cdefine28,cdefine29,cdefine30,cdefine31,cdefine32,cdefine33,cdefine34,cdefine35" +
                                                ",cdefine36,cdefine37,icheckids,cbvencode,cinvouchcode,cgspstate,iarrsid,ccheckcode,icheckidbaks" +
                                                ",crejectcode,irejectids,ccheckpersoncode,dcheckdate,ioritaxcost,ioricost,iorimoney,ioritaxprice,iorisum,itaxrate" +
                                                ",itaxprice,isum,btaxcost,cpoid,cmassunit,imaterialfee,iprocesscost,iprocessfee,dmsdate,ismaterialfee" +
                                                ",isprocessfee,iomodid,iorderdid,strcontractid,strcode,iordertype,cbaccounter,bcosting,isumbillquantity,bvmiused" +
                                                ",ivmisettlequantity,ivmisettlenum,cvmivencode,iinvsncount,impcost,iimosid,iimbsid,cbarvcode,dbarvdate,iinvexchrate" +
                                                ",iordercode,iorderseq,corufts,iexpiratdatecalcu,cexpirationdate,dexpirationdate,cciqbookcode,ibondedsumqty,isodid,isotype" +
                                                ",csocode,isoseq,cbatchproperty1,cbatchproperty2,cbatchproperty3,cbatchproperty4,cbatchproperty5,cbatchproperty6,cbatchproperty7,cbatchproperty8" +
                                                ",cbatchproperty9,cbatchproperty10) " +
                                            "Values (" + iIDDetail + "," + iID + ",N'" + dt列表.Rows[j]["物料编码"].ToString().Trim() + "'," + s本次入库件数2 + "," + d本次入库数量2 + "," + d无税单价2 + "," + d无税金额2 + "," + d无税金额2 + ",Null,Null" +
                                                ",Null,Null,Null,Null,Null,null,0,0,0,Null" +
                                                ",Null,Null,Null,Null,Null,Null,Null,Null,Null" +
                                                ",Null,Null,N'00',N'" + dt列表.Rows[j]["项目编码"].ToString().Trim() + "'," + dt到货单.Rows[0]["iPOsID"].ToString().Trim() + "," + d无税单价2 + ",N'" + dt列表.Rows[j]["项目编码"].ToString().Trim() + "',N'外销订单项目',Null,Null" +
                                                ",Null,Null,Null,Null,Null,Null,Null,Null,Null,N'" + dt列表.Rows[j]["辅计量单位编码"].ToString().Trim() + "'" +
                                                ",Null,Null,Null,Null,Null,Null,Null,Null,Null,Null" +
                                                ",Null,Null,Null,Null,Null,Null," + dt到货单2.Rows[0]["Autoid"].ToString().Trim() + ",N'" + dt列表.Rows[j]["检验单号"].ToString().Trim() + "'," + dt检验单详细信息2.Rows[0]["检验单子表ID"].ToString().Trim() + " " +
                                                ",Null,Null,Null,N'" + dt检验单详细信息2.Rows[0]["检验日期"].ToString().Trim() + "'," + d含税单价2 + "," + d无税单价2 + "," + d无税金额2 + "," + d税额2 + "," + d价税合计2 + "," + d税率2 + " " +
                                                "," + d税额2 + "," + d价税合计2 + ",0,N'" + dt到货单2.Rows[0]["cordercode"].ToString().Trim() + "',Null,Null,Null,Null,Null,Null" +
                                                ",Null," + dt到货单.Rows[0]["iPOsID"].ToString().Trim() + ",Null,Null,Null,Null,Null,1,Null,Null" +
                                                ",Null,Null,Null,Null,Null,Null,Null,N'" + dt检验单详细信息2.Rows[0]["到货单号"].ToString().Trim() + "',N'" + dt检验单详细信息2.Rows[0]["到货日期"].ToString().Trim() + "'," + s换算率 + " " +
                                                ",Null,Null,N'13959.6528',null,Null,Null,Null,Null,Null,Null" +
                                                ",Null,Null,Null,Null,Null,Null,Null,Null,Null,Null" +
                                                ",Null,Null)";
                                    aList.Add(sSQL);

                                    sSQL = "update @u8.rdrecords01 set iOriCost = CAST(iOriTaxCost / {0} as decimal(16,6)) " +
                                                  ",iOriMoney =  CAST( CAST(iOriTaxCost / {0} as decimal(16,6)) * iQuantity as decimal(16,2)) " +
                                                  ",ioriSum = CAST(iOriTaxCost * iQuantity as decimal(16,2))  " +
                                                  ",iOriTaxPrice =   CAST(iOriTaxCost * iQuantity as decimal(16,2)) -  CAST( CAST(iOriTaxCost / {0} as decimal(16,6)) * iQuantity as decimal(16,2)) " +
                                                  ",iUnitCost = CAST(iOriTaxCost / {0} as decimal(16,6)) " +
                                                  ",iPrice =  CAST( CAST(iOriTaxCost / {0} as decimal(16,6)) * iQuantity as decimal(16,2)) " +
                                                  ",iTax =  CAST(iOriTaxCost * iQuantity as decimal(16,2)) -  CAST( CAST(iOriTaxCost / {0} as decimal(16,6)) * iQuantity as decimal(16,2)) " +
                                                  ",iTaxPrice = CAST(iOriTaxCost * iQuantity as decimal(16,2)) -  CAST( CAST(iOriTaxCost / {0} as decimal(16,6)) * iQuantity as decimal(16,2))" +
                                                  ",iProcessCost =  CAST(iOriTaxCost / {0} as decimal(16,6)) " +
                                                  ",iProcessFee = CAST( CAST(iOriTaxCost / {0} as decimal(16,6)) * iQuantity as decimal(16,2)) " +
                                            "where autoid = " + iIDDetail;

                                    sSQL = string.Format(sSQL, "1." + iTaxRate_All.ToString()); 
                                    aList.Add(sSQL);

                                    sSQL = "if exists(select * from  @u8.CurrentStock where cInvCode = '" + dt列表.Rows[j]["物料编码"].ToString().Trim() + "' and cWhCode = '" + dt列表.Rows[j]["仓库编码"].ToString().Trim() + "') " +
                                                "update  @u8.CurrentStock set iQuantity = isnull(iQuantity,0) + " + d本次入库数量2 + " ,iNum = isnull(iNum,0) + " + s本次入库件数2 + " where cInvCode = '" + dt列表.Rows[j]["物料编码"].ToString().Trim() + "' and cWhCode = '" + dt列表.Rows[j]["仓库编码"].ToString().Trim() + "' " +
                                          "else " +
                                              "begin " +
                                              "    declare @itemid varchar(20); " +
                                              "declare @iCount int;  " +
                                                "select @iCount=count(itemid) from @u8.CurrentStock where cInvCode = '" + dt列表.Rows[j]["物料编码"].ToString().Trim() + "';   " +
                                                "if( @iCount > 0 ) " +
                                                "	select @itemid=itemid from @u8.CurrentStock where cInvCode = '" + dt列表.Rows[j]["物料编码"].ToString().Trim() + "';  " +
                                                "else  " +
                                                "	 select @itemid=max(itemid+1) from @u8.CurrentStock  " +
                                                "    insert into @u8.CurrentStock(cWhCode,cInvCode,iQuantity,iNum,itemid)values('" + dt列表.Rows[j]["仓库编码"].ToString().Trim() + "','" + dt列表.Rows[j]["物料编码"].ToString().Trim() + "'," + d本次入库数量2 + "," + s本次入库件数2 + ",@itemid) " +
                                          "end";
                                    aList.Add(sSQL);


                                    sSQL = " UPDATE @u8.qmcheckvoucher SET FsumQuantity=isnull(FsumQuantity,0)+ " + d本次入库数量2 + ",FsumNum=isnull(FsumNum,0)+ " + s本次入库件数2 + ",bpuinflag=0 " +
                                            " where ID = " + dt检验单详细信息2.Rows[0]["检验单ID"].ToString().Trim();
                                    aList.Add(sSQL);

                                    sSQL = "update @u8.Pu_ArrivalVouchs set fValidInQuan = ISNULL(fValidInQuan,0) + " + d本次入库数量2 + ",fValidInNum = ISNULL(fValidInNum,0) +  " + s本次入库件数2 + " " +
                                            "where Autoid = " + dt到货单2.Rows[0]["Autoid"].ToString().Trim();
                                    aList.Add(sSQL);

                                    int i货位管理 = Chk货位管理(dt列表.Rows[j]["仓库编码"].ToString().Trim());
                                    if (i货位管理 == 1)
                                    {
                                        decimal d货位数量2 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt列表.Rows[j]["本次入库数量"]);
                                        decimal d货位件数2 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt列表.Rows[j]["本次入库件数"]);
                                        string s货位件数2 = "null";
                                        if (d货位件数2 > 0)
                                            s货位件数2 = d货位件数2.ToString();

                                        Model.InvPosition modelPos = new BarCode.Model.InvPosition();
                                        modelPos.RdsID = iIDDetail;
                                        modelPos.RdID = iID;
                                        modelPos.cWhCode = dt列表.Rows[i]["仓库编码"].ToString().Trim();
                                        modelPos.cPosCode = dt列表.Rows[i]["货位编码"].ToString().Trim();
                                        modelPos.cInvCode = dt列表.Rows[i]["物料编码"].ToString().Trim();
                                        modelPos.iQuantity = d货位数量2;
                                        modelPos.iNum = d货位件数2;
                                        modelPos.cHandler = MobileBaseDLL.ClsBaseDataInfo.sUserName;
                                        modelPos.dDate = d单据日期;
                                        modelPos.bRdFlag = 1;
                                        modelPos.cAssUnit = dt列表.Rows[i]["辅计量单位编码"].ToString().Trim();
                                        modelPos.iTrackId = 0;
                                        modelPos.iExpiratDateCalcu = 0;
                                        modelPos.cvouchtype = "01";
                                        modelPos.dVouchDate = d单据日期;

                                        DAL.InvPosition dalPos = new BarCode.DAL.InvPosition();
                                        sSQL = dalPos.Add(modelPos);
                                        aList.Add(sSQL);

                                        sSQL = @"
if exists (select * from @u8.InvPositionSum where  cInvCode = 'aaaaaaaaaa' and cWhCode = 'cccccccccc' and cPosCode = 'bbbbbbbbbb')
    update @u8.InvPositionSum set iQuantity = isnull(iQuantity,0) + dddddddddd,iNum = isnull(iNum,0) + eeeeeeeeee where cInvCode = 'aaaaaaaaaa' and cWhCode = 'cccccccccc' and cPosCode = 'bbbbbbbbbb'
else
    insert into @u8.InvPositionSum(cInvCode,cWhCode,cPosCode,iQuantity,iNum)
    values('aaaaaaaaaa','cccccccccc','bbbbbbbbbb',dddddddddd,eeeeeeeeee)
";
                                        sSQL = sSQL.Replace("aaaaaaaaaa", dt列表.Rows[i]["物料编码"].ToString().Trim());
                                        sSQL = sSQL.Replace("bbbbbbbbbb", dt列表.Rows[i]["货位编码"].ToString().Trim());
                                        sSQL = sSQL.Replace("cccccccccc", dt列表.Rows[i]["仓库编码"].ToString().Trim());
                                        sSQL = sSQL.Replace("dddddddddd", d货位数量2.ToString());

                                        if (modelPos.iNum == 0)
                                        {
                                            sSQL = sSQL.Replace("eeeeeeeeee", "Null");
                                        }
                                        else
                                        {
                                            sSQL = sSQL.Replace("eeeeeeeeee", modelPos.iNum.ToString());
                                        }
                                        aList.Add(sSQL);

                                        //当一条入库单有多个货位时，置空
                                        sSQL = "update @u8.rdrecords01 set cposition=N'" + dt列表.Rows[j]["货位编码"].ToString().Trim() + "' where id = " + iID + " and autoid=" + iIDDetail;
                                        aList.Add(sSQL);
                                    }
                                }
                            }
                            #endregion

                            dt列表.Rows[j]["bUsed"] = iID;
                        }
                    }
                    #endregion
                }

                sSQL = "update @u8.QMCHECKVOUCHER set bpuinflag = 1 where ID in " +
                        "	(" +
                        "		select ID" +
                        "		from @u8.QMCHECKVOUCHER " +
                        "		where isnull(FsumQuantity,0) >= ISNULL(FREGQUANTITY,0) + ISNULL(FCONQUANTIY,0)" +
                        "			and isnull(bpuinflag,0) <> 1 and isnull(FsumQuantity,0)<> 0" +
                        "	)";
                aList.Add(sSQL);

                if (iID > 1000000000)
                {
                    iID = iID - 1000000000;
                    iIDDetail = iIDDetail - 1000000000;
                }
                sSQL = "update UFSystem..UA_Identity set iFatherID = " + iID + ",iChildID=" + iIDDetail + "  where cAcc_Id = '200' and cVouchType = 'rd'";
                aList.Add(sSQL);

                //更改最大单据号
                sSQL = "select count(*) as iCount From @u8.VoucherHistory  with (NOLOCK) Where CardNumber='24' and (cContent='日期' or cContent='单据日期') and (cSeed='" + d单据日期.ToString("yyyyMM") + "' or cSeed='" + d单据日期.ToString("yyMM") + "')";
                DataTable dtCodeTemp = clsSQLCommond.ExecQuery(sSQL);
                if (dtCodeTemp.Rows[0]["iCount"].ToString().Trim() == "0")
                {
                    sSQL = "insert into @u8.VoucherHistory(cardnumber,ccontent,ccontentrule,cseed,cnumber,bempty)values('24','日期','月','" + d单据日期.ToString("yyMM") + "','1',0)";
                    aList.Add(sSQL);
                }
                else
                {
                    sSQL = "update @u8.VoucherHistory set cNumber = '" + iCode.ToString().Trim() + "' Where CardNumber='24' and (cContent='日期' or cContent='单据日期') and (cSeed='" + d单据日期.ToString("yyyyMM") + "' or cSeed='" + d单据日期.ToString("yyMM") + "')";
                    aList.Add(sSQL);
                }

                if (aList单据号id.Count > 0)
                {
                    for (int i = 0; i < aList单据号id.Count; i++)
                    {
                        sSQL = "exec @u8.IA_SP_WriteUnAccountVouchForST 'aaaaaaaa',N'01'";
                        sSQL = sSQL.Replace("aaaaaaaa", aList单据号id[i].ToString());
                        aList.Add(sSQL);
                    }
                }

                if (s错误.Trim() != "")
                {
                    return "存在错误，不能导入，行号如下：" + s错误;
                }
                clsSQLCommond.ExecSqlTran(aList);
                sReturn = "成功生成入库单：\r\n" + s单据号;
            }
            catch (Exception ee)
            {
                sReturn = ee.Message;
            }
            return sReturn;
        }


        /// <summary>
        /// 获得单据ID
        /// </summary>
        /// <param name="sType">单据类型  PuArrival，</param>
        private void GetID(string sType, out long iID, out long iIDDetail)
        {
            //string sSQL = "select iFatherID,iChildID from UFSystem..UA_Identity where cAcc_Id = '200' and cVouchType = '" + sType + "'";


            string sSQL = @"
declare @p5 int
set @p5=1000589146
declare @p6 int
set @p6=1003092055
exec @u8.sp_GetId N'',N'200',N'rd',1,@p5 output,@p6 output,default
select @p5, @p6
";


            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            if (dt == null || dt.Rows.Count < 1)
            {
                iID = 0;
                iIDDetail = 0;
            }
            else
            {
                iID = Convert.ToInt64(dt.Rows[0][0]) - 1;
                iIDDetail = Convert.ToInt64(dt.Rows[0][1]) - 1;
            }
        }

        /// <summary>
        /// 返回入库单单据号
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        private string sSetCode(long s, DateTime date1)
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

            return "IP" + date1.ToString("yyMM") + sCode;
        }

        private int Chk货位管理(string sWhCode)
        {
            int i = -1;
            try
            {
                string sSQL = "select isnull(bWhPos,0) as bWhPos from @u8.Warehouse where cWhCode = '" + sWhCode + "'";
                i = MobileBaseDLL.ClsBaseDataInfo.ReturnBoolToInt(clsSQLCommond.ExecGetScalar(sSQL));
            }
            catch { }
            return i;
        }
    }
}
