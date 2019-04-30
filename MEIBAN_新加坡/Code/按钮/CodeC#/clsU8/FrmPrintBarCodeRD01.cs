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



namespace clsU8
{
    public partial class FrmPrintBarCodeRD01 : Form
    {
        RepBaseGrid Rep = new RepBaseGrid();
        string sProPath = Application.StartupPath;
        string sPrintLayOutMod = Application.StartupPath + "\\UAP\\Runtime\\print\\PrintRD01.dll";
        string s服务器;
        string sSA;
        string sPwd;
        string s数据库;
        string s单据号;
        string sConnString;
        string sUserName;

        public FrmPrintBarCodeRD01()
        {
            InitializeComponent();
        }


        public FrmPrintBarCodeRD01(string s1, string s2, string s3, string s4, string s5, string s6)
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

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                //if (sUserName.ToLower() == "demo")
                //{
                //    btn打印模板.Visible = true;
                //}
                //else
                //{
                //    btn打印模板.Visible = false;
                //}

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
                Rep = new RepBaseGrid();
                if (File.Exists(sPrintLayOutMod))
                {
                    Rep.LoadLayout(sPrintLayOutMod);
                }
                else
                {
                    MessageBox.Show("加载报表模板失败，请与管理员联系");
                    return;
                }
                Rep.dsPrint.Tables.Clear();

                SqlConnection conn = new SqlConnection(sConnString);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                string sSQL = @"
select a.cCode,a.dDate,b.cInvCode ,c.cInvName,c.cInvStd,b.cFree1,b.cFree2,b.cFree3,b.cBatch,'01' + b.AutoID as BarCode
from RdRecord01 a inner join RdRecords01 b on a.id = b.id   
    inner join Inventory c on b.cInvCode = c.cInvCode
WHERE 1=1   AND  1=1   And a.cCode = N'aaaaaa'
";
                sSQL = sSQL.Replace("aaaaaa", s单据号);

                DataTable dtHead = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                dtHead.TableName = "dtHead";
                Rep.dsPrint.Tables.Add(dtHead.Copy());

                printControl1.PrintingSystem = Rep.PrintingSystem;
                Rep.CreateDocument();
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

                if (File.Exists(sPrintLayOutMod))
                {
                    Rep.LoadLayout(sPrintLayOutMod);
                }

                Rep.ShowDesignerDialog();

                DialogResult d = MessageBox.Show("是否保存?模板调整将在下次打开窗体时体现\n是：保存打印模板\n", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (DialogResult.Yes == d)
                {
                    Rep.SaveLayoutToXml(sPrintLayOutMod);
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
                Rep.PrintDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
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
