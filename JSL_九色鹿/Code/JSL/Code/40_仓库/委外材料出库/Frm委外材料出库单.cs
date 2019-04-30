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
    public partial class Frm委外材料出库单 : 系统服务.FrmBaseInfo
    {
        string tablename = "RdRecord12";
        string tableid = "cRDCode";
        string tablenames = "RdRecords12";
        string cRsCode = "1201";

        string cSQL = "";
        string cMSCode = "";

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

        public Frm委外材料出库单(long siID)
        {
            iID = siID;
            InitializeComponent();
        }

        private void GetTitle()
        {
            string title = this.Text.Replace("委外材料出库单","");
            sSQL = "select * from MOStyle where cMSName='" + title + "'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt.Rows.Count > 0)
            {
                cSQL = " and cMSCode='" + dt.Rows[0]["cMSCode"].ToString() + "'";
                cMSCode = dt.Rows[0]["cMSCode"].ToString();
            }
        }

        public Frm委外材料出库单()
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
            Frm委外材料出库单_Add frm = new Frm委外材料出库单_Add(单据号1, 单据号2, 单据日期1, 单据日期2, 制单日期1, 制单日期2, 业务员,
               仓库,  审核日期1, 审核日期2, 制单人1, 制单人2, 审核人1, 审核人2, 物料1, 物料2);
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
                sSQL = "select min(ID) as ID from " + tablename + " where cRSCode='" + cRsCode + "'" + cSQL;
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
                    sSQL = "select ID from " + tablename + " where ID<" + iID + " and cRSCode='" + cRsCode + "'" + cSQL + " order by ID desc";
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
            if (lookUpEdit仓库.EditValue == null || lookUpEdit仓库.EditValue.ToString()=="")
            {
                throw new Exception("请选择仓库！");
            }

            Frm委外订单_New2 frm = new Frm委外订单_New2((DataTable)gridControl1.DataSource);

            frm.红蓝标志 = radioGroup蓝红标识.EditValue.ToString().Trim();
            frm.cMSCode = cMSCode;
            if (lookUpEdit供应商.EditValue != null)
            {
                frm.供应商 = lookUpEdit供应商.EditValue.ToString();
            }
            string cWhCode = "";
            if (lookUpEdit仓库.EditValue != null)
            {
                frm.cWhCode = lookUpEdit仓库.EditValue.ToString();
            }
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
                    string[] split = dtnew.Rows[s]["RdAutoIDList"].ToString().Split('|');
                    for (int j = 0; j < split.Length; j++)
                    {
                        string[] split_2 = split[j].Split(':');

                        gridView1.FocusedRowHandle = gridView1.RowCount - 1;
                        i = gridView1.RowCount - 1;
                        //bool b表已引用 = false;
                        //for (int ii = 0; ii < gridView1.RowCount; ii++)
                        //{
                        //    if (gridView1.GetRowCellValue(ii, gridCol委外订单材料表ID).ToString().Trim() == dtnew.Rows[s]["sID"].ToString().Trim())
                        //    {
                        //        b表已引用 = true;
                        //        break;
                        //    }
                        //}
                        //if (b表已引用)
                        //    continue;

                        gridView1.SetRowCellValue(i, gridCol历史数量, split_2[5]);
                        gridView1.SetRowCellValue(i, gridCol委外订单材料表ID, dtnew.Rows[s]["sID"].ToString());
                        gridView1.SetRowCellValue(i, gridCol出入库单子表ID, split_2[0]);
                        gridView1.SetRowCellValue(i, gridCol委外订单子表ID, dtnew.Rows[s]["AutoID"].ToString());
                        gridView1.SetRowCellValue(i, gridCol物料编码, dtnew.Rows[s]["cInvCode"].ToString());
                        gridView1.SetRowCellValue(i, gridColcPosCode, split_2[2]);

                        gridView1.SetRowCellValue(i, gridCol数量, split_2[5]);
                        if (dtnew.Rows[s]["iNum"].ToString() != "")
                        {
                            gridView1.SetRowCellValue(i, gridCol件数, dtnew.Rows[s]["iNum"].ToString());
                        }
                        if (dtnew.Rows[s]["iChangRate"].ToString() != "")
                        {
                            gridView1.SetRowCellValue(i, gridCol换算率, dtnew.Rows[s]["iChangRate"].ToString());
                        }
                        
                        gridView1.SetRowCellValue(i, gridColM1, dtnew.Rows[s]["M1"].ToString());
                        gridView1.SetRowCellValue(i, gridColM2, split_2[4]);
                    }
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
                if (iCodeUsed(Convert.ToInt64(gridView1.GetRowCellValue(iRow, gridCol委外订单材料表ID)), lAutoid, out d上游, out d累计, out d引用) == -1)
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
            gridCol出入库单子表ID.OptionsColumn.AllowEdit = true;
            //btnAddRow();

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
            gridCol出入库单子表ID.OptionsColumn.AllowEdit = false;
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
            aList = new System.Collections.ArrayList();
            DialogResult result = MessageBox.Show("是否删除?", "删除提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                
//                string RdAutoIDList = "";
//                for (int i = 0; i < gridView1.RowCount; i++)
//                {
//                    if (gridView1.GetRowCellValue(i, gridCol出入库单子表ID) != null)
//                    {
//                        string RdAutoID = gridView1.GetRowCellValue(i, gridCol出入库单子表ID).ToString().Trim();
//                        if (RdAutoID != "")
//                        {
//                            if (RdAutoIDList != "")
//                            {
//                                RdAutoIDList = RdAutoIDList + ",";
//                            }
//                            RdAutoIDList = RdAutoIDList + RdAutoID;
//                        }
//                    }
//                }
//                sSQL = @"
//if object_id('Tempdb.dbo.#a') is not null drop table #a
//declare @ID VARCHAR(50)
//SET @ID = 111111
//
//select b.MOsID 
//into #a
//from RdRecords12 b inner join RdRecord12 a on a.id = b.id where a.ID = @ID
//
//delete RdRecords12 where ID = @ID
//
//delete RdRecord12 where ID = @ID
//
//declare @iQty decimal(16,6)
//declare @iNum decimal(16,6)
//select @iQty = SUM(b.iQuantity) ,@iNum = sum(b.iNum) 
//from RdRecords12 b inner join RdRecord12 a on a.id = b.id
//where b.MOsID in (select MOsID from #a) 
//group by b.MOsID
//
//update MO_MOSublist set iOutQuantity=@iQty,iOutNum = @iNum
//where MO_MOSublist.sID in (select MOsID from #a) 
//
//update  MO_MODetails set iOutQuantity=@iQty,iOutNum =@iNum
//where MO_MODetails.autoid  in (select b.AutoID from #a a inner join MO_MOSublist b on a.MOsID = b.sID) 
//
//";
//                sSQL = sSQL.Replace("111111", textEditID.Text.Trim());
//                aList.Add(sSQL);
//                string[] splitlist = RdAutoIDList.Split(',');
//                for (int i = 0; i < splitlist.Length; i++)
//                {
//                    sSQL = @"
//if object_id('Tempdb.dbo.#c') is not null drop table #c
//select RdAutoID,iQuantity into #c from RdRecords11 where RdAutoID=111111 
//insert into #c select RdAutoID,iQuantity from RdRecords12 where RdAutoID=111111 
//insert into #c select RdAutoID,iQuantity from RdRecords13 where RdAutoID=111111 
//insert into #c select RdAutoID,iQuantity from RdRecords15 where RdAutoID=111111 
//
//insert into #c select RdAutoID,-iQuantity from RdRecords01 where RdAutoID=111111 and iQuantity<0 
//insert into #c select RdAutoID,-iQuantity from RdRecords02 where RdAutoID=111111 and iQuantity<0 
//insert into #c select RdAutoID,-iQuantity from RdRecords03 where RdAutoID=111111 and iQuantity<0 
//insert into #c select RdAutoID,-iQuantity from RdRecords05 where RdAutoID=111111 and iQuantity<0 
//
//update RdRecords01 set iOutQuantity=a.iQuantity from (select RdAutoID,sum(iQuantity) as iQuantity from #c group by RdAutoID) a where RdRecords01.AutoID=a.RdAutoID
//update RdRecords02 set iOutQuantity=a.iQuantity from (select RdAutoID,sum(iQuantity) as iQuantity from #c group by RdAutoID) a where RdRecords02.AutoID=a.RdAutoID
//update RdRecords03 set iOutQuantity=a.iQuantity from (select RdAutoID,sum(iQuantity) as iQuantity from #c group by RdAutoID) a where RdRecords03.AutoID=a.RdAutoID
//update RdRecords05 set iOutQuantity=a.iQuantity from (select RdAutoID,sum(iQuantity) as iQuantity from #c group by RdAutoID) a where RdRecords05.AutoID=a.RdAutoID
//";
//                    sSQL = sSQL.Replace("111111", splitlist[i]);
//                    aList.Add(sSQL);
//                }
                sSQL = @"delete RdRecords12 where ID = 111111
                delete RdRecord12 where ID = 111111";
                sSQL = sSQL.Replace("111111", textEditID.EditValue.ToString());
                aList.Add(sSQL);
                
                sSQL = "select RdAutoID,MosID from " + tablenames + " where ID=" + textEditID.EditValue.ToString();
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string RdAutoID = dt.Rows[i]["RdAutoID"].ToString();
                    if (RdAutoID != "")
                    {
                        aList.Add(clsPublic.ReturnWriteRdAutoID(RdAutoID));
                    }

                    string MosID = dt.Rows[i]["MosID"].ToString();
                    if (MosID != "")
                    {
                        aList.Add(clsPublic.ReturnWriteRdAutoID(MosID));
                    }
                }

                int iCou = clsSQLCommond.ExecSqlTran(aList);

                if (iCou > 0)
                {
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
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
                gridView1.FocusedColumn = gridCol序号;
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
                iID = clsPublic.GetMaxID("RD");
                drh["ID"] = iID;
                drh["cRDCode"] = clsPublic.GetMaxCode("cRdCode");
                textEdit单据号.EditValue = drh["cRDCode"].ToString();
            }
            else
            {
                drh["ID"] = textEditID.Text;
                iID = Convert.ToInt64(textEditID.Text);
                drh["cRDCode"] = textEdit单据号.EditValue.ToString().Trim();
            }
            drh["dDate"] = dateEdit单据日期.EditValue.ToString().Trim();
            drh["cVenCode"] = lookUpEdit供应商.EditValue.ToString().Trim();
            drh["cPersonCode"] = buttonEdit业务员.Text.Trim();
            if (lookUpEdit操作人.EditValue != null)
            {
                drh["cOperator"] = lookUpEdit操作人.EditValue.ToString().Trim();
            }
            drh["cWhCode"] = lookUpEdit仓库.EditValue.ToString().Trim();
            drh["cRdPersonCode"] = buttonEdit收货人.Text.Trim();
            drh["cDepCode"] = buttonEdit部门.Text.Trim();
            drh["cRSCode"] = cRsCode;
            drh["cMSCode"] = cMSCode;
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
                clsPublic.GetChange(tablename, tablenames, textEditID.EditValue.ToString().Trim(), clsGetSQL, aList);
            }
            #endregion

            #region 删行
            string strDelRdAutoID = "";
            string strDelMosID = "";
            if (textEditDel.EditValue != null && textEditDel.EditValue.ToString().Trim() != "")
            {
                string[] split = textEditDel.EditValue.ToString().Trim().Split(',');
                for (int i = 0; i < split.Length; i++)
                {
                    sSQL = "select RdAutoID from " + tablenames + " where AutoID=" + split[i];
                    string RdAutoID = clsSQLCommond.ExecGetScalar(sSQL).ToString();
                    if (strDelRdAutoID != "")
                    {
                        strDelRdAutoID = strDelRdAutoID + ",";
                    }
                    strDelRdAutoID = strDelRdAutoID + RdAutoID;
                    
                    sSQL = "select MosID from " + tablenames + " where AutoID=" + split[i];
                    string MosID = clsSQLCommond.ExecGetScalar(sSQL).ToString();
                    if (MosID != "")
                    {
                        if (strDelMosID != "")
                        {
                            strDelMosID = strDelMosID + ",";
                        }
                        strDelMosID = strDelMosID + RdAutoID;
                    }
                }
                clsPublic.ReturnNow(textEditDel.EditValue.ToString().Trim(), aList);
                clsPublic.GetChangeDelRow(tablenames, textEditDel.EditValue.ToString().Trim(), aList);//删除行

                //WriteOrder(textEditDel.EditValue.ToString().Trim(), aList);
//                string[] splitlist = RdAutoIDList.Split(',');
//                for (int i = 0; i < splitlist.Length; i++)
//                {
//                    sSQL = @"
//if object_id('Tempdb.dbo.#c') is not null drop table #c
//select RdAutoID,iQuantity into #c from RdRecords11 where RdAutoID=111111 
//insert into #c select RdAutoID,iQuantity from RdRecords12 where RdAutoID=111111 
//insert into #c select RdAutoID,iQuantity from RdRecords13 where RdAutoID=111111 
//insert into #c select RdAutoID,iQuantity from RdRecords15 where RdAutoID=111111 
//
//insert into #c select RdAutoID,-iQuantity from RdRecords01 where RdAutoID=111111 and iQuantity<0 
//insert into #c select RdAutoID,-iQuantity from RdRecords02 where RdAutoID=111111 and iQuantity<0 
//insert into #c select RdAutoID,-iQuantity from RdRecords03 where RdAutoID=111111 and iQuantity<0 
//insert into #c select RdAutoID,-iQuantity from RdRecords05 where RdAutoID=111111 and iQuantity<0 
//
//update RdRecords01 set iOutQuantity=a.iQuantity from (select RdAutoID,sum(iQuantity) as iQuantity from #c group by RdAutoID) a where RdRecords01.AutoID=a.RdAutoID
//update RdRecords02 set iOutQuantity=a.iQuantity from (select RdAutoID,sum(iQuantity) as iQuantity from #c group by RdAutoID) a where RdRecords02.AutoID=a.RdAutoID
//update RdRecords03 set iOutQuantity=a.iQuantity from (select RdAutoID,sum(iQuantity) as iQuantity from #c group by RdAutoID) a where RdRecords03.AutoID=a.RdAutoID
//update RdRecords05 set iOutQuantity=a.iQuantity from (select RdAutoID,sum(iQuantity) as iQuantity from #c group by RdAutoID) a where RdRecords05.AutoID=a.RdAutoID
//";
//                    sSQL = sSQL.Replace("111111", splitlist[i]);
//                    aList.Add(sSQL);
                //}
            }
            #endregion

            #region 子表
            
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

                decimal d出库数量 = Convert.ToDecimal(gridView1.GetRowCellValue(i, gridCol数量));

                bHasGrid = true;
                if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "update" || gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "add" || gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "alter")
                {
                    #region 判断

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
                    if (gridView1.GetRowCellValue(i, gridCol出入库单子表ID) == null || gridView1.GetRowCellValue(i, gridCol出入库单子表ID).ToString() == "")
                    {
                        sErr = sErr + "行" + (i + 1) +  "请选择入库单\n";
                    }
                    decimal d上游 = 0;
                    decimal d累计 = 0;
                    decimal d引用 = 0;
                    long lAutoid = -1;
                    if (gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim() != "")
                    {
                        lAutoid = Convert.ToInt64(gridView1.GetRowCellValue(i, gridColAutoID));
                    }
                    if (iCodeUsed(Convert.ToInt64(gridView1.GetRowCellValue(i, gridCol委外订单材料表ID)), lAutoid, out d上游, out d累计, out d引用) == -1)
                    {
                        sErr = sErr + "行" + (i + 1) + "获得引用信息失败\n";
                        continue;
                    }
                    else
                    {
                        if (radioGroup蓝红标识.EditValue.ToString().Trim() == "1")
                        {
                            if (d累计 + Convert.ToDecimal(gridView1.GetRowCellValue(i, gridCol数量)) > d上游)
                            {
                                sErr = sErr + "行" + (i + 1) + "数量超出采购订单剩余数量\n";
                                continue;
                            }
                            if (d累计 + Convert.ToDecimal(gridView1.GetRowCellValue(i, gridCol数量)) < d引用)
                            {
                                sErr = sErr + "行" + (i + 1) + "累计下单数量低于引用数量\n";
                                continue;
                            }
                        }
                        if (radioGroup蓝红标识.EditValue.ToString().Trim() == "2")
                        {
                            if (d累计 < Convert.ToDecimal(gridView1.GetRowCellValue(i, gridCol数量)))
                            {
                                sErr = sErr + "行" + (i + 1) + "红字数量超出累计下单数量\n";
                                continue;
                            }
                            if (d累计 + Convert.ToDecimal(gridView1.GetRowCellValue(i, gridCol数量)) < d引用)
                            {
                                sErr = sErr + "行" + (i + 1) + "累计下单数量低于引用数量\n";
                                continue;
                            }
                        }
                    }

                    sSQL = "";
                    #endregion

                    #region 生成table
                    DataRow dr = dts.NewRow();
                    if (gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim() == "")
                    {
                        long sID = clsPublic.GetMaxID("RDS");
                        dr["AutoID"] = sID;
                    }
                    else
                    {
                        dr["AutoID"] = gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim();
                    }
                    dr["ID"] = iID;
                    dr["cRDCode"] = textEdit单据号.EditValue.ToString().Trim();
                    dr["iRowNo"] = gridView1.GetRowCellValue(i, gridCol序号).ToString().Trim();
                    dr["MOsID"] = gridView1.GetRowCellValue(i, gridCol委外订单材料表ID).ToString().Trim();
                    dr["MOAutoID"] = gridView1.GetRowCellValue(i, gridCol委外订单子表ID).ToString().Trim();
                    if (gridView1.GetRowCellValue(i, gridCol出入库单子表ID) != null && gridView1.GetRowCellValue(i, gridCol出入库单子表ID).ToString() != "")
                    {
                        dr["RdAutoID"] = gridView1.GetRowCellValue(i, gridCol出入库单子表ID).ToString().Trim();
                    }
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
                    if (gridView1.GetRowCellValue(i, gridCol换算率) != null && gridView1.GetRowCellValue(i, gridCol换算率).ToString().Trim() != "")
                    {
                        dr["iChangRate"] = gridView1.GetRowCellValue(i, gridCol换算率).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol税额) != null && gridView1.GetRowCellValue(i, gridCol税额).ToString().Trim() != "")
                    {
                        dr["iNatTax"] = gridView1.GetRowCellValue(i, gridCol税额).ToString().Trim();
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

                    if (gridView1.GetRowCellValue(i, gridCol绞数) != null && gridView1.GetRowCellValue(i, gridCol绞数).ToString().Trim() != "")
                    {
                        dr["D1"] = gridView1.GetRowCellValue(i, gridCol绞数).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol绞重) != null && gridView1.GetRowCellValue(i, gridCol绞重).ToString().Trim() != "")
                    {
                        dr["D2"] = gridView1.GetRowCellValue(i, gridCol绞重).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol称重) != null && gridView1.GetRowCellValue(i, gridCol称重).ToString().Trim() != "")
                    {
                        dr["D3"] = gridView1.GetRowCellValue(i, gridCol称重).ToString().Trim();
                    }

                    if (gridView1.GetRowCellValue(i, gridCol发出件数) != null && gridView1.GetRowCellValue(i, gridCol发出件数).ToString().Trim() != "")
                    {
                        dr["D14"] = gridView1.GetRowCellValue(i, gridCol发出件数).ToString().Trim();
                    }
                   
                    dr["cMemo"] = gridView1.GetRowCellValue(i, gridCol备注).ToString().Trim();


                    //dr["cClosesysPerson"] = gridView1.GetRowCellValue(i, gridCol行关闭人).ToString().Trim();
                    //dr["cClosesysTime"] = gridView1.GetRowCellValue(i, gridCol行关闭日期).ToString().Trim();
                    dr["UpdateDate"] = DateTime.Now.ToString();
                    dts.Rows.Add(dr);
                    //sID = sID + 1;
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

                    clsPublic.ReturnNow(1, gridView1.GetRowCellValue(i, gridCol物料编码).ToString().Trim(), lookUpEdit仓库.EditValue.ToString().Trim(), gridView1.GetRowCellValue(i, gridColcPosCode).ToString().Trim()
                        , "", "", gridView1.GetRowCellValue(i, gridCol出入库单子表ID).ToString().Trim()
                        , gridView1.GetRowCellValue(i, gridColM1).ToString().Trim(), gridView1.GetRowCellValue(i, gridColM2).ToString().Trim(), "", "", ""
                        , "", "", "", "", ""
                        , ReturnDecimal(gridView1.GetRowCellValue(i, gridCol历史数量).ToString().Trim(), 6), 0, 0, ReturnDecimal(gridView1.GetRowCellValue(i, gridCol数量).ToString().Trim(), 6), 0, 0, aList);

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
                }
            }

            #region 单据反写
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string RdAutoID = gridView1.GetRowCellValue(i, gridCol出入库单子表ID).ToString().Trim();
                if (RdAutoID != "")
                {
                    aList.Add(clsPublic.ReturnWriteRdAutoID(RdAutoID));
                }

                string MosID = gridView1.GetRowCellValue(i, gridCol委外订单材料表ID).ToString().Trim();
                if (MosID != "")
                {
                    aList.Add(clsPublic.ReturnWriteMosID(MosID));
                }
            }

            string[] splstrDelAutoID = strDelRdAutoID.Split(',');
            for (int i = 0; i < splstrDelAutoID.Length; i++)
            {
                string RdAutoID = splstrDelAutoID[i];
                if (RdAutoID != "")
                {
                    aList.Add(clsPublic.ReturnWriteRdAutoID(RdAutoID));
                } 
            }

            string[] splitstrDelMosID = strDelMosID.Split(',');
            for (int i = 0; i < splitstrDelMosID.Length; i++)
            {
                string MosID = splitstrDelMosID[i];
                if (MosID != "")
                {
                    aList.Add(clsPublic.ReturnWriteMosID(MosID));
                }
            }
            #endregion

            //            //回写上游单据
//            if(sState == "edit")
//            {
//                sSQL = @"
//select b.MOsID 
//from RdRecords12 b inner join RdRecord12 a on a.id = b.id 
//where a.ID = 111111 
//";
//                sSQL = sSQL.Replace("111111", textEditID.Text.Trim());
//                DataTable dt委外订单子表ID = clsSQLCommond.ExecQuery(sSQL);

//                for (int i = 0; i < dt委外订单子表ID.Rows.Count; i++)
//                {
//                    sSQL = @"
//
//declare @iQty decimal(16,6)
//declare @iNum decimal(16,6)
//
//select @iQty = SUM(b.iQuantity),@iNum = sum(b.iNum)
//from RdRecords12 b inner join RdRecord12 a on a.id = b.id
//where b.MOsID  = 222222 
//group by b.MOsID
//
//update MO_MOSublist set iOutQuantity=@iQty,iOutNum = @iNum
//where MO_MOSublist.sID = 222222
//";
//                    sSQL = sSQL.Replace("222222", dt委外订单子表ID.Rows[i]["MOsID"].ToString().Trim());
//                    aList.Add(sSQL);
//                }
//            }
//            else
//            {
//                for (int i = 0; i < gridView1.RowCount; i++)
//                {
//                    string sID = gridView1.GetRowCellValue(i, gridCol委外订单材料表ID).ToString().Trim();
//                    if(sID == "")
//                        continue; 

//                    sSQL = @"
//
//declare @iQty decimal(16,6)
//declare @iNum decimal(16,6)
//
//select @iQty = SUM(b.iQuantity),@iNum = sum(b.iNum)
//from RdRecords12 b inner join RdRecord12 a on a.id = b.id
//where b.MOsID  = 222222 
//group by b.MOsID
//
//update MO_MOSublist set iOutQuantity=@iQty,iOutNum = @iNum
//where MO_MOSublist.sID = 222222
//";

//                    sSQL = sSQL.Replace("222222", sID);
//                    aList.Add(sSQL);
//                }
//            }
//            aList.Add(sSQL);

            //控制0出库

            
//            if (radioGroup蓝红标识.EditValue.ToString().Trim() == "1")
//            {
//                for (int i = 0; i < gridView1.RowCount; i++)
//                {
//                    if (gridView1.GetRowCellValue(i, gridCol出入库单子表ID) == null || gridView1.GetRowCellValue(i, gridCol出入库单子表ID).ToString().Trim()=="")
//                        continue;
//                    string RdAutoID = gridView1.GetRowCellValue(i, gridCol出入库单子表ID).ToString().Trim();
//                    string sSQLCurr = @"
//select iQuantity-isnull(iOutQuantity,0) as iQuantity,sBoxQty as sBoxQty
//into #CurrQty 
//from RdRecord01 a inner join RdRecords01 b on a.ID=b.ID where 1=1 and dVerifysysPerson is not null 
//
//insert into #CurrQty select iQuantity-isnull(iOutQuantity,0) as iQuantity,sBoxQty as sBoxQty
//from RdRecord02 a inner join RdRecords02 b on a.ID=b.ID where 1=1 and dVerifysysPerson is not null 
//
//insert into #CurrQty select iQuantity-isnull(iOutQuantity,0) as iQuantity,sBoxQty-isnull(sOutBoxQty,0) as sBoxQty
//from RdRecord03 a inner join RdRecords03 b on a.ID=b.ID where 1=1 and dVerifysysPerson is not null 
//
//insert into #CurrQty select iQuantity-isnull(iOutQuantity,0) as iQuantity,sBoxQty-isnull(sOutBoxQty,0) as sBoxQty
//from RdRecord05 a inner join RdRecords05 b on a.ID=b.ID where 1=1 and dVerifysysPerson is not null 
//
//insert into #CurrQty select -iQuantity-isnull(iOutQuantity,0) as iQuantity,sBoxQty as sBoxQty
//from RdRecord11 a inner join RdRecords11 b on a.ID=b.ID where 1=1 and dVerifysysPerson is not null 
//
//insert into #CurrQty select -iQuantity-isnull(iOutQuantity,0) as iQuantity,sBoxQty as sBoxQty
//from RdRecord12 a inner join RdRecords12 b on a.ID=b.ID where 1=1 and dVerifysysPerson is not null 
//
//insert into #CurrQty select -iQuantity-isnull(iOutQuantity,0) as iQuantity,sBoxQty-isnull(sOutBoxQty,0) as sBoxQty
//from RdRecord13 a inner join RdRecords13 b on a.ID=b.ID where 1=1 and dVerifysysPerson is not null 
//
//insert into #CurrQty select -iQuantity-isnull(iOutQuantity,0) as iQuantity,sBoxQty-isnull(sOutBoxQty,0) as sBoxQty
//from RdRecord15 a inner join RdRecords15 b on a.ID=b.ID where 1=1 and dVerifysysPerson is not null 
//
//select * from #CurrQty
//";
//                    sSQLCurr = sSQLCurr.Replace("1=1", "1=1 and AutoID = '" + RdAutoID + "'");
//                    DataTable dtCurr = clsSQLCommond.ExecQuery(sSQLCurr);
//                    decimal dCurrQty = 0;
//                    if (dtCurr != null && dtCurr.Rows.Count > 0)
//                    {
//                        dCurrQty = Convert.ToDecimal(dtCurr.Rows[0]["iQuantity"]);
//                    }
//                    decimal d2 = 0;
//                    if (gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim() != "")
//                    {
//                        sSQL = @"
//select * from 222222 where autoid = 111111
//";
//                        sSQL = sSQL.Replace("222222", tablenames);
//                        sSQL = sSQL.Replace("111111", gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim());
//                        DataTable dtTemp = clsSQLCommond.ExecQuery(sSQL);
                        
//                        if (dtTemp != null && dtTemp.Rows.Count > 0)
//                        {
//                            d2 = Convert.ToDecimal(dtTemp.Rows[0]["iQuantity"]);
//                        }
//                    }
//                    dCurrQty = dCurrQty + d2;

//                    decimal dQty = Convert.ToDecimal(gridView1.GetRowCellValue(i, gridCol数量));
//                    if (dCurrQty < dQty)
//                    {
//                        sErr = sErr + "行" + (i + 1).ToString() + " 现存量不足\n";
//                    }

//                }
//            }
             

            #endregion
            if (sErr != "")
            {
                clsPublic.SetMaxID();
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
            gridCol出入库单子表ID.OptionsColumn.AllowEdit = false;
        }

        #endregion

        private void Frm委外材料出库单_Load(object sender, EventArgs e)
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

        private void GetGrid()
        {
            if (iID != -1)
            {
                sSQL = @"select a.*,u1.vchrName as 制单人,u2.vchrName as 审核人,d.cDepName,v.cVenName ,p1.PersonName,p2.PersonName as 收货人,
b.数量,b.绞数,b.件数,cVenName,convert(decimal(18, 6),null) as 历史数量,
convert(varchar(10),dCreatesysTime,120) as 制单日期,convert(varchar(10),dVerifysysTime,120) as 审核日期,convert(varchar(10),dDate,120) as 单据日期,'" + this.Text+"' as title  from " + tablename + " a "
+ @"left join _UserInfo u1 on a.dCreatesysPerson=u1.vchrUid left join _UserInfo u2 on a.dVerifysysPerson=u2.vchrUid 
left join Department d on a.cDepCode=d.cDepCode left join Vendor v on a.cVenCode=v.cVenCode left join Person p1 on a.cPersonCode=p1.PersonCode left join Person p2 on a.cRdPersonCode=p2.PersonCode 
left join (select ID,sum(iQuantity) as 数量,sum(D1) as 绞数,sum(D14) as 件数 from  " + tablenames + " group by ID) b on a.ID=b.ID where cRSCode='" + cRsCode + "' and a.ID=" + iID;
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
                    sSQL = @"
select a.*, 'edit' as iSave,a.iQuantity as 历史数量,cast(null as decimal(16,6)) as 引用量,cast(null as decimal(16,6)) as 累计下单数量
    ,cast(null as decimal(16,6)) as 上游单据数量,i.cInvName 
	,c.M1 as 订单色号
from " + tablenames + " a left join Inventory i on a.cInvCode=i.cInvCode left join MO_MODetails c on a.MOAutoID = c.AutoID where a.ID=" + iID;


                    dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
                    gridControl1.DataSource = dtBingGrid;

                    sPrintLayOutMod = sProPath + "\\print\\Model\\委外材料出库单Mod.dll";
                    sPrintLayOutUser = sProPath + "\\print\\User\\委外材料出库单User.dll";

                    base.dsPrint.Tables.Clear();
                    base.dsPrint.Tables.Add(dt.Copy());
                    base.dsPrint.Tables[0].TableName = "dtHead";
                    base.dsPrint.Tables.Add(dtBingGrid.Copy());
                    base.dsPrint.Tables[1].TableName = "dtGrid";

                    gridView1.FocusedRowHandle = iFocRow;
                    gridView1.AddNewRow();
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
                if (gridView1.GetRowCellValue(e.RowHandle, gridCol序号).ToString().Trim() == "")
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridCol序号, e.RowHandle + 1);
                }

                if (e.Column == gridCol物料编码 || e.Column == gridCol物料名称 || e.Column == gridCol规格型号)
                {
                    if (e.Column == gridCol物料编码)
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridCol物料名称, gridView1.GetRowCellValue(e.RowHandle, gridCol物料编码).ToString().Trim());
                        gridView1.SetRowCellValue(e.RowHandle, gridCol规格型号, gridView1.GetRowCellValue(e.RowHandle, gridCol物料编码).ToString().Trim());
                        gridView1.SetRowCellValue(e.RowHandle, gridCol税率, 17);
                    }
                    string invocde = gridView1.GetRowCellValue(e.RowHandle, gridCol物料编码).ToString().Trim();
                    sSQL = "select 换算率 from Inventory where cInvCode='" + invocde + "'";
                    decimal d换算率 = ReturnDecimal(clsSQLCommond.ExecGetScalar(sSQL));
                    if (d换算率 > 0)
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridCol换算率, d换算率);
                    }
                    else
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridCol换算率, null);
                    }
                }

                #region 换算率
                if (e.Column == gridCol数量 || e.Column == gridCol换算率)
                {
                    if (gridView1.GetRowCellValue(e.RowHandle, gridCol换算率).ToString().Trim() != "")
                    {
                        decimal 换算率 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol换算率));
                        decimal 数量 = 0;
                        if (gridView1.GetRowCellValue(e.RowHandle, gridCol数量).ToString().Trim() != "")
                        {
                            数量 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol数量));
                        }
                        if (数量 == 0)
                        {
                            gridView1.SetRowCellValue(e.RowHandle, gridCol件数, null);
                        }
                        else
                        {
                            gridView1.SetRowCellValue(e.RowHandle, gridCol件数, ReturnDecimal(数量 * 换算率));
                        }

                    }
                    else
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridCol件数, null);
                    }

                }
                #endregion

                if (e.Column == gridCol数量 || e.Column == gridCol件数 || e.Column == gridCol税率 || e.Column == gridCol税额 || e.Column == gridCol含税单价 || e.Column == gridCol含税金额
                    || e.Column == gridCol无税单价 || e.Column == gridCol无税金额)
                {
                    decimal 数量 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol数量));
                    decimal 历史数量 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol历史数量));
                    decimal 件数 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol件数));
                    decimal 税率 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol税率)) / 100;
                    decimal 税额 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol税额));
                    decimal 换算率 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol换算率));
                    decimal 含税单价 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol含税单价));
                    decimal 含税金额 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol含税金额));
                    decimal 无税单价 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol无税单价));
                    decimal 无税金额 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol无税金额));

                    #region 计算
                    if (e.Column == gridCol数量)
                    {
                        if (换算率 != 0)
                        {
                            gridView1.SetRowCellValue(e.RowHandle, gridCol件数, ReturnDecimal(数量 * 换算率));
                        }
                        else
                        {
                            gridView1.SetRowCellValue(e.RowHandle, gridCol件数, null);
                        }
                        if (数量 != 历史数量)
                        {
                            decimal d上游 = 0;
                            decimal d累计 = 0;
                            decimal d引用 = 0;
                            long lAutoid = -1;
                            if (gridView1.GetRowCellValue(e.RowHandle, gridColAutoID).ToString().Trim() != "")
                            {
                                lAutoid = Convert.ToInt64(gridView1.GetRowCellValue(e.RowHandle, gridColAutoID));
                            }
                            if (iCodeUsed(Convert.ToInt64(gridView1.GetRowCellValue(e.RowHandle, gridCol委外订单材料表ID)), lAutoid, out d上游, out d累计, out d引用) == -1)
                            {
                                gridView1.SetRowCellValue(e.RowHandle, gridCol数量, gridView1.GetRowCellValue(e.RowHandle, gridCol历史数量));
                                MessageBox.Show("获得引用信息失败");
                            }
                            else
                            {
                                if (数量 == 0)
                                {
                                    gridView1.SetRowCellValue(e.RowHandle, gridCol数量, gridView1.GetRowCellValue(e.RowHandle, gridCol历史数量));
                                    MessageBox.Show("数量不能为0");
                                }

                                if (radioGroup蓝红标识.EditValue.ToString().Trim() == "1")
                                {
                                    if (数量 + d累计 > d上游)
                                    {
                                        gridView1.SetRowCellValue(e.RowHandle, gridCol数量, gridView1.GetRowCellValue(e.RowHandle, gridCol历史数量));
                                        MessageBox.Show("累计下单数量超出订单数量，订单可下出库量为" + (d上游 - d累计).ToString());
                                    }
                                    else
                                    {
                                        if (数量 + d累计 < d引用)
                                        {
                                            gridView1.SetRowCellValue(e.RowHandle, gridCol数量, gridView1.GetRowCellValue(e.RowHandle, gridCol历史数量));
                                            MessageBox.Show("累计下单数量低于已引用数量");
                                        }
                                    }
                                }
                                if (radioGroup蓝红标识.EditValue.ToString().Trim() == "2")
                                {
                                    if (数量 > d累计)
                                    {
                                        gridView1.SetRowCellValue(e.RowHandle, gridCol数量, gridView1.GetRowCellValue(e.RowHandle, gridCol历史数量));
                                        MessageBox.Show("红字数量超出累计下单数量");
                                        return;
                                    }
                                    if (数量 + d累计 < d引用)
                                    {
                                        gridView1.SetRowCellValue(e.RowHandle, gridCol数量, gridView1.GetRowCellValue(e.RowHandle, gridCol历史数量));
                                        MessageBox.Show("累计下单数量低于已引用数量");
                                        return;
                                    }
                                }
                                if (radioGroup蓝红标识.EditValue.ToString().Trim() == "1" && 数量 < 0)
                                {
                                    gridView1.SetRowCellValue(e.RowHandle, gridCol数量, gridView1.GetRowCellValue(e.RowHandle, gridCol历史数量));
                                    MessageBox.Show("蓝字数量不能小于0");
                                }
                                if (radioGroup蓝红标识.EditValue.ToString().Trim() == "2" && 数量 > 0)
                                {
                                    gridView1.SetRowCellValue(e.RowHandle, gridCol数量, gridView1.GetRowCellValue(e.RowHandle, gridCol历史数量));
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

                        gridView1.SetRowCellValue(e.RowHandle, gridCol无税单价, 无税单价);
                        gridView1.SetRowCellValue(e.RowHandle, gridCol无税金额, 无税金额);
                        gridView1.SetRowCellValue(e.RowHandle, gridCol含税金额, 含税金额);
                        gridView1.SetRowCellValue(e.RowHandle, gridCol税额, 税额);
                    }
                    if (e.Column == gridCol含税金额 && 数量 != 0)
                    {
                        含税单价 = ReturnDecimal(含税金额 / 数量);
                    }


                    #endregion

                }
                if (gridView1.GetRowCellValue(e.RowHandle, gridCol出入库单子表ID).ToString() == "")
                {
                    gridCol出入库单子表ID.OptionsColumn.AllowEdit = true;
                }
                else
                {
                    gridCol出入库单子表ID.OptionsColumn.AllowEdit = false;
                }

                #region
                if (e.Column != gridColiSave && e.Column != gridCol序号 && gridView1.GetRowCellDisplayText(e.RowHandle, gridColiSave).ToString().Trim() == "")
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridColiSave, "add");
                }
                if (e.Column != gridColiSave && e.Column != gridCol序号 && gridView1.GetRowCellDisplayText(e.RowHandle, gridColiSave).ToString().Trim() == "edit")
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridColiSave, "update");
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
                //sSQL = @"select count(1) from dbo.RdRecord12 a inner join RdRecords12 b on a.id = b.id where a.cRdCode = '" + sCode + "'";
                //iReturn = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                iReturn = 0;
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
                sSQL = "select isnull(sum(iOutQuantity),0) as iQuantity,isnull(iQuantity,0) as iQty from MO_MOSublist a  " +
                       "where a.sID = '" + 上游ID + "' ";

                sSQL = sSQL + "group by a.sID,a.iQuantity";

                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt != null && dt.Rows.Count > 0)
                {
                    d累计使用数量 = Convert.ToDecimal(dt.Rows[0][0]);
                    d上游单据数量 = Convert.ToDecimal(dt.Rows[0][1]);
                }
                sSQL = "select iQuantity  from rdrecords12 where autoid = " + 当前ID;
                DataTable dtRds12 = clsSQLCommond.ExecQuery(sSQL);
                if (dtRds12 != null && dtRds12.Rows.Count > 0)
                {
                    d累计使用数量 = d累计使用数量 - Convert.ToDecimal(dt.Rows[0][0]);
                }

                iReturn = 0;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            return iReturn;
        }

//        //保存订单时反写
//        public void WriteOrder(string RdAutoID, string MoAutoID,string MosID
//            , decimal HistoryQty, decimal HistoryNum, decimal HistorysBoxQty
//            , decimal iQuantity, decimal iNum, int sBoxQty, System.Collections.ArrayList aList)
//        {
//            decimal NowQty = iQuantity - HistoryQty;
//            decimal NowNum = iNum - HistoryNum;

//            //反写委外订单子表
//            sSQL = @"
//update  MO_MODetails set iOutQuantity=a.iQuantity,iOutNum = a.iNum from (select MOAutoID,SUM(iQuantity) as iQuantity,sum(iNum) as iNum from RdRecords12 group by MOAutoID) a 
//where MO_MODetails.autoid=a.MOAutoID and MOAutoID = 111111
//";
//            sSQL = sSQL.Replace("111111", MoAutoID.ToString().Trim());
//            aList.Add(sSQL);
//            //反写委外订单材料表
//            sSQL = @"
//update  MO_MOSublist set iOutQuantity=a.iQuantity,iOutNum = a.iNum from (select MOsID,SUM(iQuantity) as iQuantity,sum(iNum) as iNum from RdRecords12 group by MOsID) a 
//where MO_MOSublist.sID=a.MOsID and sID = 111111
//";
//            sSQL = sSQL.Replace("111111", MosID.ToString().Trim());
//        }

        ////删除单据时反写订单
        //public void WriteOrder(string delStrs, System.Collections.ArrayList aList)
        //{
        //    string[] delSplit = delStrs.Split(',');

        //    for (int i = 0; i < delSplit.Length; i++)
        //    {
        //        sSQL = "select iQuantity,iNum,MOAutoID,MOsID,RdAutoID from RdRecords12 where AutoID=" + delSplit[i];
        //        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
        //        if (dt.Rows.Count > 0)
        //        {
        //            long MOAutoID = ReturnLong(dt.Rows[0]["MOAutoID"]);
        //            long MOsID = ReturnLong(dt.Rows[0]["MOsID"]);
        //            string RdAutoID = dt.Rows[0]["RdAutoID"].ToString();

        //            decimal iQuantity = ReturnDecimal(dt.Rows[0]["iQuantity"], 6);
        //            decimal iNum = ReturnDecimal(dt.Rows[0]["iNum"], 6);

        //            //反写委外订单子表
        //            sSQL = @"update MO_MODetails set iOutQuantity = isnull(iOutQuantity,0) - " + iQuantity + ",iOutNum = isnull(iOutNum,0) - " + iNum + " where AutoID = " + MOAutoID;
        //            aList.Add(sSQL);
        //            //反写委外订单材料表
        //            sSQL = @"update MO_MOSublist set iOutQuantity = isnull(iOutQuantity,0) - " + iQuantity + ",iOutNum = isnull(iOutNum,0) - " + iNum + " where sID = " + MOsID;
        //            aList.Add(sSQL);
        //            //反写入库单
        //            sSQL = @"update RdRecords01 set iOutQuantity = isnull(iOutQuantity,0) - " + iQuantity + ",iOutNum = isnull(iOutNum,0) - " + iNum + " where AutoID = '" + RdAutoID + "'";
        //            aList.Add(sSQL);
        //            sSQL = @"update RdRecords02 set iOutQuantity = isnull(iOutQuantity,0) - " + iQuantity + ",iOutNum = isnull(iOutNum,0) - " + iNum + " where AutoID = '" + RdAutoID + "'";
        //            aList.Add(sSQL);
        //            sSQL = @"update RdRecords05 set iOutQuantity = isnull(iOutQuantity,0) - " + iQuantity + ",iOutNum = isnull(iOutNum,0) - " + iNum + " where AutoID = '" + RdAutoID + "'";
        //            aList.Add(sSQL);
        //        }
        //        else
        //        {
        //            throw new Exception("无法找到对应订单");
        //        }
        //    }
        //}

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

        private void lookUpEdit业务员_EditValueChanged(object sender, EventArgs e)
        {

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

        private void ItemButtonEditRdAutoID_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //int iRow = 0;
            //if (gridView1.FocusedRowHandle > 0)
            //    iRow = gridView1.FocusedRowHandle;
            //string cinvcode=gridView1.GetRowCellValue(iRow,gridCol物料编码).ToString();
            //string m1=gridView1.GetRowCellValue(iRow,gridColM1).ToString();
            //系统服务.Frm库存_New frm = new 系统服务.Frm库存_New(1, cinvcode, m1);
            //if (DialogResult.OK == frm.ShowDialog())
            //{
            //    DataTable dt = frm.dt;
            //    decimal iQuantity = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol数量).ToString());
            //    if (dt.Rows.Count > 0)
            //    {
            //        decimal iQty = ReturnDecimal(dt.Rows[0]["iQuantity"]);
            //        if (dt.Rows[0]["cWhCode"].ToString().Trim() != lookUpEdit仓库.EditValue.ToString().Trim())
            //        {
            //            MessageBox.Show("选择的入库单仓库与当前单据仓库不同");
            //        }
            //        else
            //        {
            //            if (iQuantity > iQty)
            //            {


            //                gridView1.SetRowCellValue(iRow, gridCol数量, iQty);
            //            }
            //            gridView1.SetRowCellValue(iRow, gridCol出入库单子表ID, dt.Rows[0]["AutoID"].ToString());
            //            gridView1.SetRowCellValue(iRow, gridColM2, dt.Rows[0]["M2"].ToString());
            //            gridView1.SetRowCellValue(iRow, gridColcPosCode, dt.Rows[0]["cPosCode"].ToString());
            //        }
            //    }
            //}
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
