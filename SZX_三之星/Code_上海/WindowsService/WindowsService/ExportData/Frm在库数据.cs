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
    public partial class Frm在库数据 : Form
    {
        public Frm在库数据()
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
                dateEdit1.DateTime = dtmStart;
                dateEdit2.DateTime = dtmEnd;

                btnSEL_Click(null, null);
                btnExport_Click(null, null);
            }
            catch (Exception ee)
            {

            }
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

                string sPath = sFilePath + "bilis_Stock_Master.csv";

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
                    for (int j = 0; j < dtDetails.Columns.Count; j++)
                    {
                        if (dtDetails.Columns[j].ColumnName == "选择")
                            continue;

                        if (j != dtDetails.Columns.Count - 1)
                        {
                            if (dtDetails.Columns[j].ColumnName == "在库年月")
                            {
                                sw.Write("\"" + BaseFunction.ReturnDate(dtDetails.Rows[i][j]).ToString("yyyyMMdd") + "\"");
                            }
                            else
                            {
                                sw.Write("\"" + dtDetails.Rows[i][j].ToString() + "\"");
                            }
                        }
                        else
                        {
                            if (dtDetails.Columns[j].ColumnName == "在库年月")
                            {
                                sw.Write("\"" + BaseFunction.ReturnDate(dtDetails.Rows[i][j]).ToString("yyyyMMdd") + "\"");
                            }
                            else
                            {
                                sw.Write("\"" + dtDetails.Rows[i][j].ToString() + "\"");
                            }
                        }
                        if (j != dtDetails.Columns.Count - 1)
                        {
                            sw.Write(",");
                        }
                    }
                    sw.WriteLine("");
                }
                sw.Flush();
                sw.Close();
            }
            catch (Exception ee)
            {

            }
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
exec _sosp_zksj 'aaaaaa','bbbbbb'

";
            sSQL = sSQL.Replace("aaaaaa", dateEdit1.DateTime.ToString("yyyy-MM-dd"));
            sSQL = sSQL.Replace("bbbbbb", dateEdit2.DateTime.ToString("yyyy-MM-dd"));

            DataTable dt = DbHelperSQL.Query(sSQL);


            for (int i = 0; i < dt.Columns.Count; i++)
            {
                string sColName = dt.Columns[i].ColumnName.Trim();
                sColName = sChinaToJap(sColName);
                dt.Columns[i].ColumnName = sColName;
            }

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                string sColName = dt.Columns[i].ColumnName.Trim();
                sColName = sChinaToJap(sColName);
                dt.Columns[i].ColumnName = sColName;
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["在库年月"] = BaseFunction.ReturnDate(dt.Rows[i]["在库年月"]).ToString("yyyy-MM-dd");
            }

            gridControl1.DataSource = dt;
            gridView1.BestFitColumns();

            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                gridView1.Columns[i].OptionsColumn.ReadOnly = true;
            }
            gridView1.Columns["选择"].OptionsColumn.ReadOnly = false;
            chkAll.Checked = true;
            gridView1.FocusedRowHandle = 0;
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
                case "仓库编号": sReturn = "Warehouse_No"; break;
                case "产品编号": sReturn = "Item_NO"; break;
                case "产品种类": sReturn = "Item_Class"; break;
                case "机带种类": sReturn = "Item_Kind"; break;
                case "测定单位": sReturn = "UM_Stock"; break;
                case "实绩在库": sReturn = "On_Hand"; break;
                case "有效在库": sReturn = "Available"; break;
                case "前残": sReturn = "Opening_Balance"; break;
                case "月出库数量": sReturn = "Issues"; break;
                case "月入库数量": sReturn = "Receipts"; break;
                case "月调整数量": sReturn = "Adjustments"; break;
                case "引当后在库数量": sReturn = "Allocated"; break;
                case "在库年月": sReturn = "Stock_Date"; break;
                case "成本合计(单价)": sReturn = "Total_Cost"; break;
            }
            return sReturn;
        }
    }
}
