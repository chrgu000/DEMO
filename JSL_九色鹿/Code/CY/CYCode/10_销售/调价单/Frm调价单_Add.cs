using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 销售
{
    public partial class Frm调价单_Add : Form
    {
        protected 系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
        protected 系统服务.ClsGetSQL clsGetSQL = 系统服务.ClsGetSQL.Instance();

        public string iCode1 = "";
        public string iCode2 = "";
        public string dDate1 = "";
        public string dDate2 = "";
        public string dCreatesysTime1 = "";
        public string dCreatesysTime2 = "";
        public string dCreatesysPerson1 = "";
        public string dCreatesysPerson2 = "";
        public string dVerifysysTime1 = "";
        public string dVerifysysTime2 = "";
        public string dVerifysysPerson1 = "";
        public string dVerifysysPerson2 = "";
        public string S1_1 = "";
        public string S1_2 = "";


        public Frm调价单_Add(string siCode1, string siCode2, string sdDate1, string sdDate2, string sdCreatesysTime1, string sdCreatesysTime2, string sdCreatesysPerson1, string sdCreatesysPerson2, string sdVerifysysTime1, string sdVerifysysTime2, string sdVerifysysPerson1, string sdVerifysysPerson2, 
            string sS1_1, string sS1_2)
        {
           
            InitializeComponent();
            iCode1 = siCode1;
            iCode2 = siCode2;
            dDate1 = sdDate1;
            dDate2 = sdDate2;
            dCreatesysTime1 = sdCreatesysTime1;
            dCreatesysTime2 = sdCreatesysTime2;
            dCreatesysPerson1 = sdCreatesysPerson1;
            dCreatesysPerson2 = sdCreatesysPerson2;
            dVerifysysTime1 = sdVerifysysPerson1;
            dVerifysysTime2 = sdVerifysysPerson2;
            dVerifysysPerson1 = sdVerifysysPerson1;
            dVerifysysPerson2 = sdVerifysysPerson2;
            S1_1 = sS1_1;
            S1_2 = sS1_2;
        }

        public Frm调价单_Add()
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

        private void Frm调价单_Add_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookUpEdit();
                lookUpEdit单据号1.EditValue = iCode1;
                lookUpEdit单据号2.EditValue = iCode2;
                dateEdit单据日期1.EditValue = dDate1;
                dateEdit单据日期2.EditValue = dDate2;
                dateEdit制单日期1.EditValue = dCreatesysTime1;
                dateEdit制单日期2.EditValue = dCreatesysTime2;
                buttonEdit制单人1.EditValue = dCreatesysPerson1;
                buttonEdit制单人2.EditValue = dCreatesysPerson2;
                dateEdit审核日期1.EditValue = dVerifysysTime1;
                dateEdit审核日期2.EditValue = dVerifysysTime2;
                buttonEdit审核人1.EditValue = dVerifysysPerson1;
                buttonEdit审核人2.EditValue = dVerifysysPerson2;
                buttonEdit物料1.EditValue = S1_1;
                buttonEdit物料2.EditValue = S1_2;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败：" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void SetLookUpEdit()
        {
            系统服务.LookUp.PriceAdjust_Main(lookUpEdit单据号1);
            系统服务.LookUp.PriceAdjust_Main(lookUpEdit单据号2);
            系统服务.LookUp._UserInfo(lookUpEdit审核人1);
            系统服务.LookUp._UserInfo(lookUpEdit审核人2);
            系统服务.LookUp._UserInfo(lookUpEdit制单人1);
            系统服务.LookUp._UserInfo(lookUpEdit制单人2);
            系统服务.LookUp.Inventory(lookUpEdit物料1);
            系统服务.LookUp.Inventory(lookUpEdit物料2);
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

        private void btnEnsure_Click(object sender, EventArgs e)
        {
            if (lookUpEdit单据号1.EditValue != null)
            {
                iCode1 = lookUpEdit单据号1.EditValue.ToString().Trim();
            }
            if (lookUpEdit单据号2.EditValue != null)
            {
                iCode2 = lookUpEdit单据号2.EditValue.ToString().Trim();
            }
            if (dateEdit单据日期1.EditValue != null)
            {
                dDate1 = dateEdit单据日期1.EditValue.ToString().Trim();
            }
            if (dateEdit单据日期2.EditValue != null)
            {
                dDate2 = dateEdit单据日期2.EditValue.ToString().Trim();
            }
            if (dateEdit制单日期1.EditValue != null)
            {
                dCreatesysTime1 = dateEdit制单日期1.EditValue.ToString().Trim();
            }
            if (dateEdit制单日期2.EditValue != null)
            {
                dCreatesysTime2 = dateEdit制单日期2.EditValue.ToString().Trim();
            }
            if (dateEdit审核日期1.EditValue != null)
            {
                dVerifysysTime1 = dateEdit审核日期1.EditValue.ToString().Trim();
            }
            if (dateEdit审核日期2.EditValue != null)
            {
                dVerifysysTime2 = dateEdit审核日期2.EditValue.ToString().Trim();
            }
            if (buttonEdit制单人1.EditValue != null)
            {
                dCreatesysPerson1 = buttonEdit制单人1.EditValue.ToString().Trim();
            }
            if (buttonEdit制单人2.EditValue != null)
            {
                dCreatesysPerson2 = buttonEdit制单人2.EditValue.ToString().Trim();
            }
            if (buttonEdit审核人1.EditValue != null)
            {
                dVerifysysPerson1 = buttonEdit审核人1.EditValue.ToString().Trim();
            }
            if (buttonEdit审核人2.EditValue != null)
            {
                dVerifysysPerson2 = buttonEdit审核人2.EditValue.ToString().Trim();
            }
            if (buttonEdit物料1.EditValue != null)
            {
                S1_1 = buttonEdit物料1.EditValue.ToString().Trim();
            }
            if (buttonEdit物料2.EditValue != null)
            {
                S1_2 = buttonEdit物料2.EditValue.ToString().Trim();
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            dateEdit单据日期1.EditValue = "";
            dateEdit单据日期2.EditValue = "";
            dateEdit制单日期1.EditValue = "";
            dateEdit制单日期2.EditValue = "";
            dateEdit审核日期1.EditValue = "";
            dateEdit审核日期2.EditValue = "";

            buttonEdit制单人1.EditValue = "";
            buttonEdit制单人2.EditValue = "";
            buttonEdit审核人1.EditValue = "";
            buttonEdit审核人2.EditValue = "";
            buttonEdit物料1.EditValue = "";
            buttonEdit物料2.EditValue = "";

            lookUpEdit单据号1.EditValue = "";
            lookUpEdit单据号2.EditValue = "";
            lookUpEdit审核人1.EditValue = "";
            lookUpEdit审核人2.EditValue = "";
            lookUpEdit物料1.EditValue = "";
            lookUpEdit物料2.EditValue = "";
            lookUpEdit制单人1.EditValue = "";
            lookUpEdit制单人2.EditValue = "";
        }

        private void buttonEdit制单人1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(12);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit制单人1.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit制单人2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(12);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit制单人2.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit审核人1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(12);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit审核人1.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit审核人2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(12);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit审核人2.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit物料1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(1);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit物料1.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit物料2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(1);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit物料2.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit物料1_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit物料1.Text.Trim() != "")
                lookUpEdit物料1.EditValue = buttonEdit物料1.Text.Trim();
            else
                lookUpEdit物料1.EditValue = null;
        }

        private void buttonEdit物料1_Leave(object sender, EventArgs e)
        {
            if (buttonEdit物料1.Text.Trim() == "")
                return;
            if (lookUpEdit物料1.Text.Trim() == "")
            {
                buttonEdit物料1.Text = "";
                buttonEdit物料1.Focus();
            }
        }

        private void buttonEdit物料2_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit物料2.Text.Trim() != "")
                lookUpEdit物料2.EditValue = buttonEdit物料2.Text.Trim();
            else
                lookUpEdit物料2.EditValue = null;
        }

        private void buttonEdit物料2_Leave(object sender, EventArgs e)
        {
            if (buttonEdit物料2.Text.Trim() == "")
                return;
            if (lookUpEdit物料2.Text.Trim() == "")
            {
                buttonEdit物料2.Text = "";
                buttonEdit物料2.Focus();
            }
        }

        private void buttonEdit制单人1_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit制单人1.Text.Trim() != "")
                lookUpEdit制单人1.EditValue = buttonEdit制单人1.Text.Trim();
            else
                lookUpEdit制单人1.EditValue = null;
        }

        private void buttonEdit制单人1_Leave(object sender, EventArgs e)
        {
            if (buttonEdit制单人1.Text.Trim() == "")
                return;
            if (lookUpEdit制单人1.Text.Trim() == "")
            {
                buttonEdit制单人1.Text = "";
                buttonEdit制单人1.Focus();
            }
        }

        private void buttonEdit制单人2_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit制单人2.Text.Trim() != "")
                lookUpEdit制单人2.EditValue = buttonEdit制单人2.Text.Trim();
            else
                lookUpEdit制单人2.EditValue = null;
        }

        private void buttonEdit制单人2_Leave(object sender, EventArgs e)
        {
            if (buttonEdit制单人2.Text.Trim() == "")
                return;
            if (lookUpEdit制单人2.Text.Trim() == "")
            {
                buttonEdit制单人2.Text = "";
                buttonEdit制单人2.Focus();
            }
        }

        private void buttonEdit审核人1_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit审核人1.Text.Trim() != "")
                lookUpEdit审核人1.EditValue = buttonEdit审核人1.Text.Trim();
            else
                lookUpEdit审核人1.EditValue = null;
        }

        private void buttonEdit审核人1_Leave(object sender, EventArgs e)
        {
            if (buttonEdit审核人1.Text.Trim() == "")
                return;
            if (lookUpEdit审核人1.Text.Trim() == "")
            {
                buttonEdit审核人1.Text = "";
                buttonEdit审核人1.Focus();
            }
        }

        private void buttonEdit审核人2_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit审核人2.Text.Trim() != "")
                lookUpEdit审核人2.EditValue = buttonEdit审核人2.Text.Trim();
            else
                lookUpEdit审核人2.EditValue = null;
        }

        private void buttonEdit审核人2_Leave(object sender, EventArgs e)
        {
            if (buttonEdit审核人2.Text.Trim() == "")
                return;
            if (lookUpEdit审核人2.Text.Trim() == "")
            {
                buttonEdit审核人2.Text = "";
                buttonEdit审核人2.Focus();
            }
        }


    }
}
