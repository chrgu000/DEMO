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
    public partial class ExportData : UserControl
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

        private void SetLookUp()
        {
            string sSQL = "select distinct rtrim(ltrim(iYPeriod)) as iYPeriod from GL_accsum order by iYPeriod";
            DataTable dt = DbHelperSQL.Query(sSQL);
            lookUpEditiYPeriod.Properties.DataSource = dt;
            if (dt != null && dt.Rows.Count > 0)
            {
                lookUpEditiYPeriod.EditValue = DateTime.Today.ToString("yyyyMM");
            }
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                DbHelperSQL.connectionString = Conn;
                SetLookUp();
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        public ExportData()
        {
            InitializeComponent();
        }

        private void btnExcel_Click(object sender, EventArgs e)
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
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "导出Excel失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
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

        private void btn查询_Click(object sender, EventArgs e)
        {
            try
            {
                string sSQL = @"
select OperatingUnit,Account,isnull(CostCenter,'0000000') as CostCenter
    ,case when Account = '81007' then '722' else '000' end as Intercompany
    ,cast(abs(sum(md-mc)) as decimal(16,2)) as Amount
    ,PERIOD
	,case when sum(isnull(a.md,0)- isnull(a.mc,0)) > 0 then 'D'
	when sum(isnull(a.md,0)- isnull(a.mc,0)) < 0 then 'C'
	 END AS DR_CR
from
(
select  '752' as OperatingUnit
	,a.ccode as Account
	,case when isnull(a.cdept_id,'') <> '' then '752' + a.cdept_id
		when  isnull(a.cdept_id,'') = '' then '752' + c.[CostCenter]
		when isnull(c.costCenter,'') <> '' then '752' + c.[CostCenter]
	end as CostCenter
	,sum(isnull(a.md,0)) as md , sum(isnull(a.mc,0)) as mc
	,RIGHT('00'+CAST(a.iperiod AS NVARCHAR(2)),2) + cast(right(a.iyear,2) as varchar(2)) as PERIOD 
from GL_accvouch a 
	inner join code b on a.ccode = b.ccode and b.iyear = 'bbbbbb'
	left join [dbo].[_codeCostCenter] c on a.ccode = c.ccode
where iYPeriod = 'aaaaaa' and isnull(b.bend ,0) = 1
group by  a.ccode,a.cdept_id,b.bproperty,a.iperiod,a.iyear,c.[CostCenter]
having abs(sum(isnull(a.md,0) - isnull(a.mc,0))) <> 0
) a 
group by OperatingUnit,Account,CostCenter,PERIOD
order by  OperatingUnit,Account,CostCenter,PERIOD
";
                sSQL = sSQL.Replace("aaaaaa", lookUpEditiYPeriod.EditValue.ToString().Trim());
                sSQL = sSQL.Replace("bbbbbb", lookUpEditiYPeriod.EditValue.ToString().Trim().Substring(0,4));
                DataTable dt = DbHelperSQL.Query(sSQL);
                gridControl1.DataSource = dt;
                gridView1.BestFitColumns();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btn导出csv_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
                sF.Filter = "CSV文件(*.CSV)|*.csv|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridView1.ExportToCsv(sF.FileName);
                    MessageBox.Show("导出成功\n\t路径：" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "导出Excel失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void btn导出Txt_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder s = new StringBuilder();

                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
                sF.Filter = "TXT文件(*.txt)|*.txt|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        string sCol = gridView1.GetRowCellDisplayText(i, gridColOperatingUnit).ToString().Trim();
                        s.Append(sCol);
                        s.Append(",");

                        sCol = gridView1.GetRowCellDisplayText(i, gridColAccount).ToString().Trim();
                        s.Append(sCol);
                        s.Append(",");

                        sCol = gridView1.GetRowCellDisplayText(i, gridColCostCenter).ToString().Trim();
                        s.Append(sCol);
                        s.Append(",");

                        sCol = gridView1.GetRowCellDisplayText(i, gridColIntercompany).ToString().Trim();
                        s.Append(sCol);
                        s.Append(",");

                        sCol = gridView1.GetRowCellDisplayText(i, gridColAmount).ToString().Trim();
                        sCol = sCol.Replace(".", "");
                        s.Append(sCol);
                        s.Append(",");

                        sCol = gridView1.GetRowCellDisplayText(i, gridColPERIOD).ToString().Trim();
                        s.Append(sCol);
                        s.Append(",");

                        sCol = gridView1.GetRowCellDisplayText(i, gridColDR_CR).ToString().Trim();
                        s.Append(sCol);

                        s.Append("\r\n");
                    }

                    File.WriteAllText(sF.FileName, s.ToString(), Encoding.ASCII);
                    MessageBox.Show("导出成功\n\t路径：" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "导出失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

    }
}
