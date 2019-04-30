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


namespace ImportDLL
{
    public partial class Frm订单评审_下达采购计划 : FrameBaseFunction.FrmFromModel
    {
        TH.DAL.订单评审_下达采购计划 BLL = new TH.DAL.订单评审_下达采购计划();
        TH.DAL.订单评审 DAL = new TH.DAL.订单评审();

        public Frm订单评审_下达采购计划()
        {
            InitializeComponent();

            #region 禁止用户调整表格
            gridView评审计算.OptionsMenu.EnableColumnMenu = false;
            gridView评审计算.OptionsMenu.EnableFooterMenu = false;
            gridView评审计算.OptionsMenu.EnableGroupPanelMenu = false;
            gridView评审计算.OptionsMenu.ShowAutoFilterRowItem = false;
            gridView评审计算.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            gridView评审计算.OptionsMenu.ShowGroupSortSummaryItems = false;
            gridView评审计算.OptionsMenu.ShowGroupSummaryEditorItem = false;
            gridView评审计算.OptionsMenu.ShowAddNewSummaryItem  = DevExpress.Utils.DefaultBoolean.False;
            gridView评审计算.OptionsBehavior.FocusLeaveOnTab = true;
            gridView评审计算.OptionsCustomization.AllowColumnMoving = false;
            //gridView合并.OptionsCustomization.

            #endregion

            sLayoutHeadPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Head.xml";
            sLayoutGridPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Grid.xml";

            if (File.Exists(sLayoutHeadPath))
                layoutControl1.RestoreLayoutFromXml(sLayoutHeadPath);

            if (File.Exists(sLayoutGridPath))
            {
                gridControl评审计算.MainView.RestoreLayoutFromXml(sLayoutGridPath);
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
                gridView评审计算.FocusedRowHandle -= 1;
                gridView评审计算.FocusedRowHandle += 1;
            }
            catch { }

            base.dsPrint.Tables.Clear();
            DataTable dtGrid = SetPrintData(((DataTable)gridControl评审计算.DataSource).Copy());
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
                    gridView评审计算.ExportToXls(sF.FileName);
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

                gridView评审计算.OptionsMenu.EnableColumnMenu = true;
                gridView评审计算.OptionsMenu.EnableFooterMenu = true;
                gridView评审计算.OptionsMenu.EnableGroupPanelMenu = true;
                //gridView合并.OptionsMenu.ShowAddNewSummaryItem = true;
                gridView评审计算.OptionsMenu.ShowAutoFilterRowItem = true;
                gridView评审计算.OptionsMenu.ShowDateTimeGroupIntervalItems = true;
                gridView评审计算.OptionsMenu.ShowGroupSortSummaryItems = true;
                gridView评审计算.OptionsMenu.ShowGroupSummaryEditorItem = true;
                gridView评审计算.OptionsCustomization.AllowColumnMoving = true;
            }
            else
            {
                //layoutControl1.HideCustomizationForm();
                layoutControl1.AllowCustomizationMenu = false;
                gridView评审计算.OptionsMenu.EnableColumnMenu = false;
                gridView评审计算.OptionsMenu.EnableFooterMenu = false;
                gridView评审计算.OptionsMenu.EnableGroupPanelMenu = false;
                //gridView合并.OptionsMenu.ShowAddNewSummaryItem = false;
                gridView评审计算.OptionsMenu.ShowAutoFilterRowItem = false;
                gridView评审计算.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
                gridView评审计算.OptionsMenu.ShowGroupSortSummaryItems = false;
                gridView评审计算.OptionsMenu.ShowGroupSummaryEditorItem = false;
                gridView评审计算.OptionsCustomization.AllowColumnMoving = false;


                if (!Directory.Exists(base.sProPath + "\\layout"))
                    Directory.CreateDirectory(base.sProPath + "\\layout");

                base.toolStripMenuBtn.Items["Layout"].Text = "布局";

                DialogResult d = MessageBox.Show("是否保存?\n是：保存界面样式\n否：恢复默认界面样式,下次加载时将以默认样式打开\n", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
                if (d == DialogResult.Yes)
                {
                    layoutControl1.SaveLayoutToXml(sLayoutHeadPath);
                    gridControl评审计算.MainView.SaveLayoutToXml(sLayoutGridPath);
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
            Frm订单评审_Sel fSel = new Frm订单评审_Sel(3);
            fSel.ShowDialog();
            if (fSel.DialogResult != DialogResult.OK)
            {
                throw new Exception("取消查询");
            }
            GetGrid(fSel.s评审单据号);
        }

        /// <summary>
        /// 首页
        /// </summary>
        private void btnFirst()
        {
            DataTable dt = DAL.GetPSCode("");
            if (dt == null || dt.Rows.Count == 0)
            {
                SetTextNull();
            }
            else
            {
                string sCode = dt.Rows[0]["评审单据号"].ToString().Trim();
                GetGrid(sCode);
            }
        }

        private void SetTextNull()
        {
            txt评审单据号.Text = "";
            dtm评审单据日期.Text = "";
            gridControl评审计算.DataSource = null;
        }
        /// <summary>
        /// 上页
        /// </summary>
        private void btnPrev()
        {
            string sCode = txt评审单据号.Text.Trim();
            DataTable dt = DAL.GetPSCode(" and 评审单据号 < '" + sCode + "'");
            if (dt != null && dt.Rows.Count > 0)
            {
                sCode = dt.Rows[dt.Rows.Count - 1]["评审单据号"].ToString().Trim();
                GetGrid(sCode);
            }
            else
            {
                btnFirst();
            }

        }
        /// <summary>
        /// 下页
        /// </summary>
        private void btnNext()
        {
            string sCode = txt评审单据号.Text.Trim();
            DataTable dt = DAL.GetPSCode(" and 评审单据号 > '" + sCode + "'");
            if (dt != null && dt.Rows.Count > 0)
            {
                sCode = dt.Rows[0]["评审单据号"].ToString().Trim();
                GetGrid(sCode);
            }
            else
            {
                btnLast();
            }
        }

        /// <summary>
        /// 末页
        /// </summary>
        private void btnLast()
        {
            DataTable dt = DAL.GetPSCode("");
            if (dt == null || dt.Rows.Count == 0)
            {
                SetTextNull();
            }
            else
            {
                string sCode = dt.Rows[dt.Rows.Count - 1]["评审单据号"].ToString().Trim();
                GetGrid(sCode);
            }
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
            gridView评审计算.AddNewRow();
        }
        /// <summary>
        /// 删行
        /// </summary>
        private void btnDelRow()
        {
            for (int i = gridView评审计算.RowCount - 1; i >= 0 ; i--)
            {
                if (gridView评审计算.IsRowSelected(i))
                {
                    gridView评审计算.DeleteRow(i);
                }
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {
            if (txt评审单据号.Text.Trim() == "")
            {
                throw new Exception("请选择需要修改的单据");
            }

            dt评审 = (DataTable)gridControl评审计算.DataSource;

            sState = "edit";
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
            //try
            //{
            //    gridView评审计算.FocusedRowHandle -= 1;
            //    gridView评审计算.FocusedRowHandle += 1;
            //}
            //catch { }

            //try
            //{
            //    if (txt评审单据号.Text.Trim() == "")
            //    {
            //        throw new Exception("请选择需要下达的生产订单");
            //    }

            //    dtBingGrid = (DataTable)gridControl评审计算.DataSource;

            //    string s生产订单号 = txt生产订单号.Text.Trim();
            //    if (s生产订单号 == "")
            //    {
            //        DialogResult d = MessageBox.Show("生产订单号为空，是否使用评审单据号作为生产订单号？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            //        if (d == DialogResult.Yes)
            //        {
            //            s生产订单号 = txt评审单据号.Text.Trim();
            //            txt生产订单号.Text = s生产订单号;
            //        }
            //        else
            //        {
            //            throw new Exception("生产订单号不能为空");
            //        }
            //    }

            //    int iCou = BLL.Save(s生产订单号, dtBingGrid);

            //    if (iCou > 0)
            //    {
            //        MessageBox.Show("保存成功：" + txt生产订单号.Text.Trim());
            //    }
            //    else
            //    {
            //        throw new Exception("请选择需要保存的数据");
            //    }
            //}
            //catch (Exception ee)
            //{
            //    throw new Exception(ee.Message);
            //}
        }

        /// <summary>
        /// 获得生产订单单据号
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string GetMOMCode(string s)
        {
            for (int i = 0; i < 5; i++)
            {
                if (s.Length < 4)
                {
                    s = "0" + s;
                }
                else
                {
                    break;
                }
            }
            return "SD" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + s;
        }

        /// <summary>
        /// 撤销
        /// </summary>
        private void btnUnDo()
        {
            //if (txt销售订单ID.Text.Trim() != "")
            //{
            //    //GetGrid(Convert.ToInt64(txt销售订单ID.Text));
            //}
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

        }
      
        private void GetGrid(string sPSCode)
        {
            DataTable dt = DAL.GetPSListHead(sPSCode, "子件属性 = '采购'");

            if (dt == null)
            {
                throw new Exception("获得评审单据失败");
            }

            DataTable dtHead = dt;
            DataTable dtDetail = DAL.GetPSListDetail(sPSCode, "子件属性 = '采购'");

            txt评审单据号.Text = dtHead.Rows[0]["评审单据号"].ToString().Trim();
            dtm评审单据日期.Text = dtHead.Rows[0]["评审单据日期"].ToString().Trim();
        
            gridControl评审计算.DataSource = dtDetail;
        }

        private void gridView评审计算_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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
    }
}
