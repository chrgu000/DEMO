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

            sSQL = "select cInvCode ,cInvName ,cInvStd from Inventory order by cInvCode";
            dt = DbHelperSQL.ExecuteDataset(sConnString, CommandType.Text, sSQL).Tables[0];
            ItemLookUpEdit存货名称.DataSource = dt;
            ItemLookUpEdit规格.DataSource = dt;

            sSQL = "select cCusCode,cCusName from Customer";
            dt = DbHelperSQL.ExecuteDataset(sConnString, CommandType.Text, sSQL).Tables[0];
            ItemLookUpEdit客户.DataSource = dt;
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

                string sSQL = "select *,'01' as 仓库编码 from [Sheet1$]";
                DataTable dt = clsExcel.ExcelToDT(fName, sSQL, true);
                //DataColumn dc = new DataColumn();
                //dc.ColumnName = "仓库编码";
                //dc.DataType = System.Type.GetType("System.Boolean");
                //dt.Columns.Add(dc);

               
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
                    //sSQL = "select isnull(bflag_SA,0) as bflag from GL_mend where iYPeriod = '" + dateEdit1.DateTime.ToString("yyyyMM") + "'";
                    //DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    //if (dt == null || dt.Rows.Count == 0)
                    //{
                    //    throw new Exception("Access module state failure");
                    //}
                    //int i结账 = BaseFunction.ReturnInt(dt.Rows[0]["bflag"]);
                    //if (i结账 > 0)
                    //{
                    //    throw new Exception(dateEdit1.DateTime.ToString("yyyy-MM") + " have checked out");
                    //}

                    int iCouRow = gridView1.RowCount;

                    //获得单据号
                    sSQL = "select cNumber from VoucherHistory with (ROWLOCK) Where CardNumber='01' and cContent is NULL";
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

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

                        string s业务模式 = gridView1.GetRowCellValue(i, gridCol业务模式).ToString().Trim();
                        string s客户编码 = gridView1.GetRowCellValue(i, gridCol客户编码).ToString().Trim();
                        int i蓝字 = 1;

                        if (BaseFunction.ReturnDecimal(gridView1.GetRowCellDisplayText(i, gridCol出库数量)) < 0)
                        {
                            i蓝字 = -1;
                        }

                        string s单据导入判断 = s业务模式 + "@" + s客户编码 + "@" + i蓝字.ToString();

                        //判断本次是否已经导入
                        for (int j = 0; j < aList.Count; j++)
                        {
                            if (s单据导入判断 == aList[j].ToString().Trim())
                            {
                                bExists = true;
                                break;
                            }
                        }

                        if (bExists)
                            continue;

                        aList.Add(s单据导入判断);

                      
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
                        model.cSTCode = "01";
                        model.dDate = BaseFunction.ReturnDate(DateTime.Today.Year.ToString() + "-" + gridView1.GetRowCellValue(i, gridCol月份).ToString().Trim() + "-01");
                        model.cDepCode = "01";
                        model.SBVID = 0;

                        string s订单号 = gridView1.GetRowCellValue(i, gridCol订单号).ToString().Trim();
                        if (s订单号 != "" && s订单号 != "0")
                        {
                            model.cSOCode = s订单号;
                        }

                        if (gridView1.GetRowCellDisplayText(i, gridCol客户).ToString().Trim() == "")
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + " 客户不存在\n";
                            continue;
                        }
                        model.cCusCode = gridView1.GetRowCellValue(i,gridCol客户编码).ToString().Trim();

                        //model.cPayCode = "01";
                        //model.cShipAddress = dtSO.Rows[0]["cCusOAddress"].ToString().Trim();
                        model.cexch_name = "人民币";
                        model.iExchRate = 1;
                        model.bFirst = false;
                        if (i蓝字 > 0)
                        {
                            model.bReturnFlag = false;
                        }
                        else
                        {
                            model.bReturnFlag = true; 
                        }
                        model.bSettleAll = false;
                        model.iSale = 0;

                        if (gridView1.GetRowCellDisplayText(i, gridCol客户).ToString().Trim() == "")
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + " 客户不存在\n";
                            continue;
                        }
                        model.cCusName = gridView1.GetRowCellDisplayText(i,gridCol客户).ToString().Trim();
                        model.iVTid = 71;
                        model.cBusType = "普通销售";
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
                        //model.cinvoicecompany = dtSO.Rows[0]["cCusCode"].ToString().Trim();
                        model.cMaker = sUserName;
                        model.cDefine1 = gridView1.GetRowCellDisplayText(i, gridCol业务模式).ToString().Trim();
                        model.iTaxRate = 17;
                        TH.clsU8.DAL.DispatchList dal = new TH.clsU8.DAL.DispatchList();
                        sSQL = dal.Add(model);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        int iRowDis = 0;
                        for (int j = 0; j < gridView1.RowCount; j++)
                        {
                            string s业务模式2 = gridView1.GetRowCellValue(j, gridCol业务模式).ToString().Trim();
                            string s客户编码2 = gridView1.GetRowCellValue(j, gridCol客户编码).ToString().Trim(); 
                            int i蓝字2 = 1;
                            if (BaseFunction.ReturnDecimal(gridView1.GetRowCellDisplayText(j, gridCol出库数量)) < 0)
                            {
                                i蓝字2 = -1;
                            }

                            string s单据导入判断2 = s业务模式2 + "@" + s客户编码2 + "@" + i蓝字2;
                            if (s单据导入判断2 != s单据导入判断)
                            {
                                continue;
                            }

                            TH.clsU8.Model.DispatchLists models = new TH.clsU8.Model.DispatchLists();

                            lIDDetails += 1;
                            models.AutoID = lIDDetails - 1000000000;
                            models.DLID = model.DLID;
                            models.iCorID = 0;
                            if (gridView1.GetRowCellDisplayText(j, gridCol仓库).ToString().Trim() == "")
                            {
                                sErr = sErr + "行 " + (j + 1).ToString() + " 仓库编码不存在\n";
                                continue;
                            }
                            models.cWhCode = gridView1.GetRowCellValue(j, gridCol仓库编码).ToString().Trim();

                            if (gridView1.GetRowCellDisplayText(j, gridCol存货名称).ToString().Trim() == "")
                            {
                                sErr = sErr + "行" + (j + 1).ToString() + " 存货不存在\n";
                                continue;
                            }
                            models.cInvCode = gridView1.GetRowCellValue(j, gridCol存货编码).ToString().Trim();
                            models.iQuantity = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(j, gridCol出库数量));
                            if (models.iQuantity == 0)
                            {
                                sErr = sErr + "行 " + (j + 1).ToString() + " 数量不正确\n";
                                continue;
                            }
                            //models.iNum = 
                            models.iQuotedPrice = 0;

                            decimal d含税单价 = BaseFunction.ReturnDecimal(gridView1.GetRowCellDisplayText(j, gridCol含税单价));
                            if (d含税单价 <= 0)
                            {
                                sErr = sErr + "行 " + (j + 1).ToString() + " 单价不正确\n";
                                continue;
                            }

                            models.iTaxRate = 17;
                            models.iTaxUnitPrice = d含税单价;
                            models.iMoney = BaseFunction.ReturnDecimal(models.iTaxUnitPrice * models.iQuantity / (1 + models.iTaxRate / 100));
                            models.iSum = BaseFunction.ReturnDecimal(models.iTaxUnitPrice * models.iQuantity);
                            models.iUnitPrice = BaseFunction.ReturnDecimal(models.iMoney / models.iQuantity);
                            models.iTax = models.iSum - models.iMoney;

                            models.iNatUnitPrice = models.iUnitPrice;
                            models.iNatMoney = models.iMoney;
                            models.iNatTax = models.iTax;
                            models.iNatSum = models.iSum;

                            models.iNatDisCount = 0;
                            models.iSettleNum = 0;
                            models.iSettleQuantity = 0;
                            models.bSettleAll = false;
                            models.iTB = 0;
                            models.TBQuantity = 0;
                            //models.iSOsID = BaseFunction.ReturnLong(dtSOs.Rows[0]["iSOsID"]);
                            models.iDLsID = lIDDetails;
                            models.KL = 100;
                            models.KL2 = 100;
                            models.cInvName = gridView1.GetRowCellDisplayText(j, gridCol存货名称).ToString().Trim();
                            models.fOutQuantity = 0;
                            models.fOutNum = 0;
                            models.fSaleCost = 0;
                            models.fSalePrice = 0;
                            models.bIsSTQc = false;
                            models.fEnSettleQuan = 0;
                            models.fEnSettleSum = 0;
                            models.bGsp = false;
                            //models.cSoCode = s销售订单号;
                            //models.iMassDate = bas
                            models.bQANeedCheck = false;
                            models.bQAChecking = false;
                            models.bQAChecked = false;
                            models.fsumsignnum = 0;
                            models.fsumsignnum = 0;
                            models.bcosting = true;
                            //models.cordercode = s销售订单号;
                            //models.iorderrowno = iRow;
                            models.fcusminprice = 0;

                            iRowDis += 1;
                            models.irowno = iRowDis;
                            models.iExpiratDateCalcu = 2;
                            models.bneedsign = false;
                            models.frlossqty = 0;
                            TH.clsU8.DAL.DispatchLists dals = new TH.clsU8.DAL.DispatchLists();
                            sSQL = dals.Add(models);
                            iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

//                            sSQL = @"
//UPDATE SO_SODetails SET iFHQuantity=a.iquantity,iFHNum=a.inum,iFHMoney=a.isum 
//from SO_SODetails inner join (
//        SELECT iSOsID,Sum(IsNull(iQuantity,0)) as iquantity,Sum(IsNull(iNum,0)) as inum,Sum(IsNull(iSum,0)) as isum 
//        FROM DispatchLists 
//        where isnull(isosid,0)<>0 
//        GROUP BY iSOsID
//    ) a on SO_SODetails.isosid=a.isosid
//where SO_SODetails.iSOsID = aaaaaa
//";
//                            sSQL = sSQL.Replace("aaaaaa", dtSOs.Rows[0]["iSOsID"].ToString().Trim());
//                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
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
                string s1 = gridView1.GetRowCellValue(e.RowHandle1, gridCol订单号).ToString().Trim();
                string s2 = gridView1.GetRowCellValue(e.RowHandle2, gridCol订单号).ToString().Trim();
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

    }
}
