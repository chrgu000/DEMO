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


namespace ImportDLL
{
    public partial class Frm生产排产 : FrameBaseFunction.FrmFromModel
    {
        TH.DAL.生产排产 DAL = new TH.DAL.生产排产();
        TH.DAL.GetBaseData DALGetBaseData = new TH.DAL.GetBaseData();

        int iPCDays = 0;
        decimal dDayTime = 0;
        DateTime dMinTime;
        DateTime dMaxTime;

        public Frm生产排产()
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
            gridView1.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.False;
            gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            gridView1.OptionsCustomization.AllowColumnMoving = false;
            //gridView合并.OptionsCustomization.

            #endregion

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
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 11;
            }
            catch { }

            string sErr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                long lID = BaseFunction.BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridCol生产计划序号));

                string s = DAL.CheckQty(lID);
                if (s.Length > 0)
                {
                    sErr = sErr + "行" + (i+1).ToString() + s + "\n";
                }
            }
            if (sErr.Length > 0)
                MsgBox("提示", sErr);
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
                //gridView合并.OptionsMenu.ShowAddNewSummaryItem = true;
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
                //gridView合并.OptionsMenu.ShowAddNewSummaryItem = false;
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
            DataTable dt = (DataTable)gridControl1.DataSource;
            if (dt == null || dt.Rows.Count == 0)
            {
                throw new Exception("没有排产数据");
            }

            string sLineNo = "";
            if(lookUpEdit产线编码.EditValue != null && lookUpEdit产线编码.EditValue.ToString().Trim() != "")
            {
                sLineNo = lookUpEdit产线编码.EditValue.ToString().Trim();
            }

            Frm工时计算 frm = new Frm工时计算(dMinTime, dMaxTime, sLineNo, dt);
            frm.ShowDialog();
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

        }

        /// <summary>
        /// 上页
        /// </summary>
        private void btnPrev()
        {

        }
        /// <summary>
        /// 下页
        /// </summary>
        private void btnNext()
        {

        }

        /// <summary>
        /// 末页
        /// </summary>
        private void btnLast()
        {

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
            //for (int i = gridView评审计算.RowCount - 1; i >= 0 ; i--)
            //{
            //    if (gridView评审计算.IsRowSelected(i))
            //    {
            //        gridView评审计算.DeleteRow(i);
            //    }
            //}
        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {

        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                DataTable dt = (DataTable)gridControl1.DataSource;
                //int iCou = DAL.Del(dtmPlan.DateTime);

                //if (iCou > 0)
                //{
                //    MessageBox.Show("删除成功");
                //    labeliSave.Text = "";
                //    gridControl1.DataSource = null;
                //}
                //else
                //    MessageBox.Show("没有需要删除的数据");

            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
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
                DataTable dt = (DataTable)gridControl1.DataSource;
                int iCou = DAL.Save(dtm排产日期.DateTime, dt);

                if (iCou > 0)
                {
                    MessageBox.Show("保存成功");
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        /// <summary>
        /// 撤销
        /// </summary>
        private void btnUnDo()
        {
            //if (txt销售订单ID.Text.Trim() != "")
            //{
            //    //GetGrid(Convert.ToInt64(txt销售订单ID.Text));
            //}
        }
        /// <summary>
        /// 审核
        /// </summary>
        private void btnAudit()
        {
            //int i = DAL.Audit(dtmPlan.DateTime);
            //if (i > 0)
            //{
            //    MessageBox.Show("审核成功");
            //    labeliSave.Text = "已审核";
            //}
            //else
            //{
            //    MessageBox.Show("请选择需要审核的数据");
            //}
        }
        /// <summary>
        /// 弃审
        /// </summary>
        private void btnUnAudit()
        {
            //int i = DAL.UnAudit(dtmPlan.DateTime);
            //if (i > 0)
            //{
            //    MessageBox.Show("弃审成功");
            //    labeliSave.Text = "已保存";
            //}
            //else
            //{
            //    MessageBox.Show("请选择需要审核的数据");
            //}
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
                if (FrameBaseFunction.ClsBaseDataInfo.sUid == "admin")
                    dtm排产日期.Properties.ReadOnly = false;
                else
                    dtm排产日期.Properties.ReadOnly = true;

                dtm排产日期.DateTime = DALGetBaseData.GetDatetimeSer();

                GetLookup();

                iPCDays = DAL.GetPCDays();
                if (iPCDays == 0)
                    iPCDays = 10;

                dDayTime = DAL.GetDayTime();
                if (dDayTime == 0)
                    dDayTime = 8;

                for (int i = 0; i < iPCDays; i++)
                {
                    AddCol(dtm排产日期.DateTime.AddDays(i + 1));
                }

                labeliSave.Text = "";

            }
            catch (Exception ee)
            {
                MsgBox("加载窗体失败", ee.Message);
            }
        }

        private void GetGrid()
        {
            try
            {
                if (lookUpEdit产线编码.Text.Trim() == "")
                {
                    throw new Exception("请选择产线");
                }

                for (int i = gridView1.Columns.Count - 1; i >= 0; i--)
                {
                    if (gridView1.Columns[i].Name.Length > 11 && gridView1.Columns[i].Name.Substring(0, 11) == "gridColtemp")
                        gridView1.Columns.RemoveAt(i);
                }

                for (int i = gridView1.Bands.Count - 1; i >= 0; i--)
                {
                    if (gridView1.Bands[i].Name.Length > 12 && gridView1.Bands[i].Name.Substring(0, 12) == "gridBandtemp")
                    {
                        gridView1.Bands.RemoveAt(i);
                    }
                }

                for (int i = 0; i < iPCDays; i++)
                {
                    AddCol(dtm排产日期.DateTime.AddDays(i));
                }
                dMinTime = dtm排产日期.DateTime;
                dMaxTime = dtm排产日期.DateTime.AddDays(iPCDays - 1);

                DateTime dPlan = BaseFunction.BaseFunction.ReturnDate(dtm排产日期.DateTime.ToString("yyyy-MM-dd"));
                string sReturn = "";
                string sLineNO = lookUpEdit产线编码.EditValue.ToString().Trim();
                int iPeopleNo = BaseFunction.BaseFunction.ReturnInt(lookUpEditPeopleNO.Text.Trim());
                DataTable dt = DAL.GetPCList(dPlan, iPCDays, dDayTime, out sReturn,sLineNO,iPeopleNo);

                DataColumn dc = new DataColumn();
                dc.ColumnName = "choose";
                dc.DataType = System.Type.GetType("System.Boolean");
                dc.DefaultValue = false;
                dt.Columns.Add(dc);

                gridControl1.DataSource = dt;
                labeliSave.Text = sReturn;           
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
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

        private void AddCol(DateTime dDay)
        {
            DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            gridBand.Caption = dDay.ToString("MM月dd日");
            gridBand.MinWidth = 20;
            gridBand.Name = "gridBandtemp日期" + dDay.ToString("yyMMdd");
            gridBand.Width = 30;
            gridBand.AppearanceHeader.Options.UseTextOptions = true;
            gridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Bands.Add(gridBand);

            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn1.Caption = "数量";
            gridColumn1.Name = "gridColtemp数量" + dDay.ToString("yyMMdd");
            gridColumn1.FieldName = "数量" + dDay.ToString("yyMMdd");
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = gridView1.Columns.Count;
            gridColumn1.ColumnEdit = this.ItemTextEditn0;
            gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn1.Width = 40;
            gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });

            gridBand.Columns.Add(gridColumn1);

            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn2.Caption = "工时";
            gridColumn2.Name = "gridColtemp工时" + dDay.ToString("yyMMdd");
            gridColumn2.FieldName = "工时" + dDay.ToString("yyMMdd");
            gridColumn2.Visible = true;
            gridColumn2.VisibleIndex = gridView1.Columns.Count;
            gridColumn2.OptionsColumn.ReadOnly = true;
            gridColumn2.ColumnEdit = this.ItemTextEditn2;
            gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn2.Width = 40;
            gridColumn2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });

            gridBand.Columns.Add(gridColumn2);


            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn3.Caption = "状态";
            gridColumn3.Name = "gridColtemp状态" + dDay.ToString("yyMMdd");
            gridColumn3.FieldName = "状态" + dDay.ToString("yyMMdd");
            gridColumn3.Visible = true;
            gridColumn3.VisibleIndex = gridView1.Columns.Count;
            gridColumn3.OptionsColumn.ReadOnly = true;
            gridColumn3.ColumnEdit = this.ItemTextEditn0;
            gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn3.Width = 40;
            gridColumn3.Visible = false;
            //gridColumn3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });

            gridBand.Columns.Add(gridColumn3);
        }

        private void btnEdit调整天数_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {

                if (labeliSave.Text.IndexOf("审核") > 0)
                {
                    MsgBox("提示", "已审核不能调整");
                }
                if (labeliSave.Text.IndexOf("历史") > 0)
                {
                    MsgBox("提示", "历史单据不能调整");
                }

                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                DataTable dt = (DataTable)gridControl1.DataSource;
                int iDays = BaseFunction.BaseFunction.ReturnInt(btnEdit调整天数.Text.Trim());
                if (iDays == 0)
                    return;

                string sReturn = "";
                dt = DAL.TZ天数(iDays, dt, dtm排产日期.DateTime, out sReturn);
                gridControl1.DataSource = dt;


                if (sReturn != "")
                {
                    MsgBox("提示", sReturn);
                }

                
            }
            catch (Exception ee)
            {
                MsgBox("调整失败", ee.Message);
            }
        }

        private void labeliSave_TextChanged(object sender, EventArgs e)
        {
            if (labeliSave.Text.IndexOf("审核") >= 0 || labeliSave.Text.IndexOf("历史") >= 0)
            {
                gridView1.OptionsBehavior.Editable = false;
                btnEdit调整天数.Enabled = false;
                btnEdit调整天数.Text = "";
            }
            else
            {
                gridView1.OptionsBehavior.Editable = true;
                btnEdit调整天数.Enabled = true;
                btnEdit调整天数.Text = "";
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                DevExpress.Utils.AppearanceDefault appTomato = new DevExpress.Utils.AppearanceDefault(Color.Tomato);

                if (gridView1.GetRowCellValue(e.RowHandle, gridCol产线编码).ToString().Trim() == "" && e.Column == gridCol产线编码)
                {
                    DevExpress.Utils.AppearanceHelper.Apply(e.Appearance, appTomato);
                }

                if (gridView1.GetRowCellValue(e.RowHandle, gridCol排产说明).ToString().Trim() != "" && e.Column == gridCol排产说明)
                {
                    DevExpress.Utils.AppearanceHelper.Apply(e.Appearance, appTomato);
                }

                DevExpress.Utils.AppearanceDefault appGreen = new DevExpress.Utils.AppearanceDefault(Color.LightGreen);
                DevExpress.Utils.AppearanceDefault appBlue = new DevExpress.Utils.AppearanceDefault(Color.LightBlue);
                if (BaseFunction.BaseFunction.ReturnBool(gridView1.GetRowCellValue(e.RowHandle, gridCol首次排产)) && e.Column == gridCol首次排产)
                {
                    DevExpress.Utils.AppearanceHelper.Apply(e.Appearance, appGreen);
                }
                if (!BaseFunction.BaseFunction.ReturnBool(gridView1.GetRowCellValue(e.RowHandle, gridCol首次排产)) && e.Column == gridCol首次排产)
                {
                    DevExpress.Utils.AppearanceHelper.Apply(e.Appearance, appBlue);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void GetLookup()
        {
            DataTable dt = DALGetBaseData.GetProductionLine("");
            ItemLookUpEdit产线.DataSource = dt;
            ItemLookUpEdit产线编码.DataSource = dt;
            lookUpEdit产线编码.Properties.DataSource = dt;
            lookUpEditPeopleNO.Properties.DataSource = dt;
            lookUpEdit产线.Properties.DataSource = dt;

            dt = DALGetBaseData.GetInventory("");
            ItemLookUpEdit存货编码.DataSource = dt;
            ItemLookUpEdit存货名称.DataSource = dt;
            ItemLookUpEdit规格型号.DataSource = dt;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.Name.Length == 19 && e.Column.Name.Substring(0, 13).ToLower() == "gridColtemp数量".ToLower())
                {
                    decimal d当前页面排产数量 = 0;
                    for (int i = 0; i < gridView1.Columns.Count; i++)
                    { 
                        string sColName =  gridView1.Columns[i].Name.Trim();
                        if (sColName.Length == 19 && sColName.Substring(0, 13).ToLower() == "gridColtemp数量".ToLower())
                        {
                            decimal d数量 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns[i]));
                            decimal d单件工时 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol单件生产工时));
                            decimal d工时 = BaseFunction.BaseFunction.ReturnDecimal(d数量 * d单件工时, 2);
                            gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["工时" + gridView1.Columns[i].Name.Trim().Substring(gridView1.Columns[i].Name.Trim().Length - 6)], d工时);

                            d当前页面排产数量 = d当前页面排产数量 + d数量;
                        }
                    }
                    gridView1.SetRowCellValue(e.RowHandle, gridCol当前页面排产数量, d当前页面排产数量);
                    decimal d计划数量 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol计划数量));
                    decimal d完工数量 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol完工数量));
                    decimal d未排产数量 = d计划数量 - d完工数量 - d当前页面排产数量;
                    gridView1.SetRowCellValue(e.RowHandle, gridCol未排产数量, d未排产数量);

                    gridView1.SetRowCellValue(e.RowHandle, gridCol排产说明, "");
                    if (d未排产数量 < 0)
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridCol排产说明, "排产数量超计划");
                    }
                    if (d未排产数量 > 0)
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridCol排产说明, "计划未排完");
                    }
                }

                if (e.Column == gridCol产线编码)
                { 
                    string sLineNO = gridView1.GetRowCellValue(e.RowHandle,gridCol产线编码).ToString().Trim();
                    string sInvCode =  gridView1.GetRowCellValue(e.RowHandle,gridCol存货编码).ToString().Trim();

                    DataTable dt = DAL.GetLineInvCode(sLineNO, sInvCode);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        decimal d = BaseFunction.BaseFunction.ReturnDecimal(dt.Rows[0]["SelfCycle"]);
                        decimal d2 = BaseFunction.BaseFunction.ReturnInt(dt.Rows[0]["SelfCycleB"]);
                        decimal d3 = BaseFunction.BaseFunction.ReturnDecimal(d / d2, 10);

                        gridView1.SetRowCellValue(e.RowHandle, gridCol单件生产工时, d3);
                        gridView1.SetRowCellValue(e.RowHandle, gridCol产线并发数, BaseFunction.BaseFunction.ReturnDecimal(dt.Rows[0]["PeopleNO"], 1));
                        gridView1.SetRowCellValue(e.RowHandle, gridCol生产准备时间, BaseFunction.BaseFunction.ReturnDecimal(dt.Rows[0]["SelfSetupCycle"], 1));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridCol单件生产工时, null);
                        gridView1.SetRowCellValue(e.RowHandle, gridCol产线并发数, null);
                        gridView1.SetRowCellValue(e.RowHandle, gridCol生产准备时间, null);
                    }
                }
            }
            catch { }
        }

        private void lookUpEdit产线编码_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEditPeopleNO.EditValue = lookUpEdit产线编码.EditValue;
                lookUpEdit产线.EditValue = lookUpEdit产线编码.EditValue;
            }
            catch { }
        }

        private void lookUpEdit产线_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEditPeopleNO.EditValue = lookUpEdit产线.EditValue;
                lookUpEdit产线编码.EditValue = lookUpEdit产线.EditValue;
            }
            catch { }

        }
    }
}
