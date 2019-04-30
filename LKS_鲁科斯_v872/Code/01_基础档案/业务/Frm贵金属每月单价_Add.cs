using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 基础设置
{
    public partial class Frm贵金属每月单价_Add : Form
    {
        protected 系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
        protected 系统服务.ClsGetSQL clsGetSQL = 系统服务.ClsGetSQL.Instance();
        public string 单据号1;
        public string 单据号2;
        public string 单据日期1;
        public string 单据日期2;
        public string 年;

        public Frm贵金属每月单价_Add(string s单据号1, string s单据号2, string s单据日期1, string s单据日期2,string s年)
        {
           
            InitializeComponent();
            单据号1 = s单据号1;
            单据号2 = s单据号2;
            单据日期1 = s单据日期1;
            单据日期2 = s单据日期2;
            年 = s年;
        }

        public Frm贵金属每月单价_Add()
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

        private void Frm贵金属每月单价_Add_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookUpEdit();
                lookUpEdit单据号1.EditValue = 单据号1;
                lookUpEdit单据号2.EditValue = 单据号2;
                dateEdit单据日期1.EditValue = 单据日期1;
                dateEdit单据日期2.EditValue = 单据日期2;
                textEdit年.EditValue = 年;
                
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败：" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }



        private void SetLookUpEdit()
        {
            string sSQL = "select iID,iCode from PreciousMetals";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            lookUpEdit单据号1.Properties.DataSource = dt;
            lookUpEdit单据号2.Properties.DataSource = dt;
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
            if (textEdit年.EditValue != null)
            {
                年 = textEdit年.EditValue.ToString().Trim();
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void buttonClear_Click(object sender, EventArgs e)
        {
            lookUpEdit单据号1.EditValue = "";
            lookUpEdit单据号2.EditValue = "";
            dateEdit单据日期1.EditValue = DBNull.Value;
            dateEdit单据日期2.EditValue = DBNull.Value;
            textEdit年.EditValue = DBNull.Value;
        }
    }
}
