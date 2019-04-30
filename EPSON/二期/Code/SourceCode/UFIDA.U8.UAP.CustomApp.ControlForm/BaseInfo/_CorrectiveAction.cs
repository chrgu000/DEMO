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
    public partial class _CorrectiveAction : UserControl
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
                f.Text = "Load From is err";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        public _CorrectiveAction()
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
                sF.Filter = "xlsx(*.xlsx)|*.xlsx|All Files(*.*)|*.*";
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
                f.Text = "Export Err";
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
            SetLookup();

            int iFoc = gridView1.FocusedRowHandle;

            string sSQL = @"
SELECT *
    ,cast(null as varchar(50)) as sStatus
FROM _CorrectiveActionReportLogsheet
ORDER BY iID
";

            DataTable dt = DbHelperSQL.Query(sSQL);
            gridControl1.DataSource = dt;
            gridView1.AddNewRow();

            gridView1.FocusedRowHandle = iFoc;
            
            SetBtnEnable(true);
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            SetBtnEnable(false);
        }

        private void SetBtnEnable(bool b)
        {
            btnEdit.Enabled = b;
            btnSave.Enabled = !b;
            btnDelete.Enabled = !b;
            btnAddRow.Enabled = !b;

            gridView1.OptionsBehavior.Editable = !b;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            try
            {
                int iCou = 0;
                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        string sType = gridView1.GetRowCellValue(i, gridColsType).ToString().Trim().ToLower();
                        if (sType == "")
                            continue;

                        Model._CorrectiveActionReportLogsheet mod = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._CorrectiveActionReportLogsheet();
                        mod.sType = gridView1.GetRowCellValue(i, gridColsType).ToString().Trim();
                        mod.Barcode = gridView1.GetRowCellValue(i, gridColBarcode).ToString().Trim();
                        mod.ReportNo = gridView1.GetRowCellValue(i, gridColReportNo).ToString().Trim();
                        if(BaseFunction.ReturnDate(gridView1.GetRowCellValue(i,gridColDateofComplaint)) > Convert.ToDateTime("2000-01-01"))
                        {
                            mod.DateofComplaint = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridColDateofComplaint));
                        }
                        mod.cCusCode = gridView1.GetRowCellValue(i, gridColcCusCode).ToString().Trim();
                        mod.cDepCode = gridView1.GetRowCellValue(i, gridColcDepCode).ToString().Trim();

                        if (BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridColDateIssued)) > Convert.ToDateTime("2000-01-01"))
                        {
                            mod.DateIssued = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridColDateIssued));
                        }
                        if (BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridColDueDate)) > Convert.ToDateTime("2000-01-01"))
                        {
                            mod.DueDate = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridColDueDate));
                        }
                        if (BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridColDateReplied)) > Convert.ToDateTime("2000-01-01"))
                        {
                            mod.DateReplied = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridColDateReplied));
                        }
                        if (BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridColDateClosed)) > Convert.ToDateTime("2000-01-01"))
                        {
                            mod.DateClosed = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridColDateClosed));
                        }

                        mod.Remarks = gridView1.GetRowCellValue(i, gridColRemarks).ToString().Trim();
                        mod.Complaint = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColComplaint));
                        mod.Claim = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColClaim));

                        mod.iID = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColiID));

                        string sSQL = "";
                        if (mod.iID == 0)
                        {
                            DAL._CorrectiveActionReportLogsheet dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._CorrectiveActionReportLogsheet();
                            sSQL = dal.Add(mod);
                            iCou += DbHelperSQL.ExecuteSql(sSQL);
                        }
                        else
                        {
                            DAL._CorrectiveActionReportLogsheet dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._CorrectiveActionReportLogsheet();
                            sSQL = dal.Update(mod);
                            iCou += DbHelperSQL.ExecuteSql(sSQL);
                        }
                    }
                    if (iCou > 0)
                    {
                        tran.Commit();

                        MessageBox.Show("OK");

                        GetGrid();
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

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column != gridColsStatus)
                {
                    long iID = BaseFunction.ReturnLong(gridView1.GetRowCellValue(e.RowHandle, gridColiID));
                    string sStatus = gridView1.GetRowCellValue(e.RowHandle, gridColsStatus).ToString().Trim();
                    if (iID > 0)
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridColsStatus, "Edit");
                    }
                    else
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridColsStatus, "Add");
                    }
                }

                if (e.Column == gridColsType && e.RowHandle == gridView1.RowCount - 1)
                {
                    int iFoc = e.RowHandle;
                    gridView1.AddNewRow();
                    gridView1.FocusedRowHandle = iFoc;
                }
            }
            catch { }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int iCou = 0;
                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    long lID = BaseFunction.ReturnLong(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColiID));

                    string sSQL = "Delete _CorrectiveActionReportLogsheet where iID = {0}";
                    sSQL = string.Format(sSQL, lID);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    tran.Commit();

                    MessageBox.Show("OK");

                    GetGrid();
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

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            gridView1.AddNewRow();
        }


        private void SetLookup()
        {
            string sSQL = @"
select cCusCode,cCusName
from Customer
order by cCusCode
";
            DataTable dt = DbHelperSQL.Query(sSQL);
            ItemLookUpEditcCusCode.DataSource = dt;
            ItemLookUpEditcCusName.DataSource = dt;

            sSQL = @"
select cDepCode,cDepName
from Department
order by cDepCode
";
            dt = DbHelperSQL.Query(sSQL);
            ItemLookUpEditcDepCode.DataSource = dt;
            ItemLookUpEditcDepName.DataSource = dt;

            dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "sType";
            dt.Columns.Add(dc);

            DataRow dr = dt.NewRow();
            dr["sType"] = "Internal";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["sType"] = "External";
            dt.Rows.Add(dr);
            ItemLookUpEditsType.DataSource = dt;
        }
    }
}
