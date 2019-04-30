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
    public partial class Frm处理日期数据 : Form
    {
        public Frm处理日期数据()
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


            string sPath = sFilePath + "bilis_M_Sysin.csv";

            System.IO.FileStream fs = new FileStream(sPath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, new System.Text.UnicodeEncoding());
            //Tabel header
            bool bFirst = true;
            //for (int i = 0; i < dtDetails.Columns.Count; i++)
            //{
            //    if (dtDetails.Columns[i].ToString() == "选择")
            //        continue;

            //    if (bFirst)
            //    {
            //        string sCol = "\"" + sColText(dtDetails.Columns[i].ColumnName.ToString().Trim()) + "\"";
            //        sw.Write(sCol);
            //        bFirst = false;
            //    }
            //    else
            //    {
            //        string sCol = ",\"" + sColText(dtDetails.Columns[i].ColumnName.ToString().Trim()) + "\"";
            //        sw.Write(sCol);
            //    }
            //}
            //sw.Write(",\"" + "处理时间" + "\"");
            //sw.WriteLine("");
            //Table body
            for (int i = 0; i < dtDetails.Rows.Count; i++)
            {
                sw.Write("\"" + dtDetails.Rows[i]["公司编号"].ToString() + "\"");
                sw.Write(",\"" + dtDetails.Rows[i]["处理编号"].ToString() + "\"");

                DateTime d处理日 = BaseFunction.ReturnDate(dtDetails.Rows[i]["处理日"]);

                if (i == 0)
                {
                    sw.Write(",\"" + d处理日.ToString("yyyyMMdd") + "\"");
                    sw.Write(",\"" + d处理日.ToString("HHmmss") + "\"");
                }
                if (i == 1)
                {
                    string sMonthLastDay = BaseFunction.ReturnDate(d处理日.ToString("yyyy-MM-01")).AddMonths(1).AddDays(-1).ToString("yyyyMMdd");

                    sw.Write(",\"" + sMonthLastDay + "\"");
                    sw.Write(",\"000000\"");
                }

                sw.WriteLine("");
            }
            sw.Flush();
            sw.Close();

        }

        private void btnSEL_Click(object sender, EventArgs e)
        {
            try
            {
                GetGrid();
            }
            catch (Exception ee)
            {

            }
        }


        private void GetGrid()
        {
              chkAll.Checked = false;

            string sDate = DateTime.Now.ToString("yyyyMMdd");

            string sSQL = @"
select cast(1 as bit) as 选择
    ,'38' as 公司编号
    ,'DAILY' AS 处理编号
    ,getdate() as 处理日
union
select cast(1 as bit)
    ,'38' as 公司编号
    ,'SYSTEM' AS 处理编号
    ,getdate() as 处理日
";

            
            DataTable dt = DbHelperSQL.Query(sSQL);

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                string sColName = dt.Columns[i].ColumnName.Trim();
                sColName = sChinaToJap(sColName);
                dt.Columns[i].ColumnName = sColName;
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

            gridView1.Columns["选择"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            gridView1.Columns["选择"].Width = 40;

            gridView1.BestFitColumns();
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
                //case "公司编号": sReturn = "Company_NO"; break;


            }
            return sReturn;
        }
    }
}
