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
    public partial class FrmInvLineCycle : FrameBaseFunction.FrmFromModel
    {
        TH.Model.InvLineCycle Model = new TH.Model.InvLineCycle();
        TH.BLL.InvLineCycle BLL = new TH.BLL.InvLineCycle();
        TH.DAL.InvLineCycle DAL = new TH.DAL.InvLineCycle();
        TH.DAL.GetBaseData DALGetbasedata = new TH.DAL.GetBaseData();

        public FrmInvLineCycle()
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

            sTableList = "FrmInvLineCycle";

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
                    case "add":
                        btnAdd();
                        break;
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

        private void btnAdd()
        {
            if (lookUpEditcInvCode.EditValue == null || lookUpEditcInvCode.Text.Trim() == "")
                throw new Exception("请选择存货");

            gridView1.AddNewRow();
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

            int iCou = DAL.PLTB();
            if (iCou > 0)
            {
                MessageBox.Show("同步成功");
            }
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
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            DialogResult d = MessageBox.Show("确定删除选定的项么？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (d != DialogResult.Yes)
                throw new Exception("取消删除");

            try
            {
                dtBingGrid = (DataTable)gridControl1.DataSource;

                int iCou = BLL.Del(dtBingGrid);

                if (iCou > 0)
                {
                    MessageBox.Show("删除成功");
                    GetGrid();
                }
                else
                {
                    MessageBox.Show("请选择需要删除的数据");
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
                if (!chkbSelf.Checked)
                {
                    throw new Exception("该物料没有自制属性");
                }

                dtBingGrid = (DataTable)gridControl1.DataSource;
                if (dtBingGrid == null || dtBingGrid.Rows.Count == 0)
                    throw new Exception("没有需要保存的数据");

                int iCouZZ = 0;
                for (int i = 0; i < dtBingGrid.Rows.Count; i++)
                {
                    dtBingGrid.Rows[i]["cInvCode"] = lookUpEditcInvCode.EditValue.ToString().Trim();

                    iCouZZ = iCouZZ + ReturnObjectToInt(gridView1.GetRowCellValue(i, gridColPriority));
                }

                if (chkbSelf.Checked && iCouZZ != 1)
                    throw new Exception("默认产线必须只能有一个");

                int iCou = BLL.Save(dtBingGrid);

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
                GetLookUp();
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
            int iFocRow = 0;
            if (gridView1.FocusedRowHandle > 0)
                iFocRow = gridView1.FocusedRowHandle;

            if (lookUpEditcInvCode.EditValue == null || lookUpEditcInvCode.Text.Trim() == "")
                throw new Exception("请选择存货编码");

            dtBingGrid = BLL.GetList(lookUpEditcInvCode.EditValue.ToString().Trim());
            DataColumn dc = new DataColumn();
            dc.ColumnName = "choose";
            dc.DataType = System.Type.GetType("System.Boolean");
            dc.DefaultValue = false;
            dtBingGrid.Columns.Add(dc);

            if (dtBingGrid != null && dtBingGrid.Rows.Count > 0)
            {

                txtPurchase.Text = dtBingGrid.Rows[0]["PurchaseCycle"].ToString();
                txtProxyForeign.Text = dtBingGrid.Rows[0]["ProxyForeignCycle"].ToString();

            }

            gridControl1.DataSource = dtBingGrid;

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                decimal d默认工时 = ReturnObjectToDecimal(txt默认工时.Text.Trim(), 1);

                decimal d单件工时 = ReturnObjectToDecimal(gridView1.GetRowCellValue(i,gridColSelfCycle),6);
                decimal d基数 = ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridColSelfCycleB), 1);


                int d产量 = ReturnObjectToInt(d默认工时 / (d单件工时 / d基数));
                gridView1.SetRowCellValue(i, gridCol产量, d产量);
            }

            gridView1.FocusedRowHandle = iFocRow;
        }

        private void SetLineNoEnable(int iRow)
        {
            int iID = ReturnObjectToInt(gridView1.GetRowCellValue(iRow, gridColiID));
            if (iID == 0)
            {
                gridColLineNo.OptionsColumn.AllowEdit = true;
            }
            else
            {
                gridColLineNo.OptionsColumn.AllowEdit = false;
            }
        }

        private void lookUpEditcInvCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (lookUpEditcInvCode.EditValue == null)
                    return;

                DataTable dt = BLL.GetInventory(lookUpEditcInvCode.EditValue.ToString().Trim());
                if (dt.Rows.Count > 0)
                {
                    textEditcInvName.Text = dt.Rows[0]["cInvName"].ToString();
                    textEditcInvStd.Text = dt.Rows[0]["cInvStd"].ToString();
                    chkbProxyForeign.Checked = ReturnObjectToBool(dt.Rows[0]["bProxyForeign"]);
                    chkbPurchase.Checked = ReturnObjectToBool(dt.Rows[0]["bPurchase"]);
                    chkbSelf.Checked = ReturnObjectToBool(dt.Rows[0]["bSelf"]);

                    if (chkbProxyForeign.Checked)
                    {
                        txtProxyForeign.Enabled = true;
                    }
                    else
                    {
                        txtProxyForeign.Enabled = false;
                    }

                    if (chkbPurchase.Checked)
                    {
                        txtPurchase.Enabled = true;
                    }
                    else
                    {
                        txtPurchase.Enabled = false;
                    }

                    GetGrid();
                }
            }
            catch (Exception ee)
            {
                MsgBox("提示", ee.Message);
            }
        }

        private void GetLookUp()
        {
            DataTable dt = DALGetbasedata.GetInventory("");
            lookUpEditcInvCode.Properties.DataSource = dt;

            dt = DALGetbasedata.GetProductionLine("");
            ItemLookUpEditLineNo.DataSource = dt;
            ItemLookUpEditLineName.DataSource = dt;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                decimal d单件工时 = ReturnObjectToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColSelfCycle), 6);
                decimal d单件工时基数 = ReturnObjectToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColSelfCycleB), 1);
                decimal d产量 = ReturnObjectToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol产量), 1);
                decimal d工时 = ReturnObjectToDecimal(txt默认工时.Text.Trim(), 1);

                if(d工时<=0)
                {
                    txt默认工时.Focus();
                    throw new Exception("行" + e.RowHandle.ToString() + "需要先设置工时");
                }

                if(d单件工时基数 <= 0)
                {
                    gridView1.SetRowCellValue(e.RowHandle,gridColSelfCycleB,1);
                }

                if (e.Column == gridCol产量)
                { 
                     decimal  d单件工时2 =ReturnObjectToDecimal( 1 / (d产量 / d工时) * d单件工时基数,6);

                     if (d单件工时 != d单件工时2)
                     {
                         gridView1.SetRowCellValue(e.RowHandle, gridColSelfCycle, d单件工时2);
                     }
                }

                //if (e.Column == gridColSelfCycle)
                //{
                //    int d产量2 = ReturnObjectToInt(d工时 / (d单件工时 / d单件工时基数));
                //          if (d产量 != d产量2)
                //     {
                //         gridView1.SetRowCellValue(e.RowHandle, gridCol产量, d产量2);
                //     }
                //}
            }
            catch(Exception ee)
            {
                MsgBox("提示", ee.Message);
            }
        }

    }
}
