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
using System.Collections;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class ImportPackingList_Invoice : UserControl
    {        
        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }


        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                DbHelperSQL.connectionString = Conn;
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "Err";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        public ImportPackingList_Invoice()
        {
            InitializeComponent();
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

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "xlsx|*.xlsx|xls|*.xls|All File|*.*";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                string sSQL = "";
                string fName = openFileDialog.FileName;

                ClsExcel clsExcel = ClsExcel.Instance();

                SetTxtNull();

                sSQL = "select * from [PL$A4:B8]";
                DataTable dtHead = clsExcel.ExcelToDT(fName, sSQL, true);
                txtCurrency.Text = dtHead.Rows[0][1].ToString().Trim();
                txtInvoiceNO.Text = dtHead.Rows[1][1].ToString().Trim();
                dateEdit1.DateTime = BaseFunction.ReturnDate(dtHead.Rows[2][1]);
                txtCompany.Text = dtHead.Rows[3][1].ToString().Trim();


                sSQL = "select * from [PL$A11:N65535]";
                DataTable dtParkingList = clsExcel.ExcelToDT(fName, sSQL, true);
                for (int i = 0; i < dtParkingList.Columns.Count; i++)
                {
                    dtParkingList.Columns[i].ColumnName = dtParkingList.Rows[0][i].ToString().Trim();
                }


                DataColumn dc = new DataColumn();
                dc.ColumnName = "U8RDCode";
                dtParkingList.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "Rds01ID";
                dtParkingList.Columns.Add(dc);
                
                dtParkingList.Rows.RemoveAt(1);                 //去除列表中的 标题
                dtParkingList.Rows.RemoveAt(0);                 //去除列表中的 ATUP PARTS 这行数据

                for (int i = dtParkingList.Rows.Count - 1; i >= 0; i--)
                {
                    if (dtParkingList.Rows[i][0].ToString().Trim().ToUpper().StartsWith("CURRENCY"))
                    {
                        dtParkingList.Rows.RemoveAt(i);
                        break;
                    }
                    dtParkingList.Rows.RemoveAt(i);
                }
                for (int i = dtParkingList.Rows.Count - 1; i >= 0; i--)
                {
                    if (dtParkingList.Rows[i][0].ToString().Trim() == "")
                    {
                        dtParkingList.Rows.RemoveAt(i);
                    }
                }

                for (int i = 0; i < dtParkingList.Columns.Count; i++)
                {
                    string sColName = dtParkingList.Columns[i].ColumnName.ToString().Trim();
                    sColName = sColName.Replace(" ", "");
                    sColName = sColName.Replace("#", "");
                    sColName = sColName.Replace(".", "");
                    sColName = sColName.Replace("(", "");
                    sColName = sColName.Replace(")", "");
                    dtParkingList.Columns[i].ColumnName = sColName;
                }

                gridControlPL.DataSource = dtParkingList;
                gridViewPL.BestFitColumns();

                //sSQL = "select * from [IN$A5:B8]";
                //DataTable dt_Head = clsExcel.ExcelToDT(fName, sSQL, true);
                //txt_InvoiceNO.Text = dt_Head.Rows[0][1].ToString().Trim();
                //dateEdit_1.DateTime = BaseFunction.ReturnDate(dt_Head.Rows[1][1]);
                //txt_Company.Text = dt_Head.Rows[2][1].ToString().Trim();

                sSQL = "select * from [IN$A11:I65535]";
                DataTable dtInvoice = clsExcel.ExcelToDT(fName, sSQL, true);
                for (int i = 0; i < dtInvoice.Columns.Count; i++)
                {
                    dtInvoice.Columns[i].ColumnName = dtInvoice.Rows[0][i].ToString().Trim();
                }

                dtInvoice.Rows.RemoveAt(1);                 //去除列表中的 标题
                dtInvoice.Rows.RemoveAt(0);                 //去除列表中的 ATUP PARTS 这行数据

                for (int i = dtInvoice.Rows.Count - 1; i >= 0; i--)
                {
                    if (dtInvoice.Rows[i][0].ToString().Trim().ToUpper().StartsWith("CURRENCY"))
                    {
                        dtInvoice.Rows.RemoveAt(i);
                        break;
                    }
                    dtInvoice.Rows.RemoveAt(i);
                }
                for (int i = dtInvoice.Rows.Count - 1; i >= 0; i--)
                {
                    if (dtInvoice.Rows[i][0].ToString().Trim().ToUpper().StartsWith(""))
                    {
                        dtInvoice.Rows.RemoveAt(i);
                        break;
                    }
                    dtInvoice.Rows.RemoveAt(i);
                }
                for (int i = dtInvoice.Rows.Count - 1; i >= 0; i--)
                {
                    if (dtInvoice.Rows[i][0].ToString().Trim() == "" || dtInvoice.Rows[i][0].ToString().Trim().ToUpper().StartsWith("TOTAL"))
                    {
                        dtInvoice.Rows.RemoveAt(i);
                    }
                }

                for (int i = 0; i < dtInvoice.Columns.Count; i++)
                {
                    string sColName = dtInvoice.Columns[i].ColumnName.ToString().Trim();
                    sColName = sColName.Replace(" ", "");
                    sColName = sColName.Replace("#", "");
                    sColName = sColName.Replace(".", "");
                    sColName = sColName.Replace("(", "");
                    sColName = sColName.Replace(")", "");
                    sColName = sColName.Replace("\n", "");
                    sColName = sColName.Replace("\r", "");
                    sColName = sColName.Replace("UNITPRICE", "PRICEPERUNIT");
                    dtInvoice.Columns[i].ColumnName = sColName;
                }

                gridControlIN.DataSource = dtInvoice;
                gridViewIN.BestFitColumns();

                dateEdit1.DateTime = BaseFunction.ReturnDate(sLogDate);
            }
            catch (Exception ee)
            {
                SetTxtNull();

                MessageBox.Show(ee.Message);
            }
        }

        private void btnImprot_Click(object sender, EventArgs e)
        {
            try
            {
                gridViewIN.FocusedRowHandle -= 1;
                gridViewIN.FocusedRowHandle += 1;

                gridViewPL.FocusedRowHandle -= 1;
                gridViewPL.FocusedRowHandle += 1;
            }
            catch { }

            try
            {
                if (dateEdit1.DateTime < BaseFunction.ReturnDate("2017-01-01"))
                {
                    throw new Exception("Date is err");
                }

                decimal dPLSum = BaseFunction.ReturnDecimal(gridViewPL.Columns["QUANTITY"].SummaryItem.SummaryValue);
                decimal dINSum = BaseFunction.ReturnDecimal(gridViewIN.Columns["QUANTITY"].SummaryItem.SummaryValue);
                if (dPLSum != dINSum)
                {
                    throw new Exception("Please check the quantity");
                }

                if (dtmBL.Text.Trim() == "")
                {
                    dtmBL.Focus();
                    throw new Exception("Please set b/l date");
                }
                //if (dtmBL.DateTime < BaseFunction.ReturnDate(sLogDate).AddMonths(-1))
                //{
                //    dtmBL.Focus();
                //    throw new Exception("Please set b/l date");
                //}

                if (txtBL.Text.Trim() == "")
                {
                    txtBL.Focus();
                    throw new Exception("Please set b/l no");
                }

                if (gridViewIN.RowCount == 0 || gridViewPL.RowCount == 0)
                {
                    throw new Exception("No data");
                }

                string sErr = "";
                string sWarn = "";
                int iCount = 0;
                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    string sSQL = "select getdate()";
                    DateTime dNow = BaseFunction.ReturnDate(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                    DateTime dNowDate = BaseFunction.ReturnDate(dNow.ToString("yyyy-MM-dd"));
                    string sDateTxt = dNow.ToString("yyyyMMddHHmmss");

                    CheckData(tran);

                    sSQL = @"
select a.cPOID,b.*,inv.cInvAddCode
from PO_Pomain a 
	inner join PO_Podetails b on a.poid = b.poid 
    inner join Inventory inv on inv.cInvCode = b.cInvCode
where a.cPOID in (select PONO from RdRecords01_temp)
";
                    DataTable dtPO = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    for (int i = 0; i < gridViewPL.RowCount; i++)
                    {
                        Model.RdRecords01_Import modRdsImport = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.RdRecords01_Import();
                        modRdsImport.ImportTime = sDateTxt;
                        modRdsImport.InvoiceNo = txtInvoiceNO.Text.Trim();
                        modRdsImport.Date = dateEdit1.DateTime;
                        modRdsImport.Companyname = txtCompany.Text.Trim();
                        modRdsImport.PONO = gridViewPL.GetRowCellValue(i, gridColPONO).ToString().Trim();
                        modRdsImport.CONTAINERNO = gridViewPL.GetRowCellValue(i, gridColCONTAINERNO).ToString().Trim();
                        modRdsImport.DESCRIPTIONOFPRODUCTSEN = gridViewPL.GetRowCellValue(i, gridColDESCRIPTIONOFPRODUCTSEN).ToString().Trim();
                        modRdsImport.CASENO = gridViewPL.GetRowCellValue(i, gridColCASENO).ToString().Trim();
                        modRdsImport.BOXNO = gridViewPL.GetRowCellValue(i, gridColBOXNO).ToString().Trim();
                        modRdsImport.BOXQTY = BaseFunction.ReturnDecimal(gridViewPL.GetRowCellValue(i, gridColBOXQTY), 6);
                        modRdsImport.QUANTITY = BaseFunction.ReturnDecimal(gridViewPL.GetRowCellValue(i, gridColQUANTITY), 6);
                        modRdsImport.UNIT = gridViewPL.GetRowCellValue(i, gridColUNIT).ToString().Trim();
                        modRdsImport.NWKGS = BaseFunction.ReturnDecimal(gridViewPL.GetRowCellValue(i, gridColNWKGS), 6);
                        modRdsImport.GWKGS = BaseFunction.ReturnDecimal(gridViewPL.GetRowCellValue(i, gridColGWKGS), 6);
                        modRdsImport.BOXCBM = BaseFunction.ReturnDecimal(gridViewPL.GetRowCellValue(i, gridColBOXCBM), 6);
                        modRdsImport.CONNO = gridViewPL.GetRowCellValue(i, gridColCONNO).ToString().Trim();
                       
                        modRdsImport.BLDate = dtmBL.DateTime;
                        modRdsImport.BLNo = txtBL.Text.Trim();
                        modRdsImport.Currency = txtCurrency.Text.Trim();

                        DataRow[] dr = dtPO.Select("cPOID = '" + modRdsImport.PONO + "' and (cInvAddCode = '" + gridViewPL.GetRowCellValue(i, gridColPARTNO).ToString().Trim() + "' or cInvCode = '" + gridViewPL.GetRowCellValue(i, gridColPARTNO).ToString().Trim() + "')");
                        if (dr.Length <= 0)
                        {
                            sErr = sErr + "Line " + (i + 1).ToString() + " PO No does not match\n";
                            continue;
                        }
                        modRdsImport.PARTNO = dr[0]["cInvCode"].ToString().Trim();
                        modRdsImport.POsID = BaseFunction.ReturnInt(dr[0]["ID"]);

                        DAL.RdRecords01_Import dalRdImport = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.RdRecords01_Import();
                        sSQL = dalRdImport.Add(modRdsImport);
                        iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    for (int i = 0; i < gridViewIN.RowCount; i++)
                    {
                        Model.PurBillVouchs_Import modINImport = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.PurBillVouchs_Import();
                        modINImport.ImportTime = sDateTxt;
                        modINImport.InvoiceNo = txtInvoiceNO.Text.Trim();
                        modINImport.Date = dateEdit1.DateTime;
                        modINImport.Companyname = txtCompany.Text.Trim();
                        modINImport.PONO = gridViewIN.GetRowCellValue(i,gridCol_PONO).ToString().Trim();

                        sSQL = @"
select inv.cInvCode,inv.cInvAddCode
from Inventory inv 
	inner join (
		select distinct b.cInvCode
		from PO_Pomain a inner join po_podetails b on a.POID = b.POID
		where a.cPOID = '{1}'
        ) po on inv.cInvCode = po.cInvCode
where inv.cInvAddCode = '{0}' or inv.cInvCode = '{0}'
";
                        sSQL = string.Format(sSQL, gridViewIN.GetRowCellValue(i, gridCol_PARTNO).ToString().Trim(), gridViewIN.GetRowCellValue(i, gridCol_PONO).ToString().Trim());

                        DataTable dtInv = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtInv == null || dtInv.Rows.Count == 0)
                        {
                            sErr = sErr + "Line " + (i + 1).ToString() + " Part No does not match\n";
                            continue;
                        }

                        modINImport.PARTNO = dtInv.Rows[0]["cInvCode"].ToString().Trim();
                        modINImport.DESCRIPTIONENGLISH = gridViewIN.GetRowCellValue(i,gridCol_DESCRIPTIONENGLISH).ToString().Trim();
                        modINImport.QUANTITY = BaseFunction.ReturnDecimal(gridViewIN.GetRowCellValue(i,gridCol_QUANTITY),6);
                        modINImport.NW = BaseFunction.ReturnDecimal(gridViewIN.GetRowCellValue(i,gridCol_NW),6);
                        modINImport.GW = BaseFunction.ReturnDecimal(gridViewIN.GetRowCellValue(i,gridCol_GW),6);
                        modINImport.PRICEPERUNIT = BaseFunction.ReturnDecimal(gridViewIN.GetRowCellValue(i,gridCol_PRICEPERUNIT),6);
                        modINImport.UNIT = gridViewIN.GetRowCellValue(i,gridCol_UNIT).ToString().Trim();
                        modINImport.TOTALPRICE = BaseFunction.ReturnDecimal(gridViewIN.GetRowCellValue(i,gridCol_TOTALPRICE),6);
                        DAL.PurBillVouchs_Import dalInImprot = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.PurBillVouchs_Import();
                        sSQL = dalInImprot.Add(modINImport);
                        iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    //按照发票刷新装箱单单价
                    sSQL = @"
update a set a.UnitPrice = b.priceperunit
from RdRecords01_Import a inner join PurBillVouchs_Import b on a.ImportTime = b.ImportTime and a.PONO = b.PONO and a.PARTNO = b.PARTNO
";
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    if (sWarn.Length > 0)
                    {
                        FrmMsgBoxYesOrNo frm = new FrmMsgBoxYesOrNo();
                        frm.richTextBox1.Text = sWarn;
                        if (DialogResult.Yes != frm.ShowDialog())
                        {
                            throw new Exception("User cancelled");
                        }
                    }

                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }

                    if (iCount > 0)
                    {
                        tran.Commit();
                        MessageBox.Show("Success");

                        SetTxtNull();
                    }
                    else
                    {
                        throw new Exception("Save failed");
                    }
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox frm = new FrmMsgBox();
                frm.richTextBox1.Text = ee.Message;
                frm.ShowDialog();
            }
        }

        private void SetTxtNull()
        {
            gridControlIN.DataSource = null;
            gridControlPL.DataSource = null;
            txtCompany.Text = "";
            txtInvoiceNO.Text = "";
            dateEdit1.Text = "";
            dtmBL.Text = "";
            txtBL.Text = "";
            txtCurrency.Text = "";

            dateEditQuery.Text = "";
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                FrmSEL_ImportPackingList_Invoice frm = new FrmSEL_ImportPackingList_Invoice();
                frm.StartPosition = FormStartPosition.CenterParent;
                if (frm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                dateEditQuery.DateTime = frm.dtmReturn;

                string sDateTime = dateEditQuery.DateTime.ToString("yyyy-MM-dd");
                string sInvoiceNo = frm.sInvoiceNo;
                string sSQL = @"
SELECT AutoID, ImportTime, InvoiceNo, Date, Companyname, PONO,inv.cInvAddCode as PARTNO, DESCRIPTIONENGLISH
	, cast(QUANTITY as decimal(16,2)) as QUANTITY 
	, cast(NW as decimal(16,2)) as NW
	, cast(GW as decimal(16,2)) as GW
	, cast(PRICEPERUNIT as decimal(16,2)) as PRICEPERUNIT, UNIT
	, cast(TOTALPRICE as decimal(16,2)) as TOTALPRICE
FROM      PurBillVouchs_Import a 
    left join Inventory inv on a.PARTNO = inv.cInvCode 
where InvoiceNo = 'aaaaaa' and Date = 'bbbbbb'
order by Autoid
";
                sSQL = sSQL.Replace("aaaaaa", sInvoiceNo);
                sSQL = sSQL.Replace("bbbbbb", sDateTime);
                DataTable dtIN = DbHelperSQL.Query(sSQL);
                if (dtIN != null && dtIN.Rows.Count > 0)
                {
                    txtCompany.Text = dtIN.Rows[0]["Companyname"].ToString().Trim();
                    txtInvoiceNO.Text = dtIN.Rows[0]["InvoiceNo"].ToString().Trim();
                    dateEdit1.DateTime = BaseFunction.ReturnDate(dtIN.Rows[0]["Date"]);
                    gridControlIN.DataSource = dtIN;
                    gridViewIN.BestFitColumns();
                }

                sSQL = @"
SELECT  a.AutoID, ImportTime, InvoiceNo, Date, Companyname, PONO, CONTAINERNO, inv.cInvAddCode as PARTNO
	, DESCRIPTIONOFPRODUCTSEN, CASENO
	, BOXNO
	,cast( BOXQTY as int) as BOXQTY
	,cast( QUANTITY as decimal(16,2)) as QUANTITY, UNIT
	, cast(NWKGS as decimal(16,2)) as NWKGS
	,cast( GWKGS as decimal(16,2)) as GWKGS
    ,cast( UnitPrice as decimal(16,2)) as UnitPrice
	, BOXCBM, CONNO, POsID, Rds01ID, BLDate, BLNo
	,b.cPOID as U8PONO
	,c.cCode as U8RDCode
    ,a.Currency
    ,c.autoid as Rds01ID
FROM      RdRecords01_Import a left join
(
	select distinct a.cPOID,b.ID,b.cInvCode
	from PO_Pomain a inner join PO_Podetails b on a.POID = b.POID
)b on a.POsID = b.ID  and a.PARTNO = b.cInvCode
	LEFT JOIN
(
	select distinct a.cCode,b.autoid
	from Rdrecord01 a inner join rdrecords01 b on a.id = b.id
) c on a.Rds01ID = c.autoid 
    left join Inventory inv on a.PARTNO = inv.cInvCode 
where a.InvoiceNo = 'aaaaaa' and a.Date = 'bbbbbb'
order by a.Autoid
";
                sSQL = sSQL.Replace("aaaaaa", sInvoiceNo);
                sSQL = sSQL.Replace("bbbbbb", sDateTime);
                DataTable dtPL = DbHelperSQL.Query(sSQL);
                if (dtPL != null && dtPL.Rows.Count > 0)
                {
                    txtCurrency.Text = dtPL.Rows[0]["Currency"].ToString().Trim();
                    txtBL.Text = dtPL.Rows[0]["BLNo"].ToString().Trim();
                    dtmBL.DateTime = BaseFunction.ReturnDate(dtPL.Rows[0]["BLDate"]);
                    gridControlPL.DataSource = dtPL;
                    gridViewPL.BestFitColumns();
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox frm = new FrmMsgBox();
                frm.richTextBox1.Text = ee.Message;
                frm.ShowDialog();

                SetTxtNull();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to delete it?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != DialogResult.Yes)
                {
                    throw new Exception("User cancelled");
                }

                string sErr = "";
                int iCount = 0;
                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    string sDateTime = dateEditQuery.DateTime.ToString("yyyy-MM-dd");
                    string sInvoiceNo = txtInvoiceNO.Text.Trim();

                    //判断是否已经生成采购入库单
                    if (bExistsRD(dateEdit1.DateTime, tran) > 0)
                    {
                        throw new Exception("Purchase receipt warrant is exists");
                    }

                    string sSQL = "delete [PurBillVouchs_Import] where InvoiceNo = 'bbbbbb'";
                    sSQL = sSQL.Replace("aaaaaa", sDateTime);
                    sSQL = sSQL.Replace("bbbbbb", sInvoiceNo);
                    iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = "delete [Rdrecords01_Import] where InvoiceNo = 'bbbbbb'";
                    sSQL = sSQL.Replace("aaaaaa", sDateTime);
                    sSQL = sSQL.Replace("bbbbbb", sInvoiceNo);
                    iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    if (iCount == 0)
                    {
                        throw new Exception("Delete data failure, not data");
                    }

                    tran.Commit();

                    MessageBox.Show("Delete success");

                    SetTxtNull();
                }


                catch (Exception ee)
                {

                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox frm = new FrmMsgBox();
                frm.richTextBox1.Text = ee.Message;
                frm.ShowDialog();
            }
        }


        /// <summary>
        /// //判断是否已经生成入库单
        /// </summary>
        /// <param name="sDateTime"></param>
        /// <param name="tran"></param>
        /// <returns> -1 错误,0 未生成入库单，>0 已生成入库单</returns>
        private int bExistsRD(DateTime sDateTime, SqlTransaction tran)
        {
            int iRet = -1;
            try
            {
                string sAutoID = "";
                for (int i = 0; i < gridViewPL.RowCount; i++)
                {
                    if (sAutoID == "")
                    {
                        sAutoID = gridViewPL.GetRowCellValue(i, gridColAutoID).ToString().Trim();
                    }
                    else
                    {
                        sAutoID = sAutoID + "," + gridViewPL.GetRowCellValue(i, gridColAutoID).ToString().Trim();
                    }
                }

                string sSQL = @"
SELECT  a.AutoID, ImportTime, InvoiceNo, Date, Companyname, PONO, CONTAINERNO, PARTNO
	, DESCRIPTIONOFPRODUCTSEN, CASENO
	, BOXNO
	,cast( BOXQTY as int) as BOXQTY
	,cast( QUANTITY as decimal(16,2)) as QUANTITY, UNIT
	, cast(NWKGS as decimal(16,2)) as NWKGS
	,cast( GWKGS as decimal(16,2)) as GWKGS
    ,cast( UnitPrice as decimal(16,2)) as UnitPrice
	, BOXCBM, CONNO, POsID, Rds01ID, BLDate, BLNo
	,b.cPOID as U8PONO
	,c.cCode as U8RDCode
FROM      RdRecords01_Import a left join
(
	select distinct a.cPOID,b.ID,b.cInvCode
	from PO_Pomain a inner join PO_Podetails b on a.POID = b.POID
)b on a.POsID = b.ID  and a.PARTNO = b.cInvCode
	LEFT JOIN
(
	select distinct a.cCode,b.autoid
	from Rdrecord01 a inner join rdrecords01 b on a.id = b.id
) c on a.Rds01ID = c.autoid 
where  a.AutoID in (aaaaaa) and isnull(c.cCode,'') <> ''
order by a.Autoid
";
                sSQL = sSQL.Replace("aaaaaa", sAutoID);
                DataTable dtPL = DbHelperSQL.Query(sSQL);

                iRet = dtPL.Rows.Count;
            }
            catch (Exception ee)
            {
                iRet = -1;
            }
            return iRet;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                SetTxtNull();
            }
            catch { }
        }

        private void btnDelRow_Click(object sender, EventArgs e)
        {
            try
            {
                if (xtraTabControl1.SelectedTabPage == xtp1)
                {
                    gridViewPL.DeleteSelectedRows();
                }
                else
                {
                    gridViewIN.DeleteSelectedRows();
                }
            }
            catch { }
        }

        private void gridViewPL_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    string s1 = gridViewPL.GetRowCellValue(e.RowHandle, gridColU8RDCode).ToString().Trim();
                    if (s1 != "")
                    {
                        e.Appearance.BackColor = Color.LightYellow;
                    }
                }
            }
            catch
            {

            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                gridViewIN.FocusedRowHandle -= 1;
                gridViewIN.FocusedRowHandle += 1;

                gridViewPL.FocusedRowHandle -= 1;
                gridViewPL.FocusedRowHandle += 1;
            }
            catch { }

            try
            {
                if (gridViewIN.RowCount == 0 || gridViewPL.RowCount == 0)
                {
                    throw new Exception("No data");
                }

                if (dateEdit1.DateTime < BaseFunction.ReturnDate("2017-01-01"))
                {
                    throw new Exception("Date is err");
                }

                decimal dPLSum = BaseFunction.ReturnDecimal(gridViewPL.Columns["QUANTITY"].SummaryItem.SummaryValue);
                decimal dINSum = BaseFunction.ReturnDecimal(gridViewIN.Columns["QUANTITY"].SummaryItem.SummaryValue);
                if (dPLSum != dINSum)
                {
                    throw new Exception("Please check the quantity");
                }

                string sErr = "";
                int iCount = 0;
                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    CheckData(tran);

                    tran.Commit();
                    MessageBox.Show("CHECK OK");
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox frm = new FrmMsgBox();
                frm.richTextBox1.Text = ee.Message;
                frm.ShowDialog();
            }
        }

        private void CheckData(SqlTransaction tran)
        {
            try
            {
                string sErr = "";

                string sDate = dateEdit1.DateTime.ToString("yyyy-MM-dd");
                string sInvoiceNo = txtInvoiceNO.Text.Trim();
                string sSQL = @"
SELECT InvoiceNo,[Date] FROM [dbo].[PurBillVouchs_Import] where InvoiceNo = 'aaaaaa'
union
SELECT InvoiceNo,[Date] FROM [dbo].[Rdrecords01_Import] where InvoiceNo = 'aaaaaa'
";
                sSQL = sSQL.Replace("aaaaaa", sInvoiceNo);
                DataTable dtExists = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtExists != null && dtExists.Rows.Count > 0)
                {
                    if (MessageBox.Show("The invoice number has been imported and whether to continue?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != DialogResult.Yes)
                    {
                        throw new Exception("User cancelled");
                    }
                }

                sSQL = "select * from foreigncurrency where cexch_code = 'aaaaaaaa' or cexch_name = 'aaaaaaaa'";
                sSQL = sSQL.Replace("aaaaaaaa", txtCurrency.Text.Trim());
                DataTable dtCurrency = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtCurrency == null || dtCurrency.Rows.Count == 0)
                {
                    throw new Exception("Currency does not exist");
                }


                sSQL = "select getdate()";
                DateTime dNow = BaseFunction.ReturnDate(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                DateTime dNowDate = BaseFunction.ReturnDate(dNow.ToString("yyyy-MM-dd"));
                string sDateTxt = dNow.ToString("yyyyMMddHHmmss");

                sSQL = "truncate table RdRecords01_Temp";
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                for (int i = 0; i < gridViewPL.RowCount; i++)
                {
                    Model.RdRecords01_Temp modRdsTemp = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.RdRecords01_Temp();
                    modRdsTemp.cInvCode = gridViewPL.GetRowCellValue(i, gridColPARTNO).ToString().Trim();
                    modRdsTemp.PONO = gridViewPL.GetRowCellValue(i, gridColPONO).ToString().Trim();
                    modRdsTemp.iQuantity = BaseFunction.ReturnDecimal(gridViewPL.GetRowCellValue(i, gridColQUANTITY), 6);

                    DAL.RdRecords01_Temp dalRdsTemp = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.RdRecords01_Temp();
                    sSQL = dalRdsTemp.Add(modRdsTemp);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }

                sSQL = "truncate table PurBillVouchs_Temp";
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                for (int i = 0; i < gridViewIN.RowCount; i++)
                {
                    Model.PurBillVouchs_Temp modINTemp = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.PurBillVouchs_Temp();
                    modINTemp.cInvCode = gridViewIN.GetRowCellValue(i, gridCol_PARTNO).ToString().Trim();
                    modINTemp.PONO = gridViewIN.GetRowCellValue(i, gridCol_PONO).ToString().Trim();
                    modINTemp.iQuantity = BaseFunction.ReturnDecimal(gridViewIN.GetRowCellValue(i, gridCol_QUANTITY), 6);

                    DAL.PurBillVouchs_Temp dalINTemp = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.PurBillVouchs_Temp();
                    sSQL = dalINTemp.Add(modINTemp);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }


                for (int i = 0; i < gridViewPL.RowCount; i++)
                {
                    string sInvAbbCode = gridViewPL.GetRowCellValue(i, gridColPARTNO).ToString().Trim();
                    if (sInvAbbCode.Trim() == "")
                        continue;

                    string sPONO = gridViewPL.GetRowCellDisplayText(i, gridColPONO).ToString().Trim();

                    //判断订单是否存在
                    sSQL = @"
select cPOID from PO_Pomain where cPOID = 'aaaaaa'
";
                    sSQL = sSQL.Replace("aaaaaa", sPONO);
                    DataTable dtCou = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtCou == null || dtCou.Rows.Count == 0)
                    {
                        sErr = sErr + "PL: line " + (i + 1).ToString() + " PO No does not match\n";
                        continue;
                    }

                    sSQL = @"
select * from Inventory where cInvCode = '{0}' or cInvAddCode = '{0}'
";
                    sSQL = string.Format(sSQL, sInvAbbCode);
                    DataTable dtInv = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtInv == null || dtInv.Rows.Count == 0)
                    {
                        sErr = sErr + "PL: Line " + (i + 1) + " cInvAddCode is not exists\n";
                        continue;
                    }

                    //判断订单是否存在物料
                    sSQL = @"
select a.cPOID ,b.cInvCode
from PO_Pomain a inner join PO_PODetails b on a.poid = b.poid 
    inner join Inventory inv on b.cInvCode = inv.cInvCode 
where a.cPOID = 'aaaaaa' and (b.cInvCode = 'bbbbbb' or inv.cInvAddCode = 'bbbbbb')
";
                    sSQL = sSQL.Replace("aaaaaa", gridViewPL.GetRowCellDisplayText(i, gridColPONO).ToString().Trim());
                    sSQL = sSQL.Replace("bbbbbb", sInvAbbCode);
                    dtCou = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtCou == null || dtCou.Rows.Count == 0)
                    {
                        sErr = sErr + "PL: line " + (i + 1).ToString() + "  PO No does not exist in this material\n";
                        continue;
                    }

                    sSQL = @"
select inv.cInvCode,isnull(inv.bPurchase,0) as bPurchase  
from Inventory  inv 
	inner join (
		select distinct b.cInvCode
		from PO_Pomain a inner join po_podetails b on a.POID = b.POID
		where a.cPOID = '{1}'
        ) po on inv.cInvCode = po.cInvCode
where inv.cInvAddCode = '{0}' or inv.cInvCode = '{0}'

";
                    sSQL = string.Format(sSQL, sInvAbbCode, gridViewPL.GetRowCellValue(i, gridColPONO).ToString().Trim());
                    dtInv = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtInv == null || dtInv.Rows.Count == 0)
                    {
                        sErr = sErr + "PL: Line " + (i + 1) + " cInvAddCode is not exists\n";
                        continue;
                    }
                    if (dtInv.Rows.Count > 1)
                    {
                        sSQL = @"
select cInvCode,isnull(bPurchase,0) as bPurchase  from Inventory where cInvAddCode = 'AAAAAAAA'
";
                        sSQL = sSQL.Replace("AAAAAAAA", sInvAbbCode);
                        dtInv = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtInv == null || dtInv.Rows.Count != 1)
                        {
                            sErr = sErr + "PL: Line " + (i + 1) + " cInvAddCode is non-unique and code is not exists,Excel line(PL) " + (i + 14) + "\n";
                            continue;
                        }
                    }
                    string sInvCode = dtInv.Rows[0]["cInvCode"].ToString().Trim();


                    if (!Convert.ToBoolean(dtInv.Rows[0]["bPurchase"]))
                    {
                        sErr = sErr + "PL: line " + (i + 1).ToString() + " inventory has no purchase attributes\n";
                        continue;
                    }

                    //判断是否生成了采购入库单
                    string sRdsID = gridViewPL.GetRowCellValue(i, gridColRds01ID).ToString().Trim();
                    if (sRdsID != "")
                    {
                        sSQL = @"
select Autoid from Rdrecords01 where autoid = aaaaaa
";
                        sSQL = sSQL.Replace("aaaaaa", sRdsID);
                        DataTable dtRds = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtRds != null && dtRds.Rows.Count > 0)
                        {
                            sErr = sErr + "PL: Line " + (i + 1) + " purchase receipt warrant is exists\n";
                            continue;
                        }
                    }

                    //  PONO ,containerNO ,PARTNO 相同的只允许导入一次
                    sSQL = @"
select * 
from Rdrecords01_Import 
where PONO = 'aaaaaa' AND CONTAINERNO = 'bbbbbb' AND PARTNO = 'cccccc'
";
                    sSQL = sSQL.Replace("aaaaaa", gridViewPL.GetRowCellDisplayText(i, gridColPONO).ToString().Trim());
                    sSQL = sSQL.Replace("bbbbbb", gridViewPL.GetRowCellDisplayText(i, gridColCONTAINERNO).ToString().Trim());
                    sSQL = sSQL.Replace("cccccc", sInvCode);
                    dtCou = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtCou != null && dtCou.Rows.Count > 0)
                    {
                        sErr = sErr + "PL: line " + (i + 1).ToString() + " PONO CONTAINERNO PARTNO have been imported\n";
                        continue;
                    }


                    //判断入库单与发票是否存在不一致数据
                    sSQL = @"
if object_id('tempdb..#_Temp') is not null 
	drop table #_Temp

select a.cInvCode,a.PONO,sum(a.iQuantity) as iINQty,cast(null as decimal(16,6)) as iRDQty
into #_Temp
from PurBillVouchs_Temp a 
where a.cInvCode = 'aaaaaa'
group by a.cInvCode,a.PONO

insert into #_Temp
select a.cInvCode,a.PONO,cast(null as decimal(16,6))  as iINQty,sum(a.iQuantity) as iRDQty
from Rdrecords01_Temp a 
where a.cInvCode = 'aaaaaa'
group by  a.cInvCode,a.PONO

select count(1) as iCou,cInvCode,PONO,sum(iINQty) as iINQty, sum(iRDQty) as iRDQty
from #_Temp
group by cInvCode,PONO
having sum(isnull(iINQty,0)) <> sum(isnull(iRDQty,0))
";
                    sSQL = sSQL.Replace("aaaaaa", sInvCode);
                    dtCou = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtCou != null && dtCou.Rows.Count > 0)
                    {
                        sErr = sErr + "PL: Excel line " + (i + 1).ToString() + " IN & PL is not equal\n";
                        continue;
                    }

                    //判断入库单是否超出订单
                    sSQL = @"
if object_id('tempdb..#_Temp2') is not null 
	drop table #_Temp2

select a.cPOID,b.cInvCode,sum(b.iQuantity) as iQtyPO,cast(null as decimal(16,6)) as iRDQty
into #_Temp2
from PO_Pomain a inner join po_podetails b on a.poid = b.poid
where b.cInvCode = 'aaaaaa' and a.cPOID = 'bbbbbb'
group by a.cPOID,b.cInvCode

insert into #_Temp2
select a.PONO,a.cInvCode,cast(null as decimal(16,6)) as iQtyPO,sum(a.iQuantity) as iRDQty
from  Rdrecords01_Temp a 
where a.cInvCode = 'aaaaaa' and a.PONO = 'bbbbbb'
group by  a.cInvCode,a.PONO

select count(1) as iCou,cInvCode,cPOID,sum(iQtyPO) as iINQty, sum(iRDQty) as iRDQty
from #_Temp2
group by cInvCode,cPOID
having sum(isnull(iQtyPO,0)) < sum(isnull(iRDQty,0))
";
                    sSQL = sSQL.Replace("aaaaaa", sInvCode);
                    sSQL = sSQL.Replace("bbbbbb", gridViewPL.GetRowCellDisplayText(i, gridColPONO).ToString().Trim());
                    dtCou = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtCou != null && dtCou.Rows.Count > 0)
                    {
                        sErr = sErr + "PL: PO No line " + (i + 1).ToString() + " overorder entry\n";
                        continue;
                    }
                }



                for (int i = 0; i < gridViewIN.RowCount; i++)
                {
                    string sPONO = gridViewIN.GetRowCellValue(i, gridCol_PONO).ToString().Trim();
                    string sInvAbbCode = gridViewIN.GetRowCellValue(i, gridCol_PARTNO).ToString().Trim();
                    if (sInvAbbCode.Trim() == "")
                        continue;

                    //判断订单是否存在
                    sSQL = @"
select cPOID from PO_Pomain where cPOID = 'aaaaaa'
";
                    sSQL = sSQL.Replace("aaaaaa", sPONO);
                    DataTable dtCou = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtCou == null || dtCou.Rows.Count == 0)
                    {
                        sErr = sErr + "IN: line " + (i + 1).ToString() + " PO No does not match\n";
                        continue;
                    }

                    sSQL = @"
select * from Inventory where cInvCode = '{0}' or cInvAddCode = '{0}'
";
                    sSQL = string.Format(sSQL, sInvAbbCode);
                    DataTable dtInv = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtInv == null || dtInv.Rows.Count == 0)
                    {
                        sErr = sErr + "IN: Line " + (i + 1) + " cInvAddCode is not exists\n";
                        continue;
                    }

                    //判断订单是否存在物料
                    sSQL = @"
select a.cPOID ,b.cInvCode
from PO_Pomain a inner join PO_PODetails b on a.poid = b.poid 
    inner join Inventory inv on b.cInvCode = inv.cInvCode 
where a.cPOID = 'aaaaaa' and (b.cInvCode = 'bbbbbb' or inv.cInvAddCode = 'bbbbbb')
";
                    sSQL = sSQL.Replace("aaaaaa", gridViewIN.GetRowCellDisplayText(i, gridCol_PONO).ToString().Trim());
                    sSQL = sSQL.Replace("bbbbbb", sInvAbbCode);
                    dtCou = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtCou == null || dtCou.Rows.Count == 0)
                    {
                        sErr = sErr + "IN: line " + (i + 1).ToString() + "  PO No does not exist in this material\n";
                        continue;
                    }

                    sSQL = @"
select inv.cInvCode,isnull(inv.bPurchase,0) as bPurchase  
from Inventory  inv 
	inner join (
		select distinct b.cInvCode
		from PO_Pomain a inner join po_podetails b on a.POID = b.POID
		where a.cPOID = '{1}'
        ) po on inv.cInvCode = po.cInvCode
where inv.cInvAddCode = '{0}' or inv.cInvCode = '{0}'

";
                    sSQL = string.Format(sSQL, sInvAbbCode, gridViewIN.GetRowCellValue(i, gridCol_PONO).ToString().Trim());
                    dtInv = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtInv == null || dtInv.Rows.Count == 0)
                    {
                        sErr = sErr + "IN: Line " + (i + 1) + " cInvAddCode is not exists\n";
                        continue;
                    }
                    if (dtInv.Rows.Count > 1)
                    {
                        sSQL = @"
select cInvCode,isnull(bPurchase,0) as bPurchase  from Inventory where cInvAddCode = 'AAAAAAAA'
";
                        sSQL = sSQL.Replace("AAAAAAAA", sInvAbbCode);
                        dtInv = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtInv == null || dtInv.Rows.Count != 1)
                        {
                            sErr = sErr + "IN: Line " + (i + 1) + " cInvAddCode is non-unique and code is not exists,Excel line(PL) " + (i + 14) + "\n";
                            continue;
                        }
                    }
                    string sInvCode = dtInv.Rows[0]["cInvCode"].ToString().Trim();

                    //防止有空数据
                    if (sInvCode != "")
                    {
                        decimal dPrice = BaseFunction.ReturnDecimal(gridViewIN.GetRowCellValue(i, gridCol_PRICEPERUNIT));
                        decimal dSum = BaseFunction.ReturnDecimal(gridViewIN.GetRowCellValue(i, gridCol_TOTALPRICE));

                        if (dPrice <= 0 || dSum <= 0)
                        {
                            sErr = sErr + "IN: Line " + (i + 1) + " unit price or amount is not correct\n";
                            continue;
                        }
                    }
                }

                if (sErr != "")
                {
                    throw new Exception(sErr);
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }
    }
}
