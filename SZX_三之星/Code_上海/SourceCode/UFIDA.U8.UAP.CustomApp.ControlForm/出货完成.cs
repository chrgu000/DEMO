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
using System.Reflection;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class 出货完成 : UserControl
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
                dateEdit2.DateTime = DateTime.Today;
                SetLookUp();
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

        private void SetLookUp()
        {
        //    string sSQL = "select cSOCode from SO_SOMain  order by cSOCode";
        //    DataTable dt = DbHelperSQL.Query(sSQL);
        //    DataRow dr = dt.NewRow();
        //    dt.Rows.InsertAt(dr, 0);
        //    lookUpEditcSOCode1.Properties.DataSource = dt;
        //    lookUpEditcSOCode2.Properties.DataSource = dt;
        }

        public 出货完成()
        {
            InitializeComponent();
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
SELECT cast(1 as bit) as 选择
    ,CONVERT(varchar(100),a.dDate, 20) as 发票生效日	
	,Right('00000000' + a.cDLCode, 8) AS 发票号									
	,RIGHT('0000' + cast(ROW_NUMBER() over(partition BY a.cDLCode order by a.cDLCode) as varchar(4)) , 4) as 发票行号					
	,CASE WHEN ISNULL(b.cCusInvCode ,'') = '' THEN b.cinvCode ELSE b.cCusInvCode  END AS 产品编号									
	,a.cCusCode as 顾客编号									
	,case when isnull(b.cDefine22,'') = '' then a.cDefine10 else b.cDefine22 end as 顾客PO号									
	,a.cCusCode as 发票寄送地址									
	,null as 发票寄送地址后缀									
	,a.cCusCode as 出货地址编号									
	,null as 出货编号									
	,SUM(cast(b.iQuantity as decimal(16,0))) as 出荷数量									
	,MAX(cast(b.iTaxUnitPrice as decimal(16,2))) as 出荷単価									
	,SUM(cast(b.iSum as decimal(16,2))) as 出荷金額									
	,c.cexch_code 货币编号									
	,null as 备注									
	,null as 到货预定日				
from dbo.DispatchList a INNER JOIN dbo.DispatchLists b ON a.DLID = b.DLID
	left join foreigncurrency c on a.cexch_name = c.cexch_name 
WHERE 1=1
GROUP BY a.dDate,a.cDLCode,b.cinvCode,b.cCusInvCode
	,a.cCusCode 								
	,a.cDefine10 									
	,a.cCusCode 						
	,a.cCusCode 		
	,c.cexch_code	
	,b.cDefine22
";

            if (dateEdit1.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.dDate >= '" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "'");
            }
            if (dateEdit2.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.dDate < '" + dateEdit2.DateTime.AddDays(1).ToString("yyyy-MM-dd") + "'");
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
                //case "": sReturn = "処理フラグ"; break;
                case "csocode": sReturn = "销售订单号"; break;
                case "irowno": sReturn = "行号"; break;
                case "ccuscode": sReturn = "顾客No"; break;
                case "cinvcode": sReturn = "产品编号"; break;
                //case "": sReturn = "製品備考"; break;
                //case "": sReturn = "顧客製品コード"; break;
                case "cdefine10": sReturn = "顾客订单NO"; break;
                //case "irowno": sReturn = "订单NO行No"; break;
                case "dpredate": sReturn = "交期"; break;
                case "iquantity": sReturn = "订货数量"; break;
                case "cinvdefine14": sReturn = "订货单价"; break;
                //case "": sReturn = "単価日付"; break;
                case "caddcode": sReturn = "出货地编号"; break;
                //case "": sReturn = "出荷No"; break;
                //case "": sReturn = "发票寄送地"; break;
                //case "": sReturn = "发票号"; break;
                //case "": sReturn = "PONO重複確認"; break;
                //case "": sReturn = "単価採用フラグ"; break;
                //case "": sReturn = "注文確認書印刷フラグ"; break;
                //case "": sReturn = "作成日"; break;
                //case "": sReturn = "作成時間"; break;
                //case "": sReturn = "受取日"; break;
                //case "": sReturn = "受取時間"; break;
                //case "": sReturn = "备忘录1"; break;
                //case "": sReturn = "备忘录2"; break;
                //case "": sReturn = "备忘录3"; break;
                //case "": sReturn = "备忘录4"; break;
                //case "": sReturn = "备忘录5"; break;
                //case "": sReturn = "备忘录6"; break;
                //case "": sReturn = "备忘录7"; break;
                //case "": sReturn = "备忘录8"; break;
                //case "": sReturn = "备忘录9"; break;
                //case "": sReturn = "备忘录10"; break;
                //case "": sReturn = "ｘｘｘ"; break;
                //case "": sReturn = "注文書発行先ID"; break;
                     
                default:
                    sReturn = s; 
                    break;
            }

            sReturn = sReturn.Replace(".", "");
            return sReturn;
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "XLS";
                sF.FileName = "SHP_Export_ShippingData.xls";
                sF.Filter = "XLS文件(*.XLS)|*.XLS|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK != dRes)
                {
                    return;
                }
                string sPath = sF.FileName;

                DataTable dtExcel = (DataTable)gridControl1.DataSource;
                for (int i = dtExcel.Rows.Count-1; i >=0; i--)
                {
                    if (!BaseFunction.ReturnBool(dtExcel.Rows[i]["选择"]))
                    {
                        dtExcel.Rows.RemoveAt(i);
                    }
                }

                for (int i = 0; i < dtExcel.Columns.Count; i++)
                {
                    if (dtExcel.Columns[i].ColumnName.Trim() == "选择")
                    {
                        dtExcel.Columns.RemoveAt(i);
                        break;
                    }
                }

                for (int i = 0; i < dtExcel.Rows.Count; i++)
                {
                    dtExcel.Rows[i]["发票生效日"] = BaseFunction.ReturnDate(dtExcel.Rows[i]["发票生效日"]).ToString("yyyyMMdd");
                    string s发票行号 = ClsFormatString.SetStringFormat(dtExcel.Rows[i]["发票行号"], 4, '0');
                    dtExcel.Rows[i]["发票行号"] = s发票行号;
                }

                gridControl2.DataSource = dtExcel;
                gridView2.ExportToExcelOld(sPath);

            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "导出失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }
    }
}
