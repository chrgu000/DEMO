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
    public partial class 发票导入_SZ : UserControl
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

                txt发票号.Enabled = true;
                txt发票号.Properties.ReadOnly = false;

                gridCol金税发票号码.OptionsColumn.AllowEdit = false;

            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }


        public 发票导入_SZ()
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
                        if(!BaseFunction.ReturnBool(gridView1.GetRowCellValue(i,gridCol选择)))
                            continue;

                        sSQL = @"
select count(1) as iCou from [dbo].[_高开返利单_SZ] where cSBVCode = '{0}'
";
                        sSQL = string.Format(sSQL, gridView1.GetRowCellValue(i, gridCol发票号码).ToString().Trim());
                        long l = BaseFunction.ReturnLong(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                        if (l > 0)
                        {
                            sErr = sErr + "行 " + (i + 1).ToString() + "已经做了高开返利单";
                            continue;
                        }

                    
                            sSQL = @"
delete  [_发票_sap] where 发票号码 = '{0}'
";
                            sSQL = string.Format(sSQL, gridView1.GetRowCellValue(i, gridCol发票号码).ToString().Trim());
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

                    string sString = "";

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        bool b = BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridCol选择));
                        if (!b)
                            continue;

                        sSQL = @"
select count(1) as iCou from [dbo].[_高开返利单_SZ] where cSBVCode = '{0}'
                        ";
                        sSQL = string.Format(sSQL, gridView1.GetRowCellValue(i, gridCol发票号码).ToString().Trim());
                        long l = BaseFunction.ReturnLong(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                        if (l > 0)
                        {
                            sString = sString + "行 " + (i + 1).ToString() + "已经做了高开返利单\n";
                            gridView1.SetRowCellValue(i, gridCol选择, false);
                            continue;
                        }

                        //未做高开返利单的当月发票全部删除
                        sSQL = @"
delete 
from [dbo].[_发票_sap] 
where year([发票日期]) = {0} and month([发票日期]) = {1}
	and 发票号码 not in (
			select DISTINCT 发票号码 from [_发票_sap] where year([发票日期]) = {0} and month([发票日期]) = {1} and iID in (select FPIDs from [dbo].[_高开返利单_SZ])
			)
";
                        sSQL = string.Format(sSQL, BaseFunction.ReturnInt(lookUpEditYear.EditValue).ToString().Trim(), BaseFunction.ReturnInt(lookUpEditMonth.EditValue).ToString().Trim());
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

//                        sSQL = @"
//select count(1) as iCou from [_发票_sap] where 发票号码 = '{0}'
//                        ";
//                        sSQL = string.Format(sSQL, gridView1.GetRowCellValue(i, gridCol发票号码).ToString().Trim());
//                        l = BaseFunction.ReturnLong(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);

//                        if (l > 0)
//                        {
//                            sSQL = @"
//delete  [_发票_sap] where 发票号码 = '{0}'
//                        ";
//                            sSQL = string.Format(sSQL, gridView1.GetRowCellValue(i, gridCol发票号码).ToString().Trim());
//                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
//                        }

                    }

                    if (sString.Length > 0)
                    {
                        FrmMsgBox frm = new FrmMsgBox();
                        frm.Text = "存在已经做了高开返利单，是否继续？";
                        frm.richTextBox1.Text = sString;

                        frm.ShowDialog();


                        if (DialogResult.OK != frm.DialogResult)
                        {
                            throw new Exception("用户取消操作!");
                        }
                    }

                    try
                    {
                        gridView1.FocusedRowHandle -= 1;
                        gridView1.FocusedRowHandle += 1;
                    }
                    catch { }


                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        bool b = BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridCol选择));
                        if (!b)
                            continue;

//                        sSQL = @"
//select count(1) as iCou from [dbo].[_高开返利单_SZ] where cSBVCode = '{0}'
//                        ";
//                        sSQL = string.Format(sSQL, gridView1.GetRowCellValue(i, gridCol发票号码).ToString().Trim());
//                        long l = BaseFunction.ReturnLong(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
//                        if (l > 0)
//                        {
//                            sString = sString + "行 " + (i + 1).ToString() + "已经做了高开返利单";
//                            continue;
//                        }


//                        sSQL = @"
//select count(1) as iCou from [_发票_sap] where 发票号码 = '{0}'
//                        ";
//                        sSQL = string.Format(sSQL, gridView1.GetRowCellValue(i, gridCol发票号码).ToString().Trim());
//                        l = BaseFunction.ReturnLong(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);

//                        if (l > 0)
//                        {
//                            sSQL = @"
//delete  [_发票_sap] where 发票号码 = '{0}'
//                        ";
//                            sSQL = string.Format(sSQL, gridView1.GetRowCellValue(i, gridCol发票号码).ToString().Trim());
//                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
//                        }

                        Model._发票_sap mod = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._发票_sap();
                        mod.销售组织 = gridView1.GetRowCellDisplayText(i, gridCol销售组织).ToString().Trim();
                        mod.发票号码 = gridView1.GetRowCellDisplayText(i, gridCol发票号码).ToString().Trim();
                        mod.发票类型 = gridView1.GetRowCellDisplayText(i, gridCol发票类型).ToString().Trim();
                        mod.发票类型名称 = gridView1.GetRowCellDisplayText(i, gridCol发票类型名称).ToString().Trim();
                        mod.发票日期 = BaseFunction.ReturnDate(gridView1.GetRowCellDisplayText(i, gridCol发票日期).ToString().Trim());
                        mod.客户编码 = gridView1.GetRowCellDisplayText(i, gridCol客户编码).ToString().Trim();
                        mod.客户名称 = gridView1.GetRowCellDisplayText(i, gridCol客户名称).ToString().Trim();
                        mod.代理商编码 = gridView1.GetRowCellDisplayText(i, gridCol代理商编码).ToString().Trim();
                        mod.代理商名称 = gridView1.GetRowCellDisplayText(i, gridCol代理商名称).ToString().Trim();
                        mod.业务员编码 = gridView1.GetRowCellDisplayText(i, gridCol业务员编码).ToString().Trim();
                        mod.业务员名称 = gridView1.GetRowCellDisplayText(i, gridCol业务员名称).ToString().Trim();
                        mod.省份编码 = gridView1.GetRowCellDisplayText(i, gridCol省份编码).ToString().Trim();
                        mod.省份名称 = gridView1.GetRowCellDisplayText(i, gridCol省份名称).ToString().Trim();
                        mod.城市编码 = gridView1.GetRowCellDisplayText(i, gridCol城市编码).ToString().Trim();
                        mod.发货单号 = gridView1.GetRowCellDisplayText(i, gridCol发货单号).ToString().Trim();
                        mod.发货行号 = BaseFunction.ReturnInt(gridView1.GetRowCellDisplayText(i, gridCol发货行号).ToString().Trim());
                        mod.货物编码 = gridView1.GetRowCellDisplayText(i, gridCol货物编码).ToString().Trim();
                        mod.货物旧编码 = gridView1.GetRowCellDisplayText(i, gridCol货物旧编码).ToString().Trim();
                        mod.货物名称 = gridView1.GetRowCellDisplayText(i, gridCol货物名称).ToString().Trim();
                        mod.规格型号 = gridView1.GetRowCellDisplayText(i, gridCol规格型号).ToString().Trim();
                        mod.批次 = gridView1.GetRowCellDisplayText(i, gridCol批次).ToString().Trim();
                        mod.单价 = BaseFunction.ReturnDecimal(gridView1.GetRowCellDisplayText(i, gridCol单价).ToString().Trim());
                        mod.开票数量 = BaseFunction.ReturnDecimal(gridView1.GetRowCellDisplayText(i, gridCol开票数量).ToString().Trim());
                        mod.金额 = BaseFunction.ReturnDecimal(gridView1.GetRowCellDisplayText(i, gridCol金额).ToString().Trim());
                        mod.货币单位 = gridView1.GetRowCellDisplayText(i, gridCol货币单位).ToString().Trim();
                        mod.发票已取消 = gridView1.GetRowCellDisplayText(i, gridCol发票已取消).ToString().Trim();
                        mod.被冲销的号码 = gridView1.GetRowCellDisplayText(i, gridCol被冲销的号码).ToString().Trim();
                        mod.PO项目 = gridView1.GetRowCellDisplayText(i, gridColPO项目).ToString().Trim();
                        mod.iID = BaseFunction.ReturnLong(gridView1.GetRowCellDisplayText(i, gridColiID));
                        mod.金税发票号码 = gridView1.GetRowCellDisplayText(i, gridCol金税发票号码).ToString().Trim();

                        DAL._发票_sap dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._发票_sap();


                        if (b编辑 && mod.iID >0)
                        {
                            sSQL = dal.Update(mod);
                        }
                        else
                        {
                            sSQL = dal.Add(mod);
                        }
                        iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr.Trim());
                    }

                    b编辑 = false;

                    if (iCou > 0)
                    {
                        tran.Commit();

                        MessageBox.Show("导入发票成功");

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
                    gridView1.SetRowCellValue(i, gridCol选择, chkAll.Checked);
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

                b编辑 = false;

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
from _发票_sap
where 1=1
order by 发票号码,iID
";
                sSQL = sSQL.Replace("1=1", "1=1 and year(发票日期) = " + lookUpEditYear.Text.Trim() + " and month(发票日期) = " + lookUpEditMonth.Text.Trim());

                if (txt发票号.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and 发票号码 like '%" + txt发票号.Text.Trim() + "%'");
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

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == gridCol金税发票号码)
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridCol选择, true);
                }
            }
            catch { }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if(gridView1.RowCount > 0 && BaseFunction.ReturnLong(gridView1.GetRowCellValue(0,gridColiID)) <= 0)
                {
                    throw new Exception("数据尚未导入，不需要编辑");
                }

                gridCol金税发票号码.OptionsColumn.AllowEdit = true;
                b编辑 = true;
            }
            catch(Exception ee)
            {
                MessageBox.Show("编辑失败:" + ee.Message);
            }
        }
    }
}
