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
    public partial class Frm订单评审_下达委外计划 : FrameBaseFunction.Frm列表窗体模板
    {
        public Frm订单评审_下达委外计划()
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

        }

        private string sFrmSEL = "";

        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
            Frm订单评审_下达委外计划SEL fSel = new Frm订单评审_下达委外计划SEL();
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

                sSQL = "select * from dbo.订单评审运算1  where 销售订单ID = " + txt销售订单ID.Text.Trim() + " and 帐套号 = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3);
                DataTable dtErr = clsSQLCommond.ExecQuery(sSQL);
                if (dtErr == null || dtErr.Rows.Count < 1)
                {
                    throw new Exception("没有需要下达采购计划的单据");
                }
                if (dtErr.Rows.Count > 0)
                {
                    if (dtErr.Rows[0]["维护审核人"].ToString().Trim() == "")
                        throw new Exception("尚未审核不能下达委外计划");
                    if (dtErr.Rows[0]["关闭人"].ToString().Trim() != "")
                        throw new Exception("已经关闭不能下达委外计划");
                    if (dtErr.Rows[0]["下达委外人"].ToString().Trim() != "")
                        throw new Exception("不能重复下达委外计划");
                }

                sSQL = "select GETDATE() ";
                DateTime d当前日期 = Convert.ToDateTime(clsSQLCommond.ExecGetScalar(sSQL));

                #region 下达委外计划

                string s生成提示 = "";

                //获得委外计划框架
                sSQL = "select * from UFDLImport.dbo.OMPlan where 1=-1";
                DataTable dtOMPlan = clsSQLCommond.ExecQuery(sSQL);

                long iVouOMNumber;
                sSQL = "select max(iID) as Maxnumber from UFDLImport.dbo.OMPlan";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                iVouOMNumber = Convert.ToInt64(dt.Rows[0]["Maxnumber"]);

                for (int i = 0; i < gridView明细.RowCount; i++)
                {
                    if (gridView明细.GetRowCellValue(i, gridCol子件属性).ToString().Trim() != "委外")
                        continue;

                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView明细.GetRowCellValue(i, gridCol本次下单数量)) == 0)
                        continue;

                    DataRow drOMPlan = dtOMPlan.NewRow();
                    iVouOMNumber += 1;
                    drOMPlan["iID"] = iVouOMNumber;
                    drOMPlan["DemandId"] = DBNull.Value;

                    sSQL = "select * from @u8.bas_part where InvCode = '" + gridView明细.GetRowCellValue(i, gridCol子件编码).ToString().Trim() + "'";
                    DataTable dtBas_part = clsSQLCommond.ExecQuery(sSQL);
                    if (dtBas_part != null && dtBas_part.Rows.Count > 0)
                    {
                        drOMPlan["PartId"] = dtBas_part.Rows[0]["PartId"];
                    }
                    drOMPlan["SoType"] = 1;
                    drOMPlan["SoDId"] = gridView明细.GetRowCellValue(i, gridCol销售订单子表ID).ToString().Trim();
                    drOMPlan["SoId"] = txt销售订单ID.Text.Trim();
                    drOMPlan["SoCode"] = txt销售订单号.Text.Trim();
                    drOMPlan["SoSeq"] = gridView明细.GetRowCellValue(i, gridCol销售订单行号).ToString().Trim();
                    //drOMPlan["PlanCode"] = "";
                    drOMPlan["DueDate"] = gridView明细.GetRowCellValue(i, gridCol完成日期).ToString().Trim();
                    drOMPlan["StartDate"] = gridView明细.GetRowCellValue(i, gridCol开始日期).ToString().Trim();
                    drOMPlan["DueDate2"] = gridView明细.GetRowCellValue(i, gridCol完成日期).ToString().Trim();
                    drOMPlan["StartDate2"] = gridView明细.GetRowCellValue(i, gridCol开始日期).ToString().Trim();
                    drOMPlan["LUSD"] = gridView明细.GetRowCellValue(i, gridCol开始日期).ToString().Trim();
                    drOMPlan["LUCD"] = gridView明细.GetRowCellValue(i, gridCol完成日期).ToString().Trim();
                    drOMPlan["PlanQty"] = gridView明细.GetRowCellValue(i, gridCol本次下单数量).ToString().Trim();
                    drOMPlan["CrdQty"] = 0;
                    drOMPlan["SupplyType"] = 2;
                    drOMPlan["SchId"] = DBNull.Value;
                    drOMPlan["ManualFlag"] = false;
                    drOMPlan["DelFlag"] = false;
                    drOMPlan["ModifyFlag"] = false;
                    drOMPlan["ProjectId"] = DBNull.Value;
                    drOMPlan["FirmDate"] = DBNull.Value;
                    drOMPlan["FirmUser"] = DBNull.Value;
                    drOMPlan["Status"] = 1;
                    drOMPlan["SrpSoDId"] = 0;
                    drOMPlan["SrpSoType"] = 0;

                    sSQL = "select a.cInvAddCode,a.cComUnitCode,b.cComUnitName from @u8.Inventory a left join @u8.ComputationUnit b on a.cComunitCode = b.cComunitCode  where a.cInvCode = '" + gridView明细.GetRowCellValue(i, gridCol子件编码).ToString().Trim() + "'";
                    DataTable dtInvCode = clsSQLCommond.ExecQuery(sSQL);
                    drOMPlan["InvCode"] = gridView明细.GetRowCellValue(i, gridCol子件编码).ToString().Trim();
                    drOMPlan["InvName"] = gridView明细.GetRowCellDisplayText(i, gridCol子件名称).ToString().Trim();
                    drOMPlan["InvStd"] = gridView明细.GetRowCellDisplayText(i, gridCol子件规格).ToString().Trim();

                    if (dtInvCode != null && dtInvCode.Rows.Count > 0)
                    {
                        drOMPlan["InvAddCode"] = dtInvCode.Rows[0]["cInvAddCode"];
                        drOMPlan["ComUnitCode"] = dtInvCode.Rows[0]["cComUnitCode"];
                        drOMPlan["ComUnitName"] = dtInvCode.Rows[0]["cComUnitName"];
                    }
                    drOMPlan["IsRem"] = false;
                    drOMPlan["Police"] = "PE";
                    //drOMPlan["MinQty"] = "";
                    //drOMPlan["MulQty"] = "";
                    //drOMPlan["FixQty"] = "";
                    //drOMPlan["SafeQty"] = "";
                    //drOMPlan["PlannerName"] = "";
                    //drOMPlan["Planner"] = "";
                    //drOMPlan["InvDefine1"] = "";
                    //drOMPlan["InvDefine2"] = "";
                    //drOMPlan["InvDefine3"] = "";
                    //drOMPlan["InvDefine4"] = "";
                    //drOMPlan["InvDefine5"] = "";
                    //drOMPlan["InvDefine6"] = "";
                    //drOMPlan["InvDefine7"] = "";
                    //drOMPlan["InvDefine8"] = "";
                    //drOMPlan["InvDefine9"] = "";
                    //drOMPlan["InvDefine10"] = "";
                    //drOMPlan["InvDefine11"] = "";
                    //drOMPlan["InvDefine12"] = "";
                    //drOMPlan["InvDefine13"] = "";
                    //drOMPlan["InvDefine14"] = "";
                    //drOMPlan["InvDefine15"] = "";
                    //drOMPlan["InvDefine16"] = "";
                    //drOMPlan["BasEngineerFigNo"] = "";
                    //drOMPlan["OrderQty"] = "";
                    drOMPlan["AccID"] = (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim();
                    drOMPlan["AccYear"] = (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4)).Trim();
                    drOMPlan["bClosed"] = false;
                    drOMPlan["bUsed"] = false;
                    drOMPlan["bAllBatchCreate"] = false;
                    //drOMPlan["cVenCode"] = "";
                    //drOMPlan["iTaxPrice"] = "";
                    //drOMPlan["iTaxRate"] = "";
                    //drOMPlan["iUnitPrice"] = "";
                    drOMPlan["bSave"] = false;
                    //drOMPlan["SvaeUID"] = "";
                    //drOMPlan["SaveDate"] = "";
                    drOMPlan["bAudit"] = false;
                    //drOMPlan["AuditUID"] = "";
                    //drOMPlan["AuditDate"] = "";
                    drOMPlan["bBeSure"] = false;
                    //drOMPlan["BeSureUID"] = "";
                    //drOMPlan["BeSureDate"] = "";
                    //drOMPlan["dVenPlanDate"] = "";
                    //drOMPlan["dVenCloseDate"] = "";
                    //drOMPlan["ClosedUID"] = "";
                    //drOMPlan["ClosedDate"] = "";
                    drOMPlan["bImport"] = true;
                    drOMPlan["ImportUID"] = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                    drOMPlan["ImportDate"] = d当前日期;
                    //drOMPlan["StartFlag"] = "";
                    //drOMPlan["Remark"] = "";

                    dtOMPlan.Rows.Add(drOMPlan);
                }

                for (int i = 0; i < dtOMPlan.Rows.Count; i++)
                {
                    //生成委外订单表体
                    aList.Add(clsGetSQL.GetInsertSQL("UFDLImport", "OMPlan", dtOMPlan, i));
                }

                    sSQL = " update dbo.订单评审运算1 set 下达委外人 = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',下达委外日期 = getdate() where 销售订单ID = " + txt销售订单ID.Text.Trim() + " and 帐套号 = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3);
                    aList.Add(sSQL);

                    s生成提示 = s生成提示 + "委外计划：" + dtOMPlan.Rows.Count + "行\n";

                #endregion
                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);

                    //GetSelList();
                    //iPage = dtSel.Rows.Count - 1;
                    //lPageInfo.Text = (iPage + 1).ToString() + "/" + dtSel.Rows.Count.ToString();

                    MsgBox("提示", "保存成功！\n合计执行语句:" + iCou + "条\n");

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

        private void Frm订单评审_下达委外计划_Load(object sender, EventArgs e)
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

            sSQL = "select * from dbo.订单评审运算3 " +
                    "where 销售订单ID = " + i销售订单ID + " and 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim() + " and 子件属性 = '委外'" +
                    " order by 子件编码,完成日期,iID";
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
            string sSQL = "select 销售订单ID from 订单评审运算1 where 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim() + " and isnull(审核人,'') <> '' and isnull(关闭人,'') = '' and isnull(下达委外人,'') = '' order by 销售订单号";
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
    }
}
