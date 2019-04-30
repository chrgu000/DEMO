using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BasicInformation
{
    public partial class FrmProProcess_Formula : Form
    {
        protected FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
        protected FrameBaseFunction.ClsGetSQL clsGetSQL = FrameBaseFunction.ClsGetSQL.Instance();
        public string sAutoID;          //销售订单子表ID
        public int i母件顺序 = 0;       //母件顺序
        public FrmProProcess_Formula(string sText,int iRow)
        {
            InitializeComponent();

            #region 禁止用户调整表格

            layoutControl1.AllowCustomizationMenu = false;

            gridView1.OptionsMenu.EnableColumnMenu = false;
            gridView1.OptionsMenu.EnableFooterMenu = false;
            gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            gridView1.OptionsMenu.ShowAutoFilterRowItem = false;
            gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            gridView1.OptionsMenu.ShowGroupSummaryEditorItem = false;
            gridView1.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.False;
            gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            gridView1.OptionsCustomization.AllowColumnMoving = false;
            //gridView1.OptionsCustomization.

            #endregion

            richTextBox1.Text = sText;
            i母件顺序 = iRow;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmProProcess_Formula_Load(object sender, EventArgs e)
        {
            try
            {
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败：" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
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

        private bool Chk公式()
        {
            bool b = false;
            try
            {
                DataTable dt = (DataTable)gridControl1.DataSource;
                string s = richTextBox1.Text.Trim();

                b = true;
            }
            catch { }

            return b;
        }


        private void btnEnsure_Click(object sender, EventArgs e)
        {
            if (Chk公式())
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            string sBtnText = ((System.Windows.Forms.Button)sender).Text.Trim();
            if (sBtnText == "清除")
            {
                richTextBox1.Text = "";
            }
            else
            {
                richTextBox1.Text = richTextBox1.Text + sBtnText;
            }
        }

        private void GetGrid()
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "计算列";
            dt.Columns.Add(dc);
            DataRow dr = dt.NewRow();
            dr["计算列"] = "开工时间";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["计算列"] = "结束时间";
            dt.Rows.Add(dr);

            gridControl1.DataSource = dt;
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Text = richTextBox1.Text + "【" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridCol计算列).ToString().Trim() + "】" + "〈" + i母件顺序 + "〉";
            }
            catch { }
        }
    }
}
