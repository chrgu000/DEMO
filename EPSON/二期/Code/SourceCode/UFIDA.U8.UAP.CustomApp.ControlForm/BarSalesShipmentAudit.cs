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
    public partial class BarSalesShipmentAudit : UserControl
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

        private void SetLookUp()
        {
            string sSQL = "select cWhCode ,cWhName from WareHouse WHERE cwhmemo like '%F%' or cwhmemo like '%R%' order by cWhCode";
            DataTable dt = DbHelperSQL.Query(sSQL);
            lookUpEditProcess.Properties.DataSource = dt;

            ItemLookUpEditProcess.DataSource = dt;

            sSQL = "select cCusCode,cCusName from Customer order by cCusCode";
            dt = DbHelperSQL.Query(sSQL);
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditcCusCode.Properties.DataSource = dt;
            lookUpEditcCusName.Properties.DataSource = dt;
        }

        public BarSalesShipmentAudit()
        {
            InitializeComponent();
        }

        private void GetGrid()
        {
            try
            {
                if (lookUpEditProcess.EditValue == null || lookUpEditProcess.Text.Trim() == "")
                {
                    lookUpEditProcess.Focus();
                    throw new Exception("Please choose process");
                }

                //当U8删除发货单，刷新发货记录表
                string sSQL = @"
Update b set b.[status] = 'Pending',b.iDispatchLists = null
FROM [dbo].[_SalesShipment] a
	inner join [dbo].[_BarCodeLabel] b on a.LotNO = b.BarCode and a.iSOsID = b.iSOsID
	left join DispatchLists c on b.iDispatchLists = c.iDLsID
where b.[status] = '发货' and isnull(c.AutoID,0) = 0 
";
                DbHelperSQL.ExecuteSql(sSQL);

                sSQL = @"
SELECT CAST(1 AS BIT) AS CHOOSE
    , a.iID, a.LotNO, a.cSOCode,a.SaleOrderRow, a.iSOsID, a.ItemNO, a.Description, a.cCusCode
    , cast (a.OrderQTY as decimal(16,2)) as OrderQTY
    , cast (a.LOTQTY as decimal(16,2)) as LOTQTY
    , a.DEPT
    , a.Process, a.ProcessNext
    , cast(a.OtherQTY as decimal(16,2)) as OtherQTY, a.Status, a.cSTCode
    , cast(a.CurrQTY as decimal(16,2)) as CurrQTY, a.CreateUid, a.CreateDate
    ,a.CartonNo,b.custlot
FROM [dbo].[_SalesShipment] a
	inner join [dbo].[_BarCodeLabel] b on a.LotNO = b.BarCode and a.iSOsID = b.iSOsID
	left join DispatchLists c on b.iDispatchLists = c.iDLsID
WHERE 1=1
	and (isnull(b.iDispatchLists,0) = 0 or (isnull(b.iDispatchLists,0) <> 0 and isnull(c.AutoID,0) = 0))
	and a.[Process] = '222222'
    and b.[status] = 'Pending'
order by a.iID
";
                if (lookUpEditcCusCode.EditValue != null && lookUpEditcCusCode.EditValue.ToString().Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.[cCusCode] = '" + lookUpEditcCusCode.EditValue.ToString() + "'  ");
                }
                sSQL = sSQL.Replace("222222", lookUpEditProcess.EditValue.ToString());
                DataTable dt = DbHelperSQL.Query(sSQL);
                gridControl1.DataSource = dt;
                gridView1.BestFitColumns();
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                GetGrid();

                chkAll.Checked = true;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }


        private void SetTxtNull()
        {
            lookUpEditProcess.EditValue = null;
            lookUpEditProcess.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            string sErr = "";

            int iCount = 0;
            try
            {
                if (lookUpEditProcess.EditValue == null || lookUpEditProcess.EditValue.ToString().Trim() == "")
                {
                    lookUpEditProcess.Focus();
                    throw new Exception("Please choose warehouse");
                }
                string sProcess = lookUpEditProcess.EditValue.ToString().Trim();


                if (lookUpEditcCusCode.EditValue == null || lookUpEditcCusCode.EditValue.ToString().Trim() == "")
                {
                    lookUpEditcCusCode.Focus();
                    throw new Exception("Please choose customer");
                }
                string sCusCode = lookUpEditcCusCode.EditValue.ToString().Trim();


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
                    sSQL = "select isnull(bflag_SA,0) as bflag from GL_mend where iYPeriod = '" + s期间 + "'";
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

                    //获得单据号
                    sSQL = "select max(cNumber) as cNumber from VoucherHistory with (ROWLOCK) Where (cSeed = 'DPaaaaaa' or cSeed = 'aaaaaa') AND cContentRule like '%YYYY%' AND CardNumber = '01' ORDER BY cNumber DESC";
                    sSQL = sSQL.Replace("aaaaaa", dNow.ToString("yyyy"));
                    dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    long lCodeDis = 0;
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        lCodeDis = BaseFunction.ReturnLong(dt.Rows[0]["cNumber"]);
                    }
                    else
                    {
                        lCodeDis = 0;
                    }

                    lCodeDis += 1;
                    string sCodeDis = lCodeDis.ToString();
                    while (sCodeDis.Length < 6)
                    {
                        sCodeDis = "0" + sCodeDis;
                    }


                    sSQL = "select count(1) as iCou from WareHouse WHERE cWhCode = '" + lookUpEditProcess.EditValue.ToString().Trim() + "' and cwhmemo like '%R%' ";
                    int iWhR = BaseFunction.ReturnInt(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                    if (iWhR > 0)
                    {
                        sCodeDis = "FC" + dNow.ToString("yyyy") + sCodeDis;
                    }
                    else
                    {
                        sCodeDis = "DP" + dNow.ToString("yyyy") + sCodeDis;
                    }
                    long lIDDis = -1;
                    long lIDDisDetails = -1;
                    sSQL = @"
declare @p5 int
set @p5=aaaaaa
declare @p6 int
set @p6=bbbbbb
exec sp_GetId N'00',N'dddddd',N'DISPATCH',cccccc,@p5 output,@p6 output,default
select @p5, @p6
";
                    sSQL = sSQL.Replace("aaaaaa", lIDDis.ToString());
                    sSQL = sSQL.Replace("bbbbbb", lIDDisDetails.ToString());
                    sSQL = sSQL.Replace("cccccc", 1.ToString());
                    sSQL = sSQL.Replace("dddddd", sAccID);
                    dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    lIDDis = BaseFunction.ReturnLong(dt.Rows[0][0]) - 1;
                    lIDDisDetails = BaseFunction.ReturnLong(dt.Rows[0][1]) - 1;

                    long lSOsID = BaseFunction.ReturnLong(gridView1.GetRowCellValue(0, gridColiSOsID));
                    sSQL = @"
select * 
from SO_SOMain a inner join SO_SODetails b on a.ID = b.ID
    left join _SystemSet c on a.cSTCode = c.cSTCode
    inner join Inventory d on b.cInvCode = d.cInvCode
    inner join Customer e on a.cCusCode = e.cCusCode
where b.iSOsID = aaaaaa
order by b.autoid
";
                    sSQL = sSQL.Replace("aaaaaa", lSOsID.ToString().Trim());
                    DataTable dtSOMain = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    Model.DispatchList modelDis = new Model.DispatchList();
                    lIDDis += 1;
                    modelDis.DLID = lIDDis;
                    modelDis.cDLCode = sCodeDis;
                    modelDis.cVouchType = "05";
                    modelDis.cSTCode = dtSOMain.Rows[0]["cSTCode"].ToString().Trim();
                    modelDis.dDate = dNowDate;
                    modelDis.cDepCode = dtSOMain.Rows[0]["cDepCode"].ToString().Trim();
                    modelDis.SBVID = 0;
                    modelDis.cSOCode = dtSOMain.Rows[0]["cSOCode"].ToString().Trim();
                    modelDis.cCusCode = dtSOMain.Rows[0]["cCusCode"].ToString().Trim();
                    modelDis.cPayCode = dtSOMain.Rows[0]["cPayCode"].ToString().Trim();
                    modelDis.cShipAddress = dtSOMain.Rows[0]["cCusOAddress"].ToString().Trim();
                    modelDis.cexch_name = dtSOMain.Rows[0]["cexch_name"].ToString().Trim();
                    modelDis.iExchRate = BaseFunction.ReturnDecimal(dtSOMain.Rows[0]["iExchRate"]);
                    modelDis.iTaxRate = BaseFunction.ReturnDecimal(dtSOMain.Rows[0]["iTaxRate"]);
                    modelDis.bFirst = false;
                    modelDis.bReturnFlag = false;
                    modelDis.bSettleAll = false;
                    modelDis.cMemo = dtSOMain.Rows[0]["cMemo"].ToString().Trim();
                    modelDis.cMaker = sUserName;
                    modelDis.iSale = 0;
                    modelDis.cCusName = dtSOMain.Rows[0]["cCusName"].ToString().Trim();
                    modelDis.iVTid = 71;
                    modelDis.cBusType = dtSOMain.Rows[0]["cBusType"].ToString().Trim();
                    modelDis.bIAFirst = false;
                    modelDis.bCredit = false;
                    modelDis.iverifystate = 0;
                    modelDis.iswfcontrolled = 0;
                    modelDis.bARFirst = false;
                    modelDis.dcreatesystime = dNow;
                    modelDis.iflowid = 0;
                    modelDis.bsigncreate = false;
                    modelDis.bcashsale = false;
                    modelDis.bneedbill = true;
                    modelDis.baccswitchflag = false;
                    modelDis.bsaleoutcreatebill = false;
                    modelDis.cinvoicecompany = dtSOMain.Rows[0]["cinvoicecompany"].ToString().Trim();

                    DAL.DispatchList dalDis = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.DispatchList();
                    sSQL = dalDis.Add(modelDis);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (!BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColchoose)))
                            continue;

                        if (gridView1.GetRowCellValue(i, gridColcCusCode).ToString().Trim() != lookUpEditcCusCode.EditValue.ToString().Trim())
                        {
                            sErr = sErr + "Row " + (i + 1) + " customer err \n";
                            continue;
                        }

                        lSOsID = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColiSOsID));
                        sSQL = @"
select * 
from SO_SOMain a inner join SO_SODetails b on a.ID = b.ID
    left join SaleType c on a.cSTCode = c.cSTCode
    inner join Inventory d on b.cInvCode = d.cInvCode
    inner join [_BarCodeLabel] e on e.[iSOsID] = b.[iSOsID]
    left join SO_SODetails_extradefine f on f.iSOsID = b.iSOsID
where b.iSOsID = aaaaaa
order by b.autoid
";
                        sSQL = sSQL.Replace("aaaaaa", lSOsID.ToString().Trim());
                        DataTable dtSODetails = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        if (dtSODetails == null || dtSODetails.Rows.Count == 0)
                        {
                            throw new Exception("Sale Order not exists err");
                        }
                        string sBarCode = gridView1.GetRowCellValue(i, gridColLotNO).ToString().Trim();

                        lIDDisDetails += 1;

                        Model.DispatchLists modelsDis = new Model.DispatchLists();
                        modelsDis.AutoID = lIDDisDetails;
                        modelsDis.DLID = modelDis.DLID;
                        modelsDis.iCorID = 0;
                        modelsDis.cWhCode = lookUpEditProcess.EditValue.ToString().Trim();
                        modelsDis.cInvCode = dtSODetails.Rows[0]["cInvCode"].ToString().Trim();
                        modelsDis.iQuantity = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColLOTQTY));
                        modelsDis.iNum = 0;
                        modelsDis.iTaxRate = BaseFunction.ReturnDecimal(dtSODetails.Rows[0]["iTaxRate"]);
                        modelsDis.iQuotedPrice = BaseFunction.ReturnDecimal(dtSODetails.Rows[0]["iQuotedPrice"]);
                        modelsDis.iUnitPrice = BaseFunction.ReturnDecimal(dtSODetails.Rows[0]["iUnitPrice"]);
                        modelsDis.iTaxUnitPrice = BaseFunction.ReturnDecimal(dtSODetails.Rows[0]["iTaxUnitPrice"]);
                        modelsDis.iMoney = modelsDis.iUnitPrice * modelsDis.iQuantity;
                        modelsDis.iSum = modelsDis.iTaxUnitPrice * modelsDis.iQuantity;
                        modelsDis.iTax = modelsDis.iSum - modelsDis.iMoney;
                        modelsDis.iDisCount = 0;
                        modelsDis.iNatUnitPrice = BaseFunction.ReturnDecimal(dtSODetails.Rows[0]["iNatUnitPrice"]);
                        modelsDis.iNatMoney = modelsDis.iNatUnitPrice * modelsDis.iQuantity;
                        modelsDis.iNatSum = modelsDis.iNatUnitPrice * (1 + modelsDis.iTaxRate / 100) * modelsDis.iQuantity;
                        modelsDis.iNatTax = modelsDis.iNatSum - modelsDis.iNatMoney;
                        modelsDis.iNatDisCount = 0;
                        modelsDis.iSettleNum = 0;
                        modelsDis.iSettleQuantity = 0;
                        modelsDis.cBatch = gridView1.GetRowCellValue(i, gridColcustlot).ToString().Trim();
                        modelsDis.bSettleAll = false;
                        modelsDis.cMemo = dtSODetails.Rows[0]["cMemo"].ToString().Trim();
                        modelsDis.iTB = 0;
                        modelsDis.TBQuantity = 0;
                        modelsDis.iSOsID = lSOsID;
                        modelsDis.iDLsID = lIDDisDetails;
                        modelsDis.KL = 100;
                        modelsDis.KL2 = 0;
                        modelsDis.cInvName = dtSODetails.Rows[0]["cInvName"].ToString().Trim();
                        modelsDis.cDefine22 = dtSODetails.Rows[0]["cDefine22"].ToString().Trim();
                        modelsDis.cDefine23 = dtSODetails.Rows[0]["cDefine23"].ToString().Trim();
                        modelsDis.cDefine24 = dtSODetails.Rows[0]["cDefine24"].ToString().Trim();
                        modelsDis.cDefine25 = dtSODetails.Rows[0]["cDefine25"].ToString().Trim();
                        modelsDis.cDefine26 = BaseFunction.ReturnDecimal(dtSODetails.Rows[0]["cDefine26"]);
                        modelsDis.cDefine27 = BaseFunction.ReturnDecimal(dtSODetails.Rows[0]["cDefine27"]);
                        modelsDis.fOutQuantity = 0;
                        modelsDis.fOutNum = 0;
                        modelsDis.fSaleCost = 0;
                        modelsDis.fSalePrice = 0;
                        modelsDis.bIsSTQc = false;
                        modelsDis.cUnitID = dtSODetails.Rows[0]["cUnitID"].ToString().Trim();
                        modelsDis.fEnSettleQuan = 0;
                        modelsDis.fEnSettleSum = 0;
                        modelsDis.cDefine28 = dtSODetails.Rows[0]["cDefine28"].ToString().Trim();
                        modelsDis.cDefine29 = dtSODetails.Rows[0]["cDefine29"].ToString().Trim();
                        modelsDis.cDefine30 = dtSODetails.Rows[0]["cDefine30"].ToString().Trim();
                        modelsDis.cDefine31 = dtSODetails.Rows[0]["cDefine31"].ToString().Trim();
                        modelsDis.cDefine32 = dtSODetails.Rows[0]["cDefine32"].ToString().Trim();
                        modelsDis.cDefine33 = dtSODetails.Rows[0]["cDefine33"].ToString().Trim();
                        modelsDis.cDefine34 = BaseFunction.ReturnLong(dtSODetails.Rows[0]["cDefine34"]);
                        modelsDis.cDefine35 = BaseFunction.ReturnLong(dtSODetails.Rows[0]["cDefine35"]);
                        modelsDis.cDefine36 = BaseFunction.ReturnDate(dtSODetails.Rows[0]["cDefine36"]);
                        modelsDis.cDefine37 = BaseFunction.ReturnDate(dtSODetails.Rows[0]["cDefine37"]);
                        modelsDis.bgift = false;
                        modelsDis.cSoCode = dtSODetails.Rows[0]["cSoCode"].ToString().Trim();
                        modelsDis.cMassUnit = BaseFunction.ReturnLong(dtSODetails.Rows[0]["cMassUnit"]);
                        modelsDis.bQANeedCheck = false;
                        modelsDis.bQAUrgency = false;
                        modelsDis.bQAChecking = false;
                        modelsDis.bQAChecked = false;
                        modelsDis.fsumsignquantity = 0;
                        modelsDis.fsumsignnum = 0;
                        modelsDis.bcosting = false;
                        modelsDis.cordercode = dtSODetails.Rows[0]["cSTCode"].ToString().Trim();
                        modelsDis.iorderrowno = BaseFunction.ReturnLong(dtSODetails.Rows[0]["irowno"]);
                        modelsDis.irowno = i + 1;
                        modelsDis.iExpiratDateCalcu = 0;
                        modelsDis.bneedsign = false;
                        modelsDis.frlossqty = 0;
                        modelsDis.bsaleprice = true;
                        modelsDis.bgift = false;
                        modelsDis.bmpforderclosed = false;
                        modelsDis.bIAcreatebill = false;

                        DAL.DispatchLists dalsDis = new DAL.DispatchLists();
                        sSQL = dalsDis.Add(modelsDis);
                        iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        Model.DispatchLists_extradefine mods_extradeine = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.DispatchLists_extradefine();
                        mods_extradeine.iDLsID = modelsDis.iDLsID;
                        mods_extradeine.cbdefine1 = dtSODetails.Rows[0]["cbdefine1"].ToString().Trim();
                        mods_extradeine.cbdefine2 = dtSODetails.Rows[0]["cbdefine2"].ToString().Trim();
                        mods_extradeine.cbdefine3 = dtSODetails.Rows[0]["cbdefine3"].ToString().Trim();
                        mods_extradeine.cbdefine4 = BaseFunction.ReturnDecimal(dtSODetails.Rows[0]["cbdefine4"]);
                        mods_extradeine.cbdefine5 = gridView1.GetRowCellValue(i, gridColCartonNo).ToString().Trim();
                        mods_extradeine.cbdefine6 = dtSODetails.Rows[0]["cbdefine6"].ToString().Trim();
                        mods_extradeine.cbdefine7 = dtSODetails.Rows[0]["cbdefine7"].ToString().Trim();
                        mods_extradeine.cbdefine8 = dtSODetails.Rows[0]["cbdefine8"].ToString().Trim();
                        mods_extradeine.cbdefine9 = dtSODetails.Rows[0]["cbdefine9"].ToString().Trim();
                        mods_extradeine.cbdefine10 = dtSODetails.Rows[0]["cbdefine10"].ToString().Trim();
                        DAL.DispatchLists_extradefine dal_extradefine = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.DispatchLists_extradefine();
                        sSQL = dal_extradefine.Add(mods_extradeine);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        sSQL = @"
SELECT SUM(ISNULL(iQuantity,0) - ISNULL(fOutQuantity,0)) AS iSumQTY
FROM dbo.CurrentStock   WITH(NOLOCK) 
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
";
                        sSQL = sSQL.Replace("@cInvCode", modelsDis.cInvCode);
                        sSQL = sSQL.Replace("@cWhCode", modelsDis.cWhCode);
                        sSQL = sSQL.Replace("@iQuantity", modelsDis.iQuantity.ToString());
                        sSQL = sSQL.Replace("@iNum", modelsDis.iNum.ToString());
                        sSQL = sSQL.Replace("@cFree10", modelsDis.cFree10 == null ? "''" : "'" + modelsDis.cFree10 + "'");
                        sSQL = sSQL.Replace("@cFree1", modelsDis.cFree1 == null ? "''" : "'" + modelsDis.cFree1 + "'");
                        sSQL = sSQL.Replace("@cFree2", modelsDis.cFree2 == null ? "''" : "'" + modelsDis.cFree2 + "'");
                        sSQL = sSQL.Replace("@cFree3", modelsDis.cFree3 == null ? "''" : "'" + modelsDis.cFree3 + "'");
                        sSQL = sSQL.Replace("@cFree4", modelsDis.cFree4 == null ? "''" : "'" + modelsDis.cFree4 + "'");
                        sSQL = sSQL.Replace("@cFree5", modelsDis.cFree5 == null ? "''" : "'" + modelsDis.cFree5 + "'");
                        sSQL = sSQL.Replace("@cFree6", modelsDis.cFree6 == null ? "''" : "'" + modelsDis.cFree6 + "'");
                        sSQL = sSQL.Replace("@cFree7", modelsDis.cFree7 == null ? "''" : "'" + modelsDis.cFree7 + "'");
                        sSQL = sSQL.Replace("@cFree8", modelsDis.cFree8 == null ? "''" : "'" + modelsDis.cFree8 + "'");
                        sSQL = sSQL.Replace("@cFree9", modelsDis.cFree9 == null ? "''" : "'" + modelsDis.cFree9 + "'");
                        sSQL = sSQL.Replace("@cBatch", modelsDis.cBatch == null ? "''" : "'" + modelsDis.cBatch + "'");
                        decimal dUseQTY = BaseFunction.ReturnDecimal(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0]["iSumQTY"], 6);
                        if (dUseQTY < modelsDis.iQuantity)
                        {
                            sErr = sErr + "Row " + (i + 1).ToString() + " is not enough\n";
                            continue;
                        }

                        sSQL = @"
 	update  CurrentStock set fOutQuantity = isnull(fOutQuantity,0) + @iQuantity  
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
";
                        sSQL = sSQL.Replace("@cInvCode", modelsDis.cInvCode);
                        sSQL = sSQL.Replace("@cWhCode", modelsDis.cWhCode);
                        sSQL = sSQL.Replace("@iQuantity", modelsDis.iQuantity.ToString());
                        sSQL = sSQL.Replace("@iNum", modelsDis.iNum.ToString());
                        sSQL = sSQL.Replace("@cFree10", modelsDis.cFree10 == null ? "''" : "'" + modelsDis.cFree10 + "'");
                        sSQL = sSQL.Replace("@cFree1", modelsDis.cFree1 == null ? "''" : "'" + modelsDis.cFree1 + "'");
                        sSQL = sSQL.Replace("@cFree2", modelsDis.cFree2 == null ? "''" : "'" + modelsDis.cFree2 + "'");
                        sSQL = sSQL.Replace("@cFree3", modelsDis.cFree3 == null ? "''" : "'" + modelsDis.cFree3 + "'");
                        sSQL = sSQL.Replace("@cFree4", modelsDis.cFree4 == null ? "''" : "'" + modelsDis.cFree4 + "'");
                        sSQL = sSQL.Replace("@cFree5", modelsDis.cFree5 == null ? "''" : "'" + modelsDis.cFree5 + "'");
                        sSQL = sSQL.Replace("@cFree6", modelsDis.cFree6 == null ? "''" : "'" + modelsDis.cFree6 + "'");
                        sSQL = sSQL.Replace("@cFree7", modelsDis.cFree7 == null ? "''" : "'" + modelsDis.cFree7 + "'");
                        sSQL = sSQL.Replace("@cFree8", modelsDis.cFree8 == null ? "''" : "'" + modelsDis.cFree8 + "'");
                        sSQL = sSQL.Replace("@cFree9", modelsDis.cFree9 == null ? "''" : "'" + modelsDis.cFree9 + "'");
                        sSQL = sSQL.Replace("@cBatch", modelsDis.cBatch == null ? "''" : "'" + modelsDis.cBatch + "'");
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        //sSQL = "update SO_SODetails set [iFHQuantity] = isnull(iFHQuantity,0) + aaaaaa,iFHNum = isnull(iFHNum ,0) + bbbbbb,iFHMoney = (isnull(iFHQuantity,0) + aaaaaa) * iTaxUnitPrice  where iSOsID = cccccc";
                        //sSQL = sSQL.Replace("aaaaaa", modelsDis.iQuantity.ToString());
                        //sSQL = sSQL.Replace("bbbbbb", modelsDis.iNum.ToString());
                        //sSQL = sSQL.Replace("cccccc", lSOsID.ToString());
                        //DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        sSQL = "update _BarCodeLabel set iDispatchLists = 'cccccc', [Status] = '发货' where BarCode = 'aaaaaa' and iSOsID = bbbbbb";
                        sSQL = sSQL.Replace("aaaaaa", gridView1.GetRowCellValue(i, gridColLotNO).ToString().Trim());
                        sSQL = sSQL.Replace("bbbbbb", lSOsID.ToString());
                        sSQL = sSQL.Replace("cccccc", modelsDis.AutoID.ToString());
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        Model.BarStatus modBarStatus = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.BarStatus();
                        modBarStatus.BarCode = gridView1.GetRowCellValue(i, gridColLotNO).ToString().Trim();
                        modBarStatus.iSOsID = lSOsID;
                        modBarStatus.Type = "发货";
                        modBarStatus.UpdateTime = dNow;
                        modBarStatus.QTY = modelsDis.iQuantity;
                        modBarStatus.CreateUid = sUserID;
                        modBarStatus.CreateDate = dNow;
                        DAL.BarStatus dalBarStatus = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.BarStatus();
                        sSQL = dalBarStatus.Add(modBarStatus);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


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
                        sSQL = string.Format(sSQL, modBarStatus.BarCode, modBarStatus.iSOsID, dNow);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                        sSQL = @"
update a set iFHQuantity = b.iQty, iFHNum = b.iNum
from SO_SODetails a
	left join (select sum(iQuantity) as iQty,sum(iNum) as iNum,iSOSid from DispatchLists group by iSOSid) b on a.iSOsID = b.iSOsID
where a.iSOsID = aaaaaa
";
                        sSQL = sSQL.Replace("aaaaaa", modelsDis.iSOsID.ToString());
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    if (lIDDis > 1000000000)
                    {
                        lIDDis = lIDDis - 1000000000;
                    }
                    if (lIDDisDetails > 1000000000)
                    {
                        lIDDisDetails = lIDDisDetails - 1000000000;
                    }
                    sSQL = "update UFSystem..UA_Identity set iFatherId = " + lIDDis.ToString() + ",iChildId = " + lIDDisDetails + " where cAcc_Id = '" + sAccID + "' and cVouchType = 'DISPATCH'";
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = @"
if exists(select * from VoucherHistory where (cSeed = 'DPaaaaaa' or cSeed = 'aaaaaa') AND cContentRule like '%YYYY%' AND CardNumber = '01')
	update VoucherHistory set cNumber = bbbbbb  where (cSeed = 'DPaaaaaa' or cSeed = 'aaaaaa') AND cContentRule like '%YYYY%' AND CardNumber = '01'
else
	insert into VoucherHistory(CardNumber,cContent,cContentRule,cSeed,cNumber,bEmpty)
	values('01',N'手工输入|单据日期',N'DP|YYYY','DPaaaaaa','bbbbbb',0)
";
                    sSQL = sSQL.Replace("aaaaaa", dNow.ToString("yyyy"));
                    sSQL = sSQL.Replace("bbbbbb", lCodeDis.ToString());
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    if (sErr.Trim() != "")
                        throw new Exception(sErr);

                    //string sRDCode = AuditDispatchList(sCodeDis, tran);
                    //if (sRDCode.Trim() == "")
                    //{
                    //    throw new Exception("Create data err\n");
                    //}

                    if (iCount > 0)
                    {
                        tran.Commit();

                        MessageBox.Show("OK\n" + modelDis.cDLCode);

                        SetTxtNull();

                        gridControl1.DataSource = DBNull.Value;
                        lookUpEditProcess.Focus();
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
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                for (int i = gridView1.RowCount - 1; i >= 0; i--)
                {
                    if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridColchoose)))
                        gridView1.DeleteRow(i);

                }
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


        /// <summary>
        /// 审核发货单
        /// </summary>
        /// <param name="sCode"></param>
        /// <param name="tran"></param>
        private string AuditDispatchList(string sCode, SqlTransaction tran)
        {
            string sRDCode = "";

            string sSQL = "select getdate()";
            DateTime dNow = BaseFunction.ReturnDate(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
            DateTime dNowDate = BaseFunction.ReturnDate(dNow.ToString("yyyy-MM-dd"));

            sSQL = " Update DispatchList SET  cVerifier=N'" + sUserName + "',dverifydate= '" + dNowDate.ToString("yyyy-MM-dd") + "',dverifysystime='" + dNow.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE cDLCode  = '" + sCode + "' ";
            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

            sSQL = @"
select d.cRdCode,a.*,b.*
from DispatchList a inner join DispatchLists b on a.DLID = b.DLID
	left join DispatchLists_extradefine c on b.iDLsID = c.iDLsID
    left join SaleType d on a.cSTCode = d.cSTCode
where a.cDLCode = 'aaaaaa'
";
            sSQL = sSQL.Replace("aaaaaa", sCode);
            DataTable dtDispatch = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

            //获得单据号
            sSQL = "select max(cNumber) as cNumber From VoucherHistory  with (NOLOCK) Where  CardNumber='0303' and cContent is NULL";
            DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

            long lRdCode = 0;
            if (dt != null && dt.Rows.Count > 0)
            {
                lRdCode = BaseFunction.ReturnLong(dt.Rows[0]["cNumber"]);
            }
            else
            {
                lRdCode = 0;
            }

            lRdCode += 1;
            string sRdCode = lRdCode.ToString();
            while (sRdCode.Length < 10)
            {
                sRdCode = "0" + sRdCode;
            }

            long lID = -1;
            long lIDDisDetails = -1;
            sSQL = @"
declare @p5 int
set @p5=aaaaaa
declare @p6 int
set @p6=bbbbbb
exec sp_GetId N'00',N'dddddd',N'rd',cccccc,@p5 output,@p6 output,default
select @p5, @p6
";
            sSQL = sSQL.Replace("aaaaaa", lID.ToString());
            sSQL = sSQL.Replace("bbbbbb", lIDDisDetails.ToString());
            sSQL = sSQL.Replace("cccccc", 1.ToString());
            sSQL = sSQL.Replace("dddddd", sAccID);
            dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

            lID = BaseFunction.ReturnLong(dt.Rows[0][0]) - 1;
            lIDDisDetails = BaseFunction.ReturnLong(dt.Rows[0][1]) - 1;

            Model.rdrecord32 model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.rdrecord32();
            lID += 1;
            model.ID = lID;
            model.bRdFlag = 0;
            model.cVouchType = "32";
            model.cBusType = "普通销售";
            model.cSource = "发货单";
            model.cCode = sRdCode;
            model.cBusCode = sCode;
            if (sRdCode == "")
            {
                sRDCode = sRDCode + model.cRdCode;
            }
            else
            {
                sRDCode = sRDCode + "," + model.cRdCode;
            }
            model.cRdCode = dtDispatch.Rows[0]["cRdCode"].ToString().Trim();
            if (model.cRdCode.Trim() == "")
            {
                throw new Exception("Please set saletype");
            }

            //model.bIsLsQuery
            model.cWhCode = dtDispatch.Rows[0]["cWhCode"].ToString().Trim();
            model.dDate = dNowDate;
            model.cDepCode = dtDispatch.Rows[0]["cDepCode"].ToString().Trim();
            model.cSTCode = dtDispatch.Rows[0]["cSTCode"].ToString().Trim();
            model.cCusCode = dtDispatch.Rows[0]["cCusCode"].ToString().Trim();
            model.cDLCode = BaseFunction.ReturnLong(dtDispatch.Rows[0]["DLID"]);
            model.cMaker = sUserName;
            model.cDefine1 = dtDispatch.Rows[0]["cDefine1"].ToString().Trim();
            model.cDefine2 = dtDispatch.Rows[0]["cDefine2"].ToString().Trim();
            model.cDefine3 = dtDispatch.Rows[0]["cDefine3"].ToString().Trim();
            model.cDefine4 = BaseFunction.ReturnDate(dtDispatch.Rows[0]["cDefine4"]);
            model.cDefine5 = BaseFunction.ReturnLong(dtDispatch.Rows[0]["cDefine5"]);
            model.cDefine6 = BaseFunction.ReturnDate(dtDispatch.Rows[0]["cDefine6"]);
            model.cDefine7 = BaseFunction.ReturnDecimal(dtDispatch.Rows[0]["cDefine7"]);
            model.cDefine8 = dtDispatch.Rows[0]["cDefine8"].ToString().Trim();
            model.cDefine9 = dtDispatch.Rows[0]["cDefine9"].ToString().Trim();
            model.cDefine10 = dtDispatch.Rows[0]["cDefine10"].ToString().Trim();
            model.bpufirst = false;
            model.biafirst = false;
            model.VT_ID = 87;
            model.bIsSTQc = false;
            model.cDefine11 = dtDispatch.Rows[0]["cDefine11"].ToString().Trim();
            model.cDefine12 = dtDispatch.Rows[0]["cDefine12"].ToString().Trim();
            model.cDefine13 = dtDispatch.Rows[0]["cDefine13"].ToString().Trim();
            model.cDefine14 = dtDispatch.Rows[0]["cDefine14"].ToString().Trim();
            model.cDefine15 = BaseFunction.ReturnLong(dtDispatch.Rows[0]["cDefine15"]);
            model.cDefine16 = BaseFunction.ReturnDecimal(dtDispatch.Rows[0]["cDefine16"]);
            model.cShipAddress = dtDispatch.Rows[0]["cShipAddress"].ToString().Trim();
            model.bOMFirst = false;
            model.bFromPreYear = false;
            model.bIsComplement = 0;
            model.iDiscountTaxType = 0;
            model.ireturncount = 0;
            model.iverifystate = 0;
            model.iswfcontrolled = 0;
            model.dnmaketime = dNow;
            model.dnverifytime = dNow;
            model.bredvouch = 0;
            model.iPrintCount = 0;
            model.cinvoicecompany = model.cCusCode;
            DAL.rdrecord32 dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.rdrecord32();
            sSQL = dal.Add(model);
            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

            for (int i = 0; i < dtDispatch.Rows.Count; i++)
            {
                Model.rdrecords32 models = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.rdrecords32();
                lIDDisDetails += 1;
                models.AutoID = lIDDisDetails;
                models.ID = lID;
                models.cInvCode = dtDispatch.Rows[i]["cInvCode"].ToString().Trim();
                if (BaseFunction.ReturnDecimal(dtDispatch.Rows[i]["iNum"]) != 0)
                {
                    models.iNum = BaseFunction.ReturnDecimal(dtDispatch.Rows[i]["iNum"]);
                    models.iNNum = BaseFunction.ReturnDecimal(dtDispatch.Rows[i]["iNum"]);
                }
                models.iQuantity = BaseFunction.ReturnDecimal(dtDispatch.Rows[i]["iQuantity"]);
                models.cBatch = dtDispatch.Rows[i]["cBatch"].ToString().Trim();
                models.iFlag = 0;
                models.cDefine22 = dtDispatch.Rows[i]["cDefine22"].ToString().Trim();
                models.cDefine23 = dtDispatch.Rows[i]["cDefine23"].ToString().Trim();
                models.cDefine24 = dtDispatch.Rows[i]["cDefine24"].ToString().Trim();
                models.cDefine25 = dtDispatch.Rows[i]["cDefine25"].ToString().Trim();
                models.cDefine26 = BaseFunction.ReturnDecimal(dtDispatch.Rows[i]["cDefine26"]);
                models.cDefine27 = BaseFunction.ReturnDecimal(dtDispatch.Rows[i]["cDefine27"]);
                models.cDefine28 = dtDispatch.Rows[i]["cDefine28"].ToString().Trim();
                models.cDefine29 = dtDispatch.Rows[i]["cDefine29"].ToString().Trim();
                models.cDefine30 = dtDispatch.Rows[i]["cDefine30"].ToString().Trim();
                models.cDefine31 = dtDispatch.Rows[i]["cDefine31"].ToString().Trim();
                models.cDefine32 = dtDispatch.Rows[i]["cDefine32"].ToString().Trim();
                models.cDefine33 = dtDispatch.Rows[i]["cDefine33"].ToString().Trim();
                models.cDefine34 = BaseFunction.ReturnInt(dtDispatch.Rows[i]["cDefine34"]);
                models.cDefine35 = BaseFunction.ReturnInt(dtDispatch.Rows[i]["cDefine35"]);
                models.cDefine36 = BaseFunction.ReturnDate(dtDispatch.Rows[i]["cDefine36"]);
                models.iDLsID = BaseFunction.ReturnLong(dtDispatch.Rows[i]["iDLsID"]);
                models.iNQuantity = BaseFunction.ReturnDecimal(dtDispatch.Rows[i]["iQuantity"]);
                models.bLPUseFree = false;
                models.iRSRowNO = 0;
                models.iOriTrackID = 0;
                models.bCosting = true;
                models.bVMIUsed = false;
                models.cbdlcode = sCode;
                models.iExpiratDateCalcu = 0;
                models.iorderdid = BaseFunction.ReturnInt(dtDispatch.Rows[i]["iSOsID"]);
                models.iordertype = 1;
                models.iordercode = dtDispatch.Rows[i]["cSourceCode"].ToString().Trim();
                models.ipesotype = 0;
                models.ipesodid = dtDispatch.Rows[i]["cSourceCode"].ToString().Trim();
                models.cpesocode = dtDispatch.Rows[i]["cSourceCode"].ToString().Trim();
                models.ipesoseq = BaseFunction.ReturnInt(dtDispatch.Rows[i]["iorderrowno"]);
                models.iorderseq = BaseFunction.ReturnInt(dtDispatch.Rows[i]["iorderrowno"]);
                models.isotype = 0;
                models.irowno = i + 1;
                models.bIAcreatebill = false;
                models.bsaleoutcreatebill = false;
                models.isaleoutid = 0;
                models.bneedbill = true;

                DAL.rdrecords32 dals = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.rdrecords32();
                sSQL = dals.Add(models);
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


            }
            if (lID > 1000000000)
            {
                lID = lID - 1000000000;
            }
            if (lIDDisDetails > 1000000000)
            {
                lIDDisDetails = lIDDisDetails - 1000000000;
            }
            sSQL = "update UFSystem..UA_Identity set iFatherId = " + lID.ToString() + ",iChildId = " + lIDDisDetails + " where cAcc_Id = '" + sAccID + "' and cVouchType = 'rd'";
            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

            sSQL = @"
if exists(select * from VoucherHistory Where CardNumber='0303' and cContent is NULL)
	update VoucherHistory set cNumber = bbbbbb Where  CardNumber='0303' and cContent is NULL
else
	insert into VoucherHistory(CardNumber,cContent,cContentRule,cSeed,cNumber,bEmpty)
	values('0303',null,null,null,'bbbbbb',0)
";
            sSQL = sSQL.Replace("aaaaaa", dNow.ToString("yyyy"));
            sSQL = sSQL.Replace("bbbbbb", lRdCode.ToString());
            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

            sSQL = @"
exec IA_SP_WriteUnAccountVouchForST32 aaaaaa,N'32',N'发货单',N'普通销售'
";
            sSQL = sSQL.Replace("aaaaaa", lID.ToString());
            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);



            sSQL = @"
 Update DispatchList SET cSaleOut=N'aaaaaa' WHERE DispatchList.DLID=bbbbbb
";
            sSQL = sSQL.Replace("aaaaaa", sRdCode);
            sSQL = sSQL.Replace("bbbbbb", dtDispatch.Rows[0]["DLID"].ToString().Trim());
            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
         
            return sRdCode;
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridColchoose, chkAll.Checked);
                }
            }
            catch { }
        }
    }
}
