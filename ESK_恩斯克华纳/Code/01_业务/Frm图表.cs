using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;
using 系统服务;
using System.Data.SqlClient;
using System.IO.Ports;

using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;

namespace 业务
{
    public partial class Frm图表 : 系统服务.FrmBaseInfo
    {

        public Frm图表()
        {

            InitializeComponent();

            #region 禁止用户调整表格
       
            //gridView1.OptionsCustomization.

            #endregion

            sLayoutHeadPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Head.xml";
            sLayoutGridPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Grid.xml";
          

            //dtBingGrid = new DataTable();
            //dtBingHead = new DataTable();



            KillProcess("Excel");
        }

        string s测定项目 = "";
        string s检验工位 = "";
        string s班组 = "";

        int iPage = 0;
        int iMax = 0;

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
        //private DataTable SetPrintData(DataTable dt)
        //{
        //    return dt;
        //}

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
            string s测定项目 = this.s测定项目;

           string sSQL = @"
select *
from 
(
    select top 12 * ,getdate() as dtmNow
    from [dbo].[工作台测量] 
    where isnull(删除人,'') = ''
	    and 测定项目 = '{0}'
        and 1=1
    order by iID desc
)a
order by iID 
";
            if (this.s检验工位 != null && this.s检验工位 != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and 工作台 = '" + this.s检验工位 + "'");
            }
            if (this.s班组 != null && this.s班组 != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and 班组 = '" + this.s班组 + "'");
            }

            sSQL = string.Format(sSQL, s测定项目);
            System.Data.DataTable dt = DbHelperSQL.Query(sSQL);

            if (dt == null || dt.Rows.Count == 0)
                return;

            object Document = this.axFramerControl1.ActiveDocument;

            if (Document == null)
            {
                return;
            }

            Workbook workbook = null;
            Worksheet worksheet = null;
            try
            {
                //// 获取当前工作薄
                workbook = (Microsoft.Office.Interop.Excel.Workbook)Document;

                //// 获取当前工作页
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.ActiveSheet;

                //worksheet.Cells[1, 1] = "test";

                worksheet.Cells[2, 2] = s测定项目;
                worksheet.Cells[31, 3] = "尺寸公差：" + dt.Rows[0]["尺寸公差"].ToString().Trim();


                decimal d上限 = BaseFunction.ReturnDecimal(dt.Rows[0]["上限"]);
                if (d上限 == 0)
                {
                    d上限 = 9999999999;
                }
                decimal d下限 = BaseFunction.ReturnDecimal(dt.Rows[0]["下限"]);

                worksheet.Cells[31, 2] = s测定项目;
                worksheet.Cells[35, 10] = "图表生成时间：" + BaseFunction.ReturnDate(dt.Rows[0]["dtmNow"]).ToString("yyyy-MM-dd HH:mm:ss");   //图表生成时间
                worksheet.Cells[31, 7] = BaseFunction.ReturnDecimal(dt.Rows[0]["下限"]);
                worksheet.Cells[31, 9] = BaseFunction.ReturnDecimal(dt.Rows[0]["上限"]);
                int iCol = 3;
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    decimal d测量值 = BaseFunction.ReturnDecimal(dt.Rows[i]["测量值"]);
                //    worksheet.Cells[32, iCol + i] = BaseFunction.ReturnDate(dt.Rows[i]["检验时间"]);
                //    worksheet.Cells[33, iCol + i] = BaseFunction.ReturnDate(dt.Rows[i]["检验时间"]);
                //    worksheet.Cells[34, iCol + i] = BaseFunction.ReturnDecimal(dt.Rows[i]["测量值"]);
                //    worksheet.Cells[36, iCol + i] = dt.Rows[i]["检验员"].ToString().Trim();
                //}

                //Range range = null;
                //Range range = worksheet.get_Range("B50:D50", Type.Missing);

                //int[] iList = new int[3] { 1, 2, 3 };

                //object[,] values = new object[55, 555];

                //range.Value2 = iList;

                DateTime[,] dtmList = new DateTime[2,12];
                double[] dList = new double[12];
                string[] s检验员 = new string[12];

                for (int j = 0; j < 12; j++)
                {
                    dtmList[0, j] = BaseFunction.ReturnDate(dt.Rows[j]["检验时间"]);
                    dtmList[1, j] = BaseFunction.ReturnDate(dt.Rows[j]["检验时间"]);
                    dList[j] = BaseFunction.ReturnDouble(dt.Rows[j]["测量值"]);
                    s检验员[j] = dt.Rows[j]["检验员"].ToString().Trim();
                }


                Range range = worksheet.get_Range("C32:N33", Type.Missing);
                range.Value2 = dtmList;


                Range range2 = worksheet.get_Range("C34:N34", Type.Missing);
                range2.Value2 = dList;

                Range range3 = worksheet.get_Range("C36:N36", Type.Missing);
                range3.Value2 = s检验员;
            }
            catch (Exception ee)
            {

                throw new Exception(ee.Message);
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
            throw new NotImplementedException();
            //gridView1.AddNewRow();
        }
        /// <summary>
        /// 删行
        /// </summary>
        private void btnDelRow()
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
            SaveFileDialog SA = new SaveFileDialog();
            SA.DefaultExt = "xlsx";
            DialogResult d = SA.ShowDialog();

            if (d == DialogResult.OK)
            {
                string spath = SA.FileName;
                this.axFramerControl1.Save(spath, true, "", "");
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
        System.Data.DataTable dt项目;

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                Frm图表筛选条件 frm = new Frm图表筛选条件(DbHelperSQL.connectionString);
                frm.StartPosition = FormStartPosition.CenterParent;
                DialogResult d = frm.ShowDialog();
                if (d == DialogResult.OK)
                {
                    s测定项目 = frm.s测定项目;
                    s检验工位 = frm.s检验工位;
                    s班组 = frm.s班组;
                }
              
                //    string sPathExcel = base.sProPath + "\\模板\\图表.xlsx";

                //    this.axFramerControl1.Open(sPathExcel);

                string path = base.sProPath + "\\模板\\图表.xlsx";


                if (!File.Exists(path))
                {
                    MessageBox.Show("文件不存在或未标识的文件格式！", "提示信息");
                    return;
                }

                this.axFramerControl1.Titlebar = false;
                this.axFramerControl1.Titlebar = false;//是否显示excel标题栏
                this.axFramerControl1.Menubar = true;//是否显示excel的菜单栏
                this.axFramerControl1.Toolbars = false;//是否显示excel的工具栏

                //this.axFramerControl1.Open(path, true, "Excel.Sheet", "", "");

                timer1.Start();

                startExcelTime = DateTime.Now;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
           
        }

        DateTime startExcelTime;
        private void Frm图表_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.axFramerControl1 = null;

                KillProcess("Excel");
            }
            catch { }
        }

        public void KillProcess(string aProcessName)
        {
            //Process myproc = new Process();
            ////得到所有打开的进程
            //try
            //{
            //    foreach (Process thisproc in Process.GetProcessesByName(aProcessName))
            //    {
            //        if (!thisproc.CloseMainWindow())
            //        {
            //            thisproc.Kill();
            //        }
            //    }
            //}
            //catch (Exception Exc)
            //{

            //}
            try
            {
                PerformanceCounter PC = new PerformanceCounter();//性能计数器
                System.Diagnostics.Process[] ExcelProcesses;
                ExcelProcesses = System.Diagnostics.Process.GetProcessesByName("EXCEL");

                foreach (System.Diagnostics.Process IsProcedding in ExcelProcesses)
                {
                    if (IsProcedding.ProcessName == "EXCEL")
                    {
                        PC.InstanceName = IsProcedding.ProcessName;
                        DateTime start = IsProcedding.StartTime;
                        TimeSpan ss = DateTime.Now - start;
                        if ((ss.Hours >= 1 || ss.Minutes > 10) || (startExcelTime.Day == start.Day && startExcelTime.Hour == start.Hour && startExcelTime.Minute == start.Minute && startExcelTime.Second == start.Second && startExcelTime.Millisecond == start.Millisecond))
                        {
                            if (!IsProcedding.HasExited)
                            {
                                try
                                {
                                    IsProcedding.Kill();
                                }
                                catch (Exception ex)
                                {

                                }
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                btnRefresh();
            }
            catch { }
                
        }
    }
}
