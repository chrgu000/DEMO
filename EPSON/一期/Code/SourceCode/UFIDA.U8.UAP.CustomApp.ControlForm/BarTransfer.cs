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
    public partial class BarTransfer : UserControl
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

        string sSQLBar = @"
SELECT
    CAST(1 AS BIT) AS CHOOSE
    ,CAST(NULL AS VARCHAR(50)) AS sErr
	,a.BarCode AS LotNO,c.cSOCode ,b.iRowNo AS SaleOrderRow,b.iSOsID
	,b.cInvCode AS ItemNO,d.cInvName AS [Description],c.cCusCode
	,CAST(b.iQuantity AS DECIMAL(16,2)) AS OrderQTY
	,a.LOTQTY,a.LOTQTY2,c.cDepCode AS DEPT	
    ,a.Process
    ,a.Batch as cBatch
	,f.RoutingTo AS ProcessNext
    ,CAST(a.LOTQTY AS DECIMAL(16,2)) as OtherQTY
	,a.[Status],c.cSTCode
    ,a.RDType,a.RDsID
    ,getdate() as ScanTime
    ,IQCStatus 
    ,OQCStatus
    ,a.CloseUid
FROM [dbo].[_BarCodeLabel] a 
	INNER JOIN dbo.SO_SODetails b ON a.iSOsID = b.iSOsID
	INNER JOIN dbo.SO_SOMain c ON b.ID = c.ID
	INNER JOIN inventory d ON b.cInvCode = d.cInvCode
	LEFT JOIN dbo.[_SystemSet] e ON e.cSTCode = c.cSTCode
	LEFT JOIN _RoutingInfo f ON f.RoutingForm = a.Process
WHERE 1=-1
    and a.iSOsID in (select max(iSOsID) from _BarCodeLabel group by BarCode)
	and isnull(a.[status],'') <> '发货' and isnull(a.[status],'') <> 'Pending'
order by iSOsID desc
";

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                labelErr.Text = "　　　　";

                DbHelperSQL.connectionString = Conn;

                SetLookUp();

                DataTable dtGrid = DbHelperSQL.Query(sSQLBar);
                gridControl1.DataSource = dtGrid;
                gridColScanTime.SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void SetLookUp()
        {
            string sSQL = "select cWhCode ,cWhName from WareHouse order by cWhCode";
            DataTable dt = DbHelperSQL.Query(sSQL);
            lookUpEditProcess.Properties.DataSource = dt;
            lookUpEditProcessNext.Properties.DataSource = dt;

            ItemLookUpEditProcess.DataSource = dt;
        }

        public BarTransfer()
        {
            InitializeComponent();
        }

        private void GetGrid()
        {
            try
            {
                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {

                    if (lookUpEditProcess.Text.Trim() == "")
                    {
                        lookUpEditProcess.Focus();
                        throw new Exception("Please choose process");
                    }

                    if (lookUpEditProcessNext.Text.Trim() == "")
                    {
                        lookUpEditProcessNext.Focus();
                        throw new Exception("Please choose new process");
                    }


                    string sBarCodeScan = txtBarCode.Text.Trim();
                    txtBarCode2.Text = txtBarCode.Text.Trim();

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        string sBarCode = gridView1.GetRowCellValue(i, gridColLotNO).ToString().Trim();
                        if (sBarCode == txtBarCode.Text.Trim())
                        {
                            labelErr.BackColor = Color.Red;
                            labelErr.Text = "Barcode is scanned";
                            txtBarCode.Text = "";
                            return;
                        }
                    }

                    string sSQL = sSQLBar.Replace("1=-1", "1=1 and a.BarCode = '" + sBarCodeScan + "'");

                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        labelErr.BackColor = Color.Red;
                        labelErr.Text = "not exists";
                        txtBarCode.Text = "";
                        return;
                    }

                    //非检验物料不可转入QC仓库
                    sSQL = @"
select * from Warehouse where cWhCode = '{0}' and (cWhMemo like '%{1}%' or cWhMemo like '%{2}%')
";
                    sSQL = string.Format(sSQL, lookUpEditProcessNext.Text.Trim(), "IQC", "OQC");
                    DataTable dtWhQC = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtWhQC != null && dtWhQC.Rows.Count > 0)
                    {
                        string sInvCode = dt.Rows[0]["ItemNo"].ToString().Trim();
                        sSQL = @"
select *
from Inventory_extradefine
where cInvCode = '{0}'
";
                        sSQL = string.Format(sSQL, sInvCode);
                        DataTable dtQC = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        decimal dQC = BaseFunction.ReturnDecimal(dtQC.Rows[0]["cidefine4"]);
                        if (dQC == 0)
                        {
                            labelErr.Text = "Item no QC err";
                            txtBarCode.Text = "";
                            txtBarCode.Focus();
                            return;
                        }
                    }

                    if (BaseFunction.ReturnDecimal(dt.Rows[0]["LotQTY"]) == 0)
                    {
                        labelErr.BackColor = Color.Red;
                        labelErr.Text = "Lotqty is 0";
                        txtBarCode.Text = "";
                        return;
                    }

                    if (dt.Rows[0]["CloseUid"].ToString().Trim() != "")
                    {
                        labelErr.BackColor = Color.Red;
                        labelErr.Text = "BarCode is closed";
                        txtBarCode.Text = "";
                        return;
                    }

                    string sStatus = BaseFunction.ReturnStatus(dt.Rows[0]["status"].ToString().Trim()).ToLower();
                    string sStatusIQC = dt.Rows[0]["iqcstatus"].ToString().Trim().ToLower().Replace(" ", "");
                    string sStatusOQC = dt.Rows[0]["oqcstatus"].ToString().Trim().ToLower().Replace(" ", "");

                    #region 来料检验

                    if (sStatus == "iqc")
                    {
                        if (sStatusIQC == "pendingiqc")
                        {
                            txtBarCode.Text = "";
                            txtBarCode.Focus();
                            throw new Exception("Lot no is pending err\n");
                        }

                        if (sStatusIQC == "IQC-ONHOLD".ToLower())
                        {
                            txtBarCode.Text = "";
                            txtBarCode.Focus();
                            throw new Exception("Lot no is ONHOLD err\n");
                        }

                        //SORT ,条形码必须先做拆分
                        if (sStatusIQC == "IQC-SORT".ToLower())
                        {
                            sSQL = @"
select *
from _BarStatus
where iID = (select max(iID) from _BarStatus where [BarCode] = '{0}' and iSOsID = '{1}')
";
                            sSQL = string.Format(sSQL, sBarCodeScan, dt.Rows[0]["iSOsID"]);
                            DataTable dtBarStatus = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                            if (BaseFunction.ReturnDecimal(dt.Rows[0]["LOTQTY"]) == BaseFunction.ReturnDecimal(dtBarStatus.Rows[0]["QTY"]))
                            {
                                throw new Exception("Please split first");
                            }
                        }

                        //RETURN ,条形码必须退回客户，进RETURN仓库
                        if (sStatusIQC == "IQC-RETURN".ToLower())
                        {
                            sSQL = @"
SELECT *
FROM WAREHOUSE 
WHERE cWhCode = '{0}' and cWhMemo = 'R'
";
                            sSQL = string.Format(sSQL, lookUpEditProcessNext.EditValue.ToString().Trim());
                            DataTable dtProcessNext = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                            if (dtProcessNext == null || dtProcessNext.Rows.Count == 0)
                            {
                                if (gridView1.RowCount == 0)
                                {
                                    lookUpEditProcessNext.Enabled = true;
                                }

                                throw new Exception("Next Warehouse is not for return");
                            }

                        }
                    }
                    #endregion

                    #region 出库检验

                    if (sStatus == "oqc")
                    {
                        if (sStatusOQC == "pendingoqc")
                        {
                            txtBarCode.Text = "";
                            txtBarCode.Focus();
                            throw new Exception("Lot no is pending err\n");
                        }

                        if (sStatusOQC == "OQC-ONHOLD".ToLower())
                        {
                            txtBarCode.Text = "";
                            txtBarCode.Focus();
                            throw new Exception("Lot no is ONHOLD err\n");
                        }
                    }
                    #endregion

                    string sProcess = dt.Rows[0]["Process"].ToString().Trim();

                    if (sProcess != lookUpEditProcess.EditValue.ToString().Trim())
                    {
                        labelErr.BackColor = Color.Red;
                        labelErr.Text = "Process is err";
                        txtBarCode.Text = "";
                        return;
                    }

                    string sQCStatus = dt.Rows[0]["IQCStatus"].ToString().Trim().ToLower();
                    sQCStatus = sQCStatus.Replace(" ", "");
                    if (sQCStatus == "pendingqc")
                    {
                        throw new Exception("Lot no is pending qc err\n");
                    }

                    if (lookUpEditProcessNext.EditValue != null && lookUpEditProcessNext.EditValue.ToString().Trim() != "")
                    {
                        dt.Rows[0]["ProcessNext"] = lookUpEditProcessNext.EditValue.ToString();
                    }

                    DataTable dtGrid = (DataTable)(gridControl1.DataSource);
                    dtGrid.ImportRow(dt.Rows[0]);
                    gridControl1.DataSource = dtGrid;
                    gridView1.BestFitColumns();

                    labelErr.BackColor = Color.Green;
                    labelErr.Text = "        ";
                    txtBarCode.Text = "";
                    txtBarCode.Focus();

                    if (dtGrid == null || dtGrid.Rows.Count == 0)
                    {
                        lookUpEditProcess.Enabled = true;
                        lookUpEditProcessNext.Enabled = true;
                    }
                    else
                    {
                        lookUpEditProcess.Enabled = false;
                        lookUpEditProcessNext.Enabled = false;
                    }
                    gridColScanTime.SortOrder = DevExpress.Data.ColumnSortOrder.Descending;

                    tran.Commit();
                }
                catch (Exception ee)
                {
                    tran.Rollback();

                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                labelErr.BackColor = Color.Red;
                labelErr.Text = ee.Message;
                txtBarCode.Text = "";
            }
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode != Keys.Enter)
                    return;

                if (txtBarCode.Text.Trim() == "")
                {
                    MessageBox.Show("Please scan barcode");
                    return;
                }

                GetGrid();

                gridView1.FocusedRowHandle = 0;
            }
            catch (Exception ee)
            {
                txtBarCode.Text = "";
                txtBarCode.Focus();
                MessageBox.Show("Err" + ee.Message);

            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBarCode.Text.Trim() == "")
                {
                    MessageBox.Show("Please scan barcode");
                    return;
                }

                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }


        private void SetTxtNull()
        {
            txtBarCode.Text = "";

            lookUpEditProcess.EditValue = null;
            lookUpEditProcessNext.EditValue = null;
            lookUpEditProcess.Enabled = true;
            lookUpEditProcessNext.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            txtBarCode.Focus();
            string sErr = "";

            int iCount = 0;
            try
            {
                string sProcess = gridView1.GetRowCellValue(0, gridColProcess).ToString().Trim();
                string sProcessNext = gridView1.GetRowCellValue(0, gridColProcessNext).ToString().Trim();
                if (sProcess == sProcessNext)
                {
                    throw new Exception("Process is err");
                }

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sSQL = "select getdate()";
                    DateTime dNow = BaseFunction.ReturnDate(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                    DateTime dNowDate = BaseFunction.ReturnDate(dNow.ToString("yyyy-MM-dd"));

                    int iYear = dNow.Year;
                    int iPeriod = dNow.Month;
                    string s期间 = BaseFunction.ReturnDate(iYear.ToString() + "-" + iPeriod.ToString() + "-01").ToString("yyyyMM");
                    sSQL = "select isnull(bflag_ST,0) as bflag from GL_mend where iYPeriod = '" + s期间 + "'";
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        throw new Exception("Access module state failure");
                    }
                    int i结账 = BaseFunction.ReturnInt(dt.Rows[0]["bflag"]);
                    if (i结账 > 0)
                    {
                        throw new Exception(dNow.ToString("yyyy-MM") + " have checked out");
                    }

                    //判断是否转入质检工序
                    bool bIQCIn = false;  //材料入库检验
                    bool bOQCIn = false;  //产品销售出库检验
                    sSQL = @"
select cWhMemo
from Warehouse 
where cWhCode = '{0}'
";
                    sSQL = string.Format(sSQL, lookUpEditProcessNext.EditValue.ToString().Trim());
                    dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt.Rows[0]["cWhMemo"].ToString().Trim().ToLower().Contains("iqc"))
                    {
                        bIQCIn = true;
                    }
                    if (dt.Rows[0]["cWhMemo"].ToString().Trim().ToLower().Contains("oqc"))
                    {
                        bOQCIn = true;
                    }


                    //判断是否从质检工序转出
                    bool bIQCOut = false;  //材料入库检验工序转出
                    bool bOQCOut = false;  //产品销售出库检验工序转出
                    sSQL = @"
select cWhMemo
from Warehouse 
where cWhCode = '{0}'
";
                    sSQL = string.Format(sSQL, lookUpEditProcess.EditValue.ToString().Trim());
                    dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt.Rows[0]["cWhMemo"].ToString().Trim().ToLower().Contains("iqc"))
                    {
                        bIQCOut = true;
                    }
                    if (dt.Rows[0]["cWhMemo"].ToString().Trim().ToLower().Contains("oqc"))
                    {
                        bOQCOut = true;
                    }

                    #region 流转

                    long lID = -1;
                    long lIDDetails = -1;
                    sSQL = @"
declare @p5 int
set @p5=aaaaaa
declare @p6 int
set @p6=bbbbbb
exec sp_GetId N'00',N'dddddd',N'tr',1,@p5 output,@p6 output,default
select @p5, @p6
";
                    sSQL = sSQL.Replace("aaaaaa", lID.ToString());
                    sSQL = sSQL.Replace("bbbbbb", lIDDetails.ToString());
                    sSQL = sSQL.Replace("dddddd", sAccID);
                    dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    lID = BaseFunction.ReturnLong(dt.Rows[0][0]) - 1;
                    lIDDetails = BaseFunction.ReturnLong(dt.Rows[0][1]) - 1;

                    ////获得单据号
                    sSQL = "select * from VoucherHistory with (ROWLOCK) Where CardNumber='0304' AND cContentRule = 'YYYY' AND cSeed = 'aaaaaa'";
                    sSQL = sSQL.Replace("aaaaaa", dNow.ToString("yyyy"));
                    dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    long lCode = 0;
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        lCode = BaseFunction.ReturnLong(dt.Rows[0]["cNumber"]);
                    }
                    else
                    {
                        lCode = 0;
                    }
                    lCode += 1;
                    string sCode = lCode.ToString();
                    while (sCode.Length < 6)
                    {
                        sCode = "0" + sCode;
                    }
                    sCode = "TR" + dNow.ToString("yyyy") + sCode;

                    Model.TransVouch mod = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.TransVouch();
                    mod.cTVCode = sCode;
                    mod.dTVDate = dNowDate;
                    mod.cOWhCode = lookUpEditProcess.EditValue.ToString().Trim();
                    mod.cIWhCode = lookUpEditProcessNext.EditValue.ToString().Trim();
                    mod.cODepCode = null;
                    mod.cIDepCode = null;
                    mod.cPersonCode = null;
                    mod.cIRdCode = "TI";
                    mod.cORdCode = "TO";
                    mod.cTVMemo = null;
                    mod.cDefine1 = null;
                    mod.cDefine2 = null;
                    mod.cDefine3 = null;
                    mod.cDefine4 = null;
                    mod.cDefine5 = null;
                    mod.cDefine6 = null;
                    mod.cDefine7 = null;
                    mod.cDefine8 = null;
                    mod.cDefine9 = null;
                    mod.cDefine10 = null;
                    mod.cAccounter = null;
                    mod.iNetLock = 1;
                    lID += 1;
                    mod.ID = lID;
                    mod.VT_ID = 89;
                    mod.cMaker = sUserName;
                    mod.dnmaketime = dNow;

                    mod.cVerifyPerson = sUserName;
                    mod.dVerifyDate = dNowDate;
                    mod.cPSPCode = null;
                    mod.cMPoCode = null;
                    mod.iQuantity = 0;
                    mod.bTransFlag = null;
                    mod.cDefine11 = null;
                    mod.cDefine12 = null;
                    mod.cDefine13 = null;
                    mod.cDefine14 = null;
                    mod.cDefine15 = null;
                    mod.cDefine16 = null;
                    mod.iproorderid = null;
                    mod.cTranRequestCode = null;
                    mod.cVersion = null;
                    mod.BomId = null;
                    mod.cFree1 = null;
                    mod.cFree2 = null;
                    mod.cFree3 = null;
                    mod.cFree4 = null;
                    mod.cFree5 = null;
                    mod.cFree6 = null;
                    mod.cFree7 = null;
                    mod.cFree8 = null;
                    mod.cFree9 = null;
                    mod.cFree10 = null;
                    mod.cAppTVCode = null;
                    mod.csource = "1";
                    mod.itransflag = "正向";
                    mod.cModifyPerson = null;
                    mod.dModifyDate = null;
                    mod.dnmaketime = dNow;
                    mod.dnmodifytime = null;
                    mod.ireturncount = null;
                    mod.iverifystate = null;
                    mod.iswfcontrolled = 0;
                    mod.csourceguid = null;
                    mod.csysbarcode = "||st12||" + mod.cTVCode;
                    DAL.TransVouch dalTR = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.TransVouch();
                    sSQL = dalTR.Add(mod);
                    iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    mod.cCurrentAuditor = null;

                    int iRow = 0;
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (!BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColchoose)))
                            continue;

                        string sBarCode = gridView1.GetRowCellValue(i, gridColLotNO).ToString().Trim();
                        sSQL = @"
select * from _BarCodeLabel  where [BarCode] = '{0}' and iSOsID = {1}" ;
                        sSQL = string.Format(sSQL, sBarCode, gridView1.GetRowCellValue(i, gridColiSOsID).ToString());
                        dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt == null || dt.Rows.Count == 0)
                        {
                            sErr = sErr + "row " + (i + 1).ToString() + "is not exists \n";
                            continue;
                        }
                        if (dt.Rows[0]["CloseUid"].ToString().Trim() != "")
                        {
                            sErr = sErr + "row " + (i + 1).ToString() + " is closed \n";
                            continue;
                        }
                        if (dt.Rows[0]["Process"].ToString().Trim().ToLower() != lookUpEditProcess.EditValue.ToString().Trim().ToLower())
                        {
                            sErr = sErr + "row " + (i + 1).ToString() + "  process is changed \n";
                            continue;
                        }
                        if (BaseFunction.ReturnDecimal(dt.Rows[0]["LotQTY"]) != BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColLOTQTY)))
                        {
                            sErr = sErr + "row " + (i + 1).ToString() + " number is changed \n";
                            continue;
                        }
                        if (dt.Rows[0]["IQCStatus"].ToString() != gridView1.GetRowCellValue(i, gridColIQCStatus).ToString().Trim())
                        {
                            sErr = sErr + "row " + (i + 1).ToString() + " iqcstatus is changed \n";
                            continue;
                        }
                        if (dt.Rows[0]["OQCStatus"].ToString() != gridView1.GetRowCellValue(i, gridColOQCStatus).ToString().Trim())
                        {
                            sErr = sErr + "row " + (i + 1).ToString() + " iqcstatus is changed \n";
                            continue;
                        }

                        iRow += 1;
                        Model.BarStatus model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.BarStatus();
                        model.BarCode = sBarCode;
                        model.iSOsID = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColiSOsID));
                        model.Type = "工序流转";
                        if (bIQCIn)
                        {
                            model.Type = "IQC";

                            sSQL = @"
update  _IQC_RMDF set ClosedUid = '{0}',dtmClose = getdate()
where LotNo = '{1}' and iSOsID = '{2}' and isnull(ClosedUid,'') <> ''
";
                            sSQL = string.Format(sSQL, sUserID, model.BarCode, model.iSOsID);
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        if (bOQCIn)
                        {
                            model.Type = "OQC"; 
                        }

                        model.RoutingFrom = lookUpEditProcess.EditValue.ToString().Trim();
                        model.RoutingTo = lookUpEditProcessNext.EditValue.ToString().Trim();
                        model.UpdateTime = dNow;
                        model.QTY = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColLOTQTY));
                        model.CreateUid = sUserID;
                        model.CreateDate = dNow;
                        DAL.BarStatus dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.BarStatus();
                        sSQL = dal.Add(model);
                        iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        //回写上一道工序的结束时间
                        sSQL = @"
declare @iID int 
select @iID = max(iID)
from _BarStatus
where [BarCode] = '{0}' and iSOsID = '{1}'
    and iID < (
        select max(iID) as maxID
        from _BarStatus
        where [BarCode] = '{0}' and iSOsID = '{1}'
    )

update _BarStatus set EndTime = '{2}' where iID = @iID and [BarCode] = '{0}' and iSOsID = '{1}'
";
                        sSQL = string.Format(sSQL, sBarCode, model.iSOsID, dNow);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        if (bIQCOut)
                        {
                            sSQL = @"
select *
from _BarCodeLabel
where [BarCode] = '{0}' and iSOsID = '{1}'
";
                            sSQL = string.Format(sSQL, sBarCode, model.iSOsID);
                            DataTable dtQC = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            string sIQCStatus = dtQC.Rows[0]["IQCStatus"].ToString().Trim().ToLower() ;
                            sIQCStatus = sIQCStatus.Replace(" ", "");
                            if (!sIQCStatus.ToLower().StartsWith("iqc"))
                            {
                                sErr = sErr + "row " + (i + 1).ToString() + " IQC not passed \n";
                                continue;
                            }
                        }
                        if (bOQCOut)
                        {
                            sSQL = @"
select *
from _BarCodeLabel
where [BarCode] = '{0}' and iSOsID = '{1}'
";
                            sSQL = string.Format(sSQL, sBarCode, model.iSOsID);
                            DataTable dtQC = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            string sOQCStatus = dtQC.Rows[0]["OQCStatus"].ToString().Trim().ToLower();
                            sOQCStatus = sOQCStatus.Replace(sOQCStatus, " ");
                            if (sOQCStatus == "oqc-ONHOLD".ToLower())
                            {
                                sErr = sErr + "row " + (i + 1).ToString() + " OQC onhold \n";
                                continue;
                            }
                        }

                        //回写 BarCodeLabel
                        sSQL = "update [_BarCodeLabel] set process = '" + model.RoutingTo + "',Status = '流转' where [BarCode] = '" + sBarCode + "' and iSOsID = '" + model.iSOsID + "'";
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        if (bIQCIn)
                        {
                            sSQL = "update [_BarCodeLabel] set IQCStatus = 'Pending IQC',Status = 'IQC' where [BarCode] = '" + sBarCode + "' and iSOsID = '" + model.iSOsID + "'";
                            int iRunCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        if (bOQCIn)
                        {
                            sSQL = "update [_BarCodeLabel] set OQCStatus = 'Pending OQC',Status = 'OQC' where [BarCode] = '" + sBarCode + "' and iSOsID = '" + model.iSOsID + "'";
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }

                        Model.TransVouchs mods = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.TransVouchs();
                        mods.cTVCode = mod.cTVCode;
                        mods.cInvCode = gridView1.GetRowCellValue(i, gridColItemNO).ToString().Trim();
                        mods.iTVNum = null;
                        mods.iTVQuantity = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColLOTQTY));
                        lIDDetails += 1;
                        mods.autoID = lIDDetails;
                        mods.ID = mod.ID;
                        mods.bCosting = true;
                        mods.irowno = iRow;
                        mods.coutposcode = null;
                        mods.cinposcode = null;
                        mods.cTVBatch = gridView1.GetRowCellValue(i, gridColcBatch).ToString().Trim();


                        mods.cbsysbarcode = "||st12|" + mod.cTVCode + "|" + iRow.ToString();
                        DAL.TransVouchs dalTRs = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.TransVouchs();
                        sSQL = dalTRs.Add(mods);
                        iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }

                    if (lID > 1000000000)
                    {
                        lID = lID - 1000000000;
                    }
                    if (lIDDetails > 1000000000)
                    {
                        lIDDetails = lIDDetails - 1000000000;
                    }
                    sSQL = "update UFSystem..UA_Identity set iFatherId = " + lID.ToString() + ",iChildId = " + lIDDetails + " where cAcc_Id = '" + sAccID + "' and cVouchType = 'tr'";
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                    sSQL = @"
                    if exists(select * from VoucherHistory where CardNumber='0304' AND cContentRule = 'YYYY' AND cSeed = 'bbbbbb')
                    	update VoucherHistory set cNumber = aaaaaa  where CardNumber = '0304' AND cContentRule = 'YYYY' AND cSeed = 'bbbbbb'
                    else
                    	insert into VoucherHistory(CardNumber,cContent,cContentRule,cSeed,cNumber,bEmpty)
                    	values('0304','日期','YYYY','bbbbbb','aaaaaa',0)
                    ";
                    sSQL = sSQL.Replace("aaaaaa", lCode.ToString());
                    sSQL = sSQL.Replace("bbbbbb", dNow.ToString("yyyy"));
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    clsU8 cls = new clsU8();
                    cls.TransVouch_Audit_U8V111(tran, mod.cTVCode, sAccID, sUserName);


                    #endregion

                    if (iCount > 0)
                    {
                        tran.Commit();

                        MessageBox.Show("OK\n");

                        SetTxtNull();

                        gridControl1.DataSource = DbHelperSQL.Query(sSQLBar);
                        txtBarCode.Focus();
                    }
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
            gridColScanTime.SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                int iRow = e.RowHandle;
                decimal dLotQTY = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridColLOTQTY));
                decimal dOtherQTY = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridColOtherQTY));

                if (dOtherQTY < 0)
                {
                    MessageBox.Show("OtherQTY is err");
                    gridView1.SetRowCellValue(iRow, gridColOtherQTY, DBNull.Value);
                    gridView1.FocusedRowHandle = iRow;
                    gridView1.FocusedColumn = gridColOtherQTY;
                }
            }
            catch (Exception ee)
            { }
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

        private void btnDelRow_Click(object sender, EventArgs e)
        {
            try
            {
                int iRow = gridView1.FocusedRowHandle;
                string sBarCode = gridView1.GetRowCellValue(iRow, gridColLotNO).ToString().Trim();

                gridView1.DeleteRow(iRow);
            }
            catch { }
        }

        private void lookUpEditProcess_Validated(object sender, EventArgs e)
        {
            try
            {
                string sProcess = lookUpEditProcess.EditValue.ToString();
                string sSQL = @"
select * from [dbo].[_RoutingInfo] where RoutingForm = 'aaaaaa'
";
                sSQL = sSQL.Replace("aaaaaa", sProcess);
                DataTable dt = DbHelperSQL.Query(sSQL);
                if (dt != null && dt.Rows.Count > 0)
                {
                    lookUpEditProcessNext.EditValue = dt.Rows[0]["RoutingTo"];
                    txtBarCode.Focus();
                }
                else
                {
                    lookUpEditProcessNext.Focus();
                }
            }
            catch { }
        }

        private void lookUpEditProcess_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lookUpEditProcess_Validated(null, null);
            }
        }

        private void lookUpEditProcessNext_Leave(object sender, EventArgs e)
        {
            try
            {
                if (lookUpEditProcess.EditValue == lookUpEditProcessNext.EditValue && lookUpEditProcessNext.EditValue != null)
                {
                    lookUpEditProcessNext.EditValue = DBNull.Value;
                    lookUpEditProcessNext.Focus();
                    MessageBox.Show("Process and next process can not same");
                }
            }
            catch { }
        }
    }
}
