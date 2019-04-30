using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorkInformation
{
    public partial class Frm列表参照 : Form
    {
        FrameBaseFunction.ClsDataBase clsSQL = FrameBaseFunction.ClsDataBaseFactory.Instance();

        DataTable dt = null;
        public string sKey = "";
        public Frm列表参照(DataTable d)
        {
            InitializeComponent();
            this.dt = d;
        }

        private void Frm列表参照_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = dt;
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                int iRow = gridView1.FocusedRowHandle;
                sKey = gridView1.GetRowCellDisplayText(iRow, gridView1.Columns[0]);
                this.DialogResult = DialogResult.Yes;
            }
            catch (Exception ee)
            {
                this.DialogResult = DialogResult.No;
            }
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