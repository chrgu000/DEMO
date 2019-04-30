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
    public partial class Frm生产订单产品工序 : FrameBaseFunction.FrmFromModel
    {
        TH.Model.生产订单产品工序 Model = new TH.Model.生产订单产品工序();
        TH.DAL.生产订单产品工序 DAL = new TH.DAL.生产订单产品工序();

        long lWorkDetailsID = 0;
        decimal d装箱数 = 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lWorkIDs">生存订单行ID</param>
        /// <param name="dQty">装箱数</param>
        public Frm生产订单产品工序(long lWorkIDs,decimal dQty)
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

            lWorkDetailsID = lWorkIDs;
            d装箱数 = dQty;
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
            GetGrid();
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
            //try
            //{
            //    gridView1.FocusedRowHandle -= 1;
            //    gridView1.FocusedRowHandle += 1;
            //}
            //catch { }

            //DialogResult d = MessageBox.Show("确定删除选定的项么？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            //if (d != DialogResult.Yes)
            //    throw new Exception("取消删除");

            //try
            //{
            //    dtBingGrid = (DataTable)gridControl1.DataSource;

    
            //    int iCou = DAL.Del(dtBingGrid);

            //    if (iCou > 0)
            //    {
             
            //            MessageBox.Show("删除成功");
                 
            //        GetGrid();
            //    }
            //    else
            //    {
            
            //            MessageBox.Show("请选择需要删除的数据");
             
            //    }
            //}
            //catch (Exception ee)
            //{
            //    MsgBox("删除失败", ee.Message);
            //}
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

                decimal d装箱数 = ReturnObjectToDecimal(txt装箱数.Text.Trim(), 0);
                if (d装箱数 <= 0)
                {
                    throw new Exception("装箱数必须大于0");
                }

                dtBingGrid = ((DataTable)gridControl1.DataSource).Copy();

                bool b入库 = false;
                for (int i = dtBingGrid.Rows.Count - 1; i >= 0; i--)
                {
                    if (!ReturnObjectToBool(dtBingGrid.Rows[i]["bChoose"]))
                        dtBingGrid.Rows.RemoveAt(i);
                    else
                    {
                        dtBingGrid.Rows[i]["WorkDetailsID"] = txt生产订单IDs.Text.Trim();
                        dtBingGrid.Rows[i]["WorkCode"] = txt生产订单号.Text.Trim();

                        if (ReturnObjectToLong(dtBingGrid.Rows[i]["分包数"]) == 0)
                        {
                            dtBingGrid.Rows[i]["分包数"] = DBNull.Value;
                        }

                        if (ReturnObjectToBool(dtBingGrid.Rows[i]["入库"]))
                        {
                            b入库 = true;

                            if (i != dtBingGrid.Rows.Count - 1)
                            {
                                throw new Exception("入库工序必须是最后一道");
                            }
                        }

                        decimal d_装箱数 = ReturnObjectToDecimal(txt装箱数.Text.Trim(), 0);
                        decimal d分包数 = 0;
                        if(ReturnObjectToBool(dtBingGrid.Rows[i]["分包"]))
                        {
                            d分包数 = ReturnObjectToDecimal(dtBingGrid.Rows[i]["分包数"], 0);
                        }
                        if (d分包数 > d_装箱数)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + " 分包数不能大于装箱数\n";
                            continue;
                        }
                    }
                }

                if (!b入库)
                {
                    throw new Exception("请选中入库工序");
                }

                if (dtBingGrid.Rows.Count == 0)
                {
                    throw new Exception("未选中工序");
                }

                if (sErr.Length > 0)
                {
                    throw new Exception(sErr);
                }

                int iCou = DAL.Save(dtBingGrid, d装箱数);

                if (iCou > 0)
                {
                    MessageBox.Show("保存成功");

                    GetGrid();
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
                GetGrid();

                this.StartPosition = FormStartPosition.CenterScreen;
                this.WindowState = FormWindowState.Normal;
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

        private void GetGrid()
        {
            DataSet ds = DAL.GetList(lWorkDetailsID);

            DataTable dtDetails = ds.Tables["Details"];
            if (dtDetails == null || dtDetails.Rows.Count == 0)
            {
                throw new Exception("获得工序列表失败");
            }
            gridControl1.DataSource = dtDetails;
            
            DataTable dtMain = ds.Tables["Main"];
            if (dtMain == null || dtMain.Rows.Count == 0)
            {
                throw new Exception("获得生产订单信息失败");
            }
            //decimal d装箱数 = ReturnObjectToDecimal(dtMain.Rows[0]["cDefine26"],0);
            //if(d装箱数<=0)
            //{
            //    throw new Exception("装箱数必须大于0");
            //}

            txt生产订单号.Text = dtMain.Rows[0]["cCode"].ToString().Trim();
            txt生产订单IDs.Text = dtMain.Rows[0]["MainId"].ToString().Trim();
            txt数量.Text = dtMain.Rows[0]["fQuantity"].ToString().Trim();
            txt装箱数.Text = dtMain.Rows[0]["cDefine26"].ToString().Trim();
            txt产品编码.Text = dtMain.Rows[0]["cInvCode"].ToString().Trim();
            txt产品名称.Text = dtMain.Rows[0]["cInvName"].ToString().Trim();
            txt规格型号.Text = dtMain.Rows[0]["cInvStd"].ToString().Trim();

        }


        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridColbChoose, chkAll.Checked);
                }
            }
            catch { }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                bool b = ReturnObjectToBool(gridView1.GetRowCellValue(e.RowHandle, gridCol入库));
                if (!b)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (e.Column != gridCol入库)
                            continue;

                        if (i == e.RowHandle)
                            continue;

                        gridView1.SetRowCellValue(i, gridCol入库, false);
                    }
                }

                b = ReturnObjectToBool(gridView1.GetRowCellValue(e.RowHandle, gridCol分包));
                if (!b)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (e.Column != gridCol分包)
                            continue;

                        if (i == e.RowHandle)
                            continue;

                        gridView1.SetRowCellValue(i, gridCol分包, false);
                        gridView1.SetRowCellValue(i, gridCol分包数, DBNull.Value);
                    }
                }

                decimal d分包数 = ReturnObjectToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol分包数), 0);
                if (d分包数 > 0)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (e.Column != gridCol分包数)
                            continue;

                        if (i == e.RowHandle)
                            continue;

                        gridView1.SetRowCellValue(i, gridCol分包, false);
                        gridView1.SetRowCellValue(i, gridCol分包数, DBNull.Value);
                    }
                }
            }
            catch { }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column != gridColbChoose)
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridColbChoose, true);
                }

                if (e.Column == gridCol分包)
                {
                    bool b = ReturnObjectToBool(gridView1.GetRowCellValue(e.RowHandle, gridCol分包));
                    if (!b)
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridCol分包数, DBNull.Value);
                    }
                }
            }
            catch { }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (ReturnObjectToBool(gridView1.GetRowCellValue(e.FocusedRowHandle, gridCol分包)))
                {
                    gridCol分包数.OptionsColumn.AllowEdit = true;
                }
                else
                {
                    gridCol分包数.OptionsColumn.AllowEdit = false;
                }
            }
            catch { }
        }

        private void gridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            try
            {
                if (gridView1.FocusedColumn == gridCol分包数)
                {
                    bool b = ReturnObjectToBool(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridCol分包));
                    if (b)
                    {
                        gridCol分包数.OptionsColumn.AllowEdit = true;
                    }
                    else
                    {
                        gridCol分包数.OptionsColumn.AllowEdit = false;
                    }
                }
            }
            catch { }
        }
    }
}
