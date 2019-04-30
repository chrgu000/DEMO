using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;
using DevExpress.XtraGrid.Views.Grid;

namespace ImportDLL
{
    public partial class FrmProductionLineStateList : FrameBaseFunction.FrmFromModel
    {
        TH.Model.ProductionLineState Model = new TH.Model.ProductionLineState();
        TH.DAL.ProductionLineState DAL = new TH.DAL.ProductionLineState();

        public FrmProductionLineStateList()
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

            sTableList = "WorkCalendarState";

            sLayoutHeadPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Head.xml";
            sLayoutGridPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Grid.xml";

            if (File.Exists(sLayoutHeadPath))
                layoutControl1.RestoreLayoutFromXml(sLayoutHeadPath);

            if (File.Exists(sLayoutGridPath))
            {
                gridControl1.MainView.RestoreLayoutFromXml(sLayoutGridPath);
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
                    case "add":
                        btnAdd();
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

        private void btnAdd()
        {
            //decimal dHours = ReturnObjectToDecimal(textEditDayTime.Text.Trim(), 1);
            //if (dHours <= 0)
            //{
            //    throw new Exception("请先设定默认日工时");
            //}
            //try
            //{
            //    gridView1.FocusedRowHandle -= 1;
            //    gridView1.FocusedRowHandle += 1;
            //}
            //catch { }

            //for (int i = 0; i < gridView1.RowCount; i++)
            //{
            //    if(!Convert.ToBoolean(gridView1.GetRowCellValue(i,gridColchoose)))
            //        continue;

            //    for (int j = 0; j < gridView1.Columns.Count; j++)
            //    {
            //        string sName = gridView1.Columns[j].Name.Trim();
            //        if (sName.Length > 8 && sName.Substring(0, 8) == "gridColi" && ReturnObjectToInt(sName.Substring(8)) > 0)
            //        {
            //            string sYear = gridView1.GetRowCellValue(i, gridColiYear).ToString().Trim();
            //            string sMonth = gridView1.GetRowCellValue(i, gridColiMonth).ToString().Trim();
            //            string sDay = sName.Substring(8);
            //            string sDate = sYear + "-" + sMonth + "-" + sDay;

            //            try
            //            {
            //                DateTime d = Convert.ToDateTime(sDate);
            //                if (d < DateTime.Today)
            //                    continue;

            //                DayOfWeek sWeek = d.DayOfWeek;
            //                if (sWeek != DayOfWeek.Saturday && sWeek != DayOfWeek.Sunday)
            //                    gridView1.SetRowCellValue(i, gridView1.Columns[j], dHours);
            //                else
            //                    gridView1.SetRowCellValue(i, gridView1.Columns[j], DBNull.Value);

            //            }
            //            catch { }
            //        }
            //    }
            //}
        }


        #region 按钮模板

        /// <summary>
        /// 将表格中Lookup之类的保存ID的数据转换成Text用于打印
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private DataTable SetPrintData(DataTable dt)
        {
            //DataTable dtState = (DataTable)ItemLookUpEditState.DataSource;
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

            //return dt;
            return null;
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
            if (layoutControl1 == null) return;
            if (sText == "布局")
            {
                //layoutControl1.ShowCustomizationForm();
                layoutControl1.AllowCustomizationMenu = true;
                base.toolStripMenuBtn.Items["Layout"].Text = "保存布局";

                gridView1.OptionsMenu.EnableColumnMenu = true;
                gridView1.OptionsMenu.EnableFooterMenu = true;
                gridView1.OptionsMenu.EnableGroupPanelMenu = true;
                //gridView1.OptionsMenu.ShowAddNewSummaryItem = true;
                gridView1.OptionsMenu.ShowAutoFilterRowItem = true;
                gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = true;
                gridView1.OptionsMenu.ShowGroupSortSummaryItems = true;
                gridView1.OptionsMenu.ShowGroupSummaryEditorItem = true;
                gridView1.OptionsCustomization.AllowColumnMoving = true;
            }
            else
            {
                //layoutControl1.HideCustomizationForm();
                layoutControl1.AllowCustomizationMenu = false;
                gridView1.OptionsMenu.EnableColumnMenu = false;
                gridView1.OptionsMenu.EnableFooterMenu = false;
                gridView1.OptionsMenu.EnableGroupPanelMenu = false;
                //gridView1.OptionsMenu.ShowAddNewSummaryItem = false;
                gridView1.OptionsMenu.ShowAutoFilterRowItem = false;
                gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
                gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
                gridView1.OptionsMenu.ShowGroupSummaryEditorItem = false;
                gridView1.OptionsCustomization.AllowColumnMoving = false;


                if (!Directory.Exists(base.sProPath + "\\layout"))
                    Directory.CreateDirectory(base.sProPath + "\\layout");

                base.toolStripMenuBtn.Items["Layout"].Text = "布局";

                DialogResult d = MessageBox.Show("是否保存?\n是：保存界面样式\n否：恢复默认界面样式,下次加载时将以默认样式打开\n", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
                if (d == DialogResult.Yes)
                {
                    layoutControl1.SaveLayoutToXml(sLayoutHeadPath);
                    gridControl1.MainView.SaveLayoutToXml(sLayoutGridPath);
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
        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
            GetGrid();
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
            //for (int i = gridView1.RowCount - 1; i >= 0 ; i--)
            //{
            //    if (gridView1.IsRowSelected(i))
            //    {
            //        gridView1.DeleteRow(i);
            //    }
            //}
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
            //string sErr = "";
            //string sErrInfo = "";
            //for (int iRow = gridView1.RowCount - 1; iRow >= 0; iRow--)
            //{
            //    if (gridView1.IsRowSelected(iRow))
            //    {
            //        if (!CheckCanDel(gridView1.GetRowCellValue(iRow, gridColMachineNO).ToString().Trim(), out sErrInfo))
            //        {
            //            sErr = sErr + "设备:" + gridView1.GetRowCellValue(iRow, gridColMachineNO).ToString().Trim() + "  " + gridView1.GetRowCellValue(iRow, gridColMachine).ToString().Trim() + sErr + "\n";
            //        }
            //    }
            //}

            //if (sErr.Length > 0)
            //{
            //    MsgBox("设备已经使用不能删除", sErr);
            //    return;
            //}
            //DialogResult d = MessageBox.Show("确定删除选中的 " + gridView1.SelectedRowsCount + " 行设备么？\n是：继续\n否：取消", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            //if (d != System.Windows.Forms.DialogResult.Yes)
            //{
            //    return;
            //}

            //aList = new System.Collections.ArrayList();
            //for (int iRow = gridView1.RowCount - 1; iRow >= 0; iRow--)
            //{
            //    if (gridView1.IsRowSelected(iRow))
            //    {
            //        sSQL = "select * from dbo.Machine where 1=-1";
            //        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            //        DataRow dr = dt.NewRow();
            //        dr["MachineNO"] = gridView1.GetRowCellValue(iRow, gridColMachineNO).ToString().Trim();
            //        dr["Machine"] = gridView1.GetRowCellValue(iRow, gridColMachine).ToString().Trim();
            //        dr["负责人"] = gridView1.GetRowCellValue(iRow, gridCol负责人).ToString().Trim();
            //        dr["State"] = gridView1.GetRowCellValue(iRow, gridColState).ToString().Trim();
            //        dr["Remark"] = gridView1.GetRowCellValue(iRow, gridColRemark).ToString().Trim();
            //        dt.Rows.Add(dr);
            //        sSQL = clsGetSQL.GetDeleteSQL( "Machine", dt, 0);
            //        aList.Add(sSQL);
            //    }
            //}

            //if (aList.Count > 0)
            //{
            //    int iCou = clsSQLCommond.ExecSqlTran(aList);
            //    MessageBox.Show("保存成功！\n合计执行语句:" + iCou + "条");
            //    GetGrid();
            //}
        }

      
        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave()
        {
            //try
            //{
            //    gridView1.FocusedRowHandle -= 1;
            //    gridView1.FocusedRowHandle += 1;
            //}
            //catch { }

            //try
            //{
            //    dtBingGrid = (DataTable)gridControl1.DataSource;
            //    for (int i = 0; i < dtBingGrid.Rows.Count; i++)
            //    {
            //        dtBingGrid.Rows[i]["dDate"] = dateEdit1.DateTime.ToString("yyyy-MM-dd");
            //    }

            //    int iCou = BLL.Save(dtBingGrid);

            //    if (iCou > 0)
            //    {
            //        MessageBox.Show("保存成功");
            //        GetGrid();
            //    }
            //    else
            //    {
            //        MessageBox.Show("请选择需要保存的数据");
            //    }
            //}
            //catch (Exception ee)
            //{
            //    MsgBox("保存失败", ee.Message);
            //}
        }
        /// <summary>
        /// 撤销
        /// </summary>
        private void btnUnDo()
        {
            int iFocRow = gridView1.FocusedRowHandle;
            GetGrid();
            gridView1.FocusedRowHandle = iFocRow;
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
            //try
            //{
            //    gridView1.FocusedRowHandle -= 1;
            //    gridView1.FocusedRowHandle += 1;
            //}
            //catch { }

            //try
            //{
            //    dtBingGrid = (DataTable)gridControl1.DataSource;

            //    int iCou = BLL.Open(dtBingGrid);

            //    if (iCou > 0)
            //    {
            //        MessageBox.Show("打开成功");
            //        GetGrid();
            //    }
            //    else
            //    {
            //        MessageBox.Show("请选择需要打开的数据");
            //    }
            //}
            //catch (Exception ee)
            //{
            //    MsgBox("保存失败", ee.Message);
            //}
        }
        /// <summary>
        /// 关闭
        /// </summary>
        private void btnClose()
        {
            //try
            //{
            //    gridView1.FocusedRowHandle -= 1;
            //    gridView1.FocusedRowHandle += 1;
            //}
            //catch { }

            //try
            //{
            //    dtBingGrid = (DataTable)gridControl1.DataSource;

            //    int iCou = BLL.Close(dtBingGrid);

            //    if (iCou > 0)
            //    {
            //        MessageBox.Show("关闭成功");
            //        GetGrid();
            //    }
            //    else
            //    {
            //        MessageBox.Show("请选择需要关闭的数据");
            //    }
            //}
            //catch (Exception ee)
            //{
            //    MsgBox("保存失败", ee.Message);
            //}
        }
        /// <summary>
        /// 变更
        /// </summary>
        private void btnAlter()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                GetLookUp();

                lookUpEditiYear.EditValue = DateTime.Now.Year.ToString();
                lookUpEditiMonth.EditValue = DateTime.Now.Month.ToString();

                btnSel();
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

        private void GetGrid()
        {
            AddCol();

            int iYear = ReturnObjectToInt(lookUpEditiYear.EditValue);
            if (iYear == 0)
                iYear = DateTime.Now.Year;
            int iMonth = ReturnObjectToInt(lookUpEditiMonth.EditValue);
            if (iMonth == 0)
                iMonth = DateTime.Now.Month;

            int iDay = Convert.ToDateTime(iYear.ToString() + "-" + iMonth + "-01").AddMonths(1).AddDays(-1).Day;

            dtBingGrid = DAL.GetMonthList(iYear.ToString() + "-" + iMonth.ToString() + "-01");

            gridControl1.DataSource = dtBingGrid;
            gridView1.FocusedRowHandle = 0;
        }
      
        private void GetLookUp()
        {
            DataTable dt = DAL.GetLookup();
            ItemLookUpEditState.DataSource = dt;

            dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "iYear";
            dt.Columns.Add(dc);
            for (int i = 2014; i <= DateTime.Today.Year + 1; i++)
            {
                DataRow dr2 = dt.NewRow();
                dr2["iYear"] = i;
                dt.Rows.Add(dr2);
            }
            lookUpEditiYear.Properties.DataSource = dt;

            dt = new DataTable();
            dc = new DataColumn();
            dc.ColumnName = "iMonth";
            dt.Columns.Add(dc);
            for (int i = 1; i <=12; i++)
            {
                DataRow dr2 = dt.NewRow();
                dr2["iMonth"] = i;
                dt.Rows.Add(dr2);
            }
            lookUpEditiMonth.Properties.DataSource = dt;
        }

        private void AddCol()
        {
            for (int i = gridView1.Columns.Count - 1; i >= 0; i--)
            {
                string sName = gridView1.Columns[i].Name.Trim();
                if (sName.Length > 8 && sName.Substring(0, 8) == "gridColi" && ReturnObjectToInt(sName.Substring(8)) > 0)
                {
                    gridView1.Columns.RemoveAt(i);
                }
            }

            int iYear = ReturnObjectToInt(lookUpEditiYear.EditValue);
            if (iYear == 0)
                iYear = DateTime.Now.Year;
            int iMonth = ReturnObjectToInt(lookUpEditiMonth.EditValue);
            if (iMonth == 0)
                iMonth = DateTime.Now.Month;
            int iDay = Convert.ToDateTime(iYear.ToString() + "-" + iMonth.ToString() + "-01").AddMonths(1).AddDays(-1).Day;

            for (int i = 1; i <= iDay; i++)
            {
                DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColi = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
                gridColi.Caption = i.ToString();
                gridColi.FieldName = "i" + i.ToString();
                gridColi.Name = "gridColi" + i.ToString();
                gridColi.Visible = true;
                gridColi.Width = 35;
                gridColi.VisibleIndex = i + 9;
                gridColi.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                gridColi.OptionsColumn.AllowEdit = false;
                gridColi.ColumnEdit = ItemLookUpEditState;
                gridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { gridColi });
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                DevExpress.Utils.AppearanceDefault appTomato = new DevExpress.Utils.AppearanceDefault(Color.Tomato);
                DevExpress.Utils.AppearanceDefault appLawnGreen = new DevExpress.Utils.AppearanceDefault(Color.LawnGreen);

                string sName = e.Column.Name.ToString().Trim();
                if (sName.Length > 8 && sName.Substring(0, 8) == "gridColi" && ReturnObjectToInt(sName.Substring(8)) > 0)
                {
                    if (ReturnObjectToInt(gridView1.GetRowCellValue(e.RowHandle, e.Column)) > 1)
                    {
                        DevExpress.Utils.AppearanceHelper.Apply(e.Appearance, appTomato);
                    }
                }
            }
            catch (Exception ee)
            { }
        }
    }
}
