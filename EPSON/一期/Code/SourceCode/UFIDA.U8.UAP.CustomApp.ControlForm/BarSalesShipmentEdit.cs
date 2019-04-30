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
    public partial class BarSalesShipmentEdit : UserControl
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

        public BarSalesShipmentEdit()
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
    ,a.CartonNo
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
                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    if (sErr.Trim() != "")
                        throw new Exception(sErr);

                    string sSQL = "";

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        bool b = BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColchoose));
                        if (!b)
                            continue;

                        sSQL = @"
update _SalesShipment set  CartonNo = 'aaaaaa' where iID = bbbbbb
";
                        sSQL = sSQL.Replace("aaaaaa", gridView1.GetRowCellValue(i, gridColCartonNo).ToString().Trim());
                        sSQL = sSQL.Replace("bbbbbb", gridView1.GetRowCellValue(i, gridColiID).ToString().Trim());
                        iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    if (iCount > 0)
                    {
                        tran.Commit();

                        MessageBox.Show("OK");
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
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            string sErr = "";

            int iCount = 0;
            try
            {
                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    if (sErr.Trim() != "")
                        throw new Exception(sErr);

                    string sSQL = "";

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        bool b = BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColchoose));
                        if (!b)
                            continue;
                        sSQL = @"
select *
FROM      _BarStatus
where BarCode = 'aaaaaa' and iSOsID = bbbbbb
order by iID
";
                        sSQL = sSQL.Replace("aaaaaa", gridView1.GetRowCellValue(i, gridColLotNO).ToString().Trim());
                        sSQL = sSQL.Replace("bbbbbb", gridView1.GetRowCellValue(i, gridColiSOsID).ToString().Trim());
                        DataTable dtBarCode = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtBarCode.Rows[0]["Type"].ToString().Trim().ToLower() != "pending")
                        {
                            sErr = sErr + "Row " + (i + 1).ToString() + " type is err \n";
                        }

                        sSQL = @"
delete _SalesShipment where iID = bbbbbb
";
                        sSQL = sSQL.Replace("bbbbbb", gridView1.GetRowCellValue(i, gridColiID).ToString().Trim());
                        iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        sSQL = @"
update _BarCodeLabel set Status =  Process where BarCode = 'aaaaaa' and iSOsID = bbbbbb
";
                        sSQL = sSQL.Replace("aaaaaa", gridView1.GetRowCellValue(i, gridColLotNO).ToString().Trim());
                        sSQL = sSQL.Replace("bbbbbb", gridView1.GetRowCellValue(i, gridColiSOsID).ToString().Trim());
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                        sSQL = @"
delete  _BarStatus where BarCode = 'aaaaaa' and iSOsID = bbbbbb and Type = 'Pending'
";
                        sSQL = sSQL.Replace("aaaaaa", gridView1.GetRowCellValue(i, gridColLotNO).ToString().Trim());
                        sSQL = sSQL.Replace("bbbbbb", gridView1.GetRowCellValue(i, gridColiSOsID).ToString().Trim());
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    if (iCount > 0)
                    {
                        tran.Commit();

                        btnQuery_Click(null, null);

                        MessageBox.Show("OK");
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
