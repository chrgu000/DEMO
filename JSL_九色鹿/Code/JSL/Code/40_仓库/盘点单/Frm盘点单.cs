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
    public partial class Frm盘点单 : 系统服务.FrmBaseInfo
    {
        string tablename = "CheckVouch";
        string tableid = "CheckCode";
        string tablenames = "CheckVouchs";
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

        public Frm盘点单(long siID)
        {
            iID = siID;
            InitializeComponent();
            
        }

        public Frm盘点单()
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
            Frm盘点单_Add frm = new Frm盘点单_Add(单据号1, 单据号2, 单据日期1, 单据日期2, 制单日期1, 制单日期2, 业务员,
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
            string sSQL = "select * from " + tablename + " a left join " + tablenames + "  b on a.ID=b.ID where 1=1 ";
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
                sSQL = "select min(ID) as ID from " + tablename + " a  where 1=1 ";
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
                    sSQL = "select ID from " + tablename + " a  where ID<" + textEditID.Text + "   order by ID desc";
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
                    sSQL = "select ID from " + tablename + " a  where ID>" + textEditID.Text + "  order by ID ";
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
                sSQL = "select isnull(max(ID),-1) as ID from " + tablename + " a   where 1=1  ";
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

            sSQL = "select a.*, 'edit' as iSave  from " + tablenames + " a  where 1=-1";
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

            if (dateEdit单据日期.EditValue == null || dateEdit单据日期.EditValue.ToString().Trim() == "")
            {
                throw new Exception("单据日期不能为空");
            }
            if (lookUpEdit仓库.EditValue == null || lookUpEdit仓库.EditValue.ToString().Trim() == "")
            {
                throw new Exception("仓库不能为空");
            }

            aList = new System.Collections.ArrayList();
            DataRow drh = dt.NewRow();
            if (sState == "add")
            {
                sSQL = "select isnull(isnull(max(ID),-1)+1,1) as ID from " + tablename;
                iID = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                drh["ID"] = iID;
                drh["CheckCode"] = clsPublic.GetNewSerialNumberContinuous(tablename, tableid);
                textEdit单据号.EditValue = drh["CheckCode"].ToString();
            }
            else
            {
                drh["ID"] = textEditID.Text;
                iID = Convert.ToInt64(textEditID.Text);
                drh["CheckCode"] = textEdit单据号.EditValue.ToString().Trim();
            }
            drh["dDate"] = dateEdit单据日期.EditValue.ToString().Trim();

            drh["cPersonCode"] = buttonEdit业务员.EditValue.ToString().Trim();
            drh["cWhCode"] = lookUpEdit仓库.EditValue.ToString().Trim();
            drh["cDepCode"] = buttonEdit部门.EditValue.ToString().Trim();
            

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
                clsPublic.GetChangeDelRow(tablenames, textEditDel.EditValue.ToString().Trim(), aList);
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
                    if (ReturnDecimal(gridView1.GetRowCellDisplayText(i, gridCol数量).ToString().Trim()) < 0)
                    {
                        sErr = sErr + "行" + (i + 1) + "数量必须大于0\n";
                        continue;
                    }
                    if (ReturnDecimal(gridView1.GetRowCellDisplayText(i, gridCol盒数).ToString().Trim()) < 0)
                    {
                        sErr = sErr + "行" + (i + 1) + "盒数必须大于0\n";
                        continue;
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
                    dr["CheckCode"] = textEdit单据号.EditValue.ToString().Trim();
                    dr["iRowNo"] = gridView1.GetRowCellValue(i, gridCol序号).ToString().Trim();
                    dr["cInvCode"] = gridView1.GetRowCellValue(i, gridCol物料编码).ToString().Trim();
                    dr["cPosCode"] = gridView1.GetRowCellValue(i, gridColcPosCode).ToString().Trim();
                    dr["BoxNo"] = gridView1.GetRowCellValue(i, gridCol箱号).ToString().Trim();
                    dr["sBoxNo"] = gridView1.GetRowCellValue(i, gridCol盒号).ToString().Trim();
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

            if (dateEdit单据日期.EditValue == null || dateEdit单据日期.EditValue.ToString().Trim() == "")
            {
                throw new Exception("单据日期不能为空\n");
            }
            if (lookUpEdit仓库.EditValue == null || lookUpEdit仓库.Text.Trim() == "")
            {
                throw new Exception("仓库不能为空");
            }
            aList = new System.Collections.ArrayList();

            string sErr = "";

            bool isIn=false;
            bool isOut=false;
            bool isOut2 = false;
            
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridCol盒号).ToString() != null && gridView1.GetRowCellValue(i, gridCol盒号).ToString() != "")
                {
                    string sBoxNo = gridView1.GetRowCellValue(i, gridCol盒号).ToString();
                    decimal sBoxQty = ReturnInt(gridView1.GetRowCellValue(i, gridCol盒数).ToString());
                    if (sBoxQty == 0)//库存为0
                    {
                        sSQL = "select * from SO_SOPackingSublist where sBoxNo='" + sBoxNo + "'";
                        DataTable dts = clsSQLCommond.ExecQuery(sSQL);
                        if (dts.Rows.Count == 0)
                        {
                            sErr = sErr + (i + 1) + "行 " + sBoxNo + " 未找到装箱单\n";
                        }
                        if (ReturnInt(dts.Rows[0]["sOutBoxQty"]) == 0)//已入库未出库 需出库
                        {
                            isOut = true;
                        }
                    }
                    else if (sBoxQty == 1)
                    {
                        sSQL = "select * from SO_SOPackingSublist where sBoxNo='" + sBoxNo + "'";
                        DataTable dts = clsSQLCommond.ExecQuery(sSQL);
                        if (dts.Rows.Count == 0)
                        {
                            sErr = sErr + (i + 1) + "行 " + sBoxNo + " 未找到装箱单\n";
                        }
                        if (ReturnInt(dts.Rows[0]["sInBoxQty"]) == 0)//未入库 需装箱单入库
                        {
                            isIn = true;
                        }
                        else if (ReturnInt(dts.Rows[0]["sInBoxQty"]) == 1 && ReturnInt(dts.Rows[0]["sOutBoxQty"]) == 1)//已出库 需红字入库
                        {
                            isOut2 = true;
                        }
                    }
                }
            }

            #region 盘点入库
            if (isIn == true)
            {
                sSQL = "select * from RdRecord05 where 1=-1";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                sSQL = "select * from RdRecords05 where 1=-1";
                DataTable dts = clsSQLCommond.ExecQuery(sSQL);

                DataRow drh = dt.NewRow();

                long sID = clsPublic.GetMaxID("RD");
                drh["ID"] = sID;
                string cRDCode = clsPublic.GetMaxCode("cRdCode");
                drh["cRDCode"] = cRDCode;
                
                drh["dDate"] = dateEdit单据日期.EditValue.ToString().Trim();

                drh["cPersonCode"] = buttonEdit业务员.EditValue.ToString().Trim();

                drh["cWhCode"] = lookUpEdit仓库.EditValue.ToString().Trim();
                drh["cDepCode"] = buttonEdit部门.EditValue.ToString().Trim();
                drh["cRSCode"] = "0504";

                drh["Flag"] = "1";

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
                dt.Rows.Add(drh);
                sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, "RdRecord05", dt, 0);
                aList.Add(sSQL);
                int count = 1;
                #region 子表
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridCol盒号).ToString() != null && gridView1.GetRowCellValue(i, gridCol盒号).ToString() != "")
                    {
                        string BoxNo = gridView1.GetRowCellValue(i, gridCol箱号).ToString();
                        string sBoxNo = gridView1.GetRowCellValue(i, gridCol盒号).ToString();
                        decimal sBoxQty = ReturnInt(gridView1.GetRowCellValue(i, gridCol盒数).ToString());
                        decimal iQuantity = ReturnInt(gridView1.GetRowCellValue(i, gridCol数量).ToString());
                        if (sBoxQty == 1)
                        {
                            sSQL = "select * from SO_SOPackingSublist where sBoxNo='" + sBoxNo + "'";
                            DataTable dta = clsSQLCommond.ExecQuery(sSQL);
                            if (ReturnInt(dta.Rows[0]["sInBoxQty"]) == 0)//未入库 需装箱单入库
                            {
                                #region 生成table
                                DataRow dr = dts.NewRow();
                                long sAutoID = clsPublic.GetMaxID("RDS");
                                dr["AutoID"] = sAutoID;
                                dr["ID"] = sID;
                                dr["cRDCode"] = cRDCode;
                                dr["iRowNo"] = count;
                                count = count + 1;
                                dr["cInvCode"] = gridView1.GetRowCellValue(i, gridCol物料编码).ToString().Trim();
                                dr["iQuantity"] =iQuantity;
                                dr["cPosCode"] = gridView1.GetRowCellValue(i, gridColcPosCode).ToString().Trim();

                                dr["BoxNo"] = BoxNo;
                                dr["sBoxNo"] = sBoxNo;
                                dr["BoxQty"] = 1;
                                dr["sBoxQty"] =sBoxQty;
                                dr["cMemo"] = gridView1.GetRowCellValue(i, gridCol备注).ToString().Trim();
                                dr["M1"] = gridView1.GetRowCellValue(i, gridColM1).ToString().Trim();
                                dr["M2"] = gridView1.GetRowCellValue(i, gridCol缸号).ToString().Trim();

                                dts.Rows.Add(dr);
                                sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, "RdRecords05", dts, dts.Rows.Count - 1);
                                aList.Add(sSQL);

                                //反写装箱单
                                sSQL = "update  SO_SOPackingSublist set sInBoxQty=" + sBoxQty + ",iInQuantity=" + iQuantity + "  where sBoxNo='" + sBoxNo + "'";
                                aList.Add(sSQL);
                                #endregion
                            }
                        }
                    }
                }
                #endregion
            }
            #endregion

            #region 盘点出库
            if (isOut == true)
            {
                sSQL = "select * from RdRecord15 where 1=-1";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                sSQL = "select * from RdRecords15 where 1=-1";
                DataTable dts = clsSQLCommond.ExecQuery(sSQL);

                DataRow drh = dt.NewRow();

                long sID = clsPublic.GetMaxID("RD");
                drh["ID"] = sID;
                string cRDCode = clsPublic.GetMaxCode("cRdCode");
                drh["cRDCode"] = cRDCode;

                drh["dDate"] = dateEdit单据日期.EditValue.ToString().Trim();

                drh["cPersonCode"] = buttonEdit业务员.EditValue.ToString().Trim();

                drh["cWhCode"] = lookUpEdit仓库.EditValue.ToString().Trim();
                drh["cDepCode"] = buttonEdit部门.EditValue.ToString().Trim();
                drh["cRSCode"] = "1504";

                drh["Flag"] = "1";

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
                dt.Rows.Add(drh);
                sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, "RdRecord15", dt, 0);
                aList.Add(sSQL);
                int count = 1;
                #region 子表
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridCol盒号).ToString() != null && gridView1.GetRowCellValue(i, gridCol盒号).ToString() != "")
                    {
                        string BoxNo = gridView1.GetRowCellValue(i, gridCol箱号).ToString();
                        string sBoxNo = gridView1.GetRowCellValue(i, gridCol盒号).ToString();
                        decimal sBoxQty = ReturnInt(gridView1.GetRowCellValue(i, gridCol盒数).ToString());
                        decimal iQuantity = ReturnInt(gridView1.GetRowCellValue(i, gridCol数量).ToString());
                        if (sBoxQty == 0)
                        {
                            sSQL = "select * from SO_SOPackingSublist where sBoxNo='" + sBoxNo + "'";
                            DataTable dta = clsSQLCommond.ExecQuery(sSQL);
                            if (ReturnInt(dta.Rows[0]["sOutBoxQty"]) == 0)//已入库未出库 需出库
                            {
                                #region 生成table
                                DataRow dr = dts.NewRow();
                                long sAutoID = clsPublic.GetMaxID("RDS");
                                dr["AutoID"] = sAutoID;
                                dr["ID"] = sID;
                                dr["cRDCode"] = cRDCode;
                                dr["iRowNo"] = count;
                                count = count + 1;
                                dr["cInvCode"] = gridView1.GetRowCellValue(i, gridCol物料编码).ToString().Trim();
                                dr["iQuantity"] = dta.Rows[0]["iQuantity"];
                                dr["cPosCode"] = gridView1.GetRowCellValue(i, gridColcPosCode).ToString().Trim();

                                dr["BoxNo"] = BoxNo;
                                dr["sBoxNo"] = sBoxNo;
                                dr["BoxQty"] = 1;
                                dr["sBoxQty"] = dta.Rows[0]["sBoxQty"];
                                dr["cMemo"] = gridView1.GetRowCellValue(i, gridCol备注).ToString().Trim();
                                dr["M1"] = gridView1.GetRowCellValue(i, gridColM1).ToString().Trim();
                                dr["M2"] = gridView1.GetRowCellValue(i, gridCol缸号).ToString().Trim();

                                dts.Rows.Add(dr);
                                sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, "RdRecords15", dts, dts.Rows.Count - 1);
                                aList.Add(sSQL);

                                //反写装箱单
                                sSQL = "update  SO_SOPackingSublist set sOutBoxQty=1,iOutQuantity=" + dta.Rows[0]["iQuantity"] + "  where sBoxNo='" + sBoxNo + "'";
                                aList.Add(sSQL);
                                #endregion
                            }
                        }
                    }
                }
                #endregion
            }
            #endregion

            #region 盘点出库
            if (isOut2 == true)
            {
                sSQL = "select * from RdRecord15 where 1=-1";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                sSQL = "select * from RdRecords15 where 1=-1";
                DataTable dts = clsSQLCommond.ExecQuery(sSQL);

                DataRow drh = dt.NewRow();

                long sID = clsPublic.GetMaxID("RD");
                drh["ID"] = sID;
                string cRDCode = clsPublic.GetMaxCode("cRdCode");
                drh["cRDCode"] = cRDCode;

                drh["dDate"] = dateEdit单据日期.EditValue.ToString().Trim();

                drh["cPersonCode"] = buttonEdit业务员.EditValue.ToString().Trim();

                drh["cWhCode"] = lookUpEdit仓库.EditValue.ToString().Trim();
                drh["cDepCode"] = buttonEdit部门.EditValue.ToString().Trim();
                drh["cRSCode"] = "1504";

                drh["Flag"] = "2";

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
                dt.Rows.Add(drh);
                sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, "RdRecord15", dt, 0);
                aList.Add(sSQL);
                int count = 1;
                #region 子表
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridCol盒号).ToString() != null && gridView1.GetRowCellValue(i, gridCol盒号).ToString() != "")
                    {
                        string BoxNo = gridView1.GetRowCellValue(i, gridCol箱号).ToString();
                        string sBoxNo = gridView1.GetRowCellValue(i, gridCol盒号).ToString();
                        decimal sBoxQty = ReturnInt(gridView1.GetRowCellValue(i, gridCol盒数).ToString());
                        decimal iQuantity = ReturnInt(gridView1.GetRowCellValue(i, gridCol数量).ToString());
                        if (sBoxQty == 0)
                        {
                            sSQL = "select * from SO_SOPackingSublist where sBoxNo='" + sBoxNo + "'";
                            DataTable dta = clsSQLCommond.ExecQuery(sSQL);
                            if (ReturnInt(dta.Rows[0]["sInBoxQty"]) == 1 && ReturnInt(dta.Rows[0]["sOutBoxQty"]) == 1)//已出库 需红字入库
                            {
                                #region 生成table
                                DataRow dr = dts.NewRow();
                                long sAutoID = clsPublic.GetMaxID("RDS");
                                dr["AutoID"] = sAutoID;
                                dr["ID"] = sID;
                                dr["cRDCode"] = cRDCode;
                                dr["iRowNo"] = count;
                                count = count + 1;
                                dr["cInvCode"] = gridView1.GetRowCellValue(i, gridCol物料编码).ToString().Trim();
                                dr["iQuantity"] ="-" + dta.Rows[0]["iQuantity"].ToString().Trim();
                                dr["cPosCode"] = gridView1.GetRowCellValue(i, gridColcPosCode).ToString().Trim();

                                dr["BoxNo"] = BoxNo;
                                dr["sBoxNo"] = sBoxNo;
                                dr["BoxQty"] = -1;
                                dr["sBoxQty"] = -1;
                                dr["cMemo"] = gridView1.GetRowCellValue(i, gridCol备注).ToString().Trim();
                                dr["M1"] = gridView1.GetRowCellValue(i, gridColM1).ToString().Trim();
                                dr["M2"] = gridView1.GetRowCellValue(i, gridCol缸号).ToString().Trim();

                                dts.Rows.Add(dr);
                                sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, "RdRecords15", dts, dts.Rows.Count - 1);
                                aList.Add(sSQL);

                                //反写装箱单
                                sSQL = "update  SO_SOPackingSublist set sOutBoxQty=1,iOutQuantity=" + dta.Rows[0]["iQuantity"] + "  where sBoxNo='" + sBoxNo + "'";
                                aList.Add(sSQL);
                                #endregion
                            }
                        }
                    }
                }
                #endregion
            }
            #endregion

            if (sErr != "")
            {
                throw new Exception(sErr);
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
            throw new Exception("该功能未实现");
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

        private void Frm盘点单_Load(object sender, EventArgs e)
        {
            try
            {
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

        private void GetGrid()
        {
            if (iID != -1)
            {
                sSQL = "select * from " + tablename + " a  where ID=" + iID;
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]);;
                    textEdit单据号.EditValue = dt.Rows[0]["CheckCode"].ToString();

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

                    
                    buttonEdit部门.Enabled = false;


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
            系统服务.LookUp.Warehouse(lookUpEdit仓库);
            系统服务.LookUp.Department(lookUpEdit部门);
            系统服务.LookUp.Person(lookUpEdit业务员);
            系统服务.LookUp.Position(ItemLookUpEdit货位);

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

            lookUpEdit业务员.Enabled = false;
            lookUpEdit部门.Enabled = false;

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
                    if (d盒数 != 1 || d盒数 != 0)
                    {
                        throw new Exception("只能为一盒或零盒");
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

        private void lookUpEdit销售类型_EditValueChanged(object sender, EventArgs e)
        {
            
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


    }
}
