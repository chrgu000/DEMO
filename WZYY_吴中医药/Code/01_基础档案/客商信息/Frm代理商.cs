﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;

namespace 基础设置
{
    public partial class Frm代理商 : 系统服务.FrmBaseInfo
    {
        string tablename = "代理商";
        string tableid = "cVenCode";

        public Frm代理商()
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
                    case "add":
                        btnAdd();
                        break;
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

        private void btnAdd()
        {
            try
            {
                int iFoc = gridView1.FocusedRowHandle;

                Frm代理商Edit frm = new Frm代理商Edit();
                frm.dt地区 = (DataTable)ItemLookUpEdit地区.DataSource;
                frm.dt部门 = (DataTable)ItemLookUpEdit部门.DataSource;
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    GetGrid();
                    gridView1.FocusedRowHandle = iFoc;
                }
            }
            catch (Exception ee)
            {
                throw new Exception("新增失败:" + ee.Message);
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
            //DataTable dtState = (DataTable)ItemLookUpEditcTrade.DataSource;
            //DataTable dtType = (DataTable)ItemLookUpEditcCCCode.DataSource;
            //DataColumn dc = new DataColumn();
            //dc.ColumnName = "StateText";
            //dt.Columns.Add(dc);
            //dc = new DataColumn();
            //dc.ColumnName = "TypeText";
            //dt.Columns.Add(dc);
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
            //gridView1.OptionsBehavior.Editable = true;
            //sState = "edit";
            gridView1.OptionsBehavior.Editable = false;

            int iFoc = gridView1.FocusedRowHandle;

            string sVenCode = gridView1.GetRowCellDisplayText(iFoc, gridColcVenCode).ToString().Trim();

            Frm代理商Edit frm = new Frm代理商Edit(sVenCode);
            frm.dt地区 = (DataTable)ItemLookUpEdit地区.DataSource;
            frm.dt部门 = (DataTable)ItemLookUpEdit部门.DataSource;
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                GetGrid();
                gridView1.FocusedRowHandle = iFoc;
            }

        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
            DialogResult result = MessageBox.Show("是否删除?", "删除提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                try
                {
                    string sErr = "";

                    aList = new System.Collections.ArrayList();

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (gridView1.IsRowSelected(i))
                        {
                            string sID = gridView1.GetRowCellValue(i, gridColcVenCode).ToString().Trim();
                            sSQL = @"
select count(*) as iCou
from 
(
	select * from [dbo].[代理商_保证金客户]
	where 代理商编码 = 'aaaaaa' 
	union
	select * from [dbo].[代理商_客户]
	where 代理商编码 = 'aaaaaa' 
)a
";
                            sSQL = sSQL.Replace("aaaaaa", sID);
                            long iCou = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                            if (iCou > 0)
                            {
                                sErr = "行" + (i + 1).ToString() + " " + sID + " 已经使用不能删除\n";
                                continue;
                            }

                            sSQL = "delete " + tablename + " where " + tableid + " = '" + sID + "' ";
                            aList.Add(sSQL);
                        }
                    }
                    if (sErr.Trim().Length > 0)
                    {
                       throw new Exception(sErr);
                    }
                    if (aList.Count > 0)
                    {
                        int iCou = clsSQLCommond.ExecSqlTran(aList);
                        MessageBox.Show("删除成功！\n合计执行语句:" + iCou.ToString() + "条");
              
                        GetGrid();
                  
                        sState = "del";
                    }
                }
                catch (Exception ee)
                {
                    throw new Exception("删除失败！" + ee.Message);
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
                gridView1.FocusedColumn = gridColcVenCode;
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
                gridView1.Focus();
            }
            catch { }
            sSQL = "select * from 代理商 where 1=-1";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            string sErr = "";

            aList = new System.Collections.ArrayList();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridColiSave).ToString().Trim() != "add" && gridView1.GetRowCellValue(i, gridColiSave).ToString().Trim() != "update")
                {
                    continue;
                }

                #region 判断
                if (gridView1.GetRowCellDisplayText(i, gridColcVenCode).ToString().Trim() == ""
                        && gridView1.GetRowCellValue(i, gridColcVenName).ToString().Trim() == "")
                {
                    continue;
                }
                if (gridView1.GetRowCellDisplayText(i, gridColcVenCode).ToString().Trim() == "")
                {
                    sErr = sErr + "行" + (i + 1) + gridColcVenCode.Caption + "不能为空\n";
                    continue;
                }

                if (gridView1.GetRowCellValue(i, gridColcVenName).ToString().Trim() == "")
                {
                    sErr = sErr + "行" + (i + 1) + gridColcVenName.Caption + "不能为空\n";
                    continue;
                }
                if (gridView1.GetRowCellValue(i, gridColcVenEndDate).ToString().Trim() != "")
                {
                    DateTime d2 = Convert.ToDateTime(gridView1.GetRowCellValue(i, gridColcVenEndDate));
                    DateTime d1 = Convert.ToDateTime(gridView1.GetRowCellValue(i, gridColcVenDevDate));
                    if (d2 <= d1)
                    {
                        sErr = sErr + "行" + (i + 1) + "停用日期必须在发展日期之后\n";
                        continue;
                    }
                }
                #endregion

                #region 判断是否重复
                for (int j = 0; j < i; j++)
                {
                    if (gridView1.GetRowCellDisplayText(i, gridColcVenCode).ToString().Trim() == gridView1.GetRowCellDisplayText(j, gridColcVenCode).ToString().Trim())
                    {
                        sErr = sErr + "行" + (i + 1) + gridColcVenCode.Caption + "重复\n";
                        continue;
                    }
                }

                for (int j = 0; j < i; j++)
                {
                    if (gridView1.GetRowCellDisplayText(i, gridColcVenName).ToString().Trim() == gridView1.GetRowCellDisplayText(j, gridColcVenName).ToString().Trim())
                    {
                        sErr = sErr + "行" + (i + 1) + gridColcVenName.Caption + "重复\n";
                        continue;
                    }
                }
                #endregion

                #region 生成table
                DataRow dr = dt.NewRow();
                dr["cVenCode"] = gridView1.GetRowCellValue(i, gridColcVenCode).ToString().Trim();
                dr["cVenName"] = gridView1.GetRowCellValue(i, gridColcVenName).ToString().Trim();
                dr["cVenAbbName"] = gridView1.GetRowCellValue(i, gridColcVenAbbName).ToString().Trim();
               
                dr["cVenPerson"] = gridView1.GetRowCellValue(i, gridColcVenPerson).ToString().Trim();
                dr["cVenPhone"] = gridView1.GetRowCellValue(i, gridColcVenPhone).ToString().Trim();
                dr["cVenDCCode"] = gridView1.GetRowCellValue(i, gridColcVenDCCode).ToString().Trim();
                dr["cVenDepartment"] = gridView1.GetRowCellValue(i, gridColcVenDepartment).ToString().Trim();
                dr["cVenEmail"] = gridView1.GetRowCellValue(i, gridColcVenEmail).ToString().Trim();
                if (gridView1.GetRowCellValue(i, gridColcVenDevDate) != null && gridView1.GetRowCellValue(i, gridColcVenDevDate).ToString() != "")
                {
                    dr["cVenDevDate"] = gridView1.GetRowCellValue(i, gridColcVenDevDate).ToString().Trim();
                }
                else
                {
                    dr["cVenDevDate"] = DBNull.Value;
                }
                if (gridView1.GetRowCellValue(i, gridColcVenEndDate) != null && gridView1.GetRowCellValue(i, gridColcVenEndDate).ToString() != "")
                {
                    dr["cVenEndDate"] = gridView1.GetRowCellValue(i, gridColcVenEndDate).ToString().Trim();
                }
                else
                {
                    dr["cVenEndDate"] = DBNull.Value;
                }
                dr["cVenRegCode"] = gridView1.GetRowCellValue(i, gridColcVenRegCode).ToString().Trim();
                dr["cVenAccount"] = gridView1.GetRowCellValue(i, gridColcVenAccount).ToString().Trim();
                dr["cVenBank"] = gridView1.GetRowCellValue(i, gridColcVenBank).ToString().Trim();
                dr["s1"] = gridView1.GetRowCellValue(i, gridColS1).ToString().Trim();
                dr["s2"] = gridView1.GetRowCellValue(i, gridColS2).ToString().Trim();

                dt.Rows.Add(dr);
                #endregion

                if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "update")
                {
                    sSQL = clsGetSQL.GetUpdateSQL(系统服务.ClsBaseDataInfo.sDataBaseName, "代理商", dt, dt.Rows.Count - 1);
                    aList.Add(sSQL);
                }
                if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "add")
                {
                    sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, "代理商", dt, dt.Rows.Count - 1);
                    aList.Add(sSQL);
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

        private void Frm供应商档案_Load(object sender, EventArgs e)
        {
            try
            {
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
            int iRow = 0;
            if (gridView1.FocusedRowHandle > 0)
                iRow = gridView1.FocusedRowHandle;

            string sSQL = @"
select *, 'edit' as iSave 
from dbo.代理商 
where 1=1
order by cVenCode
";
            if (buttonEdit1.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and ([cVenCode] like '%aaaaaaaaaa%' or cVenName like '%aaaaaaaaaa%' or cVenAbbName like '%aaaaaaaaaa%')");
                sSQL = sSQL.Replace("aaaaaaaaaa", buttonEdit1.Text.Trim());
            }
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;

            gridView1.AddNewRow();
            gridView1.OptionsBehavior.Editable = false;

            gridView1.FocusedRowHandle = iRow;
        }

        /// <summary>
        /// 下拉列表框
        /// </summary>
        private void SetLookUpEdit()
        {
            string sSQL = @"
select * from [dbo].[U8DistrictClass] order by cDCCode
";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit地区.DataSource = dt;

            sSQL = @"
select * from [dbo].[U8Department] order by cDepCode
";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit部门.DataSource = dt;


            sSQL = "select  cVenCode, cVenName, cVenAbbName from 代理商 order by cVenCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            lookUpEdit上级代理.Properties.DataSource = dt;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column != gridColiSave && gridView1.GetRowCellDisplayText(e.RowHandle, gridColiSave).ToString().Trim() == "")
                {
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridColiSave, "add");
                }
                if (e.Column != gridColiSave && gridView1.GetRowCellDisplayText(e.RowHandle, gridColiSave).ToString().Trim() == "edit")
                {
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridColiSave, "update");
                }
                if (e.Column == gridColcVenName && e.RowHandle == gridView1.RowCount - 1 && gridView1.GetRowCellDisplayText(e.RowHandle, gridColcVenCode).ToString().Trim() != "")
                {
                    int iRow = gridView1.FocusedRowHandle;
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

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gridView1.GetRowCellValue(e.FocusedRowHandle, gridColiSave).ToString().ToLower().Trim() == "edit")
                {
                    gridColcVenCode.OptionsColumn.AllowEdit = false;
                }
                else
                {
                    gridColcVenCode.OptionsColumn.AllowEdit = true;
                }
            }
            catch { }
        }

        private void ItemButtonEdit地区_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                Frm参照 frm = new Frm参照(6);
                frm.txtSEL.Text = gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, gridColcVenDCCode).ToString().Trim();
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridColcVenDCCode, frm.iID);
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show("操作失败：" + ee.Message);
            }
        }

        private void ItemButtonEdit部门_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                Frm参照 frm = new Frm参照(2);
                frm.txtSEL.Text = gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, gridColcVenDepartment).ToString().Trim();
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridColcVenDepartment, frm.iID);
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show("操作失败：" + ee.Message);
            }

        }

        private void ItemButtonEdit地区_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                ItemButtonEdit地区_ButtonClick(null, null);
            }
        }

        private void ItemButtonEdit部门_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                ItemButtonEdit部门_ButtonClick(null, null);
            }
        }

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            GetGrid();
        }

      
    }
}
