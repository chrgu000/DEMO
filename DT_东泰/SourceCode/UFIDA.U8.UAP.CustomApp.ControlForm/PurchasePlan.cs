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

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class PurchasePlan : UserControl
    {
        TH.BaseClass.GetBaseData getBaseData = new GetBaseData();
        
        string sProPath = Application.StartupPath;

        UFIDA.U8.UAP.CustomApp.ControlForm.RepBaseGrid Rep = new RepBaseGrid();

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        private void SetLookUp()
        {
            string sSQL = "select cVenCode,cVenName,cVenDefine7 as Brand from Vendor where isnull(cVenDefine3 ,'') = 'Y' order by cVenDefine7,cVenCode";
            DataTable dt = DbHelperSQL.Query(sSQL);
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditcVenName.Properties.DataSource = dt;

            sSQL = "select cexch_code,cexch_name from foreigncurrency order by cexch_code";
            dt = DbHelperSQL.Query(sSQL);
            lookUpEditforeigncurrency.Properties.DataSource = dt;
            lookUpEditforeigncurrencyName.Properties.DataSource = dt;
            lookUpEditforeigncurrency.EditValue = "SGD";
            lookUpEditforeigncurrencyName.EditValue = "SGD";
            ItemLookUpEditCurrency.DataSource = dt;
        }



        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                DbHelperSQL.connectionString = Conn;
                SetLookUp();

                btnClear_Click(null, null);

                gridBand1.Width = 470;
                gridColbChoose.Width = 70;
                gridColcInvCode.Width = 80;
                gridColcInvName.Width = 320;
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        public PurchasePlan()
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
                    MessageBox.Show("导出Excel成功\n\t路径：" + sF.FileName);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sErr = "";
            int iCount = 0;
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }


                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sSQL = "select getdate()";
                    DateTime dNow = BaseFunction.ReturnDate(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                    DateTime dNowDate = BaseFunction.ReturnDate(dNow.ToString("yyyy-MM-dd"));

                    int iRowCou = 0;
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        bool bChoose = BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColbChoose));
                        if (!bChoose)
                            continue;

                        decimal dQty = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColOrderQty));
                        if (dQty <= 0)
                            continue;

                        DateTime dDate = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridColPlanDate));
                        if (dNowDate > dDate)
                        {
                            dDate = dNowDate;
                        }
                        iRowCou += 1;
                    }

                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }

                    sSQL = @"
declare @p5 int
set @p5=1000000003
declare @p6 int
set @p6=1000000005
exec sp_getID N'00',N'111111',N'Pomain',222222,@p5 output,@p6 output
select @p5, @p6
";

                    sSQL = sSQL.Replace("111111", sAccID);
                    sSQL = sSQL.Replace("222222", iRowCou.ToString());
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    long iID = BaseFunction.ReturnLong(dt.Rows[0][0]);
                    long iIDDetails = BaseFunction.ReturnLong(dt.Rows[0][1]);
                    iIDDetails = iIDDetails - iRowCou;

                    sSQL = @"
select isnull(max(cNumber),0) as Maxnumber From VoucherHistory  with (NOLOCK) Where CardNumber = '88' and cContent like '%单据日期|采购类型%' and cSeed = 'aaaaaaaa'
";
                    sSQL = sSQL.Replace("aaaaaaaa", BaseFunction.ReturnDate(sLogDate).ToString("yyyy") + "1");
                    DataTable dtCode = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    long iVouch = 0;
                    dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt == null || dt.Rows.Count == 0)
                        iVouch = 0;
                    else
                        iVouch = BaseFunction.ReturnLong(dt.Rows[0][0]);

                    iVouch +=1;

                    Model.PO_Pomain model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.PO_Pomain();


                    sSQL = "select * from PurchaseType where isnull(bDefault,0) = 1";
                    DataTable dtCodeType = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtCodeType == null || dtCodeType.Rows.Count < 1)
                    {
                        throw new Exception("Please set purchase category");
                    }

                    model.cPTCode = dtCodeType.Rows[0]["cPTCode"].ToString().Trim();

                    model.cPOID = sGetVouCode(BaseFunction.ReturnDate(sLogDate).ToString("yyyy"), iVouch, model.cPTCode);
                    model.dPODate = BaseFunction.ReturnDate(sLogDate);

                    sSQL = "select * from Vendor where cVenCode = '" + gridView1.GetRowCellValue(0, gridColcVenCode).ToString().Trim() + "' or cVenName = '" + gridView1.GetRowCellValue(0, gridColcVenCode).ToString().Trim() + "' or cVenAbbName = '" + gridView1.GetRowCellValue(0, gridColcVenCode).ToString().Trim() + "'";
                    DataTable dtVendor = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtVendor == null || dtVendor.Rows.Count == 0)
                    {
                        throw new Exception("Vendor error");
                    }
                    model.cVenCode = dtVendor.Rows[0]["cVenCode"].ToString().Trim();

                    if (dtVendor.Rows[0]["cVenDepart"].ToString().Trim() == "")
                    {
                        throw new Exception("Vendor Department error");
                    }
                    model.cDepCode = dtVendor.Rows[0]["cVenDepart"].ToString().Trim();

                    if (dtVendor.Rows[0]["cVenPPerson"].ToString().Trim() != "")
                    {
                        model.cPersonCode = dtVendor.Rows[0]["cVenPPerson"].ToString().Trim();
                    }

                    if (dtVendor.Rows[0]["cVenExch_name"].ToString().Trim() == "")
                    {
                        model.cexch_name = "SGD";
                    }
                    else
                    {
                        model.cexch_name = dtVendor.Rows[0]["cVenExch_name"].ToString().Trim();
                    }
                    model.nflat = 1;

                    decimal dTax = BaseFunction.ReturnDecimal(dtVendor.Rows[0]["iVenTaxRate"]);
                    if (dTax > 0)
                    { }
                    else
                    {
                        model.iTaxRate = 7;
                    }
                    model.iCost = 0;
                    model.iBargain = 0;
                    model.cState = 0;
                    model.cMaker = sUserName;
                    model.POID = iID;
                    model.iVTid = 8173;
                    model.cBusType = "普通采购";
                    model.iDiscountTaxType = 0;
                    model.IsWfControlled = false;
                    model.cmaketime = dNow;
                    model.iPrintCount = 0;
                    model.cVerifier = sUserName;
                    model.iverifystateex = 2;
                    model.cAuditDate = dNowDate;
                    model.cAuditTime = dNow;

                    DAL.PO_Pomain dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.PO_Pomain();
                    sSQL = dal.Add(model);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = @"
if exists(select * From VoucherHistory  with (NOLOCK) Where CardNumber = '88' and cContent like '%单据日期%' and cSeed = N'aaaaaaaa')
    update VoucherHistory set cNumber = bbbbbbbb Where  CardNumber=N'88' and cContent like '%单据日期%' and cSeed = N'aaaaaaaa'
else
    insert into VoucherHistory(CardNumber,  cContent, cContentRule, cSeed, cNumber, bEmpty)
    values(N'88',N'单据日期|采购类型',N'YYYY|',N'aaaaaaaa',bbbbbbbb,0)
";
                    sSQL = sSQL.Replace("aaaaaaaa", BaseFunction.ReturnDate(sLogDate).ToString("yyyy") + "1");
                    sSQL = sSQL.Replace("bbbbbbbb", iVouch.ToString());

                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    int iRowNo = 0;
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        bool bChoose = BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColbChoose));
                        if (!bChoose)
                            continue;

                        decimal dQty = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColOrderQty));
                        if (dQty <= 0)
                            continue;

                        sSQL = "select * from Inventory where cInvCode = '" + gridView1.GetRowCellDisplayText(i, gridColcInvCode).ToString().Trim() + "'";
                        DataTable dtInv = DbHelperSQL.ExecuteDataset(tran,CommandType.Text,sSQL).Tables[0];

                        iIDDetails += 1;

                        Model.PO_Podetails models = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.PO_Podetails();
                        models.ID = iIDDetails;
                        models.cInvCode = gridView1.GetRowCellDisplayText(i, gridColcInvCode).ToString().Trim();
                        models.iQuantity = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColOrderQty));
                        decimal dNum = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColOrderNum));
                        if (dNum != 0)
                        {
                            models.iNum = dNum;
                        }
                        models.cDefine26 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColvolume));
                        models.cDefine27 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColweight)); 

                        decimal dPrice = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColPrice));
                        if(dPrice ==0)
                        {
                            throw new Exception("Row " + (i + 1).ToString() + " please set vendor price");
                        }
                        
                        decimal dTaxRate = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColTaxRate));
                        if(dTaxRate == 0)
                            dTaxRate = 7;
                        models.iPerTaxRate = dTaxRate;
                        models.iUnitPrice = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColPrice));
                        models.iMoney = BaseFunction.ReturnDecimal(models.iUnitPrice * models.iQuantity, 6);
                        models.iTaxPrice = BaseFunction.ReturnDecimal(models.iUnitPrice * (1 + models.iPerTaxRate / 100));
                        models.iSum = BaseFunction.ReturnDecimal(models.iTaxPrice * models.iQuantity, 6);
                        models.iTax = models.iSum - models.iMoney;

                        decimal iFlat = BaseFunction.ReturnDecimal(txtnflat.Text.Trim());

                        if (iFlat == 1)
                        {
                            models.iNatUnitPrice = models.iUnitPrice;
                        }
                        else
                        {
                            if (radio2.Checked)
                            {
                                models.iNatUnitPrice = BaseFunction.ReturnDecimal(models.iUnitPrice / iFlat);
                            }
                            if (radio1.Checked)
                            {
                                models.iNatUnitPrice = BaseFunction.ReturnDecimal(models.iUnitPrice * iFlat);
                            }
                        }
                        models.iNatMoney = BaseFunction.ReturnDecimal(models.iNatUnitPrice * models.iQuantity, 6);
                        models.iNatSum = BaseFunction.ReturnDecimal(models.iNatMoney * (1 + models.iPerTaxRate / 100));
                        models.iNatTax = models.iNatSum - models.iNatMoney;

                   
                        models.dArriveDate = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridColPlanDate));


                        models.bGsp = 0;
                        models.POID = iID;
                        models.cUnitID = dtInv.Rows[0]["cSAComUnitCode"].ToString().Trim();
                        models.bTaxCost = true;

                        iRowNo += 1;
                        //models.irowno = iRowNo;
                        models.ivouchrowno = iRowNo;

                        DAL.PO_Podetails dals = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.PO_Podetails();
                        sSQL = dals.Add(models);
                        iCount = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                        sSQL = "update PO_Pomain set iTaxrate = " + models.iPerTaxRate.ToString() + " where poid = " + iID.ToString();
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    }


                    if (iCount > 0)
                    {
                        tran.Commit();
                        MessageBox.Show("OK\n" + model.cPOID);
                        gridControl1.DataSource = null;
                    }
                    else
                    {
                        throw new Exception("no data");
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

        private string sGetVouCode(string sYear,long l,string sPTCode)
        {
            string sVouCode = l.ToString();
            while (sVouCode.ToString().Length < 3)
            {
                sVouCode = "0" + sVouCode;
            }

            return "PO" + sYear + "-" + sPTCode + sVouCode;
        }


        private void ItemButtonEditcInvCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                gridView1.FocusedColumn = gridColcInvName;
                string sInvCode = gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, gridColcInvCode).ToString().Trim();

                gridView1.FocusedColumn = gridColcInvCode;

                FrmInvInfo frm = new FrmInvInfo(sInvCode, false);
                DialogResult d = frm.ShowDialog();
                if (d == DialogResult.OK)
                {
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridColcInvCode, frm.sInvCode);
                }
                else
                {
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载存货档案失败:" + ee.Message);
            }
        }

        private void ItemButtonEditcInvCode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F2)
                {
                    ItemButtonEditcInvCode_ButtonClick(null, null);
                }
            }
            catch { }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lookUpEditcVenName.EditValue = DBNull.Value;

            dtm1.DateTime = DateTime.Today.AddMonths(-3);
            dtm2.DateTime = DateTime.Today;

            long iMonths = 4;
            txtParameter.Text = "";
            txtMonths.Text = iMonths.ToString();

            AddCol();

            gridControl1.DataSource = null;
        }

        private void btncalculate_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;

                    chkAll.Checked = false;
                }
                catch { }

                if (lookUpEditcVenName.EditValue == null || lookUpEditcVenName.EditValue.ToString().Trim() == "" || lookUpEditcVenName.Text.Trim() == "")
                {
                    btnTxtVenCode.Focus();
                    throw new Exception("Please choose supplier");
                }

                if (BaseFunction.ReturnDecimal(txtParameter.Text.Trim()) <= 0)
                {
                    txtParameter.Focus();
                    throw new Exception("Please set parameter");
                }

                AddCol();

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sSQL = @"
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_TempTH_Sales]') AND type in (N'U'))
    DROP TABLE [dbo].[_TempTH_Sales]

Select distinct a.cInvCode,b.cInvName,b.cInvStd,a.cVenCode,d.cVenName,cast (null as decimal(16,0)) as AllMonth,b.iInvAdvance 
	,cast (null as decimal(16,0)) as Month01,cast (null as decimal(16,0)) as Month02,cast (null as decimal(16,0)) as Month03
	,cast (null as decimal(16,0)) as Month04,cast (null as decimal(16,0)) as Month05,cast (null as decimal(16,0)) as Month06
	,cast (null as decimal(16,0)) as Month07,cast (null as decimal(16,0)) as Month08,cast (null as decimal(16,0)) as Month09
	,cast (null as decimal(16,0)) as Month10,cast (null as decimal(16,0)) as Month11,cast (null as decimal(16,0)) as Month12
	,cast (c.CurrQty as decimal(16,0)) as CurrQty,cast (null as decimal(16,0)) as OnLoadQty,cast (null as decimal(16,0)) as SugQty
	,cast (null as decimal(16,0)) as OrderQty,cast (e.cComUnitName as varchar(50)) as PM,cast (null as datetime) as ETA
into _TempTH_Sales
From pu_veninvpricelst a inner join Inventory b on a.cInvCode = b.cInvCode left join ComputationUnit e on b.cPUComUnitCode = e.cComunitCode 
    left join 
    (
        select cInvCode,sum(iQuantity) as CurrQty
        from CurrentStock
        group by cInvCode
    ) c on a.cInvCode = c.cInvCode
    left join Vendor d on a.cVenCode = d.cVenCode
Where 1=1 and isnull(b.bPurchase,0) = 1 and isnull(dEDate ,'2099-12-31') >= getdate()
ORDER BY a.cInvCode,b.cInvName,b.cInvStd

update _TempTH_Sales set AllMonth = a.iQty
from (
select sum(b.iQuantity) as iQty,b.cInvCode
from SaleBillVouch a inner join SaleBillVouchs b on a.SBVID = b.SBVID
where a.dDate >= '111111' and a.dDate < '222222'
group by b.cInvCode
)a 
where a.cInvCode = _TempTH_Sales.cInvCode

--采购在途
update _TempTH_Sales set OnLoadQty = isnull(a.OnLoadQty,0)
from (
	select sum(iQuantity - isnull(b.iReceivedQTY,0) - isnull(iarrQty,0)) as OnLoadQty,b.cInvCode
	from PO_Pomain a inner join PO_Podetails b on a.POID = b.POID
	where isnull(a.cVerifier ,'') <> '' and isnull(a.cCloser,'') = '' and isnull(b.cbCloser ,'') = ''
	group by  b.cInvCode
	having sum(iQuantity - isnull(b.iReceivedQTY,0) - isnull(iarrQty,0)) > 0 
)a 
where a.cInvCode = _TempTH_Sales.cinvcode

update _TempTH_Sales set OnLoadQty = 0 where isnull(OnLoadQty,0) = 0

";
                    sSQL = sSQL.Replace("111111", dtm1.DateTime.ToString("yyyy-MM-01"));
                    sSQL = sSQL.Replace("222222", dtm2.DateTime.AddMonths(1).ToString("yyyy-MM-01"));
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cVenCode = '" + lookUpEditcVenName.EditValue.ToString().Trim() + "' ");

                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    int iYear1 = BaseFunction.ReturnInt(dtm1.DateTime.ToString("yyyy"));
                    int iYear2 = BaseFunction.ReturnInt(dtm2.DateTime.ToString("yyyy"));
                    int iMonth1 = BaseFunction.ReturnInt(dtm1.DateTime.ToString("MM"));
                    int iMonth2 = BaseFunction.ReturnInt(dtm2.DateTime.ToString("MM"));
                    int iCount = 0;
                    while (iCount < 12)
                    {
                        if (iMonth2 + 12 * (iYear2 - iYear1) >= iMonth1 + 12)
                            break;

                        sSQL = @"
update _TempTH_Sales set Month3333 = a.iQty
from (
select sum(b.iQuantity) as iQty,b.cInvCode
from SaleBillVouch a inner join SaleBillVouchs b on a.SBVID = b.SBVID
where a.dDate >= '1111-01' and a.dDate < '2222-01'
group by b.cInvCode
)a 
where _TempTH_Sales.cInvCode = a.cInvCode
";
                        sSQL = sSQL.Replace("1111", dtm1.DateTime.AddMonths(iCount).ToString("yyyy-MM"));
                        sSQL = sSQL.Replace("2222", dtm1.DateTime.AddMonths(iCount + 1).ToString("yyyy-MM"));
                        sSQL = sSQL.Replace("3333", dtm1.DateTime.AddMonths(iCount).ToString("MM"));
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        iCount += 1;
                    }

                    sSQL = @"
select cast(0 as bit) as bChoose,* 
    ,cast(null as decimal(16,6)) as volumeP
    ,cast(null as decimal(16,6)) as weightP
    ,cast(null as decimal(16,4)) as volume
    ,cast(null as decimal(16,4)) as weight
    ,cast(null as decimal(16,6)) as changrate
    ,cast(null as decimal(16,6)) as OrderNum
    ,cast(null as decimal(16,4)) as Price
    ,cast(null as decimal(16,4)) as Money
    ,cast(null as decimal(16,6)) as TaxRate
    ,cast(null as varchar(50)) as Currency
from _TempTH_Sales
order by cInvCode
";
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        decimal dSales = BaseFunction.ReturnDecimal(dt.Rows[i]["AllMonth"]);
                        decimal iMonths = BaseFunction.ReturnInt(txtMonths.Text.Trim());
                        decimal iParameter = BaseFunction.ReturnDecimal(txtParameter.Text.Trim(), 2);
                        decimal dCurrQty = BaseFunction.ReturnDecimal(dt.Rows[i]["CurrQty"]);
                        decimal dOnLoadQty = BaseFunction.ReturnDecimal(dt.Rows[i]["OnLoadQty"]);

                        if (iMonths == 0)
                            continue;

                        decimal dOrder = dSales / iMonths * iParameter - dCurrQty - dOnLoadQty;

                        sSQL = "select * from Inventory where cInvCode = '" + dt.Rows[i]["cInvCode"].ToString().Trim() + "'";
                        DataTable dtInv = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtInv != null && dtInv.Rows.Count > 0)
                        {
                            dt.Rows[i]["volumeP"] = BaseFunction.ReturnDecimal(dtInv.Rows[0]["cInvDefine13"]);
                            dt.Rows[i]["weightP"] = BaseFunction.ReturnDecimal(dtInv.Rows[0]["cInvDefine14"]);

                            decimal dvolume = BaseFunction.ReturnDecimal(dtInv.Rows[0]["cInvDefine13"]);
                            decimal dweight = BaseFunction.ReturnDecimal(dtInv.Rows[0]["cInvDefine14"]);

                            if (dOrder > 0)
                            {
                                dt.Rows[i]["SugQty"] = dOrder;
                                dt.Rows[i]["OrderQty"] = dOrder;
                            }

                            string sPUComUnit = dtInv.Rows[0]["cPUComUnitCode"].ToString().Trim();
                            sSQL = "select * from ComputationUnit where cComunitCode = '" + sPUComUnit + "' and cGroupCode = '" + dtInv.Rows[0]["cGroupCode"].ToString().Trim() + "'";
                            DataTable dtComputationUnit = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                            if (sPUComUnit != "")
                            {
                                if (dtComputationUnit != null && dtComputationUnit.Rows.Count > 0)
                                {
                                    decimal diChangRate = BaseFunction.ReturnDecimal(dtComputationUnit.Rows[0]["iChangRate"]);
                                    dt.Rows[i]["changrate"] = diChangRate;

                                    if (dOrder > 0)
                                    {
                                        decimal iNum = BaseFunction.ReturnDecimal(dOrder / diChangRate);

                                        dt.Rows[i]["OrderNum"] = iNum;
                                        dt.Rows[i]["volume"] = iNum * dvolume;

                                        dt.Rows[i]["weight"] = iNum * dweight;
                                    }
                                }
                            }
                        }
                        //设置价格
                        string sForeigncurrency = lookUpEditforeigncurrency.EditValue.ToString().Trim();
                        string sVenCode = lookUpEditcVenName.EditValue.ToString().Trim();
                        string sInvCode = dt.Rows[i]["cInvCode"].ToString().Trim();
                        decimal dQty = BaseFunction.ReturnDecimal(dt.Rows[i]["OrderQty"]);

                        sSQL = @"
select a.dEnableDate,a.dDisableDate ,a.iLowerLimit ,a.iUpperLimit ,* ,a.iTaxRate as iInvTaxRate
from ven_inv_price a inner join Inventory b on a.cInvCode = b.cInvCode
where a.iSupplyType = 1 and a.cVenCode = '222222' 
	and a.cInvCode = '333333'
	and a.iLowerLimit <= 444444 
	and isnull(a.dEnableDate,'2000-01-01') <= '111111'
	and isnull(a.dDisableDate,'2099-12-30') >= '111111'
    and (ltrim(rtrim(a.cexch_name)) = '555555' or a.cexch_name = '666666')
order by a.iLowerLimit desc,a.dEnableDate desc

";
                        sSQL = sSQL.Replace("111111", sLogDate);
                        sSQL = sSQL.Replace("222222", sVenCode);
                        sSQL = sSQL.Replace("333333", sInvCode);
                        sSQL = sSQL.Replace("444444", dQty.ToString());
                        sSQL = sSQL.Replace("555555", lookUpEditforeigncurrencyName.Text.Trim());
                        sSQL = sSQL.Replace("666666", lookUpEditforeigncurrency.EditValue.ToString().Trim());
                        DataTable dtPrice = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        if (dtPrice != null && dtPrice.Rows.Count > 0)
                        {
                            decimal dPrice = BaseFunction.ReturnDecimal(dtPrice.Rows[0]["iUnitPrice"]);
                            decimal dSum = BaseFunction.ReturnDecimal(dPrice * dQty);

                            dt.Rows[i]["Price"] = dPrice;
                            dt.Rows[i]["Money"] = dSum;
                            dt.Rows[i]["TaxRate"] = BaseFunction.ReturnDecimal(dtPrice.Rows[0]["iInvtaxRate"]);
                        }

                        //计划到货期
                        int iDays = BaseFunction.ReturnInt(dt.Rows[i]["iInvAdvance"]);
                        DateTime dArr = BaseFunction.ReturnDate(sLogDate).AddDays(iDays);
                        if (dArr < DateTime.Today)
                        {
                            dArr = DateTime.Today.AddDays(iDays);
                        }

                        dt.Rows[i]["ETA"] = dArr.ToString("yyyy-MM-dd");
                    }

                    gridControl1.DataSource = dt;

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
                MessageBox.Show(ee.Message);
            }
        }

        private void lookUpEditcVenName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                btnTxtVenCode.Text = lookUpEditcVenName.EditValue.ToString().Trim();

                string sVenCode = lookUpEditcVenName.EditValue.ToString().Trim();
                string sSQL = @"
select b.cexch_code ,a.cVenExch_name ,cVenDefine10
from Vendor a left join foreigncurrency b on a.cVenExch_name  = b.cexch_name 
where a.cVenCode = '111111'
";
                sSQL = sSQL.Replace("111111", sVenCode);
                DataTable dt = DbHelperSQL.Query(sSQL);
                if (dt != null && dt.Rows.Count > 0)
                {
                    lookUpEditforeigncurrency.EditValue = dt.Rows[0]["cexch_code"].ToString().Trim();
                    richTextBox1.Text = dt.Rows[0]["cVenDefine10"].ToString().Trim();
                }
                else
                {
                    richTextBox1.Text = "";
                }
            }
            catch { }
        }

        private void AddCol()
        {
            int iYear1 = BaseFunction.ReturnInt(dtm1.DateTime.ToString("yyyy"));
            int iYear2 = BaseFunction.ReturnInt(dtm2.DateTime.ToString("yyyy"));
            int iMonth1 = BaseFunction.ReturnInt(dtm1.DateTime.ToString("MM"));
            int iMonth2 = BaseFunction.ReturnInt(dtm2.DateTime.ToString("MM"));


            if (iMonth2 + 12 * (iYear2 - iYear1) >= iMonth1 + 12)
            {
                throw new Exception("Allow only 12 months");
            }

            for (int i = gridView1.Columns.Count - 1; i >= 0; i--)
            {
                string sColName = gridView1.Columns[i].Name;
                if (sColName.Length > 12 && sColName.Substring(0, 12) == "gridColMonth")
                {
                    gridView1.Columns.RemoveAt(i);
                }
            }

            iMonth1 -= 1;
            for (int i = 0; i < BaseFunction.ReturnInt(txtMonths.Text); i++)
            {
                iMonth1 = iMonth1 + 1;
                if (iMonth1 > 12)
                    iMonth1 = iMonth1 - 12;

                DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColMonth1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
                gridColMonth1.AppearanceHeader.Options.UseTextOptions = true;
                gridColMonth1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridColMonth1.Caption = GetMonth(BaseFunction.ReturnInt(iMonth1.ToString()));
                if (iMonth1.ToString().Trim().Length == 1)
                {
                    gridColMonth1.Name = "gridColMonth0" + iMonth1.ToString();
                    gridColMonth1.FieldName = "Month0" + iMonth1.ToString();
                }
                else
                {
                    gridColMonth1.Name = "gridColMonth" + iMonth1.ToString();
                    gridColMonth1.FieldName = "Month" + iMonth1.ToString();
                }
                gridColMonth1.OptionsColumn.AllowEdit = false;
                gridColMonth1.Visible = true;
                gridColMonth1.Width = 50;
                gridColMonth1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridColMonth1.ColumnEdit = this.ItemTextEditn0;

                gridBand2.Columns.Add(gridColMonth1);
            }

            for (int i = gridView1.Columns.Count - 1; i >= 0; i--)
            {
                string sColName = gridView1.Columns[i].Name;
                if (sColName.Length > 12 && sColName.Substring(0, 12) == "gridColMonth")
                {
                    gridView1.Columns[i].Width = 50;
                }
            }

        }

        private string GetMonth(int i)
        { 
            string sMonth = "";
            switch (i)
            {
                case 1:
                    sMonth = "Jan";
                    break;
                case 2:
                    sMonth = "Feb";
                    break;
                case 3:
                    sMonth = "Mar";
                    break;
                case 4:
                    sMonth = "Apr";
                    break;
                case 5:
                    sMonth = "May";
                    break;
                case 6:
                    sMonth = "Jun";
                    break;
                case 7:
                    sMonth = "Jul";
                    break;
                case 8:
                    sMonth = "Aug";
                    break;
                case 9:
                    sMonth = "Sep";
                    break;
                case 10:
                    sMonth = "Oct";
                    break;
                case 11:
                    sMonth = "Nov";
                    break;
                case 12:
                    sMonth = "Dec";
                    break;
                default:
                    sMonth = "";
                    break;
                    
            }
            return sMonth;
        }

        private void dtm_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int iYear1 = BaseFunction.ReturnInt(dtm1.DateTime.ToString("yyyy"));
                int iYear2 = BaseFunction.ReturnInt(dtm2.DateTime.ToString("yyyy"));
                int iMonth1 = BaseFunction.ReturnInt(dtm1.DateTime.ToString("MM"));
                int iMonth2 = BaseFunction.ReturnInt(dtm2.DateTime.ToString("MM"));


                if (iMonth2 + 12 * (iYear2 - iYear1) >= iMonth1 + 12)
                {
                    throw new Exception("Allow only 12 months");
                }

                //txtParameter.Text = (iMonth2 + 12 * (iYear2 - iYear1) - iMonth1 + 1).ToString();
                txtMonths.Text = (iMonth2 + 12 * (iYear2 - iYear1) - iMonth1 + 1).ToString();
            }
            catch { }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridColbChoose, chkAll.Checked);
                }
            }
            catch { }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedColumn = gridColvolume;
                    gridView1.FocusedColumn = gridColOrderQty;
                }
                catch { }

                if (e.Column == gridColOrderQty)
                {
                    int iFocRow = e.RowHandle;
                    decimal dChangeRate = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(iFocRow, gridColchangrate));
                    decimal dQty = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(iFocRow, gridColOrderQty));
                    decimal dWeightP = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(iFocRow, gridColweightP));
                    decimal dVolumeP = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(iFocRow, gridColvolumeP));

                    if (dChangeRate > 0)
                    {
                        decimal dNum = BaseFunction.ReturnDecimal(dQty / dChangeRate);

                        decimal dWeight = BaseFunction.ReturnDecimal(dNum * dWeightP);
                        gridView1.SetRowCellValue(iFocRow, gridColweight, dWeight);

                        decimal dNumNow = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(iFocRow, gridColOrderNum));
                        if (dNumNow != BaseFunction.ReturnDecimal(dQty / dChangeRate))
                        {
                            gridView1.SetRowCellValue(iFocRow, gridColOrderNum, dNum);
                        }

                        decimal dVolume = BaseFunction.ReturnDecimal(dNum * dVolumeP);
                        gridView1.SetRowCellValue(iFocRow, gridColvolume, dVolume);
                    }

                    decimal dPrice = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(iFocRow, gridColPrice));
                    decimal dSum = BaseFunction.ReturnDecimal(dPrice * dQty);
                    gridView1.SetRowCellValue(iFocRow, gridColMoney, dSum);

                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle = iFocRow;
                }
                if (e.Column == gridColOrderNum)
                {
                    int iFocRow = e.RowHandle;
                    decimal dChangeRate = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(iFocRow, gridColchangrate));
                    decimal dNum = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(iFocRow, gridColOrderNum));
                   
                    if (dChangeRate > 0)
                    {
                        decimal dQty = BaseFunction.ReturnDecimal(dNum * dChangeRate);

                        decimal dQtyNow = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(iFocRow, gridColOrderQty));
                        if (dQtyNow != dQty)
                        {
                            gridView1.SetRowCellValue(iFocRow, gridColOrderQty, dQty);
                        }
                    }

                    gridView1.FocusedColumn = gridColOrderNum;
                }
            }
            catch { }
        }

        private void lookUpEditforeigncurrency_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "";

                lookUpEditforeigncurrencyName.EditValue = lookUpEditforeigncurrency.EditValue;

                string sForeigncurrency = lookUpEditforeigncurrencyName.Text.Trim();
                if (lookUpEditforeigncurrencyName.EditValue.ToString().Trim().ToLower() != "sgd")
                {
                    sSQL = @" 
select * 
from exch a inner join foreigncurrency b on a.cexch_name = b.cexch_name
where a.cexch_name = '111111' and a.iYear = '222222' and a.iperiod = 333333
";
                    sSQL = sSQL.Replace("111111", sForeigncurrency);
                    sSQL = sSQL.Replace("222222", BaseFunction.ReturnDate(sLogDate).ToString("yyyy"));
                    sSQL = sSQL.Replace("333333", BaseFunction.ReturnInt(BaseFunction.ReturnDate(sLogDate).ToString("MM")).ToString());
                    DataTable dtCxch = DbHelperSQL.Query(sSQL);
                    if (dtCxch == null || dtCxch.Rows.Count == 0)
                    {
                        throw new Exception("Please set exchange rate");
                    }
                    txtnflat.Text = dtCxch.Rows[0]["nflat"].ToString().Trim();
                    bool b = BaseFunction.ReturnBool(dtCxch.Rows[0]["bcal"]);
                    if (b)
                        radio1.Checked = true;
                    else
                        radio2.Checked = true;
                }
                else
                {
                    txtnflat.Text = "1";
                }

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    string sVenCode = lookUpEditcVenName.EditValue.ToString().Trim();
                    string sInvCode = gridView1.GetRowCellValue(i, gridColcInvCode).ToString().Trim();
                    decimal dQty = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColOrderNum));


                    sSQL = @"
select a.dEnableDate,a.dDisableDate ,a.iLowerLimit ,a.iUpperLimit ,* ,a.iTaxRate as iInvTaxRate
from ven_inv_price a inner join Inventory b on a.cInvCode = b.cInvCode
where a.iSupplyType = 1 and a.cVenCode = '222222' 
	and a.cInvCode = '333333'
	and a.iLowerLimit <= 444444 
	and isnull(a.dEnableDate,'2000-01-01') <= '111111'
	and isnull(a.dDisableDate,'2099-12-30') >= '111111'
    and (ltrim(rtrim(a.cexch_name)) = '555555' or a.cexch_name = '666666')
order by a.iLowerLimit desc,a.dEnableDate desc

";
                    sSQL = sSQL.Replace("111111", sLogDate);
                    sSQL = sSQL.Replace("222222", sVenCode);
                    sSQL = sSQL.Replace("333333", sInvCode);
                    sSQL = sSQL.Replace("444444", dQty.ToString());
                    sSQL = sSQL.Replace("555555", lookUpEditforeigncurrencyName.Text.Trim());
                    sSQL = sSQL.Replace("666666", lookUpEditforeigncurrency.EditValue.ToString().Trim());
                    DataTable dtPrice = DbHelperSQL.Query(sSQL);

                    if (dtPrice != null && dtPrice.Rows.Count > 0)
                    {
                        decimal dPrice = BaseFunction.ReturnDecimal(dtPrice.Rows[0]["iUnitPrice"]);
                        decimal dSum = BaseFunction.ReturnDecimal(dPrice * dQty);

                        gridView1.SetRowCellValue(i, gridColPrice, dPrice);
                        gridView1.SetRowCellValue(i, gridColMoney, dSum);
                        gridView1.SetRowCellValue(i, gridColTaxRate, BaseFunction.ReturnDecimal(dtPrice.Rows[0]["iInvtaxRate"]));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(i, gridColPrice, DBNull.Value);
                        gridView1.SetRowCellValue(i, gridColMoney, DBNull.Value);
                        gridView1.SetRowCellValue(i, gridColTaxRate, DBNull.Value);
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void lookUpEditforeigncurrencyName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEditforeigncurrency.EditValue = lookUpEditforeigncurrencyName.EditValue;
            }
            catch { }
        }

        private void btnTxtVenCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                FrmVendorInfo frm = new FrmVendorInfo(btnTxtVenCode.Text.Trim());
                DialogResult d = frm.ShowDialog();
                if (d == DialogResult.OK)
                {
                    btnTxtVenCode.Text = frm.sVenCode;
                    lookUpEditcVenName.EditValue = frm.sVenCode;
                }
            }
            catch { }
        }

        private void btnTxtVenCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F2)
                {
                    btnTxtVenCode_ButtonClick(null, null);
                }
                if (e.KeyCode == Keys.Enter)
                {
                    lookUpEditcVenName.EditValue = btnTxtVenCode.Text.Trim();
                }
            }
            catch { }
        }
    }
}
