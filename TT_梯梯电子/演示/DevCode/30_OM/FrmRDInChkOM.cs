using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FrameBaseFunction;
using System.Data.SqlClient;

namespace OM
{
    public partial class FrmRDInChkOM : FrameBaseFunction.Frm列表窗体模板
    {
        bool bCheck = false;

        public FrmRDInChkOM()
        {
            InitializeComponent();
        }

        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "sel":
                        btnSel();
                        break;
                    case "unlock":
                        btnCheck();
                        break;
                    case "save":
                        btnSave();
                        break;
                    case "undo":
                        btnDel();
                        break;
                    case "audit":
                        btnAudit();
                        break;
                    case "unaudit":
                        btnUnAudit();
                        break;
                    case "export":
                        btnExport();
                        break;
                    case "alter":
                        btnPrint();
                        break;
                    case "open":
                        btnOpen();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(sBtnText + " 失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOpen()
        {
            if (!radioAudit.Checked)
            {
                throw new Exception("请选择已审核单据生成发票");
            }

            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            try
            {
                string sErr = "";
                int iCount = 0;

                DateTime dLogDate = BaseFunction.ReturnDate(FrameBaseFunction.ClsBaseDataInfo.sLogDate);
                SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    string sSQL = "select getdate()";
                    DateTime dNow = BaseFunction.ReturnDate(ClsSqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                    DateTime dNowDate = BaseFunction.ReturnDate(dNow.ToString("yyyy-MM-dd"));

                    sSQL = @"
select isnull(bflag_ST,0) as bflag from @u8.GL_mend where iYPeriod = 'aaaaaa'
";
                    sSQL = sSQL.Replace("aaaaaa", dLogDate.ToString("yyyyMM"));
                    int i结账 = BaseFunction.ReturnInt(ClsSqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                    if (i结账 == 1)
                    {
                        throw new Exception("登陆月份已结账");
                    }

                    long lID = -1;
                    long lIDDetails = -1;
                    sSQL = @"
declare @p5 int
set @p5=aaaaaa
declare @p6 int
set @p6=bbbbbb
exec @u8.sp_GetId N'00',N'dddddd',N'PURBILL',1,@p5 output,@p6 output,default
select @p5, @p6
";
                    sSQL = sSQL.Replace("aaaaaa", lID.ToString());
                    sSQL = sSQL.Replace("bbbbbb", lIDDetails.ToString());
                    sSQL = sSQL.Replace("dddddd", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3));
                    DataTable dt = ClsSqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    lID = BaseFunction.ReturnLong(dt.Rows[0][0]) - 1;
                    lIDDetails = BaseFunction.ReturnLong(dt.Rows[0][1]) - 1;

                    ////获得单据号
                    sSQL = "select * from @u8.VoucherHistory with (ROWLOCK) Where CardNumber='25' AND cSeed = 'aaaaaa'";
                    sSQL = sSQL.Replace("aaaaaa", dLogDate.ToString("yyyyMM"));
                    dt = ClsSqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    long lCode = 0;
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        lCode = BaseFunction.ReturnLong(dt.Rows[0]["cNumber"]);
                    }
                    else
                    {
                        lCode = 0;
                    }
                    lCode += 1;

                    string sCode = lCode.ToString();
                    while (sCode.Length < 5)
                    {
                        sCode = "0" + sCode;
                    }
                    sCode = "PSI" + dLogDate.ToString("yyMM") + sCode;

                    lID += 1;
                    OM.Model.PurBillVouch model = new OM.Model.PurBillVouch();
                    model.PBVID = lID;
                    model.cPBVBillType = "01";
                    model.cPBVCode = sCode;
                    model.cPTCode = "02";
                    model.dPBVDate = dLogDate;
                    model.cVenCode = txtVenCode.Text.Trim();
                    model.cUnitCode = txtVenCode.Text.Trim();
                    model.cDepCode = FrameBaseFunction.ClsBaseDataInfo.sDepCode;

                    sSQL = @"
select *
from _UserInfo a inner join @u8.Person b on a.[vchrName] = b.cPersonName
where a.vchrUid = 'aaaaaa'
";
                    sSQL = sSQL.Replace("aaaaaa", sUid);
                    DataTable dtPerson = ClsSqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtPerson == null || dtPerson.Rows.Count == 0)
                    {
                        throw new Exception("请确定登陆人员是业务员");
                    }

                    model.cPersonCode = dtPerson.Rows[0]["cPersonCode"].ToString().Trim();
                    model.cexch_name = "人民币";
                    model.cExchRate = 1;
                    model.iPBVTaxRate = 17;
                    model.cBusType = "委外加工";
                    model.cPBVMaker = sUserName;
                    model.bNegative = false;
                    model.bOriginal = false;
                    model.bFirst = false;
                    model.iNetLock = 0;
                    model.iVTid = 131386;
                    model.cSource = "委外";
                    model.iDiscountTaxType = 0;
                    model.iflowid = 0;
                    model.iPrintCount = 0;
                    model.cmaketime = dNow;
                    model.bMerger = 0;

                    DAL.PurBillVouch dal = new OM.DAL.PurBillVouch();
                    sSQL = dal.Add(model);
                    ClsSqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    bool b单据 = false;
                    int iRowNO = 0;
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (gridView1.GetRowCellValue(i, gridColbChoose).ToString().Trim() != "√")
                            continue;

                        long lRdsID = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColRdsID));

                        sSQL = @"
select rds.iquantity as iQty,rds.iNum as iNNum,rds.iSumBillQuantity,b.*
    
from @u8.OM_MOMain a inner join @u8.OM_MODetails b on a.MOID = b.MOID
	inner join @u8.rdrecords01 rds on rds.iOMoDID = b.MODetailsID
where rds.AutoID  = aaaaaa
";
                        sSQL = sSQL.Replace("aaaaaa", lRdsID.ToString());
                        DataTable dtRd = ClsSqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        decimal d开票 = BaseFunction.ReturnDecimal(dtRd.Rows[0]["iSumBillQuantity"]);
                        if (d开票 > 0)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "已开票\n";
                            continue;
                        }

                        sSQL = @"
select * from @u8.[fitemss00] where citemcode = 'aaaaaa'
";
                        sSQL = sSQL.Replace("aaaaaa", dtRd.Rows[0]["cItemCode"].ToString().Trim());
                        DataTable dtItem = ClsSqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        Model.PurBillVouchs mods = new Model.PurBillVouchs();
                        lIDDetails += 1;
                        mods.ID = lIDDetails;
                        mods.PBVID = model.PBVID;
                        mods.cInvCode = gridView1.GetRowCellValue(i, gridColcInvCode).ToString().Trim();
                        mods.bExBill = false;
                        mods.iPBVQuantity = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColiQuantity));
                        mods.iNum = BaseFunction.ReturnDecimal(dtRd.Rows[0]["iNNum"]);

                        decimal d含税单价_审核 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColiPrice));
                        decimal d含税单价_入库 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColprice));

                        decimal d税率 = BaseFunction.ReturnDecimal(dtRd.Rows[0]["iPerTaxRate"]);
                
                        mods.iOriTaxCost = BaseFunction.ReturnDecimal(d含税单价_审核);                      //含税单价
                        mods.iOriSum = BaseFunction.ReturnDecimal(mods.iOriTaxCost * mods.iPBVQuantity, 2);  //含税金额
                        mods.iOriMoney = BaseFunction.ReturnDecimal(mods.iOriSum / (decimal)(1 + d税率/100), 2);       //不含税金额
                        mods.iOriCost = BaseFunction.ReturnDecimal(mods.iOriMoney / mods.iPBVQuantity, 3);      //不含税单价
                        mods.iOriTaxPrice = mods.iOriSum - mods.iOriMoney;

                        mods.iCost = mods.iOriCost;
                        mods.iMoney = mods.iOriMoney;
                        mods.iSum = mods.iOriSum;
                        mods.iTaxPrice = mods.iOriTaxPrice;

                        mods.iOriTotal = 0;
                        mods.iTotal = 0;
                        mods.iTaxRate = 17;
                        mods.iPOsID = ReturnObjectToInt(dtRd.Rows[0]["MODetailsID"]);
                        mods.cItemCode = dtRd.Rows[0]["cItemCode"].ToString().Trim();
                        if (dtItem != null && dtItem.Rows.Count > 0)
                        {
                            mods.cItemName = dtItem.Rows[0]["cItemName"].ToString().Trim();
                        }
                        mods.cItem_class = "00";
                        mods.RdsId = lRdsID;
                        mods.UpSoType = "rd";
                        mods.bCosting = false;
                        mods.bTaxCost = true;
                        mods.iinvexchrate = 0;
                        mods.brettax = 0;

                        iRowNO += 1;
                        mods.ivouchrowno = iRowNO;
                        mods.bgift = 0;

                        DAL.PurBillVouchs dals = new DAL.PurBillVouchs();
                        sSQL = dals.Add(mods);
                        ClsSqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        sSQL = "update @u8.rdrecords01 set iSumBillQuantity = isnull(iSumBillQuantity,0) + " + mods.iPBVQuantity + " where autoid = " + lRdsID;
                        ClsSqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                        sSQL = @"
update @u8.po_podetails set iInvQty = isnull(iInvQty,0) + aaaaaa,iInvNum = isnull(iInvNum,0) + bbbbbb,iInvMoney = isnull(iInvMoney,0) + cccccc,iNatInvMoney = isnull(iNatInvMoney,0) + dddddd
where ID = eeeeee
";
                        sSQL = sSQL.Replace("aaaaaa", mods.iPBVQuantity.ToString());
                        sSQL = sSQL.Replace("bbbbbb", mods.iNum.ToString());
                        sSQL = sSQL.Replace("cccccc", mods.iMoney.ToString());
                        sSQL = sSQL.Replace("dddddd", mods.iMoney.ToString());
                        sSQL = sSQL.Replace("eeeeee", mods.iPOsID.ToString());
                        ClsSqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                        //sSQL = "update [UFDLImport].[dbo].Records_Import set bAudit = 2 where RDid = aaaaaa";
                        //sSQL = sSQL.Replace("aaaaaa", lRdsID.ToString());
                        //ClsSqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        b单据 = true;
                    }

                    if (!b单据)
                    {
                        throw new Exception("没有可执行数据");
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
                    sSQL = "update UFSystem..UA_Identity set iFatherId = " + lID.ToString() + ",iChildId = " + lIDDetails + " where cAcc_Id = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3) + "' and cVouchType = 'PURBILL'";
                    ClsSqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = @"
            if exists(select * from @u8.VoucherHistory where CardNumber='25' AND cSeed = 'bbbbbb')
            	update @u8.VoucherHistory set cNumber = aaaaaa  where CardNumber = '25' AND cSeed = 'bbbbbb'
            else
            	insert into @u8.VoucherHistory(CardNumber,cContent,cContentRule,cSeed,cNumber,bEmpty)
            	values('25','单据日期','月','bbbbbb','aaaaaa',0)
                    ";

                    sSQL = sSQL.Replace("aaaaaa", lCode.ToString());
                    sSQL = sSQL.Replace("bbbbbb", dLogDate.ToString("yyyyMM"));
                    ClsSqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                    tran.Commit();

                    GetGrid();


                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        private void btnDel()
        {
            if (radioAudit.Checked)
            {
                MessageBox.Show("已审核单据不能撤销");
                return;
            }

            string sSQL = "";
            ArrayList aList = new ArrayList();
            DataTable dt = (DataTable)gridControl1.DataSource;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["bChoose"].ToString().Trim() == "√")
                {
                    sSQL = "update UFDLImport..Records_Import set Saver = null " +
                          " where RDId = " + dt.Rows[i]["autoid"].ToString().Trim() + " and accid = 200 and accyear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4);
                    aList.Add(sSQL);
                }
            }

            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("撤销成功！");
                GetGrid();
            }
        }

        private void btnPrint()
        {
            try
            {
                RepRDInChk rep = new RepRDInChk();

                try
                {
                    gridView1.FocusedRowHandle -= 1;
                }
                catch { }

                decimal d1 = 0;
                decimal d2 = 0;

                DataTable dt = (DataTable)gridControl1.DataSource;
                int iRow = 0;
                if (dt.Rows.Count > 0)
                {
                    DataTable dtDetail = rep.dataSet1.Tables["dtDetail"];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["bChoose"].ToString().Trim() == "√")
                        {
                            iRow += 1;
                            DataRow dr = dtDetail.NewRow();
                            dr["Column1"] = dt.Rows[i]["cPOID"];
                            dr["Column2"] = dt.Rows[i]["cCode"];
                            dr["Column3"] = Convert.ToDateTime(dt.Rows[i]["dDate"]).ToString("yyyy-MM-dd");
                            dr["Column4"] = dt.Rows[i]["cInvCode"];
                            dr["Column5"] = dt.Rows[i]["cInvName"];
                            dr["Column6"] = dt.Rows[i]["cInvStd"];
                            dr["Column7"] = dt.Rows[i]["iPrice"];

                            if (dt.Rows[i]["Qty"].ToString().Trim() != "")
                            {
                                dr["Column8"] = decimal.Round( Convert.ToDecimal(dt.Rows[i]["Qty"]),6);
                                d1 = d1 + decimal.Round(Convert.ToDecimal(dt.Rows[i]["Qty"]), 6);
                            }
                            if (dt.Rows[i]["iArrSum"].ToString().Trim() != "")
                            {
                                dr["Column9"] = decimal.Round( Convert.ToDecimal(dt.Rows[i]["iArrSum"]),6);
                                d2 = d2 + decimal.Round(Convert.ToDecimal(dt.Rows[i]["iArrSum"]), 6);
                            }

                            dtDetail.Rows.Add(dr);
                        }
                    }

                    if (dtDetail.Rows.Count < 1)
                    {
                        MessageBox.Show("请选择需要打印的数据！");
                        return;
                    }

                    DataTable dtHead = rep.dataSet1.Tables["dtHead"];
                    DataRow dRowTe = dtHead.NewRow();
                    dRowTe["Column1"] = "对账日期： " + dateEdit1.DateTime.ToString("yyyy-MM-dd") + " ---- " + dateEdit2.DateTime.ToString("yyyy-MM-dd");
                    dRowTe["Column2"] = "厂商：" + txtVenName.Text.Trim();
                    dRowTe["Column3"] = "联系人：";
                    dRowTe["Column4"] = "电话：";
                    dRowTe["Column5"] = "审核：";
                    dRowTe["Column6"] = d1;
                    dRowTe["Column7"] = d2;
                    dtHead.Rows.Add(dRowTe);

                    rep.ShowPreview();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载打印失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport()
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
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
                MessageBox.Show(ee.Message);
            }
        }

        private void btnSel()
        {
            try
            {
                GetGrid();

                for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                {
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "unlock")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = false;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "save")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = true;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "audit")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = false;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "unaudit")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = false;
                    }
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show("获得列表失败！  " + ee.Message);
            }
        }

        private void btnCheck()
        {
            gridColprice.Visible = true;
            gridColiQuantity.Visible = true;
            gridColiSum.Visible = true;

            gridColiPrice.OptionsColumn.AllowEdit = false;
            gridColQty.OptionsColumn.AllowEdit = false;

            bCheck = true;

            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                decimal d1 = 0;
                decimal d2 = 0;
                decimal d3 = 0;
                decimal d4 = 0;
                decimal d5 = 0;
                decimal d6 = 0;
                if (gridView1.GetRowCellValue(i, gridColprice).ToString() != "")
                    d1 = decimal.Round(Convert.ToDecimal(gridView1.GetRowCellValue(i, gridColprice)),6);
                if (gridView1.GetRowCellValue(i, gridColiPrice).ToString() != "")
                    d2 = decimal.Round(Convert.ToDecimal(gridView1.GetRowCellValue(i, gridColiPrice)),6);
                if (gridView1.GetRowCellValue(i, gridColiQuantity).ToString() != "")
                    d3 = decimal.Round(Convert.ToDecimal(gridView1.GetRowCellValue(i, gridColiQuantity)),6);
                if (gridView1.GetRowCellValue(i, gridColQty).ToString() != "")
                    d4 = decimal.Round(Convert.ToDecimal(gridView1.GetRowCellValue(i, gridColQty)),6);
                if (gridView1.GetRowCellValue(i, gridColiSum).ToString() != "")
                    d5 = decimal.Round(Convert.ToDecimal(gridView1.GetRowCellValue(i, gridColiSum)),6);
                if (gridView1.GetRowCellValue(i, gridColiArrSum).ToString() != "")
                    d6 = decimal.Round(Convert.ToDecimal(gridView1.GetRowCellValue(i, gridColiArrSum)), 6);

                if (d1 == d2 && d3 == d4 && d5 == d6 && d5 != 0)
                {
                    gridView1.SetRowCellValue(i, gridColbChoose, "√");
                }
                else
                {
                    gridView1.SetRowCellValue(i, gridColbChoose, "");
                }
            }
            
        }

        private void btnUnAudit()
        {
            if (!radioAudit.Checked)
            {
                MessageBox.Show("请先选中已审核");
                return;
            }

            string sSQL = "";
            ArrayList aList = new ArrayList();
            DataTable dt = (DataTable)gridControl1.DataSource;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["bChoose"].ToString().Trim() == "√")
                {
                    sSQL = "update UFDLImport..Records_Import set bAudit =0 " +
                          " where RDId = " + dt.Rows[i]["autoid"].ToString().Trim() + " and accid = 200 and accyear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4);
                    aList.Add(sSQL);
                }
            }

            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("弃审成功！");
                GetGrid();
            }
        }

        private void btnAudit()
        {
            if (!bCheck)
            {
                MessageBox.Show("请先点击查看按钮，核查数据");
                return;
            }

            string sErr = "";
            string sSQL = "";
            ArrayList aList = new ArrayList();
            DataTable dt = (DataTable)gridControl1.DataSource;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["bChoose"].ToString().Trim() == "√")
                {
                    decimal d数量 = BaseFunction.ReturnDecimal(dt.Rows[i]["iQuantity"]);
                    decimal d送货数量 = BaseFunction.ReturnDecimal(dt.Rows[i]["iQuantity"]);
                    if (d数量 != d送货数量)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "数量不一致\n";
                    }

                    decimal d单价 = BaseFunction.ReturnDecimal(dt.Rows[i]["price"]);
                    decimal d送货单价 = BaseFunction.ReturnDecimal(dt.Rows[i]["iprice"]);
                    if (d单价 != d送货单价)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "单价不一致\n";
                    }

                    sSQL = "update UFDLImport..Records_Import set bAudit =1 " +
                           " where RDId = " + dt.Rows[i]["autoid"].ToString().Trim() + " and accid = 200 and accyear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4);
                    aList.Add(sSQL);
                }
            }

            if (sErr != "")
            {
                DialogResult d = MsgBox("提示", sErr);
                if (d != DialogResult.OK)
                {
                    throw new Exception("取消操作");
                }
            }

            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("审核成功！");
                GetGrid();
            }
        }

        private void btnSave()
        {
            bCheck = false;

            ArrayList aList = new ArrayList();
            string sSQL = "";

            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            string sErr = "";
            DataTable dt = (DataTable)gridControl1.DataSource;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["bChoose"].ToString().Trim() == "√")
                {
                    decimal d1 = 0;
                    if (dt.Rows[i]["Qty"].ToString().Trim() != "")
                    {
                        d1 = decimal.Round(Convert.ToDecimal(dt.Rows[i]["Qty"]), 6);
                    }
                    else
                    {
                        sErr = sErr + "第" + (i + 1) + "行送货数量不能为空\n";
                        continue;
                    }
                    decimal d2 = 0;
                    if (dt.Rows[i]["iPrice"].ToString().Trim() != "")
                    {
                        d2 = decimal.Round(Convert.ToDecimal(dt.Rows[i]["iPrice"]), 6);
                    }
                    else
                    {
                        sErr = sErr + "第" + (i + 1) + "行送货单价不能为空\n";
                        continue;
                    }

                    sSQL = " if exists(select * from UFDLImport..Records_Import where accid = 200 and accyear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + " and rdid = " + dt.Rows[i]["autoid"].ToString().Trim() + ") " +
                                "    update UFDLImport..Records_Import set Saver='" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',qty = " + d1 + ",price = " + d2 + " where accid = 200 and accyear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + " and rdid = " + dt.Rows[i]["autoid"].ToString().Trim() + " " +
                             "else " +
                                "    insert into UFDLImport..Records_Import(RDId,accid,accyear,qty,price,bAudit,Saver) " +
                                "    values(" + dt.Rows[i]["autoid"].ToString().Trim() + ",200," + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "," + d1 + "," + d2 + ",0,'" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "') ";
                    aList.Add(sSQL);

                    decimal d = ReturnObjectToDecimal(gridView1.GetRowCellDisplayText(i, gridColiInvWeight), 6);
                    if (d > 0)
                    {
                        sSQL = "update @u8.Inventory set iInvWeight = " + d + " where cInvCode = '" + gridView1.GetRowCellValue(i, gridColcInvCode).ToString().Trim() + "'";
                        aList.Add(sSQL);
                    }
                }
            }

            if (sErr.Trim() != "")
            {
                FrmMsgBox fMsgBos = new FrmMsgBox();
                fMsgBos.Text = "保存";
                fMsgBos.richTextBox1.Text = sErr;
                fMsgBos.ShowDialog();
            }
            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("保存" + aList.Count + "条数据成功！");
                GetGrid();
            }
        }

        private void FrmRDInChkOM_Load(object sender, EventArgs e)
        {
            try
            {
                chkDate.Checked = false;
                base.SetConEnable(true);

                dateEdit1.DateTime = Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).AddMonths(-1);
                dateEdit2.DateTime = Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate);

                string sSQL = "select cCode as iID,cCode as iText from @u8.OM_MOMain where 1=1 order by cCode";
                lookUpEditOrder1.Properties.DataSource = clsGetSQL.GetLookUpEdit(sSQL);
                lookUpEditOrder2.Properties.DataSource = lookUpEditOrder1.Properties.DataSource;

                sSQL = "select distinct cCode as iID,cCode as iText from @u8.rdrecord01 where cBusType = '委外加工' AND csource = '委外订单' order by cCode";
                lookUpEditRDIn1.Properties.DataSource = clsGetSQL.GetLookUpEdit(sSQL);
                lookUpEditRDIn2.Properties.DataSource = lookUpEditRDIn1.Properties.DataSource;

                bCheck = false;

                for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                {
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "unlock")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = false;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "save")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = true;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "audit")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = false;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "unaudit")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = false;
                    }
                }

                string sVend = GetUidVend();
                if (sVend == "all")
                {
                    txtVenCode.Enabled = true;
                }
                else
                {
                    txtVenCode.Text = sVend;
                    txtVenCode.Enabled = false;
                    txtVenCode_Leave(null, null);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败！\n\t原因：" + ee.Message);
            }
        }

        /// <summary>
        /// 获得当前帐号对应供应商
        /// </summary>
        /// <returns></returns>
        private string GetUidVend()
        {
            try
            {
                string s = "all";

                if (FrameBaseFunction.ClsBaseDataInfo.sUid.ToLower() == "admin")
                {
                    return s;
                }

                string sSQL = "select * from UFDLImport.._vendUid where uid = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "' and accid =200 and accyear=" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + " ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    s = dt.Rows[0]["vendCode"].ToString().Trim();
                }

                if (s == string.Empty)
                {
                    s = "all";
                }

                return s;
            }
            catch (Exception ee)
            {
                throw new Exception("获得帐号供应商信息失败！\n\t原因：" + ee.Message);
            }
        }

        private void GetGrid()
        {
            if (txtVenCode.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请选择供应商！");
                return;
            }

            bCheck = false;

            string sSQL = @"
select '' as bChoose,i.iInvWeight,rs.cbarvcode,CONVERT(varchar(100), r.dDate, 111)  as dDate,autoid,rs.iPOsID,rs.cPOID,r.cCode,rs.cInvCode,i.cInvName,i.cInvStd,cast(os.iTaxPrice as DECIMAL(16,6)) as price, cast(rs.iQuantity as DECIMAL(16,6)) as iQuantity
    ,cast(v.Price as DECIMAL(16,6)) as iVendPrice,cast(rI.qty as DECIMAL(16,6)) as Qty, cast(rI.price as DECIMAL(16,6)) as iPrice, rI.bAudit as bAudit 
    ,iSum =  cast(os.iTaxPrice * rs.iQuantity  as DECIMAL(16,6)),iArrSum =cast( rI.qty * rI.price as DECIMAL(16,6)),iInvQTY,iInvNum,iInvMoney,rs.iSQuantity,rs.iQuantity-rs.iSQuantity as iQQty  
    ,cUnit.cComUnitName
from @u8.rdrecord01 r left join @u8.rdrecords01 rs on r.id = rs.id 
    left join @u8.Inventory i on i.cinvcode = rs.cInvCode 
    left join @u8.ComputationUnit cUnit on cUnit.cComunitCode = i.cComunitCode 
    left join @u8.OM_MODetails os on os.MODetailsID = rs.iOMoDID left join @u8.OM_MOMain o on o.moid = os.moid	
    left join UFDLImport..VendPrice v on v.Vend = r.cVenCode and v.cInvCode = rs.cInvcode and v.Type = 1  and v.accid = 200 and v.accyear = aaaaaa
    left join UFDLImport..Records_Import rI on rI.RDId = rs.autoid and rI.accid =200 and rI.accyear = aaaaaa
where r.cVenCode = 'bbbbbb' and r.cbustype = '委外加工'   
";

            sSQL = sSQL.Replace("aaaaaa", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4));
            sSQL = sSQL.Replace("bbbbbb", txtVenCode.Text.ToString().Trim());

            if (!chkiInvMoney.Checked)
            {
                sSQL = sSQL + " and ((rs.iQuantity > isnull(rs.iSQuantity,0) and isnull(bredvouch,0) = 0 ) or (rs.iQuantity < isnull(rs.iSQuantity,0) and isnull(bredvouch,0) = 1 )) ";
          
            }
         
            if (lookUpEditOrder1.Text.Trim() != "")
            {
                sSQL = sSQL + " and o.cCode >= '" + lookUpEditOrder1.Text.Trim() + "' ";
            }
            if (lookUpEditOrder2.Text.Trim() != "")
            {
                sSQL = sSQL + " and o.cCode <= '" + lookUpEditOrder2.Text.Trim() + "' ";
            }

            if (lookUpEditRDIn1.Text.Trim() != "")
            {
                sSQL = sSQL + " and r.cCode >= '" + lookUpEditRDIn1.Text.Trim() + "' ";
            }
            if (lookUpEditRDIn2.Text.Trim() != "")
            {
                sSQL = sSQL + " and r.cCode <= '" + lookUpEditRDIn2.Text.Trim() + "' ";
            }
            if (radioAudit.Checked)
            {
                sSQL = sSQL + " and isnull(rI.bAudit,0) = 1 and isnull(rs.iSumBillQuantity,0) = 0 ";
            }
            if (radioInvoice.Checked)
            {
                sSQL = sSQL + " and isnull(rs.iSumBillQuantity,0) <> 0  ";
            }

            if (radioUnSure.Checked)
            {
                sSQL = sSQL + " and isnull(rI.bAudit,0) = 0 and Saver is null  ";
            }
            if (radioEnSure.Checked)
            {
                sSQL = sSQL + " and isnull(rI.bAudit,0) = 0  and Saver is not null  ";
            }

            if (chkDate.Checked)
            {
                sSQL = sSQL + " and r.dDate >='" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "' and r.dDate<= '" + dateEdit2.DateTime.ToString("yyyy-MM-dd") + "' ";
            }

            sSQL = sSQL + " order by rs.cbarvcode,r.cCode,rs.autoid";

            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            
            gridControl1.DataSource = dt;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.RowCount < 1)
                    return;
                int iRow = 1;
                if (gridView1.RowCount == 1)
                    iRow = 0;
                else
                    iRow = gridView1.FocusedRowHandle;

                if (gridView1.GetRowCellValue(iRow, gridColbChoose).ToString().Trim() == "")
                {
                    gridView1.SetFocusedRowCellValue(gridColbChoose, "√");
                }
                else
                {
                    gridView1.SetFocusedRowCellValue(gridColbChoose, "");
                    return;
                }
            }
            catch
            { }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    if (gridView1.GetRowCellValue(e.RowHandle, gridColbChoose).ToString().Trim() == "√")
                    {
                        if (bCheck)
                        {
                            decimal d1 = 0;
                            decimal d2 = 0;
                            decimal d3 = 0;
                            decimal d4 = 0;
                            decimal d5 = 0;
                            decimal d6 = 0;
                            if (gridView1.GetRowCellValue(e.RowHandle, gridColprice).ToString() != "")
                                d1 = decimal.Round(Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColprice)), 6);
                            if (gridView1.GetRowCellValue(e.RowHandle, gridColiPrice).ToString() != "")
                                d2 = decimal.Round(Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColiPrice)), 6);
                            if (gridView1.GetRowCellValue(e.RowHandle, gridColiQuantity).ToString() != "")
                                d3 = decimal.Round(Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColiQuantity)), 6);
                            if (gridView1.GetRowCellValue(e.RowHandle, gridColQty).ToString() != "")
                                d4 = decimal.Round(Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColQty)), 6);
                            if (gridView1.GetRowCellValue(e.RowHandle, gridColiSum).ToString() != "")
                                d5 = decimal.Round(Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColiSum)), 6);
                            if (gridView1.GetRowCellValue(e.RowHandle, gridColiArrSum).ToString() != "")
                                d6 = decimal.Round(Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColiArrSum)), 6);

                            if (d1 == d2 && d3 == d4 && d5 == d6 && d5 != 0)
                            {
                                e.Appearance.BackColor = Color.MediumSeaGreen;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.Tomato;
                            }
                        }
                        else
                        {
                            e.Appearance.BackColor = Color.MediumSeaGreen;
                        }
                    }
                }
            }
            catch
            { }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAll.Checked)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                        gridView1.SetRowCellValue(i, gridColbChoose, "√");
                }
                if (!chkAll.Checked)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                        gridView1.SetRowCellValue(i, gridColbChoose, "");
                }

            }
            catch
            { }
        }

        private void lookUpEditOrder1_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditOrder2.EditValue = lookUpEditOrder1.EditValue;
        }

        private void lookUpEditRDIn1_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditRDIn2.EditValue = lookUpEditRDIn1.EditValue;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            { 
                int iRow = 0;

                if(gridView1.RowCount >0)
                {
                    iRow = gridView1.FocusedRowHandle;
                }
                if (e.Column == gridView1.Columns["Qty"])
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["bChoose"], "√");
                }
                if (e.Column == gridView1.Columns["Qty"] && gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["iVendPrice"]).ToString().Trim() != string.Empty)
                {
                    //iVendPrice
                    gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["iPrice"], gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["iVendPrice"]).ToString().Trim());
                }

                if (e.Column != gridView1.Columns["iArrSum"])
                {
                    if (gridView1.GetRowCellValue(iRow, gridView1.Columns["iPrice"]).ToString().Trim() != string.Empty && gridView1.GetRowCellValue(iRow, gridView1.Columns["Qty"]).ToString().Trim() != string.Empty)
                    {
                        gridView1.SetRowCellValue(iRow, gridView1.Columns["iArrSum"], Convert.ToDecimal(gridView1.GetRowCellValue(iRow, gridView1.Columns["iPrice"])) * Convert.ToDecimal(gridView1.GetRowCellValue(iRow, gridView1.Columns["Qty"])));
                    }
                }
                
            }
            catch 
            {

            }
        }

        private void txtVenCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmVenInfo fVen = new FrmVenInfo(txtVenCode.Text.Trim());
            if (DialogResult.OK == fVen.ShowDialog())
            {
                txtVenCode.Text = fVen.sVenCode;
                txtVenName.Text = fVen.sVenName;
            }
        }

        private DataTable GetVendor(string sVenCode)
        {
            try
            {
                string sSQL = "select cVenCode as iID,cVenName as iText from @u8.Vendor where cVenCode = '" + sVenCode + "' order by cVenCode";
                DataTable dt = clsGetSQL.GetLookUpEdit(sSQL);
                return dt;
            }
            catch
            {
                throw new Exception("获得供应商信息失败！");
            }
        }

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDate.Checked)
            {
                dateEdit1.Enabled = true;
                dateEdit2.Enabled = true;
            }
            else
            {
                dateEdit1.Enabled = false;
                dateEdit2.Enabled = false;
            }
        }

        private void radioUnSure_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioUnSure.Checked)
                {
                    GetGrid();

                    gridView1.Columns["iPrice"].OptionsColumn.AllowEdit = true;
                    gridView1.Columns["Qty"].OptionsColumn.AllowEdit = true;

                    for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                    {
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "unlock")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = false;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "save")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = true;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "audit")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = false;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "unaudit")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = false;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "undo")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = false;
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得列表信息失败！\n\t原因：" + ee.Message);
            }
        }

        private void radioEnSure_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioEnSure.Checked)
                {
                    GetGrid();

                    gridView1.Columns["iPrice"].OptionsColumn.AllowEdit = true;
                    gridView1.Columns["Qty"].OptionsColumn.AllowEdit = true;

                    for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                    {
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "unlock")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = true;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "save")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = true;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "audit")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = true;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "unaudit")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = false;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "undo")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得列表信息失败！\n\t原因：" + ee.Message);
            }
        }

        private void radioAudit_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioAudit.Checked)
                {
                    GetGrid();

                    gridView1.Columns["iPrice"].OptionsColumn.AllowEdit = false;
                    gridView1.Columns["Qty"].OptionsColumn.AllowEdit = false;

                    for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                    {
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "unlock")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = false;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "save")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = false;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "audit")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = false;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "unaudit")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = true;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "undo")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = false;
                        }
                    }

                    gridView1.Columns["iPrice"].OptionsColumn.AllowEdit = false;
                    gridView1.Columns["Qty"].OptionsColumn.AllowEdit = false;
                }
                else
                {
                    gridView1.Columns["iPrice"].OptionsColumn.AllowEdit = true;
                    gridView1.Columns["Qty"].OptionsColumn.AllowEdit = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得列表信息失败！\n\t原因：" + ee.Message);
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void txtVenCode_Leave(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = GetVendor(txtVenCode.Text.Trim());
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtVenName.Text = dt.Rows[0]["iText"].ToString().Trim();
                    GetGrid();
                }
                else
                {
                    txtVenCode.Text = "";
                    txtVenName.Text = "";
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得供应商信息失败！   " + ee.Message);
            }
        }

        private void btn保存净重_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                ArrayList aList = new ArrayList();
                string sSQL = "";

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    decimal d = ReturnObjectToDecimal(gridView1.GetRowCellDisplayText(i, gridColiInvWeight),6);
                    if (d > 0)
                    {
                        sSQL = "update @u8.Inventory set iInvWeight = " + d + " where cInvCode = '" + gridView1.GetRowCellValue(i, gridColcInvCode).ToString().Trim() + "'";
                        aList.Add(sSQL);
                    }
                }
                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("保存成功");
                }
                else
                {
                    MessageBox.Show("没有需要保存的数据");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("保存失败:" + ee.Message);
            }
        }

        private void radioInvoice_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioInvoice.Checked)
                {
                    GetGrid();

                    gridView1.Columns["iPrice"].OptionsColumn.AllowEdit = false;
                    gridView1.Columns["Qty"].OptionsColumn.AllowEdit = false;

                    for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                    {
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "check")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = false;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "save")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = false;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "audit")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = false;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "unaudit")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = false;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "del")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = false;
                        }
                    }
                    gridView1.Columns["iPrice"].OptionsColumn.AllowEdit = false;
                    gridView1.Columns["Qty"].OptionsColumn.AllowEdit = false;
                }
                else
                {
                    gridView1.Columns["iPrice"].OptionsColumn.AllowEdit = true;
                    gridView1.Columns["Qty"].OptionsColumn.AllowEdit = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得列表信息失败！\n\t原因：" + ee.Message);
            }
        }
    }
}