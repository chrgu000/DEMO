using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorkInformation
{
    public partial class FrmWorkPlan_Add : Form
    {
        protected FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
        protected FrameBaseFunction.ClsGetSQL clsGetSQL = FrameBaseFunction.ClsGetSQL.Instance();
        public string sAutoID;          //销售订单子表ID
        public int iType;               //单据类型：0 销售订单，1 手工计划
        //int iSaleID = 2703;           //参与计算ID
        public FrmWorkPlan_Add()
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmWorkPlanAdd_Load(object sender, EventArgs e)
        {
            try
            {
                GetLookUp();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败：" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void GetLookUp()
        {
            string sSQL = "select distinct cSOCode as iID from @u8.SO_SOMain where isnull(cVerifier,'') <> '' and isnull(cCloser,'') = '' order by cSOCode";
            DataTable dt = clsGetSQL.GetLookUpEdit(sSQL);
            lookUpEditSaleOrder1.Properties.DataSource = dt;
            lookUpEditSaleOrder2.Properties.DataSource = dt;

            sSQL = "select distinct cItemCode as iID from @u8.SO_SODetails order by cItemCode";
            dt = clsGetSQL.GetLookUpEdit(sSQL);
            lookUpEditSaleOrderW.Properties.DataSource = dt;

            sSQL = "select distinct cDefine2 as iID from @u8.SO_SOMain where isnull(cVerifier,'') <> '' and isnull(cCloser,'') = '' and isnull(cDefine2,'') <> '' order by cDefine2";
            dt = clsGetSQL.GetLookUpEdit(sSQL);
            lookUpEditSaleOrderC.Properties.DataSource = dt;

            sSQL = "select distinct cCusCode as iID,cCusName from @u8.Customer order by cCusCode";
            dt = clsGetSQL.GetLookUpEdit(sSQL);
            lookUpEditCusterm.Properties.DataSource = dt;
            ItemLookUpEditCustomer.DataSource = dt;
        }

        private void btnSEL_Click(object sender, EventArgs e)
        {
            string sSQL = "";
            if (chk手工.Checked)
            {
                sSQL = @"
select a.销售订单号 as cSOCode,a.行号 as iRowNo,a.完工日期 as dPreMoDate,a.物料编码 as cInvCode,a.数量 as iQuantity,a.iID as AutoID,b.cInvName
from 生产手工计划 a inner join @u8.Inventory b on a.物料编码 = b.cInvCode 
where a.帐套号 = '111111' and a.iID not in (select distinct isnull(手工计划ID,-1) from dbo.生产计划) 
";
                if (lookUpEditSaleOrder1.Text.Trim() != string.Empty)
                {
                    sSQL = sSQL + " and 销售订单号 >= '" + lookUpEditSaleOrder1.EditValue + "'";
                }
                if (lookUpEditSaleOrder2.Text.Trim() != string.Empty)
                {
                    sSQL = sSQL + " and 销售订单号 <= '" + lookUpEditSaleOrder2.EditValue + "'";
                }

                sSQL = sSQL.Replace("111111", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3));
            }
            else
            {
                sSQL = "SELECT cDefine6,a.*, b.*,c.cInvName " +
                              " FROM @u8.SO_SODetails b INNER JOIN @u8.SO_SOMain a ON a.ID = b.ID left join @u8.Inventory c on b.cInvCode = c.cInvCode ";

                sSQL = sSQL + " where isnull(cVerifier,'') <> '' and isnull(cCloser,'') = '' and isnull(b.cSCloser,'') = '' " +
                                " and cast(a.cSOCode as varchar(50)) +'-'  + cast(b.iRowNo as varchar(50)) not in (select cast(销售订单号 as varchar(50)) +'-'  + cast(销售订单行号 as varchar(50)) from dbo.生产计划 where 帐套号 = " + int.Parse(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)) + "  and 单据类型 = 0 ) ";

                if (lookUpEditSaleOrder1.Text.Trim() != string.Empty)
                {
                    sSQL = sSQL + " and a.cSOCode >= '" + lookUpEditSaleOrder1.EditValue + "'";
                }
                if (lookUpEditSaleOrder2.Text.Trim() != string.Empty)
                {
                    sSQL = sSQL + " and a.cSOCode <= '" + lookUpEditSaleOrder2.EditValue + "'";
                }
                if (lookUpEditSaleOrderW.Text.Trim() != string.Empty)
                {
                    sSQL = sSQL + " and a.cDefine11 = '" + lookUpEditSaleOrderW.EditValue + "'";
                }
                if (lookUpEditSaleOrderC.Text.Trim() != string.Empty)
                {
                    sSQL = sSQL + " and a.cDefine2 = '" + lookUpEditSaleOrderC.EditValue + "'";
                }
                if (lookUpEditCusterm.Text.Trim() != string.Empty)
                {
                    sSQL = sSQL + " and a.cCusCode = '" + lookUpEditCusterm.EditValue + "'";
                }
                if (dateEditW1.Text.Trim() != string.Empty)
                {
                    sSQL = sSQL + " and b.dPreMoDate >= '" + dateEditW1.DateTime.ToString("yyyy-MM-dd") + "'";
                }
                if (dateEditW2.Text.Trim() != string.Empty)
                {
                    sSQL = sSQL + " and b.dPreMoDate <= '" + dateEditW2.DateTime.ToString("yyyy-MM-dd") + "'";
                }
                if (dateEditJ1.Text.Trim() != string.Empty)
                {
                    sSQL = sSQL + " and b.cDefine36 >= '" + dateEditJ1.DateTime.ToString("yyyy-MM-dd") + "'";
                }
                if (dateEditJ2.Text.Trim() != string.Empty)
                {
                    sSQL = sSQL + " and b.cDefine36 <= '" + dateEditJ2.DateTime.ToString("yyyy-MM-dd") + "'";
                }
                if (dateEditC1.Text.Trim() != string.Empty)
                {
                    sSQL = sSQL + " and b.dPreDate >= '" + dateEditC1.DateTime.ToString("yyyy-MM-dd") + "'";
                }
                if (dateEditC2.Text.Trim() != string.Empty)
                {
                    sSQL = sSQL + " and b.dPreDate <= '" + dateEditC2.DateTime.ToString("yyyy-MM-dd") + "'";
                }

                sSQL = sSQL + " and a.dDate >= '2013-9-1' ";
                sSQL = sSQL + " order by b.AutoID ";
            }
            DataTable dt =clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;
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

        private void btnEnsure_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount < 1)
            {
                MessageBox.Show("请选择需要排产的销售订单后确定");
                return;
            }
            if (chk手工.Checked)
            {
                iType = 1;
            }
            else
            {
                iType = 0;
            }
            
            sAutoID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColAutoID).ToString().Trim();
            
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void chk手工_CheckedChanged(object sender, EventArgs e)
        {
            gridControl1.DataSource = null;
        }
    }
}
