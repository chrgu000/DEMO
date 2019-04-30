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
        string tablename = "RdRecord";
        string tableid = "cRDCode";
        string tablenames = "RdRecords";
        //string cRsCode = "01";

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

        public Frm其他入库单(long siID)
        {
            iID = siID;
            InitializeComponent();
            
        }

        public Frm其他入库单()
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
            string sSQL = "select * from " + tablename + " a left join " + tablenames + "  b on a.ID=b.ID left join RdStyle r on a.cRSCode=r.cRSCode where 收发标志='0' and a.cRSCode <> '01' ";
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
                sSQL = "select min(ID) as ID from " + tablename + " a left join RdStyle r on a.cRSCode=r.cRSCode where 收发标志='0' and a.cRSCode <> '01' ";
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
                    sSQL = "select ID from " + tablename + " a left join RdStyle r on a.cRSCode=r.cRSCode where ID<" + textEditID.Text + " and 收发标志='0' and a.cRSCode <> '01'  order by ID desc";
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
                    sSQL = "select ID from " + tablename + " a left join RdStyle r on a.cRSCode=r.cRSCode where ID>" + textEditID.Text + " and 收发标志='0' and a.cRSCode <> '01'  order by ID ";
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
                sSQL = "select isnull(max(ID),-1) as ID from " + tablename + " a left join RdStyle r on a.cRSCode=r.cRSCode  where 收发标志='0' and a.cRSCode <> '01'  ";
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

            sSQL = "select a.*,i.cInvName,i.cInvStd, 'edit' as iSave  from " + tablenames + " a left join  Inventory i on a.cInvCode=i.cInvCode "
                    + " left join ComputationUnitGroup g on i.cGroupCode=g.cGroupCode where 1=-1";
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
            string lb=lookUpEdit出入库类别.EditValue.ToString().Trim();
            if (lb == "05" || lb == "06" || lb == "07" || lb == "08" || lb == "09")
            {
                if (lookUpEdit出入库类别.EditValue.ToString().Trim() == "05" && (lookUpEdit销售类型.EditValue == null || lookUpEdit销售类型.EditValue.ToString().Trim() == ""))
                {
                    throw new Exception("销售类型不能为空");
                }
                if (lookUpEdit客户.EditValue == null || lookUpEdit客户.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("客户不能为空");
                }
                if (lb == "05" || lb == "06" || lb == "07")
                {
                    if (lookUpEdit相关期初.EditValue == null || lookUpEdit相关期初.EditValue.ToString().Trim() == "")
                    {
                        throw new Exception("相关期初必须选择");
                    }
                }
                if (lb == "08"||lb== "09")
                {
                    if (lookUpEdit相关销售订单.EditValue == null || lookUpEdit相关销售订单.EditValue.ToString().Trim() == "")
                    {
                        throw new Exception("相关期初销售订单必须选择");
                    }
                }
            }
            if (lookUpEdit销售类型.EditValue == null || lookUpEdit销售类型.EditValue.ToString().Trim() == "")
            {
                throw new Exception("销售类型不能为空");
            }

            if (lb == "05" || lb == "06" || lb == "07")
            {
                decimal 剩余金额 = 期初剩余金额();
                decimal 已用金额 = 0;
                for (int p = 0; p < gridView1.RowCount; p++)
                {
                    if (gridView1.GetRowCellValue(p, gridCol含税金额) != null)
                    {
                        已用金额 = 已用金额 + ReturnDecimal(gridView1.GetRowCellValue(p, gridCol含税金额));
                    }
                }
                if (已用金额 > 剩余金额)
                {
                    throw new Exception("总金额超过期初未用金额,期初未用金额为" + 剩余金额);
                }
            }
            else if(lb=="08")
            {
                decimal 剩余金额 = 销售订单剩余金额();
                decimal 已用金额 = 0;
                for (int p = 0; p < gridView1.RowCount; p++)
                {
                    if (gridView1.GetRowCellValue(p, gridCol含税金额) != null)
                    {
                        已用金额 = 已用金额 + ReturnDecimal(gridView1.GetRowCellValue(p, gridCol含税金额));
                    }
                }
                if (已用金额 > 剩余金额)
                {
                    throw new Exception("总金额超过销售订单未用金额,销售订单未用金额为" + 剩余金额);
                }
            }

            aList = new System.Collections.ArrayList();
            DataRow drh = dt.NewRow();
            if (sState == "add")
            {
                sSQL = "select isnull(isnull(max(ID),-1)+1,1) as ID from " + tablename;
                iID = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                drh["ID"] = iID;
                drh["cRDCode"] = 系统服务.序号.GetNewSerialNumberContinuous(tablename, tableid);
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
            drh["cWhCode"] = lookUpEdit仓库.EditValue.ToString().Trim();
            drh["cDepCode"] = buttonEdit部门.EditValue.ToString().Trim();
            drh["cRSCode"] = lookUpEdit出入库类别.EditValue.ToString().Trim();

            drh["cSTCode"] = lookUpEdit销售类型.EditValue.ToString().Trim();
            
            drh["cCusCode"] = buttonEdit客户.EditValue.ToString().Trim();

            drh["Flag"] = radioGroup蓝红标识.EditValue.ToString().Trim();

            drh["cMemo"] = textEdit备注.EditValue.ToString().Trim();

            if (lookUpEdit相关期初.EditValue != null && lookUpEdit相关期初.EditValue.ToString().Trim() != "")
            {
                drh["ARiID"] = lookUpEdit相关期初.EditValue.ToString().Trim();
            }
            if (lookUpEdit相关销售订单.EditValue != null && lookUpEdit相关销售订单.EditValue.ToString().Trim() != "")
            {
                drh["SoAutoID"] = lookUpEdit相关销售订单.EditValue.ToString().Trim();
            }

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
            sSQL = "select isnull(max(AutoID)+1,1) as AutoID from " + tablenames;
            long sID = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "update" || gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "add")
                {
                    #region 判断
                    if (gridView1.GetRowCellDisplayText(i, gridCol物料编码).ToString().Trim() == "")
                    {
                        continue;
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
                    

                    
                    #endregion

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
                    dr["cRDCode"] = textEdit单据号.EditValue.ToString().Trim();
                    dr["iRowNo"] = gridView1.GetRowCellValue(i, gridCol序号).ToString().Trim();
                    dr["cInvCode"] = gridView1.GetRowCellValue(i, gridCol物料编码).ToString().Trim();
                    dr["cInvStd"] = gridView1.GetRowCellValue(i, gridCol规格型号).ToString().Trim();
                    dr["iQuantity"] = gridView1.GetRowCellValue(i, gridCol数量).ToString().Trim();
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

                    if (gridView1.GetRowCellValue(i, gridCol子件编码1) != null && gridView1.GetRowCellValue(i, gridCol子件编码1).ToString().Trim() != "")
                    {
                        if (gridView1.GetRowCellValue(i, gridCol子件数量1) == null || gridView1.GetRowCellValue(i, gridCol子件数量1).ToString().Trim() == "")
                        {
                            sErr = sErr + "行" + (i + 1) + gridCol子件数量1.Caption + "必须填写\n";
                            continue;
                        }
                        if (gridView1.GetRowCellValue(i, gridCol子件单价1) == null || gridView1.GetRowCellValue(i, gridCol子件单价1).ToString().Trim() == "")
                        {
                            sErr = sErr + "行" + (i + 1) + gridCol子件单价1.Caption + "必须填写\n";
                            continue;
                        }
                        dr["S11"] = gridView1.GetRowCellValue(i, gridCol子件编码1).ToString().Trim();
                        dr["D11"] = gridView1.GetRowCellValue(i, gridCol子件数量1).ToString().Trim();
                        dr["D12"] = gridView1.GetRowCellValue(i, gridCol子件单价1).ToString().Trim();
                        dr["D13"] = gridView1.GetRowCellValue(i, gridCol子件金额1).ToString().Trim();
                    }

                    if (gridView1.GetRowCellValue(i, gridCol子件编码2) != null && gridView1.GetRowCellValue(i, gridCol子件编码2).ToString().Trim() != "")
                    {
                        if (gridView1.GetRowCellValue(i, gridCol子件数量2) == null || gridView1.GetRowCellValue(i, gridCol子件数量2).ToString().Trim() == "")
                        {
                            sErr = sErr + "行" + (i + 1) + gridCol子件数量2.Caption + "必须填写\n";
                            continue;
                        }
                        if (gridView1.GetRowCellValue(i, gridCol子件单价2) == null || gridView1.GetRowCellValue(i, gridCol子件单价2).ToString().Trim() == "")
                        {
                            sErr = sErr + "行" + (i + 1) + gridCol子件单价2.Caption + "必须填写\n";
                            continue;
                        }
                        dr["S12"] = gridView1.GetRowCellValue(i, gridCol子件编码2).ToString().Trim();
                        dr["D14"] = gridView1.GetRowCellValue(i, gridCol子件数量2).ToString().Trim();
                        dr["D15"] = gridView1.GetRowCellValue(i, gridCol子件单价2).ToString().Trim();
                        dr["D16"] = gridView1.GetRowCellValue(i, gridCol子件金额2).ToString().Trim();
                    }

                    if (gridView1.GetRowCellValue(i, gridCol子件编码3) != null && gridView1.GetRowCellValue(i, gridCol子件编码3).ToString().Trim() != "")
                    {
                        if (gridView1.GetRowCellValue(i, gridCol子件数量3) == null || gridView1.GetRowCellValue(i, gridCol子件数量3).ToString().Trim() == "")
                        {
                            sErr = sErr + "行" + (i + 1) + gridCol子件数量3.Caption + "必须填写\n";
                            continue;
                        }
                        if (gridView1.GetRowCellValue(i, gridCol子件单价3) == null || gridView1.GetRowCellValue(i, gridCol子件单价3).ToString().Trim() == "")
                        {
                            sErr = sErr + "行" + (i + 1) + gridCol子件单价3.Caption + "必须填写\n";
                            continue;
                        }
                        dr["S13"] = gridView1.GetRowCellValue(i, gridCol子件编码3).ToString().Trim();
                        dr["D17"] = gridView1.GetRowCellValue(i, gridCol子件数量3).ToString().Trim();
                        dr["D18"] = gridView1.GetRowCellValue(i, gridCol子件单价3).ToString().Trim();
                        dr["D19"] = gridView1.GetRowCellValue(i, gridCol子件金额3).ToString().Trim();
                    }

                    if (gridView1.GetRowCellValue(i, gridCol子件编码4) != null && gridView1.GetRowCellValue(i, gridCol子件编码4).ToString().Trim() != "")
                    {
                        if (gridView1.GetRowCellValue(i, gridCol子件数量4) == null || gridView1.GetRowCellValue(i, gridCol子件数量4).ToString().Trim() == "")
                        {
                            sErr = sErr + "行" + (i + 1) + gridCol子件数量4.Caption + "必须填写\n";
                            continue;
                        }
                        if (gridView1.GetRowCellValue(i, gridCol子件单价4) == null || gridView1.GetRowCellValue(i, gridCol子件单价4).ToString().Trim() == "")
                        {
                            sErr = sErr + "行" + (i + 1) + gridCol子件单价4.Caption + "必须填写\n";
                            continue;
                        }
                        dr["S14"] = gridView1.GetRowCellValue(i, gridCol子件编码4).ToString().Trim();
                        dr["D20"] = gridView1.GetRowCellValue(i, gridCol子件数量4).ToString().Trim();
                        dr["D21"] = gridView1.GetRowCellValue(i, gridCol子件单价4).ToString().Trim();
                        dr["D22"] = gridView1.GetRowCellValue(i, gridCol子件金额4).ToString().Trim();
                    }

                    if (gridView1.GetRowCellValue(i, gridCol子件编码5) != null && gridView1.GetRowCellValue(i, gridCol子件编码5).ToString().Trim() != "")
                    {
                        if (gridView1.GetRowCellValue(i, gridCol子件数量5) == null || gridView1.GetRowCellValue(i, gridCol子件数量5).ToString().Trim() == "")
                        {
                            sErr = sErr + "行" + (i + 1) + gridCol子件数量5.Caption + "必须填写\n";
                            continue;
                        }
                        if (gridView1.GetRowCellValue(i, gridCol子件单价5) == null || gridView1.GetRowCellValue(i, gridCol子件单价5).ToString().Trim() == "")
                        {
                            sErr = sErr + "行" + (i + 1) + gridCol子件单价5.Caption + "必须填写\n";
                            continue;
                        }
                        dr["S15"] = gridView1.GetRowCellValue(i, gridCol子件编码5).ToString().Trim();
                        dr["D23"] = gridView1.GetRowCellValue(i, gridCol子件数量5).ToString().Trim();
                        dr["D24"] = gridView1.GetRowCellValue(i, gridCol子件单价5).ToString().Trim();
                        dr["D25"] = gridView1.GetRowCellValue(i, gridCol子件金额5).ToString().Trim();
                    }

                    if (gridView1.GetRowCellValue(i, gridCol运行成本) != null && gridView1.GetRowCellValue(i, gridCol运行成本).ToString().Trim() != "")
                    {
                        dr["F1"] = gridView1.GetRowCellValue(i, gridCol运行成本).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol业务费用) != null && gridView1.GetRowCellValue(i, gridCol业务费用).ToString().Trim() != "")
                    {
                        dr["F2"] = gridView1.GetRowCellValue(i, gridCol业务费用).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol业务费用倍数) != null && gridView1.GetRowCellValue(i, gridCol业务费用倍数).ToString().Trim() != "")
                    {
                        dr["F3"] = gridView1.GetRowCellValue(i, gridCol业务费用倍数).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol利润分成) != null && gridView1.GetRowCellValue(i, gridCol利润分成).ToString().Trim() != "")
                    {
                        dr["F4"] = gridView1.GetRowCellValue(i, gridCol利润分成).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol利润) != null && gridView1.GetRowCellValue(i, gridCol利润).ToString().Trim() != "")
                    {
                        dr["F5"] = gridView1.GetRowCellValue(i, gridCol利润).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol个人利润) != null && gridView1.GetRowCellValue(i, gridCol个人利润).ToString().Trim() != "")
                    {
                        dr["F6"] = gridView1.GetRowCellValue(i, gridCol个人利润).ToString().Trim();
                    }

                    //dr["cClosesysPerson"] = gridView1.GetRowCellValue(i, gridCol行关闭人).ToString().Trim();
                    //dr["cClosesysTime"] = gridView1.GetRowCellValue(i, gridCol行关闭日期).ToString().Trim();

                    dts.Rows.Add(dr);
                    sID = sID + 1;
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
            #endregion
            if (sErr != "")
            {
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

                #region 判断是否已全部收款
                System.Collections.ArrayList aList1 = new System.Collections.ArrayList();
                if (lookUpEdit相关销售订单.EditValue != null)
                {
                    string SoAutoID = lookUpEdit相关销售订单.EditValue.ToString().Trim();
                    if (SoAutoID != "")
                    {
                        系统服务.收款利润.Get(SoAutoID, aList1);
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
                }
                #endregion
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

            sSQL = "update " + tablename + " set dVerifysysTime='" + 系统服务.ClsBaseDataInfo.sLogDate + "',dVerifysysPerson='" + 系统服务.ClsBaseDataInfo.sUid + "' where ID=" + textEditID.Text + "";
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
            sState = "alter";
            GetShow(true);
            GetShow();
        }

        #endregion

        private void Frm其他入库单_Load(object sender, EventArgs e)
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
                sSQL = "select * from " + tablename + " a left join RdStyle r on a.cRSCode=r.cRSCode  where 收发标志='0' and a.cRSCode <> '01'  and ID=" + iID;
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

                    lookUpEdit销售类型.EditValue = dt.Rows[0]["cSTCode"].ToString();
                    buttonEdit客户.EditValue = dt.Rows[0]["cCusCode"].ToString();
                    lookUpEdit出入库类别.EditValue = dt.Rows[0]["cRSCode"];

                    

                    GetShow();

                    lookUpEdit相关期初.EditValue = dt.Rows[0]["ARiID"];
                    lookUpEdit相关销售订单.EditValue = dt.Rows[0]["SoAutoID"];


                    sSQL = "select a.*,i.cInvName, 'edit' as iSave  from " + tablenames + " a left join  Inventory i on a.cInvCode=i.cInvCode "
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
            lookUpEdit仓库.Properties.DataSource = 系统服务.LookUp.Warehouse();
            ItemLookUpEditcInvName.Properties.DataSource = 系统服务.LookUp.Inventory();
            系统服务.LookUp.RdStyle(lookUpEdit出入库类别,0);
            系统服务.LookUp.Department(lookUpEdit部门);
            系统服务.LookUp.Person(lookUpEdit业务员);
            系统服务.LookUp.Inventory3(ItemLookUpEdit存货代码);
            系统服务.LookUp.SaleTypeSaleRole(lookUpEdit销售类型);
            系统服务.LookUp.Customer(lookUpEdit客户);
            
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
            lookUpEdit出入库类别.Enabled = b;

            lookUpEdit业务员.Enabled = false;
            lookUpEdit部门.Enabled = false;

            lookUpEdit销售类型.Enabled = b;
            buttonEdit客户.Enabled = b;
            lookUpEdit客户.Enabled = false;

            radioGroup蓝红标识.Enabled = b;
            
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
            lookUpEdit仓库.EditValue = "";
            buttonEdit部门.EditValue = "";

            lookUpEdit销售类型.EditValue = "";
            buttonEdit客户.EditValue = "";
            lookUpEdit出入库类别.EditValue = "";
            lookUpEdit相关期初.EditValue = null;
            lookUpEdit相关销售订单.EditValue = null;
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

                if (e.Column == gridCol物料编码 || e.Column == gridCol物料名称)
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

                #region 子件
                if (e.Column == gridCol子件数量1 || e.Column == gridCol子件单价1)
                {
                    decimal 数量 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol子件数量1));
                    decimal 单价 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol子件单价1));
                    gridView1.SetRowCellValue(iRow, gridCol子件金额1, 数量 * 单价);
                }

                if (e.Column == gridCol子件数量2 || e.Column == gridCol子件单价2)
                {
                    decimal 数量 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol子件数量2));
                    decimal 单价 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol子件单价2));
                    gridView1.SetRowCellValue(iRow, gridCol子件金额2, 数量 * 单价);
                }

                if (e.Column == gridCol子件数量3 || e.Column == gridCol子件单价3)
                {
                    decimal 数量 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol子件数量3));
                    decimal 单价 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol子件单价3));
                    gridView1.SetRowCellValue(iRow, gridCol子件金额3, 数量 * 单价);
                }

                if (e.Column == gridCol子件数量4 || e.Column == gridCol子件单价4)
                {
                    decimal 数量 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol子件数量4));
                    decimal 单价 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol子件单价4));
                    gridView1.SetRowCellValue(iRow, gridCol子件金额4, 数量 * 单价);
                }

                if (e.Column == gridCol子件数量5 || e.Column == gridCol子件单价5)
                {
                    decimal 数量 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol子件数量5));
                    decimal 单价 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol子件单价5));
                    gridView1.SetRowCellValue(iRow, gridCol子件金额5, 数量 * 单价);
                }
                #endregion

                if (e.Column == gridCol运行成本 || e.Column == gridCol业务费用 || e.Column == gridCol业务费用倍数 || e.Column == gridCol利润分成
                    || e.Column == gridCol子件数量1 || e.Column == gridCol子件单价1
                    || e.Column == gridCol子件数量2 || e.Column == gridCol子件单价2
                    || e.Column == gridCol子件数量3 || e.Column == gridCol子件单价3
                    || e.Column == gridCol子件数量4 || e.Column == gridCol子件单价4
                    || e.Column == gridCol子件数量5 || e.Column == gridCol子件单价5)
                {
                    Get利润(iRow);
                }

                if (e.Column == gridCol利润)
                {
                    decimal 利润 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol利润));
                    decimal 利润分成 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol利润分成));
                    gridView1.SetRowCellValue(iRow, gridCol个人利润, 利润 * 利润分成);
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

        private void ItemButtonEdit子件编码1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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
                gridView1.SetRowCellValue(iRow, gridCol子件编码1, frm.sID);
                frm.Enabled = true;
            }
        }

        private void ItemButtonEdit子件编码2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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
                gridView1.SetRowCellValue(iRow, gridCol子件编码2, frm.sID);
                frm.Enabled = true;
            }
        }

        private void ItemButtonEdit子件编码3_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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
                gridView1.SetRowCellValue(iRow, gridCol子件编码3, frm.sID);
                frm.Enabled = true;
            }
        }

        private void ItemButtonEdit子件编码4_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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
                gridView1.SetRowCellValue(iRow, gridCol子件编码4, frm.sID);
                frm.Enabled = true;
            }
        }

        private void ItemButtonEdit子件编码5_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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
                gridView1.SetRowCellValue(iRow, gridCol子件编码5, frm.sID);
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

        private void lookUpEdit客户_EditValueChanged(object sender, EventArgs e)
        {
            GetShow();
        }

        private void lookUpEdit出入库类别_EditValueChanged(object sender, EventArgs e)
        {
            GetShow();
        }

        private void lookUpEdit销售类型_EditValueChanged(object sender, EventArgs e)
        {
            GetShow();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridCol物料编码).ToString().Trim() != "")
                {
                    Get利润(i);
                }
            }
        }

        private void GetShow()
        {
            lookUpEdit相关销售订单.Enabled = false;
            lookUpEdit相关期初.Enabled = false;
            if (lookUpEdit客户.EditValue != null && lookUpEdit销售类型.EditValue != null && lookUpEdit出入库类别.EditValue!=null)
            {
                string lb = lookUpEdit出入库类别.EditValue.ToString().Trim();
                if (lb == "05" || lb == "06" || lb == "07")
                {
                    系统服务.LookUp.RdAR_First(lookUpEdit相关期初, lookUpEdit客户.EditValue.ToString().Trim(), textEditID.EditValue.ToString().Trim(), lookUpEdit销售类型.EditValue.ToString().Trim());
                    系统服务.LookUp.RdSO_SOMain(lookUpEdit相关销售订单, "", "", "");
                    if (sState == "add" || sState == "edit" || sState == "alter")
                    {
                        lookUpEdit相关期初.Enabled = true;
                        
                    }
                    else
                    {
                        lookUpEdit相关期初.Enabled = false;
                    }
                    lookUpEdit相关销售订单.Enabled = false;
                    lookUpEdit相关销售订单.EditValue = null;
                }
                else if (lb == "08" || lb == "09")
                {
                    系统服务.LookUp.RdSO_SOMain(lookUpEdit相关销售订单, lookUpEdit客户.EditValue.ToString().Trim(), textEditID.EditValue.ToString().Trim(), lookUpEdit销售类型.EditValue.ToString().Trim());
                    系统服务.LookUp.RdAR_First(lookUpEdit相关期初, "", "", "");
                    if (sState == "add" || sState == "edit" || sState == "alter")
                    {
                        lookUpEdit相关销售订单.Enabled = true;
                        
                    }
                    else
                    {
                        lookUpEdit相关期初.Enabled = false;
                    }
                    lookUpEdit相关期初.Enabled = false;
                    lookUpEdit相关期初.EditValue = null;
                }
                else
                {
                    lookUpEdit相关期初.Enabled = false;
                    lookUpEdit相关期初.EditValue = null;
                    lookUpEdit相关销售订单.Enabled = false;
                    lookUpEdit相关销售订单.EditValue = null;
                }
            }
        }

        private decimal 期初剩余金额()
        {
            if (lookUpEdit相关期初.EditValue.ToString().Trim() != "")
            {
                sSQL = "select D1-isnull((select sum(b.iMoney) from RdRecord a left join RdRecords b on a.ID=b.ID where a.ARiID=AR_First.iID and 1=1),0) from AR_First where iID='" + lookUpEdit相关期初.EditValue.ToString().Trim() + "'";
                if (textEditID.EditValue.ToString().Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", " a.ID<>'" + textEditID.EditValue.ToString().Trim() + "'");
                }
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count == 0)
                {
                    return 0;
                }

                else
                {
                    return ReturnDecimal(dt.Rows[0][0]);
                }
            }
            else
            {
                return 0;
            }
        }

        private decimal 销售订单剩余金额()
        {
            if (lookUpEdit相关销售订单.EditValue.ToString().Trim() != "")
            {
                sSQL = "select iMoney-isnull((select sum(b.iMoney) from RdRecord a left join RdRecords b on a.ID=b.ID where a.SoAutoID=SO_SODetails.AutoID and 1=1),0) from SO_SODetails where AutoID='" + lookUpEdit相关销售订单.EditValue.ToString().Trim() + "'";
                if (textEditID.EditValue.ToString().Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", " a.ID<>'" + textEditID.EditValue.ToString().Trim() + "'");
                }
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count == 0)
                {
                    return 0;
                }

                else
                {
                    return ReturnDecimal(dt.Rows[0][0]);
                }
            }
            else
            {
                return 0;
            }
        }



        private void Get利润(int iRow)
        {
            if (sState == "add" || sState == "edit" || sState == "alter")
            {
                decimal 订单金额 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol含税金额));
                decimal 订单数量 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol数量));
                decimal 子件金额 = 0;
                sSQL = "select * from Inventory ";
                DataTable dtinv = clsSQLCommond.ExecQuery(sSQL);
                if (gridView1.GetRowCellValue(iRow, gridCol子件编码1).ToString().Trim() != "")
                {
                    if (dtinv.Select("cInvCode='" + gridView1.GetRowCellValue(iRow, gridCol子件编码1).ToString().Trim() + "'")[0]["cInvClassCode"].ToString().Trim() != "03")
                    {
                        子件金额 = 子件金额 + ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol子件金额1));
                    }
                }
                if (gridView1.GetRowCellValue(iRow, gridCol子件编码2).ToString().Trim() != "")
                {
                    if (dtinv.Select("cInvCode='" + gridView1.GetRowCellValue(iRow, gridCol子件编码2).ToString().Trim() + "'")[0]["cInvClassCode"].ToString().Trim() != "03")
                    {
                        子件金额 = 子件金额 + ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol子件金额2));
                    }
                }
                if (gridView1.GetRowCellValue(iRow, gridCol子件编码3).ToString().Trim() != "")
                {
                    if (dtinv.Select("cInvCode='" + gridView1.GetRowCellValue(iRow, gridCol子件编码3).ToString().Trim() + "'")[0]["cInvClassCode"].ToString().Trim() != "03")
                    {
                        子件金额 = 子件金额 + ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol子件金额3));
                    }
                }
                if (gridView1.GetRowCellValue(iRow, gridCol子件编码4).ToString().Trim() != "")
                {
                    if (dtinv.Select("cInvCode='" + gridView1.GetRowCellValue(iRow, gridCol子件编码4).ToString().Trim() + "'")[0]["cInvClassCode"].ToString().Trim() != "03")
                    {
                        子件金额 = 子件金额 + ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol子件金额4));
                    }
                }
                if (gridView1.GetRowCellValue(iRow, gridCol子件编码5).ToString().Trim() != "")
                {
                    if (dtinv.Select("cInvCode='" + gridView1.GetRowCellValue(iRow, gridCol子件编码5).ToString().Trim() + "'")[0]["cInvClassCode"].ToString().Trim() != "03")
                    {
                        子件金额 = 子件金额 + ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol子件金额5));
                    }
                }
                decimal 业务费用 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol业务费用));
                decimal 运行成本 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol运行成本));
                decimal 业务费用倍数 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol业务费用倍数));
                
                if (lookUpEdit销售类型.EditValue.ToString() == "01")
                {

                    业务费用 = 业务费用 * 业务费用倍数;
                }
                else
                {
                    子件金额 = 子件金额 * 0.9M;
                    业务费用 = 业务费用 * 业务费用倍数;
                }
                if (lookUpEdit销售类型.EditValue.ToString() == "01")
                {
                    if (lookUpEdit出入库类别.EditValue.ToString().Trim() != "09")
                    {
                        gridView1.SetRowCellValue(iRow, gridCol利润, (订单金额 - 子件金额 - 业务费用 - 运行成本 * 订单数量) * 0.7M);
                    }
                    else
                    {
                        gridView1.SetRowCellValue(iRow, gridCol利润, (子件金额 + 运行成本 * 订单数量)*0.7M);
                    }
                }
                else
                {
                    if (lookUpEdit出入库类别.EditValue.ToString().Trim() != "09")
                    {
                        gridView1.SetRowCellValue(iRow, gridCol利润, 订单金额 - 子件金额 - 业务费用 - 运行成本 * 订单数量);
                    }
                    else
                    {
                        gridView1.SetRowCellValue(iRow, gridCol利润, 子件金额 + 运行成本 * 订单数量);
                    }
                }

            }
        }

        
    }
}
