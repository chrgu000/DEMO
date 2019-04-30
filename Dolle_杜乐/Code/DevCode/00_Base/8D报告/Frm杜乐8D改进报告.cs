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
    public partial class Frm����8D�Ľ����� : FrameBaseFunction.Frm�б���ģ��
    {
        //TH.BaseClsInfo.ClsDataBase clsSQLCommond = TH.BaseClsInfo.ClsDataBaseFactory.Instance();
        //FrameBaseFunction.ClsGetSQL clsGetSQL = new FrameBaseFunction.ClsGetSQL();
  
        DataTable dtSel = new DataTable();
        int iPage = 0;
        ArrayList aList;
        string sSQL;

        public Frm����8D�Ľ�����()
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

            string sSQL = @"
select cast(0 as bit) as ѡ��
    ,* 
from DolleDatabase.dbo._Bai_��������Ʒ�������� a
    left join UFDLImport.._8D���� b on a.id = b.idhead 
    left join opendatasource('SQLOLEDB','server=192.168.1.10;uid=sa;pwd=bpm@PASSWORD;database=BPMDB').BPMDB.dbo.BPMInstTasks c on a.TaskId = c.TaskId 
where �Ƿ��ύ8D�Ľ����� = '��' and 1=1 
    and c.state not in ('Deleted','Aborted') 
Order by id
";

            if (txtVenCode.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.���̱��� = '" + txtVenCode.Text.Trim() + "'");
            }
            if (radio������.Checked)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and isnull(b.idHead,0) = 0");
            }
            if (radio�Ѵ���.Checked)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and ((isnull(b.idHead,0) <> 0 and isnull(������,'') = '') or (isnull(b.idHead,0) <> 0 and isnull(������,'') <> '' and isnull(״̬,0) = 0 and isnull(�ٴ��ύ,'') <> '' ))");
            }
            if (radio����׼.Checked)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and isnull(b.idHead,0) <> 0 and isnull(������,'') <> '' and isnull(״̬,0) = 1");
            }
            if (radio�Ѿܾ�.Checked)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and isnull(b.idHead,0) <> 0 and isnull(������,'') <> '' and isnull(״̬,0) = 0 and isnull(�ٴ��ύ,'') = ''");
            }
          
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;
            gridView1.FocusedRowHandle = iFoc;

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
                txtVenCode.Properties.ReadOnly = false;

                string sSQL = "select vendCode,cVenName from [UFDLImport].._vendUid left join @u8.Vendor on @u8.Vendor.cVenCode = vendCode where uid = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "'  and accid = 200 and accyear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + " ";
                DataTable dt =clsSQLCommond.ExecQuery(sSQL);

                if (FrameBaseFunction.ClsBaseDataInfo.sUid == "admin" || dt.Rows.Count == 0)
                {
                    txtVenCode.Enabled = true;
                }
                else
                {
                    if (dt.Rows[0]["vendCode"].ToString().Trim() == string.Empty)
                    {
                        txtVenCode.Enabled = true;
                    }
                    else
                    {
                        txtVenCode.Enabled = false;
                    }
                    txtVenCode.Text = dt.Rows[0]["vendCode"].ToString().Trim();
                    txtVenCode_Leave(null, null);
                }  

                btnSel();
            }
            catch (Exception ee)
            {
                MessageBox.Show("���ش���ʧ��\n" + ee.Message);
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

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView1.FocusedRowHandle > 0)
                    iRow = gridView1.FocusedRowHandle;

                long iID = ReturnObjectToLong(gridView1.GetRowCellValue(iRow, gridColiID));
                if (iID != 0)
                {
                    Frm����8D�Ľ�����Edit f = new Frm����8D�Ľ�����Edit(iID);
                    f.MdiParent = this.MdiParent;
                    f.Tag = f.Text;
                    f.Show();

                    btnSel();
                    gridView1.FocusedRowHandle = iRow;
                }
            }
            catch { }
        }

        private void txtVenCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmVenInfo fVen = new FrmVenInfo(txtVenCode.Text.Trim());
            if (DialogResult.OK == fVen.ShowDialog())
            {
                txtVenCode.Text = fVen.sVenCode;
                txtVenName.Text = fVen.sVenName;
            }
        }

        private void txtVenCode_Leave(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = GetVendor(txtVenCode.Text.Trim());
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtVenName.Text = dt.Rows[0]["iText"].ToString().Trim();
                    btnSel();
                }
                else
                {
                    txtVenCode.Text = "";
                    txtVenName.Text = "";
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("��ù�Ӧ����Ϣʧ�ܣ� " + ee.Message);
            }
        }


        private DataTable GetVendor(string sVenCode)
        {
            try
            {
                //FrameBaseFunction.ClsGetSQL clsGetSQL = new FrameBaseFunction.ClsGetSQL();
                string sSQL = "select cVenCode as iID,cVenName as iText from @u8.Vendor where cVenCode = '" + sVenCode + "' order by cVenCode";
                DataTable dt = clsGetSQL.GetLookUpEdit(sSQL);
                return dt;
            }
            catch
            {
                throw new Exception("��ù�Ӧ����Ϣʧ�ܣ�");
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
            catch { }
        }

        private void Frm����8D�Ľ�����_Activated(object sender, EventArgs e)
        {
            try
            {
                btnSel();
            }
            catch { }
        }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                btnSel();
            }
            catch { }
        }
    }
}