using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 仓库
{
    public partial class Frm装箱单_Add : Form
    {
        string tablename = "SO_SOPackingMain";
        string tableid = "cSOPCode";
        string tablenames = "SO_SOPackingDetails";
        string tablenamel = "SO_SOPackingSublist";
        string tableids = "AutoID";
        string sSQL;

        decimal 乘数 = 1M;
        private uint _PropertyName;
        protected 系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
        protected 系统服务.ClsGetSQL clsGetSQL = 系统服务.ClsGetSQL.Instance();
        public string AutoID;
        public DataTable dthas;
        public string 物料编码;
        public string 物料名称;
        public string 规格型号;

        public string 色号;
        public string 缸号;

        public decimal 母件数量;
        private bool bAllowEdit = false;
        public string 删除 = "";

        bool is散件 = false;

        public DataTable dt;

        public Frm装箱单_Add(string sAutoID, DataTable sdttmp, string s物料编码, string s物料名称, string s规格型号,
            bool bEdit, string s删除, string sState, decimal s数量, bool sis散件,string s色号,string s缸号)
        {
            InitializeComponent();
            AutoID = sAutoID;
            dthas = sdttmp;
            物料编码 = s物料编码;
            物料名称 = s物料名称;
            规格型号 = s规格型号;
            bAllowEdit = bEdit;
            删除 = s删除;
            母件数量 = s数量;
            is散件 = sis散件;
            色号 = s色号;
            缸号 = s缸号;
            if (is散件 == true)
            {
                gridCol箱数.Visible = false;
                gridCol数量.Visible = false;
                gridCol件数.Visible = false;
                gridCol换算率.Visible = false;
            }
            else
            {
                gridCol盒号.Visible = false;
                gridCol盒数.Visible = false;
                gridCol装箱单子表sID.Visible = false;
                gridCol数量2.Visible = false;
                gridCol件数2.Visible = false;
                gridCol换算率2.Visible = false;
            }
            if (sState == "")
            {
                textEdit物料编码.Enabled = false;
                gridView1.OptionsBehavior.ReadOnly = true;
                btnEnsure.Enabled = false;
            }
        }

        public Frm装箱单_Add()
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

        private void Frm装箱单_Add_Load(object sender, EventArgs e)
        {
            try
            {
                gridView1.OptionsBehavior.Editable = bAllowEdit;

                btnEnsure.Enabled = bAllowEdit;

                SetLookUpEdit();
                textEditAutoID.EditValue = AutoID;
                textEdit物料编码.EditValue = 物料编码;
                textEdit物料名称.EditValue = 物料名称;
                textEdit规格型号.EditValue = 规格型号;
                textEdit数量.EditValue = 母件数量;
                lookUpEdit色号.EditValue = 色号;
                lookUpEdit缸号.EditValue = 缸号;

                GetGrid();

            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败：" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void GetGrid()
        {
            if (is散件 == false)
            {
                sSQL = "select a.*,'' as iChk, cClosesysPerson,cClosesysTime,b.AutoID,b.M1,b.M2,b.M3,b.M4,b.M5,b.M6,b.M7,b.M8,b.M9,b.M10,b.BoxQty,b.BoxNo,"
                + "b.cInvCode, b.iQuantity,b.iNum, b.iNatTax, b.iTaxRate, b.iChangRate, b.iUnitPrice,b.iMoney, b.iNatUnitPrice,b.iNatMoney "
                + "from dbo." + tablename + " a left join " + tablenames + " b on a.ID=b.ID  "
                + " left join (select SoPAutoID,count(SoPAutoID) scount from SO_SOOutSublist group by SoPAutoID) r on b.AutoID=r.SoPAutoID "
                + " where scount is null and a.dVerifysysPerson is not null and a.dClosesysPerson is null and b.cClosesysPerson is null ";

            }
            else
            {
                sSQL = "select a.*,'' as iChk, cClosesysPerson,cClosesysTime,b.AutoID,b.M1,b.M2,b.M3,b.M4,b.M5,b.M6,b.M7,b.M8,b.M9,b.M10,b.BoxQty,b.BoxNo,c.sBoxQty,c.sBoxNo,sID,"
                + "b.cInvCode, b.iQuantity,b.iNum, b.iNatTax, b.iTaxRate, b.iChangRate, b.iUnitPrice,b.iMoney, b.iNatUnitPrice,b.iNatMoney,c.iQuantity as siQuantity,c.iNum as siNum,c.iChangRate as siChangRate "
                + "from dbo." + tablename + " a left join " + tablenames + " b on a.ID=b.ID left join " + tablenamel + " c on b.AutoID=c.AutoID "
                 + " left join (select SoPsID,count(SoPAutoID) scount from SO_SOOutSublist group by SoPsID) r on c.sID=r.SoPsID "
                + " where scount is null and a.dVerifysysPerson is not null and a.dClosesysPerson is null and b.cClosesysPerson is null ";

            }
            sSQL = sSQL + " and b.cInvCode='" + 物料编码 + "'";
            if (dthas.Rows.Count != 0)
            {
                string s = "";
                for (int i = 0; i < dthas.Rows.Count; i++)
                {
                    if (dthas.Rows[i]["SoAutoID"].ToString() != "")
                    {
                        if (s != "")
                        {
                            s = s + ",";
                        }
                        s = s + dthas.Rows[i]["SoAutoID"].ToString();
                    }
                }
                if (s.Trim() != "")
                {
                    sSQL = sSQL + " and b.AutoID not in (" + s + ")";
                }
            }
            sSQL = sSQL + " order by  a." + tableid;
            dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;
        }


        private void SetLookUpEdit()
        {
            DataTable dt = 系统服务.LookUp.Inventory();
            ItemLookUpEditcInvName.Properties.DataSource = dt;
            ItemLookUpEditcInvStd.Properties.DataSource = dt;
            系统服务.LookUp.InventoryClass(lookUpEdit色号);

            系统服务.LookUp.ColorNo(ItemLookUpEditM1);

            系统服务.LookUp.ColorNo(lookUpEdit色号);
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
            string bCode = "";
            bool b = true;
            if (dt != null)
            {
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    if (dt.Rows[i]["iChk"].ToString() == "√")
                    {
                        if (bCode == "")
                        {
                            bCode = dt.Rows[i]["ID"].ToString();
                        }
                        else
                        {
                            if (bCode != dt.Rows[i]["ID"].ToString())
                            {
                                b = false;
                            }
                        }
                    }
                    if (dt.Rows[i]["iChk"].ToString() != "√")
                    {
                        dt.Rows.Remove(dt.Rows[i]);
                    }
                }
            }
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("请至少选择一张单据");
                GetGrid();
            }
            else
            {
                if (b == true)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("一张单据只能选择一张销售订单");
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            for (int i = gridView1.RowCount - 1; i >= 0; i--)
            {
                if (gridView1.IsRowSelected(i))
                {
                    if (gridView1.GetRowCellValue(i, gridCol装箱单子表sID).ToString().Trim() != "")
                    {
                        if (删除 != "")
                        {
                            删除 = 删除 + ",";
                        }
                        删除 = 删除 + gridView1.GetRowCellValue(i, gridCol装箱单子表sID).ToString().Trim();
                    }
                    gridView1.DeleteRow(i);
                }
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
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
                gridView1.SetRowCellValue(iRow, gridCol存货编码, frm.sID);
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

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.IsRowSelected(i))
                {
                    if (gridView1.GetRowCellValue(i, gridCol选择) == "")
                    {
                        gridView1.SetRowCellValue(i, gridCol选择, "√");
                    }
                    else
                    {
                        gridView1.SetRowCellValue(i, gridCol选择, "");
                    }
                }
                //else
                //{
                //    gridView1.SetRowCellValue(i, gridCol选择, "");
                //}
            }
        }

       

    }
}
