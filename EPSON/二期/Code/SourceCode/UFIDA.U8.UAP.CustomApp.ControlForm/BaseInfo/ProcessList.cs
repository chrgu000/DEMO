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
    public partial class ProcessList : UserControl
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

                DataTable dt = new DataTable();
                DataColumn dc = new DataColumn();
                dc.ColumnName = "Active";
                dt.Columns.Add(dc);
                DataRow dr = dt.NewRow();
                dr["Active"] = "Yes";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Active"] = "No";
                dt.Rows.Add(dr);
                ItemLookUpEditActive.DataSource = dt;
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


        public ProcessList()
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
                    string sSQL = "select getdate()";
                    DateTime dNow = BaseFunction.ReturnDate(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                    DateTime dNowDate = BaseFunction.ReturnDate(dNow.ToString("yyyy-MM-dd"));

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        string sState = gridView1.GetRowCellValue(i, gridColiState).ToString().Trim();
                        if (sState == "")
                            continue;

                        Model.ProcessList model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.ProcessList();
                        model.Remark = gridView1.GetRowCellValue(i, gridColRemark).ToString().Trim();
                        model.Status = gridView1.GetRowCellValue(i, gridColStatus).ToString().Trim();
                        model.ProcessCode = gridView1.GetRowCellValue(i, gridColProcessCode).ToString().Trim();
                        model.Seq = gridView1.GetRowCellValue(i, gridColSeq).ToString().Trim();
                        model.PlatingProcess = gridView1.GetRowCellValue(i, gridColPlatingProcess).ToString().Trim();
                        model.Condition = gridView1.GetRowCellValue(i, gridColCondition).ToString().Trim();
                        model.Thichness = gridView1.GetRowCellValue(i, gridColThichness).ToString().Trim();
                        model.Time = gridView1.GetRowCellValue(i, gridColTime).ToString().Trim();
                        model.Density = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColDensity), 2);
                        model.AMP = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColAMP), 2);
                        model.Updatedby = sUserID;
                        model.UpdateDate = dNow;
                        model.iID = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i,gridColiID));
                        model.Remark = gridView1.GetRowCellValue(i, gridColRemark).ToString().Trim();

                        DAL.ProcessList dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.ProcessList();
                        sSQL = dal.Exists(model.iID);
                        bool b = DbHelperSQL.Exists(tran, sSQL);

                        if (b || BaseFunction.ReturnLong(gridView1.GetRowCellValue(i,gridColiID)) > 0)
                        {
                            sSQL = dal.Update(model);
                            iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        else
                        {
                            sSQL = dal.Add(model);
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
select *,cast(null as varchar(50)) as iState
from _ProcessList a
order by  ProcessCode,Seq,PlatingProcess
";
            DataTable dt = DbHelperSQL.Query(sSQL);
            gridControl1.DataSource = dt;
            gridView1.AddNewRow();

            gridView1.FocusedRowHandle = iFocRow;
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            gridView1.AddNewRow();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                int iRow = e.RowHandle;

                if (e.Column != gridColiState)
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

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                long iID = BaseFunction.ReturnLong( gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColiID));
                if (iID == 0)
                {
                    throw new Exception("Please Choose data");
                }
                //判断是否使用


                string sSQL = "delete _ProcessList where iID = " + iID.ToString();
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

        private void btnAddCopyRow_Click(object sender, EventArgs e)
        {
            try
            {
                int iRow = gridView1.FocusedRowHandle;
                gridView1.AddNewRow();
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }
                int iNewRow = gridView1.RowCount - 1;
                for (int i = gridView1.RowCount - 1; i >= 0; i--)
                {
                    if (gridView1.GetRowCellValue(i, gridColProcessCode).ToString().Trim() == "")
                    {
                        iNewRow = i;
                    }
                }

                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    object o = gridView1.GetRowCellValue(iRow, gridView1.Columns[i]);
                    gridView1.SetRowCellValue(iNewRow, gridView1.Columns[i], o);
                }

                gridView1.SetRowCellValue(iNewRow, gridColiState, "add");
                gridView1.SetRowCellValue(iNewRow, gridColUpdatedBy, sUserName);
                gridView1.SetRowCellValue(iNewRow, gridColUpdatedDate, DateTime.Today);
                gridView1.SetRowCellValue(iNewRow, gridColiID, 0);

                gridView1.FocusedRowHandle = iNewRow;

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message); 
            }
        }
    }
}
