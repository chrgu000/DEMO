using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TH.BaseClass;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class FrmSEL_ImportPurBillVouch : Form
    {
        public FrmSEL_ImportPurBillVouch()
        {
            InitializeComponent();
        }

        public DateTime dtmReturn;
        public string sInvoiceNO;
        public string sContainerNO;

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string sSQL = @"
SELECT distinct cast(0 as bit) as bSelected, InvoiceNo,CONVERT(varchar(100), [Date], 23) as dDate
FROM RDRECORDS01_IMPORT
where 1=1
";
               
                if (txtInvoiceNo.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and InvoiceNo like '%" + txtInvoiceNo.Text.Trim() + "%'");
                }
                if (dateEdit1.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and [Date] >= '" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "'");
                }
                if (dateEdit2.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and [Date] < '" + dateEdit2.DateTime.AddDays(1).ToString("yyyy-MM-dd") + "'");
                }
                if (radioUnCreated.Checked)
                {
                    sSQL = sSQL.Replace("1=1", @"1=1 and AutoID not in (
		    SELECT  a.AutoID
		    FROM      RdRecords01_Import a left join
		    (
select a.cPBVCode,b.ID 
from PurBillVouch a inner join PurBillVouchs b on a.PBVID = b.PBVID 
		    ) c on a.PurBillIDs = c.ID 
		    where  isnull(c.cPBVCode,'') <> ''
        )");
                }

                if (radioCreated.Checked)
                {
                    sSQL = sSQL.Replace("1=1", @"1=1 and AutoID not in (
		    SELECT  a.AutoID
		    FROM      RdRecords01_Import a left join
		    (
select a.cPBVCode,b.ID 
from PurBillVouch a inner join PurBillVouchs b on a.PBVID = b.PBVID 
		    ) c on a.PurBillIDs = c.ID 
		    where  isnull(c.cPBVCode,'') = ''
        )"); 
                }

                DataTable dt = DbHelperSQL.Query(sSQL);
                gridControl1.DataSource = dt;
                gridView1.BestFitColumns();
            }
            catch (Exception ee)
            {
                FrmMsgBox frm = new FrmMsgBox();
                frm.richTextBox1.Text = ee.Message;
                frm.ShowDialog();
            }
        }

        private void FrmSEL_Load(object sender, EventArgs e)
        {
              try
              {
                  txtInvoiceNo.Text = "";

                  dateEdit1.DateTime = DateTime.Today.AddDays(-7);
                  dateEdit2.DateTime = DateTime.Today;
              }
              catch (Exception ee)
              {
                  FrmMsgBox frm = new FrmMsgBox();
                  frm.richTextBox1.Text = ee.Message;
                  frm.ShowDialog();
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                { 
                    if(BaseFunction.ReturnBool(gridView1.GetRowCellValue(i,gridColbSelected)))
                    {
                        dtmReturn = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridColdDate));
                        sInvoiceNO = gridView1.GetRowCellValue(i, gridColInvoiceNo).ToString().Trim();
                        sContainerNO = txtContainerNO.Text.Trim();

                        break;
                    }
                }

                if (dtmReturn != null && dtmReturn > Convert.ToDateTime("2000-01-01"))
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch(Exception ee)
            {
                FrmMsgBox frm = new FrmMsgBox();
                frm.richTextBox1.Text = ee.Message;
                frm.ShowDialog();
            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                int iRow = gridView1.FocusedRowHandle;

                bool b = BaseFunction.ReturnBool(gridView1.GetRowCellValue(iRow, gridColbSelected));
                gridView1.SetRowCellValue(iRow, gridColbSelected, !b);
                if (!b)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (i == iRow)
                        {
                            continue;
                        }

                        gridView1.SetRowCellValue(i, gridColbSelected, false);
                    }
                }
            }
            catch { }
        }

    }
}
