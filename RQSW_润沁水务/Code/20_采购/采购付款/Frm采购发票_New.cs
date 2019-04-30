using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 采购
{
    public partial class Frm采购发票_New : Form
    {
        string tablename = "PurBillVouch";
        string tableid = "ID";
        string tablenames = "PurBillVouchs";
        string tableids = "AutoID";

        protected 系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
        protected 系统服务.ClsGetSQL clsGetSQL = 系统服务.ClsGetSQL.Instance();
        public string 供应商;
        public string 红蓝标志;
        public DataTable dt;
        DataTable dthas;
        public Frm采购发票_New(DataTable sdthas)
        {
           
            InitializeComponent();
            dthas = sdthas;
        }

        public Frm采购发票_New()
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

        private void Frm采购发票_New_Load(object sender, EventArgs e)
        {
            try
            {
                radioGroup蓝红标识.EditValue = "1";
                if (供应商.Trim() != "")
                {
                    buttonEdit供应商.EditValue = 供应商;
                    buttonEdit供应商.Enabled = false;
                }
                else
                {
                    buttonEdit供应商.Enabled = true;
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
            if (供应商.Trim() == "")
                return;

            string sSQL = "";
            if (radioGroup蓝红标识.EditValue.ToString() == "1")
            {
                sSQL = " select cast('' as varchar(2)) as iChk,2 as iType, a.ID,b.AutoID,a.cPBVCode,a.dDate,a.cPersonCode,a.cDepCode,a.cVenCode,a.cVouchType,a.cPayCode," +
                            "sum(b.iMoney) as iMoney,sum(b.iNatMoney) as iNatMoney,isnull(sum(b.iMoney),0) - isnull(c.付款金额,0) as 付款金额,e.cPOCode  " +
                       "from PurBillVouch a inner join PurBillVouchs b on a.id = b.id left join RdRecords r on b.RdRecordPOAutoID=r.AutoID left join (select b.cPBVAutoID,isnull(sum(付款金额),0) as 付款金额 from PO_CloseBill a inner join PO_CloseBillDetails b on a.id = b.id where iType=2 group by b.cPBVAutoID) c on c.cPBVAutoID=b.AutoID " +
                       " left join PO_PODetails d on r.POAutoID=d.AutoID left join PO_POMain e on d.ID=e.ID " +
                       "where 1=1 and a.dVerifysysPerson is not null and a.dClosesysPerson is null and b.cClosesysPerson is null and a.cVenCode='" + 供应商.Trim() + "'"+
                        " group by a.ID,b.AutoID,a.cPBVCode,a.dDate,a.cPersonCode,a.cDepCode,a.cVenCode,a.cVouchType,a.cPayCode,a.cexch_name,a.Flag,a.cMemo,a.dCreatesysPerson,a.dCreatesysTime,a.dVerifysysPerson,a.dVerifysysTime,a.dClosesysPerson,a.dClosesysTime,a.dChangeVerifyPerson,a.dChangeVerifyTime,c.付款金额,e.cPOCode " +
                        "having sum(b.iMoney) - isnull(c.付款金额,0) >0  " +
                        " union all select cast('' as varchar(2)) as iChk,1 as iType,a.iID,a.iID as AutoID,cast (a.iID as varchar(50)) as cTypeCode,a.Date1,null,a.S3,a.S1,null,null,sum(a.D1),sum(a.D1),sum(a.D1)-isnull(sum(c.付款金额),0) as 付款金额,null from AP_First a 	 " +
                       " left join (select isnull(sum(付款金额),0) as 付款金额,cVenCode,cPBVCode as cTypeCode from PO_CloseBill a inner join PO_CloseBillDetails b on a.id = b.id  where iType=1 " +
                        "group by cVenCode,cPBVCode) c on c.cVenCode = a.s1 and cast (a.iID as nvarchar(50))=c.cTypeCode where a.S1 = '" + 供应商.Trim() + "'  " +
                        "group by a.iID,a.Date1,a.S1,a.S3,c.付款金额 having  sum(a.D1)-isnull(sum(c.付款金额),0)>0";
                
            }
            if (radioGroup蓝红标识.EditValue.ToString() == "2")
            {

            }

            #region 去除已经选择的
            if (dthas.Rows.Count != 0)
            {
                string s = "";
                for (int i = 0; i < dthas.Rows.Count; i++)
                {
                    if (dthas.Rows[i].RowState == DataRowState.Deleted)
                        continue;

                    if (dthas.Rows[i]["cPBVCode"].ToString() != "")
                    {
                        if (s != "")
                        {
                            s = s + ",";
                        }
                        s = s + "'" + dthas.Rows[i]["cPBVCode"].ToString().Trim() + "'";
                    }
                }
                if (s.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", " a.cPBVCode not in (" + s + ")");
                }
            }
            #endregion


            sSQL = sSQL + " order by  a." + tableid;

            dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;
        }

        public void Get(string 单据号1, string 单据号2, string 单据日期1, string 单据日期2,string 制单日期1,string 制单日期2,string 业务员,
            string 部门, string 供应商1, string 供应商2, string 审核日期1, string 审核日期2, string 制单人1, string 制单人2, string 审核人1, string 审核人2)
        {
            //lookUpEdit单据号1.EditValue = 单据号1;
            //lookUpEdit单据号2.EditValue = 单据号2;
            //if (单据日期1 != null && 单据日期1 != "")
            //{
            //    单据日期1 = DateTime.Parse(单据日期1).ToString("yyyy-MM-dd");
            //    dateEdit单据日期1.EditValue = 单据日期1;
            //}
            //if (单据日期2 != null && 单据日期2 != "")
            //{
            //    单据日期2 = DateTime.Parse(单据日期2).ToString("yyyy-MM-dd");
            //    dateEdit单据日期2.EditValue = 单据日期2;
            //}
        }

        private void SetLookUpEdit()
        {
            //DataTable dt = 系统服务.LookUp.PurBillVouch();
            //lookUpEdit单据号1.Properties.DataSource = dt;
            //lookUpEdit单据号2.Properties.DataSource = dt;

            DataTable dtinv=系统服务.LookUp.Inventory();

            系统服务.LookUp.Vendor(lookUpEdit供应商);
            系统服务.LookUp.Vendor(ItemLookUpEdit供应商);

            系统服务.LookUp.Person(ItemLookUpEdit业务员);
            系统服务.LookUp.Department(ItemLookUpEdit部门);
            系统服务.LookUp._LoopUpData(ItemLookUpEdit来源类型, "24");
            系统服务.LookUp.PO_POMain(ItemLookUpEdit采购订单号);
        }

        private void btnEnsure_Click(object sender, EventArgs e)
        {
            for (int i = dt.Rows.Count-1; i >=0; i--)
            {
                if (dt.Rows[i]["iChk"] != "√")
                {
                    dt.Rows.Remove(dt.Rows[i]);
                }
            }
            红蓝标志 = radioGroup蓝红标识.EditValue.ToString().Trim();
            供应商 = lookUpEdit供应商.EditValue.ToString().Trim();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void button查询_Click(object sender, EventArgs e)
        {
            try
            {
                if (lookUpEdit供应商.Text.Trim() == "")
                {
                    throw new Exception("请选择供应商");
                }
                else
                {
                    供应商 = lookUpEdit供应商.EditValue.ToString().Trim();
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
            }
        }

        private void buttonEdit供应商_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit供应商.Text.Trim() != "")
                lookUpEdit供应商.EditValue = buttonEdit供应商.Text.Trim();
            else
                lookUpEdit供应商.EditValue = null;
        }

        private void buttonEdit供应商_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(10);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit供应商.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit供应商_Leave(object sender, EventArgs e)
        {
            if (buttonEdit供应商.Text.Trim() == "")
                return;
            if (lookUpEdit供应商.Text.Trim() == "")
            {
                buttonEdit供应商.Text = "";
                buttonEdit供应商.Focus();
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
    }
}
