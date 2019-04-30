using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class Frm����Ԥ���Ʒ������� : Form
    {
        public string Conn { get; set; }

        public DataTable dtGrid;

        public Frm����Ԥ���Ʒ�������(string conn)
        {
            InitializeComponent();
            Conn = conn;
        }



        private void Frm����Ԥ���Ʒ�������_Load(object sender, EventArgs e)
        {
            try
            {
                dtGrid = new DataTable();
                dateEdit1.DateTime = DateTime.Now.AddMonths(-1);
                dateEdit2.DateTime = DateTime.Now;

                ϵͳ����.���.GetGridViewSet(gridView1);

                SetLookUp();
            }
            catch (Exception ee)
            {
                MessageBox.Show("������۳��ⵥ��ϸ��Ϣʧ�ܣ�  " + ee.Message);
            }
        }

        private void SetLookUp()
        {
            string sSQL = "select cCode from SA_PreOrderMain order by cCode";
            DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditcCode1.Properties.DataSource = dt;
            lookUpEditcCode2.Properties.DataSource = dt;

            sSQL = @"
select cInvCode ,cInvName,cInvStd,a.cComunitCode ,b.cComUnitName
from Inventory a left join ComputationUnit b on a.cComunitCode = b.cComunitCode 
order by cInvCode
";
            dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            ItemLookUpEditcInvCode.DataSource = dt;
            ItemLookUpEditcInvName.DataSource = dt;
            ItemLookUpEditcInvStd.DataSource = dt;
            ItemLookUpEditcComUnitName.DataSource = dt;

            sSQL = "select cCusCode,cCusName from Customer order by cCusCode";
            dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            lookUpEdit�ͻ�����.Properties.DataSource = dt;
            ItemLookUpEditcCusCode.DataSource = dt;
            ItemLookUpEditcCusName.DataSource = dt;

            sSQL = "select cDepCode,cDepName from Department order by cDepCode";
            dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            ItemLookUpEditcDepCode.DataSource = dt;
            ItemLookUpEditcDepName.DataSource = dt;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            try
            {
                dtGrid = new DataTable();

                string sSQL = @"
select cast(0 as bit) as ѡ��,convert(nvarchar(50),null) cPosition, *,isnull(b.iQuantity,0) - isnull(cDefine26,0)  as UniQty,cast(null as decimal(16,6)) as UniNum
    ,cast(i.cInvStd as varchar(120)) as cBatchProperty6,cast(null as varchar(120)) as cBatchProperty7,cast(null as varchar(120)) as cBatchProperty8,cast(null as varchar(120)) as cBatchProperty9
,isnull(cDefine26,0) as iSumQty,p.cPersonName
from SA_PreOrderMain a inner join SA_PreOrderDetails b on a.id = b.id
	left join (select sum(iQuantity) as iQty,SA_PreOrderDetailsID from rdrecords10 group by SA_PreOrderDetailsID) c on b.autoid = c.SA_PreOrderDetailsID 
left join Inventory i on b.cInvCode=i.cInvCode
LEFT JOIN Person P ON a.cPersonCode=p.cPersonCode
where isnull(b.cSCloser,'') = '' and isnull(a.cCloser,'') = '' and 1=1
order by b.autoid
";
                if (!chk��������ѳ�����.Checked)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(b.iQuantity,0) > isnull(cDefine26,0) ");
                }
                if (lookUpEditcCode1.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cCode >= '" + lookUpEditcCode1.Text.Trim() + "'");
                }
                if (lookUpEditcCode2.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cCode <= '" + lookUpEditcCode2.Text.Trim() + "'");
                }
                if (dateEdit1.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.dDate >= '" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "'");
                }
                if (dateEdit2.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.dDate <= '" + dateEdit2.DateTime.ToString("yyyy-MM-dd") + "'");
                }
                if (lookUpEdit�ͻ�����.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cCusCode = '" + lookUpEdit�ͻ�����.EditValue.ToString().Trim() + "'");
                }

                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    decimal dNum = TH.BaseClass.BaseFunction.ReturnDecimal(dt.Rows[i]["iNum"]);
                    if (dNum == 0)
                    {
                        continue;
                    }

                    decimal dQty = TH.BaseClass.BaseFunction.ReturnDecimal(dt.Rows[i]["iQuantity"]);
                    decimal dUnQty = TH.BaseClass.BaseFunction.ReturnDecimal(dt.Rows[i]["UniNum"]);
                    decimal dUnNum = TH.BaseClass.BaseFunction.ReturnDecimal(dUnQty * dNum / dNum);

                    dt.Rows[i]["UniNum"] = dUnNum;
                }

                gridControl1.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void chk��������ѳ�����_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridColѡ��, chkAll.Checked);
                }
            }
            catch { }
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

        private void btn���_Click(object sender, EventArgs e)
        {
            try
            {
                lookUpEditcCode1.EditValue = null;
                lookUpEditcCode2.EditValue = null;
                dateEdit1.DateTime = DateTime.Now.AddMonths(-1);
                dateEdit2.DateTime = DateTime.Now;
                buttonEdit�ͻ�.Text = "";
                lookUpEdit�ͻ�����.EditValue = null;
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                if (gridView1.RowCount <= 0)
                {
                    throw new Exception("��ѡ������Ԥ�ⵥ");
                }

                string sCusCode = "";
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (!Convert.ToBoolean(gridView1.GetRowCellValue(i, gridColѡ��)))
                        continue;

                    if (sCusCode == "")
                    {
                        sCusCode = gridView1.GetRowCellValue(i, gridColcCusCode).ToString().Trim();
                    }
                    else if (sCusCode != gridView1.GetRowCellValue(i, gridColcCusCode).ToString().Trim())
                    {
                        throw new Exception("����ѡ����ͬ�ͻ�");
                    }
                }

                DataTable dtTable = (DataTable)gridControl1.DataSource;
                for(int i=0;i<dtTable.Rows.Count;i++)
                {
                    dtTable.Rows[i]["cItemCode"] = "��������";
                    dtTable.Rows[i]["cPosition"] = "0220";
                }
                DataTable dt = dtTable.Copy();
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    if (!Convert.ToBoolean(dt.Rows[i]["ѡ��"]))
                    {
                        dt.Rows.RemoveAt(i);
                    }
                }

                dtGrid = dt.Copy();

                DialogResult = DialogResult.OK;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}