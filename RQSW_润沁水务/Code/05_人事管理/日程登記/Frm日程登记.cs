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
    public partial class Frm日程登记 : 系统服务.FrmBaseInfo
    {
        string tablename = "日程安排";

        public Frm日程登记()
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
            //string sErr = "";
            //OpenFileDialog oFile = new OpenFileDialog();
            //oFile.Filter = "Excel文件2003|*.xls|Excel文件2007|*.xlsx";
            //if (oFile.ShowDialog() == DialogResult.OK)
            //{
            //    string sFilePath = oFile.FileName;
            //    string sSQL = "select 员工工号 as PerNO,姓名拼音 as NamePY,姓名 as Name,状态 as State,岗位 as Post,级别 as Levels,类型 as PerType,备注 as Remark,null as tstamp,null as iSave from [生产员工$]";
            //    DataTable dtExcel = clsExcel.ExcelToDT(sFilePath, sSQL, true);

            //    for (int i = 0; i < dtExcel.Rows.Count; i++)
            //    {
            //        string sPerNO = dtExcel.Rows[i]["PerNO"].ToString().Trim();
            //        DataRow[] dr = dtBingGrid.Select("PerNO = '" + sPerNO + "'");
            //        if (dr.Length > 0)
            //        {
            //            dtExcel.Rows[i]["tstamp"] = dr[0]["tstamp"];
            //            sErr = sErr + sPerNO + "\n";
            //        }
            //        string sName = dtExcel.Rows[i]["Name"].ToString().Trim();
            //        DataRow[] dr2 = dtBingGrid.Select("Name = '" + sName + "'");
            //        if (dr2.Length > 0)
            //        {
            //            dtExcel.Rows[i]["tstamp"] = dr2[0]["tstamp"];
            //            sErr = sErr + sName + "\n";
            //        }
            //    }

            //    gridControl1.DataSource = dtExcel;
                
            //    if (sErr.Length > 0)
            //    {
            //        sErr = "以下工号已经存在，不能重复导入：\n" + sErr;
            //        throw new Exception(sErr);
            //    }
            //}
            //else
            //{
            //    throw new Exception("取消导入");
            //}
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
            gridView1.OptionsBehavior.ReadOnly = false;
            gridView1.OptionsBehavior.Editable = true;

            buttonEdit业务员.Enabled = true;
            SetEnabled(true);

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
                    if (gridView1.GetRowCellDisplayText(i, gridCol序号).ToString().Trim() == "")
                    {
                        continue;
                    }
                    if (gridView1.IsRowSelected(i))
                    {
                        string sID = gridView1.GetRowCellValue(i, gridCol序号).ToString().Trim();

                        sSQL = "select count(1) from dbo.ComputationUnitGroup where cComunitCode = '" + sID + "' or cAuxComunitCode = '" + sID + "'";
                        long iCou1 = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                        if (iCou1 > 0)
                        {
                            sErr = "行" + (i + 1).ToString() + " 计量单位 " + sID + " 已经使用不能删除\n";
                            continue;
                        } 

                        //sSQL = "delete " + tablename + " where " + tableid + " = '" + sID + "' ";
                        //aList.Add(sSQL);
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
            sState = "del";
        }


        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave()
        {
            try
            {
                gridView1.FocusedColumn = gridCol序号;
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
                gridView1.Focus();
            }
            catch { }
            sSQL = "select * from " + tablename + " where 1=-1";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            string sErr = "";

            sSQL = "select isnull(max(iID)+1,1) as iID from " + tablename;
            long iID = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));

            aList = new System.Collections.ArrayList();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "update" || gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "add")
                {
                    #region 判断
                    if (gridView1.GetRowCellValue(i, gridCol登记部门).ToString().Trim() == "" && gridView1.GetRowCellValue(i, gridCol技术员编码).ToString().Trim() == "")
                    {
                        continue;
                    }

                    if (gridView1.GetRowCellValue(i, gridCol技术员编码).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + gridCol技术员编码.Caption + "不能为空\n";
                        continue;
                    }
                    if (gridView1.GetRowCellValue(i, gridCol登记部门).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + gridCol登记部门.Caption + "不能为空\n";
                        continue;
                    }
                    if (gridView1.GetRowCellValue(i, gridCol开始日期).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + gridCol开始日期.Caption + "不能为空\n";
                        continue;
                    }
                    if (gridView1.GetRowCellValue(i, gridCol结束日期).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + gridCol结束日期.Caption + "不能为空\n";
                        continue;
                    }
                    #endregion

                    #region 判断是否重复

                    DateTime d1 = Convert.ToDateTime(gridView1.GetRowCellValue(i, gridCol开始日期));
                    DateTime d2 = Convert.ToDateTime(gridView1.GetRowCellValue(i, gridCol结束日期));
                    string s技术员 = gridView1.GetRowCellValue(i, gridCol技术员编码).ToString().Trim();
                    if (d2 < d1)
                    {
                        sErr = sErr + "行" + (i + 1) + gridCol结束日期.Caption + "不能早于开始日期\n";
                        continue;
                    }
                    for (int j = i+1; j < gridView1.RowCount; j++)
                    {
                        if (gridView1.GetRowCellValue(j, gridCol登记部门).ToString().Trim() == "")
                        {
                            continue;
                        }
                        string s技术员2 = gridView1.GetRowCellValue(j, gridCol技术员编码).ToString().Trim();

                        DateTime d11 = Convert.ToDateTime(gridView1.GetRowCellValue(j, gridCol开始日期));
                        DateTime d21 = Convert.ToDateTime(gridView1.GetRowCellValue(j, gridCol结束日期));
                        if (d11 < d2 && s技术员 == s技术员2)
                        {
                            sErr = sErr + "行" + (i + 1) + "开始日期不能早于上行结束日期\n";
                            continue;
                        }
                    }
                    #endregion

                    #region 生成table
                    DataRow dr = dt.NewRow();

                    if (gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() != "")
                    {
                        dr["iID"] = gridView1.GetRowCellValue(i, gridColiID).ToString().Trim();
                    }
                    dr["技术员"] = gridView1.GetRowCellValue(i, gridCol技术员编码).ToString().Trim();
                    dr["登记部门"] = gridView1.GetRowCellValue(i, gridCol登记部门编码).ToString().Trim();
                    dr["开始日期"] = gridView1.GetRowCellValue(i, gridCol开始日期).ToString().Trim();
                    dr["结束日期"] = gridView1.GetRowCellValue(i, gridCol结束日期).ToString().Trim();
                    dr["备注"] = gridView1.GetRowCellValue(i, gridCol备注).ToString().Trim();

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

        private void Frm日程登记_Load(object sender, EventArgs e)
        {
            try
            {
                dateEdit1.Text = DateTime.Now.ToString("yyyy-MM-" + "01");
                dateEdit2.Text = DateTime.Parse((DateTime.Now.AddMonths(1).ToString("yyyy-MM-" + "01"))).AddDays(-1).ToString("yyyy-MM-dd");

                SetEnabled(false);
                SetLookUpEdit();
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

            string sSQL = "select *, 'edit' as iSave from dbo." + tablename + " where 开始日期 >= '" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "' and 结束日期 <= '" + dateEdit2.DateTime.ToString("yyyy-MM-dd") + "'";
            if (buttonEdit业务员.EditValue != null && buttonEdit业务员.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and 技术员 = '" + buttonEdit业务员.EditValue.ToString() + "' ";
            }

            sSQL = sSQL + " order by  iID";
            dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dtBingGrid;

            gridView1.AddNewRow();
            gridView1.OptionsBehavior.Editable = false;
            sState = "sel";
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == gridCol登记部门编码 && gridView1.GetRowCellValue(e.RowHandle, gridCol登记部门编码).ToString().Trim() != "")
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridCol登记部门, gridView1.GetRowCellValue(e.RowHandle, gridCol登记部门编码).ToString().Trim());
                    if (gridView1.GetRowCellDisplayText(e.RowHandle, gridCol登记部门).ToString().Trim() == "")
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridCol登记部门编码, "");
                    }
                }

                if (e.Column == gridCol技术员编码 && gridView1.GetRowCellValue(e.RowHandle, gridCol技术员编码).ToString().Trim() != "")
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridCol技术员, gridView1.GetRowCellValue(e.RowHandle, gridCol技术员编码).ToString().Trim());
                    if (gridView1.GetRowCellDisplayText(e.RowHandle, gridCol技术员).ToString().Trim() == "")
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridCol技术员编码, "");
                    }
                }

                if (e.Column != gridColiSave && gridView1.GetRowCellDisplayText(e.RowHandle, gridColiSave).ToString().Trim() == "")
                {
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridColiSave, "add");
                }
                if (e.Column != gridColiSave && gridView1.GetRowCellDisplayText(e.RowHandle, gridColiSave).ToString().Trim() == "edit")
                {
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridColiSave, "update");
                }
                if ((e.Column == gridCol登记部门 || e.Column == gridCol技术员编码) && e.RowHandle == gridView1.RowCount - 1 && gridView1.GetRowCellDisplayText(e.RowHandle, gridCol序号).ToString().Trim() != "")
                {
                    int iRow = gridView1.FocusedRowHandle;
                    gridView1.AddNewRow();
                    gridView1.FocusedRowHandle = iRow;
                }

                if (e.Column == gridCol技术员编码)
                {
                    if (gridView1.GetRowCellDisplayText(e.RowHandle, gridCol技术员).ToString().Trim() == "" && gridView1.GetRowCellDisplayText(e.RowHandle, gridCol技术员编码).ToString().Trim() != "")
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridCol技术员编码, "");
                    }
                }

                if (e.Column == gridCol登记部门编码)
                {
                    if (gridView1.GetRowCellDisplayText(e.RowHandle, gridCol登记部门).ToString().Trim() == "" && gridView1.GetRowCellDisplayText(e.RowHandle, gridCol登记部门编码).ToString().Trim() != "")
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridCol登记部门编码, "");
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView1.RowCount > 0)
                    iRow = gridView1.FocusedRowHandle;
                try
                {
                    string sUpdate = gridView1.GetRowCellValue(iRow, gridColiSave).ToString().Trim();
                    if (sUpdate == "" || sUpdate == "add")
                    {
                        gridCol序号.OptionsColumn.AllowEdit = true;
                    }
                    else
                    {
                        gridCol序号.OptionsColumn.AllowEdit = false;
                    }
                }
                catch { }

                if (gridView1.GetRowCellValue(iRow, gridColiSave) != null && (gridView1.GetRowCellValue(iRow, gridColiSave).ToString().Trim() == "add" || gridView1.GetRowCellValue(iRow, gridColiSave).ToString().Trim() == ""))
                {
                    gridCol登记部门编码.OptionsColumn.AllowEdit = true;
                    gridCol技术员编码.OptionsColumn.AllowEdit = true;
                    gridCol开始日期.OptionsColumn.AllowEdit = true;
                    gridCol结束日期.OptionsColumn.AllowEdit = true;
                    gridCol备注.OptionsColumn.AllowEdit = true;
                }
                else
                {
                    if (sState == "edit")
                    {
                        if (gridView1.GetRowCellValue(iRow, gridColiSave).ToString().Trim() != "")
                        {
                            DateTime d1 = Convert.ToDateTime(gridView1.GetRowCellValue(iRow, gridCol开始日期));
                            DateTime d2 = Convert.ToDateTime(gridView1.GetRowCellValue(iRow, gridCol结束日期));
                            if (d1 < DateTime.Now)
                            {
                                gridCol登记部门编码.OptionsColumn.AllowEdit = false;
                                gridCol技术员编码.OptionsColumn.AllowEdit = false;
                                gridCol开始日期.OptionsColumn.AllowEdit = false;
                                gridCol结束日期.OptionsColumn.AllowEdit = true;
                                gridCol备注.OptionsColumn.AllowEdit = true;
                            }
                            if (d2 < DateTime.Now)
                            {
                                gridCol登记部门编码.OptionsColumn.AllowEdit = false;
                                gridCol技术员编码.OptionsColumn.AllowEdit = false;
                                gridCol开始日期.OptionsColumn.AllowEdit = false;
                                gridCol结束日期.OptionsColumn.AllowEdit = false;
                                gridCol备注.OptionsColumn.AllowEdit = false;
                            }
                            if (d1 > DateTime.Now && d2 > DateTime.Now)
                            {
                                gridCol技术员编码.OptionsColumn.AllowEdit = false;
                                gridCol登记部门编码.OptionsColumn.AllowEdit = true;
                                gridCol开始日期.OptionsColumn.AllowEdit = true;
                                gridCol结束日期.OptionsColumn.AllowEdit = true;
                                gridCol备注.OptionsColumn.AllowEdit = true;
                            }
                        }
                    }
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

        private void buttonEdit业务员_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(2);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit业务员.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit业务员_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit业务员.Text.Trim() != "")
            {
                lookUpEdit业务员.EditValue = buttonEdit业务员.Text.Trim();
                GetGrid();
            }
            else
                lookUpEdit业务员.EditValue = null;
        }

        private void buttonEdit业务员_Leave(object sender, EventArgs e)
        {
            if (buttonEdit业务员.Text.Trim() == "")
                return;
            if (lookUpEdit业务员.Text.Trim() == "")
            {
                buttonEdit业务员.Text = "";
                buttonEdit业务员.Focus();
            }
        }

        private void SetLookUpEdit()
        {
            系统服务.LookUp.Person(lookUpEdit业务员);
            系统服务.LookUp.Department(ItemLookUpEdit部门);
            系统服务.LookUp.Person(ItemLookUpEdit技术员);
        }

        private void ItemButtonEdit部门_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int iRow = 0;
            if (gridView1.RowCount > 0)
                iRow = gridView1.FocusedRowHandle;

            系统服务.Frm参照 frm = new 系统服务.Frm参照(3);
            if (DialogResult.OK == frm.ShowDialog())
            {
                gridView1.SetRowCellValue(iRow, gridCol登记部门编码, frm.sID);
                gridView1.SetRowCellValue(iRow, gridCol登记部门, frm.sID);
                frm.Enabled = true;
            }
        }

        private void SetEnabled(bool b)
        {
            lookUpEdit业务员.Enabled = false;
            buttonEdit业务员.Enabled = true;
            gridView1.FocusedRowHandle = iFocRow;
            gridView1.OptionsBehavior.Editable = b;
            gridCol登记部门编码.OptionsColumn.AllowEdit = b;
            gridCol登记部门.OptionsColumn.AllowEdit = false;
            gridCol开始日期.OptionsColumn.AllowEdit = b;
            gridCol结束日期.OptionsColumn.AllowEdit = b;
        }

        private void ItemButtonEdit技术员_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int iRow = 0;
            if (gridView1.RowCount > 0)
                iRow = gridView1.FocusedRowHandle;

            系统服务.Frm参照 frm = new 系统服务.Frm参照(2);
            if (DialogResult.OK == frm.ShowDialog())
            {
                gridView1.SetRowCellValue(iRow, gridCol技术员编码, frm.sID);
                gridView1.SetRowCellValue(iRow, gridCol技术员, frm.sID);
                frm.Enabled = true;
            }
        }
    }
}
