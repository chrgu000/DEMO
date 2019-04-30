using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 销售
{
    public partial class Frm销售订单_New : Form
    {
        string tablename = "SO_SOMain";
        string tableid = "cSoCode";
        string tablenames = "SO_SODetails";
        string tableids = "AutoID";

        protected 系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
        protected 系统服务.ClsGetSQL clsGetSQL = 系统服务.ClsGetSQL.Instance();
        public string 红蓝标志;
        public string 客户;
        public DataTable dt;
        DataTable dthas;
        public string 销售类型;
        public Frm销售订单_New(string s客户, string s红蓝标志, DataTable sdthas,string s销售类型)
        {
            InitializeComponent();

            客户 = s客户;
            buttonEdit客户.EditValue = 客户;
            红蓝标志 = s红蓝标志;
            销售类型 = s销售类型;
            dthas = sdthas;
        }

        public Frm销售订单_New()
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

        private void Frm销售订单_New_Load(object sender, EventArgs e)
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

                if (销售类型.Trim() != "")
                {
                    lookUpEdit销售类型.EditValue = 销售类型;
                    lookUpEdit销售类型.Enabled = false;
                }
                else
                {
                    lookUpEdit销售类型.Enabled = true;
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
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败：" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void GetGrid()
        {
            if (buttonEdit客户.Text.Trim() == "")
                return;
            if (lookUpEdit销售类型.EditValue.ToString().Trim() != "")
            {
                销售类型 = lookUpEdit销售类型.EditValue.ToString().Trim();
            }

            if (radioGroup蓝红标识.EditValue.ToString() == "1")
            {
                string sSQL = @"
select cast(null as varchar(1)) as iChk,*,isnull(iMoney,0) - isnull(iReMoney,0) as iReceiptMoney,AutoID as cSBVAutoID 
from 
                ( 
    select 2 as iType,a.cSOCode as cTypeCode,a.dDate,a.cCusCode,a.cPersonCode,a.cDepCode,a.ECode,a.cPayCode,a.iMoney,sum(c.iReMoney) as iReMoney,AutoID 
    from (
            select a.cSOCode,a.dDate,a.cCusCode,a.cPersonCode,a.cDepCode,a.ECode,a.cPayCode,sum(b.iMoney+isnull(r.iMoney,0)-isnull(f.iMoney,0)-isnull(h.iMoney,0))  as iMoney,a.cSTCode,b.AutoID 
            from view_SO_SOMain a inner join view_SO_SODetails b on a.id = b.id 
                left join (
                    select SoAutoID,sum(isnull(iQuantity,0)) as iQuantity,sum(isnull(iNum,0)) as iNum ,sum(isnull(iNatMoney,0)) as iNatMoney ,sum(isnull(iMoney,0)) as iMoney  from view_SO_SOReturns group by SoAutoID) r on b.AutoID=r.SoAutoID  
                left join (select sum(iQuantity) as iQuantity,sum(isnull(iMoney,0)) as iMoney,SoAutoID from view_RdRecord a inner join view_RdRecords b on a.id = b.id where a.cRSCode in ('05','06','07') group by SoAutoID) f on f.SoAutoID = b.AutoID 
                left join (select SoAutoID,sum(isnull(iMoney,0)) as iMoney  from view_SaleVerifications group by SoAutoID) h on b.AutoID=h.SoAutoID 
            where isnull(a.dVerifysysPerson,'') <> '' and isnull(a.dClosesysPerson,'') = ''   
            group by b.AutoID,a.cSOCode,a.dDate,a.cCusCode,a.cPersonCode,a.cDepCode,a.ECode,a.cPayCode,a.cSTCode
        ) a 
            left join (select sum(isnull(iMoneyNow,0)) as iReMoney,cCusCode,cTypeCode from view_SO_CloseBill a inner join view_SO_CloseBillDetails b on a.id = b.id group by cCusCode,cTypeCode) c on c.cCusCode = a.cCusCode and c.cTypeCode = a.cSOCode 
        where 1=1 
        group by a.cSOCode,a.dDate,a.cCusCode,a.cPersonCode,a.cDepCode,a.ECode,a.cPayCode,a.iMoney ,a.AutoID
        having sum(isnull(a.iMoney,0)) > sum(isnull(c.iReMoney,0))

                    union all 

            select 1 as iType,cast (a.iID as varchar(50)) as cTypeCode,a.Date1,a.S1,a.S3,null,null,null ,sum(a.D1),isnull(sum(c.iReMoney),0)+isnull(sum(d.iMoney),0) as iReMoney ,a.iID 
            from [SysDB_RQSW_2013_20170617]..AR_First a 
                left join (select sum(isnull(iMoneyNow,0)) as iReMoney,cCusCode,cTypeCode from view_SO_CloseBill a inner join view_SO_CloseBillDetails b on a.id = b.id group by cCusCode,cTypeCode) c on c.cCusCode = a.s1 and cast (a.iID as nvarchar(50))=c.cTypeCode 
                left join (select sum(iQuantity) as iQuantity,sum(isnull(iMoney,0)) as iMoney,ARiID from view_RdRecord a inner join view_RdRecords b on a.id = b.id where a.cRSCode in ('05','06','07') group by ARiID) d on d.ARiID = a.iID 
            where 2=2 
            group by a.iID,a.Date1,a.S1,a.S3 
            having sum(a.D1)-isnull(sum(c.iReMoney),0)-isnull(sum(d.iMoney),0)>0

 )a 
order by iType,dDate,cTypeCode";

                sSQL = sSQL.Replace("1=1", "a.cCusCode = '" + buttonEdit客户.Text.Trim() + "' and a.cSTCode='" + 销售类型 + "' ");
                sSQL = sSQL.Replace("2=2", "a.S1 = '" + buttonEdit客户.Text.Trim() + "' and a.S5 = '" + 销售类型 + "' ");

                dt = clsSQLCommond.ExecQuery(sSQL);

                if (dthas.Rows.Count != 0)
                {
                    for (int i = 0; i < dthas.Rows.Count; i++)
                    {
                        string sType = dthas.Rows[i]["iType"].ToString().Trim();
                        string sCode = dthas.Rows[i]["cTypeCode"].ToString().Trim();

                        for (int j = dt.Rows.Count - 1; j >= 0; j--)
                        {
                            if (sType == dt.Rows[j]["iType"].ToString().Trim() && sCode == dt.Rows[j]["cTypeCode"].ToString().Trim())
                            {
                                dt.Rows.RemoveAt(j);
                            }
                        }
                    }
                }
                gridControl1.DataSource = dt;
            }
            if (radioGroup蓝红标识.EditValue.ToString() == "2")
            {
                string sSQL = @"
select cast(null as varchar(1)) as iChk,*,-1*isnull(iReMoney,0) as iReceiptMoney from 
( 
    select 2 as iType,a.cSOCode as cTypeCode,a.dDate,a.cCusCode,a.cPersonCode,a.cDepCode,a.ECode,a.cPayCode,a.iMoney,sum(c.iReMoney) as iReMoney  
    from (
            select a.cSOCode,a.dDate,a.cCusCode,a.cPersonCode,a.cDepCode,a.ECode,a.cPayCode,sum(b.iMoney) as iMoney,a.cSTCode 
            from view_SO_SOMain a inner join view_SO_SODetails b on a.id = b.id where isnull(a.dVerifysysPerson,'') <> '' and isnull(a.dClosesysPerson,'') = ''  
            group by a.cSOCode,a.dDate,a.cCusCode,a.cPersonCode,a.cDepCode,a.ECode,a.cPayCode,a.cSTCode
        ) a  left join (
            select sum(isnull(iMoneyNow,0)) as iReMoney,cCusCode,cTypeCode 
            from view_SO_CloseBill a inner join view_SO_CloseBillDetails b on a.id = b.id group by cCusCode,cTypeCode) c on c.cCusCode = a.cCusCode and c.cTypeCode = a.cSOCode
            where a.cCusCode = 'bbbbbbbb'  and a.cSTCode='aaaaaaaa' 
            group by a.cSOCode,a.dDate,a.cCusCode,a.cPersonCode,a.cDepCode,a.ECode,a.cPayCode,a.iMoney 
            having sum(isnull(c.iReMoney,0)) >0 
            
            union all 

            select 1 as iType,cast (a.iID as varchar(50)) as cTypeCode,a.Date1,a.S1,a.S3,null,null,null,sum(a.D1),sum(c.iReMoney) as iReMoney 
            from [SysDB_RQSW_2013_20170617]..AR_First a
            	left join (select sum(isnull(iMoneyNow,0)) as iReMoney,cCusCode from view_SO_CloseBill a inner join view_SO_CloseBillDetails b on a.id = b.id group by cCusCode) c on c.cCusCode = a.s1 
            where a.S1 = 'bbbbbbbb' and a.S5 = 'aaaaaaaa'
            group by a.iID,a.Date1,a.S1,a.S3 
            having sum(isnull(c.iReMoney,0)) >0 
         )a 
order by iType,dDate,cTypeCode";

                                        sSQL = sSQL.Replace("aaaaaaaa",销售类型);
                                        sSQL = sSQL.Replace("bbbbbbbb",buttonEdit客户.Text.Trim());
                dt = clsSQLCommond.ExecQuery(sSQL);

                if (dthas.Rows.Count != 0)
                {
                    for (int i = 0; i < dthas.Rows.Count; i++)
                    {
                        string sType = dthas.Rows[i]["iType"].ToString().Trim();
                        string sCode = dthas.Rows[i]["cTypeCode"].ToString().Trim();

                        for (int j = dt.Rows.Count - 1; j >= 0; j--)
                        {
                            if (sType == dt.Rows[j]["iType"].ToString().Trim() && sCode == dt.Rows[j]["cTypeCode"].ToString().Trim())
                            {
                                dt.Rows.RemoveAt(j);
                            }
                        }
                    }
                }
                gridControl1.DataSource = dt;
            }
        }


        private void SetLookUpEdit()
        {
            系统服务.LookUp._LoopUpData(ItemLookUpEdit来源单据类型, "21");
            系统服务.LookUp.Customer(lookUpEdit客户);
            系统服务.LookUp.Person(ItemLookUpEdit业务员);
            系统服务.LookUp.Department(ItemLookUpEdit部门);
            系统服务.LookUp.SaleTypeSaleRoleCloseBill(lookUpEdit销售类型);
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
            客户 = lookUpEdit客户.EditValue.ToString().Trim();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void button查询_Click(object sender, EventArgs e)
        {
            try
            {
                if (lookUpEdit客户.Text.Trim() == "")
                {
                    throw new Exception("请选择客户");
                }
                else if (lookUpEdit销售类型.Text.Trim() == "")
                {
                    throw new Exception("请选择销售类型");
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
            int iRow = gridView1.FocusedRowHandle;

            if (gridView1.GetRowCellValue(iRow, gridCol选择).ToString().Trim() == "")
            {
                gridView1.SetRowCellValue(iRow, gridCol选择, "√");
            }
            else
            {
                gridView1.SetRowCellValue(iRow, gridCol选择, "");
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

        private void radioGroup蓝红标识_EditValueChanged(object sender, EventArgs e)
        {
            if (radioGroup蓝红标识.EditValue.ToString().Trim() == "1")
            {
                gridCol应收金额.Caption = "可收款金额";
                GetGrid();
            }
            if (radioGroup蓝红标识.EditValue.ToString().Trim() == "2")
            {
                gridCol应收金额.Caption = "可退款金额";
                GetGrid();
            }
        }
    }
}
