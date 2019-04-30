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
    public partial class FrmӦ������ : UserControl
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

        public FrmӦ������()
        {
            InitializeComponent();
        }


        private void FrmӦ������_Load(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "";
                DataTable dt;
                DataRow dr;
                Clsʱ���� cls = new Clsʱ����();
                if (cls.bchkʱ����(Conn) == false)
                {
                    throw new Exception("��������ʧ��");
                }

                LookUp.Inventory(Conn, lookUpEdit�������1);
                LookUp.Inventory(Conn, lookUpEdit�������2);
                LookUp.Vendor(Conn, lookUpEdit��Ӧ������);
                LookUp.Person(Conn, lookUpEdit�ɹ�Ա����);
                LookUp.Department(Conn, lookUpEdit����);
                LookUp.Warehouse(Conn, lookUpEdit�ֿ�);

                btnRefresh_Click(null, null);
            }
            catch (Exception ee)
            {
                MessageBox.Show("��������ʧ��");
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
                Clsʱ���� cls = new Clsʱ����();
                if (cls.bchkʱ����(Conn) == false)
                {
                    throw new Exception("��������ʧ��");
                }
                string d1 = "";
                string d2 = "";
                if (rdo����.Checked == true)
                {
                    d1 = (DateTime.Now.AddDays(1 - DateTime.Now.Day)).ToString("yyyy-MM-dd");
                    d2 = ((DateTime.Now.AddDays(1 - DateTime.Now.Day)).AddMonths(1).AddDays(-1)).ToString("yyyy-MM-dd");
                }
                else if (rdo����.Checked == true)
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
,���ڲɹ����δ������� decimal(18,2),���ڲɹ����δ����� money,�ڳ��ɹ����δ�������  decimal(18,2),�ڳ��ɹ����δ����� money,��ĩ�ɹ����δ�������  decimal(18,2),��ĩ�ɹ����δ����� money
,���ڲɹ���Ʊ����  decimal(18,2),���ڲɹ���Ʊ��� money)
insert into #a(ccode,ccode_name,ccontractid,ccontractname,ccontracttype,ccontracttypename,cdwdcode,cdcname,cdeptcode,cdepname,cdwccode,cdwcname,cdwcode,cdwname,cdwabbname,chdptcode,chdepname,chdwcode,chdwname,chpsncode,chpersonname,cinvccode,cinvcname,cinvcode,cinvname,cinvstd,citem_class,citem_name,citemcode,citemname,cperson,cpersonname,qc_f,qc_s,qc,jf_f,jf_s,jf,df_f,df_s,df,csysid) Select max(a.ccode),max(code.ccode_name),max(a.ccontractid),max(cm.strContractName),max(ccontracttype),max(cm_type.ctypename),max(cdwdcode),max(districtclass.cdcname),max(a.cdeptcode),max(department.cdepname),max(cdwccode),max(vendorclass.cvcname),max(cdwcode),max(cdwname) as cdwname,max(cdwabbname) as cdwabbname,max(chdptcode),max(department_1.cdepname),max(chdwcode),max(case when vendor_1.cvenname<>'' then vendor_1.cvenname else vendor_1.cvenabbname end),max(chpsncode),max(person_1.cpersonname),max(inventory.cinvccode),max(inventoryclass.cinvcname),max(a.cinvcode),max(inventory.cinvname),max(inventory.cinvstd),max(a.citem_class),max(fitem.citem_name),max(a.citemcode),max(a.citemname),max(a.cperson),max(person.cpersonname),SUM(case when  ((isnull(dcreditstart,dregdate)<'111111')) and a.cexch_name<>N'�����' then iCAmount_f-iDAmount_f else 0 end) as qc_f,SUM(case when  ((isnull(dcreditstart,dregdate)<'111111')) and (ccovouchtype=cprocstyle Or cprocstyle='XJ')then iCAmount_s-iDAmount_s else 0 end) as qc_s,SUM(case when  ((isnull(dcreditstart,dregdate)<'111111')) then iCAmount-iDAmount else 0 end) as qc,SUM(case when  ((isnull(dCreditStart,dregdate)>='111111' and isnull(dCreditStart,dregdate)<='222222')) and a.cexch_name<>N'�����' then iCAmount_f else 0 end) as jf_f,SUM(case when  ((isnull(dCreditStart,dregdate)>='111111' and isnull(dCreditStart,dregdate)<='222222')) and (ccovouchtype=cprocstyle Or cprocstyle='XJ') then iCAmount_s else 0 end) as jf_s,SUM(case when  ((isnull(dCreditStart,dregdate)>='111111' and isnull(dCreditStart,dregdate)<='222222')) then iCAmount else 0 end) as jf,SUM(case when  ((isnull(dCreditStart,dregdate)>='111111' and isnull(dCreditStart,dregdate)<='222222')) and a.cexch_name<>N'�����' then iDAmount_f else 0 end) as df_f,SUM(case when  ((isnull(dCreditStart,dregdate)>='111111' and isnull(dCreditStart,dregdate)<='222222')) and ccovouchtype=cprocstyle then iDAmount_s else 0 end) as df_s,SUM(case when  ((isnull(dCreditStart,dregdate)>='111111' and isnull(dCreditStart,dregdate)<='222222')) then iDAmount else 0 end) as df,N'AP' 
From Ap_DetailVend_s  a with (nolock) LEFT JOIN gl_v_code code with (nolock) ON a.cCode=code.cCode Left Join vwCM_ContractForAPAR cm with (nolock) on a.cContractID=cm.strContractID LEFT join cm_type with (nolock) on a.cContractType=cm_type.ctypecode LEFT JOIN DistrictClass with (nolock) ON a.cdwdcode=DistrictClass.cDCCode LEFT JOIN Department with (nolock) ON a.cDeptCode = Department.cDepCode LEFT JOIN VendorClass with (nolock) ON a.cdwccode=VendorClass.cVCCode LEFT JOIN Department as Department_1 with (nolock) ON a.chdptcode=Department_1.cDepCode LEFT JOIN Vendor as Vendor_1 with (nolock) ON a.chdwcode=Vendor_1.cVenCode LEFT JOIN Person as Person_1 with (nolock) ON a.chpsncode=Person_1.cPersonCode  LEFT JOIN Inventory with (nolock) ON a.cInvCode = Inventory.cInvCode LEFT JOIN InventoryClass with (nolock) ON Inventory.cInvCCode=InventoryClass.cInvCCode  LEFT JOIN fitem with (nolock) ON a.cItem_Class=fitem.cItem_Class LEFT JOIN Person with (nolock) ON a.cPerson = Person.cPersonCode where  ((isnull(dcreditstart,dregdate)<='222222'))  and a.iflag<=2  Group by cdwcode

insert into #a(cDwCode,cDwName,�ڳ��ɹ����δ�������,�ڳ��ɹ����δ�����) 
select a.cVenCode,c.cVenName,sum(iQuantity-isnull(iSQuantity,0)) ,sum(iAPrice -isnull(iMoney,0)) from RdRecord01 a left join RdRecords01 b on a.ID=b.ID 
left join Vendor c on a.cVenCode=c.cVenCode where a.dDate<='111111' group by a.cVenCode,c.cVenName

insert into #a(cDwCode,cDwName,���ڲɹ����δ�������,���ڲɹ����δ�����) 
select a.cVenCode,c.cVenName,sum(iQuantity-isnull(iSQuantity,0)) ,sum(iAPrice -isnull(iMoney,0)) from RdRecord01 a left join RdRecords01 b on a.ID=b.ID 
left join Vendor c on a.cVenCode=c.cVenCode where a.dDate>='111111' and a.dDate<='222222' group by a.cVenCode,c.cVenName

insert into #a(cDwCode,cDwName,��ĩ�ɹ����δ�������,��ĩ�ɹ����δ�����) 
select a.cVenCode,c.cVenName,sum(iQuantity-isnull(iSQuantity,0)) ,sum(iAPrice -isnull(iMoney,0)) from RdRecord01 a left join RdRecords01 b on a.ID=b.ID 
left join Vendor c on a.cVenCode=c.cVenCode where a.dDate<='111111'  group by a.cVenCode,c.cVenName

insert into #a(cDwCode,cDwName,���ڲɹ���Ʊ����,���ڲɹ���Ʊ���) 
select a.cVenCode,c.cVenName,sum(iPBVQuantity) ,sum(iMoney) from PurBillVouch a left join PurBillVouchs b on a.PBVID =b.PBVID  
left join Vendor c on a.cVenCode=c.cVenCode where a.dPBVDate>='111111' and a.dPBVDate<='222222'  group by a.cVenCode,c.cVenName


select cDwCode,cDwName
,case when convert(decimal(18, 2),sum(qc))<>0 then convert(decimal(18, 2),sum(qc)) end as �ڳ������
,case when convert(decimal(18, 2),sum(qc))<>0 then convert(decimal(18, 2),sum(qc_s)) end as �ڳ��������
,case when convert(decimal(18, 2),sum(jf))<>0 then convert(decimal(18, 2),sum(jf)) end as ����Ӧ��
,case when convert(decimal(18, 2),sum(df))<>0 then convert(decimal(18, 2),sum(df)) end as ���ڸ���
,case when convert(decimal(18, 2),isnull(sum(qc),0)+isnull(sum(jf),0)-isnull(sum(df),0))<>0 then convert(decimal(18, 2),isnull(sum(qc),0)+isnull(sum(jf),0)-isnull(sum(df),0)) end as ��ĩ���

,case when convert(decimal(18, 2),sum(�ڳ��ɹ����δ�������))<>0 then convert(decimal(18, 2),sum(�ڳ��ɹ����δ�������)) end as �ڳ��ɹ����δ������� 
,case when convert(decimal(18, 2),sum(�ڳ��ɹ����δ�����))<>0 then convert(decimal(18, 2),sum(�ڳ��ɹ����δ�����)) end as �ڳ��ɹ����δ����� 

,case when convert(decimal(18, 2),sum(���ڲɹ����δ�������))<>0 then convert(decimal(18, 2),sum(���ڲɹ����δ�������)) end as ���ڲɹ����δ������� 
,case when convert(decimal(18, 2),sum(���ڲɹ����δ�����))<>0 then convert(decimal(18, 2),sum(���ڲɹ����δ�����)) end as ���ڲɹ����δ����� 

,case when convert(decimal(18, 2),sum(��ĩ�ɹ����δ�������))<>0 then convert(decimal(18, 2),sum(��ĩ�ɹ����δ�������)) end as ��ĩ�ɹ����δ������� 
,case when convert(decimal(18, 2),sum(��ĩ�ɹ����δ�����))<>0 then convert(decimal(18, 2),sum(��ĩ�ɹ����δ�����)) end as ��ĩ�ɹ����δ����� 

,case when convert(decimal(18, 2),sum(���ڲɹ���Ʊ����))<>0 then convert(decimal(18, 2),sum(���ڲɹ���Ʊ����)) end as ���ڲɹ���Ʊ���� 
,case when convert(decimal(18, 2),sum(���ڲɹ���Ʊ���))<>0 then convert(decimal(18, 2),sum(���ڲɹ���Ʊ���)) end as ���ڲɹ���Ʊ��� 

into #b
from #a where 2=2 group by cDwCode,cDwName

select * 
from #b 
";

                sSQL = sSQL.Replace("111111", d1);
                sSQL = sSQL.Replace("222222", d2);

                if (rdo���.Checked == true)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(a.cCheckMan,'')<>''");
                }
                else
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(a.cCheckMan,'')=''");
                }

                if (lookUpEdit��Ӧ������.EditValue != null && lookUpEdit��Ӧ������.EditValue.ToString().Trim() != "")
                {
                    sSQL = sSQL.Replace("2=2", "2=2 and cDwCode='" + lookUpEdit��Ӧ������.EditValue.ToString().Trim() + "'");
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
                sF.Filter = "Excel�ļ�(*.xls)|*.xls|�����ļ�(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridControl1.ExportToXls(sF.FileName);
                    MessageBox.Show("����Excel�ɹ�\n\t·����" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("�����б�ʧ�ܣ�" + ee.Message);
            }
        }

        private void buttonEdit��Ӧ��_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                FrmVenInfo frm = new FrmVenInfo(buttonEdit��Ӧ��.Text.ToString(), Conn, true);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    buttonEdit��Ӧ��.EditValue = frm.cVenCode;

                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }


        private void buttonEdit��Ӧ��_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit��Ӧ��.Text.Trim() != "")
                {
                    lookUpEdit��Ӧ������.EditValue = buttonEdit��Ӧ��.Text.Trim();
                }
                else
                {
                    lookUpEdit��Ӧ������.EditValue = null;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit��Ӧ��_Leave(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit��Ӧ��.Text.Trim() == "")
                    return;
                if (lookUpEdit��Ӧ������.Text.Trim() == "")
                {
                    buttonEdit��Ӧ��.Text = "";
                    buttonEdit��Ӧ��.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            string cVenCode = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridCol��Ӧ�̱���).ToString().Trim();
            string d1 = "";
            string d2 = "";
            ϵͳ����.���.ReturnDate(out d1, out d2, false, rdo����.Checked, rdo����.Checked, rdo����.Checked);
            //��ⵥ
            if (gridView1.FocusedColumn == gridCol���ڲɹ����δ������ || gridView1.FocusedColumn == gridCol���ڲɹ����δ��������)
            {
                Frm��ϸ���ͷ frm = new Frm��ϸ���ͷ(Conn);
                frm.Ӧ���˿�ɹ������;(cVenCode, d1, d2);
                frm.Show();
            }
            else if (gridView1.FocusedColumn == gridCol�ڳ��ɹ����δ������ || gridView1.FocusedColumn == gridCol�ڳ��ɹ����δ��������)
            {
                Frm��ϸ���ͷ frm = new Frm��ϸ���ͷ(Conn);
                frm.Ӧ���˿�ɹ������;(cVenCode, "", DateTime.Parse(d1).AddDays(-1).ToString("yyyy-MM-dd"));
                frm.Show();
            }
            else if (gridView1.FocusedColumn == gridCol�ڳ��ɹ����δ������ || gridView1.FocusedColumn == gridCol�ڳ��ɹ����δ��������)
            {
                Frm��ϸ���ͷ frm = new Frm��ϸ���ͷ(Conn);
                frm.Ӧ���˿�ɹ������;(cVenCode, DateTime.Parse(d2).AddDays(1).ToString("yyyy-MM-dd"), "");
                frm.Show();
            }
            //����
            else if (gridView1.FocusedColumn == gridCol���ڲɹ�����δ����� || gridView1.FocusedColumn == gridCol���ڲɹ�����δ�������)
            {
                Frm��ϸ���ͷ frm = new Frm��ϸ���ͷ(Conn);
                frm.Ӧ���˿�ɹ�������;(cVenCode, d1, d2);
                frm.Show();
            }
            else if (gridView1.FocusedColumn == gridCol�ڳ��ɹ�����δ����� || gridView1.FocusedColumn == gridCol�ڳ��ɹ�����δ�������)
            {
                Frm��ϸ���ͷ frm = new Frm��ϸ���ͷ(Conn);
                frm.Ӧ���˿�ɹ�������;(cVenCode, "", DateTime.Parse(d1).AddDays(-1).ToString("yyyy-MM-dd"));
                frm.Show();
            }
            else if (gridView1.FocusedColumn == gridCol��ĩ�ɹ�����δ����� || gridView1.FocusedColumn == gridCol��ĩ�ɹ�����δ�������)
            {
                Frm��ϸ���ͷ frm = new Frm��ϸ���ͷ(Conn);
                frm.Ӧ���˿�ɹ�������;(cVenCode, DateTime.Parse(d2).AddDays(1).ToString("yyyy-MM-dd"), "");
                frm.Show();
            }
            //��Ʊ
            else if (gridView1.FocusedColumn == gridCol���ڲɹ���Ʊ��� || gridView1.FocusedColumn == gridCol���ڲɹ���Ʊ����)
            {
                Frm��ϸ���ͷ frm = new Frm��ϸ���ͷ(Conn);
                frm.Ӧ���˿�ɹ���Ʊ(cVenCode, d1, d2);
                frm.Show();
            }
            //����
            else if (gridView1.FocusedColumn == gridCol���ڸ���)
            {
                Frm��ϸ���ͷ frm = new Frm��ϸ���ͷ(Conn);
                frm.Ӧ���˿�ɹ�����(cVenCode, d1, d2);
                frm.Show();
            }
        }


    }
}