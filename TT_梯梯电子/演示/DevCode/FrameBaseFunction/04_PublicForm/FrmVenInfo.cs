using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FrameBaseFunction
{
    public partial class FrmVenInfo : Form
    {
        FrameBaseFunction.ClsDataBase clsSQL = FrameBaseFunction.ClsDataBaseFactory.Instance();

        public string sVenCode = "";
        public string sVenName = "";
        
        public FrmVenInfo(string sVen)
        {
            InitializeComponent();

            txtVen.Text = sVen;
        }

        private void FrmVenInfo_Load(object sender, EventArgs e)
        {
            try
            {
                GetVendorClass();

                GetVen();
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得供应商参照失败！  " + ee.Message);
            }
        }

        private void GetVen()
        {

            string sSQL = "select * from @u8.Vendor where 1=1 ";
            if (txtVen.Text.Trim() != string.Empty)
            {
                sSQL = sSQL + " and (cVenCode like '%" + txtVen.Text.Trim() + "%' or cVenName like '%" + txtVen.Text.Trim() + "%') ";
            }

            sSQL = sSQL + " order by cVenCode,cVCCode";
            DataTable dt = clsSQL.ExecQuery(sSQL);
            gridControl1.DataSource = dt;
        }

        private void GetVendorClass()
        {
            try
            {
                string sSQL = "select cVCCode,cVCName,iVCGrade,bVCEnd from @u8.VendorClass order by cVCCode";
                DataTable dt = clsSQL.ExecQuery(sSQL);

                TreeNode tn;
                TreeNode tn2;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dt.Rows[i]["iVCGrade"]) == 1)
                    {
                        tn = new TreeNode();
                        tn.Tag = dt.Rows[i]["cVCCode"].ToString().Trim();
                        tn.Text = dt.Rows[i]["cVCCode"].ToString().Trim() + "  " + dt.Rows[i]["cVCName"].ToString().Trim();
                        treeView1.Nodes.Add(tn);
                    }
                    else
                    {
                        int iGrade = Convert.ToInt32(dt.Rows[i]["iVCGrade"]);
                        int iGradeParent = iGrade - 1;

                        foreach (TreeNode tn1 in treeView1.Nodes)
                        {
                            if (tn1.Level == iGradeParent - 1 && dt.Rows[i]["cVCCode"].ToString().Trim().StartsWith(tn1.Tag.ToString().Trim()))
                            {

                                tn2 = new TreeNode();
                                tn2.Tag = dt.Rows[i]["cVCCode"].ToString().Trim();
                                tn2.Text = dt.Rows[i]["cVCCode"].ToString().Trim() + "  " + dt.Rows[i]["cVCName"].ToString().Trim();
                                tn1.Nodes.Add(tn2);
                            }
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                throw new Exception("获得供应商分类失败！  " + ee.Message);
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string sSQL = "select * from @u8.Vendor where 1=1 and cVCCode like '" + e.Node.Tag.ToString().Trim() + "%' ";
            if (txtVen.Text.Trim() != string.Empty)
            {
                sSQL = sSQL + " and (cVenCode like '%" + txtVen.Text.Trim() + "%' or cVenName like '%" + txtVen.Text.Trim() + "%') ";
            }

            sSQL = sSQL + " order by cVenCode,cVCCode";
            DataTable dt = clsSQL.ExecQuery(sSQL);
            gridControl1.DataSource = dt;
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

                sVenCode = gridView1.GetRowCellValue(iRow, gridColcVenCode).ToString().Trim();
                sVenName = gridView1.GetRowCellValue(iRow, gridColcVenName).ToString().Trim();

                DialogResult = DialogResult.OK;
            }
            catch (Exception ee)
            {
                MessageBox.Show("返回供应商信息失败！  " + ee.Message);
            }
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

                sVenCode = gridView1.GetRowCellValue(iRow, gridColcVenCode).ToString().Trim();
                sVenName = gridView1.GetRowCellValue(iRow, gridColcVenName).ToString().Trim();

                DialogResult = DialogResult.OK;
            }
            catch (Exception ee)
            {
                MessageBox.Show("返回供应商信息失败！  " + ee.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
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