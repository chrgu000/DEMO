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
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Drawing;
namespace 销售
{
    public partial class Frm销售发货单 : 系统服务.FrmBaseInfo
    {
        string tablename = "DispatchList";
        string tableid = "ID";
        string tablecode = "cDLCode";
        string tablenames = "DispatchLists";
        string tablenamel = "DispatchListSublist";
        string cDLCode = "";

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
        public string 删除 = "";

        public DataTable dt子件;


        string isChange = "";


        public Frm销售发货单(long siID, string title)
        {
            iID = siID;
            InitializeComponent();
            this.Text = title;
        }

        public Frm销售发货单()
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
            throw new NotImplementedException();
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
                    //aList.Add("update  " + tablename + " set PrintCount=" + textEdit打印次数.Text.Trim() + "+1,LastPrintDate=getdate() where ID=" + textEditID.Text.Trim());
                    //if (aList.Count > 0)
                    //{
                    //    int iCou = clsSQLCommond.ExecSqlTran(aList);
                    //}
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
        /// 导入
        /// </summary>
        private void btnImport()
        {
            //try
            //{
            //    string sErr = "";
            //    if (iID < 0)
            //    {
            //        sErr = sErr + "没有单据，无法查询历史记录";
            //    }
            //    //throw new Exception("没有单据，无法查询历史记录");
            //    sSQL = "select * from " + tablename + "History a where ID='" + iID + "'";
            //    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            //    if (dt.Rows.Count == 0)
            //    {
            //        sErr = sErr + "无变更历史记录"; 
            //    }

            //    if (sErr == "")
            //    {
            //        Frm销售发货单历史 frm = new Frm销售发货单历史(iID);
            //        frm.Tag = frm.Name;
            //        frm.MdiParent = this.MdiParent;

            //        frm.Show();
            //        if (DialogResult.OK == frm.ShowDialog())
            //        {
            //            frm.Enabled = true;
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show(sErr);
            //    }

            //}
            //catch (Exception ee)
            //{ }
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
            Frm销售发货单_Add frm = new Frm销售发货单_Add(单据号1, 单据号2, 单据日期1, 单据日期2, 制单日期1, 制单日期2, 业务员,
               部门, 客户1, 客户2, 审核日期1, 审核日期2, 制单人1, 制单人2, 审核人1, 审核人2, 物料1, 物料2);
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
                GetSel();
            }

        }

        private void GetSel()
        {
            string sSQL = "select * from " + tablename + " a left join " + tablenames + "  b on a.ID=b.ID where 1=1 ";
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
                sSQL = "select min(ID) as ID from " + tablename + " a where 1=1 " ;
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
                    sSQL = "select ID from " + tablename + " a where ID<" + textEditID.EditValue.ToString().Trim();

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
                    sSQL = "select ID from " + tablename + " a where ID>" + textEditID.EditValue.ToString().Trim() ;

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
                sSQL = "select isnull(max(ID),-1) as ID from " + tablename + " a  where 1=1 " ;

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
        /// 锁定 生产委外入库单
        /// </summary>
        private void btnLock()
        {
            try
            {
                gridView1.FocusedColumn = gridCol行号;
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
            if (iRe == 1 && (sState == "alter" || sState==""))
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

            sSQL = "select * from RdRecord where MoID='" + textEditID.EditValue.ToString().Trim() + "' and cRSCode='03'";
            DataTable dtc = clsSQLCommond.ExecQuery(sSQL);
            if (dtc.Rows.Count > 0)
            {
                throw new Exception("已生成委外入库单");
            }

            sSQL = @"select * from RdRecord a left join RdRecords b on a.ID=b.ID left join MO_MODetails c on b.MOAutoID=c.AutoID 
            where c.ID='" + textEditID.EditValue.ToString().Trim() + "' and cRSCode='13'";
            DataTable dtcc = clsSQLCommond.ExecQuery(sSQL);
            if (dtcc.Rows.Count > 0)
            {
                throw new Exception("已有部分数据生成委外入库单");
            }

            string sErr = "";
            aList = new System.Collections.ArrayList();

            sSQL = "select * from RdRecord where 1=-1";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            sSQL = "select * from RdRecords where 1=-1";
            DataTable dts = clsSQLCommond.ExecQuery(sSQL);

            sSQL = "select isnull(max(ID)+1,1) as ID from RdRecord";
            long siID = long.Parse(clsSQLCommond.ExecQuery(sSQL).Rows[0][0].ToString());
            sSQL = "select isnull(max(AutoID)+1,1) as AutoID from RdRecords";
            long sAutoID = long.Parse(clsSQLCommond.ExecQuery(sSQL).Rows[0][0].ToString());

            #region 表头
            DataRow drh = dt.NewRow();
            drh["ID"] = siID;
            string cCode = clsPublic.GetNewSerialNumberContinuous("RdRecord", "cRdCode");
            drh["cRDCode"] = cCode;
            drh["dDate"] = dateEdit单据日期.EditValue.ToString().Trim();
            drh["cDepCode"] = lookUpEdit部门.EditValue.ToString().Trim();
            drh["MOID"] = textEditID.EditValue.ToString().Trim();
            drh["cMemo"] = "";
            drh["dCreatesysTime"] = GetSystemTime();
            drh["dCreatesysPerson"] = 系统服务.ClsBaseDataInfo.sUid;
            drh["dVerifysysTime"] = GetSystemTime();
            drh["dVerifysysPerson"] = 系统服务.ClsBaseDataInfo.sUid;
            dt.Rows.Add(drh);
            sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, "RdRecord", dt, 0);
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
                dr["cRDCode"] = cCode;
                dr["iRowNo"] = i + 1;
                dr["MOAutoID"] = dtns.Rows[i]["AutoID"];
                dr["cInvCode"] = dtns.Rows[i]["cInvCode"];
                dr["iQuantity"] = dtns.Rows[i]["iQuantity"];
                
                if (dtns.Rows[i]["iNum"].ToString() != "")
                {
                    dr["iNum"] = dtns.Rows[i]["iNum"];
                }
                if (dtns.Rows[i]["iChangRate"].ToString() != "")
                {
                    dr["iChangRate"] = dtns.Rows[i]["iChangRate"];
                }
                dr["M1"] = dtns.Rows[i]["M1"].ToString();
                dr["M2"] = dtns.Rows[i]["M2"].ToString();
                dr["M3"] = dtns.Rows[i]["M3"].ToString();
                dr["M4"] = dtns.Rows[i]["M4"].ToString();
                dr["M5"] = dtns.Rows[i]["M5"].ToString();
                dr["M6"] = dtns.Rows[i]["M6"].ToString();
                dr["M7"] = dtns.Rows[i]["M7"].ToString();
                dr["M8"] = dtns.Rows[i]["M8"].ToString();
                dr["M9"] = dtns.Rows[i]["M9"].ToString();
                dr["M10"] = dtns.Rows[i]["M10"].ToString();
                dts.Rows.Add(dr);
                sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, "RdRecords", dts, dts.Rows.Count - 1);

                aList.Add(sSQL);

                #endregion
                sAutoID = sAutoID + 1;
            }
            #endregion

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("生成委外入库单成功！\n合计执行语句:" + iCou + "条");

            }
        }
        /// <summary>
        /// 解锁  生成材料出库单
        /// </summary>
        private void btnUnLock()
        {
            try
            {
                gridView1.FocusedColumn = gridCol行号;
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
            if (iRe == 1 && (sState == "alter" || sState == ""))
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

            sSQL = "select * from RdRecord where MoID='" + textEditID.EditValue.ToString().Trim() + "' and cRSCode='13'";
            DataTable dtc = clsSQLCommond.ExecQuery(sSQL);
            if (dtc.Rows.Count > 0)
            {
                throw new Exception("已生成材料出库单");
            }

            sSQL = @"select * from RdRecord a left join RdRecords b on a.ID=b.ID left join MO_MOSublist c on b.MOsID=c.sID 
            where c.ID='" + textEditID.EditValue.ToString().Trim() + "' and cRSCode='13'";
            DataTable dtcc = clsSQLCommond.ExecQuery(sSQL);
            if (dtcc.Rows.Count > 0)
            {
                throw new Exception("已有部分数据生成材料出库单");
            }

            string sErr = "";
            aList = new System.Collections.ArrayList();

            sSQL = "select * from RdRecord where 1=-1";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            sSQL = "select * from RdRecords where 1=-1";
            DataTable dts = clsSQLCommond.ExecQuery(sSQL);

            sSQL = "select isnull(max(ID)+1,1) as ID from RdRecord";
            long siID = long.Parse(clsSQLCommond.ExecQuery(sSQL).Rows[0][0].ToString());
            sSQL = "select isnull(max(AutoID)+1,1) as AutoID from RdRecords";
            long sAutoID = long.Parse(clsSQLCommond.ExecQuery(sSQL).Rows[0][0].ToString());

            #region 表头
            DataRow drh = dt.NewRow();
            drh["ID"] = siID;
            string cCode = clsPublic.GetNewSerialNumberContinuous("RdRecord", "cRdCode");
            drh["cRDCode"] = cCode;
            drh["dDate"] = dateEdit单据日期.EditValue.ToString().Trim();
            drh["MOID"] = textEditID.EditValue.ToString().Trim();
            drh["cRSCode"] = "13";
            drh["Flag"] = "1";
            drh["cMemo"] = "";
            drh["dCreatesysTime"] = GetSystemTime();
            drh["dCreatesysPerson"] = 系统服务.ClsBaseDataInfo.sUid;
            drh["dVerifysysTime"] = GetSystemTime();
            drh["dVerifysysPerson"] = 系统服务.ClsBaseDataInfo.sUid;
            dt.Rows.Add(drh);
            sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, "RdRecord", dt, 0);
            aList.Add(sSQL);
            #endregion

            #region 子表
            sSQL = "select * from " + tablenamel + " where ID='" + textEditID.EditValue + "'";
            DataTable dtns = clsSQLCommond.ExecQuery(sSQL);
            for (int i = 0; i < dtns.Rows.Count; i++)
            {
                #region 生成table
                DataRow dr = dts.NewRow();
                dr["ID"] = siID;
                dr["AutoID"] = sAutoID;
                dr["cRDCode"] = cCode;
                dr["iRowNo"] = i+1;
                dr["MOsID"] = dtns.Rows[i]["sID"];
                dr["MOAutoID"] = dtns.Rows[i]["AutoID"];
                dr["RdAutoID"] = dtns.Rows[i]["RdAutoID"];
                dr["cInvCode"] = dtns.Rows[i]["cInvCode"];
                dr["iQuantity"] = dtns.Rows[i]["iQuantity"];
                
                if (dtns.Rows[i]["iNum"].ToString() != "")
                {
                    dr["iNum"] = dtns.Rows[i]["iNum"];
                }
                if (dtns.Rows[i]["iChangRate"].ToString() != "")
                {
                    dr["iChangRate"] = dtns.Rows[i]["iChangRate"];
                }
                dr["M1"] = dtns.Rows[i]["M1"].ToString();
                dr["M2"] = dtns.Rows[i]["M2"].ToString();
                dr["M3"] = dtns.Rows[i]["M3"].ToString();
                dr["M4"] = dtns.Rows[i]["M4"].ToString();
                dr["M5"] = dtns.Rows[i]["M5"].ToString();
                dr["M6"] = dtns.Rows[i]["M6"].ToString();
                dr["M7"] = dtns.Rows[i]["M7"].ToString();
                dr["M8"] = dtns.Rows[i]["M8"].ToString();
                dr["M9"] = dtns.Rows[i]["M9"].ToString();
                dr["M10"] = dtns.Rows[i]["M10"].ToString();
                dts.Rows.Add(dr);
                sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, "RdRecords", dts, dts.Rows.Count - 1);

                aList.Add(sSQL);

                #endregion
                sAutoID = sAutoID + 1;
            }
            #endregion

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("生成材料出库成功！\n合计执行语句:" + iCou + "条");

            }

        }
        /// <summary>
        /// 增行 引用
        /// </summary>
        private void btnAddRow()
        {
            try
            {
                int iRowView = gridView1.FocusedRowHandle;
                BindGrid2(iRowView);
            }
            catch { }

            string 行标记 = "";
            string 行号 = "";
            string 客户 = "";
            string 物料名称 = "";
            string 规格型号 = "";
            string AutoID = "";
            decimal 数量 = 0;
            int iRow = 0;
            if (gridView1.FocusedRowHandle > 0)
                iRow = gridView1.FocusedRowHandle;

            行标记 = gridView1.GetRowCellDisplayText(iRow, gridCol行标记).ToString().Trim();
            行号 = gridView1.GetRowCellDisplayText(iRow, gridCol行号).ToString().Trim();
            客户 = gridView1.GetRowCellDisplayText(iRow, gridCol客户).ToString().Trim();
            AutoID = gridView1.GetRowCellDisplayText(iRow, gridColAutoID).ToString().Trim();
            if ((sState == "edit" || sState == "alter") && gridView1.GetRowCellDisplayText(iRow, gridColiSave) == "edit")
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
                dttmp = clsPublic.DataRowToDataTable(dw);
            }
            else
            {
                dttmp = clsSQLCommond.ExecQuery("select *,cast(null as decimal(16,6)) as 历史,iRowNo as 行标记,'' as cInvClassCode,cast(null as decimal(16,6)) as 可用数量 from " + tablenamel + " where 1=-1");
            }

            bool b = false;
            if (sState == "add" || sState == "edit" || sState == "alter")
            {
                b = true;
            }
            Frm销售订单_New frm = new Frm销售订单_New(客户, dt子件);
            if (DialogResult.OK == frm.ShowDialog())
            {

                frm.Enabled = true;
                DataTable dtnew = frm.dt;
                for (int s = 0; s < dtnew.Rows.Count; s++)
                {
                    gridView2.AddNewRow();
                    
                    int i = gridView2.RowCount - 1;
                    gridView2.FocusedRowHandle = i;
                    gridView2.SetRowCellValue(i, gridSOAutoID, dtnew.Rows[s]["AutoID"].ToString());
                    gridView2.SetRowCellValue(i, grid存货编码, dtnew.Rows[s]["cInvCode"].ToString());
                    gridView2.SetRowCellValue(i, gridiQuantity, dtnew.Rows[s]["iQuantity"].ToString());
                    gridView2.SetRowCellValue(i, gridsBoxQty, dtnew.Rows[s]["sBoxQty"].ToString());
                    gridView2.SetRowCellValue(i, grid行标记, 行标记);
                    gridView2.SetRowCellValue(i, grid行号, 行号);
                    gridView2.SetRowCellValue(i, grid每盒数量, ReturnDecimal(dtnew.Rows[s]["iQuantity"].ToString()) / ReturnDecimal(dtnew.Rows[s]["sBoxQty"].ToString()));

                    if (dtnew.Rows[s]["M1"].ToString() != "")
                    {
                        gridView2.SetRowCellValue(i, gridM1, dtnew.Rows[s]["M1"].ToString());
                    }
                    if (dtnew.Rows[s]["M2"].ToString() != "")
                    {
                        gridView2.SetRowCellValue(i, gridM2, dtnew.Rows[s]["M2"].ToString());
                    }

                    DataRow dwzj = dt子件.NewRow();
                    dwzj["SOAutoID"] = dtnew.Rows[s]["AutoID"].ToString();
                    dwzj["cInvCode"] = dtnew.Rows[s]["cInvCode"].ToString();
                    dwzj["iQuantity"] = dtnew.Rows[s]["iQuantity"].ToString();
                    dwzj["sBoxQty"] = dtnew.Rows[s]["sBoxQty"].ToString();
                    dwzj["M1"] = dtnew.Rows[s]["M1"].ToString();
                    dwzj["M2"] = dtnew.Rows[s]["M2"].ToString();
                    dwzj["行标记"] = 行标记;
                    dwzj["iRowNO"] = 行号;
                    dt子件.Rows.Add(dwzj);
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
                                textEditDel.EditValue = gridView1.GetRowCellDisplayText(i, gridColAutoID).ToString().Trim();
                            }
                            gridView1.DeleteRow(i);
                        }
                        else
                        {
                            sErr = sErr + "行" + (i + 1) + "已引用\n";
                        }
                    }
                    else
                    {
                        gridView1.DeleteRow(i);
                    }
                }
            }
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellDisplayText(i, gridCol行号).ToString().Trim() != "")
                {
                    gridView1.SetRowCellValue(i, gridCol行号, i + 1);
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

            sSQL = "select a.*, 'edit' as iSave,cast(null as decimal(16,6)) as 引用量,cast(null as decimal(16,6)) as 历史数量,cast(null as decimal(16,6)) as 历史,iRowNo as 行标记 from " + tablenames + " a  where 1=-1";
            dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dtBingGrid;
            try
            {
                gridView1.FocusedColumn = gridCol行号;
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
                gridView1.Focus();
            }
            catch { }

            gridView1.AddNewRow();
            gridView1.FocusedRowHandle = 0;

            dt子件 = clsSQLCommond.ExecQuery("select *,cast(null as decimal(16,6)) as 历史,iRowNo as 行标记,'' as cInvClassCode,null as 可用数量,cast(null as decimal(16,6)) as 每盒数量 from " + tablenamel + " where 1=-1");

            gridView1.OptionsBehavior.Editable = true;
     
            sState = "add";
            删除 = "";
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
                gridView1.FocusedColumn = gridCol行号;
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

            if (dateEdit单据日期.EditValue == null || dateEdit单据日期.EditValue.ToString().Trim() == "")
            {
                throw new Exception("单据日期不能为空");
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
                drh[tablecode] = clsPublic.GetNewSerialNumberContinuous(tablename, tablecode);
                textEdit单据号.EditValue = drh[tablecode].ToString();
            }
            else
            {
                drh["ID"] = textEditID.EditValue.ToString().Trim();
                iID = Convert.ToInt64(textEditID.EditValue);
                drh[tablecode] = textEdit单据号.EditValue.ToString().Trim();
            }
            drh["dDate"] = dateEdit单据日期.EditValue.ToString().Trim();
            if (lookUpEdit部门.EditValue != null)
            {
                drh["cDepCode"] = lookUpEdit部门.EditValue.ToString().Trim();
            }

            drh["cPersonCode"] = lookUpEdit业务员.EditValue.ToString().Trim();

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
                drh["dVerifysysTime"] = dateEdit审核日期.Text.Trim();
                drh["dVerifysysPerson"] = textEdit审核人.Text.Trim();

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
                clsPublic.GetChange(tablename, tablenames, tablenamel, textEditID.EditValue.ToString().Trim(), clsGetSQL, aList);
            }
            #endregion

            #region 删行
            if (textEditDel.EditValue != null && textEditDel.EditValue.ToString().Trim() != "")
            {
                clsPublic.GetChangeDelRow(tablenames, tablenamel, textEditDel.EditValue.ToString().Trim(), aList);
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

            
           
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                    #region 判断
                    if (gridView1.GetRowCellDisplayText(i, gridCol客户).ToString().Trim() == "")
                    {
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
                    string iRowNo = gridView1.GetRowCellValue(i, gridCol行号).ToString().Trim();
                    dr["ID"] = iID;
                    dr[tablecode] = textEdit单据号.EditValue.ToString().Trim();
                    dr["iRowNo"] = iRowNo;
                    dr["cCusCode"] = gridView1.GetRowCellValue(i, gridCol客户).ToString().Trim();
                    if (gridView1.GetRowCellValue(i, gridCol备注) != null)
                    {
                        dr["cMemo"] = gridView1.GetRowCellValue(i, gridCol备注).ToString().Trim();
                    }
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
                            dwl[tablecode] = textEdit单据号.EditValue.ToString().Trim();
                            dwl["iRowNo"] = iRowNo;
                            dwl["cInvCode"] = dw[l]["cInvCode"].ToString();
                            dwl["iQuantity"] = dw[l]["iQuantity"].ToString();
                            dwl["SOAutoID"] = dw[l]["SOAutoID"].ToString();
                            dwl["sBoxQty"] = dw[l]["sBoxQty"].ToString();
                            dwl["cMemo"] = dw[l]["cMemo"].ToString();
                            dwl["M1"] = dw[l]["M1"].ToString();
                            dwl["M2"] = dw[l]["M2"].ToString();
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
            #endregion

            #region 表体不能为空
            bool b列表 = false;
            int bCount = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridCol客户).ToString().Trim() != "")
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
                if (gridView1.GetRowCellValue(i, gridCol客户).ToString().Trim() != "")
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

            sSQL = "update " + tablename + " set dVerifysysTime='" + GetSystemTime() + "',dVerifysysPerson='" + 系统服务.ClsBaseDataInfo.sUid + "' where ID=" + textEditID.EditValue.ToString().Trim() + "";
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
        /// 打开 生成
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
            //if (iRe == 2)
            //{
            //    throw new Exception("单据已审核");
            //}
            if (iRe == 3)
            {
                throw new Exception("单据已关闭");
            }
            bool bHasGrid = false;
            string sErr = "";

            sSQL = "select * from RdRecord13 where 1=-1";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            sSQL = "select * from RdRecords13 where 1=-1";
            DataTable dts = clsSQLCommond.ExecQuery(sSQL);
            sSQL = @"
select dis.iID,a.cInvCode,sops.M1,sops.M2,a.AutoID as DLsID,a.SOAutoID,sops.BoxNo,dis.sBoxNo,sos.iUnitPrice,sos.iNatUnitPrice,sos.iTaxRate,sops.sBoxQty, sops.iQuantity
,cInWhCode ,cInPosCode,OutSoAutoID,InRdAutoID,sops.sID as cSOPSID,so.cCusCode,so.cPersonCode,so.cDepCode,so.dDate 
from DispatchListSublist a left join DispatchListReturn dis on a.sID=dis.DLsID 
left join SO_SOPackingSublist sops on dis.sBoxNo=sops.sBoxNo
left join SO_SODetails sos on a.SOAutoID=sos.AutoID left join SO_SOMain so on so.ID=sos.ID
where isnull(dis.DLsID,'') <>''and (isnull(sInBoxQty,0) = 1) AND (isnull(sops.sOutBoxQty,0) = 0) --and OutSoAutoID is not null 
and a.ID='" + textEditID.EditValue.ToString().Trim() + "'";
            DataTable dtDis = clsSQLCommond.ExecQuery(sSQL);
            if (dtDis.Rows.Count == 0)
            {
                throw new Exception("未找到需要发货的数据");
            }
            sSQL = "select * from DispatchListSublist a left join RdRecords13 rd on a.sID=rd.DLsID where isnull(rd.DLsID,'') <>'' and a.ID='" + textEditID.EditValue.ToString().Trim() + "'";
            DataTable dtrd = clsSQLCommond.ExecQuery(sSQL);
            if (dtrd.Rows.Count > 0)
            {
                throw new Exception("已生成销售出库单，不可再次生成");
            }
            aList = new System.Collections.ArrayList();
            DataTable dtg = clsPublic.Group(dtDis, new string[1]{ "cCusCode" });
            for (int g = 0; g < dtg.Rows.Count; g++)
            {
                string cCusCode = dtg.Rows[g]["cCusCode"].ToString();
                DataTable dtlist = clsPublic.SelectTable(dtDis, new string[,] { { "cCusCode", cCusCode } }, "iID");
                DataRow drh = dt.NewRow();
                iID = clsPublic.GetMaxID("RD");
                drh["ID"] = iID;
                drh["cRDCode"] = clsPublic.GetMaxCode_SO("cRdCode");
                drh["dDate"] = DateTime.Now.ToString("yyyy-MM-dd");
                if (buttonEdit业务员.EditValue != null)
                {
                    drh["cPersonCode"] = buttonEdit业务员.EditValue.ToString().Trim();
                }
                drh["cWhCode"] = "02";
                if (buttonEdit部门.EditValue != null)
                {
                    drh["cDepCode"] = buttonEdit部门.EditValue.ToString().Trim();
                }
                drh["cRSCode"] = "1302";
                drh["cCusCode"] = cCusCode;
                drh["Flag"] = "1";

                drh["cMemo"] = textEdit备注.EditValue.ToString().Trim();
                drh["UpdateDate"] = DateTime.Now.ToString();

                drh["dCreatesysTime"] = GetSystemTime();
                drh["dCreatesysPerson"] = 系统服务.ClsBaseDataInfo.sUid;

                dt.Rows.Add(drh);
                sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, "RdRecord13", dt, 0);
                aList.Add(sSQL);
                #region 子表

                for (int i = 0; i < dtlist.Rows.Count; i++)
                {
                    string cInvCode = dtlist.Rows[i]["cInvCode"].ToString().Trim();
                    string M1 = dtlist.Rows[i]["M1"].ToString().Trim();
                    string M2 = dtlist.Rows[i]["M2"].ToString().Trim();
                    string DLsID = dtlist.Rows[i]["DLsID"].ToString().Trim();
                    string SOAutoID = dtlist.Rows[i]["SOAutoID"].ToString().Trim();
                    string cSOPSID = dtlist.Rows[i]["cSOPSID"].ToString().Trim();
                    string sBoxNo = dtlist.Rows[i]["sBoxNo"].ToString().Trim();
                    string BoxNo = dtlist.Rows[i]["BoxNo"].ToString().Trim();
                    string iUnitPrice = dtlist.Rows[i]["iUnitPrice"].ToString().Trim();
                    string iNatUnitPrice = dtlist.Rows[i]["iNatUnitPrice"].ToString().Trim();
                    string iTaxRate = dtlist.Rows[i]["iTaxRate"].ToString().Trim();
                    string sBoxQty = dtlist.Rows[i]["sBoxQty"].ToString().Trim();
                    string iQuantity = dtlist.Rows[i]["iQuantity"].ToString().Trim();
                    string cWhCode = dtlist.Rows[i]["cInWhCode"].ToString().Trim();
                    string cPosCode = dtlist.Rows[i]["cInPosCode"].ToString().Trim();
                    string OutSoAutoID = dtlist.Rows[i]["OutSoAutoID"].ToString().Trim();
                    string RdAutoID = dtlist.Rows[i]["InRdAutoID"].ToString().Trim();
                    string cPersonCode = dtlist.Rows[i]["cPersonCode"].ToString().Trim();
                    string cDepCode = dtlist.Rows[i]["cDepCode"].ToString().Trim();
                    string dDate = dtlist.Rows[i]["dDate"].ToString().Trim();

                    #region 生成table
                    DataRow dr = dts.NewRow();
                    long sAutoID = clsPublic.GetMaxID("RDS");
                    dr["AutoID"] = sAutoID;
                    dr["ID"] = iID;
                    dr["cRDCode"] = textEdit单据号.EditValue.ToString().Trim();
                    dr["iRowNo"] = i + 1;
                    dr["cInvCode"] = cInvCode;
                    dr["M1"] = M1;
                    dr["M2"] = M2;
                    dr["sBoxQty"] = sBoxQty;
                    dr["BoxNo"] = BoxNo;
                    dr["sBoxNo"] = sBoxNo;
                    dr["iQuantity"] = dtDis.Rows[i]["iQuantity"];
                    dr["SoAutoID"] = SOAutoID;
                    dr["DLsID"] = DLsID;
                    dr["cPosCode"] = cPosCode;
                    dr["iUnitPrice"] = iUnitPrice;
                    dr["iMoney"] = iUnitPrice;
                    dr["iNatUnitPrice"] = iNatUnitPrice;
                    dr["iNatMoney"] = iNatUnitPrice;
                    dr["iTaxRate"] = iTaxRate;
                    dr["RdAutoID"] = RdAutoID;
                    dr["cSOPSID"] = cSOPSID;

                    dr["UpdateDate"] = DateTime.Now.ToString();
                    dts.Rows.Add(dr);
                    #endregion

                    sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, "RdRecords13", dts, dts.Rows.Count - 1);

                    aList.Add(sSQL);

                    aList.Add(clsPublic.ReturnWriteSoAutoID(SOAutoID));

                    sSQL = "update SO_SODetails set isDispatchList=null from DispatchListSublist b where SO_SODetails.AutoID=b.SOAutoID and b.ID='" + textEditID.EditValue.ToString().Trim() + "'";
                    aList.Add(sSQL);

                    //反写成品入库单
                    sSQL = "update RdRecords03 set sOutBoxQty=isnull(sOutBoxQty,0)+" + 1 + ",iOutQuantity=isnull(iOutQuantity,0)+" + iQuantity + " where AutoID='" + RdAutoID + "'";
                    aList.Add(sSQL);


                    //反写装箱单
                    sSQL = "update SO_SOPackingSublist set sOutBoxQty=isnull(sOutBoxQty,0)+" + 1 + ",iOutQuantity=isnull(iOutQuantity,0)+" + iQuantity + ",OutcCusCode='" + cCusCode + "',OutcPersonCode='" + cPersonCode + "',OutcDepCode='" + cDepCode + "',OutDate='" + dDate + "',OutSoAutoID='" + SOAutoID + "' where sID='" + cSOPSID + "'";
                    aList.Add(sSQL);
                }
                #endregion
            }
            if (sErr != "")
            {
                throw new Exception(sErr);
            }

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("生成成功！\n合计执行语句:" + iCou + "条");

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

            sSQL = "update " + tablename + " set dClosesysTime='" + GetSystemTime() + "',dClosesysPerson='" + 系统服务.ClsBaseDataInfo.sUid + "' where ID=" + textEditID.EditValue.ToString().Trim() + "";
            aList.Add(sSQL);
            sSQL = "update " + tablenames + " set cClosesysTime='" + GetSystemTime() + "',cClosesysPerson='" + 系统服务.ClsBaseDataInfo.sUid + "' where ID=" + textEditID.EditValue.ToString().Trim() + " and  (cClosesysPerson='' or cClosesysPerson is null)";
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

            //for (int i = 0; i < gridView1.RowCount; i++)
            //{
            //    if (gridView1.GetRowCellValue(i, gridCol物料编码).ToString().Trim() == "")
            //        continue;

            //    long lAutoID = Convert.ToInt64(gridView1.GetRowCellValue(i, gridColAutoID));
            //    gridView1.SetRowCellValue(i, gridCol引用量, iCodeUsed(lAutoID));
            //}

            sState = "alter";
            SetEnabled(true);
        }

        #endregion

        private void Frm销售发货单_Load(object sender, EventArgs e)
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

                sSQL = @"select a.*,u1.vchrName as 制单人,u2.vchrName as 审核人 ,p.PersonName,b.数量,"
+"convert(varchar(10),dCreatesysTime,120) as 制单日期,convert(varchar(10),dVerifysysTime,120) as 审核日期,convert(varchar(10),dDate,120) as 单据日期 ,null as 现存量 from " + tablename + " a "
+ @"left join _UserInfo u1 on a.dCreatesysPerson=u1.vchrUid left join _UserInfo u2 on a.dVerifysysPerson=u2.vchrUid 
left join Person p on a.cPersonCode=p.PersonCode 
left join (select ID,sum(iQuantity) as 数量 from  " + tablenamel + " group by ID) b on a.ID=b.ID where a.ID=" + iID ;

                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                
                if (dt.Rows.Count > 0)
                {
                    textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]); ;
                    textEdit单据号.EditValue = dt.Rows[0]["cDLCode"].ToString();

                    dateEdit单据日期.EditValue = dt.Rows[0]["dDate"].ToString();
                    dateEdit制单日期.EditValue = dt.Rows[0]["dCreatesysTime"].ToString();
                    dateEdit审核日期.EditValue = dt.Rows[0]["dVerifysysTime"].ToString();
                    dateEdit关闭日期.EditValue = dt.Rows[0]["dClosesysTime"].ToString();

                    textEdit备注.EditValue = dt.Rows[0]["cMemo"].ToString();
                    textEdit制单人.EditValue = dt.Rows[0]["dCreatesysPerson"].ToString();
                    textEdit审核人.EditValue = dt.Rows[0]["dVerifysysPerson"].ToString();
                    textEdit关闭人.EditValue = dt.Rows[0]["dClosesysPerson"].ToString();


                    buttonEdit部门.EditValue = dt.Rows[0]["cDepCode"].ToString();
                    lookUpEdit部门.EditValue = buttonEdit部门.EditValue;

                    buttonEdit业务员.EditValue = dt.Rows[0]["cPersonCode"].ToString();
                    lookUpEdit业务员.EditValue = buttonEdit业务员.EditValue;

                    sSQL = "select a.*, 'edit' as iSave,iRowNo as 行标记,盒数,已发货盒数,cus.cCusName from " + tablenames + " a "
                    + @"left join (select AutoID,sum(sBoxQty) as 盒数 from  DispatchListSublist group by AutoID) b on a.AutoID=b.AutoID 
left join (select AutoID,count(*) as 已发货盒数 from  DispatchListReturn a left join DispatchListSublist b on a.DLsID=b.sID group by AutoID) c on b.AutoID=c.AutoID
left join Customer cus on a.cCusCode=cus.cCusCode where ID=" + iID + " order by iRowNo";

                    dtBingGrid = clsSQLCommond.ExecQuery(sSQL);

                    gridControl1.DataSource = dtBingGrid;
                    //sSQL = "select a.cInvCode,i.cInvName,convert(decimal(16,2),sum(iQuantity)) as iQuantity from " + tablenames + " a left join Inventory i on a.cInvCode=i.cInvCode where ID=" + iID + " group by a.cInvCode,i.cInvName order by a.cInvCode";
                    //DataTable dtprint = clsSQLCommond.ExecQuery(sSQL);



                    sSQL = @"select a.*,a.iRowNo as 行标记,已发货盒数,cast(a.iQuantity/a.sBoxQty as decimal(16,6)) as 每盒数量,cast(a.sBoxQty as decimal(16,6)) as 历史盒数 ,sos.cSOCode 来源订单号,sos.iRowNo as 来源订单行号 
                    from " + tablenamel + " a left join (select DLsID,count(*) as 已发货盒数 from  DispatchListReturn group by DLsID) d on a.sID=d.DLsID left join SO_SODetails sos on a.SOAutoID=sos.AutoID  where a.ID=" + iID;
                    dt子件 = clsSQLCommond.ExecQuery(sSQL);

                    sPrintLayOutMod = sProPath + "\\print\\Model\\销售发货单Mod.dll";
                    sPrintLayOutUser = sProPath + "\\print\\User\\销售发货单User.dll";

                    //sPrintLayOutMod2 = sProPath + "\\print\\Model\\销售发货单Mod.dll";
                    //sPrintLayOutUser2 = sProPath + "\\print\\User\\销售发货单User.dll";


                    DataTable dtfh = new DataTable();
                    dtfh.Columns.Add("客户编码");
                    dtfh.Columns.Add("存货编码");
                    dtfh.Columns.Add("单据号");
                    for (int i = 0; i < dtBingGrid.Rows.Count; i++)
                    {
                        DataRow dw = dtfh.NewRow();
                        dw["客户编码"] = dtBingGrid.Rows[i]["cCusCode"].ToString() + "-" + dtBingGrid.Rows[i]["cCusName"].ToString();
                        DataTable dttmp = clsPublic.SelectTable(dt子件, new string[,] { { "AutoID", dtBingGrid.Rows[i]["AutoID"].ToString()} }, "sID" );
                        for (int j = 0; j < dttmp.Rows.Count; j++)
                        {
                            if (j > 0)
                            {
                                dw["存货编码"] = dw["存货编码"].ToString() + ",";
                                dw["单据号"] = dw["单据号"].ToString() + ",";
                            }
                            dw["存货编码"] = dw["存货编码"] + dttmp.Rows[i]["cInvCode"].ToString() + "-" + dttmp.Rows[i]["M1"].ToString() + "[" + dttmp.Rows[i]["sBoxQty"].ToString() + "盒]";
                            dw["单据号"] = dw["单据号"] + dttmp.Rows[i]["来源订单号"].ToString() + "-" + dttmp.Rows[i]["来源订单行号"].ToString();
                        }
                        dtfh.Rows.Add(dw);
                    }
                    
                    base.dsPrint.Tables.Clear();
                    base.dsPrint.Tables.Add(dt.Copy());
                    base.dsPrint.Tables[0].TableName = "dtHead";
                    base.dsPrint.Tables.Add(dtfh.Copy());
                    base.dsPrint.Tables[1].TableName = "dtGrid";

                    //base.dsPrint2.Tables.Clear();
                    //base.dsPrint2.Tables.Add(dt.Copy());
                    //base.dsPrint2.Tables[0].TableName = "dtHead";
                    ////base.dsPrint2.Tables.Add(dtprint.Copy());
                    //base.dsPrint2.Tables[1].TableName = "dtGrid";

                    gridView1.AddNewRow();

                    gridView1.FocusedRowHandle = iFocRow;

                    sState = "";

                    SetEnabled(false);
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
            系统服务.LookUp.Department(lookUpEdit部门);
            系统服务.LookUp.Person(lookUpEdit业务员);
            系统服务.LookUp.Customer(ItemLookUpEdit客户);

            系统服务.LookUp.Inventory(ItemLookUpEdit物料名称);
            ItemLookUpEdit物料名称.Properties.DisplayMember = "cInvName";


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

            buttonEdit部门.Enabled = false;

            buttonEdit业务员.Enabled = b;

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

            buttonEdit部门.EditValue = "";
            
            buttonEdit业务员.EditValue = "";
            lookUpEdit业务员.EditValue = "";

            textEditDelS.EditValue = "";

            gridControl1.DataSource = null;
            gridControl2.DataSource = null;
            dt子件 = null;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int iRow = 0;
            if (gridView1.FocusedRowHandle >= 0)
                iRow = gridView1.FocusedRowHandle;

            if (gridView1.GetRowCellValue(iRow, gridCol行号).ToString().Trim() == "")
            {
                gridView1.SetRowCellValue(iRow, gridCol行号, iRow + 1);
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
            #region
           
            if (e.Column != gridColiSave && gridView1.GetRowCellDisplayText(e.RowHandle, gridColiSave).ToString().Trim() == "")
            {
                gridView1.SetRowCellValue(iRow, gridColiSave, "add");
            }
            if (e.Column != gridColiSave && e.Column != gridCol行号 && gridView1.GetRowCellDisplayText(e.RowHandle, gridColiSave).ToString().Trim() == "edit")
            {
                gridView1.SetRowCellValue(iRow, gridColiSave, "update");
            }
            if (e.Column == gridCol客户 && e.RowHandle == gridView1.RowCount - 1 && gridView1.GetRowCellDisplayText(e.RowHandle, gridCol客户).ToString().Trim() != "")
            {
                gridView1.AddNewRow();
                gridView1.FocusedRowHandle = gridView1.RowCount - 1;
                gridView1.FocusedRowHandle = gridView1.RowCount - 2;
            }
            #endregion
        }

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int iRow = 0;
            if (gridView2.FocusedRowHandle >= 0)
                iRow = gridView2.FocusedRowHandle;

            if (e.Column == gridsBoxQty)
            {
                int sBoxQty = ReturnInt(gridView2.GetRowCellValue(iRow, gridsBoxQty));
                decimal 每盒数量 = ReturnDecimal(gridView2.GetRowCellValue(iRow, grid每盒数量));

                #region 判断引用量
                long SOAutoID = -1;
                if (gridView2.GetRowCellValue(iRow, gridSOAutoID) != null && gridView2.GetRowCellValue(iRow, gridSOAutoID).ToString().Trim() != "")
                {
                    SOAutoID = Convert.ToInt64(gridView2.GetRowCellValue(iRow, gridSOAutoID));

                    int 订单数量 = iCodeUsed(SOAutoID);
                    if (sBoxQty > 订单数量)
                    {
                        MessageBox.Show("引用量超出");
                        gridView2.SetRowCellValue(iRow, gridsBoxQty, gridView2.GetRowCellValue(iRow, grid历史盒数));
                    }
                    else
                    {
                        decimal iQuantity = sBoxQty * 每盒数量;
                        gridView2.SetRowCellValue(iRow, gridiQuantity, iQuantity);

                    }
                }
                #endregion
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
            {
                lookUpEdit部门.EditValue = buttonEdit部门.Text.Trim();
                if (lookUpEdit部门.Text.Trim() != "")
                {
                    DataTable dt = 系统服务.LookUp.Department(buttonEdit部门.Text.Trim());
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        buttonEdit部门.EditValue = dt.Rows[0]["cDepCode"];
                    }
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
                sSQL = "select  isnull(dCreatesysPerson,'') as 制单人,isnull(dVerifysysPerson,'') as 审核人,isnull(dClosesysPerson,'') as 关闭人 from " + tablename + " where "+tablecode+" = '" + sCode + "'";
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

                    //sSQL = "select count(1) from " + tablename + " a inner join " + tablenames + " b on a.id = b.id where a." + tablecode + " = '" + sCode + "' and isnull(cClosesysPerson,'') <> ''";
                    //long iCou = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                    //if (iCou > 0)
                    //{
                    //    iReturn = 3;
                    //}
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
                //
                sSQL = @"select count(1) from dbo.RdRecord a inner join dbo.RdRecords b on a.ID = b.ID inner join MO_MODetails ms on b.MOAutoID=ms.AutoID inner join MO_MOMain m on ms.ID=m.ID " +
                       "where m.cMOCode = '" + sCode + "'";
                int iReturn1 = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));

                sSQL = "select * from dbo.RdRecord a inner join dbo.RdRecords b on a.ID = b.ID inner join MO_MOSublist ms on b.MOsID=ms.sID inner join MO_MOMain m on ms.ID=m.ID  " +
                       "where m.cMOCode = '" + sCode + "'";
                int iReturn2 = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));

                if (iReturn1 > iReturn2)
                    iReturn = iReturn1;
                else
                    iReturn = iReturn2;

                //iReturn = iReturn1;
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
        private int iCodeUsed(long sID)
        {
            int iReturn = -1;
            try
            {
                sSQL = @"select b.sBoxQty-isnull(sOutBoxQty,0) as sBoxQty from SO_SODetails b 
                       where AutoID = '" + sID + "'";
                int iReturn1 = ReturnInt(clsSQLCommond.ExecGetScalar(sSQL));
                if (iReturn1 > iReturn && iReturn1 > 0)
                    iReturn = iReturn1;

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

        private void buttonEdit业务员_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(2);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit业务员.EditValue = frm.sID;

                frm.Enabled = true;
            }
        }

        private void buttonEdit业务员_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit业务员.Text.Trim() != "")
            {
                lookUpEdit业务员.EditValue = buttonEdit业务员.Text.Trim();
                //if (lookUpEdit业务员.Text.Trim() != "")
                //{
                //    DataTable dt = 系统服务.LookUp.PersonDepartment(buttonEdit业务员.Text.Trim());
                //    if (dt != null && dt.Rows.Count > 0)
                //    {
                //        buttonEdit委外供应商.EditValue = dt.Rows[0]["cDepCode"];
                //    }
                //}
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

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void ItemButtonEdit客户_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int iRow = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.IsRowSelected(i))
                {
                    iRow = i;
                }
            }
            string cCusCode = gridView1.GetRowCellValue(iRow, gridCol客户).ToString().Trim();
            系统服务.Frm参照 frm = new 系统服务.Frm参照(9);
            if (DialogResult.OK == frm.ShowDialog())
            {
                gridView1.SetRowCellValue(iRow, gridCol客户, frm.sID);
                frm.Enabled = true;
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            int iRow = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.IsRowSelected(i))
                {
                    iRow = i;
                }
            }
            
            if (textEdit行标记.EditValue != null && textEdit行标记.EditValue.ToString() != "")
            {
                string 行标记 = textEdit行标记.EditValue.ToString();
                //删除所有行标记
                DataTable dttmp = clsPublic.SelectTable(dt子件, new string[,] { { "行标记", 行标记 } }, "行标记");
                for (int i = dt子件.Rows.Count - 1; i >= 0; i--)
                {
                    if (dt子件.Rows[i]["行标记"].ToString().Trim() == 行标记)
                    {
                        dt子件.Rows.Remove(dt子件.Rows[i]);
                    }
                }
                //添加
                if (gridView2.RowCount > 0)
                {
                    DataTable dtl = (DataTable)gridControl2.DataSource;
                    for (int i = 0; i < dtl.Rows.Count; i++)
                    {
                        dt子件.ImportRow(dtl.Rows[i]);
                    }
                }
            }
            BindGrid2(iRow);
        }

        private void BindGrid2(int iRow)
        {
            string 行号 = gridView1.GetRowCellValue(iRow, gridCol行号).ToString().Trim();
            string 行标记 = gridView1.GetRowCellValue(iRow, gridCol行标记).ToString().Trim();
            string cCusCode = gridView1.GetRowCellValue(iRow, gridCol客户).ToString().Trim();
            textEdit行号.EditValue = 行号;
            textEdit行标记.EditValue = 行标记;
            textEdit客户.EditValue = cCusCode;
            if (textEdit行标记.EditValue != "")
            {
                DataTable dttmp = clsPublic.SelectTable(dt子件, new string[,] { { "行标记", 行标记 } }, "行标记");
                gridControl2.DataSource = dttmp;
            }
            else
            {
                gridControl2.DataSource = null;
            }
        }

    }
}
