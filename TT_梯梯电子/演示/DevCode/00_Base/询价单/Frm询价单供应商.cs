using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FrameBaseFunction;

namespace Base
{
    public partial class Frmѯ�۵���Ӧ�� : FrameBaseFunction.Frm�б���ģ��
    {  
        DataTable dtSel = new DataTable();
        int iPage = 0;
        ArrayList aList;
        string sSQL;

        public Frmѯ�۵���Ӧ��()
        {
            InitializeComponent();
        }

        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {

                    case "sel":
                        btnSel();
                        break;
                  
                    default:
                        break;
                }

                sState = sBtnName.ToLower();
            }
            catch (Exception ee)
            {
                throw new Exception(sBtnText + " ʧ��! \n\nԭ��:\n  " + ee.Message);
            }
        }

        private void btnSel()
        {
            int iFoc = 0;
            if (gridView1.FocusedRowHandle > 0)
                iFoc = gridView1.FocusedRowHandle;

            if (lookUpEditcVenCode.Text.Trim() == "")
            {
                throw new Exception("��Ӧ�����ô���");
            }

            string sSQL = @"
select cast(0 as bit) as ѡ��
    , a.iID, a.��������, a.�Ƶ���, a.�Ƶ�����, a.������, a.��������, a.����, a.��ע,  a.GUID
    ,b.��Ӧ�̱���,c.cVenName as ��Ӧ������
    , CONVERT(varchar, ��ֹ����, 120) AS ��ֹ����
    , CONVERT(varchar, ��ֹѯ������, 120) as ��ֹѯ������, ��ֹ��
from UFDLImport..ѯ�۵� a inner join UFDLImport..ѯ�۵���Ӧ�� b on a.GUID = b.GUID
	inner join @u8.Vendor c on b.��Ӧ�̱��� = c.cVenCode
where 1=1 and b.��Ӧ�̱��� = '1111'
    and isnull(a.������,'') <> ''
order by a.iID
";
            sSQL = sSQL.Replace("1111", lookUpEditcVenCode.EditValue.ToString().Trim());
            if (date1.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and �������� >= '" + date1.DateTime.ToString("yyyy-MM-dd") + "' ");
            }
            if (date2.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and �������� <= '" + date2.DateTime.ToString("yyyy-MM-dd") + "' ");
            }
            if (radioδ����.Checked)
            {
                sSQL = sSQL.Replace("1=1", "1=1  and a.[GUID] not in (select [guid] from UFDLImport..ѯ�۵���Ӧ�̱��� where ��Ӧ�̱��� = '" + lookUpEditcVenCode.EditValue.ToString().Trim() + "') ");
            }
            if (radio�ѱ���.Checked)
            {
                sSQL = sSQL.Replace("1=1", "1=1  and a.[GUID] in (select [guid] from UFDLImport..ѯ�۵���Ӧ�̱��� where ��Ӧ�̱��� = '" + lookUpEditcVenCode.EditValue.ToString().Trim() + "' and  isnull(������,'') = '')  ");
            }
            if (radio������.Checked)
            {
                sSQL = sSQL.Replace("1=1", "1=1  and a.[GUID] in (select [guid] from UFDLImport..ѯ�۵���Ӧ�̱��� where ��Ӧ�̱��� = '" + lookUpEditcVenCode.EditValue.ToString().Trim() + "' and  isnull(������,'') <> '')  ");
            }

            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;
            gridView1.FocusedRowHandle = iFoc;

        }

        private void btnSave()
        {
            throw new NotImplementedException();
        }

        #region ��ťģ��

      
        /// <summary>
        /// ���
        /// </summary>
        private void btnExport()
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
                sF.Filter = "Excel�ļ�(*.xls)|*.xls|�����ļ�(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridView1.ExportToXls(sF.FileName);
                    MessageBox.Show("����Excel�ɹ�\n\t·����" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

      
        #endregion


        private void SetLookup()
        {
            string sSQL = "select cVenCode,cVenName from @u8.Vendor order by cVenCode";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            lookUpEditcVenCode.Properties.DataSource = dt;

            sSQL = "select  vchrUid, vchrName from _UserInfo order by vchrUid";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEditUser.DataSource = dt;
        }



        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                string sUid = FrameBaseFunction.ClsBaseDataInfo.sUid;
                string s1 = sUid.Substring(0, 1);
                if (s1.ToLower() != "d")
                {
                   MessageBox.Show("��ù�Ӧ����Ϣʧ��");
                   return;
                }

                date1.DateTime = DateTime.Today.AddMonths(-1);
                date2.DateTime = DateTime.Today;

                date1.Enabled = true;
                date1.Properties.ReadOnly = false;

                date2.Enabled = true;
                date2.Properties.ReadOnly = false;

                SetLookup();


                string s2 = sUid.Substring(1);
                lookUpEditcVenCode.EditValue = s2;
                if (lookUpEditcVenCode.Text.Trim() == "")
                {
                    MessageBox.Show("��ù�Ӧ����Ϣʧ��");
                    this.Close();
                    return;
                }

                btnSel();
            }
            catch (Exception ee)
            {
                MessageBox.Show("���ش���ʧ��\n" + ee.Message);
            }
        }

        private void gridView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView1.FocusedRowHandle > 0)
                    iRow = gridView1.FocusedRowHandle;

                string sGuid = gridView1.GetRowCellValue(iRow, gridColGUID).ToString().Trim();
                if (sGuid != "")
                {
                    Frmѯ�۵���Ӧ��Edit f = new Frmѯ�۵���Ӧ��Edit(sGuid, lookUpEditcVenCode.EditValue.ToString().Trim());
                    f.ShowDialog();

                    btnSel();
                }
            }
            catch { }
        }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                btnSel();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}