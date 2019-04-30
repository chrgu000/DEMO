using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 系统服务;
using System.Data.SqlClient;

namespace 业务
{
    public partial class Frm检验图表数据修改 : Form
    {
        string s班组;
        string s测定项目;
        string s检验工位;
        string sUserName;

        public Frm检验图表数据修改(string sConn,string sGroup,string sPro,string sSite,string sUser)
        {
            InitializeComponent();

            DbHelperSQL.connectionString = sConn;
            s班组 = sGroup;
            s测定项目 = sPro;
            s检验工位 = sSite;
            sUserName = sUser;
        }

        private void GetGrid()
        {
            string sSQL = @"
select *
    ,cast(0 as bit) as Selected
from 
(
    select top 24 * ,getdate() as dtmNow
    from [dbo].[工作台测量] 
    where isnull(删除人,'') = ''
	    and 测定项目 = '{0}'
        and 1=1
    order by iID desc
)a
order by iID 
";
            if (this.s检验工位 != null && this.s检验工位 != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and 工作台 = '" + this.s检验工位 + "'");
            }
            if (this.s班组 != null && this.s班组 != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and 班组 = '" + this.s班组 + "'");
            }

            sSQL = string.Format(sSQL, s测定项目);
            System.Data.DataTable dt = DbHelperSQL.Query(sSQL);

            if (dt == null || dt.Rows.Count == 0)
                return;

            gridControl1.DataSource = dt;
            gridView1.BestFitColumns();

            gridCol测量值.OptionsColumn.AllowEdit = true;
        }
      
        private void Frm_Load(object sender, EventArgs e)
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (!BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColSelected)))
                            continue;

                        decimal d测量值 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol测量值));
                        long iID = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColiID));
                        string s备注 = gridView1.GetRowCellValue(i, gridCol备注).ToString().Trim();

                        string sSQL = @"
update 工作台测量 set 测量值 = {0},备注 = N'{2}',操作员 = '{3}',操作日期 = getdate() where iID = {1}
";
                        sSQL = string.Format(sSQL, d测量值, iID, s备注, sUserName);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                    tran.Commit();
                }
                catch (Exception ee)
                {
                    tran.Rollback();

                    throw new Exception(ee.Message);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                int iCou = 0;
                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (!BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColSelected)))
                            continue;

                        long iID = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColiID));
                        string s备注 = gridView1.GetRowCellValue(i, gridCol备注).ToString().Trim();

                        string sSQL = @"
update 工作台测量 set 删除人 = '{0}',删除日期 = getdate(),备注 = N'{2}' where iID = {1}
";
                         sSQL = string.Format(sSQL, sUserName, iID, s备注);
                        iCou += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                    tran.Commit();

                    if (iCou > 0)
                    {
                        GetGrid();
                    }
                }
                catch (Exception ee)
                {
                    tran.Rollback();

                    throw new Exception(ee.Message);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column != gridColSelected)
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridColSelected, true);
                }
            }
            catch { }
        }
    }
}
