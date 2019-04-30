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

namespace U8Export
{
    public partial class Frm销售实绩数据 : Form
    {
        public Frm销售实绩数据()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 中文转日文
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        private string sChinaToJap(object o)
        {
            string s = o.ToString().ToLower().Trim();

            string sReturn = "";
            switch (s)
            {
                case "csocode": sReturn = "受注No."; break;
                case "cdefine10": sReturn = "顾客订单NO"; break;
                case "cdefine4": sReturn = "交期"; break;
                case "cwhcode": sReturn = "仓库编号"; break;
                case "ddate": sReturn = "受注处理日"; break;
                case "ccuscode": sReturn = "顾客No"; break;
                case "ccusname": sReturn = "顾客名称"; break;
                case "irowno": sReturn = "受注行No"; break;
                case "cinvcode": sReturn = "产品编号"; break;
                case "cinvname": sReturn = "产品编号备注"; break;
                case "iquantity": sReturn = "受注数量"; break;
                case "ifhquantity": sReturn = "已出货数量"; break;
                case "iqtyszc": sReturn = "受注残数量"; break;
                case "ciInvdefine13": sReturn = "成本(合計)"; break;
                case "ciInvdefine1": sReturn = "生产线"; break;

                default:
                    sReturn = s; break;
            }

            sReturn = sReturn.Replace(".", "");
            return sReturn;
        }

        string sFilePath = "";
        string sConn = "";
        public void ExportData(DateTime dtmStart,DateTime dtmEnd,string sPath,string conn)
        {
            try
            {
                sFilePath = sPath;
                sConn = conn;
                dateEdit1.DateTime = dtmStart;
                dateEdit2.DateTime = dtmEnd;

                btnSEL_Click(null, null);
                btnExport_Click(null, null);
            }
            catch (Exception ee)
            {
            
            }
        }

        private void btnSEL_Click(object sender, EventArgs e)
        {
            try
            {
                chkAll.Checked = false;

                string sSQL = @"
select * from _Export_V_xssj a where 1=1
";

                if (dateEdit1.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.dDate >= '" + dateEdit1.Text.Trim().Trim() + "'");
                }
                if (dateEdit2.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.dDate <= '" + dateEdit2.Text.Trim().Trim() + "'");
                }
                DataTable dt = DbHelperSQL.Query(sSQL);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string s货币 = dt.Rows[i]["交易货币"].ToString().Trim();
                    switch (s货币)
                    {
                        case "美元": s货币 = "USD"; break;
                        case "人民币": s货币 = "CNY"; break;
                        case "RMB": s货币 = "CNY"; break;
                        case "日元": s货币 = "JPY"; break;
                        case "欧元": s货币 = "EUR"; break;
                    }
                    dt.Rows[i]["交易货币"] = s货币;

                    string s机带种类 = dt.Rows[i]["机带种类"].ToString().Trim();
                    if (s机带种类.Length >= 5)
                    {
                        s机带种类 = s机带种类.Substring(1, 3);
                    }
                    else
                    {
                        s机带种类 = "";
                    }
                }

                for (int i = dt.Columns.Count - 1; i >= 0; i--)
                {
                    if (dt.Columns[i].ColumnName.ToLower() == "ddate")
                    {
                        dt.Columns.RemoveAt(i);
                    }
                }

                gridControl1.DataSource = dt;

                chkAll.Checked = true;
                gridView1.FocusedRowHandle = 0;

                gridView1.BestFitColumns();

                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    gridView1.Columns[i].OptionsColumn.ReadOnly = true;
                }
                gridView1.Columns["选择"].OptionsColumn.ReadOnly = false;

                gridView1.Columns["选择"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                gridView1.Columns["选择"].Width = 40;
                gridView1.BestFitColumns();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private string sColText(object o)
        {
            string sReturn = o.ToString().ToLower().Trim();
            switch (sReturn)
            {
                case "公司编号": sReturn = "Company_No"; break;
                case "订单no.": sReturn = "Invoice_NO"; break;
                case "订单行no.": sReturn = "Invoice_Line"; break;
                case "受注no.": sReturn = "Order_NO"; break;
                case "受注行no.": sReturn = "Order_Line"; break;
                case "顾客订单no.": sReturn = "Customer_PONO"; break;
                case "顾客no.": sReturn = "Customer_NO"; break;
                case "顾客名称": sReturn = "Customer_Name"; break;
                case "产品编号": sReturn = "Item_No"; break;
                case "产品种类": sReturn = "Item_Class"; break;
                case "机带种类": sReturn = "Item_Kind"; break;
                case "销售数量": sReturn = "QTY_Sold"; break;
                case "销售金额(交易货币)": sReturn = "Sold_TotalPrice"; break;
                case "交易货币": sReturn = "Currency_NO"; break;
                case "销售金额(管理货币)": sReturn = "Local_Amount"; break;
                case "销售金额(美金)": sReturn = "USD_Amount"; break;
                case "成本": sReturn = "Total_Cost"; break;
                case "请求书发行日": sReturn = "Invoice_Date"; break;
                case "单价": sReturn = "Sold_UnitPrice"; break;
                case "汇率(交易货币→管理货币)": sReturn = "Rate_Of_Exchange"; break;
                case "重点客户编号": sReturn = ""; break;
            }
            return sReturn;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                DataTable dtDetails = ((DataTable)gridControl1.DataSource).Copy();
                for (int i = dtDetails.Rows.Count - 1; i >= 0; i--)
                {
                    if (!BaseFunction.ReturnBool(dtDetails.Rows[i]["选择"]))
                    {
                        dtDetails.Rows.RemoveAt(i);
                    }
                }

                string sFileName = @"bilis_AR_Detail.csv";
                string sPath = sFilePath + sFileName;

                System.IO.FileStream fs = new FileStream(sPath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs, new System.Text.UnicodeEncoding());
                //Tabel header
                bool bFirst = true;
                for (int i = 0; i < dtDetails.Columns.Count; i++)
                {
                    if (dtDetails.Columns[i].ColumnName == "选择")
                        continue;

                    if (bFirst)
                    {
                        string sCol = "\"" + sColText(dtDetails.Columns[i].ColumnName.ToString().Trim()) + "\"";
                        sw.Write(sCol);
                        bFirst = false;
                    }
                    else
                    {
                        string sCol = ",\"" + sColText(dtDetails.Columns[i].ColumnName.ToString().Trim()) + "\"";
                        sw.Write(sCol);
                    }
                }
                sw.WriteLine("");
                //Table body
                for (int i = 0; i < dtDetails.Rows.Count; i++)
                {
                    if (dtDetails.Rows[i]["选择"].ToString() == "选择")
                        continue;

                    string s = "\"" + dtDetails.Rows[i]["公司编号"].ToString() + "\"";
                    sw.Write(s);

                    sw.Write(",\"" + ClsFormatString.SetStringFormat(dtDetails.Rows[i]["订单No."].ToString().Trim(), 8, '0') + "\"");

                    sw.Write(",\"" + ClsFormatString.SetStringFormat(dtDetails.Rows[i]["订单行No."].ToString(), 4, '0') + "\"");

                    sw.Write(",\"" + ClsFormatString.SetStringFormat(dtDetails.Rows[i]["受注No."].ToString(), 8, '0') + "\"");

                    sw.Write(",\"" + ClsFormatString.SetStringFormat(dtDetails.Rows[i]["受注行No."].ToString(), 4, '0') + "\"");

                    sw.Write(",\"" + dtDetails.Rows[i]["顾客订单NO."].ToString() + "\"");

                    sw.Write(",\"" + dtDetails.Rows[i]["顾客No."].ToString() + "\"");

                    sw.Write(",\"" + dtDetails.Rows[i]["顾客名称"].ToString() + "\"");

                    sw.Write(",\"" + dtDetails.Rows[i]["产品编号"].ToString() + "\"");

                    sw.Write(",\"" + dtDetails.Rows[i]["产品种类"].ToString() + "\"");

                    sw.Write(",\"" + dtDetails.Rows[i]["机带种类"].ToString() + "\"");

                    sw.Write(",\"" + dtDetails.Rows[i]["销售数量"].ToString() + "\"");

                    sw.Write(",\"" + dtDetails.Rows[i]["销售金额(交易货币)"].ToString() + "\"");

                    sw.Write(",\"" + dtDetails.Rows[i]["交易货币"].ToString() + "\"");

                    sw.Write(",\"" + dtDetails.Rows[i]["销售金额(管理货币)"].ToString() + "\"");

                    sw.Write(",\"" + dtDetails.Rows[i]["销售金额(美金)"].ToString() + "\"");

                    sw.Write(",\"" + dtDetails.Rows[i]["成本"].ToString() + "\"");

                    DateTime dDate = BaseFunction.ReturnDate(dtDetails.Rows[i]["请求书发行日"].ToString());
                    sw.Write(",\"" + dDate.ToString("yyyyMMdd") + "\"");

                    sw.Write(",\"" + dtDetails.Rows[i]["单价"].ToString() + "\"");

                    sw.Write(",\"" + dtDetails.Rows[i]["汇率(交易货币→管理货币)"].ToString() + "\"");

                    //sw.Write(",\"" + dtDetails.Rows[i]["重点客户编号"].ToString() + "\"");

                    sw.WriteLine("");
                }
                sw.Flush();
                sw.Close();
            }
            catch (Exception ee)
            {

            }
        }
    }
}
