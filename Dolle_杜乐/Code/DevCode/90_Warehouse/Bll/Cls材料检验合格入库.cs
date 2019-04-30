using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Collections;

namespace TH.DBWebService
{
    public class Cls材料检验合格入库 : FrameBaseFunction.ClsDataBase
    {
        FrameBaseFunction.ClsDES clsDES = FrameBaseFunction.ClsDES.Instance();
        FrameBaseFunction.ClsSQLServerCommond clsSQLCommond = new FrameBaseFunction.ClsSQLServerCommond();

        ArrayList aList;

        public DataTable GetBarArrInfo(string sBarCode)
        {
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
                    sSQL = " select cast(null as varchar(50)) as 返回信息 " +
                                 "	,a.CCHECKCODE as 检验单号,a.CINVCODE as 物料编码,c.cInvName as 物料名称,c.cInvStd as 规格型号,a.FQUANTITY as 检验数量,a.FNUM as 检验件数 " +
                                 "	,isnull(a.FREGQUANTITY,0) + isnull(a.FCONQUANTIY,0) as 可入库数量 " +
                                 "   ,case when c.cAssComUnitCode is null then null else isnull(a.FREGNUM,0) + isnull(a.FCONNUM,0) end as 可入库件数 " +
                                 "	," + s[3].Trim() + " as 本次入库数量" +
                                 "   ," + s[4].Trim() + "as 本次入库件数 " +
                                 ",a.CITEMCODE as 项目编码 " +
                                 "   ,'" + sBarCode + "' as 条形码,cast(null as varchar(50)) as 仓库编码,cast(null as varchar(50)) as 货位编码 " +
                             "from @u8.QMCHECKVOUCHER a inner join @u8.QMCHECKVOUCHERs b on a.id = b.id inner join @u8.Inventory c on a.cInvCode = c.cInvCode " +
                             "where  isnull(a.FREGQUANTITY,0) + isnull(a.FCONQUANTIY,0) > isnull(a.FsumQuantity,0) and a.IVERIFYSTATE = 1 " +
                                "  and  a.ID = " + s[2].Trim();
                }

                dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count != 1)
                {
                    dt = null;
                }

                decimal d可入库数量 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dt.Rows[0]["可入库数量"]);
                decimal d可入库件数 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dt.Rows[0]["可入库件数"]);
                decimal d本次入库数量 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dt.Rows[0]["本次入库数量"]);
                decimal d本次入库件数 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dt.Rows[0]["本次入库件数"]);

                if (d本次入库数量 > d可入库数量)
                {
                    dt.Rows[0]["返回信息"] = "入库数量已经超出，请核查！";
                }
            }
            catch (Exception ee)
            {
                dt = null;
            }

            return dt;
        }

        public int Chk货位物料(string s货位, string s物料)
        {
            int i = -1;
            try
            {
                string sSQL = "select a.入库货位 as 货位编码,b.cPosName as 货位,c.cWhCode as 仓库编码,c.cWhName as 仓库 " +
                        "from dbo.物料货位对照 a left join @u8.Position b on a.到货货位 = b.cPosCode" +
                        "	left join @u8.Warehouse c on c.cWhCode = b.cWhCode " +
                        "where 物料编码 = '" + s物料 + "' and a.到货货位 = '" + s货位 + "'";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                if (dt != null && dt.Rows.Count > 0)
                    i = dt.Rows.Count;
            }
            catch
            { }
            return i;
        }

        public DataTable Chk货位(string s货位)
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "货位编号";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "货位";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "仓库编码";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "仓库";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "返回信息";
            dt.Columns.Add(dc);

            try
            {
                string sSQL = "select a.cPosCode as 货位编码,a.cPosName as 货位,b.cWhCode as 仓库编码,b.cWhName as 仓库,cast(null as varchar(50)) as  返回信息 " +
                                "from @u8.Position a left join @u8.Warehouse  b on a.cWhCode = b.cWhCode " +
                                "where a.cPosCode = '" + s货位 + "' " +
                                "order by a.cWhCode,a.cPosCode";
                dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count < 1)
                {
                    throw new Exception("该货位不存在");
                }
            }
            catch
            {
                DataRow dr = dt.NewRow();
                dr["返回信息"] = "检查货位信息失败";
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public DataTable Get默认入库货位(string sInvCode)
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "货位编号";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "货位";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "仓库编码";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "仓库";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "返回信息";
            dt.Columns.Add(dc);

            try
            {
                string sSQL = "select a.入库货位 as 货位编码,b.cPosName as 货位,c.cWhCode as 仓库编码,c.cWhName as 仓库,cast(null as varchar(50)) as  返回信息 " +
                                "from dbo.物料货位对照 a left join @u8.Position b on a.入库货位 = b.cPosCode " +
                                "	left join @u8.Warehouse c on c.cWhCode = b.cWhCode " +
                                "where 物料编码 = '" + sInvCode + "' " +
                                "order by iID";
                dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count < 1)
                {
                    throw new Exception("该物料未设置货位");
                }
            }
            catch(Exception ee)
            {
                DataRow dr = dt.NewRow();
                dr["返回信息"] = ee.Message;
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public string Insert入库单(DataTable dt列表,DateTime d单据日期)
        {
            string sReturn = "";
            try
            {
                int iYear = int.Parse(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11,4));
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
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(dt列表.Rows[i]["bUsed"]) > 0)
                    {
                        continue;
                    }

                    string[] s条形码 = dt列表.Rows[i]["条形码"].ToString().Trim().Split('$');
                    decimal d本次入库数量 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dt列表.Rows[i]["本次入库数量"]);
                    decimal d本次入库件数 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dt列表.Rows[i]["本次入库件数"]);
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
                              "   ,cast(null as varchar(50)) as 条形码,c.cAssComUnitCode as 辅助计量编码,cast(null as varchar(10)) as 单据来源,0 as bUsed,b.AUTOID as 检验单子表ID " +
                          "from @u8.QMCHECKVOUCHER a inner join @u8.QMCHECKVOUCHERS b on a.id = b.id inner join @u8.Inventory c on a.cInvCode = c.cInvCode " +
                          "where  a.id = " + s条形码[2].Trim() + " " +
                          "order by a.CWHCODE,a.CPOSITION,a.CINVCODE,a.CCHECKCODE ";
                    DataTable dt检验单详细信息 = clsSQLCommond.ExecQuery(sSQL);

                    decimal d可入库数量 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dt检验单详细信息.Rows[0]["可入库数量"]);
                    decimal d可入库件数 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dt检验单详细信息.Rows[0]["可入库件数"]);
                    decimal d累计入库数量 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dt检验单详细信息.Rows[0]["累计入库数量"]);
                    decimal d累计入库件数 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dt检验单详细信息.Rows[0]["累计入库件数"]);
                    if (d可入库数量 < d本次入库数量 + d累计入库数量)
                    {
                        dt列表.Rows[i]["返回信息"] = "超出数量，不能入库";
                        if (s错误.Trim() == "")
                        {
                            s错误 = (i + 1).ToString();
                        }
                        else
                        {
                            s错误 = s错误 + "," + (i + 1).ToString();
                        }
                    }

                    sSQL = "select cBusType,b.* from @u8.PU_ArrivalVouch a inner join @u8.PU_ArrivalVouchs b on a.id = b.id where b.autoid = " + dt检验单详细信息.Rows[0]["来源单据子表ID"].ToString().Trim();
                    DataTable dt到货单 = clsSQLCommond.ExecQuery(sSQL);
                    if (dt到货单 == null || dt到货单.Rows.Count < 1)
                    {
                        dt列表.Rows[i]["返回信息"] = "未能查出单据类型";
                        if (s错误.Trim() == "")
                        {
                            s错误 = (i + 1).ToString();
                        }
                        else
                        {
                            s错误 = s错误 + "," + (i + 1).ToString();
                        }
                    }

                    if (s错误.Trim() != "")
                    {
                        return "存在错误，不能导入，行号如下：" + s错误;
                    }


                    dt列表.Rows[i]["单据来源"] = dt到货单.Rows[0]["cBusType"].ToString().Trim();
                    dt列表.Rows[i]["bUsed"] = 0;

                    iID += 1;
                    iIDDetail += 1;
                    iCode += 1;
                    if (dt列表.Rows[i]["单据来源"].ToString().Trim() == "普通采购")
                    {
                        sSQL = "insert into @u8.rdrecord(id,brdflag,cvouchtype,cbustype,csource,cwhcode,ddate,ccode,crdcode,cdepcode" +
                                    ",cptcode,cvencode,cordercode,carvcode,cmaker,bpufirst,darvdate,vt_id,bisstqc,cdefine14" +
                                    ",itaxrate,iexchrate,cexch_name,bomfirst,idiscounttaxtype,iswfcontrolled,dnmaketime,dnmodifytime,dnverifytime,bcredit) " +
                               "values (" + iID + ",1,N'01',N'普通采购',N'来料检验单',N'" + dt列表.Rows[i]["仓库编码"].ToString().Trim() + "',N'" + d单据日期.ToString("yyyy-MM-dd") + "',N'" + sSetCode(iCode, d单据日期) + "',N'101',N'" + dt检验单详细信息.Rows[0]["部门编号"].ToString().Trim() + "'" +
                                    ",N'01',N'" + dt检验单详细信息.Rows[0]["供应商编码"].ToString().Trim() + "',N'" + dt检验单详细信息.Rows[0]["订单号"].ToString().Trim() + "',N'" + dt检验单详细信息.Rows[0]["到货单号"].ToString().Trim() + "',N'" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',0,N'" + dt检验单详细信息.Rows[0]["到货日期"].ToString().Trim() + "',27,0,N'" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "'" +
                                    ",N'16',1,N'人民币',0,N'0',0, getdate(), Null , Null ,N'0')";
                        aList.Add(sSQL);
                    }
                    if (dt列表.Rows[i]["单据来源"].ToString().Trim() == "委外加工")
                    {
                        sSQL = "insert into @u8.rdrecord(id,brdflag,cvouchtype,cbustype,csource,cwhcode,ddate,ccode,crdcode,cdepcode" +
                                    ",cptcode,cvencode,cordercode,carvcode,cmaker,bpufirst,darvdate,vt_id,bisstqc,cdefine14" +
                                    ",itaxrate,iexchrate,cexch_name,bomfirst,idiscounttaxtype,iswfcontrolled,dnmaketime,dnmodifytime,dnverifytime,bcredit) " +
                               "values (" + iID + ",1,N'01',N'委外加工',N'来料检验单',N'" + dt列表.Rows[i]["仓库编码"].ToString().Trim() + "',N'" + d单据日期.ToString("yyyy-MM-dd") + "',N'" + sSetCode(iCode, d单据日期) + "',N'101',N'" + dt检验单详细信息.Rows[0]["部门编号"].ToString().Trim() + "'" +
                                    ",N'01',N'" + dt检验单详细信息.Rows[0]["供应商编码"].ToString().Trim() + "',N'" + dt检验单详细信息.Rows[0]["订单号"].ToString().Trim() + "',N'" + dt检验单详细信息.Rows[0]["到货单号"].ToString().Trim() + "',N'" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',0,N'" + dt检验单详细信息.Rows[i]["到货日期"].ToString().Trim() + "',27,0,N'" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "'" +
                                    ",N'16',1,N'人民币',0,N'0',0, getdate(), Null , Null ,N'0')";
                        aList.Add(sSQL);
                    }
                    string s本次入库件数 = "null";
                    if (d本次入库件数 > 0)
                    {
                        s本次入库件数 = d本次入库件数.ToString().Trim();
                    }

                    if (dt列表.Rows[i]["单据来源"].ToString().Trim() == "普通采购")
                    {
                        //税率
                        decimal d税率 = decimal.Round(Convert.ToDecimal(dt到货单.Rows[0]["iTaxRate"]), 2);
                        //单价(不含税)
                        decimal d无税单价 = decimal.Round(Convert.ToDecimal(dt到货单.Rows[0]["iOriCost"]), 2);
                        //金额(不含税)
                        decimal d无税金额 = decimal.Round(d无税单价 * d本次入库数量, 2);
                        //原币含税单价
                        decimal d含税单价 = decimal.Round(Convert.ToDecimal(dt到货单.Rows[0]["iOriTaxCost"]), 6);
                        //原币价税合计
                        decimal d价税合计 = decimal.Round(d含税单价 * decimal.Round(d本次入库数量, 6), 2);
                        //原币税额 
                        decimal d税额 = d价税合计 - d无税金额;

                        sSQL = "Insert Into @u8.rdrecords(autoid,id,cinvcode,inum,iquantity,iunitcost,iprice,iaprice,ipunitcost,ipprice" +
                                    ",cbatch,cvouchcode,cfree1,cfree2,dsdate,itax,isquantity,isnum,imoney,isoutquantity" +
                                    ",isoutnum,ifnum,ifquantity,dvdate,itrids,cposition,cdefine22,cdefine23,cdefine24,cdefine25" +
                                    ",cdefine26,cdefine27,citem_class,citemcode,iposid,facost,cname,citemcname,cfree3,cfree4" +
                                    ",cfree5,cfree6,cfree7,cfree8,cfree9,cfree10,cbarcode,inquantity,innum,cassunit" +
                                    ",dmadedate,imassdate,cdefine28,cdefine29,cdefine30,cdefine31,cdefine32,cdefine33,cdefine34,cdefine35" +
                                    ",cdefine36,cdefine37,impoids,icheckids,cbvencode,cinvouchcode,cgspstate,iarrsid,ccheckcode,icheckidbaks" +
                                    ",crejectcode,irejectids,ccheckpersoncode,dcheckdate,ioritaxcost,ioricost,iorimoney,ioritaxprice,iorisum,itaxrate" +
                                    ",itaxprice,isum,btaxcost,cpoid,cmassunit,imaterialfee,iprocesscost,iprocessfee,dmsdate,ismaterialfee" +
                                    ",isprocessfee,iomodid,iorderdid,strcontractid,strcode,iordertype,cbaccounter,bcosting,isumbillquantity,bvmiused" +
                                    ",ivmisettlequantity,ivmisettlenum,cvmivencode,iinvsncount,impcost,iimosid,iimbsid,cbarvcode,dbarvdate,iinvexchrate" +
                                    ",iordercode,iorderseq,corufts,iexpiratdatecalcu,cexpirationdate,dexpirationdate,cciqbookcode,ibondedsumqty,isodid,isotype" +
                                    ",csocode,isoseq,cbatchproperty1,cbatchproperty2,cbatchproperty3,cbatchproperty4,cbatchproperty5,cbatchproperty6,cbatchproperty7,cbatchproperty8" +
                                    ",cbatchproperty9,cbatchproperty10) " +
                                "Values (" + iIDDetail + "," + iID + ",N'" + dt列表.Rows[i]["物料编码"].ToString().Trim() + "'," + s本次入库件数 + "," + d本次入库数量 + "," + d无税单价 + "," + d无税金额 + "," + d无税金额 + ",Null,Null" +
                                    ",Null,Null,Null,Null,Null," + d税额 + ",0,0,0,Null" +
                                    ",Null,Null,Null,Null,Null,Null,Null,Null,Null,Null" +
                                    ",Null,Null,N'00',N'" + dt列表.Rows[i]["项目编码"].ToString().Trim() + "'," + dt到货单.Rows[0]["iPOsID"].ToString().Trim() + "," + d无税单价 + ",N'" + dt列表.Rows[i]["项目编码"].ToString().Trim() + "',N'外销订单项目',Null,Null" +
                                    ",Null,Null,Null,Null,Null,Null,Null,Null,Null,N'" + dt列表.Rows[i]["项目编码"].ToString().Trim() + "'" +
                                    ",Null,Null,Null,Null,Null,Null,Null,Null,Null,Null" +
                                    ",Null,Null,Null,Null,Null,Null,Null," + dt到货单.Rows[0]["Autoid"].ToString().Trim() + ",N'" + dt列表.Rows[i]["检验单号"].ToString().Trim() + "'," + dt检验单详细信息.Rows[0]["检验单子表ID"].ToString().Trim() + " " +
                                    ",Null,Null,Null,N'" + dt检验单详细信息.Rows[0]["检验日期"].ToString().Trim() + "'," + d含税单价 + "," + d无税单价 + "," + d无税金额 + "," + d税额 + "," + d价税合计 + "," + d税率 + " " +
                                    "," + d税额 + "," + d价税合计 + ",0,N'" + dt到货单.Rows[0]["cordercode"].ToString().Trim() + "',Null,Null,Null,Null,Null,Null" +
                                    ",Null,Null,Null,Null,Null,Null,Null,1,Null,Null" +
                                    ",Null,Null,Null,Null,Null,Null,Null,N'" + dt检验单详细信息.Rows[0]["到货单号"].ToString().Trim() + "',N'" + dt检验单详细信息.Rows[0]["到货日期"].ToString().Trim() + "'," + dt到货单.Rows[0]["iinvexchrate"].ToString().Trim() + " " +
                                    ",Null,Null,N'13959.6528',null,Null,Null,Null,Null,Null,Null" +
                                    ",Null,Null,Null,Null,Null,Null,Null,Null,Null,Null" +
                                    ",Null,Null)";
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

                        int i货位管理 = Chk货位管理(dt列表.Rows[i]["仓库编码"].ToString().Trim());
                        if (i货位管理 == 1)
                        { 
                            sSQL = "Insert Into @u8.InvPosition(rdsid,rdid,cwhcode,cposcode,cinvcode,cbatch,cfree1,cfree2,dvdate,iquantity" +
                                        ",inum,cmemo,chandler,ddate,brdflag,csource,cfree3,cfree4,cfree5,cfree6" +
                                        ",cfree7,cfree8,cfree9,cfree10,cassunit,cbvencode,itrackid,dmadedate,imassdate,cmassunit" +
                                        ",cvmivencode,iexpiratdatecalcu,cexpirationdate,dexpirationdate) " +
                                    "Values (" + iIDDetail + ",N'" + iID + "',N'" + dt列表.Rows[i]["仓库编码"].ToString().Trim() + "',N'" + dt列表.Rows[i]["货位编码"].ToString().Trim() + "',N'" + dt列表.Rows[i]["物料编码"].ToString().Trim() + "',Null,Null,Null,Null," + d本次入库数量 + " "  +
                                        "," + s本次入库件数 + ",Null,N'" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',N'" + d单据日期.ToString("yyyy-MM-dd") + "',1,Null,Null,Null,Null,Null" +
                                        ",Null,Null,Null,Null,N'" + dt检验单详细信息.Rows[0]["辅助计量编码"].ToString().Trim() + "',Null,Null,Null,Null,Null" +
                                        ",Null,0,Null,Null)";
                            aList.Add(sSQL);

                            //当一条入库单有多个货位时，置空
                            sSQL = "update @u8.rdrecords set cposition=N'" + dt列表.Rows[i]["货位编码"].ToString().Trim() + "' where id = " + iID + " and autoid=" + iIDDetail;
                            aList.Add(sSQL);
                        }

                        sSQL = " UPDATE @u8.qmcheckvoucher SET FsumQuantity=isnull(FsumQuantity,0)+ " + d本次入库数量 + ",FsumNum=isnull(FsumNum,0)+ " + s本次入库件数 + ",bpuinflag=1 " +
                                " where ID = " + dt检验单详细信息.Rows[0]["检验单ID"].ToString().Trim();
                        aList.Add(sSQL);

                        sSQL = "update @u8.Pu_ArrivalVouchs set fValidInQuan = ISNULL(fValidInQuan,0) + " + d本次入库数量 + ",fValidInNum = ISNULL(fValidInNum,0) + " + s本次入库件数 + " " +
                                "where Autoid = " + dt到货单.Rows[0]["Autoid"].ToString().Trim();
                        aList.Add(sSQL);
                    }
                    if (dt列表.Rows[i]["单据来源"].ToString().Trim() == "委外加工")
                    {
                        //税率
                        decimal d税率 = decimal.Round(Convert.ToDecimal(dt到货单.Rows[0]["iTaxRate"]), 2);
                        //单价(不含税)
                        decimal d无税单价 = decimal.Round(Convert.ToDecimal(dt到货单.Rows[0]["iOriCost"]), 2);
                        //金额(不含税)
                        decimal d无税金额 = decimal.Round(d无税单价 * d本次入库数量, 2);
                        //原币含税单价
                        decimal d含税单价 = decimal.Round(Convert.ToDecimal(dt到货单.Rows[0]["iOriTaxCost"]), 6);
                        //原币价税合计
                        decimal d价税合计 = decimal.Round(d含税单价 * decimal.Round(d本次入库数量, 6), 2);
                        //原币税额 
                        decimal d税额 = d价税合计 - d无税金额;

                        sSQL = "Insert Into @u8.rdrecords(autoid,id,cinvcode,inum,iquantity,iunitcost,iprice,iaprice,ipunitcost,ipprice" +
                                    ",cbatch,cvouchcode,cfree1,cfree2,dsdate,itax,isquantity,isnum,imoney,isoutquantity" +
                                    ",isoutnum,ifnum,ifquantity,dvdate,itrids,cposition,cdefine22,cdefine23,cdefine24,cdefine25" +
                                    ",cdefine26,cdefine27,citem_class,citemcode,iposid,facost,cname,citemcname,cfree3,cfree4" +
                                    ",cfree5,cfree6,cfree7,cfree8,cfree9,cfree10,cbarcode,inquantity,innum,cassunit" +
                                    ",dmadedate,imassdate,cdefine28,cdefine29,cdefine30,cdefine31,cdefine32,cdefine33,cdefine34,cdefine35" +
                                    ",cdefine36,cdefine37,impoids,icheckids,cbvencode,cinvouchcode,cgspstate,iarrsid,ccheckcode,icheckidbaks" +
                                    ",crejectcode,irejectids,ccheckpersoncode,dcheckdate,ioritaxcost,ioricost,iorimoney,ioritaxprice,iorisum,itaxrate" +
                                    ",itaxprice,isum,btaxcost,cpoid,cmassunit,imaterialfee,iprocesscost,iprocessfee,dmsdate,ismaterialfee" +
                                    ",isprocessfee,iomodid,iorderdid,strcontractid,strcode,iordertype,cbaccounter,bcosting,isumbillquantity,bvmiused" +
                                    ",ivmisettlequantity,ivmisettlenum,cvmivencode,iinvsncount,impcost,iimosid,iimbsid,cbarvcode,dbarvdate,iinvexchrate" +
                                    ",iordercode,iorderseq,corufts,iexpiratdatecalcu,cexpirationdate,dexpirationdate,cciqbookcode,ibondedsumqty,isodid,isotype" +
                                    ",csocode,isoseq,cbatchproperty1,cbatchproperty2,cbatchproperty3,cbatchproperty4,cbatchproperty5,cbatchproperty6,cbatchproperty7,cbatchproperty8" +
                                    ",cbatchproperty9,cbatchproperty10) " +
                                "Values (" + iIDDetail + "," + iID + ",N'" + dt列表.Rows[i]["物料编码"].ToString().Trim() + "'," + s本次入库件数 + "," + d本次入库数量 + "," + d无税单价 + "," + d无税金额 + "," + d无税金额 + ",Null,Null" +
                                    ",Null,Null,Null,Null,Null," + d税额 + ",0,0,0,Null" +
                                    ",Null,Null,Null,Null,Null,Null,Null,Null,Null,Null" +
                                    ",Null,Null,N'00',N'" + dt列表.Rows[i]["项目编码"].ToString().Trim() + "'," + dt到货单.Rows[0]["iPOsID"].ToString().Trim() + "," + d无税单价 + ",N'" + dt列表.Rows[i]["项目编码"].ToString().Trim() + "',N'外销订单项目',Null,Null" +
                                    ",Null,Null,Null,Null,Null,Null,Null,Null,Null,N'" + dt列表.Rows[i]["项目编码"].ToString().Trim() + "'" +
                                    ",Null,Null,Null,Null,Null,Null,Null,Null,Null,Null" +
                                    ",Null,Null,Null,Null,Null,Null,Null," + dt到货单.Rows[0]["Autoid"].ToString().Trim() + ",N'" + dt列表.Rows[i]["检验单号"].ToString().Trim() + "'," + dt检验单详细信息.Rows[0]["检验单子表ID"].ToString().Trim() + " " +
                                    ",Null,Null,Null,N'" + dt检验单详细信息.Rows[0]["检验日期"].ToString().Trim() + "'," + d含税单价 + "," + d无税单价 + "," + d无税金额 + "," + d税额 + "," + d价税合计 + "," + d税率 + " " +
                                    "," + d税额 + "," + d价税合计 + ",0,N'" + dt到货单.Rows[0]["cordercode"].ToString().Trim() + "',Null,Null,Null,Null,Null,Null" +
                                    ",Null,Null,Null,Null,Null,Null,Null,1,Null,Null" +
                                    ",Null,Null,Null,Null,Null,Null,Null,N'" + dt检验单详细信息.Rows[0]["到货单号"].ToString().Trim() + "',N'" + dt检验单详细信息.Rows[0]["到货日期"].ToString().Trim() + "'," + dt到货单.Rows[0]["iinvexchrate"].ToString().Trim() + " " +
                                    ",Null,Null,N'13959.6528',null,Null,Null,Null,Null,Null,Null" +
                                    ",Null,Null,Null,Null,Null,Null,Null,Null,Null,Null" +
                                    ",Null,Null)";
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

                        int i货位管理 = Chk货位管理(dt列表.Rows[i]["仓库编码"].ToString().Trim());
                        if (i货位管理 == 1)
                        {
                            sSQL = "Insert Into @u8.InvPosition(rdsid,rdid,cwhcode,cposcode,cinvcode,cbatch,cfree1,cfree2,dvdate,iquantity" +
                                        ",inum,cmemo,chandler,ddate,brdflag,csource,cfree3,cfree4,cfree5,cfree6" +
                                        ",cfree7,cfree8,cfree9,cfree10,cassunit,cbvencode,itrackid,dmadedate,imassdate,cmassunit" +
                                        ",cvmivencode,iexpiratdatecalcu,cexpirationdate,dexpirationdate) " +
                                    "Values (" + iIDDetail + ",N'" + iID + "',N'" + dt列表.Rows[i]["仓库编码"].ToString().Trim() + "',N'" + dt列表.Rows[i]["货位编码"].ToString().Trim() + "',N'" + dt列表.Rows[i]["物料编码"].ToString().Trim() + "',Null,Null,Null,Null," + d本次入库数量 + " " +
                                        "," + s本次入库件数 + ",Null,N'" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',N'" + d单据日期.ToString("yyyy-MM-dd") + "',1,Null,Null,Null,Null,Null" +
                                        ",Null,Null,Null,Null,N'" + dt检验单详细信息.Rows[0]["辅助计量编码"].ToString().Trim() + "',Null,Null,Null,Null,Null" +
                                        ",Null,0,Null,Null)";
                            aList.Add(sSQL);

                            //当一条入库单有多个货位时，置空
                            sSQL = "update @u8.rdrecords set cposition=N'" + dt列表.Rows[i]["货位编码"].ToString().Trim() + "' where id = " + iID + " and autoid=" + iIDDetail;
                            aList.Add(sSQL);
                        }

                        sSQL = " UPDATE @u8.qmcheckvoucher SET FsumQuantity=isnull(FsumQuantity,0)+ " + d本次入库数量 + ",FsumNum=isnull(FsumNum,0)+ " + s本次入库件数 + ",bpuinflag=1 " +
                                " where ID = " + dt检验单详细信息.Rows[0]["检验单ID"].ToString().Trim();
                        aList.Add(sSQL);

                        sSQL = "update @u8.Pu_ArrivalVouchs set fValidInQuan = ISNULL(fValidInQuan,0) + " + d本次入库数量 + ",fValidInNum = ISNULL(fValidInNum,0) + " + s本次入库件数 + " " +
                                "where Autoid = " + dt到货单.Rows[0]["Autoid"].ToString().Trim();
                        aList.Add(sSQL);
                    }

                    dt列表.Rows[i]["bUsed"] = iID;


                    #region MyRegion
                    for (int j = i + 1; j < dt列表.Rows.Count; j++)
                    {
                        if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(dt列表.Rows[j]["bUsed"]) >0)
                        {
                            continue;
                        }
                        string[] s条形码2 = dt列表.Rows[j]["条形码"].ToString().Trim().Split('$');
                        decimal d本次入库数量2 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dt列表.Rows[j]["本次入库数量"]);
                        decimal d本次入库件数2 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dt列表.Rows[j]["本次入库件数"]);

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
                                  "   ,cast(null as varchar(50)) as 条形码,c.cAssComUnitCode as 辅助计量编码,cast(null as varchar(10)) as 单据来源,0 as bUsed,b.AUTOID as 检验单子表ID " +
                              "from @u8.QMCHECKVOUCHER a inner join @u8.QMCHECKVOUCHERS b on a.id = b.id inner join @u8.Inventory c on a.cInvCode = c.cInvCode " +
                              "where  a.id = " + s条形码2[2].Trim() + " " +
                              "order by a.CWHCODE,a.CPOSITION,a.CINVCODE,a.CCHECKCODE ";
                        DataTable dt检验单详细信息2 = clsSQLCommond.ExecQuery(sSQL);

                        if (dt检验单详细信息.Rows[0]["仓库编码"].ToString().Trim() == dt检验单详细信息2.Rows[0]["仓库编码"].ToString().Trim() && dt检验单详细信息.Rows[0]["供应商编码"].ToString().Trim() == dt检验单详细信息2.Rows[0]["供应商编码"].ToString().Trim()
                                && dt检验单详细信息.Rows[0]["部门编号"].ToString().Trim() == dt检验单详细信息2.Rows[0]["部门编号"].ToString().Trim()
                                && dt列表.Rows[i]["单据来源"].ToString().Trim() == dt列表.Rows[j]["单据来源"].ToString().Trim())
                        {
                            decimal d可入库数量2 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dt检验单详细信息2.Rows[0]["可入库数量"]);
                            decimal d可入库件数2 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dt检验单详细信息2.Rows[0]["可入库件数"]);
                            decimal d累计入库数量2 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dt检验单详细信息2.Rows[0]["累计入库数量"]);
                            decimal d累计入库件数2 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dt检验单详细信息2.Rows[0]["累计入库件数"]);
                            if (d可入库数量2 < d本次入库数量2 + d累计入库数量2)
                            {
                                dt列表.Rows[j]["返回信息"] = "超出数量，不能入库";
                                if (s错误.Trim() == "")
                                {
                                    s错误 = (j + 1).ToString();
                                }
                                else
                                {
                                    s错误 = s错误 + "," + (j + 1).ToString();
                                }
                            }

                            sSQL = "select cBusType,b.* from @u8.PU_ArrivalVouch a inner join @u8.PU_ArrivalVouchs b on a.id = b.id where b.autoid = " + dt检验单详细信息2.Rows[0]["来源单据子表ID"].ToString().Trim();
                            DataTable dt到货单2 = clsSQLCommond.ExecQuery(sSQL);
                            if (dt到货单2 == null || dt到货单2.Rows.Count < 1)
                            {
                                dt列表.Rows[j]["返回信息"] = "未能查出单据类型";
                                if (s错误.Trim() == "")
                                {
                                    s错误 = (i + 1).ToString();
                                }
                                else
                                {
                                    s错误 = s错误 + "," + (i + 1).ToString();
                                }
                            }

                            if (s错误.Trim() != "")
                            {
                                return "存在错误，不能导入，行号如下：" + s错误;
                            }


                            dt列表.Rows[j]["单据来源"] = dt到货单2.Rows[0]["cBusType"].ToString().Trim();
                            dt列表.Rows[j]["bUsed"] = 0;

                            iIDDetail += 1;

                            string s本次入库件数2 = "null";
                            if (d本次入库件数2 > 0)
                            {
                                s本次入库件数2 = d本次入库件数2.ToString().Trim();
                            }

                            if (dt列表.Rows[j]["单据来源"].ToString().Trim() == "普通采购")
                            {
                                //税率
                                decimal d税率2 = decimal.Round(Convert.ToDecimal(dt到货单2.Rows[0]["iTaxRate"]), 2);
                                //单价(不含税)
                                decimal d无税单价2 = decimal.Round(Convert.ToDecimal(dt到货单2.Rows[0]["iOriCost"]), 2);
                                //金额(不含税)
                                decimal d无税金额2 = decimal.Round(d无税单价2 * d本次入库数量2, 2);
                                //原币含税单价
                                decimal d含税单价2 = decimal.Round(Convert.ToDecimal(dt到货单2.Rows[0]["iOriTaxCost"]), 6);
                                //原币价税合计
                                decimal d价税合计2 = decimal.Round(d含税单价2 * decimal.Round(d本次入库数量2, 6), 2);
                                //原币税额 
                                decimal d税额2 = d价税合计2 - d无税金额2;
                                sSQL = "Insert Into @u8.rdrecords(autoid,id,cinvcode,inum,iquantity,iunitcost,iprice,iaprice,ipunitcost,ipprice" +
                                            ",cbatch,cvouchcode,cfree1,cfree2,dsdate,itax,isquantity,isnum,imoney,isoutquantity" +
                                            ",isoutnum,ifnum,ifquantity,dvdate,itrids,cposition,cdefine22,cdefine23,cdefine24,cdefine25" +
                                            ",cdefine26,cdefine27,citem_class,citemcode,iposid,facost,cname,citemcname,cfree3,cfree4" +
                                            ",cfree5,cfree6,cfree7,cfree8,cfree9,cfree10,cbarcode,inquantity,innum,cassunit" +
                                            ",dmadedate,imassdate,cdefine28,cdefine29,cdefine30,cdefine31,cdefine32,cdefine33,cdefine34,cdefine35" +
                                            ",cdefine36,cdefine37,impoids,icheckids,cbvencode,cinvouchcode,cgspstate,iarrsid,ccheckcode,icheckidbaks" +
                                            ",crejectcode,irejectids,ccheckpersoncode,dcheckdate,ioritaxcost,ioricost,iorimoney,ioritaxprice,iorisum,itaxrate" +
                                            ",itaxprice,isum,btaxcost,cpoid,cmassunit,imaterialfee,iprocesscost,iprocessfee,dmsdate,ismaterialfee" +
                                            ",isprocessfee,iomodid,iorderdid,strcontractid,strcode,iordertype,cbaccounter,bcosting,isumbillquantity,bvmiused" +
                                            ",ivmisettlequantity,ivmisettlenum,cvmivencode,iinvsncount,impcost,iimosid,iimbsid,cbarvcode,dbarvdate,iinvexchrate" +
                                            ",iordercode,iorderseq,corufts,iexpiratdatecalcu,cexpirationdate,dexpirationdate,cciqbookcode,ibondedsumqty,isodid,isotype" +
                                            ",csocode,isoseq,cbatchproperty1,cbatchproperty2,cbatchproperty3,cbatchproperty4,cbatchproperty5,cbatchproperty6,cbatchproperty7,cbatchproperty8" +
                                            ",cbatchproperty9,cbatchproperty10) " +
                                        "Values (" + iIDDetail + "," + iID + ",N'" + dt列表.Rows[j]["物料编码"].ToString().Trim() + "'," + s本次入库件数2 + "," + d本次入库数量2 + "," + d无税单价2 + "," + d无税金额2 + "," + d无税金额2 + ",Null,Null" +
                                            ",Null,Null,Null,Null,Null," + d税额2 + ",0,0,0,Null" +
                                            ",Null,Null,Null,Null,Null,Null,Null,Null,Null,Null" +
                                            ",Null,Null,N'00',N'" + dt列表.Rows[j]["项目编码"].ToString().Trim() + "'," + dt到货单.Rows[0]["iPOsID"].ToString().Trim() + "," + d无税单价2 + ",N'" + dt列表.Rows[j]["项目编码"].ToString().Trim() + "',N'外销订单项目',Null,Null" +
                                            ",Null,Null,Null,Null,Null,Null,Null,Null,Null,N'" + dt列表.Rows[j]["项目编码"].ToString().Trim() + "'" +
                                            ",Null,Null,Null,Null,Null,Null,Null,Null,Null,Null" +
                                            ",Null,Null,Null,Null,Null,Null,Null," + dt到货单2.Rows[0]["Autoid"].ToString().Trim() + ",N'" + dt列表.Rows[j]["检验单号"].ToString().Trim() + "'," + dt检验单详细信息2.Rows[0]["检验单子表ID"].ToString().Trim() + " " +
                                            ",Null,Null,Null,N'" + dt检验单详细信息2.Rows[0]["检验日期"].ToString().Trim() + "'," + d含税单价2 + "," + d无税单价2 + "," + d无税金额2 + "," + d税额2 + "," + d价税合计2 + "," + d税率2 + " " +
                                            "," + d税额2 + "," + d价税合计2 + ",0,N'" + dt到货单2.Rows[0]["cordercode"].ToString().Trim() + "',Null,Null,Null,Null,Null,Null" +
                                            ",Null,Null,Null,Null,Null,Null,Null,1,Null,Null" +
                                            ",Null,Null,Null,Null,Null,Null,Null,N'" + dt检验单详细信息2.Rows[0]["到货单号"].ToString().Trim() + "',N'" + dt检验单详细信息2.Rows[0]["到货日期"].ToString().Trim() + "'," + dt到货单2.Rows[0]["iinvexchrate"].ToString().Trim() + " " +
                                            ",Null,Null,N'13959.6528',null,Null,Null,Null,Null,Null,Null" +
                                            ",Null,Null,Null,Null,Null,Null,Null,Null,Null,Null" +
                                            ",Null,Null)";
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

                                int i货位管理 = Chk货位管理(dt列表.Rows[j]["仓库编码"].ToString().Trim());
                                if (i货位管理 == 1)
                                {
                                    sSQL = "Insert Into @u8.InvPosition(rdsid,rdid,cwhcode,cposcode,cinvcode,cbatch,cfree1,cfree2,dvdate,iquantity" +
                                                ",inum,cmemo,chandler,ddate,brdflag,csource,cfree3,cfree4,cfree5,cfree6" +
                                                ",cfree7,cfree8,cfree9,cfree10,cassunit,cbvencode,itrackid,dmadedate,imassdate,cmassunit" +
                                                ",cvmivencode,iexpiratdatecalcu,cexpirationdate,dexpirationdate) " +
                                            "Values (" + iIDDetail + ",N'" + iID + "',N'" + dt列表.Rows[j]["仓库编码"].ToString().Trim() + "',N'" + dt列表.Rows[j]["货位编码"].ToString().Trim() + "',N'" + dt列表.Rows[j]["物料编码"].ToString().Trim() + "',Null,Null,Null,Null," + d本次入库数量2 + " " +
                                                "," + s本次入库件数2 + ",Null,N'" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',N'" + d单据日期.ToString("yyyy-MM-dd") + "',1,Null,Null,Null,Null,Null" +
                                                ",Null,Null,Null,Null,N'" + dt检验单详细信息2.Rows[0]["辅助计量编码"].ToString().Trim() + "',Null,Null,Null,Null,Null" +
                                                ",Null,0,Null,Null)";
                                    aList.Add(sSQL);

                                    //当一条入库单有多个货位时，置空
                                    sSQL = "update @u8.rdrecords set cposition=N'" + dt列表.Rows[j]["货位编码"].ToString().Trim() + "' where id = " + iID + " and autoid=" + iIDDetail;
                                    aList.Add(sSQL);
                                }

                                sSQL = " UPDATE @u8.qmcheckvoucher SET FsumQuantity=isnull(a.FsumQuantity,0)+ " + d本次入库数量2 + ",a.FsumNum=isnull(a.FsumNum,0)+ " + s本次入库件数2 + ",bpuinflag=1 " +
                                        " where ID = " + dt检验单详细信息2.Rows[0]["检验单ID"].ToString().Trim();
                                aList.Add(sSQL);

                                sSQL = "update @u8.Pu_ArrivalVouchs set fValidInQuan = ISNULL(fValidInQuan,0) + " + d本次入库数量2 + ",fValidInNum = ISNULL(fValidInNum,0) +  " + s本次入库件数2 + " " +
                                        "where Autoid = " + dt到货单2.Rows[0]["Autoid"].ToString().Trim();
                                aList.Add(sSQL);
                            }
                            if (dt列表.Rows[i]["单据来源"].ToString().Trim() == "委外加工")
                            {
                                //税率
                                decimal d税率2 = decimal.Round(Convert.ToDecimal(dt到货单2.Rows[0]["iTaxRate"]), 2);
                                //单价(不含税)
                                decimal d无税单价2 = decimal.Round(Convert.ToDecimal(dt到货单2.Rows[0]["iOriCost"]), 2);
                                //金额(不含税)
                                decimal d无税金额2 = decimal.Round(d无税单价2 * d本次入库数量2, 2);
                                //原币含税单价
                                decimal d含税单价2 = decimal.Round(Convert.ToDecimal(dt到货单2.Rows[0]["iOriTaxCost"]), 6);
                                //原币价税合计
                                decimal d价税合计2 = decimal.Round(d含税单价2 * decimal.Round(d本次入库数量2, 6), 2);
                                //原币税额 
                                decimal d税额2 = d价税合计2 - d无税金额2;
                                sSQL = "Insert Into @u8.rdrecords(autoid,id,cinvcode,inum,iquantity,iunitcost,iprice,iaprice,ipunitcost,ipprice" +
                                            ",cbatch,cvouchcode,cfree1,cfree2,dsdate,itax,isquantity,isnum,imoney,isoutquantity" +
                                            ",isoutnum,ifnum,ifquantity,dvdate,itrids,cposition,cdefine22,cdefine23,cdefine24,cdefine25" +
                                            ",cdefine26,cdefine27,citem_class,citemcode,iposid,facost,cname,citemcname,cfree3,cfree4" +
                                            ",cfree5,cfree6,cfree7,cfree8,cfree9,cfree10,cbarcode,inquantity,innum,cassunit" +
                                            ",dmadedate,imassdate,cdefine28,cdefine29,cdefine30,cdefine31,cdefine32,cdefine33,cdefine34,cdefine35" +
                                            ",cdefine36,cdefine37,impoids,icheckids,cbvencode,cinvouchcode,cgspstate,iarrsid,ccheckcode,icheckidbaks" +
                                            ",crejectcode,irejectids,ccheckpersoncode,dcheckdate,ioritaxcost,ioricost,iorimoney,ioritaxprice,iorisum,itaxrate" +
                                            ",itaxprice,isum,btaxcost,cpoid,cmassunit,imaterialfee,iprocesscost,iprocessfee,dmsdate,ismaterialfee" +
                                            ",isprocessfee,iomodid,iorderdid,strcontractid,strcode,iordertype,cbaccounter,bcosting,isumbillquantity,bvmiused" +
                                            ",ivmisettlequantity,ivmisettlenum,cvmivencode,iinvsncount,impcost,iimosid,iimbsid,cbarvcode,dbarvdate,iinvexchrate" +
                                            ",iordercode,iorderseq,corufts,iexpiratdatecalcu,cexpirationdate,dexpirationdate,cciqbookcode,ibondedsumqty,isodid,isotype" +
                                            ",csocode,isoseq,cbatchproperty1,cbatchproperty2,cbatchproperty3,cbatchproperty4,cbatchproperty5,cbatchproperty6,cbatchproperty7,cbatchproperty8" +
                                            ",cbatchproperty9,cbatchproperty10) " +
                                        "Values (" + iIDDetail + "," + iID + ",N'" + dt列表.Rows[j]["物料编码"].ToString().Trim() + "'," + s本次入库件数2 + "," + d本次入库数量2 + "," + d无税单价2 + "," + d无税金额2 + "," + d无税金额2 + ",Null,Null" +
                                            ",Null,Null,Null,Null,Null," + d税额2 + ",0,0,0,Null" +
                                            ",Null,Null,Null,Null,Null,Null,Null,Null,Null,Null" +
                                            ",Null,Null,N'00',N'" + dt列表.Rows[j]["项目编码"].ToString().Trim() + "'," + dt到货单.Rows[0]["iPOsID"].ToString().Trim() + "," + d无税单价2 + ",N'" + dt列表.Rows[j]["项目编码"].ToString().Trim() + "',N'外销订单项目',Null,Null" +
                                            ",Null,Null,Null,Null,Null,Null,Null,Null,Null,N'" + dt列表.Rows[j]["项目编码"].ToString().Trim() + "'" +
                                            ",Null,Null,Null,Null,Null,Null,Null,Null,Null,Null" +
                                            ",Null,Null,Null,Null,Null,Null,Null," + dt到货单2.Rows[0]["Autoid"].ToString().Trim() + ",N'" + dt列表.Rows[j]["检验单号"].ToString().Trim() + "'," + dt检验单详细信息2.Rows[0]["检验单子表ID"].ToString().Trim() + " " +
                                            ",Null,Null,Null,N'" + dt检验单详细信息2.Rows[0]["检验日期"].ToString().Trim() + "'," + d含税单价2 + "," + d无税单价2 + "," + d无税金额2 + "," + d税额2 + "," + d价税合计2 + "," + d税率2 + " " +
                                            "," + d税额2 + "," + d价税合计2 + ",0,N'" + dt到货单2.Rows[0]["cordercode"].ToString().Trim() + "',Null,Null,Null,Null,Null,Null" +
                                            ",Null,Null,Null,Null,Null,Null,Null,1,Null,Null" +
                                            ",Null,Null,Null,Null,Null,Null,Null,N'" + dt检验单详细信息2.Rows[0]["到货单号"].ToString().Trim() + "',N'" + dt检验单详细信息2.Rows[0]["到货日期"].ToString().Trim() + "'," + dt到货单2.Rows[0]["iinvexchrate"].ToString().Trim() + " " +
                                            ",Null,Null,N'13959.6528',null,Null,Null,Null,Null,Null,Null" +
                                            ",Null,Null,Null,Null,Null,Null,Null,Null,Null,Null" +
                                            ",Null,Null)";
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

                                int i货位管理 = Chk货位管理(dt列表.Rows[j]["仓库编码"].ToString().Trim());
                                if (i货位管理 == 1)
                                {
                                    sSQL = "Insert Into @u8.InvPosition(rdsid,rdid,cwhcode,cposcode,cinvcode,cbatch,cfree1,cfree2,dvdate,iquantity" +
                                                ",inum,cmemo,chandler,ddate,brdflag,csource,cfree3,cfree4,cfree5,cfree6" +
                                                ",cfree7,cfree8,cfree9,cfree10,cassunit,cbvencode,itrackid,dmadedate,imassdate,cmassunit" +
                                                ",cvmivencode,iexpiratdatecalcu,cexpirationdate,dexpirationdate) " +
                                            "Values (" + iIDDetail + ",N'" + iID + "',N'" + dt列表.Rows[j]["仓库编码"].ToString().Trim() + "',N'" + dt列表.Rows[j]["货位编码"].ToString().Trim() + "',N'" + dt列表.Rows[j]["物料编码"].ToString().Trim() + "',Null,Null,Null,Null," + d本次入库数量2 + " " +
                                                "," + s本次入库件数2 + ",Null,N'" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',N'" + d单据日期.ToString("yyyy-MM-dd") + "',1,Null,Null,Null,Null,Null" +
                                                ",Null,Null,Null,Null,N'" + dt检验单详细信息2.Rows[0]["辅助计量编码"].ToString().Trim() + "',Null,Null,Null,Null,Null" +
                                                ",Null,0,Null,Null)";
                                    aList.Add(sSQL);

                                    //当一条入库单有多个货位时，置空
                                    sSQL = "update @u8.rdrecords set cposition=N'" + dt列表.Rows[j]["货位编码"].ToString().Trim() + "' where id = " + iID + " and autoid=" + iIDDetail;
                                    aList.Add(sSQL);
                                }

                                sSQL = " UPDATE @u8.qmcheckvoucher SET FsumQuantity=isnull(a.FsumQuantity,0)+ " + d本次入库数量2 + ",a.FsumNum=isnull(a.FsumNum,0)+ " + s本次入库件数2 + ",bpuinflag=1 " +
                                        " where ID = " + dt检验单详细信息2.Rows[0]["检验单ID"].ToString().Trim();
                                aList.Add(sSQL);

                                sSQL = "update @u8.Pu_ArrivalVouchs set fValidInQuan = ISNULL(fValidInQuan,0) + " + d本次入库数量2 + ",fValidInNum = ISNULL(fValidInNum,0) +  " + s本次入库件数2 + " " +
                                        "where Autoid = " + dt到货单2.Rows[0]["Autoid"].ToString().Trim();
                                aList.Add(sSQL);
                            }

                            dt列表.Rows[j]["bUsed"] = iID;
                        }
                    }
                    #endregion
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

                if (s错误.Trim() != "")
                {
                    return "存在错误，不能导入，行号如下：" + s错误;
                }
                clsSQLCommond.ExecSqlTran(aList);
                sReturn = "成功生成入库单";
            }
            catch(Exception ee)
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
            string sSQL = "select iFatherID,iChildID from UFSystem..UA_Identity where cAcc_Id = '200' and cVouchType = '" + sType + "'";
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
        /// 返回入库单单据号
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        private string sSetCode(long s,DateTime date1)
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
                i = FrameBaseFunction.ClsBaseDataInfo.ReturnBoolToInt(clsSQLCommond.ExecGetScalar(sSQL));
            }
            catch { }
            return i;
        }
    }
}
