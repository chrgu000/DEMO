using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraEditors;

namespace 销售
{
    public partial class Frm调价单 : 系统服务.FrmBaseInfo
    {
        string tablename = "PriceAdjust_Main";
        string tableid = "ID";
        string tablecode = "iCode";
        string tablenames = "PriceAdjust_Details";

        string cSQL = " and BB1=0";

        string iID = "";
        string isChange = "";

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

        public Frm调价单(string siID)
        {
            iID = siID;
            InitializeComponent();
            
        }

        public Frm调价单()
        {
            InitializeComponent();

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
                    case "add":
                        btnAdd();
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
            
            return null;
        }

        /// <summary>
        /// 打印
        /// </summary>
        private void btnPrint()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 输出
        /// </summary>
        private void btnExport()
        {
            throw new NotImplementedException();
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
            SetLookUpEdit();
            GetGrid();
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
            Frm调价单_Add frm = new Frm调价单_Add(iCode1, iCode2, dDate1, dDate2, dCreatesysTime1, dCreatesysTime2, dVerifysysTime1, dVerifysysTime2, dCreatesysPerson1, dCreatesysPerson2, dVerifysysPerson1, dVerifysysPerson2, S1_1,S1_2);
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
                GetSel();
            }

        }

        private void GetSel()
        {
            string sSQL = "select * from " + tablename + " a left join " + tablenames + "  b on a.ID=b.ID where 1=1 " + cSQL;
            if (iCode1 != null && iCode1 != "")
            {
                sSQL = sSQL + " and a." + tablecode + ">='" + iCode1 + "'";
            }
            if (iCode2 != null && iCode2 != "")
            {
                sSQL = sSQL + " and a." + tablecode + "<='" + iCode2 + "'";
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
            sSQL = sSQL + "  order by a.ID";
            dtSel = clsSQLCommond.ExecQuery(sSQL);
            if (dtSel.Rows.Count > 0)
            {
                iID = dtSel.Rows[0]["ID"].ToString();
                GetGrid();
            }
            else
            {
                btnLast();
            }

        }

        /// <summary>
        /// 首页
        /// </summary>
        private void btnFirst()
        {
            try
            {
                sSQL = "select min(ID) as ID from " + tablename + " where 1=1 "+cSQL;
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    textEditID.EditValue = dt.Rows[0]["ID"].ToString();
                    iID = dt.Rows[0]["ID"].ToString();
                }
                GetSelBind();
            }
            catch
            {
                MessageBox.Show("未知错误");
            }
        }
        /// <summary>
        /// 上页
        /// </summary>
        private void btnPrev()
        {
            try
            {
                if (iID != "")
                {
                    sSQL = "select ID from " + tablename + " where ID<" + textEditID.EditValue.ToString().Trim() + cSQL;
                    sSQL=sSQL+" order by ID desc";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt.Rows.Count > 0)
                    {
                        textEditID.EditValue = dt.Rows[0]["ID"].ToString();
                        iID = dt.Rows[0]["ID"].ToString();
                    }
                    GetSelBind();
                }
            }
            catch
            {
                MessageBox.Show("未知错误");
            }
        }
        /// <summary>
        /// 下页
        /// </summary>
        private void btnNext()
        {
            try
            {
                if (iID != "")
                {
                    sSQL = "select ID from " + tablename + " where ID>" + textEditID.EditValue.ToString().Trim() + cSQL;
                    sSQL=sSQL+" order by ID ";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt.Rows.Count > 0)
                    {
                        textEditID.EditValue = dt.Rows[0]["ID"].ToString();
                        iID = dt.Rows[0]["ID"].ToString();
                    }
                    GetSelBind();
                }
            }
            catch
            {
                MessageBox.Show("未知错误");
            }
        }
        /// <summary>
        /// 末页
        /// </summary>
        private void btnLast()
        {
            try
            {
                sSQL = "select max(ID) as ID from " + tablename + " where 1=1 "+cSQL;
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    textEditID.EditValue = dt.Rows[0]["ID"].ToString();
                    iID = dt.Rows[0]["ID"].ToString();
                }
                GetSelBind();
            }
            catch
            {
                MessageBox.Show("未知错误");
            }
        }

        private void GetSelBind()
        {
            GetGrid();
            SetEnabled(false);
            sState = "";
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
            throw new NotImplementedException();
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
                    if (gridView1.GetRowCellDisplayText(i, gridColAutoID).ToString().Trim() != "")
                    {
                        if (textEditDel.EditValue!=null && textEditDel.EditValue.ToString().Trim() != "")
                        {
                            textEditDel.EditValue = textEditDel.EditValue.ToString().Trim() + "," + gridView1.GetRowCellDisplayText(i, gridColAutoID).ToString().Trim();
                        }
                        else
                        {
                            textEditDel.EditValue = gridView1.GetRowCellDisplayText(i, gridColAutoID).ToString().Trim();
                        }
                    }
                    gridView1.DeleteRow(i);
                }
            }
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellDisplayText(i, gridColiRowNo).ToString().Trim() != "")
                {
                    gridView1.SetRowCellValue(i, gridColiRowNo, i + 1);
                }
            }
        }
        /// <summary>
        /// 新增
        /// </summary>
        private void btnAdd()
        {
            GetNull();
            SetEnabled(true);
            dateEditdDate.EditValue = 系统服务.ClsBaseDataInfo.sLogDate;

            int iFocRow = gridView1.FocusedRowHandle;

            sSQL = "select *, 'edit' as iSave,cast(null as decimal(16,6)) as 引用量,cast(null as decimal(16,6)) as 历史数量 " +
                    "from " + tablenames + "  where 1=-1";
            dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dtBingGrid;
            try
            {
                gridView1.FocusedColumn = gridColiRowNo;
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
                gridView1.Focus();
            }
            catch { }

            gridView1.AddNewRow();
            gridView1.FocusedRowHandle = 0;


            gridView1.OptionsBehavior.Editable = true;
            sState = "add";
        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {
            if (textEditiCode.Text.Trim() == "")
            {
                throw new Exception("请选择需要修改的单据");
            }

            int iRe = CheState(textEditiCode.Text.Trim());
            if(iRe == -1)
            {
                throw new Exception("检查单据状态出错");
            } 
            if (iRe == 0)
            {
                throw new Exception("单据不存在");
            } 
            //if (iRe == 1)
            //{
            //    throw new Exception("单据已保存");
            //} 
            if (iRe == 2)
            {
                throw new Exception("单据已审核");
            }
            if (iRe == 3)
            {
                throw new Exception("单据已关闭");
            }

            SetEnabled(true);
            sState = "edit";
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
            if (textEditID.Text.Trim() == "")
                throw new Exception("请选择需要删除的单据");

            if (textEditiCode.Text.Trim() == "")
            {
                throw new Exception("请选择需要修改的单据");
            }

            int iRe = CheState(textEditiCode.Text.Trim());
            if (iRe == -1)
            {
                throw new Exception("检查单据状态出错");
            }
            if (iRe == 0)
            {
                throw new Exception("单据不存在");
            }
            //if (iRe == 1)
            //{
            //    throw new Exception("单据已保存");
            //} 
            if (iRe == 2)
            {
                throw new Exception("单据已审核");
            }
            if (iRe == 3)
            {
                throw new Exception("单据已关闭");
            }
            DialogResult result = MessageBox.Show("是否删除?", "删除提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                string sErr = "";

                aList = new System.Collections.ArrayList();
                sSQL = "delete " + tablename + " where ID = " + textEditID.Text.Trim();
                aList.Add(sSQL);
                sSQL = "delete " + tablenames + " where ID = " + textEditID.Text.Trim();
                aList.Add(sSQL);

               
                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("删除成功！\n合计执行语句:" + iCou + "条");
                    GetGrid();

                    sState = "del";
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
                gridView1.FocusedColumn = gridColiRowNo;
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
                gridView1.Focus();
            }
            catch { }

            int iRe = CheState(textEditiCode.Text.Trim());
            if (iRe == -1)
            {
                throw new Exception("检查单据状态出错");
            }
            if (iRe == 0 && (sState == "edit" || sState == "alter"))
            {
                throw new Exception("单据不存在");
            }
            if (iRe == 1 && sState == "alter")
            {
                throw new Exception("单据未审核");
            }
            if (iRe == 2 && sState == "edit")
            {
                throw new Exception("单据已审核");
            }
            if (iRe == 3)
            {
                throw new Exception("单据已关闭");
            }

            string sErr = "";

            sSQL = "select * from " + tablename + " where 1=-1";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            sSQL = "select * from " + tablenames + " where 1=-1";
            DataTable dts = clsSQLCommond.ExecQuery(sSQL);

            if(dateEditdDate.EditValue.ToString().Trim() == "")
            {
                sErr = sErr + "单据日期不能为空\n";
            }

            aList = new System.Collections.ArrayList();
            DataRow drh = dt.NewRow();
            if (sState == "add")
            {
                sSQL = "select isnull(max(ID)+1,1) as ID from " + tablename;
                iID = clsSQLCommond.ExecQuery(sSQL).Rows[0][0].ToString();
                drh["ID"] = iID;
                textEditiCode.EditValue = clsPublic.GetNewSerialNumberContinuous(tablename, tablecode);
            }
            else
            {
                drh["ID"] = textEditID.EditValue.ToString().Trim();
                iID = textEditID.EditValue.ToString().Trim();
            }
            drh["iCode"] = textEditiCode.EditValue.ToString().Trim();
            drh["dDate"] = dateEditdDate.EditValue.ToString().Trim();
            drh["BB1"] = 0;

            drh["dMemo"] = textEditdMemo.EditValue.ToString().Trim();

            if (sState == "add")
            {
                dateEditdCreatesysTime.EditValue = GetSystemTime();
                textEditdCreatesysPerson.EditValue = 系统服务.ClsBaseDataInfo.sUid;
            }

            drh["dCreatesysTime"] = dateEditdCreatesysTime.EditValue.ToString().Trim();
            drh["dCreatesysPerson"] = textEditdCreatesysPerson.EditValue.ToString().Trim();

            if (sState == "add")
            {
                dateEditdCreatesysTime.EditValue = GetSystemTime();
                textEditdCreatesysPerson.EditValue = 系统服务.ClsBaseDataInfo.sUid;
            }

            drh["dCreatesysTime"] = dateEditdCreatesysTime.EditValue.ToString().Trim();
            drh["dCreatesysPerson"] = textEditdCreatesysPerson.EditValue.ToString().Trim();

            if (sState == "alter")
            {
                drh["dVerifysysPerson"] = textEditdVerifysysPerson.Text.Trim();
                drh["dVerifysysTime"] = dateEditdVerifysysTime.Text.Trim();
                drh["dChangeVerifyTime"] = GetSystemTime();
                drh["dChangeVerifyPerson"] = 系统服务.ClsBaseDataInfo.sUid;
            }
            dt.Rows.Add(drh);

            if (sState == "add")
            {
                sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablename, dt, 0);
                aList.Add(sSQL);
            }
            if (sState == "alter" || sState == "edit")
            {
                sSQL = clsGetSQL.GetUpdateSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablename, dt, 0);
                aList.Add(sSQL);
            }

            #region 更新变更表
            if (sState == "alter")
            {
                clsPublic.GetChange(tablename, tablenames, textEditID.EditValue.ToString().Trim(), clsGetSQL, aList);
            }
            #endregion

            #region 删行
            if (textEditDel.EditValue != null && textEditDel.EditValue.ToString().Trim() != "")
            {
                clsPublic.GetChangeDelRow(tablenames, textEditDel.EditValue.ToString().Trim(), aList);
            }
            #endregion


            #region 子表

            sSQL = "select isnull(max(AutoID)+1,1) as AutoID from " + tablenames;
            long sAutoID = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "edit" || gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "update" || gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "add")
                {
                    #region 判断
                    if (gridView1.GetRowCellDisplayText(i, gridColS1).ToString().Trim() == "")
                    {
                        continue;
                    }

                    if (gridView1.GetRowCellValue(i, gridColD1).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + gridColD1.Caption + "不能为空\n";
                        continue;
                    }

                    if (gridView1.GetRowCellValue(i, gridColS2).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + gridColS2.Caption + "不能为空\n";
                        continue;
                    }

                    if (gridView1.GetRowCellValue(i, gridColT1).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + gridColT1.Caption + "不能为空\n";
                        continue;
                    }

                    #endregion

                    #region 判断是否重复
                    bool b = false;
                    for (int j = 0; j < i; j++)
                    {
                        if (gridView1.GetRowCellDisplayText(i, gridColS1).ToString().Trim() == gridView1.GetRowCellDisplayText(j, gridColS1).ToString().Trim()
                            && gridView1.GetRowCellDisplayText(i, gridColS2).ToString().Trim() == gridView1.GetRowCellDisplayText(j, gridColS2).ToString().Trim()
                            && gridView1.GetRowCellDisplayText(i, gridColT1).ToString().Trim() == gridView1.GetRowCellDisplayText(j, gridColT1).ToString().Trim())
                        {
                            sErr = sErr + "行" + (i + 1)  + "该物料,同日期,同客户等级不可以重复\n";
                            b = true;
                            continue;
                        }
                    }
                    if (b == false)
                    {
                        sSQL = "select * from " + tablenames + " where S1='" + gridView1.GetRowCellDisplayText(i, gridColS1).ToString().Trim() + "' "
                            + " and S2='" + gridView1.GetRowCellDisplayText(i, gridColS2).ToString().Trim() + "'"
                            + "and convert(varchar(10),T1,120)='" + DateTime.Parse(gridView1.GetRowCellDisplayText(i, gridColT1).ToString().Trim()).ToString("yyyy-MM-dd") + "' and B1=0";
                        if (gridView1.GetRowCellDisplayText(i, gridColAutoID).ToString().Trim() != "")
                        {
                            sSQL = sSQL + " and AutoID='" + gridView1.GetRowCellDisplayText(i, gridColAutoID).ToString().Trim() + "'";
                        }
                        DataTable dt重复 = clsSQLCommond.ExecQuery(sSQL);
                        if (dt重复.Rows.Count > 0)
                        {
                            sErr = sErr + "行" + (i + 1) + "该物料,同日期,同客户等级不可以重复\n";
                            continue;
                        }
                    }

                    #endregion

                    #region 生成table
                    DataRow dr = dts.NewRow();
                    if (gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim() == "")
                    {
                        dr["AutoID"] = sAutoID;
                    }
                    else
                    {
                        dr["AutoID"] = gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim();
                    }
                    dr["ID"] = iID;
                    dr["iCode"] = textEditiCode.EditValue.ToString().Trim();
                    dr["iRowNo"] = gridView1.GetRowCellValue(i, gridColiRowNo).ToString().Trim();
                    dr["cMemo"] = gridView1.GetRowCellValue(i, gridColcMemo).ToString().Trim();

                    #region S
                    dr["S1"] = gridView1.GetRowCellValue(i, gridColS1).ToString().Trim();
                    dr["S2"] = gridView1.GetRowCellValue(i, gridColS2).ToString().Trim();
                    dr["S3"] = gridView1.GetRowCellValue(i, gridColS3).ToString().Trim();
                    dr["S4"] = gridView1.GetRowCellValue(i, gridColS4).ToString().Trim();
                    dr["S5"] = gridView1.GetRowCellValue(i, gridColS5).ToString().Trim();
                    dr["S6"] = gridView1.GetRowCellValue(i, gridColS6).ToString().Trim();
                    dr["S7"] = gridView1.GetRowCellValue(i, gridColS7).ToString().Trim();
                    dr["S8"] = gridView1.GetRowCellValue(i, gridColS8).ToString().Trim();
                    dr["S9"] = gridView1.GetRowCellValue(i, gridColS9).ToString().Trim();
                    #endregion

                    #region D
                    if (gridView1.GetRowCellValue(i, gridColD1) != null && gridView1.GetRowCellValue(i, gridColD1).ToString().Trim() != "")
                    {
                        dr["D1"] = gridView1.GetRowCellValue(i, gridColD1).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridColD2) != null && gridView1.GetRowCellValue(i, gridColD2).ToString().Trim() != "")
                    {
                        dr["D2"] = gridView1.GetRowCellValue(i, gridColD2).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridColD3) != null && gridView1.GetRowCellValue(i, gridColD3).ToString().Trim() != "")
                    {
                        dr["D3"] = gridView1.GetRowCellValue(i, gridColD3).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridColD4) != null && gridView1.GetRowCellValue(i, gridColD4).ToString().Trim() != "")
                    {
                        dr["D4"] = gridView1.GetRowCellValue(i, gridColD4).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridColD5) != null && gridView1.GetRowCellValue(i, gridColD5).ToString().Trim() != "")
                    {
                        dr["D5"] = gridView1.GetRowCellValue(i, gridColD5).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridColD6) != null && gridView1.GetRowCellValue(i, gridColD6).ToString().Trim() != "")
                    {
                        dr["D6"] = gridView1.GetRowCellValue(i, gridColD6).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridColD7) != null && gridView1.GetRowCellValue(i, gridColD7).ToString().Trim() != "")
                    {
                        dr["D7"] = gridView1.GetRowCellValue(i, gridColD7).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridColD8) != null && gridView1.GetRowCellValue(i, gridColD8).ToString().Trim() != "")
                    {
                        dr["D8"] = gridView1.GetRowCellValue(i, gridColD8).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridColD9) != null && gridView1.GetRowCellValue(i, gridColD9).ToString().Trim() != "")
                    {
                        dr["D9"] = gridView1.GetRowCellValue(i, gridColD9).ToString().Trim();
                    }
                    #endregion

                    #region T
                    if (gridView1.GetRowCellValue(i, gridColT1) != null && gridView1.GetRowCellValue(i, gridColT1).ToString().Trim() != "")
                    {
                        dr["T1"] = gridView1.GetRowCellValue(i, gridColT1).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridColT2) != null && gridView1.GetRowCellValue(i, gridColT2).ToString().Trim() != "")
                    {
                        dr["T2"] = gridView1.GetRowCellValue(i, gridColT2).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridColT3) != null && gridView1.GetRowCellValue(i, gridColT3).ToString().Trim() != "")
                    {
                        dr["T3"] = gridView1.GetRowCellValue(i, gridColT3).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridColT4) != null && gridView1.GetRowCellValue(i, gridColT4).ToString().Trim() != "")
                    {
                        dr["T4"] = gridView1.GetRowCellValue(i, gridColT4).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridColT5) != null && gridView1.GetRowCellValue(i, gridColT5).ToString().Trim() != "")
                    {
                        dr["T5"] = gridView1.GetRowCellValue(i, gridColT5).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridColT6) != null && gridView1.GetRowCellValue(i, gridColT6).ToString().Trim() != "")
                    {
                        dr["T6"] = gridView1.GetRowCellValue(i, gridColT6).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridColT7) != null && gridView1.GetRowCellValue(i, gridColT7).ToString().Trim() != "")
                    {
                        dr["T7"] = gridView1.GetRowCellValue(i, gridColT7).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridColT8) != null && gridView1.GetRowCellValue(i, gridColT8).ToString().Trim() != "")
                    {
                        dr["T8"] = gridView1.GetRowCellValue(i, gridColT8).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridColT9) != null && gridView1.GetRowCellValue(i, gridColT9).ToString().Trim() != "")
                    {
                        dr["T9"] = gridView1.GetRowCellValue(i, gridColT9).ToString().Trim();
                    }
                    #endregion

                    #region B
                    //if (gridView1.GetRowCellValue(i, gridColB1) != null && gridView1.GetRowCellValue(i, gridColB1).ToString().Trim() == "True")
                    //{
                    //    dr["B1"] = gridView1.GetRowCellValue(i, gridColB1).ToString().Trim();
                    //}
                    //else
                    //{
                        dr["B1"] = 0;
                    //}
                    //if (gridView1.GetRowCellValue(i, gridColB2) != null && gridView1.GetRowCellValue(i, gridColB2).ToString().Trim() == "True")
                    //{
                    //    dr["B2"] = gridView1.GetRowCellValue(i, gridColB2).ToString().Trim();
                    //}
                    //else
                    //{
                    //    dr["B2"] = 0;
                    //}
                    //if (gridView1.GetRowCellValue(i, gridColB3) != null && gridView1.GetRowCellValue(i, gridColB3).ToString().Trim() == "True")
                    //{
                    //    dr["B3"] = gridView1.GetRowCellValue(i, gridColB3).ToString().Trim();
                    //}
                    //else
                    //{
                    //    dr["B3"] = 0;
                    //}
                    //if (gridView1.GetRowCellValue(i, gridColB4) != null && gridView1.GetRowCellValue(i, gridColB4).ToString().Trim() == "True")
                    //{
                    //    dr["B4"] = gridView1.GetRowCellValue(i, gridColB4).ToString().Trim();
                    //}
                    //else
                    //{
                    //    dr["B4"] = 0;
                    //}
                    //if (gridView1.GetRowCellValue(i, gridColB5) != null && gridView1.GetRowCellValue(i, gridColB5).ToString().Trim() == "True")
                    //{
                    //    dr["B5"] = gridView1.GetRowCellValue(i, gridColB5).ToString().Trim();
                    //}
                    //else
                    //{
                    //    dr["B5"] = 0;
                    //}
                    //if (gridView1.GetRowCellValue(i, gridColB6) != null && gridView1.GetRowCellValue(i, gridColB6).ToString().Trim() == "True")
                    //{
                    //    dr["B6"] = gridView1.GetRowCellValue(i, gridColB6).ToString().Trim();
                    //}
                    //else
                    //{
                    //    dr["B6"] = 0;
                    //}
                    //if (gridView1.GetRowCellValue(i, gridColB7) != null && gridView1.GetRowCellValue(i, gridColB7).ToString().Trim() == "True")
                    //{
                    //    dr["B7"] = gridView1.GetRowCellValue(i, gridColB7).ToString().Trim();
                    //}
                    //else
                    //{
                    //    dr["B7"] = 0;
                    //}
                    //if (gridView1.GetRowCellValue(i, gridColB8) != null && gridView1.GetRowCellValue(i, gridColB8).ToString().Trim() == "True")
                    //{
                    //    dr["B8"] = gridView1.GetRowCellValue(i, gridColB8).ToString().Trim();
                    //}
                    //else
                    //{
                    //    dr["B8"] = 0;
                    //}
                    //if (gridView1.GetRowCellValue(i, gridColB9) != null && gridView1.GetRowCellValue(i, gridColB9).ToString().Trim() == "True")
                    //{
                    //    dr["B9"] = gridView1.GetRowCellValue(i, gridColB9).ToString().Trim();
                    //}
                    //else
                    //{
                    //    dr["B9"] = 0;
                    //}
                    #endregion

                    dts.Rows.Add(dr);
                    #endregion

                    if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "update" || gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "edit")
                    {
                        sSQL = clsGetSQL.GetUpdateSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablenames, dts, dts.Rows.Count - 1);
                    }
                    if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "add")
                    {
                        sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablenames, dts, dts.Rows.Count - 1);
                    }

                    aList.Add(sSQL);
                    sAutoID = sAutoID + 1;
                }
            }
            #endregion


            if (sErr.Length != 0)
            {
                throw new Exception(sErr.ToString());
            }

            if (dt == null || dt.Rows.Count <= 0)
            {
                throw new Exception("表头不能为空");
            }
            if (dts == null || dts.Rows.Count <= 0)
            {
                throw new Exception("表体不能为空");
            }


            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("保存成功！\n合计执行语句:" + iCou + "条");
                textEditID.EditValue = iID;
                GetSelBind();
                sState = "save";
                SetEnabled(false);

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
            if (textEditiCode.Text.Trim() == "")
            {
                throw new Exception("请选择需要审核的单据");
            }

            int iRe = CheState(textEditiCode.Text.Trim());
            if (iRe == -1)
            {
                throw new Exception("检查单据状态出错");
            }
            if (iRe == 0)
            {
                throw new Exception("单据不存在");
            }
            //if (iRe == 1)
            //{
            //    throw new Exception("单据已保存");
            //} 
            if (iRe == 2)
            {
                throw new Exception("单据已审核");
            }
            if (iRe == 3)
            {
                throw new Exception("单据已关闭");
            }

            aList = new System.Collections.ArrayList();

            sSQL = "update " + tablename + " set dVerifysysTime='" + GetSystemTime() + "',dVerifysysPerson='" + 系统服务.ClsBaseDataInfo.sUid + "' where ID=" + textEditID.EditValue.ToString().Trim() + "";
            aList.Add(sSQL);

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("审核成功！\n合计执行语句:" + iCou + "条");

                textEditdVerifysysPerson.Text = 系统服务.ClsBaseDataInfo.sUid;
                dateEditdVerifysysTime.Text = GetSystemTime();
                sState = "audit";
            }
        }
        /// <summary>
        /// 弃审
        /// </summary>
        private void btnUnAudit()
        {
            if (textEditiCode.Text.Trim() == "")
            {
                throw new Exception("请选择需要弃审的单据");
            }

            int iRe = CheState(textEditiCode.Text.Trim());
            if (iRe == -1)
            {
                throw new Exception("检查单据状态出错");
            }
            if (iRe == 0)
            {
                throw new Exception("单据不存在");
            }
            if (iRe == 1)
            {
                throw new Exception("单据未审核");
            } 
            //if (iRe == 2)
            //{
            //    throw new Exception("单据已审核");
            //}
            if (iRe == 3)
            {
                throw new Exception("单据已关闭");
            }
            //int iUsed= iCodeUsed(textEdit单据号.Text.Trim());
            //if (iUsed > 0)
            //{
            //    throw new Exception("单据已引用");
            //}

            aList = new System.Collections.ArrayList();

            sSQL = "update " + tablename + " set dVerifysysTime=null,dVerifysysPerson=null where ID=" + textEditID.EditValue.ToString().Trim() + "";
            aList.Add(sSQL);

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("弃审成功！\n合计执行语句:" + iCou + "条");
                textEditdVerifysysPerson.Text = "";
                dateEditdVerifysysTime.Text = "";
                sState = "unaudit";
            }
        }
        /// <summary>
        /// 打开
        /// </summary>
        private void btnOpen()
        {
            int iRe = CheState(textEditiCode.Text.Trim());
            if (iRe == -1)
            {
                throw new Exception("检查单据状态出错");
            }
            if (iRe == 0)
            {
                throw new Exception("单据不存在");
            }
            if (iRe == 1)
            {
                throw new Exception("单据未审核");
            }
            if (iRe == 2)
            {
                throw new Exception("单据未关闭");
            }
            //if (iRe == 3)
            //{
            //    throw new Exception("单据已关闭");
            //}

            aList = new System.Collections.ArrayList();

            sSQL = "update " + tablename + " set dClosesysTime=null,dClosesysPerson=null where ID=" + textEditID.EditValue.ToString().Trim() + "";
            aList.Add(sSQL);
            sSQL = "update " + tablenames + " set cClosesysTime=null,cClosesysPerson=null where ID=" + textEditID.EditValue.ToString().Trim() + " ";
            aList.Add(sSQL);

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("打开成功！\n合计执行语句:" + iCou + "条");

                textEditdClosesysPerson.Text = "";
                dateEditdClosesysTime.Text = "";
                sState = "open";
            }
        }
        /// <summary>
        /// 关闭
        /// </summary>
        private void btnClose()
        {
            int iRe = CheState(textEditiCode.Text.Trim());
            if (iRe == -1)
            {
                throw new Exception("检查单据状态出错");
            }
            if (iRe == 0)
            {
                throw new Exception("单据不存在");
            }
            if (iRe == 1)
            {
                throw new Exception("单据未审核");
            }
            //if (iRe == 2)
            //{
            //    throw new Exception("单据已审核");
            //}
            if (iRe == 3)
            {
                throw new Exception("单据已关闭");
            }


            aList = new System.Collections.ArrayList();

            sSQL = "update " + tablename + " set dClosesysTime='" + GetSystemTime() + "',dClosesysPerson='" + 系统服务.ClsBaseDataInfo.sUid + "' where ID=" + textEditID.EditValue.ToString().Trim() + "";
            aList.Add(sSQL);
            sSQL = "update " + tablenames + " set cClosesysTime='" + GetSystemTime() + "',cClosesysPerson='" + 系统服务.ClsBaseDataInfo.sUid + "' where ID=" + textEditID.EditValue.ToString().Trim() + " and  (cClosesysPerson='' or cClosesysPerson is null)";
            aList.Add(sSQL);
            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("关闭成功！\n合计执行语句:" + iCou + "条");

                textEditdClosesysPerson.Text = 系统服务.ClsBaseDataInfo.sUid;
                dateEditdClosesysTime.Text = GetSystemTime();
                sState = "close";
            }
        }
        /// <summary>
        /// 变更
        /// </summary>
        private void btnAlter()
        {
            int iRe = CheState(textEditiCode.Text.Trim());
            if (iRe == -1)
            {
                throw new Exception("检查单据状态出错");
            }
            if (iRe == 0)
            {
                throw new Exception("单据不存在");
            }
            if (iRe == 1)
            {
                throw new Exception("单据未审核");
            }
            //if (iRe == 2)
            //{
            //    throw new Exception("单据已审核");
            //}
            if (iRe == 3)
            {
                throw new Exception("单据已关闭");
            }

            //for (int i = 0; i < gridView1.RowCount; i++)
            //{
            //    if (gridView1.GetRowCellValue(i, gridCol物料编码).ToString().Trim() == "")
            //        continue;

            //    long lAutoID = Convert.ToInt64(gridView1.GetRowCellValue(i, gridColAutoID));
            //    gridView1.SetRowCellValue(i,gridCol引用量, iCodeUsed(lAutoID));
            //}

            SetEnabled(true);
            sState = "alter";
        }

        #endregion

        private void Frm调价单_Load(object sender, EventArgs e)
        {
            try
            {
                GetLayOut(layoutControl1, gridControl1);
                GetLabel();
                SetLookUpEdit();
                if (iID != "")
                {
                    GetGrid();
                }
                else
                {
                    btnLast();
                }
                
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void GetGrid()
        {
            if (iID != "")
            {

                sSQL = "select * from " + tablename + " where ID=" + iID + cSQL;
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    textEditID.EditValue = dt.Rows[0]["ID"].ToString();
                    textEditiCode.EditValue = dt.Rows[0]["iCode"].ToString();
                    dateEditdDate.EditValue = dt.Rows[0]["dDate"].ToString();
                    dateEditdCreatesysTime.EditValue = dt.Rows[0]["dCreatesysTime"].ToString();
                    dateEditdVerifysysTime.EditValue = dt.Rows[0]["dVerifysysTime"].ToString();
                    dateEditdClosesysTime.EditValue = dt.Rows[0]["dClosesysTime"].ToString();
                    textEditdCreatesysPerson.EditValue = dt.Rows[0]["dCreatesysPerson"].ToString();
                    textEditdVerifysysPerson.EditValue = dt.Rows[0]["dVerifysysPerson"].ToString();
                    textEditdClosesysPerson.EditValue = dt.Rows[0]["dClosesysPerson"].ToString();
                    textEditdMemo.EditValue = dt.Rows[0]["dMemo"].ToString();

                    sSQL = "select *, 'edit' as iSave,cast(null as decimal(16,6)) as 引用量,cast(D1 as decimal(16,6)) as 历史数量 " +
                        "from " + tablenames + " where ID=" + iID + " order by iRowNo";

                    dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
                    gridControl1.DataSource = dtBingGrid;

                    
                    gridView1.AddNewRow();

                    gridView1.FocusedRowHandle = iFocRow;

                    SetEnabled(false);

                }
                else
                {
                    GetNull();
                    SetEnabled(false);
                }
            }
            else
            {
                GetNull();
                SetEnabled(false);
            }
        }

        /// <summary>
        /// 下拉列表框
        /// </summary>
        private void SetLookUpEdit()
        {
            系统服务.LookUp.CustomerLevel(ItemLookUpEdit客户等级);

            系统服务.LookUp.Inventory(ItemLookUpEdit物料名称);
            ItemLookUpEdit物料名称.Properties.DisplayMember = "cInvName";
            系统服务.LookUp.Inventory(ItemLookUpEdit物料规格);
            ItemLookUpEdit物料规格.Properties.DisplayMember = "cInvStd";
            系统服务.LookUp.Inventory(ItemLookUpEdit物料代码);
            ItemLookUpEdit物料规格.Properties.DisplayMember = "cInvAddCode";
        }

        private void GetLabel()
        {
            #region 表体
            sSQL = "select COLUMN_NAME,COLUMN_Text from _TableColInfo where TABLE_NAME='" + tablenames + "' and TABLE_CATALOG='" + 系统服务.ClsBaseDataInfo.sDataBaseName + "'";
            DataTable dts = clsSQLCommond.ExecQuery(sSQL);
            for (int i = 0; i < dts.Rows.Count; i++)
            {
                switch (dts.Rows[i]["COLUMN_NAME"].ToString())
                {
                    #region S
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
                    #endregion
                    #region D
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
                    #endregion
                    #region T
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
                    #endregion
                    #region B
                    case "B1":
                        gridColB1.Caption = dts.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "B2":
                        gridColB2.Caption = dts.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "B3":
                        gridColB3.Caption = dts.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "B4":
                        gridColB4.Caption = dts.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "B5":
                        gridColB5.Caption = dts.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "B6":
                        gridColB6.Caption = dts.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "B7":
                        gridColB7.Caption = dts.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "B8":
                        gridColB8.Caption = dts.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    case "B9":
                        gridColB9.Caption = dts.Rows[i]["COLUMN_Text"].ToString();
                        break;
                    #endregion
                }
            }
            #endregion
        }

        private void SetEnabled(bool b)
        {
            textEditiCode.Enabled = false;
            dateEditdDate.Enabled = b;
            textEditdMemo.Enabled = b;
            dateEditdCreatesysTime.Enabled = false;
            dateEditdVerifysysTime.Enabled = false;
            dateEditdClosesysTime.Enabled = false;
            textEditdCreatesysPerson.Enabled = false;
            textEditdVerifysysPerson.Enabled = false;
            textEditdClosesysPerson.Enabled = false;
            gridView1.OptionsBehavior.Editable = b;

            if (b == false)
            {
                isChange = "N";
            }
            else
            {
                isChange = "";
            }
        }

        private void GetNull()
        {
            textEditID.EditValue = "";
            textEditiCode.EditValue = "";
            dateEditdDate.EditValue = DBNull.Value;
            textEditdMemo.EditValue = "";
            dateEditdCreatesysTime.EditValue = DBNull.Value;
            dateEditdVerifysysTime.EditValue = DBNull.Value;
            dateEditdClosesysTime.EditValue = DBNull.Value;
            textEditdCreatesysPerson.EditValue = "";
            textEditdVerifysysPerson.EditValue = "";
            textEditdClosesysPerson.EditValue = "";
            gridControl1.DataSource = null;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int iRow = 0;
            if (gridView1.FocusedRowHandle >= 0)
                iRow = gridView1.FocusedRowHandle;

            if (gridView1.GetRowCellValue(iRow, gridColiRowNo).ToString().Trim() == "")
            {
                gridView1.SetRowCellValue(iRow, gridColiRowNo, iRow + 1);
            }

            if (e.Column == gridColD1)
            {
                decimal iD1 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridColD1));
                decimal 引用量 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol引用量));
                if (iD1 < 引用量)
                {
                    MessageBox.Show("引用量超出");
                    gridView1.SetRowCellValue(iRow, gridColD1, gridView1.GetRowCellValue(iRow, gridCol历史数量));
                }
            }

            #region 新增或更新
            if (e.Column != gridColiSave && gridView1.GetRowCellDisplayText(e.RowHandle, gridColiSave).ToString().Trim() == "")
            {
                gridView1.SetRowCellValue(iRow, gridColiSave, "add");
            }
            if (e.Column != gridColiSave && e.Column != gridColiRowNo && gridView1.GetRowCellDisplayText(e.RowHandle, gridColiSave).ToString().Trim() == "edit")
            {
                gridView1.SetRowCellValue(iRow, gridColiSave, "update");
            }
            if (e.Column == gridColS1 && e.RowHandle == gridView1.RowCount - 1 && gridView1.GetRowCellDisplayText(e.RowHandle, gridColS1).ToString().Trim() != "")
            {
                gridView1.AddNewRow();
                gridView1.FocusedRowHandle = gridView1.RowCount - 1;
                gridView1.FocusedRowHandle = gridView1.RowCount - 2;
            }
            #endregion
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (isChange != "N")
            {
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColcClosesysPerson) != null)
                {
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColcClosesysPerson).ToString().Trim() != "")
                    {
                        gridView1.OptionsBehavior.Editable = false;
                    }
                    else
                    {
                        gridView1.OptionsBehavior.Editable = true;
                    }
                }
            }
        }
        
        private void ItemButtonEditS1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int iRow = 0;
            if (gridView1.FocusedRowHandle > 0)
                iRow = gridView1.FocusedRowHandle;

            系统服务.Frm参照 frm = new 系统服务.Frm参照(1);
            if (DialogResult.OK == frm.ShowDialog())
            {
                gridView1.SetRowCellValue(iRow, gridColS1, frm.sID);
                frm.Enabled = true;
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
                sSQL = "select  isnull(dCreatesysPerson,'') as 制单人,isnull(dVerifysysPerson,'') as 审核人,isnull(dClosesysPerson,'') as 关闭人 from " + tablename + " where " + tablecode + " = '" + sCode + "'";
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
                }
            }
            catch (Exception ee)
            { }
            return iReturn;
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

        ///// <summary>
        ///// 判断单据是否已经使用
        ///// </summary>
        ///// <param name="sCode">子表ID</param>
        ///// <returns></returns>
        //private decimal iCodeUsed(long AutoID)
        //{
        //    decimal iReturn = -1;
        //    try
        //    {
        //        sSQL = "select isnull(sum(c.iQuantity),0) as iQty from dbo.PO_POMain a inner join dbo.PO_PODetails b on a.ID = b.ID inner join dbo.RdRecords c on c.POAutoID = b.AutoID " +
        //               "where b.AutoID = '" + AutoID + "'";
        //        iReturn =ReturnDecimal(clsSQLCommond.ExecGetScalar(sSQL));
        //    }
        //    catch (Exception ee)
        //    { }
        //    return iReturn;
        //}
    }
}
