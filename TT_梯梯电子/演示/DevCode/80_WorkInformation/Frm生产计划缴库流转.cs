using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;
using System.Collections;

namespace WorkInformation
{
    public partial class Frm生产计划缴库流转 : FrameBaseFunction.Frm列表窗体模板
    {
        public Frm生产计划缴库流转()
        {
            InitializeComponent();

            #region 禁止用户调整表格
            gridView1.OptionsMenu.EnableColumnMenu = false;
            gridView1.OptionsMenu.EnableFooterMenu = false;
            gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            gridView1.OptionsMenu.ShowAutoFilterRowItem = false;
            gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            gridView1.OptionsMenu.ShowGroupSummaryEditorItem = false;
            gridView1.OptionsMenu.ShowAddNewSummaryItem  = DevExpress.Utils.DefaultBoolean.False;
            gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            gridView1.OptionsCustomization.AllowColumnMoving = false;
            //gridView1.OptionsCustomization.

            #endregion

            sLayoutHeadPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Head.xml";
            sLayoutGridPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Grid.xml";

            //if (File.Exists(sLayoutHeadPath))
            //    layoutControl1.RestoreLayoutFromXml(sLayoutHeadPath);

            //if (File.Exists(sLayoutGridPath))
            //{
            //    gridControl1.MainView.RestoreLayoutFromXml(sLayoutGridPath);
            //}

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
            }
            catch (Exception ee)
            {
                throw new Exception(sBtnText + " 失败! \n\n原因:\n  " + ee.Message);
            }
        }

        private void btnSave()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            try
            {
                string sErr = "";
                ArrayList aList = new ArrayList();

                sSQL = "select * from UFDLImport..WorkPlanDetail where 1=-1";
                DataTable dtWorkPlanDetail = clsSQLCommond.ExecQuery(sSQL);

                sSQL = "select * from UFDLImport..WorkPlanDetailDefective where 1=-1";
                DataTable dtWorkPlanDetailDefective = clsSQLCommond.ExecQuery(sSQL);

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (!Convert.ToBoolean(gridView1.GetRowCellValue(i, gridCol选择)))
                        continue;

                    string s人员 = gridView1.GetRowCellValue(i, gridCol人员).ToString().Trim();
                    if (s人员 == "")
                    {
                        sErr = sErr + "行" + (i + 1).ToString().Trim() + "员工信息为空\n";
                        continue;
                    }

                    decimal d本次接受数量 = ReturnObjectToDecimal(gridView1.GetRowCellDisplayText(i, gridCol本次接受数量), 6);
                    if (d本次接受数量 <= 0)
                        continue;

                    string s接受部门 = gridView1.GetRowCellValue(i, gridCol下一班组).ToString().Trim();
                    if (s接受部门 == "")
                    {
                        sErr = sErr + "行" + (i + 1).ToString().Trim() + "下一班组为空\n";
                        continue;
                    }

                    decimal d未完工数量 = ReturnObjectToDecimal(gridView1.GetRowCellDisplayText(i, gridCol未完工数量), 6);
                    decimal d订单数量 = ReturnObjectToDecimal(gridView1.GetRowCellDisplayText(i, gridCol订单数量), 6);
                    decimal d完工数量 = ReturnObjectToDecimal(gridView1.GetRowCellDisplayText(i, gridCol完工数量), 6);
                    decimal d入库超上限 = ReturnObjectToDecimal(gridView1.GetRowCellDisplayText(i, gridCol入库超上限), 6);
                    if (d订单数量 * (1 + d入库超上限) < d完工数量 + d本次接受数量)
                    {
                        sErr = sErr + "行" + (i + 1).ToString().Trim() + "接受数量超出入库上限\n";
                        continue;
                    }


                    string s设备 = gridView1.GetRowCellDisplayText(i, gridCol设备).ToString().Trim();

                    decimal d工时 = ReturnObjectToDecimal(gridView1.GetRowCellDisplayText(i, gridCol工时), 2);
                    //if (d工时 <= 0)
                    //{
                    //    sErr = sErr + "行" + (i + 1).ToString().Trim() + "工时必须大于0 \n";
                    //    continue;
                    //}

                    string sGuidHead = gridView1.GetRowCellValue(i, gridColGuidHead).ToString().Trim();

                    //string s母件编码 = gridView1.GetRowCellDisplayText(i, gridCol母件编码).ToString().Trim();
                    //string s母件名称 = gridView1.GetRowCellDisplayText(i, gridCol母件名称).ToString().Trim();
                    //if (s母件编码 == "" || s母件名称 == "")
                    //    sErr = sErr + "行" + (i + 1).ToString().Trim() + "母件为空\n";

                    string s制造令号码 = gridView1.GetRowCellDisplayText(i, gridCol制造令号码).ToString().Trim();
                    string s物料编码 = gridView1.GetRowCellDisplayText(i, gridCol物料编码).ToString().Trim();

                    string sGuid = Guid.NewGuid().ToString().Trim();

                    #region 工序报表(含流转缴库)
                    
                    if (radio工序报表.Checked)
                    {
                        //工序报表
                        if (ReturnObjectToInt(gridView1.GetRowCellValue(i, gridColbRDIn)) == 0)
                        {
                            sSQL = "insert into UFDLImport.dbo.WorkPlanDetail(WorkDep,iQuantity,GUIDHead,[GUID],dtmDay,vchruid,vchrPer,vchrFacility,workTime)values" +
                                "('" + s接受部门 + "'," + d本次接受数量 + ",'" + sGuidHead + "','" + sGuid + "',getdate(),'" + FrameBaseFunction.ClsBaseDataInfo.sUid + "','" + s人员 + "','" + s设备 + "'," + d工时 + ")";
                            aList.Add(sSQL);
                        }

                        //流转
                        if (ReturnObjectToInt(gridView1.GetRowCellValue(i, gridColbRDIn)) == 2)
                        {
                            //判断现场库是否有足够物料，物料不足不允许保存
                            sSQL = "select count(*) as iCount " +
                                    "from @u8.mom_order a inner join @u8.mom_orderdetail b on a.MoId = b.MoId " +
                                    "   inner join @u8.mom_moallocate c on b.MoDId = c.MoDId " +
                                    "	inner join @u8.bas_part d on c.ComponentId = d.PartId " +
                                    "	inner join @u8.CurrentStock e on e.cInvCode = d.InvCode and cWhCode = '0F' " +
                                    "where a.MoCode = '" + s制造令号码 + "' and b.InvCode = '" + s物料编码 + "' and " + d本次接受数量 + " * (BaseQtyN * (1 + CompScrap)/(BaseQtyD * (1 - CompScrap))) > e.iQuantity";
                            DataTable dtTemp = clsSQLCommond.ExecQuery(sSQL);
                            if (Convert.ToInt32(dtTemp.Rows[0]["iCount"]) > 0)
                            {
                                sErr = sErr + "行 " + (i + 1) + " 现场仓材料不足！\n";
                                continue;
                            }

                            //判断材料是否入库道冲，不是不允许保存
                            sSQL = "select count(*) as iCount " +
                                    "from @u8.mom_order a inner join @u8.mom_orderdetail b on a.MoId = b.MoId inner join @u8.mom_moallocate c on b.MoDId = c.MoDId " +
                                    "	inner join @u8.bas_part d on c.ComponentId = d.PartId " +
                                    "	inner join @u8.CurrentStock e on e.cInvCode = d.InvCode and cWhCode = '0F' " +
                                    "where a.MoCode = '" + s制造令号码 + "' and b.InvCode = '" + s物料编码 + "' and c.WIPType <> 1";
                            DataTable dtTemp2 = clsSQLCommond.ExecQuery(sSQL);
                            if (Convert.ToInt32(dtTemp.Rows[0]["iCount"]) > 0)
                            {
                                sErr = sErr + "行 " + (i + 1) + " 物料" + s物料编码 + "不是入库倒冲，请通知生管！\n";
                                continue;
                            }

                            DataRow drWorkPlanDetail = dtWorkPlanDetail.NewRow();

                            drWorkPlanDetail["WorkDep"] = gridView1.GetRowCellValue(i, gridCol班组).ToString().Trim();
                            drWorkPlanDetail["iQuantity"] = d本次接受数量;
                            drWorkPlanDetail["GUIDHead"] = gridView1.GetRowCellValue(i, gridColGuidHead).ToString().Trim();
                            drWorkPlanDetail["GUID"] = sGuid;
                            drWorkPlanDetail["dtmDay"] = DateTime.Now.ToString("yyyy-MM-dd hh:ss:mm");
                            drWorkPlanDetail["vchruid"] = FrameBaseFunction.ClsBaseDataInfo.sUid;
                            drWorkPlanDetail["vchrPer"] = gridView1.GetRowCellValue(i, gridCol人员).ToString().Trim();
                            drWorkPlanDetail["vchrFacility"] = gridView1.GetRowCellValue(i, gridCol设备).ToString().Trim();
                            drWorkPlanDetail["workTime"] = d工时;
                            drWorkPlanDetail["workDepmentNext2"] = gridView1.GetRowCellValue(i, gridCol下一班组).ToString().Trim();
                            drWorkPlanDetail["RDInType"] = gridView1.GetRowCellValue(i, gridColbRDIn).ToString().Trim();

                            //decimal d缴库数量 = ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol缴库数量), 2);
                            //decimal d流转数量 = ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol流转数量), 2);
                            //drWorkPlanDetail["QtyRDIn"] = d缴库数量;
                            drWorkPlanDetail["QtyRDL"] = d本次接受数量;

                            if (ReturnObjectToInt(gridView1.GetRowCellValue(i, gridColbRDIn).ToString().Trim()) == 1 || gridView1.GetRowCellDisplayText(i, gridCol下一班组).ToString().Trim() == "仓库")
                            {
                                drWorkPlanDetail["EnSureUid"] = "L";
                                drWorkPlanDetail["EnSureDate"] = DateTime.Now.ToString("yyyy-MM-dd hh:ss:mm");
                            }

                            dtWorkPlanDetail.Rows.Add(drWorkPlanDetail);

                            aList.Add(clsGetSQL.GetInsertSQL("UFDLImport", "WorkPlanDetail", dtWorkPlanDetail, dtWorkPlanDetail.Rows.Count - 1));
                        }
                    }

                    #endregion

                    #region 生产缴库

                    if (radio生产缴库.Checked || radio流转缴库.Checked)
                    {
                        //判断现场库是否有足够物料，物料不足不允许保存
                        sSQL = "select count(*) as iCount " +
                                "from @u8.mom_order a inner join @u8.mom_orderdetail b on a.MoId = b.MoId " +
                                "   inner join @u8.mom_moallocate c on b.MoDId = c.MoDId " +
                                "	inner join @u8.bas_part d on c.ComponentId = d.PartId " +
                                "	inner join @u8.CurrentStock e on e.cInvCode = d.InvCode and cWhCode = '0F' " +
                                "where a.MoCode = '" + s制造令号码 + "' and b.InvCode = '" + s物料编码 + "' and " + d本次接受数量 + " * (BaseQtyN * (1 + CompScrap)/(BaseQtyD * (1 - CompScrap))) > e.iQuantity";
                        DataTable dtTemp = clsSQLCommond.ExecQuery(sSQL);
                        if (Convert.ToInt32(dtTemp.Rows[0]["iCount"]) > 0)
                        {
                            sErr = sErr + "行 " + (i + 1) + " 现场仓材料不足！\n";
                            continue;
                        }

                        //判断材料是否入库道冲，不是不允许保存
                        sSQL = "select count(*) as iCount " +
                                "from @u8.mom_order a inner join @u8.mom_orderdetail b on a.MoId = b.MoId inner join @u8.mom_moallocate c on b.MoDId = c.MoDId " +
                                "	inner join @u8.bas_part d on c.ComponentId = d.PartId " +
                                "	inner join @u8.CurrentStock e on e.cInvCode = d.InvCode and cWhCode = '0F' " +
                                "where a.MoCode = '" + s制造令号码 + "' and b.InvCode = '" + s物料编码 + "' and c.WIPType <> 1";
                        DataTable dtTemp2 = clsSQLCommond.ExecQuery(sSQL);
                        if (Convert.ToInt32(dtTemp.Rows[0]["iCount"]) > 0)
                        {
                            sErr = sErr + "行 " + (i + 1) + " 物料" + s物料编码 + "不是入库倒冲，请通知生管！\n";
                            continue;
                        }

                        DataRow drWorkPlanDetail = dtWorkPlanDetail.NewRow();

                        drWorkPlanDetail["WorkDep"] = gridView1.GetRowCellValue(i, gridCol班组).ToString().Trim();
                        drWorkPlanDetail["iQuantity"] = d本次接受数量;
                        drWorkPlanDetail["GUIDHead"] = gridView1.GetRowCellValue(i, gridColGuidHead).ToString().Trim();
                        drWorkPlanDetail["GUID"] = sGuid;
                        drWorkPlanDetail["dtmDay"] = DateTime.Now.ToString("yyyy-MM-dd hh:ss:mm");
                        drWorkPlanDetail["vchruid"] = FrameBaseFunction.ClsBaseDataInfo.sUid;
                        drWorkPlanDetail["vchrPer"] = gridView1.GetRowCellValue(i, gridCol人员).ToString().Trim();
                        drWorkPlanDetail["vchrFacility"] = gridView1.GetRowCellValue(i, gridCol设备).ToString().Trim();
                        drWorkPlanDetail["workTime"] = d工时;
                        drWorkPlanDetail["workDepmentNext2"] = gridView1.GetRowCellValue(i, gridCol下一班组).ToString().Trim();
                        drWorkPlanDetail["RDInType"] = gridView1.GetRowCellValue(i, gridColbRDIn).ToString().Trim();

                        decimal d缴库数量 = ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol缴库数量), 2);
                        decimal d流转数量 = ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol流转数量), 2);
                        drWorkPlanDetail["QtyRDIn"] = d缴库数量;
                        drWorkPlanDetail["QtyRDL"] = d流转数量;

                        if (ReturnObjectToInt(gridView1.GetRowCellValue(i, gridColbRDIn).ToString().Trim()) == 1 || gridView1.GetRowCellDisplayText(i, gridCol下一班组).ToString().Trim() == "仓库")
                        {
                            drWorkPlanDetail["EnSureUid"] = "L";
                            drWorkPlanDetail["EnSureDate"] = DateTime.Now.ToString("yyyy-MM-dd hh:ss:mm");
                        }

                        dtWorkPlanDetail.Rows.Add(drWorkPlanDetail);

                        aList.Add(clsGetSQL.GetInsertSQL("UFDLImport", "WorkPlanDetail", dtWorkPlanDetail, dtWorkPlanDetail.Rows.Count - 1));
                    }

                    #endregion
                }

                if (sErr.Trim() != "")
                {
                    throw new Exception(sErr);
                }
                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("批量工序转移成功");
                    btnSel();
                }
                else
                {
                    MessageBox.Show("没有需要转移的数据");
                }

            }
            catch (Exception ee)
            {
                throw new Exception("保存失败：" + ee.Message);
            }
        }


        #region 按钮模板

        /// <summary>
        /// 将表格中Lookup之类的保存ID的数据转换成Text用于打印
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private DataTable SetPrintData(DataTable dt)
        {
            //DataTable dtState = (DataTable)ItemLookUpEdit设备.DataSource;
            //DataColumn dc = new DataColumn();
            //dc.ColumnName = "StateText";
            //dt.Columns.Add(dc);
           
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    DataRow[] drState = dtState.Select("iID = '" + dt.Rows[i]["State"].ToString().Trim() + "'");
            //    if (drState.Length > 0)
            //    {
            //        dt.Rows[i]["StateText"] = drState[0]["State"];
            //    }

            //}

            return dt;
        }

        /// <summary>
        /// 打印
        /// </summary>
        private void btnPrint()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            base.dsPrint.Tables.Clear();
            DataTable dtGrid = SetPrintData(((DataTable)gridControl1.DataSource).Copy());
            DataView dv = dtGrid.DefaultView;
            dv.RowFilter = " 选择 = 1 ";
            dtGrid = dv.ToTable().Copy();

            dtGrid.TableName = "dtGrid";
            base.dsPrint.Tables.Add(dtGrid);

            DataTable dtHead = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "标题";
            dtHead.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "计划日期";
            dtHead.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "组别";
            dtHead.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "是否入库";
            dtHead.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "理论工时合计";
            dtHead.Columns.Add(dc);

            DataRow dr = dtHead.NewRow();
            if (radio工序报表.Checked)
            {
                dr["标题"] = "工序报表";
                dr["是否入库"] = "N";
            }
            if (radio流转缴库.Checked)
            {
                dr["标题"] = "流转缴库";
                dr["是否入库"] = "L";
            }
            if (radio生产缴库.Checked)
            {
                dr["标题"] = "生产缴库";
                dr["是否入库"] = "Y";
            }
            dr["理论工时合计"] = gridCol工时理论.SummaryText;
            dr["计划日期"] = dtm计划日期.DateTime.ToString("yyyy-MM-dd");
            if (lookUpEdit班组.EditValue != null)
            {
                dr["组别"] = lookUpEdit班组.Text.Trim();
            }
            dtHead.Rows.Add(dr);

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
                    gridView1.ExportToXls(sF.FileName);
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
            //if (layoutControl1 == null) return;
            //if (sText == "布局")
            //{
            //    //layoutControl1.ShowCustomizationForm();
            //    layoutControl1.AllowCustomizationMenu = true;
            //    base.toolStripMenuBtn.Items["Layout"].Text = "保存布局";

            //    gridView1.OptionsMenu.EnableColumnMenu = true;
            //    gridView1.OptionsMenu.EnableFooterMenu = true;
            //    gridView1.OptionsMenu.EnableGroupPanelMenu = true;
            //    //gridView1.OptionsMenu.ShowAddNewSummaryItem = true;
            //    gridView1.OptionsMenu.ShowAutoFilterRowItem = true;
            //    gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = true;
            //    gridView1.OptionsMenu.ShowGroupSortSummaryItems = true;
            //    gridView1.OptionsMenu.ShowGroupSummaryEditorItem = true;
            //    gridView1.OptionsCustomization.AllowColumnMoving = true;
            //}
            //else
            //{
            //    //layoutControl1.HideCustomizationForm();
            //    layoutControl1.AllowCustomizationMenu = false;
            //    gridView1.OptionsMenu.EnableColumnMenu = false;
            //    gridView1.OptionsMenu.EnableFooterMenu = false;
            //    gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            //    //gridView1.OptionsMenu.ShowAddNewSummaryItem = false;
            //    gridView1.OptionsMenu.ShowAutoFilterRowItem = false;
            //    gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            //    gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            //    gridView1.OptionsMenu.ShowGroupSummaryEditorItem = false;
            //    gridView1.OptionsCustomization.AllowColumnMoving = false;


            //    if (!Directory.Exists(base.sProPath + "\\layout"))
            //        Directory.CreateDirectory(base.sProPath + "\\layout");

            //    base.toolStripMenuBtn.Items["Layout"].Text = "布局";

            //    DialogResult d = MessageBox.Show("是否保存?\n是：保存界面样式\n否：恢复默认界面样式,下次加载时将以默认样式打开\n", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
            //    if (d == DialogResult.Yes)
            //    {
            //        layoutControl1.SaveLayoutToXml(sLayoutHeadPath);
            //        gridControl1.MainView.SaveLayoutToXml(sLayoutGridPath);
            //    }
            //    else if (d == DialogResult.No)
            //    {
            //        if (File.Exists(sLayoutHeadPath))
            //            File.Delete(sLayoutHeadPath);

            //        if (File.Exists(sLayoutGridPath))
            //            File.Delete(sLayoutGridPath);
            //    }
            //}
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
            throw new NotImplementedException();
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
            if (bFormLoad)
            {

                if (dtm计划日期.Text.Trim() == "")
                {
                    dtm计划日期.Focus();
                    throw new Exception("请选择计划日期");
                }
                if (lookUpEdit班组.Text.Trim() == "")
                {
                    lookUpEdit班组.Focus();
                    throw new Exception("请选择班组");
                }

                string sSQL = @"
select cast(0 as bit) as 选择,w.guid as guidhead,w.vchrPer as 人员,w.cInvCode as 物料编码,sOrder as 外销订单,cInvCode2 as 产品编码,iQuantity2 as 订单数量, 
    w.[WorkOrderNO] as 制造令号码,w.cInvName as 物料名称,w.cInvStd as 物料规格,w.[vchrEquipment] as 设备,w.[workProcedure] as 工序,dtmtime as 工时理论, 
    w.iQuantity as 计划数量,w.iQtyPlan as 预计计划数量,null as 工时,w.vchrRemark as [周未完工],w.[workProcedureNext] as 下一工序,w.[AutoID] as 条形码,w.托外结束时间 
    ,p.cPosName as 货位 ,isnull(a.生产订单余量,0) as 生产订单余量,w.workDepment as 班组,case when isnull(w.bRDIn,0) <> 0 then '仓库' else w.workDepmentNext end as 下一班组
    ,CAST(null as decimal(16,2)) AS 本次接受数量,b.完工数量,w.iQuantity - isnull(b.完工数量,0) as 未完工数量,cast(null as varchar(200)) as 母件编码,cast(null as varchar(200)) as 母件名称
    ,e.fInExcess as 入库超上限,w.bRDIn ,CAST(null as decimal(16,2)) AS 流转数量 ,CAST(null as decimal(16,2)) AS 缴库数量
from UFDLImport.dbo.WorkPlan w left join @u8.Inventory i on i.cInvCode = w.cInvcode 
    left join UFDLImport..WorkDepment d on w.workDepment=d.fcode 
    left join @u8.Position p on p.cPosCode = i.cPosition 
    left join (
                    select mocode as 生产订单号,(sum(isnull(Qty,0))-sum(isnull(QualifiedInQty,0))) as 生产订单余量,InvCode as 产品编码,sum(Qty) as 生产订单数量,max(SoCode) as SoCode 
                    from @u8.mom_order m left join @u8.mom_orderdetail md on m.moid = md.moid
                    where md.Status = 3
                    group by m.mocode,md.InvCode
                )a on a.生产订单号 = w.[WorkOrderNO] and w.cInvCode = a.产品编码
     left join (
					select SUM(iQuantity) as 完工数量,GUIDHead
					from UFDLImport.dbo.WorkPlanDetail
					group by GUIDHead
				)b on b.GUIDHead = w.GUID
	 inner join @u8.Inventory e on e.cInvCode = w.cInvCode
where 1=1 and 11111111 and (isnull(w.[iQuantity],0) > 0 or isnull(w.iQtyPlan,0) > 0 ) and isnull(bClose,0) = 0 
    and dtmPlan = '22222222' and w.accid = '200' 
    and workDepment = '33333333'
order by w.cInvCode,w.AutoID,sOrder,WorkOrderID,WorkOrderNO,WorkOrderRowNO,workProcedure
";

                if (radio工序报表.Checked)
                {
                    sSQL = sSQL.Replace("11111111", "(isnull(w.bRDIn,0) = 0 or isnull(w.bRDIn,0) = 2)");
                }
                if (radio生产缴库.Checked)
                {
                    sSQL = sSQL.Replace("11111111", "isnull(w.bRDIn,0) = 1");
                }
                if (radio流转缴库.Checked)
                {
                    sSQL = sSQL.Replace("11111111", "1=1");
                }

                if (!chk包含已完工.Checked)
                {
                    sSQL = sSQL.Replace("1=1", " 1=1 and isnull(w.iQuantity,0) > isnull(b.完工数量,0)");
                }

                sSQL = sSQL.Replace("22222222", dtm计划日期.DateTime.ToString("yyyy-MM-dd").Trim());
                sSQL = sSQL.Replace("33333333", lookUpEdit班组.Text.Trim());

                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                gridControl1.DataSource = dt;
            }
        }

        /// <summary>
        /// 首页
        /// </summary>
        private void btnFirst()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 上页
        /// </summary>
        private void btnPrev()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 下页
        /// </summary>
        private void btnNext()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 末页
        /// </summary>
        private void btnLast()
        {
            throw new NotImplementedException();
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
            gridView1.AddNewRow();
        }
        /// <summary>
        /// 删行
        /// </summary>
        private void btnDelRow()
        {
            for (int i = gridView1.RowCount - 1; i >= 0 ; i--)
            {
                if (gridView1.IsRowSelected(i))
                {
                    gridView1.DeleteRow(i);
                }
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
            if (MessageBox.Show("本功能仅能删除未进行工序转移的导入工单，是否继续？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {

                ArrayList aList = new ArrayList();
                string sSQL = "";

                int iRow1 = gridView1.RowCount;

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridCol选择)))
                    {
                        sSQL = " if not exists(select * from UFDLImport.dbo.WorkPlan w inner join UFDLImport.dbo.WorkPlanDetail wd on w.GUID = wd.GUIDHead where w.autoid = " + gridView1.GetRowCellValue(i, gridCol条形码).ToString().Trim() + ")	delete UFDLImport..WorkPlan where autoid =  " + gridView1.GetRowCellValue(i, gridCol条形码).ToString().Trim();
                        aList.Add(sSQL);
                    }
                }

                clsSQLCommond.ExecSqlTran(aList);
                btnSel();

                int iRow2 = gridView1.RowCount;

                MessageBox.Show("删除行数" + (iRow1 - iRow2) + "成功！");
            }
        }

      
        /// <summary>
        /// 撤销
        /// </summary>
        private void btnUnDo()
        {

        }
        /// <summary>
        /// 审核
        /// </summary>
        private void btnAudit()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 弃审
        /// </summary>
        private void btnUnAudit()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 打开
        /// </summary>
        private void btnOpen()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 关闭
        /// </summary>
        private void btnClose()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 变更
        /// </summary>
        private void btnAlter()
        {
            throw new NotImplementedException();
        }

        #endregion


        bool bFormLoad = false;
        private void Frm生产计划缴库流转_Load(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "select max(dtmPlan) from UFDLImport..WorkPlan";
                DateTime d = Convert.ToDateTime(clsSQLCommond.ExecGetScalar(sSQL));
                dtm计划日期.DateTime = d;

                GetLookUp();

                bFormLoad = true;

                txt条形码.Enabled = true; txt条形码.ReadOnly = false;
                dtm计划日期.Enabled = true; dtm计划日期.Properties.ReadOnly = false;
                lookUpEdit班组.Enabled = true; lookUpEdit班组.Properties.ReadOnly = false;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
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

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    decimal d = ReturnObjectToDecimal(gridView1.GetRowCellDisplayText(e.RowHandle, gridView1.Columns["缺料数量"]), 6);
                    if (d > 0)
                    {
                        e.Appearance.BackColor = Color.Tomato;
                    }
                }
            }
            catch
            { }
        }

        private void GetLookUp()
        {
            try
            {
                string sSQL = "select cDepCode as FCode,cDepName as FName from @u8.Department where cDepCode = '902' or cDepCode = '901' or cDepCode = '906' or cDepCode = '903' or cDepCode = '904' or cDepCode = '801' order by cDepName";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                lookUpEdit班组.Properties.DataSource = dt;

                sSQL = "select MachineNo,Machine from dbo.Machine order by MachineNo";
                dt = clsSQLCommond.ExecQuery(sSQL);
                ItemLookUpEdit设备.DataSource = dt;
            }
            catch (Exception ee)
            {
                throw new Exception("加载参照信息失败：" + ee.Message);
            }
        }

        private void dtm计划日期_EditValueChanged(object sender, EventArgs e)
        {

            try
            {
                btnSel();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void lookUpEdit班组_EditValueChanged(object sender, EventArgs e)
        {

            try
            {
                btnSel();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void radio工序报表_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radio工序报表.Checked)
                {
                    gridCol缴库数量.Visible = false;
                    gridCol流转数量.Visible = false;
                    gridCol本次接受数量.OptionsColumn.AllowEdit = true;

                    if (radio工序报表.Checked)
                    {
                        btnSel();
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void radio生产缴库_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radio生产缴库.Checked)
                {
                    gridCol缴库数量.Visible = true;
                    gridCol流转数量.Visible = true;
                    gridCol本次接受数量.OptionsColumn.AllowEdit = false;

                    if (radio生产缴库.Checked)
                    {
                        btnSel();
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void radio流转缴库_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radio流转缴库.Checked)
                {
                    gridCol缴库数量.Visible = true;
                    gridCol流转数量.Visible = true;
                    gridCol本次接受数量.OptionsColumn.AllowEdit = false;

                    if (radio流转缴库.Checked)
                    {
                        btnSel();
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void txt条形码_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (txt条形码.Text.Trim() == string.Empty)
                {
                    return;
                }
                if (e.KeyCode == Keys.Enter)
                {
                    bFormLoad = false;
                    string s条形码 = txt条形码.Text.Trim();
                    string s = s条形码.Substring(0, 2) + "-" + s条形码.Substring(2, 2) + "-" + s条形码.Substring(4, 2);
                    dtm计划日期.DateTime = Convert.ToDateTime(s);

                    lookUpEdit班组.EditValue = s条形码.Substring(6, 3);

                    s = s条形码.Substring(9, 1).ToUpper();
                    if (s == "N")
                        radio工序报表.Checked = true;
                    if (s == "Y")
                        radio生产缴库.Checked = true;
                    if (s == "L")
                        radio流转缴库.Checked = true;

                    bFormLoad = true;
                    btnSel();
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
                if (e.Column != gridCol选择)
                    gridView1.SetRowCellValue(e.RowHandle, gridCol选择, true);

                if (e.Column == gridCol缴库数量 || e.Column == gridCol流转数量)
                {
                    decimal d缴库数量 = ReturnObjectToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol缴库数量), 2);
                    decimal d流转数量 = ReturnObjectToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol流转数量), 2);

                    gridView1.SetRowCellValue(e.RowHandle, gridCol本次接受数量, d缴库数量 + d流转数量);
                }
            }
            catch { }
        }

        private void ItemButtonEdit人员_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string sSQL = "select FCode as 编码,FName as 姓名 from  UFDLImport..EmployeeInfo order by FCode";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            Frm列表参照 f = new Frm列表参照(dt);
            f.ShowDialog();
            if (f.DialogResult == DialogResult.Yes)
            {
                string s = f.sKey;
                DataRow[] dr = dt.Select(" 编码 = '" + s + "' ");
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridCol人员, dr[0][1].ToString().Trim());
            }
        }

        private void ItemButtonEdit母件编码_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string sSQL = @"    
select distinct bas.InvCode as 母件编码,i.cInvName as 母件名称,i.cInvStd as 母件规格
from @u8.bom_bom b
   left join @u8.bom_parent bP on b.BomId=bP.BomId left join @u8.bas_part bas on bas.PartId = bP.ParentId 
   left join @u8.bom_opcomponent bOP on bOp.BomId = b.BomId left join @u8.bas_part bas2 on bOP.ComponentId = bas2.partid left join @u8.Inventory i on i.cInvCode =bas.InvCode
where bas2.Invcode = '111111'
order by bas.InvCode";

    sSQL = sSQL.Replace("111111",gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle,gridCol物料编码).ToString().Trim());
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            Frm列表参照 f = new Frm列表参照(dt);
            f.ShowDialog();
            if (f.DialogResult == DialogResult.Yes)
            {
                string s = f.sKey;
                DataRow[] dr = dt.Select(" 母件编码 = '" + s + "' ");
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridCol母件编码, dr[0][0].ToString().Trim());
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridCol母件名称, dr[0][1].ToString().Trim());
            }
        }

    }
}
