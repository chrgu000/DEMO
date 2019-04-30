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
    public partial class 订货数据 : UserControl
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

                dateEdit1.DateTime = DateTime.Today.AddDays(-7);
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
            string sSQL = "select cPOID from PO_Pomain  order by cPOID";
            DataTable dt = DbHelperSQL.Query(sSQL);
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditcSOCode1.Properties.DataSource = dt;
            lookUpEditcSOCode2.Properties.DataSource = dt;
        }

        public 订货数据()
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

                StringBuilder strDetail = new StringBuilder();

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (!BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridView1.Columns["选择"])))
                    {
                        continue;
                    }

                    strDetail.Append(ClsFormatString.SetStringFormat("", 1));
                    //strDetail.Append(ClsFormatString.SetStringFormat("", 8, '0'));        //第二列 使用8个0
                    strDetail.Append(ClsFormatString.SetStringFormat(gridView1.GetRowCellValue(i, gridView1.Columns["顾客No."]), 8, '0'));
                    strDetail.Append(ClsFormatString.SetStringFormat(gridView1.GetRowCellValue(i, gridView1.Columns["产品编号"]), 35));
                    strDetail.Append(ClsFormatString.SetStringFormat("", 50));
                    strDetail.Append(ClsFormatString.SetStringFormat("", 35));
                    strDetail.Append(ClsFormatString.SetStringFormat(gridView1.GetRowCellValue(i, gridView1.Columns["顾客订单 NO."]), 20));
                    strDetail.Append(ClsFormatString.SetStringFormat(gridView1.GetRowCellValue(i, gridView1.Columns["订单NO. 行No."]), 4, '0'));

                    string s交期 = "";
                    if (BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridView1.Columns["交期"])) > BaseFunction.ReturnDate("2000-01-01"))
                    {
                        s交期 = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridView1.Columns["交期"])).ToString("yyyyMMdd");
                    }
                    strDetail.Append(ClsFormatString.SetStringFormat(s交期, 8));

                    decimal d订货数量 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridView1.Columns["订货数量"])) * 1000;
                    string s订货数量 =Convert.ToDouble( d订货数量).ToString();
                    strDetail.Append(ClsFormatString.SetStringFormat(s订货数量, 11, '0'));

                    decimal d订货单价 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridView1.Columns["订货单价"]), 4) * 10000;
                    string s订货单价 = Convert.ToDouble(d订货单价).ToString();
                    strDetail.Append(ClsFormatString.SetStringFormat(s订货单价, 14, '0'));

                    strDetail.Append(ClsFormatString.SetStringFormat("", 8));


                    strDetail.Append(ClsFormatString.SetStringFormat("", 8));
                    strDetail.Append(ClsFormatString.SetStringFormat("", 4));
                    strDetail.Append(ClsFormatString.SetStringFormat("", 8));
                    strDetail.Append(ClsFormatString.SetStringFormat("", 4));

                    strDetail.Append(ClsFormatString.SetStringFormat("", 1));
                    strDetail.Append(ClsFormatString.SetStringFormat("", 1));
                    strDetail.Append(ClsFormatString.SetStringFormat("", 1));

                    DateTime d作成時間 = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridView1.Columns["作成時間"]));
                    strDetail.Append(ClsFormatString.SetStringFormat(d作成時間.ToString("yyyyMMdd"), 8));
                    strDetail.Append(ClsFormatString.SetStringFormat(d作成時間.ToString("HHmmss"), 6));
                    DateTime d受取時間 = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridView1.Columns["受取時間"]));
                    strDetail.Append(ClsFormatString.SetStringFormat(d受取時間.ToString("yyyyMMdd"), 8));
                    strDetail.Append(ClsFormatString.SetStringFormat(d受取時間.ToString("HHmmss"), 6));
                    strDetail.Append(ClsFormatString.SetStringFormat(gridView1.GetRowCellValue(i, gridView1.Columns["备忘录1"]), 50));
                    strDetail.Append(ClsFormatString.SetStringFormat(gridView1.GetRowCellValue(i, gridView1.Columns["备忘录2"]), 50));
                    strDetail.Append(ClsFormatString.SetStringFormat(gridView1.GetRowCellValue(i, gridView1.Columns["备忘录3"]), 50));
                    strDetail.Append(ClsFormatString.SetStringFormat(gridView1.GetRowCellValue(i, gridView1.Columns["备忘录4"]), 50));
                    strDetail.Append(ClsFormatString.SetStringFormat(gridView1.GetRowCellValue(i, gridView1.Columns["备忘录5"]), 50));
                    strDetail.Append(ClsFormatString.SetStringFormat(gridView1.GetRowCellValue(i, gridView1.Columns["备忘录6"]), 50));
                    strDetail.Append(ClsFormatString.SetStringFormat(gridView1.GetRowCellValue(i, gridView1.Columns["备忘录7"]), 50));
                    strDetail.Append(ClsFormatString.SetStringFormat(gridView1.GetRowCellValue(i, gridView1.Columns["备忘录8"]), 50));
                    strDetail.Append(ClsFormatString.SetStringFormat(gridView1.GetRowCellValue(i, gridView1.Columns["备忘录9"]), 50));
                    strDetail.Append(ClsFormatString.SetStringFormat(gridView1.GetRowCellValue(i, gridView1.Columns["备忘录10"]), 50));
                    strDetail.Append(ClsFormatString.SetStringFormat(gridView1.GetRowCellValue(i, gridView1.Columns["ｘｘｘ"]), 8, '0'));
                    strDetail.Append(ClsFormatString.SetStringFormat("SMB", 3));
                  
                    strDetail.Append("\r\n");
                }

                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "txt";
                sF.FileName = "Ufida_OTS_Data_038.txt";
                sF.Filter = "Txt文件(*.txt)|*.txt|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK != dRes)
                {
                    return;
                }
                string sPath = sF.FileName;
                string s = strDetail.ToString();
                File.WriteAllText(sPath, s);
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
SELECT  cast(1 as bit) as 选择
	,a.cVenCode AS [顾客No.],b.cInvCode as [产品编号], NULL AS [Order to],NULL AS [BPCS产品编号]
	,a.cDefine10 AS [顾客订单 NO.]
	,b.ivouchrowno AS [订单NO. 行No.],CASE WHEN ISNULL(b.cDefine36,'')='' THEN b.dArriveDate  ELSE b.cDefine36 end AS 交期,b.iQuantity AS 订货数量,b.iUnitPrice AS 订货单价
	,a.cMemo AS 备注
    ,a.cmaketime as 作成時間,a.cmaketime as 受取時間
FROM dbo.PO_POMain a INNER JOIN dbo.PO_PODetails b ON a.POID = b.POID
where 1=1
order by b.ID
";

            if(lookUpEditcSOCode1.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cPOID  >= '" + lookUpEditcSOCode1.Text.Trim().Trim() + "'");
            }
            if (lookUpEditcSOCode2.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cPOID  <= '" + lookUpEditcSOCode2.Text.Trim().Trim() + "'");
            }
            if (dateEdit1.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.dPODate  >= '" + dateEdit1.Text.Trim().Trim() + "'");
            }
            if (dateEdit2.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.dPODate  <= '" + dateEdit2.Text.Trim().Trim() + "'");
            }
            DataTable dt = DbHelperSQL.Query(sSQL);
            //DataColumn dc = new DataColumn();
            //dc.ColumnName = "选择";
            //dc.DataType = System.Type.GetType("System.Boolean");
            //dt.Columns.Add(dc);

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

                DataTable dtExcel = new DataTable();
                DataColumn dc = new DataColumn();
                dc.ColumnName = "顾客No.";
                dtExcel.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "产品编号";
                dtExcel.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "Order to";
                dtExcel.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "BPCS产品编号";
                dtExcel.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "顾客订单 NO.";
                dtExcel.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "订单NO.行No.";
                dtExcel.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "要求日";
                dtExcel.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "交期";
                dtExcel.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "订货数量";
                dtExcel.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "订货单价";
                dtExcel.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "备忘录1";
                dtExcel.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "备忘录2";
                dtExcel.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "备忘录3";
                dtExcel.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "备忘录4";
                dtExcel.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "备忘录5";
                dtExcel.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "备忘录6";
                dtExcel.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "备忘录7";
                dtExcel.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "备忘录8";
                dtExcel.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "备忘录9";
                dtExcel.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "备忘录10";
                dtExcel.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "出货地编号";
                dtExcel.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "出荷No.";
                dtExcel.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "发票寄送地";
                dtExcel.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "发票号";
                dtExcel.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "备注";
                dtExcel.Columns.Add(dc);
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (!BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridView1.Columns["选择"])))
                        continue;

                    DataRow dr = dtExcel.NewRow();
                    //dr["顾客No."] = gridView1.GetRowCellValue(i, gridView1.Columns["顾客No."]).ToString().Trim();
                    dr["产品编号"] = gridView1.GetRowCellValue(i, gridView1.Columns["产品编号"]).ToString().Trim();
                    //dr["Order to"] = gridView1.GetRowCellValue(i, gridView1.Columns["Orderto"]).ToString().Trim();
                    //dr["BPCS产品编号"] = gridView1.GetRowCellValue(i, gridView1.Columns["BPCS产品编号"]).ToString().Trim();
                    dr["顾客订单 NO."] = gridView1.GetRowCellValue(i, gridView1.Columns["顾客订单 NO."]).ToString().Trim();
                    dr["订单NO.行No."] = gridView1.GetRowCellValue(i, gridView1.Columns["订单NO. 行No."]).ToString().Trim();
                    //dr["要求日"] = gridView1.GetRowCellValue(i, gridView1.Columns["要求日"]).ToString().Trim();

                    DateTime d交期 = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridView1.Columns["交期"]));
                    if(d交期 > BaseFunction.ReturnDate("2000-01-01"))
                    {
                        dr["交期"] = d交期.ToString("yyyyMMdd");
                    }
                    dr["订货数量"] = Convert.ToDouble(BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridView1.Columns["订货数量"]), 3));
                    dr["订货单价"] = Convert.ToDouble(BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridView1.Columns["订货单价"]), 4));
                    //dr["备忘录1"] = gridView1.GetRowCellValue(i, gridView1.Columns["备忘录1"]).ToString().Trim();
                    //dr["备忘录2"] = gridView1.GetRowCellValue(i, gridView1.Columns["备忘录2"]).ToString().Trim();
                    //dr["备忘录3"] = gridView1.GetRowCellValue(i, gridView1.Columns["备忘录3"]).ToString().Trim();
                    //dr["备忘录4"] = gridView1.GetRowCellValue(i, gridView1.Columns["备忘录4"]).ToString().Trim();
                    //dr["备忘录5"] = gridView1.GetRowCellValue(i, gridView1.Columns["备忘录5"]).ToString().Trim();
                    //dr["备忘录6"] = gridView1.GetRowCellValue(i, gridView1.Columns["备忘录6"]).ToString().Trim();
                    //dr["备忘录7"] = gridView1.GetRowCellValue(i, gridView1.Columns["备忘录7"]).ToString().Trim();
                    //dr["备忘录8"] = gridView1.GetRowCellValue(i, gridView1.Columns["备忘录8"]).ToString().Trim();
                    //dr["备忘录9"] = gridView1.GetRowCellValue(i, gridView1.Columns["备忘录9"]).ToString().Trim();
                    //dr["备忘录10"] = gridView1.GetRowCellValue(i, gridView1.Columns["备忘录10"]).ToString().Trim();
                    //dr["出货地编号"] = gridView1.GetRowCellValue(i, gridView1.Columns["出货地编号"]).ToString().Trim();
                    //dr["出荷No."] = gridView1.GetRowCellValue(i, gridView1.Columns["出荷No"]).ToString().Trim();
                    //dr["发票寄送地"] = gridView1.GetRowCellValue(i, gridView1.Columns["发票寄送地"]).ToString().Trim();
                    //dr["发票号"] = gridView1.GetRowCellValue(i, gridView1.Columns["发票号"]).ToString().Trim();
                    string s备注 = gridView1.GetRowCellValue(i, gridView1.Columns["备注"]).ToString().Trim(); ;
                    if (s备注.Length > 50)
                        dr["备注"] = s备注.Substring(0, 50);

                    dtExcel.Rows.Add(dr);
                }

                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "XLSX";
                sF.FileName = "Ufida_Export_POData_OTS_038";
                sF.Filter = "XLSX文件(*.XLSX)|*.XLSX|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK != dRes)
                {
                    return;
                }
                string sPath = sF.FileName;

                gridControl2.DataSource = dtExcel;
                gridView2.ExportToXlsx(sPath);

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
