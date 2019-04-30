using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 销售
{
    public partial class Frm人员调整单_Add : Form
    {
        protected 系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
        protected 系统服务.ClsGetSQL clsGetSQL = 系统服务.ClsGetSQL.Instance();
        public string 单据号1;
        public string 单据号2;
        public string 单据日期1;
        public string 单据日期2;
        public string 调整日期1;
        public string 调整日期2;
        public string 人员编码;

        public Frm人员调整单_Add(string s单据号1, string s单据号2, string s单据日期1, string s单据日期2, string s调整日期1, string s调整日期2, string s人员编码)
        {
           
            InitializeComponent();
            单据号1 = s单据号1;
            单据号2 = s单据号2;
            单据日期1 = s单据日期1;
            单据日期2 = s单据日期2;
            调整日期1 = s调整日期1;
            调整日期2 = s调整日期2;
            人员编码 = s人员编码;
        }

        public Frm人员调整单_Add()
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

        private void Frm人员调整单_Add_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookUpEdit();
                lookUpEdit单据号1.EditValue = 单据号1;
                lookUpEdit单据号2.EditValue = 单据号2;
                dateEdit单据日期1.EditValue = 单据日期1;
                dateEdit单据日期2.EditValue = 单据日期2;
                dateEdit调整日期1.EditValue = 单据日期1;
                dateEdit调整日期2.EditValue = 单据日期2;
                lookUpEdit人员编码.EditValue = 人员编码;
                buttonEdit人员编码.EditValue = 人员编码;
                
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败：" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        //public void Get(string inv1, string inv2, string date1, string date2,string cdate1,string cdate2,string person)
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
        //    if (cdate1 != null && cdate1 != "")
        //    {
        //        cdate1 = DateTime.Parse(cdate1).ToString("yyyy-MM-dd");
        //        dateEdit调整日期1.EditValue = cdate1;
        //    }
        //    if (cdate2 != null && cdate2 != "")
        //    {
        //        cdate2 = DateTime.Parse(cdate2).ToString("yyyy-MM-dd");
        //        dateEdit调整日期2.EditValue = cdate2;
        //    }
        //    lookUpEdit人员编码.EditValue = person;
        //}

        private void SetLookUpEdit()
        {
            string sSQL = "select iID,iCode from PersonAdjust";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            lookUpEdit单据号1.Properties.DataSource = dt;
            lookUpEdit单据号2.Properties.DataSource = dt;
            系统服务.LookUp.Person(lookUpEdit人员编码);
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
            if (dateEdit调整日期1.EditValue != null)
            {
                调整日期1 = dateEdit调整日期1.EditValue.ToString().Trim();
            }
            if (dateEdit调整日期2.EditValue != null)
            {
                调整日期2 = dateEdit调整日期2.EditValue.ToString().Trim();
            }
            if (lookUpEdit人员编码.EditValue != null)
            {
                人员编码 = lookUpEdit人员编码.EditValue.ToString().Trim();
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void buttonEdit人员编码_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(2);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit人员编码.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit人员编码_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit人员编码.Text.Trim() != "")
                lookUpEdit人员编码.EditValue = buttonEdit人员编码.Text.Trim();
            else
                lookUpEdit人员编码.EditValue = null;
        }

        private void buttonEdit人员编码_Leave(object sender, EventArgs e)
        {
            if (buttonEdit人员编码.Text.Trim() == "")
                return;
            if (lookUpEdit人员编码.Text.Trim() == "")
            {
                buttonEdit人员编码.Text = "";
                buttonEdit人员编码.Focus();
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            lookUpEdit单据号1.EditValue = "";
            lookUpEdit单据号2.EditValue = "";
            dateEdit单据日期1.EditValue = DBNull.Value;
            dateEdit单据日期2.EditValue = DBNull.Value;
            dateEdit调整日期1.EditValue = DBNull.Value;
            dateEdit调整日期2.EditValue = DBNull.Value;
            lookUpEdit人员编码.EditValue = "";
            buttonEdit人员编码.EditValue = "";
        }
    }
}
