using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImportDLL
{
    public partial class Frm订单评审_Sel : FrameBaseFunction.FrmFromModel
    {
        public string s评审单据号 = "";

        TH.Model.订单评审 Model = new TH.Model.订单评审();
        TH.Model.订单评审明细 ModelDetail = new TH.Model.订单评审明细();
        //TH.BLL.订单评审 BLL = new TH.BLL.订单评审();
        TH.DAL.订单评审 DAL = new TH.DAL.订单评审();


        int iType = 0;      //0 订单评审；1 下达生产计划；2 下达委外计划；3 下达采购计划

        public Frm订单评审_Sel()
        {
            InitializeComponent();

            #region 禁止用户调整表格

            layoutControl1.AllowCustomizationMenu = false;

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
        }


        public Frm订单评审_Sel(int i)
        {
            InitializeComponent();

            #region 禁止用户调整表格

            layoutControl1.AllowCustomizationMenu = false;

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
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterParent;
            GetLookup();

            if (iType == 0)
            {
                layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                //radio未下单.Visible = false;
                //radio已下单.Visible = false;
                emptySpaceItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
            {
                radio未下单.Checked = true;
                //radio未下单.Visible = true;
                //radio已下单.Visible = true;
                layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                emptySpaceItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }

            dtm单据日期1.Text = Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyy-MM-01");
            dtm单据日期2.Text =DateTime.Parse( Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyy-MM-01")).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");
            
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void btnSEL_Click(object sender, EventArgs e)
        {
            try
            {
                string sSQLWhere = "";
                if (lookUpEdit评审单据号1.Text.Trim() != "")
                {
                    sSQLWhere = sSQLWhere + " and 评审单据号 >= '" + lookUpEdit评审单据号1.Text.Trim() + "'";
                }
                if (lookUpEdit评审单据号2.Text.Trim() != "")
                {
                    sSQLWhere = sSQLWhere + " and 评审单据号 <= '" + lookUpEdit评审单据号2.Text.Trim() + "'";
                }
                if (dtm单据日期1.Text.Trim() != "")
                {
                    sSQLWhere = sSQLWhere + " and 评审单据日期 >= '" + dtm单据日期1.DateTime.ToString("yyyy-MM-dd") + "'";
                }
                if (dtm单据日期2.Text.Trim() != "")
                {
                    sSQLWhere = sSQLWhere + " and 评审单据日期 <= '" + dtm单据日期2.DateTime.ToString("yyyy-MM-dd") + "'";
                }
                if (radio已关闭.Checked)
                {
                    sSQLWhere = sSQLWhere + " and isnull(关闭人,'') <> '' ";
                }   
                else
                {
                    sSQLWhere = sSQLWhere + " and isnull(审核人,'') <> '' ";
                }

                if (!radio全部.Checked)
                {
                    if (iType == 1)
                    {
                        if (radio已下单.Checked)
                        {
                            sSQLWhere = sSQLWhere + " and isnull(下达生产人,'') <> '' ";
                        }
                        if (radio未下单.Checked)
                        {
                            sSQLWhere = sSQLWhere + " and isnull(下达生产人,'') = '' ";
                        }
                    }
                    if (iType == 2)
                    {
                        if (radio已下单.Checked)
                        {
                            sSQLWhere = sSQLWhere + " and isnull(下达委外人,'') <> '' ";
                        }
                        if (radio未下单.Checked)
                        {
                            sSQLWhere = sSQLWhere + " and isnull(下达委外人,'') = '' ";
                        }
                    }
                    if (iType == 3)
                    {
                        if (radio已下单.Checked)
                        {
                            sSQLWhere = sSQLWhere + " and isnull(下达请购人,'') <> '' ";
                        }
                        if (radio未下单.Checked)
                        {
                            sSQLWhere = sSQLWhere + " and isnull(下达请购人,'') = '' ";
                        }
                    }
                }

                DataTable dt = DAL.GetPSCodeList(sSQLWhere);
                gridControl1.DataSource = dt;
            }
            catch (Exception ee)
            {
                MsgBox("加载数据失败", ee.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.RowCount < 1)
                {
                    throw new Exception("没有数据");
                }
                int iRow = 0;
                if (gridView1.FocusedRowHandle > 0)
                    iRow = gridView1.FocusedRowHandle;

                s评审单据号 = gridView1.GetRowCellValue(iRow, gridCol评审单据号).ToString().Trim();
                if (s评审单据号 == "")
                {
                    throw new Exception("没有选择数据");
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch(Exception ee)
            {
                MessageBox.Show("查询失败:" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
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
        
        private void GetLookup()
        {
           DataTable dt = DAL.GetPSCode("");
           lookUpEdit评审单据号1.Properties.DataSource = dt;
           lookUpEdit评审单据号2.Properties.DataSource = dt;

        }
    }
}
