using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;

namespace 工程
{
    public partial class Frm符合率报表 : 系统服务.FrmBaseInfo
    {
        public string iCode1 = "";
        public string iCode2 = "";
        public string dDate1 = "";
        public string dDate2 = "";
        public string cInvCode1 = "";
        public string cInvCode2 = "";

        public Frm符合率报表()
        {
            InitializeComponent();

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
            try
            {
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("刷新窗体失败\n" + ee.Message);
            }
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
            try
            {
                GetGrid();
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
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave()
        {
            throw new NotImplementedException();
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

        private void Frm符合率报表_Load(object sender, EventArgs e)
        {
            try
            {
                GetGridViewSet(gridView1);
                GetLayOut(layoutControl1, gridControl1);
                SetLookUpEdit();
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void SetLookUpEdit()
        {
            lookUp.DistrictClass(lookUpEdit工程地区);
            lookUp.Person(lookUpEdit监察人);
            lookUp.LoopUpData(lookUpEdit工程类型, "2");
            lookUp.Engineering(lookUpEdit工程性质);

            lookUp.DistrictClass(ItemLookUpEdit工程地区);
            lookUp.Person(ItemLookUpEdit登记人);
            lookUp.Quality(ItemLookUpEdit质量类型);
            lookUp.LoopUpData(ItemLookUpEdit工程类型, "2");
            lookUp.Department(ItemLookUpEdit部门);
            lookUp.Engineering(ItemLookUpEdit工程性质);
        }

        private void GetGrid()
        {
            DateTime dDate1 = dateEdit工程开始日期.DateTime;
            DateTime dDate2 = dateEdit工程结束日期.DateTime;
            DateTime dDate3 = dateEdit监察开始日期.DateTime;
            DateTime dDate4 = dateEdit监察结束日期.DateTime;
            string cPCCode = "";
            if (lookUpEdit工程类型.EditValue != null)
            {
                cPCCode = lookUpEdit工程类型.EditValue.ToString().Trim();
            }
            string cDCCode = "";
            if(lookUpEdit工程地区.EditValue!=null)
            {
                cDCCode=lookUpEdit工程地区.EditValue.ToString().Trim();
            }
            string PersonCode = "";
            if(lookUpEdit监察人.EditValue!=null)
            {
                PersonCode=lookUpEdit监察人.EditValue.ToString().Trim();
            }
            string cECode = "";
            if (lookUpEdit工程性质.EditValue != null)
            {
                cECode = lookUpEdit工程性质.EditValue.ToString().Trim();
            }
            DataTable dt = clsWeb.dtReportCheck(dDate1, dDate2, dDate3, dDate4, cPCCode, cDCCode, PersonCode, cECode);
            gridControl1.DataSource = dt;
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
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int iRow = gridView1.FocusedRowHandle;
                if (iRow < 0)
                    return;

                string sID = gridView1.GetRowCellValue(iRow, gridCol序号).ToString().Trim();
                if (sID == "")
                    return;

                Frm工程登记 frm = new Frm工程登记(sID);
                frm.Tag = frm.Name;
                frm.MdiParent = this.MdiParent;

                frm.Show();
                if (DialogResult.OK == frm.ShowDialog())
                {
                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            { }
        }

        private void ItemCheckEdit选择_CheckedChanged(object sender, EventArgs e)
        {
            int iRow = gridView1.FocusedRowHandle;
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            //string sCode = gridView1.GetRowCellValue(iRow, gridCol是否符合).ToString().Trim();
            //for (int i = 0; i < gridView1.RowCount; i++)
            //{
            //    if (i == iRow)
            //        continue;
            //    string sCode2 = gridView1.GetRowCellValue(i, gridCol是否符合).ToString().Trim();
            //    if (sCode == sCode2)
            //    {
            //        gridView1.SetRowCellValue(i, gridCol选择, Convert.ToBoolean(gridView1.GetRowCellValue(iRow, gridCol选择)));
            //    }
            //}
        }

        private void buttonEdit工程地区_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                string s = buttonEdit工程地区.Text.Trim();
                系统服务.Frm参照 frm = new 系统服务.Frm参照(7, s);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    buttonEdit工程地区.EditValue = frm.sID;
                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit工程地区_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit工程地区.Text.Trim() != "")
                {
                    lookUpEdit工程地区.EditValue = buttonEdit工程地区.Text.Trim();
                }
                else
                {
                    lookUpEdit工程地区.EditValue = null;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit工程地区_Leave(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit工程地区.Text.Trim() == "")
                    return;
                if (lookUpEdit工程地区.Text.Trim() == "")
                {
                    buttonEdit工程地区.Text = "";
                    buttonEdit工程地区.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit监察人_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                string s = buttonEdit监察人.Text.Trim();
                系统服务.Frm参照 frm = new 系统服务.Frm参照(2, s);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    buttonEdit监察人.EditValue = frm.sID;
                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit监察人_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit监察人.Text.Trim() != "")
                {
                    lookUpEdit监察人.EditValue = buttonEdit监察人.Text.Trim();
                }
                else
                {
                    lookUpEdit监察人.EditValue = null;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit监察人_Leave(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit监察人.Text.Trim() == "")
                    return;
                if (lookUpEdit监察人.Text.Trim() == "")
                {
                    buttonEdit监察人.Text = "";
                    buttonEdit监察人.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }


        private void buttonEdit工程类型_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                string s = buttonEdit工程类型.Text.Trim();
                系统服务.Frm参照 frm = new 系统服务.Frm参照(8, s);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    buttonEdit工程类型.EditValue = frm.sID;
                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit工程类型_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit工程类型.Text.Trim() != "")
                {
                    lookUpEdit工程类型.EditValue = buttonEdit工程类型.Text.Trim();
                }
                else
                {
                    lookUpEdit工程类型.EditValue = null;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit工程类型_Leave(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit工程类型.Text.Trim() == "")
                    return;
                if (lookUpEdit工程类型.Text.Trim() == "")
                {
                    buttonEdit工程类型.Text = "";
                    buttonEdit工程类型.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit工程性质_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                string s = buttonEdit工程性质.Text.Trim();
                系统服务.Frm参照 frm = new 系统服务.Frm参照(6, s);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    buttonEdit工程性质.EditValue = frm.sID;
                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit工程性质_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit工程性质.Text.Trim() != "")
                {
                    lookUpEdit工程性质.EditValue = buttonEdit工程性质.Text.Trim();
                }
                else
                {
                    lookUpEdit工程性质.EditValue = null;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit工程性质_Leave(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit工程性质.Text.Trim() == "")
                    return;
                if (lookUpEdit工程性质.Text.Trim() == "")
                {
                    buttonEdit工程性质.Text = "";
                    buttonEdit工程性质.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}