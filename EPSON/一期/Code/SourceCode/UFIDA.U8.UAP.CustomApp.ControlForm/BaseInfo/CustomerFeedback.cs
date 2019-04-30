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
    public partial class CustomerFeedback : UserControl
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

        public CustomerFeedback()
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
                    MessageBox.Show("OK\n\tPath：" + sF.FileName);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sErr = "";
            int iCount = 0;
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }


                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sSQL = "truncate table _CustomerFeedback";
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        string sCustomerFeedback = gridView1.GetRowCellValue(i, gridColCustomerFeedback).ToString().Trim();
                        if (sCustomerFeedback == "")
                        {
                            continue;
                        }

                        Model._CustomerFeedback mod = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._CustomerFeedback();
                        mod.CustomerFeedback = sCustomerFeedback;

                        DAL._CustomerFeedback dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._CustomerFeedback();
                        sSQL = dal.Add(mod);
                        iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    if (sErr != "")
                    {
                        throw new Exception(sErr);
                    }

                    if (iCount > 0)
                    {
                        tran.Commit();

                        MessageBox.Show("OK");

                        GetGrid();
                    }
                    else
                    {
                        throw new Exception("no data");
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

        private void btnRefresh_Click(object sender, EventArgs e)
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
            int iFocRow = gridView1.FocusedRowHandle;
            string sSQL = @"
select *,cast(null as varchar(50)) as iState from [_CustomerFeedback] order by iID
";
            DataTable dt = DbHelperSQL.Query(sSQL);
            gridControl1.DataSource = dt;

            gridView1.AddNewRow();
            while (gridView1.RowCount < 10)
            {
                gridView1.AddNewRow();
            }

            gridView1.FocusedRowHandle = 0;

            gridView1.BestFitColumns();
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            gridView1.AddNewRow();
        }

        private void btnDEL_Click(object sender, EventArgs e)
        {
            try
            {
                string sCustomerFeedback = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColCustomerFeedback).ToString().Trim();
                if (sCustomerFeedback == "")
                {
                    throw new Exception("Please Choose data");
                }

                //判断是否使用


                string sSQL = "delete _CustomerFeedback where [CustomerFeedback] = '" + sCustomerFeedback + "'";
                int iCou = DbHelperSQL.ExecuteSql(sSQL);

                if (iCou > 0)
                {
                    MessageBox.Show("OK");
                    GetGrid();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                int iRow = e.RowHandle;

                if (e.Column == gridColCustomerFeedback)
                {
                    if (e.RowHandle == gridView1.RowCount - 1)
                    {
                        gridView1.AddNewRow();
                        gridView1.FocusedRowHandle = iRow;
                    }
                }
            }
            catch { }
        }
    }
}
