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
    public partial class Frm成团委外入库单 : 系统服务.FrmBaseInfo
    {
        string tablename = "RdRecord03";
        string tableid = "cRDCode";
        string tablenames = "RdRecords03";
        string cRsCode = "0301";

        string cMSCode = "";

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

        public Frm成团委外入库单(long siID,string title)
        {
            iID = siID;
            
            InitializeComponent();

            this.Text = title;
        }

        public Frm成团委外入库单()
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
            Frm委外订单_New frm = new Frm委外订单_New((DataTable)gridControl1.DataSource, cMSCode);
            
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
                    gridView1.SetRowCellValue(i, gridCol数量, dtnew.Rows[s]["iQuantity"].ToString());
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
            if (gridView1.GetRowCellValue(iRow, gridCol数量).ToString().Trim() != "")
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
                    gridView1.SetRowCellValue(iRow, gridCol数量, gridView1.GetRowCellValue(iRow, gridCol历史数量));
                    throw new Exception("获得引用信息失败");
                }
                else
                {
                    if (radioGroup蓝红标识.EditValue.ToString().Trim() == "1")
                    {
                        if (数量 + d累计 > d上游)
                        {
                            gridView1.SetRowCellValue(iRow, gridCol数量, gridView1.GetRowCellValue(iRow, gridCol历史数量));
                            throw new Exception("累计下单数量超出订单数量，订单可下数量为" + (d上游 - d累计).ToString());
                        }
                        if (数量 + d累计 < d引用)
                        {
                            gridView1.SetRowCellValue(iRow, gridCol数量, gridView1.GetRowCellValue(iRow, gridCol历史数量));
                            throw new Exception("累计下单数量低于已引用数量");
                        }
                    }
                    if (radioGroup蓝红标识.EditValue.ToString().Trim() == "2")
                    {
                        if (数量 > d累计)
                        {
                            gridView1.SetRowCellValue(iRow, gridCol数量, gridView1.GetRowCellValue(iRow, gridCol历史数量));
                            throw new Exception("红字数量超出累计下单数量");
                        }
                        if (数量 + d累计 < d引用)
                        {
                            gridView1.SetRowCellValue(iRow, gridCol数量, gridView1.GetRowCellValue(iRow, gridCol历史数量));
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

            GetGroup();
        }
        /// <summary>
        /// 新增
        /// </summary>
        private void btnAdd()
        {
            if (cMSCode == "0004")
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

                sSQL = @"select autoid into #a from RdRecords03 where id=111111
select a.autoid,iQuantity into #b from #a a left join RdRecords11 b on a.autoid=b.autoid where isnull(iQuantity,0)>0
insert into #b select a.autoid,iQuantity from #a a left join RdRecords12 b on a.autoid=b.autoid where isnull(iQuantity,0)>0
insert into #b select a.autoid,iQuantity from #a a left join RdRecords13 b on a.autoid=b.autoid where isnull(iQuantity,0)>0
insert into #b select a.autoid,iQuantity from #a a left join RdRecords15 b on a.autoid=b.autoid where isnull(iQuantity,0)>0 
select * from #b     
";
                sSQL = sSQL.Replace("111111", textEditID.EditValue.ToString());
                DataTable dta = clsSQLCommond.ExecQuery(sSQL);
                if (dta.Rows.Count > 0)
                {
                    throw new Exception("单据已使用不可删除");
                }

                sSQL = "delete from " + tablename + " where ID='" + textEditID.EditValue.ToString().Trim() + "'";
                aList.Add(sSQL);
                sSQL = "delete from " + tablenames + " where ID='" + textEditID.EditValue.ToString().Trim() + "'";
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

            string sBoxErr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string sBox1 = gridView1.GetRowCellValue(i, gridCol盒号).ToString().Trim();
                string box1 = gridView1.GetRowCellValue(i, gridCol箱号).ToString().Trim();

                for (int j = i + 1; j < gridView1.RowCount; j++)
                {
                    string sBox2 = gridView1.GetRowCellValue(j, gridCol盒号).ToString().Trim();
                    string box2 = gridView1.GetRowCellValue(j, gridCol箱号).ToString().Trim();

                    if (sBox1 == sBox2 )
                    {
                        sBoxErr = sBoxErr + "行" + (i + 1).ToString() + "与 行 " + (j + 1).ToString() + " 盒号重复\n";
                        continue;
                    }
                }
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

            #region 更新变更表
            if (sState == "alter")
            {
                clsPublic.GetChange(tablename, tablenames, textEditID.EditValue.ToString().Trim(), clsGetSQL, aList);
            }
            #endregion

            sSQL = @"select autoid into #a from RdRecords03 where id=111111
select a.autoid,iQuantity into #b from #a a left join RdRecords11 b on a.autoid=b.autoid where isnull(iQuantity,0)>0
insert into #b select a.autoid,iQuantity from #a a left join RdRecords12 b on a.autoid=b.autoid where isnull(iQuantity,0)>0
insert into #b select a.autoid,iQuantity from #a a left join RdRecords13 b on a.autoid=b.autoid where isnull(iQuantity,0)>0
insert into #b select a.autoid,iQuantity from #a a left join RdRecords15 b on a.autoid=b.autoid where isnull(iQuantity,0)>0 
select * from #b     
";
            sSQL = sSQL.Replace("111111", textEditID.EditValue.ToString());
            DataTable dta = clsSQLCommond.ExecQuery(sSQL);

            #region 删行
            if (textEditDel.EditValue != null && textEditDel.EditValue.ToString().Trim() != "")
            {
                string[] strdel = textEditDel.Text.Split(',');
                for (int i = 0; i < strdel.Length; i++)
                {
                    DataRow[] dw = dta.Select("autoid=" + strdel[i]);
                    if (dw.Length > 0)
                    {
                        sErr = sErr + "行" + (i + 1) + "已使用不可删除\n";
                        continue;
                    }
                    else
                    {
                        sSQL = "delete from RdRecords03 where autoid=" + strdel[i];
                        aList.Add(sSQL);
                    }
                }
            }
            #endregion

            if (sErr != "")
            {
                throw new Exception(sErr);
            }

            //if (!bHasGrid)
            //{
            //    throw new Exception("数据不完整，不能保存");
            //}

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

            aList = new System.Collections.ArrayList();

            sSQL = "update " + tablename + " set dVerifysysTime='" + GetSystemTime() + "',dVerifysysPerson='" + 系统服务.ClsBaseDataInfo.sUid + "' where ID=" + textEditID.Text + "";
            aList.Add(sSQL);

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (radioGroup蓝红标识.EditValue.ToString() == "1")
                {
                    sSQL = "update SO_SOPackingSublist set S1=1 where sBoxNo='" + gridView1.GetRowCellValue(i, gridCol盒号).ToString() + "' ";
                }
                else
                {
                    sSQL = "update SO_SOPackingSublist set S1=null where sBoxNo='" + gridView1.GetRowCellValue(i, gridCol盒号).ToString() + "' ";
                }
                aList.Add(sSQL);
            }

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

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (radioGroup蓝红标识.EditValue.ToString() == "1")
                {
                    sSQL = "update SO_SOPackingSublist set S1=null where sBoxNo='" + gridView1.GetRowCellValue(i, gridCol盒号).ToString() + "' ";
                }
                else
                {
                    sSQL = "update SO_SOPackingSublist set S1=1 where sBoxNo='" + gridView1.GetRowCellValue(i, gridCol盒号).ToString() + "' ";
                }
                aList.Add(sSQL);
            }

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

        private void Frm成团委外入库单_Load(object sender, EventArgs e)
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
            sSQL = "select * from MOStyle where cMSName='" + title + "'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt.Rows.Count > 0)
            {
                cSQL = " and cMSCode='" + dt.Rows[0]["cMSCode"].ToString() + "'";
                cMSCode = dt.Rows[0]["cMSCode"].ToString();
                
                cWhCodeIn = dt.Rows[0]["S2"].ToString();
            }
        }

        private void GetGrid()
        {
            if (iID != -1)
            {
                sSQL = "select * from " + tablename + " where cRSCode='" + cRsCode + "' and ID=" + iID;
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

                    gridView1.FocusedRowHandle = iFocRow;
                    GetGroup();
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


        private void GetGroup()
        {
            DataView dv = new DataView(dtBingGrid);
            DataTable dtgroup = dv.ToTable(true, new string[] { "cInvCode", "M1", "M2", "BoxNo" });
            dtgroup.Columns.Add("sBoxQty");
            dtgroup.Columns.Add("iQuantity");
            for (int i = 0; i < dtgroup.Rows.Count; i++)
            {
                dtgroup.Rows[i]["sBoxQty"] = dtBingGrid.Compute("sum(sBoxQty)", "cInvCode='" + dtgroup.Rows[i]["cInvCode"].ToString() + "' and M1='" + dtgroup.Rows[i]["M1"].ToString() + "' and M2='" + dtgroup.Rows[i]["M2"].ToString() + "' and BoxNo='" + dtgroup.Rows[i]["BoxNo"].ToString() + "'");
                dtgroup.Rows[i]["iQuantity"] = dtBingGrid.Compute("sum(iQuantity)", "cInvCode='" + dtgroup.Rows[i]["cInvCode"].ToString() + "' and M1='" + dtgroup.Rows[i]["M1"].ToString() + "' and M2='" + dtgroup.Rows[i]["M2"].ToString() + "' and BoxNo='" + dtgroup.Rows[i]["BoxNo"].ToString() + "'");
            }
            gridControl2.DataSource = dtgroup;
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

            系统服务.LookUp.ColorNo(ItemLookUpM1);

            系统服务.LookUp.Inventory(ItemLookUpEdit物料名称);
            ItemLookUpEdit物料名称.Properties.DisplayMember = "cInvName";
            系统服务.LookUp.Inventory(ItemLookUpEdit物料规格);
            ItemLookUpEdit物料规格.Properties.DisplayMember = "cInvStd";
            系统服务.LookUp.Inventory(ItemLookUpEdit物料代码);
            ItemLookUpEdit物料规格.Properties.DisplayMember = "cInvAddCode";

            系统服务.LookUp.Inventory(ItemLookUp存货名称);
            ItemLookUp存货名称.Properties.DisplayMember = "cInvName";

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
                                gridView1.SetRowCellValue(iRow, gridCol数量, gridView1.GetRowCellValue(iRow, gridCol历史数量));
                                MessageBox.Show("获得引用信息失败");
                            }
                            else
                            {
                                if (数量 == 0)
                                {
                                    gridView1.SetRowCellValue(iRow, gridCol数量, gridView1.GetRowCellValue(iRow, gridCol历史数量));
                                    MessageBox.Show("数量不能为0");
                                }

                                if (radioGroup蓝红标识.EditValue.ToString().Trim() == "1")
                                {
                                    if (数量 + d累计 > d上游)
                                    {
                                        gridView1.SetRowCellValue(iRow, gridCol数量, gridView1.GetRowCellValue(iRow, gridCol历史数量));
                                        MessageBox.Show("累计下单数量超出订单数量，订单可下入库量为" + (d上游 - d累计).ToString());
                                    }
                                    else
                                    {
                                        if (数量 + d累计 < d引用)
                                        {
                                            gridView1.SetRowCellValue(iRow, gridCol数量, gridView1.GetRowCellValue(iRow, gridCol历史数量));
                                            MessageBox.Show("累计下单数量低于已引用数量");
                                        }
                                    }
                                }
                                if (radioGroup蓝红标识.EditValue.ToString().Trim() == "2")
                                {
                                    if (数量 > d累计)
                                    {
                                        gridView1.SetRowCellValue(iRow, gridCol数量, gridView1.GetRowCellValue(iRow, gridCol历史数量));
                                        MessageBox.Show("红字数量超出累计下单数量");
                                        return;
                                    }
                                    if (数量 + d累计 < d引用)
                                    {
                                        gridView1.SetRowCellValue(iRow, gridCol数量, gridView1.GetRowCellValue(iRow, gridCol历史数量));
                                        MessageBox.Show("累计下单数量低于已引用数量");
                                        return;
                                    }
                                }
                                if (radioGroup蓝红标识.EditValue.ToString().Trim() == "1" && 数量 < 0)
                                {
                                    gridView1.SetRowCellValue(iRow, gridCol数量, gridView1.GetRowCellValue(iRow, gridCol历史数量));
                                    MessageBox.Show("蓝字数量不能小于0");
                                }
                                if (radioGroup蓝红标识.EditValue.ToString().Trim() == "2" && 数量 > 0)
                                {
                                    gridView1.SetRowCellValue(iRow, gridCol数量, gridView1.GetRowCellValue(iRow, gridCol历史数量));
                                    MessageBox.Show("红字数量不能大于0");
                                }
                            }
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

                //#region M2
                //if (e.Column == gridM2)
                //{
                //    string invocde = gridView1.GetRowCellValue(iRow, gridCol物料编码).ToString().Trim();
                //    string M2 = gridView1.GetRowCellValue(iRow, gridM2).ToString().Trim();
                //    if (invocde != "" && M2 != "")
                //    {
                //        bool b = false;
                //        sSQL = "select M2 from Inventory where cInvCode='" + invocde + "'";
                //        DataTable dts = clsSQLCommond.ExecQuery(sSQL);
                //        if (dts.Rows.Count > 0)
                //        {
                //            string per = dts.Rows[0]["M2"].ToString();
                //            per = "," + per.Replace(", ", ",") + ",";
                //            if (per.IndexOf("," + M2 + ",") >= 0)
                //            {
                //                b = true;
                //            }
                //        }
                //        if (b == false)
                //        {
                //            MessageBox.Show(invocde + "无此色号");
                //            if (gridView1.GetRowCellValue(iRow, gridColM2).ToString().Trim() != "")
                //            {
                //                gridView1.SetRowCellValue(iRow, gridColM2, "");
                //            }
                //            if (gridView1.GetRowCellValue(iRow, gridM2).ToString().Trim() != "")
                //            {
                //                gridView1.SetRowCellValue(iRow, gridM2, "");
                //            }
                //        }
                //    }
                //    else
                //    {
                //        if (invocde == "")
                //        {
                //            MessageBox.Show(invocde + "未选择存货");
                //        }
                //        if (gridView1.GetRowCellValue(iRow, gridColM2).ToString().Trim() != "")
                //        {
                //            gridView1.SetRowCellValue(iRow, gridColM2, "");
                //        }
                //        if (gridView1.GetRowCellValue(iRow, gridM2).ToString().Trim() != "")
                //        {
                //            gridView1.SetRowCellValue(iRow, gridM2, "");
                //        }
                //    }
                //}
                //#endregion

                if (e.Column == gridCol绞数 || e.Column == gridCol绞重)
                {
                    if (gridView1.GetRowCellValue(iRow, gridCol绞数).ToString().Trim() != "" && gridView1.GetRowCellValue(iRow, gridCol绞重).ToString().Trim() != "")
                    {
                        gridView1.SetRowCellValue(iRow, gridCol数量, ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol绞数)) * ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol绞重)));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(iRow, gridCol数量, null);
                    }
                }
                if (e.Column == gridCol检验后绞数 || e.Column == gridCol检验后绞重)
                {
                    if (gridView1.GetRowCellValue(iRow, gridCol检验后绞数).ToString().Trim() != "" && gridView1.GetRowCellValue(iRow, gridCol检验后绞重).ToString().Trim() != "")
                    {
                        gridView1.SetRowCellValue(iRow, gridCol检验后标重, ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol检验后绞数)) * ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol检验后绞重)));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(iRow, gridCol检验后标重, null);
                    }
                }
                if (e.Column == gridCol数量 || e.Column == gridCol检验后标重)
                {
                    if (gridView1.GetRowCellValue(iRow, gridCol数量).ToString().Trim() != "" && gridView1.GetRowCellValue(iRow, gridCol检验后标重).ToString().Trim() != "")
                    {
                        gridView1.SetRowCellValue(iRow, gridCol次品重量, ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol数量)) - ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol检验后标重)));
                        gridView1.SetRowCellValue(iRow, gridCol合格率, ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol数量)) * 100 / ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol检验后标重)));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(iRow, gridCol次品重量, null);
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
                sSQL = @"
                select count(1) from dbo.RdRecord13 a inner join RdRecords13 b on a.id = b.id left join dbo.RdRecords03 c on b.RdAutoID=c.AutoID "
                + " where c.cRdCode = '" + sCode + "'";
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
                        "from MO_MODetails a left join RdRecords13 b on a.AutoID = b.RdAutoID  and b.AutoID <> " + 当前ID + " left join dbo.RdRecord13 c on c.id = b.id and cRSCode = '"+cRsCode+"'  " +
                       "where a.AutoID = '" + 上游ID + "' ";

                sSQL = sSQL + "group by a.AutoID,a.iQuantity";

                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt != null && dt.Rows.Count > 0)
                {
                    d累计使用数量 = Convert.ToDecimal(dt.Rows[0][0]);
                    d上游单据数量 = Convert.ToDecimal(dt.Rows[0][1]);
                }

                sSQL = @"
select RdAutoID,iQuantity into #a from RdRecords13 
insert into #a select RdAutoID,iQuantity from RdRecords13

select sum(isnull(c.iQuantity,0)) from dbo.RdRecord13 a inner join RdRecords13 b on a.id = b.id 
and cRSCode = '" + cRsCode + "' inner join #a c on c.RdAutoID = b.autoid " +
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
