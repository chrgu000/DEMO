using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;

namespace 基础设置
{
    public partial class Frm经销商档案 : 系统服务.FrmBaseInfo
    {
        string tablename = "Dealer";
        string tableid = "dDeaCode";
        public Frm经销商档案()
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
        /// <param name="dt"></param>
        /// <returns></returns>
        private DataTable SetPrintData(DataTable dt)
        {
            //DataTable dtState = (DataTable)ItemLookUpEditcTrade.DataSource;
            //DataTable dtType = (DataTable)ItemLookUpEditcCCCode.DataSource;
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
                throw new Exception(ee.Message);
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
            try
            {
                SetLookUpEdit();
                GetGrid();
            }
            catch (Exception ee)
            {
                throw new Exception("刷新窗体失败\n" + ee.Message);
            }
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
            gridView1.OptionsBehavior.ReadOnly = false;
            gridView1.OptionsBehavior.Editable = true;
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
            DialogResult result = MessageBox.Show("是否删除?", "删除提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                try
                {
                    string sErr = "";

                    aList = new System.Collections.ArrayList();

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (gridView1.IsRowSelected(i))
                        {
                            string sID = gridView1.GetRowCellValue(i, gridColdDeaCode).ToString().Trim();
                            //sSQL = "select count(1) from dbo.Vendor where cVenTrade = '" + sID + "' ";
                            //long iCou = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                            //if (iCou > 0)
                            //{
                            //    sErr = "行" + (i + 1).ToString() + " " + sID + " 已经使用不能删除\n";
                            //    continue;
                            //}

                            sSQL = "delete " + tablename + " where " + tableid + " = '" + sID + "' ";
                            aList.Add(sSQL);
                        }
                    }
                    if (sErr.Trim().Length > 0)
                    {
                        MsgBox("删除失败", sErr);
                    }
                    else
                    {
                        if (aList.Count > 0)
                        {
                            int iCou = clsSQLCommond.ExecSqlTran(aList);
                            MessageBox.Show("删除成功！\n合计执行语句:" + iCou.ToString() + "条");
                            int iFoc = gridView1.FocusedRowHandle;
                            GetGrid();
                            gridView1.FocusedRowHandle = iFoc - 1;
                            sState = "del";
                        }
                    }
                }
                catch (Exception ee)
                {
                    throw new Exception("删除失败！" + ee.Message);
                }
            }
        }


        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave()
        {
            try
            {
                gridView1.FocusedColumn = gridColdDeaCode;
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
                gridView1.Focus();
            }
            catch { }
            sSQL = "select * from Dealer where 1=-1";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            string sErr = "";

            aList = new System.Collections.ArrayList();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                #region 判断
                if (gridView1.GetRowCellDisplayText(i, gridColdDeaCode).ToString().Trim() == ""
                        && gridView1.GetRowCellValue(i, gridColdDeaAbbName).ToString().Trim() == "")
                {
                    continue;
                }
                if (gridView1.GetRowCellDisplayText(i, gridColdDeaCode).ToString().Trim() == "")
                {
                    sErr = sErr + "行" + (i + 1) + gridColdDeaCode.Caption + "不能为空\n";
                    continue;
                }

                if (gridView1.GetRowCellValue(i, gridColdDeaAbbName).ToString().Trim() == "")
                {
                    sErr = sErr + "行" + (i + 1) + gridColdDeaAbbName.Caption + "不能为空\n";
                    continue;
                }
                #endregion

                #region 判断是否重复
                for (int j = 0; j < i; j++)
                {
                    if (gridView1.GetRowCellDisplayText(i, gridColdDeaCode).ToString().Trim() == gridView1.GetRowCellDisplayText(j, gridColdDeaCode).ToString().Trim())
                    {
                        sErr = sErr + "行" + (i + 1) + gridColdDeaCode.Caption + "重复\n";
                        continue;
                    }
                }

                for (int j = 0; j < i; j++)
                {
                    if (gridView1.GetRowCellDisplayText(i, gridColdDeaAbbName).ToString().Trim() == gridView1.GetRowCellDisplayText(j, gridColdDeaAbbName).ToString().Trim())
                    {
                        sErr = sErr + "行" + (i + 1) + gridColdDeaAbbName.Caption + "重复\n";
                        continue;
                    }
                }
                #endregion

                #region 生成table
                DataRow dr = dt.NewRow();
                dr["dDeaCode"] = gridView1.GetRowCellValue(i, gridColdDeaCode).ToString().Trim();
                dr["dDeaName"] = gridView1.GetRowCellValue(i, gridColdDeaName).ToString().Trim();
                dr["dDeaAbbName"] = gridView1.GetRowCellValue(i, gridColdDeaAbbName).ToString().Trim();
                dr["cDCCode"] = gridView1.GetRowCellValue(i, gridCol经销商分类).ToString().Trim();
                dr["dDCCode"] = gridView1.GetRowCellValue(i, gridCol地区编码).ToString().Trim();
                dr["dDeaPerson"] = gridView1.GetRowCellValue(i, gridColdDeaPerson).ToString().Trim();
                dr["dDeaPhone"] = gridView1.GetRowCellValue(i, gridColdDeaPhone).ToString().Trim();
                dr["dDeaAddress"] = gridView1.GetRowCellValue(i, gridColdDeaAddress).ToString().Trim();
                dr["dDeaEmail"] = gridView1.GetRowCellValue(i, gridColdDeaEmail).ToString().Trim();
                if (gridView1.GetRowCellValue(i, gridColdDeaDevDate) != null && gridView1.GetRowCellValue(i, gridColdDeaDevDate).ToString() != "")
                {
                    dr["dDeaDevDate"] = gridView1.GetRowCellValue(i, gridColdDeaDevDate).ToString().Trim();
                }
                else
                {
                    dr["dDeaDevDate"] = DBNull.Value;
                }
                if (gridView1.GetRowCellValue(i, gridColdEndDate) != null && gridView1.GetRowCellValue(i, gridColdEndDate).ToString() != "")
                {
                    dr["dEndDate"] = gridView1.GetRowCellValue(i, gridColdEndDate).ToString().Trim();
                }
                else
                {
                    dr["dEndDate"] = DBNull.Value;
                }
                dr["dDeaRegCode"] = gridView1.GetRowCellValue(i, gridColdDeaRegCode).ToString().Trim();
                dr["dDeaAccount"] = gridView1.GetRowCellValue(i, gridColdDeaAccount).ToString().Trim();
                dr["dDeaBank"] = gridView1.GetRowCellValue(i, gridColdDeaBank).ToString().Trim();
                dr["dDeaLPerson"] = gridView1.GetRowCellValue(i, gridColdDeaLPerson).ToString().Trim();
                dr["dDeaType"] = gridView1.GetRowCellValue(i, gridColdDeaType).ToString().Trim();
                dr["dDeaUnit"] = gridView1.GetRowCellValue(i, gridColdDeaUnit).ToString().Trim();
                dt.Rows.Add(dr);
                #endregion

                if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "update")
                {
                    sSQL = clsGetSQL.GetUpdateSQL(系统服务.ClsBaseDataInfo.sDataBaseName, "Dealer", dt, dt.Rows.Count - 1);
                    aList.Add(sSQL);
                }
                if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "add")
                {
                    sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, "Dealer", dt, dt.Rows.Count - 1);
                    aList.Add(sSQL);
                }
            }

            if (sErr.Trim().Length > 0)
            {
                throw new Exception(sErr);
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

        private void Frm经销商档案_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookUpEdit();
                GetGrid();
            }
            catch (Exception ee)
            {
                throw new Exception("加载窗体失败\n" + ee.Message);
            }
        }

        private void GetGrid()
        {
            int iFocRow = gridView1.FocusedRowHandle;
            string sSQL = "select *, 'edit' as iSave from dbo.Dealer order by dDeaCode";
            dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dtBingGrid;

            gridView1.AddNewRow();

            gridView1.FocusedRowHandle = iFocRow;
            gridView1.OptionsBehavior.ReadOnly = true;
            gridView1.OptionsBehavior.Editable = false;
        }

        /// <summary>
        /// 下拉列表框
        /// </summary>
        private void SetLookUpEdit()
        {
            //地区
            sSQL = "select cDCCode as iID,cDCName as iText from dbo.DistrictClass  order by cDCCode";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEditdDCCode.DataSource = dt;

            //归属类型
            sSQL = "select iID,iText from dbo._LookUpDate where iType = '2' and isnull(bClose,1) = 1 order by iID";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEditdDeaType.DataSource = dt;

            //归属单位
            sSQL = "select iID,iText from dbo._LookUpDate where iType = '3' and isnull(bClose,1) = 1 order by iID";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEditdDeaUnit.DataSource = dt;

            //经销商分类
            sSQL = "select cDCode as iID,cDName as iText from dbo.DealerClass order by cDCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit经销商分类.DataSource = dt;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column != gridColiSave && gridView1.GetRowCellDisplayText(e.RowHandle, gridColiSave).ToString().Trim() == "")
            {
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridColiSave, "add");
            }
            if (e.Column != gridColiSave && gridView1.GetRowCellDisplayText(e.RowHandle, gridColiSave).ToString().Trim() == "edit")
            {
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridColiSave, "update");
            }
            if (e.Column == gridColdDeaName && e.RowHandle == gridView1.RowCount - 1 && gridView1.GetRowCellDisplayText(e.RowHandle, gridColdDeaCode).ToString().Trim() != "")
            {
                int iRow = gridView1.FocusedRowHandle;
                gridView1.AddNewRow();
                gridView1.FocusedRowHandle = iRow;
            }
        }

        private void ItemButtonEdit地区编码_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int iRow = gridView1.FocusedRowHandle;
                系统服务.Frm参照 frm = new 系统服务.Frm参照(4);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    gridView1.SetRowCellValue(iRow, gridCol地区编码, frm.sID);
                    frm.Enabled = true;
                }
            }
            catch { }
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

        private void ItemButtonEdit分销商分类_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int iRow = gridView1.FocusedRowHandle;
                系统服务.Frm参照 frm = new 系统服务.Frm参照(8);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    gridView1.SetRowCellValue(iRow, gridCol经销商分类编码, frm.sID);
                    frm.Enabled = true;
                }
            }
            catch { }
        }

    }
}
