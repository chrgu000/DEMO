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
    public partial class Frmѯ�۵����۹����ڲ� : FrameBaseFunction.Frm�б���ģ��
    {
        string sGuid = "";
        string sDepCode = "";

        public Frmѯ�۵����۹����ڲ�(string s_Guid,string s_DepCode)
        {
            InitializeComponent();

            sGuid = s_Guid;
            sDepCode = s_DepCode;
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


        private void SetLookup()
        {
            string sSQL = "select cDepCode,cDepName from @u8.Department order by cDepCode";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            lookUpEditcDepCode.Properties.DataSource = dt;
            lookUpEditcDepCode.EditValue = sDepCode;
        }


        private void btnSel()
        {
            string sSQL = @"
if exists (select * from tempdb.dbo.sysobjects where id = object_id(N'tempdb..#a') and type='U')
	drop table #a

select distinct a.����, CONVERT(varchar, a.��������, 120) AS �������� , CONVERT(varchar, a.��ֹ����, 120) AS ��ֹ����,CONVERT(varchar, a.��ֹѯ������, 120) AS ��ֹѯ������
	,c.�Զ�������,c.���ϱ���,d.cInvName as ��������,d.cInvStd as ����ͺ�
	,CAST(null as decimal(16,2)) as ��ͼ�,CAST(null as decimal(16,2)) as ��߼�,CAST(null as decimal(16,2)) as ¼�ü�
	,c.GUID����,a.[GUID],c.��ע1
into #a
from UFDLImport..ѯ�۵� a inner join UFDLImport..ѯ�۵���Ӧ�� b on a.[GUID] = b.[GUID]
	inner join UFDLImport..ѯ�۵������б� c on a.[GUID] = c.[GUID] and b.[GUID] = c.[GUID]
	inner join @u8.Inventory d on c.���ϱ��� = d. cInvCode
where a.[GUID] = '111111'


update #a set ��ͼ� = a.��ͼ�
from
(
	select [GUID],[GUID����],min(����) as ��ͼ�
	from UFDLImport..ѯ�۵���Ӧ�̱���
	where [GUID] = '111111'
		and ISNULL(����,0) <> 0
	group by [GUID],[GUID����]
)a
where a.GUID = #a.GUID and a.GUID���� = #a.GUID����

update #a set ��߼� = a.��߼�
from
(
	select [GUID],[GUID����],max(����) as ��߼�
	from UFDLImport..ѯ�۵���Ӧ�̱���
	where [GUID] = '111111'
	group by [GUID],[GUID����]
)a
where a.GUID = #a.GUID and a.GUID���� = #a.GUID����

update #a set ¼�ü� = a.¼�ü�
from
(
	select a.[GUID],a.[GUID����],max(a.����) as ¼�ü�
	from UFDLImport..ѯ�۵���Ӧ�̱��� a inner join UFDLImport..ѯ�۵���Ӧ�� b on a.[GUID] = b.[guid]
	where a.[GUID] = '111111'
		and a.�������� = 'ͨ��'
group by a.[GUID],a.[GUID����]
)a
where a.GUID = #a.GUID and a.GUID���� = #a.GUID����

select * from #a 

if exists (select * from tempdb.dbo.sysobjects where id = object_id(N'tempdb..#a') and type='U')
	drop table #a
";
            sSQL = sSQL.Replace("111111", sGuid);
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;

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






        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookup();
                lookUpEditcDepCode.EditValue = sDepCode;
                if (lookUpEditcDepCode.Text.Trim() == "")
                {
                    MessageBox.Show("��ò�����Ϣʧ��");
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

    }
}