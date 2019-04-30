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

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class SaleBillVouch : UserControl
    {
        TH.BaseClass.GetBaseData getBaseData = new GetBaseData();
        
        string sProPath = Application.StartupPath;

        UFIDA.U8.UAP.CustomApp.ControlForm.RepBaseGrid Rep = new RepBaseGrid();

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

                dateEdit1.DateTime = DateTime.Today;
                dateEdit2.DateTime = DateTime.Today;
                SetLookUp();
                GetGrid();
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void SetLookUp()
        {
            string sSQL = "select cSBVCode from SaleBillVouch order by cSBVCode";
            DataTable dt = DbHelperSQL.Query(sSQL);
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditcSBVCode1.Properties.DataSource = dt;
            lookUpEditcSBVCode2.Properties.DataSource = dt;
        }

        public SaleBillVouch()
        {
            InitializeComponent();
        }

        private void btnExportTxt_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                string sSQL = "select getdate()";
                string sTime = BaseFunction.ReturnDate(DbHelperSQL.GetSingle(sSQL)).ToString("yyyyMMddHHmmss");

                StringBuilder strID = new StringBuilder();
                StringBuilder strIDs = new StringBuilder();
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (!BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColchoose)))
                    {
                        continue;
                    }

                    if (strID.ToString().Trim() == "")
                    {
                        strID.Append(gridView1.GetRowCellValue(i, gridColSBVID).ToString().Trim());
                    }
                    else
                    {
                        strID.Append("," + gridView1.GetRowCellValue(i, gridColSBVID).ToString().Trim());
                    }

                    if (strIDs.ToString().Trim() == "")
                    {
                        strIDs.Append(gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim());
                    }
                    else
                    {
                        strIDs.Append("," + gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim());
                    }
                }

                if (strID.ToString().Trim() == "")
                {
                    throw new Exception("Please choose data");
                }

                sSQL = @"
select a.*  ,b.cCusDefine4,c.cSSName
    ,cast(e.iMoney as decimal(16,2)) as iMoney,cast(e.iSum as decimal(16,2)) as iSum,cast(e.iNatSum as decimal(16,2)) as iNatSum
    ,cast(e.iTax as decimal(16,2)) as iTax,b.cCusDefine2,a.cDefine16 as EditCount
	,d.*
from SaleBillVouch a
    inner join Customer b ON a.cCusCode = b.cCusCode
	left join SettleStyle c on a.cSSCode = c.cSSCode 
	LEFT JOIN dbo.[_SalesSet] d ON d.SalesType = a.cSTCode
    left join 
    (
        SELECT SUM(iMoney) AS iMoney ,SBVID,sum(iSum) as iSum,sum(iNatSum) as iNatSum,sum(iTax) as iTax
        FROM SaleBillVouchs
        GROUP BY SBVID
     )e on e.SBVID = a.SBVID
where 1=1
order by a.SBVID

";
                sSQL = sSQL.Replace("1=1", "1=1 and  a.SBVID IN (" + strID.ToString() + ") ");
                DataTable dtHead = DbHelperSQL.Query(sSQL);

                sSQL = @"
select distinct *
from
(
select distinct a.SBVID,c.cCusDefine4,d.cSSName
    ,e.*
	,isnull(cDefine16,0) as EditCount
    ,cast(h.iSum as decimal(16,2)) as iSumH,cast(h.iNatSum as decimal(16,2)) as iNatSumH,cast(h.iTax as decimal(16,2)) as iTaxH,c.cCusDefine2
    ,cc.ccdefine1
	,aa.chdefine9
from SaleBillVouch a 
    inner join SaleBillVouch_extradefine aa on a.SBVID = aa.SBVID
    inner join SaleBillVouchs b on a.SBVID = b.SBVID 
    left join SaleBillVouchs_extradefine bb on bb.AutoID = b.AutoID
    inner join Customer c ON a.cCusCode = c.cCusCode
    inner join Customer_extradefine cc on cc.cCusCode = c.cCusCode
	left join SettleStyle d on a.cSSCode = d.cSSCode 
	LEFT JOIN dbo.[_SalesSet] e ON e.SalesType = a.cSTCode
    left join 
    (
        SELECT SUM(iMoney) AS iMoney ,SBVID,sum(iSum) as iSum,sum(iNatSum) as iNatSum,sum(iTax) as iTax
        FROM SaleBillVouchs
        GROUP BY SBVID
     )h on h.SBVID = a.SBVID
where 1=1
)a
order by a.SBVID
";
                sSQL = sSQL.Replace("1=1", "1=1 and  a.SBVID IN (" + strID.ToString() + ") ");
                DataTable dtDetails = DbHelperSQL.Query(sSQL);

                if (dtHead == null || dtHead.Rows.Count == 0)
                {
                    throw new Exception("Please choose data");
                }

                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "txt";
                sF.FileName = "ARH" + sTime + "PLT";
                sF.Filter = "Txt文件(*.txt)|*.txt|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK != dRes)
                {
                    return;
                }

                
                StringBuilder strHead = new StringBuilder();
                for (int i = 0; i < dtHead.Rows.Count; i++)
                {
                    DataRow[] drs = dtDetails.Select("SBVID = " + dtHead.Rows[i]["sbvid"].ToString().Trim());

                    //1 Data type
                    strHead.Append("IN202");
                    strHead.Append("|");
                    //2 System type
                    strHead.Append("PLATING");
                    strHead.Append("|");
                    //3 Preparation key
                    strHead.Append("XX");
                    strHead.Append("|");
                    //4 Company Code
                    strHead.Append("4131");
                    strHead.Append("|");
                    //5 Customer
                    strHead.Append(dtHead.Rows[i]["cCusDefine2"].ToString().Trim());
                    strHead.Append("|");
                    //6 Invoice Number
                    strHead.Append(dtHead.Rows[i]["cSBVCode"].ToString().Trim());
                    strHead.Append("|");
                    //7 Revised Indicator
                    decimal dMoney = BaseFunction.ReturnDecimal(dtHead.Rows[i]["iMoney"]);
                    if (dMoney > 0)
                    {
                        strHead.Append("A");
                    }
                    else
                    {
                        strHead.Append("N");
                    }
                    strHead.Append("|");
                    //8 Trading type
                    strHead.Append("TT");
                    strHead.Append("|");
                    //9 Transaction Number
                    int iEditCount = BaseFunction.ReturnInt(dtHead.Rows[i]["EditCount"]);
                    strHead.Append(dtHead.Rows[i]["cSBVCode"].ToString().Trim() + "-" + iEditCount.ToString().Trim());
                    strHead.Append("|");

                    //10 Document Type
                    if (dMoney > 0)
                    {
                        strHead.Append("DR");
                        strHead.Append("|");
                    }
                    else
                    {
                        strHead.Append("DG");
                        strHead.Append("|");
                    }

                    DateTime dDate = BaseFunction.ReturnDate(dtHead.Rows[i]["dDate"]);
                    //11 Invoice Date(=Document Date)
                    strHead.Append(dDate.ToString("yyyyMMdd"));
                    strHead.Append("|");
                    //12 Posting Date
                    strHead.Append(dDate.ToString("yyyyMMdd"));     //dverifydate 
                    strHead.Append("|");
                    //13 Special G/L Indicator
                    strHead.Append("");
                    strHead.Append("|");
                    //14 Payment Term
                    strHead.Append("");
                    strHead.Append("|");
                    //15 Payment Method
                    strHead.Append("");
                    strHead.Append("|");
                    //16 Baseline Date
                    strHead.Append("00000000");
                    strHead.Append("|");
                    //17 House Bank ID
                    strHead.Append("");
                    strHead.Append("|");
                    //18 Transaction Currency
                    strHead.Append(dtHead.Rows[i]["cexch_name"].ToString().Trim());
                    strHead.Append("|");
                    //19 Exchange Rate
                    strHead.Append("0");
                    strHead.Append("|");
                    decimal dSum =BaseFunction.ReturnDecimal(BaseFunction.ReturnDecimal(dtHead.Rows[i]["iSum"], 2));
                    decimal dNatSum = Math.Abs(BaseFunction.ReturnDecimal(dtHead.Rows[i]["iNatSum"], 2));
                    //20 Total Amount by Transaction Currency
                    strHead.Append(Math.Abs( dSum).ToString().Trim());
                    strHead.Append("|");
                    //21 Total Amount by Local Currency
                    strHead.Append("0");
                    strHead.Append("|");
                    //22 Header Text
                    string sHead = dtHead.Rows[i]["HeadText"].ToString().Trim() + " " + dtHead.Rows[i]["cSBVCode"].ToString().Trim();
                    strHead.Append(sHead);
                    strHead.Append("|");
                    //23 Tax type
                    //decimal dTax = BaseFunction.ReturnDecimal(dtHead.Rows[i]["iTax"], 2);
                    //if (dTax > 0)
                    //{
                    //    strHead.Append("1");
                    //}
                    //else
                    //{
                    //    strHead.Append("2");
                    //}
                    strHead.Append("1");
                    strHead.Append("|");
                    //24 Assignment
                    strHead.Append("");
                    strHead.Append("|");
                    //25 Item text
                    strHead.Append(dtHead.Rows[i]["ItemText"].ToString().Trim() + " " + dtHead.Rows[i]["cCusName"].ToString().Trim());
                    strHead.Append("|");
                    //26 Clearing document number
                    strHead.Append("");
                    strHead.Append("|");
                    //27 Clearing document year
                    strHead.Append("");
                    strHead.Append("|");
                    //28 Status
                    strHead.Append("");
                    strHead.Append("|");
                    //29 User name
                    strHead.Append("");
                    strHead.Append("|");
                    //30 EntryProgram
                    strHead.Append("");
                    strHead.Append("|");
                    //31 Created on
                    strHead.Append("");
                    strHead.Append("|");
                    //32 Time of entry
                    strHead.Append("");
                    strHead.Append("|");
                    //33 Last Changed By
                    strHead.Append("");
                    strHead.Append("|");
                    //34 Update PGM
                    strHead.Append("");
                    strHead.Append("|");
                    //35 Date of Last Change
                    strHead.Append("");
                    strHead.Append("|");
                    //36 Time last change was made
                    strHead.Append("");
                    strHead.Append("|");

                    strHead.Append("\r\n");
                }


                StringBuilder strDetail = new StringBuilder();
                for (int i = 0; i < dtDetails.Rows.Count; i++)
                {
                    DataRow[] dr = dtHead.Select("SBVID = " + dtDetails.Rows[i]["sbvid"].ToString().Trim());
                    //1. Data type
                    strDetail.Append("IN202");
                    strDetail.Append("|");
                    //2 System type
                    strDetail.Append("PLATING");
                    strDetail.Append("|");
                    //3 Preparation key
                    strDetail.Append("XX");
                    strDetail.Append("|");
                    //4 Company Code
                    strDetail.Append("4131");
                    strDetail.Append("|");

                    //5 Customer
                    strDetail.Append(dr[0]["cCusDefine2"].ToString().Trim());
                    strDetail.Append("|");
                    //6 Invoice Number
                    strDetail.Append(dr[0]["cSBVCode"].ToString().Trim());
                    strDetail.Append("|");
                    //7 Revised Indicator
                    decimal dMoney = BaseFunction.ReturnDecimal(dtDetails.Rows[i]["iSumH"], 2);
                    if (dMoney > 0)
                    {
                        strDetail.Append("A");
                    }
                    else
                    {
                        strDetail.Append("N");
                    }
                    strDetail.Append("|");
                    //8 Trading type
                    strDetail.Append("TT");
                    strDetail.Append("|");
                    //9 Transaction Number
                    int iEditCount2 = BaseFunction.ReturnInt(dtDetails.Rows[i]["EditCount"]);
                    strDetail.Append(dr[0]["cSBVCode"].ToString().Trim() + "-" + iEditCount2.ToString().Trim());
                    strDetail.Append("|");
                    //10 Detail Line Number
                    strDetail.Append("1");
                    strDetail.Append("|");
                    //11 Debit/Credit
                    if (dMoney > 0)
                    {
                        strDetail.Append("H");
                    }
                    else
                    {
                        strDetail.Append("S");
                    }
                    strDetail.Append("|");
                    //12 SAP G/L Account code
                    strDetail.Append(dtDetails.Rows[i]["GLCode"].ToString().Trim());
                    strDetail.Append("|");
                    //13 Cost Centre
                    strDetail.Append(dtDetails.Rows[i]["chdefine9"].ToString().Trim());
                    strDetail.Append("|");
                    //14 Internal Order
                    strDetail.Append(dtDetails.Rows[i]["InternalOrder"].ToString().Trim());
                    strDetail.Append("|");
                    //15 Profit Centre
                    strDetail.Append(dtDetails.Rows[i]["ProfitCenter"].ToString().Trim());
                    strDetail.Append("|");
                    //16 Trading Partner
                    strDetail.Append("");
                    strDetail.Append("|");
                    //17 Plant
                    strDetail.Append("");
                    strDetail.Append("|");
                    //18 Material Number
                    strDetail.Append("");
                    strDetail.Append("|");
                    //19 Unit of Measure
                    strDetail.Append("");
                    strDetail.Append("|");
                    //20 Quantity
                    strDetail.Append("0");
                    strDetail.Append("|");
                    //21 Item Text
                    strDetail.Append(dtDetails.Rows[i]["ItemText2"].ToString().Trim() + " " + dtDetails.Rows[i]["ccdefine1"].ToString().Trim());
                    strDetail.Append("|");
                    //22 Assignment
                    strDetail.Append("");
                    strDetail.Append("|");
                    //23 Transaction Amount
                    strDetail.Append(Math.Abs(BaseFunction.ReturnDecimal(dtDetails.Rows[i]["iSumH"], 2)).ToString().Trim());
                    strDetail.Append("|");
                    //24 Local Amount
                    strDetail.Append("0");
                    strDetail.Append("|");
                    //25 Tax Code
                    strDetail.Append(dr[0]["cDefine1"].ToString().Trim());
                    strDetail.Append("|");

                    //26 Tax Rate
                    strDetail.Append("0");
                    strDetail.Append("|");
                    //27 Tax Amount by Transcation Currency
                    strDetail.Append("0");
                    strDetail.Append("|");
                    //28 Tax Amount by Local Currency 
                    strDetail.Append("0");
                    strDetail.Append("|");
                    //29 User name
                    strDetail.Append("");
                    strDetail.Append("|");
                    //30 EntryProgram
                    strDetail.Append("");
                    strDetail.Append("|");
                    //31 Created on
                    strDetail.Append("");
                    strDetail.Append("|");
                    //32 Time of entry
                    strDetail.Append("");
                    strDetail.Append("|");
                    //33 Last Changed By
                    strDetail.Append("");
                    strDetail.Append("|");
                    //34 Update PGM
                    strDetail.Append("");
                    strDetail.Append("|");
                    //35 Date of Last Change
                    DateTime dtmLast = BaseFunction.ReturnDate("");
                    //strDetail.Append(dtmLast.ToString("yyyyMMdd"));
                    strDetail.Append("|");
                    strDetail.Append("|");
                    //36 Time last change was made
                    strDetail.Append("");
                    strDetail.Append("|");

                    strDetail.Append("\r\n");
                }

                string sPath = sF.FileName;
                if (File.Exists(sPath))
                {
                    throw new Exception("File is exists");
                }

                string sPath2 = sPath.Replace("ARH", "ARD");
                if (File.Exists(sPath2))
                {
                    throw new Exception("File is exists");
                }


                File.WriteAllText(sPath, strHead.ToString());
                File.WriteAllText(sPath2, strDetail.ToString());
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

        private void btnSEL_Click(object sender, EventArgs e)
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


        private void GetGrid()
        {
            chkAll.Checked = false;

            string sSQL = @"
select cast(0 as bit) as choose, *
	,c.cInvName,c.cInvStd
	,d.cCusName
from SaleBillVouch a inner join SaleBillVouchs b on a.SBVID = b.SBVID 
	left join Inventory c on b.cInvCode = c.cInvCode
	left join Customer d on a.cCusCode = d.cCusCode
where 1=1 and isnull(b.iUnitPrice ,0) <> 0 and isnull(cChecker,'') <> ''
    and cVouchType = '27'
order by a.cSBVCode,a.SBVID ,b.AutoID
";

            if(lookUpEditcSBVCode1.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cSBVCode >= '" + lookUpEditcSBVCode1.Text.Trim().Trim() + "'");
            }
            if (lookUpEditcSBVCode2.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cSBVCode <= '" + lookUpEditcSBVCode2.Text.Trim().Trim() + "'");
            }
            if (dateEdit1.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.dDate >= '" + dateEdit1.Text.Trim().Trim() + "'");
            }
            if (dateEdit2.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.dDate <= '" + dateEdit2.Text.Trim().Trim() + "'");
            }
            DataTable dt = DbHelperSQL.Query(sSQL);
            gridControl1.DataSource = dt;

            gridView1.FocusedRowHandle = 0;
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            gridView1.AddNewRow();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridColchoose, chkAll.Checked);
                }
            }
            catch { }
        }

        ///// <summary>
        ///// Export the data from datatable to CSV file
        ///// </summary>
        ///// <param name="grid"></param>
        //public void ExportDataGridToCSV(DataTable dt, string sPath)
        //{
        //    System.IO.FileStream fs = new FileStream(sPath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
        //    StreamWriter sw = new StreamWriter(fs, new System.Text.UnicodeEncoding());
        //    //Tabel header
        //    for (int i = 0; i < dt.Columns.Count; i++)
        //    {
        //        sw.Write(dt.Columns[i].ColumnName);
        //        sw.Write("\t");
        //    }
        //    sw.WriteLine("");
        //    //Table body
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        for (int j = 0; j < dt.Columns.Count; j++)
        //        {
        //            sw.Write(DelQuota(dt.Rows[i][j].ToString()));
        //            sw.Write("\t");
        //        }
        //        sw.WriteLine("");
        //    }
        //    sw.Flush();
        //    sw.Close();
        //}

        ///// <summary>
        ///// Delete special symbol
        ///// </summary>
        ///// <param name="str"></param>
        ///// <returns></returns>
        //public string DelQuota(string str)
        //{
        //    string result = str;
        //    string[] strQuota = { "~", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "`", ";", "'", ",", ".", "/", ":", "/,", "<", ">", "?" };
        //    for (int i = 0; i < strQuota.Length; i++)
        //    {
        //        if (result.IndexOf(strQuota[i]) > -1)
        //            result = result.Replace(strQuota[i], "");
        //    }
        //    return result;
        //}

//        private void btnExportCSV_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                try
//                {
//                    gridView1.FocusedRowHandle -= 1;
//                    gridView1.FocusedRowHandle += 1;
//                }
//                catch { }

//                string sSQL = "select getdate()";
//                string sTime = BaseFunction.ReturnDate(DbHelperSQL.GetSingle(sSQL)).ToString("yyyyMMddHHmmss");

//                StringBuilder strIDs = new StringBuilder();
//                for (int i = 0; i < gridView1.RowCount; i++)
//                {
//                    if (!BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColchoose)))
//                    {
//                        continue;
//                    }

//                    if (strIDs.ToString().Trim() == "")
//                    {
//                        strIDs.Append(gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim());
//                    }
//                    else
//                    {
//                        strIDs.Append("," + gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim());
//                    }
//                }

//                if(strIDs.ToString().Trim() == "")
//                    throw new Exception("Please choose data");

//                sSQL = @"
//select * 
//from SaleBillVouch a inner join SaleBillVouchs b on a.SBVID = b.SBVID
//where 1=1
//    and cVouchType = '27'
//    and isnull(iUnitPrice,0) <> 0
//order by Autoid
//";
//                sSQL = sSQL.Replace("1=1", "1=1 and  b.Autoid IN (" + strIDs.ToString() + ")  ");
//                DataTable dtDetails = DbHelperSQL.Query(sSQL);
//                if (dtDetails == null || dtDetails.Rows.Count == 0)
//                {
//                    throw new Exception("no data");
//                }

//                string sSTCode = dtDetails.Rows[0]["cSTCode"].ToString().Trim();

//                SaveFileDialog sF = new SaveFileDialog();
//                sF.DefaultExt = "csv";
//                sF.FileName = sSTCode + sTime;
//                sF.Filter = "CSV文件(*.csv)|*.csv|所有文件(*.*)|*.*";
//                DialogResult dRes = sF.ShowDialog();
//                if (DialogResult.OK != dRes)
//                {
//                    return;
//                }

//                System.IO.FileStream fs = new FileStream(sF.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
//                StreamWriter sw = new StreamWriter(fs, new System.Text.UnicodeEncoding());
//                //Tabel header

//                //Table body
//                for (int i = 0; i < dtDetails.Rows.Count; i++)
//                {
//                    //1	I/V No	SO No.	EPJINVOICENO
//                    sw.Write(dtDetails.Rows[i]["cSBVCode"].ToString().Trim());
//                    sw.Write("\t");
//                    //2	On board date		EPJONBOARDDATE
//                    sw.Write(dtDetails.Rows[i]["dDate"].ToString().Trim());
//                    sw.Write("\t");
//                    //3	Part Code		PARTCODE
//                    sw.Write(dtDetails.Rows[i]["cInvCode"].ToString().Trim());
//                    sw.Write("\t");
//                    //4	Product Order => Job Number		JOBNO
//                    sw.Write(dtDetails.Rows[i]["cordercode"].ToString().Trim());
//                    sw.Write("\t");
//                    //5	Operation No		EPJOPERATIONCODE
//                    //sw.Write(dtDetails.Rows[i][""].ToString().Trim());
//                    sw.Write("\t");
//                    //6	Operation To (If Over Reject Go To LWE6)		SEPOPERATIONCODE
//                    //sw.Write(dtDetails.Rows[i][""].ToString().Trim());
//                    sw.Write("\t");
//                    //7	Qty		DELIVERYQTY
//                    sw.Write(BaseFunction.ReturnDecimal(dtDetails.Rows[i]["iQuantity"], 2).ToString().Trim());
//                    sw.Write("\t");
//                    //8	Reject Qty		REJECTQTY
//                    //sw.Write(BaseFunction.ReturnDecimal(dtDetails.Rows[i][""], 2).ToString().Trim());
//                    sw.Write("\t");
//                    //9	Price => EPJ Price(WIP before plating standartd cost)	Material cost	MATERIALPRICE
//                    //sw.Write(BaseFunction.ReturnDecimal(dtDetails.Rows[i][""], 2).ToString().Trim());
//                    sw.Write("\t");
//                    //10	Currency		CURRENCY
//                    //sw.Write(BaseFunction.ReturnDecimal(dtDetails.Rows[i][""], 2).ToString().Trim());
//                    sw.Write("\t");
//                    //11	Product Code 		PRODUCTCODE
//                    //sw.Write(BaseFunction.ReturnDecimal(dtDetails.Rows[i][""], 2).ToString().Trim());
//                    sw.Write("\t");
//                    //12	Parent Code		PARENTCODE
//                    //sw.Write(BaseFunction.ReturnDecimal(dtDetails.Rows[i][""], 2).ToString().Trim());
//                    sw.Write("\t");
//                    //13	Plating spec		PLATINGSPEC
//                    //sw.Write(BaseFunction.ReturnDecimal(dtDetails.Rows[i][""], 2).ToString().Trim());
//                    sw.Write("\t");
//                    //14	SEP Invoice No		SEPINVOICENO
//                    //sw.Write(BaseFunction.ReturnDecimal(dtDetails.Rows[i][""], 2).ToString().Trim());
//                    sw.Write("\t");
//                    //15	Status -> Business Type Identification	Sales type	STATUS
//                    //sw.Write(BaseFunction.ReturnDecimal(dtDetails.Rows[i][""], 2).ToString().Trim());
//                    sw.Write("\t");
//                    //16	SEP Price(Plating price)	unit price(无税单价)	SEPPLTPRICE
//                    //sw.Write(BaseFunction.ReturnDecimal(dtDetails.Rows[i][""], 2).ToString().Trim());
//                    sw.Write("\t");
//                    //17	SEP Amount	无税金额	SEPAMOUNT
//                    //sw.Write(BaseFunction.ReturnDecimal(dtDetails.Rows[i][""], 2).ToString().Trim());
//                    sw.Write("\t");
//                    //18	EPJ Amount	Material cost乘以数量	EPJAMOUNT
//                    //sw.Write(BaseFunction.ReturnDecimal(dtDetails.Rows[i][""], 2).ToString().Trim());
//                    sw.Write("\t");
//                    //19	SEP DO Number		SEPDONO
//                    //sw.Write(BaseFunction.ReturnDecimal(dtDetails.Rows[i][""], 2).ToString().Trim());
//                    sw.Write("\t");
//                }
//                sw.Flush();
//                sw.Close();
//            }
//            catch (Exception ee)
//            {
//                FrmMsgBox f = new FrmMsgBox();
//                f.Text = "导出Excel失败";
//                f.richTextBox1.Text = ee.Message;
//                f.ShowDialog();
//            }
//        }

        private string SetStringFormat(object o, int iLength)
        {
            string sTxt = "";
            if (o != null)
            {
                sTxt = o.ToString().Trim();
            }

            while (System.Text.Encoding.Default.GetBytes(sTxt).Length < iLength)
            {
                sTxt = sTxt + ' '.ToString();
            }


            return sTxt;
        }

        private string SetStringFormat(object o, int iLength, char sValue)
        {
            string sTxt = "";
            if (o != null)
            {
                sTxt = o.ToString().Trim();
            }

            while (System.Text.Encoding.Default.GetBytes(sTxt).Length < iLength)
            {
                sTxt = sValue.ToString() + sTxt;
            }


            return sTxt;
        }
    }
}
