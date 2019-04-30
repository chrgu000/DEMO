using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
//using UFIDA.U8.UAP.CustomApp.ControlForm.Business;
using DevExpress.XtraEditors;
using System.Xml;
using System.Data.SqlClient;
using TH.BaseClass;
using System.IO;


namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class ƾ֤���� : UserControl
    {
        string sProPath = Application.StartupPath;

        UFIDA.U8.UAP.CustomApp.ControlForm.RepBaseGrid Rep = new RepBaseGrid();

        string sState = "";

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string Conn2 = "server=192.168.1.7;uid=sa;pwd=Sa!@#;database=UFSystem";

        //public string Conn2 = "server=192.168.150.110;uid=sa;pwd=;database=UFSystem";

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        public ƾ֤����()
        {
            InitializeComponent();
        }

        private void ProjectManager_Load(object sender, EventArgs e)
        {
            try
            {
                GetLookUp();

                if (lookUpEdit��Դ����.EditValue.ToString().Trim() != "100" && lookUpEdit��Դ����.EditValue.ToString().Trim() != "666")
                {
                    btnSave.Enabled = false;
                    btnSel.Enabled = false;
                    throw new Exception("ֻ������100��666������ΪԴ����");
                }

                if (lookUpEdit��Դ����.EditValue.ToString().Trim() == "100")
                {
                    groupBox1.Visible = true;
                }
                else
                {
                    groupBox1.Visible = false;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("��������ʧ�ܣ�" + ee.Message);
            }
        }

        private void GetLookUp()
        {
            string sSQL = @"
SELECT DISTINCT A.cAcc_Id as ���׺�,'[' + cast(A.cAcc_Id as varchar(3)) + ']' + A.cAcc_Name as ���� 
FROM UFSystem.dbo.UA_Account A,UFSystem.dbo.UA_period P  
WHERE A.cAcc_Id=P.cAcc_Id AND (P.bIsDelete=0 OR P.bIsDelete IS NULL) 
ORDER BY A.cAcc_Id,'[' + cast(A.cAcc_Id as varchar(3)) + ']' + A.cAcc_Name
";

            DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];

            lookUpEdit��Դ����.Properties.DataSource = dt;

            lookUpEdit��Դ����.EditValue = sAccID;

            dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "���";
            dt.Columns.Add(dc);

            DataRow dr = dt.NewRow();
            dr["���"] = DateTime.Now.AddYears(-1).ToString("yyyy");
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["���"] = DateTime.Now.ToString("yyyy");
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["���"] = DateTime.Now.AddYears(1).ToString("yyyy");
            dt.Rows.Add(dr);
            lookUpEdit���.Properties.DataSource = dt;
            lookUpEdit���.EditValue = DateTime.Now.ToString("yyyy");

            dt = new DataTable();
            dc = new DataColumn();
            dc.ColumnName = "�ڼ�";
            dt.Columns.Add(dc);

            for (int i = 1; i <= 12; i++)
            {
                dr = dt.NewRow();
                dr["�ڼ�"] = i.ToString();
                dt.Rows.Add(dr);
            }
          
            lookUpEdit�ڼ�.Properties.DataSource = dt;
            lookUpEdit�ڼ�.EditValue = DateTime.Now.Month.ToString().Trim();

            sSQL = "select distinct cbill  from gl_accvouch order by cbill";
            dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            lookUpEdit�Ƶ���.Properties.DataSource = dt;

            sSQL = "select distinct ccode as ��Ŀ���� from code where isnull(bend,0) = 1 order by ccode ";
            dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            ItemLookUpEdit��Ŀ����.DataSource = dt;

            dt = new DataTable();
            dc = new DataColumn();
            dc.ColumnName = "������˾";
            dt.Columns.Add(dc);
            dr = dt.NewRow();
            dr["������˾"] = "";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["������˾"] = "��̫";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["������˾"] = "����";
            dt.Rows.Add(dr);
            ItemLookUpEdit������˾.DataSource = dt;
        }

        
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            try
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
            catch { }
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dDate = Convert.ToDateTime(SqlHelper.sDate);
                if (DateTime.Today > dDate.AddMonths(3))
                {
                    return;
                }

                if (lookUpEdit��Դ����.Text.Trim() == "")
                {
                    throw new Exception("��Դ���ײ���Ϊ��");
                }

                if (lookUpEdit���.Text.Trim() == "")
                {
                    throw new Exception("��Ȳ���Ϊ��");
                }
                if (lookUpEdit�ڼ�.Text.Trim() == "")
                {
                    throw new Exception("�ڼ䲻��Ϊ��");
                }


                //string s��� = lookUpEdit���.EditValue.ToString().Trim();
                //sSQL = "select * from  bbb..GL_mend where iyear = '" + s��� + "' and iperiod = '" + lookUpEdit�ڼ�.Text.Trim() + "'";
                //sSQL = sSQL.Replace("bbb", sĿ������);
                //dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                //if (dt == null || dt.Rows.Count == 0)
                //{
                //    throw new Exception("Ŀ�����ײ����ڶ�Ӧ����ڼ�");
                //}
                //if (Convert.ToBoolean(dt.Rows[0]["bflag"]))
                //{
                //    throw new Exception("Ŀ�������Ѿ�����");
                //}

                //                string sErr = "";

                string sSQL = "";

                #region 100����ת��
                if (lookUpEdit��Դ����.EditValue.ToString().Trim() == "100")
                {
                    sSQL = "select distinct ctext1 from aaa..GL_accvouch where isnull(ctext1,'') <> '' and iyear = '111111' and iperiod = '222222'";
                    sSQL = sSQL.Replace("111111", lookUpEdit���.Text.Trim());
                    sSQL = sSQL.Replace("222222", lookUpEdit�ڼ�.Text.Trim());
                    sSQL = sSQL.Replace("aaa", "ufdata_003_2014");
                    DataTable dtHav��̫ = SqlHelper.ExecuteDataset(Conn2, CommandType.Text, sSQL).Tables[0];
                    string sHav��̫ = @"'TestNull'";
                    StringBuilder sHavBud��̫ = new StringBuilder();
                    if (dtHav��̫ != null && dtHav��̫.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtHav��̫.Rows.Count; i++)
                        {
                            if (sHavBud��̫.ToString().Trim() == "")
                            {
                                sHavBud��̫.Append("'" + dtHav��̫.Rows[i]["ctext1"].ToString().Trim() + "'");
                            }
                            else
                            {
                                sHavBud��̫.Append(",'" + dtHav��̫.Rows[i]["ctext1"].ToString().Trim() + "'");
                            }
                        }
                        sHav��̫ = sHavBud��̫.ToString().Trim();
                    }

                    sSQL = "select distinct ctext1 from aaa..GL_accvouch where isnull(ctext1,'') <> '' and iyear = '111111' and iperiod = '222222'";
                    sSQL = sSQL.Replace("111111", lookUpEdit���.Text.Trim());
                    sSQL = sSQL.Replace("222222", lookUpEdit�ڼ�.Text.Trim());
                    sSQL = sSQL.Replace("aaa", "ufdata_009_2014");
                    DataTable dtHav���� = SqlHelper.ExecuteDataset(Conn2, CommandType.Text, sSQL).Tables[0];
                    string sHav���� = @"'TestNull'";
                    StringBuilder sHavBud���� = new StringBuilder();
                    if (dtHav���� != null && dtHav����.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtHav����.Rows.Count; i++)
                        {
                            if (sHavBud����.ToString().Trim() == "")
                            {
                                sHavBud����.Append("'" + dtHav����.Rows[i]["ctext1"].ToString().Trim() + "'");
                            }
                            else
                            {
                                sHavBud����.Append(",'" + dtHav����.Rows[i]["ctext1"].ToString().Trim() + "'");
                            }
                        }
                        sHav���� = sHavBud����.ToString().Trim();
                    }


                    if (radio��̫.Checked || radio����.Checked)
                    {
                        sSQL = @"
select CAST(0 as bit) as ѡ�� ,cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) as ƾ֤��,ino_id
		,b.������˾,i_id as �Զ����, iperiod as ����ڼ�, csign as ƾ֤�����,  inid as �к�
		,dbill_date as �Ƶ�����, cbill as �Ƶ���, ccheck as �����, cbook as ������, ibook as ���˱�־ 
		, cdigest as ժҪ, ccode as ��Ŀ����, cexch_name as ��������
        ,case when cast(md as decimal(16,2)) = 0 then null else cast(md as decimal(16,2)) end as �跽���, case when cast(mc as decimal(16,2)) = 0 then null else cast(mc as decimal(16,2)) end  as �������
        ,case when cast(md_f as decimal(16,2)) = 0 then null else cast(md_f as decimal(16,2)) end  as ��ҽ跽���, case when cast(mc_f as decimal(16,2)) = 0 then null else cast(mc_f as decimal(16,2)) end   as ��Ҵ������
        ,case when cast(nfrat as decimal(16,2)) = 0 then null else cast(nfrat as decimal(16,2)) end as ����
		, nd_s as �����跽, nc_s as ��������
		, ccus_id as �ͻ�����, csup_id as ��Ӧ�̱���
		,cast('999999' as varchar(50))  + right('00' + cast(iperiod as varchar(2)),2) + cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) as ʶ���
into #a
from GL_accvouch a left join UFSystem..���׿�Ŀ���� b on a.ccode = b.��Ŀ and b.���׺� = '555555' 
where 1=1 and iyear = '111111' and iperiod = '222222' and dbill_date >= '333333' and dbill_date <= '444444'
    and cast(iyear as varchar(50))  + right('00' + cast(iperiod as varchar(2)),2) + cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) not in (666666)
order by iyear,iperiod,csign,ino_id,inid

select distinct cast('999999' as varchar(50))  + right('00' + cast(iperiod as varchar(2)),2) + cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) as ʶ���
into #b
from GL_accvouch a left join UFSystem..���׿�Ŀ���� b on a.ccode = b.��Ŀ and b.���׺� = '555555' 
where 22=22 and iyear = '111111' and iperiod = '222222' and dbill_date >= '333333' and dbill_date <= '444444'

select distinct cast('999999' as varchar(50))  + right('00' + cast(iperiod as varchar(2)),2) + cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) as ʶ���
into #c
from GL_accvouch a left join UFSystem..���׿�Ŀ���� b on a.ccode = b.��Ŀ and b.���׺� = '555555' 
where 33=33 and iyear = '111111' and iperiod = '222222' and dbill_date >= '333333' and dbill_date <= '444444'

select #a.*
from #a inner join #b on ltrim(rtrim(#a.ʶ���)) = ltrim(rtrim(#b.ʶ���))
where #a.ʶ��� not in (select ʶ��� from #c)

";

                        sSQL = sSQL.Replace("999999", lookUpEdit���.Text.Substring(2));

                        if (radio��̫.Checked)
                        {
                            sSQL = sSQL.Replace("22=22", "22=22 and b.������˾ = '��̫'");
                            sSQL = sSQL.Replace("33=33", "33=33 and b.������˾ <> '��̫' and isnull(b.������˾,'') <> '' ");
                            sSQL = sSQL.Replace("aaa", "ufdata_003_2014");
                            sSQL = sSQL.Replace("666666", sHav��̫);
                        }
                        if (radio����.Checked)
                        {
                            sSQL = sSQL.Replace("22=22", "22=22 and b.������˾ = '����'");
                            sSQL = sSQL.Replace("33=33", "33=33 and b.������˾ <> '����' and isnull(b.������˾,'') <> '' ");
                            sSQL = sSQL.Replace("aaa", "ufdata_009_2014");
                            sSQL = sSQL.Replace("666666", sHav����);
                        }
                    }
                    if (radioȫ����.Checked)
                    {
                        //    and cast(iyear as varchar(50))  + right('00' + cast(iperiod as varchar(2)),2) + cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) not in (select distinct ctext1 from aaa..GL_accvouch where isnull(ctext1,'') <> '')
                        //    and cast(iyear as varchar(50))  + right('00' + cast(iperiod as varchar(2)),2) + cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) not in (select distinct ctext1 from bbb..GL_accvouch where isnull(ctext1,'') <> '')

                        sSQL = @"
select CAST(0 as bit) as ѡ�� ,cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) as ƾ֤��,ino_id
		,b.������˾,i_id as �Զ����, iperiod as ����ڼ�, csign as ƾ֤�����,  inid as �к�,csign as ƾ֤�����2
		,dbill_date as �Ƶ�����, cbill as �Ƶ���, ccheck as �����, cbook as ������, ibook as ���˱�־ 
		, cdigest as ժҪ, ccode as ��Ŀ����, cexch_name as ��������
        ,case when cast(md as decimal(16,2)) = 0 then null else cast(md as decimal(16,2)) end as �跽���, case when cast(mc as decimal(16,2)) = 0 then null else cast(mc as decimal(16,2)) end  as �������
        ,case when cast(md_f as decimal(16,2)) = 0 then null else cast(md_f as decimal(16,2)) end  as ��ҽ跽���, case when cast(mc_f as decimal(16,2)) = 0 then null else cast(mc_f as decimal(16,2)) end   as ��Ҵ������
		,case when cast(nfrat as decimal(16,2)) = 0 then null else cast(nfrat as decimal(16,2)) end as ����
        , nd_s as �����跽, nc_s as ��������
		, ccus_id as �ͻ�����, csup_id as ��Ӧ�̱���
		,cast('999999' as varchar(50))  + right('00' + cast(iperiod as varchar(2)),2) + cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) as ʶ���
into #a
from GL_accvouch a left join UFSystem..���׿�Ŀ���� b on a.ccode = b.��Ŀ and b.���׺� = '555555' 
where 1=1 and iyear = '111111' and iperiod = '222222' and dbill_date >= '333333' and dbill_date <= '444444'
     and cast(iyear as varchar(50))  + right('00' + cast(iperiod as varchar(2)),2) + cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) not in(666666)
     and cast(iyear as varchar(50))  + right('00' + cast(iperiod as varchar(2)),2) + cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) not in(777777)
order by iyear,iperiod,csign,ino_id,inid


select ʶ���,count(1)  as ����
into #b
from 
(
	select distinct cast('999999' as varchar(50))  + right('00' + cast(iperiod as varchar(2)),2) + cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) as ʶ���
		,b.������˾
	from GL_accvouch a left join UFSystem..���׿�Ŀ���� b on a.ccode = b.��Ŀ and b.���׺� = '100' 
	where 33=33 and iyear = '111111' and iperiod = '222222' and dbill_date >= '333333' and dbill_date <= '444444'
		 and isnull(b.������˾,'') <> ''
)a
group by ʶ���
having 2=2

select *,cast (null as varchar(50)) as sErr
from #a
where #a.ʶ��� in (select ʶ��� from #b)

";
                        sSQL = sSQL.Replace("999999", lookUpEdit���.Text.Substring(2));
                        sSQL = sSQL.Replace("aaa", "ufdata_003_2014");
                        sSQL = sSQL.Replace("bbb", "ufdata_009_2014");
                        sSQL = sSQL.Replace("666666", sHav��̫);
                        sSQL = sSQL.Replace("777777", sHav����);
                        if (radioȫ����.Checked)
                        {
                            sSQL = sSQL.Replace("2=2", "count(1) > 1");
                        }
                        if (radioȫ������.Checked)
                        {
                            sSQL = sSQL.Replace("2=2", "count(1) < 1");
                        }
                    }

                    if (radioȫ������.Checked)
                    {
                        //and cast(iyear as varchar(50))  + right('00' + cast(iperiod as varchar(2)),2) + cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) not in (select distinct ctext1 from aaa..GL_accvouch where isnull(ctext1,'') <> '')
                        //and cast(iyear as varchar(50))  + right('00' + cast(iperiod as varchar(2)),2) + cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) not in (select distinct ctext1 from bbb..GL_accvouch where isnull(ctext1,'') <> '')

                        sSQL = @"
select CAST(0 as bit) as ѡ�� ,cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) as ƾ֤��,ino_id
		,b.������˾,i_id as �Զ����, iperiod as ����ڼ�, csign as ƾ֤�����,  inid as �к�
		,dbill_date as �Ƶ�����, cbill as �Ƶ���, ccheck as �����, cbook as ������, ibook as ���˱�־ 
		, cdigest as ժҪ, ccode as ��Ŀ����, cexch_name as ��������
        ,case when cast(md as decimal(16,2)) = 0 then null else cast(md as decimal(16,2)) end as �跽���, case when cast(mc as decimal(16,2)) = 0 then null else cast(mc as decimal(16,2)) end  as �������
        ,case when cast(md_f as decimal(16,2)) = 0 then null else cast(md_f as decimal(16,2)) end  as ��ҽ跽���, case when cast(mc_f as decimal(16,2)) = 0 then null else cast(mc_f as decimal(16,2)) end   as ��Ҵ������
		,case when cast(nfrat as decimal(16,2)) = 0 then null else cast(nfrat as decimal(16,2)) end as ����
        , nd_s as �����跽, nc_s as ��������
		, ccus_id as �ͻ�����, csup_id as ��Ӧ�̱���
		,cast('999999' as varchar(50))  + right('00' + cast(iperiod as varchar(2)),2) + cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) as ʶ���
into #a
from GL_accvouch a left join UFSystem..���׿�Ŀ���� b on a.ccode = b.��Ŀ and b.���׺� = '555555' 
where 1=1 and iyear = '111111' and iperiod = '222222' and dbill_date >= '333333' and dbill_date <= '444444'
order by iyear,iperiod,csign,ino_id,inid


select distinct cast('999999' as varchar(50))  + right('00' + cast(iperiod as varchar(2)),2) + cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) as ʶ���
into #b
from GL_accvouch a left join UFSystem..���׿�Ŀ���� b on a.ccode = b.��Ŀ and b.���׺� = '555555' 
where 22=22 and iyear = '111111' and iperiod = '222222' and dbill_date >= '333333' and dbill_date <= '444444'

select distinct cast('999999' as varchar(50))  + right('00' + cast(iperiod as varchar(2)),2) + cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) as ʶ���
into #c
from GL_accvouch a left join UFSystem..���׿�Ŀ���� b on a.ccode = b.��Ŀ and b.���׺� = '555555' 
where 33=33 and iyear = '111111' and iperiod = '222222' and dbill_date >= '333333' and dbill_date <= '444444'

select #a.*
from #a inner join #b on ltrim(rtrim(#a.ʶ���)) = ltrim(rtrim(#b.ʶ���))
where #a.ʶ��� not in (select ʶ��� from #c)
";

                        sSQL = sSQL.Replace("999999", lookUpEdit���.Text.Substring(2));
                        sSQL = sSQL.Replace("22=22", "22=22 and isnull(b.������˾,'') = ''");
                        sSQL = sSQL.Replace("33=33", "33=33 and (b.������˾ = '����' or b.������˾ = '��̫') ");
                        sSQL = sSQL.Replace("aaa", "ufdata_003_2014");
                        sSQL = sSQL.Replace("bbb", "ufdata_009_2014");
                    }

                    sSQL = sSQL.Replace("111111", lookUpEdit���.Text.Trim());
                    sSQL = sSQL.Replace("222222", lookUpEdit�ڼ�.Text.Trim());
                    sSQL = sSQL.Replace("333333", dateEdit�Ƶ�����1.DateTime.ToString("yyyy-MM-dd"));
                    sSQL = sSQL.Replace("444444", dateEdit�Ƶ�����2.DateTime.ToString("yyyy-MM-dd"));
                    sSQL = sSQL.Replace("555555", lookUpEdit��Դ����.EditValue.ToString().Trim());




                    if (radioδ���.Checked)
                    {
                        sSQL = sSQL.Replace("1=1", "1=1 and isnull(ccheck,'') = ''");
                    }
                    if (radio�����.Checked)
                    {
                        sSQL = sSQL.Replace("1=1", "1=1 and isnull(ccheck,'') <> ''");
                    }
                    if (lookUpEdit�Ƶ���.Text.Trim() != "")
                    {
                        sSQL = sSQL.Replace("1=1", "1=1 and isnull(cbill,'') = '" + lookUpEdit�Ƶ���.Text.Trim() + "'");
                    }

                    DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                    gridControl1.DataSource = dt;

                    string sErr = "";
                    //�趨�Է���Ŀ
                    if (radioȫ����.Checked)
                    {
                        sSQL = "select * from UFSystem..���׿�Ŀ���� where ���׺� = '100'";
                        DataTable dt���׿�Ŀ���� = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];

                        for (int i = dt.Rows.Count-1; i >=0 ; i--)
                        {
                            string s��Ŀ = dt.Rows[i]["��Ŀ����"].ToString().Trim();
                            string s������˾ = dt.Rows[i]["������˾"].ToString().Trim();
                            decimal d�� = SqlHelper.ReturnObjectToDecimal(dt.Rows[i]["�跽���"], 2);
                            decimal d�� = SqlHelper.ReturnObjectToDecimal(dt.Rows[i]["�������"], 2);
                            string sƾ֤��� = dt.Rows[i]["ƾ֤�����"].ToString().Trim();
                            string sƾ֤���2 = "";

                            if (sƾ֤��� == "��" && d�� > 0)
                                    sƾ֤���2 = "��";

                            if (sƾ֤��� == "��" && d�� > 0)
                                sƾ֤���2 = "��";


                            if (sƾ֤��� == "��" && d�� > 0)
                                sƾ֤���2 = "��";

                            if (sƾ֤��� == "��" && d�� > 0)
                                sƾ֤���2 = "��";

                            if (sƾ֤��� == "ת")
                            {
                                sƾ֤���2 = "ת";
                            }

                            dt.Rows[i]["ƾ֤�����2"] = sƾ֤���2;

                            DataRow[] dr�Է���Ŀ = dt���׿�Ŀ����.Select("��Ŀ = '" + s��Ŀ + "' and ������˾ = '" + s������˾ + "'");
                            if (dr�Է���Ŀ.Length == 0)
                            {

                                if (radioȫ����.Checked)
                                {
                                    for (int ii = 0; ii < dr�Է���Ŀ.Length; ii++)
                                    {
                                        dr�Է���Ŀ[ii]["serr"] = "Err";
                                    }
                                    sErr = sErr + "��Ŀ" + s��Ŀ + " δ���öԷ���Ŀ\n";
                                }
                                else
                                {
                                    sErr = sErr + "��" + (i + 1).ToString() + " δ���öԷ���Ŀ\n";
                                }
                                continue;
                            }
                            string s�Է���Ŀ = "@" + dr�Է���Ŀ[0]["�Է���Ŀ"].ToString().Trim();
                            if (s�Է���Ŀ == "")
                            {
                                if (radioȫ����.Checked)
                                {
                                    for (int ii = 0; ii < dr�Է���Ŀ.Length; ii++)
                                    {
                                        dr�Է���Ŀ[ii]["serr"] = "Err";
                                    }
                                    sErr = sErr + "��Ŀ" + s��Ŀ + " δ���öԷ���Ŀ\n";
                                }
                                else
                                {
                                    sErr = sErr + "��" + (i + 1).ToString() + " δ���öԷ���Ŀ\n";
                                }
                                continue;
                            }
                            string s�Է���Ӧ�� = "@" + dr�Է���Ŀ[0]["�Է���Ӧ��"].ToString().Trim();
                            //if (dr�Է���Ŀ[0]["�Է���Ӧ��"].ToString().Trim() != "")
                            //{
                            //    s�Է���Ӧ�� = "'" + dr�Է���Ŀ[0]["�Է���Ӧ��"].ToString().Trim() + "'";
                            //}
                            string s�Է��ͻ� = "@" + dr�Է���Ŀ[0]["�Է��ͻ�"].ToString().Trim();
                            //if (dr�Է���Ŀ[0]["�Է��ͻ�"].ToString().Trim() != "")
                            //{
                            //    s�Է��ͻ� = "'" + dr�Է���Ŀ[0]["�Է��ͻ�"].ToString().Trim() + "'";
                            //}

                            DataRow dr = dt.Rows[i];
                            DataRow drNew = dt.NewRow();
                            drNew.ItemArray = dr.ItemArray;
                            drNew[15] = s�Է���Ŀ;
                            decimal d17 = SqlHelper.ReturnObjectToDecimal(drNew[17]);//�跽���
                            decimal d18 = SqlHelper.ReturnObjectToDecimal(drNew[18]);//�������
                            decimal d19 = SqlHelper.ReturnObjectToDecimal(drNew[19]);//�跽���
                            decimal d20 = SqlHelper.ReturnObjectToDecimal(drNew[20]);//�������

                            drNew[17] = d18;
                            drNew[18] = d17;
                            drNew[19] = d20;
                            drNew[20] = d19;
                            drNew["��Ӧ�̱���"] = s�Է���Ӧ��;
                            drNew["�ͻ�����"] = s�Է��ͻ�;

                          
                            dt.Rows.InsertAt(drNew, i+1);
                        }
                    }
                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }
                    gridControl1.DataSource = dt;
                }

                #endregion

                #region 666����ת��
                if (lookUpEdit��Դ����.EditValue.ToString().Trim() == "666")
                {
                    sSQL = "select distinct ctext1 from aaa..GL_accvouch where isnull(ctext1,'') <> '' and iyear = '111111' and iperiod = '222222'";
                    sSQL = sSQL.Replace("111111", lookUpEdit���.Text.Trim());
                    sSQL = sSQL.Replace("222222", lookUpEdit�ڼ�.Text.Trim());
                    sSQL = sSQL.Replace("aaa", "ufdata_001_2014");
                    DataTable dtHav = SqlHelper.ExecuteDataset(Conn2, CommandType.Text, sSQL).Tables[0];

                    string sHav = @"'TestNull'";
                    StringBuilder sHavBud = new StringBuilder();
                    if (dtHav != null && dtHav.Rows.Count > 0)
                    {
                        for(int i=0;i<dtHav.Rows.Count;i++)
                        {
                            if (sHavBud.ToString().Trim() == "")
                            {
                                sHavBud.Append("'" + dtHav.Rows[i]["ctext1"].ToString().Trim() + "'");
                            }
                            else
                            {
                                sHavBud.Append(",'" + dtHav.Rows[i]["ctext1"].ToString().Trim() + "'"); 
                            }
                        }
                        sHav = sHavBud.ToString().Trim();
                    }

                    sSQL = @"
select CAST(0 as bit) as ѡ�� ,cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) as ƾ֤��,ino_id
		,b.������˾,i_id as �Զ����, iperiod as ����ڼ�, csign as ƾ֤�����,  inid as �к�
		,dbill_date as �Ƶ�����, cbill as �Ƶ���, ccheck as �����, cbook as ������, ibook as ���˱�־ 
		, cdigest as ժҪ, ccode as ��Ŀ����, cexch_name as ��������
        ,case when cast(md as decimal(16,2)) = 0 then null else cast(md as decimal(16,2)) end as �跽���, case when cast(mc as decimal(16,2)) = 0 then null else cast(mc as decimal(16,2)) end  as �������
        ,case when cast(md_f as decimal(16,2)) = 0 then null else cast(md_f as decimal(16,2)) end  as ��ҽ跽���, case when cast(mc_f as decimal(16,2)) = 0 then null else cast(mc_f as decimal(16,2)) end   as ��Ҵ������
		, nfrat as ����, nd_s as �����跽, nc_s as ��������
		, ccus_id as �ͻ�����, csup_id as ��Ӧ�̱���
		,cast('999999' as varchar(50))  + right('00' + cast(iperiod as varchar(2)),2) + cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) as ʶ���
from GL_accvouch a left join UFSystem..���׿�Ŀ���� b on a.ccode = b.��Ŀ and b.���׺� = '555555' 
where 1=1 and iyear = '111111' and iperiod = '222222' and dbill_date >= '333333' and dbill_date <= '444444'
    and cast(iyear as varchar(50))  + right('00' + cast(iperiod as varchar(2)),2) + cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) not in (666666)
order by iyear,iperiod,csign,ino_id,inid
";

                    sSQL = sSQL.Replace("999999", lookUpEdit���.Text.Substring(2));
                    sSQL = sSQL.Replace("111111", lookUpEdit���.Text.Trim());
                    sSQL = sSQL.Replace("222222", lookUpEdit�ڼ�.Text.Trim());
                    sSQL = sSQL.Replace("333333", dateEdit�Ƶ�����1.DateTime.ToString("yyyy-MM-dd"));
                    sSQL = sSQL.Replace("444444", dateEdit�Ƶ�����2.DateTime.ToString("yyyy-MM-dd"));
                    sSQL = sSQL.Replace("555555", lookUpEdit��Դ����.EditValue.ToString().Trim());
                    sSQL = sSQL.Replace("666666", sHav);

                    if (radioδ���.Checked)
                    {
                        sSQL = sSQL.Replace("1=1", "1=1 and isnull(ccheck,'') = ''");
                    }
                    if (radio�����.Checked)
                    {
                        sSQL = sSQL.Replace("1=1", "1=1 and isnull(ccheck,'') <> ''");
                    }
                    if (lookUpEdit�Ƶ���.Text.Trim() != "")
                    {
                        sSQL = sSQL.Replace("1=1", "1=1 and isnull(cbill,'') = '" + lookUpEdit�Ƶ���.Text.Trim() + "'");
                    }
                    DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                    gridControl1.DataSource = dt;
                }
                #endregion

                label��Դ����.Text = lookUpEdit��Դ����.EditValue.ToString().Trim();
                label���.Text = lookUpEdit���.EditValue.ToString().Trim();
                label�ڼ�.Text = lookUpEdit�ڼ�.EditValue.ToString().Trim();
            }
            catch (Exception ee)
            {
                MessageBox.Show("��������ʧ��:" + ee.Message);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
                sF.Filter = "Excel�ļ�(*.xls)|*.xls|�����ļ�(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridView1.ExportToXls(sF.FileName);
                    MessageBox.Show("����Excel�ɹ�\n\t·����" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }


        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                TH.BaseClass.ClsExcel clsExcel = TH.BaseClass.ClsExcel.Instance();

                OpenFileDialog oFile = new OpenFileDialog();
                oFile.Filter = "Excel�ļ�|*.xls|Excel�ļ�|*.xlsx";
                if (oFile.ShowDialog() == DialogResult.OK)
                {
                    string sFilePath = oFile.FileName;
                    string sSQL = "select * from [���յ���$]";

                    DataTable dt = clsExcel.ExcelToDT(sFilePath, sSQL, true);

                    gridView1.Columns.Clear();

                    gridControl1.DataSource = dt;

                    if (dt == null || dt.Rows.Count < 1)
                        throw new Exception("���ص��ļ�û�����ݣ����ʵ�����");
                }
                else
                {
                    throw new Exception("ȡ������");
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.richTextBox1.Text = ee.Message;
                f.Text = "����ʧ��";
                f.ShowDialog();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                if (lookUpEdit��Դ����.EditValue.ToString().Trim() != label��Դ����.Text.Trim() || lookUpEdit���.EditValue.ToString().Trim() != label���.Text.Trim() || lookUpEdit�ڼ�.EditValue.ToString().Trim() != label�ڼ�.Text.Trim())
                {
                    throw new Exception("�����Ѿ��仯�������µ�����˰�ť");
                }

                string sErr = "";
                string sSQL = "";

                int iFoc = 0;
                if (gridView1.FocusedRowHandle > 0)
                    iFoc = gridView1.FocusedRowHandle;

                SqlConnection conn2 = new SqlConnection(Conn2);
                conn2.Open();
                //��������
                SqlTransaction tran = conn2.BeginTransaction();

                try
                {
                    int iCou = 0;

                    string s����ڼ� = lookUpEdit���.EditValue.ToString().Trim() + lookUpEdit�ڼ�.EditValue.ToString().Trim();
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (!Convert.ToBoolean(gridView1.GetRowCellValue(i, gridColѡ��)))
                            continue;

                        string s��� = lookUpEdit���.EditValue.ToString().Trim();
                        string s�ڼ� = lookUpEdit�ڼ�.EditValue.ToString().Trim();
                        if (s�ڼ�.Length == 1)
                            s����ڼ� = lookUpEdit���.EditValue.ToString().Trim() + "0" + lookUpEdit�ڼ�.EditValue.ToString().Trim();

                        string sƾ֤��� = gridView1.GetRowCellValue(i, gridColƾ֤�����).ToString().Trim();
                        string sƾ֤�� = gridView1.GetRowCellValue(i, gridColƾ֤��).ToString().Trim();
                        string s��Ŀ���� = gridView1.GetRowCellValue(i, gridCol��Ŀ����).ToString().Trim();
                        string s�ͻ����� = gridView1.GetRowCellValue(i, gridCol�ͻ�����).ToString().Trim();
                        string s��Ӧ�̱��� = gridView1.GetRowCellValue(i, gridCol��Ӧ�̱���).ToString().Trim();
                        decimal d�跽��� = SqlHelper.ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol�跽���));
                        decimal d��ҽ跽��� = SqlHelper.ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol��ҽ跽���));
                        decimal d������� = SqlHelper.ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol�������));
                        decimal d��Ҵ������ = SqlHelper.ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol��Ҵ������));
                        decimal d���� = SqlHelper.ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol����));
                        string s�������� = gridView1.GetRowCellValue(i, gridCol��������).ToString().Trim();
                        if (s�������� == "")
                            s�������� = "null";
                        else
                            s�������� = "'" + s�������� + "'";

                        string sժҪ = gridView1.GetRowCellValue(i, gridColժҪ).ToString().Trim();
                        string sʶ��� = gridView1.GetRowCellValue(i, gridColʶ���).ToString().Trim();
                        int iƾ֤�� = 0;


                        #region ��һ���״�������

                        if ((lookUpEdit��Դ����.EditValue.ToString().Trim() == "100" && (radio����.Checked || radio��̫.Checked)) || lookUpEdit��Դ����.EditValue.ToString().Trim() == "666")
                        {
                            if (radio����.Checked || radio��̫.Checked)
                            {
                                string sĿ������ = "ufdata_009_2014";   //����
                                sSQL = "select * from ufsystem.dbo.���׵������ձ� where ��Դ���� = '100' and �������� = '009'";

                                if (lookUpEdit��Դ����.EditValue.ToString().Trim() == "666")
                                {
                                    sĿ������ = "ufdata_001_2014";

                                    sSQL = "select * from ufsystem.dbo.���׵������ձ� where ��Դ���� = '666' and �������� = '001'";
                                }
                                else
                                {
                                    if (radio��̫.Checked)
                                    {
                                        sĿ������ = "ufdata_003_2014";

                                        sSQL = "select * from ufsystem.dbo.���׵������ձ� where ��Դ���� = '100' and �������� = '003'";
                                    }
                                }
                                DataTable dt������Ϣ = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];

                                //string s��Ŀ
                                DataRow[] drĿ�����׿�Ŀ���� = dt������Ϣ.Select("���� = '��Ŀ����' and ���� = '" + s��Ŀ���� + "'");
                                if (drĿ�����׿�Ŀ����.Length == 0)
                                {
                                    sErr = sErr + "��" + (i + 1).ToString() + " δ���ÿ�Ŀ����\n";
                                    continue;
                                }
                                else
                                {
                                    s��Ŀ���� = drĿ�����׿�Ŀ����[0]["���ձ���"].ToString().Trim();
                                    if (s��Ŀ���� == "")
                                    {
                                        sErr = sErr + "��" + (i + 1).ToString() + " δ���ÿ�Ŀ����\n";
                                        continue;
                                    }
                                }

                                if (s�ͻ����� != "")
                                {
                                    DataRow[] dr = dt������Ϣ.Select("���� = '�ͻ�����' and ���� = '" + s�ͻ����� + "'");
                                    if (dr.Length > 0 && dr[0]["���ձ���"].ToString().Trim() != "")
                                    {
                                        s�ͻ����� = "'" + dr[0]["���ձ���"].ToString().Trim() + "'";
                                    }
                                    else
                                    {
                                        sErr = sErr + "��" + (i + 1).ToString() + " δ���ÿͻ�����\n";
                                        continue;
                                    }
                                }
                                else
                                {
                                    s�ͻ����� = "null";
                                }
                                if (s��Ӧ�̱��� != "")
                                {
                                    DataRow[] dr = dt������Ϣ.Select("���� = '��Ӧ�̱���' and ���� = '" + s��Ӧ�̱��� + "'");
                                    if (dr.Length > 0 && dr[0]["���ձ���"].ToString().Trim() != "")
                                    {
                                        s��Ӧ�̱��� = "'" + dr[0]["���ձ���"].ToString().Trim() + "'";
                                    }
                                    else
                                    {
                                        sErr = sErr + "��" + (i + 1).ToString() + " δ���ù�Ӧ�̱������\n";
                                        continue;
                                    }
                                }
                                else
                                {
                                    s��Ӧ�̱��� = "null";
                                }

                                sSQL = "select * from aaa..gl_accvouch where ctext1 = '" + sʶ��� + "'";
                                sSQL = sSQL.Replace("aaa", sĿ������);
                                DataTable dt = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    iƾ֤�� = SqlHelper.ReturnObjectToInt(dt.Rows[0]["ino_id"]);
                                }
                                else
                                {
                                    sSQL = "select isnull(max(ino_id),0) as ino_id from aaa..gl_accvouch where iyear = '" + s��� + "' and iperiod = " + s�ڼ� + " and csign = '" + sƾ֤��� + "' ";
                                    sSQL = sSQL.Replace("aaa", sĿ������);
                                    dt = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                    iƾ֤�� = SqlHelper.ReturnObjectToInt(dt.Rows[0]["ino_id"]) + 1;
                                }

                                sSQL = "select * from aaa..dsign where csign = '" + sƾ֤��� + "'";
                                sSQL = sSQL.Replace("aaa", sĿ������);
                                DataTable dtƾ֤���� = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                if (dtƾ֤���� == null || dtƾ֤����.Rows.Count == 0)
                                {
                                    sErr = sErr + "��" + (i + 1).ToString() + " δ����ƾ֤���Ͷ���\n";
                                    continue;
                                }


                                sSQL = "INSERT INTO aaa..gl_accvouch (iperiod, csign, isignseq, ino_id, inid, dbill_date, idoc, cbill, ccheck, cbook" +
                                                  ", ibook, ccashier, iflag, ctext2, cdigest, ccode, cexch_name, md, mc, " +
                                                  "md_f, mc_f, nfrat, nd_s, nc_s, csettle, cn_id, dt_date, cdept_id, cperson_id" +
                                                  ", ccus_id, csup_id, citem_id, citem_class, cname, ccode_equal, iflagbank, iflagPerson,bdelete, coutaccset " +
                                                  ",iyear,iYPeriod ,ctext1) " +
                                       "values(" + s�ڼ� + ",'" + sƾ֤��� + "','" + dtƾ֤����.Rows[0]["isignseq"] + "'," + iƾ֤�� + ",'" + gridView1.GetRowCellValue(i, gridCol�к�).ToString().Trim() + "','" + gridView1.GetRowCellValue(i, gridCol�Ƶ�����).ToString().Trim() + "',-1,'" + gridView1.GetRowCellValue(i, gridCol�Ƶ���).ToString().Trim() + "',null,null" +
                                                ",0,null,null,null,'" + gridView1.GetRowCellValue(i, gridColժҪ).ToString().Trim() + "','" + s��Ŀ���� + "'," + s�������� + "," + SqlHelper.ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol�跽���), 2) + "," + SqlHelper.ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol�������), 2) + "" +
                                                "," + SqlHelper.ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol��ҽ跽���), 2) + "," + SqlHelper.ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol��Ҵ������), 2) + "," + d���� + ",0,0,null,null,null,null,null" +
                                                "," + s�ͻ����� + "," + s��Ӧ�̱��� + ",null,null,null,null,null,null,null,null" +
                                                ",'" + s��� + "','" + s����ڼ� + "','" + sʶ��� + "')";


                                sSQL = sSQL.Replace("aaa", sĿ������);

                                iCou = iCou + SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                        }

                        #endregion

                        #region 100���� ȫ������

                        if (lookUpEdit��Դ����.EditValue.ToString().Trim() == "100" && radioȫ������.Checked)
                        {
                            string s������˾ = gridView1.GetRowCellValue(i, gridCol������˾).ToString().Trim();
                            if (s������˾ == "")
                            {
                                sErr = sErr + "��" + (i + 1).ToString() + " δ���ù�����˾\n";
                                continue;
                            }

                            string sĿ������ = "ufdata_009_2014";       //����
                            if (s������˾ == "��̫")
                            {
                                sĿ������ = "ufdata_003_2014";
                            }

                            sSQL = "select * from ufsystem.dbo.���׵������ձ� where ��Դ���� = '100' and (�������� = '003' or �������� = '009')";
                            DataTable dt������Ϣ = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];

                            //string s��Ŀ
                            DataRow[] drĿ�����׿�Ŀ���� = dt������Ϣ.Select("���� = '��Ŀ����' and ���� = '" + s��Ŀ���� + "'");
                            if (drĿ�����׿�Ŀ����.Length == 0)
                            {
                                sErr = sErr + "��" + (i + 1).ToString() + " δ���ÿ�Ŀ����\n";
                                continue;
                            }
                            else
                            {
                                s��Ŀ���� = drĿ�����׿�Ŀ����[0]["���ձ���"].ToString().Trim();
                                if (s��Ŀ���� == "")
                                {
                                    sErr = sErr + "��" + (i + 1).ToString() + " δ���ÿ�Ŀ����\n";
                                    continue;
                                }
                            }


                            if (s�ͻ����� != "")
                            {
                                DataRow[] dr = dt������Ϣ.Select("���� = '�ͻ�����' and ���� = '" + s�ͻ����� + "'");
                                if (dr.Length > 0 && dr[0]["���ձ���"].ToString().Trim() != "")
                                {
                                    s�ͻ����� = "'" + dr[0]["���ձ���"].ToString().Trim() + "'";
                                }
                                else
                                {
                                    sErr = sErr + "��" + (i + 1).ToString() + " δ���ÿͻ�����\n";
                                    continue;
                                }
                            }
                            else
                            {
                                s�ͻ����� = "null";
                            }
                            if (s��Ӧ�̱��� != "")
                            {
                                DataRow[] dr = dt������Ϣ.Select("���� = '��Ӧ�̱���' and ���� = '" + s��Ӧ�̱��� + "'");
                                if (dr.Length > 0 && dr[0]["���ձ���"].ToString().Trim() != "")
                                {
                                    s��Ӧ�̱��� = "'" + dr[0]["���ձ���"].ToString().Trim() + "'";
                                }
                                else
                                {
                                    sErr = sErr + "��" + (i + 1).ToString() + " δ���ù�Ӧ�̱������\n";
                                    continue;
                                }
                            }
                            else
                            {
                                s��Ӧ�̱��� = "null";
                            }

                            sSQL = "select * from aaa..gl_accvouch where ctext1 = '" + sʶ��� + "'";
                            sSQL = sSQL.Replace("aaa", sĿ������);
                            DataTable dt = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                iƾ֤�� = SqlHelper.ReturnObjectToInt(dt.Rows[0]["ino_id"]);
                            }
                            else
                            {
                                sSQL = "select isnull(max(ino_id),0) as ino_id from aaa..gl_accvouch where iyear = '" + s��� + "' and iperiod = " + s�ڼ� + " and csign = '" + sƾ֤��� + "' ";
                                sSQL = sSQL.Replace("aaa", sĿ������);
                                dt = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                iƾ֤�� = SqlHelper.ReturnObjectToInt(dt.Rows[0]["ino_id"]) + 1;
                            }

                            sSQL = "select * from aaa..dsign where csign = '" + sƾ֤��� + "'";
                            sSQL = sSQL.Replace("aaa", sĿ������);
                            DataTable dtƾ֤���� = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dtƾ֤���� == null || dtƾ֤����.Rows.Count == 0)
                            {
                                sErr = sErr + "��" + (i + 1).ToString() + " δ����ƾ֤���Ͷ���\n";
                                continue;
                            }


                            sSQL = "INSERT INTO aaa..gl_accvouch (iperiod, csign, isignseq, ino_id, inid, dbill_date, idoc, cbill, ccheck, cbook" +
                                              ", ibook, ccashier, iflag, ctext2, cdigest, ccode, cexch_name, md, mc, " +
                                              "md_f, mc_f, nfrat, nd_s, nc_s, csettle, cn_id, dt_date, cdept_id, cperson_id" +
                                              ", ccus_id, csup_id, citem_id, citem_class, cname, ccode_equal, iflagbank, iflagPerson,bdelete, coutaccset " +
                                              ",iyear,iYPeriod ,ctext1) " +
                                   "values(" + s�ڼ� + ",'" + sƾ֤��� + "','" + dtƾ֤����.Rows[0]["isignseq"] + "'," + iƾ֤�� + ",'" + gridView1.GetRowCellValue(i, gridCol�к�).ToString().Trim() + "','" + gridView1.GetRowCellValue(i, gridCol�Ƶ�����).ToString().Trim() + "',-1,'" + gridView1.GetRowCellValue(i, gridCol�Ƶ���).ToString().Trim() + "',null,null" +
                                            ",0,null,null,null,'" + gridView1.GetRowCellValue(i, gridColժҪ).ToString().Trim() + "'," + s��Ŀ���� + "','" + s�������� + "," + SqlHelper.ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol�跽���), 2) + "," + SqlHelper.ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol�������), 2) + "" +
                                            "," + SqlHelper.ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol��ҽ跽���), 2) + "," + SqlHelper.ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol��Ҵ������), 2) + "," + d���� + ",0,0,null,null,null,null,null" +
                                            "," + s�ͻ����� + "," + s��Ӧ�̱��� + ",null,null,null,null,null,null,null,null" +
                                            ",'" + s��� + "','" + s����ڼ� + "','" + sʶ��� + "')";


                            sSQL = sSQL.Replace("aaa", sĿ������);

                            iCou = iCou + SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        #endregion

                        #region 100���� ȫ����

                        if (lookUpEdit��Դ����.EditValue.ToString().Trim() == "100" && radioȫ����.Checked)
                        {
                            string s������˾ = gridView1.GetRowCellValue(i, gridCol������˾).ToString().Trim();
                            if (s������˾ == "")
                            {
                                sErr = sErr + "��" + (i + 1).ToString() + " δ���ù�����˾\n";
                                continue;
                            }

                            string sĿ������ = "ufdata_009_2014";       //����
                            if (s������˾ == "��̫")
                            {
                                sĿ������ = "ufdata_003_2014";
                            }

                            sSQL = "select * from ufsystem.dbo.���׵������ձ� where ��Դ���� = '100' and (�������� = '003' or �������� = '009')";
                            DataTable dt������Ϣ = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];

                            //string s��Ŀ
                            if (s��Ŀ����.Trim() != "" && s��Ŀ����.Substring(0, 1) != "@")
                            {
                                DataRow[] drĿ�����׿�Ŀ���� = dt������Ϣ.Select("���� = '��Ŀ����' and ���� = '" + s��Ŀ���� + "'");
                                if (drĿ�����׿�Ŀ����.Length == 0)
                                {
                                    sErr = sErr + "��" + (i + 1).ToString() + " δ���ÿ�Ŀ����\n";
                                    continue;
                                }
                                else
                                {
                                    s��Ŀ���� = drĿ�����׿�Ŀ����[0]["���ձ���"].ToString().Trim();
                                    if (s��Ŀ���� == "")
                                    {
                                        sErr = sErr + "��" + (i + 1).ToString() + " δ���ÿ�Ŀ����\n";
                                        continue;
                                    }
                                }
                            }
                            else
                            {
                                s��Ŀ���� = s��Ŀ����.Replace("@", "");
                            }

                            if (s�ͻ����� != "")
                            {
                                if (s�ͻ�����.Substring(0, 1) == "@")
                                {
                                    s�ͻ����� = s�ͻ�����.Replace("@", "");
                                    if (s�ͻ����� != "")
                                    {
                                        s�ͻ����� = "'" + s�ͻ����� + "'";
                                    }
                                    else
                                    {
                                        s�ͻ����� = "null";
                                    }
                                }
                                else
                                {
                                    DataRow[] dr = dt������Ϣ.Select("���� = '�ͻ�����' and ���� = '" + s�ͻ����� + "'");
                                    if (dr.Length > 0 && dr[0]["���ձ���"].ToString().Trim() != "")
                                    {
                                        s�ͻ����� = "'" + dr[0]["���ձ���"].ToString().Trim() + "'";
                                    }
                                    else
                                    {
                                        sErr = sErr + "��" + (i + 1).ToString() + " δ���ÿͻ�����\n";
                                        continue;
                                    }
                                }
                            }
                            else
                            {
                                s�ͻ����� = "null";
                            }

                            if (s��Ӧ�̱��� != "")
                            {
                                if (s��Ӧ�̱���.Substring(0, 1) == "@")
                                {
                                    s��Ӧ�̱��� = s��Ӧ�̱���.Replace("@", "");
                                    if (s��Ӧ�̱��� != "")
                                    {
                                        s��Ӧ�̱��� = "'" + s��Ӧ�̱��� + "'";
                                    }
                                    else
                                    {
                                        s��Ӧ�̱��� = "null";
                                    }
                                }
                                else
                                {
                                    DataRow[] dr = dt������Ϣ.Select("���� = '��Ӧ�̱���' and ���� = '" + s��Ӧ�̱��� + "'");
                                    if (dr.Length > 0 && dr[0]["���ձ���"].ToString().Trim() != "")
                                    {
                                        s��Ӧ�̱��� = "'" + dr[0]["���ձ���"].ToString().Trim() + "'";
                                    }
                                    else
                                    {
                                        sErr = sErr + "��" + (i + 1).ToString() + " δ���ù�Ӧ�̱������\n";
                                        continue;
                                    }
                                }
                            }
                            else
                            {
                                s��Ӧ�̱��� = "null";
                            }

                            string sƾ֤���2 = gridView1.GetRowCellValue(i, gridColƾ֤�����2).ToString().Trim();
                            sSQL = "select * from aaa..gl_accvouch where ctext1 = '" + sʶ��� + "' and csign = '" + sƾ֤���2 + "'";
                            sSQL = sSQL.Replace("aaa", sĿ������);
                            DataTable dt = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                iƾ֤�� = SqlHelper.ReturnObjectToInt(dt.Rows[0]["ino_id"]);
                            }
                            else
                            {
                                sSQL = "select isnull(max(ino_id),0) as ino_id,count(1) as �к� from aaa..gl_accvouch where iyear = '" + s��� + "' and iperiod = " + s�ڼ� + " and csign = '" + sƾ֤���2 + "' ";
                                sSQL = sSQL.Replace("aaa", sĿ������);
                                dt = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                iƾ֤�� = SqlHelper.ReturnObjectToInt(dt.Rows[0]["ino_id"]) + 1;
                            }

                            sSQL = "select count(1) as �к� from aaa..gl_accvouch where ctext1 = '" + sʶ��� + "' ";
                            sSQL = sSQL.Replace("aaa", sĿ������);
                            dt = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            int iƾ֤�к� = SqlHelper.ReturnObjectToInt(dt.Rows[0][0]) + 1;

                            sSQL = "select * from aaa..dsign where csign = '" + sƾ֤���2 + "'";
                            sSQL = sSQL.Replace("aaa", sĿ������);
                            DataTable dtƾ֤���� = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dtƾ֤���� == null || dtƾ֤����.Rows.Count == 0)
                            {
                                sErr = sErr + "��" + (i + 1).ToString() + " δ����ƾ֤���Ͷ���\n";
                                continue;
                            }

                            sSQL = "INSERT INTO aaa..gl_accvouch (iperiod, csign, isignseq, ino_id, inid, dbill_date, idoc, cbill, ccheck, cbook" +
                                              ", ibook, ccashier, iflag, ctext2, cdigest, ccode, cexch_name, md, mc, " +
                                              "md_f, mc_f, nfrat, nd_s, nc_s, csettle, cn_id, dt_date, cdept_id, cperson_id" +
                                              ", ccus_id, csup_id, citem_id, citem_class, cname, ccode_equal, iflagbank, iflagPerson,bdelete, coutaccset " +
                                              ",iyear,iYPeriod ,ctext1) " +
                                   "values(" + s�ڼ� + ",'" + sƾ֤���2 + "','" + dtƾ֤����.Rows[0]["isignseq"] + "'," + iƾ֤�� + ",'" + iƾ֤�к� + "','" + gridView1.GetRowCellValue(i, gridCol�Ƶ�����).ToString().Trim() + "',-1,'" + gridView1.GetRowCellValue(i, gridCol�Ƶ���).ToString().Trim() + "',null,null" +
                                            ",0,null,null,null,'" + gridView1.GetRowCellValue(i, gridColժҪ).ToString().Trim() + "','" + s��Ŀ���� + "'," + s�������� + "," + SqlHelper.ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol�跽���), 2) + "," + SqlHelper.ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol�������), 2) + "" +
                                            "," + SqlHelper.ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol��ҽ跽���), 2) + "," + SqlHelper.ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol��Ҵ������), 2) + "," + d���� + ",0,0,null,null,null,null,null" +
                                            "," + s�ͻ����� + "," + s��Ӧ�̱��� + ",null,null,null,null,null,null,null,null" +
                                            ",'" + s��� + "','" + s����ڼ� + "','" + sʶ��� + "')";


                            sSQL = sSQL.Replace("aaa", sĿ������);

                            iCou = iCou + SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        #endregion
                    }


                    sSQL = @"
update UFDATA_009_2014..gl_accvouch set ccus_id='51205001', ccode= '113301',csup_id=NULL
where iyPeriod ='111111' and csign <>'' and ccode ='218101' and csup_id ='51205001' and isnull(ctext1,'') <> ''
";
                    sSQL = sSQL.Replace("111111", s����ڼ�);

                    iCou = iCou + SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                    sSQL = @"
update UFDATA_001_2014..gl_accvouch set csup_id='024', ccode= '218101',ccus_id=NULL
where iyPeriod ='111111' and csign <>'' and ccode ='113301' and ccus_id ='522' and isnull(ctext1,'') <> ''

update UFDATA_001_2014..gl_accvouch set csup_id='002', ccode= '218101',ccus_id=NULL
where iyPeriod ='111111' and csign <>'' and ccode ='113301' and ccus_id ='302' and isnull(ctext1,'') <> ''
";
                    sSQL = sSQL.Replace("111111", s����ڼ�);

                    iCou = iCou + SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    sSQL = sSQL.Replace("111111", s����ڼ�);

                    iCou = iCou + SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }


                    if (iCou > 0)
                    {
                        tran.Commit();
                        MessageBox.Show("����ɹ�", "��ʾ");

                        btnSel_Click(null, null);
                    }
                    else
                    {
                        tran.Rollback();
                        MessageBox.Show("û����Ҫ���������", "��ʾ");
                    }
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                DialogResult d = MessageBox.Show("ȷ��ɾ��ѡ������ô��", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (d != DialogResult.Yes)
                {
                    return;
                }


                int iFoc = 0;
                if (gridView1.FocusedRowHandle > 0)
                    iFoc = gridView1.FocusedRowHandle;

                string sSQL = "";

                DataTable dtGrid = (DataTable)gridControl1.DataSource;

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //��������
                SqlTransaction tran = conn.BeginTransaction();

                for (int i = gridView1.RowCount - 1; i >= 0; i--)
                {
                    if (gridView1.IsRowSelected(i))
                    {
                        string s��Դ���� = gridView1.GetRowCellValue(i, gridView1.Columns["��Դ����"]).ToString().Trim();
                        string s���� = gridView1.GetRowCellValue(i, gridView1.Columns["����"]).ToString().Trim();
                        string s�������� = gridView1.GetRowCellValue(i, gridView1.Columns["��������"]).ToString().Trim();
                        string s���ձ��� = gridView1.GetRowCellValue(i, gridView1.Columns["���ձ���"]).ToString().Trim(); 
                        string s���� = gridView1.GetRowCellValue(i, gridView1.Columns["����"]).ToString().Trim(); 
                    
                        sSQL = "delete ���׵������ձ� where ��Դ���� = '111111' and ���� = '222222' and �������� = '333333' and ���ձ��� = '444444' and ���� = '555555'";

                        sSQL = sSQL.Replace("111111", s��Դ����);
                        sSQL = sSQL.Replace("222222", s����);
                        sSQL = sSQL.Replace("333333", s��������);
                        sSQL = sSQL.Replace("444444", s���ձ���);
                        sSQL = sSQL.Replace("555555", s����);
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                }

                tran.Commit();
                MessageBox.Show("ɾ���ɹ�", "��ʾ");

                btnSel_Click(null,null);
                gridView1.FocusedRowHandle = iFoc;
            }
            catch (Exception ee)
            {
                MessageBox.Show("ɾ��ʧ��:" + ee.Message);
            }
        }

        private void gridView1_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            if ((this.gridView1.GetDataRow(e.RowHandle1)["ʶ���"].ToString() != this.gridView1.GetDataRow(e.RowHandle2)["ʶ���"].ToString()))
                e.Handled = true;
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                DevExpress.XtraGrid.Columns.GridColumn gCol = gridView1.FocusedColumn;
                if (gCol.FieldName == "ѡ��")
                {
                    int iRow = 0;
                    if (gridView1.FocusedRowHandle > 0)
                        iRow = gridView1.FocusedRowHandle;

                    string sʶ��� = gridView1.GetRowCellValue(iRow, gridView1.Columns["ʶ���"]).ToString().Trim();
                    bool bѡ�� = Convert.ToBoolean(gridView1.GetRowCellValue(iRow, gridView1.Columns["ѡ��"]).ToString().Trim());

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        string sʶ���2 = gridView1.GetRowCellValue(i, gridView1.Columns["ʶ���"]).ToString().Trim();
                        if (sʶ��� == sʶ���2)
                        {
                            gridView1.SetRowCellValue(i, gridView1.Columns["ѡ��"], !bѡ��);
                        }
                    }
                }
            }
            catch { }
        }

        private void lookUpEdit�ڼ�_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                dateEdit�Ƶ�����1.Text = lookUpEdit���.Text.Trim() + "-" + lookUpEdit�ڼ�.Text.Trim() + "-01";
                dateEdit�Ƶ�����2.Text = Convert.ToDateTime(lookUpEdit���.Text.Trim() + "-" + lookUpEdit�ڼ�.Text.Trim() + "-01").AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");
            }
            catch { }

        }

        private void chkȫѡ_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridColѡ��, chkȫѡ.Checked);
                }
            }
            catch { }
        }
    }
}