using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImportDLL
{
    public partial class Frm材料入库单_Add : Form
    {
        protected FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
        protected FrameBaseFunction.ClsGetSQL clsGetSQL = FrameBaseFunction.ClsGetSQL.Instance();
        //public string sAutoID;          //销售订单子表ID
        //public string sCinvCode;
        //int iSaleID = 0;                //参与计算ID（用于期初屏蔽已执行单据）
        public string 材料入库单号1;
        public string 材料入库单号2;
        public string 入库日期1;
        public string 入库日期2;

        public Frm材料入库单_Add()
        {
            InitializeComponent();

            #region 禁止用户调整表格

            layoutControl1.AllowCustomizationMenu = false;

            //gridView1.OptionsMenu.EnableColumnMenu = false;
            //gridView1.OptionsMenu.EnableFooterMenu = false;
            //gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            //gridView1.OptionsMenu.ShowAutoFilterRowItem = false;
            //gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            //gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            //gridView1.OptionsMenu.ShowGroupSummaryEditorItem = false;
            //gridView1.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.False;
            //gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            //gridView1.OptionsCustomization.AllowColumnMoving = false;
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

        public void Get(string inv1, string inv2, string date1, string date2)
        {
            lookUpEdit材料入库单号1.EditValue = inv1;
            lookUpEdit材料入库单号2.EditValue = inv2;
            if (date1 != null && date1 != "")
            {
                date1 = DateTime.Parse(date1).ToString("yyyy-MM-dd");
                dateEdit入库日期1.EditValue = date1;
            }
            if (date2 != null && date2 != "")
            {
                date2 = DateTime.Parse(date2).ToString("yyyy-MM-dd");
                dateEdit入库日期2.EditValue = date2;
            }
        }

        private void GetLookUp()
        {
            string sSQL = "select * from @u8.材料入库单表头";
            DataTable dt =clsSQLCommond.ExecQuery(sSQL);
            lookUpEdit材料入库单号1.Properties.DataSource = dt;
            lookUpEdit材料入库单号2.Properties.DataSource = dt;
        }

        private void btnSEL_Click(object sender, EventArgs e)
        {
            //string sSQL = "SELECT a.*, b.*,c.cInvName,c.cInvStd " +
            //              " FROM @u8.SO_SODetails b INNER JOIN @u8.SO_SOMain a ON a.ID = b.ID left join @u8.Inventory c on b.cInvCode = c.cInvCode ";

            //sSQL = sSQL + " where isnull(cVerifier,'') <> '' and isnull(cCloser,'') = '' ";
            //                //" and cast(a.cSOCode as varchar(50)) +'-'  + cast(b.iRowNo as varchar(50)) not in (select cast(销售订单号 as varchar(50)) +'-'  + cast(销售订单行号 as varchar(50)) from dbo.生产计划 where 帐套号 = " + int.Parse(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)) + " and 年度 = " + int.Parse(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4)) + ") ";

            //if (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.ToLower() == "ufdata_200_2012")
            //{
            //    sSQL = sSQL + " and a.ID > " + iSaleID + " ";
            //}
            //if (lookUpEdit材料入库单号1.Text.Trim() != string.Empty)
            //{
            //    sSQL = sSQL + " and a.cSOCode >= '" + lookUpEdit材料入库单号1.EditValue + "'";
            //}
            //if (lookUpEditSaleOrder2.Text.Trim() != string.Empty)
            //{
            //    sSQL = sSQL + " and a.cSOCode <= '" + lookUpEditSaleOrder2.EditValue + "'";
            //}
       
            //if (lookUpEditCusterm.Text.Trim() != string.Empty)
            //{
            //    sSQL = sSQL + " and a.cCusCode = '" + lookUpEditCusterm.EditValue + "'";
            //}
            //if (!chkAll.Checked)
            //{
            //    sSQL = sSQL + " and b.AutoID not in (select isnull(销售订单ID,-1) from dbo.开料单表头) ";
            //}
              
            //sSQL = sSQL + " order by b.AutoID ";

            //DataTable dt =clsSQLCommond.ExecQuery(sSQL);
            //gridControl1.DataSource = dt;
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
            //if (gridView1.RowCount < 1)
            //{
            //    MessageBox.Show("请选择需要排产的销售订单后确定");
            //    return;
            //}

            //sAutoID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColAutoID).ToString().Trim();
            //sCinvCode = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColcInvCode).ToString().Trim();

            if (lookUpEdit材料入库单号1.EditValue != null)
            {
                材料入库单号1 = lookUpEdit材料入库单号1.EditValue.ToString().Trim();
            }
            if (lookUpEdit材料入库单号2.EditValue != null)
            {
                材料入库单号2 = lookUpEdit材料入库单号2.EditValue.ToString().Trim();
            }
            if (dateEdit入库日期1.EditValue != null)
            {
                入库日期1 = dateEdit入库日期1.EditValue.ToString().Trim();
            }
            if (dateEdit入库日期2.EditValue != null)
            {
                入库日期2 = dateEdit入库日期2.EditValue.ToString().Trim();
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
