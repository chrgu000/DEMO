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
using DevExpress.XtraReports.UI;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class BarClose : UserControl
    {
        TH.BaseClass.GetBaseData getBaseData = new GetBaseData();

        UFIDA.U8.UAP.CustomApp.ControlForm.RepBaseGrid Rep = new RepBaseGrid();

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        string sProPath = Application.StartupPath;
        string sPrintLayOutMod = Application.StartupPath + "\\UAP\\Runtime\\print\\BarLabel1.dll";
       

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                DbHelperSQL.connectionString = Conn;
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        public BarClose()
        {
            InitializeComponent();
        }

        private void GetGrid()
        { 
            string sSQL = @"
SELECT 
      cast(0 as bit) as choose
    ,case when isnull([CloseUid],'') = '' then 'Use' else 'Closed' end as StatusBarCode
    ,d.*
FROM dbo.SO_SOMain A INNER JOIN dbo.SO_SODetails B ON A.ID = B.ID
	INNER JOIN inventory c ON b.cInvCode = c.cInvCode
	inner JOIN [dbo].[_BarCodeLabel] d ON b.iSOsID = d.iSOsID
WHERE 1=1 
ORDER BY a.cSOCode, b.AutoID
";
            sSQL = sSQL.Replace("1=1", "1=1 and d.BarCode = '" + txtBarCode.Text.Trim() + "'");

            DataTable dt = DbHelperSQL.Query(sSQL);

            txtSaleOrderNo.Text = dt.Rows[0]["ORDERNO"].ToString().Trim();
            txtRowNo.Text = dt.Rows[0]["SaleorderRowNo"].ToString().Trim();
            txtiSOsID.Text = dt.Rows[0]["iSOsID"].ToString().Trim();
            txtcInvCode.Text = dt.Rows[0]["cInvCode"].ToString().Trim();
            txtcInvName.Text = dt.Rows[0]["cInvName"].ToString().Trim();
            txtDEPT.Text = dt.Rows[0]["DEPT"].ToString().Trim();
            txtCUST.Text = dt.Rows[0]["CUST"].ToString().Trim();
            txtLOTNO.Text = dt.Rows[0]["BarCode"].ToString().Trim();
            txtStatus.Text = BaseFunction.ReturnStatus(dt.Rows[0]["StatusBarCode"].ToString().Trim());
            txtOrderQTY.Text = BaseFunction.ReturnDecimal(dt.Rows[0]["ORDERQTY"], 0).ToString().Trim();

            txtBarCode.Focus();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode != Keys.Enter)
                    return;

                if (txtBarCode.Text.Trim() == "")
                {
                    MessageBox.Show("Please scan barcode");
                    return;
                }

                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBarCode.Text.Trim() == "")
                {
                    MessageBox.Show("Please scan barcode");
                    return;
                }

                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            txtBarCode.Focus();

            int iCount = 0;
            try
            {
                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sSQL = @"select * from _BarCodeLabel  where [BarCode] = '" + txtBarCode.Text.Trim() + "'";
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        throw new Exception("Barcode is not exists");
                    }
                    if (dt.Rows[0]["CloseUid"].ToString().Trim() == "")
                    {
                        throw new Exception("Barcode is unclosed");
                    }

                    sSQL = "update [_BarCodeLabel] set [CloseUid] = null,[CloseDate] = null where [BarCode] = '" + txtBarCode.Text.Trim() + "'";
                    iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    if (iCount > 0)
                    {
                        tran.Commit();

                        MessageBox.Show("OK");

                        SetTxtNull();
                    }
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            txtBarCode.Focus();

            int iCount = 0;
            try
            {
                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sSQL = @"select * from _BarCodeLabel  where [BarCode] = '" + txtBarCode.Text.Trim() + "'";
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        throw new Exception("Barcode is not exists");
                    }
                    if (dt.Rows[0]["CloseUid"].ToString().Trim() != "")
                    {
                        throw new Exception("Barcode is closed");
                    }

                    sSQL = "update [_BarCodeLabel] set [CloseUid] = '" + sUserID + "',[CloseDate] = GETDATE() where [BarCode] = '" + txtBarCode.Text.Trim() + "'";
                    iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    if (iCount > 0)
                    {
                        tran.Commit();

                        MessageBox.Show("OK");

                        SetTxtNull();
                    }
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

        private void SetTxtNull()
        {
            txtBarCode.Text = "";
            txtSaleOrderNo.Text = "";
            txtRowNo.Text = "";
            txtiSOsID.Text = "";
            txtcInvCode.Text = "";
            txtcInvName.Text = "";
            txtDEPT.Text = "";
            txtCUST.Text = "";
            txtLOTNO.Text = "";
            txtOrderQTY.Text = "";
            txtStatus.Text = "";
            txtBarCode.Text = "";

            txtBarCode.Focus();
        }



    }
}
