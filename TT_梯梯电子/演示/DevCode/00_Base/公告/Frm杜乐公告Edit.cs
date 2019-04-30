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
    public partial class Frm���ֹ���Edit : Form
    {
        FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
        FrameBaseFunction.ClsGetSQL clsGetSQL = FrameBaseFunction.ClsGetSQL.Instance();

        string sGuid = "";
        public Frm���ֹ���Edit()
        {
            InitializeComponent();
        }
        string sType = "";
        public Frm���ֹ���Edit(string s)
        {
            InitializeComponent();

            sGuid = s;
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

        private void SetValue()
        {
            string sSQL = @"
select cast(0 as bit) as ѡ��, cVenCode as ��Ӧ�̱���,cVenName as ��Ӧ������ 
from @u8.Vendor  
where 1=1
order by cVenCode";

            if (radio�ɹ�.Checked)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and cVenDepart = '4'");
            }
            if (radioί��.Checked)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and cVenDepart = '905'");
            }
            if (radioδ����.Checked)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and isnull(cVenDepart,'') = ''");
            }
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;

            sSQL = @"
select * 
from UFDLImport..���ֹ��� a inner join UFDLImport..���ֹ�����ϸ b on a.GUID = b.GUID 
where a.GUID = '111111'
";
            sSQL = sSQL.Replace("111111", sGuid);
            dt = clsSQLCommond.ExecQuery(sSQL);

            txt����.Text = dt.Rows[0]["����"].ToString().Trim();
            richTextBox����.Text = dt.Rows[0]["����"].ToString().Trim();
            txt�Ƶ���.Text = dt.Rows[0]["�Ƶ���"].ToString().Trim();
            date�Ƶ�����.Text = dt.Rows[0]["�Ƶ�����"].ToString().Trim();
            txt������.Text = dt.Rows[0]["������"].ToString().Trim();
            date_��������.Text = dt.Rows[0]["��������"].ToString().Trim();

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string s��Ӧ�̱��� = gridView1.GetRowCellValue(i, gridCol��Ӧ�̱���).ToString().Trim();
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    string s��Ӧ�̱���2 = dt.Rows[j]["��Ӧ�̱���"].ToString().Trim();

                    if (s��Ӧ�̱��� == s��Ӧ�̱���2)
                    {
                        gridView1.SetRowCellValue(i, gridColѡ��, true);
                        break;
                    }
                }
            }
        }

        private void SetNull()
        {
            radioȫ��.Checked = true;
            txt����.Text = "";
            richTextBox����.Text = "";
            date�Ƶ�����.Text = "";
            date_��������.Text = "";

            string sSQL = "select cast(0 as bit) as ѡ��, cVenCode as ��Ӧ�̱���,cVenName as ��Ӧ������ from @u8.Vendor  order by cVenCode";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;
            txt����.Focus();
        }

        private void Frm���ֹ���Edit_Load(object sender, EventArgs e)
        {
            try
            {
                if (sGuid == "")
                {
                    SetNull();
                }
                else
                {
                    SetValue();
                }
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

        private void btn����_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                if (txt����.Text.Trim() == "")
                {
                    txt����.Focus();
                    throw new Exception("���ⲻ��Ϊ��");
                }
                if (richTextBox����.Text.Trim() == "")
                {
                    richTextBox����.Focus();
                    throw new Exception("���ݲ���Ϊ��");
                }
                if (sGuid == "")
                {
                    sGuid = Guid.NewGuid().ToString();
                }

                string sSQL = "select count(1) from UFDLImport..���ֹ��� where guid = '" + sGuid + "' and isnull(������,'') <> ''";
                int iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                if (iCou > 0)
                    throw new Exception("�Ѿ����������޸�");

                ArrayList aList = new ArrayList();
                sSQL = "delete UFDLImport..���ֹ�����ϸ where guid = '" + sGuid + "'";
                aList.Add(sSQL);

                bool b = false;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridColѡ��)))
                    {
                        sSQL = "insert into UFDLImport..���ֹ�����ϸ(��Ӧ�̱���,guid)values('" + gridView1.GetRowCellValue(i, gridCol��Ӧ�̱���).ToString().Trim() + "','" + sGuid + "')";
                        aList.Add(sSQL);
                        b = true;
                    }
                }

                if(!b)
                {
                    throw new Exception("��ѡ��Ӧ��");
                }

                sSQL = "select count(1) from UFDLImport..���ֹ��� where guid = '" + sGuid + "'";
                iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                if (iCou == 0)
                {
                    sSQL = "insert into UFDLImport..���ֹ���(����,����,�Ƶ���,�Ƶ�����,guid)values('" + txt����.Text.Trim() + "','" + richTextBox����.Text.Trim() + "','" + FrameBaseFunction.ClsBaseDataInfo.sUid + "','" + DateTime.Today.ToString("yyyy-MM-dd") + "','" + sGuid + "')";
                    aList.Add(sSQL);
                }
                else
                {
                    sSQL = "update UFDLImport..���ֹ��� set ���� = '" + txt����.Text.Trim() + "',���� = '" + richTextBox����.Text.Trim() + "',�Ƶ��� = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "',�Ƶ����� = '" + DateTime.Today.ToString("yyyy-MM-dd") + "' where guid = '" + sGuid + "'";
                    aList.Add(sSQL);
                }

                if (aList.Count > 1)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("����ɹ�");

                    txt�Ƶ���.Text = FrameBaseFunction.ClsBaseDataInfo.sUid;
                    date�Ƶ�����.Text = DateTime.Today.ToString("yyyy-MM-dd");
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnɾ��_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                string sSQL = "select count(1) from UFDLImport..���ֹ��� where guid = '" + sGuid + "' and isnull(������,'') <> ''";
                int iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                if (iCou > 0)
                    throw new Exception("�Ѿ���������ɾ��");

                ArrayList aList = new ArrayList();
                sSQL = "delete UFDLImport..���ֹ�����ϸ where guid = '" + sGuid + "'";
                aList.Add(sSQL);
                sSQL = "delete UFDLImport..���ֹ��� where guid = '" + sGuid + "'";
                aList.Add(sSQL);
                clsSQLCommond.ExecSqlTran(aList);

                MessageBox.Show("ɾ���ɹ�");

                this.DialogResult = DialogResult.Yes;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btn����_Click(object sender, EventArgs e)
        {
            try
            {

                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                if (txt������.Text.Trim() != "")
                {
                    MessageBox.Show("�Ѿ�����");
                    return;
                }

                btn����_Click(null, null);
                string sSQL = "update UFDLImport..���ֹ��� set ������ = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "',�������� = '" + DateTime.Today.ToString("yyyy-MM-dd") + "' where guid = '" + sGuid + "'";

                clsSQLCommond.ExecSql(sSQL);
                MessageBox.Show("�����ɹ�");

                txt������.Text = FrameBaseFunction.ClsBaseDataInfo.sUid;
                date_��������.Text = DateTime.Today.ToString("yyyy-MM-dd");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnȡ��_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                if (txt�Ƶ���.Text.Trim() == "")
                {
                    MessageBox.Show("��δ����");
                    return;
                }

                if (txt������.Text.Trim() == "")
                {
                    MessageBox.Show("��δ����");
                    return;
                }

                string sSQL = "update UFDLImport..���ֹ��� set ������ = null,�������� = null where guid = '" + sGuid + "'";

                clsSQLCommond.ExecSql(sSQL);
                MessageBox.Show("ȡ�������ɹ�");

                txt������.Text = "";
                date_��������.Text = "";
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btn�˳�_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }


        private void radio��Ӧ��_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                string sSQL = @"
select cast(0 as bit) as ѡ��, cVenCode as ��Ӧ�̱���,cVenName as ��Ӧ������ 
from @u8.Vendor  
where 1=1
order by cVenCode";

                if (radio�ɹ�.Checked)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and cVenDepart = '4'");
                }
                if (radioί��.Checked)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and cVenDepart = '905'");
                }
                if (radioδ����.Checked)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(cVenDepart,'') = ''");
                }
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                gridControl1.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show("���ع�Ӧ��ʧ��\n" + ee.Message);
            }
        }

    }
}