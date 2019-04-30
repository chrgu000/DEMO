using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;

namespace ImportDLL
{
    public partial class FrmWorkCalendar : FrameBaseFunction.FrmFromModel
    {
        TH.DAL.GetBaseData DALGetBaseData = new TH.DAL.GetBaseData();
        TH.Model.WorkCalendar Model = new TH.Model.WorkCalendar();
        TH.BLL.WorkCalendar BLL = new TH.BLL.WorkCalendar();
        TH.DAL.ReportLookUp DALLookup = new TH.DAL.ReportLookUp();

        string sLineNo;

        public FrmWorkCalendar()
        {
            InitializeComponent();

            #region 禁止用户调整表格
            gridView日历.OptionsMenu.EnableColumnMenu = false;
            gridView日历.OptionsMenu.EnableFooterMenu = false;
            gridView日历.OptionsMenu.EnableGroupPanelMenu = false;
            gridView日历.OptionsMenu.ShowAutoFilterRowItem = false;
            gridView日历.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            gridView日历.OptionsMenu.ShowGroupSortSummaryItems = false;
            gridView日历.OptionsMenu.ShowGroupSummaryEditorItem = false;
            gridView日历.OptionsMenu.ShowAddNewSummaryItem  = DevExpress.Utils.DefaultBoolean.False;
            gridView日历.OptionsBehavior.FocusLeaveOnTab = true;
            gridView日历.OptionsCustomization.AllowColumnMoving = false;
            //gridView1.OptionsCustomization.

            #endregion

            sTableList = "WorkCalendar";

            sLayoutHeadPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Head.xml";
            sLayoutGridPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Grid.xml";

            if (File.Exists(sLayoutHeadPath))
                layoutControl1.RestoreLayoutFromXml(sLayoutHeadPath);

            if (File.Exists(sLayoutGridPath))
            {
                gridControl日历.MainView.RestoreLayoutFromXml(sLayoutGridPath);
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
            dtHolidays = BLL.GetHolidays(lookUpEditYear.EditValue.ToString());

            decimal dHours = ReturnObjectToDecimal(textEditDayTime.Text.Trim(), 1);
            if (dHours <= 0)
            {
                throw new Exception("请先设定默认日工时");
            }
            try
            {
                gridView日历.FocusedRowHandle -= 1;
                gridView日历.FocusedRowHandle += 1;
            }
            catch { }

            for (int i = 0; i < gridView日历.RowCount; i++)
            {
                if(!Convert.ToBoolean(gridView日历.GetRowCellValue(i,gridColchoose)))
                    continue;

                for (int j = 0; j < gridView日历.Columns.Count; j++)
                {
                    string sName = gridView日历.Columns[j].Name.Trim();
                    if (sName.Length > 8 && sName.Substring(0, 8) == "gridColi" && ReturnObjectToInt(sName.Substring(8)) > 0)
                    {
                        string sYear = gridView日历.GetRowCellValue(i, gridColiYear).ToString().Trim();
                        string sMonth = gridView日历.GetRowCellValue(i, gridColiMonth).ToString().Trim();
                        string sDay = sName.Substring(8);
                        string sDate = sYear + "-" + sMonth + "-" + sDay;

                        try
                        {
                            DateTime d = Convert.ToDateTime(sDate);
                            //if (d < DateTime.Today)
                            //    continue;
                            DataTable dtTemp = BaseFunction.BaseFunction.ReturnDataTableSel(dtHolidays, "dHolidays = '" +  sDate+ "'");

                            DayOfWeek sWeek = d.DayOfWeek;
                            if (sWeek == DayOfWeek.Sunday)
                                gridView日历.SetRowCellValue(i, gridView日历.Columns[j], DBNull.Value);
                            else if (dtTemp != null && dtTemp.Rows.Count > 0)
                            {
                                gridView日历.SetRowCellValue(i, gridView日历.Columns[j], DBNull.Value);
                            }
                            else
                                gridView日历.SetRowCellValue(i, gridView日历.Columns[j], dHours);

                        }
                        catch { }
                    }
                }
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
                gridView日历.FocusedRowHandle -= 1;
                gridView日历.FocusedRowHandle += 1;
            }
            catch { }

            base.dsPrint.Tables.Clear();
            DataTable dtGrid = SetPrintData(((DataTable)gridControl日历.DataSource).Copy());
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
                    gridView日历.ExportToXls(sF.FileName);
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

                gridView日历.OptionsMenu.EnableColumnMenu = true;
                gridView日历.OptionsMenu.EnableFooterMenu = true;
                gridView日历.OptionsMenu.EnableGroupPanelMenu = true;
                //gridView1.OptionsMenu.ShowAddNewSummaryItem = true;
                gridView日历.OptionsMenu.ShowAutoFilterRowItem = true;
                gridView日历.OptionsMenu.ShowDateTimeGroupIntervalItems = true;
                gridView日历.OptionsMenu.ShowGroupSortSummaryItems = true;
                gridView日历.OptionsMenu.ShowGroupSummaryEditorItem = true;
                gridView日历.OptionsCustomization.AllowColumnMoving = true;
            }
            else
            {
                //layoutControl1.HideCustomizationForm();
                layoutControl1.AllowCustomizationMenu = false;
                gridView日历.OptionsMenu.EnableColumnMenu = false;
                gridView日历.OptionsMenu.EnableFooterMenu = false;
                gridView日历.OptionsMenu.EnableGroupPanelMenu = false;
                //gridView1.OptionsMenu.ShowAddNewSummaryItem = false;
                gridView日历.OptionsMenu.ShowAutoFilterRowItem = false;
                gridView日历.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
                gridView日历.OptionsMenu.ShowGroupSortSummaryItems = false;
                gridView日历.OptionsMenu.ShowGroupSummaryEditorItem = false;
                gridView日历.OptionsCustomization.AllowColumnMoving = false;


                if (!Directory.Exists(base.sProPath + "\\layout"))
                    Directory.CreateDirectory(base.sProPath + "\\layout");

                base.toolStripMenuBtn.Items["Layout"].Text = "布局";

                DialogResult d = MessageBox.Show("是否保存?\n是：保存界面样式\n否：恢复默认界面样式,下次加载时将以默认样式打开\n", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
                if (d == DialogResult.Yes)
                {
                    layoutControl1.SaveLayoutToXml(sLayoutHeadPath);
                    gridControl日历.MainView.SaveLayoutToXml(sLayoutGridPath);
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
            AddCol();

            gridControl产线.DataSource = DALGetBaseData.GetProductionLine(" and 1=1");
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {

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
            gridView日历.AddNewRow();
        }
        /// <summary>
        /// 删行
        /// </summary>
        private void btnDelRow()
        {

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
      
        }

      
        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave()
        {
            try
            {
                gridView产线.FocusedRowHandle -= 1;
                gridView产线.FocusedRowHandle += 1;
            }
            catch { }
            try
            {
                gridView日历.FocusedRowHandle -= 1;
                gridView日历.FocusedRowHandle += 1;
            }
            catch { }

            try
            {
                dtBingGrid = (DataTable)gridControl日历.DataSource;
                DataTable dt产线 = (DataTable)gridControl产线.DataSource;

                int iCou = BLL.Save(dt产线, dtBingGrid);

                if (iCou > 0)
                {
                    MessageBox.Show("保存成功");

                    chk全选产线.Checked = false;
                }
                else
                {
                    MessageBox.Show("请选择需要保存的数据");
                }
            }
            catch (Exception ee)
            {
                MsgBox("保存失败", ee.Message);
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

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                label2.Text = "";

                GetLookUp();

                DataTable dt = DALGetBaseData.GetProductionLine(" and 1=1");
                DataColumn dc = new DataColumn();
                dc.ColumnName = "选择";
                dc.DataType = System.Type.GetType("System.Boolean");
                dc.DefaultValue = false;
                dt.Columns.Add(dc);
                gridControl产线.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column != gridColchoose)
            {
                gridView日历.SetRowCellValue(e.RowHandle, gridColchoose, true);
                decimal d = ReturnObjectToDecimal(gridView日历.GetRowCellValue(e.RowHandle, e.Column), 1);
                if (d > 24 || d < 0)
                {
                    MessageBox.Show("工时设置不合理");
                    gridView日历.FocusedRowHandle = e.RowHandle;
                    gridView日历.FocusedColumn = e.Column;
                }
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

        private void GetGrid(string sLineNo)
        {
            if (sLineNo == "")
            {
                throw new Exception("请选择产线");
            }

            int iFocRow = 0;
            if (gridView日历.FocusedRowHandle > 0)
                iFocRow = gridView日历.FocusedRowHandle;

            int iYear = ReturnObjectToInt(lookUpEditYear.EditValue);
            if (iYear == 0)
                iYear = DateTime.Now.Year;
            dtBingGrid = BLL.GetList("iYear = " + iYear.ToString() + " and [LineNo] = '" + sLineNo + "' ");
            DataColumn dc = new DataColumn();
            dc.ColumnName = "choose";
            dc.DataType = System.Type.GetType("System.Boolean");
            dc.DefaultValue = false;
            dtBingGrid.Columns.Add(dc);

            if (dtBingGrid.Rows.Count < 12)
            {
                for (int i = 1; i <= 12; i++)
                {
                    bool bHas = false;

                    for (int j = 0; j < dtBingGrid.Rows.Count; j++)
                    {
                        int iYear2 = ReturnObjectToInt(dtBingGrid.Rows[j]["iYear"]);
                        int iMonth2 = ReturnObjectToInt(dtBingGrid.Rows[j]["iMonth"]);
                        if(iYear2 == iYear && iMonth2 == i)
                        {
                            bHas = true;
                            break;
                        }

                    }
                    if (bHas)
                        continue;

                    DataRow dr = dtBingGrid.NewRow();
                    dr["iYear"] = iYear;
                    dr["iMonth"] = i;
                    dtBingGrid.Rows.Add(dr);
                }
            }
            gridControl日历.DataSource = dtBingGrid;

            gridView日历.FocusedRowHandle = 0;

            chk全选日历.Checked = false;

            dtHolidays = BLL.GetHolidays(lookUpEditYear.EditValue.ToString());
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView日历.RowCount; i++)
            {
                if (!chk全选日历.Checked)
                    gridView日历.SetRowCellValue(i, gridColchoose, false);
                else
                {
                    gridView日历.SetRowCellValue(i, gridColchoose, true);
                }
            }
        }

        private void AddCol()
        {
            for (int i = gridView日历.Columns.Count-1; i >=0 ; i--)
            {
                string sName = gridView日历.Columns[i].Name.Trim();
                if (sName.Length > 8 && sName.Substring(0, 8) == "gridColi" && ReturnObjectToInt(sName.Substring(8)) > 0)
                {
                    gridView日历.Columns.RemoveAt(i);
                }
            }

            for (int i = 1; i <= 31; i++)
            {
                DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColi = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
                gridColi.Caption = i.ToString();
                gridColi.FieldName = "i" + i.ToString();
                gridColi.Name = "gridColi" + i.ToString();
                gridColi.Visible = true;
                gridColi.Width = 35;
                gridColi.VisibleIndex = i + 9;
                gridColi.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                gridView日历.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { gridColi });
            }
        }

        private void GetLookUp()
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "iYear";
            dt.Columns.Add(dc);

            int iYear = DateTime.Now.Year;
            for (int i = 2013; i <= iYear + 1; i++)
            {
                DataRow dr = dt.NewRow();
                dr["iYear"] = i;
                dt.Rows.Add(dr);
            }

            lookUpEditYear.Properties.DataSource = dt;
            lookUpEditYear.EditValue = DateTime.Now.Year.ToString().Trim();

            dt = DALLookup.Get班次设定("");
            lookUpEdit班次.Properties.DataSource = dt;
            if (dt != null && dt.Rows.Count > 0)
            {
                lookUpEdit班次.EditValue = dt.Rows[0]["小时数"];
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                DevExpress.Utils.AppearanceDefault appTomato = new DevExpress.Utils.AppearanceDefault(Color.Tomato);
                DevExpress.Utils.AppearanceDefault appBlack = new DevExpress.Utils.AppearanceDefault(Color.Black);
                DevExpress.Utils.AppearanceDefault appLightYellow = new DevExpress.Utils.AppearanceDefault(Color.LightYellow);
                DevExpress.Utils.AppearanceDefault appLighYellow = new DevExpress.Utils.AppearanceDefault(Color.Yellow);

                string sName = e.Column.Name.ToString().Trim();
                if (sName.Length > 8 && sName.Substring(0, 8) == "gridColi" && ReturnObjectToInt(sName.Substring(8)) > 0)
                {
                    string sYear = gridView日历.GetRowCellValue(e.RowHandle, gridColiYear).ToString().Trim();
                    string sMonth = gridView日历.GetRowCellValue(e.RowHandle, gridColiMonth).ToString().Trim();
                    string sDay = sName.Substring(8);
                    string sDate = sYear + "-" + sMonth + "-" + sDay;

                    try
                    {
                        DateTime d = Convert.ToDateTime(sDate);

                        DayOfWeek sWeek = d.DayOfWeek;
                        if (sWeek == DayOfWeek.Saturday)
                            DevExpress.Utils.AppearanceHelper.Apply(e.Appearance, appLightYellow);
                        else if (sWeek == DayOfWeek.Sunday)
                            DevExpress.Utils.AppearanceHelper.Apply(e.Appearance, appLighYellow);

                        if (dtHolidays != null && dtHolidays.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtHolidays.Rows.Count; i++)
                            {
                                if (ReturnObjectToDatetime(dtHolidays.Rows[i]["dHolidays"]) == d)
                                {
                                    DevExpress.Utils.AppearanceHelper.Apply(e.Appearance, appTomato);
                                }
                            }
                        }
                    }
                    catch
                    {
                        //不合理的日期标记黑色(2月的29号,30号,小月的31号)
                        DevExpress.Utils.AppearanceHelper.Apply(e.Appearance, appBlack);
                    }
                }
            }
            catch (Exception ee)
            { 
            
            }
        }

        DataTable dtHolidays = new DataTable();
        private void lookUpEditYear_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                AddCol();

                if (sLineNo == "")
                    return;

                GetGrid(sLineNo);
            }
            catch (Exception ee)
            {
                MsgBox("加载日历失败", ee.Message);
            }
        }

        private void gridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            SetEditable();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SetEditable();
        }

        /// <summary>
        /// 不能修改日期在当天之前的工作日历
        /// </summary>
        private void SetEditable()
        {
            try
            {
                int i = gridView日历.FocusedRowHandle;
                string sYear = gridView日历.GetRowCellValue(i, gridColiYear).ToString().Trim();
                string sMonth = gridView日历.GetRowCellValue(i, gridColiMonth).ToString().Trim();
                string sDay = gridView日历.FocusedColumn.Name.Substring(8);
                string sDate = sYear + "-" + sMonth + "-" + sDay;

                try
                {
                    if (gridView日历.FocusedColumn == gridColchoose)
                    {
                        int iYearNow = DateTime.Now.Year;
                        int iYear = ReturnObjectToInt(sYear);
                        if (iYear > iYearNow)
                            gridView日历.FocusedColumn.OptionsColumn.AllowEdit = true;
                        else if (iYear < iYearNow)
                            gridView日历.FocusedColumn.OptionsColumn.AllowEdit = false;
                        else
                        {
                            int iMonthNow = DateTime.Now.Month;
                            if (iMonthNow <= ReturnObjectToInt(sMonth))
                            {
                                gridView日历.FocusedColumn.OptionsColumn.AllowEdit = true;
                            }
                            else
                            {
                                gridView日历.FocusedColumn.OptionsColumn.AllowEdit = false;
                            }
                        }
                    }
                    else
                    {
                        DateTime d = Convert.ToDateTime(sDate);
                        if (d < DateTime.Today)
                            gridView日历.FocusedColumn.OptionsColumn.AllowEdit = false;
                        else
                            gridView日历.FocusedColumn.OptionsColumn.AllowEdit = true;
                    }
                }
                catch
                {

                }
            }
            catch { } 
        }

        private void lookUpEdit班次_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                decimal d = BaseFunction.BaseFunction.ReturnDecimal(lookUpEdit班次.EditValue, 1);
                if (d > 0)
                {
                    textEditDayTime.Text = d.ToString().Trim();
                }
                else
                {
                    textEditDayTime.Text = "8";
                }
            }
            catch { }
        }

        private void gridView产线_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                sLineNo = gridView产线.GetRowCellValue(gridView产线.FocusedRowHandle, gridCol_LineNo).ToString().Trim();
                label2.Text = "对应产线：【" + sLineNo + "】" + gridView产线.GetRowCellValue(gridView产线.FocusedRowHandle, gridCol_LineName).ToString().Trim();
                GetGrid(sLineNo);
            }
            catch { }
        }

        private void chk全选产线_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView产线.RowCount; i++)
                {
                    gridView产线.SetRowCellValue(i, gridCol_选择, chk全选产线.Checked);
                }
            }
            catch { }
        }
    }
}
