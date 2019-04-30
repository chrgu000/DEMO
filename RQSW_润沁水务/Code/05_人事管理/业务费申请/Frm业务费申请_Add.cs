using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 人事管理
{
    public partial class Frm业务费申请_Add : Form
    {
        protected 系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
        protected 系统服务.ClsGetSQL clsGetSQL = 系统服务.ClsGetSQL.Instance();
        public string iCode1;
        public string iCode2;
        public string dDate1;
        public string dDate2;
        public string SS1;
        public string SS2;
        public string SS3;

        public Frm业务费申请_Add(string siCode1, string siCode2, string sdDate1, string sdDate2, string sSS1, string sSS2, string sSS3)
        {
           
            InitializeComponent();
            iCode1 = siCode1;
            iCode2 = siCode2;
            dDate1 = sdDate1;
            dDate2 = sdDate2;
            SS1 = sSS1;
            SS2 = sSS2;
            SS3 = sSS3;
        }

        public Frm业务费申请_Add()
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

        private void Frm业务费申请_Add_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookUpEdit();
                lookUpEditiCode1.EditValue = iCode1;
                lookUpEditiCode2.EditValue = iCode2;
                dateEditdDate1.EditValue = dDate1;
                dateEditdDate2.EditValue = dDate2;
                lookUpEditSS1.EditValue = SS1;
                lookUpEditSS2.EditValue = SS2;
                lookUpEditSS3.EditValue = SS3;
                buttonEditSS1.EditValue = SS1;
                buttonEditSS2.EditValue = SS2;
                buttonEditSS3.EditValue = SS3;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败：" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void SetLookUpEdit()
        {
            系统服务.LookUp.OperationalCosts(lookUpEditiCode1);
            系统服务.LookUp.OperationalCosts(lookUpEditiCode2);
            系统服务.LookUp.Person(lookUpEditSS1);
            系统服务.LookUp.Department(lookUpEditSS2);
            系统服务.LookUp.Customer(lookUpEditSS3);
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

        private void btnEnsure_Click(object sender, EventArgs e)
        {
            if (lookUpEditiCode1.EditValue != null)
            {
                iCode1 = lookUpEditiCode1.EditValue.ToString().Trim();
            }
            if (lookUpEditiCode2.EditValue != null)
            {
                iCode2 = lookUpEditiCode2.EditValue.ToString().Trim();
            }
            if (dateEditdDate1.EditValue != null)
            {
                dDate1 = dateEditdDate1.EditValue.ToString().Trim();
            }
            if (dateEditdDate2.EditValue != null)
            {
                dDate2 = dateEditdDate2.EditValue.ToString().Trim();
            }
            if (lookUpEditSS1.EditValue != null)
            {
                SS1 = lookUpEditSS1.EditValue.ToString().Trim();
            }
            if (lookUpEditSS2.EditValue != null)
            {
                SS2 = lookUpEditSS2.EditValue.ToString().Trim();
            }
            if (lookUpEditSS3.EditValue != null)
            {
                SS3 = lookUpEditSS3.EditValue.ToString().Trim();
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            lookUpEditiCode1.EditValue = "";
            lookUpEditiCode2.EditValue = "";
            lookUpEditSS3.EditValue = ""; ;
            lookUpEditSS1.EditValue = "";
            lookUpEditSS2.EditValue = "";
            dateEditdDate1.EditValue = DBNull.Value;
            dateEditdDate2.EditValue = DBNull.Value;
            buttonEditSS1.EditValue = DBNull.Value;
            buttonEditSS2.EditValue = DBNull.Value;
            buttonEditSS3.EditValue = DBNull.Value;
        }

        private void buttonEditSS1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(2);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEditSS1.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEditSS2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(3);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEditSS2.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEditSS3_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(9);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEditSS3.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEditSS1_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEditSS1.Text.Trim() != "")
                lookUpEditSS1.EditValue = buttonEditSS1.Text.Trim();
            else
                lookUpEditSS1.EditValue = null;
        }

        private void buttonEditSS1_Leave(object sender, EventArgs e)
        {
            if (buttonEditSS1.Text.Trim() == "")
                return;
            if (lookUpEditSS1.Text.Trim() == "")
            {
                buttonEditSS1.Text = "";
                buttonEditSS1.Focus();
            }
        }

        private void buttonEditSS2_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEditSS2.Text.Trim() != "")
                lookUpEditSS2.EditValue = buttonEditSS2.Text.Trim();
            else
                lookUpEditSS2.EditValue = null;
        }

        private void buttonEditSS2_Leave(object sender, EventArgs e)
        {
            if (buttonEditSS2.Text.Trim() == "")
                return;
            if (lookUpEditSS2.Text.Trim() == "")
            {
                buttonEditSS2.Text = "";
                buttonEditSS2.Focus();
            }
        }

        private void buttonEditSS3_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEditSS3.Text.Trim() != "")
                lookUpEditSS3.EditValue = buttonEditSS3.Text.Trim();
            else
                lookUpEditSS3.EditValue = null;
        }

        private void buttonEditSS3_Leave(object sender, EventArgs e)
        {
            if (buttonEditSS3.Text.Trim() == "")
                return;
            if (lookUpEditSS3.Text.Trim() == "")
            {
                buttonEditSS3.Text = "";
                buttonEditSS3.Focus();
            }
        }


    }
}
