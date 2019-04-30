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
    public partial class Frm受注残数据 : Form
    {
        public Frm受注残数据()
        {
            InitializeComponent();
        }

        private void SetLookUp()
        {
            string sSQL = "select cSOCode from SO_SOMain  order by cSOCode";
            DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditcSOCode1.Properties.DataSource = dt;
            lookUpEditcSOCode2.Properties.DataSource = dt;

            sSQL = "select cCusCode,cCusName from Customer order by cCusCode";
            dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditcCusCode1.Properties.DataSource = dt;
            lookUpEditcCusCode2.Properties.DataSource = dt;
        }

        private void GetGrid()
        {
            chkAll.Checked = false;

            string sSQL = @"
select cast(1 as bit) as 选择,a.cMaker as 制单人,b.cDefine31 as 表体自定义项10,cast(d.cidefine12 as decimal(21,7)) as 成本合計,e.iQty as 预留数量
    ,*								
    ,isnull(iquantity - isnull(iFHQuantity,0),0) - isnull(e.iQty,0) as iqtyszc
    ,isnull(cast(c.cInvDefine13 * b.iQuantity as decimal(16,6)),0) as cInvDefine13
    ,isnull(cInvDefine1,0) as 生产线
from so_somain a inner join so_sodetails b on a.id = b.id
    inner join Inventory c on b.cInvCode = c.cInvCode
    left join Inventory_extradefine d on b.cInvCode = d.cInvCode
    LEFT JOIN (SELECT [cInvCode],[iSodid],SUM([iQuantity]) AS iqty FROM [ST_PELockedSum] GROUP BY [cInvCode],[iSodid]) e ON e.iSodid = b.iSOsID
where 1=1 and isnull(c.bSelf ,0) = 1
    and isnull(iquantity - isnull(iFHQuantity,0),0) - isnull(e.iQty,0) <> 0
order by a.id,b.AutoID
";

            if (lookUpEditcSOCode1.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cSOCode >= '" + lookUpEditcSOCode1.Text.Trim().Trim() + "'");
            }
            if (lookUpEditcSOCode2.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cSOCode <= '" + lookUpEditcSOCode2.Text.Trim().Trim() + "'");
            }
            //if (dateEdit1.Text.Trim() != "")
            //{
            //    sSQL = sSQL.Replace("1=1", "1=1 and a.dDate >= '" + dateEdit1.Text.Trim().Trim() + "'");
            //}
            //if (dateEdit2.Text.Trim() != "")
            //{
            //    sSQL = sSQL.Replace("1=1", "1=1 and a.dDate <= '" + dateEdit2.Text.Trim().Trim() + "'");
            //}
            if (lookUpEditcCusCode1.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cCusCode >= '" + lookUpEditcCusCode1.Text.Trim().Trim() + "'");
            }
            if (lookUpEditcCusCode2.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cCusCode <= '" + lookUpEditcCusCode2.Text.Trim().Trim() + "'");
            }

            DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

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
                    if (!BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColchoose)))
                    {
                        continue;
                    }

                    string s销售订单号 = gridView1.GetRowCellValue(i, gridCol受注No).ToString().Trim();
                    if (s销售订单号.Length >= 8)
                        s销售订单号 = s销售订单号.Substring(s销售订单号.Length - 8);

                    strDetail.Append(ClsFormatString.SetStringFormat(s销售订单号, 8, '0'));
                    strDetail.Append(ClsFormatString.SetStringFormat(gridView1.GetRowCellValue(i, gridCol顾客订单NO), 23));

                    string s交期 = "";
                    if (BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridCol交期)) > BaseFunction.ReturnDate("2000-01-01"))
                    {
                        s交期 = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridCol交期)).ToString("yyyyMMdd");
                    }

                    strDetail.Append(ClsFormatString.SetStringFormat(s交期, 8));
                    strDetail.Append(ClsFormatString.SetStringFormat(gridView1.GetRowCellValue(i, gridCol仓库编号), 3));
                    string s受注处理日 = "";
                    if (BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridCol受注处理日)) > BaseFunction.ReturnDate("2000-01-01"))
                    {
                        s受注处理日 = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridCol受注处理日)).ToString("yyyyMMdd");
                    }
                    strDetail.Append(ClsFormatString.SetStringFormat(s受注处理日, 8));
                    strDetail.Append(ClsFormatString.SetStringFormat(gridView1.GetRowCellValue(i, gridCol顾客No), 8));
                    strDetail.Append(ClsFormatString.SetStringFormat(gridView1.GetRowCellValue(i, gridCol顾客名称), 50));

                    if (gridView1.GetRowCellValue(i, gridCol制单人).ToString().Trim().ToLower() == "xtx" || gridView1.GetRowCellValue(i, gridCol制单人).ToString().Trim().ToLower() == "徐天翔")
                    {
                        strDetail.Append(ClsFormatString.SetStringFormat(gridView1.GetRowCellValue(i, gridCol表体自定义项10), 4, '0'));
                    }
                    else
                    {
                        strDetail.Append(ClsFormatString.SetStringFormat(gridView1.GetRowCellValue(i, gridCol受注行No), 4, '0'));
                    }

                    strDetail.Append(ClsFormatString.SetStringFormat(gridView1.GetRowCellValue(i, gridCol产品编号), 35));
                    strDetail.Append(ClsFormatString.SetStringFormat(gridView1.GetRowCellValue(i, gridCol产品编号备注), 50));
                    decimal d受注数量 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol受注数量), 3);
                    string s受注数量 = d受注数量.ToString("f3");
                    strDetail.Append(ClsFormatString.SetStringFormat(s受注数量, 13, '0'));
                    decimal d已出货数量 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol已出货数量), 3);
                    string s已出货数量 = d已出货数量.ToString("f3");
                    strDetail.Append(ClsFormatString.SetStringFormat(s已出货数量, 13, '0'));
                    decimal d受注残数量 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol受注残数量), 3);
                    string s受注残数量 = d受注残数量.ToString("f3");
                    strDetail.Append(ClsFormatString.SetStringFormat(s受注残数量, 13, '0'));
                    decimal d成本合計 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol成本合計), 7);

                    if (d成本合計 != 0)
                    {
                        string s成本合計 = d成本合計.ToString("f7");
                        strDetail.Append(ClsFormatString.SetStringFormat(d成本合計, 21, '0'));
                    }
                    else
                    {
                        strDetail.Append("0000000000000.0000000");
                    }
                    strDetail.Append(ClsFormatString.SetStringFormat(gridView1.GetRowCellValue(i, gridCol生产线), 5));

                    strDetail.Append("\r\n");
                }

                string sPath = sFilePath + @"Receive_All_Order.txt";
                string s = strDetail.ToString();
                File.WriteAllText(sPath, s, Encoding.Default);
            }
            catch (Exception ee)
            {

            }
        }

        string sFilePath = "";
        SqlTransaction tran = null;
        public void ExportData(DateTime dtmStart,DateTime dtmEnd,string sPath,SqlTransaction sqlTran)
        {
            try
            {
                sFilePath = sPath;
                tran = sqlTran;
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
