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

                string sSheet = "Sheet1$";
                DataTable dtSheetNames = clsExcel.dtExcelSheetName(fName);

                for (int i = 0; i < dtSheetNames.Rows.Count; i++)
                {
                    if (dtSheetNames.Rows[i]["TABLE_NAME"].ToString().Trim() == "Sheet1$" || dtSheetNames.Rows[i]["TABLE_NAME"].ToString().Trim() == "Sheet$")
                    {
                        sSheet = dtSheetNames.Rows[i]["TABLE_NAME"].ToString().Trim();
                        break;
                    }
                }

                string sSQL = "select * from [" + sSheet + "]";
                DataTable dt = clsExcel.ExcelToDT(fName, sSQL, true);
                DataColumn dc = new DataColumn();
                dc.ColumnName = "choose";
                dc.DataType = System.Type.GetType("System.Boolean");
                dt.Columns.Add(dc);

                for (int i = dt.Rows.Count - 1;i>=0 ; i--)
                {
                    if (dt.Rows[i]["采购订单号"].ToString().Trim() == "" && dt.Rows[i]["供应商编号"].ToString().Trim() == "")
                    {
                        dt.Rows.RemoveAt(i);
                    }
                }

                sSQL = @"
select a.cexch_name,b.cexch_code ,a.nflat
from exch a inner join foreigncurrency b on a.cexch_name = b.cexch_name
where iYear = '111111' and iperiod = '222222'
";
                sSQL = sSQL.Replace("111111", dateEdit1.DateTime.ToString("yyyy"));
                sSQL = sSQL.Replace("222222", dateEdit1.DateTime.Month.ToString());
                DataTable dtExch = DbHelperSQL.ExecuteDataset(sConnString, CommandType.Text, sSQL).Tables[0];


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    #region 币种汇率

                    DataRow[] dr;
                    string s币种名称 = dt.Rows[i]["币种"].ToString().ToLower().Trim();
                    switch (s币种名称)
                    {
                        case "rmb":
                            s币种名称 = "人民币";
                            break;
                        case "cny":
                            s币种名称 = "人民币";
                            break;
                        case "¥":
                            s币种名称 = "人民币";
                            break;

                        case "$":
                            s币种名称 = "usd";
                            break;
                        case "usd":
                            s币种名称 = "usd";
                            break;
                        case "美元":
                            s币种名称 = "usd";
                            break;

                        case "￥":
                            s币种名称 = "jpy";
                            break;
                        case "jpy":
                            s币种名称 = "jpy";
                            break;
                        case "日元":
                            s币种名称 = "jpy";
                            break;

                        case "€":
                            s币种名称 = "eur";
                            break;
                        case "eur":
                            s币种名称 = "eur";
                            break;
                        case "欧元":
                            s币种名称 = "eur";
                            break;
                    }

                    switch (s币种名称)
                    {
                        case "人民币":
                            dt.Rows[i]["汇率"] = "1";
                            break;

                        case "usd":
                            dr = dtExch.Select("cexch_code = '" + s币种名称 + "' or cexch_name = '" + s币种名称 + "'");
                            if (dr.Length > 0)
                            {
                                dt.Rows[i]["汇率"] = dr[0]["nflat"].ToString().Trim();
                            }
                            break;

                        case "jpy":
                            dr = dtExch.Select("cexch_code = '" + s币种名称 + "' or cexch_name = '" + s币种名称 + "'");
                            if (dr.Length > 0)
                            {
                                dt.Rows[i]["汇率"] = dr[0]["nflat"].ToString().Trim();
                            }
                            break;

                        case "eur":
                            dr = dtExch.Select("cexch_code = '" + s币种名称 + "' or cexch_name = '" + s币种名称 + "'");
                            if (dr.Length > 0)
                            {
                                dt.Rows[i]["汇率"] = dr[0]["nflat"].ToString().Trim();
                            }
                            break;
                    }
                    #endregion

                    DateTime d发运日期 = BaseFunction.ReturnDate(dt.Rows[i]["发运日期"]);
                    if (d发运日期 > BaseFunction.ReturnDate("2000-01-01"))
                    {
                        dt.Rows[i]["发运日期"] = d发运日期.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        dt.Rows[i]["发运日期"] = DBNull.Value;
                    }

                    DateTime d计划到货日期 = BaseFunction.ReturnDate(dt.Rows[i]["计划到货日期"]);
                    if (d计划到货日期 > BaseFunction.ReturnDate("2000-01-01"))
                    {
                        dt.Rows[i]["计划到货日期"] = d计划到货日期.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        dt.Rows[i]["计划到货日期"] = DBNull.Value;
                    }

                    //string sVenCode = dt.Rows[i]["供应商编号"].ToString().Trim();
                    //string sInvCode = dt.Rows[i]["存货编码"].ToString().Trim();
                    //decimal dQty = BaseFunction.ReturnDecimal(dt.Rows[i]["数量"]);
                    //string sCurr = dt.Rows[i]["币种"].ToString().Trim();
                    //string sDate = dt.Rows[i]["单据日期"].ToString().Trim();
                    //decimal d2 = 0;
                    //decimal d = dPrice(sVenCode, sInvCode, dQty, sCurr, sDate, out d2);
                    //dt.Rows[i]["原币含税单价"] = d.ToString();
                }

                gridControl1.DataSource = dt;
                gridColchoose.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                gridColchoose.Width = 40;

                chkAll.Checked = false;
                chkAll.Checked = true;
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
                        string s单据号 = gridView1.GetRowCellValue(i, gridCol采购订单号).ToString().Trim();

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
                        model.cVenCode = gridView1.GetRowCellDisplayText(i, gridCol供应商编号).ToString().Trim();
                        if (model.cVenCode == "")
                        {
                            sErr = sErr + "行 " + (i + 1).ToString() + " 供应商编码不存在\n";
                            continue;
                        }
                        model.cDepCode = gridView1.GetRowCellValue(i, gridCol采购部门).ToString().Trim();
                        if (model.cDepCode == "")
                        {
                            sErr = sErr + "行 " + (i + 1).ToString() + " 采购部门不存在\n";
                            continue;
                        }
                        model.cPTCode = gridView1.GetRowCellValue(i, gridCol采购类型).ToString().Trim();
                        if (model.cPTCode == "")
                        {
                            sErr = sErr + "行 " + (i + 1).ToString() + " 采购类型不存在\n";
                            continue;
                        }
                        //model.cSCCode = 
                        model.cexch_name = gridView1.GetRowCellValue(i, gridCol币种).ToString().Trim();
                        model.nflat = BaseFunction.ReturnDecimal(gridView1.GetRowCellDisplayText(i, gridCol汇率), 1);
                        model.iTaxRate = BaseFunction.ReturnDecimal(gridView1.GetRowCellDisplayText(i, gridCol税率));
                        model.cState = 0;
                        model.cMaker = sUserName;
                        lID += 1;
                        model.POID = lID;
                        model.iVTid = 131397;
                        model.cBusType = gridView1.GetRowCellDisplayText(i, gridCol业务类型).ToString().Trim();
                        if (model.cBusType != "普通采购" && model.cBusType != "直运采购")
                        {
                            sErr = sErr + "行 " + (i + 1).ToString() + " 业务类型错误\n";
                            continue;
                        }

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
                            string s单据号2 = gridView1.GetRowCellDisplayText(j, gridCol采购订单号).ToString().Trim();
                            if (s单据号 != s单据号2)
                                continue;

                            iRow += 1;
                            lIDDetails += 1;
                            TH.clsU8.Model.PO_Podetails models = new TH.clsU8.Model.PO_Podetails();
                            models.ID = lIDDetails;
                            //models.cPOID
                            models.cInvCode = gridView1.GetRowCellDisplayText(j, gridCol存货编码).ToString().Trim();
                            if (models.cInvCode == "")
                            {
                                sErr = sErr + "行 " + (j + 1).ToString() + " 存货编码不存在\n";
                                continue;
                            }

                            models.iQuantity = BaseFunction.ReturnDecimal(gridView1.GetRowCellDisplayText(j, gridCol数量));
                            if (models.iQuantity <= 0)
                            {
                                sErr = sErr + "行 " + (j + 1).ToString() + " 数量错误\n";
                                continue;
                            }
                            models.iPerTaxRate = BaseFunction.ReturnDecimal(gridView1.GetRowCellDisplayText(j, gridCol税率), 0);
                            models.iTaxPrice = BaseFunction.ReturnDecimal(gridView1.GetRowCellDisplayText(j, gridCol原币含税单价), 4);

                            if (models.iPerTaxRate == 0 || models.iTaxPrice == 0)
                            {
                                sSQL = @"
select b.*
from PU_PriceJustMain a inner join PU_PriceJustDetail b on a.id = b.id
where b.cvencode = 'aaaaaa' and dstartdate < 'bbbbbb' and isnull(denddate ,'2099-12-31') > 'bbbbbb'
    and b.cInvCode = 'cccccc'
order by fminquantity desc,dstartdate desc
";
                                sSQL = sSQL.Replace("aaaaaa", model.cVenCode);
                                sSQL = sSQL.Replace("bbbbbb", model.dPODate.ToString("yyyy-MM-dd"));
                                sSQL = sSQL.Replace("cccccc", models.cInvCode);
                                DataTable dtPrice = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                if (dtPrice != null && dtPrice.Rows.Count > 0)
                                {
                                    models.iPerTaxRate = BaseFunction.ReturnDecimal(dtPrice.Rows[0]["iTaxRate"]);
                                    models.iTaxPrice = BaseFunction.ReturnDecimal(dtPrice.Rows[0]["iTaxUnitPrice"]);
                                }
                            }
                            models.iUnitPrice = BaseFunction.ReturnDecimal(models.iTaxPrice / (1 + models.iPerTaxRate / 100), 4);
                            models.iMoney = BaseFunction.ReturnDecimal(models.iUnitPrice * models.iQuantity, 2);
                            models.iSum = BaseFunction.ReturnDecimal(models.iTaxPrice * models.iQuantity, 2);
                            models.iTax = models.iSum - models.iMoney;

                            models.iNatUnitPrice = BaseFunction.ReturnDecimal(models.iUnitPrice * model.nflat,4);
                            models.iNatMoney = BaseFunction.ReturnDecimal(models.iNatUnitPrice * models.iQuantity, 2);
                            models.iNatSum = BaseFunction.ReturnDecimal(BaseFunction.ReturnDecimal(models.iNatUnitPrice * models.iQuantity) * models.iPerTaxRate,2);
                            models.iNatTax = models.iNatSum - models.iNatMoney;
                            if (gridView1.GetRowCellDisplayText(j, gridCol计划到货日期).ToString().Trim() != "")
                            {
                                models.dArriveDate = BaseFunction.ReturnDate(gridView1.GetRowCellDisplayText(j, gridCol计划到货日期));
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
                    sSQL = "update UFSystem..UA_Identity set iFatherId = " + lID.ToString() + ",iChildId = " + lIDDetails + " where cAcc_Id = '" + s数据库.Substring(7, 3) + "' and cVouchType = 'Somain'";
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

        private string sJapToChina(object o)
        {
            string s = o.ToString().Trim();

            string sReturn = "";
            switch (s)
            {
                //case "choose": sReturn = "选择"; break;
                case "得意先コード": sReturn = "客户编号"; break;
                case "得意先名称": sReturn = "客户名称"; break;
                case "顧客オーダー№": sReturn = "客户定单号码"; break;
                case "受注№": sReturn = "接受定单号"; break;
                case "受注日": sReturn = "接受订单日期"; break;
                case "製品コード": sReturn = "成品编码"; break;
                case "仕様(分析コード２)": sReturn = "样品（分析编码2）"; break;
                case "仕様２(分析コード３)": sReturn = "样品（分析编码3）"; break;
                case "製品備考": sReturn = "成品备注"; break;
                case "製品備考拡張": sReturn = "成品备注追加"; break;
                case "クラス": sReturn = "类别"; break;
                case "納期": sReturn = "交货期"; break;
                case "通貨": sReturn = "币种"; break;
                case "受注金額合計": sReturn = "接受订单金额合计"; break;
                case "受注金額合計(税抜き)": sReturn = "接受订单金额合计（不含税）"; break;
                case "原価合計": sReturn = "成本合计"; break;
                case "限界利益": sReturn = "边际贡献"; break;
                case "": sReturn = ""; break;
                case "受注数量": sReturn = "接受订单数量"; break;
                case "出荷済数量": sReturn = "发货完成数量"; break;
                case "受注残": sReturn = "接受订单后尚未发货数量"; break;
                case "CNY": sReturn = "RMB"; break;

                //case "USD": sReturn = "$"; break;
                //case "JPY": sReturn = "￥"; break;
                //case "ECB": sReturn = "€"; break;         

                default:
                    sReturn = s; break;
            }

            return sReturn;
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
                    gridView1.SetRowCellValue(i, gridColchoose, chkAll.Checked);
                }
            }
            catch { }
        }

        private void gridView1_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            try
            {
                string s1 = gridView1.GetRowCellValue(e.RowHandle1, gridCol采购订单号).ToString().Trim();
                string s2 = gridView1.GetRowCellValue(e.RowHandle2, gridCol采购订单号).ToString().Trim();
                if (s1 == s2)
                {
                    e.Merge = true;
                    e.Handled = true;
                }
                else
                {
                    e.Merge = false;
                    e.Handled = true;
                }
            }
            catch { }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                bool bChk = BaseFunction.ReturnBool(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColchoose));
                string s采购订单号 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridCol采购订单号).ToString().Trim();

                for (int i = 0; i<gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridCol采购订单号).ToString().Trim() == s采购订单号)
                    {
                        gridView1.SetRowCellValue(i, gridColchoose, !bChk);
                    }
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
