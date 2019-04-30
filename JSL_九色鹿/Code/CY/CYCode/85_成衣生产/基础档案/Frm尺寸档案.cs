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
    public partial class Frm尺寸档案 : 系统服务.FrmBaseInfo
    {

        public Frm尺寸档案()
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
            gridView1.PostEditor();

            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            try
            {
                int iCou = 0;

                DialogResult d = MessageBox.Show("确定删除选中行么？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (d != DialogResult.Yes)
                    return;

                SqlConnection conn = new SqlConnection(系统服务.ClsBaseDataInfo.sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                string sErr = "";

                try
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        bool b = ReturnBool(gridView1.GetRowCellValue(i, gridColchoose));
                        if (!b)
                            continue;

                        int iID = ReturnInt(gridView1.GetRowCellValue(i, gridColiID));
                        if (iID == 0)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "未保存，不能删除\n";
                            continue;
                        }

                        string s制版文件 = gridView1.GetRowCellValue(i, gridCol制版人).ToString().Trim();
                        string s上机文件 = gridView1.GetRowCellValue(i, gridCol上机人).ToString().Trim();
                        if (s制版文件 != "" || s上机文件 != "")
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "已经有文件，不能删除\n";
                            continue;
                        }

                        sSQL = "delete 尺码信息 where iID = " + gridView1.GetRowCellValue(i, gridColiID).ToString();
                        iCou += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    if (sErr != "")
                    {
                        throw new Exception(sErr);
                    }
                    if (iCou > 0)
                    {
                        tran.Commit();
                        MessageBox.Show("删除成功");
                        GetGrid();
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
                MessageBox.Show("删除失败:" + ee.Message);
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

            gridView1.PostEditor();

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
                        Boolean b = ReturnBool(gridView1.GetRowCellValue(i, gridColchoose));
                        if (!b)
                            continue;

                        Model.尺码信息 model = new 成衣生产.Model.尺码信息();
                        model.款号 = gridView1.GetRowCellValue(i, gridCol款号).ToString().Trim();
                        model.身高L = ReturnDecimal(gridView1.GetRowCellValue(i, gridCol身高L), 2);
                        model.身高T = ReturnDecimal(gridView1.GetRowCellValue(i, gridCol身高T), 2);
                        model.体重L = ReturnDecimal(gridView1.GetRowCellValue(i, gridCol体重L), 2);
                        model.体重T = ReturnDecimal(gridView1.GetRowCellValue(i, gridCol体重T), 2);
                        model.胸围L = ReturnDecimal(gridView1.GetRowCellValue(i, gridCol胸围L), 2);
                        model.胸围T = ReturnDecimal(gridView1.GetRowCellValue(i, gridCol胸围T), 2);
                        model.胸围杯型L = ReturnDecimal(gridView1.GetRowCellValue(i, gridCol胸围杯型L), 2);
                        model.胸围杯型T = ReturnDecimal(gridView1.GetRowCellValue(i, gridCol胸围杯型T), 2);
                        model.身长L = ReturnDecimal(gridView1.GetRowCellValue(i, gridCol身长L), 2);
                        model.身长T = ReturnDecimal(gridView1.GetRowCellValue(i, gridCol身长T), 2);
                        model.肩宽L = ReturnDecimal(gridView1.GetRowCellValue(i, gridCol肩宽L), 2);
                        model.肩宽T = ReturnDecimal(gridView1.GetRowCellValue(i, gridCol肩宽T), 2);
                        model.袖长L = ReturnDecimal(gridView1.GetRowCellValue(i, gridCol袖长L), 2);
                        model.袖长T = ReturnDecimal(gridView1.GetRowCellValue(i, gridCol袖长T), 2);

                        if (model.款号 == "")
                            continue;
                        if (model.身高L == 0 || model.身高T == 0 || model.身高L > model.身高T)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "身高错误\n";
                        }
                        if (model.体重L == 0 || model.体重T == 0 || model.体重L > model.体重T)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "体重错误\n";
                        }
                        if (model.胸围L == 0 || model.胸围T == 0 || model.胸围L > model.胸围L)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "胸围错误\n";
                        }
                        //if (model.胸围杯型L == 0 || model.胸围杯型T == 0 || model.胸围杯型L > model.胸围杯型T)
                        //{
                        //    sErr = sErr + "行" + (i + 1).ToString() + "胸围杯型错误\n";
                        //}
                        if (model.身长L == 0 || model.身长T == 0 || model.身长L > model.身长T)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "身长错误\n";
                        }
                        if (model.肩宽L == 0 || model.肩宽T == 0 || model.肩宽L > model.肩宽T)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "肩宽错误\n";
                        }
                        if (model.袖长L == 0 || model.袖长T == 0 || model.袖长L > model.袖长T)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "袖长错误\n";
                        }
                        if(sErr != "")
                        {
                            continue;
                        }

                        DAL.尺码信息 dal = new 成衣生产.DAL.尺码信息();
                        sSQL = dal.Add(model);
                        iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
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
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

          
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
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void GetGrid()
        {
            int iRow = gridView1.FocusedRowHandle;
            string sSQL = @"
select *,cast(0 as bit) as choose
FROM  尺码信息
where 1=1
order by 款号, 身高L, 身高T, 体重L, 体重T, 胸围L, 胸围T, 胸围杯型L, 胸围杯型T, 身长L, 身长T, 肩宽L, 肩宽T, 袖长L, 袖长T
";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;

            for (int i = 0; i < 10; i++)
            {
                gridView1.AddNewRow();
            }

            gridView1.FocusedRowHandle = iRow;
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

        private void ItemButtonEdit制版文件_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                ClsUseWebService clsWeb = new ClsUseWebService();

                int iRow = gridView1.FocusedRowHandle;

                int iFileCount = 0;
                int iUpFileCount = 0;

                string sID = gridView1.GetRowCellValue(iRow, gridColiID).ToString().Trim();
                if (sID == "")
                {
                    throw new Exception("请先保存尺寸档案后上传制版文件");
                }
                string s别名 = sID;
                while (s别名.Length < 10)
                {
                    s别名 = "0" + s别名;
                }

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
                        string sPath = open.SelectedPath;

                        string sDelName = clsWeb.sDelFolder(s别名, "制版文件");
                        int i = 0;
                        foreach (string item in Directory.GetFiles(sPath))
                        {
                            i += 1;
                            DirectoryInfo directoryinfo = new DirectoryInfo(item);
                            string sFilePath = directoryinfo.FullName;


                            FileInfo fi = new FileInfo(sFilePath.Trim());
                            FileStream fs = fi.OpenRead();
                            byte[] bytes = new byte[fs.Length];
                            fs.Read(bytes, 0, Convert.ToInt32(fs.Length));

                            //sSQL = "insert into 图纸文件(别名,类型,文件)values " +
                            //      "	('" + s别名 + "','制版文件',@file" + i.ToString() + ")";

                            //cmd.CommandType = CommandType.Text;
                            //cmd.CommandText = sSQL;
                            //SqlParameter spFile = new SqlParameter("@file" + i.ToString(), SqlDbType.Image);
                            //spFile.Value = bytes;
                            //cmd.Parameters.Add(spFile);
                            //iCount = iCount + cmd.ExecuteNonQuery();

                            string sFileName = item.Replace(sPath + "\\", "");
                            string sN = clsWeb.UploadFile(s别名, "制版文件", sFileName, bytes);
                            if (sN.ToLower().IndexOf(sFileName.ToLower()) > 0)
                            {
                                iUpFileCount += 1;
                            }
                        }
                        iFileCount = i;
                        if (iFileCount == 0)
                            throw new Exception("上传失败");

                        sSQL = "update [尺码信息] set [制版文件] = '√',制版时间 = getdate() ,制版人 = '" + sUid + "' where iID = " + sID;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = sSQL;
                        cmd.ExecuteNonQuery();

                        sSQL = @"insert into 图纸上传记录(别名, 类型, 上传人, 上传日期)
                                values('aaaaaa','制版文件','bbbbbb',getdate())";
                        sSQL = sSQL.Replace("aaaaaa", sID);
                        sSQL = sSQL.Replace("bbbbbb", sUid);
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = sSQL;

                        if (iUpFileCount == iFileCount)
                        {
                            tx.Commit();

                            MessageBox.Show("上传成功\n");
                            GetGrid();
                        }
                        else
                        {
                            throw new Exception("请选择需要保存的数据");
                        }
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

        private void ItemButtonEdit上机文件_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                ClsUseWebService clsWeb = new ClsUseWebService();

                int iRow = gridView1.FocusedRowHandle;

                int iFileCount = 0;
                int iUpFileCount = 0;

                string sID = gridView1.GetRowCellValue(iRow, gridColiID).ToString().Trim();
                if (sID == "")
                {
                    throw new Exception("请先保存尺寸档案后上传上机文件");
                }
                string s别名 = sID;
                while (s别名.Length < 10)
                {
                    s别名 = "0" + s别名;
                }

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
                        string sPath = open.SelectedPath;

                        string sDelName = clsWeb.sDelFolder(s别名, "上机文件");
                        int i = 0;
                        foreach (string item in Directory.GetFiles(sPath))
                        {
                            i += 1;
                            DirectoryInfo directoryinfo = new DirectoryInfo(item);
                            string sFilePath = directoryinfo.FullName;

                            FileInfo fi = new FileInfo(sFilePath.Trim());
                            FileStream fs = fi.OpenRead();
                            byte[] bytes = new byte[fs.Length];
                            fs.Read(bytes, 0, Convert.ToInt32(fs.Length));

                            string sFileName = item.Replace(sPath + "\\", "");
                            string sN = clsWeb.UploadFile(s别名, "上机文件", sFileName, bytes);
                            if (sN.ToLower().IndexOf(sFileName.ToLower()) > 0)
                            {
                                iUpFileCount += 1;
                            }
                        }
                        iFileCount = i;
                        if (iFileCount == 0)
                            throw new Exception("上传失败");

                        sSQL = "update [尺码信息] set [上机文件] = '√',上机时间 = getdate(),上机人 = '" + sUid + "' where iID = " + sID;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = sSQL;
                        cmd.ExecuteNonQuery();

                        sSQL = @"insert into 图纸上传记录(别名, 类型, 上传人, 上传日期)
                                values('aaaaaa','上机文件','bbbbbb',getdate())";
                        sSQL = sSQL.Replace("aaaaaa", sID);
                        sSQL = sSQL.Replace("bbbbbb", sUid);
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = sSQL;

                        if (iUpFileCount == iFileCount)
                        {
                            tx.Commit();

                            MessageBox.Show("上传成功\n");
                            GetGrid();
                        }
                        else
                        {
                            throw new Exception("请选择需要保存的数据");
                        }
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

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column != gridColchoose)
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridColchoose, true);
                }
            }
            catch { }
        }
       
    }
}