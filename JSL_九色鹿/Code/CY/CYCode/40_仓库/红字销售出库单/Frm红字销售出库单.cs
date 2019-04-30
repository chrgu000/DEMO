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
    public partial class Frm红字销售出库单 : 系统服务.FrmBaseInfo
    {
        decimal 乘数 = 1M;
        string tablename = "SO_SOOutMain";
        string tableid = "ID";
        string tablecode = "cSOOutCode";
        string tablenames = "SO_SOOutDetails";
        string tablenamel = "SO_SOOutSublist";

        string cSQL = " and iType=1 and Flag=2";
        string iType = "1";
        string Flag = "2";

        bool is散件 = false;

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
        public string ECode = "";
        public string 删除 = "";

        public string s销售订单号 = "";

        public DataTable dt子件;

        string isChange = "";

        public Frm红字销售出库单(long siID)
        {
            iID = siID;
            InitializeComponent();

        }

        public Frm红字销售出库单()
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
        /// 输出 打印盒号
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
        /// 导入 打印箱号
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
            Frm红字销售出库单_Add frm = new Frm红字销售出库单_Add(单据号1, 单据号2, 单据日期1, 单据日期2, 制单日期1, 制单日期2, 业务员,
               部门, 客户1, 客户2, 审核日期1, 审核日期2, 制单人1, 制单人2, 审核人1, 审核人2, 物料1, 物料2,ECode,iType,Flag);
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
                ECode = frm.ECode;
                GetSel();
            }

        }

        private void GetSel()
        {
            string sSQL = "select * from " + tablename + " a left join " + tablenames + "  b on a.ID=b.ID where 1=1 " + cSQL;
            if (单据号1 != null && 单据号1 != "")
            {
                sSQL = sSQL + " and a." + tablecode + ">='" + 单据号1 + "'";
            }
            if (单据号2 != null && 单据号2 != "")
            {
                sSQL = sSQL + " and a." + tablecode + "<='" + 单据号2 + "'";
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
            if (物料1 != "")
            {
                sSQL = sSQL + " and cInvCode>='" + 物料1 + "'";
            }
            if (物料2 != "")
            {
                sSQL = sSQL + " and cInvCode<='" + 物料2 + "'";
            }
            if (ECode != "")
            {
                sSQL = sSQL + " and ECode like '%" + ECode + "%'";
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
                sSQL = "select min(ID) as ID from " + tablename + "  where 1=1 " + cSQL;
                sSQL = sSQL + " order by ID";

                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]); ;
                    iID = Convert.ToInt64(dt.Rows[0]["ID"]);
                }
                GetGrid();
            }
            catch
            {
                MessageBox.Show("翻页失败");
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
                    sSQL = "select ID from " + tablename + " where ID<" + textEditID.EditValue.ToString().Trim() + cSQL;

                    sSQL = sSQL + " order by ID desc";

                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt.Rows.Count > 0)
                    {
                        textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]); ;
                        iID = Convert.ToInt64(dt.Rows[0]["ID"]); ;
                    }
                    GetGrid();
                }
            }
            catch
            {
                MessageBox.Show("翻页失败");
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
                    sSQL = "select ID from " + tablename + " where ID>" + textEditID.EditValue.ToString().Trim() + cSQL;

                    sSQL = sSQL + " order by ID";

                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt.Rows.Count > 0)
                    {
                        textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]); ;
                        iID = Convert.ToInt64(dt.Rows[0]["ID"]); ;
                    }
                    GetGrid();
                }
            }
            catch
            {
                MessageBox.Show("翻页失败");
            }
        }
        /// <summary>
        /// 末页
        /// </summary>
        private void btnLast()
        {
            try
            {
                sSQL = "select isnull(max(ID),-1) as ID from " + tablename + " where 1=1  " + cSQL;

                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]); ;
                    iID = Convert.ToInt64(dt.Rows[0]["ID"]); ;
                }
                GetGrid();
            }
            catch
            {
                MessageBox.Show("翻页失败");
            }
        }

        /// <summary>
        /// 锁定
        /// </summary>
        private void btnLock()
        {
            decimal 数量 = 0;
            string cInvCode = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellDisplayText(i, gridCol数量) != null && gridView1.GetRowCellDisplayText(i, gridCol数量).Trim() != "")
                {
                    数量 = 数量 + ReturnDecimal(gridView1.GetRowCellDisplayText(i, gridCol数量).Trim());
                }
                if (i == 0)
                {
                    if (gridView1.GetRowCellDisplayText(i, gridCol物料编码) != null && gridView1.GetRowCellDisplayText(i, gridCol物料编码).Trim() != "")
                    {
                        cInvCode = gridView1.GetRowCellDisplayText(i, gridCol物料编码).Trim();
                    }
                }
            }
            if (数量 == 0)
            {
                throw new Exception("请先输入数量");
            }
            bool b = false;
            if (sState == "add" || sState == "edit" || sState == "alter")
            {
                b = true;
            }
        }
        /// <summary>
        /// 解锁  子件
        /// </summary>
        private void btnUnLock()
        {
            throw new NotImplementedException();

        }
        /// <summary>
        /// 增行 引用
        /// </summary>
        private void btnAddRow()
        {
            if (radioGroup蓝红标识.EditValue == null)
            {
                radioGroup蓝红标识.EditValue = "";
            }
            DataTable dtt = (DataTable)gridControl1.DataSource;
            DataTable dtt2 = (DataTable)gridControl2.DataSource;
            if (dtt.Rows.Count > 0)
            {
                s销售订单号 = dtt.Rows[0]["AutoID"].ToString();
            }
            else
            {
                s销售订单号 = "";
            }
            Frm销售出库单_New frm = new Frm销售出库单_New(buttonEdit客户.Text.ToString().Trim(), dtt, s销售订单号, radioGroup蓝红标识.EditValue.ToString().Trim(), iType, dtt2);
            if (lookUpEdit客户.EditValue == null)
                frm.客户 = "";
            else
                frm.客户 = lookUpEdit客户.EditValue.ToString().Trim();

            frm.红蓝标志 = radioGroup蓝红标识.EditValue.ToString().Trim();

            if (DialogResult.OK == frm.ShowDialog())
            {
                if (frm.客户 != "")
                {
                    buttonEdit客户.Enabled = false;
                }
                if (radioGroup蓝红标识.EditValue != "")
                {
                    radioGroup蓝红标识.Enabled = false;
                }
                if (lookUpEdit客户.EditValue != null && lookUpEdit客户.EditValue != "" && frm.客户.Trim() != lookUpEdit客户.EditValue.ToString().Trim() && frm.客户.Trim() != "")
                {
                    throw new Exception("一张单据只能有一个客户");
                }
                if (radioGroup蓝红标识.EditValue != "" && frm.红蓝标志.Trim() != radioGroup蓝红标识.EditValue.ToString().Trim())
                {
                    throw new Exception("红蓝标志不能修改");
                }

                radioGroup蓝红标识.EditValue = frm.红蓝标志;
                buttonEdit客户.EditValue = frm.客户;
                frm.Enabled = true;
                DataTable dtnew = frm.dt;

                if (iType == "1")
                {
                    for (int s = 0; s < dtnew.Rows.Count; s++)
                    {
                        gridView1.AddNewRow();
                        int iRow = gridView1.RowCount - 1;
                        gridView1.FocusedRowHandle = iRow;
                        gridView1.SetRowCellValue(iRow, gridCol行标记, iRow + 1);
                        gridView1.SetRowCellValue(iRow, gridCol序号, iRow + 1);
                        decimal 换算率 = 0;
                        if (dtnew.Rows[s]["iChangRate"].ToString() != "" && dtnew.Rows[s]["iChangRate"].ToString() != "0")
                        {
                            换算率 = ReturnDecimal(dtnew.Rows[s]["iChangRate"].ToString(), 6);
                        }
                        gridView1.SetRowCellValue(iRow, gridCol物料编码, dtnew.Rows[s]["cInvCode"].ToString());
                        gridView1.SetRowCellValue(iRow, gridCol数量, dtnew.Rows[s]["iQuantity"].ToString());
                        gridView1.SetRowCellValue(iRow, gridCol历史数量, dtnew.Rows[s]["iQuantity"].ToString());
                        gridView1.SetRowCellValue(iRow, gridCol销售出库单AutoID, dtnew.Rows[s]["AutoID"].ToString());
                        gridView1.SetRowCellValue(iRow, gridCol销售订单AutoID, dtnew.Rows[s]["SoAutoID"].ToString());
                        gridView1.SetRowCellValue(iRow, gridCol出入库单子表ID, dtnew.Rows[s]["RdAutoID"].ToString());
                        gridView1.SetRowCellValue(iRow, gridCol箱号, dtnew.Rows[s]["BoxNo"].ToString());
                        gridView1.SetRowCellValue(iRow, gridCol箱数, dtnew.Rows[s]["BoxQty"].ToString());
                        if (dtnew.Rows[s]["iNum"].ToString() != "")
                        {
                            gridView1.SetRowCellValue(iRow, gridCol件数, dtnew.Rows[s]["iNum"].ToString());
                        }
                        if (dtnew.Rows[s]["iUnitPrice"].ToString() != "")
                        {
                            gridView1.SetRowCellValue(iRow, gridCol含税单价, dtnew.Rows[s]["iUnitPrice"].ToString());
                        }
                        if (dtnew.Rows[s]["iMoney"].ToString() != "")
                        {
                            gridView1.SetRowCellValue(iRow, gridCol含税金额, dtnew.Rows[s]["iMoney"].ToString());
                        }
                        if (dtnew.Rows[s]["iNatUnitPrice"].ToString() != "")
                        {
                            gridView1.SetRowCellValue(iRow, gridCol无税单价, dtnew.Rows[s]["iNatUnitPrice"].ToString());
                        }
                        if (dtnew.Rows[s]["iNatMoney"].ToString() != "")
                        {
                            gridView1.SetRowCellValue(iRow, gridCol无税金额, dtnew.Rows[s]["iNatMoney"].ToString());
                        }
                        if (dtnew.Rows[s]["iTaxRate"].ToString() != "")
                        {
                            gridView1.SetRowCellValue(iRow, gridCol税率, dtnew.Rows[s]["iTaxRate"].ToString());
                        }
                        if (dtnew.Rows[s]["iChangRate"].ToString() != "")
                        {
                            gridView1.SetRowCellValue(iRow, gridCol换算率, dtnew.Rows[s]["iChangRate"].ToString());
                        }

                        if (dtnew.Rows[s]["M1"].ToString() != "")
                        {
                            gridView1.SetRowCellValue(iRow, gridColM1, dtnew.Rows[s]["M1"].ToString());
                        }
                        if (dtnew.Rows[s]["M2"].ToString() != "")
                        {
                            gridView1.SetRowCellValue(iRow, gridColM2, dtnew.Rows[s]["M2"].ToString());
                        }
                        if (dtnew.Rows[s]["M3"].ToString() != "")
                        {
                            gridView1.SetRowCellValue(iRow, gridColM3, dtnew.Rows[s]["M3"].ToString());
                        }
                        if (dtnew.Rows[s]["M4"].ToString() != "")
                        {
                            gridView1.SetRowCellValue(iRow, gridColM4, dtnew.Rows[s]["M4"].ToString());
                        }
                        if (dtnew.Rows[s]["M5"].ToString() != "")
                        {
                            gridView1.SetRowCellValue(iRow, gridColM5, dtnew.Rows[s]["M5"].ToString());
                        }
                        if (dtnew.Rows[s]["M6"].ToString() != "")
                        {
                            gridView1.SetRowCellValue(iRow, gridColM6, dtnew.Rows[s]["M6"].ToString());
                        }
                        if (dtnew.Rows[s]["M7"].ToString() != "")
                        {
                            gridView1.SetRowCellValue(iRow, gridColM7, dtnew.Rows[s]["M7"].ToString());
                        }
                        if (dtnew.Rows[s]["M8"].ToString() != "")
                        {
                            gridView1.SetRowCellValue(iRow, gridColM8, dtnew.Rows[s]["M8"].ToString());
                        }
                        if (dtnew.Rows[s]["M9"].ToString() != "")
                        {
                            gridView1.SetRowCellValue(iRow, gridColM9, dtnew.Rows[s]["M9"].ToString());
                        }
                        if (dtnew.Rows[s]["M10"].ToString() != "")
                        {
                            gridView1.SetRowCellValue(iRow, gridColM10, dtnew.Rows[s]["M10"].ToString());
                        }
                        gridView1.SetRowCellValue(iRow, gridColiSave, "add");

                        sSQL = "select * from SO_SOOutSublist where AutoID='" + dtnew.Rows[s]["AutoID"].ToString() + "'";
                        DataTable dttmp = clsSQLCommond.ExecQuery(sSQL);
                        for (int j = 0; j < dttmp.Rows.Count; j++)
                        {
                            gridView2.AddNewRow();
                            int siRow = gridView2.RowCount - 1;
                            gridView2.FocusedRowHandle = siRow;
                            gridView2.SetRowCellValue(siRow, grid行标记, iRow + 1);
                            gridView2.SetRowCellValue(siRow, grid序号, iRow + 1);
                            gridView2.SetRowCellValue(siRow, grid销售订单AutoID, dtnew.Rows[s]["SoAutoID"].ToString());
                            gridView2.SetRowCellValue(siRow, grid销售订单sID, dttmp.Rows[j]["sID"].ToString());
                            gridView2.SetRowCellValue(siRow, grid箱号, dttmp.Rows[j]["BoxNo"].ToString());
                            gridView2.SetRowCellValue(siRow, gridCol物料编码, dttmp.Rows[j]["cInvCode"].ToString());
                            gridView2.SetRowCellValue(siRow, gridiSave, "add");
                            gridView2.SetRowCellValue(siRow, gridM1, dttmp.Rows[j]["M1"]);
                            gridView2.SetRowCellValue(siRow, gridM2, dttmp.Rows[j]["M2"]);
                            gridView2.SetRowCellValue(siRow, gridM3, dttmp.Rows[j]["M3"]);
                            gridView2.SetRowCellValue(siRow, gridM4, dttmp.Rows[j]["M4"]);
                            gridView2.SetRowCellValue(siRow, gridM5, dttmp.Rows[j]["M5"]);
                            gridView2.SetRowCellValue(siRow, gridM6, dttmp.Rows[j]["M6"]);
                            gridView2.SetRowCellValue(siRow, gridM7, dttmp.Rows[j]["M7"]);
                            gridView2.SetRowCellValue(siRow, gridM8, dttmp.Rows[j]["M8"]);
                            gridView2.SetRowCellValue(siRow, gridM9, dttmp.Rows[j]["M9"]);
                            gridView2.SetRowCellValue(siRow, gridM10, dttmp.Rows[j]["M10"]);

                            gridView2.SetRowCellValue(siRow, grid引用销售出库单AutoID, dttmp.Rows[j]["AutoID"].ToString());
                            gridView2.SetRowCellValue(siRow, gridsID, dttmp.Rows[j]["sID"].ToString());
                            gridView2.SetRowCellValue(siRow, gridiSave, "add");

                            gridView2.SetRowCellValue(siRow, grid盒号, dttmp.Rows[j]["sBoxNo"].ToString());
                            gridView2.SetRowCellValue(siRow, grid盒数, -1);
                            decimal s数量 = ReturnDecimal("-" + dttmp.Rows[j]["iQuantity"].ToString());
                            gridView2.SetRowCellValue(siRow, gridCol数量, s数量);
                            if (换算率 != 0)
                            {
                                gridView2.SetRowCellValue(siRow, grid换算率, 换算率);
                                gridView2.SetRowCellValue(siRow, grid件数, s数量 * 换算率);
                            }

                        }
                    }
                }
                else
                {
                    DataView dv = new DataView(dtnew);
                    DataTable dtgroup = dv.ToTable(true, "AutoID");
                    for (int s = 0; s < dtgroup.Rows.Count; s++)
                    {
                        gridView1.AddNewRow();
                        int iRow = gridView1.RowCount - 1;
                        gridView1.FocusedRowHandle = iRow;
                        gridView1.SetRowCellValue(iRow, gridCol行标记, iRow + 1);
                        gridView1.SetRowCellValue(iRow, gridCol序号, iRow + 1);
                        decimal 换算率 = 0;
                        if (dtnew.Rows[s]["iChangRate"].ToString() != "" && dtnew.Rows[s]["iChangRate"].ToString() != "0")
                        {
                            换算率 = ReturnDecimal(dtnew.Rows[s]["iChangRate"].ToString(), 6);
                        }
                        gridView1.SetRowCellValue(iRow, gridCol物料编码, dtnew.Rows[s]["cInvCode"].ToString());
                        gridView1.SetRowCellValue(iRow, gridCol数量, dtnew.Compute("sum(iQuantity)", "AutoID='" + dtgroup.Rows[s]["AutoID"].ToString() + "'"));
                        gridView1.SetRowCellValue(iRow, gridCol历史数量, dtnew.Compute("sum(iQuantity)", "AutoID='" + dtgroup.Rows[s]["AutoID"].ToString() + "'"));
                        gridView1.SetRowCellValue(iRow, gridCol销售出库单AutoID, dtnew.Rows[s]["AutoID"].ToString());
                        gridView1.SetRowCellValue(iRow, gridCol销售订单AutoID, dtnew.Rows[s]["SoAutoID"].ToString());
                        gridView1.SetRowCellValue(iRow, gridCol出入库单子表ID, dtnew.Rows[s]["RdAutoID"].ToString());
                        if (dtnew.Compute("sum(iNum)", "AutoID='" + dtgroup.Rows[s]["AutoID"].ToString() + "'").ToString() != "")
                        {
                            gridView1.SetRowCellValue(iRow, gridCol件数,dtnew.Compute("sum(iNum)", "AutoID='" + dtgroup.Rows[s]["AutoID"].ToString() + "'")); 
                        }
                        if (dtnew.Compute("max(iUnitPrice)", "AutoID='" + dtgroup.Rows[s]["AutoID"].ToString() + "'").ToString() != "")
                        {
                            gridView1.SetRowCellValue(iRow, gridCol含税单价, dtnew.Compute("max(iUnitPrice)", "AutoID='" + dtgroup.Rows[s]["AutoID"].ToString() + "'"));
                        }
                        if (dtnew.Compute("sum(iMoney)", "AutoID='" + dtgroup.Rows[s]["AutoID"].ToString() + "'").ToString() != "")
                        {
                            gridView1.SetRowCellValue(iRow, gridCol含税金额,  dtnew.Compute("sum(iMoney)", "AutoID='" + dtgroup.Rows[s]["AutoID"].ToString() + "'"));
                        }
                        if (dtnew.Compute("max(iNatUnitPrice)", "AutoID='" + dtgroup.Rows[s]["AutoID"].ToString() + "'").ToString() != "")
                        {
                            gridView1.SetRowCellValue(iRow, gridCol无税单价,  dtnew.Compute("max(iNatUnitPrice)", "AutoID='" + dtgroup.Rows[s]["AutoID"].ToString() + "'")); 
                        }
                        if (dtnew.Compute("sum(iNatMoney)", "AutoID='" + dtgroup.Rows[s]["AutoID"].ToString() + "'").ToString() != "")
                        {
                            gridView1.SetRowCellValue(iRow, gridCol无税金额, dtnew.Compute("sum(iNatMoney)", "AutoID='" + dtgroup.Rows[s]["AutoID"].ToString() + "'")); 
                        }
                        if (dtnew.Compute("max(iTaxRate)", "AutoID='" + dtgroup.Rows[s]["AutoID"].ToString() + "'").ToString() != "")
                        {
                            gridView1.SetRowCellValue(iRow, gridCol税率, dtnew.Compute("max(iTaxRate)", "AutoID='" + dtgroup.Rows[s]["AutoID"].ToString() + "'")); 
                        }
                        if (dtnew.Compute("max(iTaxRate)", "AutoID='" + dtgroup.Rows[s]["AutoID"].ToString() + "'").ToString() != "")
                        {
                            gridView1.SetRowCellValue(iRow, gridCol换算率, dtnew.Compute("max(iTaxRate)", "AutoID='" + dtgroup.Rows[s]["AutoID"].ToString() + "'"));
                        }
                            gridView1.SetRowCellValue(iRow, gridColM1, dtnew.Compute("max(M1)", "AutoID='" + dtgroup.Rows[s]["AutoID"].ToString() + "'")); 
                            gridView1.SetRowCellValue(iRow, gridColM2, dtnew.Compute("max(M2)", "AutoID='" + dtgroup.Rows[s]["AutoID"].ToString() + "'")); 
                            gridView1.SetRowCellValue(iRow, gridColM3, dtnew.Compute("max(M3)", "AutoID='" + dtgroup.Rows[s]["AutoID"].ToString() + "'")); 
                            gridView1.SetRowCellValue(iRow, gridColM4, dtnew.Compute("max(M4)", "AutoID='" + dtgroup.Rows[s]["AutoID"].ToString() + "'")); 
                            gridView1.SetRowCellValue(iRow, gridColM5, dtnew.Compute("max(M5)", "AutoID='" + dtgroup.Rows[s]["AutoID"].ToString() + "'")); 
                            gridView1.SetRowCellValue(iRow, gridColM6, dtnew.Compute("max(M6)", "AutoID='" + dtgroup.Rows[s]["AutoID"].ToString() + "'")); 
                            gridView1.SetRowCellValue(iRow, gridColM7, dtnew.Compute("max(M7)", "AutoID='" + dtgroup.Rows[s]["AutoID"].ToString() + "'")); 
                            gridView1.SetRowCellValue(iRow, gridColM8, dtnew.Compute("max(M8)", "AutoID='" + dtgroup.Rows[s]["AutoID"].ToString() + "'")); 
                            gridView1.SetRowCellValue(iRow, gridColM9, dtnew.Compute("max(M9)", "AutoID='" + dtgroup.Rows[s]["AutoID"].ToString() + "'")); 
                            gridView1.SetRowCellValue(iRow, gridColM10, dtnew.Compute("max(M10)", "AutoID='" + dtgroup.Rows[s]["AutoID"].ToString() + "'")); 
                        gridView1.SetRowCellValue(iRow, gridColiSave, "add");

                        DataRow[] dw = dtnew.Select("AutoID='" + dtgroup.Rows[s]["AutoID"].ToString() + "'");
                        for (int r = 0; r < dw.Length; r++)
                        {
                            sSQL = "select * from SO_SOOutSublist where AutoID='" + dtnew.Rows[s]["AutoID"].ToString() + "' and sID='"+dw[r]["sID"].ToString()+"'";
                            DataTable dttmp = clsSQLCommond.ExecQuery(sSQL);
                            for (int j = 0; j < dttmp.Rows.Count; j++)
                            {
                                gridView2.AddNewRow();
                                int siRow = gridView2.RowCount - 1;
                                gridView2.FocusedRowHandle = siRow;
                                gridView2.SetRowCellValue(siRow, grid行标记, iRow + 1);
                                gridView2.SetRowCellValue(siRow, grid序号, iRow + 1);
                                gridView2.SetRowCellValue(siRow, grid箱号, dttmp.Rows[j]["BoxNo"].ToString());
                                gridView2.SetRowCellValue(siRow, grid销售订单AutoID, dtnew.Rows[s]["SoAutoID"].ToString());
                                gridView2.SetRowCellValue(siRow, grid引用销售出库单AutoID, dttmp.Rows[j]["AutoID"].ToString());
                                gridView2.SetRowCellValue(siRow, gridsID, dttmp.Rows[j]["sID"].ToString());
                                
                                gridView2.SetRowCellValue(siRow, gridCol物料编码, dttmp.Rows[j]["cInvCode"].ToString());
                                gridView2.SetRowCellValue(siRow, gridiSave, "add");
                                gridView2.SetRowCellValue(siRow, gridM1, dttmp.Rows[j]["M1"]);
                                gridView2.SetRowCellValue(siRow, gridM2, dttmp.Rows[j]["M2"]);
                                gridView2.SetRowCellValue(siRow, gridM3, dttmp.Rows[j]["M3"]);
                                gridView2.SetRowCellValue(siRow, gridM4, dttmp.Rows[j]["M4"]);
                                gridView2.SetRowCellValue(siRow, gridM5, dttmp.Rows[j]["M5"]);
                                gridView2.SetRowCellValue(siRow, gridM6, dttmp.Rows[j]["M6"]);
                                gridView2.SetRowCellValue(siRow, gridM7, dttmp.Rows[j]["M7"]);
                                gridView2.SetRowCellValue(siRow, gridM8, dttmp.Rows[j]["M8"]);
                                gridView2.SetRowCellValue(siRow, gridM9, dttmp.Rows[j]["M9"]);
                                gridView2.SetRowCellValue(siRow, gridM10, dttmp.Rows[j]["M10"]);

                                
                                
                                gridView2.SetRowCellValue(siRow, gridiSave, "add");

                                gridView2.SetRowCellValue(siRow, grid盒号, dttmp.Rows[j]["sBoxNo"].ToString());
                                gridView2.SetRowCellValue(siRow, grid盒数, -1);
                                decimal s数量 = ReturnDecimal("-" + dttmp.Rows[j]["iQuantity"].ToString());
                                gridView2.SetRowCellValue(siRow, gridCol数量, s数量);
                                if (换算率 != 0)
                                {
                                    gridView2.SetRowCellValue(siRow, grid换算率, 换算率);
                                    gridView2.SetRowCellValue(siRow, grid件数, s数量 * 换算率);
                                }
                            }

                        }
                    }
                }
            }
        }

        /// <summary>
        /// 删行
        /// </summary>
        private void btnDelRow()
        {
            string sErr = "";
            for (int i = gridView1.RowCount - 1; i >= 0; i--)
            {
                if (gridView1.IsRowSelected(i))
                {
                    long lAutoid = -1;
                    if (gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim() != "")
                    {
                        lAutoid = Convert.ToInt64(gridView1.GetRowCellValue(i, gridColAutoID));
                    }
                    if (lAutoid > -1)
                    {
                        decimal 引用量 = iCodeUsed(lAutoid);
                        if (引用量 <= 0)
                        {
                            if (textEditDel.EditValue != null && textEditDel.EditValue.ToString().Trim() != "")
                            {
                                textEditDel.EditValue = textEditDel.EditValue.ToString().Trim() + "," + lAutoid.ToString().Trim();
                            }
                            else
                            {
                                textEditDel.EditValue = lAutoid.ToString().Trim();
                            }

                            string 序号 = gridView1.GetRowCellValue(i, gridCol序号).ToString();
                            for (int j = gridView2.RowCount - 1; j >= 0; j--)
                            {
                                if (序号 == gridView2.GetRowCellValue(j, grid序号).ToString().Trim())
                                {
                                    long slAutoid = -1;
                                    if (gridView2.GetRowCellValue(j, gridsID).ToString().Trim() != "")
                                    {
                                        slAutoid = Convert.ToInt64(gridView2.GetRowCellValue(j, gridsID));
                                    }
                                    if (textEditDelS.EditValue != null && textEditDelS.EditValue.ToString().Trim() != "")
                                    {
                                        textEditDelS.EditValue = textEditDelS.EditValue.ToString().Trim() + "," + slAutoid.ToString().Trim();
                                    }
                                    else
                                    {
                                        textEditDelS.EditValue = slAutoid.ToString().Trim();
                                    }
                                    gridView2.DeleteRow(j);
                                }
                            }
                            gridView1.DeleteRow(i);
                        }
                        else
                        {
                            sErr = sErr + "行" + (i + 1) + "已引用\n";
                        }
                    }
                }
            }
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string 序号 = gridView1.GetRowCellDisplayText(i, gridCol序号).ToString().Trim();
                if (序号 != "")
                {
                    gridView1.SetRowCellValue(i, gridCol行标记, i + 1);
                    for (int j = 0; j < gridView2.RowCount; j++)
                    {
                        if (序号 == gridView2.GetRowCellValue(j, grid序号).ToString().Trim())
                        {
                            gridView2.SetRowCellValue(j, grid行标记, i + 1);
                        }
                    }
                }
            }
            if (sErr != "")
            {
                MessageBox.Show(sErr);
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

            sSQL = "select a.*, 'edit' as iSave,cast(iQuantity as decimal(16,6)) as 历史数量,iRowNo as 行标记,null as 序号 from " + tablenames + " a  where 1=-1";
            dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dtBingGrid;

            sSQL = "select *,cast(iQuantity as decimal(16,6)) as 历史数量,iRowNo as 行标记,'' as cInvClassCode,null as 序号 from " + tablenamel + " where 1=-1";
            DataTable dtlist = clsSQLCommond.ExecQuery(sSQL);
            gridControl2.DataSource = dtlist;
            try
            {
                gridView1.FocusedColumn = gridCol行标记;
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
                gridView1.Focus();
            }
            catch { }
           
            //gridView1.AddNewRow();
            //gridView1.FocusedRowHandle = 0;

            dt子件 = clsSQLCommond.ExecQuery("select *,cast(iQuantity as decimal(16,6)) as 历史数量,iRowNo as 行标记,'' as cInvClassCode from " + tablenamel + " where 1=-1");

            gridView1.OptionsBehavior.Editable = true;
     
            sState = "add";
            radioGroup蓝红标识.EditValue = "2";
            lookUpEdit仓库.EditValue = "02";
            删除 = "";
            btnAddRow();
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
            删除 = "";
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
                string sErr = "";

                aList = new System.Collections.ArrayList();
                sSQL = "delete " + tablename + " where ID = '" + textEditID.EditValue.ToString().Trim() + "' ";
                aList.Add(sSQL);

                sSQL = "delete " + tablenames + " where ID = '" + textEditID.EditValue.ToString().Trim() + "' ";
                aList.Add(sSQL);

                sSQL = "delete " + tablenamel + " where ID = '" + textEditID.EditValue.ToString().Trim() + "' ";
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
                gridView1.FocusedColumn = gridCol行标记;
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
            sSQL = "select * from " + tablenamel + " where 1=-1";
            DataTable dtsl = clsSQLCommond.ExecQuery(sSQL);
            if (lookUpEdit客户.EditValue == null || lookUpEdit客户.EditValue.ToString().Trim() == "")
            {
                throw new Exception("客户不能为空");
            }
            //if (lookUpEdit转入仓库.EditValue == null || lookUpEdit转入仓库.EditValue.ToString().Trim() == "")
            //{
            //    throw new Exception("转入仓库不能为空");
            //}
            if (lookUpEdit仓库.EditValue == null || lookUpEdit仓库.EditValue.ToString().Trim() == "")
            {
                throw new Exception("仓库不能为空");
            }
            if (lookUpEdit部门.EditValue == null || lookUpEdit部门.EditValue.ToString().Trim() == "")
            {
                throw new Exception("部门不能为空");
            }
            if (dateEdit单据日期.EditValue == null || dateEdit单据日期.EditValue.ToString().Trim() == "")
            {
                throw new Exception("单据日期不能为空");
            }
            //if (lookUpEdit委外类型.EditValue == null || lookUpEdit委外类型.EditValue.ToString().Trim() == "")
            //{
            //    throw new Exception("委外类型不能为空");
            //}

            if (lookUpEdit仓库.EditValue == null || lookUpEdit仓库.EditValue.ToString().Trim() == "")
            {
                throw new Exception("转出仓库不能为空");
            }
            //if (lookUpEdit转入仓库.EditValue == null || lookUpEdit转入仓库.EditValue.ToString().Trim() == "")
            //{
            //    throw new Exception("转入仓库不能为空"); 
            //}
            if (lookUpEdit业务员.EditValue == null || lookUpEdit业务员.EditValue.ToString().Trim() == "")
            {
                throw new Exception("业务员不能为空");
            }
            if (lookUpEdit部门.EditValue == null || lookUpEdit部门.EditValue.ToString().Trim() == "")
            {
                throw new Exception("部门不能为空");
            }

            sSQL = "select isnull(max(AutoID)+1,1) as AutoID from " + tablenames;
            long sAutoID = long.Parse(clsSQLCommond.ExecQuery(sSQL).Rows[0][0].ToString());
            sSQL = "select isnull(max(sID)+1,1) as AutoID from " + tablenamel;
            long sID = long.Parse(clsSQLCommond.ExecQuery(sSQL).Rows[0][0].ToString());
            

            aList = new System.Collections.ArrayList();
            DataRow drh = dt.NewRow();
            if (sState == "add")
            {
                sSQL = "select isnull(isnull(max(ID),-1)+1,1) as ID from " + tablename;
                iID = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                drh["ID"] = iID;
                drh[tablecode] = 系统服务.序号.GetNewSerialNumberContinuous(tablename, tablecode);
                textEdit单据号.EditValue = drh[tablecode].ToString();
            }
            else
            {
                drh["ID"] = textEditID.EditValue.ToString().Trim();
                iID = Convert.ToInt64(textEditID.EditValue);
                drh[tablecode] = textEdit单据号.EditValue.ToString().Trim();
            }
            drh["dDate"] = dateEdit单据日期.EditValue.ToString().Trim();

            drh["cCusCode"] = buttonEdit客户.EditValue.ToString().Trim();
            drh["cPersonCode"] = buttonEdit业务员.EditValue.ToString().Trim();
            drh["cDepCode"] = buttonEdit部门.EditValue.ToString().Trim();

            drh["cWhCode"] = lookUpEdit仓库.EditValue.ToString().Trim();
            //drh["cWhCodeOut"] = lookUpEdit转入仓库.EditValue.ToString().Trim();

            //drh["cMTCode"] = lookUpEdit委外类型.EditValue.ToString().Trim();

            drh["Flag"] = radioGroup蓝红标识.EditValue.ToString().Trim();
            drh["iType"] = iType;
            drh["cMemo"] = textEdit备注.EditValue.ToString().Trim();

            if (sState == "add")
            {
                dateEdit制单日期.EditValue = 系统服务.ClsBaseDataInfo.sLogDate;
                textEdit制单人.EditValue = 系统服务.ClsBaseDataInfo.sUid;
            }

            drh["dCreatesysTime"] = dateEdit制单日期.EditValue.ToString().Trim();
            drh["dCreatesysPerson"] = textEdit制单人.EditValue.ToString().Trim();

            if (sState == "alter")
            {
                drh["dVerifysysTime"] = dateEdit审核日期.Text.Trim();
                drh["dVerifysysPerson"] = textEdit审核人.Text.Trim();

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
                系统服务.变更表.GetChange(tablename, tablenames, tablenamel, textEditID.EditValue.ToString().Trim(), clsGetSQL, aList);
            }
            #endregion

            #region 删行
            if (textEditDel.EditValue != null && textEditDel.EditValue.ToString().Trim() != "")
            {
                系统服务.变更表.GetDelRow(tablenames, tablenamel, textEditDel.EditValue.ToString().Trim(), aList);
            }

            if (textEditDelS.EditValue != null && textEditDelS.EditValue.ToString().Trim() != "")
            {
                string[] strdel = textEditDelS.EditValue.ToString().Trim().Split(',');
                for (int i = 0; i < strdel.Length; i++)
                {
                    if (strdel[i].Trim() != "")
                    {
                        sSQL = "delete  from " + tablenamel + " where sID ='" + strdel[i] + "'";
                        aList.Add(sSQL);
                    }
                }

            }

            #endregion

            #region 子表

            DataTable dtlist = (DataTable)gridControl2.DataSource;
           
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "update" || gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "edit" || gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "add")
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
                    if (is散件==false && gridView1.GetRowCellDisplayText(i, gridCol箱号).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + gridCol箱号.Caption + "不可为空\n";
                        continue;
                    }

                    if (is散件 == false && ReturnDecimal(gridView1.GetRowCellValue(i, gridCol箱数)) >= 0)
                    {
                        sErr = sErr + "行" + (i + 1) + gridCol箱数.Caption + "必须小于0\n";
                        continue;
                    }
                    #endregion

                    #region 生成table
                    DataRow dr = dts.NewRow();
                    if (gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim() == "")
                    {
                        dr["AutoID"] = sAutoID;
                    }
                    else
                    {
                        dr["AutoID"] = gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim();
                    }
                    long bAutoID = long.Parse(dr["AutoID"].ToString());
                    string 行标记 = gridView1.GetRowCellValue(i, gridCol行标记).ToString().Trim();
                    dr["ID"] = iID;
                    dr[tablecode] = textEdit单据号.EditValue.ToString().Trim();
                    dr["iRowNo"] = 行标记;
                    dr["cInvCode"] = gridView1.GetRowCellValue(i, gridCol物料编码).ToString().Trim();
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
                    if (gridView1.GetRowCellValue(i, gridCol税额) != null && gridView1.GetRowCellValue(i, gridCol税额).ToString().Trim() != "")
                    {
                        dr["iNatTax"] = gridView1.GetRowCellValue(i, gridCol税额).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol换算率) != null && gridView1.GetRowCellValue(i, gridCol换算率).ToString().Trim() != "")
                    {
                        dr["iChangRate"] = gridView1.GetRowCellValue(i, gridCol换算率).ToString().Trim();
                    }

                    dr["M1"] = gridView1.GetRowCellValue(i, gridColM1).ToString().Trim();
                    dr["M2"] = gridView1.GetRowCellValue(i, gridColM2).ToString().Trim();
                    dr["M3"] = gridView1.GetRowCellValue(i, gridColM3).ToString().Trim();
                    dr["M4"] = gridView1.GetRowCellValue(i, gridColM4).ToString().Trim();
                    dr["M5"] = gridView1.GetRowCellValue(i, gridColM5).ToString().Trim();
                    dr["M6"] = gridView1.GetRowCellValue(i, gridColM6).ToString().Trim();
                    dr["M7"] = gridView1.GetRowCellValue(i, gridColM7).ToString().Trim();
                    dr["M8"] = gridView1.GetRowCellValue(i, gridColM8).ToString().Trim();
                    dr["M9"] = gridView1.GetRowCellValue(i, gridColM9).ToString().Trim();
                    dr["M10"] = gridView1.GetRowCellValue(i, gridColM10).ToString().Trim();

                    dr["SoAutoID"] = gridView1.GetRowCellValue(i, gridCol销售订单AutoID).ToString().Trim();
                    dr["RdAutoID"] = gridView1.GetRowCellValue(i, gridCol出入库单子表ID).ToString().Trim();
                    dr["SOOutAutoID"] = gridView1.GetRowCellValue(i, gridCol销售出库单AutoID).ToString().Trim();
                    dr["BoxNo"] = gridView1.GetRowCellValue(i, gridCol箱号).ToString().Trim();
                    if (gridView1.GetRowCellValue(i, gridCol箱数) != null && gridView1.GetRowCellValue(i, gridCol箱数).ToString().Trim() != "")
                    {
                        dr["BoxQty"] = gridView1.GetRowCellValue(i, gridCol箱数).ToString().Trim();
                    }

                    dr["cMemo"] = gridView1.GetRowCellValue(i, gridCol备注).ToString().Trim();

                    dts.Rows.Add(dr);
                    #endregion

                    if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "update" || gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "edit")
                    {
                        sSQL = clsGetSQL.GetUpdateSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablenames, dts, dts.Rows.Count - 1);
                    }
                    else if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "add")
                    {
                        sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablenames, dts, dts.Rows.Count - 1);
                    }

                    aList.Add(sSQL);

                    #region 子件

                    DataRow[] dw = dtlist.Select("行标记='" + 行标记 + "'");
                    if (dw.Length == 0)
                    {
                        sErr = sErr + "行" + (i + 1) + "子件数量不能为0\n";
                        continue;
                    }
                    else
                    {
                        for (int l = 0; l < dw.Length; l++)
                        {
                            DataRow dwl = dtsl.NewRow();
                            if (dw[l]["sID"].ToString() == "")
                            {
                                dwl["sID"] = sID;
                            }
                            else
                            {
                                dwl["sID"] = dw[l]["sID"].ToString();
                            }
                            dwl["AutoID"] = bAutoID;
                            dwl["ID"] = iID;
                            dwl[tablecode] = textEdit单据号.EditValue.ToString().Trim();
                            dwl["iRowNo"] = dw[l]["行标记"].ToString();
                            dwl["cInvCode"] = dw[l]["cInvCode"].ToString();
                            dwl["iQuantity"] = dw[l]["iQuantity"].ToString();
                            dwl["SoAutoID"] = dw[l]["SoAutoID"].ToString();
                            if (dw[l]["SosID"].ToString() != "")
                            {
                                dwl["SosID"] = dw[l]["SosID"].ToString();
                            }
                            dwl["SOOutsID"] = dw[l]["SOOutsID"].ToString();
                            dwl["SOOutAutoID"] = dw[l]["SOOutAutoID"].ToString();
                            //dwl["iUsedQty"] = dw[l]["iUsedQty"].ToString();
                            if (dw[l]["iNum"].ToString() != "")
                            {
                                dwl["iNum"] = dw[l]["iNum"].ToString();
                            }
                            if (dw[l]["iChangRate"].ToString() != "")
                            {
                                dwl["iChangRate"] = dw[l]["iChangRate"].ToString();
                            }
                            dwl["cMemo"] = dw[l]["cMemo"].ToString();
                            if (dw[l]["D1"].ToString() != "")
                            {
                                dwl["D1"] = dw[l]["D1"].ToString();
                            }
                            dwl["BoxNo"] = dw[l]["BoxNo"].ToString();
                            dwl["sBoxNo"] = dw[l]["sBoxNo"].ToString();
                            if (dw[l]["sBoxQty"].ToString() != "")
                            {
                                dwl["sBoxQty"] = dw[l]["sBoxQty"];
                            }
                            dwl["M1"] = dw[l]["M1"];
                            dwl["M2"] = dw[l]["M2"];
                            dwl["M3"] = dw[l]["M3"];
                            dwl["M4"] = dw[l]["M4"];
                            dwl["M5"] = dw[l]["M5"];
                            dwl["M6"] = dw[l]["M6"];
                            dwl["M7"] = dw[l]["M7"];
                            dwl["M8"] = dw[l]["M8"];
                            dwl["M9"] = dw[l]["M9"];
                            dwl["M10"] = dw[l]["M10"];
                            dtsl.Rows.Add(dwl);
                            if (dw[l]["sID"].ToString() == "")
                            {
                                sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablenamel, dtsl, dtsl.Rows.Count - 1);
                                sID = sID + 1;
                            }
                            else
                            {
                                sSQL = clsGetSQL.GetUpdateSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablenamel, dtsl, dtsl.Rows.Count - 1);
                            }
                            aList.Add(sSQL);
                            
                        }
                    }
                    #endregion

                    sAutoID = sAutoID + 1;
                }
            }
            #endregion

            #region 表体不能为空
            bool b列表 = false;
            int bCount = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridCol物料编码).ToString().Trim() != "")
                {
                    b列表 = true;
                    bCount = bCount + 1;
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
                textEditDel.EditValue = "";
                textEditDelS.EditValue = "";
                sState = "save";
                删除 = "";
                GetGrid();

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

            sSQL = "update " + tablename + " set dVerifysysTime='" + 系统服务.ClsBaseDataInfo.sLogDate + "',dVerifysysPerson='" + 系统服务.ClsBaseDataInfo.sUid + "' where ID=" + textEditID.EditValue.ToString().Trim() + "";
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

            sSQL = "update " + tablename + " set dVerifysysTime=null,dVerifysysPerson=null where ID=" + textEditID.EditValue.ToString().Trim() + "";
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

            sSQL = "update " + tablename + " set dClosesysTime=null,dClosesysPerson=null where ID=" + textEditID.EditValue.ToString().Trim() + "";
            aList.Add(sSQL);
            sSQL = "update " + tablenames + " set cClosesysTime=null,cClosesysPerson=null where ID=" + textEditID.EditValue.ToString().Trim() + " ";
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

            sSQL = "update " + tablename + " set dClosesysTime='" + 系统服务.ClsBaseDataInfo.sLogDate + "',dClosesysPerson='" + 系统服务.ClsBaseDataInfo.sUid + "' where ID=" + textEditID.EditValue.ToString().Trim() + "";
            aList.Add(sSQL);
            sSQL = "update " + tablenames + " set cClosesysTime='" + 系统服务.ClsBaseDataInfo.sLogDate + "',cClosesysPerson='" + 系统服务.ClsBaseDataInfo.sUid + "' where ID=" + textEditID.EditValue.ToString().Trim() + " and  (cClosesysPerson='' or cClosesysPerson is null)";
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
            SetEnabled(true);
        }

        #endregion

        private void Frm红字销售出库单_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.Text.IndexOf("散件") > -1)
                {
                    is散件 = true;
                    cSQL = " and iType=2 and Flag=2";
                    iType = "2";
                    gridCol箱号.Visible = false;
                    gridCol箱数.Visible = false;
                    grid箱号.Visible = false;
                }
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

                sSQL = "select * from " + tablename + " where ID=" + iID + cSQL;

                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                
                if (dt.Rows.Count > 0)
                {
                    textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]); ;
                    textEdit单据号.EditValue = dt.Rows[0]["cSOOutCode"].ToString();
                    buttonEdit客户.EditValue = dt.Rows[0]["cCusCode"].ToString();
                    dateEdit单据日期.EditValue = dt.Rows[0]["dDate"].ToString();
                    dateEdit制单日期.EditValue = dt.Rows[0]["dCreatesysTime"].ToString();
                    dateEdit审核日期.EditValue = dt.Rows[0]["dVerifysysTime"].ToString();
                    dateEdit关闭日期.EditValue = dt.Rows[0]["dClosesysTime"].ToString();

                    textEdit备注.EditValue = dt.Rows[0]["cMemo"].ToString();
                    textEdit制单人.EditValue = dt.Rows[0]["dCreatesysPerson"].ToString();
                    textEdit审核人.EditValue = dt.Rows[0]["dVerifysysPerson"].ToString();
                    textEdit关闭人.EditValue = dt.Rows[0]["dClosesysPerson"].ToString();

                    buttonEdit业务员.EditValue = dt.Rows[0]["cPersonCode"].ToString();
                    lookUpEdit业务员.EditValue = buttonEdit业务员.EditValue;
                    buttonEdit部门.EditValue = dt.Rows[0]["cDepCode"].ToString();
                    lookUpEdit部门.EditValue = buttonEdit部门.EditValue;

                    lookUpEdit仓库.EditValue = dt.Rows[0]["cWhCode"].ToString();
                    radioGroup蓝红标识.EditValue = dt.Rows[0]["Flag"].ToString();

                    sSQL = "select a.*, 'edit' as iSave,cast(a.iQuantity as decimal(16,6)) as 历史数量,iRowNo as 行标记,cast(null as decimal(16,6)) as SumiQuantity,iRowNo as 序号 from " + tablenames + " a where ID=" + iID + " order by iRowNo";
                    dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
                    gridControl1.DataSource = dtBingGrid;

                   

                    SetEnabled(false);


                    sSQL = "select a.*,cast(iQuantity as decimal(16,6)) as 历史数量,iRowNo as 行标记,b.cInvClassCode,iRowNo as 序号 from " + tablenamel + " a left join Inventory b on a.cInvCode=b.cInvCode where a.ID=" + iID;
                    dt子件 = clsSQLCommond.ExecQuery(sSQL);

                    DataTable dtlist = clsSQLCommond.ExecQuery(sSQL);
                    gridControl2.DataSource = dtlist;

                    sState = "";
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
            SetEnabled(false);
            sState = "sel";
        }

        /// <summary>
        /// 下拉列表框
        /// </summary>
        private void SetLookUpEdit()
        {
            系统服务.LookUp.Person(lookUpEdit业务员);
            系统服务.LookUp.Department(lookUpEdit部门);
            系统服务.LookUp.Customer(lookUpEdit客户);
            系统服务.LookUp.Warehouse(lookUpEdit仓库);

            系统服务.LookUp.ColorNo(ItemLookUpEditM1);
            系统服务.LookUp.Dyelot(ItemLookUpEditM2);

            系统服务.LookUp.ColorNo(ItemLookUpM1);
            系统服务.LookUp.Dyelot(ItemLookUpM2);

            系统服务.LookUp.Inventory(ItemLookUpEdit存货名称);
            ItemLookUpEdit存货名称.Properties.DisplayMember = "cInvName";
            系统服务.LookUp.Inventory(ItemLookUpEdit存货规格);
            ItemLookUpEdit存货规格.Properties.DisplayMember = "cInvStd";
            系统服务.LookUp.InventorycInvAddCode(ItemLookUpEdit存货代码);

            系统服务.LookUp.Inventory(ItemLookUp存货名称);
            ItemLookUpEdit存货名称.Properties.DisplayMember = "cInvName";
            系统服务.LookUp.Inventory(ItemLookUp存货规格);
            ItemLookUpEdit存货规格.Properties.DisplayMember = "cInvStd";
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
            buttonEdit部门.Enabled = b;
            buttonEdit客户.Enabled = b;

            lookUpEdit仓库.Enabled = b;
            gridView1.OptionsBehavior.Editable = b;
            gridView2.OptionsBehavior.Editable = b;

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
            buttonEdit部门.EditValue = "";
            lookUpEdit部门.EditValue = "";
            buttonEdit客户.EditValue = "";
            lookUpEdit客户.EditValue = "";

            lookUpEdit仓库.EditValue = "";

            textEditDelS.EditValue = "";

            gridControl1.DataSource = null;
            gridControl2.DataSource = null;
            dt子件 = null;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int iRow = 0;
            if (gridView1.FocusedRowHandle >= 0)
            {
                iRow = gridView1.FocusedRowHandle;
            }

            //if (gridView1.GetRowCellValue(iRow, gridCol行标记).ToString().Trim() == "")
            //{
            //    gridView1.SetRowCellValue(iRow, gridCol行标记, iRow + 1);
            //}
            //if (gridView1.GetRowCellValue(iRow, gridCol行标记).ToString().Trim() == "")
            //{
            //    if (iRow == 0)
            //    {
            //        gridView1.SetRowCellValue(iRow, gridCol行标记, 1);
            //    }
            //    else
            //    {
            //        gridView1.SetRowCellValue(iRow, gridCol行标记, double.Parse(gridView1.GetRowCellValue(iRow - 1, gridCol行标记).ToString().Trim()) + 1);
            //    }
            //}

            //if (e.Column == gridCol物料编码)
            //{
            //    string invocde = gridView1.GetRowCellValue(iRow, gridCol物料编码).ToString().Trim();
            //    if (invocde != "")
            //    {
            //        if (buttonEdit客户.EditValue != null && buttonEdit客户.EditValue.ToString().Trim() != "")
            //        {
            //            decimal price = 系统服务.GetPrice.PriceAdjust(invocde, buttonEdit客户.EditValue.ToString().Trim());
            //            if (price != 0)
            //            {
            //                gridView1.SetRowCellValue(iRow, gridCol含税单价, price);
            //            }
            //        }

            //        #region 换算率和税率
            //        sSQL = "select 换算率 from Inventory where cInvCode='" + invocde + "'";
            //        decimal d换算率 = ReturnDecimal(clsSQLCommond.ExecGetScalar(sSQL));
            //        if (d换算率 > 0)
            //        {
            //            gridView1.SetRowCellValue(iRow, gridCol换算率, d换算率);
            //        }
            //        else
            //        {
            //            gridView1.SetRowCellValue(iRow, gridCol换算率, null);
            //        }
            //        gridView1.SetRowCellValue(iRow, gridCol税率, 17);
            //        #endregion
            //    }
            //}

            //#region 判断引用量
            //long lAutoid = -1;
            //if (gridView1.GetRowCellValue(iRow, gridColAutoID).ToString().Trim() != "")
            //{
            //    lAutoid = Convert.ToInt64(gridView1.GetRowCellValue(iRow, gridColAutoID));
            //}
            //long 上游AutoID = -1;
            //if (gridView1.GetRowCellValue(iRow, gridCol销售订单子表ID).ToString().Trim() != "")
            //{
            //    上游AutoID = Convert.ToInt64(gridView1.GetRowCellValue(iRow, gridCol销售订单子表ID));
            //}
            //decimal Qty = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol数量));
            //decimal 上游可用量 = iCodeUsed上游(上游AutoID, lAutoid);
            //if (Qty > 上游可用量)
            //{
            //    MessageBox.Show("累计下单数量超出订单数量，订单可下入库量为" + 上游可用量.ToString());
            //    gridView1.SetRowCellValue(iRow, gridCol数量, gridView1.GetRowCellValue(iRow, gridCol历史数量));
            //}
            
            //#endregion

            //#region 换算率
            //if (e.Column == gridCol数量 || e.Column == gridCol换算率)
            //{
            //    if (gridView1.GetRowCellValue(iRow, gridCol换算率).ToString().Trim() != "")
            //    {
            //        decimal 换算率 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol换算率));
            //        decimal 数量 = 0;
            //        if (gridView1.GetRowCellValue(iRow, gridCol数量).ToString().Trim() != "")
            //        {
            //            数量 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol数量));
            //        }
            //        if (数量 == 0)
            //        {
            //            gridView1.SetRowCellValue(iRow, gridCol件数, null);
            //        }
            //        else
            //        {
            //            gridView1.SetRowCellValue(iRow, gridCol件数, ReturnDecimal(数量 * 换算率));
            //        }
            //    }
            //    else
            //    {
            //        gridView1.SetRowCellValue(iRow, gridCol件数, null);
            //    }

            //}
            //#endregion

            //if (e.Column == gridCol数量 || e.Column == gridCol件数 || e.Column == gridCol税率 || e.Column == gridCol税额 || e.Column == gridCol含税单价 || e.Column == gridCol含税金额
            //    || e.Column == gridCol无税单价 || e.Column == gridCol无税金额)
            //{
            //    decimal 数量 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol数量));
            //    decimal 历史数量 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol历史数量));
            //    decimal 件数 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol件数));
            //    decimal 税率 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol税率)) / 100;
            //    decimal 税额 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol税额));
            //    decimal 换算率 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol换算率));
            //    decimal 含税单价 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol含税单价));
            //    decimal 含税金额 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol含税金额));
            //    decimal 无税单价 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol无税单价));
            //    decimal 无税金额 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol无税金额));

            //    #region 计算
            //    if (e.Column == gridCol数量)
            //    {
            //        if (换算率 != 0)
            //        {
            //            gridView1.SetRowCellValue(iRow, gridCol件数, ReturnDecimal(数量 * 换算率));
            //        }
            //        else
            //        {
            //            gridView1.SetRowCellValue(iRow, gridCol件数, null);
            //        }
            //    }
            //    if (e.Column == gridCol含税单价 || e.Column == gridCol数量 || e.Column == gridCol税率)
            //    {
            //        无税单价 = ReturnDecimal(含税单价 / (1 + 税率));
            //        含税金额 = ReturnDecimal(含税单价 * 数量);
            //        无税金额 = ReturnDecimal(无税单价 * 数量);
            //        税额 = 含税金额 - 无税金额;

            //        gridView1.SetRowCellValue(iRow, gridCol无税单价, 无税单价);
            //        gridView1.SetRowCellValue(iRow, gridCol无税金额, 无税金额);
            //        gridView1.SetRowCellValue(iRow, gridCol含税金额, 含税金额);
            //        gridView1.SetRowCellValue(iRow, gridCol税额, 税额);
            //    }
            //    if (e.Column == gridCol含税金额 && 数量 != 0)
            //    {
            //        含税单价 = ReturnDecimal(含税金额 / 数量);
            //    }
            //    #endregion

            //}

            //#region
            //if (e.Column != gridColiSave && e.Column != gridCol行标记 && gridView1.GetRowCellDisplayText(e.RowHandle, gridColiSave).ToString().Trim() == "")
            //{
            //    gridView1.SetRowCellValue(iRow, gridColiSave, "add");
            //}
            //if (e.Column != gridColiSave && e.Column != gridCol行标记 && gridView1.GetRowCellDisplayText(e.RowHandle, gridColiSave).ToString().Trim() == "edit")
            //{
            //    gridView1.SetRowCellValue(iRow, gridColiSave, "update");
            //}
            ////if (e.Column == gridCol物料编码 && e.RowHandle == gridView1.RowCount - 1 && gridView1.GetRowCellDisplayText(e.RowHandle, gridCol物料编码).ToString().Trim() != "")
            ////{
            ////    gridView1.AddNewRow();
            ////    gridView1.FocusedRowHandle = iRow;
            ////}
            //#endregion
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

        private void ItemButtonEditcInvCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

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
            if (lookUpEdit部门.Text.Trim() != "")
            {
                DataTable dt = 系统服务.LookUp.Department(buttonEdit部门.Text.Trim());
                if (dt != null && dt.Rows.Count > 0)
                {
                    buttonEdit部门.EditValue = dt.Rows[0]["cDepCode"];
                }
            }
            else
            {
                lookUpEdit部门.EditValue = null;
                buttonEdit部门.EditValue = null;
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
                sSQL = "select  isnull(dCreatesysPerson,'') as 制单人,isnull(dVerifysysPerson,'') as 审核人,isnull(dClosesysPerson,'') as 关闭人 from " + tablename + " where cSOOutCode = '" + sCode + "'";
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

                    sSQL = "select count(1) from " + tablename + " a inner join " + tablenames + " b on a.id = b.id where a.cSOOutCode = '" + sCode + "' and isnull(cClosesysPerson,'') <> ''";
                    long iCou = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                    if (iCou > 0)
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
//                sSQL = @"select count(1) from dbo.SO_SOOutMain a inner join dbo.SO_SOOutDetails b on a.ID = b.ID inner join 
//                left join (select b.MOAutoID,sum(b.iQuantity) as iQuantity from RdRecord a left join dbo.RdRecords b on a.ID=b.ID where a.cRSCode='11' group by b.MOAutoID) c 
//                on c.MOAutoID = b.AutoID where a.cMOCode = '" + sCode + "'";
//                int iReturn1 = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL)); 

                //sSQL = "select count(1) from dbo.MO_MOMain a inner join dbo.MO_MODetails b on a.ID = b.ID inner join dbo.SaleBillVouchs c on c.SoAutoID = b.AutoID " +
                //       "where a.cSOCode = '" + sCode + "'";
                //int iReturn2 = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));

                //if (iReturn1 > iReturn2)
                //    iReturn = iReturn1;
                //else
                //    iReturn = iReturn2;

                //iReturn = iReturn1;
                return 0;
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
                //sSQL = "select isnull(sum(c.iQuantity),0) as iQty from dbo.MO_MOMain a inner join dbo.MO_MODetails b on a.ID = b.ID inner join dbo.MO_MOOutDetails c on c.SoAutoID = b.AutoID " +
                //       "where b.AutoID = '" + AutoID + "'";
                //decimal iReturn1 = ReturnDecimal(clsSQLCommond.ExecGetScalar(sSQL));
                //if (iReturn1 > iReturn && iReturn1 > 0)
                //    iReturn = iReturn1;

                //sSQL = "select isnull(sum(c.iQuantity),0) as iQty from dbo.MO_MOMain a inner join dbo.MO_MODetails b on a.ID = b.ID inner join dbo.SaleBillVouchs c on c.SoAutoID = b.AutoID " +
                //       "where b.AutoID = '" + AutoID + "'";
                //decimal iReturn2 = ReturnDecimal(clsSQLCommond.ExecGetScalar(sSQL));
                //if (iReturn2 > iReturn && iReturn2 > 0)
                //    iReturn = iReturn2;

                //sSQL = "select isnull(sum(c.iQuantity),0) as iQty from dbo.MO_MOMain a inner join dbo.MO_MODetails b on a.ID = b.ID inner join dbo.SO_CloseBillDetails c on c.SoAutoID = b.AutoID " +
                //       "where b.AutoID = '" + AutoID + "'";
                //decimal iReturn3 = ReturnDecimal(clsSQLCommond.ExecGetScalar(sSQL));

                //if (iReturn3 > iReturn && iReturn3 > 0)
                //    iReturn = iReturn3;
                return 0;
            }
            catch (Exception ee)
            { }
            return iReturn;
        }

        /// <summary>
        /// 判断上游单据可使用量
        /// </summary>
        /// <param name="sCode">子表ID</param>
        /// <returns></returns>
        private decimal iCodeUsed上游(long 上游AutoID, long AutoID)
        {
            decimal iReturn = -1;
            try
            {
                if (radioGroup蓝红标识.EditValue.ToString().Trim() == "1")
                {
                    sSQL = @"select isnull(b.iQuantity,0)-isnull(r.iQuantity,0) as iQuantity 
from SO_SOMain a left join SO_SODetails b on a.ID = b.ID 
left join (select SoAutoID,sum(isnull(iQuantity,0)) as iQuantity,sum(isnull(iNum,0)) as iNum ,sum(isnull(iNatMoney,0)) as iNatMoney ,sum(isnull(iMoney,0)) as iMoney  from SO_SOOutDetails 
where 1=1 group by SoAutoID) r on b.AutoID=r.SoAutoID where b.AutoID = " + 上游AutoID;
                    sSQL = sSQL.Replace("1=1", "1=1 and AutoID <> '" + AutoID + "'");
                }
                else
                {
                    sSQL = @"select -isnull(r.iQuantity,0) as iQuantity 
from SO_SOMain a left join SO_SODetails b on a.ID = b.ID 
left join (select SoAutoID,sum(isnull(iQuantity,0)) as iQuantity,sum(isnull(iNum,0)) as iNum ,sum(isnull(iNatMoney,0)) as iNatMoney ,sum(isnull(iMoney,0)) as iMoney  from SO_SOOutDetails 
where 1=1 group by SoAutoID) r on b.AutoID=r.SoAutoID where b.AutoID = " + 上游AutoID;
                    sSQL = sSQL.Replace("1=1", "1=1 and AutoID <> '" + AutoID + "'");
                }
                decimal iReturn1 = ReturnDecimal(clsSQLCommond.ExecGetScalar(sSQL));

                iReturn = iReturn1;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
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

        private void buttonEdit客户_Leave(object sender, EventArgs e)
        {
            if (buttonEdit客户.Text.Trim() != "")
                lookUpEdit客户.EditValue = buttonEdit客户.Text.Trim();
            else
                lookUpEdit客户.EditValue = null;
        }

    }
}
