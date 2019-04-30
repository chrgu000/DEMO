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



        /// <summary>
        /// 获得存货档案
        /// </summary>
        private void GetInvGrid()
        {
            int iFocRow = gridView1.FocusedRowHandle;
            string sSQL = "select cast(0 as bit) as 选择,cInvCode as iID,cInvCode as 存货编码,cInvName as 存货名称,cInvAddCode as 存货代码,cInvStd as 规格型号 from dbo.Inventory where 1=1 order by cInvCode";
            if (treeList1.FocusedNode!=null && treeList1.FocusedNode.Tag.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and cInvClassCode like '" + treeList1.FocusedNode.Tag.ToString().Trim() + "%' or cInvClassCode='" + treeList1.FocusedNode.Tag.ToString().Trim() + "'");
            }
            if (textEdit1.EditValue != null && textEdit1.EditValue != "")
            {
                sSQL = sSQL.Replace("1=1", " cInvCode like '%" + textEdit1.EditValue.ToString().Trim() + "%' or cInvName like '%" + textEdit1.EditValue.ToString().Trim() + "%'");
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

        /// <summary>
        /// 获得人员
        /// </summary>
        private void GetPersonGrid()
        {
            int iFocRow = gridView1.FocusedRowHandle;
            string sSQL = "select cast(0 as bit) as 选择,PersonCode as iID,PersonCode as 人员编码,PersonName as 人员名称 from dbo.Person where 1=1 order by PersonCode";
            if (treeList1.FocusedNode != null && treeList1.FocusedNode.Tag.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and DeptID like '" + treeList1.FocusedNode.Tag.ToString().Trim() + "%' or DeptID='" + treeList1.FocusedNode.Tag.ToString().Trim() + "'");
            }
            if (textEdit1.EditValue != null && textEdit1.EditValue != "")
            {
                sSQL = sSQL.Replace("1=1", " PersonCode like '%" + textEdit1.EditValue.ToString().Trim() + "%' or PersonName like '%" + textEdit1.EditValue.ToString().Trim() + "%'");
            }
            gridControl1.DataSource = clsSQLCommond.ExecQuery(sSQL);

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

        #region 获得地区
        /// <summary>
        /// 获得地区
        /// </summary>
        private void GetTradeClassGrid()
        {
            int iFocRow = gridView1.FocusedRowHandle;
            string sSQL = "select cast(0 as bit) as 选择,cTCode as iID,cTCode as 地区分类编码,cTCName as 地区分类名称 from dbo.TradeClass where 1=1 order by cTCode";
            if (treeList1.FocusedNode != null && treeList1.FocusedNode.Tag.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "cTCode like '" + treeList1.FocusedNode.Tag.ToString().Trim() + "%' or cTCode='" + treeList1.FocusedNode.Tag.ToString().Trim() + "'");
            }
            gridControl1.DataSource = clsSQLCommond.ExecQuery(sSQL);

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
        #endregion

        #region 客户
        /// <summary>
        /// 客户
        /// </summary>
        private void GetCustomerGrid()
        {
            int iFocRow = gridView1.FocusedRowHandle;
            string sSQL = "select cast(0 as bit) as 选择,cCusCode as iID,cCusCode as 客户编码,cCusName as 客户名称,cCusAbbName as 客户简称,cDepName as 部门 from dbo.Customer a left join Department b on a.cDCCode=b.cDepCode where 1=1 order by cCusCode";
            if (treeList1.FocusedNode != null && treeList1.FocusedNode.Tag.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and cCCCode like '" + treeList1.FocusedNode.Tag.ToString().Trim() + "%' or cCCCode='" + treeList1.FocusedNode.Tag.ToString().Trim() + "'");
            }
            if (textEdit1.EditValue != null && textEdit1.EditValue != "")
            {
                sSQL = sSQL.Replace("1=1", " cCusCode like '%" + textEdit1.EditValue.ToString().Trim() + "%' or cCusName like '%" + textEdit1.EditValue.ToString().Trim() + "%' or cDepName like '%" + textEdit1.EditValue.ToString().Trim() + "%'");
            }
            gridControl1.DataSource = clsSQLCommond.ExecQuery(sSQL);

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
        #endregion

        #region 供应商
        /// <summary>
        /// 供应商
        /// </summary>
        private void GetVendorGrid()
        {
            int iFocRow = gridView1.FocusedRowHandle;
            string sSQL = "select cast(0 as bit) as 选择,cVenCode as iID,cVenCode as 供应商编码,cVenName as 供应商名称,cVenAbbName as 供应商简称 from dbo.Vendor where 1=1 order by cVenCode";
            if (treeList1.FocusedNode != null && treeList1.FocusedNode.Tag.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and cVenCCode like '" + treeList1.FocusedNode.Tag.ToString().Trim() + "%' or cVenCCode='" + treeList1.FocusedNode.Tag.ToString().Trim() + "'");
            }
            if (textEdit1.EditValue != null && textEdit1.EditValue != "")
            {
                sSQL = sSQL.Replace("1=1", " cVenCode like '%" + textEdit1.EditValue.ToString().Trim() + "%' or cVenName like '%" + textEdit1.EditValue.ToString().Trim() + "%'");
            }
            gridControl1.DataSource = clsSQLCommond.ExecQuery(sSQL);

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
        #endregion


        #region 经销商
        /// <summary>
        /// 经销商
        /// </summary>
        private void GetDealerGrid()
        {
            int iFocRow = gridView1.FocusedRowHandle;
            string sSQL = "select cast(0 as bit) as 选择,dDeaCode as iID,dDeaCode as 经销商编码,dDeaName as 经销商名称,dDeaAbbName as 经销商简称 from dbo.Dealer where 1=1 order by dDeaCode";
            if (treeList1.FocusedNode != null && treeList1.FocusedNode.Tag.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and dDCCode like '" + treeList1.FocusedNode.Tag.ToString().Trim() + "%' or dDCCode='" + treeList1.FocusedNode.Tag.ToString().Trim() + "'");
            }
            if (textEdit1.EditValue != null && textEdit1.EditValue != "")
            {
                sSQL = sSQL.Replace("1=1", " dDeaCode like '%" + textEdit1.EditValue.ToString().Trim() + "%' or dDeaName like '%" + textEdit1.EditValue.ToString().Trim() + "%'");
            }
            gridControl1.DataSource = clsSQLCommond.ExecQuery(sSQL);

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
        #endregion

        #region 用户
        /// <summary>
        /// 用户
        /// </summary>
        private void GetUserInfo()
        {
            int iFocRow = gridView1.FocusedRowHandle;
            string sSQL = "select cast(0 as bit) as 选择,vchrUid as iID,vchrUid as 用户编码,vchrName as 用户名称 from dbo._UserInfo where 1=1 order by vchrUid";
            if (textEdit1.EditValue != null && textEdit1.EditValue != "")
            {
                sSQL = sSQL.Replace("1=1", " vchrUid like '%" + textEdit1.EditValue.ToString().Trim() + "%' or vchrName like '%" + textEdit1.EditValue.ToString().Trim() + "%'");
            }
            gridControl1.DataSource = clsSQLCommond.ExecQuery(sSQL);

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
        #endregion

        #region 合作方式
        /// <summary>
        /// 合作方式
        /// </summary>
        private void GetPacking()
        {
            int iFocRow = gridView1.FocusedRowHandle;
            string sSQL = "select cast(0 as bit) as 选择,cPCode as iID,cPCode as 合作方式编码,cPName as 合作方式名称 from dbo.Packing where 1=1 order by cPCode";
            if (textEdit1.EditValue != null && textEdit1.EditValue != "")
            {
                sSQL = sSQL.Replace("1=1", " cPCode like '%" + textEdit1.EditValue.ToString().Trim() + "%' or cPName like '%" + textEdit1.EditValue.ToString().Trim() + "%'");
            }
            gridControl1.DataSource = clsSQLCommond.ExecQuery(sSQL);

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
        #endregion

        #region 意向性客户
        /// <summary>
        /// 意向性客户
        /// </summary>
        private void GetCustomersIntentionality()
        {
            int iFocRow = gridView1.FocusedRowHandle;
            string sSQL = "select cast(0 as bit) as 选择,iCode as iID,iCode as 意向性客户编码,cIntName as  意向性客户名称 from dbo.CustomersIntentionality where 1=1 order by iCode";
            if (textEdit1.EditValue != null && textEdit1.EditValue != "")
            {
                sSQL = sSQL.Replace("1=1", " iCode like '%" + textEdit1.EditValue.ToString().Trim() + "%' or cIntName like '%" + textEdit1.EditValue.ToString().Trim() + "%'");
            }
            gridControl1.DataSource = clsSQLCommond.ExecQuery(sSQL);

            int iCou = gridView1.Columns.Count;
            for (int i = 0; i < iCou; i++)
            {
                if (i == 0)
                {
                    gridView1.Columns[i].Width = 30;
                }
                else if (i == 1)
                {
                    gridView1.Columns[i].Width = 200;
                }
                else
                {
                    gridView1.Columns[i].Width = 400;
                }
            }

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
        #endregion
        private void GetTree()
        {
            try
            {
                if (sTree != "")
                {
                    序号.GetTree(treeList1, sTree, sTreeCode, sTreeText);
                    //treeList1.ExpandAll();
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
        /// 1 存货档案 2 人员档案 3 部门分类 4 地区分类 5 客户分类 6 供应商分类 7 存货分类 8 经销商分类 9 客户档案 10 供应商档案 11经销商档案 12 用户 14 意向性客户
        /// </summary>
        /// <param name="i">1 存货档案 2 人员档案 3 部门分类 4 地区分类 5 客户分类 6 供应商分类 7 存货分类 8 经销商分类 9 客户档案 10 供应商档案 11经销商档案  12 用户 14 意向性客户</param>
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
                    sTree = "Department";
                    sTreeCode = "cDepCode";
                    sTreeText = "人员分类";
                    break;
                case 3:
                    sTree = "Department";
                    sTreeCode = "cDepCode";
                    sTreeText = "部门分类";
                    break;
                case 4:
                    sTree = "DistrictClass ";
                    sTreeCode = "cDCCode";
                    sTreeText = "地区";
                    break;
                case 5:
                    sTree = "CustomerClass ";
                    sTreeCode = "cCCode";
                    sTreeText = "客户分类";
                    break;
                case 6:
                    sTree = "VendorClass ";
                    sTreeCode = "cVCCode";
                    sTreeText = "供应商分类";
                    break;
                case 7:
                    sTree = "InventoryClass ";
                    sTreeCode = "cInvClassCode";
                    sTreeText = "存货档案";
                    break;
                case 8:
                    sTree = "DealerClass ";
                    sTreeCode = "cDCode";
                    sTreeText = "经销商分类";
                    break;
                case 9:
                    sTree = "CustomerClass ";
                    sTreeCode = "cCCode";
                    sTreeText = "客户分类";
                    break;
                case 10:
                    sTree = "VendorClass ";
                    sTreeCode = "cVCCode";
                    sTreeText = "供应商分类";
                    break;
                case 11:
                    sTree = "DealerClass ";
                    sTreeCode = "cDCode";
                    sTreeText = "经销商分类";
                    break;
            }
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
                        GetPersonGrid();
                        break;
                    case 3:
                        layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        break;
                    case 4:
                        layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        break;
                    case 5:
                        layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        break;
                    case 6:
                        layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        break;
                    case 7:
                        layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        break;
                    case 8:
                        layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        break;
                    case 9:
                        GetCustomerGrid();
                        break;
                    case 10:
                        GetVendorGrid();
                        break;
                    case 11:
                        GetDealerGrid();
                        break;
                    case 12:
                        layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        GetUserInfo();
                        break;
                    case 13:
                        layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        GetPacking();
                        break;
                    case 14:
                        layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        GetCustomersIntentionality();
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
                    case 2:
                        GetPersonGrid();
                        break;
                    case 9:
                        GetCustomerGrid();
                        break;
                    case 10:
                        GetVendorGrid();
                        break;
                    case 11:
                        GetDealerGrid();
                        break;
                    case 12:
                        GetUserInfo();
                        break;
                    case 13:
                        GetPacking();
                        break;
                    case 14:
                        GetCustomersIntentionality();
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
