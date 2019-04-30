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
    public partial class Frm受注数据 : Form
    {
        string sConn = "";
        public Frm受注数据()
        {
            InitializeComponent();
        }

        private void SetLookUp()
        {
            DbHelperSQL.connectionString = sConn;
            string sSQL = "select cSOCode from SO_SOMain  order by cSOCode";
            DataTable dt = DbHelperSQL.Query(sSQL);
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditcSOCode1.Properties.DataSource = dt;
            lookUpEditcSOCode2.Properties.DataSource = dt;
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

                string sFileName = "bilis_Sales_Order.csv";

                string sPath = sFilePath + sFileName;

                System.IO.FileStream fs = new FileStream(sPath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs, new System.Text.UnicodeEncoding());
                //Tabel header

                bool bFirst = true;
                for (int i = 0; i < dtDetails.Columns.Count; i++)
                {
                    if (dtDetails.Columns[i].ColumnName.Trim() == "选择")
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

                    sw.Write("\"" + dtDetails.Rows[i]["公司编号"].ToString() + "\"");

                    sw.Write(",\"" + dtDetails.Rows[i]["顾客No."].ToString() + "\"");

                    sw.Write(",\"" + dtDetails.Rows[i]["顾客名称"].ToString() + "\"");

                    sw.Write(",\"" + dtDetails.Rows[i]["顧客订单NO."].ToString() + "\"");

                    sw.Write(",\"" + dtDetails.Rows[i]["受注No."].ToString() + "\"");

                    sw.Write(",\"" + dtDetails.Rows[i]["受注行No."].ToString() + "\"");

                    sw.Write(",\"" + dtDetails.Rows[i]["产品编号"].ToString() + "\"");

                    sw.Write(",\"" + dtDetails.Rows[i]["产品种类"].ToString() + "\"");

                    sw.Write(",\"" + dtDetails.Rows[i]["机带种类"].ToString() + "\"");

                    sw.Write(",\"" + dtDetails.Rows[i]["仓库编号"].ToString() + "\"");

                    sw.Write(",\"" + "        " + "\"");

                    //string svalue = dtDetails.Rows[i]["生产指图日"].ToString();
                    //DateTime dValue = BaseFunction.ReturnDate(svalue);
                    //if (dValue > BaseFunction.ReturnDate("2000-01-01"))
                    //{
                    //    svalue = dValue.ToString("yyyyMMdd");
                    //}
                    string svalue = dtDetails.Rows[i]["顾客要求日"].ToString();
                    DateTime dValue = BaseFunction.ReturnDate(svalue);
                    if (dValue > BaseFunction.ReturnDate("2000-01-01"))
                    {
                        svalue = dValue.ToString("yyyyMMdd");
                    }
                    sw.Write(",\"" + svalue + "\"");

                    sw.Write(",\"" + dtDetails.Rows[i]["受注数量"].ToString() + "\"");


                    sw.Write(",\"" + dtDetails.Rows[i]["已引当数量"].ToString() + "\"");


                    sw.Write(",\"" + dtDetails.Rows[i]["已出货数量"].ToString() + "\"");


                    sw.Write(",\"" + dtDetails.Rows[i]["受注残数量"].ToString() + "\"");


                    sw.Write(",\"" + dtDetails.Rows[i]["交易货币种类"].ToString() + "\"");


                    sw.Write(",\"" + BaseFunction.ReturnDecimal(dtDetails.Rows[i]["单价"], 7).ToString() + "\"");


                    sw.Write(",\"" + BaseFunction.ReturnDecimal(dtDetails.Rows[i]["受注金额"], 7).ToString() + "\"");


                    sw.Write(",\"" + BaseFunction.ReturnDecimal(dtDetails.Rows[i]["未分配数量"], 3).ToString() + "\"");


                    sw.Write(",\"" + BaseFunction.ReturnDecimal(dtDetails.Rows[i]["必要生产量"], 3).ToString() + "\"");


                    sw.WriteLine("");
                }
                sw.Flush();
                sw.Close();
            }
            catch (Exception ee)
            {

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
select * from _Export_V_szsj where 1=1 order by id,AutoID	
";

            //if (lookUpEditcSOCode1.Text.Trim() != "")
            //{
            //    sSQL = sSQL.Replace("1=1", "1=1 and cSOCode >= '" + lookUpEditcSOCode1.Text.Trim().Trim() + "'");
            //}
            //if (lookUpEditcSOCode2.Text.Trim() != "")
            //{
            //    sSQL = sSQL.Replace("1=1", "1=1 and cSOCode <= '" + lookUpEditcSOCode2.Text.Trim().Trim() + "'");
            //}
            //if (dateEdit1.Text.Trim() != "")
            //{
            //    sSQL = sSQL.Replace("1=1", "1=1 and dDate >= '" + dateEdit1.Text.Trim().Trim() + "'");
            //}
            //if (dateEdit2.Text.Trim() != "")
            //{
            //    sSQL = sSQL.Replace("1=1", "1=1 and dDate <= '" + dateEdit2.Text.Trim().Trim() + "'");
            //}
            DataTable dt = DbHelperSQL.Query(sSQL);

            for (int i = dt.Columns.Count - 1; i >= 0; i--)
            {
                if (dt.Columns[i].ColumnName.ToLower() == "csocode"
                        || dt.Columns[i].ColumnName.ToLower() == "ddate"
                        || dt.Columns[i].ColumnName.ToLower() == "id"
                        || dt.Columns[i].ColumnName.ToLower() == "autoid")
                {
                    dt.Columns.RemoveAt(i);
                }
            }


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string s货币 = dt.Rows[i]["交易货币种类"].ToString().Trim();
                switch (s货币)
                {
                    case "美元": s货币 = "USD"; break;
                    case "人民币": s货币 = "CNY"; break;
                    case "日元": s货币 = "JPY"; break;
                    case "欧元": s货币 = "EUR"; break;
                }
                dt.Rows[i]["交易货币种类"] = s货币;

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
                //case "选择": sReturn = "选择"; break;
                case "csocode": sReturn = "受注No."; break;

                default:
                    sReturn = s; break;
            }

            sReturn = sReturn.Replace(".", "");
            return sReturn;
        }


        private string sColText(object o)
        {
            string sReturn = o.ToString().ToLower().Trim();
            switch (sReturn)
            {
                case "公司编号": sReturn = "Company_NO"; break;
                case "顾客no.": sReturn = "Customer_NO"; break;
                case "顾客名称": sReturn = "Customer_Name"; break;
                case "顧客订单no.": sReturn = "Customer_PONO"; break;
                case "受注no.": sReturn = "Order_NO"; break;
                case "受注行no.": sReturn = "Order_Line"; break;
                case "产品编号": sReturn = "Item_NO"; break;
                case "产品种类": sReturn = "Item_Class"; break;
                case "机带种类": sReturn = "Item_Kind"; break;
                case "仓库编号": sReturn = "Warehouse_No"; break;
                case "生产指图日": sReturn = "Schedule_DueDate"; break;
                case "顾客要求日": sReturn = "Delivery_Date"; break;
                case "受注数量": sReturn = "QTY_Order"; break;
                case "已引当数量": sReturn = "QTY_Allocated"; break;
                case "已出货数量": sReturn = "QTY_Shipped"; break;
                case "受注残数量": sReturn = "QTY_BO"; break;
                case "交易货币种类": sReturn = "Currency_NO"; break;
                case "单价": sReturn = "Order_UnitPrice"; break;
                case "受注金额": sReturn = "Order_TotalPrice"; break;
                case "未分配数量": sReturn = "Qty_SoftAllocated"; break;
                case "必要生产量": sReturn = "Qty_Require"; break;
            }
            return sReturn;
        }

        string sFilePath = "";
        public void ExportData(DateTime dtmStart, DateTime dtmEnd, string sPath, string conn)
        {
            try
            {
                sFilePath = sPath;
                sConn = conn;
                dateEdit1.DateTime = dtmStart;
                dateEdit2.DateTime = dtmEnd;
                SetLookUp();

                btnSEL_Click(null, null);
                btnExport_Click(null, null);
            }
            catch (Exception ee)
            {

            }
        }
    }
}
