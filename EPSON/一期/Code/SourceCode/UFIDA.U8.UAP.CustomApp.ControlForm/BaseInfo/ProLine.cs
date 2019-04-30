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
    public partial class ProLine : UserControl
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

        public ProLine()
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

                        UFIDA.U8.UAP.CustomApp.ControlForm.Model._ProLine model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._ProLine();
                        model.cCode = gridView1.GetRowCellValue(i, gridColcCode).ToString().Trim();
                        model.cName = gridView1.GetRowCellValue(i, gridColcName).ToString().Trim();
                        model.Remark1 = gridView1.GetRowCellValue(i, gridColRemark1).ToString().Trim();
                        model.Remark2 = gridView1.GetRowCellValue(i, gridColRemark2).ToString().Trim();
                        model.Remark3 = gridView1.GetRowCellValue(i, gridColRemark3).ToString().Trim();
                        model.Remark4 = gridView1.GetRowCellValue(i, gridColRemark4).ToString().Trim();
                        model.Remark5 = gridView1.GetRowCellValue(i, gridColRemark5).ToString().Trim();

                        UFIDA.U8.UAP.CustomApp.ControlForm.DAL._ProLine dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._ProLine();
                        sSQL = dal.Exists(model.cCode);
                        bool b = DbHelperSQL.Exists(tran,sSQL);

                        if (b)
                        {
                            model.Creater = gridView1.GetRowCellValue(i, gridColCreateUid).ToString().Trim();
                            model.CreateDate = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridColCreateDate));
                            model.UpdateUid = sUserName;
                            model.UpdateDate = dNowDate;
                            sSQL = dal.Update(model);
                            iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        else
                        {
                            model.Creater = sUserName;
                            model.CreateDate = dNowDate;
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
            string sSQL = @"
select *
	,CAST(null as varchar(50)) as iState
from [_ProLine] a
order by a.cCode
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

        private void btnDEL_Click(object sender, EventArgs e)
        {
            try
            {
                int iRow = gridView1.FocusedRowHandle;
                string sID = gridView1.GetRowCellValue(iRow, gridColiID).ToString().Trim();
                if (sID == "")
                {
                    return;
                }

                string sCode = gridView1.GetRowCellValue(iRow, gridColcCode).ToString().Trim();
                DialogResult d = MessageBox.Show("del or not", "", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (d == DialogResult.Yes)
                {
                    string sSQL = "delete _ProLine where iID = " + sID;
                    int iCou = DbHelperSQL.ExecuteSql(sSQL);
                    MessageBox.Show("ok");

                    GetGrid();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void addrowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                gridView1.AddNewRow();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }

        private void delrowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                gridView1.DeleteRow(gridView1.FocusedRowHandle);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

    }
}
