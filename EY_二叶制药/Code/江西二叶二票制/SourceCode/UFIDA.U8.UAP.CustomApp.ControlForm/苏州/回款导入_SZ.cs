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
    public partial class 回款导入_SZ : UserControl
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

        public string s_Code;

        bool b编辑 = false;

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookup();

                txt收款单号.Enabled = true;
                txt收款单号.Properties.ReadOnly = false;

                gridCol_金税发票号码.OptionsColumn.AllowEdit = false;

            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }


        public 回款导入_SZ()
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


        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    int iCou = 0;
                    string sErr = "";
                    string sSQL = "";

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if(!BaseFunction.ReturnBool(gridView1.GetRowCellValue(i,gridCol_选择)))
                            continue;

//                        sSQL = @"
//select count(1) as iCou from [dbo].[_高开返利单_SZ] where cSBVCode = '{0}'
//";
//                        sSQL = string.Format(sSQL, gridView1.GetRowCellValue(i, gridCol_发票号码).ToString().Trim());
//                        long l = BaseFunction.ReturnLong(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
//                        if (l > 0)
//                        {
//                            sErr = sErr + "行 " + (i + 1).ToString() + "已经做了高开返利单";
//                            continue;
//                        }

                    
                            sSQL = @"
delete  [dbo].[_回款_sap] where 收款单号 = '{0}'
";
                            sSQL = string.Format(sSQL, gridView1.GetRowCellValue(i, gridCol_收款单号).ToString().Trim());
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);

                    }

                    tran.Commit();

                    btnSEL_Click(null, null);

                    MessageBox.Show("删除成功");
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "删除失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {

                    int iCou = 0;
                    string sErr = "";

                    string sSQL = "";
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        sSQL = @"
select count(1) as iCou from [_回款_sap] where [收款单号] = '{0}'
";
                        sSQL = string.Format(sSQL, gridView1.GetRowCellValue(i, gridCol_收款单号).ToString().Trim());
                        long l = BaseFunction.ReturnLong(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);

                        if (l > 0)
                        {
                            sSQL = @"
delete  [_回款_sap] where 收款单号 = '{0}'
";
                            sSQL = string.Format(sSQL, gridView1.GetRowCellValue(i, gridCol_收款单号).ToString().Trim());
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                    }
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        Model._回款_sap mod = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._回款_sap();

                        mod.收款单号 = gridView1.GetRowCellDisplayText(i, gridCol_收款单号).ToString().Trim();
                        mod.收款单日期 = BaseFunction.ReturnDate(gridView1.GetRowCellDisplayText(i, gridCol_收款单日期).ToString().Trim());
                        mod.收款单金额 = BaseFunction.ReturnDecimal(gridView1.GetRowCellDisplayText(i, gridCol_收款单金额).ToString().Trim());
                        mod.业务员编码 = gridView1.GetRowCellDisplayText(i, gridCol_业务员编码).ToString().Trim();
                        mod.业务员 = gridView1.GetRowCellDisplayText(i, gridCol_业务员).ToString().Trim();
                        mod.核销金额 = BaseFunction.ReturnDecimal(gridView1.GetRowCellDisplayText(i, gridCol_核销金额).ToString().Trim());
                        mod.核销日期 = BaseFunction.ReturnDate(gridView1.GetRowCellDisplayText(i, gridCol_核销日期).ToString().Trim());
                        mod.发票号码 = gridView1.GetRowCellDisplayText(i, gridCol_发票号码).ToString().Trim();
                        mod.发票日期 = BaseFunction.ReturnDate(gridView1.GetRowCellDisplayText(i, gridCol_发票日期).ToString().Trim());
                        mod.销售组织 = gridView1.GetRowCellDisplayText(i, gridCol_销售组织).ToString().Trim();
                        mod.客户编码 = gridView1.GetRowCellDisplayText(i, gridCol_客户编码).ToString().Trim();
                        mod.客户名称 = gridView1.GetRowCellDisplayText(i, gridCol_客户名称).ToString().Trim();
                        mod.发票金额 = BaseFunction.ReturnDecimal(gridView1.GetRowCellDisplayText(i, gridCol_发票金额).ToString().Trim());
                        mod.货币单位 = gridView1.GetRowCellDisplayText(i, gridCol_货币单位).ToString().Trim();
                        mod.金税发票号 = gridView1.GetRowCellDisplayText(i, gridCol_金税发票号码).ToString().Trim();
                        mod.分配 = gridView1.GetRowCellDisplayText(i, gridCol_分配).ToString().Trim();
                        mod.清帐凭证号 = gridView1.GetRowCellDisplayText(i, gridCol_清帐凭证号).ToString().Trim();

                        DAL._回款_sap dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._回款_sap();
                        sSQL = dal.Add(mod);

                        iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr.Trim());
                    }

                    if (iCou > 0)
                    {
                        tran.Commit();

                        MessageBox.Show("导入回款成功");

                        gridControl1.DataSource = null;
                    }
                    else
                    {
                        throw new Exception("请选择需要保存的数据");
                    }
                }

                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "保存失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

      
        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败:" + ee.Message);
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridCol_选择, chkAll.Checked);
                }
            }
            catch { }
        }

        private void btnLoadExcel_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog o = new OpenFileDialog();
                o.ShowDialog();

                chkAll.Checked = false;

                string sFile = o.FileName;

                TH.BaseClass.ClsExcel clsExcel = TH.BaseClass.ClsExcel.Instance();

                string sSQL = @"
select *
from [Sheet1$]                    
";
                DataTable dt = clsExcel.ExcelToDT(sFile, sSQL, true);
                DataColumn dc = new DataColumn();
                dc.ColumnName = "choose";
                dc.DataType = System.Type.GetType("System.Boolean");
                dc.DefaultValue = false;
                dt.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "已使用";
                dc.DataType = System.Type.GetType("System.Boolean");
                dc.DefaultValue = false;
                dt.Columns.Add(dc);

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    dt.Columns[i].ColumnName = dt.Columns[i].ColumnName.ToString().Trim();
                }
                gridControl1.DataSource = dt;

                gridView1.BestFitColumns();

            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败:" + ee.Message);
            }
        }

        private void SetLookup()
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.Int32");
            dc.ColumnName = "iYear";
            dt.Columns.Add(dc);

            int iYear = 2018;
            for (int i = iYear; i <= DateTime.Now.Year + 1; i++)
            {
                DataRow dr = dt.NewRow();
                dr["iYear"] = i;
                dt.Rows.Add(dr);
            }
            lookUpEditYear.Properties.DataSource = dt;
            lookUpEditYear.EditValue = DateTime.Now.Year;

            dt = new DataTable();
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.Int32");
            dc.ColumnName = "iMonth";
            dt.Columns.Add(dc);
            for (int i = 1; i <= 12; i++)
            {
                DataRow dr = dt.NewRow();
                dr["iMonth"] = i;
                dt.Rows.Add(dr);
            }

            lookUpEditMonth.Properties.DataSource = dt;
            lookUpEditMonth.EditValue = DateTime.Now.Month;


        }

        private void btnSEL_Click(object sender, EventArgs e)
        {
            try
            {
                if (lookUpEditYear.EditValue == null || lookUpEditYear.Text.Trim() == "")
                {
                    lookUpEditYear.Focus();
                    throw new Exception("请选择期间");
                }

                if (lookUpEditMonth.EditValue == null || lookUpEditMonth.Text.Trim() == "")
                {
                    lookUpEditMonth.Focus();
                    throw new Exception("请选择期间");
                }

                string sSQL = @"
select *,cast(0 as bit) as choose,cast(0 as bit) as 已使用
from [dbo].[_回款_sap]
where 1=1
order by 收款单号,iID
";
                sSQL = sSQL.Replace("1=1", "1=1 and year(收款单日期) = " + lookUpEditYear.Text.Trim() + " and month(收款单日期) = " + lookUpEditMonth.Text.Trim());

                if (txt收款单号.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and 收款单号 like '%" + txt收款单号.Text.Trim() + "%'");
                }

                DataTable dt = DbHelperSQL.Query(sSQL);
                gridControl1.DataSource = dt;
                gridView1.BestFitColumns();

                b编辑 = false;

                chkAll.Checked = false;
            }
            catch(Exception ee)
            {
                MessageBox.Show("加载数据失败:" + ee.Message);
            }
        }
    }
}
