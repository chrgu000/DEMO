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
using System.Data.SqlClient;
using 系统服务;

namespace 成衣生产
{
    public partial class Frm销售出库 : 系统服务.FrmBaseInfo
    {
        public string 单据号1 = "";
        public string 单据号2 = "";
        public string 单据日期1 = "";
        public string 单据日期2 = "";
        public string 制单日期1 = "";
        public string 制单日期2 = "";
        public string 业务员 = "";
        public string 部门 = "";
        public string 客户 = "";
        public string 审核日期1 = "";
        public string 审核日期2 = "";
        public string 制单人1 = "";
        public string 制单人2 = "";
        public string 审核人1 = "";
        public string 审核人2 = "";
        public string 款号1 = "";
        public string 款号2 = "";

        public Frm销售出库()
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
            gridView1.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.False;
            gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            gridView1.OptionsCustomization.AllowColumnMoving = false;
            //gridView1.OptionsCustomization.

            #endregion

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
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            base.dsPrint.Tables.Clear();
            DataTable dtGrid = SetPrintData(((DataTable)gridControl1.DataSource).Copy());
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
            gridView1.OptionsBehavior.ReadOnly = false;
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            try
            {
                DialogResult d = MessageBox.Show("确定删除选中行么？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (d != DialogResult.Yes)
                    return;

                string sErr = "";
                int iCount = 0;
                SqlConnection conn = new SqlConnection(系统服务.ClsBaseDataInfo.sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                string sSQL = "";
                try
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        bool bCheck = ReturnBool(gridView1.GetRowCellValue(i, gridCol选择));
                        if (!bCheck)
                            continue;

                        DAL.成品出入库 dal = new 成衣生产.DAL.成品出入库();

                        long iID = ReturnLong(gridView1.GetRowCellValue(i, gridColiID));
                        sSQL = "select iID from  成品出入库 where isnull(审核人,'') <> '' and iID = " + iID.ToString();
                        DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            throw new Exception("行" + (i + 1).ToString() + " 已经审核\n");
                        }

                        if (sErr != "")
                        {
                            throw new Exception(sErr);
                        }

                        sSQL = dal.Delete(iID);
                        iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    if (iCount > 0)
                    {
                        tran.Commit();

                        MessageBox.Show("OK\n");

                        int iRow = gridView1.FocusedRowHandle;
                        GetGrid();
                        gridView1.FocusedRowHandle = iRow;
                    }
                    else
                    {
                        throw new Exception("请选择需要保存的数据" + sErr);
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
                int iCount = 0;
                SqlConnection conn = new SqlConnection(系统服务.ClsBaseDataInfo.sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                string sSQL = "";
                try
                {

                    DataTable dt = (DataTable)gridControl1.DataSource;
                    string sErrRow = "";
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (!ReturnBool(dt.Rows[i]["选择"]))
                            continue;

                        DataRow dr = dt.Rows[i];
                        Model.成品出入库 model = new 成衣生产.Model.成品出入库();
                        DAL.成品出入库 dal = new 成衣生产.DAL.成品出入库();
                        model = dal.DataRowToModel(dr);

                        if (model.客户.Trim() == "")
                        {
                            sErrRow = sErrRow + "行" + (i + 1).ToString() + "客户不能为空\n";
                        }
                        if (model.生产.Trim() == "")
                        {
                            sErrRow = sErrRow + "行" + (i + 1).ToString() + "生产不能为空\n";
                        }
                        if (model.类别.Trim() == "")
                        {
                            sErrRow = sErrRow + "行" + (i + 1).ToString() + "类别不能为空\n";
                        }
                        if (model.款号.Trim() == "")
                        {
                            sErrRow = sErrRow + "行" + (i + 1).ToString() + "款号不能为空\n";
                        }
                        if (model.纱种.Trim() == "")
                        {
                            sErrRow = sErrRow + "行" + (i + 1).ToString() + "纱种不能为空\n";
                        }
                        if (ReturnDecimal(model.数量) == 0)
                        {
                            sErrRow = sErrRow + "行" + (i + 1).ToString() + "请填写数量\n";
                        }

                        sSQL = "select sum(数量) from 生产计划 where 1=1 and iID='" + model.生产计划iID + "'";
                        decimal 生产计划数量 = ReturnDecimal(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);

                        sSQL = "select sum(数量) from 成品出入库 where 1=1 and 生产计划iID='" + model.生产计划iID + "' and iID<>" + model.iID + "";
                        decimal 已入库数量 = ReturnDecimal(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                        if (生产计划数量 - 已入库数量 < ReturnDecimal(model.数量))
                        {
                            sErrRow = sErrRow + "行" + (i + 1).ToString() + "生产计划数量不足，当前可完工数量" + (生产计划数量 - 已入库数量) + "\n";
                        }
                        
                        if (sErrRow != "")
                        {
                            sErr = sErr + sErrRow;
                            continue;
                        }

                        sSQL = dal.Exists(model.iID);
                        bool bExists = ReturnBool(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                        if (bExists && model.iID!=0)
                        {
                            sSQL = dal.Update(model);
                            iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        else
                        {
                            model.制单人 = 系统服务.ClsBaseDataInfo.sUserName;
                            model.制单日期 = DateTime.Now;

                            sSQL = dal.Add(model);
                            iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                    }
                    if (sErr != "")
                    {
                        throw new Exception(sErr);
                    }
                    if (iCount > 0)
                    {
                        tran.Commit();

                        MessageBox.Show("OK\n");

                        int iRow = gridView1.FocusedRowHandle;
                        GetGrid();
                        gridView1.FocusedRowHandle = iRow;
                    }
                    else
                    {
                        throw new Exception(sErrRow);
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
                FrmMsgBox msgbox = new FrmMsgBox();
                msgbox.richTextBox1.Text = ee.Message;
                msgbox.Text = "提示";
                msgbox.ShowDialog();
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
                SqlConnection conn = new SqlConnection(系统服务.ClsBaseDataInfo.sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                string sSQL = "";
                try
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        bool bCheck = ReturnBool(gridView1.GetRowCellValue(i, gridCol选择));
                        if (!bCheck)
                            continue;

                        DAL.成品出入库 dal = new 成衣生产.DAL.成品出入库();

                        long iID = ReturnLong(gridView1.GetRowCellValue(i, gridColiID));
                        sSQL = "select iID from  成品出入库 where isnull(审核人,'') <> '' and iID = " + iID.ToString();
                        DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            continue;
                        }

                        sSQL = "update 成品出入库 set 审核人 = '" + 系统服务.ClsBaseDataInfo.sUserName + "',审核日期 = getdate() where iID = " + iID.ToString();
                        iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    if (iCount > 0)
                    {
                        tran.Commit();

                        MessageBox.Show("OK\n");

                        int iRow = gridView1.FocusedRowHandle;
                        GetGrid();
                        gridView1.FocusedRowHandle = iRow;
                    }
                    else
                    {
                        throw new Exception("请选择需要保存的数据" + sErr);
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
        /// 弃审
        /// </summary>
        private void btnUnAudit()
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
                SqlConnection conn = new SqlConnection(系统服务.ClsBaseDataInfo.sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                string sSQL = "";
                try
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        bool bCheck = ReturnBool(gridView1.GetRowCellValue(i, gridCol选择));
                        if (!bCheck)
                            continue;

                        DAL.成品出入库 dal = new 成衣生产.DAL.成品出入库();

                        long iID = ReturnLong(gridView1.GetRowCellValue(i, gridColiID));

                        ///
                        ///需要增加弃审验证，已使用的不可弃审
                        ///

                        sSQL = "update 成品出入库 set 审核人 = null,审核日期 = null where iID = " + iID.ToString();
                        iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    if (iCount > 0)
                    {
                        tran.Commit();

                        MessageBox.Show("OK\n");

                        int iRow = gridView1.FocusedRowHandle;
                        GetGrid();
                        gridView1.FocusedRowHandle = iRow;
                    }
                    else
                    {
                        throw new Exception("请选择需要保存的数据" + sErr);
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

        private void Frm销售出库_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookUpEdit();
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void GetGrid()
        {
            string sSQL = @"
select cast(0 as bit) as 选择
    ,iID, 生产计划iID, 单据日期, 客户, 生产, 类别, 款号, 纱种, 数量, 质量评定, 备注, 制单人, 制单日期, 审核人, 
                审核日期, 关闭人, 关闭日期, 变更人, 变更日期
FROM     成品出入库 where 出入库类别='02'
order by iID
";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;

            for (int i = 0; i < 10; i++)
            {
                gridView1.AddNewRow();
            }

            gridView1.BestFitColumns();
        }


        /// <summary>
        /// 下拉列表框
        /// </summary>
        private void SetLookUpEdit()
        {
            DbHelperSQL.connectionString = 系统服务.ClsBaseDataInfo.sConnString;
            系统服务.LookUp._LoopUpData(ItemLookUpEdit类别, "30");
            系统服务.LookUp._LoopUpData(ItemLookUpEdit质量评定, "32");

            string sSQL = @"SELECT distinct 款号 FROM [dbo].[尺码信息] ORDER BY 款号";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit款号.Properties.DataSource = dt;

            dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "cCode";
            dt.Columns.Add(dc);
            DataRow dr = dt.NewRow();
            dr["cCode"] = "工厂";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["cCode"] = "生产门店";
            dt.Rows.Add(dr);
            ItemLookUpEdit生产.Properties.DataSource = dt;

            sSQL = "select cCode,cName from 纱种 order by cCode";
            dt = DbHelperSQL.Query(sSQL);
            ItemLookUpEdit纱种.Properties.DataSource = dt;

        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                int iRow = gridView1.FocusedRowHandle;
                if (e.Column != gridCol选择)
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridCol选择, true);
                }

                if (e.Column == gridCol生产计划iID && gridView1.FocusedRowHandle == gridView1.RowCount - 1)
                {
                    gridView1.AddNewRow();
                    gridView1.FocusedRowHandle = iRow;
                }
                
                if (e.Column == gridCol数量)
                {
                    DataRow dr = ((System.Data.DataRowView)gridView1.GetRow(iRow)).Row;
                    Model.成品出入库 model = new 成衣生产.Model.成品出入库();
                    DAL.成品出入库 dal = new 成衣生产.DAL.成品出入库();
                    model = dal.DataRowToModel(dr);
                    sSQL = "select sum(数量) from 生产计划 where 1=1 and iID='" + model.生产计划iID + "'";
                    decimal 生产计划数量 = ReturnDecimal(clsSQLCommond.ExecQuery(sSQL).Rows[0][0]);

                    sSQL = "select sum(数量) from 成品出入库 where 1=1 and 生产计划iID='" + model.生产计划iID + "' and iID<>" + model.iID + "";
                    decimal 已入库数量 = ReturnDecimal(clsSQLCommond.ExecQuery(sSQL).Rows[0][0]);
                    if (生产计划数量 - 已入库数量 < ReturnDecimal(model.数量))
                    {
                        throw new Exception("行" + (iRow + 1).ToString() + "生产计划数量不足，当前可完工数量" + (生产计划数量 - 已入库数量));
                        gridView1.SetRowCellValue(iRow, gridCol数量, 生产计划数量 - 已入库数量);
                    }
                }

            }
            catch { }
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
                sSQL = "select  isnull(制单人,'') as 制单人,isnull(审核人,'') as 审核人,isnull(关闭人,'') as 关闭人 from 成品出入库 where 单据号 = '" + sCode + "'";
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

        public bool FolderExists(string Folder)
        {
            if (System.IO.Directory.Exists(Folder) == false)
            {

                System.IO.Directory.CreateDirectory(Folder);
            }
            return true;
        }


    }
}
