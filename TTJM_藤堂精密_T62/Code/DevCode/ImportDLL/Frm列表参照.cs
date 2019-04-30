using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;

namespace ImportDLL
{
    public partial class Frm列表参照 : Form
    {

        FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
        DataTable dtGridInfo;

        string sLabel = "";
        string sSQL = "";
        string sID = "";
        string sIDValue = "";
        public string sReturnID = "";

        public Frm列表参照(string sText,string sSQLstring,string sIDstring,string sIDValuestring)
        {
            InitializeComponent();

            #region 禁止用户调整表格
            gridView1.OptionsMenu.EnableColumnMenu = false;
            gridView1.OptionsMenu.EnableFooterMenu = false;
            gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            gridView1.OptionsMenu.ShowAutoFilterRowItem = false;
            gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            gridView1.OptionsMenu.ShowGroupSummaryEditorItem = false;
            gridView1.OptionsMenu.ShowAddNewSummaryItem  = DevExpress.Utils.DefaultBoolean.False;
            gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            gridView1.OptionsCustomization.AllowColumnMoving = false;
            //gridView1.OptionsCustomization.

            #endregion

            sLabel = sText;
            sSQL = sSQLstring;
            sID = sIDstring;
            sIDValue = sIDValuestring;
        }


        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                gridView1.OptionsBehavior.Editable = false;

                label参照.Text = sLabel;
                buttonEdit1.Text = sIDValue;

                string sSQL2 = sSQL.Replace("1=1", "1=1 and " + sID + " like '%" + sIDValue + "%' ");
                DataTable dtGrid = clsSQLCommond.ExecQuery(sSQL2);
                gridControl1.DataSource = dtGrid;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
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

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string sSQL2 = sSQL.Replace("1=1", "1=1 and " + sID + " like '%" + buttonEdit1.Text.Trim() + "%' ");
            DataTable dtGrid = clsSQLCommond.ExecQuery(sSQL2);
            gridControl1.DataSource = dtGrid;
            gridView1.FocusedRowHandle = 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                gridView1_DoubleClick(null, null); 
            }
            catch { }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (gridView1.Columns[i].FieldName.Trim().ToLower() == sLabel.Trim().ToLower())
                    {
                        sReturnID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[i]).ToString().Trim();
                        this.DialogResult = DialogResult.OK;
                        break;
                    }
                }
            }
            catch { }
        }

        private void buttonEdit1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    buttonEdit1_ButtonClick(null, null);
                }
            }
            catch { }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
                sF.Filter = "Excel文件(*.xls)|*.xls|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridView1.ExportToXls(sF.FileName);
                    MessageBox.Show("导出Excel成功\n\t路径：" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
