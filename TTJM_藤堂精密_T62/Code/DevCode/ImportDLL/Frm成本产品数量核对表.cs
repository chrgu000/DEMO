using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;
using System.Data.SqlClient;
using FrameBaseFunction;

namespace ImportDLL
{
    public partial class Frm成本产品数量核对表 : FrameBaseFunction.FrmFromModel
    {
        TH.DAL.成本报表 DAL = new TH.DAL.成本报表();

        string sTable = "成本产品数量核对表";

        public Frm成本产品数量核对表()
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
            gridView1.OptionsCustomization.AllowColumnMoving = true;
            gridView1.OptionsCustomization.AllowColumnMoving = false;
            //gridView1.OptionsCustomization.

            #endregion


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


                base.toolStripMenuBtn.Items["Layout"].Text = "布局";

                DialogResult d = MessageBox.Show("是否保存?\n是：保存界面样式\n否：取消保存", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (d == DialogResult.Yes)
                {
                    int iCou = 0;
                    SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
                    conn.Open();
                    //启用事务
                    SqlTransaction tran = conn.BeginTransaction();
                    try
                    {
                        sSQL = @"update [dbo].[列表设置] set [可见] = 0 where 库名 = '.' and [表名] = '111111'";
                        sSQL = sSQL.Replace("111111", sTable);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        for (int i = 0; i < gridView1.Columns.Count; i++)
                        {
                            int iW = gridView1.Columns[i].Width;
                            string sColName = gridView1.Columns[i].FieldName.Trim();
                            string sColText = gridView1.Columns[i].Caption.Trim();
                            int iIndex = gridView1.Columns[i].VisibleIndex;
                            bool bVis = gridView1.Columns[i].Visible;

                            sSQL = @"update [dbo].[列表设置] set [排序] = 444444,[可见] = 555555, [宽度] = " + iW + " where 库名 = '.' and [表名] = '111111' and [列名] = '222222' and [列标题] = '333333'";
                            sSQL = sSQL.Replace("111111", sTable);
                            sSQL = sSQL.Replace("222222", sColName);
                            sSQL = sSQL.Replace("333333", sColText);
                            sSQL = sSQL.Replace("444444", iIndex.ToString().Trim());
                            if (bVis)
                            {
                                sSQL = sSQL.Replace("555555", "1");
                            }
                            else
                            {
                                sSQL = sSQL.Replace("555555", "0");
                            }
                            iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        }
                        if (iCou > 0)
                        {
                            tran.Commit();
                        }
                        else
                        {
                            tran.Rollback();
                        }
                    }
                    catch (Exception error)
                    {
                        tran.Rollback();

                        throw new Exception(error.Message);
                    }
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
            
        }
        /// <summary>
        /// 撤销
        /// </summary>
        private void btnUnDo()
        {
 
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
                if (lookUpEdit盘点期间.Text.Trim() == "")
                {
                    return;
                }

                GetGrid();
              
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
            if (lookUpEdit盘点期间.Text.Trim() == "")
            {
                lookUpEdit盘点期间.Focus();
                throw new Exception("请选择盘点期间");
            }

            DateTime dDate = ReturnObjectToDatetime(lookUpEdit盘点期间.Text.Trim() + "-01");
            DataTable dt = DAL.Get成本产品数量核对表(dDate);
            gridControl1.DataSource = dt;
        }

        private void GetLookUp()
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "年月";
            dt.Columns.Add(dc);

            int iYear = DateTime.Today.AddYears(-1).Year;

            for (int i = iYear; i <= DateTime.Today.AddYears(1).Year; i++)
            {
                for (int j = 1; j <= 12; j++)
                {
                    DataRow dr = dt.NewRow();

                    string sMonth = j.ToString();
                    if (sMonth.Length < 2)
                    {
                        sMonth = "0" + sMonth;
                    }
                    dr["年月"] = i.ToString() + "-" + sMonth;
                    dt.Rows.Add(dr);
                }
            }
            lookUpEdit盘点期间.Properties.DataSource = dt;
            lookUpEdit盘点期间.EditValue = DateTime.Today.ToString("yyyy-MM");
        }
    }
}
