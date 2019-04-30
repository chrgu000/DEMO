using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Warehouse.OMBack
{
    public partial class FrmInvClass : Form
    {
        public string SelClassCode = "";
        public string SelClassName = "";
        public FrmInvClass()
        {
            InitializeComponent();
        }

        private void FrmInvClass_Load(object sender, EventArgs e)
        {
            Dictionary<string, TreeNode> tree = new Dictionary<string, TreeNode>();

            string sql = "select * from dbo.InventoryClass order by  cInvCCode ";
            DataTable dt = SqlHelper.ExecuteDataset(Assistanter.U8ConnectString, CommandType.Text, sql).Tables[0];
            for (int i = 1; i < 99; i++)
            {
                DataRow[] classRows = dt.Select("iInvCGrade='" + i.ToString()+"'");
                foreach (DataRow row in classRows)
                {
                    string classCode = row["cInvCCode"].ToString();
                    string className = row["cInvCName"].ToString();
                    string parentCode = "";
                    if(i>1)
                        parentCode=classCode.Substring(0, (i-1)*2);
                    TreeNode node = new TreeNode();
                    if (tree.ContainsKey(parentCode))
                    {
                        node = tree[parentCode];
                        TreeNode newNode = new TreeNode();
                        newNode.Text =  classCode+" "+className;;
                        newNode.Tag = classCode;
                        node.Nodes.Add(newNode);
                        tree.Add(classCode,newNode);
                    }
                    else
                    {
                        node.Text = classCode+" "+className;
                        node.Tag = classCode;
                        trvClass.Nodes.Add(node);
                        tree.Add(classCode, node);
                    }

                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(trvClass .SelectedNode ==null)
            {
                MessageBox .Show ("请选择一个分类");
                return ;
            }
            TreeNode node =trvClass .SelectedNode ;
            SelClassCode =node.Tag .ToString ();
            SelClassName =node .Text ;
            DialogResult = DialogResult.OK ;
        }


    }
}
