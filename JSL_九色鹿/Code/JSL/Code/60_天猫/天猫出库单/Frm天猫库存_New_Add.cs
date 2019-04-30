using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 系统服务
{
    public partial class Frm天猫库存_New_Add : Form
    {
        string sSQL;
        protected 系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
        protected 系统服务.ClsGetSQL clsGetSQL = 系统服务.ClsGetSQL.Instance();
        protected 系统服务.公共调用 clsPublic = new 系统服务.公共调用();
        public string 红蓝标志;
        public string 客户;
        public DataTable dt;
        public DataTable dthas;
        public string cRsCode;
        public int Flag=0;//0 单选  1 多选 有传入需要存货 2 多选 未传入需要存货

        public Frm天猫库存_New_Add()
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

        private void Frm天猫库存_New_Add_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookUpEdit();
                if (cRsCode == "1102")
                {
                    gridCol选中卷数.Visible = false;
                    gridCol卷数.Visible = false;
                    gridCol单卷数量.Visible = false;
                }
                else
                {
                    gridCol选中数量.Visible = false;
                }
                //if (Flag == 1)
                //{
                //    gridCol选中卷数.Visible = true;
                //}
                //if (lookUpEdit物料编码1.Text != "" || lookUpEdit物料编码2.Text != "")
                //{
                //    buttonEdit物料编码1.Enabled = false;
                //    buttonEdit物料编码2.Enabled = false;
                //}
                //else
                //{
                //    buttonEdit物料编码1.Enabled = true;
                //    buttonEdit物料编码2.Enabled = true;
                //}
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败：" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void GetGrid()
        {
            sSQL = @"select cast(0 as bit) as iChk,isnull(case when a.flag=1 then b.iQty else -b.iQty end,0)-isnull(b.OutiQty,0) as iQty, 
iSubQty-isnull(OutiSubQty,0) as iSubQty,iUnitQty,   
a.ID, a.cSubCode, dDate, cPersonCode, cOperator, cDepCode, a.cWhCode, cCusCode, cVenCode,a.cRSCode, b.AutoID,b.cInvCode,
b.M1,b.M2,b.sBoxNo
,convert(decimal(18, 6),null) as chkQty ,convert(decimal(18, 6),null) as chkSubQty 
,i.cInvName
from SubRecord01 a left join SubRecords01 b on a.ID=b.ID 
left join Inventory i on b.cInvCode=i.cInvCode
left join InventoryContrast ic on b.cInvCode=ic.cInvCode
where isnull(b.iQty,0)-isnull(b.OutiQty,0)>0 and ic.cInvCode is not null
and a.dVerifysysPerson is not null and a.dClosesysPerson is null and 1=1  ";
            
            if (lookUpEdit单据号1.EditValue!=null && lookUpEdit单据号1.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cSubCode>='" + lookUpEdit单据号1.EditValue.ToString().Trim() + "'");
            }
            if (lookUpEdit单据号2.EditValue!=null && lookUpEdit单据号2.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cSubCode<='" + lookUpEdit单据号2.EditValue.ToString().Trim() + "'");
            }
            if (dateEdit单据日期1.EditValue!=null && dateEdit单据日期1.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and dDate='" + dateEdit单据日期1.EditValue.ToString().Trim() + "'");
            }
            if (dateEdit单据日期2.EditValue!=null && dateEdit单据日期2.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and dDate<='" + dateEdit单据日期2.EditValue.ToString().Trim() + "'");
            }
            if (buttonEdit物料编码1.EditValue != null && buttonEdit物料编码1.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and b.cInvCode>= '" + buttonEdit物料编码1.EditValue.ToString().Trim() + "'");
            }
            if (buttonEdit物料编码2.EditValue != null && buttonEdit物料编码2.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and b.cInvCode<= '" + buttonEdit物料编码2.EditValue.ToString().Trim() + "'");
            }
            if (textEdit色号.EditValue != null && textEdit色号.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and b.M1= '" + textEdit色号.EditValue.ToString().Trim() + "'");
            }
            if (textEdit缸号.EditValue != null && textEdit缸号.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and b.M2= '" + textEdit缸号.EditValue.ToString().Trim() + "'");
            }

            if (cRsCode == "1102")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and cRsCode='0102' ");
            }
            else
            {
                sSQL = sSQL.Replace("1=1", "1=1 and cRsCode='0101' ");
            }
            if (dthas!=null && dthas.Rows.Count != 0)
            {
                string s = "";
                for (int i = 0; i < dthas.Rows.Count; i++)
                {
                    if (dthas.Rows[i]["SubAutoID"].ToString() != "")
                    {
                        if (s != "")
                        {
                            s = s + ",";
                        }
                        s = s + dthas.Rows[i]["SubAutoID"].ToString();
                    }
                }
                if (s.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.AutoID not in (" + s + ")");
                }
            }
            sSQL = sSQL + " order by  a.cSubCode" ;
            DataTable dtgrid = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dtgrid;
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
            系统服务.LookUp.Inventory(lookUpEdit物料编码1);
            系统服务.LookUp.Inventory(lookUpEdit物料编码2);
            
        }

        private void btnEnsure_Click(object sender, EventArgs e)
        {
            string sErr = "";

            dt = new DataTable();
            dt.Columns.Add("cInvCode");
            dt.Columns.Add("M1");
            dt.Columns.Add("M2");
            dt.Columns.Add("sBoxNo");
            dt.Columns.Add("iQty", typeof(decimal));
            dt.Columns.Add("iUnitQty", typeof(decimal));
            dt.Columns.Add("chkSubQty", typeof(decimal));
            dt.Columns.Add("AutoID", typeof(long));

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridCol选择).ToString()))
                {
                    DataRow dw = dt.NewRow();

                    dw["cInvCode"] = gridView1.GetRowCellValue(i, gridCol物料编码);
                    dw["sBoxNo"] = gridView1.GetRowCellValue(i, gridCol盒号);
                    dw["M1"] = gridView1.GetRowCellValue(i, gridColM1);
                    dw["M2"] = gridView1.GetRowCellValue(i, gridColM2);
                    dw["iQty"] = gridView1.GetRowCellValue(i, gridCol选中数量);
                    dw["iUnitQty"] = gridView1.GetRowCellValue(i, gridCol单卷数量);
                    dw["chkSubQty"] = gridView1.GetRowCellValue(i, gridCol选中卷数);
                    dw["AutoID"] = gridView1.GetRowCellValue(i, gridColAutoID);

                    dt.Rows.Add(dw);
                }
            }
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("请至少选择一张单据");
                GetGrid();
            }
            else if (sErr != "")
            {
                MessageBox.Show(sErr);
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

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView1.FocusedRowHandle >= 0)
                {
                    iRow = gridView1.FocusedRowHandle;
                }
                //if (e.Column == gridCol选中卷数)
                //{
                //    decimal d单卷数量 = clsPublic.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol单卷数量).ToString());

                //    if (d单卷数量>0)
                //    {
                //        gridView1.SetRowCellValue(iRow, gridCol选中数量, d单卷数量);
                //    }
                //    else
                //    {
                //        gridView1.SetRowCellValue(iRow, gridCol选中数量, null);
                //    }
                //}
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            lookUpEdit单据号1.EditValue = "";
            lookUpEdit单据号2.EditValue = "";
            buttonEdit物料编码1.EditValue = "";
            buttonEdit物料编码2.EditValue = "";
            lookUpEdit物料编码1.EditValue = "";
            lookUpEdit物料编码2.EditValue = "";
            gridControl1.DataSource = null;
        }

        private void buttonEdit物料编码1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(1);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit物料编码1.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit物料编码2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(1);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit物料编码2.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit物料编码1_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit物料编码1.Text.Trim() != "")
                lookUpEdit物料编码1.EditValue = buttonEdit物料编码1.Text.Trim();
            else
                lookUpEdit物料编码1.EditValue = null;
        }

        private void buttonEdit物料编码1_Leave(object sender, EventArgs e)
        {
            if (buttonEdit物料编码1.Text.Trim() == "")
                return;
            if (lookUpEdit物料编码1.Text.Trim() == "")
            {
                buttonEdit物料编码1.Text = "";
                buttonEdit物料编码1.Focus();
            }
        }

        private void buttonEdit物料编码2_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit物料编码2.Text.Trim() != "")
                lookUpEdit物料编码2.EditValue = buttonEdit物料编码2.Text.Trim();
            else
                lookUpEdit物料编码2.EditValue = null;
        }

        private void buttonEdit物料编码2_Leave(object sender, EventArgs e)
        {
            if (buttonEdit物料编码2.Text.Trim() == "")
                return;
            if (lookUpEdit物料编码2.Text.Trim() == "")
            {
                buttonEdit物料编码2.Text = "";
                buttonEdit物料编码2.Focus();
            }
        }

        private void ItemCheckEdit选择_CheckedChanged(object sender, EventArgs e)
        {
            int iRow = gridView1.FocusedRowHandle;
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            if (cRsCode == "1102")
            {
                decimal d数量 = clsPublic.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol数量).ToString());

                if (Convert.ToBoolean(gridView1.GetRowCellValue(iRow, gridCol选择)))
                {
                    gridView1.SetRowCellValue(iRow, gridCol选中数量, d数量);
                }
                else
                {
                    gridView1.SetRowCellValue(iRow, gridCol选中数量, null);
                }
            }
            else
            {
                decimal d卷数 = clsPublic.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol卷数).ToString());

                if (Convert.ToBoolean(gridView1.GetRowCellValue(iRow, gridCol选择)))
                {
                    gridView1.SetRowCellValue(iRow, gridCol选中卷数, d卷数);
                }
                else
                {
                    gridView1.SetRowCellValue(iRow, gridCol选中卷数, null);
                }
            }
        }

        private void checkEditChk_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                gridView1.SetRowCellValue(i, gridCol选择, checkEditChk.Checked);
            }
        }

    }
}
