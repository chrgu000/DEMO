using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FrameBaseFunction;
using System.IO;
using System.Data.SqlClient;
using System.Data.OleDb;


namespace Base
{
    public partial class Frmѯ�۵�Edit : Form
    {
        FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
        FrameBaseFunction.ClsGetSQL clsGetSQL = FrameBaseFunction.ClsGetSQL.Instance();

        string sDepCode = "";

        string sGuid = "";
        public Frmѯ�۵�Edit(string s2)
        {
            InitializeComponent();

            labelGUID.Text = "";
            sDepCode = s2;
        }
        string sType = "";
        public Frmѯ�۵�Edit(string s,string s2)
        {
            InitializeComponent();

            sGuid = s;

            labelGUID.Text = s;

            sDepCode = s2;
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
                    gridView2.ExportToXls(sF.FileName);
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
select a.* ,b.*,c.cVenName
from UFDLImport..ѯ�۵� a inner join UFDLImport..ѯ�۵���Ӧ�� b on a.GUID = b.GUID 
    left join @u8.Vendor c on b.��Ӧ�̱��� = c.cVenCode
where a.GUID = '111111'
";
            sSQL = sSQL.Replace("111111", sGuid);
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt == null || dt.Rows.Count == 0)
            {
                SetNull();
                return;
            }

            labeliID.Text = dt.Rows[0]["iID"].ToString().Trim();

            string sVenCode = "";
            string sVenName = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (sVenCode == "")
                {
                    sVenCode = dt.Rows[i]["��Ӧ�̱���"].ToString().Trim();
                    sVenName = dt.Rows[i]["cVenName"].ToString().Trim();
                }
                else
                {
                    sVenCode = sVenCode + "," + dt.Rows[i]["��Ӧ�̱���"].ToString().Trim();
                    sVenName = sVenName + "," + dt.Rows[i]["cVenName"].ToString().Trim();
                }
            }

            label��Ӧ��.Text = sVenCode;
            txtVenCode.Text = sVenCode;
            txtVenName.Text = sVenName;

            sSQL = @"
select a.*,b.������ as ���ظ��� ,cast(null as varchar(200)) as �ϴ�����
from UFDLImport..ѯ�۵������б� a left join UFDLImport..ѯ�۵����� b on a.GUID���� = b.GUID����
where 1=1 
order by a.iID
";
            sSQL = sSQL.Replace("1=1","1=1 and a.GUID = '" + sGuid + "'");
            DataTable dt�����б� = clsSQLCommond.ExecQuery(sSQL);
            gridControl2.DataSource = dt�����б�;


            txt����.Text = dt.Rows[0]["����"].ToString().Trim();
            richTextBox��ע.Text = dt.Rows[0]["��ע"].ToString().Trim();
            dtm��ֹ.Text = Convert.ToDateTime(dt.Rows[0]["��ֹ����"]).ToString("yyyy-MM-dd");
            lookUpEditTime.EditValue =  Convert.ToDateTime(dt.Rows[0]["��ֹ����"]).ToString("HH:mm");
            txt��ֹ����.Text = dt.Rows[0]["��ֹѯ������"].ToString().Trim();
            dtm��������.DateTime = Convert.ToDateTime(dt.Rows[0]["��������"]);
            txt�Ƶ���.EditValue = dt.Rows[0]["�Ƶ���"].ToString().Trim();
            date�Ƶ�����.Text = dt.Rows[0]["�Ƶ�����"].ToString().Trim();
            txt������.EditValue = dt.Rows[0]["������"].ToString().Trim();
            date_��������.Text = dt.Rows[0]["��������"].ToString().Trim();
            if (txt������.Text.Trim() != "")
            {
                SetEnbale(true);
            }
            else
            {
                SetEnbale(false);
            }
        }

        private void SetEnbale(bool p)
        {
            txt����.ReadOnly = p;
            richTextBox��ע.ReadOnly = p;
            dtm��ֹ.Properties.ReadOnly = p;
            lookUpEditTime.Properties.ReadOnly = p;
            txt��ֹ����.Enabled = false;
            dtm��������.Properties.ReadOnly = p;
            btnExcel.Enabled = !p;
            btnAddRow.Enabled = !p;
            btnDelRow.Enabled = !p;
            txtVenCode.Enabled = !p;
            btnExExcel.Enabled = true;

            btn����.Enabled = !p;
            btnɾ��.Enabled = !p;
         
            txt�Ƶ���.Enabled = false;
            txt������.Enabled = false;
            date_��������.Enabled = false;
            date�Ƶ�����.Enabled = false;

            for (int i = 0; i < gridView2.Columns.Count; i++)
            {
                gridView2.Columns[i].OptionsColumn.AllowEdit = !p;
            }
            gridCol_�ϴ�����.OptionsColumn.AllowEdit = true;
            gridCol_���ظ���.OptionsColumn.AllowEdit = true;
            gridCol_GUID����.OptionsColumn.AllowEdit = false;
        }

        private void SetNull()
        {
            label��Ӧ��.Text = "";
            txt����.Text = "";
            richTextBox��ע.Text = "";
            dtm��ֹ.DateTime = DateTime.Today;
            dtm��������.DateTime = DateTime.Today;
            txt��ֹ����.Text = "";
            txt�Ƶ���.Text = "";
            date�Ƶ�����.Text = "";
            txt������.Text = "";
            date_��������.Text = "";
            labelGUID.Text = "";
            sGuid = "";

            string sSQL = @"
select a.*,b.������ as ���ظ��� ,cast(null as varchar(200)) as �ϴ�����
from UFDLImport..ѯ�۵������б� a left join UFDLImport..ѯ�۵����� b on a.GUID���� = b.GUID����
where 1=-1 
order by a.iID
";

            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl2.DataSource = dt;

            txt����.Focus();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                dtm��������.DateTime = DateTime.Today;
                dtm��ֹ.DateTime = DateTime.Today;

                SetLookUp();
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

        private void sSave()
        {
            try
            {
                try
                {
                    gridView2.FocusedRowHandle -= 1;
                    gridView2.FocusedRowHandle += 1;
                }
                catch { }

                string sErr = "";

                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    string s�Զ������� = gridView2.GetRowCellValue(i, gridCol_�Զ�������).ToString().Trim();
                    string scInvCode = gridView2.GetRowCellValue(i, gridCol_cInvCode).ToString().Trim();
                    decimal d���� = ReturnObjectToDecimal(gridView2.GetRowCellValue(i, gridCol_����), 6);

                    for (int j = i + 1; j < gridView2.RowCount; j++)
                    {
                        string s�Զ�������2 = gridView2.GetRowCellValue(j, gridCol_�Զ�������).ToString().Trim();
                        string scInvCode2 = gridView2.GetRowCellValue(j, gridCol_cInvCode).ToString().Trim();
                        decimal d����2 = ReturnObjectToDecimal(gridView2.GetRowCellValue(j, gridCol_����), 6);

                        if (i == j)
                            continue;

                        if (s�Զ������� == s�Զ�������2 && s�Զ������� != "" && d���� == d����2)
                        {
                            sErr = sErr + "��" + (i + 1).ToString() + "�� �� " + (j + 1) + "�Զ�������һ��\n";
                            continue;
                        }

                        if (scInvCode == scInvCode2 && scInvCode != "" && d���� == d����2)
                        {
                            sErr = sErr + "��" + (i + 1).ToString() + "�� �� " + (j + 1) + "���ϱ���һ��\n";
                            continue;
                        }
                    }

                    if (scInvCode.Trim() != "")
                    {
                        string sInvName = gridView2.GetRowCellDisplayText(i, gridCol_cInvName).ToString().Trim();
                        if (sInvName.Trim() == "")
                        {
                            sErr = sErr + "��" + (i + 1).ToString() + "���ϱ��벻��ȷ\n";
                            continue;
                        }
                    }
                }

                if (sErr.Length > 0)
                {
                    throw new Exception(sErr);
                }

                if (txt����.Text.Trim() == "")
                {
                    txt����.Focus();
                    throw new Exception("���ⲻ��Ϊ��");
                }
                if (richTextBox��ע.Text.Trim() == "")
                {
                    richTextBox��ע.Focus();
                    throw new Exception("��ע����Ϊ��");
                }
                if (sGuid == "")
                {
                    sGuid = Guid.NewGuid().ToString();
                }

                DateTime d��ֹʱ�� = Convert.ToDateTime(dtm��ֹ.DateTime.ToString("yyyy-MM-dd") + " " + lookUpEditTime.Text + ":00");
                if (dtm��ֹ.DateTime < dtm��������.DateTime || d��ֹʱ�� < DateTime.Now.AddHours(1))
                {
                    throw new Exception("���ݽ�ֹʱ�������ڵ�ǰʱ������һСʱ");
                }

                string sSQL = "select count(1) from UFDLImport..ѯ�۵� where guid = '" + sGuid + "' and isnull(������,'') <> ''";
                int iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                if (iCou > 0)
                    throw new Exception("�Ѿ����������޸�");

                ArrayList aList = new ArrayList();



                sSQL = "delete UFDLImport..ѯ�۵������б� where guid = '" + sGuid + "'";
                aList.Add(sSQL);


                bool b = false;
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    string sInvCode = gridView2.GetRowCellValue(i, gridCol_cInvCode).ToString().Trim();
                    string sInvCode�Զ��� = gridView2.GetRowCellValue(i, gridCol_�Զ�������).ToString().Trim();
                    if (sInvCode == "" && sInvCode�Զ��� == "")
                    {
                        sErr = sErr + "�� " + (i + 1).ToString() + " ���ϱ��벻��Ϊ��\n";
                        continue;
                    }
                    if (sInvCode != "" && sInvCode�Զ��� != "")
                    {
                        sErr = sErr + "�� " + (i + 1).ToString() + " ���ϱ���,�Զ������ϲ���ͬʱ����\n";
                        continue;
                    }

                    b = true;
                    sSQL = @"
insert into UFDLImport..ѯ�۵������б�(GUID, �Զ�������,���ϱ���, ����, ��������, ��ע1, ��ע2, ��ע3, GUID����)
values('1111',2222,3333,4444,5555,'6666','7777','8888','9999')
";
                    sSQL = sSQL.Replace("1111", sGuid);

                    if (sInvCode�Զ��� == "")
                    {
                        sInvCode�Զ��� = "null";
                    }
                    else
                    {
                        sInvCode�Զ��� = "'" + sInvCode�Զ��� + "'";
                    }
                    sSQL = sSQL.Replace("2222", sInvCode�Զ���);

                    if (sInvCode == "")
                    {
                        sInvCode = "null";
                    }
                    else
                    {
                        sInvCode = "'" + sInvCode + "'";
                    }
                    sSQL = sSQL.Replace("3333", sInvCode);

                    decimal dQty = ReturnObjectToDecimal(gridView2.GetRowCellValue(i, gridCol_����), 2);
                    if (dQty < 0)
                    {
                        sErr = sErr + "�� " + (i + 1).ToString() + " ��������Ϊ����\n";
                        continue;
                    }
                    if (dQty > 0)
                    {
                        sSQL = sSQL.Replace("4444", dQty.ToString());
                    }
                    else
                    {
                        sSQL = sSQL.Replace("4444", "null");
                    }

                    decimal d�������� = ReturnObjectToDecimal(gridView2.GetRowCellValue(i, gridCol_��������), 2);
                    if (d�������� < 0)
                    {
                        sErr = sErr + "�� " + (i + 1).ToString() + " �������ڲ���Ϊ����\n";
                        continue;
                    }
                    if (dQty > 0)
                    {
                        sSQL = sSQL.Replace("5555", d��������.ToString());
                    }
                    else
                    {
                        sSQL = sSQL.Replace("5555", "null");
                    }


                    sSQL = sSQL.Replace("6666", gridView2.GetRowCellValue(i, gridCol_��ע1).ToString().Trim());
                    sSQL = sSQL.Replace("7777", gridView2.GetRowCellValue(i, gridCol_��ע2).ToString().Trim());
                    sSQL = sSQL.Replace("8888", gridView2.GetRowCellValue(i, gridCol_��ע3).ToString().Trim());

                    string sGuid���� = gridView2.GetRowCellValue(i, gridCol_GUID����).ToString().Trim();
                    if (sGuid����.Length == 0)
                    {
                        sGuid���� = Guid.NewGuid().ToString();
                    }
                    sSQL = sSQL.Replace("9999", sGuid����);
                    aList.Add(sSQL);
                }

                if (!b)
                {
                    throw new Exception("����������");
                }

                sSQL = "delete UFDLImport..ѯ�۵���Ӧ�� where guid = '" + sGuid + "'";
                aList.Add(sSQL);

                b = false;

                if (label��Ӧ��.Text.Trim() == "")
                {
                    throw new Exception("��ѡ��Ӧ��");
                }
                string[] s��Ӧ�� = label��Ӧ��.Text.Trim().Split(',');
                for (int i = 0; i < s��Ӧ��.Length; i++)
                {
                    sSQL = "insert into UFDLImport..ѯ�۵���Ӧ��(��Ӧ�̱���,guid)values('" + s��Ӧ��[i].Trim() + "','" + sGuid + "')";
                    aList.Add(sSQL);
                    b = true;
                }

                if (!b)
                {
                    throw new Exception("��ѡ��Ӧ��");
                }

                sSQL = "select count(1) from UFDLImport..ѯ�۵� where guid = '" + sGuid + "'";
                iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                if (iCou == 0)
                {
                    sSQL = "insert into UFDLImport..ѯ�۵�(����,��ע,�Ƶ���,�Ƶ�����,��������,��ֹ����,guid,����)values('" + txt����.Text.Trim() + "','" + richTextBox��ע.Text.Trim() + "','" + FrameBaseFunction.ClsBaseDataInfo.sUid + "','" + DateTime.Today.ToString("yyyy-MM-dd") + "','" + dtm��������.DateTime.ToString("yyyy-MM-dd") + "','" + dtm��ֹ.DateTime.ToString("yyyy-MM-dd") + " " + lookUpEditTime.Text.Trim() + "','" + sGuid + "','" + sDepCode + "')";
                    aList.Add(sSQL);
                }
                else
                {
                    sSQL = "update UFDLImport..ѯ�۵� set ��ֹ���� = '" + dtm��ֹ.DateTime.ToString("yyyy-MM-dd") + " " + lookUpEditTime.Text.Trim() + "',���� = '" + txt����.Text.Trim() + "',��ע = '" + richTextBox��ע.Text.Trim() + "',�Ƶ��� = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "',�Ƶ����� = '" + DateTime.Today.ToString("yyyy-MM-dd") + "' where guid = '" + sGuid + "'";
                    aList.Add(sSQL);
                }


                if (sErr.Length > 0)
                {
                    throw new Exception(sErr);
                }

                if (aList.Count > 1)
                {
                    clsSQLCommond.ExecSqlTran(aList);

                    sErr = "";
                    for (int i = 0; i < gridView2.RowCount; i++)
                    {
                        try
                        {
                            string sFile = "";
                            try
                            {
                                sFile = gridView2.GetRowCellValue(i, gridCol_�ϴ�����).ToString().Trim();
                            }
                            catch { }
                            if (sFile != "")
                            {
                                string sGUID���� = gridView2.GetRowCellValue(i, gridCol_GUID����).ToString().Trim();
                                bool b�ϴ� = �ϴ�����(sFile, sGUID����);
                                if (!b�ϴ�)
                                {
                                    throw new Exception("");
                                }
                            }
                        }

                        catch (Exception ee)
                        {
                            sErr = sErr + "��" + (i + 1).ToString() + "�ϴ�����ʧ��\n";
                        }
                    }

                    MessageBox.Show("����ɹ�");
                    if (sErr.Length > 0)
                    {
                        MessageBox.Show(sErr, "�ϴ�����ʧ��");
                    }

                    SetValue();
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        private void btn����_Click(object sender, EventArgs e)
        {
            try
            {
                sSave();
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "��ʾ";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void btnɾ��_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView2.FocusedRowHandle -= 1;
                    gridView2.FocusedRowHandle += 1;
                }
                catch { }

                sGuid = labelGUID.Text.Trim();
                if (sGuid.Length == 0)
                {
                    throw new Exception("û��ѡ����Ҫɾ��������");
                }

                ArrayList aList = new ArrayList();
                string sSQL = "select count(1) from UFDLImport..ѯ�۵� where guid = '" + sGuid + "' and isnull(������,'') <> ''";
                int iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                if (iCou > 0)
                {
                    throw new Exception("�����Ѿ�����������ɾ��");
                }

                sSQL = "delete UFDLImport..ѯ�۵������б� where guid = '" + sGuid + "'";
                aList.Add(sSQL);

                sSQL = "delete UFDLImport..ѯ�۵���Ӧ�� where guid = '" + sGuid + "'";
                aList.Add(sSQL);

                sSQL = "delete UFDLImport..ѯ�۵����� where guid = '" + sGuid + "'";
                aList.Add(sSQL);

                sSQL = "delete UFDLImport..ѯ�۵� where guid = '" + sGuid + "'";
                aList.Add(sSQL);

                
                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("ɾ���ɹ�");

                    SetNull();
                }
                else
                {
                    MessageBox.Show("û��ѡ����Ҫɾ��������");
                }
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
                    gridView2.FocusedRowHandle -= 1;
                    gridView2.FocusedRowHandle += 1;
                }
                catch { }

                sSave();

                string sSQL = "select * from UFDLImport..ѯ�۵� where [GUID] = '" + sGuid + "'";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("���ѯ�۵�ʧ��");
                }
                if (dt.Rows[0]["������"].ToString().Trim() != "")
                {
                    throw new Exception("�Ѿ�����");
                }

                sSQL = "update UFDLImport..ѯ�۵� set ������ = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "',�������� = '" + DateTime.Today.ToString("yyyy-MM-dd") + "' where guid = '" + sGuid + "'";

                clsSQLCommond.ExecSql(sSQL);
                MessageBox.Show("�����ɹ�");

                try
                {
                    string[] s��Ӧ�� = label��Ӧ��.Text.Trim().Split(',');
                    for (int i = 0; i < s��Ӧ��.Length; i++)
                    {
                        sSQL = "select sEMail from UFDLImport.._vendUid where vendcode = '" + s��Ӧ��[i] + "' and isnull(sEMail,'') <> '' order by AccYear desc";
                        dt = clsSQLCommond.ExecQuery(sSQL);
                        if (dt != null && dt.Rows.Count > 0 && dt.Rows[0][0].ToString().Trim() != "")
                        {
                            SendMail(dt.Rows[0][0].ToString().Trim(), "���۵�", "ѯ�۵�" + labeliID .Text + "�Ѿ������뾡�챨��");
                        }
                    }
                }
                catch { }

                this.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }



        /// <summary>
        /// �����ʼ�
        /// </summary>
        private void SendMail(string sAdd, string sSub, string sText)
        {
            try
            {
                ClseMail clseMail = new ClseMail();
                clseMail.MailSend(sAdd, sSub, sText);
            }
            catch (Exception ee)
            {
                throw new Exception("�ʼ�����ʧ�ܣ� " + ee.Message);
            }
        }

        private void btnȡ��_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView2.FocusedRowHandle -= 1;
                    gridView2.FocusedRowHandle += 1;
                }
                catch { }

                string sSQL = "select * from UFDLImport..ѯ�۵� where [GUID] = '" + sGuid + "'";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("���ѯ�۵�ʧ��");
                }
                if (dt.Rows[0]["������"].ToString().Trim() == "")
                {
                    throw new Exception("��δ����");
                }

                sSQL = "select * from UFDLImport..ѯ�۵���Ӧ�̱��� where [GUID] = '@guid'";
                sSQL = sSQL.Replace("@guid", sGuid);
                dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt != null && dt.Rows.Count > 0)
                {
                    throw new Exception("���й�Ӧ���ύ���ۣ�����ȡ��");
                }


                sSQL = "update UFDLImport..ѯ�۵� set ������ = null,�������� = null where guid = '" + sGuid + "'";

                clsSQLCommond.ExecSql(sSQL);
                MessageBox.Show("ȡ�������ɹ�");

                SetEnbale(false);

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

        private void ItemButtonEdit�ϴ�����_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                OpenFileDialog oFile = new OpenFileDialog();
                oFile.Filter = "����|*.*";
                if (oFile.ShowDialog() == DialogResult.OK)
                {
                    string sFilePath = oFile.FileName;

                    if (!File.Exists(sFilePath))
                    {
                        throw new Exception("�ļ�������");
                    }

                    gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridCol_�ϴ�����, sFilePath);
                    //�ϴ�����(sFilePath);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private bool �ϴ�����(string sFilePath,string sGuid����)
        {
            bool b = false;
            using (SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandTimeout = 3600;
                cmd.Connection = conn;
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;

                try
                {
                    string[] sName = sFilePath.Split('\\');
                    string sFileName = sName[sName.Length - 1];

                    FileInfo fi = new FileInfo(sFilePath);
                    FileStream fs = fi.OpenRead();
                    byte[] bytes = new byte[fs.Length];
                    fs.Read(bytes, 0, Convert.ToInt32(fs.Length));

                    string sSQL = @"
if exists(select * from UFDLImport..ѯ�۵����� where GUID���� = '@GUID����' and [GUID] = '@GUID')
	update UFDLImport..ѯ�۵�����  set ���� = @file,�ϴ��� = '@�ϴ���',�ϴ����� = GETDATE() ,������ = N'@������'
    where GUID���� = '@GUID����' and [GUID] = '@GUID'
else
	insert into UFDLImport..ѯ�۵�����(GUID, ����, �ϴ���, �ϴ�����, GUID����,������)
	values('@GUID',@file,'@�ϴ���',GETDATE(),'@GUID����',N'@������')
";
                    sSQL = sSQL.Replace("@GUID����", sGuid����);
                    sSQL = sSQL.Replace("@GUID", sGuid);
                    sSQL = sSQL.Replace("@�ϴ���", FrameBaseFunction.ClsBaseDataInfo.sUid);
                    sSQL = sSQL.Replace("@������", sFileName);

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sSQL;
                    SqlParameter spFile = new SqlParameter("@file", SqlDbType.Image);
                    spFile.Value = bytes;
                    cmd.Parameters.Add(spFile);
                    int iCou = cmd.ExecuteNonQuery();

                    tx.Commit();

                    gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridCol_���ظ���, sFileName);

                    if (iCou > 0)
                    {
                        b = true;
                    }
                    fs = null;
                    fi = null;
                    bytes = null;
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    tx.Rollback();
                    throw new Exception(E.Message);
                }
                return b;
            }
        }

        private void ItemButtonEdit���ظ���_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                string sSQL = @"
select * from UFDLImport..ѯ�۵����� where GUID���� = '@GUID����' and [GUID] = '@GUID'
";
                sSQL = sSQL.Replace("@GUID����", gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridCol_GUID����).ToString().Trim());
                sSQL = sSQL.Replace("@GUID", sGuid);
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("����������");
                }


                SaveFileDialog oFile = new SaveFileDialog();
                oFile.Filter = "����|*.*";
                oFile.FileName = dt.Rows[0]["������"].ToString().Trim();
               
                if (oFile.ShowDialog() == DialogResult.OK)
                {
                    string sFilePath = oFile.FileName;

                    FileInfo fi = new FileInfo(sFilePath);
                    string[] sName = sFilePath.Split('\\');
                    string sFileName = sName[sName.Length - 1];
                    Byte[] b = (byte[])dt.Rows[0]["����"];
                    writePic(b, sFilePath);
                    MessageBox.Show("���سɹ�");

                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        public void writePic(byte[] pics, string sPath)
        {
            FileStream fs = new FileStream(sPath, FileMode.Append, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(pics, 0, pics.Length);
            bw.Close();
            fs.Close();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog oFile = new OpenFileDialog();
                oFile.Filter = "Excel�ļ�2003|*.xls|Excel�ļ�2007|*.xlsx";
                if (oFile.ShowDialog() == DialogResult.OK)
                {
                    string sFilePath = oFile.FileName;
                    string sSQL = "select * from [���۵�$]";

                    DataTable dtExcel = ExcelToDT(sFilePath, sSQL, true);
                    DataColumn dc = new DataColumn();
                    dc.ColumnName = "GUID����";
                    dtExcel.Columns.Add(dc);

                    for (int i = 0; i < dtExcel.Rows.Count; i++)
                    {
                        Guid g = Guid.NewGuid();
                        dtExcel.Rows[i]["GUID����"] = g.ToString();

                        string sInvCode = dtExcel.Rows[i]["���ϱ���"].ToString().Trim();
                        if (sInvCode == "")
                        {
                            continue;
                        }

                        DataTable dtInv = (DataTable)ItemLookUpEdit_cInvName.DataSource;
                        DataRow[] dr = dtInv.Select("cInvCode = '" + sInvCode + "'");
                        if (dr.Length > 0)
                        {
                            sInvCode = dr[0]["cInvCode"].ToString().Trim();
                            dtExcel.Rows[i]["���ϱ���"] = sInvCode;
                        }
                    }

                    gridControl2.DataSource = dtExcel;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void SetLookUp()
        {
            string sSQL = "select cInvCode,cInvName,cInvStd from @u8.Inventory order by cInvCode";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            DataRow dr2 = dt.NewRow();
            dt.Rows.InsertAt(dr2, 0);

            ItemLookUpEdit_cInvName.DataSource = dt;
            ItemLookUpEdit_cInvStd.DataSource = dt;

            dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "Time";
            dt.Columns.Add(dc);

            for (int i = 0; i < 24; i++)
            {
                DataRow dr = dt.NewRow();

                string sHour = i.ToString();
                while (sHour.Length < 2)
                {
                    sHour = "0" + sHour;
                }

                dr["Time"] = sHour + ":00";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Time"] = sHour + ":30";
                dt.Rows.Add(dr);
            }
            lookUpEditTime.Properties.DataSource = dt;
            lookUpEditTime.EditValue = "16:30";

            sSQL = "select  vchrUid, vchrName from _UserInfo order by vchrUid";
            dt = clsSQLCommond.ExecQuery(sSQL);
            txt�Ƶ���.Properties.DataSource = dt;
            txt������.Properties.DataSource = dt;
        }


        private decimal ReturnObjectToDecimal(object o, int iL)
        {
            decimal i = 0;
            try
            {
                i = Convert.ToDecimal(o);
                i = decimal.Round(i, iL);
            }
            catch { }
            return i;
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            try
            {
                gridView2.AddNewRow();
            }
            catch { }
        }

        private void btnDelRow_Click(object sender, EventArgs e)
        {
            try
            {
                gridView2.DeleteRow(gridView2.FocusedRowHandle);
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "��ʾ";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
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

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                string s1 = gridView2.GetRowCellValue(e.RowHandle, gridCol_cInvCode).ToString().Trim();
                string s2 = gridView2.GetRowCellValue(e.RowHandle, gridCol_�Զ�������).ToString().Trim();
                if (s1 != "" || s2 != "")
                {
                    string sGuid = gridView2.GetRowCellValue(e.RowHandle, gridCol_GUID����).ToString().Trim();
                    if (sGuid == "")
                    {
                        Guid g = Guid.NewGuid();
                        gridView2.SetRowCellValue(e.RowHandle, gridCol_GUID����, g.ToString());
                    }
                }
            }
            catch { }
        }

        private void ItemButtonEditcInvCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                try
                {
                    gridView2.FocusedColumn = gridCol_GUID����;
                    gridView2.FocusedColumn = gridCol_cInvCode;
                }
                catch { }

                string sInvCode = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridCol_cInvCode).ToString().Trim();
                FrmInvInfo fInv = new FrmInvInfo(sInvCode);
                if (DialogResult.OK == fInv.ShowDialog())
                {
                    gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridCol_cInvCode, fInv.sInvCode);
                    //gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridCol_cInvName, fInv.sInvName);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        /// <summary>
        /// ��ȡExcelת��ΪDataTable
        /// </summary>
        /// <param name="Path">·��</param>
        /// <param name="sSQL">��ȡExcel�Ĳ�ѯ��� �磺select * from [Sheet1$]</param>
        /// <param name="bIsTitle">Excel��һ���Ƿ����</param>
        /// <returns>DataTable</returns>
        public DataTable ExcelToDT(string Path, string sSQL, bool bIsTitle)
        {
            try
            {
                ArrayList arrList = new ArrayList();
                arrList.Add(sSQL);
                DataSet ds = ExcelToDS(Path, arrList, bIsTitle);

                if (ds == null || ds.Tables.Count < 1)
                    return null;
                else
                    return ds.Tables[0];
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        /// <summary>
        /// ��ȡExcelת��ΪDataSet
        /// </summary>
        /// <param name="Path">·��</param>
        /// <param name="arrList">��ȡExcel�Ĳ�ѯ���ArrayList; �磺select * from [Sheet1$]</param>
        /// <param name="bIsTitle">Excel��һ���Ƿ����</param>
        /// <returns>DataSet</returns>
        public DataSet ExcelToDS(string Path, ArrayList arrList, bool bIsTitle)
        {
            try
            {
                string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Extended Properties=\"excel 8.0;hdr=1;imex=1;Persist Security Info=false;Mode=Share Deny Read\";" + "data source=" + Path;
                if (Path.ToLower().IndexOf("xlsx") > 0)
                {
                    strConn = "Provider=Microsoft.ACE.OLEDB.12.0; Persist Security Info=False;Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1'; data source=" + Path + "";
                }

                //if (bIsTitle)
                //    strConn += "HDR=YES;'";
                //else
                //    strConn += "HDR=NO;'";

                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();

                string strExcel = "";
                OleDbDataAdapter myCommand = new OleDbDataAdapter(strExcel, strConn);
                DataSet ds = new DataSet();

                for (int i = 0; i < arrList.Count; i++)
                {
                    strExcel = arrList[i].ToString();
                    myCommand.SelectCommand.CommandText = strExcel;
                    myCommand.Fill(ds, "dt" + i.ToString());
                }

                if (ds == null || ds.Tables.Count < 1)
                    return null;
                else
                    return ds;
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        private void txtVenCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                FrmVendorInfo fVen = new FrmVendorInfo(txtVenCode.Text.Trim(), true);
                if (DialogResult.OK == fVen.ShowDialog())
                {
                    txtVenCode.Text = fVen.sVenCode;
                    txtVenName.Text = fVen.sVenName;

                    label��Ӧ��.Text = fVen.sVenCode;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("���ع�Ӧ��ʧ��");
            }
        }

        private void btnExExcel_Click(object sender, EventArgs e)
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
                    gridView2.ExportToXls(sF.FileName);
                    MessageBox.Show("����Excel�ɹ�\n\t·����" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}