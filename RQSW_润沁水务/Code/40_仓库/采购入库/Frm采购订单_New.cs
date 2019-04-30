using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 仓库
{
    public partial class Frm采购订单_New : Form
    {
        string tablename = "PO_POMain";
        string tableid = "ID";
        string tablenames = "PO_PODetails";
        string tableids = "AutoID";

        protected 系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
        protected 系统服务.ClsGetSQL clsGetSQL = 系统服务.ClsGetSQL.Instance();
        public string 供应商;
        public string 红蓝标志;
        public DataTable dt;
        DataTable dthas;
        public Frm采购订单_New(DataTable sdthas)
        {
           
            InitializeComponent();
            dthas = sdthas;
        }

        public Frm采购订单_New()
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

        private void Frm采购订单_New_Load(object sender, EventArgs e)
        {
            try
            {
                radioGroup蓝红标识.EditValue = "1";
                if (供应商.Trim() != "")
                {
                    buttonEdit供应商.EditValue = 供应商;
                    buttonEdit供应商.Enabled = false;
                    radioGroup蓝红标识.EditValue = 红蓝标志;
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
            if (供应商.Trim() == "")
                return;

            string sSQL = "";
            if (radioGroup蓝红标识.EditValue.ToString().Trim() == "1")
            {
                sSQL = "select a.*,i.cInvName,i.cInvStd,'' as iChk, cClosesysPerson,cClosesysTime,b.AutoID,b.cInvCode, isnull(b.iQuantity,0)-isnull(f.iQuantity,0) as iQuantity, isnull(b.iNum,0)-isnull(f.iNum,0) as iNum, b.iNatTax, b.iTaxRate, b.iChangRate, b.iUnitPrice, isnull(b.iMoney,0)-isnull(f.iMoney,0) as iMoney, b.iNatUnitPrice, isnull(b.iNatMoney,0) - isnull(f.iNatMoney,0) as  iNatMoney " +
                        "from dbo." + tablename + " a left join " + tablenames + " b on a.ID=b.ID left join Inventory i on b.cInvCode=i.cInvCode left join (select POAutoID,sum(iQuantity) as iQuantity,sum(isnull(iNum,0)) as iNum ,sum(isnull(iNatMoney,0)) as iNatMoney ,sum(isnull(iMoney,0)) as iMoney from RdRecords group by POAutoID) f on b.AutoID=f.POAutoID  " +
                        "where isnull(b.iQuantity,0)-isnull(f.iQuantity,0) > 0 and a.dVerifysysPerson is not null and a.dClosesysPerson is null and b.cClosesysPerson is null and cVenCode='" + 供应商 + "' ";
            }
            if (radioGroup蓝红标识.EditValue.ToString().Trim() == "2")
            {
                sSQL = "select  a.*,i.cInvName,i.cInvStd,'' as iChk, cClosesysPerson,cClosesysTime,b.AutoID,b.cInvCode,-isnull(f.iQuantity,0) as iQuantity, -isnull(f.iNum,0) as iNum,-b.iNatTax, b.iTaxRate, b.iChangRate, b.iUnitPrice,-isnull(f.iMoney,0) as iMoney,b.iNatUnitPrice,- isnull(f.iNatMoney,0) as  iNatMoney " +
                       "from dbo." + tablename + " a left join " + tablenames + " b on a.ID=b.ID left join Inventory i on b.cInvCode=i.cInvCode left join (select POAutoID,sum(iQuantity) as iQuantity,sum(isnull(iNum,0)) as iNum ,sum(isnull(iNatMoney,0)) as iNatMoney ,sum(isnull(iMoney,0)) as iMoney from RdRecords group by POAutoID) f on b.AutoID=f.POAutoID  " +
                       "where isnull(f.iQuantity,0)>0 and a.dVerifysysPerson is not null and a.dClosesysPerson is null and b.cClosesysPerson is null and cVenCode='" + 供应商 + "' ";
 
            }
            if (lookUpEdit单据号1.EditValue!=null && lookUpEdit单据号1.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and a.cPOCode>='" + lookUpEdit单据号1.EditValue.ToString().Trim() + "'";
            }
            if (lookUpEdit单据号2.EditValue!=null && lookUpEdit单据号2.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and a.cPOCode<='" + lookUpEdit单据号2.EditValue.ToString().Trim() + "'";
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
            if (dthas.Rows.Count != 0)
            {
                string s = "";
                for (int i = 0; i < dthas.Rows.Count; i++)
                {
                    if (dthas.Rows[i].RowState == DataRowState.Deleted)
                        continue;

                    if (dthas.Rows[i]["POAutoID"].ToString() != "")
                    {
                        if (s != "")
                        {
                            s = s + ",";
                        }
                        s = s + dthas.Rows[i]["POAutoID"].ToString();
                    }
                }
                if (s.Trim() != "")
                {
                    sSQL = sSQL + " and b.AutoID not in (" + s + ")";
                }
            }
            
            sSQL = sSQL + " order by  a." + tableid;
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
            系统服务.LookUp.PO_POMain(lookUpEdit单据号1);
            系统服务.LookUp.PO_POMain(lookUpEdit单据号2);

            系统服务.LookUp.Inventory(lookUpEdit物料编码1);
            系统服务.LookUp.Inventory(lookUpEdit物料编码2);

            系统服务.LookUp.Vendor(lookUpEdit供应商);
            系统服务.LookUp.Inventory3(ItemLookUpEdit物料代码);
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
                if (lookUpEdit供应商.Text.Trim() == "")
                {
                    throw new Exception("请选择供应商");
                }
                else
                {
                    供应商 = lookUpEdit供应商.EditValue.ToString().Trim();

                    GetGrid();
                }
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

        private void buttonEdit供应商_EditValueChanged(object sender, EventArgs e)
        { 
            if (buttonEdit供应商.Text.Trim() != "")
                lookUpEdit供应商.EditValue = buttonEdit供应商.Text.Trim();
            else
                lookUpEdit供应商.EditValue = null;
        }

        private void buttonEdit供应商_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(10);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit供应商.EditValue = frm.sID;
                frm.Enabled = true;
            }
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
    }
}
