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
        string tablename = "SO_SOMain";
        string tableid = "ID";
        string tablecode = "cSOCode";
        string tablenames = "SO_SODetails";

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


        public Frm销售订单(long siID)
        {
            iID = siID;
            InitializeComponent();

        }

        public Frm销售订单()
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
            //DataTable dtState = (DataTable)ItemLookUpEditPerState.DataSource;
            //DataTable dtType = (DataTable)ItemLookUpEditType.DataSource;
            DataColumn dc = new DataColumn();
            dc.ColumnName = "StateText";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "TypeText";
            dt.Columns.Add(dc);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //DataRow[] drState = dtState.Select("iID = '" + dt.Rows[i]["State"].ToString().Trim() + "'");
                //if (drState.Length > 0)
                //{
                //    dt.Rows[i]["StateText"] = drState[0]["State"];
                //}

                //DataRow[] drType = dtType.Select("iID = '" + dt.Rows[i]["Type"].ToString().Trim() + "'");
                //if (drType.Length > 0)
                //{
                //    dt.Rows[i]["TypeText"] = drType[0]["Type"];
                //}
            }
            
            return dt;
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
            //if (iRe == 2)
            //{
            //    throw new Exception("单据已审核");
            //}
            if (iRe == 3)
            {
                throw new Exception("单据已关闭");
            }
            try
            {

                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;

                base.dsPrint.Tables.Clear();
                base.dsPrint.Tables.Add(dtBingHead.Copy());
                base.dsPrint.Tables[0].TableName = "dtHead";

                DataTable dt = dtBingGrid.Copy();
                decimal dsum = 0;
                decimal dsumQty = 0;
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    if (dt.Rows[i]["cinvcode"].ToString() == "")
                    {
                        dt.Rows.Remove(dt.Rows[i]);
                    }
                    else
                    {
                        decimal d = ReturnDecimal(dt.Rows[i]["sBoxQty"]) - ReturnDecimal(dt.Rows[i]["已发盒数"]);
                        if (d > 0)
                        {
                            dt.Rows[i]["sBoxQty"] = d;
                            dsum = dsum + d;
                        }
                        decimal d1 = ReturnDecimal(dt.Rows[i]["iQuantity"]) - ReturnDecimal(dt.Rows[i]["已发数量"]);
                        if (d1 > 0)
                        {
                            dt.Rows[i]["iQuantity"] = d1;
                            dsumQty = dsumQty + d1;
                        }
                        if (lookUpEdit销售类型.EditValue.ToString() != "03" && d==0)
                        {
                            dt.Rows.Remove(dt.Rows[i]);
                        }
                        else if (lookUpEdit销售类型.EditValue.ToString() == "03" && d1 == 0)
                        {
                            dt.Rows.Remove(dt.Rows[i]);
                        }
                    }
                }
                base.dsPrint.Tables[0].Rows[0]["sBoxQty"] = dsum;
                base.dsPrint.Tables[0].Rows[0]["iQuantity"] = dsumQty;

                if (dt.Rows.Count == 0)
                {
                    throw new Exception("无需打印的销售订单");
                }
                base.dsPrint.Tables.Add(dt);
                base.dsPrint.Tables[1].TableName = "dtGrid";


                aList = new System.Collections.ArrayList();
                aList.Add("update  " + tablename + " set PrintCount=" + textEdit打印次数.EditValue.ToString() + "+1,LastPrintDate=getdate() where ID=" + textEditID.EditValue);
                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);
                    GetGrid();

                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
 
            }
        }

        /// <summary>
        /// 打印
        /// </summary>
        private void btnPrint2()
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
            try
            {

                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);

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
        /// 导入 打印销售订单
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
            Frm销售订单_Add frm = new Frm销售订单_Add(单据号1, 单据号2, 单据日期1, 单据日期2, 制单日期1, 制单日期2, 业务员,
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
            if (系统服务.ClsBaseDataInfo.sUid != "admin")
            {
                sSQL = sSQL + " and cSTCode in (select cSTCode from SaleRole where vchrUid='" + 系统服务.ClsBaseDataInfo.sUid + "') ";
            }
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
                sSQL = "select min(ID) as ID from " + tablename + "  where 1=1 ";

                //if (系统服务.ClsBaseDataInfo.sUid != "admin")
                //{
                //    sSQL = sSQL + " and cSTCode in (select cSTCode from SaleRole where vchrUid='" + 系统服务.ClsBaseDataInfo.sUid + "')";
                //}

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

                    //if (系统服务.ClsBaseDataInfo.sUid != "admin")
                    //{
                    //    sSQL = sSQL + " and cSTCode in (select cSTCode from SaleRole where vchrUid='" + 系统服务.ClsBaseDataInfo.sUid + "')";
                    //}

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

                    //if (系统服务.ClsBaseDataInfo.sUid != "admin")
                    //{
                    //    sSQL = sSQL + " and cSTCode in (select cSTCode from SaleRole where vchrUid='" + 系统服务.ClsBaseDataInfo.sUid + "')";
                    //}

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

                //if (系统服务.ClsBaseDataInfo.sUid != "admin")
                //{
                //    sSQL = sSQL + " and cSTCode in (select cSTCode from SaleRole where vchrUid='" + 系统服务.ClsBaseDataInfo.sUid + "')";
                //}

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
        /// 锁定 折扣率审核
        /// </summary>
        private void btnLock()
        {
            if (textEdit单据号.Text.Trim() == "")
            {
                throw new Exception("请选择需要审核的单据");
            }
            if (textEdit折扣率.EditValue.ToString().Trim() == "")
            {
                throw new Exception("折扣率未填写不可审核");
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
            //if (iRe == 2)
            //{
            //    throw new Exception("单据已审核");
            //}
            //if (iRe == 3)
            //{
            //    throw new Exception("单据已关闭");
            //}
            sSQL = "select isnull(dPerVerifysysPerson,'') as 折扣率审核人 from " + tablename + " where cSOCode = '" + textEdit单据号.Text.Trim() + "'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["折扣率审核人"].ToString() != "")
                {
                    throw new Exception("折扣率已审核，不可再审");
                }
            }

            aList = new System.Collections.ArrayList();

            sSQL = "update " + tablename + " set dPerVerifysysTime='" + GetSystemTime() + "',dPerVerifysysPerson='" + 系统服务.ClsBaseDataInfo.sUid + "' where ID=" + textEditID.EditValue.ToString().Trim() + "";
            aList.Add(sSQL);

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("审核折扣率成功！\n合计执行语句:" + iCou + "条");
                GetGrid();
            }
        }
        /// <summary>
        /// 解锁  折扣率弃审
        /// </summary>
        private void btnUnLock()
        {
            if (textEdit单据号.Text.Trim() == "")
            {
                throw new Exception("请选择需要弃审的单据");
            }
            if (textEdit折扣率.EditValue.ToString().Trim() == "")
            {
                throw new Exception("折扣率未填写不可审核");
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
            //    throw new Exception("单据未审核");
            //}
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

            sSQL = "select isnull(dPerVerifysysPerson,'') as 折扣率审核人 from " + tablename + " where cSOCode = '" + textEdit单据号.Text.Trim() + "'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["折扣率审核人"].ToString() == "")
                {
                    throw new Exception("折扣率未审核，不可弃审");
                }
            }

            aList = new System.Collections.ArrayList();

            sSQL = "update " + tablename + " set dPerVerifysysTime=null,dPerVerifysysPerson=null where ID=" + textEditID.EditValue.ToString().Trim() + "";
            aList.Add(sSQL);

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("弃审折扣率成功！\n合计执行语句:" + iCou + "条");
                GetGrid();
            }
        }
        /// <summary>
        /// 增行 引用
        /// </summary>
        private void btnAddRow()
        {
            
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
                if (gridView1.GetRowCellDisplayText(i, gridCol序号).ToString().Trim() != "")
                {
                    gridView1.SetRowCellValue(i, gridCol序号, i + 1);
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

            sSQL = "select a.*, 'edit' as iSave,cast(null as decimal(16,6)) as 引用量,cast(null as decimal(16,6)) as 历史数量,cast(null as decimal(16,6)) as 历史样品数量,cast(null as decimal(16,6)) as 历史,iRowNo as 行标记,null as 现存量 from " + tablenames + " a where 1=-1";
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
            sState = "add";
            lookUpEdit销售类型.EditValue = "01";

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
            gridView1.AddNewRow();
            gridView1.FocusedRowHandle = 0;
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
            
           
            sSQL = "select isnull(max(AutoID)+1,1) as AutoID from " + tablenames;
            long sAutoID = long.Parse(clsSQLCommond.ExecQuery(sSQL).Rows[0][0].ToString());
            aList = new System.Collections.ArrayList();
            DataRow drh = dt.NewRow();
            if (sState == "add")
            {
                sSQL = "select isnull(isnull(max(ID),-1)+1,1) as ID from " + tablename;
                iID = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                drh["ID"] = iID;
                drh["cSOCode"] = clsPublic.GetNewSerialNumberContinuous(tablename, tablecode);
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
            if (textEdit折扣率.EditValue != null && textEdit折扣率.EditValue.ToString().Trim() != "")
            {
                drh["DD1"] = textEdit折扣率.EditValue.ToString().Trim();
            }
            

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
                    if (lookUpEdit销售类型.EditValue.ToString().Trim()!="03" && gridView1.GetRowCellDisplayText(i, gridCol盒数).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + gridCol盒数.Caption + "必须大于0\n";
                        continue;
                    }
                    if (ReturnDecimal(gridView1.GetRowCellValue(i, gridCol数量)) <= 0)
                    {
                        sErr = sErr + "行" + (i + 1) + gridCol数量.Caption + "必须大于0\n";
                        continue;
                    }
                    if (ReturnDecimal(gridView1.GetRowCellValue(i, gridCol含税单价)) == 0)
                    {
                        sErr = sErr + "行" + (i + 1) + gridCol无税单价.Caption + "不能为0\n";
                        continue;
                    }
                    #endregion

                    #region 判断引用量
                    long lAutoid = -1;
                    if (gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim() != "")
                    {
                        lAutoid = Convert.ToInt64(gridView1.GetRowCellValue(i, gridColAutoID));
                    }
                    decimal Qty = ReturnDecimal(gridView1.GetRowCellValue(i, gridCol数量));
                    if (lAutoid > -1)
                    {
                        decimal 引用量 = iCodeUsed(lAutoid);
                        if (Qty < 引用量)
                        {
                            sErr = sErr + "行" + (i + 1) + "引用量超出数量\n"; 
                            gridView1.SetRowCellValue(i, gridCol数量, gridView1.GetRowCellValue(i, gridCol历史数量));
                        }
                    }
                    for (int j = 0; j < i; j++)
                    {
                        if (gridView1.GetRowCellValue(i, gridCol物料编码).ToString().Trim() == gridView1.GetRowCellValue(j, gridCol物料编码).ToString().Trim()
                            && gridView1.GetRowCellValue(i, gridColM1).ToString().Trim() == gridView1.GetRowCellValue(j, gridColM1).ToString().Trim())
                        {
                            sErr = sErr + "行" + (i + 1) + "物料编码不可重复\n"; 
                        }
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
                    dr["ID"] = iID;
                    dr["cSOCode"] = textEdit单据号.EditValue.ToString().Trim();
                    dr["iRowNo"] = gridView1.GetRowCellValue(i, gridCol序号).ToString().Trim();
                    dr["cInvCode"] = gridView1.GetRowCellValue(i, gridCol物料编码).ToString().Trim();
                    dr["iQuantity"] = gridView1.GetRowCellValue(i, gridCol数量).ToString().Trim();
                    if (gridView1.GetRowCellValue(i, gridCol盒数) != null && gridView1.GetRowCellValue(i, gridCol盒数).ToString().Trim() != "")
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
                    if (gridView1.GetRowCellValue(i, gridCol税额) != null && gridView1.GetRowCellValue(i, gridCol税额).ToString().Trim() != "")
                    {
                        dr["iNatTax"] = gridView1.GetRowCellValue(i, gridCol税额).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol换算率) != null && gridView1.GetRowCellValue(i, gridCol换算率).ToString().Trim() != "")
                    {
                        dr["iChangRate"] = gridView1.GetRowCellValue(i, gridCol换算率).ToString().Trim();
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

                    if (gridView1.GetRowCellValue(i, gridCol每盒含税价格) != null && gridView1.GetRowCellValue(i, gridCol每盒含税价格).ToString().Trim() != "")
                    {
                        dr["D1"] = gridView1.GetRowCellValue(i, gridCol每盒含税价格).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol每盒重量) != null && gridView1.GetRowCellValue(i, gridCol每盒重量).ToString().Trim() != "")
                    {
                        dr["D2"] = gridView1.GetRowCellValue(i, gridCol每盒重量).ToString().Trim();
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
            //if (bCount != 1)
            //{
            //    throw new Exception("销售订单只能有一行");
            //}
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
            sSQL = "select NotDelivery from Customer where cCusCode='" + lookUpEdit客户.EditValue + "'";
            DataTable dtcus = clsSQLCommond.ExecQuery(sSQL);
            if (dtcus.Rows.Count > 0 && dtcus.Rows[0]["NotDelivery"].ToString().Trim() == "True")
            {
                throw new Exception("已限制出库，请与财务联系");
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
            gridView1.AddNewRow();
            gridView1.FocusedRowHandle = 0;
            sState = "alter";
            SetEnabled(true);
        }

        #endregion

        private void Frm销售订单_Load(object sender, EventArgs e)
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
                sSQL = @"select a.*,u1.vchrName as 制单人,u2.vchrName as 审核人,d.cDepName,c.cCusName ,p.PersonName,b.sBoxQty,b.iQuantity,
convert(varchar(10),dCreatesysTime,120) as 制单日期,convert(varchar(10),dVerifysysTime,120) as 审核日期,convert(varchar(10),dDate,120) as 单据日期 ,null as 现存量,
c.cCusPerson as 收件人,c.cCusAddress as 地址,c.cCusPhone as 手机,c.cCusPhone2 as 电话,c.cCusName as 客户名称,c.S1 as 邮编,dc.cDCName as 区域 
from " + tablename + " a "
+ @"left join _UserInfo u1 on a.dCreatesysPerson=u1.vchrUid left join _UserInfo u2 on a.dVerifysysPerson=u2.vchrUid 
left join Department d on a.cDepCode=d.cDepCode left join Customer c on a.cCusCode=c.cCusCode left join Person p on a.cPersonCode=p.PersonCode left join DistrictClass dc on c.cDCCode=dc.cDCCode "
+ @"left join (select ID,sum(iQuantity) as iQuantity,sum(sBoxQty) as sBoxQty  from " + tablenames + " group by ID) b on a.ID=b.ID where a.ID=" + iID + " ";

                dtBingHead = clsSQLCommond.ExecQuery(sSQL);

                if (dtBingHead.Rows.Count > 0)
                {
                    textEditID.EditValue = Convert.ToInt64(dtBingHead.Rows[0]["ID"]); ;
                    textEdit单据号.EditValue = dtBingHead.Rows[0]["cSOCode"].ToString();

                    dateEdit单据日期.EditValue = dtBingHead.Rows[0]["dDate"].ToString();
                    dateEdit制单日期.EditValue = dtBingHead.Rows[0]["dCreatesysTime"].ToString();
                    dateEdit审核日期.EditValue = dtBingHead.Rows[0]["dVerifysysTime"].ToString();
                    dateEdit关闭日期.EditValue = dtBingHead.Rows[0]["dClosesysTime"].ToString();
                    dateEdit折扣率审核日期.EditValue = dtBingHead.Rows[0]["dPerVerifysysTime"].ToString();

                    textEdit备注.EditValue = dtBingHead.Rows[0]["cMemo"].ToString();
                    textEdit制单人.EditValue = dtBingHead.Rows[0]["dCreatesysPerson"].ToString();
                    textEdit审核人.EditValue = dtBingHead.Rows[0]["dVerifysysPerson"].ToString();
                    textEdit关闭人.EditValue = dtBingHead.Rows[0]["dClosesysPerson"].ToString();
                    textEdit折扣率审核人.EditValue = dtBingHead.Rows[0]["dPerVerifysysPerson"].ToString();

                    buttonEdit客户.EditValue = dtBingHead.Rows[0]["cCusCode"].ToString();
                    lookUpEdit客户.EditValue = buttonEdit客户.EditValue;
                    buttonEdit业务员.EditValue = dtBingHead.Rows[0]["cPersonCode"].ToString();
                    lookUpEdit业务员.EditValue = buttonEdit业务员.EditValue;
                    buttonEdit部门.EditValue = dtBingHead.Rows[0]["cDepCode"].ToString();
                    lookUpEdit部门.EditValue = buttonEdit部门.EditValue;

                    lookUpEdit销售类型.EditValue = dtBingHead.Rows[0]["cSTCode"].ToString();

                    textEdit折扣率.EditValue = dtBingHead.Rows[0]["DD1"].ToString();
                    textEdit打印次数.EditValue = dtBingHead.Rows[0]["PrintCount"].ToString();

                    sSQL = @"
select a.*, 'edit' as iSave,cast(null as decimal(16,6)) as 引用量,cast(a.iQuantity as decimal(16,6)) as 历史数量,i.cInvName,null as 现存量 
    ,isnull(a.sOutBoxQty,0) 已发盒数 ,isnull(a.iOutQuantity,0) 已发数量,'' as 建议货位
    ,sOutLastDateTime 
from SO_SODetails a left join Inventory i on a.cInvCode=i.cInvCode 
where ID=" + iID + " order by iRowNo";
                    sSQL = sSQL.Replace("1=1", "1=1 and a.ID=" + iID + "");

                    dtBingGrid = clsSQLCommond.ExecQuery(sSQL);

                    for (int i = 0; i < dtBingGrid.Rows.Count; i++)
                    {
                        if (dtBingGrid.Rows[i]["cInvCode"].ToString() != "" && dtBingGrid.Rows[i]["M1"].ToString() != "")
                        {
                            dtBingGrid.Rows[i]["现存量"] = clsPublic.Get现存量(dtBingGrid.Rows[i]["cInvCode"].ToString(), dtBingGrid.Rows[i]["M1"].ToString());
                        }
                        sSQL = @"select cPosCode from CurrentStock where cInvCode='" + dtBingGrid.Rows[i]["cInvCode"].ToString() + "' and M1='" + dtBingGrid.Rows[i]["M1"].ToString() + "' group by cPosCode";
                        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                        string cPosCode = "";
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            if (cPosCode != "")
                            {
                                cPosCode = cPosCode + ",";
                            }
                            cPosCode = cPosCode + dt.Rows[j]["cPosCode"].ToString();
                        }
                        dtBingGrid.Rows[i]["建议货位"] = cPosCode;
                    }
                    gridControl1.DataSource = dtBingGrid;
                    dtBingGrid.TableName = "dtGrid";

                    gridView1.FocusedRowHandle = iFocRow;

                    SetEnabled(false);

                    sState = "sel";

                    if (lookUpEdit销售类型.EditValue.ToString() == "03")
                    {
                        sPrintLayOutMod = sProPath + "\\print\\Model\\" + this.Text.Trim() + "Mod_1.dll";
                        sPrintLayOutUser = sProPath + "\\print\\User\\" + this.Text.Trim() + "User_1.dll";
                    }



                    base.dsPrint2.Tables.Clear();
                    base.dsPrint2.Tables.Add(dtBingHead.Copy());
                    base.dsPrint2.Tables[0].TableName = "dtHead";
                    base.dsPrint2.Tables.Add(dtBingHead.Copy());
                    base.dsPrint2.Tables[1].TableName = "dtGrid";
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
            系统服务.LookUp.SaleType(lookUpEdit销售类型);
            系统服务.LookUp.Person(lookUpEdit业务员);
            系统服务.LookUp.Department(lookUpEdit部门);
            系统服务.LookUp.Customer(lookUpEdit客户);

            系统服务.LookUp.ColorNo(ItemLookUpEditM1);

            系统服务.LookUp.Inventory(ItemLookUpEdit物料名称);
            ItemLookUpEdit物料名称.Properties.DisplayMember = "cInvName";
            系统服务.LookUp.Inventory(ItemLookUpEdit物料规格);
            ItemLookUpEdit物料规格.Properties.DisplayMember = "cInvStd";
            系统服务.LookUp.Inventory(ItemLookUpEdit物料代码);
            ItemLookUpEdit物料规格.Properties.DisplayMember = "cInvAddCode";
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
            lookUpEdit销售类型.Enabled = b;
            textEdit折扣率.Enabled = b;
            gridView1.OptionsBehavior.Editable = b;

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
            lookUpEdit业务员.EditValue = "";
            buttonEdit部门.EditValue = "";
            lookUpEdit部门.EditValue = "";
            buttonEdit客户.EditValue = "";
            lookUpEdit客户.EditValue = "";
            lookUpEdit销售类型.EditValue = "";
            textEdit折扣率.EditValue = "";

            textEditDelS.EditValue = "";

            gridControl1.DataSource = null;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int iRow = 0;
            if (gridView1.FocusedRowHandle >= 0)
                iRow = gridView1.FocusedRowHandle;

            string invocde = gridView1.GetRowCellValue(iRow, gridCol物料编码).ToString().Trim();
            string M1 = gridView1.GetRowCellValue(iRow, gridColM1).ToString().Trim();
            #region 行号
            if (gridView1.GetRowCellValue(iRow, gridCol序号).ToString().Trim() == "")
            {
                gridView1.SetRowCellValue(iRow, gridCol序号, iRow + 1);
            }
            #endregion

            if (e.Column == gridCol物料编码)
            {
                if (invocde != "")
                {
                    #region 每盒含税单价
                    if (lookUpEdit客户.Text != "")
                    {
                        decimal price = clsPublic.PriceAdjust(invocde, buttonEdit客户.EditValue.ToString().Trim());
                        if (price != 0)
                        {
                            gridView1.SetRowCellValue(iRow, gridCol每盒含税价格, price);
                        }
                        else
                        {
                            gridView1.SetRowCellValue(iRow, gridCol每盒含税价格, null);
                        }

                        if (lookUpEdit销售类型.EditValue != null && lookUpEdit销售类型.EditValue.ToString().Trim() == "03")
                        {  if (price != 0)
                        {
                            gridView1.SetRowCellValue(iRow, gridCol含税单价, price);
                        }
                        else
                        {
                            gridView1.SetRowCellValue(iRow, gridCol含税单价, null);
                        }

                        }
                    }
                    #endregion

                    #region 换算率和税率
                    decimal d换算率 = clsPublic.iinvexchrate(invocde);
                    if (d换算率 > 0)
                    {
                        gridView1.SetRowCellValue(iRow, gridCol换算率, d换算率);
                    }
                    else
                    {
                        gridView1.SetRowCellValue(iRow, gridCol换算率, null);
                    }
                    gridView1.SetRowCellValue(iRow, gridCol税率, 17);
                    #endregion

                    #region 每盒重量 从存货档案中
                    sSQL = "select D2 from Inventory where cInvCode='" + invocde + "'";
                    decimal d重量 = ReturnDecimal(clsSQLCommond.ExecGetScalar(sSQL));
                    if (d重量 > 0)
                    {
                        gridView1.SetRowCellValue(iRow, gridCol每盒重量, d重量);
                    }
                    else
                    {
                        gridView1.SetRowCellValue(iRow, gridCol每盒重量, null);
                    }
                    #endregion
                }
                
                
            }
            if (e.Column == gridCol物料编码 || e.Column == gridColM1)
            {
                if (invocde != "" && M1 != "")
                {
                    gridView1.SetRowCellValue(iRow, gridCol现存量, clsPublic.Get现存量(invocde, M1));
                }
            }

            #region 判断引用量
            long lAutoid = -1;
            if (gridView1.GetRowCellValue(iRow, gridColAutoID).ToString().Trim() != "")
            {
                lAutoid = Convert.ToInt64(gridView1.GetRowCellValue(iRow, gridColAutoID));
            }
            decimal Qty = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol数量));
            if (lAutoid > -1)
            {
                decimal 引用量 = iCodeUsed(lAutoid);
                if (Qty < 引用量)
                {
                    MessageBox.Show("引用量超出");
                    gridView1.SetRowCellValue(iRow, gridCol数量, gridView1.GetRowCellValue(iRow, gridCol历史数量));
                }
            }
            #endregion

            #region 数量和价格
            if (lookUpEdit销售类型.EditValue.ToString().Trim() != "03")
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
            else
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

                        gridView1.SetRowCellValue(iRow, gridCol无税单价, 无税单价);
                        gridView1.SetRowCellValue(iRow, gridCol无税金额, 无税金额);
                        gridView1.SetRowCellValue(iRow, gridCol含税金额, 含税金额);
                    
                    gridView1.SetRowCellValue(iRow, gridCol税额, 税额);

                    #endregion
                }
            }
            #endregion

            #region M1
            if (e.Column == gridM1)
            {
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
                gridView1.FocusedRowHandle = gridView1.RowCount - 1;
                gridView1.FocusedRowHandle = gridView1.RowCount - 2;
            }
            #endregion
        }

        #region buttonEdit
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


        #endregion

        #region ItemButtonEdit
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
        #endregion

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
                sSQL = "select count(1) from dbo.SO_SOMain a inner join dbo.SO_SODetails b on a.ID = b.ID inner join dbo.RdRecords13 c on c.SoAutoID = b.AutoID " +
                     "where a.cSOCode = '" + sCode + "'";
                int iReturn1 = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                return iReturn1;
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
                sSQL = "select isnull(sum(c.iQuantity),0) as iQty from dbo." + tablename + " a inner join dbo." + tablenames + " b on a.ID = b.ID inner join dbo.RdRecords13 c on c.SoAutoID = b.AutoID " +
                       "where b.AutoID = '" + AutoID + "'";
                decimal iReturn1 = ReturnDecimal(clsSQLCommond.ExecGetScalar(sSQL));
                if (iReturn1 > iReturn && iReturn1 > 0)
                    iReturn = iReturn1;

                sSQL = "select isnull(sum(c.iQuantity),0) as iQty from dbo.MO_MOMain a inner join dbo.MO_MODetails b on a.ID = b.ID inner join dbo.SaleBillVouchs c on c.SoAutoID = b.AutoID " +
                       "where b.AutoID = '" + AutoID + "'";
                decimal iReturn2 = ReturnDecimal(clsSQLCommond.ExecGetScalar(sSQL));
                if (iReturn2 > iReturn && iReturn2 > 0)
                    iReturn = iReturn2;

            }
            catch (Exception ee)
            { }
            return iReturn;
        }

        private void ItemButtonEditcInvCode_EditValueChanged(object sender, EventArgs e)
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

        private void ItemButtonEdit物料编码_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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

        private void lookUpEdit销售类型_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEdit销售类型.EditValue.ToString().Trim() == "03")
            {
                gridCol数量.OptionsColumn.AllowEdit = true;
                gridCol盒数.Visible = false;
                gridCol每盒含税价格.Visible = false;
                gridCol每盒重量.Visible = false;
                gridCol含税单价.OptionsColumn.AllowEdit = true;
                gridCol已发盒数.Visible = false;
                gridCol现存量.Visible = false;
                gridCol含税单价.Visible = true;
                gridCol发货日期.Visible = false;

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    decimal d单价 = ReturnDecimal(gridView1.GetRowCellValue(i, gridCol含税单价));
                    if(d单价 ==0)
                    {
                        gridView1.SetRowCellValue(i,gridCol含税单价,gridView1.GetRowCellValue(i,gridCol每盒含税价格));
                    }
                }
            }
            else
            {
                gridCol数量.OptionsColumn.AllowEdit = false;
                gridCol盒数.Visible = true;
                gridCol每盒含税价格.Visible = true;
                gridCol每盒重量.Visible = true;
                gridCol含税单价.OptionsColumn.AllowEdit = false;
                gridCol已发盒数.Visible = true;
                gridCol现存量.Visible = true;
                gridCol含税单价.Visible = false;
                gridCol发货日期.Visible = true;

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridCol含税单价, DBNull.Value);
                }
            }
        }

    }
}
