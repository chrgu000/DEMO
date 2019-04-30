using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;
using System.Data.SqlClient;
using FrameBaseFunction;


namespace ImportDLL
{
    public partial class Frm销售订单导入 : FrameBaseFunction.FrmFromModel
    {
        ClsExcel clsexcel = FrameBaseFunction.ClsExcel.Instance();
        

        DataTable dtGridInfo;

        string sTable = "";

        public Frm销售订单导入()
        {
            InitializeComponent();

            #region 禁止用户调整表格
            gridView内销.OptionsMenu.EnableColumnMenu = false;
            gridView内销.OptionsMenu.EnableFooterMenu = false;
            gridView内销.OptionsMenu.EnableGroupPanelMenu = false;
            gridView内销.OptionsMenu.ShowAutoFilterRowItem = false;
            gridView内销.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            gridView内销.OptionsMenu.ShowGroupSortSummaryItems = false;
            gridView内销.OptionsMenu.ShowGroupSummaryEditorItem = false;
            gridView内销.OptionsMenu.ShowAddNewSummaryItem  = DevExpress.Utils.DefaultBoolean.False;
            gridView内销.OptionsBehavior.FocusLeaveOnTab = true;
            gridView内销.OptionsCustomization.AllowColumnMoving = true;
            gridView内销.OptionsCustomization.AllowColumnMoving = false;
            //gridView1.OptionsCustomization.

            #endregion

            //sLayoutHeadPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Head.xml";
            //sLayoutGridPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Grid.xml";

            //if (File.Exists(sLayoutHeadPath))
            //    layoutControl1.RestoreLayoutFromXml(sLayoutHeadPath);

            //if (File.Exists(sLayoutGridPath))
            //{
            //    gridControl1.MainView.RestoreLayoutFromXml(sLayoutGridPath);
            //}

            radio内销.Checked = true;
            layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

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
            //DataTable dtState = (DataTable)ItemLookUpEditState.DataSource;
            //DataColumn dc = new DataColumn();
            //dc.ColumnName = "StateText";
            //dt.Columns.Add(dc);
           
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    DataRow[] drState = dtState.Select("iID = '" + dt.Rows[i]["State"].ToString().Trim() + "'");
            //    if (drState.Length > 0)
            //    {
            //        dt.Rows[i]["StateText"] = drState[0]["State"];
            //    }

            //}

            //return dt;
            return null;
        }

        /// <summary>
        /// 打印
        /// </summary>
        private void btnPrint()
        {
            try
            {
                gridView内销.FocusedRowHandle -= 1;
                gridView内销.FocusedRowHandle += 1;
            }
            catch { }

            base.dsPrint.Tables.Clear();
            DataTable dtGrid = SetPrintData(((DataTable)gridControl内销.DataSource).Copy());
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
                    gridView内销.ExportToXls(sF.FileName);
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

                gridView内销.OptionsMenu.EnableColumnMenu = true;
                gridView内销.OptionsMenu.EnableFooterMenu = true;
                gridView内销.OptionsMenu.EnableGroupPanelMenu = true;
                //gridView1.OptionsMenu.ShowAddNewSummaryItem = true;
                gridView内销.OptionsMenu.ShowAutoFilterRowItem = true;
                gridView内销.OptionsMenu.ShowDateTimeGroupIntervalItems = true;
                gridView内销.OptionsMenu.ShowGroupSortSummaryItems = true;
                gridView内销.OptionsMenu.ShowGroupSummaryEditorItem = true;
                gridView内销.OptionsCustomization.AllowColumnMoving = true;
            }
            else
            {
                //layoutControl1.HideCustomizationForm();
                layoutControl1.AllowCustomizationMenu = false;
                gridView内销.OptionsMenu.EnableColumnMenu = false;
                gridView内销.OptionsMenu.EnableFooterMenu = false;
                gridView内销.OptionsMenu.EnableGroupPanelMenu = false;
                //gridView1.OptionsMenu.ShowAddNewSummaryItem = false;
                gridView内销.OptionsMenu.ShowAutoFilterRowItem = false;
                gridView内销.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
                gridView内销.OptionsMenu.ShowGroupSortSummaryItems = false;
                gridView内销.OptionsMenu.ShowGroupSummaryEditorItem = false;
                gridView内销.OptionsCustomization.AllowColumnMoving = false;


                base.toolStripMenuBtn.Items["Layout"].Text = "布局";

                DialogResult d = MessageBox.Show("是否保存?\n是：保存界面样式\n否：取消保存", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (d == DialogResult.Yes)
                {
                    int iCou = 0;
                    SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
                    conn.Open();
                    //启用事务
                    SqlTransaction tran = conn.BeginTransaction();
                    try
                    {
                        sSQL = @"update [dbo].[列表设置] set [可见] = 0 where 库名 = '.' and [表名] = '111111'";
                        sSQL = sSQL.Replace("111111", sTable);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        for (int i = 0; i < gridView内销.Columns.Count; i++)
                        {
                            int iW = gridView内销.Columns[i].Width;
                            string sColName = gridView内销.Columns[i].FieldName.Trim();
                            string sColText = gridView内销.Columns[i].Caption.Trim();
                            int iIndex = gridView内销.Columns[i].VisibleIndex;
                            bool bVis = gridView内销.Columns[i].Visible;

                            sSQL = @"update [dbo].[列表设置] set [排序] = 444444,[可见] = 555555, [宽度] = " + iW + " where 库名 = '.' and [表名] = '111111' and [列名] = '222222' and [列标题] = '333333'";
                            sSQL = sSQL.Replace("111111", sTable);
                            sSQL = sSQL.Replace("222222", sColName);
                            sSQL = sSQL.Replace("333333", sColText);
                            sSQL = sSQL.Replace("444444", iIndex.ToString().Trim());
                            if (bVis)
                            {
                                sSQL = sSQL.Replace("555555", "1");
                            }
                            else
                            {
                                sSQL = sSQL.Replace("555555", "0");
                            }
                            iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        }
                        if (iCou > 0)
                        {
                            tran.Commit();
                        }
                        else
                        {
                            tran.Rollback();
                        }
                    }
                    catch (Exception error)
                    {
                        tran.Rollback();

                        throw new Exception(error.Message);
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// 导入
        /// </summary>
        private void btnImport()
        {
            string sErr = "";

            gridControl内销.DataSource = null;
            gridControl外销.DataSource = null;

            if (radio内销.Checked)
            {
                OpenFileDialog oFile = new OpenFileDialog();
                oFile.Filter = "Excel文件(*.xlsx)|*.xlsx|Excel文件(*.xls)|*.xls";
                if (oFile.ShowDialog() == DialogResult.OK)
                {
                    string sFilePath = oFile.FileName;
                    string sSQL = "select * from [内销$] order by 序号";

                    DataTable dtExcel = clsExcel.ExcelToDT(sFilePath, sSQL, true);

                    DataColumn dc = new DataColumn();
                    dc.ColumnName = "辅助数量";
                    dtExcel.Columns.Add(dc);

                    dc = new DataColumn();
                    dc.ColumnName = "换算率";
                    dtExcel.Columns.Add(dc);

                    dc = new DataColumn();
                    dc.ColumnName = "计量单位编码";
                    dtExcel.Columns.Add(dc);

                    dc = new DataColumn();
                    dc.ColumnName = "税率";
                    dtExcel.Columns.Add(dc);

                    dc = new DataColumn();
                    dc.ColumnName = "单计量";
                    dtExcel.Columns.Add(dc);

                    dc = new DataColumn();
                    dc.ColumnName = "型号";
                    dtExcel.Columns.Add(dc);

                    dc = new DataColumn();
                    dc.ColumnName = "级别";
                    dtExcel.Columns.Add(dc);

                    for (int i = 0; i < dtExcel.Rows.Count; i++)
                    {
                        decimal d数量 = ReturnObjectToDecimal(dtExcel.Rows[i]["数量"], 4);
                        if (d数量 == 0)
                        {
                            continue;
                        }
                        string s存货编码 = dtExcel.Rows[i]["产品编码"].ToString().Trim();
                        if (s存货编码 == "")
                        {
                            continue;
                        }

                        sSQL = @"
SELECT a.cInvCode,a.cInvName,a.cInvStd,a.cGroupCode ,isnull(c.bMainUnit,0) as bMainUnit,c.iChangRate,c.cComunitCode,a.cComUnitCode,a.iTaxRate,a.iInvWeight,cInvDefine1 as 型号,cInvDefine2 as 级别
FROM @u8.Inventory a LEFT JOIN @u8.ComputationGroup  b ON a.cGroupCode = b.cGroupCode
	LEFT JOIN @u8.ComputationUnit c ON b.cGroupCode = c.cGroupCode
WHERE 1=1
	AND a.cInvCode = N'111111'
ORDER BY cInvCode,c.bMainUnit
";
                        sSQL = sSQL.Replace("111111", s存货编码);
                        DataTable dtTemp = clsSQLCommond.ExecQuery(sSQL);
                        if (dtTemp == null || dtTemp.Rows.Count == 0)
                        {
                            continue;
                        }

                        decimal d换算率辅助 = 1;
                        decimal d换算率主 = 1;

                        bool b单计量 = false;
                        for (int j = 0; j < dtTemp.Rows.Count; j++)
                        {
                            dtExcel.Rows[i]["型号"] = dtTemp.Rows[0]["型号"].ToString().Trim();
                            dtExcel.Rows[i]["级别"] = dtTemp.Rows[0]["级别"].ToString().Trim();

                            //单计量单位
                            if (dtTemp.Rows[j]["cGroupCode"].ToString().Trim() == "W000")
                            {
                                dtExcel.Rows[i]["单计量"] = "是";
                                b单计量 = true;
                                break;
                            }

                            if (!Convert.ToBoolean(dtTemp.Rows[j]["bMainUnit"]))
                            {
                                d换算率辅助 = ReturnObjectToDecimal(dtTemp.Rows[j]["iChangRate"], 4);
                                if (d换算率辅助 == 0)
                                    d换算率辅助 = 1;
                            }
                            else
                            {
                                d换算率主 = ReturnObjectToDecimal(dtTemp.Rows[j]["iChangRate"], 4);
                                if (d换算率主 == 0)
                                    d换算率主 = 1;
                            }
                        }
                        dtExcel.Rows[i]["数量"] = d数量;

                        if (!b单计量)
                        {
                            decimal d换算率 = d换算率辅助 / d换算率主;

                            decimal d辅数量 = ReturnObjectToDecimal(d数量 / d换算率, 4);

                            if (dtTemp.Rows[0]["cInvStd"].ToString().Trim() == "非标")
                            {
                                decimal d长度 = ReturnObjectToDecimal(dtExcel.Rows[i]["长度"], 4);
                                decimal d单重 = ReturnObjectToDecimal(dtTemp.Rows[0]["iInvWeight"], 4) / 1000;

                                if (d长度 == 0)
                                {
                                    sErr = sErr + "行" + (i + 1).ToString() + " 没有长度\n";
                                    continue;
                                }
                                if (d单重 == 0)
                                {
                                    sErr = sErr + "行" + (i + 1).ToString() + " 没有单重\n";
                                    continue;
                                }


                                d辅数量 = ReturnObjectToDecimal(d数量 * d长度 * d单重, 4);
                                d换算率 = ReturnObjectToDecimal(d数量 / d辅数量, 4);
                            }



                            dtExcel.Rows[i]["辅助数量"] = d辅数量;

                            dtExcel.Rows[i]["换算率"] = d换算率;
                        }

                        dtExcel.Rows[i]["计量单位编码"] = dtTemp.Rows[0]["cComUnitCode"].ToString().Trim();
                        dtExcel.Rows[i]["税率"] = dtTemp.Rows[0]["iTaxRate"].ToString().Trim();

                        if (radio单价计算.Checked)
                        {
                            decimal d单价 = ReturnObjectToDecimal(dtExcel.Rows[i]["单价"], 4);
                            if (d单价 != 0)
                            {
                                decimal d金额 = ReturnObjectToDecimal(d单价 * d数量, 2);

                                dtExcel.Rows[i]["总价"] = d金额;
                            }
                        }
                        if (radio总价计算.Checked)
                        {
                            decimal d总价 = ReturnObjectToDecimal(dtExcel.Rows[i]["总价"], 2);

                            if (d数量 != 0)
                            {
                                decimal d单价 = ReturnObjectToDecimal(d总价 / d数量, 4);

                                dtExcel.Rows[i]["单价"] = d单价;

                            }
                        }
                    }

                    gridControl内销.DataSource = dtExcel;
                }
                else
                {
                    throw new Exception("取消导入");
                }
            }

            if (radio外销.Checked)
            {
                OpenFileDialog oFile = new OpenFileDialog();
                oFile.Filter = "Excel文件(*.xlsx)|*.xlsx|Excel文件(*.xls)|*.xls";
                if (oFile.ShowDialog() == DialogResult.OK)
                {
                    string sFilePath = oFile.FileName;
                    string sSQL = "select * from [外销$] order by 序号";

                    DataTable dtExcel = clsExcel.ExcelToDT(sFilePath, sSQL, true);

                    DataColumn dc = new DataColumn();
                    dc.ColumnName = "数量";
                    dtExcel.Columns.Add(dc);

                    dc = new DataColumn();
                    dc.ColumnName = "换算率";
                    dtExcel.Columns.Add(dc);

                    dc = new DataColumn();
                    dc.ColumnName = "计量单位编码";
                    dtExcel.Columns.Add(dc);

                    dc = new DataColumn();
                    dc.ColumnName = "税率";
                    dtExcel.Columns.Add(dc);

                    dc = new DataColumn();
                    dc.ColumnName = "汇率";
                    dtExcel.Columns.Add(dc);

                    dc = new DataColumn();
                    dc.ColumnName = "单计量";
                    dtExcel.Columns.Add(dc);

                    for (int i = 0; i < dtExcel.Rows.Count; i++)
                    {
                        decimal d辅数量 = ReturnObjectToDecimal(dtExcel.Rows[i]["支数"], 4);
                        if (d辅数量 == 0)
                        {
                            continue;
                        }
                        string s存货编码 = dtExcel.Rows[i]["产品编码"].ToString().Trim();
                        if (s存货编码 == "")
                        {
                            continue;
                        }

                        sSQL = @"
SELECT a.cInvCode,a.cInvName,a.cInvStd,a.cGroupCode ,isnull(c.bMainUnit,0) as bMainUnit,c.iChangRate,c.cComunitCode,a.cComUnitCode,a.iTaxRate
FROM @u8.Inventory a LEFT JOIN @u8.ComputationGroup  b ON a.cGroupCode = b.cGroupCode
	LEFT JOIN @u8.ComputationUnit c ON b.cGroupCode = c.cGroupCode
WHERE 1=1
	AND a.cInvCode = N'111111'
ORDER BY cInvCode,c.bMainUnit
";
                        sSQL = sSQL.Replace("111111", s存货编码);
                        DataTable dtTemp = clsSQLCommond.ExecQuery(sSQL);
                        if (dtTemp == null || dtTemp.Rows.Count == 0)
                        {
                            continue;
                        }

                        decimal d换算率辅助 = 1;
                        decimal d换算率主 = 1;
                        for (int j = 0; j < dtTemp.Rows.Count; j++)
                        {
                            //单计量单位
                            if (dtTemp.Rows[j]["cGroupCode"].ToString().Trim() == "W000")
                            {
                                dtExcel.Rows[i]["单计量"] = "是";
                                break;
                            }
                            if (!Convert.ToBoolean(dtTemp.Rows[j]["bMainUnit"]))
                            {
                                d换算率辅助 = ReturnObjectToDecimal(dtTemp.Rows[j]["iChangRate"], 4);
                            }
                            else
                            {
                                d换算率主 = ReturnObjectToDecimal(dtTemp.Rows[j]["iChangRate"], 4);
                            }
                        }

                        decimal d换算率 = d换算率辅助 / d换算率主;

                        decimal d主数量 = ReturnObjectToDecimal(d辅数量 * d换算率, 4);

                        dtExcel.Rows[i]["数量"] = d主数量;


                        dtExcel.Rows[i]["换算率"] = d换算率;
                        dtExcel.Rows[i]["计量单位编码"] = dtTemp.Rows[0]["cComUnitCode"].ToString().Trim();
                        dtExcel.Rows[i]["税率"] = dtTemp.Rows[0]["iTaxRate"].ToString().Trim();

                        if (radio单价计算.Checked)
                        {
                            decimal d单价 = ReturnObjectToDecimal(dtExcel.Rows[i]["单价"], 4);
                            if (d单价 != 0)
                            {
                                decimal d金额 = ReturnObjectToDecimal(d单价 * d主数量, 2);

                                dtExcel.Rows[i]["总价"] = d金额;
                            }
                        }
                        if (radio总价计算.Checked)
                        {
                            decimal d总价 = ReturnObjectToDecimal(dtExcel.Rows[i]["总价"], 2);

                            if (d主数量 != 0)
                            {
                                decimal d单价 = ReturnObjectToDecimal(d总价 / d主数量, 4);

                                dtExcel.Rows[i]["单价"] = d单价;
                            }
                        }

                        string s币种 = dtExcel.Rows[i]["货币单位"].ToString().Trim();
                        DateTime d下单日期 = ReturnObjectToDatetime(dtExcel.Rows[i]["下单日期"]);
                        if (s币种 != "人民币")
                        {
                            //sSQL = "SELECT * FROM @u8.exch WHERE cexch_name = '111111' AND iperiod = 222222";

                            sSQL = @"
SELECT a.* FROM @u8.exch a 
	LEFT JOIN @u8.foreigncurrency b ON a.cexch_name = b.cexch_name
WHERE (A.cexch_name = '111111' OR b.cexch_code = '111111') AND iperiod = 222222
";
                            sSQL = sSQL.Replace("111111", s币种);
                            if (d下单日期 < ReturnObjectToDatetime("2015-4-1"))
                            {
                                sSQL = sSQL.Replace("222222", "4");
                            }
                            else
                            {
                                sSQL = sSQL.Replace("222222", d下单日期.Month.ToString().Trim());
                            }
                            dtTemp = clsSQLCommond.ExecQuery(sSQL);
                            if (dtTemp != null && dtTemp.Rows.Count > 0)
                            {
                                dtExcel.Rows[i]["汇率"] = ReturnObjectToDecimal(dtTemp.Rows[0]["nflat"], 4);
                            }
                        }
                        else
                        {
                            dtExcel.Rows[i]["汇率"] = 1;
                        }
                    }

                    gridControl外销.DataSource = dtExcel;
                }
                else
                {
                    throw new Exception("取消导入");
                }
            }

            if (sErr != "")
            {
                throw new Exception(sErr);
            }
        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void btnRefresh()
        {
            SetLookup();
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
            GetGrid();
        }

        private void GetGrid()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 首页
        /// </summary>
        private void btnFirst()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 上页
        /// </summary>
        private void btnPrev()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 下页
        /// </summary>
        private void btnNext()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 末页
        /// </summary>
        private void btnLast()
        {
            throw new NotImplementedException();
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
            gridView内销.AddNewRow();
        }
        /// <summary>
        /// 删行
        /// </summary>
        private void btnDelRow()
        {
            try
            {
                gridView内销.FocusedRowHandle -= 1;
                gridView内销.FocusedRowHandle += 1;
            }
            catch { }

            for (int i = gridView内销.RowCount - 1; i >= 0; i--)
            {
                if (BaseFunction.BaseFunction.ReturnBool(gridView内销.GetRowCellValue(i,gridView内销.Columns["bChoose"])))
                {
                    gridView内销.DeleteRow(i);
                }
            }
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
           
        }

      
        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave()
        {
            int iErr = 0;
            try
            {
                gridView内销.FocusedRowHandle -= 1;
                gridView内销.FocusedRowHandle += 1;
            }
            catch { }

            try
            {

                TH.DAL.SO_SOMain DAL = new TH.DAL.SO_SOMain();
                TH.DAL.SO_SODetails Dals = new TH.DAL.SO_SODetails();

                string sErr = "";
                if (radio内销.Checked && gridView内销.RowCount == 0)
                {
                    throw new Exception("请加载内销数据");
                }

                if (radio外销.Checked && gridView外销.RowCount == 0)
                {
                    throw new Exception("请加载外销数据");
                }

                long lCode = 0;
                long lID = 0;
                long lIDDetail = 0;

                int iCou = 0;
                SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    sSQL = "SELECT * FROM UFSystem..UA_Identity WHERE cAcc_Id = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3) + "' AND cVouchType = 'Somain'";
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        sSQL = "INSERT INTO UFSystem..UA_Identity(cAcc_Id,cVouchType,iFatherId,iChildId)VALUES('111111','Somain',0,0)";
                        sSQL = sSQL.Replace("111111", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3));
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                    else
                    {
                        lID = ReturnObjectToLong(dt.Rows[0]["iFatherId"]);
                        lIDDetail = ReturnObjectToLong(dt.Rows[0]["iChildId"]);
                    }

              

                    #region 内销

                    if (radio内销.Checked)
                    {
                        #region 判断是否已经导入

                        for (int i = 0; i < gridView内销.RowCount; i++)
                        {
                            string s单据号 = gridView内销.GetRowCellValue(i, gridCol订单号).ToString().Trim();
                            sSQL = "select * from @u8.SO_SODetails where cDefine22 = '" + s单据号 + "'";
                            dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                sErr = sErr + "单据已经存在 " + s单据号 + "\n";
                            }
                        }
                        if (sErr.Length > 0)
                        {
                            throw new Exception(sErr);
                        }

                        #endregion

                        decimal d税率 = 17;

                        DataTable dt业务类型 = new DataTable();
                        DataColumn dc业务类型 = new DataColumn();
                        dc业务类型.ColumnName = "业务类型";
                        dt业务类型.Columns.Add(dc业务类型);

                        DataRow dr业务类型 = dt业务类型.NewRow();
                        dr业务类型["业务类型"] = "普通销售";
                        dt业务类型.Rows.Add(dr业务类型);

                        dr业务类型 = dt业务类型.NewRow();
                        dr业务类型["业务类型"] = "直运销售";
                        dt业务类型.Rows.Add(dr业务类型);


                        for (int ii = 0; ii < dt业务类型.Rows.Count; ii++)
                        {
                            string s业务类型 = dt业务类型.Rows[ii]["业务类型"].ToString().Trim();

                            for (int i = 0; i < gridView内销.RowCount; i++)
                            {
                                string s业务类型2 = gridView内销.GetRowCellValue(i, gridCol业务类型).ToString().Trim();

                                bool bexist = false;
                                for (int iii = 0; iii < dt业务类型.Rows.Count; iii++)
                                {
                                    if (s业务类型2 == dt业务类型.Rows[iii]["业务类型"].ToString().Trim())
                                    {
                                        bexist = true;
                                        break;
                                    }
                                }
                                if(!bexist)
                                    throw new Exception(s业务类型2 + " 不存在\n");


                                if (s业务类型 != s业务类型2)
                                {
                                    continue;
                                }

                                iErr = i;

                                DateTime d单据日期 = ReturnObjectToDatetime(gridView内销.GetRowCellValue(i, gridCol客户下单日期));
                                //if (d单据日期 == ReturnObjectToDatetime("1900-1-1"))
                                //{
                                //    sErr = sErr + "行" + (i + 1).ToString().Trim() + " 单据日期不正确\n";
                                //}

                                if (gridView内销.GetRowCellValue(i, gridCol客户下单日期).ToString().Trim() == "")
                                {
                                    d单据日期 = ReturnObjectToDatetime(DateTime.Now.ToString("yyyy-MM-dd"));
                                }
                                else if (ReturnObjectToDatetime(gridView内销.GetRowCellValue(i, gridCol客户下单日期)) == ReturnObjectToDatetime("1900-1-1"))
                                {
                                    sErr = sErr + "行" + (i + 1).ToString().Trim() + " " + gridCol客户下单日期.Caption + "不正确\n";
                                    continue;
                                }
                                else
                                {
                                    d单据日期 = ReturnObjectToDatetime(gridView内销.GetRowCellValue(i, gridCol客户下单日期));
                                }


                                sSQL = "SELECT * FROM @u8.VoucherHistory WHERE CardNumber = '17' and cSeed = '" + d单据日期.ToString("yyyyMM") + "'";
                                dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    lCode = ReturnObjectToLong(dt.Rows[0]["cNumber"]);
                                }
                                else
                                {
                                    sSQL = "INSERT INTO @u8.VoucherHistory(CardNumber,cContent,cContentRule,cSeed,cNumber,bEmpty)values('17','单据日期','月','" + d单据日期.ToString("yyyyMM") + "',1,0)";
                                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                                }

                                TH.Model.SO_SOMain model = new TH.Model.SO_SOMain();

                                d税率 = ReturnObjectToDecimal(gridView内销.GetRowCellValue(i, gridCol税率), 4);
                                if (d税率 > 100 || d税率 < 0)
                                {
                                    sErr = sErr + "行" + (i + 1).ToString().Trim() + " 税率不正确\n";
                                }

                                long lIDMain = 0;
                                string s单据号 = gridView内销.GetRowCellValue(i, gridCol订单号).ToString().Trim();
                                string s销售订单号 = "";

                                sSQL = "select * from @u8.SO_SODetails where cDefine22 = '" + s单据号 + "'";
                                dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    lIDMain = ReturnObjectToLong(dt.Rows[0]["ID"]);

                                    s销售订单号 = dt.Rows[0]["cSOCode"].ToString().Trim();
                                }
                                else
                                {
                                    lID = lID + 1;
                                    lIDMain = lID;

                                    lCode += 1;

                                    sSQL = "UPDATE @u8.VoucherHistory SET cNumber = 111111 WHERE CardNumber = '17' and cSeed = '" + d单据日期.ToString("yyyyMM") + "'";
                                    sSQL = sSQL.Replace("111111", lCode.ToString());
                                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                    model.cSTCode = "01";
                                    model.dDate = ReturnObjectToDatetime(gridView内销.GetRowCellValue(i, gridCol客户下单日期));
                                    if (model.dDate < ReturnObjectToDatetime("2000-1-1"))
                                    {
                                        sErr = sErr + "行" + (i + 1).ToString().Trim() + " " + gridCol客户下单日期.Caption + "不正确\n";
                                    }

                                    s销售订单号 = sCode(lCode, d单据日期);
                                    model.cSOCode = s销售订单号;
                                    if (model.cSOCode == "")
                                    {
                                        sErr = sErr + "行" + (i + 1).ToString().Trim() + " " + gridCol订单号.Caption + "不正确\n";
                                    }

                                    model.cCusCode = gridView内销.GetRowCellValue(i, gridCol客户名称).ToString().Trim();
                                    if (model.cCusCode == "")
                                    {
                                        sErr = sErr + "行" + (i + 1).ToString().Trim() + " " + gridCol客户编码.Caption + "不正确\n";
                                    }

                                    sSQL = "select * from @u8.Customer where cCusCode = '" + model.cCusCode + "'";
                                    dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                    if (dt != null && dt.Rows.Count > 0)
                                    {
                                        model.cDepCode = dt.Rows[0]["cCusDepart"].ToString().Trim();
                                        model.cPersonCode = dt.Rows[0]["cCusPPerson"].ToString().Trim();
                                    }

                                    model.cexch_name = "人民币";
                                    model.iExchRate = 1;
                                    model.iTaxRate = d税率;
                                    if (FrameBaseFunction.ClsBaseDataInfo.sUserName.Trim() == "")
                                    {
                                        throw new Exception("请设置用户姓名");
                                    }

                                    model.cMaker = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                                    model.bDisFlag = false;
                                    model.bReturnFlag = false;
                                    model.cCusName = gridView内销.GetRowCellDisplayText(i, gridCol客户名称).ToString().Trim();
                                    model.bOrder = false;
                                    model.ID = lIDMain;
                                    model.iVTid = 95;
                                    model.cBusType = gridView内销.GetRowCellValue(i, gridCol业务类型).ToString().Trim();
                                    model.cAccountPDate = ReturnObjectToDatetime(gridView内销.GetRowCellValue(i, gridCol客户下单日期));
                                    if (model.cAccountPDate < ReturnObjectToDatetime("2000-1-1"))
                                    {
                                        sErr = sErr + "行" + (i + 1).ToString().Trim() + " " + gridCol客户下单日期.Caption + "不正确\n";
                                    }


                                    sSQL = DAL.Add(model);
                                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                                }

                                lIDDetail += 1;
                                TH.Model.SO_SODetails models = new TH.Model.SO_SODetails();
                                models.AutoID = lIDDetail;
                                models.cSOCode = s销售订单号;
                                models.cInvCode = gridView内销.GetRowCellValue(i, gridCol品名).ToString().Trim();
                                if (models.cInvCode == "")
                                {
                                    sErr = sErr + "行" + (i + 1).ToString().Trim() + " " + gridCol产品编码.Caption + "不正确\n";
                                }

                                models.dPreDate = ReturnObjectToDatetime(gridView内销.GetRowCellValue(i, gridCol计划交付日期));
                                if (models.dPreDate < ReturnObjectToDatetime("2000-1-1"))
                                {
                                    sErr = sErr + "行" + (i + 1).ToString().Trim() + " " + gridCol计划交付日期.Caption + "不正确\n";
                                }

                                decimal d数量 = ReturnObjectToDecimal(gridView内销.GetRowCellValue(i, gridCol数量), 4);
                                models.iQuantity = d数量;
                                if (models.iQuantity <= 0)
                                {
                                    sErr = sErr + "行" + (i + 1).ToString().Trim() + " " + gridCol数量.Caption + "不正确\n";
                                }

                                if (gridView内销.GetRowCellValue(i, gridCol单计量).ToString().Trim() != "是")
                                {
                                    models.iNum = ReturnObjectToDecimal(gridView内销.GetRowCellValue(i, gridCol辅助数量), 4);
                                    if (models.iNum <= 0)
                                    {
                                        sErr = sErr + "行" + (i + 1).ToString().Trim() + " " + gridCol辅助数量.Caption + "不正确\n";
                                    }
                                }

                                models.iQuotedPrice = 0;

                                if (radio单价计算.Checked)
                                {
                                    decimal d单价 = ReturnObjectToDecimal(gridView内销.GetRowCellValue(i, gridCol单价), 4);
                                    if (d单价 < 0)
                                    {
                                        sErr = sErr + "行" + (i + 1).ToString().Trim() + " 单价不正确\n";
                                    }

                                    models.iUnitPrice = ReturnObjectToDecimal(d单价 / (1 + d税率 / 100), 4);
                                    models.iTaxUnitPrice = d单价;
                                    models.iMoney = ReturnObjectToDecimal(models.iUnitPrice * d数量, 2);
                                    models.iSum = ReturnObjectToDecimal(d单价 * d数量, 2);
                                    models.iTax = models.iSum - models.iMoney;
                                    models.iDisCount = 0;

                                    models.iNatUnitPrice = models.iUnitPrice;
                                    models.iNatMoney = models.iMoney;
                                    models.iNatTax = models.iTax;
                                    models.iNatSum = models.iSum;
                                    models.iNatDisCount = 0;
                                }
                                if (radio总价计算.Checked)
                                {
                                    decimal d总价 = ReturnObjectToDecimal(gridView内销.GetRowCellValue(i, gridCol总价), 2);
                                    decimal d单价 = ReturnObjectToDecimal(d总价 / d数量, 4);

                                    models.iUnitPrice = ReturnObjectToDecimal(d单价 / (1 + d税率 / 100), 4);
                                    models.iTaxUnitPrice = d单价;
                                    models.iMoney = ReturnObjectToDecimal(models.iUnitPrice * d数量, 2);
                                    models.iSum = d总价;
                                    models.iTax = models.iSum - models.iMoney;
                                    models.iDisCount = 0;

                                    models.iNatUnitPrice = models.iUnitPrice;
                                    models.iNatMoney = models.iMoney;
                                    models.iNatTax = models.iTax;
                                    models.iNatSum = models.iSum;
                                    models.iNatDisCount = 0;
                                }

                                models.iSOsID = lIDDetail;
                                models.KL = 100;
                                models.KL2 = 100;
                                models.cInvName = gridView内销.GetRowCellDisplayText(i, gridCol品名).ToString().Trim();


                                if (models.cInvName == "")
                                {
                                    sErr = sErr + "行" + (i + 1).ToString().Trim() + " " + gridCol品名.Caption + "不正确\n";
                                }

                                models.iTaxRate = d税率;

                                if (gridView内销.GetRowCellValue(i, gridCol单计量).ToString().Trim() != "是")
                                {
                                    models.iInvExchRate = ReturnObjectToDecimal(gridView内销.GetRowCellValue(i, gridCol换算率), 4);
                                }
                                models.ID = lIDMain;
                                models.fSaleCost = 0;
                                models.fSalePrice = 0;
                                models.dPreFinishDate = ReturnObjectToDatetime(gridView内销.GetRowCellValue(i, gridCol计划交付日期));
                                models.bMRPs = 0;

                                models.cDefine31 = gridView内销.GetRowCellValue(i, gridCol长度).ToString().Trim();
                                models.cDefine23 = gridView内销.GetRowCellValue(i, gridCol客户图号).ToString().Trim();
                                models.cDefine22 = gridView内销.GetRowCellValue(i, gridCol订单号).ToString().Trim();
                                models.cDefine30 = gridView内销.GetRowCellValue(i, gridCol物料号).ToString().Trim();
                                models.cDefine24 = gridView内销.GetRowCellValue(i, gridCol工地区域).ToString().Trim();
                                models.cDefine25 = gridView内销.GetRowCellValue(i, gridCol项目).ToString().Trim();
                                models.cDefine28 = gridView内销.GetRowCellValue(i, gridCol梯号).ToString().Trim();
                                models.cDefine29 = gridView内销.GetRowCellValue(i, gridCol唛头编号).ToString().Trim();
                                models.cUnitID = gridView内销.GetRowCellValue(i, gridCol计量单位编码).ToString().Trim();
                                models.cMemo = gridView内销.GetRowCellValue(i, gridCol备注).ToString().Trim();

                                sSQL = "SELECT * FROM @u8.pp_q_bomlist WHERE 母件编码 = '" + models.cInvCode + "' AND 母件版本号 = '" + gridView内销.GetRowCellValue(i, gridColBOM版本号).ToString().Trim() + "'";
                                dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    models.cbomsocode = gridView内销.GetRowCellValue(i, gridColBOM版本号).ToString().Trim();
                                }
                                //else
                                //{
                                //    sErr = sErr + "行" + (i + 1).ToString().Trim() + " " + gridColBOM版本号.Caption + "不正确\n";
                                //}


                                sSQL = "select * from @u8.Inventory where cInvCode = '" + models.cInvCode + "' and (cInvCCode like 'A%' or cInvCCode like 'P%')";
                                dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    decimal d单重 = ReturnObjectToDecimal(dt.Rows[0]["iInvWeight"], 4) / 1000;
                                    decimal d = ReturnObjectToDecimal(d单重 * models.iQuantity, 4);
                                    models.cDefine26 = d;
                                }

                                sSQL = Dals.Add(models);
                                iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                        }
                    }

                    #endregion

                    #region 外销

                    if (radio外销.Checked)
                    {
                        #region 判断是否已经导入

                        for (int i = 0; i < gridView外销.RowCount; i++)
                        {
                            string s单据号 = gridView外销.GetRowCellValue(i, gridCol_订单号).ToString().Trim();
                            sSQL = "select * from @u8.SO_SODetails where cDefine22 = '" + s单据号 + "'";
                            dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                sErr = sErr + "单据已经存在 " + s单据号 + "\n";
                            }
                        }
                        if (sErr.Length > 0)
                        {
                            throw new Exception(sErr);
                        }

                        #endregion

                        decimal d税率 = 17;

                        for (int i = 0; i < gridView外销.RowCount; i++)
                        {
                            DateTime d单据日期 = ReturnObjectToDatetime(gridView外销.GetRowCellValue(i, gridCol_下单日期));
                            if (gridView外销.GetRowCellValue(i, gridCol_下单日期).ToString().Trim() == "")
                            {
                                d单据日期 = ReturnObjectToDatetime(DateTime.Now.ToString("yyyy-MM-dd"));
                            }
                            else if (ReturnObjectToDatetime(gridView外销.GetRowCellValue(i, gridCol_下单日期)) == ReturnObjectToDatetime("1900-1-1"))
                            {
                                sErr = sErr + "行" + (i + 1).ToString().Trim() + " " + gridCol_下单日期.Caption + "不正确\n";
                                continue;
                            }
                            else
                            {
                                d单据日期 = ReturnObjectToDatetime(gridView外销.GetRowCellValue(i, gridCol_下单日期));
                            }


                            sSQL = "SELECT * FROM @u8.VoucherHistory WHERE CardNumber = '17' and cSeed = '" + d单据日期.ToString("yyyyMM") + "'";
                            dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                lCode = ReturnObjectToLong(dt.Rows[0]["cNumber"]);
                            }
                            else
                            {
                                sSQL = "INSERT INTO @u8.VoucherHistory(CardNumber,cContent,cContentRule,cSeed,cNumber,bEmpty)values('17','单据日期','月','" + d单据日期.ToString("yyyyMM") + "',1,0)";
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }

                            TH.Model.SO_SOMain model = new TH.Model.SO_SOMain();

                            d税率 = ReturnObjectToDecimal(gridView外销.GetRowCellValue(i, gridCol_税率), 4);
                            if (d税率 > 100 || d税率 < 0)
                            {
                                sErr = sErr + "行" + (i + 1).ToString().Trim() + " 税率不正确\n";
                            }


                            long lIDMain = 0;
                            string s销售订单号 = "";
                            string s单据号 = gridView外销.GetRowCellValue(i, gridCol_订单号).ToString().Trim();
                            sSQL = "select * from @u8.SO_SODetails where cDefine22 = '" + s单据号 + "'";
                            dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                lIDMain = ReturnObjectToLong(dt.Rows[0]["ID"]);
                                s销售订单号 = dt.Rows[0]["cSOCode"].ToString().Trim();
                            }
                            else
                            {
                                lID = lID + 1;
                                lIDMain = lID;

                                lCode += 1;


                                sSQL = "UPDATE @u8.VoucherHistory SET cNumber = 111111 WHERE CardNumber = '17' and cSeed = '" + d单据日期.ToString("yyyyMM") + "'";
                                sSQL = sSQL.Replace("111111", lCode.ToString());
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                model.cSTCode = "X";
                                model.dDate = ReturnObjectToDatetime(gridView外销.GetRowCellValue(i, gridCol_下单日期));
                                if (model.dDate < ReturnObjectToDatetime("2000-1-1"))
                                {
                                    sErr = sErr + "行" + (i + 1).ToString().Trim() + " " + gridCol_下单日期.Caption + "不正确\n";
                                }

                                s销售订单号 = sCode(lCode, d单据日期);
                                model.cSOCode = s销售订单号;
                                if (model.cSOCode == "")
                                {
                                    sErr = sErr + "行" + (i + 1).ToString().Trim() + " " + gridCol_订单号.Caption + "不正确\n";
                                }

                                model.cCusCode = gridView外销.GetRowCellValue(i, gridCol_客户).ToString().Trim();
                                if (model.cCusCode == "")
                                {
                                    sErr = sErr + "行" + (i + 1).ToString().Trim() + " " + gridCol_客户编码.Caption + "不正确\n";
                                }

                                sSQL = "select * from @u8.Customer where cCusCode = '" + model.cCusCode + "'";
                                dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    model.cDepCode = dt.Rows[0]["cCusDepart"].ToString().Trim();
                                    model.cPersonCode = dt.Rows[0]["cCusPPerson"].ToString().Trim();
                                }

                                model.cDefine2 = gridView外销.GetRowCellValue(i, gridCol_计价方式).ToString().Trim();
                                //if (model.cDepCode == "")
                                //{
                                //    sErr = sErr + "行" + (i + 1).ToString().Trim() + " 销售部门不正确\n";
                                //}

                                string s币种 = gridView外销.GetRowCellValue(i, gridCol_货币单位).ToString().Trim();
                                sSQL = "select * from @u8.foreigncurrency where cexch_code = '111111' OR cexch_name = '111111'";
                                sSQL = sSQL.Replace("111111", s币种);
                                dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                if(dt == null || dt.Rows.Count ==0)
                                {
                                    sErr = sErr + "行" + (i + 1).ToString().Trim() + " " + gridCol_货币单位.Caption + "不正确\n";
                                }
                                model.cexch_name = dt.Rows[0]["cexch_name"].ToString().Trim();


                                model.iExchRate = ReturnObjectToDecimal(gridView外销.GetRowCellValue(i, gridCol_汇率), 4);
                                if (model.iExchRate <= 0)
                                {
                                    sErr = sErr + "行" + (i + 1).ToString().Trim() + " " + gridCol_汇率.Caption + "不正确\n";
                                }
                           
                                model.iTaxRate = d税率;
                                model.cMaker = FrameBaseFunction.ClsBaseDataInfo.sUid;
                                model.bDisFlag = false;
                                model.bReturnFlag = false;
                                model.cCusName = gridView外销.GetRowCellDisplayText(i, gridCol_客户).ToString().Trim();
                                model.bOrder = false;
                                model.ID = lIDMain;
                                model.iVTid = 95;
                                model.cBusType = "普通销售";
                                model.cAccountPDate = ReturnObjectToDatetime(gridView外销.GetRowCellValue(i, gridCol_下单日期));
                                if (model.cAccountPDate < ReturnObjectToDatetime("2000-1-1"))
                                {
                                    sErr = sErr + "行" + (i + 1).ToString().Trim() + " " + gridCol_下单日期.Caption + "不正确\n";
                                }

                                model.cDefine1 = gridView外销.GetRowCellValue(i,gridCol_付款方式).ToString().Trim();

                                sSQL = DAL.Add(model);
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }

                            lIDDetail += 1;
                            TH.Model.SO_SODetails models = new TH.Model.SO_SODetails();
                            models.AutoID = lIDDetail;
                            models.cSOCode = s销售订单号;
                            models.cInvCode = gridView外销.GetRowCellValue(i, gridCol_品名).ToString().Trim();
                            if (models.cInvCode == "")
                            {
                                sErr = sErr + "行" + (i + 1).ToString().Trim() + " " + gridCol_产品编码.Caption + "不正确\n";
                            }

                            models.dPreDate = ReturnObjectToDatetime(gridView外销.GetRowCellValue(i, gridCol_下单日期));
                            if (models.dPreDate < ReturnObjectToDatetime("2000-1-1"))
                            {
                                sErr = sErr + "行" + (i + 1).ToString().Trim() + " " + gridCol_下单日期.Caption + "不正确\n";
                            }

                            decimal d数量 = ReturnObjectToDecimal(gridView外销.GetRowCellValue(i, gridCol_数量), 4);
                            models.iQuantity = d数量;
                            if (models.iQuantity <= 0)
                            {
                                sErr = sErr + "行" + (i + 1).ToString().Trim() + " " + gridCol_数量.Caption + "不正确\n";
                            }

                            if (gridView外销.GetRowCellValue(i, gridCol_单计量).ToString().Trim() != "是")
                            {
                                models.iNum = ReturnObjectToDecimal(gridView外销.GetRowCellValue(i, gridCol_支数), 4);
                                if (models.iNum < 0)
                                {
                                    sErr = sErr + "行" + (i + 1).ToString().Trim() + " " + gridCol_支数.Caption + "不正确\n";
                                }
                            }

                            models.iQuotedPrice = 0;

                            decimal d单价 = ReturnObjectToDecimal(gridView外销.GetRowCellValue(i, gridCol_单价), 4);
                            if (d单价 < 0)
                            {
                                sErr = sErr + "行" + (i + 1).ToString().Trim() + " 单价不正确\n";
                            }

                            models.iUnitPrice = ReturnObjectToDecimal(d单价 / (1 + d税率 / 100), 4);
                            models.iTaxUnitPrice = d单价;
                            models.iMoney = ReturnObjectToDecimal(models.iUnitPrice * d数量, 2);
                            models.iSum = ReturnObjectToDecimal(d单价 * d数量, 2);
                            models.iTax = models.iSum - models.iMoney;
                            models.iDisCount = 0;

                            decimal d汇率 = ReturnObjectToDecimal(gridView外销.GetRowCellValue(i,gridCol_汇率),4);
                            models.iNatUnitPrice = ReturnObjectToDecimal(models.iUnitPrice * d汇率,4);
                            models.iNatMoney = ReturnObjectToDecimal(models.iMoney * d汇率,2);
                            models.iNatSum =ReturnObjectToDecimal(models.iSum *  d汇率,2);
                            models.iNatTax =  models.iNatSum -   models.iNatMoney;
                            models.iNatDisCount = 0;

                            models.iSOsID = lIDDetail;
                            models.KL = 100;
                            models.KL2 = 100;
                            models.cInvName = gridView外销.GetRowCellDisplayText(i, gridCol_品名).ToString().Trim();
                            if (models.cInvName == "")
                            {
                                sErr = sErr + "行" + (i + 1).ToString().Trim() + " " + gridCol_品名.Caption + "不正确\n";
                            }

                            models.iTaxRate = d税率;

                            if (gridView外销.GetRowCellValue(i, gridCol_单计量).ToString().Trim() != "是")
                            {
                                models.iInvExchRate = ReturnObjectToDecimal(gridView外销.GetRowCellValue(i, gridCol_换算率), 4);
                            }
                            models.ID = lIDMain;
                            models.fSaleCost = 0;
                            models.fSalePrice = 0;

                            if (gridView外销.GetRowCellValue(i, gridCol_检测日期).ToString().Trim() == "")
                            {
                                models.dPreFinishDate = ReturnObjectToDatetime(DateTime.Now.ToString("yyyy-MM-dd"));
                            }
                            else if (ReturnObjectToDatetime(gridView外销.GetRowCellValue(i, gridCol_检测日期)) == ReturnObjectToDatetime("1900-1-1"))
                            {
                                sErr = sErr + "行" + (i + 1).ToString().Trim() + " " + gridCol_检测日期.Caption + "不正确\n";
                            }
                            else
                            {
                                models.dPreFinishDate = ReturnObjectToDatetime(gridView外销.GetRowCellValue(i, gridCol_检测日期));
                            }

                            models.bMRPs = 0;
                            models.cUnitID = gridView外销.GetRowCellValue(i, gridCol_计量单位编码).ToString().Trim();

                            models.cDefine22 = gridView外销.GetRowCellValue(i, gridCol_订单号).ToString().Trim();
                            models.cDefine23 = gridView外销.GetRowCellValue(i, gridCol_客户图号).ToString().Trim();
                            models.cDefine30 = gridView外销.GetRowCellValue(i, gridCol_客户编码).ToString().Trim();

                            if (gridView外销.GetRowCellValue(i, gridCol_客户要求交期).ToString().Trim() == "")
                            {
                                models.dPreFinishDate = ReturnObjectToDatetime(DateTime.Now.ToString("yyyy-MM-dd"));
                            }
                            else if (ReturnObjectToDatetime(gridView外销.GetRowCellValue(i, gridCol_客户要求交期)) == ReturnObjectToDatetime("1900-1-1"))
                            {
                                sErr = sErr + "行" + (i + 1).ToString().Trim() + " " + gridCol_客户要求交期.Caption + "不正确\n";
                            }
                            else
                            {
                                models.cDefine36 = ReturnObjectToDatetime(gridView外销.GetRowCellValue(i, gridCol_客户要求交期));
                            }

                            models.cMemo = gridView外销.GetRowCellValue(i, gridCol_备注).ToString().Trim();
                            sSQL = "SELECT * FROM @u8.pp_q_bomlist WHERE 母件编码 = '" + models.cInvCode + "' AND 母件版本号 = '" + gridView外销.GetRowCellValue(i, gridCol_BOM版本号).ToString().Trim() + "'";
                            dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                models.cbomsocode = gridView外销.GetRowCellValue(i, gridCol_BOM版本号).ToString().Trim();
                            }
                            //else
                            //{
                            //    sErr = sErr + "行" + (i + 1).ToString().Trim() + " " + gridCol_BOM版本号.Caption + "不正确\n";
                            //}


                            sSQL = "select * from @u8.Inventory where cInvCode = '" + models.cInvCode + "' and (cInvCCode like 'A%' or cInvCCode like 'P%')";
                            dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                decimal d单重 = ReturnObjectToDecimal(dt.Rows[0]["iInvWeight"], 4) / 1000;
                                decimal d = ReturnObjectToDecimal(d单重 * models.iQuantity, 4);
                                models.cDefine26 = d;
                            }

                            sSQL = Dals.Add(models);
                            iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                    }

                    #endregion


                    sSQL = "UPDATE UFSystem..UA_Identity SET iFatherId = 111111,iChildId = 222222 WHERE cAcc_Id = '333333' AND cVouchType = 'Somain'";
                    sSQL = sSQL.Replace("111111", lID.ToString());
                    sSQL = sSQL.Replace("222222", lIDDetail.ToString());
                    sSQL = sSQL.Replace("333333", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3));
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    //sSQL = "UPDATE @u8.VoucherHistory SET cNumber = 111111 WHERE CardNumber = '17' and cSeed = '" +  + "'";
                    //sSQL = sSQL.Replace("111111", lCode.ToString());
                    //DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    if (sErr.Trim() != "")
                        throw new Exception(sErr);

                    tran.Commit();

                    if (iCou > 0)
                    {
                        MessageBox.Show("保存成功");

                        gridControl内销.DataSource = null;
                        gridControl外销.DataSource = null;
                    }
                }
                catch (Exception error)
                {
                    tran.Rollback();

                    //MessageBox.Show(iErr.ToString());
                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        /// <summary>
        /// 撤销
        /// </summary>
        private void btnUnDo()
        {
 
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
            throw new NotImplementedException();
        }

        #endregion

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                btnRefresh();

                radio_CheckedChanged(null, null);
           
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
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

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            gridControl外销.DataSource = null;
            gridControl内销.DataSource = null;

            if (radio内销.Checked)
            {
                layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            if (radio外销.Checked)
            {
                layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
        }

        private void SetLookup()
        {
            string sSQL = "SELECT cCusCode,cCusName,cCusAbbName FROM @u8.Customer ORDER BY cCusCode";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit客户简称.DataSource = dt;
            ItemLookUpEdit客户名称.DataSource = dt;

            ItemLookUpEdit_客户.DataSource = dt;

            sSQL = "SELECT cInvCode,cInvName,cInvStd FROM @u8.Inventory ORDER BY cInvCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit存货名称.DataSource = dt;
            ItemLookUpEdit存货规格.DataSource = dt;

            ItemLookUpEdit_存货名称.DataSource = dt;
            ItemLookUpEdit_存货规格.DataSource = dt;
        }

        private string sCode(long lCode,DateTime d单据日期)
        { 
            string sCode = lCode.ToString().Trim();
            while (sCode.Length < 5)
            {
                sCode = "0" + sCode;
            }
            sCode = "SO" + d单据日期.ToString("yyyyMM") + sCode;

            return sCode;
        }
    }
}
