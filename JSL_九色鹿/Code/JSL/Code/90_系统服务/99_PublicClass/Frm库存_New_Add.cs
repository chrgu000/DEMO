﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 系统服务
{
    public partial class Frm库存_New_Add : Form
    {
        string tablename = "RdRecord";
        string tableid = "ID";
        string tablecode = "cRdCode";
        string tablenames = "RdRecords";
        string tableids = "AutoID";
        string sSQL;
        protected 系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
        protected 系统服务.ClsGetSQL clsGetSQL = 系统服务.ClsGetSQL.Instance();
        protected 系统服务.公共调用 clsPublic = new 系统服务.公共调用();
        public string 红蓝标志;
        public string 客户;
        public DataTable dt;
        public DataTable dthas;
        public string RdAutoID;
        public string M2;
        public decimal iQty;
        public string cPosCode;
        public string cWhCode;
        public int type;//1 期初成品  2 原料或半成品  3 辅料
        public decimal MaxQty;
        public string RdAutoIDList;
        public decimal RdAutoIDListQty;
        public int Flag=0;//0 单选  1 多选 有传入需要存货 2 多选 未传入需要存货

        public Frm库存_New_Add()
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

        private void Frm库存_New_Add_Load(object sender, EventArgs e)
        {
            try
            {
                if (cWhCode != "")
                {
                    lookUpEdit仓库.EditValue = cWhCode;
                }
                SetLookUpEdit();
                if (Flag == 1)
                {
                    gridCol选中盒数.Visible = true;
                }
                if (lookUpEdit物料编码1.Text != "" || lookUpEdit物料编码2.Text != "")
                {
                    buttonEdit物料编码1.Enabled = false;
                    buttonEdit物料编码2.Enabled = false;
                }
                else
                {
                    buttonEdit物料编码1.Enabled = true;
                    buttonEdit物料编码2.Enabled = true;
                }
                //GetGrid();
                //if (Flag == 1)
                //{
                //    string[] split = RdAutoIDList.Split('|');
                //    for (int i = 0; i < gridView1.RowCount; i++)
                //    {
                //        string AutoID = gridView1.GetRowCellValue(i, gridColAutoID).ToString();
                //        for (int j = 0; j < split.Length; j++)
                //        {
                //            string[] split_2 = split[j].Split(':');
                //            if (AutoID == split_2[0])
                //            {
                //                gridView1.SetRowCellValue(i, gridCol选择, "√");
                //                gridView1.SetRowCellValue(i, gridCol选中数量, split_2[5]);
                //            }
                //        }
                //    }
                //}
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败：" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void GetGrid()
        {
            if (lookUpEdit仓库.EditValue != null && lookUpEdit仓库.EditValue.ToString() == "")
            {
                throw new Exception("仓库不可为空");
            }
            if (type == 5)//成品出库
            {
                sSQL = @"select cast(0 as bit) as iChk,isnull(case when a.flag=1 then b.iQuantity else -b.iQuantity end,0)-isnull(b.iOutQuantity,0) as iQuantity, 
isnull(case when a.flag=1 then b.iNum else -b.iNum end,0)-isnull(b.iOutNum,0) as iNum,
sBoxQty-isnull(sOutBoxQty,0) as sBoxQty,   
b.iUnitPrice*(isnull(b.iQuantity,0)-isnull(b.iOutQuantity,0)) as iMoney,
b.iNatUnitPrice*(isnull(b.iQuantity,0)-isnull(b.iOutQuantity,0)) as iNatMoney,
a.ID, a.cRdCode, dDate, cPersonCode, cOperator, cDepCode, a.cWhCode, cCusCode, cVenCode,a.cRSCode,null as cMOCode,'' as iChk, b.AutoID,b.cInvCode,b.iNatTax, b.iTaxRate,b.iNatUnitPrice,
b.M1,b.M2,b.M3,b.M4,b.M5,b.M6,b.M7,b.M8,b.M9,b.M10,b.iChangRate, b.iUnitPrice,b.cPosCode,b.D1,b.D2,b.sBoxNo
,convert(decimal(18, 6),null) as chkQty ,convert(decimal(18, 6),null) as chkBoxQty 
,r.cRSName,i.cInvName,w.cWhName,p.cPosName
from RdRecord03 a left join RdRecords03 b on a.ID=b.ID 
left join RdStyle r on r.cRSCode=a.cRSCode 
left join Inventory i on b.cInvCode=i.cInvCode
left join Warehouse w on a.cWhCode=w.cWhCode
left join Position p on b.cPosCode=p.cPosCode
left join InventoryContrast ic on b.cInvCode=ic.cInvCode
where a.Flag=1 and isnull(b.iQuantity,0)-isnull(b.iOutQuantity,0)>0 and ic.cInvCode is not null
and isnull(b.sBoxQty,0)-isnull(b.sOutBoxQty,0)>0 
and a.dVerifysysPerson is not null and a.dClosesysPerson is null and 1=1 and a.cRSCode='0301'";
            }
            if (lookUpEdit单据号1.EditValue!=null && lookUpEdit单据号1.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cRdCode>='" + lookUpEdit单据号1.EditValue.ToString().Trim() + "'");
            }
            if (lookUpEdit单据号2.EditValue!=null && lookUpEdit单据号2.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cRdCode<='" + lookUpEdit单据号2.EditValue.ToString().Trim() + "'");
            }
            if (dateEdit单据日期1.EditValue!=null && dateEdit单据日期1.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and dDate='" + dateEdit单据日期1.EditValue.ToString().Trim() + "'");
            }
            if (dateEdit单据日期2.EditValue!=null && dateEdit单据日期2.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and dDate<='" + dateEdit单据日期2.EditValue.ToString().Trim() + "'");
            }
            if (buttonEdit物料编码1.EditValue != null && buttonEdit物料编码1.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and b.cInvCode>= '" + buttonEdit物料编码1.EditValue.ToString().Trim() + "'");
            }
            if (buttonEdit物料编码2.EditValue != null && buttonEdit物料编码2.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and b.cInvCode<= '" + buttonEdit物料编码2.EditValue.ToString().Trim() + "'");
            }
            if (textEdit色号.EditValue != null && textEdit色号.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and b.M1= '" + textEdit色号.EditValue.ToString().Trim() + "'");
            }
            if (textEdit缸号.EditValue != null && textEdit缸号.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and b.M2= '" + textEdit缸号.EditValue.ToString().Trim() + "'");
            }
            if (lookUpEdit仓库.EditValue != null && lookUpEdit仓库.EditValue.ToString() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cWhCode= '" + lookUpEdit仓库.EditValue.ToString() + "'");
            }
            if (dthas!=null && dthas.Rows.Count != 0)
            {
                string s = "";
                for (int i = 0; i < dthas.Rows.Count; i++)
                {
                    if (dthas.Rows[i]["RdAutoID"].ToString() != "")
                    {
                        if (s != "")
                        {
                            s = s + ",";
                        }
                        s = s + dthas.Rows[i]["RdAutoID"].ToString();
                    }
                }
                if (s.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.AutoID not in (" + s + ")");
                }
            }
            sSQL = sSQL + " order by  " + tablecode;
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
            系统服务.LookUp.Inventory(lookUpEdit物料编码1);
            系统服务.LookUp.Inventory(lookUpEdit物料编码2);

            //系统服务.LookUp.ColorNo(ItemLookUpEditM1);

            //系统服务.LookUp.Warehouse(ItemLookUpEdit仓库);
            //系统服务.LookUp.Position(ItemLookUpEdit货位);
            //系统服务.LookUp.RdStyle(ItemLookUpEdit出入库类别);
            //系统服务.LookUp.MOStyle(ItemLookUpEdit委外类别);

            //系统服务.LookUp.Inventory(ItemLookUpEdit物料名称);
            //ItemLookUpEdit物料名称.Properties.DisplayMember = "cInvName";
            //系统服务.LookUp.Inventory(ItemLookUpEdit物料规格);
            //ItemLookUpEdit物料规格.Properties.DisplayMember = "cInvStd";

            系统服务.LookUp.Warehouse(lookUpEdit仓库);
            
        }

        private void btnEnsure_Click(object sender, EventArgs e)
        {
            string sErr = "";
            cWhCode = lookUpEdit仓库.EditValue.ToString();
            if (dt != null)
            {
                if (Flag == 1)
                {
                    dt = new DataTable();
                    dt.Columns.Add("cPosCode");
                    dt.Columns.Add("cInvCode");
                    dt.Columns.Add("M1");
                    dt.Columns.Add("M2");
                    dt.Columns.Add("sBoxNo");
                    dt.Columns.Add("iQuantity",typeof(decimal));
                    dt.Columns.Add("sBoxQty", typeof(decimal));
                    dt.Columns.Add("chkQty", typeof(decimal));
                    dt.Columns.Add("chkBoxQty", typeof(decimal));
                    dt.Columns.Add("AutoID", typeof(long));

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridCol选择).ToString()))
                        {
                            DataRow dw = dt.NewRow();

                            dw["cPosCode"] = gridView1.GetRowCellValue(i, gridCol货位);
                            dw["cInvCode"] = gridView1.GetRowCellValue(i, gridCol物料编码);
                            dw["sBoxNo"] = gridView1.GetRowCellValue(i, gridCol盒号);
                            dw["M1"] = gridView1.GetRowCellValue(i, gridColM1);
                            dw["M2"] = gridView1.GetRowCellValue(i, gridColM2);
                            dw["iQuantity"] = gridView1.GetRowCellValue(i, gridCol数量);
                            dw["sBoxQty"] = gridView1.GetRowCellValue(i, gridCol盒数);
                            dw["chkQty"] = gridView1.GetRowCellValue(i, gridCol选中数量);
                            dw["chkBoxQty"] = gridView1.GetRowCellValue(i, gridCol选中盒数);
                            dw["AutoID"] = gridView1.GetRowCellValue(i, gridColAutoID);

                            dt.Rows.Add(dw);
                        }
                    }
                }
            }
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("请至少选择一张单据");
                GetGrid();
            }
            else if (sErr != "")
            {
                MessageBox.Show(sErr);
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
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

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView1.FocusedRowHandle >= 0)
                {
                    iRow = gridView1.FocusedRowHandle;
                }
                if (e.Column == gridCol选中盒数)
                {
                    //decimal d选中盒数 = 0;
                    //if (gridView1.GetRowCellValue(iRow, gridCol选中盒数) != null)
                    //{
                    //    d选中盒数 = clsPublic.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol选中盒数).ToString());
                    //}
                    //decimal d选中数量 = 0;
                    //if (gridView1.GetRowCellValue(iRow, gridCol选中数量) != null)
                    //{
                    //    d选中数量 = clsPublic.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol选中数量).ToString());
                    //}
                    //decimal d数量 = 0;
                    //if (gridView1.GetRowCellValue(iRow, gridCol数量) != null)
                    //{
                    //    d数量 = clsPublic.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol数量).ToString());
                    //}
                    //decimal d盒数 = 0;
                    //if (gridView1.GetRowCellValue(iRow, gridCol盒数) != null)
                    //{
                    //    d盒数 = clsPublic.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol盒数).ToString());
                    //}

                    //decimal new选中数量 = d选中盒数 * d数量 / d盒数;
                    //if (new选中数量 == 0)
                    //{
                    //    gridView1.SetRowCellValue(iRow, gridCol选中数量, null);
                    //}
                    //else
                    //{
                    //    gridView1.SetRowCellValue(iRow, gridCol选中数量, new选中数量);
                    //}
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }


        //private void gridView1_DoubleClick(object sender, EventArgs e)
        //{
            
        //    if (Flag == 0)
        //    {
        //        for (int i = 0; i < gridView1.RowCount; i++)
        //        {
        //            if (gridView1.IsRowSelected(i))
        //            {
        //                if (gridView1.GetRowCellValue(i, gridCol选择).ToString() == "")
        //                {
        //                    gridView1.SetRowCellValue(i, gridCol选择, "√");
        //                }
        //                else
        //                {
        //                    gridView1.SetRowCellValue(i, gridCol选择, "");
        //                }
        //            }
        //        }
        //        //单选
        //        for (int i = 0; i < gridView1.RowCount; i++)
        //        {
        //            if (gridView1.IsRowSelected(i) == false)
        //            {
        //                gridView1.SetRowCellValue(i, gridCol选择, "");
        //            }
        //        }
        //    }
        //    else if (Flag == 1)
        //    {
        //        decimal tmpQty = 0;
        //        for (int i = 0; i < gridView1.RowCount; i++)
        //        {
        //            if (gridView1.IsRowSelected(i))
        //            {
        //                gridView1.SetRowCellValue(i, gridCol选中数量, clsPublic.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol数量).ToString()));
        //                tmpQty = tmpQty + clsPublic.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol选中数量).ToString());
        //                gridView1.SetRowCellValue(i, gridCol选择, "√");
        //            }
        //            else if (gridView1.IsRowSelected(i)!=true)
        //            {
        //                tmpQty = tmpQty + clsPublic.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol选中数量).ToString());
        //            }
        //        }
        //        if (tmpQty > MaxQty)
        //        {
        //            MessageBox.Show("引用数量超过最大数量，最大" + MaxQty);
        //        }
        //    }
        //    else if (Flag == 2)
        //    {
        //        decimal tmpQty = 0;
        //        for (int i = 0; i < gridView1.RowCount; i++)
        //        {
        //            if (gridView1.IsRowSelected(i))
        //            {
        //                gridView1.SetRowCellValue(i, gridCol选中数量, clsPublic.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol数量).ToString()));
        //                tmpQty = tmpQty + clsPublic.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol选中数量).ToString());
        //                gridView1.SetRowCellValue(i, gridCol选择, "√");
        //            }
        //            if (gridView1.GetRowCellValue(i, gridCol选择).ToString() == "√")
        //            {
        //                tmpQty = tmpQty + clsPublic.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol选中数量).ToString());
        //            }
        //        }
        //    }

        //}

        private void buttonClear_Click(object sender, EventArgs e)
        {
            lookUpEdit单据号1.EditValue = "";
            lookUpEdit单据号2.EditValue = "";
            buttonEdit物料编码1.EditValue = "";
            buttonEdit物料编码2.EditValue = "";
            lookUpEdit物料编码1.EditValue = "";
            lookUpEdit物料编码2.EditValue = "";
            gridControl1.DataSource = null;
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

        private void ItemCheckEdit选择_CheckedChanged(object sender, EventArgs e)
        {
            int iRow = gridView1.FocusedRowHandle;
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            if (Flag == 0)
            {
                
            }
            else if (Flag == 1)
            {
                decimal d选中盒数 = clsPublic.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol盒数).ToString());
                decimal d数量 = clsPublic.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol数量).ToString());
                decimal d盒数 = clsPublic.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol盒数).ToString());

                decimal new选中数量 = d选中盒数 * d数量 / d盒数;
                if (Convert.ToBoolean(gridView1.GetRowCellValue(iRow, gridCol选择)))
                {
                    gridView1.SetRowCellValue(iRow, gridCol选中盒数, d选中盒数);
                    gridView1.SetRowCellValue(iRow, gridCol选中数量, new选中数量);
                }
                else
                {
                    gridView1.SetRowCellValue(iRow, gridCol选中盒数, null);
                    gridView1.SetRowCellValue(iRow, gridCol选中数量, null);
                }
            }
        }

        private void checkEditChk_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                gridView1.SetRowCellValue(i, gridCol选择, checkEditChk.Checked);
            }
        }

    }
}
