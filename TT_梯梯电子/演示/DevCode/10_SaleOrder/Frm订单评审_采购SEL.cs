using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SaleOrder
{
    public partial class Frm订单评审_采购SEL : Form
    {
        protected FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
        protected FrameBaseFunction.ClsGetSQL clsGetSQL = FrameBaseFunction.ClsGetSQL.Instance();

        //public DataTable dtSEL = new DataTable();

        public long i销售订单ID = 0;

        public Frm订单评审_采购SEL()
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

        private void Frm订单评审_SEL_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            dtm单据日期1.Text = Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyy-MM-01");
            dtm单据日期2.Text =DateTime.Parse( Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyy-MM-01")).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");

            GetLookUp();
        }

        private void btnSEL_Click(object sender, EventArgs e)
        {
            string sSQL = "select *,cast(null as varchar(50)) as 采购评审,cast(null as varchar(50)) as 锁定 from 订单评审运算1 where 帐套号 = '" + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim() + "' and isnull(审核人,'') <> '' and isnull(关闭人,'') = '' ";
 
            if(dtm单据日期1.Text.Trim() != "")
            {
                sSQL = sSQL + " and 制单日期 >= '" + dtm单据日期1.DateTime.ToString("yyyy-MM-dd") + "' ";
            }
            if (dtm单据日期2.Text.Trim() != "")
            {
                sSQL = sSQL + " and 制单日期 < '" + dtm单据日期2.DateTime.AddDays(1).ToString("yyyy-MM-dd") + "' ";
            }
            if (lookUpEdit销售订单号1.Text.Trim() != "")
            {
                sSQL = sSQL + " and 销售订单号 >= '" + lookUpEdit销售订单号1.EditValue + "' ";
            }
            if (lookUpEdit销售订单号2.Text.Trim() != "")
            {
                sSQL = sSQL + " and 销售订单号 <= '" + lookUpEdit销售订单号2.EditValue + "' ";
            }
            if (lookUpEdit外销订单号1.Text.Trim() != "")
            {
                sSQL = sSQL + " and 外销订单号 >= '" + lookUpEdit外销订单号1.EditValue + "' ";
            }
            if (lookUpEdit外销订单号2.Text.Trim() != "")
            {
                sSQL = sSQL + " and 外销订单号 <= '" + lookUpEdit外销订单号2.EditValue + "' ";
            }
          
            if (lookUpEdit客户订单号1.Text.Trim() != "")
            {
                sSQL = sSQL + " and 客户订单号 >= '" + lookUpEdit客户订单号1.EditValue + "' ";
            }
            if (lookUpEdit客户订单号2.Text.Trim() != "")
            {
                sSQL = sSQL + " and 客户订单号 <= '" + lookUpEdit客户订单号2.EditValue + "' ";
            }

            sSQL = sSQL + " and isnull(下达请购人,'') <> '' ";
          
            if (radio未评审.Checked)
            {
                string s子件属性 = "采购";
               
                sSQL = sSQL + " and 销售订单ID in (select 销售订单ID from 订单评审运算3 where 帐套号 = '" + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim() + "' and isnull(回签人,'') = '' and 子件属性 = '" + s子件属性 + "' and isnull(本次下单数量,0) <> 0) ";
            }
          
            sSQL = sSQL + " order by 销售订单号";

            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            for (int i = dt.Rows.Count - 1; i >= 0 ; i--)
            {
                string s回签人 = "";
                string s锁定人 = "";
                string s销售订单ID = dt.Rows[i]["销售订单ID"].ToString().Trim();
                sSQL = "select distinct 回签人,锁定人 from 订单评审运算3 where 子件属性 = '采购' and 帐套号 = '" + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim() + "' and 销售订单ID = " + dt.Rows[i]["销售订单ID"];
                DataTable dtTemp = clsSQLCommond.ExecQuery(sSQL);
                for (int j = 0; j < dtTemp.Rows.Count; j++)
                {
                    if (dtTemp.Rows[j]["回签人"].ToString().Trim() != "")
                    {
                        s回签人 = s回签人 + dtTemp.Rows[j]["回签人"].ToString().Trim();
                    }
                    if (dtTemp.Rows[j]["锁定人"].ToString().Trim() != "")
                    {
                        s锁定人 = s锁定人 + dtTemp.Rows[j]["锁定人"].ToString().Trim();
                    }
                }
                dt.Rows[i]["采购评审"] = s回签人;
                dt.Rows[i]["锁定"] = s锁定人;

            }

            gridControl1.DataSource = dt;
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
                string sSQL = "select cCusCode,cCusName,cCusAbbName from @u8.Customer order by cCusCode";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                ItemLookUpEdit客户编码.DataSource = dt;
                ItemLookUpEdit客户简称.DataSource = dt;

                sSQL = "SELECT distinct cSOCode as iID from @u8.SO_SOMain where isnull(cCloser,'') = '' and isnull(cVerifier,'') <> '' and cSOCode not in (select 销售订单号 from dbo.订单评审表头) order by cSOCode";
                dt = clsGetSQL.GetLookUpEdit(sSQL);
                lookUpEdit销售订单号1.Properties.DataSource = dt;
                lookUpEdit销售订单号2.Properties.DataSource = dt;

                sSQL = "SELECT distinct cDefine11 as iID from @u8.SO_SOMain where isnull(cCloser,'') = '' and isnull(cVerifier,'') <> '' and cSOCode not in (select 销售订单号 from dbo.订单评审表头) order by cDefine11";
                dt = clsGetSQL.GetLookUpEdit(sSQL);
                lookUpEdit外销订单号1.Properties.DataSource = dt;
                lookUpEdit外销订单号2.Properties.DataSource = dt;

                sSQL = "SELECT distinct cDefine2 as iID from @u8.SO_SOMain where isnull(cCloser,'') = '' and isnull(cVerifier,'') <> '' and cSOCode not in (select 销售订单号 from dbo.订单评审表头) order by cDefine2";
                //dt = clsGetSQL.GetLookUpEdit(sSQL);
                dt = clsSQLCommond.ExecQuery(sSQL);
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
