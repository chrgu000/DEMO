using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.BandedGrid;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class Frm明细多表头 : Form
    {

        public void 应付账款采购入库在途(string cVenCode,string sdate,string edate)
        {
            try
            {
                New("", new string[,]{
                     {"供应商简称","供应商简称"}
                });
                New("采购入库单", new string[,]{
                     {"入库日期","入库日期"}
                    ,{"入库单号","入库单号"}
                    ,{"物料名称","品名"}
                    ,{"规格型号","规格型号"}
                    ,{"入库数量","数量"}
                    ,{"含税单价","单价"}
                    ,{"暂估金额","暂估金额"}
                });
                New("关联单据", new string[,]{
                     {"采购订单号","采购订单号"}
                    ,{"请购单号","请购单号"}
                });
                New("采购发票", new string[,]{
                     {"采购发票日期","日期"}
                    ,{"采购发票号","单据号"}
                    ,{"采购发票数量","数量"}
                    ,{"采购发票含税单价","含税单价"}
                    ,{"采购发票价税合计","价税合计"}
                });

                this.Text = "应付账款采购入库在途";
                string sSQL = @"select a.dDate as 入库日期,w.cWhName as 公司名称,a.cDefine10 as 采购员,a.cDefine8 as 请购员,v.cVenAbbName as 供应商简称,a.cCode as 入库单号
,case when ISNULL(a.cHandler ,'')<>'' then '审核' when isnull(a.iswfcontrolled,0)=1 and isnull(a.iverifystate ,0)=1 then '审核中' when ISNULL(a.cMaker,'')<>'' then '开立' end as 审批状态
,r.crdname as 入库类别,ic.cInvCName as 财务产品分类,i.cInvAddCode as 品名简称,i.cInvStd as 规格型号,b.cFree1 as 包装,cBatch as 批号,convert(decimal(18, 3),b.iquantity) as 数量,cu.cComUnitName 单位
,a.cMemo as 入库备注,dis.cDCName as 区域,b.irowno as 行号,b.cInvCode as 物料编码,i.cInvName as 品名 ,iUnitCost as 单价,iAPrice as 暂估金额 ,pp.cPOID as 采购订单号,pp.cappcode as 请购单号
,pb.dPBVDate as 采购发票日期,pb.cPBVCode as 采购发票号,pbs.iPBVQuantity as 采购发票数量,pbs.iCost as 采购发票含税单价,pbs.iSum as 采购发票价税合计
from RdRecord01 a inner join rdrecords01 b on a.ID = b.ID left join Inventory i on b.cInvCode=i.cInvCode left join Vendor v on a.cVenCode=v.cVenCode
left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode left join DistrictClass dis on v.cDCCode=dis.cDCCode
left join Warehouse w on a.cWhCode=w.cWhCode left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
left join Rd_Style r on a.cRdCode=r.cRdCode
left join PO_Podetails pps on b.iPOsID=pps.ID left join PO_Pomain pp on pp.POID =pps.POID 
left join PurBillVouchs pbs on pbs.RdsId =b.AutoID left join PurBillVouch pb on pb.PBVID=pbs.PBVID
where 1=1 and b.iquantity>0";
                if (cVenCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cVenCode='" + cVenCode + "'");
                }
                if (sdate != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dDate,120)>='" + sdate + "'");
                }
                if (edate != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dDate,120)<='" + edate + "'");
                }
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                gridControl1.DataSource = dt;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (gridView1.Columns[i].FieldName == "入库数量" || gridView1.Columns[i].FieldName == "暂估金额")
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

        public void 应付账款采购订单在途(string cVenCode, string sdate, string edate)
        {
            try
            {
                New("", new string[,]{
                     {"供应商简称","供应商简称"}
                });
                New("采购订单", new string[,]{
                     {"订单日期","订单日期"}
                    ,{"订单号","订单号"}
                    ,{"物料名称","品名"}
                    ,{"规格型号","规格型号"}
                    ,{"数量","数量"}
                    ,{"含税单价","含税单价"}
                    ,{"含税金额","含税金额"}
                });
                New("关联单据", new string[,]{
                     {"请购单号","请购单号"}
                    ,{"请购数量","请购数量"}
                });
                New("采购入库单", new string[,]{
                     {"采购入库单入库日期","日期"}
                    ,{"采购入库单入库单号","单据号"}
                    ,{"采购入库单数量","数量"}
                    ,{"采购入库单单价","含税单价"}
                    ,{"采购入库单含税金额","价税合计"}
                });

                this.Text = "应付账款采购订单在途";
                string sSQL = @"select a.dPODate as 订单日期,w.cWhName as 公司名称,a.cDefine10 as 采购员,a.cDefine8 as 请购员,v.cVenAbbName as 供应商简称,a.cPOID as 订单号
,ic.cInvCName as 财务产品分类,i.cInvAddCode as 品名简称,i.cInvStd as 规格型号,b.cFree1 as 包装,cBatch as 批号,convert(decimal(18, 3),b.iquantity) as 数量,cu.cComUnitName 单位
,a.cMemo as 入库备注,dis.cDCName as 区域,b.irowno as 行号,b.cInvCode as 物料编码,i.cInvName as 品名 ,iUnitCost as 含税单价,iAPrice as 含税金额 
,pa.cCode  as 请购单号,pas.fQuantity as 请购数量
,rd.dDate 采购入库单入库日期,rd.cCode as 采购入库单入库单号,convert(decimal(18, 3),b.iquantity) as 采购入库单数量,iUnitCost as 采购入库单单价,iAPrice as 采购入库单含税金额
from PO_Pomain a inner join PO_Podetails b on a.POID = b.POID left join Inventory i on b.cInvCode=i.cInvCode left join Vendor v on a.cVenCode=v.cVenCode
left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode left join DistrictClass dis on v.cDCCode=dis.cDCCode
left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
left join rdrecords01 rds on rds.iPOsID=b.ID left join RdRecord01 rd on rd.ID =rds.ID  left join Warehouse w on rd.cWhCode=w.cWhCode 
left join PU_AppVouchs pas on b.iAppIds =pas.AutoID left join PU_AppVouch pa on pa.ID =pas.ID 
where 1=1 and b.iquantity>0";
                if (cVenCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cVenCode='" + cVenCode + "'");
                }
                if (sdate != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dPODate,120)>='" + sdate + "'");
                }
                if (edate != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dPODate,120)<='" + edate + "'");
                }
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                gridControl1.DataSource = dt;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (gridView1.Columns[i].FieldName == "入库数量" || gridView1.Columns[i].FieldName == "暂估金额")
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

        public void 应付账款采购发票(string cVenCode, string sdate, string edate)
        {
            try
            {
                New("", new string[,]{
                     {"供应商简称","供应商简称"}
                });
                New("采购发票", new string[,]{
                     {"日期","日期"}
                    ,{"订单号","订单号"}
                    ,{"存货名称","存货名称"}
                    ,{"规格型号","规格型号"}
                    ,{"数量","数量"}
                    ,{"含税单价","含税单价"}
                    ,{"含税金额","含税金额"}
                });
                New("关联采购入库单", new string[,]{
                     {"采购入库单入库日期","日期"}
                    ,{"采购入库单入库单号","单据号"}
                    ,{"采购入库单数量","数量"}
                    ,{"采购入库单单价","含税单价"}
                    ,{"采购入库单含税金额","价税合计"}
                });
                New("", new string[,]{
                     {"销售部门","销售部门"}
                });
                New("", new string[,]{
                     {"业务员","业务员"}
                });
                New("", new string[,]{
                     {"公司名称","公司名称"}
                });
                this.Text = "应付账款采购订单在途";
                string sSQL = @"select a.dPBVDate as 日期,d.cDepName as 销售部门,w.cWhName as 公司名称,a.cDefine10 as 业务员,a.cDefine8 as 请购员,v.cVenAbbName as 供应商简称,a.cPBVCode as 单据号
,ic.cInvCName as 财务产品分类,i.cInvAddCode as 品名简称,i.cInvStd as 规格型号,b.cFree1 as 包装,cBatch as 批号,convert(decimal(18, 3),b.iPBVQuantity) as 数量,cu.cComUnitName 单位
,dis.cDCName as 区域,b.cInvCode as 存货编码,i.cInvName as 品名 ,iUnitCost as 含税单价,iAPrice as 含税金额 
,rd.dDate 采购入库单入库日期,rd.cCode as 采购入库单入库单号,convert(decimal(18, 3),rds.iquantity) as 采购入库单数量,iUnitCost as 采购入库单单价,iAPrice as 采购入库单含税金额
from PurBillVouch a inner join PurBillVouchs b on a.PBVID = b.PBVID left join Inventory i on b.cInvCode=i.cInvCode left join Vendor v on a.cVenCode=v.cVenCode
left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode left join DistrictClass dis on v.cDCCode=dis.cDCCode
left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
left join rdrecords01 rds on rds.iPOsID=b.ID left join RdRecord01 rd on rd.ID =rds.ID  left join Warehouse w on rd.cWhCode=w.cWhCode 
where 1=1 ";
                if (cVenCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cVenCode='" + cVenCode + "'");
                }
                if (sdate != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dPBVDate,120)>='" + sdate + "'");
                }
                if (edate != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dPBVDate,120)<='" + edate + "'");
                }
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                gridControl1.DataSource = dt;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (gridView1.Columns[i].FieldName == "入库数量" || gridView1.Columns[i].FieldName == "暂估金额")
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

        public void 应付账款采购付款(string cVenCode, string sdate, string edate)
        {
            try
            {
                New("", new string[,]{
                     {"供应商简称","供应商简称"}
                });
                New("采购发票", new string[,]{
                     {"日期","日期"}
                    ,{"订单号","订单号"}
                    ,{"存货名称","存货名称"}
                    ,{"规格型号","规格型号"}
                    ,{"数量","数量"}
                    ,{"含税单价","含税单价"}
                    ,{"含税金额","含税金额"}
                });
                New("关联采购入库单", new string[,]{
                     {"采购入库单入库日期","日期"}
                    ,{"采购入库单入库单号","单据号"}
                    ,{"采购入库单数量","数量"}
                    ,{"采购入库单单价","含税单价"}
                    ,{"采购入库单含税金额","价税合计"}
                });
                New("", new string[,]{
                     {"销售部门","销售部门"}
                });
                New("", new string[,]{
                     {"业务员","业务员"}
                });
                New("", new string[,]{
                     {"公司名称","公司名称"}
                });
                this.Text = "应付账款采购订单在途";
                string sSQL = @"select a.dPBVDate as 日期,d.cDepName as 销售部门,w.cWhName as 公司名称,a.cDefine10 as 业务员,a.cDefine8 as 请购员,v.cVenAbbName as 供应商简称,a.cPBVCode as 单据号
,ic.cInvCName as 财务产品分类,i.cInvAddCode as 品名简称,i.cInvStd as 规格型号,b.cFree1 as 包装,cBatch as 批号,convert(decimal(18, 3),b.iPBVQuantity) as 数量,cu.cComUnitName 单位
,dis.cDCName as 区域,b.cInvCode as 存货编码,i.cInvName as 品名 ,iUnitCost as 含税单价,iAPrice as 含税金额 
,rd.dDate 采购入库单入库日期,rd.cCode as 采购入库单入库单号,convert(decimal(18, 3),rds.iquantity) as 采购入库单数量,iUnitCost as 采购入库单单价,iAPrice as 采购入库单含税金额
from PurBillVouch a inner join PurBillVouchs b on a.PBVID = b.PBVID left join Inventory i on b.cInvCode=i.cInvCode left join Vendor v on a.cVenCode=v.cVenCode
left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode left join DistrictClass dis on v.cDCCode=dis.cDCCode
left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
left join rdrecords01 rds on rds.iPOsID=b.ID left join RdRecord01 rd on rd.ID =rds.ID  left join Warehouse w on rd.cWhCode=w.cWhCode 
where 1=1 ";
                if (cVenCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cVenCode='" + cVenCode + "'");
                }
                if (sdate != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dPBVDate,120)>='" + sdate + "'");
                }
                if (edate != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dPBVDate,120)<='" + edate + "'");
                }
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                gridControl1.DataSource = dt;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (gridView1.Columns[i].FieldName == "入库数量" || gridView1.Columns[i].FieldName == "暂估金额")
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

        public void 应收账款销售发货在途(string cCusCode, string sdate, string edate)
        {
            try
            {
                New("", new string[,]{
                     {"客户简称","客户简称"}
                });
                New("采购入库单", new string[,]{
                     {"发货日期","发货日期"}
                    ,{"发货单号","发货单号"}
                    ,{"物料名称","品名"}
                    ,{"规格型号","规格型号"}
                    ,{"数量","数量"}
                    ,{"含税单价","单价"}
                    ,{"暂估金额","暂估金额"}
                });
                New("销售发票", new string[,]{
                     {"销售发票日期","日期"}
                    ,{"销售发票号","单据号"}
                    ,{"销售发票数量","数量"}
                    ,{"销售发票含税单价","含税单价"}
                    ,{"销售发票价税合计","价税合计"}
                });

                this.Text = "应收账款销售发货在途";
                string sSQL = @"select a.dDate as 发货日期,a.cDefine10 as 采购员,a.cDefine8 as 请购员,c.cCusAbbName as 客户简称,a.cDLCode as 发货单号
,case when ISNULL(a.cVerifier ,'')<>'' then '审核' when isnull(a.iswfcontrolled,0)=1 and isnull(a.iverifystate ,0)=1 then '审核中' when ISNULL(a.cMaker,'')<>'' then '开立' end as 审批状态
,r.crdname as 入库类别,ic.cInvCName as 财务产品分类,i.cInvAddCode as 品名简称,i.cInvStd as 规格型号,b.cFree1 as 包装,b.cBatch as 批号,convert(decimal(18, 3),b.iquantity) as 数量,cu.cComUnitName 单位
,a.cMemo as 入库备注,dis.cDCName as 区域,b.irowno as 行号,b.cInvCode as 物料编码,i.cInvName as 品名 ,b.iNatSum/b.iQuantity as 单价,b.iNatSum as 暂估金额 
,fp.dDate as 销售发票日期,fp.cSBVCode as 销售发票号,fps.iQuantity as 销售发票数量,fps.iNatSum/fps.iQuantity as 销售发票含税单价,fps.iSum as 销售发票价税合计
from DispatchList a inner join DispatchLists b on a.DLID = b.DLID left join Inventory i on b.cInvCode=i.cInvCode left join Customer c on a.cCusCode=c.cCusCode
left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode left join DistrictClass dis on c.cDCCode=dis.cDCCode
left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
left join Rd_Style r on a.cRdCode=r.cRdCode
left join SO_SODetails dds on b.iSOsID=dds.ID left join SO_SOMain dd on dd.ID  =dds.ID  
left join SaleBillVouchs fps on fps.RdsId =b.AutoID left join SaleBillVouch fp on fp.SBVID=fps.SBVID
where 1=1 and b.iquantity>0";
                if (cCusCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cVenCode='" + cCusCode + "'");
                }
                if (sdate != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dDate,120)>='" + sdate + "'");
                }
                if (edate != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dDate,120)<='" + edate + "'");
                }
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                gridControl1.DataSource = dt;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (gridView1.Columns[i].FieldName == "入库数量" || gridView1.Columns[i].FieldName == "暂估金额")
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

        public void 应收账款销售发票单在途(string cCusCode, string sdate, string edate)
        {
            try
            {
                New("", new string[,]{
                     {"客户简称","客户简称"}
                });
                New("销售发票", new string[,]{
                     {"发票日期","日期"}
                    ,{"订单号","订单号"}
                    ,{"物料名称","品名"}
                    ,{"规格型号","规格型号"}
                    ,{"数量","数量"}
                    ,{"含税单价","含税单价"}
                    ,{"含税金额","含税金额"}
                });
                New("关联单据", new string[,]{
                     {"请购单号","请购单号"}
                    ,{"请购数量","请购数量"}
                });
                New("采购入库单", new string[,]{
                     {"采购入库单入库日期","日期"}
                    ,{"采购入库单入库单号","单据号"}
                    ,{"采购入库单数量","数量"}
                    ,{"采购入库单单价","含税单价"}
                    ,{"采购入库单含税金额","价税合计"}
                });

                this.Text = "应收账款销售发票单在途";
                string sSQL = @"
//select a.dPODate as 发票日期,w.cWhName as 公司名称,a.cDefine10 as 采购员,a.cDefine8 as 请购员,v.cVenAbbName as 供应商简称,a.cPOID as 订单号
//,ic.cInvCName as 财务产品分类,i.cInvAddCode as 品名简称,i.cInvStd as 规格型号,b.cFree1 as 包装,cBatch as 批号,convert(decimal(18, 3),b.iquantity) as 数量,cu.cComUnitName 单位
//,a.cMemo as 入库备注,dis.cDCName as 区域,b.irowno as 行号,b.cInvCode as 物料编码,i.cInvName as 品名 ,iUnitCost as 含税单价,iAPrice as 含税金额 
//,pa.cCode  as 请购单号,pas.fQuantity as 请购数量
//,rd.dDate 采购入库单入库日期,rd.cCode as 采购入库单入库单号,convert(decimal(18, 3),b.iquantity) as 采购入库单数量,iUnitCost as 采购入库单单价,iAPrice as 采购入库单含税金额
//from PO_Pomain a inner join PO_Podetails b on a.POID = b.POID left join Inventory i on b.cInvCode=i.cInvCode left join Vendor v on a.cVenCode=v.cVenCode
//left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode left join DistrictClass dis on v.cDCCode=dis.cDCCode
//left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
//left join rdrecords01 rds on rds.iPOsID=b.ID left join RdRecord01 rd on rd.ID =rds.ID  left join Warehouse w on rd.cWhCode=w.cWhCode 
//left join PU_AppVouchs pas on b.iAppIds =pas.AutoID left join PU_AppVouch pa on pa.ID =pas.ID 
//where 1=1 and b.iquantity>0
";
                if (cCusCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cCusCode='" + cCusCode + "'");
                }
                if (sdate != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dPODate,120)>='" + sdate + "'");
                }
                if (edate != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dPODate,120)<='" + edate + "'");
                }
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                gridControl1.DataSource = dt;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (gridView1.Columns[i].FieldName == "入库数量" || gridView1.Columns[i].FieldName == "暂估金额")
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

        private void New(string Caption, string[,] col)
        {
            GridBand b1 = NewBand(Caption);
            for (int i = 0; i < col.Length / 2; i++)
            {
                NewCol(b1, col[i, 0], col[i, 1]);
            }
        }

        private GridBand NewBand(string Caption)
        {
            GridBand b = new GridBand();
            b.Caption = Caption;
            b.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Bands.Add(b);
            return b;
        }

        private void NewCol(GridBand b, string FieldName, string Caption)
        {
            BandedGridColumn Col = new BandedGridColumn();
            Col.FieldName = FieldName;
            Col.Caption = Caption;
            Col.Width = 75;
            Col.Visible = true;
            Col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            b.Columns.Add(Col);
        }

        public string Conn { get; set; }

        public Frm明细多表头(string conn)
        {
            InitializeComponent();
            Conn = conn;
        }
        
        private void Frm明细多表头_Load(object sender, EventArgs e)
        {
            try
            {
                系统服务.规格化.GetGridViewSet(gridView1);
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得明细信息失败！  " + ee.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}