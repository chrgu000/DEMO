using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ϵͳ����
{
    public partial class FrmRoleRight : ϵͳ����.FrmBaseInfo
    {
        ϵͳ����.Query.ClsRoleRight clsRoleRight = new ϵͳ����.Query.ClsRoleRight();

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
                MessageBox.Show("���ش���ʧ�ܣ� ԭ�����£�\n  " + ee.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ��ý�ɫ��Ϣ���ֵ
        /// </summary>
        private void GetGridInfo()
        {
            ϵͳ����.Query.ClsRoleInfoQuery clsQuery = new ϵͳ����.Query.ClsRoleInfoQuery();
            DataTable dt = clsQuery.GetAllDt();
            gridControl1.DataSource = dt;
        }

        /// <summary>
        /// ����������
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

                if (drv["bChoosed"].ToString().Trim() == "��")
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

                MessageBox.Show(sBtnText + "�ɹ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ee)
            {
                MessageBox.Show(sBtnText + " ʧ��! \n\nԭ��:\n  " + ee.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport()
        {
            try
            {
                string sSQL = @"
select a.vchrUid as �˺�,vchrName as ����,d.vchrRoleRight as Ȩ��,cast(null as varchar(50)) as ģ��,cast(null as varchar(50)) as ����,cast(null as varchar(50)) as ��ť
from dbo._UserInfo a
	left join dbo._UserRoleInfo b on a.vchrUid = b.vchrUserID
	left join dbo._RoleInfo c on b.vchrRoleID = c.vchrRoleID
	left join dbo._RoleRight d on d.vchrRoleID = c.vchrRoleID
where d.vchrRoleRight like 'Frm%'
order by a.vchrUid,d.vchrRoleRight
";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                sSQL = "select * from _Form";
                DataTable dt���� = clsSQLCommond.ExecQuery(sSQL);

                sSQL = "select * from _BtnBaseInfo";
                DataTable dt��ť = clsSQLCommond.ExecQuery(sSQL);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sȨ�� = dt.Rows[i]["Ȩ��"].ToString().Trim();
                    string[] s = sȨ��.Split('|');

                    DataRow[] dr���� = dt����.Select(" fchrFrmNameID = '" + s[0] + "' ");
                    if (dr����.Length > 0)
                    {
                        dt.Rows[i]["ģ��"] = dr����[0]["fchrNameSpace"].ToString().Trim();
                        dt.Rows[i]["����"] = dr����[0]["fchrFrmText"].ToString().Trim();
                    }

                    DataRow[] dr��ť = dt��ť.Select(" btnCode = '" + s[1] + "' ");
                    if (dr��ť.Length > 0)
                    {

                        dt.Rows[i]["��ť"] = dr��ť[0]["btnName"].ToString().Trim();
                    }
                }

               gridControl2.DataSource = dt;

                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
                sF.Filter = "Excel�ļ�(*.xls)|*.xls|�����ļ�(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridView2.ExportToXls(sF.FileName);
                    MessageBox.Show("����Excel�ɹ�\n\t·����" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                throw new Exception("����ʧ��:" + ee.Message);
            }
        }

        DataTable dtTre;
        private void btnSave()
        {
            string sRoleID = GetFocValuePK();
            if (sRoleID.ToLower() == "administrator")
            {
                gridView1_FocusedRowChanged(null, null);
                throw new Exception("administrator��Ĭ�Ͻ�ɫ�������޸�Ȩ�ޣ�");
            }

            ϵͳ����.Bll.ClsRoleRightBll clsBll = new ϵͳ����.Bll.ClsRoleRightBll();

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
                    throw new Exception("administrator��Ĭ�Ͻ�ɫ�������޸�Ȩ�ޣ�");
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
                MessageBox.Show(ee.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
         
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