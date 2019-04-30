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
    public partial class DSSaleBaseInfo : UserControl
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
                btnQuery_Click(null, null);
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        public DSSaleBaseInfo()
        {
            InitializeComponent();
        }

        private void SetLookup()
        {
            //string sSQL = "select distinct cWhCode,cWhName from Warehouse order by cWhCode";
            //DataTable dt = DbHelperSQL.Query(sSQL);
            //ItemLookUpEditcWhCode.DataSource = dt;
            //ItemLookUpEditcWhName.DataSource = dt;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                string sErr = "";

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    int iCou = 0;
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        bool b = BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColbChoose));
                        if (!b)
                            continue;

                        if (gridView1.GetRowCellValue(i, gridColcSTCode).ToString().Trim() == "")
                            continue;

                        Model._DSSaleBaseInfo mod = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._DSSaleBaseInfo();
                        mod.cSTCode = gridView1.GetRowCellValue(i, gridColcSTCode).ToString().Trim();
                        mod.bDS = BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColbCreateDP));

                        DAL._DSSaleBaseInfo dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._DSSaleBaseInfo();
                        string sSQL = dal.Exists(mod.cSTCode);
                        int iDataCou = BaseFunction.ReturnInt(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                        if (iDataCou > 0)
                        {
                            sSQL = dal.Update(mod);
                            iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        else
                        {
                            sSQL = dal.Add(mod);
                            iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                    }

                    if (sErr != "")
                    { 
                        throw new Exception(sErr);
                    }

                    //if (iCou > 0)
                    //{
                        tran.Commit();

                        MessageBox.Show("Save sucess");

                        btnQuery_Click(null, null);
                    //}
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("Save err:" + ee.Message);
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

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string sSQL = @"
select cast(0 as bit) as bChoose,a.cSTCode ,a.cSTName,cast(isnull(b.bDS,0) as bit) as bCreateDP
from SaleType a left join [dbo].[_DSSaleBaseInfo] b on a.cSTCode = b.cSTCode
order by a.cSTCode
";
            DataTable dt = DbHelperSQL.Query(sSQL);
            gridControl1.DataSource = dt;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column != gridColbChoose)
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridColbChoose, true);
                }
            }
            catch { }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
                sF.Filter = "Excel(*.xls)|*.xls|All files(*.*)|*.*";
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
                f.Text = "Export err";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

    }
}
