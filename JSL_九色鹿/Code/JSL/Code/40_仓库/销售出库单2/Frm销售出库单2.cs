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
    public partial class Frm销售出库单2 : 系统服务.FrmBaseInfo
    {
        string tablename = "RdRecord11";
        string tableid = "cRDCode";
        string tablenames = "RdRecords11";
        string cRsCode = "";

        DataTable dth;

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
        public string 物料1 = "";
        public string 物料2 = "";
        public string BoxNo = "";
        public string sBoxNo = "";

        public string s销售订单号 = "";

        string isChange = "";

        public Frm销售出库单2(long siID, string title)
        {
            iID = siID;
            InitializeComponent();
            this.Text = title;
        }

        public Frm销售出库单2(long siID)
        {
            iID = siID;
            InitializeComponent();

        }
        public Frm销售出库单2()
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
                    case "print2":
                        btnPrint2();
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
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }
        }

        /// <summary>
        /// 打印
        /// </summary>
        private void btnPrint2()
        {
            try
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

                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;

                aList = new System.Collections.ArrayList();
                if (gridView1.RowCount > 0)
                {
                    aList.Add("update  " + tablename + " set PrintCount=" + textEdit打印次数.Text.Trim() + " + 1,LastPrintDate = getdate() where ID=" + textEditID.Text.Trim());
                    if (aList.Count > 0)
                    {
                        int iCou = clsSQLCommond.ExecSqlTran(aList);
                    }
                }
            }
            catch (Exception ee)
            {
                isPrint = false;
                throw new Exception(ee.Message);
            }
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
        /// 导入 打印汇总
        /// </summary>
        private void btnImport()
        {
            
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
            Frm销售出库单2_Add frm = new Frm销售出库单2_Add(单据号1, 单据号2, 单据日期1, 单据日期2, 制单日期1, 制单日期2, 业务员,
                部门, 客户1, 客户2, 审核日期1, 审核日期2, 制单人1, 制单人2, 审核人1, 审核人2, 物料1, 物料2, BoxNo, sBoxNo);
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
                物料1 = frm.物料1;
                物料2 = frm.物料2;
                BoxNo = frm.BoxNo;
                sBoxNo = frm.sBoxNo;
                GetSel();
            }

        }

        private void GetSel()
        {
            string sSQL = "select * from " + tablename + " a left join " + tablenames + "  b on a.ID=b.ID left join RdStyle r on a.cRSCode=r.cRSCode where 收发标志='1'  and a.cRSCode='"+cRsCode+"'";
            if (单据号1 != "")
            {
                sSQL = sSQL + " and a." + tableid + ">='" + 单据号1 + "'";
            }
            if (单据号2 != "")
            {
                sSQL = sSQL + " and a." + tableid + "<='" + 单据号2 + "'";
            }
            if (单据日期1 != "")
            {
                sSQL = sSQL + " and dDate>='" + 单据日期1 + "'";
            }
            if (单据日期2 != "")
            {
                sSQL = sSQL + " and dDate<='" + 单据日期2 + "'";
            }
            if (制单日期1 != "")
            {
                sSQL = sSQL + " and dCreatesysTime>='" + 制单日期1 + "'";
            }
            if (制单日期2 != "")
            {
                sSQL = sSQL + " and dCreatesysTime<='" + 制单日期2 + "'";
            }
            if (业务员 != "")
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
            if (物料1 != "")
            {
                sSQL = sSQL + " and b.cInvCode>='" + 物料1 + "'";
            }
            if (物料2 != "")
            {
                sSQL = sSQL + " and b.cInvCode<='" + 物料2 + "'";
            }
            if (BoxNo != "")
            {
                sSQL = sSQL + " and b.BoxNo like '%" + BoxNo + "%'";
            }
            if (sBoxNo != "")
            {
                sSQL = sSQL + " and b.sBoxNo like '%" + sBoxNo + "%'";
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
                sSQL = "select min(ID) as ID from " + tablename + " a left join RdStyle r on a.cRSCode=r.cRSCode where 收发标志='1' and a.cRSCode='" + cRsCode + "'";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]); ;
                    iID = Convert.ToInt64(dt.Rows[0]["ID"]); ;
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
                    sSQL = "select ID from " + tablename + "  a left join RdStyle r on a.cRSCode=r.cRSCode where ID<" + textEditID.Text + " and 收发标志='1' and a.cRSCode='" + cRsCode + "' order by ID desc";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt.Rows.Count > 0)
                    {
                        textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]); ;
                        iID = Convert.ToInt64(dt.Rows[0]["ID"]); ;
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
                    sSQL = "select ID from " + tablename + " a left join RdStyle r on a.cRSCode=r.cRSCode where ID>" + textEditID.Text + " and 收发标志='1' and a.cRSCode='" + cRsCode + "' order by ID ";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt.Rows.Count > 0)
                    {
                        textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]); ;
                        iID = Convert.ToInt64(dt.Rows[0]["ID"]); ;
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
                sSQL = "select isnull(max(ID),-1) as ID from " + tablename + " a left join RdStyle r on a.cRSCode=r.cRSCode where  收发标志='1' and a.cRSCode='" + cRsCode + "'";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]); 
                    iID = Convert.ToInt64(dt.Rows[0]["ID"]); 
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
            string sErr = "";
            if (radioGroup蓝红标识.EditValue == null)
            {
                radioGroup蓝红标识.EditValue = "";
            }
            DataTable dtt = (DataTable)gridControl1.DataSource;
            if (dtt.Rows.Count > 0)
            {
                s销售订单号 = dtt.Rows[0]["AutoID"].ToString();
            }
            else
            {
                s销售订单号 = "";
            }
            Frm销售订单_New3 frm = new Frm销售订单_New3(buttonEdit客户.Text.ToString().Trim(), dtt, s销售订单号, radioGroup蓝红标识.EditValue.ToString().Trim(),cRsCode);
            if (lookUpEdit客户.EditValue == null)
                frm.客户 = "";
            else
                frm.客户 = lookUpEdit客户.EditValue.ToString().Trim();

            frm.红蓝标志 = radioGroup蓝红标识.EditValue.ToString().Trim();
            if (DialogResult.OK == frm.ShowDialog())
            {
                
                bool b = false;
                for (int ii = 0; ii < gridView1.RowCount; ii++)
                {
                    if (gridView1.GetRowCellValue(ii, gridCol物料编码).ToString().Trim() != "")
                    {
                        b = true;
                        break;
                    }
                }
                if (b && lookUpEdit客户.EditValue != null && frm.客户.Trim() != lookUpEdit客户.EditValue.ToString().Trim() && frm.客户.Trim() != "")
                {
                    throw new Exception("一张单据只能有一个客户");
                }
                if (b && radioGroup蓝红标识.EditValue != null && frm.红蓝标志.Trim() != radioGroup蓝红标识.EditValue.ToString().Trim())
                {
                    throw new Exception("红蓝标志不能修改");
                }

                radioGroup蓝红标识.EditValue = frm.红蓝标志;
                buttonEdit客户.EditValue = frm.客户;

                frm.Enabled = true;
                DataTable dtnew = frm.dt;
                int i = gridView1.RowCount - 1;
                gridView1.FocusedRowHandle = i;
                for (int s = 0; s < dtnew.Rows.Count; s++)
                {
                    if (gridView1.RowCount == 0)
                    {
                        lookUpEdit仓库.EditValue = dtnew.Rows[0]["cWhCode"].ToString();
                    }
                    else
                    {
                        //if (lookUpEdit部门.EditValue != dtnew.Rows[0]["cWhCode"].ToString())
                        //{
                        //    throw new Exception("出库单仓库必须相同");
                        //}
                    }
                    if (s != 0)
                    {
                        gridView1.FocusedRowHandle = gridView1.RowCount - 1;
                        i = gridView1.RowCount - 1;
                    }

                    gridView1.SetRowCellValue(i, gridCol物料编码, dtnew.Rows[s]["cInvCode"].ToString());
                    gridView1.SetRowCellValue(i, gridColM1, dtnew.Rows[s]["M1"].ToString());
                    gridView1.SetRowCellValue(i, gridColM2, dtnew.Rows[s]["M2"].ToString());

                    if (cRsCode != "1102")
                    {
                        gridView1.SetRowCellValue(i, gridCol盒数, dtnew.Rows[s]["sBoxQty"].ToString());
                        gridView1.SetRowCellValue(i, gridCol每盒重量, dtnew.Rows[s]["D2"].ToString());
                        gridView1.SetRowCellValue(i, gridCol每盒含税价格, dtnew.Rows[s]["D1"].ToString());
                    }
                    else
                    {
                        gridView1.SetRowCellValue(i, gridCol数量, dtnew.Rows[s]["iQuantity"].ToString());
                        gridView1.SetRowCellValue(i, gridCol含税单价, dtnew.Rows[s]["iUnitPrice"].ToString());
                        gridView1.SetRowCellValue(i, gridCol含税金额, ReturnDecimal(dtnew.Rows[s]["iQuantity"].ToString()) * ReturnDecimal(dtnew.Rows[s]["iUnitPrice"].ToString()));
                    }
                    if (dtnew.Rows[s]["RdAutoID"].ToString() != "")
                    {
                        gridView1.SetRowCellValue(i, gridColRdAutoID, dtnew.Rows[s]["RdAutoID"].ToString());
                    }
                    gridView1.SetRowCellValue(i, gridColSoAutoID, dtnew.Rows[s]["AutoID"].ToString());
                    gridView1.SetRowCellValue(i, gridColcPosCode, dtnew.Rows[s]["cPosCode"].ToString());
                }
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
            sState = "add";
            GetNull();
            GetShow(true);
            dateEdit单据日期.EditValue = 系统服务.ClsBaseDataInfo.sLogDate;

            int iFocRow = gridView1.FocusedRowHandle;

            sSQL = "select a.*,i.cInvName,i.cInvStd, 'edit' as iSave,iQuantity as 历史数量  from " + tablenames + " a left join  Inventory i on a.cInvCode=i.cInvCode "
                    + " left join ComputationUnitGroup g on i.cGroupCode=g.cGroupCode where 1=-1";
            dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dtBingGrid;

            if (this.Text.IndexOf("半成品") > -1)
            {
                lookUpEdit仓库.EditValue = "04";
            }
            else if (this.Text.IndexOf("期初") > -1)
            {
                lookUpEdit仓库.EditValue = "04";
            }
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
            radioGroup蓝红标识.EditValue = "";
            btnAddRow();
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
            else if (textEdit审核人.EditValue.ToString().Trim() != "")
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
                //string sErr = "";

                //aList = new System.Collections.ArrayList();
                //string delstr = "";
                //for (int i = 0; i < gridView1.RowCount; i++)
                //{
                //    if (gridView1.GetRowCellDisplayText(i, gridColAutoID).Trim() != "")
                //    {
                //        //clsPublic.ReturnNow(1, gridView1.GetRowCellValue(i, gridCol物料编码).ToString().Trim(), lookUpEdit仓库.EditValue.ToString().Trim(), gridView1.GetRowCellValue(i, gridColcPosCode).ToString().Trim()
                //        //, "", "", gridView1.GetRowCellValue(i, gridColRdAutoID).ToString().Trim()
                //        //, gridView1.GetRowCellValue(i, gridColM1).ToString().Trim(), gridView1.GetRowCellValue(i, gridColM2).ToString().Trim(), "", "", ""
                //        //, "", "", "", "", ""
                //        WriteOrder(gridView1.GetRowCellDisplayText(i, gridColAutoID).Trim(), aList);
                //    }
                //}

                //sSQL = "delete from " + tablename + " where ID='" + textEditID.EditValue.ToString().Trim() + "'";
                //aList.Add(sSQL);
                //sSQL = "delete from " + tablenames + " where ID='" + textEditID.EditValue.ToString().Trim() + "'";
                //aList.Add(sSQL);

                sSQL = @"delete RdRecords11 where ID = 111111
                delete RdRecord11 where ID = 111111";
                sSQL = sSQL.Replace("111111", textEditID.EditValue.ToString());
                aList.Add(sSQL);

                sSQL = "select RdAutoID,SoAutoID from " + tablenames + " where ID=" + textEditID.EditValue.ToString();
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string RdAutoID = dt.Rows[i]["RdAutoID"].ToString();
                    if (RdAutoID != "")
                    {
                        aList.Add(clsPublic.ReturnWriteRdAutoID(RdAutoID));
                    }

                    string SoAutoID = dt.Rows[i]["SoAutoID"].ToString();
                    if (SoAutoID != "")
                    {
                        aList.Add(clsPublic.ReturnWriteSoAutoID(SoAutoID));
                    }
                }

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

            sSQL = "select * from " + tablename + " where 1=-1";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            sSQL = "select * from " + tablenames + " where 1=-1";
            DataTable dts = clsSQLCommond.ExecQuery(sSQL);
            string sErr = "";

            if (lookUpEdit客户.EditValue == null || lookUpEdit客户.EditValue.ToString().Trim() == "")
            {
                throw new Exception("客户不能为空");
            }

            sSQL = "select NotDelivery from Customer where cCusCode='" + lookUpEdit客户.EditValue + "'";
            DataTable dtcus = clsSQLCommond.ExecQuery(sSQL);
            if (dtcus.Rows.Count > 0 && dtcus.Rows[0]["NotDelivery"].ToString().Trim() == "True")
            {
                throw new Exception("已限制出库，请与财务联系");
            }

            if (radioGroup蓝红标识.EditValue == null || radioGroup蓝红标识.EditValue.ToString().Trim() == "")
            {
                sErr = sErr + "蓝红标识不能为空\n";
            }
            if (buttonEdit部门.EditValue == null || buttonEdit部门.EditValue.ToString().Trim() == "")
            {
                sErr = sErr + "部门不能为空\n";
            }
            if (dateEdit单据日期.EditValue == null || dateEdit单据日期.EditValue.ToString().Trim() == "")
            {
                sErr = sErr + "单据日期不能为空\n";
            }
            if (lookUpEdit仓库.EditValue == null || lookUpEdit仓库.Text.Trim() == "")
            {
                throw new Exception("仓库不能为空");
            }
            if (lookUpEdit出入库类别.EditValue.ToString().Trim() == "16")
            {
                if (lookUpEdit客户.EditValue == null || lookUpEdit客户.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("客户不能为空");
                }
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
            
            //drh["SoID"] = lookUpEdit销售订单号.EditValue.ToString().Trim();
            //drh["SoAutoID"] = lookUpEdit销售订单AutoID.EditValue.ToString().Trim();

            drh["Flag"] = radioGroup蓝红标识.EditValue.ToString().Trim();

            drh["cMemo"] = textEdit备注.EditValue.ToString().Trim();
            drh["UpdateDate"] = DateTime.Now.ToString();
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
                drh["dChangeVerifyTime"] = DateTime.Now;
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
                clsPublic.GetChange(tablename, tablenames, textEditID.EditValue.ToString().Trim(), clsGetSQL, aList);
            }
            #endregion

            #region 删行
            string strDelRdAutoID = "";
            string strDelMosID = "";
            if (textEditDel.EditValue != null && textEditDel.EditValue.ToString().Trim() != "")
            {
                string[] split = textEditDel.EditValue.ToString().Trim().Split(',');
                for (int i = 0; i < split.Length; i++)
                {
                    sSQL = "select RdAutoID from " + tablenames + " where AutoID=" + split[i];
                    string RdAutoID = clsSQLCommond.ExecGetScalar(sSQL).ToString();
                    if (strDelRdAutoID != "")
                    {
                        strDelRdAutoID = strDelRdAutoID + ",";
                    }
                    strDelRdAutoID = strDelRdAutoID + RdAutoID;

                    sSQL = "select isnull(MosID,-1) as MosID from " + tablenames + " where AutoID=" + split[i];
                    string MosID = clsSQLCommond.ExecGetScalar(sSQL).ToString();
                    if (MosID != "")
                    {
                        if (strDelMosID != "")
                        {
                            strDelMosID = strDelMosID + ",";
                        }
                        strDelMosID = strDelMosID + RdAutoID;
                    }
                }

                clsPublic.ReturnNow(textEditDel.EditValue.ToString().Trim(), aList);
                clsPublic.GetChangeDelRow(tablenames, textEditDel.EditValue.ToString().Trim(), aList);

                WriteOrder(textEditDel.EditValue.ToString().Trim(), aList);
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

                    if (radioGroup蓝红标识.EditValue.ToString().Trim() == "1")
                    {
                        if (cRsCode != "1101")
                        {
                            if (gridView1.GetRowCellValue(i, gridColRdAutoID).ToString().Trim() == "")
                            {
                                sErr = sErr + "行" + (i + 1) + "请选择入库单号\n";
                                continue;
                            }
                        }
                    }

                    if (gridView1.GetRowCellValue(i, gridCol数量).ToString().Trim() == "")
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

                    if (radioGroup蓝红标识.EditValue.ToString().Trim() == "1" && cRsCode == "1101")
                    {
                        decimal 库存数量 = clsPublic.Get期初现存量(gridView1.GetRowCellValue(i, gridCol物料编码).ToString().Trim(), gridView1.GetRowCellValue(i, gridColM1).ToString().Trim(), gridView1.GetRowCellValue(i, gridColM2).ToString().Trim());
                        decimal 盒数=ReturnDecimal(gridView1.GetRowCellValue(i, gridCol盒数).ToString().Trim());
                        decimal 本行数量 = 0;
                        if (gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim() != "")
                        {
                            sSQL = "select sBoxQty from " + tablenames + " with(nolock) where AutoID=" + gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim();
                            本行数量 = Convert.ToDecimal(clsSQLCommond.ExecGetScalar(sSQL));
                        }
                        if (库存数量 + 本行数量 < 盒数)
                        {
                            sErr = sErr + "行" + (i + 1) + "现存数量不足\n";
                            continue;
                        }
                    }
                    
                    #endregion

                    #region 生成table
                    DataRow dr = dts.NewRow();
                    if (gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim() == "")
                    {
                        long sAutoID = clsPublic.GetMaxID("RDS");
                        dr["AutoID"] = sAutoID;
                    }
                    else
                    {
                        dr["AutoID"] = gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim();
                    }
                    
                    dr["ID"] = iID;
                    dr["cRDCode"] = textEdit单据号.EditValue.ToString().Trim();
                    dr["iRowNo"] = gridView1.GetRowCellValue(i, gridCol序号).ToString().Trim();
                    dr["cInvCode"] = gridView1.GetRowCellValue(i, gridCol物料编码).ToString().Trim();
                    dr["iQuantity"] = gridView1.GetRowCellValue(i, gridCol数量).ToString().Trim();
                    dr["M1"] = gridView1.GetRowCellValue(i, gridColM1).ToString().Trim();
                    dr["M2"] = gridView1.GetRowCellValue(i, gridColM2).ToString().Trim();
                    if (cRsCode != "1102")
                    {
                        dr["sBoxQty"] = gridView1.GetRowCellValue(i, gridCol盒数).ToString().Trim();
                        dr["D1"] = gridView1.GetRowCellValue(i, gridCol每盒含税价格).ToString().Trim();
                        dr["D2"] = gridView1.GetRowCellValue(i, gridCol每盒重量).ToString().Trim();
                    }
                    else
                    {
                        dr["sBoxQty"] = 0;
                        dr["D1"] = 0;
                        dr["D2"] = 0;
                        
                    }
                    dr["BoxNo"] = gridView1.GetRowCellValue(i, gridCol箱号).ToString().Trim();
                    

                    dr["SoAutoID"] = gridView1.GetRowCellValue(i, gridColSoAutoID).ToString().Trim();
                    dr["cPosCode"] = gridView1.GetRowCellValue(i, gridColcPosCode).ToString().Trim();
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
                    if (gridView1.GetRowCellValue(i, gridColRdAutoID).ToString().Trim() != "")
                    {
                        dr["RdAutoID"] = gridView1.GetRowCellValue(i, gridColRdAutoID).ToString().Trim();
                    }
                    dr["cMemo"] = gridView1.GetRowCellValue(i, gridCol备注).ToString().Trim();
                    dr["UpdateDate"] = DateTime.Now.ToString();
                    //dr["cClosesysPerson"] = gridView1.GetRowCellValue(i, gridCol行关闭人).ToString().Trim();
                    //dr["cClosesysTime"] = gridView1.GetRowCellValue(i, gridCol行关闭日期).ToString().Trim();

                    dts.Rows.Add(dr);
                    ////sID = sID + 1;
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

                    clsPublic.ReturnNow(1, gridView1.GetRowCellValue(i, gridCol物料编码).ToString().Trim(), lookUpEdit仓库.EditValue.ToString().Trim(), gridView1.GetRowCellValue(i, gridColcPosCode).ToString().Trim()
                        , "", "", gridView1.GetRowCellValue(i, gridColRdAutoID).ToString().Trim()
                        , gridView1.GetRowCellValue(i, gridColM1).ToString().Trim(), gridView1.GetRowCellValue(i, gridColM2).ToString().Trim(), "", "", ""
                        , "", "", "", "", ""
                        , ReturnDecimal(gridView1.GetRowCellValue(i, gridCol历史数量).ToString().Trim(), 6), 0, 0, ReturnDecimal(gridView1.GetRowCellValue(i, gridCol数量).ToString().Trim(), 6), 0, ReturnInt(gridView1.GetRowCellValue(i, gridCol盒数).ToString().Trim()), aList);

                    WriteOrder(gridView1.GetRowCellValue(i, gridColRdAutoID).ToString().Trim(),gridView1.GetRowCellValue(i, gridColSoAutoID).ToString().Trim()
                        , ReturnDecimal(gridView1.GetRowCellValue(i, gridCol历史数量).ToString().Trim(), 6), 0, 0, ReturnDecimal(gridView1.GetRowCellValue(i, gridCol数量).ToString().Trim(), 6), 0, ReturnInt(gridView1.GetRowCellValue(i, gridCol盒数).ToString().Trim()), aList);

                }
                else
                {
                    if (gridView1.GetRowCellDisplayText(i, gridCol物料编码).ToString().Trim() != "")
                    {
                        if (gridView1.GetRowCellValue(i, gridCol数量).ToString().Trim() != "")
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
                        else
                        {
                            sErr = sErr + "行" + (i + 1) + gridCol数量.Caption + "不能为空\n";
                            continue;
                        }
                    }
                }
            }
            #endregion

            #region 单据反写
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string RdAutoID = gridView1.GetRowCellValue(i, gridColRdAutoID).ToString().Trim();
                if (RdAutoID != "")
                {
                    aList.Add(clsPublic.ReturnWriteRdAutoID(RdAutoID));
                }

                string MosID = gridView1.GetRowCellValue(i, gridColSoAutoID).ToString().Trim();
                if (MosID != "")
                {
                    aList.Add(clsPublic.ReturnWriteMosID(MosID));
                }
            }

            string[] splstrDelAutoID = strDelRdAutoID.Split(',');
            for (int i = 0; i < splstrDelAutoID.Length; i++)
            {
                string RdAutoID = splstrDelAutoID[i];
                if (RdAutoID != "")
                {
                    aList.Add(clsPublic.ReturnWriteRdAutoID(RdAutoID));
                }
            }

            string[] splitstrDelMosID = strDelMosID.Split(',');
            for (int i = 0; i < splitstrDelMosID.Length; i++)
            {
                string MosID = splitstrDelMosID[i];
                if (MosID != "")
                {
                    aList.Add(clsPublic.ReturnWriteSoAutoID(MosID));
                }
            }
            #endregion

            if (sErr != "")
            {
                throw new Exception(sErr);
            }

            if (dt == null || dt.Rows.Count <= 0)
            {
                throw new Exception("表头不能为空");
            }
            #region 表体不能为空
            bool b列表 = false;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridCol物料编码).ToString().Trim() != "")
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
                if (gridView1.GetRowCellValue(i, gridCol物料编码).ToString().Trim() != "")
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

            sSQL = "select NotDelivery from Customer where cCusCode='" + lookUpEdit客户.EditValue + "'";
            DataTable dtcus = clsSQLCommond.ExecQuery(sSQL);
            if (dtcus.Rows.Count > 0 && dtcus.Rows[0]["NotDelivery"].ToString().Trim() == "True")
            {
                throw new Exception("已限制出库，请与财务联系");
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

            int iUsed = iCodeUsed(textEdit单据号.Text.Trim());
            if (iUsed > 0)
            {
                throw new Exception("单据已引用");
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

        private void Frm销售出库单2_Load(object sender, EventArgs e)
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
            if (title.IndexOf("半成品") > -1)
            {
                gridCol盒数.Visible = false;
                gridCol箱号.Visible = false;
                gridCol盒数.Visible = false;
                gridCol每盒含税价格.Visible = false;
                gridCol每盒重量.Visible = false;
                cRsCode = "1102";
            }
            else if (title.IndexOf("期初") > -1)
            {
                cRsCode = "1101";
                gridColRdAutoID.Visible = false;
                gridCol选择入库单.Visible = false;
            }
            lookUpEdit出入库类别.EditValue = cRsCode;
        }

        private void GetGrid()
        {
            if (iID != -1)
            {
                sSQL = @"select a.*,u1.vchrName as 制单人,u2.vchrName as 审核人,d.cDepName,c.cCusName ,p.PersonName,
b.iQuantity,b.sBoxQty,b.iMoney,b.iQuantity as 历史数量,
convert(varchar(10),dCreatesysTime,120) as 制单日期,convert(varchar(10),dVerifysysTime,120) as 审核日期,convert(varchar(10),dDate,120) as 单据日期,a.cRDCode as 单据号,c.cDCCode,dc.cDCName  from " + tablename + " a left join RdStyle r on a.cRSCode=r.cRSCode "
                + @"left join _UserInfo u1 on a.dCreatesysPerson=u1.vchrUid left join _UserInfo u2 on a.dVerifysysPerson=u2.vchrUid 
left join Department d on a.cDepCode=d.cDepCode left join Customer c on a.cCusCode=c.cCusCode left join DistrictClass dc on c.cDCCode=dc.cDCCode left join Person p on a.cPersonCode=p.PersonCode 
left join (select ID,sum(iQuantity) as iQuantity,sum(sBoxQty) as sBoxQty ,sum(iMoney) as iMoney from " + tablenames + " group by ID) b on a.ID=b.ID "
 + @"where 收发标志='1' and a.cRSCode='" + cRsCode + "' and a.ID=" + iID;
                 dth = clsSQLCommond.ExecQuery(sSQL);
                if (dth.Rows.Count > 0)
                {
                    textEditID.EditValue = Convert.ToInt64(dth.Rows[0]["ID"]);
                    textEdit单据号.EditValue = dth.Rows[0]["cRDCode"].ToString();
                    lookUpEdit区域.EditValue = dth.Rows[0]["cDCCode"].ToString();

                    dateEdit单据日期.EditValue = dth.Rows[0]["dDate"].ToString();
                    dateEdit制单日期.EditValue = dth.Rows[0]["dCreatesysTime"].ToString();
                    dateEdit审核日期.EditValue = dth.Rows[0]["dVerifysysTime"].ToString();
                    dateEdit关闭日期.EditValue = dth.Rows[0]["dClosesysTime"].ToString();

                    textEdit备注.EditValue = dth.Rows[0]["cMemo"].ToString();
                    textEdit制单人.EditValue = dth.Rows[0]["dCreatesysPerson"].ToString();
                    textEdit审核人.EditValue = dth.Rows[0]["dVerifysysPerson"].ToString();
                    textEdit关闭人.EditValue = dth.Rows[0]["dClosesysPerson"].ToString();

                    buttonEdit业务员.EditValue = dth.Rows[0]["cPersonCode"].ToString();
                    buttonEdit操作人.EditValue = dth.Rows[0]["cOperator"].ToString();
                    lookUpEdit仓库.EditValue = dth.Rows[0]["cWhCode"].ToString();
                    buttonEdit部门.EditValue = dth.Rows[0]["cDepCode"].ToString();

                    radioGroup蓝红标识.EditValue = dth.Rows[0]["Flag"].ToString();

                    buttonEdit客户.EditValue = dth.Rows[0]["cCusCode"].ToString();
                    lookUpEdit出入库类别.EditValue = dth.Rows[0]["cRSCode"].ToString().Trim();

                    buttonEdit部门.Enabled = false;

                    textEdit打印次数.EditValue = dth.Rows[0]["PrintCount"].ToString();

                    sSQL = "select a.*,i.cInvName,i.cInvStd, 'edit' as iSave,a.iQuantity as 历史数量  from " + tablenames + " a left join  Inventory i on a.cInvCode=i.cInvCode "
                    + " left join ComputationUnitGroup g on i.cGroupCode=g.cGroupCode where ID=" + iID;

                    

                    dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
                    gridControl1.DataSource = dtBingGrid;

                    gridView1.FocusedRowHandle = iFocRow;
                    gridView1.AddNewRow();

                    if (cRsCode != "1102")
                    {
                        sSQL = "select a.cInvCode,i.cInvName,sum(a.iQuantity) as iQuantity,sum(a.sBoxQty) as sBoxQty,sum(iMoney) as iMoney,sum(iMoney)/sum(a.sBoxQty) as iUnitPrice,sum(iMoney)/sum(a.iQuantity) as iUnitPriceQty from " + tablenames + " a left join Inventory i on a.cInvCode=i.cInvCode where ID=" + iID + " group by a.cInvCode,i.cInvName order by a.cInvCode";
                       
                    }
                    else
                    {
                        sSQL = "select a.cInvCode,i.cInvName,sum(a.iQuantity) as iQuantity,sum(a.sBoxQty) as sBoxQty,sum(iMoney) as iMoney,sum(iMoney)/sum(a.iQuantity) as iUnitPriceQty from " + tablenames + " a left join Inventory i on a.cInvCode=i.cInvCode where ID=" + iID + " group by a.cInvCode,i.cInvName order by a.cInvCode";
                        
                    }
                    DataTable dtGroup = clsSQLCommond.ExecQuery(sSQL);
                    
                    if (cRsCode == "1101")
                    {
                        //汇总
                        sPrintLayOutMod = sProPath + "\\print\\Model\\销售出库单Mod.dll";
                        sPrintLayOutUser = sProPath + "\\print\\User\\销售出库单User.dll";

                        //明细
                        sPrintLayOutMod2 = sProPath + "\\print\\Model\\销售出库单Mod2.dll";
                        sPrintLayOutUser2 = sProPath + "\\print\\User\\销售出库单User2.dll";

                    }
                    else if (cRsCode == "1102")
                    {
                        //汇总
                        sPrintLayOutMod = sProPath + "\\print\\Model\\销售出库单Mod_1.dll";
                        sPrintLayOutUser = sProPath + "\\print\\User\\销售出库单User_1.dll";

                        //明细
                        sPrintLayOutMod2 = sProPath + "\\print\\Model\\销售出库单Mod2_1.dll";
                        sPrintLayOutUser2 = sProPath + "\\print\\User\\销售出库单User2_1.dll";
                    }
                    
                    base.dsPrint.Tables.Clear();
                    base.dsPrint.Tables.Add(dth.Copy());
                    base.dsPrint.Tables[0].TableName = "dtHead";
                    base.dsPrint.Tables.Add(dtBingGrid.Copy());
                    base.dsPrint.Tables[1].TableName = "dtGrid";

                    base.dsPrint2.Tables.Clear();
                    base.dsPrint2.Tables.Add(dth.Copy());
                    base.dsPrint2.Tables[0].TableName = "dtHead";
                    base.dsPrint2.Tables.Add(dtGroup.Copy());
                    base.dsPrint2.Tables[1].TableName = "dtGrid";

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
            系统服务.LookUp.RdStyle(lookUpEdit出入库类别,1,"'1101','1102'");
            
            系统服务.LookUp.Department(lookUpEdit部门);
            系统服务.LookUp.Person(lookUpEdit业务员);
            系统服务.LookUp.Person(lookUpEdit操作人);
            系统服务.LookUp.Customer(lookUpEdit客户);
            系统服务.LookUp.DistrictClass(lookUpEdit区域);

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

            radioGroup蓝红标识.Enabled = b;

            buttonEdit客户.Enabled = b;

            //lookUpEdit销售订单号.Enabled = b;
            //lookUpEdit销售订单AutoID.Enabled = b;

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
            //lookUpEdit出入库类别.EditValue = "14";
            lookUpEdit仓库.EditValue = "02";
            


            //lookUpEdit销售订单号.EditValue = "";
            //lookUpEdit销售订单AutoID.EditValue = "";

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

                if (e.Column == gridCol物料编码 || e.Column == gridCol物料名称 || e.Column == gridCol规格型号)
                {
                    string invocde = gridView1.GetRowCellValue(iRow, gridCol物料编码).ToString().Trim();
                    if (e.Column == gridCol物料编码)
                    {
                        sSQL = "select * from Inventory where cInvCode='" + invocde + "'";
                        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                        if (dt.Rows.Count > 0)
                        {
                            gridView1.SetRowCellValue(iRow, gridCol规格型号, dt.Rows[0]["cInvStd"]);
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

                if (cRsCode == "1102")
                {
                    if (e.Column == gridCol数量 || e.Column == gridCol含税单价)
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
                                decimal s件数 = ReturnDecimal(数量 * 换算率);
                                if (s件数 != 件数)
                                {
                                    gridView1.SetRowCellValue(iRow, gridCol件数, s件数);
                                }
                            }
                            else
                            {
                                gridView1.SetRowCellValue(iRow, gridCol件数, null);
                            }
                        }

                        无税单价 = ReturnDecimal(含税单价 / (1 + 税率));
                        含税金额 = ReturnDecimal(含税单价 * 数量);
                        无税金额 = ReturnDecimal(无税单价 * 数量);
                        税额 = 含税金额 - 无税金额;

                        if (无税金额 != ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol无税单价)))
                        {
                            gridView1.SetRowCellValue(iRow, gridCol无税单价, 无税单价);
                            gridView1.SetRowCellValue(iRow, gridCol无税金额, 无税金额);
                        }

                        if (ReturnDecimal(含税金额, 2) != ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol含税金额), 2))
                        {
                            //gridView1.SetRowCellValue(iRow, gridCol含税单价, 含税单价);
                            gridView1.SetRowCellValue(iRow, gridCol含税金额, 含税金额);
                        }
                        gridView1.SetRowCellValue(iRow, gridCol税额, 税额);

                        #endregion
                    }
                }
                else
                {
                    if (e.Column == gridCol每盒含税价格 || e.Column == gridCol盒数 || e.Column == gridCol每盒重量)
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
                        decimal 每盒含税价格 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol每盒含税价格));
                        decimal 每盒重量 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol每盒重量));
                        decimal 盒数 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol盒数));


                        #region 计算
                        if (e.Column == gridCol数量)
                        {
                            if (换算率 != 0)
                            {
                                decimal s件数 = ReturnDecimal(数量 * 换算率);
                                if (s件数 != 件数)
                                {
                                    gridView1.SetRowCellValue(iRow, gridCol件数, s件数);
                                }
                            }
                            else
                            {
                                gridView1.SetRowCellValue(iRow, gridCol件数, null);
                            }
                        }
                        if (e.Column == gridCol数量)
                        {
                            if (换算率 != 0)
                            {
                                decimal s件数 = ReturnDecimal(数量 * 换算率);
                                if (s件数 != 件数)
                                {
                                    gridView1.SetRowCellValue(iRow, gridCol件数, s件数);
                                }
                            }
                            else
                            {
                                gridView1.SetRowCellValue(iRow, gridCol件数, null);
                            }
                        }

                        数量 = 盒数 * 每盒重量;
                        if (每盒重量 != 0)
                        {
                            含税单价 = 每盒含税价格 / 每盒重量;
                        }

                        无税单价 = ReturnDecimal(含税单价 / (1 + 税率));
                        含税金额 = ReturnDecimal(含税单价 * 数量);
                        无税金额 = ReturnDecimal(无税单价 * 数量);
                        税额 = 含税金额 - 无税金额;

                        gridView1.SetRowCellValue(iRow, gridCol数量, 数量);
                        gridView1.SetRowCellValue(iRow, gridCol无税单价, 无税单价);
                        gridView1.SetRowCellValue(iRow, gridCol无税金额, 无税金额);
                        gridView1.SetRowCellValue(iRow, gridCol含税单价, 含税单价);
                        gridView1.SetRowCellValue(iRow, gridCol含税金额, 含税金额);
                        gridView1.SetRowCellValue(iRow, gridCol税额, 税额);

                        if (e.Column == gridCol含税金额 && 数量 != 0)
                        {
                            含税单价 = ReturnDecimal(含税金额 / 数量);
                        }


                        #endregion
                    }
                }
                #region
                if (e.Column != gridColiSave && e.Column != gridCol序号 && gridView1.GetRowCellDisplayText(iRow, gridColiSave).ToString().Trim() == "")
                {
                    gridView1.SetRowCellValue(iRow, gridColiSave, "add");
                }
                if (e.Column != gridColiSave && e.Column != gridCol序号 && gridView1.GetRowCellDisplayText(iRow, gridColiSave).ToString().Trim() == "edit")
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

        private void gridView1_CustomDrawRowIndicator_1(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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
            {
                lookUpEdit客户.EditValue = buttonEdit客户.Text.Trim();
                sSQL = "select * from Customer where cCusCode='" + lookUpEdit客户.EditValue + "'";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    lookUpEdit区域.EditValue = dt.Rows[0]["cDCCode"].ToString();
                }
            }
            else
            {
                lookUpEdit客户.EditValue = null;
                lookUpEdit区域.EditValue = null;
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

        private void lookUpEdit客户_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit客户.Text.Trim() != "")
            {
                lookUpEdit客户.EditValue = buttonEdit客户.Text.Trim();
                if (lookUpEdit客户.Text.Trim() != "")
                {
                    DataTable dt = 系统服务.LookUp.CustomercCusPPerson(buttonEdit客户.Text.Trim());
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        buttonEdit业务员.EditValue = dt.Rows[0]["cCusPPerson"];
                    }
                }
            }
            else
            {
                buttonEdit客户.EditValue = null;
                lookUpEdit业务员.EditValue = null;
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
        /// <param name="sCode">单据号</param>
        /// <returns></returns>
        private int iCodeUsed(string sCode)
        {
            int iReturn = -1;
            try
            {
                sSQL = @"select count(1) from dbo.RdRecord a inner join dbo.RdRecords b on a.ID = b.ID 
                inner join (select RdAutoID,sum(iQuantity) as iQuantity from RdRecord group by RdAutoID) c 
                on c.RdAutoID = b.AutoID where a.cRDCode = '" + sCode + "'";
                int iReturn1 = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));

                sSQL = "select count(1) from XWSystemDB_JSL_" + lookUpEdit客户.EditValue.ToString().Trim() + ".dbo.CustomerRdRecord " +
                       "where cRDCode = '" + sCode + "'";
                int iReturn2 = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));

                if (iReturn1 > iReturn2)
                    iReturn = iReturn1;
                else
                    iReturn = iReturn2;

                return iReturn;
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
        private decimal iCodeUsed(long AutoID)
        {
            decimal iReturn = -1;
            try
            {
                sSQL = @"select -isnull(sum(b.iQuantity),0) as iQty from dbo.RdRecord a inner join dbo.RdRecords b on a.ID = b.ID 
                 where b.RdAutoID = '" + AutoID + "'";
                decimal iReturn1 = ReturnDecimal(clsSQLCommond.ExecGetScalar(sSQL));
                if (iReturn1 > iReturn && iReturn1 > 0)
                    iReturn = iReturn1;

                sSQL = "select isnull(sum(c.iQuantity),0) as iQty from XWSystemDB_JSL_" + lookUpEdit客户.EditValue.ToString().Trim() + ".dbo.CustomerRdRecords " +
                       "where jslAutoID = '" + AutoID + "'";
                decimal iReturn2 = ReturnDecimal(clsSQLCommond.ExecGetScalar(sSQL));
                if (iReturn2 > iReturn && iReturn2 > 0)
                    iReturn = iReturn2;

                //sSQL = "select isnull(sum(c.iQuantity),0) as iQty from dbo.MO_MOMain a inner join dbo.MO_MODetails b on a.ID = b.ID inner join dbo.SO_CloseBillDetails c on c.SoAutoID = b.AutoID " +
                //       "where b.AutoID = '" + AutoID + "'";
                //decimal iReturn3 = ReturnDecimal(clsSQLCommond.ExecGetScalar(sSQL));

                //if (iReturn3 > iReturn && iReturn3 > 0)
                //    iReturn = iReturn3;
                return iReturn;
            }
            catch (Exception ee)
            { }
            return iReturn;
        }

        //保存订单时反写
        public void WriteOrder(string RdAutoID, string SoAutoID
            , decimal HistoryQty, decimal HistoryNum, decimal HistorysBoxQty
            , decimal iQuantity, decimal iNum, int sBoxQty, System.Collections.ArrayList aList)
        {
            decimal NowQty = iQuantity - HistoryQty;
            decimal NowNum = iNum - HistoryNum;
            decimal NowsBoxQty = sBoxQty - HistorysBoxQty;
            if (radioGroup蓝红标识.EditValue.ToString().Trim() == "0")
            {
                NowQty = -NowQty;
                NowNum = -NowNum;
                NowsBoxQty = -NowsBoxQty;
            }
            //反写销售订单
            sSQL = @"update SO_SODetails set iOutQuantity = isnull(iOutQuantity,0) + " + iQuantity + ",iOutNum = isnull(iOutNum,0) + " + iNum + ",sOutBoxQty = isnull(sOutBoxQty,0) + " + sBoxQty + " where AutoID = " + SoAutoID;
            aList.Add(sSQL);
            //反写入库单
            sSQL = @"update RdRecords01 set iOutQuantity = isnull(iOutQuantity,0) + " + iQuantity + ",iOutNum = isnull(iOutNum,0) + " + iNum + " where AutoID = '" + RdAutoID + "'";
            aList.Add(sSQL);
            sSQL = @"update RdRecords02 set iOutQuantity = isnull(iOutQuantity,0) + " + iQuantity + ",iOutNum = isnull(iOutNum,0) + " + iNum + " where AutoID = '" + RdAutoID + "'";
            aList.Add(sSQL);
            sSQL = @"update RdRecords05 set iOutQuantity = isnull(iOutQuantity,0) + " + iQuantity + ",iOutNum = isnull(iOutNum,0) + " + iNum + ",sOutBoxQty = isnull(sOutBoxQty,0) + " + sBoxQty + " where AutoID = '" + RdAutoID + "'";
            aList.Add(sSQL);
        }

        //删除单据时反写订单
        public void WriteOrder(string delStrs, System.Collections.ArrayList aList)
        {
            string[] delSplit = delStrs.Split(',');

            for (int i = 0; i < delSplit.Length; i++)
            {
                sSQL = "select iQuantity,iNum,sBoxQty,SoAutoID,cSOPSID,RdAutoID from RdRecords11 where AutoID=" + delSplit[i];
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    long SoAutoID = ReturnLong(dt.Rows[0]["SoAutoID"]);
                    int sBoxQty = ReturnInt(dt.Rows[0]["sBoxQty"]);
                    decimal iQuantity = ReturnDecimal(dt.Rows[0]["iQuantity"], 2);
                    decimal iNum = ReturnDecimal(dt.Rows[0]["iNum"], 2);
                    string RdAutoID = dt.Rows[0]["RdAutoID"].ToString();
                    //反写销售订单
                    sSQL = @"update SO_SODetails set iOutQuantity = isnull(iOutQuantity,0) - (" + iQuantity + "),iOutNum = isnull(iOutNum,0) - (" + iNum + "),sOutBoxQty = isnull(sOutBoxQty,0) - (" + sBoxQty + ") where AutoID = " + SoAutoID;
                    aList.Add(sSQL);
                    //反写入库单
                    sSQL = "update RdRecords01 set iOutQuantity=isnull(iOutQuantity,0) - (" + iQuantity + ") where AutoID='" + RdAutoID + "'";
                    aList.Add(sSQL);
                    sSQL = "update RdRecords02 set iOutQuantity=isnull(iOutQuantity,0) - (" + iQuantity + ") where AutoID='" + RdAutoID + "'";
                    aList.Add(sSQL);
                    sSQL = "update RdRecords05 set iOutQuantity=isnull(iOutQuantity,0) - (" + iQuantity + "),sOutBoxQty = isnull(sOutBoxQty,0) - (" + sBoxQty + ") where AutoID='" + RdAutoID + "'";
                    aList.Add(sSQL);
                }
                else
                {
                    throw new Exception("无法找到对应订单");
                }
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

        private void ItemButtonEditRdAutoID_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int iRow = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.IsRowSelected(i))
                {
                    iRow = i;
                }
            }
            string cInvCode = gridView1.GetRowCellValue(iRow, gridCol物料编码).ToString().Trim();
            string M1 = gridView1.GetRowCellValue(iRow, gridColM1).ToString().Trim();
            decimal iQuantity=clsPublic.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol数量).ToString().Trim());
            int itype = 1;
            if (cRsCode == "1101")//期初销售出库单
            {
                itype = 2;
            }
            系统服务.Frm库存_New frm = new 系统服务.Frm库存_New(itype, cInvCode, M1);
            if (DialogResult.OK == frm.ShowDialog())
            {

                if (frm.RdAutoID != "")
                {

                    gridView1.SetRowCellValue(iRow, gridColRdAutoID, frm.RdAutoID);
                    gridView1.SetRowCellValue(iRow, gridColM2, frm.M2);
                    gridView1.SetRowCellValue(iRow, gridColcPosCode, frm.cPosCode);
                    if (iQuantity > frm.iQty)
                    {
                        gridView1.SetRowCellValue(iRow, gridColcPosCode, frm.iQty);
                    }
                    frm.Enabled = true;
                }
            }
        }

      

    }
}
