﻿using System;
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
    public partial class Frm设备状态 : FrameBaseFunction.FrmFromModel
    {
        public Frm设备状态()
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

            sTableList = "设备状态";

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
                    case "add":
                        btnAdd();
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
            //DateTime d = DateTime.Today;
            //if (d > dateEdit1.DateTime)
            //{
            //    throw new Exception("不能编辑之前的档案");
            //}

            //sSQL = "select a.*,b.iID,b.State from @u8.EQ_EQData a left join EQ b on a.cEQCode=b.cEQCode where dDate='" + d + "'";
            //dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
        
            //gridControl1.DataSource = dtBingGrid;
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
            //string sErr = "";
            //OpenFileDialog oFile = new OpenFileDialog();
            //oFile.Filter = "Excel文件2003|*.xls|Excel文件2007|*.xlsx";
            //if (oFile.ShowDialog() == DialogResult.OK)
            //{
            //    string sFilePath = oFile.FileName;
            //    string sSQL = "select distinct 设备编号 as MachineNO,设备 as Machine,负责人,状态 as State,备注 as Remark,null as tstamp,null as iSave from [设备档案$]";

            //    DataTable dtExcel = clsExcel.ExcelToDT(sFilePath, sSQL, true);

            //    for (int i = 0; i < dtExcel.Rows.Count; i++)
            //    {
            //        string sMachineNO = dtExcel.Rows[i]["MachineNO"].ToString().Trim();
            //        DataRow[] dr = dtBingGrid.Select("MachineNO = '" + sMachineNO + "'");
            //        if (dr.Length > 0)
            //        {
            //            dtExcel.Rows[i]["tstamp"] = dr[0]["tstamp"];
            //            sErr = sErr + sMachineNO + "\n";
            //        }
            //    }
            //    gridControl1.DataSource = dtExcel;

            //    if (sErr.Length > 0)
            //    {
            //        sErr = "以下设备编号已经存在，不能重复导入：\n" + sErr;
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
            //try
            //{
            //    int iCou = BLL.Del(dateEdit1.DateTime);
            //    if (iCou > 0)
            //    {
            //        MessageBox.Show("删除成功");

            //        GetGrid();
            //    }
            //    else
            //    {
            //        throw new Exception("没有需要删除的数据");
            //    }

            //}
            //catch (Exception ee)
            //{
            //    throw new Exception("删除失败：" + ee.Message);
            //}
            throw new NotImplementedException();
        }

      
        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave()
        {
            try
            {
                gridView1.FocusedColumn = gridCol设备序号;
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
                gridView1.Focus();
            }
            catch { }
            sSQL = "select * from EQ where 1=-1";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            string sErr = "";

            aList = new System.Collections.ArrayList();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridColiSave).ToString().Trim() != "add" && gridView1.GetRowCellValue(i, gridColiSave).ToString().Trim() != "update")
                {
                    continue;
                }

                #region 生成table
                DataRow dr = dt.NewRow();
                
                dr["cEQCode"] = gridView1.GetRowCellValue(i, gridCol设备名称).ToString().Trim();
                dr["State"] = gridView1.GetRowCellValue(i, gridCol状态).ToString().Trim();
                dr["Remark"] = gridView1.GetRowCellValue(i, gridColRemark).ToString().Trim();
                dr["dDate"] = dateEdit1.DateTime.ToString("yyyy-MM-dd");

                if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "add")
                {
                    dr["CreateUid"] = FrameBaseFunction.ClsBaseDataInfo.sUid;
                    dr["CreateDate"] = DateTime.Now.ToString();
                }
                else
                {
                    dr["iID"] = gridView1.GetRowCellValue(i, gridColiID).ToString().Trim();
                    dr["CreateUid"] = gridView1.GetRowCellValue(i, gridColCreateUid).ToString().Trim();
                    dr["CreateDate"] = gridView1.GetRowCellValue(i, gridColCreateDate).ToString().Trim();

                    dr["UpdateUid"] = FrameBaseFunction.ClsBaseDataInfo.sUid;
                    dr["UpdateDate"] = DateTime.Now.ToString();
                }

                dt.Rows.Add(dr);
                #endregion

                if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "update")
                {
                    sSQL = clsGetSQL.GetUpdateSQL(FrameBaseFunction.ClsBaseDataInfo.sDataBaseName, "EQ", dt, dt.Rows.Count - 1);
                    aList.Add(sSQL);
                }
                if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "add")
                {
                    sSQL = clsGetSQL.GetInsertSQL(FrameBaseFunction.ClsBaseDataInfo.sDataBaseName, "EQ", dt, dt.Rows.Count - 1);
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
            //try
            //{
            //    gridView1.FocusedRowHandle -= 1;
            //    gridView1.FocusedRowHandle += 1;
            //}
            //catch { }

            //try
            //{
            //    dtBingGrid = (DataTable)gridControl1.DataSource;

            //    int iCou = BLL.Open(dtBingGrid);

            //    if (iCou > 0)
            //    {
            //        MessageBox.Show("打开成功");
            //        GetGrid();
            //    }
            //    else
            //    {
            //        MessageBox.Show("请选择需要打开的数据");
            //    }
            //}
            //catch (Exception ee)
            //{
            //    MsgBox("保存失败", ee.Message);
            //}
        }
        /// <summary>
        /// 关闭
        /// </summary>
        private void btnClose()
        {
            //try
            //{
            //    gridView1.FocusedRowHandle -= 1;
            //    gridView1.FocusedRowHandle += 1;
            //}
            //catch { }

            //try
            //{
            //    dtBingGrid = (DataTable)gridControl1.DataSource;

            //    int iCou = BLL.Close(dtBingGrid);

            //    if (iCou > 0)
            //    {
            //        MessageBox.Show("关闭成功");
            //        GetGrid();
            //    }
            //    else
            //    {
            //        MessageBox.Show("请选择需要关闭的数据");
            //    }
            //}
            //catch (Exception ee)
            //{
            //    MsgBox("保存失败", ee.Message);
            //}
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
                dateEdit1.DateTime = DateTime.Today;
                LookUp.EQ_EQData(ItemLookUpEdit设备); 
                LookUp._LoopUpData(ItemLookUpEdit状态, "01");
                btnRefresh();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
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
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
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
            DateTime d = DateTime.Today;
            if (d > dateEdit1.DateTime)
            {
                throw new Exception("不能编辑之前的档案");
            }

            sSQL = @"select a.*,b.iID,case when b.iID is null then '0' else b.State end State, case when b.iID is null then '' else 'edit' end as iSave,b.Remark,CreateUid, CreateDate, UpdateUid, UpdateDate	 
            from @u8.EQ_EQData a left join (select * from EQ where dDate='" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "') b on a.cEQCode=b.cEQCode ";
            dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dtBingGrid;
            gridView1.OptionsBehavior.Editable = false;

        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dateEdit1.DateTime < DateTime.Today)
                    gridView1.OptionsBehavior.Editable = false;
                else
                    gridView1.OptionsBehavior.Editable = true;

                GetGrid();
            }
            catch (Exception ee)
            {
                MsgBox("提示", ee.Message);
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                DevExpress.Utils.AppearanceDefault appTomato = new DevExpress.Utils.AppearanceDefault(Color.Tomato);
                DevExpress.Utils.AppearanceDefault appLawnGreen = new DevExpress.Utils.AppearanceDefault(Color.LawnGreen);

                string sName = e.Column.Name.ToString().Trim();
                if ( sName == "gridCol状态")
                {
                    if (gridView1.GetRowCellValue(e.RowHandle, e.Column).ToString().Trim() == "?")
                    {
                        DevExpress.Utils.AppearanceHelper.Apply(e.Appearance, appLawnGreen);
                    }
                    else if (gridView1.GetRowCellValue(e.RowHandle, e.Column).ToString().Trim().ToLower() != "o")
                    {
                        DevExpress.Utils.AppearanceHelper.Apply(e.Appearance, appTomato);
                    }
                 
                }
            }
            catch (Exception ee)
            { }
        }
    }
}
