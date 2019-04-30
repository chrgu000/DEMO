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

namespace 生产
{
    public partial class Frm物料清单 : 系统服务.FrmBaseInfo
    {
        string tablename = "BOM_Main";
        string tableid = "iCode";
        string tablenames = "BOM_Details";

        string iID = "";
        public string 制单日期1 = "";
        public string 制单日期2 = "";
        public string 审核日期1 = "";
        public string 审核日期2 = "";
        public string 制单人1 = "";
        public string 制单人2 = "";
        public string 审核人1 = "";
        public string 审核人2 = "";
        public string 物料1 = "";
        public string 物料2 = "";

        string isChange = "";

        public DataTable dt子件;


        public Frm物料清单(string siID)
        {
            iID = siID;
            InitializeComponent();
            
        }

        public Frm物料清单()
        {
            InitializeComponent();

            sLayoutHeadPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Head.xml";
            sLayoutGridPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Grid.xml";

            if (File.Exists(sLayoutHeadPath))
                layoutControl1.RestoreLayoutFromXml(sLayoutHeadPath);

            if (File.Exists(sLayoutGridPath))
            {
                //gridControl1.MainView.RestoreLayoutFromXml(sLayoutGridPath);
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
            GetGrid();
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
            Frm物料清单_Add frm = new Frm物料清单_Add(制单日期1, 制单日期2,审核日期1, 审核日期2, 制单人1, 制单人2, 审核人1, 审核人2, 物料1, 物料2);
            if (DialogResult.OK == frm.ShowDialog())
            {
                frm.Enabled = true;
                制单日期1 = frm.制单日期1;
                制单日期2 = frm.制单日期2;
                审核日期1 = frm.审核日期1;
                审核日期2 = frm.审核日期2;
                制单人1 = frm.制单人1;
                制单人2 = frm.制单人2;
                审核人1 = frm.审核人1;
                审核人2 = frm.审核人2;
                物料1 = frm.物料1;
                物料2 = frm.物料2;
                GetSel();
            }

        }

        private void GetSel()
        {
            string sSQL = "select * from " + tablename + " a left join "+tablenames+" b on a.ID=b.ID where 1=1";
            if (制单日期1 != "")
            {
                sSQL = sSQL + " and dCreatesysTime>='" + 制单日期1 + "'";
            }
            if (制单日期2 != "")
            {
                sSQL = sSQL + " and dCreatesysTime<='" + 制单日期2 + "'";
            }
            if (审核日期1 != "")
            {
                sSQL = sSQL + " and dVerifysysTime>='" + 审核日期1 + "'";
            }
            if (审核日期2 != "")
            {
                sSQL = sSQL + " and dVerifysysTime<='" + 审核日期2 + "'";
            }
            if (制单人1 != "")
            {
                sSQL = sSQL + " and dCreatesysPerson>='" + 制单人1 + "'";
            }
            if (制单人2 != "")
            {
                sSQL = sSQL + " and dCreatesysPerson<='" + 制单人2 + "'";
            }
            if (审核人1 != "")
            {
                sSQL = sSQL + " and dVerifysysPerson>='" + 审核人1 + "'";
            }
            if (审核人2 != "")
            {
                sSQL = sSQL + " and dVerifysysPerson<='" + 审核人2 + "'";
            }
            if (物料1 != "")
            {
                sSQL = sSQL + " and cInvCode>='" + 物料1 + "'";
            }
            if (物料2 != "")
            {
                sSQL = sSQL + " and cInvCode<='" + 物料2 + "'";
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
                sSQL = "select min(ID) as ID from " + tablename + " ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    textEditID.EditValue = dt.Rows[0]["ID"].ToString();
                    iID = dt.Rows[0]["ID"].ToString();
                }
                GetSelBind();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败：" + ee.Message);
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
                    sSQL = "select ID from " + tablename + " where ID<" + textEditID.EditValue.ToString().Trim() + " order by ID desc";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt.Rows.Count > 0)
                    {
                        textEditID.EditValue = dt.Rows[0]["ID"].ToString();
                        iID = dt.Rows[0]["ID"].ToString();
                    }
                    GetSelBind();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败：" + ee.Message);
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
                    sSQL = "select ID from " + tablename + " where ID>" + textEditID.EditValue.ToString().Trim() + " order by ID ";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt.Rows.Count > 0)
                    {
                        textEditID.EditValue = dt.Rows[0]["ID"].ToString();
                        iID = dt.Rows[0]["ID"].ToString();
                    }
                    GetSelBind();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败：" + ee.Message);
            }
        }
        /// <summary>
        /// 末页
        /// </summary>
        private void btnLast()
        {
            try
            {
                sSQL = "select max(ID) as ID from " + tablename + " ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    textEditID.EditValue = dt.Rows[0]["ID"].ToString();
                    iID = dt.Rows[0]["ID"].ToString();
                }
                GetSelBind();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败：" + ee.Message);
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
                if (gridView1.GetRowCellDisplayText(i, gridCol序号).ToString().Trim() != "")
                {
                    gridView1.SetRowCellValue(i, gridCol序号, i + 1);
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

            dateEdit单据日期.EditValue = 系统服务.ClsBaseDataInfo.sLogDate;

            int iFocRow = gridView1.FocusedRowHandle;

            sSQL = "select a.*,i.cInvName,i.cInvStd, 'edit' as iSave,cast(null as decimal(16,6)) as 引用量,cast(null as decimal(16,6)) as 历史数量 " +
                    "from " + tablenames + " a left join  Inventory i on a.cInvCode=i.cInvCode left join ComputationUnitGroup g on i.cGroupCode=g.cGroupCode where 1=-1";
            dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dtBingGrid;
            try
            {
                gridView1.FocusedColumn = gridCol序号;
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
            if (textEditID.Text.Trim() == "")
            {
                throw new Exception("请选择需要修改的单据");
            }

            int iRe = CheState(textEdit单据号.Text.Trim());
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
            if (textEdit单据号.Text.Trim() == "")
                throw new Exception("请选择需要删除的单据");

            if (textEdit单据号.Text.Trim() == "")
            {
                throw new Exception("请选择需要修改的单据");
            }

            int iRe = CheState(textEdit单据号.Text.Trim());
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
                sSQL = "delete dbo."+tablenames+" where ID = " + textEditID.Text.Trim();
                aList.Add(sSQL);
                sSQL = "delete dbo."+tablename+" where ID = " + textEditID.Text.Trim();
                aList.Add(sSQL);

               
                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("删除成功！\n合计执行语句:" + iCou + "条");
                    btnLast();
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
                gridView1.FocusedColumn = gridCol序号;
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
                gridView1.Focus();
            }
            catch { }

            int iRe = CheState(textEdit单据号.Text.Trim());
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

            if (buttonEdit母件编码.EditValue == null || buttonEdit母件编码.EditValue.ToString().Trim() == "")
            {
                sErr = sErr + "母件编码不能为空\n";
                
            }

            if (textEdit含税单价.EditValue == null || textEdit含税单价.EditValue.ToString().Trim() == "")
            {
                sErr = sErr + "含税单价不能为空\n";

            }

            if (textEdit税率.EditValue == null || textEdit税率.EditValue.ToString().Trim() == "")
            {
                sErr = sErr + "税率不能为空\n";

            }

            if (lookUpEdit包装方式.EditValue == null || textEdit税率.EditValue.ToString().Trim() == "")
            {
                sErr = sErr + "包装方式不能为空\n";

            }

            aList = new System.Collections.ArrayList();
            DataRow drh = dt.NewRow();
            if (sState == "add")
            {
                sSQL = "select isnull(max(ID)+1,1) as ID from " + tablename;
                iID = clsSQLCommond.ExecQuery(sSQL).Rows[0][0].ToString();
                drh["ID"] = iID;
                textEdit单据号.EditValue = 系统服务.序号.GetNewSerialNumberContinuous(tablename, tableid);
                dateEdit制单日期.EditValue = 系统服务.ClsBaseDataInfo.sLogDate;
                textEdit制单人.EditValue = 系统服务.ClsBaseDataInfo.sUid;

                sSQL = "select * from " + tablename + " where InvCode='" + buttonEdit母件编码.EditValue.ToString().Trim()+ "'";
                DataTable dtis = clsSQLCommond.ExecQuery(sSQL);
                if (dtis.Rows.Count > 0)
                {
                    sErr = sErr + "已为该物料设定BOM，请对旧BOM进行修改\n";
                }
            }
            drh["ID"] = iID;

            drh["iCode"] = textEdit单据号.EditValue.ToString().Trim();

            drh["dDate"] = dateEdit单据日期.EditValue.ToString().Trim();

            drh["InvCode"] = buttonEdit母件编码.EditValue.ToString().Trim();

            drh["cMemo"] = textEdit备注.EditValue.ToString().Trim();

            drh["cPCode"] = lookUpEdit包装方式.EditValue;
            if (textEdit含税单价.EditValue.ToString().Trim() != "")
            {
                drh["iUnitPrice"] = textEdit含税单价.EditValue;
            }
            if (textEdit无税单价.EditValue.ToString().Trim() != "")
            {
                drh["iNatUnitPrice"] = textEdit无税单价.EditValue;
            }
            if (textEdit税率.EditValue.ToString().Trim() != "")
            {
                drh["iTaxRate"] = textEdit税率.EditValue;
            }
            drh["S1"] = lookUpEdit客户.EditValue;
            if (sState == "add" )
            {
                textEdit制单人.Text = 系统服务.ClsBaseDataInfo.sUid;
                dateEdit制单日期.Text = 系统服务.ClsBaseDataInfo.sLogDate;
            }
            if (sState == "alter")
            {
                drh["dVerifysysTime"] = dateEdit审核日期.Text.Trim();
                drh["dVerifysysPerson"] = textEdit审核人.Text.Trim();
                textEdit关闭人.Text = 系统服务.ClsBaseDataInfo.sUid;
                dateEdit关闭日期.Text = 系统服务.ClsBaseDataInfo.sLogDate;
            }

            drh["dCreatesysTime"] = dateEdit制单日期.Text.Trim();
            drh["dCreatesysPerson"] = dateEdit制单日期.Text.Trim();
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
                系统服务.变更表.GetChange(tablename, tablenames, textEditID.EditValue.ToString().Trim(), clsGetSQL, aList);
            }
            #endregion

            #region 删行
            if (textEditDel.EditValue != null && textEditDel.EditValue.ToString().Trim() != "")
            {
                系统服务.变更表.GetDelRow(tablenames, textEditDel.EditValue.ToString().Trim(), aList);
            }
            #endregion

            #region 子表

            sSQL = "select isnull(max(AutoID)+1,1) as AutoID from " + tablenames;
            long sAutoID = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "update" || gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "add")
                {
                    #region 判断
                    if (gridView1.GetRowCellDisplayText(i, gridCol子件编码).ToString().Trim() == "")
                    {
                        continue;
                    }

                    if (gridView1.GetRowCellValue(i, gridCol数量).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + gridCol数量.Caption + "不能为空\n";
                        continue;
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
                    dr["iCode"] = textEdit单据号.EditValue.ToString().Trim();
                    dr["iRowNo"] = gridView1.GetRowCellValue(i, gridCol序号).ToString().Trim();
                    dr["InvCode"] = buttonEdit母件编码.EditValue;
                    dr["cInvCode"] = gridView1.GetRowCellValue(i, gridCol子件编码).ToString().Trim();
                    dr["iQuantity"] = gridView1.GetRowCellValue(i, gridCol数量).ToString().Trim();
                    if (gridView1.GetRowCellValue(i, gridCol件数) != null && gridView1.GetRowCellValue(i, gridCol件数).ToString().Trim() != "")
                    {
                        dr["iNum"] = gridView1.GetRowCellValue(i, gridCol件数).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol换算率) != null && gridView1.GetRowCellValue(i, gridCol换算率).ToString().Trim() != "")
                    {
                        dr["iChangRate"] = gridView1.GetRowCellValue(i, gridCol换算率).ToString().Trim();
                    }

                    dr["cMemo"] = gridView1.GetRowCellValue(i, gridCol备注).ToString().Trim();

                    //dr["cClosesysPerson"] = gridView1.GetRowCellValue(i, gridCol行关闭人).ToString().Trim();
                    //dr["cClosesysTime"] = gridView1.GetRowCellValue(i, gridCol行关闭日期).ToString().Trim();

                    dts.Rows.Add(dr);
                    #endregion

                    if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "update" )
                    {
                        sSQL = clsGetSQL.GetUpdateSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablenames, dts, dts.Rows.Count - 1);
                    }
                     if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "add" )
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
            #region 表体不能为空
            bool b列表 = false;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridCol子件编码).ToString().Trim() != "")
                    b列表 = true;
            }
            if (!b列表)
            {
                sErr = sErr + "表体不能为空";
            }

            if (sErr.Length != 0)
            {
                throw new Exception(sErr.ToString());
            }
            if (dt == null || dt.Rows.Count <= 0)
            {
                throw new Exception("表头不能为空");
            }
            bool b = false;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridCol子件编码).ToString().Trim() != "")
                {
                    b = true;
                    break;
                }
            }
            if (!b)
            {
                throw new Exception("表体不能为空");
            }
            #endregion

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("保存成功！\n合计执行语句:" + iCou + "条");
                textEditID.EditValue = iID;
                textEditDel.EditValue = "";
                sState = "save";
                SetEnabled(false);
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
            if (textEdit单据号.Text.Trim() == "")
            {
                throw new Exception("请选择需要审核的单据");
            }

            int iRe = CheState(textEdit单据号.Text.Trim());
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

            sSQL = "update " + tablename + " set dVerifysysTime='" + 系统服务.ClsBaseDataInfo.sLogDate + "',dVerifysysPerson='" + 系统服务.ClsBaseDataInfo.sUid + "' where ID=" + textEditID.EditValue.ToString().Trim() + "";
            aList.Add(sSQL);

           

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("审核成功！\n合计执行语句:" + iCou + "条");

                textEdit审核人.Text = 系统服务.ClsBaseDataInfo.sUid;
                dateEdit审核日期.Text = 系统服务.ClsBaseDataInfo.sLogDate;
                sState = "audit";
            }
        }
        /// <summary>
        /// 弃审
        /// </summary>
        private void btnUnAudit()
        {
            if (textEdit单据号.Text.Trim() == "")
            {
                throw new Exception("请选择需要弃审的单据");
            }

            int iRe = CheState(textEdit单据号.Text.Trim());
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
            //int iUsed = iCodeUsed(textEdit单据号.Text.Trim());
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
                textEdit审核人.Text = "";
                dateEdit审核日期.Text = "";
                sState = "unaudit";
            }
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
            int iRe = CheState(textEdit单据号.Text.Trim());
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

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridCol子件编码).ToString().Trim() == "")
                    continue;

                //long lAutoID = Convert.ToInt64(gridView1.GetRowCellValue(i, gridColAutoID));
                //gridView1.SetRowCellValue(i,gridCol引用量, iCodeUsed(lAutoID));
            }

            SetEnabled(true);
            sState = "alter";
        }

        #endregion

        private void Frm物料清单_Load(object sender, EventArgs e)
        {
            try
            {
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
                
                sSQL = "select * from " + tablename + " where ID=" + iID;
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    textEditID.EditValue = dt.Rows[0]["ID"].ToString();
                    textEdit单据号.EditValue = dt.Rows[0]["iCode"].ToString();
                    dateEdit单据日期.EditValue = dt.Rows[0]["dDate"].ToString();

                    dateEdit制单日期.EditValue = dt.Rows[0]["dCreatesysTime"].ToString();
                    dateEdit审核日期.EditValue = dt.Rows[0]["dVerifysysTime"].ToString();
                    dateEdit关闭日期.EditValue = dt.Rows[0]["dClosesysTime"].ToString();

                    textEdit备注.EditValue = dt.Rows[0]["cMemo"].ToString();
                    textEdit制单人.EditValue = dt.Rows[0]["dCreatesysPerson"].ToString();
                    textEdit审核人.EditValue = dt.Rows[0]["dVerifysysPerson"].ToString();
                    textEdit关闭人.EditValue = dt.Rows[0]["dClosesysPerson"].ToString();

                    lookUpEdit包装方式.EditValue = dt.Rows[0]["cPCode"].ToString();
                    textEdit含税单价.EditValue = dt.Rows[0]["iUnitPrice"].ToString();
                    textEdit无税单价.EditValue = dt.Rows[0]["iNatUnitPrice"].ToString();
                    textEdit税率.EditValue = dt.Rows[0]["iTaxRate"].ToString();

                    buttonEdit客户.EditValue = dt.Rows[0]["S1"].ToString();

                    buttonEdit母件编码.EditValue = dt.Rows[0]["InvCode"].ToString();
                    sSQL = "select a.*, 'edit' as iSave,cast(null as decimal(16,6)) as 引用量,cast(a.iQuantity as decimal(16,6)) as 历史数量 " +
                        "from " + tablenames + " a  where ID=" + iID;

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
            lookUpEdit规格型号.Properties.DataSource = 系统服务.LookUp.PurchaseType();
            ItemLookUpEditcInvName.Properties.DataSource = 系统服务.LookUp.Inventory();
            ItemLookUpEditcInvStd.Properties.DataSource = 系统服务.LookUp.Inventory();
            系统服务.LookUp.Inventory(lookUpEdit母件名称);
            系统服务.LookUp.Inventory(lookUpEdit规格型号);
            ItemLookUpEdit供应商物料编码.DisplayMember = "cInvVenCode";
            系统服务.LookUp.Packing(lookUpEdit包装方式);
            系统服务.LookUp.Customer(lookUpEdit客户);
        }

        private void SetEnabled(bool b)
        {
            textEdit单据号.Enabled = false;
            dateEdit单据日期.Enabled = b;
            dateEdit制单日期.Enabled = false;
            dateEdit审核日期.Enabled = false;
            dateEdit关闭日期.Enabled = false;

            textEdit备注.Enabled = b;
            textEdit制单人.Enabled = false;
            textEdit审核人.Enabled = false;
            textEdit关闭人.Enabled = false;
            textEdit含税单价.Enabled = b;
            textEdit税率.Enabled = b;
            textEdit无税单价.Enabled = false;

            lookUpEdit母件名称.Enabled = false;

            buttonEdit母件编码.Enabled = b;

            lookUpEdit规格型号.Enabled = false;

            lookUpEdit包装方式.Enabled = b;

            lookUpEdit客户.Enabled = false;
            buttonEdit客户.Enabled = b;

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
            textEdit单据号.EditValue = "";
            dateEdit单据日期.EditValue = DBNull.Value;

            dateEdit制单日期.EditValue = DBNull.Value;
            dateEdit审核日期.EditValue = DBNull.Value;
            dateEdit关闭日期.EditValue = DBNull.Value;

            textEditID.EditValue = "";
            textEdit备注.EditValue = "";
            textEdit制单人.EditValue = "";
            textEdit审核人.EditValue = "";
            textEdit关闭人.EditValue = "";
            textEdit含税单价.EditValue = "";
            textEdit税率.EditValue = "17";
            textEdit无税单价.EditValue = "";

            buttonEdit母件编码.EditValue = "";
            lookUpEdit母件名称.EditValue = "";
            lookUpEdit规格型号.EditValue = "";

            lookUpEdit包装方式.EditValue = "";

            lookUpEdit客户.EditValue = "";
            buttonEdit客户.EditValue = "";

            gridControl1.DataSource = null;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView1.FocusedRowHandle >= 0)
                    iRow = gridView1.FocusedRowHandle;

                if (gridView1.GetRowCellValue(iRow, gridCol序号).ToString().Trim() == "")
                {
                    gridView1.SetRowCellValue(iRow, gridCol序号, iRow + 1);
                }

                if (e.Column == gridCol子件编码 || e.Column == gridCol子件名称 || e.Column == gridCol规格型号)
                {
                    if (e.Column == gridCol子件编码)
                    {
                        gridView1.SetRowCellValue(iRow, gridCol子件名称, gridView1.GetRowCellValue(iRow, gridCol子件编码).ToString().Trim());
                        gridView1.SetRowCellValue(iRow, gridCol规格型号, gridView1.GetRowCellValue(iRow, gridCol子件编码).ToString().Trim());
                    }
                    sSQL = "select * from Inventory where cInvCode = '" + gridView1.GetRowCellValue(iRow, gridCol子件编码).ToString().Trim() + "'";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["换算率"].ToString() != "")
                    {
                        gridView1.SetRowCellValue(iRow, gridCol换算率, dt.Rows[0]["换算率"].ToString());
                    }
                    else
                    {
                        gridView1.SetRowCellValue(iRow, gridCol换算率, null);
                    }
                }

                #region 换算率
                if (e.Column == gridCol数量 || e.Column == gridCol换算率)
                {
                    if (gridView1.GetRowCellValue(iRow, gridCol换算率).ToString().Trim() != "")
                    {
                        decimal 换算率 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol换算率));
                        decimal 数量 = 0;
                        if (gridView1.GetRowCellValue(iRow, gridCol数量).ToString().Trim() != "")
                        {
                            数量 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol数量));
                        }
                        if (数量 == 0)
                        {
                            gridView1.SetRowCellValue(iRow, gridCol件数, null);
                        }
                        else
                        {
                            gridView1.SetRowCellValue(iRow, gridCol件数, ReturnDecimal(数量 * 换算率));
                        }

                    }
                    else
                    {
                        gridView1.SetRowCellValue(iRow, gridCol件数, null);
                    }
                }
                #endregion

                if (e.Column == gridCol数量 || e.Column == gridCol件数)
                {
                    decimal 数量 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol数量));
                    decimal 件数 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol件数));
                    decimal 换算率 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol换算率));

                    #region 计算
                    if (e.Column == gridCol数量)
                    {
                        if (换算率 != 0)
                        {
                            gridView1.SetRowCellValue(iRow, gridCol件数, ReturnDecimal(数量 * 换算率));
                        }
                        else
                        {
                            gridView1.SetRowCellValue(iRow, gridCol件数, null);
                        }
                    }
                    #endregion
                }

                if (e.Column == gridCol数量)
                {
                    decimal 数量 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol数量));
                    decimal 引用量 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol引用量));
                    if (数量 < 引用量)
                    {
                        MessageBox.Show("引用量超出");
                        gridView1.SetRowCellValue(iRow, gridCol数量, gridView1.GetRowCellValue(iRow, gridCol历史数量));
                    }
                }

                #region
                if (e.Column != gridColiSave && gridView1.GetRowCellDisplayText(e.RowHandle, gridColiSave).ToString().Trim() == "")
                {
                    gridView1.SetRowCellValue(iRow, gridColiSave, "add");
                }
                if (e.Column != gridColiSave && e.Column != gridCol序号 && gridView1.GetRowCellDisplayText(e.RowHandle, gridColiSave).ToString().Trim() == "edit")
                {
                    gridView1.SetRowCellValue(iRow, gridColiSave, "update");
                }
                if (e.Column == gridCol子件编码 && e.RowHandle == gridView1.RowCount - 1 && gridView1.GetRowCellDisplayText(e.RowHandle, gridCol子件编码).ToString().Trim() != "")
                {
                    gridView1.AddNewRow();
                    gridView1.FocusedRowHandle = iRow;
                }
                #endregion
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
                if (isChange != "N")
                {
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridCol行关闭人) != null)
                    {
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridCol行关闭人).ToString().Trim() != "")
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
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit母件编码_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(1);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit母件编码.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit母件编码_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit母件编码.Text.Trim() != "")
                lookUpEdit母件名称.EditValue = buttonEdit母件编码.Text.Trim();
            else
                lookUpEdit母件名称.EditValue = null;

            if (buttonEdit母件编码.Text.Trim() != "")
            {
                if (sState == "add" || sState == "edit")
                {
                    sSQL = "select * from " + tablename + " where InvCode = '" + buttonEdit母件编码.Text.Trim() + "'";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt == null || dt.Rows.Count < 1)
                    {
                        return;
                    }
                    textEditID.EditValue = dt.Rows[0]["ID"].ToString();

                    buttonEdit母件编码.EditValue = dt.Rows[0]["InvCode"].ToString();
                    sSQL = "select a.*, 'edit' as iSave,cast(null as decimal(16,6)) as 引用量,cast(a.iQuantity as decimal(16,6)) as 历史数量 " +
                        "from " + tablenames + " a  where 1=-1";

                    dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
                    gridControl1.DataSource = dtBingGrid;


                    gridView1.AddNewRow();

                    gridView1.FocusedRowHandle = iFocRow;
                }
            }
        }


        private void buttonEdit母件编码_Leave(object sender, EventArgs e)
        {
            if (buttonEdit母件编码.Text.Trim() == "")
                return;
            if (lookUpEdit母件名称.Text.Trim() == "")
            {
                buttonEdit母件编码.Text = "";
                buttonEdit母件编码.Focus();
            }
        }

        private void ItemButtonEdit存货编码_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int iRow = 0;
            if (gridView1.FocusedRowHandle > 0)
                iRow = gridView1.FocusedRowHandle;

            系统服务.Frm参照 frm = new 系统服务.Frm参照(1);
            if (DialogResult.OK == frm.ShowDialog())
            {
                gridView1.SetRowCellValue(iRow, gridCol子件编码, frm.sID);
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
                sSQL = "select  isnull(dCreatesysPerson,'') as 制单人,isnull(dVerifysysPerson,'') as 审核人,isnull(dClosesysPerson,'') as 关闭人 from " + tablename + " where " + tableid + " = '" + sCode + "'";
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
            {
                MessageBox.Show(ee.Message);
            }
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

        private void textEdit税率_EditValueChanged(object sender, EventArgs e)
        {
            if (textEdit含税单价.Text.Trim() != "" && textEdit税率.Text.Trim() != "")
            {
                textEdit无税单价.EditValue = ReturnDecimal(ReturnDecimal(textEdit含税单价.EditValue) / (1 + ReturnDecimal(textEdit税率.EditValue) / 100));
            }
            else
            {
                textEdit无税单价.EditValue = DBNull.Value;
            }
        }

        private void textEdit含税单价_EditValueChanged(object sender, EventArgs e)
        {

            if (textEdit含税单价.Text.Trim() != "" && textEdit税率.Text.Trim() != "")
            {
                textEdit无税单价.EditValue = ReturnDecimal(ReturnDecimal(textEdit含税单价.EditValue) / (1 + ReturnDecimal(textEdit税率.EditValue) / 100));
            }
            else
            {
                textEdit无税单价.EditValue = DBNull.Value;
            }
        }

        private void buttonEdit客户_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(9);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit客户.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit客户_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit客户.Text.Trim() != "")
            {
                lookUpEdit客户.EditValue = buttonEdit客户.Text.Trim();
            }
            else
            {
                buttonEdit客户.EditValue = null;
            }
        }

        private void buttonEdit客户_Leave(object sender, EventArgs e)
        {
            if (buttonEdit客户.Text.Trim() == "")
                return;
            if (lookUpEdit客户.Text.Trim() == "")
            {
                buttonEdit客户.Text = "";
                buttonEdit客户.Focus();
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
        //        iReturn = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
        //    }
        //    catch (Exception ee)
        //    { }
        //    return iReturn;
        //}
    }
}
