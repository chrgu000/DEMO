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
    public partial class Frm生产订单中转箱 : FrameBaseFunction.FrmFromModel
    {

        TH.DAL._GetBaseData DALGetBaseData = new TH.DAL._GetBaseData();
        TH.DAL.生产订单中转箱记录 DAL = new TH.DAL.生产订单中转箱记录();

        public Frm生产订单中转箱()
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
            throw new NotImplementedException();
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
                dtBingGrid = (DataTable)gridControl2.DataSource;

                string sInvCode = "";

                long lID = BaseFunction.BaseFunction.ReturnLong(l单据ID.Text.Trim());
                if (lID == 0)
                {
                    throw new Exception("请选择生产订单");
                }

                long lIDDetail = BaseFunction.BaseFunction.ReturnLong(txt生产订单序号.Text.Trim());
                if (lIDDetail == 0)
                {
                    throw new Exception("请选择生产订单");
                }

                decimal d = 0;
                for (int i = 0; i < dtBingGrid.Rows.Count; i++)
                {
                    d = d + BaseFunction.BaseFunction.ReturnDecimal(dtBingGrid.Rows[i]["数量"]);
                }
                if (d != BaseFunction.BaseFunction.ReturnDecimal(txt生产订单数量.Text.Trim()))
                {
                    throw new Exception("装箱数必须等于生产订单数量才能保存");
                }
                    
                int iCou = DAL.Save(lID, lIDDetail, dtBingGrid);
               if (iCou > 0)
                {
                    MessageBox.Show("保存成功");
                    DataTable dt = DAL.GetList(txt生产订单序号.Text.Trim());
                    gridControl2.DataSource = dt;

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
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            try
            {
                dtBingGrid = (DataTable)gridControl2.DataSource;

                int iCou = DAL.Open(dtBingGrid);

                if (iCou > 0)
                {
         
                        MessageBox.Show("打开成功");
               
                    DataTable dt = DAL.GetList(txt生产订单序号.Text.Trim());
                    gridControl2.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("请选择需要打开的数据");
                }
            }
            catch (Exception ee)
            {
                MsgBox("打开失败", ee.Message);
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

            try
            {
                dtBingGrid = (DataTable)gridControl2.DataSource;

                int iCou = DAL.Close(dtBingGrid);

                if (iCou > 0)
                {
                        MessageBox.Show("关闭成功");
                    
                    DataTable dt = DAL.GetList(txt生产订单序号.Text.Trim());
                    gridControl2.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("请选择需要关闭的数据");
                }
            }
            catch (Exception ee)
            {
                MsgBox("关闭失败", ee.Message);
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
                GetLookUp();

                GetGrid();
                l单据ID.Text = "";
                l装箱数.Text = "";
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
            string sWhere = "";
            if (lookUpEdit生产订单号.Text.Trim() != "")
            {
                sWhere = sWhere + " and  a.cCode = '" + lookUpEdit生产订单号.Text.Trim() + "'";
            }
            if (dateEdit1.Text != "")
            {
                sWhere = sWhere + " and  a.dDate >= '" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "'";
            }
            if (dateEdit2.Text != "")
            {
                sWhere = sWhere + " and  a.dDate <= '" + dateEdit2.DateTime.ToString("yyyy-MM-dd") + "'";
            }

            dtBingGrid = DAL.GetListAll(sWhere);
            DataColumn dc = new DataColumn();
            dc.ColumnName = "choose";
            dc.DataType = System.Type.GetType("System.Boolean");
            dc.DefaultValue = false;
            dtBingGrid.Columns.Add(dc);

            gridControl1.DataSource = dtBingGrid;
        }


        private void GetLookUp()
        {
            DataTable dt = DALGetBaseData.GetProductPO("");
            lookUpEdit生产订单号.Properties.DataSource = dt;

            dateEdit1.DateTime = BaseFunction.BaseFunction.ReturnDate(DateTime.Today.ToString("yyyy-MM-01"));
            dateEdit2.DateTime = BaseFunction.BaseFunction.ReturnDate(DateTime.Today.ToString("yyyy-MM-dd"));
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                txt生产订单号.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColc生产订单号).ToString().Trim();
                txt存货编码.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridCol存货编码).ToString().Trim();
                txt生产订单序号.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridCol生产订单序号).ToString().Trim();
                txt生产订单数量.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridCol生产订单数量).ToString().Trim();
                l单据ID.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridCol单据ID).ToString().Trim();

                string s单据明细ID =  gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridCol生产订单序号).ToString().Trim();

                DataTable dt = DAL.GetList(s单据明细ID);
                gridControl2.DataSource = dt;

                if (dt != null && dt.Rows.Count > 0)
                {
                    string s = dt.Rows[0]["箱号"].ToString().Trim();
                    string[] s2 = s.Split('-');
                    txt箱号规则.Text = s2[0].Trim();

                    txtQty.Text = BaseFunction.BaseFunction.ReturnDecimal(dt.Rows[0]["装箱数"]).ToString().Trim();
                }
            }
            catch { }
        }

        private void btn生成_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)gridControl2.DataSource;

                decimal d订单数量 = BaseFunction.BaseFunction.ReturnDecimal(txt生产订单数量.Text);
                if (d订单数量 == 0)
                {
                    throw new Exception("订单数量不能为空或者0");
                }
                decimal d装箱数 = BaseFunction.BaseFunction.ReturnDecimal(txtQty.Text);
                if (d装箱数 == 0)
                {
                    throw new Exception("装箱数不能为空或者0");
                }

                int iBoxCou = BaseFunction.BaseFunction.ReturnInt(Math.Ceiling(d订单数量 / d装箱数));

                l装箱数.Text = iBoxCou.ToString();


                for (int i =dt.Rows.Count ; i < iBoxCou; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["数量"] = d装箱数;
                    dr["选择"] = true;

                    string s = (i + 1).ToString();
                    while (s.Length < 2)
                    {
                        s = "0" + s;
                    }
                    dr["箱号"] = txt箱号规则.Text + "-" + s;
                    dt.Rows.Add(dr);
                }


                gridControl2.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    gridView2.SetRowCellValue(i, gridCol选择, chkAll.Checked);
                }
            }
            catch { }
        }
    }
}
