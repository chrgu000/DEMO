using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FrameBaseFunction;

namespace Base
{
    public partial class FrmQMREJECT : FrameBaseFunction.Frm列表窗体模板
    {
        public FrmQMREJECT()
        {
            InitializeComponent();
        }

        private void FrmQMREJECT_Load(object sender, EventArgs e)
        {
            try
            {
                GetCode();
                GetQMSCRAPDISPOSE();

                string sSQL = "select vendCode,cVenName from UFDLImport.._vendUid left join @u8.Vendor on @u8.Vendor.cVenCode = vendCode where uid = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "'  and accid = 200 and accyear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + " ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                txtVenCode.Properties.ReadOnly = false;
                if (FrameBaseFunction.ClsBaseDataInfo.sUid == "admin" || dt.Rows.Count == 0)
                {
                    txtVenCode.Enabled = true;
                }
                else
                {
                    if (dt.Rows[0]["vendCode"].ToString().Trim() == string.Empty)
                    {
                        txtVenCode.Enabled = true;
                    }
                    else
                    {
                        txtVenCode.Enabled = false;
                    }
                    txtVenCode.Text = dt.Rows[0]["vendCode"].ToString().Trim();
                    txtVenCode_Leave(null, null);
                }

                GetGridView();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败！");
            }
        }

        /// <summary>
        /// 不良品处理方式
        /// </summary>
        private void GetQMSCRAPDISPOSE()
        {
            string sSQL = "select CSCRAPDISCODE as iID,CSCRAPDISNAME as iText from @u8.QMSCRAPDISPOSE  order by CSCRAPDISCODE ";
            DataTable dt = clsGetSQL.GetLookUpEdit(sSQL);
            lookUpEditQM.Properties.DataSource = dt;

            lookUpEditQM.Properties.ReadOnly = false;
            lookUpEditQM.Enabled = true;
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
                    case "audit":
                        btnAudit();
                        break;
                    case "unaudit":
                        btnUnAudit();
                        break;
                    case "alter":
                        btnPrint();
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
                    gridView1.FocusedRowHandle -= 1;
                }
                catch { }

                SaveFileDialog sa = new SaveFileDialog();
                sa.Filter = "Excel文件2003|*.xls";
                sa.FileName = "不良品列表";

                DialogResult d = sa.ShowDialog();
                if (d == DialogResult.OK)
                {
                    string sPath = sa.FileName;

                    if (sPath.Trim() != string.Empty)
                    {
                        gridView1.ExportToXls(sPath);
                        MessageBox.Show("导出列表成功！\n路径：" + sPath);
                    }
                }
            }
            catch (Exception ee)
            {
                throw new Exception("导出列表失败：" + ee.Message);
            }
        }

        private void btnSel()
        {
            GetGridView();
        }

        private void btnPrint()
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                }
                catch { }

                if (txtVenName.Text.Trim() == "")
                {
                    if (DialogResult.No == MessageBox.Show("请输入表头供应商，否则打印将无法显示供应商信息\n是否继续？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk))
                    {
                        return;
                    }
                }

                RepQMREJECT rep = new RepQMREJECT();

                int iRow = 0;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "√")
                    {
                        iRow += 1;
                        DataRow dr = rep.dataSet1.Tables[0].NewRow();
                        dr["Column9"] = iRow;
                        dr["Column1"] = gridView1.GetRowCellValue(i, gridColCREJECTCODE).ToString().Trim();
                        dr["Column2"] = gridView1.GetRowCellValue(i, gridColDCHECKDATE).ToString().Trim();
                        dr["Column3"] = gridView1.GetRowCellValue(i, gridColSOURCECODE).ToString().Trim();
                        dr["Column4"] = gridView1.GetRowCellValue(i, gridColCINVCODE).ToString().Trim();
                        dr["Column11"] = gridView1.GetRowCellValue(i, gridColcInvName).ToString().Trim();
                        dr["Column5"] = gridView1.GetRowCellValue(i, gridColcInvStd).ToString().Trim();
                        dr["Column6"] = gridView1.GetRowCellValue(i, gridColFQUANTITY).ToString().Trim();
                        dr["Column12"] = gridView1.GetRowCellValue(i, gridColCSCRAPDISNAME).ToString().Trim();
                        dr["Column13"] = gridView1.GetRowCellValue(i, gridColCCHECKPERSON).ToString().Trim();
                        dr["Column14"] = gridView1.GetRowCellValue(i, gridColCPOCODE).ToString().Trim();

                        rep.dataSet1.Tables[0].Rows.Add(dr);
                    }
                }

                DataTable dt2 = rep.dataSet1.Tables[1];
                DataRow dRowTe = dt2.NewRow();
                dRowTe["Column1"] = "供应商：" + txtVenName.Text.Trim();
                dRowTe["Column2"] = "厂商：                                                        仓库：                                                        制单人：" + FrameBaseFunction.ClsBaseDataInfo.sUserName;
                dt2.Rows.Add(dRowTe);
                //rep.PageHeight = 2200;
                //rep.PageWidth = 1400;
                //rep.Landscape = true;

                rep.ShowPreview();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载打印失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUnAudit()
        {
            if (radioUnAudit.Checked)
            {
                MessageBox.Show("当前是未审核列表，无需弃审单据！");
                return;
            }

            ArrayList aList = new ArrayList();
            string sSQL = "";

            string sQty = ""; 
            string sNum = "";
            string sTxt = "";

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string sCode = gridView1.GetRowCellValue(i, gridColCREJECTCODE).ToString().Trim();
                if (gridView1.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "√")
                {

                    sSQL = "select * from @u8.rdrecords01 where iRejectIds in (select autoid from @u8.QMREJECTVOUCHER q inner join @u8.QMREJECTVOUCHERS qs on q.[ID] = qs.[ID] where CREJECTCODE = '" + sCode + "')";
                    DataTable dtQM = clsSQLCommond.ExecQuery(sSQL);
                    if (dtQM == null || dtQM.Rows.Count > 0)
                    {
                        sTxt = sTxt + sCode + ",";
                    }
                    else
                    {
                        sQty = gridView1.GetRowCellValue(i, gridColFQUANTITY).ToString().Trim();
                        sNum = gridView1.GetRowCellValue(i, gridColFNUM).ToString().Trim();
                        if (sNum == "")
                            sNum = "0";

                        sSQL = "select isnull(IVERIFYSTATE,0) from @u8.QMREJECTVOUCHER  where CREJECTCODE = '" + sCode + "'";
                        DataTable dtTemp = clsSQLCommond.ExecQuery(sSQL);
                        if (Convert.ToInt32(dtTemp.Rows[0][0]) == 0)
                        {
                            continue;
                        }

                        sSQL = "update @u8.QMRejectVoucher set DVERIFYDATE = null,IVERIFYSTATE = 0,DVERIFYTIME = null,CVERIFIER = null " +
                                "where CREJECTCODE = '" + sCode + "'";
                        aList.Add(sSQL);

                        if (gridView1.GetRowCellValue(i, gridColCSCRAPDISNAME).ToString().Trim() == "拒收")  //报废不需要本语句
                        {
                            sSQL = "Update @u8.CurrentStock Set fInQuantity=fInQuantity+" + sQty + " ,fInNum=fInNum+" + sNum + " " +
                                    "Where cWhcode=N'" + gridView1.GetRowCellValue(i, gridColcWhCode).ToString().Trim() + "' And cInvCode=N'" + gridView1.GetRowCellValue(i, gridColCINVCODE).ToString().Trim() + "' And Isnull(cFree1,N'')=N'' And Isnull(cFree2,N'')=N'' And Isnull(cFree3,N'')=N'' And Isnull(cFree4,N'')=N'' And Isnull(cFree5,N'')=N'' And Isnull(cFree6,N'')=N'' And Isnull(cFree7,N'')=N'' And Isnull(cFree8,N'')=N'' And Isnull(cFree9,N'')=N'' And Isnull(cFree10,N'')=N'' And Isnull(cBatch,N'')=N'' and isodid =N'' and isotype =0 and isnull(cvmivencode,'') =N'' ";
                            aList.Add(sSQL);
                        }

                        if (gridView1.GetRowCellValue(i, gridColCSCRAPDISNAME).ToString().Trim() == "拒收")
                        {
                            sSQL = "UPDATE @u8.Pu_ArrivalVouchs SET fValidQuantity=ISNULL(fValidQuantity,0)+0,fValidNum=ISNULL(fValidNum,0)+0," +
                                        "fDegradeQuantity=ISNULL(fDegradeQuantity,0)+0,fDegradeNum=ISNULL(fDegradeNum,0)+0," +
                                        "fRealQuantity = ISNULL(fValidQuantity,0)+0 + ISNULL(fInValidQuantity,0)+0,fRealNum=ISNULL(fValidNum,0)+0 +ISNULL(fInValidNum,0)+0," +
                                        "fRefuseQuantity=ISNULL(fRefuseQuantity,0)-" + sQty + ",fRefuseNum=ISNULL(fRefuseNum,0)-" + sNum + "," +
                                        "fInValidQuantity=ISNULL(fInValidQuantity,0)+0,fInValidNum=ISNULL(fInValidNum,0)+0 " +
                                    "WHERE @u8.Pu_ArrivalVouchs.AutoID=" + gridView1.GetRowCellValue(i, gridColSOURCEAUTOID).ToString().Trim(); ;
                            aList.Add(sSQL);
                        }
                        if (gridView1.GetRowCellValue(i, gridColCSCRAPDISNAME).ToString().Trim() == "报废")
                        {
                            sSQL = "UPDATE @u8.Pu_ArrivalVouchs SET fValidQuantity=ISNULL(fValidQuantity,0)+0,fValidNum=ISNULL(fValidNum,0)+0, " +
                                  "     fDegradeQuantity=ISNULL(fDegradeQuantity,0)+0,fDegradeNum=ISNULL(fDegradeNum,0)+0, " +
                                  "     fRealQuantity = ISNULL(fValidQuantity,0)+0 + ISNULL(fInValidQuantity,0)-" + sQty + ",fRealNum=ISNULL(fValidNum,0)+0 +ISNULL(fInValidNum,0)-" + sNum.ToString().Trim() + ", " +
                                  "     fRefuseQuantity=ISNULL(fRefuseQuantity,0)+0,fRefuseNum=ISNULL(fRefuseNum,0)+0, " +
                                  "     fInValidQuantity=ISNULL(fInValidQuantity,0)-" + sQty + ",fInValidNum=ISNULL(fInValidNum,0)-" + sNum.ToString().Trim() + "  " +
                                  " WHERE @u8.Pu_ArrivalVouchs.AutoID=" + gridView1.GetRowCellValue(i, gridColSOURCEAUTOID).ToString().Trim();
                            aList.Add(sSQL);
                        }

                        if (gridView1.GetRowCellValue(i, gridColCSCRAPDISNAME).ToString().Trim() == "降级")
                        {
                            sSQL = "UPDATE @u8.Pu_ArrivalVouchs SET fValidQuantity=ISNULL(fValidQuantity,0)-" + sQty + ",fValidNum=ISNULL(fValidNum,0)-" + sNum.ToString().Trim() + ", " +
                                   "     fDegradeQuantity=ISNULL(fDegradeQuantity,0)-" + sQty + ",fDegradeNum=ISNULL(fDegradeNum,0)-" + sNum.ToString().Trim() + ", " +
                                   "     fRealQuantity = ISNULL(fValidQuantity,0)-" + sQty + " + ISNULL(fInValidQuantity,0)+0,fRealNum=ISNULL(fValidNum,0)-" + sNum.ToString().Trim() + " +ISNULL(fInValidNum,0)+0, " +
                                   "     fRefuseQuantity=ISNULL(fRefuseQuantity,0)-" + sQty + ",fRefuseNum=ISNULL(fRefuseNum,0)-" + sNum.ToString().Trim() + ", " +
                                   "     fInValidQuantity=ISNULL(fInValidQuantity,0)+0,fInValidNum=ISNULL(fInValidNum,0)+0  " +
                                   " WHERE @u8.Pu_ArrivalVouchs.AutoID=" + gridView1.GetRowCellValue(i, gridColSOURCEAUTOID).ToString().Trim();
                            aList.Add(sSQL);
                        }

                        if (gridView1.GetRowCellValue(i, gridColCSCRAPDISNAME).ToString().Trim() == "拒收" && gridView1.GetRowCellValue(i, gridColiPOsID).ToString().Trim() != "")
                        {
                            if (gridView1.GetRowCellValue(i, gridColcbustype).ToString().Trim() == "普通采购")
                            {
                                sSQL = "UPDATE @u8.Po_Podetails SET iArrQTY=CONVERT(DECIMAL(20,6),ISNULL(iArrQTY,0)) + " + sQty + " ,iArrNum=CONVERT(DECIMAL(20,6),ISNULL(iArrNum,0)) + " + sNum + " ," +
                                            "@u8.Po_Podetails.iArrMoney=ISNULL(@u8.Po_Podetails.iArrMoney,0)- (case when isnull(@u8.pu_arrivalvouchs.iquantity,0)=0 then @u8.pu_arrivalvouchs.iorisum else (@u8.pu_arrivalvouchs.iorisum/ @u8.pu_arrivalvouchs.iquantity)*(-" + sQty + ")  end), " +
                                            "fPoRefuseQuantity=ISNULL(fPoRefuseQuantity,0)-" + sQty + ",fPORefuseNum=ISNULL(fPORefuseNum,0)-" + sNum + " , " +
                                            "fPoValidQuantity=ISNULL(fPoValidQuantity,0)+0,fPoValidnum=ISNULL(fPoValidnum,0)+0 ," +
                                            "@u8.Po_Podetails.iNatArrMoney=ISNULL(@u8.Po_Podetails.iNatArrMoney,0)- (case when isnull(@u8.pu_arrivalvouchs.iquantity,0)=0 then @u8.pu_arrivalvouchs.isum else (@u8.pu_arrivalvouchs.isum/ @u8.pu_arrivalvouchs.iquantity)*(-" + sQty + ") end) " +
                                       "from @u8.Po_Podetails inner join @u8.pu_arrivalvouchs on @u8.pu_arrivalvouchs.iposid=@u8.Po_Podetails.id   " +
                                       "Where @u8.Po_Podetails.id= " + gridView1.GetRowCellValue(i, gridColiPOsID).ToString().Trim() + " and  @u8.Pu_ArrivalVouchs.AutoID=" + gridView1.GetRowCellValue(i, gridColSOURCEAUTOID).ToString().Trim();
                                aList.Add(sSQL);
                            }
                            if (gridView1.GetRowCellValue(i, gridColcbustype).ToString().Trim() == "委外加工")
                            {
                                sSQL = "UPDATE @u8.OM_MODetails SET iArrQTY=CONVERT(DECIMAL(20,6),ISNULL(iArrQTY,0)) + " + sQty + " ,iArrNum=CONVERT(DECIMAL(20,6),ISNULL(iArrNum,0)) + " + sNum + " ," +
                                       "    @u8.OM_MODetails.iArrMoney=ISNULL(@u8.OM_MODetails.iArrMoney,0)- (case when isnull(@u8.pu_arrivalvouchs.iquantity,0)=0 then @u8.pu_arrivalvouchs.iorisum else (@u8.pu_arrivalvouchs.iorisum/ @u8.pu_arrivalvouchs.iquantity)*-" + sQty + " end), " +
                                       "    @u8.OM_MODetails.iNatArrMoney=ISNULL(@u8.OM_MODetails.iNatArrMoney,0)- (case when isnull(@u8.pu_arrivalvouchs.iquantity,0)=0 then @u8.pu_arrivalvouchs.isum else (@u8.pu_arrivalvouchs.isum/ @u8.pu_arrivalvouchs.iquantity)*-" + sQty + " end) " +
                                       "from @u8.OM_MODetails inner join @u8.pu_arrivalvouchs on @u8.pu_arrivalvouchs.iposid=@u8.OM_MODetails.MODetailsID   " +
                                       "Where @u8.OM_MODetails.MODetailsID= " + gridView1.GetRowCellValue(i, gridColiPOsID).ToString().Trim() + " and  @u8.Pu_ArrivalVouchs.AutoID=" + gridView1.GetRowCellValue(i, gridColSOURCEAUTOID).ToString().Trim(); 
                                aList.Add(sSQL);
                            }
                        }
                    }
                }
            }
            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("单据弃审成功！");
                GetGridView();
            }
            if (sTxt.Trim() != "")
            {
                FrmMsgBox fMsgBos = new FrmMsgBox();
                fMsgBos.Text = "弃审失败！";
                if (sTxt.Trim() != "")
                {
                    sTxt = "被入库单引用，不能弃审：" + sTxt;
                }
                fMsgBos.richTextBox1.Text = sTxt;
                fMsgBos.ShowDialog();
            }
        }

        private void btnAudit()
        {
            if (radioAudit.Checked)
            {
                MessageBox.Show("当前是审核列表，无需审核单据！");
                return;
            }
            string sQty = "";
            string sNum = ""; 

            ArrayList aList = new ArrayList();
            string sSQL = "";

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string sCode = gridView1.GetRowCellValue(i, gridColCREJECTCODE).ToString().Trim();
                if (gridView1.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "√")
                {
                    sQty = gridView1.GetRowCellValue(i, gridColFQUANTITY).ToString().Trim();
                    sNum = gridView1.GetRowCellValue(i, gridColFNUM).ToString().Trim();
                    if (sNum == "")
                        sNum = "0";

                    sSQL = "select isnull(IVERIFYSTATE,0) from @u8.QMREJECTVOUCHER  where CREJECTCODE = '" + sCode + "'";
                    DataTable dtTemp = clsSQLCommond.ExecQuery(sSQL);
                    if (Convert.ToInt32(dtTemp.Rows[0][0]) == 1)
                    {
                        continue;
                    }

                    sSQL = "update @u8.QMREJECTVOUCHER set DVERIFYDATE = '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "',IVERIFYSTATE = 1," +
                               " DVERIFYTIME = '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "',CVERIFIER = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "' " +
                           "where CREJECTCODE = '" + sCode + "'";
                    aList.Add(sSQL);

                    if (gridView1.GetRowCellValue(i, gridColCSCRAPDISNAME).ToString().Trim() == "拒收")//降级，报废不需要本语句
                    {
                        sSQL = "Update @u8.CurrentStock Set fInQuantity=fInQuantity-" + sQty + " ,fInNum=fInNum-" + sNum + " " +
                               " Where cWhcode=N'" + gridView1.GetRowCellValue(i, gridColcWhCode).ToString().Trim() + "' And cInvCode=N'" + gridView1.GetRowCellValue(i, gridColCINVCODE).ToString().Trim() + "' And Isnull(cFree1,N'')=N'' And Isnull(cFree2,N'')=N'' And Isnull(cFree3,N'')=N'' And Isnull(cFree4,N'')=N'' And Isnull(cFree5,N'')=N'' And Isnull(cFree6,N'')=N'' And Isnull(cFree7,N'')=N'' And Isnull(cFree8,N'')=N'' And Isnull(cFree9,N'')=N'' And Isnull(cFree10,N'')=N'' And Isnull(cBatch,N'')=N'' and isodid =N'' and isotype =0 and isnull(cvmivencode,'') =N'' ";
                        aList.Add(sSQL);
                    }

                    if (gridView1.GetRowCellValue(i, gridColCSCRAPDISNAME).ToString().Trim() == "拒收")
                    {
                        sSQL = "UPDATE @u8.Pu_ArrivalVouchs SET fValidQuantity=ISNULL(fValidQuantity,0)+0,fValidNum=ISNULL(fValidNum,0)+0, " +
                               "     fDegradeQuantity=ISNULL(fDegradeQuantity,0)+0,fDegradeNum=ISNULL(fDegradeNum,0)+0, " +
                               "     fRealQuantity = ISNULL(fValidQuantity,0)+0 + ISNULL(fInValidQuantity,0)+0,fRealNum=ISNULL(fValidNum,0)+0 +ISNULL(fInValidNum,0)+0, " +
                               "     fRefuseQuantity=ISNULL(fRefuseQuantity,0)+" + sQty + ",fRefuseNum=ISNULL(fRefuseNum,0)+" + sNum.ToString().Trim() + ", " +
                               "     fInValidQuantity=ISNULL(fInValidQuantity,0)+0,fInValidNum=ISNULL(fInValidNum,0)+0  " +
                               " WHERE @u8.Pu_ArrivalVouchs.AutoID=" + gridView1.GetRowCellValue(i, gridColSOURCEAUTOID).ToString().Trim();
                        aList.Add(sSQL);
                    }
                    if (gridView1.GetRowCellValue(i, gridColCSCRAPDISNAME).ToString().Trim() == "报废")
                    {
                        sSQL = "UPDATE @u8.Pu_ArrivalVouchs SET fValidQuantity=ISNULL(fValidQuantity,0)+0,fValidNum=ISNULL(fValidNum,0)+0, " +
                               "     fDegradeQuantity=ISNULL(fDegradeQuantity,0)+0,fDegradeNum=ISNULL(fDegradeNum,0)+0, " +
                               "     fRealQuantity = ISNULL(fValidQuantity,0)+0 + ISNULL(fInValidQuantity,0)+" + sQty + ",fRealNum=ISNULL(fValidNum,0)+0 +ISNULL(fInValidNum,0)+"+ sNum.ToString().Trim() + ", " +
                               "     fRefuseQuantity=ISNULL(fRefuseQuantity,0)+0,fRefuseNum=ISNULL(fRefuseNum,0)+0, " +
                               "     fInValidQuantity=ISNULL(fInValidQuantity,0)+" + sQty + ",fInValidNum=ISNULL(fInValidNum,0)+" + sNum.ToString().Trim() + "  " +
                               " WHERE @u8.Pu_ArrivalVouchs.AutoID=" + gridView1.GetRowCellValue(i, gridColSOURCEAUTOID).ToString().Trim();
                        aList.Add(sSQL);
                    }
                    if (gridView1.GetRowCellValue(i, gridColCSCRAPDISNAME).ToString().Trim() == "降级")
                    {
                        sSQL = "UPDATE @u8.Pu_ArrivalVouchs SET fValidQuantity=ISNULL(fValidQuantity,0)+" + sQty + ",fValidNum=ISNULL(fValidNum,0)+" + sNum.ToString().Trim() + ", " +
                               "     fDegradeQuantity=ISNULL(fDegradeQuantity,0)+" + sQty + ",fDegradeNum=ISNULL(fDegradeNum,0)+" + sNum.ToString().Trim() + ", " +
                               "     fRealQuantity = ISNULL(fValidQuantity,0)+" + sQty + " + ISNULL(fInValidQuantity,0)+0,fRealNum=ISNULL(fValidNum,0)+" + sNum.ToString().Trim() + " +ISNULL(fInValidNum,0)+0, " +
                               "     fRefuseQuantity=ISNULL(fRefuseQuantity,0)+" + sQty + ",fRefuseNum=ISNULL(fRefuseNum,0)+" + sNum.ToString().Trim() + ", " +
                               "     fInValidQuantity=ISNULL(fInValidQuantity,0)+0,fInValidNum=ISNULL(fInValidNum,0)+0  " +
                               " WHERE @u8.Pu_ArrivalVouchs.AutoID=" + gridView1.GetRowCellValue(i, gridColSOURCEAUTOID).ToString().Trim();
                        aList.Add(sSQL);
                    }

                    if (gridView1.GetRowCellValue(i, gridColiPOsID).ToString().Trim() != "" && gridView1.GetRowCellValue(i, gridColiPOsID).ToString().Trim() != "")
                    {
                        if (gridView1.GetRowCellValue(i, gridColcbustype).ToString().Trim() == "普通采购")
                        {
                            sSQL = "UPDATE @u8.Po_Podetails SET iArrQTY=CONVERT(DECIMAL(20,6),ISNULL(iArrQTY,0)) - " + sQty + " ,iArrNum=CONVERT(DECIMAL(20,6),ISNULL(iArrNum,0)) - " + sNum + " , " +
                                   "    @u8.Po_Podetails.iArrMoney=ISNULL(@u8.Po_Podetails.iArrMoney,0)- (case when isnull(@u8.pu_arrivalvouchs.iquantity,0)=0 then @u8.pu_arrivalvouchs.iorisum else (@u8.pu_arrivalvouchs.iorisum/ @u8.pu_arrivalvouchs.iquantity)*" + sQty + " end),  " +
                                   "    fPoRefuseQuantity=ISNULL(fPoRefuseQuantity,0)+" + sQty + ",fPORefuseNum=ISNULL(fPORefuseNum,0)+" + sNum + " , " +
                                   "    fPoValidQuantity=ISNULL(fPoValidQuantity,0)+0,fPoValidnum=ISNULL(fPoValidnum,0)+0 , " +
                                   "    @u8.Po_Podetails.iNatArrMoney=ISNULL(@u8.Po_Podetails.iNatArrMoney,0)- (case when isnull(@u8.pu_arrivalvouchs.iquantity,0)=0 then @u8.pu_arrivalvouchs.isum else (@u8.pu_arrivalvouchs.isum/ @u8.pu_arrivalvouchs.iquantity)*" + sQty + " end) " +
                                   "from @u8.Po_Podetails inner join @u8.pu_arrivalvouchs on @u8.pu_arrivalvouchs.iposid=@u8.Po_Podetails.id    " +
                                   "Where @u8.Po_Podetails.id= " + gridView1.GetRowCellValue(i, gridColiPOsID).ToString().Trim() + " and  @u8.Pu_ArrivalVouchs.AutoID=" + gridView1.GetRowCellValue(i, gridColSOURCEAUTOID).ToString().Trim();
                            aList.Add(sSQL);
                        }
                        if (gridView1.GetRowCellValue(i, gridColcbustype).ToString().Trim() == "委外加工")
                        {
                            sSQL = "UPDATE @u8.OM_MODetails SET iArrQTY=CONVERT(DECIMAL(20,6),ISNULL(iArrQTY,0)) - " + sQty + " ,iArrNum=CONVERT(DECIMAL(20,6),ISNULL(iArrNum,0)) - " + sNum + " ," +
                                   "    @u8.OM_MODetails.iArrMoney=ISNULL(@u8.OM_MODetails.iArrMoney,0)- (case when isnull(@u8.pu_arrivalvouchs.iquantity,0)=0 then @u8.pu_arrivalvouchs.iorisum else (@u8.pu_arrivalvouchs.iorisum/ @u8.pu_arrivalvouchs.iquantity)*" + sQty + " end), " +
                                   "    @u8.OM_MODetails.iNatArrMoney=ISNULL(@u8.OM_MODetails.iNatArrMoney,0)- (case when isnull(@u8.pu_arrivalvouchs.iquantity,0)=0 then @u8.pu_arrivalvouchs.isum else (@u8.pu_arrivalvouchs.isum/ @u8.pu_arrivalvouchs.iquantity)*" + sQty + " end) " +
                                   "from @u8.OM_MODetails inner join @u8.pu_arrivalvouchs on @u8.pu_arrivalvouchs.iposid=@u8.OM_MODetails.MODetailsID   " +
                                   "Where @u8.OM_MODetails.MODetailsID= " + gridView1.GetRowCellValue(i, gridColiPOsID).ToString().Trim() + " and  @u8.Pu_ArrivalVouchs.AutoID=" + gridView1.GetRowCellValue(i, gridColSOURCEAUTOID).ToString().Trim();
                            aList.Add(sSQL);
                        }
                    }
                }
            }
            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("单据审核成功！");
                GetGridView();
            }
        }

        private void GetGridView()
        {
            try
            {
                string sSQL = @"
select '' as bChoose,c.CPOCODE,c.cDefine13,c.CMAKER,c.cWhCode,v.cVenName,CREJECTCODE,DCHECKDATE,SOURCECODE,
            SOURCEAUTOID,c.CINVCODE,cInvName,cInvStd,FQUANTITY,FNUM,FQUANTITY,CSCRAPDISNAME,CCHECKPERSON,cPersonName,iPOsID,
            u.cComUnitName,u2.cComUnitName as cComUnitName2,pArr.cbustype,c.CVERIFIER,c.DVERIFYDATE 
        ,Pa.cItemCode
from @u8.QMREJECTVOUCHER c inner join @u8.QMREJECTVOUCHERS cs on c.[id] = cs.[id] 
    left join @u8.QMSCRAPDISPOSE q on q.CSCRAPDISCODE = cs.CSCRAPDISCODE 
    inner join @u8.Inventory i on i.cInvCode = c.CINVCODE 
    left join @u8.Person  p on p.cPersonCode = CCHECKPERSON 
    left join @u8.Pu_ArrivalVouchs pA on pA.Autoid = SOURCEAUTOID 
    left join @u8.Pu_ArrivalVouch pArr on pArr.[ID] = pA.[ID] 
    left join @u8.Vendor v on v.cVenCode = c.CVENCODE 
    left join @u8.ComputationUnit u on u.cComunitCode = i.cComUnitCode 
    left join @u8.ComputationUnit u2 on u2.cComunitCode = c.CUNITID
";
                if (radioAudit.Checked)
                    sSQL = sSQL + " where isnull(c.IVERIFYSTATE,0) = 1";
                if (radioUnAudit.Checked)
                    sSQL = sSQL + " where isnull(c.IVERIFYSTATE,0) = 0";

                if (lookUpEditQM.EditValue != null && lookUpEditQM.EditValue.ToString().Trim() != "")
                {
                    sSQL = sSQL + " and CSCRAPDISNAME = '" + lookUpEditQM.Text.Trim() + "' ";
                }

                if (txtVenCode.Text.Trim() != string.Empty)
                {
                    sSQL = sSQL + " and c.CVENCODE = '" + txtVenCode.Text.Trim() + "' ";
                }

                if (lookUpEdit1.Text.Trim() != "")
                {
                    sSQL = sSQL + " and c.CREJECTCODE >= '" + lookUpEdit1.Text.Trim() + "' ";
                }
                if (lookUpEdit2.Text.Trim() != "")
                {
                    sSQL = sSQL + " and c.CREJECTCODE <= '" + lookUpEdit2.Text.Trim() + "' ";
                }

                if (txtVenCode.Enabled == false)
                {
                    sSQL = sSQL + " and CSCRAPDISNAME = '拒收' ";
                }

                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                gridControl1.DataSource = dt;

                chkAll.Checked = false;
            }
            catch (Exception ee)
            {
                gridControl1.DataSource = null;
                MessageBox.Show("获得列表失败：" + ee.Message);
            }
        }

        private void GetCode()
        {
            string sSQL = "select CREJECTCODE as iID from @u8.QMREJECTVOUCHER order by CREJECTCODE";
            DataTable dt = clsGetSQL.GetLookUpEdit(sSQL);
            lookUpEdit1.Properties.DataSource = dt;
            lookUpEdit2.Properties.DataSource = dt;
            lookUpEdit1.Properties.ReadOnly = false;
            lookUpEdit2.Properties.ReadOnly = false;

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

        private void txtVenCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {     
            FrmVenInfo fVen = new FrmVenInfo(txtVenCode.Text.Trim());
            if (DialogResult.OK == fVen.ShowDialog())
            {
                txtVenCode.Text = fVen.sVenCode;
                txtVenName.Text = fVen.sVenName;
            }
        }

        private void radioUnAudit_CheckedChanged(object sender, EventArgs e)
        {
            GetGridView();
        }

        private void radioAudit_CheckedChanged(object sender, EventArgs e)
        {
            GetGridView();
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEdit2.Text = lookUpEdit1.Text;
            GetGridView();
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

                string sCode = gridView1.GetRowCellValue(iRow, gridColCREJECTCODE).ToString().Trim();
                if (gridView1.GetRowCellValue(iRow, gridColbChoose).ToString().Trim() == "")
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (gridView1.GetRowCellValue(i, gridColCREJECTCODE).ToString().Trim() == sCode)
                        {
                            gridView1.SetRowCellValue(i, gridColbChoose, "√");
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (gridView1.GetRowCellValue(i, gridColCREJECTCODE).ToString().Trim() == sCode)
                        {
                            gridView1.SetRowCellValue(i, gridColbChoose, "");
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    string s1 = gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["bChoose"]).ToString().Trim();
                    if (s1 == "√")
                    {
                        e.Appearance.BackColor = Color.MediumSeaGreen;
                    }
                }
            }
            catch
            { }
        }

        private void lookUpEditQM_EditValueChanged(object sender, EventArgs e)
        {
            GetGridView();
        }

        private void lookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {
            GetGridView();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAll.Checked)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        gridView1.SetRowCellValue(i, gridColbChoose, "√");
                    }
                }
                else
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        gridView1.SetRowCellValue(i, gridColbChoose, "");
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("错误：" + ee.Message);
            }
        }

        private void txtVenCode_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtVenCode.Text.Trim() == "")
                {
                    txtVenName.Text = "";
                    return;
                }
                DataTable dt = GetVendor(txtVenCode.Text.Trim());
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtVenName.Text = dt.Rows[0]["iText"].ToString().Trim();
                    GetGridView();
                }
                else
                {
                    txtVenCode.Text = "";
                    txtVenName.Text = "";
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得供应商信息失败！ " + ee.Message);
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
    }
}