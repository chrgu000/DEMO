using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 销售
{
    public partial class Frm销售订单业务费用历史_Add : Form
    {
        private uint _PropertyName;
        protected 系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
        protected 系统服务.ClsGetSQL clsGetSQL = 系统服务.ClsGetSQL.Instance();
        public string ID;
        public DataTable dttmp;

        public decimal 母件数量;
        private bool bAllowEdit = false;
        public string 删除 = "";
        public string cCusCode = "";
        decimal 数量 = 0;
        public decimal 业务费用 = 0;
        public string State = "";
        public string cInvCode = "";

        public Frm销售订单业务费用历史_Add(string sID, DataTable sdttmp, bool bEdit, string sState,string scCusCode,decimal s数量,string scInvCode,string s删除)
        {
            InitializeComponent();
            ID = sID;
            dttmp = sdttmp;
            bAllowEdit = bEdit;
            cCusCode = scCusCode;
            数量 = s数量;
            textEdit数量.EditValue = s数量;
            删除 = s删除;
            State = sState;
            cInvCode = scInvCode;
            系统服务.LookUp.Inventory(ItemLookUpEditcInvName);
            if (sState == "")
            {
                gridView1.OptionsBehavior.ReadOnly = true;
                btnDel.Enabled = false;
                btnEnsure.Enabled = false;
            }
            else
            {
                if (dttmp.Rows.Count == 0 && cCusCode != "")
                {
                    DialogResult MsgBoxResult = MessageBox.Show("是否导入客户档案中客户信息", "请选择你要按下的按钮", MessageBoxButtons.YesNo);
                    if (MsgBoxResult == DialogResult.Yes)
                    {
                        string sSQL = "select * from Customer where cCusCode='" + cCusCode + "'";
                        DataTable dts = clsSQLCommond.ExecQuery(sSQL);
                        if (dts.Rows.Count > 0)
                        {
                            DataRow dw = dttmp.NewRow();
                            dw["SS1"] = dts.Rows[0]["cCusPerson"].ToString();
                            dw["SS2"] = dts.Rows[0]["cCusPhone"].ToString();
                            dw["SS3"] = dts.Rows[0]["cCusAddress"].ToString();
                            dw["SS5"] = cInvCode;
                            dw["DD2"] = s数量;
                            dttmp.Rows.Add(dw);
                        }
                    }
                }

            }
        }

        public Frm销售订单业务费用历史_Add()
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

        private void Frm销售订单业务费用历史_Add_Load(object sender, EventArgs e)
        {
            try
            {
                gridView1.OptionsBehavior.Editable = bAllowEdit;
                btnDel.Enabled = bAllowEdit;
                btnEnsure.Enabled = bAllowEdit;

                SetLookUpEdit();
                gridControl1.DataSource = dttmp;
                if (State != "")
                {
                    gridView1.AddNewRow();
                    gridView1.FocusedRowHandle = 0;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败：" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void SetLookUpEdit()
        {
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
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }
            string sErr = "";
            业务费用 = 0;
            string 销售订单 = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridColSS1).ToString().Trim() != "" || gridView1.GetRowCellValue(i, gridColSS2).ToString().Trim() != "" || gridView1.GetRowCellValue(i, gridColSS3).ToString().Trim() != "" || gridView1.GetRowCellValue(i, gridColDD1).ToString().Trim() != "" || gridView1.GetRowCellValue(i, gridColDD2).ToString().Trim() != "")
                {
                    if (gridView1.GetRowCellValue(i, gridColSS1).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + gridColSS1.Caption + "不能为空\n";
                    }
                    if (gridView1.GetRowCellValue(i, gridColSS2).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + gridColSS2.Caption + "不能为空\n";
                    }
                    if (gridView1.GetRowCellValue(i, gridColSS3).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + gridColSS3.Caption + "不能为空\n";
                    }
                    if (gridView1.GetRowCellValue(i, gridColSS5).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + gridColSS5.Caption + "不能为空\n";
                    }
                    if (gridView1.GetRowCellValue(i, gridColDD1).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + gridColDD1.Caption + "不能为空\n";
                    }
                    if (gridView1.GetRowCellValue(i, gridColDD2).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + gridColDD2.Caption + "不能为空\n";
                    }
                    decimal DD1 = 0;
                    decimal DD2 = 0;
                    if (gridView1.GetRowCellValue(i, gridColDD1) != null && gridView1.GetRowCellValue(i, gridColDD1).ToString().Trim() != "")
                    {
                        DD1 = decimal.Parse(gridView1.GetRowCellValue(i, gridColDD1).ToString().Trim());
                    }
                    if (gridView1.GetRowCellValue(i, gridColDD2) != null && gridView1.GetRowCellValue(i, gridColDD2).ToString().Trim() != "")
                    {
                        DD2 = decimal.Parse(gridView1.GetRowCellValue(i, gridColDD2).ToString().Trim());
                    }
                    业务费用 =业务费用+ DD1 * DD2;
                }
                else
                {
                    gridView1.DeleteRow(i);
                }
            }
            if (sErr.Length > 0)
            {
                MessageBox.Show(sErr);
            }
            else
            {
                
                dttmp = ((DataTable)gridControl1.DataSource).Copy();
                for (int i = dttmp.Rows.Count - 1; i >= 0; i--)
                {
                    if (dttmp.Rows[i]["SS1"].ToString().Trim() == "" && dttmp.Rows[i]["SS2"].ToString().Trim() == "" && dttmp.Rows[i]["SS3"].ToString().Trim() == "" &&
                        dttmp.Rows[i]["DD1"].ToString().Trim() == "" && dttmp.Rows[i]["DD2"].ToString().Trim() == "")
                    {
                        dttmp.Rows.Remove(dttmp.Rows[i]);
                    }
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            for (int i = gridView1.RowCount - 1; i >= 0; i--)
            {
                if (gridView1.IsRowSelected(i))
                {
                    if (gridView1.GetRowCellValue(i, gridColCID).ToString().Trim() != "")
                    {
                        if (删除 != "")
                        {
                            删除 = 删除 + ",";
                        }
                        删除 = 删除 + gridView1.GetRowCellValue(i, gridColCID).ToString().Trim();
                    }
                    gridView1.DeleteRow(i);
                }
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView1.FocusedRowHandle >= 0)
                    iRow = gridView1.FocusedRowHandle;

                if (e.Column == gridColDD1 || e.Column == gridColDD2)
                {
                    decimal DD1 = 0;
                    decimal DD2 = 0;
                    decimal iSum = 0;
                    if (gridView1.GetRowCellValue(iRow, gridColDD1) != null && gridView1.GetRowCellValue(iRow, gridColDD1).ToString().Trim() != "")
                    {
                        DD1 = decimal.Parse(gridView1.GetRowCellValue(iRow, gridColDD1).ToString().Trim());
                    }
                    if (gridView1.GetRowCellValue(iRow, gridColDD2) != null && gridView1.GetRowCellValue(iRow, gridColDD2).ToString().Trim() != "")
                    {
                        DD2 = decimal.Parse(gridView1.GetRowCellValue(iRow, gridColDD2).ToString().Trim());
                    }
                    iSum = DD1 * DD2;
                    if (iSum != 0)
                    {
                        gridView1.SetRowCellValue(iRow, gridCol业务费用, iSum);
                    }
                    else
                    {
                        gridView1.SetRowCellValue(iRow, gridCol业务费用, null);
                    }
                }
                //if (e.Column == gridColSS1)
                //{
                //    gridView1.SetRowCellValue(iRow, gridColDD2, textEdit数量.EditValue);
                //}

                #region
                if (iRow == gridView1.RowCount - 1 && gridView1.GetRowCellDisplayText(iRow, gridColSS1).ToString().Trim() != "")
                {
                    gridView1.AddNewRow();
                    gridView1.FocusedRowHandle = iRow;
                    if (iRow > 0)
                    {
                        gridView1.SetRowCellValue(iRow, gridColSS3, gridView1.GetRowCellValue(iRow - 1, gridColSS3));
                        gridView1.SetRowCellValue(iRow, gridColSS5, gridView1.GetRowCellValue(iRow - 1, gridColSS5));
                        gridView1.SetRowCellValue(iRow, gridColDD2, textEdit数量.EditValue);
                    }
                }
                #endregion
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        private void gridView1_CustomDrawRowIndicator_1(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void ItemButtonEditcInvCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int iRow = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.IsRowSelected(i))
                {
                    iRow = i;
                }
            }
            系统服务.Frm参照 frm = new 系统服务.Frm参照(1);
            if (DialogResult.OK == frm.ShowDialog())
            {
                gridView1.SetRowCellValue(iRow, gridColSS5, frm.sID);
                frm.Enabled = true;
            }
        }

        private void ItemButtonEditcInvCode_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void ItemButtonEditcInvCode_Leave(object sender, EventArgs e)
        {

        }
    }
}
