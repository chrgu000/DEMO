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
    public partial class Frmѯ�۵� : FrameBaseFunction.Frm�б���ģ��
    {  
        DataTable dtSel = new DataTable();
        int iPage = 0;
        ArrayList aList;
        string sSQL;

        public Frmѯ�۵�()
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
                    case "save":
                        btnAudit();
                        break;
                    case "undo":
                        btnUnAudit();
                        break;
                    case "lock":
                        btnstopX();
                        break;
                    case "unlock":
                        btnselX();
                        break;
                    case "audit":
                        btnselAll();
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

        private void btnselAll()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            int iFocRow = -1;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridColѡ��)))
                {
                    iFocRow = i;
                    break;
                }
            }

            if (iFocRow == -1)
            {
                throw new Exception("��ѡ�񵥾�");
            }

            string sGuid = gridView1.GetRowCellValue(iFocRow, gridColGUID).ToString().Trim();
            Frmѯ�۵����۹����ڲ� f = new Frmѯ�۵����۹����ڲ�(sGuid, lookUpEditcDepCode.EditValue.ToString());
            f.WindowState = FormWindowState.Normal;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
        }

        private void btnselX()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            int iFocRow = -1;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridColѡ��)))
                {
                    iFocRow = i;
                    break;
                }
            }
            if (iFocRow == -1)
            {
                throw new Exception("��ѡ�񵥾�");
            }

            string sGuid = gridView1.GetRowCellValue(iFocRow, gridColGUID).ToString().Trim();
            string sSQL = "select *,getdate() as ��ǰʱ�� from UFDLImport..ѯ�۵� where GUID = '" + sGuid + "'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            if (dt == null || dt.Rows.Count == 0)
            {
                throw new Exception("�� " + (iFocRow + 1).ToString() + "���ѯ�۵�ʧ��");
            }
            if (dt.Rows[0]["������"].ToString().Trim() == "")
            {
                throw new Exception("�� " + (iFocRow + 1).ToString() + "��δ����");
            }
            DateTime d��ǰʱ�� = Convert.ToDateTime(dt.Rows[0]["��ǰʱ��"]);
            DateTime d��ֹʱ�� = Convert.ToDateTime(dt.Rows[0]["��ֹ����"]);
            DateTime d��ֹʱ�� = Convert.ToDateTime("2099-12-31");
            if (dt.Rows[0]["��ֹѯ������"].ToString().Trim() != "")
            {
                d��ֹʱ�� = Convert.ToDateTime(dt.Rows[0]["��ֹѯ������"]);
            }
            if (d��ǰʱ�� < d��ֹʱ�� && d��ǰʱ�� < d��ֹʱ��)
            {
                throw new Exception("�� " + (iFocRow + 1).ToString() + "��ֹʱ��δ��");
            }

            //�й�Ӧ��δ���ۣ���ʾ����ȡ���鿴
            sSQL = @"
select b.[��Ӧ�̱���],d.cVenName
from UFDLImport..ѯ�۵� a inner join UFDLImport..ѯ�۵������б� aa on a.GUID = aa.GUID
	inner join UFDLImport..ѯ�۵���Ӧ�� b on a.GUID = b.GUID 
	left join UFDLImport..ѯ�۵���Ӧ�̱��� c on c.GUID = a.guid and aa.GUID���� = c.GUID���� and b.��Ӧ�̱��� = c.��Ӧ�̱���
	inner join @u8.vendor d on b.��Ӧ�̱��� = d.cVenCode
	left join UFDLImport..ѯ�۵����� e on e.GUID���� = aa.GUID����
where a.[GUID] = 'aaaaaa'
	AND c.���� is null
GROUP BY b.[��Ӧ�̱���],d.cVenName

";
            sSQL = sSQL.Replace("aaaaaa", sGuid);
            DataTable dtTemp = clsSQLCommond.ExecQuery(sSQL);
            if (d��ǰʱ�� < d��ֹʱ��.AddHours(2))
            {
                if (dtTemp != null && dtTemp.Rows.Count > 0)
                {
                    string sVenTemp = "";
                    for (int i = 0; i < dtTemp.Rows.Count; i++)
                    {
                        if (sVenTemp == "")
                        {
                            sVenTemp = dtTemp.Rows[i]["��Ӧ�̱���"].ToString().Trim() + "-" + dtTemp.Rows[i]["cVenName"].ToString().Trim();
                        }
                        else
                        {
                            sVenTemp = sVenTemp + "\n" + dtTemp.Rows[i]["��Ӧ�̱���"].ToString().Trim() + "-" + dtTemp.Rows[i]["cVenName"].ToString().Trim();
                        }
                    }

                    throw new Exception("����δ��ɣ���ǰ�޷��鿴���������¹�˾δ���ۣ��뼰ʱ֪ͨ:\n" + sVenTemp);
                }
            }

            Frmѯ�۵��鿴 f = new Frmѯ�۵��鿴(sGuid);
            f.ShowDialog();

        }

        private void btnstopX()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            string sInfo = "";

            aList = new ArrayList();
            string sErr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (!Convert.ToBoolean(gridView1.GetRowCellValue(i, gridColѡ��)))
                    continue;

                string sSQL = "select *,getdate() as ��ǰʱ�� from UFDLImport..ѯ�۵� where guid = '" + gridView1.GetRowCellValue(i, gridColGUID).ToString().Trim() + "'";
                DataTable dt= clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count ==0)
                {
                    sErr = sErr + "��" + (i + 1).ToString() + "���ѯ�۵�ʧ��\n";
                    continue;
                }
                if (dt.Rows[0]["������"].ToString().Trim() == "")
                {
                    sErr = sErr + "��" + (i + 1).ToString() + "��δ����\n";
                    continue;
                }
                if (dt.Rows[0]["��ֹ��"].ToString().Trim() != "")
                {
                    sErr = sErr + "��" + (i + 1).ToString() + "�Ѿ���ֹ\n";
                    continue;
                }
                DateTime dNow = Convert.ToDateTime(dt.Rows[0]["��ǰʱ��"]);
                DateTime d��ֹ���� = Convert.ToDateTime(dt.Rows[0]["��ֹ����"]);
                if (dNow > d��ֹ����)
                {
                    sErr = sErr + "��" + (i + 1).ToString() + "�ѹ���ֹ���ڣ�����Ҫ��ֹ\n";
                    continue;
                }

                sSQL = @"
select ��Ӧ�̱��� from UFDLImport..ѯ�۵� a left join UFDLImport.[dbo].[ѯ�۵���Ӧ��] b on a.guid = b.GUID
where a.guid = 'aaaaaa'
	and ��Ӧ�̱��� not in (select ��Ӧ�̱��� from UFDLImport.[dbo].[ѯ�۵���Ӧ�̱���] where guid = 'aaaaaa')
";
                sSQL = sSQL.Replace("aaaaaa", gridView1.GetRowCellValue(i, gridColGUID).ToString().Trim());
                DataTable dtVend = clsSQLCommond.ExecQuery(sSQL);
                if (dtVend != null && dtVend.Rows.Count > 0)
                {
                    string sVend = "";
                    for (int j = 0; j < dtVend.Rows.Count; j++)
                    {
                        if (sVend == "")
                        {
                            sVend = dtVend.Rows[j]["��Ӧ�̱���"].ToString().Trim();
                        }
                        else
                        {
                            sVend = sVend + "," + dtVend.Rows[j]["��Ӧ�̱���"].ToString().Trim();
                        }
                    }
                    sInfo = sInfo + "��" + (i + 1).ToString() + ":  " +sVend + "\n";
                }

                sSQL = "update UFDLImport..ѯ�۵� set ��ֹ�� = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "',��ֹѯ������ = getdate() where guid = '" + gridView1.GetRowCellValue(i, gridColGUID).ToString().Trim() + "'";
                aList.Add(sSQL);
            }
            if (sErr != "")
            {
                throw new Exception(sErr);
            }

            if (sInfo != "")
            {
                DialogResult d = MessageBox.Show("���¹�Ӧ��δ���ۣ��Ƿ����:\n" + sInfo, "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (d != DialogResult.Yes)
                {
                    throw new Exception("��֪ͨ���¹�Ӧ�̼�������:\n" + sInfo);
                }
            }

            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("��ֹ�ɹ�");
                btnSel();
            }
            else
            {
                MessageBox.Show("û��ѡ����Ҫ����������");
            }
        }

        private void btnAdd()
        {
            string sDepCode = lookUpEditcDepCode.EditValue.ToString().Trim();
            if (sDepCode == "")
            {
                throw new Exception("����û�������Ϣʧ��");
            }

            Frmѯ�۵�Edit f = new Frmѯ�۵�Edit(sDepCode);
            f.ShowDialog();

            btnSel();
        }

        private void btnSel()
        {
            int iFoc = 0;
            if (gridView1.FocusedRowHandle > 0)
                iFoc = gridView1.FocusedRowHandle;

            string sSQL = @"
select cast(0 as bit) as ѡ��
    , iID, ��������, �Ƶ���, �Ƶ�����, ������, ��������, ����, ��ע,  GUID
    ,cast(null as varchar(8000)) as ��Ӧ�̱���,cast(null as varchar(8000)) as ��Ӧ������ 
    , CONVERT(varchar, ��ֹ����, 120) AS ��ֹ����
    , CONVERT(varchar, ��ֹѯ������, 120) as ��ֹѯ������, ��ֹ��
from UFDLImport..ѯ�۵� a
where 1=1 and a.���� = '111111'
order by a.iID
";
            sSQL = sSQL.Replace("111111", lookUpEditcDepCode.EditValue.ToString().Trim());
            if (date1.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and �������� >= '" + date1.DateTime.ToString("yyyy-MM-dd") + "' ");
            }
            if (date2.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and �������� <= '" + date2.DateTime.ToString("yyyy-MM-dd") + "' ");
            }
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sSQL = "select *,b.cVenName as ��Ӧ������ from UFDLImport..ѯ�۵���Ӧ�� a inner join @u8.vendor b on a.��Ӧ�̱��� = b.cVenCode where guid = '" + dt.Rows[i]["guid"].ToString().Trim() + "' order by a.iID";
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
                if (!Convert.ToBoolean(gridView1.GetRowCellValue(i, gridColѡ��)))
                    continue;

                string sSQL = "select count(1) from UFDLImport..ѯ�۵� where guid = '" + gridView1.GetRowCellValue(i, gridColGUID).ToString().Trim() + "' and isnull(������,'') = ''";
                int iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                if (iCou > 0)
                {
                    sErr = sErr + "��" + (i + 1).ToString() + "��δ����\n";
                    continue;
                }

                sSQL = "update UFDLImport..ѯ�۵� set ������ = null,�������� = null where guid = '" + gridView1.GetRowCellValue(i, gridColGUID).ToString().Trim() + "'";
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
                if (!Convert.ToBoolean(gridView1.GetRowCellValue(i, gridColѡ��)))
                    continue;

                string sSQL = "select count(1) from UFDLImport..ѯ�۵� where guid = '" + gridView1.GetRowCellValue(i, gridColGUID).ToString().Trim() + "' and isnull(������,'') <> ''";
                int iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                if (iCou > 0)
                {
                    sErr = sErr + "��" + (i + 1).ToString() + "�Ѿ�����\n";
                    continue;
                }

                sSQL = "update UFDLImport..ѯ�۵� set ������ = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "',�������� = getdate() where guid = '" + gridView1.GetRowCellValue(i, gridColGUID).ToString().Trim() + "'";
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
                if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridColѡ��)))
                {
                    string sSQL = "select count(1) from UFDLImport..ѯ�۵� where guid = '" + gridView1.GetRowCellValue(i, gridColGUID).ToString().Trim() + "' and isnull(������,'') <> ''";
                    int iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                    if (iCou > 0)
                    {
                        sErr = sErr + "��" + (i + 1).ToString() + "�Ѿ�����\n";
                        continue;
                    }

                    sSQL = "delete UFDLImport..ѯ�۵������б� where guid = '" + gridView1.GetRowCellValue(i, gridColGUID).ToString().Trim() + "'";
                    aList.Add(sSQL);

                    sSQL = "delete UFDLImport..ѯ�۵���Ӧ�� where guid = '" + gridView1.GetRowCellValue(i, gridColGUID).ToString().Trim() + "'";
                    aList.Add(sSQL);

                    sSQL = "delete UFDLImport..ѯ�۵����� where guid = '" + gridView1.GetRowCellValue(i, gridColGUID).ToString().Trim() + "'";
                    aList.Add(sSQL);

                    sSQL = "delete UFDLImport..ѯ�۵� where guid = '" + gridView1.GetRowCellValue(i, gridColGUID).ToString().Trim() + "'";
                    aList.Add(sSQL);
                }
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






        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookUp();

                string sSQL = @"
select a.cDepCode ,b.cDepName
from dbo._UserInfo a
	left join @u8.Department b on a.cDepCode = b.cDepCode
where vchrUid = '1111'
";
                sSQL = sSQL.Replace("1111", FrameBaseFunction.ClsBaseDataInfo.sUid);
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("����û���Ϣʧ��");
                }
                if (dt.Rows[0]["cDepCode"].ToString().Trim() == "")
                {
                    throw new Exception("�������û���������");
                }
                lookUpEditcDepCode.EditValue = dt.Rows[0]["cDepCode"].ToString().Trim();

                date1.DateTime = DateTime.Today.AddMonths(-1);
                date2.DateTime = DateTime.Today;

                date1.Enabled = true;
                date1.Properties.ReadOnly = false;

                date2.Enabled = true;
                date2.Properties.ReadOnly = false;

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

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView1.FocusedRowHandle > 0)
                    iRow = gridView1.FocusedRowHandle;

                string sDepCode = lookUpEditcDepCode.EditValue.ToString().Trim();
                if (sDepCode == "")
                {
                    throw new Exception("����û�������Ϣʧ��");
                }


                string sGuid = gridView1.GetRowCellValue(iRow, gridColGUID).ToString().Trim();
                if (sGuid != "")
                {
                    Frmѯ�۵�Edit f = new Frmѯ�۵�Edit(sGuid, sDepCode);
                    f.ShowDialog();

                    btnSel();
                }
            }
            catch { }
        }

        private void SetLookUp()
        {
            string sSQL = "select cDepCode,cDepName from @u8.Department order by cDepCode";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            lookUpEditcDepCode.Properties.DataSource = dt;


            sSQL = "select  vchrUid, vchrName from _UserInfo order by vchrUid";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEditUser.DataSource = dt;
        }
    }
}