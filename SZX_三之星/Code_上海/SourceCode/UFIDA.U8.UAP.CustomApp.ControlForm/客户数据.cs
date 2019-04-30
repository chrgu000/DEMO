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
    public partial class 客户数据 : UserControl
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

        public 客户数据()
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
                sF.FileName = "bilis_M_Customer.csv";
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
                    sw.Write(",\"" + dtDetails.Rows[i]["客户编号"].ToString() + "\""); 
                    sw.Write(",\"" + dtDetails.Rows[i]["重点客户编号"].ToString() + "\""); 
                    sw.Write(",\"" + dtDetails.Rows[i]["客户分类"].ToString() + "\""); 
                    sw.Write(",\"" + dtDetails.Rows[i]["ＭＢＬ集团编号"].ToString() + "\""); 
                    sw.Write(",\"" + dtDetails.Rows[i]["客户名称"].ToString() + "\""); 

                    string sAddress = dtDetails.Rows[i]["地址1"].ToString();
                    if (sAddress.Length <= 100)
                    {
                        sw.Write(",\"" + sAddress + "\""); 
                        sw.Write(",\"" + "" + "\""); 
                        sw.Write(",\"" + "" + "\""); 
                    }
                    else if(sAddress.Length > 100 && sAddress.Length <= 150)
                    {
                        sw.Write(",\"" + sAddress.Substring(0, 100) + "\""); 
                        sw.Write(",\"" + sAddress.Substring(101) + "\""); 
                        sw.Write(",\"" + "" + "\""); 
                    }
                    else
                    {
                        sw.Write(",\"" + sAddress.Substring(0, 100) + "\""); 
                        sw.Write(",\"" + sAddress.Substring(101, 50) + "\""); 
                        sw.Write(",\"" + sAddress.Substring(151, 50) + "\""); 
                    }

                    sw.Write(",\"" + dtDetails.Rows[i]["国家编号"].ToString() + "\""); 
                    sw.Write(",\"" + dtDetails.Rows[i]["分析编号1"].ToString() + "\""); 
                    sw.Write(",\"" + dtDetails.Rows[i]["分析编号2"].ToString() + "\""); 
                    sw.Write(",\"" + dtDetails.Rows[i]["分析编号3"].ToString() + "\""); 
                    sw.Write(",\"" + dtDetails.Rows[i]["分析编号4"].ToString() + "\""); 
                    sw.Write(",\"" + dtDetails.Rows[i]["分析编号5"].ToString() + "\""); 

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
	,a.cCusCode as 客户编号
	,null as 重点客户编号									
	,a.cCusDefine7 as 客户分类									
	,a.cCusDefine8 as ＭＢＬ集团编号									
	,a.cCusName 客户名称									
	,a.cCusAddress  as 地址1									
	,null as 地址2									
	,null as 地址3									
	,cCusDefine1 as 国家编号									
	,cCusDefine2 as 分析编号1									
	,cCusDefine3 as 分析编号2									
	,cCusDefine4 as 分析编号3									
	,cCusDefine5 as 分析编号4									
	,cCusDefine6 as 分析编号5		
from Customer a
order by a.cCusCode
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
                case "客户编号": sReturn = "Customer_NO"; break;
                case "重点客户编号": sReturn = "Important_User_CD"; break;
                case "客户分类": sReturn = "Customer_Type"; break;
                case "ｍｂｌ集团编号": sReturn = "MBL_Group_Cd"; break;
                case "客户名称": sReturn = "Customer_Name"; break;
                case "地址1": sReturn = "Customer_Address1"; break;
                case "地址2": sReturn = "Customer_Address2"; break;
                case "地址3": sReturn = "Customer_Address3"; break;
                case "国家编号": sReturn = "Customer_Country_NO"; break;
                case "分析编号1": sReturn = "Sales_Analysis_Code1"; break;
                case "分析编号2": sReturn = "Sales_Analysis_Code2"; break;
                case "分析编号3": sReturn = "Sales_Analysis_Code3"; break;
                case "分析编号4": sReturn = "Sales_Analysis_Code4"; break;
                case "分析编号5": sReturn = "Sales_Analysis_Code5"; break;
            
            }
            return sReturn;
        }
    }
}
