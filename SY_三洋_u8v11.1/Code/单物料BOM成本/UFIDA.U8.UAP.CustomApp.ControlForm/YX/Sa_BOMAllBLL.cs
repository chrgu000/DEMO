using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using UFIDA.U8.UAP.CustomApp.MetaData;

using System.ComponentModel;
using System.Collections;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Business
{
    public class Sa_BOMAllBLL
    {
        private uint _Stat;
        /// <summary>
        /// 母件结构单阶
        /// </summary>
        private static DataTable dt;

        public static DataTable dts;
        /// <summary>
        /// 采购管理模块中的供应商存货价格表
        /// </summary>
        private static DataTable dt2;
        /// <summary>
        /// 采购发票
        /// </summary>
        private static DataTable dt3;

        /// <summary>
        /// 采购发票汇总
        /// </summary>
        private static DataTable dt9;

        /// <summary>
        /// 存货档案参考成本
        /// </summary>
        private static DataTable dt4;

        public static double count;

        public static double hasprice;

        //public string levid;

        public static string exlname;

        public static int type;
        
        /// <summary>
        /// 母件结构单阶
        /// </summary>
        private static string _dataSourceStr = @"SELECT convert(float,c.SortSeq) as 序号,vp.InvCode AS 母件编码,vp.InvName AS 母件名称,vpi.cEnglishName as 母件英文名称,
            vp.InvStd AS 母件规格型号,vp.ComUnitName AS 母件计量单位,
CONVERT(nvarchar(40), CASE vp.InvAttr WHEN 1 THEN '采购件' WHEN 2 THEN '委外件' WHEN 3 THEN '自制件' WHEN 4 THEN '选项类' WHEN 5 THEN 'PTO' WHEN 6 THEN '' WHEN 7 THEN '计划品' ELSE '' END) AS 母件物料属性,
            vc.InvCode AS 子件编码,vc.InvName AS 子件名称,vci.cEnglishName as 子件英文名称,
            vc.InvStd AS 子件规格型号,vc.ComUnitName AS 子件计量单位,
            o.WhCode AS 仓库编码,w.cWhName AS 仓库名称,convert(nvarchar(40),case b.Status when 4 then '停用' when 3 then '审核'  end ) as 状态 ,
            c.BaseQtyN AS '基本用量',c.BaseQtyD AS '基础数量',
            (case when c.AuxUnitCode is null or vc.BOMExpandUnitType = 1 then c.BaseQtyN else c.AuxBaseQtyN * c.Changerate end)/c.BaseQtyD * ( 1 + c.CompScrap/100) / case when c.FVFlag = 1 then (1 - p.ParentScrap/100) else 1 end   as 单层使用数量,
            (case when c.AuxUnitCode is null or vc.BOMExpandUnitType = 1 then c.BaseQtyN else c.AuxBaseQtyN * c.Changerate end)/c.BaseQtyD * ( 1 + c.CompScrap/100) / case when c.FVFlag = 1 then (1 - p.ParentScrap/100) else 1 end as 使用数量 ,
            CONVERT(nvarchar(40), CASE vc.InvAttr WHEN 1 THEN '采购件' WHEN 2 THEN '委外件' WHEN 3 THEN '自制件' WHEN 4 THEN '选项类' WHEN 5 THEN 'PTO' WHEN 6 THEN '' WHEN 7 THEN '计划品' ELSE '' END) AS 子件物料属性  ,
 ( CASE o.WIPType WHEN 2 THEN '工序倒冲' WHEN 1 THEN '入库倒冲' WHEN 3 THEN '领用' WHEN 4 THEN '虚拟件' ELSE '直接供应' END) AS 供应类型 
            FROM bom_bom b with (nolock) 
            INNER JOIN bom_parent p with (nolock) ON b.BomId = p.BomId 
            INNER JOIN bas_part bp with (nolock) ON bp.PartId = p.ParentId 
            INNER JOIN v_bas_inventory vp with (nolock) ON bp.InvCode = vp.InvCode 
            INNER JOIN bom_opcomponent c with (nolock) ON b.BomId = c.BomId 
            INNER JOIN bas_part bc with (nolock) ON bc.PartId = c.ComponentId 
            INNER JOIN v_bas_inventory vc with (nolock) ON vc.InvCode = bc.InvCode 
            LEFT OUTER JOIN bom_opcomponentopt o with (nolock) ON o.OptionsId = c.OptionsId 
            LEFT OUTER JOIN WareHouse w ON w.cWhCode = o.WhCode 
            LEFT OUTER JOIN Department d ON d.cDepCode = o.DrawDeptCode   
            LEFT OUTER JOIN ecn_ecnapplydetail as ed with (nolock) on ed.ApplyDId = b.ApplyDId 
            LEFT OUTER JOIN ecn_ecnapply as eh with (nolock) on ed.ApplyId = eh.ApplyId  
            LEFT OUTER JOIN ComputationUnit fu with (nolock) on fu.cComunitCode = c.AuxUnitCode  
            LEFT OUTER JOIN v_prouting_all s  with (nolock) on s.partid = p.parentid and s.RountingType = b.bomtype and (b.bomtype = 1 and b.VersionEffDate >= s.VersionEffDate and b.VersionEffDate < s.VersionEndDate or b.bomtype = 2 and b.IdentCode = s.IdentCode)  
            LEFT OUTER JOIN sfc_proutingdetail s1  with (nolock) on s.PRoutingId = s1.PRoutingId and s1.opseq = c.opseq  
            LEFT OUTER JOIN inventory as vpi on vp.InvCode=vpi.cInvCode 
            LEFT OUTER JOIN inventory as vci on vc.InvCode=vci.cInvCode 
            WHERE 1=1 AND  ( b.BomType = 1)  AND c.EffBegDate <= coalesce(b.VersionEffDate,c.EffEndDate) AND c.EffEndDate > coalesce(b.VersionEffDate,c.EffBegDate) and b.VersionEndDate > getdate()
            Order By vp.InvCode,convert(float,c.SortSeq)   ";

        //
        /// <summary>
        /// 采购管理模块中的供应商存货价格表
        /// </summary>
        private static string _dataSourceStr2 = @" Select denabledate as 日期,cvencode as 供应商编号,cvenabbname as 供应商简称,cvenname as 供应商名称,cinvcode as 存货编码,cinvname 存货名称,
            cexch_name as 币别,iunitprice as 原币单价,case when cexch_name='人民币' then 1 else (
            select top 1  case when bcal=1  then nflat else 1/nflat end as 汇率 from exch a 
            left join (select cexch_name,bcal from foreigncurrency ) b 
            on a.cexch_name=b.cexch_name  where itype=2 and a.cexch_name=pu_veninvpricelst.cexch_name order by convert(int,cdate) desc
            ) end * iunitprice as  单价 From pu_veninvpricelst  ";

        /// <summary>
        /// 发票
        /// </summary>
        private static string _dataSourceStr3 = "";
        private static string Get_dataSourceStr3()
        {
            return @"Select id as 从表序号,cPTName as 采购类型,cbustype as 类型,cpbvcode as 发票号,dPBVDate as 发票日期,cvencode as 供应商编号,cvenabbname as 供应商简称,cvenname as 供应商名称,cinvcode as 存货编码,cinvname 存货名称,ipbvquantity as 数量,icost as 无税单价 
            From zpurBillHead with(nolock) inner join zpurbilltail with(nolock) on zpurBillHead.pbvid=zpurbilltail.pbvid  Where 1=1 and cPTName<>'调整'  
            union all SELECT  从表序号, 采购类型, 类型, 发票号, 发票日期, 供应商编号, 供应商简称, 供应商名称, 存货编码, 存货名称, 数量, 无税单价 FROM         历史发票明细表 where 2=2 ";//And  cbustype <> N'委外加工' and cSource =  '采购'  And  cbustype <> N'委外加工' and cSource =  '采购'
        }

        /// <summary>
        /// 发票
        /// </summary>
        private static string _dataSourceStr9 = "";
        private static string Get_dataSourceStr9()
        {
            return @"select 供应商编号,存货编码,sum(数量) as 数量 from ( 
Select cvencode as 供应商编号,cinvcode as 存货编码,ipbvquantity as 数量 
            From zpurBillHead with(nolock) inner join zpurbilltail with(nolock) on zpurBillHead.pbvid=zpurbilltail.pbvid  Where 1=1 and cPTName<>'调整'  
            union all SELECT  供应商编号,存货编码, 数量 FROM         
历史发票明细表 where 2=2 ) a group by 供应商编号,存货编码";//And  cbustype <> N'委外加工' and cSource =  '采购'  And  cbustype <> N'委外加工' and cSource =  '采购'
        }

        /// <summary>
        /// 存货档案参考成本
        /// </summary>
        private static string _dataSourceStr4 = @"SELECT     a.cInvCode AS 存货编码, a.cInvName AS 存货名称, a.cInvAddCode AS 物料代码, a.cInvStd AS 存货规格,cEnglishName as 存货英文名称, b.cComUnitName AS 主计量, iInvSPrice as 参考成本 
                        FROM         dbo.Inventory AS a LEFT OUTER JOIN 
                      dbo.ComputationUnit AS b ON a.cComUnitCode = b.cComunitCode LEFT OUTER JOIN 
                      dbo.InventoryClass AS c ON a.cInvCCode = c.cInvCCode LEFT OUTER JOIN 
                      dbo.ComputationUnit AS e ON e.cComunitCode = a.cAssComUnitCode  where 1=1 ";

        /// <summary>
        /// 外币
        /// </summary>
        private static string _dataSourceStr5 = @"select a.cexch_name,convert(int,cdate) as cdate,nflat,折算方式 from exch a 
            left join (select cexch_name,case when bcal=0 then '外币乘以汇率' else '外币除以汇率' end 折算方式 from foreigncurrency ) b 
            on a.cexch_name=b.cexch_name  where itype=2";

        #region
        public static Projects GetFormsData(string conn, string cinvcode, string price, string price2,DateTime d1,DateTime d2)
        {
            hasprice = 0;
            NewTB();
            try
            {
                dt2 = SqlHelper.ExecuteDataset(conn, CommandType.Text, _dataSourceStr2).Tables[0];
            }
            catch
            {
                throw new Exception("供应商存货价格表取值失败");
            }
            try
            {
                _dataSourceStr3 = Get_dataSourceStr3();
                _dataSourceStr3 = _dataSourceStr3.Replace("1=1", " dPBVDate between '" + d1.ToString("yyyy-MM-dd") + "' and '" + d2.ToString("yyyy-MM-dd") + "'");
                _dataSourceStr3 = _dataSourceStr3.Replace("2=2", " 发票日期 between '" + d1.ToString("yyyy-MM-dd") + "' and '" + d2.ToString("yyyy-MM-dd") + "'");

                dt3 = SqlHelper.ExecuteDataset(conn, CommandType.Text, _dataSourceStr3).Tables[0];

                _dataSourceStr9 = Get_dataSourceStr9();
                _dataSourceStr9 = _dataSourceStr9.Replace("1=1", " dPBVDate between '" + d1.ToString("yyyy-MM-dd") + "' and '" + d2.ToString("yyyy-MM-dd") + "'");
                _dataSourceStr9 = _dataSourceStr9.Replace("2=2", " 发票日期 between '" + d1.ToString("yyyy-MM-dd") + "' and '" + d2.ToString("yyyy-MM-dd") + "'");

                dt9 = SqlHelper.ExecuteDataset(conn, CommandType.Text, _dataSourceStr9).Tables[0];
            }
            catch
            {
                throw new Exception("采购发票取值失败");
            }
            dt4 = SqlHelper.ExecuteDataset(conn, CommandType.Text, _dataSourceStr4).Tables[0];

            
            string[] cinvcodes = cinvcode.Split(',');

            type = 1;
            for (int i = 0; i < cinvcodes.Length; i++)
            {
                DataTable dttop = SqlHelper.ExecuteDataset(conn, CommandType.Text, _dataSourceStr4.Replace(" 1=1 ", " a.cInvCode='" + cinvcodes[i].Trim() + "' ")).Tables[0];
                
                if (dttop.Rows.Count > 0)
                {
                    string cen = i.ToString() + "_";
                    try
                    {
                        string 单价来源 = "";
                        string 发票号 = "";
                        string 发票日期 = "";
                        double jbyl = 0;
                        double dj = 0;
                        string vendor = "";
                        string vendorname = "";
                        double jg = 0;
                        DataTable dtinv = SqlHelper.ExecuteDataset(conn, CommandType.Text, _dataSourceStr.Replace(" 1=1 AND ", " vp.InvCode='" + dttop.Rows[0]["存货编码"].ToString() + "' AND ")).Tables[0];
                        if (dtinv.Rows.Count > 0 && dtinv.Rows[0]["母件物料属性"].ToString() == "委外件")
                        {
                            string[] djs = CCCB(price, price2, dttop.Rows[0]["存货编码"].ToString(), dtinv.Rows[0]["母件物料属性"].ToString());
                            if (djs[0] != "")
                            {
                                dj = double.Parse(djs[0]);
                                jg = dj;
                            }
                            vendor = djs[1];
                            vendorname = djs[2];
                            if (dj == 0)
                            {
                                hasprice = hasprice + 1;
                            }
                            单价来源 = djs[3];
                            发票号 = djs[4];
                            发票日期 = djs[5];
                        }
                        else if (dtinv.Rows.Count == 0)
                        {
                            string[] djs = CCCB(price, price2, dttop.Rows[0]["存货编码"].ToString(), "采购件");
                            if (djs[0] != "")
                            {
                                dj = double.Parse(djs[0]);
                                jg = dj;
                            }
                            vendor = djs[1];
                            vendorname = djs[2];
                            if (dj == 0)
                            {
                                hasprice = hasprice + 1;
                            }
                            单价来源 = djs[3];
                            发票号 = djs[4];
                            发票日期 = djs[5];
                        }
                        InsertTB("", dttop.Rows[0]["存货编码"].ToString(), dttop.Rows[0]["存货名称"].ToString(), dttop.Rows[0]["存货英文名称"].ToString(), dttop.Rows[0]["存货规格"].ToString(), dttop.Rows[0]["主计量"].ToString(),
                            "", "", "", "", "", "",
                            0, 0, 0, 0, cen, "", dj, jg,
                             vendor, vendorname, "", "", "",
                           单价来源, 发票号, 发票日期);

                        Get(conn, dttop.Rows[0]["存货编码"].ToString(), 1, cen, price, price2, 1);
                    }
                    catch(Exception ee)
                    {
                        throw new Exception("获取子件失败" + dttop.Rows[0]["存货编码"].ToString()+ee.Message);
                    }
                    
                }
            }

                GetJG();

            exlname = "";
            DataRow[] dwnew = dts.Select("子件编码=''");
            for (int i = 0; i < dwnew.Length; i++)
            {
                if (exlname != "")
                {
                    exlname = exlname + "+";
                }
                string izj = dwnew[i]["总价"].ToString();
                if (izj == "")
                {
                    izj = "0";
                }
                exlname = exlname + dwnew[i]["母件编码"].ToString() + "+" + dwnew[i]["母件名称"].ToString() + "+" + Math.Round(double.Parse(izj));
            }
            if (exlname.Length > 250)
            {
                exlname = exlname.Substring(0, 250);
            }
            Projects projects = new Projects();
            GetPro(projects);

            double sum=double.Parse(dts.Compute("sum(总价)", "子件编码=''").ToString());
            projects.Add(new Project(Math.Round(sum,2).ToString(), "总价", Priority.Normal, true));

            return projects;
        }

        private static void GetJG()
        {
            for (int i = 0; i < dts.Rows.Count; i++)
            {
                dts.Rows[i]["总价"] = double.Parse(dts.Compute("sum(价格)", "层 like '" + dts.Rows[i]["层"].ToString() + "%'").ToString());
                if (dts.Rows[i]["总价"].ToString() == "")
                {
                    dts.Rows[i]["总价"] = 0;
                }
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="cinvcode">母件编码</param>
        /// <param name="yl">使用数量</param>
        /// <param name="stype"></param>
        /// <param name="levid">层</param>
        /// <param name="price"></param>
        /// <param name="price2"></param>
        private static void Get(string conn, string cinvcode, double yl, string levid, string price, string price2, int stype)//Project project, 
        {
            stype = stype + 1;
            if (stype > type)
            {
                type = stype;
            }
            DataTable dtnew = SqlHelper.ExecuteDataset(conn, CommandType.Text, _dataSourceStr.Replace(" 1=1 AND ", " vp.InvCode='" + cinvcode + "' AND ")).Tables[0];
            if (dtnew.Rows.Count > 0)
            {
                for (int i = 0; i < dtnew.Rows.Count; i++)
                {
                    double jbyl = 0;
                    double jcsl = 0;
                    double dcyl = 0;
                    double sysl = 0;
                    double dj = 0;
                    double jg = 0;
                    string sx = dtnew.Rows[i]["子件物料属性"].ToString();
                    string vendor = "";
                    string vendorname = "";
                    if (dtnew.Rows[i]["基本用量"].ToString() != "")
                    {
                        jbyl = double.Parse(dtnew.Rows[i]["基本用量"].ToString());
                    }
                    if (dtnew.Rows[i]["基础数量"].ToString() != "")
                    {
                        jcsl = double.Parse(dtnew.Rows[i]["基础数量"].ToString());
                    }
                    if (dtnew.Rows[i]["单层使用数量"].ToString() != "")
                    {
                        dcyl = double.Parse(dtnew.Rows[i]["单层使用数量"].ToString());
                    }
                    sysl = yl * dcyl;

                    string 单价来源 = "";
                    string 发票号 = "";
                    string 发票日期 = "";

                    //DataTable dtzj = SqlHelper.ExecuteDataset(conn, CommandType.Text, _dataSourceStr.Replace(" 1=1 AND ", " vp.InvCode='" + dtnew.Rows[i]["子件编码"].ToString() + "' AND ")).Tables[0];
                    if (sx == "采购件" || sx == "委外件")
                    {
                        string[] djs = CCCB(price, price2, dtnew.Rows[i]["子件编码"].ToString(), sx);
                        if (djs[0] != "")
                        {
                            dj = double.Parse(djs[0]);
                        }
                        vendor = djs[1];
                        vendorname = djs[2];
                        if (dj == 0)
                        {
                            hasprice = hasprice + 1;
                        }
                        单价来源 = djs[3];
                        发票号 = djs[4];
                        发票日期 = djs[5];
                    }
                    jg = sysl * dj;

                    string cen = levid + i.ToString() + "_";
                    InsertTB(dtnew.Rows[i]["序号"].ToString(), cinvcode, dtnew.Rows[i]["母件名称"].ToString(), dtnew.Rows[i]["母件英文名称"].ToString(), dtnew.Rows[i]["母件规格型号"].ToString(), dtnew.Rows[i]["母件计量单位"].ToString(),
                    dtnew.Rows[i]["子件编码"].ToString(), dtnew.Rows[i]["子件名称"].ToString(), dtnew.Rows[i]["子件英文名称"].ToString(), dtnew.Rows[i]["子件规格型号"].ToString(), dtnew.Rows[i]["子件计量单位"].ToString(),dtnew.Rows[i]["状态"].ToString(),
                    jbyl,jcsl,dcyl,sysl,cen,sx,dj,jg,
                    vendor, vendorname, dtnew.Rows[i]["仓库编码"].ToString(), dtnew.Rows[i]["仓库名称"].ToString(), dtnew.Rows[i]["供应类型"].ToString(),
                    单价来源, 发票号, 发票日期);

                    Get(conn, dtnew.Rows[i]["子件编码"].ToString(), sysl, cen, price, price2, stype);
                }
            }
        }

        private static void GetPro(Projects projects)
        {
            DataTable dtthis = DataRowToDataTable(dts.Select("子件编码=''"));
            for (int i = 0; i < dtthis.Rows.Count; i++)
            {
                Project projnew = new Project("", dtthis.Rows[i]["母件编码"].ToString(), dtthis.Rows[i]["母件名称"].ToString(), dtthis.Rows[i]["母件英文名称"].ToString(),
                    dtthis.Rows[i]["母件规格型号"].ToString(), dtthis.Rows[i]["母件计量单位"].ToString(), dtthis.Rows[i]["状态"].ToString(),
                    double.Parse(dtthis.Rows[i]["基本用量"].ToString()), double.Parse(dtthis.Rows[i]["基础数量"].ToString()), double.Parse(dtthis.Rows[i]["单层使用数量"].ToString()), double.Parse(dtthis.Rows[i]["使用数量"].ToString()), double.Parse(dtthis.Rows[i]["单价"].ToString()), double.Parse(dtthis.Rows[i]["总价"].ToString()), dtthis.Rows[i]["子件物料属性"].ToString(),
                    "", "", dtthis.Rows[i]["仓库编码"].ToString(), dtthis.Rows[i]["仓库名称"].ToString(), dtthis.Rows[i]["供应类型"].ToString(),
                    dtthis.Rows[i]["单价来源"].ToString(), dtthis.Rows[i]["采购发票号"].ToString(), dtthis.Rows[i]["采购发票日期"].ToString(), Priority.Normal, true);
                projects.Add(projnew);
                GetPro2(projnew, dtthis.Rows[i]["母件编码"].ToString(),dtthis.Rows[i]["层"].ToString());
            }
        }

        private static void GetPro2(Project project,string cinvcode,string cen)
        {
            DataTable dtthis = DataRowToDataTable(dts.Select("母件编码='" + cinvcode + "' and 子件编码<>'' and 层 like '" + cen + "%'","序号"));
            for (int i = 0; i < dtthis.Rows.Count; i++)
            {
                Project projnew = new Project(dtthis.Rows[i]["序号"].ToString(), dtthis.Rows[i]["子件编码"].ToString(), dtthis.Rows[i]["子件名称"].ToString(), dtthis.Rows[i]["子件英文名称"].ToString(),
                    dtthis.Rows[i]["子件规格型号"].ToString(), dtthis.Rows[i]["子件计量单位"].ToString(), dtthis.Rows[i]["状态"].ToString(),
                    double.Parse(dtthis.Rows[i]["基本用量"].ToString()), double.Parse(dtthis.Rows[i]["基础数量"].ToString()), double.Parse(dtthis.Rows[i]["单层使用数量"].ToString()), double.Parse(dtthis.Rows[i]["使用数量"].ToString()), double.Parse(dtthis.Rows[i]["单价"].ToString()), double.Parse(dtthis.Rows[i]["总价"].ToString()), dtthis.Rows[i]["子件物料属性"].ToString(),
                    dtthis.Rows[i]["供应商编码"].ToString(), dtthis.Rows[i]["供应商名称"].ToString(), dtthis.Rows[i]["仓库编码"].ToString(), dtthis.Rows[i]["仓库名称"].ToString(), dtthis.Rows[i]["供应类型"].ToString(),
                     dtthis.Rows[i]["单价来源"].ToString(), dtthis.Rows[i]["采购发票号"].ToString(), dtthis.Rows[i]["采购发票日期"].ToString(), Priority.Normal, true);
                project.Projects.Add(projnew);
                GetPro2(projnew, dtthis.Rows[i]["子件编码"].ToString(), dtthis.Rows[i]["层"].ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static void NewTB()
        {
            dts = new DataTable();
            dts.Columns.Add("序号",typeof(double));
            dts.Columns.Add("母件编码");
            dts.Columns.Add("母件名称");
            dts.Columns.Add("母件英文名称");
            dts.Columns.Add("母件规格型号");
            dts.Columns.Add("母件计量单位");
            dts.Columns.Add("子件编码");
            dts.Columns.Add("子件名称");
            dts.Columns.Add("子件英文名称");
            dts.Columns.Add("子件规格型号");
            dts.Columns.Add("子件计量单位");
            dts.Columns.Add("状态");
            dts.Columns.Add("基本用量", typeof(double));
            dts.Columns.Add("基础数量", typeof(double));
            dts.Columns.Add("单层使用数量", typeof(double));
            dts.Columns.Add("使用数量", typeof(double));
            dts.Columns.Add("层");
            dts.Columns.Add("子件物料属性");
            dts.Columns.Add("单价", typeof(double));
            dts.Columns.Add("价格", typeof(double));
            dts.Columns.Add("总价", typeof(double));
            dts.Columns.Add("供应商编码");
            dts.Columns.Add("供应商名称");
            dts.Columns.Add("仓库编码");
            dts.Columns.Add("仓库名称");
            dts.Columns.Add("供应类型");
            dts.Columns.Add("单价来源");
            dts.Columns.Add("采购发票号");
            dts.Columns.Add("采购发票日期");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="seq">序号</param>
        /// <param name="invcode">母件编码</param>
        /// <param name="invname">母件名称</param>
        /// <param name="invenglishname">母件英文名称</param>
        /// <param name="invstd">母件规格</param>
        /// <param name="invunitname">母件计量单位</param>
        /// <param name="cinvcode">子件编码</param>
        /// <param name="cinvname">子件名称</param>
        /// <param name="cinvenglishname">子件英文名称</param>
        /// <param name="cinvstd">子件规格</param>
        /// <param name="cinvunitname">子件计量单位</param>
        /// <param name="flag">状态</param>
        /// <param name="baseqtyn">基本用量</param>
        /// <param name="baseqtyq">使用数量</param>
        /// <param name="dcusedq">单层使用数</param>
        /// <param name="usedq">使用数量</param>
        /// <param name="cen">层</param>
        /// <param name="sx">子件物料属性</param>
        /// <param name="dj">单价</param>
        /// <param name="zj">价格</param>
        /// <param name="vendor">供应商编号</param>
        /// <param name="vendorname">供应商名称</param>
        /// <param name="stock">仓库编码</param>
        /// <param name="stockname">仓库名称</param>
        /// <param name="stockname">单价来源</param>
        /// <param name="stockname">采购发票号</param>
        private static void InsertTB(string seq, string invcode, string invname, string invenglishname, string invstd, string invunitname,
         string cinvcode,  string cinvname, string cinvenglishname,string cinvstd, string cinvunitname,
         string flag,double baseqtyn, double baseqtyq,double dcusedq, double usedq,string cen, string sx, double dj, double zj,
         string vendor, string vendorname, string stock, string stockname, string gylx, string pricefrom, string cpbvcode,string cpbvdate)
        {
            DataRow dw = dts.NewRow();
            if (seq != "")
            {
                dw["序号"] = seq;
            }
            dw["母件编码"]=invcode;
            dw["母件名称"]=invname;
            dw["母件英文名称"]=invenglishname;
            dw["母件规格型号"]=invstd;
            dw["母件计量单位"]=invunitname;
            dw["子件编码"]=cinvcode;
            dw["子件名称"]=cinvname;
            dw["子件英文名称"]=cinvenglishname;
            dw["子件规格型号"]=cinvstd;
            dw["子件计量单位"]=cinvunitname;
            dw["状态"]=flag;
            dw["基本用量"]=baseqtyn;
            dw["基础数量"]=baseqtyq;
            dw["单层使用数量"]=dcusedq;
            dw["使用数量"]=usedq;
            dw["层"]=cen;
            dw["子件物料属性"]=sx;
            dw["单价"]=dj;
            dw["价格"]=zj;
            dw["供应商编码"]=vendor;
            dw["供应商名称"]=vendorname;
            dw["仓库编码"] = stock;
            dw["仓库名称"] = stockname;
            dw["供应类型"] = gylx;
            dw["单价来源"] = pricefrom;
            dw["采购发票号"] = cpbvcode;
            dw["采购发票日期"] = cpbvdate;
            dts.Rows.Add(dw);
        }

        #region 得到价格
        private static string[] CCCB(string price, string price2, string zjbm,string sx)
        {
            try
            {
                string vendor = "";

                string vendorname = "";
                #region
                if (price == "发票单价")
                {
                    string str = "";
                    if (sx == "采购件")
                    {
                        str = "存货编码='" + zjbm + "' and 类型='普通采购'";
                    }
                    else
                    {
                        str = "存货编码='" + zjbm + "' and 类型='委外加工'";
                    }
                    DataRow[] dwprice = dt3.Select(str, "无税单价 desc,发票日期 desc,从表序号 desc");//有采购发票
                    if (dwprice.Length > 0)
                    {
                        if (price2 == "最高价")
                        {
                            DataRow[] dwnew = dt3.Select("存货编码='" + zjbm + "'", "无税单价 desc,供应商编号 desc");
                            if (dwnew.Length > 0)
                            {
                                return new string[] { dt3.Compute("max(无税单价)", "存货编码='" + zjbm + "'").ToString(), dwnew[0]["供应商编号"].ToString(), dwnew[0]["供应商名称"].ToString(), "发票单价", dwnew[0]["发票号"].ToString(), dwnew[0]["发票日期"].ToString() };
                            }
                            //else
                            //{
                            //    return new string[] { dt2.Compute("max(单价)", "存货编码='" + zjbm + "'").ToString(), dwnew[0]["供应商编号"].ToString(), dwnew[0]["供应商名称"].ToString(), "供应商单价", "", "" };
                            //}
                        }
                        else if(price2 == "平均价")
                        {
                            DataRow[] dwnew = dt3.Select("存货编码='" + zjbm + "'", "无税单价,供应商编号 desc");
                            if (dwnew.Length > 0)
                            {
                                return new string[] { dt3.Compute("avg(无税单价)", "存货编码='" + zjbm + "'").ToString(), dwnew[0]["供应商编号"].ToString(), dwnew[0]["供应商名称"].ToString(), "发票单价", "", "" };
                            }
                            //else
                            //{
                            //    return new string[] { dt2.Compute("avg(单价)", "存货编码='" + zjbm + "'").ToString(), dwnew[0]["供应商编号"].ToString(), dwnew[0]["供应商名称"].ToString(), "供应商单价", "", "" };
                            //}
                        }
                        else if (price2 == "最新价")
                        {
                            if (zjbm == "1BFB000301200F")
                            {
                                string s = "1";
                            }
                            DataRow[] dwnew = dt9.Select("存货编码='" + zjbm + "'", "数量 desc");
                            if (dwnew.Length > 0)
                            {
                                DataRow[] dw2 = dt3.Select("存货编码='" + zjbm + "' and 供应商编号='" + dwnew[0]["供应商编号"].ToString() + "'", "发票日期 desc");
                                if (dw2.Length > 0)
                                {
                                    return new string[] { dw2[0]["无税单价"].ToString(), dw2[0]["供应商编号"].ToString(), dw2[0]["供应商名称"].ToString(), "发票单价", dw2[0]["发票号"].ToString(), dw2[0]["发票日期"].ToString() };
                                }
                            }
                            DataRow[] dw3 = dt2.Select("存货编码='" + zjbm + "'", "日期 desc");
                            if (dw3.Length > 0)
                            {
                                return new string[] { dw3[0]["单价"].ToString(), dw3[0]["供应商编号"].ToString(), dw3[0]["供应商名称"].ToString(), "发票单价", "", "" };
                            }
                        }
                        //return new string[] { dwprice[0]["无税单价"].ToString(), dwprice[0]["供应商编号"].ToString(), dwprice[0]["供应商名称"].ToString(), "发票单价", dwprice[0]["发票号"].ToString(), dwprice[0]["发票日期"].ToString() };
                    }
                    else//没有采购发票
                    {
                        if (price2 == "最高价")
                        {
                            DataRow[] dwnew = dt2.Select("存货编码='" + zjbm + "'", "单价 desc,供应商编号 desc");
                            if (dwnew.Length > 0)
                            {
                                return new string[] { dt2.Compute("max(单价)", "存货编码='" + zjbm + "'").ToString(), dwnew[0]["供应商编号"].ToString(), dwnew[0]["供应商名称"].ToString(), "供应商单价", "", "" };
                            }
                            else
                            {
                                return new string[] { dt2.Compute("max(单价)", "存货编码='" + zjbm + "'").ToString(), "", "", "", "", "" };
                            }
                        }
                        else
                        {
                            DataRow[] dwnew = dt2.Select("存货编码='" + zjbm + "'", "单价,供应商编号 desc");
                            if (dwnew.Length > 0)
                            {
                                return new string[] { dt2.Compute("avg(单价)", "存货编码='" + zjbm + "'").ToString(), dwnew[0]["供应商编号"].ToString(), dwnew[0]["供应商名称"].ToString(), "供应商单价", "", "" };
                            }
                            else
                            {
                                return new string[] { dt2.Compute("avg(单价)", "存货编码='" + zjbm + "'").ToString(), "", "", "", "", "" };
                            }
                        }

                    }
                }
                else if (price == "参考成本")
                {
                    return new string[] { dt4.Compute("max(参考成本)", "存货编码='" + zjbm + "'").ToString(), "", "", "参考成本", "", "" };
                }
                else if (price == "供应商价格")
                {
                    if (price2 == "最高价")
                    {
                        DataRow[] dwnew = dt2.Select("存货编码='" + zjbm + "'", "单价,供应商编号 desc");
                        if (dwnew.Length > 0)
                        {
                            return new string[] { dt2.Compute("max(单价)", "存货编码='" + zjbm + "'").ToString(), dwnew[0]["供应商编号"].ToString(), dwnew[0]["供应商名称"].ToString(), "供应商单价", "", "" };
                        }
                        else
                        {
                            return new string[] { dt2.Compute("max(单价)", "存货编码='" + zjbm + "'").ToString(), "", "", "", "", "" };
                        }
                    }
                    else
                    {
                        DataRow[] dwnew = dt2.Select("存货编码='" + zjbm + "'", "单价,供应商编号 desc");
                        if (dwnew.Length > 0)
                        {
                            return new string[] { dt2.Compute("avg(单价)", "存货编码='" + zjbm + "'").ToString(), dwnew[0]["供应商编号"].ToString(), dwnew[0]["供应商名称"].ToString(), "供应商单价", "", "" };
                        }
                        else
                        {
                            return new string[] { dt2.Compute("avg(单价)", "存货编码='" + zjbm + "'").ToString(), "", "", "", "", "" };
                        }
                    }
                }
                return new string[] { "0", "", "", "", "", "" };
                #endregion
            }
            catch(Exception ee)
            {
                throw new Exception("获取价格" + zjbm+ee.Message);
            }
        }
        #endregion

        #region 将DataRow[] 更改为DataTable
        public static DataTable DataRowToDataTable(DataRow[] dw)
        {
            DataTable dtnew = new DataTable();
            if (dw.Length != 0)
            {
                foreach (DataColumn dc in dw[0].Table.Columns)
                {
                    dtnew.Columns.Add(dc.ColumnName);
                }
                foreach (DataRow dws in dw)
                {
                    dtnew.ImportRow(dws);
                }
            }
            return dtnew;
        }
        #endregion

        #endregion

    }
}