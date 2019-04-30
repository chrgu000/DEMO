using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImportDLL
{
    public partial class Frm开料单_Add : Form
    {
        protected FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
        protected FrameBaseFunction.ClsGetSQL clsGetSQL = FrameBaseFunction.ClsGetSQL.Instance();
        public string sAutoID;          //销售订单子表ID
        //public string sCinvCode;
        int iSaleID = 0;                //参与计算ID（用于期初屏蔽已执行单据）


        public Frm开料单_Add()
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
            string sSQL = "select distinct cSOCode as iID from @u8.SO_SOMain where isnull(cVerifier,'') <> '' and isnull(cCloser,'') = '' and [ID] > " + iSaleID + " order by cSOCode";
            DataTable dt = clsGetSQL.GetLookUpEdit(sSQL);
            lookUpEditSaleOrder1.Properties.DataSource = dt;
            lookUpEditSaleOrder2.Properties.DataSource = dt;
         
            sSQL = "select distinct cCusCode as iID,cCusName from @u8.Customer order by cCusCode";
            dt = clsGetSQL.GetLookUpEdit(sSQL);
            lookUpEditCusterm.Properties.DataSource = dt;
            ItemLookUpEditCustomer.DataSource = dt;
        }

        private void btnSEL_Click(object sender, EventArgs e)
        {
            string sSQL = "SELECT a.*, b.*,c.cInvName,c.cInvStd " +
                          " FROM @u8.SO_SODetails b INNER JOIN @u8.SO_SOMain a ON a.ID = b.ID left join @u8.Inventory c on b.cInvCode = c.cInvCode ";

            sSQL = sSQL + " where isnull(cVerifier,'') <> '' and isnull(cCloser,'') = '' ";
                            //" and cast(a.cSOCode as varchar(50)) +'-'  + cast(b.iRowNo as varchar(50)) not in (select cast(销售订单号 as varchar(50)) +'-'  + cast(销售订单行号 as varchar(50)) from dbo.生产计划 where 帐套号 = " + int.Parse(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)) + " and 年度 = " + int.Parse(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4)) + ") ";

            if (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.ToLower() == "ufdata_200_2012")
            {
                sSQL = sSQL + " and a.ID > " + iSaleID + " ";
            }
            if (lookUpEditSaleOrder1.Text.Trim() != string.Empty)
            {
                sSQL = sSQL + " and a.cSOCode >= '" + lookUpEditSaleOrder1.EditValue + "'";
            }
            if (lookUpEditSaleOrder2.Text.Trim() != string.Empty)
            {
                sSQL = sSQL + " and a.cSOCode <= '" + lookUpEditSaleOrder2.EditValue + "'";
            }
       
            if (lookUpEditCusterm.Text.Trim() != string.Empty)
            {
                sSQL = sSQL + " and a.cCusCode = '" + lookUpEditCusterm.EditValue + "'";
            }

            if (buttonEdit存货编码.Text.Trim() != "")
            {
                sSQL = sSQL + " and b.cInvCode like '%" + buttonEdit存货编码.Text.Trim() + "%'";
            }
            if (!chkAll.Checked)
            {
                sSQL = sSQL + " and b.iQuantity-(select isnull(sum(@u8.开料单表头.数量2),0) from @u8.开料单表头 where @u8.开料单表头.销售订单ID=b.AutoID)>0  ";//b.AutoID not in (select isnull(销售订单ID,-1) from @u8.开料单表头)
            }
              
            sSQL = sSQL + " order by b.AutoID ";

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

            sAutoID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColAutoID).ToString().Trim();
            //sCinvCode = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColcInvCode).ToString().Trim();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            sAutoID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColAutoID).ToString().Trim();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void buttonEdit存货编码_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (buttonEdit存货编码.EditValue == null)
            {
                buttonEdit存货编码.EditValue = "";
            }
            string cinvcode = buttonEdit存货编码.EditValue.ToString().Trim();

            FrmInvInfo fInv = new FrmInvInfo(cinvcode);
            if (DialogResult.OK == fInv.ShowDialog())
            {
                fInv.Enabled = true;
                buttonEdit存货编码.EditValue = fInv.sInvCode;

            }
        }
    }
}
