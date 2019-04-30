using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 仓库
{
    public partial class Frm委外订单_New2 : Form
    {
        string tablename = "MO_MOMain";
        string tableid = "ID";
        string tablecode = "cMOCode";
        string tablenames = "MO_MODetails";
        string tableids = "AutoID";
        string tablenamel = "MO_MOSublist";
        public string cMSCode = "";
        public string 供应商 = "";
        public string cWhCode = "";

        protected 系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
        protected 系统服务.ClsGetSQL clsGetSQL = 系统服务.ClsGetSQL.Instance();
        protected 系统服务.公共调用 clsPublic = new 系统服务.公共调用();
        public string 红蓝标志;
        public DataTable dt;
        DataTable dthas;
        public Frm委外订单_New2(DataTable sdthas)
        {
           
            InitializeComponent();
            dthas = sdthas;
        }

        public Frm委外订单_New2()
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

        private void Frm委外订单_New2_Load(object sender, EventArgs e)
        {
            try
            {
                if (红蓝标志 == "")
                {

                    radioGroup蓝红标识.EditValue = "1";
                }
                else
                {
                    radioGroup蓝红标识.EditValue = 红蓝标志;
                }

                if (供应商.Trim() != "")
                {
                    buttonEdit委外供应商.EditValue = 供应商;
                    buttonEdit委外供应商.Enabled = false;
                }
                else
                {
                    buttonEdit委外供应商.Enabled = true;
                }
                

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
            if (lookUpEdit委外供应商.EditValue!=null && lookUpEdit委外供应商.EditValue.ToString().Trim() != "")
            {
                供应商 = lookUpEdit委外供应商.EditValue.ToString().Trim();
            }
            if (供应商.Trim() == "")
                return;
            string sSQL = "";
            if (radioGroup蓝红标识.EditValue.ToString().Trim() == "1")
            {
                sSQL = "select a.*,c.M1 as MOM1,'' as iChk,b.AutoID,b.sID,b.cInvCode, isnull(b.iQuantity,0)-isnull(b.iOutQuantity,0) as iQuantity, isnull(b.iNum,0)-isnull(b.iOutNum,0) as iNum,b.iChangRate,b.M1,b.M2,b.M3,b.M4,b.M5,b.M6,b.M7,b.M8,b.M9,b.M10,null as RdAutoID,convert(nvarchar(500),null) as RdAutoIDList,convert(nvarchar(500),null) as RdAutoIDListQty  " +
                        "from dbo." + tablename + " a left join "+tablenames+" c on a.ID=c.ID left join " + tablenamel + " b on b.AutoID=c.AutoID " +
                        "where isnull(b.iQuantity,0)-isnull(b.iOutQuantity,0) > 0 and a.dVerifysysPerson is not null and a.dClosesysPerson is null and cVenCode='" + 供应商 + "' ";
            }
            if (radioGroup蓝红标识.EditValue.ToString().Trim() == "2")
            {
                sSQL = @"select  a.*,'' as iChk,b.AutoID,b.sID,b.cInvCode,-isnull(f.iQuantity,0)-isnull(f.iOutQuantity,0) as iQuantity, -isnull(f.iNum,0) as iNum,f.M1,f.M2,f.iChangRate,f.AutoID as RdAutoID 
                from MO_MOMain a left join MO_MOSublist b on a.ID=b.ID left join  RdRecords12 f on b.sID=f.MOsID
                where -isnull(f.iQuantity,0)-isnull(f.iOutQuantity,0)<0 and isnull(f.iQuantity,0)>0  and a.dVerifysysPerson is not null and a.dClosesysPerson is null and cVenCode='" + 供应商 + "'";
            }
            if (lookUpEdit单据号1.EditValue!=null && lookUpEdit单据号1.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and a.cMOCode>='" + lookUpEdit单据号1.EditValue.ToString().Trim() + "'";
            }
            if (lookUpEdit单据号2.EditValue!=null && lookUpEdit单据号2.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and a.cMOCode<='" + lookUpEdit单据号2.EditValue.ToString().Trim() + "'";
            }
            if (dateEdit单据日期1.EditValue!=null && dateEdit单据日期1.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and dDate >= '" + dateEdit单据日期1.EditValue.ToString().Trim() + "'";
            }
            if (dateEdit单据日期2.EditValue!=null && dateEdit单据日期2.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and dDate<='" + dateEdit单据日期2.EditValue.ToString().Trim() + "'";
            }
            if (buttonEdit物料编码1.EditValue != null && buttonEdit物料编码1.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and b.cInvCode>= '" + buttonEdit物料编码1.EditValue.ToString().Trim() + "'";
            }
            if (buttonEdit物料编码2.EditValue != null && buttonEdit物料编码2.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and b.cInvCode<= '" + buttonEdit物料编码2.EditValue.ToString().Trim() + "'";
            }
            sSQL = sSQL + " and cMSCode='" + cMSCode + "'";
            if (dthas.Rows.Count != 0)
            {
                string s = "";
                for (int i = 0; i < dthas.Rows.Count; i++)
                {
                    if (dthas.Rows[i].RowState == DataRowState.Deleted)
                        continue;

                    if (dthas.Rows[i]["MOsID"].ToString() != "")
                    {
                        if (s != "")
                        {
                            s = s + ",";
                        }
                        s = s + dthas.Rows[i]["MOsID"].ToString();
                    }
                }
                if (s.Trim() != "")
                {
                    sSQL = sSQL + " and b.AutoID not in (" + s + ")";
                }
            }
            
            sSQL = sSQL + " order by  b.AutoID";
            dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;
        }

        public void Get(string 单据号1, string 单据号2, string 单据日期1, string 单据日期2,string 制单日期1,string 制单日期2,string 业务员,
            string 部门, string 客户1, string 客户2, string 审核日期1, string 审核日期2, string 制单人1, string 制单人2, string 审核人1, string 审核人2)
        {
            lookUpEdit单据号1.EditValue = 单据号1;
            lookUpEdit单据号2.EditValue = 单据号2;
            if (单据日期1 != null && 单据日期1 != "")
            {
                单据日期1 = DateTime.Parse(单据日期1).ToString("yyyy-MM-dd");
                dateEdit单据日期1.EditValue = 单据日期1;
            }
            if (单据日期2 != null && 单据日期2 != "")
            {
                单据日期2 = DateTime.Parse(单据日期2).ToString("yyyy-MM-dd");
                dateEdit单据日期2.EditValue = 单据日期2;
            }
        }

        private void SetLookUpEdit()
        {
            系统服务.LookUp.MO_MOMain(lookUpEdit单据号1);
            系统服务.LookUp.MO_MOMain(lookUpEdit单据号2);

            系统服务.LookUp.Inventory(lookUpEdit物料编码1);
            系统服务.LookUp.Inventory(lookUpEdit物料编码2);

            系统服务.LookUp.Inventory(ItemLookUpEdit物料名称);
            ItemLookUpEdit物料名称.Properties.DisplayMember = "cInvName";
            系统服务.LookUp.Inventory(ItemLookUpEdit物料规格);
            ItemLookUpEdit物料规格.Properties.DisplayMember = "cInvStd";
            系统服务.LookUp.Inventory(ItemLookUpEdit物料代码);
            ItemLookUpEdit物料规格.Properties.DisplayMember = "cInvAddCode";

            系统服务.LookUp.Vendor2(lookUpEdit委外供应商);
            系统服务.LookUp.MOStyle(ItemLookUpEdit委外工序);
        }

        private void btnEnsure_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.RowCount < 1)
                    return;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    
                }
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    if (dt.Rows[i]["iChk"] != "√")
                    {
                        dt.Rows.Remove(dt.Rows[i]);
                    }
                    else
                    {
                        string s选中库存 = dt.Rows[i]["RdAutoIDList"].ToString();
                        if (s选中库存 == "")
                        {
                            throw new Exception("第" + (i + 1) + "行需选中子件");
                        }
                    }
                }
                红蓝标志 = radioGroup蓝红标识.EditValue.ToString().Trim();
                供应商 = lookUpEdit委外供应商.EditValue.ToString().Trim();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
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
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
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
            }
        }

        private void buttonEdit物料编码1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(1);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit物料编码1.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit物料编码2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(1);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit物料编码2.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit物料编码1_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit物料编码1.Text.Trim() != "")
                lookUpEdit物料编码1.EditValue = buttonEdit物料编码1.Text.Trim();
            else
                lookUpEdit物料编码1.EditValue = null;
        }

        private void buttonEdit物料编码1_Leave(object sender, EventArgs e)
        {
            if (buttonEdit物料编码1.Text.Trim() == "")
                return;
            if (lookUpEdit物料编码1.Text.Trim() == "")
            {
                buttonEdit物料编码1.Text = "";
                buttonEdit物料编码1.Focus();
            }
        }

        private void buttonEdit物料编码2_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit物料编码2.Text.Trim() != "")
                lookUpEdit物料编码2.EditValue = buttonEdit物料编码2.Text.Trim();
            else
                lookUpEdit物料编码2.EditValue = null;
        }

        private void buttonEdit物料编码2_Leave(object sender, EventArgs e)
        {
            if (buttonEdit物料编码2.Text.Trim() == "")
                return;
            if (lookUpEdit物料编码2.Text.Trim() == "")
            {
                buttonEdit物料编码2.Text = "";
                buttonEdit物料编码2.Focus();
            }
        }

        private void buttonEdit委外供应商_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(23);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit委外供应商.EditValue = frm.sID;

                frm.Enabled = true;
            }
        }

        private void buttonEdit委外供应商_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit委外供应商.Text.Trim() != "")
                lookUpEdit委外供应商.EditValue = buttonEdit委外供应商.Text.Trim();
            else
                lookUpEdit委外供应商.EditValue = null;
        }

        private void buttonEdit委外供应商_Leave(object sender, EventArgs e)
        {
            if (buttonEdit委外供应商.Text.Trim() == "")
                return;
            if (lookUpEdit委外供应商.Text.Trim() == "")
            {
                buttonEdit委外供应商.Text = "";
                buttonEdit委外供应商.Focus();
            }
        }

        private void btn子件_Click(object sender, EventArgs e)
        {
            int iRow = 0;
            if (gridView1.FocusedRowHandle > 0)
                iRow = gridView1.FocusedRowHandle;
            string cinvcode = gridView1.GetRowCellValue(iRow, gridCol物料编码).ToString();
            string AutoID = gridView1.GetRowCellValue(iRow, gridColAutoID).ToString();
            string m1 = gridView1.GetRowCellValue(iRow, gridColM1).ToString();
            decimal MaxQty = clsPublic.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol数量).ToString());
            string RdAutoIDList = gridView1.GetRowCellValue(iRow, gridCol选中库存).ToString();
            decimal RdAutoIDListQty = clsPublic.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol选中库存总量).ToString());
            系统服务.Frm库存_New frm = new 系统服务.Frm库存_New(4, cinvcode, m1, MaxQty, 1, RdAutoIDList);
            frm.cWhCode = cWhCode;
            if (DialogResult.OK == frm.ShowDialog())
            {
                DataTable dt = frm.dt;
                RdAutoIDList = frm.RdAutoIDList;
                RdAutoIDListQty = frm.RdAutoIDListQty;
                gridView1.SetRowCellValue(iRow, gridCol选中库存, RdAutoIDList);
                gridView1.SetRowCellValue(iRow, gridCol选中库存总量, RdAutoIDListQty);
                //if (dt.Rows.Count > 0)
                //{
                //    decimal iQty = ReturnDecimal(dt.Rows[0]["iQuantity"]);
                //    if (dt.Rows[0]["cWhCode"].ToString().Trim() != lookUpEdit仓库.EditValue.ToString().Trim())
                //    {
                //        MessageBox.Show("选择的入库单仓库与当前单据仓库不同");
                //    }
                //    else
                //    {
                //        if (iQuantity > iQty)
                //        {


                //            gridView1.SetRowCellValue(iRow, gridCol数量, iQty);
                //        }
                //        gridView1.SetRowCellValue(iRow, gridCol出入库单子表ID, dt.Rows[0]["AutoID"].ToString());
                //        gridView1.SetRowCellValue(iRow, gridColM2, dt.Rows[0]["M2"].ToString());
                //        gridView1.SetRowCellValue(iRow, gridColcPosCode, dt.Rows[0]["cPosCode"].ToString());
                //    }
                //}
            }
        }


    }
}
