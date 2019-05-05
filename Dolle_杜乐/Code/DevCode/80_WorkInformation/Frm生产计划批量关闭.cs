using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace WorkInformation
{
    public partial class Frm生产计划批量关闭 : FrameBaseFunction.Frm列表窗体模板
    {

        DataTable dtWorkPlanDay = new DataTable();
        bool bCheck = false;
        FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();


        public Frm生产计划批量关闭()
        {
            InitializeComponent();
        }

        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    //case "open":
                    //    btnOpen();
                    //    break;
                    case "close":
                        btnClose();
                        break;
                  
                    default:
                        break;
                }
            }
            catch (Exception ee)
            {
                throw new Exception(sBtnText + " 失败! \n\n原因:\n  " + ee.Message);
            }
        }

        private void btnClose()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            if (lookUpEdit外销单号.EditValue == null || lookUpEdit外销单号.Text.Trim() == "")
            {
                throw new Exception("请选择外销单号");
            }

            DialogResult d = MessageBox.Show("确定关闭选中的生产计划么？\n是：继续\n否：取消", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (d != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }
            aList = new System.Collections.ArrayList();

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (!Convert.ToBoolean(gridView1.GetRowCellValue(i, gridView1.Columns["选择"])))
                {
                    continue;
                }

                string sCode = gridView1.GetRowCellValue(i, gridView1.Columns["单据号"]).ToString().Trim();

                sSQL = " update 生产计划明细 set 关闭人 = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',关闭日期 = getdate()  " +
                       " where 表头单据号 = '" + sCode  + "' and 帐套号 = '200'";
                aList.Add(sSQL);
            }

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("关闭成功！\n合计执行语句:" + iCou + "条");
            }
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                lookUpEdit外销单号.Enabled = true;
                lookUpEdit外销单号.Properties.ReadOnly = false;

                SetLookup();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void SetLookup()
        {
            string sSQL = @"
select  distinct so.cSOCode 
from @u8.so_somain so inner join @u8.SO_SODetails sos on so.id = sos.id
where so.dDate >= '2018-01-01' and sos.iQuantity > isnull(sos.iFHQuantity ,0)
	and so.cSOCode in (select 销售订单号 from XWSystemDB_DL.dbo.生产计划)
order by so.cSOCode
";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            lookUpEdit外销单号.Properties.DataSource = dt;
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
            catch { }
        }

        private void btnSEL_Click(object sender, EventArgs e)
        {
            try
            {
                if (lookUpEdit外销单号.EditValue == null || lookUpEdit外销单号.Text.Trim() == "")
                {
                    throw new Exception("请选择外销单号");
                }

                string sSQL = @"
select cast(0 as bit) as 选择, 单据号, 单据日期, 排产完工日期, 数量, 产品编码, 销售订单号, 销售订单行号, 出货周, 备注, 创建人, 创建日期, 审核人, 审核日期
from XWSystemDB_DL.dbo.生产计划 a 
where 销售订单号 = '{0}' 
order by 单据号
";
                sSQL = string.Format(sSQL, lookUpEdit外销单号.Text.Trim());
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                gridControl1.DataSource = dt;
                gridView1.BestFitColumns();

                gridView1.OptionsBehavior.Editable = true;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (gridView1.Columns[i].FieldName.Trim() == "选择")
                    {
                        gridView1.Columns[i].OptionsColumn.AllowEdit = true;
                    }
                    else
                    {
                        gridView1.Columns[i].OptionsColumn.AllowEdit = false;
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridView1.Columns["选择"], chkAll.Checked);
                }
            }
            catch { }
        }
    }
}
