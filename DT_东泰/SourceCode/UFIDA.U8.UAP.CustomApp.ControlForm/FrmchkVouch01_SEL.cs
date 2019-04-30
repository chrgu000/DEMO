using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TH.BaseClass;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{

    public partial class FrmchkVouch01_SEL : Form
    {

        TH.BaseClass.GetBaseData getBaseData = new GetBaseData();
        string sConn;

        public FrmchkVouch01_SEL(string sConnString)
        {
            InitializeComponent();

            sConn = sConnString;
        }

        public string sCode;

        private void SetLookup()
        {
            string sSQL = @"
select distinct cCode from [dbo].[_TH_ChkValue01] order by cCode
";
            DataTable dt = DbHelperSQL.Query(sSQL);
            DataRow dr = dt.NewRow();
            dr["cCode"]="";
            dt.Rows.InsertAt(dr, 0);
            lookUpEditcCode.Properties.DataSource = dt;


            sSQL = @"
select distinct WONo as [生产订单号] from [dbo].[_TH_ChkValue01] order by WONo
";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dr["生产订单号"] = "";
            dt.Rows.InsertAt(dr, 0);
            lookUpEdit生产订单号.Properties.DataSource = dt;


            sSQL = @"
select distinct [WorkProcess] from [dbo].[_TH_ChkValue01] order by [WorkProcess]
";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dr["WorkProcess"] = "";
            dt.Rows.InsertAt(dr, 0);
            lookUpEdit工序.Properties.DataSource = dt;


            sSQL = @"
select distinct [WorkGroup] from [dbo].[_TH_ChkValue01] order by [WorkGroup]
";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dr["WorkGroup"] = "";
            dt.Rows.InsertAt(dr, 0);
            lookUpEdit班组.Properties.DataSource = dt;

            sSQL = @"
select cInvCode ,cInvName from Inventory order by cInvCode
"; 
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dr["cInvCode"] = "";
            dr["cInvName"] = "";
            dt.Rows.InsertAt(dr, 0);

            lookUpEditcInvCode.Properties.DataSource = dt;
            lookUpEditcInvName.Properties.DataSource = dt;

            dtm1.DateTime = DateTime.Today.AddDays(-7);
            dtm2.DateTime = DateTime.Today;
        }

        private void FrmchkVouch01_SEL_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookup();

            }
            catch(Exception ee)
            {}
        }

        private void btnSEL_Click(object sender, EventArgs e)
        {
            string sSQL = @"
select *
from [_TH_ChkValue01]
where 1=1 
";
            if (lookUpEditcCode.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and cCode = '" + lookUpEditcCode.Text.Trim() + "'");
            }
            if (lookUpEdit生产订单号.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and WONo = '" + lookUpEdit生产订单号.Text.Trim() + "'");
            }
            if (lookUpEditcInvCode.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and cInvCode = '" + lookUpEditcInvCode.Text.Trim() + "'");
            }

            if (lookUpEdit工序.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and WorkProcess = '" + lookUpEdit工序.Text.Trim() + "'");
            }
            if (lookUpEdit班组.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and WorkGroup = '" + lookUpEdit班组.Text.Trim() + "'");
            }
            if (dtm1.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and dtmCode >= '" + dtm1.DateTime.ToString("yyyy-MM-dd") + "'");
            }
            if (dtm2.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and dtmCode < '" + dtm2.DateTime.AddDays(1).ToString("yyyy-MM-dd") + "'");
            }
            DataTable  dt = DbHelperSQL.Query(sSQL);
            gridControl1.DataSource = dt;
            gridView1.BestFitColumns();


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

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                gridView1_DoubleClick(null, null);
            }
            catch { }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.sCode = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColcCode).ToString().Trim();

                this.DialogResult = DialogResult.OK;
            }
            catch { }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void lookUpEditcInvCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEditcInvName.EditValue = lookUpEditcInvCode.EditValue;
            }
            catch { }
        }

        private void lookUpEditcInvName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEditcInvCode.EditValue = lookUpEditcInvName.EditValue;
            }
            catch { }
        }
    }
}
