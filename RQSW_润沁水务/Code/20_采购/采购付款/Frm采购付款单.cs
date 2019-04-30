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

namespace 采购
{
    public partial class Frm采购付款单 : 系统服务.FrmBaseInfo
    {
        string tablename = "PO_CloseBill";
        string tableid = "cPOCCode";
        string tablenames = "PO_CloseBillDetails";

        long iID = -1;
        public string 单据号1 = "";
        public string 单据号2 = "";
        public string 单据日期1 = "";
        public string 单据日期2 = "";
        public string 制单日期1 = "";
        public string 制单日期2 = "";
        public string 业务员 = "";
        public string 部门 = "";
        public string 供应商1 = "";
        public string 供应商2 = "";
        public string 审核日期1 = "";
        public string 审核日期2 = "";
        public string 制单人1 = "";
        public string 制单人2 = "";
        public string 审核人1 = "";
        public string 审核人2 = "";
        public string 物料1 = "";
        public string 物料2 = ""; 
        decimal d付款金额 = 0;

        string isChange = "";

        public Frm采购付款单(long siID)
        {
            iID = siID;
            InitializeComponent();
            
        }

        public Frm采购付款单()
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
            throw new NotImplementedException();
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
            Frm采购付款单_Add frm = new Frm采购付款单_Add(单据号1, 单据号2, 单据日期1, 单据日期2, 制单日期1, 制单日期2, 业务员,
               部门, 供应商1, 供应商2, 审核日期1, 审核日期2, 制单人1, 制单人2, 审核人1, 审核人2, 物料1, 物料2);
            if (DialogResult.OK == frm.ShowDialog())
            {
                frm.Enabled = true;
                单据号1 = frm.单据号1;
                单据号2 = frm.单据号2;
                单据日期1 = frm.单据日期1;
                单据日期2 = frm.单据日期2;
                制单日期1 = frm.制单日期1;
                制单日期2 = frm.制单日期2;
                业务员 = frm.业务员;
                部门 = frm.部门;
                供应商1 = frm.供应商1;
                供应商2 = frm.供应商2;
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
            sState = "sel";
        }

        private void GetSel()
        {
            string sSQL = "select * from " + tablename + " a left join " + tablenames + "  b on a.ID=b.ID where 1=1";
            if (单据号1 != null && 单据号1 != "")
            {
                sSQL = sSQL + " and a." + tableid + ">='" + 单据号1 + "'";
            }
            if (单据号2 != null && 单据号2 != "")
            {
                sSQL = sSQL + " and a." + tableid + "<='" + 单据号2 + "'";
            }
            if (单据日期1 != null && 单据日期1 != "")
            {
                sSQL = sSQL + " and dDate>='" + 单据日期1 + "'";
            }
            if (单据日期2 != null && 单据日期2 != "")
            {
                sSQL = sSQL + " and dDate<='" + 单据日期2 + "'";
            }
            if (制单日期1 != null && 制单日期1 != "")
            {
                sSQL = sSQL + " and dCreatesysTime>='" + 制单日期1 + "'";
            }
            if (制单日期2 != null && 制单日期2 != "")
            {
                sSQL = sSQL + " and dCreatesysTime<='" + 制单日期2 + "'";
            }
            if (业务员 != null && 业务员 != "")
            {
                sSQL = sSQL + " and cPersonCode='" + 业务员 + "'";
            }
            if (部门 != "")
            {
                sSQL = sSQL + " and cDepCode='" + 部门 + "'";
            }
            if (供应商1 != "")
            {
                sSQL = sSQL + " and cVenCode>='" + 供应商1 + "'";
            }
            if (供应商2 != "")
            {
                sSQL = sSQL + " and cVenCode<='" + 供应商2 + "'";
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
                sSQL = sSQL + " and dVerifysysPerson>='" + 物料1 + "'";
            }
            if (物料2 != "")
            {
                sSQL = sSQL + " and dVerifysysPerson<='" + 物料2 + "'";
            }
            sSQL = sSQL + "  order by a.ID";
            dtSel = clsSQLCommond.ExecQuery(sSQL);
            if (dtSel.Rows.Count > 0)
            {
                iID = Convert.ToInt64(dtSel.Rows[0]["ID"]);
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
                    textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]);;
                    iID = Convert.ToInt64(dt.Rows[0]["ID"]);;
                }
                GetGrid();
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
                if (iID != -1)
                {
                    sSQL = "select ID from " + tablename + " where ID<" + textEditID.Text + " order by ID desc";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt.Rows.Count > 0)
                    {
                        textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]);;
                        iID = Convert.ToInt64(dt.Rows[0]["ID"]);
                    }
                    GetGrid();
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
                if (iID != -1)
                {
                    sSQL = "select ID from " + tablename + " where ID>" + textEditID.Text + " order by ID ";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt.Rows.Count > 0)
                    {
                        textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]);;
                        iID = Convert.ToInt64(dt.Rows[0]["ID"]);;
                    }
                    GetGrid();
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
                sSQL = "select isnull(max(ID),-1) as ID from " + tablename + " ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]);;
                    iID = Convert.ToInt64(dt.Rows[0]["ID"]);
                }
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败：" + ee.Message);
            }
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
            Frm采购发票_New frm = new Frm采购发票_New((DataTable)gridControl1.DataSource);

            if (lookUpEdit供应商.EditValue == null)
                frm.供应商 = "";
            else
                frm.供应商 = lookUpEdit供应商.EditValue.ToString().Trim();

            frm.红蓝标志 = radioGroup蓝红标识.EditValue.ToString().Trim();
            if (DialogResult.OK == frm.ShowDialog())
            {
                bool b = false;

                if (b && lookUpEdit供应商.EditValue != null && frm.供应商.Trim() != lookUpEdit供应商.EditValue.ToString().Trim() && frm.供应商.Trim() != "")
                {
                    throw new Exception("一张单据只能有一个供应商");
                }
                if (b && radioGroup蓝红标识.EditValue != null && frm.红蓝标志.Trim() != radioGroup蓝红标识.EditValue.ToString().Trim())
                {
                    throw new Exception("红蓝标志不能修改");
                }

                radioGroup蓝红标识.EditValue = frm.红蓝标志;
                buttonEdit供应商.EditValue = frm.供应商;

                frm.Enabled = true;
                DataTable dtnew = frm.dt;
                int i = gridView1.RowCount - 1;
                gridView1.FocusedRowHandle = i;
                for (int s = 0; s < dtnew.Rows.Count; s++)
                {
                    if (s != 0)
                    {
                        gridView1.FocusedRowHandle = gridView1.RowCount - 1;
                        i = gridView1.RowCount - 1;
                    }

                    gridView1.SetRowCellValue(i, gridCol来源类型, dtnew.Rows[s]["iType"].ToString());
                    gridView1.SetRowCellValue(i, gridCol来源单据ID, dtnew.Rows[s]["AutoID"].ToString());

                    if (dtnew.Rows[s]["cPBVCode"].ToString() != "")
                    {
                        gridView1.SetRowCellValue(i, gridCol序号, (i + 1).ToString());
                        gridView1.SetRowCellValue(i, gridCol来源单据号 , dtnew.Rows[s]["cPBVCode"].ToString());
                    }
                 
                    if (dtnew.Rows[s]["iMoney"].ToString() != "")
                    {
                        gridView1.SetRowCellValue(i, gridCol发票含税金额, dtnew.Rows[s]["iMoney"].ToString());
                    }
                    if (dtnew.Rows[s]["iNatMoney"].ToString() != "")
                    {
                        gridView1.SetRowCellValue(i, gridCol发票无税金额 , dtnew.Rows[s]["iNatMoney"].ToString());
                    }

                    if (dtnew.Rows[s]["iMoney"].ToString() != "")
                    {
                        gridView1.SetRowCellValue(i, gridCol发票含税金额, dtnew.Rows[s]["iMoney"].ToString());

                        gridView1.SetRowCellValue(i, gridCol税额, ReturnDecimal(gridView1.GetRowCellValue(i,gridCol发票含税金额)) -  ReturnDecimal(gridView1.GetRowCellValue(i,gridCol发票无税金额)));
                    }

                    

                    if (dtnew.Rows[s]["付款金额"].ToString() != "")
                    {
                        gridCol未付金额.Visible = true;
                        gridView1.SetRowCellValue(i, gridCol历史付款金额, dtnew.Rows[s]["付款金额"].ToString());
                        gridView1.SetRowCellValue(i, gridCol未付金额, dtnew.Rows[s]["付款金额"].ToString());
                        //gridView1.SetRowCellValue(i, gridCol付款金额, dtnew.Rows[s]["付款金额"].ToString());
                    }

                }
            }

            d付款金额 = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridCol发票含税金额).ToString().Trim() != "")
                {
                    decimal d含税金额 =  ReturnDecimal(gridView1.GetRowCellValue(i, gridCol未付金额));
                    d付款金额 = d付款金额 + d含税金额;
                }
            }
            //textEdit付款金额.EditValue = d付款金额;
            if (radioGroup蓝红标识.EditValue.ToString().Trim() == "1" && d付款金额 < 0)
            {
                throw new Exception("蓝字单据，金额不小于0");
            }
            if (radioGroup蓝红标识.EditValue.ToString().Trim() == "2" && d付款金额 > 0)
            {
                throw new Exception("蓝字单据，金额小于0");
            }
        }

        /// <summary>
        /// 删行
        /// </summary>
        private void btnDelRow()
        {
            int iRow = 0;
            if (gridView1.RowCount > 0)
                iRow = gridView1.FocusedRowHandle;

            if (gridView1.GetRowCellDisplayText(iRow, gridColAutoID).ToString().Trim() != "")
            {
                if (textEditDel.EditValue != null && textEditDel.EditValue.ToString().Trim() != "")
                {
                    textEditDel.EditValue = textEditDel.EditValue.ToString().Trim() + "," + gridView1.GetRowCellDisplayText(iRow, gridColAutoID).ToString().Trim();
                }
                else
                {
                    textEditDel.EditValue = gridView1.GetRowCellDisplayText(iRow, gridColAutoID).ToString().Trim();
                }
            }
            gridView1.DeleteRow(iRow);

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

            sSQL = "select a.*, 'edit' as iSave,cast(null as decimal(16,6)) as 未付金额,a.付款金额 as 历史付款金额,cast(null as decimal(16,6)) as 发票金额  from " + tablenames + " a  where 1=-1";
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
            radioGroup蓝红标识.EditValue = "1";

            btnAddRow();

            sState = "add";
            gridView1.OptionsBehavior.Editable = true;
        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {
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

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                
                string gs发票号 = gridView1.GetRowCellValue(i, gridCol来源单据号).ToString().Trim();
                decimal d本次金额 = ReturnDecimal(gridView1.GetRowCellValue(i, gridCol付款金额));
                string sType = gridView1.GetRowCellValue(i, gridCol来源类型).ToString().Trim();
                decimal 发票金额 = 0;
                decimal 累计付款金额 = 0;
                long 本单子表ID = -1;
                if (gs发票号 != "")
                {
                    if (gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim() != "")
                    {
                        本单子表ID = Convert.ToInt64(gridView1.GetRowCellValue(i, gridColAutoID));
                    }
                    if (iCodeUsed(gs发票号, sType, 本单子表ID, out 累计付款金额, out 发票金额) == -1)
                    {
                        throw new Exception("获得历史信息失败");
                    }
                    gridView1.SetRowCellValue(i, gridCol未付金额, 发票金额 - 累计付款金额);
                }
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
                aList = new System.Collections.ArrayList();
                sSQL = "delete " + tablenames + " where ID = " + textEditID.Text.Trim();
                aList.Add(sSQL);
                sSQL = "delete " + tablename + " where ID = " + textEditID.Text.Trim();
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

            decimal d金额 = ReturnDecimal(textEdit付款金额.Text);
            if (d金额 == 0)
            {
                textEdit付款金额.Focus();
                throw new Exception("付款金额不能为0");
            }
            decimal d付金额总 = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                d付金额总 = d付金额总 + ReturnDecimal(gridView1.GetRowCellValue(i, gridCol付款金额));
            }
            if (d金额 != d付金额总)
            {
                textEdit付款金额.Focus();
                throw new Exception("付款金额与表体付款金额总和不一致");
            }
            if (d金额 > d付金额总)
            {
                textEdit付款金额.Focus();
                throw new Exception("付款金额不能大于表体付款金额总和");
            }

            bool bHasGrid = false;
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

            sSQL = "select * from " + tablename + " where 1=-1";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            sSQL = "select * from " + tablenames + " where 1=-1";
            DataTable dts = clsSQLCommond.ExecQuery(sSQL);
            string sErr = "";
            if (textEdit单据号.EditValue == null || textEdit单据号.EditValue.ToString().Trim() == "")
            {
                throw new Exception("付款单号不能为空");
            }
            if (radioGroup蓝红标识.EditValue == null || radioGroup蓝红标识.EditValue.ToString().Trim() == "")
            {
                throw new Exception("蓝红标识不能为空");
            }
            if (buttonEdit供应商.EditValue == null || buttonEdit供应商.EditValue.ToString().Trim() == "")
            {
                throw new Exception("供应商不能为空");
            }
            if (textEdit付款金额.EditValue == null || textEdit付款金额.EditValue.ToString().Trim() == "")
            {
                throw new Exception("付款金额不能为空");
            }
            if (dateEdit单据日期.EditValue == null || dateEdit单据日期.EditValue.ToString().Trim() == "")
            {
                throw new Exception("单据日期不能为空");
            }
            if (dateEdit付款日期.EditValue == null || dateEdit付款日期.EditValue.ToString().Trim() == "")
            {
                throw new Exception("付款日期不能为空");
            }
            if (lookUpEdit结算方式.EditValue == null || lookUpEdit结算方式.EditValue.ToString().Trim() == "")
            {
                throw new Exception("结算方式不能为空");
            }
            else
            {
                if (lookUpEdit结算方式.EditValue.ToString().Trim() == "02" && textEdit承兑号.EditValue.ToString().Trim()=="")
                {
                    throw new Exception("承兑号不能为空");
                }
            }
            aList = new System.Collections.ArrayList();
            DataRow drh = dt.NewRow();
            if (sState == "add")
            {
                sSQL = "select isnull(isnull(max(ID),-1)+1,1) as ID from " + tablename;
                iID = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                drh["ID"] = iID;
                //drh["cPOCCode"] = 系统服务.序号.GetNewSerialNumberContinuous(tablename, tableid);
                //textEdit单据号.EditValue = drh["cPOCCode"].ToString();
            }
            else
            {
                drh["ID"] = textEditID.Text;
                iID = Convert.ToInt64(textEditID.Text);
                
            }

            sSQL = "select count(*) from " + tablename + " where cPOCCode='" + textEdit单据号.EditValue.ToString().Trim() + "' and ID<>'" + iID + "'";
            decimal scount = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
            if (scount > 0)
            {
                sErr = sErr + "付款单号不能重复\n";
            }

            drh["cPOCCode"] = textEdit单据号.EditValue.ToString().Trim();
            drh["dDate"] = dateEdit单据日期.EditValue.ToString().Trim();
            drh["付款日期"] = dateEdit付款日期.EditValue.ToString().Trim();

            drh["cPersonCode"] = buttonEdit业务员.EditValue.ToString().Trim();
            drh["cDepCode"] = buttonEdit部门.EditValue.ToString().Trim();
            drh["cVenCode"] = buttonEdit供应商.EditValue.ToString().Trim();
            if (textEdit付款金额.EditValue != null && textEdit付款金额.EditValue.ToString().Trim() != "")
            {
                drh["iAmount"] = textEdit付款金额.EditValue.ToString().Trim();
            }
            drh["cSSCode"] = lookUpEdit结算方式.EditValue.ToString().Trim();

            drh["Flag"] = radioGroup蓝红标识.EditValue.ToString().Trim();

            drh["cMemo"] = textEdit备注.EditValue.ToString().Trim();

            drh["S1"] = textEdit承兑号.EditValue.ToString().Trim();

            if (sState == "add")
            {
                dateEdit制单日期.EditValue = 系统服务.ClsBaseDataInfo.sLogDate;
                textEdit制单人.EditValue = 系统服务.ClsBaseDataInfo.sUid;
            }

            drh["dCreatesysTime"] = dateEdit制单日期.EditValue.ToString().Trim();
            drh["dCreatesysPerson"] = textEdit制单人.EditValue.ToString().Trim();
            
            if (sState == "alter")
            {
                drh["dVerifysysPerson"] = textEdit审核人.Text.Trim();
                drh["dVerifysysTime"] = dateEdit审核日期.Text.Trim();
                drh["dChangeVerifyTime"] = 系统服务.ClsBaseDataInfo.sLogDate;
                drh["dChangeVerifyPerson"] = 系统服务.ClsBaseDataInfo.sUid;
            }
            dt.Rows.Add(drh);
            if (sState == "add")
            {
                sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablename, dt, 0);
                aList.Add(sSQL);
            }
            else
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
            long sID = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "update" || gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "add")
                {
            //        #region 判断
                    if (gridView1.GetRowCellDisplayText(i, gridCol来源单据号).ToString().Trim() == "")
                    {
                        continue;
                    }
                    if (gridView1.GetRowCellDisplayText(i, gridCol付款金额).ToString().Trim() == "" || Convert.ToDecimal(gridView1.GetRowCellDisplayText(i, gridCol付款金额)) == 0)
                    {
                        continue;
                    }

                    string gs发票号 = gridView1.GetRowCellValue(i, gridCol来源单据号).ToString().Trim();
                    decimal d本次金额 = ReturnDecimal(gridView1.GetRowCellValue(i, gridCol付款金额));
                    string sType = gridView1.GetRowCellValue(i, gridCol来源类型).ToString().Trim();
                    decimal 发票金额 = 0;
                    decimal 累计付款金额 = 0;
                    long 本单子表ID = -1;
                    if (gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim() != "")
                    {
                        本单子表ID = Convert.ToInt64(gridView1.GetRowCellValue(i, gridColAutoID));
                    }
                    if (iCodeUsed(gs发票号,sType, 本单子表ID, out 累计付款金额, out 发票金额) == -1)
                    {
                        throw new Exception("获得历史信息失败");
                    }
                    if (radioGroup蓝红标识.EditValue.ToString().Trim() == "1")
                    {
                        if (d本次金额 > 发票金额 - 累计付款金额)
                        {
                            gridView1.SetRowCellValue(i, gridCol付款金额, ReturnDecimal(gridView1.GetRowCellValue(i, gridCol历史付款金额)));
                            throw new Exception("付款金额超出发票未付金额");
                        }
                    }
                    if (radioGroup蓝红标识.EditValue.ToString().Trim() == "2")
                    {
                        if (d本次金额 < 发票金额 - 累计付款金额)
                        {
                            gridView1.SetRowCellValue(i, gridCol付款金额, ReturnDecimal(gridView1.GetRowCellValue(i, gridCol历史付款金额)));
                            throw new Exception("付款金额超出发票未付金额");
                        }
                    }

                    #region 生成table
                    DataRow dr = dts.NewRow();
                    if (gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim() == "")
                    {
                        dr["AutoID"] = sID;
                    }
                    else
                    {
                        dr["AutoID"] = gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim();
                    }
                    dr["ID"] = iID;
                    dr["cPBVCode"] = gridView1.GetRowCellValue(i, gridCol来源单据号).ToString().Trim();
                    dr["cPBVAutoID"] = gridView1.GetRowCellValue(i, gridCol来源单据ID).ToString().Trim();
                    dr["iRowNo"] = gridView1.GetRowCellValue(i, gridCol序号).ToString().Trim();
                    dr["iType"] = gridView1.GetRowCellValue(i, gridCol来源类型).ToString().Trim();

                    if (gridView1.GetRowCellValue(i, gridCol发票含税金额) != null && ReturnDecimal(gridView1.GetRowCellValue(i, gridCol发票含税金额)) != 0)
                    {
                        dr["iMoney"] = ReturnDecimal(gridView1.GetRowCellValue(i, gridCol发票含税金额));
                    }

                    if (gridView1.GetRowCellValue(i, gridCol发票无税金额) != null && ReturnDecimal(gridView1.GetRowCellValue(i, gridCol发票无税金额)) != 0)
                    {
                        dr["iNatMoney"] = ReturnDecimal(gridView1.GetRowCellValue(i, gridCol发票无税金额));
                        dr["iNatTax"] = ReturnDecimal(gridView1.GetRowCellValue(i, gridCol发票含税金额)) - ReturnDecimal(gridView1.GetRowCellValue(i, gridCol发票无税金额));
                    }

                    if (gridView1.GetRowCellValue(i, gridCol付款金额) != null && gridView1.GetRowCellValue(i, gridCol付款金额).ToString().Trim() != "")
                    {
                        dr["付款金额"] = gridView1.GetRowCellValue(i, gridCol付款金额).ToString().Trim();
                    }
                    
                    
                    dr["cMemo"] = gridView1.GetRowCellValue(i, gridCol备注).ToString().Trim();

                    //dr["cClosesysPerson"] = gridView1.GetRowCellValue(i, gridCol行关闭人).ToString().Trim();
                    //dr["cClosesysTime"] = gridView1.GetRowCellValue(i, gridCol行关闭日期).ToString().Trim();

                    dts.Rows.Add(dr);
                    sID = sID + 1;
                    #endregion

                    if (gridView1.GetRowCellDisplayText(i, gridColAutoID).ToString().Trim() != "")
                    {
                        sSQL = clsGetSQL.GetUpdateSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablenames, dts, dts.Rows.Count - 1);
                    }
                    else if (gridView1.GetRowCellDisplayText(i, gridColAutoID).ToString().Trim() == "")
                    {
                        sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablenames, dts, dts.Rows.Count - 1);
                    }

                    aList.Add(sSQL);

                }
                else
                {
                    //if (gridView1.GetRowCellValue(i, gridCol数量).ToString().Trim() != "")
                    //{
                    //    if (radioGroup蓝红标识.EditValue.ToString().Trim() == "1")
                    //    {
                    //        if (ReturnDecimal(gridView1.GetRowCellValue(i, gridCol数量).ToString().Trim()) < 0)
                    //        {
                    //            sErr = sErr + "行" + (i + 1) + gridCol数量.Caption + "需为正\n";
                    //            continue;
                    //        }
                    //    }
                    //    else if (radioGroup蓝红标识.EditValue.ToString().Trim() == "2")
                    //    {
                    //        if (ReturnDecimal(gridView1.GetRowCellValue(i, gridCol数量).ToString().Trim()) >= 0)
                    //        {
                    //            sErr = sErr + "行" + (i + 1) + gridCol数量.Caption + "需为负\n";
                    //            continue;
                    //        }
                    //    }
                    //}
                }
            }
            #endregion
            if (sErr != "")
            {
                throw new Exception(sErr);
            }

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("保存成功！\n合计执行语句:" + iCou + "条");
                textEditID.EditValue = iID;
                GetGrid();

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
            aList = new System.Collections.ArrayList();

            if (textEdit单据号.Text.Trim() == "")
            {
                throw new Exception("没有单据号，不能审核");
            }
            if (textEdit审核人.Text.Trim() != "")
            {
                throw new Exception("已经审核，不能审核");
            }
            if (textEdit关闭人.EditValue.ToString().Trim() != "")
            {
                throw new Exception("已关闭，不能审核");
            }

            sSQL = "update " + tablename + " set dVerifysysTime='" + 系统服务.ClsBaseDataInfo.sLogDate + "',dVerifysysPerson='" + 系统服务.ClsBaseDataInfo.sUid + "' where ID=" + textEditID.Text + "";
            aList.Add(sSQL);

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("审核成功！\n合计执行语句:" + iCou + "条");

                textEdit审核人.EditValue = 系统服务.ClsBaseDataInfo.sUid;
                dateEdit审核日期.EditValue = 系统服务.ClsBaseDataInfo.sLogDate;

                SetEnabled(false);
                sState = "audit";
            }
        }
        /// <summary>
        /// 弃审
        /// </summary>
        private void btnUnAudit()
        {
            aList = new System.Collections.ArrayList();

            if (textEdit单据号.EditValue.ToString().Trim() == "")
            {
                throw new Exception("没有单据号，不能弃审");
            }
            if (textEdit审核人.EditValue.ToString().Trim() == "")
            {
                throw new Exception("未审核，不能弃审");
            }
            if (textEdit关闭人.EditValue.ToString().Trim() != "")
            {
                throw new Exception("已关闭，不能弃审");
            }

            sSQL = "update " + tablename + " set dVerifysysTime=null,dVerifysysPerson=null where ID=" + textEditID.Text + "";
            aList.Add(sSQL);

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("弃审成功！\n合计执行语句:" + iCou + "条");


                textEdit审核人.EditValue = "";
                dateEdit审核日期.EditValue = "";
                sState = "unaudit";
            }
        }
        /// <summary>
        /// 打开
        /// </summary>
        private void btnOpen()
        {
            aList = new System.Collections.ArrayList();

            if (textEdit单据号.EditValue.ToString().Trim() == "")
            {
                throw new Exception("没有单据号，不能打开");
            }
            if (textEdit关闭人.EditValue.ToString().Trim() == "")
            {
                throw new Exception("未关闭，不能打开");
            }

            sSQL = "update " + tablename + " set dClosesysTime=null,dClosesysPerson=null where ID=" + textEditID.Text + "";
            aList.Add(sSQL);
            sSQL = "update " + tablenames + " set cClosesysTime=null,cClosesysPerson=null where ID=" + textEditID.Text + " ";
            aList.Add(sSQL);

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("打开成功！\n合计执行语句:" + iCou + "条");

                textEdit关闭人.EditValue = "";
                dateEdit关闭日期.EditValue = "";
                SetEnabled(false);

                sState = "open";
            }
        }
        /// <summary>
        /// 关闭
        /// </summary>
        private void btnClose()
        {
            aList = new System.Collections.ArrayList();

            if (textEdit单据号.EditValue.ToString().Trim() == "")
            {
                throw new Exception("没有单据号，不能弃审");
            }
            if (textEdit关闭人.EditValue.ToString().Trim() != "")
            {
                throw new Exception("已关闭，不能再次关闭");
            }

            sSQL = "update " + tablename + " set dClosesysTime='" + 系统服务.ClsBaseDataInfo.sLogDate + "',dClosesysPerson='" + 系统服务.ClsBaseDataInfo.sUid + "' where ID=" + textEditID.Text + "";
            aList.Add(sSQL);
            sSQL = "update " + tablenames + " set cClosesysTime='" + 系统服务.ClsBaseDataInfo.sLogDate + "',cClosesysPerson='" + 系统服务.ClsBaseDataInfo.sUid + "' where ID=" + textEditID.Text + " and  (cClosesysPerson='' or cClosesysPerson is null)";
            aList.Add(sSQL);
            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("关闭成功！\n合计执行语句:" + iCou + "条");


                textEdit关闭人.EditValue = 系统服务.ClsBaseDataInfo.sUid;
                dateEdit关闭日期.EditValue = 系统服务.ClsBaseDataInfo.sLogDate;
                sState = "close";
            }
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
            sState = "alter";
            SetEnabled(true);
        }

        #endregion

        private void Frm采购付款单_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookUpEdit();
                if (iID != -1)
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
            if (iID != -1)
            {
                sSQL = "select * from " + tablename + " where ID=" + iID;
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]);;
                    textEdit单据号.EditValue = dt.Rows[0]["cPOCCode"].ToString();
                    textEdit付款金额.EditValue = dt.Rows[0]["iAmount"].ToString();


                    dateEdit单据日期.EditValue = dt.Rows[0]["dDate"].ToString();
                    dateEdit制单日期.EditValue = dt.Rows[0]["dCreatesysTime"].ToString();
                    dateEdit审核日期.EditValue = dt.Rows[0]["dVerifysysTime"].ToString();
                    dateEdit关闭日期.EditValue = dt.Rows[0]["dClosesysTime"].ToString();
                    dateEdit付款日期.EditValue = dt.Rows[0]["付款日期"].ToString();

                    textEdit备注.EditValue = dt.Rows[0]["cMemo"].ToString();
                    textEdit制单人.EditValue = dt.Rows[0]["dCreatesysPerson"].ToString();
                    textEdit审核人.EditValue = dt.Rows[0]["dVerifysysPerson"].ToString();
                    textEdit关闭人.EditValue = dt.Rows[0]["dClosesysPerson"].ToString();

                    buttonEdit供应商.EditValue = dt.Rows[0]["cVenCode"].ToString();
                    buttonEdit业务员.EditValue = dt.Rows[0]["cPersonCode"].ToString();
                    buttonEdit部门.EditValue = dt.Rows[0]["cDepCode"].ToString();
                   
                    lookUpEdit结算方式.EditValue = dt.Rows[0]["cSSCode"].ToString();

                    radioGroup蓝红标识.EditValue = dt.Rows[0]["Flag"].ToString();

                    textEdit承兑号.EditValue = dt.Rows[0]["S1"].ToString();

                    buttonEdit供应商.Enabled = false;
                    sSQL = "select a.*,'edit' as iSave,cast(null as decimal(16,6)) as 未付金额,a.付款金额 as 历史付款金额,cast(null as decimal(16,6)) as 发票金额 "
                    + " from " + tablenames + " a left join PurBillVouchs b on a.cPBVCode=b.AutoID left join RdRecords r on b.RdRecordPOAutoID=r.AutoID where a.ID=" + iID + " order by a.iRowNo";

                    dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
                    gridControl1.DataSource = dtBingGrid;

                    
                    gridView1.AddNewRow();

                    gridView1.FocusedRowHandle = iFocRow;
                    SetEnabled(false);
                }
                else
                {
                    GetNull();
                }
            }
            else
            {
                GetNull();
            }

            SetEnabled(false);
            sState = "sel";
        }

        /// <summary>
        /// 下拉列表框
        /// </summary>
        private void SetLookUpEdit()
        {
            lookUpEdit结算方式.Properties.DataSource = 系统服务.LookUp.SettleStyle();
            系统服务.LookUp.Vendor(lookUpEdit供应商);
            系统服务.LookUp.Person(lookUpEdit业务员);
            系统服务.LookUp.Department(lookUpEdit部门);
            系统服务.LookUp._LoopUpData(ItemLookUpEdit来源类型, "24");
        }

        private void SetEnabled(bool b)
        {
            gridCol未付金额.Visible = b;

            dateEdit单据日期.Enabled = b;
            dateEdit制单日期.Enabled = false;
            dateEdit审核日期.Enabled = false;
            dateEdit关闭日期.Enabled = false;
            dateEdit付款日期.Enabled = b;

            textEdit单据号.Enabled = b;
            textEdit备注.Enabled = b;
            textEdit制单人.Enabled = false;
            textEdit审核人.Enabled = false;
            textEdit关闭人.Enabled = false;
            textEdit付款金额.Enabled = b;
            textEdit承兑号.Enabled = b;

            buttonEdit业务员.Enabled = b;
            buttonEdit部门.Enabled = b;
            buttonEdit供应商.Enabled = b;
            lookUpEdit结算方式.Enabled = b;

            lookUpEdit供应商.Enabled = false;
            lookUpEdit业务员.Enabled = false;
            lookUpEdit部门.Enabled = false;

            radioGroup蓝红标识.Enabled = false;
            textEdit付款金额.Enabled = b;

            
            
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
            dateEdit单据日期.EditValue = DBNull.Value;
            dateEdit制单日期.EditValue = DBNull.Value;
            dateEdit审核日期.EditValue = DBNull.Value;
            dateEdit关闭日期.EditValue = DBNull.Value;
            dateEdit付款日期.EditValue = DBNull.Value;

            textEditID.EditValue = "";
            textEdit单据号.EditValue = "";
            textEdit备注.EditValue = "";
            textEdit制单人.EditValue = "";
            textEdit审核人.EditValue = "";
            textEdit关闭人.EditValue = "";
            textEdit付款金额.EditValue = "";
            textEdit承兑号.EditValue = "";

            buttonEdit业务员.EditValue = "";
            buttonEdit部门.EditValue = "";
            buttonEdit供应商.EditValue = "";
            lookUpEdit结算方式.EditValue = "";


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


                if (e.Column == gridCol付款金额 && ReturnDecimal(gridView1.GetRowCellDisplayText(iRow, gridCol来源单据号)) != 0)
                {
                    //if (radioGroup蓝红标识.EditValue.ToString().Trim() == "1")
                    //{
                    //    if (ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol付款金额)) <= 0)
                    //    {
                    //        gridView1.SetRowCellValue(iRow, gridCol付款金额, ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol历史付款金额)));
                    //        throw new Exception("蓝字付款金额不能小于等于0");
                    //    }
                    //}
                    //if (radioGroup蓝红标识.EditValue.ToString().Trim() == "2")
                    //{
                    //    if (ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol付款金额)) >= 0)
                    //    {
                    //        gridView1.SetRowCellValue(iRow, gridCol付款金额, ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol历史付款金额)));
                    //        throw new Exception("红字付款金额不能大于等于0");
                    //    }
                    //}


                    if (ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol历史付款金额)) != ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol付款金额)))
                    {
                        string gs发票号 = gridView1.GetRowCellValue(iRow, gridCol来源单据号).ToString().Trim();
                        decimal d本次金额 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol付款金额));
                        string sType = gridView1.GetRowCellValue(iRow, gridCol来源类型).ToString().Trim();
                        decimal 发票金额 = 0;
                        decimal 累计付款金额 = 0;
                        long 本单子表ID = -1;
                        if (gridView1.GetRowCellValue(iRow, gridColAutoID).ToString().Trim() != "")
                        {
                            本单子表ID = Convert.ToInt64(gridView1.GetRowCellValue(iRow, gridColAutoID));
                        }
                        if (iCodeUsed(gs发票号, sType,本单子表ID, out 累计付款金额, out 发票金额) == -1)
                        {
                            throw new Exception("获得历史信息失败");
                        }
                        if (radioGroup蓝红标识.EditValue.ToString().Trim() == "1")
                        {
                            if (d本次金额 > 发票金额 - 累计付款金额)
                            {
                                gridView1.SetRowCellValue(iRow, gridCol付款金额, ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol历史付款金额)));
                                throw new Exception("付款金额超出发票未付金额");
                            }
                        }
                        if (radioGroup蓝红标识.EditValue.ToString().Trim() == "2")
                        {
                            if (d本次金额 < 发票金额 - 累计付款金额)
                            {
                                gridView1.SetRowCellValue(iRow, gridCol付款金额, ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol历史付款金额)));
                                throw new Exception("付款金额超出发票未付金额");
                            }
                        }
                    }
                    //decimal d金额 = 0;
                    //for (int i = 0; i < gridView1.RowCount; i++)
                    //{
                    //    if (gridView1.GetRowCellValue(i, gridCol付款金额) != null && gridView1.GetRowCellValue(i, gridCol付款金额).ToString().Trim() == "")
                    //        continue;
                    //    decimal d = ReturnDecimal(gridView1.GetRowCellValue(i, gridCol付款金额));
                    //    d金额 = d金额 + d;
                    //}
                    //textEdit付款金额.EditValue = d金额;
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
                if (e.Column == gridCol来源单据号 && e.RowHandle == gridView1.RowCount - 1 && gridView1.GetRowCellDisplayText(e.RowHandle, gridCol来源单据号).ToString().Trim() != "")
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
            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridCol来源单据号) != null && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridCol来源单据号).ToString().Trim() != "" && (sState == "add" || sState == "edit" || sState == "alter"))
            {
                gridView1.OptionsBehavior.Editable = true;
            }
            else
            {

                gridView1.OptionsBehavior.Editable = false;
            }
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

        private void buttonEdit部门_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(3);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit部门.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit供应商_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(10);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit供应商.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit业务员_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit业务员.Text.Trim() != "")
            {
                lookUpEdit业务员.EditValue = buttonEdit业务员.Text.Trim();
                if (lookUpEdit业务员.Text.Trim() != "")
                {
                    DataTable dt = 系统服务.LookUp.PersonDepartment(buttonEdit业务员.Text.Trim());
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        buttonEdit部门.EditValue = dt.Rows[0]["cDepCode"];
                    }
                }
            }
            else
                lookUpEdit业务员.EditValue = null;
        }

        private void buttonEdit部门_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit部门.Text.Trim() != "")
                lookUpEdit部门.EditValue = buttonEdit部门.Text.Trim();
            else
                lookUpEdit部门.EditValue = null;
        }


        private void buttonEdit供应商_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit供应商.Text.Trim() != "")
                lookUpEdit供应商.EditValue = buttonEdit供应商.Text.Trim();
            else
                lookUpEdit供应商.EditValue = null;
        }

        private void buttonEdit供应商_Leave(object sender, EventArgs e)
        {
            if (buttonEdit供应商.Text.Trim() == "")
                return;
            if (lookUpEdit供应商.Text.Trim() == "")
            {
                buttonEdit供应商.Text = "";
                buttonEdit供应商.Focus();
            }
        }

        private void buttonEdit部门_Leave(object sender, EventArgs e)
        {
            if (buttonEdit部门.Text.Trim() == "")
                return;
            if (lookUpEdit部门.Text.Trim() == "")
            {
                buttonEdit部门.Text = "";
                buttonEdit部门.Focus();
            }
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
                sSQL = "select  isnull(dCreatesysPerson,'') as 制单人,isnull(dVerifysysPerson,'') as 审核人,isnull(dClosesysPerson,'') as 关闭人 from " + tablename + " where ID = '" + textEditID.EditValue.ToString() + "'";
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

        /// <summary>
        /// 判断单据是否已经使用
        /// </summary>
        /// <param name="sCode">子表ID</param>
        /// <returns></returns>
        private decimal iCodeUsed(string s发票号, string iType, long 本单子表ID, out decimal 累计下单金额, out decimal 发票金额)
        {
            decimal iReturn = -1;
            累计下单金额 = 0;
            发票金额 = 0;
            try
            {
                if (iType == "1")
                {
                    sSQL = "select a.S1,a.D1 as iMoney,b.iMoneyNow as 累计付款金额 from AP_First a left join  ( select b.iType,b.cTypeCode,sum(iMoneyNow) as iMoneyNow from PO_CloseBill a inner join PO_CloseBillDetails b on a.id = b.id where b.iType = '1' and b.cTypeCode = '" + s发票号 + "'  group by b.iType,b.cTypeCode ) b on cast(a.iID as varchar(50)) = b.cTypeCode where a.iID = " + s发票号;
                }
                if (iType == "2")
                {
                    sSQL = "select a.cPBVCode,a.iMoney,isnull(b.累计付款金额,0) as 累计付款金额 " +
                            "from " +
                            "( " +
                            "select sum(iMoney) as iMoney,a.cPBVCode " +
                            "from dbo.PurBillVouch a inner join dbo.PurBillVouchs b on a.id = b.id " +
                            "group by a.cPBVCode " +
                            ") a left join  " +
                            "(select sum(付款金额) as 累计付款金额,cPBVCode from dbo.PO_CloseBillDetails where autoid <> " + 本单子表ID + " group by cPBVCode) b on a.cPBVCode = b.cPBVCode " +
                            "where  a.cPBVCode = '" + s发票号 + "' ";
                }

                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt != null && dt.Rows.Count > 0)
                {
                    发票金额 = ReturnDecimal(dt.Rows[0]["iMoney"]);
                    累计下单金额 = ReturnDecimal(dt.Rows[0]["累计付款金额"]);
                }
                iReturn = 0;
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

        private void textEdit付款金额_EditValueChanged(object sender, EventArgs e)
        {
            if (sState == null || sState == "sel" || sState == "")
                return;

            if (textEdit付款金额.Text.Trim() == "")
                return;

            decimal d1 = ReturnDecimal(textEdit付款金额.Text);
            if (d1 == 0)
                return;

            if (radioGroup蓝红标识.EditValue.ToString() == "1" && d1<0)
            {
                MessageBox.Show("蓝字单据，付款金额必须是正数");
                return;
            }
            if (radioGroup蓝红标识.EditValue.ToString() == "2" && d1 > 0)
            {
                MessageBox.Show("红字单据，付款金额必须是负数");
                return;
            }
            if (radioGroup蓝红标识.EditValue.ToString() == "1")
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridCol来源单据号) == null || gridView1.GetRowCellValue(i, gridCol来源单据号).ToString().Trim() == "")
                        continue;

                    decimal d2 = ReturnDecimal(gridView1.GetRowCellValue(i, gridCol未付金额));
                    if (d1 >= d2)
                    {
                        gridView1.SetRowCellValue(i, gridCol付款金额, d2);
                        d1 = d1 - d2;
                    }
                    else
                    {
                        gridView1.SetRowCellValue(i, gridCol付款金额, d1);
                        d1 = 0;
                        return;
                    }
                }
            }
            if (radioGroup蓝红标识.EditValue.ToString() == "2")
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridCol来源单据号) == null || gridView1.GetRowCellValue(i, gridCol来源单据号).ToString().Trim() == "")
                        continue;

                    decimal d2 = ReturnDecimal(gridView1.GetRowCellValue(i, gridCol未付金额));
                    if (d1 <= d2)
                    {
                        gridView1.SetRowCellValue(i, gridCol付款金额, d2);
                        d1 = d1 - d2;
                    }
                    else
                    {
                        gridView1.SetRowCellValue(i, gridCol付款金额, d1);
                        d1 = 0;
                        return;
                    }
                }
            }
        
        }

        private void textEdit承兑号_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
