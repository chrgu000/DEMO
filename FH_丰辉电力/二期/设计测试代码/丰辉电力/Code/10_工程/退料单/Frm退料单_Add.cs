using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 工程
{
    public partial class Frm退料单_Add : Form
    {
        protected 系统服务.LookUp lookUp = new 系统服务.LookUp();
        public string iCode1 = "";
        public string iCode2 = "";
        public string dDate1 = "";
        public string dDate2 = "";
        public string cInvCode1 = "";
        public string cInvCode2 = "";


        public Frm退料单_Add(string siCode1, string siCode2, string sdDate1, string sdDate2,string scInvCode1, string scInvCode2)
        {
           
            InitializeComponent();
            iCode1 = siCode1;
            iCode2 = siCode2;
            dDate1 = sdDate1;
            dDate2 = sdDate2;
            cInvCode1 = scInvCode1;
            cInvCode2 = scInvCode2;
        }

        public Frm退料单_Add()
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

        private void Frm退料单_Add_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookUpEdit();
                lookUpEdit单据号1.EditValue = iCode1;
                lookUpEdit单据号2.EditValue = iCode2;
                dateEdit单据日期1.EditValue = dDate1;
                dateEdit单据日期2.EditValue = dDate2;
                buttonEdit物料1.EditValue = cInvCode1;
                buttonEdit物料2.EditValue = cInvCode2;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败：" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void SetLookUpEdit()
        {
            lookUp.RdRecord(lookUpEdit单据号1);
            lookUp.RdRecord(lookUpEdit单据号2);
            lookUp.Inventory(lookUpEdit物料1);
            lookUp.Inventory(lookUpEdit物料2);
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
            try
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
                if (buttonEdit物料1.EditValue != null)
                {
                    cInvCode1 = buttonEdit物料1.EditValue.ToString().Trim();
                }
                if (buttonEdit物料2.EditValue != null)
                {
                    cInvCode2 = buttonEdit物料2.EditValue.ToString().Trim();
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            try
            {
                lookUpEdit单据号1.EditValue = "";
                lookUpEdit单据号2.EditValue = "";
                dateEdit单据日期1.EditValue = "";
                dateEdit单据日期2.EditValue = "";
                buttonEdit物料1.EditValue = "";
                buttonEdit物料2.EditValue = "";
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit物料1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                系统服务.Frm参照 frm = new 系统服务.Frm参照(1);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    buttonEdit物料1.EditValue = frm.sID;
                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit物料2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                系统服务.Frm参照 frm = new 系统服务.Frm参照(1);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    buttonEdit物料2.EditValue = frm.sID;
                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit物料1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit物料1.Text.Trim() != "")
                    lookUpEdit物料1.EditValue = buttonEdit物料1.Text.Trim();
                else
                    lookUpEdit物料1.EditValue = null;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit物料1_Leave(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit物料1.Text.Trim() == "")
                    return;
                if (lookUpEdit物料1.Text.Trim() == "")
                {
                    buttonEdit物料1.Text = "";
                    buttonEdit物料1.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit物料2_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit物料2.Text.Trim() != "")
                    lookUpEdit物料2.EditValue = buttonEdit物料2.Text.Trim();
                else
                    lookUpEdit物料2.EditValue = null;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit物料2_Leave(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit物料2.Text.Trim() == "")
                    return;
                if (lookUpEdit物料2.Text.Trim() == "")
                {
                    buttonEdit物料2.Text = "";
                    buttonEdit物料2.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
