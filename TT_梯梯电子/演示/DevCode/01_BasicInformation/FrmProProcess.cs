using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;

namespace BasicInformation
{
    public partial class FrmProProcess : FrameBaseFunction.Frm列表窗体模板
    {
        public FrmProProcess()
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
            string sErr = "";
            OpenFileDialog oFile = new OpenFileDialog();
            oFile.Filter = "Excel文件2003|*.xls|Excel文件2007|*.xlsx";
            if (oFile.ShowDialog() == DialogResult.OK)
            {
                string sFilePath = oFile.FileName;
                string sSQL = "select 母件顺序,产品编码,物料编码,半成品编码,逻辑顺序,加工顺序,设备,组别,内部流转,工序,'' as 开工排序,数量,单位工时,开工时间,间隔时间,作业人员数量,下道工序,下一班组,完工入库,1 as State,null as Remark,null as tstamp,null as iSave from [工时工序明细总表$]";
                //  where 产品编码 <> '' and 物料编码 <> '' order by 产品编码,母件顺序,物料编码,加工顺序

                //string sSQL = "select * from [工时工序明细总表$]";
                DataTable dtExcel = clsExcel.ExcelToDT(sFilePath, sSQL, true);

                string s母件编码 = lookUpEdit产品编码.EditValue.ToString().Trim();
                
                for (int i = 0; i < dtExcel.Rows.Count; i++)
                {
                    if (dtExcel.Rows[i]["产品编码"].ToString().Trim() == "")
                        continue;

                    if (dtExcel.Rows[i]["产品编码"].ToString().Trim() != s母件编码)
                    {
                        throw new Exception("不支持多个产品导入，请修改后继续");
                    }
                }
                gridControl1.DataSource = dtExcel;

                sState = "import";

                if (sErr.Length > 0)
                {
                    MsgBox("提示", sErr);
                }
            }
            else
            {
                throw new Exception("取消导入");
            }
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
            string sErr = "";
            string sErrInfo = "";
            for (int iRow = gridView1.RowCount - 1; iRow >= 0; iRow--)
            {
                if (gridView1.IsRowSelected(iRow))
                {
                    //if (!CheckCanDel(gridView1.GetRowCellValue(iRow, gridColWorkProcessNO).ToString().Trim(), out sErrInfo))
                    //{
                    //    sErr = sErr + "工序:" + gridView1.GetRowCellValue(iRow, gridColWorkProcessNO).ToString().Trim() + "  " + gridView1.GetRowCellValue(iRow, gridColWorkProcess).ToString().Trim() + sErr + "\n";
                    //}
                }
            }

            if (sErr.Length > 0)
            {
                MsgBox("工序已经使用不能删除", sErr);
                return;
            }
            DialogResult d = MessageBox.Show("确定删除选中的 " + gridView1.SelectedRowsCount + " 行工序么？\n是：继续\n否：取消", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (d != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            aList = new System.Collections.ArrayList();
            for (int i = gridView1.RowCount - 1; i >= 0; i--)
            {
                if (gridView1.IsRowSelected(i))
                {
                    sSQL = "select * from dbo.ProProcess where 1=-1";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    DataRow dr = dt.NewRow();
                    dr["母件顺序"] = gridView1.GetRowCellValue(i, gridCol母件顺序).ToString().Trim();
                    dr["产品编码"] = gridView1.GetRowCellValue(i, gridCol产品编码).ToString().Trim();
                    dr["物料编码"] = gridView1.GetRowCellValue(i, gridCol物料编码).ToString().Trim();
                    dr["半成品编码"] = gridView1.GetRowCellValue(i, gridCol半成品编码).ToString().Trim();
                    dr["逻辑顺序"] = gridView1.GetRowCellValue(i, gridCol逻辑顺序).ToString().Trim();
                    dr["加工顺序"] = gridView1.GetRowCellValue(i, gridCol加工顺序).ToString().Trim();
                    dr["设备"] = gridView1.GetRowCellValue(i, gridCol设备).ToString().Trim();
                    dr["组别"] = gridView1.GetRowCellValue(i, gridCol组别).ToString().Trim();
                    if (gridView1.GetRowCellValue(i, gridCol内部流转).ToString().Trim() == string.Empty)
                    {
                        dr["内部流转"] = 0;
                    }
                    else
                    {
                        dr["内部流转"] = Convert.ToDecimal(gridView1.GetRowCellValue(i, gridCol内部流转));
                    }
                    dr["工序"] = gridView1.GetRowCellValue(i, gridCol工序).ToString().Trim();
                    if (gridView1.GetRowCellValue(i, gridCol单位工时).ToString().Trim() != string.Empty)
                    {
                        dr["单位工时"] = Convert.ToDecimal(gridView1.GetRowCellValue(i, gridCol单位工时));
                    }
                    if (gridView1.GetRowCellValue(i, gridCol间隔时间).ToString().Trim() != string.Empty)
                    {
                        dr["间隔时间"] = Convert.ToDecimal(gridView1.GetRowCellValue(i, gridCol间隔时间));
                    }
                    dr["作业人员数量"] = gridView1.GetRowCellValue(i, gridCol作业人员数量).ToString().Trim();
                    dr["下道工序"] = gridView1.GetRowCellValue(i, gridCol下道工序).ToString().Trim();
                    dr["下一班组"] = gridView1.GetRowCellValue(i, gridCol下一班组).ToString().Trim();
                    dr["完工入库"] = gridView1.GetRowCellValue(i, gridCol完工入库).ToString().Trim();

                    dr["State"] = gridView1.GetRowCellValue(i, gridColState).ToString().Trim();
                    dr["Remark"] = gridView1.GetRowCellValue(i, gridColRemark).ToString().Trim();
                    dt.Rows.Add(dr);
                    sSQL = clsGetSQL.GetDeleteSQL( "ProProcess", dt, 0);
                    aList.Add(sSQL);
                }
            }

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("删除成功！\n合计执行语句:" + iCou + "条");
                GetGrid();
            }
        }

        /// <summary>
        /// 判断生产工序是否已经使用
        /// </summary>
        /// <param name="p"></param>
        /// <param name="sErr"></param>
        /// <returns></returns>
        private bool CheckCanDel(string p,out string sErr)
        {
            bool b = true;
            sErr = "";

            return b;
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


            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridCol母件顺序).ToString().Trim() != "" && Convert.ToInt32(gridView1.GetRowCellValue(i, gridCol母件顺序)) != i + 1)
                {
                    throw new Exception("母件顺序存在错误，请核实");
                }
            }


            sSQL = "select *,cast(null as varchar(5)) as bEdit from ProProcess where 1=-1";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            string sErr = "";

            aList = new System.Collections.ArrayList();
            sSQL = "delete dbo.ProProcess where 产品编码 = '" + lookUpEdit产品编码.EditValue.ToString().Trim() + "'";
            aList.Add(sSQL);

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellDisplayText(i, gridCol产品编码).ToString().Trim() == "" && gridView1.GetRowCellDisplayText(i, gridCol物料编码).ToString().Trim() == "")
                {
                    continue;
                }
                if (gridView1.GetRowCellDisplayText(i, gridCol产品编码).ToString().Trim() == "")
                {
                    sErr = sErr + "行" + (i + 1) + "产品编码不能为空\n";
                    continue;
                }
                if (gridView1.GetRowCellDisplayText(i, gridCol母件顺序).ToString().Trim() == "")
                {
                    sErr = sErr + "行" + (i + 1) + "母件顺序不能为空\n";
                    continue;
                }
                if (gridView1.GetRowCellDisplayText(i, gridCol物料编码).ToString().Trim() == "")
                {
                    sErr = sErr + "行" + (i + 1) + "物料编码不能为空\n";
                    continue;
                }
                if (gridView1.GetRowCellDisplayText(i, gridCol加工顺序).ToString().Trim() == "")
                {
                    sErr = sErr + "行" + (i + 1) + "加工顺序不能为空\n";
                    continue;
                }
                if (gridView1.GetRowCellDisplayText(i, gridCol工序).ToString().Trim() == "")
                {
                    sErr = sErr + "行" + (i + 1) + "工序不能为空\n";
                    continue;
                }
                if (gridView1.GetRowCellValue(i, gridColState).ToString().Trim() == "")
                {
                    sErr = sErr + "行" + (i + 1) + "状态不能为空\n";
                    continue;
                }


                DataRow dr = dt.NewRow();
                dr["母件顺序"] = gridView1.GetRowCellValue(i, gridCol母件顺序).ToString().Trim();
                dr["产品编码"] = gridView1.GetRowCellValue(i, gridCol产品编码).ToString().Trim();
                dr["物料编码"] = gridView1.GetRowCellValue(i, gridCol物料编码).ToString().Trim();
                dr["半成品编码"] = gridView1.GetRowCellValue(i, gridCol半成品编码).ToString().Trim();
                dr["逻辑顺序"] = gridView1.GetRowCellValue(i, gridCol逻辑顺序).ToString().Trim();
                dr["加工顺序"] = gridView1.GetRowCellValue(i, gridCol加工顺序).ToString().Trim();
                dr["设备"] = gridView1.GetRowCellValue(i, gridCol设备).ToString().Trim();
                dr["组别"] = gridView1.GetRowCellValue(i, gridCol组别).ToString().Trim();
                if (gridView1.GetRowCellValue(i, gridCol内部流转).ToString().Trim() == string.Empty)
                {
                    dr["内部流转"] = 0;
                }
                else
                {
                    dr["内部流转"] = Convert.ToDecimal(gridView1.GetRowCellValue(i, gridCol内部流转));
                }
                dr["工序"] = gridView1.GetRowCellValue(i, gridCol工序).ToString().Trim();
                dr["数量"] = gridView1.GetRowCellValue(i, gridCol数量).ToString().Trim();
                if (gridView1.GetRowCellValue(i, gridCol单位工时).ToString().Trim() != string.Empty)
                {
                    dr["单位工时"] = Convert.ToDecimal(gridView1.GetRowCellValue(i, gridCol单位工时));
                }
                if (gridView1.GetRowCellValue(i, gridCol间隔时间).ToString().Trim() != string.Empty)
                {
                    dr["间隔时间"] = Convert.ToDecimal(gridView1.GetRowCellValue(i, gridCol间隔时间));
                }
                dr["作业人员数量"] = gridView1.GetRowCellValue(i, gridCol作业人员数量).ToString().Trim();
                dr["开工时间"] = gridView1.GetRowCellValue(i, gridCol开工时间).ToString().Trim();
                dr["下道工序"] = gridView1.GetRowCellValue(i, gridCol下道工序).ToString().Trim();
                dr["下一班组"] = gridView1.GetRowCellValue(i, gridCol下一班组).ToString().Trim();
                dr["完工入库"] = gridView1.GetRowCellValue(i, gridCol完工入库).ToString().Trim();

                if (gridView1.GetRowCellValue(i, gridCol开工排序).ToString().Trim() != "")
                {
                    dr["开工排序"] = gridView1.GetRowCellValue(i, gridCol开工排序).ToString().Trim();
                }
                
                dr["State"] = gridView1.GetRowCellValue(i, gridColState).ToString().Trim();
                dr["Remark"] = gridView1.GetRowCellValue(i, gridColRemark).ToString().Trim();

                if (sState == "import")
                {
                    dr["bEdit"] = "add";
                }
                if (sState == "add")
                {
                    dr["bEdit"] = "add";
                }
                if (sState == "edit")
                {
                    dr["bEdit"] = "edit";
                }

                dt.Rows.Add(dr);
            }

            if (sErr.Trim().Length > 0)
            {
                MsgBox("提示", sErr);
                return;
            }

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //if (dt.Rows[i]["bEdit"].ToString().Trim() == "add")
                    //{
                        sSQL = clsGetSQL.GetInsertSQL( "ProProcess", dt, i);
                        aList.Add(sSQL);
                    //}
                    //if (dt.Rows[i]["bEdit"].ToString().Trim() == "edit")
                    //{
                    //    sSQL = clsGetSQL.GetUpdateSQL( "ProProcess", dt, i);
                    //    aList.Add(sSQL);
                    //}
                }
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

        private void FrmProProcess_Load(object sender, EventArgs e)
        {
            try
            {
                GetProcess();
                GetInventory();
                GetLookUp();
                GetType();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void GetGrid()
        {
            if (lookUpEdit产品编码.EditValue != null && lookUpEdit产品编码.EditValue.ToString().Trim() != "")
            {
                int iFocRow = gridView1.FocusedRowHandle;
                string sSQL = "select *,cast(null as varchar(10)) as iSave from dbo.ProProcess where 产品编码 = '" + lookUpEdit产品编码.EditValue.ToString().Trim() + "' order by 产品编码,母件顺序,物料编码,加工顺序";
                dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
                gridControl1.DataSource = dtBingGrid;
                if (dtBingGrid == null)
                    return;

                for (int i = 0; i < dtBingGrid.Rows.Count; i++)
                {
                    if (dtBingGrid.Rows[i]["组别"].ToString().Trim() != "")
                    {
                        dtBingGrid.Rows[i]["组别"] = sDepInfo(dtBingGrid.Rows[i]["组别"].ToString().Trim());
                    }
                    if (dtBingGrid.Rows[i]["下一班组"].ToString().Trim() != "")
                    {
                        dtBingGrid.Rows[i]["下一班组"] = sDepInfo(dtBingGrid.Rows[i]["下一班组"].ToString().Trim());
                    }
                }

                gridView1.AddNewRow();

                gridView1.FocusedRowHandle = iFocRow;
            }
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridCol母件顺序).ToString().Trim() != "" && Convert.ToInt32(gridView1.GetRowCellValue(i, gridCol母件顺序)) != i + 1)
                {
                    MessageBox.Show("母件顺序存在错误，请核实");
                    return;
                }
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //if (e.Column != gridColiSave && gridView1.GetRowCellDisplayText(e.RowHandle, gridColtstamp).ToString().Trim() != "")
            //{
            //    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridColiSave, "edit");
            //}
            if (e.Column == gridCol产品编码 && e.RowHandle == gridView1.RowCount - 1 && gridView1.GetRowCellDisplayText(e.RowHandle, gridCol产品编码).ToString().Trim() != "")
            {
                int iRow = gridView1.FocusedRowHandle;
                gridView1.AddNewRow();
                gridView1.FocusedRowHandle = iRow;
            }

            //if (e.Column == gridColcInvCode && gridView1.GetRowCellDisplayText(e.RowHandle,gridColcInvCode).ToString().Trim() != string.Empty)
            //{
            //    DataRow[] dr = ((DataTable)ItemLookUpEditInventory.DataSource).Select("cInvCode = '" + gridView1.GetRowCellDisplayText(e.RowHandle, gridColcInvCode) + "'");
            //    if (dr.Length > 0)
            //    {
            //        gridView1.SetRowCellValue(e.RowHandle, gridColcInvName, dr[0]["cInvName"]);
            //        gridView1.SetRowCellValue(e.RowHandle, gridColcInvStd, dr[0]["cInvStd"]);
            //    }
            //    else
            //    {
            //        MessageBox.Show("存货编码不存在");
            //    }
            //}

            //if (e.Column == gridColWorkProcessNO && gridView1.GetRowCellDisplayText(e.RowHandle, gridColWorkProcessNO).ToString().Trim() != string.Empty)
            //{
            //    DataRow[] dr = ((DataTable)ItemLookUpEditWorkProcess.DataSource).Select("WorkProcessNO = '" + gridView1.GetRowCellDisplayText(e.RowHandle, gridColWorkProcessNO) + "'");
            //    if (dr.Length > 0)
            //    {
            //        gridView1.SetRowCellValue(e.RowHandle, gridColWorkProcess, dr[0]["WorkProcess"]);
            //    }
            //    else
            //    {
            //        MessageBox.Show("工序编码不存在");
            //    }
            //}
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

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //if (gridView1.GetRowCellDisplayText(e.FocusedRowHandle, gridColtstamp).ToString().Trim() == "")
            //{
            //    gridColWorkProcessNO.OptionsColumn.AllowEdit = true;
            //}
            //else
            //{
            //    gridColWorkProcessNO.OptionsColumn.AllowEdit = false;
            //}
        }

        /// <summary>
        /// 获得LookUp
        /// /// </summary>
        private void GetLookUp()
        {
            sSQL = "select iID,iText as State from dbo._LookUpDate where iType = '3' and isnull(bClose,1)=1 order by iID";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEditState.DataSource = dt;

            sSQL = "select cInvCode,cInvName,cInvStd from @u8.Inventory order by cInvCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            lookUpEdit产品编码.Properties.DataSource = dt;
            lookUpEdit产品名称.Properties.DataSource = dt;
            lookUpEdit产品规格.Properties.DataSource = dt;

            sSQL = "select cDepCode,cDepName from @u8.Department order by cDepCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit组别.DataSource = dt;

            sSQL = "select iID,iText,Remark from dbo._LookUpDate where iType = '5' and isnull(bClose,1)=1 order by iID";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit完工入库.DataSource = dt;
        }

        /// <summary>
        /// 获得存货档案
        /// </summary>
        private void GetInventory()
        {
            sSQL = "select cInvCode,cInvName,cInvStd from @u8.Inventory order by cInvCode ";
            DataTable dtInventory = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEditInventory.DataSource = dtInventory;
        }

        /// <summary>
        /// 获得工序档案
        /// </summary>
        private void GetProcess()
        {
            sSQL = "select * from dbo.WorkProcess order by WorkProcessNO ";
            DataTable dtProcess = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEditWorkProcess.DataSource = dtProcess;
        }

        private void ItemButtonEdit公式_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int iFocRow = gridView1.FocusedRowHandle;
            string sText = gridView1.GetRowCellDisplayText(iFocRow, gridCol开工排序).ToString().Trim();
            int iRowMJ =Convert.ToInt32(  gridView1.GetRowCellDisplayText(iFocRow, gridCol母件顺序));
            FrmProProcess_Formula fFormula = new FrmProProcess_Formula(sText, iRowMJ);
            fFormula.ShowDialog();
            gridView1.SetRowCellValue(iFocRow, gridCol开工排序, fFormula.richTextBox1.Text.Trim());
        }
        
        private void lookUpEdit产品编码_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEdit产品规格.EditValue = lookUpEdit产品编码.EditValue;
            lookUpEdit产品名称.EditValue = lookUpEdit产品编码.EditValue;

            GetGrid();
        }

        /// <summary>
        /// 建立U8与吕云系统的部门对应信息
        /// </summary>
        /// <param name="sDep"></param>
        /// <returns></returns>
        private string sDepInfo(string sDep)
        {
            string sDepU8Name = "";
            switch (sDep)
            {
                case "冲压组": sDepU8Name = "冲压"; break;
                case "焊接组": sDepU8Name = "电焊"; break;
                case "冲压": sDepU8Name = "冲压"; break;
                case "出冲压": sDepU8Name = "冲压"; break;
                case "电焊组": sDepU8Name = "电焊"; break;
                case "拉伸": sDepU8Name = ""; break;
                case "拉伸孔": sDepU8Name = ""; break;
                case "铝件组": sDepU8Name = "铝件"; break;
                case "品管部": sDepU8Name = "品检"; break;
                case "铁件组": sDepU8Name = "铁件组"; break;
                case "维护组": sDepU8Name = "维护组"; break;
                case "委外部": sDepU8Name = "委外部"; break;
                case "物控部": sDepU8Name = "委外部"; break;
                case "研发部": sDepU8Name = "研发"; break;
                case "组装": sDepU8Name = "组装"; break;
                case "组装组": sDepU8Name = "组装"; break;
                case "采购部": sDepU8Name = "采购"; break;
                case "生管部": sDepU8Name = "生管部"; break;
                case "销售/人事部": sDepU8Name = "人事"; break;
                case "财务部": sDepU8Name = "财务"; break;
                case "生产部": sDepU8Name = "生产"; break;
                case "裁切组": sDepU8Name = "裁切--停用"; break;
                case "办公室": sDepU8Name = "人事"; break;

                default: sDepU8Name = sDep; break;
            }
            return sDepU8Name;
        }
    }
}
