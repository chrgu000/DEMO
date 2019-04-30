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
    public partial class 发货单导入 : UserControl
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


        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                dateEdit1.DateTime = DateTime.Today;

                DbHelperSQL.connectionString = Conn;
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }


        public 发货单导入()
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


        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridView1.Columns["选择"], chkAll.Checked);
                }
            }
            catch { }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel2010|*.xlsx|所有文件|*.*";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                string fName = openFileDialog.FileName;

                ClsExcel clsExcel = ClsExcel.Instance();

                string sSQL = "select * from [发货单$] ";
                DataTable dt = clsExcel.ExcelToDT(fName, sSQL, true);
                DataColumn dc = new DataColumn();
                dc.ColumnName = "选择";
                dc.DataType = System.Type.GetType("System.Boolean");
                dt.Columns.Add(dc);

                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    if (dt.Rows[i]["存货编码"].ToString().Trim() == "")
                    {
                        dt.Rows.RemoveAt(i);
                    }
                }

                gridControl1.DataSource = dt;
                gridView1.Columns["选择"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                gridView1.Columns["选择"].Width = 40;

                chkAll.Checked = false;
                chkAll.Checked = true;

                gridView1.BestFitColumns();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnImprot_Click(object sender, EventArgs e)
        {

            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                string sErr = "";
                int iCount = 0;
                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                string sSQL = "";
                try
                {
                    sSQL = "select isnull(bflag_SA,0) as bflag from GL_mend where iYPeriod = '" + dateEdit1.DateTime.ToString("yyyyMM") + "'";
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        throw new Exception("Access module state failure");
                    }
                    int i结账 = BaseFunction.ReturnInt(dt.Rows[0]["bflag"]);
                    if (i结账 > 0)
                    {
                        throw new Exception(dateEdit1.DateTime.ToString("yyyy-MM") + " have checked out");
                    }

                    int iCouRow = gridView1.RowCount;

                    //获得单据号
                    sSQL = "select max(cNumber) as cNumber from VoucherHistory with (ROWLOCK) where CardNumber = '01'";
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



                    long lID = -1;
                    long lIDDetails = -1;
                    sSQL = @"
declare @p5 int
set @p5=aaaaaa
declare @p6 int
set @p6=bbbbbb
exec sp_GetId N'00',N'dddddd',N'DISPATCH',cccccc,@p5 output,@p6 output,default
select @p5, @p6
";
                    sSQL = sSQL.Replace("aaaaaa", lID.ToString());
                    sSQL = sSQL.Replace("bbbbbb", lIDDetails.ToString());
                    sSQL = sSQL.Replace("cccccc", iCouRow.ToString());
                    sSQL = sSQL.Replace("dddddd", sAccID);
                    dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    lID = BaseFunction.ReturnLong(dt.Rows[0][0]) - 1;
                    lIDDetails = BaseFunction.ReturnLong(dt.Rows[0][1]) - iCouRow;

                    sSQL = "select * from Warehouse ";
                    DataTable dtWh = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    sSQL = "select * from Inventory where isnull(bSale ,0) = 1";
                    DataTable dtInv = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    ArrayList aList = new ArrayList();
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        bool bCho = BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridCol选择));
                        if (!bCho)
                            continue;


                        bool bExist = false;
                        string sSoCode = gridView1.GetRowCellValue(i, gridCol销售订单号).ToString().Trim();
                        for (int j = 0; j < aList.Count; j++)
                        {
                            if (aList[j].ToString() == sSoCode)
                            {
                                bExist = true;
                                break;
                            }
                        }

                        aList.Add(sSoCode);
                        if (bExist)
                        {
                            break;
                        }

                        lCode += 1;
                        string sCode = lCode.ToString();
                        while (sCode.Length < 10)
                        {
                            sCode = "0" + sCode;
                        }
                        sSQL = @"
select * 
from SO_SOMain a inner join SO_SODetails b on a.ID = b.ID
    inner join Customer c on a.cCusCode = c.cCusCode
where a.cSOCode = 'aaaaaa'
order by b.iRowNo
";
                        sSQL = sSQL.Replace("aaaaaa", sSoCode);
                        DataTable dtSo = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtSo == null || dtSo.Rows.Count == 0)
                        {
                            sErr = sErr + "销售订单" + sSoCode + "不存在\n";
                            continue;
                        }

                        Model.DispatchList mod = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.DispatchList();

                        lID += 1;
                        mod.DLID = lID;
                        mod.cDLCode = sCode;
                        mod.cVouchType = "05";
                        mod.cSTCode = "01";
                        mod.dDate = dateEdit1.DateTime;
                        mod.cDepCode = "01";
                        mod.SBVID = 0;
                        mod.cSOCode = gridView1.GetRowCellValue(iCount, gridCol销售订单号).ToString().Trim();
                        mod.cCusCode = dtSo.Rows[0]["cCusCode"].ToString().Trim();
                        mod.cShipAddress = dtSo.Rows[0]["cCusOAddress"].ToString().Trim();
                        mod.cexch_name = dtSo.Rows[0]["cexch_name"].ToString().Trim();
                        mod.iExchRate = BaseFunction.ReturnDecimal(dtSo.Rows[0]["iExchRate"]);
                        mod.iTaxRate = BaseFunction.ReturnDecimal(dtSo.Rows[0]["iExchRate"]);
                        mod.bFirst = false;
                        mod.bReturnFlag = false;
                        mod.bSettleAll = false;
                        mod.cMaker = sUserID;
                        mod.iSale = 0;
                        mod.cCusName = dtSo.Rows[0]["cCusName"].ToString().Trim();
                        mod.iVTid = 71;
                        mod.cBusType = "普通销售";
                        mod.bIAFirst = false;
                        mod.bCredit = false;
                        mod.caddcode = dtSo.Rows[0]["caddcode"].ToString().Trim();
                        mod.iverifystate = 0;
                        mod.iswfcontrolled = 0;
                        mod.bARFirst = false;
                        mod.ccusperson = dtSo.Rows[0]["ccusperson"].ToString().Trim();
                        mod.iflowid = 0;
                        mod.bsigncreate = false;
                        mod.bcashsale = false;
                        mod.bmustbook = false;
                        mod.bneedbill = true;
                        mod.baccswitchflag = false;
                        mod.ccuspersoncode = dtSo.Rows[0]["ccuspersoncode"].ToString().Trim();
                        mod.bsaleoutcreatebill = false;
                        mod.cinvoicecompany = dtSo.Rows[0]["cinvoicecompany"].ToString().Trim();
                        mod.bNotToGoldTax = 0;

                        DAL.DispatchList dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.DispatchList();
                        sSQL = dal.Add(mod);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        int iRowNO = 0;
                        for (int j = i; j < gridView1.RowCount; j++)
                        {
                            string sSoCode2 = gridView1.GetRowCellValue(j, gridCol销售订单号).ToString().Trim();
                            if (sSoCode != sSoCode2)
                                continue;


                            bool bChoose = BaseFunction.ReturnBool(gridView1.GetRowCellValue(j, gridCol选择));
                            if (!bChoose)
                                continue;

                            lIDDetails += 1;

                            Model.DispatchLists mods = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.DispatchLists();
                            mods.AutoID = lIDDetails;
                            mods.DLID = mod.DLID;
                            mods.iCorID = 0;

                            string sWhCode = gridView1.GetRowCellValue(j, gridCol仓库).ToString().Trim();
                            DataRow[] drWh = dtWh.Select("cWhCode = '" + sWhCode + "'");
                            if (drWh.Length == 0)
                            {
                                sErr = sErr + "仓库" + sWhCode + "错误\n";
                                break;
                            }
                            mods.cWhCode = sWhCode;

                            string sInvCode = gridView1.GetRowCellValue(j, gridCol存货编码).ToString().Trim();
                            DataRow[] drInv = dtInv.Select("cInvCode = '" + sInvCode + "'");
                            if (drInv.Length == 0)
                            {
                                sErr = sErr + "存货" + sWhCode + "错误\n";
                                break;
                            }
                            mods.cInvCode = sInvCode;

                            DataRow[] drSO = dtSo.Select("cInvCode = '" + sInvCode + "'");
                            if (drSO.Length == 0)
                            {
                                sErr = sErr + "订单" + sSoCode2 + "不存在存货" + sInvCode + "\n";
                                break;
                            }

                            decimal dQty = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(j, gridCol数量));
                            if (dQty <= 0)
                            {
                                sErr = sErr + "存货" + sInvCode + "数量错误\n";
                                break;
                            }
                            mods.iQuantity = dQty;

                            decimal dSOQty = BaseFunction.ReturnDecimal(drSO[0]["iQuantity"]);
                            decimal dSONum = BaseFunction.ReturnDecimal(drSO[0]["iNum"]);
                            if (dSONum != 0)
                            {
                                mods.iNum = BaseFunction.ReturnDecimal(mods.iQuantity * (dSONum / dSOQty), 6);
                            }
                            mods.iQuotedPrice = 0;
                            mods.iUnitPrice = BaseFunction.ReturnDecimal(drSO[0]["iUnitPrice"]);
                            mods.iTaxUnitPrice = BaseFunction.ReturnDecimal(drSO[0]["iUnitPrice"]);
                            mods.iMoney = BaseFunction.ReturnDecimal(mods.iUnitPrice * mods.iQuantity, 2);
                            mods.iSum = BaseFunction.ReturnDecimal(mods.iTaxUnitPrice * mods.iQuantity, 2);
                            mods.iTax = mods.iSum - mods.iMoney;

                            mods.iDisCount = 0;
                            mods.iNatUnitPrice = BaseFunction.ReturnDecimal(drSO[0]["iNatUnitPrice"]);
                            mods.iNatMoney = BaseFunction.ReturnDecimal(mods.iNatUnitPrice * mods.iQuantity, 2);
                            mods.iNatSum = BaseFunction.ReturnDecimal(mods.iTaxUnitPrice * mods.iQuantity * mod.iExchRate, 2);
                            mods.iNatTax = mods.iNatSum - mods.iNatMoney;
                            mods.iNatDisCount = 0;
                            mods.iSettleNum = 0;
                            mods.iSettleQuantity = 0;
                            mods.bSettleAll = false;
                            mods.iTB = 0;
                            mods.TBQuantity = 0;
                            mods.TBNum = 0;
                            mods.iSOsID = BaseFunction.ReturnLong(dtSo.Rows[0]["iSOsID"]);
                            mods.iDLsID = lIDDetails;
                            mods.KL = 100;
                            mods.KL2 = 100;
                            mods.cInvName = drInv[0]["cInvName"].ToString().Trim();
                            mods.iTaxRate = BaseFunction.ReturnDecimal(dtSo.Rows[0]["iTaxRate"]);
                            mods.fOutQuantity = 0;
                            mods.fOutNum = 0;
                            mods.fSaleCost = 0;
                            mods.fSalePrice = 0;
                            mods.fEnSettleQuan = 0;
                            mods.fEnSettleSum = 0;
                            mods.cSoCode = dtSo.Rows[0]["cSOCode"].ToString().Trim();
                            mods.cMassUnit = BaseFunction.ReturnLong(drInv[0]["cMassUnit"]);
                            mods.bQANeedCheck = false;
                            mods.bQAUrgency = false;
                            mods.bQAChecked = false;
                            mods.fsumsignnum = 0;
                            mods.fsumsignnum = 0;
                            mods.bcosting = true;
                            mods.cordercode = dtSo.Rows[0]["cSOCode"].ToString().Trim();
                            mods.iorderrowno = BaseFunction.ReturnLong(dtSo.Rows[0]["iRowNo"]);
                            mods.fcusminprice = 0;
                            iRowNO += 1;
                            mods.irowno = iRowNO;
                            mods.frlossqty = 0;
                            mods.bIAcreatebill = false;

                            string sBatch =  gridView1.GetRowCellValue(j, gridCol批号).ToString().Trim();
                            if (BaseFunction.ReturnInt(drInv[0]["bInvBatch"]) > 0)
                            {
                                if (sBatch == "")
                                {
                                    sErr = sErr + "存货" + mods.cInvCode + "批次管理\n";
                                    continue;
                                }
                                mods.cBatch = sBatch;
                            }

                            //判断不可超订单
                            decimal dSOFHQty = BaseFunction.ReturnDecimal(drSO[0]["iFHQuantity"]);
                            if (dSOFHQty + mods.iQuantity > dSOQty)
                            {
                                sErr = sErr + "存货" + mods.cInvCode + "超订单发货\n";
                                    continue;
                            }

                            sSQL = @"
select * from CurrentStock 
where cWhCode = 'cccccc' and cInvCode = 'dddddd' and isnull(cBatch,'') = 'eeeeee'
";
                            sSQL = sSQL.Replace("cccccc", mods.cWhCode);
                            sSQL = sSQL.Replace("dddddd", mods.cInvCode);
                            sSQL = sSQL.Replace("eeeeee", mods.cBatch);
                            DataTable dtCurrQty = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            decimal dCurrQty = BaseFunction.ReturnDecimal(dtCurrQty.Rows[0]["iQuantity"]);
                            if (dCurrQty < mods.iQuantity)
                            {
                                sErr = sErr + "存货" + mods.cInvCode + "现存量不足\n";
                                continue;
                            }

                            //判断不可超现存量


                            DAL.DispatchLists dals = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.DispatchLists();
                            sSQL = dals.Add(mods);
                            iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            sSQL = @"
update CurrentStock set fOutQuantity = isnull(fOutQuantity,0) + aaaaaa,
	fOutNum = isnull(fOutNum,0) + bbbbbb 
where cWhCode = 'cccccc' and cInvCode = 'dddddd' and isnull(cBatch,'') = 'eeeeee'
";
                            sSQL = sSQL.Replace("aaaaaa", mods.iQuantity.ToString());
                            sSQL = sSQL.Replace("bbbbbb", mods.iNum.ToString());
                            sSQL = sSQL.Replace("cccccc", mods.cWhCode);
                            sSQL = sSQL.Replace("dddddd", mods.cInvCode);
                            sSQL = sSQL.Replace("eeeeee", mods.cBatch);
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }

                        sSQL = @"
UPDATE SO_SODetails SET iFHQuantity=IsNull(iFHQuantity,0)+a.iquantity,iFHNum=IsNull(iFHNum,0)+a.inum,iFHMoney=IsNull(iFHMoney,0)+a.isum 
from SO_SODetails sos inner join 
	(
		SELECT iSOsID,Sum(IsNull(iQuantity,0)) as iquantity,Sum(IsNull(iNum,0)) as inum,Sum(IsNull(iSum,0)) as isum 
		FROM DispatchLists where isnull(isosid,0)<>0 GROUP BY iSOsID
	) a on sos.isosid=a.isosid
	inner join SO_SOMain so on so.id = sos.id
where so.csocode = 'aaaaaa'
";
                        sSQL = sSQL.Replace("aaaaaa", sSoCode);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }


                    if (sErr != "")
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
                    sSQL = "update UFSystem..UA_Identity set iFatherId = " + lID.ToString() + ",iChildId = " + lIDDetails + " where cAcc_Id = '" + sAccID + "' and cVouchType = 'Pomain'";
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                    sSQL = "update VoucherHistory set cNumber = aaaaaa where CardNumber = '01'";
                    sSQL = sSQL.Replace("aaaaaa", lCode.ToString());
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    if (iCount > 0)
                    {
                        tran.Commit();

                        MessageBox.Show("OK\n");
                        gridControl1.DataSource = null;
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
                FrmMsgBox msgbox = new FrmMsgBox();
                msgbox.richTextBox1.Text = ee.Message;
                msgbox.ShowDialog();
            }

        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
     
        }

    }
}
