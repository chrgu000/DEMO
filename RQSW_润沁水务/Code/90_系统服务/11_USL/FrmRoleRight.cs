using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 系统服务
{
    public partial class FrmRoleRight : 系统服务.FrmBaseInfo
    {
        系统服务.Query.ClsRoleRight clsRoleRight = new 系统服务.Query.ClsRoleRight();

        public FrmRoleRight()
        {
            InitializeComponent();
        }

        DataTable dt;
        private void FrmRoleRight_Load(object sender, EventArgs e)
        {
            try
            {
                gridControl2.Visible = false;

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
            系统服务.Query.ClsRoleInfoQuery clsQuery = new 系统服务.Query.ClsRoleInfoQuery();
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
                    case "export":
                        btnExport();
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

        private void btnExport()
        {
            try
            {
                string sSQL = @"
select a.vchrUid as 账号,vchrName as 姓名,d.vchrRoleRight as 权限,cast(null as varchar(50)) as 模块,cast(null as varchar(50)) as 窗体,cast(null as varchar(50)) as 按钮
from dbo._UserInfo a
	left join dbo._UserRoleInfo b on a.vchrUid = b.vchrUserID
	left join dbo._RoleInfo c on b.vchrRoleID = c.vchrRoleID
	left join dbo._RoleRight d on d.vchrRoleID = c.vchrRoleID
where d.vchrRoleRight like 'Frm%'
order by a.vchrUid,d.vchrRoleRight
";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                sSQL = "select * from _Form";
                DataTable dt窗体 = clsSQLCommond.ExecQuery(sSQL);

                sSQL = "select * from _BtnBaseInfo";
                DataTable dt按钮 = clsSQLCommond.ExecQuery(sSQL);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string s权限 = dt.Rows[i]["权限"].ToString().Trim();
                    string[] s = s权限.Split('|');

                    DataRow[] dr窗体 = dt窗体.Select(" fchrFrmNameID = '" + s[0] + "' ");
                    if (dr窗体.Length > 0)
                    {
                        dt.Rows[i]["模块"] = dr窗体[0]["fchrNameSpace"].ToString().Trim();
                        dt.Rows[i]["窗体"] = dr窗体[0]["fchrFrmText"].ToString().Trim();
                    }

                    DataRow[] dr按钮 = dt按钮.Select(" btnCode = '" + s[1] + "' ");
                    if (dr按钮.Length > 0)
                    {

                        dt.Rows[i]["按钮"] = dr按钮[0]["btnName"].ToString().Trim();
                    }
                }

               gridControl2.DataSource = dt;

                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
                sF.Filter = "Excel文件(*.xls)|*.xls|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridView2.ExportToXls(sF.FileName);
                    MessageBox.Show("导出Excel成功\n\t路径：" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                throw new Exception("导出失败:" + ee.Message);
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

            系统服务.Bll.ClsRoleRightBll clsBll = new 系统服务.Bll.ClsRoleRightBll();

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