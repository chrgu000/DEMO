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
    public partial class CreditLine : UserControl
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
                GetGrid();
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        public CreditLine()
        {
            InitializeComponent();
        }

        private void btnExport_Click(object sender, EventArgs e)
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
                sF.FileName = "客户信用额度";
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

        private void btnSEL_Click(object sender, EventArgs e)
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


        private void GetGrid()
        {
            chkAll.Checked = false;

            string sSQL = @"
SELECT a.cCusCode AS CustomerCode,a.cCusName AS CustomerName,cast(a.iCusCreLine as decimal(16,2)) AS CreditLimit
	,a.cCusCMProtocol ,b.PaymentTermCode AS PaymentTerm,a.cCusExch_name AS Currency
	,cast(c.iMoney as decimal(16,2)) AS TotalOutstandingAmount,cast(a.iCusCreLine - ISNULL(c.iMoney,0) as decimal(16,2)) AS ExceedLimit
	,CASE WHEN a.iCusCreLine >= ISNULL(c.iMoney,0) THEN 'UNBLOCK' ELSE 'BLOCK' END AS Posting
from dbo.Customer a LEFT JOIN [dbo].[_Payment] b ON a.cCusPayCond = b.U8PaymentTermCode
	LEFT JOIN
  (
		SELECT a.cCusCode,SUM(b.iSum  - ISNULL(iExchSum  ,0)) AS iMoney
		FROM SaleBillVouch a INNER JOIN  dbo.SaleBillVouchs b ON a.SBVID = b.SBVID
		WHERE ISNULL(a.cInvalider,'') = '' AND ISNULL(a.cVerifier ,'') <> ''
		GROUP BY a.cCusCode
  )  c ON a.cCusCode = c.cCusCode
where 1=1 and isnull(a.iCusCreLine,0) > 1
    and a.bCredit  = 1
order by a.cCusCode
";

            DataTable dt = DbHelperSQL.Query(sSQL);
            gridControl1.DataSource = dt;

            gridView1.BestFitColumns();

            gridView1.FocusedRowHandle = 0;
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            gridView1.AddNewRow();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    for (int i = 0; i < gridView1.RowCount; i++)
            //    {
            //        gridView1.SetRowCellValue(i, gridColchoose, chkAll.Checked);
            //    }
            //}
            //catch { }
        }

        private string SetStringFormat(object o,int iLength)
        {
            string sTxt = o.ToString().Trim();
            if (sTxt.Length < iLength)
            {
                while (sTxt.Length < iLength)
                {
                    sTxt = " " + sTxt;
                }
            }
            else if (sTxt.Length > iLength)
            {
                sTxt = sTxt.Substring(sTxt.Length - iLength);
            }
            return sTxt;
        }
    }
}
