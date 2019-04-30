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
    public partial class Exchange : UserControl
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
                label1.Text = "";

                DbHelperSQL.connectionString = Conn;

                DateTime dLogDate = BaseFunction.ReturnDate(sLogDate);
                string sSQL = @"
select distinct cast(year(dDate) as varchar(4)) + '.' + right('00' + cast(MONTH(dDate) as varchar(2)),2) as Period 
from Rdrecord01 
order by cast(year(dDate) as varchar(4)) + '.' + right('00' + cast(MONTH(dDate) as varchar(2)),2) desc
";
                DataTable dt = DbHelperSQL.Query(sSQL);
                lookUpEditPeriod.Properties.DataSource = dt;

                lookUpEditPeriod.EditValue = dLogDate.Year.ToString() + "." + dLogDate.Month.ToString().PadLeft(2,'0');

            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "Err";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        public Exchange()
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

      

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (lookUpEditPeriod.Text.Trim() == "")
                {
                    lookUpEditPeriod.Focus();
                    throw new Exception("Please set period");
                }

                bool bCreated = false;

                string[] s = lookUpEditPeriod.Text.Trim().Split('.');
                DateTime dDate = BaseFunction.ReturnDate(s[0] + "-" + s[1] + "-01");

                string sSQL = @"
select a.*,b.ino_id ,rd.cVenCode,v.cVenName
from _AmountOfExchangeProfitAndLoss a 
    left join gl_accvouch b on a.iYear = b.iyear and a.iPeriod = b.iperiod and a.i_id = b.i_id
    left join Rdrecord01 rd on rd.cCode = a.cCode
    left join Vendor v on rd.cVencode = v.cVenCode
where a.iyear = aaaaaaaa and a.iperiod = bbbbbbbb
";
                sSQL = sSQL.Replace("aaaaaaaa", dDate.Year.ToString());
                sSQL = sSQL.Replace("bbbbbbbb", dDate.Month.ToString());
                DataTable dt = DbHelperSQL.Query(sSQL);
                if (dt != null && dt.Rows.Count > 0)
                {
                    sSQL = @"
select i_id
from GL_accvouch
where iYear = {0} and iPeriod = {1} and csign = '{2}' and ino_id = '{3}' and i_id = '{4}' and iflag is null
";
                    sSQL = string.Format(sSQL, dDate.Year.ToString(), dDate.Month.ToString(), dt.Rows[0]["csign"].ToString().Trim(), dt.Rows[0]["ino_id"].ToString().Trim(), dt.Rows[0]["i_id"].ToString().Trim());
                    DataTable dtTemp = DbHelperSQL.Query(sSQL);
                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                    {
                        bCreated = true;

                        gridControl1.DataSource = dt;

                        label1.Text = "Saved";
                    }
                }
                if (!bCreated)
                {
                    sSQL = @"

select * 
from 
(
    select a.cCode,b.irowno, a.cExch_Name,CONVERT(varchar(100),a.dDate, 23) as dDate,'20' + CONVERT(varchar(100),a.dDate, 2) as dDateExch
	    ,b.AutoID,b.cInvCode,inv.cInvName,inv.cInvStd
	    ,cast(b.ioriSum - isnull(pur.iOriMoney,0) as decimal(16,2)) as iOriSum
	    ,case when isnull(e.nflat,0) = 0 then a.iExchRate else e.nflat end as nflat
        ,f.nflat as nflat2
	    ,cast((b.ioriSum - isnull(pur.iOriMoney,0)) * (a.iExchRate - f.nflat) as decimal(16,2)) as [AmountOfExchangeProfitAndLoss]
        ,a.cVenCode,v.cVenName
    from RdRecord01 a inner join Rdrecords01 b on a.id = b.id 
	    inner join Inventory inv on b.cInvCode = inv.cInvCode
	    left join exch e on e.cexch_name = a.cExch_Name and e.cdate = '20' + CONVERT(varchar(100),a.dDate, 2) and e.itype = 1 and e.iYear = year('aaaaaaaa')
	    left join exch f on f.cexch_name = a.cExch_Name and f.iperiod = month('aaaaaaaa') and f.itype = 3 and f.iYear = year('aaaaaaaa')
	    left join (
		    select sum(iPBVQuantity) as iPBVQuantity , sum(b.iOriMoney) as iOriMoney ,sum(b.iMoney) as iMoney,b.RdsId 
		    from PurBillVouch a inner join PurBillVouchs b on a.PBVID = b.PBVID 
		    where a.dPBVDate < 'bbbbbbbb'
		    group by b.RdsId 
		    ) pur on pur.RdsId = b.AutoID
        left join Vendor v on a.cVenCode = v.cVenCode
    where a.cExch_Name <> 'THB'
	    and a.dDate < 'bbbbbbbb'
	    and b.iQuantity > isnull(iSumBillQuantity,0)
	    and b.ioriSum - isnull(pur.iOriMoney,0) > 0
    union 

    select a.cCode,b.irowno, a.cExch_Name,CONVERT(varchar(100),a.dDate, 23) as dDate,'20' + CONVERT(varchar(100),a.dDate, 2) as dDateExch
	    ,b.AutoID,b.cInvCode,inv.cInvName,inv.cInvStd
	    ,cast(b.ioriSum - isnull(pur.iOriMoney,0) as decimal(16,2)) as iOriSum
	    ,case when isnull(e.nflat,0) = 0 then a.iExchRate else e.nflat end as nflat
        ,f.nflat as nflat2
	    ,-1 * cast((b.ioriSum - isnull(pur.iOriMoney,0)) * (a.iExchRate - f.nflat) as decimal(16,2)) as [AmountOfExchangeProfitAndLoss]
        ,a.cVenCode,v.cVenName
    from RdRecord01 a inner join Rdrecords01 b on a.id = b.id 
	    inner join Inventory inv on b.cInvCode = inv.cInvCode
	    left join exch e on e.cexch_name = a.cExch_Name and e.cdate = '20' + CONVERT(varchar(100),a.dDate, 2) and e.itype = 1 and e.iYear = year('aaaaaaaa')
	    left join exch f on f.cexch_name = a.cExch_Name and f.iperiod = month('aaaaaaaa') and f.itype = 3 and f.iYear = year('aaaaaaaa')
	    left join (
		    select sum(iPBVQuantity) as iPBVQuantity , sum(b.iOriMoney) as iOriMoney ,sum(b.iMoney) as iMoney,b.RdsId 
		    from PurBillVouch a inner join PurBillVouchs b on a.PBVID = b.PBVID 
		    where a.dPBVDate < 'bbbbbbbb'
		    group by b.RdsId 
		    ) pur on pur.RdsId = b.AutoID
        left join Vendor v on a.cVenCode = v.cVenCode
    where a.cExch_Name <> 'THB'
	    and a.dDate < 'bbbbbbbb'
	    and b.iQuantity < isnull(iSumBillQuantity,0)
	    and b.ioriSum - isnull(pur.iOriMoney,0) < 0
) a 

order by a.cExch_Name,a.AutoID
";
                    sSQL = sSQL.Replace("aaaaaaaa", dDate.ToString("yyyy-MM-dd"));
                    sSQL = sSQL.Replace("bbbbbbbb", dDate.AddMonths(1).ToString("yyyy-MM-dd"));
                    dt = DbHelperSQL.Query(sSQL);
                    gridControl1.DataSource = dt;

                    label1.Text = "Add";
                }
                gridView1.BestFitColumns();
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "Err";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string[] s = lookUpEditPeriod.Text.Trim().Split('.');
                int iYear = BaseFunction.ReturnInt(s[0]);
                int iPeriod = BaseFunction.ReturnInt(s[1]);

                string sVoucher = "";
                string sErr = "";
                int iCount = 0;
                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    string sSQL = "SELECT * FROM dbo.GL_mend WHERE iyear = aaaaaa AND iperiod = bbbbbb";
                    sSQL = sSQL.Replace("aaaaaa", iYear.ToString());
                    sSQL = sSQL.Replace("bbbbbb", iPeriod.ToString());
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        throw new Exception("Failed to obtain module status");
                    }
                    if (BaseFunction.ReturnBool(dt.Rows[0]["bflag"]))
                    {
                        throw new Exception("General ledger");
                    }

                    string sino_id = "";
                    long i_id = -1;

                    sSQL = @"
select bflag from gl_mend where iyear = aaaaaa and iperiod = bbbbbb
";
                    sSQL = sSQL.Replace("aaaaaa", iYear.ToString());
                    sSQL = sSQL.Replace("bbbbbb", iPeriod.ToString());
                    DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (BaseFunction.ReturnBool(dtTemp.Rows[0]["bflag"]))
                    {
                        throw new Exception("The current date has been checked out");
                    }

                    sSQL = @"
select * 
from _AmountOfExchangeProfitAndLoss
where iyear = aaaaaa and iperiod = bbbbbb
";
                    sSQL = sSQL.Replace("aaaaaa", iYear.ToString());
                    sSQL = sSQL.Replace("bbbbbb", iPeriod.ToString());
                    dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        if (DialogResult.Yes != MessageBox.Show("The document has been generated. Will it continue?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk))
                        {
                            throw new Exception("User cancelled");
                        }

                        i_id = BaseFunction.ReturnLong(dt.Rows[0]["i_id"]);

                        sSQL = @"
delete _AmountOfExchangeProfitAndLoss where iyear = aaaaaa and iperiod = bbbbbb
";
                        sSQL = sSQL.Replace("aaaaaa", iYear.ToString());
                        sSQL = sSQL.Replace("bbbbbb", iPeriod.ToString());
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    if (sino_id != "")
                    {
                        sSQL = @"
select *
from GL_accvouch 
where csign = 'AP' and iyear = aaaaaa and iperiod = bbbbbb and ino_id = 'cccccc' and isnull(iflag,0) = 0 and i_id = 'dddddd'
";
                        sSQL = sSQL.Replace("aaaaaa", iYear.ToString());
                        sSQL = sSQL.Replace("bbbbbb", iPeriod.ToString());
                        sSQL = sSQL.Replace("cccccc", sino_id);
                        sSQL = sSQL.Replace("dddddd", i_id.ToString());
                        dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        if (dt != null && dt.Rows.Count > 0)
                        {
                            throw new Exception("Accounting vouchers already exist");
                        }
                    }

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {

                        Model._AmountOfExchangeProfitAndLoss mod = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._AmountOfExchangeProfitAndLoss();
                        mod.iYear = iYear;
                        mod.iPeriod = iPeriod;
                        mod.AutoID = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColAutoID));
                        mod.cCode = gridView1.GetRowCellValue(i, gridColcCode).ToString().Trim();
                        mod.irowno = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColirowno));
                        mod.cExch_Name = gridView1.GetRowCellValue(i, gridColcExch_Name).ToString().Trim();
                        mod.dDate = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridColdDate));

                        mod.cInvCode = gridView1.GetRowCellValue(i, gridColcInvCode).ToString().Trim();
                        mod.cInvName = gridView1.GetRowCellValue(i, gridColcInvName).ToString().Trim();
                        mod.cInvStd = gridView1.GetRowCellValue(i, gridColcInvStd).ToString().Trim();
                        mod.iOriSum = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColiOriSum));
                        mod.nflat = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColnflat));
                        mod.nflat2 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColnflat2));
                        mod.AmountOfExchangeProfitAndLoss = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColAmountOfExchangeProfitAndLoss));
                        mod.i_ID = -1;
                        mod.redi_ID = -1;

                        if (mod.nflat == 0 || mod.nflat2 == 0)
                        {
                            throw new Exception("Please set exchange rate");
                        }

                        DAL._AmountOfExchangeProfitAndLoss dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._AmountOfExchangeProfitAndLoss();
                        sSQL = dal.Add(mod);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    if (MessageBox.Show("Whether to generate accounting vouchers?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    {

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
                        sSQL = @"
select sum(AmountOfExchangeProfitAndLoss) as AmountOfExchangeProfitAndLoss ,rd.cVenCode
from _AmountOfExchangeProfitAndLoss a
	left join RdRecord01 rd on a.cCode = rd.cCode
where a.iyear = aaaaaa and a.iperiod = bbbbbb
group by rd.cVenCode
";
                        sSQL = sSQL.Replace("aaaaaa", iYear.ToString());
                        sSQL = sSQL.Replace("bbbbbb", iPeriod.ToString());
                        DataTable dtSum = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtSum == null || dtSum.Rows.Count == 0)
                        {
                            throw new Exception("No data");
                        }

                        sSQL = "select isnull(max(ino_id),0)  from GL_accvouch where iyear = aaaaaa AND iperiod = bbbbbb and csign = 'AP'";
                        sSQL = sSQL.Replace("aaaaaa", iYear.ToString());
                        sSQL = sSQL.Replace("bbbbbb", iPeriod.ToString());
                        DataTable dtinoid = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        int ino_id = BaseFunction.ReturnInt(dtinoid.Rows[0][0]) + 1;

                        decimal dSum = 0;

                        #region 生成凭证
                        sVoucher = sVoucher + "AP-" + ino_id.ToString().PadLeft(4, '0') + "\n";

                        #region 借方
                        for (int i = 0; i < dtSum.Rows.Count; i++)
                        {
                            decimal dMoney = BaseFunction.ReturnDecimal(dtSum.Rows[i]["AmountOfExchangeProfitAndLoss"], 2);
                            dSum = dSum + dMoney;
                        }

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
                        model.md = dSum;
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

                        model.csup_id = dtSum.Rows[0]["cVenCode"].ToString().Trim();

                        UFIDA.U8.UAP.CustomApp.ControlForm.DAL.GL_accvouch dalGL = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.GL_accvouch();
                        sSQL = dalGL.Add(model);
                        iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        #endregion

                        for (int i = 0; i < dtSum.Rows.Count; i++)
                        {
                            #region 贷方
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
                            model.mc = BaseFunction.ReturnDecimal(dtSum.Rows[i]["AmountOfExchangeProfitAndLoss"], 2);
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

                            dalGL = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.GL_accvouch();
                            sSQL = dalGL.Add(model);
                            iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            #endregion
                        }
                       
                        #endregion

                        sSQL = @"
select i_id from GL_accvouch where iyear = {0} and iperiod = {1} and csign = '{2}' and ino_id = {3}
";
                        sSQL = string.Format(sSQL, model.iyear, model.iperiod, model.csign, model.ino_id);
                        dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        i_id = BaseFunction.ReturnLong(dtTemp.Rows[0]["i_id"]);

                        sSQL = @"
update _AmountOfExchangeProfitAndLoss set csign = 'AP',i_id = 'dddddddd',ino_id = 'eeeeee'
where  iyear = bbbbbbbb and iperiod = cccccccc
";
                        sSQL = sSQL.Replace("bbbbbbbb", model.iyear.ToString());
                        sSQL = sSQL.Replace("cccccccc", model.iperiod.ToString());
                        sSQL = sSQL.Replace("dddddddd", i_id.ToString().Trim());
                        sSQL = sSQL.Replace("eeeeee", model.ino_id.ToString().Trim());
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                    tran.Commit();

                    MessageBox.Show("Sucess\n" + sVoucher);


                    label1.Text = "";
                    gridControl1.DataSource = null;
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

        private void btnExport_Click(object sender, EventArgs e)
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
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "导出Excel失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }
    }
}
