using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;
using 系统服务;

namespace 基础设置
{
    public partial class Frm参照 : Form
    {
        int iClassType = 0;
        bool bList = true;
        bool bTree = true;

        public DataTable dtReturn;
        public string iID;
        public string iText;
        public string iText2;

        public Frm参照(int iType)
        {
            InitializeComponent();

            #region 禁止用户调整表格
            gridView1.OptionsMenu.EnableColumnMenu = false;
            gridView1.OptionsMenu.EnableFooterMenu = false;
            gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            gridView1.OptionsMenu.ShowAutoFilterRowItem = false;
            gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            gridView1.OptionsMenu.ShowGroupSummaryEditorItem = false;
            gridView1.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.False;
            gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            gridView1.OptionsCustomization.AllowColumnMoving = false;
            //gridView1.OptionsCustomization.

            #endregion

            dtReturn = new DataTable();

            DataColumn dc = new DataColumn();
            dc.ColumnName = "iID";
            dtReturn.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "iText";
            dtReturn.Columns.Add(dc);


            iClassType = iType;

            switch (iClassType)
            {
                case 1:
                    splitContainerControl1.Panel2.Visible = true;
                    gridControl1.Visible = true;
                    splitContainerControl1.SplitterPosition = this.Width / 4;
                    bList = true;
                    bTree = true;
                    break;
                case 2:
                    splitContainerControl1.Panel2.Visible = false;
                    gridControl1.Visible = false;
                    splitContainerControl1.SplitterPosition = this.Width;
                    bList = false;
                    bTree = true;
                    break;
                case 3:
                    splitContainerControl1.Panel1.Visible = false;
                    gridControl1.Visible = true;
                    splitContainerControl1.SplitterPosition = 0;
                    bList = true;
                    bTree = false;
                    break;
                case 6:
                    splitContainerControl1.Panel2.Visible = false;
                    gridControl1.Visible = false;
                    splitContainerControl1.SplitterPosition = this.Width;
                    bList = false;
                    bTree = true;
                    break;
                case 7:
                    splitContainerControl1.Panel1.Visible = false;
                    gridControl1.Visible = true;
                    splitContainerControl1.SplitterPosition = 0;
                    bList = true;
                    bTree = false;
                    break;
            }
        }


        public string sID = "";
        public string sIDText = "";
        public bool isAll = false;
        public string streeid = "";
        string sTreeNodeTag = "";
        string sTreeText = "";
        bool bTreeEnd = false;
        系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
      
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            try
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
            catch { }
        }


        /// <summary>
        /// 树状菜单
        /// </summary>
        private void GetClass()
        {
            try
            {
                
                string sSQL = "";

                string sTree = "";
                switch (iClassType)
                {
                    case 1:
                        sSQL = @"
select cInvCCode as iIDTree,cInvCName as iTextTree,iInvCGrade as iGrade,bInvCEnd as bEnd 
from  U8InventoryClass
order by cInvCCode
";
                        sTree = "存货分类";
                        break;
                    case 2:
                        sSQL = @"
select cDepCode as iIDTree,cDepName as iTextTree,iDepGrade as iGrade,bDepEnd as bEnd 
from [U8Department] 
order by cDepCode
";
                        sTree = "部门";
                        break;
                    case 4:
                        sSQL = @"
select cCCCode as iIDTree,cCCName as iTextTree,iCCGrade as iGrade,bCCEnd as bEnd
from [dbo].[U8CustomerClass]
order by cCCCode
";
                        sTree = "开票客户";
                        break;

                    case 5:
                        sSQL = @"
select cVCCode as iIDTree,cVCName as iTextTree,iVCGrade as iGrade,bVCEnd as bEnd 
from  [dbo].[U8VendorClass]
order by cVCCode
";
                        sTree = "保证金客户";
                        break;
                    case 6:
                        sSQL = @"
select cDCCode as iIDTree,cDCName as iTextTree,iDCGrade as iGrade,bDCEnd as bEnd 
from [dbo].[U8DistrictClass]
order by cDCCode
";
                        sTree = "部门";
                        break;
                }

                if (sSQL.Trim() == "")
                {
                    throw new Exception("请设置参照");
                }
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                //DataRow dr = dt.NewRow();
                //dr["iIDTree"] = sTree;
                //dr["iTextTree"] = sTree;
                //dr["iGrade"] = 0;
                //dr["bEnd"] = false;
                //dt.Rows.Add(dr);

                TreeNode tn;
                TreeNode tn2;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dt.Rows[i]["iGrade"]) == 1)
                    {
                        tn = new TreeNode();
                        tn.Tag = dt.Rows[i]["iIDTree"].ToString().Trim();
                        tn.Text ="["+ dt.Rows[i]["iIDTree"].ToString().Trim() + "]" + dt.Rows[i]["iTextTree"].ToString().Trim();
                        treeView1.Nodes.Add(tn);
                        if (dt.Rows[i]["iTextTree"].ToString().Trim() == streeid)
                        {
                            tn.Expand();
                            tn.Checked = true;
                        }
                        GetLev(tn, dt, 1);
                    }
                }
            }
            catch (Exception ee)
            {
                throw new Exception("获得参照失败！  " + ee.Message);
            }
        }

        private void GetLev(TreeNode tn, DataTable dt, int cgrade)
        {
            try
            {
                cgrade = cgrade + 1;
                DataRow[] dw = dt.Select("iIDTree like '" + tn.Tag.ToString().Trim() + "%' and iGrade='" + cgrade + "'");
                for (int i = 0; i < dw.Length; i++)
                {
                    TreeNode tn1 = new TreeNode();
                    tn1.Name = dw[i]["iIDTree"].ToString().Trim();
                    tn1.Tag = dw[i]["iIDTree"].ToString().Trim();
                    tn1.Text = "[" + dw[i]["iIDTree"].ToString().Trim() + "]" + dw[i]["iTextTree"].ToString().Trim();
                    tn.Nodes.Add(tn1);
                    if (dw[i]["iTextTree"].ToString().Trim() == streeid)
                    {
                        tn.Expand();
                        tn.Checked = true;
                    }
                    GetLev(tn1, dt, cgrade);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("操作失败：" + ee.Message);
            }
        }

        private void Frm参照_Load(object sender, EventArgs e)
        {
            try
            {
                this.StartPosition = FormStartPosition.CenterParent;
                if (bTree)
                {
                    GetClass();
                }

                //if (txtSEL.Text.Trim() != "" || streeid != "")
                    GetInfo();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void GetInfo()
        {
            try
            {
                string sSQL = "";

                switch (iClassType)
                {
                    case 1:
                        sSQL = @"

select cInvCode as 存货编码,cInvName as 存货名称,cInvStd as 规格型号 
from [dbo].[U8Inventory] 
where 1=1
order by cInvCode
";
                        if (txtSEL.Text.Trim() != string.Empty)
                        {
                            sSQL = sSQL.Replace("1=1", "1=1 and (cInvCode like '%" + txtSEL.Text.Trim() + "%' or cInvName like '%" + txtSEL.Text.Trim() + "%'  or cInvStd like '%" + txtSEL.Text.Trim() + "%') ");
                        }
                        if (sTreeNodeTag.Trim() != "")
                        {
                            sSQL = sSQL.Replace("1=1", "1=1 and cInvCCode like '" + sTreeNodeTag.Trim() + "%'");
                        }

                        break;


                    case 3:
                        sSQL = @"

select cVenCode as 代理商编码,cVenName as 代理商 
from [dbo].[代理商] 
where 1=1
order by cVenCode
";
                        if (txtSEL.Text.Trim() != string.Empty)
                        {
                            sSQL = sSQL.Replace("1=1", "1=1 and (cVenCode like '%" + txtSEL.Text.Trim() + "%' or cVenName like '%" + txtSEL.Text.Trim() + "%') ");
                        }

                        break;

                    case 4:
                        sSQL = @"
select cCusCode as 开票客户编码,cCusName as 开票客户名称
from [dbo].[U8Customer] 
where 1=1
order by cCusCode
";
                        if (txtSEL.Text.Trim() != string.Empty)
                        {
                            sSQL = sSQL.Replace("1=1", "1=1 and (cCusCode like '%" + txtSEL.Text.Trim() + "%' or cCusName like '%" + txtSEL.Text.Trim() + "%') ");
                        }
                        if (sTreeNodeTag.Trim() != "")
                        {
                            sSQL = sSQL.Replace("1=1", "1=1 and cCCCode like '" + sTreeNodeTag.Trim() + "%'");
                        }

                        break;

                    case 5:
                        sSQL = @"
select cVenCode as 保证金客户编码,cVenName as 保证金客户名称
from [dbo].[U8Vendor] 
where 1=1 
order by cVenCode
";
                        if (txtSEL.Text.Trim() != string.Empty)
                        {
                            sSQL = sSQL.Replace("1=1", "1=1 and (cVenCode  like '%" + txtSEL.Text.Trim() + "%' or cVenName like '%" + txtSEL.Text.Trim() + "%') ");
                        }
                        if (sTreeNodeTag.Trim() != "")
                        {
                            sSQL = sSQL.Replace("1=1", "1=1 and cVCCode  like '" + sTreeNodeTag.Trim() + "%'");
                        }

                        break;

                    case 7:
                        sSQL = @"

select cPersonCode as 业务员编码,cPersonName as 业务员名称 
from U8Person 
where 1=1
order by cPersonCode
";
                        if (txtSEL.Text.Trim() != string.Empty)
                        {
                            sSQL = sSQL.Replace("1=1", "1=1 and (cPersonCode like '%" + txtSEL.Text.Trim() + "%' or cPersonName like '%" + txtSEL.Text.Trim() + "%') ");
                        }

                        break;
                }

                if (sSQL.Trim() != "")
                {
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    gridControl1.DataSource = dt;
                    gridView1.OptionsBehavior.Editable = false;
                    gridView1.BestFitColumns();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败:" + ee.Message);
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                sTreeNodeTag = e.Node.Tag.ToString().Trim();
                sTreeText = e.Node.Text.Trim();
                if (e.Node.Nodes.Count>0)
                {
                    bTreeEnd = false;
                }
                else
                {
                    bTreeEnd = true;
                }

                if (bList)
                {
                    GetInfo();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("操作失败：" + ee.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (bList)
                {
                    iID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString().Trim();
                    iText = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString().Trim();
                    if (gridView1.Columns.Count > 2)
                    {
                        iText2 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString().Trim();
                    }

                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    if (!bTreeEnd)
                    {
                        MessageBox.Show("请选择末级");
                        return;
                    }

                    string[] s = sTreeText.Split(']');
                    iID = sTreeNodeTag;
                    iText = s[1];

                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                int iFoc = e.RowHandle;

                if(Convert.ToBoolean(gridView1.GetRowCellValue(iFoc,gridView1.Columns["选择"])))
                {
                    for(int i = 0;i<gridView1.RowCount;i++)
                    {
                        if (i == iFoc)
                        {
                            gridView1.SetRowCellValue(i, gridView1.Columns["选择"], false);
                        }
                    }
                }
            
            }
            catch { }
        }

        private void btnSEL_Click(object sender, EventArgs e)
        {
            GetInfo();
        }
    }
}