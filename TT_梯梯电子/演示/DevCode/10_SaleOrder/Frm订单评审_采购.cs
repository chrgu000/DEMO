using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;
using FrameBaseFunction;
using System.Data.SqlClient;

namespace SaleOrder
{
    public partial class Frm订单评审_采购 : FrameBaseFunction.Frm列表窗体模板
    {
        public Frm订单评审_采购()
        {
            InitializeComponent();

            #region 禁止用户调整表格
            gridView评审.OptionsMenu.EnableColumnMenu = false;
            gridView评审.OptionsMenu.EnableFooterMenu = false;
            gridView评审.OptionsMenu.EnableGroupPanelMenu = false;
            gridView评审.OptionsMenu.ShowAutoFilterRowItem = false;
            gridView评审.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            gridView评审.OptionsMenu.ShowGroupSortSummaryItems = false;
            gridView评审.OptionsMenu.ShowGroupSummaryEditorItem = false;
            gridView评审.OptionsMenu.ShowAddNewSummaryItem  = DevExpress.Utils.DefaultBoolean.False;
            gridView评审.OptionsBehavior.FocusLeaveOnTab = true;
            gridView评审.OptionsCustomization.AllowColumnMoving = false;
            //gridView1.OptionsCustomization.

            #endregion

            sLayoutHeadPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Head.xml";
            sLayoutGridPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Grid.xml";

            if (File.Exists(sLayoutHeadPath))
                layoutControl1.RestoreLayoutFromXml(sLayoutHeadPath);

            if (File.Exists(sLayoutGridPath))
            {
                gridControl评审.MainView.RestoreLayoutFromXml(sLayoutGridPath);
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
                    case "add":
                        btnAdd();
                        break;
                    case "del":
                        btnDel();
                        break;
                    case "delrow":
                        btnDelRow();
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

                sState = sBtnName.ToLower();
            }
            catch (Exception ee)
            {
                throw new Exception(sBtnText + " 失败! \n\n原因:\n  " + ee.Message);
            }
        }

        DataTable dt评审 = new DataTable();

        private void btnAdd()
        {
           
        }

        #region 按钮模板

        ///// <summary>
        ///// 将表格中Lookup之类的保存ID的数据转换成Text用于打印
        ///// </summary>
        ///// <param name="dt"></param>
        ///// <returns></returns>
        private DataTable SetPrintData(DataTable dt)
        {
        //    DataTable dtState = (DataTable)ItemLookUpEditState.DataSource;
        //    DataColumn dc = new DataColumn();
        //    dc.ColumnName = "StateText";
        //    dt.Columns.Add(dc);
           
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        DataRow[] drState = dtState.Select("iID = '" + dt.Rows[i]["State"].ToString().Trim() + "'");
        //        if (drState.Length > 0)
        //        {
        //            dt.Rows[i]["StateText"] = drState[0]["State"];
        //        }

        //    }

            return dt;
        }

        /// <summary>
        /// 打印
        /// </summary>
        private void btnPrint()
        {
            try
            {
                gridView评审.FocusedRowHandle -= 1;
                gridView评审.FocusedRowHandle += 1;
            }
            catch { }

            base.dsPrint.Tables.Clear();
            DataTable dtGrid = SetPrintData(((DataTable)gridControl评审.DataSource).Copy());
            dtGrid.TableName = "dtGrid";

            base.dsPrint.Tables.Add(dtGrid);
            DataTable dtHead = dtBingHead.Copy();
            dtHead.TableName = "dtHead";
            base.dsPrint.Tables.Add(dtHead);
        }
        /// <summary>
        /// 输出
        /// </summary>
        private void btnExport()
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
                sF.Filter = "Excel文件(*.xls)|*.xls|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridView评审.ExportToXls(sF.FileName);
                    MessageBox.Show("导出Excel成功\n\t路径：" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnLayout(string sText)
        {
            if (layoutControl1 == null) return;
            if (sText == "布局")
            {
                //layoutControl1.ShowCustomizationForm();
                layoutControl1.AllowCustomizationMenu = true;
                base.toolStripMenuBtn.Items["Layout"].Text = "保存布局";

                gridView评审.OptionsMenu.EnableColumnMenu = true;
                gridView评审.OptionsMenu.EnableFooterMenu = true;
                gridView评审.OptionsMenu.EnableGroupPanelMenu = true;
                //gridView1.OptionsMenu.ShowAddNewSummaryItem = true;
                gridView评审.OptionsMenu.ShowAutoFilterRowItem = true;
                gridView评审.OptionsMenu.ShowDateTimeGroupIntervalItems = true;
                gridView评审.OptionsMenu.ShowGroupSortSummaryItems = true;
                gridView评审.OptionsMenu.ShowGroupSummaryEditorItem = true;
                gridView评审.OptionsCustomization.AllowColumnMoving = true;
            }
            else
            {
                //layoutControl1.HideCustomizationForm();
                layoutControl1.AllowCustomizationMenu = false;
                gridView评审.OptionsMenu.EnableColumnMenu = false;
                gridView评审.OptionsMenu.EnableFooterMenu = false;
                gridView评审.OptionsMenu.EnableGroupPanelMenu = false;
                //gridView1.OptionsMenu.ShowAddNewSummaryItem = false;
                gridView评审.OptionsMenu.ShowAutoFilterRowItem = false;
                gridView评审.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
                gridView评审.OptionsMenu.ShowGroupSortSummaryItems = false;
                gridView评审.OptionsMenu.ShowGroupSummaryEditorItem = false;
                gridView评审.OptionsCustomization.AllowColumnMoving = false;


                if (!Directory.Exists(base.sProPath + "\\layout"))
                    Directory.CreateDirectory(base.sProPath + "\\layout");

                base.toolStripMenuBtn.Items["Layout"].Text = "布局";

                DialogResult d = MessageBox.Show("是否保存?\n是：保存界面样式\n否：恢复默认界面样式,下次加载时将以默认样式打开\n", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
                if (d == DialogResult.Yes)
                {
                    layoutControl1.SaveLayoutToXml(sLayoutHeadPath);
                    gridControl评审.MainView.SaveLayoutToXml(sLayoutGridPath);
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

        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void btnRefresh()
        {
            if (txt销售订单ID.Text.Trim()!="")
                GetGrid(Convert.ToInt64(txt销售订单ID.Text));
        }

        private string sFrmSEL = "";

        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
            Frm订单评审_采购SEL fSel = new Frm订单评审_采购SEL();
            fSel.ShowDialog();
            if (fSel.DialogResult != DialogResult.OK)
            {
                throw new Exception("取消查询");
            }
            GetGrid(fSel.i销售订单ID);
        }

        /// <summary>
        /// 首页
        /// </summary>
        private void btnFirst()
        {
            try
            {
                if (dtSel == null || dtSel.Rows.Count < 1)
                {
                    throw new Exception("没有可以查看的单据");
                }

                iPage = 0;
                long i = Convert.ToInt64(dtSel.Rows[iPage]["销售订单ID"]);
                GetGrid(i);
                lPageInfo.Text = (iPage + 1).ToString() + "/" + dtSel.Rows.Count.ToString();
            }
            catch { }
        }
        /// <summary>
        /// 上页
        /// </summary>
        private void btnPrev()
        {
            try
            {
                if (dtSel == null || dtSel.Rows.Count < 1)
                {
                    throw new Exception("没有可以查看的单据");
                }

                if (iPage > 0)
                {
                    iPage -= 1;
                    long i = Convert.ToInt64(dtSel.Rows[iPage]["销售订单ID"]);
                    GetGrid(i);
                    lPageInfo.Text = (iPage + 1).ToString() + "/" + dtSel.Rows.Count.ToString();
                }
            }
            catch { }

        }
        /// <summary>
        /// 下页
        /// </summary>
        private void btnNext()
        {
            try
            {
                if (dtSel == null || dtSel.Rows.Count < 1)
                {
                    throw new Exception("没有可以查看的单据");
                }

                if (iPage < dtSel.Rows.Count - 1)
                {
                    iPage += 1;
                    long i = Convert.ToInt64(dtSel.Rows[iPage]["销售订单ID"]);
                    GetGrid(i);

                    lPageInfo.Text = (iPage + 1).ToString() + "/" + dtSel.Rows.Count.ToString();
                }
            }
            catch { }
        }

        /// <summary>
        /// 末页
        /// </summary>
        private void btnLast()
        {
            try
            {
                if (dtSel == null || dtSel.Rows.Count < 1)
                {
                    throw new Exception("没有可以查看的单据");
                }

                iPage = dtSel.Rows.Count - 1;

                long i = Convert.ToInt64(dtSel.Rows[iPage]["销售订单ID"]);
                GetGrid(i);
                lPageInfo.Text = (iPage + 1).ToString() + "/" + dtSel.Rows.Count.ToString();
            }
            catch { }
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
            gridView评审.AddNewRow();
        }
        /// <summary>
        /// 删行
        /// </summary>
        private void btnDelRow()
        {
            for (int i = gridView评审.RowCount - 1; i >= 0 ; i--)
            {
                if (gridView评审.IsRowSelected(i))
                {
                    gridView评审.DeleteRow(i);
                }
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {
            if (txt销售订单号.Text.Trim() == "")
            {
                throw new Exception("请选择需要修改的单据");
            }

            SetColEdit(true);

            dt评审 = (DataTable)gridControl评审.DataSource;

            sState = "edit";
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {

        }

        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave()
        {
            try
            {
                gridView评审.FocusedRowHandle -= 1;
                gridView评审.FocusedRowHandle += 1;

                gridView评审.FocusedRowHandle -= 1;
                gridView评审.FocusedRowHandle += 1;
                aList = new System.Collections.ArrayList();
                string sErr = "";

                for (int i = 0; i < gridView评审.RowCount; i++)
                {

                    if (gridView评审.GetRowCellValue(i, gridCol选择1).ToString().Trim() == "√")
                    {
                        if (gridView评审.GetRowCellValue(i, gridCol锁定人1).ToString().Trim() != "")
                        {
                            sErr = sErr + "行" + (i + 1) + "已经锁定不能评审\n";
                            continue;
                        }
                        if (gridView评审.GetRowCellValue(i, gridCol回签完工日期1).ToString().Trim() != "")
                        {
                            DateTime d1 = Convert.ToDateTime(gridView评审.GetRowCellValue(i, gridCol回签完工日期1));
                            DateTime d2 = DateTime.Today;
                            if (d1 < d2)
                            {
                                sErr = sErr + "行" + (i + 1) + "回签日期不能早于当天\n";
                                continue;
                            }
                        }

                        gridView评审.SetRowCellValue(i, gridCol回签人1, FrameBaseFunction.ClsBaseDataInfo.sUserName);
                        gridView评审.SetRowCellValue(i, gridCol回签日期1, DateTime.Now);

                        sSQL = "update 订单评审运算3 set 回签日期2 = '" + gridView评审.GetRowCellValue(i, gridCol回签完工日期1).ToString().Trim() + "',回签人 = '" + gridView评审.GetRowCellValue(i, gridCol回签人1).ToString().Trim() + "',回签日期 = '" + gridView评审.GetRowCellValue(i, gridCol回签日期1).ToString().Trim() + "' where iID = " + gridView评审.GetRowCellValue(i, gridColiID1).ToString().Trim();
                        aList.Add(sSQL);
                    }
                }

                if (sErr.Trim() != "")
                {
                    throw new Exception(sErr);
                }

                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);

                    GetSelList();
                    iPage = dtSel.Rows.Count - 1;
                    lPageInfo.Text = (iPage + 1).ToString() + "/" + dtSel.Rows.Count.ToString();

                    MessageBox.Show("保存成功！\n合计执行语句:" + iCou + "条");

                    SetColEdit(false);
                    sState = "save";
                }

                SetColEdit(false);

                GetSelList();
            }
            catch( Exception ee)
            {
                MsgBox("保存失败", ee.Message);
            }


        }

        /// <summary>
        /// 撤销
        /// </summary>
        private void btnUnDo()
        {
            SetColEdit(false);

            if (txt销售订单ID.Text.Trim() != "")
            {
                GetGrid(Convert.ToInt64(txt销售订单ID.Text));
            }
        }
        /// <summary>
        /// 审核
        /// </summary>
        private void btnAudit()
        {

        }
        /// <summary>
        /// 弃审
        /// </summary>
        private void btnUnAudit()
        {

        }
        /// <summary>
        /// 打开
        /// </summary>
        private void btnOpen()
        {
        }

        /// <summary>
        /// 关闭
        /// </summary>
        private void btnClose()
        {

        }

        /// <summary>
        /// 变更
        /// </summary>
        private void btnAlter()
        {
            string s = "";
            switch (FrameBaseFunction.ClsBaseDataInfo.sUid)
            {
                case "012" :
                    s = " and (iID = 1 or iID = 3)";
                    break;
                case "014" :
                    s = " and (iID = 1 or iID = 3)";
                    break;
                case "018" :
                    s = " and (iID = 2 or iID = 3)";
                    break;
                case "027" :
                    s = " and (iID = 2 or iID = 3)";
                    break;
            }

            string sSQL = "select * from dbo._LookUpDate where iType = 7  " + s;
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            string sMail = "";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (sMail == "")
                    sMail = dt.Rows[i]["iText"].ToString().Trim();
                else
                {
                    sMail = sMail + ";" + dt.Rows[i]["iText"].ToString().Trim();
                }
            }
            string sHead = "订单评审采购确认：" + txt外销订单号.Text.Trim();
            string sText = "外销订单" + txt外销订单号.Text.Trim() + "已经采购确认。";
            try
            {
                ClseMail clseMail = new ClseMail();
                clseMail.MailSend(sMail, sHead, sText);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "发送邮件失败");
            }
        }

        #endregion

        private void Frm订单评审_Load(object sender, EventArgs e)
        {
            try
            {
                GetLookUp();

                GetSelList();

                btnLast();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void gridView评审_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        //private void gridView评审计算_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        //{
        //    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
        //    if (e.Info.IsRowIndicator)
        //    {
        //        if (e.RowHandle >= 0)
        //        {
        //            e.Info.DisplayText = (e.RowHandle + 1).ToString();
        //        }
        //        else if (e.RowHandle < 0 && e.RowHandle > -1000)
        //        {
        //            e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
        //            e.Info.DisplayText = "G" + e.RowHandle.ToString();
        //        }
        //    }
        //}

        private void GetLookUp()
        {
            string sSQL = "select cInvCode,cInvName,cInvStd from @u8.Inventory order by cInvCode";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            DataRow drInv = dt.NewRow();
            drInv["cInvCode"] = "--";
            dt.Rows.Add(drInv);
            ItemLookUpEdit1物料编码.DataSource = dt;
            ItemLookUpEdit1物料名称.DataSource = dt;
            ItemLookUpEdit1物料规格.DataSource = dt;

            sSQL = "select cCusCode,cCusName,cCusAbbName from @u8.Customer order by cCusCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            lookUpEdit客户.Properties.DataSource = dt;

            DataColumn dc = new DataColumn();
            dc.ColumnName = "iID";
            dt.Columns.Add(dc);
            DataRow dr = dt.NewRow();
            dr["iID"] = "采购";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["iID"] = "委外";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["iID"] = "自制";
            dt.Rows.Add(dr);
            ItemLookUpEdit1子件属性.DataSource = dt;

            sSQL = "select cDepCode,cDepName from @u8.Department order by cDepCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit1部门编码.DataSource = dt;
            ItemLookUpEdit1部门名称.DataSource = dt;

            sSQL = "select cWhCode,cWhName from @u8.Warehouse  order by cWhCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit1仓库编码.DataSource = dt;
            ItemLookUpEdit1仓库名称.DataSource = dt;

            sSQL = "select cDepCode,cDepName from @u8.Department where bDepEnd = 1 ";
            dt = clsSQLCommond.ExecQuery(sSQL);
            lookUpEdit部门.Properties.DataSource = dt;

            sSQL = "select cVenCode,cVenName from @u8.Vendor  order by cVenCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit供应商.DataSource = dt;
        }

        private void gridView评审计算_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                int i1 = ReturnObjectToInt(gridView评审.GetRowCellValue(e.RowHandle, gridCol销售订单行号1));
                int i2 = i1%2;

                if (i2 == 0)
                {
                    e.Appearance.BackColor = Color.AliceBlue;
                }
                else
                {
                    e.Appearance.BackColor = Color.AntiqueWhite; 
                }
            }
            catch
            { }
        }


        private void SetColEdit(bool b)
        {
            gridCol回签开始日期1 .OptionsColumn.AllowEdit = b;
            gridCol回签完工日期1.OptionsColumn.AllowEdit = b;
            chk全选.Enabled = b;
            chk全选.Checked = false;
        }


        private void GetGrid(long i销售订单ID)
        {
            string sSQL = "select * from dbo.订单评审运算1 where 销售订单ID = " + i销售订单ID + " and 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim();
            DataTable dt订单评审运算1 = clsSQLCommond.ExecQuery(sSQL);

            sSQL = "select * from dbo.订单评审运算2 where 销售订单ID = " + i销售订单ID + " and 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim() + " order by iID";
            DataTable dt订单评审运算2 = clsSQLCommond.ExecQuery(sSQL);

            sSQL = "select cast(null as varchar(2)) as 选择,*,cast(null as varchar(50)) as 供应商编码,cast(null as decimal(16,6)) as 含税单价,cast(null as decimal(16,6)) as 含税金额,cast(null as varchar(50)) as 采购部门编码,cast(null as decimal(16,6)) as 仓库现存量,cast(null as decimal(16,6)) as 待入库,cast(null as decimal(16,6)) as 下单量,cast(null as decimal(16,6)) as 累计下单量,cast(null as decimal(16,6)) as 累计待入库,cast(null as decimal(16,6)) as 最小批量 " +
                "from dbo.订单评审运算3 where isnull(本次下单数量,0) <> 0 and 子件属性 = '采购' and 销售订单ID = " + i销售订单ID + " and 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim() + " order by 子件编码,iID";
            DataTable dt订单评审运算3 = clsSQLCommond.ExecQuery(sSQL);

            if (dt订单评审运算1 != null && dt订单评审运算1.Rows.Count > 0 && dt订单评审运算2 != null && dt订单评审运算2.Rows.Count > 0 && dt订单评审运算3 != null && dt订单评审运算3.Rows.Count > 0)
            {
                for (int i = 0; i < dt订单评审运算3.Rows.Count; i++)
                {
                    string s子件 = dt订单评审运算3.Rows[i]["子件编码"].ToString().Trim();
                    string s销售订单号 = dt订单评审运算1.Rows[0]["销售订单号"].ToString().Trim();
                    sSQL = "select a.cPOID,b.cDefine37,b.iTaxPrice,b.iSum,a.cVenCode,c.cVenDepart " +
                           "from @u8.PO_Pomain a inner join @u8.PO_Podetails b on a.poid = b.poid  left join @u8.Vendor c on a.cVenCode = c.cVenCode " +
                           "where b.cInvCode = '" + s子件 + "' and cItemCode = '" + s销售订单号 + "'  ";
                    DataTable dt采购供应商回签日期 = clsSQLCommond.ExecQuery(sSQL);

                    if (dt采购供应商回签日期 != null && dt采购供应商回签日期.Rows.Count > 0)
                    {
                        dt订单评审运算3.Rows[i]["供应商回签日期"] = dt采购供应商回签日期.Rows[0]["cDefine37"];
                        dt订单评审运算3.Rows[i]["供应商编码"] = dt采购供应商回签日期.Rows[0]["cVenCode"];
                        dt订单评审运算3.Rows[i]["含税单价"] = dt采购供应商回签日期.Rows[0]["iTaxPrice"];
                        dt订单评审运算3.Rows[i]["含税金额"] = dt采购供应商回签日期.Rows[0]["iSum"];
                        dt订单评审运算3.Rows[i]["采购部门编码"] = dt采购供应商回签日期.Rows[0]["cVenDepart"];
                    }
                
                }

                txt销售订单号.Text = dt订单评审运算1.Rows[0]["销售订单号"].ToString().Trim();
                txt外销订单号.Text = dt订单评审运算1.Rows[0]["外销订单号"].ToString().Trim();
                txt客户订单号.Text = dt订单评审运算1.Rows[0]["客户订单号"].ToString().Trim();
                lookUpEdit客户.EditValue = dt订单评审运算1.Rows[0]["客户编号"];
                txt备注.Text = dt订单评审运算1.Rows[0]["备注"].ToString().Trim();
                txt销售订单ID.Text = dt订单评审运算1.Rows[0]["销售订单ID"].ToString().Trim();
                txt评审备注.Text = dt订单评审运算1.Rows[0]["评审备注"].ToString().Trim();

                gridControl评审.DataSource = dt订单评审运算3;
                gridControl评审.DataSource = dt订单评审运算3;

                sSQL = @"
select distinct a.cCode,b.cItemCode,a.cAuditDate,a.cAuditTime,a.cMakeTime,a.ID
from @u8.PU_AppVouch a inner join @u8.PU_AppVouchs b on a.ID = b.ID  
where b.cItemCode = '111111'
order by a.ID
";
                sSQL = sSQL.Replace("111111", txt销售订单号.Text.Trim());
                DataTable dt审核时间 = clsSQLCommond.ExecQuery(sSQL);
                if (dt审核时间 != null && dt审核时间.Rows.Count > 0)
                {
                    txt请购单审核时间.Text = ReturnObjectToDatetime(dt审核时间.Rows[0]["cAuditTime"]).ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    txt请购单审核时间.Text = "";
                }

                if (lookUpEdit部门.Text.Trim() != "")
                {
                    gridCol采购部门编码1.FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(" 采购部门编码 = '" + lookUpEdit部门.EditValue.ToString().Trim() + "' or 采购部门编码 = '' or 采购部门编码 is null ");
                }
                }
            else
            {
                throw new Exception("获得单据失败");
            }


            SetColEdit(false);
        }


        private void chk全选_CheckedChanged(object sender, EventArgs e)
        {
            b双击 = true;

            if (sState != "edit")
                return;

            try
            {
                if (chk全选.Checked)
                {
                    for (int i = 0; i < gridView评审.RowCount; i++)
                    {

                        if (gridView评审.GetRowCellValue(i, gridCol回签完工日期1).ToString().Trim() == "")
                        {
                            if (gridView评审.GetRowCellValue(i, gridCol供应商回签日期1).ToString().Trim() != "")
                            {
                                gridView评审.SetRowCellValue(i, gridCol回签完工日期1, gridView评审.GetRowCellValue(i, gridCol供应商回签日期1));
                            }
                            else
                            {
                                gridView评审.SetRowCellValue(i, gridCol回签完工日期1, gridView评审.GetRowCellValue(i, gridCol完成日期1)); 
                            }
                        }

                        if (gridView评审.GetRowCellValue(i, gridCol回签完工日期1).ToString().Trim() != "")
                        {
                            gridView评审.SetRowCellValue(i, gridCol选择1, "√");
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < gridView评审.RowCount; i++)
                    {
                        gridView评审.SetRowCellValue(i, gridCol选择1, "");
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            b双击 = false;
        }

        bool b双击 = false;
        private void gridView评审_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (sState != "edit")
                    return;

                b双击 = true;
                int i = gridView评审.FocusedRowHandle;
                if (gridView评审.GetRowCellValue(i, gridCol选择1).ToString().Trim() == "")
                {
                    if (gridView评审.GetRowCellValue(i, gridCol供应商回签日期1).ToString().Trim() != "")
                    {
                        gridView评审.SetRowCellValue(i, gridCol回签完工日期1, gridView评审.GetRowCellValue(i, gridCol供应商回签日期1));
                    }
                    else
                    {
                        gridView评审.SetRowCellValue(i, gridCol回签完工日期1, gridView评审.GetRowCellValue(i, gridCol完成日期1));
                    }
                    if (gridView评审.GetRowCellValue(i, gridCol回签完工日期1).ToString().Trim() != "")
                    {
                        gridView评审.SetRowCellValue(i, gridCol选择1, "√");
                    }
                }
                else
                {
                    gridView评审.SetRowCellValue(i, gridCol选择1, "");
                }
                if (!b双击)
                {
                    if (gridView评审.GetRowCellValue(i, gridCol选择1).ToString().Trim() == "√")
                    {
                        gridView评审.SetRowCellValue(i, gridCol选择1, "");
                    }
                }
            }
            catch { }
            b双击 = false;
        }

        private void GetSelList()
        {
            string sSQL = "select 销售订单ID from 订单评审运算1 where 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim() + " and isnull(审核人,'') <> '' and isnull(关闭人,'') = '' and isnull(下达请购人,'') <> '' order by 销售订单号";
            dtSel = clsSQLCommond.ExecQuery(sSQL);

            if (dtSel != null && dtSel.Rows.Count > 0)
            {
                iPage = dtSel.Rows.Count - 1;
            }
        }

        private void gridView评审_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (sState == "edit")
            {
                if (gridView评审.GetRowCellValue(e.FocusedRowHandle, gridCol锁定人1) == null || gridView评审.GetRowCellValue(e.FocusedRowHandle, gridCol锁定人1).ToString().Trim() == "")
                {
                    gridCol回签开始日期1.OptionsColumn.AllowEdit = true;
                    gridCol回签完工日期1.OptionsColumn.AllowEdit = true;
                }
                else
                {
                    gridCol回签开始日期1.OptionsColumn.AllowEdit = false;
                    gridCol回签完工日期1.OptionsColumn.AllowEdit = false;
                }
            }
        }

        private decimal GetQTY(object d)
        {
            try
            {
                return FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(d);
            }
            catch
            {
                return -999999;
            }
        }

        private void lookUpEdit部门_EditValueChanged(object sender, EventArgs e)
        {
            gridCol采购部门编码1.FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(" 采购部门编码 = '" + lookUpEdit部门.EditValue.ToString().Trim() + "' or rtrim(ltrim(采购部门编码)) = '' or 采购部门编码 is null ");
        }

        //private void gridView评审_CustomDrawRowIndicator_1(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        //{
        //    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
        //    if (e.Info.IsRowIndicator)
        //    {
        //        if (e.RowHandle >= 0)
        //        {
        //            e.Info.DisplayText = (e.RowHandle + 1).ToString();
        //        }
        //        else if (e.RowHandle < 0 && e.RowHandle > -1000)
        //        {
        //            e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
        //            e.Info.DisplayText = "G" + e.RowHandle.ToString();
        //        }
        //    }
        //}
    }
}
