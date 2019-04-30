using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class Frm销售预测产品入库生单 : Form
    {
        public string Conn { get; set; }

        public DataTable dtGrid;

        public Frm销售预测产品入库生单(string conn)
        {
            InitializeComponent();
            Conn = conn;
        }



        private void Frm销售预测产品入库生单_Load(object sender, EventArgs e)
        {
            try
            {
                dtGrid = new DataTable();
                dateEdit1.DateTime = DateTime.Now.AddMonths(-1);
                dateEdit2.DateTime = DateTime.Now;

                系统服务.规格化.GetGridViewSet(gridView1);

                SetLookUp();
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得销售出库单明细信息失败！  " + ee.Message);
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
            lookUpEdit客户名称.Properties.DataSource = dt;
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
select cast(0 as bit) as 选择,convert(nvarchar(50),null) cPosition, *,isnull(b.iQuantity,0) - isnull(cDefine26,0)  as UniQty,cast(null as decimal(16,6)) as UniNum
    ,cast(i.cInvStd as varchar(120)) as cBatchProperty6,cast(null as varchar(120)) as cBatchProperty7,cast(null as varchar(120)) as cBatchProperty8,cast(null as varchar(120)) as cBatchProperty9
,isnull(cDefine26,0) as iSumQty,p.cPersonName
from SA_PreOrderMain a inner join SA_PreOrderDetails b on a.id = b.id
	left join (select sum(iQuantity) as iQty,SA_PreOrderDetailsID from rdrecords10 group by SA_PreOrderDetailsID) c on b.autoid = c.SA_PreOrderDetailsID 
left join Inventory i on b.cInvCode=i.cInvCode
LEFT JOIN Person P ON a.cPersonCode=p.cPersonCode
where isnull(b.cSCloser,'') = '' and isnull(a.cCloser,'') = '' and 1=1
order by b.autoid
";
                if (!chk包含入库已超订单.Checked)
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
                if (lookUpEdit客户名称.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cCusCode = '" + lookUpEdit客户名称.EditValue.ToString().Trim() + "'");
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

        private void chk包含入库已超订单_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridCol选择, chkAll.Checked);
                }
            }
            catch { }
        }

        private void buttonEdit客户_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                FrmCustomer frm = new FrmCustomer(buttonEdit客户.Text.ToString(), Conn, true);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    buttonEdit客户.EditValue = frm.sCusCode;
                    lookUpEdit客户名称.EditValue = frm.sCusCode;

                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btn清空_Click(object sender, EventArgs e)
        {
            try
            {
                lookUpEditcCode1.EditValue = null;
                lookUpEditcCode2.EditValue = null;
                dateEdit1.DateTime = DateTime.Now.AddMonths(-1);
                dateEdit2.DateTime = DateTime.Now;
                buttonEdit客户.Text = "";
                lookUpEdit客户名称.EditValue = null;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit客户_Leave(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit客户.Text.Trim() != "")
                {
                    lookUpEdit客户名称.EditValue = buttonEdit客户.Text.Trim();

                    if (lookUpEdit客户名称.EditValue == null || lookUpEdit客户名称.Text.Trim() == "")
                    {
                        MessageBox.Show("该客户编码不存在");
                        buttonEdit客户.Focus();
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
                    throw new Exception("请选择销售预测单");
                }

                string sCusCode = "";
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (!Convert.ToBoolean(gridView1.GetRowCellValue(i, gridCol选择)))
                        continue;

                    if (sCusCode == "")
                    {
                        sCusCode = gridView1.GetRowCellValue(i, gridColcCusCode).ToString().Trim();
                    }
                    else if (sCusCode != gridView1.GetRowCellValue(i, gridColcCusCode).ToString().Trim())
                    {
                        throw new Exception("必须选择相同客户");
                    }
                }

                DataTable dtTable = (DataTable)gridControl1.DataSource;
                for(int i=0;i<dtTable.Rows.Count;i++)
                {
                    dtTable.Rows[i]["cItemCode"] = "常规物料";
                    dtTable.Rows[i]["cPosition"] = "0220";
                }
                DataTable dt = dtTable.Copy();
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    if (!Convert.ToBoolean(dt.Rows[i]["选择"]))
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