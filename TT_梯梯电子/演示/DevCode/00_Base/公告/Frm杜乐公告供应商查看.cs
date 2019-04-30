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
    public partial class Frm���ֹ��湩Ӧ�̲鿴 : FrameBaseFunction.Frm�б���ģ��
    {
        DataTable dtSel = new DataTable();
        int iPage = 0;
        ArrayList aList;
        string sSQL;

        public Frm���ֹ��湩Ӧ�̲鿴()
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
                    case "save":
                        btnAudit();
                        break;
                    case "unaudit":
                        btnUnAudit();
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

        private void btnAdd()
        {
            Frm���ֹ���Edit f = new Frm���ֹ���Edit();
            f.ShowDialog();

            btnSel();
        }

        private void btnSel()
        {
            if (!b��Ӧ��)
                throw new Exception("���趨��Ӧ��");

            chkȫѡ.Checked = false;

            int iFoc = 0;
            if (gridView1.FocusedRowHandle > 0)
                iFoc = gridView1.FocusedRowHandle;

            string sSQL = @"
select cast(0 as bit) as ѡ��, *
from UFDLImport..���ֹ��� a inner join UFDLImport..���ֹ�����ϸ b on a.guid = b.guid
where 1=1 and ��Ӧ�̱��� = '111111' and isnull(a.������,'') <> ''
order by a.iID
";
            sSQL = sSQL.Replace("111111", l��Ӧ�̱���.Text.Trim());
            if (radioδ����.Checked)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and isnull(�Ķ���,'') = ''");
            }

            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            gridControl1.DataSource = dt;
            gridView1.FocusedRowHandle = iFoc;

        }

        private void btnUnAudit()
        {
          
        }

        private void btnAudit()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }
            aList = new ArrayList();
            string sErr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridCol�Ķ���).ToString().Trim() != "")
                {
                    sErr = sErr + "��" + (i + 1).ToString() + "�Ѿ�����\n";
                    continue;
                }

                string sSQL = "update UFDLImport..���ֹ�����ϸ set �Ķ��� = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "',�Ķ����� = getdate() where guid = '" + gridView1.GetRowCellValue(i, gridColGUID).ToString().Trim() + "' and ��Ӧ�̱��� = '" + l��Ӧ�̱���.Text.Trim() + "'";
                aList.Add(sSQL);
            }
            if (sErr != "")
            {
                throw new Exception(sErr);
            }

            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("����ɹ�");
                btnSel();
            }
            else
            {
                MessageBox.Show("û��ѡ����Ҫ���������");
            }
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




        bool b��Ӧ�� = false;

        private void Frm���ֹ��湩Ӧ�̲鿴_Load(object sender, EventArgs e)
        {
            try
            {
                date1.Enabled = true;
                date2.Enabled = true;
                date1.Properties.ReadOnly = false;
                date2.Properties.ReadOnly = false;


                string sSQL = "select vendCode,cVenName from UFDLImport.._vendUid inner join @u8.Vendor on @u8.Vendor.cVenCode = vendCode where uid = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "'  and accid = 200 and accyear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + " ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    b��Ӧ�� = false;
                }
                else
                {
                    b��Ӧ�� = true;
                    l��Ӧ�̱���.Text = dt.Rows[0]["vendcode"].ToString().Trim();
                }

                date1.DateTime = DateTime.Today.AddMonths(-1);
                date2.DateTime = DateTime.Today;

                btnSel();

            }
            catch (Exception ee)
            {
                MessageBox.Show("���ش���ʧ��\n" + ee.Message);
            }
        }

        private void gridView����_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void chkȫѡ_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridColѡ��, chkȫѡ.Checked);
                }
            }
            catch (Exception ee)
            { 
                
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
                    Frm���ֹ��湩Ӧ�̲鿴Edit f = new Frm���ֹ��湩Ӧ�̲鿴Edit(sGuid, l��Ӧ�̱���.Text.Trim());
                    f.ShowDialog();

                    sSQL = "update UFDLImport..���ֹ�����ϸ set �Ķ��� = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "' , �Ķ����� = getdate() where guid = '" + sGuid + "' and ��Ӧ�̱��� = '" + l��Ӧ�̱���.Text.Trim() + "'";
                    clsSQLCommond.ExecSql(sSQL);

                    btnSel();
                }
            }
            catch { }
        }

        private void radioδ����_Click(object sender, EventArgs e)
        {
            btnSel();
        }
    }
}