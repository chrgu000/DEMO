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
    public partial class Frm委外入库单2 : 系统服务.FrmBaseInfo
    {
        string tablename = "RdRecord";
        string tableid = "cRDCode";
        string tablenames = "RdRecords";
        string cRsCode = "03";

        string cMPCode = "";

        string cSQL = " ";

        string cWhCodeIn = "";

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
        public string 色号 = "";
        public string 缸号 = "";

        string isChange = "";

        public Frm委外入库单2(long siID,string title)
        {
            iID = siID;
            InitializeComponent();

            
        }

        public Frm委外入库单2()
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
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }
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
            Frm委外入库单_Add frm = new Frm委外入库单_Add(单据号1, 单据号2, 单据日期1, 单据日期2, 制单日期1, 制单日期2, 业务员,
               仓库, 审核日期1, 审核日期2, 制单人1, 制单人2, 审核人1, 审核人2, 物料1, 物料2, 色号, 缸号);
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
                色号 = frm.色号;
                缸号 = frm.缸号;
                GetSel();
            }

        }

        private void GetSel()
        {
            string sSQL = "select * from " + tablename + " a left join " + tablenames + "  b on a.ID=b.ID where 1=1 and cRSCode=" + cRsCode + cSQL;
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
            if (色号 != "")
            {
                sSQL = sSQL + " and b.M1 like '%" + 色号 + "%'";
            }
            if (缸号 != "")
            {
                sSQL = sSQL + " and b.M2 like '%" + 缸号 + "%'";
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
                sSQL = "select min(ID) as ID from " + tablename + " where cRSCode='" + cRsCode + "' " + cSQL;
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]); ;
                    iID = Convert.ToInt64(dt.Rows[0]["ID"]); ;
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
                    sSQL = "select ID from " + tablename + " where ID<" + iID + " and cRSCode='" + cRsCode + "' " + cSQL + " order by ID desc";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt.Rows.Count > 0)
                    {
                        textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]); ;
                        iID = Convert.ToInt64(dt.Rows[0]["ID"]); ;
                        GetGrid();
                    }
                    else
                    {
                        btnFirst();
                    }
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
                    sSQL = "select ID from " + tablename + " where ID>" + iID + " and cRSCode='" + cRsCode + "'" + cSQL + " order by ID ";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt.Rows.Count > 0)
                    {
                        textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]); ;
                        iID = Convert.ToInt64(dt.Rows[0]["ID"]); ;
                        GetGrid();
                    }
                    else
                    {
                        btnLast();
                    }
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
                sSQL = "select isnull(max(ID),-1) as ID from " + tablename + " where cRSCode='" + cRsCode + "'" + cSQL;
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    if (Convert.ToInt64(dt.Rows[0]["ID"]) == -1)
                        iID = -1;
                    else
                        iID = Convert.ToInt64(dt.Rows[0]["ID"]); ;

                    textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]); ;
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
            Frm委外订单_New frm = new Frm委外订单_New((DataTable)gridControl1.DataSource, cMPCode);
            frm.cMPCode = cMPCode;
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
                    gridView1.SetRowCellValue(i, gridCol委外订单子表ID, dtnew.Rows[s]["AutoID"].ToString());
                    gridView1.SetRowCellValue(i, gridCol物料编码, dtnew.Rows[s]["cInvCode"].ToString());
                    gridView1.SetRowCellValue(i, gridCol材料投入数量, dtnew.Rows[s]["iQuantity"].ToString());
                    gridView1.SetRowCellValue(i, gridCol成品量, dtnew.Rows[s]["D3"].ToString());
                    gridView1.SetRowCellValue(i, gridCol历史数量, dtnew.Rows[s]["iQuantity"].ToString());
                    if (dtnew.Rows[s]["iNum"].ToString() != "")
                    {
                        gridView1.SetRowCellValue(i, gridCol件数, dtnew.Rows[s]["iNum"].ToString());
                    }
                    if (dtnew.Rows[s]["iUnitPrice"].ToString() != "")
                    {
                        gridView1.SetRowCellValue(i, gridCol含税单价, dtnew.Rows[s]["iUnitPrice"].ToString());
                    }
                    if (dtnew.Rows[s]["iMoney"].ToString() != "")
                    {
                        gridView1.SetRowCellValue(i, gridCol含税金额, dtnew.Rows[s]["iMoney"].ToString());
                    }
                    if (dtnew.Rows[s]["iNatUnitPrice"].ToString() != "")
                    {
                        gridView1.SetRowCellValue(i, gridCol无税单价, dtnew.Rows[s]["iNatUnitPrice"].ToString());
                    }
                    if (dtnew.Rows[s]["iNatMoney"].ToString() != "")
                    {
                        gridView1.SetRowCellValue(i, gridCol无税金额, dtnew.Rows[s]["iNatMoney"].ToString());
                    }
                    if (dtnew.Rows[s]["iTaxRate"].ToString() != "")
                    {
                        gridView1.SetRowCellValue(i, gridCol税率, dtnew.Rows[s]["iTaxRate"].ToString());
                    }
                    if (dtnew.Rows[s]["iChangRate"].ToString() != "")
                    {
                        gridView1.SetRowCellValue(i, gridCol换算率, dtnew.Rows[s]["iChangRate"].ToString());
                    }
                    if (dtnew.Rows[s]["RdAutoID"].ToString() != "")
                    {
                        gridView1.SetRowCellValue(i, gridCol相关入库单AutoID, dtnew.Rows[s]["RdAutoID"].ToString());
                    }
                    gridView1.SetRowCellValue(i, gridColM1, dtnew.Rows[s]["M1"].ToString());
                    gridView1.SetRowCellValue(i, gridColM2, dtnew.Rows[s]["M2"].ToString());
                    gridView1.SetRowCellValue(i, gridColM3, dtnew.Rows[s]["M3"].ToString());
                }
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

            decimal 数量 = 0;
            if (gridView1.GetRowCellValue(iRow, gridCol材料投入数量).ToString().Trim() != "")
            {
                decimal d上游 = 0;
                decimal d累计 = 0;
                decimal d引用 = 0;
                long lAutoid = -1;
                if (gridView1.GetRowCellValue(iRow, gridColAutoID).ToString().Trim() != "")
                {
                    lAutoid = Convert.ToInt64(gridView1.GetRowCellValue(iRow, gridColAutoID));
                }
                if (iCodeUsed(Convert.ToInt64(gridView1.GetRowCellValue(iRow, gridCol委外订单子表ID)), lAutoid, out d上游, out d累计, out d引用) == -1)
                {
                    gridView1.SetRowCellValue(iRow, gridCol材料投入数量, gridView1.GetRowCellValue(iRow, gridCol历史数量));
                    throw new Exception("获得引用信息失败");
                }
                else
                {
                    if (radioGroup蓝红标识.EditValue.ToString().Trim() == "1")
                    {
                        if (数量 + d累计 > d上游)
                        {
                            gridView1.SetRowCellValue(iRow, gridCol材料投入数量, gridView1.GetRowCellValue(iRow, gridCol历史数量));
                            throw new Exception("累计下单数量超出订单数量，订单可下数量为" + (d上游 - d累计).ToString());
                        }
                        if (数量 + d累计 < d引用)
                        {
                            gridView1.SetRowCellValue(iRow, gridCol材料投入数量, gridView1.GetRowCellValue(iRow, gridCol历史数量));
                            throw new Exception("累计下单数量低于已引用数量");
                        }
                    }
                    if (radioGroup蓝红标识.EditValue.ToString().Trim() == "2")
                    {
                        if (数量 > d累计)
                        {
                            gridView1.SetRowCellValue(iRow, gridCol材料投入数量, gridView1.GetRowCellValue(iRow, gridCol历史数量));
                            throw new Exception("红字数量超出累计下单数量");
                        }
                        if (数量 + d累计 < d引用)
                        {
                            gridView1.SetRowCellValue(iRow, gridCol材料投入数量, gridView1.GetRowCellValue(iRow, gridCol历史数量));
                            throw new Exception("累计下单数量低于已引用数量");
                        }
                    }
                }
            }

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
            if (cMPCode == "0004")
            {
                throw new Exception("成团委外入库单请使用采集器入库");
            }
            GetNull();
            SetEnabled(true);
            dateEdit单据日期.EditValue = 系统服务.ClsBaseDataInfo.sLogDate;

            int iFocRow = gridView1.FocusedRowHandle;

            sSQL = "select a.*, 'edit' as iSave,a.iQuantity as 历史数量,cast(null as decimal(16,6)) as 引用量,cast(null as decimal(16,6)) as 累计下单数量,cast(null as decimal(16,6)) as 上游单据数量 from " + tablenames + " a   where 1=-1";
            dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dtBingGrid;
            gridView1.AddNewRow();
            try
            {
                gridView1.FocusedColumn = gridCol序号;
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
                gridView1.Focus();
            }
            catch { }

            gridView1.FocusedRowHandle = 0;

            gridView1.OptionsBehavior.Editable = true;
            radioGroup蓝红标识.EditValue = "1";
            lookUpEdit仓库.EditValue = cWhCodeIn;
            btnAddRow();

            sState = "add";
        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {
            if (cMPCode == "0004")
            {
                throw new Exception("成团委外入库单请使用采集器入库");
            }
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

            sState = "edit";
            SetEnabled(true);
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {

            if (textEditID.Text.Trim() == "")
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
                aList = new System.Collections.ArrayList();
                sSQL = "delete dbo.RdRecords where ID = " + textEditID.Text.Trim();
                aList.Add(sSQL);
                sSQL = "delete dbo.RdRecord where ID = " + textEditID.Text.Trim();
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

            if (lookUpEdit供应商.Text.Trim() == "")
            {
                throw new Exception("委外供应商不能为空");
            }

            if (radioGroup蓝红标识.EditValue == null || radioGroup蓝红标识.EditValue.ToString().Trim() == "")
            {
                throw new Exception("蓝红标识不能为空");
            }
            if (dateEdit单据日期.EditValue == null || dateEdit单据日期.EditValue.ToString().Trim() == "")
            {
                throw new Exception("单据日期不能为空");
            }
            if (lookUpEdit仓库.EditValue == null || lookUpEdit仓库.Text.Trim() == "")
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
                drh["cRDCode"] = 系统服务.序号.GetNewSerialNumberContinuous(tablename, tableid);
                textEdit单据号.EditValue = drh["cRDCode"].ToString();
            }
            else
            {
                drh["ID"] = textEditID.Text;
                iID = Convert.ToInt64(textEditID.Text);
                drh["cRDCode"] = textEdit单据号.EditValue.ToString().Trim();
            }
            drh["cVenCode"] = lookUpEdit供应商.EditValue.ToString().Trim();
            drh["dDate"] = dateEdit单据日期.EditValue.ToString().Trim();
            drh["cPersonCode"] = buttonEdit业务员.EditValue.ToString().Trim();
            if (lookUpEdit操作人.EditValue != null)
            {
                drh["cOperator"] = lookUpEdit操作人.EditValue.ToString().Trim();
            }
            drh["cWhCode"] = lookUpEdit仓库.EditValue.ToString().Trim();
            drh["cRdPersonCode"] = buttonEdit收货人.EditValue.ToString().Trim();
            drh["cDepCode"] = buttonEdit部门.EditValue.ToString().Trim();
            drh["cRSCode"] = cRsCode;
            drh["cMPCode"] = cMPCode;
            drh["Flag"] = radioGroup蓝红标识.EditValue.ToString().Trim();

            drh["cMemo"] = textEdit备注.EditValue.ToString().Trim();

            if (sState == "add")
            {
                dateEdit制单日期.EditValue = GetSystemTime();
                textEdit制单人.EditValue = 系统服务.ClsBaseDataInfo.sUid;
            }

            drh["dCreatesysTime"] = dateEdit制单日期.EditValue.ToString().Trim();
            drh["dCreatesysPerson"] = textEdit制单人.EditValue.ToString().Trim();

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
                if (gridView1.GetRowCellDisplayText(i, gridColM2).ToString().Trim() != "" && gridView1.GetRowCellDisplayText(i, gridColM2).ToString().Trim().Length != 7)
                {
                    sErr = sErr + "行" + (i + 1) + "请输入7位数缸号\n";
                    continue;
                }
                bHasGrid = true;
                if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "update" || gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "add" || gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "alter")
                {
                    #region 判断

                    if (gridView1.GetRowCellValue(i, gridCol材料投入数量).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + gridCol材料投入数量.Caption + "不能为空\n";
                        continue;
                    }
                    else
                    {
                        if (radioGroup蓝红标识.EditValue.ToString().Trim() == "1")
                        {
                            if (ReturnDecimal(gridView1.GetRowCellValue(i, gridCol材料投入数量).ToString().Trim()) < 0)
                            {
                                sErr = sErr + "行" + (i + 1) + gridCol材料投入数量.Caption + "需为正\n";
                                continue;
                            }
                        }
                        else if (radioGroup蓝红标识.EditValue.ToString().Trim() == "2")
                        {
                            if (ReturnDecimal(gridView1.GetRowCellValue(i, gridCol材料投入数量).ToString().Trim()) >= 0)
                            {
                                sErr = sErr + "行" + (i + 1) + gridCol材料投入数量.Caption + "需为负\n";
                                continue;
                            }
                        }
                    }

                    decimal d上游 = 0;
                    decimal d累计 = 0;
                    decimal d引用 = 0;
                    long lAutoid = -1;
                    if (gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim() != "")
                    {
                        lAutoid = Convert.ToInt64(gridView1.GetRowCellValue(i, gridColAutoID));
                    }
                    if (iCodeUsed(Convert.ToInt64(gridView1.GetRowCellValue(i, gridCol委外订单子表ID)), lAutoid, out d上游, out d累计, out d引用) == -1)
                    {
                        sErr = sErr + "行" + (i + 1) + "获得引用信息失败\n";
                        continue;
                    }
                    else
                    {
                        if (radioGroup蓝红标识.EditValue.ToString().Trim() == "1")
                        {
                            //if (d累计 + Convert.ToDecimal(gridView1.GetRowCellValue(i, gridCol材料投入数量)) > d上游)
                            //{
                            //    sErr = sErr + "行" + (i + 1) + "数量超出采购订单剩余数量\n";
                            //    continue;
                            //}
                            if (d累计 + Convert.ToDecimal(gridView1.GetRowCellValue(i, gridCol材料投入数量)) < d引用)
                            {
                                sErr = sErr + "行" + (i + 1) + "累计下单数量低于引用数量\n";
                                continue;
                            }
                        }
                        if (radioGroup蓝红标识.EditValue.ToString().Trim() == "2")
                        {
                            //if (d累计 < Convert.ToDecimal(gridView1.GetRowCellValue(i, gridCol材料投入数量)))
                            //{
                            //    sErr = sErr + "行" + (i + 1) + "红字数量超出累计下单数量\n";
                            //    continue;
                            //}
                            //if (d累计 + Convert.ToDecimal(gridView1.GetRowCellValue(i, gridCol材料投入数量)) < d引用)
                            //{
                            //    sErr = sErr + "行" + (i + 1) + "累计下单数量低于引用数量\n";
                            //    continue;
                            //}
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
                    dr["MOAutoID"] = gridView1.GetRowCellValue(i, gridCol委外订单子表ID).ToString().Trim();
                    dr["cInvCode"] = gridView1.GetRowCellValue(i, gridCol物料编码).ToString().Trim();
                    dr["D3"] = gridView1.GetRowCellValue(i, gridCol成品量).ToString().Trim();
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
                    if (gridView1.GetRowCellValue(i, gridCol税额) != null && gridView1.GetRowCellValue(i, gridCol税额).ToString().Trim() != "")
                    {
                        dr["iNatTax"] = gridView1.GetRowCellValue(i, gridCol税额).ToString().Trim();
                    }


                    if (gridView1.GetRowCellValue(i, gridColM1) != null && gridView1.GetRowCellValue(i, gridColM1).ToString().Trim() != "")
                    {
                        dr["M1"] = gridView1.GetRowCellValue(i, gridColM1).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridColM2) != null && gridView1.GetRowCellValue(i, gridColM2).ToString().Trim() != "")
                    {
                        dr["M2"] = gridView1.GetRowCellValue(i, gridColM2).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridColM3) != null && gridView1.GetRowCellValue(i, gridColM3).ToString().Trim() != "")
                    {
                        dr["M3"] = gridView1.GetRowCellValue(i, gridColM3).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridColM4) != null && gridView1.GetRowCellValue(i, gridColM4).ToString().Trim() != "")
                    {
                        dr["M4"] = gridView1.GetRowCellValue(i, gridColM4).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridColM5) != null && gridView1.GetRowCellValue(i, gridColM5).ToString().Trim() != "")
                    {
                        dr["M5"] = gridView1.GetRowCellValue(i, gridColM5).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridColM6) != null && gridView1.GetRowCellValue(i, gridColM6).ToString().Trim() != "")
                    {
                        dr["M6"] = gridView1.GetRowCellValue(i, gridColM6).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridColM7) != null && gridView1.GetRowCellValue(i, gridColM7).ToString().Trim() != "")
                    {
                        dr["M7"] = gridView1.GetRowCellValue(i, gridColM7).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridColM8) != null && gridView1.GetRowCellValue(i, gridColM8).ToString().Trim() != "")
                    {
                        dr["M8"] = gridView1.GetRowCellValue(i, gridColM8).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridColM9) != null && gridView1.GetRowCellValue(i, gridColM9).ToString().Trim() != "")
                    {
                        dr["M9"] = gridView1.GetRowCellValue(i, gridColM9).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridColM10) != null && gridView1.GetRowCellValue(i, gridColM10).ToString().Trim() != "")
                    {
                        dr["M10"] = gridView1.GetRowCellValue(i, gridColM10).ToString().Trim();
                    }

                    dr["cMemo"] = gridView1.GetRowCellValue(i, gridCol备注).ToString().Trim();


                    if (gridView1.GetRowCellValue(i, gridCol成品绞数) != null && gridView1.GetRowCellValue(i, gridCol成品绞数).ToString().Trim() != "")
                    {
                        dr["D1"] = gridView1.GetRowCellValue(i, gridCol成品绞数).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol成品绞重) != null && gridView1.GetRowCellValue(i, gridCol成品绞重).ToString().Trim() != "")
                    {
                        dr["D2"] = gridView1.GetRowCellValue(i, gridCol成品绞重).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol材料投入数量) != null && gridView1.GetRowCellValue(i, gridCol材料投入数量).ToString().Trim() != "")
                    {
                        dr["D15"] = gridView1.GetRowCellValue(i, gridCol材料投入数量).ToString().Trim();
                    }

                    if (gridView1.GetRowCellValue(i, gridCol回潮后绞数) != null && gridView1.GetRowCellValue(i, gridCol回潮后绞数).ToString().Trim() != "")
                    {
                        dr["D4"] = gridView1.GetRowCellValue(i, gridCol回潮后绞数).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol回潮后绞重) != null && gridView1.GetRowCellValue(i, gridCol回潮后绞重).ToString().Trim() != "")
                    {
                        dr["D5"] = gridView1.GetRowCellValue(i, gridCol回潮后绞重).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol回潮后重量) != null && gridView1.GetRowCellValue(i, gridCol回潮后重量).ToString().Trim() != "")
                    {
                        dr["iQuantity"] = gridView1.GetRowCellValue(i, gridCol回潮后重量).ToString().Trim();
                    }


                    if (gridView1.GetRowCellValue(i, gridCol检验后绞数) != null && gridView1.GetRowCellValue(i, gridCol检验后绞数).ToString().Trim() != "")
                    {
                        dr["D7"] = gridView1.GetRowCellValue(i, gridCol检验后绞数).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol检验后绞重) != null && gridView1.GetRowCellValue(i, gridCol检验后绞重).ToString().Trim() != "")
                    {
                        dr["D8"] = gridView1.GetRowCellValue(i, gridCol检验后绞重).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol检验后称重) != null && gridView1.GetRowCellValue(i, gridCol检验后称重).ToString().Trim() != "")
                    {
                        dr["D9"] = gridView1.GetRowCellValue(i, gridCol检验后称重).ToString().Trim();
                    }

                    if (gridView1.GetRowCellValue(i, gridCol次品绞数) != null && gridView1.GetRowCellValue(i, gridCol次品绞数).ToString().Trim() != "")
                    {
                        dr["D10"] = gridView1.GetRowCellValue(i, gridCol次品绞数).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol次品绞重) != null && gridView1.GetRowCellValue(i, gridCol次品绞重).ToString().Trim() != "")
                    {
                        dr["D11"] = gridView1.GetRowCellValue(i, gridCol次品绞重).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol次品重量) != null && gridView1.GetRowCellValue(i, gridCol次品重量).ToString().Trim() != "")
                    {
                        dr["D12"] = gridView1.GetRowCellValue(i, gridCol次品重量).ToString().Trim();
                    }

                    if (gridView1.GetRowCellValue(i, gridCol合格率) != null && gridView1.GetRowCellValue(i, gridCol合格率).ToString().Trim() != "")
                    {
                        dr["D13"] = gridView1.GetRowCellValue(i, gridCol合格率).ToString().Trim();
                    }

                    if (gridView1.GetRowCellValue(i, gridColD14) != null && gridView1.GetRowCellValue(i, gridColD14).ToString().Trim() != "")
                    {
                        dr["D14"] = gridView1.GetRowCellValue(i, gridColD14).ToString().Trim();
                    }

                    if (gridView1.GetRowCellValue(i, gridCol相关入库单AutoID) != null && gridView1.GetRowCellValue(i, gridCol相关入库单AutoID).ToString().Trim() != "")
                    {
                        dr["RdAutoID"] = gridView1.GetRowCellValue(i, gridCol相关入库单AutoID).ToString().Trim();
                    }

                    dr["S1"] = gridView1.GetRowCellValue(i, gridCol次品原因).ToString().Trim();

                    //dr["cClosesysPerson"] = gridView1.GetRowCellValue(i, gridCol行关闭人).ToString().Trim();
                    //dr["cClosesysTime"] = gridView1.GetRowCellValue(i, gridCol行关闭日期).ToString().Trim();
                    dr["UpdateDate"] = DateTime.Now.ToString();
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
                    if (gridView1.GetRowCellValue(i, gridCol材料投入数量).ToString().Trim() != "")
                    {
                        if (radioGroup蓝红标识.EditValue.ToString().Trim() == "1")
                        {
                            if (ReturnDecimal(gridView1.GetRowCellValue(i, gridCol材料投入数量).ToString().Trim()) < 0)
                            {
                                sErr = sErr + "行" + (i + 1) + gridCol材料投入数量.Caption + "需为正\n";
                                continue;
                            }
                        }
                        else if (radioGroup蓝红标识.EditValue.ToString().Trim() == "2")
                        {
                            if (ReturnDecimal(gridView1.GetRowCellValue(i, gridCol材料投入数量).ToString().Trim()) >= 0)
                            {
                                sErr = sErr + "行" + (i + 1) + gridCol材料投入数量.Caption + "需为负\n";
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

            if (!bHasGrid)
            {
                throw new Exception("数据不完整，不能保存");
            }

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("保存成功！\n合计执行语句:" + iCou + "条");
                textEditID.EditValue = iID;
                GetGrid();

                sState = "save";
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
            string sErr = "";
            if (cMPCode != "0013")
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellDisplayText(i, gridCol回潮后绞重).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + "回潮后绞重不可为空\n";
                        continue;
                    }
                }
            }
            if (sErr != "")
            {
                throw new Exception(sErr);
            }


            aList = new System.Collections.ArrayList();

            sSQL = "update " + tablename + " set dVerifysysTime='" + GetSystemTime() + "',dVerifysysPerson='" + 系统服务.ClsBaseDataInfo.sUid + "' where ID=" + textEditID.Text + "";
            aList.Add(sSQL);

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("审核成功！\n合计执行语句:" + iCou + "条");

                textEdit审核人.Text = 系统服务.ClsBaseDataInfo.sUid;
                dateEdit审核日期.Text = GetSystemTime();
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
            int iUsed = iCodeUsed(textEdit单据号.Text.Trim());
            if (iUsed == -1)
            {
                throw new Exception("查找引用情况失败");
            }
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

                textEdit关闭人.Text = "";
                dateEdit关闭日期.Text = "";
                sState = "open";
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

                textEdit关闭人.Text = 系统服务.ClsBaseDataInfo.sUid;
                dateEdit关闭日期.Text = GetSystemTime();
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

            SetEnabled(true);
            sState = "alter";
        }

        #endregion

        private void Frm委外入库单2_Load(object sender, EventArgs e)
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
            string title = this.Text.Replace("委外入库单", "");
            sSQL = "select * from MOProcess where cMPName='" + title + "'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt.Rows.Count > 0)
            {
                cSQL = " and cMPCode='" + dt.Rows[0]["cMPCode"].ToString() + "'";
                cMPCode = dt.Rows[0]["cMPCode"].ToString();
                
                cWhCodeIn = dt.Rows[0]["S2"].ToString();
            }
            if (this.Text.IndexOf("染色") == -1)
            {
                gridCol次品绞数.Visible = false;
                gridCol次品绞重.Visible = false;
                gridCol次品原因.Visible = false;
                gridCol次品重量.Visible = false;
                gridCol回潮后绞数.Visible = false;
                gridCol回潮后绞重.Visible = false;
                gridCol回潮后重量.Visible = false;
                gridCol检验后称重.Visible = false;
                gridCol检验后绞数.Visible = false;
                gridCol检验后绞重.Visible = false;
            }
        }

        private void GetGrid()
        {
            if (iID != -1)
            {
                sSQL = @"select a.*,u1.vchrName as 制单人,u2.vchrName as 审核人,d.cDepName,v.cVenName ,p1.PersonName,p2.PersonName as 收货人,b.投入重量,b.染出重量,b.件数
,convert(varchar(10),dCreatesysTime,120) as 制单日期,convert(varchar(10),dVerifysysTime,120) as 审核日期,convert(varchar(10),dDate,120) as 单据日期,'" + this.Text + "' as title from " + tablename + " a "
                +  @"left join _UserInfo u1 on a.dCreatesysPerson=u1.vchrUid left join _UserInfo u2 on a.dVerifysysPerson=u2.vchrUid 
left join Department d on a.cDepCode=d.cDepCode left join Vendor v on a.cVenCode=v.cVenCode left join Person p1 on a.cPersonCode=p1.PersonCode left join Person p2 on a.cRdPersonCode=p2.PersonCode 
                left join (select ID,sum(D15) as 投入重量,sum(D3) as 染出重量,sum(D14) as 件数 from  " + tablenames + " group by ID) b on a.ID=b.ID "
                + @"where cRSCode='" + cRsCode + "' and a.ID=" + iID;
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    textEditDel.Text = "";

                    textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]); 
                    textEdit单据号.EditValue = dt.Rows[0]["cRDCode"].ToString();

                    buttonEdit供应商.EditValue = dt.Rows[0]["cVenCode"].ToString();

                    dateEdit单据日期.EditValue = dt.Rows[0]["dDate"].ToString();
                    dateEdit制单日期.EditValue = dt.Rows[0]["dCreatesysTime"].ToString();
                    dateEdit审核日期.EditValue = dt.Rows[0]["dVerifysysTime"].ToString();
                    dateEdit关闭日期.EditValue = dt.Rows[0]["dClosesysTime"].ToString();

                    textEdit备注.EditValue = dt.Rows[0]["cMemo"].ToString();
                    textEdit制单人.EditValue = dt.Rows[0]["dCreatesysPerson"].ToString();
                    textEdit审核人.EditValue = dt.Rows[0]["dVerifysysPerson"].ToString();
                    textEdit关闭人.EditValue = dt.Rows[0]["dClosesysPerson"].ToString();

                    buttonEdit业务员.EditValue = dt.Rows[0]["cPersonCode"].ToString();
                    buttonEdit操作人.EditValue = dt.Rows[0]["cOperator"].ToString();
                    lookUpEdit仓库.EditValue = dt.Rows[0]["cWhCode"].ToString();
                    buttonEdit收货人.EditValue = dt.Rows[0]["cRdPersonCode"].ToString();
                    buttonEdit部门.EditValue = dt.Rows[0]["cDepCode"].ToString();

                    radioGroup蓝红标识.EditValue = dt.Rows[0]["Flag"].ToString();
                    sSQL = "select a.*,i.cInvName,i.cInvStd, 'edit' as iSave,a.iQuantity as 历史数量,cast(null as decimal(16,6)) as 引用量,cast(null as decimal(16,6)) as 累计下单数量,cast(null as decimal(16,6)) as 上游单据数量 " +
                            "from " + tablenames + " a left join  Inventory i on a.cInvCode=i.cInvCode left join ComputationUnitGroup g on i.cGroupCode=g.cGroupCode where ID=" + iID;


                    dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
                    gridControl1.DataSource = dtBingGrid;

                    sPrintLayOutMod = sProPath + "\\print\\Model\\委外入库单Mod.dll";
                    sPrintLayOutUser = sProPath + "\\print\\User\\委外入库单User.dll";

                    base.dsPrint.Tables.Clear();
                    base.dsPrint.Tables.Add(dt.Copy());
                    base.dsPrint.Tables[0].TableName = "dtHead";
                    base.dsPrint.Tables.Add(dtBingGrid.Copy());
                    base.dsPrint.Tables[1].TableName = "dtGrid";

                    gridView1.FocusedRowHandle = iFocRow;
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
            系统服务.LookUp.Warehouse(lookUpEdit仓库);
            系统服务.LookUp.Position(ItemLookUpEdit货位);
            系统服务.LookUp.RdStyle(lookUpEdit出入库类别);
            lookUpEdit出入库类别.EditValue = cRsCode;
            系统服务.LookUp.Person(lookUpEdit收货人);
            系统服务.LookUp.Person(lookUpEdit业务员);
            系统服务.LookUp.Person(lookUpEdit操作人);
            系统服务.LookUp.Department(lookUpEdit部门);

            系统服务.LookUp.ColorNo(ItemLookUpEditM1);
            系统服务.LookUp.Dyelot(ItemLookUpEditM2);

            系统服务.LookUp.Inventory(ItemLookUpEdit物料名称);
            ItemLookUpEdit物料名称.Properties.DisplayMember = "cInvName";
            系统服务.LookUp.Inventory(ItemLookUpEdit物料规格);
            ItemLookUpEdit物料规格.Properties.DisplayMember = "cInvStd";
            系统服务.LookUp.Inventory(ItemLookUpEdit物料代码);
            ItemLookUpEdit物料规格.Properties.DisplayMember = "cInvAddCode";

            系统服务.LookUp.Vendor2(lookUpEdit供应商);
        }

        private void SetEnabled(bool b)
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
            buttonEdit收货人.Enabled = b;
            lookUpEdit出入库类别.Enabled = false;

            lookUpEdit收货人.Enabled = false;
            lookUpEdit业务员.Enabled = false;

            buttonEdit操作人.Enabled = b;

            buttonEdit部门.Enabled = b;
            lookUpEdit部门.Enabled = false;
            buttonEdit供应商.Enabled = b;
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
            buttonEdit收货人.EditValue = "";
            buttonEdit部门.EditValue = "";
            buttonEdit供应商.EditValue = "";

            gridControl1.DataSource = null;

        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView1.FocusedRowHandle >= 0)
                {
                    iRow = gridView1.FocusedRowHandle;
                }

                if (gridView1.GetRowCellValue(iRow, gridCol序号).ToString().Trim() == "")
                {
                    gridView1.SetRowCellValue(iRow, gridCol序号, iRow + 1);
                }

                if (e.Column == gridCol物料编码 || e.Column == gridCol物料名称 || e.Column == gridCol规格型号)
                {
                    if (e.Column == gridCol物料编码)
                    {
                        gridView1.SetRowCellValue(iRow, gridCol物料名称, gridView1.GetRowCellValue(iRow, gridCol物料编码).ToString().Trim());
                        gridView1.SetRowCellValue(iRow, gridCol规格型号, gridView1.GetRowCellValue(iRow, gridCol物料编码).ToString().Trim());
                        gridView1.SetRowCellValue(iRow, gridCol税率, 17);
                    }
                    string invocde = gridView1.GetRowCellValue(iRow, gridCol物料编码).ToString().Trim();
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
                if (e.Column == gridCol材料投入数量 || e.Column == gridCol换算率)
                {
                    if (gridView1.GetRowCellValue(iRow, gridCol换算率).ToString().Trim() != "")
                    {
                        decimal 换算率 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol换算率));
                        decimal 数量 = 0;
                        if (gridView1.GetRowCellValue(iRow, gridCol材料投入数量).ToString().Trim() != "")
                        {
                            数量 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol材料投入数量));
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

                if (e.Column == gridCol材料投入数量 || e.Column == gridCol件数 || e.Column == gridCol税率 || e.Column == gridCol税额 || e.Column == gridCol含税单价 || e.Column == gridCol含税金额
                    || e.Column == gridCol无税单价 || e.Column == gridCol无税金额)
                {
                    decimal 数量 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol材料投入数量));
                    decimal 历史数量 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol历史数量));
                    decimal 件数 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol件数));
                    decimal 税率 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol税率)) / 100;
                    decimal 税额 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol税额));
                    decimal 换算率 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol换算率));
                    decimal 含税单价 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol含税单价));
                    decimal 含税金额 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol含税金额));
                    decimal 无税单价 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol无税单价));
                    decimal 无税金额 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol无税金额));

                    #region 计算
                    if (e.Column == gridCol材料投入数量)
                    {
                        if (换算率 != 0)
                        {
                            gridView1.SetRowCellValue(iRow, gridCol件数, ReturnDecimal(数量 * 换算率));
                        }
                        else
                        {
                            gridView1.SetRowCellValue(iRow, gridCol件数, null);
                        }
                        if (数量 != 历史数量)
                        {
                            decimal d上游 = 0;
                            decimal d累计 = 0;
                            decimal d引用 = 0;
                            long lAutoid = -1;
                            if (gridView1.GetRowCellValue(iRow, gridColAutoID).ToString().Trim() != "")
                            {
                                lAutoid = Convert.ToInt64(gridView1.GetRowCellValue(iRow, gridColAutoID));
                            }
                            if (iCodeUsed(Convert.ToInt64(gridView1.GetRowCellValue(iRow, gridCol委外订单子表ID)), lAutoid, out d上游, out d累计, out d引用) == -1)
                            {
                                gridView1.SetRowCellValue(iRow, gridCol材料投入数量, gridView1.GetRowCellValue(iRow, gridCol历史数量));
                                MessageBox.Show("获得引用信息失败");
                            }
                            else
                            {
                                if (数量 == 0)
                                {
                                    gridView1.SetRowCellValue(iRow, gridCol材料投入数量, gridView1.GetRowCellValue(iRow, gridCol历史数量));
                                    MessageBox.Show("数量不能为0");
                                }

                                if (radioGroup蓝红标识.EditValue.ToString().Trim() == "1")
                                {
                                    if (数量 + d累计 > d上游)
                                    {
                                        //gridView1.SetRowCellValue(iRow, gridCol材料投入数量, gridView1.GetRowCellValue(iRow, gridCol历史数量));
                                        //MessageBox.Show("累计下单数量超出订单数量，订单可下入库量为" + (d上游 - d累计).ToString());
                                    }
                                    else
                                    {
                                        if (数量 + d累计 < d引用)
                                        {
                                            //gridView1.SetRowCellValue(iRow, gridCol材料投入数量, gridView1.GetRowCellValue(iRow, gridCol历史数量));
                                            //MessageBox.Show("累计下单数量低于已引用数量");
                                        }
                                    }
                                }
                                if (radioGroup蓝红标识.EditValue.ToString().Trim() == "2")
                                {
                                    if (数量 > d累计)
                                    {
                                        gridView1.SetRowCellValue(iRow, gridCol材料投入数量, gridView1.GetRowCellValue(iRow, gridCol历史数量));
                                        MessageBox.Show("红字数量超出累计下单数量");
                                        return;
                                    }
                                    if (数量 + d累计 < d引用)
                                    {
                                        //gridView1.SetRowCellValue(iRow, gridCol材料投入数量, gridView1.GetRowCellValue(iRow, gridCol历史数量));
                                        //MessageBox.Show("累计下单数量低于已引用数量");
                                        //return;
                                    }
                                }
                                if (radioGroup蓝红标识.EditValue.ToString().Trim() == "1" && 数量 < 0)
                                {
                                    gridView1.SetRowCellValue(iRow, gridCol材料投入数量, gridView1.GetRowCellValue(iRow, gridCol历史数量));
                                    MessageBox.Show("蓝字数量不能小于0");
                                }
                                if (radioGroup蓝红标识.EditValue.ToString().Trim() == "2" && 数量 > 0)
                                {
                                    gridView1.SetRowCellValue(iRow, gridCol材料投入数量, gridView1.GetRowCellValue(iRow, gridCol历史数量));
                                    MessageBox.Show("红字数量不能大于0");
                                }
                            }
                        }
                    }
                    if (e.Column == gridCol含税单价 || e.Column == gridCol材料投入数量 || e.Column == gridCol税率)
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

                #region M1
                if (e.Column == gridM1)
                {
                    string invocde = gridView1.GetRowCellValue(iRow, gridCol物料编码).ToString().Trim();
                    string M1 = gridView1.GetRowCellValue(iRow, gridM1).ToString().Trim();
                    if (invocde != "" && M1 != "")
                    {
                        bool b = false;
                        sSQL = "select M1 from Inventory where cInvCode='" + invocde + "'";
                        DataTable dts = clsSQLCommond.ExecQuery(sSQL);
                        if (dts.Rows.Count > 0)
                        {
                            string per = dts.Rows[0]["M1"].ToString();
                            per = "," + per.Replace(", ", ",") + ",";
                            if (per.IndexOf("," + M1 + ",") >= 0)
                            {
                                b = true;
                            }
                        }
                        if (b == false)
                        {
                            MessageBox.Show(invocde + "无此色号");
                            if (gridView1.GetRowCellValue(iRow, gridColM1).ToString().Trim() != "")
                            {
                                gridView1.SetRowCellValue(iRow, gridColM1, "");
                            }
                            if (gridView1.GetRowCellValue(iRow, gridM1).ToString().Trim() != "")
                            {
                                gridView1.SetRowCellValue(iRow, gridM1, "");
                            }
                        }
                    }
                    else
                    {
                        if (invocde == "")
                        {
                            MessageBox.Show(invocde + "未选择存货");
                        }
                        if (gridView1.GetRowCellValue(iRow, gridColM1).ToString().Trim() != "")
                        {
                            gridView1.SetRowCellValue(iRow, gridColM1, "");
                        }
                        if (gridView1.GetRowCellValue(iRow, gridM1).ToString().Trim() != "")
                        {
                            gridView1.SetRowCellValue(iRow, gridM1, "");
                        }
                    }
                }
                #endregion

                if (e.Column == gridCol成品量 || e.Column == gridCol成品绞数)
                {
                    if (gridView1.GetRowCellValue(iRow, gridCol成品量).ToString().Trim() != "" && gridView1.GetRowCellValue(iRow, gridCol成品绞数).ToString().Trim() != "")
                    {
                        gridView1.SetRowCellValue(iRow, gridCol成品绞重, ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol成品量)) / ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol成品绞数)));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(iRow, gridCol成品绞重, null);
                    }
                }
                if (e.Column == gridCol检验后称重 || e.Column == gridCol检验后绞数)
                {
                    if (gridView1.GetRowCellValue(iRow, gridCol检验后称重).ToString().Trim() != "" && gridView1.GetRowCellValue(iRow, gridCol检验后绞数).ToString().Trim() != "")
                    {
                        gridView1.SetRowCellValue(iRow, gridCol检验后绞重, ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol检验后称重)) / ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol检验后绞数)));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(iRow, gridCol检验后绞重, null);
                    }
                }
                if (e.Column == gridCol回潮后重量 || e.Column == gridCol回潮后绞数)
                {
                    if (gridView1.GetRowCellValue(iRow, gridCol回潮后重量).ToString().Trim() != "" && gridView1.GetRowCellValue(iRow, gridCol回潮后绞数).ToString().Trim() != "")
                    {
                        gridView1.SetRowCellValue(iRow, gridCol回潮后绞重, ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol回潮后重量)) / ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol回潮后绞数)));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(iRow, gridCol回潮后绞重, null);
                    }
                }

                if (e.Column == gridCol次品重量 || e.Column == gridCol次品绞数)
                {
                    if (gridView1.GetRowCellValue(iRow, gridCol次品重量).ToString().Trim() != "" && gridView1.GetRowCellValue(iRow, gridCol次品绞数).ToString().Trim() != "")
                    {
                        gridView1.SetRowCellValue(iRow, gridCol次品绞重, ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol次品重量)) / ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol次品绞数)));
                        gridView1.SetRowCellValue(iRow, gridCol合格率, ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol次品重量)) * 100 / ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol检验后称重)));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(iRow, gridCol次品绞重, null);
                        gridView1.SetRowCellValue(iRow, gridCol合格率, null);
                    }
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

        private void buttonEdit收货人_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(2);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit收货人.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit收货人_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit收货人.Text.Trim() != "")
                lookUpEdit收货人.EditValue = buttonEdit收货人.Text.Trim();
            else
                lookUpEdit收货人.EditValue = null;
        }

        private void buttonEdit收货人_Leave(object sender, EventArgs e)
        {
            if (buttonEdit收货人.Text.Trim() == "")
                return;
            if (lookUpEdit收货人.Text.Trim() == "")
            {
                buttonEdit收货人.Text = "";
                buttonEdit收货人.Focus();
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
                sSQL = "select count(1) from dbo.RdRecord a inner join RdRecords b on a.id = b.id and cRSCode = '" + cRsCode + "' "
                + " inner join (select RdAutoID from RdRecords union all select RdAutoID from SO_SOOutDetails ) c on c.RdAutoID = b.autoid " +
                       "where a.cRdCode = '" + sCode + "'";
                iReturn = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            return iReturn;
        }

        /// <summary>
        /// 判断单据是否已经使用
        /// </summary>
        /// <param name="sCode">子表ID</param>
        /// <returns></returns>
        private decimal iCodeUsed(long 上游ID, long 当前ID, out decimal d上游单据数量, out decimal d累计使用数量, out decimal d引用量)
        {
            decimal iReturn = -1;
            d上游单据数量 = 0;
            d累计使用数量 = 0;
            d引用量 = 0;
            try
            {
                sSQL = "select isnull(sum(b.iQuantity),0) as iQuantity,isnull(a.iQuantity,0) as iQty " +
                        "from MO_MODetails a left join RdRecords b on a.AutoID = b.RdAutoID  and b.AutoID <> " + 当前ID + " left join dbo.RdRecord c on c.id = b.id and cRSCode = '"+cRsCode+"'  " +
                       "where a.AutoID = '" + 上游ID + "' ";

                sSQL = sSQL + "group by a.AutoID,a.iQuantity";

                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt != null && dt.Rows.Count > 0)
                {
                    d累计使用数量 = Convert.ToDecimal(dt.Rows[0][0]);
                    d上游单据数量 = Convert.ToDecimal(dt.Rows[0][1]);
                }

                sSQL = @"select sum(isnull(c.iQuantity,0)) from dbo.RdRecord a inner join RdRecords b on a.id = b.id 
and cRSCode = '" + cRsCode + "' inner join (select RdAutoID,iQuantity from RdRecords union all select RdAutoID,iQuantity from SO_SOOutDetails ) c on c.RdAutoID = b.autoid " +
                   "where b.autoid = '" + 当前ID + "'";

                d引用量 = Convert.ToDecimal(clsSQLCommond.ExecGetScalar(sSQL));
                iReturn = 0;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            return iReturn;
        }

        private void buttonEdit部门_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit部门.Text.Trim() != "")
                lookUpEdit部门.EditValue = buttonEdit部门.Text.Trim();
            else
                lookUpEdit部门.EditValue = null;
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

        private void ItemButtonEditM2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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
            系统服务.Frm参照 frm = new 系统服务.Frm参照(22, invocde);
            if (DialogResult.OK == frm.ShowDialog())
            {
                gridView1.SetRowCellValue(iRow, gridColM2, frm.sID);
                frm.Enabled = true;
            }
        }

        private void buttonEdit供应商_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(23);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit供应商.EditValue = frm.sID;

                frm.Enabled = true;
            }
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
