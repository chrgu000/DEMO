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
    public partial class Frm条件数据 : Form
    {
        public Frm条件数据()
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

            string sPath = sFilePath + "bilis_M_Item.csv";

            System.IO.FileStream fs = new FileStream(sPath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, new System.Text.UnicodeEncoding());
            //Tabel header
            bool bFirst = true;
            for (int i = 0; i < dtDetails.Columns.Count; i++)
            {
                if (dtDetails.Columns[i].ToString() == "选择")
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
                sw.Write(",\"" + dtDetails.Rows[i]["产品分类"].ToString() + "\"");
                sw.Write(",\"" + dtDetails.Rows[i]["产品编号"].ToString() + "\"");
                sw.Write(",\"" + dtDetails.Rows[i]["产品备注1"].ToString() + "\"");
                sw.Write(",\"" + dtDetails.Rows[i]["产品备注2"].ToString() + "\"");
                sw.Write(",\"" + dtDetails.Rows[i]["式样编号"].ToString() + "\"");
                sw.Write(",\"" + dtDetails.Rows[i]["产品种类"].ToString() + "\"");
                sw.Write(",\"" + dtDetails.Rows[i]["挂率折扣编号"].ToString() + "\"");
                sw.Write(",\"" + dtDetails.Rows[i]["分析编号1"].ToString() + "\"");
                sw.Write(",\"" + dtDetails.Rows[i]["分析编号2"].ToString() + "\"");
                sw.Write(",\"" + dtDetails.Rows[i]["分析编号3"].ToString() + "\"");
                sw.Write(",\"" + dtDetails.Rows[i]["分析编号4"].ToString() + "\"");
                sw.Write(",\"" + dtDetails.Rows[i]["分析编号5"].ToString() + "\"");
                sw.Write(",\"" + dtDetails.Rows[i]["在库单位"].ToString() + "\"");
                sw.Write(",\"" + dtDetails.Rows[i]["采购单位"].ToString() + "\"");
                sw.Write(",\"" + dtDetails.Rows[i]["标准成本"].ToString() + "\"");
                sw.Write(",\"" + dtDetails.Rows[i]["实际成本"].ToString() + "\"");

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

            string sSQL = @"
select cast(1 as bit) as 选择
	,'41' as 公司编号
	,a.cInvDefine10 as 产品分类
	,a.cInvCode as 产品编号				
	,a.cInvName as 产品备注1									
	,a.cInvName as 产品备注2									
	,b.ciDefine6 as 式样编号									
	,a.cInvDefine2 as 产品种类									
	,'NONE' as 挂率折扣编号									
	,cInvDefine3 as 分析编号1									
	,cInvDefine4 as 分析编号2									
	,cInvDefine5 as 分析编号3									
	,cInvDefine6 as 分析编号4									
	,cInvDefine1 as 分析编号5									
	,d.cEnSingular as 在库单位									
	,d.cEnSingular as 采购单位									
	,0 as 标准成本									
	,0 as 实际成本									
from Inventory a
    left join [Inventory_extradefine] b on a.cInvCode = b.cInvCode
    left JOIN ComputationUnit d on d.cComunitCode = a.cComUnitCode   
where 1=1
order by a.cInvCode
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
                case "产品分类": sReturn = "Item_Class"; break;
                case "产品编号": sReturn = "Item_NO"; break;
                case "产品备注1": sReturn = "Item_Des"; break;
                case "产品备注2": sReturn = "Item_ExtraDES"; break;
                case "式样编号": sReturn = "Draw_No"; break;
                case "产品种类": sReturn = "Item_Type"; break;
                case "挂率折扣编号": sReturn = "Special_Rate_Discount_NO"; break;


                case "分析编号1": sReturn = "Sales_Analysis_Code1"; break;
                case "分析编号2": sReturn = "Sales_Analysis_Code2"; break;
                case "分析编号3": sReturn = "Sales_Analysis_Code3"; break;
                case "分析编号4": sReturn = "Sales_Analysis_Code4"; break;
                case "分析编号5": sReturn = "Sales_Analysis_Code5"; break;

                case "在库单位": sReturn = "UM_Stock"; break;
                case "采购单位": sReturn = "UM_Purchase"; break;
                case "标准成本": sReturn = "Total_Cost"; break;
                case "实际成本": sReturn = "Act_Cost"; break;

            } return sReturn;
        }
    }
}
