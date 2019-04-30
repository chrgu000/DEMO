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
    public partial class Frm销售订单 : 系统服务.FrmBaseInfo
    {
        decimal 乘数 = 0.1M;
        string tablename = "SO_SOMain";
        string tableid = "cSOCode";
        string tablenames = "SO_SODetails";
        string tablenamel = "SO_SOSublist";
        string tablenamec = "SO_SOMainCommissiion";

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
        public string 收款日期1 = "";
        public string 收款日期2 = "";

        public string 删除 = "";
        public string 删除业务费用 = "";

        public DataTable dt子件;

        public DataTable dt业务费用;

        string isChange = "";


        public Frm销售订单(long siID)
        {
            iID = siID;
            InitializeComponent();

        }

        public Frm销售订单()
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
            try
            {
                string sErr = "";
                if (iID < 0)
                {
                    sErr = sErr + "没有单据，无法查询历史记录";
                }
                //throw new Exception("没有单据，无法查询历史记录");
                sSQL = "select * from " + tablename + "History a where ID='" + iID + "'";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count == 0)
                {
                    sErr = sErr + "无变更历史记录"; 
                }

                if (sErr == "")
                {
                    Frm销售订单历史 frm = new Frm销售订单历史(iID);
                    frm.Tag = frm.Name;
                    frm.MdiParent = this.MdiParent;

                    frm.Show();
                    if (DialogResult.OK == frm.ShowDialog())
                    {
                        frm.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show(sErr);
                }

            }
            catch (Exception ee)
            { }
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
            Frm销售订单_Add frm = new Frm销售订单_Add(单据号1, 单据号2, 单据日期1, 单据日期2, 制单日期1, 制单日期2, 业务员,
               部门, 客户1, 客户2, 审核日期1, 审核日期2, 制单人1, 制单人2, 审核人1, 审核人2, 物料1, 物料2,ECode, 收款日期1, 收款日期2);
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
                收款日期1 = frm.收款日期1;
                收款日期2 = frm.收款日期2;
                GetSel();
            }

        }

        private void GetSel()
        {
            string sSQL = "select * from " + tablename + " a left join " + tablenames + "  b on a.ID=b.ID where 1=1 ";
            if (系统服务.ClsBaseDataInfo.sUid != "admin")
            {
                sSQL = sSQL + " and cSTCode in (select cSTCode from SaleRole where vchrUid='" + 系统服务.ClsBaseDataInfo.sUid + "') ";
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
            if (收款日期1 != "")
            {
                sSQL = sSQL + " and a.Date1>='" + 收款日期1 + "'";
            }
            if (收款日期2 != "")
            {
                sSQL = sSQL + " and a.Date1<='" + 收款日期2 + "'";
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
                sSQL = "select min(ID) as ID from " + tablename + "  where 1=1 ";

                if (系统服务.ClsBaseDataInfo.sUid != "admin")
                {
                    sSQL = sSQL + " and cSTCode in (select cSTCode from SaleRole where vchrUid='" + 系统服务.ClsBaseDataInfo.sUid + "')";
                }

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
                    sSQL = "select ID from " + tablename + " where ID<" + textEditID.EditValue.ToString().Trim() + " ";

                    if (系统服务.ClsBaseDataInfo.sUid != "admin")
                    {
                        sSQL = sSQL + " and cSTCode in (select cSTCode from SaleRole where vchrUid='" + 系统服务.ClsBaseDataInfo.sUid + "')";
                    }

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
                    sSQL = "select ID from " + tablename + " where ID>" + textEditID.EditValue.ToString().Trim() + " ";

                    if (系统服务.ClsBaseDataInfo.sUid != "admin")
                    {
                        sSQL = sSQL + " and cSTCode in (select cSTCode from SaleRole where vchrUid='" + 系统服务.ClsBaseDataInfo.sUid + "')";
                    }

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
                sSQL = "select isnull(max(ID),-1) as ID from " + tablename + " where 1=1 ";

                if (系统服务.ClsBaseDataInfo.sUid != "admin")
                {
                    sSQL = sSQL + " and cSTCode in (select cSTCode from SaleRole where vchrUid='" + 系统服务.ClsBaseDataInfo.sUid + "')";
                }

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
            Frm销售订单业务费用_Add frm = new Frm销售订单业务费用_Add(textEditID.EditValue.ToString().Trim(), dt业务费用, b, sState, lookUpEdit客户.EditValue.ToString().Trim(), 数量,cInvCode, 删除业务费用);
            if (DialogResult.OK == frm.ShowDialog())
            {
                frm.Enabled = true;
                dt业务费用 = frm.dttmp;
                删除业务费用 = frm.删除;
                textEdit业务费用.EditValue = frm.业务费用;
            }
        }
        /// <summary>
        /// 解锁  生成出库单
        /// </summary>
        private void btnUnLock()
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
            //if (iRe == 2 && sState == "edit")
            //{
            //    throw new Exception("单据已审核");
            //}
            if (iRe == 3)
            {
                throw new Exception("单据已关闭");
            }

            sSQL = "select * from SO_SOOutDetails where SoAutoID in (select AutoID from " + tablename + " a left join " + tablenames + " b on a.ID=b.ID where a.ID='" + textEditID.EditValue + "')";
            DataTable dtc = clsSQLCommond.ExecQuery(sSQL);
            if (dtc.Rows.Count > 0)
            {
                throw new Exception("已生成销售出库单");
            }

            string sErr = "";
            aList = new System.Collections.ArrayList();

            sSQL = "select * from SO_SOOutMain where 1=-1";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            sSQL = "select * from SO_SOOutDetails where 1=-1";
            DataTable dts = clsSQLCommond.ExecQuery(sSQL);
            sSQL = "select * from SO_SOOutSublist where 1=-1";
            DataTable dtsl = clsSQLCommond.ExecQuery(sSQL);

            sSQL = "select isnull(max(ID)+1,1) as ID from SO_SOOutMain";
            long siID = long.Parse(clsSQLCommond.ExecQuery(sSQL).Rows[0][0].ToString());
            sSQL = "select isnull(max(AutoID)+1,1) as AutoID from SO_SOOutDetails";
            long sAutoID = long.Parse(clsSQLCommond.ExecQuery(sSQL).Rows[0][0].ToString());
            sSQL = "select isnull(max(sID)+1,1) as AutoID from SO_SOOutSublist" ;
            long sID = long.Parse(clsSQLCommond.ExecQuery(sSQL).Rows[0][0].ToString());

            #region 表头
            DataRow drh = dt.NewRow();
            drh["ID"] = siID;
            string cCode = 系统服务.序号.GetNewSerialNumberContinuous("SO_SOOutMain", "cSOOutCode");
            drh["cSOOutCode"] = cCode;
            drh["dDate"] = dateEdit单据日期.EditValue.ToString().Trim();
            drh["cPersonCode"] = buttonEdit业务员.EditValue.ToString().Trim();
            drh["cWhCode"] = "01";
            drh["cCusCode"] = buttonEdit客户.EditValue.ToString().Trim();
            drh["cSendPersonCode"] = "";
            drh["cOutCode"] = "11";
            drh["Flag"] = "1";
            
            drh["cMemo"] = "";
            drh["dCreatesysTime"] = 系统服务.ClsBaseDataInfo.sLogDate;
            drh["dCreatesysPerson"] = 系统服务.ClsBaseDataInfo.sUid;
            drh["dVerifysysTime"] = 系统服务.ClsBaseDataInfo.sLogDate;
            drh["dVerifysysPerson"] = 系统服务.ClsBaseDataInfo.sUid;
            dt.Rows.Add(drh);
            sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, "SO_SOOutMain", dt, 0);
            aList.Add(sSQL);
            #endregion

            #region 子表
            sSQL = "select * from " + tablenames + " where ID='" + textEditID.EditValue + "'";
            DataTable dtns = clsSQLCommond.ExecQuery(sSQL);
            for (int i = 0; i < dtns.Rows.Count; i++)
            {
                #region 生成table
                DataRow dr = dts.NewRow();
                dr["ID"] = siID;
                dr["AutoID"] = sAutoID;
                dr["cSOOutCode"] = cCode;
                dr["iRowNo"] = i+1;
                dr["SoAutoID"] = dtns.Rows[i]["AutoID"];
                dr["cInvCode"] = dtns.Rows[i]["cInvCode"];
                dr["cInvStd"] = dtns.Rows[i]["cInvStd"];
                dr["iQuantity"] = dtns.Rows[i]["iQuantity"];
                string std = dtns.Rows[i]["cInvStd"].ToString().Split('/')[0];

                dr["D1"] = ReturnDecimal(dtns.Rows[i]["iQuantity"]) / ReturnDecimal(std);
                if (dtns.Rows[i]["iNum"].ToString() != "")
                {
                    dr["iNum"] = dtns.Rows[i]["iNum"];
                }
                if (dtns.Rows[i]["iUnitPrice"].ToString() != "")
                {
                    dr["iUnitPrice"] = dtns.Rows[i]["iUnitPrice"];
                }
                if (dtns.Rows[i]["iMoney"].ToString() != "")
                {
                    dr["iMoney"] = dtns.Rows[i]["iMoney"];
                }
                if (dtns.Rows[i]["iNatUnitPrice"].ToString() != "")
                {
                    dr["iNatUnitPrice"] = dtns.Rows[i]["iNatUnitPrice"];
                }
                if (dtns.Rows[i]["iNatMoney"].ToString() != "")
                {
                    dr["iNatMoney"] = dtns.Rows[i]["iNatMoney"];
                }
                if (dtns.Rows[i]["iTaxRate"].ToString() != "")
                {
                    dr["iTaxRate"] = dtns.Rows[i]["iTaxRate"];
                }
                if (dtns.Rows[i]["iNatTax"].ToString() != "")
                {
                    dr["iNatTax"] = dtns.Rows[i]["iNatTax"];
                }
                if (dtns.Rows[i]["iChangRate"].ToString() != "")
                {
                    dr["iChangRate"] = dtns.Rows[i]["iChangRate"];
                }
                dts.Rows.Add(dr);
                sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, "SO_SOOutDetails", dts, dts.Rows.Count - 1);

                aList.Add(sSQL);

                #endregion
                #region 出库子件
                sSQL = "select * from " + tablenamel + " where AutoID='" + dtns.Rows[i]["AutoID"].ToString() + "'";
                DataTable dtcs = clsSQLCommond.ExecQuery(sSQL);
                for (int j = 0; j < dtcs.Rows.Count; j++)
                {
                    DataRow drl = dtsl.NewRow();
                    drl["sID"] = sID;
                    drl["ID"] = siID;
                    drl["AutoID"] = sAutoID;
                    drl["iRowNo"] = j+1;
                    drl["cSOOutCode"] = cCode;
                    drl["cInvCode"] = dtcs.Rows[j]["cInvCode"].ToString();
                    drl["iQuantity"] = ReturnDecimal(dtcs.Rows[j]["iQuantity"].ToString()) ;
                    drl["iUsedQty"] = dtcs.Rows[j]["iUsedQty"].ToString();
                    if (dtcs.Rows[j]["iNum"].ToString() != "")
                    {
                        drl["iNum"] = ReturnDecimal(dtcs.Rows[j]["iNum"].ToString()) ;
                    }
                    if (dtcs.Rows[j]["iChangRate"].ToString() != "")
                    {
                        drl["iChangRate"] = dtcs.Rows[j]["iChangRate"].ToString();
                    }
                    dtsl.Rows.Add(drl);
                    sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, "SO_SOOutSublist", dtsl, dtsl.Rows.Count - 1);
                    aList.Add(sSQL);
                    sID = sID + 1;
                }
                #endregion
                sAutoID = sAutoID + 1;
            }
            #endregion

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("生成销售出库单成功！\n合计执行语句:" + iCou + "条");

            }

        }
        /// <summary>
        /// 增行 引用
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
            Frm销售订单子件_Add frm = new Frm销售订单子件_Add(AutoID, 行标记, dttmp, 物料编码, 物料名称, 规格型号, b, 删除,sState,数量);
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
                    textEditDelS.EditValue =删除;
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
            Get利润();
            
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
                    if (ReturnDecimal(gridView1.GetRowCellDisplayText(i, gridCol引用量).ToString().Trim().ToString()) > 0)
                    {
                        sErr = sErr + "行" + (i + 1) + "已引用\n";
                    }
                    else
                    {
                        string 行标记 = gridView1.GetRowCellDisplayText(i, gridCol行标记).ToString().Trim();
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

                        for (int j = dt子件.Rows.Count - 1; j >= 0; j--)
                        {
                            if (dt子件.Rows[j]["行标记"].ToString() == 行标记)
                            {
                                dt子件.Rows.Remove(dt子件.Rows[j]);
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellDisplayText(i, gridCol序号).ToString().Trim() != "")
                {
                    gridView1.SetRowCellValue(i, gridCol序号, i + 1);
                }
            }
            Get利润();
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

            sSQL = "select a.*,i.cInvName,i.cInvStd, 'edit' as iSave,cast(null as decimal(16,6)) as 引用量,cast(null as decimal(16,6)) as 历史数量,cast(null as decimal(16,6)) as 历史样品数量,cast(null as decimal(16,6)) as 历史,iRowNo as 行标记 from " + tablenames + " a left join  Inventory i on a.cInvCode=i.cInvCode "
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

            dt子件 = clsSQLCommond.ExecQuery("select *,cast(null as decimal(16,6)) as 历史,iRowNo as 行标记,'' as cInvClassCode from " + tablenamel + " where 1=-1");

            dt业务费用 = clsSQLCommond.ExecQuery("select *,cast(null as decimal(16,6)) as sCount,cast(null as decimal(16,6)) as 引用量,cast(DD1 as decimal(16,6)) as 历史DD1,cast(DD2 as decimal(16,6)) as 历史DD2 from " + tablenamec + " where 1=-1");

            gridView1.OptionsBehavior.Editable = true;
            textEdit运行成本.EditValue = "2.7";
            //textEdit业务费用倍数.EditValue = "1.5";
            lookUpEdit统计类型.EditValue = "001";
            sState = "add";
            删除 = "";
            删除业务费用 = "";
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
            删除业务费用 = "";
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

                sSQL = "delete " + tablenamec + " where ID ='" + textEditID.EditValue.ToString().Trim() + "'";
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
            sSQL = "select * from " + tablenamec + " where 1=-1";
            DataTable dtsc = clsSQLCommond.ExecQuery(sSQL);
            if (buttonEdit客户.EditValue == null || buttonEdit客户.EditValue.ToString().Trim() == "")
            {
                throw new Exception("客户不能为空");
            }
            if (buttonEdit业务员.EditValue == null || buttonEdit业务员.EditValue.ToString().Trim() == "")
            {
                throw new Exception("业务员不能为空");
            }
            if (buttonEdit部门.EditValue == null || buttonEdit部门.EditValue.ToString().Trim() == "")
            {
                throw new Exception("部门不能为空");
            }
            if (dateEdit单据日期.EditValue == null || dateEdit单据日期.EditValue.ToString().Trim() == "")
            {
                throw new Exception("单据日期不能为空");
            }
            if (lookUpEdit销售类型.EditValue == null || lookUpEdit销售类型.EditValue.ToString().Trim() == "")
            {
                throw new Exception("销售类型不能为空");
            }
            //if (textEdit佣金.EditValue == null || textEdit佣金.EditValue.ToString().Trim() == "")
            //{
            //    throw new Exception("业务费用不能为空");
            //}

            if (lookUpEdit合作方式.EditValue == null || lookUpEdit合作方式.EditValue.ToString().Trim() == "")
            {
                throw new Exception("合作方式不可为空");
            }

            if (textEdit8位数编码.EditValue == null || textEdit8位数编码.EditValue.ToString().Trim() == "")
            {
                throw new Exception("8位数编码不能为空");
            }
            
            if (textEdit8位数编码.EditValue.ToString().Trim().Length != 8)
            {
                throw new Exception("8位数编码必须为8位");
            }

            
            if (sState == "add")
            {
                sSQL = "select ECode from " + tablename + " where ECode='" + textEdit8位数编码.EditValue + "'";
                DataTable dte = clsSQLCommond.ExecQuery(sSQL);
                if (dte.Rows.Count > 0)
                {
                    throw new Exception("8位数编码不可重复");
                }
            }
            try
            {
                float shuzi = float.Parse(textEdit8位数编码.EditValue.ToString().Trim());
            }
            catch
            {
                throw new Exception("8位数编码必须为数字");
            }
            if (textEdit8位数编码.EditValue.ToString().Trim().IndexOf('.') >= 0)
            {
                throw new Exception("8位数编码不可有“.”");
            }
            if (textEdit发运金额.EditValue != null && textEdit发运金额.EditValue.ToString().Trim() != "")
            {
                try
                {
                    float shuzi = float.Parse(textEdit发运金额.EditValue.ToString().Trim());
                }
                catch
                {
                    throw new Exception("发运金额必须为数字");
                }
            }
            if (textEdit利润分成.EditValue == null || textEdit利润分成.EditValue.ToString().Trim() == "")
            {
                throw new Exception("利润分成必须填写");
            }
            else
            {
                try
                {
                    float lf = float.Parse(textEdit利润分成.EditValue.ToString().Trim());
                    if (lf > 100 || lf < 0)
                    {
                        throw new Exception("利润分成必须在0-100之间");
                    }
                }
                catch
                {
                    throw new Exception("利润分成必须为数字");
                }
            }


            if (textEdit业务费用倍数.EditValue == null || textEdit业务费用倍数.EditValue.ToString().Trim() == "")
            {
                throw new Exception("业务费用倍数不可为空");
            }
            if (lookUpEdit新老客户.EditValue == null || lookUpEdit新老客户.EditValue.ToString().Trim() == "")
            {
                throw new Exception("新老客户不可为空");
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
                drh["cSOCode"] = 系统服务.序号.GetNewSerialNumberContinuous(tablename, tableid);
                textEdit单据号.EditValue = drh["cSOCode"].ToString();
            }
            else
            {
                drh["ID"] = textEditID.EditValue.ToString().Trim();
                iID = Convert.ToInt64(textEditID.EditValue);
                drh["cSOCode"] = textEdit单据号.EditValue.ToString().Trim();
            }
            drh["dDate"] = dateEdit单据日期.EditValue.ToString().Trim();

            drh["cPersonCode"] = buttonEdit业务员.EditValue.ToString().Trim();
            drh["cDepCode"] = buttonEdit部门.EditValue.ToString().Trim();
            drh["cCusCode"] = buttonEdit客户.EditValue.ToString().Trim();
            drh["cSTCode"] = lookUpEdit销售类型.EditValue.ToString().Trim();
            drh["cSTTCode"] = lookUpEdit统计类型.EditValue;
            if (textEdit业务费用.EditValue != null && textEdit业务费用.EditValue.ToString().Trim() != "")
            {
                drh["D7"] = textEdit业务费用.EditValue;
            }
            if (lookUpEdit发运方式.EditValue != null && lookUpEdit发运方式.EditValue.ToString().Trim() != "")
            {
                drh["S1"] = lookUpEdit发运方式.EditValue.ToString().Trim();
            }
            if (textEdit发运金额.EditValue != null && textEdit发运金额.EditValue.ToString().Trim()!="")
            {
                drh["D1"] = textEdit发运金额.EditValue.ToString().Trim();
            }
            drh["D2"] = textEdit利润分成.EditValue.ToString().Trim();
            if (textEdit利润.EditValue != null && textEdit利润.EditValue.ToString().Trim() != "")
            {
                drh["D3"] = textEdit利润.EditValue.ToString().Trim();
            }
            if (textEdit收款利润.EditValue != null && textEdit收款利润.EditValue.ToString().Trim() != "")
            {
                drh["D4"] = textEdit收款利润.EditValue.ToString().Trim();
            }
            if (textEdit业务费用倍数.EditValue != null && textEdit业务费用倍数.EditValue.ToString().Trim() != "")
            {
                drh["D5"] = textEdit业务费用倍数.EditValue.ToString().Trim();
            }
            if (textEdit个人利润.EditValue != null && textEdit个人利润.EditValue.ToString().Trim() != "")
            {
                drh["D6"] = textEdit个人利润.EditValue.ToString().Trim();
            }

            if (dateEdit最后收款时间.EditValue != null && dateEdit最后收款时间.EditValue.ToString().Trim() != "")
            {
                drh["Date1"] = dateEdit最后收款时间.EditValue.ToString().Trim();
            }
            if (textEdit业务费用.EditValue != null && textEdit业务费用.EditValue.ToString().Trim() != "")
            {
                try
                {
                    float shuzi = float.Parse(textEdit业务费用.EditValue.ToString().Trim());
                }
                catch
                {
                    throw new Exception("业务费用必须为数字");
                }
                drh["Commission"] = ReturnDecimal(textEdit业务费用.EditValue.ToString().Trim());
            }

            drh["cDCCode"] = lookUpEdit区域.EditValue.ToString().Trim();
            drh["cTrade"] = lookUpEdit行业.EditValue.ToString().Trim();
            drh["cCCCode"] = lookUpEdit客户分类.EditValue.ToString().Trim();

            drh["cMemo"] = textEdit备注.EditValue.ToString().Trim();

            drh["ECode"] = textEdit8位数编码.EditValue.ToString().Trim();

            drh["cCCode"] = lookUpEdit合作方式.EditValue.ToString().Trim();
            drh["S2"] = textEdit客户联系人.EditValue.ToString().Trim();
            drh["S3"] = textEdit客户联系电话.EditValue.ToString().Trim();
            drh["S4"] = textEdit客户地址.EditValue.ToString().Trim();

            if (textEdit预计到货天数.EditValue != null && textEdit预计到货天数.EditValue.ToString().Trim() != "")
            {
                try
                {
                    float shuzi = float.Parse(textEdit预计到货天数.EditValue.ToString().Trim());
                }
                catch
                {
                    throw new Exception("预计到货天数必须为数字");
                }
                drh["ArrDays"] = textEdit预计到货天数.EditValue.ToString().Trim();
            }
            if (dateEdit实际到货时间.EditValue != null && dateEdit实际到货时间.EditValue.ToString().Trim() != "")
            {
                drh["ArrDate"] = dateEdit实际到货时间.EditValue.ToString().Trim();
            }
            drh["CusType"] = lookUpEdit新老客户.EditValue.ToString().Trim();
            if (textEdit运行成本.EditValue != null && textEdit运行成本.EditValue.ToString().Trim() != "")
            {
                try
                {
                    float shuzi = float.Parse(textEdit运行成本.EditValue.ToString().Trim());
                }
                catch
                {
                    throw new Exception("运行成本必须为数字");
                }
                drh["cPayCode"] = lookUpEdit付款条件.EditValue.ToString().Trim();
            }
            if (textEdit运行成本.EditValue != null && textEdit运行成本.EditValue.ToString().Trim() != "")
            {
                drh["Cost"] = textEdit运行成本.EditValue.ToString().Trim();
            }

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
                系统服务.变更表.GetChange(tablename, tablenames, tablenamel,tablenamec, textEditID.EditValue.ToString().Trim(), clsGetSQL, aList);
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


            if (删除业务费用 != "")
            {
                if (删除业务费用 != "")
                {
                    string[] strdel = 删除业务费用.Trim().Split(',');
                    for (int i = 0; i < strdel.Length; i++)
                    {
                        if (strdel[i].Trim() != "")
                        {
                            sSQL = "delete  from " + tablenamec + " where CID ='" + strdel[i] + "'";
                            aList.Add(sSQL);
                        }
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

                    if (ReturnDecimal(gridView1.GetRowCellValue(i, gridCol数量)) < 0)
                    {
                        sErr = sErr + "行" + (i + 1) + gridCol数量.Caption + "必须大于或等于0\n";
                        continue;
                    }
                    if (ReturnDecimal(gridView1.GetRowCellValue(i, gridCol含税单价)) == 0)
                    {
                        sErr = sErr + "行" + (i + 1) + gridCol无税单价.Caption + "不能为0\n";
                        continue;
                    }

                    if (gridView1.GetRowCellValue(i, gridCol包装方式).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + gridCol包装方式.Caption + "不能为空\n";
                        continue;
                    }

                    if (gridView1.GetRowCellValue(i, gridCol规格型号).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + gridCol规格型号.Caption + "不能为空\n";
                        continue;
                    }

                    if (gridView1.GetRowCellValue(i, gridCol包).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + gridCol包.Caption + "不能为空\n";
                        continue;
                    }

                    //try
                    //{
                    //    float shuzi = float.Parse(gridView1.GetRowCellValue(i, gridCol规格型号).ToString().Trim());
                    //}
                    //catch
                    //{
                    //    sErr = sErr + "行" + (i + 1) + gridCol规格型号.Caption + "必须为数字\n";
                    //}

                    sSQL = "select cInvCode from Inventory where cInvCode='" + gridView1.GetRowCellDisplayText(i, gridCol物料编码).ToString().Trim() + "'";
                    DataTable dtinv = clsSQLCommond.ExecQuery(sSQL);
                    if (dtinv.Rows.Count == 0)
                    {
                        sErr = sErr + "行" + (i + 1) + "无此物料\n";
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
                    string iRowNo = gridView1.GetRowCellValue(i, gridCol序号).ToString().Trim();
                    dr["ID"] = iID;
                    dr["cSOCode"] = textEdit单据号.EditValue.ToString().Trim();
                    dr["iRowNo"] = iRowNo;
                    dr["cInvCode"] = gridView1.GetRowCellValue(i, gridCol物料编码).ToString().Trim();
                    dr["cInvStd"] =gridView1.GetRowCellValue(i, gridCol规格型号);
                    dr["cInvCodeType"] = gridView1.GetRowCellValue(i, gridCol物料属性).ToString().Trim();
                    dr["cPCode"] = gridView1.GetRowCellValue(i, gridCol包装方式).ToString().Trim();
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
                        if (lookUpEdit销售类型.EditValue != null && lookUpEdit销售类型.EditValue.ToString().Trim() == "02")
                        {
                            dr["iNatUnitPrice"] = gridView1.GetRowCellValue(i, gridCol含税单价).ToString().Trim();
                        }
                        else
                        {
                            dr["iNatUnitPrice"] = gridView1.GetRowCellValue(i, gridCol无税单价).ToString().Trim();
                        }
                    }
                    if (gridView1.GetRowCellValue(i, gridCol无税金额) != null && gridView1.GetRowCellValue(i, gridCol无税金额).ToString().Trim() != "")
                    {
                        if (lookUpEdit销售类型.EditValue != null && lookUpEdit销售类型.EditValue.ToString().Trim() == "02")
                        {
                            dr["iNatMoney"] = gridView1.GetRowCellValue(i, gridCol含税金额).ToString().Trim();
                        }
                        else
                        {
                            dr["iNatMoney"] = gridView1.GetRowCellValue(i, gridCol无税金额).ToString().Trim();
                        }
                    }
                    if (gridView1.GetRowCellValue(i, gridCol税率) != null && gridView1.GetRowCellValue(i, gridCol税率).ToString().Trim() != "")
                    {
                        if (lookUpEdit销售类型.EditValue != null && lookUpEdit销售类型.EditValue.ToString().Trim() == "02")
                        {
                            dr["iTaxRate"] = 0;
                        }
                        else
                        {
                            dr["iTaxRate"] = gridView1.GetRowCellValue(i, gridCol税率).ToString().Trim();
                        }
                    }
                    if (gridView1.GetRowCellValue(i, gridCol税额) != null && gridView1.GetRowCellValue(i, gridCol税额).ToString().Trim() != "")
                    {
                        dr["iNatTax"] = gridView1.GetRowCellValue(i, gridCol税额).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol换算率) != null && gridView1.GetRowCellValue(i, gridCol换算率).ToString().Trim() != "")
                    {
                        dr["iChangRate"] = gridView1.GetRowCellValue(i, gridCol换算率).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol样品数量) != null && gridView1.GetRowCellValue(i, gridCol样品数量).ToString().Trim() != "")
                    {
                        dr["iSampleQuantity"] = gridView1.GetRowCellValue(i, gridCol样品数量).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol样品件数) != null && gridView1.GetRowCellValue(i, gridCol样品件数).ToString().Trim() != "")
                    {
                        dr["iSampleNum"] = gridView1.GetRowCellValue(i, gridCol样品件数).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol数量小计) != null && gridView1.GetRowCellValue(i, gridCol数量小计).ToString().Trim() != "")
                    {
                        dr["iSubtotalQuantity"] = gridView1.GetRowCellValue(i, gridCol数量小计).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol件数小计) != null && gridView1.GetRowCellValue(i, gridCol件数小计).ToString().Trim() != "")
                    {
                        dr["iSubtotalNum"] = gridView1.GetRowCellValue(i, gridCol件数小计).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol包) != null && gridView1.GetRowCellValue(i, gridCol包).ToString().Trim() != "")
                    {
                        dr["D1"] = gridView1.GetRowCellValue(i, gridCol包).ToString().Trim();
                    }
                    dr["cMemo"] = gridView1.GetRowCellValue(i, gridCol备注).ToString().Trim();

                    //if (gridView1.GetRowCellDisplayText(i, gridCol利润分成).ToString() != "")
                    //{
                    //    decimal d1 = ReturnDecimal(gridView1.GetRowCellDisplayText(i, gridCol利润分成).ToString());
                    //    if (d1 <= 100 && d1 >= 0)
                    //    {
                    //        dr["D1"] = gridView1.GetRowCellValue(i, gridCol利润分成).ToString().Trim();
                    //    }
                    //    else
                    //    {
                    //        sErr = sErr + "行" + (i + 1) + gridCol利润分成.Caption + "在0-100之间\n";
                    //    }
                    //}
                    //else
                    //{
                    //    dr["D1"] = DBNull.Value;
                    //}


                    //dr["cClosesysPerson"] = gridView1.GetRowCellValue(i, gridCol行关闭人).ToString().Trim();
                    //dr["cClosesysTime"] = gridView1.GetRowCellValue(i, gridCol行关闭日期).ToString().Trim();

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

                    
                    #region 子件
                    DataRow[] dw = dt子件.Select("行标记='" + 行标记 + "'");
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
                            dwl["cSOCode"] = textEdit单据号.EditValue.ToString().Trim();
                            dwl["iRowNo"] = iRowNo;
                            dwl["cInvCode"] = dw[l]["cInvCode"].ToString();
                            dwl["cSOCode"] = textEdit单据号.EditValue.ToString().Trim();
                            dwl["iQuantity"] = dw[l]["iQuantity"].ToString();
                            dwl["iUsedQty"] = dw[l]["iUsedQty"].ToString();
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
                            else
                            {
                                sErr = sErr + "行" + (i + 1) + "子件单价不能为0\n";
                            }
                            dtsl.Rows.Add(dwl);
                            if (dw[l]["sID"].ToString() == "")
                            {
                                sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablenamel, dtsl, dtsl.Rows.Count - 1);
                            }
                            else
                            {
                                sSQL = clsGetSQL.GetUpdateSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablenamel, dtsl, dtsl.Rows.Count - 1);
                            }
                            aList.Add(sSQL);
                            sID = sID + 1;
                        }
                    }
                    #endregion

                    sAutoID = sAutoID + 1;
                }
            }
            #endregion

            #region 业务费用
            sSQL = "select isnull(max(CID)+1,1) as CID from " + tablenamec;
            long CID = long.Parse(clsSQLCommond.ExecQuery(sSQL).Rows[0][0].ToString());
            for (int i = 0; i < dt业务费用.Rows.Count; i++)
            {
                if (dt业务费用.Rows[i].RowState == DataRowState.Deleted)
                    continue;
                if (dt业务费用.Rows[i]["SS3"].ToString().Trim() == "")
                    continue;
                if (dt业务费用.Rows[i]["SS1"].ToString().Trim() != "" && dt业务费用.Rows[i]["SS2"].ToString().Trim() != "" && dt业务费用.Rows[i]["SS3"].ToString().Trim() != "" && dt业务费用.Rows[i]["DD1"].ToString().Trim() != "" && dt业务费用.Rows[i]["DD2"].ToString().Trim() != "")
                {
                    
                    DataRow dr = dtsc.NewRow();
                    if (dt业务费用.Rows[i]["CID"].ToString() == "")
                    {
                        dr["CID"] = CID;
                    }
                    else
                    {
                        dr["CID"] = dt业务费用.Rows[i]["CID"];
                    }

                    dr["ID"] = iID;
                    dr["SS1"] = dt业务费用.Rows[i]["SS1"];
                    dr["SS2"] = dt业务费用.Rows[i]["SS2"];
                    dr["SS3"] = dt业务费用.Rows[i]["SS3"];
                    dr["SS4"] = dt业务费用.Rows[i]["SS4"];
                    dr["SS5"] = dt业务费用.Rows[i]["SS5"];
                    dr["DD1"] = dt业务费用.Rows[i]["DD1"];
                    dr["DD2"] = dt业务费用.Rows[i]["DD2"];
                    dtsc.Rows.Add(dr);
                    CID = CID + 1;
                    if (dt业务费用.Rows[i]["CID"].ToString() == "")
                    {
                        sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablenamec, dtsc, dtsc.Rows.Count - 1);
                        aList.Add(sSQL);
                    }
                    else
                    {
                        sSQL = clsGetSQL.GetUpdateSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablenamec, dtsc, dtsc.Rows.Count - 1);
                        aList.Add(sSQL);
                    }

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
            if (bCount != 1)
            {
                throw new Exception("销售订单只能有一行");
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
                

                #region 判断是否已全部收款
                System.Collections.ArrayList aList1 = new System.Collections.ArrayList();
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    string SoAutoID = gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim();
                    if (SoAutoID != "")
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
                #endregion
                MessageBox.Show("保存成功！\n合计执行语句:" + iCou + "条");

                textEditID.EditValue = iID;
                textEditDel.EditValue = "";
                textEditDelS.EditValue = "";
                sState = "save";
                删除 = "";
                删除业务费用 = "";
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

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridCol物料编码).ToString().Trim() == "")
                    continue;

                long lAutoID = Convert.ToInt64(gridView1.GetRowCellValue(i, gridColAutoID));
                gridView1.SetRowCellValue(i, gridCol引用量, iCodeUsed(lAutoID));
            }

            sState = "alter";
            SetEnabled(true);
        }

        #endregion

        private void Frm销售订单_Load(object sender, EventArgs e)
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

                sSQL = "select * from " + tablename + " where ID=" + iID + " ";

                if (系统服务.ClsBaseDataInfo.sUid != "admin")
                {
                    sSQL = sSQL + " and cSTCode in (select cSTCode from SaleRole where vchrUid='" + 系统服务.ClsBaseDataInfo.sUid + "')";
                }

                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                
                if (dt.Rows.Count > 0)
                {
                    textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]); ;
                    textEdit单据号.EditValue = dt.Rows[0]["cSOCode"].ToString();

                    dateEdit单据日期.EditValue = dt.Rows[0]["dDate"].ToString();
                    dateEdit制单日期.EditValue = dt.Rows[0]["dCreatesysTime"].ToString();
                    dateEdit审核日期.EditValue = dt.Rows[0]["dVerifysysTime"].ToString();
                    dateEdit关闭日期.EditValue = dt.Rows[0]["dClosesysTime"].ToString();

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
                    
                    sSQL = "select a.*, 'edit' as iSave,cast(null as decimal(16,6)) as 引用量,cast(a.iQuantity as decimal(16,6)) as 历史数量,cast(a.iSampleQuantity as decimal(16,6)) as 历史样品数量,cast(isnull(a.iQuantity,0)+isnull(a.iSampleQuantity,0) as decimal(16,6)) as 历史,iRowNo as 行标记 from " + tablenames + " a left join  Inventory i on a.cInvCode=i.cInvCode "
                    + " left join ComputationUnitGroup g on i.cGroupCode=g.cGroupCode where ID=" + iID + " order by iRowNo";


                    dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
                    gridControl1.DataSource = dtBingGrid;

                   
                    gridView1.AddNewRow();

                    gridView1.FocusedRowHandle = iFocRow;

                    SetEnabled(false);


                    sSQL = "select a.*,cast(null as decimal(16,6)) as 历史,iRowNo as 行标记,b.cInvClassCode from " + tablenamel + " a left join Inventory b on a.cInvCode=b.cInvCode where a.ID=" + iID;
                    dt子件 = clsSQLCommond.ExecQuery(sSQL);

                    sSQL = "select *,cast(DD1*DD2 as decimal(16,6)) as sCount,cast(null as decimal(16,6)) as 引用量,cast(DD1 as decimal(16,6)) as 历史DD1,cast(DD2 as decimal(16,6)) as 历史DD2 from " + tablenamec + " where ID=" + iID;
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
            系统服务.LookUp.SaleTypeSaleRole(lookUpEdit销售类型);
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
            textEdit业务费用倍数.Enabled = b;
            textEdit个人利润.Enabled = false;
            lookUpEdit统计类型.Enabled = b;
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
            textEdit业务费用倍数.EditValue = "";
            textEdit利润.EditValue = "";
            textEdit收款利润.EditValue = "";
            dateEdit最后收款时间.EditValue = "";

            textEdit个人利润.EditValue = "";

            lookUpEdit统计类型.EditValue = "";

            textEditDelS.EditValue = "";

            gridControl1.DataSource = null;
            dt子件 = null;
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

            if (gridView1.GetRowCellValue(iRow, gridCol行标记).ToString().Trim() == "")
            {
                if (iRow == 0)
                {
                    gridView1.SetRowCellValue(iRow, gridCol行标记, 1);
                }
                else
                {
                    gridView1.SetRowCellValue(iRow, gridCol行标记, double.Parse(gridView1.GetRowCellValue(iRow - 1, gridCol行标记).ToString().Trim()) + 1);
                }
            }

            if (e.Column == gridCol物料编码)
            {
                string invocde = gridView1.GetRowCellValue(iRow, gridCol物料编码).ToString().Trim();
                sSQL = "select * from SO_SOMain a left join SO_SODetails b on a.ID=b.ID where cInvCode='" + invocde + "' and cCusCode='" + lookUpEdit客户.EditValue.ToString().Trim() + "' order by dDate desc,b.AutoID desc";
                DataTable dtstd1 = clsSQLCommond.ExecQuery(sSQL);
                if (dtstd1.Rows.Count > 0)
                {
                    gridView1.SetRowCellValue(iRow, gridCol规格型号, dtstd1.Rows[0]["cInvStd"]);
                }
                else
                {
                    sSQL = "select cInvStd from Inventory where cInvCode='" + invocde + "'";
                    DataTable dtstd = clsSQLCommond.ExecQuery(sSQL);
                    if (dtstd.Rows.Count > 0)
                    {
                        gridView1.SetRowCellValue(iRow, gridCol规格型号, dtstd.Rows[0]["cInvStd"]);
                    }
                }
                if (lookUpEdit销售类型.Text.Trim() == "YS")
                {
                    gridView1.SetRowCellValue(iRow, gridCol税率, 0);
                }
                else
                {
                    gridView1.SetRowCellValue(iRow, gridCol税率, 17);
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
            if (e.Column == gridCol物料编码 || e.Column == gridCol数量小计)
            {
                string invocde = gridView1.GetRowCellValue(iRow, gridCol物料编码).ToString().Trim();
                decimal qty = 0;
                if (gridView1.GetRowCellValue(iRow, gridCol数量小计) != null && gridView1.GetRowCellValue(iRow, gridCol数量小计).ToString().Trim() != "")
                {
                    qty = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol数量小计));
                }
                #region 物料变更时
                if (invocde != "")
                {
                    if (e.Column == gridCol物料编码)
                    {
                        bool hasdj = true;
                        #region 删除子件
                        for (int i = dt子件.Rows.Count - 1; i >= 0; i--)
                        {
                            if (dt子件.Rows[i]["iRowNo"].ToString().Trim() == gridView1.GetRowCellValue(iRow, gridCol序号).ToString().Trim())
                            {
                                if (dt子件.Rows[i]["sID"].ToString().Trim() != "")
                                {
                                    if (textEditDelS.EditValue!=null && textEditDelS.EditValue != "")
                                    {
                                        textEditDelS.EditValue = textEditDelS.EditValue + ",";
                                    }
                                    textEditDelS.EditValue = textEditDelS.EditValue + dt子件.Rows[i]["sID"].ToString().Trim();
                                }
                                dt子件.Rows.Remove(dt子件.Rows[i]);
                            }
                        }
                        #endregion

                        sSQL = "select * from SO_SOMain a left join SO_SODetails b on a.ID=b.ID where cInvCode='" + invocde + "' and cCusCode='"+lookUpEdit客户.EditValue.ToString().Trim()+"' order by dDate desc,b.AutoID desc";
                        DataTable dtss = clsSQLCommond.ExecQuery(sSQL);
                        if (dtss.Rows.Count > 0)
                        {
                            gridView1.SetRowCellValue(iRow, gridCol无税单价, ReturnDecimal(dtss.Rows[0]["iNatUnitPrice"]));
                            gridView1.SetRowCellValue(iRow, gridCol含税单价, ReturnDecimal(dtss.Rows[0]["iUnitPrice"]));
                            gridView1.SetRowCellValue(iRow, gridCol税率, ReturnDecimal(dtss.Rows[0]["iTaxRate"]));
                            gridView1.SetRowCellValue(iRow, gridCol包装方式, dtss.Rows[0]["cPCode"]);
                            //if (ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol数量小计)) != ReturnDecimal(dtss.Rows[0]["iQuantity"]))
                            //{
                            //    gridView1.SetRowCellValue(iRow, gridCol数量小计, ReturnDecimal(dtss.Rows[0]["iQuantity"]));
                            //}
                            sSQL = "select c.* from SO_SOMain a left join SO_SODetails b on a.ID=b.ID left join SO_SOSublist c on b.AutoID=c.AutoID where b.AutoID='" + dtss.Rows[0]["AutoID"].ToString() + "' order by dDate desc,c.AutoID desc";
                            DataTable dtso = clsSQLCommond.ExecQuery(sSQL);
                            if (dtso.Rows.Count > 0)
                            {
                                #region 从销售订单中取数
                                decimal sum = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol数量小计));

                                if (gridView1.GetRowCellValue(iRow, gridCol历史) != null && gridView1.GetRowCellValue(iRow, gridCol历史).ToString().Trim() != "")
                                {
                                    gridView1.SetRowCellValue(iRow, gridCol历史, "1");
                                }


                                for (int i = 0; i < dtso.Rows.Count; i++)
                                {
                                    DataRow dw = dt子件.NewRow();
                                    dw["iRowNo"] = gridView1.GetRowCellValue(iRow, gridCol序号);
                                    dw["行标记"] = gridView1.GetRowCellValue(iRow, gridCol行标记);
                                    dw["cInvCode"] = dtso.Rows[i]["cInvCode"].ToString();
                                    //dw["iQuantity"] = ReturnDecimal(ReturnDecimal(dtso.Rows[i]["iQuantity"]));
                                    dw["iUsedQty"] = ReturnDecimal(ReturnDecimal(dtso.Rows[i]["iUsedQty"]));
                                    if (ReturnDecimal(dtso.Rows[i]["iNum"]) != 0)
                                    {
                                        dw["iNum"] = ReturnDecimal(ReturnDecimal(dtso.Rows[i]["iNum"]));
                                        dw["iChangRate"] = ReturnDecimal(dtso.Rows[i]["iChangRate"]);
                                    }
                                    dw["D1"] = GetPrice(dtso.Rows[i]["cInvCode"].ToString());

                                    #region
                                    sSQL = "select * from Inventory where cInvCode='" + dtso.Rows[i]["cInvCode"].ToString() + "'";
                                    DataTable dts = clsSQLCommond.ExecQuery(sSQL);
                                    if (dts.Rows.Count > 0)
                                    {
                                        dw["cInvClassCode"] = dts.Rows[0]["cInvClassCode"].ToString();
                                    }
                                    #endregion
                                    dt子件.Rows.Add(dw);
                                }
                                #endregion

                                #region 业务费用
                                if (invocde != "" && qty != 0)
                                {
                                    bool b = false;
                                    string iCinvCode = "";
                                    for (int i = dt业务费用.Rows.Count - 1; i >= 0; i--)
                                    {
                                        if (dt业务费用.Rows[i]["SS5"].ToString() != invocde)
                                        {
                                            b = true;
                                        }
                                        if (dt业务费用.Rows[i]["SS5"].ToString() != "")
                                        {
                                            if (iCinvCode != "")
                                            {
                                                iCinvCode = iCinvCode + ",";
                                            }
                                            iCinvCode = iCinvCode + dt业务费用.Rows[i]["SS5"].ToString();
                                        }
                                    }
                                    for (int i = dt业务费用.Rows.Count - 1; i >= 0; i--)
                                    {
                                        if (iCinvCode.IndexOf(dt业务费用.Rows[i]["SS5"].ToString()) >= 0)
                                        {
                                            dt业务费用.Rows.Remove(dt业务费用.Rows[i]);
                                        }
                                        else
                                        {
                                            if (dt业务费用.Rows[i]["SS1"].ToString().Trim() == "" && dt业务费用.Rows[i]["SS2"].ToString().Trim() == "" && dt业务费用.Rows[i]["SS3"].ToString().Trim() == "" &&
                                                dt业务费用.Rows[i]["DD1"].ToString().Trim() == "" && dt业务费用.Rows[i]["DD2"].ToString().Trim() == "")
                                            {
                                                dt业务费用.Rows.Remove(dt业务费用.Rows[i]);
                                            }
                                        }
                                    }
                                    if (b == false)
                                    {
                                        sSQL = @"select null as CID, null as ID, SS1, SS2, SS3, SS4, SS5, SS6, SS7, SS8, SS9, SS10, SS11, SS12, SS13, SS14, SS15, SS16, SS17, SS18, SS19, SS20, DD1, DD2, DD3, DD4, DD5, DD6, DD7, 
                      DD8, DD9, TT1, TT2, TT3, TT4, TT5, TT6, TT7, TT8, TT9from SO_SOMain a left join SO_SOMainCommissiion b on a.ID=b.ID left join (select top 1 a.ID from SO_SOMain a left join SO_SODetails b on a.ID=b.ID where cCusCode='" + lookUpEdit客户.EditValue.ToString().Trim() + "' and   b.cInvCode='" + invocde + "'  order by a.ID desc )=a.ID"
                                        +"where a.cCusCode='" + lookUpEdit客户.EditValue.ToString().Trim() + "' and    SS5='" + invocde + "' order by dDate desc,b.CID desc";
                                        DataTable dtc = clsSQLCommond.ExecQuery(sSQL);
                                        if (dtc.Rows.Count > 0)
                                        {
                                            for (int s = 0; s < dtc.Rows.Count; s++)
                                            {
                                                dt业务费用.ImportRow(dtc.Rows[s]);
                                            }
                                        }
                                    }

                                }
                                #endregion
                            }
                        }
                        else
                        {
                            
                            #region 从bom中取数
                            sSQL = "select * from BOM_Main where InvCode='" + invocde + "' and  isnull(dVerifysysTime,'') <> '' order by ID desc";
                            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                            if (dt.Rows.Count > 0)
                            {
                                if (buttonEdit客户.EditValue == null || buttonEdit客户.EditValue == "")
                                {
                                    buttonEdit客户.EditValue = dt.Rows[0]["S1"].ToString();
                                }
                                gridView1.SetRowCellValue(iRow, gridCol无税单价, ReturnDecimal(dt.Rows[0]["iNatUnitPrice"]));
                                gridView1.SetRowCellValue(iRow, gridCol含税单价, ReturnDecimal(dt.Rows[0]["iUnitPrice"]));
                                gridView1.SetRowCellValue(iRow, gridCol税率, ReturnDecimal(dt.Rows[0]["iTaxRate"]));
                                gridView1.SetRowCellValue(iRow, gridCol包装方式, dt.Rows[0]["cPCode"]);
                                sSQL = "select * from BOM_Details where ID='" + dt.Rows[0]["ID"].ToString() + "'";
                                DataTable dttmp = clsSQLCommond.ExecQuery(sSQL);
                                decimal sum = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol数量小计));

                                if (gridView1.GetRowCellValue(iRow, gridCol历史) != null && gridView1.GetRowCellValue(iRow, gridCol历史).ToString().Trim() != "")
                                {
                                    gridView1.SetRowCellValue(iRow, gridCol历史, "1");
                                }

                                for (int i = 0; i < dttmp.Rows.Count; i++)
                                {
                                    DataRow dw = dt子件.NewRow();
                                    dw["iRowNo"] = gridView1.GetRowCellValue(iRow, gridCol序号);
                                    dw["行标记"] = gridView1.GetRowCellValue(iRow, gridCol行标记);
                                    dw["cInvCode"] = dttmp.Rows[i]["cInvCode"].ToString();
                                    dw["iQuantity"] = ReturnDecimal(ReturnDecimal(dttmp.Rows[i]["iQuantity"])) * qty * 乘数;
                                    dw["iUsedQty"] = ReturnDecimal(ReturnDecimal(dttmp.Rows[i]["iQuantity"]));
                                    if (ReturnDecimal(dttmp.Rows[i]["iNum"]) != 0)
                                    {
                                        dw["iNum"] = ReturnDecimal(ReturnDecimal(dttmp.Rows[i]["iNum"])) * qty * 乘数;
                                        dw["iChangRate"] = ReturnDecimal(dttmp.Rows[i]["iChangRate"]);
                                    }
                                    dw["D1"] = GetPrice(dttmp.Rows[i]["cInvCode"].ToString());
                                    
                                    #region
                                    sSQL = "select * from Inventory where cInvCode='" + dttmp.Rows[i]["cInvCode"].ToString() + "'";
                                    DataTable dts = clsSQLCommond.ExecQuery(sSQL);
                                    if (dts.Rows.Count > 0)
                                    {
                                        dw["cInvClassCode"] = dts.Rows[0]["cInvClassCode"].ToString();
                                    }
                                    #endregion
                                    dt子件.Rows.Add(dw);
                                }

                            }
                            #endregion
                        }
                        if (hasdj == false)
                        {
                            MsgBox("提示", "子件单价不能为空，请设置调价单，本次允许手工填写");
                        }
                    }
                    else
                    {
                        for (int i = dt子件.Rows.Count - 1; i >= 0; i--)
                        {
                            if (dt子件.Rows[i]["iRowNo"].ToString().Trim() == gridView1.GetRowCellValue(iRow, gridCol序号).ToString().Trim())
                            {
                                dt子件.Rows[i]["iQuantity"] = ReturnDecimal(ReturnDecimal(qty)) * ReturnDecimal(ReturnDecimal(dt子件.Rows[i]["iUsedQty"]))* 乘数;
                            }
                        }
                    }
                    
                }

                #endregion

                #region 业务费用
                if (invocde != "" && qty != 0)
                {
                    bool b = false;
                    string iCinvCode = "";
                    for (int i = dt业务费用.Rows.Count - 1; i >= 0; i--)
                    {
                        if (dt业务费用.Rows[i]["SS5"].ToString() != invocde)
                        {
                            b = true;
                        }
                        if (dt业务费用.Rows[i]["SS5"].ToString() != "")
                        {
                            if (iCinvCode != "")
                            {
                                iCinvCode = iCinvCode + ",";
                            }
                            iCinvCode = iCinvCode + dt业务费用.Rows[i]["SS5"].ToString();
                        }
                    }
                    for (int i = dt业务费用.Rows.Count - 1; i >= 0; i--)
                    {
                        if (iCinvCode.IndexOf(dt业务费用.Rows[i]["SS5"].ToString()) >= 0)
                        {
                            dt业务费用.Rows.Remove(dt业务费用.Rows[i]);
                        }
                        else
                        {
                            if (dt业务费用.Rows[i]["SS1"].ToString().Trim() == "" && dt业务费用.Rows[i]["SS2"].ToString().Trim() == "" && dt业务费用.Rows[i]["SS3"].ToString().Trim() == "" &&
                                dt业务费用.Rows[i]["DD1"].ToString().Trim() == "" && dt业务费用.Rows[i]["DD2"].ToString().Trim() == "")
                            {
                                dt业务费用.Rows.Remove(dt业务费用.Rows[i]);
                            }
                        }
                    }
                    if (b == false)
                    {
                        sSQL = @"select null as CID, null as ID, SS1, SS2, SS3, SS4, SS5, SS6, SS7, SS8, SS9, SS10, SS11, SS12, SS13, SS14, SS15, SS16, SS17, SS18, SS19, SS20, DD1, DD2, DD3, DD4, DD5, DD6, DD7, 
                      DD8, DD9, TT1, TT2, TT3, TT4, TT5, TT6, TT7, TT8, TT9,DD1*DD2 as sCount from SO_SOMain a left join SO_SOMainCommissiion b on a.ID=b.ID "
                        + "where a.cCusCode='" + lookUpEdit客户.EditValue.ToString().Trim() + "' and    SS5='" + invocde + "' and  (select top 1 a.ID from SO_SOMain a left join SO_SODetails b on a.ID=b.ID where cCusCode='" + lookUpEdit客户.EditValue.ToString().Trim() + "' and   b.cInvCode='" + invocde + "'  order by a.ID desc )=a.ID order by dDate desc,b.CID desc";
                        DataTable dtc = clsSQLCommond.ExecQuery(sSQL);
                        if (dtc.Rows.Count > 0)
                        {
                            for (int s = 0; s < dtc.Rows.Count; s++)
                            {
                                dtc.Rows[s]["DD2"] = qty;
                                dt业务费用.ImportRow(dtc.Rows[s]);
                            }
                        }
                    }

                }
                #endregion
            }

            #region 换算率
            if (e.Column == gridCol数量小计 || e.Column == gridCol换算率 || e.Column == gridCol样品数量)
            {
                if (ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol换算率)) != 0)
                {
                    decimal 换算率 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol换算率));
                    decimal 数量 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol数量小计));
                    decimal 件数 = ReturnDecimal(数量 * 换算率);
                    gridView1.SetRowCellValue(iRow, gridCol件数小计, 件数);

                    decimal 样品数量 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol样品数量));
                    decimal 样品件数 = ReturnDecimal(样品数量 * 换算率);
                    gridView1.SetRowCellValue(iRow, gridCol样品件数, 样品件数);

                    gridView1.SetRowCellValue(iRow, gridCol数量, 数量 - 样品数量);
                    gridView1.SetRowCellValue(iRow, gridCol件数, 件数 - 样品件数);
                }
                else
                {
                    decimal 数量 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol数量小计));
                    decimal 样品数量 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol样品数量));
                    gridView1.SetRowCellValue(iRow, gridCol数量, 数量 - 样品数量);
                    gridView1.SetRowCellValue(iRow, gridCol件数, DBNull.Value);
                    gridView1.SetRowCellValue(iRow, gridCol样品件数, DBNull.Value);
                    gridView1.SetRowCellValue(iRow, gridCol件数小计, DBNull.Value);
                }
            }
            #endregion


            #region 计算

            if (e.Column == gridCol含税单价 || e.Column == gridCol数量 || e.Column == gridCol税率)
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


                无税单价 = ReturnDecimal(含税单价 / (1 + 税率));
                含税金额 = ReturnDecimal(含税单价 * 数量);
                无税金额 = ReturnDecimal(无税单价 * 数量);
                税额 = 含税金额 - 无税金额;

                gridView1.SetRowCellValue(iRow, gridCol无税单价, 无税单价);
                gridView1.SetRowCellValue(iRow, gridCol无税金额, 无税金额);
                gridView1.SetRowCellValue(iRow, gridCol含税金额, 含税金额);
                gridView1.SetRowCellValue(iRow, gridCol税额, 税额);
            }
            //if (e.Column == gridCol含税金额 && 数量 != 0 && 含税单价 != ReturnDecimal(含税金额 / 数量))
            //{
            //    含税单价 = ReturnDecimal(含税金额 / 数量);
            //}
            #endregion

            if (e.Column == gridCol数量小计 || e.Column == gridCol规格型号)
            {
                decimal 数量 = 0;
                decimal 规格型号 = 0;
                if (gridView1.GetRowCellValue(iRow, gridCol数量小计) != null && gridView1.GetRowCellValue(iRow, gridCol数量小计).ToString().Trim() != "")
                {
                    数量 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol数量小计));
                }
                if (gridView1.GetRowCellValue(iRow, gridCol规格型号) != null && gridView1.GetRowCellValue(iRow, gridCol规格型号).ToString().Trim() != "")
                {
                    if (gridView1.GetRowCellValue(iRow, gridCol规格型号).ToString().Trim().IndexOf('/') >= 0)
                    {
                        规格型号 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol规格型号).ToString().Split('/')[0]);
                    }
                    else
                    {
                        规格型号 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol规格型号));
                    }
                }
                if (规格型号 != 0)
                {
                    gridView1.SetRowCellValue(iRow, gridCol包, 数量 / 规格型号);
                }
                else
                {
                    gridView1.SetRowCellValue(iRow, gridCol包, null);
                }
            }

            if (e.Column == gridCol数量小计)
            {
                decimal 数量小计 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol数量小计));
                decimal 引用量 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol引用量));
                if (数量小计 < 引用量)
                {
                    MessageBox.Show("引用量超出");

                    if (数量小计 != ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol历史数量)) + ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol历史样品数量)))
                    {
                        gridView1.SetRowCellValue(iRow, gridCol数量小计, ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol历史数量)) + ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol历史样品数量)));
                    }
                }
                gridView1.SetRowCellValue(iRow, gridCol历史, 数量小计);
            }

            if (e.Column == gridCol数量小计 || e.Column == gridCol含税金额)
            {
                Get利润();
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
            if (e.Column == gridCol物料编码 && e.RowHandle == gridView1.RowCount - 1 && gridView1.GetRowCellDisplayText(e.RowHandle, gridCol物料编码).ToString().Trim() != "")
            {
                gridView1.AddNewRow();
                gridView1.FocusedRowHandle = iRow;
            }
            #endregion
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
            系统服务.Frm参照 frm = new 系统服务.Frm参照(9);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit客户.EditValue = frm.sID;
                frm.Enabled = true;
                sSQL = "select * from SO_SOMain where cCusCode='" + lookUpEdit客户.EditValue.ToString().Trim() + "' and 1=1 order by dDate desc,ID desc";
                if (textEditID.EditValue.ToString().Trim() != "")
                {
                    sSQL =sSQL.Replace("1=1","  ID<>'" + textEditID.EditValue.ToString().Trim() + "' ");
                }
                DataTable dts = clsSQLCommond.ExecQuery(sSQL);
                if (dts.Rows.Count > 0)
                {
                    lookUpEdit新老客户.EditValue = 2;

                    textEdit运行成本.EditValue = dts.Rows[0]["Cost"].ToString();
                    lookUpEdit付款条件.EditValue = ReturnInt(dts.Rows[0]["cPayCode"].ToString());
                    lookUpEdit发运方式.EditValue = dts.Rows[0]["S1"].ToString();
                    lookUpEdit合作方式.EditValue = dts.Rows[0]["cCCode"].ToString();
                }
                else
                {
                    lookUpEdit新老客户.EditValue = 1;
                }
            }
        }

        private void ItemButtonEditcInvCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int iRow = 0;
            if (gridView1.FocusedRowHandle > 0)
                iRow = gridView1.FocusedRowHandle;

            系统服务.Frm参照 frm = new 系统服务.Frm参照(1);
            if (DialogResult.OK == frm.ShowDialog())
            {
                gridView1.SetRowCellValue(iRow, gridCol物料编码, frm.sID);


                frm.Enabled = true;
            }
        }

        private void ItemButtonEditcInvCode_EditValueChanged(object sender, EventArgs e)
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
                if (lookUpEdit客户.Text.Trim() != "")
                {
                    DataTable dt = 系统服务.LookUp.CustomercCusPPerson(buttonEdit客户.Text.Trim());
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        buttonEdit业务员.EditValue = dt.Rows[0]["cCusPPerson"];
                        lookUpEdit客户分类.EditValue = dt.Rows[0]["cCCCode"];
                        lookUpEdit区域.EditValue = dt.Rows[0]["cDCCode"];
                        lookUpEdit行业.EditValue = dt.Rows[0]["cTrade"];
                        lookUpEdit合作方式.EditValue = dt.Rows[0]["cCCode"];
                        lookUpEdit销售类型.EditValue = dt.Rows[0]["S4"];

                        textEdit客户联系人.EditValue = dt.Rows[0]["cCusPerson"];
                        textEdit客户联系电话.EditValue = dt.Rows[0]["cCusPhone"];
                        textEdit客户地址.EditValue = dt.Rows[0]["cCusAddress"];
                        textEdit利润分成.EditValue = dt.Rows[0]["D1"];
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
                sSQL = "select  isnull(dCreatesysPerson,'') as 制单人,isnull(dVerifysysPerson,'') as 审核人,isnull(dClosesysPerson,'') as 关闭人 from " + tablename + " where cSOCode = '" + sCode + "'";
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

                    sSQL = "select count(1) from SO_SOMain a inner join SO_SODetails b on a.id = b.id where a.cSOCode = '" + sCode + "' and isnull(cClosesysPerson,'') <> ''";
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
                sSQL = "select count(1) from dbo.SO_SOMain a inner join dbo.SO_SODetails b on a.ID = b.ID inner join dbo.SO_SOOutDetails c on c.SoAutoID = b.AutoID " +
                     "where a.cSOCode = '" + sCode + "'";
                int iReturn1 = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));

                sSQL = "select count(1) from dbo.SO_SOMain a inner join dbo.SO_SODetails b on a.ID = b.ID inner join dbo.SaleBillVouchs c on c.SoAutoID = b.AutoID " +
                       "where a.cSOCode = '" + sCode + "'";
                int iReturn2 = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));

                if (iReturn1 > iReturn2)
                    iReturn = iReturn1;
                else
                    iReturn = iReturn2;
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
                sSQL = "select isnull(sum(c.iQuantity),0) as iQty from dbo.SO_SOMain a inner join dbo.SO_SODetails b on a.ID = b.ID inner join dbo.SO_SOOutDetails c on c.SoAutoID = b.AutoID " +
                       "where b.AutoID = '" + AutoID + "'";
                decimal iReturn1 = ReturnDecimal(clsSQLCommond.ExecGetScalar(sSQL));
                if (iReturn1 > iReturn && iReturn1 > 0)
                    iReturn = iReturn1;

                sSQL = "select isnull(sum(c.iQuantity),0) as iQty from dbo.SO_SOMain a inner join dbo.SO_SODetails b on a.ID = b.ID inner join dbo.SaleBillVouchs c on c.SoAutoID = b.AutoID " +
                       "where b.AutoID = '" + AutoID + "'";
                decimal iReturn2 = ReturnDecimal(clsSQLCommond.ExecGetScalar(sSQL));
                if (iReturn2 > iReturn && iReturn2 > 0)
                    iReturn = iReturn2;

                sSQL = "select isnull(sum(c.iQuantity),0) as iQty from dbo.SO_SOMain a inner join dbo.SO_SODetails b on a.ID = b.ID inner join dbo.SO_CloseBillDetails c on c.SoAutoID = b.AutoID " +
                       "where b.AutoID = '" + AutoID + "'";
                decimal iReturn3 = ReturnDecimal(clsSQLCommond.ExecGetScalar(sSQL));

                if (iReturn3 > iReturn && iReturn3 > 0)
                    iReturn = iReturn3;
            }
            catch (Exception ee)
            { }
            return iReturn;
        }

        private void ItemButtonEditcInvCode_EditValueChanged_1(object sender, EventArgs e)
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
            decimal qty = 0;
            if (gridView1.GetRowCellValue(iRow, gridCol数量).ToString().Trim() != "")
            {
                qty = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol数量).ToString().Trim());
            }
            if (invocde != "")
            {
                for (int i = dt子件.Rows.Count - 1; i >= 0; i--)
                {
                    if (dt子件.Rows[i]["iRowNo"].ToString().Trim() == gridView1.GetRowCellValue(iRow, gridCol序号).ToString().Trim())
                    {
                        dt子件.Rows.Remove(dt子件.Rows[i]);
                    }
                }

                sSQL = "select * from BOM_Main where InvCode='" + invocde + "' and  isnull(dVerifysysTime,'') <> '' order by dVerifysysTime desc,ID desc";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    sSQL = "select * from BOM_Details where ID='" + dt.Rows[0]["ID"].ToString() + "'";
                    DataTable dttmp = clsSQLCommond.ExecQuery(sSQL);
                    decimal sum = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol数量小计));

                    if (gridView1.GetRowCellValue(iRow, gridCol历史) != null && gridView1.GetRowCellValue(iRow, gridCol历史).ToString().Trim() != "")
                    {
                        gridView1.SetRowCellValue(iRow, gridCol历史, "1");
                    }
                    for (int i = 0; i < dttmp.Rows.Count; i++)
                    {
                        DataRow dw = dt子件.NewRow();
                        dw["iRowNo"] = gridView1.GetRowCellValue(iRow, gridCol序号);
                        dw["行标记"] = gridView1.GetRowCellValue(iRow, gridCol行标记);
                        dw["cInvCode"] = dttmp.Rows[i]["cInvCode"].ToString();
                        dw["iQuantity"] = ReturnDecimal(ReturnDecimal(dttmp.Rows[i]["iQuantity"])) * qty;
                        if (ReturnDecimal(dttmp.Rows[i]["iNum"]) != 0)
                        {
                            dw["iNum"] = ReturnDecimal(ReturnDecimal(dttmp.Rows[i]["iNum"])) * qty;
                            dw["iChangRate"] = ReturnDecimal(dttmp.Rows[i]["iChangRate"]);
                        }
                        dt子件.Rows.Add(dw);
                    }
                }
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

        private void lookUpEdit销售类型_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEdit销售类型.EditValue.ToString().Trim() == "02")
            {
                gridCol税额.Visible = false;
                gridCol税率.Visible = false;
                gridCol无税单价.Visible = false;
                gridCol无税金额.Visible = false;
                gridCol含税单价.Caption = "无税单价";
                gridCol含税金额.Caption = "无税金额";
                if (sState == "add" || sState == "edit" || sState == "alter")
                {
                    textEdit业务费用倍数.EditValue = "1";
                }
            }
            else
            {
                gridCol税额.Visible = true;
                gridCol税率.Visible = true;
                gridCol无税单价.Visible = true;
                gridCol无税金额.Visible = true;
                gridCol含税单价.Caption = "含税单价";
                gridCol含税金额.Caption = "含税金额";
                textEdit业务费用倍数.Enabled = true;
                if (sState == "add" || sState == "edit" || sState == "alter")
                {
                    textEdit业务费用倍数.EditValue = "1.5";
                }
            }
            Get利润();
        }

        private void ItemButtonEdit包装方式_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int iRow = 0;
            if (gridView1.FocusedRowHandle > 0)
                iRow = gridView1.FocusedRowHandle;

            系统服务.Frm参照 frm = new 系统服务.Frm参照(13);
            if (DialogResult.OK == frm.ShowDialog())
            {
                gridView1.SetRowCellValue(iRow, gridCol包装方式, frm.sID);
                frm.Enabled = true;
            }
        }

        private void Get利润()
        {
            if (sState == "add" || sState == "edit" || sState == "alter")
            {
                decimal 订单金额 = ReturnDecimal(dtBingGrid.Compute("sum(iMoney)", ""));
                decimal 订单数量 = ReturnDecimal(dtBingGrid.Compute("sum(iQuantity)", ""));
                decimal 子件金额 = 0;
                for (int i = 0; i < dt子件.Rows.Count; i++)
                {
                    if (dt子件.Rows[i]["cInvClassCode"].ToString() != "03")
                    {
                        decimal qty = ReturnDecimal(dt子件.Rows[i]["D1"]);
                        decimal iQuantity = 订单数量*ReturnDecimal(dt子件.Rows[i]["iUsedQty"])/10;
                        子件金额 = 子件金额 + qty * iQuantity;
                    }
                }
                decimal 业务费用 = ReturnDecimal(textEdit业务费用.EditValue);
                decimal 运行成本=ReturnDecimal(textEdit运行成本.EditValue)*订单数量;
                decimal 业务费用倍数 = ReturnDecimal(textEdit业务费用倍数.EditValue);
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
                    textEdit利润.EditValue = (订单金额 - 子件金额 - 业务费用 - 运行成本)*0.7M;
                }
                else
                {
                    textEdit利润.EditValue = 订单金额 - 子件金额 - 业务费用 - 运行成本;
                }

            }
        }

        private void textEdit业务费用_EditValueChanged(object sender, EventArgs e)
        {
            Get利润();
        }

        private void textEdit运行成本_EditValueChanged(object sender, EventArgs e)
        {
            Get利润();
        }

        private void textEdit收款利润_EditValueChanged(object sender, EventArgs e)
        {
            Get个人利润();
        }

        private void textEdit利润分成_EditValueChanged(object sender, EventArgs e)
        {
            Get个人利润();
        }

        private void Get个人利润()
        {
            decimal 利润分成 = ReturnDecimal(textEdit利润分成.EditValue);
            decimal 收款利润 = ReturnDecimal(textEdit收款利润.EditValue);
            textEdit个人利润.Text = (利润分成 * 收款利润).ToString();
        }

    }
}
