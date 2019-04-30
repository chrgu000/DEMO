using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 人事管理
{
    public partial class Frm销售订单_New : Form
    {
        string tablename = "SO_SOMain";
        string tableid = "cSoCode";
        string tablenames = "SO_SOMainCommissiion";
        string tableids = "CID";

        protected 系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
        protected 系统服务.ClsGetSQL clsGetSQL = 系统服务.ClsGetSQL.Instance();
        public string 客户;
        public string 业务员;
        public string 部门;
        public DataTable dt;
        DataTable dthas;
        public string 销售订单号;
        public Frm销售订单_New(string s客户, DataTable sdthas, string s销售订单号)
        {
            InitializeComponent();
            客户 = s客户;
            buttonEdit客户.EditValue = 客户;
            销售订单号 = s销售订单号;
            dthas = sdthas;
        }

        public Frm销售订单_New()
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

        private void Frm销售订单_New_Load(object sender, EventArgs e)
        {
            try
            {
                if (客户.Trim() != "")
                {
                    buttonEdit客户.EditValue = 客户;
                    buttonEdit客户.Enabled = false;
                }
                else
                {
                    buttonEdit客户.Enabled = true;
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
            if (客户.Trim() == "")
                return;
            string sSQL = @"select '' as iChk,a.cSOCode,a.dDate,a.cPersonCode,a.cDepCode,a.cCusCode,a.cSTCode,
            b.*,isnull(b.DD1,0)*isnull(b.DD2,0)-isnull(b.DD1,0)*isnull(r.iQuantity,0)-isnull(f.usedMoney,0) as usedMoney,isnull(b.DD2,0)-isnull(f.DD2,0)+isnull(r.iQuantity,0) as usedQty 
            from SO_SOMain a left join SO_SOMainCommissiion b on a.ID=b.ID  left join SO_SODetails c on a.ID=c.ID
            left join (select CID,sum(isnull(DD1*DD2,0)) as usedMoney,sum(isnull(DD2,0)) as DD2 from Commissions group by CID) f on b.CID=f.CID 
left join (select SoAutoID,sum(isnull(iQuantity,0)) as iQuantity,sum(isnull(iNum,0)) as iNum ,sum(isnull(iNatMoney,0)) as iNatMoney ,sum(isnull(iMoney,0)) as iMoney  from SO_SOReturns group by SoAutoID) r on c.AutoID=r.SoAutoID  

            where isnull(b.DD1,0)*isnull(b.DD2,0)-isnull(b.DD1,0)*isnull(r.iQuantity,0)-isnull(f.usedMoney,0)>0 and a.dVerifysysPerson is not null and a.dClosesysPerson is null  and cCusCode='" + 客户 + "'";
           
            if (lookUpEdit单据号1.EditValue!=null && lookUpEdit单据号1.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and a.cSoCode>='" + lookUpEdit单据号1.EditValue.ToString().Trim() + "'";
            }
            if (lookUpEdit单据号2.EditValue!=null && lookUpEdit单据号2.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and a.cSOCode<='" + lookUpEdit单据号2.EditValue.ToString().Trim() + "'";
            }
            if (dateEdit单据日期1.EditValue!=null && dateEdit单据日期1.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and dDate>='" + dateEdit单据日期1.EditValue.ToString().Trim() + "'";
            }
            if (dateEdit单据日期2.EditValue!=null && dateEdit单据日期2.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and dDate<='" + dateEdit单据日期2.EditValue.ToString().Trim() + "'";
            }

            if (dthas.Rows.Count != 0)
            {
                string s = "";
                for (int i = 0; i < dthas.Rows.Count; i++)
                {
                    if (dthas.Rows[i]["CID"].ToString() != "")
                    {
                        if (s != "")
                        {
                            s = s + ",";
                        }
                        s = s + dthas.Rows[i]["CID"].ToString();
                    }
                }
                if (s.Trim() != "")
                {
                    sSQL = sSQL + " and b.CID not in (" + s + ")";
                }
            }
            if (销售订单号 != "")
            {
                sSQL = sSQL + " and a.cSoCode='" + 销售订单号 + "'";
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
            DataTable dt = 系统服务.LookUp.SO_SOMain();
            lookUpEdit单据号1.Properties.DataSource = dt;
            lookUpEdit单据号2.Properties.DataSource = dt;
            系统服务.LookUp.Customer(lookUpEdit客户);
        }

        private void btnEnsure_Click(object sender, EventArgs e)
        {
            string bCode = "";
            bool b = true;
            for (int i = dt.Rows.Count-1; i >=0; i--)
            {
                if (dt.Rows[i]["iChk"].ToString() == "√")
                {
                    if (bCode == "")
                    {
                        bCode = dt.Rows[i]["cSOCode"].ToString();
                    }
                    else
                    {
                        if (bCode != dt.Rows[i]["cSOCode"].ToString())
                        {
                            b = false;
                        }
                    }
                    
                }
                if (dt.Rows[i]["iChk"].ToString() != "√")
                {
                    dt.Rows.Remove(dt.Rows[i]);
                }
                
            }
            销售订单号 = dt.Rows[0]["cSOCode"].ToString();
            业务员 = dt.Rows[0]["cPersonCode"].ToString();
            部门 = dt.Rows[0]["cDepCode"].ToString();
            客户 = lookUpEdit客户.EditValue.ToString().Trim();
            if (b == true)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageBox.Show("一张单据只能选择一张销售订单");
            }
        }

        private void button查询_Click(object sender, EventArgs e)
        {
            try
            {
                if (lookUpEdit客户.Text.Trim() == "")
                {
                    throw new Exception("请选择客户");
                }
                else
                {
                    客户 = lookUpEdit客户.EditValue.ToString().Trim();
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

        private void buttonEdit客户_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(9);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit客户.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit客户_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit客户.Text.Trim() != "")
                lookUpEdit客户.EditValue = buttonEdit客户.Text.Trim();
            else
                lookUpEdit客户.EditValue = null;
        }

        private void buttonEdit客户_Leave(object sender, EventArgs e)
        {
            if (buttonEdit客户.Text.Trim() == "")
                return;
            if (lookUpEdit客户.Text.Trim() == "")
            {
                buttonEdit客户.Text = "";
                buttonEdit客户.Focus();
            }
        }




    }
}
