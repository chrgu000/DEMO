using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImportDLL
{
    public partial class Frm工序批量_New : Form
    {
        protected FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
        protected FrameBaseFunction.ClsGetSQL clsGetSQL = FrameBaseFunction.ClsGetSQL.Instance();
        public string OpCode;
        public string 炉号;
        public Frm工序批量_New(DataTable sdthas)
        {
           
            InitializeComponent();
        }

        public Frm工序批量_New()
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

        private void Frm工序批量_New_Load(object sender, EventArgs e)
        {
            try
            {

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
            
        }

        

        private void SetLookUpEdit()
        {
            string sSQL = "select OpCode,Description  from @u8.sfc_operation";
            DataTable dtwork = clsSQLCommond.ExecQuery(sSQL);
            lookUp工序.Properties.DataSource = dtwork;
        }

        private void btnEnsure_Click(object sender, EventArgs e)
        {
            try
            {
                if (lookUp工序.Text != "")
                {
                    OpCode = lookUp工序.EditValue.ToString().Trim();
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else if (textEdit炉号.EditValue.ToString().Trim()!="")
                {
                    炉号=textEdit炉号.EditValue.ToString().Trim();
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("请选择工序或炉号");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void button查询_Click(object sender, EventArgs e)
        {
            try
            {
                textEdit炉号.EditValue = "";
                lookUp工序.EditValue = "";
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
            {
                lookUp工序.Enabled = true;
                textEdit炉号.Enabled = false;
                textEdit炉号.EditValue = "";
            }
            else
            {
                textEdit炉号.Enabled = true;
                lookUp工序.Enabled = false;
                lookUp工序.EditValue = "";
            }
        }

    }
}
