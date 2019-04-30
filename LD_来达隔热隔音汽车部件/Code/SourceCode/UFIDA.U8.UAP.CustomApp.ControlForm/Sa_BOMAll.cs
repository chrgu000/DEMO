using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using UFIDA.U8.UAP.CustomApp.ControlForm.Business;
using DevExpress.XtraEditors;
using System.Xml;
using DevExpress.XtraTreeList.Nodes;


namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class Sa_BOMAll : UserControl
    {

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        public Sa_BOMAll()
        {
            InitializeComponent();
        }


        private void ProjectManager_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dtmonth = new DataTable();
                dtmonth.Columns.Add("cValue");
                for (int i = 1; i <= 12; i++)
                {
                    DataRow dw = dtmonth.NewRow();
                    dw[0] = i.ToString();
                    dtmonth.Rows.Add(dw);
                }
                lookUpEditMonth.Properties.DataSource = dtmonth;

                txt年.EditValue = DateTime.Now.Year;

                lookUpEditMonth.EditValue = DateTime.Now.AddMonths(-1).Month.ToString();

                if (lookUpEditMonth.EditValue.ToString() == "12")
                {
                    txt年.EditValue = DateTime.Now.Year - 1;
                }

                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetGrid();
        }

        DataTable dtcg;
        DataTable dtc;
        DataTable dtt;
        DataTable dtsfc;
        DataTable dtso;
        DataTable dtinv;
        DataTable dtcb;
        string sd;
        string ed;

        private void GetGrid()
        {
            try
            {
                
                treeList1.Nodes.Clear();

                if (txt年.Text.Trim() == "")
                {
                    throw new Exception("年度不可为空");
                }
                if (lookUpEditMonth.EditValue.ToString() == "")
                {
                    throw new Exception("月份不可为空");
                }

                sd = txt年.EditValue.ToString() + "-" + lookUpEditMonth.EditValue.ToString()+"-01";
                ed = DateTime.Parse(sd).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");
                

                dtcg = GetCusInvContraposeGroup();
                dtc = GetCusInvContrapose();
                dtt = GetTree();
                dtso = GetSo();
                dtinv = GetInv();
                dtcb = GetCb();
                dtsfc = GetSfchz();
                //找出客户存货对照表中的所有存货
                for (int i = 0; i < dtcg.Rows.Count; i++)
                {
                    string tl = dtcg.Rows[i]["cInvCode"].ToString();
                    //DataRow[] dw = dtso.Select("cInvCode='" + tl + "'");
                    //if (dw.Length > 0)
                    //{
                        //找出存货对应的客户，如果为多条则跳过
                        //DataRow[] dwc = dtc.Select("cInvCode='" + tl + "'");
                        //if (dwc.Length == 1)
                        //{
                            AddNode(tl);
                        //}
                    //}
                }

                treeList1.ExpandAll();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void AddNode(string tl)
        {
            int isOpen = 0;
            object[] obj = AddNodeObj(0, tl, 0, 0, 0,out isOpen);
            TreeListNode node = treeList1.AppendNode(obj, -1);
            //如果修改后的库存金额小于0再展开一层
            if (isOpen == 1)
            {
                DataRow[] dwr = dtt.Select("母件编码='" + tl + "' and 子件物料属性='自制件' ");
                for (int i = 0; i < dwr.Length; i++)
                {
                    string tlzj = dwr[i]["子件编码"].ToString();
                    decimal d成品金额 = 规格化.ReturnDecimal(obj[9], 6);
                    decimal d成品成本金额 = 规格化.ReturnDecimal(obj[13], 6);
                    decimal d半成品销量 = 规格化.ReturnDecimal(obj[6], 6) - 规格化.ReturnDecimal(obj[7], 6);
                    int isOpen2 = 0;
                    TreeListNode node1 = treeList1.AppendNode(AddNodeObj(1, tlzj, d成品金额, d成品成本金额, d半成品销量, out isOpen2), node);
                }
            }
        }

        private object[] AddNodeObj(int flag, string tl, decimal d成品金额, decimal d成品成本金额, decimal d半成品销量, out int isOpen)
        {
            isOpen = 0;
            DataRow[] dwc = dtc.Select("cInvCode='" + tl + "'");
            string cCusInvCode = "";
            string cCusName = "";
            string s是否客户付款 = "";
            if (dwc.Length > 0)
            {
                cCusInvCode = dwc[0]["cCusInvCode"].ToString();
                cCusName = dwc[0]["cCusName"].ToString();
                s是否客户付款 = dwc[0]["cCusDefine2"].ToString();
            }
            //结存
            DataRow[] dwf = dtsfc.Select("物料编码='" + tl + "' and 收发存='结存'");
            decimal d月底结存数量 = 0;
            decimal d月底结存金额 = 0;

            decimal d实际材料单价 = 0;
            decimal d实际人工单价 = 0;
            decimal d实际固定制造单价 = 0;
            decimal d实际变动制造单价 = 0;
            if (dwf.Length > 0)
            {
                d月底结存数量 = 规格化.ReturnDecimal(dwf[0]["数量"], 2);
                d月底结存金额 = 规格化.ReturnDecimal(dwf[0]["结存金额"], 2);
                if (d月底结存数量 < 0)
                {
                    d月底结存数量 = 0;
                    d月底结存金额 = 0;
                }

                d实际材料单价 = 规格化.ReturnDecimal(dwf[0]["实际材料单价"], 2);
                d实际人工单价 = 规格化.ReturnDecimal(dwf[0]["实际人工单价"], 2);
                d实际固定制造单价 = 规格化.ReturnDecimal(dwf[0]["实际固定制造单价"], 2);
                d实际变动制造单价 = 规格化.ReturnDecimal(dwf[0]["实际变动制造单价"], 2);
            }
            //14天销量
            decimal d14天销量 = 规格化.ReturnDecimal(dtso.Compute("sum(iQuantity)", "cInvCode='" + tl + "'"), 2);
            //销量和库存比较（取较小值）
            decimal d确认销量 = d月底结存数量;
            if (d月底结存数量 > d14天销量)
            {
                d确认销量 = d14天销量;
            }
            if (flag == 1)
            {
                d14天销量 = d半成品销量;
            }
            //销售单价
            decimal d销售单价 = 0;
            if (d成品金额 == 0)
            {
                DataRow[] dwso = dtso.Select("cInvCode='" + tl + "'", "ddate desc");
                if (dwso.Length > 0)
                {
                    d销售单价 = 规格化.ReturnDecimal(dwso[0]["iTaxUnitPrice"], 2);
                }
            }
            else
            {
                DataRow[] dwcbs = dtcb.Select("cInvCode='" + tl + "'");
                if (dwcbs.Length > 0)
                {
                    d销售单价 = d成品金额 * (d成品成本金额 / 规格化.ReturnDecimal(dwcbs[0]["iInvRCost"], 4));
                }
            }
            decimal d金额 = d销售单价 * d确认销量;
            //是否客户付款
            decimal d确认收入 = 0;
            if (s是否客户付款 == "是")
            {
                d确认收入 = d金额;
            }
            //标准成本
            decimal d标准成本单价 = 0;
            DataRow[] dwcb = dtcb.Select("cInvCode='" + tl + "'");
            if (dwcb.Length > 0)
            {
                d标准成本单价 = 规格化.ReturnDecimal(dwcb[0]["iInvRCost"], 4);
            }
            DataRow[] dwinv = dtinv.Select("cInvCode='" + tl + "'");
            decimal d标准成本金额 = 0;
            string s是否共用存货 = "";
            if (dwinv.Length > 0)
            {

                d标准成本金额 = d标准成本单价 * d确认销量;

                s是否共用存货 = dwinv[0]["cInvDefine9"].ToString();

            }

            decimal d实际材料金额 = 0;
            decimal d实际人工金额 = 0;
            decimal d实际固定制造金额 = 0;
            decimal d实际变动制造金额 = 0;

            d实际材料金额 = d实际材料单价 * d确认销量;
            d实际人工金额 = d实际人工单价 * d确认销量;
            d实际固定制造金额 = d实际固定制造单价 * d确认销量;
            d实际变动制造金额 = d实际变动制造单价 * d确认销量;

            //修改后的库存金额
            decimal d修改后的库存金额 = d月底结存金额 - d标准成本金额;
            if (d修改后的库存金额 < 0)
            {
                d修改后的库存金额 = 0;
                isOpen = 1;
            }

            return new object[] { tl, cCusInvCode, cCusName,d月底结存数量 ,d月底结存金额 ,s是否共用存货
                ,d14天销量, d确认销量, d销售单价, d金额, s是否客户付款,d确认收入
                ,d实际材料单价,d实际人工单价,d实际固定制造单价,d实际变动制造单价
                ,d实际材料金额,d实际人工金额,d实际固定制造金额,d实际变动制造金额
                ,d标准成本单价,d标准成本金额,d修改后的库存金额 };

        }
        //private void AddNode(TreeListNode node, string tl)
        //{
        //    DataRow[] dwr = dtt.Select("母件编码='" + tl + "'");
        //    for (int i = 0; i < dwr.Length; i++)
        //    {
        //        string tl1 = dwr[i]["子件编码"].ToString();
        //        TreeListNode node1 = treeList1.AppendNode(new object[] { tl1 }, node);

        //        AddNode(node1, tl1);
        //    }
        //}

        private DataTable GetTree()
        {
            string sSQL = @"SELECT convert(float,c.SortSeq) as 序号,vp.InvCode AS 母件编码,vp.InvName AS 母件名称,vpi.cEnglishName as 母件英文名称,
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
            and vpi.cInvCCode<>'I09' and vci.cInvCCode<>'I09'
            Order By vp.InvCode,convert(float,c.SortSeq)  ";
            return SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
        }

        private DataTable GetCusInvContraposeGroup()
        {
            string sSQL = @"select distinct cInvCode from inventory where cInvCCode='I05'";
            return SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
        } 

        private DataTable GetCusInvContrapose()
        {
            string sSQL = @"select a.cCusCode,cInvCode,cCusInvCode,b.cCusName,b.cCusDefine2 from CusInvContrapose  a left join Customer b on a.cCusCode=b.cCusCode ";
            return SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
        }

        private DataTable GetSo()
        {
//            string sSQL = @"select cInvCode,iQuantity-isnull(iFHQuantity,0)  as iQuantity,iTaxUnitPrice,ddate  from SO_SOMain  a left join SO_SODetails b on a.ID =b.ID 
//                where convert(varchar(10),cDefine36,120)>='" + DateTime.Parse(ed).AddDays(1).ToString("yyyy-MM-dd") + "' and convert(varchar(10),cDefine36,120)<='" + DateTime.Parse(ed).AddDays(16).ToString("yyyy-MM-dd") + "' and isnull(cVerifier,'')<>'' ";
            string sSQL = @"select cInvCode,iQuantity-isnull(iKPQuantity,0)  as iQuantity,iTaxUnitPrice,ddate  from SO_SOMain  a left join SO_SODetails b on a.ID =b.ID 
                where iQuantity-isnull(iKPQuantity,0)>0 and isnull(cVerifier,'')<>'' and isnull(cSCloser,'')='' and isnull(cSCloser,'')='' ";
            return SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
        }

        private DataTable GetInv()
        {
            string sSQL = @"SELECT * FROM  Inventory ";
            return SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
        }

        private DataTable GetCb()
        {
            string sSQL = "select * from Inventory ";
            return SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
        }

        private DataTable GetSfchz()
        {
            string sSQL = @"if object_id(N'_temp_sfchz',N'U') is not null drop table _temp_sfchz

declare @p1 int
set @p1=0
exec sp_prepexecrpc @p1 output,N'sp_CO_InvHZ','  1>0  and  1>0  and  1>0  and  1>0  and  1>0  and  1>0  and  1>0  and  1>0  and  1>0  and  1>0  and  ( A.iPeriod  >= N''201710'') and ( A.iPeriod  <= N''201710'') and  right(A.iPeriod,2) <> ''00'' ','1=1','_temp_sfchz',1,2,'201710','201710','201700'
select @p1";
            sSQL = sSQL.Replace("201710", DateTime.Parse(sd).ToString("yyyyMM"));
            SqlHelper.ExecuteScalar(Conn, CommandType.Text, sSQL);
            sSQL = @"select *,ISNULL(实际材料费用,0)+ISNULL(实际人工费用,0)+ISNULL(实际固定制造费用,0)+ISNULL(实际变动制造费用,0)+ISNULL(实际委外加工费,0) as 结存金额 
            ,case when isnull(数量,0)=0 then 0 else ISNULL(实际材料费用,0)/isnull(数量,0) end as 实际材料单价
            ,case when isnull(数量,0)=0 then 0 else ISNULL(实际人工费用,0)/isnull(数量,0) end as 实际人工单价
            ,case when isnull(数量,0)=0 then 0 else ISNULL(实际固定制造费用,0)/isnull(数量,0) end as 实际固定制造单价
            ,case when isnull(数量,0)=0 then 0 else ISNULL(实际变动制造费用,0)/isnull(数量,0) end as 实际变动制造单价
            from _temp_sfchz";
            return SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
        }

        private void grvDetail_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {

            if (e.RowHandle < 0)
                return;
            e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sa = new SaveFileDialog();
                sa.Filter = "Excel文件2003|*.xls";
                sa.FileName = "销售";

                DialogResult d = sa.ShowDialog();
                if (d == DialogResult.OK)
                {
                    string sPath = sa.FileName;

                    if (sPath.Trim() != string.Empty)
                    {
                        treeList1.ExportToXls(sPath);
                        MessageBox.Show("导出列表成功！\n路径：" + sPath);
                    }
                }
                
            }
            catch (Exception ee)
            {
                MessageBox.Show("导出列表失败：" + ee.Message);
            }
        }

    }
}