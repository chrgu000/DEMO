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


namespace Base
{
    public partial class Frmѯ�۵��鿴 : FrameBaseFunction.Frm�б���ģ��
    {
        string sGuid = "";
 
        string sType = "";
        public Frmѯ�۵��鿴(string s)
        {
            InitializeComponent();

            sGuid = s;

            labelGUID.Text = s;

            //base.toolStripMenuBtn.Items["audit"].Visible = true;
            //base.toolStripMenuBtn.Items["unaudit"].Visible = true;

            toolStripMenuBtn.Visible = false;
        }

        #region ��ťģ��

        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {

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

        private void btnUnAudit()
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

                ArrayList aList = new ArrayList();

                bool b = false;

                string sSQL = "select * from UFDLImport..ѯ�۵���Ӧ�̱��� where isnull(��������,'') <> '' and [GUID] = '" + labelGUID.Text.Trim() + "'";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("��δ���");
                }


                sSQL = "update UFDLImport..ѯ�۵���Ӧ�̱��� set �������� = null,������ = null,�������� = null where [GUID] = '" + sGuid + "'";
                clsSQLCommond.ExecSql(sSQL);


                MessageBox.Show("����ɹ�");

                SetValue();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }
        private void btnAudit()
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

                ArrayList aList = new ArrayList();

                bool b = false;

                string sSQL = "select * from UFDLImport..ѯ�۵���Ӧ�̱��� where isnull(��������,'') <> '' and [GUID] = '" + labelGUID.Text.Trim() + "'";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt != null && dt.Rows.Count > 0)
                {
                    throw new Exception("�Ѿ����");
                }

                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    bool bChoose = Convert.ToBoolean(gridView2.GetRowCellValue(i, gridCol_ѡ��));

                    string sGuid���� = gridView2.GetRowCellValue(i, gridCol_GUID����).ToString().Trim();
                    string sGuid = labelGUID.Text.Trim();
                    string sVenCode = gridView2.GetRowCellValue(i, gridCol_��Ӧ�̱���).ToString().Trim();

                    if (bChoose)
                    {
                        decimal d���� = ReturnObjectToDecimal(gridView2.GetRowCellValue(i, gridCol_����), 6);
                        if (d���� == 0)
                        {
                            sErr = sErr + "��" + (i + 1).ToString() + "��Ӧ��δ����\n";
                            continue;
                        }

                        sSQL = "update UFDLImport..ѯ�۵���Ӧ�̱��� set �������� = 'ͨ��',������ = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "',�������� = getdate() where ��Ӧ�̱��� = '" + sVenCode + "' and [GUID] = '" + sGuid + "' and GUID���� = '" + sGuid���� + "'";
                        aList.Add(sSQL);

                        b = true;
                    }
                    else
                    {
                        sSQL = "update UFDLImport..ѯ�۵���Ӧ�̱��� set �������� = '��ͨ��',������ = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "',�������� = getdate() where ��Ӧ�̱��� = '" + sVenCode + "' and [GUID] = '" + sGuid + "' and GUID���� = '" + sGuid���� + "'";
                        aList.Add(sSQL);
                    }
                }

                if (sErr.Trim() != "")
                {
                    throw new Exception(sErr);
                }

                if (!b)
                {
                    throw new Exception("��ѡ������");
                }

                clsSQLCommond.ExecSqlTran(aList);

                MessageBox.Show("��˳ɹ�");

                SetValue();

                //                //�����ʼ�


                //                //

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

      
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
select case when isnull(c.��������,'') = 'ͨ��' then CAST(1 as bit) else CAST(0 as bit) end as ѡ��
    , b.��Ӧ�̱���,d.cVenName as ��Ӧ��,aa.�Զ�������,aa.���ϱ���,c.����,aa.����,c.��������,aa.GUID����,aa.��ע1
	,e.������,c.������,c.��������,c.��������,c.[��Ӧ�̱�ע]
from UFDLImport..ѯ�۵� a inner join UFDLImport..ѯ�۵������б� aa on a.GUID = aa.GUID
	inner join UFDLImport..ѯ�۵���Ӧ�� b on a.GUID = b.GUID 
	left join UFDLImport..ѯ�۵���Ӧ�̱��� c on c.GUID = a.guid and aa.GUID���� = c.GUID���� and b.��Ӧ�̱��� = c.��Ӧ�̱���
	inner join @u8.vendor d on b.��Ӧ�̱��� = d.cVenCode
	left join UFDLImport..ѯ�۵����� e on e.GUID���� = aa.GUID����
where a.[GUID] = '111111'
order by aa.�Զ�������,aa.���ϱ���,b.��Ӧ�̱���

";
            sSQL = sSQL.Replace("111111", sGuid);
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl2.DataSource = dt;

            sSQL = @"
select a.* ,b.*,c.cVenName
from UFDLImport..ѯ�۵� a inner join UFDLImport..ѯ�۵���Ӧ�� b on a.GUID = b.GUID 
    left join @u8.Vendor c on b.��Ӧ�̱��� = c.cVenCode
where a.GUID = '111111'
";
            sSQL = sSQL.Replace("111111", sGuid);
             dt = clsSQLCommond.ExecQuery(sSQL);


            txt����.Text = dt.Rows[0]["����"].ToString().Trim();
            richTextBox��ע.Text = dt.Rows[0]["��ע"].ToString().Trim();
            dtm��ֹ.Text = Convert.ToDateTime(dt.Rows[0]["��ֹ����"]).ToString("yyyy-MM-dd");
            lookUpEditTime.EditValue = Convert.ToDateTime(dt.Rows[0]["��ֹ����"]).ToString("HH:ss");
            txt��ֹ����.Text = dt.Rows[0]["��ֹѯ������"].ToString().Trim();
            dtm��������.DateTime = Convert.ToDateTime(dt.Rows[0]["��������"]);
            txt�Ƶ���.EditValue = dt.Rows[0]["�Ƶ���"].ToString().Trim();
            date�Ƶ�����.Text = dt.Rows[0]["�Ƶ�����"].ToString().Trim();
            txt������.EditValue = dt.Rows[0]["������"].ToString().Trim();
            date_��������.Text = dt.Rows[0]["��������"].ToString().Trim();
        }


        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                dtm��������.DateTime = DateTime.Today;
                dtm��ֹ.DateTime = DateTime.Today;

                SetLookUp();

                SetValue();
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

        private void btn���_Click(object sender, EventArgs e)
        {
           
        }

//        private void btn��ͨ��_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                string sSQL = @"
//select a.* ,getdate() as ��ǰʱ��
//from ѯ�۵� a inner join ѯ�۵���Ӧ�� b on a.[GUID] = b.[GUID]
//where a.[GUID] = '111111' and b.��Ӧ�̱��� = '222222' 
//";
//                sSQL = sSQL.Replace("111111", sGuid);
//                sSQL = sSQL.Replace("222222", txt��Ӧ�̱���.Text.Trim());
//                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
//                if (dt == null || dt.Rows.Count == 0)
//                {
//                    throw new Exception("���ѯ�۵�ʧ��");
//                }
//                if (dt.Rows[0]["������"].ToString().Trim() == "")
//                {
//                    throw new Exception("��δ����");
//                }
//                DateTime d��ǰʱ�� = Convert.ToDateTime(dt.Rows[0]["��ǰʱ��"]);
//                DateTime d��ֹ���� = Convert.ToDateTime(dt.Rows[0]["��ֹ����"]);
//                DateTime d��ֹ���� = Convert.ToDateTime("2099-12-31");
//                if (dt.Rows[0]["��ֹѯ������"].ToString().Trim() != "")
//                {
//                    d��ֹ���� = Convert.ToDateTime(dt.Rows[0]["��ֹѯ������"]);
//                }
//                if (d��ǰʱ�� < d��ֹ���� && d��ǰʱ�� < d��ֹ����)
//                {
//                    throw new Exception("��δ�����ޣ���������");
//                }

//                sSQL = "update ѯ�۵���Ӧ�� set �������� = '��ͨ��',����ʱ�� = getdate(),������ = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "' where guid = '" + sGuid + "' and ��Ӧ�̱��� = '" + txt��Ӧ�̱���.Text.Trim() + "'";

//                int iCou = clsSQLCommond.ExecSql(sSQL);
//                if (iCou > 0)
//                {
//                    MessageBox.Show("��˲�ͨ��");

//                    radio��ͨ��.Checked = true;
//                }
//            }
//            catch (Exception ee)
//            {
//                MessageBox.Show(ee.Message);
//            }
//        }

        private void btn�˳�_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
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

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int iRow = gridView2.FocusedRowHandle;
                if (Convert.ToBoolean(gridView2.GetRowCellValue(iRow, gridCol_ѡ��)))
                {
                    gridView2.SetRowCellValue(iRow, gridCol_ѡ��, false);
                }
                else
                {
                    gridView2.SetRowCellValue(iRow, gridCol_ѡ��, true);

                    string scInvCode = gridView2.GetRowCellValue(iRow, gridCol_cInvCode).ToString().Trim();
                    string s�Զ������� = gridView2.GetRowCellValue(iRow, gridCol_�Զ�������).ToString().Trim();

                    for (int i = 0; i < gridView2.RowCount; i++)
                    {
                        if (i == iRow)
                            continue;

                        string scInvCode2 = gridView2.GetRowCellValue(i, gridCol_cInvCode).ToString().Trim();
                        string s�Զ�������2 = gridView2.GetRowCellValue(i, gridCol_�Զ�������).ToString().Trim();

                        if (scInvCode == scInvCode2 && s�Զ������� == s�Զ�������2)
                        {
                            gridView2.SetRowCellValue(i, gridCol_ѡ��, false);
                        }
                    }
                }
            }
            catch { }
        }

        private void gridView2_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            try
            {
                if ((this.gridView2.GetDataRow(e.RowHandle1)["���ϱ���"].ToString() != this.gridView2.GetDataRow(e.RowHandle2)["���ϱ���"].ToString())
                    || (this.gridView2.GetDataRow(e.RowHandle1)["�Զ�������"].ToString() != this.gridView2.GetDataRow(e.RowHandle2)["�Զ�������"].ToString())
                    )
                    e.Handled = true;
            }
            catch { }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Audit_Click(object sender, EventArgs e)
        {
            btnAudit();
        }

        private void btn_UnAudit_Click(object sender, EventArgs e)
        {
            btnUnAudit();
        }
    }
}