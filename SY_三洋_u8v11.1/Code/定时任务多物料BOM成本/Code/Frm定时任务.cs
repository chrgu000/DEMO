using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Data.SqlClient;

namespace 定时任务
{
    public partial class Frm定时任务 : Form
    {
        private string sPathConfig = Application.StartupPath + @"\App.dll";

        bool isSd = false;
        #region 计算
         private uint _Stat;
        /// <summary>
        /// 母件结构单阶
        /// </summary>
        private  DataTable dt;

        public  DataTable dts;
        /// <summary>
        /// 采购管理模块中的供应商存货价格表
        /// </summary>
        private  DataTable dt2;
        /// <summary>
        /// 采购发票
        /// </summary>
        private  DataTable dt3;

        /// <summary>
        /// 采购发票汇总
        /// </summary>
        private static DataTable dt9;

        /// <summary>
        /// 存货档案参考成本
        /// </summary>
        private  DataTable dt4;

        private static DataTable dt6;
        /// <summary>
        /// 销售发票
        /// </summary>
        private static DataTable dt7;

        /// <summary>
        /// 客户价格
        /// </summary>
        private static DataTable dt8;
        public  double count;

        public  double hasprice;

        //public string levid;

        public  string exlname;

        public  int type;

        /// <summary>
        /// 母件结构单阶
        /// </summary>
        private  string _dataSourceStr = @"SELECT convert(float,c.SortSeq) as 序号,vp.InvCode AS 母件编码,vp.InvName AS 母件名称,vpi.cEnglishName as 母件英文名称,
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
        private string _dataSourceStr2 = @" Select denabledate as 日期,cvencode as 供应商编号,cvenabbname as 供应商简称,cvenname as 供应商名称,cinvcode as 存货编码,cinvname 存货名称,
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
//        /// <summary>
//        /// 发票
//        /// </summary>
//        private static string _dataSourceStr3 = @"Select id as 从表序号,cPTName as 采购类型,cbustype as 类型,cpbvcode as 发票号,dPBVDate as 发票日期,cvencode as 供应商编号,cvenabbname as 供应商简称,cvenname as 供应商名称,cinvcode as 存货编码,cinvname 存货名称,ipbvquantity as 数量,icost as 无税单价 
//            From zpurBillHead with(nolock) inner join zpurbilltail with(nolock) on zpurBillHead.pbvid=zpurbilltail.pbvid  Where 1=1 and cPTName<>'调整'  
//            union all SELECT  从表序号, 采购类型, 类型, 发票号, 发票日期, 供应商编号, 供应商简称, 供应商名称, 存货编码, 存货名称, 数量, 无税单价 FROM         历史发票明细表 where 2=2 ";//And  cbustype <> N'委外加工' and cSource =  '采购'  And  cbustype <> N'委外加工' and cSource =  '采购'
            return @"
Select id as 从表序号,cPTName as 采购类型,cbustype as 类型,cpbvcode as 发票号,dPBVDate as 发票日期,cvencode as 供应商编号,cvenabbname as 供应商简称,cvenname as 供应商名称,cinvcode as 存货编码,cinvname 存货名称,ipbvquantity as 数量,icost as 无税单价 
From zpurBillHead with(nolock) inner join zpurbilltail with(nolock) on zpurBillHead.pbvid=zpurbilltail.pbvid  Where 1=1 and cPTName<>'调整'  

union all 

SELECT  从表序号, 采购类型, 类型, 发票号, 发票日期, 供应商编号, 供应商简称, 供应商名称, 存货编码, 存货名称, 数量, 无税单价 
FROM  历史发票明细表 where 2=2 
";//And  cbustype <> N'委外加工' and cSource =  '采购'  And  cbustype <> N'委外加工' and cSource =  '采购'
        }

        /// <summary>
        /// 发票
        /// </summary>
        private static string _dataSourceStr9 = "";
        private static string Get_dataSourceStr9()
        {
            //        /// <summary>
            //        /// 发票
            //        /// </summary>
            //        private static string _dataSourceStr3 = @"Select id as 从表序号,cPTName as 采购类型,cbustype as 类型,cpbvcode as 发票号,dPBVDate as 发票日期,cvencode as 供应商编号,cvenabbname as 供应商简称,cvenname as 供应商名称,cinvcode as 存货编码,cinvname 存货名称,ipbvquantity as 数量,icost as 无税单价 
            //            From zpurBillHead with(nolock) inner join zpurbilltail with(nolock) on zpurBillHead.pbvid=zpurbilltail.pbvid  Where 1=1 and cPTName<>'调整'  
            //            union all SELECT  从表序号, 采购类型, 类型, 发票号, 发票日期, 供应商编号, 供应商简称, 供应商名称, 存货编码, 存货名称, 数量, 无税单价 FROM         历史发票明细表 where 2=2 ";//And  cbustype <> N'委外加工' and cSource =  '采购'  And  cbustype <> N'委外加工' and cSource =  '采购'
            return @"
select 供应商编号,存货编码,sum(数量) as 数量 
from ( 
Select cvencode as 供应商编号,cinvcode as 存货编码,ipbvquantity as 数量 
From zpurBillHead with(nolock) inner join zpurbilltail with(nolock) on zpurBillHead.pbvid=zpurbilltail.pbvid  Where 1=1 and cPTName<>'调整'  
union all 
SELECT  供应商编号,存货编码, 数量 FROM         
历史发票明细表 where 2=2 
) a group by 供应商编号,存货编码
";
            //And  cbustype <> N'委外加工' and cSource =  '采购'  And  cbustype <> N'委外加工' and cSource =  '采购'
        }

        /// <summary>
        /// 存货档案参考成本
        /// </summary>
        private  string _dataSourceStr4 = @"SELECT     a.cInvCode AS 存货编码, a.cInvName AS 存货名称, a.cInvAddCode AS 物料代码, a.cInvStd AS 存货规格,cEnglishName as 存货英文名称, b.cComUnitName AS 主计量, iInvSPrice as 参考成本 
                        FROM         dbo.Inventory AS a LEFT OUTER JOIN 
                      dbo.ComputationUnit AS b ON a.cComUnitCode = b.cComunitCode LEFT OUTER JOIN 
                      dbo.InventoryClass AS c ON a.cInvCCode = c.cInvCCode LEFT OUTER JOIN 
                      dbo.ComputationUnit AS e ON e.cComunitCode = a.cAssComUnitCode where 1=1 ";//where 1=1 and cinvcode='A53113200'

        /// <summary>
        /// 外币
        /// </summary>
        private  string _dataSourceStr5 = @"
select a.cexch_name,convert(int,cdate) as cdate,nflat,折算方式 
from exch a 
    left join (
        select cexch_name,case when bcal=0 then '外币乘以汇率' else '外币除以汇率' end 折算方式 
        from foreigncurrency
    ) b on a.cexch_name=b.cexch_name  where itype=2";
        
        private string _dataSourceStr6 = @"select a.*,b.cInvCName from inventory a left join InventoryClass b on a.cInvCCode=b.cInvCCode 
        where (isnull(bSale,0) = 1 or isnull(bExpSale,0) = 1) and 1=1 ";


        private static string _dataSourceStr7 = "";

       
        private static string Get_dataSourceStr7()
        {
            return @"select cstname,csbvcode,ddate,cinvcode,cinvname,cinvstd,iquantity,iunitprice ,iNatUnitPrice,ccuscode,cCusAbbName 
        from SaleBillVouchZT inner join SaleBillVouchZW on SaleBillVouchZT.sbvid=SaleBillVouchZW.sbvid where 1=1
 union all select 销售类型,销售发票号,销售日期,存货编码,存货名称,存货规格,数量,含税单价,无税单价,客户编码,客户简称 from 历史销售发票明细表 where 2=2 ";
        }

        private static string _dataSourceStr8 = "select *,b.cCusName,b.cCusAbbName   from SA_CusPriceJustDetail a left join Customer b on a.ccuscode =b.cCusCode ";

        #region
        public bool GetFormsData(string conn,DateTime d1,DateTime d2,DateTime d3,DateTime d4)//,string cinvcode1,string cinvcode2,string stype
        {
            bool b = false;
            progressBar1.Value = 0;
            label2.Text = DateTime.Now.ToString();
            hasprice = 0;
            try
            {
                dt2 = SqlHelper.ExecuteDataset(conn, CommandType.Text, _dataSourceStr2).Tables[0];
                _dataSourceStr3 = Get_dataSourceStr3();
                _dataSourceStr3 = _dataSourceStr3.Replace("1=1", " dPBVDate between '" + d3.ToString("yyyy-MM-dd") + "' and '" + d4.ToString("yyyy-MM-dd") + "'");
                _dataSourceStr3 = _dataSourceStr3.Replace("2=2", " 发票日期 between '" + d3.ToString("yyyy-MM-dd") + "' and '" + d4.ToString("yyyy-MM-dd") + "'");
                dt3 = SqlHelper.ExecuteDataset(conn, CommandType.Text, _dataSourceStr3).Tables[0];

                _dataSourceStr9 = Get_dataSourceStr9();
                _dataSourceStr9 = _dataSourceStr9.Replace("1=1", " dPBVDate between '" + d3.ToString("yyyy-MM-dd") + "' and '" + d4.ToString("yyyy-MM-dd") + "'");
                _dataSourceStr9 = _dataSourceStr9.Replace("2=2", " 发票日期 between '" + d3.ToString("yyyy-MM-dd") + "' and '" + d4.ToString("yyyy-MM-dd") + "'");

                dt9 = SqlHelper.ExecuteDataset(conn, CommandType.Text, _dataSourceStr9).Tables[0];

                if (dt3.Rows.Count == 0 && isSd == true)
                {
                    throw new Exception("没有此日期段采购发票的历史数据");
                }
                dt6 = SqlHelper.ExecuteDataset(conn, CommandType.Text, _dataSourceStr6).Tables[0];
                dt8 = SqlHelper.ExecuteDataset(conn, CommandType.Text, _dataSourceStr8).Tables[0];
            }
            catch
            {
                throw new Exception("获取发票失败");
            }
            try
            {
                dt4 = SqlHelper.ExecuteDataset(conn, CommandType.Text, _dataSourceStr4).Tables[0];
            }
            catch
            {
                throw new Exception("获取存货档案参考成本失败");
            }
            try
            {
                _dataSourceStr7 = Get_dataSourceStr7();
                _dataSourceStr7 = _dataSourceStr7.Replace("1=1","1=1 and ddate between '" + d1.ToString("yyyy-MM-dd") + "' and '" + d2.ToString("yyyy-MM-dd") + "' ");
                _dataSourceStr7 = _dataSourceStr7.Replace("2=2", "2=2 and 销售日期 between '" + d1.ToString("yyyy-MM-dd") + "' and '" + d2.ToString("yyyy-MM-dd") + "' ");
                dt7 = SqlHelper.ExecuteDataset(conn, CommandType.Text, _dataSourceStr7).Tables[0];
                if (dt7.Rows.Count == 0 && isSd == true)
                {
                    throw new Exception("后台没有此日期段销售发票的历史数据");
                }

                
            }
            catch
            {
                throw new Exception("获取存货档案失败");
            }
            type = 1;

            DataTable dt = SqlHelper.ExecuteDataset(conn, CommandType.Text, _dataSourceStr6).Tables[0];

            SqlConnection con = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();
            SqlTransaction trans;
            con.Open();
            cmd.Connection = con;
            trans = con.BeginTransaction();
            cmd.Transaction = trans;
            try
            {
                cmd.CommandText = @"delete  from 产品原价分析汇总";
                cmd.ExecuteNonQuery();

                int iCou = dt.Rows.Count;
                //iCou = 200;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = iCou;
                progressBar1.Step = 1;

                for (int i = 0; i < iCou; i++)
                {
                    NewTB();
                    string cinvcode = dt.Rows[i]["cInvCode"].ToString();
                    DataTable dttop = SqlHelper.ExecuteDataset(conn, CommandType.Text, _dataSourceStr4.Replace(" 1=1 ", " a.cInvCode='" + cinvcode + "' ")).Tables[0];
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
                            double dj1 = 0;
                            double dj2 = 0;
                            double dj3 = 0;
                            double dj4 = 0;
                            double dj5 = 0;
                            double dj6 = 0;
                            double jg = 0;
                            DataTable dtinv = SqlHelper.ExecuteDataset(conn, CommandType.Text, _dataSourceStr.Replace(" 1=1 AND ", " vp.InvCode='" + dttop.Rows[0]["存货编码"].ToString() + "' AND ")).Tables[0];
                            if (dtinv.Rows.Count > 0 && dtinv.Rows[0]["母件物料属性"].ToString() == "委外件")
                            {
                                dj1 = 1 * CCC("发票单价", "最高价", dttop.Rows[0]["存货编码"].ToString(), dtinv.Rows[0]["母件物料属性"].ToString());
                                dj2 = 1 * CCC("发票单价", "最低价", dttop.Rows[0]["存货编码"].ToString(), dtinv.Rows[0]["母件物料属性"].ToString());
                                dj3 = 1 * CCC("参考成本", "", dttop.Rows[0]["存货编码"].ToString(), dtinv.Rows[0]["母件物料属性"].ToString());
                                dj4 = 1 * CCC("供应商价格", "最高价", dttop.Rows[0]["存货编码"].ToString(), dtinv.Rows[0]["母件物料属性"].ToString());
                                dj5 = 1 * CCC("供应商价格", "最低价", dttop.Rows[0]["存货编码"].ToString(), dtinv.Rows[0]["母件物料属性"].ToString());
                                dj6 = 1 * CCC("供应商价格", "最新价", dttop.Rows[0]["存货编码"].ToString(), dtinv.Rows[0]["母件物料属性"].ToString());
                            }
                            else if (dtinv.Rows.Count == 0)
                            {
                                dj1 = 1 * CCC("发票单价", "最高价", dttop.Rows[0]["存货编码"].ToString(), "采购件");
                                dj2 = 1 * CCC("发票单价", "最低价", dttop.Rows[0]["存货编码"].ToString(), "采购件");
                                dj3 = 1 * CCC("参考成本", "", dttop.Rows[0]["存货编码"].ToString(), "采购件");
                                dj4 = 1 * CCC("供应商价格", "最高价", dttop.Rows[0]["存货编码"].ToString(), "采购件");
                                dj5 = 1 * CCC("供应商价格", "最低价", dttop.Rows[0]["存货编码"].ToString(), "采购件");
                                dj6 = 1 * CCC("供应商价格", "最新价", dttop.Rows[0]["存货编码"].ToString(), "采购件");
                            }
                            InsertTB("", dttop.Rows[0]["存货编码"].ToString(), dttop.Rows[0]["存货名称"].ToString(), dttop.Rows[0]["存货英文名称"].ToString(), dttop.Rows[0]["存货规格"].ToString(), dttop.Rows[0]["主计量"].ToString(),
                                "", "", "", "", "", "",
                                0, 0, 0, 0, cen, "", dj1, dj2, dj3, dj4, dj5, dj6, jg,
                                "", "", "", "", "", dt.Rows[i]["cInvCName"].ToString(), dt.Rows[i]["cInvCCode"].ToString());
                        }
                        catch
                        {
                            throw new Exception("获取子件失败" + dttop.Rows[0]["存货编码"].ToString());
                        }
                        Get(conn, dttop.Rows[0]["存货编码"].ToString(), 1, cen, 1);

                        if (dts.Rows[0]["子件编码"].ToString() == "")
                        {
                            dts.Rows[0]["发票最高单价"] = double.Parse(dts.Compute("sum(发票最高单价)", "").ToString());
                            if (dts.Rows[0]["发票最高单价"].ToString() == "")
                            {
                                dts.Rows[0]["发票最高单价"] = 0;
                            }
                            dts.Rows[0]["发票最低单价"] = double.Parse(dts.Compute("sum(发票最低单价)", "").ToString());
                            if (dts.Rows[0]["发票最低单价"].ToString() == "")
                            {
                                dts.Rows[0]["发票最低单价"] = 0;
                            }
                            dts.Rows[0]["发票最新单价"] = double.Parse(dts.Compute("sum(发票最新单价)", "").ToString());
                            if (dts.Rows[0]["发票最新单价"].ToString() == "")
                            {
                                dts.Rows[0]["发票最新单价"] = 0;
                            }

                            dts.Rows[0]["供应商最高单价"] = double.Parse(dts.Compute("sum(供应商最高单价)", "").ToString());
                            if (dts.Rows[0]["供应商最高单价"].ToString() == "")
                            {
                                dts.Rows[0]["供应商最高单价"] = 0;
                            }
                            dts.Rows[0]["供应商最低单价"] = double.Parse(dts.Compute("sum(供应商最低单价)", "").ToString());
                            if (dts.Rows[0]["供应商最低单价"].ToString() == "")
                            {
                                dts.Rows[0]["供应商最低单价"] = 0;
                            }
                            DataRow[] dwi = dt4.Select("存货编码='" + dts.Rows[0]["母件编码"].ToString() + "'");
                            if (dwi.Length > 0 && dwi[0]["参考成本"].ToString() != "")
                            {
                                dts.Rows[0]["参考成本"] = double.Parse(dwi[0]["参考成本"].ToString()).ToString();

                            }
                            if (dts.Rows[0]["参考成本"].ToString() == "")
                            {
                                dts.Rows[0]["参考成本"] = 0;
                            }

                            DataRow[] dwsale = dt7.Select("cinvcode='" + dts.Rows[0]["母件编码"].ToString() + "'", "iNatUnitPrice desc,ddate desc");
                            double 销售标准单价 = 0;
                            string 销售发票号 = "";
                            string 销售发票日期 = "null";
                            decimal 最高进价 = 0;
                            string 产品停用日期 = "null";

                            string 客户编码 = "";
                            string 客户简称 = "";

                            if (dwsale.Length > 0)
                            {
                                if (dwsale[0]["iNatUnitPrice"].ToString() != "")
                                {
                                    销售标准单价 = double.Parse(dwsale[0]["iNatUnitPrice"].ToString());
                                }
                                销售发票号 = dwsale[0]["csbvcode"].ToString() ;

                                if ( dwsale[0]["ddate"].ToString().Trim() != "" && Convert.ToDateTime(dwsale[0]["ddate"]) > Convert.ToDateTime("2000-1-1"))
                                {
                                    销售发票日期 = "'" + dwsale[0]["ddate"].ToString() + "'";
                                }
                                客户编码 = dwsale[0]["ccuscode"].ToString();
                                客户简称 = dwsale[0]["cCusAbbName"].ToString();
                            }
                            DataRow[] dwinv = dt6.Select("cinvcode='" + dts.Rows[0]["母件编码"].ToString() + "'");
                            if (dwinv.Length > 0)
                            {
                                if (dwinv[0]["iInvMPCost"].ToString() != "")
                                {
                                    最高进价 = decimal.Parse(dwinv[0]["iInvMPCost"].ToString());
                                }


                                if ( dwinv[0]["dEDate"].ToString().Trim() != "" && Convert.ToDateTime(dwinv[0]["dEDate"]) > Convert.ToDateTime("2000-1-1"))
                                {
                                    产品停用日期 = "'" + dwinv[0]["dEDate"].ToString() + "'";
                                }
                            }

                            decimal 客户标准销售单价 = 0;
                            
                            DataRow[] dwcus = dt8.Select("cinvcode='" + dts.Rows[0]["母件编码"].ToString() + "'");
                            if (dwcus.Length > 0)
                            {
                                if (dwcus[0]["iinvnowcost"].ToString() != "")
                                {
                                    客户标准销售单价 = decimal.Parse(dwcus[0]["iinvnowcost"].ToString());
                                }
                                客户编码 = dwcus[0]["ccuscode"].ToString();
                                客户简称 = dwcus[0]["cCusAbbName"].ToString();
                            }

                            try
                            {
                                cmd.CommandText = @"insert into 产品原价分析汇总(物料编码,物料名称,英文名称,规格型号,计量单位,物料类别,物料类别编码,发票最高单价,发票最低单价,发票最新单价,
参考成本,供应商最高单价,供应商最低单价,销售标准单价,销售发票号,销售发票日期,最高进价,客户标准销售单价,客户编码,客户简称,产品停用日期,SysCreateDate) 
                    values('" + dts.Rows[0]["母件编码"].ToString() + "','" + dts.Rows[0]["母件名称"].ToString() + "','" + dts.Rows[0]["母件英文名称"].ToString() + "','" + dts.Rows[0]["母件规格型号"].ToString() + "', '" + dts.Rows[0]["母件计量单位"].ToString() + "','" + dts.Rows[0]["物料类别"].ToString() + "','" + dts.Rows[0]["物料类别编码"].ToString() + "',"
                            + "'" + ReturnDecimal2(dts.Rows[0]["发票最高单价"].ToString()) + "',"
                            + "'" + ReturnDecimal2(dts.Rows[0]["发票最低单价"].ToString()) + "',"
                            + "'" + ReturnDecimal2(dts.Rows[0]["发票最新单价"].ToString()) + "',"
                            + "'" + ReturnDecimal2(dts.Rows[0]["参考成本"].ToString()) + "',"
                            + "'" + ReturnDecimal2(dts.Rows[0]["供应商最高单价"].ToString()) + "',"
                            + "'" + ReturnDecimal2(dts.Rows[0]["供应商最低单价"].ToString()) + "',"
                            + "'" + ReturnDecimal2(销售标准单价) + "',"
                            + "'" + 销售发票号 + "'," + 销售发票日期 + ",'" + 最高进价 + "','" + 客户标准销售单价 + "','" + 客户编码 + "','" + 客户简称 + "'," + 产品停用日期 + ",getdate())";
                                cmd.ExecuteNonQuery();
                            }
                            catch(Exception ee)
                            {
                                throw new Exception("获取保存数据出错" + dts.Rows[0]["母件编码"].ToString()+ "   " +ee.Message);
                            }

                        }

                    }
                    progressBar1.PerformStep();

                }
                trans.Commit();
                b =true;
            }
            catch (Exception e)
            {
                b = false;
                trans.Rollback();
                throw new Exception(e.Message);
                
            }
            finally
            {
                progressBar1.Value = 0;
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            label3.Text = DateTime.Now.ToString();


            return b;
        }

        private decimal ReturnDecimal2(object oo)
        {
            try
            {
                decimal o = 0;
                decimal s = 0.00004M;
                if (oo.ToString() != "")
                {
                    o = decimal.Parse(oo.ToString());
                }
                decimal o1 = Math.Round(o, 4);
                decimal o2 = Math.Round(o + s, 4);
                if (o2 >= o1)
                {
                    return Math.Round(o + s, 4);
                }
                else
                {
                    return Math.Round(o, 4);
                }
                //decimal d = 0;
                //try
                //{
                //    d = decimal.Round(Convert.ToDecimal(o), 2);
                //}
                //catch { }
                //return d;
            }
            catch
            {
                return 0;
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
        private void Get(string conn, string cinvcode, double yl, string levid, int stype)//Project project, 
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
                    double dj1 = 0;
                    double dj2 = 0;
                    double dj3 = 0;
                    double dj4 = 0;
                    double dj5 = 0;
                    double dj6 = 0;
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

                    //DataTable dtzj = SqlHelper.ExecuteDataset(conn, CommandType.Text, _dataSourceStr.Replace(" 1=1 AND ", " vp.InvCode='" + dtnew.Rows[i]["子件编码"].ToString() + "' AND ")).Tables[0];
                    if (sx == "采购件" || sx == "委外件")
                    {
                        dj1 = sysl * CCC("发票单价", "最高价", dtnew.Rows[i]["子件编码"].ToString(), sx);
                        dj2 = sysl * CCC("发票单价", "最低价", dtnew.Rows[i]["子件编码"].ToString(), sx);
                        dj3 = sysl * CCC("参考成本", "", dtnew.Rows[i]["子件编码"].ToString(), sx);
                        dj4 = sysl * CCC("供应商价格", "最高价", dtnew.Rows[i]["子件编码"].ToString(), sx);
                        dj5 = sysl * CCC("供应商价格", "最低价", dtnew.Rows[i]["子件编码"].ToString(), sx);
                        dj6 = sysl * CCC("发票单价", "最新价", dtnew.Rows[i]["子件编码"].ToString(), sx);
                    }

                    string cen = levid + i.ToString() + "_";
                    InsertTB(dtnew.Rows[i]["序号"].ToString(), cinvcode, dtnew.Rows[i]["母件名称"].ToString(), dtnew.Rows[i]["母件英文名称"].ToString(), dtnew.Rows[i]["母件规格型号"].ToString(), dtnew.Rows[i]["母件计量单位"].ToString(),
                    dtnew.Rows[i]["子件编码"].ToString(), dtnew.Rows[i]["子件名称"].ToString(), dtnew.Rows[i]["子件英文名称"].ToString(), dtnew.Rows[i]["子件规格型号"].ToString(), dtnew.Rows[i]["子件计量单位"].ToString(), dtnew.Rows[i]["状态"].ToString(),
                    jbyl, jcsl, dcyl, sysl, cen, sx, dj1, dj2, dj3, dj4, dj5, dj6,jg,
                    vendor, vendorname, dtnew.Rows[i]["仓库编码"].ToString(), dtnew.Rows[i]["仓库名称"].ToString(), dtnew.Rows[i]["供应类型"].ToString(), "","");

                    Get(conn, dtnew.Rows[i]["子件编码"].ToString(), sysl, cen, stype);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private  void NewTB()
        {
            dts = new DataTable();
            dts.Columns.Add("序号", typeof(double));
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
            dts.Columns.Add("发票最高单价", typeof(double));
            dts.Columns.Add("发票最低单价", typeof(double));
            dts.Columns.Add("发票最新单价", typeof(double));
            dts.Columns.Add("参考成本", typeof(double));
            dts.Columns.Add("供应商最高单价", typeof(double));
            dts.Columns.Add("供应商最低单价", typeof(double));
            dts.Columns.Add("价格", typeof(double));
            //dts.Columns.Add("总价", typeof(double));
            dts.Columns.Add("供应商编码");
            dts.Columns.Add("供应商名称");
            dts.Columns.Add("仓库编码");
            dts.Columns.Add("仓库名称");
            dts.Columns.Add("供应类型");
            dts.Columns.Add("物料类别");
            dts.Columns.Add("物料类别编码");
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
        /// <param name="wllb">物料类别</param>
        private  void InsertTB(string seq, string invcode, string invname, string invenglishname, string invstd, string invunitname,
         string cinvcode, string cinvname, string cinvenglishname, string cinvstd, string cinvunitname,
         string flag, double baseqtyn, double baseqtyq, double dcusedq, double usedq, string cen, string sx, double dj1, double dj2, double dj3, double dj4, double dj5,double dj6, double zj,
         string vendor, string vendorname, string stock, string stockname, string gylx, string wllb,string wllbbm)
        {
            try
            {
                DataRow dw = dts.NewRow();
                if (seq != "")
                {
                    dw["序号"] = seq;
                }
                dw["母件编码"] = invcode;
                dw["母件名称"] = invname;
                dw["母件英文名称"] = invenglishname;
                dw["母件规格型号"] = invstd;
                dw["母件计量单位"] = invunitname;
                dw["子件编码"] = cinvcode;
                dw["子件名称"] = cinvname;
                dw["子件英文名称"] = cinvenglishname;
                dw["子件规格型号"] = cinvstd;
                dw["子件计量单位"] = cinvunitname;
                dw["状态"] = flag;
                dw["基本用量"] = baseqtyn;
                dw["基础数量"] = baseqtyq;
                dw["单层使用数量"] = dcusedq;
                dw["使用数量"] = usedq;
                dw["层"] = cen;
                dw["子件物料属性"] = sx;
                dw["发票最高单价"] = dj1;
                dw["发票最低单价"] = dj2;
                dw["发票最新单价"] = dj6;
                dw["参考成本"] = dj3;
                dw["供应商最高单价"] = dj4;
                dw["供应商最低单价"] = dj5;
                dw["价格"] = zj;
                dw["供应商编码"] = vendor;
                dw["供应商名称"] = vendorname;
                dw["仓库编码"] = stock;
                dw["仓库名称"] = stockname;
                dw["供应类型"] = gylx;
                dw["物料类别"] = wllb;
                dw["物料类别编码"] = wllbbm;
                
                dts.Rows.Add(dw);
            }
            catch
            {
                throw new Exception("添加行失败");
            }
        }

        #region 得到价格

        private  double CCC(string price, string price2, string zjbm, string sx)
        {
            string[] dj = CCCB(price, price2, zjbm, sx);
            if (dj[0] != "")
            {
               return double.Parse(dj[0]);
            }
            return 0;
        }

        private string[] CCCB(string price, string price2, string zjbm, string sx)
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
                        else if (price2 == "平均价")
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
            catch (Exception ee)
            {
                throw new Exception("获取价格" + zjbm + ee.Message);
            }
        }
        #endregion


        #region 将DataRow[] 更改为DataTable
        public  DataTable DataRowToDataTable(DataRow[] dw)
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

        #endregion


        public Frm定时任务()
        {
            InitializeComponent();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.ToString("HH:mm:ss") == Convert.ToDateTime(timeEdit1.EditValue).ToString("HH:mm:ss"))
            {
                //dateEdit1.Text = DateTime.Now.AddMonths(-3).ToString("yyyy-MM-dd");
                dateEdit2.Text = DateTime.Now.ToString("yyyy-MM-dd");
                //dateEdit3.Text = DateTime.Now.AddMonths(-3).ToString("yyyy-MM-dd");
                dateEdit4.Text = DateTime.Now.ToString("yyyy-MM-dd");
                GetGrid();
            }
        }

        private void GetGrid()
        {
            try
            {
                string s1 = GetConfigValue(sPathConfig, "ServerInfo");
                string s2 = GetConfigValue(sPathConfig, "SQLPWD");
                string s3 = GetConfigValue(sPathConfig, "DataBaseInfo");
                string s4 = GetConfigValue(sPathConfig, "SQLUID");
                string sConn = "server=" + s1 + ";uid=" + s4 + ";pwd=" + s2 + ";database=" + s3 + "";

                GetFormsData(sConn, dateEdit1.DateTime, dateEdit2.DateTime,dateEdit3.DateTime,dateEdit4.DateTime);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            isSd = true;
            GetGrid();
            isSd = false;
        }

        ///
        /// Read confing
        /// </summary>
        /// <param name="path"></param>
        /// <param name="appKey"></param>
        /// <returns></returns>
        public string GetConfigValue(string path, string appKey)
        {
            XmlDocument xDoc = new XmlDocument();
            try
            {
                xDoc.Load(path);
                XmlNode xNode;
                XmlElement xElem;
                xNode = xDoc.SelectSingleNode("//appSettings");
                xElem = (XmlElement)xNode.SelectSingleNode("//add[@key='" + appKey + "']");
                if (xElem != null)
                    return xElem.GetAttribute("value");
                else
                    return "";
            }
            catch (Exception)
            {
                return "";
            }
        }

        private void Frm定时任务_Load(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    label2.Text = "";
                    label3.Text = "";

                    this.WindowState = FormWindowState.Normal;  //还原窗体
                    this.ShowInTaskbar = false;  //不显示在系统任务栏
                    notifyIcon1.Visible = true;    //托盘图标可见

                    string s5 = GetConfigValue(sPathConfig, "sTime");
                    timeEdit1.EditValue = s5;

                    this.StartPosition = FormStartPosition.CenterScreen;

                    dateEdit1.Text = DateTime.Now.AddMonths(-3).ToString("yyyy-MM-dd");
                    dateEdit2.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    dateEdit3.Text = DateTime.Now.AddMonths(-3).ToString("yyyy-MM-dd");
                    dateEdit4.Text = DateTime.Now.ToString("yyyy-MM-dd");
                }
                catch { }

                timer1.Start();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.WindowState = FormWindowState.Normal;  //还原窗体
                    this.ShowInTaskbar = false;  //不显示在系统任务栏
                    notifyIcon1.Visible = true;  //托盘图标显示
                }
                else
                {
                    this.WindowState = FormWindowState.Minimized;
                    this.ShowInTaskbar = false;  //不显示在系统任务栏
                    notifyIcon1.Visible = true;  //托盘图标显示
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void Frm定时任务_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.WindowState == FormWindowState.Minimized)  //判断是否最小化
                {
                    this.ShowInTaskbar = false;  //不显示在系统任务栏
                    notifyIcon1.Visible = true;    //托盘图标可见
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

    }
}
