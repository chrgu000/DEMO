using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class FrmInvClassInfo : Form
    {
        public string txt = "";
        public string id = "";

        public string Conn { get; set; }

        public FrmInvClassInfo(string sInv, string conn)
        {
            Conn = conn;

            InitializeComponent();
            //textInvNew.Text = sInv;
        }

        private void FrmInvInfo_Load(object sender, EventArgs e)
        {
            try
            {
                GetInvClass();
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得存货参照失败！  " + ee.Message);
            }
        }

        private void GetInvClass()
        {
            try
            {
                string sSQL = "select cInvCCode,cInvCName,iInvCGrade,bInvCEnd from InventoryClass  order by cInvCCode";
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];

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
                        GetLev(tn, dt);
                    }
                }
            }
            catch (Exception ee)
            {
                throw new Exception("获得存货分类失败！  " + ee.Message);
            }
        }

        private void GetLev(TreeNode tn, DataTable dt)
        {
            DataRow[] dw = dt.Select("cInvCCode like '" + tn.Tag.ToString().Trim() + "%' and iInvCGrade='" + (1+tn.Tag.ToString().Trim().Length / 2) + "'");
            for (int i = 0; i < dw.Length; i++)
            {
                TreeNode tn1 = new TreeNode();
                tn1.Tag = dw[i]["cInvCCode"].ToString().Trim();
                tn1.Text = dw[i]["cInvCCode"].ToString().Trim() + "  " + dw[i]["cInvCName"].ToString().Trim();
                tn.Nodes.Add(tn1);
                GetLev(tn1, dt);
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                txt = treeView1.SelectedNode.Text.Trim();
                id = treeView1.SelectedNode.Tag.ToString().Trim();
                if (txt != "")
                {
                    DialogResult = DialogResult.OK;
                }
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

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                txt = treeView1.SelectedNode.Text.Trim();
                id = treeView1.SelectedNode.Tag.ToString().Trim();
                if (txt != "")
                {
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("返回存货信息失败！  " + ee.Message);
            }
        }
    }
}