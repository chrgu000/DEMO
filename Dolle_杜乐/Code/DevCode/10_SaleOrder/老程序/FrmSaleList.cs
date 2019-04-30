using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SaleOrder
{
    public partial class FrmSaleList : Form
    {
        protected FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
        protected FrameBaseFunction.ClsGetSQL clsGetSQL = FrameBaseFunction.ClsGetSQL.Instance();
        int iSaleID = 2703;             //参与计算ID
        public string sOrderID = "";
        public FrmSaleList()
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

                date1.Text = DateTime.Now.ToString("yyyy-MM-01");
                date2.Text = Convert.ToDateTime(DateTime.Now.AddMonths(1).ToString("yyyy-MM-01")).AddDays(-1).ToString("yyyy-MM-dd");
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
            string sSQL = "SELECT cast(null as varchar(2)) as bChoose,cDefine6,a.*, b.*,c.cInvName " +
                          " FROM @u8.SO_SODetails b INNER JOIN @u8.SO_SOMain a ON a.ID = b.ID left join @u8.Inventory c on b.cInvCode = c.cInvCode ";

            sSQL = sSQL + " where isnull(cVerifier,'') <> '' and isnull(cCloser,'') = '' " +
                            " and cast(a.cSOCode as varchar(50)) +'-'  + cast(b.iRowNo as varchar(50)) not in (select cast(销售订单号 as varchar(50)) +'-'  + cast(行号 as varchar(50)) from dbo.订单评审表头 where 帐套号 = " + int.Parse(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)) + " and 年度 = " + int.Parse(Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyy")) + ") ";

            sSQL = sSQL + " and a.dDate >= '" + date1.DateTime.ToString("yyyy-MM-dd") + "' and a.dDate <= '" + date2.DateTime.ToString("yyyy-MM-dd") + "' ";

            if (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.ToLower() == "ufdata_200_2012")
            {
                sSQL = sSQL + " and b.AutoID > " + iSaleID + " ";
            }
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

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "")
                    continue;

                if (sOrderID == "")
                {
                    sOrderID = gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim();
                }
                else
                {
                    sOrderID = sOrderID + "," + gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim();
                }
            }

            if (sOrderID.Trim() != "")
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            else
                MessageBox.Show("请选择需要评审的单据");
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int iRow = gridView1.FocusedRowHandle;
                if (gridView1.GetRowCellValue(iRow, gridColbChoose).ToString().Trim() == "")
                {
                    gridView1.SetRowCellValue(iRow, gridColbChoose, "√");
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (iRow == i)
                            continue;
                        else
                            gridView1.SetRowCellValue(i, gridColbChoose, "");
                    }
                }
                else
                {
                    gridView1.SetRowCellValue(iRow, gridColbChoose, "");
                }
            }
            catch
            {}
        }
    }
}
