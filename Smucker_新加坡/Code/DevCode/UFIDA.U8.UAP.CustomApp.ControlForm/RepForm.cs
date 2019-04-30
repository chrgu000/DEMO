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
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class RepForm : UserControl
    {
        TH.BaseClass.GetBaseData getBaseData = new GetBaseData();
        
        string sProPath = Application.StartupPath;

        UFIDA.U8.UAP.CustomApp.ControlForm.RepBaseGrid Rep = new RepBaseGrid();

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

                txtCIO.Properties.ReadOnly = false;
                txtDuty.Properties.ReadOnly = false;
                txtStdCost.Properties.ReadOnly = false;
                txtExchangeRate.Properties.ReadOnly = false;

                txtCIO.Enabled = true;
                txtDuty.Enabled = true;
                txtStdCost.Enabled = true;
                txtExchangeRate.Enabled = true;

                dateEdit1.DateTime = BaseFunction.ReturnDate(DateTime.Today.ToString("yyyy-MM-01"));
                dateEdit2.DateTime = DateTime.Today;

                txtCIO.Focus();

            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        public RepForm()
        {
            InitializeComponent();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
                sF.Filter = "Excel(*.xls)|*.xls|All files(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    //创建工作薄
                    HSSFWorkbook wk = new HSSFWorkbook();
                    ICellStyle style0 = wk.CreateCellStyle();

                    //设置单元格风格
                    style0.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                    style0.WrapText = true;
                    IFont font = wk.CreateFont();
                    font.FontHeightInPoints = 16;
                    font.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;
                    font.FontName = "標楷體";
                    style0.SetFont(font);//HEAD 样式

                    ICellStyle style00 = wk.CreateCellStyle();
                    style00.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                    style00.WrapText = true;

                    ICellStyle style1 = wk.CreateCellStyle();
                    style1.Alignment = NPOI.SS.UserModel.HorizontalAlignment.GENERAL;
                    style1.WrapText = true;


                    //创建一个名称为mySheet的表
                    ISheet tb = wk.CreateSheet("mySheet");

                    CellRangeAddress cellRangeAddress1 = new CellRangeAddress(0, 0, 0, 13);
                    tb.AddMergedRegion(cellRangeAddress1);

                   

                    IRow row0 = tb.CreateRow(0);
                    ICell cell0 = row0.CreateCell(0);
                    cell0.SetCellValue("The JM Smucker Company");
                    row0.GetCell(0).CellStyle = style0;
                    row0.Height = 600;


                    CellRangeAddress cellRangeAddress2 = new CellRangeAddress(1, 1, 0, 13);
                    tb.AddMergedRegion(cellRangeAddress2);

                    row0 = tb.CreateRow(1);
                    cell0 = row0.CreateCell(0);
                    cell0.SetCellValue("China WFOE Volumes, GS, COST");
                    row0.GetCell(0).CellStyle = style00;

                    CellRangeAddress cellRangeAddress3 = new CellRangeAddress(2, 2, 0, 13);
                    tb.AddMergedRegion(cellRangeAddress3);

                    row0 = tb.CreateRow(2);
                    cell0 = row0.CreateCell(0);
                    cell0.SetCellValue("Date:" + dateEdit1.DateTime.ToString("yyyy/MM/dd") + " - " + dateEdit2.DateTime.ToString("yyyy/MM/dd"));
                    row0.GetCell(0).CellStyle = style00;

                    IRow row = tb.CreateRow(4);
                    ICell cell = row.CreateCell(0);
                    cell.SetCellValue("CIQ");
                    row.GetCell(0).CellStyle = style1;

                    cell = row.CreateCell(1);
                    cell.SetCellValue(BaseFunction.ReturnDouble(txtCIO.Text.Trim()));
                    cell.CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");

                    row = tb.CreateRow(5);
                    cell = row.CreateCell(0);
                    cell.SetCellValue("Duty");
                    cell = row.CreateCell(1);
                    cell.SetCellValue(BaseFunction.ReturnDouble(txtDuty.Text.Trim()));

                    row = tb.CreateRow(6);
                    cell = row.CreateCell(0);
                    cell.SetCellValue("% of std cost ");
                    cell = row.CreateCell(1);
                    cell.SetCellValue(BaseFunction.ReturnDouble(txtStdCost.Text.Trim()));

                    row = tb.CreateRow(7);
                    cell = row.CreateCell(0);
                    cell.SetCellValue("Exchange Rate");
                    cell = row.CreateCell(1);
                    cell.SetCellValue(BaseFunction.ReturnDouble(txtExchangeRate.Text.Trim()));


                    row = tb.CreateRow(9);
                    for (int i = 0; i < gridView1.Columns.Count; i++)
                    {
                        cell = row.CreateCell(i);
                        cell.SetCellValue(gridView1.Columns[i].Caption);
                    }

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        row = tb.CreateRow(10 + i);
                        for (int j = 0; j < gridView1.Columns.Count; j++)
                        {
                            cell = row.CreateCell(j);

                            if (gridView1.GetRowCellDisplayText(i, gridView1.Columns[j]).ToString().Trim() != "")
                            {
                                if (j < 3)
                                {
                                    cell.SetCellValue(gridView1.GetRowCellDisplayText(i, gridView1.Columns[j]).ToString().Trim());
                                }
                                else
                                {
                                    cell.SetCellValue(BaseFunction.ReturnDouble(gridView1.GetRowCellDisplayText(i, gridView1.Columns[j])));
                                }
                            }


                            tb.AutoSizeColumn(i);
                        }
                    }

                    row = tb.CreateRow(10 + gridView1.RowCount);
                    for (int j = 3; j < gridView1.Columns.Count; j++)
                    {
                        cell = row.CreateCell(j);
                        cell.SetCellValue(BaseFunction.ReturnDouble(gridView1.Columns[j].SummaryItem.SummaryValue));
                    }


                    using (FileStream fs = File.OpenWrite(sF.FileName))     //打开一个xls文件，如果没有则自行创建，如果存在myxls.xls文件则在创建是不要打开该文件！
                    {
                        wk.Write(fs);                                       //向打开的这个xls文件中写入mySheet表并保存。
                        MessageBox.Show("Export success\nPath:" + sF.FileName);
                    }


                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "Export err";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void txt_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                decimal d1 = BaseFunction.ReturnDecimal(txtCIO.Text.Trim());
                decimal d2 = BaseFunction.ReturnDecimal(txtDuty.Text.Trim());

                txtTotal.Text = (d1 + d2).ToString();
            }
            catch { }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                decimal dCIO = BaseFunction.ReturnDecimal(txtCIO.Text.Trim());
                //if (dCIO == 0)
                //{
                //    txtCIO.Focus();
                //    throw new Exception("Please set cio");
                //}

                decimal dDuty = BaseFunction.ReturnDecimal(txtDuty.Text.Trim());
                //if (dDuty == 0)
                //{
                //    txtDuty.Focus();
                //    throw new Exception("Please set duty");
                //}

                decimal dStdCost = BaseFunction.ReturnDecimal(txtStdCost.Text.Trim());
                //if (dStdCost == 0)
                //{
                //    txtStdCost.Focus();
                //    throw new Exception("Please set std cost");
                //}

                decimal dExchangeRate = BaseFunction.ReturnDecimal(txtExchangeRate.Text.Trim());
                if (dExchangeRate == 0)
                {
                    txtExchangeRate.Focus();
                    throw new Exception("Please set exchange rate");
                }

                string sSQL = @"
declare @dExchangeRate decimal(16,6)
declare @dStdCost decimal(16,6)

set @dExchangeRate = aaaaaa
set @dStdCost = bbbbbb

select billVouch.cInvCode as UPC
	,inv.cInvName as [Description]
	,inv.cEnglishName as Description2
	,cast((billVouch.iQuantity) as decimal(16,2)) as Qty
	,cast((billVouch.iInvExchRate) as decimal(16,2)) as  CSEConv0
	,cast(case when isnull(billVouch.iInvExchRate,0) <> 0 then (isnull(billVouch.iQuantity,0) / isnull(billVouch.iInvExchRate,0)) end as decimal(16,2))  as Cases
	,null as EUConv
	,null as EUs
	,(billVouch.iMoney) as GSWOTaxRMB 
	,cast((billVouch.iMoney) * @dExchangeRate as decimal(16,2)) as GSWOTaxUSD
	,cast((rd.iprice) as decimal(16,2)) as StandardCost
	,cast((rd.iprice) * @dStdCost as decimal(16,2)) as AllocateDutyCIQ
	,cast((rd.iprice) * @dStdCost as decimal(16,2)) + cast((rd.iprice) as decimal(16,2)) as TotStdCostRMB
	,cast(@dExchangeRate * (cast((rd.iprice) * @dStdCost as decimal(16,2)) + cast((rd.iprice) as decimal(16,2))) as decimal(16,2)) as TotStdCostUSD
from
	( 
		select b.cInvCode,sum(b.iQuantity) as iQuantity,sum(iMoney) as iMoney,min(b.iInvExchRate) as iInvExchRate
		from SaleBillVouch a inner join SaleBillVouchs b on a.SBVID = b.SBVID  
		where a.dDate >= 'cccccc' and a.dDate < 'dddddd'
		group by b.cInvCode
	) billVouch 
	inner join Inventory inv on billVouch.cInvCode = inv.cinvCode
	left join
	(
		select sum(iprice) as iprice,sum(iquantity) as iQty,b.cInvCode
		from rdrecord32 a inner join rdrecords32 b on a.ID = b.ID
		where a.dDate >= 'cccccc' and a.dDate < 'dddddd'
		group by b.cInvCode
	) rd on billVouch.cInvCode = rd.cInvCode
order by inv.cInvCode
";
                sSQL = sSQL.Replace("cccccc", dateEdit1.DateTime.ToString("yyyy-MM-dd"));
                sSQL = sSQL.Replace("dddddd", dateEdit2.DateTime.AddDays(1).ToString("yyyy-MM-dd"));
                sSQL = sSQL.Replace("aaaaaa", dExchangeRate.ToString());
                sSQL = sSQL.Replace("bbbbbb", (dStdCost / 100).ToString());
                
                DataTable dt = DbHelperSQL.Query(sSQL);
                gridControl1.DataSource = dt;
                gridView1.BestFitColumns();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
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
    }
}
