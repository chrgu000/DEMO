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
    public partial class Frm应收余额表 : UserControl
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

        public Frm应收余额表()
        {
            InitializeComponent();
        }


        private void Frm应收余额表_Load(object sender, EventArgs e)
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
                LookUp.Customer(Conn, lookUpEdit客户名称);
                LookUp.Person(Conn, lookUpEdit销售员名称);
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
,本期销售发货未入库数量 decimal(18,2),本期销售发货未入库金额 money,期初销售发货未入库数量  decimal(18,2),期初销售发货未入库金额 money,期末销售发货未入库数量  decimal(18,2),期末销售发货未入库金额 money
,本期销售发票数量  decimal(18,2),本期销售发票金额 money)

insert into #a(cCheckMan,ccode,ccode_name,ccontractid,ccontractname,ccontracttype,ccontracttypename,ccuscreditcompany,ccuscreditname,icreline,cdwdcode,cdcname,cdeptcode,cdepname,cdwccode,cdwcname,cdwcode,cdwname,cdwabbname,chdptcode,chdepname,chdwcode,chdwname,chpsncode,chpersonname,cinvccode,cinvcname,cinvcode,cinvname,cinvstd,citem_class,citem_name,citemcode,citemname,cperson,cpersonname,qc_f,qc_s,qc,jf_f,jf_s,jf,df_f,df_s,df,csysid) 
Select max(cCheckMan),max(a.ccode),max(code.ccode_name),max(a.ccontractid),max(cm.strContractName),max(ccontracttype),max(cm_type.ctypename),max(a.ccuscreditcompany),max(CASE WHEN Customer_2.cCusName<>'' THEN Customer_2.cCusName ELSE Customer_2.cCusAbbName END),max(a.icreline),max(cdwdcode),max(districtclass.cdcname),max(a.cdeptcode),max(department.cdepname),max(cdwccode),max(customerclass.cccname),max(cdwcode),max(cdwname) as cdwname,max(cdwabbname) as cdwabbname,max(chdptcode),max(department_1.cdepname),max(chdwcode),max(case when customer_1.ccusname<>'' then customer_1.ccusname else customer_1.ccusabbname end),max(chpsncode),max(person_1.cpersonname),max(inventory.cinvccode),max(inventoryclass.cinvcname),max(a.cinvcode),max(inventory.cinvname),max(inventory.cinvstd),max(a.citem_class),max(fitem.citem_name),max(a.citemcode),max(a.citemname),max(a.cperson),max(person.cpersonname),SUM(case when  ((isnull(dcreditstart,dregdate)<'111111')) and a.cexch_name<>N'人民币' then iDAmount_f-iCAmount_f else 0 end) as qc_f,SUM(case when  ((isnull(dcreditstart,dregdate)<'111111')) and (ccovouchtype=cprocstyle Or cprocstyle='XJ') then iDAmount_s-iCAmount_s else 0 end) as qc_s,SUM(case when  ((isnull(dcreditstart,dregdate)<'111111')) then iDAmount-iCAmount else 0 end) as qc,SUM(case when  ((isnull(dCreditStart,dregdate)>='111111' and isnull(dCreditStart,dregdate)<='222222')) and a.cexch_name<>N'人民币' then iDAmount_f else 0 end) as jf_f,SUM(case when  ((isnull(dCreditStart,dregdate)>='111111' and isnull(dCreditStart,dregdate)<='222222')) and (ccovouchtype=cprocstyle Or cprocstyle='XJ') then iDAmount_s else 0 end) as jf_s,SUM(case when  ((isnull(dCreditStart,dregdate)>='111111' and isnull(dCreditStart,dregdate)<='222222')) then iDAmount else 0 end) as jf,SUM(case when  ((isnull(dCreditStart,dregdate)>='111111' and isnull(dCreditStart,dregdate)<='222222')) and a.cexch_name<>N'人民币' then iCAmount_f else 0 end) as df_f,SUM(case when  ((isnull(dCreditStart,dregdate)>='111111' and isnull(dCreditStart,dregdate)<='222222')) and ccovouchtype=cprocstyle then iCAmount_s else 0 end) as df_s,SUM(case when  ((isnull(dCreditStart,dregdate)>='111111' and isnull(dCreditStart,dregdate)<='222222')) then iCAmount else 0 end) as df,N'AR' 
From Ar_DetailCust_s  a with (nolock) LEFT JOIN gl_v_code code with (nolock) ON a.cCode=code.cCode Left Join vwCM_ContractForAPAR cm with (nolock) on a.cContractID=cm.strContractID LEFT join cm_type with (nolock) on a.cContractType=cm_type.ctypecode LEFT JOIN Customer as Customer_2 with (nolock) ON a.ccuscreditcompany=Customer_2.cCusCode LEFT JOIN DistrictClass with (nolock) ON a.cdwdcode=DistrictClass.cDCCode LEFT JOIN Department with (nolock) ON a.cDeptCode = Department.cDepCode LEFT JOIN CustomerClass with (nolock) ON a.cdwccode=CustomerClass.cCCCode LEFT JOIN Department as Department_1 with (nolock) ON a.chdptcode=Department_1.cDepCode LEFT JOIN Customer as Customer_1 with (nolock) ON a.chdwcode=Customer_1.cCusCode LEFT JOIN Person as Person_1 with (nolock) ON a.chpsncode=Person_1.cPersonCode  LEFT JOIN Inventory with (nolock) ON a.cInvCode = Inventory.cInvCode LEFT JOIN InventoryClass with (nolock) ON Inventory.cInvCCode=InventoryClass.cInvCCode  LEFT JOIN fitem with (nolock) ON a.cItem_Class=fitem.cItem_Class LEFT JOIN Person with (nolock) ON a.cPerson = Person.cPersonCode 
where  ((isnull(dcreditstart,dregdate)<='222222'))  and a.iflag<=2  Group by cdwcode

insert into #a(cCheckMan,ccode,ccode_name,ccontractid,ccontractname,ccontracttype,ccontracttypename,ccuscreditcompany,ccuscreditname,icreline,cdwdcode,cdcname,cdeptcode,cdepname,cdwccode,cdwcname,cdwcode,cdwname,cdwabbname,chdptcode,chdepname,chdwcode,chdwname,chpsncode,chpersonname,cinvccode,cinvcname,cinvcode,cinvname,cinvstd,citem_class,citem_name,citemcode,citemname,cperson,cpersonname,qc_f,qc_s,qc,jf_f,jf_s,jf,df_f,df_s,df,csysid) 
Select max(cCheckMan),max(a.ccode),max(code.ccode_name),max(cm.strContractID),max(cm.strContractName),max(cm.strContractType),max(cm.cTypeName),max(a.ccuscreditcompany),max(CASE WHEN Customer_2.cCusName<>'' THEN Customer_2.cCusName ELSE Customer_2.cCusAbbName END),max(a.icreline),max(cdwdcode),max(districtclass.cdcname),max(a.cdeptcode),max(department.cdepname),max(cdwccode),max(customerclass.cccname),max(cdwcode),max(cdwname) as cdwname,max(cdwabbname) as cdwabbname,max(chdptcode),max(department_1.cdepname),max(chdwcode),max(case when customer_1.ccusname<>'' then customer_1.ccusname else customer_1.ccusabbname end),max(chpsncode),max(person_1.cpersonname),max(inventory.cinvccode),max(inventoryclass.cinvcname),max(a.cinvcode),max(inventory.cinvname),max(inventory.cinvstd),max(a.citem_class),max(fitem.citem_name),max(a.citemcode),max(a.citemname),max(a.cperson),max(person.cpersonname),SUM(case when  ((a.bcredit=1 and dCreditStart<'111111')) and a.cexch_name<>N'人民币' then iAmount_f else 0 end) as qc_f,SUM(case when  ((a.bcredit=1 and dCreditStart<'111111')) then iAmount_s else 0 end) as qc_s,SUM(case when  ((a.bcredit=1 and dCreditStart<'111111')) then iAmount else 0 end) as qc,SUM(case when  ((a.bcredit=1 and dCreditStart>=N'111111' and dCreditStart<=N'222222') ) and a.cexch_name<>N'人民币' then iAmount_f else 0 end) as jf_f,SUM(case when  ((a.bcredit=1 and dCreditStart>=N'111111' and dCreditStart<=N'222222') ) then iAmount_s else 0 end) as jf_s,SUM(case when  ((a.bcredit=1 and dCreditStart>=N'111111' and dCreditStart<=N'222222') ) then iAmount else 0 end) as jf,0 as df_f,0 as df_s,0 as df,N'AR' 
From V_OutNotBalance_s a with (nolock) LEFT JOIN gl_v_code code with (nolock) ON a.cCode=code.cCode LEFT join vwContractPosaForAPAR cm with (nolock) on a.cContractRowGuid=cm.RowGuid  LEFT JOIN Customer as Customer_2 with (nolock) ON a.ccuscreditcompany=Customer_2.cCusCode LEFT JOIN DistrictClass with (nolock) ON a.cdwdcode=DistrictClass.cDCCode LEFT JOIN Department with (nolock) ON a.cDeptCode = Department.cDepCode LEFT JOIN CustomerClass with (nolock) ON a.cdwccode=CustomerClass.cCCCode LEFT JOIN Department as Department_1 with (nolock) ON a.chdptcode=Department_1.cDepCode LEFT JOIN Customer as Customer_1 with (nolock) ON a.chdwcode=Customer_1.cCusCode LEFT JOIN Person as Person_1 with (nolock) ON a.chpsncode=Person_1.cPersonCode  LEFT JOIN Inventory with (nolock) ON a.cInvCode = Inventory.cInvCode LEFT JOIN InventoryClass with (nolock) ON Inventory.cInvCCode=InventoryClass.cInvCCode  LEFT JOIN fitem with (nolock) ON a.cItem_Class=fitem.cItem_Class LEFT JOIN Person with (nolock) ON a.cPerson = Person.cPersonCode 
where  ((a.bcredit=1 and dCreditStart<='222222')) Group By cdwcode

--,cDeptCode,cDepName,cPerson,cPersonName
insert into #a(cDwCode,cDwName,期初销售发货未入库数量,期初销售发货未入库金额) 
select a.cCusCode,c.cCusName,sum(iQuantity-isnull(fOutQuantity,0)) ,sum(iNatSum-isnull(iSettleNum,0)) 
from DispatchList a left join DispatchLists b on a.DLID=b.DLID 
left join Customer c on a.cCusCode=c.cCusCode where a.dDate<='111111' group by a.cCusCode,c.cCusName

insert into #a(cDwCode,cDwName,本期销售发货未入库数量,本期销售发货未入库金额) 
select a.cCusCode,c.cCusName,sum(iQuantity-isnull(fOutQuantity,0)) ,sum(iNatSum-isnull(iSettleNum,0)) from DispatchList a left join DispatchLists b on a.DLID=b.DLID 
left join Customer c on a.cCusCode=c.cCusCode where a.dDate>='111111' and a.dDate<='222222' group by a.cCusCode,c.cCusName

insert into #a(cDwCode,cDwName,期末销售发货未入库数量,期末销售发货未入库金额) 
select a.cCusCode,c.cCusName,sum(iQuantity-isnull(fOutQuantity,0)) ,sum(iNatSum-isnull(iSettleNum,0)) from DispatchList a left join DispatchLists b on a.DLID=b.DLID 
left join Customer c on a.cCusCode=c.cCusCode where a.dDate<='111111'  group by a.cCusCode,c.cCusName

insert into #a(cDwCode,cDwName,本期销售发票数量,本期销售发票金额) 
select a.cCusCode,c.cCusName,sum(iQuantity-isnull(fOutQuantity,0)) ,sum(iNatSum-isnull(iMoneySum,0)) from SaleBillVouch a left join SaleBillVouchs b on a.SBVID =b.SBVID 
left join Customer c on a.cCusCode=c.cCusCode where a.dDate>='111111' and a.dDate<='222222'  group by a.cCusCode,c.cCusName


select cDwCode,cDwName
,case when convert(decimal(18, 2),sum(qc))<>0 then convert(decimal(18, 2),sum(qc)) end as 期初余额金额
,case when convert(decimal(18, 2),sum(qc))<>0 then convert(decimal(18, 2),sum(qc_s)) end as 期初余额数量
,case when convert(decimal(18, 2),sum(jf))<>0 then convert(decimal(18, 2),sum(jf)) end as 本期应收
,case when convert(decimal(18, 2),sum(df))<>0 then convert(decimal(18, 2),sum(df)) end as 本期收款
,case when convert(decimal(18, 2),isnull(sum(qc),0)+isnull(sum(jf),0)-isnull(sum(df),0))<>0 then convert(decimal(18, 2),isnull(sum(qc),0)+isnull(sum(jf),0)-isnull(sum(df),0)) end as 期末余额

,case when convert(decimal(18, 2),sum(期初销售发货未入库数量))<>0 then convert(decimal(18, 2),sum(期初销售发货未入库数量)) end as 期初销售发货未入库数量 
,case when convert(decimal(18, 2),sum(期初销售发货未入库金额))<>0 then convert(decimal(18, 2),sum(期初销售发货未入库金额)) end as 期初销售发货未入库金额 

,case when convert(decimal(18, 2),sum(本期销售发货未入库数量))<>0 then convert(decimal(18, 2),sum(本期销售发货未入库数量)) end as 本期销售发货未入库数量 
,case when convert(decimal(18, 2),sum(本期销售发货未入库金额))<>0 then convert(decimal(18, 2),sum(本期销售发货未入库金额)) end as 本期销售发货未入库金额 

,case when convert(decimal(18, 2),sum(期末销售发货未入库数量))<>0 then convert(decimal(18, 2),sum(期末销售发货未入库数量)) end as 期末销售发货未入库数量 
,case when convert(decimal(18, 2),sum(期末销售发货未入库金额))<>0 then convert(decimal(18, 2),sum(期末销售发货未入库金额)) end as 期末销售发货未入库金额 

,case when convert(decimal(18, 2),sum(本期销售发票数量))<>0 then convert(decimal(18, 2),sum(本期销售发票数量)) end as 本期销售发票数量 
,case when convert(decimal(18, 2),sum(本期销售发票金额))<>0 then convert(decimal(18, 2),sum(本期销售发票金额)) end as 本期销售发票金额 

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
                if (buttonEdit存货编码1.EditValue != null && buttonEdit存货编码1.EditValue.ToString() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.cInvCode>='" + buttonEdit存货编码1.EditValue.ToString().Trim() + "'");
                }
                if (buttonEdit存货编码2.EditValue != null && buttonEdit存货编码2.EditValue.ToString() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.cInvCode<='" + buttonEdit存货编码2.EditValue.ToString().Trim() + "'");
                }
                if (buttonEdit客户.EditValue != null && buttonEdit客户.EditValue.ToString() != "")
                {
                    sSQL = sSQL.Replace("2=2", "2=2 and (c.cCusCode='" + buttonEdit客户.EditValue.ToString().Trim() + "' or c.cCusName='" + buttonEdit客户.EditValue.ToString().Trim() + "')");
                }
                if (buttonEdit销售员.EditValue != null && buttonEdit销售员.EditValue.ToString() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and (p.cPersonCode='" + buttonEdit销售员.EditValue.ToString().Trim() + "' or p.cPersonName='" + buttonEdit销售员.EditValue.ToString().Trim() + "')");
                }
                if (buttonEdit部门.EditValue != null && buttonEdit部门.EditValue.ToString() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and (d.cDepName='" + buttonEdit部门.EditValue.ToString().Trim() + "' or d.cDepName='" + buttonEdit部门.EditValue.ToString().Trim() + "')");
                }
                if (buttonEdit仓库.EditValue != null && buttonEdit仓库.EditValue.ToString() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and (w.cWhCode='" + buttonEdit仓库.EditValue.ToString().Trim() + "' or w.cWhName='" + buttonEdit仓库.EditValue.ToString().Trim() + "')");
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

        private void buttonEdit存货编码1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                FrmInvInfo frm = new FrmInvInfo(buttonEdit存货编码1.Text.ToString(), Conn, true);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    buttonEdit存货编码1.EditValue = frm.sInvCode;

                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit存货编码2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                FrmInvInfo frm = new FrmInvInfo(buttonEdit存货编码2.Text.ToString(), Conn, true);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    buttonEdit存货编码2.EditValue = frm.sInvCode;

                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit客户_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                FrmCustomer frm = new FrmCustomer(buttonEdit客户.Text.ToString(), Conn, true);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    buttonEdit客户.EditValue = frm.sCusCode;

                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit销售员_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                FrmPerson frm = new FrmPerson(buttonEdit销售员.Text.ToString(), Conn, true);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    buttonEdit销售员.EditValue = frm.sPerCode;

                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit存货编码1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit存货编码1.Text.Trim() != "")
                {
                    lookUpEdit存货名称1.EditValue = buttonEdit存货编码1.Text.Trim();
                }
                else
                {
                    lookUpEdit存货名称1.EditValue = null;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit存货编码1_Leave(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit存货编码1.Text.Trim() == "")
                    return;
                if (lookUpEdit存货名称1.Text.Trim() == "")
                {
                    buttonEdit存货编码1.Text = "";
                    buttonEdit存货编码1.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit存货编码2_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit存货编码2.Text.Trim() != "")
                {
                    lookUpEdit存货名称2.EditValue = buttonEdit存货编码2.Text.Trim();
                }
                else
                {
                    lookUpEdit存货名称2.EditValue = null;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit存货编码2_Leave(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit存货编码2.Text.Trim() == "")
                    return;
                if (lookUpEdit存货名称2.Text.Trim() == "")
                {
                    buttonEdit存货编码2.Text = "";
                    buttonEdit存货编码2.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit客户_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit客户.Text.Trim() != "")
                {
                    lookUpEdit客户名称.EditValue = buttonEdit客户.Text.Trim();
                }
                else
                {
                    lookUpEdit客户名称.EditValue = null;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit客户_Leave(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit客户.Text.Trim() == "")
                    return;
                if (lookUpEdit客户名称.Text.Trim() == "")
                {
                    buttonEdit客户.Text = "";
                    buttonEdit客户.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit销售员_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit销售员.Text.Trim() != "")
                {
                    lookUpEdit销售员名称.EditValue = buttonEdit销售员.Text.Trim();
                }
                else
                {
                    lookUpEdit销售员名称.EditValue = null;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit销售员_Leave(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit销售员.Text.Trim() == "")
                    return;
                if (lookUpEdit销售员名称.Text.Trim() == "")
                {
                    buttonEdit销售员.Text = "";
                    buttonEdit销售员.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit部门_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                FrmDepartment frm = new FrmDepartment(buttonEdit部门.Text.ToString(), Conn, true);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    buttonEdit部门.EditValue = frm.sPerCode;

                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit部门_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit部门.Text.Trim() != "")
                {
                    lookUpEdit部门.EditValue = buttonEdit部门.Text.Trim();
                }
                else
                {
                    lookUpEdit部门.EditValue = null;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit部门_Leave(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit部门.Text.Trim() == "")
                    return;
                if (lookUpEdit部门.Text.Trim() == "")
                {
                    buttonEdit部门.Text = "";
                    buttonEdit部门.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit仓库_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                FrmWarehouse frm = new FrmWarehouse(buttonEdit仓库.Text.ToString(), Conn, true);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    buttonEdit仓库.EditValue = frm.sPerCode;

                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit仓库_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit仓库.Text.Trim() != "")
                {
                    lookUpEdit仓库.EditValue = buttonEdit仓库.Text.Trim();
                }
                else
                {
                    lookUpEdit仓库.EditValue = null;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit仓库_Leave(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit仓库.Text.Trim() == "")
                    return;
                if (lookUpEdit仓库.Text.Trim() == "")
                {
                    buttonEdit仓库.Text = "";
                    buttonEdit仓库.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            string cCusCode = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridCol客户编码).ToString().Trim();
            string d1 = "";
            string d2 = "";
            系统服务.规格化.ReturnDate(out d1, out d2, false, rdo本月.Checked, rdo本季.Checked, rdo本年.Checked);
            //入库单
            if (gridView1.FocusedColumn == gridCol本期销售发货未入库金额 || gridView1.FocusedColumn == gridCol本期销售发货未入库数量)
            {
                Frm明细多表头 frm = new Frm明细多表头(Conn);
                frm.应收账款销售发货在途(cCusCode, d1, d2);
                frm.Show();
            }
            else if (gridView1.FocusedColumn == gridCol期初销售发货未入库金额 || gridView1.FocusedColumn == gridCol期初销售发货未入库数量)
            {
                Frm明细多表头 frm = new Frm明细多表头(Conn);
                frm.应收账款销售发货在途(cCusCode, "", DateTime.Parse(d1).AddDays(-1).ToString("yyyy-MM-dd"));
                frm.Show();
            }
            else if (gridView1.FocusedColumn == gridCol期末销售发货未入库金额 || gridView1.FocusedColumn == gridCol期末销售发货未入库数量)
            {
                Frm明细多表头 frm = new Frm明细多表头(Conn);
                frm.应收账款销售发货在途(cCusCode, DateTime.Parse(d2).AddDays(1).ToString("yyyy-MM-dd"), "");
                frm.Show();
            }
            //销售发票
            else if (gridView1.FocusedColumn == gridCol本期销售发票金额 || gridView1.FocusedColumn == gridCol本期销售发票数量)
            {
                Frm明细多表头 frm = new Frm明细多表头(Conn);
                frm.应收账款销售发票单在途(cCusCode, d1, d2);
                frm.Show();
            }
            else if (gridView1.FocusedColumn == gridCol期初销售发货未入库金额 || gridView1.FocusedColumn == gridCol期初销售发货未入库数量)
            {
                Frm明细多表头 frm = new Frm明细多表头(Conn);
                frm.应收账款销售发票单在途(cCusCode, "", DateTime.Parse(d1).AddDays(-1).ToString("yyyy-MM-dd"));
                frm.Show();
            }
            else if (gridView1.FocusedColumn == gridCol期末销售发货未入库金额 || gridView1.FocusedColumn == gridCol期末销售发货未入库数量)
            {
                Frm明细多表头 frm = new Frm明细多表头(Conn);
                frm.应收账款销售发票单在途(cCusCode, DateTime.Parse(d2).AddDays(1).ToString("yyyy-MM-dd"), "");
                frm.Show();
            }
            //发票
        }


    }
}