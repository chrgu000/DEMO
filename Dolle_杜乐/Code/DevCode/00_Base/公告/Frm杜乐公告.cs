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
    public partial class Frm���ֹ��� : FrameBaseFunction.Frm�б���ģ��
    {
        DataTable dtSel = new DataTable();
        int iPage = 0;
        ArrayList aList;
        string sSQL;

        public Frm���ֹ���()
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
                    case "add":
                        btnAdd();
                        break;
                    case "del":
                        btnDel();
                        break;
                    case "audit":
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
            chkȫѡ.Checked = false;

            int iFoc = 0;
            if (gridView1.FocusedRowHandle > 0)
                iFoc = gridView1.FocusedRowHandle;

            string sSQL = @"
select cast(0 as bit) as ѡ��, *,cast(null as varchar(8000)) as ��Ӧ�̱���,cast(null as varchar(8000)) as ��Ӧ������ 
from UFDLImport..���ֹ��� a
where 1=1 
order by a.iID
";
            if (date1.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and �Ƶ����� >= '" + date1.DateTime.ToString("yyyy-MM-dd") + "' ");
            }
            if (date2.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and �Ƶ����� <= '" + date2.DateTime.ToString("yyyy-MM-dd") + "' ");
            }
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sSQL = "select *,b.cVenName as ��Ӧ������ from UFDLImport..���ֹ�����ϸ a inner join @u8.vendor b on a.��Ӧ�̱��� = b.cVenCode where guid = '" + dt.Rows[i]["guid"].ToString().Trim() + "' order by a.iID";
                DataTable dtGrid = clsSQLCommond.ExecQuery(sSQL);
                string s��Ӧ�̱��� = "";
                string s��Ӧ������ = "";
                for (int j = 0; j < dtGrid.Rows.Count; j++)
                {
                    if (s��Ӧ�̱��� == "")
                    {
                        s��Ӧ�̱��� = dtGrid.Rows[j]["��Ӧ�̱���"].ToString().Trim();
                        s��Ӧ������ = dtGrid.Rows[j]["��Ӧ������"].ToString().Trim();
                    }
                    else
                    {
                        s��Ӧ�̱��� = s��Ӧ�̱��� + "," + dtGrid.Rows[j]["��Ӧ�̱���"].ToString().Trim();
                        s��Ӧ������ = s��Ӧ������ + "," + dtGrid.Rows[j]["��Ӧ������"].ToString().Trim();
                    }
                }
                dt.Rows[i]["��Ӧ�̱���"] = s��Ӧ�̱���;
                dt.Rows[i]["��Ӧ������"] = s��Ӧ������;
            }
            gridControl1.DataSource = dt;
            gridView1.FocusedRowHandle = iFoc;

        }

        private void btnUnAudit()
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
                bool bChoose = ReturnObjectToBool(gridView1.GetRowCellValue(i, gridColѡ��));
                if (!bChoose)
                    continue;

                if (gridView1.GetRowCellValue(i, gridCol������).ToString().Trim() == "")
                {
                    sErr = sErr + "��" + (i + 1).ToString() + "��δ����\n";
                    continue;
                }

                string sSQL = "update UFDLImport..���ֹ��� set ������ = null,�������� = null where guid = '" + gridView1.GetRowCellValue(i, gridColGUID).ToString().Trim() + "'";
                aList.Add(sSQL);
            }
            if (sErr != "")
            {
                throw new Exception(sErr);
            }

            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("ȡ�������ɹ�");
                btnSel();
            }
            else
            {
                MessageBox.Show("û��ѡ����Ҫ����������");
            }
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
                bool bChoose = ReturnObjectToBool(gridView1.GetRowCellValue(i, gridColѡ��));
                if (!bChoose)
                    continue;

                if (gridView1.GetRowCellValue(i, gridCol������).ToString().Trim() != "")
                {
                    sErr = sErr + "��" + (i + 1).ToString() + "�Ѿ�����\n";
                    continue;
                }

                string sSQL = "update UFDLImport..���ֹ��� set ������ = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "',�������� = getdate() where guid = '" + gridView1.GetRowCellValue(i, gridColGUID).ToString().Trim() + "'";
                aList.Add(sSQL);
            }
            if (sErr != "")
            {
                throw new Exception(sErr);
            }

            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("�����ɹ�");
                btnSel();
            }
            else
            {
                MessageBox.Show("û��ѡ����Ҫ����������");
            }
        }

        private void btnDel()
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
                if (!Convert.ToBoolean(gridView1.GetRowCellValue(i, gridColѡ��)))
                {
                    continue;
                }

                if (gridView1.GetRowCellValue(i, gridCol������).ToString().Trim() != "")
                {
                    sErr = sErr + "��" + (i + 1).ToString() + "�Ѿ�����\n";
                    continue;
                }

                string sSQL = "delete UFDLImport..���ֹ�����ϸ where guid = '" + gridView1.GetRowCellValue(i, gridColGUID).ToString().Trim() + "'";
                aList.Add(sSQL);
                sSQL = "delete UFDLImport..���ֹ��� where guid = '" + gridView1.GetRowCellValue(i, gridColGUID).ToString().Trim() + "'";
                aList.Add(sSQL);
            }
            if (sErr != "")
            {
                throw new Exception(sErr);
            }

            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("ɾ���ɹ�");
                btnSel();
            }
            else
            {
                MessageBox.Show("û��ѡ����Ҫ����������");
            }
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






        private void Frm���ֹ���_Load(object sender, EventArgs e)
        {
            try
            {
                date1.DateTime = DateTime.Today.AddMonths(-1);
                date2.DateTime = DateTime.Today;

                date1.Enabled = true;
                date1.Properties.ReadOnly = false;

                date2.Enabled = true;
                date2.Properties.ReadOnly = false;
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
                    Frm���ֹ���Edit f = new Frm���ֹ���Edit(sGuid);
                    f.ShowDialog();

                    btnSel();
                }
            }
            catch { }
        }
    }
}