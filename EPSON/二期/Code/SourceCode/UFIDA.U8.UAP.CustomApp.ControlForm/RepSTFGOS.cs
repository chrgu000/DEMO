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
    public partial class RepSTFGOS : UserControl
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

        public RepSTFGOS()
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
set nocount on										

declare @dtm1 datetime
declare @dtm2 datetime 

set @dtm1 = 'aaaaaa'
set @dtm2 = 'bbbbbb'


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


 --本月发货
select a.cCusCode,b.cInvCode
	,cast(null as decimal(16,3)) as OpeningQty
	,cast(sum(b.iquantity) as decimal(16,3)) as RecQty
	,cast(sum(b.iquantity) as decimal(16,3)) as IssQty
	,cast(null as decimal(16,3)) as AdjQty
	,cast(null as decimal(16,3)) as BalanceQty
	,cast(null as decimal(16,3)) as RejQty
	,po.cVenCode as cVenCode
	,null as ID
	,null as ParentID
    ,so.cexch_name as PurchaseCurr
    ,sum(salebills.iMoney * isnull(salebill.iExchRate,0)) as iSum
into #Rep
from DispatchList  a inner join DispatchLists b on a.DLID = b.DLID
    inner join SaleBillVouchs salebills on  salebills.iDLsID = b.iDLsID 
    inner join SaleBillVouch salebill on  salebills.SBVID = salebill.SBVID
	inner join SO_SODetails sos on sos.iSOsID = b.iSOsID 
	inner join SO_SOMain so on so.ID = sos.ID
	inner join Inventory i on b.cInvCode = i.cInvCode
    inner join Warehouse w on b.cWhCode = w.cWhCode
	inner join PO_Podetails pos on pos.iorderdid = sos.iSOsID
	inner join PO_Pomain po on po.POID = pos.POID
where 1=1 and a.dDate >= @dtm1 and a.dDate < @dtm2 and 2=2
    and w.cWhMemo like '%F%'
group by a.cCusCode,b.cInvCode,so.cexch_name,po.cVenCode


select a.cCusCode,cus.cCusName,cus.cCusAbbName
	,a.cInvCode as ItemNo,i.cInvName,i.cInvStd
	,a.cVenCode
	,null as OpeningQty
	,sum(RecQty) as RecQty
	,sum(IssQty) as IssQty
	,null as AdjQty
	,null as BalanceQty
	,sum(RejQty) as RejQty
	,cast(NULL as decimal(16,3)) as OpeningAmt													--金额（有的仓库是不记成本的）
	,cast(sum(iSum) as decimal(16,3)) as RecAmt														--本月入库金额
	,cast(NULL as decimal(16,3)) as IssAmt														--本月发货金额
	,cast(NULL as decimal(16,3)) as AdjAmt														--调整金额
	,cast(NULL as decimal(16,3)) as RejAmt														--次品金额
	,cast(NULL as decimal(16,3)) as BalanceAmt														--
	,cast(NULL as decimal(16,5)) as AvgPrice
    ,a.PurchaseCurr
    ,cast(null as decimal(16,3)) as iSum
into #Rep2
from #Rep a
	left join Inventory i on i.cInvCode = a.cInvCode
	left join Customer cus on cus.cCusCode = a.cCusCode
group by a.cCusCode,cus.cCusName,cus.cCusAbbName,a.cInvCode,i.cInvName,i.cInvStd,a.cVenCode,a.PurchaseCurr


UPDATE #Rep2 SET AvgPrice = case when isnull(RecQty,0) <> 0 then isnull(RecAmt,0)/isnull(RecQty,0)  else null end

UPDATE #Rep2 SET BalanceQty = isnull(RecQty,0) - isnull(IssQty,0)
	,IssAmt = IssQty * AvgPrice


UPDATE #Rep2 SET IssAmt = RecAmt

	
select  IDENTITY(INT,1,1) as ID,null as ParentID,null as ID2,cVenCode
	,cCusCode,cCusName,cCusAbbName,cast(null as varchar(100)) as ItemNo,cast(null as varchar(100)) as cInvName,cast(null as varchar(100)) as cInvStd 
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
group by cCusCode,cCusName,cCusAbbName,PurchaseCurr,cVenCode

update #Cus set ParentID = ID, ID2 = ID + 1000000000



INSERT INTO #Cus(ParentID,ID2,cCusCode,cCusName,cCusAbbName,ItemNo,cInvName,cInvStd,cVenCode,OpeningQty,RecQty,IssQty,AdjQty,BalanceQty,RejQty,OpeningAmt,RecAmt,IssAmt,AdjAmt,RejAmt,BalanceAmt,AvgPrice,PurchaseCurr )
select b.ParentID,b.ID2,a.cCusCode,a.cCusName,a.cCusAbbName,a.ItemNo,a.cInvName,a.cInvStd,a.cVenCode,a.OpeningQty,a.RecQty,a.IssQty,a.AdjQty,a.BalanceQty,a.RejQty,a.OpeningAmt,a.RecAmt,a.IssAmt,a.AdjAmt,a.RejAmt,a.BalanceAmt,a.AvgPrice ,a.PurchaseCurr
from #Rep2 a inner join #Cus b on a.cCusCode = b.cCusCode and a.cVenCode = b.cVenCode


select a.*,i.cComUnitCode as UM,isnull(IssAmt,0) - isnull(RecAmt,0) as DiffAmt
from #Cus a
    left join Inventory i on a.ItemNo = i.cInvCode

order by cCusCode,ID

";

                if (lookUpEditcCusCode.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cCusCode = '" + lookUpEditcCusCode.EditValue.ToString().Trim() + "'");
                }
                //if(lookUpEditcVenCode.Text.Trim() !="")
                //{
                //    sSQL = sSQL.Replace("1=1", "1=1 and RdIn.cVenCode = '" + lookUpEditcVenCode.EditValue.ToString().Trim() + "'");
                //}
                sSQL = sSQL.Replace("aaaaaa", dtm1.ToString("yyyy-MM-dd"));
                sSQL = sSQL.Replace("bbbbbb", dtm2.ToString("yyyy-MM-dd"));


                if (lookUpEditcInvCCode.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("2=2", "2=2 and i.cInvCCode like '" + lookUpEditcInvCCode.EditValue.ToString().Trim() + "%'");
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

            sSQL = "SELECT cInvCCode FROM dbo.InventoryClass where cInvCCode = 'OS'";
            dt = DbHelperSQL.Query(sSQL);
            lookUpEditcInvCCode.Properties.DataSource = dt;
            lookUpEditcInvCCode.EditValue = "OS";

            //string sSQL = "select cVenCode,cVenName from Vendor order by cVenCode";
            //DataTable dt = DbHelperSQL.Query(sSQL);
            //DataRow dr = dt.NewRow();
            //dt.Rows.InsertAt(dr, 0);
            //lookUpEditcVenCode.Properties.DataSource = dt;
            //lookUpEditcVenName.Properties.DataSource = dt;

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

        //private void lookUpEditcVenCode_EditValueChanged(object sender, EventArgs e)
        //{
        //    lookUpEditcVenName.EditValue = lookUpEditcVenCode.EditValue;
        //}

        //private void lookUpEditcVenName_EditValueChanged(object sender, EventArgs e)
        //{
        //    lookUpEditcVenCode.EditValue = lookUpEditcVenName.EditValue;
        //}

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

        private void lookUpEditcCusCode_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditcCusName.EditValue = lookUpEditcCusCode.EditValue;
        }

        private void lookUpEditcCusName_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditcCusCode.EditValue = lookUpEditcCusName.EditValue;
        }
    }
}
