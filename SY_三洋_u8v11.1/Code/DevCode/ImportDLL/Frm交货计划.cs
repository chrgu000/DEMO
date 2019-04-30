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
using System.Collections;

namespace ImportDLL
{
    public partial class Frm交货计划 : FrameBaseFunction.FrmFromModel
    {
        TH.DAL.交货计划 DAL = new TH.DAL.交货计划();
        bool bLog = false;

        public Frm交货计划()
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

        private void btnAdd()
        {

        }


        #endregion

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

        private string sFrmSEL = "";

        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
            GetGrid();
        }

        private void GetGrid()
        {
            if (bLog)
                return;

            List<string> sWhere = new List<string>();
            if (lookUpEditYearMonth.EditValue != null && lookUpEditYearMonth.EditValue.ToString() != "")
            {
                DateTime d = BaseFunction.BaseFunction.ReturnDate(lookUpEditYearMonth.EditValue.ToString() + "-01");
                string s = "1=1 and b.dPreDate >= '" + d.ToString("yyyy-MM-dd") + "' and b.dPreDate < '" + d.AddMonths(1).ToString("yyyy-MM-dd") + "'";
                sWhere.Add("1=1●" + s);
            }
            if (radio未审核.Checked)
            {
                string s = "1=1 and isnull(a.cVerifier ,'') = '' and isnull(a.cCloser ,'') = ''";
                sWhere.Add("1=1●" + s);
            }
            if (radio已审核未排产.Checked)
            {
                string s = "1=1 and isnull(a.cVerifier ,'') <> '' and isnull(a.cCloser ,'') = '' and isnull(e.cbdefine1 ,0) = 0";
                sWhere.Add("1=1●" + s);
            }
            if (radio已排产.Checked)
            {
                string s = "1=1 and isnull(a.cVerifier ,'') <> '' and isnull(a.cCloser ,'') = '' and isnull(e.cbdefine1 ,0) = 1 and isnull(f.关闭人,'') = ''";
                sWhere.Add("1=1●" + s);
            }
            if (radio不排产.Checked)
            {
                string s = "1=1 and isnull(a.cVerifier ,'') <> '' and isnull(a.cCloser ,'') = '' and isnull(e.cbdefine1 ,0) = 2";
                sWhere.Add("1=1●" + s);
            }
            if (radio已关闭.Checked)
            {
                string s = "1=1  and (isnull(a.cCloser ,'') <> '' or isnull(b.cSCloser,'') <> '' or isnull(f.关闭人,'') <>  '')";
                sWhere.Add("1=1●" + s);
            }
            if (radio期初.Checked)
            {
                string s = "1=1 and isnull(a.cVerifier ,'') <> '' and isnull(a.cCloser ,'') = '' and isnull(e.cbdefine1 ,0) = 3";
                sWhere.Add("1=1●" + s);
            }
            if (!chk包含备库订单.Checked)
            {
                string s = "1=1 and isnull(a.cSTCode ,'') <> '04' ";
                sWhere.Add("1=1●" + s);
            }
            if (radioCMU.Checked)
            {
                string s = "1=1 and( isnull(d.cInvCCode  ,'') = '0107' or isnull(d.cInvCCode  ,'') = '0108' or isnull(d.cInvCCode  ,'') = '010103' or isnull(d.cInvCCode  ,'') = '0109') ";
                sWhere.Add("1=1●" + s);
            }
            if (lookUpEdit产品大类.Text.Trim() != "")
            {
                string s = "1=1 and  isnull(d.cInvDefine4  ,'') = '" + lookUpEdit产品大类.Text.Trim() + "'";
                sWhere.Add("1=1●" + s);
            }


            DataTable dt = DAL.GetSoList(sWhere);
            gridControl1.DataSource = dt;

            chkAll.Checked = false;
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

        }
        /// <summary>
        /// 解锁
        /// </summary>
        private void btnUnLock()
        {

        }
        /// <summary>
        /// 增行
        /// </summary>
        private void btnAddRow()
        {

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
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }
            if (!radio已审核未排产.Checked)
            {
                throw new Exception("只有已审核未排产数据才可登记期初");
            }

            DataTable dt = (DataTable)gridControl1.DataSource;
            if (dt == null || dt.Rows.Count == 0)
                throw new Exception("没有需要登记期初的数据");

            int iCou = DAL.SaveQC(dt);
            if (iCou > 0)
            {
                MessageBox.Show("登记期初成功");

                int iFoc = gridView1.FocusedRowHandle;
                GetGrid();
                gridView1.FocusedRowHandle = iFoc;
            }
            else
                MessageBox.Show("未登记期初");
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
            if (!radio期初.Checked)
            {
                throw new Exception("只有已登记期初才可撤销");
            }

            DataTable dt = (DataTable)gridControl1.DataSource;
            if (dt == null || dt.Rows.Count == 0)
                throw new Exception("没有需要撤销期初的数据");

            int iCou = DAL.SaveUnQC(dt);
            if (iCou > 0)
            {
                MessageBox.Show("撤销期初成功");

                int iFoc = gridView1.FocusedRowHandle;
                GetGrid();
                gridView1.FocusedRowHandle = iFoc;
            }
            else
                MessageBox.Show("未撤销期初");
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
            if (!radio已审核未排产.Checked)
            {
                throw new Exception("只有已审核未排产数据才可登记排产");
            }

            DataTable dt = (DataTable)gridControl1.DataSource;
            if (dt == null || dt.Rows.Count == 0)
                throw new Exception("没有需要排产的数据");

            int iCou = DAL.SavePC(dt);
            if (iCou > 0)
            {
                MessageBox.Show("标记排产成功");

                int iFoc = gridView1.FocusedRowHandle;
                GetGrid();
                gridView1.FocusedRowHandle = iFoc;
            }
            else
                MessageBox.Show("未标记排产");

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
            if (!radio已排产.Checked)
            {
                throw new Exception("只有已排产数据才可撤销排产");
            }

            DataTable dt = (DataTable)gridControl1.DataSource;
            if (dt == null || dt.Rows.Count == 0)
                throw new Exception("没有需要排产的数据");

            int iCou = DAL.SaveUNPC(dt);
            if (iCou > 0)
            {
                MessageBox.Show("撤销排产成功");

                int iFoc = gridView1.FocusedRowHandle;
                GetGrid();
                gridView1.FocusedRowHandle = iFoc;
            }
            else
                MessageBox.Show("未撤销排产");

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
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }
            if (radio不排产.Checked)
            {

                DataTable dt = (DataTable)gridControl1.DataSource;
                if (dt == null || dt.Rows.Count == 0)
                    throw new Exception("没有需要取消标记不排产的数据");

                int iCou = DAL.SaveUNPC(dt);
                if (iCou > 0)
                {
                    MessageBox.Show("取消标记不排产成功");

                    int iFoc = gridView1.FocusedRowHandle;
                    GetGrid();
                    gridView1.FocusedRowHandle = iFoc;
                }
                else
                    MessageBox.Show("未取消标记不排产");
            }
            else
            {
                MessageBox.Show("只有在不排产列表才可取消标记不排产");
            }
        }

        /// <summary>
        /// 关闭
        /// </summary>
        private void btnClose()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }
            if (radio已审核未排产.Checked )
            {

                DataTable dt = (DataTable)gridControl1.DataSource;
                if (dt == null || dt.Rows.Count == 0)
                    throw new Exception("没有需要关闭排产的数据");

                int iCou = DAL.SaveClosePC(dt);
                if (iCou > 0)
                {
                    MessageBox.Show("标记不排产成功");

                    int iFoc = gridView1.FocusedRowHandle;
                    GetGrid();
                    gridView1.FocusedRowHandle = iFoc;
                }
                else
                    MessageBox.Show("未标记不排产");
            }
            else
            {
                MessageBox.Show("只有已审核未排产状态才可标记不排产");
            }
        }

        /// <summary>
        /// 变更
        /// </summary>
        private void btnAlter()
        {
            throw new NotImplementedException();
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

        public void GetLookup()
        {
            DataTable dt = DAL.GetYearMonth();
            lookUpEditYearMonth.Properties.DataSource = dt;

            string sYearMonth = DateTime.Today.ToString("yyyy-MM");
            lookUpEditYearMonth.EditValue = sYearMonth;

            dt = DAL.Get产品大类();
            lookUpEdit产品大类.Properties.DataSource = dt;
        }

        private void Frm交货计划_Load(object sender, EventArgs e)
        {
            try
            {
                bLog = false;
                //DateTime dNow = DAL.Get服务器日期();
                //if (dNow > ReturnObjectToDatetime("2016-1-11"))
                //    bLog = true;

                GetLookup();
                GetGrid();
            }
            catch (Exception ee)
            {
                MsgBox("加载窗体错误", ee.Message);
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column != gridCol选择)
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridCol选择, true);
                }
            }
            catch { }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridCol选择, chkAll.Checked);
                }
            }
            catch { }
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
    }
}
