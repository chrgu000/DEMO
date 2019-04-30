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
    public partial class 车间材料领用汇总月报 : UserControl
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
                label审核.Text = "";

                GetLookUp();
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        public 车间材料领用汇总月报()
        {
            InitializeComponent();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
                sF.Filter = "Excel文件(*.xls)|*.xls|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridView1.ExportToXls(sF.FileName);
                    MessageBox.Show("导出Excel成功\n\t路径：" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "导出Excel失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void GetLookUp()
        {
            string sSQL = "select cDepCode,cDepName from Department where isnull(bDepEnd ,0) <> 0  and isnull(cDepProp,'') = '成本' order by cDepCode";
            DataTable dt = DbHelperSQL.Query(sSQL);
            lookUpEditcDepName.Properties.DataSource = dt;
            lookUpEditcDepCode.Properties.DataSource = dt;

            sSQL = "select distinct 会计期间 from  _ProMaterial order by 会计期间";
            dt = DbHelperSQL.Query(sSQL);
            
            lookUpEdit会计期间.Properties.DataSource = dt;
            if (dt != null && dt.Rows.Count > 0)
            {
                lookUpEdit会计期间.EditValue = dt.Rows[dt.Rows.Count - 1]["会计期间"];
            }

            sSQL = @"
select cInvCode,cInvName,cInvStd,cInvAddCode, a.cComUnitCode ,b.cComUnitName
from Inventory a inner join ComputationUnit b on a.cComUnitCode = b.cComunitCode
order by a.cInvCode
";
            dt = DbHelperSQL.Query(sSQL);
            ItemLookUpEditcInvCode.DataSource = dt;
            ItemLookUpEditcInvName.DataSource = dt;
            ItemLookUpEditcInvStd.DataSource = dt;
            ItemLookUpEditcComUnitName.DataSource = dt;

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


        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                lookUpEditcDepCode.EditValue = DBNull.Value;
                lookUpEditcDepName.EditValue = DBNull.Value;
            }
            catch (Exception ee)
            {
                MessageBox.Show("清空失败：" + ee.Message);
            }
        }

        private void GetGrid()
        {
            try
            {
                label审核.Text = "";

                if (lookUpEdit会计期间.Text.ToString().Trim() == "")
                {
                    throw new Exception("请选择会计期间");
                }
                if (lookUpEditcDepCode.Text.ToString().Trim() == "")
                {
                    throw new Exception("请选择部门");
                }

                l会计期间.Text = lookUpEdit会计期间.EditValue.ToString().Trim();
                l部门编码.Text = lookUpEditcDepCode.EditValue.ToString().Trim();

                string sSQL = @"
exec _Get产品材料耗用月汇总 '111111','222222'
";
                sSQL = sSQL.Replace("111111", lookUpEdit会计期间.Text.ToString().Trim());
                sSQL = sSQL.Replace("222222", lookUpEditcDepCode.EditValue.ToString().Trim());

                DataTable dt = DbHelperSQL.Query(sSQL);

                sSQL = @"
select * from _ProMaterial where 会计期间 = '111111' and 部门 = '222222' and isnull(审核人,'') <> ''
";
                sSQL = sSQL.Replace("111111", lookUpEdit会计期间.Text.ToString().Trim());
                sSQL = sSQL.Replace("222222", lookUpEditcDepCode.EditValue.ToString().Trim());
                DataTable dt审核 = DbHelperSQL.Query(sSQL);
                if (dt审核 != null && dt审核.Rows.Count > 0)
                {
                    label审核.Text = "已审核";
                }
                else
                {
                    sSQL = @"
select * from _QCMaterial where 会计期间 = '111111' and 部门 = '222222' and isnull(审核人,'') <> ''
";
                    sSQL = sSQL.Replace("111111", lookUpEdit会计期间.Text.ToString().Trim());
                    sSQL = sSQL.Replace("222222", lookUpEditcDepCode.EditValue.ToString().Trim());
                    dt审核 = DbHelperSQL.Query(sSQL);
                    if (dt审核 != null && dt审核.Rows.Count > 0)
                    {
                        label审核.Text = "已审核";
                    }
                    else
                    {
                        label审核.Text = "";
                    }
                }

                for (int i = gridView1.Columns.Count - 1; i >= 0; i--)
                {

                    if (gridView1.Columns[i].Name.StartsWith("gridColtemp"))
                    {
                        gridView1.Columns.RemoveAt(i);
                    }
                }
                for (int i = gridView1.Bands.Count - 1; i >= 0; i--)
                {
                    if (gridView1.Bands[i].Name.StartsWith("gridBandtemp"))
                    {
                        gridView1.Bands.RemoveAt(i);
                    }
                }

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (dt.Columns[i].ColumnName.Length < 12)
                    {
                        continue;
                    }

                    if (dt.Columns[i].ColumnName.StartsWith("产品数量_"))
                    {
                        AddBand(dt.Columns[i].ColumnName);
                        AddCol(dt.Columns[i].ColumnName);
                    }

                    if (dt.Columns[i].ColumnName.StartsWith("产品金额_"))
                    {
                        AddCol(dt.Columns[i].ColumnName);
                    }
                    if (dt.Columns[i].ColumnName.StartsWith("产品单价_"))
                    {
                        AddCol(dt.Columns[i].ColumnName);
                    }
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    decimal d = 0;
                    for (int j = 0; j < dt.Columns.Count; j++)
                    { 
                        string sColName = dt.Columns[j].ColumnName.Trim();
                        if (sColName.Length > 5 && sColName.Substring(0, 5) == "产品金额_")
                        {
                            d = d + TH.BaseClass.BaseFunction.ReturnDecimal(dt.Rows[i][j], 2);
                        }
                    }

                    if (d != 0)
                    {
                        dt.Rows[i]["本月耗用金额"] = d;
                    }
                    else
                    {
                        dt.Rows[i]["本月耗用金额"] = DBNull.Value;
                        dt.Rows[i]["本月耗用单价"] = DBNull.Value;
                    }
                }

                gridControl1.DataSource = dt;
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }
        private void lookUpEditcDepName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEditcDepCode.EditValue = lookUpEditcDepName.EditValue;
            }
            catch { }
        }

        private void lookUpEditcDepCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEditcDepName.EditValue = lookUpEditcDepCode.EditValue;
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
                MessageBox.Show("加载数据失败：" + ee.Message);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
                sF.Filter = "Excel文件(*.xls)|*.xls|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridView1.ExportToXls(sF.FileName);
                    MessageBox.Show("导出Excel成功\n\t路径：" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "导出Excel失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void AddBand(string sColName)
        {
            DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            gridBand.Caption = sColName.Substring(5);
            gridBand.MinWidth = 20;
            gridBand.Name = "gridBandtemp" + sColName.Substring(5);
            gridBand.Width = 30;
            gridBand.AppearanceHeader.Options.UseTextOptions = true;
            gridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Bands.Add(gridBand);
        }

        private void AddCol(string sColName)
        {
            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn1.Caption = sColName.Substring(2, 2);
            gridColumn1.Name = "gridColtemp" + sColName;
            gridColumn1.FieldName = sColName;
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = gridView1.Columns.Count;
            gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            gridColumn1.OptionsFilter.AllowFilter = false;
            //gridColumn1.ColumnEdit = this.ItemTextEditn0;
            gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn1.Width = 40;
            gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });

            foreach (DevExpress.XtraGrid.Views.BandedGrid.GridBand gBand in gridView1.Bands)
            {
                if (gBand.Name == "gridBandtemp" + sColName.Substring(5))
                {
                    gBand.Columns.Add(gridColumn1);
                }
            }
        }

        private void btnAudit_Click(object sender, EventArgs e)
        {
            try
            {
                string sErr = "";

                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                int iCou = 0;
                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string s部门编码 = l部门编码.Text.Trim();
                    if (s部门编码 == "")
                    {
                        lookUpEditcDepCode.Focus();
                        throw new Exception("部门编码不能为空");
                    }

                    string s会计期间 = l会计期间.Text.Trim();
                    if (s会计期间 == "")
                    {
                        lookUpEditcDepCode.Focus();
                        throw new Exception("会计期间不能为空");
                    }


                    string sSQL = @"
select cbaccounter ,* 
from rdrecord11 a inner join rdrecords11 b on a.ID = b.ID inner join Inventory c on b.cInvCode = c.cInvCode
where a.dDate >= '111111' and a.dDate < '222222'
	and a.cDepCode = '333333'
    and a.cWhCode in ('01','02','03','04','05','06','14','19')
    and c.cInvCCode not like '8%'
	and ISNULL(cbaccounter ,'') = ''
";
                    sSQL = sSQL.Replace("111111", s会计期间 + "-01");
                    sSQL = sSQL.Replace("222222", TH.BaseClass.BaseFunction.ReturnDate(s会计期间 + "-01").AddMonths(1).ToString("yyyy-MM-dd"));
                    sSQL = sSQL.Replace("333333", s部门编码);
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        throw new Exception("当前年度，当前部门有尚未记账的出库单");
                    }

                    string s下一会计期间 = BaseFunction.ReturnDate( lookUpEdit会计期间.Text.Trim() + "-01") .AddMonths(1).ToString("yyyy-MM");


                    sSQL = @"
delete _QCMaterial where 1=1
";
                    sSQL = sSQL.Replace("1=1", "1=1 and 会计期间 = '" + s下一会计期间 + "' and 部门 = '" + s部门编码 + "'");
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        for (int j = 0; j < gridView1.Columns.Count; j++)
                        {
                            string sColName = gridView1.Columns[j].Name.Trim();
                            if (sColName.StartsWith("gridColtemp产品数量_"))
                            {
                                string sProInvCode = sColName.Substring(16);
                                int iLength = sProInvCode.LastIndexOf('_');
                                sProInvCode = sProInvCode.Substring(0, iLength);

                                decimal d单价 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol本月耗用单价), 6);

                                string sCol金额 = sColName.Replace("gridColtemp产品数量_","产品金额_");
                                decimal d产品耗用材料金额 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, sCol金额), 6);

                                sSQL = "update _ProMaterial set 审核人 = '" + sUserID + "',审核日期 = getdate(),单价 = 333333,金额 = 444444 where 1=1";
                                sSQL = sSQL.Replace("1=1", "1=1 and 会计期间 = '" + lookUpEdit会计期间.Text.Trim() + "' and 部门 = '" + s部门编码 + "' and 产品编码 = '" + sProInvCode + "' and 存货编码 = '" + gridView1.GetRowCellValue(i, gridCol材料编码).ToString().Trim() + "'");
                                sSQL = sSQL.Replace("333333", d单价.ToString());
                                sSQL = sSQL.Replace("444444", d产品耗用材料金额.ToString());

                                iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                        }

                        decimal d金额 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol月末结存金额), 6);
                        decimal d数量 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol月末结存数量), 6);

                        if (d金额 == 0)
                        {
                            continue;
                        }

                        sSQL = @"
insert into _QCMaterial(会计期间, 部门, 存货编码, 期初数量, 期初金额)
values('111111','222222','333333',444444,555555)
";
                        sSQL = sSQL.Replace("111111", s下一会计期间);
                        sSQL = sSQL.Replace("222222", s部门编码);
                        sSQL = sSQL.Replace("333333", gridView1.GetRowCellValue(i, gridCol材料编码).ToString().Trim());
                        sSQL = sSQL.Replace("444444", d数量.ToString());
                        sSQL = sSQL.Replace("555555", d金额.ToString());
                        iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        sSQL = "update _QCMaterial set 审核人 = '111111' where 会计期间 = '222222' and 部门 = '333333' ";
                        sSQL = sSQL.Replace("111111", sUserID);
                        sSQL = sSQL.Replace("222222", s会计期间);
                        sSQL = sSQL.Replace("333333", s部门编码);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        
                    }

                    sSQL = "delete _车间材料领用汇总月报 where 会计期间 = 'aaaaaa' and 部门编码 = 'bbbbbb'";
                    sSQL = sSQL.Replace("aaaaaa", s会计期间);
                    sSQL = sSQL.Replace("bbbbbb", s部门编码);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        for (int j = 0; j < gridView1.Columns.Count; j++)
                        {
                            string sColText = gridView1.Columns[j].Caption.ToString().Trim();
                            string sColName = gridView1.Columns[j].Name.ToString().Trim();
                            string sFieldName = gridView1.Columns[j].FieldName.ToString().Trim();
                            if (sColName.StartsWith("gridColtemp产品数量"))
                            {
                                string[] s产品 = sFieldName.Split('_');
                                string s产品编码 = s产品[1].ToString().Trim();

                                string sFieldName2 = sFieldName.Replace("产品数量", "产品单价");
                                string sFieldName3 = sFieldName.Replace("产品数量", "产品金额");
                                decimal d产品数量 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridView1.Columns[sFieldName]), 6);
                                decimal d产品单价 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridView1.Columns[sFieldName2]), 6);
                                decimal d产品金额 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridView1.Columns[sFieldName3]), 6);

                                if (d产品单价 == 0 && d产品数量 == 0)
                                    continue;

                                Model._车间材料领用汇总月报 mod = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._车间材料领用汇总月报();


                                mod.会计期间 = s会计期间;
                                mod.部门编码 = s部门编码;
                                mod.产品编码 = s产品编码;
                                mod.材料编码 = gridView1.GetRowCellValue(i, gridCol材料编码).ToString().Trim();
                                mod.月初存料单价 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol月初存料单价), 6);
                                mod.月初存料数量 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol月初存料数量), 6);
                                mod.月初存料金额 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol月初存料金额), 6);

                                mod.收发存汇总出库单价 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol收发存出库单价), 6);
                                mod.收发存汇总出库数量 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol收发存出库数量), 6);
                                mod.收发存汇总出库金额 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol收发存出库金额), 6);

                                mod.月末结存单价 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol月末结存单价), 6);
                                mod.月末结存数量 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol月末结存数量), 6);
                                mod.月末结存金额= BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol月末结存金额), 6);

                                mod.本月耗用单价 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol本月耗用单价), 6);
                                mod.本月耗用数量 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol本月耗用数量), 6);
                                mod.本月耗用金额 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol本月耗用金额), 6);

                                mod.产品单价 = d产品单价;
                                mod.产品数量 = d产品数量;
                                mod.产品金额 = d产品金额;

                                DAL._车间材料领用汇总月报 dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._车间材料领用汇总月报();
                                sSQL = dal.Add(mod);
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                        }
                    }

                    tran.Commit();
                    label审核.Text = "已审核";

                    MessageBox.Show("审核成功");
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox msg = new FrmMsgBox();
                msg.Text = "审核失败";
                msg.richTextBox1.Text = ee.Message;
                msg.StartPosition = FormStartPosition.CenterScreen;
                msg.ShowDialog();
            }
        }

       

        private void btnUnAudit_Click(object sender, EventArgs e)
        {
            try
            {
                string sErr = "";
   
                if (sErr.Length > 0)
                    throw new Exception(sErr);

                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                int iCou = 0;
                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string s部门编码 = l部门编码.Text.Trim();
                    if (s部门编码 == "")
                    {
                        lookUpEditcDepCode.Focus();
                        sErr = "部门编码不能为空";
                    }

                    string s会计期间 = l会计期间.Text.Trim();
                    if (s会计期间 == "")
                    {
                        lookUpEditcDepCode.Focus();
                        sErr = "会计期间不能为空";
                    }


                    //判断当前部门后续月份审核，本月禁止弃审，已经核算成本，本月不允许弃审
                    string sSQL = "select * from _ProMaterial where isnull(审核人,'') <> '' and 会计期间 > '" + lookUpEdit会计期间.Text.Trim() + "' and 部门 = '" + s部门编码 + "'";
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        sErr = "已有之后的会计期间审核，当前期间不能弃审";
                    }

                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }

                    sSQL = "select * from _ProMaterial where isnull(记账人,'') <> '' and 1=1";
                    sSQL = sSQL.Replace("1=1", "1=1 and 会计期间 = '" + lookUpEdit会计期间.Text.Trim() + "' and 部门 = '" + s部门编码 + "'");
                    DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                    {
                        throw new Exception("已经参与成本计算，不能弃审");
                    }

                    sSQL = "update _ProMaterial set 审核人 = null,审核日期 = null where 1=1";
                    sSQL = sSQL.Replace("1=1", "1=1 and 会计期间 = '" + lookUpEdit会计期间.Text.Trim() + "' and 部门 = '" + s部门编码 + "'");

                    iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    string s下一会计期间 = BaseFunction.ReturnDate(lookUpEdit会计期间.Text.Trim() + "-01").AddMonths(1).ToString("yyyy-MM");
                    sSQL = @"
delete _QCMaterial where 1=1
";
                    sSQL = sSQL.Replace("1=1", "1=1 and 会计期间 = '" + s下一会计期间 + "' and 部门 = '" + s部门编码 + "'");
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = "update _QCMaterial set 审核人 = null where 会计期间 = '222222' and 部门 = '333333' ";
                    sSQL = sSQL.Replace("222222", s会计期间);
                    sSQL = sSQL.Replace("333333", s部门编码);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = "delete _车间材料领用汇总月报 where 会计期间 = 'aaaaaa' and 部门编码 = 'bbbbbb'";
                    sSQL = sSQL.Replace("aaaaaa", s会计期间);
                    sSQL = sSQL.Replace("bbbbbb", s部门编码);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    tran.Commit();

                    MessageBox.Show("弃审成功");
                    label审核.Text = "";
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox msg = new FrmMsgBox();
                msg.Text = "弃审失败";
                msg.richTextBox1.Text = ee.Message;
                msg.StartPosition = FormStartPosition.CenterScreen;
                msg.ShowDialog();
            }
        }

        private void btnExcel_Click_1(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                }
                catch { }

                SaveFileDialog sa = new SaveFileDialog();
                sa.Filter = "Excel文件2003|*.xls";
                sa.FileName = "费用分配";

                sa.ShowDialog();
                string sPath = sa.FileName;

                if (sPath.Trim() != string.Empty)
                {
                    gridView1.ExportToXls(sPath);
                    MessageBox.Show("导出列表成功！\n路径：" + sPath);
                }
            }
            catch (Exception ee)
            {
                throw new Exception("导出列表失败：" + ee.Message);
            }
        }
    }
}
