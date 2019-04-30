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
    public partial class 生产入库数据每月明细 : UserControl
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

                dateEdit1.DateTime = BaseFunction.ReturnDate(DateTime.Today.ToString("yyyy-MM-01"));
                dateEdit2.DateTime = BaseFunction.ReturnDate(DateTime.Today.ToString("yyyy-MM-01")).AddMonths(1).AddDays(-1);
                
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

        public 生产入库数据每月明细()
        {
            InitializeComponent();
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


                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "csv";
                sF.FileName = "bilis_Result_ProductionReceipt.csv";
                sF.Filter = "CSV文件(*.csv)|*.csv|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK != dRes)
                {
                    return;
                }
                string sPath = sF.FileName;

                System.IO.FileStream fs = new FileStream(sF.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
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
                    sw.Write("\"" + dtDetails.Rows[i]["公司编号"].ToString() +  "\""); 

                    DateTime d入库日 = BaseFunction.ReturnDate(dtDetails.Rows[i]["入库日"]);
                    if (d入库日 > BaseFunction.ReturnDate("2000-01-01"))
                    {
                        sw.Write(",\"" + d入库日.ToString("yyyyMMdd") +  "\""); 
                    }
                    sw.Write(",\"" + dtDetails.Rows[i]["入库分类"].ToString() +  "\""); 
                    sw.Write(",\"" + dtDetails.Rows[i]["产品编号"].ToString() +  "\""); 
                    sw.Write(",\"" + dtDetails.Rows[i]["产品种类"].ToString() +  "\""); 
                    sw.Write(",\"" + dtDetails.Rows[i]["机带种类"].ToString() +  "\""); 
                    sw.Write(",\"" + dtDetails.Rows[i]["仓库编号"].ToString() +  "\""); 
                    sw.Write(",\"" + dtDetails.Rows[i]["数量"].ToString() + "\"");

                    sw.WriteLine("");
                }
                sw.Flush();
                sw.Close();
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "导出失败";
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
                    gridView1.SetRowCellValue(i, gridView1.Columns["选择"], chkAll.Checked);
                }
            }
            catch { }
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
