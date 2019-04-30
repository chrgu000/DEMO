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
    public partial class Frm生产入库数据每月明细 : Form
    {
        public Frm生产入库数据每月明细()
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

                string sPath = sFilePath + "bilis_Result_ProductionReceipt.csv";

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
                    sw.Write("\"" + dtDetails.Rows[i]["公司编号"].ToString() + "\"");

                    DateTime d入库日 = BaseFunction.ReturnDate(dtDetails.Rows[i]["入库日"]);
                    if (d入库日 > BaseFunction.ReturnDate("2000-01-01"))
                    {
                        sw.Write(",\"" + d入库日.ToString("yyyyMMdd") + "\"");
                    }
                    sw.Write(",\"" + dtDetails.Rows[i]["入库分类"].ToString() + "\"");
                    sw.Write(",\"" + dtDetails.Rows[i]["产品编号"].ToString() + "\"");
                    sw.Write(",\"" + dtDetails.Rows[i]["产品种类"].ToString() + "\"");
                    sw.Write(",\"" + dtDetails.Rows[i]["机带种类"].ToString() + "\"");
                    sw.Write(",\"" + dtDetails.Rows[i]["仓库编号"].ToString() + "\"");
                    sw.Write(",\"" + dtDetails.Rows[i]["数量"].ToString() + "\"");

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
select cast(1 as bit) as 选择
    ,'38' as 公司编号
    ,a.dDate as 入库日
    ,'R' as 入库分类
    ,b.cInvCode as 产品编号
    ,c.cInvDefine10 as 产品种类
    ,c.cInvDefine7 as 机带种类
    ,a.cWhCode as 仓库编号
    ,cast(b.iQuantity as decimal(16,0)) as 数量
from RdRecord10 a inner join RdRecords10 b on a.id = b.id
    inner join Inventory c on b.cInvCode = c.cInvCode
where 1=1
order by a.id,b.AutoID
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
            //DataColumn dc = new DataColumn();
            //dc.ColumnName = "选择";
            //dc.DataType = System.Type.GetType("System.Boolean");
            //dt.Columns.Add(dc);

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                string sColName = dt.Columns[i].ColumnName.Trim();
                sColName = sChinaToJap(sColName);
                dt.Columns[i].ColumnName = sColName;
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string s机带种类 = dt.Rows[i]["机带种类"].ToString().Trim();
                if (s机带种类.Length > 3)
                {
                    s机带种类 = s机带种类.Substring(1, 3);
                    dt.Rows[i]["机带种类"] = s机带种类;
                }
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
                case "入库日": sReturn = "Receipt_Date"; break;

                case "入库分类": sReturn = "Receipt_Type"; break;


                case "产品编号": sReturn = "Item_NO"; break;
                case "产品种类": sReturn = "Item_Class"; break;
                case "机带种类": sReturn = "Item_Kind"; break;
                case "仓库编号": sReturn = "Warehouse_No"; break;

                case "数量": sReturn = "Receipts"; break;
            }
            return sReturn;
        }
    }
}
