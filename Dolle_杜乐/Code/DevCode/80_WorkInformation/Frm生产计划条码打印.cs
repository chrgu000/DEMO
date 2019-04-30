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
    public partial class Frm生产计划条码打印 : FrameBaseFunction.Frm列表窗体模板
    {
        public Frm生产计划条码打印()
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

            decimal d工时 = 0;
            for (int i = 0; i < dtGrid.Rows.Count; i++)
            {
                d工时 = d工时 + ReturnObjectToDecimal(dtGrid.Rows[i]["工时理论"], 6);

                string s条形码 = dtGrid.Rows[i]["条形码"].ToString().Trim() + "-" + ReturnObjectToDecimal(dtGrid.Rows[i]["本次缴库数量"], 2);
                dtGrid.Rows[i]["条形码"] = s条形码;
            }

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
            dc = new DataColumn();
            dc.ColumnName = "条形码";
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
            dr["理论工时合计"] = d工时;
            dr["计划日期"] = dtm计划日期.DateTime.ToString("yyyy-MM-dd");
            if (lookUpEdit班组.EditValue != null)
            {
                dr["组别"] = lookUpEdit班组.Text.Trim();
            }
            dr["条形码"] = dtm计划日期.DateTime.ToString("yyMMdd") + lookUpEdit班组.EditValue.ToString().Trim() + dr["是否入库"].ToString().Trim();
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
            try
            {
                if (bFormLoad)
                {
                    if (dtm计划日期.Text.Trim() == "")
                    {
                        dtm计划日期.Focus();
                        throw new Exception("计划日期不能为空");
                    }

                    if (lookUpEdit班组.Text.Trim() == "")
                    {
                        lookUpEdit班组.Focus();
                        throw new Exception("班组不能为空");
                    }

                    string sSQL = @"
select cast(1 as bit) as 选择,w.vchrPer as 人员,w.cInvCode as 物料编码,sOrder as 外销订单,cInvCode2 as 产品编码,iQuantity2 as 订单数量,
    w.[WorkOrderNO] as 制造令号码,w.cInvName as 物料名称,w.cInvStd as 物料规格,w.[vchrEquipment] as 设备,w.[workProcedure] as 工序,dtmtime as 工时理论,
    w.iQuantity as 计划数量,w.iQtyPlan as 预计计划数量,w.iQtyPlan as 本次缴库数量,null as 完工数量,null as 工时,w.vchrRemark as [周未完工],w.[workProcedureNext] as 下一工序
    ,cast(w.[AutoID] as varchar(50)) as 条形码,w.托外结束时间 
    ,p.cPosName as 货位,bRdIn as 工序类型 
from UFDLImport.dbo.WorkPlan w left join @u8.Inventory i on i.cInvCode = w.cInvcode 
    left join UFDLImport..WorkDepment d on w.workDepment=d.fcode 
    left join @u8.Position p on p.cPosCode = i.cPosition 
where 1=1 
";
                    if (!chk包含已关闭.Checked)
                    {
                        sSQL = sSQL + " and (isnull(w.[iQuantity],0) > 0 or isnull(w.iQtyPlan,0) > 0 ) and isnull(bClose,0) = 0 and dtmPlan = '" + dtm计划日期.DateTime.ToString("yyyy-MM-dd").Trim() + "' and w.accid = '200' ";
                    }
                    else
                    {
                        sSQL = sSQL + " and dtmPlan >= '" + Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyy") + "-01-01' ";
                    }
                    //if (radio工序报表.Checked)
                    //{
                    //    sSQL = sSQL + " and isnull(w.bRDIn,0) = 0 ";
                    //}
                    //if (radio生产缴库.Checked)
                    //{
                    //    sSQL = sSQL + " and  isnull(w.bRDIn,0) = 1 ";
                    //}
                    if (radio流转缴库.Checked)
                    {
                        sSQL = sSQL + " and  isnull(w.bRDIn,0) = 2 ";
                    }

                    //将流转与工序报表合并为一个条码
                    if (radio工序报表.Checked)
                    {
                        sSQL = sSQL + " and (isnull(w.bRDIn,0) = 0 or  isnull(w.bRDIn,0) = 2)";
                    }
                    if (radio生产缴库.Checked)
                    {
                        sSQL = sSQL + " and  isnull(w.bRDIn,0) = 1 ";
                    }
    

                    if (lookUpEdit班组.Text.Trim() != "")
                    {
                        sSQL = sSQL + " and workDepment = '" + lookUpEdit班组.Text.Trim() + "' ";
                    }

                    sSQL = sSQL + " order by w.cInvCode,w.AutoID,sOrder,WorkOrderID,WorkOrderNO,WorkOrderRowNO,workProcedure";

                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    gridControl1.DataSource = dt;


                    chk全选.Checked = true;
                    gridCol选择.OptionsColumn.AllowEdit = true;
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
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
        private void Frm生产流转缴库_Load(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "select max(dtmPlan) from UFDLImport..WorkPlan";
                DateTime d = Convert.ToDateTime(clsSQLCommond.ExecGetScalar(sSQL));
                dtm计划日期.DateTime = d;

                GetLookUp();

                bFormLoad = true;

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
            }
            catch (Exception ee)
            {
                throw new Exception("加载参照信息失败：" + ee.Message);
            }
        }

        private void chk全选_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chk全选.Checked)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        gridView1.SetRowCellValue(i, gridCol选择, true);
                    }
                }
                else
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        gridView1.SetRowCellValue(i, gridCol选择, false);
                    }
                }
            }
            catch { }
        }

        private void radio工序报表_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radio工序报表.Checked )
                {
                    btnSel();
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
                    btnSel();
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
                if ( radio流转缴库.Checked)
                {
                    btnSel();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void radio全部_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if ( radio全部.Checked)
                {
                    btnSel();
                }
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
    }
}
