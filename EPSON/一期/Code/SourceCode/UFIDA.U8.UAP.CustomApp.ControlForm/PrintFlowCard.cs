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
    public partial class PrintFlowCard : UserControl
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
        string sPrintLayOutMod = Application.StartupPath + "\\UAP\\Runtime\\print\\aaaaaaaa1.dll";

        DataTable dtGrid = new DataTable();
        DataTable dtPrint = new DataTable();

        string sSQLGrid = @"
SELECT 
      cast(1 as bit) as choose, A.cSTCode,a.dDate
    ,A.cSOCode AS ORDNO,b.iSOsID,b.iRowNo,c.cInvDepCode AS DEPT
	,A.cCusCode AS CUST
	,NULL AS vend
	,b.cinvcode AS ItemNO,b.cInvName AS ItemDESC
	,b.cDefine25 AS CustLOT,d.CustDO AS CustDO
	,CAST(b.iQuantity AS DECIMAL(16,2)) AS ORDQTY
    ,CAST(d.LotQTY AS DECIMAL(16,2)) AS LOTQTY
    ,CAST(d.LotQTY AS DECIMAL(16,2)) AS PrintQTY
    ,CAST(null AS DECIMAL(16,2)) AS PrintQTY2
	,A.dDate AS RECDTE,B.dPreDate AS DUEDTE
	,d.BarCode AS LOTNO
    ,d.creater,d.createdate
    ,b.cUnitID ,d.PrintCount,d.PrintTime
    ,d.BarCode
    ,d.iID
    ,cast(null as varchar(50)) as MC
    ,cast(null as varchar(50)) as POT
    ,cast(null as varchar(50)) as RACK
    ,cast(null as varchar(50)) as PRODLINE
    ,e.*
FROM dbo.SO_SOMain A INNER JOIN dbo.SO_SODetails B ON A.ID = B.ID
	INNER JOIN inventory c ON b.cInvCode = c.cInvCode
	inner JOIN [dbo].[_BarCodeLabel] d ON b.iSOsID = d.iSOsID
	left join  _PlatingProcess e on e.ItemCode = b.cInvCode
WHERE 1=1 and isnull(a.iStatus ,0) = 1 and isnull(cCloser ,'') = '' 
	and b.iSOsID in (select max(iSOsID) from [_BarCodeLabel] group by barcode)
ORDER BY a.cSOCode,b.cInvCode,d.BarCode
";

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                if (sUserID.ToLower() == "demo")
                {
                    btnPrintSet.Visible = true;
                }
                else
                {
                    btnPrintSet.Visible = false;
                }

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
                SetLookUp();
                string sSQL = sSQLGrid;
                sSQL = sSQL.Replace("1=1", "1=-1");
                dtGrid = DbHelperSQL.Query(sSQL);

                dtPrint = dtGrid.Copy();

                btnTxtBarCode.Focus();

                sPrintLayOutMod = sPrintLayOutMod.Replace("aaaaaaaa", lookUpEditFlowType.Text.Trim());


            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        public PrintFlowCard()
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
                //DataTable dt = ((DataView)gridView1.DataSource).ToTable();
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (!BaseFunction.ReturnBool(gridView1.GetRowCellValue(i,gridColchoose)))
                    {
                        continue;
                    }

                    decimal dPrint = BaseFunction.ReturnDecimal(gridView1.GetRowCellDisplayText(i,gridColPrintQTY));

                    if (dPrint > 0)
                    {
                        sSQL = @"
SELECT row_number() over (order by A.cSTCode) as rowid
    ,getdate() as dtmNow
    ,A.cSTCode,a.dDate
    ,A.cSOCode AS ORDNO,b.iSOsID,b.iRowNo,c.cInvDepCode AS DEPT
	,A.cCusCode AS CUST
	,NULL AS vend
	,b.cinvcode AS ITEMNO,b.cInvName AS ITEMDESC
	,b.cDefine25 AS CUSTLOT,a.cDefine10 AS CUSTDO
	,CAST(b.iQuantity AS DECIMAL(16,2)) AS ORDQTY
    ,cast(bbbbbb as decimal(16,2)) AS LOTQTY
    ,CONVERT(char(10), A.dDate, 120) as RECDTE
    ,CONVERT(char(10), B.dPreDate, 120) as DUEDTE
	,'gggggg' AS LOTNO
    ,d.creater,d.createdate
    ,c.cComUnitCode as cUnitID ,d.PrintCount,GETDATE() AS PrintTime
    ,d.barcode
    ,d.iID
    ,e.*
    ,cast('eeeeee' as varchar(50)) as MC
    ,cast('ffffff' as varchar(50)) as POT
    ,cast('cccccc' as varchar(50)) as RACK
    ,cast('dddddd' as varchar(50)) as PRODLINE
FROM dbo.SO_SOMain A INNER JOIN dbo.SO_SODetails B ON A.ID = B.ID
	INNER JOIN inventory c ON b.cInvCode = c.cInvCode
	inner JOIN [dbo].[_BarCodeLabel] d ON b.iSOsID = d.iSOsID
	LEFT JOIN 
	(
		SELECT a.Status, a.ProcessCode, a.Seq, a.PlatingProcess, a.Condition, a.Thichness, a.Time, a.Density, a.AMP
			, b.ItemCode, b.Material, b.XRayFile, b.FinishingSpec, b.CommonPltSpec, b.Grade, b.UnitSurfaceArea, b.UnitWeight, b.Note1, b.Note2, b.Note3,b.Color
		FROM [dbo].[_ProcessList] a INNER JOIN [dbo].[_PlatingProcess] b ON a.ProcessCode = b.ProcessCode
        where a.Status <> 'No'
	)e ON c.cinvcode = e.ItemCode
WHERE 1=1 and d.barcode = 'aaaaaa'
	and b.iSOsID in (select max(iSOsID) from [_BarCodeLabel] where barcode = 'aaaaaa' group by barcode)
ORDER BY b.cinvcode,a.cSOCode, b.AutoID ,e.Seq
";
                        sSQL = sSQL.Replace("aaaaaa", gridView1.GetRowCellDisplayText(i,gridColBarCode).ToString().Trim());
                        sSQL = sSQL.Replace("bbbbbb", dPrint.ToString().Trim());
                        sSQL = sSQL.Replace("cccccc", gridView1.GetRowCellDisplayText(i,gridColRACK).ToString().Trim());
                        sSQL = sSQL.Replace("dddddd", gridView1.GetRowCellDisplayText(i,gridColPRODLINE).ToString().Trim()); 
                        sSQL = sSQL.Replace("eeeeee",gridView1.GetRowCellDisplayText(i,gridColMC).ToString().Trim());
                        sSQL = sSQL.Replace("ffffff",gridView1.GetRowCellDisplayText(i,gridColPOT).ToString().Trim());
                        sSQL = sSQL.Replace("gggggg", gridView1.GetRowCellDisplayText(i,gridColLOTNO).ToString().Trim()); 
                        DataTable dtPrint = DbHelperSQL.Query(sSQL);

                        Rep = new RepBaseGrid();
                        if (File.Exists(sPrintLayOutMod))
                        {
                            Rep.LoadLayout(sPrintLayOutMod);
                        }
                        else
                        {
                            MessageBox.Show("加载报表模板失败，请与管理员联系");
                            return;
                        }
                        Rep.dsPrint.Tables.Clear();
                        Rep.dsPrint.Tables.Add(dtPrint.Copy());
                        Rep.dsPrint.Tables[0].TableName = "dtGrid";

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
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private DataTable GetGrid()
        {
            string sSQL = sSQLGrid;
            if (btnTxtBarCode.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and d.BarCode = '" + btnTxtBarCode.Text.Trim() + "' ");
            }
            if (lookUpEditSOCode.EditValue != null && lookUpEditSOCode.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and A.cSOCode = '" + lookUpEditSOCode.EditValue.ToString().Trim() + "'");
            }
            return  DbHelperSQL.Query(sSQL);
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            gridView1.AddNewRow();
        }

        private void SetLookUp()
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "FlowType";
            dt.Columns.Add(dc);

            DataRow dr = dt.NewRow();
            dr["FlowType"] = "BARREL";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["FlowType"] = "WP";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["FlowType"] = "WC";
            dt.Rows.Add(dr);

            lookUpEditFlowType.Properties.DataSource = dt;
            lookUpEditFlowType.EditValue = dt.Rows[0][0].ToString().Trim();

            string sSQL = @"select * from _ProLine order by cCode";
            dt = DbHelperSQL.Query(sSQL);
            ItemLookUpEditRACK.DataSource = dt;

            sSQL = "select cSoCode from SO_SOMain where isnull(cCloser,'') = ''";
            dt = DbHelperSQL.Query(sSQL);
            DataRow drSO = dt.NewRow();
            drSO["cSoCode"] = DBNull.Value;
            dt.Rows.InsertAt(drSO, 0);
            lookUpEditSOCode.Properties.DataSource = dt;
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

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridView1.Columns["choose"], chkAll.Checked);
                }
            }
            catch { }
        }

        private void lookUpEditFlowType_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                sPrintLayOutMod = Application.StartupPath + "\\UAP\\Runtime\\print\\aaaaaaaa1.dll";
                sPrintLayOutMod = sPrintLayOutMod.Replace("aaaaaaaa", lookUpEditFlowType.Text.Trim());
            }
            catch { }
        }

        private void btnTxtBarCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            { 
                if(btnTxtBarCode.Text.Trim() == "")
                    return;

                string sSQL = sSQLGrid;
                sSQL = sSQL.Replace("1=1", "1=-1");
                dtGrid = DbHelperSQL.Query(sSQL);


                DataTable dt = GetGrid();

                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("Get barcode err");
                }

                DataRow dr = dtGrid.NewRow();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    dr[i] = dt.Rows[0][i];
                }
                dtGrid.Rows.Add(dr);

                gridControl1.DataSource = dtGrid;
                btnTxtSize.Text = dtGrid.Rows[0]["LotQTY"].ToString().Trim();
                if (BaseFunction.ReturnDecimal(btnTxtSize.Text) <= 0)
                {
                    btnTxtSize.Text = "";
                    throw new Exception("Please set size");
                }

                btnTxtSize.Focus();

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnTxtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode != Keys.Enter)
                {
                    return;
                }

                btnTxtBarCode_ButtonClick(null, null);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnTxtSize_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (btnTxtBarCode.Text.Trim() == "")
                {
                    throw new Exception("Please scan barcode");
                }

                decimal dSize = BaseFunction.ReturnDecimal(btnTxtSize.Text);
                if (dSize <= 0)
                    return;

                string sSQL = sSQLGrid;
                sSQL = sSQL.Replace("1=1", "1=1 and d.BarCode = '" + btnTxtBarCode.Text.Trim() + "'");
                DataTable dt = DbHelperSQL.Query(sSQL);

                sSQL = sSQL.Replace("1=1", "1=-1");
                DataTable dtTemp = DbHelperSQL.Query(sSQL);

                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("Barcode is changed");
                }
                decimal dBarQTY = BaseFunction.ReturnDecimal(dt.Rows[0]["LOTQTY"], 2);

                int iRow = 0;

                while (dBarQTY > 0)
                {
                    DataRow dr = dtTemp.NewRow();
                    for (int i = 0; i < dtTemp.Columns.Count; i++)
                    {
                        dr[i] = dt.Rows[0][i];
                    }

                    iRow += 1;
                    string sRow = iRow.ToString();
                    while (sRow.Length < 4)
                    {
                        sRow = "0" + sRow;
                    }


                    if (dtTemp.Rows.Count == 0 && dBarQTY <= BaseFunction.ReturnDecimal(btnTxtSize.Text.Trim()))
                    {
                        dr["LOTNO"] = dr["LOTNO"];
                    }
                    else
                    {
                        dr["LOTNO"] = dr["LOTNO"] + "-" + sRow;
                    }
                    if (dBarQTY > dSize)
                    {
                        dr["PrintQTY"] = BaseFunction.ReturnDecimal(dSize.ToString(), 2);
                        dBarQTY = BaseFunction.ReturnDecimal(dBarQTY - dSize, 2);
                    }
                    else
                    {
                        dr["PrintQTY"] = BaseFunction.ReturnDecimal(dBarQTY.ToString(), 2);
                        dBarQTY = 0;
                    }
                    dtTemp.Rows.Add(dr);
                }

                gridControl1.DataSource = dtTemp;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnTxtSize_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode != Keys.Enter)
                {
                    return;
                }

                btnTxtSize_ButtonClick(null, null);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string sSQL = sSQLGrid;
                if (btnTxtBarCode.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and d.BarCode = '" + btnTxtBarCode.Text.Trim() + "' ");
                }
                if (lookUpEditSOCode.EditValue != null && lookUpEditSOCode.EditValue.ToString().Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and A.cSOCode = '" + lookUpEditSOCode.EditValue.ToString().Trim() + "'");
                }
                DataTable dt = DbHelperSQL.Query(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    gridControl1.DataSource = null;
                    throw new Exception("Get barcode err");
                }

                gridControl1.DataSource = dt;
                btnTxtSize.Text = dt.Rows[0]["LotQTY"].ToString().Trim();
                if (BaseFunction.ReturnDecimal(btnTxtSize.Text) <= 0)
                {
                    btnTxtSize.Text = "";
                    throw new Exception("Please set size");
                }

                btnTxtSize.Focus();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}

