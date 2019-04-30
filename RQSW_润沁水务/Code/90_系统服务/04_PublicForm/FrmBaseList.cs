using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 系统服务
{
    public partial class FrmBaseList : Form
    {
        系统服务.ClsDataBase clsSQL = 系统服务.ClsDataBaseFactory.Instance();
        int iType = 0;

        /// <summary>
        /// 列表参照
        /// </summary>
        /// <param name="i">1 部门</param>
        public FrmBaseList(int i)
        {
            InitializeComponent();

            iType = i;
        }
        public string sID;
        public string sText;

        private void FrmBaseList_Load(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "";
                switch (iType)
                {
                    case 1:
                        sSQL = "SELECT cDepCode AS iID, cDepName AS iText FROM @u8.Department WHERE bDepEnd =1 ORDER BY cDepCode ";
                        break;
                    default:
                        break;
                }
                DataTable dt = clsSQL.ExecQuery(sSQL);
                gridControl1.DataSource = dt;
            }
            catch(Exception ee) 
            {
                MessageBox.Show("获得" + this.Text.Trim() + "失败！  " + ee.Message);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView1.RowCount > 0)
                {
                    iRow = gridView1.FocusedRowHandle;
                }

                sID = gridView1.GetRowCellValue(iRow, gridColiID).ToString().Trim();
                sText = gridView1.GetRowCellValue(iRow, gridColiText).ToString().Trim();

                DialogResult = DialogResult.OK;
            }
            catch (Exception ee)
            {
                MessageBox.Show("返回" + this.Text.Trim() + "失败！  " + ee.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            btnOK_Click(null, null);
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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
    }
}