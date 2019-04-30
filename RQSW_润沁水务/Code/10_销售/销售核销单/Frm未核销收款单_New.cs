using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 销售
{
    public partial class Frm未核销收款单_New : Form
    {
        string tablename = "SO_SOMain";
        string tableid = "cSoCode";
        string tablenames = "SO_SODetails";
        string tableids = "AutoID";
        DataTable dt;

        public int 收款单ID = 0;
        public decimal 核销金额 = 0;
        public string 客户 = "";
        public string 销售类型 = "";
        public string iType = "";
        protected 系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
        protected 系统服务.ClsGetSQL clsGetSQL = 系统服务.ClsGetSQL.Instance();

        public Frm未核销收款单_New()
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

        private void 未核销收款单_New_Load(object sender, EventArgs e)
        {
            try
            {
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
            //if (客户.Trim() == "")
            //    return;
            string sSQL = "";
            sSQL = @"select '' as iChk,2 as iType ,a.ID,a.cSOCCode,a.dDate,cCusCode,a.cSTCode,a.cDepCode,cast(a.iAmount-isnull(b.iMoneyNow,0)-isnull(c.iAmount,0) as decimal(18, 6)) as iAmount 
from SO_CloseBill a 
            left join (select ID,SUM(iMoneyNow) as iMoneyNow from SO_CloseBillDetails group by ID) b on a.ID=b.ID 
            left join (select cTypeCode,sum(iAmount) as iAmount from SaleVerification where iType=2 group by cTypeCode) c on a.ID=c.cTypeCode
            where cast(a.iAmount-isnull(b.iMoneyNow,0)-isnull(c.iAmount,0) as decimal(18, 6))>0 and 1=1 and a.dVerifysysTime is not null 

union all 

select '' as iChk,1 as iType ,a.iID,cast(a.iID as nvarchar),a.Date1,a.S1,a.S5,a.S4,cast(-a.D1+isnull(b.iMoneyNow,0)-isnull(c.iAmount,0)-isnull(r.iMoney,0)+case when a.D1-b.iMoneyNow=0 then r.iMoney end  as decimal(18, 6)) as iAmount 
from AR_First a 
            left join (select cTypeCode,SUM(iMoneyNow) as iMoneyNow from SO_CloseBillDetails where iType=1 group by cTypeCode) b on a.iID=b.cTypeCode 
            left join (select cTypeCode,sum(iAmount) as iAmount from SaleVerification where iType=1 group by cTypeCode) c on a.iID=c.cTypeCode
left join (select ARiID,isnull(SUM(iMoney),0) as iMoney from RdRecord a left join RdRecords b on a.ID=b.ID left join RdStyle r on a.cRSCode=r.cRSCode  where r.S1=1 and B1=1 and a.dVerifysysTime is not null and 3=3 group by ARiID) r on a.iID=r.ARiID   
     
where cast(-a.D1+isnull(b.iMoneyNow,0)-isnull(c.iAmount,0)-isnull(r.iMoney,0)+case when a.D1-b.iMoneyNow=0 then r.iMoney end  as decimal(18, 2)) >0

union all 

select '' as iChk,3 as iType ,a.AutoID,b.cSOCCode,b.dDate,b.cCusCode,b.cSTCode,b.cDepCode,
cast(a.iMoneyNow-isnull(c.iMoney,0)-isnull(d.iMoney,0)-isnull(v.iAmount,0) as decimal(18, 6)) as iAmount 
from SO_CloseBillDetails a left join SO_CloseBill b on a.ID=b.ID 
left join (select AutoID,SUM(iMoney) as iMoney from SO_SODetails group by AutoID) c on a.cSBVAutoID=c.AutoID 
left join (select SoAutoID,SUM(iMoney) as iMoney from SO_SOReturns group by SoAutoID) d on a.cSBVAutoID=d.SoAutoID 
left join (select cTypeCode,sum(iAmount) as iAmount from SaleVerification where iType=3 group by cTypeCode) v on a.AutoID=v.cTypeCode
where 1=1 and b.dVerifysysTime is not null and cast(a.iMoneyNow-isnull(c.iMoney,0)-isnull(d.iMoney,0)-isnull(v.iAmount,0) as decimal(18, 6))>0  and a.iType='2'
";

            dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;
        }

        private void SetLookUpEdit()
        {
            系统服务.LookUp.Customer(ItemLookUpEdit客户);
            系统服务.LookUp.Department(ItemLookUpEdit部门);
            系统服务.LookUp.Person(ItemLookUpEdit业务员);
            系统服务.LookUp.SaleTypeAll(ItemLookUpEdit销售类型);
            系统服务.LookUp._LoopUpData(ItemLookUpEdit来源类型, "26");
        }

        private void btnEnsure_Click(object sender, EventArgs e)
        {
            try
            {
                int b = 0;
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    if (dt.Rows[i]["iChk"].ToString() != "√")
                    {
                        dt.Rows.Remove(dt.Rows[i]);
                    }
                    else
                    {
                        b = b+1;
                        收款单ID = Convert.ToInt32(dt.Rows[i]["ID"].ToString());
                        核销金额 = decimal.Parse(dt.Rows[i]["iAmount"].ToString());
                        客户 = dt.Rows[i]["cCusCode"].ToString();
                        销售类型 = dt.Rows[i]["cSTCode"].ToString();
                        iType = dt.Rows[i]["iType"].ToString();
                    }

                }
                if (b == 1)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("请选择一张收款单并且只选择一张收款单进行核销");
                }
                
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }

        //private void button查询_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (lookUpEdit客户.Text.Trim() == "")
        //        {
        //            //throw new Exception("请选择客户");
        //        }
        //        else
        //        {
        //            客户 = lookUpEdit客户.EditValue.ToString().Trim();
                    
        //        }

        //        GetGrid();
        //    }
        //    catch (Exception ee)
        //    {
        //        MessageBox.Show(ee.Message);
        //    }
        //}

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
