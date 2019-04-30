using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorkInformation
{
    public partial class FrmWorkPlan_SEL : Form
    {
        protected FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
        protected FrameBaseFunction.ClsGetSQL clsGetSQL = FrameBaseFunction.ClsGetSQL.Instance();

        public DataTable dtSEL = new DataTable();
        public int iPageSEL = 0;
        public FrmWorkPlan_SEL()
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

        private void FrmWorkPlanSEL_Load(object sender, EventArgs e)
        {
            GetLookUp();
        }

        private void btnSEL_Click(object sender, EventArgs e)
        {
            string sSQL = "SELECT a.单据号, a.单据日期, a.排产完工日期, a.数量, a.产品编码, a.销售订单号, a.销售订单行号, a.帐套号, a.备注, a.时间戳, a.创建人, a.创建日期, a.审核人,a.审核日期,c.cItemCode as 外销订单号,b.cDefine2 as 客户订单号, d.cCusName  as 客户,e.cInvName as 产品名称,e.cInvStd as 产品规格 " +
                          "FROM 生产计划 AS a inner JOIN @u8.SO_SOMain AS b ON a.销售订单号 = b.cSOCode inner JOIN @u8.SO_SODetails AS c ON c.ID = b.ID AND a.销售订单行号 = c.iRowNo " +
                                "left join @u8.Customer  d on d.cCusCode = b.cCusCode left join @u8.Inventory e on e.cInvCode = a.产品编码 where 1 = 1 and 帐套号 = '200' ";
             
            if (lookUpEdit单据号1.Text.Trim() != "")
            {
                sSQL = sSQL + " and a.单据号 >= '" + lookUpEdit单据号1.EditValue + "' ";
            }
            if (lookUpEdit单据号2.Text.Trim() != "")
            {
                sSQL = sSQL + " and a.单据号 <= '" + lookUpEdit单据号2.EditValue + "' ";
            }
            if(dtm单据日期1.Text.Trim() != "")
            {
                sSQL = sSQL + " and a.单据日期 >= '" + dtm单据日期1.DateTime.ToString("yyyy-MM-dd") + "' ";
            }
            if (dtm单据日期2.Text.Trim() != "")
            {
                sSQL = sSQL + " and a.单据日期 <= '" + dtm单据日期2.DateTime.ToString("yyyy-MM-dd") + "' ";
            }
            if (lookUpEdit销售订单号1.Text.Trim() != "")
            {
                sSQL = sSQL + " and a.销售订单号 >= '" + lookUpEdit销售订单号1.EditValue + "' ";
            }
            if (lookUpEdit销售订单号2.Text.Trim() != "")
            {
                sSQL = sSQL + " and a.销售订单号 <= '" + lookUpEdit销售订单号2.EditValue + "' ";
            }
            if (lookUpEdit外销订单号1.Text.Trim() != "")
            {
                sSQL = sSQL + " and c.cItemCode >= '" + lookUpEdit外销订单号1.EditValue + "' ";
            }
            if (lookUpEdit外销订单号2.Text.Trim() != "")
            {
                sSQL = sSQL + " and c.cItemCode <= '" + lookUpEdit外销订单号2.EditValue + "' ";
            }
            if (dtm完工日期1.Text.Trim() != "")
            {
                sSQL = sSQL + " and a.排产完工日期 >= '" + dtm完工日期1.DateTime.ToString("yyyy-MM-dd") + "' ";
            }
            if (dtm完工日期2.Text.Trim() != "")
            {
                sSQL = sSQL + " and a.排产完工日期 <= '" + dtm完工日期2.DateTime.ToString("yyyy-MM-dd") + "' ";
            }
            if (lookUpEdit客户订单号1.Text.Trim() != "")
            {
                sSQL = sSQL + " and b.cDefine2 >= '" + lookUpEdit客户订单号1.EditValue + "' ";
            }
            if (lookUpEdit客户订单号2.Text.Trim() != "")
            {
                sSQL = sSQL + " and b.cDefine2 <= '" + lookUpEdit客户订单号2.EditValue + "' ";
            }
            dtSEL = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dtSEL;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                dtSEL = (DataTable)gridControl1.DataSource;
                iPageSEL = gridView1.FocusedRowHandle;
                if (dtSEL == null || dtSEL.Rows.Count < 1)
                {
                    throw new Exception("没有数据");
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch(Exception ee)
            {
                MessageBox.Show("查询失败:" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void GetLookUp()
        {
            string sSQL = "SELECT distinct 单据号 as iID from 生产计划 order by 单据号";
            DataTable dt = clsGetSQL.GetLookUpEdit(sSQL);
            lookUpEdit单据号1.Properties.DataSource = dt;
            lookUpEdit单据号2.Properties.DataSource = dt;

            sSQL = "SELECT distinct 销售订单号 as iID from 生产计划 order by 销售订单号";
            dt = clsGetSQL.GetLookUpEdit(sSQL);
            lookUpEdit销售订单号1.Properties.DataSource = dt;
            lookUpEdit销售订单号2.Properties.DataSource = dt;

            sSQL = "SELECT distinct c.cItemCode as iID from 生产计划 a inner JOIN @u8.SO_SOMain b ON a.销售订单号 = b.cSOCode inner JOIN @u8.SO_SODetails c ON c.ID = b.ID AND a.销售订单行号 = c.iRowNo order by cItemCode";
            dt = clsGetSQL.GetLookUpEdit(sSQL);
            lookUpEdit外销订单号1.Properties.DataSource = dt;
            lookUpEdit外销订单号2.Properties.DataSource = dt;

            sSQL = "SELECT distinct b.cDefine2 as iID from 生产计划 a inner JOIN @u8.SO_SOMain b ON a.销售订单号 = b.cSOCode inner JOIN @u8.SO_SODetails c ON c.ID = b.ID AND a.销售订单行号 = c.iRowNo order by b.cDefine2";
            dt = clsGetSQL.GetLookUpEdit(sSQL);
            lookUpEdit客户订单号1.Properties.DataSource = dt;
            lookUpEdit客户订单号2.Properties.DataSource = dt;
        }
    }
}
