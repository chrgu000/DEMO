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
    public partial class Frm销售订单历史 : 系统服务.FrmBaseInfo
    {
        decimal 乘数 = 0.1M;
        string tablename = "SO_SOMainHistory";
        string tableid = "cSOCode";
        string tablenames = "SO_SODetailsHistory";
        string tablenamel = "SO_SOSublistHistory";
        string tablenamec = "SO_SOMainCommissiionHistory";

        long iID = -1;
        long hID = -1;
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
        public string 删除业务费用 = "";

        public DataTable dt子件;

        public DataTable dt业务费用;

        string isChange = "";


        public Frm销售订单历史(long siID)
        {
            iID = siID;
            InitializeComponent();

        }

        public Frm销售订单历史()
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
            throw new NotImplementedException();
        }

        private void GetSel()
        {
            string sSQL = "select * from " + tablename + " a left join " + tablenames + "  b on a.ID=b.ID and a.ID=" + iID + " where 1=1 ";
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
            sSQL = sSQL + "  order by a.HistoryId";
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
                sSQL = "select min(HistoryId) as HistoryId from " + tablename + "  where 1=1 and ID=" + iID + "";

                sSQL = sSQL + " order by HistoryId";

                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    hID = Convert.ToInt64(dt.Rows[0]["HistoryId"]); 
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
                    sSQL = "select HistoryId from " + tablename + " where HistoryId<'" + hID + "' and ID=" + iID + " ";

                    sSQL = sSQL + " order by HistoryId desc";

                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt.Rows.Count > 0)
                    {
                        hID = Convert.ToInt64(dt.Rows[0]["HistoryId"]); 
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
                    sSQL = "select HistoryId from " + tablename + " where HistoryId>'" + hID + "' and ID=" + iID + " ";

                    sSQL = sSQL + " order by HistoryId";

                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt.Rows.Count > 0)
                    {
                        hID = Convert.ToInt64(dt.Rows[0]["HistoryId"]); 
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
                sSQL = "select isnull(max(HistoryId),-1) as HistoryId from " + tablename + " where ID=" + iID + "  ";

                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    hID = Convert.ToInt64(dt.Rows[0]["HistoryId"]); 
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
            if (lookUpEdit客户.EditValue == null || lookUpEdit客户.EditValue.ToString() == "")
            {
                throw new Exception("请先输入客户");
            }
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
            Frm销售订单业务费用历史_Add frm = new Frm销售订单业务费用历史_Add(textEditID.EditValue.ToString().Trim(), dt业务费用, b, sState, lookUpEdit客户.EditValue.ToString().Trim(), 数量, cInvCode, 删除业务费用);
            if (DialogResult.OK == frm.ShowDialog())
            {
                frm.Enabled = true;
                dt业务费用 = frm.dttmp;
                删除业务费用 = frm.删除;
                textEdit业务费用.EditValue = frm.业务费用;
            }
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
            string 行标记 = "";
            string 物料编码 = "";
            string 物料名称 = "";
            string 规格型号 = "";
            string AutoID = "";
            decimal 数量 = 0;
            int iRow = 0;
            if (gridView1.FocusedRowHandle > 0)
                iRow = gridView1.FocusedRowHandle;

            行标记 = gridView1.GetRowCellDisplayText(iRow, gridCol行标记).ToString().Trim();
            物料编码 = gridView1.GetRowCellDisplayText(iRow, gridCol物料编码).ToString().Trim();
            物料名称 = gridView1.GetRowCellDisplayText(iRow, gridCol物料名称).ToString().Trim();
            规格型号 = gridView1.GetRowCellDisplayText(iRow, gridCol规格型号).ToString().Trim();
            AutoID = gridView1.GetRowCellDisplayText(iRow, gridColAutoID).ToString().Trim();
            if (gridView1.GetRowCellDisplayText(iRow, gridCol数量) != null && gridView1.GetRowCellDisplayText(iRow, gridCol数量).Trim() != "")
            {
                数量 = ReturnDecimal(gridView1.GetRowCellDisplayText(iRow, gridCol数量).Trim());
            }
            if (数量 == 0)
            {
                throw new Exception("请先输入数量");
            }
            if (gridView1.GetRowCellDisplayText(iRow, gridColiSave) == "edit")
            {
                gridView1.SetRowCellValue(iRow, gridColiSave, "update");
            }

            if (行标记 == "")
            {
                throw new Exception("未选中行，不可设定子件");
            }
            DataRow[] dw = dt子件.Select("行标记='" + 行标记 + "'");
            DataTable dttmp;
            if (dw.Length > 0)
            {
                dttmp = 系统服务.Table.DataRowToDataTable(dw);
            }
            else
            {
                dttmp = clsSQLCommond.ExecQuery("select *,cast(null as decimal(16,6)) as 历史,iRowNo as 行标记,'' as cInvClassCode from " + tablenamel + " where 1=-1");
            }

            bool b = false;
            if (sState == "add" || sState == "edit" || sState == "alter")
            {
                b = true;
            }
            Frm销售订单子件历史_Add frm = new Frm销售订单子件历史_Add(AutoID, 行标记, dttmp, 物料编码, 物料名称, 规格型号, b, 删除, sState, 数量);
            if (DialogResult.OK == frm.ShowDialog())
            {
                frm.Enabled = true;
                dttmp = frm.dttmp;
                删除 = frm.删除;
                if (textEditDelS.EditValue != null && textEditDelS.EditValue.ToString().Trim() != "")
                {
                    textEditDelS.EditValue = textEditDelS.EditValue + "," + 删除;
                }
                else
                {
                    textEditDelS.EditValue = 删除;
                }
                for (int i = dt子件.Rows.Count - 1; i >= 0; i--)
                {
                    //if (dt子件.Rows[i].RowState == DataRowState.Deleted)
                    //    continue;
                    if (dt子件.Rows[i]["行标记"].ToString() == 行标记)
                    {
                        dt子件.Rows.Remove(dt子件.Rows[i]);
                    }
                }
                for (int i = 0; i < dttmp.Rows.Count; i++)
                {
                    dt子件.ImportRow(dttmp.Rows[i]);
                }
            }
        }
        /// <summary>
        /// 删行
        /// </summary>
        private void btnDelRow()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 新增
        /// </summary>
        private void btnAdd()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 撤销
        /// </summary>
        private void btnUnDo()
        {
            throw new NotImplementedException();
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

        private void Frm销售订单历史_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookUpEdit();
                if (iID != -1 & hID!=-1)
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

                sSQL = "select *,(select sum(DD1*DD2) as sCount from SO_SOMainCommissiion c where " + tablename + ".ID=c.ID) as sCount from " + tablename + " where ID=" + iID + " and HistoryId='"+hID+"'";

                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                
                if (dt.Rows.Count > 0)
                {
                    textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]);
                    textEdit单据号.EditValue = dt.Rows[0]["cSOCode"].ToString();

                    dateEdit单据日期.EditValue = dt.Rows[0]["dDate"].ToString();
                    dateEdit制单日期.EditValue = dt.Rows[0]["dCreatesysTime"].ToString();
                    dateEdit审核日期.EditValue = dt.Rows[0]["dVerifysysTime"].ToString();
                    dateEdit关闭日期.EditValue = dt.Rows[0]["dClosesysTime"].ToString();

                    textEdit变更日期.EditValue = dt.Rows[0]["HistoryTime"].ToString();

                    textEdit备注.EditValue = dt.Rows[0]["cMemo"].ToString();
                    textEdit制单人.EditValue = dt.Rows[0]["dCreatesysPerson"].ToString();
                    textEdit审核人.EditValue = dt.Rows[0]["dVerifysysPerson"].ToString();
                    textEdit关闭人.EditValue = dt.Rows[0]["dClosesysPerson"].ToString();

                    buttonEdit客户.EditValue = dt.Rows[0]["cCusCode"].ToString();
                    lookUpEdit客户.EditValue = buttonEdit客户.EditValue;
                    buttonEdit业务员.EditValue = dt.Rows[0]["cPersonCode"].ToString();
                    lookUpEdit业务员.EditValue = buttonEdit业务员.EditValue;
                    buttonEdit部门.EditValue = dt.Rows[0]["cDepCode"].ToString();
                    lookUpEdit部门.EditValue = buttonEdit部门.EditValue;
                    
                    lookUpEdit销售类型.EditValue = dt.Rows[0]["cSTCode"].ToString();
                    lookUpEdit统计类型.EditValue = dt.Rows[0]["cSTTCode"].ToString();
                    textEdit业务费用.EditValue = dt.Rows[0]["D7"].ToString();

                    lookUpEdit区域.EditValue = dt.Rows[0]["cDCCode"].ToString();
                    lookUpEdit行业.EditValue = dt.Rows[0]["cTrade"].ToString();
                    lookUpEdit客户分类.EditValue = dt.Rows[0]["cCCCode"].ToString();

                    textEdit8位数编码.EditValue = dt.Rows[0]["ECode"].ToString();

                    lookUpEdit合作方式.EditValue = dt.Rows[0]["cCCode"].ToString();

                    lookUpEdit新老客户.EditValue = ReturnInt(dt.Rows[0]["CusType"].ToString());
                    dateEdit实际到货时间.EditValue = dt.Rows[0]["ArrDate"].ToString();
                    textEdit预计到货天数.EditValue = dt.Rows[0]["ArrDays"].ToString();
                    textEdit运行成本.EditValue = dt.Rows[0]["Cost"].ToString();
                    lookUpEdit发运方式.EditValue = dt.Rows[0]["S1"].ToString();
                    textEdit发运金额.EditValue = dt.Rows[0]["D1"].ToString();
                    lookUpEdit付款条件.EditValue = ReturnInt(dt.Rows[0]["cPayCode"].ToString());

                    textEdit利润分成.EditValue = dt.Rows[0]["D2"];
                    textEdit客户联系人.EditValue = dt.Rows[0]["S2"];
                    textEdit客户联系电话.EditValue = dt.Rows[0]["S3"];
                    textEdit客户地址.EditValue = dt.Rows[0]["S4"];

                    textEdit利润.EditValue = dt.Rows[0]["D3"];

                    textEdit收款利润.EditValue = dt.Rows[0]["D4"];
                    textEdit业务费用倍数.EditValue = dt.Rows[0]["D5"];
                    textEdit个人利润.EditValue = dt.Rows[0]["D6"];

                    dateEdit最后收款时间.EditValue = dt.Rows[0]["Date1"];
                    string hno = dt.Rows[0]["HistoryNum"].ToString().Trim();
                    
                    sSQL = "select a.*, 'edit' as iSave,cast(null as decimal(16,6)) as 引用量,cast(a.iQuantity as decimal(16,6)) as 历史数量,cast(a.iSampleQuantity as decimal(16,6)) as 历史样品数量,cast(isnull(a.iQuantity,0)+isnull(a.iSampleQuantity,0) as decimal(16,6)) as 历史,iRowNo as 行标记 from " + tablenames + " a left join  Inventory i on a.cInvCode=i.cInvCode "
                    + " left join ComputationUnitGroup g on i.cGroupCode=g.cGroupCode where ID=" + iID + " and HistoryNum='" + hno + "' order by iRowNo";


                    dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
                    gridControl1.DataSource = dtBingGrid;

                    SetEnabled(false);


                    sSQL = "select a.*,cast(null as decimal(16,6)) as 历史,iRowNo as 行标记,b.cInvClassCode from " + tablenamel + " a left join Inventory b on a.cInvCode=b.cInvCode where a.ID=" + iID + " and HistoryNum='" + hno + "'";
                    dt子件 = clsSQLCommond.ExecQuery(sSQL);

                    sSQL = "select *,cast(DD1*DD2 as decimal(16,6)) as sCount from " + tablenamec + " where ID=" + iID + " and HistoryNum='" + hno + "'";
                    dt业务费用 = clsSQLCommond.ExecQuery(sSQL);

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
        }

        /// <summary>
        /// 下拉列表框
        /// </summary>
        private void SetLookUpEdit()
        {
            系统服务.LookUp.SaleTypeAll(lookUpEdit销售类型);
            ItemLookUpEditcInvCode.Properties.DataSource = 系统服务.LookUp.Inventory();
            ItemLookUpEditcInvName.Properties.DataSource = 系统服务.LookUp.Inventory();
            ItemLookUpEdit物料属性.Properties.DataSource = 系统服务.LookUp._LoopUpData("9");
            系统服务.LookUp.Person(lookUpEdit业务员);
            系统服务.LookUp.Department(lookUpEdit部门);
            系统服务.LookUp.Customer(lookUpEdit客户);
            系统服务.LookUp.Packing(ItemLookUpEdit包装方式);

            系统服务.LookUp.TradeClass(lookUpEdit行业);
            系统服务.LookUp.CustomerClass(lookUpEdit客户分类);
            系统服务.LookUp.DistrictClass(lookUpEdit区域);
            系统服务.LookUp._LoopUpData(lookUpEdit新老客户, "16");
            系统服务.LookUp._LoopUpData(lookUpEdit付款条件, "11");
            系统服务.LookUp.Inventory3(ItemLookUpEdit物料代码);

            系统服务.LookUp.Cooperation(lookUpEdit合作方式);
            系统服务.LookUp.ShippingChoice(lookUpEdit发运方式);
            系统服务.LookUp.SOStatType(lookUpEdit统计类型);
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
            textEdit业务费用.Enabled = false;
            textEdit8位数编码.Enabled = b;

            buttonEdit业务员.Enabled = b;
            buttonEdit部门.Enabled = b;
            buttonEdit客户.Enabled = b;
            lookUpEdit销售类型.Enabled = b;
            gridView1.OptionsBehavior.Editable = b;

            lookUpEdit行业.Enabled = false;
            lookUpEdit客户分类.Enabled = false;
            lookUpEdit区域.Enabled = false;
            lookUpEdit合作方式.Enabled = b;

            lookUpEdit新老客户.Enabled = b;
            dateEdit实际到货时间.Enabled = b;
            textEdit预计到货天数.Enabled = b;
            textEdit运行成本.Enabled = b;
            lookUpEdit付款条件.Enabled = b;
            lookUpEdit发运方式.Enabled = b;
            textEdit发运金额.Enabled = b;
            textEdit利润分成.Enabled = b;
            textEdit客户地址.Enabled = b;
            textEdit客户联系电话.Enabled = b;
            textEdit客户联系人.Enabled = b;
            lookUpEdit统计类型.Enabled = b;

            textEdit个人利润.Enabled = b;
            textEdit业务费用倍数.Enabled = b;
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
            textEdit业务费用.EditValue = "";
            textEdit8位数编码.EditValue = "";

            buttonEdit业务员.EditValue = "";
            buttonEdit部门.EditValue = "";
            buttonEdit客户.EditValue = "";
            lookUpEdit销售类型.EditValue = "";
            lookUpEdit合作方式.EditValue = "";

            lookUpEdit行业.EditValue = "";
            lookUpEdit客户分类.EditValue = "";
            lookUpEdit区域.EditValue = "";
            lookUpEdit客户.EditValue = "";
            lookUpEdit发运方式.EditValue = "";
            textEdit发运金额.EditValue = "";

            lookUpEdit新老客户.EditValue = DBNull.Value;
            dateEdit实际到货时间.EditValue = DBNull.Value;
            textEdit运行成本.EditValue = "";
            textEdit预计到货天数.EditValue = "";
            lookUpEdit付款条件.EditValue = DBNull.Value;
            textEdit利润分成.EditValue = "";
            textEdit客户地址.EditValue = "";
            textEdit客户联系电话.EditValue = "";
            textEdit客户联系人.EditValue = "";

            textEdit个人利润.EditValue = "";
            textEdit业务费用倍数.EditValue = "";

            textEditDelS.EditValue = "";

            gridControl1.DataSource = null;
            dt子件 = null;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
        }


        private decimal GetPrice(string cInvCode)
        {
            sSQL = "select a.* from SO_SOSublist a left join SO_SOMain b on b.ID=a.ID where  a.cInvCode='" + cInvCode + "' order by b.dDate desc,a.ID desc";
            DataTable dtjgs = clsSQLCommond.ExecQuery(sSQL);
            if (dtjgs.Rows.Count > 0)
            {
                return ReturnDecimal(dtjgs.Rows[0]["D1"]);
            }
            return 0;
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
        }

        private void ItemButtonEditcInvCode_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void buttonEdit业务员_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit业务员.Text.Trim() != "")
            {
                lookUpEdit业务员.EditValue = buttonEdit业务员.Text.Trim();
            }
            else
            {
                lookUpEdit业务员.EditValue = null;
                buttonEdit部门.EditValue = null;
            }
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
            }
            else
            {
                buttonEdit客户.EditValue = null;
                lookUpEdit业务员.EditValue = null;
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

    }
}
