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
        protected ClsUseWebService clsWeb = new ClsUseWebService();
        int iType = 0;
        string sTree = "";
        string sTreeCode = "";
        string sTreeText = "";
        public string sID = "";
        bool b多选 = false;

        #region

        public Frm参照(int i, bool bAllow多选)
        {
            iType = i;

            b多选 = bAllow多选;
        }

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
            //layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            //switch (i)
            //{
            //    case 1:
            //        sTree = "InventoryClass";
            //        sTreeCode = "cInvClassCode";
            //        sTreeText = "存货分类";
            //        break;
            //    case 2:
            //        sTree = "Department";
            //        sTreeCode = "cDepCode";
            //        sTreeText = "人员分类";
            //        break;
            //    case 3:
            //        sTree = "Department";
            //        sTreeCode = "cDepCode";
            //        sTreeText = "部门分类";
            //        break;
            //    case 4:
            //        sTree = "DistrictClass ";
            //        sTreeCode = "cDCCode";
            //        sTreeText = "地区";
            //        break;
            //    case 5:
            //        sTree = "CustomerClass ";
            //        sTreeCode = "cCCode";
            //        sTreeText = "客户分类";
            //        break;
            //    case 6:
            //        sTree = "VendorClass ";
            //        sTreeCode = "cVCCode";
            //        sTreeText = "供应商分类";
            //        break;
            //    case 7:
            //        sTree = "InventoryClass ";
            //        sTreeCode = "cInvClassCode";
            //        sTreeText = "存货档案";
            //        break;
            //    case 8:
            //        sTree = "DealerClass ";
            //        sTreeCode = "cDCode";
            //        sTreeText = "经销商分类";
            //        break;
            //    case 9:
            //        sTree = "CustomerClass ";
            //        sTreeCode = "cCCode";
            //        sTreeText = "客户分类";
            //        break;
            //    case 10:
            //        sTree = "VendorClass ";
            //        sTreeCode = "cVCCode";
            //        sTreeText = "供应商分类";
            //        break;
            //    case 11:
            //        sTree = "DealerClass ";
            //        sTreeCode = "cDCode";
            //        sTreeText = "经销商分类";
            //        break;

            //}
        }
        #endregion

        private string GetcCode()
        {
            if (textEdit1.EditValue != null && textEdit1.EditValue.ToString().Trim() != "")
            {
                return textEdit1.EditValue.ToString().Trim();
            }
            return "";
        }
        /// <summary>
        /// 获得存货档案
        /// </summary>
        private void GetInvGrid()
        {
            gridControl1.DataSource = clsWeb.ShowInventory(GetcCode());
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
            gridControl1.DataSource = clsWeb.ShowPerson(GetcCode());

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
        /// 获得部门
        /// </summary>
        private void GetDepartment()
        {
            gridControl1.DataSource = clsWeb.ShowDepartment(GetcCode());

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
        /// 工程性质
        /// </summary>
        private void GetEngineeringGrid()
        {
            gridControl1.DataSource = clsWeb.ShowEngineering(GetcCode());

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
        /// 质量
        /// </summary>
        private void GetQualityGrid()
        {
            gridControl1.DataSource = clsWeb.ShowQuality(GetcCode());

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
        /// 安全
        /// </summary>
        private void GetSecurityGrid()
        {
            gridControl1.DataSource = clsWeb.ShowSecurity(GetcCode());

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
        /// 性质
        /// </summary>
        private void GetEngineering()
        {
            gridControl1.DataSource = clsWeb.ShowEngineering(GetcCode());

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
        /// 项目
        /// </summary>
        private void GetProject()
        {
            gridControl1.DataSource = clsWeb.ShowProject(GetcCode());

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
        /// 地区
        /// </summary>
        private void GetDistrictClass()
        {
            gridControl1.DataSource = clsWeb.ShowDistrictClass(GetcCode());

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
        /// 工程分类
        /// </summary>
        private void GetShowlookUpDate2()
        {
            gridControl1.DataSource = clsWeb.ShowlookUpDate(GetcCode(),"2");

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
                    //序号.GetTree(treeList1, sTree, sTreeCode, sTreeText);
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
            try
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
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }


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
                layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                switch (iType)
                {
                    case 1:
                        GetInvGrid();
                        break;
                    case 2:
                        GetPersonGrid();
                        break;
                    case 3:
                        GetQualityGrid();
                        break;
                    case 4:
                        GetSecurityGrid();
                        break;
                    case 5:
                        GetDepartment();
                        break;
                    case 6:
                        GetEngineering();
                        break;
                    case 7:
                        GetDistrictClass();
                        break;
                    case 8:
                        GetShowlookUpDate2();
                        break;
                    case 9:
                        GetProject();
                        break;
                }

                int iCol = gridView1.Columns.Count;

                for (int i = 0; i < iCol; i++)
                {
                    switch (i)
                    {
                        case 0:
                            gridView1.Columns[i].Width = 20;
                            break;
                        case 1:
                            gridView1.Columns[i].Width = 50;
                            break;
                        case 2:
                            gridView1.Columns[i].Width = 200;
                            break;
                        default:
                            gridView1.Columns[i].Width = 200;
                            break;
                    }

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
                    case 3:
                        GetQualityGrid();
                        break;
                    case 4:
                        GetSecurityGrid();
                        break;
                    case 5:
                        GetDepartment();
                        break;
                    case 6:
                        GetEngineering();
                        break;
                    case 7:
                        GetDistrictClass();
                        break;
                    case 8:
                        GetShowlookUpDate2();
                        break;
                    case 9:
                        GetProject();
                        break;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("参照失败");
            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (!b多选)
                {
                    bool b = Convert.ToBoolean(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["选择"]));
                    if (!b)
                    {
                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            if (i == e.RowHandle)
                                continue;

                            gridView1.SetRowCellValue(i, gridView1.Columns["选择"], false);
                        }
                    }
                }
            }
            catch { }
        }

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
    }
}
