using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TH.BaseClass;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class FrmMaterialList : Form
    {
        public string s����ڼ�;
        public string s���ű���;
        public string s��Ʒ����;

        /// <summary>
        /// 
        /// </summary>
        public FrmMaterialList()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                int iRow = gridView1.FocusedRowHandle;
                if (iRow < 0)
                {
                    throw new Exception("��ѡ����Ҫ�鿴����");
                }
                s����ڼ� = gridView1.GetRowCellValue(iRow, gridCol����ڼ�).ToString().Trim();
                s���ű��� = gridView1.GetRowCellValue(iRow, gridCol���ű���).ToString().Trim();
                s��Ʒ���� = gridView1.GetRowCellValue(iRow, gridCol��Ʒ����).ToString().Trim();

                DialogResult = DialogResult.OK;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void FrmMaterialList_Load(object sender, EventArgs e)
        {
            try
            {
                GetLookUp();
            }
            catch (Exception ee)
            {
                MessageBox.Show("���ش���ʧ�ܣ�" + ee.Message);
            }
        }

        private void btnSEL_Click(object sender, EventArgs e)
        {
            string sSQL = @"
select distinct ����ڼ�,���� as ���ű���,��Ʒ���� from dbo._ProMaterial where 1=1 order by ����ڼ�,����,��Ʒ����
";
            if (lookUpEdit����ڼ�.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and ����ڼ� = '" + lookUpEdit����ڼ�.Text.Trim() + "'");
            }
            if (lookUpEditcDepCode.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and ���� = '" + lookUpEditcDepCode.Text.Trim() + "'");
            }
            if (btnTxtInvCode.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and ��Ʒ���� = '" + btnTxtInvCode.Text.Trim() + "'");
            }
            DataTable dt = TH.BaseClass.DbHelperSQL.Query(sSQL);
            gridControl1.DataSource = dt;

        }

        private void GetLookUp()
        {
            string sSQL = "select cInvCode,cInvName,cInvStd,cCurrencyName from Inventory order by cInvCode";
            DataTable dt =TH.BaseClass.DbHelperSQL.Query(sSQL);
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);

            lookUpEditcInvName.Properties.DataSource = dt;
            lookUpEditcInvStd.Properties.DataSource = dt;
            lookUpEditcCurrencyName.Properties.DataSource = dt;
            ItemLookUpEditcCurrencyName.DataSource = dt;
            ItemLookUpEditcInvCode.DataSource = dt;
            ItemLookUpEditcInvName.DataSource = dt;
            ItemLookUpEditcInvStd.DataSource = dt;


            sSQL = "select cDepCode,cDepName from Department where isnull(bDepEnd ,0) <> 0 order by cDepCode";
            dt = TH.BaseClass.DbHelperSQL.Query(sSQL); 
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditcDepName.Properties.DataSource = dt;
            lookUpEditcDepCode.Properties.DataSource = dt;
            ItemLookUpEditcDepCode.DataSource = dt;
            ItemLookUpEditcDepName.DataSource = dt;

            sSQL = "select distinct ����ڼ� from  _ProMaterial order by ����ڼ�";
            dt = TH.BaseClass.DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEdit����ڼ�.Properties.DataSource = dt;
            lookUpEdit����ڼ�.EditValue = DateTime.Today.ToString("yyyy-MM");

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

        private void lookUpEditcDepCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEditcDepName.EditValue = lookUpEditcDepCode.EditValue;
            }
            catch { }
        }

        private void lookUpEditcDepName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEditcDepCode.EditValue = lookUpEditcDepName.EditValue;
            }
            catch { }
        }

        private void lookUpEditcInvName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEditcInvStd.EditValue = lookUpEditcInvName.EditValue;
                lookUpEditcCurrencyName.EditValue = lookUpEditcInvName.EditValue;
                btnTxtInvCode.Text = lookUpEditcCurrencyName.EditValue.ToString().Trim();
            }
            catch { }
        }

        private void lookUpEditcInvStd_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEditcInvName.EditValue = lookUpEditcInvStd.EditValue;
                lookUpEditcCurrencyName.EditValue = lookUpEditcInvStd.EditValue;
                btnTxtInvCode.Text = lookUpEditcCurrencyName.EditValue.ToString().Trim();
            }
            catch { }
        }

        private void lookUpEditcCurrencyName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEditcInvName.EditValue = lookUpEditcCurrencyName.EditValue;
                lookUpEditcInvStd.EditValue = lookUpEditcCurrencyName.EditValue;
                btnTxtInvCode.Text = lookUpEditcCurrencyName.EditValue.ToString().Trim();
            }
            catch { }
        }

        private void btnTxtInvCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                string sInvCode = btnTxtInvCode.Text.Trim();

                FrmInvInfo frm = new FrmInvInfo(sInvCode, false);
                DialogResult d = frm.ShowDialog();
                if (d == DialogResult.OK)
                {
                    btnTxtInvCode.Text = frm.sInvCode;
                    lookUpEditcInvName.EditValue = frm.sInvCode;
                }
                else
                {
                    btnTxtInvCode.Text = "";
                    lookUpEditcInvName.EditValue = DBNull.Value;
                }
            }
            catch(Exception ee)
            {
                MessageBox.Show("���ش������ʧ��:" + ee.Message);
            }
        }

        private void btnTxtInvCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (btnTxtInvCode.Text.Trim() != "")
                {
                    lookUpEditcInvName.EditValue = btnTxtInvCode.Text.Trim();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}