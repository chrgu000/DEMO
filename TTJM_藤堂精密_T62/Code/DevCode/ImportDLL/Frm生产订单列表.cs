using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrameBaseFunction;

namespace ImportDLL
{
    public partial class Frm生产订单列表 : Form
    {
        FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();

        public Frm生产订单列表()
        {
            InitializeComponent();
        }

        public long lIDDetails;

        private void GetGrid()
        {
            string sSQL = @"
select cast(0 as bit) as bChoose,a.cCode,a.dDate,b.cInvCode,i.cInvName,i.cInvStd
	,cast(b.fQuantity as decimal(16,2)) as fQuantity,b.dStartDate,b.dEndDate,cast(b.cDefine26 as int) as cDefine26,a.ID,b.MainId,a.cDepCode,dep.cDepName,a.cPersonCode,per.cPersonName,a.iState
from @u8.PP_ProductPO a inner join @u8.PP_POMain b on a.ID = b.ID
	left join @u8.Inventory I on I.cInvCode = b.cInvCode
    left join @u8.Department dep on dep.cDepCode = a.cDepCode
    left join @u8.Person per on per.cPersonCode = a.cPersonCode
where 1=1 and a.iState = 2
order by b.ID
";
            if (lookUpEdit生产订单号1.EditValue != null && lookUpEdit生产订单号1.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cCode >= '" + lookUpEdit生产订单号1.EditValue.ToString().Trim() + "'");
            }
            if (lookUpEdit生产订单号2.EditValue != null && lookUpEdit生产订单号2.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cCode <= '" + lookUpEdit生产订单号2.EditValue.ToString().Trim() + "'");
            }
            if (dateEdit1.Text != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.dDate >= '" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "'");
            }
            if (dateEdit2.Text != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.dDate <= '" + dateEdit2.DateTime.ToString("yyyy-MM-dd") + "'");
            }
            DataTable dt = DbHelperSQL.Query(sSQL);
            gridControl1.DataSource = dt;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void btnSEL_Click(object sender, EventArgs e)
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                long l = -1;

                l = BaseFunction.BaseFunction.ReturnLong(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridCol单据ID));
                if (l > 0)
                {
                    lIDDetails = l;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("请选择订单");
                }
            }
            catch { }
        }

        private void Frm生产订单列表_Load(object sender, EventArgs e)
        {
            try
            {
                this.StartPosition = FormStartPosition.CenterScreen;

                SetLookUp();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void SetLookUp()
        {
            string sSQL = @"
select distinct cCode from @u8.PP_ProductPO where iState = 2 order by cCode
";
            DataTable dt = DbHelperSQL.Query(sSQL);
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEdit生产订单号1.Properties.DataSource = dt;
            lookUpEdit生产订单号2.Properties.DataSource = dt;

            dateEdit1.DateTime = DateTime.Today.AddMonths(-1);
            dateEdit2.DateTime = DateTime.Today;
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
