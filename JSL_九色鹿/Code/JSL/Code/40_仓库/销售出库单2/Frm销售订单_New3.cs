﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 仓库
{
    public partial class Frm销售订单_New3 : Form
    {
        string tablename = "SO_SOMain";
        string tableid = "cSoCode";
        string tablenames = "SO_SODetails";
        string tableids = "AutoID";
        string cRsCode="";

        protected 系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
        protected 系统服务.ClsGetSQL clsGetSQL = 系统服务.ClsGetSQL.Instance();
        protected 系统服务.公共调用 clsPublic = new 系统服务.公共调用();
        public string 红蓝标志;
        public string 客户;
        public DataTable dt;
        DataTable dthas;
        public string 销售订单号;
        public Frm销售订单_New3(string s客户, DataTable sdthas, string s销售订单号, string s红蓝标志, string scRsCode)
        {
           
            InitializeComponent();
            客户 = s客户;
            销售订单号 = s销售订单号;
            红蓝标志 = s红蓝标志;
            dthas = sdthas;
            cRsCode = scRsCode;
            lookUpEdit单据号1.EditValue = null;
            lookUpEdit单据号2.EditValue = null;
        }

        public Frm销售订单_New3()
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

        private void Frm销售订单_New3_Load(object sender, EventArgs e)
        {
            try
            {
                if (客户.Trim() != "")
                {
                    buttonEdit客户.EditValue = 客户;
                    buttonEdit客户.Enabled = false;
                }
                else
                {
                    buttonEdit客户.Enabled = true;
                }
                if (红蓝标志.Trim() != "")
                {
                    radioGroup蓝红标识.EditValue = 红蓝标志;
                    radioGroup蓝红标识.Enabled = false;
                }
                else
                {
                    radioGroup蓝红标识.EditValue = "1";
                    radioGroup蓝红标识.Enabled = true;
                }
                SetLookUpEdit();
                lookUpEdit单据号1.EditValue = null;
                lookUpEdit单据号2.EditValue = null;
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败：" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void GetGrid()
        {
            if (客户.Trim() == "" && radioGroup蓝红标识.EditValue.ToString().Trim()!="")
                return;

            string sSQL = "";
            if (radioGroup蓝红标识.EditValue.ToString().Trim() == "1")
            {
                sSQL = @"
select a.*,'' as RdAutoID,'' as cPosCode,'' as cWhCode,'' as iChk, cClosesysPerson,cClosesysTime,b.AutoID,b.M1,b.M2,b.M3,b.M4,b.M5,b.M6,b.M7,b.M8,b.M9,b.M10,a.DD1,a.dPerVerifysysPerson,b.D2,b.D1,
    b.cInvCode,isnull(b.iQuantity,0)-isnull(b.iOutQuantity,0) as iQuantity,isnull(b.sBoxQty,0)-isnull(b.sOutBoxQty,0) as sBoxQty, isnull(b.iNum,0)-isnull(b.iOutNum,0) as iNum, b.iNatTax, b.iTaxRate, b.iChangRate, b.iUnitPrice, isnull(b.iUnitPrice,0)*(isnull(b.iQuantity,0)-isnull(b.iOutQuantity,0)) as iMoney, b.iNatUnitPrice, isnull(b.iNatUnitPrice,0)*(isnull(b.iQuantity,0)-isnull(b.iOutQuantity,0)) as  iNatMoney 
from dbo." + tablename + " a left join " + tablenames + " b on a.ID=b.ID  "
                + " where isnull(b.iQuantity,0)-isnull(b.iOutQuantity,0)>0 and a.dVerifysysPerson is not null and a.dClosesysPerson is null and b.cClosesysPerson is null and cCusCode='" + 客户 + "' ";
            }
            if (radioGroup蓝红标识.EditValue.ToString().Trim() == "2")
            {
                sSQL = @"
select a.*,'' as iChk,b.AutoID,b.M1,b.M2,b.M3,b.M4,b.M5,b.M6,b.M7,b.M8,b.M9,b.M10,a.DD1,a.dPerVerifysysPerson,-isnull(f.sBoxQty,0)-isnull(f.sOutBoxQty,0) as sBoxQty,
    b.D2 as D2,b.D1 as D1,b.cInvCode,-isnull(f.iQuantity,0)-isnull(f.iOutQuantity,0) as iQuantity,-isnull(f.iNum,0)-isnull(f.iOutNum,0) as iNum, b.iNatTax, b.iTaxRate, b.iChangRate, b.iUnitPrice, 
isnull(b.iUnitPrice*-isnull(f.iQuantity,0)-isnull(f.iOutQuantity,0),0) as iMoney,b.iNatUnitPrice, isnull(b.iNatUnitPrice*(-isnull(f.iQuantity,0)-isnull(f.iOutQuantity,0)),0) as  iNatMoney,'' as cWhCode,'' as cPosCode ,f.AutoID as RdAutoID 
from dbo.SO_SOMain a left join SO_SODetails b on a.ID=b.ID  left join RdRecords11 f on b.AutoID=f.SoAutoID
where -isnull(f.iQuantity,0)-isnull(f.iOutQuantity,0)<0 and isnull(f.iQuantity,0)>0  and a.dVerifysysPerson is not null and a.dClosesysPerson is null 
    and b.cClosesysPerson is null and cCusCode='" + 客户 + "' ";
            }
            if(cRsCode=="1101")
            {
                sSQL = sSQL + " and cSTCode in('01','02')";
            }
            else if (cRsCode == "1102")
            {
                sSQL = sSQL + " and cSTCode='03' ";
            }
            if (lookUpEdit单据号1.EditValue!=null && lookUpEdit单据号1.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and a.cSoCode>='" + lookUpEdit单据号1.EditValue.ToString().Trim() + "'";
            }
            if (lookUpEdit单据号2.EditValue!=null && lookUpEdit单据号2.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and a.cSoCode<='" + lookUpEdit单据号2.EditValue.ToString().Trim() + "'";
            }
            if (dateEdit单据日期1.EditValue!=null && dateEdit单据日期1.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and dDate='" + dateEdit单据日期1.EditValue.ToString().Trim() + "'";
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
            //if (dthas.Rows.Count != 0)
            //{ 
            //    string s = "";
            //    for (int i = 0; i < dthas.Rows.Count; i++)
            //    {
            //        if (dthas.Rows[i]["SoAutoID"].ToString() != "")
            //        {
            //            if (s != "")
            //            {
            //                s = s + ",";
            //            }
            //            s = s + dthas.Rows[i]["SoAutoID"].ToString();
            //        }
            //    }
            //    if (s.Trim() != "")
            //    {
            //        sSQL = sSQL + " and b.AutoID not in (" + s + ")";
            //    }
            //}
            sSQL = sSQL + " order by  a." + tableid;
            
            dt = clsSQLCommond.ExecQuery(sSQL);
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                decimal iqty = decimal.Parse(dt.Rows[i]["iQuantity"].ToString());
                decimal sbox = 0;
                if (dt.Rows[i]["sBoxQty"].ToString() != "")
                    sbox = decimal.Parse(dt.Rows[i]["sBoxQty"].ToString());
                decimal ioutqty = 0;
                decimal soutbox = 0;

                for (int j = 0; j < dthas.Rows.Count-1; j++)
                {
                    if (dthas.Rows[j]["cInvCode"].ToString() != "")
                    {
                        if (dthas.Rows[j]["SoAutoID"].ToString() == dt.Rows[i]["AutoID"].ToString())
                        {
                            ioutqty = ioutqty + decimal.Parse(dthas.Rows[j]["iQuantity"].ToString());

                            if (dthas.Rows[j]["sBoxQty"].ToString() == "")
                                soutbox = 0;
                            else
                                soutbox = soutbox + decimal.Parse(dthas.Rows[j]["sBoxQty"].ToString());
                        }
                    }
                }

                if (radioGroup蓝红标识.EditValue.ToString().Trim() == "1")
                {
                    if (iqty - ioutqty > 0 || sbox - soutbox > 0)
                    {
                        dt.Rows[i]["iQuantity"] = iqty - ioutqty;
                        dt.Rows[i]["sBoxQty"] = sbox - soutbox;
                    }
                    else
                    {
                        dt.Rows.Remove(dt.Rows[i]);
                    }
                }

                if (radioGroup蓝红标识.EditValue.ToString().Trim() == "2")
                {
                    if (iqty - ioutqty < 0 || sbox - soutbox < 0)
                    {
                        dt.Rows[i]["iQuantity"] = iqty - ioutqty;
                        dt.Rows[i]["sBoxQty"] = sbox - soutbox;
                    }
                    else
                    {
                        dt.Rows.Remove(dt.Rows[i]);
                    }
                }
            }
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
            系统服务.LookUp.SO_SOMain(lookUpEdit单据号1);
            系统服务.LookUp.SO_SOMain(lookUpEdit单据号2);
            系统服务.LookUp.Inventory(lookUpEdit物料编码1);
            系统服务.LookUp.Inventory(lookUpEdit物料编码2);
            系统服务.LookUp.Customer(lookUpEdit客户);

            系统服务.LookUp.ColorNo(ItemLookUpEditM1);

            系统服务.LookUp.Inventory(ItemLookUpEdit物料名称);
            ItemLookUpEdit物料名称.Properties.DisplayMember = "cInvName";
            系统服务.LookUp.Inventory(ItemLookUpEdit物料规格);
            ItemLookUpEdit物料规格.Properties.DisplayMember = "cInvStd";
        }

        private void btnEnsure_Click(object sender, EventArgs e)
        {
            string bCode = "";
            bool b = true;
            string cInvCode = "";
            string M1="";
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
                        cInvCode = dt.Rows[i]["cInvCode"].ToString();
                        M1 = dt.Rows[i]["M1"].ToString();
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
                红蓝标志 = radioGroup蓝红标识.EditValue.ToString().Trim();
                客户 = lookUpEdit客户.EditValue.ToString().Trim();
                
                if (销售订单号 != "")
                {
                    if (dt.Rows.Count > 0)
                    {
                        销售订单号 = dt.Rows[0]["cSoCode"].ToString();
                    }
                }

                if (b == true)
                {
                    int itype = 1;
                    if (cRsCode == "1101")//期初销售出库单
                    {
                        itype = 2;
                    }
                    //系统服务.Frm库存_New frm = new 系统服务.Frm库存_New(itype, cInvCode, M1);
                    //if (DialogResult.OK == frm.ShowDialog())
                    //{
                        
                    //    if (frm.RdAutoID != "")
                    //    {
                    //        dt.Rows[0]["RdAutoID"] = frm.RdAutoID;
                    //        dt.Rows[0]["M2"] = frm.M2;
                    //        dt.Rows[0]["cPosCode"] = frm.cPosCode;
                    //        dt.Rows[0]["cWhCode"] = frm.cWhCode;
                    //        if (clsPublic.ReturnDecimal(dt.Rows[0]["iQuantity"].ToString()) > frm.iQty)
                    //        {
                    //            dt.Rows[0]["iQuantity"] = frm.iQty;
                    //        }
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    //    }
                    //}
                    
                    
                }
                else
                {
                    MessageBox.Show("一张单据只能选择一张销售订单");
                }
            }
        }

        private void button查询_Click(object sender, EventArgs e)
        {
            try
            {
                if (lookUpEdit客户.Text.Trim() == "")
                {
                    throw new Exception("请选择客户");
                }
                else
                {
                    客户 = lookUpEdit客户.EditValue.ToString().Trim();
                    GetGrid();
                }
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
                //else
                //{
                //    gridView1.SetRowCellValue(i, gridCol选择, "");
                //}
            }
            //单选
            //for (int i = 0; i < gridView1.RowCount; i++)
            //{
            //    if (gridView1.IsRowSelected(i)==false)
            //    {
            //        gridView1.SetRowCellValue(i, gridCol选择, "");
            //    }
            //}
        }

        private void buttonEdit客户_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(9);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit客户.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit客户_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit客户.Text.Trim() != "")
                lookUpEdit客户.EditValue = buttonEdit客户.Text.Trim();
            else
                lookUpEdit客户.EditValue = null;
        }

        private void buttonEdit客户_Leave(object sender, EventArgs e)
        {
            if (buttonEdit客户.Text.Trim() == "")
                return;
            if (lookUpEdit客户.Text.Trim() == "")
            {
                buttonEdit客户.Text = "";
                buttonEdit客户.Focus();
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            lookUpEdit单据号1.EditValue = "";
            lookUpEdit单据号2.EditValue = "";
            buttonEdit客户.EditValue = "";
            lookUpEdit客户.EditValue = "";
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

    }
}
