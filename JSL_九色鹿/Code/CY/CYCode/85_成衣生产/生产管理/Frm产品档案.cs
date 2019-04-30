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
using 系统服务;

namespace 成衣生产
{
    public partial class Frm产品档案 : 系统服务.FrmBaseInfo
    {

        public Frm产品档案()
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

        private void btnAdd()
        {
            Frm产品档案_Add frm = new Frm产品档案_Add();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.Yes)
            {
                GetGrid();
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
            throw new NotImplementedException();
        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void btnRefresh()
        {
            try
            {
                SetLookUpEdit();
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("刷新窗体失败\n" + ee.Message);
            }
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
           


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
            for (int i = gridView1.RowCount - 1; i >= 0; i--)
            {
                if (gridView1.IsRowSelected(i))
                {
                    gridView1.DeleteRow(i);
                }
            }
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

                        DAL.产品档案 dal = new 成衣生产.DAL.产品档案();

                        long iID = ReturnLong(gridView1.GetRowCellValue(i,gridColiID));
                        sSQL = "select iID from  产品档案 where isnull(审核人,'') <> '' and iID = " + iID.ToString();
                        DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            sErr = "行" + (i + 1).ToString() + " 已经审核\n";
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
                        Model.产品档案 model = new 成衣生产.Model.产品档案();
                        DAL.产品档案 dal = new 成衣生产.DAL.产品档案();
                        model = dal.DataRowToModel(dr);

                        if(model.编码.Trim() == "")
                        {
                            sErrRow = sErrRow + "行" + (i + 1).ToString() + "编码不能为空\n";
                        }
                        if(model.款号.Trim() == "")
                        {
                            sErrRow = sErrRow + "行" + (i+1).ToString() + "款号不能为空\n";
                        }
                        if(model.生产.Trim() == "")
                        {
                            sErrRow = sErrRow + "行" + (i+1).ToString() + "生产不能为空\n";
                        }
                        if(model.纱种.Trim() == "")
                        {
                            sErrRow = sErrRow + "行" + (i+1).ToString() + "纱种不能为空\n";
                        }
                        if (ReturnDecimal(model.身长L) == 0)
                        {
                            sErrRow = sErrRow + "行" + (i + 1).ToString() + "请设置正确的身长下限\n";
                        }
                        if (ReturnDecimal(model.身长T) == 0)
                        {
                            sErrRow = sErrRow + "行" + (i + 1).ToString() + "请设置正确的身长上限\n";
                        }
                        if (ReturnDecimal(model.胸围L) == 0)
                        {
                            sErrRow = sErrRow + "行" + (i + 1).ToString() + "请设置正确的胸围下限\n";
                        }
                        if (ReturnDecimal(model.胸围T) == 0)
                        {
                            sErrRow = sErrRow + "行" + (i + 1).ToString() + "请设置正确的胸围上限\n";
                        }
                        if (ReturnDecimal(model.袖长L) == 0)
                        {
                            sErrRow = sErrRow + "行" + (i + 1).ToString() + "请设置正确的袖长下限\n";
                        }
                        if (ReturnDecimal(model.袖长T) == 0)
                        {
                            sErrRow = sErrRow + "行" + (i + 1).ToString() + "请设置正确的袖长上限\n";
                        }
                        if (ReturnDecimal(model.肩宽L) == 0)
                        {
                            sErrRow = sErrRow + "行" + (i + 1).ToString() + "请设置正确的肩宽下限\n";
                        }
                        if (ReturnDecimal(model.肩宽T) == 0)
                        {
                            sErrRow = sErrRow + "行" + (i + 1).ToString() + "请设置正确的肩宽上限\n";
                        }
                        if (model.主色.Trim() == "")
                        {
                            sErrRow = sErrRow + "行" + (i + 1).ToString() + "主色不能为空\n";
                        }
                        if (ReturnDecimal(model.主色用纱量) == 0)
                        {
                            sErrRow = sErrRow + "行" + (i + 1).ToString() + "请设置正确的主色用纱量\n";
                        }

                        

                        if(sErrRow != "")
                        {
                            sErr = sErr + sErrRow;
                            continue;
                        }

                        sSQL = dal.Exists(model.iID);
                        bool bExists = ReturnBool(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                        if (bExists)
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

                        DAL.产品档案 dal = new 成衣生产.DAL.产品档案();

                        long iID = ReturnLong(gridView1.GetRowCellValue(i, gridColiID));
                        sSQL = "select iID from  产品档案 where isnull(审核人,'') <> '' and iID = " + iID.ToString();
                        DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            continue;
                        }

                        sSQL = "update 产品档案 set 审核人 = '" + 系统服务.ClsBaseDataInfo.sUserName + "',审核日期 = getdate() where iID = " + iID.ToString();
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

                        DAL.产品档案 dal = new 成衣生产.DAL.产品档案();

                        long iID = ReturnLong(gridView1.GetRowCellValue(i, gridColiID));

                        ///
                        ///需要增加弃审验证，已使用的不可弃审
                        ///

                        sSQL = "update 产品档案 set 审核人 = null,审核日期 = null where iID = " + iID.ToString();
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
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            string sErr = "";
            string success = "";
            int iCount = 0;
            try
            {
                string sSQL = "";

                ClsUseWebService clsWeb = new ClsUseWebService();

                int iRow = gridView1.FocusedRowHandle;


                FolderBrowserDialog open = new FolderBrowserDialog();
                open.ShowDialog();
                string sPath = open.SelectedPath;
                foreach (string items in Directory.GetDirectories(sPath))
                {

                    string s文件夹 = items.Replace(sPath + "\\", "");

                    sSQL = "select 审核人 from 产品档案 where iID = " + ReturnLong(s文件夹).ToString().Trim();
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt == null || dt.Rows.Count == 0 || dt.Rows[0][0].ToString().Trim() == "")
                    {
                        sErr = sErr + "产品 " + s文件夹 + "不存在，或者未审核，不能上传文件\n";
                        continue;
                    }

                    string s别名 = s文件夹;
                    while (s别名.Length < 10)
                    {
                        s别名 = "0" + s别名;
                    }

                    int iFileCount = 0;
                    int iUpFileCount = 0;
                    string sDelName = clsWeb.sDelFolder(s别名, "上机文件");
                    int i = 0;
                    foreach (string item in Directory.GetFiles(items.ToString()))
                    {
                        i += 1;
                        DirectoryInfo directoryinfo = new DirectoryInfo(item);
                        string sFilePath = directoryinfo.FullName;


                        FileInfo fi = new FileInfo(sFilePath.Trim());
                        FileStream fs = fi.OpenRead();
                        byte[] bytes = new byte[fs.Length];
                        fs.Read(bytes, 0, Convert.ToInt32(fs.Length));

                        string sFileName = item.Replace(items.ToString() + "\\", "");
                        string sN = clsWeb.UploadFile(s别名, "上机文件", sFileName, bytes);
                        if (sN.ToLower().IndexOf(sFileName.ToLower()) > 0)
                        {
                            iUpFileCount += 1;
                        }
                    }

                    sSQL = "update [产品档案] set [上机文件] = '√',上机时间 = getdate(),上机人 = '" + sUid + "' where iID = " + s文件夹;
                    int iCou = clsSQLCommond.ExecSql(sSQL);

                    sSQL = @"insert into 图纸上传记录(别名, 类型, 上传人, 上传日期)
                                values('aaaaaa','上机文件','bbbbbb',getdate())";
                    sSQL = sSQL.Replace("aaaaaa", s文件夹);
                    sSQL = sSQL.Replace("bbbbbb", sUid);
                    clsSQLCommond.ExecSql(sSQL);

                    if (iUpFileCount > 0 && iCou > 0)
                    {
                        if (success.Trim() == "")
                        {
                            success = s文件夹;
                        }
                        else
                        {
                            success = success + "," + s文件夹;
                        }
                    }
                    else
                    {
                        if (sErr.Trim() == "")
                        {
                            sErr = s文件夹 + "上传失败\n";
                        }
                        else
                        {
                            sErr = sErr + "," + s文件夹 + "上传失败\n";
                        }
                    }
                }

                string sInfo = "";
                if (success != "")
                {
                    sInfo = sInfo + "成功：\n" + success;
                }
                if(sErr != "")
                {
                    sInfo = sInfo + "\n\n失败：\n" + sErr;
                }
                MsgBox("提示", sInfo);

                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("上传失败：" + ee.Message);
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

            string sErr = "";
            string success = "";
            int iCount = 0;
            try
            {
                string sSQL = "";

                ClsUseWebService clsWeb = new ClsUseWebService();

                int iRow = gridView1.FocusedRowHandle;


                FolderBrowserDialog open = new FolderBrowserDialog();
                open.ShowDialog();
                string sPath = open.SelectedPath;
                foreach (string items in Directory.GetDirectories(sPath))
                {

                    string s文件夹 = items.Replace(sPath + "\\", "");

                    sSQL = "select 审核人 from 产品档案 where iID = " + ReturnLong(s文件夹).ToString().Trim();
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt == null || dt.Rows.Count == 0 || dt.Rows[0][0].ToString().Trim() == "")
                    {
                        sErr = sErr + "产品 " + s文件夹 + "不存在，或者未审核，不能上传文件\n";
                        continue;
                    }

                    string s别名 = s文件夹;
                    while (s别名.Length < 10)
                    {
                        s别名 = "0" + s别名;
                    }

                    int iFileCount = 0;
                    int iUpFileCount = 0;
                    string sDelName = clsWeb.sDelFolder(s别名, "制版文件");
                    int i = 0;
                    foreach (string item in Directory.GetFiles(items.ToString()))
                    {
                        i += 1;
                        DirectoryInfo directoryinfo = new DirectoryInfo(item);
                        string sFilePath = directoryinfo.FullName;


                        FileInfo fi = new FileInfo(sFilePath.Trim());
                        FileStream fs = fi.OpenRead();
                        byte[] bytes = new byte[fs.Length];
                        fs.Read(bytes, 0, Convert.ToInt32(fs.Length));

                        string sFileName = item.Replace(items.ToString() + "\\", "");
                        string sN = clsWeb.UploadFile(s别名, "制版文件", sFileName, bytes);
                        if (sN.ToLower().IndexOf(sFileName.ToLower()) > 0)
                        {
                            iUpFileCount += 1;
                        }
                    }

                    sSQL = "update [产品档案] set [制版文件] = '√',制版时间 = getdate(),制版人 = '" + sUid + "' where iID = " + s文件夹;
                    int iCou = clsSQLCommond.ExecSql(sSQL);

                    sSQL = @"insert into 图纸上传记录(别名, 类型, 上传人, 上传日期)
                                values('aaaaaa','制版文件','bbbbbb',getdate())";
                    sSQL = sSQL.Replace("aaaaaa", s文件夹);
                    sSQL = sSQL.Replace("bbbbbb", sUid);
                    clsSQLCommond.ExecSql(sSQL);

                    if (iUpFileCount > 0 && iCou > 0)
                    {
                        if (success.Trim() == "")
                        {
                            success = s文件夹;
                        }
                        else
                        {
                            success = success + "," + s文件夹;
                        }
                    }
                    else
                    {
                        if (sErr.Trim() == "")
                        {
                            sErr = s文件夹 + "上传失败\n";
                        }
                        else
                        {
                            sErr = sErr + "," + s文件夹 + "上传失败\n";
                        }
                    }
                }

                string sInfo = "";
                if (success != "")
                {
                    sInfo = sInfo + "成功：\n" + success;
                }
                if (sErr != "")
                {
                    sInfo = sInfo + "\n\n失败：\n" + sErr;
                }
                MsgBox("提示", sInfo);

                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("上传失败：" + ee.Message);
            }
        }

        private void GetClose(string sList)
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
                SetLookUpEdit();
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        /// <summary>
        /// 下拉列表框
        /// </summary>
        private void SetLookUpEdit()
        {
            string sSQL = "SELECT * FROM [dbo].[成衣类别] ORDER BY cCode ";
            DbHelperSQL.connectionString = 系统服务.ClsBaseDataInfo.sConnString;
            DataTable dt = DbHelperSQL.Query(sSQL);
            ItemLookUpEdit成衣类别.Properties.DataSource = dt;

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

            sSQL = @"
SELECT distinct 款号 FROM [dbo].[尺码信息] ORDER BY 款号
";
            dt = DbHelperSQL.Query(sSQL);
            ItemLookUpEdit款号.Properties.DataSource = dt;
        }

        private void GetGrid()
        {
            string sSQL = @"
select cast(0 as bit) as 选择
    ,iID, 尺码信息iID, 编码, 类别, 款号, 款名, 规格, 生产, 纱种, 腰围L, 腰围T, 下摆宽L, 下摆宽T, 针型, 
                领形, 领深L, 领深T, 定制加工费, VIP加工费, 主色, 配色1, 配色2, 配色3, 配色4, 配色5, 主色用纱量, 配色1用纱量, 
                配色2用纱量, 配色3用纱量, 配色4用纱量, 配色5用纱量, 图纸责任人, 制版文件, 制版时间, 制版人, 上机文件, 上机时间, 
                上机人, 制单人, 制单日期, 审核人, 审核日期, 身高L, 身高T, 体重L, 体重T, 胸围L, 胸围T, 胸围杯型L, 胸围杯型T, 身长L, 
                身长T, 肩宽L, 肩宽T, 袖长L, 袖长T
      ,isnull(主色用纱量,0) +isnull(配色1用纱量,0) + isnull(配色2用纱量,0) + isnull(配色3用纱量,0) + isnull(配色4用纱量,0) + isnull(配色5用纱量,0) as 用纱合计
FROM     产品档案
order by 编码,iID
";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;

            for (int i = 0; i < 10; i++)
            {
                gridView1.AddNewRow();
            }

            gridView1.BestFitColumns();
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

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column != gridCol选择)
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridCol选择, true);
                }

                if (e.Column == gridCol编码 && gridView1.FocusedRowHandle == gridView1.RowCount - 1)
                {
                    int iRow = gridView1.FocusedRowHandle;
                    gridView1.AddNewRow();
                    gridView1.FocusedRowHandle = iRow;
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

    }
}