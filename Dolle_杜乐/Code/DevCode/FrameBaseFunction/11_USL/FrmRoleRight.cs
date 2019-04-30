using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FrameBaseFunction
{
    public partial class FrmRoleRight : FrameBaseFunction.Frm列表窗体模板
    {
        FrameBaseFunction.Query.ClsRoleRight clsRoleRight = new FrameBaseFunction.Query.ClsRoleRight();

        public FrmRoleRight()
        {
            InitializeComponent();
        }

        DataTable dt;
        private void FrmRoleRight_Load(object sender, EventArgs e)
        {
            try
            {
                GetGridInfo();

                base.SetBtnEnable(false);
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败！ 原因如下：\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 获得角色信息表格值
        /// </summary>
        private void GetGridInfo()
        {
            FrameBaseFunction.Query.ClsRoleInfoQuery clsQuery = new FrameBaseFunction.Query.ClsRoleInfoQuery();
            DataTable dt = clsQuery.GetAllDt();
            gridControl1.DataSource = dt;
        }

        /// <summary>
        /// 创建功能树
        /// </summary>
        /// <param name="Nds"></param>
        /// <param name="parentId"></param>
        private void InitTree(TreeNodeCollection Nds, string parentId)
        {
            DataView dv = new DataView();
            TreeNode tmpNd;
            string intId;
            dv.Table = dt;
            dv.RowFilter = "fchrFrmUpName='" + parentId + "'";
            foreach (DataRowView drv in dv)
            {
                tmpNd = new TreeNode();
                tmpNd.Name = drv["fchrFrmNameID"].ToString().Trim();
                tmpNd.Text = drv["fchrFrmText"].ToString().Trim();
                //tmpNd.Text = drv["sInfo"].ToString().Trim();
                tmpNd.Tag = drv["sInfo"].ToString().Trim();

                if (drv["bChoosed"].ToString().Trim() == "√")
                    tmpNd.Checked = true;
                else
                    tmpNd.Checked = false;
                Nds.Add(tmpNd);
                intId = drv["fchrFrmUpName"].ToString().Trim();
                InitTree(tmpNd.Nodes, tmpNd.Name);

                
            }
        }

        private int GetFocRow()
        {
            int iRow = 0;
            if (gridView1.RowCount > 1)
                iRow = gridView1.FocusedRowHandle;

            return iRow;
        }

        private string GetFocValuePK()
        {
            if (gridView1.RowCount > 0)
            {
                return gridView1.GetRowCellValue(GetFocRow(), colvchrRoleID).ToString().Trim();
            }
            else
                return null;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.RowCount < 1)
                return;

            string sValuePK = GetFocValuePK();

            treView.Nodes.Clear();
            dt = clsRoleRight.GetTreeInfo(sValuePK);
            InitTree(treView.Nodes, "0");

            //treView.ExpandAll();
        }

        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "save":
                        btnSave();
                        break;
                    default:
                        break;
                }

                MessageBox.Show(sBtnText + "成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ee)
            {
                MessageBox.Show(sBtnText + " 失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        DataTable dtTre;
        private void btnSave()
        {
            string sRoleID = GetFocValuePK();
            if (sRoleID.ToLower() == "administrator")
            {
                gridView1_FocusedRowChanged(null, null);
                throw new Exception("administrator是默认角色，不能修改权限！");
            }

            FrameBaseFunction.Bll.ClsRoleRightBll clsBll = new FrameBaseFunction.Bll.ClsRoleRightBll();

            dtTre = new DataTable();
            DataColumn dc = new DataColumn("bChoosed");
            dtTre.Columns.Add(dc);
            dc = new DataColumn("vchrRoleRight");
            dtTre.Columns.Add(dc);

            GetAllNodeText(treView.Nodes);

            clsBll.Add(sRoleID, dtTre);
        }

        void GetAllNodeText(TreeNodeCollection tnc)
        {
            foreach (TreeNode node in tnc)
            {
                if (node.Nodes.Count != 0)
                    GetAllNodeText(node.Nodes);
                //Response.Write(node.Text + "   ");

                if (node.Checked)
                {
                    DataRow dr = dtTre.NewRow();
                    dr["bChoosed"] = true;
                    dr["vchrRoleRight"] = node.Tag.ToString().Trim();
                    dtTre.Rows.Add(dr);
                }
            }
        }

        private void treView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                string sRoleID = GetFocValuePK();
                if (sRoleID.ToLower() == "administrator")
                {
                    gridView1_FocusedRowChanged(null, null);
                    throw new Exception("administrator是默认角色，不能修改权限！");
                }

                treView.AfterCheck -= new TreeViewEventHandler(treView_AfterCheck);
                if (!e.Node.Checked)
                {
                    GetChildNodes(e.Node);
                }
                else
                {
                    GetParentNodes(e.Node);
                }
                treView.AfterCheck += new TreeViewEventHandler(treView_AfterCheck);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
         
            }
        }

        private void GetChildNodes(TreeNode tnParent)
        {
            if (tnParent != null)
            {
                foreach (TreeNode tn in tnParent.Nodes)
                {
                    tn.Checked = false;
                    GetChildNodes(tn);
                }
            }
        }
        private void GetParentNodes(TreeNode CurrentNode)
        {
            if (CurrentNode.Parent != null)
            {
                CurrentNode.Parent.Checked = true;
                this.GetParentNodes(CurrentNode.Parent);
            }
        }
    }
}