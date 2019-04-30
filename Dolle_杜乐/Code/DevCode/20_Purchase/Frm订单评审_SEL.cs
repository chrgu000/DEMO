using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FrameBaseFunction;

namespace Purchase
{
    public partial class Frm��������_SEL : Form
    {
        FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
        FrameBaseFunction.ClsGetSQL clsGetSQL = FrameBaseFunction.ClsGetSQL.Instance();

        public long i���۶���ID = 0;
        int iType = 0;

        public Frm��������_SEL(int i)
        {
            InitializeComponent();

            iType = i;
        }
        public DataTable dtOM;

        private void Frm��������_SEL_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            dtm��������1.Text = Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyy-MM-01");
            dtm��������2.Text = DateTime.Parse(Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyy-MM-01")).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");

            GetLookUp();
        }

        private void btnSEL_Click(object sender, EventArgs e)
        {
            string sSQL = "select *,cast(null as varchar(50)) as �ɹ�����,cast(null as varchar(50)) as ���� from XWSystemDB_DL..������������1 where ���׺� = '" + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim() + "' and isnull(�����,'') <> '' and isnull(�ر���,'') = '' ";

            if (dtm��������1.Text.Trim() != "")
            {
                sSQL = sSQL + " and �Ƶ����� >= '" + dtm��������1.DateTime.ToString("yyyy-MM-dd") + "' ";
            }
            if (dtm��������2.Text.Trim() != "")
            {
                sSQL = sSQL + " and �Ƶ����� < '" + dtm��������2.DateTime.AddDays(1).ToString("yyyy-MM-dd") + "' ";
            }
            if (lookUpEdit���۶�����1.Text.Trim() != "")
            {
                sSQL = sSQL + " and ���۶����� >= '" + lookUpEdit���۶�����1.EditValue + "' ";
            }
            if (lookUpEdit���۶�����2.Text.Trim() != "")
            {
                sSQL = sSQL + " and ���۶����� <= '" + lookUpEdit���۶�����2.EditValue + "' ";
            }
            if (lookUpEdit����������1.Text.Trim() != "")
            {
                sSQL = sSQL + " and ���������� >= '" + lookUpEdit����������1.EditValue + "' ";
            }
            if (lookUpEdit����������2.Text.Trim() != "")
            {
                sSQL = sSQL + " and ���������� <= '" + lookUpEdit����������2.EditValue + "' ";
            }

            if (lookUpEdit�ͻ�������1.Text.Trim() != "")
            {
                sSQL = sSQL + " and �ͻ������� >= '" + lookUpEdit�ͻ�������1.EditValue + "' ";
            }
            if (lookUpEdit�ͻ�������2.Text.Trim() != "")
            {
                sSQL = sSQL + " and �ͻ������� <= '" + lookUpEdit�ͻ�������2.EditValue + "' ";
            }
            //if (radioδ�´�.Checked)
            //{
            //    sSQL = sSQL + " and isnull(�´���,'') = '' ";
            //}
            //if (radio���´�.Checked)
            //{
            //    sSQL = sSQL + " and isnull(�´���,'') <> '' ";
            //}
            //�ɹ�����
            if (iType == 1)
            {
                sSQL = sSQL + " and isnull(�´��빺��,'') <> '' ";
            }
            //ί������
            if (iType == 2)
            {
                sSQL = sSQL + "  and isnull(�´�ί����,'') = '' ";
            }
            //��������
            if (iType == 3)
            {
                sSQL = sSQL + "   and isnull(�´�������,'') = '' ";
            }
            //�´�ɹ��ƻ�
            if (iType == 11)
            {
                sSQL = sSQL + " and isnull(�´��빺��,'') = '' ";
            }
            //�´�ί��ƻ�
            if (iType == 12)
            {
                sSQL = sSQL + " and isnull(ά�������,'') <> '' ";
            }
            //�´������ƻ�
            if (iType == 13)
            {
                sSQL = sSQL + " and isnull(ά�������,'') <> '' ";
            }
            //��������ά��
            if (iType == 4)
            {
                sSQL = sSQL + "  ";
            }

            if (radioδ����.Checked)
            {
                string s�Ӽ����� = "";
                if (iType == 1)
                {
                    s�Ӽ����� = "�ɹ�";
                }
                if (iType == 2)
                {
                    s�Ӽ����� = "ί��";
                }
                if (iType == 2)
                {
                    s�Ӽ����� = "����";
                }

                sSQL = sSQL + " and ���۶���ID in (select ���۶���ID from XWSystemDB_DL..������������3 where ���׺� = '" + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim() + "' and isnull(��ǩ��,'') = '' and �Ӽ����� = '" + s�Ӽ����� + "' and isnull(�����µ�����,0) <> 0) ";
            }


            sSQL = sSQL + " order by ���۶�����";

            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                string s��ǩ�� = "";
                string s������ = "";
                string s���۶���ID = dt.Rows[i]["���۶���ID"].ToString().Trim();
                sSQL = "select distinct ��ǩ��,������ from XWSystemDB_DL..������������3 where �Ӽ����� = '�ɹ�' and ���׺� = '" + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim() + "' and ���۶���ID = " + dt.Rows[i]["���۶���ID"];
                DataTable dtTemp = clsSQLCommond.ExecQuery(sSQL);
                for (int j = 0; j < dtTemp.Rows.Count; j++)
                {
                    if (dtTemp.Rows[j]["��ǩ��"].ToString().Trim() != "")
                    {
                        s��ǩ�� = s��ǩ�� + dtTemp.Rows[j]["��ǩ��"].ToString().Trim();
                    }
                    if (dtTemp.Rows[j]["������"].ToString().Trim() != "")
                    {
                        s������ = s������ + dtTemp.Rows[j]["������"].ToString().Trim();
                    }
                }
                dt.Rows[i]["�ɹ�����"] = s��ǩ��;
                dt.Rows[i]["����"] = s������;

            }

            gridControl1.DataSource = dt;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.RowCount < 1)
                {
                    throw new Exception("û������");
                }

                i���۶���ID = Convert.ToInt64(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridCol���۶���ID));

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ee)
            {
                MessageBox.Show("��ѯʧ��:" + ee.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void GetLookUp()
        {
            try
            {
                string sSQL = "select cCusCode,cCusName,cCusAbbName from @u8.Customer order by cCusCode";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                ItemLookUpEdit�ͻ�����.DataSource = dt;
                ItemLookUpEdit�ͻ����.DataSource = dt;

                sSQL = "SELECT distinct cSOCode as iID from @u8.SO_SOMain where isnull(cCloser,'') = '' and isnull(cVerifier,'') <> '' and cSOCode not in (select ���۶����� from XWSystemDB_DL.dbo.���������ͷ) order by cSOCode";
                dt = clsGetSQL.GetLookUpEdit(sSQL);
                lookUpEdit���۶�����1.Properties.DataSource = dt;
                lookUpEdit���۶�����2.Properties.DataSource = dt;

                sSQL = "SELECT distinct cDefine11 as iID from @u8.SO_SOMain where isnull(cCloser,'') = '' and isnull(cVerifier,'') <> '' and cSOCode not in (select ���۶����� from XWSystemDB_DL.dbo.���������ͷ) order by cDefine11";
                dt = clsGetSQL.GetLookUpEdit(sSQL);
                lookUpEdit����������1.Properties.DataSource = dt;
                lookUpEdit����������2.Properties.DataSource = dt;

                sSQL = "SELECT distinct cDefine2 as iID from @u8.SO_SOMain where isnull(cCloser,'') = '' and isnull(cVerifier,'') <> '' and cSOCode not in (select ���۶����� from XWSystemDB_DL.dbo.���������ͷ) order by cDefine2";
                //dt = clsGetSQL.GetLookUpEdit(sSQL);
                dt = clsSQLCommond.ExecQuery(sSQL);
                lookUpEdit�ͻ�������1.Properties.DataSource = dt;
                lookUpEdit�ͻ�������2.Properties.DataSource = dt;

                sSQL = "select cDepCode ,cDepName from @u8.Department where bDepEnd = 1 order by cDepCode ";
                dt = clsSQLCommond.ExecQuery(sSQL);
                lookUpEdit����.Properties.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("��ò�����Ϣʧ��!");
            }
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