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
    public partial class ActionFCost : UserControl
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
                dateEdit1.DateTime = BaseFunction.ReturnDate(sLogDate).AddMonths(-6);
                dateEdit1.Enabled = true;

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

        public ActionFCost()
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
FROM _ActionFCost
where 1=1
ORDER BY cInvCode, ActionCode
";
            if(dateEdit1.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and dtmStart >= '" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "'");
            }
            if (lookUpEditcCusCode.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and cCusCode = '" + lookUpEditcCusCode.Text.Trim() + "'");
            }

            DataTable dt = DbHelperSQL.Query(sSQL);
            gridControl1.DataSource = dt;
            gridView1.AddNewRow();

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
            btnLoad.Enabled = b;
            btnEdit.Enabled = b;
            btnSave.Enabled = !b;
            btnDelete.Enabled = !b;
            btnAddRow.Enabled = !b;
            dtmStartImprot.Enabled = !b;

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
                string sErr = "";
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

                        string sActionCode = gridView1.GetRowCellDisplayText(i, gridColActionCode).ToString().Trim();
                        string sInvCode = gridView1.GetRowCellDisplayText(i, gridColcInvCode).ToString().Trim();
                        string sCusCode = gridView1.GetRowCellDisplayText(i, gridColcCusCode).ToString().Trim();
                        if (sActionCode == "" && sInvCode == "" && sCusCode == "")
                            continue;

                        if (sActionCode != "" || sInvCode != "" || sCusCode != "")
                        {
                            if (sActionCode == "")
                            {
                                sErr = sErr + "Row " + (i + 1).ToString() + " Action Code  err\n";
                                continue;
                            }
                            if (sInvCode == "")
                            {
                                sErr = sErr + "Row " + (i + 1).ToString() + " Part no err\n";
                                continue;
                            }
                            if (sCusCode == "")
                            {
                                sErr = sErr + "Row " + (i + 1).ToString() + "  Customer Code err\n";
                                continue;
                            }
                        }

                        Model._ActionFCost mod = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._ActionFCost();
                        mod.cCusCode = gridView1.GetRowCellValue(i, gridColcCusCode).ToString().Trim();
                        mod.cInvCode = sInvCode;
                        mod.ActionCode = sActionCode;
                        mod.MANHOUR = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColMANHOUR), 2);
                        mod.Labour = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColLabour), 2);
                        mod.Process = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColProcess), 2);
                        mod.PlatingCost = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColPlatingCost), 2);
                        mod.Part = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColPart), 2);
                        mod.dtmStart = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridColdtmStart));

                        //if (mod.dtmStart < BaseFunction.ReturnDate(sLogDate))
                        //{
                        //    sErr = sErr + "Row " + (i + 1).ToString() + " Start Date err\n";
                        //    continue;
                        //}

                        mod.iID = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColiID));

                        string sSQL = "";
                        if (sStatus == "add")
                        {
                            try
                            {
                                //更新上一次的结束日期
                                sSQL = @"
update _ActionFCost set dtmEnd = '{0}'
where iID in ( select max(iID) from _ActionFCost where cCusCode = '{1}' and cInvCode = '{2}' and ActionCode = '{3}')
";
                                sSQL = string.Format(sSQL, mod.dtmStart.AddDays(-1), mod.cCusCode, mod.cInvCode, mod.ActionCode);
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                DAL._ActionFCost dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._ActionFCost();
                                sSQL = dal.Add(mod);

                                iCou += DbHelperSQL.ExecuteSql(sSQL);
                            }
                            catch (Exception ee)
                            {
                                sErr = sErr + "Row " + (i + 1).ToString() + " " + ee.Message + " err\n";
                                continue;
                            }
                        }
                        if (sStatus == "edit")
                        {
                            try
                            {
                                DAL._ActionFCost dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._ActionFCost();
                                sSQL = dal.Update(mod);
                                iCou += DbHelperSQL.ExecuteSql(sSQL);
                            }
                            catch (Exception ee)
                            {
                                sErr = sErr + "Row " + (i + 1).ToString() + " " + ee.Message + " err\n";
                                continue;
                            }
                        }
                    }
                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
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
                FrmMsgBox frm = new FrmMsgBox();
                frm.richTextBox1.Text = ee.Message;
                frm.ShowDialog();
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

                if (e.Column == gridColcInvCode && e.RowHandle == gridView1.RowCount - 1)
                {
                    int iFoc = e.RowHandle;
                    gridView1.AddNewRow();
                    gridView1.FocusedRowHandle = iFoc;
                }
                if (e.Column != gridColdtmStart && gridView1.GetRowCellDisplayText(e.RowHandle, gridColdtmStart).ToString().Trim() == "")
                {
                    if (dtmStartImprot.DateTime > Convert.ToDateTime("2010-01-01"))
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridColdtmStart, dtmStartImprot.DateTime);
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
                    long lID = BaseFunction.ReturnLong(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColiID));

                    string sSQL = "Delete  _ActionFCost where iID = {0}";
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

        private void btnAddRow_Click_1(object sender, EventArgs e)
        {
            gridView1.AddNewRow();
        }

        private void SetLookup()
        {
            string sSQL = @"
select ActionCode,Action from _Action order by ActionCode
";
            DataTable dt = DbHelperSQL.Query(sSQL);
            ItemLookUpEditActionCode.DataSource = dt;
            ItemLookUpEditAction.DataSource = dt;

            sSQL = @"
select cInvCode ,cInvName from Inventory 
order by cInvCode 
";
            dt = DbHelperSQL.Query(sSQL);
            ItemLookUpEditcInvCode.DataSource = dt;
            ItemLookUpEditcInvName.DataSource = dt;

            sSQL = @"
select cCusCode,cCusName from Customer order by cCusCode
";
            dt = DbHelperSQL.Query(sSQL);
            ItemLookUpEditcCusCode.DataSource = dt;
            ItemLookUpEditcCusName.DataSource = dt;

            lookUpEditcCusCode.Properties.DataSource = dt;
            lookUpEditcCusName.Properties.DataSource = dt;
        }

        private void lookUpEditcCusCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEditcCusName.EditValue = lookUpEditcCusCode.EditValue;
            }
            catch { }
        }

        private void lookUpEditcCusName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEditcCusCode.EditValue = lookUpEditcCusName.EditValue;
            }
            catch { }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel|*.xls|Excel|*.xlsx|All File|*.*";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                string fName = openFileDialog.FileName;

                ClsExcel clsExcel = ClsExcel.Instance();

                string sSQL = @"
select *
from [Sheet1$]
";
                DataTable dt = clsExcel.ExcelToDT(fName, sSQL, true);
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    string sCol = dt.Columns[i].ColumnName;
                    if (sCol.ToLower() == "CustomerCode".ToLower())
                    {
                        dt.Columns[i].ColumnName = "cCusCode";
                    }
                    if (sCol.ToLower() == "PartNo".ToLower())
                    {
                        dt.Columns[i].ColumnName = "cInvCode";
                    }
                    if (sCol.ToLower() == "StartDate".ToLower())
                    {
                        dt.Columns[i].ColumnName = "dtmStart";
                    }
                    if (sCol.ToLower() == "MAN-HOUR".ToLower())
                    {
                        dt.Columns[i].ColumnName = "MANHOUR";
                    }
                }
                DataColumn dc = new DataColumn();
                dc.ColumnName = "sStatus";
                dt.Columns.Add(dc);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["sStatus"] = "add";
                }

                gridControl1.DataSource = dt;

                SetBtnEnable(false);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
