using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;


namespace Warehouse
{
    public partial class Frm材料检验合格入库 : FrameBaseFunction.Frm列表窗体模板
    {

        DataTable dt入库;
        TH.DBWebService.Cls材料检验合格入库 cls检验入库 = new TH.DBWebService.Cls材料检验合格入库();
        
        public Frm材料检验合格入库()
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


            dt入库 = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "返回信息";
            dt入库.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "检验单号";
            dt入库.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "物料编码";
            dt入库.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "物料名称";
            dt入库.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "规格型号";
            dt入库.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "检验数量";
            dt入库.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "检验件数";
            dt入库.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "可入库数量";
            dt入库.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "可入库件数";
            dt入库.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "本次入库数量";
            dt入库.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "本次入库件数";
            dt入库.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "项目编码";
            dt入库.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "条形码";
            dt入库.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "货位编码";
            dt入库.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "仓库编码";
            dt入库.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "bUsed";
            dt入库.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "单据来源";
            dt入库.Columns.Add(dc);
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
            DataTable dtState = (DataTable)ItemLookUpEditState.DataSource;
            DataColumn dc = new DataColumn();
            dc.ColumnName = "StateText";
            dt.Columns.Add(dc);
           
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow[] drState = dtState.Select("iID = '" + dt.Rows[i]["State"].ToString().Trim() + "'");
                if (drState.Length > 0)
                {
                    dt.Rows[i]["StateText"] = drState[0]["State"];
                }

            }

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
            throw new NotImplementedException();
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
            for (int i = gridView1.RowCount - 1; i >= 0 ; i--)
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
            throw new NotImplementedException();
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
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                int i1 = dt入库.Rows.Count ;
                int i2 = FrameBaseFunction.ClsBaseDataInfo.ReturnInt(txt条数.Text.Trim());
                if (i1!= i2) 
                {
                    throw new Exception("条形码数量不一致");
                }
                if (dt入库 == null || dt入库.Rows.Count < 1)
                {
                    throw new Exception("请先扫条形码");
                }

                string sReturn = cls检验入库.Insert入库单(dt入库,dateEdit单据日期.DateTime);

                if (sReturn.Substring(0, 2) == "成功")
                {
                    dt入库.Clear();
                    txt货位.Text = "";
                    txt条数.Text = "";
                    txt条形码.Text = "";
                    txt条数.Focus();
                }
                MessageBox.Show(sReturn);
            }
            catch (Exception ee)
            {
                MessageBox.Show("保存失败:" + ee.Message);
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

        private void Frm材料检验合格入库_Load(object sender, EventArgs e)
        {
            try
            {
                dateEdit单据日期.Text = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void GetGrid()
        {
            //int iFocRow = gridView1.FocusedRowHandle;
            //string sSQL = "select *,cast(null as varchar(10)) as iSave from dbo.Machine order by MachineNO";
            //dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
            //gridControl1.DataSource = dtBingGrid;

            //gridView1.AddNewRow();

            //gridView1.FocusedRowHandle = iFocRow;
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


        private void txt条形码_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13 && txt条形码.Text.Trim() != "")
                {
                    DataTable dt = cls检验入库.GetBarArrInfo(txt条形码.Text.Trim());
                    if (dt == null || dt.Rows.Count < 1)
                    {
                        throw new Exception("条码扫描失败");
                    }


                    string s返回信息 = dt.Rows[0]["返回信息"].ToString().Trim();
                    if (s返回信息 != string.Empty)
                    {
                        throw new Exception(s返回信息);
                    }

                    string s条形码 = dt.Rows[0]["条形码"].ToString().Trim();
                    for (int i = 0; i < dt入库.Rows.Count; i++)
                    {
                        string s条形码2 = dt入库.Rows[i]["条形码"].ToString().Trim();
                        if (s条形码 == s条形码2)
                        {
                            throw new Exception("该条码已扫");
                        }
                    }

                    DataRow dr = dt入库.NewRow();
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        dr[dt.Columns[i].ColumnName] = dt.Rows[0][i];
                    }

                    string s货位 = txt货位.Text.Trim();
                    if (s货位 != "")
                    {
                        string sInvCode = dt.Rows[0]["物料编码"].ToString().Trim();
                        int iCou = cls检验入库.Chk货位物料(s货位, sInvCode);
                        if (iCou <= 0)
                        {
                            DialogResult d = MessageBox.Show("物料、货位不对应，是否继续","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Asterisk);
                            if (d != DialogResult.Yes)
                            {
                                throw new Exception("物料货位不对应");
                            }
                        }

                        DataTable dt货位 = cls检验入库.Chk货位(s货位);
                        if (dt货位 == null || dt货位.Rows.Count < 1)
                        {
                            throw new Exception("货位信息失败");
                        }
                        if (dt货位.Rows[0]["返回信息"].ToString().Trim() != "")
                        {
                            throw new Exception(dt货位.Rows[0]["返回信息"].ToString().Trim());
                        }

                        dr["货位编码"] = dt货位.Rows[0]["货位编码"].ToString().Trim();
                        dr["仓库编码"] = dt货位.Rows[0]["仓库编码"].ToString().Trim();
                    }
                    else
                    {
                        string sInvCode = dt.Rows[0]["物料编码"].ToString().Trim();
                        DataTable dt默认货位 = cls检验入库.Get默认入库货位(sInvCode);

                        if (dt默认货位 == null || dt默认货位.Rows.Count < 1)
                        {
                            throw new Exception("货位信息失败");
                        }
                        if (dt默认货位.Rows[0]["返回信息"].ToString().Trim() != "")
                        {
                            throw new Exception(dt默认货位.Rows[0]["返回信息"].ToString().Trim());
                        }

                        dr["货位编码"] = dt默认货位.Rows[0]["货位编码"].ToString().Trim();
                        dr["仓库编码"] = dt默认货位.Rows[0]["仓库编码"].ToString().Trim();
                    }
                    dt入库.Rows.Add(dr);

                    gridControl1.DataSource = dt入库;

                    txt条形码.Text = "";
                    txt条形码.Focus();
                }
            }
            catch (Exception ee)
            {
                txt条形码.Text = "";
                MessageBox.Show("条码数据失败:" + ee.Message);
            }
        }

        private void txt货位_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    if (txt货位.Text.Trim() == "")
                    {
                        return;
                    }
                    string s货位 = txt货位.Text.Trim();
                    DataTable dt货位 = cls检验入库.Chk货位(s货位);
                    if (dt货位 == null || dt货位.Rows.Count < 1)
                    {
                        throw new Exception("货位信息失败");
                    }
                    if (dt货位.Rows[0]["返回信息"].ToString().Trim() != "")
                    {
                        throw new Exception(dt货位.Rows[0]["返回信息"].ToString().Trim());
                    }

                    txt条形码.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("货物错误:" + ee.Message);
                if (txt货位.Text.Trim() != "")
                {
                    txt货位.Text = "";
                }
            }
        }

        private void txt条数_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    if (txt条数.Text.Trim() == "")
                        return;

                    int iR =FrameBaseFunction.ClsBaseDataInfo.ReturnInt(txt条数.Text.Trim()) ;
                    if (iR <=0)
                    {
                       throw new Exception("条数必须大于0");
                    }
                    txt货位.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                if (txt条数.Text.Trim() != "")
                {
                    txt条数.Text = "";
                }
            }
        }
    }
}
