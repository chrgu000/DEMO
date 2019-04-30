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
    public partial class FrmPUvoiceExportTxt : Form
    {
        public FrmPUvoiceExportTxt()
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
            lookUpEditcPBVCode1.Properties.DataSource = dt;
            lookUpEditcPBVCode2.Properties.DataSource = dt;
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
	,d.cVenName
from PurBillVouch a inner join PurBillVouchs b on a.PBVID = b.PBVID 
	left join Inventory c on b.cInvCode = c.cInvCode
	left join Vendor d on a.cVenCode = d.cVenCode
where 1=1 
    and isnull(b.iOriCost, 0) <> 0
    and isnull(a.cVerifier, '') <> ''
order by a.cPBVCode,b.ID
";

            if (lookUpEditcPBVCode1.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cPBVCode >= '" + lookUpEditcPBVCode1.Text.Trim().Trim() + "'");
            }
            if (lookUpEditcPBVCode2.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cPBVCode <= '" + lookUpEditcPBVCode2.Text.Trim().Trim() + "'");
            }
            if (dateEdit1.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.dPBVDate >= '" + dateEdit1.Text.Trim().Trim() + "'");
            }
            if (dateEdit2.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.dPBVDate <= '" + dateEdit2.Text.Trim().Trim() + "'");
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
                        strID.Append(gridView1.GetRowCellValue(i, gridColPBVID).ToString().Trim());
                    }
                    else
                    {
                        strID.Append("," + gridView1.GetRowCellValue(i, gridColPBVID).ToString().Trim());
                    }

                    if (strIDs.ToString().Trim() == "")
                    {
                        strIDs.Append(gridView1.GetRowCellValue(i, gridColID).ToString().Trim());
                    }
                    else
                    {
                        strIDs.Append("," + gridView1.GetRowCellValue(i, gridColID).ToString().Trim());
                    }
                }

                if (strID.ToString().Trim() == "")
                {
                    throw new Exception("Please choose data");
                }

                sSQL = @"
select a.*,b.cVenDefine3,b.cVenDefine4,c.iOriMoney,c.iMoney,c.iOriTaxPrice,e.*,a.cDefine16 as EditCount,c.iOriSumH
from PurBillVouch a INNER JOIN dbo.Vendor b ON a.cVenCode = b.cVenCode
    inner join (select PBVID ,SUM(iOriMoney) AS iOriMoney,sum(iMoney) as iMoney,sum(iOriTaxPrice) as iOriTaxPrice,SUM(iOriSum) AS iOriSumH FROM PurBillVouchs group by PBVID) c on a.PBVID = c.PBVID 
	LEFT JOIN [U8CUSTDEF_0002_E001] e ON a.cdefine12 = e.cNo
where 1=1 
order by PBVID 
";
                sSQL = sSQL.Replace("1=1", "1=1 and  a.PBVID IN (" + strID.ToString() + ") ");
                DataTable dtHead = DbHelperSQL.Query(sSQL);

                sSQL = @"
select distinct a.PBVID,e.*,v.*,c.iOriMoney as iOriMoneyH,c.iMoney AS iMoneyH,c.iOriTaxPrice AS iOriTaxPriceH,C.iOriSum AS iOriSumH,a.cDefine16 as EditCount
    ,b.iMoney
from PurBillVouchs b inner join PurBillVouch a on a.PBVID = b.PBVID
	LEFT JOIN [U8CUSTDEF_0002_E001] e ON a.cdefine12 = e.cNo
    LEFT JOIN Vendor V ON a.cVenCode = V.cVenCode
    inner join (select PBVID ,SUM(iOriCost) AS iOriMoney,sum(iMoney) as iMoney,sum(iOriTaxPrice) as iOriTaxPrice,SUM(iOriSum) AS iOriSum FROM PurBillVouchs group by PBVID) c on a.PBVID = c.PBVID 
where 1=1
order by a.PBVID
";
                sSQL = sSQL.Replace("1=1", "1=1 and  a.PBVID IN (" + strID.ToString() + ")  ");
                DataTable dtDetails = DbHelperSQL.Query(sSQL);

                if (dtHead == null || dtHead.Rows.Count == 0)
                {
                    throw new Exception("Please choose data");
                }

                StringBuilder strHead = new StringBuilder();
                for (int i = 0; i < dtHead.Rows.Count; i++)
                {
                    //1 Data type
                    strHead.Append("IN201");
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

                    //5 Vendor Code
                    strHead.Append(dtHead.Rows[i]["cVenDefine3"].ToString().Trim());
                    strHead.Append("|");

                    //6 Invoice Number
                    strHead.Append(dtHead.Rows[i]["cDefine2"].ToString().Trim());
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

                    //9 Transaction Number                使用自定义项16记录修改次数
                    int iEditCount = BaseFunction.ReturnInt(dtHead.Rows[i]["EditCount"]);
                    strHead.Append(dtHead.Rows[i]["cPBVCode"].ToString().Trim() + "-" + iEditCount.ToString().Trim());
                    strHead.Append("|");

                    //10 Document Type

                    if (dMoney > 0)
                    {
                        strHead.Append("KR");
                    }
                    else
                    {
                        strHead.Append("KG");
                    }
                    strHead.Append("|");

                    //11 Invoice Date(=Document Date)
                    DateTime dDate = BaseFunction.ReturnDate(dtHead.Rows[i]["cDefine4"]);
                    strHead.Append(dDate.ToString("yyyyMMdd"));
                    strHead.Append("|");

                    //12 Posting Date
                    DateTime ddverifydate = BaseFunction.ReturnDate(dtHead.Rows[i]["dPBVDate"]);
                    strHead.Append(ddverifydate.ToString("yyyyMMdd"));     //dverifydate 
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

                    //20 Exchange Rate for Tax
                    strHead.Append(dtHead.Rows[i]["cPBVMemo"].ToString().Trim());
                    strHead.Append("|");

                    decimal diOriSumH = Math.Abs(BaseFunction.ReturnDecimal(dtHead.Rows[i]["iOriSumH"], 2));
                    //21 Total Amount by Transaction Currency
                    strHead.Append(diOriSumH.ToString().Trim());
                    strHead.Append("|");

                    //22 Total Amount by Local Currency
                    strHead.Append("0");
                    strHead.Append("|");

                    //23 Header Text
                    //strHead.Append(dtHead.Rows[i]["cMemo"].ToString().Trim()); 
                    string sHead = dtHead.Rows[i]["Header_Text"].ToString().Trim() + " " + dtHead.Rows[i]["cDefine2"].ToString().Trim();
                    strHead.Append(sHead);
                    strHead.Append("|");

                    //24 Tax type
                    decimal iOriTaxPrice = BaseFunction.ReturnDecimal(dtHead.Rows[i]["iOriTaxPrice"], 2);
                    if (diOriSumH > 0)
                    {
                        strHead.Append("1");
                    }
                    else
                    {
                        strHead.Append("2");
                    }
                    strHead.Append("|");

                    //25 Assignment
                    strHead.Append("");
                    strHead.Append("|");

                    //26 Item text
                    string sItemText = dtHead.Rows[i]["Header_Text"].ToString().Trim() + " " + dtHead.Rows[i]["Reason_name"].ToString().Trim();
                    strHead.Append(sItemText);
                    strHead.Append("|");

                    //27 Clearing document number
                    strHead.Append("");
                    strHead.Append("|");

                    //28 Clearing document year
                    strHead.Append("");
                    strHead.Append("|");

                    //29 Status
                    strHead.Append("");
                    strHead.Append("|");

                    //30 User name
                    strHead.Append("");
                    strHead.Append("|");

                    //31 EntryProgram
                    strHead.Append("");
                    strHead.Append("|");

                    //32 Created on
                    strHead.Append("");
                    strHead.Append("|");

                    //33 Time of entry
                    strHead.Append("");
                    strHead.Append("|");

                    //34 Last Changed By
                    strHead.Append("");
                    strHead.Append("|");

                    //35 Update PGM
                    strHead.Append("");
                    strHead.Append("|");

                    //36 Date of Last Change
                    strHead.Append("");
                    strHead.Append("|");

                    //37 Time last change was made
                    strHead.Append("");
                    strHead.Append("|");

                    strHead.Append("\r\n");
                }


                StringBuilder strDetail = new StringBuilder();
                for (int i = 0; i < dtDetails.Rows.Count; i++)
                {
                    DataRow[] dr = dtHead.Select("PBVID = " + dtDetails.Rows[i]["pbvid"].ToString().Trim());
                    //1 Data type
                    strDetail.Append("IN201");
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
                    strDetail.Append(dr[0]["cVenDefine3"].ToString().Trim());
                    strDetail.Append("|");

                    //6 Invoice Number
                    strDetail.Append(dr[0]["cDefine2"].ToString().Trim());
                    strDetail.Append("|");

                    //7 Revised Indicator
                    decimal diOriMoney = BaseFunction.ReturnDecimal(dtDetails.Rows[i]["iOriMoneyH"]);
                    if (diOriMoney > 0)
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

                    int iEditCount2 = BaseFunction.ReturnInt(dr[0]["EditCount"]);
                    strDetail.Append(dr[0]["cPBVCode"].ToString().Trim() + "-" + iEditCount2.ToString().Trim());
                    strDetail.Append("|");

                    //10 Detail Line Number
                    strDetail.Append("1");
                    strDetail.Append("|");

                    //11 Debit/Credit
                    if (diOriMoney > 0)
                    {
                        strDetail.Append("S");
                    }
                    else
                    {
                        strDetail.Append("H");
                    }
                    strDetail.Append("|");

                    //12 SAP G/L Account code
                    strDetail.Append(dr[0]["GL_Account_Code"].ToString().Trim());
                    strDetail.Append("|");

                    //13 Cost Centre
                    strDetail.Append(dr[0]["CostCentre"].ToString().Trim());
                    strDetail.Append("|");

                    //14 Internal Order
                    strDetail.Append(dr[0]["Internal_Order"].ToString().Trim());
                    strDetail.Append("|");

                    //15 Profit Centre
                    strDetail.Append("");
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
                    //strDetail.Append(dtDetails.Rows[i]["iPBVQuantity"].ToString().Trim());
                    strDetail.Append("|");

                    //21 Item Text
                    strDetail.Append(dr[0]["Header_Text"].ToString().Trim() + " " + dr[0]["Cost_Centre_Desc"].ToString().Trim());
                    strDetail.Append("|");

                    //22 Assignment
                    strDetail.Append("");
                    strDetail.Append("|");

                    //23 Transaction Amount
                    decimal d = Math.Abs(BaseFunction.ReturnDecimal(dtDetails.Rows[i]["iOriSumH"], 2));
                    strDetail.Append(d.ToString());
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
                    strDetail.Append("");
                    strDetail.Append("|");

                    //36 Time last change was made
                    strDetail.Append("");
                    strDetail.Append("|");

                    strDetail.Append("\r\n");
                }

                string sPath = sFilePath + "APH" + sTime + "PLT.txt";
                if (File.Exists(sPath))
                {
                    throw new Exception("File is exists");
                }

                string sPath2 = sPath.Replace("APH", "APD");
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
