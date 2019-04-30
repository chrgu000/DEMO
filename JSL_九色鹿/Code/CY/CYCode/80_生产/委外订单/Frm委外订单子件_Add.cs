using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 生产
{
    public partial class Frm委外订单子件_Add : Form
    {
        decimal 乘数 = 1M;
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

        public DataTable dtall;

        public Frm委外订单子件_Add(string sAutoID, string s行标记, DataTable sdttmp, string s物料编码, string s物料名称, string s规格型号, 
            bool bEdit, string s删除, string sState,decimal s数量,DataTable sdtall)
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
            dtall = sdtall;
            if (sState == "")
            {
                textEdit物料编码.Enabled = false;
                gridView1.OptionsBehavior.ReadOnly = true;
                btnDel.Enabled = false;
                btnEnsure.Enabled = false;
                //button选择子件.Enabled = false;
            }
        }

        public Frm委外订单子件_Add()
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

        private void Frm委外订单子件_Add_Load(object sender, EventArgs e)
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
//                for (int i = 0; i < dttmp.Rows.Count; i++)
//                {
//                    string sSQL = @"select --a.*,'' as iChk, cClosesysPerson,cClosesysTime,b.AutoID,
//                    --b.cInvCode,
//case when isnull(b.D6,0)<>0 then isnull(b.D6,0) else isnull(b.iQuantity,0) end -isnull(r.iQuantity,0)-isnull(f.iQuantity,0)+isnull(sBoxQty,0) as iQuantity
//--isnull(b.iNum,0)-isnull(r.iNum,0)-isnull(f.iNum,0) as iNum, b.iNatTax, b.iTaxRate, 
//                    --b.iChangRate, b.iUnitPrice, b.iUnitPrice*(isnull(b.iQuantity,0)-isnull(r.iQuantity,0)) as iMoney, b.iNatUnitPrice,b.M1,b.M2,b.M3,b.M4,b.M5,b.M6,b.M7,b.M8,b.M9,b.M10 
//                    from RdRecord a left join RdRecords b on a.ID=b.ID  
//                    left join (select RdAutoID,sum(isnull(iQuantity,0)) as iQuantity,sum(isnull(iNum,0)) as iNum from MO_MOSublist where 1=1 group by RdAutoID) r on b.AutoID=r.RdAutoID 
//                     left join (select RdAutoID,sum(isnull(iQuantity,0)) as iQuantity,sum(isnull(iNum,0)) as iNum from RdRecords13 group by RdAutoID) f on b.AutoID=f.RdAutoID 
//                     where cRSCode in (01,02,03) and case when isnull(b.D6,0)<>0 then isnull(b.D6,0) else isnull(b.iQuantity,0) end-isnull(r.iQuantity,0)-isnull(f.iQuantity,0)+isnull(sBoxQty,0)>0 
//and a.dVerifysysPerson is not null and a.dClosesysPerson is null and b.cClosesysPerson is null and b.AutoID='"+dttmp.Rows[i]["RdAutoID"]+"'";
//                    if (dttmp.Rows[i]["sID"].ToString().Trim() != "")
//                    {
//                        sSQL = sSQL.Replace("1=1", "1=1 and sID<>" + dttmp.Rows[i]["sID"].ToString().Trim() + "");
//                    }
//                    DataTable dts = clsSQLCommond.ExecQuery(sSQL);
//                    if (dts.Rows.Count > 0)
//                    {
//                        dttmp.Rows[i]["可用数量"] = dts.Rows[0]["iQuantity"];
//                    }
//                }
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
            系统服务.LookUp.Inventory(ItemLookUpEdit物料名称);
            ItemLookUpEdit物料名称.Properties.DisplayMember = "cInvName";
            系统服务.LookUp.Inventory(ItemLookUpEdit物料规格);
            ItemLookUpEdit物料规格.Properties.DisplayMember = "cInvStd";
            系统服务.LookUp.Inventory(ItemLookUpEdit物料代码);
            ItemLookUpEdit物料规格.Properties.DisplayMember = "cInvAddCode";

            系统服务.LookUp.ColorNo(ItemLookUpEditM1);
            系统服务.LookUp.Dyelot(ItemLookUpEditM2);

            //系统服务.LookUp.RdRecords(ItemLookUpEdit出入库单号);
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
            //string type = lookUpEdit物料分类.EditValue.ToString().Substring(2, lookUpEdit物料分类.EditValue.ToString().Length - 2);
            string sErr = "";
            string tx = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridCol子件编码).ToString().Trim() != "" && gridView1.GetRowCellValue(i, gridCol数量).ToString().Trim() == "")
                {
                    sErr = sErr + "行" + (i + 1) + "数量不能为0\n";
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

                if (e.Column == gridCol子件编码 || e.Column == gridCol子件名称 || e.Column == gridCol子件规格 )
                {
                    if (e.Column == gridCol子件编码)
                    {
                        gridView1.SetRowCellValue(iRow, gridCol子件名称, gridView1.GetRowCellValue(iRow, gridCol子件编码).ToString().Trim());
                        gridView1.SetRowCellValue(iRow, gridCol子件规格, gridView1.GetRowCellValue(iRow, gridCol子件编码).ToString().Trim());
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
                if (gridView1.GetRowCellValue(iRow, gridCol行标记) == null || gridView1.GetRowCellValue(iRow, gridCol行标记).ToString().Trim() == "")
                {
                    gridView1.SetRowCellValue(iRow, gridCol行标记, textEdit行标记.EditValue.ToString().Trim());
                    if (textEditAutoID.EditValue.ToString().Trim() != "")
                    {
                        gridView1.SetRowCellValue(iRow, gridColAutoID, textEditAutoID.EditValue.ToString().Trim());
                    }
                }
                if (e.Column == gridCol子件编码)
                {
                    
                }

                //if (clsPublic.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol数量)) > clsPublic.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol可用数量))+10)
                //{
                //    throw new Exception("数量不可超出可用数量10KG");
                //    gridView1.SetRowCellValue(iRow, gridCol数量, gridView1.GetRowCellValue(iRow, gridCol可用数量));
                //}
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
