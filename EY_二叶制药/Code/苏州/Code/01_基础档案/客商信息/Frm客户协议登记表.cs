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
    public partial class Frm客户协议登记表 : 系统服务.FrmBaseInfo
    {
        public Frm客户协议登记表()
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

                SetEnable(false);
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
            lookUpEdit_EnabledChanged(null, null);
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
            int iRow = 0;
       
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
            if (tabControl1.SelectedTab.Text.Trim() == "业务员")
            {
                gridView2.AddNewRow();
            }
            else
            {
                gridView1.AddNewRow();
            }
        }
        /// <summary>
        /// 删行
        /// </summary>
        private void btnDelRow()
        {
            if (tabControl1.SelectedTab.Text.Trim() == "业务员")
            {
                gridView2.DeleteRow(gridView2.FocusedRowHandle);
            }
            else
            {
                gridView1.DeleteRow(gridView1.FocusedRowHandle); 
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {
            if (lookUpEditYear.Text.Trim() == "")
            {
                lookUpEditYear.Focus();
                throw new Exception("请设置年度");
            }
            if (lookUpEdit代理商.Text.Trim() == "")
            {
                lookUpEdit代理商.Focus();
                throw new Exception("请设置代理商");
            }

            SetEnable(true);

            gridView1.FocusedRowHandle = 0;
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
            if (lookUpEditYear.Text.Trim() == "")
            {
                lookUpEditYear.Focus();
                throw new Exception("请设置年度");
            }

            if (lookUpEdit代理商.EditValue == null || lookUpEdit代理商.Text.Trim() == "")
            {
                btnTxtDLS.Focus();
                throw new Exception("请选择代理商");
            }

            aList = new System.Collections.ArrayList();

            Guid sGuid = Guid.NewGuid();

            sSQL = @"
select GUID from 客户协议登记表 where iYear = aaaaaaaa and 代理商 = 'bbbbbbbb'
";
            sSQL = sSQL.Replace("aaaaaaaa", lookUpEditYear.Text.Trim());
            sSQL = sSQL.Replace("bbbbbbbb", lookUpEdit代理商.EditValue.ToString().Trim());
            DataTable dtGuid = clsSQLCommond.ExecQuery(sSQL);
            if (dtGuid != null && dtGuid.Rows.Count > 0 & dtGuid.Rows[0]["GUID"].ToString().Trim() != "")
            {
                sGuid = (Guid)dtGuid.Rows[0]["GUID"];
            }

            sSQL = @"
delete 客户协议登记表 where iYear = aaaaaaaa and 代理商 = 'bbbbbbbb' 
";
            sSQL = sSQL.Replace("aaaaaaaa", lookUpEditYear.Text.Trim());
            sSQL = sSQL.Replace("bbbbbbbb", lookUpEdit代理商.EditValue.ToString().Trim());
            aList.Add(sSQL);


            sSQL = @"
delete 客户协议登记表_业务员 where GUID = 'aaaaaaaaaa'
";
            sSQL = sSQL.Replace("aaaaaaaaaa", sGuid.ToString());
            aList.Add(sSQL);

            int iCou = clsSQLCommond.ExecSqlTran(aList);
            if (iCou == 0)
            {
                throw new Exception("删除失败");
            }
            GetGrid();
            SetEnable(false);
            btnRefresh();
            btnFirst();
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
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                    gridView2.FocusedRowHandle -= 1;
                    gridView2.FocusedRowHandle += 1;
                }
                catch { }
                
                if (lookUpEditYear.Text.Trim() == "")
                {
                    lookUpEditYear.Focus();
                    throw new Exception("请设置年度");
                }

                if (lookUpEdit代理商.EditValue == null || lookUpEdit代理商.Text.Trim() == "")
                {
                    btnTxtDLS.Focus();
                    throw new Exception("请选择代理商");
                }


                string s代理商编码 = lookUpEdit代理商.EditValue.ToString().Trim();
                //DateTime dtm1 = dateEdit1.DateTime;
                //DateTime dtm2 = dateEdit2.DateTime;
                string s返点方式 = lookUpEdit返点方式.Text.Trim();
                if (s返点方式 == "")
                {
                    lookUpEdit返点方式.Focus();
                    throw new Exception("请选择返点方式");
                }

                string sErr = "";

                aList = new System.Collections.ArrayList();
                bool b = false;


                Guid sGuid = Guid.NewGuid();

                sSQL = @"
select GUID from 客户协议登记表 where iYear = aaaaaaaa and 代理商 = 'bbbbbbbb'
";
                sSQL = sSQL.Replace("aaaaaaaa", lookUpEditYear.Text.Trim());
                sSQL = sSQL.Replace("bbbbbbbb", s代理商编码);
                DataTable dtGuid = clsSQLCommond.ExecQuery(sSQL);
                if (dtGuid != null && dtGuid.Rows.Count > 0)
                {
                    if (dtGuid.Rows[0]["GUID"].ToString().Trim() != "")
                    {
                        sGuid = (Guid)dtGuid.Rows[0]["GUID"];
                    }
                }

                sSQL = @"
delete 客户协议登记表 where iYear = aaaaaaaa and 代理商 = 'bbbbbbbb'
";
                sSQL = sSQL.Replace("aaaaaaaa", lookUpEditYear.Text.Trim());
                sSQL = sSQL.Replace("bbbbbbbb", s代理商编码);
                aList.Add(sSQL);

                 
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    Model.客户协议登记表 mod = new 基础设置.Model.客户协议登记表();

                    string s编码 = gridView1.GetRowCellValue(i, gridCol编码).ToString().Trim();
                    if (s编码 == "")
                    {
                        continue;
                    }

                    sSQL = @"
select count(1) 
from U8Inventory 
where cInvCode = 'aaaaaaaa' 
";
                    sSQL = sSQL.Replace("aaaaaaaa", s编码);
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        sErr = sErr + "行 " + (i + 1).ToString() + " 品种不存在\n";
                        continue;
                    }

                    mod.GUID = sGuid;
                    mod.iYear = ReturnInt(lookUpEditYear.Text);
                    mod.代理商 = s代理商编码;

                    if (gridView1.GetRowCellDisplayText(i, gridColdtmStart).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "协议开始日期不能为空\n";
                    }
                    mod.dDate1 = Convert.ToDateTime(gridView1.GetRowCellDisplayText(i, gridColdtmStart));

                    if (gridView1.GetRowCellDisplayText(i, gridColdtmEnd).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "协议结束日期不能为空\n";
                    }
                    mod.dDate2 = Convert.ToDateTime(gridView1.GetRowCellDisplayText(i, gridColdtmEnd));
                    mod.返点方式 = s返点方式;
                    mod.品种 = s编码;
                    //mod.或有条款 = gridView1.GetRowCellDisplayText(i, gridCol或有条款).ToString().Trim();

                    if (gridView1.GetRowCellValue(i, gridCol底价).ToString().Trim() != "")
                    { 
                        mod.底价 =  ReturnDecimal(gridView1.GetRowCellValue(i, gridCol底价), 2);
                    }
                    if (gridView1.GetRowCellValue(i, gridCol协议销量).ToString().Trim() != "")
                    {
                        mod.协议销量 = ReturnDecimal(gridView1.GetRowCellValue(i, gridCol协议销量), 2);
                    }
                    if (gridView1.GetRowCellValue(i, gridCol保证金).ToString().Trim() != "")
                    {
                        mod.保证金= ReturnDecimal(gridView1.GetRowCellValue(i, gridCol保证金), 2);
                    }
                    if (gridView1.GetRowCellValue(i, gridColM1).ToString().Trim() != "")
                    {
                        mod.M1 = ReturnDecimal(gridView1.GetRowCellValue(i, gridColM1), 2);
                    }
                    if (gridView1.GetRowCellValue(i, gridColM2).ToString().Trim() != "")
                    {
                        mod.M2 = ReturnDecimal(gridView1.GetRowCellValue(i, gridColM2), 2);
                    }
                    if (gridView1.GetRowCellValue(i, gridColM3).ToString().Trim() != "")
                    {
                        mod.M3 = ReturnDecimal(gridView1.GetRowCellValue(i, gridColM3), 2);
                    }
                    if (gridView1.GetRowCellValue(i, gridColM4).ToString().Trim() != "")
                    {
                        mod.M4 = ReturnDecimal(gridView1.GetRowCellValue(i, gridColM4), 2);
                    }
                    if (gridView1.GetRowCellValue(i, gridColM5).ToString().Trim() != "")
                    {
                        mod.M5 = ReturnDecimal(gridView1.GetRowCellValue(i, gridColM5), 2);
                    }
                    if (gridView1.GetRowCellValue(i, gridColM6).ToString().Trim() != "")
                    {
                        mod.M6 = ReturnDecimal(gridView1.GetRowCellValue(i, gridColM6), 2);
                    }
                    if (gridView1.GetRowCellValue(i, gridColM7).ToString().Trim() != "")
                    {
                        mod.M7 = ReturnDecimal(gridView1.GetRowCellValue(i, gridColM7), 2);
                    }
                    if (gridView1.GetRowCellValue(i, gridColM8).ToString().Trim() != "")
                    {
                        mod.M8 = ReturnDecimal(gridView1.GetRowCellValue(i, gridColM8), 2);
                    }
                    if (gridView1.GetRowCellValue(i, gridColM9).ToString().Trim() != "")
                    {
                        mod.M9 = ReturnDecimal(gridView1.GetRowCellValue(i, gridColM9), 2);
                    }
                    if (gridView1.GetRowCellValue(i, gridColM10).ToString().Trim() != "")
                    {
                        mod.M10 = ReturnDecimal(gridView1.GetRowCellValue(i, gridColM10), 2);
                    }
                    if (gridView1.GetRowCellValue(i, gridColM11).ToString().Trim() != "")
                    {
                        mod.M11 = ReturnDecimal(gridView1.GetRowCellValue(i, gridColM11), 2);
                    }
                    if (gridView1.GetRowCellValue(i, gridColM12).ToString().Trim() != "")
                    {
                        mod.M12 = ReturnDecimal(gridView1.GetRowCellValue(i, gridColM12), 2);
                    }
                    mod.CreateUid = sUid;
                    mod.CreateDate = DateTime.Now;

                    DAL.客户协议登记表 dal = new 基础设置.DAL.客户协议登记表();
                    sSQL = dal.Add(mod);
                    aList.Add(sSQL);

                    b = true;
                }

                sSQL = @"
delete 客户协议登记表_业务员 where GUID = 'aaaaaaaaaa'
";
                sSQL = sSQL.Replace("aaaaaaaaaa", sGuid.ToString());
                aList.Add(sSQL);

                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    string s业务员 =  gridView2.GetRowCellValue(i, gridCol业务员编码).ToString().Trim();
                    if(s业务员 == "")
                        continue;

                    Model.客户协议登记表_业务员 mod = new 基础设置.Model.客户协议登记表_业务员();
                    mod.cPersonCode = s业务员;
                    mod.Remark = gridView2.GetRowCellValue(i, gridCol备注).ToString().Trim();
                    if (gridView2.GetRowCellValue(i, gridCol开始日期).ToString().Trim() != "")
                    {
                        mod.StartDate = ReturnDateTime(gridView2.GetRowCellValue(i, gridCol开始日期));
                    }
                    if (gridView2.GetRowCellValue(i, gridCol结束日期).ToString().Trim() != "")
                    {
                        mod.ENDDate = ReturnDateTime(gridView2.GetRowCellValue(i, gridCol结束日期));
                    }
                    mod.GUID = sGuid;

                    DAL.客户协议登记表_业务员 dal = new 基础设置.DAL.客户协议登记表_业务员();
                    sSQL = dal.Add(mod);
                    aList.Add(sSQL);
                }


                if (!b)
                {
                    throw new Exception("没有需要保存的数据");
                }

                if (sErr.Trim() != "")
                {
                    throw new Exception(sErr);
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


        private void Frm客户协议登记表_Load(object sender, EventArgs e)
        {
            try
            {
                SetEnable(false);

                SetLookUpEdit();
                GetGrid();

                label8.Text = "";
                label8.Visible = true;
            }
            catch (Exception ee)
            {
                throw new Exception("加载窗体失败\n" + ee.Message);
            }

        }

        private void SetLookUpEdit()
        {
            string sSQL = @"
select cVenCode ,cVenName,cVenAbbName from 代理商 order by cVenCode
";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            lookUpEdit代理商.Properties.DataSource = dt;

            lookUpEdit代理商.Enabled = true;
            lookUpEdit代理商.Properties.ReadOnly = false;

            sSQL = @"
select cCode from 返点方式 order by cCode
";
            dt = clsSQLCommond.ExecQuery(sSQL);
            lookUpEdit返点方式.Properties.DataSource = dt;

            dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "iYear";
            dt.Columns.Add(dc);
            for (int i = 2016; i <= DateTime.Today.Year + 1; i++)
            {
                DataRow dr = dt.NewRow();
                dr["iYear"] = i;
                dt.Rows.Add(dr);
            }
            lookUpEditYear.Properties.DataSource = dt;
            lookUpEditYear.EditValue = DateTime.Today.Year.ToString();

            //dateEdit1.DateTime = Convert.ToDateTime(DateTime.Today.Year.ToString() + "-01-01");
            //dateEdit2.DateTime = Convert.ToDateTime(DateTime.Today.Year.ToString() + "-12-31");

            sSQL = @"
select cPersonCode,cPersonName from U8Person order by cPersonCode
";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEditcPersonCode.DataSource = dt;
            ItemLookUpEditcPersonName.DataSource = dt;
        }




        private void lookUpEdit代理商2_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                btnTxtDLS.Text = lookUpEdit代理商.EditValue.ToString().Trim();

                if (lookUpEdit代理商.EditValue != null && lookUpEdit代理商.Text.Trim() != "")
                {
                    GetGrid();
                }

                btnFirst();
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
            lookUpEdit代理商.EditValue = btnTxtDLS.Text.Trim();

            if (lookUpEdit代理商.EditValue != null && lookUpEdit代理商.Text.Trim() != "")
            {
                GetGrid();
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
                lookUpEdit代理商.EditValue = frm.iID;
            }
            catch (Exception ee)
            {
                MessageBox.Show("操作失败：" + ee.Message);
            }
        }


        private void SetEnable(bool b)
        {
            lookUpEditYear.Enabled = true;
            lookUpEditYear.Properties.ReadOnly = false;

            btnTxtDLS.Enabled = true;
            lookUpEdit代理商.Enabled = true;

            lookUpEdit返点方式.Enabled = b;
            lookUpEdit返点方式.Properties.ReadOnly = !b;

            gridView1.OptionsBehavior.Editable = b;
            gridView2.OptionsBehavior.Editable = b;
        }

        private void lookUpEdit_EnabledChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEdit返点方式.EditValue = DBNull.Value;
                labelGUID.Text = "";

                if (lookUpEditYear.Text.Trim() == "")
                {
                    lookUpEditYear.Focus();
                    return;
                }

                string sYear = lookUpEditYear.EditValue.ToString().Trim();
                string s代理商 = "";
                string s开票客户 = "";
                if (lookUpEdit代理商.EditValue != null)
                {
                    s代理商 = lookUpEdit代理商.EditValue.ToString().Trim();
                }

                string sSQL = @"
select a.iID, iYear, a.代理商, a.dDate1, a.dDate2, a.返点方式, a.底价, a.协议销量, a.保证金,inv.cInvStd as 规格型号,a.品种 as 编码,inv.cInvName as 品种
    ,cast(M1 as decimal(16,2)) as M1,cast(M2 as decimal(16,2)) as M2,cast(M3 as decimal(16,2)) as M3,cast(M4 as decimal(16,2)) as M4,cast(M5 as decimal(16,2)) as M5,cast(M6 as decimal(16,2)) as M6 
    ,cast(M7 as decimal(16,2)) as M7,cast(M8 as decimal(16,2)) as M8,cast(M9 as decimal(16,2)) as M9,cast(M10 as decimal(16,2)) as M10, cast(M11 as decimal(16,2)) as M11,cast(M12 as decimal(16,2)) as M12
    ,a.CreateUid,a.CreateDate, a.AuditUid, a.AuditDate
    ,cast(M1 as decimal(16,2)) + cast(M2 as decimal(16,2)) + cast(M3 as decimal(16,2)) + cast(M4 as decimal(16,2)) + cast(M5 as decimal(16,2)) + cast(M6 as decimal(16,2)) 
    + cast(M7 as decimal(16,2)) + cast(M8 as decimal(16,2)) + cast(M9 as decimal(16,2)) + cast(M10 as decimal(16,2)) + cast(M11 as decimal(16,2)) + cast(M12 as decimal(16,2)) as MSum
    ,a.GUID
from 客户协议登记表 a
    left join U8Inventory inv on a.品种 = inv.cInvCode
where iYear = aaaaaaaa  
    and 代理商 = 'bbbbbbbb' 
order by a.iID
";
                sSQL = sSQL.Replace("aaaaaaaa", sYear);
                sSQL = sSQL.Replace("bbbbbbbb", s代理商);
                sSQL = sSQL.Replace("cccccccc", s开票客户);
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                gridControl1.DataSource = dt;

                if (dt.Rows.Count > 0)
                {
                    lookUpEdit返点方式.EditValue = dt.Rows[0]["返点方式"].ToString().Trim();

                    labelGUID.Text = dt.Rows[0]["GUID"].ToString().Trim();
                }
                while (gridView1.RowCount < 50)
                {
                    gridView1.AddNewRow();
                }
                gridView1.FocusedRowHandle = 0;

                sSQL = @"
select * 
from 客户协议登记表_业务员 
where 1=1
order by iID
";
                if (labelGUID.Text.Trim() == "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and 1=-1");
                }
                else
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and GUID = '" + labelGUID.Text.Trim() + "'");
                }
                dt = clsSQLCommond.ExecQuery(sSQL);
                gridControl2.DataSource = dt;

                while (gridView2.RowCount < 50)
                {
                    gridView2.AddNewRow();
                }
                gridView2.FocusedRowHandle = 0;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == gridColM1 || e.Column == gridColM2 || e.Column == gridColM3 || e.Column == gridColM4 || e.Column == gridColM5 || e.Column == gridColM6 ||
                    e.Column == gridColM7 || e.Column == gridColM8 || e.Column == gridColM9 || e.Column == gridColM10 || e.Column == gridColM11 || e.Column == gridColM12)
                {
                    decimal d1 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColM1), 2);
                    decimal d2 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColM2), 2);
                    decimal d3 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColM3), 2);
                    decimal d4 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColM4), 2);
                    decimal d5 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColM5), 2);
                    decimal d6 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColM6), 2);
                    decimal d7 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColM7), 2);
                    decimal d8 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColM8), 2);
                    decimal d9 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColM9), 2);
                    decimal d10 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColM10), 2);
                    decimal d11 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColM11), 2);
                    decimal d12 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColM12), 2);

                    decimal dSum = d1 + d2 + d3 + d4 + d5 + d6 + d7 + d8 + d9 + d10 + d11 + d12;

                    gridView1.SetRowCellValue(e.RowHandle, gridColMSum, dSum);
                }
            }
            catch (Exception ee)
            { 
            
            }
        }

        private void ItemButtonEditcInvName_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                Frm参照 frm = new Frm参照(1);
                frm.txtSEL.Text = gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, gridCol品种).ToString().Trim();
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridCol编码, frm.iID);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridCol品种, frm.iText);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridCol规格型号, frm.iText2);
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show("操作失败：" + ee.Message);
            }
        }

        private void ItemButtonEditcInvName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                ItemButtonEditcInvName_ButtonClick(null, null);
            }
        }

        private void ItemButtonEditcInvStd_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                Frm参照 frm = new Frm参照(1);
                frm.txtSEL.Text = gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, gridCol规格型号).ToString().Trim();
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridCol编码, frm.iID);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridCol品种, frm.iText);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridCol规格型号, frm.iText2);
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show("操作失败：" + ee.Message);
            }
        }

        private void ItemButtonEditcInvStd_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                ItemButtonEditcInvStd_ButtonClick(null, null);
            }
        }

        private void ItemButtonEditcInvCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                Frm参照 frm = new Frm参照(1);
                frm.txtSEL.Text = gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, gridCol编码).ToString().Trim();
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridCol编码, frm.iID);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridCol品种, frm.iText);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridCol规格型号, frm.iText2);
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show("操作失败：" + ee.Message);
            }
        }

        private void ItemButtonEditcInvCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                ItemButtonEditcInvCode_ButtonClick(null, null);
            }
        }
    }
}
