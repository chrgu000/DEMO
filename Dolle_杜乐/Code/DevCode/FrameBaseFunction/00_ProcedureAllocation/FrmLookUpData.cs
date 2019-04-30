using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;

namespace FrameBaseFunction
{
    public partial class FrmLookUpData : FrameBaseFunction.Frm列表窗体模板
    {
        public FrmLookUpData()
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


        #region 按钮模板

        /// <summary>
        /// 将表格中Lookup之类的保存ID的数据转换成Text用于打印
        /// </summary>
        /// <param cInvName="dt"></param>
        /// <returns></returns>
        private DataTable SetPrintData(DataTable dt)
        {
            //DataTable dtType = (DataTable)ItemLookUpEditType.DataSource;
            //DataColumn dc = new DataColumn();
            //dc.ColumnName = "StateText";
            //dt.Columns.Add(dc);
            //dc = new DataColumn();
            //dc.ColumnName = "TypeText";
            //dt.Columns.Add(dc);
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    DataRow[] drState = dtState.Select("iID = '" + dt.Rows[i]["State"].ToString().Trim() + "'");
            //    if (drState.Length > 0)
            //    {
            //        dt.Rows[i]["StateText"] = drState[0]["State"];
            //    }

            //    DataRow[] drType = dtType.Select("iID = '" + dt.Rows[i]["Type"].ToString().Trim() + "'");
            //    if (drType.Length > 0)
            //    {
            //        dt.Rows[i]["TypeText"] = drType[0]["Type"];
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
            throw new NotImplementedException();
        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void btnRefresh()
        {
            GetType();
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
            for (int i = gridView1.RowCount - 1; i >= 0; i--)
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
            string sErr = "";
            string sErrInfo = "";
            for (int iRow = gridView1.RowCount - 1; iRow >= 0; iRow--)
            {
                if (gridView1.IsRowSelected(iRow))
                {
                    if (!CheckCanDel(gridView1.GetRowCellValue(iRow, gridColiID).ToString().Trim(), out sErrInfo))
                    {
                        sErr = sErr + "档案:" + gridView1.GetRowCellValue(iRow, gridColiID).ToString().Trim() + "  " + gridView1.GetRowCellValue(iRow, gridColiText).ToString().Trim() + sErrInfo + "\n";
                    }
                }
            }

            if (sErr.Length > 0)
            {
                MsgBox("该数据已经使用不能删除", sErr);
                return;
            }
            DialogResult d = MessageBox.Show("确定删除选中的 " + gridView1.SelectedRowsCount + " 行数据么？\n是：继续\n否：取消", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (d != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            aList = new System.Collections.ArrayList();
            for (int iRow = gridView1.RowCount - 1; iRow >= 0; iRow--)
            {
                if (gridView1.IsRowSelected(iRow))
                {
                    sSQL = "select * from _LookUpDate where 1=-1";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    DataRow dr = dt.NewRow();
                    dr["iID"] = gridView1.GetRowCellValue(iRow, gridColiID).ToString().Trim();
                    dr["iText"] = gridView1.GetRowCellValue(iRow, gridColiText).ToString().Trim();
                    dr["iType"] = lookUpEditType.EditValue;
                    dr["Remark"] = gridView1.GetRowCellValue(iRow, gridColRemark).ToString().Trim();
                    dr["bClose"] = gridView1.GetRowCellValue(iRow, gridColbClose).ToString().Trim();
                    dr["bSystem"] = gridView1.GetRowCellValue(iRow, gridColbSystem).ToString().Trim();
                    dt.Rows.Add(dr);
                    sSQL = clsGetSQL.GetDeleteSQL("_LookUpDate", dt, 0);
                    aList.Add(sSQL);
                }
            }

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("保存成功！\n合计执行语句:" + iCou + "条");
                GetGrid();
            }
        }

        /// <summary>
        /// 判断生产员工是否已经使用
        /// </summary>
        /// <param cInvName="p"></param>
        /// <param cInvName="sErr"></param>
        /// <returns></returns>
        private bool CheckCanDel(string p,out string sErr)
        {
            bool b = true;
            sErr = "";

            return b;
        }
        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave()
        {
            if (lookUpEditType.EditValue == null)
            {
                MessageBox.Show("请选择类型");
                return;
            }

            try 
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }
            sSQL = "select * from _LookUpDate where 1=-1";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            string sErr = "";

            aList = new System.Collections.ArrayList();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() == "")
                {
                    continue;
                }
                if (gridView1.GetRowCellValue(i, gridColiText).ToString().Trim() == "")
                {
                    sErr = sErr + "行" + (i + 1) + "内容不能为空\n";
                    continue;
                }
                if (gridView1.GetRowCellValue(i, gridColbClose).ToString().Trim() == "")
                {
                    sErr = sErr + "行" + (i + 1) + "是否启用不能为空\n";
                    continue;
                }
                if (gridView1.GetRowCellValue(i, gridColbSystem).ToString().Trim() == "")
                {
                    sErr = sErr + "行" + (i + 1) + "是否系统不能为空\n";
                    continue;
                }

                if (gridView1.GetRowCellDisplayText(i, gridColtstamp).ToString().Trim() == "")
                {
                    DataRow dr = dt.NewRow();
                    dr["iID"] = gridView1.GetRowCellValue(i, gridColiID).ToString().Trim();
                    dr["iText"] = gridView1.GetRowCellValue(i, gridColiText).ToString().Trim();
                    dr["iType"] = lookUpEditType.EditValue;
                    dr["Remark"] = gridView1.GetRowCellValue(i, gridColRemark).ToString().Trim();
                    dr["bClose"] = gridView1.GetRowCellValue(i, gridColbClose).ToString().Trim();
                    dr["bSystem"] = gridView1.GetRowCellValue(i, gridColbSystem).ToString().Trim();
                    dt.Rows.Add(dr);
                    sSQL = clsGetSQL.GetInsertSQL( "_LookUpDate", dt, dt.Rows.Count - 1);
                    aList.Add(sSQL);
                }
                if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "edit")
                {
                    DataRow dr = dt.NewRow();
                    dr["iID"] = gridView1.GetRowCellValue(i, gridColiID).ToString().Trim();
                    dr["iText"] = gridView1.GetRowCellValue(i, gridColiText).ToString().Trim();
                    dr["iType"] = lookUpEditType.EditValue;
                    dr["bClose"] = gridView1.GetRowCellValue(i, gridColbClose).ToString().Trim();
                    dr["bSystem"] = gridView1.GetRowCellValue(i, gridColbSystem).ToString().Trim();
                    dr["Remark"] = gridView1.GetRowCellValue(i, gridColRemark).ToString().Trim();
                    dt.Rows.Add(dr);
                    sSQL = clsGetSQL.GetUpdateSQL( "_LookUpDate", dt, dt.Rows.Count - 1);
                    aList.Add(sSQL);
                }
            }

            if (sErr.Trim().Length > 0)
            {
                MsgBox("提示", sErr);
                return;
            }

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("保存成功！\n合计执行语句:" + iCou + "条");
                GetGrid();
            }
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

        private void FrmLookUpData_Load(object sender, EventArgs e)
        {
            try
            {
                GetType();
                GettYesOrNo();
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void GetGrid()
        {
            int iFocRow = gridView1.FocusedRowHandle;
            string sSQL = "select *,cast(null as varchar(10)) as iSave from dbo._LookUpDate where iType = '" + lookUpEditType.EditValue + "' order by iID";
            dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dtBingGrid;

            gridView1.AddNewRow();

            gridView1.FocusedRowHandle = iFocRow;
        }

        /// <summary>
        /// 获得LookUp类型档案
        /// </summary>
        private void GetType()
        {
            sSQL = "select * from dbo._LookUpType order by iID";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            ItemLookUpEditType.DataSource = dt;
            lookUpEditType.Properties.DataSource = dt;
        }

        /// <summary>
        /// 获得类型是/否
        /// </summary>
        private void GettYesOrNo()
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "iID";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "iText";
            dt.Columns.Add(dc);

            DataRow dr = dt.NewRow();
            dr["iID"] = 1;
            dr["iText"] = "是";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["iID"] = 2;
            dr["iText"] = "否";
            dt.Rows.Add(dr);

            ItemLookUpEditYesOrNo.DataSource = dt;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column != gridColiSave && gridView1.GetRowCellDisplayText(e.RowHandle, gridColtstamp).ToString().Trim() != "")
            {
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridColiSave, "edit");
            }
            if (e.Column == gridColiID && e.RowHandle == gridView1.RowCount - 1 && gridView1.GetRowCellDisplayText(e.RowHandle, gridColiID).ToString().Trim() != "")
            {
                int iRow = gridView1.FocusedRowHandle;
                gridView1.AddNewRow();
                gridView1.FocusedRowHandle = iRow;
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

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.GetRowCellDisplayText(e.FocusedRowHandle, gridColtstamp).ToString().Trim() == "")
            {
                gridColiID.OptionsColumn.AllowEdit = true;
            }
            else
            {
                gridColiID.OptionsColumn.AllowEdit = false;
            }
        }

        private void lookUpEditType_EditValueChanged(object sender, EventArgs e)
        {
            GetGrid();
        }
    }
}
