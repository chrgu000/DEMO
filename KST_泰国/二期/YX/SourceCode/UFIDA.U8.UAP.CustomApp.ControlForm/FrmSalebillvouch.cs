using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using BaseClass;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class FrmSalebillvouch : UserControl
    {
        //public class CmbDataSource
        //{
        //    public string WareHouseCode;
        //    public string WareHouseName;
        //}

        //public class UserMsg
        //{
        //    public string UserCode;
        //    public string UserName;
        //}


        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        string sSQL;

        public FrmSalebillvouch()
        {
            InitializeComponent();
        }


        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                gridView1.PostEditor();
                this.Validate();

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
                MessageBox.Show("�����б�ʧ�ܣ�" + ee.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                FrmSalebillvouch_Add frm = new FrmSalebillvouch_Add(Conn, sUserID, sUserName, sLogDate, sAccID);
                DialogResult d = frm.ShowDialog();
                if (d != DialogResult.OK)
                {
                    //MessageBox.Show("ȡ������");
                    return;
                }
                else
                {
                    btnReflash_Click(null, null);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("������������ʧ�ܣ�" + ee.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int iRow = gridView1.FocusedRowHandle;
                if (iRow >= 0)
                {
                    string cSBVCode = gridView1.GetRowCellValue(iRow, gridColcSBVCode).ToString();

                    FrmSalebillvouch_Add frm = new FrmSalebillvouch_Add(Conn, sUserID, sUserName, sLogDate, sAccID, cSBVCode);
                    DialogResult d = frm.ShowDialog();
                    if (d != DialogResult.OK)
                    {
                        //MessageBox.Show("ȡ������");
                        return;
                    }
                    else
                    {
                        btnReflash_Click(null, null);
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("������������ʧ�ܣ�" + ee.Message);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void SetLookUp()
        {
            sSQL = "select cCusCode,cCusName from Customer order by cCusCode";
            DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            lookUpEdit�ͻ�����.Properties.DataSource = dt;

            sSQL = "select cDLCode from DispatchList order by cDLCode desc";
            dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditcCode1.Properties.DataSource = dt;
            lookUpEditcCode2.Properties.DataSource = dt;

        }

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookUp();
                btnReflash_Click(null, null);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }


        private void btnReflash_Click(object sender, EventArgs e)
        {
            try
            {
                sSQL = @"
select b.SBVID,b.cSBVCode,b.cCusCode,c.cCusName,b.cPersonCode,p.cPersonName,b.cDepCode,d.cDepName,convert(nvarchar(10),b.dDate,120) as dDate,b.cVerifier 
from (select distinct SaleBillCode from _DispatchLists_SaleBillVouchs) ds 
left join SaleBillVouch b on ds.SaleBillCode=b.cSBVCode  
left join Customer c on b.cCusCode=c.cCusCode
LEFT JOIN Person P ON b.cPersonCode=p.cPersonCode
left join Department d on b.cDepCode=d.cDepCode where 1=1 
";

                if (lookUpEditcCode1.Text != "")
                {
                    sSQL = sSQL.Replace("1=1", " 1=1 and b.cSBVCode >= '" + lookUpEditcCode1.Text + "'");
                }
                if (lookUpEditcCode2.Text != "")
                {
                    sSQL = sSQL.Replace("1=1", " 1=1 and b.cSBVCode <= '" + lookUpEditcCode2.Text + "'");
                }
                if (dateEdit1.Text != "")
                {
                    sSQL = sSQL.Replace("1=1", " 1=1 and convert(nvarchar(10),b.dDate,120) >= convert(nvarchar(10),'" + dateEdit1.Text + "',120)");
                }
                if (dateEdit2.Text != "")
                {
                    sSQL = sSQL.Replace("1=1", " 1=1 and convert(nvarchar(10),b.dDate,120) >= convert(nvarchar(10),'" + dateEdit2.Text + "',120)");
                }
                if (lookUpEdit�ͻ�����.EditValue != null && lookUpEdit�ͻ�����.EditValue.ToString().Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", " 1=1 and b.cCusCode = '" + lookUpEdit�ͻ�����.EditValue.ToString().Trim() + "'");
                }

                DataTable dtGrid = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                gridControl1.DataSource = dtGrid;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }


        private void buttonEdit�ͻ�_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                FrmCustomer frm = new FrmCustomer(buttonEdit�ͻ�.Text.ToString(), Conn, true);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    buttonEdit�ͻ�.EditValue = frm.sCusCode;
                    lookUpEdit�ͻ�����.EditValue = frm.sCusCode;

                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit�ͻ�_Leave(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit�ͻ�.Text.Trim() != "")
                {
                    lookUpEdit�ͻ�����.EditValue = buttonEdit�ͻ�.Text.Trim();

                    if (lookUpEdit�ͻ�����.EditValue == null || lookUpEdit�ͻ�����.Text.Trim() == "")
                    {
                        MessageBox.Show("�ÿͻ����벻����");
                        buttonEdit�ͻ�.Focus();
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit�ͻ�_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEdit�ͻ�����.EditValue = buttonEdit�ͻ�.Text.Trim();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }


    }
}