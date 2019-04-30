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
    public partial class BarAdjust : UserControl
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
    CAST(1 AS BIT) AS CHOOSE,CAST(NULL AS VARCHAR(50)) AS sErr
	,a.BarCode AS LotNO,c.cSOCode ,b.iRowNo AS SaleOrderRow,b.iSOsID
	,b.cInvCode AS ItemNO,d.cInvName AS [Description],c.cCusCode
	,CAST(b.iQuantity AS DECIMAL(16,2)) AS OrderQTY
	,a.LOTQTY,c.cDepCode AS DEPT	
    ,a.Process
    ,a.Batch as cBatch
	,f.RoutingTo AS ProcessNext
    ,CAST(a.LOTQTY AS DECIMAL(16,2)) as OtherQTY
	,case when a.[Status] = '新增' then 'New' 
          when a.[Status] = '新增-客供条码' then 'New-with Barcode' 
          when a.[Status] = '发货' then 'Delivery' 
          when a.[Status] = '关闭' then 'Closed' 
          when a.[Status] = '流转' then 'Transfer' 
          when a.[Status] = '调整' then 'Adjustment' 
      else a.[Status] end as [Status]

    ,c.cSTCode
    ,a.RDType,a.RDsID
	,c.cSTCode
FROM [dbo].[_BarCodeLabel] a 
	INNER JOIN dbo.SO_SODetails b ON a.iSOsID = b.iSOsID
	INNER JOIN dbo.SO_SOMain c ON b.ID = c.ID
	INNER JOIN inventory d ON b.cInvCode = d.cInvCode
	LEFT JOIN dbo.[_SystemSet] e ON e.cSTCode = c.cSTCode
	LEFT JOIN _RoutingInfo f ON f.RoutingForm = a.Process
WHERE 1=-1
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

            ItemLookUpEditProcess.DataSource = dt;
        }

        public BarAdjust()
        {
            InitializeComponent();
        }

        private void GetGrid()
        {
            string sBarCodeScan = txtBarCode.Text.Trim();
            txtBarCode2.Text = txtBarCode.Text.Trim();

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string sBarCode = gridView1.GetRowCellValue(i, gridColLotNO).ToString().Trim();
                if (sBarCode == txtBarCode.Text.Trim())
                {
                    labelErr.BackColor = Color.Red;
                    labelErr.Text = "is scanned";
                    txtBarCode.Text = "";
                    return;
                }
            }

            string sSQL = sSQLBar.Replace("1=-1", "1=1 and a.BarCode = '" + sBarCodeScan + "'");

            DataTable dt = DbHelperSQL.Query(sSQL);
            if (dt == null || dt.Rows.Count == 0)
            {
                labelErr.BackColor = Color.Red;
                labelErr.Text = "not exists";
                txtBarCode.Text = "";
                return;
            }

            string sStatus = BaseFunction.ReturnStatus(dt.Rows[0]["status"].ToString().Trim());
            if (sStatus.ToLower() == "pending")
            {
                throw new Exception("Lot no is pending err\n");
            }

            if (dt.Rows[0]["cSTCode"].ToString().ToLower() != "wp")
            {
                throw new Exception("It is not wp");
            }

            string sProcess = dt.Rows[0]["Process"].ToString().Trim();
            lookUpEditProcess.EditValue = sProcess;

            DataTable dtGrid = (DataTable)(gridControl1.DataSource);
            dtGrid.ImportRow(dt.Rows[0]);
            gridControl1.DataSource = dtGrid;
            gridView1.BestFitColumns();

            labelErr.BackColor = Color.Green;
            labelErr.Text = "        ";
            txtBarCode.Text = "";
            txtBarCode.Focus();
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
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
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

                    #region 必须销售类型是“WP”，状态非关闭。 回写销售订单数量，并新增其它出库单（数量增加红字出库单，数量减少蓝字出库单）

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        decimal dLotQTY = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColLOTQTY));
                        decimal dOrderQTY = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColOrderQTY));
                        decimal dQTYtc = dOrderQTY - dLotQTY;

                        if (dLotQTY == dOrderQTY)
                            continue;

                        long lSOsID = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColiSOsID));
                        string sBarCode = gridView1.GetRowCellValue(i, gridColLotNO).ToString().Trim();

                        //回写条码数量
                        sSQL = @"update [_BarCodeLabel] set [Status] = '调整', orderqty = aaaaaa, LOTQTY = aaaaaa where BarCode = 'bbbbbb' and iSOsID = " + gridView1.GetRowCellValue(i, gridColiSOsID).ToString().Trim();
                        sSQL = sSQL.Replace("aaaaaa", dLotQTY.ToString());
                        sSQL = sSQL.Replace("bbbbbb", sBarCode);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        Model.BarStatus model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.BarStatus();
                        model.BarCode = sBarCode;
                        model.iSOsID = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColiSOsID));
                        model.Type = "调整";
                        model.RoutingFrom = gridView1.GetRowCellValue(i, gridColProcess).ToString().Trim();
                        model.RoutingTo = gridView1.GetRowCellValue(i, gridColProcess).ToString().Trim();
                        model.UpdateTime = dNow;
                        model.QTY = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColLOTQTY));
                        model.CreateUid = sUserID;
                        model.CreateDate = dNow;
                        DAL.BarStatus dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.BarStatus();
                        sSQL = dal.Add(model);
                        iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        //回写销售订单数量
                        sSQL = @"update SO_SODetails set iQuantity = iQuantity - aaaaaa where iSOsID =  bbbbbb";
                        sSQL = sSQL.Replace("aaaaaa", dQTYtc.ToString());
                        sSQL = sSQL.Replace("bbbbbb", lSOsID.ToString());
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        //回写销售订单金额
                        sSQL = @"
update SO_SODetails set iMoney = iQuantity * iUnitPrice,iSum = iTaxUnitPrice * iQuantity,iTax = iTaxUnitPrice * iQuantity - iQuantity * iUnitPrice
    ,iNatMoney = iNatUnitPrice * iQuantity , iNatSum = iNatMoney * (1 + iTaxRate / 100),iNatTax = iNatMoney * (1 + iTaxRate / 100) - iNatUnitPrice * iQuantity
where iSOsID =  bbbbbb
";
                        sSQL = sSQL.Replace("bbbbbb", lSOsID.ToString());
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        //------------------------------------------------------------------------
                        #region 同步生成其它出库单

                        sSQL = @"
select * 
from SO_SOMain a inner join SO_SODetails b on a.ID = b.ID
    left join _SystemSet c on a.cSTCode = c.cSTCode
    inner join Inventory d on b.cInvCode = d.cInvCode
where b.iSOsID = aaaaaa
order by b.autoid
";
                        sSQL = sSQL.Replace("aaaaaa", lSOsID.ToString().Trim());
                        DataTable dtSOMain = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        if (dtSOMain == null || dtSOMain.Rows.Count == 0)
                        {
                            throw new Exception("Sale Order not exists err");
                        }

                        string sCTCode = dtSOMain.Rows[0]["cSTCode"].ToString().Trim();

                        //DateTime dDate = BaseFunction.ReturnDate(dtSOMain.Rows[0]["dDate"]);
                        DateTime dDate = DateTime.Today;
                        sSQL = "select isnull(bflag_ST,0) as bflag from GL_mend where iYPeriod = '" + dDate.ToString("yyyyMM") + "'";
                        dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt == null || dt.Rows.Count == 0)
                        {
                            throw new Exception("Access module state failure");
                        }
                        int i结账RD = BaseFunction.ReturnInt(dt.Rows[0]["bflag"]);
                        if (i结账RD > 0)
                        {
                            throw new Exception(dDate.ToString("yyyy-MM") + " have checked out");
                        }

                        //获得单据号
                        sSQL = "select cNumber from VoucherHistory with (ROWLOCK) Where cSeed = 'aaaaaa' AND cContentRule = 'YYYY' AND CardNumber = '0302' ORDER BY cNumber DESC";
                        sSQL = sSQL.Replace("aaaaaa", dDate.ToString("yyyy"));
                        dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        long lCodeRD = 0;
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            lCodeRD = BaseFunction.ReturnLong(dt.Rows[0]["cNumber"]);
                        }
                        else
                        {
                            lCodeRD = 0;
                        }

                        long lIDRD = -1;
                        long lIDRDDetails = -1;
                        sSQL = @"
declare @p5 int
set @p5=aaaaaa
declare @p6 int
set @p6=bbbbbb
exec sp_GetId N'00',N'dddddd',N'rd',cccccc,@p5 output,@p6 output,default
select @p5, @p6
";
                        sSQL = sSQL.Replace("aaaaaa", lIDRD.ToString());
                        sSQL = sSQL.Replace("bbbbbb", lIDRDDetails.ToString());
                        sSQL = sSQL.Replace("cccccc", 1.ToString());
                        sSQL = sSQL.Replace("dddddd", sAccID);
                        dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        lIDRD = BaseFunction.ReturnLong(dt.Rows[0][0]) - 1;
                        lIDRDDetails = BaseFunction.ReturnLong(dt.Rows[0][1]) - 1;

                        //ArrayList aList = new ArrayList();

                        Model.RdRecord09 modelRD = new Model.RdRecord09();
                        lIDRD += 1;
                        modelRD.ID = lIDRD;

                        modelRD.bRdFlag = 0;
                        modelRD.cVouchType = "09";
                        modelRD.cBusType = "其他出库";
                        modelRD.cSource = "库存";
                        //modelRD.cBusCode = 


                        modelRD.cWhCode = dtSOMain.Rows[0]["cWhCode"].ToString().Trim();        //需要仓库默认值
                        if (dtSOMain.Rows[0]["cWhCode"].ToString().Trim() == "")
                        {
                            throw new Exception("Please set default warehouse");
                        }

                        modelRD.dDate = dDate;        //需要默认值

                        lCodeRD += 1;
                        string sCodeRD = lCodeRD.ToString();
                        while (sCodeRD.Length < 6)
                        {
                            sCodeRD = "0" + sCodeRD;
                        }
                        modelRD.cCode = "MR" + dNow.ToString("yyyy") + sCodeRD;
                        modelRD.cRdCode = "AD";      //需要默认值
                        if (dtSOMain.Rows[0]["cRdCode"].ToString().Trim() == "")
                        {
                            throw new Exception("Please set RdCode");
                        }
                        //modelRD.cDepCode = ""
                        //modelRD.cPersonCode; 
                        //modelRD.cPTCode; 
                        //modelRD.cSTCode; 
                        //modelRD.cCusCode; 
                        //modelRD.cVenCode; 
                        //modelRD.cOrderCode; 
                        //modelRD.cARVCode; 
                        //modelRD.cBillCode; 
                        //modelRD.cDLCode; 
                        //modelRD.cProBatch; 
                        modelRD.cHandler = sUserName;
                        //modelRD.cMemo; 
                        modelRD.bTransFlag = false;
                        //modelRD.cAccounter; 
                        modelRD.cMaker = sUserName;
                        modelRD.cDefine1 = dtSOMain.Rows[0]["cDefine1"].ToString();
                        modelRD.cDefine2 = dtSOMain.Rows[0]["cDefine2"].ToString();
                        modelRD.cDefine3 = dtSOMain.Rows[0]["cDefine3"].ToString();

                        if (dtSOMain.Rows[0]["cDefine4"].ToString().Trim() != "")
                        {
                            modelRD.cDefine4 = BaseFunction.ReturnDate(dtSOMain.Rows[0]["cDefine4"]);
                        }
                        if (dtSOMain.Rows[0]["cDefine5"].ToString().Trim() != "")
                        {
                            modelRD.cDefine5 = BaseFunction.ReturnLong(dtSOMain.Rows[0]["cDefine5"]);
                        }
                        if (dtSOMain.Rows[0]["cDefine6"].ToString().Trim() != "")
                        {
                            modelRD.cDefine6 = BaseFunction.ReturnDate(dtSOMain.Rows[0]["cDefine6"]);
                        }
                        if (dtSOMain.Rows[0]["cDefine7"].ToString().Trim() != "")
                        {
                            modelRD.cDefine7 = BaseFunction.ReturnDecimal(dtSOMain.Rows[0]["cDefine7"]);
                        }
                        modelRD.cDefine8 = dtSOMain.Rows[0]["cDefine8"].ToString();
                        modelRD.cDefine9 = dtSOMain.Rows[0]["cDefine9"].ToString();
                        modelRD.cDefine10 = dtSOMain.Rows[0]["cDefine10"].ToString();
                        //modelRD.dKeepDate; 
                        modelRD.dVeriDate = dDate;
                        modelRD.bpufirst = false;
                        modelRD.biafirst = false;
                        //modelRD.iMQuantity; 
                        //modelRD.dARVDate; 
                        //modelRD.cChkCode; 
                        //modelRD.dChkDate; 
                        //modelRD.cChkPerson; 
                        modelRD.VT_ID = 85;
                        modelRD.bIsSTQc = false;
                        modelRD.cDefine11 = dtSOMain.Rows[0]["cDefine11"].ToString();
                        modelRD.cDefine12 = dtSOMain.Rows[0]["cDefine12"].ToString();
                        modelRD.cDefine13 = dtSOMain.Rows[0]["cDefine13"].ToString();
                        modelRD.cDefine14 = dtSOMain.Rows[0]["cDefine14"].ToString();

                        if (dtSOMain.Rows[0]["cDefine15"].ToString() != "")
                        {
                            modelRD.cDefine15 = BaseFunction.ReturnLong(dtSOMain.Rows[0]["cDefine15"]);
                        }
                        if (dtSOMain.Rows[0]["cDefine16"].ToString() != "")
                        {
                            modelRD.cDefine16 = BaseFunction.ReturnDecimal(dtSOMain.Rows[0]["cDefine16"]);
                        }
                        //modelRD.gspcheck; 
                        //modelRD.ufts; 
                        //modelRD.iExchRate; 
                        //modelRD.cExch_Name; 
                        modelRD.bOMFirst = false;
                        modelRD.bFromPreYear = false;
                        modelRD.bIsLsQuery = false;
                        modelRD.bIsComplement = 0;
                        modelRD.iDiscountTaxType = 0;
                        modelRD.ireturncount = 0;
                        modelRD.iverifystate = 0;
                        modelRD.iswfcontrolled = 0;
                        //modelRD.cModifyPerson; 
                        //modelRD.dModifyDate; 
                        //modelRD.dnmaketime; 
                        //modelRD.dnmodifytime; 
                        modelRD.dnverifytime = dNow;
                        modelRD.bredvouch = 0;
                        //modelRD.iFlowId; 
                        //modelRD.cPZID; 
                        //modelRD.cSourceLs; 
                        //modelRD.cSourceCodeLs; 
                        modelRD.iPrintCount = 0;
                        //modelRD.ctransflag; 
                        //modelRD.csysbarcode;
                        //modelRD.cCurrentAuditor;
                        DAL.RdRecord09 dalRD = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.RdRecord09();
                        sSQL = dalRD.Add(modelRD);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                        lIDRDDetails += 1;


                        Model.rdrecords09 modelsRD = new Model.rdrecords09();
                        modelsRD.AutoID = lIDRDDetails;


                        modelsRD.ID = modelRD.ID;
                        modelsRD.cInvCode = dtSOMain.Rows[0]["cInvCode"].ToString().Trim();

                        //if (dtSOMain.Rows[0]["iNum"].ToString().Trim() != "")
                        //{
                        //    modelsRD.iNum = BaseFunction.ReturnDecimal(dtSOMain.Rows[0]["iNum"]);
                        //}
                        modelsRD.iQuantity = dQTYtc;
                        //modelsRD.iUnitCost; 
                        //modelsRD.iPrice; 
                        //modelsRD.iAPrice; 
                        //modelsRD.iPUnitCost; 
                        //modelsRD.iPPrice; 

                        modelsRD.cBatch = gridView1.GetRowCellValue(i, gridColcBatch).ToString().Trim();

                        //modelsRD.cVouchCode; 
                        //modelsRD.cInVouchCode; 
                        //modelsRD.cinvouchtype; 
                        //modelsRD.iSOutQuantity; 
                        //modelsRD.iSOutNum; 
                        //modelsRD.cFree1; 
                        //modelsRD.cFree2; 
                        modelsRD.iFlag = 0;
                        //modelsRD.iFNum; 
                        //modelsRD.iFQuantity; 
                        //modelsRD.dVDate; 
                        //modelsRD.iTrIds; 
                        //modelsRD.cPosition; 
                        //modelsRD.cDefine22; 
                        //modelsRD.cDefine23; 
                        //modelsRD.cDefine24; 
                        //modelsRD.cDefine25; 
                        //modelsRD.cDefine26; 
                        //modelsRD.cDefine27; 
                        //modelsRD.cItem_class; 
                        //modelsRD.cItemCode; 
                        //modelsRD.cName; 
                        //modelsRD.cItemCName; 
                        //modelsRD.cFree3; 
                        //modelsRD.cFree4; 
                        //modelsRD.cFree5; 
                        //modelsRD.cFree6; 
                        //modelsRD.cFree7; 
                        //modelsRD.cFree8; 
                        //modelsRD.cFree9; 
                        //modelsRD.cFree10; 
                        //modelsRD.cBarCode; 
                        //modelsRD.iNQuantity; 
                        //modelsRD.iNNum; 
                        //modelsRD.cAssUnit; 
                        //modelsRD.dMadeDate; 
                        //modelsRD.iMassDate; 
                        //modelsRD.cDefine28; 
                        //modelsRD.cDefine29; 
                        //modelsRD.cDefine30;
                        //modelsRD.cDefine31; 
                        //modelsRD.cDefine32; 
                        //modelsRD.cDefine33; 
                        //modelsRD.cDefine34; 
                        //modelsRD.cDefine35; 
                        //modelsRD.cDefine36; 
                        //modelsRD.cDefine37; 
                        //modelsRD.iCheckIds; 
                        //modelsRD.cBVencode; 
                        //modelsRD.chVencode; 
                        //modelsRD.bGsp; 
                        //modelsRD.cGspState; 
                        //modelsRD.cCheckCode; 
                        //modelsRD.iCheckIdBaks; 
                        //modelsRD.cRejectCode; 
                        //modelsRD.iRejectIds; 
                        //modelsRD.cCheckPersonCode; 
                        //modelsRD.dCheckDate; 
                        //modelsRD.cMassUnit; 
                        //modelsRD.bChecked; 
                        modelsRD.bLPUseFree = false;
                        //modelsRD.iRSRowNO; 
                        //modelsRD.iOriTrackID; 
                        //modelsRD.coritracktype; 
                        //modelsRD.cbaccounter; 
                        //modelsRD.dbKeepDate; 
                        modelsRD.bCosting = true;
                        modelsRD.bVMIUsed = false;
                        //modelsRD.iVMISettleQuantity; 
                        //modelsRD.iVMISettleNum; 
                        //modelsRD.cvmivencode; 
                        //modelsRD.iInvSNCount; 
                        //modelsRD.cwhpersoncode; 
                        //modelsRD.cwhpersonname; 
                        //modelsRD.cserviceoid; 
                        //modelsRD.cbserviceoid; 
                        //modelsRD.iinvexchrate; 
                        //modelsRD.corufts;
                        //modelsRD.strContractGUID; 
                        modelsRD.iExpiratDateCalcu = 0;
                        //modelsRD.cExpirationdate; 
                        //modelsRD.dExpirationdate; 
                        //modelsRD.cciqbookcode; 
                        //modelsRD.iBondedSumQty; 
                        //modelsRD.iorderdid; 
                        modelsRD.iordertype = 0;
                        //modelsRD.iordercode; 
                        //modelsRD.iorderseq; 
                        //modelsRD.isodid; 
                        modelsRD.isotype = 0;
                        modelsRD.csocode = dtSOMain.Rows[0]["cSOCode"].ToString().Trim();
                        //modelsRD.isoseq
                        //modelsRD.cBatchProperty1; 
                        //modelsRD.cBatchProperty2; 
                        //modelsRD.cBatchProperty3; 
                        //modelsRD.cBatchProperty4; 
                        //modelsRD.cBatchProperty5; 
                        //modelsRD.cBatchProperty6; 
                        //modelsRD.cBatchProperty7; 
                        //modelsRD.cBatchProperty8; 
                        //modelsRD.cBatchProperty9; 
                        //modelsRD.cBatchProperty10; 
                        //modelsRD.cbMemo; 
                        modelsRD.irowno = 1;
                        //modelsRD.strowguid; 
                        //modelsRD.rowufts; 
                        //modelsRD.ipreuseqty; 
                        //modelsRD.ipreuseinum; 
                        //modelsRD.cbsourcecodels; 
                        //modelsRD.iGroupNO; 
                        //modelsRD.iDebitIDs; 
                        //modelsRD.idebitchildids; 
                        //modelsRD.OutCopiedQuantity; 
                        //modelsRD.cbsysbarcode

                        DAL.rdrecords09 dalsRD = new DAL.rdrecords09();
                        sSQL = dalsRD.Add(modelsRD);
                        iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        sSQL = @"
if exists
    (select * from  CurrentStock where cInvCode = '@cInvCode' and cWhCode = '@cWhCode'
        and isnull(cFree1,'') = @cFree1 
        and isnull(cFree2,'') = @cFree2
        and isnull(cFree3,'') = @cFree3
        and isnull(cFree4,'') = @cFree4
        and isnull(cFree5,'') = @cFree5
        and isnull(cFree6,'') = @cFree6
        and isnull(cFree7,'') = @cFree7
        and isnull(cFree8,'') = @cFree8
        and isnull(cFree9,'') = @cFree9
        and isnull(cFree10,'') = @cFree10
        and isnull(cBatch,'') = @cBatch 
    )
  	update  CurrentStock set iQuantity = isnull(iQuantity,0) + @iQuantity  
    where cInvCode = '@cInvCode' and cWhCode = '@cWhCode' 
        and isnull(cFree1,'') = @cFree1 
        and isnull(cFree2,'') = @cFree2
        and isnull(cFree3,'') = @cFree3
        and isnull(cFree4,'') = @cFree4
        and isnull(cFree5,'') = @cFree5
        and isnull(cFree6,'') = @cFree6
        and isnull(cFree7,'') = @cFree7
        and isnull(cFree8,'') = @cFree8
        and isnull(cFree9,'') = @cFree9
        and isnull(cFree10,'') = @cFree10
        and isnull(cBatch,'') = @cBatch 
else 
    begin 
        declare @itemid varchar(20); 
        declare @iCount int;  
        select @iCount=count(itemid) from CurrentStock where cInvCode = '@cInvCode';
        if( @iCount > 0 )
	        select @itemid=itemid from CurrentStock where cInvCode = '@cInvCode';
        else  
            select @itemid=max(itemid+1) from CurrentStock  
            insert into CurrentStock(cWhCode,cInvCode,iQuantity,itemid, cFree1, cFree2, cFree3, cFree4, cFree5, cFree6, cFree7, cFree8, cFree9, cFree10,cBatch,iSoDid)
            values('@cWhCode','@cInvCode', @iQuantity,@itemid, @cFree1, @cFree2, @cFree3, @cFree4, @cFree5, @cFree6, @cFree7, @cFree8, @cFree9, @cFree10,@cBatch,'') 
    end
";
                        sSQL = sSQL.Replace("@cInvCode", modelsRD.cInvCode);
                        sSQL = sSQL.Replace("@cWhCode", modelRD.cWhCode);
                        sSQL = sSQL.Replace("@iQuantity", (-1 * modelsRD.iQuantity).ToString());
                        sSQL = sSQL.Replace("@iNum", (-1 * modelsRD.iNum).ToString());
                        sSQL = sSQL.Replace("@cFree10", modelsRD.cFree10 == null ? "''" : "'" + modelsRD.cFree10 + "'");
                        sSQL = sSQL.Replace("@cFree1", modelsRD.cFree1 == null ? "''" : "'" + modelsRD.cFree1 + "'");
                        sSQL = sSQL.Replace("@cFree2", modelsRD.cFree2 == null ? "''" : "'" + modelsRD.cFree2 + "'");
                        sSQL = sSQL.Replace("@cFree3", modelsRD.cFree3 == null ? "''" : "'" + modelsRD.cFree3 + "'");
                        sSQL = sSQL.Replace("@cFree4", modelsRD.cFree4 == null ? "''" : "'" + modelsRD.cFree4 + "'");
                        sSQL = sSQL.Replace("@cFree5", modelsRD.cFree5 == null ? "''" : "'" + modelsRD.cFree5 + "'");
                        sSQL = sSQL.Replace("@cFree6", modelsRD.cFree6 == null ? "''" : "'" + modelsRD.cFree6 + "'");
                        sSQL = sSQL.Replace("@cFree7", modelsRD.cFree7 == null ? "''" : "'" + modelsRD.cFree7 + "'");
                        sSQL = sSQL.Replace("@cFree8", modelsRD.cFree8 == null ? "''" : "'" + modelsRD.cFree8 + "'");
                        sSQL = sSQL.Replace("@cFree9", modelsRD.cFree9 == null ? "''" : "'" + modelsRD.cFree9 + "'");
                        sSQL = sSQL.Replace("@cBatch", modelsRD.cBatch == null ? "''" : "'" + modelsRD.cBatch + "'");
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                        sSQL = @"
exec ST_SaveForStock N'09',N'aaaaaa',1,0 ,1
";
                        sSQL = sSQL.Replace("aaaaaa", lIDRD.ToString());
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        sSQL = @"
exec ST_SaveForTrackStock N'09',N'aaaaaa', 0 ,1
";
                        sSQL = sSQL.Replace("aaaaaa", lIDRD.ToString());
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        sSQL = @"
exec IA_SP_WriteUnAccountVouchForST 'aaaaaa',N'09'
";
                        sSQL = sSQL.Replace("aaaaaa", lIDRD.ToString());
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                        if (lIDRD > 1000000000)
                        {
                            lIDRD = lIDRD - 1000000000;
                        }
                        if (lIDRDDetails > 1000000000)
                        {
                            lIDRDDetails = lIDRDDetails - 1000000000;
                        }
                        sSQL = "update UFSystem..UA_Identity set iFatherId = " + lIDRD.ToString() + ",iChildId = " + lIDRDDetails + " where cAcc_Id = '" + sAccID + "' and cVouchType = 'rd'";
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        sSQL = @"
if exists(select * from VoucherHistory where CardNumber = '0302' and cSeed = 'aaaaaa' AND cContentRule = 'YYYY')
	update VoucherHistory set cNumber = bbbbbb  where CardNumber = '0302' and cSeed = 'aaaaaa' AND cContentRule = 'YYYY'
else
	insert into VoucherHistory(CardNumber,cContent,cContentRule,cSeed,cNumber,bEmpty)
	values('0302','日期','YYYY','aaaaaa','bbbbbb',0)
";
                        sSQL = sSQL.Replace("aaaaaa", dDate.ToString("yyyy"));
                        sSQL = sSQL.Replace("bbbbbb", lCodeRD.ToString());
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        #endregion
                        //------------------------------------------------------------------------
                    }

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
                MessageBox.Show(ee.Message);
            }
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

        private void lookUpEditProcess_EditValueChanged(object sender, EventArgs e)
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
                    txtBarCode.Focus();
                }
            }
            catch { }
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
    }
}
