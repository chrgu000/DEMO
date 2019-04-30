﻿using System;
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
    public partial class Frm采购入库单导入 : Form
    {
        string s服务器;
        string sSA;
        string sPwd;
        string s数据库;
        string s单据号;
        string sConnString;
        string sUserName;

        public Frm采购入库单导入()
        {
            InitializeComponent();
        }


        public Frm采购入库单导入(string s1, string s2, string s3, string s4, string s5, string s6)
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


            sSQL = "SELECT cWhCode ,cWhName FROM dbo.Warehouse ORDER BY cWhCode";
            dt = DbHelperSQL.ExecuteDataset(sConnString, CommandType.Text, sSQL).Tables[0];
            ItemLookUpEditWarehouse.DataSource = dt;
            ItemLookUpEditWareHouseName.DataSource = dt;

            //sSQL = "SELECT * FROM dbo.Rd_Style WHERE bRdFlag = 1 AND bRdEnd = 1 ORDER BY cRdCode";
            //dt = DbHelperSQL.ExecuteDataset(sConnString, CommandType.Text, sSQL).Tables[0];

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
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    if (dt.Rows[i]["存货编码"].ToString().Trim() == "")
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
                    sSQL = "select isnull(bflag_ST,0) as bflag from GL_mend where iYPeriod = '" + dateEdit1.DateTime.ToString("yyyyMM") + "'";
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

                    long lID = -1;
                    long lIDDetails = -1;
                    sSQL = @"
declare @p5 int
set @p5=aaaaaa
declare @p6 int
set @p6=bbbbbb
exec sp_GetId N'00',N'dddddd',N'rd',cccccc,@p5 output,@p6 output,default
select @p5, @p6
";
                    sSQL = sSQL.Replace("aaaaaa", lID.ToString());
                    sSQL = sSQL.Replace("bbbbbb", lIDDetails.ToString());
                    sSQL = sSQL.Replace("cccccc", iCouRow.ToString());
                    sSQL = sSQL.Replace("dddddd", s数据库.Substring(7, 3));
                    dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    long lCode = 0;
                    sSQL = "select * from voucherhistory where CardNumber = '24'";
                    DataTable dtCode = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtCode == null || dtCode.Rows.Count == 0)
                    {
                        lCode = 0;
                    }
                    else
                    {
                        lCode = BaseFunction.ReturnLong(dtCode.Rows[0]["cNumber"]);
                    }
                  

                    lID = BaseFunction.ReturnLong(dt.Rows[0][0]) - 1;
                    lIDDetails = BaseFunction.ReturnLong(dt.Rows[0][1]) - iCouRow;

                    string sMsg = "";
                    ArrayList aList = new ArrayList();

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        string s采购订单号 =  gridView1.GetRowCellValue(i, gridCol采购订单号).ToString().Trim();
                        string s仓库 = gridView1.GetRowCellValue(i, gridCol仓库编码).ToString().Trim();

                        bool bExist = false;
                        for (int j = 0; j < aList.Count; j++)
                        {
                            if (aList[j].ToString().Trim() == s采购订单号 + "," + s仓库)
                            {
                                bExist = true;
                                break;
                            }
                        }
                        if (bExist)
                            continue;

                        aList.Add(s采购订单号 + "," + s仓库);

                        sSQL = @"
select * from po_pomain where cPOID = 'aaaaaa'
";
                        sSQL = sSQL.Replace("aaaaaa", s采购订单号);
                        DataTable dtPO = DbHelperSQL.ExecuteDataset(tran,CommandType.Text,sSQL).Tables[0];

                        TH.clsU8.Model.RdRecord01 model = new TH.clsU8.Model.RdRecord01();
                        lID += 1;

                        model.ID = lID;
                        model.bRdFlag = 1;
                        model.cVouchType = "01";
                        model.cBusType = dtPO.Rows[0]["cBusType"].ToString().Trim();
                        model.cSource = "采购订单";
                        model.cWhCode = s仓库;
                        model.dDate = dateEdit1.DateTime;

                        lCode += 1;
                        string sCode = lCode.ToString();
                        while (sCode.Length < 10)
                        {
                            sCode = "0" + sCode;
                        }
                        model.cCode = sCode;
                        model.cRdCode = gridView1.GetRowCellValue(i, gridCol入库类别).ToString().Trim();
                        model.cDepCode = gridView1.GetRowCellValue(i, gridCol部门).ToString().Trim();
                        //model.cPersonCode = 
                        model.cPTCode = dtPO.Rows[0]["cPTCode"].ToString().Trim();
                        model.cVenCode = dtPO.Rows[0]["cVenCode"].ToString().Trim();
                        model.cOrderCode = dtPO.Rows[0]["cPOID"].ToString().Trim();
                        model.cMaker = sUserName;
                        model.VT_ID = 27;
                        model.bIsSTQc = false;
                        model.ipurorderid = BaseFunction.ReturnLong(dtPO.Rows[0]["poid"]);
                        model.iTaxRate = BaseFunction.ReturnDecimal(dtPO.Rows[0]["iTaxRate"]);
                        model.iExchRate = BaseFunction.ReturnDecimal(dtPO.Rows[0]["nflat"]);
                        model.cExch_Name = dtPO.Rows[0]["cExch_Name"].ToString().Trim();
                        model.bOMFirst = false;
                        model.bFromPreYear = false;
                        model.bIsComplement = 0;
                        model.bIsComplement = 0;
                        model.iDiscountTaxType = 0;
                        model.ireturncount = 0;
                        model.iverifystate = 0;
                        model.iswfcontrolled = 0;
                        model.dnmaketime = DateTime.Now;
                        model.bredvouch = 0;
                        model.bCredit = 0;
                        model.iPrintCount = 0;

                        TH.clsU8.DAL.RdRecord01 dal = new TH.clsU8.DAL.RdRecord01();
                        sSQL = dal.Add(model);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        int iRowNO = 0;
                        for (int j = 0; j < gridView1.RowCount; j++)
                        {
                            string s采购订单号2 = gridView1.GetRowCellValue(j, gridCol采购订单号).ToString().Trim();
                            string s仓库2 = gridView1.GetRowCellValue(j, gridCol仓库编码).ToString().Trim();
                            if (s采购订单号2 != s采购订单号 || s仓库2 != s仓库)
                            {
                                continue;
                            }


                            sSQL = @"
select * 
from po_pomain a inner join PO_POdetails b on a.poid = b.poid
    inner join Inventory c on b.cInvCode = c.cInvCode
where a.cPOID = 'aaaaaa' and b.ivouchrowno = bbbbbb
";
                            sSQL = sSQL.Replace("aaaaaa", s采购订单号);
                            sSQL = sSQL.Replace("bbbbbb", gridView1.GetRowCellValue(j, gridCol行号).ToString().Trim());
                            DataTable dtPOs = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                            lIDDetails += 1;
                            TH.clsU8.Model.rdrecords01 models = new TH.clsU8.Model.rdrecords01();
                            models.AutoID = lIDDetails;
                            models.ID = model.ID;
                            models.cInvCode = gridView1.GetRowCellValue(j, gridCol存货编码).ToString().Trim();
                            models.iQuantity = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(j, gridCol数量));
                            if (BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(j, gridCol件数)) > 0)
                            {
                                models.iNum = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(j, gridCol件数));
                            }
                            iRowNO += 1;
                            models.iUnitCost = BaseFunction.ReturnDecimal(dtPOs.Rows[0]["iTaxPrice"]);
                            models.iPrice = BaseFunction.ReturnDecimal(models.iUnitCost * models.iQuantity, 4);
                            models.iAPrice = models.iPrice;
                            models.iFlag = 0;
                            models.dVDate = BaseFunction.ReturnDate(gridView1.GetRowCellValue(j, gridCol生效日期)).AddDays(BaseFunction.ReturnInt(dtPOs.Rows[0]["iMassDate"]));
                            models.iPOsID = BaseFunction.ReturnLong(dtPOs.Rows[0]["ID"]);
                            models.fACost = BaseFunction.ReturnDecimal(dtPOs.Rows[0]["iTaxPrice"]);
                            models.iNQuantity = models.iQuantity;
                            models.iNNum = models.iNum;
                            models.cAssUnit = dtPOs.Rows[0]["cAssComUnitCode"].ToString().Trim();
                            models.dMadeDate = BaseFunction.ReturnDate(gridView1.GetRowCellValue(j, gridCol生效日期));
                            models.iMassDate = BaseFunction.ReturnInt(dtPOs.Rows[0]["iMassDate"]);
                            models.chVencode = model.cVenCode;
                            models.iOriTaxCost = BaseFunction.ReturnDecimal(dtPOs.Rows[0]["iTaxPrice"]);
                            models.iOriCost = BaseFunction.ReturnDecimal(dtPOs.Rows[0]["iTaxPrice"]);
                            models.iOriMoney = BaseFunction.ReturnDecimal(models.iOriTaxCost * models.iQuantity, 4);
                            models.iTaxRate = model.iTaxRate;
                            models.iTaxPrice = 0;
                            models.iSum = BaseFunction.ReturnDecimal(models.iOriTaxCost * models.iQuantity, 4);
                            models.bTaxCost = true;
                            models.cPOID = dtPOs.Rows[0]["cPOID"].ToString().Trim();
                            models.cMassUnit = BaseFunction.ReturnInt(dtPOs.Rows[0]["cMassUnit"]);
                            models.iMatSettleState = 0;
                            models.iBillSettleCount = 0;
                            models.bLPUseFree = false;
                            models.iOriTaxCost = 0;
                            models.bCosting = true;
                            models.iExpiratDateCalcu = 2;
                            models.cExpirationdate = BaseFunction.ReturnDate(gridView1.GetRowCellValue(j, gridCol生效日期)).AddDays(BaseFunction.ReturnInt(dtPOs.Rows[0]["iMassDate"])).ToString("yyyy-MM-dd");
                            models.dExpirationdate = BaseFunction.ReturnDate(gridView1.GetRowCellValue(j, gridCol生效日期)).AddDays(BaseFunction.ReturnInt(dtPOs.Rows[0]["iMassDate"]));
                            models.iordertype = 0;
                            models.isotype = 0;
                            models.irowno = iRowNO;
                            models.bgift = 0;

                            TH.clsU8.DAL.rdrecords01 dals = new TH.clsU8.DAL.rdrecords01();
                            sSQL = dals.Add(models);
                            iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            sSQL = @"
update rdrecords01 set cVouchCode = null,iArrsId = null ,dVDate = null ,dMadeDate = null ,iMassDate = null ,iOMoDID = null 
	,bchecked = null,bRelated = null ,bgsp = null ,bVMIUsed = null,iIMOSID = null,iSumBillQuantity = null,iVMISettleQuantity = null,iVMISettleNum = null
	,iIMBSID = null
where autoid = aaaaaa
";
                            sSQL = sSQL.Replace("aaaaaa", models.AutoID.ToString());
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            sSQL = @"
 UPDATE T1 SET  T1.iReceivedQTY=CONVERT(DECIMAL(38,3),ISNULL(T1.iReceivedQTY,0))+CONVERT(DECIMAL(38,3),ISNULL(T2.iQuantity,0))
	, T1.iReceivedNum=CONVERT(DECIMAL(38,2),ISNULL(T1.iReceivedNum,0))+CONVERT(DECIMAL(38,2),ISNULL(T2.iNum,0))
	, T1.iReceivedMoney=CONVERT(DECIMAL(38,7),ISNULL(T1.iReceivedMoney,0))+CONVERT(DECIMAL(38,7),ISNULL(T2.imoney,0)) 
FROM Po_Podetails T1 INNER JOIN rdrecords01 AS T2 ON T2.iPOsID = T1.ID
where t2.AutoID = aaaaaa
";
                            sSQL = sSQL.Replace("aaaaaa", models.AutoID.ToString());
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);



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
            insert into CurrentStock(cWhCode,cInvCode,iQuantity,itemid, cFree1, cFree2, cFree3, cFree4, cFree5, cFree6, cFree7, cFree8, cFree9, cFree10,cBatch,iSoDid,dVDate,dMdate)
            values('@cWhCode','@cInvCode', @iQuantity,@itemid, @cFree1, @cFree2, @cFree3, @cFree4, @cFree5, @cFree6, @cFree7, @cFree8, @cFree9, @cFree10,@cBatch,'',@dVDate,@dMdate) 
    end
";
                            sSQL = sSQL.Replace("@cInvCode", models.cInvCode);
                            sSQL = sSQL.Replace("@cWhCode", model.cWhCode);
                            sSQL = sSQL.Replace("@iQuantity", (models.iQuantity).ToString());
                            sSQL = sSQL.Replace("@iNum", (models.iNum).ToString());
                            sSQL = sSQL.Replace("@cFree10", models.cFree10 == null ? "''" : "'" + models.cFree10 + "'");
                            sSQL = sSQL.Replace("@cFree1", models.cFree1 == null ? "''" : "'" + models.cFree1 + "'");
                            sSQL = sSQL.Replace("@cFree2", models.cFree2 == null ? "''" : "'" + models.cFree2 + "'");
                            sSQL = sSQL.Replace("@cFree3", models.cFree3 == null ? "''" : "'" + models.cFree3 + "'");
                            sSQL = sSQL.Replace("@cFree4", models.cFree4 == null ? "''" : "'" + models.cFree4 + "'");
                            sSQL = sSQL.Replace("@cFree5", models.cFree5 == null ? "''" : "'" + models.cFree5 + "'");
                            sSQL = sSQL.Replace("@cFree6", models.cFree6 == null ? "''" : "'" + models.cFree6 + "'");
                            sSQL = sSQL.Replace("@cFree7", models.cFree7 == null ? "''" : "'" + models.cFree7 + "'");
                            sSQL = sSQL.Replace("@cFree8", models.cFree8 == null ? "''" : "'" + models.cFree8 + "'");
                            sSQL = sSQL.Replace("@cFree9", models.cFree9 == null ? "''" : "'" + models.cFree9 + "'");
                            sSQL = sSQL.Replace("@cBatch", models.cBatch == null ? "''" : "'" + models.cBatch + "'");
                            sSQL = sSQL.Replace("@dVDate", models.dVDate == null ? "''" : "'" + models.dVDate + "'");
                            sSQL = sSQL.Replace("@dMdate", models.dMadeDate == null ? "''" : "'" + models.dMadeDate + "'");
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }

                        sSQL = @"
exec ST_SaveForStock N'01',N'aaaaaa',1,0 ,1
";
                        sSQL = sSQL.Replace("aaaaaa", model.ID.ToString());
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        sSQL = @"
exec ST_SaveForTrackStock N'01',N'aaaaaa', 0 ,1
";
                        sSQL = sSQL.Replace("aaaaaa", model.ID.ToString());
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        sSQL = @"
exec IA_SP_WriteUnAccountVouchForST 'aaaaaa',N'01'
";
                        sSQL = sSQL.Replace("aaaaaa", model.ID.ToString());
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
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
                    sSQL = "update UFSystem..UA_Identity set iFatherId = " + lID.ToString() + ",iChildId = " + lIDDetails + " where cAcc_Id = '" + s数据库.Substring(7, 3) + "' and cVouchType = 'rd'";
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = @"
if exists(select * from VoucherHistory where CardNumber = '24' and cContent is null)
	update VoucherHistory set cNumber = aaaaaa  where CardNumber = '24' and cContent is null
else
	insert into VoucherHistory(CardNumber,cContent,cContentRule,cSeed,cNumber,bEmpty)
	values('24',null,null,null,'aaaaaa',0)
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
                string s1 = gridView1.GetRowCellValue(e.RowHandle1, gridCol仓库编码).ToString().Trim();
                string s2 = gridView1.GetRowCellValue(e.RowHandle2, gridCol仓库编码).ToString().Trim();
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
