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
    public partial class Frm仓库盘点 : 系统服务.FrmBaseInfo
    {
        string iID = "";
        public string iCode1 = "";
        public string iCode2 = "";
        public string dDate1 = "";
        public string dDate2 = "";
        public string cInvCode1 = "";
        public string cInvCode2 = "";
        string cRsCode = "01";

        public Frm仓库盘点(string siID)
        {
            iID = siID;
            InitializeComponent();
            
        }

        public Frm仓库盘点()
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
                Frm仓库盘点_Add frm = new Frm仓库盘点_Add(iCode1, iCode2, dDate1, dDate2, cInvCode1, cInvCode2);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    frm.Enabled = true;
                    iCode1 = frm.iCode1;
                    iCode2 = frm.iCode2;
                    dDate1 = frm.dDate1;
                    dDate2 = frm.dDate2;
                    cInvCode1 = frm.cInvCode1;
                    cInvCode2 = frm.cInvCode2;
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
                dtSel = clsWeb.dtListRdRecord(iCode1, iCode2, dDate1, dDate2, cInvCode1, cInvCode2, cRsCode);
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
                iID = clsWeb.siIDRdRecord(1, "", cRsCode);
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
                    iID = clsWeb.siIDRdRecord(2, iID, cRsCode);
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
                    iID = clsWeb.siIDRdRecord(3, iID, cRsCode);
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
                iID = clsWeb.siIDRdRecord(4, "", cRsCode);
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
            try
            {
                #region gridView1
                for (int i = gridView1.RowCount - 2; i >= 0; i--)
                {
                    if (gridView1.IsRowSelected(i))
                    {
                        if (gridView1.GetRowCellDisplayText(i, gridCol序号).ToString().Trim() != "")
                        {
                            if (txtDel.EditValue != null && txtDel.EditValue.ToString().Trim() != "")
                            {
                                txtDel.EditValue = txtDel.EditValue.ToString().Trim() + "," + gridView1.GetRowCellDisplayText(i, gridCol序号).ToString().Trim();
                            }
                            else
                            {
                                txtDel.EditValue = gridView1.GetRowCellDisplayText(i, gridCol序号).ToString().Trim();
                            }
                        }
                        gridView1.DeleteRow(i);
                    }
                }
                
                #endregion

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
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
                dateEdit单据日期.EditValue = 系统服务.ClsBaseDataInfo.sLogDate;

                int iFocRow = gridView1.FocusedRowHandle;

                dtBingHead = clsWeb.dtnewRdRecord(0);
                gridControl1.DataSource = clsWeb.dtnewRdRecord(1);
                try
                {
                    gridView1.FocusedColumn = gridCol存货编码;
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
                if (txt单据号.Text.Trim() == "")
                {
                    throw new Exception("请选择需要修改的单据");
                }

                int iRe = CheState(textEditID.Text.Trim());
                if (iRe == -1)
                {
                    throw new Exception("检查单据状态出错");
                }
                if (iRe == 0)
                {
                    throw new Exception("单据不存在");
                }

                SetEnabled(true);
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

                    string sErr = clsWeb.delRdRecord(textEditID.EditValue.ToString());

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
                DataRow dw;
                if (sState == "add")
                {
                    dw = dtBingHead.NewRow();
                    dw["iSave"] = "add";
                }
                else
                {
                    dw = dtBingHead.Rows[0];
                    dw["iSave"] = "update";
                }
                if (txt单据号.EditValue == null && txt单据号.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("单据号不可为空");
                }
                if (dateEdit单据日期.EditValue == null && dateEdit单据日期.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("单据日期不可为空");
                }
                dw["cRdCode"] = txt单据号.EditValue;
                dw["cRsCode"] = cRsCode;
                dw["Remark"] = txt备注.EditValue;

                if (dateEdit单据日期.EditValue != null)
                {
                    dw["dDate"] = dateEdit单据日期.EditValue;
                }
                if (sState == "add")
                {
                    dtBingHead.Rows.Add(dw);
                }
                string del = "";
                if (txtDel.EditValue != null)
                {
                    del = txtDel.EditValue.ToString().Trim();
                }
                string sErr = clsWeb.saveRdRecord(系统服务.ClsBaseDataInfo.sUid, dtBingHead, (DataTable)gridControl1.DataSource, del);

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

        private void Frm仓库盘点_Load(object sender, EventArgs e)
        {
            try
            {
                GetLayOut(layoutControl1, gridControl1);
                GetGridViewSet(gridView1);
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
            try
            {
                if (iID != "")
                {
                    dtBingHead = clsWeb.dtRdRecord(0, iID, cRsCode);
                    if (dtBingHead.Rows.Count > 0)
                    {
                        textEditID.EditValue = dtBingHead.Rows[0]["iID"].ToString().Trim();

                        txt单据号.EditValue = dtBingHead.Rows[0]["cRdCode"].ToString().Trim();
                        txt备注.EditValue = dtBingHead.Rows[0]["Remark"].ToString().Trim();

                        dateEdit单据日期.EditValue = ReturnDateTimeString(dtBingHead.Rows[0]["dDate"].ToString().Trim());

                        dateEditdCreateTime.EditValue = dtBingHead.Rows[0]["dCreateTime"].ToString().Trim();
                        dateEditdModifyTime.EditValue = dtBingHead.Rows[0]["dModifyTime"].ToString().Trim();
                        txtdCreatePerson.EditValue = dtBingHead.Rows[0]["dCreatePerson"].ToString().Trim();
                        txtdModifyPerson.EditValue = dtBingHead.Rows[0]["dModifyPerson"].ToString().Trim();

                        gridControl1.DataSource = clsWeb.dtRdRecord(1, iID, cRsCode);

                        gridView1.AddNewRow();

                        gridView1.FocusedRowHandle = 0;
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

        }

        private void SetEnabled(bool b)
        {
            txt备注.Enabled = b;
            dateEdit单据日期.Enabled = b;

            gridView1.OptionsBehavior.Editable = b;
        }

        private void GetNull()
        {
            textEditID.EditValue = "";
            txt单据号.EditValue = "";
            txt备注.EditValue = "";

            dateEdit单据日期.EditValue = "";

            dateEditdCreateTime.EditValue = "";
            dateEditdModifyTime.EditValue = "";
            txtdCreatePerson.EditValue = "";
            txtdModifyPerson.EditValue = "";

            gridControl1.DataSource = null;

            txtDel.EditValue = "";
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView1.FocusedRowHandle >= 0)
                    iRow = gridView1.FocusedRowHandle;

                if (e.Column == gridCol存货编码)
                {
                    string cInvCode = gridView1.GetRowCellDisplayText(e.RowHandle, gridCol存货编码).ToString().Trim();
                    if (cInvCode != "")
                    {
                        decimal qty = clsWeb.NowQty(cInvCode);
                        if (qty == -1)
                        {
                            throw new Exception("获取账面数量失败");
                        }
                        else
                        {
                            gridView1.SetRowCellValue(e.RowHandle, gridCol账面数量, qty);
                        }
                    }
                    else
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridCol账面数量, null);
                    }
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
                    gridView1.AddNewRow();
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

        /// <summary>
        /// 判断单据状态
        /// </summary>
        /// <param name="sCode">单据号</param>
        /// <returns>-1：出错</returns>
        /// <returns>0 ：不存在单据</returns>
        /// <returns>1 ：已保存</returns>
        /// <returns>2 ：已审核</returns>
        /// <returns>3 ：已关闭</returns>
        private int CheState(string iID)
        {
            int iReturn = -1;
            try
            {
                DataTable dt = clsWeb.dtRdRecord(0, iID, cRsCode);
                if (dt == null || dt.Rows.Count < 1)
                    iReturn = 0;
                else
                    iReturn = 1;
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
                string invocde = gridView1.GetRowCellValue(iRow, gridCol存货编码).ToString().Trim();
                系统服务.Frm参照 frm = new 系统服务.Frm参照(1, invocde);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    gridView1.SetRowCellValue(iRow, gridCol存货编码, frm.sID);
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
                string invocde = gridView1.GetRowCellValue(iRow, gridCol存货编码).ToString().Trim();
                bool b = clsWeb.bClosedInventory(invocde);
                if (b == true)
                {
                    MessageBox.Show(invocde + "存货已关闭");
                    gridView1.SetRowCellValue(iRow, gridCol存货编码, "");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
