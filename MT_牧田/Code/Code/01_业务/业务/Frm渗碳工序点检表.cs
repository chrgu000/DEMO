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

namespace 业务
{
    public partial class Frm渗碳工序点检表 : 系统服务.FrmBaseInfo
    {


        public Frm渗碳工序点检表()
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
            int i = 1;
            int p_s1 = 14;
            int p_e1 = 31;
            int q_s1 = 2;
            int q_e1 = 4;

            int p_s2 = 14;
            int p_e2 = 28;
            int q_s2 = 10;
            int q_e2 = 12;

            int p_s3 = 10;
            int p_e3 = 15;
            int q_s3 = 20;
            int q_e3 = 42;

            int p_n = 0;
            int q_n = 0;
            try
            {
                //判断模板文件是否存在
                if (File.Exists(txtMBPath.Text) == false)
                {
                    throw new Exception("模板文件不存在");
                }

                //判断数据文件是否存在
                if (File.Exists(btnYU.Text) == false)
                {
                    throw new Exception("数据文件不存在");
                }

                var filenew = btnOut.Text + "\\" + "工具手柄硬度点检表" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";

                File.Copy(txtMBPath.Text, filenew, true);

                //判断创建文件是否存在
                if (File.Exists(filenew) == false)
                {
                    throw new Exception("数据文件不存在");
                }


                XSSFWorkbook oldwk = GetSheet(btnYU.Text);//原数据Sheet
                XSSFSheet oldsheet = (XSSFSheet)oldwk.GetSheetAt(0);

                XSSFWorkbook newwk = GetSheet(filenew);//写入数据Sheet
                XSSFSheet newsheet = (XSSFSheet)newwk.GetSheetAt(0);

                #region 第一区域
                bool b = false;
                while (b == false)
                {
                    if (oldsheet.GetRow(i) == null)
                    {
                        b = true;
                        continue;
                    }
                    ICell icell = oldsheet.GetRow(i).GetCell(1);
                    if (icell == null)
                    {
                        continue;
                    }
                    double d;//写入数据
                    switch (icell.CellType)
                    {
                        case CellType.NUMERIC:
                            d = icell.NumericCellValue;
                            break;
                        case CellType.STRING:
                            d = ReturnDouble(icell.NumericCellValue);
                            break;
                        default:
                            d = 0;
                            break;
                    }

                    if (p_n == 0 && q_n == 0)
                    {
                        p_n = p_s1;//第一行
                        q_n = q_s1;
                    }
                    else if (p_n <= p_e1 || q_n <= q_e1)
                    {
                        if (q_n == q_e1)//换一行
                        {
                            p_n++;
                            q_n = q_s1;
                        }
                        else//后移一格
                        {
                            q_n++;
                        }
                    }
                    if (p_n <= p_e1)
                    {
                        ICell newicell = newsheet.GetRow(p_n).GetCell(q_n);
                        if (newicell == null)
                        {
                            newicell = newsheet.GetRow(p_n).CreateCell(q_n);
                        }
                        newicell.SetCellValue(d);

                        i++;
                    }
                    else
                    {
                        b = true;
                    }
                }
                #endregion

                #region 第二区域
                b = false;
                p_n = 0;
                q_n = 0;
                while (b == false)
                {
                    if (oldsheet.GetRow(i) == null)
                    {
                        b = true;
                        continue;
                    }
                    ICell icell = oldsheet.GetRow(i).GetCell(1);
                    if (icell == null)
                    {
                        continue;
                    }
                    double d;//写入数据
                    switch (icell.CellType)
                    {
                        case CellType.NUMERIC:
                            d = icell.NumericCellValue;
                            break;
                        case CellType.STRING:
                            d = ReturnDouble(icell.NumericCellValue);
                            break;
                        default:
                            d = 0;
                            break;
                    }

                    if (p_n == 0 && q_n == 0)
                    {
                        p_n = p_s2;//第一行
                        q_n = q_s2;
                    }
                    else if (p_n <= p_e2 || q_n <= q_e2)
                    {
                        if (q_n == q_e2)//换一行
                        {
                            p_n++;
                            q_n = q_s2;
                        }
                        else//后移一格
                        {
                            q_n++;
                        }
                    }
                    if (p_n <= p_e2)
                    {
                        ICell newicell = newsheet.GetRow(p_n).GetCell(q_n);
                        if (newicell == null)
                        {
                            newicell = newsheet.GetRow(p_n).CreateCell(q_n);
                        }
                        newicell.SetCellValue(d);

                        i++;
                    }
                    else
                    {
                        b = true;
                    }
                }
                #endregion

                #region 第三区域
                b = false;
                p_n = 0;
                q_n = 0;
                while (b == false)
                {
                    if (oldsheet.GetRow(i) == null)
                    {
                        b = true;
                        continue;
                    }
                    ICell icell = oldsheet.GetRow(i).GetCell(1);
                    if (icell == null)
                    {
                        continue;
                    }
                    double d;//写入数据
                    switch (icell.CellType)
                    {
                        case CellType.NUMERIC:
                            d = icell.NumericCellValue;
                            break;
                        case CellType.STRING:
                            d = ReturnDouble(icell.NumericCellValue);
                            break;
                        default:
                            d = 0;
                            break;
                    }

                    if (p_n == 0 && q_n == 0)
                    {
                        p_n = p_s3;//第一行
                        q_n = q_s3;
                    }
                    else if (p_n <= p_e3 || q_n <= q_e3)
                    {
                        if (q_n == q_e3)//换一行
                        {
                            p_n++;
                            q_n = q_s3;
                        }
                        else//后移二格
                        {
                            q_n++;
                            q_n++;
                        }
                    }
                    if (p_n <= p_e3)
                    {
                        ICell newicell = newsheet.GetRow(p_n).GetCell(q_n);
                        if (newicell == null)
                        {
                            newicell = newsheet.GetRow(p_n).CreateCell(q_n);
                        }
                        newicell.SetCellValue(d);

                        i++;
                    }
                    else
                    {
                        b = true;
                    }
                }
                #endregion
                //ICell oldicell = oldsheet.GetRow(1).GetCell(4);


                //XSSFWorkbook newworkbook = new XSSFWorkbook();

                //XSSFRow newirow = (XSSFRow)newsheet.CreateRow(1);

                //XSSFCell newicell = (XSSFCell)newirow.CreateCell(1);
                //newicell.SetCellValue(oldicell.NumericCellValue); 

                using (FileStream fsnew = new FileStream(filenew, FileMode.Create, FileAccess.Write))
                {
                    newwk.Write(fsnew);
                    MessageBox.Show("ok");
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败:" + ee.Message);
            }

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

        private void Frm渗碳工序点检表_Load(object sender, EventArgs e)
        {
            try
            {
                string sPath = Application.StartupPath + @"\模板\工具手柄硬度点检表.xlsx";
                txtMBPath.Text = sPath;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败:" + ee.Message);
            }
        }

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            { 
            
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败:" + ee.Message);
            }
        }

        private void buttonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载模板失败:" + ee.Message);
            }
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnYU_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Title = "请选择文件夹";
                dialog.Filter = "所有文件(*.*)|*.*";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    btnYU.Text = dialog.FileName;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据源失败:" + ee.Message);
            }
        }

        private void btnOut_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
                dialog.Description = "请选择Txt所在文件夹";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    btnOut.Text = dialog.SelectedPath;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据源失败:" + ee.Message);
            }
        }
    }
}
