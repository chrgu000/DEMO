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
    public partial class Frm发货单导入 : Form
    {
        string s服务器;
        string sSA;
        string sPwd;
        string s数据库;
        string s单据号;
        string sConnString;
        string sUserName;

        public Frm发货单导入()
        {
            InitializeComponent();
        }


        public Frm发货单导入(string s1, string s2, string s3, string s4, string s5, string s6)
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
            string sSQL = "select cWhCode,cWhName from WareHouse order by cWhCode";
            DataTable dt = DbHelperSQL.ExecuteDataset(sConnString, CommandType.Text, sSQL).Tables[0];
            ItemLookUpEditcWhCode.DataSource = dt;
            ItemLookUpEditcWhName.DataSource = dt;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel2010|*.xlsx|Excel2003|*.xls|所有文件|*.*";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                string fName = openFileDialog.FileName;

                ClsExcel clsExcel = ClsExcel.Instance();

                string sSQL = "select * from [Sheet1$]";
                DataTable dt = clsExcel.ExcelToDT(fName, sSQL, true);
                DataColumn dc = new DataColumn();
                dc.ColumnName = "choose";
                dc.DataType = System.Type.GetType("System.Boolean");
                dt.Columns.Add(dc);

                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    if (dt.Rows[i]["销售订单号"].ToString().Trim() == "" || BaseFunction.ReturnDecimal(dt.Rows[i]["数量"]) == 0)
                    {
                        dt.Rows.RemoveAt(i);
                    }
                }

                gridControl1.DataSource = dt;
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
                    sSQL = "select cNumber from VoucherHistory with (ROWLOCK) Where CardNumber='01' and cContent is NULL";
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
                    sSQL = sSQL.Replace("dddddd", s数据库.Substring(7, 3));
                    dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    lID = BaseFunction.ReturnLong(dt.Rows[0][0]) - 1;
                    lIDDetails = BaseFunction.ReturnLong(dt.Rows[0][1]) - iCouRow;

                    ArrayList aList = new ArrayList();

                    string sMsg = "";

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        bool bExists = false;

                        string s销售订单号 = gridView1.GetRowCellValue(i, gridCol销售订单号).ToString().Trim();

                        //判断本次是否已经导入
                        for (int j = 0; j < aList.Count; j++)
                        {
                            if (s销售订单号 == aList[j].ToString().Trim())
                            {
                                bExists = true;
                                break;
                            }
                        }

                        if (bExists)
                            continue;

                        aList.Add(s销售订单号);

                        sSQL = @"
select *
from SO_SOMain a inner join SO_SODetails b on a.ID = b.ID
    inner join Customer c on a.cCusCode = c.cCusCode
    inner join Inventory d on b.cInvCode = d.cInvCode
where a.cSOCode = 'aaaaaa'
order by b.AutoID
";
                        sSQL = sSQL.Replace("aaaaaa", s销售订单号);
                        DataTable dtSO = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtSO == null || dtSO.Rows.Count == 0)
                        {
                            sErr = sErr + "行 " + (i + 1).ToString() + " 销售订单不存在\n";
                            continue;
                        }
                        TH.clsU8.Model.DispatchList model = new TH.clsU8.Model.DispatchList();
                        lID += 1;
                        model.DLID = lID;


                        lCode += 1;
                        string sCode = lCode.ToString();
                        while (sCode.Length < 10)
                        {
                            sCode = "0" + sCode;
                        }
                        model.cDLCode = sCode;
                        model.cVouchType = "05";
                        model.cSTCode = dtSO.Rows[0]["cSTCode"].ToString().Trim();
                        model.dDate = dateEdit1.DateTime;
                        model.cDepCode = dtSO.Rows[0]["cDepCode"].ToString().Trim();
                        model.SBVID = 0;
                        model.cSOCode = s销售订单号;
                        model.cCusCode = dtSO.Rows[0]["cCusCode"].ToString().Trim();
                        model.cPayCode = dtSO.Rows[0]["cPayCode"].ToString().Trim();
                        model.cShipAddress = dtSO.Rows[0]["cCusOAddress"].ToString().Trim();
                        model.cexch_name = dtSO.Rows[0]["cexch_name"].ToString().Trim();
                        model.iExchRate = BaseFunction.ReturnDecimal(dtSO.Rows[0]["iExchRate"]);
                        model.bFirst = false;
                        model.bReturnFlag = false;
                        model.bSettleAll = false;
                        model.iSale = 0;
                        model.cCusName = dtSO.Rows[0]["cCusName"].ToString().Trim();
                        model.iVTid = 71;
                        model.cBusType = dtSO.Rows[0]["cBusType"].ToString().Trim();
                        model.bIAFirst = false;
                        model.bCredit = false;
                        //model.caddcode = 
                        model.iverifystate = 0;
                        model.iswfcontrolled = 0;
                        model.bARFirst = false;
                        model.dcreatesystime = DateTime.Now;
                        model.iflowid = 0;
                        model.bsigncreate = false;
                        model.bcashsale = false;
                        model.bmustbook = false;
                        model.bneedbill = true;
                        model.baccswitchflag = false;
                        model.bsaleoutcreatebill = false;
                        model.cinvoicecompany = dtSO.Rows[0]["cCusCode"].ToString().Trim();
                        model.cMaker = sUserName;
                        TH.clsU8.DAL.DispatchList dal = new TH.clsU8.DAL.DispatchList();
                        sSQL = dal.Add(model);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        int iRowDis = 0;
                        for (int j = 0; j < gridView1.RowCount; j++)
                        {
                            if (s销售订单号 != gridView1.GetRowCellValue(j, gridCol销售订单号).ToString().Trim())
                            {
                                continue;
                            }

                            int iRow = BaseFunction.ReturnInt(gridView1.GetRowCellValue(j, gridCol行号));
                            sSQL = @"
select *
from SO_SOMain a inner join SO_SODetails b on a.ID = b.ID
    inner join Customer c on a.cCusCode = c.cCusCode
    inner join Inventory d on b.cInvCode = d.cInvCode
where a.cSOCode = 'aaaaaa' and b.iRowNo = bbbbbb
order by b.AutoID
";
                            sSQL = sSQL.Replace("aaaaaa", s销售订单号);
                            sSQL = sSQL.Replace("bbbbbb", iRow.ToString());
                            DataTable dtSOs = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                            TH.clsU8.Model.DispatchLists models = new TH.clsU8.Model.DispatchLists();

                            lIDDetails += 1;
                            models.AutoID = lIDDetails - 1000000000;
                            models.DLID = model.DLID;
                            models.iCorID = 0;
                            if (gridView1.GetRowCellDisplayText(i, gridCol仓库编码).ToString().Trim() == "")
                            {
                                sErr = sErr + "行 " + (j + 1).ToString() + " 仓库编码不存在\n";
                                continue;
                            }
                            models.cWhCode = gridView1.GetRowCellValue(i, gridCol仓库编码).ToString().Trim();
                            models.cInvCode = dtSOs.Rows[0]["cInvCode"].ToString();
                            models.iQuantity = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol数量));
                            if (models.iQuantity == 0)
                            {
                                sErr = sErr + "行 " + (j + 1).ToString() + " 数量不正确\n";
                                continue;
                            }
                            //models.iNum = 
                            models.iQuotedPrice = 0;
                            models.iTaxUnitPrice = 0;
                            models.imoneysum = 0;
                            models.iTaxUnitPrice = 0;
                            models.iMoney = 0;
                            models.iTax = 0;
                            models.iSum = 0;
                            models.iNatUnitPrice = 0;
                            models.iNatMoney = 0;
                            models.iNatTax = 0;
                            models.iNatSum = 0;
                            models.iNatDisCount = 0;
                            models.iSettleNum = 0;
                            models.iSettleQuantity = 0;
                            models.bSettleAll = false;
                            models.iTB = 0;
                            models.TBQuantity = 0;
                            models.iSOsID = BaseFunction.ReturnLong(dtSOs.Rows[0]["iSOsID"]);
                            models.iDLsID = lIDDetails;
                            models.KL = 100;
                            models.KL2 = 100;
                            models.cInvName = dtSOs.Rows[0]["cInvName"].ToString().Trim();
                            models.iTaxRate = BaseFunction.ReturnDecimal(dtSOs.Rows[0]["iTaxRate"]);
                            models.fOutQuantity = 0;
                            models.fOutNum = 0;
                            models.fSaleCost = 0;
                            models.fSalePrice = 0;
                            models.bIsSTQc = false;
                            models.fEnSettleQuan = 0;
                            models.fEnSettleSum = 0;
                            models.bGsp = false;
                            models.cSoCode = s销售订单号;
                            //models.iMassDate = bas
                            models.bQANeedCheck = false;
                            models.bQAChecking = false;
                            models.bQAChecked = false;
                            models.fsumsignnum = 0;
                            models.fsumsignnum = 0;
                            models.bcosting = true;
                            models.cordercode = s销售订单号;
                            models.iorderrowno = iRow;
                            models.fcusminprice = 0;

                            iRowDis += 1;
                            models.irowno = iRowDis;
                            models.iExpiratDateCalcu = 2;
                            models.bneedsign = false;
                            models.frlossqty = 0;
                            models.bsaleprice = false;
                            models.bgift = false;
                            models.bmpforderclosed = false;
                            TH.clsU8.DAL.DispatchLists dals = new TH.clsU8.DAL.DispatchLists();
                            sSQL = dals.Add(models);
                            iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            sSQL = @"
UPDATE SO_SODetails SET iFHQuantity=a.iquantity,iFHNum=a.inum,iFHMoney=a.isum 
from SO_SODetails inner join (
        SELECT iSOsID,Sum(IsNull(iQuantity,0)) as iquantity,Sum(IsNull(iNum,0)) as inum,Sum(IsNull(iSum,0)) as isum 
        FROM DispatchLists 
        where isnull(isosid,0)<>0 
        GROUP BY iSOsID
    ) a on SO_SODetails.isosid=a.isosid
where SO_SODetails.iSOsID = aaaaaa
";
                            sSQL = sSQL.Replace("aaaaaa", dtSOs.Rows[0]["iSOsID"].ToString().Trim());
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
                    sSQL = "update UFSystem..UA_Identity set iFatherId = " + lID.ToString() + ",iChildId = " + lIDDetails + " where cAcc_Id = '" + s数据库.Substring(7, 3) + "' and cVouchType = 'DISPATCH'";
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = @"
if exists(select * from VoucherHistory where CardNumber = '01' and cContent is null)
	update VoucherHistory set cNumber = aaaaaa  where CardNumber = '01' and cContent is null
else
	insert into VoucherHistory(CardNumber,cContent,cContentRule,cSeed,cNumber,bEmpty)
	values('01',null,null,null,'aaaaaa',0)
";
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

        private void gridView1_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            try
            {
                string s1 = gridView1.GetRowCellValue(e.RowHandle1, gridCol销售订单号).ToString().Trim();
                string s2 = gridView1.GetRowCellValue(e.RowHandle2, gridCol销售订单号).ToString().Trim();
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
