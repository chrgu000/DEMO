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
    public partial class FrmRepSalebillvouchSEL : Form
    {
        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        public string sProjectName;

        public FrmRepSalebillvouchSEL(string conn, string userid, string username, string logdate, string accid)
        {
            InitializeComponent();

            Conn = conn;
            sUserID = userid;
            sUserName = username;
            sLogDate = logdate;
            sAccID = accid;
        }

        private void SetLookup()
        {
            string sSQL = @"
select distinct rtrim(a.cSBVCode) as cSBVCode
from salebillvouch a inner join dbo._DispatchLists_SaleBillVouchs _temp on a.SBVID = _temp.SaleBillID
order by a.cSBVCode
";
            DataTable dt = DbHelperSQL.Query(sSQL);
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditSaleBillCode1.Properties.DataSource = dt;
            lookUpEditSaleBillCode2.Properties.DataSource = dt;

            sSQL = @"
select distinct a.cDefine10 as ProjectName
from salebillvouch  a inner join dbo._DispatchLists_SaleBillVouchs _temp on a.SBVID = _temp.SaleBillID
where ISNULL(a.cDefine10,'') <> ''
order by a.cDefine10
";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditProName1.Properties.DataSource = dt;
            lookUpEditProName2.Properties.DataSource = dt;

            sSQL = @"
select distinct b.cCusInvCode
from salebillvouchs b inner join Inventory inv on b.cInvCode = inv.cInvCode
      inner join dbo._DispatchLists_SaleBillVouchs _temp on b.AutoID = _temp.SaleBillsID
where isnull(b.cCusInvCode,'') <> ''
order by  b.cCusInvCode
";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditPartNO1.Properties.DataSource = dt;
            lookUpEditPartNO2.Properties.DataSource = dt;
        }


        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string sSQL = @"
select distinct isnull(a.cDefine10,'') as [ProjectName],a.cSBVCode as [SalebillCode],a.dDate
from salebillvouch a inner join salebillvouchs b on a.SBVID = b.SBVID
    inner join ._DispatchLists_SaleBillVouchs _temp on b.AutoID = _temp.SaleBillsID
where 1=1
order by a.dDate,a.cSBVCode
";
                if (lookUpEditSaleBillCode1.EditValue != null && lookUpEditSaleBillCode1.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cSBVCode >= '" + lookUpEditSaleBillCode1.Text.Trim() + "' ");
                }
                if (lookUpEditSaleBillCode2.EditValue != null && lookUpEditSaleBillCode2.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cSBVCode <= '" + lookUpEditSaleBillCode2.Text.Trim() + "' ");
                }

                if (dateEdit1.Text != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.dDate >= '" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "' ");
                }
                if (dateEdit2.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.dDate < '" + dateEdit2.DateTime.AddDays(1).ToString("yyyy-MM-dd") + "' ");
                }

                if (lookUpEditProName1.EditValue != null && lookUpEditProName1.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cDefine10 >= '" + lookUpEditProName1.Text.Trim() + "' ");
                }
                if (lookUpEditProName2.EditValue != null && lookUpEditProName2.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cDefine10 <= '" + lookUpEditProName2.Text.Trim() + "' ");
                }

                if (lookUpEditPartNO1.EditValue != null && lookUpEditPartNO1.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.cCusInvCode >= '" + lookUpEditPartNO1.Text.Trim() + "' ");
                }
                if (lookUpEditPartNO2.EditValue != null && lookUpEditPartNO2.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.cCusInvCode <= '" + lookUpEditPartNO2.Text.Trim() + "' ");
                }

                DataTable dt = DbHelperSQL.Query(sSQL);
                gridControl1.DataSource = dt;
                gridView1.BestFitColumns();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void FrmRepSalebillvouchSEL_Load(object sender, EventArgs e)
        {
            try
            {
                DbHelperSQL.connectionString = Conn;

                SetLookup();

                dateEdit1.DateTime = BaseFunction.ReturnDate(BaseFunction.ReturnDate(sLogDate).ToString("yyyy-MM-01"));
                dateEdit2.DateTime = BaseFunction.ReturnDate(sLogDate);
            }
            catch
            { }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                sProjectName = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColProjectName).ToString().Trim();
                if (sProjectName == "")
                {
                    throw new Exception("NO project name");
                }

                this.DialogResult = DialogResult.Yes;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                btnOK_Click(null, null);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
