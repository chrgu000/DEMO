using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FrameBaseFunction
{
    public partial class FrmVenHavPriceInfo : Form
    {
        FrameBaseFunction.ClsDataBase clsSQL = FrameBaseFunction.ClsDataBaseFactory.Instance();
        FrameBaseFunction.ClsVenInvPrice cPrice = new FrameBaseFunction.ClsVenInvPrice();

        public string sVenCode;
        public string sVenName;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sInvCode">存货编码</param>
        /// <param name="iType">类型：? 采购；2 委外</param>
        public FrmVenHavPriceInfo(string sInvCode,int iType)
        {
            InitializeComponent();

            try
            {
                DataTable dt = cPrice.GetVenHavPrice(iType, sInvCode);
                gridControl1.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得供应商参照失败！  " + ee.Message);
            }
        }

        private void FrmVenHavPriceInfo_Load(object sender, EventArgs e)
        {
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

                sVenCode = gridView1.GetRowCellValue(iRow, gridColcVenCode).ToString().Trim();
                sVenName = gridView1.GetRowCellValue(iRow, gridColcVenName).ToString().Trim();

                DialogResult = DialogResult.OK;
            }
            catch (Exception ee)
            {
                MessageBox.Show("返回供应商信息失败！  " + ee.Message);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView1.RowCount > 0)
                {
                    iRow = gridView1.FocusedRowHandle;
                }

                sVenCode = gridView1.GetRowCellValue(iRow, gridColcVenCode).ToString().Trim();
                sVenName = gridView1.GetRowCellValue(iRow, gridColcVenName).ToString().Trim();

                DialogResult = DialogResult.OK;
            }
            catch (Exception ee)
            {
                MessageBox.Show("返回供应商信息失败！  " + ee.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
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