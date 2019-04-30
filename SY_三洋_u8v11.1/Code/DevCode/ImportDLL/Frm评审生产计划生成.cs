﻿using System;
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
    public partial class Frm评审生产计划生成 : FrameBaseFunction.FrmFromModel
    {
        TH.DAL.生产计划 DAL = new TH.DAL.生产计划();
        TH.DAL.GetBaseData DALBaseData = new TH.DAL.GetBaseData();

        public Frm评审生产计划生成()
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
            SetLookUp();
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
            lookUpEdit评审单据号1.EditValue = DBNull.Value;
            lookUpEdit评审单据号2.EditValue = DBNull.Value;
            lookUpEdit销售订单号1.EditValue = DBNull.Value;
            lookUpEdit销售订单号2.EditValue = DBNull.Value;
            dtm单据日期1.Text = "";
            dtm单据日期2.Text = "";
            dtm制单计划日期1.Text = "";
            dtm制单计划日期2.Text = "";
            txt存货.Text = "";
            txt制单人.Text = "";
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
            if (!radio未审核.Checked)
                return;

            int iRow = 0;
            if (gridView1.FocusedRowHandle > 0)
                iRow = gridView1.FocusedRowHandle;
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            DataTable dt = (DataTable)gridControl1.DataSource;

            DataTable dt2 = BaseFunction.BaseFunction.ReturnDataRowToTable(dt.Rows[iRow]);

            Frm计划分拆 f = new Frm计划分拆(dt2, dt);
            f.ShowDialog();

            gridControl1.DataSource = f.dt分拆计划.Copy();
            
        }
        /// <summary>
        /// 删行
        /// </summary>
        private void btnDelRow()
        {

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
                if (radio已审核.Checked)
                {
                    throw new Exception("单据已制单");
                }
                dtBingGrid = (DataTable)gridControl1.DataSource;

                int iCou = DAL.Save(dtBingGrid, "评审");

                if (iCou > 0)
                {
                    MessageBox.Show("保存成功");
                    GetGrid();
                }
                else
                {
                    throw new Exception("请选择需要保存的数据");
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
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            try
            {
                if (radio未审核.Checked)
                {
                    throw new Exception("单据未制单");
                }

                dtBingGrid = (DataTable)gridControl1.DataSource;

                int iCou = DAL.UnSave(dtBingGrid);

                if (iCou > 0)
                {
                    MessageBox.Show("撤销成功");
                    GetGrid();
                }
                else
                {
                    throw new Exception("请选择需要保存的数据");
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }
        /// <summary>
        /// 审核
        /// </summary>
        private void btnAudit()
        {

        }
        /// <summary>
        /// 弃审
        /// </summary>
        private void btnUnAudit()
        {

        }
        /// <summary>
        /// 打开
        /// </summary>
        private void btnOpen()
        {
            if (!radio已关闭.Checked)
                throw new Exception("单据未关闭");

            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            try
            {
                dtBingGrid = (DataTable)gridControl1.DataSource;

                int iCou = DAL.Open(dtBingGrid);

                if (iCou > 0)
                {
                    MessageBox.Show("打开成功");
                    GetGrid();
                }
                else
                {
                    throw new Exception("请选择需要打开的数据");
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        /// <summary>
        /// 关闭
        /// </summary>
        private void btnClose()
        {
            if (radio已关闭.Checked)
                throw new Exception("单据已关闭");

            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            try
            {
                if (radio未审核.Checked)
                {
                    throw new Exception("尚未审核不能关闭");
                }

                dtBingGrid = (DataTable)gridControl1.DataSource;

                int iCou = DAL.Close(dtBingGrid);

                if (iCou > 0)
                {
                    MessageBox.Show("关闭成功");
                    GetGrid();
                }
                else
                {
                    throw new Exception("请选择需要关闭的数据");
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
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
                SetLookUp();

                dtmPlan.Enabled = true;
                dtmPlan.DateTime = DateTime.Today;
                dtmPlan.Properties.ReadOnly = false;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败" + ee.Message);
            }
        }

        private void SetEnable(bool b)
        {
            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                if (gridView1.Columns[i].FieldName.Trim() == "选择")
                {
                    gridView1.Columns[i].OptionsColumn.AllowEdit = true;
                }
                else
                {
                    gridView1.Columns[i].OptionsColumn.AllowEdit = b;  
                }
            }

            gridCol产线.OptionsColumn.AllowEdit = false;
            gridCol存货规格.OptionsColumn.AllowEdit = false;
            gridCol存货名称.OptionsColumn.AllowEdit = false;
            gridCol单据类型.OptionsColumn.AllowEdit = false;
            gridCol关闭人.OptionsColumn.AllowEdit = false;
            gridCol关闭日期.OptionsColumn.AllowEdit = false;
            gridCol来源GUID.OptionsColumn.AllowEdit = false;
            gridCol评审单据号.OptionsColumn.AllowEdit = false;
            gridCol审核人.OptionsColumn.AllowEdit = false;
            gridCol审核日期.OptionsColumn.AllowEdit = false;
            gridCol生产部门.OptionsColumn.AllowEdit = false;
            gridCol销售订单行号.OptionsColumn.AllowEdit = false;
            gridCol销售订单号.OptionsColumn.AllowEdit = false;
            gridCol制单人.OptionsColumn.AllowEdit = false;
            gridCol制单日期.OptionsColumn.AllowEdit = false;
        }

        private void GetGrid()
        {
            chk全选.Checked = false;

            if (radio未审核.Checked)
            {
                SetEnable(true);

                List<string> sWhere = new List<string>();
                if (lookUpEdit评审单据号1.Text.Trim() != "")
                {
                    string s = "1=1 and a.评审单据号 >= '" + lookUpEdit评审单据号1.Text.Trim() + "'";
                    sWhere.Add("1=1●" + s);
                }
                if (lookUpEdit评审单据号2.Text.Trim() != "")
                {
                    string s = "1=1 and a.评审单据号 <= '" + lookUpEdit评审单据号2.Text.Trim() + "'";
                    sWhere.Add("1=1●" + s);
                }
                if (lookUpEdit销售订单号1.Text.Trim() != "")
                {
                    string s = "1=1 and b.销售订单号 >= '" + lookUpEdit销售订单号1.Text.Trim() + "'";
                    sWhere.Add("1=1●" + s);
                }
                if (lookUpEdit销售订单号2.Text.Trim() != "")
                {
                    string s = "1=1 and b.销售订单号 <= '" + lookUpEdit销售订单号2.Text.Trim() + "'";
                    sWhere.Add("1=1●" + s);
                }
                if (dtm单据日期1.Text.Trim() != "")
                {
                    string s = "1=1 and a.单据日期 >= '" + dtm单据日期1.DateTime.ToString("yyyy-MM-dd") + "'";
                    sWhere.Add("1=1●" + s);
                }
                if (dtm单据日期2.Text.Trim() != "")
                {
                    string s = "1=1 and a.单据日期 < '" + dtm单据日期2.DateTime.AddDays(1).ToString("yyyy-MM-dd") + "'";
                    sWhere.Add("1=1●" + s);
                }
                if (txt存货.Text.Trim() != "")
                {
                    string s = "1=1 and b.子件编码 like '%" + txt存货.Text.Trim() + "%'";
                    sWhere.Add("1=1●" + s);
                }
                if (!chk包含数量0.Checked)
                {
                    string s = "1=1 and isnull(b.本单需求数量,0) <> 0";
                    sWhere.Add("1=1●" + s);
                }
                if (lookUpEdit客户.Text.Trim() != "")
                {
                    string s = "1=1 and isnull(d.cCusCode,'') = '" + lookUpEdit客户.Text.Trim() + "'";
                    sWhere.Add("1=1●" + s);
                }
                if (dtmPlan.Text.Trim() != "")
                {
                    string s = "1=1 and  b.开始日期 >= '" + dtmPlan.DateTime.ToString("yyyy-MM-dd") + "'";
                    sWhere.Add("1=1●" + s);
                }

                DataTable dt = DAL.GetListUn(sWhere);

                gridControl1.DataSource = dt;
            }
            if (radio已审核.Checked || radio已排产.Checked || radio已关闭.Checked)
            {
                SetEnable(false);

                List<string> sWhere = new List<string>();
                if (lookUpEdit评审单据号1.Text.Trim() != "")
                {
                    string s = "1=1 and a.评审单据号 >= '" + lookUpEdit评审单据号1.Text.Trim() + "'";
                    sWhere.Add("1=1●" + s);
                }
                if (lookUpEdit评审单据号2.Text.Trim() != "")
                {
                    string s = "1=1 and a.评审单据号 <= '" + lookUpEdit评审单据号2.Text.Trim() + "'";
                    sWhere.Add("1=1●" + s);
                }
                if (lookUpEdit销售订单号1.Text.Trim() != "")
                {
                    string s = "1=1 and a.销售订单号 >= '" + lookUpEdit销售订单号1.Text.Trim() + "'";
                    sWhere.Add("1=1●" + s);
                }
                if (lookUpEdit销售订单号2.Text.Trim() != "")
                {
                    string s = "1=1 and a.销售订单号 <= '" + lookUpEdit销售订单号2.Text.Trim() + "'";
                    sWhere.Add("1=1●" + s);
                }
                if (dtm单据日期1.Text.Trim() != "")
                {
                    string s = "1=1 and a.制单日期 >= '" + dtm单据日期1.DateTime.ToString("yyyy-MM-dd") + "'";
                    sWhere.Add("1=1●" + s);
                }
                if (dtm单据日期2.Text.Trim() != "")
                {
                    string s = "1=1 and a.制单日期 < '" + dtm单据日期2.DateTime.AddDays(1).ToString("yyyy-MM-dd") + "'";
                    sWhere.Add("1=1●" + s);
                }
                if (txt存货.Text.Trim() != "")
                {
                    string s = "1=1 and a.存货编码 like '%" + txt存货.Text.Trim() + "%'";
                    sWhere.Add("1=1●" + s);
                }
                if (txt制单人.Text.Trim() != "" && radio已审核.Checked)
                {
                    string s = "1=1 and a.制单人 like '%" + txt制单人.Text.Trim() + "%'";
                    sWhere.Add("1=1●" + s);
                }
                if (dtm制单计划日期1.Text.Trim() != "")
                {
                    string s = "1=1 and a.制单日期 >= '" + dtm制单计划日期1.DateTime.ToString("yyyy-MM-dd") + "'";
                    sWhere.Add("1=1●" + s);
                }
                if (dtm制单计划日期2.Text.Trim() != "")
                {
                    string s = "1=1 and a.制单日期 < '" + dtm制单计划日期2.DateTime.AddDays(1).ToString("yyyy-MM-dd") + "'";
                    sWhere.Add("1=1●" + s);
                }
                if (!chk包含数量0.Checked)
                {
                    string s = "1=1 and isnull(a.数量,0) <> 0";
                    sWhere.Add("1=1●" + s);
                }
                if (radio已审核.Checked)
                {
                    string s = "1=1 and isnull(a.关闭人,'') = ''  and a.GUID not in (select 来源GUID from 生产日计划) ";
                    sWhere.Add("1=1●" + s);
                }
                if (radio已排产.Checked)
                {
                    string s = "1=1 and isnull(a.关闭人,'') = '' and a.GUID in (select 来源GUID from 生产日计划) ";
                    sWhere.Add("1=1●" + s);
                }
                if (radio已关闭.Checked)
                {
                    string s = "1=1 and isnull(a.关闭人,'') <> '' ";
                    sWhere.Add("1=1●" + s);
                }
                if (lookUpEdit客户.Text.Trim() != "")
                {
                    string s = "1=1 and isnull(d.cCusCode,'') = '" + lookUpEdit客户.Text.Trim() + "'";
                    sWhere.Add("1=1●" + s);
                }
                if (dtmPlan.Text.Trim() != "")
                {
                    string s = "1=1 and a.计划开工日期 >= '" + dtmPlan.DateTime.ToString("yyyy-MM-dd") + "'";
                    sWhere.Add("1=1●" + s);
                }

                string s1 = "1=1 and a.单据类型 = '评审'";
                sWhere.Add("1=1●" + s1);
                DataTable dt = DAL.GetListed(sWhere);
                gridControl1.DataSource = dt;
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

        private void chk全选_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridCol选择, chk全选.Checked);
                }
            }
            catch (Exception ee)
            { }
        }

        private void SetLookUp()
        {
            DataTable dt = DALBaseData.GetDepartment(" and isnull(bDepEnd ,0) = 1 and cDepCode like '08%'");
            ItemLookUpEdit部门编码.DataSource = dt;
            ItemLookUpEdit部门.DataSource = dt;

            dt = DALBaseData.GetInventory("");
            ItemLookUpEdit存货编码.DataSource = dt;
            ItemLookUpEdit存货名称.DataSource = dt;
            ItemLookUpEdit规格型号.DataSource = dt;

            dt = DALBaseData.GetProductionLine("");
            ItemLookUpEdit产线编码.DataSource = dt;
            ItemLookUpEdit产线.DataSource = dt;

            dt = DALBaseData.GetSoCode("");
            lookUpEdit销售订单号1.Properties.DataSource = dt;
            lookUpEdit销售订单号2.Properties.DataSource = dt;

            dt = DALBaseData.GetPSCode("");
            lookUpEdit评审单据号1.Properties.DataSource = dt;
            lookUpEdit评审单据号2.Properties.DataSource = dt;
        }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                GetGrid();
            }
            catch (Exception ee)
            {
                MsgBox("加载数据失败", ee.Message);
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView1.FocusedRowHandle > 0)
                {
                    iRow = gridView1.FocusedRowHandle;
                }

                if (e.Column != gridCol选择)
                {
                    gridView1.SetRowCellValue(iRow, gridCol选择, true);
                }

                if (e.Column == gridCol产线编码)
                { 
                    string sLineNO = gridView1.GetRowCellValue(iRow,gridCol产线编码).ToString().Trim();
                    string sInvCode = gridView1.GetRowCellValue(iRow,gridCol存货编码).ToString().Trim();
                    DataTable dt = DAL.GetProLine(sLineNO, sInvCode);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        decimal d单件生产工时 = BaseFunction.BaseFunction.ReturnDecimal(BaseFunction.BaseFunction.ReturnDecimal(dt.Rows[0]["SelfCycle"]) / BaseFunction.BaseFunction.ReturnDecimal(dt.Rows[0]["SelfCycleB"]), 10);
                        gridView1.SetRowCellValue(iRow, gridCol单件生产工时, d单件生产工时);
                        gridView1.SetRowCellValue(iRow, gridCol产线并发数, BaseFunction.BaseFunction.ReturnBoolToInt(dt.Rows[0]["SelfCapacity"],1));
                        gridView1.SetRowCellValue(iRow, gridCol生产准备时间, BaseFunction.BaseFunction.ReturnDecimal(dt.Rows[0]["SelfSetupCycle"], 1, 0));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(iRow, gridCol单件生产工时, DBNull.Value);
                        gridView1.SetRowCellValue(iRow, gridCol产线并发数, DBNull.Value);
                        gridView1.SetRowCellValue(iRow, gridCol生产准备时间, DBNull.Value);

                        throw new Exception("行" + (iRow + 1).ToString().Trim() + "请定义存货产线档案");
                    }
                }
            }
            catch(Exception ee) 
            {
                MsgBox("提示", ee.Message);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                btnAddRow();
            }
            catch { }
        }

        private void chk计划开工日期批改_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dtm计划开工日期批改.Enabled = chk计划开工日期批改.Checked;
                DateTime dtmNow = DALBaseData.GetDatetimeSer("yyy-MM-dd");

                if (dtm计划开工日期批改.DateTime < dtmNow)
                    dtm计划开工日期批改.DateTime = dtmNow;

            }
            catch (Exception ee)
            {
                MsgBox("提示", ee.Message);
            }
        }

        private void chk计划完工日期批改_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dtm计划完工日期批改.Enabled = chk计划完工日期批改.Checked;
                DateTime dtmNow = DALBaseData.GetDatetimeSer("yyy-MM-dd");

                if (dtm计划完工日期批改.DateTime < dtmNow)
                    dtm计划完工日期批改.DateTime = dtmNow;
            }
            catch (Exception ee)
            {
                MsgBox("提示", ee.Message);
            }
        }

        private void btn批改_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    bool b = BaseFunction.BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridCol选择));
                    if (!b)
                        continue;

                    if (chk计划开工日期批改.Checked)
                    {
                        gridView1.SetRowCellValue(i, gridCol计划开工日期, dtm计划开工日期批改.DateTime);
                    }

                    if (chk计划完工日期批改.Checked)
                    {
                        gridView1.SetRowCellValue(i, gridCol计划完工日期, dtm计划完工日期批改.DateTime);
                    }
                }
            }
            catch (Exception ee)
            {
                MsgBox("提示", ee.Message);
            }
        }

        private void lookUpEdit客户_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEdit客户编码.EditValue = lookUpEdit客户.EditValue;
            }
            catch { }
        }

        private void lookUpEdit客户编码_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEdit客户.EditValue = lookUpEdit客户编码.EditValue;
            }
            catch { }
        }
    }
}
