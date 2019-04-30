using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.IO;



namespace clsU8
{
    public partial class FrmPrintRd32 : Form
    {
        RepBaseGrid Rep = new RepBaseGrid();
        string sProPath = Application.StartupPath;
        string sPrintLayOutMod = Application.StartupPath + "\\UAP\\Runtime\\print\\PrintRd32.dll";
        string s服务器;
        string sSA;
        string sPwd;
        string s数据库;
        string s单据号;
        string sConnString;
        string sUserName;

        public FrmPrintRd32()
        {
            InitializeComponent();
        }


        public FrmPrintRd32(string s1, string s2, string s3, string s4, string s5, string s6)
        {
            InitializeComponent();

            s服务器 = s1;
            sSA = s2;
            sPwd = s3;
            s数据库 = s4;
            s单据号 = s5;
            sUserName = s6;

            sConnString = "server = " + s服务器 + ";uid=" + sSA + ";pwd=" + sPwd + ";database=" + s数据库 + ";timeout = 200";
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                //if (sUserName.ToLower() == "demo")
                //{
                //    btn打印模板.Visible = true;
                //}
                //else
                //{
                //    btn打印模板.Visible = false;
                //}

                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void GetGrid()
        {
            try
            {
                Rep = new RepBaseGrid();
                if (File.Exists(sPrintLayOutMod))
                {
                    Rep.LoadLayout(sPrintLayOutMod);
                }
                else
                {
                    MessageBox.Show("加载报表模板失败，请与管理员联系");
                    return;
                }
                Rep.dsPrint.Tables.Clear();

                SqlConnection conn = new SqlConnection(sConnString);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                string sSQL = @"
if exists(select * from tempdb..sysobjects where id=object_id('tempdb..#a'))
	drop table #a

SELECT rds32.autoid,rd32.cMaker 
	,rd32.cCode,CONVERT(varchar(100),rd32.dDate,23) as dDate,wh.cWhName
	,rs.cRdName,cus.cCusAbbName,rd32.cMemo
	,rds32.cInvCode,inv.cInvName,inv.cInvStd
	,rds32.cFree1 as 长度,cUnit.cComUnitName 
	,cast(rds32.iNum as decimal(16,2)) as iNum,cast(rds32.iQuantity as decimal(16,2)) as iQuantity
	,rds32.cDefine22 as 公差,rds32.cBatchProperty6 as 炉号
	,rds32.cBatch
	,a.iMPoIds
	,cast(null as varchar(50)) as 材料批号
    ,a.,cmocode 
into #a
FROM dbo.rdrecord32 rd32 
	INNER JOIN dbo.rdrecords32 rds32 ON rd32.ID = rds32.ID
    INNER JOIN dbo.Warehouse wh ON rd32.cWhCode = wh.cWhCode
    inner join Inventory Inv on Inv.cInvCode = rds32.cInvCode
	inner join Rd_Style rs on rs.cRdCode = rd32.cRdCode 
	inner join Customer cus on cus.cCusCode = rd32.cCusCode
	inner join ComputationUnit cUnit on cUnit.cComunitCode = Inv.cComunitCode 
	left join 
	(
		select cBatch,max(iMPoIds) as  iMPoIds,cInvCode ,cmocode 
		from rdrecords10 
		group by cBatch,cInvCode,cmocode 
	)a on a.cBatch = rds32.cBatch and rds32.cInvCode = a.cInvCode
WHERE rd32.cCode = 'aaaaaa'


update a set 材料批号 = rds11.cBatch
from #a a  inner join rdrecords11 rds11 on a.iMPoIds = rds11.iMPoIds 

insert into #a(autoid,cCode,cRdName,cCusAbbName,cComUnitName,cInvCode,iNum,iQuantity,cmocode)
select 99999999999,'','','','','合计',sum(iNum),sum(iQuantity),'' from #a

select * from #a
order by autoid
";
                sSQL = sSQL.Replace("aaaaaa", s单据号);

                DataTable dtHead = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                dtHead.TableName = "dtHead";
                Rep.dsPrint.Tables.Add(dtHead.Copy());

                printControl1.PrintingSystem = Rep.PrintingSystem;
                Rep.CreateDocument();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btn打印模板_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(sProPath + "\\print"))
                    Directory.CreateDirectory(sProPath + "\\print");

                if (File.Exists(sPrintLayOutMod))
                {
                    Rep.LoadLayout(sPrintLayOutMod);
                }

                Rep.ShowDesignerDialog();

                DialogResult d = MessageBox.Show("是否保存?模板调整将在下次打开窗体时体现\n是：保存打印模板\n", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (DialogResult.Yes == d)
                {
                    Rep.SaveLayoutToXml(sPrintLayOutMod);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("设置打印模板失败：" + ee.Message);
            }
        }

        private void btn打印_Click(object sender, EventArgs e)
        {
            try
            {
                Rep.PrintDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btn刷新_Click(object sender, EventArgs e)
        {
            try
            {
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
