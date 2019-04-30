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
using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF;
using NPOI.XSSF.UserModel;
using 系统服务;

namespace 业务
{
    public partial class Frm高频淬火回火 : 系统服务.FrmBaseInfo
    {


        public Frm高频淬火回火()
        {
            InitializeComponent();

   

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

        }
        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
         

        }

        private void GetSel()
        {
           
        }

        /// <summary>
        /// 首页
        /// </summary>
        private void btnFirst()
        {
           
        }
        /// <summary>
        /// 上页
        /// </summary>
        private void btnPrev()
        {
          
        }
        /// <summary>
        /// 下页
        /// </summary>
        private void btnNext()
        {
 
        }
        /// <summary>
        /// 末页
        /// </summary>
        private void btnLast()
        {
           
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
           
        }
        /// <summary>
        /// 删行
        /// </summary>
        private void btnDelRow()
        {
            

        }
        /// <summary>
        /// 新增
        /// </summary>
        private void btnAdd()
        {
          
        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {
            
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
            //int i = 1;
            //int p_s1 = 11;
            //int p_e1 = 20;
            //int q_s1 = 3;
            //int q_e1 = 20;

            //int s_s1 = 0;
            //int s_e1 = 3;

            //int p_n = 0;
            //int q_n = 0;
            //int s_n = 0;
            //try
            //{
            //    //判断模板文件是否存在
            //    if (File.Exists(txtMBPath.Text) == false)
            //    {
            //        throw new Exception("模板文件不存在");
            //    }

            //    //判断数据文件是否存在
            //    if (File.Exists(btnYU.Text) == false)
            //    {
            //        throw new Exception("数据文件不存在");
            //    }

            //    var filenew = btnOut.Text + "\\" + "转子轴硬度 点检表" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";

            //    File.Copy(txtMBPath.Text, filenew, true);

            //    //判断创建文件是否存在
            //    if (File.Exists(filenew) == false)
            //    {
            //        throw new Exception("数据文件不存在");
            //    }


            //    XSSFWorkbook oldwk = GetSheet(btnYU.Text);//原数据Sheet
            //    XSSFSheet oldsheet = (XSSFSheet)oldwk.GetSheetAt(0);

            //    XSSFWorkbook newwk = GetSheet(filenew);//写入数据Sheet
            //    XSSFSheet newsheet = (XSSFSheet)newwk.GetSheetAt(0);

            //    #region 区域
            //    bool b = false;
            //    while (b == false)
            //    {
            //        if (oldsheet.GetRow(i) == null)
            //        {
            //            b = true;
            //            continue;
            //        }
            //        ICell icell = oldsheet.GetRow(i).GetCell(1);
            //        if (icell == null)
            //        {
            //            continue;
            //        }
            //        double d;//写入数据
            //        switch (icell.CellType)
            //        {
            //            case CellType.NUMERIC:
            //                d = icell.NumericCellValue;
            //                break;
            //            case CellType.STRING:
            //                d = ReturnDouble(icell.NumericCellValue);
            //                break;
            //            default:
            //                d = 0;
            //                break;
            //        }

            //        if (p_n == 0 && q_n == 0)
            //        {
            //            p_n = p_s1;//第一行
            //            q_n = q_s1;
            //            s_n = s_s1;
            //        }
            //        else if (p_n <= p_e1 || q_n <= q_e1)
            //        {
            //            if (q_n == q_e1)//换一行
            //            {
            //                p_n++;
            //                q_n = q_s1;
            //                s_n = s_s1;
            //            }
            //            else//后移一格
            //            {
            //                q_n++;
            //                s_n++;
            //                if (s_n == s_e1)
            //                {
            //                    q_n++;
            //                    q_n++;
            //                    s_n = s_s1;
            //                }
                            
            //            }
            //        }
            //        if (p_n <= p_e1)
            //        {
            //            ICell newicell = newsheet.GetRow(p_n).GetCell(q_n);
            //            if (newicell == null)
            //            {
            //                newicell = newsheet.GetRow(p_n).CreateCell(q_n);
            //            }
            //            newicell.SetCellValue(d);

            //            i++;
            //        }
            //        else
            //        {
            //            b = true;
            //        }
            //    }
            //    #endregion

            //    using (FileStream fsnew = new FileStream(filenew, FileMode.Create, FileAccess.Write))
            //    {
            //        newwk.Write(fsnew);
            //        MessageBox.Show("ok");
            //    }

            //}
            //catch (Exception ee)
            //{
            //    MessageBox.Show("加载窗体失败:" + ee.Message);
            //}

        }

        private XSSFWorkbook GetSheet(string filename)
        {
            var ext = Path.GetExtension(filename).ToLower();
            FileStream fs = File.OpenRead(filename);

            XSSFWorkbook wk = new XSSFWorkbook(fs);
            return wk;
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

        private void Frm高频淬火回火_Load(object sender, EventArgs e)
        {
            try
            {
                string sPath = Application.StartupPath + @"\模板\转子轴硬度 点检表.xlsx";
                txtMBPath.Text = sPath;

                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败:" + ee.Message);
            }
        }

        private void GetGrid()
        {
            string sSQL = @"
select *
from [高频淬火·回火工序品质确认记录]
where cCode = '{0}'
order by iRow
";
            sSQL = string.Format(sSQL, txt序号.Text.Trim());

            DataTable dt = DbHelperSQL.Query(sSQL);

            gridControl1.DataSource = dt;
            gridView1.BestFitColumns();

            while (gridView1.RowCount < 100)
            {
                gridView1.AddNewRow();
            }

            gridView1.FocusedColumn = gridColGroup1;
            gridView1.FocusedRowHandle = 0;
        }


        private void txt测量数值_KeyUp(object sender, KeyEventArgs e)
        {
            try
            { }
            catch { }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            try
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
            catch { }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == gridColGroup1)
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridColTime1, DateTime.Now);
                }
                if (e.Column == gridColGroup2)
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridColTime2, DateTime.Now);
                }
                if (e.Column == gridColGroup3)
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridColTime3, DateTime.Now);
                }
                if (e.Column == gridColGroup4)
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridColTime4, DateTime.Now);
                }
                if (e.Column == gridColGroup5)
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridColTime5, DateTime.Now);
                }
                if (e.Column == gridColGroup6)
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridColTime6, DateTime.Now);
                }
                if (e.Column == gridColGroup7)
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridColTime7, DateTime.Now);
                }
                if (e.Column == gridColGroup8)
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridColTime8, DateTime.Now);
                }
                if (e.Column == gridColGroup9)
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridColTime9, DateTime.Now);
                }
                if (e.Column == gridColGroup10)
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridColTime10, DateTime.Now);
                }
            }
            catch { }
        }


        private void ItemTextEdit测量值_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridcolFoc = gridView1.FocusedColumn;
                    int iRowFoc = gridView1.FocusedRowHandle;

                    if (iRowFoc == gridView1.RowCount - 1)
                    {
                        gridView1.AddNewRow();
                    }

                    

                    gridView1.FocusedRowHandle = iRowFoc + 1;
                }
            }
            catch (Exception ee)
            { }
        }


        //private void btnYU_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        //{
        //    try
        //    {
        //        OpenFileDialog dialog = new OpenFileDialog();
        //        dialog.Title = "请选择文件夹";
        //        dialog.Filter = "所有文件(*.*)|*.*";
        //        if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //        {
        //            btnYU.Text = dialog.FileName;
        //        }
        //    }
        //    catch (Exception ee)
        //    {
        //        MessageBox.Show("加载数据源失败:" + ee.Message);
        //    }
        //}

        //private void btnOut_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        //{
        //    try
        //    {
        //        System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
        //        dialog.Description = "请选择Txt所在文件夹";
        //        if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //        {
        //            btnOut.Text = dialog.SelectedPath;
        //        }
        //    }
        //    catch (Exception ee)
        //    {
        //        MessageBox.Show("加载数据源失败:" + ee.Message);
        //    }
        //}
    }
}
