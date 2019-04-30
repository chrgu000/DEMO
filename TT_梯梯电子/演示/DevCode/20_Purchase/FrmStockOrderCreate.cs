using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FrameBaseFunction;

namespace Purchase
{
    public partial class FrmStockOrderCreate : FrameBaseFunction.Frm列表窗体模板
    {
        DataTable dtPriceList;

        public FrmStockOrderCreate()
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
                        btnGet();
                        break;
                    case "save":
                        btnImport();
                        break;
                    case "export":
                        btnExport();
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

        private void btnExport()
        {
            try
            {
                try
                {
                    gridView2.FocusedRowHandle -= 1;
                }
                catch { }

                SaveFileDialog sa = new SaveFileDialog();
                sa.Filter = "Excel文件2003|*.xls";
                sa.FileName = "采购合并列表";

                DialogResult d = sa.ShowDialog();
                if (d == DialogResult.OK)
                {
                    string sPath = sa.FileName;

                    if (sPath.Trim() != string.Empty)
                    {
                        gridView2.ExportToXls(sPath);
                        MessageBox.Show("导出列表成功！\n路径：" + sPath);
                    }
                }
            }
            catch (Exception ee)
            {
                throw new Exception("导出列表失败：" + ee.Message);
            }
        }
      
        private string GetsCode(long iCode,string sDepCode)
        {
            try
            {
                string ssCode = iCode.ToString().Trim();
                string sDep = sDepCode.Trim().Substring(0, 1);
                for (int iii = 0; iii < 4; iii++)
                {
                    if (ssCode.Length < 4)
                    {
                        ssCode = "0" + ssCode;
                    }
                    else
                    {
                        break;
                    }
                }
                string sSQL = "Select cCode from @u8.VoucherContrapose as a Left Join @u8.Department as b ON a.cSeed=b.cDepCode  " +
                            "WHERE cContent = 'department' AND cDepCode = '" + sDep.Trim() + "' " +
                            "order by a.cSeed";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyyy") + dt.Rows[0]["cCode"].ToString().Trim() + ssCode;
                }
                else
                {
                    throw new Exception("获得单据号失败！");
                }
            }
            catch
            {
                throw new Exception("获得单据号失败！");
            }
        }

        private void  btnImport()
        {
            try
            {
                if (gridView2.RowCount < 1)
                {
                    MessageBox.Show("没有数据，不能生单！");
                    return;
                }

                int iYear = int.Parse(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4));
                int iYear2 = int.Parse(date1.DateTime.ToString("yyyy"));
                string sSQL = "";

                if (iYear >= iYear2)
                {
                    sSQL = "select * from @u8.GL_mend where iYPeriod = '" + date1.DateTime.ToString("yyyyMM") + "'";
                    DataTable dtGL = clsSQLCommond.ExecQuery(sSQL);
                    if (Convert.ToBoolean(dtGL.Rows[0]["bflag_PU"]) == true)
                    {
                        MessageBox.Show("当月采购管理已结帐，不能录入数据！");
                        return;
                    }
                }
                
                try
                {
                    gridView2.FocusedRowHandle -= 1;
                    gridView2.FocusedRowHandle += 1;
                }
                catch { }
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                sSQL = "select * from @u8.PO_Pomain where 1=-1";
                DataTable dtPO_Pomain = clsSQLCommond.ExecQuery(sSQL);

                sSQL = "select * from @u8.PO_Podetails  where 1=-1";
                DataTable dtPO_Podetails = clsSQLCommond.ExecQuery(sSQL);

                SetGridView1();

                DataTable dtTemp1 = ((DataTable)gridControl2.DataSource ).Copy();
                DataView dvView1 = dtTemp1.DefaultView;
                dvView1.Sort = " cVenCode asc,AutoID asc";
                dvView1.RowFilter = " bChoose = '√' ";

                DataTable dtView1 = dvView1.ToTable();
                DataColumn dc = new DataColumn();
                dc.ColumnName = "PomainID";
                dtView1.Columns.Add(dc);

                long iID;
                long iIDDetail;
                //sSQL = "select iFatherID,iChildID from UFSystem..UA_Identity where cAcc_Id = '200' and cVouchType = 'POMain'";

                sSQL = @"
declare @p5 int
set @p5=1000043137
declare @p6 int
set @p6=1000043137
exec @u8.sp_GetID @RemoteId=N'00',@cAcc_Id=N'200',@cVouchType=N'POMain',@iAmount=1,@iFatherId=@p5 output,@iChildId=@p6 output
select @p5, @p6
";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                if (dt == null || dt.Rows.Count < 1)
                {
                    iID = 0;
                    iIDDetail = 0;
                }
                else
                {
                    iID = Convert.ToInt64(dt.Rows[0][0]);
                    iIDDetail = Convert.ToInt64(dt.Rows[0][1]);
                }

                long iCode = 0;
                sSQL = "select isnull(max(cNumber),0) as Maxnumber From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='88'  and cSeed='" + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyyy") + "'";
                DataTable dtCode = clsSQLCommond.ExecQuery(sSQL);
                iCode = Convert.ToInt64(dtCode.Rows[0]["Maxnumber"]);
                bool bVouNumber = false;
                if (iCode == 0)
                {
                    bVouNumber = true;
                }

                string sErr = "";
                string sErr1 = "";
                string sErr2 = "";
                string sErr3 = "";
                string sErr4 = "";
                string sErr5 = "";
                ArrayList aList = new ArrayList();

                for (int i = 0; i < dtView1.Rows.Count; i++)
                {
                    if (dtView1.Rows[i]["bChoose"].ToString().Trim() != "√")
                    {
                        continue;
                    }

                    //string sErrSQL = "";
                    //DataTable dtErr = clsSQLCommond.ExecQuery(sErrSQL);
                    double d1 = 0; if (dtView1.Rows[i]["fQuantity"].ToString().Trim() != "") d1 = Convert.ToDouble(dtView1.Rows[i]["fQuantity"]);
                    double d2 = 0; if (dtView1.Rows[i]["iReceivedQTY"].ToString().Trim() != "") d2 = Convert.ToDouble(dtView1.Rows[i]["iReceivedQTY"]);
                    double d3 = 0; if (dtView1.Rows[i]["QtyNow"].ToString().Trim() != "") d3 = Convert.ToDouble(dtView1.Rows[i]["QtyNow"]);
                    
                    if (d1 < d2 +d3)
                    {
                        sErr3 = sErr3 + "第" + (i + 1) + "行：" + dtView1.Rows[i]["cVenCode"].ToString().Trim() + ",物料：" + dtView1.Rows[i]["cInvCode"].ToString().Trim() + "超请购单！\n";
                        continue;
                    }

                    if (dtView1.Rows[i]["cVenCode"] == null || dtView1.Rows[i]["cVenCode"].ToString().Trim()=="")
                    {
                        sErr1 =sErr1 + "第" + (i+1) + "行请购单：" + dtView1.Rows[i]["cCode"].ToString().Trim() + ",物料：" + dtView1.Rows[i]["cInvCode"].ToString().Trim() + "没有供应商！\n";
                        continue;
                    }
                    if (dtView1.Rows[i]["QtyNow"] == null || dtView1.Rows[i]["QtyNow"].ToString().Trim() == "" || dtView1.Rows[i]["QtyNow"].ToString().Trim() == "0" || Convert.ToDouble(dtView1.Rows[i]["QtyNow"]) <= 0)
                    {
                        sErr3 = sErr3 + "第" + (i + 1) + "行供应商：" + dtView1.Rows[i]["cVenCode"].ToString().Trim() + ",物料：" + dtView1.Rows[i]["cInvCode"].ToString().Trim() + "没有设置数量或数量不能为负数！\n";
                        continue;
                    }

                    if (dtView1.Rows[i]["iTaxPrice"] == null || dtView1.Rows[i]["iTaxPrice"].ToString().Trim() == "" || dtView1.Rows[i]["iTaxPrice"].ToString().Trim() == "0" || Convert.ToDouble(dtView1.Rows[i]["iTaxPrice"]) <= 0)
                    {
                        sErr3 = sErr3 + "第" + (i + 1) + "行供应商：" + dtView1.Rows[i]["cVenCode"].ToString().Trim() + ",物料：" + dtView1.Rows[i]["cInvCode"].ToString().Trim() + "没有输入单价或单价不能为负数！\n";
                        continue;
                    }

                    if (dtView1.Rows[i]["dRequirDate"] == null || dtView1.Rows[i]["dRequirDate"].ToString().Trim() == "" || Convert.ToDateTime( dtView1.Rows[i]["dRequirDate"]) < DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")) )
                    {
                        sErr3 = sErr3 + "第" + (i + 1) + "行供应商：" + dtView1.Rows[i]["cVenCode"].ToString().Trim() + ",物料：" + dtView1.Rows[i]["cInvCode"].ToString().Trim() + "到货日期不能在订货日期之前！\n";
                        continue;
                    }

                    if (dtView1.Rows[i]["cDepCode"] == null || dtView1.Rows[i]["cDepCode"].ToString().Trim() == "")
                    {
                        sErr3 = sErr3 + "第" + (i + 1) + "行供应商：" + dtView1.Rows[i]["cVenCode"].ToString().Trim() + "未设定部门！\n";
                        continue;
                    }
                    string siAppIds = dtView1.Rows[i]["AutoID"].ToString().Trim().Replace(';', ',');
                    if (siAppIds != null && siAppIds != "")
                    {
                        string sItem = dtView1.Rows[i]["cItemCode"].ToString().Trim();
                        if (sItem == "")
                        {
                            sItem = "Share";
                        }
                        sSQL = "select count(*) from @u8.Po_Pomain a inner join @u8.Po_podetails b on a.poid = b.poid " +
                                "where b.cItemCode = '" + sItem + "' and b.cInvCode = '" + dtView1.Rows[i]["cInvCode"].ToString().Trim() + "' and b.iAppIds in (" + siAppIds + ") ";
                        DataTable dtCou = clsSQLCommond.ExecQuery(sSQL);
                        int iCou = Convert.ToInt32(dtCou.Rows[0][0]);
                        if (iCou > 0)
                        {
                            sSQL = "select sum(fQuantity - isnull(iReceivedQTY,0)) from @u8.PU_AppVouch a inner join @u8.PU_AppVouchs b on a.ID = b.ID where b.AutoID in (" + siAppIds + ") ";
                            DataTable dtSum = clsSQLCommond.ExecQuery(sSQL);
                            decimal dSum = Convert.ToDecimal(dtSum.Rows[0][0]);
                            if (dSum < decimal.Round(Convert.ToDecimal(dtView1.Rows[i]["QtyNow"]), 6))
                            {
                                sErr3 = sErr3 + "第" + (i + 1) + "行重复生单！\n";
                                continue;
                            }
                        }
                    }

                    sSQL = "select sum(fQuantity) as iQty,sum(iReceivedQTY) as iRecQty from @u8.PU_AppVouchs where autoid in(" + dtView1.Rows[i]["AutoID"].ToString().Trim().Replace(';',',') + ")";
                    DataTable dtPUTemp = clsSQLCommond.ExecQuery(sSQL);
                    decimal dec1 = 0 ;//数据库中累计下单数量
                    decimal dec2 =0;  //当前单据中累计下单数量
                    if (dtPUTemp != null && dtPUTemp.Rows.Count > 0)
                    {
                        dec1 = Convert.ToDecimal(dtPUTemp.Rows[0]["iRecQty"]);
                        dec2 = Convert.ToDecimal(dtView1.Rows[i]["iReceivedQTY"]);
                        if (dec1 != dec2)
                        {
                            sErr3 = sErr3 + "第" + (i + 1) + "行已经由他人生单，请核查！\n";
                            continue;
                        }
                    }
                   

                    if (i == 0)
                    {
                        iID += 1;
                        iCode += 1;
                        DataRow drPO_Pomain = dtPO_Pomain.NewRow();

                        drPO_Pomain["dPODate"] = date1.DateTime.ToString("yyyy-MM-dd");
                        drPO_Pomain["cVenCode"] = dtView1.Rows[i]["cVenCode"];
                        drPO_Pomain["cDepCode"] = dtView1.Rows[i]["cDepCode"];
                        drPO_Pomain["cPOID"] = GetsCode(iCode, dtView1.Rows[i]["cDepCode"].ToString().Trim());
                        drPO_Pomain["cPTCode"] = "01";
                        drPO_Pomain["cexch_name"] = "人民币";
                        drPO_Pomain["nflat"] = 1;
                        drPO_Pomain["iTaxRate"] = 17;
                        if(BaseFunction.ReturnDecimal(dtView1.Rows[i]["iPerTaxRate"]) >0 && BaseFunction.ReturnDecimal(dtView1.Rows[i]["iPerTaxRate"]) < 100)
                        {
                            drPO_Pomain["iTaxRate"] = dtView1.Rows[i]["iPerTaxRate"];
                        }
                        drPO_Pomain["cState"] = 0;
                        drPO_Pomain["cMaker"] = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                        drPO_Pomain["POID"] = iID;
                        drPO_Pomain["iVTid"] = 30766;
                        drPO_Pomain["cBusType"] = "普通采购";
                        drPO_Pomain["iVTid"] = 30766;
                        drPO_Pomain["cLocker"] = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                        drPO_Pomain["iDiscountTaxType"] = 0;
                        drPO_Pomain["IsWfControlled"] = 0;
                        drPO_Pomain["cmaketime"] = date1.DateTime.ToString("yyyy-MM-dd");
                        drPO_Pomain["iDiscountTaxType"] = 0;
                        drPO_Pomain["cDefine11"] = dtView1.Rows[i]["cItemCode"];
                        drPO_Pomain["cPayCode"] = dtView1.Rows[i]["cVenPayCond"];
                        drPO_Pomain["cPersonCode"] = dtView1.Rows[i]["cVenPPerson"];
                        drPO_Pomain["cDefine2"] = dtView1.Rows[i]["cDefine2"];
                        drPO_Pomain["cMemo"] = dtView1.Rows[i]["cMemo"];

                        dtPO_Pomain.Rows.Add(drPO_Pomain);
                    }
                    else
                    {
                        bool bVend = false;
                        for (int j = 0; j < i && j < dtPO_Pomain.Rows.Count; j++)
                        {
                            if (dtPO_Pomain.Rows[j]["cVenCode"].ToString().Trim().ToLower() == dtView1.Rows[i]["cVenCode"].ToString().Trim().ToLower() && dtPO_Pomain.Rows[j]["cDepCode"].ToString().Trim().ToLower() == dtView1.Rows[i]["cDepCode"].ToString().Trim().ToLower())
                            {
                                bVend = true;
                                dtView1.Rows[i]["PomainID"] = dtPO_Pomain.Rows[j]["POID"];
                                break;
                            }
                        }
                        if (!bVend)
                        {
                            iID += 1;
                            iCode += 1;
                            DataRow drPO_Pomain = dtPO_Pomain.NewRow();
                            
                            drPO_Pomain["dPODate"] = date1.DateTime.ToString("yyyy-MM-dd");
                            drPO_Pomain["cVenCode"] = dtView1.Rows[i]["cVenCode"];
                            drPO_Pomain["cDepCode"] = dtView1.Rows[i]["cDepCode"];
                            drPO_Pomain["cPOID"] = GetsCode(iCode, dtView1.Rows[i]["cDepCode"].ToString().Trim());
                            drPO_Pomain["cPTCode"] = "01";
                            drPO_Pomain["cexch_name"] = "人民币";
                            drPO_Pomain["nflat"] = 1;
                            drPO_Pomain["iTaxRate"] = 17;
                            if (BaseFunction.ReturnDecimal(dtView1.Rows[i]["iPerTaxRate"]) > 0 && BaseFunction.ReturnDecimal(dtView1.Rows[i]["iPerTaxRate"]) < 100)
                            {
                                drPO_Pomain["iTaxRate"] = dtView1.Rows[i]["iPerTaxRate"];
                            }
                            drPO_Pomain["cState"] = 0;
                            drPO_Pomain["cMaker"] = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                            drPO_Pomain["POID"] = iID;
                            drPO_Pomain["iVTid"] = 30766;
                            drPO_Pomain["cBusType"] = "普通采购";
                            drPO_Pomain["iVTid"] = 30766;
                            drPO_Pomain["cLocker"] = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                            drPO_Pomain["iDiscountTaxType"] = 0;
                            drPO_Pomain["IsWfControlled"] = 0;
                            drPO_Pomain["cmaketime"] = date1.DateTime.ToString("yyyy-MM-dd");
                            drPO_Pomain["iDiscountTaxType"] = 0;
                            drPO_Pomain["cDefine11"] = dtView1.Rows[i]["cItemCode"];
                            drPO_Pomain["cPayCode"] = dtView1.Rows[i]["cVenPayCond"];
                            drPO_Pomain["cPersonCode"] = dtView1.Rows[i]["cVenPPerson"];
                            drPO_Pomain["cDefine2"] = dtView1.Rows[i]["cDefine2"];
                            drPO_Pomain["cMemo"] = dtView1.Rows[i]["cMemo"];

                            dtPO_Pomain.Rows.Add(drPO_Pomain);
                        }
                    }

                    iIDDetail += 1;
                    DataRow drPO_Podetails = dtPO_Podetails.NewRow();
                    drPO_Podetails["ID"] = iIDDetail;
                    drPO_Podetails["cInvCode"] = dtView1.Rows[i]["cInvCode"];
                    drPO_Podetails["iQuantity"] = decimal.Round(Convert.ToDecimal(dtView1.Rows[i]["QtyNow"]), 6);

                    if (dtView1.Rows[i]["NumNow"] == null || dtView1.Rows[i]["NumNow"].ToString().Trim() == "" || dtView1.Rows[i]["NumNow"].ToString().Trim() == "0")
                    {

                    }
                    else
                    {
                        drPO_Podetails["iNum"] =decimal.Round(Convert.ToDecimal( dtView1.Rows[i]["NumNow"]),6);
                    }
                    drPO_Podetails["iUnitPrice"] = decimal.Round(Convert.ToDecimal(dtView1.Rows[i]["iTaxPrice"]) / (1 + Convert.ToDecimal(dtView1.Rows[i]["iPerTaxRate"]) / 100), 6);
                    drPO_Podetails["iMoney"] = decimal.Round(Convert.ToDecimal(drPO_Podetails["iUnitPrice"]) * Convert.ToDecimal(dtView1.Rows[i]["QtyNow"]), 2);
                    drPO_Podetails["iTax"] = decimal.Round(Convert.ToDecimal(dtView1.Rows[i]["iTaxPrice"]) * Convert.ToDecimal(dtView1.Rows[i]["QtyNow"]) - Convert.ToDecimal(drPO_Podetails["iMoney"]), 2);
                    drPO_Podetails["iSum"] = decimal.Round(Convert.ToDecimal(dtView1.Rows[i]["iTaxPrice"]) * Convert.ToDecimal(dtView1.Rows[i]["QtyNow"]), 2);
                    drPO_Podetails["iNatUnitPrice"] = decimal.Round(Convert.ToDecimal(drPO_Podetails["iUnitPrice"]), 6);
                    drPO_Podetails["iNatMoney"] = decimal.Round(Convert.ToDecimal(drPO_Podetails["iMoney"]), 2);
                    drPO_Podetails["iNatTax"] = decimal.Round(Convert.ToDecimal(drPO_Podetails["iTax"]), 2);
                    drPO_Podetails["iNatSum"] = decimal.Round(Convert.ToDecimal(drPO_Podetails["iSum"]), 2);

                    if (Convert.ToDateTime(dtView1.Rows[i]["dRequirDate"]) < DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")))
                    {
                        sErr4 = sErr4 + "第" + (i + 1) + "行供应商：" + dtView1.Rows[i]["cVenCode"].ToString().Trim() + ",物料：" + dtView1.Rows[i]["cInvCode"].ToString().Trim() + "制单日期超过需求日期！\n";
                    }
                    drPO_Podetails["dArriveDate"] = dtView1.Rows[i]["dRequirDate"];
                    drPO_Podetails["iPerTaxRate"] = decimal.Round(Convert.ToDecimal(dtView1.Rows[i]["iPerTaxRate"]), 2);

                    if (dtView1.Rows[i]["cItemCode"].ToString().Trim() == "")
                    {
                        drPO_Podetails["cItemCode"] = "Share";
                        drPO_Podetails["cItem_class"] = "00";
                        drPO_Podetails["cItemName"] = "Share";
                    }
                    else
                    {
                        drPO_Podetails["cItemCode"] = dtView1.Rows[i]["cItemCode"];
                        drPO_Podetails["cItem_class"] = dtView1.Rows[i]["cItem_class"];
                        drPO_Podetails["cItemName"] = dtView1.Rows[i]["CItemName"];
                    }
                    drPO_Podetails["bGsp"] = 0;
                    drPO_Podetails["POID"] = iID;
                    drPO_Podetails["iTaxPrice"] = decimal.Round(Convert.ToDecimal(dtView1.Rows[i]["iTaxPrice"]), 6);
                    drPO_Podetails["cUnitID"] = dtView1.Rows[i]["cUnitID"];
                    drPO_Podetails["cDefine33"] = dtView1.Rows[i]["Remark"];

                    string[] s = dtView1.Rows[i]["AutoID"].ToString().Trim().Split(';');
                    drPO_Podetails["iAppIds"] = s[0];
                    drPO_Podetails["bTaxCost"] = 0;
                    drPO_Podetails["cSource"] = "app";
                    drPO_Podetails["SoType"] = 1;
                    drPO_Podetails["SoDId"] = dtView1.Rows[i]["SoDId"];
                    string[] s1 = dtView1.Rows[i]["cCode"].ToString().Trim().Split(';');
                    drPO_Podetails["cupsocode"] = s1[0];

                    dtPO_Podetails.Rows.Add(drPO_Podetails);

                    string sAutoID = dtView1.Rows[i]["AutoID"].ToString().Trim();
                    string[] sID = sAutoID.Split(';');

                    for (int j = 0; j < sID.Length; j++)
                    {
                        for (int k = 0; k < gridView1.RowCount; k++)
                        {
                            if (sID[j] == gridView1.GetRowCellValue(k,gridColAutoID).ToString().Trim())
                            {
                                decimal dQty = 0;
                                decimal dNum = 0;
                                if (gridView1.GetRowCellValue(k, gridColQtyNow) != null && gridView1.GetRowCellValue(k, gridColQtyNow).ToString().Trim() != "" )
                                {
                                    dQty =decimal.Round(Convert.ToDecimal( gridView1.GetRowCellValue(k, gridColQtyNow)),6);
                                }
                                if (gridView1.GetRowCellValue(k, gridColNumNow) != null && gridView1.GetRowCellValue(k, gridColNumNow).ToString().Trim() != "")
                                {
                                    dNum = decimal.Round(Convert.ToDecimal(gridView1.GetRowCellValue(k, gridColNumNow).ToString().Trim()),2);
                                }

                                if (dtView1.Rows[i]["NumNow"] == null || dtView1.Rows[i]["NumNow"].ToString().Trim() == "" || dtView1.Rows[i]["NumNow"].ToString().Trim() == "0")
                                {
                                    sSQL = "if exists (select * from UFDLImport..PU_AppVouchs_Import where PU_AppVouchID=" + sID[j] + " and accid = 200 and accyear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + " and PO_PodetailsID=" + iIDDetail + ") " +
                                                 "update UFDLImport..PU_AppVouchs_Import set iQty = isnull(iQty,0) + " + dQty + " where PU_AppVouchID=" + sID[j] + " and accid = 200 and accyear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + " and PO_PodetailsID=" + iIDDetail + " " +
                                             "else " +
                                                 "insert into UFDLImport..PU_AppVouchs_Import(PU_AppVouchID,AccID,AccYear,PO_PodetailsID,iQty)values(" + sID[j] + ",200," + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "," + iIDDetail + "," + dQty + ")";
                                    aList.Add(sSQL);

                                    sSQL = "update @u8.PU_AppVouchs set iReceivedQTY = isnull(iReceivedQTY,0) + " + dQty + " where AutoID = " + sID[j]; 
                                    aList.Add(sSQL);
                                }
                                else
                                {
                                    sSQL = "if exists (select * from UFDLImport..PU_AppVouchs_Import where PU_AppVouchID=" + sID[j] + " and accid = 200 and accyear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + " and PO_PodetailsID=" + iIDDetail + ") " +
                                                "update UFDLImport..PU_AppVouchs_Import set iQty = isnull(iQty,0) + " + dQty + " , iNum = isnull(iNum,0) + " + dNum + " where PU_AppVouchID=" + sID[j] + " and accid = 200 and accyear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + " and PO_PodetailsID=" + iIDDetail + " " +
                                            "else " +
                                                "insert into UFDLImport..PU_AppVouchs_Import(PU_AppVouchID,AccID,AccYear,PO_PodetailsID,iQty,iNum)values(" + sID[j] + ",200," + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "," + iIDDetail + "," + dQty + "," + dNum + ")";
                                    aList.Add(sSQL);

                                    sSQL = "update @u8.PU_AppVouchs set iReceivedQTY = isnull(iReceivedQTY,0) + " + dQty + ",iReceivedNum = isnull(iReceivedNum,0) + " +dNum + " where AutoID = " + sID[j];
                                    aList.Add(sSQL);
                                }
                            }
                        }
                    }
                }

                string sCode = "";


                FrmMailListSend frmMail = new FrmMailListSend();
                for (int i = 0; i < dtPO_Pomain.Rows.Count; i++)
                {
                    //生成采购订单表头
                    aList.Add(clsGetSQL.GetInsertSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "PO_Pomain", dtPO_Pomain, i));

                    if (sCode == string.Empty)
                    {
                        sCode = dtPO_Pomain.Rows[i]["cPOID"].ToString() + "    " + dtPO_Pomain.Rows[i]["cVenCode"].ToString() + "--" + (((DataTable)ItemLookUpEdit_Ven.DataSource).Select(" iID = '" + dtPO_Pomain.Rows[i]["cVenCode"].ToString() + "' "))[0]["iText"].ToString().Trim() + "\n";
                    }
                    else
                    {
                        sCode = sCode + dtPO_Pomain.Rows[i]["cPOID"].ToString() + "    " + dtPO_Pomain.Rows[i]["cVenCode"].ToString() + "--" + (((DataTable)ItemLookUpEdit_Ven.DataSource).Select(" iID = '" + dtPO_Pomain.Rows[i]["cVenCode"].ToString() + "' "))[0]["iText"].ToString().Trim() + "\n";
                    }

                    bool b存在 = true;
                    for (int j = 0; j < frmMail.dt.Rows.Count; j++)
                    {
                        string sVen1 = frmMail.dt.Rows[j]["mailPerID"].ToString().Trim();
                        string sVen2 = dtPO_Pomain.Rows[i]["cVenCode"].ToString().Trim();
                        if (sVen1 == sVen2)
                        {
                            b存在 = false;
                            if (frmMail.dt.Rows[j]["cCode"].ToString().Trim() == "")
                            {
                                frmMail.dt.Rows[j]["cCode"] = dtPO_Pomain.Rows[i]["cPOID"].ToString();
                            }
                            else
                            {
                                frmMail.dt.Rows[j]["cCode"] = frmMail.dt.Rows[j]["cCode"] + "," + dtPO_Pomain.Rows[i]["cPOID"].ToString();
                            }
                        }
                    }

                    if (b存在)
                    {
                        sSQL = "select a.*,b.cvenname from UFDLImport.._vendUid a left join @u8.vendor b on a.vendcode = b.cvencode where a.AccID = '200' and a.AccYear  = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' and a.vendcode = '" + dtPO_Pomain.Rows[i]["cVenCode"].ToString().Trim() + "' ";
                        DataTable dtMail = clsSQLCommond.ExecQuery(sSQL);
                        if (dtMail != null && dtMail.Rows.Count > 0)
                        {
                            DataRow drMail = frmMail.dt.NewRow();
                            drMail["Subject"] = "采购评审";
                            //drMail["sText"] = "采购订单已下达请尽快评审";
                            drMail["cCode"] = dtPO_Pomain.Rows[i]["cPOID"].ToString();
                            drMail["bUsed"] = "-1";
                            drMail["mailAddress"] = dtMail.Rows[0]["sEMail"].ToString().Trim();
                            drMail["mailPerID"] = dtMail.Rows[0]["vendcode"].ToString().Trim();
                            drMail["mailPer"] = dtMail.Rows[0]["cvenname"].ToString().Trim();
                            drMail["sMailCC"] = "dolle_sz@126.com";
                            frmMail.dt.Rows.Add(drMail);
                        }
                        else
                        {
                            MessageBox.Show("供应商" + dtPO_Pomain.Rows[i]["cVenCode"].ToString() + "未设置邮箱");
                        }
                    }

                }
                for (int i = 0; i < dtPO_Podetails.Rows.Count; i++)
                {
                    //生成采购订单表体
                    aList.Add(clsGetSQL.GetInsertSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "PO_Podetails", dtPO_Podetails, i));
                }
                if (bVouNumber)
                {
                    sSQL = "insert into @u8.VoucherHistory(cardnumber,cContent,cContentRule,cSeed,cNumber,bEmpty) " +
                            "values('88','单据日期','年','" + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyyy") + "','1',0)";
                    aList.Add(sSQL);
                }
                else
                {
                    sSQL = "update @u8.VoucherHistory set cNumber = '" + iCode.ToString().Trim() + "' where  CardNumber='88' and cSeed = '" + Convert.ToDateTime(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyyy") + "'";
                    aList.Add(sSQL);
                }
                if (iID >= 1000000000)
                    iID = iID - 1000000000;
                if (iIDDetail >= 1000000000)
                    iIDDetail = iIDDetail - 1000000000;
                sSQL = "update UFSystem..UA_Identity set iFatherID=" + iID + ",iChildID=" + iIDDetail + " where  cAcc_Id = '200' and cVouchType = 'POMain'";
                aList.Add(sSQL);

                sErr = sErr1 + sErr2 + sErr3 + sErr4 + sErr5;
                if (sErr.Trim() != string.Empty)
                {
                    FrmMsgBox fMsgBos = new FrmMsgBox();
                    fMsgBos.Text = "提示";
                    fMsgBos.richTextBox1.Text = "以下数据存在错误，请修正数据后重新生成！\n" + sErr;
                    fMsgBos.ShowDialog();
                    return;
                }

                if (dtPO_Pomain.Rows.Count > 0 && dtPO_Podetails.Rows.Count > 0 && aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    FrmMsgBox fMsgBos = new FrmMsgBox();
                    fMsgBos.Text = "生成采购订单成功！";
                    fMsgBos.richTextBox1.Text = sCode;
                    fMsgBos.ShowDialog();

                    gridControl1.DataSource = null;
                    gridControl2.DataSource = null;


                    try
                    {
                        frmMail.sDO = "采购订单评审";
                        frmMail.FrmMailListSend_Load(null, null);
                        frmMail.btnOK_Click(null, null);
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("请选择需要生单的数据");
                }
            }
            catch (Exception ee)
            {
                throw new Exception("生成单据失败！  " + ee.Message);
            }
        }

        private void SetGridView1()
        {
            try
            {
                try
                {
                    gridView2.FocusedRowHandle -= 1;
                }
                catch { }

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridColbChoose, "");
                    gridView1.SetRowCellValue(i, gridColQtyNow, null);
                    gridView1.SetRowCellValue(i, gridColNumNow, null);
                    gridView1.SetRowCellValue(i, gridColcVenCode, null);
                    gridView1.SetRowCellValue(i, gridColcVenName, null);
                    gridView1.SetRowCellValue(i, gridColiTaxPrice, null);
                    gridView1.SetRowCellValue(i, gridColiTaxRate, null);
                    gridView1.SetRowCellValue(i, gridColfMoney, null);
                }

                //return;
                string[] s;
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    if (gridView2.GetRowCellValue(i, gridColbChoose2).ToString().Trim() == "√")
                    {
                        string sInvCode = gridView2.GetRowCellValue(i, gridColcInvCode2).ToString().Trim();

                        double dQty = 0;
                        if (gridView2.GetRowCellValue(i, gridColQtyNow2).ToString().Trim() != "" && gridView2.GetRowCellValue(i, gridColQtyNow2).ToString().Trim() != "0")
                        {
                            dQty = Convert.ToDouble(gridView2.GetRowCellValue(i, gridColQtyNow2));
                        }
                        if (dQty == 0)
                        {
                            gridView2.SetRowCellValue(i, gridColbChoose2, "");
                        }

                        double dNum = 0;
                        bool bNum = false;
                        if (gridView2.GetRowCellValue(i, gridColNumNow2).ToString().Trim() != "")
                        {
                            dNum = Convert.ToDouble(gridView2.GetRowCellValue(i, gridColNumNow2));
                            bNum = true;
                        }
                        s = gridView2.GetRowCellValue(i, gridColAutoID2).ToString().Trim().Split(';');

                        for (int k = 0; k < s.Length; k++)
                        {
                            for (int j = 0; j < gridView1.RowCount; j++)
                            {
                                if (s[k].Trim() == gridView1.GetRowCellValue(j, gridColAutoID2).ToString().Trim())
                                {
                                    if (dQty <= 0)
                                    {
                                        break;
                                    }

                                    gridView1.SetRowCellValue(i, gridColbChoose, "√");
                                    gridView1.SetRowCellValue(j, gridColcVenCode, gridView2.GetRowCellValue(i, gridColcVenCode2));
                                    gridView1.SetRowCellValue(j, gridColcVenName, gridView2.GetRowCellValue(i, gridColcVenName2));
                                    gridView1.SetRowCellValue(j, gridColiTaxPrice, gridView2.GetRowCellValue(i, gridColiTaxPrice2));
                                    gridView1.SetRowCellValue(j, gridColiTaxRate, gridView2.GetRowCellValue(i, gridColiPerTaxRate2));

                                    if (k == s.Length - 1)
                                    {
                                        gridView1.SetRowCellValue(j, gridColQtyNow, dQty);
                                        if (bNum)
                                        {
                                            gridView1.SetRowCellValue(j, gridColNumNow, dNum);
                                        }

                                        gridView1.SetRowCellValue(j, gridColbChoose, "√");
                                        //gridView1.SetRowCellValue(j, gridColfMoney, Convert.ToDouble(gridView2.GetRowCellValue(j, gridColiTaxPrice2)) * dQty);
                                        continue;
                                    }

                                    gridView1.SetRowCellValue(j, gridColbChoose, "√");
                                    double d1 = Convert.ToDouble(gridView1.GetRowCellValue(j, gridColiQty));
                                    if (d1 >= dQty)
                                    {
                                        gridView1.SetRowCellValue(j, gridColQtyNow, dQty);
                                        //gridView1.SetRowCellValue(j, gridColfMoney, Convert.ToDouble(gridView2.GetRowCellValue(j, gridColiTaxPrice2)) * dQty);
                                        dQty = 0;
                                        if (bNum)
                                        {
                                            gridView1.SetRowCellValue(j, gridColNumNow, dNum);
                                            dNum = 0;
                                        }
                                        break;
                                    }
                                    gridView1.SetRowCellValue(j, gridColQtyNow, d1);
                              
                                    dQty = dQty - d1;
                                    if (bNum)
                                    {
                                        double d2 = Convert.ToDouble(gridView1.GetRowCellValue(j, gridColiNum));
                                        gridView1.SetRowCellValue(j, gridColNumNow, d2);
                                        dNum = dNum - d2;
                                    }
                                    if (dQty <= 0)
                                    {
                                        gridView1.SetRowCellValue(j, gridColQtyNow, 0);
                                        if (bNum)
                                        {
                                            gridView1.SetRowCellValue(j, gridColNumNow, 0);
                                        }
                                    }
                                    
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("设置请购单信息错误！  " + ee.Message);
            }
        }

        private void btnGet()
        {
            try
            {
                FrmStockOrderCreateSel fSEL = new FrmStockOrderCreateSel();
                if (fSEL.ShowDialog() == DialogResult.OK)
                {
                    chkAll.Checked = true;

                    gridControl1.DataSource = fSEL.dt1;

                    for (int i = 0; i < fSEL.dt2.Rows.Count; i++)
                    {
                        try
                        {
                            double d1 = Convert.ToDouble(fSEL.dt2.Rows[i]["iTaxPrice"]);
                            double d2 = Convert.ToDouble(fSEL.dt2.Rows[i]["QtyNow"]);
                            fSEL.dt2.Rows[i]["fMoney"] = d1 * d2;
                        }
                        catch { }
                    }

                    gridControl2.DataSource = fSEL.dt2;

                    gridColNumNow2.OptionsColumn.AllowEdit = true;
                    gridColQtyNow2.OptionsColumn.AllowEdit = true;
                }
            }
            catch 
            { }
        }

        private void FrmStockOrderCreate_Load(object sender, EventArgs e)
        {
            try
            {
                GetVenInfo();

                ClsVenInvPrice clsPrice = new ClsVenInvPrice();
                dtPriceList = clsPrice.GetPrice(1);

                dateEdit1.Text = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                date1.Text = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                date1.Properties.ReadOnly = false;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败！  " + ee.Message);
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAll.Checked)
                {
                    for (int i = 0; i < gridView2.RowCount; i++)
                        gridView2.SetRowCellValue(i, gridView2.Columns["bChoose"], "√");
                }
                if (!chkAll.Checked)
                {
                    for (int i = 0; i < gridView2.RowCount; i++)
                        gridView2.SetRowCellValue(i, gridView2.Columns["bChoose"], "");
                }
            }
            catch
            { }
        }

        private void gridView2_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    string s1 = gridView2.GetRowCellValue(e.RowHandle, gridView2.Columns["bChoose"]).ToString().Trim();
                    if (s1 == "√")
                    {
                        e.Appearance.BackColor = Color.MediumSeaGreen;
                    }
                    if (s1 == "×")
                    {
                        e.Appearance.BackColor = Color.Tomato;
                    }
                }
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetGridView1();
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView2.RowCount < 1)
                    return;
                int iRow = 1;
                if (gridView2.RowCount == 1)
                    iRow = 0;
                else
                    iRow = gridView2.FocusedRowHandle;

                if (gridView2.GetRowCellValue(iRow, gridColbChoose2).ToString().Trim() == "")
                {
                    gridView2.SetFocusedRowCellValue(gridColbChoose2, "√");
                }
                else
                {
                    gridView2.SetFocusedRowCellValue(gridColbChoose2, "");
                    return;
                }
            }
            catch
            { }
        }

        bool bItemButtonEditVen = false;      //ItemButtonEditVen 点击
        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == gridColQtyNow2 && radioQty.Checked)
                {
                    string s = gridView2.GetRowCellValue(e.RowHandle, gridColiNum2).ToString().Trim();
                    if (s != "")
                    {
                        double d = Convert.ToDouble(gridView2.GetRowCellValue(e.RowHandle, gridColiNum2));
                        double d1 = Convert.ToDouble(gridView2.GetRowCellValue(e.RowHandle, gridColiQty2));
                        double d2 = Convert.ToDouble(gridView2.GetRowCellValue(e.RowHandle, gridColQtyNow2));
                        gridView2.SetRowCellValue(e.RowHandle, gridColNumNow2, d / d1 * d2);
                        double d3 = 0;
                        try
                        {
                            d3 = Convert.ToDouble(gridView2.GetRowCellValue(e.RowHandle, gridColiTaxPrice2));
                        }
                        catch { }
                        gridView2.SetRowCellValue(e.RowHandle, gridColfMoney2, d2 * d3);
                    }
                }
                if (e.Column == gridColNumNow2 && radioNum.Checked)
                {
                    double d = Convert.ToDouble(gridView2.GetRowCellValue(e.RowHandle, gridColiNum2));
                    double d1 = Convert.ToDouble(gridView2.GetRowCellValue(e.RowHandle, gridColiQty2));
                    double d2 = Convert.ToDouble(gridView2.GetRowCellValue(e.RowHandle, gridColNumNow2));
                    gridView2.SetRowCellValue(e.RowHandle, gridColQtyNow2, d1 / d * d2);

                    double d3 = Convert.ToDouble(gridView2.GetRowCellValue(e.RowHandle, gridColiTaxPrice2));
                    gridView2.SetRowCellValue(e.RowHandle, gridColfMoney2, d1 / d * d2 * d3);
                }
                if (e.Column == gridColcVenCode2)
                {
                    if (!bItemButtonEditVen)
                    {
                        string sSQL = "select cVenName,v.cVenDepart,d.cDepName from @u8.vendor v LEFT JOIN @u8.Department d ON v.cVenDepart = d.cDepCode where v.cVenCode = '" + gridView2.GetRowCellValue(e.RowHandle, gridColcVenCode2).ToString().Trim() + "' ";
                        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            gridView2.SetRowCellValue(e.RowHandle, gridColcVenName2, dt.Rows[0]["cVenName"]);
                            gridView2.SetRowCellValue(e.RowHandle, gridColcDepCode2, dt.Rows[0]["cVenDepart"]);
                            gridView2.SetRowCellValue(e.RowHandle, gridColcDepName2, dt.Rows[0]["cDepName"]);
                        }
                        else
                        {
                            if (gridView2.GetRowCellValue(e.RowHandle, gridColcVenCode2).ToString().Trim() != string.Empty)
                            {
                                gridView2.SetRowCellValue(e.RowHandle, gridColcVenCode2, "");
                            }
                            gridView2.SetRowCellValue(e.RowHandle, gridColcVenName2, "");
                            gridView2.SetRowCellValue(e.RowHandle, gridColcDepCode2, "");
                            gridView2.SetRowCellValue(e.RowHandle, gridColcDepName2, "");
                            gridView2.SetColumnError(gridColcVenCode2, "供应商编码不正确!");
                        }
                    }
                    DataTable dt2 = GetVendPriceInfo(gridView2.GetRowCellValue(e.RowHandle, gridColcInvCode2).ToString().Trim(),gridView2.GetRowCellValue(e.RowHandle, gridColcVenCode2).ToString().Trim());
                    if (dt2 != null && dt2.Rows.Count > 0)
                    {
                        gridView2.SetRowCellValue(e.RowHandle, gridColiTaxPrice2, dt2.Rows[0]["iTaxPrice"]);
                    }
                    else
                    {
                        gridView2.SetRowCellValue(e.RowHandle, gridColiTaxPrice2, 0);
                    }
                }
                if (e.Column == gridColiTaxPrice2)
                {
                    double d1 = Convert.ToDouble(gridView2.GetRowCellValue(e.RowHandle, gridColQtyNow2));
                    double d2 = Convert.ToDouble(gridView2.GetRowCellValue(e.RowHandle, gridColiTaxPrice2));
                    gridView2.SetRowCellValue(e.RowHandle, gridColfMoney2, d1 * d2);
                }
                if (e.Column == gridColcDepCode2)
                {
                    string sSQL = "SELECT cDepCode AS iID, cDepName AS iText FROM @u8.Department WHERE bDepEnd =1 and cDepCode = '"+ gridView2.GetRowCellValue(e.RowHandle,gridColcDepCode2).ToString().Trim() +"' ORDER BY cDepCode ";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        gridView2.SetRowCellValue(e.RowHandle, gridColcDepName2, dt.Rows[0]["iText"]);
                    }
                    else
                    {
                        if (gridView2.GetRowCellValue(e.RowHandle, gridColcDepCode2).ToString().Trim() != string.Empty)
                        {
                            gridView2.SetRowCellValue(e.RowHandle, gridColcDepCode2, "");
                        }
                        gridView2.SetRowCellValue(e.RowHandle, gridColcDepName2, "");
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string s = gridView2.GetRowCellValue(e.FocusedRowHandle, gridColiNum2).ToString().Trim();
            if (s != "")
            {
                gridColNumNow2.OptionsColumn.AllowEdit = true;
            }
            else
            {
                gridColNumNow2.OptionsColumn.AllowEdit = false;
            }
        }

        /// <summary>
        /// 供应商信息
        /// </summary>
        private void GetVenInfo()
        {
            string sSQL = "select cast(cVenCode as varchar(20)) as iID,cVenName as iText from @u8.Vendor where isnull(bVenCargo,0) =1 order by cVenCode";
            DataTable dt = clsGetSQL.GetLookUpEdit(sSQL);
            ItemLookUpEdit_Ven.DataSource = dt;
        }

        /// <summary>
        /// 根据存货编码判断供应商 1. 供应商存货价格表，便宜者 2. 最后一次采购供应商
        /// </summary>
        /// <param name="sInvCode">存货编码</param>
        /// <param name="sVen">供应商编码</param>
        /// <returns></returns>
        private DataTable GetVendPriceInfo(string sInvCode, string sVen)
        {
            try
            {
                DataView dv = new DataView(dtPriceList);
                dv.RowFilter = " cInvCode = '" + sInvCode + "' and cVenCode = '" + sVen + "' ";
                DataTable dt = dv.ToTable();
                if (dt == null || dt.Rows.Count < 1)
                {
                    string sSQL = "select top 1 p.cVenCode,v.cVenName,pd.cInvCode,i.cInvName,i.cInvStd,i.cComUnitCode,pd.iUnitPrice,pd.iTaxPrice,pd.iPerTaxRate as itaxrate " +
                                    "from @u8.PO_Pomain p inner join @u8.PO_Podetails pd on p.poid = pd.poid inner join @u8.Vendor v on v.cVenCode = p.cVenCode inner join @u8.Inventory i on i.cInvCode = pd.cInvCode  " +
                                    "where pd.cInvCode = '" + sInvCode + "' and p.cVenCode = '" + sVen + "'  " +
                                    "order by id desc";
                    dt = clsSQLCommond.ExecQuery(sSQL);
                }
                return dt;
            }
            catch (Exception ee)
            {
                throw new Exception("获得供应商物料信息失败！\n  " + ee.Message);
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == gridColiTaxPrice || e.Column == gridColQtyNow)
                {
                    try
                    {
                        double d1 = Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColiTaxPrice)) * Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColQtyNow));
                        gridView1.SetRowCellValue(e.RowHandle, gridColfMoney, d1);
                    }
                    catch { }
                }
            }
            catch
            { }
        }

        private void ItemButtonEditInvPrice_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int iRow = 0;
            if (gridView1.RowCount > 0)
                iRow = gridView2.FocusedRowHandle;

            string sInvCode = gridView2.GetRowCellValue(iRow, gridColcInvCode2).ToString().Trim();
            FrmInvPrice fPrice = new FrmInvPrice(sInvCode);
            fPrice.ShowDialog();

            if(fPrice.DialogResult == DialogResult.OK)
            {
                double dTaxPrice = fPrice.dTaxPrice;
                double dRate = fPrice.dTaxRate;
                double dQty = Convert.ToDouble(gridView2.GetRowCellValue(iRow, gridColQtyNow2));
                gridView2.SetRowCellValue(iRow, gridColiTaxPrice, dTaxPrice);
                gridView2.SetRowCellValue(iRow, gridColiPerTaxRate2, fPrice.dTaxRate);
                gridView2.SetRowCellValue(iRow, gridColfMoney2, dTaxPrice * dQty);
            }
        }

        private void ItemButtonEditVen_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                bItemButtonEditVen = true;
                int iRow = 0;
                if (gridView2.RowCount > 0)
                    iRow = gridView2.FocusedRowHandle;

                try
                {
                    gridView2.FocusedRowHandle -= 1;
                    gridView2.FocusedRowHandle += 1;
                }
                catch { }

                string sVen = gridView2.GetRowCellDisplayText(iRow, gridColcVenCode2).ToString().Trim();
                bItemButtonEditVen = false;

                FrmVenInfo fVen = new FrmVenInfo(sVen);
                if (DialogResult.OK == fVen.ShowDialog())
                {
                    gridView2.SetRowCellValue(iRow, gridColcVenCode2, fVen.sVenCode);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得供应商参照失败！  " + ee.Message);
            }
        }

        private void ItemButtonEditdep_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView2.RowCount > 0)
                    iRow = gridView2.FocusedRowHandle;

                FrmBaseList fList = new FrmBaseList(1);
                fList.Text = "部门信息";
                if (fList.ShowDialog() == DialogResult.OK)
                {
                    gridView2.SetRowCellValue(iRow, gridColcDepCode2, fList.sID);
                    gridView2.SetRowCellValue(iRow, gridColcDepName2, fList.sText);
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    if (gridView2.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "√")
                    {
                        if (checkBox1.Checked)
                        {
                            gridView2.SetRowCellValue(i, gridColdRequirDate2, dateEdit1.DateTime.ToString("yyyy-MM-dd"));
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dateEdit1.Enabled = true;
            }
            else
            {
                dateEdit1.Enabled = false;
            }
        }

        private DateTime ReturnObjectToDatetime(object o)
        {
            DateTime d = Convert.ToDateTime("1900-01-01");
            try
            {
                d = Convert.ToDateTime(o);
            }
            catch { }
            return d;
        }

        private void btnChange2_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    if (gridView2.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "√")
                    {
                        //if (checkBox1.Checked)
                        //{
                            gridView2.SetRowCellValue(i, gridColiPerTaxRate2, BaseFunction.ReturnDecimal(txtiTaxRate.Text.Trim()));
                        //}
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}