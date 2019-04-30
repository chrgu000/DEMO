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
    public partial class Frm生产计划 : 系统服务.FrmBaseInfo
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

        public Frm生产计划()
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

                        DAL.生产计划 dal = new 成衣生产.DAL.生产计划();

                        long iID = ReturnLong(gridView1.GetRowCellValue(i, gridColiID));
                        sSQL = "select iID from  生产计划 where isnull(审核人,'') <> '' and iID = " + iID.ToString();
                        DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            throw new Exception("别名" + iID.ToString() + " 已经审核\n");
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
            throw new NotImplementedException();
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

                        DAL.生产计划 dal = new 成衣生产.DAL.生产计划();

                        long iID = ReturnLong(gridView1.GetRowCellValue(i, gridColiID));
                        sSQL = "select iID from  生产计划 where isnull(审核人,'') <> '' and iID = " + iID.ToString();
                        DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            continue;
                        }

                        sSQL = "update 生产计划 set 审核人 = '" + 系统服务.ClsBaseDataInfo.sUserName + "',审核日期 = getdate() where iID = " + iID.ToString();
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

                        DAL.生产计划 dal = new 成衣生产.DAL.生产计划();

                        long iID = ReturnLong(gridView1.GetRowCellValue(i, gridColiID));

                        sSQL = "";

                        sSQL = "select count(*) from 材料出入库 where 生产计划iID=" + iID;
                        int chk1 = ReturnInt(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                        if (chk1 > 0)
                        {
                            throw new Exception("别名" + iID.ToString() + "已生成材料出库不可弃审\n");
                        }
                        sSQL = "select count(*) from 成品出入库 where 生产计划iID=" + iID;
                        int chk2 = ReturnInt(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                        if (chk2 > 0)
                        {
                            throw new Exception("别名" + iID.ToString() + "已生成完工入库不可弃审\n");
                        }

                        sSQL = "update 生产计划 set 审核人 = null,审核日期 = null where iID = " + iID.ToString();
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

        private void Frm生产计划_Load(object sender, EventArgs e)
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
    ,a.iID, 订单iID,尺码信息iID, 产品档案iID, 单据日期, 联系电话, 客户, 备注, 制单人, 制单日期, 审核人, 审核日期, 关闭人, 关闭日期, 变更人, 
                变更日期, 打印次数, 最后打印日期, 类别, 款号, 交货期, 数量, 生产, 纱种, 领形, 针型, 身高, 体重, 胸围, 胸围杯型, 身长, 
                肩宽, 袖长, 腰围, 下摆宽, 领深, 主色, 配色1, 配色2, 配色3, 配色4, 配色5, 主色用纱量, 配色1用纱量, 配色2用纱量, 
                配色3用纱量, 配色4用纱量, 配色5用纱量,计划生产日期, 生产日期, 入库日期, 完成日期
,isnull(主色用纱量,0) +isnull(配色1用纱量,0) + isnull(配色2用纱量,0) + isnull(配色3用纱量,0) + isnull(配色4用纱量,0) + isnull(配色5用纱量,0) as 用纱合计
,case when isnull(完工入库次数,0)=0 then '否' else '是' end 是否完工入库
,case when isnull(材料出库次数,0)=0 then '否' else '是' end 是否材料出库
FROM     生产计划 a left join (select iID,产品档案iID from 订单) b on a.订单iID=b.iID
left join (select iID,尺码信息iID from 产品档案) c on b.产品档案iID=c.iID
left join (select 生产计划iID,count(*) as 完工入库次数 from 成品出入库 where isnull(审核人,'')!='' group by 生产计划iID) d on a.iID=d.生产计划iID 
left join (select 生产计划iID,count(*) as 材料出库次数 from 材料出入库 where isnull(审核人,'')!='' and 出入库类别='02' group by 生产计划iID) e on a.iID=e.生产计划iID 
order by a.iID
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

            sSQL = "SELECT * FROM dbo.ColorNo ORDER BY cCNCode";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            ItemLookUpEdit色号.Properties.DataSource = dt;

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

                if (e.Column == gridCol订单iID && gridView1.FocusedRowHandle == gridView1.RowCount - 1)
                {
                    gridView1.AddNewRow();
                    gridView1.FocusedRowHandle = iRow;
                }
                
                if (e.Column == gridCol款号 || e.Column == gridCol生产 || e.Column == gridCol纱种 || e.Column == gridCol针型 || e.Column == gridCol领形
                    || e.Column == gridCol身高 || e.Column == gridCol体重 || e.Column == gridCol胸围 || e.Column == gridCol胸围杯型 || e.Column == gridCol身长
                    || e.Column == gridCol肩宽 || e.Column == gridCol袖长 || e.Column == gridCol腰围 || e.Column == gridCol下摆宽 || e.Column == gridCol领深)
                {
                    DataRow dr = ((System.Data.DataRowView)gridView1.GetRow(iRow)).Row;
                    Model.生产计划 model = new 成衣生产.Model.生产计划();
                    DAL.生产计划 dal = new 成衣生产.DAL.生产计划();
                    model = dal.DataRowToModel(dr);
                    sSQL = "select * from 产品档案 where 1=1 and isnull(审核人,'')<>''";
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(款号,'')='" + model.款号 + "'");
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(生产,'')='" + model.生产 + "'");
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(纱种,'')='" + model.纱种 + "'");
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(针型,'')='" + model.针型 + "'");

                    sSQL = sSQL.Replace("1=1", "1=1 and 领形='" + model.领形 + "'");
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(身高T,0)>='" + model.身高 + "' and isnull(身高L,0)<='" + model.身高 + "'");
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(体重T,0)>='" + model.体重 + "' and isnull(体重L,0)<='" + model.体重 + "'");
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(胸围T,0)>='" + model.胸围 + "' and isnull(胸围L,0)<='" + model.胸围 + "'");
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(胸围杯型T,0)>='" + model.胸围杯型 + "' and isnull(胸围杯型L,0)<='" + model.胸围杯型 + "'");
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(身长T,0)>='" + model.身长 + "' and isnull(身长L,0)<='" + model.身长 + "'");
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(肩宽T,0)>='" + model.肩宽 + "' and isnull(肩宽L,0)<='" + model.肩宽 + "'");
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(袖长T,0)>='" + model.袖长 + "' and isnull(袖长L,0)<='" + model.袖长 + "'");
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(腰围T,0)>='" + model.腰围 + "' and isnull(腰围L,0)<='" + model.腰围 + "'");
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(下摆宽T,0)>='" + model.下摆宽 + "' and isnull(下摆宽L,0)<='" + model.下摆宽 + "'");
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(领深T,0)>='" + model.领深 + "' and isnull(领深L,0)<='" + model.领深 + "'");


                    DataTable dt生产计划 = clsSQLCommond.ExecQuery(sSQL);
                    if (dt生产计划.Rows.Count > 0)
                    {
                        gridView1.SetRowCellValue(iRow, gridCol主色, dt生产计划.Rows[0]["主色"]);
                        gridView1.SetRowCellValue(iRow, gridCol配色1, dt生产计划.Rows[0]["配色1"]);
                        gridView1.SetRowCellValue(iRow, gridCol配色2, dt生产计划.Rows[0]["配色2"]);
                        gridView1.SetRowCellValue(iRow, gridCol配色3, dt生产计划.Rows[0]["配色3"]);
                        gridView1.SetRowCellValue(iRow, gridCol配色4, dt生产计划.Rows[0]["配色4"]);
                        gridView1.SetRowCellValue(iRow, gridCol配色5, dt生产计划.Rows[0]["配色5"]);

                        gridView1.SetRowCellValue(iRow, gridCol主色用纱量, dt生产计划.Rows[0]["主色用纱量"]);
                        gridView1.SetRowCellValue(iRow, gridCol配色1用纱量, dt生产计划.Rows[0]["配色1用纱量"]);
                        gridView1.SetRowCellValue(iRow, gridCol配色2用纱量, dt生产计划.Rows[0]["配色2用纱量"]);
                        gridView1.SetRowCellValue(iRow, gridCol配色3用纱量, dt生产计划.Rows[0]["配色3用纱量"]);
                        gridView1.SetRowCellValue(iRow, gridCol配色4用纱量, dt生产计划.Rows[0]["配色4用纱量"]);
                        gridView1.SetRowCellValue(iRow, gridCol配色5用纱量, dt生产计划.Rows[0]["配色5用纱量"]);

                        gridView1.SetRowCellValue(iRow, gridCol订单iID, dt生产计划.Rows[0]["iID"]);
                    }
                }

                if (e.Column == gridCol配色1用纱量 || e.Column == gridCol配色2用纱量 || e.Column == gridCol配色3用纱量 || e.Column == gridCol配色4用纱量 || e.Column == gridCol配色5用纱量 || e.Column == gridCol主色用纱量)
                {
                    decimal d1 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol配色1用纱量));
                    decimal d2 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol配色2用纱量));
                    decimal d3 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol配色3用纱量));
                    decimal d4 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol配色4用纱量));
                    decimal d5 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol配色5用纱量));
                    decimal d6 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol主色用纱量));

                    gridView1.SetRowCellValue(e.RowHandle, gridCol用纱合计, d1 + d2 + d3 + d4 + d5 + d6);
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
                sSQL = "select  isnull(制单人,'') as 制单人,isnull(审核人,'') as 审核人,isnull(关闭人,'') as 关闭人 from 生产计划 where 单据号 = '" + sCode + "'";
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

        private void ItemButtonEdit上机文件_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                ClsUseWebService clsWeb = new ClsUseWebService();

                int iRow = gridView1.FocusedRowHandle;

                int iFileCount = 0;
                int iUpFileCount = 0;

                string sID = gridView1.GetRowCellValue(iRow, gridCol尺码信息iID).ToString().Trim();
                string s别名 = sID;
                while (s别名.Length < 10)
                {
                    s别名 = "0" + s别名;
                }
                if (sID == "")
                {
                    throw new Exception("无法下载");
                }
                string s客户 = gridView1.GetRowCellDisplayText(iRow, gridCol客户).ToString().Trim();
                string sDate =DateTime.Parse(gridView1.GetRowCellDisplayText(iRow, gridCol单据日期).ToString().Trim()).ToString("yyyyMMdd");
                //int c = GetNewName(s别名);

                //DirectoryInfo directoryinfo = new DirectoryInfo(item);
                //string sFilePath = directoryinfo.FullName;
                
                try
                {
                    int iCount = 0;

                    SqlConnection conn = new SqlConnection(系统服务.ClsBaseDataInfo.sConnString);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandTimeout = 3600;
                    cmd.Connection = conn;
                    SqlTransaction tx = conn.BeginTransaction();
                    cmd.Transaction = tx;
                    string sSQL = "";
                    try
                    {
                        FolderBrowserDialog open = new FolderBrowserDialog();
                        open.ShowDialog();
                        string sDelName = open.SelectedPath + "\\" + s客户 + "_" + sDate + "_" + s别名;
                        FolderExists(sDelName);

                        string sPath = clsWeb.sFolder(s别名, "上机文件");
                        int i = 0;
                        string[] path = clsWeb.GetFilesName(sPath).Split(',');
                        foreach (string item in Directory.GetFiles(sPath))
                        {
                            i += 1;
                            DirectoryInfo directoryinfo = new DirectoryInfo(item);
                            string sFilePath = directoryinfo.FullName;
                            string sFileName = directoryinfo.Name;

                            FileInfo fi = new FileInfo(sFilePath.Trim());
                            byte[] b = clsWeb.DownloadFile(sFilePath);
                            File.WriteAllBytes(sDelName + "\\" + sFileName, b);
                            iFileCount = iFileCount + 1;
                        }
                        if (iFileCount == 0)
                            throw new Exception("下载失败");
                    }
                    catch (Exception ee)
                    {
                        tx.Rollback();
                        throw new Exception(ee.Message);
                    }
                }
                catch (Exception ee)
                {
                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("下载失败：" + ee.Message);
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

        private string GetOut(Model.生产计划 model, int flag, SqlTransaction tran, int i, string 生产计划iID)
        {
            Model.材料出入库 model材料出入库 = new 成衣生产.Model.材料出入库();
            DAL.材料出入库 dal材料出入库 = new 成衣生产.DAL.材料出入库();

            model材料出入库.单据日期 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
            系统服务.公共调用 cls = new 公共调用();
            model材料出入库.单据号 = cls.GetNewSerialNumberContinuous("材料出入库", "单据号");
            model材料出入库.类别 = model.类别;
            model材料出入库.出入库类别 = "02";
            model材料出入库.数量 = model.数量;
            model材料出入库.纱种 = model.纱种;
            model材料出入库.生产计划iID = ReturnInt(生产计划iID);
            if (flag == 1)
            {
                model材料出入库.色号 = model.主色;
                model材料出入库.数量 = model.主色用纱量 * model.数量;
            }
            else if (flag == 2)
            {
                model材料出入库.色号 = model.配色1;
                model材料出入库.数量 = model.配色1用纱量 * model.数量;
            }
            else if (flag == 3)
            {
                model材料出入库.色号 = model.配色2;
                model材料出入库.数量 = model.配色2用纱量 * model.数量;
            }
            else if (flag == 4)
            {
                model材料出入库.色号 = model.配色3;
                model材料出入库.数量 = model.配色3用纱量 * model.数量;
            }
            else if (flag == 5)
            {
                model材料出入库.色号 = model.配色4;
                model材料出入库.数量 = model.配色4用纱量 * model.数量;
            }
            else if (flag == 6)
            {
                model材料出入库.色号 = model.配色5;
                model材料出入库.数量 = model.配色5用纱量 * model.数量;
            }
            sSQL = "select sum(case when 出入库类别='01' then 数量 else -数量 end) as 库存数量 from 材料出入库 where 纱种='" + model.纱种 + "' and 色号='" + model材料出入库.色号 + "' "
            + "and isnull(缸号,'')=isnull('" + model材料出入库.缸号 + "','') ";
            decimal 库存数量 = ReturnDecimal(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
            if (库存数量 < ReturnDecimal(model材料出入库.数量))
            {
                throw new Exception("纱种:" + model.纱种 + "色号:" + model材料出入库.色号 + ",库存数量不足，当前可出库数量" + 库存数量 + "\n");
            }

            model材料出入库.制单人 = 系统服务.ClsBaseDataInfo.sUserName;
            model材料出入库.制单日期 = DateTime.Now;

            return dal材料出入库.Add(model材料出入库);
        }

        private void ItemButtonEdit点击生产_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(系统服务.ClsBaseDataInfo.sConnString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                int iRow = gridView1.FocusedRowHandle;
                int i = gridView1.FocusedRowHandle;
                int iCount = 0;
                string sID = gridView1.GetRowCellValue(i, gridColiID).ToString().Trim();
                if (sID == "")
                {
                    throw new Exception("单据不存在\n");
                }
                sSQL = "select * from 生产计划 where iID=" + sID;
                DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["计划生产日期"].ToString() == "")
                    {
                        throw new Exception("别名" + sID  + "请先保存计划生产日期后再生产\n");
                    }
                    else if (dt.Rows[0]["生产日期"].ToString() != "")
                    {
                        throw new Exception("别名" + sID  + "已进行生产\n");
                    }
                }
                else
                {
                    throw new Exception("别名" + sID  + "单据不存在，请刷新界面\n");
                }

                sSQL = "update 生产计划 set 生产日期='" + DateTime.Now.ToString("yyyy-MM-dd") + "' where iID=" + sID;
                iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                Model.生产计划 model生产计划 = new 成衣生产.Model.生产计划();
                DAL.生产计划 dal生产计划 = new 成衣生产.DAL.生产计划();
                DataRow drdd = dt.Rows[0];
                model生产计划 = dal生产计划.DataRowToModel(drdd);

                if (model生产计划.主色 != "")
                {
                    sSQL = GetOut(model生产计划, 1, tran, i, sID);
                    iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }
                if (model生产计划.配色1 != "")
                {
                    sSQL = GetOut(model生产计划, 2, tran, i, sID);
                    iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }
                if (model生产计划.配色2 != "")
                {
                    sSQL = GetOut(model生产计划, 3, tran, i, sID);
                    iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }
                if (model生产计划.配色3 != "")
                {
                    sSQL = GetOut(model生产计划, 4, tran, i, sID);
                    iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }
                if (model生产计划.配色4 != "")
                {
                    sSQL = GetOut(model生产计划, 5, tran, i, sID);
                    iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }
                if (model生产计划.配色5 != "")
                {
                    sSQL = GetOut(model生产计划, 6, tran, i, sID);
                    iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }

                if (iCount > 0)
                {
                    tran.Commit();

                    MessageBox.Show("已保存\n");

                    GetGrid();
                    gridView1.FocusedRowHandle = i;
                }
            }
            catch (Exception ee)
            {
                tran.Rollback();
                MessageBox.Show("失败：" + ee.Message);
            }
        }

        private void ItemButtonEdit点击入库_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(系统服务.ClsBaseDataInfo.sConnString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                int i = gridView1.FocusedRowHandle;
                int iCount = 0;
                string sID = gridView1.GetRowCellValue(i, gridColiID).ToString().Trim();
                if (sID == "")
                {
                    throw new Exception("单据不存在\n");
                }
                sSQL = "select * from 生产计划 where iID=" + sID;
                DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["生产日期"].ToString() == "")
                    {
                        throw new Exception("别名" + sID  + "请先生产后再入库\n");
                    }
                    else if (dt.Rows[0]["入库日期"].ToString() != "")
                    {
                        throw new Exception("别名" + sID  + "已入库\n");
                    }
                }
                else
                {
                    throw new Exception("别名" + sID  + "单据不存在，请刷新界面\n");
                }
                sSQL = "update 生产计划 set 入库日期='" + DateTime.Now.ToString("yyyy-MM-dd") + "' where iID=" + sID;
                iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                Model.成品出入库 model成品出入库 = new 成衣生产.Model.成品出入库();
                DAL.成品出入库 dal成品出入库 = new 成衣生产.DAL.成品出入库();

                model成品出入库.单据日期 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                model成品出入库.客户 = gridView1.GetRowCellValue(i, gridCol客户).ToString().Trim();
                model成品出入库.出入库类别 = "01";
                model成品出入库.类别 = gridView1.GetRowCellValue(i, gridCol类别).ToString().Trim();
                model成品出入库.款号 = gridView1.GetRowCellValue(i, gridCol款号).ToString().Trim();
                model成品出入库.数量 = ReturnDecimal(gridView1.GetRowCellValue(i, gridCol数量));
                model成品出入库.生产 = gridView1.GetRowCellValue(i, gridCol生产).ToString().Trim();
                model成品出入库.纱种 = gridView1.GetRowCellValue(i, gridCol纱种).ToString().Trim();
                model成品出入库.生产计划iID =ReturnInt(sID);

                model成品出入库.制单人 = 系统服务.ClsBaseDataInfo.sUserName;
                model成品出入库.制单日期 = DateTime.Now;

                sSQL = dal成品出入库.Add(model成品出入库);
                iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                if (iCount > 0)
                {
                    tran.Commit();

                    MessageBox.Show("已保存\n");

                    GetGrid();
                    gridView1.FocusedRowHandle = i;
                }
            }
            catch (Exception ee)
            {
                tran.Rollback();
                MessageBox.Show("失败：" + ee.Message);
            }
        }

        private void ItemButtonEdit点击计划_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(系统服务.ClsBaseDataInfo.sConnString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                int i = gridView1.FocusedRowHandle;
                int iCount = 0;
                string sID = gridView1.GetRowCellValue(i, gridColiID).ToString().Trim();
                if (sID == "")
                {
                    throw new Exception("单据不存在\n");
                }
                string 计划生产日期 = gridView1.GetRowCellValue(i, gridCol计划生产日期).ToString().Trim();
                
                sSQL = "select * from 生产计划 where iID=" + sID;
                DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["审核人"].ToString() == "")
                    {
                        throw new Exception("别名" + sID  + "请先审核\n");
                    }
                    if (dt.Rows[0]["生产日期"].ToString() != "")
                    {
                        throw new Exception("别名" + sID  + "已点生产不可再次修改计划生产日期\n");
                    }
                }
                else
                {
                    throw new Exception("别名" + sID  + "单据不存在，请刷新界面\n");
                }
                sSQL = "update 生产计划 set 计划生产日期='" + 计划生产日期 + "' where iID=" + sID;
                iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                if (iCount > 0)
                {
                    tran.Commit();

                    MessageBox.Show("已保存\n");

                    GetGrid();
                    gridView1.FocusedRowHandle = i;
                }
            }
            catch (Exception ee)
            {
                tran.Rollback();
                MessageBox.Show("失败：" + ee.Message);
            }
        }

        private void ItemButtonEdit点击完成_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(系统服务.ClsBaseDataInfo.sConnString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                int i = gridView1.FocusedRowHandle;
                int iCount = 0;
                string sID = gridView1.GetRowCellValue(i, gridColiID).ToString().Trim();
                if (sID == "")
                {
                    throw new Exception("单据不存在\n");
                }
                string 计划生产日期 = gridView1.GetRowCellValue(i, gridCol计划生产日期).ToString().Trim();

                sSQL = "select * from 生产计划 where iID=" + sID;
                DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["入库日期"].ToString() == "")
                    {
                        throw new Exception("别名" + sID + "未入库，不可点击完成\n");
                    }
                    if (dt.Rows[0]["完成日期"].ToString() != "")
                    {
                        throw new Exception("别名" + sID  + "已完成，不可再次完成\n");
                    }
                }
                else
                {
                    throw new Exception("别名" + sID  + "单据不存在，请刷新界面\n");
                }
                sSQL = "update 生产计划 set 完成日期='" + DateTime.Now.ToString("yyyy-MM-dd") + "' where iID=" + sID;
                iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                if (iCount > 0)
                {
                    tran.Commit();

                    MessageBox.Show("已保存\n");

                    GetGrid();
                    gridView1.FocusedRowHandle = i;
                }
            }
            catch (Exception ee)
            {
                tran.Rollback();
                MessageBox.Show("失败：" + ee.Message);
            }
        }


    }
}
