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
    public partial class PurchaseSet : UserControl
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

        public PurchaseSet()
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

                        Model._PurchaseSet model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._PurchaseSet();
                        model.ReasonCode = gridView1.GetRowCellValue(i, gridColReasonCode).ToString().Trim();
                        model.CostCenter = gridView1.GetRowCellValue(i, gridColCostCenter).ToString().Trim();
                        model.Description = gridView1.GetRowCellValue(i, gridColDescription).ToString().Trim();
                        model.CostCentreDescription = gridView1.GetRowCellValue(i, gridColCostCentreDescription).ToString().Trim();
                        model.GLAccountDescription = gridView1.GetRowCellValue(i, gridColGLAccountDescription).ToString().Trim();
                        model.GLAccountCode = gridView1.GetRowCellValue(i, gridColGLAccountCode).ToString().Trim();
                        model.iID = BaseFunction.ReturnInt(gridView1.GetRowCellValue(i, gridColiID));
                        model.Headtext = gridView1.GetRowCellValue(i, gridColHeadtext).ToString().Trim();
                        model.Reasonname = gridView1.GetRowCellValue(i, gridColReasonname).ToString().Trim();
                      
                        model.InternalOrder = gridView1.GetRowCellValue(i, gridColInternalOrder).ToString().Trim();

                        if (iID == 0)
                        {
                            model.Creater = sUserID;
                            model.CreateDate = dNowDate;

                            DAL._PurchaseSet dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._PurchaseSet();
                            sSQL = dal.Add(model);
                            iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        else
                        {
                            model.Creater = gridView1.GetRowCellValue(i, gridColCreateUid).ToString().Trim();
                            model.CreateDate = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridColCreateDate));
                            DAL._PurchaseSet dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._PurchaseSet();
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
SELECT  iID, ReasonCode, Description, CostCenter, CostCentreDescription, GLAccountCode, GLAccountDescription,Headtext,Reasonname
    ,InternalOrder, Creater, CreateDate
    ,cast(null as varchar(50)) as iState 
FROM _PurchaseSet
ORDER BY iID
";
            DataTable dt = DbHelperSQL.Query(sSQL);
            gridControl1.DataSource = dt;
            for (int i = 0; i < 10; i++)
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
                string sReasonCode = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColReasonCode).ToString().Trim();
                if (sReasonCode == "")
                {
                    throw new Exception("Please Choose data");
                }

                DialogResult d = MessageBox.Show("Delete " + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColReasonCode).ToString().Trim() + "?","Message",MessageBoxButtons.YesNo,MessageBoxIcon.Asterisk );
                if(d != DialogResult.Yes)
                {
                    return;
                }

                //判断是否使用

                int iID = BaseFunction.ReturnInt(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColiID));
                DAL._PurchaseSet dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._PurchaseSet();
                string sSQL = dal.Delete(iID);
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

                if (e.Column != gridColiState && gridView1.GetRowCellValue(iRow, gridColiState).ToString().Trim() != "edit")
                {
                    gridView1.SetRowCellValue(iRow, gridColiState, "edit");
                }
            }
            catch { }
        }

        private void btnAddRow_Click_1(object sender, EventArgs e)
        {
            gridView1.AddNewRow();
        }
    }
}
