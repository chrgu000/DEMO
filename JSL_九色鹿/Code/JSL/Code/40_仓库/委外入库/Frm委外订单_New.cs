using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 仓库
{
    public partial class Frm委外订单_New : Form
    {
        string tablename = "MO_MOMain";
        string tableid = "ID";
        string tablecode = "cMOCode";
        string tablenames = "MO_MODetails";
        string tableids = "AutoID";

        public string cMSCode = "";

        protected 系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
        protected 系统服务.ClsGetSQL clsGetSQL = 系统服务.ClsGetSQL.Instance();
        protected 系统服务.公共调用 clsPublic = new 系统服务.公共调用();
        public string 红蓝标志;
        public DataTable dt;
        DataTable dthas;
        public string 供应商="";
        public Frm委外订单_New(DataTable sdthas, string scMSCode)
        {
           
            InitializeComponent();
            dthas = sdthas;
            cMSCode = scMSCode;
        }

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
                if (红蓝标志 == "")
                {

                    radioGroup蓝红标识.EditValue = "1";
                }
                else
                {
                    radioGroup蓝红标识.EditValue = 红蓝标志;
                }
                if (供应商.Trim() != "")
                {
                    buttonEdit供应商.EditValue = 供应商;
                    buttonEdit供应商.Enabled = false;
                }
                else
                {
                    buttonEdit供应商.Enabled = true;
                }

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
            if (lookUpEdit供应商.EditValue != null && lookUpEdit供应商.EditValue.ToString().Trim() != "")
            {
                供应商 = lookUpEdit供应商.EditValue.ToString().Trim();
            }
            if (供应商.Trim() == "")
                return;

            if (radioGroup蓝红标识.EditValue.ToString().Trim() == "1")
            {
                sSQL = @"select a.*,'' as iChk, cClosesysPerson,cClosesysTime,b.AutoID,b.cInvCode, isnull(b.iQuantity,0)-isnull(b.iInQuantity,0) as iQuantity, isnull(b.iNum,0)-isnull(b.iInNum,0) as iNum, 
b.iNatTax, b.iTaxRate, b.iChangRate, b.iUnitPrice, b.iUnitPrice*(isnull(b.iQuantity,0)-isnull(b.iInQuantity,0)) as iMoney, b.iNatUnitPrice, 
b.iNatUnitPrice*(isnull(b.iQuantity,0)-isnull(b.iInQuantity,0)) as  iNatMoney,b.iOutQuantity as 材料出库数量,b.M1,b.M2,b.M3,b.M4,b.M5,b.M6,b.M7,b.M8,b.M9,b.M10,isnull(b.iQuantity,0) as D3,null as RdAutoID 
from dbo." + tablename + " a  left join " + tablenames + " b on a.ID=b.ID  " +
@"where isnull(b.iQuantity,0)-isnull(b.iInQuantity,0) > 0 and a.dVerifysysPerson is not null and a.dClosesysPerson is null and b.cClosesysPerson is null and cVenCode='" + 供应商 + "' ";
            }
            if (radioGroup蓝红标识.EditValue.ToString().Trim() == "2")
            {
                sSQL = @"select  a.*,'' as iChk, cClosesysPerson,cClosesysTime,b.AutoID,b.cInvCode,-isnull(f.iQuantity,0) as iQuantity, -isnull(f.iNum,0) as iNum,-b.iNatTax, b.iTaxRate, b.iChangRate, b.iUnitPrice,-isnull(f.iMoney,0) as iMoney,b.iNatUnitPrice,- isnull(f.iNatMoney,0) as  iNatMoney,g.iQuantity  as 材料出库数量,b.M1,b.M2,b.M3,b.M4,b.M5,b.M6,b.M7,b.M8,b.M9,b.M10,-isnull(f.D3,0) as D3,f.AutoID as RdAutoID
from dbo." + tablename + " a left join " + tablenames + " b on a.ID=b.ID left join (select AutoID,MOAutoID,sum(iQuantity) as iQuantity,sum(isnull(iNum,0)) as iNum ,sum(isnull(iNatMoney,0)) as iNatMoney ,sum(isnull(iMoney,0)) as iMoney,sum(RdRecords02.D3) as D3 from RdRecords02 left join RdRecord02 on RdRecords02.ID=RdRecord02.ID  group by AutoID,MOAutoID) f on b.AutoID=f.MOAutoID   " +
@"left join (select MOAutoID,RdAutoID,sum(iQuantity) as iQuantity,sum(isnull(iNum,0)) as iNum ,sum(isnull(iNatMoney,0)) as iNatMoney ,sum(isnull(iMoney,0)) as iMoney from RdRecords12 left join RdRecord12  on RdRecords12.ID=RdRecord12.ID  group by MOAutoID,RdAutoID) g on b.AutoID=g.MOAutoID and f.AutoID=g.RdAutoID  
where isnull(f.iQuantity,0)>0 and a.dVerifysysPerson is not null and a.dClosesysPerson is null and b.cClosesysPerson is null  and cVenCode='" + 供应商 + "'";
 
            }
            if (lookUpEdit单据号1.EditValue!=null && lookUpEdit单据号1.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and a.cMOCode>='" + lookUpEdit单据号1.EditValue.ToString().Trim() + "'";
            }
            if (lookUpEdit单据号2.EditValue!=null && lookUpEdit单据号2.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and a.cMOCode<='" + lookUpEdit单据号2.EditValue.ToString().Trim() + "'";
            }
            if (dateEdit单据日期1.EditValue!=null && dateEdit单据日期1.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and dDate >= '" + dateEdit单据日期1.EditValue.ToString().Trim() + "'";
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
            sSQL = sSQL + " and cMSCode='" + cMSCode + "'";
            string s = "";
            if (dthas.Rows.Count != 0)
            {
                
                for (int i = 0; i < dthas.Rows.Count; i++)
                {
                    if (dthas.Rows[i].RowState == DataRowState.Deleted)
                        continue;

                    if (dthas.Rows[i]["MOAutoID"].ToString() != "")
                    {
                        if (s != "")
                        {
                            s = s + ",";
                        }
                        s = s + dthas.Rows[i]["MOAutoID"].ToString();
                    }
                }
            //    if (s.Trim() != "")
            //    {
            //        sSQL = sSQL + " and b.AutoID not in (" + s + ")";
            //    }
            }
            
            sSQL = sSQL + " order by  a." + tableid;
            dt = clsSQLCommond.ExecQuery(sSQL);
            if (s != "")
            {
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    if (dt.Rows[i]["AutoID"].ToString().IndexOf(s) >= 0)
                    {
                        decimal c = clsPublic.ReturnDecimal(dthas.Compute("sum(D3)", "MOAutoID='" + dt.Rows[i]["AutoID"].ToString() + "'"));
                        decimal d3 = clsPublic.ReturnDecimal(dt.Rows[i]["iQuantity"]) - c;
                        decimal iQty = clsPublic.ReturnDecimal(dt.Rows[i]["iQuantity"]) - clsPublic.ReturnDecimal(dthas.Compute("sum(iQuantity)", "MOAutoID='" + dt.Rows[i]["AutoID"].ToString() + "'")); ;
                        if (d3 != 0)
                        {
                            dt.Rows[i]["iQuantity"] = iQty;
                            dt.Rows[i]["D3"] = d3;
                        }
                        else
                        {
                            dt.Rows.Remove(dt.Rows[i]);
                        }
                    }
                }
            }
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

            系统服务.LookUp.Inventory(ItemLookUpEdit物料名称);
            ItemLookUpEdit物料名称.Properties.DisplayMember = "cInvName";
            系统服务.LookUp.Inventory(ItemLookUpEdit物料规格);
            ItemLookUpEdit物料规格.Properties.DisplayMember = "cInvStd";
            系统服务.LookUp.Inventory(ItemLookUpEdit物料代码);
            ItemLookUpEdit物料规格.Properties.DisplayMember = "cInvAddCode";

            系统服务.LookUp.Vendor2(lookUpEdit供应商);
        }

        private void btnEnsure_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.RowCount < 1)
                    return;

                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    if (dt.Rows[i]["iChk"] != "√")
                    {
                        dt.Rows.Remove(dt.Rows[i]);
                    }
                }
                红蓝标志 = radioGroup蓝红标识.EditValue.ToString().Trim();
                供应商 = lookUpEdit供应商.EditValue.ToString().Trim();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
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
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.IsRowSelected(i))
                {
                    if (gridView1.GetRowCellValue(i, gridCol选择) == "")
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
        private void buttonEdit供应商_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(23);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit供应商.EditValue = frm.sID;

                frm.Enabled = true;
            }
        }

        private void buttonEdit供应商_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit供应商.Text.Trim() != "")
                lookUpEdit供应商.EditValue = buttonEdit供应商.Text.Trim();
            else
                lookUpEdit供应商.EditValue = null;
        }

        private void buttonEdit供应商_Leave(object sender, EventArgs e)
        {
            if (buttonEdit供应商.Text.Trim() == "")
                return;
            if (lookUpEdit供应商.Text.Trim() == "")
            {
                buttonEdit供应商.Text = "";
                buttonEdit供应商.Focus();
            }
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
    }
}
