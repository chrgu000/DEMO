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
    public partial class RepCreateDisInfo : UserControl
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

                SetLookup();

                btnQuery_Click(null, null);
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void SetLookup()
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "Status";
            dt.Columns.Add(dc);

            DataRow dr = dt.NewRow();
            dr["Status"] = "Success";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Status"] = "Error";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Status"] = "All";
            dt.Rows.Add(dr);
            lookUpEditStatus.Properties.DataSource = dt;
            lookUpEditStatus.EditValue = "Error";
        }

        public RepCreateDisInfo()
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

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string sSQL = @"
select * 
from  [dbo].[_CreateDisInfo]
where 1=1 
order by iID
";
            if (lookUpEditStatus.EditValue.ToString().Trim().ToLower() != "all")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and [Status] = '" + lookUpEditStatus.EditValue.ToString().Trim() + "'");
            }
            if (radioOneDay.Checked)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and CreateDate >= CONVERT(VARCHAR(10),DATEADD(day,-1,getdate()),120) ");
            }
            if (radioOneWeek.Checked)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and CreateDate >= CONVERT(VARCHAR(10),DATEADD(week,-1,getdate()),120) ");
            }
            if (radioOneMonth.Checked)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and CreateDate >= CONVERT(VARCHAR(10),DATEADD(month,-1,getdate()),120) ");
            }
            DataTable dt = DbHelperSQL.Query(sSQL);
            gridControl1.DataSource = dt;

            gridView1.BestFitColumns();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == gridColStatus)
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridColcSOCode, true);
                }
            }
            catch { }
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
                    gridView1.ExportToXls(sF.FileName);
                    MessageBox.Show("OK\n\tPath：" + sF.FileName);
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

        private void ItemButtonEditShowDetails_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int iRow = gridView1.FocusedRowHandle;
                if (iRow >= 0)
                {
                    FrmMsgBox frm = new FrmMsgBox();
                    frm.richTextBox1.Text = gridView1.GetRowCellDisplayText(iRow, gridColRemark).ToString().Trim();
                    frm.ShowDialog();
                }
            }
            catch { }
        }

    }
}
