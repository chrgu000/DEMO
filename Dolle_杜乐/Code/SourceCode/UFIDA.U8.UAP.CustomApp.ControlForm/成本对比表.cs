using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TH.BaseClass;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class 成本对比表 : UserControl
    {
        TH.BaseClass.GetBaseData getBaseData = new GetBaseData();
        
        string sProPath = Application.StartupPath;

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }


        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                DbHelperSQL.connectionString = Conn;

                for (int i = 2009; i <= DateTime.Now.Year; i++)
                {
                    comboBox1.Items.Add(i);
                }
                comboBox1.Text = BaseFunction.ReturnDate(sLogDate).ToString("yyyy");
            
//                string sSQL = @"
//select top 1 RIGHT('00'+CAST( iperiod  AS nvarchar(2)),2) as 期间 from GL_mend where isnull(bflag_CA,0) = 0 and iperiod <> 0 order by iperiod
//";
//                DataTable dt = DbHelperSQL.Query(sSQL);
//                if (dt == null || dt.Rows.Count == 0)
//                {
                    comboBox2.Text = BaseFunction.ReturnDate(sLogDate).ToString("MM");
                //}
                //else
                //{
                //    comboBox2.Text = dt.Rows[0]["期间"].ToString().Trim();
                //}

            }
            catch(Exception ee)
            { 
            
            }
        }

        public 成本对比表()
        {
            InitializeComponent();
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

        private void GetGrid()
        {
            try
            {
                string sErr = "";
                int iCount = 0;

                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                if(comboBox1.Text.Trim() == "")
                {
                    comboBox1.Focus();
                    throw new Exception("请选择年度");
                }
                if(comboBox2.Text.Trim() == "")
                {
                    comboBox2.Focus();
                    throw new Exception("请选择期间");
                }

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string s期间 = comboBox1.Text.Trim() + comboBox2.Text.Trim();
                    string sSQL = "select isnull(bflag_CA,0) as bflag from GL_mend where iYPeriod = '" + s期间 + "'";
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
 
                    int i结账 = BaseFunction.ReturnInt(dt.Rows[0]["bflag"]);

                    sSQL = @"select count(1) from _成本计算结果表 where 期间 = 'aaaaaaaa'";
                    sSQL = sSQL.Replace("aaaaaaaa", s期间);
                    long iDataCount = BaseFunction.ReturnLong(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);

                    //未结帐期间重写计算中间表
                    if (i结账 == 0 || iDataCount == 0)
                    {
                        sSQL = @"
delete _成本计算结果表 where 期间 = 'aaaaaaaa'
";
                        sSQL = sSQL.Replace("aaaaaaaa", s期间);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        sSQL = @"
declare @p1 int
set @p1=0
declare @p38 int
set @p38=0
exec sp_prepexecrpc @p1 output,N'CaP_SumFin','ca_rptsumfin','','',aaaaaaaa,aaaaaaaa,'','','','','','CP','CP',-1,-1,'','',0,0,2,0,0,0,0,0,0,0,0,'','','','','',-1,'zh-cn',0,@p38 output
select @p1, @p38

";
                        sSQL = sSQL.Replace("aaaaaaaa", s期间);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        sSQL = @"
insert into _成本计算结果表
select  cast(iYear as varchar(4)) + RIGHT('00'+CAST( iperiod  AS nvarchar(2)),2) as 期间,InvcCode as 产品大类,InvcName as 产品大类名称
	,InvCode as 产品编码,cInvName as 产品名称,cInvStd as 规格型号,cInvAddCode as 产品代码,cInvM_Unit as 计量单位
	,cDeptID as 生产部门编码,cDepName as 生产部门
	,cast(ioutput as decimal(16,2)) as 产量 ,cast(iamoall as decimal(16,2)) as 总成本,cast(iamotype0 as decimal(16,2)) as 材料成本,cast(iamotype3 as decimal(16,2)) as 制造费用
	,cMOCode as 生产订单号,iMOSubSN as 生产订单行号
from ca_rptsumfin 
";
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    sSQL = @"
select 产品编码,产品名称,规格型号,计量单位,cast(0 as int) as 超百分比
	 ,期间
	 ,cast(sum(产量) as decimal(16,2)) as 产量
	 ,cast(sum(总成本) as decimal(16,2)) as 总成本
	 ,cast(sum(材料成本) as decimal(16,2)) as 材料成本
	 ,cast(sum(制造费用) as decimal(16,2)) as 制造费用
	 ,cast(sum(总成本) / sum(产量) as decimal(16,6)) as 单件成本
	 ,cast(sum(材料成本) / sum(产量) as decimal(16,6)) as 单件材料成本
	 ,cast(sum(制造费用) / sum(产量) as decimal(16,6)) as 单件制造费用
	 ,cast(null as VARCHAR(6)) as 期间1
	 ,cast(null as decimal(16,2)) as 产量1
	 ,cast(null as decimal(16,2)) as 总成本1
	 ,cast(null as decimal(16,2)) as 材料成本1
	 ,cast(null as decimal(16,2)) as 制造费用1
	 ,cast(null as decimal(16,6)) as 单件成本1
	 ,cast(null as decimal(16,6))  as 单件材料成本1
	 ,cast(null as decimal(16,6))  as 单件制造费用1
	 ,cast(null as VARCHAR(6)) as 期间2
	 ,cast(null as decimal(16,2)) as 产量2
	 ,cast(null as decimal(16,2)) as 总成本2
	 ,cast(null as decimal(16,2)) as 材料成本2
	 ,cast(null as decimal(16,2)) as 制造费用2
	 ,cast(null as decimal(16,6)) as 单件成本2
	 ,cast(null as decimal(16,6))  as 单件材料成本2
	 ,cast(null as decimal(16,6))  as 单件制造费用2
	 ,cast(null as VARCHAR(6)) as 期间3
	 ,cast(null as decimal(16,2)) as 产量3
	 ,cast(null as decimal(16,2)) as 总成本3
	 ,cast(null as decimal(16,2)) as 材料成本3
	 ,cast(null as decimal(16,2)) as 制造费用3
	 ,cast(null as decimal(16,6)) as 单件成本3
	 ,cast(null as decimal(16,6))  as 单件材料成本3
	 ,cast(null as decimal(16,6))  as 单件制造费用3
from _成本计算结果表 
where  期间 = 'aaaaaaaa'
group by 期间,产品编码,产品名称,规格型号,计量单位
having sum(产量) <> 0
";
                    sSQL = sSQL.Replace("aaaaaaaa", s期间);
                    DataTable dtGrid = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    for (int i = 0; i < dtGrid.Rows.Count; i++)
                    {
                        string sInvCode = dtGrid.Rows[i]["产品编码"].ToString().Trim();
                        decimal d单件成本 = BaseFunction.ReturnDecimal(dtGrid.Rows[i]["单件成本"]);
                        sSQL = @"
select top 3 产品编码,产品名称,规格型号
	 ,期间
	 ,cast(sum(产量) as decimal(16,2)) as 产量
	 ,cast(sum(总成本) as decimal(16,2)) as 总成本
	 ,cast(sum(材料成本) as decimal(16,2)) as 材料成本
	 ,cast(sum(制造费用) as decimal(16,2)) as 制造费用
	 ,cast(sum(总成本) / sum(产量) as decimal(16,6)) as 单件成本
	 ,cast(sum(材料成本) / sum(产量) as decimal(16,6)) as 单件材料成本
	 ,cast(sum(制造费用) / sum(产量) as decimal(16,6)) as 单件制造费用
from _成本计算结果表 
where  期间 < 'aaaaaaaa' and 产品编码 = 'bbbbbbbb'
group by 期间,产品编码,产品名称,规格型号
having sum(产量) <> 0
order by 期间 desc
";
                        sSQL = sSQL.Replace("aaaaaaaa", s期间);
                        sSQL = sSQL.Replace("bbbbbbbb", sInvCode);
                        DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        if (dtTemp.Rows.Count > 0)
                        {
                            decimal d单件成本1 = BaseFunction.ReturnDecimal(dtTemp.Rows[0]["单件成本"]);

                            if (d单件成本 > d单件成本1 * (decimal)1.1)
                            {
                                dtGrid.Rows[i]["超百分比"] = 1;
                            }
                            if (d单件成本 < d单件成本1 * (decimal)0.9)
                            {
                                dtGrid.Rows[i]["超百分比"] = -1;
                            }
                        }

                        for (int j = 0; j < dtTemp.Rows.Count; j++)
                        {
                            dtGrid.Rows[i]["期间" + (j + 1).ToString()] = dtTemp.Rows[j]["期间"];
                            dtGrid.Rows[i]["产量" + (j + 1).ToString()] = dtTemp.Rows[j]["产量"];
                            dtGrid.Rows[i]["总成本" + (j + 1).ToString()] = dtTemp.Rows[j]["总成本"];
                            dtGrid.Rows[i]["材料成本" + (j + 1).ToString()] = dtTemp.Rows[j]["材料成本"];
                            dtGrid.Rows[i]["制造费用" + (j + 1).ToString()] = dtTemp.Rows[j]["制造费用"];
                            dtGrid.Rows[i]["单件成本" + (j + 1).ToString()] = dtTemp.Rows[j]["单件成本"];
                            dtGrid.Rows[i]["单件材料成本" + (j + 1).ToString()] = dtTemp.Rows[j]["单件材料成本"];
                            dtGrid.Rows[i]["单件制造费用" + (j + 1).ToString()] = dtTemp.Rows[j]["单件制造费用"];
                        }
                    }

                    gridControl1.DataSource = dtGrid;
                    gridView1.BestFitColumns();
                    gridCol产品名称.Width = 100;
                    gridCol规格型号.Width = 80;

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
                gridControl1.DataSource = null;
                MessageBox.Show(ee.Message);
            }
        }



        private void btnSEL_Click(object sender, EventArgs e)
        {
            
            try
            {
                GetGrid();
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xlsx";
                sF.FileName = "成本对比表";
                sF.Filter = "xlsx文件(*.xlsx)|*.xlsx|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK != dRes)
                {
                    return;
                }

                gridView1.ExportToXlsx(sF.FileName);
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "导出Excel失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                int itype = BaseFunction.ReturnInt(gridView1.GetRowCellValue(e.RowHandle, gridCol超百分比));
                if (itype == 1)
                {
                    e.Appearance.BackColor = Color.Tomato;
                }
                if (itype == -1)
                {
                    e.Appearance.BackColor = Color.Yellow;
                }
            }
            catch { }
        }

    }
}
