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
    public partial class Frm销售收款单 : 系统服务.FrmBaseInfo
    {
        string tablename = "SO_CloseBill";
        string tableid = "cSOCCode";
        string tablenames = "SO_CloseBillDetails";

        long iID = -1;
        public string 单据号1 = "";
        public string 单据号2 = "";
        public string 单据日期1 = "";
        public string 单据日期2 = "";
        public string 制单日期1 = "";
        public string 制单日期2 = "";
        public string 业务员 = "";
        public string 部门 = "";
        public string 客户1 = "";
        public string 客户2 = "";
        public string 审核日期1 = "";
        public string 审核日期2 = "";
        public string 制单人1 = "";
        public string 制单人2 = "";
        public string 审核人1 = "";
        public string 审核人2 = "";

        string isChange = "";

        public Frm销售收款单(long siID)
        {
            iID = siID;
            InitializeComponent();
            
        }

        public Frm销售收款单()
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
            throw new NotImplementedException();
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
            Frm销售收款单_Add frm = new Frm销售收款单_Add(单据号1, 单据号2, 单据日期1, 单据日期2, 制单日期1, 制单日期2, 业务员,
               部门, 客户1, 客户2, 审核日期1, 审核日期2, 制单人1, 制单人2, 审核人1, 审核人2);
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
                客户1 = frm.客户1;
                客户2 = frm.客户2;
                审核日期1 = frm.审核日期1;
                审核日期2 = frm.审核日期2;
                制单人1 = frm.制单人1;
                制单人2 = frm.制单人2;
                审核人1 = frm.审核人1;
                审核人2 = frm.审核人2;
                GetSel();
            }

        }

        private void GetSel()
        {
            string sSQL = "select * from " + tablename + " a left join " + tablenames + "  b on a.ID=b.ID where 1=1 ";
            if (系统服务.ClsBaseDataInfo.sUid != "admin")
            {
                sSQL = sSQL + " and cSTCode in (select cSTCode from SaleRoleCloseBill where vchrUid='" + 系统服务.ClsBaseDataInfo.sUid + "') ";
            }
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
            if (客户1 != "")
            {
                sSQL = sSQL + " and cCusCode>='" + 客户1 + "'";
            }
            if (客户2 != "")
            {
                sSQL = sSQL + " and cCusCode<='" + 客户2 + "'";
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
                if (系统服务.ClsBaseDataInfo.sUid != "admin")
                {
                    sSQL = sSQL + " and cSTCode in (select cSTCode from SaleRoleCloseBill where vchrUid='" + 系统服务.ClsBaseDataInfo.sUid + "') ";
                }
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]);;
                    iID = Convert.ToInt64(dt.Rows[0]["ID"]);
                }
                GetSelBind();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败" + ee.Message);
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
                    sSQL = "select ID from " + tablename + " where ID<" + textEditID.Text + "  ";
                    if (系统服务.ClsBaseDataInfo.sUid != "admin")
                    {
                        sSQL = sSQL + " and cSTCode in (select cSTCode from SaleRoleCloseBill where vchrUid='" + 系统服务.ClsBaseDataInfo.sUid + "') ";
                    }
                    sSQL = sSQL + " order by ID desc";

                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt.Rows.Count > 0)
                    {
                        textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]);;
                        iID = Convert.ToInt64(dt.Rows[0]["ID"]);
                    }
                    GetSelBind();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败" + ee.Message);
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
                    sSQL = "select ID from " + tablename + " where ID>" + textEditID.Text + "   ";
                    if (系统服务.ClsBaseDataInfo.sUid != "admin")
                    {
                        sSQL = sSQL + " and cSTCode in (select cSTCode from SaleRoleCloseBill where vchrUid='" + 系统服务.ClsBaseDataInfo.sUid + "') ";
                    }
                    sSQL = sSQL + " order by ID desc";

                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt.Rows.Count > 0)
                    {
                        textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]);;
                        iID = Convert.ToInt64(dt.Rows[0]["ID"]);
                    }
                    GetSelBind();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败" + ee.Message);
            }
        }
        /// <summary>
        /// 末页
        /// </summary>
        private void btnLast()
        {
            try
            {
                sSQL = "select isnull(max(ID),-1) as ID from " + tablename + " where 1=1";
                if (系统服务.ClsBaseDataInfo.sUid != "admin")
                {
                    sSQL = sSQL + " and cSTCode in (select cSTCode from SaleRoleCloseBill where vchrUid='" + 系统服务.ClsBaseDataInfo.sUid + "') ";
                }

                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]);;
                    iID = Convert.ToInt64(dt.Rows[0]["ID"]);;
                }
                GetSelBind();
            }
            catch(Exception ee)
            {
                MessageBox.Show("加载数据失败" + ee.Message);
            }
        }

        private void GetSelBind()
        {
            GetGrid();
            GetShow(false);
            sState = "sel";
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
            if (radioGroup蓝红标识.EditValue == null)
            {
                radioGroup蓝红标识.EditValue = "";
            }
            Frm销售订单_New frm = new Frm销售订单_New(buttonEdit客户.EditValue.ToString().Trim(),radioGroup蓝红标识.EditValue.ToString().Trim(), (DataTable)gridControl1.DataSource,lookUpEdit销售类型.EditValue.ToString().Trim());
            if (lookUpEdit客户.EditValue == null)
                frm.客户 = "";
            else
                frm.客户 = lookUpEdit客户.EditValue.ToString().Trim();

            frm.红蓝标志 = radioGroup蓝红标识.EditValue.ToString().Trim();
            if (DialogResult.OK == frm.ShowDialog())
            {
                bool b = false;

                if (b && lookUpEdit客户.EditValue != null && frm.客户.Trim() != lookUpEdit客户.EditValue.ToString().Trim() && frm.客户.Trim() != "")
                {
                    throw new Exception("一张单据只能有一个供应商");
                }
                if (b && radioGroup蓝红标识.EditValue != null && frm.红蓝标志.Trim() != radioGroup蓝红标识.EditValue.ToString().Trim())
                {
                    throw new Exception("红蓝标志不能修改");
                }

                radioGroup蓝红标识.EditValue = frm.红蓝标志;
                
                lookUpEdit销售类型.EditValue = frm.销售类型;
                frm.Enabled = true;
                DataTable dtnew = frm.dt;
                int i = gridView1.RowCount - 1;
                gridView1.FocusedRowHandle = i;

                //if (dtnew.Rows.Count > 0)
                //{
                //    buttonEdit业务员.EditValue = dtnew.Rows[0]["cPersonCode"].ToString();
                //    buttonEdit客户.EditValue = dtnew.Rows[0]["cDepCode"].ToString();
                //}

                for (int s = 0; s < dtnew.Rows.Count; s++)
                {
                    if (s != 0)
                    {
                        gridView1.FocusedRowHandle = gridView1.RowCount - 1;
                        i = gridView1.RowCount - 1;
                    }

                    if (dtnew.Rows[s]["iType"].ToString() != "")
                    {
                        gridView1.SetRowCellValue(i, gridCol来源类型, dtnew.Rows[s]["iType"].ToString());
                    }
                    if (dtnew.Rows[s]["cTypeCode"].ToString() != "")
                    {
                        gridView1.SetRowCellValue(i, gridCol来源单据号, dtnew.Rows[s]["cTypeCode"].ToString());
                    }

                    if (dtnew.Rows[s]["cSBVAutoID"].ToString() != "")
                    {
                        gridView1.SetRowCellValue(i, gridCol来源单据ID, dtnew.Rows[s]["cSBVAutoID"].ToString());
                    }
                    //if (dtnew.Rows[s]["dDate"].ToString() != "")
                    //{
                    //    gridView1.SetRowCellValue(i, gridCol来源单据号, dtnew.Rows[s]["cTypeCode"].ToString());
                    //}
                    if (dtnew.Rows[s]["iMoney"].ToString() != "")
                    {
                        gridView1.SetRowCellValue(i, gridCol含税金额, dtnew.Rows[s]["iMoney"].ToString());
                    }
                    if (dtnew.Rows[s]["iReceiptMoney"].ToString() != "")
                    {
                        gridView1.SetRowCellValue(i, gridCol应收款, dtnew.Rows[s]["iReceiptMoney"].ToString());
                    }

                    gridView1.SetRowCellValue(i, gridColiSave, "add");
                    
                    gridView1.AddNewRow();
                }

                buttonEdit客户.EditValue = frm.客户;
            }
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
            GetShow(true);
            dateEdit单据日期.EditValue = 系统服务.ClsBaseDataInfo.sLogDate;

            int iFocRow = gridView1.FocusedRowHandle;

            sSQL = "select a.*,cast(null as decimal(16,6)) as iReceiptMoney,cast(null as decimal(16,6)) as iMoney, 'edit' as iSave  from " + tablenames + " a where 1=-1";
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
            
            gridView1.OptionsBehavior.Editable = true;
            radioGroup蓝红标识.EditValue = "1";

            btnAddRow();

            gridCol应收款.Visible = true;
            sState = "add";
        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {
            int iRe = CheState(textEditID.Text.Trim());
            if (iRe == -1)
            {
                throw new Exception("检查单据状态出错");
            }
            if (iRe == 0)
            {
                throw new Exception("单据不存在");
            }
            //if (iRe == 1 && sState == "alter")
            //{
            //    throw new Exception("单据未审核");
            //}
            if (iRe == 2)
            {
                throw new Exception("单据已审核");
            }
            if (iRe == 3)
            {
                throw new Exception("单据已关闭");
            }

            gridCol应收款.Visible = true;

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridCol来源类型).ToString().Trim() == "")
                    continue;

                decimal d累计下单金额 = 0;
                decimal d单据金额 = 0;
                string sType = gridView1.GetRowCellValue(i, gridCol来源类型).ToString().Trim();
                string sTypeCode = gridView1.GetRowCellValue(i, gridCol来源单据号).ToString().Trim();
                long autoid = Convert.ToInt64(gridView1.GetRowCellValue(i, gridColAutoID));
                int iReturn = iCodeUsed(autoid ,sType, sTypeCode, out d累计下单金额, out d单据金额);
                if (iReturn == -1)
                {
                    throw new Exception("获取历史数据失败");
                }
                gridView1.SetRowCellValue(i, gridCol含税金额, d单据金额);
                if (radioGroup蓝红标识.EditValue.ToString() == "1")
                {
                    gridView1.SetRowCellValue(i, gridCol应收款, d单据金额 - d累计下单金额);
                }
                if (radioGroup蓝红标识.EditValue.ToString() == "2")
                {
                    gridView1.SetRowCellValue(i, gridCol应收款, - d累计下单金额);
                }
            }

            GetShow(true);
            sState = "edit";
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
            int iRe = CheState(textEditID.Text.Trim());
            if (iRe == -1)
            {
                throw new Exception("检查单据状态出错");
            }
            if (iRe == 0 && (sState == "edit" || sState == "alter"))
            {
                throw new Exception("单据不存在");
            }
            //if (iRe == 1 && sState == "alter")
            //{
            //    throw new Exception("单据未审核");
            //}
            if (iRe == 2 && sState == "edit")
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
                sSQL = "delete " + tablenames + " where id = " + textEditID.Text.Trim();
                aList.Add(sSQL);
                sSQL = "delete " + tablename + " where id = " + textEditID.Text.Trim();
                aList.Add(sSQL);
               
                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("删除成功！\n合计执行语句:" + iCou + "条");
                    GetGrid();
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

            int iRe = CheState(textEditID.Text.Trim());
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
            if (radioGroup蓝红标识.EditValue.ToString() == "1" && ReturnDecimal(textEdit收款金额.Text) < 0)
            {
                throw new Exception("蓝字单据收款金额必须为正数");
            }
            if (radioGroup蓝红标识.EditValue.ToString() == "2" && ReturnDecimal(textEdit收款金额.Text) > 0)
            {
                throw new Exception("红字单据收款金额必须为负数");
            }
            if (buttonEdit客户.EditValue == null || buttonEdit客户.EditValue.ToString().Trim() == "")
            {
                throw new Exception("客户不能为空");
            }
            if (textEdit收款金额.EditValue == null || ReturnDecimal(textEdit收款金额.EditValue.ToString().Trim()) == 0)
            {
                throw new Exception("收款金额不能为空");
            }
            if (dateEdit单据日期.EditValue == null || dateEdit单据日期.EditValue.ToString().Trim() == "")
            {
                throw new Exception("单据日期不能为空");
            }
            if (lookUpEdit销售类型.EditValue == null || lookUpEdit销售类型.EditValue.ToString().Trim() == "")
            {
                throw new Exception("销售类型不能为空");
            }
            if (lookUpEdit业务员.EditValue == null || lookUpEdit业务员.EditValue.ToString().Trim() == "")
            {
                throw new Exception("业务员不能为空");
            }
            if (lookUpEdit部门.EditValue == null || lookUpEdit部门.EditValue.ToString().Trim() == "")
            {
                throw new Exception("部门不能为空");
            }
            if (lookUpEdit收款类别.EditValue == null || lookUpEdit收款类别.EditValue.ToString().Trim() == "")
            {
                throw new Exception("收款类别不能为空");
            }

            decimal d金额 = ReturnDecimal(textEdit收款金额.Text);
            decimal d本次金额 = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                d本次金额 = d本次金额 + ReturnDecimal(gridView1.GetRowCellValue(i, gridCol本次收款));
            }
            if (d金额 < d本次金额)
            {
                throw new Exception("请注意收款金额必须大于或等于本次金额");
            }

            aList = new System.Collections.ArrayList();
            DataRow drh = dt.NewRow();
            if (sState == "add")
            {
                sSQL = "select isnull(isnull(max(ID),-1)+1,1) as ID from " + tablename;
                iID = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                drh["ID"] = iID;
                drh["cSOCCode"] = 系统服务.序号.GetNewSerialNumberContinuous(tablename, tableid);
                textEdit单据号.EditValue = drh["cSOCCode"].ToString();
            }
            else
            {
                drh["ID"] = textEditID.Text;
                iID = Convert.ToInt64(textEditID.Text);
                drh["cSOCCode"] = textEdit单据号.EditValue.ToString().Trim();
            }
            drh["dDate"] = dateEdit单据日期.EditValue.ToString().Trim();

            drh["cPersonCode"] = buttonEdit业务员.EditValue.ToString().Trim();
            drh["cDepCode"] = buttonEdit部门.EditValue.ToString().Trim();
            drh["cCusCode"] = buttonEdit客户.EditValue.ToString().Trim();
            drh["cSTCode"] = lookUpEdit销售类型.EditValue.ToString().Trim();
            drh["S1"] = lookUpEdit收款类别.EditValue.ToString().Trim();
            if (textEdit收款金额.EditValue != null && textEdit收款金额.EditValue.ToString().Trim() != "")
            {
                drh["iAmount"] = textEdit收款金额.EditValue.ToString().Trim();
            }
            drh["cSSCode"] = lookUpEdit结算方式.EditValue.ToString().Trim();

            drh["Flag"] = radioGroup蓝红标识.EditValue.ToString().Trim();

            drh["cMemo"] = textEdit备注.EditValue.ToString().Trim();

            if (sState == "add")
            {
                drh["dCreatesysTime"] = 系统服务.ClsBaseDataInfo.sLogDate;
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
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "update" || gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "add")
                {
                    #region 判断
                    if (ReturnDecimal(gridView1.GetRowCellValue(i, gridCol本次收款)) == 0)
                        continue;

                    if (radioGroup蓝红标识.EditValue.ToString() == "1" && ReturnDecimal(gridView1.GetRowCellValue(i, gridCol本次收款)) < 0)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "蓝字单据不能为负数";
                    }
                    if (radioGroup蓝红标识.EditValue.ToString() == "2" && ReturnDecimal(gridView1.GetRowCellValue(i, gridCol本次收款)) > 0)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "红字单据不能为正数";
                    }

                    #endregion

                    #region 生成table
                    DataRow dr = dts.NewRow();
                    if (gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim() != "")
                    {
                        dr["AutoID"] = gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim();
                    }
                    dr["ID"] = iID;
                    dr["iType"] = gridView1.GetRowCellValue(i, gridCol来源类型).ToString().Trim();
                    dr["cTypeCode"] = gridView1.GetRowCellValue(i, gridCol来源单据号).ToString().Trim();
                    dr["cSBVAutoID"] = gridView1.GetRowCellValue(i, gridCol来源单据ID).ToString().Trim();

                    dr["S1"] = gridView1.GetRowCellValue(i, gridColS1).ToString().Trim();
                    if (gridView1.GetRowCellValue(i, gridColD1) != null && gridView1.GetRowCellValue(i, gridColD1).ToString().Trim() != "")
                    {
                        dr["D1"] = gridView1.GetRowCellValue(i, gridColD1).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridColDate1) != null && gridView1.GetRowCellValue(i, gridColDate1).ToString().Trim() != "")
                    {
                        dr["Date1"] = gridView1.GetRowCellValue(i, gridColDate1).ToString().Trim();
                    }

                    decimal d本次 = ReturnDecimal(gridView1.GetRowCellValue(i, gridCol本次收款));

                    dr["iMoneyNow"] = d本次;
                    
                    dr["cMemo"] = gridView1.GetRowCellValue(i, gridCol备注).ToString().Trim();

                    dts.Rows.Add(dr);

                   
                    #endregion


                    if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "update")
                    {
                        sSQL = clsGetSQL.GetUpdateSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablenames, dts, dts.Rows.Count - 1);
                    }
                    else if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "add")
                    {
                        sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablenames, dts, dts.Rows.Count - 1);
                    }

                    aList.Add(sSQL);

                    
                }
            }
            #endregion
            if (sErr != "")
            {
                throw new Exception(sErr);
            }

            #region 表体不能为空
            bool b列表 = false;
            int bCount = 0;
            decimal sum = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridCol本次收款).ToString().Trim() != "")
                {
                    b列表 = true;
                    bCount = bCount + 1;
                    sum = sum + ReturnDecimal(gridView1.GetRowCellValue(i, gridCol本次收款));
                }
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
                if (gridView1.GetRowCellValue(i, gridCol本次收款).ToString().Trim() != "")
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


            bool isok = false;
            if (ReturnDecimal(sum) != ReturnDecimal(textEdit收款金额.EditValue))
            {
                DialogResult result = MessageBox.Show("标题和表头收款金额不同是否保存?", "保存提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.OK)
                {
                    isok = true;
                }
            }
            else
            {
                isok = true;
            }
            if (isok == true)
            {
                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);
                    System.Collections.ArrayList aList1 = new System.Collections.ArrayList();
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        string iType = gridView1.GetRowCellValue(i, gridCol来源类型).ToString().Trim();
                        string SoAutoID = gridView1.GetRowCellValue(i, gridCol来源单据ID).ToString().Trim();
                        if (iType == "2")
                        {
                            系统服务.收款利润.Get(SoAutoID, aList1);
                        }
                    }
                    if (aList1.Count > 0)
                    {
                        try
                        {
                            int iCou1 = clsSQLCommond.ExecSqlTran(aList1);
                        }
                        catch
                        {
                            throw new Exception("收款利润保存不成功");
                        }

                    }
                    MessageBox.Show("保存成功！\n合计执行语句:" + iCou + "条");
                    textEditID.EditValue = iID;
                    GetSelBind();
                }
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
            int iRe = CheState(textEditID.Text.Trim());
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
            //    throw new Exception("单据未审核");
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

            #region 判断是否已全部收款
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string iType = gridView1.GetRowCellValue(i, gridCol来源类型).ToString().Trim();
                string SoAutoID = gridView1.GetRowCellValue(i, gridCol来源单据ID).ToString().Trim();
                if (iType == "2")
                {
                    系统服务.收款利润.Get(SoAutoID, aList);
                }
            }
            #endregion

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
            int iRe = CheState(textEditID.Text.Trim());
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
            //if (iRe == 2 && sState == "edit")
            //{
            //    throw new Exception("单据已审核");
            //}
            if (iRe == 3)
            {
                throw new Exception("单据已关闭");
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
            int iRe = CheState(textEditID.Text.Trim());
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
            if (iRe == 2 && sState == "edit")
            {
                throw new Exception("单据已审核");
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
            int iRe = CheState(textEditID.Text.Trim());
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

            sSQL = "update " + tablename + " set dClosesysTime='" + 系统服务.ClsBaseDataInfo.sLogDate + "',dClosesysPerson='" + 系统服务.ClsBaseDataInfo.sUid + "' where ID=" + textEditID.Text + "";
            aList.Add(sSQL);
            sSQL = "update " + tablenames + " set cClosesysTime='" + 系统服务.ClsBaseDataInfo.sLogDate + "',cClosesysPerson='" + 系统服务.ClsBaseDataInfo.sUid + "' where ID=" + textEditID.Text + " and  (cClosesysPerson='' or cClosesysPerson is null)";
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
            gridCol应收款.Visible = true;

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridCol来源类型).ToString().Trim() == "")
                    continue;

                decimal d累计下单金额 = 0;
                decimal d单据金额 = 0;
                string sType = gridView1.GetRowCellValue(i, gridCol来源类型).ToString().Trim();
                string sTypeCode = gridView1.GetRowCellValue(i, gridCol来源单据号).ToString().Trim();
                long autoid = Convert.ToInt64(gridView1.GetRowCellValue(i, gridColAutoID));
                int iReturn = iCodeUsed(autoid, sType, sTypeCode, out d累计下单金额, out d单据金额);
                if (iReturn == -1)
                {
                    throw new Exception("获取历史数据失败");
                }
                gridView1.SetRowCellValue(i, gridCol含税金额, d单据金额);
                if (radioGroup蓝红标识.EditValue.ToString() == "1")
                {
                    gridView1.SetRowCellValue(i, gridCol应收款, d单据金额 - d累计下单金额);
                }
                if (radioGroup蓝红标识.EditValue.ToString() == "2")
                {
                    gridView1.SetRowCellValue(i, gridCol应收款, -d累计下单金额);
                }
            }

            sState = "alter";
            GetShow(true);
        }

        #endregion

        private void Frm销售收款单_Load(object sender, EventArgs e)
        {
            try
            {
                radioGroup蓝红标识.EditValue = "1";

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
                sSQL = "select * from " + tablename + " where ID=" + iID +" ";

                if (系统服务.ClsBaseDataInfo.sUid != "admin")
                {
                    sSQL = sSQL + " and cSTCode in (select cSTCode from SaleRoleCloseBill where vchrUid='" + 系统服务.ClsBaseDataInfo.sUid + "') ";
                }
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]);;
                    textEdit单据号.EditValue = dt.Rows[0]["cSOCCode"].ToString();
                    textEdit收款金额.EditValue = dt.Rows[0]["iAmount"].ToString();

                    dateEdit单据日期.EditValue = dt.Rows[0]["dDate"].ToString();
                    dateEdit制单日期.EditValue = dt.Rows[0]["dCreatesysTime"].ToString();
                    dateEdit审核日期.EditValue = dt.Rows[0]["dVerifysysTime"].ToString();
                    dateEdit关闭日期.EditValue = dt.Rows[0]["dClosesysTime"].ToString();

                    textEdit备注.EditValue = dt.Rows[0]["cMemo"].ToString();
                    textEdit制单人.EditValue = dt.Rows[0]["dCreatesysPerson"].ToString();
                    textEdit审核人.EditValue = dt.Rows[0]["dVerifysysPerson"].ToString();
                    textEdit关闭人.EditValue = dt.Rows[0]["dClosesysPerson"].ToString();

                    buttonEdit客户.EditValue = dt.Rows[0]["cCusCode"].ToString();
                    buttonEdit业务员.EditValue = dt.Rows[0]["cPersonCode"].ToString();
                    buttonEdit部门.EditValue = dt.Rows[0]["cDepCode"].ToString();
                    
                    lookUpEdit结算方式.EditValue = dt.Rows[0]["cSSCode"].ToString();

                    radioGroup蓝红标识.EditValue = dt.Rows[0]["Flag"].ToString();

                    lookUpEdit销售类型.EditValue = dt.Rows[0]["cSTCode"].ToString();
                    lookUpEdit收款类别.EditValue = ReturnInt( dt.Rows[0]["S1"]);

                    buttonEdit客户.Enabled = false;
                    sSQL = "select cast(null as decimal(16,6)) as iReceiptMoney,case when a.iType = 1 then b.D1 when a.iType = 2 then c.iMoney end as iMoney,*, 'edit' as iSave  " +
                            "from " + tablenames + " a " +
                                " left join (select iID,sum(D1) as D1 FROM AR_First group by iID)b on a.cTypeCode = cast(b.iID as varchar(50)) and iType = 1 " +
                                " left join (select cSOCode,sum(iMoney) as iMoney from dbo.SO_SODetails group by cSOCode) c on a.cTypeCode = c.cSOCode and iType = 2 " +
                             "where a.ID=" + iID;
                    dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
                    gridControl1.DataSource = dtBingGrid;

                    gridView1.AddNewRow();

                    gridCol应收款.Visible = false;

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
            系统服务.LookUp._LoopUpData(ItemLookUpEdit来源类型, "21");
            系统服务.LookUp.SettleStyle(lookUpEdit结算方式);
            系统服务.LookUp.Customer(lookUpEdit客户);
            系统服务.LookUp.Person(lookUpEdit业务员);
            系统服务.LookUp.Department(lookUpEdit部门);
            系统服务.LookUp.SaleTypeSaleRoleCloseBill(lookUpEdit销售类型);
            系统服务.LookUp._LoopUpData(lookUpEdit收款类别,"31");
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
            textEdit收款金额.Enabled = b;

            buttonEdit业务员.Enabled = b;
            buttonEdit部门.Enabled = b;
            buttonEdit客户.Enabled = b;
            lookUpEdit结算方式.Enabled = b;

            lookUpEdit客户.Enabled = false;
            lookUpEdit业务员.Enabled = false;
            lookUpEdit部门.Enabled = false;

            radioGroup蓝红标识.Enabled = false;
            lookUpEdit销售类型.Enabled = b;
            lookUpEdit收款类别.Enabled = b;
            
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
            textEdit收款金额.EditValue = "";

            buttonEdit业务员.EditValue = "";
            buttonEdit部门.EditValue = "";
            buttonEdit客户.EditValue = "";
            lookUpEdit结算方式.EditValue = "";
            lookUpEdit销售类型.EditValue = "";
            lookUpEdit收款类别.EditValue = 1;
            sSQL = "select cast(null as decimal(16,6)) as iReceiptMoney,cast(null as decimal(16,6)) as iMoney,*, 'edit' as iSave  from " + tablenames + " where ID=" + iID;
            dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dtBingGrid;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int iRow = 0;
            if (gridView1.FocusedRowHandle >= 0)
                iRow = gridView1.FocusedRowHandle;

            if (gridView1.GetRowCellValue(iRow, gridCol序号).ToString().Trim() == "")
            {
                gridView1.SetRowCellValue(iRow, gridCol序号, iRow + 1);
            }
            if (e.Column == gridCol本次收款)
            {
                if (ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol本次收款)) > ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol应收款)))
                {

                    throw new Exception("收款金额大于可收金额");
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
            //if (e.Column == gridCol来源单据号 && e.RowHandle == gridView1.RowCount - 1 && gridView1.GetRowCellDisplayText(e.RowHandle, gridCol来源单据号).ToString().Trim() != "")
            //{
            //    gridView1.AddNewRow();
            //    gridView1.FocusedRowHandle = iRow;
            //}
            #endregion
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

        private void buttonEdit客户_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(9);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit客户.EditValue = frm.sID;
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


        private void buttonEdit客户_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit客户.Text.Trim() != "")
            {
                lookUpEdit客户.EditValue = buttonEdit客户.Text.Trim();
                if (lookUpEdit客户.Text.Trim() != "")
                {
                    sSQL = "select top 1 * from CustomersAdjust where aIntCode='" + lookUpEdit客户.EditValue.ToString().Trim() + "' and aIntAdjustTime<='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and aIntPPerson is not null order by aIntAdjustTime desc";
                    DataTable dtj = clsSQLCommond.ExecQuery(sSQL);
                    if (dtj.Rows.Count > 0)
                    {
                        buttonEdit业务员.EditValue = dtj.Rows[0]["aIntPPerson"];
                    }
                    else
                    {
                        if (gridView1.RowCount > 0)
                        {
                            if (gridView1.GetRowCellValue(0, gridCol来源类型).ToString().Trim() == "2")
                            {
                                DataTable dt = clsSQLCommond.ExecQuery("select cPersonCode from SO_SOMain where cCusCode='" + lookUpEdit客户.EditValue.ToString().Trim() + "'");
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    buttonEdit业务员.EditValue = dt.Rows[0]["cPersonCode"];
                                }
                            }
                            else
                            {
                                DataTable dt = clsSQLCommond.ExecQuery("select S3 from AR_First where S1='" + lookUpEdit客户.EditValue.ToString().Trim() + "'");
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    buttonEdit业务员.EditValue = dt.Rows[0]["S3"];
                                }
                            }
                        }
                    }
                }
            }
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

        private void textEdit收款金额_EditValueChanged(object sender, EventArgs e)
        {
            if (sState == null || sState == "sel" || sState == "")
                return;

            if (textEdit收款金额.Text.Trim() == "")
                return;

            decimal d1 = ReturnDecimal(textEdit收款金额.Text);
            if (d1 == 0)
                return;

            if (radioGroup蓝红标识.EditValue.ToString() == "1" && d1<0)
            {
                MessageBox.Show("蓝字单据，收款金额必须是正数");
                return;
            }
            if (radioGroup蓝红标识.EditValue.ToString() == "2" && d1 > 0)
            {
                MessageBox.Show("红字单据，收款金额必须是负数");
                return;
            }
            if (radioGroup蓝红标识.EditValue.ToString() == "1")
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridCol来源单据号) == null || gridView1.GetRowCellValue(i, gridCol来源单据号).ToString().Trim() == "")
                        continue;

                    decimal d2 = ReturnDecimal(gridView1.GetRowCellValue(i, gridCol应收款));
                    if (d1 >= d2)
                    {
                        gridView1.SetRowCellValue(i, gridCol本次收款, d2);
                        d1 = d1 - d2;
                    }
                    else
                    {
                        gridView1.SetRowCellValue(i, gridCol本次收款, d1);
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

                    decimal d2 = ReturnDecimal(gridView1.GetRowCellValue(i, gridCol应收款));
                    if (d1 <= d2)
                    {
                        gridView1.SetRowCellValue(i, gridCol本次收款, d2);
                        d1 = d1 - d2;
                    }
                    else
                    {
                        gridView1.SetRowCellValue(i, gridCol本次收款, d1);
                        d1 = 0;
                        return;
                    }
                }
            }
        }


        /// <summary>
        /// 判断单据状态
        /// </summary>
        /// <param name="sID">单据ID</param>
        /// <returns>-1：出错</returns>
        /// <returns>0 ：不存在单据</returns>
        /// <returns>1 ：已保存</returns>
        /// <returns>2 ：已审核</returns>
        /// <returns>3 ：已关闭</returns>
        private int CheState(string sID)
        {
            int iReturn = -1;
            try
            {
                sSQL = "select  isnull(dCreatesysPerson,'') as 制单人,isnull(dVerifysysPerson,'') as 审核人,isnull(dClosesysPerson,'') as 关闭人 from " + tablename + " where id = '" + sID + "'";
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
        private int iCodeUsed(long autoid,string iType, string cTypeCode, out decimal 累计下单金额, out decimal 单据金额)
        {
            int iReturn = -1;
            累计下单金额 = 0;
            单据金额 = 0;
            try
            {
                string sSQL = "";
                if (iType == "1")
                {
                    sSQL = @"select a.S1,a.D1 as iMoney,isnull(b.iMoneyNow,0)+isnull(c.iAmount,0) as iMoneyNow from AR_First a 
left join (select cTypeCode,sum(iAmount) as iAmount from SaleVerification where iType=1 group by cTypeCode) c on a.iID=c.cTypeCode 
left join  ( select b.iType,b.cTypeCode,sum(iMoneyNow) as iMoneyNow from SO_CloseBill a inner join SO_CloseBillDetails b on a.id = b.id 

where b.iType = '1' and b.cTypeCode = '" + cTypeCode + "' and b.autoid <>  " + autoid + " group by b.iType,b.cTypeCode ) b on cast(a.iID as varchar(50)) = b.cTypeCode where a.iID = " + cTypeCode;
                }

                if (iType == "2")
                {
//                    sSQL = @" select a.iMoney,isnull(r.iMoney,0)+isnull(f.iMoney,0)+isnull(c.iAmount,0)+isnull(b.iMoneyNow,0) as iMoneyNow " +
//"from (select a.ID,a.cSOCode,sum(b.iMoney) as iMoney from dbo.SO_SOMain a inner join dbo.SO_SODetails b on a.id = b.id  "+
//"where a.cSOCode = '" + cTypeCode + "' group by a.ID,a.cSOCode ) a left join ( select b.iType,b.cTypeCode,b.cSBVAutoID,sum(iMoneyNow) as iMoneyNow from SO_CloseBill a inner join SO_CloseBillDetails b on a.id = b.id " +
//"where b.iType = '2' and b.cTypeCode = '" + cTypeCode + "' and b.autoid <> " + autoid + " group by b.iType,b.cTypeCode,b.cSBVAutoID ) b on a.cSOCode = b.cTypeCode " +
//"left join (select SoAutoID,sum(isnull(iQuantity,0)) as iQuantity,sum(isnull(iNum,0)) as iNum ,sum(isnull(iNatMoney,0)) as iNatMoney ,sum(isnull(iMoney,0)) as iMoney  from SO_SOReturns group by SoAutoID) r on b.AutoID=r.SoAutoID  " +
//"left join (select sum(iQuantity) as iQuantity,sum(isnull(iMoney,0)) as iMoney,SoAutoID from RdRecord a inner join RdRecords b on a.id = b.id where a.cRSCode in ('05','06','07') group by SoAutoID) f on f.SoAutoID = b.AutoID " +
//"left join (select cTypeCode,sum(iAmount) as iAmount from SaleVerification where iType=2 group by cTypeCode) c on a.ID=c.cTypeCode ";
                    sSQL = @"select a.AutoID,a.iMoney,isnull(r.iMoney,0)+isnull(f.iMoney,0)+isnull(c.iAmount,0)+isnull(b.iMoneyNow,0) as iMoneyNow 
from (select a.ID,b.AutoID,sum(b.iMoney) as iMoney from dbo.SO_SOMain a inner join dbo.SO_SODetails b on a.id = b.id  where a.cSOCode = '" + cTypeCode + "' group by a.ID,b.AutoID ) a "+
@"left join ( select b.cSBVAutoID,sum(iMoneyNow) as iMoneyNow from SO_CloseBill a inner join SO_CloseBillDetails b 
on a.id = b.id where b.iType = '2' and b.autoid <> " + autoid + " group by b.iType,b.cSBVAutoID ) b on a.AutoID = b.cSBVAutoID "+
@"left join (select SoAutoID,sum(isnull(iQuantity,0)) as iQuantity,sum(isnull(iNum,0)) as iNum ,sum(isnull(iNatMoney,0)) as iNatMoney ,sum(isnull(iMoney,0)) as iMoney  
from SO_SOReturns group by SoAutoID) r on a.AutoID=r.SoAutoID  
left join (select sum(iQuantity) as iQuantity,sum(isnull(iMoney,0)) as iMoney,SoAutoID from RdRecord a inner join RdRecords b on a.id = b.id 
where a.cRSCode in ('05','06','07') group by SoAutoID) f on f.SoAutoID = a.AutoID 
left join (select cTypeCode,sum(iAmount) as iAmount from SaleVerification where iType=2 group by cTypeCode) c on a.ID=c.cTypeCode ";
                }
                if (sSQL.Length == 0)
                {
                    throw new Exception("单据来源类型错误");
                }

                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt != null && dt.Rows.Count > 0)
                {
                    单据金额 = ReturnDecimal(dt.Rows[0]["iMoney"]);
                    累计下单金额 = ReturnDecimal(dt.Rows[0]["iMoneyNow"]);
                }
                iReturn = 0;
            }
            catch (Exception ee)
            { }
            return iReturn;
        }

        private void radioGroup蓝红标识_EditValueChanged(object sender, EventArgs e)
        {
            if (radioGroup蓝红标识.EditValue.ToString().Trim() == "1")
            {
                gridCol应收款.Caption = "可收款金额";
            }
            if (radioGroup蓝红标识.EditValue.ToString().Trim() == "2")
            {
                gridCol应收款.Caption = "可退款金额";
            }
        }

        private void lookUpEdit客户_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
