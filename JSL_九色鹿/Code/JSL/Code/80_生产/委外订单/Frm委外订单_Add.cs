using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 生产
{
    public partial class Frm委外订单_Add : Form
    {
        protected 系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
        protected 系统服务.ClsGetSQL clsGetSQL = 系统服务.ClsGetSQL.Instance();
        public string 单据号1 = "";
        public string 单据号2 = "";
        public string 单据日期1 = "";
        public string 单据日期2 = "";
        public string 制单日期1 = "";
        public string 制单日期2 = "";
        public string 业务员 = "";
        public string 部门 = "";
        public string 客户1 = "";
        public string 客户2 = "";
        public string 审核日期1 = "";
        public string 审核日期2 = "";
        public string 制单人1 = "";
        public string 制单人2 = "";
        public string 审核人1 = "";
        public string 审核人2 = "";
        public string 物料1 = "";
        public string 物料2 = "";
        public string ECode = "";


        public Frm委外订单_Add(string s单据号1, string s单据号2, string s单据日期1, string s单据日期2, string s制单日期1, string s制单日期2, string s业务员,
            string s部门, string s客户1, string s客户2, string s审核日期1, string s审核日期2, string s制单人1, string s制单人2, string s审核人1, string s审核人2, string s物料1, string s物料2,string sEcode)
        {
           
            InitializeComponent();
            单据号1 = s单据号1;
            单据号2 = s单据号2;
            单据日期1 = s单据日期1;
            单据日期2 = s单据日期2;
            制单日期1 = s制单日期1;
            制单日期2 = s制单日期2;
            业务员 = s业务员;
            部门 = s部门;
            客户1 = s客户1;
            客户2 = s客户2;
            审核日期1 = s审核日期1;
            审核日期2 = s审核日期2;
            制单人1 = s制单人1;
            制单人2 = s制单人2;
            审核人1 = s审核人1;
            审核人2 = s审核人2;
            物料1 = s物料1;
            物料2 = s物料2;
            ECode = sEcode;
        }

        public Frm委外订单_Add()
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

        private void Frm委外订单_Add_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookUpEdit();
                lookUpEdit单据号1.EditValue = 单据号1;
                lookUpEdit单据号2.EditValue = 单据号2;
                dateEdit单据日期1.EditValue = 单据日期1;
                dateEdit单据日期2.EditValue = 单据日期2;
                dateEdit制单日期1.EditValue = 制单日期1;
                dateEdit制单日期2.EditValue = 制单日期2;
                buttonEdit业务员.EditValue = 业务员;
                buttonEdit部门.EditValue = 部门;
                buttonEdit客户1.EditValue = 客户1;
                buttonEdit客户2.EditValue = 客户2;
                dateEdit审核日期1.EditValue = 审核日期1;
                dateEdit审核日期2.EditValue = 审核日期2;
                buttonEdit制单人1.EditValue = 制单人1;
                buttonEdit制单人2.EditValue = 制单人2;
                buttonEdit审核人1.EditValue = 审核人1;
                buttonEdit审核人2.EditValue = 审核人2;
                buttonEdit物料1.EditValue = 物料1;
                buttonEdit物料2.EditValue = 物料2;
                textEdit8位数编码.EditValue = ECode;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败：" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        //public void Get(string 单据号1, string 单据号2, string 单据日期1, string 单据日期2,string 制单日期1,string 制单日期2,string 业务员,
        //    string 部门, string 客户1, string 客户2, string 审核日期1, string 审核日期2, string 制单人1, string 制单人2, string 审核人1, string 审核人2, string 物料1, string 物料2)
        //{
        //    lookUpEdit单据号1.EditValue = 单据号1;
        //    lookUpEdit单据号2.EditValue = 单据号2;
        //    if (单据日期1 != null && 单据日期1 != "")
        //    {
        //        单据日期1 = DateTime.Parse(单据日期1).ToString("yyyy-MM-dd");
        //        dateEdit单据日期1.EditValue = 单据日期1;
        //    }
        //    if (单据日期2 != null && 单据日期2 != "")
        //    {
        //        单据日期2 = DateTime.Parse(单据日期2).ToString("yyyy-MM-dd");
        //        dateEdit单据日期2.EditValue = 单据日期2;
        //    }
        //    if (制单日期1 != null && 制单日期1 != "")
        //    {
        //        制单日期1 = DateTime.Parse(制单日期1).ToString("yyyy-MM-dd");
        //        dateEdit制单日期1.EditValue = 制单日期1;
        //    }
        //    if (制单日期2 != null && 制单日期2 != "")
        //    {
        //        制单日期2 = DateTime.Parse(制单日期2).ToString("yyyy-MM-dd");
        //        dateEdit制单日期2.EditValue = 制单日期2;
        //    }
        //    buttonEdit业务员.EditValue = 业务员;
        //    buttonEdit部门.EditValue = 部门;
        //    buttonEdit客户1.EditValue = 客户1;
        //    buttonEdit客户2.EditValue = 客户2;
        //    if (审核日期1 != null && 审核日期1 != "")
        //    {
        //        审核日期1 = DateTime.Parse(审核日期1).ToString("yyyy-MM-dd");
        //        dateEdit审核日期1.EditValue = 审核日期1;
        //    }
        //    if (审核日期2 != null && 审核日期2 != "")
        //    {
        //        审核日期2 = DateTime.Parse(审核日期2).ToString("yyyy-MM-dd");
        //        dateEdit审核日期2.EditValue = 审核日期2;
        //    }
        //    buttonEdit制单人1.EditValue = 制单人1;
        //    buttonEdit制单人2.EditValue = 制单人2;
        //    buttonEdit审核人1.EditValue = 审核人1;
        //    buttonEdit审核人2.EditValue = 审核人2;
        //    buttonEdit物料1.EditValue = 物料1;
        //    buttonEdit物料2.EditValue = 物料2;
        //}

        private void SetLookUpEdit()
        {
            系统服务.LookUp.MO_MOMain(lookUpEdit单据号1);
            系统服务.LookUp.MO_MOMain(lookUpEdit单据号2);
            系统服务.LookUp.Department(lookUpEdit部门);
            系统服务.LookUp.Customer(lookUpEdit客户1);
            系统服务.LookUp.Customer(lookUpEdit客户2);
            系统服务.LookUp._UserInfo(lookUpEdit审核人1);
            系统服务.LookUp._UserInfo(lookUpEdit审核人2);
            系统服务.LookUp.Inventory(lookUpEdit物料1);
            系统服务.LookUp.Inventory(lookUpEdit物料2);
            系统服务.LookUp.Person(lookUpEdit业务员);
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
            if (lookUpEdit单据号1.EditValue != null)
            {
                单据号1 = lookUpEdit单据号1.EditValue.ToString().Trim();
            }
            if (lookUpEdit单据号2.EditValue != null)
            {
                单据号2 = lookUpEdit单据号2.EditValue.ToString().Trim();
            }
            if (dateEdit单据日期1.EditValue != null)
            {
                单据日期1 = dateEdit单据日期1.EditValue.ToString().Trim();
            }
            if (dateEdit单据日期2.EditValue != null)
            {
                单据日期2 = dateEdit单据日期2.EditValue.ToString().Trim();
            }
            if (dateEdit制单日期1.EditValue != null)
            {
                制单日期1 = dateEdit制单日期1.EditValue.ToString().Trim();
            }
            if (dateEdit制单日期2.EditValue != null)
            {
                制单日期2 = dateEdit制单日期2.EditValue.ToString().Trim();
            }
            if (buttonEdit业务员.EditValue != null)
            {
                业务员 = buttonEdit业务员.EditValue.ToString().Trim();
            }
            if (buttonEdit部门.EditValue != null)
            {
                部门 = buttonEdit部门.EditValue.ToString().Trim();
            }
            if (buttonEdit客户1.EditValue != null)
            {
                客户1 = buttonEdit客户1.EditValue.ToString().Trim();
            }
            if (buttonEdit客户2.EditValue != null)
            {
                客户2 = buttonEdit客户2.EditValue.ToString().Trim();
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
            if (textEdit8位数编码.EditValue != null)
            {
                ECode = textEdit8位数编码.EditValue.ToString().Trim();
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            lookUpEdit单据号1.EditValue = "";
            lookUpEdit单据号2.EditValue = "";
            dateEdit单据日期1.EditValue = "";
            dateEdit单据日期2.EditValue = "";
            dateEdit制单日期1.EditValue = "";
            dateEdit制单日期2.EditValue = "";
            buttonEdit业务员.EditValue = "";
            buttonEdit部门.EditValue = "";
            buttonEdit客户1.EditValue = "";
            buttonEdit客户2.EditValue = "";
            dateEdit审核日期1.EditValue = "";
            dateEdit审核日期2.EditValue = "";
            buttonEdit制单人1.EditValue = "";
            buttonEdit制单人2.EditValue = "";
            buttonEdit审核人1.EditValue = "";
            buttonEdit审核人2.EditValue = "";
            buttonEdit物料1.EditValue = "";
            buttonEdit物料2.EditValue = "";
            lookUpEdit部门.EditValue = "";
            lookUpEdit客户1.EditValue = "";
            lookUpEdit客户2.EditValue = "";
            lookUpEdit审核人1.EditValue = "";
            lookUpEdit审核人2.EditValue = "";
            lookUpEdit物料1.EditValue = "";
            lookUpEdit物料2.EditValue = "";
            lookUpEdit业务员.EditValue = "";
            lookUpEdit制单人1.EditValue = "";
            lookUpEdit制单人2.EditValue = "";
            textEdit8位数编码.EditValue = "";
        }

        private void buttonEdit客户1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(9);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit客户1.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit客户2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(9);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit客户2.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit部门_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(3);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit部门.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit业务员_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(2);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit业务员.EditValue = frm.sID;
                frm.Enabled = true;
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

        private void buttonEdit部门_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit部门.Text.Trim() != "")
                lookUpEdit部门.EditValue = buttonEdit部门.Text.Trim();
            else
                lookUpEdit部门.EditValue = null;
        }


        private void buttonEdit部门_Leave(object sender, EventArgs e)
        {
            if (buttonEdit部门.Text.Trim() == "")
                return;
            if (lookUpEdit部门.Text.Trim() == "")
            {
                buttonEdit部门.Text = "";
                buttonEdit部门.Focus();
            }
        }

        private void buttonEdit业务员_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit业务员.Text.Trim() != "")
                lookUpEdit业务员.EditValue = buttonEdit业务员.Text.Trim();
            else
                lookUpEdit业务员.EditValue = null;
        }

        private void buttonEdit业务员_Leave(object sender, EventArgs e)
        {
            if (buttonEdit业务员.Text.Trim() == "")
                return;
            if (lookUpEdit业务员.Text.Trim() == "")
            {
                buttonEdit业务员.Text = "";
                buttonEdit业务员.Focus();
            }
        }

        private void buttonEdit客户1_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit客户1.Text.Trim() != "")
                lookUpEdit客户1.EditValue = buttonEdit客户1.Text.Trim();
            else
                lookUpEdit客户1.EditValue = null;
        }

        private void buttonEdit客户1_Leave(object sender, EventArgs e)
        {
            if (buttonEdit客户1.Text.Trim() == "")
                return;
            if (lookUpEdit客户1.Text.Trim() == "")
            {
                buttonEdit客户1.Text = "";
                buttonEdit客户1.Focus();
            }
        }

        private void buttonEdit客户2_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit客户2.Text.Trim() != "")
                lookUpEdit客户2.EditValue = buttonEdit客户2.Text.Trim();
            else
                lookUpEdit客户2.EditValue = null;
        }

        private void buttonEdit客户2_Leave(object sender, EventArgs e)
        {
            if (buttonEdit客户2.Text.Trim() == "")
                return;
            if (lookUpEdit客户2.Text.Trim() == "")
            {
                buttonEdit客户2.Text = "";
                buttonEdit客户2.Focus();
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
