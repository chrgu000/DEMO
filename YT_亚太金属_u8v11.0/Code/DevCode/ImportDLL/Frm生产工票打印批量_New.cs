using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImportDLL
{
    public partial class Frm生产工票打印批量_New : Form
    {
        protected FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
        protected FrameBaseFunction.ClsGetSQL clsGetSQL = FrameBaseFunction.ClsGetSQL.Instance();
        public string iType;
        public string iValue;
        public Frm生产工票打印批量_New(DataTable sdthas)
        {
           
            InitializeComponent();
        }

        public Frm生产工票打印批量_New()
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

        private void Frm工序流转卡批量_New_Load(object sender, EventArgs e)
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
            lookUpEdit人员.Enabled = false;
            dateEdit调度.Enabled = false;
        }

        

        private void SetLookUpEdit()
        {
            LookUp.EQ_EQData(lookUp机床);
            LookUp.Person(lookUpEdit人员);
        }

        private void btnEnsure_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioGroup1.SelectedIndex == 0)
                {
                    iType = "1";
                    iValue = lookUp机床.EditValue.ToString().Trim();
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else if (radioGroup1.SelectedIndex == 1)
                {
                    iType = "2";
                    iValue = lookUpEdit人员.EditValue.ToString().Trim();
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else if (radioGroup1.SelectedIndex == 2)
                {
                    iType = "3";
                    iValue = dateEdit调度.EditValue.ToString();
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
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
                LookUp.Person(lookUpEdit人员);
                LookUp.EQ_EQData(lookUp机床);
                lookUp机床.EditValue = "";
                lookUpEdit人员.EditValue = "";
                dateEdit调度.EditValue = null;
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
                lookUp机床.Enabled = true;
                lookUpEdit人员.EditValue = "";
                lookUpEdit人员.Enabled = false;
                dateEdit调度.EditValue = null;
                dateEdit调度.Enabled = false;
            }
            else if (radioGroup1.SelectedIndex == 1)
            {
                lookUpEdit人员.Enabled = true;
                lookUp机床.Enabled = false;
                lookUp机床.EditValue = "";
                dateEdit调度.EditValue = null;
                dateEdit调度.Enabled = false;
            }
            else
            {
                dateEdit调度.Enabled = true;
                lookUp机床.Enabled = false;
                lookUp机床.EditValue = "";
                lookUpEdit人员.EditValue = "";
                lookUpEdit人员.Enabled = false;
            }
        }

    }
}
