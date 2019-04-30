using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Collections;

namespace BarCode
{
    public class Cls到货
    {
        MobileBaseDLL.ClsDES clsDES = MobileBaseDLL.ClsDES.Instance();
        MobileBaseDLL.ClsSQLServerCommond clsSQLCommond = new MobileBaseDLL.ClsSQLServerCommond();

        ArrayList aList;
        int iTaxRate_All = MobileBaseDLL.ClsBaseDataInfo.iTaxRate_All_QJ;

        public DataTable GetBarArrInfo(string sBarCode)
        {

            //单据类型 0 采购订单入库，1 委外订单入库；帐套号；单据ID；数量
            //         2 采购订单到货，3 委外订单到货,
            //         4 委外退货

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
                //采购条码到货
                if (s[0].Trim() == "2")
                {
                    sSQL = "select distinct cast(null as int) as 序号,cast(null as varchar(50)) as 返回信息,'" + sBarCode + "' as 条形码,2 as 单据类型,p.dPODate as 单据日期,cDefine2 as 客户订单号,p.cDepCode as 部门编码,d.cDepName as 部门,p.cPersonCode as 业务员编码,a.cPersonName as 业务员 " +
                                ",p.cDefine14 as 备注,p.cDefine11 as 外销单号,p.poid as 订单ID,pd.[id] as 订单子表ID,p.cPOID as 订单号 " +
                                ",p.cVenCode as 供应商编码,v.cVenName as 供应商,i.cInvCode as 物料编码,i.cInvName as 物料名称,i.cInvStd as 规格型号,i.cComUnitCode as 主计量单位编码 ,c1.cComUnitName as 主计量,i.cAssComUnitCode as 辅计量单位编码 ,c2.cComUnitName as 辅计量 " +
                                ",pd.iQuantity as 订单数量,pd.iNum as 订单件数," + s[3].Trim() + "  as 本次到货数量," + s[4].Trim() + "  as 本次到货件数,i.cDefWareHouse as 默认仓库编码,w.cWhName as 默认仓库,cast(null as varchar(50)) as 货位编码,cast(null as varchar(50)) as 货位 " +
                                ",(pD.iQuantity - isnull(pd.iArrQTY,0)) as 应收数量,(pD.iNum- isnull(pd.iArrNum,0)) as 应收件数,iUnitPrice as 原币无税单价,iNatUnitPrice as 本币无税单价,iPerTaxRate as 税率 " +
                                ",pD.iTaxPrice as 含税单价,isnull(i.fInExcess ,0) as 入库上限,null as 领用类型,-1 as bUsed,cast(null as varchar(50)) as 制单人,pD.cItem_class as 项目大类编码,pD.cItemCode as 项目编码,pD.cItemName as 项目名称 " +
                            "FROM @u8.PO_Podetails pD inner join @u8.PO_Pomain p on pD.poid=p.poid " +
                                "inner join @u8.Inventory i on i.cInvCode = pd.cInvCode " +
                                "left join  @u8.ComputationUnit c1 on c1.cComunitCode = i.cComUnitCode " +
                                "left join @u8.Department  d on d.cDepCode = p.cDepCode " +
                                "left join @u8.Vendor v on v.cVenCode = p.cVenCode " +
                                "left join @u8.Person a on a.cPersonCode = p.cPersonCode " +
                                "left join  @u8.ComputationUnit c2 on c2.cComunitCode = i.cAssComUnitCode  " +
                                "left join @u8.Warehouse w on w.cWhCode = i.cDefWareHouse " +
                            "WHERE pd.[id] =  " + s[2].Trim();
                }
                //委外条码到货
                if (s[0].Trim() == "3")
                {
                    sSQL = "SELECT distinct cast(null as int) as 序号,cast(null as varchar(50)) as 返回信息,'" + sBarCode + "' as 条形码,3 as 单据类型,p.dDate as 单据日期,cDefine2 as 客户订单号,p.cDepCode as 部门编码,d.cDepName as 部门,p.cPersonCode as 业务员编码,a.cPersonName as 业务员 " +
                                ",p.cDefine14 as 备注,pd.cItemCode as 外销单号,p.moid as 订单ID,pD.MODetailsID AS 订单子表ID, p.cCode AS 订单号" +
                                ",p.cVenCode as 供应商编码,v.cVenName as 供应商,pD.cInvCode AS 物料编码, i.cInvName AS 物料名称, i.cInvStd AS 规格型号,i.cComUnitCode as 主计量单位编码,c1.cComUnitName as 主计量,i.cAssComUnitCode as 辅计量单位编码 ,c2.cComUnitName as 辅计量" +
                                ", pD.iQuantity AS 订单数量,pD.iNum as 订单件数, " + s[3].Trim() + " as 本次到货数量," + s[4].Trim() + "  as 本次到货件数,i.cDefWareHouse as 默认仓库编码,w.cWhName as 默认仓库,cast(null as varchar(50)) as 货位编码,cast(null as varchar(50)) as 货位 " +
                                ",(pD.iQuantity - isnull(pd.iArrQTY,0)) as 应收数量,(pD.iNum- isnull(pd.iArrNum,0)) as 应收件数,pd.iUnitPrice as 原币无税单价,pd.iNatUnitPrice as 本币无税单价,iPerTaxRate as 税率" +
                                ",pD.iTaxPrice as 含税单价 ,isnull(i.fInExcess,0) as 入库上限,pDD.iWIPtype as 领用类型,-1 as bUsed,cast(null as varchar(50)) as 制单人,pD.cItem_class as 项目大类编码,pD.cItemCode as 项目编码,pD.cItemName as 项目名称 " +
                            "FROM @u8.OM_MOMain p LEFT OUTER JOIN @u8.OM_MODetails pD ON p.MOID = pD.MOID  " +
                                "left outer join @u8.OM_MOMaterials pDD on pDD.MoDetailsID = pD.MoDetailsID " +
                                "LEFT OUTER JOIN @u8.Inventory i ON i.cInvCode = pD.cInvCode  " +
                                "left join  @u8.ComputationUnit c1 on c1.cComunitCode = i.cComUnitCode " +
                                "left join @u8.Department  d on d.cDepCode = p.cDepCode " +
                                "left join @u8.Vendor v on v.cVenCode = p.cVenCode " +
                                "left join @u8.Person a on a.cPersonCode = p.cPersonCode " +
                                "left join  @u8.ComputationUnit c2 on c2.cComunitCode = i.cAssComUnitCode " +
                                "left join @u8.Warehouse w on w.cWhCode = i.cDefWareHouse " +
                            "WHERE pD.MODetailsID =  " + s[2].Trim();
                }

                dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count != 1)
                {
                    dt = null;
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
                if (s货位 == "246013C30DFC486A")
                    i = 1;
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

      
        long iIDArr = 0;
        long iIDDetailArr = 0;
        long iCodeArr = 0;

        long iCode报检 = 0;
        long iID报检 = 0;
        long iIDDetail报检 = 0;

        string sInfo3 = "";
        string sInfo4 = "";

        string s到货单号 = "";
        string s报检单号 = "";

        long iIDBack = 0;
        long iIDBackDetail = 0;
        long iCodeBack = 0;

        public string Insert到货单(DataTable dt列表, DateTime d单据日期, int i栈板1, int i栈板2, int i栈板3, int i栈板4, int i栈板5, int i栈板6, int i栈板7, int i栈板8)
        {
            s到货单号 = "";
            s报检单号 = "";

            if (dt列表 == null || dt列表.Rows.Count < 1)
                return "没有需要导入的数据";

            string sReturn = "";
            try
            {
                int iYear = int.Parse(MobileBaseDLL.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4));
                int iYear2 = int.Parse(d单据日期.ToString("yyyy"));
                string sSQL = "";

                if (iYear >= iYear2)
                {
                    sSQL = "select * from @u8.GL_mend where iperiod = month('" + d单据日期.ToString("yyyy-MM-dd") + "')";
                    DataTable dtTemp1 = clsSQLCommond.ExecQuery(sSQL);
                    if (Convert.ToBoolean(dtTemp1.Rows[0]["bflag_ST"]) == true)
                    {
                        throw new Exception("当月库存管理已结帐，不能录入数据！");
                    }
                }

                string sErr = "";

                for (int i = 0; i < dt列表.Rows.Count; i++)
                {
                    int i类型 = Convert.ToInt32(dt列表.Rows[i]["单据类型"]);
                    decimal d本次到货 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt列表.Rows[i]["本次到货数量"]);
                    decimal d订单数量 = 0;
                    decimal d到货数量 = 0;
                    decimal d超限额 = 0;
                    if (i类型 == 2)
                    {
                        string s订单信息 = "select b.iQuantity,b.iArrQTY,c.fInExcess from @u8.PO_Pomain a inner join  @u8.PO_Podetails b on a.POID = b.POID inner join @u8.Inventory c on c.cInvCode = b.cInvCode where b.ID = " + dt列表.Rows[i]["订单子表ID"].ToString().Trim();
                        DataTable dt订单信息 = clsSQLCommond.ExecQuery(s订单信息);
                        d订单数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt订单信息.Rows[0]["iQuantity"]);
                        d到货数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt订单信息.Rows[0]["iArrQTY"]);
                        d超限额 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt订单信息.Rows[0]["fInExcess"]);
                    }
                    if (i类型 == 3)
                    {
                        string s订单信息 = "select b.iQuantity,b.iArrQTY,c.fInExcess from @u8.OM_MOMain a inner join @u8.OM_MODetails b on a.MOID = b.MOID inner join @u8.Inventory c on c.cInvCode = b.cInvCode where b.MODetailsID = " + dt列表.Rows[i]["订单子表ID"].ToString().Trim();
                        DataTable dt订单信息 = clsSQLCommond.ExecQuery(s订单信息);
                        d订单数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt订单信息.Rows[0]["iQuantity"]);
                        d到货数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt订单信息.Rows[0]["iArrQTY"]);
                        d超限额 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt订单信息.Rows[0]["fInExcess"]);
                    }

                    if (d订单数量 * (1 + d超限额) < d到货数量 + d本次到货)
                    {
                        sErr =  sErr + "行" + (i + 1).ToString() + "超订单\r\n";
                    }
                }

                if (sErr.Length > 0)
                    return sErr;

                aList = new ArrayList();

                //条码到货ID，单据号
                GetID("PuArrival", out iIDArr, out iIDDetailArr);
                sSQL = "select isnull(max(cNumber),0) as Maxnumber From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='26' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(d单据日期.ToString("yyyy-MM-dd")).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(d单据日期.ToString("yyyy-MM-dd")).ToString("yyMM") + "')";
                DataTable dtCode = clsSQLCommond.ExecQuery(sSQL);
                iCodeArr = Convert.ToInt64(dtCode.Rows[0]["Maxnumber"]);
                dtCode = null;

                //报检ID，单据号
                GetID报检();
                sSQL = "select isnull(max(cNumber),0) as Maxnumber From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='QM01' and (cContent='日期' or cContent='报检日期') and (cSeed='" + DateTime.Parse(d单据日期.ToString("yyyy-MM-dd")).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(d单据日期.ToString("yyyy-MM-dd")).ToString("yyMM") + "')";
                DataTable dtCode2 = clsSQLCommond.ExecQuery(sSQL);
                iCode报检 = Convert.ToInt64(dtCode2.Rows[0]["Maxnumber"]);
                dtCode2 = null;

                //委外退货单,单据号
                GetID("rd", out iIDBack, out iIDBackDetail);
                sSQL = "select isnull(max(cNumber),0) as Maxnumber From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='0412' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(d单据日期.ToString("yyyy-MM-dd")).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(d单据日期.ToString("yyyy-MM-dd")).ToString("yyMM") + "')";
                DataTable dtCodeBack = clsSQLCommond.ExecQuery(sSQL);
                iCodeBack = Convert.ToInt64(dtCodeBack.Rows[0]["Maxnumber"]);

                //采购到货单
                DataRow[] dr2 = dt列表.Select("单据类型 = 2");
                if (dr2.Length > 0)
                {
                    Import采购到货单(dr2, out sInfo3, d单据日期);
                    if (aList.Count < 1)
                        return "没有需要导入的数据";

                    if (iIDArr > 1000000000)
                        iIDArr = iIDArr - 1000000000;
                    if (iIDDetailArr > 1000000000)
                        iIDDetailArr = iIDDetailArr - 1000000000;
                    sSQL = "update UFSystem..UA_Identity set iFatherID = " + iIDArr + ",iChildID=" + iIDDetailArr + "  where cAcc_Id = '200' and cVouchType = 'PuArrival'";
                    aList.Add(sSQL);

                    //更新最大单据号

                    //到货单单据号记录
                    sSQL = "select count(*) as iCount From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='26' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(d单据日期.ToString("yyyy-MM-dd")).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(d单据日期.ToString("yyyy-MM-dd")).ToString("yyMM") + "')";
                    DataTable dtCodeTemp = clsSQLCommond.ExecQuery(sSQL);
                    if (dtCodeTemp.Rows[0]["iCount"].ToString().Trim() == "0")
                    {
                        sSQL = "insert into @u8.VoucherHistory(cardnumber,ccontent,ccontentrule,cseed,cnumber,bempty)values('26','单据日期','月','" + DateTime.Parse(d单据日期.ToString("yyyy-MM-dd")).ToString("yyMM") + "','1',0)";
                        aList.Add(sSQL);
                    }
                    else
                    {
                        sSQL = "update @u8.VoucherHistory set cNumber = '" + iCodeArr.ToString().Trim() + "' Where  CardNumber='26' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(d单据日期.ToString("yyyy-MM-dd")).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(d单据日期.ToString("yyyy-MM-dd")).ToString("yyMM") + "')";
                        aList.Add(sSQL);
                    }


                    //报检单单据号记录
                    sSQL = "select count(*) as iCount From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='QM01' and cContent like '%日期%' and (cSeed='" + DateTime.Parse(d单据日期.ToString("yyyy-MM-dd")).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(d单据日期.ToString("yyyy-MM-dd")).ToString("yyMM") + "')";
                    dtCodeTemp = clsSQLCommond.ExecQuery(sSQL);
                    if (dtCodeTemp.Rows[0]["iCount"].ToString().Trim() == "0")
                    {
                        sSQL = "insert into @u8.VoucherHistory(cardnumber,ccontent,ccontentrule,cseed,cnumber,bempty)values('QM01','报检日期','月','" + DateTime.Parse(d单据日期.ToString("yyyy-MM-dd")).ToString("yyyyMM") + "','1',0)";
                        aList.Add(sSQL);
                    }
                    else
                    {
                        sSQL = "update @u8.VoucherHistory set cNumber = '" + iCode报检.ToString().Trim() + "' Where  CardNumber='QM01' and (cContent='日期' or cContent='报检日期') and (cSeed='" + DateTime.Parse(d单据日期.ToString("yyyy-MM-dd")).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(d单据日期.ToString("yyyy-MM-dd")).ToString("yyMM") + "')";
                        aList.Add(sSQL);
                    }
                }

                //委外到货单
                DataRow[] dr3 = dt列表.Select("单据类型=3");
                if (dr3.Length > 0)
                {
                    Import委外到货单(dr3, out sInfo4, d单据日期);
                    if (aList.Count < 1)
                        return "没有需要导入的数据";

                    if (iIDArr > 1000000000)
                        iIDArr = iIDArr - 1000000000;
                    if (iIDDetailArr > 1000000000)
                        iIDDetailArr = iIDDetailArr - 1000000000;
                    sSQL = "update UFSystem..UA_Identity set iFatherID = " + iIDArr + ",iChildID=" + iIDDetailArr + "  where cAcc_Id = '200' and cVouchType = 'PuArrival'";
                    aList.Add(sSQL);

                    //更新最大单据号
                    //到货单单据号记录
                    sSQL = "select count(*) as iCount From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='26' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(d单据日期.ToString("yyyy-MM-dd")).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(d单据日期.ToString("yyyy-MM-dd")).ToString("yyMM") + "')";
                    DataTable dtCodeTemp = clsSQLCommond.ExecQuery(sSQL);
                    if (dtCodeTemp.Rows[0]["iCount"].ToString().Trim() == "0")
                    {
                        sSQL = "insert into @u8.VoucherHistory(cardnumber,ccontent,ccontentrule,cseed,cnumber,bempty)values('26','单据日期','月','" + DateTime.Parse(d单据日期.ToString("yyyy-MM-dd")).ToString("yyMM") + "','1',0)";
                        aList.Add(sSQL);
                    }
                    else
                    {
                        sSQL = "update @u8.VoucherHistory set cNumber = '" + iCodeArr.ToString().Trim() + "' Where  CardNumber='26' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(d单据日期.ToString("yyyy-MM-dd")).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(d单据日期.ToString("yyyy-MM-dd")).ToString("yyMM") + "')";
                        aList.Add(sSQL);
                    }

                    //报检单单据号记录
                    sSQL = "select count(*) as iCount From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='QM01' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(d单据日期.ToString("yyyy-MM-dd")).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(d单据日期.ToString("yyyy-MM-dd")).ToString("yyMM") + "')";
                    dtCodeTemp = clsSQLCommond.ExecQuery(sSQL);
                    if (dtCodeTemp.Rows[0]["iCount"].ToString().Trim() == "0")
                    {
                        sSQL = "insert into @u8.VoucherHistory(cardnumber,ccontent,ccontentrule,cseed,cnumber,bempty)values('QM01','报检日期','月','" + DateTime.Parse(d单据日期.ToString("yyyy-MM-dd")).ToString("yyMM") + "','1',0)";
                        aList.Add(sSQL);
                    }
                    else
                    {
                        sSQL = "update @u8.VoucherHistory set cNumber = '" + iCode报检.ToString().Trim() + "' Where  CardNumber='QM01' and (cContent='日期' or cContent='报检日期') and (cSeed='" + DateTime.Parse(d单据日期.ToString("yyyy-MM-dd")).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(d单据日期.ToString("yyyy-MM-dd")).ToString("yyMM") + "')";
                        aList.Add(sSQL);
                    }
                }

                sSQL = "insert into [UFDLImport].[dbo].[栈板厂商收发登记表]( 厂商编码, 单据类型, 单据号, 栈板1, 栈板2, 栈板3, 栈板4, 栈板5, 栈板6, 栈板7, 栈板8, 日期, 制单人, 制单日期, 审核人, 审核日期,确认人,确认日期)" +
                       "values('" + dt列表.Rows[0]["供应商编码"].ToString().Trim() + "','到货单','" + s到货单号 + "'," + i栈板1 + "," + i栈板2 + "," + i栈板3 + "," + i栈板4 + "," + i栈板5 + "," + i栈板6 + "," + i栈板7 + "," + i栈板8 + ",'" + d单据日期.ToString("yyyy-MM-dd") + "','" + dt列表.Rows[0]["制单人"].ToString().Trim() + "',getdate(),'" + dt列表.Rows[0]["制单人"].ToString().Trim() + "',getdate(),'" + dt列表.Rows[0]["制单人"].ToString().Trim() + "',getdate())";
                aList.Add(sSQL);

                clsSQLCommond.ExecSqlTran(aList);

                string sInfo = "";

                sReturn = "成功生成到货单：\r\n" + s到货单号 + "\r\n" + "成功生成报检单：\r\n" + s报检单号;
            }
            catch (Exception ee)
            {
                aList = null;
                sReturn = ee.Message;
            }
            return sReturn;
        }

        /// <summary>
        /// 返回出库单单据号
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        private string sSetOutCode(long s, DateTime d单据日期)
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

            return "OP" + d单据日期.ToString("yyMM") + sCode;
        }

        /// <summary>
        /// 获得单据ID
        /// </summary>
        /// <param name="sType">单据类型  PuArrival，</param>
        private void GetID(string sType, out long iID, out long iIDDetail)
        {
            string sSQL = @"
declare @p5 int
set @p5=1000589146
declare @p6 int
set @p6=1003092055
exec @u8.sp_GetId N'',N'200',N'aaaaaaaa',1,@p5 output,@p6 output,default
select @p5, @p6
";
            sSQL = sSQL.Replace("aaaaaaaa", sType);
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            if (dt == null || dt.Rows.Count < 1)
            {
                iID = 0;
                iIDDetail = 0;
            }
            else
            {
                iID = Convert.ToInt64(dt.Rows[0][0]);
                iIDDetail = Convert.ToInt64(dt.Rows[0][1]);
            }
        }

        public DataTable Get栈板打印(long lID)
        {
            string sSQL = "select * from [UFDLImport]..栈板打印登记 where iID = " + lID;
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            return dt;
        }

        /// <summary>
        /// 导入委外到货单，审核并报检
        /// </summary>
        /// <param name="dr2"></param>
        private void Import委外到货单(DataRow[] dr2, out string sInfo, DateTime date1)
        {
            string sSQL = "";
            sInfo = "";

            for (int i = 0; i < dr2.Length; i++)
            {
                if (dr2[i]["bUsed"].ToString().Trim() == "-1")
                {
                    iCodeArr += 1;
                    string sDepCode = dr2[i]["部门编码"].ToString().Trim();
                    string sRDCode = sSetCode(iCodeArr, sDepCode, date1);

                    iIDArr += 1;
                    iIDDetailArr += 1;

                    string sPersonCodeInfo = "null";
                    string sPersonNameInfo = "null";
                    if (dr2[i]["业务员"].ToString().Trim() != string.Empty)
                    {
                        sPersonCodeInfo = "'" + dr2[i]["业务员编码"].ToString().Trim() + "'";
                        sPersonNameInfo = "'" + dr2[i]["业务员"].ToString().Trim() + "'";
                    }
                    string s客户订单号 = "null";
                    if (dr2[i]["客户订单号"].ToString().Trim() != string.Empty)
                    {
                        s客户订单号 = "'" + dr2[i]["客户订单号"].ToString().Trim() + "'";
                    }
                    //表头
                    sSQL = "Insert Into @u8.PU_ArrivalVouch(ivtid,id,ccode,cptcode,ddate,cvencode,cdepcode,cpersoncode,cpaycode,csccode,cexch_name,iexchrate,itaxrate,cmemo," +
                                "cbustype,cmaker,bnegative,cdefine1,cdefine2,cdefine3,cdefine4,cdefine5,cdefine6,cdefine7,cdefine8,cdefine9,cdefine10,cdefine11,cdefine12,cdefine13,cdefine14,cdefine15,cdefine16,ccloser,idiscounttaxtype,ibilltype,cvouchtype,cgeneralordercode,ctmcode,cincotermcode,ctransordercode,dportdate,csportcode,caportcode,csvencode,carrivalplace,dclosedate,idec,bcal,guid,iverifystate,cauditdate,cverifier,iverifystateex,ireturncount,iswfcontrolled,cvenpuomprotocol) " +
                           "Values( 8169," + iIDArr + ",'" + sRDCode + "','02','" + date1.ToString("yyyy-MM-dd") + "','" + dr2[i]["供应商编码"].ToString().Trim() + "','" + sDepCode + "'," + sPersonCodeInfo + ",'03',NULL,N'人民币',1," + iTaxRate_All .ToString()+ ",NULL, " +
                                "N'委外加工','" + dr2[i]["制单人"].ToString().Trim() + "',0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'" + dr2[i]["制单人"].ToString().Trim() + "',NULL,NULL,NULL,0,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,NULL) ";
                    aList.Add(sSQL);

                    s到货单号 = s到货单号 + sRDCode + "\r\n";

                    //审核到货单
                    sSQL = "Update @u8.PU_ArrivalVouch Set cAuditTime = GetDate(),cAuditDate = N'" + date1.ToString("yyyy-MM-dd") + "',cVerifier=N'" + dr2[i]["制单人"].ToString().Trim() + "',iverifystateex='2' where ID=N'" + iIDArr + "' and isnull(cVerifier,'')='' and isnull(cCloser,'')=''";
                    aList.Add(sSQL);


                    //报检单表头
                    iID报检 += 1;
                    iCode报检 += 1;
                    sSQL = "INSERT INTO @u8.QMInspectVoucher (ID,IVTID,CINSPECTCODE,CREJECTCODE,CSOURCECODE,REJECTID,CSOURCEID,CDEPCODE,DDATE,CTIME" +
                                ",CSOURCE,CVOUCHTYPE,CMAKER,CVERIFIER,CDEFINE1,CDEFINE2,CDEFINE3,CDEFINE4,CDEFINE5,CDEFINE6" +
                                ",CDEFINE7,CDEFINE8,CDEFINE9,CDEFINE10,CDEFINE11,CDEFINE12,CDEFINE13,CDEFINE14,CDEFINE15,CDEFINE16" +
                                ",CINSPECTDEPCODE,CCUSCODE,CCHECKTYPECODE,DARRIVALDATE,CVENCODE,IWORKCENTER,DMAKETIME,CPROCESSAUTOID,DVERIFYDATE,DVERIFYTIME) " +
                                "VALUES( " + iID报检 + " ,351,N'" + sGet报检单号(iCode报检, date1).ToString().Trim() + "',NULL,N'" + sRDCode + "',NULL," + iIDArr + ",N'" + sDepCode + "',N'" + date1.ToString("yyyy-MM-dd") + "',N'" + DateTime.Now.ToString("hh:mm:ss") + "'" +
                            ",N'到货单',N'QM01',N'" + dr2[i]["制单人"].ToString().Trim() + "',N'" + dr2[i]["制单人"].ToString().Trim() + "',NULL,null,NULL,NULL,NULL,NULL" +
                            ",NULL,NULL,NULL,NULL,NULL,NULL,NULL,null,NULL,NULL" +
                            ",NULL,NULL,N'ARR',N'" + date1.ToString("yyyy-MM-dd") + "',N'" + dr2[i]["供应商编码"].ToString().Trim() + "',NULL,GetDate(),NULL,'" + date1.ToString("yyyy-MM-dd") + "',getdate()) ";
                    aList.Add(sSQL);


                    s报检单号 = s报检单号 + sGet报检单号(iCode报检, date1).ToString().Trim() + "\r\n";

                    sInfo = sInfo + sRDCode + ";";
                    //表体 

                    string s本次到货件数 = "null";
                    if (dr2[i]["本次到货件数"].ToString().Trim() != string.Empty)
                        s本次到货件数 = dr2[i]["本次到货件数"].ToString().Trim();
                    if (s本次到货件数 == "null" || double.Parse(s本次到货件数) == 0)
                        s本次到货件数 = "null";
                    string s本次到货数量 = "null";
                    if (dr2[i]["本次到货数量"].ToString().Trim() != string.Empty)
                        s本次到货数量 = dr2[i]["本次到货数量"].ToString().Trim();

                    sSQL = " Insert Into @u8.PU_ArrivalVouchs(autoid,id,cwhcode,cinvcode,inum,iquantity," +
                               "ioricost,ioritaxcost,iorimoney,ioritaxprice,iorisum,icost,imoney,itaxprice,isum,itaxrate," +
                               "citem_class,citemcode,iposid,citemname,frealquantity,fvalidquantity,bgsp,btaxcost,sodid," +
                               "sotype,iinvexchrate,csocode,cordercode,rejectsource,iexpiratdatecalcu,cDefine28) Values  " +
                           "(" + iIDDetailArr + "," + iIDArr + ",N'" + dr2[i]["默认仓库编码"] + "',N'" + dr2[i]["物料编码"] + "'," + s本次到货件数 + "," + s本次到货数量 + "," +
                               "null,null,null,null,null,null,null,null,null,13," +
                               "null,null," + dr2[i]["订单子表ID"] + ",null,null,null,0,1,N'" + dr2[i]["订单子表ID"] + "'," +
                               "0,0,null,N'" + dr2[i]["订单号"] + "',0,0,'" + dr2[i]["货位编码"] + "')";
                    aList.Add(sSQL);


                    //生成来料报检单时回写到货单数据
                    sSQL = "UPDATE @u8.Pu_ArrivalVouchs SET bInspect =1,fInspectQuantity = ISNULL(fInspectQuantity,0)+" + s本次到货数量 + ",fInspectNum = ISNULL(fInspectNum,0)+" + s本次到货件数 + " WHERE AutoID=" + iIDDetailArr;
                    aList.Add(sSQL);

                    string s辅计量单位编码 = "null";
                    string s换算率 = "null";
                    if (dr2[i]["辅计量单位编码"].ToString().Trim() != "")
                    {
                        s辅计量单位编码 = "'" + dr2[i]["辅计量单位编码"].ToString().Trim() + "'";
                        s换算率 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(s本次到货数量) / MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(s本次到货件数)).ToString();
                    }

                    //来料报检单表体
                    iIDDetail报检 += 1;
                    sSQL = "INSERT INTO @u8.QMInspectVouchers(ID,AUTOID,CITEMCLASS,CITEMCODE,CITEMCNAME,CITEMNAME,REJECTAUTOID,SOURCEAUTOID,ITESTSTYLE,CWHCODE" +
                                ",CINVCODE,CBATCH,DPRODATE,DVDATE,CUNITID,FCHANGRATE,FQUANTITY,FNUM,BFLAG,CFREE1" +
                                ",CFREE2,CFREE3,CFREE4,CFREE5,CFREE6,CFREE7,CFREE8,CFREE9,CFREE10,CBATCHPROPERTY1" +
                                ",CBATCHPROPERTY2,CBATCHPROPERTY3,CBATCHPROPERTY4,CBATCHPROPERTY5,CBATCHPROPERTY6,CBATCHPROPERTY7,CBATCHPROPERTY8,CBATCHPROPERTY9,CBATCHPROPERTY10,CDEFINE22" +
                                ",CDEFINE23,CDEFINE24,CDEFINE25,CDEFINE26,CDEFINE27,CDEFINE28,CDEFINE29,CDEFINE30,CDEFINE31,CDEFINE32" +
                                ",CDEFINE33,CDEFINE34,CDEFINE35,CDEFINE36,CDEFINE37,IMASSDATE,CMASSUNIT,CPROBATCH,CBYPRODUCT,CPOSITION" +
                                ",PCSTRANSTYPE, IORDERTYPE,CSOORDERCODE,ISOORDERAUTOID,CPROORDERCODE,IPROORDERID,IPROORDERAUTOID,CCONTRACTCODE,CCONTRACTSTRCODE,CPOCODE" +
                                ",BEXIGENCY,CSOURCEPROORDERCODE,ISOURCEPROORDERROWNO,ISOURCEPROORDERID,ISOURCEPROORDERAUTOID,IEXPIRATDATECALCU,CEXPIRATIONDATE,DEXPIRATIONDATE,IORDERDID,ISOORDERTYPE" +
                                ",CORDERCODE,IORDERSEQ,CVMIVENCODE ) " +
                            "VALUES(" + iID报检 + ",  " + iIDDetail报检 + " ,N'" + dr2[i]["项目大类编码"] + "',N'" + dr2[i]["项目编码"] + "',N'外销订单项目',N'" + dr2[i]["项目名称"] + "',NULL," + iIDDetailArr + ",N'0',N'" + dr2[i]["默认仓库编码"] + "'" +
                                ",N'" + dr2[i]["物料编码"] + "',NULL,NULL,NULL," + s辅计量单位编码 + "," + s换算率 + "," + s本次到货数量 + "," + s本次到货件数 + ",NULL,NULL" +
                                ",NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL" +
                                ",NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL" +
                                ",NULL,NULL,NULL,NULL,NULL,'" + dr2[i]["货位编码"] + "',NULL,NULL,NULL,NULL" +
                                ",NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL" +
                                ",NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,N'" + dr2[i]["订单号"].ToString().Trim() + "'" +
                                ",0,NULL,NULL,NULL,NULL,N'0',NULL,NULL,NULL,NULL" +
                                ",NULL,NULL,NULL) ";
                    aList.Add(sSQL);

                    sSQL = "select isnull(bPropertyCheck,0) as bPropertyCheck,cAssComUnitCode from @u8.Inventory  where cInvCode = '" + dr2[i]["物料编码"] + "' ";
                    DataTable dtGSP = clsSQLCommond.ExecQuery(sSQL);
                    if (dtGSP.Rows[0]["bPropertyCheck"].ToString().Trim() == "1" || Convert.ToBoolean(dtGSP.Rows[0]["bPropertyCheck"]))
                    {
                        sSQL = "update  @u8.PU_ArrivalVouchs set  bGsp = 1 where autoid = " + iIDDetailArr;
                        aList.Add(sSQL);
                    }

                    sSQL = "select * from @u8.OM_MODetails where MODetailsID = " + dr2[i]["订单子表ID"].ToString().Trim();
                    DataTable dtPodetails = clsSQLCommond.ExecQuery(sSQL);

                    //原币含税单价  6位
                    //无税单价      6位
                    //数量          6位
                    //价税合计      2位   原币含税单价 * 数量
                    //无税金额      2位   价税合计 / （1 + 税率） 
                    //税额          2位   价税合计 - 无税金额 
                    //----------------------------------------------------------------------------------------------------------------

                    //税率
                    decimal d税率 = decimal.Round(Convert.ToDecimal(dtPodetails.Rows[0]["ipertaxrate"]), 2);
                    //单价(不含税)
                    decimal d原币无税单价 = decimal.Round(Convert.ToDecimal(dtPodetails.Rows[0]["iUnitPrice"]), 3);
                    //金额(不含税)
                    decimal d原币金额 = decimal.Round(d原币无税单价 * decimal.Parse(s本次到货数量), 2);
                    //原币含税单价
                    decimal d原币含税单价 = decimal.Round(Convert.ToDecimal(dtPodetails.Rows[0]["iTaxPrice"]), 6);
                    //原币价税合计
                    decimal d原币价税合计 = decimal.Round(d原币含税单价 * decimal.Round(decimal.Parse(s本次到货数量), 6), 2);
                    //原币无税金额 
                    decimal d原币无税金额 = decimal.Round(d原币价税合计 / (1 + d税率 / 100), 2);
                    //原币税额 
                    decimal d原币税额 = d原币价税合计 - d原币无税金额;


                    sSQL = "update @u8.PU_ArrivalVouchs set iOriCost= " + d原币无税单价 + ",iOriTaxCost = " + d原币含税单价 + ",iOriMoney = " + d原币无税金额 + ",iOriTaxPrice = " + d原币税额 + "," +
                                "iOriSum = " + d原币价税合计 + ",iCost = " + d原币无税单价 + ",iMoney = " + d原币无税金额 + ",iTaxPrice = " + d原币税额 + ",iSum = " + d原币价税合计 + ",iTaxRate = " + d税率 + " " +
                            " where autoid = " + iIDDetailArr;
                    aList.Add(sSQL);

                    if (dtPodetails.Rows[0]["iNum"].ToString().Trim() != string.Empty && Convert.ToDouble(dtPodetails.Rows[0]["iNum"]) != 0)
                    {
                        sSQL = "update @u8.PU_ArrivalVouchs set iinvexchrate=cast((" + s本次到货数量 + "/" + s本次到货件数 + ")  as decimal(18, 6)),inum=" + s本次到货件数 + " " +
                                        " ,cUnitID = '" + dtGSP.Rows[0]["cAssComUnitCode"].ToString().Trim() + "' " +
                               " where autoid = " + iIDDetailArr;
                        aList.Add(sSQL);
                    }
                    else
                    {
                        sSQL = "update @u8.PU_ArrivalVouchs set iinvexchrate = null " +
                               " where autoid = " + iIDDetailArr;
                        aList.Add(sSQL); 
                    }


                    if (dtPodetails.Rows[0]["citemName"].ToString().Trim() != string.Empty)
                    {

                        sSQL = "update @u8.PU_ArrivalVouchs set citem_class='" + dtPodetails.Rows[0]["citem_class"] + "',citemcode='" + dtPodetails.Rows[0]["citemcode"] + "',cItemName='" + dtPodetails.Rows[0]["citemName"] + "' " +
                                " where autoid = " + iIDDetailArr;
                        aList.Add(sSQL);
                    }

                    sSQL = "update @u8.OM_MODetails set iTaxPrice = " + d原币含税单价 + ",iArrMoney = isnull(iArrMoney,0) + " + d原币价税合计 + ",iNatArrMoney = isnull(iNatArrMoney,0) + " + d原币价税合计 + ",iArrQTY = isnull(iArrQTY,0) + " + s本次到货数量 + ",iArrNum =  isnull(iArrNum,0) + " + s本次到货件数 + " where MODetailsID = " + dr2[i]["订单子表ID"].ToString().Trim();
                    aList.Add(sSQL);

                    dr2[i]["bUsed"] = iIDArr;
                }
                else
                {
                    continue;
                }

                for (int j = i + 1; j < dr2.Length; j++)
                {
                    if (dr2[j]["bUsed"].ToString().Trim() == "-1" && dr2[i]["默认仓库编码"].ToString().Trim() == dr2[j]["默认仓库编码"].ToString().Trim())
                    {
                        iIDDetailArr += 1;
                        //表体 
                        string s本次到货件数 = "null";
                        if (dr2[j]["本次到货件数"].ToString().Trim() != string.Empty)
                            s本次到货件数 = dr2[j]["本次到货件数"].ToString().Trim();
                        if (s本次到货件数 == "null" || double.Parse(s本次到货件数) == 0)
                            s本次到货件数 = "null";
                        string s本次到货数量 = "null";
                        if (dr2[j]["本次到货数量"].ToString().Trim() != string.Empty)
                            s本次到货数量 = dr2[j]["本次到货数量"].ToString().Trim();

                        sSQL = " Insert Into @u8.PU_ArrivalVouchs(autoid,id,cwhcode,cinvcode,inum,iquantity," +
                                    "ioricost,ioritaxcost,iorimoney,ioritaxprice,iorisum,icost,imoney,itaxprice,isum,itaxrate," +
                                    "citem_class,citemcode,iposid,citemname,frealquantity,fvalidquantity,bgsp,btaxcost,sodid," +
                                    "sotype,iinvexchrate,csocode,cordercode,rejectsource,iexpiratdatecalcu,cDefine28) Values  " +
                                "(" + iIDDetailArr + "," + iIDArr + ",N'" + dr2[j]["默认仓库编码"] + "',N'" + dr2[j]["物料编码"] + "'," + s本次到货件数 + "," + s本次到货数量 + "," +
                                    "null,null,null,null,null,null,null,null,null,13," +
                                    "null,null," + dr2[j]["订单子表ID"] + ",null,null,null,0,1,N'" + dr2[j]["订单子表ID"] + "'," +
                                    "0,0,null,N'" + dr2[j]["订单号"] + "',0,0,'" + dr2[j]["货位编码"] + "')";
                        aList.Add(sSQL);


                        //生成来料报检单时回写到货单数据
                        sSQL = "UPDATE @u8.Pu_ArrivalVouchs SET bInspect =1,fInspectQuantity = ISNULL(fInspectQuantity,0)+" + s本次到货数量 + ",fInspectNum = ISNULL(fInspectNum,0)+" + s本次到货件数 + " WHERE AutoID=" + iIDDetailArr;
                        aList.Add(sSQL);

                        string s辅计量单位编码 = "null";
                        string s换算率 = "null";
                        if (dr2[j]["辅计量单位编码"].ToString().Trim() != "")
                        {
                            s辅计量单位编码 = "'" + dr2[j]["辅计量单位编码"].ToString().Trim() + "'";
                            s换算率 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(s本次到货数量) / MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(s本次到货件数)).ToString();
                        }

                        //来料报检单表体
                        iIDDetail报检 += 1;
                        sSQL = "INSERT INTO @u8.QMInspectVouchers(ID,AUTOID,CITEMCLASS,CITEMCODE,CITEMCNAME,CITEMNAME,REJECTAUTOID,SOURCEAUTOID,ITESTSTYLE,CWHCODE" +
                                    ",CINVCODE,CBATCH,DPRODATE,DVDATE,CUNITID,FCHANGRATE,FQUANTITY,FNUM,BFLAG,CFREE1" +
                                    ",CFREE2,CFREE3,CFREE4,CFREE5,CFREE6,CFREE7,CFREE8,CFREE9,CFREE10,CBATCHPROPERTY1" +
                                    ",CBATCHPROPERTY2,CBATCHPROPERTY3,CBATCHPROPERTY4,CBATCHPROPERTY5,CBATCHPROPERTY6,CBATCHPROPERTY7,CBATCHPROPERTY8,CBATCHPROPERTY9,CBATCHPROPERTY10,CDEFINE22" +
                                    ",CDEFINE23,CDEFINE24,CDEFINE25,CDEFINE26,CDEFINE27,CDEFINE28,CDEFINE29,CDEFINE30,CDEFINE31,CDEFINE32" +
                                    ",CDEFINE33,CDEFINE34,CDEFINE35,CDEFINE36,CDEFINE37,IMASSDATE,CMASSUNIT,CPROBATCH,CBYPRODUCT,CPOSITION" +
                                    ",PCSTRANSTYPE, IORDERTYPE,CSOORDERCODE,ISOORDERAUTOID,CPROORDERCODE,IPROORDERID,IPROORDERAUTOID,CCONTRACTCODE,CCONTRACTSTRCODE,CPOCODE" +
                                    ",BEXIGENCY,CSOURCEPROORDERCODE,ISOURCEPROORDERROWNO,ISOURCEPROORDERID,ISOURCEPROORDERAUTOID,IEXPIRATDATECALCU,CEXPIRATIONDATE,DEXPIRATIONDATE,IORDERDID,ISOORDERTYPE" +
                                    ",CORDERCODE,IORDERSEQ,CVMIVENCODE ) " +
                                "VALUES(" + iID报检 + ",  " + iIDDetail报检 + " ,N'" + dr2[j]["项目大类编码"] + "',N'" + dr2[j]["项目编码"] + "',N'外销订单项目',N'" + dr2[j]["项目名称"] + "',NULL," + iIDDetailArr + ",N'0',N'" + dr2[j]["默认仓库编码"] + "'" +
                                    ",N'" + dr2[j]["物料编码"] + "',NULL,NULL,NULL," + s辅计量单位编码 + "," + s换算率 + "," + s本次到货数量 + "," + s本次到货件数 + ",NULL,NULL" +
                                    ",NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL" +
                                    ",NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL" +
                                    ",NULL,NULL,NULL,NULL,NULL,'" + dr2[j]["货位编码"] + "',NULL,NULL,NULL,NULL" +
                                    ",NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL" +
                                    ",NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,N'" + dr2[j]["订单号"].ToString().Trim() + "'" +
                                    ",0,NULL,NULL,NULL,NULL,N'0',NULL,NULL,NULL,NULL" +
                                    ",NULL,NULL,NULL) ";
                        aList.Add(sSQL);


                        sSQL = "select isnull(bPropertyCheck,0) as bPropertyCheck ,cAssComUnitCode from @u8.Inventory  where cInvCode = '" + dr2[j]["物料编码"] + "' ";
                        DataTable dtGSP = clsSQLCommond.ExecQuery(sSQL);
                        if (dtGSP.Rows[0]["bPropertyCheck"].ToString().Trim() == "1" || Convert.ToBoolean(dtGSP.Rows[0]["bPropertyCheck"]))
                        {
                            sSQL = "update  @u8.PU_ArrivalVouchs set  bGsp = 1 where autoid = " + iIDDetailArr;
                            aList.Add(sSQL);
                        }


                        sSQL = "select * from @u8.OM_MODetails where MODetailsID = " + dr2[j]["订单子表ID"].ToString().Trim();
                        DataTable dtPodetails = clsSQLCommond.ExecQuery(sSQL);

                        //税率
                        decimal d税率 = decimal.Round(Convert.ToDecimal(dtPodetails.Rows[0]["ipertaxrate"]), 2);
                        //单价(不含税)
                        decimal d原币无税单价 = decimal.Round(Convert.ToDecimal(dtPodetails.Rows[0]["iUnitPrice"]), 3);
                        //金额(不含税)
                        decimal d原币金额 = decimal.Round(d原币无税单价 * decimal.Parse(s本次到货数量), 2);
                        //原币含税单价
                        decimal d含税单价 = decimal.Round(Convert.ToDecimal(dtPodetails.Rows[0]["iTaxPrice"]), 6);
                        //原币价税合计
                        decimal d原币价税合计 = decimal.Round(d含税单价 * decimal.Round(decimal.Parse(s本次到货数量), 6), 2);
                        //原币无税金额 
                        decimal d原币无税金额 = decimal.Round(d原币价税合计 / (1 + d税率 / 100), 2);
                        //原币税额 
                        decimal d原币税额 = d原币价税合计 - d原币无税金额;

                        sSQL = "update @u8.PU_ArrivalVouchs set iOriCost= " + d原币无税单价 + ",iOriTaxCost = " + d含税单价 + ",iOriMoney = " + d原币无税金额 + ",iOriTaxPrice = " + d原币税额 + "," +
                                    "iOriSum = " + d原币价税合计 + ",iCost = " + d原币无税单价 + ",iMoney = " + d原币无税金额 + ",iTaxPrice = " + d原币税额 + ",iSum = " + d原币价税合计 + ",iTaxRate = " + d税率 + " " +
                                " where autoid = " + iIDDetailArr;
                        aList.Add(sSQL);

                        if (dtPodetails.Rows[0]["iNum"].ToString().Trim() != string.Empty && Convert.ToDouble(dtPodetails.Rows[0]["iNum"]) != 0)
                        {
                            sSQL = "update @u8.PU_ArrivalVouchs set iinvexchrate=cast((" + s本次到货数量 + "/" + s本次到货件数 + ")  as decimal(18, 6)),inum=" + s本次到货件数 + " " +
                                        " ,cUnitID = '" + dtGSP.Rows[0]["cAssComUnitCode"].ToString().Trim() + "' " +
                                   " where autoid = " + iIDDetailArr;
                            aList.Add(sSQL);
                        }
                        else
                        {
                            sSQL = "update @u8.PU_ArrivalVouchs set iinvexchrate = null " +
                                   " where autoid = " + iIDDetailArr;
                            aList.Add(sSQL);
                        }

                        if (dtPodetails.Rows[0]["citemName"].ToString().Trim() != string.Empty)
                        {

                            sSQL = "update @u8.PU_ArrivalVouchs set citem_class='" + dtPodetails.Rows[0]["citem_class"] + "',citemcode='" + dtPodetails.Rows[0]["citemcode"] + "',cItemName='" + dtPodetails.Rows[0]["citemName"] + "' " +
                                    " where autoid = " + iIDDetailArr;
                            aList.Add(sSQL);
                        }

                        sSQL = "update @u8.OM_MODetails set iTaxPrice = " + d含税单价 + ",iArrMoney = isnull(iArrMoney,0) + " + d原币价税合计 + ",iNatArrMoney = isnull(iNatArrMoney,0) + " + d原币价税合计 + ",iArrQTY = isnull(iArrQTY,0) + " + s本次到货数量 + ",iArrNum =  isnull(iArrNum,0) + " + s本次到货件数 + " where MODetailsID = " + dr2[j]["订单子表ID"].ToString().Trim();
                        aList.Add(sSQL);

                        dr2[j]["bUsed"] = iIDArr;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }


        /// <summary>
        /// 导入采购到货单，审核并报检
        /// </summary>
        /// PU_ArrivalVouch:	[cPersonCode,cPayCode,]cDefine2(客户订单号),cDefine11(外销订单号)
        ///PU_ArrivalVouchs:	cdefine37,csocode,sodid
        /// <param name="dr"></param>
        private void Import采购到货单(DataRow[] dr, out string sInfo, DateTime date1)
        {
            string sSQL = "";
            sInfo = "";

            for (int i = 0; i < dr.Length; i++)
            {
                if (dr[i]["bUsed"].ToString().Trim() == "-1")
                {
                    iCodeArr += 1;
                    string sDepCode = dr[i]["部门编码"].ToString().Trim();
                    string sRDCode = sSetCode(iCodeArr, sDepCode, date1);

                    iIDArr += 1;
                    iIDDetailArr += 1;

                    string sPersonCodeInfo = "null";
                    string sPersonNameInfo = "null";
                    if (dr[i]["业务员"].ToString().Trim() != string.Empty)
                    {
                        sPersonCodeInfo = "'" + dr[i]["业务员编码"].ToString().Trim() + "'";
                        sPersonNameInfo = "'" + dr[i]["业务员"].ToString().Trim() + "'";
                    }
                    string s客户订单号 = "null";
                    if (dr[i]["客户订单号"].ToString().Trim() != string.Empty)
                    {
                        s客户订单号 = "'" + dr[i]["客户订单号"].ToString().Trim() + "'";
                    }
                    //表头
                    sSQL = "Insert Into @u8.PU_ArrivalVouch(ivtid,id,ccode,cptcode,ddate,cvencode,cdepcode,cpersoncode,cpaycode,csccode,cexch_name,iexchrate,itaxrate,cmemo," +
                                "cbustype,cmaker,bnegative,cdefine1,cdefine2,cdefine3,cdefine4,cdefine5,cdefine6,cdefine7,cdefine8,cdefine9,cdefine10" +
                                ",cdefine11,cdefine12,cdefine13,cdefine14,cdefine15,cdefine16,ccloser,idiscounttaxtype,ibilltype" +
                                ",cvouchtype,cgeneralordercode,ctmcode,cincotermcode,ctransordercode,dportdate,csportcode,caportcode" +
                                ",csvencode,carrivalplace,dclosedate,idec,bcal,guid,iverifystate,cauditdate,cverifier,iverifystateex,ireturncount,iswfcontrolled,cvenpuomprotocol) " +
                           "Values( 8169," + iIDArr + ",'" + sRDCode + "','01','" + date1.ToString("yyyy-MM-dd") + "','" + dr[i]["供应商编码"].ToString().Trim() + "','" + sDepCode + "'," + sPersonCodeInfo + ",'03',NULL,N'人民币',1,13,NULL, " +
                                "N'普通采购','" + dr[i]["制单人"].ToString().Trim() + "',0,NULL," + s客户订单号 + ",NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL" +
                                ",NULL,NULL,NULL,'" + dr[i]["制单人"].ToString().Trim() + "',NULL,NULL,NULL,0,0" +
                                ",NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL" +
                                ",NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,NULL) ";
                    aList.Add(sSQL);

                    //审核到货单
                    sSQL = "Update @u8.PU_ArrivalVouch Set cAuditTime = GetDate(),cAuditDate = N'" + date1.ToString("yyyy-MM-dd") + "',cVerifier=N'" + dr[i]["制单人"].ToString().Trim() + "',iverifystateex='2' where ID=N'" + iIDArr + "' and isnull(cVerifier,'')='' and isnull(cCloser,'')=''";
                    aList.Add(sSQL);

                    s到货单号 = s到货单号 + sRDCode + "\r\n";

                    //报检单表头
                    iID报检 += 1;
                    iCode报检 += 1;
                    sSQL = "INSERT INTO @u8.QMInspectVoucher (ID,IVTID,CINSPECTCODE,CREJECTCODE,CSOURCECODE,REJECTID,CSOURCEID,CDEPCODE,DDATE,CTIME" +
                                ",CSOURCE,CVOUCHTYPE,CMAKER,CVERIFIER,CDEFINE1,CDEFINE2,CDEFINE3,CDEFINE4,CDEFINE5,CDEFINE6" +
                                ",CDEFINE7,CDEFINE8,CDEFINE9,CDEFINE10,CDEFINE11,CDEFINE12,CDEFINE13,CDEFINE14,CDEFINE15,CDEFINE16" +
                                ",CINSPECTDEPCODE,CCUSCODE,CCHECKTYPECODE,DARRIVALDATE,CVENCODE,IWORKCENTER,DMAKETIME,CPROCESSAUTOID,DVERIFYDATE,DVERIFYTIME) " +
                                "VALUES( " + iID报检 + " ,351,N'" + sGet报检单号(iCode报检, date1).ToString().Trim() + "',NULL,N'" + sRDCode + "',NULL," + iIDArr + ",N'" + sDepCode + "',N'" + date1.ToString("yyyy-MM-dd") + "',N'" + DateTime.Now.ToString("hh:mm:ss") + "'" +
                            ",N'到货单',N'QM01',N'" + dr[i]["制单人"].ToString().Trim() + "',N'" + dr[i]["制单人"].ToString().Trim() + "',NULL," + s客户订单号 + ",NULL,NULL,NULL,NULL" +
                            ",NULL,NULL,NULL,NULL,NULL,NULL,NULL," + sPersonNameInfo + ",NULL,NULL" +
                            ",NULL,NULL,N'ARR',N'" + date1.ToString("yyyy-MM-dd") + "',N'" + dr[i]["供应商编码"].ToString().Trim() + "',NULL,GetDate(),NULL,'" + date1.ToString("yyyy-MM-dd") + "',getdate()) ";
                    aList.Add(sSQL);


                    s报检单号 = s报检单号 + sGet报检单号(iCode报检, date1).ToString().Trim() + "\r\n";

                    sInfo = sInfo + sRDCode + ";";

                    //表体 
                    string s本次到货件数 = "null";
                    if (dr[i]["本次到货件数"].ToString().Trim() != string.Empty)
                        s本次到货件数 = dr[i]["本次到货件数"].ToString().Trim();
                    if (s本次到货件数 == "null" || double.Parse(s本次到货件数) == 0)
                        s本次到货件数 = "null";

                    string s本次到货数量 = "null";
                    if (dr[i]["本次到货数量"].ToString().Trim() != string.Empty)
                        s本次到货数量 = dr[i]["本次到货数量"].ToString().Trim();

                    sSQL = "select * from @u8.PO_Podetails where id = " + dr[i]["订单子表ID"];
                    DataTable dtPodetails = clsSQLCommond.ExecQuery(sSQL);

                    sSQL = " Insert Into @u8.PU_ArrivalVouchs(autoid,id,cwhcode,cinvcode,inum,iquantity," +
                            "ioricost,ioritaxcost,iorimoney,ioritaxprice,iorisum,icost,imoney,itaxprice,isum,itaxrate," +
                            "citem_class,citemcode,iposid,citemname,frealquantity,fvalidquantity,bgsp,btaxcost,sodid," +
                            "sotype,iinvexchrate,csocode,cordercode,rejectsource,iexpiratdatecalcu,cDefine28) Values  " +
                        "(" + iIDDetailArr + "," + iIDArr + ",N'" + dr[i]["默认仓库编码"] + "',N'" + dr[i]["物料编码"] + "'," + s本次到货件数 + "," + s本次到货数量 + "," +
                            "null,null,null,null,null,null,null,null,null,13," +
                            "'" + dr[i]["项目大类编码"] + "','" + dr[i]["项目编码"] + "'," + dr[i]["订单子表ID"] + ",'" + dr[i]["项目名称"] + "',null,null,0,1,N'" + dr[i]["订单子表ID"] + "'," +
                            "0,0,null,N'" + dr[i]["订单号"].ToString().Trim() + "',0,0,'" + dr[i]["货位编码"] + "')";
                    aList.Add(sSQL);

                    //生成来料报检单时回写到货单数据
                    sSQL = "UPDATE @u8.Pu_ArrivalVouchs SET bInspect =1,fInspectQuantity = ISNULL(fInspectQuantity,0)+" + s本次到货数量 + ",fInspectNum = ISNULL(fInspectNum,0)+" + s本次到货件数 + " WHERE AutoID=" + iIDDetailArr;
                    aList.Add(sSQL);


                    string s辅计量单位编码 = "null";
                    string s换算率 = "null";
                    if (dr[i]["辅计量单位编码"].ToString().Trim() != "")
                    {
                        s辅计量单位编码 = "'" + dr[i]["辅计量单位编码"].ToString().Trim() + "'";
                        s换算率 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(s本次到货数量) / MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(s本次到货件数)).ToString();
                    }


                    //来料报检单表体
                    iIDDetail报检 += 1;
                    sSQL = "INSERT INTO @u8.QMInspectVouchers(ID,AUTOID,CITEMCLASS,CITEMCODE,CITEMCNAME,CITEMNAME,REJECTAUTOID,SOURCEAUTOID,ITESTSTYLE,CWHCODE" +
                                ",CINVCODE,CBATCH,DPRODATE,DVDATE,CUNITID,FCHANGRATE,FQUANTITY,FNUM,BFLAG,CFREE1" +
                                ",CFREE2,CFREE3,CFREE4,CFREE5,CFREE6,CFREE7,CFREE8,CFREE9,CFREE10,CBATCHPROPERTY1" +
                                ",CBATCHPROPERTY2,CBATCHPROPERTY3,CBATCHPROPERTY4,CBATCHPROPERTY5,CBATCHPROPERTY6,CBATCHPROPERTY7,CBATCHPROPERTY8,CBATCHPROPERTY9,CBATCHPROPERTY10,CDEFINE22" +
                                ",CDEFINE23,CDEFINE24,CDEFINE25,CDEFINE26,CDEFINE27,CDEFINE28,CDEFINE29,CDEFINE30,CDEFINE31,CDEFINE32" +
                                ",CDEFINE33,CDEFINE34,CDEFINE35,CDEFINE36,CDEFINE37,IMASSDATE,CMASSUNIT,CPROBATCH,CBYPRODUCT,CPOSITION" +
                                ",PCSTRANSTYPE, IORDERTYPE,CSOORDERCODE,ISOORDERAUTOID,CPROORDERCODE,IPROORDERID,IPROORDERAUTOID,CCONTRACTCODE,CCONTRACTSTRCODE,CPOCODE" +
                                ",BEXIGENCY,CSOURCEPROORDERCODE,ISOURCEPROORDERROWNO,ISOURCEPROORDERID,ISOURCEPROORDERAUTOID,IEXPIRATDATECALCU,CEXPIRATIONDATE,DEXPIRATIONDATE,IORDERDID,ISOORDERTYPE" +
                                ",CORDERCODE,IORDERSEQ,CVMIVENCODE ) " +
                            "VALUES(" + iID报检 + ",  " + iIDDetail报检 + " ,N'" + dr[i]["项目大类编码"] + "',N'" + dr[i]["项目编码"] + "',N'外销订单项目',N'" + dr[i]["项目名称"] + "',NULL," + iIDDetailArr + ",N'0',N'" + dr[i]["默认仓库编码"] + "'" +
                                ",N'" + dr[i]["物料编码"] + "',NULL,NULL,NULL," + s辅计量单位编码 + "," + s换算率 + ", " + s本次到货数量 + "," + s本次到货件数 + ",NULL,NULL" +
                                ",NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL" +
                                ",NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL" +
                                ",NULL,NULL,NULL,NULL,NULL,'" + dr[i]["货位编码"] + "',NULL,NULL,NULL,NULL" +
                                ",NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL" +
                                ",NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,N'" + dr[i]["订单号"].ToString().Trim() + "'" +
                                ",0,NULL,NULL,NULL,NULL,N'0',NULL,NULL,NULL,NULL" +
                                ",NULL,NULL,NULL) ";
                    aList.Add(sSQL);

                    sSQL = "select isnull(bPropertyCheck,0) as bPropertyCheck,cAssComUnitCode from @u8.Inventory  where cInvCode = '" + dr[i]["物料编码"].ToString().Trim() + "' ";
                    DataTable dtGSP = clsSQLCommond.ExecQuery(sSQL);
                    if (dtGSP.Rows[0]["bPropertyCheck"].ToString().Trim() == "1" || Convert.ToBoolean(dtGSP.Rows[0]["bPropertyCheck"]))
                    {
                        sSQL = "update  @u8.PU_ArrivalVouchs set  bGsp = 1 where autoid = " + iIDDetailArr;
                        aList.Add(sSQL);
                    }

                    //原币含税单价  6位
                    //无税单价      6位
                    //数量          6位
                    //价税合计      2位   原币含税单价 * 数量
                    //无税金额      2位   价税合计 / （1 + 税率） 
                    //税额          2位   价税合计 - 无税金额 
                    //----------------------------------------------------------------------------------------------------------------

                    //税率
                    decimal d税率 = decimal.Round(Convert.ToDecimal(dtPodetails.Rows[0]["ipertaxrate"]), 2);
                    //单价(不含税)
                    decimal d原币无税单价 = decimal.Round(Convert.ToDecimal(dtPodetails.Rows[0]["iUnitPrice"]), 6);
                    //金额(不含税)
                    decimal d原币金额 = decimal.Round(d原币无税单价 * decimal.Parse(s本次到货数量), 2);
                    //原币含税单价
                    decimal d含税单价 = decimal.Round(Convert.ToDecimal(dtPodetails.Rows[0]["iTaxPrice"]), 6);
                    //原币价税合计
                    decimal d原币价税合计 = decimal.Round(d含税单价 * decimal.Round(decimal.Parse(s本次到货数量), 6), 2);
                    //原币无税金额 
                    decimal d原币无税金额 = decimal.Round(d原币价税合计 / (1 + d税率 / 100), 2);
                    //原币税额 
                    decimal d原币税额 = d原币价税合计 - d原币无税金额;


                    sSQL = "update @u8.PU_ArrivalVouchs set iOriCost= " + d原币无税单价 + ",iOriTaxCost = " + d含税单价 + ",iOriMoney = " + d原币无税金额 + ",iOriTaxPrice = " + d原币税额 + "," +
                                "iOriSum = " + d原币价税合计 + ",iCost = " + d原币无税单价 + ",iMoney = " + d原币无税金额 + ",iTaxPrice = " + d原币税额 + ",iSum = " + d原币价税合计 + ",iTaxRate = " + d税率 + " " +
                           " where autoid = " + iIDDetailArr;
                    aList.Add(sSQL);

                    if (dtPodetails.Rows[0]["iNum"].ToString().Trim() != string.Empty && Convert.ToDouble(dtPodetails.Rows[0]["iNum"]) != 0)
                    {
                        sSQL = "update @u8.PU_ArrivalVouchs set iinvexchrate=cast((" + s本次到货数量 + "/" + s本次到货件数 + ")  as decimal(18, 6)),inum=" + s本次到货件数 + " " +
                                                  " ,cUnitID = '" + dtGSP.Rows[0]["cAssComUnitCode"].ToString().Trim() + "' " +
                               " where autoid = " + iIDDetailArr;
                        aList.Add(sSQL);
                    }

                    if (dtPodetails.Rows[0]["citemName"].ToString().Trim() != string.Empty)
                    {
                        sSQL = "update @u8.PU_ArrivalVouchs set citem_class='" + dtPodetails.Rows[0]["citem_class"] + "',citemcode='" + dtPodetails.Rows[0]["citemName"] + "',cItemName='" + dtPodetails.Rows[0]["citemName"] + "' " +
                               " where autoid = " + iIDDetailArr;
                        aList.Add(sSQL);
                    }

                    if (s本次到货件数.Trim() == string.Empty || s本次到货件数.Trim() == "null")
                    {
                        sSQL = "update @u8.PO_Podetails  set iArrMoney = isnull(iArrMoney,0) + " + d原币金额 + ",iNatArrMoney =isnull(iNatArrMoney,0) + " + d原币金额 + " ,iArrQTY = isnull(iArrQTY,0) + " + s本次到货数量 + ",fPoValidQuantity = isnull(fPoValidQuantity,0) + " + s本次到货数量 + ",fPoArrQuantity= isnull(fPoArrQuantity,0) + " + s本次到货数量 + "  where [id] = " + dr[i]["订单子表ID"].ToString().Trim();

                    }
                    else
                    {
                        sSQL = "update @u8.PO_Podetails  set iArrMoney = isnull(iArrMoney,0) + " + d原币金额 + ",iNatArrMoney = isnull(iNatArrMoney,0) + " + d原币金额 + " ,iArrQTY = isnull(iArrQTY,0) + " + s本次到货数量 + ",iArrNum = isnull(iArrNum,0) + " + s本次到货件数 + ",fPoValidQuantity =isnull(fPoValidQuantity,0) + " + s本次到货数量 + ",fPoArrQuantity=isnull(fPoArrQuantity,0) + " + s本次到货数量 + ",fPoValidNum =isnull(fPoValidNum,0) + " + s本次到货件数 + ",fPoArrNum=isnull(fPoArrNum,0) + " + s本次到货件数 + "  where [id] = " + dr[i]["订单子表ID"].ToString().Trim();
                    }
                    aList.Add(sSQL);

                    dr[i]["bUsed"] = iIDArr;
                }
                else
                {
                    continue;
                }

                for (int j = i + 1; j < dr.Length; j++)
                {
                    if (dr[j]["bUsed"].ToString().Trim() == "-1" && dr[i]["默认仓库编码"].ToString().Trim() == dr[j]["默认仓库编码"].ToString().Trim())
                    {
                        iIDDetailArr += 1;

                        //表体 

                        string s本次到货件数 = "null";
                        if (dr[j]["本次到货件数"].ToString().Trim() != string.Empty)
                            s本次到货件数 = dr[j]["本次到货件数"].ToString().Trim();
                        if (s本次到货件数 == "null" || double.Parse(s本次到货件数) == 0)
                            s本次到货件数 = "null";

                        string s本次到货数量 = "null";
                        if (dr[j]["本次到货数量"].ToString().Trim() != string.Empty)
                            s本次到货数量 = dr[j]["本次到货数量"].ToString().Trim();

                        sSQL = "select * from @u8.PO_Podetails where id = " + dr[j]["订单子表ID"];
                        DataTable dtPodetails = clsSQLCommond.ExecQuery(sSQL);

                        sSQL = " Insert Into @u8.PU_ArrivalVouchs(autoid,id,cwhcode,cinvcode,inum,iquantity," +
                           "ioricost,ioritaxcost,iorimoney,ioritaxprice,iorisum,icost,imoney,itaxprice,isum,itaxrate," +
                           "citem_class,citemcode,iposid,citemname,frealquantity,fvalidquantity,bgsp,btaxcost,sodid," +
                           "sotype,iinvexchrate,csocode,cordercode,rejectsource,iexpiratdatecalcu,cDefine28) Values  " +
                       "(" + iIDDetailArr + "," + iIDArr + ",N'" + dr[j]["默认仓库编码"] + "',N'" + dr[j]["物料编码"] + "'," + s本次到货件数 + "," + s本次到货数量 + "," +
                           "null,null,null,null,null,null,null,null,null,13," +
                           "null,null," + dr[j]["订单子表ID"] + ",null,null,null,0,1,N'" + dr[j]["订单子表ID"] + "'," +
                           "0,0,null,N'" + dr[j]["订单号"] + "',0,0,'" + dr[j]["货位编码"] + "')";
                        aList.Add(sSQL);


                        //生成来料报检单时回写到货单数据
                        sSQL = "UPDATE @u8.Pu_ArrivalVouchs SET bInspect =1,fInspectQuantity = ISNULL(fInspectQuantity,0)+" + s本次到货数量 + ",fInspectNum = ISNULL(fInspectNum,0)+" + s本次到货件数 + " WHERE AutoID=" + iIDDetailArr;
                        aList.Add(sSQL);

                        string s辅计量单位编码 = "null";
                        string s换算率 = "null";
                        if (dr[j]["辅计量单位编码"].ToString().Trim() != "")
                        {
                            s辅计量单位编码 = "'" + dr[j]["辅计量单位编码"].ToString().Trim() + "'";
                            s换算率 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(s本次到货数量) / MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(s本次到货件数)).ToString();
                        }

                        //来料报检单表体
                        iIDDetail报检 += 1;
                        sSQL = "INSERT INTO @u8.QMInspectVouchers(ID,AUTOID,CITEMCLASS,CITEMCODE,CITEMCNAME,CITEMNAME,REJECTAUTOID,SOURCEAUTOID,ITESTSTYLE,CWHCODE" +
                                    ",CINVCODE,CBATCH,DPRODATE,DVDATE,CUNITID,FCHANGRATE,FQUANTITY,FNUM,BFLAG,CFREE1" +
                                    ",CFREE2,CFREE3,CFREE4,CFREE5,CFREE6,CFREE7,CFREE8,CFREE9,CFREE10,CBATCHPROPERTY1" +
                                    ",CBATCHPROPERTY2,CBATCHPROPERTY3,CBATCHPROPERTY4,CBATCHPROPERTY5,CBATCHPROPERTY6,CBATCHPROPERTY7,CBATCHPROPERTY8,CBATCHPROPERTY9,CBATCHPROPERTY10,CDEFINE22" +
                                    ",CDEFINE23,CDEFINE24,CDEFINE25,CDEFINE26,CDEFINE27,CDEFINE28,CDEFINE29,CDEFINE30,CDEFINE31,CDEFINE32" +
                                    ",CDEFINE33,CDEFINE34,CDEFINE35,CDEFINE36,CDEFINE37,IMASSDATE,CMASSUNIT,CPROBATCH,CBYPRODUCT,CPOSITION" +
                                    ",PCSTRANSTYPE, IORDERTYPE,CSOORDERCODE,ISOORDERAUTOID,CPROORDERCODE,IPROORDERID,IPROORDERAUTOID,CCONTRACTCODE,CCONTRACTSTRCODE,CPOCODE" +
                                    ",BEXIGENCY,CSOURCEPROORDERCODE,ISOURCEPROORDERROWNO,ISOURCEPROORDERID,ISOURCEPROORDERAUTOID,IEXPIRATDATECALCU,CEXPIRATIONDATE,DEXPIRATIONDATE,IORDERDID,ISOORDERTYPE" +
                                    ",CORDERCODE,IORDERSEQ,CVMIVENCODE ) " +
                                "VALUES(" + iID报检 + ",  " + iIDDetail报检 + " ,N'" + dr[j]["项目大类编码"] + "',N'" + dr[j]["项目编码"] + "',N'外销订单项目',N'" + dr[j]["项目名称"] + "',NULL," + iIDDetailArr + ",N'0',N'" + dr[j]["默认仓库编码"] + "'" +
                                    ",N'" + dr[j]["物料编码"] + "',NULL,NULL,NULL," + s辅计量单位编码 + "," + s换算率 + "," + s本次到货数量 + "," + s本次到货件数 + ",NULL,NULL" +
                                    ",NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL" +
                                    ",NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL" +
                                    ",NULL,NULL,NULL,NULL,NULL,'" + dr[j]["货位编码"] + "',NULL,NULL,NULL,NULL" +
                                    ",NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL" +
                                    ",NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,N'" + dr[j]["订单号"].ToString().Trim() + "'" +
                                    ",0,NULL,NULL,NULL,NULL,N'0',NULL,NULL,NULL,NULL" +
                                    ",NULL,NULL,NULL) ";
                        aList.Add(sSQL);

                        sSQL = "select isnull(bPropertyCheck,0) as bPropertyCheck,cAssComUnitCode from @u8.Inventory  where cInvCode = '" + dr[j]["物料编码"].ToString().Trim() + "' ";
                        DataTable dtGSP = clsSQLCommond.ExecQuery(sSQL);
                        if (dtGSP.Rows[0]["bPropertyCheck"].ToString().Trim() == "1" || Convert.ToBoolean(dtGSP.Rows[0]["bPropertyCheck"]))
                        {
                            sSQL = "update  @u8.PU_ArrivalVouchs set  bGsp = 1 where autoid = " + iIDDetailArr;
                            aList.Add(sSQL);
                        }

                        //原币含税单价  5位
                        //无税单价      6位
                        //数量          6位
                        //价税合计      2位   原币含税单价 * 数量
                        //无税金额      2位   价税合计 / （1 + 税率） 
                        //税额          2位   价税合计 - 无税金额 
                        //---------------------------------------------------------

                        //税率
                        decimal d税率 = decimal.Round(Convert.ToDecimal(dtPodetails.Rows[0]["ipertaxrate"]), 2);
                        //单价(不含税)
                        decimal d原币无税单价 = decimal.Round(Convert.ToDecimal(dtPodetails.Rows[0]["iUnitPrice"]), 6);
                        //金额(不含税)
                        decimal d原币金额 = decimal.Round(d原币无税单价 * decimal.Parse(s本次到货数量), 2);
                        //原币含税单价
                        decimal d含税单价 = decimal.Round(Convert.ToDecimal(dtPodetails.Rows[0]["iTaxPrice"]), 6);
                        //原币价税合计
                        decimal d原币价税合计 = decimal.Round(d含税单价 * decimal.Round(decimal.Parse(s本次到货数量), 6), 2);
                        //原币无税金额 
                        decimal d原币无税金额 = decimal.Round(d原币价税合计 / (1 + d税率 / 100), 2);
                        //原币税额 
                        decimal d原币税额 = d原币价税合计 - d原币无税金额;

                        sSQL = "update @u8.PU_ArrivalVouchs set iOriCost= " + d原币无税单价 + ",iOriTaxCost = " + d含税单价 + ",iOriMoney = " + d原币无税金额 + ",iOriTaxPrice = " + d原币税额 + "," +
                               "iOriSum = " + d原币价税合计 + ",iCost = " + d原币无税单价 + ",iMoney = " + d原币无税金额 + ",iTaxPrice = " + d原币税额 + ",iSum = " + d原币价税合计 + ",iTaxRate = " + d税率 + " " +
                          " where autoid = " + iIDDetailArr;
                        aList.Add(sSQL);

                        if (dtPodetails.Rows[0]["iNum"].ToString().Trim() != string.Empty && Convert.ToDouble(dtPodetails.Rows[0]["iNum"]) != 0)
                        {
                            sSQL = "update @u8.PU_ArrivalVouchs set iinvexchrate=cast((" + s本次到货数量 + "/" + s本次到货件数 + ")  as decimal(18, 6)),inum=" + s本次到货件数 + " " +
                                                           " ,cUnitID = '" + dtGSP.Rows[0]["cAssComUnitCode"].ToString().Trim() + "' " +
                                   " where autoid = " + iIDDetailArr;
                            aList.Add(sSQL);
                        }

                        if (dtPodetails.Rows[0]["citemName"].ToString().Trim() != string.Empty)
                        {
                            sSQL = "update @u8.PU_ArrivalVouchs set citem_class='" + dtPodetails.Rows[0]["citem_class"] + "',citemcode='" + dtPodetails.Rows[0]["citemName"] + "',cItemName='" + dtPodetails.Rows[0]["citemName"] + "' " +
                                   " where autoid = " + iIDDetailArr;
                            aList.Add(sSQL);
                        }

                        if (s本次到货件数.Trim() == string.Empty || s本次到货件数.Trim() == "null")
                        {
                            sSQL = "update @u8.PO_Podetails  set iArrMoney = isnull(iArrMoney,0) + " + d原币金额 + ",iNatArrMoney =isnull(iNatArrMoney,0) + " + d原币金额 + " ,iArrQTY = isnull(iArrQTY,0) + " + s本次到货数量 + ",fPoValidQuantity = isnull(fPoValidQuantity,0) + " + s本次到货数量 + ",fPoArrQuantity= isnull(fPoArrQuantity,0) + " + s本次到货数量 + "  where [id] = " + dr[j]["订单子表ID"].ToString().Trim();

                        }
                        else
                        {
                            sSQL = "update @u8.PO_Podetails  set iArrMoney = isnull(iArrMoney,0) + " + d原币金额 + ",iNatArrMoney = isnull(iNatArrMoney,0) + " + d原币金额 + " ,iArrQTY = isnull(iArrQTY,0) + " + s本次到货数量 + ",iArrNum = isnull(iArrNum,0) + " + s本次到货件数 + ",fPoValidQuantity =isnull(fPoValidQuantity,0) + " + s本次到货数量 + ",fPoArrQuantity=isnull(fPoArrQuantity,0) + " + s本次到货数量 + ",fPoValidNum =isnull(fPoValidNum,0) + " + s本次到货件数 + ",fPoArrNum=isnull(fPoArrNum,0) + " + s本次到货件数 + "  where [id] = " + dr[j]["订单子表ID"].ToString().Trim();
                        }
                        aList.Add(sSQL);

                        dr[j]["bUsed"] = iIDArr;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }


        private void GetID报检()
        {
            string sSQL = "select max(ID) as iID,max(AutoID) as iIDDetail from @u8.QMInspectVouchers";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt == null || dt.Rows.Count < 1)
            {
                iID报检 = 0;
                iIDDetail报检 = 0;
            }
            else
            {
                iID报检 = Convert.ToInt64(dt.Rows[0]["iID"]);
                iIDDetail报检 = Convert.ToInt64(dt.Rows[0]["iIDDetail"]);
            }
        }

        /// <summary>
        /// 返回到货单单据号
        /// </summary>
        /// <param name="s"></param>
        /// <param name="sDepCode"></param>
        /// <returns></returns>
        private string sSetCode(long s, string sDepCode, DateTime date1)
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

            string sDCode = "";
            string sSQL = "Select cCode from @u8.Vouchercontrapose Where cContent='Department' and cSeed='" + sDepCode + "'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt != null && dt.Rows.Count > 0)
            {
                sDCode = dt.Rows[0]["cCode"].ToString().Trim();
                sDCode = sDCode.Substring(0, 1);
            }

            return sDCode + DateTime.Parse(date1.ToString("yyyy-MM-dd")).ToString("yyMM") + sCode;
        }

        private string sGet报检单号(long s, DateTime date1)
        {
            string sCode = s.ToString().Trim();
            for (int i = 0; i < 5; i++)
            {
                if (sCode.Length < 5)
                {
                    sCode = "0" + sCode;
                }
                else
                {
                    break;
                }
            }

            return "BJ" + DateTime.Parse(date1.ToString("yyyy-MM-dd")).ToString("yyMM") + sCode;

        }
    }
}
