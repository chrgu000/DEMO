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
    public partial class RDInPu : UserControl
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

        DataTable dtHead = new DataTable();
        DataTable dtDetails = new DataTable();

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                DbHelperSQL.connectionString = Conn;

                GetLookUp();
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        public RDInPu()
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

        private void GetLookUp()
        {
            string sSQL = @"
select cWhCode,cWhName from WareHouse order by cWhCode
            ";
            DataTable dt = DbHelperSQL.Query(sSQL);
            lookUpEdit仓库.Properties.DataSource = dt;

            sSQL = @"
select cDepCode,cDepName from Department order by cDepCode
            ";
            dt = DbHelperSQL.Query(sSQL);
            lookUpEdit入库类别.Properties.DataSource = dt;
            
            sSQL = @"
select  cRdCode,cRdName from Rd_Style where bRdEnd = 1 and bRdFlag = 1 order by cRdCode
            ";
            dt = DbHelperSQL.Query(sSQL);
            lookUpEdit入库类别.Properties.DataSource = dt;
            int iRd = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string sRdName ="!!!!" + dt.Rows[i]["cRdName"].ToString().Trim();
                if (sRdName.IndexOf("采购入库") > 0 || sRdName.IndexOf("采购入库") > 0)
                {
                    iRd = i;
                    break;
                }
            }
            lookUpEdit入库类别.EditValue = dt.Rows[iRd]["cRdCode"].ToString().Trim();


            sSQL = @"
select cComunitCode,cComUnitName from ComputationUnit order by cComunitCode
            ";
            dt = DbHelperSQL.Query(sSQL);
            ItemLookUpEdit计量单位.DataSource = dt;
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
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                if (txt单据号.Text.Trim() == "")
                {
                    txt单据号.Focus();
                    throw new Exception("单据号不能为空");
                }

                if (lookUpEdit仓库.EditValue == null || lookUpEdit仓库.EditValue.ToString().Trim() == "")
                {
                    lookUpEdit仓库.Focus();
                    throw new Exception("仓库不能为空");
                }

                if (lookUpEdit入库类别.EditValue == null || lookUpEdit入库类别.EditValue.ToString().Trim() == "")
                {
                    lookUpEdit入库类别.Focus();
                    throw new Exception("入库类别不能为空");
                }
                
                string sErr = "";
                int iCou = 0;
                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sSQL = @"
SELECT * FROM GL_mend where iYPeriod = '111111' 
";
                    sSQL = sSQL.Replace("111111", dtm.DateTime.ToString("yyyyMM"));
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (BaseFunction.ReturnBool(dt.Rows[0]["bflag_ST"]))
                    {
                        throw new Exception("该月库存模块已经结账");
                    }

                    sSQL = @"
select getdate()
";
                    DateTime dNow = BaseFunction.ReturnDate(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);

                    sSQL = @"
select cCode from rdrecord01 where cCode = '111111'
";
                    sSQL = sSQL.Replace("111111", txt单据号.Text.Trim());
                    dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        txt单据号.Focus();
                        throw new Exception("单据号已经存在");
                    }

                    sSQL = @"
declare @p5 int
set @p5=1002300362
declare @p6 int
set @p6=1001610690
exec sp_GetId N'',N'111111',N'rd',222222,@p5 output,@p6 output,default
select @p5, @p6
";
                    sSQL = sSQL.Replace("111111", sAccID.ToString());
                    sSQL = sSQL.Replace("222222", gridView1.RowCount.ToString());
                    dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    long iID = BaseFunction.ReturnLong(dt.Rows[0][0]);
                    long iIDDetails = BaseFunction.ReturnLong(dt.Rows[0][1]);
                    iIDDetails = iIDDetails - gridView1.RowCount;

                    Model.rdrecord01 model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.rdrecord01();
                    model.ID = iID;
                    model.bRdFlag = 1;
                    model.cVouchType = "01";
                    model.cBusType = "普通采购";
                    model.cSource = "采购到货单";
                    model.cPTCode = "02";
                    model.cVenCode = txtcVenCode.Text.Trim();
                    model.cWhCode = lookUpEdit仓库.EditValue.ToString().Trim();
                    string cWhCode = lookUpEdit仓库.EditValue.ToString().Trim();
                    model.dDate = dtm.DateTime;
                    model.cCode = txt单据号.Text.Trim();
                    model.cRdCode = lookUpEdit入库类别.EditValue.ToString().Trim();
                    model.cDepCode = dtHead.Rows[0]["cDepCode"].ToString().Trim();
                    model.cPersonCode = dtHead.Rows[0]["cPersonCode"].ToString().Trim();
                    model.dARVDate = dtArrDate.DateTime;
                    model.cARVCode = dtHead.Rows[0]["ccode"].ToString().Trim();
                    model.cOrderCode = dtDetails.Rows[0]["cOrderCode"].ToString().Trim();
                    model.cMemo = txt备注.Text.Trim();
                    model.cMaker = sUserName;
                    model.bpufirst = false;
                    model.biafirst = false;
                    model.VT_ID = 30772;
                    model.bIsSTQc = false;
                    model.bOMFirst = false;
                    model.bFromPreYear = false;
                    //model.bIsLsQuery = false;
                    model.iDiscountTaxType = 0;
                    model.ireturncount = 0;
                    model.iverifystate = 0;
                    model.iswfcontrolled = 0;
                    model.dnmaketime = dNow;
                    model.bredvouch = 0;
                    model.bCredit = 0;
                    model.csysbarcode = "||st01|" + txt单据号.Text;
                    model.iExchRate = BaseFunction.ReturnDecimal(dtHead.Rows[0]["iExchRate"]);
                    model.iTaxRate = BaseFunction.ReturnDecimal(dtHead.Rows[0]["iTaxRate"]);
                    model.cExch_Name = dtHead.Rows[0]["cExch_Name"].ToString().Trim();
                    model.ipurarriveid = BaseFunction.ReturnLong(dtHead.Rows[0]["ID"]);
                    model.cDefine1 = dtHead.Rows[0]["cDefine1"].ToString().Trim();
                    model.cDefine2 = dtHead.Rows[0]["cDefine2"].ToString().Trim();
                    model.cDefine3 = dtHead.Rows[0]["cDefine3"].ToString().Trim();
                    model.cDefine4 = BaseFunction.ReturnDate(dtHead.Rows[0]["cDefine4"].ToString().Trim());
                    model.cDefine5 = BaseFunction.ReturnInt(dtHead.Rows[0]["cDefine5"].ToString().Trim());
                    model.cDefine6 = BaseFunction.ReturnDate(dtHead.Rows[0]["cDefine6"].ToString().Trim());
                    model.cDefine7 = BaseFunction.ReturnDecimal(dtHead.Rows[0]["cDefine7"].ToString().Trim());
                    model.cDefine8 = dtHead.Rows[0]["cDefine8"].ToString().Trim();
                    model.cDefine9 = dtHead.Rows[0]["cDefine9"].ToString().Trim();
                    model.cDefine10 = dtHead.Rows[0]["cDefine10"].ToString().Trim();
                    DAL.rdrecord01 dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.rdrecord01();
                    sSQL = dal.Add(model);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    int iRow = 0;
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        long l出库单表体ID = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColAutoID));
                        decimal d数量 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol数量), 6);
                        decimal d件数 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol件数), 6);
                        if (d数量 <= 0)
                        {
                            continue;
                        }

                        string dMadeDate = gridView1.GetRowCellValue(i, gridCol生产日期).ToString().Trim();
                        if (dMadeDate == "")
                        {
                            throw new Exception("生产日期不可为空");
                        }
                        string cBatch = gridView1.GetRowCellValue(i, gridCol批号).ToString().Trim();
                        if (cBatch == "")
                        {
                            throw new Exception("批号不可为空");
                        }
                        
                        iRow+=1;
                        DataRow[] dr = dtDetails.Select("autoid = " + l出库单表体ID);
                        if (dr[0]["iMassDate"].ToString().Trim() != "" && gridView1.GetRowCellValue(i, gridCol失效日期).ToString().Trim()=="")
                        {
                            throw new Exception("失效日期不可为空");
                        }

                        decimal s数量 = 0;
                        decimal d原始数量 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol原始数量), 6);
                        string sid = gridView1.GetRowCellValue(i, gridColAutoID).ToString();
                        for (int j = 0; j < gridView1.RowCount; j++)
                        {
                            if (i != j && sid == gridView1.GetRowCellValue(j, gridColAutoID).ToString())
                            {
                                s数量 = s数量 + BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(j, gridCol数量), 6);
                            }
                        }
                        //if (d数量 + s数量 > d原始数量)
                        //{
                        //    throw new Exception((i + 1) + "行数量不能超出到货单数量");
                        //    return;
                        //}

                        Model.rdrecords01 models = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.rdrecords01();
                        iIDDetails += 1;
                        models.AutoID = iIDDetails;
                        models.ID = iID;
                        models.cInvCode = gridView1.GetRowCellValue(i, gridCol存货编码).ToString().Trim();

                        long AutoID = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColAutoID));
                        if(gridView1.GetRowCellValue(i,gridCol辅计量).ToString().Trim() != "")
                        {
                            models.iNum = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol件数));
                            models.iNNum = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol件数));
                            models.cAssUnit = dr[0]["cunitid"].ToString().Trim();
                        }
                        models.iQuantity = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol数量));
                        models.iNQuantity = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol数量));

                        

                        models.iFlag = 0;
                        models.cDefine22 = dr[0]["cDefine22"].ToString().Trim();
                        models.cDefine23 = dr[0]["cDefine23"].ToString().Trim();
                        models.cDefine24 = dr[0]["cDefine24"].ToString().Trim();
                        models.cDefine25 = dr[0]["cDefine25"].ToString().Trim();
                        if (dr[0]["cDefine26"].ToString().Trim() != "")
                        {
                            models.cDefine26 = BaseFunction.ReturnDecimal(dr[0]["cDefine26"]);
                        }
                        models.cItem_class = dr[0]["cItem_class"].ToString().Trim();
                        models.cItemCode = dr[0]["cItemCode"].ToString().Trim();
                        //models.cName = dr[0]["cName"].ToString().Trim();
                        //models.cItemCName = dr[0]["cItemCName"].ToString().Trim();

                        models.cFree1 = gridView1.GetRowCellValue(i, gridColcFree1).ToString().Trim();
                        models.cFree2 = gridView1.GetRowCellValue(i, gridColcFree2).ToString().Trim();
                        models.cFree3 = gridView1.GetRowCellValue(i, gridColcFree3).ToString().Trim();
                        models.cFree4 = gridView1.GetRowCellValue(i, gridColcFree4).ToString().Trim();
                        models.cFree5 = gridView1.GetRowCellValue(i, gridColcFree5).ToString().Trim();
                        models.cFree6 = gridView1.GetRowCellValue(i, gridColcFree6).ToString().Trim();
                        models.cFree7 = dr[0]["cFree7"].ToString().Trim();
                        models.cFree8 = dr[0]["cFree8"].ToString().Trim();
                        models.cFree9 = dr[0]["cFree9"].ToString().Trim();
                        models.cFree10 = dr[0]["cFree10"].ToString().Trim();

                        if (BaseFunction.ReturnDecimal(models.cFree1) != 0 && BaseFunction.ReturnDecimal(models.cFree2) != 0)
                        {
                            models.cDefine27 = models.iQuantity;
                        }
                        //models.cVouchCode = 0;
                        models.cBatch = gridView1.GetRowCellValue(i, gridCol批号).ToString().Trim();
                        models.iSQuantity = 0;
                        models.iSNum = 0;
                        models.iMoney = 0;
                        //models.dVDate = "";
                        models.iPOsID = BaseFunction.ReturnLong(dr[0]["iPOsID"]);
                        models.iArrsId = AutoID;
                        models.cPOID = dr[0]["cOrderCode"].ToString();
                        models.cbarvcode = dtHead.Rows[0]["ccode"].ToString().Trim();
                        models.dVDate = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridCol失效日期));
                        models.dbarvdate = dtArrDate.Text.ToString();
                        models.bLPUseFree = false;
                        models.bCosting = true;
                        //models.bVMIUsed = false;
                        models.iExpiratDateCalcu = 0;
                        models.iordertype = 0;
                        models.isotype = 0;
                        models.irowno = iRow;
                        //models.iposflag = 0;
                        //models.iIMOSID = DBNull.Value;
                        //models.iIMBSID = DBNull.Value;
                        models.cbsysbarcode = "||st01|" + txt单据号.Text + "|" + iRow;

                        //models.dMadeDate = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridCol生产日期));//生产日期 
                        string s生产日期 = dr[0]["dMadeDate"].ToString().Trim();
                        if (s生产日期 != "")
                        {
                            models.dMadeDate = BaseFunction.ReturnDate(s生产日期);
                            s生产日期 = "'" + models.dMadeDate + "'";
                        }
                        else
                        {
                            s生产日期 = "Null";
                        }

                        string s失效日期 = gridView1.GetRowCellValue(i, gridCol失效日期).ToString().Trim();
                        if (s失效日期 != "")
                        {
                            models.dVDate = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridCol失效日期));
                            s失效日期 = "'" + models.dVDate + "'";
                        }
                        else
                        {
                            s失效日期 = "Null";
                        }
                        models.iMassDate = BaseFunction.ReturnInt(dr[0]["iMassDate"]);//保质期天数
                        models.cMassUnit = BaseFunction.ReturnInt(dr[0]["cMassUnit"]);//保质期单位
                        models.chVencode = txtcVenCode.Text.Trim();

                        decimal d含税单价 = BaseFunction.ReturnDecimal(dr[0]["iOriTaxCost"], 6);
                        decimal d含税金额 = BaseFunction.ReturnDecimal(d含税单价 * d数量, 2);
                        decimal d税率 = BaseFunction.ReturnDecimal(dr[0]["iTaxRate"], 6);
                        decimal d无税金额 = BaseFunction.ReturnDecimal(d含税金额 / (1 + d税率 / 100), 2);
                        decimal d税额 = d含税金额 - d无税金额;
                        decimal d无税单价 = BaseFunction.ReturnDecimal(d无税金额 / d数量, 3);

                        models.iinvexchrate = BaseFunction.ReturnDecimal(dr[0]["iinvexchrate"], 6);
                        models.iUnitCost = d含税单价;//单价 
                        models.iPrice = d含税金额;//金额
                        models.iAPrice = d含税金额;//暂估金额 
                        models.fACost = d含税单价;//暂估单价 

                        models.iOriTaxCost = d含税单价;//原币含税单价
                        models.iOriCost = d无税单价;//原币无税单价 
                        models.iOriMoney = d无税金额;//原币无税金额
                        models.iOriTaxPrice = d税额;//原币税额
                        models.ioriSum = d含税金额;//原币价税合计 
                        models.iTaxRate = d税率;//税率
                        models.iTaxPrice = d税额;//税额
                        models.iSum = 0;

                        string s存货编码 = models.cInvCode;
                        string cFree1 = models.cFree1;
                        string cFree2 = models.cFree2;
                        string cFree3 = models.cFree3;
                        string cFree4 = models.cFree4;
                        string cFree5 = models.cFree5;
                        string cFree6 = models.cFree6;
                        string cFree7 = models.cFree7;
                        string cFree8 = models.cFree8;
                        string cFree9 = models.cFree9;
                        string cFree10 = models.cFree10;

                        DAL.rdrecords01 dals = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.rdrecords01();
                        sSQL = dals.Add(models);
                        iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        //更新现存量

                        sSQL = "select * from SCM_Item where cInvCode = '" + s存货编码 + "' and ISNULL(cFree1,'') = '" + cFree1 + "' and ISNULL(cFree2,'') = '" + cFree2 + "' and ISNULL(cFree3,'') = '" + cFree3 + "' and ISNULL(cFree4,'') = '" + cFree4 + "' and ISNULL(cFree5,'') = '" + cFree5 + "' and ISNULL(cFree6,'') = '" + cFree6 + "' and ISNULL(cFree7,'') = '" + cFree7 + "' and ISNULL(cFree8,'') = '" + cFree8 + "' and ISNULL(cFree9,'') = '" + cFree9 + "' and ISNULL(cFree10,'') = '" + cFree10 + "' ";
                        DataTable dtTemp2 = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        long lItemID = 0;
                        if (dtTemp2 == null || dtTemp2.Rows.Count == 0)
                        {
                            try
                            {


                                sSQL = "insert into SCM_Item(cInvCode,cFree1,cFree2,cFree3,cFree4,cFree5,cFree6,cFree7,cFree8,cFree9,cFree10,PartId) " +
                                        "values('" + s存货编码 + "','" + cFree1 + "','" + cFree2 + "','" + cFree3 + "','" + cFree4 + "','" + cFree5 + "','" + cFree6 + "','" + cFree7 + "','" + cFree8 + "','" + cFree9 + "','" + cFree10 + "',0)";
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                            catch
                            {
                                throw new Exception("现存量更新有误" + sSQL);
                            }
                            sSQL = "select * from SCM_Item where cInvCode = '" + s存货编码 + "'  and ISNULL(cFree1,'') = '" + cFree1 + "' and ISNULL(cFree2,'') = '" + cFree2 + "' and ISNULL(cFree3,'') = '" + cFree3 + "' and ISNULL(cFree4,'') = '" + cFree4 + "' and ISNULL(cFree5,'') = '" + cFree5 + "' and ISNULL(cFree6,'') = '" + cFree6 + "' and ISNULL(cFree7,'') = '" + cFree7 + "' and ISNULL(cFree8,'') = '" + cFree8 + "' and ISNULL(cFree9,'') = '" + cFree9 + "' and ISNULL(cFree10,'') = '" + cFree10 + "' ";
                            dtTemp2 = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            lItemID = Convert.ToInt64(dtTemp2.Rows[0]["id"]);

                        }
                        else
                        {
                            lItemID = Convert.ToInt64(dtTemp2.Rows[0]["id"]);
                        }

                        sSQL = "declare @itmeid int " +
                                "select @itmeid = MAX(ItemId) + 1 from CurrentStock " +
                               "if exists(select * from CurrentStock where cinvcode = '" + s存货编码 + "' and isnull(cBatch,'') = isnull('" + cBatch + "','')  and cWhCode = '" + cWhCode + "'  and ISNULL(cFree1,'') = '" + cFree1 + "' and ISNULL(cFree2,'') = '" + cFree2 + "' and ISNULL(cFree3,'') = '" + cFree3 + "' and ISNULL(cFree4,'') = '" + cFree4 + "' and ISNULL(cFree5,'') = '" + cFree5 + "' and ISNULL(cFree6,'') = '" + cFree6 + "' and ISNULL(cFree7,'') = '" + cFree7 + "' and ISNULL(cFree8,'') = '" + cFree8 + "' and ISNULL(cFree9,'') = '" + cFree9 + "' and ISNULL(cFree10,'') = '" + cFree10 + "' ) " +
                               "    update CurrentStock set iQuantity = isnull(iQuantity,0) + " + d数量 + ",iNum = isnull(iNum,0) + " + d件数 + ",iMassDate='" + dr[0]["iMassDate"].ToString().Trim() + "',cMassUnit='" + dr[0]["cMassUnit"].ToString().Trim() + "',dVDate=" + s失效日期 + ", dMDate=" + s生产日期 + " " +
                               "    where cinvcode = '" + s存货编码 + "' and isnull(cBatch,'') = isnull('" + cBatch + "','') and cWhCode = '" + cWhCode + "'  and ISNULL(cFree1,'') = '" + cFree1 + "' and ISNULL(cFree2,'') = '" + cFree2 + "' and ISNULL(cFree3,'') = '" + cFree3 + "' and ISNULL(cFree4,'') = '" + cFree4 + "' and ISNULL(cFree5,'') = '" + cFree5 + "' and ISNULL(cFree6,'') = '" + cFree6 + "' and ISNULL(cFree7,'') = '" + cFree7 + "' and ISNULL(cFree8,'') = '" + cFree8 + "' and ISNULL(cFree9,'') = '" + cFree9 + "' and ISNULL(cFree10,'') = '" + cFree10 + "' " +
                               "else " +
                               "    insert into CurrentStock(cWhCode,cInvCode,cBatch,iSoType,iQuantity,iNum,ItemId,cFree1,cFree2,cFree3,cFree4,cFree5,cFree6,cFree7,cFree8,cFree9,cFree10,iSodid,iMassDate,cMassUnit,dVDate,dMDate)  " +
                               "    values(N'" + cWhCode + "', N'" + s存货编码 + "',N'" + cBatch + "',0," + d数量 + "," + d件数 + "," + lItemID + ",'" + cFree1 + "','" + cFree2 + "','" + cFree3 + "','" + cFree4 + "','" + cFree5 + "','" + cFree6 + "','" + cFree7 + "','" + cFree8 + "','" + cFree9 + "','" + cFree10 + "',''"+
                               ",'" + dr[0]["iMassDate"].ToString().Trim() + "','" + dr[0]["cMassUnit"].ToString().Trim() + "'," + s失效日期 + "," + s生产日期 + ")";
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        sSQL = "update PU_ArrivalVouchs set fValidInQuan  = isnull(fValidInQuan ,0) + " + BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol数量)) + " ,fValidInNum  = isnull(fValidInNum ,0) + " + BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol件数)) + " " +
                                        "where autoid = " +AutoID;
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        sSQL = "update po_podetails set  " +//iReceivedQTY  = isnull(iReceivedQTY ,0) + " + ClsBaseDataInfo.ReturnCol(d数量) + " ,iReceivedNum   = isnull(iReceivedNum,0) + " + ClsBaseDataInfo.ReturnCol(d件数) + ",
                                "freceivedqty= isnull(iReceivedQTY ,0) + " + BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol数量)) + ", freceivednum = isnull(iReceivedNum,0) + " + BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol件数)) + "" +
                                "where ID = " +dr[0]["iPOsID"].ToString();
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    sSQL = @"
exec ST_SaveForStock N'01',N'111111',0,0 ,1
";
                    sSQL = sSQL.Replace("111111", iID.ToString());
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = @"
exec ST_SaveForTrackStock N'01',N'111111', 0 ,1
";
                    sSQL = sSQL.Replace("111111", iID.ToString());
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = "exec IA_SP_WriteUnAccountVouchForST '111111',N'01'";
                    sSQL = sSQL.Replace("111111", iID.ToString());
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    if (iCou > 0)
                    {
                        tran.Commit();
                        MessageBox.Show("保存成功。单据号:" + model.cCode);
                    }
                    else
                    {
                        throw new Exception("没有需要保存的单据体");
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
                MessageBox.Show(ee.Message);
            }
        }




        private void ItemButtonEditcInvCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                gridView1.FocusedColumn = gridCol存货名称;
                string sInvCode = gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, gridCol存货编码).ToString().Trim();

                gridView1.FocusedColumn = gridCol存货编码;

                FrmInvInfo frm = new FrmInvInfo(sInvCode, false);
                DialogResult d = frm.ShowDialog();
                if (d == DialogResult.OK)
                {
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridCol存货编码, frm.sInvCode);
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

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                FrmRDInPuSEL frm = new FrmRDInPuSEL();
                frm.sConnString = Conn;
                frm.ShowDialog();

                string sCode = frm.sCode;

                if (sCode.Trim() == "")
                {
                    throw new Exception("获得单据号失败");
                }

                DataTable dttmp = frm.dt;

                string sSQL = "select a.*,b.cVenName from PU_ArrivalVouch a left join Vendor b on a.cVenCode=b.cVenCode where cCode = '" + sCode + "'";
                dtHead = DbHelperSQL.Query(sSQL);

                if (dtHead == null || dtHead.Rows.Count == 0)
                {
                    throw new Exception("加载采购到货单失败");
                }
                string cBatch = DateTime.Now.ToString("yyyyMM") + "00";
                sSQL = @"
select a.cInvCode as 存货编码,b.cInvName as 存货名称,b.cInvStd as 规格型号
,case when a.iNum is not null then cast(a.cFree1 as decimal)*cast(a.cFree2 as decimal)/10000*(isnull(a.iNum,0)-isnull(fValidInNum,0)-isnull(fRefuseNum,0))
else isnull(a.iQuantity,0) - isnull(fValidInQuan,0)-isnull(fRefuseQuantity,0) end as 数量
,convert(int,case when isnull(a.iNum,0)-isnull(fValidInNum,0)-isnull(fRefuseNum,0)=0 then null else isnull(a.iNum,0)-isnull(fValidInNum,0)-isnull(fRefuseNum,0) end) as 件数
,a.cbMemo as 表体备注,a.iinvexchrate  as 换算率
,a.cUnitID as 辅计量,b.cComUnitCode  as 主计量,a.iQuantity as 订单数量,a.iNum as 订单件数
,isnull(a.iQuantity,0) - isnull(fValidInQuan,0)-isnull(fRefuseQuantity,0)  as 原始数量
,convert(int,case when isnull(a.iNum,0)-isnull(fValidInNum,0)-isnull(fRefuseNum,0)=0 then null else isnull(a.iNum,0)-isnull(fValidInNum,0)-isnull(fRefuseNum,0) end) as 原始件数
	,* ,convert(datetime,convert(nvarchar(10),getdate(),120)) as dMadeDate ,'222222' as 批号
,case when isnull(b.cMassUnit,'')!='' then dateadd(d,(case when b.cMassUnit=1 then b.iMassDate*365  when b.cMassUnit=2 then b.iMassDate*30  when b.cMassUnit=3 then b.iMassDate end),convert(datetime,convert(nvarchar(10),getdate(),120))) end as 失效日期
from pu_ArrBody a left join Inventory b on a.cInvCode = b.cInvCode 
left join PO_Podetails c on a.iPOsID =c.ID 
left join PO_Pomain d on c.POID=d.POID
where 1=1 
order by AutoID
";
                sSQL = sSQL.Replace("222222", cBatch);
                string s = "";
                for (int i = 0; i < dttmp.Rows.Count; i++)
                {
                    if (dttmp.Rows[i].RowState != DataRowState.Deleted)
                    {
                        if (s != "")
                        {
                            s = s + " or ";
                        }
                        s = s + "(a.ID='" + dttmp.Rows[i]["ID"].ToString() + "' and d.cPOID='" + dttmp.Rows[i]["cPOID"].ToString() + "' and a.cFree1='" + dttmp.Rows[i]["cFree1"].ToString() + "' and a.cFree2='" + dttmp.Rows[i]["cFree2"].ToString() + "')";
                    }
                }
                sSQL = sSQL.Replace("1=1", "1=1 and (" + s + ")");
                DataTable dts = DbHelperSQL.Query(sSQL);
                dtDetails = dts.Copy();

                txt单据号.Text = dtHead.Rows[0]["cCode"].ToString().Trim();
                dtm.DateTime = BaseFunction.ReturnDate(DateTime.Now.ToString("yyyy-MM-dd"));
                txtcVenCode.Text = dtHead.Rows[0]["cVenCode"].ToString().Trim();
                txtcVenName.Text = dtHead.Rows[0]["cVenName"].ToString().Trim();
                dtArrDate.DateTime = BaseFunction.ReturnDate(dtHead.Rows[0]["dDate"]);
                txt备注.Text = dtHead.Rows[0]["cMemo"].ToString().Trim();

                gridControl1.DataSource = dts;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void 增行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.IsRowSelected(i))
                {
                    gridView1.AddNewRow();
                    int iRow = gridView1.RowCount - 1;
                    gridView1.FocusedRowHandle = iRow;

                    gridView1.SetRowCellValue(iRow, gridColAutoID, gridView1.GetRowCellValue(i, gridColAutoID));
                    gridView1.SetRowCellValue(iRow, gridColcFree1, gridView1.GetRowCellValue(i, gridColcFree1));
                    gridView1.SetRowCellValue(iRow, gridColcFree2, gridView1.GetRowCellValue(i, gridColcFree2));
                    gridView1.SetRowCellValue(iRow, gridColcFree3, gridView1.GetRowCellValue(i, gridColcFree3));
                    gridView1.SetRowCellValue(iRow, gridColcFree4, gridView1.GetRowCellValue(i, gridColcFree4));
                    gridView1.SetRowCellValue(iRow, gridColcFree5, gridView1.GetRowCellValue(i, gridColcFree5));
                    gridView1.SetRowCellValue(iRow, gridColcFree6, gridView1.GetRowCellValue(i, gridColcFree6));
                    gridView1.SetRowCellValue(iRow, gridColID, gridView1.GetRowCellValue(i, gridColID));
                    gridView1.SetRowCellValue(iRow, gridCol表体备注, gridView1.GetRowCellValue(i, gridCol表体备注));
                    gridView1.SetRowCellValue(iRow, gridCol存货编码, gridView1.GetRowCellValue(i, gridCol存货编码));
                    gridView1.SetRowCellValue(iRow, gridCol存货名称, gridView1.GetRowCellValue(i, gridCol存货名称));
                    gridView1.SetRowCellValue(iRow, gridCol辅计量, gridView1.GetRowCellValue(i, gridCol辅计量));
                    gridView1.SetRowCellValue(iRow, gridCol规格型号, gridView1.GetRowCellValue(i, gridCol规格型号));
                    gridView1.SetRowCellValue(iRow, gridCol换算率, gridView1.GetRowCellValue(i, gridCol换算率));
                    gridView1.SetRowCellValue(iRow, gridCol生产日期, gridView1.GetRowCellValue(i, gridCol生产日期));
                    gridView1.SetRowCellValue(iRow, gridCol失效日期, gridView1.GetRowCellValue(i, gridCol失效日期));
                    gridView1.SetRowCellValue(iRow, gridCol批号, gridView1.GetRowCellValue(i, gridCol批号));
                    gridView1.SetRowCellValue(iRow, gridCol订单件数, gridView1.GetRowCellValue(i, gridCol订单件数));
                    gridView1.SetRowCellValue(iRow, gridCol订单数量, gridView1.GetRowCellValue(i, gridCol订单数量));

                    gridView1.SetRowCellValue(iRow, gridCol原始件数, gridView1.GetRowCellValue(i, gridCol原始件数));
                    gridView1.SetRowCellValue(iRow, gridCol原始数量, gridView1.GetRowCellValue(i, gridCol原始数量));
                    gridView1.SetRowCellValue(iRow, gridCol主计量, gridView1.GetRowCellValue(i, gridCol主计量));
                    gridView1.SetRowCellValue(iRow, gridCol件数, gridView1.GetRowCellValue(i, gridCol件数));
                    gridView1.SetRowCellValue(iRow, gridCol数量, gridView1.GetRowCellValue(i, gridCol数量));
                    break;
                }
            }
        }

        private void gridView1_CustomDrawRowIndicator_1(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                decimal d换算率 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.FocusedRowHandle, gridCol换算率), 6);
                if (d换算率 == 0)
                {
                    gridCol件数.OptionsColumn.AllowEdit = false;
                }
                else
                {
                    gridCol件数.OptionsColumn.AllowEdit = true;
                }
            }
            catch { }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                int iRow = e.RowHandle;
                decimal d数量 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol数量), 6);
                decimal s数量 = 0;
                decimal s件数 = 0;
                decimal d件数 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol件数), 6);
                decimal d原始数量 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol原始数量), 6);
                decimal d原始件数 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol原始件数), 6);
                string sid = gridView1.GetRowCellValue(iRow, gridColAutoID).ToString();
                decimal d换算率 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol换算率), 6);
                decimal cFree1 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColcFree1), 6);
                decimal cFree2 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColcFree2), 6);

                if (e.Column == gridColcFree1 || e.Column == gridColcFree2 || e.Column == gridCol件数)
                {
                    d换算率 = cFree1 * cFree2 / 10000;
                    d数量 = d换算率 * d件数;
                    if (d数量 != BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol数量), 6))
                    {
                        gridView1.SetRowCellValue(iRow, gridCol数量, d数量);
                    }
                    if (d件数 != BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol件数), 6))
                    {
                        gridView1.SetRowCellValue(iRow, gridCol件数, d件数);
                    }
                    if (d换算率 != BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol换算率), 6))
                    {
                        gridView1.SetRowCellValue(iRow, gridCol换算率, d换算率);
                    }
                }
                
                //if (e.Column == gridCol数量)
                //{
                    //for (int i = 0; i < gridView1.RowCount; i++)
                    //{
                    //    if (i != iRow && sid == gridView1.GetRowCellValue(i, gridColAutoID).ToString())
                    //    {
                    //        s数量 = s数量 + BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol数量), 6);
                    //    }
                    //}
                    //if (d数量 + s数量 > d原始数量)
                    //{
                    //    MessageBox.Show("数量不能超出到货单数量");
                    //    gridView1.SetRowCellValue(iRow, gridCol数量, d原始数量 - s数量);
                    //    return;
                    //}
                    //else
                    //{
                    //    if (d换算率 != 0)
                    //    {
                    //        if (d数量 == d原始数量)
                    //        {
                    //            d件数 = d原始件数;
                    //        }
                    //        else
                    //        {
                    //            d件数 = BaseFunction.ReturnDecimal(d数量 / d换算率, 6);
                    //        }
                    //        gridView1.SetRowCellValue(e.RowHandle, gridCol件数, d件数);
                    //    }
                    //}
                //}
                //if (e.Column == gridCol件数)
                //{
                //    for (int i = 0; i < gridView1.RowCount; i++)
                //    {
                //        if (i != iRow && sid == gridView1.GetRowCellValue(i, gridColAutoID).ToString())
                //        {
                //            s件数 = s件数 + BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol件数), 6);
                //        }
                //    }
                //    if (d件数 + s件数 > d原始件数)
                //    {
                //        MessageBox.Show("件数不能超出到货单件数");
                //        gridView1.SetRowCellValue(e.RowHandle, gridCol件数, d原始件数 - s件数);
                //        return;
                    
                //    }
                //}
            }
            catch { }
            if (e.Column == gridColcFree1)
            {
                GetHas("20", gridView1.GetRowCellValue(e.RowHandle, gridColcFree1).ToString());
            }
            if (e.Column == gridColcFree2)
            {
                GetHas("21", gridView1.GetRowCellValue(e.RowHandle, gridColcFree2).ToString());
            }
        }

        private void GetHas(string cID, string cValue)
        {
            if (cValue.Trim() != "")
            {
                string sSQL = "select * from UserDefine where cID='" + cID + "' and cValue='" + cValue + "' ";
                DataTable dt = DbHelperSQL.Query(sSQL);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("自由项不符合");
                }
            }
        }
        private void 删行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = gridView1.RowCount-1; i >= 0; i--)
            {
                if (gridView1.IsRowSelected(i))
                {
                    gridView1.DeleteRow(i);
                    break;
                }
            }
        }

        
    }
}
