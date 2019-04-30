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
    public partial class 凭证传递 : UserControl
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

        public 凭证传递()
        {
            InitializeComponent();
        }

        private void ProjectManager_Load(object sender, EventArgs e)
        {
            try
            {
                GetLookUp();

                if (lookUpEdit来源帐套.EditValue.ToString().Trim() != "100" && lookUpEdit来源帐套.EditValue.ToString().Trim() != "666")
                {
                    btnSave.Enabled = false;
                    btnSel.Enabled = false;
                    throw new Exception("只有帐套100，666可以作为源帐套");
                }

                if (lookUpEdit来源帐套.EditValue.ToString().Trim() == "100")
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
                MessageBox.Show("加载数据失败：" + ee.Message);
            }
        }

        private void GetLookUp()
        {
            string sSQL = @"
SELECT DISTINCT A.cAcc_Id as 帐套号,'[' + cast(A.cAcc_Id as varchar(3)) + ']' + A.cAcc_Name as 帐套 
FROM UFSystem.dbo.UA_Account A,UFSystem.dbo.UA_period P  
WHERE A.cAcc_Id=P.cAcc_Id AND (P.bIsDelete=0 OR P.bIsDelete IS NULL) 
ORDER BY A.cAcc_Id,'[' + cast(A.cAcc_Id as varchar(3)) + ']' + A.cAcc_Name
";

            DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];

            lookUpEdit来源帐套.Properties.DataSource = dt;

            lookUpEdit来源帐套.EditValue = sAccID;

            dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "年度";
            dt.Columns.Add(dc);

            DataRow dr = dt.NewRow();
            dr["年度"] = DateTime.Now.AddYears(-1).ToString("yyyy");
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["年度"] = DateTime.Now.ToString("yyyy");
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["年度"] = DateTime.Now.AddYears(1).ToString("yyyy");
            dt.Rows.Add(dr);
            lookUpEdit年度.Properties.DataSource = dt;
            lookUpEdit年度.EditValue = DateTime.Now.ToString("yyyy");

            dt = new DataTable();
            dc = new DataColumn();
            dc.ColumnName = "期间";
            dt.Columns.Add(dc);

            for (int i = 1; i <= 12; i++)
            {
                dr = dt.NewRow();
                dr["期间"] = i.ToString();
                dt.Rows.Add(dr);
            }
          
            lookUpEdit期间.Properties.DataSource = dt;
            lookUpEdit期间.EditValue = DateTime.Now.Month.ToString().Trim();

            sSQL = "select distinct cbill  from gl_accvouch order by cbill";
            dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            lookUpEdit制单人.Properties.DataSource = dt;

            sSQL = "select distinct ccode as 科目编码 from code where isnull(bend,0) = 1 order by ccode ";
            dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            ItemLookUpEdit科目编码.DataSource = dt;

            dt = new DataTable();
            dc = new DataColumn();
            dc.ColumnName = "归属公司";
            dt.Columns.Add(dc);
            dr = dt.NewRow();
            dr["归属公司"] = "";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["归属公司"] = "亚太";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["归属公司"] = "泛威";
            dt.Rows.Add(dr);
            ItemLookUpEdit归属公司.DataSource = dt;
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

                if (lookUpEdit来源帐套.Text.Trim() == "")
                {
                    throw new Exception("来源帐套不能为空");
                }

                if (lookUpEdit年度.Text.Trim() == "")
                {
                    throw new Exception("年度不能为空");
                }
                if (lookUpEdit期间.Text.Trim() == "")
                {
                    throw new Exception("期间不能为空");
                }


                //string s年度 = lookUpEdit年度.EditValue.ToString().Trim();
                //sSQL = "select * from  bbb..GL_mend where iyear = '" + s年度 + "' and iperiod = '" + lookUpEdit期间.Text.Trim() + "'";
                //sSQL = sSQL.Replace("bbb", s目的帐套);
                //dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                //if (dt == null || dt.Rows.Count == 0)
                //{
                //    throw new Exception("目的帐套不存在对应会计期间");
                //}
                //if (Convert.ToBoolean(dt.Rows[0]["bflag"]))
                //{
                //    throw new Exception("目的帐套已经结账");
                //}

                //                string sErr = "";

                string sSQL = "";

                #region 100帐套转出
                if (lookUpEdit来源帐套.EditValue.ToString().Trim() == "100")
                {
                    sSQL = "select distinct ctext1 from aaa..GL_accvouch where isnull(ctext1,'') <> '' and iyear = '111111' and iperiod = '222222'";
                    sSQL = sSQL.Replace("111111", lookUpEdit年度.Text.Trim());
                    sSQL = sSQL.Replace("222222", lookUpEdit期间.Text.Trim());
                    sSQL = sSQL.Replace("aaa", "ufdata_003_2014");
                    DataTable dtHav亚太 = SqlHelper.ExecuteDataset(Conn2, CommandType.Text, sSQL).Tables[0];
                    string sHav亚太 = @"'TestNull'";
                    StringBuilder sHavBud亚太 = new StringBuilder();
                    if (dtHav亚太 != null && dtHav亚太.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtHav亚太.Rows.Count; i++)
                        {
                            if (sHavBud亚太.ToString().Trim() == "")
                            {
                                sHavBud亚太.Append("'" + dtHav亚太.Rows[i]["ctext1"].ToString().Trim() + "'");
                            }
                            else
                            {
                                sHavBud亚太.Append(",'" + dtHav亚太.Rows[i]["ctext1"].ToString().Trim() + "'");
                            }
                        }
                        sHav亚太 = sHavBud亚太.ToString().Trim();
                    }

                    sSQL = "select distinct ctext1 from aaa..GL_accvouch where isnull(ctext1,'') <> '' and iyear = '111111' and iperiod = '222222'";
                    sSQL = sSQL.Replace("111111", lookUpEdit年度.Text.Trim());
                    sSQL = sSQL.Replace("222222", lookUpEdit期间.Text.Trim());
                    sSQL = sSQL.Replace("aaa", "ufdata_009_2014");
                    DataTable dtHav泛威 = SqlHelper.ExecuteDataset(Conn2, CommandType.Text, sSQL).Tables[0];
                    string sHav泛威 = @"'TestNull'";
                    StringBuilder sHavBud泛威 = new StringBuilder();
                    if (dtHav泛威 != null && dtHav泛威.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtHav泛威.Rows.Count; i++)
                        {
                            if (sHavBud泛威.ToString().Trim() == "")
                            {
                                sHavBud泛威.Append("'" + dtHav泛威.Rows[i]["ctext1"].ToString().Trim() + "'");
                            }
                            else
                            {
                                sHavBud泛威.Append(",'" + dtHav泛威.Rows[i]["ctext1"].ToString().Trim() + "'");
                            }
                        }
                        sHav泛威 = sHavBud泛威.ToString().Trim();
                    }


                    if (radio亚太.Checked || radio泛威.Checked)
                    {
                        sSQL = @"
select CAST(0 as bit) as 选择 ,cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) as 凭证号,ino_id
		,b.归属公司,i_id as 自动编号, iperiod as 会计期间, csign as 凭证类别字,  inid as 行号
		,dbill_date as 制单日期, cbill as 制单人, ccheck as 审核人, cbook as 记账人, ibook as 记账标志 
		, cdigest as 摘要, ccode as 科目编码, cexch_name as 币种名称
        ,case when cast(md as decimal(16,2)) = 0 then null else cast(md as decimal(16,2)) end as 借方金额, case when cast(mc as decimal(16,2)) = 0 then null else cast(mc as decimal(16,2)) end  as 贷方金额
        ,case when cast(md_f as decimal(16,2)) = 0 then null else cast(md_f as decimal(16,2)) end  as 外币借方金额, case when cast(mc_f as decimal(16,2)) = 0 then null else cast(mc_f as decimal(16,2)) end   as 外币贷方金额
        ,case when cast(nfrat as decimal(16,2)) = 0 then null else cast(nfrat as decimal(16,2)) end as 汇率
		, nd_s as 数量借方, nc_s as 数量贷方
		, ccus_id as 客户编码, csup_id as 供应商编码
		,cast('999999' as varchar(50))  + right('00' + cast(iperiod as varchar(2)),2) + cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) as 识别号
into #a
from GL_accvouch a left join UFSystem..帐套科目归属 b on a.ccode = b.科目 and b.帐套号 = '555555' 
where 1=1 and iyear = '111111' and iperiod = '222222' and dbill_date >= '333333' and dbill_date <= '444444'
    and cast(iyear as varchar(50))  + right('00' + cast(iperiod as varchar(2)),2) + cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) not in (666666)
order by iyear,iperiod,csign,ino_id,inid

select distinct cast('999999' as varchar(50))  + right('00' + cast(iperiod as varchar(2)),2) + cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) as 识别号
into #b
from GL_accvouch a left join UFSystem..帐套科目归属 b on a.ccode = b.科目 and b.帐套号 = '555555' 
where 22=22 and iyear = '111111' and iperiod = '222222' and dbill_date >= '333333' and dbill_date <= '444444'

select distinct cast('999999' as varchar(50))  + right('00' + cast(iperiod as varchar(2)),2) + cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) as 识别号
into #c
from GL_accvouch a left join UFSystem..帐套科目归属 b on a.ccode = b.科目 and b.帐套号 = '555555' 
where 33=33 and iyear = '111111' and iperiod = '222222' and dbill_date >= '333333' and dbill_date <= '444444'

select #a.*
from #a inner join #b on ltrim(rtrim(#a.识别号)) = ltrim(rtrim(#b.识别号))
where #a.识别号 not in (select 识别号 from #c)

";

                        sSQL = sSQL.Replace("999999", lookUpEdit年度.Text.Substring(2));

                        if (radio亚太.Checked)
                        {
                            sSQL = sSQL.Replace("22=22", "22=22 and b.归属公司 = '亚太'");
                            sSQL = sSQL.Replace("33=33", "33=33 and b.归属公司 <> '亚太' and isnull(b.归属公司,'') <> '' ");
                            sSQL = sSQL.Replace("aaa", "ufdata_003_2014");
                            sSQL = sSQL.Replace("666666", sHav亚太);
                        }
                        if (radio泛威.Checked)
                        {
                            sSQL = sSQL.Replace("22=22", "22=22 and b.归属公司 = '泛威'");
                            sSQL = sSQL.Replace("33=33", "33=33 and b.归属公司 <> '泛威' and isnull(b.归属公司,'') <> '' ");
                            sSQL = sSQL.Replace("aaa", "ufdata_009_2014");
                            sSQL = sSQL.Replace("666666", sHav泛威);
                        }
                    }
                    if (radio全包括.Checked)
                    {
                        //    and cast(iyear as varchar(50))  + right('00' + cast(iperiod as varchar(2)),2) + cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) not in (select distinct ctext1 from aaa..GL_accvouch where isnull(ctext1,'') <> '')
                        //    and cast(iyear as varchar(50))  + right('00' + cast(iperiod as varchar(2)),2) + cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) not in (select distinct ctext1 from bbb..GL_accvouch where isnull(ctext1,'') <> '')

                        sSQL = @"
select CAST(0 as bit) as 选择 ,cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) as 凭证号,ino_id
		,b.归属公司,i_id as 自动编号, iperiod as 会计期间, csign as 凭证类别字,  inid as 行号,csign as 凭证类别字2
		,dbill_date as 制单日期, cbill as 制单人, ccheck as 审核人, cbook as 记账人, ibook as 记账标志 
		, cdigest as 摘要, ccode as 科目编码, cexch_name as 币种名称
        ,case when cast(md as decimal(16,2)) = 0 then null else cast(md as decimal(16,2)) end as 借方金额, case when cast(mc as decimal(16,2)) = 0 then null else cast(mc as decimal(16,2)) end  as 贷方金额
        ,case when cast(md_f as decimal(16,2)) = 0 then null else cast(md_f as decimal(16,2)) end  as 外币借方金额, case when cast(mc_f as decimal(16,2)) = 0 then null else cast(mc_f as decimal(16,2)) end   as 外币贷方金额
		,case when cast(nfrat as decimal(16,2)) = 0 then null else cast(nfrat as decimal(16,2)) end as 汇率
        , nd_s as 数量借方, nc_s as 数量贷方
		, ccus_id as 客户编码, csup_id as 供应商编码
		,cast('999999' as varchar(50))  + right('00' + cast(iperiod as varchar(2)),2) + cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) as 识别号
into #a
from GL_accvouch a left join UFSystem..帐套科目归属 b on a.ccode = b.科目 and b.帐套号 = '555555' 
where 1=1 and iyear = '111111' and iperiod = '222222' and dbill_date >= '333333' and dbill_date <= '444444'
     and cast(iyear as varchar(50))  + right('00' + cast(iperiod as varchar(2)),2) + cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) not in(666666)
     and cast(iyear as varchar(50))  + right('00' + cast(iperiod as varchar(2)),2) + cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) not in(777777)
order by iyear,iperiod,csign,ino_id,inid


select 识别号,count(1)  as 计数
into #b
from 
(
	select distinct cast('999999' as varchar(50))  + right('00' + cast(iperiod as varchar(2)),2) + cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) as 识别号
		,b.归属公司
	from GL_accvouch a left join UFSystem..帐套科目归属 b on a.ccode = b.科目 and b.帐套号 = '100' 
	where 33=33 and iyear = '111111' and iperiod = '222222' and dbill_date >= '333333' and dbill_date <= '444444'
		 and isnull(b.归属公司,'') <> ''
)a
group by 识别号
having 2=2

select *,cast (null as varchar(50)) as sErr
from #a
where #a.识别号 in (select 识别号 from #b)

";
                        sSQL = sSQL.Replace("999999", lookUpEdit年度.Text.Substring(2));
                        sSQL = sSQL.Replace("aaa", "ufdata_003_2014");
                        sSQL = sSQL.Replace("bbb", "ufdata_009_2014");
                        sSQL = sSQL.Replace("666666", sHav亚太);
                        sSQL = sSQL.Replace("777777", sHav泛威);
                        if (radio全包括.Checked)
                        {
                            sSQL = sSQL.Replace("2=2", "count(1) > 1");
                        }
                        if (radio全不包括.Checked)
                        {
                            sSQL = sSQL.Replace("2=2", "count(1) < 1");
                        }
                    }

                    if (radio全不包括.Checked)
                    {
                        //and cast(iyear as varchar(50))  + right('00' + cast(iperiod as varchar(2)),2) + cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) not in (select distinct ctext1 from aaa..GL_accvouch where isnull(ctext1,'') <> '')
                        //and cast(iyear as varchar(50))  + right('00' + cast(iperiod as varchar(2)),2) + cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) not in (select distinct ctext1 from bbb..GL_accvouch where isnull(ctext1,'') <> '')

                        sSQL = @"
select CAST(0 as bit) as 选择 ,cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) as 凭证号,ino_id
		,b.归属公司,i_id as 自动编号, iperiod as 会计期间, csign as 凭证类别字,  inid as 行号
		,dbill_date as 制单日期, cbill as 制单人, ccheck as 审核人, cbook as 记账人, ibook as 记账标志 
		, cdigest as 摘要, ccode as 科目编码, cexch_name as 币种名称
        ,case when cast(md as decimal(16,2)) = 0 then null else cast(md as decimal(16,2)) end as 借方金额, case when cast(mc as decimal(16,2)) = 0 then null else cast(mc as decimal(16,2)) end  as 贷方金额
        ,case when cast(md_f as decimal(16,2)) = 0 then null else cast(md_f as decimal(16,2)) end  as 外币借方金额, case when cast(mc_f as decimal(16,2)) = 0 then null else cast(mc_f as decimal(16,2)) end   as 外币贷方金额
		,case when cast(nfrat as decimal(16,2)) = 0 then null else cast(nfrat as decimal(16,2)) end as 汇率
        , nd_s as 数量借方, nc_s as 数量贷方
		, ccus_id as 客户编码, csup_id as 供应商编码
		,cast('999999' as varchar(50))  + right('00' + cast(iperiod as varchar(2)),2) + cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) as 识别号
into #a
from GL_accvouch a left join UFSystem..帐套科目归属 b on a.ccode = b.科目 and b.帐套号 = '555555' 
where 1=1 and iyear = '111111' and iperiod = '222222' and dbill_date >= '333333' and dbill_date <= '444444'
order by iyear,iperiod,csign,ino_id,inid


select distinct cast('999999' as varchar(50))  + right('00' + cast(iperiod as varchar(2)),2) + cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) as 识别号
into #b
from GL_accvouch a left join UFSystem..帐套科目归属 b on a.ccode = b.科目 and b.帐套号 = '555555' 
where 22=22 and iyear = '111111' and iperiod = '222222' and dbill_date >= '333333' and dbill_date <= '444444'

select distinct cast('999999' as varchar(50))  + right('00' + cast(iperiod as varchar(2)),2) + cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) as 识别号
into #c
from GL_accvouch a left join UFSystem..帐套科目归属 b on a.ccode = b.科目 and b.帐套号 = '555555' 
where 33=33 and iyear = '111111' and iperiod = '222222' and dbill_date >= '333333' and dbill_date <= '444444'

select #a.*
from #a inner join #b on ltrim(rtrim(#a.识别号)) = ltrim(rtrim(#b.识别号))
where #a.识别号 not in (select 识别号 from #c)
";

                        sSQL = sSQL.Replace("999999", lookUpEdit年度.Text.Substring(2));
                        sSQL = sSQL.Replace("22=22", "22=22 and isnull(b.归属公司,'') = ''");
                        sSQL = sSQL.Replace("33=33", "33=33 and (b.归属公司 = '泛威' or b.归属公司 = '亚太') ");
                        sSQL = sSQL.Replace("aaa", "ufdata_003_2014");
                        sSQL = sSQL.Replace("bbb", "ufdata_009_2014");
                    }

                    sSQL = sSQL.Replace("111111", lookUpEdit年度.Text.Trim());
                    sSQL = sSQL.Replace("222222", lookUpEdit期间.Text.Trim());
                    sSQL = sSQL.Replace("333333", dateEdit制单日期1.DateTime.ToString("yyyy-MM-dd"));
                    sSQL = sSQL.Replace("444444", dateEdit制单日期2.DateTime.ToString("yyyy-MM-dd"));
                    sSQL = sSQL.Replace("555555", lookUpEdit来源帐套.EditValue.ToString().Trim());




                    if (radio未审核.Checked)
                    {
                        sSQL = sSQL.Replace("1=1", "1=1 and isnull(ccheck,'') = ''");
                    }
                    if (radio已审核.Checked)
                    {
                        sSQL = sSQL.Replace("1=1", "1=1 and isnull(ccheck,'') <> ''");
                    }
                    if (lookUpEdit制单人.Text.Trim() != "")
                    {
                        sSQL = sSQL.Replace("1=1", "1=1 and isnull(cbill,'') = '" + lookUpEdit制单人.Text.Trim() + "'");
                    }

                    DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                    gridControl1.DataSource = dt;

                    string sErr = "";
                    //设定对方科目
                    if (radio全包括.Checked)
                    {
                        sSQL = "select * from UFSystem..帐套科目归属 where 帐套号 = '100'";
                        DataTable dt帐套科目归属 = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];

                        for (int i = dt.Rows.Count-1; i >=0 ; i--)
                        {
                            string s科目 = dt.Rows[i]["科目编码"].ToString().Trim();
                            string s归属公司 = dt.Rows[i]["归属公司"].ToString().Trim();
                            decimal d借 = SqlHelper.ReturnObjectToDecimal(dt.Rows[i]["借方金额"], 2);
                            decimal d贷 = SqlHelper.ReturnObjectToDecimal(dt.Rows[i]["贷方金额"], 2);
                            string s凭证类别 = dt.Rows[i]["凭证类别字"].ToString().Trim();
                            string s凭证类别2 = "";

                            if (s凭证类别 == "付" && d借 > 0)
                                    s凭证类别2 = "收";

                            if (s凭证类别 == "付" && d贷 > 0)
                                s凭证类别2 = "付";


                            if (s凭证类别 == "收" && d借 > 0)
                                s凭证类别2 = "付";

                            if (s凭证类别 == "收" && d贷 > 0)
                                s凭证类别2 = "收";

                            if (s凭证类别 == "转")
                            {
                                s凭证类别2 = "转";
                            }

                            dt.Rows[i]["凭证类别字2"] = s凭证类别2;

                            DataRow[] dr对方科目 = dt帐套科目归属.Select("科目 = '" + s科目 + "' and 归属公司 = '" + s归属公司 + "'");
                            if (dr对方科目.Length == 0)
                            {

                                if (radio全包括.Checked)
                                {
                                    for (int ii = 0; ii < dr对方科目.Length; ii++)
                                    {
                                        dr对方科目[ii]["serr"] = "Err";
                                    }
                                    sErr = sErr + "科目" + s科目 + " 未设置对方科目\n";
                                }
                                else
                                {
                                    sErr = sErr + "行" + (i + 1).ToString() + " 未设置对方科目\n";
                                }
                                continue;
                            }
                            string s对方科目 = "@" + dr对方科目[0]["对方科目"].ToString().Trim();
                            if (s对方科目 == "")
                            {
                                if (radio全包括.Checked)
                                {
                                    for (int ii = 0; ii < dr对方科目.Length; ii++)
                                    {
                                        dr对方科目[ii]["serr"] = "Err";
                                    }
                                    sErr = sErr + "科目" + s科目 + " 未设置对方科目\n";
                                }
                                else
                                {
                                    sErr = sErr + "行" + (i + 1).ToString() + " 未设置对方科目\n";
                                }
                                continue;
                            }
                            string s对方供应商 = "@" + dr对方科目[0]["对方供应商"].ToString().Trim();
                            //if (dr对方科目[0]["对方供应商"].ToString().Trim() != "")
                            //{
                            //    s对方供应商 = "'" + dr对方科目[0]["对方供应商"].ToString().Trim() + "'";
                            //}
                            string s对方客户 = "@" + dr对方科目[0]["对方客户"].ToString().Trim();
                            //if (dr对方科目[0]["对方客户"].ToString().Trim() != "")
                            //{
                            //    s对方客户 = "'" + dr对方科目[0]["对方客户"].ToString().Trim() + "'";
                            //}

                            DataRow dr = dt.Rows[i];
                            DataRow drNew = dt.NewRow();
                            drNew.ItemArray = dr.ItemArray;
                            drNew[15] = s对方科目;
                            decimal d17 = SqlHelper.ReturnObjectToDecimal(drNew[17]);//借方金额
                            decimal d18 = SqlHelper.ReturnObjectToDecimal(drNew[18]);//贷方金额
                            decimal d19 = SqlHelper.ReturnObjectToDecimal(drNew[19]);//借方金额
                            decimal d20 = SqlHelper.ReturnObjectToDecimal(drNew[20]);//贷方金额

                            drNew[17] = d18;
                            drNew[18] = d17;
                            drNew[19] = d20;
                            drNew[20] = d19;
                            drNew["供应商编码"] = s对方供应商;
                            drNew["客户编码"] = s对方客户;

                          
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

                #region 666帐套转出
                if (lookUpEdit来源帐套.EditValue.ToString().Trim() == "666")
                {
                    sSQL = "select distinct ctext1 from aaa..GL_accvouch where isnull(ctext1,'') <> '' and iyear = '111111' and iperiod = '222222'";
                    sSQL = sSQL.Replace("111111", lookUpEdit年度.Text.Trim());
                    sSQL = sSQL.Replace("222222", lookUpEdit期间.Text.Trim());
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
select CAST(0 as bit) as 选择 ,cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) as 凭证号,ino_id
		,b.归属公司,i_id as 自动编号, iperiod as 会计期间, csign as 凭证类别字,  inid as 行号
		,dbill_date as 制单日期, cbill as 制单人, ccheck as 审核人, cbook as 记账人, ibook as 记账标志 
		, cdigest as 摘要, ccode as 科目编码, cexch_name as 币种名称
        ,case when cast(md as decimal(16,2)) = 0 then null else cast(md as decimal(16,2)) end as 借方金额, case when cast(mc as decimal(16,2)) = 0 then null else cast(mc as decimal(16,2)) end  as 贷方金额
        ,case when cast(md_f as decimal(16,2)) = 0 then null else cast(md_f as decimal(16,2)) end  as 外币借方金额, case when cast(mc_f as decimal(16,2)) = 0 then null else cast(mc_f as decimal(16,2)) end   as 外币贷方金额
		, nfrat as 汇率, nd_s as 数量借方, nc_s as 数量贷方
		, ccus_id as 客户编码, csup_id as 供应商编码
		,cast('999999' as varchar(50))  + right('00' + cast(iperiod as varchar(2)),2) + cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) as 识别号
from GL_accvouch a left join UFSystem..帐套科目归属 b on a.ccode = b.科目 and b.帐套号 = '555555' 
where 1=1 and iyear = '111111' and iperiod = '222222' and dbill_date >= '333333' and dbill_date <= '444444'
    and cast(iyear as varchar(50))  + right('00' + cast(iperiod as varchar(2)),2) + cast(csign as varchar(50)) + right('0000' + cast(ino_id as varchar(4)),4) not in (666666)
order by iyear,iperiod,csign,ino_id,inid
";

                    sSQL = sSQL.Replace("999999", lookUpEdit年度.Text.Substring(2));
                    sSQL = sSQL.Replace("111111", lookUpEdit年度.Text.Trim());
                    sSQL = sSQL.Replace("222222", lookUpEdit期间.Text.Trim());
                    sSQL = sSQL.Replace("333333", dateEdit制单日期1.DateTime.ToString("yyyy-MM-dd"));
                    sSQL = sSQL.Replace("444444", dateEdit制单日期2.DateTime.ToString("yyyy-MM-dd"));
                    sSQL = sSQL.Replace("555555", lookUpEdit来源帐套.EditValue.ToString().Trim());
                    sSQL = sSQL.Replace("666666", sHav);

                    if (radio未审核.Checked)
                    {
                        sSQL = sSQL.Replace("1=1", "1=1 and isnull(ccheck,'') = ''");
                    }
                    if (radio已审核.Checked)
                    {
                        sSQL = sSQL.Replace("1=1", "1=1 and isnull(ccheck,'') <> ''");
                    }
                    if (lookUpEdit制单人.Text.Trim() != "")
                    {
                        sSQL = sSQL.Replace("1=1", "1=1 and isnull(cbill,'') = '" + lookUpEdit制单人.Text.Trim() + "'");
                    }
                    DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                    gridControl1.DataSource = dt;
                }
                #endregion

                label来源帐套.Text = lookUpEdit来源帐套.EditValue.ToString().Trim();
                label年度.Text = lookUpEdit年度.EditValue.ToString().Trim();
                label期间.Text = lookUpEdit期间.EditValue.ToString().Trim();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败:" + ee.Message);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
                sF.Filter = "Excel文件(*.xls)|*.xls|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridView1.ExportToXls(sF.FileName);
                    MessageBox.Show("导出Excel成功\n\t路径：" + sF.FileName);
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
                oFile.Filter = "Excel文件|*.xls|Excel文件|*.xlsx";
                if (oFile.ShowDialog() == DialogResult.OK)
                {
                    string sFilePath = oFile.FileName;
                    string sSQL = "select * from [对照档案$]";

                    DataTable dt = clsExcel.ExcelToDT(sFilePath, sSQL, true);

                    gridView1.Columns.Clear();

                    gridControl1.DataSource = dt;

                    if (dt == null || dt.Rows.Count < 1)
                        throw new Exception("加载的文件没有数据，请核实后继续");
                }
                else
                {
                    throw new Exception("取消导入");
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.richTextBox1.Text = ee.Message;
                f.Text = "加载失败";
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

                if (lookUpEdit来源帐套.EditValue.ToString().Trim() != label来源帐套.Text.Trim() || lookUpEdit年度.EditValue.ToString().Trim() != label年度.Text.Trim() || lookUpEdit期间.EditValue.ToString().Trim() != label期间.Text.Trim())
                {
                    throw new Exception("参数已经变化，请重新点击过滤按钮");
                }

                string sErr = "";
                string sSQL = "";

                int iFoc = 0;
                if (gridView1.FocusedRowHandle > 0)
                    iFoc = gridView1.FocusedRowHandle;

                SqlConnection conn2 = new SqlConnection(Conn2);
                conn2.Open();
                //启用事务
                SqlTransaction tran = conn2.BeginTransaction();

                try
                {
                    int iCou = 0;

                    string s年度期间 = lookUpEdit年度.EditValue.ToString().Trim() + lookUpEdit期间.EditValue.ToString().Trim();
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (!Convert.ToBoolean(gridView1.GetRowCellValue(i, gridCol选择)))
                            continue;

                        string s年度 = lookUpEdit年度.EditValue.ToString().Trim();
                        string s期间 = lookUpEdit期间.EditValue.ToString().Trim();
                        if (s期间.Length == 1)
                            s年度期间 = lookUpEdit年度.EditValue.ToString().Trim() + "0" + lookUpEdit期间.EditValue.ToString().Trim();

                        string s凭证类别 = gridView1.GetRowCellValue(i, gridCol凭证类别字).ToString().Trim();
                        string s凭证号 = gridView1.GetRowCellValue(i, gridCol凭证号).ToString().Trim();
                        string s科目编码 = gridView1.GetRowCellValue(i, gridCol科目编码).ToString().Trim();
                        string s客户编码 = gridView1.GetRowCellValue(i, gridCol客户编码).ToString().Trim();
                        string s供应商编码 = gridView1.GetRowCellValue(i, gridCol供应商编码).ToString().Trim();
                        decimal d借方金额 = SqlHelper.ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol借方金额));
                        decimal d外币借方金额 = SqlHelper.ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol外币借方金额));
                        decimal d贷方金额 = SqlHelper.ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol贷方金额));
                        decimal d外币贷方金额 = SqlHelper.ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol外币贷方金额));
                        decimal d汇率 = SqlHelper.ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol汇率));
                        string s币种名称 = gridView1.GetRowCellValue(i, gridCol币种名称).ToString().Trim();
                        if (s币种名称 == "")
                            s币种名称 = "null";
                        else
                            s币种名称 = "'" + s币种名称 + "'";

                        string s摘要 = gridView1.GetRowCellValue(i, gridCol摘要).ToString().Trim();
                        string s识别号 = gridView1.GetRowCellValue(i, gridCol识别号).ToString().Trim();
                        int i凭证号 = 0;


                        #region 单一帐套传输数据

                        if ((lookUpEdit来源帐套.EditValue.ToString().Trim() == "100" && (radio泛威.Checked || radio亚太.Checked)) || lookUpEdit来源帐套.EditValue.ToString().Trim() == "666")
                        {
                            if (radio泛威.Checked || radio亚太.Checked)
                            {
                                string s目的帐套 = "ufdata_009_2014";   //泛威
                                sSQL = "select * from ufsystem.dbo.帐套档案对照表 where 来源帐套 = '100' and 对照帐套 = '009'";

                                if (lookUpEdit来源帐套.EditValue.ToString().Trim() == "666")
                                {
                                    s目的帐套 = "ufdata_001_2014";

                                    sSQL = "select * from ufsystem.dbo.帐套档案对照表 where 来源帐套 = '666' and 对照帐套 = '001'";
                                }
                                else
                                {
                                    if (radio亚太.Checked)
                                    {
                                        s目的帐套 = "ufdata_003_2014";

                                        sSQL = "select * from ufsystem.dbo.帐套档案对照表 where 来源帐套 = '100' and 对照帐套 = '003'";
                                    }
                                }
                                DataTable dt对照信息 = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];

                                //string s科目
                                DataRow[] dr目的帐套科目档案 = dt对照信息.Select("类型 = '科目编码' and 编码 = '" + s科目编码 + "'");
                                if (dr目的帐套科目档案.Length == 0)
                                {
                                    sErr = sErr + "行" + (i + 1).ToString() + " 未设置科目对照\n";
                                    continue;
                                }
                                else
                                {
                                    s科目编码 = dr目的帐套科目档案[0]["对照编码"].ToString().Trim();
                                    if (s科目编码 == "")
                                    {
                                        sErr = sErr + "行" + (i + 1).ToString() + " 未设置科目对照\n";
                                        continue;
                                    }
                                }

                                if (s客户编码 != "")
                                {
                                    DataRow[] dr = dt对照信息.Select("类型 = '客户编码' and 编码 = '" + s客户编码 + "'");
                                    if (dr.Length > 0 && dr[0]["对照编码"].ToString().Trim() != "")
                                    {
                                        s客户编码 = "'" + dr[0]["对照编码"].ToString().Trim() + "'";
                                    }
                                    else
                                    {
                                        sErr = sErr + "行" + (i + 1).ToString() + " 未设置客户对照\n";
                                        continue;
                                    }
                                }
                                else
                                {
                                    s客户编码 = "null";
                                }
                                if (s供应商编码 != "")
                                {
                                    DataRow[] dr = dt对照信息.Select("类型 = '供应商编码' and 编码 = '" + s供应商编码 + "'");
                                    if (dr.Length > 0 && dr[0]["对照编码"].ToString().Trim() != "")
                                    {
                                        s供应商编码 = "'" + dr[0]["对照编码"].ToString().Trim() + "'";
                                    }
                                    else
                                    {
                                        sErr = sErr + "行" + (i + 1).ToString() + " 未设置供应商编码对照\n";
                                        continue;
                                    }
                                }
                                else
                                {
                                    s供应商编码 = "null";
                                }

                                sSQL = "select * from aaa..gl_accvouch where ctext1 = '" + s识别号 + "'";
                                sSQL = sSQL.Replace("aaa", s目的帐套);
                                DataTable dt = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    i凭证号 = SqlHelper.ReturnObjectToInt(dt.Rows[0]["ino_id"]);
                                }
                                else
                                {
                                    sSQL = "select isnull(max(ino_id),0) as ino_id from aaa..gl_accvouch where iyear = '" + s年度 + "' and iperiod = " + s期间 + " and csign = '" + s凭证类别 + "' ";
                                    sSQL = sSQL.Replace("aaa", s目的帐套);
                                    dt = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                    i凭证号 = SqlHelper.ReturnObjectToInt(dt.Rows[0]["ino_id"]) + 1;
                                }

                                sSQL = "select * from aaa..dsign where csign = '" + s凭证类别 + "'";
                                sSQL = sSQL.Replace("aaa", s目的帐套);
                                DataTable dt凭证类型 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                if (dt凭证类型 == null || dt凭证类型.Rows.Count == 0)
                                {
                                    sErr = sErr + "行" + (i + 1).ToString() + " 未设置凭证类型对照\n";
                                    continue;
                                }


                                sSQL = "INSERT INTO aaa..gl_accvouch (iperiod, csign, isignseq, ino_id, inid, dbill_date, idoc, cbill, ccheck, cbook" +
                                                  ", ibook, ccashier, iflag, ctext2, cdigest, ccode, cexch_name, md, mc, " +
                                                  "md_f, mc_f, nfrat, nd_s, nc_s, csettle, cn_id, dt_date, cdept_id, cperson_id" +
                                                  ", ccus_id, csup_id, citem_id, citem_class, cname, ccode_equal, iflagbank, iflagPerson,bdelete, coutaccset " +
                                                  ",iyear,iYPeriod ,ctext1) " +
                                       "values(" + s期间 + ",'" + s凭证类别 + "','" + dt凭证类型.Rows[0]["isignseq"] + "'," + i凭证号 + ",'" + gridView1.GetRowCellValue(i, gridCol行号).ToString().Trim() + "','" + gridView1.GetRowCellValue(i, gridCol制单日期).ToString().Trim() + "',-1,'" + gridView1.GetRowCellValue(i, gridCol制单人).ToString().Trim() + "',null,null" +
                                                ",0,null,null,null,'" + gridView1.GetRowCellValue(i, gridCol摘要).ToString().Trim() + "','" + s科目编码 + "'," + s币种名称 + "," + SqlHelper.ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol借方金额), 2) + "," + SqlHelper.ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol贷方金额), 2) + "" +
                                                "," + SqlHelper.ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol外币借方金额), 2) + "," + SqlHelper.ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol外币贷方金额), 2) + "," + d汇率 + ",0,0,null,null,null,null,null" +
                                                "," + s客户编码 + "," + s供应商编码 + ",null,null,null,null,null,null,null,null" +
                                                ",'" + s年度 + "','" + s年度期间 + "','" + s识别号 + "')";


                                sSQL = sSQL.Replace("aaa", s目的帐套);

                                iCou = iCou + SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                        }

                        #endregion

                        #region 100帐套 全不包括

                        if (lookUpEdit来源帐套.EditValue.ToString().Trim() == "100" && radio全不包括.Checked)
                        {
                            string s归属公司 = gridView1.GetRowCellValue(i, gridCol归属公司).ToString().Trim();
                            if (s归属公司 == "")
                            {
                                sErr = sErr + "行" + (i + 1).ToString() + " 未设置归属公司\n";
                                continue;
                            }

                            string s目的帐套 = "ufdata_009_2014";       //泛威
                            if (s归属公司 == "亚太")
                            {
                                s目的帐套 = "ufdata_003_2014";
                            }

                            sSQL = "select * from ufsystem.dbo.帐套档案对照表 where 来源帐套 = '100' and (对照帐套 = '003' or 对照帐套 = '009')";
                            DataTable dt对照信息 = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];

                            //string s科目
                            DataRow[] dr目的帐套科目档案 = dt对照信息.Select("类型 = '科目编码' and 编码 = '" + s科目编码 + "'");
                            if (dr目的帐套科目档案.Length == 0)
                            {
                                sErr = sErr + "行" + (i + 1).ToString() + " 未设置科目对照\n";
                                continue;
                            }
                            else
                            {
                                s科目编码 = dr目的帐套科目档案[0]["对照编码"].ToString().Trim();
                                if (s科目编码 == "")
                                {
                                    sErr = sErr + "行" + (i + 1).ToString() + " 未设置科目对照\n";
                                    continue;
                                }
                            }


                            if (s客户编码 != "")
                            {
                                DataRow[] dr = dt对照信息.Select("类型 = '客户编码' and 编码 = '" + s客户编码 + "'");
                                if (dr.Length > 0 && dr[0]["对照编码"].ToString().Trim() != "")
                                {
                                    s客户编码 = "'" + dr[0]["对照编码"].ToString().Trim() + "'";
                                }
                                else
                                {
                                    sErr = sErr + "行" + (i + 1).ToString() + " 未设置客户对照\n";
                                    continue;
                                }
                            }
                            else
                            {
                                s客户编码 = "null";
                            }
                            if (s供应商编码 != "")
                            {
                                DataRow[] dr = dt对照信息.Select("类型 = '供应商编码' and 编码 = '" + s供应商编码 + "'");
                                if (dr.Length > 0 && dr[0]["对照编码"].ToString().Trim() != "")
                                {
                                    s供应商编码 = "'" + dr[0]["对照编码"].ToString().Trim() + "'";
                                }
                                else
                                {
                                    sErr = sErr + "行" + (i + 1).ToString() + " 未设置供应商编码对照\n";
                                    continue;
                                }
                            }
                            else
                            {
                                s供应商编码 = "null";
                            }

                            sSQL = "select * from aaa..gl_accvouch where ctext1 = '" + s识别号 + "'";
                            sSQL = sSQL.Replace("aaa", s目的帐套);
                            DataTable dt = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                i凭证号 = SqlHelper.ReturnObjectToInt(dt.Rows[0]["ino_id"]);
                            }
                            else
                            {
                                sSQL = "select isnull(max(ino_id),0) as ino_id from aaa..gl_accvouch where iyear = '" + s年度 + "' and iperiod = " + s期间 + " and csign = '" + s凭证类别 + "' ";
                                sSQL = sSQL.Replace("aaa", s目的帐套);
                                dt = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                i凭证号 = SqlHelper.ReturnObjectToInt(dt.Rows[0]["ino_id"]) + 1;
                            }

                            sSQL = "select * from aaa..dsign where csign = '" + s凭证类别 + "'";
                            sSQL = sSQL.Replace("aaa", s目的帐套);
                            DataTable dt凭证类型 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dt凭证类型 == null || dt凭证类型.Rows.Count == 0)
                            {
                                sErr = sErr + "行" + (i + 1).ToString() + " 未设置凭证类型对照\n";
                                continue;
                            }


                            sSQL = "INSERT INTO aaa..gl_accvouch (iperiod, csign, isignseq, ino_id, inid, dbill_date, idoc, cbill, ccheck, cbook" +
                                              ", ibook, ccashier, iflag, ctext2, cdigest, ccode, cexch_name, md, mc, " +
                                              "md_f, mc_f, nfrat, nd_s, nc_s, csettle, cn_id, dt_date, cdept_id, cperson_id" +
                                              ", ccus_id, csup_id, citem_id, citem_class, cname, ccode_equal, iflagbank, iflagPerson,bdelete, coutaccset " +
                                              ",iyear,iYPeriod ,ctext1) " +
                                   "values(" + s期间 + ",'" + s凭证类别 + "','" + dt凭证类型.Rows[0]["isignseq"] + "'," + i凭证号 + ",'" + gridView1.GetRowCellValue(i, gridCol行号).ToString().Trim() + "','" + gridView1.GetRowCellValue(i, gridCol制单日期).ToString().Trim() + "',-1,'" + gridView1.GetRowCellValue(i, gridCol制单人).ToString().Trim() + "',null,null" +
                                            ",0,null,null,null,'" + gridView1.GetRowCellValue(i, gridCol摘要).ToString().Trim() + "'," + s科目编码 + "','" + s币种名称 + "," + SqlHelper.ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol借方金额), 2) + "," + SqlHelper.ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol贷方金额), 2) + "" +
                                            "," + SqlHelper.ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol外币借方金额), 2) + "," + SqlHelper.ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol外币贷方金额), 2) + "," + d汇率 + ",0,0,null,null,null,null,null" +
                                            "," + s客户编码 + "," + s供应商编码 + ",null,null,null,null,null,null,null,null" +
                                            ",'" + s年度 + "','" + s年度期间 + "','" + s识别号 + "')";


                            sSQL = sSQL.Replace("aaa", s目的帐套);

                            iCou = iCou + SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        #endregion

                        #region 100帐套 全包括

                        if (lookUpEdit来源帐套.EditValue.ToString().Trim() == "100" && radio全包括.Checked)
                        {
                            string s归属公司 = gridView1.GetRowCellValue(i, gridCol归属公司).ToString().Trim();
                            if (s归属公司 == "")
                            {
                                sErr = sErr + "行" + (i + 1).ToString() + " 未设置归属公司\n";
                                continue;
                            }

                            string s目的帐套 = "ufdata_009_2014";       //泛威
                            if (s归属公司 == "亚太")
                            {
                                s目的帐套 = "ufdata_003_2014";
                            }

                            sSQL = "select * from ufsystem.dbo.帐套档案对照表 where 来源帐套 = '100' and (对照帐套 = '003' or 对照帐套 = '009')";
                            DataTable dt对照信息 = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];

                            //string s科目
                            if (s科目编码.Trim() != "" && s科目编码.Substring(0, 1) != "@")
                            {
                                DataRow[] dr目的帐套科目档案 = dt对照信息.Select("类型 = '科目编码' and 编码 = '" + s科目编码 + "'");
                                if (dr目的帐套科目档案.Length == 0)
                                {
                                    sErr = sErr + "行" + (i + 1).ToString() + " 未设置科目对照\n";
                                    continue;
                                }
                                else
                                {
                                    s科目编码 = dr目的帐套科目档案[0]["对照编码"].ToString().Trim();
                                    if (s科目编码 == "")
                                    {
                                        sErr = sErr + "行" + (i + 1).ToString() + " 未设置科目对照\n";
                                        continue;
                                    }
                                }
                            }
                            else
                            {
                                s科目编码 = s科目编码.Replace("@", "");
                            }

                            if (s客户编码 != "")
                            {
                                if (s客户编码.Substring(0, 1) == "@")
                                {
                                    s客户编码 = s客户编码.Replace("@", "");
                                    if (s客户编码 != "")
                                    {
                                        s客户编码 = "'" + s客户编码 + "'";
                                    }
                                    else
                                    {
                                        s客户编码 = "null";
                                    }
                                }
                                else
                                {
                                    DataRow[] dr = dt对照信息.Select("类型 = '客户编码' and 编码 = '" + s客户编码 + "'");
                                    if (dr.Length > 0 && dr[0]["对照编码"].ToString().Trim() != "")
                                    {
                                        s客户编码 = "'" + dr[0]["对照编码"].ToString().Trim() + "'";
                                    }
                                    else
                                    {
                                        sErr = sErr + "行" + (i + 1).ToString() + " 未设置客户对照\n";
                                        continue;
                                    }
                                }
                            }
                            else
                            {
                                s客户编码 = "null";
                            }

                            if (s供应商编码 != "")
                            {
                                if (s供应商编码.Substring(0, 1) == "@")
                                {
                                    s供应商编码 = s供应商编码.Replace("@", "");
                                    if (s供应商编码 != "")
                                    {
                                        s供应商编码 = "'" + s供应商编码 + "'";
                                    }
                                    else
                                    {
                                        s供应商编码 = "null";
                                    }
                                }
                                else
                                {
                                    DataRow[] dr = dt对照信息.Select("类型 = '供应商编码' and 编码 = '" + s供应商编码 + "'");
                                    if (dr.Length > 0 && dr[0]["对照编码"].ToString().Trim() != "")
                                    {
                                        s供应商编码 = "'" + dr[0]["对照编码"].ToString().Trim() + "'";
                                    }
                                    else
                                    {
                                        sErr = sErr + "行" + (i + 1).ToString() + " 未设置供应商编码对照\n";
                                        continue;
                                    }
                                }
                            }
                            else
                            {
                                s供应商编码 = "null";
                            }

                            string s凭证类别2 = gridView1.GetRowCellValue(i, gridCol凭证类别字2).ToString().Trim();
                            sSQL = "select * from aaa..gl_accvouch where ctext1 = '" + s识别号 + "' and csign = '" + s凭证类别2 + "'";
                            sSQL = sSQL.Replace("aaa", s目的帐套);
                            DataTable dt = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                i凭证号 = SqlHelper.ReturnObjectToInt(dt.Rows[0]["ino_id"]);
                            }
                            else
                            {
                                sSQL = "select isnull(max(ino_id),0) as ino_id,count(1) as 行号 from aaa..gl_accvouch where iyear = '" + s年度 + "' and iperiod = " + s期间 + " and csign = '" + s凭证类别2 + "' ";
                                sSQL = sSQL.Replace("aaa", s目的帐套);
                                dt = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                i凭证号 = SqlHelper.ReturnObjectToInt(dt.Rows[0]["ino_id"]) + 1;
                            }

                            sSQL = "select count(1) as 行号 from aaa..gl_accvouch where ctext1 = '" + s识别号 + "' ";
                            sSQL = sSQL.Replace("aaa", s目的帐套);
                            dt = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            int i凭证行号 = SqlHelper.ReturnObjectToInt(dt.Rows[0][0]) + 1;

                            sSQL = "select * from aaa..dsign where csign = '" + s凭证类别2 + "'";
                            sSQL = sSQL.Replace("aaa", s目的帐套);
                            DataTable dt凭证类型 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dt凭证类型 == null || dt凭证类型.Rows.Count == 0)
                            {
                                sErr = sErr + "行" + (i + 1).ToString() + " 未设置凭证类型对照\n";
                                continue;
                            }

                            sSQL = "INSERT INTO aaa..gl_accvouch (iperiod, csign, isignseq, ino_id, inid, dbill_date, idoc, cbill, ccheck, cbook" +
                                              ", ibook, ccashier, iflag, ctext2, cdigest, ccode, cexch_name, md, mc, " +
                                              "md_f, mc_f, nfrat, nd_s, nc_s, csettle, cn_id, dt_date, cdept_id, cperson_id" +
                                              ", ccus_id, csup_id, citem_id, citem_class, cname, ccode_equal, iflagbank, iflagPerson,bdelete, coutaccset " +
                                              ",iyear,iYPeriod ,ctext1) " +
                                   "values(" + s期间 + ",'" + s凭证类别2 + "','" + dt凭证类型.Rows[0]["isignseq"] + "'," + i凭证号 + ",'" + i凭证行号 + "','" + gridView1.GetRowCellValue(i, gridCol制单日期).ToString().Trim() + "',-1,'" + gridView1.GetRowCellValue(i, gridCol制单人).ToString().Trim() + "',null,null" +
                                            ",0,null,null,null,'" + gridView1.GetRowCellValue(i, gridCol摘要).ToString().Trim() + "','" + s科目编码 + "'," + s币种名称 + "," + SqlHelper.ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol借方金额), 2) + "," + SqlHelper.ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol贷方金额), 2) + "" +
                                            "," + SqlHelper.ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol外币借方金额), 2) + "," + SqlHelper.ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol外币贷方金额), 2) + "," + d汇率 + ",0,0,null,null,null,null,null" +
                                            "," + s客户编码 + "," + s供应商编码 + ",null,null,null,null,null,null,null,null" +
                                            ",'" + s年度 + "','" + s年度期间 + "','" + s识别号 + "')";


                            sSQL = sSQL.Replace("aaa", s目的帐套);

                            iCou = iCou + SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        #endregion
                    }


                    sSQL = @"
update UFDATA_009_2014..gl_accvouch set ccus_id='51205001', ccode= '113301',csup_id=NULL
where iyPeriod ='111111' and csign <>'' and ccode ='218101' and csup_id ='51205001' and isnull(ctext1,'') <> ''
";
                    sSQL = sSQL.Replace("111111", s年度期间);

                    iCou = iCou + SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                    sSQL = @"
update UFDATA_001_2014..gl_accvouch set csup_id='024', ccode= '218101',ccus_id=NULL
where iyPeriod ='111111' and csign <>'' and ccode ='113301' and ccus_id ='522' and isnull(ctext1,'') <> ''

update UFDATA_001_2014..gl_accvouch set csup_id='002', ccode= '218101',ccus_id=NULL
where iyPeriod ='111111' and csign <>'' and ccode ='113301' and ccus_id ='302' and isnull(ctext1,'') <> ''
";
                    sSQL = sSQL.Replace("111111", s年度期间);

                    iCou = iCou + SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    sSQL = sSQL.Replace("111111", s年度期间);

                    iCou = iCou + SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }


                    if (iCou > 0)
                    {
                        tran.Commit();
                        MessageBox.Show("保存成功", "提示");

                        btnSel_Click(null, null);
                    }
                    else
                    {
                        tran.Rollback();
                        MessageBox.Show("没有需要保存的数据", "提示");
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

                DialogResult d = MessageBox.Show("确定删除选定的行么？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
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
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                for (int i = gridView1.RowCount - 1; i >= 0; i--)
                {
                    if (gridView1.IsRowSelected(i))
                    {
                        string s来源帐套 = gridView1.GetRowCellValue(i, gridView1.Columns["来源帐套"]).ToString().Trim();
                        string s编码 = gridView1.GetRowCellValue(i, gridView1.Columns["编码"]).ToString().Trim();
                        string s对照帐套 = gridView1.GetRowCellValue(i, gridView1.Columns["对照帐套"]).ToString().Trim();
                        string s对照编码 = gridView1.GetRowCellValue(i, gridView1.Columns["对照编码"]).ToString().Trim(); 
                        string s类型 = gridView1.GetRowCellValue(i, gridView1.Columns["类型"]).ToString().Trim(); 
                    
                        sSQL = "delete 帐套档案对照表 where 来源帐套 = '111111' and 编码 = '222222' and 对照帐套 = '333333' and 对照编码 = '444444' and 类型 = '555555'";

                        sSQL = sSQL.Replace("111111", s来源帐套);
                        sSQL = sSQL.Replace("222222", s编码);
                        sSQL = sSQL.Replace("333333", s对照帐套);
                        sSQL = sSQL.Replace("444444", s对照编码);
                        sSQL = sSQL.Replace("555555", s类型);
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                }

                tran.Commit();
                MessageBox.Show("删除成功", "提示");

                btnSel_Click(null,null);
                gridView1.FocusedRowHandle = iFoc;
            }
            catch (Exception ee)
            {
                MessageBox.Show("删除失败:" + ee.Message);
            }
        }

        private void gridView1_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            if ((this.gridView1.GetDataRow(e.RowHandle1)["识别号"].ToString() != this.gridView1.GetDataRow(e.RowHandle2)["识别号"].ToString()))
                e.Handled = true;
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                DevExpress.XtraGrid.Columns.GridColumn gCol = gridView1.FocusedColumn;
                if (gCol.FieldName == "选择")
                {
                    int iRow = 0;
                    if (gridView1.FocusedRowHandle > 0)
                        iRow = gridView1.FocusedRowHandle;

                    string s识别号 = gridView1.GetRowCellValue(iRow, gridView1.Columns["识别号"]).ToString().Trim();
                    bool b选择 = Convert.ToBoolean(gridView1.GetRowCellValue(iRow, gridView1.Columns["选择"]).ToString().Trim());

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        string s识别号2 = gridView1.GetRowCellValue(i, gridView1.Columns["识别号"]).ToString().Trim();
                        if (s识别号 == s识别号2)
                        {
                            gridView1.SetRowCellValue(i, gridView1.Columns["选择"], !b选择);
                        }
                    }
                }
            }
            catch { }
        }

        private void lookUpEdit期间_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                dateEdit制单日期1.Text = lookUpEdit年度.Text.Trim() + "-" + lookUpEdit期间.Text.Trim() + "-01";
                dateEdit制单日期2.Text = Convert.ToDateTime(lookUpEdit年度.Text.Trim() + "-" + lookUpEdit期间.Text.Trim() + "-01").AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");
            }
            catch { }

        }

        private void chk全选_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridCol选择, chk全选.Checked);
                }
            }
            catch { }
        }
    }
}