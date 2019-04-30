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
    public partial class SalesSet : UserControl
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

        public SalesSet()
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
                gridView1.PostEditor();

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sSQL = "select getdate()";
                    DateTime dNow = BaseFunction.ReturnDate(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                    DateTime dNowDate = BaseFunction.ReturnDate(dNow.ToString("yyyy-MM-dd"));

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        int iID = BaseFunction.ReturnInt(gridView1.GetRowCellValue(i, gridColiID));
                        string iState = gridView1.GetRowCellValue(i, gridColiState).ToString().Trim();

                        if (iState == "")
                        {
                            continue;
                        }

                        Model._SalesSet model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._SalesSet();
                        model.SalesType = gridView1.GetRowCellValue(i, gridColSalesType).ToString().Trim();
                        model.GLCode = gridView1.GetRowCellValue(i, gridColGLCode).ToString().Trim();
                        model.Headtext = gridView1.GetRowCellValue(i, gridColHeadtext).ToString().Trim();
                        model.Internalorder = gridView1.GetRowCellValue(i, gridColInternalorder).ToString().Trim();
                        model.ItemText = gridView1.GetRowCellValue(i, gridColItemText).ToString().Trim();
                        model.ItemText2 = gridView1.GetRowCellValue(i, gridColItemText2).ToString().Trim();
                        model.ProfitCenter = gridView1.GetRowCellValue(i, gridColProfitCenter).ToString().Trim();
                      
                        model.Remark = gridView1.GetRowCellValue(i, gridColRemark).ToString().Trim();

                        if (iID == 0)
                        {
                            model.Creater = sUserID;
                            model.CreateDate = dNowDate;

                            DAL._SalesSet dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._SalesSet();
                            sSQL = dal.Add(model);
                            iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        else
                        {
                            model.Creater = gridView1.GetRowCellValue(i, gridColCreateUid).ToString().Trim();
                            model.CreateDate = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridColCreateDate));
                            DAL._SalesSet dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._SalesSet();
                            sSQL = dal.Update(model);
                            iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
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

        private void SetLookup()
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                SetLookup();

                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void GetGrid()
        { 
            string sSQL = @"
SELECT a.cSTCode AS SalesType,b.GLCode, b.Headtext, b.Internalorder, b.ProfitCenter, b.ItemText, b.ItemText2,  b.Remark,b.Creater, b.CreateDate,b.iID
,cast(null as varchar(50)) as iState 
FROM dbo.SaleType a LEFT JOIN [dbo].[_SalesSet] b ON a.cSTCode = b.SalesType
ORDER BY a.cSTCode
";
            DataTable dt = DbHelperSQL.Query(sSQL);
            gridControl1.DataSource = dt;

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
                string sSalesType = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColSalesType).ToString().Trim();
                if (sSalesType == "")
                {
                    throw new Exception("Please Choose data");
                }

                DialogResult d = MessageBox.Show("Delete " + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColSalesType).ToString().Trim() + "?","Message",MessageBoxButtons.YesNo,MessageBoxIcon.Asterisk );
                if(d != DialogResult.Yes)
                {
                    return;
                }

                //判断是否使用

                DAL._SalesSet dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._SalesSet();
                string sSQL = dal.Delete(sSalesType);
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

                if (e.Column != gridColGLCode)
                {
                    if (e.RowHandle == gridView1.RowCount - 1)
                    {
                        gridView1.AddNewRow();
                        gridView1.FocusedRowHandle = iRow;
                    }
                }

                if (e.Column != gridColiState && gridView1.GetRowCellValue(iRow, gridColiState).ToString().Trim() != "edit")
                {
                    gridView1.SetRowCellValue(iRow, gridColiState, "edit");
                }
            }
            catch { }
        }
    }
}
