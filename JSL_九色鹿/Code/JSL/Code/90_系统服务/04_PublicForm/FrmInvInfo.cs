using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 系统服务
{
    public partial class FrmInvInfo : Form
    {
        系统服务.ClsDataBase clsSQL = 系统服务.ClsDataBaseFactory.Instance();

        public string sInvCode = "";
        public string sInvName = "";

        public FrmInvInfo(string sInv)
        {
            InitializeComponent();

            txtInv.Text = sInv;
        }

        private void FrmInvInfo_Load(object sender, EventArgs e)
        {
            try
            {
                GetInvClass();

                if(txtInv.Text.Trim() != "")
                    GetInv();
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得存货参照失败！  " + ee.Message);
            }
        }

        private void GetInv()
        {

            string sSQL = "select * from @u8.Inventory where 1=1 ";
            if (txtInv.Text.Trim() != string.Empty)
            {
                sSQL = sSQL + " and (cInvCode like '%" + txtInv.Text.Trim() + "%' or cInvName like '%" + txtInv.Text.Trim() + "%') ";
            }

            sSQL = sSQL + " order by cInvCode,cInvCCode";
            DataTable dt = clsSQL.ExecQuery(sSQL);
            gridControl1.DataSource = dt;
        }

        private void GetInvClass()
        {
            try
            {
                string sSQL = "select cInvCCode,cInvCName,iInvCGrade,bInvCEnd from @u8.InventoryClass  order by cInvCCode";
                DataTable dt = clsSQL.ExecQuery(sSQL);

                TreeNode tn;
                TreeNode tn2;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dt.Rows[i]["iInvCGrade"]) == 1)
                    {
                        tn = new TreeNode();
                        tn.Tag = dt.Rows[i]["cInvCCode"].ToString().Trim();
                        tn.Text = dt.Rows[i]["cInvCCode"].ToString().Trim() + "  " + dt.Rows[i]["cInvCName"].ToString().Trim();
                        treeView1.Nodes.Add(tn);
                    }
                    else
                    {
                        int iGrade = Convert.ToInt32(dt.Rows[i]["iInvCGrade"]);
                        int iGradeParent = iGrade - 1;

                        foreach (TreeNode tn1 in treeView1.Nodes)
                        {
                            if (tn1.Level == iGradeParent - 1 && dt.Rows[i]["cInvCCode"].ToString().Trim().StartsWith(tn1.Tag.ToString().Trim()))
                            {

                                tn2 = new TreeNode();
                                tn2.Tag = dt.Rows[i]["cInvCCode"].ToString().Trim();
                                tn2.Text = dt.Rows[i]["cInvCCode"].ToString().Trim() + "  " + dt.Rows[i]["cInvCName"].ToString().Trim();
                                tn1.Nodes.Add(tn2);
                            }
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                throw new Exception("获得存货分类失败！  " + ee.Message);
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string sSQL = "select * from @u8.Inventory  where 1=1 and cInvCode like '" + e.Node.Tag.ToString().Trim() + "%' ";
            if (txtInv.Text.Trim() != string.Empty)
            {
                sSQL = sSQL + " and (cInvCode like '%" + txtInv.Text.Trim() + "%' or cInvName like '%" + txtInv.Text.Trim() + "%') ";
            }

            sSQL = sSQL + " order by cInvCode,cInvCCode";
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

                sInvCode = gridView1.GetRowCellValue(iRow, gridColcInvCode).ToString().Trim();
                sInvName = gridView1.GetRowCellValue(iRow, gridColcInvName).ToString().Trim();

                DialogResult = DialogResult.OK;
            }
            catch (Exception ee)
            {
                MessageBox.Show("返回存货信息失败！  " + ee.Message);
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

                sInvCode = gridView1.GetRowCellValue(iRow, gridColcInvCode).ToString().Trim();
                sInvName = gridView1.GetRowCellValue(iRow, gridColcInvName).ToString().Trim();

                DialogResult = DialogResult.OK;
            }
            catch (Exception ee)
            {
                MessageBox.Show("返回存货信息失败！  " + ee.Message);
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