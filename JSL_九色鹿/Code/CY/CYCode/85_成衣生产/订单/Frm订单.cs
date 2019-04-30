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
    public partial class Frm订单 : 系统服务.FrmBaseInfo
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

        public Frm订单()
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

                        DAL.订单 dal = new 成衣生产.DAL.订单();

                        long iID = ReturnLong(gridView1.GetRowCellValue(i, gridColiID));
                        sSQL = "select iID from  订单 where isnull(审核人,'') <> '' and iID = " + iID.ToString();
                        DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            sErr = "别名" + iID .ToString() + " 已经审核\n";
                            continue;
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
                        Model.订单 model = new 成衣生产.Model.订单();
                        DAL.订单 dal = new 成衣生产.DAL.订单();
                        model = dal.DataRowToModel(dr);

                        if (model.客户.Trim() == "")
                        {
                            sErrRow = sErrRow + "行" + (i + 1).ToString() + "客户不能为空\n";
                        }
                        if (model.联系电话.Trim() == "")
                        {
                            sErrRow = sErrRow + "行" + (i + 1).ToString() + "联系电话不能为空\n";
                        }
                        if (model.类别.Trim() == "")
                        {
                            sErrRow = sErrRow + "行" + (i + 1).ToString() + "类别不能为空\n";
                        }
                        if (model.款号.Trim() == "")
                        {
                            sErrRow = sErrRow + "行" + (i + 1).ToString() + "款号不能为空\n";
                        }
                        if (ReturnDateTimeString(model.交货期) == "")
                        {
                            sErrRow = sErrRow + "行" + (i + 1).ToString() + "交货期不能为空\n";
                        }
                        if (model.生产.Trim() == "")
                        {
                            sErrRow = sErrRow + "行" + (i + 1).ToString() + "生产不能为空\n";
                        }
                        if (model.纱种.Trim() == "")
                        {
                            sErrRow = sErrRow + "行" + (i + 1).ToString() + "纱种不能为空\n";
                        }
                        if (ReturnDecimal(model.身长) == 0)
                        {
                            sErrRow = sErrRow + "行" + (i + 1).ToString() + "请设置正确的身长\n";
                        }
                        if (ReturnDecimal(model.胸围) == 0)
                        {
                            sErrRow = sErrRow + "行" + (i + 1).ToString() + "请设置正确的胸围\n";
                        }
                        if (ReturnDecimal(model.袖长) == 0)
                        {
                            sErrRow = sErrRow + "行" + (i + 1).ToString() + "请设置正确的袖长\n";
                        }
                        if (ReturnDecimal(model.肩宽) == 0)
                        {
                            sErrRow = sErrRow + "行" + (i + 1).ToString() + "请设置正确的肩宽\n";
                        }
                        if (model.主色.Trim() == "")
                        {
                            sErrRow = sErrRow + "行" + (i + 1).ToString() + "主色不能为空\n";
                        }
                        if (ReturnDecimal(model.主色用纱量) == 0)
                        {
                            sErrRow = sErrRow + "行" + (i + 1).ToString() + "请设置正确的主色用纱量\n";
                        }

                        #region 判断订单
                        if (sErrRow == "")
                        {
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

                            sSQL = sSQL.Replace("1=1", "1=1 and isnull(主色,'')='" + model.主色 + "'");
                            sSQL = sSQL.Replace("1=1", "1=1 and isnull(配色1,'')='" + model.配色1 + "'");
                            sSQL = sSQL.Replace("1=1", "1=1 and isnull(配色2,'')='" + model.配色2 + "'");
                            sSQL = sSQL.Replace("1=1", "1=1 and isnull(配色3,'')='" + model.配色3 + "'");
                            sSQL = sSQL.Replace("1=1", "1=1 and isnull(配色4,'')='" + model.配色4 + "'");
                            sSQL = sSQL.Replace("1=1", "1=1 and isnull(配色5,'')='" + model.配色5 + "'");

                            sSQL = sSQL.Replace("1=1", "1=1 and isnull(主色用纱量,0)='" + model.主色用纱量 + "'");
                            sSQL = sSQL.Replace("1=1", "1=1 and isnull(配色1用纱量,0)='" + model.配色1用纱量 + "'");
                            sSQL = sSQL.Replace("1=1", "1=1 and isnull(配色2用纱量,0)='" + model.配色2用纱量 + "'");
                            sSQL = sSQL.Replace("1=1", "1=1 and isnull(配色3用纱量,0)='" + model.配色3用纱量 + "'");
                            sSQL = sSQL.Replace("1=1", "1=1 and isnull(配色4用纱量,0)='" + model.配色4用纱量 + "'");
                            sSQL = sSQL.Replace("1=1", "1=1 and isnull(配色5用纱量,0)='" + model.配色5用纱量 + "'");


                            DataTable dt订单 = clsSQLCommond.ExecQuery(sSQL);
                            if (dt订单.Rows.Count == 0)
                            {
                                sErr = sErr + "行" + (i + 1) + "请建立相应尺码档案\n";
                                continue;
                            }
                            else
                            {
                                model.产品档案iID = ReturnInt(dt订单.Rows[0]["iID"]);
                            }
                        }
                        #endregion
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

                        DAL.订单 dal = new 成衣生产.DAL.订单();

                        long iID = ReturnLong(gridView1.GetRowCellValue(i, gridColiID));
                        sSQL = "select iID from  订单 where isnull(审核人,'') <> '' and iID = " + iID.ToString();
                        DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            continue;
                        }

                        sSQL = "update 订单 set 审核人 = '" + 系统服务.ClsBaseDataInfo.sUserName + "',审核日期 = getdate() where iID = " + iID.ToString();
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

                        DAL.订单 dal = new 成衣生产.DAL.订单();

                        long iID = ReturnLong(gridView1.GetRowCellValue(i, gridColiID));

                        sSQL = "select count(*) from 生产计划 where 订单iID=" + iID;
                        int hasCount = ReturnInt(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                        if (hasCount > 0)
                        {
                            throw new Exception("行" + (i + 1).ToString() + "已生成生产计划不可弃审\n");
                        }

                        sSQL = "update 订单 set 审核人 = null,审核日期 = null where iID = " + iID.ToString();
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
        /// 打开 销售出库
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
                        Model.订单 model = new 成衣生产.Model.订单();
                        DAL.订单 dal = new 成衣生产.DAL.订单();
                        model = dal.DataRowToModel(dr);

                        sSQL = "select count(*) from 成品出入库 a left join 生产计划 b on a.生产计划iID=b.iID  where isnull(a.审核人,'')!='' and b.订单iID=" + model.iID;
                        int hasauidt = ReturnInt(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                        if (hasauidt == 0)
                        {
                            throw new Exception("行" + (i + 1).ToString() + "未完工入库\n");
                        }

                        Model.成品出入库 model成品出入库 = new 成衣生产.Model.成品出入库();
                        DAL.成品出入库 dal成品出入库 = new 成衣生产.DAL.成品出入库();

                        model成品出入库.单据日期 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                        model成品出入库.客户 = model.客户;
                        model成品出入库.出入库类别 = "02";
                        model成品出入库.类别 = model.类别;
                        model成品出入库.款号 = model.款号;
                        model成品出入库.数量 = model.数量;
                        model成品出入库.生产 = model.生产;
                        model成品出入库.纱种 = model.纱种;
                        model成品出入库.生产计划iID = model.iID;

                        model成品出入库.制单人 = 系统服务.ClsBaseDataInfo.sUserName;
                        model成品出入库.制单日期 = DateTime.Now;

                        sSQL = dal成品出入库.Add(model成品出入库);
                        iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        if (sErrRow != "")
                        {
                            sErr = sErr + sErrRow;
                            continue;
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
        /// 关闭
        /// </summary>
        private void btnClose()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 变更 下达生产
        /// </summary>
        private void btnAlter()
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
                        Model.订单 model = new 成衣生产.Model.订单();
                        DAL.订单 dal = new 成衣生产.DAL.订单();
                        model = dal.DataRowToModel(dr);
                        sSQL = "select count(*) from 订单 where isnull(审核人,'')!='' and iID=" + model.iID;
                        int hasauidt = ReturnInt(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                        if (hasauidt == 0)
                        {
                            throw new Exception("行" + (i + 1).ToString() + "未审核\n");
                        }

                        sSQL = "select count(*) from 生产计划 where 订单iID=" + model.iID;
                        int hasCount = ReturnInt(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                        if (hasCount > 0)
                        {
                            throw new Exception("行" + (i + 1).ToString() + "已生成生产计划\n");
                        }
                        
                        Model.生产计划 model生产计划 = new 成衣生产.Model.生产计划();
                        DAL.生产计划 dal生产计划 = new 成衣生产.DAL.生产计划();

                        model生产计划.单据日期 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                        model生产计划.订单iID = model.iID;
                        model生产计划.联系电话 = model.联系电话;
                        model生产计划.客户 = model.客户;
                        model生产计划.类别 = model.类别;
                        model生产计划.款号 = model.款号;
                        model生产计划.交货期 = model.交货期;
                        model生产计划.数量 = model.数量;
                        model生产计划.生产 = model.生产;
                        model生产计划.纱种 = model.纱种;
                        model生产计划.领形 = model.领形;
                        model生产计划.针型 = model.针型;
                        model生产计划.身高 = model.身高;
                        model生产计划.体重 = model.体重;
                        model生产计划.胸围 = model.胸围;
                        model生产计划.胸围杯型 = model.胸围杯型;
                        model生产计划.身长 = model.身长;
                        model生产计划.肩宽 = model.肩宽;
                        model生产计划.袖长 = model.袖长;
                        model生产计划.腰围 = model.腰围;
                        model生产计划.下摆宽 = model.下摆宽;
                        model生产计划.领深 = model.领深;
                        model生产计划.主色 = model.主色;
                        model生产计划.配色1 = model.配色1;
                        model生产计划.配色2 = model.配色2;
                        model生产计划.配色3 = model.配色3;
                        model生产计划.配色4 = model.配色4;
                        model生产计划.配色5 = model.配色5;
                        model生产计划.主色用纱量 = model.主色用纱量;
                        model生产计划.配色1用纱量 = model.配色1用纱量;
                        model生产计划.配色2用纱量 = model.配色2用纱量;
                        model生产计划.配色3用纱量 = model.配色3用纱量;
                        model生产计划.配色4用纱量 = model.配色4用纱量;
                        model生产计划.配色5用纱量 = model.配色5用纱量;

                        model生产计划.制单人 = 系统服务.ClsBaseDataInfo.sUserName;
                        model生产计划.制单日期 = DateTime.Now;


                        sSQL = dal生产计划.Add(model生产计划);
                        iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    
                        
                        if (sErrRow != "")
                        {
                            sErr = sErr + sErrRow;
                            continue;
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

        #endregion

        private void Frm订单_Load(object sender, EventArgs e)
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
    ,iID, 产品档案iID,尺码信息iID, 单据日期, 联系电话, 客户, 备注, 制单人, 制单日期, 审核人, 审核日期, 关闭人, 关闭日期, 变更人, 
                变更日期, 打印次数, 最后打印日期, 类别, 款号, 交货期, 数量, 生产, 纱种, 领形, 针型, 身高, 体重, 胸围, 胸围杯型, 身长, 
                肩宽, 袖长, 腰围, 下摆宽, 领深, 主色, 配色1, 配色2, 配色3, 配色4, 配色5, 主色用纱量, 配色1用纱量, 配色2用纱量, 
                配色3用纱量, 配色4用纱量, 配色5用纱量
,isnull(主色用纱量,0) +isnull(配色1用纱量,0) + isnull(配色2用纱量,0) + isnull(配色3用纱量,0) + isnull(配色4用纱量,0) + isnull(配色5用纱量,0) as 用纱合计
,case when isnull(生产计划生成次数,0)=0 then '否' else '是' end 是否生成生产计划
,case when isnull(完工入库生成次数,0)=0 then '否' else '是' end 是否完工入库
FROM     订单 a left join (select iID as 产品档案iID_1,尺码信息iID from 产品档案) b on a.产品档案iID=b.产品档案iID_1
left join (select 订单iID,count(*) as 生产计划生成次数 from 生产计划  where isnull(审核人,'')!='' group by 订单iID) c on a.iID=c.订单iID
left join (select 订单iID,count(*) as 完工入库生成次数 from 生产计划 a left join 成品出入库 b on a.iID=b.生产计划iID where isnull(b.审核人,'')!='' and b.生产计划iID is not null group by 订单iID) d on a.iID=d.订单iID
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

                if (e.Column == gridCol产品档案iID && gridView1.FocusedRowHandle == gridView1.RowCount - 1)
                {
                    gridView1.AddNewRow();
                    gridView1.FocusedRowHandle = iRow;
                }
                
                if (e.Column == gridCol款号 || e.Column == gridCol生产 || e.Column == gridCol纱种 || e.Column == gridCol针型 || e.Column == gridCol领形
                    || e.Column == gridCol身高 || e.Column == gridCol体重 || e.Column == gridCol胸围 || e.Column == gridCol胸围杯型 || e.Column == gridCol身长
                    || e.Column == gridCol肩宽 || e.Column == gridCol袖长 || e.Column == gridCol腰围 || e.Column == gridCol下摆宽 || e.Column == gridCol领深)
                {
                    DataRow dr = ((System.Data.DataRowView)gridView1.GetRow(iRow)).Row;
                    Model.订单 model = new 成衣生产.Model.订单();
                    DAL.订单 dal = new 成衣生产.DAL.订单();
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


                    DataTable dt订单 = clsSQLCommond.ExecQuery(sSQL);
                    if (dt订单.Rows.Count > 0)
                    {
                        gridView1.SetRowCellValue(iRow, gridCol主色, dt订单.Rows[0]["主色"]);
                        gridView1.SetRowCellValue(iRow, gridCol配色1, dt订单.Rows[0]["配色1"]);
                        gridView1.SetRowCellValue(iRow, gridCol配色2, dt订单.Rows[0]["配色2"]);
                        gridView1.SetRowCellValue(iRow, gridCol配色3, dt订单.Rows[0]["配色3"]);
                        gridView1.SetRowCellValue(iRow, gridCol配色4, dt订单.Rows[0]["配色4"]);
                        gridView1.SetRowCellValue(iRow, gridCol配色5, dt订单.Rows[0]["配色5"]);

                        gridView1.SetRowCellValue(iRow, gridCol主色用纱量, dt订单.Rows[0]["主色用纱量"]);
                        gridView1.SetRowCellValue(iRow, gridCol配色1用纱量, dt订单.Rows[0]["配色1用纱量"]);
                        gridView1.SetRowCellValue(iRow, gridCol配色2用纱量, dt订单.Rows[0]["配色2用纱量"]);
                        gridView1.SetRowCellValue(iRow, gridCol配色3用纱量, dt订单.Rows[0]["配色3用纱量"]);
                        gridView1.SetRowCellValue(iRow, gridCol配色4用纱量, dt订单.Rows[0]["配色4用纱量"]);
                        gridView1.SetRowCellValue(iRow, gridCol配色5用纱量, dt订单.Rows[0]["配色5用纱量"]);

                        gridView1.SetRowCellValue(iRow, gridCol产品档案iID, dt订单.Rows[0]["iID"]);
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
                sSQL = "select  isnull(制单人,'') as 制单人,isnull(审核人,'') as 审核人,isnull(关闭人,'') as 关闭人 from 订单 where 单据号 = '" + sCode + "'";
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
                if (sID == "")
                {
                    throw new Exception("单据不存在\n");
                }
                string s别名 = sID;
                while (s别名.Length < 10)
                {
                    s别名 = "0" + s别名;
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
                MessageBox.Show("上传失败：" + ee.Message);
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

        private void ItemButtonEdit销售出库_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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
                sSQL = "select * from 订单 where iID=" + sID;
                DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("别名" + sID  + "单据不存在，请刷新界面\n");
                }
                sSQL = "select isnull(max(b.iID),0) from 成品出入库 a left join 生产计划 b on a.生产计划iID=b.iID  where isnull(a.审核人,'')!='' and b.订单iID=" + sID;
                int 生产计划iID = ReturnInt(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                if (生产计划iID == 0)
                {
                    throw new Exception("别名" + sID  + "未完工入库\n");
                }

                Model.成品出入库 model成品出入库 = new 成衣生产.Model.成品出入库();
                DAL.成品出入库 dal成品出入库 = new 成衣生产.DAL.成品出入库();

                model成品出入库.单据日期 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                model成品出入库.客户 = dt.Rows[0]["客户"].ToString().Trim();
                model成品出入库.出入库类别 = "02";
                model成品出入库.类别 = dt.Rows[0]["类别"].ToString().Trim();
                model成品出入库.款号 = dt.Rows[0]["款号"].ToString().Trim();
                model成品出入库.数量 = ReturnDecimal(dt.Rows[0]["数量"].ToString().Trim());
                model成品出入库.生产 = dt.Rows[0]["生产"].ToString().Trim();
                model成品出入库.纱种 = dt.Rows[0]["纱种"].ToString().Trim();
                model成品出入库.生产计划iID = 生产计划iID;

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

        private void ItemButtonEdit下达生产_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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
                sSQL = "select * from 订单 where iID=" + sID;
                DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("别名" + sID  + "单据不存在，请刷新界面\n");
                }
                sSQL = "select count(*) from 订单 where isnull(审核人,'')!='' and iID=" + sID;
                int hasauidt = ReturnInt(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                if (hasauidt == 0)
                {
                    throw new Exception("别名" + sID  + "未审核\n");
                }

                sSQL = "select count(*) from 生产计划 where 订单iID=" + sID;
                int hasCount = ReturnInt(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                if (hasCount > 0)
                {
                    throw new Exception("别名" + sID  + "已生成生产计划\n");
                }

                Model.生产计划 model生产计划 = new 成衣生产.Model.生产计划();
                DAL.生产计划 dal生产计划 = new 成衣生产.DAL.生产计划();

                model生产计划.单据日期 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                model生产计划.订单iID = ReturnInt(sID);
                model生产计划.联系电话 = dt.Rows[0]["联系电话"].ToString().Trim();
                model生产计划.客户 = dt.Rows[0]["客户"].ToString().Trim();
                model生产计划.类别 = dt.Rows[0]["类别"].ToString().Trim();
                model生产计划.款号 = dt.Rows[0]["款号"].ToString().Trim();
                model生产计划.交货期 = DateTime.Parse(dt.Rows[0]["交货期"].ToString().Trim());
                model生产计划.数量 = ReturnDecimal(dt.Rows[0]["数量"].ToString().Trim());
                model生产计划.生产 = dt.Rows[0]["生产"].ToString().Trim();
                model生产计划.纱种 = dt.Rows[0]["纱种"].ToString().Trim();
                model生产计划.领形 = dt.Rows[0]["领形"].ToString().Trim();
                model生产计划.针型 = dt.Rows[0]["针型"].ToString().Trim();
                model生产计划.身高 = ReturnDecimal(dt.Rows[0]["身高"].ToString().Trim());
                model生产计划.体重 = ReturnDecimal(dt.Rows[0]["体重"].ToString().Trim());
                model生产计划.胸围 = ReturnDecimal(dt.Rows[0]["胸围"].ToString().Trim());
                model生产计划.胸围杯型 = ReturnDecimal(dt.Rows[0]["胸围杯型"].ToString().Trim());
                model生产计划.身长 = ReturnDecimal(dt.Rows[0]["身长"].ToString().Trim());
                model生产计划.肩宽 = ReturnDecimal(dt.Rows[0]["肩宽"].ToString().Trim());
                model生产计划.袖长 = ReturnDecimal(dt.Rows[0]["袖长"].ToString().Trim());
                model生产计划.腰围 = ReturnDecimal(dt.Rows[0]["腰围"].ToString().Trim());
                model生产计划.下摆宽 = ReturnDecimal(dt.Rows[0]["下摆宽"].ToString().Trim());
                model生产计划.领深 = ReturnDecimal(dt.Rows[0]["领深"].ToString().Trim());
                model生产计划.主色 = dt.Rows[0]["主色"].ToString().Trim();
                model生产计划.配色1 = dt.Rows[0]["配色1"].ToString().Trim();
                model生产计划.配色2 = dt.Rows[0]["配色2"].ToString().Trim();
                model生产计划.配色3 = dt.Rows[0]["配色3"].ToString().Trim();
                model生产计划.配色4 = dt.Rows[0]["配色4"].ToString().Trim();
                model生产计划.配色5 = dt.Rows[0]["配色5"].ToString().Trim();
                if (dt.Rows[0]["主色用纱量"].ToString().Trim() != "")
                {
                    model生产计划.主色用纱量 = ReturnDecimal(dt.Rows[0]["主色用纱量"].ToString().Trim());
                }
                if (dt.Rows[0]["配色1用纱量"].ToString().Trim() != "")
                {
                    model生产计划.配色1用纱量 = ReturnDecimal(dt.Rows[0]["配色1用纱量"].ToString().Trim());
                }
                if (dt.Rows[0]["配色2用纱量"].ToString().Trim() != "")
                {
                    model生产计划.配色2用纱量 = ReturnDecimal(dt.Rows[0]["配色2用纱量"].ToString().Trim());
                }
                if (dt.Rows[0]["配色3用纱量"].ToString().Trim() != "")
                {
                    model生产计划.配色3用纱量 = ReturnDecimal(dt.Rows[0]["配色3用纱量"].ToString().Trim());
                }
                if (dt.Rows[0]["配色4用纱量"].ToString().Trim() != "")
                {
                    model生产计划.配色4用纱量 = ReturnDecimal(dt.Rows[0]["配色4用纱量"].ToString().Trim());
                }
                if (dt.Rows[0]["配色5用纱量"].ToString().Trim() != "")
                {
                    model生产计划.配色5用纱量 = ReturnDecimal(dt.Rows[0]["配色5用纱量"].ToString().Trim());
                }
                model生产计划.制单人 = 系统服务.ClsBaseDataInfo.sUserName;
                model生产计划.制单日期 = DateTime.Now;


                sSQL = dal生产计划.Add(model生产计划);
                iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                if (iCount > 0)
                {
                    tran.Commit();

                    MessageBox.Show("下达生产计划成功\n");

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
