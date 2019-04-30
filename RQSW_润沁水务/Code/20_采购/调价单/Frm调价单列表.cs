using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;

namespace 采购
{
    public partial class Frm调价单列表 : 系统服务.FrmBaseInfo
    {
        string tablename = "PriceAdjust_Main";
        string tableid = "ID";
        string tablenames = "PriceAdjust_Details";
        string tableids = "AutoID";

        public string iCode1 = "";
        public string iCode2 = "";
        public string dDate1 = "";
        public string dDate2 = "";
        public string dCreatesysTime1 = "";
        public string dCreatesysTime2 = "";
        public string dCreatesysPerson1 = "";
        public string dCreatesysPerson2 = "";
        public string dVerifysysTime1 = "";
        public string dVerifysysTime2 = "";
        public string dVerifysysPerson1 = "";
        public string dVerifysysPerson2 = "";
        public string S1_1 = "";
        public string S1_2 = "";

        public Frm调价单列表()
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
            gridView1.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.False;
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
                MessageBox.Show("刷新窗体失败\n" + ee.Message);
            }
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
            Frm调价单_Add frm = new Frm调价单_Add(iCode1, iCode2, dDate1, dDate2, dCreatesysTime1, dCreatesysTime2, dVerifysysTime1, dVerifysysTime2, dCreatesysPerson1, dCreatesysPerson2, dVerifysysPerson1, dVerifysysPerson2, S1_1, S1_2);
            if (DialogResult.OK == frm.ShowDialog())
            {
                frm.Enabled = true;
                iCode1 = frm.iCode1;
                iCode2 = frm.iCode2;
                dDate1 = frm.dDate1;
                dDate2 = frm.dDate2;
                dCreatesysTime1 = frm.dCreatesysTime1;
                dCreatesysTime2 = frm.dCreatesysTime2;
                dCreatesysPerson1 = frm.dCreatesysPerson1;
                dCreatesysPerson2 = frm.dCreatesysPerson2;
                dVerifysysTime1 = frm.dVerifysysTime1;
                dVerifysysTime2 = frm.dVerifysysTime2;
                dVerifysysPerson1 = frm.dVerifysysPerson1;
                dVerifysysPerson2 = frm.dVerifysysPerson2;
                S1_1 = frm.S1_1;
                S1_2 = frm.S1_2;
                GetGrid();
            }
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
            throw new NotImplementedException();
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
            try
            {
                gridView1.FocusedRowHandle -=1;
                gridView1.FocusedRowHandle +=1;
            }
            catch{}
          
            aList = new System.Collections.ArrayList();
            string sList = "";
            string sErr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (Convert.ToBoolean( gridView1.GetRowCellValue(i, gridCol选择)))
                {
                    string sCode = gridView1.GetRowCellValue(i, gridCol单据号).ToString().Trim();

                    int iRe = CheState(sCode);
                    if (iRe == -1)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "检查单据状态出错\n";
                        continue;
                    }
                    if (iRe == 0)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "单据不存在\n";
                        continue;
                    }
                    if (iRe == 2)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "单据已审核\n";
                        continue;
                    }
                    if (iRe == 3)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "单据已关闭\n";
                        continue;
                    }

                    sSQL = "update " + tablename + " set dVerifysysTime='" + 系统服务.ClsBaseDataInfo.sLogDate + "',dVerifysysPerson='" + 系统服务.ClsBaseDataInfo.sUid + "' " +
                           "where ID=" + gridView1.GetRowCellValue(i, gridColID).ToString().Trim();
                    aList.Add(sSQL);

                    sList = sList + "行" + (i + 1).ToString() + "审核成功\n";
                }
            }
            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MsgBox("审核成功", sErr + "\n" + sList);
                GetGrid();

                checkEditChk.Checked = false;
                sState = "audit";
            }
            else
            {
                throw new Exception(sErr);
            }
        }
        /// <summary>
        /// 弃审
        /// </summary>
        private void btnUnAudit()
        {

            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            aList = new System.Collections.ArrayList();
            string sErr = "";
            string sList = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridCol选择)))
                {
                    string sCode = gridView1.GetRowCellValue(i, gridCol单据号).ToString().Trim();

                    int iRe = CheState(sCode);
                    if (iRe == -1)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "检查单据状态出错\n";
                        continue;
                    }
                    if (iRe == 0)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "单据不存在\n";
                        continue;
                    }
                    if (iRe == 1)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "单据未审核\n";
                        continue;
                    }
                    if (iRe == 3)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "单据已关闭\n";
                        continue;
                    }

                    //int iUsed = iCodeUsed(sCode); 
                    //if (iUsed == -1)
                    //{
                    //    sErr = sErr + "行" + (i + 1).ToString() + "检查后续单据状态出错\n";
                    //    continue;
                    //}
                    //if (iUsed > 0)
                    //{
                    //    sErr = sErr + "行" + (i + 1).ToString() + "单据已生成后续单据\n";
                    //    continue;
                    //}

                    sSQL = "update " + tablename + " set dVerifysysTime=null,dVerifysysPerson=null " +
                           "where ID=" + gridView1.GetRowCellValue(i, gridColID).ToString().Trim();
                    aList.Add(sSQL);

                    sList = sList + "行" + (i + 1).ToString() + "弃审成功\n";
                }
            }
            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MsgBox("弃审成功", sErr + "\n" + sList);
                GetGrid();
                checkEditChk.Checked = false;

                sState = "unaudit";
            }
            else
            {
                throw new Exception(sErr);
            }
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

            aList = new System.Collections.ArrayList();
            string sList = "";
            string sErr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridCol选择)))
                {
                    string sCode = gridView1.GetRowCellValue(i, gridCol单据号).ToString().Trim();

                    int iRe = CheState(sCode);
                    if (iRe == -1)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "检查单据状态出错\n";
                        continue;
                    }
                    if (iRe == 0)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "单据不存在\n";
                        continue;
                    }
                    if (iRe == 1)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "单据未审核\n";
                        continue;
                    }
                    if (iRe == 2)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "单据未关闭\n";
                        continue;
                    }
                    //if (iRe == 3)
                    //{
                    //    sErr = sErr + "行" + (i + 1).ToString() + "单据已关闭\n";
                    //    continue;
                    //}


                    sSQL = "update " + tablename + " set  dClosesysTime = null,dClosesysPerson = null " +
                           "where ID=" + gridView1.GetRowCellValue(i, gridColID).ToString().Trim();
                    aList.Add(sSQL);

                    sSQL = "update " + tablenames + " set  cClosesysTime = null,cClosesysPerson = null " +
                           "where AutoID=" + gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim();
                    aList.Add(sSQL);

                    sList = sList + "行" + (i + 1).ToString() + "打开成功\n";
                }
            }
            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MsgBox("打开成功", sErr + "\n" + sList);
                GetGrid();

                checkEditChk.Checked = false;
                sState = "open";
            }
            else
            {
                throw new Exception(sErr);
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

            aList = new System.Collections.ArrayList();
            string sList = "";
            string sErr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridCol选择)))
                {
                    string sCode = gridView1.GetRowCellValue(i, gridCol单据号).ToString().Trim();

                    int iRe = CheState(sCode);
                    if (iRe == -1)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "检查单据状态出错\n";
                        continue;
                    }
                    if (iRe == 0)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "单据不存在\n";
                        continue;
                    }
                    if (iRe == 1)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "单据未审核\n";
                        continue;
                    }
                    //if (iRe == 2)
                    //{
                    //    sErr = sErr + "行" + (i + 1).ToString() + "单据未关闭\n";
                    //    continue;
                    //}
                    if (iRe == 3)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "单据已关闭\n";
                        continue;
                    }

                    sSQL = "update " + tablename + " set  dClosesysTime='" + 系统服务.ClsBaseDataInfo.sLogDate + "',dClosesysPerson='" + 系统服务.ClsBaseDataInfo.sUid + "' " +
                           "where ID=" + gridView1.GetRowCellValue(i, gridColID).ToString().Trim();
                    aList.Add(sSQL);

                    sSQL = "update " + tablenames + " set  cClosesysTime='" + 系统服务.ClsBaseDataInfo.sLogDate + "',cClosesysPerson='" + 系统服务.ClsBaseDataInfo.sUid + "' " +
                           "where AutoID=" + gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim();
                    aList.Add(sSQL);

                    sList = sList + "行" + (i + 1).ToString() + "关闭成功\n";
                }
            }
            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MsgBox("关闭成功", sErr + "\n" + sList);
                GetGrid();

                checkEditChk.Checked = false;
                sState = "close";
            }
            else
            {
                throw new Exception(sErr);
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

        private void Frm调价单列表_Load(object sender, EventArgs e)
        {
            try
            {
                dateEdit1.DateTime = Convert.ToDateTime(DateTime.Today.ToString("yyyy-01-01"));
                dateEdit2.DateTime = Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-dd"));
                GetLabel();
                SetLookUpEdit();
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void SetLookUpEdit()
        {
            系统服务.LookUp.Inventory(ItemLookUpEditS1_1);
            ItemLookUpEditS1_1.Properties.DisplayMember = "cInvName";
            系统服务.LookUp.Inventory(ItemLookUpEditS1_2);
            ItemLookUpEditS1_2.Properties.DisplayMember = "cInvStd";
            系统服务.LookUp.Inventory3(ItemLookUpEdit存货代码);
        }

        private void GetLabel()
        {
            #region 表头
            sSQL = "select COLUMN_NAME,COLUMN_Text from _TableColInfo where TABLE_NAME='" + tablename + "' and TABLE_CATALOG='" + 系统服务.ClsBaseDataInfo.sDataBaseName + "'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                switch (dt.Rows[i]["COLUMN_NAME"].ToString())
                {
                    case "SS1":
                        gridColSS1.Caption = dt.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "SS2":
                        gridColSS2.Caption = dt.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "SS3":
                        gridColSS3.Caption = dt.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "SS4":
                        gridColSS4.Caption = dt.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "SS5":
                        gridColSS5.Caption = dt.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "SS6":
                        gridColSS6.Caption = dt.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "SS7":
                        gridColSS7.Caption = dt.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "SS8":
                        gridColSS8.Caption = dt.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "SS9":
                        gridColSS9.Caption = dt.Rows[i]["COLUMN_Text"].ToString();
                        break;

                    case "DD1":
                        gridColDD1.Caption = dt.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "DD2":
                        gridColDD2.Caption = dt.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "DD3":
                        gridColDD3.Caption = dt.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "DD4":
                        gridColDD4.Caption = dt.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "DD5":
                        gridColDD5.Caption = dt.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "DD6":
                        gridColDD6.Caption = dt.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "DD7":
                        gridColDD7.Caption = dt.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "DD8":
                        gridColDD8.Caption = dt.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "DD9":
                        gridColDD9.Caption = dt.Rows[i]["COLUMN_Text"].ToString();
                        break;

                    case "TT1":
                        gridColTT1.Caption = dt.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "TT2":
                        gridColTT2.Caption = dt.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "TT3":
                        gridColTT3.Caption = dt.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "TT4":
                        gridColTT4.Caption = dt.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "TT5":
                        gridColTT5.Caption = dt.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "TT6":
                        gridColTT6.Caption = dt.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "TT7":
                        gridColTT7.Caption = dt.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "TT8":
                        gridColTT8.Caption = dt.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "TT9":
                        gridColTT9.Caption = dt.Rows[i]["COLUMN_Text"].ToString();
                        break;
                }

            }
            #endregion

            #region 表体
            sSQL = "select COLUMN_NAME,COLUMN_Text from _TableColInfo where TABLE_NAME='" + tablenames + "' and TABLE_CATALOG='" + 系统服务.ClsBaseDataInfo.sDataBaseName + "'";
            DataTable dts = clsSQLCommond.ExecQuery(sSQL);
            for (int i = 0; i < dts.Rows.Count; i++)
            {
                switch (dts.Rows[i]["COLUMN_NAME"].ToString())
                {
                    case "S1":
                        gridColS1.Caption = dts.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "S2":
                        gridColS2.Caption = dts.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "S3":
                        gridColS3.Caption = dts.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "S4":
                        gridColS4.Caption = dts.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "S5":
                        gridColS5.Caption = dts.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "S6":
                        gridColS6.Caption = dts.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "S7":
                        gridColS7.Caption = dts.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "S8":
                        gridColS8.Caption = dts.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "S9":
                        gridColS9.Caption = dts.Rows[i]["COLUMN_Text"].ToString();
                        break;

                    case "D1":
                        gridColD1.Caption = dts.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "D2":
                        gridColD2.Caption = dts.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "D3":
                        gridColD3.Caption = dts.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "D4":
                        gridColD4.Caption = dts.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "D5":
                        gridColD5.Caption = dts.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "D6":
                        gridColD6.Caption = dts.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "D7":
                        gridColD7.Caption = dts.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "D8":
                        gridColD8.Caption = dts.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "D9":
                        gridColD9.Caption = dts.Rows[i]["COLUMN_Text"].ToString();
                        break;

                    case "T1":
                        gridColT1.Caption = dts.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "T2":
                        gridColT2.Caption = dts.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "T3":
                        gridColT3.Caption = dts.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "T4":
                        gridColT4.Caption = dts.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "T5":
                        gridColT5.Caption = dts.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "T6":
                        gridColT6.Caption = dts.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "T7":
                        gridColT7.Caption = dts.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "T8":
                        gridColT8.Caption = dts.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "T9":
                        gridColT9.Caption = dts.Rows[i]["COLUMN_Text"].ToString();
                        break;
                }

            }
            #endregion
        }

        private void GetGrid()
        {
            int iFocRow = gridView1.FocusedRowHandle;
            string sSQL = @"select cast(0 as bit) as iChk,a.*,b.*,0 as iChk, convert(varchar(10),dDate,120) as 单据日期,
convert(varchar(10),dCreatesysTime,120) as 制单日期,convert(varchar(10),dVerifysysTime,120) as 审核日期,
convert(varchar(10),dClosesysTime,120) as 关闭日期 from dbo." + tablename + " a left join " + tablenames + " b on a.ID=b.ID where 1=1 ";
            if (dateEdit1.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.dDate >= '" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "'");
            }
            if (dateEdit2.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.dDate < '" + dateEdit2.DateTime.AddDays(1).ToString("yyyy-MM-dd") + "'");
            }
            if (iCode1 != null && iCode1 != "")
            {
                sSQL = sSQL + " and a." + tableid + ">='" + iCode1 + "'";
            }
            if (iCode2 != null && iCode2 != "")
            {
                sSQL = sSQL + " and a." + tableid + "<='" + iCode2 + "'";
            }
            if (dDate1 != null && dDate1 != "")
            {
                sSQL = sSQL + " and dDate>='" + dDate1 + "'";
            }
            if (dDate2 != null && dDate2 != "")
            {
                sSQL = sSQL + " and dDate<='" + dDate2 + "'";
            }
            if (dCreatesysTime1 != null && dCreatesysTime1 != "")
            {
                sSQL = sSQL + " and dCreatesysTime>='" + dCreatesysTime1 + "'";
            }
            if (dCreatesysTime2 != null && dCreatesysTime2 != "")
            {
                sSQL = sSQL + " and dCreatesysTime<='" + dCreatesysTime2 + "'";
            }
            if (dCreatesysPerson1 != "")
            {
                sSQL = sSQL + " and dCreatesysPerson>='" + dCreatesysPerson1 + "'";
            }
            if (dCreatesysPerson2 != "")
            {
                sSQL = sSQL + " and dCreatesysPerson<='" + dCreatesysPerson2 + "'";
            }
            if (dVerifysysTime1 != "")
            {
                sSQL = sSQL + " and dVerifysysTime>='" + dVerifysysTime1 + "'";
            }
            if (dVerifysysTime2 != "")
            {
                sSQL = sSQL + " and dVerifysysTime<='" + dVerifysysTime2 + "'";
            }
            if (dVerifysysPerson1 != "")
            {
                sSQL = sSQL + " and dVerifysysPerson>='" + dVerifysysPerson1 + "'";
            }
            if (dVerifysysPerson2 != "")
            {
                sSQL = sSQL + " and dVerifysysPerson<='" + dVerifysysPerson2 + "'";
            }
            if (S1_1 != "")
            {
                sSQL = sSQL + " and S1='" + S1_1 + "'";
            }
            if (S1_2 != "")
            {
                sSQL = sSQL + " and S1='" + S1_2 + "'";
            }
            sSQL = sSQL + " order by  a." + tableid;
            dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dtBingGrid;
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

        private void checkEditChk_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                gridView1.SetRowCellValue(i, gridCol选择, checkEditChk.Checked);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int iRow = gridView1.FocusedRowHandle;
                if (iRow < 0)
                    return;

                string sID = gridView1.GetRowCellValue(iRow, gridColID).ToString().Trim();
                if (sID == "")
                    return;

                Frm调价单 frm = new Frm调价单(sID);
                frm.Tag = frm.Name;
                frm.MdiParent = this.MdiParent;

                frm.Show();
                if (DialogResult.OK == frm.ShowDialog())
                {
                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            { }
        }

        private void ItemCheckEdit选择_CheckedChanged(object sender, EventArgs e)
        {
            int iRow = gridView1.FocusedRowHandle;
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            string sCode = gridView1.GetRowCellValue(iRow, gridCol单据号).ToString().Trim();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (i == iRow)
                    continue;
                string sCode2 = gridView1.GetRowCellValue(i, gridCol单据号).ToString().Trim();
                if (sCode == sCode2)
                {
                    gridView1.SetRowCellValue(i, gridCol选择, Convert.ToBoolean(gridView1.GetRowCellValue(iRow, gridCol选择)));
                }
            }
        }

        /// <summary>
        /// 判断单据状态
        /// </summary>
        /// <param name="sCode">单据号</param>
        /// <returns>-1：出错</returns>
        /// <returns>0 ：不存在单据</returns>
        /// <returns>1 ：已保存</returns>
        /// <returns>2 ：已审核</returns>
        /// <returns>3 ：已关闭</returns>
        private int CheState(string sCode)
        {
            int iReturn = -1;
            try
            {
                sSQL = "select  isnull(dCreatesysPerson,'') as 制单人,isnull(dVerifysysPerson,'') as 审核人,isnull(dClosesysPerson,'') as 关闭人 from " + tablename + " where iCode = '" + sCode + "'";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count < 1)
                    iReturn = 0;
                else
                {
                    if (dt.Rows[0]["制单人"].ToString().Trim() != "")
                    {
                        iReturn = 1;
                    }
                    if (dt.Rows[0]["审核人"].ToString().Trim() != "")
                    {
                        iReturn = 2;
                    }
                    if (dt.Rows[0]["关闭人"].ToString().Trim() != "")
                    {
                        iReturn = 3;
                    }

                    sSQL = "select count(1) from PO_POMain a inner join PO_PODetails b on a.id = b.id where a.cPOCode = '" + sCode + "' and isnull(cClosesysPerson,'') <> ''";
                    long iCou = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                    if (iCou > 0)
                    {
                        iReturn = 3;
                    }
                }
            }
            catch (Exception ee)
            { }
            return iReturn;
        }

        ///// <summary>
        ///// 判断单据是否已经使用
        ///// </summary>
        ///// <param name="sCode">单据号</param>
        ///// <returns></returns>
        //private int iCodeUsed(string sCode)
        //{
        //    int iReturn = -1;
        //    try
        //    {
        //        sSQL = "select count(1) from dbo.PO_POMain a inner join dbo.PO_PODetails b on a.ID = b.ID inner join dbo.RdRecords c on c.POAutoID = b.AutoID " +
        //               "where a.cPOCode = '" + sCode + "'";
        //        iReturn = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
        //    }
        //    catch (Exception ee)
        //    { }
        //    return iReturn;
        //}
    }
}