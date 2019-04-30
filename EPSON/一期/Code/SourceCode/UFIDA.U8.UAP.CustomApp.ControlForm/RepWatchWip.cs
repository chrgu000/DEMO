using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TH.BaseClass;
using System.Data.SqlClient;
using DevExpress.XtraReports.UI;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class RepWatchWip : UserControl
    {
        TH.BaseClass.GetBaseData getBaseData = new GetBaseData();

        UFIDA.U8.UAP.CustomApp.ControlForm.RepBaseGrid Rep = new RepBaseGrid();

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        string sProPath = Application.StartupPath;
        string sPrintLayOutMod = Application.StartupPath + "\\UAP\\Runtime\\print\\BarLabel1.dll";


        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                DbHelperSQL.connectionString = Conn;

                SetLookUp();
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        public RepWatchWip()
        {
            InitializeComponent();
        }

        private void GetGrid()
        {
          
           
        }
      
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            try
            {
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                if (e.Info.IsRowIndicator)
                {
                    if (e.RowHandle >= 0)
                    {
                        e.Info.DisplayText = (e.RowHandle + 1).ToString();
                    }
                    else if (e.RowHandle < 0 && e.RowHandle > -1000)
                    {
                        e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
                        e.Info.DisplayText = "G" + e.RowHandle.ToString();
                    }
                }
            }
            catch { }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dtm1 = BaseFunction.ReturnDate(lookUpEditYear.EditValue.ToString() + "-" + lookUpEditMonth.EditValue.ToString() + "-01");
                DateTime dtm2 = BaseFunction.ReturnDate(lookUpEditYear.EditValue.ToString() + "-" + lookUpEditMonth.EditValue.ToString() + "-01").AddMonths(1);

                string sSQL = @"

declare @dtm1 datetime
declare @dtm2 datetime 
declare @dtm3 datetime 

set @dtm1 = 'aaaaaa'
set @dtm2 = 'bbbbbb'	
set @dtm3 = 'cccccc'


IF OBJECT_ID('tempdb..#Rep') is not null
	drop table #Rep
IF OBJECT_ID('tempdb..#Rep2') is not null
	drop table #Rep2
IF OBJECT_ID('tempdb..#Rep3') is not null
	drop table #Rep3
IF OBJECT_ID('tempdb..#Cus') is not null
	drop table #Cus

	
IF OBJECT_ID('tempdb..#Price') is not null
	drop table #Price


select a.cInvCode,cast(a.iUnitPrice as decimal(16,5)) AS AvgPrice
into #Price
from IA_Summary a inner join 
(
	select max(AutoID) as Autoid,cInvCode
	from IA_Summary
	where isnull(iUnitPrice ,0) <> 0
	group by cInvCode
)b on a.AutoID = b.Autoid


-- 期初数据
select a.cCusCode ,a.cInvCode
	,a.BalanceQty as OpeningQty
	,cast(null as decimal(16,3)) as RecQty
	,cast(null as decimal(16,3)) as IssQty
	,cast(null as decimal(16,3)) as AdjQty
	,cast(null as decimal(16,3)) as BalanceQty
	,cast(null as decimal(16,3)) as RejQty
	,cast(null as varchar(50)) as cVenCode
	,null as ID
	,null as ParentID
    ,PurchaseCurr
into #Rep
from _RepWIP a
	inner join Inventory i on a.cInvCode = i.cInvCode
where dDate = @dtm3 and 1=1

-- 本月入库
insert into #Rep
select cCusCode,a.cInvCode
	,cast(null as decimal(16,3)) as OpeningQty
	,sum(iQtyIn)  as RecQty
	,cast(null as decimal(16,3)) as IssQty
	,cast(null as decimal(16,3)) as AdjQty
	,cast(null as decimal(16,3)) as BalanceQty
	,cast(null as decimal(16,3)) as RejQty
	,a.cVenCode as cVenCode
	,null as ID
	,null as ParentID
    ,a.cexch_name as PurchaseCurr
from
(
	--其他入库
	select a.cCusCode,rds08.cInvCode,sum(rds08.iquantity) as iQtyIn,null as cVenCode,a.cexch_name
	from RdRecord08 rd08 inner join Rdrecords08 rds08 on rd08.ID = rds08.ID
		left join SO_SODetails b on b.iSOsID =  rds08.isodid
		left join SO_SOMain a on a.ID = b.id
		inner join Inventory i on i.cInvCode = rds08.cInvCode
	where isnull(a.cCusCode,'') <> '' and rd08.dDate >= @dtm1 and rd08.dDate < @dtm2
        and rd08.cRdCode in (select cRdCode from _systemset)
		and 1=1
	group by a.cCusCode,rds08.cInvCode,a.cexch_name
	union
	--采购入库
	select a.cCusCode,b.cInvCode,sum(rds.iQuantity) as iQtyIn,d.cVenCode,a.cexch_name
	from Rdrecord01 rd inner join RdRecords01 rds on rd.id = rds.id
		inner join PO_Podetails c on rds.iPOsID = c.ID
		inner join PO_Pomain d on c.POID = d.POID
		inner join SO_SODetails b on b.iSOsID =  c.iorderdid
		inner join SO_SOMain a on a.ID = b.id
		inner join Inventory i on i.cInvCode = rds.cInvCode
	where rd.dDate >= @dtm1 and rd.dDate < @dtm2
		and isnull(a.cCusCode,'') <> ''
		and 1=1
	group by a.cCusCode,b.cInvCode ,d.cVenCode,a.cexch_name
) a
	inner join Inventory i on a.cInvCode = i.cInvCode
where 1=1 
group by cCusCode,a.cInvCode ,a.cexch_name,a.cVenCode


-- AdjQty
insert into #Rep
select a.cCusCode,b.cInvCode
	,cast(null as decimal(16,3)) as OpeningQty
	,cast(null as decimal(16,3)) as RecQty
	,cast(null as decimal(16,3))  as IssQty
	,case when i.cInvCCode = 'WP'then sum(b.iQuantity - case when ISNULL(c.cbdefine4,0) = 0 then b.iQuantity else ISNULL(c.cbdefine4,0) end ) 
		  else null end as AdjQty
	,cast(null as decimal(16,3)) as BalanceQty
	,cast(null as decimal(16,3)) as RejQty
	,cast(null as varchar(50)) as cVenCode
	,null as ID
	,null as ParentID
    ,a.cexch_name as PurchaseCurr
from DispatchList a inner join DispatchLists b on a.DLID = b.DLID
	left join [dbo].[DispatchLists_extradefine] c on b.iDLsID = c.iDLsID
	inner join Inventory i on b.cInvCode = i.cInvCode
where 1=1 and a.dDate >= @dtm1 and a.dDate < @dtm2
group by a.cCusCode,b.cInvCode,a.cexch_name,i.cInvCCode


-- 发货
insert into #Rep 
select cCusCode,a.cInvCode
	,cast(null as decimal(16,3)) as OpeningQty
	,cast(null as decimal(16,3))  as RecQty
	,cast(sum(iQtyIn) as decimal(16,3)) as IssQty
	,cast(null as decimal(16,3)) as AdjQty
	,cast(null as decimal(16,3)) as BalanceQty
	,cast(null as decimal(16,3)) as RejQty
	,a.cVenCode
	,null as ID
	,null as ParentID
    ,a.cexch_name as PurchaseCurr
from
(
	----其他入库
	--select a.cCusCode,rds08.cInvCode,sum(rds08.iquantity) as iQtyIn,null as cVenCode,a.cexch_name
	--from RdRecord08 rd08 inner join Rdrecords08 rds08 on rd08.ID = rds08.ID
	--	left join (select distinct max(iSOsID) as iSOsID,Batch,cInvCode from [dbo].[_BarCodeLabel] group by Batch,cInvCode) bar on bar.Batch = rds08.cBatch and bar.cInvCode = rds08.cInvCode
	--	left join SO_SODetails b on b.iSOsID =  bar.iSOsID
	--	left join SO_SOMain a on a.ID = b.id
	--	inner join Inventory i on i.cInvCode = rds08.cInvCode
	--	inner join Warehouse w on rd08.cWhCode = w.cWhCode 
	--where isnull(a.cCusCode,'') <> '' and rd08.dDate >= @dtm1 and rd08.dDate < @dtm2
	--	and 1=1 and 2=2
	--	and w.cWhMemo like '%f%'
	--group by a.cCusCode,rds08.cInvCode,a.cexch_name
	--union
	----采购入库
	--select a.cCusCode,b.cInvCode,sum(rds.iQuantity) as iQtyIn,d.cVenCode,a.cexch_name
	--from Rdrecord01 rd inner join RdRecords01 rds on rd.id = rds.id
	--	inner join PO_Podetails c on rds.iPOsID = c.ID
	--	inner join PO_Pomain d on c.POID = d.POID
	--	inner join SO_SODetails b on b.iSOsID = c.iorderdid 
	--	inner join SO_SOMain a on a.ID = b.id
	--	inner join Inventory i on i.cInvCode = rds.cInvCode
	--	inner join Warehouse w on rd.cWhCode = w.cWhCode 
	--where rd.dDate >= @dtm1 and rd.dDate < @dtm2
	--	and 1=1 and 2=2
	--	and w.cWhMemo like '%f%'
	--group by a.cCusCode,b.cInvCode ,d.cVenCode,a.cexch_name

	select a.cCusCode,b.cInvCode,sum( b.iQuantity) as iQtyIn,null as cVenCode,a.cexch_name
	from DispatchList a inner join DispatchLists b on a.DLID = b.DLID
		--inner join PO_Podetails c on rds.iPOsID = c.ID
		--inner join PO_Pomain d on c.POID = d.POID
		inner join Inventory i on i.cInvCode = b.cInvCode
		inner join Warehouse w on b.cWhCode = w.cWhCode 
	where a.dDate >= @dtm1 and a.dDate < @dtm2
		and 1=1 and 2=2
		and w.cWhMemo like '%f%'
	group by a.cCusCode,b.cInvCode ,a.cexch_name 
) a
	inner join Inventory i on a.cInvCode = i.cInvCode
where 1=1 
group by cCusCode,a.cInvCode ,a.cVenCode,a.cexch_name,a.cVenCode

insert into #Rep
select a.cCusCode,rds32.cInvCode
	,cast(null as decimal(16,3)) as OpeningQty
	,cast(null as decimal(16,3)) as RecQty
	,cast(null as decimal(16,3)) as IssQty
	,cast(null as decimal(16,3))  as AdjQty
	,cast(null as decimal(16,3)) as BalanceQty
	,sum(rds32.iquantity) as RejQty
	,cast(null as varchar(50)) as cVenCode
	,null as ID
	,null as ParentID
    ,a.cexch_name as PurchaseCurr
from RdRecord32 rd32 inner join Rdrecords32 rds32 on rd32.ID = rds32.ID
	inner join Warehouse w on rd32.cWhCode = w.cWhCode
	inner join SO_SODetails b on b.iSOsID = rds32.iorderdid
	inner join SO_SOMain a on a.id = b.ID
	inner join Inventory i on b.cInvCode = i.cInvCode
WHERE cWhMemo LIKE '%r%'
	and rd32.dDate >= @dtm1 and rd32.dDate < @dtm2
	and 1=1
group by a.cCusCode,rds32.cInvCode,a.cexch_name

select a.cCusCode,cus.cCusName,cus.cCusAbbName
	,a.cInvCode as ItemNo,i.cInvName,i.cInvStd
	,max(a.cVenCode) as cVenCode
	,sum(OpeningQty) as OpeningQty
	,sum(RecQty) as RecQty
	,sum(IssQty) as IssQty
	,sum(AdjQty) as AdjQty
	,sum(BalanceQty) as BalanceQty
	,sum(RejQty) as RejQty
	,cast(NULL as decimal(16,3)) as OpeningAmt													--金额（有的仓库是不记成本的）
	,cast(NULL as decimal(16,3)) as RecAmt														--本月入库金额
	,cast(NULL as decimal(16,3)) as IssAmt														--本月发货金额
	,cast(NULL as decimal(16,3)) as AdjAmt														--调整金额
	,cast(NULL as decimal(16,3)) as RejAmt														--次品金额
	,cast(NULL as decimal(16,3)) as BalanceAmt														--
	,cast(b.AvgPrice as decimal(16,3)) as AvgPrice
    ,a.PurchaseCurr
into #Rep2
from #Rep a
	left join #Price b on a.cInvCode = b.cInvCode
	left join Inventory i on i.cInvCode = a.cInvCode
	left join Customer cus on cus.cCusCode = a.cCusCode
--where a.cCusCode = '90722'
group by a.cCusCode,cus.cCusName,cus.cCusAbbName,a.cInvCode,i.cInvName,i.cInvStd,b.AvgPrice,a.PurchaseCurr

UPDATE #Rep2 SET BalanceQty = isnull(OpeningQty,0) + isnull(RecQty,0) - isnull(IssQty,0) + isnull(AdjQty,0) - isnull(RejQty,0)
	,OpeningAmt = OpeningQty * AvgPrice
	,RecAmt = RecQty * AvgPrice
	,IssAmt = IssQty * AvgPrice
	,AdjAmt = AdjQty * AvgPrice
	,RejAmt = RejQty * AvgPrice
	,BalanceAmt = (isnull(OpeningQty,0) + isnull(RecQty,0) - isnull(IssQty,0) + isnull(AdjQty,0) - isnull(RejQty,0)) * AvgPrice


delete _RepWIP where dDate = @dtm1 and cCusCode in (select distinct cCusCode from #Rep2)

insert into _RepWIP(dDate, cCusCode, cInvCode, BalanceQty,PurchaseCurr)
select @dtm1,cCusCode,ItemNo,BalanceQty,PurchaseCurr
from #Rep2
where isnull(ItemNo,'') <> ''

	
select  IDENTITY(INT,1,1) as ID,null as ParentID,null as ID2
	,cCusCode,cCusName,cCusAbbName,cast(null as varchar(100)) as ItemNo,cast(null as varchar(100)) as cInvName,cast(null as varchar(100)) as cInvStd,cast(null as varchar(100)) as cVenCode 
	,sum(OpeningQty) as OpeningQty
	,sum(RecQty) as RecQty
	,sum(IssQty) as IssQty
	,sum(AdjQty) as AdjQty
	,sum(BalanceQty) as BalanceQty
	,sum(RejQty) as RejQty
	,sum(OpeningAmt) as OpeningAmt
	,sum(RecAmt) as RecAmt
	,sum(IssAmt) as IssAmt
	,sum(AdjAmt) as AdjAmt
	,sum(RejAmt) as RejAmt
	,sum(BalanceAmt) as BalanceAmt
	,cast(null as decimal(16,5)) as AvgPrice
    ,PurchaseCurr
into #Cus
from #Rep2
group by cCusCode,cCusName,cCusAbbName,PurchaseCurr

update #Cus set ParentID = ID, ID2 = ID + 1000000000



INSERT INTO #Cus(ParentID,ID2,cCusCode,cCusName,cCusAbbName,ItemNo,cInvName,cInvStd,cVenCode,OpeningQty,RecQty,IssQty,AdjQty,BalanceQty,RejQty,OpeningAmt,RecAmt,IssAmt,AdjAmt,RejAmt,BalanceAmt,AvgPrice,PurchaseCurr )
select b.ParentID,b.ID2,a.cCusCode,a.cCusName,a.cCusAbbName,a.ItemNo,a.cInvName,a.cInvStd,a.cVenCode,a.OpeningQty,a.RecQty,a.IssQty,a.AdjQty,a.BalanceQty,a.RejQty,a.OpeningAmt,a.RecAmt,a.IssAmt,a.AdjAmt,a.RejAmt,a.BalanceAmt,a.AvgPrice ,a.PurchaseCurr
from #Rep2 a inner join #Cus b on a.cCusCode = b.cCusCode


select a.*,b.cComUnitCode as UM
from #Cus a
    left join Inventory b on a.ItemNo = b.cInvCode
order by cCusCode,ID
";
                if(lookUpEditcCusCode.Text.Trim() !="")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cCusCode = '" + lookUpEditcCusCode.EditValue.ToString().Trim() + "'");
                }
                sSQL = sSQL.Replace("aaaaaa", dtm1.ToString("yyyy-MM-dd"));
                sSQL = sSQL.Replace("bbbbbb", dtm2.ToString("yyyy-MM-dd"));
                sSQL = sSQL.Replace("cccccc", dtm1.AddMonths(-1).ToString("yyyy-MM-dd"));

                if (lookUpEditcInvCCode.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and i.cInvCCode like '" + lookUpEditcInvCCode.EditValue.ToString().Trim() + "%'");
                }

                DataTable dt = DbHelperSQL.Query(sSQL);

                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    decimal OpeningQty = BaseFunction.ReturnDecimal(dt.Rows[i]["OpeningQty"]);
                    decimal RecQty = BaseFunction.ReturnDecimal(dt.Rows[i]["RecQty"]);
                    decimal IssQty = BaseFunction.ReturnDecimal(dt.Rows[i]["IssQty"]);
                    decimal AdjQty = BaseFunction.ReturnDecimal(dt.Rows[i]["AdjQty"]);
                    decimal BalanceQty = BaseFunction.ReturnDecimal(dt.Rows[i]["BalanceQty"]);
                    decimal RejQty = BaseFunction.ReturnDecimal(dt.Rows[i]["RejQty"]);

                    if (OpeningQty == 0
                        && RecQty == 0
                        && IssQty == 0
                        && AdjQty == 0
                        && BalanceQty == 0
                        && RejQty == 0
                        )
                        dt.Rows.RemoveAt(i);
                }

                this.treeList1.DataSource = dt;
                this.treeList1.KeyFieldName = "ID";
                this.treeList1.ParentFieldName = "ParentID";
                this.treeList1.BestFitColumns();

                chkExpandAll.Checked = false;
                //this.treeList1.ExpandAll();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void SetLookUp()
        {
            //dateEdit1.DateTime = Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-01"));
            //dateEdit2.DateTime = DateTime.Today;

            string sSQL = "select cCusCode,cCusName from Customer order by cCusCode";
            DataTable dt = DbHelperSQL.Query(sSQL);
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditcCusCode.Properties.DataSource = dt;
            lookUpEditcCusName.Properties.DataSource = dt;

            sSQL = "SELECT cInvCCode FROM dbo.InventoryClass where cInvCCode <> 'OS'";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditcInvCCode.Properties.DataSource = dt;

            sSQL = @"select distinct year(dDate) as [iYear] from SO_SOMain order by year(dDate)";
            dt = DbHelperSQL.Query(sSQL);
            lookUpEditYear.Properties.DataSource = dt;
            lookUpEditYear.EditValue = DateTime.Now.Year;

            dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "iMonth";
            dt.Columns.Add(dc);

            for (int i = 1; i <= 12; i++)
            {
                DataRow dr2 = dt.NewRow();
                dr2["iMonth"] = i;
                dt.Rows.Add(dr2);
            }
            lookUpEditMonth.Properties.DataSource = dt;
            lookUpEditMonth.EditValue = DateTime.Now.Month.ToString();

        }

        private void lookUpEditcCusCode_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditcCusName.EditValue = lookUpEditcCusCode.EditValue;
        }

        private void lookUpEditcCusName_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditcCusCode.EditValue = lookUpEditcCusName.EditValue;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xlsx";
                sF.FileName = "Sale Report";
                sF.Filter = "xlsx文件(*.xlsx)|*.xlsx|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK != dRes)
                {
                    return;
                }

                this.treeList1.ExportToXlsx(sF.FileName);
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "导出Excel失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void chkExpandAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkExpandAll.Checked)
                    this.treeList1.ExpandAll();
                else
                    this.treeList1.CollapseAll();
            }
            catch { }
        }
    }
}
