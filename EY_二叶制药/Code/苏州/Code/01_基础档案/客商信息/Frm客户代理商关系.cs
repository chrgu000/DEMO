using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 基础设置
{
    public partial class Frm客户代理商关系 : 系统服务.FrmBaseInfo
    {
        public Frm客户代理商关系()
        {
            InitializeComponent();
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
        }
        /// <summary>
        /// 输出
        /// </summary>
        private void btnExport()
        {
            //try
            //{
            //    SaveFileDialog sF = new SaveFileDialog();
            //    sF.DefaultExt = "xls";
            //    sF.FileName = this.Text;
            //    sF.Filter = "Excel文件(*.xls)|*.xls|所有文件(*.*)|*.*";
            //    DialogResult dRes = sF.ShowDialog();
            //    if (DialogResult.OK == dRes)
            //    {
            //        gridView1.ExportToXls(sF.FileName);
            //        MessageBox.Show("导出Excel成功\n\t路径：" + sF.FileName);
            //    }
            //}
            //catch (Exception ee)
            //{
            //    throw new Exception(ee.Message);
            //}
        }

        private void btnLayout(string sText)
        {
            //if (layoutControl1 == null) return;
            //if (sText == "布局")
            //{
            //    //layoutControl1.ShowCustomizationForm();
            //    layoutControl1.AllowCustomizationMenu = true;
            //    base.toolStripMenuBtn.Items["Layout"].Text = "保存布局";

            //    gridView1.OptionsMenu.EnableColumnMenu = true;
            //    gridView1.OptionsMenu.EnableFooterMenu = true;
            //    gridView1.OptionsMenu.EnableGroupPanelMenu = true;
            //    //gridView1.OptionsMenu.ShowAddNewSummaryItem = true;
            //    gridView1.OptionsMenu.ShowAutoFilterRowItem = true;
            //    gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = true;
            //    gridView1.OptionsMenu.ShowGroupSortSummaryItems = true;
            //    gridView1.OptionsMenu.ShowGroupSummaryEditorItem = true;
            //    gridView1.OptionsCustomization.AllowColumnMoving = true;
            //}
            //else
            //{
            //    //layoutControl1.HideCustomizationForm();
            //    layoutControl1.AllowCustomizationMenu = false;
            //    gridView1.OptionsMenu.EnableColumnMenu = false;
            //    gridView1.OptionsMenu.EnableFooterMenu = false;
            //    gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            //    //gridView1.OptionsMenu.ShowAddNewSummaryItem = false;
            //    gridView1.OptionsMenu.ShowAutoFilterRowItem = false;
            //    gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            //    gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            //    gridView1.OptionsMenu.ShowGroupSummaryEditorItem = false;
            //    gridView1.OptionsCustomization.AllowColumnMoving = false;


            //    if (!Directory.Exists(base.sProPath + "\\layout"))
            //        Directory.CreateDirectory(base.sProPath + "\\layout");

            //    base.toolStripMenuBtn.Items["Layout"].Text = "布局";

            //    DialogResult d = MessageBox.Show("是否保存?\n是：保存界面样式\n否：恢复默认界面样式,下次加载时将以默认样式打开\n", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
            //    if (d == DialogResult.Yes)
            //    {
            //        layoutControl1.SaveLayoutToXml(sLayoutHeadPath);
            //        gridControl1.MainView.SaveLayoutToXml(sLayoutGridPath);
            //    }
            //    else if (d == DialogResult.No)
            //    {
            //        if (File.Exists(sLayoutHeadPath))
            //            File.Delete(sLayoutHeadPath);

            //        if (File.Exists(sLayoutGridPath))
            //            File.Delete(sLayoutGridPath);
            //    }
            //}
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

        private void GetGrid()
        {
            string s代理商 = "";
            if (lookUpEdit代理商2.EditValue != null && lookUpEdit代理商2.EditValue.ToString().Trim() != "")
            {
                s代理商 = lookUpEdit代理商2.EditValue.ToString().Trim();
            }
            if (s代理商 == "")
            {
                return;
            }

            string sSQL = @"
select b.cVenCode as cCusCode,b.cVenName as cCusName,b.cVenAbbName as cCusAbbName
from 代理商_保证金客户 a inner join [dbo].[U8Vendor] b on a.保证金客户编码 = b.cVenCode
where [代理商编码] = 'aaaaaa'
order by b.cVenCode
";
            sSQL = sSQL.Replace("aaaaaa", s代理商);

            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            gridControl保证金客户.DataSource = dt;

            gridView保证金客户.OptionsBehavior.Editable = true;

            while (gridView保证金客户.RowCount < 100)
            {
                gridView保证金客户.AddNewRow();
            }
            gridView保证金客户.FocusedRowHandle = 0;


            sSQL = @"
select b.cCusCode,b.cCusName,b.cCusAbbName
from 代理商_客户 a inner join [U8Customer] b on a.[客户编码] = b.cCusCode
where [代理商编码] = 'aaaaaa'
order by b.cCusCode
";
            sSQL = sSQL.Replace("aaaaaa", s代理商);
            dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl开票客户.DataSource = dt;
            gridView开票客户.OptionsBehavior.Editable = true;



            while (gridView开票客户.RowCount < 100)
            {
                gridView开票客户.AddNewRow();
            }
            gridView开票客户.FocusedRowHandle = 0;


            gridView保证金客户.OptionsBehavior.Editable = false;
            gridView开票客户.OptionsBehavior.Editable = false;
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
            int iRow保证金客户 = gridView保证金客户.FocusedRowHandle;
            int iRow开票客户 = gridView开票客户.FocusedRowHandle;
            for (int i = 0; i < 10; i++)
            {
                if (xtraTabControl1.TabPages[0].Focus())
                {
                    gridView开票客户.AddNewRow();
                }
                if (xtraTabControl1.TabPages[1].Focus())
                {
                    gridView保证金客户.AddNewRow();
                }
            }

            gridView保证金客户.FocusedRowHandle = iRow保证金客户;
            gridView开票客户.FocusedRowHandle = iRow开票客户;
        }
        /// <summary>
        /// 删行
        /// </summary>
        private void btnDelRow()
        {
            if (xtraTabControl1.TabPages[0].Focus())
            {
                gridView开票客户.DeleteRow(gridView开票客户.FocusedRowHandle);
            }
            if (xtraTabControl1.TabPages[1].Focus())
            {
                gridView保证金客户.DeleteRow(gridView保证金客户.FocusedRowHandle);
            }

        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {
            gridView保证金客户.OptionsBehavior.Editable = true;
            gridView开票客户.OptionsBehavior.Editable = true;
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
            if (lookUpEdit代理商2.EditValue == null || lookUpEdit代理商2.Text.Trim() == "")
            {
                throw new Exception("请选择代理商");
            }
            int iCou = 0;
            string sSQL = "";
            string s代理商 = lookUpEdit代理商2.EditValue.ToString().Trim();

            if (xtraTabControl1.TabPages[1].Focus())
            {
                string s保证金客户 = gridView保证金客户.GetRowCellValue(gridView保证金客户.FocusedRowHandle, gridCol保证金客户编码).ToString().Trim();

                sSQL = "delete [dbo].[代理商_保证金客户] where 代理商编码 = '" + s代理商 + "' and 保证金客户编码 = '" + s保证金客户 + "'";
                iCou = clsSQLCommond.ExecSql(sSQL);
            }
            if (xtraTabControl1.TabPages[0].Focus())
            {
                string s开票客户 = gridView开票客户.GetRowCellValue(gridView开票客户.FocusedRowHandle, gridCol开票客户编码).ToString().Trim();

                sSQL = "delete [dbo].[代理商_客户] where 代理商编码 = '" + s代理商 + "' and 客户编码 = '" + s开票客户 + "'";
                iCou = clsSQLCommond.ExecSql(sSQL);
            }

            if (iCou == 0)
            {
                throw new Exception("删除失败");
            }
            btnRefresh();
        }


        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave()
        {
            try
            {
                try
                {
                    gridView保证金客户.FocusedRowHandle -= 1;
                    gridView保证金客户.FocusedRowHandle += 1;
                }
                catch { }

                if (lookUpEdit代理商2.EditValue == null || lookUpEdit代理商2.Text.Trim() == "")
                {
                    btnTxtDLS.Focus();
                    throw new Exception("请选择代理商");
                }

                string s代理商编码 = lookUpEdit代理商2.EditValue.ToString().Trim();

                string sErr = "";

                for (int i = 0; i < gridView开票客户.RowCount; i++)
                {
                    string s1 = gridView开票客户.GetRowCellValue(i, gridCol开票客户编码).ToString().Trim();
                    if(s1 == "")
                        continue;

                    for (int j = i + 1; j < gridView开票客户.RowCount; j++)
                    {
                        string s2 = gridView开票客户.GetRowCellValue(j, gridCol开票客户编码).ToString().Trim();

                        if (s1 == s2)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + " 与行 " + (j + 1).ToString() + " 重复\n";
                        }
                    }
                }



                for (int i = 0; i < gridView保证金客户.RowCount; i++)
                {
                    string s1 = gridView保证金客户.GetRowCellValue(i, gridCol保证金客户编码).ToString().Trim();
                    if (s1 == "")
                        continue;

                    for (int j = i + 1; j < gridView保证金客户.RowCount; j++)
                    {
                        string s2 = gridView保证金客户.GetRowCellValue(j, gridCol保证金客户编码).ToString().Trim();

                        if (s1 == s2)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + " 与行 " + (j + 1).ToString() + " 重复\n";
                        }
                    }
                }

                if (sErr.Trim().Length > 0)
                {
                    throw new Exception(sErr);
                }

                aList = new System.Collections.ArrayList();

                string sSQL = "delete 代理商_保证金客户 where 代理商编码 = 'aaaaaa'";
                sSQL = sSQL.Replace("aaaaaa", s代理商编码);
                aList.Add(sSQL);
                for (int i = 0; i < gridView保证金客户.RowCount; i++)
                {
                    string s保证金客户 = gridView保证金客户.GetRowCellValue(i, gridCol保证金客户编码).ToString().Trim();
                    if (s保证金客户 == "")
                    {
                        continue;
                    }

                    sSQL = @"
insert into 代理商_保证金客户([保证金客户编码],[代理商编码])
values('bbbbbb','aaaaaa')
";
                    sSQL = sSQL.Replace("aaaaaa", s代理商编码);
                    sSQL = sSQL.Replace("bbbbbb",s保证金客户);
                    aList.Add(sSQL);
                }

                sSQL = "delete 代理商_客户 where 代理商编码 = 'aaaaaa'";
                sSQL = sSQL.Replace("aaaaaa", s代理商编码);
                aList.Add(sSQL);
                for (int i = 0; i < gridView开票客户.RowCount; i++)
                {
                    string s开票客户 = gridView开票客户.GetRowCellValue(i, gridCol开票客户编码).ToString().Trim();
                    if(s开票客户 == "")
                    {
                        continue;
                    }                        
                    
                    sSQL = @"
insert into 代理商_客户([客户编码],[代理商编码])
values('bbbbbb','aaaaaa')
";
                    sSQL = sSQL.Replace("aaaaaa", s代理商编码);
                    sSQL = sSQL.Replace("bbbbbb", s开票客户);
                    aList.Add(sSQL);
                }

                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("保存成功");

                    btnRefresh();
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
            GetGrid();
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


        private void Frm客户代理商关系_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookUpEdit();
                GetGrid();

                gridView保证金客户.OptionsBehavior.Editable = false;
                gridView开票客户.OptionsBehavior.Editable = false;

            }
            catch (Exception ee)
            {
                throw new Exception("加载窗体失败\n" + ee.Message);
            }

        }

        private void SetLookUpEdit()
        {
            string sSQL = @"
select cVenCode ,cVenName from 代理商 order by cVenCode
";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            lookUpEdit代理商2.Properties.DataSource = dt;

            lookUpEdit代理商2.Enabled = true;
            lookUpEdit代理商2.Properties.ReadOnly = false;

            sSQL = @"
select cCusCode,cCusName,cCusAbbName from [dbo].[U8Customer] order by cCusCode
";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEditcCusAbbName.DataSource = dt;
            ItemLookUpEditcCusName.DataSource = dt;


            sSQL = @"
select cVenCode,cVenName,cVenAbbName from [dbo].[U8Vendor] order by cVenCode
";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit保证金客户名称.DataSource = dt;
            ItemLookUpEdit保证金客户简称.DataSource = dt;
        }

       


        private void lookUpEdit代理商2_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                btnTxtDLS.Text = lookUpEdit代理商2.EditValue.ToString().Trim();

                btnRefresh();
            }
            catch { }
        }

        private void gridView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

     

        private void btnTxtDLS_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F2)
                {
                    btnTxtDLS_ButtonClick(null, null);
                }
                if (e.KeyCode == Keys.Enter)
                {
                    btnTxtDLS_Leave(null, null);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("操作失败：" + ee.Message);
            }
        }

        private void btnTxtDLS_Leave(object sender, EventArgs e)
        {
            lookUpEdit代理商2.EditValue = btnTxtDLS.Text.Trim();

            if (lookUpEdit代理商2.EditValue != null && lookUpEdit代理商2.Text.Trim() != "")
            {
                btnRefresh();
            }
        }

        private void btnTxtDLS_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                Frm参照 frm = new Frm参照(3);
                frm.txtSEL.Text = btnTxtDLS.Text.Trim();
                frm.ShowDialog();

                btnTxtDLS.Text = frm.iID;
                lookUpEdit代理商2.EditValue = frm.iID;
            }
            catch (Exception ee)
            {
                MessageBox.Show("操作失败：" + ee.Message);
            }
        }

        private void ItemButtonEditcCusCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                Frm参照 frm = new Frm参照(4);
                frm.txtSEL.Text = gridView开票客户.GetRowCellDisplayText(gridView开票客户.FocusedRowHandle, gridCol开票客户编码).ToString().Trim();
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    gridView开票客户.SetRowCellValue(gridView开票客户.FocusedRowHandle, gridCol开票客户编码, frm.iID);
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show("操作失败：" + ee.Message);
            }
        }

        private void ItemButtonEdit保证金客户_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                Frm参照 frm = new Frm参照(5);
                frm.txtSEL.Text = gridView保证金客户.GetRowCellDisplayText(gridView保证金客户.FocusedRowHandle, gridCol保证金客户编码).ToString().Trim();
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    gridView保证金客户.SetRowCellValue(gridView保证金客户.FocusedRowHandle, gridCol保证金客户编码, frm.iID);
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show("操作失败：" + ee.Message);
            }
        }

        private void ItemButtonEditcCusCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                ItemButtonEditcCusCode_ButtonClick(null, null);
            }
        }

        private void ItemButtonEdit保证金客户_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                ItemButtonEdit保证金客户_ButtonClick(null, null);
            }
        }

    }
}
