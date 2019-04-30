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

namespace 工程
{
    public partial class Frm工程登记 : 系统服务.FrmBaseInfo
    {
        string iID = "";
        private string sWhere = "";
        DataTable dtpro;

        int b安全登记=1;
        int b材料登记 = 1;
        int b附件 = 1;
        int b工程质量登记 = 1;
        int b公司工程进度 = 1;
        int b供电公司工程进度 = 1;
        bool bBack = false;
        bool b表头权限 = false;
        int b监察 = 1;

        public Frm工程登记(string siID)
        {
            iID = siID;
            InitializeComponent();
            
        }

        public Frm工程登记()
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
            try
            {
                Frm工程登记_Add frm = new Frm工程登记_Add();
                if (DialogResult.OK == frm.ShowDialog())
                {
                    frm.Enabled = true;
                    sWhere = frm.sWhere;
                    GetSel();
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        private void GetSel()
        {
            try
            {
                dtSel = clsWeb.dtListProject(sWhere, "");
                if (dtSel == null)
                {
                    throw new Exception("查询失败");
                }
                if (dtSel.Rows.Count > 0)
                {
                    iID = dtSel.Rows[0]["iID"].ToString();
                    GetGrid();
                }
                else
                {
                    btnLast();
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        /// <summary>
        /// 首页
        /// </summary>
        private void btnFirst()
        {
            try
            {
                iID = clsWeb.siIDProject(1, "");
                if (iID != "-1")
                {
                    textEditID.EditValue = iID;
                    GetSelBind();
                }
                
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
                    if (textEditID.EditValue != null)
                    {
                        iID = textEditID.EditValue.ToString().Trim();
                    }
                    iID = clsWeb.siIDProject(2, iID);
                    if (iID != "-1")
                    {
                        textEditID.EditValue = iID;
                        GetSelBind();
                    }
                    else
                    {
                        btnFirst();
                    }
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
                    if (textEditID.EditValue != null)
                    {
                        iID = textEditID.EditValue.ToString().Trim();
                    }
                    iID = clsWeb.siIDProject(3, iID);
                    if (iID != "-1")
                    {
                        textEditID.EditValue = iID;
                        GetSelBind();
                    }
                    else
                    {
                        btnLast();
                    }
                    
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
                iID = clsWeb.siIDProject(4, "");
                if (iID != "-1")
                {
                    textEditID.EditValue = iID;
                    GetSelBind();
                }
                else
                {
                    iID = "";
                    GetGrid();
                }
            }
            catch(Exception ee)
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
            try
            {
                #region gridView1
                for (int i = gridView1.RowCount - 2; i >= 0; i--)
                {
                    if (gridView1.IsRowSelected(i))
                    {
                        if (gridView1.GetRowCellDisplayText(i, gridCol1序号).ToString().Trim() != "")
                        {
                            if (txtDel1.EditValue != null && txtDel1.EditValue.ToString().Trim() != "")
                            {
                                txtDel1.EditValue = txtDel1.EditValue.ToString().Trim() + "," + gridView1.GetRowCellDisplayText(i, gridCol1序号).ToString().Trim();
                            }
                            else
                            {
                                txtDel1.EditValue = gridView1.GetRowCellDisplayText(i, gridCol1序号).ToString().Trim();
                            }
                        }
                        gridView1.DeleteRow(i);
                    }
                }

                #endregion

                #region gridView4
                for (int i = gridView4.RowCount - 2; i >= 0; i--)
                {
                    if (gridView4.IsRowSelected(i))
                    {
                        if (gridView4.GetRowCellDisplayText(i, gridCol4序号).ToString().Trim() != "")
                        {
                            if (txtDel4.EditValue != null && txtDel4.EditValue.ToString().Trim() != "")
                            {
                                txtDel4.EditValue = txtDel4.EditValue.ToString().Trim() + "," + gridView4.GetRowCellDisplayText(i, gridCol4序号).ToString().Trim();
                            }
                            else
                            {
                                txtDel4.EditValue = gridView4.GetRowCellDisplayText(i, gridCol4序号).ToString().Trim();
                            }
                        }
                        gridView4.DeleteRow(i);
                    }
                }
                #endregion

                #region gridView5
                for (int i = gridView5.RowCount - 2; i >= 0; i--)
                {
                    if (gridView5.IsRowSelected(i))
                    {
                        if (gridView5.GetRowCellDisplayText(i, gridCol5序号).ToString().Trim() != "")
                        {
                            if (txtDel5.EditValue != null && txtDel5.EditValue.ToString().Trim() != "")
                            {
                                txtDel5.EditValue = txtDel5.EditValue.ToString().Trim() + "," + gridView5.GetRowCellDisplayText(i, gridCol5序号).ToString().Trim();
                            }
                            else
                            {
                                txtDel5.EditValue = gridView5.GetRowCellDisplayText(i, gridCol5序号).ToString().Trim();
                            }
                        }
                        gridView5.DeleteRow(i);
                    }
                }
                #endregion

                #region gridView8
                for (int i = gridView8.RowCount - 2; i >= 0; i--)
                {
                    if (gridView8.IsRowSelected(i))
                    {
                        if (gridView8.GetRowCellDisplayText(i, gridCol8序号).ToString().Trim() != "")
                        {
                            if (txtDel8.EditValue != null && txtDel8.EditValue.ToString().Trim() != "")
                            {
                                txtDel8.EditValue = txtDel8.EditValue.ToString().Trim() + "," + gridView8.GetRowCellDisplayText(i, gridCol8序号).ToString().Trim();
                            }
                            else
                            {
                                txtDel8.EditValue = gridView8.GetRowCellDisplayText(i, gridCol8序号).ToString().Trim();
                            }
                        }
                        gridView8.DeleteRow(i);
                    }
                }
                #endregion
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }
        /// <summary>
        /// 新增
        /// </summary>
        private void btnAdd()
        {
            try
            {
                GetNull();
                SetEnabled(true);
                dateEdit接收日期.EditValue = 系统服务.ClsBaseDataInfo.sLogDate;

                int iFocRow = gridView1.FocusedRowHandle;

                dtBingHead = clsWeb.dtnewProject(0);
                gridControl1.DataSource = clsWeb.dtnewProject(1);
                gridControl4.DataSource = clsWeb.dtnewProject(4);
                gridControl5.DataSource = clsWeb.dtnewProject(5);
                dtpro = clsWeb.dtnewProject(6);
                GetProgress(dtpro);
                SetEnabled进展1(false);
                SetEnabled进展2(false);
                gridControl8.DataSource = clsWeb.dtnewProject(8);
                try
                {
                    gridView1.FocusedColumn = gridCol1存货编码;
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                    gridView1.Focus();
                }
                catch { }

                //gridView1.AddNewRow();
                gridView4.AddNewRow();
                //gridView5.AddNewRow();
                gridView8.AddNewRow();

                gridView1.FocusedRowHandle = 0;
                gridView4.FocusedRowHandle = 0;
                gridView5.FocusedRowHandle = 0;
                gridView8.FocusedRowHandle = 0;
                xtraTab供电公司工程进度.PageVisible = false;
                xtraTab公司工程进度.PageVisible = false;
                sState = "add";
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {
            try
            {
                string sErr = clsWeb.editProject(textEditID.Text);

                if (sErr.Trim().Length > 0)
                {
                    throw new Exception(sErr);
                }

                SetEnabled(true);
                if (b供电公司工程进度 == 3)
                {
                    SetEnabled进展1(true);
                }
                if (b公司工程进度 == 3)
                {
                    SetEnabled进展2(true);
                }
                txt工程编号.Enabled = false;
                lookUpEdit工程类型.Enabled = false;
                sState = "edit";
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
            try
            {
                DialogResult result = MessageBox.Show("是否删除?", "删除提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.OK)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (gridView1.IsRowSelected(i))
                        {
                            gridView1.SetRowCellValue(i, gridColiSave, "del");
                        }
                    }

                    string sErr = clsWeb.delProject(textEditID.EditValue.ToString());

                    if (sErr.Trim() != "ok")
                    {
                        throw new Exception(sErr);
                    }

                    MessageBox.Show("删除成功！");
                    btnLast();
                    sState = "del";
                }
            }
            catch (Exception ee)
            {
                throw new Exception("删除失败！" + ee.Message);
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
                gridView1.Focus();

                gridView4.FocusedRowHandle -= 1;
                gridView4.FocusedRowHandle += 1;
                gridView4.Focus();

                gridView5.FocusedRowHandle -= 1;
                gridView5.FocusedRowHandle += 1;
                gridView5.Focus();

                gridView8.FocusedRowHandle -= 1;
                gridView8.FocusedRowHandle += 1;
                gridView8.Focus();

                DataRow dw;
                if (sState == "add")
                {
                    for (int i = dtBingHead.Rows.Count - 1; i >= 0; i--)
                    {
                        dtBingHead.Rows.Remove(dtBingHead.Rows[i]);
                    }
                    dw = dtBingHead.NewRow();
                    dw["iSave"] = "add";
                }
                else
                {
                    dw = dtBingHead.Rows[0];
                    dw["iSave"] = "update";
                }
                if (txt工程编号.EditValue == null || txt工程编号.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("工程编号不可为空");
                }
                if (txt工程名称.EditValue == null || txt工程名称.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("工程名称不可为空");
                }
                if (lookUpEdit工程类型.EditValue == null || lookUpEdit工程类型.EditValue.ToString() == "")
                {
                    throw new Exception("工程类型不可为空");
                }
                if (dateEdit接收日期.EditValue == null || dateEdit接收日期.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("接收日期不可为空");
                }
                if (lookUpEdit工程地区.EditValue == null || lookUpEdit工程地区.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("工程地区不可为空");
                }
                if (lookUpEdit工程类型.EditValue.ToString().Trim() == "1")
                {
                    if (lookUpEdit工程性质.Text.Trim() == "")
                    {
                        throw new Exception("供电公司工程的工程性质不可为空");
                    }
                }

                dw["cCode"] = txt工程编号.EditValue;
                dw["cName"] = txt工程名称.EditValue;
                //dw["InvoiceState"] = txt开票情况.EditValue;
                dw["LineName"] = txt线路名称.EditValue;
                dw["iQuantity"] = txt工程量.EditValue;
                dw["Remark"] = txt备注.EditValue;

                dw["cDCCode"] = lookUpEdit工程地区.EditValue;
                dw["cPCCode"] = lookUpEdit工程类型.EditValue;
                dw["cECode"] = lookUpEdit工程性质.EditValue;
                dw["EndState"] = chk结案.Checked;
                dw["IsInvoice"] = chkIsInvoice.Checked;
                dw["sState"] = sState;

                if (radioGroup监察.EditValue != null)
                {
                    dw["IsCheck"] = radioGroup监察.EditValue;
                }
                dw["CheckPerson"] = lblCheckPerson.Text;
                if (lblCheckTime.Text != null && lblCheckTime.Text !="")
                {
                    dw["CheckTime"] = lblCheckTime.Text;
                }
                dw["CheckRemark"] = txtCheckRemark.EditValue;
               

                if (dateEdit接收日期.EditValue != null)
                {
                    dw["dDate"] = dateEdit接收日期.EditValue;
                }

                if (dateEdit计划决算资料提交日期.EditValue != null && dateEdit计划决算资料提交日期.EditValue.ToString().Trim() != "")
                {
                    dw["Date1"] = dateEdit计划决算资料提交日期.EditValue;
                }
                if (dateEdit决算资料提交日期.EditValue != null && dateEdit决算资料提交日期.EditValue.ToString().Trim() != "")
                {
                    dw["Date2"] = dateEdit决算资料提交日期.EditValue;
                }
                if (dateEdit计划竣工资料上报日期.EditValue != null && dateEdit计划竣工资料上报日期.EditValue.ToString().Trim() != "")
                {
                    dw["Date3"] = dateEdit计划竣工资料上报日期.EditValue;
                }
                if (dateEdit竣工资料上报日期.EditValue != null && dateEdit竣工资料上报日期.EditValue.ToString().Trim() != "")
                {
                    dw["Date4"] = dateEdit竣工资料上报日期.EditValue;
                }
                if (dateEdit计划竣工日期.EditValue != null && dateEdit计划竣工日期.EditValue.ToString().Trim() != "")
                {
                    dw["Date5"] = dateEdit计划竣工日期.EditValue;
                }
                if (dateEdit竣工日期.EditValue != null && dateEdit竣工日期.EditValue.ToString().Trim() != "")
                {
                    dw["Date6"] = dateEdit竣工日期.EditValue;
                }
                if (sState == "add")
                {
                    dtBingHead.Rows.Add(dw);
                }
                string del1 = "";
                if (txtDel1.EditValue != null)
                {
                    del1 = txtDel1.EditValue.ToString().Trim();
                }
                string del2 = "";
                if (txtDel2.EditValue != null)
                {
                    del2 = txtDel2.EditValue.ToString().Trim();
                }
                string del3 = "";
                if (txtDel3.EditValue != null)
                {
                    del3 = txtDel3.EditValue.ToString().Trim();
                }
                string del4 = "";
                if (txtDel4.EditValue != null)
                {
                    del4 = txtDel4.EditValue.ToString().Trim();
                }
                string del5 = "";
                if (txtDel5.EditValue != null)
                {
                    del5 = txtDel5.EditValue.ToString().Trim();
                }
                string del8 = "";
                if (txtDel8.EditValue != null)
                {
                    del8 = txtDel8.EditValue.ToString().Trim();
                }

                string sErr = clsWeb.saveProject(系统服务.ClsBaseDataInfo.sUid, dtBingHead
                    , (DataTable)gridControl1.DataSource
                    , (DataTable)gridControl4.DataSource
                    , (DataTable)gridControl5.DataSource
                    , (DataTable)gridControl8.DataSource
                    , del1, del4, del5, del8);

                if (sErr.Trim() != "ok")
                {
                    throw new Exception(sErr);
                }

                MessageBox.Show("保存成功！");
                if (textEditID.EditValue.ToString().Trim() == "")
                {
                    btnLast();
                }
                else
                {
                    GetGrid();
                }
                sState = "sel";

            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
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
            try
            {
                string sErr = clsWeb.auditProject(textEditID.Text, 系统服务.ClsBaseDataInfo.sUid);

                if (sErr.Trim().Length > 0)
                {
                    throw new Exception(sErr);
                }

                MessageBox.Show("审核成功！");
                GetGrid();
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }
        /// <summary>
        /// 弃审
        /// </summary>
        private void btnUnAudit()
        {
            try
            {
                string sErr = clsWeb.unAuditProject(textEditID.Text);

                if (sErr.Trim().Length > 0)
                {
                    throw new Exception(sErr);
                }

                MessageBox.Show("弃审成功！");
                GetGrid();
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
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
            throw new NotImplementedException();
        }

        #endregion

        private void Frm工程登记_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookUpEdit();

                GetLayOut(layoutControl1, gridControl1);
                GetGridViewSet(gridView1);
                GetGridViewSet(gridView4);
                GetGridViewSet(gridView5);
                GetGridViewSet(gridView8);

                DataTable dtrole = clsWeb.dtRole(系统服务.ClsBaseDataInfo.sUid);
                if (dtrole.Rows.Count > 0)
                {
                    b材料登记 = ReturnInt(dtrole.Rows[0]["S1"]);
                    b工程质量登记 = ReturnInt(dtrole.Rows[0]["S4"]);
                    b安全登记 = ReturnInt(dtrole.Rows[0]["S5"]);
                    b供电公司工程进度 = ReturnInt(dtrole.Rows[0]["S6"]);
                    b公司工程进度 = ReturnInt(dtrole.Rows[0]["S7"]);
                    b附件 = ReturnInt(dtrole.Rows[0]["S8"]);
                    bBack = ReturnBoolean(dtrole.Rows[0]["B1"]);
                    b表头权限 = ReturnBoolean(dtrole.Rows[0]["B2"]);
                    b监察 = ReturnInt(dtrole.Rows[0]["S9"]);
                }
                xtraTabShow();
                
                if (iID != "")
                {
                    GetGrid();
                }
                else
                {
                    btnLast();
                    SetEnabled(false);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void GetGrid()
        {
            try
            {
                if (iID != "")
                {
                    dtBingHead = clsWeb.dtProject(0, iID);
                    if (dtBingHead.Rows.Count > 0)
                    {
                        textEditID.EditValue = dtBingHead.Rows[0]["iID"].ToString().Trim();

                        txt工程编号.EditValue = dtBingHead.Rows[0]["cCode"].ToString().Trim();
                        txt工程名称.EditValue = dtBingHead.Rows[0]["cName"].ToString().Trim();
                        //txt开票情况.EditValue = dtBingHead.Rows[0]["InvoiceState"].ToString().Trim();
                        txt线路名称.EditValue = dtBingHead.Rows[0]["LineName"].ToString().Trim();
                        txt工程量.EditValue = dtBingHead.Rows[0]["iQuantity"].ToString().Trim();
                        txt备注.EditValue = dtBingHead.Rows[0]["Remark"].ToString().Trim();

                        lookUpEdit工程地区.EditValue = dtBingHead.Rows[0]["cDCCode"].ToString().Trim();
                        txt进度.EditValue = dtBingHead.Rows[0]["进度"].ToString().Trim();
                        lookUpEdit工程类型.EditValue = dtBingHead.Rows[0]["cPCCode"].ToString().Trim();
                        buttonEdit工程性质.EditValue = dtBingHead.Rows[0]["cECode"].ToString().Trim();
                        chk结案.Checked = ReturnBoolean(dtBingHead.Rows[0]["EndState"].ToString().Trim());
                        chkIsInvoice.Checked = ReturnBoolean(dtBingHead.Rows[0]["IsInvoice"].ToString().Trim());
                        dateEdit接收日期.EditValue = ReturnDateTimeString(dtBingHead.Rows[0]["dDate"].ToString().Trim());

                        dateEdit计划决算资料提交日期.EditValue = ReturnDateTimeString(dtBingHead.Rows[0]["Date1"].ToString().Trim());
                        dateEdit决算资料提交日期.EditValue = ReturnDateTimeString(dtBingHead.Rows[0]["Date2"].ToString().Trim());
                        dateEdit计划竣工资料上报日期.EditValue = ReturnDateTimeString(dtBingHead.Rows[0]["Date3"].ToString().Trim());
                        dateEdit竣工资料上报日期.EditValue = ReturnDateTimeString(dtBingHead.Rows[0]["Date4"].ToString().Trim());
                        dateEdit计划竣工日期.EditValue = ReturnDateTimeString(dtBingHead.Rows[0]["Date5"].ToString().Trim());
                        dateEdit竣工日期.EditValue = ReturnDateTimeString(dtBingHead.Rows[0]["Date6"].ToString().Trim());


                        dateEditdCreateTime.EditValue = ReturnDateTimeString(dtBingHead.Rows[0]["dCreateTime"].ToString().Trim());
                        dateEditdModifyTime.EditValue = ReturnDateTimeString(dtBingHead.Rows[0]["dModifyTime"].ToString().Trim());
                        txtdCreatePerson.EditValue = dtBingHead.Rows[0]["dCreatePerson"].ToString().Trim();
                        txtdModifyPerson.EditValue = dtBingHead.Rows[0]["dModifyPerson"].ToString().Trim();
                        text审核人.EditValue = dtBingHead.Rows[0]["dVerifyPerson"].ToString().Trim();
                        dateEdit审核日期.EditValue = dtBingHead.Rows[0]["dVerifyTime"].ToString().Trim();
                        if (dtBingHead.Rows[0]["IsCheck"].ToString().Trim() != "")
                        {
                            radioGroup监察.EditValue = ReturnBoolean(dtBingHead.Rows[0]["IsCheck"].ToString().Trim());
                        }
                        else
                        {
                            radioGroup监察.EditValue = null;
                        }
                        txtCheckRemark.EditValue = dtBingHead.Rows[0]["CheckRemark"].ToString().Trim();
                        lblCheckPerson.Text = dtBingHead.Rows[0]["CheckPerson"].ToString().Trim();
                        lblCheckTime.Text = ReturnDateTimeString(dtBingHead.Rows[0]["CheckTime"].ToString().Trim());
                       
                        
                        GetShowcPCCode();

                        gridControl1.DataSource = clsWeb.dtProject(1, iID);
                        gridControl4.DataSource = clsWeb.dtProject(4, iID);
                        gridControl5.DataSource = clsWeb.dtProject(5, iID);
                        dtpro = clsWeb.dtProject(6, iID);
                        GetProgress(dtpro);
                        gridControl8.DataSource = clsWeb.dtProject(8, iID);

                        //gridView1.AddNewRow();
                        gridView4.AddNewRow();
                        //gridView5.AddNewRow();
                        gridView8.AddNewRow();

                        gridView1.FocusedRowHandle = 0;
                        gridView4.FocusedRowHandle = 0;
                        gridView5.FocusedRowHandle = 0;
                        gridView8.FocusedRowHandle = 0;
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
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        private void xtraTabShow()
        {
            if (b材料登记 == 2 || b材料登记 == 3)
            {
                xtraTab材料登记.PageVisible = true;
            }
            else
            {
                xtraTab材料登记.PageVisible = false;
            }

            if (b工程质量登记 == 2 || b工程质量登记 == 3)
            {
                xtraTab质量登记.PageVisible = true;
            }
            else
            {
                xtraTab质量登记.PageVisible = false;
            }

            if (b安全登记 == 2 || b安全登记 == 3)
            {
                xtraTab安全登记.PageVisible = true;
            }
            else
            {
                xtraTab安全登记.PageVisible = false;
            }

            if (b供电公司工程进度 == 2 || b供电公司工程进度 == 3)
            {
                xtraTab供电公司工程进度.PageVisible = true;
            }
            else
            {
                xtraTab供电公司工程进度.PageVisible = false;
            }

            if (b公司工程进度 == 2 || b公司工程进度 == 3)
            {
                xtraTab公司工程进度.PageVisible = true;
            }
            else
            {
                xtraTab公司工程进度.PageVisible = false;
            }

            if (b附件 == 2 || b附件 == 3)
            {
                xtraTab附件.PageVisible = true;
            }
            else
            {
                xtraTab附件.PageVisible = false;
            }

            if (b监察 == 2 || b监察 == 3)
            {
                xtraTabPage监察.PageVisible = true;
            }
            else
            {
                xtraTabPage监察.PageVisible = false;
            }
        }

        private void GetProgress(Control进展 uc, string iText, string dDate, string PersonName, bool chk, bool bBack, string PID, string iID)
        {
            uc.Set(iID, PID, bBack, iText, PersonName, dDate);
        }

        private void GetProgress(DataTable dtp)
        {
            for (int i = 0; i < dtp.Rows.Count; i++)
            {
                string ControlID=dtp.Rows[i]["ControlID"].ToString();
                string PID = dtp.Rows[i]["PID"].ToString();
                string iText = dtp.Rows[i]["iText"].ToString();
                string dDate = "";
                bool chk = false;
                if (dtp.Rows[i]["dDate"].ToString() != "")
                {
                    dDate = dtp.Rows[i]["dDate"].ToString();
                    chk = ReturnBoolean(true);
                }
                string PersonName = dtp.Rows[i]["PersonName"].ToString();
                
                #region 
                switch (ControlID)
                {
                    case "1": GetProgress(control进展1, iText, dDate, PersonName, chk, bBack, PID, iID); break;
                    case "2": GetProgress(control进展2, iText, dDate, PersonName, chk, bBack, PID, iID); break;
                    case "3": GetProgress(control进展3, iText, dDate, PersonName, chk, bBack, PID, iID); break;
                    case "4": GetProgress(control进展4, iText, dDate, PersonName, chk, bBack, PID, iID); break;
                    case "5": GetProgress(control进展5, iText, dDate, PersonName, chk, bBack, PID, iID); break;
                    case "6": GetProgress(control进展6, iText, dDate, PersonName, chk, bBack, PID, iID); break;
                    case "7": GetProgress(control进展7, iText, dDate, PersonName, chk, bBack, PID, iID); break;
                    case "8": GetProgress(control进展8, iText, dDate, PersonName, chk, bBack, PID, iID); break;
                    case "9": GetProgress(control进展9, iText, dDate, PersonName, chk, bBack, PID, iID); break;
                    case "10": GetProgress(control进展10, iText, dDate, PersonName, chk, bBack, PID, iID); break;
                    case "11": GetProgress(control进展11, iText, dDate, PersonName, chk, bBack, PID, iID); break;
                    case "12": GetProgress(control进展12, iText, dDate, PersonName, chk, bBack, PID, iID); break;
                    case "13": GetProgress(control进展13, iText, dDate, PersonName, chk, bBack, PID, iID); break;
                    case "14": GetProgress(control进展14, iText, dDate, PersonName, chk, bBack, PID, iID); break;
                    case "15": GetProgress(control进展15, iText, dDate, PersonName, chk, bBack, PID, iID); break;
                    case "16": GetProgress(control进展16, iText, dDate, PersonName, chk, bBack, PID, iID); break;
                    case "17": GetProgress(control进展17, iText, dDate, PersonName, chk, bBack, PID, iID); break;
                    case "18": GetProgress(control进展18, iText, dDate, PersonName, chk, bBack, PID, iID); break;
                    case "19": GetProgress(control进展19, iText, dDate, PersonName, chk, bBack, PID, iID); break;
                    case "20": GetProgress(control进展20, iText, dDate, PersonName, chk, bBack, PID, iID); break;
                    case "21": GetProgress(control进展21, iText, dDate, PersonName, chk, bBack, PID, iID); break;
                    case "22": GetProgress(control进展22, iText, dDate, PersonName, chk, bBack, PID, iID); break;
                    case "23": GetProgress(control进展23, iText, dDate, PersonName, chk, bBack, PID, iID); break;
                    case "24": GetProgress(control进展24, iText, dDate, PersonName, chk, bBack, PID, iID); break;
                    case "25": GetProgress(control进展25, iText, dDate, PersonName, chk, bBack, PID, iID); break;
                    case "26": GetProgress(control进展26, iText, dDate, PersonName, chk, bBack, PID, iID); break;
                    case "27": GetProgress(control进展27, iText, dDate, PersonName, chk, bBack, PID, iID); break;
                    case "28": GetProgress(control进展28, iText, dDate, PersonName, chk, bBack, PID, iID); break;
                    case "29": GetProgress(control进展29, iText, dDate, PersonName, chk, bBack, PID, iID); break;
                    case "30": GetProgress(control进展30, iText, dDate, PersonName, chk, bBack, PID, iID); break;
                    case "31": GetProgress(control进展31, iText, dDate, PersonName, chk, bBack, PID, iID); break;
                    case "32": GetProgress(control进展32, iText, dDate, PersonName, chk, bBack, PID, iID); break;
                    case "33": GetProgress(control进展33, iText, dDate, PersonName, chk, bBack, PID, iID); break;
                    case "34": GetProgress(control进展34, iText, dDate, PersonName, chk, bBack, PID, iID); break;
                    case "35": GetProgress(control进展35, iText, dDate, PersonName, chk, bBack, PID, iID); break;
                    case "36": GetProgress(control进展36, iText, dDate, PersonName, chk, bBack, PID, iID); break;
                }
                #endregion
            }
        }

        /// <summary>
        /// 下拉列表框
        /// </summary>
        private void SetLookUpEdit()
        {
            lookUp.Inventory(ItemLookUpEdit物料名称);
            ItemLookUpEdit物料名称.Properties.DisplayMember = "cInvName";
            lookUp.Inventory(ItemLookUpEdit物料规格);
            ItemLookUpEdit物料规格.Properties.DisplayMember = "cInvStd";
            lookUp.Inventory(ItemLookUpEdit计量单位);
            ItemLookUpEdit计量单位.Properties.DisplayMember = "cComunitName";

            lookUp.DistrictClass(lookUpEdit工程地区);
            lookUp.Engineering(lookUpEdit工程性质);
            lookUp.LoopUpData(lookUpEdit工程类型, "2");

            lookUp.Person(ItemLookUpEdit4人员);
            lookUp.Person(ItemLookUpEdit5人员);
            lookUp.UserInfo(ItemLookUpEdit8上传人);
            lookUp.Department(ItemLookUpEdit4责任人部门);
            lookUp.Department(ItemLookUpEdit5责任人部门);

            lookUp.LoopUpData(ItemLookUpEdit入库类型, "3");
            lookUp.Quality(ItemLookUpEdit4质量类型);
            lookUp.Security(ItemLookUpEdit5安全类型);
        }

        private void SetEnabled(bool b)
        {
            bool b表头=false;
            if (b == true && b表头权限 == true)
            {
                b表头 = true;
            }
            txt工程编号.Enabled = b表头;
            txt工程名称.Enabled = b表头;
            //txt开票情况.Enabled = b;
            txt线路名称.Enabled = b表头;
            txt工程量.Enabled = b表头;
            txt备注.Enabled = b表头;

            buttonEdit工程性质.Enabled = b表头;
            lookUpEdit工程地区.Enabled = b表头;
            lookUpEdit工程类型.Enabled = b表头;

            chk结案.Enabled = b表头;
            if (lookUpEdit工程类型.EditValue!=null && lookUpEdit工程类型.EditValue.ToString().Trim() == "2")
            {
                chkIsInvoice.Enabled = b表头;
            }
            else
            {
                chkIsInvoice.Enabled = false;
            }

            dateEdit计划决算资料提交日期.Enabled = b表头;
            dateEdit计划竣工日期.Enabled = b表头;
            dateEdit计划竣工资料上报日期.Enabled = b表头;
            dateEdit竣工资料上报日期.Enabled = b表头;
            dateEdit接收日期.Enabled = b表头;
            dateEdit决算资料提交日期.Enabled = b表头;
            dateEdit竣工日期.Enabled = b表头;
            lookUpEdit工程性质.Enabled = false;
           

            if (b == true && b材料登记 == 3)
            {
                gridView1.OptionsBehavior.Editable = true;
            }
            else
            {
                gridView1.OptionsBehavior.Editable = false;
            }
            if (b == true && b工程质量登记 == 3)
            {
                gridView4.OptionsBehavior.Editable = true;
            }
            else
            {
                gridView4.OptionsBehavior.Editable = false;
            }
            if (b == true && b安全登记 == 3)
            {
                gridView5.OptionsBehavior.Editable = true;
            }
            else
            {
                gridView5.OptionsBehavior.Editable = false;
            }
            //gridView8.OptionsBehavior.Editable = b;
            if (b == true && b附件 == 3)
            {
                gridCol8上传附件.OptionsColumn.AllowEdit = true;
                gridCol8备注.OptionsColumn.AllowEdit = true;
                gridCol8附件名称.OptionsColumn.AllowEdit = true;
                gridCol8下载附件.OptionsColumn.AllowEdit = true;
            }
            else
            {
                gridCol8上传附件.OptionsColumn.AllowEdit = false;
                gridCol8备注.OptionsColumn.AllowEdit = false;
                gridCol8附件名称.OptionsColumn.AllowEdit = false;
                gridCol8下载附件.OptionsColumn.AllowEdit = true;
            }

            if (b == false)
            {
                SetEnabled进展1(b);
                SetEnabled进展2(b);
            }

            if (b == true && b监察 == 3)
            {
                SetEnabled监察(true);
            }
            else
            {
                SetEnabled监察(false);
            }
        }

        private void SetEnabled进展1(bool b)
        {
            control进展29.Enable(b);
            control进展30.Enable(b);
            control进展31.Enable(b);
            control进展32.Enable(b);
            control进展33.Enable(b);
            control进展34.Enable(b);
            control进展35.Enable(b);
            control进展36.Enable(b);
        }

        private void SetEnabled进展2(bool b)
        {
            control进展1.Enable(b);
            control进展2.Enable(b);
            control进展3.Enable(b);
            control进展4.Enable(b);
            control进展5.Enable(b);
            control进展6.Enable(b);
            control进展7.Enable(b);
            control进展8.Enable(b);
            control进展9.Enable(b);
            control进展10.Enable(b);
            control进展11.Enable(b);
            control进展12.Enable(b);
            control进展13.Enable(b);
            control进展14.Enable(b);
            control进展15.Enable(b);
            control进展16.Enable(b);
            control进展17.Enable(b);
            control进展18.Enable(b);
            control进展19.Enable(b);

            control进展20.Enable(b);
            control进展21.Enable(b);
            control进展22.Enable(b);
            control进展23.Enable(b);
            control进展24.Enable(b);
            control进展25.Enable(b);
            control进展26.Enable(b);
            control进展27.Enable(b);
            control进展28.Enable(b);
        }

        private void SetEnabled监察(bool b)
        {
            txtCheckRemark.Enabled = b;
            radioGroup监察.Enabled = b;
        }


        private void GetNull()
        {
            try
            {
                textEditID.EditValue = "";
                txt工程编号.EditValue = "";
                txt工程名称.EditValue = "";
                //txt开票情况.EditValue = "";
                txt线路名称.EditValue = "";
                txt工程量.EditValue = "";
                txt备注.EditValue = "";

                txt进度.EditValue = "";
                buttonEdit工程性质.EditValue = "";
                chk结案.Checked = false;
                chkIsInvoice.Checked = false;
                lookUpEdit工程地区.EditValue = null;
                lookUpEdit工程类型.EditValue = DBNull.Value;
                //lookUpEdit工程性质.EditValue = null;

                dateEdit计划决算资料提交日期.EditValue = "";
                dateEdit计划竣工日期.EditValue = "";
                dateEdit计划竣工资料上报日期.EditValue = "";
                dateEdit竣工资料上报日期.EditValue = "";
                dateEdit接收日期.EditValue = "";
                dateEdit决算资料提交日期.EditValue = "";
                dateEdit竣工日期.EditValue = "";

                dateEditdCreateTime.EditValue = "";
                dateEditdModifyTime.EditValue = "";
                txtdCreatePerson.EditValue = "";
                txtdModifyPerson.EditValue = "";
                text审核人.EditValue = "";
                dateEdit审核日期.EditValue = "";

                gridControl1.DataSource = null;
                gridControl4.DataSource = null;
                gridControl5.DataSource = null;
                gridControl8.DataSource = null;

                txtDel1.EditValue = "";
                txtDel2.EditValue = "";
                txtDel3.EditValue = "";
                txtDel4.EditValue = "";
                txtDel5.EditValue = "";
                txtDel8.EditValue = "";

                control进展1.SetNull();
                control进展2.SetNull();
                control进展3.SetNull();
                control进展4.SetNull();
                control进展5.SetNull();
                control进展6.SetNull();
                control进展7.SetNull();
                control进展8.SetNull();
                control进展9.SetNull();
                control进展10.SetNull();
                control进展11.SetNull();
                control进展12.SetNull();
                control进展13.SetNull();
                control进展14.SetNull();
                control进展15.SetNull();
                control进展16.SetNull();
                control进展17.SetNull();
                control进展18.SetNull();
                control进展19.SetNull();
                control进展20.SetNull();
                control进展21.SetNull();
                control进展22.SetNull();
                control进展23.SetNull();
                control进展24.SetNull();
                control进展25.SetNull();
                control进展26.SetNull();
                control进展27.SetNull();
                control进展28.SetNull();
                control进展29.SetNull();
                control进展30.SetNull();
                control进展31.SetNull();
                control进展32.SetNull();
                control进展33.SetNull();
                control进展34.SetNull();
                control进展35.SetNull();
                control进展36.SetNull();

                lblCheckPerson.Text = "";
                lblCheckTime.Text = "";
                txtCheckRemark.EditValue = "";
                radioGroup监察.EditValue = null;
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView1.FocusedRowHandle >= 0)
                    iRow = gridView1.FocusedRowHandle;
                if (e.Column == gridCol1入库数量 || e.Column == gridCol1领料数量)
                {
                    decimal inQty = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol1入库数量), 2);
                    decimal OutQty = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol1领料数量), 2);
                    decimal RQty = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol1退料数量), 2);
                    gridView1.SetRowCellValue(iRow, gridCol1结余数量, inQty - OutQty + RQty);
                }
                #region 新增或更新
                if (e.Column != gridColiSave && gridView1.GetRowCellDisplayText(e.RowHandle, gridColiSave).ToString().Trim() == "")
                {
                    gridView1.SetRowCellValue(iRow, gridColiSave, "add");
                }
                if (e.Column != gridColiSave && gridView1.GetRowCellDisplayText(e.RowHandle, gridColiSave).ToString().Trim() == "edit")
                {
                    gridView1.SetRowCellValue(iRow, gridColiSave, "update");
                }
                if (e.Column != gridColiSave && e.RowHandle == gridView1.RowCount - 1 && gridView1.GetRowCellDisplayText(e.RowHandle, e.Column).ToString().Trim() != "")
                {
                    //gridView1.AddNewRow();
                    gridView1.FocusedRowHandle = gridView1.RowCount - 1;
                    gridView1.FocusedRowHandle = gridView1.RowCount - 2;
                }
                #endregion
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void gridView4_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView4.FocusedRowHandle >= 0)
                    iRow = gridView4.FocusedRowHandle;

                #region 新增或更新
                if (e.Column != gridCol4iSave && gridView4.GetRowCellDisplayText(e.RowHandle, gridCol4iSave).ToString().Trim() == "")
                {
                    gridView4.SetRowCellValue(iRow, gridCol4iSave, "add");
                }
                if (e.Column != gridCol4iSave && gridView4.GetRowCellDisplayText(e.RowHandle, gridCol4iSave).ToString().Trim() == "edit")
                {
                    gridView4.SetRowCellValue(iRow, gridCol4iSave, "update");
                }
                if (e.Column == gridCol4iSave && e.RowHandle == gridView4.RowCount - 1 && gridView4.GetRowCellDisplayText(e.RowHandle, gridCol4iSave).ToString().Trim() != "")
                {
                    gridView4.AddNewRow();
                    gridView4.FocusedRowHandle = gridView4.RowCount - 1;
                    gridView4.FocusedRowHandle = gridView4.RowCount - 2;
                }
                #endregion
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void gridView5_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView5.FocusedRowHandle >= 0)
                    iRow = gridView5.FocusedRowHandle;
                if (e.Column == gridCol5次数)
                {
                    int iScore = ReturnInt(gridView5.GetRowCellValue(iRow, gridCol5分数).ToString().Trim());
                    int iCount = ReturnInt(gridView5.GetRowCellValue(iRow, gridCol5次数).ToString().Trim());
                    int Score = ReturnInt(gridView5.GetRowCellValue(iRow, gridCol5分值).ToString().Trim());
                    iScore = iCount * Score;
                    gridView5.SetRowCellValue(iRow, gridCol5分数, iScore);
                }
                #region 新增或更新
                if (e.Column != gridCol5iSave && gridView5.GetRowCellDisplayText(e.RowHandle, gridCol5iSave).ToString().Trim() == "")
                {
                    gridView5.SetRowCellValue(iRow, gridCol5iSave, "add");
                }
                if (e.Column != gridCol5iSave && gridView5.GetRowCellDisplayText(e.RowHandle, gridCol5iSave).ToString().Trim() == "edit")
                {
                    gridView5.SetRowCellValue(iRow, gridCol5iSave, "update");
                }
                if (e.Column == gridCol5iSave && e.RowHandle == gridView5.RowCount - 1 && gridView5.GetRowCellDisplayText(e.RowHandle, gridCol5iSave).ToString().Trim() != "")
                {
                    //gridView5.AddNewRow();
                    gridView5.FocusedRowHandle = gridView5.RowCount - 1;
                    gridView5.FocusedRowHandle = gridView5.RowCount - 2;
                }
                #endregion
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void gridView8_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView8.FocusedRowHandle >= 0)
                    iRow = gridView8.FocusedRowHandle;

                #region 新增或更新
                if (e.Column != gridCol8iSave && gridView8.GetRowCellDisplayText(e.RowHandle, gridCol8iSave).ToString().Trim() == "")
                {
                    gridView8.SetRowCellValue(iRow, gridCol8iSave, "add");
                }
                if (e.Column != gridCol8iSave && gridView8.GetRowCellDisplayText(e.RowHandle, gridCol8iSave).ToString().Trim() == "edit")
                {
                    gridView8.SetRowCellValue(iRow, gridCol8iSave, "update");
                }
                if (e.Column == gridCol8iSave && e.RowHandle == gridView8.RowCount - 1 && gridView8.GetRowCellDisplayText(e.RowHandle, gridCol8iSave).ToString().Trim() != "")
                {
                    gridView8.AddNewRow();
                    gridView8.FocusedRowHandle = gridView8.RowCount - 1;
                    gridView8.FocusedRowHandle = gridView8.RowCount - 2;
                }
                #endregion
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

        private void gridView4_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void gridView5_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void gridView8_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void ItemButtonEdit物料编码_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int iRow = 0;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.IsRowSelected(i))
                    {
                        iRow = i;
                    }
                }
                string invocde = gridView1.GetRowCellValue(iRow, gridCol1存货编码).ToString().Trim();
                系统服务.Frm参照 frm = new 系统服务.Frm参照(1, invocde);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    gridView1.SetRowCellValue(iRow, gridCol1存货编码, frm.sID);
                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void ItemButtonEdit物料编码_Leave(object sender, EventArgs e)
        {
            try
            {
                int iRow = 0;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.IsRowSelected(i))
                    {
                        iRow = i;
                    }
                }
                string invocde = gridView1.GetRowCellValue(iRow, gridCol1存货编码).ToString().Trim();
                bool b = clsWeb.bClosedInventory(invocde);
                if (b == true)
                {
                    MessageBox.Show(invocde + "存货已关闭");
                    gridView1.SetRowCellValue(iRow, gridCol1存货编码, "");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void ItemButtonEdit4登记人_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int iRow = 0;
                for (int i = 0; i < gridView4.RowCount; i++)
                {
                    if (gridView4.IsRowSelected(i))
                    {
                        iRow = i;
                    }
                }
                string s = "";
                if (gridView4.GetRowCellValue(iRow, gridCol4登记人) != null)
                {
                    s = gridView4.GetRowCellValue(iRow, gridCol4登记人).ToString().Trim();
                }
                系统服务.Frm参照 frm = new 系统服务.Frm参照(2, s);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    gridView4.SetRowCellValue(iRow, gridCol4登记人, frm.sID);
                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void ItemButtonEdit4登记人_Leave(object sender, EventArgs e)
        {
            try
            {
                int iRow = 0;
                for (int i = 0; i < gridView4.RowCount; i++)
                {
                    if (gridView4.IsRowSelected(i))
                    {
                        iRow = i;
                    }
                }
                string PersonCode = gridView4.GetRowCellValue(iRow, gridCol4登记人).ToString().Trim();
                bool b = clsWeb.bClosedPerson(PersonCode);
                if (b == true)
                {
                    MessageBox.Show(PersonCode + "登记人已关闭");
                    gridView4.SetRowCellValue(iRow, gridCol4登记人, "");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void ItemButtonEdit4责任人_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int iRow = 0;
                for (int i = 0; i < gridView4.RowCount; i++)
                {
                    if (gridView4.IsRowSelected(i))
                    {
                        iRow = i;
                    }
                }
                string s = "";
                if (gridView4.GetRowCellValue(iRow, gridCol4责任人) != null)
                {
                    s = gridView4.GetRowCellValue(iRow, gridCol4责任人).ToString().Trim();
                }
                系统服务.Frm参照 frm = new 系统服务.Frm参照(2, s);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    gridView4.SetRowCellValue(iRow, gridCol4责任人, frm.sID);
                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void ItemButtonEdit4责任人_Leave(object sender, EventArgs e)
        {
            try
            {
                int iRow = 0;
                for (int i = 0; i < gridView4.RowCount; i++)
                {
                    if (gridView4.IsRowSelected(i))
                    {
                        iRow = i;
                    }
                }
                string PersonCode = gridView4.GetRowCellValue(iRow, gridCol4责任人).ToString().Trim();
                bool b = clsWeb.bClosedPerson(PersonCode);
                if (b == true)
                {
                    MessageBox.Show(PersonCode + "责任人已关闭");
                    gridView4.SetRowCellValue(iRow, gridCol4责任人, "");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void ItemButtonEdit4责任人部门_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int iRow = 0;
                for (int i = 0; i < gridView4.RowCount; i++)
                {
                    if (gridView4.IsRowSelected(i))
                    {
                        iRow = i;
                    }
                }
                string s = "";
                if (gridView4.GetRowCellValue(iRow, gridCol4责任人部门) != null)
                {
                    s = gridView4.GetRowCellValue(iRow, gridCol4责任人部门).ToString().Trim();
                }
                系统服务.Frm参照 frm = new 系统服务.Frm参照(5, s);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    gridView4.SetRowCellValue(iRow, gridCol4责任人部门, frm.sID);
                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void ItemButtonEdit4责任人部门_Leave(object sender, EventArgs e)
        {
            try
            {
                int iRow = 0;
                for (int i = 0; i < gridView4.RowCount; i++)
                {
                    if (gridView4.IsRowSelected(i))
                    {
                        iRow = i;
                    }
                }
                string PersonCode = gridView4.GetRowCellValue(iRow, gridCol4责任人部门).ToString().Trim();
                bool b = clsWeb.bClosedPerson(PersonCode);
                if (b == true)
                {
                    MessageBox.Show(PersonCode + "责任人部门已关闭");
                    gridView4.SetRowCellValue(iRow, gridCol4责任人部门, "");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void ItemButtonEdit4考核人_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int iRow = 0;
                for (int i = 0; i < gridView4.RowCount; i++)
                {
                    if (gridView4.IsRowSelected(i))
                    {
                        iRow = i;
                    }
                }
                string s = "";
                if (gridView4.GetRowCellValue(iRow, gridCol4考核人) != null)
                {
                    s = gridView4.GetRowCellValue(iRow, gridCol4考核人).ToString().Trim();
                }
                系统服务.Frm参照 frm = new 系统服务.Frm参照(2, s);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    gridView4.SetRowCellValue(iRow, gridCol4考核人, frm.sID);
                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void ItemButtonEdit4考核人_Leave(object sender, EventArgs e)
        {
            try
            {
                int iRow = 0;
                for (int i = 0; i < gridView4.RowCount; i++)
                {
                    if (gridView4.IsRowSelected(i))
                    {
                        iRow = i;
                    }
                }
                string PersonCode = gridView4.GetRowCellValue(iRow, gridCol4考核人).ToString().Trim();
                bool b = clsWeb.bClosedPerson(PersonCode);
                if (b == true)
                {
                    MessageBox.Show(PersonCode + "考核人已关闭");
                    gridView4.SetRowCellValue(iRow, gridCol4考核人, "");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void ItemButtonEdit4分管人_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int iRow = 0;
                for (int i = 0; i < gridView4.RowCount; i++)
                {
                    if (gridView4.IsRowSelected(i))
                    {
                        iRow = i;
                    }
                }
                string s = "";
                if (gridView4.GetRowCellValue(iRow, gridCol4分管人) != null)
                {
                    s = gridView4.GetRowCellValue(iRow, gridCol4分管人).ToString().Trim();
                }
                系统服务.Frm参照 frm = new 系统服务.Frm参照(2, s);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    gridView4.SetRowCellValue(iRow, gridCol4分管人, frm.sID);
                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void ItemButtonEdit4分管人_Leave(object sender, EventArgs e)
        {
            try
            {
                int iRow = 0;
                for (int i = 0; i < gridView4.RowCount; i++)
                {
                    if (gridView4.IsRowSelected(i))
                    {
                        iRow = i;
                    }
                }
                string PersonCode = gridView4.GetRowCellValue(iRow, gridCol4分管人).ToString().Trim();
                bool b = clsWeb.bClosedPerson(PersonCode);
                if (b == true)
                {
                    MessageBox.Show(PersonCode + "分管人已关闭");
                    gridView4.SetRowCellValue(iRow, gridCol4分管人, "");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }


        private void ItemButtonEdit5登记人_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int iRow = 0;
                for (int i = 0; i < gridView5.RowCount; i++)
                {
                    if (gridView5.IsRowSelected(i))
                    {
                        iRow = i;
                    }
                }
                string s = "";
                if (gridView5.GetRowCellValue(iRow, gridCol5登记人) != null)
                {
                    s = gridView5.GetRowCellValue(iRow, gridCol5登记人).ToString().Trim();
                }
                系统服务.Frm参照 frm = new 系统服务.Frm参照(2, s);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    gridView5.SetRowCellValue(iRow, gridCol5登记人, frm.sID);
                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void ItemButtonEdit5登记人_Leave(object sender, EventArgs e)
        {
            try
            {
                int iRow = 0;
                for (int i = 0; i < gridView5.RowCount; i++)
                {
                    if (gridView5.IsRowSelected(i))
                    {
                        iRow = i;
                    }
                }
                string PersonCode = gridView5.GetRowCellValue(iRow, gridCol5登记人).ToString().Trim();
                bool b = clsWeb.bClosedPerson(PersonCode);
                if (b == true)
                {
                    MessageBox.Show(PersonCode + "登记人已关闭");
                    gridView5.SetRowCellValue(iRow, gridCol5登记人, "");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void ItemButtonEdit5责任人_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int iRow = 0;
                for (int i = 0; i < gridView5.RowCount; i++)
                {
                    if (gridView5.IsRowSelected(i))
                    {
                        iRow = i;
                    }
                }
                string s = "";
                if (gridView5.GetRowCellValue(iRow, gridCol5责任人) != null)
                {
                    s = gridView5.GetRowCellValue(iRow, gridCol5责任人).ToString().Trim();
                }
                系统服务.Frm参照 frm = new 系统服务.Frm参照(2, s);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    gridView5.SetRowCellValue(iRow, gridCol5责任人, frm.sID);
                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void ItemButtonEdit5责任人_Leave(object sender, EventArgs e)
        {
            try
            {
                int iRow = 0;
                for (int i = 0; i < gridView5.RowCount; i++)
                {
                    if (gridView5.IsRowSelected(i))
                    {
                        iRow = i;
                    }
                }
                string PersonCode = gridView5.GetRowCellValue(iRow, gridCol5责任人).ToString().Trim();
                bool b = clsWeb.bClosedPerson(PersonCode);
                if (b == true)
                {
                    MessageBox.Show(PersonCode + "责任人已关闭");
                    gridView5.SetRowCellValue(iRow, gridCol5责任人, "");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void ItemButtonEdit5责任人部门_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int iRow = 0;
                for (int i = 0; i < gridView5.RowCount; i++)
                {
                    if (gridView5.IsRowSelected(i))
                    {
                        iRow = i;
                    }
                }
                string s = "";
                if (gridView5.GetRowCellValue(iRow, gridCol5责任人部门) != null)
                {
                    s = gridView5.GetRowCellValue(iRow, gridCol5责任人名称).ToString().Trim();
                }
                系统服务.Frm参照 frm = new 系统服务.Frm参照(5, s);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    gridView5.SetRowCellValue(iRow, gridCol5责任人部门, frm.sID);
                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void ItemButtonEdit5责任人部门_Leave(object sender, EventArgs e)
        {
            try
            {
                int iRow = 0;
                for (int i = 0; i < gridView5.RowCount; i++)
                {
                    if (gridView5.IsRowSelected(i))
                    {
                        iRow = i;
                    }
                }
                string PersonCode = gridView5.GetRowCellValue(iRow, gridCol5责任人名称).ToString().Trim();
                bool b = clsWeb.bClosedPerson(PersonCode);
                if (b == true)
                {
                    MessageBox.Show(PersonCode + "责任人部门已关闭");
                    gridView5.SetRowCellValue(iRow, gridCol5责任人名称, "");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void ItemButtonEdit5考核人_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int iRow = 0;
                for (int i = 0; i < gridView5.RowCount; i++)
                {
                    if (gridView5.IsRowSelected(i))
                    {
                        iRow = i;
                    }
                }
                string s = "";
                if (gridView5.GetRowCellValue(iRow, gridCol5考核人) != null)
                {
                    s = gridView5.GetRowCellValue(iRow, gridCol5考核人).ToString().Trim();
                }
                系统服务.Frm参照 frm = new 系统服务.Frm参照(2, s);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    gridView5.SetRowCellValue(iRow, gridCol5考核人, frm.sID);
                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void ItemButtonEdit5考核人_Leave(object sender, EventArgs e)
        {
            try
            {
                int iRow = 0;
                for (int i = 0; i < gridView5.RowCount; i++)
                {
                    if (gridView5.IsRowSelected(i))
                    {
                        iRow = i;
                    }
                }
                string PersonCode = gridView5.GetRowCellValue(iRow, gridCol5考核人).ToString().Trim();
                bool b = clsWeb.bClosedPerson(PersonCode);
                if (b == true)
                {
                    MessageBox.Show(PersonCode + "考核人已关闭");
                    gridView5.SetRowCellValue(iRow, gridCol5考核人, "");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void ItemButtonEdit5分管人_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int iRow = 0;
                for (int i = 0; i < gridView5.RowCount; i++)
                {
                    if (gridView5.IsRowSelected(i))
                    {
                        iRow = i;
                    }
                }
                string s = "";
                if (gridView5.GetRowCellValue(iRow, gridCol5分管人) != null)
                {
                    s = gridView5.GetRowCellValue(iRow, gridCol5分管人).ToString().Trim();
                }
                系统服务.Frm参照 frm = new 系统服务.Frm参照(2, s);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    gridView5.SetRowCellValue(iRow, gridCol5分管人, frm.sID);
                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void ItemButtonEdit5分管人_Leave(object sender, EventArgs e)
        {
            try
            {
                int iRow = 0;
                for (int i = 0; i < gridView5.RowCount; i++)
                {
                    if (gridView5.IsRowSelected(i))
                    {
                        iRow = i;
                    }
                }
                string PersonCode = gridView5.GetRowCellValue(iRow, gridCol5分管人).ToString().Trim();
                bool b = clsWeb.bClosedPerson(PersonCode);
                if (b == true)
                {
                    MessageBox.Show(PersonCode + "分管人已关闭");
                    gridView5.SetRowCellValue(iRow, gridCol5分管人, "");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void ItemButtonEdit5违章人_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int iRow = 0;
                for (int i = 0; i < gridView5.RowCount; i++)
                {
                    if (gridView5.IsRowSelected(i))
                    {
                        iRow = i;
                    }
                }
                string s = "";
                if (gridView5.GetRowCellValue(iRow, gridCol5违章人) != null)
                {
                    s = gridView5.GetRowCellValue(iRow, gridCol5违章人).ToString().Trim();
                }
                系统服务.Frm参照 frm = new 系统服务.Frm参照(2, s);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    gridView5.SetRowCellValue(iRow, gridCol5违章人, frm.sID);
                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void ItemButtonEdit5违章人_Leave(object sender, EventArgs e)
        {
            try
            {
                int iRow = 0;
                for (int i = 0; i < gridView5.RowCount; i++)
                {
                    if (gridView5.IsRowSelected(i))
                    {
                        iRow = i;
                    }
                }
                string PersonCode = gridView5.GetRowCellValue(iRow, gridCol5违章人).ToString().Trim();
                bool b = clsWeb.bClosedPerson(PersonCode);
                if (b == true)
                {
                    MessageBox.Show(PersonCode + "违章人已关闭");
                    gridView5.SetRowCellValue(iRow, gridCol5违章人, "");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void ItemButtonEdit4质量类型_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int iRow = 0;
                for (int i = 0; i < gridView4.RowCount; i++)
                {
                    if (gridView4.IsRowSelected(i))
                    {
                        iRow = i;
                    }
                }
                string s = "";
                if (gridView4.GetRowCellValue(iRow, gridCol4质量类型) != null)
                {
                    s = gridView4.GetRowCellValue(iRow, gridCol4质量类型).ToString().Trim();
                }
                系统服务.Frm参照 frm = new 系统服务.Frm参照(3, s);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    gridView4.SetRowCellValue(iRow, gridCol4质量类型, frm.sID);
                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void ItemButtonEdit4质量类型_Leave(object sender, EventArgs e)
        {
            try
            {
                int iRow = 0;
                for (int i = 0; i < gridView4.RowCount; i++)
                {
                    if (gridView4.IsRowSelected(i))
                    {
                        iRow = i;
                    }
                }
                string cQCode = gridView4.GetRowCellValue(iRow, gridCol4质量类型).ToString().Trim();
                bool b = clsWeb.bClosedQuality(cQCode);
                if (b == true)
                {
                    MessageBox.Show(cQCode + "质量类型已关闭");
                    gridView4.SetRowCellValue(iRow, gridCol4质量类型, "");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void ItemButtonEdit5安全类型_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int iRow = 0;
                for (int i = 0; i < gridView5.RowCount; i++)
                {
                    if (gridView5.IsRowSelected(i))
                    {
                        iRow = i;
                    }
                }
                string s = "";
                if (gridView5.GetRowCellValue(iRow, gridCol5安全类型) != null)
                {
                    s = gridView5.GetRowCellValue(iRow, gridCol5安全类型).ToString().Trim();
                }
                系统服务.Frm参照 frm = new 系统服务.Frm参照(4, s);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    gridView5.SetRowCellValue(iRow, gridCol5安全类型, frm.sID);
                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void ItemButtonEdit5安全类型_Leave(object sender, EventArgs e)
        {
            try
            {
                int iRow = 0;
                for (int i = 0; i < gridView5.RowCount; i++)
                {
                    if (gridView5.IsRowSelected(i))
                    {
                        iRow = i;
                    }
                }
                string cSCode = gridView5.GetRowCellValue(iRow, gridCol5安全类型).ToString().Trim();
                bool b = clsWeb.bClosedSecurity(cSCode);
                if (b == true)
                {
                    MessageBox.Show(cSCode + "安全类型已关闭");
                    gridView5.SetRowCellValue(iRow, gridCol5安全类型, "");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void ItemButtonEdit8上传附件_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int iRow = 0;
                for (int i = 0; i < gridView8.RowCount; i++)
                {
                    if (gridView8.IsRowSelected(i))
                    {
                        iRow = i;
                    }
                }
                if (gridView8.GetRowCellValue(iRow, gridCol8上传人名称).ToString() != "")
                {
                    MessageBox.Show("附件已上传");
                }
                else
                {
                    OpenFileDialog openFileDialog1 = new OpenFileDialog();
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string filename = openFileDialog1.FileName;
                        FileStream file = new FileStream(filename, FileMode.Open, FileAccess.Read);
                        byte[] bytes = new byte[file.Length];

                        //读取文件保存到字节流对象
                        file.Read(bytes, 0, bytes.Length);
                        string filenewname = clsWeb.UploadFile(iID, filename, bytes);
                        gridView8.SetRowCellValue(iRow, gridCol8下载附件, filenewname);
                        gridView8.SetRowCellValue(iRow, gridCol8附件名称, Path.GetFileNameWithoutExtension(filename));
                        gridView8.SetRowCellValue(iRow, gridCol8上传人名称, 系统服务.ClsBaseDataInfo.sUid);
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        
        private void ItemButtonEdit下载附件_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int iRow = 0;
                for (int i = 0; i < gridView8.RowCount; i++)
                {
                    if (gridView8.IsRowSelected(i))
                    {
                        iRow = i;
                    }
                }
                string filenew = gridView8.GetRowCellValue(iRow, gridCol8下载附件).ToString().Trim();
                byte[] bytes = clsWeb.DownloadFile(iID, filenew);
                if (bytes != null)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.FileName = gridView8.GetRowCellValue(iRow, gridCol8附件名称).ToString().Trim() + Path.GetExtension(filenew);
                    saveFileDialog1.Filter = "txt files(*" + Path.GetExtension(filenew) + ")|*.*";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(saveFileDialog1.FileName + Path.GetExtension(filenew), bytes);
                    }
                }
                else
                {
                    MessageBox.Show("未找到附件");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void lookUpEdit工程类型_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetShowcPCCode();

                if (lookUpEdit工程类型.EditValue.ToString().Trim() == "1")
                {
                    layoutControlItem22.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layoutControlItem12.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
                else
                {
                    layoutControlItem22.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    layoutControlItem12.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never; 
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        private void GetShowcPCCode()
        {
            if (lookUpEdit工程类型.EditValue == null)
            {
                xtraTab供电公司工程进度.PageVisible = false;
                xtraTab公司工程进度.PageVisible = false;
            }
            else
            {
                if (lookUpEdit工程类型.EditValue.ToString() == "1")
                {
                    xtraTab供电公司工程进度.PageVisible = true;
                    xtraTab公司工程进度.PageVisible = false;
                    if (b供电公司工程进度 == 1)
                    {
                        xtraTab供电公司工程进度.PageVisible = false;
                    }
                    else if (b供电公司工程进度 == 2 || b供电公司工程进度 == 3)
                    {
                        xtraTab供电公司工程进度.PageVisible = true;
                        if (b供电公司工程进度 == 2)
                        {

                        }
                    }
                    chkIsInvoice.Enabled = false;
                }
                else if (lookUpEdit工程类型.EditValue.ToString() == "2")
                {
                    xtraTab供电公司工程进度.PageVisible = false;
                    xtraTab公司工程进度.PageVisible = true;

                    if (b公司工程进度 == 1)
                    {
                        xtraTab公司工程进度.PageVisible = false;
                    }
                    else if (b公司工程进度 == 2 || b公司工程进度 == 3)
                    {
                        xtraTab公司工程进度.PageVisible = true;
                        if (b公司工程进度 == 2)
                        {

                        }
                    }
                    
                    if (b表头权限 == true)
                    {
                        chkIsInvoice.Enabled = true;
                    }
                    else
                    {
                        chkIsInvoice.Enabled = false;
                    }
                }
                else
                {
                    xtraTab供电公司工程进度.PageVisible = false;
                    xtraTab公司工程进度.PageVisible = false;
                }
            }
        }

        private void buttonEdit工程性质_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                系统服务.Frm参照 frm = new 系统服务.Frm参照(6);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    buttonEdit工程性质.EditValue = frm.sID;
                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit工程性质_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit工程性质.Text.Trim() != "")
                {
                    lookUpEdit工程性质.EditValue = buttonEdit工程性质.Text.Trim();
                }
                else
                {
                    lookUpEdit工程性质.EditValue = null;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit工程性质_Leave(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit工程性质.Text.Trim() == "")
                    return;

                string cECode = buttonEdit工程性质.Text;
                bool b = clsWeb.bClosedEngineering(cECode);
                if (b == true)
                {
                    MessageBox.Show(cECode + "工程性质已关闭");
                    buttonEdit工程性质.Text = "";
                }

                if (lookUpEdit工程性质.Text.Trim() == "")
                {
                    buttonEdit工程性质.Text = "";
                    buttonEdit工程性质.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void ItemCheckEdit增加扣分_Click(object sender, EventArgs e)
        {
            try
            {
                int iRow = 0;
                for (int i = 0; i < gridView5.RowCount; i++)
                {
                    if (gridView5.IsRowSelected(i))
                    {
                        iRow = i;
                    }
                }
                int iScore = ReturnInt(gridView5.GetRowCellValue(iRow, gridCol5分数).ToString().Trim());
                int iCount = ReturnInt(gridView5.GetRowCellValue(iRow, gridCol5次数).ToString().Trim());
                int Score = ReturnInt(gridView5.GetRowCellValue(iRow, gridCol5分值).ToString().Trim());
                iCount = iCount + 1;
                iScore = iCount * Score;
                gridView5.SetRowCellValue(iRow, gridCol5分数, iScore);
                gridView5.SetRowCellValue(iRow, gridCol5次数, iCount);
                gridView5.SetRowCellValue(iRow, gridCol5增加扣分, false);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void ItemCheckEdit减少扣分_Click(object sender, EventArgs e)
        {
            try
            {
                int iRow = 0;
                for (int i = 0; i < gridView5.RowCount; i++)
                {
                    if (gridView5.IsRowSelected(i))
                    {
                        iRow = i;
                    }
                }
                int iScore = ReturnInt(gridView5.GetRowCellValue(iRow, gridCol5分数).ToString().Trim());
                int iCount = ReturnInt(gridView5.GetRowCellValue(iRow, gridCol5次数).ToString().Trim());
                int Score = ReturnInt(gridView5.GetRowCellValue(iRow, gridCol5分值).ToString().Trim());
                iCount = iCount - 1;
                iScore = iCount * Score;
                gridView5.SetRowCellValue(iRow, gridCol5分数, iScore);
                gridView5.SetRowCellValue(iRow, gridCol5次数, iCount);
                gridView5.SetRowCellValue(iRow, gridCol5减少扣分, false);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }


    }
}
