using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;
using FrameBaseFunction;
using System.Data.SqlClient;

namespace SaleOrder
{
    public partial class Frm订单评审_下达采购计划 : FrameBaseFunction.Frm列表窗体模板
    {
        public Frm订单评审_下达采购计划()
        {
            InitializeComponent();

            #region 禁止用户调整表格
            gridView明细.OptionsMenu.EnableColumnMenu = false;
            gridView明细.OptionsMenu.EnableFooterMenu = false;
            gridView明细.OptionsMenu.EnableGroupPanelMenu = false;
            gridView明细.OptionsMenu.ShowAutoFilterRowItem = false;
            gridView明细.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            gridView明细.OptionsMenu.ShowGroupSortSummaryItems = false;
            gridView明细.OptionsMenu.ShowGroupSummaryEditorItem = false;
            gridView明细.OptionsMenu.ShowAddNewSummaryItem  = DevExpress.Utils.DefaultBoolean.False;
            gridView明细.OptionsBehavior.FocusLeaveOnTab = true;
            gridView明细.OptionsCustomization.AllowColumnMoving = false;
            //gridView合并.OptionsCustomization.

            #endregion

            sLayoutHeadPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Head.xml";
            sLayoutGridPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Grid.xml";

            if (File.Exists(sLayoutHeadPath))
                layoutControl1.RestoreLayoutFromXml(sLayoutHeadPath);

            if (File.Exists(sLayoutGridPath))
            {
                gridControl明细.MainView.RestoreLayoutFromXml(sLayoutGridPath);
            }

            dtBingGrid = new DataTable();
            dtBingHead = new DataTable();
        }

       

        #region 按钮操作
        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "addrow":
                        btnAddRow();
                        break;
                    case "alter":
                        btnAlter();
                        break;
                    case "audit":
                        btnAudit();
                        break;
                    case "add":
                        btnAdd();
                        break;
                    case "del":
                        btnDel();
                        break;
                    case "delrow":
                        btnDelRow();
                        break;
                    case "edit":
                        btnEdit();
                        break;
                    case "export":
                        btnExport();
                        break;
                    case "first":
                        btnFirst();
                        break;
                    case "import":
                        btnImport();
                        break;
                    case "last":
                        btnLast();
                        break;
                    case "lock":
                        btnLock();
                        break;
                    case "next":
                        btnNext();
                        break;
                    case "prev":
                        btnPrev();
                        break;
                    case "print":
                        btnPrint();
                        break;
                    //case "printset":
                    //    btnPrintSet();
                    //    break;
                    case "refresh":
                        btnRefresh();
                        break;
                    case "save":
                        btnSave();
                        break;
                    case "sel":
                        btnSel();
                        break;
                    case "unaudit":
                        btnUnAudit();
                        break;
                    case "undo":
                        btnUnDo();
                        break;
                    case "unlock":
                        btnUnLock();
                        break;
                    case "open":
                        btnOpen();
                        break;
                    case "close":
                        btnClose();
                        break;
                    case "layout":
                        btnLayout(sBtnText);
                        break;
                    default:
                        break;
                }

                sState = sBtnName.ToLower();
            }
            catch (Exception ee)
            {
                throw new Exception(sBtnText + " 失败! \n\n原因:\n  " + ee.Message);
            }
        }

        DataTable dt评审 = new DataTable();

        private void btnAdd()
        {
           
        }

        #region 按钮模板

        ///// <summary>
        ///// 将表格中Lookup之类的保存ID的数据转换成Text用于打印
        ///// </summary>
        ///// <param name="dt"></param>
        ///// <returns></returns>
        private DataTable SetPrintData(DataTable dt)
        {
        //    DataTable dtState = (DataTable)ItemLookUpEditState.DataSource;
        //    DataColumn dc = new DataColumn();
        //    dc.ColumnName = "StateText";
        //    dt.Columns.Add(dc);
           
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        DataRow[] drState = dtState.Select("iID = '" + dt.Rows[i]["State"].ToString().Trim() + "'");
        //        if (drState.Length > 0)
        //        {
        //            dt.Rows[i]["StateText"] = drState[0]["State"];
        //        }

        //    }

            return dt;
        }

        /// <summary>
        /// 打印
        /// </summary>
        private void btnPrint()
        {
            try
            {
                gridView明细.FocusedRowHandle -= 1;
                gridView明细.FocusedRowHandle += 1;
            }
            catch { }

            base.dsPrint.Tables.Clear();
            DataTable dtGrid = SetPrintData(((DataTable)gridControl明细.DataSource).Copy());
            dtGrid.TableName = "dtGrid";

            base.dsPrint.Tables.Add(dtGrid);
            DataTable dtHead = dtBingHead.Copy();
            dtHead.TableName = "dtHead";
            base.dsPrint.Tables.Add(dtHead);
        }
        /// <summary>
        /// 输出
        /// </summary>
        private void btnExport()
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
                    gridView明细.ExportToXls(sF.FileName);
                    MessageBox.Show("导出Excel成功\n\t路径：" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnLayout(string sText)
        {
            if (layoutControl1 == null) return;
            if (sText == "布局")
            {
                //layoutControl1.ShowCustomizationForm();
                layoutControl1.AllowCustomizationMenu = true;
                base.toolStripMenuBtn.Items["Layout"].Text = "保存布局";

                gridView明细.OptionsMenu.EnableColumnMenu = true;
                gridView明细.OptionsMenu.EnableFooterMenu = true;
                gridView明细.OptionsMenu.EnableGroupPanelMenu = true;
                //gridView合并.OptionsMenu.ShowAddNewSummaryItem = true;
                gridView明细.OptionsMenu.ShowAutoFilterRowItem = true;
                gridView明细.OptionsMenu.ShowDateTimeGroupIntervalItems = true;
                gridView明细.OptionsMenu.ShowGroupSortSummaryItems = true;
                gridView明细.OptionsMenu.ShowGroupSummaryEditorItem = true;
                gridView明细.OptionsCustomization.AllowColumnMoving = true;
            }
            else
            {
                //layoutControl1.HideCustomizationForm();
                layoutControl1.AllowCustomizationMenu = false;
                gridView明细.OptionsMenu.EnableColumnMenu = false;
                gridView明细.OptionsMenu.EnableFooterMenu = false;
                gridView明细.OptionsMenu.EnableGroupPanelMenu = false;
                //gridView合并.OptionsMenu.ShowAddNewSummaryItem = false;
                gridView明细.OptionsMenu.ShowAutoFilterRowItem = false;
                gridView明细.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
                gridView明细.OptionsMenu.ShowGroupSortSummaryItems = false;
                gridView明细.OptionsMenu.ShowGroupSummaryEditorItem = false;
                gridView明细.OptionsCustomization.AllowColumnMoving = false;


                if (!Directory.Exists(base.sProPath + "\\layout"))
                    Directory.CreateDirectory(base.sProPath + "\\layout");

                base.toolStripMenuBtn.Items["Layout"].Text = "布局";

                DialogResult d = MessageBox.Show("是否保存?\n是：保存界面样式\n否：恢复默认界面样式,下次加载时将以默认样式打开\n", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
                if (d == DialogResult.Yes)
                {
                    layoutControl1.SaveLayoutToXml(sLayoutHeadPath);
                    gridControl明细.MainView.SaveLayoutToXml(sLayoutGridPath);
                }
                else if (d == DialogResult.No)
                {
                    if (File.Exists(sLayoutHeadPath))
                        File.Delete(sLayoutHeadPath);

                    if (File.Exists(sLayoutGridPath))
                        File.Delete(sLayoutGridPath);
                }
            }
        }
        #endregion

        /// <summary>
        /// 导入
        /// </summary>
        private void btnImport()
        {

        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void btnRefresh()
        {
            try
            {
                GetLookUp();

                GetSelList();

                btnLast();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private string sFrmSEL = "";

        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
            Frm订单评审_下达采购计划SEL fSel = new Frm订单评审_下达采购计划SEL();
            fSel.ShowDialog();
            if (fSel.DialogResult != DialogResult.OK)
            {
                throw new Exception("取消查询");
            }
            GetGrid(fSel.i销售订单ID);
        }

        /// <summary>
        /// 首页
        /// </summary>
        private void btnFirst()
        {
            try
            {
                if (dtSel == null || dtSel.Rows.Count < 1)
                {
                    throw new Exception("没有可以查看的单据");
                }

                iPage = 0;
                long i = Convert.ToInt64(dtSel.Rows[iPage]["销售订单ID"]);
                GetGrid(i);
                lPageInfo.Text = (iPage + 1).ToString() + "/" + dtSel.Rows.Count.ToString();
            }
            catch { }
        }
        /// <summary>
        /// 上页
        /// </summary>
        private void btnPrev()
        {
            try
            {
                if (dtSel == null || dtSel.Rows.Count < 1)
                {
                    throw new Exception("没有可以查看的单据");
                }

                if (iPage > 0)
                {
                    iPage -= 1;
                    long i = Convert.ToInt64(dtSel.Rows[iPage]["销售订单ID"]);
                    GetGrid(i);
                    lPageInfo.Text = (iPage + 1).ToString() + "/" + dtSel.Rows.Count.ToString();
                }
            }
            catch { }

        }
        /// <summary>
        /// 下页
        /// </summary>
        private void btnNext()
        {
            try
            {
                if (dtSel == null || dtSel.Rows.Count < 1)
                {
                    throw new Exception("没有可以查看的单据");
                }

                if (iPage < dtSel.Rows.Count - 1)
                {
                    iPage += 1;
                    long i = Convert.ToInt64(dtSel.Rows[iPage]["销售订单ID"]);
                    GetGrid(i);

                    lPageInfo.Text = (iPage + 1).ToString() + "/" + dtSel.Rows.Count.ToString();
                }
            }
            catch { }
        }

        /// <summary>
        /// 末页
        /// </summary>
        private void btnLast()
        {
            try
            {
                if (dtSel == null || dtSel.Rows.Count < 1)
                {
                    throw new Exception("没有可以查看的单据");
                }

                iPage = dtSel.Rows.Count - 1;

                long i = Convert.ToInt64(dtSel.Rows[iPage]["销售订单ID"]);
                GetGrid(i);
                lPageInfo.Text = (iPage + 1).ToString() + "/" + dtSel.Rows.Count.ToString();
            }
            catch { }
        }
        /// <summary>
        /// 锁定
        /// </summary>
        private void btnLock()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 解锁
        /// </summary>
        private void btnUnLock()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 增行
        /// </summary>
        private void btnAddRow()
        {
            gridView明细.AddNewRow();
        }
        /// <summary>
        /// 删行
        /// </summary>
        private void btnDelRow()
        {
            for (int i = gridView明细.RowCount - 1; i >= 0 ; i--)
            {
                if (gridView明细.IsRowSelected(i))
                {
                    gridView明细.DeleteRow(i);
                }
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {
            if (txt销售订单号.Text.Trim() == "")
            {
                throw new Exception("请选择需要修改的单据");
            }

            dt评审 = (DataTable)gridControl明细.DataSource;

            sState = "edit";
        }

        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {

        }

        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave()
        {
            try
            {
                gridView明细.FocusedRowHandle -= 1;
                gridView明细.FocusedRowHandle += 1;

                gridView合并.FocusedRowHandle -= 1;
                gridView合并.FocusedRowHandle += 1;
                aList = new System.Collections.ArrayList();
                string sErr = "";
                string sCode = "";

                if(txt外销订单号.Text.Trim() == "")
                {
                    throw new Exception("请选择单据");
                }

                sSQL = "select * from dbo.订单评审运算1  where 销售订单ID = " + txt销售订单ID.Text.Trim() + " and 帐套号 = '200'";
                DataTable dtErr = clsSQLCommond.ExecQuery(sSQL);
                if (dtErr == null || dtErr.Rows.Count < 1)
                {
                    throw new Exception("没有需要下达采购计划的单据");
                }
                if (dtErr.Rows.Count > 0)
                { 
                    if(dtErr.Rows[0]["审核人"].ToString().Trim() == "")
                        throw new Exception("尚未审核不能下达采购计划");
                    if (dtErr.Rows[0]["关闭人"].ToString().Trim() != "")
                        throw new Exception("已经关闭不能下达采购计划");
                    if (dtErr.Rows[0]["下达请购人"].ToString().Trim() != "")
                    {
                        sSQL = "select distinct cItemCode from @u8.PU_AppVouchs where cItemCode = '" + txt销售订单号.Text.Trim() + "'";
                        DataTable dtTemp = clsSQLCommond.ExecQuery(sSQL);
                        if (dtTemp != null && dtTemp.Rows.Count > 0)
                        {
                            throw new Exception("已经下达不能重复下达采购计划");
                        }
                        else
                        {
                            DialogResult d = MessageBox.Show("单据已经下达，但在U8中已经删除，是否重新下达", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                            if (d == DialogResult.No)
                            {
                                return;
                            }
                        }
                    }
                }

                #region 下达采购计划（采购请购单）

                //获得请购单主表框架
                sSQL = "select * from @u8.PU_AppVouch where 1=-1";
                DataTable dtPU_AppVouch = clsSQLCommond.ExecQuery(sSQL);
                //获得请购单子表框架
                sSQL = "select * from @u8.PU_AppVouchs  where 1=-1";
                DataTable dtPU_AppVouchs = clsSQLCommond.ExecQuery(sSQL);
                
                //获得最大单据号
                long iVouNumber;
                sSQL = "select isnull(max(cNumber),0) as Maxnumber From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='27' and cSeed = '" + ReturnObjectToDatetime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyy") + "'";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                iVouNumber = Convert.ToInt64(dt.Rows[0]["Maxnumber"]);

                bool bVouNumber = false;            //当月第一张单据
                if (iVouNumber == 0)
                {
                    bVouNumber = true;
                }

                //获得单据ID号
                long iID;
                long iIDDetail;
                sSQL = "select iFatherID,iChildID from UFSystem..UA_Identity where cAcc_Id = '200' and cVouchType = 'PuApp'";
                dt = clsSQLCommond.ExecQuery(sSQL);

                if (dt == null || dt.Rows.Count < 1)
                {
                    iID = 0;
                    iIDDetail = 0;
                }
                else
                {
                    iID = Convert.ToInt64(dt.Rows[0]["iFatherID"]);
                    iIDDetail = Convert.ToInt64(dt.Rows[0]["iChildID"]);
                }

                DataRow drPU_AppVouch = dtPU_AppVouch.NewRow();
                drPU_AppVouch["iVTid"] = "8171";
                iID += 1;
                drPU_AppVouch["ID"] = iID;
                iVouNumber += 1;
                drPU_AppVouch["cCode"] = GetPU_AppVouchCode(iVouNumber.ToString());
                drPU_AppVouch["dDate"] = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
              
                drPU_AppVouch["cDepCode"] = "802";
                drPU_AppVouch["cPersonCode"] = FrameBaseFunction.ClsBaseDataInfo.sUid;

                string sPerson = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                string sPerSQL = "select * from @u8.person where cPersonName = '" + sPerson + "' ";
                DataTable dtPer = clsSQLCommond.ExecQuery(sPerSQL);
                if (dtPer != null && dtPer.Rows.Count > 0)
                {
                    drPU_AppVouch["cDepCode"] = dtPer.Rows[0]["cDepCode"];
                    drPU_AppVouch["cPersonCode"] = dtPer.Rows[0]["cPersonCode"];
                }

                drPU_AppVouch["cPTCode"] = "01";
                drPU_AppVouch["cBusType"] = "普通采购";
                drPU_AppVouch["cMaker"] = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                drPU_AppVouch["cVerifier"] = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                drPU_AppVouch["cCloser"] = DBNull.Value;
                drPU_AppVouch["cDefine1"] = DBNull.Value;
                drPU_AppVouch["cDefine2"] = txt客户订单号.Text.Trim();
                drPU_AppVouch["cDefine11"] = txt外销订单号.Text.Trim();
                drPU_AppVouch["cMemo"] = "";
                drPU_AppVouch["cLocker"] = "";
                drPU_AppVouch["iverifystateex"] = 2;
                drPU_AppVouch["ireturncount"] = DBNull.Value;
                drPU_AppVouch["IsWfControlled"] = 0;
                drPU_AppVouch["cMakeTime"] = Get当前服务器时间();
                drPU_AppVouch["cModifyTime"] = DBNull.Value;
                drPU_AppVouch["cAuditTime"] = Get当前服务器时间();
                drPU_AppVouch["cAuditDate"] = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                drPU_AppVouch["cModifyDate"] = DBNull.Value;
                drPU_AppVouch["cReviser"] = DBNull.Value;
                dtPU_AppVouch.Rows.Add(drPU_AppVouch);

                for (int i = 0; i < gridView合并.RowCount; i++)
                {
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView合并.GetRowCellValue(i, gridCol本次下单数量)) == 0)
                        continue;

                    DataRow drPU_AppVouchs = dtPU_AppVouchs.NewRow();
                    drPU_AppVouchs["ID"] = iID;

                    iIDDetail += 1;
                    drPU_AppVouchs["AutoID"] = iIDDetail;
                    drPU_AppVouchs["cVenCode"] = DBNull.Value;
                    drPU_AppVouchs["cInvCode"] = gridView合并.GetRowCellValue(i, gridCol子件编码).ToString().Trim();
                    drPU_AppVouchs["fQuantity"] = gridView合并.GetRowCellValue(i, gridCol本次下单数量).ToString().Trim();
                    drPU_AppVouchs["fUnitPrice"] = DBNull.Value;
                    drPU_AppVouchs["iPerTaxRate"] = 17;
                    drPU_AppVouchs["fTaxPrice"] = DBNull.Value;
                    drPU_AppVouchs["fMoney"] = DBNull.Value;

                    DateTime d完成日期 = Convert.ToDateTime(gridView合并.GetRowCellValue(i, gridCol完成日期));
                    if (d完成日期 < DateTime.Today)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "需求日期不能早于今天\n";
                        continue;
                    }
                    drPU_AppVouchs["dRequirDate"] = gridView合并.GetRowCellValue(i, gridCol完成日期).ToString().Trim();
                    //drPU_AppVouchs["dArriveDate"] = gridView合并.GetRowCellValue(i, gridCol完成日期).ToString().Trim();
                    drPU_AppVouchs["iReceivedQTY"] = 0;
                    drPU_AppVouchs["cItem_class"] = "00";
                    drPU_AppVouchs["cItemCode"] = txt外销订单号.Text.Trim();
                    drPU_AppVouchs["CItemName"] = txt外销订单号.Text.Trim();
                    drPU_AppVouchs["bTaxCost"] = true;
                    drPU_AppVouchs["iPPartId"] = DBNull.Value;
                    drPU_AppVouchs["iPQuantity"] = DBNull.Value;
                    drPU_AppVouchs["iPTOSeq"] = DBNull.Value;
                    drPU_AppVouchs["cSource"] = DBNull.Value;
                    //drPU_AppVouchs["SoDId"] = txt销售订单子表ID.Text.Trim();
                    //drPU_AppVouchs["SoType"] = "1";
                    drPU_AppVouchs["iMrpsid"] = DBNull.Value;
                    drPU_AppVouchs["iRopsid"] = DBNull.Value;
                    drPU_AppVouchs["cbcloser"] = DBNull.Value;
                    if (gridView合并.GetRowCellValue(i, gridCol换算率1).ToString().Trim() != "")
                    {
                        //decimal d1 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView合并.GetRowCellValue(i, gridCol换算率1));
                        //decimal d2 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView合并.GetRowCellValue(i, gridCol本次下单数量1));
                        //d1 = decimal.Round(d1, 6);
                        //d2 = decimal.Round(d2, 6);
                        drPU_AppVouchs["fNum"] = gridView合并.GetRowCellValue(i, gridCol本次下单件数1).ToString().Trim();
                        drPU_AppVouchs["cUnitID"] = gridView合并.GetRowCellValue(i, gridCol子件辅助单位1).ToString().Trim();
                    }
                    drPU_AppVouchs["iReceivedNum"] = DBNull.Value;
                    drPU_AppVouchs["cPersonCodeExec"] = DBNull.Value;
                    drPU_AppVouchs["cDepCodeExec"] = DBNull.Value;
                    drPU_AppVouchs["iInvMPCost"] = DBNull.Value;
                    drPU_AppVouchs["cexch_name"] = "人民币";
                    drPU_AppVouchs["iExchRate"] = 1;
                    drPU_AppVouchs["iOriCost"] = DBNull.Value;
                    drPU_AppVouchs["iOriTaxCost"] = DBNull.Value;
                    drPU_AppVouchs["iOriMoney"] = DBNull.Value;
                    drPU_AppVouchs["iOriTaxPrice"] = DBNull.Value;
                    drPU_AppVouchs["iOriSum"] = DBNull.Value;
                    drPU_AppVouchs["iMoney"] = DBNull.Value;
                    drPU_AppVouchs["iTaxPrice"] = DBNull.Value;
                    drPU_AppVouchs["cdemandcode"] = DBNull.Value;
                    drPU_AppVouchs["cdetailsdemandmemo"] = DBNull.Value;

                    //评审ID号
                    drPU_AppVouchs["cDefine31"] = gridView合并.GetRowCellValue(i, gridCol评审ID).ToString().Trim();

                    dtPU_AppVouchs.Rows.Add(drPU_AppVouchs);
                }
                if (dtPU_AppVouchs.Rows.Count > 0)
                {
                    //更新最大单据号
                    if (bVouNumber)
                    {
                        sSQL = "insert into @u8.VoucherHistory(cardnumber,cContent,cContentRule,cSeed,cNumber,bEmpty) " +
                                "values('27','单据日期','年','" + ReturnObjectToDatetime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyy") + "','1',0)";
                        aList.Add(sSQL);
                    }
                    else
                    {
                        sSQL = "update @u8.VoucherHistory set cNumber = '" + iVouNumber + "' Where  CardNumber='27' and cSeed = '" + ReturnObjectToDatetime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyy") + "'";
                        aList.Add(sSQL);
                    }

                    //更新最大ID
                    sSQL = "update UFSystem..UA_Identity set iFatherID=" + iID + ",iChildID=" + iIDDetail + " where  cAcc_Id = '200' and cVouchType = 'PuApp'";
                    aList.Add(sSQL);

                    for (int i = 0; i < dtPU_AppVouch.Rows.Count; i++)
                    {
                        //生成委外订单表体
                        aList.Add(clsGetSQL.GetInsertSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "PU_AppVouch", dtPU_AppVouch, i));
                    }
                    for (int i = 0; i < dtPU_AppVouchs.Rows.Count; i++)
                    {
                        //生成委外订单表体
                        aList.Add(clsGetSQL.GetInsertSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "PU_AppVouchs", dtPU_AppVouchs, i));
                    }

                    sCode = sCode + "采购请购单：" + GetPU_AppVouchCode(iVouNumber.ToString()) + "\n";

                    sSQL = " update dbo.订单评审运算1 set 下达请购人 = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',下达请购日期 = getdate() where 销售订单ID = " + txt销售订单ID.Text.Trim() + " and 帐套号 = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3);
                    aList.Add(sSQL);

                }
                #endregion

                if (sErr.Trim().Length > 0)
                {
                    throw new Exception(sErr);
                }

                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);

                    GetSelList();
                    iPage = dtSel.Rows.Count - 1;
                    lPageInfo.Text = (iPage + 1).ToString() + "/" + dtSel.Rows.Count.ToString();


                    if (sCode.Trim() != "")
                    {
                        MsgBox("提示", "保存成功！\n合计执行语句:" + iCou + "条\n" + sCode);
                    }

                    sState = "save";
                }
                GetSelList();
            }
            catch (Exception ee)
            {
                MsgBox("提示", ee.Message);
            }
        }

        /// <summary>
        /// 撤销
        /// </summary>
        private void btnUnDo()
        {
            if (txt销售订单ID.Text.Trim() != "")
            {
                GetGrid(Convert.ToInt64(txt销售订单ID.Text));
            }
        }
        /// <summary>
        /// 审核
        /// </summary>
        private void btnAudit()
        {

        }
        /// <summary>
        /// 弃审
        /// </summary>
        private void btnUnAudit()
        {

        }
        /// <summary>
        /// 打开
        /// </summary>
        private void btnOpen()
        {
        }

        /// <summary>
        /// 关闭
        /// </summary>
        private void btnClose()
        {

        }

        /// <summary>
        /// 变更
        /// </summary>
        private void btnAlter()
        {
            string sSQL = "select * from dbo._LookUpDate where iType = 7";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            string sMail = "";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (sMail == "")
                    sMail = dt.Rows[i]["iText"].ToString().Trim();
                else
                {
                    sMail = sMail + ";" + dt.Rows[i]["iText"].ToString().Trim();
                }
            }
            string sHead = "外销订单采购计划已下达:" + txt外销订单号.Text.Trim();
            string sText = "外销订单" + txt外销订单号.Text.Trim() + "已经下达采购计划，请尽快评审。";
            try
            {
                ClseMail clseMail = new ClseMail();
                clseMail.MailSend(sMail, sHead, sText);
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message,"发送邮件失败");
            }
        }

        #endregion

        private void Frm订单评审_下达采购计划_Load(object sender, EventArgs e)
        {
            try
            {
                GetLookUp();

                GetSelList();

                btnLast();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void GetLookUp()
        {
            string sSQL = "select cInvCode,cInvName,cInvStd from @u8.Inventory order by cInvCode";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            DataRow drInv = dt.NewRow();
            drInv["cInvCode"] = "--";
            dt.Rows.Add(drInv);
            ItemLookUpEdit1物料编码.DataSource = dt;
            ItemLookUpEdit1物料名称.DataSource = dt;
            ItemLookUpEdit1物料规格.DataSource = dt;

            ItemLookUpEdit物料编码.DataSource = dt;
            ItemLookUpEdit物料名称.DataSource = dt;
            ItemLookUpEdit规格型号.DataSource = dt;

            sSQL = "select cCusCode,cCusName,cCusAbbName from @u8.Customer order by cCusCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            lookUpEdit客户.Properties.DataSource = dt;

            DataColumn dc = new DataColumn();
            dc.ColumnName = "iID";
            dt.Columns.Add(dc);
            DataRow dr = dt.NewRow();
            dr["iID"] = "采购";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["iID"] = "委外";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["iID"] = "自制";
            dt.Rows.Add(dr);
            ItemLookUpEdit子件属性.DataSource = dt;
            ItemLookUpEdit1子件属性.DataSource = dt;

            sSQL = "select cDepCode,cDepName from @u8.Department order by cDepCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit部门编码.DataSource = dt;
            ItemLookUpEdit部门名称.DataSource = dt;
            ItemLookUpEdit1部门编码.DataSource = dt;
            ItemLookUpEdit1部门名称.DataSource = dt;

            sSQL = "select cWhCode,cWhName from @u8.Warehouse  order by cWhCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit仓库编号.DataSource = dt;
            ItemLookUpEdit仓库名称.DataSource = dt;
            ItemLookUpEdit1仓库编码.DataSource = dt;
            ItemLookUpEdit1仓库名称.DataSource = dt;

            sSQL = "select * from @u8.ComputationUnit ";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit计量单位.DataSource = dt;
        }

        private void gridView评审计算_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                int i1 = ReturnObjectToInt(gridView明细.GetRowCellValue(e.RowHandle, gridCol销售订单行号));
                int i2 = i1%2;

                if (i2 == 0)
                {
                    e.Appearance.BackColor = Color.AliceBlue;
                }
                else
                {
                    e.Appearance.BackColor = Color.AntiqueWhite; 
                } 
            }
            catch
            { }
        }

      
        private void GetGrid(long i销售订单ID)
        {
            string sSQL = "select * from dbo.订单评审运算1 where 销售订单ID = " + i销售订单ID + " and 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim();
            DataTable dt订单评审运算1 = clsSQLCommond.ExecQuery(sSQL);

            sSQL = "select * from dbo.订单评审运算2 where 销售订单ID = " + i销售订单ID + " and 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim() + " order by iID";
            DataTable dt订单评审运算2 = clsSQLCommond.ExecQuery(sSQL);

            sSQL = @"
select a.*,b.iGroupType,b.cComUnitCode as 子件计量单位,b.cAssComUnitCode as 辅助单位 ,c.iInvExchRate
from dbo.订单评审运算3 a 
        left join @u8.Inventory b on a.子件编码 = b.cInvCode
        left join 
        (
        select a.id,b.cInvCode,min(b.iInvExchRate) as iInvExchRate from @u8.SO_SOMain a inner join @u8.SO_SODetails b on a.csocode = b.csocode group by  a.id,b.cInvCode
        )c on c.ID = a.销售订单ID and c.cInvCode = a.子件编码
where 销售订单ID = 111111 and 帐套号 = 222222 and 子件属性 = '采购'
order by 子件编码,完成日期,a.iID
";

                    sSQL = sSQL.Replace("111111", i销售订单ID.ToString());
                    sSQL = sSQL.Replace("222222", (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim());
            DataTable dt订单评审运算3 = clsSQLCommond.ExecQuery(sSQL);

            if (dt订单评审运算1 != null && dt订单评审运算1.Rows.Count > 0 && dt订单评审运算2 != null && dt订单评审运算2.Rows.Count > 0 && dt订单评审运算3 != null && dt订单评审运算3.Rows.Count > 0)
            {
                txt销售订单号.Text = dt订单评审运算1.Rows[0]["销售订单号"].ToString().Trim();
                txt外销订单号.Text = dt订单评审运算1.Rows[0]["外销订单号"].ToString().Trim();
                txt客户订单号.Text = dt订单评审运算1.Rows[0]["客户订单号"].ToString().Trim();
                lookUpEdit客户.EditValue = dt订单评审运算1.Rows[0]["客户编号"];
                txt备注.Text = dt订单评审运算1.Rows[0]["备注"].ToString().Trim();
                txt销售订单ID.Text = dt订单评审运算1.Rows[0]["销售订单ID"].ToString().Trim();
                txt评审备注.Text = dt订单评审运算1.Rows[0]["评审备注"].ToString().Trim();
            
                gridControl明细.DataSource = dt订单评审运算3;

                DataTable dtTemp = new DataTable();
                DataColumn dc = new DataColumn();
                dc.ColumnName = "子件编码";
                dtTemp.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "本次下单数量";
                dtTemp.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "本次下单件数";
                dtTemp.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "完成日期";
                dtTemp.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "评审ID";
                dtTemp.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "换算率";
                dtTemp.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "子件计量单位";
                dtTemp.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "辅助单位";
                dtTemp.Columns.Add(dc);

                for (int i = 0; i < dt订单评审运算3.Rows.Count; i++)
                {
                    string s子件编码 = dt订单评审运算3.Rows[i]["子件编码"].ToString().Trim();
                    decimal dDec = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dt订单评审运算3.Rows[i]["本次下单数量"]);
                    if (dDec == 0)
                        continue; 

                    DateTime dDate = Convert.ToDateTime(dt订单评审运算3.Rows[i]["完成日期"]);

                    bool bAdd = true;
                    for (int j = 0; j < dtTemp.Rows.Count; j++)
                    {
                        string s子件编码2 = dtTemp.Rows[j]["子件编码"].ToString().Trim();
                        decimal d1Dec2 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dtTemp.Rows[j]["本次下单数量"]);
                        if (d1Dec2 == 0)
                            continue; 

                        DateTime dDate2 = Convert.ToDateTime(dtTemp.Rows[j]["完成日期"]);
                        if (s子件编码 == s子件编码2 && dDate <= dDate2.AddDays(10))
                        {
                            dtTemp.Rows[j]["本次下单数量"] = d1Dec2 + dDec;
                            dtTemp.Rows[j]["完成日期"] = dDate2;
                            dtTemp.Rows[j]["评审ID"] = dt订单评审运算3.Rows[i]["iID"] + "," + dtTemp.Rows[j]["评审ID"].ToString().Trim();
                            bAdd = false;
                        }
                    }
                    if (bAdd)
                    {
                        DataRow dr = dtTemp.NewRow();
                        dr["子件编码"] = s子件编码;
                        dr["本次下单数量"] = dDec;
                        dr["完成日期"] = dDate;
                        if (dt订单评审运算3.Rows[i]["iInvExchRate"].ToString().Trim() != "")
                        {
                            dr["换算率"] = dt订单评审运算3.Rows[i]["iInvExchRate"];
                        }
                        else
                        {
                            dr["换算率"] = dt订单评审运算3.Rows[i]["换算率"].ToString().Trim();
                        }
                        dr["子件计量单位"] = dt订单评审运算3.Rows[i]["子件计量单位"].ToString().Trim();
                        dr["辅助单位"] = dt订单评审运算3.Rows[i]["辅助单位"].ToString().Trim();
                        dr["评审ID"] = dt订单评审运算3.Rows[i]["iID"];
                        dtTemp.Rows.Add(dr);
                    } 
                }
                for (int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    if (dtTemp.Rows[i]["辅助单位"].ToString().Trim() != "" && FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dtTemp.Rows[i]["换算率"]) != 0)
                    {
                        decimal d本次下单数量 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dtTemp.Rows[i]["本次下单数量"]);
                        decimal d换算率 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dtTemp.Rows[i]["换算率"]);
                        decimal d本次下单件数 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(d本次下单数量 / d换算率);
                        dtTemp.Rows[i]["本次下单件数"] = d本次下单件数;
                    }
                }

                gridControl合并.DataSource = dtTemp;
            }
            else
            {
                throw new Exception("获得单据失败");
            }
        }

        private void GetSelList()
        {
            string sSQL = "select 销售订单ID from 订单评审运算1 where 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim() + " and isnull(审核人,'') <> '' and isnull(关闭人,'') = '' and isnull(下达请购人,'') = '' order by 销售订单号";
            dtSel = clsSQLCommond.ExecQuery(sSQL);

            if (dtSel != null && dtSel.Rows.Count > 0)
            {
                iPage = dtSel.Rows.Count - 1;
            }
        }

        private void gridView明细_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void gridView合并_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        /// <summary>
        /// 获得请购单单据号
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string GetPU_AppVouchCode(string s)
        {
            for (int i = 0; i < 5; i++)
            {
                if (s.Length < 4)
                {
                    s = "0" + s;
                }
                else
                {
                    break;
                }
            }
            return "PRPM" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + s;
        }
    }
}
