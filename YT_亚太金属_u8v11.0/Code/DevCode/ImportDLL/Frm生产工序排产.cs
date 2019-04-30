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
    public partial class Frm生产工序排产 : FrameBaseFunction.FrmFromModel
    {
        TH.BLL.生产工序排产 BLL = new TH.BLL.生产工序排产();

        int iPCDays = 0;
        int iDayTime = 0;

        public Frm生产工序排产()
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
            dtmPlan.DateTime = dtm.DateTime;
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
                DataTable dt = (DataTable)gridControl1.DataSource;
                int iCou = BLL.Del(dtmPlan.DateTime);

                if (iCou > 0)
                {
                    MessageBox.Show("删除成功");
                    labeliSave.Text = "";
                    gridControl1.DataSource = null;
                }
                else
                    MessageBox.Show("没有需要删除的数据");

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
                int iCou = BLL.Save(dtmPlan.DateTime,dt);

                if (iCou > 0)
                {
                    MessageBox.Show("保存成功");
                    labeliSave.Text = "已保存";
                }
                else
                    MessageBox.Show("没有需要保存的数据");

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
            int i = BLL.Audit(dtmPlan.DateTime);
            if (i > 0)
            {
                MessageBox.Show("审核成功");
                labeliSave.Text = "已审核";
            }
            else
            {
                MessageBox.Show("请选择需要审核的数据");
            }
        }
        /// <summary>
        /// 弃审
        /// </summary>
        private void btnUnAudit()
        {
            int i = BLL.UnAudit(dtmPlan.DateTime);
            if (i > 0)
            {
                MessageBox.Show("弃审成功");
                labeliSave.Text = "已保存";
            }
            else
            {
                MessageBox.Show("请选择需要审核的数据");
            }
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
                GetLookup();

                dtm.Enabled = true;
                dtm.DateTime = BaseFunction.BaseFunction.ReturnDate(FrameBaseFunction.ClsBaseDataInfo.sLogDate);

                iPCDays = BLL.GetPCDays();
                if (iPCDays == 0)
                    iPCDays = 10;

                iDayTime = BLL.GetDayTime();
                if (iDayTime == 0)
                    iDayTime = 8;

                for (int i = 0; i < iPCDays; i++)
                {
                    AddCol(dtm.DateTime.AddDays(i + 1));
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
                if (dtmPlan.Text.Trim() == "")
                {
                    throw new Exception("请选择排产日期");
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
                    AddCol(dtm.DateTime.AddDays(i));
                }

                DateTime dPlan = BaseFunction.BaseFunction.ReturnDate(dtm.DateTime.ToString("yyyy-MM-dd"));
                string sReturn = "";
                DataTable dt = BLL.GetPCList(dPlan, iPCDays, iDayTime, out sReturn).Tables[0];

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
                throw new Exception("获得数据列表失败:" + ee.Message);
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
            gridBand.Width = 50;
            
            gridView1.Bands.Add(gridBand);

            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn1.Caption = "数量";
            gridColumn1.Name = "gridColtemp数量" + dDay.ToString("yyMMdd");
            gridColumn1.FieldName = "数量" + dDay.ToString("yyMMdd");
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = gridView1.Columns.Count;
            gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });

            gridBand.Columns.Add(gridColumn1);

            //DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            //gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //gridColumn2.Caption = "工时比例";
            //gridColumn2.Name = "gridColtemp工时比例" + dDay.ToString("yyMMdd");
            //gridColumn2.FieldName = "工时比例" + dDay.ToString("yyMMdd");
            //gridColumn2.Visible = false;
            //gridColumn2.Width = 0;
            //gridColumn2.VisibleIndex = gridView1.Columns.Count;
            //gridColumn2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });

            //gridBand.Columns.Add(gridColumn2);

            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn3.Caption = "工时";
            gridColumn3.Name = "gridColtemp工时" + dDay.ToString("yyMMdd");
            gridColumn3.FieldName = "工时" + dDay.ToString("yyMMdd");
            gridColumn3.Visible = true;
            gridColumn3.VisibleIndex = gridView1.Columns.Count;
            gridColumn3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });

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
                dt = BLL.TZ天数(iDays, dt, dtmPlan.DateTime, out sReturn);
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
                int iRow = e.RowHandle;
                if (iRow < 0 || iRow >= gridView1.RowCount)
                    return;
                if (gridView1.GetRowCellDisplayText(e.RowHandle, gridCol排产说明).ToString().Trim() == "含未排产数据")
                    e.Appearance.BackColor = Color.LightYellow;
                if (gridView1.GetRowCellDisplayText(e.RowHandle, gridCol排产说明).ToString().Trim() == "完工延迟")
                    e.Appearance.BackColor = Color.Tomato;
            }
            catch { }
        }

        private void GetLookup()
        {
            DataTable dt = BLL.GetLine();
            ItemLookUpEdit工作中心.DataSource = dt;
            ItemLookUpEdit工作中心编码.DataSource = dt;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int iRow=e.RowHandle;
            if(iRow<0)
            {
                iRow=0;
            }
            if (e.Column.FieldName.Substring(0, 2) == "数量" && e.Column.FieldName.Length == 8)
            {
                string d = e.Column.FieldName.Substring(2, 6);
                decimal 单件加工工时 = ReturnObjectToDecimal(gridView1.GetRowCellValue(iRow, gridCol单件加工工时), 2);
                decimal 剩余排产工时 = 0;
                decimal 总量 = ReturnObjectToDecimal(gridView1.GetRowCellValue(iRow, gridCol当前页面排产数量), 2);
            
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (gridView1.Columns[i].FieldName.Substring(0, 2) == "数量" && gridView1.Columns[i].FieldName.Length == 8)
                    {
                        decimal 数量 = ReturnObjectToDecimal(gridView1.GetRowCellValue(iRow, gridView1.Columns[i].FieldName), 2);
                        decimal 工时=0;
                        if (数量 > 0)
                        {
                            工时 = 单件加工工时 * 数量;
                            总量 = 总量 - 数量;
                            if (总量 < 0)
                            {
                                throw new Exception("排产数量超出");
                            }
                        }
                        if (工时 > 8)
                        {
                            剩余排产工时 = 工时 - 8;
                            工时 = 8;
                        }
                        if (工时 < 8 && 剩余排产工时 > 0)
                        {
                            if (工时 + 剩余排产工时 > 8)
                            {
                                工时 = 8;
                                剩余排产工时 = 剩余排产工时 - (8 - 工时);
                            }
                            else
                            {
                                工时 = 工时 + 剩余排产工时;
                                剩余排产工时 = 0;
                            }
                        }
                        if (工时 == 0)
                        {
                            gridView1.SetRowCellValue(iRow, gridView1.Columns[i].FieldName.Replace("数量", "工时"), null);
                        }
                        else
                        {
                            gridView1.SetRowCellValue(iRow, gridView1.Columns[i].FieldName.Replace("数量", "工时"), 工时);
                        }
                    }
                }
                
            }
        }
    }
}
