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
    public partial class RepBarcodeDetail : UserControl
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
        string sPrintLayOutMod = Application.StartupPath + "\\UAP\\Runtime\\print\\RepBarcodeDetail.dll";

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                List<String> list = LocalPrinter.GetLocalPrinters(); //获得系统中的打印机列表
                DataTable dt = new DataTable();
                DataColumn dc = new DataColumn();
                dc.ColumnName = "Printer";
                dt.Columns.Add(dc);

                foreach (String s in list)
                {
                    DataRow dr = dt.NewRow();
                    dr["Printer"] = s;
                    dt.Rows.Add(dr);
                }
                lookUpEditPrinter.Properties.DataSource = dt;
                lookUpEditPrinter.EditValue = LocalPrinter.DefaultPrinter();

                DbHelperSQL.connectionString = Conn;

                dateEdit1.DateTime = BaseFunction.ReturnDate(DateTime.Today.ToString("yyyy-MM-01"));
                dateEdit2.DateTime = BaseFunction.ReturnDate(DateTime.Today.AddMonths(1).ToString("yyyy-MM-01")).AddDays(-1);
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        public RepBarcodeDetail()
        {
            InitializeComponent();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
                sF.Filter = "Excel文件(*.xls)|*.xls|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridView1.ExportToXls(sF.FileName);
                    MessageBox.Show("OK\n\tPath：" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "导出Excel失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                string sSQL = "";
                DataTable dtHead = new DataTable();
                dtHead.TableName = "dtHead";
                DataColumn dc = new DataColumn();
                dc.ColumnName = "Date";
                dtHead.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "Time";
                dtHead.Columns.Add(dc);
                DataRow dr = dtHead.NewRow();
                dr["Date"] = DateTime.Now.ToString("dd/MM/yyyy");
                dr["Time"] = DateTime.Now.ToString("HH:mm:ss");
                dtHead.Rows.Add(dr);

                DataTable dt = (DataTable)gridControl1.DataSource;

                Rep.dsPrint.Tables.Clear();
                Rep.dsPrint.Tables.Add(dt.Copy());
                Rep.dsPrint.Tables[0].TableName = "dtGrid";
                Rep.dsPrint.Tables.Add(dtHead.Copy());
                Rep.dsPrint.Tables[1].TableName = "dtHead";

                if (radioPreview.Checked)
                {
                    Rep.ShowPreview();
                }
                if (radioPrint.Checked)
                {
                    if (lookUpEditPrinter.Text.Trim() == "")
                    {
                        lookUpEditPrinter.Focus();
                        throw new Exception("Please choose printer");
                    }
                    Rep.PrinterName = lookUpEditPrinter.Text.Trim();
                    Rep.Print();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private DataTable GetGrid()
        {
            string sSQL = "";
            return DbHelperSQL.Query(sSQL);
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            gridView1.AddNewRow();
        }

        private void btnPrintSet_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(sProPath + "\\print"))
                    Directory.CreateDirectory(sProPath + "\\print");

                if (File.Exists(sPrintLayOutMod))
                {
                    Rep.LoadLayout(sPrintLayOutMod);
                }

                Rep.ShowDesignerDialog();

                DialogResult d = MessageBox.Show("是否保存?模板调整将在下次打开窗体时体现\n是：保存打印模板\n", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (DialogResult.Yes == d)
                {
                    Rep.SaveLayoutToXml(sPrintLayOutMod);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "设置打印模板失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {

                string sDep = "select cDepCode,cDepName from Department order by cDepCode";
                ItemLookUpEditDept.DataSource = DbHelperSQL.Query(sDep);

                string sSQL = @"
IF OBJECT_ID('tempdb..#a') is not null
	drop table #a
	
IF OBJECT_ID('tempdb..#b') is not null
	drop table #b
	
IF OBJECT_ID('tempdb..#c') is not null
	drop table #c

select a.BarCode,a.iSOsID, MAX(a.UpdateTime) AS dEndTime
into #b
from _BarStatus a with(nolock)  inner join Warehouse b with(nolock) on a.RoutingTo = b.cwhCode
where b.CWHMEMO like '%P%'
	and UpdateTime >= 'aaaaaa' AND UpdateTime < 'bbbbbb'
group by a.BarCode,a.iSOsID
	
select a.BarCode,a.iSOsID, MIN(a.UpdateTime) AS dStartTime
into #c
from _BarStatus a with(nolock) inner join Warehouse b with(nolock) on a.RoutingTo = b.cwhCode
where b.CWHMEMO like '%P%'
	and a.BarCode in (select distinct barcode from #b)
group by a.BarCode,a.iSOsID


SELECT e.cCusCode as cCusCode,e.cCusName AS CUSTOMER,a.cCusCode AS CustomerID,b.cInvCode AS PARTCODE
	,g.cInvDefine6 AS PLATING,h.ProcessCode AS Process
	,g.cInvDepCode  AS Department,c.BarCode AS LabelNumber,c.LOTQTY AS Quantity
	,b.dPreDate AS ReceiveDate,b.dPreMoDate AS DueDate
	,case when d1.dStartTime is null then d2.dEndTime else d1.dStartTime end AS DateStart
    ,d2.dEndTime AS DateEnd
	,CAST( NULL AS DECIMAL(16,5)) AS OFFPH,isnull(CAST(DATEDIFF(minute,d1.dStartTime,d2.dEndTime ) / 60.0 / 24.0 AS DECIMAL(16,5)),0) AS TAT
INTO #a
FROM dbo.SO_SOMain a  with(nolock) INNER JOIN dbo.SO_SODetails b with(nolock) ON a.ID = b.ID 
	left JOIN [dbo].[_BarCodeLabel] c  with(nolock) ON b.iSOsID = c.iSOsID
	left JOIN #c d1 ON c.BarCode = d1.BarCode AND c.iSOsID = d1.iSOsID
	LEFT JOIN #b d2 ON c.BarCode = d2.BarCode AND c.iSOsID = d2.iSOsID
	inner JOIN customer e  with(nolock) ON a.cCusCode = e.cCusCode
	inner JOIN dbo.Department f  with(nolock) ON a.cDepCode = f.cDepCode
    inner join Inventory g  with(nolock) on g.cInvCode = b.cInvCode
    left join [_PlatingProcess] h  with(nolock) on h.itemcode = b.cInvCode
WHERE 1=1
	AND b.iQuantity = b.iFHQuantity 
    and d2.dEndTime is not null


UPDATE #a SET OFFPH = 
	(SELECT COUNT(1) AS iCou 
	FROM bas_calendardetail 
	WHERE CalendarId IN (
		SELECT CalendarId 
		FROM bas_calendar 
		WHERE CalendarCode = 'SYSTEM')
			AND CalDate >= #a.DateStart AND CalDate <= #a.DateEnd
			AND WkHours = 0	)

SELECT * FROM #a ORDER BY Department, CustomerID,PARTCODE,LabelNumber
";

//                string sSQL = @"
//    exec _GetTatDetails 'aaaaaa','bbbbbb'
//";
                sSQL = sSQL.Replace("aaaaaa", dateEdit1.DateTime.ToString("yyyy-MM-dd"));
                sSQL = sSQL.Replace("bbbbbb", dateEdit2.DateTime.AddDays(1).ToString("yyyy-MM-dd"));
                DataTable dt = DbHelperSQL.Query(sSQL);

                //gridView1.Columns["TAT"].SummaryItem.Format.GetFormat

                gridControl1.DataSource = dt;


                gridView1.BestFitColumns();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}

