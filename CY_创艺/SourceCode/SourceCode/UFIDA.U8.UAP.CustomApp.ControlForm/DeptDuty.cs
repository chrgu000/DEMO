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
    public partial class DeptDuty : UserControl
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

        private void SetLookUp()
        {
            string sSQL = "select cDutyCode,vDutyName from dbo.hr_tm_DutyBasic where  isnull(bused,1) = 1 order by cDutyCode";
            DataTable dt = DbHelperSQL.Query(sSQL);
            ItemLookUpEditcDutyCode.Properties.DataSource = dt;

            sSQL = "select cDepCode ,cDepName  from dbo.Department  order by cDepCode";
            dt = DbHelperSQL.Query(sSQL);
            ItemLookUpEditcDept_num.Properties.DataSource = dt;
        }



        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                DbHelperSQL.connectionString = Conn;
                SetLookUp();
                GetGrid();
            }
            catch
            { 
            
            }
        }

        public DeptDuty()
        {
            InitializeComponent();
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
            try
            {
                string sErr = "";
                int iCount = 0;

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

                    string sSQL = "";
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (!BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColbChoose)))
                            continue;

                        if (gridView1.GetRowCellValue(i, gridColcDept_num).ToString().Trim() == "")
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "部门必须填写\n";
                            continue;
                        }

                        if (gridView1.GetRowCellValue(i, gridColcDutyCode).ToString().Trim() == "")
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "班次必须填写\n";
                            continue;
                        }

                        for (int j = 0; j < i; j++)
                        {
                            if (gridView1.GetRowCellValue(i, gridColcDept_num).ToString().Trim() == (gridView1.GetRowCellValue(j, gridColcDept_num).ToString().Trim())
                                && gridView1.GetRowCellValue(i, gridColcDutyCode).ToString().Trim() == (gridView1.GetRowCellValue(j, gridColcDutyCode).ToString().Trim()))
                            {
                                sErr = sErr + "行" + (i + 1) + "部门,班次" + "不可重复的\n";
                                continue;
                            }
                        }

                        string iID = gridView1.GetRowCellValue(i, gridColiID).ToString().Trim();
                        if (iID == "")
                        {
                            sSQL = "insert into _DeptDuty(cDept_num,cDutyCode) values('" + gridView1.GetRowCellValue(i, gridColcDept_num).ToString().Trim() + "','" + gridView1.GetRowCellValue(i, gridColcDutyCode).ToString().Trim() + "')";
                        }
                        else
                        {
                            sSQL = "update _DeptDuty set cDept_num='" + gridView1.GetRowCellValue(i, gridColcDept_num).ToString().Trim() + "',cDutyCode='" + gridView1.GetRowCellValue(i, gridColcDutyCode).ToString().Trim() + "' where iID=" + iID;
                        }
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        iCount = iCount + 1;
                    }

                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }

                    if (iCount > 0)
                    {
                        tran.Commit();
                        MessageBox.Show("保存成功\n");

                        GetGrid();
                    }
                    else
                    {
                        throw new Exception("无数据需要保存");
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

        private void GetGrid()
        {
            int iRow = gridView1.FocusedRowHandle;

            chkAll.Checked = false;

            string sSQL = @"
select cast(0 as bit) as bChoose,'sel' as sState, * from _DeptDuty 
";
            DataTable dt = DbHelperSQL.Query(sSQL);
            gridControl1.DataSource = dt;
            gridView1.AddNewRow();

            gridView1.FocusedRowHandle = iRow;
        }

        private void btnSEL_Click(object sender, EventArgs e)
        {
            
            try
            {
                GetGrid();
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column != gridColbChoose && gridView1.GetRowCellValue(e.RowHandle, gridColsState).ToString().Trim() == "")
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridColsState, "add");
                }

                if (e.Column != gridColbChoose && e.Column != gridColsState)
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridColbChoose, true);
                }

                if (e.Column != gridColcDept_num && gridView1.GetRowCellValue(e.RowHandle,gridColsState).ToString().Trim() == "")
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridColsState, "edit");
                }

                if (e.RowHandle == gridView1.RowCount - 1 && (e.Column == gridColcDept_num || e.Column == gridColcDutyCode))
                {
                    int iRow = e.RowHandle;
                    gridView1.AddNewRow();

                    gridView1.FocusedRowHandle = iRow;
                }

            }
            catch { }
        }

        private void btnDEL_Click(object sender, EventArgs e)
        {
            try
            {
                string sErr = "";
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
                    int iCou = 0;
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (!BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColbChoose)))
                            continue;

                        string iID = gridView1.GetRowCellValue(i, gridColiID).ToString().Trim();
                        if (iID == "")
                            continue;

                        string sSQL = "delete _DeptDuty where iID = N'111111' ";
                        sSQL = sSQL.Replace("111111", iID);
                        iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    if (sErr != "")
                    {
                        throw new Exception(sErr);
                    }

                    if (iCou > 0)
                    {
                        tran.Commit();
                        MessageBox.Show("删除成功\n");

                        GetGrid();
                    }
                    else
                    {
                        MessageBox.Show("无数据需要保存");
                    }
                }
                catch(Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
            }
            catch(Exception ee) 
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
            }
            catch { }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                { 
                    if(gridView1.GetRowCellValue(i,gridColcDept_num).ToString().Trim() == "")
                    {
                        continue;
                    }

                    gridView1.SetRowCellValue(i, gridColbChoose, chkAll.Checked);
                }
            }
            catch { }
        }



    }
}
