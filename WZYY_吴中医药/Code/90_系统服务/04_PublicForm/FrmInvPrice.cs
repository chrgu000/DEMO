using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 系统服务
{
    public partial class FrmInvPrice : Form
    {
        string sInvCode;
        public double dTaxPrice = 0;
        public double dTaxRate = 0;


        系统服务.ClsDataBase clsSQL = 系统服务.ClsDataBaseFactory.Instance();

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

                string sSQL = "SELECT DISTINCT p.cVenCode " +
                                "FROM @u8.PO_Pomain p inner join @u8.PO_Podetails ps on p.POID = ps.POID inner join @u8.Vendor v on v.cVenCode = p.cVenCode  " +
                                "WHERE ps.cInvCode = '" + sInvCode + "' and isnull(iUnitPrice,0) <> 0  " +
                                "ORDER BY p.cVenCode	";
                DataTable dt = clsSQL.ExecQuery(sSQL);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sSQL = "select distinct top 5 ps.iPerTaxRate as iPerTaxRate,ps.cInvCode,I.cInvName,I.cInvStd,ps.iQuantity as iQty,p.cVenCode,v.cVenName,p.cPOID,p.dPODate,iUnitPrice,ps.iTaxPrice " +
                               "from @u8.PO_Pomain p inner join @u8.PO_Podetails ps on p.POID = ps.POID inner join @u8.Vendor v on v.cVenCode = p.cVenCode inner join @u8.Inventory I on I.cInvCode = ps.cInvCode " +
                               "where ps.cInvCode = '" + sInvCode + "' and isnull(iUnitPrice,0) <> 0 AND p.cVenCode = '" + dt.Rows[i]["cVenCode"].ToString().Trim() + "' " +
                               "order by dPODate DESC";
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