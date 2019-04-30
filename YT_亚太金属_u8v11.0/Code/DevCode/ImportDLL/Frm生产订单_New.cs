using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImportDLL
{
    public partial class Frm生产订单_New : Form
    {
        protected FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
        protected FrameBaseFunction.ClsGetSQL clsGetSQL = FrameBaseFunction.ClsGetSQL.Instance();
        public DataTable dt;
        public string MoDId; 
        public Frm生产订单_New(DataTable sdthas)
        {
           
            InitializeComponent();
        }

        public Frm生产订单_New()
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

        private void Frm生产订单_New_Load(object sender, EventArgs e)
        {
            try
            {

                SetLookUpEdit();
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败：" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void GetGrid()
        {
            string sSQL = @"select a.*,b.*,i.cInvCode,i.cInvName,i.cInvStd,c.StartDate,c.DueDate, cast(0 as bit) as iChk from  
@u8.mom_orderdetail a 
left join @u8.mom_order b on a.MoId=b.MoId
left join @u8.mom_morder c on a.MoDId=c.MoDId
--left join dbo.生产工序日计划 r on b.MoRoutingDId=r.生产订单工艺路线明细ID 
left join @u8.Inventory i on a.InvCode=i.cInvCode where a.MoDId not in (select 生产订单明细iID from 生产工序日计划) ";
            if (lookUpEdit单据号1.EditValue!=null && lookUpEdit单据号1.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and b.MoCode>='" + lookUpEdit单据号1.EditValue.ToString().Trim() + "'";
            }
            if (lookUpEdit单据号2.EditValue!=null && lookUpEdit单据号2.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and b.MoCode<='" + lookUpEdit单据号2.EditValue.ToString().Trim() + "'";
            }
            if (dateEdit单据日期1.EditValue!=null && dateEdit单据日期1.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and StartDate >= '" + dateEdit单据日期1.EditValue.ToString().Trim() + "'";
            }
            if (dateEdit单据日期2.EditValue!=null && dateEdit单据日期2.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and StartDate<='" + dateEdit单据日期2.EditValue.ToString().Trim() + "'";
            }
            if (lookUpEdit物料编码.EditValue != null && lookUpEdit物料编码.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and i.cInvCode= '" + lookUpEdit物料编码.EditValue.ToString().Trim() + "'";
            }

            sSQL = sSQL + "and StartDate>'2014-01-01'  order by  b.MoCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;
        }

        public void Get(string 单据号1, string 单据号2, string 单据日期1, string 单据日期2,string 制单日期1,string 制单日期2,string 业务员,
            string 部门, string 客户1, string 客户2, string 审核日期1, string 审核日期2, string 制单人1, string 制单人2, string 审核人1, string 审核人2)
        {
            lookUpEdit单据号1.EditValue = 单据号1;
            lookUpEdit单据号2.EditValue = 单据号2;
            if (单据日期1 != null && 单据日期1 != "")
            {
                单据日期1 = DateTime.Parse(单据日期1).ToString("yyyy-MM-dd");
                dateEdit单据日期1.EditValue = 单据日期1;
            }
            if (单据日期2 != null && 单据日期2 != "")
            {
                单据日期2 = DateTime.Parse(单据日期2).ToString("yyyy-MM-dd");
                dateEdit单据日期2.EditValue = 单据日期2;
            }
        }

        private void SetLookUpEdit()
        {
            string sSQL = "select MoCode  from @u8.mom_order";
            dt = clsSQLCommond.ExecQuery(sSQL);
            lookUpEdit单据号1.Properties.DataSource = dt;
            lookUpEdit单据号2.Properties.DataSource = dt;

            LookUp.Inventory(lookUpEdit物料编码);
        }

        private void btnEnsure_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.RowCount < 1)
                    return;
                string sErr = "";
                string cinvcode = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["iChk"].ToString().Trim().ToUpper() == "TRUE" )
                    {
                        if (cinvcode == "")
                        {
                            cinvcode = dt.Rows[i]["cInvCode"].ToString().Trim();
                        }
                        else if (cinvcode != dt.Rows[i]["cInvCode"].ToString().Trim())
                        {
                            sErr = sErr + "第" + i + "行存货编码不一致\n";
                        }
                    }
                }
                if (sErr != "")
                {
                    MessageBox.Show(sErr);
                }
                else
                {
                    for (int i = dt.Rows.Count - 1; i >= 0; i--)
                    {
                        if (dt.Rows[i]["iChk"].ToString().Trim().ToUpper() != "TRUE")
                        {
                            dt.Rows.Remove(dt.Rows[i]);
                        }
                    }
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
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
            //for (int i = 0; i < gridView1.RowCount; i++)
            //{
            //    if (gridView1.IsRowSelected(i))
            //    {
            //        if (gridView1.GetRowCellValue(i, gridCol选择) == "")
            //        {
            //            gridView1.SetRowCellValue(i, gridCol选择, "√");
            //        }
            //        else
            //        {
            //            gridView1.SetRowCellValue(i, gridCol选择, "");
            //        }
            //    }
            //}
        }

        private void ItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            //DevExpress.XtraEditors.CheckEdit edit = sender as DevExpress.XtraEditors.CheckEdit;
            //int iRow = gridView1.FocusedRowHandle;
            //for (int i = 0; i < gridView1.RowCount; i++)
            //{
            //    if (i != iRow)
            //    {
            //        gridView1.SetRowCellValue(i, gridCol选择, false);
            //    }
            //}
        }

        private void buttonEdit物料编码_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmInvInfo frm = new FrmInvInfo("", false);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit物料编码.EditValue = frm.sInvCode;

                frm.Enabled = true;
            }
        }

        private void buttonEdit物料编码_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit物料编码.Text.Trim() != "")
                lookUpEdit物料编码.EditValue = buttonEdit物料编码.Text.Trim();
            else
                lookUpEdit物料编码.EditValue = null;
        }

        private void buttonEdit物料编码_Leave(object sender, EventArgs e)
        {

        }

     
    }
}
