using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
//using UFIDA.U8.UAP.CustomApp.ControlForm.Business;
using DevExpress.XtraEditors;
using System.Xml;
using System.Data.SqlClient;
using TH.BaseClass;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class 结算方式对应表 : UserControl
    {
 
        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        public 结算方式对应表()
        {
            InitializeComponent();
        }


        private void 结算方式对应表_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                string sSQL = "select * from SettleStyle";
                ItemLookUpEdit结算方式.DataSource = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                conn.Close();
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message + "加载数据失败");
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
            try
            {
                string sSQL = @"SELECT    *,'edit' as iSave,cast(0 as bit) as iChk,cast(0 as bit) as iIsPro FROM       ERP_Link_SettleStyle";
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                grdDetail.DataSource = dt;
                gridView1.AddNewRow();
                gridView1.FocusedRowHandle = gridView1.RowCount - 1;
                gridView1.SetRowCellValue(gridView1.RowCount - 1, gridColChk, "False");
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        private void grvDetail_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {

            if (e.RowHandle < 0)
                return;
            e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                gridView1.PostEditor();
                this.Validate();

                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
                sF.Filter = "Excel文件(*.xls)|*.xls|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridView1.ExportToXls(sF.FileName);
                    MessageBox.Show("导出Excel成功\n\t路径：" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("导出列表失败：" + ee.Message);
            }
        }

        private void ItemTextEditN2_Enter(object sender, EventArgs e)
        {
            TextEdit item = sender as TextEdit;
            item.SelectAll();
            Application.DoEvents();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }
            string sErr = "";
            SqlConnection con = new SqlConnection(Conn);
            SqlCommand cmd = new SqlCommand();
            SqlTransaction trans;
            con.Open();
            cmd.Connection = con;
            trans = con.BeginTransaction();
            cmd.Transaction = trans;
            try
            {
                for (int i = gridView1.RowCount - 1; i >= 0; i--)
                {
                    if (gridView1.GetRowCellValue(i, gridColChk).ToString().Trim()=="True")
                    {
                        string sCode = gridView1.GetRowCellValue(i, gridCol业务系统编码).ToString().Trim();
                        if (sCode != "")
                        {
                            cmd.CommandText = "delete ERP_Link_SettleStyle  where 业务系统编码='" + sCode + "'";
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                if (sErr.Trim().Length > 0)
                {
                    throw new Exception(sErr);
                }

                trans.Commit();
                MessageBox.Show("删除成功");
                GetGrid();
            }
            catch (Exception ee)
            {
                trans.Rollback();

                MessageBox.Show("删除失败:" + ee.Message);

            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                gridView1.FocusedColumn = gridCol业务系统编码;
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
                gridView1.Focus();
            }
            catch { }
            string sErr = "";
            string sSQL = "";
            System.Collections.ArrayList aList = new System.Collections.ArrayList();

            SqlConnection con = new SqlConnection(Conn);
            SqlCommand cmd = new SqlCommand();
            SqlTransaction trans;
            con.Open();
            cmd.Connection = con;
            trans = con.BeginTransaction();
            cmd.Transaction = trans;
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridColiSave).ToString().Trim() != "add" && gridView1.GetRowCellValue(i, gridColiSave).ToString().Trim() != "update")
                    {
                        continue;
                    }
                    if (gridView1.GetRowCellValue(i, gridCol结算方式编码) == null || gridView1.GetRowCellValue(i, gridCol结算方式编码).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "结算方式编码不可为空\n";
                    }
                    if (gridView1.GetRowCellValue(i, gridCol业务系统编码) == null || gridView1.GetRowCellValue(i, gridCol业务系统编码).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "业务系统编码不可为空\n";
                    }


                    if (gridView1.GetRowCellValue(i, gridColiSave).ToString().Trim() == "add")
                    {
                        string iSQL = "insert into ERP_Link_SettleStyle(业务系统编码,结算方式编码) values  " +
                           "('" + gridView1.GetRowCellValue(i, gridCol业务系统编码).ToString().Trim() + "','" + gridView1.GetRowCellValue(i, gridCol结算方式编码).ToString().Trim() + "')";
                        cmd.CommandText = iSQL;
                        cmd.ExecuteNonQuery();
                    }
                    else if (gridView1.GetRowCellValue(i, gridColiSave).ToString().Trim() == "update")
                    {
                        string iSQL = "update ERP_Link_SettleStyle set  " +
                            "结算方式编码='" + gridView1.GetRowCellValue(i, gridCol结算方式编码).ToString().Trim() + "' where 业务系统编码='" + gridView1.GetRowCellValue(i, gridCol业务系统编码).ToString().Trim() + "' ";
                        cmd.CommandText = iSQL;
                        cmd.ExecuteNonQuery();
                    }

                }


                if (sErr.Trim().Length > 0)
                {
                    MessageBox.Show(sErr);
                }
                trans.Commit();
                if (sErr.Trim().Length == 0)
                {
                    MessageBox.Show("保存成功");
                }
                GetGrid();
            }
            catch (Exception ee)
            {
                trans.Rollback();
                MessageBox.Show(ee.Message);

            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView1.FocusedRowHandle >= 0)
                    iRow = gridView1.FocusedRowHandle;

                if (e.Column != gridColiSave && e.Column != gridColChk && gridView1.GetRowCellDisplayText(e.RowHandle, gridColiSave).ToString().Trim() == "")
                {
                    gridView1.SetRowCellValue(iRow, gridColiSave, "add");
                }
                if (e.Column != gridColiSave && e.Column != gridColChk && gridView1.GetRowCellDisplayText(e.RowHandle, gridColiSave).ToString().Trim() == "edit")
                {
                    gridView1.SetRowCellValue(iRow, gridColiSave, "update");
                }

                if (e.Column == gridCol结算方式编码 && e.RowHandle == gridView1.RowCount - 1 && gridView1.GetRowCellDisplayText(e.RowHandle, gridCol结算方式编码).ToString().Trim() != "")
                {
                    gridView1.AddNewRow();
                }
            }
            catch (Exception ee)
            { }
        }


        private void btnSel_Click(object sender, EventArgs e)
        {
            try
            {
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得数据失败:" + ee.Message);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gridView1.GetRowCellDisplayText(e.FocusedRowHandle, gridColiSave).ToString().Trim() == "edit" || gridView1.GetRowCellDisplayText(e.FocusedRowHandle, gridColiSave).ToString().Trim() == "update")
                {
                    gridCol业务系统编码.OptionsColumn.ReadOnly = true;
                }
                else
                {
                    gridCol业务系统编码.OptionsColumn.ReadOnly = false;
                }
            }
            catch (Exception ee)
            { 
                
            }
        }
    }
}