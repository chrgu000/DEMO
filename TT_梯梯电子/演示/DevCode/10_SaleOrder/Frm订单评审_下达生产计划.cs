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
    public partial class Frm订单评审_下达生产计划 : FrameBaseFunction.Frm列表窗体模板
    {
        public Frm订单评审_下达生产计划()
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

        }

        private string sFrmSEL = "";

        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
            Frm订单评审_下达生产计划SEL fSel = new Frm订单评审_下达生产计划SEL();
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
                aList = new System.Collections.ArrayList();
                string sErr = "";
                string s生成提示 = "";

                sSQL = "select * from dbo.订单评审运算1  where 销售订单ID = " + txt销售订单ID.Text.Trim() + " and 帐套号 = 200";
                DataTable dtErr = clsSQLCommond.ExecQuery(sSQL);
                if (dtErr == null || dtErr.Rows.Count < 1)
                {
                    throw new Exception("没有需要下达生产计划的单据");
                }
                if (dtErr.Rows.Count > 0)
                {
                    if (dtErr.Rows[0]["维护审核人"].ToString().Trim() == "")
                        throw new Exception("尚未审核不能下达生产计划");
                    if (dtErr.Rows[0]["关闭人"].ToString().Trim() != "")
                        throw new Exception("已经关闭不能下达生产计划");
                    if (dtErr.Rows[0]["下达生产人"].ToString().Trim() != "")
                    {
                        sSQL = "select distinct SoCode from @u8.mom_orderdetail where SoCode = '" + txt销售订单号.Text.Trim() + "'";
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


                #region 下达生产计划（生产订单）

                //获得最大单据号
                long iVouMOM;
                sSQL = "select isnull(max(cast (cNumber as int)),0) as Maxnumber From @u8.VoucherHistory  with (NOLOCK) Where CardNumber='MO21' and (cSeed = '" + Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyyMM") + "' or cSeed = '" + Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "')";
                DataTable dtMOM = clsSQLCommond.ExecQuery(sSQL);
                iVouMOM = Convert.ToInt64(dtMOM.Rows[0]["Maxnumber"]);

                bool bVouMOM = false;            //当月第一张单据
                if (iVouMOM == 0)
                {
                    bVouMOM = true;
                }

                ////获得单据ID号
                long iIDmom_order;
                long iIDmom_orderdetail;
                long iIDmom_moallocate;
                //sSQL = "select iFatherID,iChildID from UFSystem..UA_Identity where cAcc_Id = '200' and cVouchType = 'mom_order'";

                sSQL = @"
declare @p5 int
set @p5=1000043137
declare @p6 int
set @p6=1000043137
exec @u8.sp_GetID @RemoteId=N'00',@cAcc_Id=N'200',@cVouchType=N'mom_order',@iAmount=1,@iFatherId=@p5 output,@iChildId=@p6 output
select @p5, @p6
";
                DataTable dtID = clsSQLCommond.ExecQuery(sSQL);
                if (dtID == null || dtID.Rows.Count < 1)
                {
                    iIDmom_order = 0;
                }
                else
                {
                    iIDmom_order = Convert.ToInt64(dtID.Rows[0][1]);
                }
                //sSQL = "select iFatherID,iChildID from UFSystem..UA_Identity where cAcc_Id = '200' and cVouchType = 'mom_orderdetail'";
                sSQL = @"
declare @p5 int
set @p5=1000108105
declare @p6 int
set @p6=1000108103
exec @u8.sp_GetID @RemoteId=N'00',@cAcc_Id=N'200',@cVouchType=N'mom_orderdetail',@iAmount=1,@iFatherId=@p5 output,@iChildId=@p6 output
select @p5, @p6
";
                dtID = clsSQLCommond.ExecQuery(sSQL);
                if (dtID == null || dtID.Rows.Count < 1)
                {
                    iIDmom_orderdetail = 0;
                }
                else
                {
                    iIDmom_orderdetail = Convert.ToInt64(dtID.Rows[0][1]);
                }
                //sSQL = "select iFatherID,iChildID from UFSystem..UA_Identity where cAcc_Id = '200' and cVouchType = 'mom_moallocate'";
                sSQL = @"
declare @p5 int
set @p5=1000424948
declare @p6 int
set @p6=1000424954
exec @u8.sp_GetID @RemoteId=N'00',@cAcc_Id=N'200',@cVouchType=N'mom_moallocate',@iAmount=3,@iFatherId=@p5 output,@iChildId=@p6 output
select @p5, @p6
";
                dtID = clsSQLCommond.ExecQuery(sSQL);
                if (dtID == null || dtID.Rows.Count < 1)
                {
                    iIDmom_moallocate = 0;
                }
                else
                {
                    iIDmom_moallocate = Convert.ToInt64(dtID.Rows[0][1]);
                }

                //获得生产订单主表框架
                sSQL = "select * from @u8.mom_order where 1=-1";
                DataTable dtmom_order = clsSQLCommond.ExecQuery(sSQL);
                //获得生产订单子表框架
                sSQL = "select * from @u8.mom_orderdetail where 1=-1";
                DataTable dtmom_orderdetail = clsSQLCommond.ExecQuery(sSQL);
                //获得生产订单子件用料表框架
                sSQL = "select * from @u8.mom_moallocate where 1=-1";
                DataTable dtmom_moallocate = clsSQLCommond.ExecQuery(sSQL);
                //获得生产订单资料框架
                sSQL = "select * from @u8.mom_morder  where 1=-1";
                DataTable dtmom_morder = clsSQLCommond.ExecQuery(sSQL);

                sSQL = "select distinct 销售订单ID,销售订单行号,生产部门编码,0 as 行 from dbo.订单评审运算3  where 子件属性 = '自制' and 销售订单ID = " + txt销售订单ID.Text.Trim() + " and 帐套号 = 200";
                DataTable dt生产 = clsSQLCommond.ExecQuery(sSQL);
                for (int ii = 0; ii < dt生产.Rows.Count; ii++)
                {
                    string s销售订单行号 = dt生产.Rows[ii]["销售订单行号"].ToString().Trim();
                    string s生产部门编码 = dt生产.Rows[ii]["生产部门编码"].ToString().Trim();
                    if (s生产部门编码 == "905")
                    {
                        sErr = sErr + "生产部门不能是委外部请核查\n";
                        continue;
                    }

                    int i行 = ReturnObjectToInt(dt生产.Rows[ii]["行"]);

                    int iSortSeq = 0;
                    for (int i = 0; i < gridView明细.RowCount; i++)
                    {
                        if (gridView明细.GetRowCellValue(i, gridCol子件属性).ToString().Trim() != "自制")
                            continue;

                        if (FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView明细.GetRowCellValue(i, gridCol本次下单数量)) == 0)
                            continue;

                        string s销售订单行号2 = gridView明细.GetRowCellValue(i, gridCol销售订单行号).ToString().Trim();
                        string s生产部门编码2 = gridView明细.GetRowCellValue(i, gridCol生产部门编码).ToString().Trim();


                        if (s销售订单行号2 == s销售订单行号 && s生产部门编码2 == s生产部门编码)
                        {
                            if (i行 == 0)
                            {
                                DataRow drmom_order = dtmom_order.NewRow();
                                iIDmom_order += 1;
                                drmom_order["MoId"] = iIDmom_order;
                                iVouMOM = iVouMOM + 1;
                                drmom_order["MoCode"] = GetMOMCode(iVouMOM.ToString());
                                drmom_order["CreateDate"] = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                                drmom_order["CreateUser"] = FrameBaseFunction.ClsBaseDataInfo.sUid;
                                drmom_order["ModifyDate"] = DBNull.Value;
                                drmom_order["ModifyUser"] = DBNull.Value;
                                drmom_order["UpdCount"] = 1;
                                //drmom_order["Define1"] = "";
                                //drmom_order["Define2"] = "";
                                //drmom_order["Define3"] = "";
                                //drmom_order["Define4"] = "";
                                //drmom_order["Define5"] = "";
                                //drmom_order["Define6"] = "";
                                //drmom_order["Define7"] = "";
                                //drmom_order["Define8"] = "";
                                //drmom_order["Define9"] = "";
                                //drmom_order["Define10"] = "";
                                drmom_order["Define11"] = "";
                                //drmom_order["Define12"] = "";
                                //drmom_order["Define13"] = "";
                                //drmom_order["Define14"] = "";
                                //drmom_order["Define15"] = "";
                                //drmom_order["Define16"] = "";
                                drmom_order["VTid"] = 30422;
                                drmom_order["CreateTime"] = Get当前服务器时间();
                                drmom_order["ModifyTime"] = DBNull.Value;
                                dtmom_order.Rows.Add(drmom_order);

                                i行 += 1;
                            }


                            if (gridView明细.GetRowCellValue(i, gridCol子件属性).ToString().Trim() != "自制")
                                continue;

                            if (FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView明细.GetRowCellValue(i, gridCol本次下单数量)) == 0)
                                continue;

                            sSQL = "select a.cInvCode,a.iInvAdvance,a.cDefWareHouse,b.PartID,a.cInvDepCode from @u8.Inventory a inner join @u8.bas_Part b on a.cInvCode = b.InvCode where a.cInvCode = '" + gridView明细.GetRowCellValue(i, gridCol子件编码) + "'";
                            DataTable dtInv = clsSQLCommond.ExecQuery(sSQL);

                            dtBom子件.Rows.Clear();
                            RetuntBOMDetail(gridView明细.GetRowCellValue(i, gridCol子件编码).ToString().Trim(), 1);
                            DataTable dtBomInfo = dtBom子件.Copy();

                            //decimal d使用 = 0;
                            //for (int a = 0; a < dtBomInfo.Rows.Count; a++)
                            //{
                            //    d使用 = d使用 + FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dtBomInfo.Rows[a]["使用数量"]);
                            //}

                            DataRow drmom_orderdetail = dtmom_orderdetail.NewRow();

                            iIDmom_orderdetail += 1;
                            drmom_orderdetail["MoDId"] = iIDmom_orderdetail;
                            drmom_orderdetail["MoId"] = iIDmom_order;
                            iSortSeq += 1;
                            drmom_orderdetail["SortSeq"] = iSortSeq;
                            drmom_orderdetail["MoClass"] = 1;
                            drmom_orderdetail["MoTypeId"] = DBNull.Value;
                            drmom_orderdetail["Qty"] = gridView明细.GetRowCellValue(i, gridCol本次下单数量);
                            drmom_orderdetail["MrpQty"] = gridView明细.GetRowCellValue(i, gridCol本次下单数量);
                            drmom_orderdetail["AuxUnitCode"] = DBNull.Value;
                            drmom_orderdetail["AuxQty"] = DBNull.Value;
                            drmom_orderdetail["ChangeRate"] = DBNull.Value;
                            drmom_orderdetail["MoLotCode"] = DBNull.Value;
                            //drmom_orderdetail["WhCode"] = gridView明细.GetRowCellValue(i, gridCol仓库代号);
                            drmom_orderdetail["WhCode"] = dtInv.Rows[0]["cDefWareHouse"];

                            if (dtInv.Rows[0]["cDefWareHouse"].ToString().Trim() != "01" && dtInv.Rows[0]["cDefWareHouse"].ToString().Trim() != "04")
                            {

                            }

                            drmom_orderdetail["MDeptCode"] = s生产部门编码2;
                            drmom_orderdetail["SoType"] = 1;
                            drmom_orderdetail["SoDId"] = gridView明细.GetRowCellValue(i, gridCol销售订单子表ID);
                            drmom_orderdetail["SoCode"] = txt销售订单号.Text.Trim();
                            drmom_orderdetail["SoSeq"] = gridView明细.GetRowCellValue(i, gridCol销售订单行号);
                            drmom_orderdetail["DeclaredQty"] = 0;
                            drmom_orderdetail["QualifiedInQty"] = 0;
                            drmom_orderdetail["Status"] = 2;
                            drmom_orderdetail["OrgStatus"] = 2;

                            if (dtBomInfo == null || dtBomInfo.Rows.Count == 0)
                            {
                                throw new Exception("存货" + gridView明细.GetRowCellValue(i, gridCol子件编码).ToString().Trim() + " 没有BOM");
                            }

                            drmom_orderdetail["BomId"] = dtBomInfo.Rows[0]["bomid"];
                
                            drmom_orderdetail["RoutingId"] = 0;
                            drmom_orderdetail["CustBomId"] = 0;
                            drmom_orderdetail["DemandId"] = 0;
                            drmom_orderdetail["PlanCode"] = DBNull.Value;

                            if (dtInv != null && dtInv.Rows.Count > 0)
                            {
                                drmom_orderdetail["PartId"] = dtInv.Rows[0]["PartID"];
                                drmom_orderdetail["LeadTime"] = dtInv.Rows[0]["iInvAdvance"];
                            }

                            drmom_orderdetail["InvCode"] = gridView明细.GetRowCellValue(i, gridCol子件编码);
                            drmom_orderdetail["SfcFlag"] = 0;
                            drmom_orderdetail["CrpFlag"] = 0;
                            drmom_orderdetail["QcFlag"] = 0;
                            drmom_orderdetail["RelsDate"] = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                            drmom_orderdetail["RelsUser"] = FrameBaseFunction.ClsBaseDataInfo.sUid;
                            drmom_orderdetail["CloseDate"] = DBNull.Value;
                            drmom_orderdetail["OrgClsDate"] = DBNull.Value;
                            drmom_orderdetail["Define22"] = txt销售订单号.Text.Trim();
                            //drmom_orderdetail["Define28"] = "";
                            //drmom_orderdetail["Define36"] = "";
                            drmom_orderdetail["OpScheduleType"] = 1;
                            drmom_orderdetail["OrdFlag"] = 0;
                            drmom_orderdetail["WIPType"] = 5;
                            drmom_orderdetail["SupplyWhCode"] = DBNull.Value;
                            drmom_orderdetail["ReasonCode"] = DBNull.Value;
                            drmom_orderdetail["IsWFControlled"] = 0;
                            drmom_orderdetail["iVerifyState"] = 0;
                            drmom_orderdetail["iReturnCount"] = 0;
                            drmom_orderdetail["Remark"] = DBNull.Value;
                            drmom_orderdetail["SourceMoCode"] = DBNull.Value;
                            drmom_orderdetail["SourceMoSeq"] = DBNull.Value;
                            drmom_orderdetail["SourceMoId"] = 0;
                            drmom_orderdetail["SourceMoDId"] = 0;
                            drmom_orderdetail["SourceQCCode"] = DBNull.Value;
                            drmom_orderdetail["SourceQCId"] = 0;
                            drmom_orderdetail["SourceQCDId"] = 0;
                            drmom_orderdetail["CostItemCode"] = DBNull.Value;
                            drmom_orderdetail["CostItemName"] = DBNull.Value;
                            drmom_orderdetail["RelsTime"] = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                            drmom_orderdetail["CloseUser"] = DBNull.Value;
                            drmom_orderdetail["CloseTime"] = DBNull.Value;
                            drmom_orderdetail["OrgClsTime"] = DBNull.Value;
                            drmom_orderdetail["AuditStatus"] = 1;
                            drmom_orderdetail["PAllocateId"] = 0;
                            drmom_orderdetail["DemandCode"] = DBNull.Value;
                            drmom_orderdetail["CollectiveFlag"] = 0;
                            drmom_orderdetail["OrderType"] = 1;
                            drmom_orderdetail["OrderDId"] = gridView明细.GetRowCellValue(i, gridCol销售订单子表ID);
                            drmom_orderdetail["OrderCode"] = txt销售订单号.Text.Trim();
                            drmom_orderdetail["OrderSeq"] = gridView明细.GetRowCellValue(i, gridCol销售订单行号);
                            drmom_orderdetail["ManualCode"] = DBNull.Value;
                            drmom_orderdetail["ReformFlag"] = 0;
                            drmom_orderdetail["SourceQCVouchType"] = 0;
                            drmom_orderdetail["OrgQty"] = 0;
                            drmom_orderdetail["FmFlag"] = 0;
                            drmom_orderdetail["BomType"] = 1;
                            drmom_orderdetail["AlloVTid"] = 30417;
                            drmom_orderdetail["RoutingType"] = 0;
                            dtmom_orderdetail.Rows.Add(drmom_orderdetail);

                            //生产订单资料
                            DataRow drmom_morder = dtmom_morder.NewRow();
                            drmom_morder["MoDId"] = iIDmom_orderdetail;
                            drmom_morder["StartDate"] = gridView明细.GetRowCellValue(i, gridCol开始日期);
                            drmom_morder["DueDate"] = gridView明细.GetRowCellValue(i, gridCol完成日期);
                            drmom_morder["MoId"] = iIDmom_order;
                            dtmom_morder.Rows.Add(drmom_morder);


                            //生产订单子件用料表
                            for (int j = 0; j < dtBomInfo.Rows.Count; j++)
                            {
                                DataRow drmom_moallocate = dtmom_moallocate.NewRow();
                                iIDmom_moallocate += 1;
                                drmom_moallocate["AllocateId"] = iIDmom_moallocate;
                                drmom_moallocate["MoDId"] = iIDmom_orderdetail;
                                drmom_moallocate["SortSeq"] = (j + 1) * 10;
                                drmom_moallocate["OpSeq"] = "0000";
                                drmom_moallocate["ComponentId"] = dtBomInfo.Rows[j]["ComponentId"];
                                drmom_moallocate["FVFlag"] = 1;
                                drmom_moallocate["BaseQtyN"] = dtBomInfo.Rows[j]["使用数量"];
                                drmom_moallocate["BaseQtyD"] = 1;
                                drmom_moallocate["ParentScrap"] = 0;
                                drmom_moallocate["CompScrap"] = 0;

                                decimal d使用数量 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dtBomInfo.Rows[j]["使用数量"]);
                                if (d使用数量 == 0)
                                {
                                    //基本用量/基础数量/（1-母件损耗率）*（1+子件损耗率）
                                    throw new Exception("获得子件使用量失败");
                                }
                                drmom_moallocate["Qty"] = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView明细.GetRowCellValue(i, gridCol本次下单数量)) * d使用数量;
                                drmom_moallocate["IssQty"] = 0;
                                drmom_moallocate["DeclaredQty"] = 0;
                                drmom_moallocate["StartDemDate"] = gridView明细.GetRowCellValue(i, gridCol开始日期);
                                drmom_moallocate["EndDemDate"] = gridView明细.GetRowCellValue(i, gridCol完成日期);
                                drmom_moallocate["WhCode"] = dtBomInfo.Rows[j]["Whcode"];
                                drmom_moallocate["LotNo"] = DBNull.Value;
                                drmom_moallocate["WIPType"] = 1;
                                drmom_moallocate["ByproductFlag"] = 0;
                                drmom_moallocate["QcFlag"] = 0;
                                drmom_moallocate["Offset"] = 0;
                                drmom_moallocate["InvCode"] = dtBomInfo.Rows[j]["cInvCode"];
                                drmom_moallocate["OpComponentId"] = dtBomInfo.Rows[j]["OpComponentId"];

                                if (dtBomInfo.Rows[j]["cAssComUnitCode"].ToString().Trim() != "")
                                {
                                    drmom_moallocate["AuxUnitCode"] = dtBomInfo.Rows[j]["cAssComUnitCode"];
                                    drmom_moallocate["ChangeRate"] = dtBomInfo.Rows[j]["ChangeRate"];
                                    drmom_moallocate["AuxBaseQtyN"] = dtBomInfo.Rows[j]["AuxBaseQtyN"];

                                    //if (FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dtBomInfo.Rows[j]["ChangeRate"]) == 0)
                                    //{ 

                                    //}
                                    drmom_moallocate["AuxQty"] = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView明细.GetRowCellValue(i, gridCol本次下单数量)) * d使用数量 / FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dtBomInfo.Rows[j]["ChangeRate"]);

                                }
                                drmom_moallocate["ReplenishQty"] = 0;
                                drmom_moallocate["Remark"] = DBNull.Value;
                                drmom_moallocate["TransQty"] = 0;
                                drmom_moallocate["ProductType"] = 1;
                                drmom_moallocate["SoType"] = 0;
                                drmom_moallocate["SoDId"] = DBNull.Value;
                                drmom_moallocate["SoCode"] = DBNull.Value;
                                drmom_moallocate["SoSeq"] = DBNull.Value;
                                drmom_moallocate["DemandCode"] = DBNull.Value;
                                drmom_moallocate["QmFlag"] = 0;
                                drmom_moallocate["OrgQty"] = 0;
                                drmom_moallocate["OrgAuxQty"] = 0;
                                drmom_moallocate["RequisitionFlag"] = 0;
                                drmom_moallocate["CostWIPRel"] = 0;
                                dtmom_moallocate.Rows.Add(drmom_moallocate);
                            }
                        }
                    }
                }
                if (sErr.Trim() != "")
                {
                    throw new Exception(sErr);
                }

                if (dtmom_orderdetail.Rows.Count > 0)
                {
                    for (int i = 0; i < dtmom_order.Rows.Count; i++)
                    {
                        //生成生产订单表头
                        aList.Add(clsGetSQL.GetInsertSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "mom_order", dtmom_order, i));
                        s生成提示 = s生成提示 + "生产订单：" + dtmom_order.Rows[i]["MoCode"].ToString().Trim() + "\n";
                    }

                    for (int i = 0; i < dtmom_orderdetail.Rows.Count; i++)
                    {
                        //生成生产订单表体
                        aList.Add(clsGetSQL.GetInsertSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "mom_orderdetail", dtmom_orderdetail, i));
                    }

                    for (int i = 0; i < dtmom_morder.Rows.Count; i++)
                    {
                        //生成生产订单资料表
                        aList.Add(clsGetSQL.GetInsertSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "mom_morder", dtmom_morder, i));
                    }

                    for (int i = 0; i < dtmom_moallocate.Rows.Count; i++)
                    {
                        //生成生产订单用料表
                        aList.Add(clsGetSQL.GetInsertSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "mom_moallocate", dtmom_moallocate, i));
                    }
                }
                //更新最大单据号
                if (bVouMOM)
                {
                    sSQL = "insert into @u8.VoucherHistory(cardnumber,cContent,cContentRule,cSeed,cNumber,bEmpty) " +
                            "values('MO21','制单日期','月','" + Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "','1',0)";
                    aList.Add(sSQL);
                }
                else
                {
                    sSQL = "update @u8.VoucherHistory set cNumber = '" + iVouMOM + "' Where CardNumber='MO21' and (cSeed = '" + Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyyMM") + "' or cSeed = '" + Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "')";
                    aList.Add(sSQL);
                }

                //更新最大ID
                if (iIDmom_order >= 1000000000)
                    iIDmom_order = iIDmom_order - 1000000000;
                if (iIDmom_orderdetail >= 1000000000)
                    iIDmom_orderdetail = iIDmom_orderdetail - 1000000000;
                if (iIDmom_moallocate >= 1000000000)
                    iIDmom_moallocate = iIDmom_moallocate - 1000000000;

                sSQL = "update UFSystem..UA_Identity set iFatherID=" + iIDmom_order + ",iChildID=" + iIDmom_order + " where  cAcc_Id = '200' and cVouchType = 'mom_order'";
                aList.Add(sSQL);
                sSQL = "update UFSystem..UA_Identity set iFatherID=" + iIDmom_orderdetail + ",iChildID=" + iIDmom_orderdetail + " where  cAcc_Id = '200' and cVouchType = 'mom_orderdetail'";
                aList.Add(sSQL);
                sSQL = "update UFSystem..UA_Identity set iFatherID=" + iIDmom_moallocate + ",iChildID=" + iIDmom_moallocate + " where  cAcc_Id = '200' and cVouchType = 'mom_moallocate'";
                aList.Add(sSQL);
                #endregion


                sSQL = " update dbo.订单评审运算1 set 下达生产人 = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',下达生产日期 = getdate() where 销售订单ID = " + txt销售订单ID.Text.Trim() + " and 帐套号 = 200";
                aList.Add(sSQL);

                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);
                    MsgBox("提示", "保存成功！\n合计执行语句:" + iCou + "条\n" + s生成提示);
                    sState = "save";
                }
                GetSelList();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        /// <summary>
        /// 获得生产订单单据号
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string GetMOMCode(string s)
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
            return "SD" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + s;
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
            throw new NotImplementedException();
        }

        #endregion

        private void Frm订单评审_下达生产计划_Load(object sender, EventArgs e)
        {
            try
            {
                GetLookUp();

                GetSelList();

                btnLast();

                sSQL = "select BaseQtyN/BaseQtyD/(1-isnull(ParentScrap,0))*(1+isnull(CompScrap,0)) as 使用数量,a.bomid,b.ComponentId,b.BaseQtyN,b.BaseQtyD," +
                   " c.ParentScrap,b.CompScrap,d.InvCode,e.cDefWareHouse,f.Whcode,e.cInvCode,b.OpComponentId,e.cAssComUnitCode,b.ChangeRate,b.AuxBaseQtyN,f.WIPType " +
               "from @u8.bom_bom a inner join @u8.bom_opcomponent b on a.bomID = b.bomid inner join @u8.bom_parent c on c.bomid = a.bomid  " +
                   " inner join @u8.bom_opcomponentopt f on f.OptionsId = b.OptionsId " +
                   " inner join @u8.bas_part d on d.PartId = b.ComponentId " +
                   " inner join @u8.Inventory e on e.cInvCode = d.InvCode " +
                   " inner join @u8.bas_part g on g.PartId = c.ParentId " +
               "where 1=-1";
                dtBom子件 = clsSQLCommond.ExecQuery(sSQL);
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

            sSQL = "select cDepCode,cDepName from @u8.Department order by cDepCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit部门编码.DataSource = dt;
            ItemLookUpEdit部门名称.DataSource = dt;

            sSQL = "select cWhCode,cWhName from @u8.Warehouse  order by cWhCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit仓库编号.DataSource = dt;
            ItemLookUpEdit仓库名称.DataSource = dt;
        }

        //private void gridView评审计算_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        //{
        //    try
        //    {
        //        int i1 = ReturnObjectToInt(gridView明细.GetRowCellValue(e.RowHandle, gridCol销售订单行号));
        //        int i2 = i1%2;

        //        if (i2 == 0)
        //        {
        //            e.Appearance.BackColor = Color.AliceBlue;
        //        }
        //        else
        //        {
        //            e.Appearance.BackColor = Color.AntiqueWhite; 
        //        } 
        //    }
        //    catch
        //    { }
        //}

      
        private void GetGrid(long i销售订单ID)
        {
            string sSQL = "select * from dbo.订单评审运算1 where 销售订单ID = " + i销售订单ID + " and 帐套号 = 200";
            DataTable dt订单评审运算1 = clsSQLCommond.ExecQuery(sSQL);

            sSQL = "select * from dbo.订单评审运算2 where 销售订单ID = " + i销售订单ID + " and 帐套号 = 200 order by iID";
            DataTable dt订单评审运算2 = clsSQLCommond.ExecQuery(sSQL);

            sSQL = "select * from dbo.订单评审运算3 " +
                    "where 销售订单ID = " + i销售订单ID + " and 帐套号 = 200 and 子件属性 = '自制'" +
                    " order by 销售订单ID, 销售订单行号,领料部门代号,子件编码,完成日期,iID";
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
                dc.ColumnName = "完成日期";
                dtTemp.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "评审ID";
                dtTemp.Columns.Add(dc);

                for (int i = 0; i < dt订单评审运算3.Rows.Count; i++)
                {
                    string s子件编码 = dt订单评审运算3.Rows[i]["子件编码"].ToString().Trim();
                    decimal dDec = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dt订单评审运算3.Rows[i]["本次下单数量"]);
                    DateTime dDate = Convert.ToDateTime(dt订单评审运算3.Rows[i]["完成日期"]);

                    bool bAdd = true;
                    for (int j = 0; j < dtTemp.Rows.Count; j++)
                    {
                        string s子件编码2 = dtTemp.Rows[j]["子件编码"].ToString().Trim();
                        decimal d1Dec2 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dtTemp.Rows[j]["本次下单数量"]);
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
                        dr["评审ID"] = dt订单评审运算3.Rows[i]["iID"];
                        dtTemp.Rows.Add(dr);
                    } 
                }
            }
            else
            {
                throw new Exception("获得单据失败");
            }
        }

        private void GetSelList()
        {
            string sSQL = "select 销售订单ID from 订单评审运算1 where 帐套号 = 200 and isnull(审核人,'') <> '' and isnull(关闭人,'') = '' and isnull(下达生产人,'') = '' and isnull(维护审核人,'') <> '' order by 销售订单号";
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

        //private void gridView合并_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        //{
        //    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
        //    if (e.Info.IsRowIndicator)
        //    {
        //        if (e.RowHandle >= 0)
        //        {
        //            e.Info.DisplayText = (e.RowHandle + 1).ToString();
        //        }
        //        else if (e.RowHandle < 0 && e.RowHandle > -1000)
        //        {
        //            e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
        //            e.Info.DisplayText = "G" + e.RowHandle.ToString();
        //        }
        //    }
        //}

        /// <summary>
        /// 获得请购单单据号
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string GetPU_AppVouchCode(string s)
        {
            for (int i = 0; i < 5; i++)
            {
                if (s.Length < 3)
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

        DataTable dtBom子件 = new DataTable();
        private DataTable RetuntBOMDetail(string sInvCode,decimal d使用倍数)
        {
            sSQL = "select BaseQtyN/BaseQtyD/(1-isnull(ParentScrap,0))*(1+isnull(CompScrap,0))*" + d使用倍数 + " as 使用数量,a.bomid,b.ComponentId,b.BaseQtyN,b.BaseQtyD," +
                     " c.ParentScrap,b.CompScrap,d.InvCode,e.cDefWareHouse,f.Whcode,e.cInvCode,b.OpComponentId,e.cAssComUnitCode,b.ChangeRate,b.AuxBaseQtyN,f.WIPType " +
                 "from @u8.bom_bom a inner join @u8.bom_opcomponent b on a.bomID = b.bomid inner join @u8.bom_parent c on c.bomid = a.bomid  " +
                     " inner join @u8.bom_opcomponentopt f on f.OptionsId = b.OptionsId " +
                     " inner join @u8.bas_part d on d.PartId = b.ComponentId " +
                     " inner join @u8.Inventory e on e.cInvCode = d.InvCode " +
                     " inner join @u8.bas_part g on g.PartId = c.ParentId " +
                 "where g.InvCode = '" + sInvCode + "' and a.[Status] = 3 and b.EffBegDate < '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' and b.EffEndDate > '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["WIPType"].ToString().Trim() == "4")
                {
                    decimal d使用数量 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dt.Rows[i]["使用数量"]);
                    DataTable dtTemp = RetuntBOMDetail(dt.Rows[i]["InvCode"].ToString().Trim(), d使用数量);
                }
                else
                {
                    DataRow dr = dtBom子件.NewRow();
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        dr[j] = dt.Rows[i][j];
                    }
                    dtBom子件.Rows.Add(dr);
                }
            }

            return dt;
        }
    }
}
