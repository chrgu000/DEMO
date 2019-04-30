using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace AutoExe
{
    public partial class FrmSalevoiceExportTxt : Form
    {
        public FrmSalevoiceExportTxt()
        {
            InitializeComponent();
        }

        string sFilePath = "";
        string sConn = "";
        public void ExportData(DateTime dtmStart, DateTime dtmEnd, string sPath, string conn)
        {
            try
            {
                sFilePath = sPath;
                sConn = conn;

                dateEdit1.DateTime = Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-01"));
                dateEdit2.DateTime = DateTime.Today;
                SetLookUp();

                btnSEL_Click(null, null);
                btnExportTxt_Click(null, null);
            }
            catch (Exception ee)
            {

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
select cast(1 as bit) as choose, *
	,c.cInvName,c.cInvStd
	,d.cCusName
from SaleBillVouch a inner join SaleBillVouchs b on a.SBVID = b.SBVID 
	left join Inventory c on b.cInvCode = c.cInvCode
	left join Customer d on a.cCusCode = d.cCusCode
where 1=1 and isnull(b.iUnitPrice ,0) <> 0 and isnull(cChecker,'') <> ''
    and cVouchType = '27'
order by a.cSBVCode,a.SBVID ,b.AutoID
";

            if (lookUpEditcSBVCode1.Text.Trim() != "")
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
select a.*  ,b.cCusDefine4,c.cSSName,e.iMoney,e.iSum,e.iNatSum,e.iTax,b.cCusDefine2,a.cDefine16 as EditCount
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
    ,h.iSum as iSumH,h.iNatSum as iNatSumH,h.iTax as iTaxH,c.cCusDefine2
    ,cc.ccdefine1
from SaleBillVouch a inner join SaleBillVouchs b on a.SBVID = b.SBVID 
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

                //SaveFileDialog sF = new SaveFileDialog();
                //sF.DefaultExt = "txt";
                //sF.FileName = "ARH" + sTime + "PLT";
                //sF.Filter = "Txt文件(*.txt)|*.txt|所有文件(*.*)|*.*";
                //DialogResult dRes = sF.ShowDialog();
                //if (DialogResult.OK != dRes)
                //{
                //    return;
                //}


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
                        strHead.Append("R");
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
                    decimal dSum = Math.Abs(BaseFunction.ReturnDecimal(dtHead.Rows[i]["iSum"], 2));
                    decimal dNatSum = Math.Abs(BaseFunction.ReturnDecimal(dtHead.Rows[i]["iNatSum"], 2));
                    //20 Total Amount by Transaction Currency
                    strHead.Append(dSum.ToString().Trim());
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
                    decimal dMoney = BaseFunction.ReturnDecimal(dtDetails.Rows[i]["iSumH"]);
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
                        strDetail.Append("A");
                    }
                    else
                    {
                        strDetail.Append("N");
                    }
                    strDetail.Append("|");
                    //12 SAP G/L Account code
                    strDetail.Append(dtDetails.Rows[i]["GLCode"].ToString().Trim());
                    strDetail.Append("|");
                    //13 Cost Centre
                    strDetail.Append("");
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

                string sPath = sFilePath+ @"ARH" + sTime + "PLT.txt";
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
           
            }
        }

    }
}
