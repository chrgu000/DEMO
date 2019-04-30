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
    public partial class Frm基础档案列表 : FrameBaseFunction.FrmFromModel
    {
        TH.Model.工序日报 Model = new TH.Model.工序日报();
        TH.DAL._GetBaseData DALGetBaseData = new TH.DAL._GetBaseData();
        TH.DAL.工序日报 DAL = new TH.DAL.工序日报();

        DataTable dtGridInfo;

        string sTable = "";

        public Frm基础档案列表()
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
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            for (int i = gridView1.RowCount - 1; i >= 0; i--)
            {
                if (BaseFunction.BaseFunction.ReturnBool(gridView1.GetRowCellValue(i,gridView1.Columns["bChoose"])))
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
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            DialogResult d = MessageBox.Show("确定删除选定的项么？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (d != DialogResult.Yes)
                return;

            try
            {
                bool bHasDel = false;
                for (int i = 0; i < gridView1.RowCount; i++)
                { 
                    if(!BaseFunction.BaseFunction.ReturnBool(gridView1.GetRowCellValue(i,gridView1.Columns["bChoose"])))
                        continue;

                    bHasDel = true;
                }

                if (!bHasDel)
                    throw new Exception("请选择需要删除的单据");

                dtBingGrid = (DataTable)gridControl1.DataSource;

                int iCou = DAL.Del(dtBingGrid);

                if (iCou > 0)
                {
                    MessageBox.Show("删除成功");

                    int iFoc = gridView1.FocusedRowHandle;

                    GetGrid();

                    gridView1.FocusedRowHandle = iFoc - iCou;
                }
                else
                {
                    MessageBox.Show("当前数据没有保存，不需要删除");

                }
            }
            catch (Exception ee)
            {
                MsgBox("删除失败", ee.Message);
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
                string sErr = "";

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (!BaseFunction.BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridView1.Columns["bChoose"])))
                        continue;


                    if (gridView1.GetRowCellValue(i, gridView1.Columns["sType"]).ToString().Trim() == "")
                    {
                        gridView1.SetRowCellValue(i, gridView1.Columns["sType"], label1.Text);
                    }

                    for (int j = 0; j < dtGridInfo.Rows.Count; j++)
                    {
                        if (BaseFunction.BaseFunction.ReturnBool(dtGridInfo.Rows[j]["必输"]))
                        {
                            string s = gridView1.GetRowCellValue(i, gridView1.Columns[dtGridInfo.Rows[j]["列名"].ToString().Trim()]).ToString().Trim();
                            if (s == "")
                            {
                                sErr = sErr + "行" + (i + 1).ToString() + " " + dtGridInfo.Rows[j]["列标题"].ToString().Trim() + " 不能为空\n";
                                continue;
                            }
                        }
                    }
                }

                if (sErr != "")
                    throw new Exception(sErr);

                DataTable dt = (DataTable)gridControl1.DataSource;

                int iCou = DAL.Save(dt);
                if (iCou > 0)
                {
                    MessageBox.Show("保存成功");

                    int iFoc = gridView1.FocusedRowHandle;
                    GetGrid();
                    gridView1.FocusedRowHandle = iFoc;
                }
            }
            catch (Exception ee)
            {
                MsgBox("保存失败", ee.Message);
            }

            //try
            //{
            //    dtBingGrid = (DataTable)gridControl1.DataSource;

            //    int iCou = DAL.Save(dtBingGrid);

            //    if (iCou > 0)
            //    {
            
            //            MessageBox.Show("保存成功");
                 
            //        GetGrid();
            //    }
            //    else
            //    {
            //            MessageBox.Show("请选择需要保存的数据");
        
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
                sTable = this.Text;
                label1.Text = sTable;

                GridAddCols();

                GetGrid();
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

        private void GridAddCols()
        {
            string sSQL = "select * from  列表设置 where 表名 = '" + sTable + "' order by 排序";
            dtGridInfo = clsSQLCommond.ExecQuery(sSQL);

            for (int i = 0; i < dtGridInfo.Rows.Count; i++)
            {
                DevExpress.XtraGrid.Columns.GridColumn gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();

                gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {gridColumn1});

                gridColumn1.Caption = dtGridInfo.Rows[i]["列标题"].ToString().Trim();
                gridColumn1.Name = "gridCol" + dtGridInfo.Rows[i]["列名"].ToString().Trim();
                gridColumn1.FieldName = dtGridInfo.Rows[i]["列名"].ToString().Trim();

                if (BaseFunction.BaseFunction.ReturnInt(dtGridInfo.Rows[i]["列锁定"]) == 0)
                {
                    gridColumn1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None;
                }
                if (BaseFunction.BaseFunction.ReturnInt(dtGridInfo.Rows[i]["列锁定"]) == 1)
                {
                    gridColumn1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                }
                if (BaseFunction.BaseFunction.ReturnInt(dtGridInfo.Rows[i]["列锁定"]) == 2)
                {
                    gridColumn1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
                }

                gridColumn1.OptionsColumn.AllowEdit = BaseFunction.BaseFunction.ReturnBool(dtGridInfo.Rows[i]["可编辑"]);
                gridColumn1.VisibleIndex = BaseFunction.BaseFunction.ReturnInt(dtGridInfo.Rows[i]["排序"]);
                gridColumn1.Width = BaseFunction.BaseFunction.ReturnInt(dtGridInfo.Rows[i]["宽度"]);
                gridColumn1.Visible = BaseFunction.BaseFunction.ReturnBool(dtGridInfo.Rows[i]["可见"]);

                #region 设置参照

                if (dtGridInfo.Rows[i]["参照"].ToString().Trim() != "")
                {
                    string sSQL2 = dtGridInfo.Rows[i]["参照"].ToString().Trim();
                    DataTable dt2 = clsSQLCommond.ExecQuery(sSQL2);

                    DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
                    //this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {ItemLookUpEdit1});
                    

                    ItemLookUpEdit1.AutoHeight = false;
                    //ItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});

                    if (dtGridInfo.Rows[i]["参照list2"].ToString().Trim() == "")
                    {
                        ItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo(dtGridInfo.Rows[i]["参照list1"].ToString().Trim(), dtGridInfo.Rows[i]["参照list1Caption"].ToString().Trim()) });
                    }
                    else if(dtGridInfo.Rows[i]["参照list3"].ToString().Trim() == "")
                    {
                        ItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo(dtGridInfo.Rows[i]["参照list1"].ToString().Trim(), dtGridInfo.Rows[i]["参照list1Caption"].ToString().Trim()), new DevExpress.XtraEditors.Controls.LookUpColumnInfo(dtGridInfo.Rows[i]["参照list2"].ToString().Trim(), dtGridInfo.Rows[i]["参照list2Caption"].ToString().Trim()) });
                    }
                    else
                    {
                        ItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo(dtGridInfo.Rows[i]["参照list1"].ToString().Trim(), dtGridInfo.Rows[i]["参照list1Caption"].ToString().Trim()), new DevExpress.XtraEditors.Controls.LookUpColumnInfo(dtGridInfo.Rows[i]["参照list2"].ToString().Trim(), dtGridInfo.Rows[i]["参照list2Caption"].ToString().Trim()), new DevExpress.XtraEditors.Controls.LookUpColumnInfo(dtGridInfo.Rows[i]["参照list3"].ToString().Trim(), dtGridInfo.Rows[i]["参照list3Caption"].ToString().Trim()) });
                    }

                    ItemLookUpEdit1.DisplayMember = dtGridInfo.Rows[i]["参照Text"].ToString().Trim();
                    ItemLookUpEdit1.Name = "ItemLookUpEdit" + dtGridInfo.Rows[i]["列名"].ToString().Trim();
                    ItemLookUpEdit1.ValueMember = dtGridInfo.Rows[i]["参照iID"].ToString().Trim();
                    ItemLookUpEdit1.NullText = "";
                    ItemLookUpEdit1.PopupWidth = 600;

                    ItemLookUpEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                    gridColumn1.ColumnEdit = ItemLookUpEdit1;
                    ItemLookUpEdit1.DataSource = dt2;
                }

                #endregion
            }
        }

        private void GetGrid()
        {
            string sSQL = @"
select cast(0 as bit) as bChoose, * from 工序报表 
where sType = '111111'
order by Date1,iID
";
            sSQL = sSQL.Replace("111111", sTable);
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;
            gridView1.AddNewRow();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column != gridView1.Columns["bChoose"])
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["bChoose"], true);

                    if (gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["sType"]).ToString().Trim() == "")
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["sType"], label1.Text.Trim());
                    }

                    if (gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["Date1"]).ToString().Trim() == "")
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["Date1"], FrameBaseFunction.ClsBaseDataInfo.sLogDate);
                    }
                }

                if (gridView1.RowCount == 1 || e.RowHandle == gridView1.RowCount - 1)
                {
                    int iFocRow = gridView1.RowCount;
                    
                    int iRow = gridView1.FocusedRowHandle;

                    gridView1.AddNewRow();

                    if (iFocRow == 1)
                        gridView1.FocusedRowHandle = 0;
                    else
                        gridView1.FocusedRowHandle = iRow;
                }
            }
            catch { }
        }
    }
}
