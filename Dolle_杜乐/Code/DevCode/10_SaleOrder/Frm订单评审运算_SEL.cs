using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SaleOrder
{
    public partial class Frm订单评审运算_SEL : Form
    {
        protected FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
        protected FrameBaseFunction.ClsGetSQL clsGetSQL = FrameBaseFunction.ClsGetSQL.Instance();

        //public DataTable dtSEL = new DataTable();

        public long i销售订单ID = 0;

        public Frm订单评审运算_SEL()
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
        }

        private void Frm订单评审运算_SEL_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            dtm单据日期1.Text = Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyy-MM-01");
            dtm单据日期2.Text =DateTime.Parse( Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyy-MM-01")).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");

            GetLookUp();
        }

        private void btnSEL_Click(object sender, EventArgs e)
        {
            string sSQL = "select ID as 销售订单ID,cSOCode as 销售订单号,dDate as 单据日期,cDefine11 as 外销订单号,cDefine2 as 客户订单号,a.cCusCode as 客户编码,b.cCusAbbName as 客户简称,dPreDateBT as 船期,dPreMoDateBT as 预完工日期,cDefine6 as 国外要求交期,a.cMemo as 备注 " +
                            "from @u8.SO_SOMain a left join @u8.Customer b on a.cCusCode = b.cCusCode  " +
                            "where isnull(cCloser,'') = '' and isnull(cVerifier,'') <> '' and cSOCode not in (select 销售订单号 from dbo.订单评审运算1)";
 
            if(dtm单据日期1.Text.Trim() != "")
            {
                sSQL = sSQL + " and dDate >= '" + dtm单据日期1.DateTime.ToString("yyyy-MM-dd") + "' ";
            }
            if (dtm单据日期2.Text.Trim() != "")
            {
                sSQL = sSQL + " and dDate < '" + dtm单据日期2.DateTime.AddDays(1).ToString("yyyy-MM-dd") + "' ";
            }
            if (lookUpEdit销售订单号1.Text.Trim() != "")
            {
                sSQL = sSQL + " and cSOCode >= '" + lookUpEdit销售订单号1.EditValue + "' ";
            }
            if (lookUpEdit销售订单号2.Text.Trim() != "")
            {
                sSQL = sSQL + " and cSOCode <= '" + lookUpEdit销售订单号2.EditValue + "' ";
            }
            if (lookUpEdit外销订单号1.Text.Trim() != "")
            {
                sSQL = sSQL + " and cDefine11 >= '" + lookUpEdit外销订单号1.EditValue + "' ";
            }
            if (lookUpEdit外销订单号2.Text.Trim() != "")
            {
                sSQL = sSQL + " and cDefine11 <= '" + lookUpEdit外销订单号2.EditValue + "' ";
            }
          
            if (lookUpEdit客户订单号1.Text.Trim() != "")
            {
                sSQL = sSQL + " and cDefine2 >= '" + lookUpEdit客户订单号1.EditValue + "' ";
            }
            if (lookUpEdit客户订单号2.Text.Trim() != "")
            {
                sSQL = sSQL + " and cDefine2 <= '" + lookUpEdit客户订单号2.EditValue + "' ";
            }
            sSQL = sSQL + " order by ID";

            gridControl1.DataSource = clsSQLCommond.ExecQuery(sSQL);
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

                i销售订单ID = Convert.ToInt64(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridCol销售订单ID));
              
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch(Exception ee)
            {
                MessageBox.Show("查询失败:" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void GetLookUp()
        {
            try
            {
                string sSQL = "SELECT distinct cSOCode as iID from @u8.SO_SOMain where isnull(cCloser,'') = '' and isnull(cVerifier,'') <> '' and cSOCode not in (select 销售订单号 from dbo.订单评审表头) order by cSOCode";
                DataTable dt = clsGetSQL.GetLookUpEdit(sSQL);
                lookUpEdit销售订单号1.Properties.DataSource = dt;
                lookUpEdit销售订单号2.Properties.DataSource = dt;

                sSQL = "SELECT distinct cDefine11 as iID from @u8.SO_SOMain where isnull(cCloser,'') = '' and isnull(cVerifier,'') <> '' and cSOCode not in (select 销售订单号 from dbo.订单评审表头) order by cDefine11";
                dt = clsGetSQL.GetLookUpEdit(sSQL);
                lookUpEdit外销订单号1.Properties.DataSource = dt;
                lookUpEdit外销订单号2.Properties.DataSource = dt;

                sSQL = "SELECT distinct cDefine2 as iID from @u8.SO_SOMain where isnull(cCloser,'') = '' and isnull(cVerifier,'') <> '' and cSOCode not in (select 销售订单号 from dbo.订单评审表头) order by cDefine2";
                dt = clsGetSQL.GetLookUpEdit(sSQL);
                lookUpEdit客户订单号1.Properties.DataSource = dt;
                lookUpEdit客户订单号2.Properties.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("获得参照信息失败!");
            }
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
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
