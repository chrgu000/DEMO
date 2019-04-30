using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FrameBaseFunction
{
    public partial class FrmInvPrice : Form
    {
        string sInvCode;
        public double dTaxPrice = 0;
        public double dTaxRate = 0;


        FrameBaseFunction.ClsDataBase clsSQL = FrameBaseFunction.ClsDataBaseFactory.Instance();

        /// <summary>
        /// 供应商存货价格
        /// </summary>
        /// <param name="sInv">存货编码</param>
        public FrmInvPrice(string sInv)
        {
            InitializeComponent();

            sInvCode = sInv;
        }

        private void FrmInvPrice_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dtPrice = new DataTable();

                string sSQL = @"
select distinct cVenCode 
from
(

SELECT DISTINCT p.cVenCode 
FROM @u8.PO_Pomain p inner join @u8.PO_Podetails ps on p.POID = ps.POID inner join @u8.Vendor v on v.cVenCode = p.cVenCode  
WHERE ps.cInvCode = '{0}' and isnull(iUnitPrice,0) <> 0  

union all

SELECT DISTINCT om.cVenCode 
FROM @u8.OM_MOMain om inner join @u8.OM_MODetails oms on om.moid = oms.moid inner join @u8.Vendor v on v.cVenCode = om.cVenCode  
WHERE oms.cInvCode = '{0}' and isnull(iUnitPrice,0) <> 0  
) a 
order by cVenCode
";

                sSQL = string.Format(sSQL, sInvCode);
                DataTable dt = clsSQL.ExecQuery(sSQL);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sSQL = @"
select *
from 
(
select distinct top 5 ps.iPerTaxRate as iPerTaxRate,ps.cInvCode,I.cInvName,I.cInvStd,ps.iQuantity as iQty,p.cVenCode,v.cVenName,p.cPOID,p.dPODate,iUnitPrice,ps.iTaxPrice 
from @u8.PO_Pomain p inner join @u8.PO_Podetails ps on p.POID = ps.POID inner join @u8.Vendor v on v.cVenCode = p.cVenCode inner join @u8.Inventory I on I.cInvCode = ps.cInvCode
where ps.cInvCode = '{0}' and isnull(iUnitPrice,0) <> 0 AND p.cVenCode = '{1}'
order by p.cPOID desc

union all

select distinct top 5 ps.iPerTaxRate as iPerTaxRate,ps.cInvCode,I.cInvName,I.cInvStd,ps.iQuantity as iQty,p.cVenCode,v.cVenName,p.cCode ,p.dDate ,iUnitPrice,ps.iTaxPrice 
from @u8.OM_MOMain p inner join @u8.OM_MODetails ps on p.moid = ps.moid inner join @u8.Vendor v on v.cVenCode = p.cVenCode inner join @u8.Inventory I on I.cInvCode = ps.cInvCode
where ps.cInvCode = '{0}' and isnull(iUnitPrice,0) <> 0 AND p.cVenCode = '{1}'
order by p.cCode desc
) a 
order by cVenCode,cInvCode,dPODate desc

";

                        sSQL = string.Format(sSQL, sInvCode, dt.Rows[i]["cVenCode"].ToString().Trim());
                        DataTable dtTemp = clsSQL.ExecQuery(sSQL);

                        if (dtTemp != null && dtTemp.Rows.Count > 0)
                        {
                            if (dtPrice == null || dtPrice.Rows.Count == 0)
                            {
                                dtPrice = dtTemp.Copy();
                            }
                            else
                            {
                                for (int j = 0; j < dtTemp.Rows.Count; j++)
                                {
                                    DataRow dr = dtPrice.NewRow();

                                    for (int k = 0; k < dtTemp.Columns.Count; k++)
                                    {
                                        dr[k] = dtTemp.Copy().Rows[j][k];
                                    }

                                    dtPrice.Rows.Add(dr);
                                }
                            }
                        }
                    }
                }


                txtInvCode.Text = sInvCode;
                if (dtPrice != null && dtPrice.Rows.Count > 0)
                {
                    txtInvName.Text = dtPrice.Rows[0]["cInvName"].ToString().Trim();
                    txtInvStd.Text = dtPrice.Rows[0]["cInvStd"].ToString().Trim();

                    gridControl1.DataSource = dtPrice;
                }
                else
                {
                    MessageBox.Show("没有历史价格！");
                    Close();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得价格失败！  " + ee.Message);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView1.RowCount > 0)
                {
                    iRow = gridView1.FocusedRowHandle;
                }

                dTaxPrice = Convert.ToDouble(gridView1.GetRowCellValue(iRow, gridColiTaxPrice));
                dTaxRate = Convert.ToDouble(gridView1.GetRowCellValue(iRow, gridColiPerTaxRate)); 

                DialogResult = DialogResult.OK;
            }
            catch(Exception ee)
            {
                MessageBox.Show("返回物料价格失败！  " + ee.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView1.RowCount > 0)
                {
                    iRow = gridView1.FocusedRowHandle;
                }

                dTaxPrice = Convert.ToDouble(gridView1.GetRowCellValue(iRow, gridColiTaxPrice));

                DialogResult = DialogResult.OK;
                dTaxRate = Convert.ToDouble(gridView1.GetRowCellValue(iRow, gridColiPerTaxRate)); 
            }
            catch (Exception ee)
            {
                MessageBox.Show("返回物料价格失败！  " + ee.Message);
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