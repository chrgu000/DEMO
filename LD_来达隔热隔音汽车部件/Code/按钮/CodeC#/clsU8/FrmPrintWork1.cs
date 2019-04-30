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
    public partial class FrmPrintWork1 : Form
    {
        RepBaseGrid Rep = new RepBaseGrid();
        string sProPath = Application.StartupPath;
        string sPrintLayOutMod = Application.StartupPath + "\\UAP\\Runtime\\print\\PrintWork1.dll";
        string s服务器;
        string sSA;
        string sPwd;
        string s数据库;
        string s单据号;
        string sConnString;
        string sUserName;

        public FrmPrintWork1()
        {
            InitializeComponent();
        }


        public FrmPrintWork1(string s1, string s2, string s3, string s4, string s5, string s6)
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
select distinct CAST(1 as int) as 打印份数,MoId,MoDId,订单号,行号,订单日期  ,产品编码,产品名称,规格型号
    ,每包数量,订单数量,包装规格,开工日期,完工日期
from _viewmom 
where 订单号 = 'aaaaaaaa'
order by MoId,MoDId
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
                GetPrint(2);
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

                GetPrint(1);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void GetPrint(int type)
        {

            SqlConnection conn = new SqlConnection(sConnString);
            conn.Open();
            SqlTransaction tran = conn.BeginTransaction();
            string sSQL = "";
            try
            {
                DataTable dt = (DataTable)gridControl1.DataSource;
                DataTable dtPrint = dt.Copy();

                string sErr = "";
                bool b = true;
                if (type != 2)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int iCouPrint = BaseFunction.ReturnInt(dt.Rows[i]["打印份数"]);
                        if (iCouPrint > 0)
                        {
                            sSQL = @"
            select 订单号
            from _viewmom
            where 订单号 = 'aaaaaaaa' and MOID = bbbbbbbb and MoDid = cccccccc and (工序 is null)
            ";
                            sSQL = sSQL.Replace("aaaaaaaa", dt.Rows[i]["订单号"].ToString().Trim());
                            sSQL = sSQL.Replace("bbbbbbbb", dt.Rows[i]["MoId"].ToString().Trim());
                            sSQL = sSQL.Replace("cccccccc", dt.Rows[i]["MoDid"].ToString().Trim());
                            DataTable dtGrid = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dtGrid.Rows.Count > 0)
                            {
                                sErr = sErr + "行号：" + dt.Rows[i]["行号"].ToString().Trim() + "工序为空\n";
                            }
                        }
                    }
                    if (sErr != "")
                    {
                        DialogResult d = MessageBox.Show("子件或工序为空是否继续打印" + sErr, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                        if (DialogResult.Yes != d)
                        {
                            b = false;
                        }
                    }
                }
                if (b == true)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int iCouPrint = BaseFunction.ReturnInt(dt.Rows[i]["打印份数"]);
                        if (iCouPrint > 0)
                        {
                            sSQL = @"
            select distinct CAST(1 as int) as 打印份数,MoId,MoDId
            	,订单号 ,行号, cast(订单号 as varchar(10)) + ' - ' + cast(行号 as varchar(6)) as 订单号行号
                ,订单日期 ,创建时间,制单人
                ,产品编码,产品名称,规格型号
                ,每包数量,订单数量,包装规格
            	,开工日期,完工日期
            from _viewmom 
            where 订单号 = 'aaaaaaaa' and MOID = bbbbbbbb and MoDid = cccccccc
            ";
                            sSQL = sSQL.Replace("aaaaaaaa", dt.Rows[i]["订单号"].ToString().Trim());
                            sSQL = sSQL.Replace("bbbbbbbb", dt.Rows[i]["MoId"].ToString().Trim());
                            sSQL = sSQL.Replace("cccccccc", dt.Rows[i]["MoDid"].ToString().Trim());
                            DataTable dtHead = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];


                            sSQL = @"
            select distinct CAST(1 as int) as 打印份数,MoId,MoDId
            	,订单号 ,行号, cast(订单号 as varchar(10)) + ' - ' + cast(行号 as varchar(6)) as 订单号行号
                ,订单日期 ,创建时间,制单人
                ,产品编码,产品名称,规格型号
                ,每包数量,订单数量,包装规格
            	,开工日期,完工日期
            	,工序行号,工序,cast(工序 as varchar(10)) + ' - ' + cast(工序行号 as varchar(6)) as 工序号工序行号
				,cast(订单号 as varchar(10)) + '-' + cast(行号 as varchar(6)) + '-' + cast(工序行号 as varchar(6)) as AllocateId
            from _viewmom
            where 订单号 = 'aaaaaaaa' and MOID = bbbbbbbb and MoDid = cccccccc
            ";
                            sSQL = sSQL.Replace("aaaaaaaa", dt.Rows[i]["订单号"].ToString().Trim());
                            sSQL = sSQL.Replace("bbbbbbbb", dt.Rows[i]["MoId"].ToString().Trim());
                            sSQL = sSQL.Replace("cccccccc", dt.Rows[i]["MoDid"].ToString().Trim());
                            DataTable dtGrid = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                            sSQL = @"
            select distinct CAST(1 as int) as 打印份数,MoId,MoDId
            	,订单号 ,行号, cast(订单号 as varchar(10)) + ' - ' + cast(行号 as varchar(6)) as 订单号行号
                ,订单日期 ,创建时间,制单人
                ,产品编码,产品名称,规格型号
                ,每包数量,订单数量,包装规格
            	,开工日期,完工日期
                ,子件编码,子件名称,子件规格
            	,工序行号,工序,cast(工序 as varchar(10)) + ' - ' + cast(工序行号 as varchar(6)) as 工序号工序行号
				,cast(订单号 as varchar(10)) + '-' + cast(行号 as varchar(6)) + '-' + cast(工序行号 as varchar(6)) as AllocateId
            from _viewmom
            where 订单号 = 'aaaaaaaa' and MOID = bbbbbbbb and MoDid = cccccccc
            ";
                            sSQL = sSQL.Replace("aaaaaaaa", dt.Rows[i]["订单号"].ToString().Trim());
                            sSQL = sSQL.Replace("bbbbbbbb", dt.Rows[i]["MoId"].ToString().Trim());
                            sSQL = sSQL.Replace("cccccccc", dt.Rows[i]["MoDid"].ToString().Trim());
                            DataTable dtChild = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                            RepBaseGrid Rep = new RepBaseGrid();


                            Rep.dsPrint.Tables.Clear();

                            dtHead.TableName = "dtHead";
                            Rep.dsPrint.Tables.Add(dtHead.Copy());

                            dtGrid.TableName = "dtGrid";
                            Rep.dsPrint.Tables.Add(dtGrid.Copy());

                            dtChild.TableName = "dtChild";
                            Rep.dsPrint.Tables.Add(dtChild.Copy());



                            //DataColumn parentColumn1 = Rep.dsPrint.Tables["dtHead"].Columns["订单号行号"];
                            //DataColumn childColumn1 = Rep.dsPrint.Tables["dtGrid"].Columns["订单号行号"];
                            //DataRelation R1 = new DataRelation("R1", parentColumn1, childColumn1);

                            DataColumn parentColumn2 = Rep.dsPrint.Tables["dtGrid"].Columns["AllocateId"];
                            DataColumn childColumn2 = Rep.dsPrint.Tables["dtChild"].Columns["AllocateId"];
                            DataRelation R2 = new DataRelation("R2", parentColumn2, childColumn2);
                            //Rep.dsPrint.Relations.Add(R1);
                            Rep.dsPrint.Relations.Add(R2);
                            if (type == 1)//打印
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

                                Rep.PrinterName = lookUpEditPrinter.Text.Trim();
                                Rep.Landscape = false;

                                for (int j = 1; j <= iCouPrint; j++)
                                {
                                    Rep.Print();
                                }

                            }
                            else if (type == 2)//模板
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
                                    Rep.SaveLayout(sPrintLayOutMod);
                                }

                                break;
                            }
                        }
                    }
                }

                tran.Commit();

            }
            catch (Exception ee)
            {
                tran.Rollback();
                throw new Exception(ee.Message);
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
