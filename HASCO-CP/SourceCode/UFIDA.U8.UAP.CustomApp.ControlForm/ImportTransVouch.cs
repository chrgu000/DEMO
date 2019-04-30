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
    public partial class ImportTransVouch : UserControl
    {        
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
                DbHelperSQL.connectionString = Conn;

                SetLookup();
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "Err";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        public ImportTransVouch()
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

        private void btnImprot_Click(object sender, EventArgs e)
        {
            try
            {
                gridViewPL.FocusedRowHandle -= 1;
                gridViewPL.FocusedRowHandle += 1;
            }
            catch { }

            try
            {
                if (txtEntryNo.Text.Trim() == "")
                {
                    txtEntryNo.Focus();
                    throw new Exception("Please set entry no");
                }

                int iCou = gridViewPL.RowCount;
                if (iCou == 0)
                {
                    throw new Exception("no data");
                }

                string sMCode = "";

                int iCodeCou = gridViewPL.RowCount;
                string sErr = "";
                int iCount = 0;
                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    if (lookUpEditWarehouseIN == null || lookUpEditWarehouseIN.Text.Trim() == "")
                    {
                        lookUpEditWarehouseIN.Focus();
                        throw new Exception("Please choose transfer-in warehouse");
                    }
                    if (lookUpEditWarehouseOUT == null || lookUpEditWarehouseOUT.Text.Trim() == "")
                    {
                        lookUpEditWarehouseOUT.Focus();
                        throw new Exception("Please choose transfer-out warehouse");
                    }

                    string sWhCodeIn = lookUpEditWarehouseIN.EditValue.ToString().Trim();
                    string sWhCodeOut = lookUpEditWarehouseOUT.EditValue.ToString().Trim();

                    if(sWhCodeIn == sWhCodeOut)
                    {
                        throw new Exception("The warehouse can't be the same");
                    }
                    string sRdCodeIn = "";
                    string sRdCodeOut = "";
                    string sDepCodeIn = "";
                    string sDepCodeOut = "";

                    string sSQL = @"
select * from _Code where VouchType = 'TransVouch'
";
                    DataTable dtCode = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtCode != null && dtCode.Rows.Count > 0)
                    {
                        sRdCodeIn = dtCode.Rows[0]["cRdCodeIn"].ToString().Trim();
                        sRdCodeOut = dtCode.Rows[0]["cRdCodeOut"].ToString().Trim();
                        sDepCodeIn = dtCode.Rows[0]["cDepCodeIn"].ToString().Trim();
                        sDepCodeOut = dtCode.Rows[0]["cDepCodeOut"].ToString().Trim();
                    }
                    else
                    {
                        throw new Exception("Please set _code [TransVouch]");
                    }

                    if (sWhCodeIn == "" || sWhCodeOut == "" || sRdCodeIn == "" || sRdCodeOut == "")
                    {
                        throw new Exception("Please set _code [TransVouchClaim]");
                    }

                    DateTime dLogDate = BaseFunction.ReturnDate(sLogDate);

                    //string sDate = dateEdit1.DateTime.ToString("yyyy-MM-dd");
                    string sDate = sLogDate;
                    sSQL = @"
select bflag_ST from gl_mend where iyear = aaaaaa and iperiod = bbbbbb
";
                    sSQL = sSQL.Replace("aaaaaa", dLogDate.Year.ToString());
                    sSQL = sSQL.Replace("bbbbbb", dLogDate.Month.ToString());
                    DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (BaseFunction.ReturnBool(dtTemp.Rows[0]["bflag_ST"]))
                    {
                        throw new Exception("The current date has been checked out");
                    }

                    string sDateTime = dateEditQuery.DateTime.ToString("yyyy-MM-dd");

                    bool bNeedTR = false;   //是否需要索赔调拨
                    #region 生成调拨单

                    long lID = -1;
                    long lIDDetails = -1;
                    sSQL = @"
declare @p5 int
set @p5=aaaaaa
declare @p6 int
set @p6=bbbbbb
exec sp_GetId N'00',N'dddddd',N'tr',cccccc,@p5 output,@p6 output,default
select @p5, @p6
";
                    sSQL = sSQL.Replace("aaaaaa", lID.ToString());
                    sSQL = sSQL.Replace("bbbbbb", lIDDetails.ToString());
                    sSQL = sSQL.Replace("cccccc", iCou.ToString());
                    sSQL = sSQL.Replace("dddddd", sAccID);
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    lID = BaseFunction.ReturnLong(dt.Rows[0][0]) - 1;
                    lIDDetails = BaseFunction.ReturnLong(dt.Rows[0][1]) - iCodeCou;

                    ////获得单据号
                    sSQL = "select * from VoucherHistory with (ROWLOCK) Where CardNumber='0304' AND cSeed = 'aaaaaa'";
                    sSQL = sSQL.Replace("aaaaaa", dLogDate.ToString("yyyyMMdd"));
                    dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    long iCode = 0;
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        iCode = BaseFunction.ReturnLong(dt.Rows[0]["cNumber"]) + 1;
                        sSQL = @"
update VoucherHistory set cNumber = aaaaaa where autoid = bbbbbb and CardNumber = '0304'
";
                        sSQL = sSQL.Replace("aaaaaa", iCode.ToString());
                        sSQL = sSQL.Replace("bbbbbb", dt.Rows[0]["AutoId"].ToString().Trim());
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                    else
                    {
                        iCode = 1;
                        sSQL = @"
insert into VoucherHistory(CardNumber, cContent, cContentRule, cSeed, cNumber, bEmpty)
values('0304','日期','日','aaaaaa',1,0)
";
                        sSQL = sSQL.Replace("aaaaaa", dLogDate.ToString("yyyyMMdd"));
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                    iCode += 1;
                    string sCode = iCode.ToString();
                    while (sCode.Length < 4)
                    {
                        sCode = "0" + sCode;
                    }
                    sCode = "TF" + dLogDate.ToString("yyyyMMdd") + sCode;

                    sSQL = @"
select distinct * from Rdrecord01 
where id in (select id from Rdrecords01 where autoid = {0})
";
                    sSQL = string.Format(sSQL, gridViewPL.GetRowCellValue(0, gridColRds01ID));
                    DataTable dtRd = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    Model.TransVouch mod = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.TransVouch();
                    mod.cTVCode = sCode;
                    mod.dTVDate = dLogDate;

                    mod.cOWhCode = sWhCodeOut;      
                    mod.cIWhCode = sWhCodeIn;
                    mod.cIRdCode = sRdCodeIn;      
                    mod.cORdCode = sRdCodeOut;

                    if (sDepCodeIn != "")
                    {
                        mod.cIDepCode = sDepCodeIn;
                    }
                    if (sDepCodeOut != "")
                    {
                        mod.cODepCode = sDepCodeOut;
                    }
                    mod.cPersonCode = null;
                    mod.cTVMemo = txtMemo.Text.Trim();

                    if(dtRd.Rows[0]["cDefine1"].ToString().Trim() != "")
                    {
                        mod.cDefine1 = dtRd.Rows[0]["cDefine1"].ToString().Trim();
                    }
                    if(dtRd.Rows[0]["cDefine2"].ToString().Trim() != "")
                    {
                    mod.cDefine2 = dtRd.Rows[0]["cDefine2"].ToString().Trim();
                    }
                    if(dtRd.Rows[0]["cDefine3"].ToString().Trim() != "")
                    {
                        mod.cDefine3 = dtRd.Rows[0]["cDefine3"].ToString().Trim();
                    }
                    if(dtRd.Rows[0]["cDefine4"].ToString().Trim() != "")
                    {
                        mod.cDefine4 = BaseFunction.ReturnDate(dtRd.Rows[0]["cDefine4"]);
                    }
                    if(dtRd.Rows[0]["cDefine5"].ToString().Trim() != "")
                    {
                        mod.cDefine5 = BaseFunction.ReturnLong(dtRd.Rows[0]["cDefine5"]);
                    }
                    if(dtRd.Rows[0]["cDefine6"].ToString().Trim() != "")
                    {
                        mod.cDefine6 = BaseFunction.ReturnDate(dtRd.Rows[0]["cDefine6"]);
                    }
                    if(dtRd.Rows[0]["cDefine7"].ToString().Trim() != "")
                    {
                        mod.cDefine7 = BaseFunction.ReturnDecimal(dtRd.Rows[0]["cDefine7"]);
                    }
                    if(dtRd.Rows[0]["cDefine8"].ToString().Trim() != "")
                    {
                        mod.cDefine8 = dtRd.Rows[0]["cDefine8"].ToString().Trim(); 
                    }
                    if(dtRd.Rows[0]["cDefine9"].ToString().Trim() != "")
                    {
                        mod.cDefine9 = dtRd.Rows[0]["cDefine9"].ToString().Trim(); 
                    }
                    if(dtRd.Rows[0]["cDefine10"].ToString().Trim() != "")
                    {
                        mod.cDefine10 = dtRd.Rows[0]["cDefine10"].ToString().Trim();
                    }
                    mod.cAccounter = null;
                    mod.iNetLock = 1;
                    lID += 1;
                    mod.ID = lID;
                    mod.VT_ID = 89;
                    mod.cMaker = sUserName;
                    mod.dnmaketime = dLogDate;

                    mod.cVerifyPerson = sUserName;
                    mod.dVerifyDate = dLogDate;
                    mod.cPSPCode = null;
                    mod.cMPoCode = null;
                    mod.iQuantity = 0;
                    mod.bTransFlag = null;
                    //if (dtRd.Rows[0]["cDefine11"].ToString().Trim() != "")
                    //{
                    //    mod.cDefine11 = dtRd.Rows[0]["cDefine11"].ToString().Trim();
                    //}
                    mod.cDefine11 = txtEntryNo.Text.Trim();
                    if (dtRd.Rows[0]["cDefine12"].ToString().Trim() != "")
                    {
                        mod.cDefine12 = dtRd.Rows[0]["cDefine12"].ToString().Trim();
                    }
                    if (dtRd.Rows[0]["cDefine13"].ToString().Trim() != "")
                    {
                        mod.cDefine13 = dtRd.Rows[0]["cDefine13"].ToString().Trim();
                    }
                    if (dtRd.Rows[0]["cDefine14"].ToString().Trim() != "")
                    {
                        mod.cDefine14 = dtRd.Rows[0]["cDefine14"].ToString().Trim();
                    }
                    if (dtRd.Rows[0]["cDefine15"].ToString().Trim() != "")
                    {
                        mod.cDefine15 = BaseFunction.ReturnLong(dtRd.Rows[0]["cDefine5"]);
                    }
                    if (dtRd.Rows[0]["cDefine16"].ToString().Trim() != "")
                    {
                        mod.cDefine16 = BaseFunction.ReturnDecimal(dtRd.Rows[0]["cDefine16"]);
                    }
                  
                    mod.iproorderid = null;
                    mod.cTranRequestCode = null;
                    mod.cVersion = null;
                    mod.BomId = null;
                    mod.cFree1 = null;
                    mod.cFree2 = null;
                    mod.cFree3 = null;
                    mod.cFree4 = null;
                    mod.cFree5 = null;
                    mod.cFree6 = null;
                    mod.cFree7 = null;
                    mod.cFree8 = null;
                    mod.cFree9 = null;
                    mod.cFree10 = null;
                    mod.cAppTVCode = null;
                    mod.csource = "1";
                    mod.itransflag = "正向";
                    mod.cModifyPerson = null;
                    mod.dModifyDate = null;
                    mod.dnmaketime = DateTime.Now;
                    mod.dnmodifytime = null;
                    mod.ireturncount = null;
                    mod.iverifystate = null;
                    mod.iswfcontrolled = 0;
                    mod.csourceguid = null;
                    mod.csysbarcode = "||st12||" + mod.cTVCode;

                    mod.cDefine1 = txtEntryNo.Text.Trim();
                    mod.cCurrentAuditor = null;

                    DAL.TransVouch dalTR = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.TransVouch();
                    sSQL = dalTR.Add(mod);
                    iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sMCode = sMCode + mod.cTVCode + "\n";

                    int iRow = 0;
                    for (int i = 0; i < gridViewPL.RowCount; i++)
                    {
                        if (!BaseFunction.ReturnBool(gridViewPL.GetRowCellValue(i, gridColSelected)))
                            continue;

                        long lRds01Autoid = BaseFunction.ReturnLong(gridViewPL.GetRowCellValue(i, gridColRds01ID));
                        if (lRds01Autoid == 0)
                        {
                            sErr = sErr + "Line " + (i + 1).ToString() + " purchase receipt warrant is not imported\n";
                            continue;
                        }

                        sSQL = @"
select autoid from Rdrecords01 where autoid = aaaaaaaa
";
                        sSQL = sSQL.Replace("aaaaaaaa", lRds01Autoid.ToString());
                        DataTable dtRds01 = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        if (dtRds01 == null || dtRds01.Rows.Count == 0)
                        {
                            sErr = sErr + "Line " + (i + 1).ToString() + " purchase receipt warrant is not imported\n";
                            continue;
                        }


                        long lTRsID = BaseFunction.ReturnLong(gridViewPL.GetRowCellValue(i, gridColTrIDs));
                        if (lTRsID > 0)
                        {
                            sSQL = @"
select autoid from TransVouchs where autoid = aaaaaaaa
";
                            sSQL = sSQL.Replace("aaaaaaaa", lTRsID.ToString());
                            DataTable dtTRs01 = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                            if (dtTRs01 != null && dtTRs01.Rows.Count > 0)
                            {
                                sErr = sErr + "Line " + (i + 1).ToString() + " is imported\n";
                                continue;
                            }
                        }

                        Model.TransVouchs mods = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.TransVouchs();
                        mods.cTVCode = mod.cTVCode;
                        mods.cInvCode = gridViewPL.GetRowCellValue(i, gridColPARTNO).ToString().Trim();
                        mods.iTVNum = null;
                        mods.iTVQuantity = BaseFunction.ReturnDecimal(gridViewPL.GetRowCellValue(i, gridColQUANTITY));
                        lIDDetails += 1;
                        mods.autoID = lIDDetails;
                        mods.ID = mod.ID;
                        mods.bCosting = true;

                        iRow += 1;
                        mods.irowno = iRow;
                        mods.coutposcode = null;
                        mods.cinposcode = null;
                        //mods.cTVBatch = gridViewPL.GetRowCellValue(i, gridColcBatch).ToString().Trim();
                        mods.cDefine22 = gridViewPL.GetRowCellValue(i, gridColCONTAINERNO).ToString().Trim();
                        mods.cDefine23 = gridViewPL.GetRowCellValue(i, gridColBOXNO).ToString().Trim();
                        mods.cDefine24 = gridViewPL.GetRowCellValue(i, gridColCASENO).ToString().Trim();
                        mods.cDefine25 = gridViewPL.GetRowCellValue(i, gridColGWKGS).ToString().Trim();
                        mods.cDefine28 = gridViewPL.GetRowCellValue(i, gridColNWKGS).ToString().Trim();

                        mods.cbsysbarcode = "||st12|" + mod.cTVCode + "|" + iRow.ToString();
                        DAL.TransVouchs dalTRs = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.TransVouchs();
                        sSQL = dalTRs.Add(mods);
                        iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        //回写导入中间表 Rdrecords10_Import
                        sSQL = @"
update RdRecords01_Import set TrIDs = AAAAAA,EntryNO = 'CCCCCC'
WHERE AUTOID = BBBBBB
";
                        sSQL = sSQL.Replace("AAAAAA", mods.autoID.ToString());
                        sSQL = sSQL.Replace("BBBBBB", gridViewPL.GetRowCellValue(i, gridColAutoID).ToString());
                        sSQL = sSQL.Replace("CCCCCC", txtEntryNo.Text.Trim());
                        int iRet = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        if (iRet != 1)
                        {
                            sErr = sErr + "Line " + (i + 1) + " update dl err\n";
                        }

                        decimal dClaimQty = BaseFunction.ReturnDecimal(gridViewPL.GetRowCellValue(i, gridColClaimQty));

                        if (dClaimQty > 0)
                        {
                            bNeedTR = true;
                        }
                    }

                    if (iRow > 0)
                    {
                        clsU8 cls = new clsU8();
                        cls.TransVouch_Audit_U8V111(tran, mod.cTVCode, sAccID, sUserName);
                    }

                    #endregion


                    #region 生成索赔调拨单
                    if (bNeedTR)
                    {
                        sRdCodeIn = "";
                        sRdCodeOut = "";
                        sDepCodeIn = "";
                        sDepCodeOut = "";

                        sSQL = @"
select * from _Code where VouchType = 'TransVouchClaim'
";
                        dtCode = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtCode != null && dtCode.Rows.Count > 0)
                        {
                            sRdCodeIn = dtCode.Rows[0]["cRdCodeIn"].ToString().Trim();
                            sRdCodeOut = dtCode.Rows[0]["cRdCodeOut"].ToString().Trim();
                            sDepCodeIn = dtCode.Rows[0]["cDepCodeIn"].ToString().Trim();
                            sDepCodeOut = dtCode.Rows[0]["cDepCodeOut"].ToString().Trim();
                        }
                        else
                        {
                            throw new Exception("Please set _code [TransVouchClaim]");
                        }

                        if (sRdCodeIn == "" || sRdCodeOut == "")
                        {
                            throw new Exception("Please set _code [TransVouchClaim]");
                        }

                        lID = -1;
                        lIDDetails = -1;
                        sSQL = @"
declare @p5 int
set @p5=aaaaaa
declare @p6 int
set @p6=bbbbbb
exec sp_GetId N'00',N'dddddd',N'tr',cccccc,@p5 output,@p6 output,default
select @p5, @p6
";
                        sSQL = sSQL.Replace("aaaaaa", lID.ToString());
                        sSQL = sSQL.Replace("bbbbbb", lIDDetails.ToString());
                        sSQL = sSQL.Replace("cccccc", iCou.ToString());
                        sSQL = sSQL.Replace("dddddd", sAccID);
                        dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        lID = BaseFunction.ReturnLong(dt.Rows[0][0]) - 1;
                        lIDDetails = BaseFunction.ReturnLong(dt.Rows[0][1]) - iCodeCou;

                        ////获得单据号
                        sSQL = "select * from VoucherHistory with (ROWLOCK) Where CardNumber='0304' AND cSeed = 'aaaaaa'";
                        sSQL = sSQL.Replace("aaaaaa", dLogDate.ToString("yyyyMMdd"));
                        dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        iCode = 0;
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            iCode = BaseFunction.ReturnLong(dt.Rows[0]["cNumber"]) + 1;
                            sSQL = @"
update VoucherHistory set cNumber = aaaaaa where autoid = bbbbbb and CardNumber = '0304'
";
                            sSQL = sSQL.Replace("aaaaaa", iCode.ToString());
                            sSQL = sSQL.Replace("bbbbbb", dt.Rows[0]["AutoId"].ToString().Trim());
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        else
                        {
                            iCode = 1;
                            sSQL = @"
insert into VoucherHistory(CardNumber, cContent, cContentRule, cSeed, cNumber, bEmpty)
values('0304','日期','日','aaaaaa',1,0)
";
                            sSQL = sSQL.Replace("aaaaaa", dLogDate.ToString("yyyyMMdd"));
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        iCode += 1;
                        sCode = iCode.ToString();
                        while (sCode.Length < 4)
                        {
                            sCode = "0" + sCode;
                        }
                        sCode = "TF" + dLogDate.ToString("yyyyMMdd") + sCode;

                        mod = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.TransVouch();
                        mod.cTVCode = sCode;
                        mod.dTVDate = dLogDate;

                        mod.cOWhCode = lookUpEditWarehouseIN.EditValue.ToString().Trim();
                        if (mod.cOWhCode.ToUpper().StartsWith("A"))
                        {
                            mod.cIWhCode = "A61";
                        }
                        if (mod.cOWhCode.ToUpper().StartsWith("B"))
                        {
                            mod.cIWhCode = "B61";
                        }

                        if (mod.cIWhCode == null || mod.cIWhCode.Trim() == "")
                        {
                            throw new Exception("Please set claim warehouse");
                        }

                        mod.cIRdCode = sRdCodeOut;     
                        mod.cORdCode = sRdCodeIn;

                        mod.cIDepCode = sDepCodeIn;
                        mod.cODepCode = sDepCodeOut;

                        mod.cPersonCode = null;
                        mod.cTVMemo = txtMemo.Text.Trim();

                        if (dtRd.Rows[0]["cDefine1"].ToString().Trim() != "")
                        {
                            mod.cDefine1 = dtRd.Rows[0]["cDefine1"].ToString().Trim();
                        }
                        if (dtRd.Rows[0]["cDefine2"].ToString().Trim() != "")
                        {
                            mod.cDefine2 = dtRd.Rows[0]["cDefine2"].ToString().Trim();
                        }
                        if (dtRd.Rows[0]["cDefine3"].ToString().Trim() != "")
                        {
                            mod.cDefine3 = dtRd.Rows[0]["cDefine3"].ToString().Trim();
                        }
                        if (dtRd.Rows[0]["cDefine4"].ToString().Trim() != "")
                        {
                            mod.cDefine4 = BaseFunction.ReturnDate(dtRd.Rows[0]["cDefine4"]);
                        }
                        if (dtRd.Rows[0]["cDefine5"].ToString().Trim() != "")
                        {
                            mod.cDefine5 = BaseFunction.ReturnLong(dtRd.Rows[0]["cDefine5"]);
                        }
                        if (dtRd.Rows[0]["cDefine6"].ToString().Trim() != "")
                        {
                            mod.cDefine6 = BaseFunction.ReturnDate(dtRd.Rows[0]["cDefine6"]);
                        }
                        if (dtRd.Rows[0]["cDefine7"].ToString().Trim() != "")
                        {
                            mod.cDefine7 = BaseFunction.ReturnDecimal(dtRd.Rows[0]["cDefine7"]);
                        }
                        if (dtRd.Rows[0]["cDefine8"].ToString().Trim() != "")
                        {
                            mod.cDefine8 = dtRd.Rows[0]["cDefine8"].ToString().Trim();
                        }
                        if (dtRd.Rows[0]["cDefine9"].ToString().Trim() != "")
                        {
                            mod.cDefine9 = dtRd.Rows[0]["cDefine9"].ToString().Trim();
                        }
                        if (dtRd.Rows[0]["cDefine10"].ToString().Trim() != "")
                        {
                            mod.cDefine10 = dtRd.Rows[0]["cDefine10"].ToString().Trim();
                        }
                        mod.cAccounter = null;
                        mod.iNetLock = 1;
                        lID += 1;
                        mod.ID = lID;
                        mod.VT_ID = 89;
                        mod.cMaker = sUserName;
                        mod.dnmaketime = dLogDate;

                        mod.cVerifyPerson = sUserName;
                        mod.dVerifyDate = dLogDate;
                        mod.cPSPCode = null;
                        mod.cMPoCode = null;
                        mod.iQuantity = 0;
                        mod.bTransFlag = null;
                        if (dtRd.Rows[0]["cDefine11"].ToString().Trim() != "")
                        {
                            mod.cDefine11 = dtRd.Rows[0]["cDefine11"].ToString().Trim();
                        }
                        if (dtRd.Rows[0]["cDefine12"].ToString().Trim() != "")
                        {
                            mod.cDefine12 = dtRd.Rows[0]["cDefine12"].ToString().Trim();
                        }
                        if (dtRd.Rows[0]["cDefine13"].ToString().Trim() != "")
                        {
                            mod.cDefine13 = dtRd.Rows[0]["cDefine13"].ToString().Trim();
                        }
                        if (dtRd.Rows[0]["cDefine14"].ToString().Trim() != "")
                        {
                            mod.cDefine14 = dtRd.Rows[0]["cDefine14"].ToString().Trim();
                        }
                        if (dtRd.Rows[0]["cDefine15"].ToString().Trim() != "")
                        {
                            mod.cDefine15 = BaseFunction.ReturnLong(dtRd.Rows[0]["cDefine5"]);
                        }
                        if (dtRd.Rows[0]["cDefine16"].ToString().Trim() != "")
                        {
                            mod.cDefine16 = BaseFunction.ReturnDecimal(dtRd.Rows[0]["cDefine16"]);
                        }
                        mod.iproorderid = null;
                        mod.cTranRequestCode = null;
                        mod.cVersion = null;
                        mod.BomId = null;
                        mod.cFree1 = null;
                        mod.cFree2 = null;
                        mod.cFree3 = null;
                        mod.cFree4 = null;
                        mod.cFree5 = null;
                        mod.cFree6 = null;
                        mod.cFree7 = null;
                        mod.cFree8 = null;
                        mod.cFree9 = null;
                        mod.cFree10 = null;
                        mod.cAppTVCode = null;
                        mod.csource = "1";
                        mod.itransflag = "正向";
                        mod.cModifyPerson = null;
                        mod.dModifyDate = null;
                        mod.dnmaketime = DateTime.Now;
                        mod.dnmodifytime = null;
                        mod.ireturncount = null;
                        mod.iverifystate = null;
                        mod.iswfcontrolled = 0;
                        mod.csourceguid = null;
                        mod.csysbarcode = "||st12||" + mod.cTVCode;

                        mod.cDefine1 = txtEntryNo.Text.Trim();
                        mod.cCurrentAuditor = null;

                        dalTR = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.TransVouch();
                        sSQL = dalTR.Add(mod);
                        iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        sMCode = sMCode + mod.cTVCode + "\n";

                        iRow = 0;
                        for (int i = 0; i < gridViewPL.RowCount; i++)
                        {
                            if (!BaseFunction.ReturnBool(gridViewPL.GetRowCellValue(i, gridColSelected)))
                                continue;



                            decimal dQty = BaseFunction.ReturnDecimal(gridViewPL.GetRowCellValue(i, gridColQUANTITY));
                            decimal dClaimQty = BaseFunction.ReturnDecimal(gridViewPL.GetRowCellValue(i, gridColClaimQty));
                            if (dClaimQty < 0 || dClaimQty > dQty)
                            {
                                sErr = sErr + "Line " + (i + 1).ToString() + " the claim quantity is wrong\n";
                                continue;
                            }
                            if (dClaimQty == 0)
                                continue;

                            long lRds01Autoid = BaseFunction.ReturnLong(gridViewPL.GetRowCellValue(i, gridColRds01ID));
                            if (lRds01Autoid == 0)
                            {
                                sErr = sErr + "Line " + (i + 1).ToString() + " purchase receipt warrant is not imported\n";
                                continue;
                            }

                            sSQL = @"
select autoid from Rdrecords01 where autoid = aaaaaaaa
";
                            sSQL = sSQL.Replace("aaaaaaaa", lRds01Autoid.ToString());
                            DataTable dtRds01 = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                            if (dtRds01 == null || dtRds01.Rows.Count == 0)
                            {
                                sErr = sErr + "Line " + (i + 1).ToString() + " purchase receipt warrant is not imported\n";
                                continue;
                            }


                            long lTRsID = BaseFunction.ReturnLong(gridViewPL.GetRowCellValue(i, gridColTrIDs));
                            if (lTRsID > 0)
                            {
                                sSQL = @"
select autoid from TransVouchs where autoid = aaaaaaaa
";
                                sSQL = sSQL.Replace("aaaaaaaa", lTRsID.ToString());
                                DataTable dtTRs01 = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                                if (dtTRs01 != null && dtTRs01.Rows.Count > 0)
                                {
                                    sErr = sErr + "Line " + (i + 1).ToString() + " is imported\n";
                                    continue;
                                }
                            }

                            Model.TransVouchs mods = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.TransVouchs();
                            mods.cTVCode = mod.cTVCode;
                            mods.cInvCode = gridViewPL.GetRowCellValue(i, gridColPARTNO).ToString().Trim();
                            mods.iTVNum = null;

                            mods.iTVQuantity = dClaimQty;
                            lIDDetails += 1;
                            mods.autoID = lIDDetails;
                            mods.ID = mod.ID;
                            mods.bCosting = true;

                            iRow += 1;
                            mods.irowno = iRow;
                            mods.coutposcode = null;
                            mods.cinposcode = null;
                            //mods.cTVBatch = gridViewPL.GetRowCellValue(i, gridColcBatch).ToString().Trim();
                            mods.cDefine22 = gridViewPL.GetRowCellValue(i, gridColCONTAINERNO).ToString().Trim();
                            mods.cDefine23 = gridViewPL.GetRowCellValue(i, gridColBOXNO).ToString().Trim();
                            mods.cDefine24 = gridViewPL.GetRowCellValue(i, gridColCASENO).ToString().Trim();
                            mods.cDefine25 = gridViewPL.GetRowCellValue(i, gridColGWKGS).ToString().Trim();
                            mods.cDefine28 = gridViewPL.GetRowCellValue(i, gridColNWKGS).ToString().Trim();

                            mods.cbsysbarcode = "||st12|" + mod.cTVCode + "|" + iRow.ToString();
                            DAL.TransVouchs dalTRs = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.TransVouchs();
                            sSQL = dalTRs.Add(mods);
                            iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            //回写导入中间表 Rdrecords10_Import
                            sSQL = @"
update RdRecords01_Import set TrIDsClaim = AAAAAA,ClaimQty = DDDDDD
WHERE AUTOID = BBBBBB
";
                            sSQL = sSQL.Replace("AAAAAA", mods.autoID.ToString());
                            sSQL = sSQL.Replace("BBBBBB", gridViewPL.GetRowCellValue(i, gridColAutoID).ToString());
                            sSQL = sSQL.Replace("DDDDDD", BaseFunction.ReturnDecimal(gridViewPL.GetRowCellValue(i, gridColClaimQty)).ToString().Trim());
                            int iRet = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }

                        if (iRow > 0)
                        {
                            clsU8 cls = new clsU8();
                            cls.TransVouch_Audit_U8V111(tran, mod.cTVCode, sAccID, sUserName);
                        }
                    }

                    #endregion

                    if (sErr != "")
                    {
                        throw new Exception(sErr);
                    }

                    if (iCount > 0)
                    {
                        tran.Commit();
                        MessageBox.Show("Success：\n" + sMCode);

                        SetTxtNull();
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
                FrmMsgBox frm = new FrmMsgBox();
                frm.richTextBox1.Text = ee.Message;
                frm.ShowDialog();
            }
        }

        private void SetLookup()
        {
            string sSQL = @"
select cWhCode ,cWhName from Warehouse where cWhcode in ('A10','A11','B10','B11') order by cWhCode
";
            DataTable dt = DbHelperSQL.Query(sSQL);
            lookUpEditWarehouseIN.Properties.DataSource = dt;

            sSQL = @"
select cWhCode ,cWhName from Warehouse order by cWhCode
";
            dt = DbHelperSQL.Query(sSQL);
            lookUpEditWarehouseOUT.Properties.DataSource = dt;


        }

        private void SetTxtNull()
        {
            //gridControlIN.DataSource = null;
            gridControlPL.DataSource = null;
            txtCompany.Text = "";
            txtInvoiceNO.Text = "";
            dateEdit1.Text = "";
            txtBL.Text = "";
            dtmBL.Text = "";
            txtEntryNo.Text = "";
            txtCurrency.Text = "";
            chkSelected.Checked = false;
            lsContaineNO.Text = "";
            txtMemo.Text = "";

            lookUpEditWarehouseOUT.EditValue = DBNull.Value;
            lookUpEditWarehouseIN.EditValue = DBNull.Value;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                FrmSEL_ImportTransVouch frm = new FrmSEL_ImportTransVouch();
                frm.StartPosition = FormStartPosition.CenterParent;
                if (frm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                dateEditQuery.DateTime = frm.dtmReturn;
                string sInvoiceNO = frm.sInvoiceNO;
                string sContaineNO = frm.sContainerNO;
                lsContaineNO.Text = sContaineNO;

                GetGrid(sInvoiceNO, sContaineNO);
            }
            catch (Exception ee)
            {
                FrmMsgBox frm = new FrmMsgBox();
                frm.richTextBox1.Text = ee.Message;
                frm.ShowDialog();

                SetTxtNull();
            }
        }

        private void GetGrid(string sInvoiceNO, string sContaineNO)
        {
            string sDateTime = dateEditQuery.DateTime.ToString("yyyy-MM-dd");
            string sSQL = @"
SELECT AutoID, ImportTime, InvoiceNo, Date, Companyname, PONO, PARTNO, DESCRIPTIONENGLISH
	, cast(QUANTITY as decimal(16,2)) as QUANTITY 
	, cast(NW as decimal(16,2)) as NW
	, cast(GW as decimal(16,2)) as GW
	, cast(PRICEPERUNIT as decimal(16,2)) as PRICEPERUNIT, UNIT
	, cast(TOTALPRICE as decimal(16,2)) as TOTALPRICE
    ,cast(0 as decimal(16,2)) as ClaimQty
FROM      PurBillVouchs_Import
where InvoiceNO = 'aaaaaa' 
order by Autoid
";
            sSQL = sSQL.Replace("aaaaaa", sInvoiceNO);
            DataTable dtIN = DbHelperSQL.Query(sSQL);
            if (dtIN != null && dtIN.Rows.Count > 0)
            {
                txtCompany.Text = dtIN.Rows[0]["Companyname"].ToString().Trim();
                txtInvoiceNO.Text = dtIN.Rows[0]["InvoiceNo"].ToString().Trim();
                dateEdit1.DateTime = BaseFunction.ReturnDate(dtIN.Rows[0]["Date"]);
                //gridControlIN.DataSource = dtIN;
                //gridViewIN.BestFitColumns();
            }

            sSQL = @"
SELECT cast(0 as bit) as Selected, a.AutoID, ImportTime, InvoiceNo, Date, Companyname, PONO, CONTAINERNO, PARTNO
	, DESCRIPTIONOFPRODUCTSEN, CASENO
	, BOXNO
	,cast( BOXQTY as int) as BOXQTY
	,cast( QUANTITY as decimal(16,2)) as QUANTITY, UNIT
	, cast(NWKGS as decimal(16,2)) as NWKGS
	,cast( GWKGS as decimal(16,2)) as GWKGS
    ,cast( UnitPrice as decimal(16,2)) as UnitPrice
	, BOXCBM, CONNO, POsID, Rds01ID, BLDate, BLNo
	,b.cPOID as U8PONO
	,c.cCode as U8RDCode
	, a.TrIDs ,d.cTVCode as U8TRCode
    ,a.EntryNO,a.Currency
    ,cast(null as decimal(16,2)) as ClaimQty
FROM      RdRecords01_Import a left join
(
	select distinct a.cPOID,b.ID,b.cInvCode
	from PO_Pomain a inner join PO_Podetails b on a.POID = b.POID
)b on a.POsID = b.ID  and a.PARTNO = b.cInvCode
	LEFT JOIN
(
	select distinct a.cCode,b.autoid
	from Rdrecord01 a inner join rdrecords01 b on a.id = b.id
) c on a.Rds01ID = c.autoid 
	left join 
(
	select distinct a.cTVCode,b.autoid
	from TransVouch a inner join TransVouchs b on a.cTVCode = b.cTVCode 
) d on a.TrIDs = d.autoid
where 1=1 and a.InvoiceNO = 'aaaaaa'
order by a.Autoid
";
            sSQL = sSQL.Replace("aaaaaa", sInvoiceNO);
            if (sContaineNO != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.ContainerNO like '%" + sContaineNO.Trim() + "%'");
            }
            if (radioUnCreated.Checked)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and isnull(d.autoid,-1) = -1");
            }
            if (radioCreated.Checked)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and isnull(d.autoid,-1) <> -1");
            }

            DataTable dtPL = DbHelperSQL.Query(sSQL);
            gridControlPL.DataSource = dtPL;
            if (dtPL != null && dtPL.Rows.Count > 0)
            {
                txtCurrency.Text = dtPL.Rows[0]["Currency"].ToString().Trim();
                txtBL.Text = dtPL.Rows[0]["BLNo"].ToString().Trim();
                dtmBL.DateTime = BaseFunction.ReturnDate(dtPL.Rows[0]["BLDate"]);
                txtEntryNo.Text = dtPL.Rows[0]["EntryNO"].ToString().Trim();
                gridViewPL.BestFitColumns();
            }

            chkSelected.Checked = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetTxtNull();
        }

        private void chkSelected_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridViewPL.RowCount; i++)
                {
                    gridViewPL.SetRowCellValue(i, gridColSelected, chkSelected.Checked);
                }
            }
            catch { }
        }

        private void gridViewPL_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    string s1 = gridViewPL.GetRowCellValue(e.RowHandle, gridColU8TRCode).ToString().Trim();
                    if (s1 != "")
                    {
                        e.Appearance.BackColor = Color.LightYellow;
                    }

                    string s2 = gridViewPL.GetRowCellValue(e.RowHandle, gridColU8RDCode).ToString().Trim();
                    {
                        if (s2 == "")
                        {
                            e.Appearance.BackColor = Color.Tomato;
                        }

                    }

                    if (e.Column == gridColClaimQty)
                    {
                        if (BaseFunction.ReturnDecimal(e.CellValue) > 0)
                        {
                            e.Appearance.BackColor = Color.LightBlue;
                        }
                        if (BaseFunction.ReturnDecimal(e.CellValue) < 0)
                        {
                            e.Appearance.BackColor = Color.Tomato;
                        }
                        if(BaseFunction.ReturnDecimal(e.CellValue) > BaseFunction.ReturnDecimal(gridViewPL.GetRowCellValue(e.RowHandle,gridColQUANTITY)))
                        {
                            e.Appearance.BackColor = Color.Tomato;
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void gridViewPL_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == gridColSelected && e.RowHandle >=0)
                {
                    bool b = BaseFunction.ReturnBool(gridViewPL.GetRowCellValue(e.RowHandle, gridColSelected));
                    if (b)
                    {
                        string s1 = gridViewPL.GetRowCellValue(e.RowHandle, gridColU8TRCode).ToString().Trim();
                        string s2 = gridViewPL.GetRowCellValue(e.RowHandle, gridColU8RDCode).ToString().Trim();
                        if (s1 != "" || s2 == "")
                        {
                            gridViewPL.SetRowCellValue(e.RowHandle, gridColSelected, false);
                        }
                    }
                }

                if (e.Column == gridColClaimQty)
                { 
                    decimal dClaimQty = BaseFunction.ReturnDecimal(e.Value);
                    if(dClaimQty < 0 )
                    {
                        MessageBox.Show("The claim quantity cannot be less than 0");
                    }

                    decimal dQty = BaseFunction.ReturnDecimal(gridViewPL.GetRowCellValue(e.RowHandle,gridColQUANTITY));
                    if(dClaimQty > dQty)
                    {
                        MessageBox.Show("The number of claims cannot be greater than the number of documents");
                    }
                }
            }
            catch { }
        }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            if (txtInvoiceNO.Text.Trim() != "")
            {
                GetGrid(txtInvoiceNO.Text.Trim(), lsContaineNO.Text.Trim());
            }
        }
    }
}
