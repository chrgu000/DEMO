using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 销售
{
    public partial class Frm委外订单_New : Form
    {
        string tablename = "MO_MOMain";
        string tableid = "ID";
        string tablecode = "cMOCode";
        string tablenames = "MO_MODetails";
        string tableids = "AutoID";

        protected 系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
        protected 系统服务.ClsGetSQL clsGetSQL = 系统服务.ClsGetSQL.Instance();
        public string 红蓝标志;
        public string 客户;
        public DataTable dt;

        public Frm委外订单_New()
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
            string sSQL = "";
            sSQL = @"select a.*,'' as iChk, cClosesysPerson,cClosesysTime,b.AutoID,null as BoxQty,i.D1 as sBoxQty,cast(null as decimal(16,6)) as sBoxNo,i.D2 as Qty,
            b.cInvCode, isnull(b.iQuantity,0)-isnull(f.iQuantity,0) as iQuantity, isnull(b.iNum,0)-isnull(f.iNum,0) as iNum, b.iNatTax, b.iTaxRate, 
            b.iChangRate, b.iUnitPrice, b.iUnitPrice*(isnull(b.iQuantity,0)) as iMoney, b.iNatUnitPrice,b.M1,c.M2,b.M3,b.M4,b.M5,b.M6,b.M7,b.M8,b.M9,b.M10 
            from dbo." + tablename + " a left join " + tablenames + " b on a.ID=b.ID "
            + " left join (select MOAutoID,sum(isnull(iQuantity,0)) as iQuantity,sum(isnull(iNum,0)) as iNum from SO_SOPackingDetails group by MOAutoID) f on b.AutoID=f.MOAutoID "
            + " left join Inventory i on b.cInvCode=i.cInvCode left join (select MOAutoID,max(M2) as M2 from  RdRecord12 a left join RdRecords12 b on a.ID=b.ID where cMSCode='0004' group by MOAutoID) c on b.AutoID=c.MOAutoID "
            + " where isnull(b.iQuantity,0)-isnull(f.iQuantity,0)>0 and a.dVerifysysPerson is not null and a.dClosesysPerson is null and b.cClosesysPerson is null and cMSCode='0004' and c.m2 is not null";

            if (lookUpEdit单据号1.EditValue!=null && lookUpEdit单据号1.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and a." + tablecode + ">='" + lookUpEdit单据号1.EditValue.ToString().Trim() + "'";
            }
            if (lookUpEdit单据号2.EditValue!=null && lookUpEdit单据号2.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and a." + tablecode + "<='" + lookUpEdit单据号2.EditValue.ToString().Trim() + "'";
            }
            if (dateEdit单据日期1.EditValue!=null && dateEdit单据日期1.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and dDate='" + dateEdit单据日期1.EditValue.ToString().Trim() + "'";
            }
            if (dateEdit单据日期2.EditValue!=null && dateEdit单据日期2.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and dDate<='" + dateEdit单据日期2.EditValue.ToString().Trim() + "'";
            }
            if (buttonEdit物料编码1.EditValue != null && buttonEdit物料编码1.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and b.cInvCode>= '" + buttonEdit物料编码1.EditValue.ToString().Trim() + "'";
            }
            if (buttonEdit物料编码2.EditValue != null && buttonEdit物料编码2.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and b.cInvCode<= '" + buttonEdit物料编码2.EditValue.ToString().Trim() + "'";
            }
            
            sSQL = sSQL + " order by  a." + tablecode;
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
            系统服务.LookUp.MO_MOMain(lookUpEdit单据号1);
            系统服务.LookUp.MO_MOMain(lookUpEdit单据号2);

            系统服务.LookUp.Inventory(lookUpEdit物料编码1);
            系统服务.LookUp.Inventory(lookUpEdit物料编码2);

            系统服务.LookUp.ColorNo(ItemLookUpEditM1);

            系统服务.LookUp.Inventory(ItemLookUpEdit物料名称);
            ItemLookUpEdit物料名称.Properties.DisplayMember = "cInvName";
            系统服务.LookUp.Inventory(ItemLookUpEdit物料规格);
            ItemLookUpEdit物料规格.Properties.DisplayMember = "cInvStd";

     
        }

        private void btnEnsure_Click(object sender, EventArgs e)
        {
            string bCode = "";
            bool b = true;
            string sErr = "";
            if (dt != null)
            {
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    if (dt.Rows[i]["iChk"].ToString() == "√")
                    {
                        if (bCode == "")
                        {
                            bCode = dt.Rows[i]["ID"].ToString();
                        }
                        else
                        {
                            if (bCode != dt.Rows[i]["ID"].ToString())
                            {
                                b = false;
                            }
                        }
                        if (dt.Rows[i]["M1"].ToString() == "")
                        {
                            sErr = sErr + "行" + (i + 1) + "色号不能为空\n";
                        }
                        if (dt.Rows[i]["M2"].ToString() == "")
                        {
                            sErr = sErr + "行" + (i + 1) + "缸号不能为空0\n";
                        }
                        if (dt.Rows[i]["BoxQty"].ToString() == "")
                        {
                            sErr = sErr + "行" + (i + 1) + "箱数不能为0\n";
                        }
                        if (dt.Rows[i]["sBoxQty"].ToString() == "")
                        {
                            sErr = sErr + "行" + (i + 1) + "每箱盒数不能为0\n";
                        }
                        if (dt.Rows[i]["Qty"].ToString() == "")
                        {
                            sErr = sErr + "行" + (i + 1) + "每盒数量不能为0\n";
                        }
                    }
                    if (dt.Rows[i]["iChk"].ToString() != "√")
                    {
                        dt.Rows.Remove(dt.Rows[i]);
                    }
                }
            }
            if (sErr != "")
            {
                MessageBox.Show(sErr);
            }
            else if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("请至少选择一张单据");
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
            if (e.Column == gridCol数量 || e.Column == gridCol箱数 || e.Column == gridCol盒数)
            {
                decimal 数量 = 0;
                decimal 箱数 = 0;
                decimal 盒数 = 0;
                if (gridView1.GetRowCellValue(iRow, gridCol数量) != null && gridView1.GetRowCellValue(iRow, gridCol数量).ToString().Trim() != "")
                {
                    数量 = Convert.ToDecimal(gridView1.GetRowCellValue(iRow, gridCol数量));
                }
                if (gridView1.GetRowCellValue(iRow, gridCol箱数) != null && gridView1.GetRowCellValue(iRow, gridCol箱数).ToString().Trim() != "")
                {
                    箱数 = Convert.ToDecimal(gridView1.GetRowCellValue(iRow, gridCol箱数));
                }
                if (gridView1.GetRowCellValue(iRow, gridCol盒数) != null && gridView1.GetRowCellValue(iRow, gridCol盒数).ToString().Trim() != "")
                {
                    盒数 = Convert.ToDecimal(gridView1.GetRowCellValue(iRow, gridCol盒数));
                }
                decimal 可用量 = Convert.ToDecimal(gridView1.GetRowCellValue(iRow, gridCol可用数量));
                if (可用量 < 数量 * 箱数 * 盒数)
                {
                    //if (e.Column == gridCol数量)
                    //{
                    //    gridView1.SetRowCellValue(iRow, gridCol数量, 可用量 / (箱数 * 盒数));
                    //}
                    //if (e.Column == gridCol箱数)
                    //{
                    //    gridView1.SetRowCellValue(iRow, gridCol箱数, 可用量 / (盒数 * 数量));
                    //}
                    //if (e.Column == gridCol盒数)
                    //{
                    //    gridView1.SetRowCellValue(iRow, gridCol盒数, 可用量 / (箱数 * 数量));
                    //}
                    //MessageBox.Show("超出库存数量");
                }
            }


            #region M1
            if (e.Column == gridM1)
            {
                string invocde = gridView1.GetRowCellValue(iRow, gridCol物料编码).ToString().Trim();
                string M1 = gridView1.GetRowCellValue(iRow, gridM1).ToString().Trim();
                if (invocde != "" && M1 != "")
                {
                    bool b = false;
                    string sSQL = "select M1 from Inventory where cInvCode='" + invocde + "'";
                    DataTable dts = clsSQLCommond.ExecQuery(sSQL);
                    if (dts.Rows.Count > 0)
                    {
                        string per = dts.Rows[0]["M1"].ToString();
                        per = "," + per.Replace(", ", ",") + ",";
                        if (per.IndexOf("," + M1 + ",") >= 0)
                        {
                            b = true;
                        }
                    }
                    if (b == false)
                    {
                        MessageBox.Show(invocde + "无此色号");
                        if (gridView1.GetRowCellValue(iRow, gridColM1).ToString().Trim() != "")
                        {
                            gridView1.SetRowCellValue(iRow, gridColM1, "");
                        }
                        if (gridView1.GetRowCellValue(iRow, gridM1).ToString().Trim() != "")
                        {
                            gridView1.SetRowCellValue(iRow, gridM1, "");
                        }
                    }
                }
                else
                {
                    if (invocde == "")
                    {
                        MessageBox.Show(invocde + "未选择存货");
                    }
                    if (gridView1.GetRowCellValue(iRow, gridColM1).ToString().Trim() != "")
                    {
                        gridView1.SetRowCellValue(iRow, gridColM1, "");
                    }
                    if (gridView1.GetRowCellValue(iRow, gridM1).ToString().Trim() != "")
                    {
                        gridView1.SetRowCellValue(iRow, gridM1, "");
                    }
                }
            }
            #endregion
        }

        private void ItemLookUpEditM1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            
        }

        private void ItemButtonEditM1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int iRow = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.IsRowSelected(i))
                {
                    iRow = i;
                }
            }
            string invocde = gridView1.GetRowCellValue(iRow, gridCol物料编码).ToString().Trim();
            系统服务.Frm参照 frm = new 系统服务.Frm参照(21, invocde);
            if (DialogResult.OK == frm.ShowDialog())
            {
                gridView1.SetRowCellValue(iRow, gridColM1, frm.sID);
                frm.Enabled = true;
            }
        }


    }
}
