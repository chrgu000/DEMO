using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;



namespace clsU8
{
    public partial class Frm采购订单导入 : Form
    {
        string s服务器;
        string sSA;
        string sPwd;
        string s数据库;
        string s单据号;
        string sConnString;
        string sUserName;
        int iTaxRate_All = 13;

        public Frm采购订单导入()
        {
            InitializeComponent();
        }


        public Frm采购订单导入(string s1, string s2, string s3, string s4, string s5, string s6)
        {
            InitializeComponent();

            s服务器 = s1;
            sSA = s2;
            sPwd = s3;
            s数据库 = s4;
            s单据号 = s5;
            sUserName = s6;

            sConnString = "server = " + s服务器 + ";uid=" + sSA + ";pwd=" + sPwd + ";database=" + s数据库 + ";timeout = 200";


            try
            {
                string sSQL = @"
select cValue  from AccInformation
Where cSysID=N'PU' and cid=N'166'
";
                DataTable dt = DbHelperSQL.ExecuteDataset(sConnString, CommandType.Text, sSQL).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    iTaxRate_All = BaseFunction.ReturnInt(dt.Rows[0]["cValue"]);
                }

            }
            catch { }
        }
    
        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                dateEdit1.DateTime = DateTime.Today;

                SetLookUp();
            }
            catch(Exception ee) 
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void SetLookUp()
        {
            string sSQL = "select cInvCode,cInvName ,cInvStd from Inventory order by cInvCode";
            DataTable dt = DbHelperSQL.ExecuteDataset(sConnString, CommandType.Text, sSQL).Tables[0];
            ItemLookUpEditcInvCode.DataSource = dt;
            ItemLookUpEditcInvName.DataSource = dt;
            ItemLookUpEditcInvStd.DataSource = dt;

            sSQL = "select cDepCode,cDepName from Department order by cDepCode";
            dt = DbHelperSQL.ExecuteDataset(sConnString, CommandType.Text, sSQL).Tables[0];
            ItemLookUpEditcDepCode.DataSource = dt;
            ItemLookUpEditcDepName.DataSource = dt;

            sSQL = "select cVenCode,cVenName from Vendor order by cVenCode";
            dt = DbHelperSQL.ExecuteDataset(sConnString, CommandType.Text, sSQL).Tables[0];
            ItemLookUpEditcVenCode.DataSource = dt;
            ItemLookUpEditcVentName.DataSource = dt;



            sSQL = "select cPTCode,cPTName from PurchaseType order by cPTCode";
            dt = DbHelperSQL.ExecuteDataset(sConnString, CommandType.Text, sSQL).Tables[0];
            ItemLookUpEditcPTCode.DataSource = dt;
            ItemLookUpEditcPTName.DataSource = dt;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel2003|*.xls|Excel2010|*.xlsx|所有文件|*.*";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                string fName = openFileDialog.FileName;

                ClsExcel clsExcel = ClsExcel.Instance();

                string sSQL = "select * from [PUR_Import_PO$A4:R65536] ";
                DataTable dt = clsExcel.ExcelToDT(fName, sSQL, false);
                DataColumn dc = new DataColumn();
                dc.ColumnName = "choose";
                dc.DataType = System.Type.GetType("System.Boolean");
                dt.Columns.Add(dc);

                for (int i = dt.Rows.Count - 1;i>=0 ; i--)
                {
                    if (dt.Rows[i][6].ToString().Trim() == "")
                    {
                        dt.Rows.RemoveAt(i);
                    }
                }

                gridControl1.DataSource = dt;
                gridView1.Columns["choose"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                gridView1.Columns["choose"].Width = 40;

                chkAll.Checked = false;
                chkAll.Checked = true;

                gridView1.BestFitColumns();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
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
                SqlConnection conn = new SqlConnection(sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                string sSQL = "";
                try
                {
                    sSQL = "select isnull(bflag_PU,0) as bflag from GL_mend where iYPeriod = '" + dateEdit1.DateTime.ToString("yyyyMM") + "'";
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

                    ////获得单据号
                    //sSQL = "select cNumber from VoucherHistory with (ROWLOCK) Where CardNumber='17' and cContent is NULL";
                    //dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    //long lCode = 0;
                    //if (dt != null && dt.Rows.Count > 0)
                    //{
                    //    lCode = BaseFunction.ReturnLong(dt.Rows[0]["cNumber"]);
                    //}
                    //else
                    //{
                    //    lCode = 0;
                    //}

                    long lID = -1;
                    long lIDDetails = -1;
                    sSQL = @"
declare @p5 int
set @p5=aaaaaa
declare @p6 int
set @p6=bbbbbb
exec sp_GetId N'00',N'dddddd',N'Pomain',cccccc,@p5 output,@p6 output,default
select @p5, @p6
";
                    sSQL = sSQL.Replace("aaaaaa", lID.ToString());
                    sSQL = sSQL.Replace("bbbbbb", lIDDetails.ToString());
                    sSQL = sSQL.Replace("cccccc", iCouRow.ToString());
                    sSQL = sSQL.Replace("dddddd", s数据库.Substring(7, 3));
                    dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    lID = BaseFunction.ReturnLong(dt.Rows[0][0]) - 1;
                    lIDDetails = BaseFunction.ReturnLong(dt.Rows[0][1]) - iCouRow;

                    ArrayList aList = new ArrayList();

                    string sMsg = "";

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        bool bChoose = BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridView1.Columns["choose"]));
                        if (!bChoose)
                            continue;

                        string s单据号 = gridView1.GetRowCellValue(i, gridView1.Columns["F1"]).ToString().Trim();

                        bool bExists = false; ;
                        for (int j = 0; j < aList.Count; j++)
                        {
                            if (s单据号 == aList[j].ToString().Trim())
                            {
                                bExists = true;
                                break;
                            }
                        }
                        if (bExists)
                        {
                            continue;
                        }
                        aList.Add(s单据号);

                        sSQL = @"
select * from PO_POMain where cPOID = 'aaaaaa'
";
                        sSQL = sSQL.Replace("aaaaaa", s单据号);
                        dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            sErr = sErr + "行 " + (i + 1).ToString() + " 单据号 " + s单据号 + " 已经存在\n";
                            continue;
                        }

                        TH.clsU8.Model.PO_Pomain model = new TH.clsU8.Model.PO_Pomain();
                        model.cPOID = s单据号;
                        model.dPODate = dateEdit1.DateTime;
                        model.cVenCode = gridView1.GetRowCellValue(i, gridView1.Columns["F2"]).ToString().Trim();
                        sSQL = "select * from Vendor where cVenCode = '" + model.cVenCode + "'";
                        DataTable dtVen = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtVen == null || dtVen.Rows.Count == 0)
                        {
                            sErr = sErr + "行 " + (i + 1).ToString() + "供应商不存在\n";
                            continue;
                        }

                        if (model.cVenCode == "")
                        {
                            sErr = sErr + "行 " + (i + 1).ToString() + " 供应商编码不存在\n";
                            continue;
                        }

                        sSQL = "select * from Person where cPersonCode = '" + sUserName + "' or cPersonName = '" + sUserName + "'";
                        DataTable dtPer = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtPer == null || dtPer.Rows.Count == 0)
                        {
                            sErr = sErr + "行 " + (i + 1).ToString() + " 用户归属部门不存在\n";
                            continue;
                        }

                        model.cDepCode = dtPer.Rows[0]["cDepCode"].ToString().Trim();
                        if (model.cDepCode == "")
                        {
                            sErr = sErr + "行 " + (i + 1).ToString() + " 用户归属部门不存在\n";
                            continue;
                        }

                        //model.cSCCode = 
                        sSQL = "select * from foreigncurrency where cexch_code = 'aaaaaa' or cexch_name = 'aaaaaa'";
                        sSQL = sSQL.Replace("aaaaaa", gridView1.GetRowCellValue(i, gridView1.Columns["F10"]).ToString().Trim());
                        DataTable dtForeigncurrency = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtForeigncurrency == null || dtForeigncurrency.Rows.Count == 0)
                        {
                            sErr = sErr + "行 " + (i + 1).ToString() + " 币种不存在 err\n";
                            continue;
                        }
                        model.cexch_name = dtForeigncurrency.Rows[0]["cexch_name"].ToString().Trim();
                        if (model.cexch_name == "人民币" | model.cexch_name == "RMB" || model.cexch_name == "CNY")
                        {
                            model.cPTCode = "01";
                            model.nflat = 1;
                            model.iTaxRate = iTaxRate_All;
                        }
                        else
                        {
                            model.cPTCode = "02";
                            sSQL = "select * from exch where iYear = aaaaaa and iPeriod = bbbbbb and cexch_name = 'cccccc'";
                            sSQL = sSQL.Replace("aaaaaa", dateEdit1.DateTime.ToString("yyyy"));
                            sSQL = sSQL.Replace("bbbbbb", dateEdit1.DateTime.Month.ToString());
                            sSQL = sSQL.Replace("cccccc", model.cexch_name);
                            DataTable dtExch = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dtExch == null || dtExch.Rows.Count == 0)
                            {
                                sErr = sErr + "行 " + (i + 1).ToString() + " 请设置汇率 err\n";
                                continue;
                            }
                            model.nflat = BaseFunction.ReturnDecimal(dtExch.Rows[0]["nflat"]);
                            model.iTaxRate = 0;
                        }
                        model.cState = 0;
                        model.cMaker = sUserName;
                        lID += 1;
                        model.POID = lID;
                        model.iVTid = 8173;
                        model.cBusType = "普通采购";

                        model.iDiscountTaxType = 0;
                        model.IsWfControlled = false;
                        model.cmaketime = DateTime.Now;
                        model.iPrintCount = 0;


                        TH.clsU8.DAL.PO_Pomain dal = new TH.clsU8.DAL.PO_Pomain();
                        sSQL = dal.Add(model);
                        iCount +=  DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                        long iRow = 0;
                        for (int j = 0; j < gridView1.RowCount; j++)
                        {
                            bool bChoose2 = BaseFunction.ReturnBool(gridView1.GetRowCellValue(j, gridView1.Columns["choose"]));
                            if (!bChoose2)
                                continue;

                            string s单据号2 = gridView1.GetRowCellDisplayText(j, gridView1.Columns["F1"]).ToString().Trim();
                            if (s单据号 != s单据号2)
                                continue;

                            iRow += 1;
                            lIDDetails += 1;
                            TH.clsU8.Model.PO_Podetails models = new TH.clsU8.Model.PO_Podetails();
                            models.ID = lIDDetails;
                            //models.cPOID
                            models.cInvCode = gridView1.GetRowCellDisplayText(j, gridView1.Columns["F6"]).ToString().Trim();
                            if (models.cInvCode == "")
                            {
                                sErr = sErr + "行 " + (j + 1).ToString() + " 存货编码不存在\n";
                                continue;
                            }
                            sSQL = "select * from Inventory where cInvCode = '" + models.cInvCode + "'";
                            DataTable dtInv = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dtInv == null || dtInv.Rows.Count == 0)
                            {
                                sErr = sErr + "行 " + (j + 1).ToString() + " 存货编码不存在\n";
                                continue;
                            }

                            models.iQuantity = BaseFunction.ReturnDecimal(gridView1.GetRowCellDisplayText(j, gridView1.Columns["F9"]));

                            models.iPerTaxRate = model.iTaxRate;
                            models.iTaxPrice = BaseFunction.ReturnDecimal(gridView1.GetRowCellDisplayText(j, gridView1.Columns["F11"]));
                            models.iUnitPrice = BaseFunction.ReturnDecimal(models.iTaxPrice / (1 + models.iPerTaxRate / 100), 4);
                            models.iMoney = BaseFunction.ReturnDecimal(models.iUnitPrice * models.iQuantity, 2);
                            models.iSum = BaseFunction.ReturnDecimal(models.iTaxPrice * models.iQuantity, 2);
                            models.iTax = models.iSum - models.iMoney;

                            models.iNatUnitPrice = BaseFunction.ReturnDecimal(models.iUnitPrice * model.nflat,4);
                            models.iNatMoney = BaseFunction.ReturnDecimal(models.iNatUnitPrice * models.iQuantity, 2);
                            models.iNatSum = BaseFunction.ReturnDecimal(BaseFunction.ReturnDecimal(models.iTaxPrice * model.nflat ,6) * models.iQuantity , 2);
                            models.iNatTax = models.iNatSum - models.iNatMoney;
                            if (gridView1.GetRowCellDisplayText(j, gridView1.Columns["F8"]).ToString().Trim() != "")
                            {
                                DateTime dtmTemp = DateTime.Today;
                                string s = gridView1.GetRowCellDisplayText(j, gridView1.Columns["F8"]).ToString().Trim();
                                if (s.Length == 8)
                                {
                                    dtmTemp = BaseFunction.ReturnDate(s.Substring(0,4) + "-" + s.Substring(4,2) + "-" + s.Substring(6));
                                }
                                if (dtmTemp > BaseFunction.ReturnDate("2015-01-01"))
                                {
                                    models.dArriveDate = dtmTemp;
                                    models.cDefine36 = dtmTemp;
                                }
                                else
                                {
                                    models.dArriveDate =DateTime.Today;
                                }
                            }
                            models.bGsp = 0;
                            models.POID = model.POID;
                            models.bTaxCost = false;
                            models.SoType = 0;
                            models.iordertype = 0;
                            models.irowno = iRow;
                            models.bgift = 0;

                            TH.clsU8.DAL.PO_Podetails dals = new TH.clsU8.DAL.PO_Podetails();
                            sSQL = dals.Add(models);
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                    }

                    if (sErr != "")
                    {
                        throw new Exception(sErr);
                    }

                    if (sMsg.Trim() != "")
                    {
                        MsgBox msg = new MsgBox();
                        msg.richTextBox1.Text = "是否继续导入：\n" + sMsg;
                        msg.btn确定.Text = "是";
                        msg.btnCancel.Text = "否";
                        msg.Text = "提示";
                        DialogResult d = msg.ShowDialog();
                        if (d != DialogResult.Yes)
                        { 
                            throw new Exception("请设置价格");
                        }
                    }

                    if (lID > 1000000000)
                    {
                        lID = lID - 1000000000;
                    }
                    if (lIDDetails > 1000000000)
                    {
                        lIDDetails = lIDDetails - 1000000000;
                    }
                    sSQL = "update UFSystem..UA_Identity set iFatherId = " + lID.ToString() + ",iChildId = " + lIDDetails + " where cAcc_Id = '" + s数据库.Substring(7, 3) + "' and cVouchType = 'Pomain'";
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
                MsgBox msgbox = new MsgBox();
                msgbox.richTextBox1.Text = ee.Message;
                msgbox.ShowDialog();
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

        private decimal dPrice(string sCusCode, string sInvCode, decimal dQty, string sCurr, string sDate, out decimal iSalecost)
        {
            decimal d = 0;
            string sSQL = @"
declare @p17 float
set @p17=0
declare @p18 float
set @p18=0
declare @p19 float
set @p19=0
declare @p20 float
set @p20=0
declare @p21 float
set @p21=0
declare @p22 nvarchar(200)
set @p22=NULL
declare @p23 bit
set @p23=1
exec SA_FetchPrice N'aaaaaa',N'bbbbbb',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'','eeeeee',N'dddddd',cccccc,0,@p17 output,@p18 output,@p19 output,@p20 output,@p21 output,@p22 output,@p23 output,N''
select @p17, @p18, @p19, @p20, @p21, @p22, @p23

";
            sSQL = sSQL.Replace("aaaaaa", sCusCode);
            sSQL = sSQL.Replace("bbbbbb", sInvCode);
            sSQL = sSQL.Replace("cccccc", dQty.ToString());
            sSQL = sSQL.Replace("dddddd", sCurr);
            sSQL = sSQL.Replace("eeeeee", sDate);

            DataTable dt = DbHelperSQL.ExecuteDataset(sConnString, CommandType.Text, sSQL).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                d = BaseFunction.ReturnDecimal(dt.Rows[0][0], 4);
            }

            iSalecost = BaseFunction.ReturnDecimal(dt.Rows[0][0], 4);

            return d;
        }
    }
}
