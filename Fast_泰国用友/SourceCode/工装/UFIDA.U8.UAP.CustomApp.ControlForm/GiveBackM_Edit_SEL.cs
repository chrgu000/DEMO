using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TH.BaseClass;
using System.Data.SqlClient;
using System.IO;
using System.Collections;


namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class GiveBackM_Edit_SEL : Form
    {
        UFIDA.U8.UAP.CustomApp.ControlForm.RepBaseGrid Rep = new RepBaseGrid();

        public GiveBackM_Edit_SEL(string connectionString,ArrayList a)
        {
            InitializeComponent();

            DbHelperSQL.connectionString = connectionString;

            aList = a;
        }

        public ArrayList aList = new ArrayList();

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
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

        private void SetLookup()
        {
            string sSQL = @"
select cPersonCode,cPersonName from person order by cPersonCode
";
            DataTable dt = DbHelperSQL.Query(sSQL);
            lookUpEditPerson.Properties.DataSource = dt;

            sSQL = @"
select cDepCode,cDepName from Department where bDepEnd = 1 order by cDepCode 
";
            dt = DbHelperSQL.Query(sSQL);
            lookUpEditDep.Properties.DataSource = dt;

            dtmCode1.DateTime = DateTime.Today;

            sSQL = @"
select SerialNo,InvName,InvStd from _FrockClamp order by SerialNo
";

            dt = DbHelperSQL.Query(sSQL);
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            ItemLookUpEditInvName.DataSource = dt;
            ItemLookUpEditInvStd.DataSource = dt;
            ItemLookUpEditSerialNo.DataSource = dt;

            sSQL = @"
select cCode from _Maintenance order by cCode
";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditCode1.Properties.DataSource = dt;
            lookUpEditCode2.Properties.DataSource = dt;

            dtmCode1.DateTime = DateTime.Now.AddMonths(-1);
            dtmCode2.DateTime = DateTime.Now;
        }

        private void FrmGriveBackM_Edit_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookup();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void GetGrid()
        {
            string sSQL = @"
select cast(0 as bit) as bChoose, b.* 
from _Maintenance a inner join _Maintenances b on a.cCode = b.cCode 
	left join [dbo].[_GiveBackMs] c on b.iID = c.MaintenancesiID
where isnull(a.AuditUserName,'') <> '' and 1=1
	and isnull(c.MaintenancesiID,0) = 0
order by a.iID,b.iID
";
            if (lookUpEditCode1.EditValue != null && lookUpEditCode1.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cCode >= N'" + lookUpEditCode1.EditValue.ToString().Trim() + "'");
            }
            if (lookUpEditCode2.EditValue != null && lookUpEditCode2.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cCode <= N'" + lookUpEditCode2.EditValue.ToString().Trim() + "'");
            }
            if (dtmCode1.Text != "" && dtmCode1.DateTime > BaseFunction.ReturnDate("2015-01-01"))
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.dDate >= N'" + dtmCode1.DateTime.ToString("yyyy-MM-dd") + "'");
            }
            if (dtmCode2.Text != "" && dtmCode2.DateTime > BaseFunction.ReturnDate("2015-01-01"))
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.dDate <= N'" + dtmCode2.DateTime.ToString("yyyy-MM-dd") + "'");
            }
            if (lookUpEditPerson.EditValue != null && lookUpEditPerson.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.Person = N'" + lookUpEditPerson.EditValue.ToString().Trim() + "'");
            }
            if (lookUpEditDep.EditValue != null && lookUpEditDep.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.DepCode = N'" + lookUpEditDep.EditValue.ToString().Trim() + "'");
            }
            DataTable dt = DbHelperSQL.Query(sSQL);
            gridControl1.DataSource = dt;
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
                aList = new ArrayList();
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    bool b = BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColbChoose));
                    if (b)
                    {
                        aList.Add(gridView1.GetRowCellValue(i, gridColiID).ToString().Trim());
                    }
                }

                DialogResult = DialogResult.OK;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

    }
}
