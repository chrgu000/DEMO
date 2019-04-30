using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;

namespace 系统服务
{
    public partial class Frm参照 : Form
    {

        系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
        int iType = 0;
        string sTree = "";
        string sTreeCode = "";
        string sTreeText = "";
        public string sID = "";

        string cInvCode = "";
        string per = "";

        /// <summary>
        /// 获得存货档案
        /// </summary>
        private void GetInvGrid()
        {
            int iFocRow = gridView1.FocusedRowHandle;
            string sSQL = "select cast(0 as bit) as 选择,cInvCode as iID,cInvCode as 存货编码,cInvName as 存货名称,cInvAddCode as 存货代码,cInvStd as 规格型号 from @u8.Inventory where 1=1 order by cInvCode";
            if (treeList1.FocusedNode!=null && treeList1.FocusedNode.Tag.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and (cInvClassCode like '" + treeList1.FocusedNode.Tag.ToString().Trim() + "%' or cInvClassCode='" + treeList1.FocusedNode.Tag.ToString().Trim() + "')");
            }
            if (textEdit1.EditValue != null && textEdit1.EditValue != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and  (cInvCode like '%" + textEdit1.EditValue.ToString().Trim() + "%' or cInvName like '%" + textEdit1.EditValue.ToString().Trim() + "%')");
            }
            gridControl1.DataSource =  clsSQLCommond.ExecQuery(sSQL);

            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                if (gridView1.Columns[i].FieldName == "选择")
                    gridView1.Columns[i].OptionsColumn.AllowEdit = true;
                else
                    gridView1.Columns[i].OptionsColumn.AllowEdit = false;

                if (gridView1.Columns[i].FieldName == "iID")
                    gridView1.Columns[i].Visible = false;
                else
                    gridView1.Columns[i].Visible = true;
            }
        }


        private void GetTree()
        {
            try
            {
                if (sTree != "")
                {
                    序号.GetTree(treeList1, sTree, sTreeCode, sTreeText);
                    treeList1.ExpandAll();
                    treeList1.BestFitColumns();
                }
                else
                {
                    treeList1.Visible = false;
                }
            }
            catch (Exception ee)
            {
                throw new Exception("获失败！  " + ee.Message);
            }
        }


        private void treeList1_Click(object sender, EventArgs e)
        {
            GetGrid();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            try
            { 
                
            }
            catch { }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            sID = "";
            
            if (layoutControlItem3.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Never)
            {
                if (treeList1.FocusedNode.Nodes.Count > 0)
                {
                    MessageBox.Show("请选择子节点");
                }
                else
                {
                    sID = treeList1.FocusedNode.Tag.ToString();
                }
            }
            else
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridView1.Columns["选择"])))
                    {
                        sID = sGetID(i);
                        break;
                    }
                }
            }
            if (sID != "")
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        #region
        /// <summary>
        /// 1 存货档案 2 人员档案 3 部门分类 4 地区分类 5 客户分类 6 供应商分类 7 存货分类 8 经销商分类 9 客户档案 10 供应商档案 11经销商档案 12 用户 
        /// </summary>
        /// <param name="i">1 存货档案 2 人员档案 3 部门分类 4 地区分类 5 客户分类 6 供应商分类 7 存货分类 8 经销商分类 9 客户档案 10 供应商档案 11经销商档案  12 用户</param>
        public Frm参照(int i)
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

            iType = i;
            layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            switch (i)
            {
                case 1:
                    sTree = "InventoryClass";
                    sTreeCode = "cInvClassCode";
                    sTreeText = "存货分类";
                    break;
                case 2:
                    sTree = "InventoryClass";
                    sTreeCode = "cInvClassCode";
                    sTreeText = "存货分类";
                    break;
                

            }
        }
        #endregion

        #region
        public Frm参照(int i,string cinvcode)
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

            iType = i;
            cInvCode = cinvcode; 
            string sSQL = "select M1 from Inventory where cInvCode='" + cInvCode + "'";
            DataTable dts = clsSQLCommond.ExecQuery(sSQL);
            if (dts.Rows.Count > 0)
            {
                per = dts.Rows[0]["M1"].ToString();
                per = per.Replace(", ", ",");
            }
            layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //switch (i)
            //{
                    

            //}
        }
        #endregion

        private void Frm参照_Load(object sender, EventArgs e)
        {
            try
            {

                GetTree();
                switch (iType)
                {
                    case 1:
                        GetInvGrid();
                        break;
                    case 2:
                        layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        break;
                   
                }
            }
            catch (Exception ee)
            {
                throw new Exception("加载窗体失败\n" + ee.Message);
            }
        }

        private string sGetID(int iRow)
        {
            string sID = gridView1.GetRowCellValue(iRow, gridView1.Columns["iID"]).ToString().Trim();
            return sID;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            GetGrid();
        }

        private void GetGrid()
        {
            try
            {
                switch (iType)
                {
                    case 1:
                        GetInvGrid();
                        break;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("参照失败");
            }
        }
    }
}
