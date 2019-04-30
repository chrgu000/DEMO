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
    public partial class FrmPrintBarCode2 : FrameBaseFunction.FrmBaseInfo
    {
        public FrmPrintBarCode2()
        {
            InitializeComponent();

            #region 禁止用户调整表格
            gridView1.OptionsMenu.EnableColumnMenu = false;
            gridView1.OptionsMenu.EnableFooterMenu = false;
            gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            gridView1.OptionsMenu.ShowAutoFilterRowItem = false;
            gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            gridView1.OptionsMenu.ShowGroupSummaryEditorItem = false;
            gridView1.OptionsMenu.ShowAddNewSummaryItem  = DevExpress.Utils.DefaultBoolean.False;
            gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            gridView1.OptionsCustomization.AllowColumnMoving = false;
            //gridView1.OptionsCustomization.

            #endregion

            sLayoutHeadPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Head.xml";
            sLayoutGridPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Grid.xml";

            if (File.Exists(sLayoutHeadPath))
                layoutControl1.RestoreLayoutFromXml(sLayoutHeadPath);

            if (File.Exists(sLayoutGridPath))
            {
                gridControl1.MainView.RestoreLayoutFromXml(sLayoutGridPath);
            }

            dtBingGrid = new DataTable();
            dtBingHead = new DataTable();
        }

        FrameBaseFunction.RepBaseGrid Rep = new FrameBaseFunction.RepBaseGrid();
       

        #region 按钮操作
        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "add":
                        btnAdd();
                        break;
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
                    case "printset":
                        btnPrintSet();
                        break;
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

        private void btnAdd()
        {
            try
            {
                string sBarCode = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["条形码"]).ToString().Trim();
                DialogResult d = MessageBox.Show("是否复制条码" + sBarCode + "相关信息并形成新条码", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (d != DialogResult.Yes)
                    return;

                string sErr = "";
                int iCount = 0;
                SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    string s单据序号 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["单据序号"]).ToString().Trim();
                    sSQL = "SELECT TOP 1 * from  _BarCodeList where DetailsID = '" + s单据序号 + "' ORDER BY iid desc";
                    DataTable dtMax = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtMax == null || dtMax.Rows.Count == 0)
                    {
                        throw new Exception("条码信息错误");
                    }

                    string[] s = dtMax.Rows[0]["BarCode"].ToString().Trim().Split('-');
                    int iXH = ReturnObjectToInt(s[1]) + 1;

                    string sNewBarCode = s单据序号 + "-" + iXH.ToString();

                    sSQL = @"
INSERT INTO _BarCodeList(BarCode, Qty, DetailsID, CreateUid, CreateDate,  PrintCount)
SELECT 'bbbbbb', Qty, DetailsID, 'cccccc', getdate(), 1
FROM      _BarCodeList
WHERE barcode = 'aaaaaa' 
";
                    sSQL = sSQL.Replace("aaaaaa", sBarCode);
                    sSQL = sSQL.Replace("bbbbbb", sNewBarCode);
                    sSQL = sSQL.Replace("cccccc", FrameBaseFunction.ClsBaseDataInfo.sUid);
                    iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    if (sErr.Trim() != "")
                    {
                        throw new Exception(sErr);
                    }

                    tran.Commit();

                    MessageBox.Show("条码复制成功:" + sNewBarCode);

                    GetGrid();
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnPrintSet()
        {
            try
            {
                if (!Directory.Exists(sProPath + "\\print"))
                    Directory.CreateDirectory(sProPath + "\\print");

                if (File.Exists(sPrintLayOutMod))
                {
                    Rep.LoadLayout(sPrintLayOutMod);
                }

                Rep.ShowDesignerDialog();

                DialogResult d = MessageBox.Show("是否保存?模板调整将在下次打开窗体时体现\n是：保存打印模板\n", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (DialogResult.Yes == d)
                {
                    Rep.SaveLayoutToXml(sPrintLayOutMod);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }


        #region 按钮模板

        /// <summary>
        /// 将表格中Lookup之类的保存ID的数据转换成Text用于打印
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        //private DataTable SetPrintData(DataTable dt)
        //{
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

        //    return dt;
        //}

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

            try
            {
                Rep = new FrameBaseFunction.RepBaseGrid();

                sPrintLayOutMod = sPrintLayOutMod.Replace("再次打印条码", "打印条码");
                if (File.Exists(sPrintLayOutMod))
                {
                    Rep.LoadLayout(sPrintLayOutMod);
                }
                else
                {
                    MessageBox.Show("加载报表模板失败，请与管理员联系");
                    return;
                }

                Rep.dsPrint.Tables.Clear();
                string sErr = "";
                int iCount = 0;
                SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    string sSQL = "select getdate()";
                    DateTime dNow = Convert.ToDateTime(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                    if (dNow > Convert.ToDateTime("2016-10-15"))
                    {
                        throw new Exception("打印条码失败");
                    }

                    DataTable dt = ((DataTable)gridControl1.DataSource).Copy();
                    for (int i = dt.Rows.Count - 1; i >= 0; i--)
                    {
                        if (ReturnObjectToBool(dt.Rows[i]["选择"]))
                            continue;

                        else
                            dt.Rows.RemoveAt(i);
                    }
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DAL._BarCodeList dal = new ImportDLL.DAL._BarCodeList();
                        sSQL = dal.Exists(dt.Rows[i]["条形码"].ToString().Trim());
                        DataTable dtExists = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if(dtExists == null || dtExists.Rows.Count == 0)
                        {
                            sErr = sErr + "条码 " + dt.Rows[i]["条形码"].ToString().Trim() + "不存在\n";
                            continue;
                        }

                        sSQL = "update [_BarCodeList] set RePrintUid = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "', RePrintDate = getdate(), PrintCount = isnull(PrintCount,0) + 1 where BarCode = '" + dt.Rows[i]["条形码"] + "'";
                        iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                    if (sErr.Trim() != "")
                    {
                        throw new Exception(sErr);
                    }

                    DataTable dtGrid = dt.Copy();
                    tran.Commit();

                    dtGrid.TableName = "dtGrid";
                    Rep.dsPrint.Tables.Add(dtGrid);

                    if (Rep.dsPrint == null)
                        throw new Exception("没有需要打印的数据");

                    Rep.ShowPreview();
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
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
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
                sF.Filter = "Excel文件(*.xls)|*.xls|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridView1.ExportToXls(sF.FileName);
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

        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void btnRefresh()
        {
            GetGrid();
            gridView1.OptionsBehavior.Editable = false;
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
            GetGrid();
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
            gridView1.AddNewRow();
        }
        /// <summary>
        /// 删行
        /// </summary>
        private void btnDelRow()
        {
            //for (int i = gridView1.RowCount - 1; i >= 0 ; i--)
            //{
            //    if (gridView1.IsRowSelected(i))
            //    {
            //        gridView1.DeleteRow(i);
            //    }
            //}
        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {
            gridView1.OptionsBehavior.Editable = true;
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
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            try
            {
                string sErr = "";
                int iCou = 0;
                SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    string sSQL = "select getdate()";
                    DateTime dNow = Convert.ToDateTime(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (ReturnObjectToBool(gridView1.GetRowCellValue(i, gridView1.Columns["选择"])))
                        {
                            sSQL = "update [_BarCodeList] set [BarCode] = '" + gridView1.GetRowCellValue(i, gridView1.Columns["条形码"]).ToString().Trim() + "' where [BarCode2] = '" + gridView1.GetRowCellValue(i, gridView1.Columns["条形码2"]).ToString().Trim() + "'";
                            iCou += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                    }

                    tran.Commit();

                    if (iCou > 0)
                    {
                        MessageBox.Show("保存成功");
                    }
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
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
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            try
            {
                string sErr = "";
                int iCount = 0;
                SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (!ReturnObjectToBool(gridView1.GetRowCellValue(i, gridView1.Columns["选择"])))
                            continue;

                        DAL._BarCodeList dal = new ImportDLL.DAL._BarCodeList();
                        string s条形码 = gridView1.GetRowCellValue(i, gridView1.Columns["条形码"]).ToString().Trim();
                        sSQL = dal.Exists(s条形码);
                        DataTable dtExists = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtExists == null || dtExists.Rows.Count == 0)
                        {
                            sErr = sErr + "条码 " + s条形码 + "不存在\n";
                            continue;
                        }

                        sSQL = "update [_BarCodeList] set DelUid = null, DelDate = getdate() where BarCode = '" + s条形码 + "'";
                        iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                    if (sErr.Trim() != "")
                    {
                        throw new Exception(sErr);
                    }

                    tran.Commit();

                    GetGrid();
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        /// <summary>
        /// 关闭
        /// </summary>
        private void btnClose()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            try
            {
                string sErr = "";
                int iCount = 0;
                SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if(!ReturnObjectToBool(gridView1.GetRowCellValue(i,gridView1.Columns["选择"])))
                            continue;

                        DAL._BarCodeList dal = new ImportDLL.DAL._BarCodeList();
                        string s条形码 = gridView1.GetRowCellValue(i,gridView1.Columns["条形码"]).ToString().Trim();
                        sSQL = dal.Exists(s条形码);
                        DataTable dtExists = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtExists == null || dtExists.Rows.Count == 0)
                        {
                            sErr = sErr + "条码 " + s条形码 + "不存在\n";
                            continue;
                        }

                        sSQL = "update [_BarCodeList] set DelUid = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "', DelDate = getdate() where BarCode = '" + s条形码 + "'";
                        iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                    if (sErr.Trim() != "")
                    {
                        throw new Exception(sErr);
                    }

                    tran.Commit();

                    GetGrid();
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
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
                dateEdit1.DateTime = DateTime.Today;
                dateEdit2.DateTime = DateTime.Today;

                SetLookup();
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void SetLookup()
        {
            string sSQL = "select code from [ST_RDRecord] where idvouchertype = 17";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            lookUpcode.Properties.DataSource = dt;
        }

        private void GetGrid()
        {
            string sSQL = @"
SELECT cast(0 as bit) as 选择
    ,d.BarCode as 条形码, a.code AS 单据号,a.voucherdate AS 单据日期,a.pubuserdefnvc1 AS 理货员,a.pubuserdefnvc2 AS 货主
	,c.code AS 存货编码,c.name AS 存货名称,c.specification AS 规格型号
	,cast(b.quantity as decimal(16,2)) AS 数量,cast(b.quantity2 as decimal(16,0)) AS 数量2
	,b.inventoryLocation AS 货位,b.freeItem0 AS 货主,b.freeItem1 AS 产地,b.freeItem2 AS 厂商,b.freeItem3 AS 包装规格,b.freeItem4 AS 货权方
    ,b.freeItem5 AS 提单号
	,b.freeItem6 AS 合同号
	,b.ID as 单据序号
    ,d.BarCode2 as 条形码2
FROM [dbo].[ST_RDRecord] a INNER JOIN [dbo].[ST_RDRecord_b] b ON a.id = b.idRDRecordDTO 
	INNER JOIN AA_Inventory c ON b.idinventory = c.id
    inner join _BarCodeList d on b.id = d.DetailsID
WHERE 1=1 AND a.idvouchertype = 17 
order by b.ID,d.iID
";
            if (lookUpcode.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.code = '" + lookUpcode.Text.Trim() + "'");
            }
            if (dateEdit1.Text != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.voucherdate >= '" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "'");
            }
            if (dateEdit2.Text != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.voucherdate < '" + dateEdit2.DateTime.AddDays(1).ToString("yyyy-MM-dd") + "'");
            }
            if (radio正常.Checked)
            { 
                sSQL  = sSQL.Replace("1=1","1=1 and isnull(d.DelUid,'') = '' ");
            }
            if (radio作废.Checked)
            {
                sSQL  = sSQL.Replace("1=1","1=1 and isnull(d.DelUid,'') <> '' ");
            }

            dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dtBingGrid;
            gridView1.BestFitColumns();

            gridView1.OptionsBehavior.Editable = true;
            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                if (gridView1.Columns[i].FieldName.ToLower() == "选择" || gridView1.Columns[i].FieldName.ToLower() == "条形码")
                {
                    gridView1.Columns[i].OptionsColumn.AllowEdit = true;
                    gridView1.Columns[i].OptionsColumn.ReadOnly = false;
                }
                else
                {
                    gridView1.Columns[i].OptionsColumn.AllowEdit = false;
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

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                bool b = ReturnObjectToBool(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["选择"]));
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle,gridView1.Columns["选择"],!b);
            }
            catch { }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column != gridView1.Columns["选择"])
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["选择"], true);
                }
            }
            catch { }
        }
    }
}
