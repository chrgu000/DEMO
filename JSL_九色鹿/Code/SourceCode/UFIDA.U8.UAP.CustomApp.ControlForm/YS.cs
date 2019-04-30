using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using UFIDA.U8.UAP.CustomApp.ControlForm.Business;
using DevExpress.XtraEditors;
using System.Xml;
using DevExpress.XtraTreeList.Nodes;


namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class YS : UserControl
    {

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        public YS()
        {
            InitializeComponent();
        }


        private void ProjectManager_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dtmonth = new DataTable();
                dtmonth.Columns.Add("cValue");
                for (int i = 1; i <= 12; i++)
                {
                    DataRow dw = dtmonth.NewRow();
                    dw[0] = i.ToString();
                    dtmonth.Rows.Add(dw);
                }
                lookUpEditMonth.Properties.DataSource = dtmonth;

                txt��.EditValue = DateTime.Now.Year;

                lookUpEditMonth.EditValue = DateTime.Now.AddMonths(-1).Month.ToString();

                if (lookUpEditMonth.EditValue.ToString() == "12")
                {
                    txt��.EditValue = DateTime.Now.Year - 1;
                }

                SetLookUp();
            }
            catch (Exception ee)
            {
                MessageBox.Show("��������ʧ��");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetGrid();
        }

        private void SetLookUp()
        {
            string sSQL = @"
select cCusCode,cCusName from Customer order by cCusCode
";
            DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);

            lookUpEditcCusCode.Properties.DataSource = dt;
            lookUpEditcCusName.Properties.DataSource = dt;

            sSQL = @"
select cDCCode ,cDCName from DistrictClass  order by cDCCode 
";
            dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);

            lookUpEditcDCCode.Properties.DataSource = dt;
            lookUpEditcDCName.Properties.DataSource = dt;

            sSQL = @"
select cPersonCode,cPersonName from Person order by cPersonCode
";
            dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditcPersonCode.Properties.DataSource = dt;
            lookUpEditcPersonName.Properties.DataSource = dt;
        }


        private void GetGrid()
        {
            try
            {
                string sSQL = @"



if object_id('tempdb..#a') is not null   
	drop table #a

	Select (cdwcode) as cCusCode
		,SUM(case when  ((isnull(dcreditstart,dregdate)<'@dtmStart')) then iDAmount-iCAmount else 0 end) as qc
		,SUM(case when  ((isnull(dcreditstart,dregdate)<'yyyy-01-01')) then iDAmount-iCAmount else 0 end) as qc_lj
		,SUM(case when  ((isnull(dCreditStart,dregdate)>='@dtmStart' and isnull(dCreditStart,dregdate)<'@dtmEnd')) then iDAmount else 0 end) as jf
		,SUM(case when  ((year(isnull(dCreditStart,dregdate))=yyyy and isnull(dCreditStart,dregdate)<'@dtmEnd')) then iDAmount else 0 end) as jf_lj
		,SUM(case when  ((isnull(dCreditStart,dregdate)>='@dtmStart' and isnull(dCreditStart,dregdate)<'@dtmEnd')) then iCAmount else 0 end) as df
		,SUM(case when  ((year(isnull(dCreditStart,dregdate))=yyyy and isnull(dCreditStart,dregdate)<'@dtmEnd')) then iCAmount else 0 end) as df_lj
		,ISNULL(SUM(case when  ((isnull(dcreditstart,dregdate)<'@dtmStart')) then iDAmount-iCAmount else 0 end),0) 
		- ISNULL(SUM(case when  ((isnull(dCreditStart,dregdate)>='@dtmStart' and isnull(dCreditStart,dregdate)<'@dtmEnd')) then iCAmount else 0 end) ,0)
		+ ISNULL( SUM(case when  ((isnull(dCreditStart,dregdate)>='@dtmStart' and isnull(dCreditStart,dregdate)<'@dtmEnd')) then iDAmount else 0 end) ,0) as jy
		,CAST(null as decimal(16,2)) as ��
		,CAST(null as decimal(16,2)) as �����
		,CAST(null as decimal(16,2)) as �˷�
		,CAST(null as decimal(16,2)) as ����˷�
		,CAST(null as decimal(16,2)) as ����
		,CAST(null as decimal(16,2)) as ��ȷ���
		,CAST(null as decimal(16,2)) as �˻�
		,CAST(null as decimal(16,2)) as ����˻�
	into #a
	From Ar_DetailCust_s  a with (nolock) inner join Customer cus on cus.cCusCode = a.cDwCode
	where   a.iflag<=2   and 1=1
	Group by cdwcode
	
	
	
	insert into #a
	Select (cdwcode) as cCusCode
		,SUM(case when  ((isnull(dCreditStart,dvouchdate)<'@dtmStart')) then iAmount else 0 end) as qc
		,SUM(case when  ((isnull(dCreditStart,dvouchdate)<'yyyy-01-01')) then iAmount else 0 end) as qc_lj
		,SUM(case when  ((isnull(dCreditStart,dvouchdate)>='@dtmStart' and isnull(dCreditStart,dvouchdate)<'@dtmEnd') ) then iAmount else 0 end) as jf
		,SUM(case when  ((year(isnull(dCreditStart,dvouchdate))=yyyy and isnull(dCreditStart,dvouchdate)<'@dtmEnd') ) then iAmount else 0 end) as jf_lj
		,0 as df
		,0 as df_lj
		,ISNULL(SUM(case when  ((isnull(dCreditStart,dvouchdate)<'@dtmStart')) then iAmount else 0 end),0) 
		+ ISNULL(SUM(case when  ((isnull(dCreditStart,dvouchdate)>='@dtmStart' and isnull(dCreditStart,dvouchdate)<'@dtmEnd') ) then iAmount else 0 end),0)
		- 0 as jy
		,null,null,null,null,null,null,null,null
	From Ap_SalbillCust_s a with (nolock)  inner join Customer cus on cus.cCusCode = a.cDwCode
	where   isnull(cCheckMan,N'')=N''   and 1=1
	Group By cdwcode



--		Select max(cdwcode),max(cdwname) as cdwname,max(cdwabbname) as cdwabbname,SUM(case when  (isnull(dCreditStart,dvouchdate)<'@dtmStart') and a.cexch_name<>N'�����' then case when a.bd_c=1 then iAmount_f else -iAmount_f end else 0 end) as qc_f,SUM(case when  (isnull(dCreditStart,dvouchdate)<'@dtmStart') then case when a.bd_c=1 then iAmount_s else -iAmount_s end else 0 end) as qc_s,SUM(case when  (isnull(dCreditStart,dvouchdate)<'@dtmStart') then case when a.bd_c=1 then iAmount else -iAmount end else 0 end) as qc,SUM(case when  (isnull(dCreditStart,dvouchdate)>='@dtmStart' and isnull(dCreditStart,dvouchdate)<'@dtmEnd') and a.cexch_name<>N'�����' then case when a.bd_c=1 then iAmount_f else -iAmount_f end else 0 end) as jf_f,SUM(case when  (isnull(dCreditStart,dvouchdate)>='@dtmStart' and isnull(dCreditStart,dvouchdate)<'@dtmEnd') then case when a.bd_c=1 then iAmount_s else -iAmount_s end else 0 end) as jf_s,SUM(case when  (isnull(dCreditStart,dvouchdate)>='@dtmStart' and isnull(dCreditStart,dvouchdate)<'@dtmEnd') then case when a.bd_c=1 then iAmount else -iAmount end else 0 end) as jf,0 as df_f,0 as df_s,0 as df,N'AR' From ap_vouchcust_s a with (nolock) where dvouchdate<=N'yyyy-06-30'  And isnull(cCheckMan,N'')=N''  Group By cdwcode


--		Select max(cdwcode),max(cdwname) as cdwname,max(cdwabbname) as cdwabbname,SUM(case when dvouchdate<N'@dtmStart' and a.cexch_name<>N'�����' then case when cVouchType=N'48' then -iAmount_f else iAmount_f  end else 0 end) as qc_f,null as qc_s,SUM(case when dvouchdate<N'@dtmStart' then case when cVouchType=N'48' then -iAmount else iAmount end else 0 end) as qc,0 as jf_f,0 as jf_s,0 as jf,SUM(case when dvouchdate>=N'@dtmStart' and a.cexch_name<>N'�����' then case when cVouchType=N'48' then iAmount_f else -iAmount_f  end else 0 end) as df_f,SUM(case when dvouchdate>=N'@dtmStart' then case when cVouchType=N'48' then iAmount_s else -iAmount_s end else 0 end) as df_s,SUM(case when dvouchdate>=N'@dtmStart' then case when cVouchType=N'48' then iAmount else -iAmount end else 0 end) as df,N'AR' From Ap_Closecust_s a with (nolock) where dvouchdate<=N'yyyy-06-30'  And isnull(cCheckMan,N'')=N''  Group By cdwcode
 

insert into #a(cCusCode,��)
select a.cCusCode
	,sum(b.iSum) as Ӧ��
from SaleBillVouch a inner join SaleBillVouchs b on a.SBVID = b.SBVID
	inner join Inventory inv on b.cInvCode = inv.cInvCode
    inner join Customer cus on a.cCusCode = cus.cCusCode
	left join DistrictClass District on cus.cDCCode = District.cDCCode
where inv.cInvStd like '%��%' and a.dDate >= '@dtmStart' and a.dDate < '@dtmEnd' and 1=1 
group by a.cCusCode

insert into #a(cCusCode,�����)
select a.cCusCode
	,sum(b.iSum) as Ӧ��
from SaleBillVouch a inner join SaleBillVouchs b on a.SBVID = b.SBVID
	inner join Inventory inv on b.cInvCode = inv.cInvCode
    inner join Customer cus on a.cCusCode = cus.cCusCode
	left join DistrictClass District on cus.cDCCode = District.cDCCode
where inv.cInvStd like '%��%' 
	and year(a.dDate) = 'yyyy' and a.dDate < '@dtmEnd' and 1=1 
group by a.cCusCode


 
insert into #a(cCusCode,�˷�)
select a.cCusCode
	,sum(b.iSum) as Ӧ��
from SaleBillVouch a inner join SaleBillVouchs b on a.SBVID = b.SBVID
	inner join Inventory inv on b.cInvCode = inv.cInvCode
    inner join Customer cus on a.cCusCode = cus.cCusCode
	left join DistrictClass District on cus.cDCCode = District.cDCCode
where inv.cInvStd like '%�˷�%' and a.dDate >= '@dtmStart' and a.dDate < '@dtmEnd' and 1=1 
group by a.cCusCode

insert into #a(cCusCode,����˷�)
select a.cCusCode
	,sum(b.iSum) as Ӧ��
from SaleBillVouch a inner join SaleBillVouchs b on a.SBVID = b.SBVID
	inner join Inventory inv on b.cInvCode = inv.cInvCode
    inner join Customer cus on a.cCusCode = cus.cCusCode
	left join DistrictClass District on cus.cDCCode = District.cDCCode
where inv.cInvStd like '%�˷�%' 
	and year(a.dDate) = 'yyyy' and a.dDate < '@dtmEnd' and 1=1 
group by a.cCusCode


insert into #a(cCusCode,����)
select a.cCusCode
	,sum(b.iSum) as ����
from SaleBillVouch a inner join SaleBillVouchs b on a.SBVID = b.SBVID
	inner join Inventory inv on b.cInvCode = inv.cInvCode
    inner join Customer cus on a.cCusCode = cus.cCusCode
	left join DistrictClass District on cus.cDCCode = District.cDCCode
where a.dDate >= '@dtmStart' and a.dDate < '@dtmEnd' and 1=1 
	and isnull(inv.cInvStd,'') not like '%�˷�%'  
	and isnull(inv.cInvStd,'') not like '%��%'
	and b.iSum > 0
group by a.cCusCode

insert into #a(cCusCode,��ȷ���)
select a.cCusCode
	,sum(b.iSum) as ����
from SaleBillVouch a inner join SaleBillVouchs b on a.SBVID = b.SBVID
	inner join Inventory inv on b.cInvCode = inv.cInvCode
    inner join Customer cus on a.cCusCode = cus.cCusCode
	left join DistrictClass District on cus.cDCCode = District.cDCCode
where year(a.dDate) >= 'yyyy' and a.dDate < '@dtmEnd' and 1=1 
	and isnull(inv.cInvStd,'') not like '%�˷�%'  
	and isnull(inv.cInvStd,'') not like '%��%'
	and b.iSum > 0
group by a.cCusCode

insert into #a(cCusCode,�˻�)
select a.cCusCode
	,sum(b.iSum) as �˻�
from SaleBillVouch a inner join SaleBillVouchs b on a.SBVID = b.SBVID
	inner join Inventory inv on b.cInvCode = inv.cInvCode
    inner join Customer cus on a.cCusCode = cus.cCusCode
	left join DistrictClass District on cus.cDCCode = District.cDCCode
where a.dDate >= '@dtmStart' and a.dDate < '@dtmEnd' and 1=1 
	and isnull(inv.cInvStd,'') not like '%�˷�%'  
	and isnull(inv.cInvStd,'') not like '%��%'
	and b.iSum < 0
group by a.cCusCode

insert into #a(cCusCode,����˻�)
select a.cCusCode
	,sum(b.iSum) as �˻�
from SaleBillVouch a inner join SaleBillVouchs b on a.SBVID = b.SBVID
	inner join Inventory inv on b.cInvCode = inv.cInvCode
    inner join Customer cus on a.cCusCode = cus.cCusCode
	left join DistrictClass District on cus.cDCCode = District.cDCCode
where year(a.dDate) >= 'yyyy' and a.dDate < '@dtmEnd' and 1=1 
	and isnull(inv.cInvStd,'') not like '%�˷�%'  
	and isnull(inv.cInvStd,'') not like '%��%'
	and b.iSum < 0
group by a.cCusCode


select cus.cCusCode,cus.cCusName,cus.cCusPPerson,per.cPersonName,cus.cDCCode,dis.cDCName  
	,case when SUM(qc) <> 0 then SUM(qc) end as �ڳ�, case when sum(jf) <> 0 then sum(jf) end as Ӧ��
    ,case when SUM(df)  <> 0 then  SUM(df) end as �տ�
    ,case when SUM(jy) <> 0 then SUM(jy) end as ���
    ,case when SUM(����) <> 0 then SUM(����) end as ����
    ,case when SUM(��ȷ���) <> 0 then SUM(��ȷ���) end as ��ȷ���
    ,case when SUM(qc_lj)  <> 0 then SUM(qc_lj) end as ����ڳ�, case when sum(jf_lj)  <> 0 then sum(jf_lj) end as ����ۼ�Ӧ��
    ,case when sum(df_lj)  <> 0 then sum(df_lj) end as ����ۼ��տ�
	,case when SUM(��)  <> 0 then SUM(��) end as ��,case when SUM(�����)  <> 0 then SUM(�����) end as �����
    ,case when SUM(�˷�) <> 0 then SUM(�˷�) end  as �˷�,case when SUM(����˷�) <> 0 then SUM(����˷�) end as ����˷�
    ,case when SUM(�˻�)  <> 0 then SUM(�˻�) end as �˻�,case when SUM(����˻�)  <> 0 then SUM(����˻�) end as ����˻�
    ,case when isnull(SUM(��ȷ���),0) + isnull(SUM(����˻�),0) <> 0 then isnull(SUM(��ȷ���),0) + isnull(SUM(����˻�),0) end as ʵ�ʷ���
from #a a 
	inner join Customer cus on a.cCusCode = cus.cCusCode
	left join Person per on per.cPersonCode = cus.cCusPPerson 
    left join DistrictClass dis on dis.cDCCode = cus.cDCCode 
group by cus.cCusCode,cus.cCusName,cus.cCusPPerson,per.cPersonName,cus.cDCCode,dis.cDCName  
having 2=2

";
                DateTime dtmStart = Convert.ToDateTime(txt��.Text.Trim() + "-" + lookUpEditMonth.Text.Trim() + "-1");
                sSQL = sSQL.Replace("@dtmStart",  dtmStart.ToString("yyyy-MM-dd") );
                sSQL = sSQL.Replace("@dtmEnd", dtmStart.AddMonths(1).ToString("yyyy-MM-dd"));
                sSQL = sSQL.Replace("yyyy", dtmStart.ToString("yyyy"));


                if (lookUpEditcCusCode.EditValue != null && lookUpEditcCusCode.Text.Trim() != "" && lookUpEditcCusName.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and cus.cCusCode = '" + lookUpEditcCusCode.EditValue.ToString().Trim() + "'");
                }
                if (lookUpEditcDCCode.EditValue != null && lookUpEditcDCCode.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and cus.cDCCode like  '" + lookUpEditcDCCode.EditValue.ToString().Trim() + "%'");
                }
                if (lookUpEditcPersonCode.EditValue != null && lookUpEditcPersonCode.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and cus.cCusPPerson  = '" + lookUpEditcPersonCode.EditValue.ToString().Trim() + "'");
                }

                if (chkYU.Checked)
                {
                    sSQL = sSQL.Replace("2=2", "2=2 and isnull(SUM(jy),0)  <> 0 or  isnull(SUM(��ȷ���),0) + isnull(SUM(����˻�),0) <> 0");
                }

                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                gridControl1.DataSource = dt;

                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    for (int j = 0; j < dt.Columns.Count; j++)
                //    {
                //        if (dt.Columns[j].ColumnName.ToLower().Trim() == "cCusCode".ToLower() || dt.Columns[j].ColumnName.ToLower().Trim() == "cCusName".ToLower()
                //            || dt.Columns[j].ColumnName.ToLower().Trim() == "cCusPPerson".ToLower() || dt.Columns[j].ColumnName.ToLower().Trim() == "cPersonName".ToLower()
                //            || dt.Columns[j].ColumnName.ToLower().Trim() == "cDCCode".ToLower() || dt.Columns[j].ColumnName.ToLower().Trim() == "cDCName".ToLower())
                //        {
                //            continue;
                //        }

                //        decimal d = ReturnDecimal(dt.Rows[i][j]);
                //        if (d == 0)
                //        {
                //            dt.Rows[i][j] = DBNull.Value;
                //        }
                //    }
                //}

                gridView1.BestFitColumns();

                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    gridView1.Columns[i].Width += 5;
                }

                //gridView1.Columns["�ۼ�Ӧ�ս�����"].


            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }


        public decimal ReturnDecimal(object o)
        {
            decimal d = 0;
            try
            {
                d = Convert.ToDecimal(o);
            }
            catch { }
            return d;
        }

      

        private void grvDetail_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {

            if (e.RowHandle < 0)
                return;
            e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sa = new SaveFileDialog();
                sa.Filter = "Excel�ļ�2003|*.xls";
                sa.FileName = "����";

                DialogResult d = sa.ShowDialog();
                if (d == DialogResult.OK)
                {
                    string sPath = sa.FileName;

                    if (sPath.Trim() != string.Empty)
                    {
                        gridView1.ExportToXls(sPath);
                        MessageBox.Show("�����б�ɹ���\n·����" + sPath);
                    }
                }
                
            }
            catch (Exception ee)
            {
                MessageBox.Show("�����б�ʧ�ܣ�" + ee.Message);
            }
        }

        private void lookUpEditcCusCode_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditcCusName.EditValue = lookUpEditcCusCode.EditValue;
        }

        private void lookUpEditcCusName_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditcCusCode.EditValue = lookUpEditcCusName.EditValue;
        }

        private void lookUpEditcDCCode_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditcDCName.EditValue = lookUpEditcDCCode.EditValue;
        }

        private void lookUpEditcDCName_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditcDCCode.EditValue = lookUpEditcDCName.EditValue;
        }

        private void lookUpEditcPersonCode_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditcPersonName.EditValue = lookUpEditcPersonCode.EditValue;
        }

        private void lookUpEditcPersonName_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditcPersonCode.EditValue = lookUpEditcPersonName.EditValue;
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0 )
                {
                    if (e.Column == gridCol�ۼ�Ӧ�ս�����)
                    {
                        decimal d = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, e.Column));
                        if (d > 0)
                        {
                            e.Appearance.ForeColor = Color.Tomato;
                        }
                    }
                    if (e.Column == gridCol�ڳ�)
                    {
                        decimal d = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, e.Column));
                        if (d > 0)
                        {
                            e.Appearance.ForeColor = Color.Tomato;
                        }
                    }
                }
            }
            catch
            { }
        }

        //private decimal ReturnDecimal(object o)
        //{
        //    decimal d = 0;
        //    try
        //    {
        //        d = Convert.ToDecimal(o);
        //    }
        //    catch { }

        //    return d;

        //}

    }
}