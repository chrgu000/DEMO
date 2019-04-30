using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class Frm明细 : Form
    {
        public string Conn { get; set; }
        string icinvcode; string isdate; string iedate; bool ibcHandler; bool ibcHas; string icFree3; string icFree4; string icWhCode; string icPosCode;

        public Frm明细(string conn)
        {
            InitializeComponent();
            Conn = conn;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cDepCode">部门</param>
        /// <param name="cPersonCode">销售员</param>
        /// <param name="cCusCode">客户</param>
        /// <param name="cDCName">区域</param>
        /// <param name="cInvName">存货</param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        public void 销售出库明细(string cDepCode, string cPersonCode, string cDCName, string cInvCode, string cCusCode, string year, string month)
        {
            try
            {
                this.Text = "销售出库明细";
                string sSQL = @"select a.dDate as 日期,w.cWhName as 公司名称,p.cPersonName as 业务员,c.cCusAbbName as 客户简称,a.cCode as 单据号
,case when ISNULL(a.cHandler ,'')<>'' then '审核' when isnull(a.iswfcontrolled,0)=1 and isnull(a.iverifystate ,0)=1 then '审核中' when ISNULL(a.cMaker,'')<>'' then '开立' end as 审批状态
,i.cInvName as 品名简称,i.cInvStd as 规格型号,cFree1 as 包装,cBatch as 批号,convert(decimal(18, 3),b.iquantity) as 数量,cu.cComUnitName 单位
,convert(decimal(18, 2),b.iUnitCost) as 含税单价 ,convert(decimal(18, 2),b.iPrice) as 含税金额,rs.cRdName as 销售出库类别
,cBatchProperty6 as 物料标识或备注,cBatchProperty7 as 包装批号,cBatchProperty9 as 作业指导书,cMaker as 制单人
--,d.cDepName as 部门,dis.cDCName as 区域,b.irowno as 行号,b.cInvCode as 物料编码,i.cInvName as 品名 
from RdRecord32 a inner join rdrecords32 b on a.ID = b.ID left join Inventory i on b.cInvCode=i.cInvCode left join Customer c on a.cCusCode=c.cCusCode
left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode left join DistrictClass dis on c.cDCCode=dis.cDCCode
left join Warehouse w on a.cWhCode=w.cWhCode left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
left join Rd_Style rs on a.cRdCode =rs.cRdCode 
where 1=1 ";
                if (cDepCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(d.cDepName,'')='" + cDepCode + "'");
                }
                if (cPersonCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(p.cPersonName,'')='" + cPersonCode + "'");
                }
                if (cCusCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(c.cCusName,'')='" + cCusCode + "'");
                }
                if (cInvCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(i.cInvCode,'')='" + cInvCode + "'");
                }
                if (cDCName != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(dis.cDCName,'')='" + cDCName + "'");
                }
                if (year != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and datepart(yyyy,a.dDate)='" + year + "'");
                }
                if (month != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and datepart(mm,a.dDate)='" + month + "'");
                }
                sSQL = sSQL + " order by a.dDate";
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                gridControl1.DataSource = dt;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (gridView1.Columns[i].FieldName == "数量" || gridView1.Columns[i].FieldName == "含税金额")
                    {
                        gridView1.Columns[i].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });
                    }
                }
                gridView1.OptionsBehavior.Editable = false;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败:" + ee.Message);
            }
        }

        public void 材料出库明细(string cDepCode, string cInvCode, string year, string month)
        {
            try
            {
                this.Text = "材料出库明细";
                string sSQL = @"select a.dDate as 日期,w.cWhName as 仓库,a.cDefine3 as 生产车间,a.cMaker as 制单人,a.cCode as 单据号
,case when ISNULL(a.cHandler ,'')<>'' then '审核' when isnull(a.iswfcontrolled,0)=1 and isnull(a.iverifystate ,0)=1 then '审核中' when ISNULL(a.cMaker,'')<>'' then '开立' end as 审批状态
,i.cInvName as 品名简称,i.cInvStd as 规格型号,cFree1 as 包装,cBatch as 批号,convert(decimal(18, 3),b.iquantity) as 数量,cu.cComUnitName 单位
,cBatchProperty6 as 物料标识或备注,cBatchProperty7 as 包装批号,cBatchProperty9 as 作业指导书,cFree3 as 虚拟库,cPosName as 库房,r.crdname as 出库类别
--,dis.cDCName as 区域,c.cCusName as 客户,b.cInvCode as 物料编码,i.cInvName as 品名,ic.cInvCName as 财务产品分类,i.cInvName as 品名简称,w.cWhName as 公司名称,d.cDepName as 领料部门,p.cPersonName as 领料人员
from RdRecord11 a inner join rdrecords11 b on a.ID = b.ID left join Inventory i on b.cInvCode=i.cInvCode left join Customer c on a.cCusCode=c.cCusCode
left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode left join DistrictClass dis on c.cDCCode=dis.cDCCode
left join Warehouse w on a.cWhCode=w.cWhCode left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
left join Rd_Style r on a.cRdCode=r.cRdCode left join Position po on b.cPosition =po.cPosCode 
where 1=1 ";
                if (cDepCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(d.cDepName,'')='" + cDepCode + "'");
                }
                if (cInvCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(i.cInvCode,'')='" + cInvCode + "'");
                }
                if (year != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and datepart(yyyy,a.dDate)='" + year + "'");
                }
                if (month != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and datepart(mm,a.dDate)='" + month + "'");
                }
                sSQL = sSQL + " order by a.dDate";
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                gridControl1.DataSource = dt;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (gridView1.Columns[i].FieldName == "数量" || gridView1.Columns[i].FieldName == "金额")
                    {
                        gridView1.Columns[i].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });
                    }
                }
                gridView1.OptionsBehavior.Editable = false;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败:" + ee.Message);
            }
        }

        public void 采购入库单明细(string cDepCode, string cPersonCode, string cVenName,
            //string cWhCode,string cPosCode,string cFree4, 
            string cInvCode, string year, string month)
        {
            try
            {
                this.Text = "采购入库单明细";
                string sSQL = @"select a.dDate as 日期,w.cWhName as 公司名称,a.cDefine10 as 采购员,v.cVenAbbName as 供应商简称,a.cCode as 单据号
,case when ISNULL(a.cHandler ,'')<>'' then '审核' when isnull(a.iswfcontrolled,0)=1 and isnull(a.iverifystate ,0)=1 then '审核中' when ISNULL(a.cMaker,'')<>'' then '开立' end as 审批状态
,i.cInvName as 品名简称,i.cInvStd as 规格型号,cFree1 as 包装,cBatch as 批号,convert(decimal(18, 3),b.iquantity) as 数量,cu.cComUnitName 单位
,convert(decimal(18, 2),b.iUnitCost) as 含税单价 ,convert(decimal(18, 2),b.iPrice) as 含税金额,b.dSDate as 结算日期 ,cBatchProperty6 as 物料标识或备注,cFree3 as 虚拟库,r.crdname as 入库类别
--,ic.cInvCName as 财务产品分类,a.cMemo as 入库备注,dis.cDCName as 区域,b.irowno as 行号,b.cInvCode as 物料编码,i.cInvName as 品名 ,a.cDefine8 as 请购员
from RdRecord01 a inner join rdrecords01 b on a.ID = b.ID left join Inventory i on b.cInvCode=i.cInvCode left join Vendor v on a.cVenCode=v.cVenCode
left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode left join DistrictClass dis on v.cDCCode=dis.cDCCode
left join Warehouse w on a.cWhCode=w.cWhCode left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
left join Rd_Style r on a.cRdCode=r.cRdCode
where 1=1 ";
                if (cDepCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(d.cDepName,'')='" + cDepCode + "'");
                }
                if (cPersonCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(cdefine10,'')='" + cPersonCode + "'");
                }
                if (cVenName != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(v.cVenName,'')='" + cVenName + "'");
                }
                if (cInvCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(i.cInvCode,'')='" + cInvCode + "'");
                }
                if (year != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and datepart(yyyy,a.dDate)='" + year + "'");
                }
                if (month != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and datepart(mm,a.dDate)='" + month + "'");
                }
                //if (cWhCode != "")
                //{
                //    sSQL = sSQL.Replace("1=1", "1=1 and isnull(a.cWhCode,'')='" + cWhCode + "'");
                //}
                //if (cPosCode != "")
                //{
                //    sSQL = sSQL.Replace("1=1", "1=1 and isnull(b.cPosition,'')='" + cPosCode + "'");
                //}
                //if (cFree4 != "")
                //{
                //    sSQL = sSQL.Replace("1=1", "1=1 and isnull(b.cFree4,'')='" + cFree4 + "'");
                //}
                sSQL = sSQL + " order by a.dDate";
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                gridControl1.DataSource = dt;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (gridView1.Columns[i].FieldName == "数量" || gridView1.Columns[i].FieldName == "含税金额")
                    {
                        gridView1.Columns[i].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });
                    }
                }
                gridView1.OptionsBehavior.Editable = false;
                gridView1.BestFitColumns();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败:" + ee.Message);
            }
        }

        public void 产品入库单明细(string cInvCode, string year, string month,int Flag,string cCode)
        {
            try
            {
                this.Text = "产品入库单明细";
                string sSQL = @"select a.dDate as 日期,w.cWhName as 仓库,a.cDefine3 as 生产车间,a.cMaker as 制单人,a.cCode as 单据号
,case when ISNULL(a.cHandler ,'')<>'' then '审核' when isnull(a.iswfcontrolled,0)=1 and isnull(a.iverifystate ,0)=1 then '审核中' when ISNULL(a.cMaker,'')<>'' then '开立' end as 审批状态
,i.cInvName as 品名简称,i.cInvStd as 规格型号,cFree1 as 包装,cBatch as 批号,convert(decimal(18, 3),b.iquantity) as 数量,cu.cComUnitName 单位
,cBatchProperty6 as 物料标识或备注,cBatchProperty7 as 包装批号,cBatchProperty9 as 作业指导书,cFree3 as 虚拟库,cPosName as 库房,r.crdname as 出库类别
--,r.crdname as 出库类别,dis.cDCName as 区域,v.cVenName as 客户,a.dDate as 日期,b.cInvCode as 物料编码,i.cInvName as 品名, w.cWhName as 公司名称,ic.cInvCName as 财务产品分类,r.crdname as 备货类别
from RdRecord10 a inner join rdrecords10 b on a.ID = b.ID left join Inventory i on b.cInvCode=i.cInvCode left join Vendor v on a.cVenCode=v.cVenCode
left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode left join DistrictClass dis on v.cDCCode=dis.cDCCode
left join Warehouse w on a.cWhCode=w.cWhCode left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
left join Rd_Style r on a.cRdCode=r.cRdCode  left join Position po on b.cPosition =po.cPosCode 
where 1=1 ";
                if (cInvCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(i.cInvCode,'')='" + cInvCode + "'");
                }
                if (year != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and datepart(yyyy,a.dDate)='" + year + "'");
                }
                if (month != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and datepart(mm,a.dDate)='" + month + "'");
                }
                if (cCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cCode='" + cCode + "'");
                }
                sSQL = sSQL + " order by a.dDate";
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                gridControl1.DataSource = dt;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (gridView1.Columns[i].FieldName == "数量" || gridView1.Columns[i].FieldName == "金额")
                    {
                        gridView1.Columns[i].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });
                    }
                }
                gridView1.OptionsBehavior.Editable = false;
                gridView1.BestFitColumns();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败:" + ee.Message);
            }
        }

        //库存物资统计

//        public void 累计入库(string cInvCode, string sdate, string edate, string cposname, string cFree1, string cFree3)
//        {
//            try
//            {
//                this.Text = "累计入库明细";
//                string sSQL = @"select a.dDate as 入库日期, w.cWhName as 公司名称,ic.cInvCName as 财务产品分类,i.cInvName as 品名简称,i.cInvStd as 规格型号,cFree1 as 包装,r.crdname as 备货类别,a.cCode as 入库单号
//,case when ISNULL(a.cHandler ,'')<>'' then '审核' when isnull(a.iswfcontrolled,0)=1 and isnull(a.iverifystate ,0)=1 then '审核中' when ISNULL(a.cMaker,'')<>'' then '开立' end as 审批状态
//,r.crdname as 出库类别,cBatch as 批号,convert(decimal(18, 3),b.iquantity) as 数量,cu.cComUnitName 单位
//,cBatchProperty6 as 物料标识或备注,cBatchProperty7 as 包装批号,cBatchProperty9 as 作业指导书
//,dis.cDCName as 区域,v.cVenName as 客户,a.dDate as 日期,b.cInvCode as 物料编码,i.cInvName as 品名
//from RdRecord10 a inner join rdrecords10 b on a.ID = b.ID left join Inventory i on b.cInvCode=i.cInvCode left join Vendor v on a.cVenCode=v.cVenCode
//left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode left join DistrictClass dis on v.cDCCode=dis.cDCCode
//left join Warehouse w on a.cWhCode=w.cWhCode left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
//left join Rd_Style r on a.cRdCode=r.cRdCode
//where 1=1 and b.iquantity>0";
//                if (cInvCode != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(i.cInvCode,'')='" + cInvCode + "'");
//                }
//                if (sdate != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dDate,120)>='" + sdate + "'");
//                }
//                if (edate != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dDate,120)<='" + edate + "'");
//                }
//                if (cposname != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and cposname='" + cposname + "'");
//                }
//                if (cFree1 != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and b.cFree1='" + cFree1 + "'");
//                }
//                if (cFree3 != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and b.cFree3='" + cFree3 + "'");
//                }
//                sSQL = sSQL + " order by a.dDate";
//                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
//                gridControl1.DataSource = dt;
//                for (int i = 0; i < gridView1.Columns.Count; i++)
//                {
//                    if (gridView1.Columns[i].FieldName == "数量" || gridView1.Columns[i].FieldName == "金额")
//                    {
//                        gridView1.Columns[i].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });
//                    }
//                }
//                gridView1.OptionsBehavior.Editable = false;
//            }
//            catch (Exception ee)
//            {
//                MessageBox.Show("加载数据失败:" + ee.Message);
//            }
//        }

        public void 累计领料(string cInvCode, string sdate, string edate, string cposname, string cFree1, string cFree3, int Flag, string cCode)
        {
            try
            {
                this.Text = "累计领料明细";
                string sSQL = @"select w.cWhName as 公司名称,d.cDepName as 领料部门,a.cDefine3 as 生产车间,p.cPersonName as 领料人员,a.cCode as 出库单号
,case when ISNULL(a.cHandler ,'')<>'' then '审核' when isnull(a.iswfcontrolled,0)=1 and isnull(a.iverifystate ,0)=1 then '审核中' when ISNULL(a.cMaker,'')<>'' then '开立' end as 审批状态
,r.crdname as 出库类别,ic.cInvCName as 财务产品分类,i.cInvName as 品名简称,i.cInvStd as 规格型号,cFree1 as 包装,cBatch as 批号,convert(decimal(18, 3),b.iquantity) as 数量,cu.cComUnitName 单位
,cBatchProperty6 as 物料标识或备注,cBatchProperty7 as 包装批号,cBatchProperty9 as 作业指导书
,dis.cDCName as 区域,c.cCusName as 客户,a.dDate as 日期,b.cInvCode as 物料编码,i.cInvName as 品名
from RdRecord11 a inner join rdrecords11 b on a.ID = b.ID left join Inventory i on b.cInvCode=i.cInvCode left join Customer c on a.cCusCode=c.cCusCode
left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode left join DistrictClass dis on c.cDCCode=dis.cDCCode
left join Warehouse w on a.cWhCode=w.cWhCode left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
left join Rd_Style r on a.cRdCode=r.cRdCode
where 1=1 ";
                if (cInvCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(i.cInvCode,'')='" + cInvCode + "'");
                }
                if (sdate != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dDate,120)>='" + sdate + "'");
                }
                if (edate != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dDate,120)<='" + edate + "'");
                }
                if (cposname != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and cposname='" + cposname + "'");
                }
                if (cFree1 != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.cFree1='" + cFree1 + "'");
                }
                if (cFree3 != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.cFree3='" + cFree3 + "'");
                }
                if (cCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cCode='" + cCode + "'");
                }
                if (Flag == 0)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.iquantity>0");
                    this.Text = "累计领料明细";
                }
                else if (Flag == 1)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.iquantity<0");
                    this.Text = "累计退库明细";
                }
                else
                {
                    this.Text = "材料出库单明细";
                }
                sSQL = sSQL + " order by a.dDate";
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                gridControl1.DataSource = dt;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (gridView1.Columns[i].FieldName == "数量" || gridView1.Columns[i].FieldName == "金额")
                    {
                        gridView1.Columns[i].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });
                    }
                }
                gridView1.OptionsBehavior.Editable = false;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败:" + ee.Message);
            }
        }

//        public void 采购入库(string cInvCode, string sdate, string edate, string cposname, string cFree1, string cFree3, int Flag, string cCode)
//        {
//            try
//            {
                
//                string sSQL = @"select a.dDate as 入库日期,w.cWhName as 公司名称,a.cDefine10 as 采购员,a.cDefine8 as 请购员,v.cVenAbbName as 供应商简称,a.cCode as 入库单号
//,case when ISNULL(a.cHandler ,'')<>'' then '审核' when isnull(a.iswfcontrolled,0)=1 and isnull(a.iverifystate ,0)=1 then '审核中' when ISNULL(a.cMaker,'')<>'' then '开立' end as 审批状态
//,r.crdname as 入库类别,ic.cInvCName as 财务产品分类,i.cInvName as 品名简称,i.cInvStd as 规格型号,cFree1 as 包装,cBatch as 批号,convert(decimal(18, 3),b.iquantity) as 数量,cu.cComUnitName 单位
//,a.cMemo as 入库备注,dis.cDCName as 区域,b.irowno as 行号,b.cInvCode as 物料编码,i.cInvName as 品名 
//from RdRecord01 a inner join rdrecords01 b on a.ID = b.ID left join Inventory i on b.cInvCode=i.cInvCode left join Vendor v on a.cVenCode=v.cVenCode
//left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode left join DistrictClass dis on v.cDCCode=dis.cDCCode
//left join Warehouse w on a.cWhCode=w.cWhCode left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
//left join Rd_Style r on a.cRdCode=r.cRdCode
//where 1=1 ";
//                if (cInvCode != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(i.cInvCode,'')='" + cInvCode + "'");
//                }
//                if (sdate != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dDate,120)>='" + sdate + "'");
//                }
//                if (edate != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dDate,120)<='" + edate + "'");
//                }
//                if (cposname != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and cposname='" + cposname + "'");
//                }
//                if (cFree1 != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and b.cFree1='" + cFree1 + "'");
//                }
//                if (cFree3 != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and b.cFree3='" + cFree3 + "'");
//                }
//                if (cCode != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and a.cCode='" + cCode + "'");
//                }
//                if (Flag == 0)
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and b.iquantity>0");
//                    this.Text = "采购入库数量明细";
//                }
//                else if (Flag == 1)
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and b.iquantity<0");
//                    this.Text = "退货数量明细";
//                }
//                else
//                {
//                    this.Text = "采购入库单明细";
//                }
//                sSQL = sSQL + " order by a.dDate";
//                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
//                gridControl1.DataSource = dt;
//                for (int i = 0; i < gridView1.Columns.Count; i++)
//                {
//                    if (gridView1.Columns[i].FieldName == "数量" || gridView1.Columns[i].FieldName == "金额")
//                    {
//                        gridView1.Columns[i].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });
//                    }
//                }
//                if (cFree1 != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and b.cFree1='" + cFree1 + "'");
//                }
//                gridView1.OptionsBehavior.Editable = false;
//            }
//            catch (Exception ee)
//            {
//                MessageBox.Show("加载数据失败:" + ee.Message);
//            }
//        }

//        public void 累计销售(string cInvCode, string sdate, string edate, string cposname, string cFree1, string cFree3,int Flag,string cCode)
//        {
//            try
//            {
                
//                string sSQL = @"select a.dDate as 单据日期,w.cWhName as 公司名称,p.cPersonName as 业务员,c.cCusName as 客户,a.cCode as 单号
//,case when ISNULL(a.cHandler ,'')<>'' then '审核' when isnull(a.iswfcontrolled,0)=1 and isnull(a.iverifystate ,0)=1 then '审核中' when ISNULL(a.cMaker,'')<>'' then '开立' end as 审批状态
//,ic.cInvCName as 财务产品分类,i.cInvName as 品名简称,i.cInvStd as 规格型号,cFree1 as 包装,cBatch as 批号,convert(decimal(18, 3),b.iquantity) as 数量,cu.cComUnitName 单位
//,cBatchProperty6 as 物料标识或备注,cBatchProperty7 as 包装批号,cBatchProperty9 as 作业指导书
//,d.cDepName as 部门,dis.cDCName as 区域,b.irowno as 行号,b.cInvCode as 物料编码,i.cInvName as 品名 --,convert(decimal(18, 2),b.iPrice) as 金额 
//from RdRecord32 a inner join rdrecords32 b on a.ID = b.ID left join Inventory i on b.cInvCode=i.cInvCode left join Customer c on a.cCusCode=c.cCusCode
//left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode left join DistrictClass dis on c.cDCCode=dis.cDCCode
//left join Warehouse w on a.cWhCode=w.cWhCode left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
//where 1=1 ";
//                if (cInvCode != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(i.cInvCode,'')='" + cInvCode + "'");
//                }
//                if (sdate != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dDate,120)>='" + sdate + "'");
//                }
//                if (edate != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dDate,120)<='" + edate + "'");
//                }
//                if (cposname != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and cposname='" + cposname + "'");
//                }
//                if (cFree1 != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and b.cFree1='" + cFree1 + "'");
//                }
//                if (cFree3 != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and b.cFree3='" + cFree3 + "'");
//                }
//                if (cCode != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and a.cCode='" + cCode + "'");
//                }
//                if (Flag == 0)
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and b.iquantity>0");
//                    this.Text = "累计销售明细";
//                }
//                else if (Flag == 1)
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and b.iquantity<0");
//                    this.Text = "累计退货明细";
//                }
//                else
//                {
//                    this.Text = "销售明细";
//                }
//                sSQL = sSQL + " order by a.dDate";
//                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
//                gridControl1.DataSource = dt;
//                for (int i = 0; i < gridView1.Columns.Count; i++)
//                {
//                    if (gridView1.Columns[i].FieldName == "数量" || gridView1.Columns[i].FieldName == "金额")
//                    {
//                        gridView1.Columns[i].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });
//                    }
//                }
//                gridView1.OptionsBehavior.Editable = false;
//            }
//            catch (Exception ee)
//            {
//                MessageBox.Show("加载数据失败:" + ee.Message);
//            }
//        }

        public void 出入库单明细(string cInvCode1, string cInvCode2, string sdate, string edate, string cposname
            , string cFree1, string cFree3 ,int QuantityFlag, string cCode,string Flag)
        {
            try
            {
                string sSQL = "";
                if (Flag == "01")
                {
                    #region SQL
                    sSQL = @"select a.dDate as 入库日期,w.cWhName as 公司名称,a.cDefine10 as 采购员,a.cDefine8 as 请购员,v.cVenAbbName as 供应商简称,a.cCode as 入库单号
,case when ISNULL(a.cHandler ,'')<>'' then '审核' when isnull(a.iswfcontrolled,0)=1 and isnull(a.iverifystate ,0)=1 then '审核中' when ISNULL(a.cMaker,'')<>'' then '开立' end as 审批状态
,r.crdname as 入库类别,ic.cInvCName as 财务产品分类,i.cInvName as 品名简称,i.cInvStd as 规格型号,cFree1 as 包装,cBatch as 批号,convert(decimal(18, 3),b.iquantity) as 数量,cu.cComUnitName 单位
,a.cMemo as 入库备注,dis.cDCName as 区域,b.irowno as 行号,b.cInvCode as 物料编码,i.cInvName as 品名 
from RdRecord01 a inner join rdrecords01 b on a.ID = b.ID left join Inventory i on b.cInvCode=i.cInvCode left join Vendor v on a.cVenCode=v.cVenCode
left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode left join DistrictClass dis on v.cDCCode=dis.cDCCode
left join Warehouse w on a.cWhCode=w.cWhCode left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
left join Rd_Style r on a.cRdCode=r.cRdCode
where 1=1 ";
                    #endregion
                    #region 标题
                    if (QuantityFlag == 0)
                    {
                        this.Text = "采购入库数量明细";
                    }
                    else if (QuantityFlag == 1)
                    {
                        this.Text = "退货数量明细";
                    }
                    else
                    {
                        this.Text = "采购入库单明细";
                    }
                    #endregion
                }
                else if (Flag == "08")
                {
                    #region SQL
                    sSQL = @"select a.dDate as 入库日期, w.cWhName as 公司名称,ic.cInvCName as 财务产品分类,i.cInvName as 品名简称,i.cInvStd as 规格型号,cFree1 as 包装,r.crdname as 备货类别,a.cCode as 入库单号
,case when ISNULL(a.cHandler ,'')<>'' then '审核' when isnull(a.iswfcontrolled,0)=1 and isnull(a.iverifystate ,0)=1 then '审核中' when ISNULL(a.cMaker,'')<>'' then '开立' end as 审批状态
,r.crdname as 出库类别,cBatch as 批号,convert(decimal(18, 3),b.iquantity) as 数量,cu.cComUnitName 单位
,cBatchProperty6 as 物料标识或备注,cBatchProperty7 as 包装批号,cBatchProperty9 as 作业指导书
,a.dDate as 日期,b.cInvCode as 物料编码,i.cInvName as 品名
from RdRecord08 a inner join rdrecords08 b on a.ID = b.ID left join Inventory i on b.cInvCode=i.cInvCode 
left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode 
left join Warehouse w on a.cWhCode=w.cWhCode left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
left join Rd_Style r on a.cRdCode=r.cRdCode
where 1=1 ";
                    #endregion
                    #region 标题
                    this.Text = "其他入库单明细";
                    #endregion
                }
                else if (Flag == "09")
                {
                    #region SQL
                    sSQL = @"select a.dDate as 入库日期, w.cWhName as 公司名称,ic.cInvCName as 财务产品分类,i.cInvName as 品名简称,i.cInvStd as 规格型号,cFree1 as 包装,r.crdname as 备货类别,a.cCode as 入库单号
,case when ISNULL(a.cHandler ,'')<>'' then '审核' when isnull(a.iswfcontrolled,0)=1 and isnull(a.iverifystate ,0)=1 then '审核中' when ISNULL(a.cMaker,'')<>'' then '开立' end as 审批状态
,r.crdname as 出库类别,cBatch as 批号,convert(decimal(18, 3),b.iquantity) as 数量,cu.cComUnitName 单位
,cBatchProperty6 as 物料标识或备注,cBatchProperty7 as 包装批号,cBatchProperty9 as 作业指导书
,a.dDate as 日期,b.cInvCode as 物料编码,i.cInvName as 品名
from RdRecord09 a inner join rdrecords09 b on a.ID = b.ID left join Inventory i on b.cInvCode=i.cInvCode 
left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode 
left join Warehouse w on a.cWhCode=w.cWhCode left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
left join Rd_Style r on a.cRdCode=r.cRdCode
where 1=1 ";
                    #endregion
                    #region 标题
                    this.Text = "其他出库单明细";
                    #endregion
                }
                else if (Flag == "10")
                {
                    #region SQL
                    sSQL = @"select a.dDate as 入库日期, w.cWhName as 公司名称,ic.cInvCName as 财务产品分类,i.cInvName as 品名简称,i.cInvStd as 规格型号,cFree1 as 包装,r.crdname as 备货类别,a.cCode as 入库单号
,case when ISNULL(a.cHandler ,'')<>'' then '审核' when isnull(a.iswfcontrolled,0)=1 and isnull(a.iverifystate ,0)=1 then '审核中' when ISNULL(a.cMaker,'')<>'' then '开立' end as 审批状态
,r.crdname as 出库类别,cBatch as 批号,convert(decimal(18, 3),b.iquantity) as 数量,cu.cComUnitName 单位
,cBatchProperty6 as 物料标识或备注,cBatchProperty7 as 包装批号,cBatchProperty9 as 作业指导书
,dis.cDCName as 区域,v.cVenName as 客户,a.dDate as 日期,b.cInvCode as 物料编码,i.cInvName as 品名
from RdRecord10 a inner join rdrecords10 b on a.ID = b.ID left join Inventory i on b.cInvCode=i.cInvCode left join Vendor v on a.cVenCode=v.cVenCode
left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode left join DistrictClass dis on v.cDCCode=dis.cDCCode
left join Warehouse w on a.cWhCode=w.cWhCode left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
left join Rd_Style r on a.cRdCode=r.cRdCode
where 1=1 ";
                    #endregion
                    #region 标题
                    if (QuantityFlag == 0)
                    {
                        this.Text = "累计入库明细";
                    }
                    else if (QuantityFlag == 1)
                    {
                        this.Text = "累计退库明细";
                    }
                    else
                    {
                        this.Text = "产成品入库单明细";
                    }
                    #endregion
                }
                else if (Flag == "11")
                {
                    #region SQL
                    sSQL = @"select w.cWhName as 公司名称,d.cDepName as 领料部门,a.cDefine3 as 生产车间,p.cPersonName as 领料人员,a.cCode as 出库单号
,case when ISNULL(a.cHandler ,'')<>'' then '审核' when isnull(a.iswfcontrolled,0)=1 and isnull(a.iverifystate ,0)=1 then '审核中' when ISNULL(a.cMaker,'')<>'' then '开立' end as 审批状态
,r.crdname as 出库类别,ic.cInvCName as 财务产品分类,i.cInvName as 品名简称,i.cInvStd as 规格型号,cFree1 as 包装,cBatch as 批号,convert(decimal(18, 3),b.iquantity) as 数量,cu.cComUnitName 单位
,cBatchProperty6 as 物料标识或备注,cBatchProperty7 as 包装批号,cBatchProperty9 as 作业指导书
,dis.cDCName as 区域,c.cCusName as 客户,a.dDate as 日期,b.cInvCode as 物料编码,i.cInvName as 品名
from RdRecord11 a inner join rdrecords11 b on a.ID = b.ID left join Inventory i on b.cInvCode=i.cInvCode left join Customer c on a.cCusCode=c.cCusCode
left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode left join DistrictClass dis on c.cDCCode=dis.cDCCode
left join Warehouse w on a.cWhCode=w.cWhCode left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
left join Rd_Style r on a.cRdCode=r.cRdCode
where 1=1 ";
                    #endregion
                    #region 标题
                    if (QuantityFlag == 0)
                    {
                        this.Text = "累计领料明细";
                    }
                    else if (QuantityFlag == 1)
                    {
                        this.Text = "累计退库明细";
                    }
                    else
                    {
                        this.Text = "材料出库单明细";
                    }
                    #endregion
                }
                else if (Flag == "32")
                {
                    #region SQL
                    sSQL = @"select a.dDate as 单据日期,w.cWhName as 公司名称,p.cPersonName as 业务员,c.cCusName as 客户,a.cCode as 单号
,case when ISNULL(a.cHandler ,'')<>'' then '审核' when isnull(a.iswfcontrolled,0)=1 and isnull(a.iverifystate ,0)=1 then '审核中' when ISNULL(a.cMaker,'')<>'' then '开立' end as 审批状态
,ic.cInvCName as 财务产品分类,i.cInvName as 品名简称,i.cInvStd as 规格型号,cFree1 as 包装,cBatch as 批号,convert(decimal(18, 3),b.iquantity) as 数量,cu.cComUnitName 单位
,cBatchProperty6 as 物料标识或备注,cBatchProperty7 as 包装批号,cBatchProperty9 as 作业指导书
,d.cDepName as 部门,dis.cDCName as 区域,b.irowno as 行号,b.cInvCode as 物料编码,i.cInvName as 品名 --,convert(decimal(18, 2),b.iPrice) as 金额 
from RdRecord32 a inner join rdrecords32 b on a.ID = b.ID left join Inventory i on b.cInvCode=i.cInvCode left join Customer c on a.cCusCode=c.cCusCode
left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode left join DistrictClass dis on c.cDCCode=dis.cDCCode
left join Warehouse w on a.cWhCode=w.cWhCode left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
where 1=1 ";
                    #endregion
                    #region 标题
                    if (QuantityFlag == 0)
                    {
                        this.Text = "累计销售明细";
                    }
                    else if (QuantityFlag == 1)
                    {
                        this.Text = "累计退货明细";
                    }
                    else
                    {
                        this.Text = "销售出库单明细";
                    }
                    #endregion
                }
                if (cInvCode1 != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(i.cInvCode,'')>='" + cInvCode1 + "'");
                }
                if (cInvCode2 != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(i.cInvCode,'')<='" + cInvCode2 + "'");
                }
                if (sdate != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dDate,120)>='" + sdate + "'");
                }
                if (edate != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dDate,120)<='" + edate + "'");
                }
                if (cposname != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and cposname='" + cposname + "'");
                }
                if (cFree1 != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.cFree1='" + cFree1 + "'");
                }
                if (cFree3 != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.cFree3='" + cFree3 + "'");
                }
                if (cCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cCode='" + cCode + "'");
                }
                if (QuantityFlag == 0)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.iquantity>0");
                }
                else if (QuantityFlag == 1)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.iquantity<0");
                }
                sSQL = sSQL + " order by a.dDate";
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                gridControl1.DataSource = dt;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (gridView1.Columns[i].FieldName == "数量" || gridView1.Columns[i].FieldName == "金额")
                    {
                        gridView1.Columns[i].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });
                    }
                }
                if (cFree1 != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.cFree1='" + cFree1 + "'");
                }
                gridView1.OptionsBehavior.Editable = false;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败:" + ee.Message);
            }
        }

        public void 收发存汇总本期单据联查汇总(string cinvcode, string sdate, string edate, bool bcHandler, bool bcHas, string cFree3, string cFree4, string cWhCode, string cPosCode)
        {
            try
            {
                icinvcode = cinvcode;
                isdate = sdate;
                iedate = edate;
                ibcHandler = bcHandler;
                ibcHas = bcHas;
                icFree3 = cFree3;
                icFree4 = cFree4;
                icWhCode = cWhCode;
                icPosCode = cPosCode;
                New("cInvName", "品名");
                New("cInvStd", "型号");
                //New("cInvName", "日期");
                New("cRdName", "收发类别");
                New("计量单位", "计量单位");
                New("期初数量", "期初数量");
                New("总计入库数量", "入库数量");
                New("总计出库数量", "出库数量");
                New("期末数量", "期末数量");
                New("cVouchName", "单据类型");
                //New("cInvName", "单据备注");
                //New("cInvName", "供应商简称");
                //New("cInvName", "采购员");
                //New("cInvName", "客户简称");
                //New("cInvName", "销售业务员");
                //New("cInvName", "部门");
                New("cDefine3", "车间");
                //New("cInvName", "目标产品");

                this.Text = "收发存汇总本期单据联查汇总";
                数据源 sfc = new 数据源();
                DataTable dt = sfc.收发存汇总(Conn, cinvcode, cinvcode, sdate, edate, 3, bcHandler, bcHas, cFree3, cFree4, cWhCode, cPosCode, "", "");
                gridControl1.DataSource = dt;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (gridView1.Columns[i].FieldName == "总计入库数量" || gridView1.Columns[i].FieldName == "总计出库数量"
                        || gridView1.Columns[i].FieldName == "期初数量" || gridView1.Columns[i].FieldName == "期末数量")
                    {
                        gridView1.Columns[i].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });
                    }
                }
                gridView1.OptionsBehavior.Editable = false;
                gridView1.BestFitColumns();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败:" + ee.Message);
            }
        }

        public void 收发存汇总本期单据联查明细(string cinvcode, string sdate, string edate, bool bcHandler, bool bcHas, string cFree3, string cFree4, string cWhCode, string cPosCode, string cRdCode,string RdFlag)
        {
            try
            {
                New("cInvName", "品名");
                New("cInvStd", "型号");
                //New("cInvName", "日期");
                New("cRdName", "收发类别");
                New("cCode", "单据号");
                New("计量单位", "计量单位");
                //New("期初数量", "期初数量");
                New("总计入库数量", "入库数量");
                New("总计出库数量", "出库数量");
                //New("期末数量", "期末数量");
                New("cVouchName", "单据类型");
                //New("cInvName", "单据备注");
                //New("cInvName", "供应商简称");
                //New("cInvName", "采购员");
                //New("cInvName", "客户简称");
                //New("cInvName", "销售业务员");
                //New("cInvName", "部门");
                New("cDefine3", "车间");
                //New("cInvName", "目标产品");

                this.Text = "收发存汇总本期单据联查明细";
                数据源 sfc = new 数据源();
                DataTable dt = sfc.收发存汇总(Conn, cinvcode, cinvcode, sdate, edate, 2, bcHandler, bcHas, cFree3, cFree4, cWhCode, cPosCode, cRdCode, RdFlag);
                gridControl1.DataSource = dt;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (gridView1.Columns[i].FieldName == "总计入库数量" || gridView1.Columns[i].FieldName == "总计出库数量"
                        || gridView1.Columns[i].FieldName == "期初数量" || gridView1.Columns[i].FieldName == "期末数量")
                    {
                        gridView1.Columns[i].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });
                    }
                }
                gridView1.OptionsBehavior.Editable = false;
                gridView1.BestFitColumns();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败:" + ee.Message);
            }
        }

        public void 收发存汇总采购订单在途(string cInvCode, string sdate, string edate, bool bcHandler)
        {
            try
            {
                this.Text = "收发存汇总采购订单在途";
                string sSQL = @"select a.dDate as 订单日期,a.cDefine10 as 采购员,a.cDefine8 as 请购员,v.cCusAbbName as 客户简称,a.cSOCode as 订单号
,case when ISNULL(a.cVerifier ,'')<>'' then '审核' when isnull(a.iswfcontrolled,0)=1 and isnull(a.iverifystate ,0)=1 then '审核中' when ISNULL(a.cMaker,'')<>'' then '开立' end as 审批状态
,ic.cInvCName as 财务产品分类,i.cInvName as 品名简称,i.cInvStd as 规格型号,cFree1 as 包装,convert(decimal(18, 3),b.iquantity) as 数量,convert(decimal(18, 3),isnull(iQuantity,0)-isnull(finquantity ,0)) as 在途数量,cu.cComUnitName 单位
,a.cMemo as 入库备注,dis.cDCName as 区域,b.irowno as 行号,b.cInvCode as 物料编码,i.cInvName as 品名  
from SO_SOMain a left join SO_SODetails b on a.ID=b.ID
left join Inventory i on b.cInvCode=i.cInvCode left join Customer v on a.cCusCode =v.cCusCode
left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode left join DistrictClass dis on v.cDCCode=dis.cDCCode
left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
where isnull(iQuantity,0)-isnull(finquantity ,0)>0 and 1=1 ";
                if (cInvCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(i.cInvCode,'')='" + cInvCode + "'");
                }
                //if (sdate != "")
                //{
                //    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dDate,120)>='" + sdate + "'");
                //}
                //if (edate != "")
                //{
                //    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dDate,120)<='" + edate + "'");
                //}
                if (bcHandler == true)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(cVerifier ,'')<>''");
                }
                else
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(cVerifier ,'')=''");
                }
                sSQL = sSQL + " order by a.dDate";
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                gridControl1.DataSource = dt;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (gridView1.Columns[i].FieldName == "数量" || gridView1.Columns[i].FieldName == "含税金额")
                    {
                        gridView1.Columns[i].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });
                    }
                }
                gridView1.OptionsBehavior.Editable = false;
                gridView1.BestFitColumns();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败:" + ee.Message);
            }
        }

        private void New(string FieldName, string Caption)
        {
            GridColumn Col = new GridColumn();
            Col.FieldName = FieldName;
            Col.Caption = Caption;
            Col.Visible = true;
            Col.VisibleIndex = gridView1.Columns.Count;
            gridView1.Columns.Add(Col);
        }

        
        private void Frm明细_Load(object sender, EventArgs e)
        {
            try
            {
                系统服务.规格化.GetGridViewSet(gridView1);
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得销售出库单明细信息失败！  " + ee.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (this.Text == "收发存汇总本期单据联查汇总")
            {
                try
                {
                    string Caption = gridView1.FocusedColumn.FieldName;
                    int iRow = gridView1.FocusedRowHandle;
                    if (iRow < 0)
                        return;
                    string cRdCode = gridView1.GetRowCellValue(iRow, "cRdCode").ToString();
                    Frm明细 frm = new Frm明细(Conn);
                    frm.收发存汇总本期单据联查明细(icinvcode, isdate, iedate, ibcHandler, ibcHas, icFree3, icFree4, icWhCode, icPosCode, cRdCode,"");
                    frm.Show();
                    if (DialogResult.OK == frm.ShowDialog())
                    {
                        frm.Enabled = true;
                    }
                }
                catch (Exception ee)
                { }
            }
        }
    }
}