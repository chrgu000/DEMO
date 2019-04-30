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

namespace 成衣生产
{
    public partial class Frm纱种 : 系统服务.FrmBaseInfo
    {
        string sTable = "纱种";

        public Frm纱种()
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
                throw new Exception(ee.Message);
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
            gridView1.OptionsBehavior.Editable = true;
            sState = "edit";
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
            string sErr = "";
            DialogResult result = MessageBox.Show("是否删除?", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (result != DialogResult.Yes)
            {
                return;
            }

            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            int iCount = 0;
            SqlConnection conn = new SqlConnection(系统服务.ClsBaseDataInfo.sConnString);
            conn.Open();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    bool bChk = ReturnBool(gridView1.GetRowCellValue(i, gridColchoose));
                    if (!bChk)
                        continue;

                    sSQL = "delete aaaaaa where iID = " + gridView1.GetRowCellValue(i, gridColiID).ToString().Trim();
                    sSQL = sSQL.Replace("aaaaaa", sTable);
                    iCount += 系统服务.DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }

                if (sErr.Trim().Length > 0)
                {
                    throw new Exception(sErr);
                }

                if (iCount > 0)
                {
                    tran.Commit();
                    MessageBox.Show("保存成功！\n合计执行语句:" + iCount + "条");
                    GetGrid();
                }
                else
                {
                    throw new Exception("没有需要保存的数据");
                }
            }
            catch (Exception ee)
            {
                tran.Rollback();
                throw new Exception(ee.Message);
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

            string sErr = "";

            SqlConnection conn = new SqlConnection(系统服务.ClsBaseDataInfo.sConnString);
            conn.Open();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                int iCount = 0;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    bool bChk = ReturnBool(gridView1.GetRowCellValue(i, gridColchoose));
                    if (!bChk)
                        continue;

                    string scCode = gridView1.GetRowCellValue(i, gridColcCode).ToString().Trim();
                    string scName = gridView1.GetRowCellValue(i, gridColcName).ToString().Trim();

                    if (scCode.Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + gridColcCode.Caption + " 不能为空\n";
                        continue;
                    }
                    if (scName.Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + gridColcCode.Caption + " 不能为空\n";
                        continue;
                    }

                    sSQL = "select * from aaaaaa where cCode = '" + scCode + "'";
                    sSQL = sSQL.Replace("aaaaaa", sTable);
                    DataTable dt = 系统服务.DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        sSQL = @"insert into aaaaaa( cCode, cName, Remark, CreateUid, CreateDate, UpdateDate)
                            values('bbbbbb','cccccc','dddddd','eeeeee',getdate(),getdate())";
                        sSQL = sSQL.Replace("aaaaaa", sTable);
                        sSQL = sSQL.Replace("bbbbbb", scCode);
                        sSQL = sSQL.Replace("cccccc", scName);
                        sSQL = sSQL.Replace("dddddd", gridView1.GetRowCellValue(i, gridColRemark).ToString().Trim());
                        sSQL = sSQL.Replace("eeeeee", 系统服务.ClsBaseDataInfo.sUid);

                        iCount += 系统服务.DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                    else
                    {
                        sSQL = @"
update aaaaaa set Remark = 'dddddd' ,UpdateDate = getdate()
where iID = ffffff
"; 
                        sSQL = sSQL.Replace("aaaaaa", sTable);
                        sSQL = sSQL.Replace("bbbbbb", scCode);
                        sSQL = sSQL.Replace("cccccc", scName);
                        sSQL = sSQL.Replace("dddddd", gridView1.GetRowCellValue(i, gridColRemark).ToString().Trim());
                        sSQL = sSQL.Replace("ffffff", gridView1.GetRowCellValue(i, gridColiID).ToString().Trim());

                        iCount += 系统服务.DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                }

                if (sErr.Trim().Length > 0)
                {
                    throw new Exception(sErr);
                }

                if (iCount > 0)
                {
                    tran.Commit();
                    MessageBox.Show("保存成功！\n合计执行语句:" + iCount + "条");
                    GetGrid();
                }
                else
                {
                    throw new Exception("没有需要保存的数据");
                }
            }
            catch (Exception ee)
            {
                tran.Rollback();
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

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                GetLayOut(layoutControl1, gridControl1);
                GetGrid();
            }
            catch (Exception ee)
            {
                throw new Exception("加载窗体失败\n" + ee.Message);
            }
        }

        private void GetGrid()
        {
            int iFocRow = 0;
            if (gridView1.FocusedRowHandle > 0)
                iFocRow = gridView1.FocusedRowHandle;

            string sSQL = "select cast(0 as bit) as choose, * from aaaaaa order by  cCode";
            sSQL = sSQL.Replace("aaaaaa", sTable);
            dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dtBingGrid;


            gridView1.AddNewRow();
            gridView1.AddNewRow();
            gridView1.AddNewRow();
            gridView1.AddNewRow();
            gridView1.AddNewRow();
            gridView1.AddNewRow();
            gridView1.AddNewRow();
            gridView1.AddNewRow();
            gridView1.AddNewRow();
            gridView1.AddNewRow();

            gridView1.FocusedRowHandle = iFocRow;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column != gridColchoose)
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridColchoose, true);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
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

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                long iID = ReturnLong(gridView1.GetRowCellValue(e.FocusedRowHandle, gridColiID));
                if (iID == 0)
                {
                    gridColcCode.OptionsColumn.AllowEdit = true;
                    gridColcName.OptionsColumn.AllowEdit = true;
                }
                else
                {
                    gridColcCode.OptionsColumn.AllowEdit = false;
                    gridColcName.OptionsColumn.AllowEdit = false;
                }
            }
            catch { }
        }
    }
}
