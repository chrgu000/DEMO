using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 报表
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
        public string 制单人1;
        public string 制单人2;
        public string 审核人1;
        public string 审核人2;
        public string 审核日期1;
        public string 审核日期2;

        public Frm业务费申请_Add(string siCode1, string siCode2, string sdDate1, string sdDate2, string sSS1, string sSS2, string sSS3,
            string s制单人1, string s制单人2, string s审核人1, string s审核人2, string s审核日期1, string s审核日期2)
        {
           
            InitializeComponent();
            iCode1 = siCode1;
            iCode2 = siCode2;
            dDate1 = sdDate1;
            dDate2 = sdDate2;
            SS1 = sSS1;
            SS2 = sSS2;
            SS3 = sSS3;
            制单人1 = s制单人1;
            制单人2 = s制单人2;
            审核人1 = s审核人1;
            审核人2 = s审核人2;
            审核日期1 = s审核日期1;
            审核日期2 = s审核日期2;
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
                buttonEdit审核人1.EditValue = 审核人1;
                buttonEdit审核人2.EditValue = 审核人2;
                dateEdit审核日期1.EditValue = 审核日期1;
                dateEdit审核日期2.EditValue = 审核日期2;
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
            系统服务.LookUp._UserInfo(lookUpEdit制单人1);
            系统服务.LookUp._UserInfo(lookUpEdit制单人2);
            系统服务.LookUp._UserInfo(lookUpEdit审核人1);
            系统服务.LookUp._UserInfo(lookUpEdit审核人2);
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
            if (lookUpEdit制单人1.EditValue != null)
            {
                制单人1 = lookUpEdit制单人1.EditValue.ToString().Trim();
            }
            if (lookUpEdit制单人2.EditValue != null)
            {
                制单人2 = lookUpEdit制单人2.EditValue.ToString().Trim();
            }
            if (lookUpEdit审核人1.EditValue != null)
            {
                审核人1 = lookUpEdit审核人1.EditValue.ToString().Trim();
            }
            if (lookUpEdit审核人2.EditValue != null)
            {
                审核人2 = lookUpEdit审核人2.EditValue.ToString().Trim();
            }
            if (dateEdit审核日期1.EditValue != null)
            {
                审核日期1 = dateEdit审核日期1.EditValue.ToString().Trim();
            }
            if (dateEdit审核日期2.EditValue != null)
            {
                审核日期2 = dateEdit审核日期2.EditValue.ToString().Trim();
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
            buttonEdit制单人1.EditValue = "";
            buttonEdit制单人2.EditValue = "";
            buttonEdit审核人1.EditValue = "";
            buttonEdit审核人2.EditValue = "";
            dateEdit审核日期1.EditValue = DBNull.Value;
            dateEdit审核日期2.EditValue = DBNull.Value;
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
