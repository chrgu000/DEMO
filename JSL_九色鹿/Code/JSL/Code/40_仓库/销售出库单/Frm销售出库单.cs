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
    public partial class Frm销售出库单 : 系统服务.FrmBaseInfo
    {
        string tablename = "RdRecord13";
        string tableid = "ID";
        string tablecode = "cRdCode";
        string tablenames = "RdRecords13";

        string cSQL = " ";
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
        public string 删除 = "";

        public string s销售订单号 = "";

        public DataTable dt子件;

        //string isChange = "";
        DataTable dth;

        public Frm销售出库单(long siID,string title)
        {
            iID = siID;
            InitializeComponent();

        }

        public Frm销售出库单()
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
                aList = new System.Collections.ArrayList();
                aList.Add("update  " + tablename + " set PrintCount=" + textEdit打印次数.EditValue.ToString() + "+1,LastPrintDate=getdate() where ID=" + textEditID.EditValue);
                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);
                    GetGrid();

                }
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
            catch(Exception ee)
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
            //int iRe = CheState(textEdit单据号.Text.Trim());
            //if (iRe == -1)
            //{
            //    throw new Exception("检查单据状态出错");
            //}
            //if (iRe == 0)
            //{
            //    throw new Exception("单据不存在");
            //}
            //if (iRe == 1)
            //{
            //    throw new Exception("单据未审核");
            //}
            //try
            //{
            //    gridView1.FocusedRowHandle -= 1;
            //    gridView1.FocusedRowHandle += 1;
            //}
            //catch { }
            //if (gridView2.RowCount > 0)
            //{

            //    Replist rep = new Replist();
            //    aList = new System.Collections.ArrayList();
            //    DataRow dw = rep.dsPrint.Tables["dtHead"].NewRow();
            //    dw["Column1"] = textEdit单据号.Text.Trim();
            //    dw["Column2"] = dth.Rows[0]["单据日期"].ToString();
            //    dw["Column3"] = lookUpEdit客户.Text.Trim();
            //    dw["Column4"] = lookUpEdit业务员.EditValue.ToString().Trim();
            //    dw["Column5"] = lookUpEdit部门.Text.Trim();
            //    dw["Column6"] = dth.Rows[0]["制单人"].ToString();
            //    dw["Column7"] = dth.Rows[0]["制单日期"].ToString();
            //    dw["Column8"] = lookUpEdit业务员.Text.Trim();
            //    dw["Column9"] = buttonEdit部门.EditValue.ToString();
            //    dw["Column10"] = dth.Rows[0]["iUnitPrice"].ToString();
            //    dw["Column11"] = dth.Rows[0]["iMoney"].ToString();
            //    dw["Column12"] = dth.Rows[0]["sBoxQty"].ToString();

            //    rep.dsPrint.Tables["dtHead"].Rows.Add(dw);
            //    sSQL = "select a.cInvCode,i.cInvName,sum(a.iQuantity) as iQuantity,sum(a.sBoxQty) as sBoxQty,sum(iMoney) as iMoney,sum(iMoney)/sum(a.sBoxQty) as iUnitPrice from " + tablenames + " a left join Inventory i on a.cInvCode=i.cInvCode where ID=" + iID + " group by a.cInvCode,i.cInvName order by a.cInvCode";
            //    DataTable dts = clsSQLCommond.ExecQuery(sSQL);
            //    for (int i = 0; i < dts.Rows.Count; i++)
            //    {
            //        DataRow dw1 = rep.dsPrint.Tables["dtGrid"].NewRow();

            //        dw1["Column1"] = dts.Rows[i]["cInvCode"].ToString();
            //        dw1["Column2"] = dts.Rows[i]["cInvName"].ToString();
            //        dw1["Column3"] = dts.Rows[i]["sBoxQty"].ToString();
            //        dw1["Column4"] = dts.Rows[i]["iUnitPrice"].ToString();
            //        dw1["Column5"] = dts.Rows[i]["iMoney"].ToString();
            //        rep.dsPrint.Tables["dtGrid"].Rows.Add(dw1);

            //    }
                
            //    rep.ShowPreview();

            //    aList.Add("update  " + tablename + " set PrintCount=" + textEdit打印次数.Text.Trim() + "+1,LastPrintDate=getdate() where ID=" + textEditID.Text.Trim());

            //    if (aList.Count > 0)
            //    {
            //        int iCou = clsSQLCommond.ExecSqlTran(aList);
            //        GetGrid();

            //    }
            //}
            //else
            //{
            //    throw new Exception("无出库单，打印失败");
            //}
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
            Frm销售出库单_Add frm = new Frm销售出库单_Add(单据号1, 单据号2, 单据日期1, 单据日期2, 制单日期1, 制单日期2, 业务员,
               部门, 客户1, 客户2, 审核日期1, 审核日期2, 制单人1, 制单人2, 审核人1, 审核人2, 物料1, 物料2,BoxNo,sBoxNo);
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
        }
        /// <summary>
        /// 增行 引用
        /// </summary>
        private void btnAddRow()
        {
            throw new Exception("请使用采集器出库");
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
                        }
                        else
                        {
                            sErr = sErr + "行" + (i + 1) + "已引用\n";
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
            GetGroup();
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
            throw new Exception("销售出库单请使用采集器出库");
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

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellDisplayText(i, gridColAutoID).Trim() != "")
                    {
                        string cInvCode = gridView1.GetRowCellValue(i, gridCol物料编码).ToString().Trim();
                        string cWhCode = lookUpEdit仓库.EditValue.ToString().Trim();
                        string cPosCode = gridView1.GetRowCellValue(i, gridColcPosCode).ToString().Trim();
                        string BoxNo = gridView1.GetRowCellValue(i, gridCol箱号).ToString().Trim();
                        string sBoxNo = gridView1.GetRowCellValue(i, gridCol盒号).ToString().Trim();
                        string AutoID=gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim();
                        string SoAutoID = gridView1.GetRowCellValue(i, gridCol销售订单子表ID).ToString().Trim();
                        string cSOPSID = gridView1.GetRowCellValue(i, gridCol装箱单sID).ToString().Trim();
                        decimal iQuantity = ReturnDecimal(gridView1.GetRowCellValue(i, gridCol数量).ToString().Trim());
                        decimal iNum = ReturnDecimal(gridView1.GetRowCellValue(i, gridCol件数).ToString().Trim());
                        int sBoxQty = ReturnInt(gridView1.GetRowCellValue(i, gridCol盒数).ToString().Trim());
                        int RdAutoID = ReturnInt(gridView1.GetRowCellValue(i, gridCol出入库单子表ID).ToString().Trim());

                        string M1 = gridView1.GetRowCellValue(i, gridColM1).ToString().Trim();
                        string M2 = gridView1.GetRowCellValue(i, gridColM2).ToString().Trim();
                        string M3 = gridView1.GetRowCellValue(i, gridColM3).ToString().Trim();
                        string M4 = gridView1.GetRowCellValue(i, gridColM4).ToString().Trim();
                        string M5 = gridView1.GetRowCellValue(i, gridColM5).ToString().Trim();
                        string M6 = gridView1.GetRowCellValue(i, gridColM6).ToString().Trim();
                        string M7 = gridView1.GetRowCellValue(i, gridColM7).ToString().Trim();
                        string M8 = gridView1.GetRowCellValue(i, gridColM8).ToString().Trim();
                        string M9 = gridView1.GetRowCellValue(i, gridColM9).ToString().Trim();
                        string M10 = gridView1.GetRowCellValue(i, gridColM10).ToString().Trim();
                        //现存量更新
                        //clsPublic.ReturnNow(1, AutoID, cInvCode, cWhCode, cPosCode, BoxNo, sBoxNo, M1, M2, M3, M4, M5, M6, M7, M8, M9, M10, iQuantity, iNum, sBoxQty, 0, 0, 0, aList);
                        
                        //反写成品入库单
                        sSQL = "update RdRecords03 set sOutBoxQty=isnull(sOutBoxQty,0) - 1,iOutQuantity=isnull(iOutQuantity,0) - (" + iQuantity + ") where AutoID='" + RdAutoID + "'";
                        aList.Add(sSQL);

                        //反写装箱单
                        sSQL = "update SO_SOPackingSublist set sOutBoxQty=isnull(sOutBoxQty,0) - 1,iOutQuantity=isnull(iOutQuantity,0) - (" + iQuantity + "),OutcCusCode=null,OutcPersonCode=null,OutcDepCode=null,OutDate=null,OutSoAutoID=null where sID='" + cSOPSID + "'";
                        aList.Add(sSQL);
                        //反写销售订单
                        //sSQL = "update SO_SODetails set sOutBoxQty=isnull(sOutBoxQty,0) - " + 1 + ",iOutQuantity=isnull(iOutQuantity,0) - " + 1 + " where AutoID='" + SoAutoID + "'";

                        if (SoAutoID != "")
                        {

                            sSQL = @"
update SO_SODetails set  iOutQuantity=null,sOutBoxQty=null where AutoID = '111111'
if object_id('Tempdb.dbo.#b') is not null drop table #b

select SoAutoID,SUM(iQuantity) as iQuantity,SUM(sBoxQty) as sBoxQty into #b from RdRecords13 where SoAutoID = '111111' group by SoAutoID
insert into #b select SoAutoID,SUM(iQuantity) as iQuantity,SUM(sBoxQty) as sBoxQty from RdRecords11 where SoAutoID = '111111' group by SoAutoID

update SO_SODetails set  iOutQuantity=a.iQuantity,sOutBoxQty=a.sBoxQty 
from (select SoAutoID,SUM(iQuantity) as iQuantity,SUM(sBoxQty) as sBoxQty from #b group by SoAutoID) a 
where SO_SODetails.AutoID=a.SoAutoID and SO_SODetails.AutoID = '111111'
";

                            sSQL = sSQL.Replace("111111", SoAutoID);
                            aList.Add(sSQL);
                        }
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
            

            aList = new System.Collections.ArrayList();
            DataRow drh = dt.NewRow();
            drh["ID"] = textEditID.EditValue.ToString().Trim();
            iID = Convert.ToInt64(textEditID.EditValue);
            drh[tablecode] = textEdit单据号.EditValue.ToString().Trim();
            
            drh["dDate"] = dateEdit单据日期.EditValue.ToString().Trim();

            drh["cCusCode"] = buttonEdit客户.EditValue.ToString().Trim();
            drh["cPersonCode"] = buttonEdit业务员.EditValue.ToString().Trim();
            if (lookUpEdit操作人.EditValue != null)
            {
                drh["cOperator"] = lookUpEdit操作人.EditValue.ToString().Trim();
            }
            drh["cDepCode"] = buttonEdit部门.EditValue.ToString().Trim();

            drh["cWhCode"] = lookUpEdit仓库.EditValue.ToString().Trim();
            //drh["cWhCodeOut"] = lookUpEdit转入仓库.EditValue.ToString().Trim();

            //drh["cMTCode"] = lookUpEdit委外类型.EditValue.ToString().Trim();

            drh["Flag"] = radioGroup蓝红标识.EditValue.ToString().Trim();
            drh["iType"] ="1";
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
                clsPublic.GetChange(tablename, tablenames, textEditID.EditValue.ToString().Trim(), clsGetSQL, aList);
            }
            #endregion

            #region 删行
            if (textEditDel.EditValue != null && textEditDel.EditValue.ToString().Trim() != "")
            {
                clsPublic.ReturnNow(textEditDel.EditValue.ToString().Trim(), aList);
                clsPublic.GetChangeDelRow(tablenames, textEditDel.EditValue.ToString().Trim(), aList);
                WriteOrder(textEditDel.EditValue.ToString().Trim(), aList);
            }

            #endregion

            #region 子表

            DataTable dtlist = (DataTable)gridControl2.DataSource;
           
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
                    if (gridView1.GetRowCellDisplayText(i, gridCol箱号).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + gridCol箱号.Caption + "不可为空\n";
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
                                sErr = sErr + "行" + (i + 1) + gridCol数量.Caption + "必须大于0\n";
                                continue;
                            }
                            if (ReturnDecimal(gridView1.GetRowCellValue(i, gridCol箱数)) <= 0)
                            {
                                sErr = sErr + "行" + (i + 1) + gridCol箱数.Caption + "必须大于0\n";
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

                    dr["SoAutoID"] = gridView1.GetRowCellValue(i, gridCol销售订单子表ID).ToString().Trim();
                    dr["RdAutoID"] = gridView1.GetRowCellValue(i, gridCol出入库单子表ID).ToString().Trim();
                    dr["BoxNo"] = gridView1.GetRowCellValue(i, gridCol箱号).ToString().Trim();
                    dr["BoxQty"] = gridView1.GetRowCellValue(i, gridCol箱数).ToString().Trim();
                    dr["sBoxNo"] = gridView1.GetRowCellValue(i, gridCol盒号).ToString().Trim();
                    dr["sBoxQty"] = gridView1.GetRowCellValue(i, gridCol盒数).ToString().Trim();
                    dr["cMemo"] = gridView1.GetRowCellValue(i, gridCol备注).ToString().Trim();
                    dr["UpdateDate"] = DateTime.Now.ToString();
                    dts.Rows.Add(dr);
                    #endregion

                    if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "update" )
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
                else
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

            sSQL = "select NotDelivery from Customer where cCusCode='" + lookUpEdit客户.EditValue + "'";
            DataTable dtcus = clsSQLCommond.ExecQuery(sSQL);
            if (dtcus.Rows.Count > 0 && dtcus.Rows[0]["NotDelivery"].ToString().Trim() == "True")
            {
                throw new Exception("已限制出库，请与财务联系");
            }

            aList = new System.Collections.ArrayList();

            sSQL = "update " + tablename + " set dVerifysysTime='" + GetSystemTime() + "',dVerifysysPerson='" + 系统服务.ClsBaseDataInfo.sUid + "' where ID=" + textEditID.EditValue.ToString().Trim() + "";
            aList.Add(sSQL);

            //for (int i = 0; i < gridView1.RowCount; i++)
            //{
            //    if (radioGroup蓝红标识.EditValue.ToString() == "1")
            //    {
            //        sSQL = "update SO_SOPackingSublist set S2=1 where sBoxNo='" + gridView1.GetRowCellValue(i, gridCol盒号).ToString() + "' ";
            //    }
            //    else
            //    {
            //        sSQL = "update SO_SOPackingSublist set S2=null where sBoxNo='" + gridView1.GetRowCellValue(i, gridCol盒号).ToString() + "' ";
            //    }
            //    aList.Add(sSQL);
            //}
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

            //for (int i = 0; i < gridView1.RowCount; i++)
            //{
            //    if (radioGroup蓝红标识.EditValue.ToString() == "1")
            //    {
            //        sSQL = "update SO_SOPackingSublist set S2=null where sBoxNo='" + gridView1.GetRowCellValue(i, gridCol盒号).ToString() + "' ";
            //    }
            //    else
            //    {
            //        sSQL = "update SO_SOPackingSublist set S2=1 where sBoxNo='" + gridView1.GetRowCellValue(i, gridCol盒号).ToString() + "' ";
            //    }
            //    aList.Add(sSQL);
            //}

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

            sState = "alter";
            SetEnabled(true);
        }

        #endregion

        private void Frm销售出库单_Load(object sender, EventArgs e)
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

                sSQL = @"select a.*,u1.vchrName as 制单人,u2.vchrName as 审核人,d.cDepName,c.cCusName ,p.PersonName,b.sBoxQty,b.iMoney, b.iUnitPrice,
convert(varchar(10),dCreatesysTime,120) as 制单日期,convert(varchar(10),dVerifysysTime,120) as 审核日期,convert(varchar(10),dDate,120) as 单据日期,a.cRDCode as 单据号,c.cDCCode,dc.cDCName from " + tablename + " a "
+ @"left join _UserInfo u1 on a.dCreatesysPerson=u1.vchrUid left join _UserInfo u2 on a.dVerifysysPerson=u2.vchrUid 
left join Department d on a.cDepCode=d.cDepCode left join Customer c on a.cCusCode=c.cCusCode left join DistrictClass dc on c.cDCCode=dc.cDCCode left join Person p on a.cPersonCode=p.PersonCode  
left join (select ID,sum(iQuantity) as iQuantity,sum(sBoxQty) as sBoxQty ,sum(iMoney) as iMoney,sum(iMoney)/sum(sBoxQty) as iUnitPrice from " + tablenames + " group by ID) b on a.ID=b.ID "
 + @"where  a.ID=" + iID + cSQL;

                dth = clsSQLCommond.ExecQuery(sSQL);
                
                if (dth.Rows.Count > 0)
                {
                    textEditID.EditValue = Convert.ToInt64(dth.Rows[0]["ID"]); ;
                    textEdit单据号.EditValue = dth.Rows[0]["cRDCode"].ToString();
                    buttonEdit客户.EditValue = dth.Rows[0]["cCusCode"].ToString();
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
                    buttonEdit部门.EditValue = dth.Rows[0]["cDepCode"].ToString();

                    lookUpEdit仓库.EditValue = dth.Rows[0]["cWhCode"].ToString();
                    radioGroup蓝红标识.EditValue = dth.Rows[0]["Flag"].ToString();
                    textEdit打印次数.EditValue = dth.Rows[0]["PrintCount"].ToString(); 

                    sSQL = "select a.*, 'edit' as iSave,cast(a.iQuantity as decimal(16,6)) as 历史数量,iRowNo as 行标记,cast(null as decimal(16,6)) as SumiQuantity,iRowNo as 序号,i.cInvName from " + tablenames + " a left join Inventory i on a.cInvCode=i.cInvCode where ID=" + iID + " order by iRowNo";
                    dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
                    gridControl1.DataSource = dtBingGrid;

                    sSQL = "select a.cInvCode,i.cInvName,a.M1,a.M2,sum(a.iQuantity) as iQuantity,sum(a.sBoxQty) as sBoxQty from " + tablenames + " a left join Inventory i on a.cInvCode=i.cInvCode where ID=" + iID + " group by a.cInvCode,i.cInvName,a.M1,a.M2 order by a.cInvCode";
                    DataTable dts = clsSQLCommond.ExecQuery(sSQL);


                    sSQL = @"select a.cInvCode,i.cInvName,sum(a.iQuantity) as iQuantity,sum(a.sBoxQty) as sBoxQty,sum(iMoney) as iMoney,a.iUnitPrice,sum(iMoney)/sum(a.iQuantity) as iUnitPriceQty 
                    from " + tablenames + " a left join Inventory i on a.cInvCode=i.cInvCode where ID=" + iID + " group by a.cInvCode,i.cInvName,a.iUnitPrice order by a.cInvCode";
                    DataTable dtGroup = clsSQLCommond.ExecQuery(sSQL);

                    sPrintLayOutMod = sProPath + "\\print\\Model\\销售出库单Mod.dll";
                    sPrintLayOutUser = sProPath + "\\print\\User\\销售出库单User.dll";

                    sPrintLayOutMod2 = sProPath + "\\print\\Model\\销售出库单Mod2.dll";
                    sPrintLayOutUser2 = sProPath + "\\print\\User\\销售出库单User2.dll";

                    base.dsPrint.Tables.Clear();
                    base.dsPrint.Tables.Add(dth.Copy());
                    base.dsPrint.Tables[0].TableName = "dtHead";
                    base.dsPrint.Tables.Add(dts.Copy());
                    base.dsPrint.Tables[1].TableName = "dtGrid";

                    base.dsPrint2.Tables.Clear();
                    base.dsPrint2.Tables.Add(dth.Copy());
                    base.dsPrint2.Tables[0].TableName = "dtHead";
                    base.dsPrint2.Tables.Add(dtGroup.Copy());
                    base.dsPrint2.Tables[1].TableName = "dtGrid";


                    GetGroup();
                    SetEnabled(false);

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

        private void GetGroup()
        {
            DataView dv = new DataView(dtBingGrid);
            DataTable dtgroup = dv.ToTable(true, new string[] { "cInvCode", "M1", "M2", "BoxNo" });
            dtgroup.Columns.Add("sBoxQty");
            dtgroup.Columns.Add("iQuantity");
            dtgroup.Columns.Add("cInvName");
            DataTable dtinv = 系统服务.LookUp.Inventory();
            for (int i = 0; i < dtgroup.Rows.Count; i++)
            {
                dtgroup.Rows[i]["sBoxQty"] = dtBingGrid.Compute("sum(sBoxQty)", "cInvCode='" + dtgroup.Rows[i]["cInvCode"].ToString() + "' and M1='" + dtgroup.Rows[i]["M1"].ToString() + "' and M2='" + dtgroup.Rows[i]["M2"].ToString() + "' and BoxNo='" + dtgroup.Rows[i]["BoxNo"].ToString() + "'");
                dtgroup.Rows[i]["iQuantity"] = dtBingGrid.Compute("sum(iQuantity)", "cInvCode='" + dtgroup.Rows[i]["cInvCode"].ToString() + "' and M1='" + dtgroup.Rows[i]["M1"].ToString() + "' and M2='" + dtgroup.Rows[i]["M2"].ToString() + "' and BoxNo='" + dtgroup.Rows[i]["BoxNo"].ToString() + "'");
                dtgroup.Rows[i]["cInvName"] = dtinv.Select("cInvCode='" + dtgroup.Rows[i]["cInvCode"].ToString() + "'")[0]["cInvName"];
            }
            gridControl2.DataSource = dtgroup;
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
            系统服务.LookUp.Person(lookUpEdit操作人);
            系统服务.LookUp.Position(ItemLookUpEdit货位);
            系统服务.LookUp.DistrictClass(lookUpEdit区域);

            系统服务.LookUp.ColorNo(ItemLookUpEditM1);

            系统服务.LookUp.ColorNo(ItemLookUpM1);

            系统服务.LookUp.Inventory(ItemLookUpEdit存货名称);
            ItemLookUpEdit存货名称.Properties.DisplayMember = "cInvName";
            系统服务.LookUp.Inventory(ItemLookUpEdit存货规格);
            ItemLookUpEdit存货规格.Properties.DisplayMember = "cInvStd";
            系统服务.LookUp.Inventory(ItemLookUpEdit存货代码);
            ItemLookUpEdit存货代码.Properties.DisplayMember = "cInvAddCode";

            系统服务.LookUp.Inventory(ItemLookUp存货名称);
            ItemLookUp存货名称.Properties.DisplayMember = "cInvName";

            系统服务.LookUp.SO_SODetails(ItemLookUpEdit销售订单);

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

            buttonEdit操作人.Enabled = b;

            lookUpEdit仓库.Enabled = b;
            gridView1.OptionsBehavior.Editable = b;
            gridView2.OptionsBehavior.Editable = b;

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

            if (gridView1.GetRowCellValue(iRow, gridCol行标记).ToString().Trim() == "")
            {
                gridView1.SetRowCellValue(iRow, gridCol行标记, iRow + 1);
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
                if (invocde != "")
                {
                    if (buttonEdit客户.EditValue != null && buttonEdit客户.EditValue.ToString().Trim() != "")
                    {
                        decimal price = clsPublic.PriceAdjust(invocde, buttonEdit客户.EditValue.ToString().Trim());
                        if (price != 0)
                        {
                            gridView1.SetRowCellValue(iRow, gridCol含税单价, price);
                        }
                    }

                    #region 换算率和税率
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
                    gridView1.SetRowCellValue(iRow, gridCol税率, 17);
                    #endregion
                }
            }

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
                string 行标记 = gridView1.GetRowCellValue(iRow, gridCol行标记).ToString().Trim();

                #region 计算金额
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

                //#region 子件数量
                //DataTable dtlist = (DataTable)gridControl2.DataSource;
                //DataRow[] dw = dtlist.Select("行标记='" + 行标记 + "'");
                //if (dw.Length != 0)
                //{
                //    decimal qty = 数量 / dw.Length;
                //    for (int i = 0; i < gridView2.RowCount; i++)
                //    {
                //        if (gridView2.GetRowCellValue(i, grid行标记).ToString().Trim() == 行标记)
                //        {
                //            decimal s换算率 = ReturnDecimal(gridView2.GetRowCellValue(i, grid换算率));
                //            gridView2.SetRowCellValue(i, grid数量, qty);
                //            gridView2.SetRowCellValue(i, grid件数, qty * s换算率);
                //        }
                //    }
                //}
                //#endregion
            }

            #region
            if (e.Column != gridColiSave && e.Column != gridCol行标记 && gridView1.GetRowCellDisplayText(e.RowHandle, gridColiSave).ToString().Trim() == "")
            {
                gridView1.SetRowCellValue(iRow, gridColiSave, "add");
            }
            if (e.Column != gridColiSave && e.Column != gridCol行标记 && gridView1.GetRowCellDisplayText(e.RowHandle, gridColiSave).ToString().Trim() == "edit")
            {
                gridView1.SetRowCellValue(iRow, gridColiSave, "update");
            }
            #endregion
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
                sSQL = "select  isnull(dCreatesysPerson,'') as 制单人,isnull(dVerifysysPerson,'') as 审核人,isnull(dClosesysPerson,'') as 关闭人 from " + tablename + " where cRDCode = '" + sCode + "'";
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

                    sSQL = "select count(1) from " + tablename + " a inner join " + tablenames + " b on a.id = b.id where a.cRDCode = '" + sCode + "' and isnull(cClosesysPerson,'') <> ''";
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
                sSQL = @"select count(1) from dbo.RdRecord13 a inner join dbo.RdRecords13 b on a.ID = b.ID 
                inner join (select SOOutAutoID,sum(iQuantity) as iQuantity from RdRecords13 group by SOOutAutoID) c 
                on c.SOOutAutoID = b.AutoID where a.cRDCode = '" + sCode + "'";
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
                sSQL = @"select -isnull(sum(b.iQuantity),0) as iQty from dbo."+tablenames+" where b.SOOutAutoID = '" + AutoID + "'";
                decimal iReturn1 = ReturnDecimal(clsSQLCommond.ExecGetScalar(sSQL));
                if (iReturn1 > iReturn && iReturn1 > 0)
                    iReturn = iReturn1;

                //sSQL = "select isnull(sum(c.iQuantity),0) as iQty from XWSystemDB_JSL_" + lookUpEdit客户.EditValue.ToString().Trim() + ".dbo.CustomerRdRecords " +
                //       "where jslSoAutoID = '" + AutoID + "'";
                //decimal iReturn2 = ReturnDecimal(clsSQLCommond.ExecGetScalar(sSQL));
                //if (iReturn2 > iReturn && iReturn2 > 0)
                //    iReturn = iReturn2;

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
                    sSQL = @"select isnull(b.iQuantity,0)-isnull(b.iOutQuantity,0) as iQuantity 
from SO_SOMain a left join SO_SODetails b on a.ID = b.ID 
where b.AutoID = " + 上游AutoID;
                    sSQL = sSQL.Replace("1=1", "1=1 and AutoID <> '" + AutoID + "'");
                }
                else
                {
                    sSQL = @"select -isnull(r.iQuantity,0) as iQuantity 
from SO_SOMain a left join SO_SODetails b on a.ID = b.ID 
left join (select SoAutoID,sum(isnull(iQuantity,0)) as iQuantity,sum(isnull(iNum,0)) as iNum ,sum(isnull(iNatMoney,0)) as iNatMoney ,sum(isnull(iMoney,0)) as iMoney  from RdRecords13 
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

        public void WriteOrder(string delStrs, System.Collections.ArrayList aList)
        {
            string[] delSplit = delStrs.Split(',');

            for (int i = 0; i < delSplit.Length; i++)
            {
                sSQL = "select iQuantity,iNum,sBoxQty,SoAutoID,cSOPSID,sBoxNo from RdRecords13 where AutoID=" + delSplit[i];
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    long SoAutoID = ReturnLong(dt.Rows[0]["SoAutoID"]);
                    int sBoxQty = ReturnInt(dt.Rows[0]["sBoxQty"]);
                    decimal iQuantity = ReturnDecimal(dt.Rows[0]["iQuantity"], 2);
                    decimal iNum = ReturnDecimal(dt.Rows[0]["iNum"], 2);
                    decimal cSOPSID = ReturnLong(dt.Rows[0]["cSOPSID"]);
                    sBoxNo = dt.Rows[0]["sBoxNo"].ToString();
                    //反写销售订单
                    //sSQL = @"update SO_SODetails set iOutQuantity = isnull(iOutQuantity,0) - (" + iQuantity + "),iOutNum = isnull(iOutNum,0) - (" + iNum + "),sOutBoxQty = isnull(sOutBoxQty,0) - (" + sBoxQty + ") where AutoID = " + SoAutoID;
                    sSQL = @"
update SO_SODetails set  iOutQuantity=null,sOutBoxQty=null where AutoID = 111111
if object_id('Tempdb.dbo.#b') is not null drop table #b

select SoAutoID,SUM(iQuantity) as iQuantity,SUM(sBoxQty) as sBoxQty into #b from RdRecords13 where SoAutoID = 111111 group by SoAutoID
insert into #b select SoAutoID,SUM(iQuantity) as iQuantity,SUM(sBoxQty) as sBoxQty from RdRecords11 where SoAutoID = 111111 group by SoAutoID

update SO_SODetails set  iOutQuantity=a.iQuantity,sOutBoxQty=a.sBoxQty 
from (select SoAutoID,SUM(iQuantity) as iQuantity,SUM(sBoxQty) as sBoxQty from #b group by SoAutoID) a 
where SO_SODetails.AutoID=a.SoAutoID and SO_SODetails.AutoID = 111111
";

                    sSQL = sSQL.Replace("111111", SoAutoID.ToString());

                    aList.Add(sSQL);
                    if (radioGroup蓝红标识.EditValue.ToString() == "1")
                    {
                        //反写装箱单
                        sSQL = @"update SO_SOPackingSublist set iOutQuantity = isnull(iOutQuantity,0) - (" + iQuantity + "),iOutNum = isnull(iOutNum,0) - (" + iNum + "),sOutBoxQty = isnull(sOutBoxQty,0) - (" + sBoxQty + ") where sBoxNo = '" + sBoxNo + "'";
                        aList.Add(sSQL);
                        //反写入库单
                        sSQL = @"update RdRecords03 set iOutQuantity = isnull(iOutQuantity,0) - (" + iQuantity + "),iOutNum = isnull(iOutNum,0) - (" + iNum + "),sOutBoxQty = isnull(sOutBoxQty,0) - (" + sBoxQty + ") where sBoxNo = '" + sBoxNo + "'";
                        aList.Add(sSQL);
                    }
                    else
                    {
                        //反写装箱单
                        sSQL = @"update SO_SOPackingSublist set iOutQuantity = isnull(iOutQuantity,0) + (" + iQuantity + "),iOutNum = isnull(iOutNum,0) + (" + iNum + "),sOutBoxQty = isnull(sOutBoxQty,0) + (" + sBoxQty + ") where sBoxNo = '" + sBoxNo + "'";
                        aList.Add(sSQL);
                        //反写入库单
                        sSQL = @"update RdRecords03 set iOutQuantity = isnull(iOutQuantity,0) + (" + iQuantity + "),iOutNum = isnull(iOutNum,0) + (" + iNum + "),sOutBoxQty = isnull(sOutBoxQty,0) + (" + sBoxQty + ") where sBoxNo = '" + sBoxNo + "'";
                        aList.Add(sSQL);
                    }
                }
                else
                {
                    throw new Exception("无法找到对应订单");
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

                    sSQL = "select * from Customer where cCusCode='" + lookUpEdit客户.EditValue + "'";
                    DataTable dts = clsSQLCommond.ExecQuery(sSQL);
                    if (dts.Rows.Count > 0)
                    {
                        lookUpEdit区域.EditValue = dts.Rows[0]["cDCCode"].ToString();
                    }
                }
            }
            else
            {
                buttonEdit客户.EditValue = null;
                lookUpEdit业务员.EditValue = null;
                lookUpEdit区域.EditValue = null;
            }
        }

        private void buttonEdit客户_Leave(object sender, EventArgs e)
        {
            if (buttonEdit客户.Text.Trim() != "")
                lookUpEdit客户.EditValue = buttonEdit客户.Text.Trim();
            else
                lookUpEdit客户.EditValue = null;
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
