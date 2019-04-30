using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 销售
{
    public partial class Frm意向性客户登记单_Add : Form
    {
        protected 系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
        protected 系统服务.ClsGetSQL clsGetSQL = 系统服务.ClsGetSQL.Instance();
        public string 单据号1 = "";
        public string 单据号2 = "";
        public string 单据日期1 = "";
        public string 单据日期2 = "";
        public string 部门 = "";
        public string 客户全称 = "";
        public string 业务员 = "";

        public Frm意向性客户登记单_Add(string s单据号1, string s单据号2, string s单据日期1, string s单据日期2, string s部门, string s客户全称, string s业务员)
        {
           
            InitializeComponent();
            单据号1 = s单据号1;
            单据号2 = s单据号2;
            单据日期1 = s单据日期1;
            单据日期2 = s单据日期2;
            部门 = s部门;
            客户全称 = s客户全称;
            业务员 = s业务员;
        }

        public Frm意向性客户登记单_Add()
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

        private void FrmWorkPlanAdd_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookUpEdit();
                lookUpEdit单据号1.EditValue = 单据号1;
                lookUpEdit单据号2.EditValue = 单据号2;
                dateEdit单据日期1.EditValue = 单据日期1;
                dateEdit单据日期2.EditValue = 单据日期2;
                buttonEdit部门.EditValue = 部门;
                textEdit客户全称.EditValue = 客户全称;
                buttonEdit业务员.EditValue = 业务员;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败：" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        //public void Get(string inv1, string inv2, string date1, string date2,string dept,string cname,string person)
        //{
        //    lookUpEdit单据号1.EditValue = inv1;
        //    lookUpEdit单据号2.EditValue = inv2;
        //    if (date1 != null && date1 != "")
        //    {
        //        date1 = DateTime.Parse(date1).ToString("yyyy-MM-dd");
        //        dateEdit单据日期1.EditValue = date1;
        //    }
        //    if (date2 != null && date2 != "")
        //    {
        //        date2 = DateTime.Parse(date2).ToString("yyyy-MM-dd");
        //        dateEdit单据日期2.EditValue = date2;
        //    }
        //    lookUpEdit部门.EditValue = dept;
        //    textEdit客户全称.EditValue = cname;
        //    lookUpEdit业务员.EditValue = person;
        //}

        private void SetLookUpEdit()
        {
            string sSQL = "select iID,iCode from CustomersIntentionality";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            lookUpEdit单据号1.Properties.DataSource = dt;
            lookUpEdit单据号2.Properties.DataSource = dt;
            系统服务.LookUp.Person(lookUpEdit业务员);
            系统服务.LookUp.Department(lookUpEdit部门);
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
            if (lookUpEdit部门.Text.Trim() != "")
            {
                部门 = lookUpEdit部门.EditValue.ToString().Trim();
            }
            if (textEdit客户全称.EditValue != null)
            {
                客户全称 = textEdit客户全称.Text.Trim();
            }
            if (lookUpEdit业务员.EditValue != null)
            {
                业务员 = lookUpEdit业务员.EditValue.ToString().Trim();
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
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

        private void buttonEdit部门_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(3);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit部门.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit业务员_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit业务员.Text.Trim() != "")
            {
                lookUpEdit业务员.EditValue = buttonEdit业务员.Text.Trim();
                if (lookUpEdit业务员.Text.Trim() != "")
                {
                    DataTable dt = 系统服务.LookUp.PersonDepartment(buttonEdit业务员.Text.Trim());
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        buttonEdit部门.EditValue = dt.Rows[0]["cDepCode"];
                    }
                }
            }
            else
            {
                lookUpEdit业务员.EditValue = null;
                buttonEdit部门.EditValue = null;
            }
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

        private void buttonEdit部门_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit部门.Text.Trim() != "")
                lookUpEdit部门.EditValue = buttonEdit部门.Text.Trim();
            else
                lookUpEdit部门.EditValue = null;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            lookUpEdit单据号1.EditValue = "";
            lookUpEdit单据号2.EditValue = "";
            dateEdit单据日期1.EditValue = DBNull.Value;
            dateEdit单据日期2.EditValue = DBNull.Value;
            lookUpEdit部门.EditValue = "";
            lookUpEdit业务员.EditValue = "";
            buttonEdit部门.EditValue = "";
            buttonEdit业务员.EditValue = "";
            textEdit客户全称.EditValue = "";
        }
    }
}
