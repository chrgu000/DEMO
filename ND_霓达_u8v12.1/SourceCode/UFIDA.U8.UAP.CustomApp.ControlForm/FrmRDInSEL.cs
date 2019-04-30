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
    public partial class FrmRDInSEL : Form
    {
        public string sCode = "";
        public string sConnString = "";

        public FrmRDInSEL()
        {
            InitializeComponent();
        }

        private void FrmRDInSEL_Load(object sender, EventArgs e)
        {
            try
            {
                DbHelperSQL.connectionString = sConnString;

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
select cWhCode,cWhName from WareHouse order by cWhCode
            ";
            DataTable dt = DbHelperSQL.Query(sSQL);
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditWH1.Properties.DataSource = dt;
            lookUpEditWH2.Properties.DataSource = dt;
            ItemLookUpEdit仓库.DataSource = dt;

            sSQL = @"
select cDepCode ,cDepName from department where bDepEnd = 1 order by cDepCode
";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditDep1.Properties.DataSource = dt;
            lookUpEditDep2.Properties.DataSource = dt;
            ItemLookUpEdit部门.DataSource = dt;

            sSQL = @"
select cCode from rdrecord11 where isnull(cHandler,'') <> '' order by cCode 
";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditcCode1.Properties.DataSource = dt;
            lookUpEditcCode2.Properties.DataSource = dt;

            dtm1.DateTime = DateTime.Today;
            dtm2.DateTime = DateTime.Today;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                int iRow = gridView1.FocusedRowHandle;
                sCode = gridView1.GetRowCellValue(iRow, gridColcCode).ToString().Trim();
                if (sCode != "")
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    throw new Exception("请选择单据");
                }
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

        private void btnSEL_Click(object sender, EventArgs e)
        {
            try
            {
                string sSQL = @"
select * from RdRecord11 where 1=1  order by ID
";
                if (lookUpEditcCode1.EditValue != null && lookUpEditcCode1.EditValue.ToString().Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and cCode >= '" + lookUpEditcCode1.EditValue.ToString().Trim() + "'");
                }
                if (lookUpEditcCode2.EditValue != null && lookUpEditcCode2.EditValue.ToString().Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and cCode <= '" + lookUpEditcCode2.EditValue.ToString().Trim() + "'");
                }
                if (dtm1.Text != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and dDate >= '" + dtm1.DateTime.ToString("yyyy-MM-dd") + "'");
                }
                if (dtm2.Text != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and dDate <= '" + dtm2.DateTime.ToString("yyyy-MM-dd") + "'");
                }
                if (!chk包含已生单.Checked)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and cCode not in (select cDefine12  from RdRecord08  where isnull(cDefine12,'') <> '') ");
                }
                if (lookUpEditDep1.EditValue != null && lookUpEditDep1.EditValue.ToString().Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and cDepCode = '" + lookUpEditDep1.EditValue.ToString().Trim() + "'");
                }
                if (lookUpEditWH1.EditValue != null && lookUpEditWH1.EditValue.ToString().Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and cWhCode = '" + lookUpEditWH1.EditValue.ToString().Trim() + "'");
                }
                DataTable dt = DbHelperSQL.Query(sSQL);
                gridControl1.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void lookUpEditWH1_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditWH2.EditValue = lookUpEditWH1.EditValue;
        }

        private void lookUpEditWH2_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditWH1.EditValue = lookUpEditWH2.EditValue;
        }

        private void lookUpEditDep1_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditDep2.EditValue = lookUpEditDep1.EditValue;
        }

        private void lookUpEditDep2_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditDep1.EditValue = lookUpEditDep2.EditValue;
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

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                btnOK_Click(null, null);
            }
            catch { }
        }

        private void lookUpEditcCode1_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditcCode2.EditValue = lookUpEditcCode1.EditValue;
        }
    }
}
