using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TH.BaseClass;
using System.Data.SqlClient;
using System.Collections;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class GL_accvouch : UserControl
    {        
        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }


        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                DbHelperSQL.connectionString = Conn;

                dateEdit1.DateTime = BaseFunction.ReturnDate(DateTime.Today.ToString("yyyy-MM-01"));
                dateEdit2.DateTime = BaseFunction.ReturnDate(dateEdit1.DateTime.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd"));
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        public GL_accvouch()
        {
            InitializeComponent();
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
                    gridView6.ExportToXls(sF.FileName);
                    MessageBox.Show("导出Excel成功\n\t路径：" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "导出Excel失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView6.FocusedRowHandle -= 1;
                    gridView6.FocusedRowHandle += 1;
                }
                catch { }

                int iCount = 0;
                decimal d借sum = 0;
                decimal d贷sum = 0;

                string sErr = "";

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    if (gridView6.RowCount == 0)
                    {
                        throw new Exception("请查询可导入凭证");
                    }

                    ArrayList aList_Doc = new ArrayList();
                    for (int i = 0; i < gridView6.RowCount; i++)
                    {
                        bool b = BaseFunction.ReturnBool(gridView6.GetRowCellValue(i, gridCol选择));
                        if (!b)
                            continue;

                        string sDocNO = gridView6.GetRowCellDisplayText(i, gridColDocumentNo).ToString().Trim();

                        if (sDocNO == "DBSRMB00793")
                        { 
                        
                        }

                        bool bExists = false;
                        for (int j = 0; j < aList_Doc.Count; j++)
                        {
                            if (sDocNO == aList_Doc[j].ToString().Trim())
                            {
                                bExists = true;
                                break;
                            }
                        }

                        if (bExists)
                            continue;

                        aList_Doc.Add(sDocNO);

                        decimal dC = 0;
                        decimal dD = 0;
                        for (int j = i; j < gridView6.RowCount; j++)
                        {
                            string sDocNO2 = gridView6.GetRowCellDisplayText(j, gridColDocumentNo).ToString().Trim();

                            if (sDocNO == sDocNO2)
                            {
                                dC = dC + BaseFunction.ReturnDecimal(gridView6.GetRowCellValue(j, gridCol借方), 6);
                                dD = dD + BaseFunction.ReturnDecimal(gridView6.GetRowCellValue(j, gridCol贷方), 6);
                            }
                        }

                        if (dC != dD)
                        { 
                            sErr = sErr + "行 " + (i+1).ToString() + " DocumentNo  " + sDocNO + " 借贷不平\n";
                            continue;
                        }
                    }

                    if(sErr != "")
                        throw new Exception(sErr);


                    DataTable dt币种 = new DataTable();

                    string sSQL = "SELECT * FROM dbo.GL_mend WHERE iyear = aaaaaa AND iperiod = bbbbbb";
                    sSQL = sSQL.Replace("aaaaaa", dateEdit1.DateTime.Year.ToString());
                    sSQL = sSQL.Replace("bbbbbb", dateEdit1.DateTime.Month.ToString());
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        throw new Exception("获得模块状态失败");
                    }
                    if (BaseFunction.ReturnBool(dt.Rows[0]["bflag"]))
                    {
                        throw new Exception("总账已结账");
                    }

                    for (int i = 0; i < gridView6.RowCount; i++)
                    {
                        bool b = BaseFunction.ReturnBool(gridView6.GetRowCellValue(i, gridCol选择));
                        if (!b)
                            continue;

                        d借sum = d借sum + BaseFunction.ReturnDecimal(gridView6.GetRowCellValue(i, gridCol借方));
                        d贷sum = d贷sum + BaseFunction.ReturnDecimal(gridView6.GetRowCellValue(i, gridCol贷方));
                    }

                    if (d借sum != d贷sum)
                    {
                        throw new Exception("借贷不平");
                    }

                    DataTable dt凭证 = (DataTable)gridControl6.DataSource;
                    sSQL = "select isnull(max(ino_id),0)  from GL_accvouch where iyear = aaaaaa AND iperiod = bbbbbb and csign = '记'";
                    sSQL = sSQL.Replace("aaaaaa", dateEdit1.DateTime.Year.ToString());
                    sSQL = sSQL.Replace("bbbbbb", dateEdit1.DateTime.Month.ToString());
                    DataTable dtinoid = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    int ino_id = BaseFunction.ReturnInt(dtinoid.Rows[0][0]);

                    ArrayList aList = new ArrayList();
                    for (int i = 0; i < gridView6.RowCount; i++)
                    {
                        bool b = BaseFunction.ReturnBool(gridView6.GetRowCellValue(i, gridCol选择));
                        if (!b)
                            continue;
                        if(BaseFunction.ReturnDate(gridView6.GetRowCellValue(i, gridCol制单日期)).Year!=dateEdit1.DateTime.Year)
                            sErr = sErr + "行" + (i + 1).ToString() + "制单日期不在账期内\n";
                        if (BaseFunction.ReturnDate(gridView6.GetRowCellValue(i, gridCol制单日期)).Month != dateEdit1.DateTime.Month)
                            sErr = sErr + "行" + (i + 1).ToString() + "制单日期不在账期内\n";

                        string sDocment = gridView6.GetRowCellValue(i, gridColDocumentNo).ToString().ToLower().Trim();
                        bool bExists = false;
                        for (int j = 0; j < aList.Count; j++)
                        {
                            if (sDocment == aList[j].ToString().ToLower().Trim())
                            {
                                bExists = true;
                                break;
                            }
                        }
                        if (bExists)
                            continue;

                        aList.Add(sDocment);

                        int inid = 0;
                        ino_id = ino_id + 1;
                        for (int j = 0; j < gridView6.RowCount; j++)
                        {
                            string sDocment2 = gridView6.GetRowCellValue(j, gridColDocumentNo).ToString().Trim().ToLower();
                            if (sDocment != sDocment2)
                                continue;

                            inid += 1;
                            Model.GL_accvouch model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.GL_accvouch();
                            model.iperiod = dateEdit1.DateTime.Month;
                            model.csign = gridView6.GetRowCellValue(j, gridCol凭证类别).ToString().Trim();
                            model.isignseq = 4;
                            model.ino_id = ino_id;
                            model.inid = inid;
                            model.dbill_date = BaseFunction.ReturnDate(gridView6.GetRowCellValue(j, gridCol制单日期));
                            model.idoc = -1;
                            model.cbill = gridView6.GetRowCellValue(j, gridCol制单人).ToString().Trim();
                            model.ibook = 0;

                            string s摘要 =  gridView6.GetRowCellValue(j, gridCol摘要).ToString().Trim();
                            if (s摘要.Length > 60)
                            {
                                s摘要 = s摘要.Substring(0, 60);
                            }
                            model.cdigest = s摘要;
                            model.ccode = gridView6.GetRowCellValue(j, gridCol会计科目).ToString().Trim();
                            model.cDefine1 = sDocment2;
                            model.md = BaseFunction.ReturnDecimal(gridView6.GetRowCellValue(j, gridCol借方));
                            model.mc = BaseFunction.ReturnDecimal(gridView6.GetRowCellValue(j, gridCol贷方));
                            model.md_f = BaseFunction.ReturnDecimal(gridView6.GetRowCellValue(j, gridCol外币借方));
                            model.mc_f = BaseFunction.ReturnDecimal(gridView6.GetRowCellValue(j, gridCol外币贷方));
                            model.nfrat = BaseFunction.ReturnDecimal(gridView6.GetRowCellValue(j, gridCol汇率));
                            model.nd_s = 0;
                            model.nc_s = 0;
                            //model.csettle = "";     //结算方式
                            //model.cn_id
                            //model.dt_date = 

                            DataRow[] dr凭证;
                            if (model.md > 0)
                            {
                                string s = "贷方>0 and 凭证类别 = '" + model.csign + "' and DocumentNo = '" + gridView6.GetRowCellValue(j, gridColDocumentNo).ToString() + "'";
                                dr凭证 = dt凭证.Select(s);
                            }
                            else
                            {
                                string s = "借方>0 and 凭证类别 = '" + model.csign + "' and DocumentNo = '" + gridView6.GetRowCellValue(j, gridColDocumentNo).ToString() + "'";
                                dr凭证 = dt凭证.Select(s);
                            }
                            string s对方科目 = "";
                            for (int k = 0; k < dr凭证.Length; k++)
                            {
                                if (s对方科目 == "")
                                {
                                    s对方科目 = dr凭证[k]["会计科目"].ToString().Trim();
                                }
                                else
                                {
                                    string sTemp = s对方科目 + "," + dr凭证[k]["会计科目"].ToString().Trim();
                                    if (sTemp.Length < 50)
                                    {
                                        if (s对方科目.IndexOf(dr凭证[k]["会计科目"].ToString().Trim()) < 0)
                                        {
                                            s对方科目 = s对方科目 + "," + dr凭证[k]["会计科目"].ToString().Trim();
                                        }
                                    }
                                }
                            }

                            if (s对方科目.Length > 50)
                            {
                                s对方科目 = s对方科目.Substring(0, 50);
                            }
                            model.ccode_equal = s对方科目;
                            model.bdelete = false;
                            model.doutbilldate = model.dbill_date;
                            model.bvouchedit = true;
                            model.bvouchAddordele = false;
                            model.bvouchmoneyhold = false;
                            model.bvalueedit = true;
                            model.bcodeedit = true;
                            model.bPCSedit = true;
                            model.bDeptedit = true;
                            model.bItemedit = true;
                            model.bCusSupInput = false;
                            model.bFlagOut = false;
                            model.RowGuid = Guid.NewGuid().ToString();
                            model.iyear = dateEdit1.DateTime.Year;
                            model.iYPeriod = BaseFunction.ReturnInt(dateEdit1.DateTime.ToString("yyyyMM"));
                            model.tvouchtime = DateTime.Now;
                            model.ccodeexch_equal = s对方科目;
                            if (gridView6.GetRowCellValue(j, gridCol客户编码).ToString() != "")
                            {
                                model.ccus_id = gridView6.GetRowCellValue(j, gridCol客户编码).ToString();
                            }
                            if (gridView6.GetRowCellValue(j, gridCol供应商编码).ToString() != "")
                            {
                                model.csup_id = gridView6.GetRowCellValue(j, gridCol供应商编码).ToString();
                            }


                            DAL.GL_accvouch dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.GL_accvouch();
                            sSQL = dal.Add(model);
                            iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                    }

                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }

                    if (iCount > 0)
                    {
                        tran.Commit();
                        MessageBox.Show("保存成功");
                        btnSel_Click(null, null);
                    }
                    else
                    {
                        throw new Exception("没有数据");
                    }
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "提示";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string sSQL = "";
            try
            {
                if (dateEdit1.DateTime.Year != dateEdit2.DateTime.Year || dateEdit1.DateTime.Month != dateEdit2.DateTime.Month)
                {
                    dateEdit1.Focus();
                    throw new Exception("日期必须在同一个年月");
                }

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "XML|*.xml|所有文件|*.*";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                string fName = openFileDialog.FileName;

                ClsExcel clsExcel = ClsExcel.Instance();
                string tablename = "";
                string sqltablename = "";
                
                if (toolStripComboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("请选择导入单据类型");
                    return;
                }
                switch(toolStripComboBox1.SelectedIndex)
                {
                    case 0:
                        tablename = "View - General Ledger Entries $A2:R65536";
                        sqltablename = "_General Ledger Entries";
                        xtp0.Show();
                        break;
                    case 1:
                        tablename = "Posted Purchase Credit Memos$A2:J65536";
                        sqltablename = "_Purchase Credit Memos";
                        xtp1.Show();
                        break;
                    case 2:
                        tablename = "Posted Purchase Invoices$A2:M65536";
                        sqltablename = "_Purchase Invoices";
                        xtp2.Show();
                        break;
                    case 3:
                        tablename = "Posted Sales Credit Memos$A2:I65536";
                        sqltablename = "_Sales Credit Memos";
                        xtp3.Show();
                        break;
                    case 4:
                        tablename = "Posted Sales Invoices$A2:L65536";
                        sqltablename = "_Sales Invoices";
                        xtp4.Show();
                        break;
                    case 5:
                        tablename = "View - Bank Account Ledger Ent$A2:J65536";
                        sqltablename = "_Bank Account Ledger Entries";
                        xtp5.Show();
                        break;
                }
                DataTable dt = DbHelperXML.ReadFromXml(fName);
                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //conn.ConnectionTimeout = 0;
               
                SqlTransaction tran = conn.BeginTransaction();
                
                
                try
                {
                    //导入
                    int iCount = 0;

                    sSQL = "truncate table [" + sqltablename + "]";

                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        SqlClass sc = new SqlClass("[" + sqltablename + "]");
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            sc.ToString("[" + dt.Columns[j].ColumnName + "]", dt.Rows[i][dt.Columns[j].ColumnName].ToString().Replace("'", ""));
                        }
                        sSQL = sc.UpdateSql();
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        iCount = iCount + 1;
                    }

                    //核对
                    switch (toolStripComboBox1.SelectedIndex)
                    {
                        case 0:
                            sSQL = "select a.*,null as 问题数据 from [" + sqltablename + "] a ";
                            dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            gridControl0.DataSource = dt;
                            gridView0.OptionsBehavior.Editable = false;
                            gridView0.Columns["Amount"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                            gridView0.BestFitColumns();
                            break;
                        case 1:
                            sSQL = "select a.*,case when b.cVenCode is null then '用友未找到供应商' end as 问题数据 from [" + sqltablename + "] a left join Vendor b on a.[Buy-from Vendor No.]=b.cVenCode ";
                            dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            gridControl1.DataSource = dt;
                            gridView1.OptionsBehavior.Editable = false;
                            gridView1.Columns["Amount"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                            gridView1.BestFitColumns();
                            break;
                        case 2:
                            sSQL = "select a.*,case when b.cVenCode is null then '用友未找到供应商' end as 问题数据 from [" + sqltablename + "] a left join Vendor b on a.[Buy-from Vendor No.]=b.cVenCode  ";
                            dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            gridControl2.DataSource = dt;
                            gridView2.OptionsBehavior.Editable = false;
                            gridView2.Columns["Amount"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                            gridView2.BestFitColumns();
                            break;
                        case 3:
                            sSQL = "select a.*,case when b.cCusCode is null then '用友未找到客户' end as 问题数据 from [" + sqltablename + "] a left join Customer b on a.[Sell-to Customer No.]=b.cCusCode ";
                            dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            gridControl3.DataSource = dt;
                            gridView3.OptionsBehavior.Editable = false;
                            gridView3.Columns["Amount"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                            gridView3.BestFitColumns();
                            break;
                        case 4:
                            sSQL = "select a.*,case when b.cCusCode is null then '用友未找到客户' end as 问题数据 from [" + sqltablename + "] a left join Customer b on a.[Sell-to Customer No.]=b.cCusCode ";
                            dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            gridControl4.DataSource = dt;
                            gridView4.OptionsBehavior.Editable = false;
                            gridView4.Columns["Amount"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                            gridView4.BestFitColumns();

                            break;
                        case 5:
                            sSQL = "select a.*,null as 问题数据 from [" + sqltablename + "] a ";
                            dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            gridControl5.DataSource = dt;
                            gridView5.OptionsBehavior.Editable = false;
                            gridView5.Columns["Amount"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                            gridView5.BestFitColumns();
                            break;
                    }
                    tran.Commit();
                    MessageBox.Show("导入成功，共" + iCount + "条");

                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception("导入失败，原因：" + ee.Message);
                }
                //DataColumn dc = new DataColumn();
                //dc.ColumnName = "选择";
                //dc.DataType = System.Type.GetType("System.Boolean");
                //dt.Columns.Add(dc);

                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    dt.Rows[i]["选择"] = true;
                //}

                //gridControl1.DataSource = dt;

                //gridView1.BestFitColumns();

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int iRow = gridView6.FocusedRowHandle;
                bool b = BaseFunction.ReturnBool(gridView6.GetRowCellValue(iRow, gridCol选择));
                //string s凭证类别 = gridView1.GetRowCellValue(iRow, gridCol凭证类别).ToString().Trim();
                //string s凭证号 = gridView1.GetRowCellValue(iRow, gridCol凭证号).ToString().Trim();
                string DocumentNo = gridView6.GetRowCellValue(iRow, gridColDocumentNo).ToString().Trim();
                //if (b == false)
                {
                    for (int i = 0; i < gridView6.RowCount; i++)
                    {
                        string sDocumentNo = gridView6.GetRowCellValue(i, gridColDocumentNo).ToString().Trim();
                        string 问题数据 = gridView6.GetRowCellValue(i, gridCol问题数据).ToString().Trim();
                        if (DocumentNo == sDocumentNo)
                        {
                            gridView6.SetRowCellValue(i, gridCol选择, !b);
                            if (问题数据 != "")
                            {

                                gridView6.SetRowCellValue(i, gridCol选择, false);
                                MessageBox.Show("行" + (i + 1).ToString() + "数据有问题，不可生成凭证\n");
                                for (int j = 0; j < gridView6.RowCount; j++)
                                {
                                    if (sDocumentNo == gridView6.GetRowCellValue(j, gridCol问题数据).ToString().Trim())
                                    {
                                        gridView6.SetRowCellValue(i, gridCol选择, false);
                                    }
                                }
                                return;
                            }
                        }
                    }
                }
                //else
                //{
                //    gridView6.SetRowCellValue(iRow, gridCol选择, !b);
                //}

            }
            catch { }
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            if (dateEdit1.DateTime.ToString("yyyyMM") != dateEdit2.DateTime.ToString("yyyyMM"))
            {
                MessageBox.Show("日期必须在同一个会计期间");
                return;
            }

            SqlConnection conn = new SqlConnection(Conn);
            conn.Open();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                string sSQL = @"

if object_id(N'tempdb..#a',N'U') is not null
	drop table #a
if object_id(N'tempdb..#b',N'U') is not null
	drop table #b
if object_id(N'tempdb..#Invoice',N'U') is not null
	drop table #Invoice

declare @dtm datetime 
declare @dtm2 datetime 
set @dtm = 'aaaaaa'
set @dtm2 = 'bbbbbb'

create table #Invoice
(
	iFlag varchar(50),
	iNo varchar(50),
	供应商 varchar(50),
	客户 varchar(50),
	币种 varchar(50),
	发票号 varchar(50)
)

insert into  #Invoice
select 'Purchase Credit Memos' as iFlag,a.[No.] as iNo,convert(varchar(100),a. [Buy-from Vendor No.]) as 供应商,convert(varchar(100),null) as 客户, [Currency Code] as 币种 ,null as 发票号
from [dbo].[_Purchase Credit Memos] a 
group by a.[No.],a.[Buy-from Vendor No.], [Currency Code]

insert into  #Invoice
select 'Purchase Invoices' as iFlag,a.[No.],a.[Buy-from Vendor No.],null, [Currency Code] as 币种 , [Vendor Invoice No.] as 发票号
from [dbo].[_Purchase Invoices] a 
where year(a.[Posting Date]) = year(@dtm) and month(a.[Posting Date]) = month(@dtm)
group by a.[No.],a.[Buy-from Vendor No.], [Currency Code], [Vendor Invoice No.]          
     
insert into  #Invoice
select 'Sales Credit Memos' as iFlag,a.[No.],null,convert(varchar(100),a.[Sell-to Customer No.]), [Currency Code] as 币种 ,null as 发票号
from [dbo].[_Sales Credit Memos] a 
group by a.[No.],a.[Sell-to Customer No.], [Currency Code]

insert into  #Invoice
select 'Sales Invoices' as iFlag,a.[No.],null,a.[Sell-to Customer No.], [Currency Code] as 币种, [External Document No.]as 发票号
from [dbo].[_Sales Invoices] a 
where year(a.[Posting Date]) = year(@dtm) and month(a.[Posting Date]) = month(@dtm)
group by a.[No.],a.[Sell-to Customer No.], [Currency Code], [External Document No.]
                   
           
select CONVERT(bit,0) as 选择,iFlag,a.[Document No.] as DocumentNo,a.[Document Type] as DocumentType,'记' as 凭证类别
	,convert(int,null) as 凭证号,convert(int,null) as 行号
	,case when a.Amount > 0 and isnull(b.RemarkJ,'') <> '' then b.RemarkJ 
		  when a.Amount > 0 and isnull(b.RemarkJ,'') = '' then a.[Description]
		  when a.Amount < 0 and isnull(b.RemarkD,'') <> '' then b.RemarkD 
		  when a.Amount < 0 and isnull(b.RemarkD,'') = '' then a.[Description] end as 摘要
	,case when a.Amount > 0 then a.Amount end as 借方
	,case when a.Amount < 0 then -a.Amount end as 贷方
	,case when e.cexch_name is not null and c.bd_c = 1 then a.Amount/e.nflat end as 外币借方
	,case when e.cexch_name is not null and c.bd_c = 0 then -a.Amount/e.nflat end as 外币贷方
	,a.[Posting Date] as 制单日期,[User ID] as 制单人,0 as 汇率,case when s.币种 is null then 'RMB' else s.币种 end as 币种,a.[G/L Account No.] as 对照科目,c.ccode as 会计科目,C.ccode_name AS 会计科目名称
	,'' as 人员,'' as 部门
	,case when isnull(cus2.cCusCode,'') = '' then  cus.cCusCode else cus2.cCusCode end as 客户编码
	,case when isnull(cus2.cCusCode,'') = '' then  cus.cCusName else cus2.cCusName end as 客户
	,case when isnull(ven2.cVenCode,'') = '' then  ven.cVenCode else ven2.cVenCode end as 供应商编码
	,case when isnull(ven2.cVenCode,'') = '' then  ven.cVenName else ven2.cVenName end as 供应商
    ,'' as 项目 
	,case when isnull(s.币种,'')<>'' and isnull(e.cexch_name,'')='' then '未找到外币换算率'
	when c.bcus=1 and isnull(case when isnull(cus2.cCusCode,'') = '' then  cus.cCusCode else cus2.cCusCode end,'')='' then '客户往来核算需要客户信息' 
	when c.bsup=1 and isnull(case when isnull(ven2.cVenCode,'') = '' then  ven.cVenCode else ven2.cVenCode end,'')='' then '供应商往来核算需要供应商信息' 
	when isnull(c.ccode,'')='' then '未找到会计科目' 
	--when c.bperson=1 and isnull(s.人员,'')='' then '个人往来核算需要人员信息' 
	--when c.bdept=1 and isnull(s.部门,'')='' then '部门核算需要部门信息' 
	when bend=0 then '不是末级科目'
	end 问题数据_1
    ,s.发票号
into #a 
from [dbo].[_General Ledger Entries] a 
	left join (select * from _科目对照 where 年度 = year(@dtm)) b on a.[G/L Account No.]=b.对照科目
	left join #Invoice s on a.[Document No.]=s.iNo 
	left join exch e on s.币种=e.cexch_name and iyear = year(a.[Posting Date]) AND iperiod = month(a.[Posting Date])
	left join Customer cus on s.客户=cus.cCusCode
	left join Vendor ven on s.供应商=ven.cVenCode 
	left join code c on b.会计科目=c.ccode and c.iYear = year(@dtm)
	left join (select distinct cDefine1  from GL_accvouch ) f on a.[Document No.] =f.cDefine1
	left join Customer cus2 on a.[Source No.]=cus2.cCusCode
	left join Vendor ven2 on a.[Source No.]=ven2.cVenCode 
where DateName(year,a.[Posting Date]) = year(@dtm) AND DateName(month,a.[Posting Date]) = month(@dtm) and f.cDefine1 is null
    and a.[Document No.] not in
        (
            select a.[Document No.]
            from [dbo].[_General Ledger Entries] a left join _科目对照 b on a.[G/L Account No.]=b.对照科目 
            where b.Remark like '%err%'  and b.年度 = year(@dtm)
        )
     and a.[Posting Date]>=@dtm and a.[Posting Date] < @dtm2
     and isnull(b.会计科目,0) <> '9999'
order by a.[Document No.] 


select distinct a.DocumentNo 
into #b 
from #a a 
where a.借方>0 and a.贷方>0

select a.*,b.DocumentNo,case when isnull(d.DocumentNo,'') <> '' then '借贷不平' when isnull(问题数据_1,'') <> '' then 问题数据_1 when b.DocumentNo is not null then '错误' end 问题数据 
from #a a 
	left join (select distinct DocumentNo from #a where 问题数据_1 is not null) b on a.DocumentNo=b.DocumentNo 
	left join #b c on a.DocumentNo=c.DocumentNo 
    left join
        (
            select DocumentNo,sum(借方) as 借方,sum(贷方) as 贷方
            from #a
            group by DocumentNo        
            having cast(sum(isnull(借方,0)) as decimal(16,2)) <> cast(sum(isnull(贷方,0)) as decimal(16,2))
        )d on a.DocumentNo=d.DocumentNo 
where c.DocumentNo is null
order by a.DocumentNo,isnull(a.借方,9999999999)

";
                sSQL = sSQL.Replace("111111", sUserID);
                sSQL = sSQL.Replace("aaaaaa", dateEdit1.DateTime.ToString("yyyy-MM-dd"));
                sSQL = sSQL.Replace("bbbbbb", dateEdit2.DateTime.AddDays(1).ToString("yyyy-MM-dd")); 
                DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string s摘要 = dt.Rows[i]["摘要"].ToString().Trim();

                    s摘要 = s摘要.Replace("@供应商", dt.Rows[i]["供应商"].ToString().Trim());
                    s摘要 = s摘要.Replace("@发票", dt.Rows[i]["发票号"].ToString().Trim());
                    s摘要 = s摘要.Replace("@客户", dt.Rows[i]["客户"].ToString().Trim());

                    dt.Rows[i]["摘要"] = s摘要;
                }

                gridControl6.DataSource = dt;
                xtp6.Show();
                tran.Commit();
            }
            catch (Exception ee)
            {
                tran.Rollback();
                MessageBox.Show("导入失败，原因：" + ee.Message);
            }
        }

        private void checkEditChk_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView6.RowCount; i++)
            {
                string 问题数据 = gridView6.GetRowCellDisplayText(i, "问题数据").ToString().Trim();
                if (问题数据 == "")
                {
                    gridView6.SetRowCellValue(i, gridCol选择, checkEditChk.Checked);
                }
            }
        }

        private void gridView0_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                string 问题数据 = gridView0.GetRowCellDisplayText(e.RowHandle, "问题数据").ToString().Trim();
                if (问题数据 != "")
                {
                    e.Appearance.BackColor = Color.LightCoral;
                }
            }
            catch
            {
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                string 问题数据 = gridView1.GetRowCellDisplayText(e.RowHandle, "问题数据").ToString().Trim();
                if (问题数据 != "")
                {
                    e.Appearance.BackColor = Color.LightCoral;
                }
            }
            catch
            {
            }
        }

        private void gridView2_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                string 问题数据 = gridView2.GetRowCellDisplayText(e.RowHandle, "问题数据").ToString().Trim();
                if (问题数据 != "")
                {
                    e.Appearance.BackColor = Color.LightCoral;
                }
            }
            catch
            {
            }
        }

        private void gridView3_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                string 问题数据 = gridView3.GetRowCellDisplayText(e.RowHandle, "问题数据").ToString().Trim();
                if (问题数据 != "")
                {
                    e.Appearance.BackColor = Color.LightCoral;
                }
            }
            catch
            {
            }
        }

        private void gridView4_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                string 问题数据 = gridView4.GetRowCellDisplayText(e.RowHandle, "问题数据").ToString().Trim();
                if (问题数据 != "")
                {
                    e.Appearance.BackColor = Color.LightCoral;
                }
            }
            catch
            {
            }
        }

        private void gridView5_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                string 问题数据 = gridView5.GetRowCellDisplayText(e.RowHandle, "问题数据").ToString().Trim();
                if (问题数据 != "")
                {
                    e.Appearance.BackColor = Color.LightCoral;
                }
            }
            catch
            {
            }
        }

        private void gridView6_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                string 问题数据 = gridView6.GetRowCellDisplayText(e.RowHandle, "问题数据").ToString().Trim();
                if (问题数据 != "")
                {
                    e.Appearance.BackColor = Color.LightCoral;
                }
            }
            catch
            {
            }
        }
    }
}
