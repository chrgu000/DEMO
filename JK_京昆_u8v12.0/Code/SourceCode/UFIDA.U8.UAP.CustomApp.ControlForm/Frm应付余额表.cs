using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyXtraTreeList;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class Frm应付余额表 : UserControl
    {
        //public class CmbDataSource
        //{
        //    public string WareHouseCode;
        //    public string WareHouseName;
        //}

        //public class UserMsg
        //{
        //    public string UserCode;
        //    public string UserName;
        //}
        int id;

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        public Frm应付余额表()
        {
            InitializeComponent();
        }


        private void Frm应付余额表_Load(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "";
                DataTable dt;
                DataRow dr;
                Cls时间锁 cls = new Cls时间锁();
                if (cls.bchk时间锁(Conn) == false)
                {
                    throw new Exception("加载数据失败");
                }

                LookUp.Inventory(Conn, lookUpEdit存货名称1);
                LookUp.Inventory(Conn, lookUpEdit存货名称2);
                LookUp.Vendor(Conn, lookUpEdit供应商名称);
                LookUp.Person(Conn, lookUpEdit采购员名称);
                LookUp.Department(Conn, lookUpEdit部门);
                LookUp.Warehouse(Conn, lookUpEdit仓库);

                btnRefresh_Click(null, null);
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败");
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                Cls时间锁 cls = new Cls时间锁();
                if (cls.bchk时间锁(Conn) == false)
                {
                    throw new Exception("加载数据失败");
                }
                string d1 = "";
                string d2 = "";
                if (rdo本月.Checked == true)
                {
                    d1 = (DateTime.Now.AddDays(1 - DateTime.Now.Day)).ToString("yyyy-MM-dd");
                    d2 = ((DateTime.Now.AddDays(1 - DateTime.Now.Day)).AddMonths(1).AddDays(-1)).ToString("yyyy-MM-dd");
                }
                else if (rdo本季.Checked == true)
                {
                    d1 = (DateTime.Now.AddMonths(0 - (DateTime.Now.Month - 1) % 3).AddDays(1 - DateTime.Now.Day)).ToString("yyyy-MM-dd");
                    d2 = (DateTime.Now.AddMonths(0 - (DateTime.Now.Month - 1) % 3).AddDays(1 - DateTime.Now.Day)).AddMonths(3).AddDays(-1).ToString("yyyy-MM-dd");
                }
                else
                {
                    d1 = (new DateTime(DateTime.Now.Year, 1, 1)).ToString("yyyy-MM-dd");
                    d2 = (new DateTime(DateTime.Now.Year, 12, 31)).ToString("yyyy-MM-dd");
                }

                string sSQL = @"
Create Table #a (cDwCode nvarchar(20),cDwName nvarchar(120),cDwAbbName nvarchar(120),cDeptCode nvarchar(20),cDepName nvarchar(255),cPerson nvarchar(20), cPersonName nvarchar(120), cInvCode nvarchar(60), cInvName nvarchar(255),cInvStd nvarchar(255),cDwCCode nvarchar(20),cDWCName nvarchar(120),cDwDCode nvarchar(20),cDCName nvarchar(120),cHDwCode nvarchar(20),cHDwName nvarchar(120),cHDptCode nvarchar(20),cHDepName nvarchar(120),cHPsnCode nvarchar(20),cHPersonName nvarchar(120),cInvCCode nvarchar(20),cInvCName nvarchar(120),cCode nvarchar(60),cCode_Name nvarchar(120),cItem_Class nvarchar(2),cItem_Name nvarchar(60),cItemCode nvarchar(60),cItemName nvarchar(255),cContractType nvarchar(12),cContractTypeName nvarchar(40),cContractID nvarchar(64),cContractName nvarchar(400),cCusCreditCompany nvarchar(20),cCusCreditName nvarchar(120),iCreLine float,qc_f money,qc_s float,qc money,jf_f money,jf_s float,jf money,df_f money,df_s float,df money,jf_f2 money,jf_s2 float,jf2 money,df_f2 money,df_s2 float,df2 money,ye_f money,ye_s float,ye money,turnrate_f float,turnrate float,turndays_f float,turndays float,csysid nvarchar(2)
,cCheckMan nvarchar(50)
,本期采购入库未入库数量 decimal(18,2),本期采购入库未入库金额 money,期初采购入库未入库数量  decimal(18,2),期初采购入库未入库金额 money,期末采购入库未入库数量  decimal(18,2),期末采购入库未入库金额 money
,本期采购发票数量  decimal(18,2),本期采购发票金额 money)
insert into #a(ccode,ccode_name,ccontractid,ccontractname,ccontracttype,ccontracttypename,cdwdcode,cdcname,cdeptcode,cdepname,cdwccode,cdwcname,cdwcode,cdwname,cdwabbname,chdptcode,chdepname,chdwcode,chdwname,chpsncode,chpersonname,cinvccode,cinvcname,cinvcode,cinvname,cinvstd,citem_class,citem_name,citemcode,citemname,cperson,cpersonname,qc_f,qc_s,qc,jf_f,jf_s,jf,df_f,df_s,df,csysid) Select max(a.ccode),max(code.ccode_name),max(a.ccontractid),max(cm.strContractName),max(ccontracttype),max(cm_type.ctypename),max(cdwdcode),max(districtclass.cdcname),max(a.cdeptcode),max(department.cdepname),max(cdwccode),max(vendorclass.cvcname),max(cdwcode),max(cdwname) as cdwname,max(cdwabbname) as cdwabbname,max(chdptcode),max(department_1.cdepname),max(chdwcode),max(case when vendor_1.cvenname<>'' then vendor_1.cvenname else vendor_1.cvenabbname end),max(chpsncode),max(person_1.cpersonname),max(inventory.cinvccode),max(inventoryclass.cinvcname),max(a.cinvcode),max(inventory.cinvname),max(inventory.cinvstd),max(a.citem_class),max(fitem.citem_name),max(a.citemcode),max(a.citemname),max(a.cperson),max(person.cpersonname),SUM(case when  ((isnull(dcreditstart,dregdate)<'111111')) and a.cexch_name<>N'人民币' then iCAmount_f-iDAmount_f else 0 end) as qc_f,SUM(case when  ((isnull(dcreditstart,dregdate)<'111111')) and (ccovouchtype=cprocstyle Or cprocstyle='XJ')then iCAmount_s-iDAmount_s else 0 end) as qc_s,SUM(case when  ((isnull(dcreditstart,dregdate)<'111111')) then iCAmount-iDAmount else 0 end) as qc,SUM(case when  ((isnull(dCreditStart,dregdate)>='111111' and isnull(dCreditStart,dregdate)<='222222')) and a.cexch_name<>N'人民币' then iCAmount_f else 0 end) as jf_f,SUM(case when  ((isnull(dCreditStart,dregdate)>='111111' and isnull(dCreditStart,dregdate)<='222222')) and (ccovouchtype=cprocstyle Or cprocstyle='XJ') then iCAmount_s else 0 end) as jf_s,SUM(case when  ((isnull(dCreditStart,dregdate)>='111111' and isnull(dCreditStart,dregdate)<='222222')) then iCAmount else 0 end) as jf,SUM(case when  ((isnull(dCreditStart,dregdate)>='111111' and isnull(dCreditStart,dregdate)<='222222')) and a.cexch_name<>N'人民币' then iDAmount_f else 0 end) as df_f,SUM(case when  ((isnull(dCreditStart,dregdate)>='111111' and isnull(dCreditStart,dregdate)<='222222')) and ccovouchtype=cprocstyle then iDAmount_s else 0 end) as df_s,SUM(case when  ((isnull(dCreditStart,dregdate)>='111111' and isnull(dCreditStart,dregdate)<='222222')) then iDAmount else 0 end) as df,N'AP' 
From Ap_DetailVend_s  a with (nolock) LEFT JOIN gl_v_code code with (nolock) ON a.cCode=code.cCode Left Join vwCM_ContractForAPAR cm with (nolock) on a.cContractID=cm.strContractID LEFT join cm_type with (nolock) on a.cContractType=cm_type.ctypecode LEFT JOIN DistrictClass with (nolock) ON a.cdwdcode=DistrictClass.cDCCode LEFT JOIN Department with (nolock) ON a.cDeptCode = Department.cDepCode LEFT JOIN VendorClass with (nolock) ON a.cdwccode=VendorClass.cVCCode LEFT JOIN Department as Department_1 with (nolock) ON a.chdptcode=Department_1.cDepCode LEFT JOIN Vendor as Vendor_1 with (nolock) ON a.chdwcode=Vendor_1.cVenCode LEFT JOIN Person as Person_1 with (nolock) ON a.chpsncode=Person_1.cPersonCode  LEFT JOIN Inventory with (nolock) ON a.cInvCode = Inventory.cInvCode LEFT JOIN InventoryClass with (nolock) ON Inventory.cInvCCode=InventoryClass.cInvCCode  LEFT JOIN fitem with (nolock) ON a.cItem_Class=fitem.cItem_Class LEFT JOIN Person with (nolock) ON a.cPerson = Person.cPersonCode where  ((isnull(dcreditstart,dregdate)<='222222'))  and a.iflag<=2  Group by cdwcode

insert into #a(cDwCode,cDwName,期初采购入库未入库数量,期初采购入库未入库金额) 
select a.cVenCode,c.cVenName,sum(iQuantity-isnull(iSQuantity,0)) ,sum(iAPrice -isnull(iMoney,0)) from RdRecord01 a left join RdRecords01 b on a.ID=b.ID 
left join Vendor c on a.cVenCode=c.cVenCode where a.dDate<='111111' group by a.cVenCode,c.cVenName

insert into #a(cDwCode,cDwName,本期采购入库未入库数量,本期采购入库未入库金额) 
select a.cVenCode,c.cVenName,sum(iQuantity-isnull(iSQuantity,0)) ,sum(iAPrice -isnull(iMoney,0)) from RdRecord01 a left join RdRecords01 b on a.ID=b.ID 
left join Vendor c on a.cVenCode=c.cVenCode where a.dDate>='111111' and a.dDate<='222222' group by a.cVenCode,c.cVenName

insert into #a(cDwCode,cDwName,期末采购入库未入库数量,期末采购入库未入库金额) 
select a.cVenCode,c.cVenName,sum(iQuantity-isnull(iSQuantity,0)) ,sum(iAPrice -isnull(iMoney,0)) from RdRecord01 a left join RdRecords01 b on a.ID=b.ID 
left join Vendor c on a.cVenCode=c.cVenCode where a.dDate<='111111'  group by a.cVenCode,c.cVenName

insert into #a(cDwCode,cDwName,本期采购发票数量,本期采购发票金额) 
select a.cVenCode,c.cVenName,sum(iPBVQuantity) ,sum(iMoney) from PurBillVouch a left join PurBillVouchs b on a.PBVID =b.PBVID  
left join Vendor c on a.cVenCode=c.cVenCode where a.dPBVDate>='111111' and a.dPBVDate<='222222'  group by a.cVenCode,c.cVenName


select cDwCode,cDwName
,case when convert(decimal(18, 2),sum(qc))<>0 then convert(decimal(18, 2),sum(qc)) end as 期初余额金额
,case when convert(decimal(18, 2),sum(qc))<>0 then convert(decimal(18, 2),sum(qc_s)) end as 期初余额数量
,case when convert(decimal(18, 2),sum(jf))<>0 then convert(decimal(18, 2),sum(jf)) end as 本期应付
,case when convert(decimal(18, 2),sum(df))<>0 then convert(decimal(18, 2),sum(df)) end as 本期付款
,case when convert(decimal(18, 2),isnull(sum(qc),0)+isnull(sum(jf),0)-isnull(sum(df),0))<>0 then convert(decimal(18, 2),isnull(sum(qc),0)+isnull(sum(jf),0)-isnull(sum(df),0)) end as 期末余额

,case when convert(decimal(18, 2),sum(期初采购入库未入库数量))<>0 then convert(decimal(18, 2),sum(期初采购入库未入库数量)) end as 期初采购入库未入库数量 
,case when convert(decimal(18, 2),sum(期初采购入库未入库金额))<>0 then convert(decimal(18, 2),sum(期初采购入库未入库金额)) end as 期初采购入库未入库金额 

,case when convert(decimal(18, 2),sum(本期采购入库未入库数量))<>0 then convert(decimal(18, 2),sum(本期采购入库未入库数量)) end as 本期采购入库未入库数量 
,case when convert(decimal(18, 2),sum(本期采购入库未入库金额))<>0 then convert(decimal(18, 2),sum(本期采购入库未入库金额)) end as 本期采购入库未入库金额 

,case when convert(decimal(18, 2),sum(期末采购入库未入库数量))<>0 then convert(decimal(18, 2),sum(期末采购入库未入库数量)) end as 期末采购入库未入库数量 
,case when convert(decimal(18, 2),sum(期末采购入库未入库金额))<>0 then convert(decimal(18, 2),sum(期末采购入库未入库金额)) end as 期末采购入库未入库金额 

,case when convert(decimal(18, 2),sum(本期采购发票数量))<>0 then convert(decimal(18, 2),sum(本期采购发票数量)) end as 本期采购发票数量 
,case when convert(decimal(18, 2),sum(本期采购发票金额))<>0 then convert(decimal(18, 2),sum(本期采购发票金额)) end as 本期采购发票金额 

into #b
from #a where 2=2 group by cDwCode,cDwName

select * 
from #b 
";

                sSQL = sSQL.Replace("111111", d1);
                sSQL = sSQL.Replace("222222", d2);

                if (rdo审核.Checked == true)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(a.cCheckMan,'')<>''");
                }
                else
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(a.cCheckMan,'')=''");
                }

                if (lookUpEdit供应商名称.EditValue != null && lookUpEdit供应商名称.EditValue.ToString().Trim() != "")
                {
                    sSQL = sSQL.Replace("2=2", "2=2 and cDwCode='" + lookUpEdit供应商名称.EditValue.ToString().Trim() + "'");
                }
                
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                gridControl1.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                gridView1.PostEditor();
                this.Validate();

                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
                sF.Filter = "Excel文件(*.xls)|*.xls|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridControl1.ExportToXls(sF.FileName);
                    MessageBox.Show("导出Excel成功\n\t路径：" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("导出列表失败：" + ee.Message);
            }
        }

        private void buttonEdit供应商_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                FrmVenInfo frm = new FrmVenInfo(buttonEdit供应商.Text.ToString(), Conn, true);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    buttonEdit供应商.EditValue = frm.cVenCode;

                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }


        private void buttonEdit供应商_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit供应商.Text.Trim() != "")
                {
                    lookUpEdit供应商名称.EditValue = buttonEdit供应商.Text.Trim();
                }
                else
                {
                    lookUpEdit供应商名称.EditValue = null;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit供应商_Leave(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit供应商.Text.Trim() == "")
                    return;
                if (lookUpEdit供应商名称.Text.Trim() == "")
                {
                    buttonEdit供应商.Text = "";
                    buttonEdit供应商.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            string cVenCode = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridCol供应商编码).ToString().Trim();
            string d1 = "";
            string d2 = "";
            系统服务.规格化.ReturnDate(out d1, out d2, false, rdo本月.Checked, rdo本季.Checked, rdo本年.Checked);
            //入库单
            if (gridView1.FocusedColumn == gridCol本期采购入库未结算金额 || gridView1.FocusedColumn == gridCol本期采购入库未结算数量)
            {
                Frm明细多表头 frm = new Frm明细多表头(Conn);
                frm.应付账款采购入库在途(cVenCode, d1, d2);
                frm.Show();
            }
            else if (gridView1.FocusedColumn == gridCol期初采购入库未结算金额 || gridView1.FocusedColumn == gridCol期初采购入库未结算数量)
            {
                Frm明细多表头 frm = new Frm明细多表头(Conn);
                frm.应付账款采购入库在途(cVenCode, "", DateTime.Parse(d1).AddDays(-1).ToString("yyyy-MM-dd"));
                frm.Show();
            }
            else if (gridView1.FocusedColumn == gridCol期初采购入库未结算金额 || gridView1.FocusedColumn == gridCol期初采购入库未结算数量)
            {
                Frm明细多表头 frm = new Frm明细多表头(Conn);
                frm.应付账款采购入库在途(cVenCode, DateTime.Parse(d2).AddDays(1).ToString("yyyy-MM-dd"), "");
                frm.Show();
            }
            //订单
            else if (gridView1.FocusedColumn == gridCol本期采购订单未入库金额 || gridView1.FocusedColumn == gridCol本期采购订单未入库数量)
            {
                Frm明细多表头 frm = new Frm明细多表头(Conn);
                frm.应付账款采购订单在途(cVenCode, d1, d2);
                frm.Show();
            }
            else if (gridView1.FocusedColumn == gridCol期初采购订单未入库金额 || gridView1.FocusedColumn == gridCol期初采购订单未入库数量)
            {
                Frm明细多表头 frm = new Frm明细多表头(Conn);
                frm.应付账款采购订单在途(cVenCode, "", DateTime.Parse(d1).AddDays(-1).ToString("yyyy-MM-dd"));
                frm.Show();
            }
            else if (gridView1.FocusedColumn == gridCol期末采购订单未入库金额 || gridView1.FocusedColumn == gridCol期末采购订单未入库数量)
            {
                Frm明细多表头 frm = new Frm明细多表头(Conn);
                frm.应付账款采购订单在途(cVenCode, DateTime.Parse(d2).AddDays(1).ToString("yyyy-MM-dd"), "");
                frm.Show();
            }
            //发票
            else if (gridView1.FocusedColumn == gridCol本期采购发票金额 || gridView1.FocusedColumn == gridCol本期采购发票数量)
            {
                Frm明细多表头 frm = new Frm明细多表头(Conn);
                frm.应付账款采购发票(cVenCode, d1, d2);
                frm.Show();
            }
            //付款
            else if (gridView1.FocusedColumn == gridCol本期付款)
            {
                Frm明细多表头 frm = new Frm明细多表头(Conn);
                frm.应付账款采购付款(cVenCode, d1, d2);
                frm.Show();
            }
        }


    }
}