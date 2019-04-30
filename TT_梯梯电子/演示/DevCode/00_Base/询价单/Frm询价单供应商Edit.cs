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


namespace Base
{
    public partial class Frmѯ�۵���Ӧ��Edit : Form
    {
        FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
        FrameBaseFunction.ClsGetSQL clsGetSQL = FrameBaseFunction.ClsGetSQL.Instance();

        string sGuid = "";
        string sVenCode = "";
        string sType = "";

        public Frmѯ�۵���Ӧ��Edit(string s,string sVen)
        {
            InitializeComponent();

            sGuid = s;
            sVenCode = sVen;

            labelGUID.Text = s;
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
select * ,getdate() as ��ǰʱ��
from UFDLImport..ѯ�۵� a inner join UFDLImport..ѯ�۵���Ӧ�� b on a.GUID = b.GUID 
where a.GUID = '111111' and b.��Ӧ�̱��� = '222222'
";
            sSQL = sSQL.Replace("111111", sGuid);
            sSQL = sSQL.Replace("222222", lookUpEditcVenCode.EditValue.ToString().Trim());
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt == null || dt.Rows.Count == 0)
            {
                SetNull();
                return;
            }

            DateTime d��ֹʱ�� = Convert.ToDateTime(dt.Rows[0]["��ֹ����"]);
            DateTime d��ֹʱ�� = Convert.ToDateTime("2099-12-31");
            if (dt.Rows[0]["��ֹѯ������"].ToString().Trim() != "")
            {
                d��ֹʱ�� = Convert.ToDateTime(dt.Rows[0]["��ֹѯ������"]);
            }
            DateTime d��ǰʱ�� = Convert.ToDateTime(dt.Rows[0]["��ǰʱ��"]);
            if (d��ǰʱ�� > d��ֹʱ�� || d��ǰʱ�� > d��ֹʱ��.AddHours(2))
            {
                gridView2.OptionsBehavior.Editable = false;
                btn����.Enabled = false;
                btn�ύ.Enabled = false;
            }
            else
            {
                gridView2.OptionsBehavior.Editable = true;
                btn����.Enabled = true;
                btn�ύ.Enabled = true;
            }

            sSQL = @"
select a.iID, a.[GUID], a.�Զ�������, a.���ϱ���, a.���� as Ҫ������, a.�������� as Ҫ����������, a.��ע1, a.��ע2, a.��ע3, a.GUID����
	, b.����, b.��Ӧ�̱���, b.�ύ��, b.�ύʱ��, b.��Ӧ�̱�ע as ��Ӧ�̱�ע,b.����,b.��������
    ,c.������ as ���ظ���
    ,b.������,b.��������,b.��������
from UFDLImport..ѯ�۵������б� a left join UFDLImport..ѯ�۵���Ӧ�̱��� b on a.GUID���� = b.GUID���� and b.��Ӧ�̱��� = '111111'
    left join UFDLImport..ѯ�۵����� c on c.GUID���� = a.GUID����
where 1=1
order by a.iID

";
            sSQL = sSQL.Replace("111111", lookUpEditcVenCode.EditValue.ToString().Trim());
            sSQL = sSQL.Replace("1=1","1=1 and a.GUID = '" + sGuid + "'");
            DataTable dt�����б� = clsSQLCommond.ExecQuery(sSQL);
            gridControl2.DataSource = dt�����б�;

            txt����.Text = dt.Rows[0]["����"].ToString().Trim();
            richTextBox��ע.Text = dt.Rows[0]["��ע"].ToString().Trim();
            dtm��ֹ.Text = Convert.ToDateTime(dt.Rows[0]["��ֹ����"]).ToString("yyyy-MM-dd");
            txt��ֹ����.Text = dt.Rows[0]["��ֹѯ������"].ToString().Trim();
            lookUpEditTime.EditValue =  Convert.ToDateTime(dt.Rows[0]["��ֹ����"]).ToString("HH:mm");
            dtm��������.DateTime = Convert.ToDateTime(dt.Rows[0]["��������"]);
            txt�Ƶ���.EditValue = dt.Rows[0]["�Ƶ���"].ToString().Trim();
            date�Ƶ�����.Text = dt.Rows[0]["�Ƶ�����"].ToString().Trim();
            txt������.EditValue = dt.Rows[0]["������"].ToString().Trim();
            date_��������.Text = dt.Rows[0]["��������"].ToString().Trim();

            txt�ύ��.EditValue = dt�����б�.Rows[0]["�ύ��"].ToString().Trim();
            txt�ύ����.Text = dt�����б�.Rows[0]["�ύʱ��"].ToString().Trim();
        }

        private void SetNull()
        {
            txt����.Text = "";
            richTextBox��ע.Text = "";
            dtm��ֹ.DateTime = DateTime.Today;
            dtm��������.DateTime = DateTime.Today;
            txt�Ƶ���.Text = "";
            date�Ƶ�����.Text = "";
            txt������.Text = "";
            date_��������.Text = "";
            labelGUID.Text = "";
            sGuid = "";

            string sSQL = "select cast(0 as bit) as bChoose,* from UFDLImport..ѯ�۵������б� where 1=-1";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl2.DataSource = dt;

            txt����.Focus();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "select * from UFDLImport..ѯ�۵� where [GUID] = '" + sGuid + "'";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("���ѯ�۵���Ϣʧ��");
                }
                if (dt.Rows[0]["�᰸��"].ToString().Trim() != "")
                {
                    gridView2.OptionsBehavior.Editable = false;
                    btn�ύ.Enabled = false;
                    btn����.Enabled = false;
                    
                }
                else
                {
                    gridView2.OptionsBehavior.Editable = true;
                    btn�ύ.Enabled = true;
                    btn����.Enabled = true;
                }

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

                string sErr = "";

            
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                  
                }

                

            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "��ʾ";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void btn�ύ_Click(object sender, EventArgs e)
        {
            try
            {

                try
                {
                    gridView2.FocusedRowHandle -= 1;
                    gridView2.FocusedRowHandle += 1;
                }
                catch { }

                string sSQL = "select getdate()";
                DataTable dtTime = clsSQLCommond.ExecQuery(sSQL);
                DateTime d������ʱ�� = Convert.ToDateTime(dtTime.Rows[0][0]);
                DateTime d��ֹʱ�� = Convert.ToDateTime(dtm��ֹ.DateTime.ToString("yyyy-MM-dd") + " " + lookUpEditTime.Text.Trim() + ":00");
                if (d������ʱ�� > d��ֹʱ��.AddHours(2))
                {
                    throw new Exception("������ֹʱ�䣬�����ύ");
                }

                sSQL = "select * from UFDLImport..ѯ�۵� where [GUID] = '" + sGuid + "'";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("���ѯ�۵���Ϣʧ��");
                }
                if (dt.Rows[0]["�᰸��"].ToString().Trim() != "")
                {
                    gridView2.OptionsBehavior.Editable = false;
                    btn�ύ.Enabled = false;
                    btn����.Enabled = false;
                    throw new Exception("�Ѿ��᰸�������ύ");
                }
                else
                {
                    gridView2.OptionsBehavior.Editable = true;
                    btn�ύ.Enabled = true;
                    btn����.Enabled = true;
                }

                bool bδ���� = true;
                ArrayList aList = new ArrayList();
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    decimal d���� = ReturnObjectToDecimal(gridView2.GetRowCellValue(i, gridCol_����),2);
                    string s���� = "null";
                    if(d����>0)
                    {
                        s���� = d����.ToString();
                    }
                    decimal d���� = ReturnObjectToDecimal(gridView2.GetRowCellValue(i, gridCol_����), 2);
                    string s���� = "null";
                    if (d���� >= 0)
                    {
                        s���� = d����.ToString();
                        bδ���� = false;
                    }
                    decimal d�������� = ReturnObjectToDecimal(gridView2.GetRowCellValue(i, gridCol_��������), 2);
                    string s�������� = "null";
                    if (d�������� > 0)
                    {
                        s�������� = d��������.ToString();
                    }

                    sSQL = @"
if exists(select * from UFDLImport..ѯ�۵���Ӧ�̱��� where ��Ӧ�̱��� = '@��Ӧ�̱���' and GUID���� = '@GUID����')
	update UFDLImport..ѯ�۵���Ӧ�̱��� set ���� = @����,�������� = @��������,���� = @����,��Ӧ�̱�ע = '@��Ӧ�̱�ע' ,�ύ�� = '@�ύ��',�ύʱ�� = getdate()
	where ��Ӧ�̱��� = '@��Ӧ�̱���' and GUID���� = '@GUID����'
else
	insert into UFDLImport..ѯ�۵���Ӧ�̱���(GUID, GUID����, ����, ��������, ����, ��Ӧ�̱���, �ύ��, �ύʱ��, ��Ӧ�̱�ע)
	values('@GUID','@GUID����',@����,@��������,@����,'@��Ӧ�̱���','@�ύ��',getdate(),'@��Ӧ�̱�ע')
";
                    sSQL = sSQL.Replace("@GUID����", gridView2.GetRowCellValue(i, gridCol_GUID����).ToString().Trim());
                    sSQL = sSQL.Replace("@GUID", sGuid);
                    sSQL = sSQL.Replace("@����", s����);
                    sSQL = sSQL.Replace("@��������", s��������);
                    sSQL = sSQL.Replace("@����", s����);
                    sSQL = sSQL.Replace("@��Ӧ�̱���", lookUpEditcVenCode.EditValue.ToString().Trim());
                    sSQL = sSQL.Replace("@�ύ��", FrameBaseFunction.ClsBaseDataInfo.sUid);
                    sSQL = sSQL.Replace("@��Ӧ�̱�ע", gridView2.GetRowCellValue(i, gridCol_��Ӧ�̱�ע).ToString().Trim());
                    aList.Add(sSQL);
                }

                if (bδ����)
                {
                    throw new Exception("�뱨��");
                }

                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("�ύ�ɹ�");

                this.Close();
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

                    FrameBaseFunction.ClsExcel clsExcel = FrameBaseFunction.ClsExcel.Instance();
                    DataTable dtExcel = clsExcel.ExcelToDT(sFilePath, sSQL, true);
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
            string sSQL = "select * from @u8.Inventory order by cInvCode";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit_cInvName.DataSource = dt;
            ItemLookUpEdit_cInvStd.DataSource = dt;

            sSQL = "select cVenCode,cVenName from @u8.Vendor where cVenCode = '" + sVenCode + "' order by cVenCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            lookUpEditcVenCode.Properties.DataSource = dt;
            lookUpEditcVenCode.EditValue = sVenCode;

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



            sSQL = "select  vchrUid, vchrName from _UserInfo order by vchrUid";
            dt = clsSQLCommond.ExecQuery(sSQL);
            txt������.Properties.DataSource = dt;
            txt�ύ��.Properties.DataSource = dt;
            txt�Ƶ���.Properties.DataSource = dt;
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

        private void btn����_Click(object sender, EventArgs e)
        {
            try
            {
                string sSQL = @"
select * 
from UFDLImport..ѯ�۵���Ӧ�̱��� 
where ��Ӧ�̱��� = '@��Ӧ�̱���' and GUID = '@GUID'
";
                sSQL = sSQL.Replace("@��Ӧ�̱���", lookUpEditcVenCode.EditValue.ToString().Trim());
                sSQL = sSQL.Replace("@GUID", sGuid);
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("ѯ�۵�ʧ��");
                }
                if (dt.Rows.Count > 0)
                {
                    string s������ = dt.Rows[0]["������"].ToString().Trim();
                    if (s������ != "")
                    {
                        throw new Exception("�Ѿ��������ܳ���");
                    }
                }

                sSQL = @"
	delete UFDLImport..ѯ�۵���Ӧ�̱��� 
	where ��Ӧ�̱��� = '@��Ӧ�̱���' and GUID = '@GUID'
";
                sSQL = sSQL.Replace("@��Ӧ�̱���", lookUpEditcVenCode.EditValue.ToString().Trim());
                sSQL = sSQL.Replace("@GUID", sGuid);
                clsSQLCommond.ExecSql(sSQL);
                MessageBox.Show("�����ɹ�");

                this.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show("�����ύ:" + ee.Message);
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

                string sSQL = "select getdate()";
                DataTable dtTime = clsSQLCommond.ExecQuery(sSQL);
                DateTime d������ʱ�� = Convert.ToDateTime(dtTime.Rows[0][0]);
                DateTime d��ֹʱ�� = Convert.ToDateTime(dtm��ֹ.DateTime.ToString("yyyy-MM-dd") + " " + lookUpEditTime.Text.Trim() + ":00");
                if (d������ʱ�� > d��ֹʱ��.AddHours(2))
                {
                    throw new Exception("������ֹʱ�䣬�����ύ");
                }

                sSQL = "select * from UFDLImport..ѯ�۵� where [GUID] = '" + sGuid + "'";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("���ѯ�۵���Ϣʧ��");
                }
                if (dt.Rows[0]["�᰸��"].ToString().Trim() != "")
                {
                    gridView2.OptionsBehavior.Editable = false;
                    btn�ύ.Enabled = false;
                    btn����.Enabled = false;
                    throw new Exception("�Ѿ��᰸�������ύ");
                }
                else
                {
                    gridView2.OptionsBehavior.Editable = true;
                    btn�ύ.Enabled = true;
                    btn����.Enabled = true;
                }

                ArrayList aList = new ArrayList();
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    string s���� = "0";
                    string s���� = "0";
                    string s�������� = "0";

                    sSQL = @"
if exists(select * from UFDLImport..ѯ�۵���Ӧ�̱��� where ��Ӧ�̱��� = '@��Ӧ�̱���' and GUID���� = '@GUID����')
	update UFDLImport..ѯ�۵���Ӧ�̱��� set ���� = @����,�������� = @��������,���� = @����,��Ӧ�̱�ע = '@��Ӧ�̱�ע' ,�ύ�� = '@�ύ��',�ύʱ�� = getdate()
	where ��Ӧ�̱��� = '@��Ӧ�̱���' and GUID���� = '@GUID����'
else
	insert into UFDLImport..ѯ�۵���Ӧ�̱���(GUID, GUID����, ����, ��������, ����, ��Ӧ�̱���, �ύ��, �ύʱ��, ��Ӧ�̱�ע)
	values('@GUID','@GUID����',@����,@��������,@����,'@��Ӧ�̱���','@�ύ��',getdate(),'@��Ӧ�̱�ע')
";
                    sSQL = sSQL.Replace("@GUID����", gridView2.GetRowCellValue(i, gridCol_GUID����).ToString().Trim());
                    sSQL = sSQL.Replace("@GUID", sGuid);
                    sSQL = sSQL.Replace("@����", s����);
                    sSQL = sSQL.Replace("@��������", s��������);
                    sSQL = sSQL.Replace("@����", s����);
                    sSQL = sSQL.Replace("@��Ӧ�̱���", lookUpEditcVenCode.EditValue.ToString().Trim());
                    sSQL = sSQL.Replace("@�ύ��", FrameBaseFunction.ClsBaseDataInfo.sUid);
                    sSQL = sSQL.Replace("@��Ӧ�̱�ע", "����");
                    aList.Add(sSQL);
                }

                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("�����ɹ�");

                this.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

    }
}