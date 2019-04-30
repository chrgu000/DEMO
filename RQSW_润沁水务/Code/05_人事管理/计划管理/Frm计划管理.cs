using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;

namespace 人事管理
{
    public partial class Frm计划管理 : 系统服务.FrmBaseInfo
    {
        string tablename = "SAPlan";
        string tableid = "iID";

        public Frm计划管理()
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
            DialogResult result = MessageBox.Show("是否删除?", "删除提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                string sErr = "";

                aList = new System.Collections.ArrayList();
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellDisplayText(i, gridColiID).ToString().Trim() == "")
                    {
                        continue;
                    }
                    if (gridView1.IsRowSelected(i))
                    {
                        string sID = gridView1.GetRowCellValue(i, gridColiID).ToString().Trim();

                        sSQL = "delete " + tablename + " where " + tableid + " = '" + sID + "' ";
                        aList.Add(sSQL);
                    }
                }
                if (sErr.Trim().Length > 0)
                {
                    MsgBox("删除失败", sErr);
                }
                else
                {
                    if (aList.Count > 0)
                    {
                        int iCou = clsSQLCommond.ExecSqlTran(aList);
                        MessageBox.Show("删除成功！\n合计执行语句:" + iCou + "条");
                        GetGrid();
                    }
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
                gridView1.FocusedColumn = gridColiID;
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
                gridView1.Focus();
            }
            catch { }
            sSQL = "select * from " + tablename + " where 1=-1";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            string sErr = "";

            if (dateEdit1.Text.Trim() == "" || dateEdit2.Text.Trim() == "")
            {
                sErr = sErr + "计划日期不能为空\n";
            }
            if (lookUpEdit年.EditValue == null || lookUpEdit年.Text.Trim() == "")
            {
                sErr = sErr + "年不能为空\n";
            }

            aList = new System.Collections.ArrayList();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "update" || gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "add")
                {
                    #region 生成table
                    DataRow dr = dt.NewRow();

                    if (lookUpEdit计划类型.Text.Trim() == "")
                    {
                        sErr = sErr + "计划类型不能为空\n";
                        continue;
                    }

                    if (lookUpEdit月.Enabled&& lookUpEdit月.Text.Trim() == "")
                    {
                        sErr = sErr + "计划类型月份不能为空\n";
                        continue;
                    }
                    if (lookUpEdit周.Enabled &&  lookUpEdit周.Text.Trim() == "")
                    {
                        sErr = sErr + "计划类型周不能为空\n";
                        continue;
                    }
                    

                    if (gridView1.GetRowCellValue(i, gridColS1).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + gridColS1.Caption + "不能为空\n";
                        continue;
                    }
                    if (gridView1.GetRowCellValue(i, gridColS3).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + gridColS3.Caption + "不能为空\n";
                        continue;
                    }
                    //if (gridView1.GetRowCellValue(i, gridColD1) == null || gridView1.GetRowCellValue(i, gridColD1).ToString().Trim() == "")
                    //{
                    //    sErr = sErr + "行" + (i + 1) + gridColD1.Caption + "不能为空\n";
                    //    continue;
                    //}
                    if (ReturnDecimal(gridView1.GetRowCellValue(i, gridColD1)) < 0)
                    {
                        sErr = sErr + "行" + (i + 1) + gridColD1.Caption + "不能小于等于0\n";
                        continue;
                    }
                    //if (gridView1.GetRowCellValue(i, gridColD2) == null || gridView1.GetRowCellValue(i, gridColD2).ToString().Trim() == "")
                    //{
                    //    sErr = sErr + "行" + (i + 1) + gridColD2.Caption + "不能为空\n";
                    //    continue;
                    //}
                    if (ReturnDecimal(gridView1.GetRowCellValue(i, gridColD2)) < 0)
                    {
                        sErr = sErr + "行" + (i + 1) + gridColD2.Caption + "不能小于等于0\n";
                        continue;
                    }

                    if (gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() != "")
                    {
                        dr["iID"] = gridView1.GetRowCellValue(i, gridColiID).ToString().Trim();
                    }
                    dr["S1"] = gridView1.GetRowCellValue(i, gridColS1).ToString().Trim();
                    //dr["S2"] = gridView1.GetRowCellValue(i, gridColS1_1).ToString().Trim();
                    dr["S3"] = gridView1.GetRowCellValue(i, gridColS3).ToString().Trim();
                    //dr["S4"] = gridView1.GetRowCellValue(i, gridColS3_1).ToString().Trim();

                    dr["S5"] = lookUpEdit年.EditValue.ToString().Trim();
                    dr["S6"] = gridView1.GetRowCellValue(i, gridColS6).ToString().Trim();
                    dr["S7"] = gridView1.GetRowCellValue(i, gridColS7).ToString().Trim();
                    dr["S8"] = gridView1.GetRowCellValue(i, gridColS8).ToString().Trim();
                    dr["S9"] = gridView1.GetRowCellValue(i, gridColS9).ToString().Trim();
                    dr["S10"] = gridView1.GetRowCellValue(i, gridColS10).ToString().Trim();

                    if (dateEdit1.Text.Trim() != "")
                    {
                        dr["Date1"] = dateEdit1.DateTime.ToString("yyyy-MM-dd");
                    }
                    if (dateEdit2.Text.Trim() != "")
                    {
                        dr["Date2"] = dateEdit2.DateTime.ToString("yyyy-MM-dd");
                    }
                    //if (gridView1.GetRowCellValue(i, gridColDate1).ToString().Trim() != "")
                    //{
                    //    dr["Date1"] = gridView1.GetRowCellValue(i, gridColDate1).ToString().Trim();
                    //}
                    //if (gridView1.GetRowCellValue(i, gridColDate2).ToString().Trim() != "")
                    //{
                    //    dr["Date2"] = gridView1.GetRowCellValue(i, gridColDate2).ToString().Trim();
                    //}
                    if (gridView1.GetRowCellValue(i, gridColDate3).ToString().Trim() != "")
                    {
                        dr["Date3"] = gridView1.GetRowCellValue(i, gridColDate3).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridColDate4).ToString().Trim() != "")
                    {
                        dr["Date4"] = gridView1.GetRowCellValue(i, gridColDate4).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridColDate5).ToString().Trim() != "")
                    {
                        dr["Date5"] = gridView1.GetRowCellValue(i, gridColDate5).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridColDate6).ToString().Trim() != "")
                    {
                        dr["Date6"] = gridView1.GetRowCellValue(i, gridColDate6).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridColD1).ToString().Trim() != "")
                    {
                        dr["D1"] = ReturnDecimal(gridView1.GetRowCellValue(i, gridColD1));
                    }
                    if (gridView1.GetRowCellValue(i, gridColD2).ToString().Trim() != "")
                    {
                        dr["D2"] = ReturnDecimal(gridView1.GetRowCellValue(i, gridColD2));
                    }
                    if (gridView1.GetRowCellValue(i, gridColD3).ToString().Trim() != "")
                    {
                        dr["D3"] = ReturnDecimal(gridView1.GetRowCellValue(i, gridColD3));
                    }
                    if (gridView1.GetRowCellValue(i, gridColD4).ToString().Trim() != "")
                    {
                        dr["D4"] = ReturnDecimal(gridView1.GetRowCellValue(i, gridColD4));
                    }
                    if (gridView1.GetRowCellValue(i, gridColD5).ToString().Trim() != "")
                    {
                        dr["D5"] = ReturnDecimal(gridView1.GetRowCellValue(i, gridColD5));
                    }
                    if (gridView1.GetRowCellValue(i, gridColD6).ToString().Trim() != "")
                    {
                        dr["D6"] = ReturnDecimal(gridView1.GetRowCellValue(i, gridColD6));
                    }
                    if (gridView1.GetRowCellValue(i, gridColD7).ToString().Trim() != "")
                    {
                        dr["D7"] = ReturnDecimal(gridView1.GetRowCellValue(i, gridColD7));
                    }
                    if (gridView1.GetRowCellValue(i, gridColD8).ToString().Trim() != "")
                    {
                        dr["D8"] = ReturnDecimal(gridView1.GetRowCellValue(i, gridColD8));
                    }
                    if (gridView1.GetRowCellValue(i, gridColD9).ToString().Trim() != "")
                    {
                        dr["D9"] = ReturnDecimal(gridView1.GetRowCellValue(i, gridColD9));
                    }
                    if (gridView1.GetRowCellValue(i, gridColD10).ToString().Trim() != "")
                    {
                        dr["D10"] = ReturnDecimal(gridView1.GetRowCellValue(i, gridColD10));
                    }
                    //if (gridView1.GetRowCellValue(i, gridColI1).ToString().Trim() != "")
                    //{
                    //    dr["I1"] = ReturnInt(gridView1.GetRowCellValue(i, gridColI1));
                    //}
                    //if (gridView1.GetRowCellValue(i, gridColI2).ToString().Trim() != "")
                    //{
                    //    dr["I2"] = ReturnInt(gridView1.GetRowCellValue(i, gridColI2));
                    //}
                    //if (gridView1.GetRowCellValue(i, gridColI3).ToString().Trim() != "")
                    //{
                    //    dr["I3"] = ReturnInt(gridView1.GetRowCellValue(i, gridColI3));
                    //}
                    if (lookUpEdit计划类型.Text.Trim() != "")
                    {
                        dr["I1"] = ReturnInt(lookUpEdit计划类型.EditValue);
                    }
                    if (lookUpEdit月.Text.Trim() != "")
                    {
                        dr["I2"] = ReturnInt(lookUpEdit月.EditValue);
                    }
                    if (lookUpEdit周.Text.Trim() != "")
                    {
                        dr["I3"] = ReturnInt(lookUpEdit周.EditValue);
                    }
                    if (gridView1.GetRowCellValue(i, gridColI4).ToString().Trim() != "")
                    {
                        dr["I4"] = ReturnInt(gridView1.GetRowCellValue(i, gridColI4));
                    }
                    if (gridView1.GetRowCellValue(i, gridColI5).ToString().Trim() != "")
                    {
                        dr["I5"] = ReturnInt(gridView1.GetRowCellValue(i, gridColI5));
                    }
                    if (gridView1.GetRowCellValue(i, gridColI6).ToString().Trim() != "")
                    {
                        dr["I6"] = ReturnInt(gridView1.GetRowCellValue(i, gridColI6));
                    }
                    dt.Rows.Add(dr);
                    #endregion

                    if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "update")
                    {
                        sSQL = clsGetSQL.GetUpdateSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablename, dt, dt.Rows.Count - 1);
                        aList.Add(sSQL);
                    }
                    if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "add")
                    {
                        sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablename, dt, dt.Rows.Count - 1);
                        aList.Add(sSQL);
                    }
                }
            }

            if (sErr.Trim().Length > 0)
            {
                throw new Exception(sErr);
            }

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("保存成功！\n合计执行语句:" + iCou + "条");
                GetGrid();
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

        private void Frm计划管理_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookUpEdit();

                lookUpEdit年.EditValue = DateTime.Now.Year.ToString();
            }
            catch (Exception ee)
            {
                throw new Exception("加载窗体失败\n" + ee.Message);
            }
        }

        private void SetLookUpEdit()
        {
            系统服务.LookUp.Person(ItemLookUpEdit业务员);
            系统服务.LookUp.Department(ItemLookUpEdit部门);
            系统服务.LookUp._LoopUpData(lookUpEdit计划类型, "18");
            系统服务.LookUp._LoopUpData(lookUpEdit月, "19");
            系统服务.LookUp._LoopUpData(lookUpEdit周, "20");
            系统服务.LookUp.Year(lookUpEdit年);
        }

        private void GetGrid()
        {
            string sErr = "";
            if (lookUpEdit年.EditValue == null || lookUpEdit年.Text.Trim() == "")
            {
                sErr = sErr + "年不能为空\n";
            }
            if (lookUpEdit计划类型.Text.Trim() == "")
            {
                sErr = sErr + "计划类型不能为空\n";
            }
            if (lookUpEdit月.Enabled && lookUpEdit月.Text.Trim() == "")
            {
                sErr = sErr + "计划类型月份不能为空\n";
            }
            if (lookUpEdit周.Enabled && lookUpEdit周.Text.Trim() == "")
            {
                sErr = sErr + "计划类型周不能为空\n";
            }
            //if (sErr.Trim().Length > 0)
            //{
            //    throw new Exception(sErr);
            //}
            if (sErr == "")
            {
                int iFocRow = 0;
                if (gridView1.FocusedRowHandle > 0)
                    iFocRow = gridView1.FocusedRowHandle;

                string sSQL = "select *, 'update' as iSave from dbo." + tablename + " where 1=1 and s5 = '" + lookUpEdit年.Text.Trim() + "' ";

                //if (dateEdit1.Text.Trim() != "")
                //{
                //    sSQL = sSQL + " and Date1 >= '" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "' ";
                //}
                //if (dateEdit2.Text.Trim() != "")
                //{
                //    sSQL = sSQL + " and Date2 <= '" + dateEdit2.DateTime.ToString("yyyy-MM-dd") + "' ";
                //}
                if (lookUpEdit计划类型.Text.Trim() != "")
                {
                    sSQL = sSQL + " and i1 = '" + lookUpEdit计划类型.EditValue.ToString().Trim() + "' ";
                }
                if (lookUpEdit月.Text.Trim() != "")
                {
                    sSQL = sSQL + " and i2 = '" + lookUpEdit月.EditValue.ToString().Trim() + "' ";
                }
                if (lookUpEdit周.Text.Trim() != "")
                {
                    sSQL = sSQL + " and i3 = '" + lookUpEdit周.EditValue.ToString().Trim() + "' ";
                }

                sSQL = sSQL + " order by  iID";
                dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
                if (dtBingGrid.Rows.Count > 0)
                {
                    dateEdit1.EditValue = dtBingGrid.Rows[0]["Date1"].ToString();
                    dateEdit2.EditValue = dtBingGrid.Rows[0]["Date2"].ToString();
                }
                else
                {
                    sSQL = @"
SELECT  b.iID, a.DeptID as S1, b.S2, a.PersonCode as S3, b.S4, b.S5, b.S6, b.S7, b.S8, b.S9, b.S10, b.D1, b.D2, b.D3, b.D4, b.D5, b.D6, b.D7, b.D8, b.D9, b.D10, b.I1, b.I2, b.I3, b.I4, b.I5, b.I6, b.Date1, b.Date2, b.Date3, b.Date4, b.Date5, b.Date6, 
                      b.SysCreateDate , 'add' as iSave
FROM      Person    a left join  (select * from SAPlan where 1=-1) b on a.PersonCode=b.S3 where DeptID like '03%' and a.S6='1'";
                    dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
                    dateEdit1.EditValue = "";
                    dateEdit2.EditValue = "";
                }
                gridControl1.DataSource = dtBingGrid;

                gridView1.AddNewRow();
                gridView1.OptionsBehavior.Editable = false;
                sState = "sel";
            }
            else
            {
                sSQL = "select *, 'update' as iSave from dbo." + tablename + " where 1=-1 ";
                dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
                gridControl1.DataSource = dtBingGrid;
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int iRow = 0;
            if (gridView1.FocusedRowHandle >= 0)
                iRow = gridView1.FocusedRowHandle;
            try
            {
                if (e.Column == gridColS1 && gridView1.GetRowCellValue(iRow, gridColS1).ToString().Trim() != "")
                {
                    gridView1.SetRowCellValue(iRow, gridColS1_1, gridView1.GetRowCellValue(iRow, gridColS1));
                    if (gridView1.GetRowCellDisplayText(iRow, gridColS1_1).ToString().Trim() == "")
                    {
                        gridView1.SetRowCellValue(iRow, gridColS1, "");
                    }
                }

                if (e.Column == gridColS3 && gridView1.GetRowCellValue(iRow, gridColS3).ToString().Trim() != "")
                {
                    gridView1.SetRowCellValue(iRow, gridColS3_1, gridView1.GetRowCellValue(iRow, gridColS3).ToString().Trim());
                    if (gridView1.GetRowCellDisplayText(iRow, gridColS3_1).ToString().Trim() == "")
                    {
                        gridView1.SetRowCellValue(iRow, gridColS3, "");
                    }
                }

                if (e.Column != gridColiSave && gridView1.GetRowCellDisplayText(iRow, gridColiSave).ToString().Trim() == "")
                {
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridColiSave, "add");
                }
                if (e.Column != gridColiSave && gridView1.GetRowCellDisplayText(iRow, gridColiSave).ToString().Trim() == "edit")
                {
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridColiSave, "update");
                }
                if (e.Column == gridColD5 && iRow == gridView1.RowCount - 1 && gridView1.GetRowCellDisplayText(iRow, gridColD5).ToString().Trim() != "")
                {
                    gridView1.AddNewRow();
                    gridView1.FocusedRowHandle = iRow;
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

        private void ItemButtonEdit部门_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(3);
            if (DialogResult.OK == frm.ShowDialog())
            {
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridColS1, frm.sID);
                
                frm.Enabled = true;
            }
        }

        private void ItemButtonEdit业务员_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(2);
            if (DialogResult.OK == frm.ShowDialog())
            {
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridColS3, frm.sID);
                if (frm.sID != "")
                {
                    DataTable dt = 系统服务.LookUp.PersonDepartment(frm.sID.Trim());
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridColS1, dt.Rows[0]["cDepCode"]);
                    }
                }
                frm.Enabled = true;
            }
        }

        private void lookUpEdit计划类型_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEdit计划类型.EditValue.ToString().Trim() == "1")
            {
                lookUpEdit月.EditValue = DBNull.Value;
                lookUpEdit月.Enabled = false;
                lookUpEdit周.EditValue = DBNull.Value;
                lookUpEdit周.Enabled = false;
            }
            if (lookUpEdit计划类型.EditValue.ToString().Trim() == "2")
            {
                lookUpEdit月.EditValue = DBNull.Value;
                lookUpEdit月.Enabled = true;
                lookUpEdit周.EditValue = DBNull.Value;
                lookUpEdit周.Enabled = false;
            }

            if (lookUpEdit计划类型.EditValue.ToString().Trim() == "3")
            {
                lookUpEdit月.EditValue = DBNull.Value;
                lookUpEdit月.Enabled = true;
                lookUpEdit周.EditValue = "";
                lookUpEdit周.Enabled = true;
            }
            //if (lookUpEdit计划类型.Text.Trim() != "" && lookUpEdit月.Text.Trim() != "")
            //{
            //    if (lookUpEdit计划类型.EditValue.ToString().Trim() == "3" && lookUpEdit周.Text.Trim() == "")
            //    {
            //        return;
            //    }
                
            //}
            btnRefresh();
        }

        private void lookUpEdit月_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEdit计划类型.Text.Trim() != "" && lookUpEdit月.Text.Trim() != "")
            {
                if (lookUpEdit计划类型.EditValue.ToString().Trim() == "3" && lookUpEdit周.Text.Trim() == "")
                {
                    return;
                }
                btnRefresh();
            }
        }

        private void lookUpEdit周_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEdit计划类型.Text.Trim() != "" && lookUpEdit月.Text.Trim() != "")
            {
                if (lookUpEdit计划类型.EditValue.ToString().Trim() == "3" && lookUpEdit周.Text.Trim() != "")
                {
                    btnRefresh();
                }
                
            }
        }

        private void dateEdit2_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEdit年.EditValue = dateEdit2.DateTime.Year;
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {

            lookUpEdit年.EditValue = dateEdit1.DateTime.Year;
        }

        private void lookUpEdit年_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                btnRefresh();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
