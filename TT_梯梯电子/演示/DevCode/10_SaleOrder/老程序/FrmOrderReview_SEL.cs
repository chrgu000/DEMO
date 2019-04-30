using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SaleOrder
{
    public partial class FrmOrderReview_SEL : Form
    {
        protected FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
        protected FrameBaseFunction.ClsGetSQL clsGetSQL = FrameBaseFunction.ClsGetSQL.Instance();

        //public DataTable dtSEL = new DataTable();
        public string sSEL = "";
        public int iPageSEL = 0;
        public FrmOrderReview_SEL()
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

        private void FrmOrderReview_SEL_Load(object sender, EventArgs e)
        {
            GetLookUp();
        }

        private void btnSEL_Click(object sender, EventArgs e)
        {
            string sSQL = "SELECT a.单据号, a.单据日期, a.产品编码, a.销售订单号, a.行号, a.帐套号, a.年度, a.备注, a.时间戳, a.制单, a.制单日期, a.审核,a.审核日期,c.cItemCode as 外销订单号,b.cDefine2 as 客户订单号, d.cCusName  as 客户,e.cInvName as 产品名称,e.cInvStd as 产品规格 " +
                          "FROM 订单评审表头 AS a inner JOIN @u8.SO_SOMain AS b ON a.销售订单号 = b.cSOCode inner JOIN @u8.SO_SODetails AS c ON c.ID = b.ID AND a.行号 = c.iRowNo " +
                                "left join @u8.Customer  d on d.cCusCode = b.cCusCode left join @u8.Inventory e on e.cInvCode = a.产品编码 where 1 = 1 ";
           
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
          
            if (lookUpEdit客户订单号1.Text.Trim() != "")
            {
                sSQL = sSQL + " and b.cDefine2 >= '" + lookUpEdit客户订单号1.EditValue + "' ";
            }
            if (lookUpEdit客户订单号2.Text.Trim() != "")
            {
                sSQL = sSQL + " and b.cDefine2 <= '" + lookUpEdit客户订单号2.EditValue + "' ";
            }
            sSQL = sSQL + " order by a.iID";

            gridControl1.DataSource = clsSQLCommond.ExecQuery(sSQL);

            sSEL = sSQL;
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

                //dtSEL = (DataTable)gridControl1.DataSource;
                iPageSEL = gridView1.FocusedRowHandle;
                //if (dtSEL == null || dtSEL.Rows.Count < 1)
                //{
                //    throw new Exception("没有数据");
                //}

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch(Exception ee)
            {
                MessageBox.Show("查询失败:" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void GetLookUp()
        {
            string sSQL = "SELECT distinct 单据号 as iID from 订单评审表头 order by 单据号";
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

            sSQL = "SELECT distinct c.cDefine2 as iID from 生产计划 a inner JOIN @u8.SO_SOMain b ON a.销售订单号 = b.cSOCode inner JOIN @u8.SO_SODetails c ON c.ID = b.ID AND a.销售订单行号 = c.iRowNo order by cDefine2";
            dt = clsGetSQL.GetLookUpEdit(sSQL);
            lookUpEdit客户订单号1.Properties.DataSource = dt;
            lookUpEdit客户订单号2.Properties.DataSource = dt;
        }
    }
}
