using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 生产
{
    public partial class Frm物料清单_Add : Form
    {
        protected 系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
        protected 系统服务.ClsGetSQL clsGetSQL = 系统服务.ClsGetSQL.Instance();

        public string 制单日期1 = "";
        public string 制单日期2 = "";
        public string 审核日期1 = "";
        public string 审核日期2 = "";
        public string 制单人1 = "";
        public string 制单人2 = "";
        public string 审核人1 = "";
        public string 审核人2 = "";
        public string 物料1 = "";
        public string 物料2 = "";


        public Frm物料清单_Add(string s制单日期1, string s制单日期2, string s审核日期1, string s审核日期2, string s制单人1, string s制单人2, string s审核人1, string s审核人2, string s物料1, string s物料2)
        {
           
            InitializeComponent();
            制单日期1 = s制单日期1;
            制单日期2 = s制单日期2;
            审核日期1 = s审核日期1;
            审核日期2 = s审核日期2;
            制单人1 = s制单人1;
            制单人2 = s制单人2;
            审核人1 = s审核人1;
            审核人2 = s审核人2;
            物料1 = s物料1;
            物料2 = s物料2;
        }

        public Frm物料清单_Add()
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

        private void Frm物料清单_Add_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookUpEdit();
                dateEdit制单日期1.EditValue = 制单日期1;
                dateEdit制单日期2.EditValue = 制单日期2;
                dateEdit审核日期1.EditValue = 审核日期1;
                dateEdit审核日期2.EditValue = 审核日期2;
                buttonEdit制单人1.EditValue = 制单人1;
                buttonEdit制单人2.EditValue = 制单人2;
                buttonEdit审核人1.EditValue = 审核人1;
                buttonEdit审核人2.EditValue = 审核人2;
                buttonEdit物料1.EditValue = 物料1;
                buttonEdit物料2.EditValue = 物料2;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败：" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        
        private void SetLookUpEdit()
        {
            系统服务.LookUp._UserInfo(lookUpEdit审核人1);
            系统服务.LookUp._UserInfo(lookUpEdit审核人2);
            系统服务.LookUp.Inventory(lookUpEdit物料1);
            系统服务.LookUp.Inventory(lookUpEdit物料2);
            系统服务.LookUp._UserInfo(lookUpEdit制单人1);
            系统服务.LookUp._UserInfo(lookUpEdit制单人2);
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
            if (dateEdit制单日期1.EditValue != null)
            {
                制单日期1 = dateEdit制单日期1.EditValue.ToString().Trim();
            }
            if (dateEdit制单日期2.EditValue != null)
            {
                制单日期2 = dateEdit制单日期2.EditValue.ToString().Trim();
            }
            if (dateEdit审核日期1.EditValue != null)
            {
                审核日期1 = dateEdit审核日期1.EditValue.ToString().Trim();
            }
            if (dateEdit审核日期2.EditValue != null)
            {
                审核日期2 = dateEdit审核日期2.EditValue.ToString().Trim();
            }
            if (buttonEdit制单人1.EditValue != null)
            {
                制单人1 = buttonEdit制单人1.EditValue.ToString().Trim();
            }
            if (buttonEdit制单人2.EditValue != null)
            {
                制单人2 = buttonEdit制单人2.EditValue.ToString().Trim();
            }
            if (buttonEdit审核人1.EditValue != null)
            {
                审核人1 = buttonEdit审核人1.EditValue.ToString().Trim();
            }
            if (buttonEdit审核人2.EditValue != null)
            {
                审核人2 = buttonEdit审核人2.EditValue.ToString().Trim();
            }
            if (buttonEdit物料1.EditValue != null)
            {
                物料1 = buttonEdit物料1.EditValue.ToString().Trim();
            }
            if (buttonEdit物料2.EditValue != null)
            {
                物料2 = buttonEdit物料2.EditValue.ToString().Trim();
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
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
