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
    public partial class Frm收发存汇总表 : FrameBaseFunction.FrmBaseInfo
    {
        public Frm收发存汇总表()
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
            DataTable dtState = (DataTable)ItemLookUpEditPerState.DataSource;
            DataTable dtType = (DataTable)ItemLookUpEditWorkplant.DataSource;
            DataColumn dc = new DataColumn();
            dc.ColumnName = "StateText";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "TypeText";
            dt.Columns.Add(dc);
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    DataRow[] drState = dtState.Select("iID = '" + dt.Rows[i]["State"].ToString().Trim() + "'");
            //    if (drState.Length > 0)
            //    {
            //        dt.Rows[i]["StateText"] = drState[0]["State"];
            //    }

            //    DataRow[] drType = dtType.Select("iID = '" + dt.Rows[i]["Type"].ToString().Trim() + "'");
            //    if (drType.Length > 0)
            //    {
            //        dt.Rows[i]["TypeText"] = drType[0]["Type"];
            //    }
            //}

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
            //DataTable dtHead = dtBingHead.Copy();
            //dtHead.TableName = "dtHead";
            //base.dsPrint.Tables.Add(dtHead);
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
            //        MsgBox("提示", sErr);
            //    }
            //}
            //else
            //{
            //    throw new Exception("取消导入");
            //}
        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void btnRefresh()
        {
            try
            {
                //GetType();
                //GetPerState();
                //GetWorkplant();
                //GetPost();
                //GetLevels();
                //GetPerType();
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("刷新窗体失败\n" + ee.Message);
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
            //throw new NotImplementedException();
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
            //string sErr = "";
            //string sErrInfo = "";
            //for (int iRow = gridView1.RowCount - 1; iRow >= 0; iRow--)
            //{
            //    if (gridView1.IsRowSelected(iRow))
            //    {
            //        if (!CheckCanDel(gridView1.GetRowCellValue(iRow, gridCol存货编码).ToString().Trim(), out sErrInfo))
            //        {
            //            sErr = sErr + "生产员工:" + gridView1.GetRowCellValue(iRow, gridCol存货编码).ToString().Trim() + "  " + gridView1.GetRowCellValue(iRow, gridColName).ToString().Trim() + sErr + "\n";
            //        }
            //    }
            //}

            //if (sErr.Length > 0)
            //{
            //    MsgBox("生产员工已经使用不能删除", sErr);
            //    return;
            //}
            //DialogResult d = MessageBox.Show("确定删除选中的 " + gridView1.SelectedRowsCount + " 行生产员工么？\n是：继续\n否：取消", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            //if (d != System.Windows.Forms.DialogResult.Yes)
            //{
            //    return;
            //}

            //aList = new System.Collections.ArrayList();
            //for (int iRow = gridView1.RowCount - 1; iRow >= 0; iRow--)
            //{
            //    if (gridView1.IsRowSelected(iRow))
            //    {
            //        sSQL = "select * from WorkPerson  where PerNO='" + gridView1.GetRowCellValue(iRow, gridCol存货编码).ToString().Trim() + "'";
            //        DataTable dtnew = clsSQLCommond.ExecQuery(sSQL);
            //        if (dtnew.Rows.Count > 0 && dtnew.Rows[0]["used"].ToString() == "Y")
            //        {
            //            sErr = sErr + "行" + (iRow + 1) + "已使用不可删除\n";
            //        }
            //        else
            //        {
            //            sSQL = "select * from WorkPerson where 1=-1";
            //            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            //            DataRow dr = dt.NewRow();
            //            dr["PerNO"] = gridView1.GetRowCellValue(iRow, gridCol存货编码).ToString().Trim();
            //            dr["NamePY"] = gridView1.GetRowCellValue(iRow, gridCol现存量).ToString().Trim();
            //            dr["Name"] = gridView1.GetRowCellValue(iRow, gridColName).ToString().Trim();
            //            dr["Type"] = gridView1.GetRowCellValue(iRow, gridColType).ToString().Trim();
            //            dr["State"] = gridView1.GetRowCellValue(iRow, gridColState).ToString().Trim();
            //            dr["Remark"] = gridView1.GetRowCellValue(iRow, gridColRemark).ToString().Trim();
            //            dr["WorkplantNO"] = gridView1.GetRowCellValue(iRow, gridColWorkplantNO).ToString().Trim();
            //            dr["Post"] = gridView1.GetRowCellValue(iRow, gridColPost).ToString().Trim();
            //            dr["Levels"] = gridView1.GetRowCellValue(iRow, gridColLevels).ToString().Trim();
            //            dr["PerType"] = gridView1.GetRowCellValue(iRow, gridColPerType).ToString().Trim();
            //            dt.Rows.Add(dr);
            //            sSQL = clsGetSQL.GetDeleteSQL("XWSystemDB_TS", "WorkPerson", dt, 0);
            //            aList.Add(sSQL);
            //        }
            //    }
            //}

            //if (aList.Count > 0)
            //{
            //    int iCou = clsSQLCommond.ExecSqlTran(aList);
            //    MessageBox.Show("保存成功！\n合计执行语句:" + iCou + "条");
            //    GetGrid();
            //}
        }

        /// <summary>
        /// 判断生产员工是否已经使用
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
            //try
            //{
            //    gridView1.FocusedColumn = gridCol存货编码;
            //    gridView1.FocusedRowHandle -= 1;
            //    gridView1.FocusedRowHandle += 1;
            //    gridView1.Focus();
            //}
            //catch { }
            //sSQL = "select * from WorkPerson where 1=-1";
            //DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            //string sErr = "";

            //aList = new System.Collections.ArrayList();
            //for (int i = 0; i < gridView1.RowCount; i++)
            //{
            //    if (gridView1.GetRowCellDisplayText(i, gridCol存货编码).ToString().Trim() == "")
            //    {
            //        continue;
            //    }

            //    if (gridView1.GetRowCellValue(i, gridColName).ToString().Trim() == "")
            //    {
            //        sErr = sErr + "行" + (i + 1) + "姓名不能为空\n";
            //        continue;
            //    }
            //    if (gridView1.GetRowCellValue(i, gridColState).ToString().Trim() == "")
            //    {
            //        sErr = sErr + "行" + (i + 1) + "状态不能为空\n";
            //        continue;
            //    }
            //    if (gridView1.GetRowCellValue(i, gridColWorkplantNO).ToString().Trim() == "")
            //    {
            //        sErr = sErr + "行" + (i + 1) + "车间不能为空\n";
            //        continue;
            //    }
            //    if (gridView1.GetRowCellValue(i, gridColPost).ToString().Trim() == "")
            //    {
            //        sErr = sErr + "行" + (i + 1) + "岗位不能为空\n";
            //        continue;
            //    }
            //    if (gridView1.GetRowCellValue(i, gridColLevels).ToString().Trim() == "")
            //    {
            //        sErr = sErr + "行" + (i + 1) + "级别不能为空\n";
            //        continue;
            //    }
            //    if (gridView1.GetRowCellValue(i, gridColPerType).ToString().Trim() == "")
            //    {
            //        sErr = sErr + "行" + (i + 1) + "类型不能为空\n";
            //        continue;
            //    }


            //    if (gridView1.GetRowCellDisplayText(i, gridColtstamp).ToString().Trim() == "")
            //    {
            //        DataRow dr = dt.NewRow();
            //        dr["PerNO"] = gridView1.GetRowCellValue(i, gridCol存货编码).ToString().Trim();
            //        dr["NamePY"] = gridView1.GetRowCellValue(i, gridCol现存量).ToString().Trim();
            //        dr["Name"] = gridView1.GetRowCellValue(i, gridColName).ToString().Trim();
            //        dr["Type"] = gridView1.GetRowCellValue(i, gridColType).ToString().Trim();
            //        dr["State"] = gridView1.GetRowCellValue(i, gridColState).ToString().Trim();
            //        dr["Remark"] = gridView1.GetRowCellValue(i, gridColRemark).ToString().Trim();
            //        dr["WorkplantNO"] = gridView1.GetRowCellValue(i, gridColWorkplantNO).ToString().Trim();
            //        dr["Post"] = gridView1.GetRowCellValue(i, gridColPost).ToString().Trim();
            //        dr["Levels"] = gridView1.GetRowCellValue(i, gridColLevels).ToString().Trim();
            //        dr["PerType"] = gridView1.GetRowCellValue(i, gridColPerType).ToString().Trim();

            //        dt.Rows.Add(dr);
            //        sSQL = clsGetSQL.GetInsertSQL("XWSystemDB_TS", "WorkPerson", dt, dt.Rows.Count - 1);
            //        aList.Add(sSQL);

            //    }
            //    if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "edit")
            //    {
            //        DataRow dr = dt.NewRow();
            //        sSQL = "select * from WorkPerson  where PerNO='" + gridView1.GetRowCellValue(i, gridCol存货编码).ToString().Trim() + "'";
            //        DataTable dtnew = clsSQLCommond.ExecQuery(sSQL);
            //        if (dtnew.Rows.Count > 0 && dtnew.Rows[0]["used"].ToString() == "Y")
            //        {
            //            if (dtnew.Rows[0]["PerNO"].ToString() != gridView1.GetRowCellValue(i, gridCol存货编码).ToString().Trim()
            //                || dtnew.Rows[0]["NamePY"].ToString() != gridView1.GetRowCellValue(i, gridCol现存量).ToString().Trim()
            //                || dtnew.Rows[0]["Name"].ToString() != gridView1.GetRowCellValue(i, gridColName).ToString().Trim())
            //            {
            //                sErr = sErr + "行" + (i + 1) + "已使用不可修改员工工号,姓名拼音,姓名,岗位,级别,类型\n";
            //            }

            //            dr["PerNO"] = dtnew.Rows[0]["PerNO"].ToString();
            //            dr["NamePY"] = dtnew.Rows[0]["NamePY"].ToString();
            //            dr["Name"] = dtnew.Rows[0]["Name"].ToString();
            //            dr["Post"] = dtnew.Rows[0]["Post"].ToString();
            //            dr["Levels"] = dtnew.Rows[0]["Levels"].ToString();
            //            dr["PerType"] = dtnew.Rows[0]["PerType"].ToString();
            //        }
            //        else
            //        {
            //            dr["PerNO"] = gridView1.GetRowCellValue(i, gridCol存货编码).ToString().Trim();
            //            dr["NamePY"] = gridView1.GetRowCellValue(i, gridCol现存量).ToString().Trim();
            //            dr["Name"] = gridView1.GetRowCellValue(i, gridColName).ToString().Trim();
            //            dr["Post"] = gridView1.GetRowCellValue(i, gridColPost).ToString().Trim();
            //            dr["Levels"] = gridView1.GetRowCellValue(i, gridColLevels).ToString().Trim();
            //            dr["PerType"] = gridView1.GetRowCellValue(i, gridColPerType).ToString().Trim();
            //        }
            //        dr["Type"] = gridView1.GetRowCellValue(i, gridColType).ToString().Trim();
            //        dr["State"] = gridView1.GetRowCellValue(i, gridColState).ToString().Trim();
            //        dr["Remark"] = gridView1.GetRowCellValue(i, gridColRemark).ToString().Trim();
            //        dr["WorkplantNO"] = gridView1.GetRowCellValue(i, gridColWorkplantNO).ToString().Trim();

            //        dt.Rows.Add(dr);
            //        sSQL = clsGetSQL.GetUpdateSQL("XWSystemDB_TS", "WorkPerson", dt, dt.Rows.Count - 1);
            //        aList.Add(sSQL);
            //    }

            //}

            //if (sErr.Trim().Length > 0)
            //{
            //    MsgBox("提示", sErr);
            //    return;
            //}

            //if (aList.Count > 0)
            //{
            //    int iCou = clsSQLCommond.ExecSqlTran(aList);
            //    MessageBox.Show("保存成功！\n合计执行语句:" + iCou + "条");
            //    GetGrid();
            //}
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

        private void FrmWorkPerson_Load(object sender, EventArgs e)
        {
            try
            {
                
                DateTime dt = DateTime.Now;
                dateEdit1.EditValue = Convert.ToDateTime(dt.Year + "-" + dt.Month + "-" + "01");
                dateEdit2.EditValue = Convert.ToDateTime(dt.Year + "-" + dt.Month + "-" + "01").AddMonths(1).AddDays(-1);
                dateEdit1.Enabled = true;
                dateEdit1.Properties.ReadOnly = false;
                dateEdit2.Enabled = true;
                dateEdit2.Properties.ReadOnly = false;

                lookUpEdit材料类型.Enabled = true;
                lookUpEdit材料类型.Properties.ReadOnly = false;
                string sSQL = "select cValue as iID from @u8.UserDefine where cID = 52 ";
                DataTable dts = clsSQLCommond.ExecQuery(sSQL);
                DataRow dw = dts.NewRow();
                dw[0] = "";
                dts.Rows.Add(dw);
                lookUpEdit材料类型.Properties.DataSource = dts;


                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void GetGrid()
        {
            base.dsPrint = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("存货编码");


            string cinvcode = "";
            if (dateEdit1.EditValue.ToString() == "" && dateEdit2.EditValue.ToString() == "")
            {
                MessageBox.Show("日期区间不可为空！");
            }
            else
            {
                base.dsPrint.Tables.Add(dt.Copy());
                base.dsPrint.Tables[0].TableName = "dtHead";

                string sql1 = @"SELECT 材料类型,存货编码,存货名称, convert(decimal(18, 2),SUM(材料重量)) AS 期初结存,0 as 本期增加,0 as 本期减少,0 as 期末结存2   
FROM (" + SQL._dataSourceStr1.Replace("1=1", "convert(varchar(10),@u8.材料入库单表头.入库日期,120)< '" + Convert.ToDateTime(dateEdit1.EditValue).ToString("yyyy-MM-dd") + "'").Replace("2=2", "convert(varchar(10),@u8.开料单表头.交货日期,120)< '" + Convert.ToDateTime(dateEdit1.EditValue).ToString("yyyy-MM-dd") + "'") + ") s group by 存货编码,存货名称,材料类型";
                string sql2 = @"SELECT 材料类型,存货编码,存货名称,0 AS 期初结存, convert(decimal(18, 2),SUM(材料重量)) as 本期增加,0 as 本期减少,0 as 期末结存2   
FROM (" + SQL._dataSourceStr2.Replace("1=1", "convert(varchar(10),日期,120)>= '" + Convert.ToDateTime(dateEdit1.EditValue).ToString("yyyy-MM-dd") + "' and convert(varchar(10),日期,120)<= '" + Convert.ToDateTime(dateEdit2.EditValue).ToString("yyyy-MM-dd") + "'") + ") s  group by 存货编码,存货名称,材料类型";
                string sql3 = @"SELECT 材料类型,存货编码,存货名称,0 AS 期初结存,0 as 本期增加, convert(decimal(18, 2),SUM(实际用料重量)) as 本期减少,0 as 期末结存2   
FROM (" + SQL._dataSourceStr3.Replace("1=1", "convert(varchar(10),日期,120)>= '" + Convert.ToDateTime(dateEdit1.EditValue).ToString("yyyy-MM-dd") + "' and convert(varchar(10),日期,120)<= '" + Convert.ToDateTime(dateEdit2.EditValue).ToString("yyyy-MM-dd") + "'") + ") s  group by 存货编码,存货名称,材料类型";
                string sql4 = @"SELECT 材料类型,存货编码,存货名称, 0 AS 期初结存,0 as 本期增加,0 as 本期减少,convert(decimal(18, 2),SUM(材料重量)) as 期末结存2   
FROM (" + SQL._dataSourceStr1.Replace("1=1", "convert(varchar(10),@u8.材料入库单表头.入库日期,120)<= '" + Convert.ToDateTime(dateEdit2.EditValue).ToString("yyyy-MM-dd") + "'").Replace("2=2", "convert(varchar(10),@u8.开料单表头.交货日期,120)<= '" + Convert.ToDateTime(dateEdit2.EditValue).ToString("yyyy-MM-dd") + "'") + ") s group by 存货编码,存货名称,材料类型";

                string sqls = @"
select 存货编码,存货名称,材料类型, convert(decimal(18, 2),sum(期初结存)) as 期初结存, convert(decimal(18, 2),sum(本期增加)) as 本期增加 
    ,convert(decimal(18, 2),sum(期末结存2))-convert(decimal(18, 2),sum(期初结存))-convert(decimal(18, 2),sum(本期增加)) as 本期减少
    ,convert(decimal(18, 2),sum(期末结存2)) as 期末结存 
    ,b.cInvStd as 厚度
from 
(111111 union all 222222 union all 333333 union all 444444) s 
    LEFT JOIN @u8.Inventory b on s.存货编码 = b.cInvCode
                
where 1=1 and 存货编码<>'' 
group by 存货编码,存货名称,材料类型 ,b.cInvStd

";

    sqls = sqls.Replace("111111",sql1);
    sqls = sqls.Replace("222222",sql2);
    sqls = sqls.Replace("333333",sql3);
    sqls = sqls.Replace("444444",sql4);

                if (lookUpEdit材料类型.Text.Trim() != "")
                {
                    sqls = sqls.Replace("1=1", "1=1 and 材料类型= '" + lookUpEdit材料类型.Text.Trim() + "'");
                }
                dtBingGrid = clsSQLCommond.ExecQuery(sqls);
                //string sql = "select  convert(decimal(18, 2),sum(期初结存)) as 期初结存, convert(decimal(18, 2),sum(本期增加)) as 本期增加, convert(decimal(18, 2),sum(本期减少)) as 本期减少,convert(decimal(18, 2),sum(期末结存2)) as 期末结存2, convert(decimal(18, 2),sum(期初结存)+sum(本期增加)-sum(本期减少)) as 期末结存 from (" + sql1 + " union all " + sql2 + " union all " + sql3 + " union all " + sql4 + ") s ";
                //DataTable dts = clsSQLCommond.ExecQuery(sql);

                //if (dts.Rows.Count > 0)
                //{
                //    DataRow dw = dtBingGrid.NewRow();
                //    dw["存货编码"] = "合计";
                //    dw["期初结存"] = dts.Rows[0]["期初结存"].ToString();
                //    dw["本期增加"] = dts.Rows[0]["本期增加"].ToString();
                //    dw["本期减少"] = dts.Rows[0]["本期减少"].ToString();
                //    dw["期末结存"] = dts.Rows[0]["期末结存"].ToString();
                //    dw["期末结存2"] = dts.Rows[0]["期末结存2"].ToString();
                //    dtBingGrid.Rows.Add(dw);
                //}

                gridControl1.DataSource = dtBingGrid;

                base.dsPrint.Tables.Add(dtBingGrid.Copy());
                base.dsPrint.Tables[1].TableName = "dtGrid";
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void GetPerType()
        {
            string sSQL = "select iID,iText from _LookUpDate where iType = '9' and isnull(bClose,1) = 1 order by iID";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEditPerType.DataSource = dt;
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

        private void lookUpEdit材料类型_EditValueChanged(object sender, EventArgs e)
        {
            GetGrid();
        }

    }
}
