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
    public partial class InvProcess : UserControl
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
                SetLookUp();
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

        public InvProcess()
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
                    string sInvCode = btnTxtInvCode.Text.Trim();
                    if (sInvCode == "" || lookUpEditInvName.EditValue == null)
                    {
                        throw new Exception("Please set Item Code");
                    }

                    string sSQL = "select getdate()";
                    DateTime dNow = BaseFunction.ReturnDate(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                    DateTime dNowDate = BaseFunction.ReturnDate(dNow.ToString("yyyy-MM-dd"));

                    sSQL = "delete [dbo].[_InvProcess] where [cInvCode] = '" + sInvCode + "' ";
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (gridView1.GetRowCellValue(i, gridColProcessNo).ToString().Trim() == "")
                            continue;

                        Model._InvProcess model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._InvProcess();

                        model.cInvCode = sInvCode;

                        model.ProcessNo = gridView1.GetRowCellValue(i, gridColProcessNo).ToString().Trim();
                        if (model.ProcessNo == "")
                        {
                            sErr = sErr + "Row " + (i + 1).ToString() + " error Please set Porcess\n";
                            continue;
                        }
                        if (gridView1.GetRowCellValue(i, gridColProcessRow).ToString().Trim() == "")
                        {
                            sErr = sErr + "Row " + (i + 1).ToString() + " error Please set PorcessRow\n";
                            continue; 
                        }
                        model.ProcessRow = gridView1.GetRowCellValue(i, gridColProcessRow).ToString().Trim();

                        model.Remark = gridView1.GetRowCellValue(i, gridColRemark).ToString().Trim();
                        model.CreateUid = sUserID;
                        model.CreateDate = dNowDate;

                        DAL._InvProcess dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._InvProcess();
                        sSQL = dal.Add(model);
                        iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
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
            if (lookUpEditInvName.EditValue == null)
                return;

            string sInvCode = lookUpEditInvName.EditValue.ToString().Trim();

            if (sInvCode != "")
            {
                string sSQL = @"
select *,cast(null as varchar(50)) as iState from [_InvProcess] where 1=1 order by cInvCode, [ProcessRow]
";
                sSQL = sSQL.Replace("1=1", "1=1 and [cInvCode] = '" + sInvCode + "'");
                DataTable dt = DbHelperSQL.Query(sSQL);
                gridControl1.DataSource = dt;

                gridView1.BestFitColumns();

                gridView1.AddNewRow();
                while (gridView1.RowCount < 10)
                {
                    gridView1.AddNewRow();
                }

                gridView1.FocusedRowHandle = 0;
            }
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            gridView1.AddNewRow();
        }

        private void btnDEL_Click(object sender, EventArgs e)
        {
            try
            {
                string sInvCode = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColItemCode).ToString().Trim();
                if (sInvCode == "")
                {
                    throw new Exception("Please Choose data");
                }
                //判断是否使用


                string sSQL = "delete _InvProcess where cInvCode = '" + sInvCode + "'";
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

                if (e.Column == gridColProcessNo)
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

        private void SetLookUp()
        {
            string sSQL = "select cInvCode ,cInvName,cInvStd from Inventory order by cInvCode";
            DataTable dt = DbHelperSQL.Query(sSQL);
            ItemLookUpEditcInvName.DataSource = dt;
            lookUpEditInvName.Properties.DataSource = dt;

            sSQL = "select ProcessNo,Process from _Process order by ProcessNo";
            dt = DbHelperSQL.Query(sSQL);
            ItemLookUpEditProcess.DataSource = dt;
            ItemLookUpEditProcessNo.DataSource = dt;
        }

        private void ItemButtonEditcInvCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
             try
             {
                 try
                 {
                     gridView1.FocusedColumn = gridColItemName;
                     gridView1.FocusedColumn = gridColItemCode;
                 }
                 catch { }

                 string sInvCode = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColItemCode).ToString().Trim();

                 FrmInvInfo frm = new FrmInvInfo(sInvCode, false);
                 DialogResult d = frm.ShowDialog();
                 if (d == DialogResult.OK)
                 {
                     gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridColItemCode, frm.sInvCode);
                 }
             }
             catch { }
        }

        private void btnTxtInvCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                string sInvCode = btnTxtInvCode.Text.Trim();

                FrmInvInfo frm = new FrmInvInfo(sInvCode, false);
                DialogResult d = frm.ShowDialog();
                if (d == DialogResult.OK)
                {
                    lookUpEditInvName.EditValue = frm.sInvCode;
                }
            }
            catch { }
        }

        private void lookUpEditInvName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (lookUpEditInvName.EditValue != null)
                {
                    btnTxtInvCode.Text = lookUpEditInvName.EditValue.ToString().Trim();
                }
            }
            catch { }
        }

        private void btnTxtInvCode_Validated(object sender, EventArgs e)
        {
            try
            {
                if (btnTxtInvCode.Text.Trim() != "")
                {
                    lookUpEditInvName.EditValue = btnTxtInvCode.Text.Trim();

                    GetGrid();
                }
            }
            catch { }
        }

        private void btnTxtInvCode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                btnTxtInvCode_Validated(null, null);
            }
            catch { }
        }
    }
}
