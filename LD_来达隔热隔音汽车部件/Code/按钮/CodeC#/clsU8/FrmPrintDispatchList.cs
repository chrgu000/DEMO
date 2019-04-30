using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.IO;
using DevExpress.XtraReports.UI;



namespace clsU8
{
    public partial class FrmPrintDispatchList : Form
    {
        RepBaseGrid Rep = new RepBaseGrid();
        string sProPath = Application.StartupPath;
        string sPrintLayOutMod = Application.StartupPath + "\\UAP\\Runtime\\print\\PrintDispatchList.dll";
        string sPrintLayOutMod2 = Application.StartupPath + "\\UAP\\Runtime\\print\\PrintDispatchList2.dll";
        string s服务器;
        string sSA;
        string sPwd;
        string s数据库;
        string s单据号;
        string sConnString;
        string sUserName;

        public FrmPrintDispatchList()
        {
            InitializeComponent();
        }


        public FrmPrintDispatchList(string s1, string s2, string s3, string s4, string s5, string s6)
        {
            InitializeComponent();

            s服务器 = s1;
            sSA = s2;
            sPwd = s3;
            s数据库 = s4;
            s单据号 = s5;
            sUserName = s6;

            sConnString = "server = " + s服务器 + ";uid=" + sSA + ";pwd=" + sPwd + ";database=" + s数据库 + ";timeout = 200";
        }

        DataTable dtPrint;
        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                List<String> list = LocalPrinter.GetLocalPrinters(); //获得系统中的打印机列表
                DataTable dt = new DataTable();
                DataColumn dc = new DataColumn();
                dc.ColumnName = "Printer";
                dt.Columns.Add(dc);

                foreach (String s in list)
                {
                    DataRow dr = dt.NewRow();
                    dr["Printer"] = s;
                    dt.Rows.Add(dr);
                }
                lookUpEditPrinter.Properties.DataSource = dt;
                lookUpEditPrinter.EditValue = LocalPrinter.DefaultPrinter();


                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void GetGrid()
        {
            try
            {
                SqlConnection conn = new SqlConnection(sConnString);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                string sSQL = @"
select * ,CAST(2 as int) as 打印份数
from _GetDispatchList 
where 发货单号 = 'aaaaaaaa'
order by autoid
";
                sSQL = sSQL.Replace("aaaaaaaa", s单据号);
                DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                gridControl1.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btn打印模板_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(sProPath + "\\print"))
                    Directory.CreateDirectory(sProPath + "\\print");

                string sFileTemp = "";
                if (radio打印模板1.Checked)
                {
                    sFileTemp = sPrintLayOutMod;
                  
                }

                if (radio打印模板2.Checked)
                {
                    sFileTemp = sPrintLayOutMod2;

                }

                if (File.Exists(sFileTemp))
                {
                    Rep.LoadLayout(sFileTemp);
                }

                Rep.ShowDesignerDialog();

                DialogResult d = MessageBox.Show("是否保存?模板调整将在下次打开窗体时体现\n是：保存打印模板\n", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (DialogResult.Yes == d)
                {
                    Rep.SaveLayoutToXml(sFileTemp);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("设置打印模板失败：" + ee.Message);
            }
        }


        private void btn打印_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                SqlConnection conn = new SqlConnection(sConnString);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                string sSQL = "select LX from _PrintLX";
                DataTable dtLX = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                long iLX = BaseFunction.ReturnLong(dtLX.Rows[0][0]);

                try
                {
                    DataTable dt = (DataTable)gridControl1.DataSource;
                    DataTable dtPrint = dt.Copy();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int iCouPrint = BaseFunction.ReturnInt(dt.Rows[i]["打印份数"]);
                        int iCou = BaseFunction.ReturnInt(dt.Rows[i]["箱数"]);

                        dt.Rows[i]["表体8"] = dt.Rows[i]["表体8"].ToString().Trim();
                        dt.Rows[i]["表体9"] = dt.Rows[i]["表体9"].ToString().Trim();

                        for (int j = 0; j < iCou; j++)
                        {
                            Rep = new RepBaseGrid();

                            if (radio打印模板1.Checked)
                            {
                                if (File.Exists(sPrintLayOutMod))
                                {
                                    Rep.LoadLayout(sPrintLayOutMod);
                                }
                                else
                                {
                                    MessageBox.Show("加载报表模板失败，请与管理员联系");
                                    return;
                                }
                            }
                            if(radio打印模板2.Checked)
                            {
                                if (File.Exists(sPrintLayOutMod2))
                                {
                                    Rep.LoadLayout(sPrintLayOutMod2);
                                }
                                else
                                {
                                    MessageBox.Show("加载报表模板失败，请与管理员联系");
                                    return;
                                }
                            }

                            Rep.dsPrint.Tables.Clear();

                            dtPrint.Clear();
                            DataRow dr = dtPrint.NewRow();
                            dr.ItemArray = (object[])dt.Rows[i].ItemArray.Clone();

                            iLX += 1;

                            dr["箱号流水"] = ReturnLX(iLX).ToString();
                            dr["箱号流水2"] = "PS" + dr["箱号流水"].ToString().Trim();
                            dtPrint.Rows.Add(dr);

                            DataTable dtHead = dtPrint.Copy();
                            dtHead.TableName = "dtHead";
                            Rep.dsPrint.Tables.Add(dtHead.Copy());

                            Rep.PrinterName = lookUpEditPrinter.Text.Trim();
                            //Rep.CreateDocument();

                            for (int k = 0; k < iCouPrint; k++)
                            {
                                Rep.Print();
                            }
                        }
                    }

                    sSQL = "update _PrintLX set LX = " + iLX.ToString();
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    tran.Commit();
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

        private string ReturnLX(long iLX)
        {
            string sLX = iLX.ToString();
            while (sLX.Length < 10)
            {
                sLX = "0" + sLX;
            }
            return sLX;
        }

        private void btn刷新_Click(object sender, EventArgs e)
        {
            try
            {
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
