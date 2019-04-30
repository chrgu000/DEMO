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
    public partial class 有效在库数据安排生产 : UserControl
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

                SetLookUp();
                GetGrid();

                gridView1.BestFitColumns();
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
            string sSQL = "select cInvCode,cInvName,cInvStd from Inventory  order by cInvCode";
            DataTable dt = DbHelperSQL.Query(sSQL);
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditcInvCode1.Properties.DataSource = dt;
            lookUpEditcInvCode2.Properties.DataSource = dt;
        }

        public 有效在库数据安排生产()
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

                    strDetail.Append(ClsFormatString.SetStringFormat(gridView1.GetRowCellValue(i, gridView1.Columns["仓库编号"]), 3));
                    strDetail.Append(ClsFormatString.SetStringFormat(gridView1.GetRowCellValue(i, gridView1.Columns["产品编号"]), 35));
                    strDetail.Append(ClsFormatString.SetStringFormat(gridView1.GetRowCellValue(i, gridView1.Columns["产品编号备注"]), 50));
                    strDetail.Append(ClsFormatString.SetStringFormat(gridView1.GetRowCellValue(i, gridView1.Columns["符号"]), 1));
                    strDetail.Append(ClsFormatString.SetStringFormat(gridView1.GetRowCellValue(i, gridView1.Columns["有效在库数量"]), 12, '0'));
                    strDetail.Append(ClsFormatString.SetStringFormat(gridView1.GetRowCellValue(i, gridView1.Columns["生产线"]), 5));

                    strDetail.Append("\r\n");
                }

                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "txt";
                sF.FileName = "Receive_All_Stock";
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
select cast(1 as bit) as 选择
    ,a.cWhCode as 仓库编号,a.cInvCode as 产品编号,b.cInvName as 产品编号备注,null as 符号,cast(sum(a.iQuantity) as decimal(18,3)) as 有效在库数量
    ,b.cInvDefine1 as 生产线							
from CurrentStock a inner join Inventory b on a.cInvCode = b.cInvCode
    
where 1=1 and isnull(bSelf ,0) = 1
group by a.cWhCode,a.cInvCode,b.cInvName,b.cInvDefine1
having sum(cast((a.iQuantity - isnull(a.fOutQuantity,0)) as decimal(18,3)))>0
order by a.cInvCode
";

            if(lookUpEditcInvCode1.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cInvCode >= '" + lookUpEditcInvCode1.Text.Trim().Trim() + "'");
            }
            if (lookUpEditcInvCode2.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cInvCode <= '" + lookUpEditcInvCode2.Text.Trim().Trim() + "'");
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
                case "csocode": sReturn = "受注No."; break;
                     
                default:
                    sReturn = s; break;
            }

            sReturn = sReturn.Replace(".", "");
            return sReturn;
        }
    }
}
