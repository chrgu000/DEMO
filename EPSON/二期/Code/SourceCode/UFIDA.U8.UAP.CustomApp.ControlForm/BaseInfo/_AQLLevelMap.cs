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
    public partial class _AQLLevelMap : UserControl
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

        public _AQLLevelMap()
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
FROM [dbo].[_AQLLevelMap]
order by CodeLetter, AQLLevel
";

            DataTable dt = DbHelperSQL.Query(sSQL);
            gridControl1.DataSource = dt;

            while (gridView1.RowCount < 20)
            {
                gridView1.AddNewRow();
            }

            gridView1.FocusedRowHandle = iFoc;
            
            SetBtnEnable(true);
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            gridView1.AddNewRow();
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
                        string sStatus = gridView1.GetRowCellValue(i, gridColsStatus).ToString().Trim().ToLower();
                        if (sStatus == "")
                            continue;

                        Model._AQLLevelMap mod = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._AQLLevelMap();
                        mod.CodeLetter = gridView1.GetRowCellValue(i, gridColCodeLetter).ToString().Trim();
                        mod.AQLLevel = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i,gridColAQLLevel).ToString().Trim());
                        mod.Accept = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColAccept));
                        mod.Reject = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColReject));
                        mod.iID = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColiID));

                        string sSQL = "";
                        if (sStatus == "add")
                        {
                            DAL._AQLLevelMap dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._AQLLevelMap();
                            sSQL = dal.Add(mod);
                            iCou += DbHelperSQL.ExecuteSql(sSQL);
                        }
                        if (sStatus == "edit")
                        {
                            DAL._AQLLevelMap dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._AQLLevelMap();
                            sSQL = dal.Update(mod);
                            iCou += DbHelperSQL.ExecuteSql(sSQL);
                        }
                    }
                    if (iCou > 0)
                    {
                        tran.Commit();

                        MessageBox.Show("OK");
                    }

                    SetBtnEnable(true);
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
                    string sCodeLetter = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColCodeLetter).ToString().Trim();
                    decimal dAQLLevel = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColAQLLevel));

                    string sSQL = "Delete _AQLLevelMap where CodeLetter = '{0}' and AQLLevel = '{1}'";
                    sSQL = string.Format(sSQL, sCodeLetter, dAQLLevel);
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

        private void btnAddRow_Click_1(object sender, EventArgs e)
        {
            gridView1.AddNewRow();
        }

        private void SetLookup()
        {
            string sSQL = @"
select distinct CodeLetter 
from [dbo].[_AQLSampleSizeMap]
order by CodeLetter
";
            DataTable dt = DbHelperSQL.Query(sSQL);
            ItemLookUpEditCodeLetter.DataSource = dt;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (BaseFunction.ReturnLong(gridView1.GetRowCellValue(e.FocusedRowHandle, gridColiID)) > 0)
                {
                    gridColCodeLetter.OptionsColumn.AllowEdit = false;
                    gridColAQLLevel.OptionsColumn.AllowEdit = false;
                }
                else
                {
                    gridColCodeLetter.OptionsColumn.AllowEdit = true;
                    gridColAQLLevel.OptionsColumn.AllowEdit = true;
                }
            }
            catch { }
        }
    }
}
