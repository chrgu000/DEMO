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
using Microsoft.VisualBasic;

using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;
using System.Threading;

namespace 业务
{
    public partial class Frm检验图表 : 系统服务.FrmBaseInfo
    {

        public Frm检验图表()
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

        string s检验工位 = "";
        string s班组 = "";

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
            ReflashData();
            LoadExcel();
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
            string sSQL = @"select getdate()";
            System.Data.DataTable dt = DbHelperSQL.Query(sSQL);
            dtmStart = BaseFunction.ReturnDate(dt.Rows[0][0]);
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
            Frm检验图表数据修改 frm = new Frm检验图表数据修改(DbHelperSQL.connectionString, s班组, s测定项目, s检验工位,sUserName);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
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

        private AxDSOFramer.AxFramerControl axFramerControl1 = new AxDSOFramer.AxFramerControl();
        Thread thOpen;
        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                Frm检验图表筛选条件 frm = new Frm检验图表筛选条件(DbHelperSQL.connectionString);
                frm.StartPosition = FormStartPosition.CenterParent;
                DialogResult d = frm.ShowDialog();
                if (d == DialogResult.OK)
                {
                    s检验工位 = frm.s检验工位;
                    s班组 = frm.s班组;
                }

                string path = base.sProPath + "\\模板\\图表.xlsx";

                thOpen = new Thread(new ThreadStart(FOpen));
                ((System.ComponentModel.ISupportInitialize)(this.axFramerControl1)).BeginInit();
                axFramerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                axFramerControl1.Enabled = true;
                axFramerControl1.Location = new System.Drawing.Point(0, 0);
                //this.spc_Excel.Name = "spc_Excel";

                this.panel1.Controls.Add(axFramerControl1);
                //spc_Excel.Panel1.Controls.Add(axFramerControl1);
             

                ((System.ComponentModel.ISupportInitialize)(this.axFramerControl1)).EndInit();

                this.axFramerControl1.Titlebar = false;         //是否显示excel标题栏
                this.axFramerControl1.Menubar = false;           //是否显示excel的菜单栏
                this.axFramerControl1.Toolbars = false;         //是否显示excel的工具栏


                timer1.Start();

                //启动现成加载EXCEL
                thOpen.Start();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
           
        }

        private void FOpen()
        {

            lock (axFramerControl1)
            {
                try
                {
                    axFramerControl1.Open(base.sProPath + "\\模板\\图表.xlsx", false, "Excel.Sheet", "", "");
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

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
            try
            {
                PerformanceCounter PC = new PerformanceCounter();//性能计数器
                System.Diagnostics.Process[] ExcelProcesses;
                ExcelProcesses = System.Diagnostics.Process.GetProcessesByName("EXCEL");

                foreach (System.Diagnostics.Process IsProcedding in ExcelProcesses)
                {
                    if (IsProcedding.ProcessName.ToUpper() == "EXCEL")
                    {
                        PC.InstanceName = IsProcedding.ProcessName;
                        DateTime start = IsProcedding.StartTime;
                        TimeSpan ss = DateTime.Now - start;

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
            catch (Exception ex)
            {

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (dtmStart < DateTime.Today.AddDays(-3))
                {
                    return;
                }

                btnRefresh();
            }
            catch { }
                
        }

        string s发射器ID;
        string s量具品名;
        string s测定项目;
        string s测定项目日文;
        string s尺寸公差;
        DateTime dtmStart;
        string sStatus;
        decimal d测量值;
        
        //加载测量数据
        private void ReflashData()
        {
            string s检验工位 = this.s检验工位;
            if (s检验工位 == "")
                return;

            SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
            conn.Open();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {

                string sSQL = @"
select * 
from [dbo].[检验值] a
	left join [dbo].[检验标准档案] b on a.发射器编号 = b.发射器ID
where isnull(a.已取值,0) = 0
	and a.dtmCreate >= '{0}'
	and a.发射器编号 in (select 发射器ID from [dbo].[发射器档案设置] where [检验工位] = '{1}')
order by a.iID
";
                sSQL = string.Format(sSQL, dtmStart.ToString("yyyy-MM-dd HH:mm:ss"), s检验工位);
                System.Data.DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];


                if (dt != null && dt.Rows.Count > 0)
                {
                    s发射器ID = dt.Rows[0]["发射器编号"].ToString().Trim();
                    s量具品名 = dt.Rows[0]["量具品名"].ToString().Trim();
                    s测定项目 = dt.Rows[0]["测定项目"].ToString().Trim();
                    s测定项目日文 = dt.Rows[0]["测定项目日文"].ToString().Trim();
                    s尺寸公差 = dt.Rows[0]["尺寸公差"].ToString().Trim();

                    decimal d上限 = 9999999999999;
                    if (dt.Rows[0]["上限"].ToString().Trim() != "")
                    {
                        d上限 = BaseFunction.ReturnDecimal(dt.Rows[0]["上限"]);
                    }

                    decimal d下限 = 0;
                    if (dt.Rows[0]["下限"].ToString().Trim() != "")
                    {
                        d下限 = BaseFunction.ReturnDecimal(dt.Rows[0]["下限"]);
                    }

                    d测量值 = BaseFunction.ReturnDecimal(dt.Rows[0]["测量数值"]);

                    if (d测量值 <= d上限 && d测量值 >= d下限)
                    {
                        sStatus = "OK";
                    }
                    else
                    {
                        sStatus = "NG";
                        Interaction.Beep();
                    }

                    Model.工作台测量 mod = new 业务.Model.工作台测量();
                    mod.发射器ID = BaseFunction.ReturnInt(dt.Rows[0]["发射器编号"]);
                    mod.工作台 = s检验工位;
                    mod.量具品名 = dt.Rows[0]["量具品名"].ToString().Trim();
                    mod.测定项目 = dt.Rows[0]["测定项目"].ToString().Trim();
                    mod.测定项目日文 = dt.Rows[0]["测定项目日文"].ToString().Trim();
                    mod.规格 = dt.Rows[0]["规格"].ToString().Trim();
                    mod.尺寸公差 = dt.Rows[0]["尺寸公差"].ToString().Trim();
                    if (dt.Rows[0]["下限"].ToString().Trim() != "")
                    {
                        mod.下限 = BaseFunction.ReturnDecimal(dt.Rows[0]["下限"]);
                    }
                    if (dt.Rows[0]["上限"].ToString().Trim() != "")
                    {
                        mod.上限 = BaseFunction.ReturnDecimal(dt.Rows[0]["上限"]);
                    }
                    mod.测量值 = BaseFunction.ReturnDecimal(dt.Rows[0]["测量数值"]);
                    mod.原始值 = BaseFunction.ReturnDecimal(dt.Rows[0]["测量数值"]);
                    mod.备注 = dt.Rows[0]["备注"].ToString().Trim();
                    mod.检验员 = sUserName;
                    mod.班组 = this.s班组;
                    mod.检验时间 = BaseFunction.ReturnDate(dt.Rows[0]["dtmCreate"]);
                    mod.操作员 = sUserName;
                    mod.SourceID = BaseFunction.ReturnLong(dt.Rows[0]["iID"]);
                    DAL.工作台测量 dal = new 业务.DAL.工作台测量();
                    sSQL = dal.Add(mod);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = @"
update [dbo].[检验值] set [已取值] = 1 where iID = {0}
";
                    sSQL = string.Format(sSQL, mod.SourceID);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }

                tran.Commit();
            }
            catch (Exception ee)
            {
                tran.Rollback();
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void LoadExcel()
        {
            string sSQL = @"
select top 1 * ,getdate() as dtmNow
from [dbo].[工作台测量] 
where isnull(删除人,'') = '' and 班组 = '{0}' and 工作台 = '{1}'
order by iID desc
";
            sSQL = string.Format(sSQL, this.s班组, this.s检验工位);
            System.Data.DataTable dtLast = DbHelperSQL.Query(sSQL);
            if (dtLast == null || dtLast.Rows.Count == 0)
                return;

            s测定项目 = dtLast.Rows[0]["测定项目"].ToString().Trim();


            sSQL = @"
select *
from 
(
    select top 24 * ,getdate() as dtmNow
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
            Worksheet worksheet2 = null;
            try
            {
                //// 获取当前工作薄
                workbook = (Microsoft.Office.Interop.Excel.Workbook)Document;

                //// 获取当前工作页
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];

                worksheet.Cells[1, 1] = s测定项目;
                worksheet.Cells[30, 1] = "尺寸公差：" + dt.Rows[0]["尺寸公差"].ToString().Trim();


                decimal d上限 = BaseFunction.ReturnDecimal(dt.Rows[0]["上限"]);
                if (d上限 == 0)
                {
                    d上限 = 9999999999;
                }
                decimal d下限 = BaseFunction.ReturnDecimal(dt.Rows[0]["下限"]);

                worksheet.Cells[29, 1] = s测定项目;
                worksheet.Cells[34, 15] = "图表生成时间：" + BaseFunction.ReturnDate(dt.Rows[0]["dtmNow"]).ToString("yyyy-MM-dd HH:mm:ss");   //图表生成时间

                decimal d测量值 = BaseFunction.ReturnDecimal(dtLast.Rows[0]["测量值"]);
                worksheet.Cells[5, 26] = d测量值;
                if (d测量值 > d上限 || d测量值 < d下限)
                {
                    worksheet.Cells[11, 26] = "NG";

                    int i已报警 = BaseFunction.ReturnInt(dtLast.Rows[0]["已报警"]);
                    if (i已报警 < 1)
                    {
                        Interaction.Beep();

                        sSQL = @"update [工作台测量] set 已报警 = isnull(已报警,0) + 1 where iID = " + BaseFunction.ReturnLong(dtLast.Rows[0]["iID"]);
                        DbHelperSQL.ExecuteSql(sSQL);
                    }
                }
                else
                {
                    worksheet.Cells[11, 26] = "OK";
                }

                DateTime[,] dtmList = new DateTime[2, 24];
                double[] dList = new double[24];
                string[] s班组 = new string[24];

                for (int j = 0; j < 24; j++)
                {
                    if (j < dt.Rows.Count)
                    {
                        dtmList[0, j] = BaseFunction.ReturnDate(dt.Rows[j]["检验时间"]);
                        dtmList[1, j] = BaseFunction.ReturnDate(dt.Rows[j]["检验时间"]);
                        dList[j] = BaseFunction.ReturnDouble(dt.Rows[j]["测量值"]);
                        s班组[j] = dt.Rows[j]["班组"].ToString().Trim();
                    }
                   
                }


                Range range = worksheet.get_Range("B31:Y32", Type.Missing);
                range.Value2 = dtmList;


                Range range2 = worksheet.get_Range("B33:Y33", Type.Missing);
                range2.Value2 = dList;

                Range range3 = worksheet.get_Range("B35:Y35", Type.Missing);
                range3.Value2 = s班组;

                worksheet2 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[2];
                worksheet2.Cells[12, 2] = d上限;
                worksheet2.Cells[13, 2] = d下限;

                sSQL = @"
select 测量值
from 
(
    select top 200 iID,测量值
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
                System.Data.DataTable dtXBar = DbHelperSQL.Query(sSQL);
                double[,] d检验值XBar = new double[200,1];
                for (int i = 0; i < dtXBar.Rows.Count; i++)
                {
                    d检验值XBar[i, 0] = BaseFunction.ReturnDouble(dtXBar.Rows[i]["测量值"]);
                }

                Range rangeXBar = worksheet2.get_Range("B18:B217", Type.Missing);
                rangeXBar.Value2 = d检验值XBar;
            }
            catch (Exception ee)
            {

                throw new Exception(ee.Message);
            }
        }

    }
}
