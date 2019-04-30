using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 销售
{
    public partial class Frm销售订单子件_Add : Form
    {
        decimal 乘数 = 0.1M;
        private uint _PropertyName;
        protected 系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
        protected 系统服务.ClsGetSQL clsGetSQL = 系统服务.ClsGetSQL.Instance();
        public string AutoID;
        public string 行标记;
        public DataTable dttmp;
        public string 物料编码;
        public string 物料名称;
        public string 规格型号;

        public decimal 母件数量;
        private bool bAllowEdit = false;
        public string 删除 = "";

        public Frm销售订单子件_Add(string sAutoID, string s行标记, DataTable sdttmp, string s物料编码, string s物料名称, string s规格型号, bool bEdit, string s删除, string sState,decimal s数量)
        {
            InitializeComponent();
            AutoID = sAutoID;
            行标记 = s行标记;
            dttmp = sdttmp;
            物料编码 = s物料编码;
            物料名称 = s物料名称;
            规格型号 = s规格型号;
            bAllowEdit = bEdit;
            删除 = s删除;
            母件数量 = s数量;
            if (sState == "")
            {
                textEdit物料编码.Enabled = false;
                gridView1.OptionsBehavior.ReadOnly = true;
                btnDel.Enabled = false;
                btnEnsure.Enabled = false;
            }
        }

        public Frm销售订单子件_Add()
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

        private void Frm销售订单子件_Add_Load(object sender, EventArgs e)
        {
            try
            {
                gridView1.OptionsBehavior.Editable = bAllowEdit;
                btnDel.Enabled = bAllowEdit;
                btnEnsure.Enabled = bAllowEdit;

                SetLookUpEdit();
                textEditAutoID.EditValue = AutoID;
                textEdit行标记.EditValue = 行标记;
                textEdit物料编码.EditValue = 物料编码;
                textEdit物料名称.EditValue = 物料名称;
                textEdit规格型号.EditValue = 规格型号;
                textEdit数量.EditValue = 母件数量;
                string sSQL = "select * from Inventory where cInvCode='" + 物料编码 + "'";
                DataTable dts = clsSQLCommond.ExecQuery(sSQL);
                if (dts.Rows.Count > 0)
                {
                    lookUpEdit物料分类.EditValue = dts.Rows[0]["cInvClassCode"].ToString();
                }
                gridControl1.DataSource = dttmp;
                gridView1.AddNewRow();
                gridView1.FocusedRowHandle = 0;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败：" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void SetLookUpEdit()
        {
            DataTable dt = 系统服务.LookUp.Inventory();
            ItemLookUpEditcInvCode.Properties.DataSource = dt;
            ItemLookUpEditcInvName.Properties.DataSource = dt;
            ItemLookUpEditcInvStd.Properties.DataSource = dt;
            系统服务.LookUp.Inventory3(ItemLookUpEdit子件代码);
            系统服务.LookUp.InventoryClass(lookUpEdit物料分类);
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
            AutoID = textEditAutoID.EditValue.ToString().Trim();
            行标记 = textEdit行标记.EditValue.ToString().Trim();
            物料编码 = textEdit物料编码.EditValue.ToString().Trim();
            物料名称 = textEdit物料名称.EditValue.ToString().Trim();
            规格型号 = textEdit规格型号.EditValue.ToString().Trim();
            string type = lookUpEdit物料分类.EditValue.ToString().Substring(2, lookUpEdit物料分类.EditValue.ToString().Length - 2);
            string sErr = "";
            string tx = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridCol子件编码).ToString().Trim() != "" && gridView1.GetRowCellValue(i, gridCol数量).ToString().Trim() == "")
                {
                    sErr = sErr + "行" + (i + 1) + "数量不能为0\n";
                }
                else
                {

                    if (gridView1.GetRowCellValue(i, gridCol子件编码).ToString().Trim() != "" && lookUpEdit物料分类.EditValue.ToString().Trim() == "0101")
                    {
                        if (double.Parse(gridView1.GetRowCellValue(i, gridCol数量).ToString()) != double.Parse(textEdit数量.EditValue.ToString()))
                        {
                            tx = tx + "行" + (i + 1) + "PAM的物料数量应该与子件数量相等\n";
                        }
                    }
                }
                if (gridView1.GetRowCellValue(i, gridCol子件编码).ToString().Trim() != "")
                {
                    string stype = gridView1.GetRowCellValue(i, gridCol子件分类).ToString().Trim();
                    if (stype != "03")
                    {
                        if (type != stype.Substring(2, stype.Length - 2))
                        {
                            tx = tx + "行" + (i + 1) + "子件分类应该与物料分类相同\n";
                        }
                    }
                    
                }
            }
            if (sErr.Length > 0)
            {
                MessageBox.Show(sErr);
            }
            else
            {
                if (tx != "")
                {
                    MessageBox.Show(tx);
                }
                dttmp = (DataTable)gridControl1.DataSource;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            for (int i = gridView1.RowCount - 1; i >= 0; i--)
            {
                if (gridView1.IsRowSelected(i))
                {
                    if (gridView1.GetRowCellValue(i, gridColsID).ToString().Trim() != "")
                    {
                        if (删除 != "")
                        {
                            删除 = 删除 + ",";
                        }
                        删除 = 删除 + gridView1.GetRowCellValue(i, gridColsID).ToString().Trim();
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

                if (e.Column == gridCol子件编码 || e.Column == gridCol子件名称 || e.Column == gridCol规格型号 || e.Column == gridCol使用数量)
                {
                    if (e.Column == gridCol子件编码)
                    {
                        gridView1.SetRowCellValue(iRow, gridCol子件名称, gridView1.GetRowCellValue(iRow, gridCol子件编码).ToString().Trim());
                        gridView1.SetRowCellValue(iRow, gridCol规格型号, gridView1.GetRowCellValue(iRow, gridCol子件编码).ToString().Trim());
                    }
                    decimal 换算率 = 0;
                    string sSQL = "select isnull(换算率,0) from dbo.Inventory where cInvCode = '" + gridView1.GetRowCellValue(iRow, gridCol子件编码).ToString().Trim() + "'";
                    decimal d换算率 = Convert.ToDecimal(clsSQLCommond.ExecGetScalar(sSQL));
                    if (d换算率 != 0)
                    {
                        换算率 = d换算率;
                        gridView1.SetRowCellValue(iRow, gridCol换算率, d换算率);
                    }
                    else
                    {
                        gridView1.SetRowCellValue(iRow, gridCol换算率, null);
                    }


                    if (gridView1.GetRowCellValue(iRow, gridCol使用数量) != null && gridView1.GetRowCellValue(iRow, gridCol使用数量).ToString().Trim() != "")
                    {
                        gridView1.SetRowCellValue(iRow, gridCol数量, Convert.ToDecimal(gridView1.GetRowCellValue(iRow, gridCol使用数量)) * Convert.ToDecimal(母件数量) * 乘数);
                    }
                    if (换算率 != 0)
                    {
                        gridView1.SetRowCellValue(iRow, gridCol换算率, 换算率);
                        if (gridView1.GetRowCellValue(iRow, gridCol数量) != null && gridView1.GetRowCellValue(iRow, gridCol数量).ToString().Trim() != "")
                        {
                            gridView1.SetRowCellValue(iRow, gridCol件数, Convert.ToDecimal(gridView1.GetRowCellValue(iRow, gridCol数量)) * 换算率 * 乘数);
                        }
                    }
                    else
                    {
                        gridView1.SetRowCellValue(iRow, gridCol换算率, null);
                        gridView1.SetRowCellValue(iRow, gridCol件数, null);
                    }
                }
                if (e.Column == gridCol子件编码)
                {
                    gridView1.SetRowCellValue(iRow, gridCol子件单价, GetPrice(gridView1.GetRowCellValue(iRow, gridCol子件编码).ToString().Trim()));

                    if (gridView1.GetRowCellValue(iRow, gridCol子件单价).ToString().Trim() == "0")
                    {
                        MessageBox.Show("子件单价不能为空，请设置调价单，本次允许手工填写", "提示");
                    }

                    string sSQL = "select * from Inventory where cInvCode='" + gridView1.GetRowCellValue(iRow, gridCol子件编码).ToString().Trim() + "'";
                    DataTable dts = clsSQLCommond.ExecQuery(sSQL);
                    if (dts.Rows.Count > 0)
                    {
                        gridView1.SetRowCellValue(iRow, gridCol子件分类, dts.Rows[0]["cInvClassCode"].ToString());
                    }
                }

                if (gridView1.GetRowCellValue(iRow, gridCol行标记) == null || gridView1.GetRowCellValue(iRow, gridCol行标记).ToString().Trim() == "")
                {
                    gridView1.SetRowCellValue(iRow, gridCol行标记, textEdit行标记.EditValue.ToString().Trim());
                    if (textEditAutoID.EditValue.ToString().Trim() != "")
                    {
                        gridView1.SetRowCellValue(iRow, gridColAutoID, textEditAutoID.EditValue.ToString().Trim());
                    }
                }
                if (e.Column == gridCol子件编码 || e.Column == gridCol使用数量)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (gridView1.GetRowCellValue(i, gridCol子件分类) != null && gridView1.GetRowCellValue(i, gridCol子件分类).ToString().Trim() != "")
                        {
                            if (gridView1.GetRowCellValue(i, gridCol子件分类).ToString().Trim().IndexOf("03") == 0)
                            {
                                double count = 10;
                                for (int s = 0; s < gridView1.RowCount; s++)
                                {
                                    if (i != s)
                                    {
                                        if (gridView1.GetRowCellValue(s, gridCol使用数量) != null && gridView1.GetRowCellValue(s, gridCol使用数量).ToString().Trim() != "")
                                        {
                                            count = count - double.Parse(gridView1.GetRowCellValue(s, gridCol使用数量).ToString().Trim());
                                        }
                                    }
                                }
                                if (gridView1.GetRowCellValue(i, gridCol使用数量).ToString().Trim() != count.ToString())
                                {
                                    gridView1.SetRowCellValue(i, gridCol使用数量, count);
                                    gridView1.SetRowCellValue(i, gridCol数量, Convert.ToDecimal(gridView1.GetRowCellValue(i, gridCol使用数量)) * Convert.ToDecimal(母件数量) * 乘数);
                                }
                            }
                        }
                    }
                }


                #region
                if (iRow == gridView1.RowCount - 1 && gridView1.GetRowCellDisplayText(iRow, gridCol子件编码).ToString().Trim() != "")
                {
                    gridView1.AddNewRow();
                    gridView1.FocusedRowHandle = iRow;
                }
                #endregion
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        private decimal GetPrice(string cInvCode)
        {
            string  sSQL = "select a.* from SO_SOSublist a left join SO_SOMain b on b.ID=a.ID where  a.cInvCode='" + cInvCode + "' order by b.dDate desc,a.ID desc";
            DataTable dtjgs = clsSQLCommond.ExecQuery(sSQL);
            if (dtjgs.Rows.Count > 0 && dtjgs.Rows[0]["D1"].ToString().Trim()!="")
            {
                return decimal.Parse(dtjgs.Rows[0]["D1"].ToString().Trim());
            }
            return 0;
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
                gridView1.SetRowCellValue(iRow, gridCol子件编码, frm.sID);
                frm.Enabled = true;
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
    }
}
