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
    public partial class ImprotExcel : UserControl
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

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
            
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }


        public ImprotExcel()
        {
            InitializeComponent();
        }

        private void GetGrid(string sCode, string Conn, string sUserID, string sUserName, string sLogDate, string sAccID)
        {
         

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


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView回款.FocusedRowHandle -= 1;
                    gridView回款.FocusedRowHandle += 1;

                    gridView发票.FocusedRowHandle -= 1;
                    gridView发票.FocusedRowHandle += 1;
                }
                catch { }


                if (radio发票.Checked)
                {
                    SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                    conn.Open();
                    //启用事务
                    SqlTransaction tran = conn.BeginTransaction();
                    try
                    {
                        int iCou = 0;
                        string sErr = "";
                        string sSQL = "";

                        for (int i = 0; i < gridView发票.RowCount; i++)
                        {
                            sSQL = @"
select count(1) as iCou from [dbo].[_高开返利单] where cSBVCode = '{0}'
";
                            sSQL = string.Format(sSQL, gridView发票.GetRowCellValue(i, gridCol发票号码).ToString().Trim());
                            long l = BaseFunction.ReturnLong(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                            if (l > 0)
                            {
                                sErr = sErr + "行 " + (i + 1).ToString() + "已经做了高开返利单";
                                continue;
                            }

                            sSQL = @"
select count(1) as iCou from [_发票_sap] where 发票号码 = '{0}'
";
                            sSQL = string.Format(sSQL, gridView发票.GetRowCellValue(i, gridCol发票号码).ToString().Trim());
                            l = BaseFunction.ReturnLong(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);

                            if (l > 0)
                            {
                                sSQL = @"
delete  [_发票_sap] where 发票号码 = '{0}'
";
                                sSQL = string.Format(sSQL, gridView发票.GetRowCellValue(i, gridCol发票号码).ToString().Trim());
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                        }

                        for (int i = 0; i < gridView发票.RowCount; i++)
                        {
                            Model._发票_sap mod = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._发票_sap();
                            mod.销售组织 = gridView发票.GetRowCellValue(i, gridCol销售组织).ToString().Trim();
                            mod.发票号码 = gridView发票.GetRowCellValue(i, gridCol发票号码).ToString().Trim();
                            mod.发票类型 = gridView发票.GetRowCellValue(i, gridCol发票类型).ToString().Trim();
                            mod.发票类型名称 = gridView发票.GetRowCellValue(i, gridCol发票类型名称).ToString().Trim();
                            mod.发票日期 = BaseFunction.ReturnDate(gridView发票.GetRowCellValue(i, gridCol发票日期).ToString().Trim());
                            mod.客户编码 = gridView发票.GetRowCellValue(i, gridCol客户编码).ToString().Trim();
                            mod.客户名称 = gridView发票.GetRowCellValue(i, gridCol客户名称).ToString().Trim();
                            mod.代码商编码 = gridView发票.GetRowCellValue(i, gridCol代码商编码).ToString().Trim();
                            mod.代理商名称 = gridView发票.GetRowCellValue(i, gridCol代理商名称).ToString().Trim();
                            mod.业务员编码 = gridView发票.GetRowCellValue(i, gridCol业务员编码).ToString().Trim();
                            mod.业务员名称 = gridView发票.GetRowCellValue(i, gridCol业务员名称).ToString().Trim();
                            mod.省份编码 = gridView发票.GetRowCellValue(i, gridCol省份编码).ToString().Trim();
                            mod.省份名称 = gridView发票.GetRowCellValue(i, gridCol省份名称).ToString().Trim();
                            mod.城市编码 = gridView发票.GetRowCellValue(i, gridCol城市编码).ToString().Trim();
                            mod.发货单号 = gridView发票.GetRowCellValue(i, gridCol发货单号).ToString().Trim();
                            mod.发货行号 = BaseFunction.ReturnInt(gridView发票.GetRowCellValue(i, gridCol发货行号).ToString().Trim());
                            mod.货物编码 = gridView发票.GetRowCellValue(i, gridCol货物编码).ToString().Trim();
                            mod.货物名称 = gridView发票.GetRowCellValue(i, gridCol货物名称).ToString().Trim();
                            mod.规格型号 = gridView发票.GetRowCellValue(i, gridCol规格型号).ToString().Trim();
                            mod.批次 = gridView发票.GetRowCellValue(i, gridCol批次).ToString().Trim();
                            mod.单价 = BaseFunction.ReturnDecimal(gridView发票.GetRowCellValue(i, gridCol单价).ToString().Trim());
                            mod.开票数量 = BaseFunction.ReturnDecimal(gridView发票.GetRowCellValue(i, gridCol开票数量).ToString().Trim());
                            mod.金额 = BaseFunction.ReturnDecimal(gridView发票.GetRowCellValue(i, gridCol金额).ToString().Trim());
                            mod.货币单位 = gridView发票.GetRowCellValue(i, gridCol货币单位).ToString().Trim();

                            DAL._发票_sap dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._发票_sap();
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

                            MessageBox.Show("导入发票成功");

                            gridControl发票.DataSource = null;
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
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "保存失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }

            if (radio回款.Checked)
            {
                

                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {

                    int iCou = 0;
                    string sErr = "";

                    string sSQL = "";
                    for (int i = 0; i < gridView回款.RowCount; i++)
                    {
                        sSQL = @"
select count(1) as iCou from [_回款_sap] where [收款单号] = '{0}'
";
                        sSQL = string.Format(sSQL, gridView回款.GetRowCellValue(i, gridCol_收款单号).ToString().Trim());
                        long l = BaseFunction.ReturnLong(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);

                        if (l > 0)
                        {
                            sSQL = @"
delete  [_回款_sap] where 收款单号 = '{0}'
";
                            sSQL = string.Format(sSQL, gridView回款.GetRowCellValue(i, gridCol_收款单号).ToString().Trim());
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                    }
                    for (int i = 0; i < gridView回款.RowCount; i++)
                    {
                        Model._回款_sap mod = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._回款_sap();

                        mod.收款单号 = gridView回款.GetRowCellValue(i, gridCol_收款单号).ToString().Trim();
                        mod.收款单日期 = BaseFunction.ReturnDate(gridView回款.GetRowCellValue(i, gridCol_收款单日期).ToString().Trim());
                        mod.收款单金额 = BaseFunction.ReturnDecimal(gridView回款.GetRowCellValue(i, gridCol_收款单金额).ToString().Trim());
                        mod.业务员编码 = gridView回款.GetRowCellValue(i, gridCol_业务员编码).ToString().Trim();
                        mod.业务员 = gridView回款.GetRowCellValue(i, gridCol_业务员).ToString().Trim();
                        mod.核销金额 = BaseFunction.ReturnDecimal(gridView回款.GetRowCellValue(i, gridCol_核销金额).ToString().Trim());
                        mod.核销日期 = BaseFunction.ReturnDate(gridView回款.GetRowCellValue(i, gridCol_核销日期).ToString().Trim());
                        mod.发票号码 = gridView回款.GetRowCellValue(i, gridCol_发票号码).ToString().Trim();
                        mod.发票日期 = BaseFunction.ReturnDate(gridView回款.GetRowCellValue(i, gridCol_发票日期).ToString().Trim());
                        mod.销售组织 = gridView回款.GetRowCellValue(i, gridCol_销售组织).ToString().Trim();
                        mod.客户编码 = gridView回款.GetRowCellValue(i, gridCol_客户编码).ToString().Trim();
                        mod.客户名称 = gridView回款.GetRowCellValue(i, gridCol客户名称).ToString().Trim();
                        mod.发票金额 = BaseFunction.ReturnDecimal(gridView回款.GetRowCellValue(i, gridCol_发票金额).ToString().Trim());
                        mod.货币单位 = gridView回款.GetRowCellValue(i, gridCol_货币单位).ToString().Trim();

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

                        gridControl回款.DataSource = null;
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
        }


        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog o = new OpenFileDialog();
                o.ShowDialog();

                string sFile = o.FileName;


                if (radio发票.Checked)
                {
                    gridControl回款.Visible = false;
                    gridControl发票.Visible = true;

                    TH.BaseClass.ClsExcel clsExcel = TH.BaseClass.ClsExcel.Instance();

                    string sSQL = @"
select *
from [发票$]                    
";
                    DataTable dt = clsExcel.ExcelToDT(sFile, sSQL, true);

                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        dt.Columns[i].ColumnName = dt.Columns[i].ColumnName.ToString().Trim();
                    }
                    gridControl发票.DataSource = dt;

                    gridView发票.BestFitColumns();
                }
                if (radio回款.Checked)
                {
                    gridControl发票.Visible = false;
                    gridControl回款.Visible = true;

                    TH.BaseClass.ClsExcel clsExcel = TH.BaseClass.ClsExcel.Instance();

                    string sSQL = @"
select *
from [回款$]                    
";
                    DataTable dt = clsExcel.ExcelToDT(sFile, sSQL, true);

                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        dt.Columns[i].ColumnName = dt.Columns[i].ColumnName.ToString().Trim();
                    }

                    gridControl回款.DataSource = dt;

                    gridView回款.BestFitColumns();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败:" + ee.Message);
            }
        }

        private void radio发票_CheckedChanged(object sender, EventArgs e)
        {
            gridControl发票.Visible = true;
            gridControl回款.Visible = false;
        }

        private void radio回款_CheckedChanged(object sender, EventArgs e)
        {
            gridControl发票.Visible = false;
            gridControl回款.Visible = true;
        }

     
    }
}
