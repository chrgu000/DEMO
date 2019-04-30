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
    public partial class Frm订单评审 : FrameBaseFunction.FrmFromModel
    {
        TH.Model.订单评审 Model = new TH.Model.订单评审();
        TH.Model.订单评审明细 ModelDetail = new TH.Model.订单评审明细();

        TH.DAL.订单评审 DAL = new TH.DAL.订单评审();
        TH.DAL.GetBaseData DALBaseData = new TH.DAL.GetBaseData();

        public Frm订单评审()
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
            gridView评审计算.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.False;
            gridView评审计算.OptionsBehavior.FocusLeaveOnTab = true;
            gridView评审计算.OptionsCustomization.AllowColumnMoving = false;
            //gridView1.OptionsCustomization.

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

            SetEnable(false);
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
        DataTable dt评审计算 = new DataTable();

        private void btnAdd()
        {
            try
            {
                radio逆排.Checked = true;

                Frm订单评审_Add fAdd = new Frm订单评审_Add();
                DialogResult d = fAdd.ShowDialog();
                if (d != DialogResult.OK)
                {
                    throw new Exception("取消新增");
                }

                string sAutoID = fAdd.s销售订单ID;

                string sSQLWhere = " and b.AutoID in (" + sAutoID + ")";
                DataTable dt = DAL.GetSoMainList(sSQLWhere);
                if (dt == null || dt.Rows.Count < 1)
                    throw new Exception("请选择需要评审的销售订单");

                string sErrInfo = "";
                DataTable dtBom = DAL.GetBomAll(dt,out sErrInfo,textEdit单据号.Text.Trim());

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string s销售订单号 = dt.Rows[i]["销售订单号"].ToString().Trim();
                    int i销售订单行号 = BaseFunction.BaseFunction.ReturnInt(dt.Rows[i]["行号"]);
                    string sGuid = dt.Rows[i]["GUID"].ToString().Trim();

                    for (int j = 0; j < dtBom.Rows.Count; j++)
                    {
                        string s销售订单号2 = dtBom.Rows[j]["销售订单号"].ToString().Trim();
                        int i销售订单行号2 = BaseFunction.BaseFunction.ReturnInt(dtBom.Rows[j]["销售订单行号"]);

                        if (s销售订单号 == s销售订单号2 && i销售订单行号 == i销售订单行号2)
                        {
                            dtBom.Rows[j]["GUIDHead"] = sGuid;

                            Guid g = Guid.NewGuid();
                            dtBom.Rows[j]["GUID"] = g.ToString();
                        }
                        
                    }
                }

                gridControl1.DataSource = dt;

                gridControl评审计算.DataSource = dtBom;

                textEdit单据号.Text = "";
                dtm单据日期.DateTime = DateTime.Today;
                SetEnable(true);

            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }

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
                //gridView1.OptionsMenu.ShowAddNewSummaryItem = true;
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
                //gridView1.OptionsMenu.ShowAddNewSummaryItem = false;
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
            GetLookUp();
        }

        private string sFrmSEL = "";

        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
            try
            {
                SetEnable(true);
                radio逆排.Checked = true;

                Frm订单评审_Sel fSel = new Frm订单评审_Sel();
                DialogResult d = fSel.ShowDialog();
                if (d != DialogResult.OK)
                {
                    throw new Exception("取消操作");
                }

                string sPSCode = fSel.s评审单据号;

                GetGrid(sPSCode);
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        private void GetGrid(string sPSCode)
        {
            GetLookUp();

            DataSet ds = new DataSet();

            DataTable dtHead = DAL.GetPSListHead(sPSCode).Copy();
            dtHead.TableName = "dtHead";
            ds.Tables.Add(dtHead);
            DataTable dtDetail = DAL.GetPSListDetail(sPSCode).Copy();
            dtDetail.TableName = "dtDetail";
            ds.Tables.Add(dtDetail);

            if (ds == null || ds.Tables.Count != 2)
            {
                throw new Exception("获得评审单据失败");
            }
            DataTable dt = ds.Tables[0];
            gridControl1.DataSource = dt;

            DataTable dtDetails = ds.Tables[1];
            gridControl评审计算.DataSource = dtDetails;

            textEdit单据号.Text = dt.Rows[0]["评审单据号"].ToString().Trim();
            dtm单据日期.Text = dt.Rows[0]["评审单据日期"].ToString().Trim();
            txt制单人.Text = dt.Rows[0]["制单人"].ToString().Trim();
            dtm制单日期.Text = dt.Rows[0]["制单日期"].ToString().Trim();
            txt审核人.Text = dt.Rows[0]["审核人"].ToString().Trim();
            dtm审核日期.Text = dt.Rows[0]["审核日期"].ToString().Trim();
            txt关闭人.Text = dt.Rows[0]["关闭人"].ToString().Trim();
            dtm关闭日期.Text = dt.Rows[0]["关闭日期"].ToString().Trim();

            SetEnable(false);
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
            textEdit单据号.Text = "";
            dtm单据日期.Text = "";
            txt制单人.Text = "";
            txt审核人.Text = "";
            txt关闭人.Text = "";
            dtm制单日期.Text = "";
            dtm审核日期.Text = "";
            dtm关闭日期.Text = "";

            gridControl1.DataSource = null;
            gridControl评审计算.DataSource = null;
        }
        /// <summary>
        /// 上页
        /// </summary>
        private void btnPrev()
        {
            string sCode = textEdit单据号.Text.Trim();
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
            string sCode = textEdit单据号.Text.Trim();
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
            for (int i = gridView评审计算.RowCount - 1; i >= 0; i--)
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
            string sCode = textEdit单据号.Text.Trim();

            if (sCode == "")
                throw new Exception("请选择需要审核的单据");

            bool b = DAL.Edit(sCode);
            if (b)
            {
                SetEnable(true);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
            string sCode = textEdit单据号.Text.Trim();

            if (sCode == "")
                throw new Exception("请选择需要删除的单据");

            DialogResult d = MessageBox.Show("确定删除当前单据么？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if(d == DialogResult.Yes)
            {
              bool b =  DAL.Delete(sCode);
              if (b)
              {
                  MessageBox.Show("删除成功");
                  btnPrev();
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
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }
            try
            {
                gridView评审计算.FocusedRowHandle -= 1;
                gridView评审计算.FocusedRowHandle += 1;
            }
            catch { }

            try
            {
                dtBingHead =  (DataTable)gridControl1.DataSource;
                dtBingGrid = (DataTable)gridControl评审计算.DataSource;

                if(dtm单据日期.Text.Trim() == "")
                    dtm单据日期.DateTime = DateTime.Today;

                string sQZ = "PS" + dtm单据日期.DateTime.ToString("yyMMdd");

                string s评审单据号 = textEdit单据号.Text.Trim();
                if (s评审单据号.Length > 8 && sQZ == s评审单据号.Substring(0, 8))
                {

                }
                else
                {
                    s评审单据号 = DAL.GetNewCode(sQZ);
                    if (s评审单据号 == "")
                        s评审单据号 = sQZ + "001";
                    else
                    {
                        string sCode = s评审单据号.Substring(s评审单据号.Length - 3);
                        int iCode = BaseFunction.BaseFunction.ReturnInt(sCode) + 1;
                        sCode = iCode.ToString().Trim();
                        for (int i = 0; i < 3; i++)
                        {
                            if (sCode.Length < 3)
                            {
                                sCode = "0" + sCode;
                            }
                            else
                            {
                                break;
                            }
                        }

                        s评审单据号 = sQZ + sCode;
                    }
                }

                for (int i = 0; i < dtBingHead.Rows.Count; i++)
                {
                    dtBingHead.Rows[i]["评审单据日期"] = dtm单据日期.DateTime.ToString("yyyy-MM-dd");
                }

                int iCou = DAL.Save(sState,s评审单据号, dtBingHead, dtBingGrid);

                if (iCou > 0)
                {
                    MessageBox.Show("保存成功");
                    textEdit单据号.Text = s评审单据号;

                    GetGrid(s评审单据号);
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
            string sPSCode = textEdit单据号.Text.Trim();
            if (sPSCode != "")
            {
                GetGrid(sPSCode);
            }
            else
            {
                btnLast();
            }
        }
        /// <summary>
        /// 审核
        /// </summary>
        private void btnAudit()
        {
            string sCode = textEdit单据号.Text.Trim();

            if (sCode == "")
                throw new Exception("请选择需要审核的单据");

            bool b = DAL.Audit(sCode);
            if (b)
            {
                MessageBox.Show("审核成功");
                GetGrid(sCode);
            }
        }

        /// <summary>
        /// 弃审
        /// </summary>
        private void btnUnAudit()
        {
            string sCode = textEdit单据号.Text.Trim();

            if (sCode == "")
                throw new Exception("请选择需要弃审的单据");

            bool b = DAL.UnAudit(sCode);
            if (b)
            {
                MessageBox.Show("弃审成功");
                GetGrid(sCode);
            }
        }
        /// <summary>
        /// 打开
        /// </summary>
        private void btnOpen()
        {
            string sCode = textEdit单据号.Text.Trim();

            if (sCode == "")
                throw new Exception("请选择需要打开的单据");

            bool b = DAL.Open(sCode);
            if (b)
            {
                MessageBox.Show("打开成功");
                GetGrid(sCode);
            }
        }

        /// <summary>
        /// 关闭
        /// </summary>
        private void btnClose()
        {
            string sCode = textEdit单据号.Text.Trim();

            if (sCode == "")
                throw new Exception("请选择需要关闭的单据");

            bool b = DAL.Close(sCode);
            if (b)
            {
                MessageBox.Show("关闭成功");
                GetGrid(sCode);
            }
        }

        /// <summary>
        /// 变更
        /// </summary>
        private void btnAlter()
        {
            throw new NotImplementedException();
        }


        private void Frm订单评审运算_Load(object sender, EventArgs e)
        {
            dateEditNow.DateTime = DateTime.Today;
            GetLookUp();
            btnLast();
        }

        private void gridView销售订单列表_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void GetSelList()
        {
            string sSQL = "select 销售订单ID from 订单评审运算1 where 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim() + " order by 销售订单号";
            dtSel = clsSQLCommond.ExecQuery(sSQL);

            if (dtSel != null && dtSel.Rows.Count > 0)
            {
                iPage = dtSel.Rows.Count - 1;
            }
        }




        private void chk开始日期_CheckedChanged(object sender, EventArgs e)
        {
            if (chk开始日期.Checked)
                dtm开始日期.Enabled = true;
            else
            {
                dtm开始日期.Enabled = false;
                dtm开始日期.Text = "";
            }

        }

        private void chk完成日期_CheckedChanged(object sender, EventArgs e)
        {

            if (chk完成日期.Checked)
                dtm完成日期.Enabled = true;
            else
            {
                dtm完成日期.Enabled = false;
                dtm完成日期.Text = "";
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

        private void gridView评审计算_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                gridControl评审计算.Refresh();
               
                int iRow = e.RowHandle;
                string sSaleRow = gridView评审计算.GetRowCellValue(iRow, gridCol销售单号).ToString().Trim();
                string sInvCode = gridView评审计算.GetRowCellValue(iRow, gridCol母件编码).ToString().Trim();
                string scInvCode = gridView评审计算.GetRowCellValue(iRow, gridCol子件编码).ToString().Trim();
                string sMZ = gridView评审计算.GetRowCellValue(iRow, gridCol母子关联).ToString().Trim();
                decimal dQty = BaseFunction.BaseFunction.ReturnDecimal(gridView评审计算.GetRowCellValue(iRow, gridCol本单需求数量));
                DateTime dEndtime = BaseFunction.BaseFunction.ReturnDate(gridView评审计算.GetRowCellValue(iRow, gridCol结束日期));
                DateTime dStarttime = BaseFunction.BaseFunction.ReturnDate(gridView评审计算.GetRowCellValue(iRow, gridCol开始日期));
                string s子件属性 = gridView评审计算.GetRowCellValue(iRow, gridCol子件属性).ToString().Trim();
                decimal d单件生产工时 = BaseFunction.BaseFunction.ReturnDecimal(gridView评审计算.GetRowCellValue(iRow, gridCol单件默认生产工时));
                decimal d合计生产工时 = d单件生产工时 * dQty;
                decimal d产线并发生产 = BaseFunction.BaseFunction.ReturnDecimal(gridView评审计算.GetRowCellValue(iRow, gridCol默认产线并发生产数), 1, 1);

                decimal d产线占用时间 = d合计生产工时 / d产线并发生产;
                decimal dWorkTime = d产线占用时间 + BaseFunction.BaseFunction.ReturnDecimal(gridView评审计算.GetRowCellValue(iRow, gridCol生产准备时间));

                if (radio逆排.Checked &&(sState == "add" || sState == "edit"))
                {
                    if (e.Column == gridCol结束日期 || e.Column == gridCol本单需求数量 || e.Column == gridCol置办周期 || e.Column == gridCol质检周期)
                    {
                        if (s子件属性 == "采购")
                            return;

                        int i置办周期 = BaseFunction.BaseFunction.ReturnInt(gridView评审计算.GetRowCellValue(iRow, gridCol置办周期));
                        if (s子件属性 == "自制" && e.Column != gridCol置办周期)
                        {
                            string sLineNo = gridView评审计算.GetRowCellValue(iRow, gridCol默认产线).ToString().Trim();
                            i置办周期 = DAL.GetiTimeN(dEndtime, dWorkTime, sLineNo);
                            gridView评审计算.SetRowCellValue(iRow, gridCol置办周期, i置办周期);
                        }

                        if (i置办周期 >= 1)
                            i置办周期 = i置办周期 - 1;

                        DateTime dStart = dEndtime.AddDays(-1 * i置办周期);
                        gridView评审计算.SetRowCellValue(iRow, gridCol开始日期, dStart);
                        sMZ = sMZ + "→" + gridView评审计算.GetRowCellValue(iRow, gridCol子件编码).ToString().Trim();

                        DAL.dtInitBomN = ((DataTable)gridControl评审计算.DataSource);

                        DAL.GetInitBomEditN(scInvCode, sMZ, dQty, dStart, sSaleRow,textEdit单据号.Text.Trim());
                    }
                }
                if (radio顺排.Checked && (sState == "edit" || sState == "add"))
                {
                    if ((s子件属性 != "采购" && e.Column == gridCol开始日期) || (s子件属性 == "采购" && e.Column == gridCol结束日期) || e.Column == gridCol本单需求数量 || e.Column == gridCol置办周期 || e.Column == gridCol质检周期)
                    {
                        int i置办周期 = BaseFunction.BaseFunction.ReturnInt(gridView评审计算.GetRowCellValue(iRow, gridCol置办周期));
                        if (s子件属性 == "自制" && e.Column != gridCol置办周期)
                        {
                            string sLineNo = gridView评审计算.GetRowCellValue(iRow, gridCol默认产线).ToString().Trim();
                            i置办周期 = DAL.GetTimeS(dQty, dStarttime, d产线并发生产, d单件生产工时, sLineNo);
                            gridView评审计算.SetRowCellValue(iRow, gridCol置办周期, i置办周期);
                        }

                        if (i置办周期 >= 1)
                            i置办周期 = i置办周期 - 1;

                        if (e.Column == gridCol开始日期)
                        {
                            dEndtime = dStarttime.AddDays(i置办周期);
                            gridView评审计算.SetRowCellValue(iRow, gridCol结束日期, dEndtime);
                        }

                        int i质检周期 = 0;
                        if (dQty > 0)
                            i质检周期 = BaseFunction.BaseFunction.ReturnInt(gridView评审计算.GetRowCellValue(iRow, gridCol质检周期));
                         //InitEditS(string sInvCode, string s母子关联, DateTime dDate1, string sSaleRow)

                        DateTime d母件开始时间 = dEndtime.AddDays(i质检周期).AddDays(1);
                        DAL.dtInitBomN = ((DataTable)gridControl评审计算.DataSource);
                        DAL.GetInitEditS(sInvCode, sMZ, d母件开始时间, sSaleRow);
                    }
                }
            }
            catch(Exception ee)
            {
                MsgBox("操作失败", ee.Message);
            }
        }


        private void SetEnable(bool b)
        {
            groupBox1.Enabled = b;
            gridView评审计算.OptionsBehavior.Editable = b;
            radio逆排.Enabled = b;
            radio顺排.Enabled = b;
            radio手工.Enabled = b;

            dtm单据日期.Enabled = b;

            gridView1.OptionsBehavior.Editable = b;
            gridView评审计算.OptionsBehavior.Editable = b;
        }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            if (radio逆排.Checked)
            {
                gridCol本单需求数量.OptionsColumn.AllowEdit = true;
                gridCol开始日期.OptionsColumn.AllowEdit = false;
                gridCol结束日期.OptionsColumn.AllowEdit = true;
                gridCol置办周期.OptionsColumn.AllowEdit = true;
                gridCol单件默认生产工时.OptionsColumn.AllowEdit = true;
                gridCol默认产线并发生产数.OptionsColumn.AllowEdit = true;
            }
            if (radio顺排.Checked)
            {
                gridCol本单需求数量.OptionsColumn.AllowEdit = false;
                gridCol开始日期.OptionsColumn.AllowEdit = true;
                gridCol结束日期.OptionsColumn.AllowEdit = false;
                gridCol置办周期.OptionsColumn.AllowEdit = true;
                gridCol单件默认生产工时.OptionsColumn.AllowEdit = true;
                gridCol默认产线并发生产数.OptionsColumn.AllowEdit = true;
                dateEditNow.Enabled = true;
                btn日期顺推.Enabled = true;
            }
            else
            {
                dateEditNow.Enabled = false;
                btn日期顺推.Enabled = false;
            }

            if (radio手工.Checked)
            {
                gridCol本单需求数量.OptionsColumn.AllowEdit = true;
                gridCol开始日期.OptionsColumn.AllowEdit = true;
                gridCol结束日期.OptionsColumn.AllowEdit = true;
                gridCol置办周期.OptionsColumn.AllowEdit = false;
                gridCol单件默认生产工时.OptionsColumn.AllowEdit = false;
                gridCol默认产线并发生产数.OptionsColumn.AllowEdit = false;
            }
        }

        private void gridView评审计算_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (sState == "add" || sState == "edit")
                {
                    if (gridView评审计算.GetRowCellValue(e.FocusedRowHandle, gridCol子件属性).ToString().Trim() == "采购")
                    {
                        gridCol开始日期.OptionsColumn.AllowEdit = false;
                        gridCol结束日期.OptionsColumn.AllowEdit = true;
                    }
                    else
                    {
                        radio_CheckedChanged(null, null);
                    }
                }
            }
            catch (Exception ee)
            { 
            
            }
        }

        private void gridView评审计算_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Frm存货供需信息 f = new Frm存货供需信息();

                int iRow = gridView评审计算.FocusedRowHandle;
                f.sInvCode = gridView评审计算.GetRowCellValue(iRow, gridCol子件编码).ToString().Trim();
                f.sPCCode = textEdit单据号.Text.Trim();

                f.StartPosition = FormStartPosition.CenterParent;
                f.WindowState = FormWindowState.Normal;
                f.ShowDialog();
            }
            catch { }
        }

        private void btn日期顺推_Click(object sender, EventArgs e)
        {
            if (sState == "add" || sState == "edit")
            {
                radio顺排.Checked = true;
                for (int i = 0; i < gridView评审计算.RowCount; i++)
                {
                    if (gridView评审计算.GetRowCellValue(i, gridCol子件属性).ToString().Trim() == "采购")
                    {
                        DateTime dEnd = BaseFunction.BaseFunction.ReturnDate(gridView评审计算.GetRowCellValue(i, gridCol结束日期));
                        if (dEnd < dateEditNow.DateTime)
                        {
                            dEnd = dateEditNow.DateTime.AddDays(1);
                            gridView评审计算.SetRowCellValue(i, gridCol结束日期, dEnd);
                        }
                    }
                }
            }
        }

        private void gridView评审计算_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                DevExpress.Utils.AppearanceDefault appTomato = new DevExpress.Utils.AppearanceDefault(Color.Tomato);
                DevExpress.Utils.AppearanceDefault appLawnGreen = new DevExpress.Utils.AppearanceDefault(Color.LawnGreen);
                DevExpress.Utils.AppearanceDefault appYellow = new DevExpress.Utils.AppearanceDefault(Color.Yellow);
                DevExpress.Utils.AppearanceDefault apprLightSkyBlue = new DevExpress.Utils.AppearanceDefault(Color.LightSkyBlue);

                string sName = e.Column.Name.ToString().Trim();
                if (sName == "gridCol结束日期" || sName == "gridCol开始日期")
                {
                    DateTime d = BaseFunction.BaseFunction.ReturnDate(gridView评审计算.GetRowCellValue(e.RowHandle, e.Column));
                    if (d > Convert.ToDateTime("2000-1-1") && d < DateTime.Today)
                        DevExpress.Utils.AppearanceHelper.Apply(e.Appearance, appTomato);
                }
                if (sName == "gridCol子件编码")
                { 
                    if(gridView评审计算.GetRowCellValue(e.RowHandle, gridCol子件属性).ToString().Trim() == "自制" && gridView评审计算.GetRowCellValue(e.RowHandle, gridCol供应类型).ToString().Trim() != "虚拟件" && (gridView评审计算.GetRowCellValue(e.RowHandle, gridCol默认产线).ToString().Trim() == "" || gridView评审计算.GetRowCellValue(e.RowHandle, gridCol默认产线).ToString().Trim() == "99"))
                    {
                        DevExpress.Utils.AppearanceHelper.Apply(e.Appearance, appTomato);
                    }

                    if (gridView评审计算.GetRowCellDisplayText(e.RowHandle, gridCol供应类型).ToString().Trim() == "虚拟件")
                    {
                        DevExpress.Utils.AppearanceHelper.Apply(e.Appearance, apprLightSkyBlue);
                    }
                }
                if (sName == "gridCol需求数量" && gridView评审计算.GetRowCellValue(e.RowHandle, gridCol母件编码) == "--")
                {
                    decimal d1 = BaseFunction.BaseFunction.ReturnDecimal(gridView评审计算.GetRowCellValue(e.RowHandle, gridCol需求数量));
                    decimal d2 = BaseFunction.BaseFunction.ReturnDecimal(gridView评审计算.GetRowCellValue(e.RowHandle, gridCol本单需求数量));
                    if (d1 != d2)
                    {
                        DevExpress.Utils.AppearanceHelper.Apply(e.Appearance, appYellow);
                    }
                }
            }
            catch (Exception ee)
            { 
            
            }
        }

        private void GetLookUp()
        {
            DataTable dt = DALBaseData.GetProductionLine("");
            ItemLookUpEdit产线.DataSource = dt;
            ItemLookUpEdit产线编码.DataSource = dt;
        }
    }
}
