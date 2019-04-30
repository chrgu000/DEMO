using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImportDLL
{
    public partial class Frm工序_New : Form
    {
        protected FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
        protected FrameBaseFunction.ClsGetSQL clsGetSQL = FrameBaseFunction.ClsGetSQL.Instance();
        public string MoDId;
        DataTable dt;
        public string OpSeq;
        public Frm工序_New(string sMoDId)
        {
            MoDId = sMoDId;
            InitializeComponent();
        }

        public Frm工序_New()
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

        private void Frm委外订单_New_Load(object sender, EventArgs e)
        {
            try
            {
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败：" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void GetGrid()
        {
            string sSQL = @" SELECT '' as iChk ,[MMSfcMoroutingdetailEntity_sfc_moroutingdetail].[OpSeq] as OpSeq,[MMSfcMoroutingdetailEntity_sfc_moroutingdetail].[Description] as Description 
--[MMMomOrderdetailEntity_mom_orderdetail].[Qty] as Qty,[MMVBasInventoryEntity_v_bas_inventory].[ComUnitName] as ComUnitName,[MMSfcMoroutingdetailEntity_sfc_moroutingdetail].[DueDate] as DueDate,[MMSfcMoroutingdetailEntity_sfc_moroutingdetail].[StartDate] as StartDate,[MMWorkCenterEntity_sfc_workcenter].[WcCode] as WcCode,[MMWorkCenterEntity_sfc_workcenter].[Description] as WcDescription 
FROM @u8.[sfc_morouting] AS [MMSfcMoroutingEntity_sfc_morouting]
LEFT JOIN @u8.[v_mom_orderdetail_all] AS [MMMomOrderdetailEntity_mom_orderdetail] ON [MMSfcMoroutingEntity_sfc_morouting].[MoDId]=[MMMomOrderdetailEntity_mom_orderdetail].[MoDId]
LEFT JOIN @u8.[bas_part] AS [MMPartEntity_bas_part] ON [MMMomOrderdetailEntity_mom_orderdetail].[PartId]=[MMPartEntity_bas_part].[PartId]
LEFT JOIN @u8.[v_bas_inventory] AS [MMVBasInventoryEntity_v_bas_inventory] ON [MMPartEntity_bas_part].[InvCode]=[MMVBasInventoryEntity_v_bas_inventory].[InvCode]
LEFT JOIN @u8.[sfc_moroutingdetail] AS [MMSfcMoroutingdetailEntity_sfc_moroutingdetail] ON [MMSfcMoroutingEntity_sfc_morouting].[MoRoutingId]=[MMSfcMoroutingdetailEntity_sfc_moroutingdetail].[MoRoutingId]
LEFT JOIN @u8.[sfc_workcenter] AS [MMWorkCenterEntity_sfc_workcenter] ON [MMSfcMoroutingdetailEntity_sfc_moroutingdetail].[WcId]=[MMWorkCenterEntity_sfc_workcenter].[WcId]
 
 WHERE 1=1   and [MMSfcMoroutingEntity_sfc_morouting].MoDId =  " + MoDId + " order by [MMSfcMoroutingdetailEntity_sfc_moroutingdetail].OpSeq";
            dt = clsSQLCommond.ExecQuery(sSQL);

            gridControl1.DataSource = dt;
        }

        private void btnEnsure_Click(object sender, EventArgs e)
        {
            string sErr = "";
            if (dt != null)
            {
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    if (dt.Rows[i]["iChk"].ToString() == "√")
                    {
                        OpSeq = dt.Rows[i]["OpSeq"].ToString();
                    }
                }
            }
            if (OpSeq == null || OpSeq=="")
            {
                MessageBox.Show("请至少选择一道工序");
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void button查询_Click(object sender, EventArgs e)
        {
            try
            {
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.IsRowSelected(i))
                {
                    if (gridView1.GetRowCellValue(i, gridCol选择).ToString().Trim() == "")
                    {
                        gridView1.SetRowCellValue(i, gridCol选择, "√");
                    }
                    else
                    {
                        gridView1.SetRowCellValue(i, gridCol选择, "");
                    }
                }
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = null;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int iRow = 0;
            try
            {
                if (gridView1.FocusedRowHandle >= 0)
                    iRow = gridView1.FocusedRowHandle;
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }

            }
      
    }
}
