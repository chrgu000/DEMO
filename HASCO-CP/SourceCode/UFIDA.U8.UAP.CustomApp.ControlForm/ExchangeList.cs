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
    public partial class ExchangeList : UserControl
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

                DateTime dLogDate = BaseFunction.ReturnDate(sLogDate);
                lLoginPeriod.Text = dLogDate.ToString("yyyy.MM");
                string sSQL = @"
select distinct year(dDate) as iYear from RdRecord01 order by year(dDate)
";
                DataTable dt = DbHelperSQL.Query(sSQL);
                lookUpEditYear.Properties.DataSource = dt;
                lookUpEditYear.EditValue = BaseFunction.ReturnInt(BaseFunction.ReturnDate(sLogDate).ToString("yyyy"));

                dt = new DataTable();
                DataColumn dc = new DataColumn();
                dc.ColumnName = "iPeriod";
                dt.Columns.Add(dc);

                for (int i = 1; i <= 12; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["iPeriod"] = i.ToString().PadLeft(2, '0');
                    dt.Rows.Add(dr);
                }

                lookUpEditPeriod1.Properties.DataSource = dt;
                lookUpEditPeriod2.Properties.DataSource = dt;

                lookUpEditPeriod1.EditValue = BaseFunction.ReturnDate(sLogDate).ToString("MM");
                lookUpEditPeriod2.EditValue = BaseFunction.ReturnDate(sLogDate).ToString("MM");
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "Err";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        public ExchangeList()
        {
            InitializeComponent();
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

      

        private void btnCreateVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                int iRow = gridView1.FocusedRowHandle;
                if (iRow < 0)
                {
                    throw new Exception("Please choose data");
                }

                int iYear = BaseFunction.ReturnInt(gridView1.GetRowCellValue(iRow, gridColiYear));
                int iPeriod = BaseFunction.ReturnInt(gridView1.GetRowCellValue(iRow, gridColiPeriod));

                string sVoucher = "";

                int iCount = 0;
                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    string sSQL = "SELECT bflag FROM dbo.GL_mend WHERE iyear = aaaaaa AND iperiod = bbbbbb";
                    sSQL = sSQL.Replace("aaaaaa", iYear.ToString());
                    sSQL = sSQL.Replace("bbbbbb", iPeriod.ToString());
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        throw new Exception("Failed to obtain module status");
                    }
                    if (BaseFunction.ReturnBool(dt.Rows[0]["bflag"]))
                    {
                        throw new Exception("The current date has been checked out");
                    }

                    sSQL = @"
select *
from GL_accvouch gl  inner join _AmountOfExchangeProfitAndLoss b 
	on gl.iyear = b.iYear and gl.iperiod = b.iPeriod and gl.i_id = b.i_id and gl.csign = b.csign
where gl.csign = 'AP' and gl.iyear = aaaaaa and gl.iperiod = bbbbbb and isnull(gl.iflag,0) = 0
";
                    sSQL = sSQL.Replace("aaaaaa", iYear.ToString());
                    sSQL = sSQL.Replace("bbbbbb", iPeriod.ToString());
                    dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        throw new Exception("Accounting vouchers already exist");
                    }


                    sSQL = @"
select * from _Code where VouchType = 'Exchange gain or loss'
";
                    dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        throw new Exception("Please set aounting subject [_Code.Exchange gain or loss]");
                    }
                    string sKMD = dt.Rows[0]["Debtor"].ToString().Trim();
                    string sKMC = dt.Rows[0]["Creditor"].ToString().Trim();
                    string sZY = dt.Rows[0]["Remark"].ToString().Trim();
                    if (sKMD == "" || sKMC == "")
                    {
                        throw new Exception("Please set aounting subject [_Code.Exchange gain or loss]");
                    }


                    sSQL = "select isnull(max(ino_id),0)  from GL_accvouch where iyear = aaaaaa AND iperiod = bbbbbb and csign = 'AP'";
                    sSQL = sSQL.Replace("aaaaaa", iYear.ToString());
                    sSQL = sSQL.Replace("bbbbbb", iPeriod.ToString());
                    DataTable dtinoid = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    int ino_id = BaseFunction.ReturnInt(dtinoid.Rows[0][0]) + 1;

                      sSQL = @"
select sum(AmountOfExchangeProfitAndLoss) as AmountOfExchangeProfitAndLoss ,rd.cVenCode
from _AmountOfExchangeProfitAndLoss a
	left join RdRecord01 rd on a.cCode = rd.cCode
where a.iyear = aaaaaa and a.iperiod = bbbbbb
group by rd.cVenCode
";
                    sSQL = sSQL.Replace("aaaaaa", iYear.ToString());
                    sSQL = sSQL.Replace("bbbbbb", iPeriod.ToString());
                    dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        throw new Exception("Please do the math first");
                    }

                    decimal dSum = 0;// BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridColAmountOfExchangeProfitAndLoss), 2);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dSum = dSum + BaseFunction.ReturnDecimal(dt.Rows[i]["AmountOfExchangeProfitAndLoss"], 2);
                    }

                    sVoucher = sVoucher + "AP-" + ino_id.ToString().PadLeft(4, '0') + "\n";
                    #region 生成凭证
                    #region 借方
                    Model.GL_accvouch model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.GL_accvouch();
                    model.iperiod = iPeriod;
                    model.csign = "AP";
                    model.isignseq = 2;
                    model.ino_id = ino_id;
                    model.inid = 1;
                    model.dbill_date = BaseFunction.ReturnDate(sLogDate);
                    model.idoc = -1;
                    model.cbill = sUserName;
                    model.ibook = 0;
                    model.cdigest = sZY;
                    model.ccode = sKMD;
                    //model.cDefine1 = sDocment2;
                    model.md = BaseFunction.ReturnDecimal(dSum, 2);
                    model.mc = 0;
                    model.md_f = 0;
                    model.mc_f = 0;
                    model.nfrat = 0;
                    model.nd_s = 0;
                    model.nc_s = 0;
                    //model.csettle = "";     //结算方式
                    //model.cn_id
                    //model.dt_date = 

                    model.ccode_equal = sKMC; ;
                    model.bdelete = false;
                    //model.doutbilldate = model.dbill_date;
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
                    model.iyear = iYear;
                    model.iYPeriod = BaseFunction.ReturnInt(BaseFunction.ReturnDate(iYear.ToString() + "-" + iPeriod.ToString() + "-01").ToString("yyyyMM"));
                    model.tvouchtime = DateTime.Now;
                    model.ccodeexch_equal = sKMC;

                    UFIDA.U8.UAP.CustomApp.ControlForm.DAL.GL_accvouch dalGL = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.GL_accvouch();
                    sSQL = dalGL.Add(model);
                    iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    #endregion

                    #region 贷方
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.GL_accvouch();
                        model.iperiod = iPeriod;
                        model.csign = "AP";
                        model.isignseq = 2;
                        model.ino_id = ino_id;
                        model.inid = 2;
                        model.dbill_date = BaseFunction.ReturnDate(sLogDate);
                        model.idoc = -1;
                        model.cbill = sUserName;
                        model.ibook = 0;
                        model.cdigest = sZY;
                        model.ccode = sKMC;
                        //model.cDefine1 = sDocment2;
                        model.md = 0;
                        model.mc = BaseFunction.ReturnDecimal(dt.Rows[i]["AmountOfExchangeProfitAndLoss"], 2);
                        model.md_f = 0;
                        model.mc_f = 0;
                        model.nfrat = 0;
                        model.nd_s = 0;
                        model.nc_s = 0;
                        //model.csettle = "";     //结算方式
                        //model.cn_id
                        //model.dt_date = 

                        model.ccode_equal = sKMD; ;
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
                        model.iyear = iYear;
                        model.iYPeriod = BaseFunction.ReturnInt(BaseFunction.ReturnDate(iYear.ToString() + "-" + iPeriod.ToString() + "-01").ToString("yyyyMM"));
                        model.tvouchtime = DateTime.Now;
                        model.ccodeexch_equal = sKMD;

                        model.csup_id = dt.Rows[i]["cVenCode"].ToString().Trim();

                        dalGL = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.GL_accvouch();
                        sSQL = dalGL.Add(model);
                        iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                    #endregion

                    #endregion

                    sSQL = @"
select *
from GL_accvouch
where iyear = {0} and iPeriod = {1} and csign = '{2}' and ino_id = {3}
";
                    sSQL = string.Format(sSQL, model.iyear, model.iperiod, model.csign, model.ino_id);
                    DataTable dtGL = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    long i_id = BaseFunction.ReturnLong(dtGL.Rows[0]["i_id"]);

                    sSQL = @"
update _AmountOfExchangeProfitAndLoss set csign = 'AP',i_id = 'dddddddd',ino_id = 'eeeeee'
where  iyear = bbbbbbbb and iperiod = cccccccc
";
                    sSQL = sSQL.Replace("bbbbbbbb", model.iyear.ToString());
                    sSQL = sSQL.Replace("cccccccc", model.iperiod.ToString());
                    sSQL = sSQL.Replace("dddddddd", i_id.ToString().Trim());
                    sSQL = sSQL.Replace("eeeeee", model.ino_id.ToString().Trim());
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    tran.Commit();

                    MessageBox.Show("Sucess\n" + sVoucher);
                    btnQuery_Click(null, null);
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
                f.Text = "Err";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {

                if (lookUpEditYear.Text.Trim() == "")
                {
                    lookUpEditYear.Focus();
                    throw new Exception("Please set year");
                }

                string sSQL = @"
select cast(0 as bit) as Selected,a.iYear,a.iPeriod,a.AmountOfExchangeProfitAndLoss
	,cast(b.csign as varchar(50)) + '-' + RIGHT('0000' + cast(b.ino_id as varchar(50)),4) as GLVoucherNO
	,b.md as Debit,b.mc as Credit
	,cast(c.csign as varchar(50)) + '-' + RIGHT('0000' + cast(c.ino_id as varchar(50)),4) as RedGLVoucherNO
	,c.md as RedDebit,c.mc as RedCredit
	,case when c.md is not null then cast(d.csign as varchar(50)) + '-' + RIGHT('0000' + cast(d.ino_id as varchar(50)),4) end as Sourcecsign
    ,case when c.md is not null then a.SourceiYear end as SourceiYear
    ,case when c.md is not null then a.SourceiPeriod end as SourceiPeriod
from
(
	select  a.iYear,a.iPeriod,a.ino_id,a.csign,cast(sum(a.AmountOfExchangeProfitAndLoss) as decimal(16,2)) as [AmountOfExchangeProfitAndLoss] 
		,a.[RedcSign],a.[Redino_id]
		,a.Sourcecsign,a.Sourceino_id,a.SourceiYear,a.SourceiPeriod
	from [dbo].[_AmountOfExchangeProfitAndLoss] a
	group by a.iYear,a.iPeriod,a.ino_id,a.csign ,a.Sourcecsign,a.Sourceino_id,a.SourceiYear,a.SourceiPeriod,a.[RedcSign],a.[Redino_id]
) a
	left join 
(
	select csign,ino_id,iyear,iperiod,sum(md) as md,sum(mc) as mc
	from GL_accvouch 
    where iflag is null
	group by csign,ino_id,iyear,iperiod
) b on cast(a.csign as nvarchar(50)) = cast(b.csign as nvarchar(50)) and cast(a.ino_id as nvarchar(50)) = cast(b.ino_id as nvarchar(50)) and a.iYear = b.iyear and a.iPeriod = b.iperiod
	left join
(
	select csign,ino_id,iyear,iperiod,sum(md) as md,sum(mc) as mc
	from GL_accvouch 
    where iflag is null
	group by csign,ino_id,iyear,iperiod
)c  on cast(a.[RedcSign] as nvarchar(50)) = cast(c.csign as nvarchar(50)) and cast(a.[Redino_id] as nvarchar(50)) = cast(c.ino_id as nvarchar(50)) and a.iyear = c.iyear  and a.iperiod = c.iperiod
	left join
(
	select csign,ino_id,iyear,iperiod,sum(md) as md,sum(mc) as mc
	from GL_accvouch 
    where iflag is null
	group by csign,ino_id,iyear,iperiod
)d  on cast(a.Sourcecsign as nvarchar(50)) = cast(d.csign as nvarchar(50)) and cast(a.Sourceino_id as nvarchar(50)) = cast(d.ino_id as nvarchar(50)) and a.SourceiYear = d.iyear and a.SourceiPeriod = d.iperiod
where 1=1
order by a.iYear,a.iPeriod
";
                sSQL = sSQL.Replace("1=1", "1=1 and a.iYear = " + lookUpEditYear.EditValue.ToString().Trim());
                if (lookUpEditPeriod1.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.iPeriod >= " + lookUpEditPeriod1.Text.Trim());
                }
                if (lookUpEditPeriod1.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.iPeriod <= " + lookUpEditPeriod2.Text.Trim());
                }
                DataTable dt = DbHelperSQL.Query(sSQL);
                gridControl1.DataSource = dt;
                gridView1.BestFitColumns();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnExchangeVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                int iRow = gridView1.FocusedRowHandle;

                if (iRow < 0)
                {
                    throw new Exception("Please choose data");
                }

                string sYear = gridView1.GetRowCellValue(iRow, gridColiYear).ToString().Trim();
                string sMonth = gridView1.GetRowCellValue(iRow, gridColiPeriod).ToString().Trim();

                if (sYear == "" || sMonth == "")
                {
                    throw new Exception("Please choose data");
                }

                FrmExchangeDetails frm = new FrmExchangeDetails(sYear, sMonth);
                frm.ShowDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnDeleteVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want delete this voucher", "", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != DialogResult.Yes)
                {
                    throw new Exception("User cancelled");
                }

                int iRow = gridView1.FocusedRowHandle;
                if (iRow < 0)
                {
                    throw new Exception("Please choose data");
                }

                int iYear = BaseFunction.ReturnInt(gridView1.GetRowCellValue(iRow, gridColiYear));
                int iPeriod = BaseFunction.ReturnInt(gridView1.GetRowCellValue(iRow, gridColiPeriod));

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    string sSQL = "SELECT bflag FROM dbo.GL_mend WHERE iyear = aaaaaa AND iperiod = bbbbbb";
                    sSQL = sSQL.Replace("aaaaaa", iYear.ToString());
                    sSQL = sSQL.Replace("bbbbbb", iPeriod.ToString());
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        throw new Exception("Failed to obtain module status");
                    }
                    if (BaseFunction.ReturnBool(dt.Rows[0]["bflag"]))
                    {
                        throw new Exception("The current date has been checked out");
                    }

                    sSQL = @"
select csign,i_id
from _AmountOfExchangeProfitAndLoss 
where iyear = {0} and iPeriod = {1}
";
                    sSQL = string.Format(sSQL, iYear, iPeriod);
                    DataTable dtGL = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtGL == null || dtGL.Rows.Count == 0)
                    {
                        throw new Exception("Please check exists");
                    }

                    sSQL = @"
 update GL_accvouch set iflag = 1
 where iyear = aaaaaaaa and iperiod = bbbbbbbb and csign = 'cccccccc' and ino_id in (select ino_id from GL_accvouch where i_id = 'dddddddd')
";
                    sSQL = sSQL.Replace("aaaaaaaa", gridView1.GetRowCellValue(iRow, gridColiYear).ToString());
                    sSQL = sSQL.Replace("bbbbbbbb", gridView1.GetRowCellValue(iRow, gridColiPeriod).ToString());
                    sSQL = sSQL.Replace("cccccccc", dtGL.Rows[0]["csign"].ToString().Trim());
                    sSQL = sSQL.Replace("dddddddd", dtGL.Rows[0]["i_id"].ToString().Trim());
                    int iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    if (iCou > 0)
                    {
                        tran.Commit();

                        MessageBox.Show("Sucess");
                        btnQuery_Click(null, null);
                    }
                    else
                    {
                        throw new Exception("Err:no data");
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
                f.Text = "Err";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void btnCreateRedVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                int iRow = gridView1.FocusedRowHandle;
                if (iRow < 0)
                {
                    throw new Exception("Please choose data");
                }

                int iCou = 0;

                int iYearSource = BaseFunction.ReturnInt(gridView1.GetRowCellValue(iRow, gridColiYear));
                int iPeriodSource = BaseFunction.ReturnInt(gridView1.GetRowCellValue(iRow, gridColiPeriod));

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    string[] s = lLoginPeriod.Text.Trim().Split('.');
                    int iYear = BaseFunction.ReturnInt(s[0]);
                    int iPeriod = BaseFunction.ReturnInt(s[1]);

                    string sSQL = @"
SELECT bflag 
FROM dbo.GL_mend 
WHERE iyear = aaaaaa AND iperiod = bbbbbb";
                    sSQL = sSQL.Replace("aaaaaa", iYear.ToString());
                    sSQL = sSQL.Replace("bbbbbb", iPeriod.ToString());
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        throw new Exception("Failed to obtain module status");
                    }
                    if (BaseFunction.ReturnBool(dt.Rows[0]["bflag"]))
                    {
                        throw new Exception("The current date has been checked out");
                    }


                    #region 生成红冲凭证

                    sSQL = @"
select *
from GL_accvouch 
where iyear = aaaaaa and iperiod = bbbbbb  and isnull(iflag,0) = 0
    and ino_id = 'cccccc' and csign = 'dddddd'
    ";
                    sSQL = sSQL.Replace("aaaaaa", iYearSource.ToString());
                    sSQL = sSQL.Replace("bbbbbb", iPeriodSource.ToString());

                    string sGLVoucherNO = gridView1.GetRowCellValue(iRow, gridColGLVoucherNO).ToString().Trim();
                    if (sGLVoucherNO == "")
                    { 
                        throw new Exception("Please choose source");
                    }

                    string[] sGlSource =sGLVoucherNO.Split('-');
                    sSQL = sSQL.Replace("cccccc", sGlSource[1]);
                    sSQL = sSQL.Replace("dddddd", sGlSource[0]);

                    dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No data.Please manually generate the red document");
                    }
                    else
                    {
                        string sGLRedVouch = gridView1.GetRowCellValue(iRow, gridColRedGLVoucherNO).ToString().Trim();
                        if (sGLRedVouch != "")
                        {
                            sGlSource = sGLRedVouch.Split('-');

                            sSQL = @"
select *
from GL_accvouch 
where csign = 'AP' and iyear = aaaaaa and iperiod = bbbbbb and isnull(iflag,0) = 0
    and ino_id = 'cccccc' and csign = 'dddddd'
";
                            sSQL = sSQL.Replace("aaaaaa", iYear.ToString());
                            sSQL = sSQL.Replace("bbbbbb", iPeriod.ToString());
                            sSQL = sSQL.Replace("cccccc", sGlSource[1]);
                            sSQL = sSQL.Replace("dddddd", sGlSource[0]);
                            dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                            if (dt != null && dt.Rows.Count > 0)
                            {
                                throw new Exception("Accounting vouchers already exist");
                            }
                        }

                        sSQL = "select isnull(max(ino_id),0) as ino_id from GL_accvouch where iyear = aaaaaa AND iperiod = bbbbbb and csign = 'AP'";
                        sSQL = sSQL.Replace("aaaaaa", iYear.ToString());
                        sSQL = sSQL.Replace("bbbbbb", iPeriod.ToString());
                        DataTable dtinoid = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        int ino_id = BaseFunction.ReturnInt(dtinoid.Rows[0]["ino_id"]);
                        ino_id += 1;
                        string sVoucher = "AP-" + ino_id.ToString().PadLeft(4, '0') + "\n";
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            Model.GL_accvouch mod = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.GL_accvouch();
                            DAL.GL_accvouch dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.GL_accvouch();

                            mod = dal.DataRowToModel(dt.Rows[i]);

                            mod.ino_id = ino_id;
                            mod.iyear = iYear;
                            mod.iperiod = iPeriod;
                            mod.iYPeriod = BaseFunction.ReturnInt(BaseFunction.ReturnDate(iYearSource.ToString() + "-" + iPeriod.ToString() + "-01").ToString("yyyyMM"));
                            mod.md = -1 * mod.md;
                            mod.mc = -1 * mod.mc;
                            mod.md_f = -1 * mod.md_f;
                            mod.md_f = -1 * mod.md_f;

                            sSQL = dal.Add(mod);
                            iCou += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        if (iCou > 0)
                        {

                            sSQL = @"
select *
from GL_accvouch
where iyear = {0} and iPeriod = {1} and csign = '{2}' and ino_id = {3}
";
                            sSQL = string.Format(sSQL, iYear.ToString(), iPeriod.ToString(),"AP", ino_id);
                            DataTable dtGL = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                            sSQL = @"
update [dbo].[_AmountOfExchangeProfitAndLoss] set [RedcSign] = 'aaaaaaaa',[Redi_id] = bbbbbbbb,[Redino_id] = 'iiiiiiii'
	,[SourceiYear] =cccccccc ,[SourceiPeriod] = dddddddd,[SourcecSign] = 'eeeeeeee',[Sourceino_id] = ffffffff
where iYear = gggggggg and iPeriod = hhhhhhhh
";
                            sSQL = sSQL.Replace("aaaaaaaa", sGlSource[0]);
                            sSQL = sSQL.Replace("bbbbbbbb", dtGL.Rows[0]["i_id"].ToString());
                            sSQL = sSQL.Replace("cccccccc", iYearSource.ToString());
                            sSQL = sSQL.Replace("dddddddd", iPeriodSource.ToString());
                            sSQL = sSQL.Replace("eeeeeeee", sGlSource[0]);
                            sSQL = sSQL.Replace("ffffffff", sGlSource[1]);
                            sSQL = sSQL.Replace("gggggggg", iYear.ToString());
                            sSQL = sSQL.Replace("hhhhhhhh", iPeriod.ToString());
                            sSQL = sSQL.Replace("iiiiiiii", BaseFunction.ReturnInt( sVoucher.Split('-')[1]).ToString().Trim());
                            int iCount = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            if (iCount == 0)
                            {
                                throw new Exception("Please CreateVoucher first");
                            }

                        }
                    }


                    #endregion

                    if (iCou > 0)
                    {
                        tran.Commit();

                        MessageBox.Show("Sucess");
                        btnQuery_Click(null, null);
                    }
                    else
                    {
                        throw new Exception("Err:no data");
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
                f.Text = "Err";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void btnDeleteRedVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want delete this voucher", "", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != DialogResult.Yes)
                {
                    throw new Exception("User cancelled");
                }

                int iRow = gridView1.FocusedRowHandle;
                if (iRow < 0)
                {
                    throw new Exception("Please choose data");
                }

                int iYear = BaseFunction.ReturnInt(gridView1.GetRowCellValue(iRow, gridColiYear));
                int iPeriod = BaseFunction.ReturnInt(gridView1.GetRowCellValue(iRow, gridColiPeriod));

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    string sSQL = "SELECT bflag FROM dbo.GL_mend WHERE iyear = aaaaaa AND iperiod = bbbbbb";
                    sSQL = sSQL.Replace("aaaaaa", iYear.ToString());
                    sSQL = sSQL.Replace("bbbbbb", iPeriod.ToString());
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        throw new Exception("Failed to obtain module status");
                    }
                    if (BaseFunction.ReturnBool(dt.Rows[0]["bflag"]))
                    {
                        throw new Exception("The current date has been checked out");
                    }

                    sSQL = @"
 update GL_accvouch set iflag = 1
 where iyear = aaaaaaaa and iperiod = bbbbbbbb and csign = 'cccccccc' and ino_id = 'dddddddd'
";
                    sSQL = sSQL.Replace("aaaaaaaa", gridView1.GetRowCellValue(iRow, gridColiYear).ToString());
                    sSQL = sSQL.Replace("bbbbbbbb", gridView1.GetRowCellValue(iRow, gridColiPeriod).ToString());

                    string[] s = gridView1.GetRowCellValue(iRow, gridColRedGLVoucherNO).ToString().Trim().Split('-');
                    sSQL = sSQL.Replace("cccccccc", s[0]);
                    sSQL = sSQL.Replace("dddddddd", s[1]);
                    int iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    if (iCou > 0)
                    {
                        tran.Commit();

                        MessageBox.Show("Sucess");
                        btnQuery_Click(null, null);
                    }
                    else
                    {
                        throw new Exception("Err:no data");
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
                f.Text = "Err";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }
    }
}
