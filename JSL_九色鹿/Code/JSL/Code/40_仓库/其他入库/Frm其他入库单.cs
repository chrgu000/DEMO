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

namespace 仓库
{
    public partial class Frm其他入库单 : 系统服务.FrmBaseInfo
    {
        string tablename = "RdRecord05";
        string tableid = "cRDCode";
        string tablenames = "RdRecords05";
        string cRsCode = "";

        long iID = -1;
        public string 单据号1 = "";
        public string 单据号2 = "";
        public string 单据日期1 = "";
        public string 单据日期2 = "";
        public string 制单日期1 = "";
        public string 制单日期2 = "";
        public string 业务员 = "";
        public string 仓库 = "";
        public string 审核日期1 = "";
        public string 审核日期2 = "";
        public string 制单人1 = "";
        public string 制单人2 = "";
        public string 审核人1 = "";
        public string 审核人2 = "";
        public string 物料1 = "";
        public string 物料2 = "";

        string isChange = "";

        public Frm其他入库单(long siID, string title)
        {
            iID = siID;
            InitializeComponent();
            this.Text = title;
        }

        public Frm其他入库单(long siID)
        {
            iID = siID;
            InitializeComponent();
            
        }

        public Frm其他入库单()
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
            sState = "sel";
            GetGrid();

        }
        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
            Frm其他入库单_Add frm = new Frm其他入库单_Add(单据号1, 单据号2, 单据日期1, 单据日期2, 制单日期1, 制单日期2, 业务员,
               仓库, 审核日期1, 审核日期2, 制单人1, 制单人2, 审核人1, 审核人2, 物料1, 物料2);
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
                仓库 = frm.仓库;
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
            string sSQL = "select * from " + tablename + " a left join " + tablenames + "  b on a.ID=b.ID left join RdStyle r on a.cRSCode=r.cRSCode where 收发标志='0' and a.cRSCode='" + cRsCode + "' ";
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
            if (仓库 != "")
            {
                sSQL = sSQL + " and cWhCode='" + 仓库 + "'";
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
                sSQL = "select min(ID) as ID from " + tablename + " a left join RdStyle r on a.cRSCode=r.cRSCode where 收发标志='0' and a.cRSCode='" + cRsCode + "' ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]);
                    iID = Convert.ToInt64(dt.Rows[0]["ID"]);;
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
                if (iID != -1)
                {
                    sSQL = "select ID from " + tablename + " a left join RdStyle r on a.cRSCode=r.cRSCode where ID<" + textEditID.Text + " and 收发标志='0' and a.cRSCode='" + cRsCode + "'  order by ID desc";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt.Rows.Count > 0)
                    {
                        textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]);;
                        iID = Convert.ToInt64(dt.Rows[0]["ID"]);;
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
                if (iID != -1)
                {
                    sSQL = "select ID from " + tablename + " a left join RdStyle r on a.cRSCode=r.cRSCode where ID>" + textEditID.Text + " and 收发标志='0' and a.cRSCode='" + cRsCode + "'  order by ID ";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt.Rows.Count > 0)
                    {
                        textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]);;
                        iID = Convert.ToInt64(dt.Rows[0]["ID"]);;
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
                sSQL = "select isnull(max(ID),-1) as ID from " + tablename + " a left join RdStyle r on a.cRSCode=r.cRSCode  where 收发标志='0' and a.cRSCode='" + cRsCode + "'  ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]);;
                    iID = Convert.ToInt64(dt.Rows[0]["ID"]);;
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
            GetShow(false);
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
                        if (textEditDel.EditValue != null && textEditDel.EditValue.ToString().Trim() != "")
                        {
                            textEditDel.EditValue = textEditDel.EditValue.ToString().Trim() + "," + gridView1.GetRowCellDisplayText(i, gridColAutoID).ToString().Trim();
                            textEditDelRdAutoID.EditValue = textEditDelRdAutoID.EditValue.ToString().Trim() + "," + gridView1.GetRowCellDisplayText(i, gridColRdAutoID).ToString().Trim();
                        }
                        else
                        {
                            textEditDel.EditValue = gridView1.GetRowCellDisplayText(i, gridColAutoID).ToString().Trim();
                            textEditDelRdAutoID.EditValue = gridView1.GetRowCellDisplayText(i, gridColRdAutoID).ToString().Trim();
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
            if (cRsCode == "0505")
            {
                throw new Exception("调拨入库单无法新增，请至调拨出库单新增，并且调拨出库单审核后会自动生成调拨入库单");
            }
            sState = "add";
            GetNull();
            GetShow(true);
            dateEdit单据日期.EditValue = 系统服务.ClsBaseDataInfo.sLogDate;

            int iFocRow = gridView1.FocusedRowHandle;

            sSQL = "select a.*, 'edit' as iSave,a.iQuantity as 历史数量 from " + tablenames + " a  where 1=-1";
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
            lookUpEdit出入库类别.EditValue = cRsCode;
            radioGroup蓝红标识.EditValue = "1";
        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {
            if (textEdit关闭人.EditValue.ToString().Trim() != "")
            {
                throw new Exception("已关闭，不能修改");
            }
            else if(textEdit审核人.EditValue.ToString().Trim() != "")
            {
                throw new Exception("已审核，不能修改");
            }
            
            sState = "edit";
            GetShow(true);
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
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

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellDisplayText(i, gridColAutoID).Trim() != "")
                    {
                        if (cRsCode == "0504")
                        {
                            string AutoID = gridView1.GetRowCellDisplayText(i, gridColAutoID).Trim();
                            sSQL = "select * from RdRecords05 where AutoID='" + AutoID + "'";
                            DataTable dtp = clsSQLCommond.ExecQuery(sSQL);
                            if (dtp.Rows.Count > 0)
                            {
                                string sBoxNo = dtp.Rows[0]["sBoxNo"].ToString().Trim();
                                sSQL = "select sum(sBoxQty) from RdRecords05 where sBoxNo='" + sBoxNo + "'";
                                DataTable dtp2 = clsSQLCommond.ExecQuery(sSQL);
                                if (ReturnInt(dtp2.Rows[0][0]) > 0)//有成团入库单
                                {
                                    //反写装箱单
                                    sSQL = "update SO_SOPackingSublist set sInBoxQty=0,iInQuantity=0,sOutBoxQty=0,iOutQuantity=0 where sBoxNo='" + sBoxNo + "'";
                                    aList.Add(sSQL);
                                }
                                else
                                {
                                    //反写装箱单
                                    sSQL = "update SO_SOPackingSublist set sInBoxQty=1,iInQuantity=" + dtp.Rows[0]["iQuantity"] + ",sOutBoxQty=1,iOutQuantity=" + dtp.Rows[0]["iQuantity"] + " where sBoxNo='" + sBoxNo + "'";
                                    aList.Add(sSQL);
                                }
                            }
                        }
                        clsPublic.ReturnNow(0, gridView1.GetRowCellValue(i, gridCol物料编码).ToString().Trim(), lookUpEdit仓库.EditValue.ToString().Trim(), gridView1.GetRowCellValue(i, gridColcPosCode).ToString().Trim()
                        , "", "", gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim()
                        , gridView1.GetRowCellValue(i, gridColM1).ToString().Trim(),"" ,"", "", ""
                        , "", "", "", "", ""
                        , ReturnDecimal(gridView1.GetRowCellValue(i, gridCol历史数量).ToString().Trim(), 6), 0, 0, 0, 0, 0, aList);
                    }
                }

                sSQL = "delete from " + tablename + " where ID='" + textEditID.EditValue.ToString().Trim() + "'";
                aList.Add(sSQL);
                sSQL = "delete from " + tablenames + " where ID='" + textEditID.EditValue.ToString().Trim() + "'";
                aList.Add(sSQL);

                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("删除成功！\n合计执行语句:" + iCou + "条");
                    btnPrev();
                    //if (textEditID.EditValue.ToString().Trim()== "")
                    //{
                    //    btnFirst();
                    //}
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

            sSQL = "select * from " + tablename + " where 1=-1";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            sSQL = "select * from " + tablenames + " where 1=-1";
            DataTable dts = clsSQLCommond.ExecQuery(sSQL);
            string sErr = "";

            if (radioGroup蓝红标识.EditValue == null || radioGroup蓝红标识.EditValue.ToString().Trim() == "")
            {
                throw new Exception("蓝红标识不能为空");
            }
            if (buttonEdit部门.EditValue == null || buttonEdit部门.EditValue.ToString().Trim() == "")
            {
                throw new Exception("部门不能为空");
            }
            if (dateEdit单据日期.EditValue == null || dateEdit单据日期.EditValue.ToString().Trim() == "")
            {
                throw new Exception("单据日期不能为空");
            }
            if (lookUpEdit仓库.EditValue == null || lookUpEdit仓库.EditValue.ToString().Trim() == "")
            {
                throw new Exception("仓库不能为空");
            }
            if (lookUpEdit出入库类别.EditValue == null || lookUpEdit出入库类别.EditValue.ToString().Trim() == "")
            {
                throw new Exception("出入库类别不能为空");
            }

            aList = new System.Collections.ArrayList();
            DataRow drh = dt.NewRow();
            if (sState == "add")
            {
                iID = clsPublic.GetMaxID("RD");
                drh["ID"] = iID;
                drh["cRDCode"] = clsPublic.GetMaxCode("cRdCode");
                textEdit单据号.EditValue = drh["cRDCode"].ToString();
            }
            else
            {
                drh["ID"] = textEditID.Text;
                iID = Convert.ToInt64(textEditID.Text);
                drh["cRDCode"] = textEdit单据号.EditValue.ToString().Trim();
            }
            drh["dDate"] = dateEdit单据日期.EditValue.ToString().Trim();

            drh["cPersonCode"] = buttonEdit业务员.EditValue.ToString().Trim();
            if (lookUpEdit操作人.EditValue != null)
            {
                drh["cOperator"] = lookUpEdit操作人.EditValue.ToString().Trim();
            }
            drh["cWhCode"] = lookUpEdit仓库.EditValue.ToString().Trim();
            drh["cDepCode"] = buttonEdit部门.EditValue.ToString().Trim();
            drh["cRSCode"] = lookUpEdit出入库类别.EditValue.ToString().Trim();
            
            drh["cCusCode"] = buttonEdit客户.EditValue.ToString().Trim();

            drh["Flag"] = radioGroup蓝红标识.EditValue.ToString().Trim();

            drh["cMemo"] = textEdit备注.EditValue.ToString().Trim();


            if (sState == "add")
            {
                drh["dCreatesysTime"] = GetSystemTime();
                drh["dCreatesysPerson"] = 系统服务.ClsBaseDataInfo.sUid;
            }
            else
            {
                drh["dCreatesysTime"] = dateEdit制单日期.EditValue.ToString().Trim();
                drh["dCreatesysPerson"] = textEdit制单人.EditValue.ToString().Trim();
            }
            if (sState == "alter")
            {
                drh["dVerifysysPerson"] = textEdit审核人.Text.Trim();
                drh["dVerifysysTime"] = dateEdit审核日期.Text.Trim();
                drh["dChangeVerifyTime"] = GetSystemTime();
                drh["dChangeVerifyPerson"] = 系统服务.ClsBaseDataInfo.sUid;
            }
            drh["UpdateDate"] = DateTime.Now.ToString();
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
                clsPublic.GetChange(tablename, tablenames, textEditID.EditValue.ToString().Trim(), clsGetSQL, aList);
            }
            #endregion

            #region 删行
            if (textEditDel.EditValue != null && textEditDel.EditValue.ToString().Trim() != "")
            {
                string[] del = textEditDel.EditValue.ToString().Split(',');
                for (int i = 0; i < del.Length; i++)
                {
                    string AutoID = del[i];
                    sSQL = "select * from RdRecords05 where AutoID='" + AutoID + "'";
                    DataTable dtp = clsSQLCommond.ExecQuery(sSQL);
                    if (dtp.Rows.Count > 0)
                    {
                        string sBoxNo = dtp.Rows[0]["sBoxNo"].ToString().Trim();
                        sSQL = "select sum(sBoxQty) from RdRecords05 where sBoxNo='" + sBoxNo + "'";
                        DataTable dtp2 = clsSQLCommond.ExecQuery(sSQL);
                        if (ReturnInt(dtp2.Rows[0][0]) > 0)//有成团入库单
                        {
                            //反写装箱单
                            sSQL = "update SO_SOPackingSublist set sInBoxQty=0,iInQuantity=0,sOutBoxQty=0,iOutQuantity=0 where sBoxNo='" + sBoxNo + "'";
                            aList.Add(sSQL);
                        }
                        else
                        {
                            //反写装箱单
                            sSQL = "update SO_SOPackingSublist set sInBoxQty=1,iInQuantity=" + dtp.Rows[0]["iQuantity"] + ",sOutBoxQty=1,iOutQuantity=" + dtp.Rows[0]["iQuantity"] + " where sBoxNo='" + sBoxNo + "'";
                            aList.Add(sSQL);
                        }
                    }
                }
                clsPublic.ReturnNow(textEditDel.EditValue.ToString().Trim(), aList);
                clsPublic.GetChangeDelRow(tablenames, textEditDel.EditValue.ToString().Trim(), aList);

                if (cRsCode == "0505")
                {
                    string[] delRd = textEditDel.EditValue.ToString().Split(',');
                    for (int i = 0; i < delRd.Length; i++)
                    {
                        string RdAutoID = delRd[i];

                        //反写单据
                        sSQL = @"
if object_id('Tempdb.dbo.#c') is not null drop table #c
select RdAutoID,iQuantity into #c from RdRecords01 where RdAutoID=111111 
insert into #c select RdAutoID,iQuantity from RdRecords02 where RdAutoID=111111 
insert into #c select RdAutoID,iQuantity from RdRecords03 where RdAutoID=111111 
insert into #c select RdAutoID,iQuantity from RdRecords05 where RdAutoID=111111 

insert into #c select RdAutoID,-iQuantity from RdRecords11 where RdAutoID=111111 and iQuantity<0 
insert into #c select RdAutoID,-iQuantity from RdRecords12 where RdAutoID=111111 and iQuantity<0 
insert into #c select RdAutoID,-iQuantity from RdRecords13 where RdAutoID=111111 and iQuantity<0 
insert into #c select RdAutoID,-iQuantity from RdRecords15 where RdAutoID=111111 and iQuantity<0 

update RdRecords11 set iOutQuantity=a.iQuantity from (select RdAutoID,sum(iQuantity) as iQuantity from #c group by RdAutoID) a where RdRecords11.AutoID=a.RdAutoID
update RdRecords12 set iOutQuantity=a.iQuantity from (select RdAutoID,sum(iQuantity) as iQuantity from #c group by RdAutoID) a where RdRecords12.AutoID=a.RdAutoID
update RdRecords13 set iOutQuantity=a.iQuantity from (select RdAutoID,sum(iQuantity) as iQuantity from #c group by RdAutoID) a where RdRecords13.AutoID=a.RdAutoID
update RdRecords15 set iOutQuantity=a.iQuantity from (select RdAutoID,sum(iQuantity) as iQuantity from #c group by RdAutoID) a where RdRecords15.AutoID=a.RdAutoID
";
                        sSQL = sSQL.Replace("111111", RdAutoID);
                        aList.Add(sSQL);
                    }
                }
            }
            #endregion

            #region 子表
            
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "update" || gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "add")
                {
                    #region 判断
                    if (gridView1.GetRowCellDisplayText(i, gridCol物料编码).ToString().Trim() == "")
                    {
                        continue;
                    }

                    if (gridView1.GetRowCellDisplayText(i, gridCol物料名称).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + "无此物料\n";
                        continue;
                    }
                    if (gridView1.GetRowCellDisplayText(i, gridColcPosCode).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + "请输入货位\n";
                        continue;
                    }
                    if (lookUpEdit出入库类别.EditValue.ToString()=="02" && gridView1.GetRowCellValue(i, gridCol数量).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + gridCol数量.Caption + "不能为空\n";
                        continue;
                    }
                    else
                    {
                        if (radioGroup蓝红标识.EditValue.ToString().Trim() == "1")
                        {
                            if (ReturnDecimal(gridView1.GetRowCellValue(i, gridCol数量).ToString().Trim()) < 0)
                            {
                                sErr = sErr + "行" + (i + 1) + gridCol数量.Caption + "需为正\n";
                                continue;
                            }
                        }
                        else if (radioGroup蓝红标识.EditValue.ToString().Trim() == "2")
                        {
                            if (ReturnDecimal(gridView1.GetRowCellValue(i, gridCol数量).ToString().Trim()) >= 0)
                            {
                                sErr = sErr + "行" + (i + 1) + gridCol数量.Caption + "需为负\n";
                                continue;
                            }
                        }
                    }
                    if (lookUpEdit出入库类别.EditValue.ToString() == "04" && gridView1.GetRowCellValue(i, gridCol盒数).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + gridCol盒数.Caption + "不能为空\n";
                        continue;
                    }
                    
                    #endregion

                    #region 生成table
                    DataRow dr = dts.NewRow();
                    if (gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim() == "")
                    {
                        long sID = clsPublic.GetMaxID("RDS");
                        dr["AutoID"] = sID;
                    }
                    else
                    {
                        dr["AutoID"] = gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim();
                    }
                    dr["ID"] = iID;
                    dr["cRDCode"] = textEdit单据号.EditValue.ToString().Trim();
                    dr["iRowNo"] = gridView1.GetRowCellValue(i, gridCol序号).ToString().Trim();
                    if (gridView1.GetRowCellValue(i, gridColRdAutoID) != null && gridView1.GetRowCellValue(i, gridColRdAutoID).ToString().Trim()!="")
                    {
                        dr["RdAutoID"] = gridView1.GetRowCellValue(i, gridColRdAutoID).ToString().Trim();
                    }
                    dr["cInvCode"] = gridView1.GetRowCellValue(i, gridCol物料编码).ToString().Trim();
                    dr["cPosCode"] = gridView1.GetRowCellValue(i, gridColcPosCode).ToString().Trim();
                    if (gridView1.GetRowCellValue(i, gridCol数量).ToString().Trim() != "")
                    {
                        dr["iQuantity"] = gridView1.GetRowCellValue(i, gridCol数量).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol盒数).ToString().Trim() != "")
                    {
                        dr["sBoxQty"] = gridView1.GetRowCellValue(i, gridCol盒数).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol件数) != null && gridView1.GetRowCellValue(i, gridCol件数).ToString().Trim() != "")
                    {
                        dr["iNum"] = gridView1.GetRowCellValue(i, gridCol件数).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol含税单价) != null && gridView1.GetRowCellValue(i, gridCol含税单价).ToString().Trim() != "")
                    {
                        dr["iUnitPrice"] = gridView1.GetRowCellValue(i, gridCol含税单价).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol含税金额) != null && gridView1.GetRowCellValue(i, gridCol含税金额).ToString().Trim() != "")
                    {
                        dr["iMoney"] = gridView1.GetRowCellValue(i, gridCol含税金额).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol无税单价) != null && gridView1.GetRowCellValue(i, gridCol无税单价).ToString().Trim() != "")
                    {
                        dr["iNatUnitPrice"] = gridView1.GetRowCellValue(i, gridCol无税单价).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol无税金额) != null && gridView1.GetRowCellValue(i, gridCol无税金额).ToString().Trim() != "")
                    {
                        dr["iNatMoney"] = gridView1.GetRowCellValue(i, gridCol无税金额).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol税率) != null && gridView1.GetRowCellValue(i, gridCol税率).ToString().Trim() != "")
                    {
                        dr["iTaxRate"] = gridView1.GetRowCellValue(i, gridCol税率).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol换算率) != null && gridView1.GetRowCellValue(i, gridCol换算率).ToString().Trim() != "")
                    {
                        dr["iChangRate"] = gridView1.GetRowCellValue(i, gridCol换算率).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol税额) != null && gridView1.GetRowCellValue(i, gridCol税额).ToString().Trim() != "")
                    {
                        dr["iNatTax"] = gridView1.GetRowCellValue(i, gridCol税额).ToString().Trim();
                    }
                    dr["cMemo"] = gridView1.GetRowCellValue(i, gridCol备注).ToString().Trim();

                    dr["M1"] = gridView1.GetRowCellValue(i, gridColM1).ToString().Trim();
                    dr["M2"] = gridView1.GetRowCellValue(i, gridCol缸号).ToString().Trim();
                    dr["UpdateDate"] = DateTime.Now.ToString();
                    dts.Rows.Add(dr);
                    //sID = sID + 1;
                    #endregion

                    if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "update")
                    {
                        sSQL = clsGetSQL.GetUpdateSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablenames, dts, dts.Rows.Count - 1);
                    }
                    else
                    {
                        sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablenames, dts, dts.Rows.Count - 1);
                    }

                    aList.Add(sSQL);

                    clsPublic.ReturnNow(0, gridView1.GetRowCellValue(i, gridCol物料编码).ToString().Trim(), lookUpEdit仓库.EditValue.ToString().Trim(), gridView1.GetRowCellValue(i, gridColcPosCode).ToString().Trim()
                        , "", "", gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim()
                        , gridView1.GetRowCellValue(i, gridColM1).ToString().Trim(), "", "", "", ""
                        , "", "", "", "", ""
                        , ReturnDecimal(gridView1.GetRowCellValue(i, gridCol历史数量).ToString().Trim(), 6), 0, 0, ReturnDecimal(gridView1.GetRowCellValue(i, gridCol数量).ToString().Trim(), 6), 0, 0, aList);
                }
                else
                {
                    if (gridView1.GetRowCellValue(i, gridCol数量).ToString().Trim() != "")
                    {
                        if (radioGroup蓝红标识.EditValue.ToString().Trim() == "1")
                        {
                            if (ReturnDecimal(gridView1.GetRowCellValue(i, gridCol数量)) < 0)
                            {
                                sErr = sErr + "行" + (i + 1) + gridCol数量.Caption + "需为正\n";
                                continue;
                            }
                        }
                        else if (radioGroup蓝红标识.EditValue.ToString().Trim() == "2")
                        {
                            if (ReturnDecimal(gridView1.GetRowCellValue(i, gridCol数量)) >= 0)
                            {
                                sErr = sErr + "行" + (i + 1) + gridCol数量.Caption + "需为负\n";
                                continue;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string RdAutoID = gridView1.GetRowCellValue(i, gridColRdAutoID).ToString().Trim();
                if (RdAutoID != "")
                {
                    sSQL = @"
if object_id('Tempdb.dbo.#c') is not null drop table #c
select RdAutoID,iQuantity into #c from RdRecords01 where RdAutoID=111111 
insert into #c select RdAutoID,iQuantity from RdRecords02 where RdAutoID=111111 
insert into #c select RdAutoID,iQuantity from RdRecords03 where RdAutoID=111111 
insert into #c select RdAutoID,iQuantity from RdRecords05 where RdAutoID=111111 

insert into #c select RdAutoID,-iQuantity from RdRecords11 where RdAutoID=111111 and iQuantity<0 
insert into #c select RdAutoID,-iQuantity from RdRecords12 where RdAutoID=111111 and iQuantity<0 
insert into #c select RdAutoID,-iQuantity from RdRecords13 where RdAutoID=111111 and iQuantity<0 
insert into #c select RdAutoID,-iQuantity from RdRecords15 where RdAutoID=111111 and iQuantity<0 

update RdRecords11 set iOutQuantity=a.iQuantity from (select RdAutoID,sum(iQuantity) as iQuantity from #c group by RdAutoID) a where RdRecords11.AutoID=a.RdAutoID
update RdRecords12 set iOutQuantity=a.iQuantity from (select RdAutoID,sum(iQuantity) as iQuantity from #c group by RdAutoID) a where RdRecords12.AutoID=a.RdAutoID
update RdRecords13 set iOutQuantity=a.iQuantity from (select RdAutoID,sum(iQuantity) as iQuantity from #c group by RdAutoID) a where RdRecords13.AutoID=a.RdAutoID
update RdRecords15 set iOutQuantity=a.iQuantity from (select RdAutoID,sum(iQuantity) as iQuantity from #c group by RdAutoID) a where RdRecords15.AutoID=a.RdAutoID
";
                    sSQL = sSQL.Replace("111111", RdAutoID);
                    aList.Add(sSQL);
                }
            }
            #endregion
            if (sErr != "")
            {
                clsPublic.SetMaxID();
                throw new Exception(sErr);
            }
            if (dt == null || dt.Rows.Count <= 0)
            {
                throw new Exception("表头不能为空");
            }

            bool b表体空 = true;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridCol物料编码).ToString().Trim() == "")
                {
                    continue;
                }
                b表体空 = false;
                break;
            }

            if (b表体空)
            {
                throw new Exception("表体不能为空");
            }

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("保存成功！\n合计执行语句:" + iCou + "条");
                textEditID.EditValue = iID;
                sState = "save";
                GetSelBind();

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

            sSQL = "update " + tablename + " set dVerifysysTime='" + GetSystemTime() + "',dVerifysysPerson='" + 系统服务.ClsBaseDataInfo.sUid + "' where ID=" + textEditID.Text + "";
            aList.Add(sSQL);

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("审核成功！\n合计执行语句:" + iCou + "条");
                GetGrid();
            }
        }
        /// <summary>
        /// 弃审
        /// </summary>
        private void btnUnAudit()
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
            if (cRsCode == "0505")
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellDisplayText(i, gridColAutoID).ToString().Trim() != "")
                    {
                        string sID = gridView1.GetRowCellDisplayText(i, gridColAutoID).ToString().Trim();
                        sSQL = "select * from RdRecords15 where RdAutoID =" + sID;
                        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                        if (dt.Rows.Count > 0)
                        {
                            throw new Exception("单据已引用");
                            break;
                        }
                    }
                }
            }
            aList = new System.Collections.ArrayList();

            sSQL = "update " + tablename + " set dVerifysysTime=null,dVerifysysPerson=null where ID=" + textEditID.Text + "";
            aList.Add(sSQL);

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("弃审成功！\n合计执行语句:" + iCou + "条");
                GetGrid();
            }
        }
        /// <summary>
        /// 打开
        /// </summary>
        private void btnOpen()
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
            if (iRe == 2)
            {
                throw new Exception("单据未关闭");
            }
            //if (iRe == 3)
            //{
            //    throw new Exception("单据已关闭");
            //}
            aList = new System.Collections.ArrayList();

            sSQL = "update " + tablename + " set dClosesysTime=null,dClosesysPerson=null where ID=" + textEditID.Text + "";
            aList.Add(sSQL);
            sSQL = "update " + tablenames + " set cClosesysTime=null,cClosesysPerson=null where ID=" + textEditID.Text + " ";
            aList.Add(sSQL);

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("打开成功！\n合计执行语句:" + iCou + "条");
                GetGrid();
            }
        }
        /// <summary>
        /// 关闭
        /// </summary>
        private void btnClose()
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

        aList = new System.Collections.ArrayList();

            sSQL = "update " + tablename + " set dClosesysTime='" + GetSystemTime() + "',dClosesysPerson='" + 系统服务.ClsBaseDataInfo.sUid + "' where ID=" + textEditID.Text + "";
            aList.Add(sSQL);
            sSQL = "update " + tablenames + " set cClosesysTime='" + GetSystemTime() + "',cClosesysPerson='" + 系统服务.ClsBaseDataInfo.sUid + "' where ID=" + textEditID.Text + " and  (cClosesysPerson='' or cClosesysPerson is null)";
            aList.Add(sSQL);
            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("关闭成功！\n合计执行语句:" + iCou + "条");
                GetGrid();
            }
        }
        /// <summary>
        /// 变更
        /// </summary>
        private void btnAlter()
        {
            if (textEdit审核人.EditValue.ToString().Trim() == "")
            {
                throw new Exception("未审核，不能变更");
            }
            if (textEdit关闭人.EditValue.ToString().Trim() != "")
            {
                throw new Exception("已关闭，不能变更");
            }
            sState = "alter";
            GetShow(true);
        }

        #endregion

        private void Frm其他入库单_Load(object sender, EventArgs e)
        {
            try
            {
                GetTitle();
                GetLayOut(layoutControl1, gridControl1);
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

        private void GetTitle()
        {
            string title = this.Text;
            if (title.IndexOf("辅料") > -1)
            {
                cRsCode = "0503";
                gridCol盒数.Visible = false;
                gridColM1.Visible = false;
                gridCol缸号.Visible = false;
                gridM1.Visible = false;
                gridCol盒号.Visible = false;
                layoutControlItem21.Text = "供应商";
            }
            else if (title.IndexOf("期初原料") > -1)
            {
                cRsCode = "0501";
                gridCol盒数.Visible = false;
                gridCol盒号.Visible = false;
            }
            else if (title.IndexOf("期初成品") > -1)
            {
                cRsCode = "0502";
                gridCol盒号.Visible = false;
            }
            else if (title.IndexOf("盘点") > -1)
            {
                cRsCode = "0504";
            }
            else if (title.IndexOf("调拨") > -1)
            {
                cRsCode = "0505";
                gridCol盒数.Visible = false;
                gridCol物料编码.OptionsColumn.AllowEdit = false;
            }
        }
        private void GetGrid()
        {
            if (iID != -1)
            {
                sSQL = "select * from " + tablename + " a left join RdStyle r on a.cRSCode=r.cRSCode  where 收发标志='0' and a.cRSCode='" + cRsCode + "'   and ID=" + iID;
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]);;
                    textEdit单据号.EditValue = dt.Rows[0]["cRDCode"].ToString();

                    dateEdit单据日期.EditValue = dt.Rows[0]["dDate"].ToString();
                    dateEdit制单日期.EditValue = dt.Rows[0]["dCreatesysTime"].ToString();
                    dateEdit审核日期.EditValue = dt.Rows[0]["dVerifysysTime"].ToString();
                    dateEdit关闭日期.EditValue = dt.Rows[0]["dClosesysTime"].ToString();

                    textEdit备注.EditValue = dt.Rows[0]["cMemo"].ToString();
                    textEdit制单人.EditValue = dt.Rows[0]["dCreatesysPerson"].ToString();
                    textEdit审核人.EditValue = dt.Rows[0]["dVerifysysPerson"].ToString();
                    textEdit关闭人.EditValue = dt.Rows[0]["dClosesysPerson"].ToString();

                    buttonEdit业务员.EditValue = dt.Rows[0]["cPersonCode"].ToString();
                    lookUpEdit仓库.EditValue = dt.Rows[0]["cWhCode"].ToString();
                    buttonEdit部门.EditValue = dt.Rows[0]["cDepCode"].ToString();

                    radioGroup蓝红标识.EditValue = dt.Rows[0]["Flag"].ToString();

                    
                    buttonEdit部门.Enabled = false;

                    buttonEdit客户.EditValue = dt.Rows[0]["cCusCode"].ToString();
                    lookUpEdit出入库类别.EditValue = dt.Rows[0]["cRSCode"];


                    sSQL = "select a.*,i.cInvName, 'edit' as iSave,a.iQuantity as 历史数量  from " + tablenames + " a left join  Inventory i on a.cInvCode=i.cInvCode "
                    + " left join ComputationUnitGroup g on i.cGroupCode=g.cGroupCode where ID=" + iID;

                    dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
                    gridControl1.DataSource = dtBingGrid;

                    
                    gridView1.AddNewRow();

                    gridView1.FocusedRowHandle = iFocRow;
                    GetShow(false);
                }
                else
                {
                    GetNull();
                    GetShow(false);
                }
            }
            else
            {
                GetNull();
                GetShow(false);
            }
        }



        /// <summary>
        /// 下拉列表框
        /// </summary>
        private void SetLookUpEdit()
        {
            系统服务.LookUp.Warehouse(lookUpEdit仓库);
            系统服务.LookUp.Position(ItemLookUpEdit货位);
            系统服务.LookUp.RdStyle(lookUpEdit出入库类别,0,"'02','04','06'");
            系统服务.LookUp.Department(lookUpEdit部门);
            系统服务.LookUp.Person(lookUpEdit业务员);
            系统服务.LookUp.Person(lookUpEdit操作人);
            系统服务.LookUp.Customer(lookUpEdit客户);
            

            系统服务.LookUp.Inventory(ItemLookUpEdit物料名称);
            ItemLookUpEdit物料名称.Properties.DisplayMember = "cInvName";
            系统服务.LookUp.Inventory(ItemLookUpEdit物料规格);
            ItemLookUpEdit物料规格.Properties.DisplayMember = "cInvStd";
            系统服务.LookUp.Inventory(ItemLookUpEdit物料代码);
            ItemLookUpEdit物料规格.Properties.DisplayMember = "cInvAddCode";
        }

        private void GetShow(bool b)
        {
            dateEdit单据日期.Enabled = b;
            dateEdit制单日期.Enabled = false;
            dateEdit审核日期.Enabled = false;
            dateEdit关闭日期.Enabled = false;

            textEdit单据号.Enabled = false;
            textEdit备注.Enabled = b;
            textEdit制单人.Enabled = false;
            textEdit审核人.Enabled = false;
            textEdit关闭人.Enabled = false;

            buttonEdit业务员.Enabled = b;
            lookUpEdit仓库.Enabled = b;
            buttonEdit部门.Enabled = b;
            lookUpEdit出入库类别.Enabled = false;

            lookUpEdit业务员.Enabled = false;
            lookUpEdit部门.Enabled = false;

            buttonEdit操作人.Enabled = b;

            buttonEdit客户.Enabled = b;
            lookUpEdit客户.Enabled = false;

            radioGroup蓝红标识.Enabled = false;
            
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

            textEditID.EditValue = "";
            textEdit单据号.EditValue = "";
            textEdit备注.EditValue = "";
            textEdit制单人.EditValue = "";
            textEdit审核人.EditValue = "";
            textEdit关闭人.EditValue = "";

            buttonEdit业务员.EditValue = "";
            buttonEdit操作人.EditValue = "";
            lookUpEdit仓库.EditValue = "";
            buttonEdit部门.EditValue = "";

            buttonEdit客户.EditValue = "";
            lookUpEdit出入库类别.EditValue = "";
            gridControl1.DataSource = null;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView1.FocusedRowHandle >= 0)
                    iRow = gridView1.FocusedRowHandle;
                string invocde = gridView1.GetRowCellValue(iRow, gridCol物料编码).ToString().Trim();

                if (gridView1.GetRowCellValue(iRow, gridCol序号).ToString().Trim() == "")
                {
                    gridView1.SetRowCellValue(iRow, gridCol序号, iRow + 1);
                }

                if (e.Column == gridCol物料编码 || e.Column == gridCol物料名称)
                {
                    
                    if (e.Column == gridCol物料编码)
                    {
                        sSQL = "select * from Inventory where cInvCode='" + invocde + "'";
                        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                        if (dt.Rows.Count > 0)
                        {
                            gridView1.SetRowCellValue(iRow, gridCol税率, 17);
                        }
                    }
                    
                    sSQL = "select 换算率 from Inventory where cInvCode='" + invocde + "'";
                    decimal d换算率 = ReturnDecimal(clsSQLCommond.ExecGetScalar(sSQL));
                    if (d换算率 > 0)
                    {
                        gridView1.SetRowCellValue(iRow, gridCol换算率, d换算率);
                    }
                    else
                    {
                        gridView1.SetRowCellValue(iRow, gridCol换算率, null);
                    }
                }

                if (e.Column == gridCol盒数)
                {
                    decimal d盒数 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol盒数));
                    sSQL = "select * from Inventory where cInvCode='" + invocde + "'";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt.Rows.Count > 0)
                    {
                        decimal 数量 = ReturnDecimal(dt.Rows[0]["D2"],6);
                        if (数量 > 0)
                        {
                            gridView1.SetRowCellValue(iRow, gridCol数量, d盒数 * 数量);
                        }
                        else
                        {
                            gridView1.SetRowCellValue(iRow, gridCol数量, null);
                        }
                    }
                }

                string AutoID = gridView1.GetRowCellValue(iRow, gridColAutoID).ToString();

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

                if (e.Column == gridCol数量)
                {
                    decimal d数量 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol数量));
                    decimal d上游 = 0;
                    decimal d引用 = 0;
                    long lAutoid = -1;
                    if (gridView1.GetRowCellValue(iRow, gridColAutoID).ToString().Trim() != "")
                    {
                        lAutoid = Convert.ToInt64(gridView1.GetRowCellValue(iRow, gridColAutoID));
                    }
                    iCodeUsed(Convert.ToInt64(gridView1.GetRowCellValue(iRow, gridColRdAutoID).ToString()), lAutoid, out d上游, out d引用);
                    if (d数量 > d上游 || d数量 < d引用)
                    {
                        MessageBox.Show((iRow + 1) + "行上游单据数量为" + d上游 + ",已引用数量为" + d引用 + ",数量不可超出此范围");
                        gridView1.SetRowCellValue(iRow, gridCol数量, d上游);
                    }
                }

                if (e.Column == gridCol数量 || e.Column == gridCol件数 || e.Column == gridCol税率 || e.Column == gridCol税额 || e.Column == gridCol含税单价 || e.Column == gridCol含税金额
                    || e.Column == gridCol无税单价 || e.Column == gridCol无税金额)
                {
                    decimal 数量 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol数量));
                    decimal 件数 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol件数));
                    decimal 税率 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol税率)) / 100;
                    decimal 税额 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol税额));
                    decimal 换算率 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol换算率));
                    decimal 含税单价 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol含税单价));
                    decimal 含税金额 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol含税金额));
                    decimal 无税单价 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol无税单价));
                    decimal 无税金额 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol无税金额));

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
                    if (e.Column == gridCol含税单价 || e.Column == gridCol数量 || e.Column == gridCol税率)
                    {
                        无税单价 = ReturnDecimal(含税单价 / (1 + 税率));
                        含税金额 = ReturnDecimal(含税单价 * 数量);
                        无税金额 = ReturnDecimal(无税单价 * 数量);
                        税额 = 含税金额 - 无税金额;

                        gridView1.SetRowCellValue(iRow, gridCol无税单价, 无税单价);
                        gridView1.SetRowCellValue(iRow, gridCol无税金额, 无税金额);
                        gridView1.SetRowCellValue(iRow, gridCol含税金额, 含税金额);
                        gridView1.SetRowCellValue(iRow, gridCol税额, 税额);
                    }
                    if (e.Column == gridCol含税金额 && 数量 != 0)
                    {
                        含税单价 = ReturnDecimal(含税金额 / 数量);
                    }


                    #endregion

                }


                #region
                if (e.Column != gridColiSave && e.Column != gridCol序号 && gridView1.GetRowCellDisplayText(e.RowHandle, gridColiSave).ToString().Trim() == "")
                {
                    gridView1.SetRowCellValue(iRow, gridColiSave, "add");
                }
                if (e.Column != gridColiSave && e.Column != gridCol序号 && gridView1.GetRowCellDisplayText(e.RowHandle, gridColiSave).ToString().Trim() == "edit")
                {
                    gridView1.SetRowCellValue(iRow, gridColiSave, "update");
                }
                if (e.Column == gridCol物料编码 && e.RowHandle == gridView1.RowCount - 1 && gridView1.GetRowCellDisplayText(e.RowHandle, gridCol物料编码).ToString().Trim() != "")
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

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //try
            //{
            //    if (isChange != "N")
            //    {
            //        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridCol行关闭人) != null)
            //        {
            //            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridCol行关闭人).ToString().Trim() != "")
            //            {
            //                gridView1.OptionsBehavior.Editable = false;
            //            }
            //            else
            //            {
            //                gridView1.OptionsBehavior.Editable = true;
            //            }
            //        }
            //    }
            //}
            //catch (Exception ee)
            //{
            //    MessageBox.Show(ee.Message);
            //}
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

        private void buttonEdit部门_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit部门.Text.Trim() != "")
                lookUpEdit部门.EditValue = buttonEdit部门.Text.Trim();
            else
                lookUpEdit部门.EditValue = null;
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

        private void ItemButtonEdit物料编码_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int iRow = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.IsRowSelected(i))
                {
                    iRow = i;
                }
            }
            系统服务.Frm参照 frm = new 系统服务.Frm参照(1);
            if (DialogResult.OK == frm.ShowDialog())
            {
                gridView1.SetRowCellValue(iRow, gridCol物料编码, frm.sID);
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
            { }
            return iReturn;
        }

        /// <summary>
        /// 判断单据是否已经使用
        /// </summary>
        /// <param name="sCode">子表ID</param>
        /// <returns></returns>
        private void iCodeUsed(long 上游ID, long 当前ID, out decimal d上游单据数量, out decimal d引用量)
        {
            decimal iReturn = -1;
            d上游单据数量 = 0;
            d引用量 = 0;
            try
            {
                sSQL = @"select iQuantity-isnull(iOutQuantity,0) from rdrecords11 where 1=1 
                union all select iQuantity-isnull(iOutQuantity,0) from rdrecords12 where 1=1 
                union all select iQuantity-isnull(iOutQuantity,0) from rdrecords13 where 1=1 
                union all select iQuantity-isnull(iOutQuantity,0) from rdrecords15 where 1=1 ";
                sSQL = sSQL.Replace("1=1", "1=1 and AutoID = '" + 上游ID + "'");

                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt != null && dt.Rows.Count > 0)
                {
                    d上游单据数量 = Convert.ToDecimal(dt.Rows[0][0]);
                }

                if (当前ID > 0)
                {
                    sSQL = "select isnull(iQuantity,0) from rdrecords05 where AutoID=" + 当前ID;
                    dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        d上游单据数量 = d上游单据数量 + Convert.ToDecimal(dt.Rows[0][0]);
                    }

                    sSQL = "select isnull(iOutQuantity,0) from rdrecords05 where AutoID = " + 当前ID;
                    dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        d引用量 = Convert.ToDecimal(dt.Rows[0][0]);
                    }
                }

                iReturn = 0;
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
                lookUpEdit客户.EditValue = buttonEdit客户.Text.Trim();
            else
                lookUpEdit客户.EditValue = null;
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

        private void ItemButtonEditM1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int iRow = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.IsRowSelected(i))
                {
                    iRow = i;
                }
            }
            string invocde = gridView1.GetRowCellValue(iRow, gridCol物料编码).ToString().Trim();
            系统服务.Frm参照 frm = new 系统服务.Frm参照(21, invocde);
            if (DialogResult.OK == frm.ShowDialog())
            {
                gridView1.SetRowCellValue(iRow, gridColM1, frm.sID);
                frm.Enabled = true;
            }
        }

        private void lookUpEdit仓库_EditValueChanged(object sender, EventArgs e)
        {
            系统服务.LookUp.Position(ItemLookUpEdit货位, lookUpEdit仓库.EditValue.ToString());
        }

        private void buttonEdit操作人_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(2);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit操作人.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit操作人_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit操作人.Text.Trim() != "")
            {
                lookUpEdit操作人.EditValue = buttonEdit操作人.Text.Trim();
            }
            else
                lookUpEdit操作人.EditValue = null;
        }

        private void buttonEdit操作人_Leave(object sender, EventArgs e)
        {
            if (buttonEdit操作人.Text.Trim() == "")
                return;
            if (lookUpEdit操作人.Text.Trim() == "")
            {
                buttonEdit操作人.Text = "";
                buttonEdit操作人.Focus();
            }
        }

    }
}
