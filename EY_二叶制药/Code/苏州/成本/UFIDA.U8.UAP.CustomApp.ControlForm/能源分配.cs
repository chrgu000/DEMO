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
    public partial class 能源分配 : UserControl
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
                lAudit.Text = "";
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

        public 能源分配()
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

        private void SetLookUp()
        {
           string sSQL = "select distinct 会计期间 from  _ProMaterial order by 会计期间";
           DataTable dt = DbHelperSQL.Query(sSQL);
            if (dt == null || dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();
                dr["会计期间"] = DateTime.Today.AddMonths(-2).ToString("yyyy-MM");
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["会计期间"] = DateTime.Today.AddMonths(-1).ToString("yyyy-MM");
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["会计期间"] = DateTime.Today.ToString("yyyy-MM");
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["会计期间"] = DateTime.Today.AddMonths(1).ToString("yyyy-MM");
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["会计期间"] = DateTime.Today.AddMonths(2).ToString("yyyy-MM");
                dt.Rows.Add(dr);
            }
            else
            {
                DateTime sMax会计期间 = BaseFunction.ReturnDate(dt.Rows[dt.Rows.Count - 1]["会计期间"].ToString().Trim() + "-01");
                DateTime dNow = BaseFunction.ReturnDate(DateTime.Today.ToString("yyyy-MM") + "-01");

                while (sMax会计期间 < dNow.AddMonths(2))
                {
                    sMax会计期间 = sMax会计期间.AddMonths(1);
                    DataRow dr = dt.NewRow();
                    dr["会计期间"] = sMax会计期间.ToString("yyyy-MM");
                    dt.Rows.Add(dr);
                }
            }

            lookUpEdit会计期间.Properties.DataSource = dt;
            lookUpEdit会计期间.EditValue = DateTime.Today.ToString("yyyy-MM");
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

                string sErr = "";
                int iCou = 0;
                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {

                    string s会计期间 = lookUpEdit会计期间.EditValue.ToString().Trim();
                    if (s会计期间 == "")
                    {
                        lookUpEdit会计期间.Focus();
                        throw new Exception("会计期间不能为空");
                    }


                    string sSQL = "select count(1) from _能源分配 where 会计期间 = '111111' and isnull(审核人,'') <> ''";
                    sSQL = sSQL.Replace("111111", s会计期间);
                    int iCount = BaseFunction.ReturnInt(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                    if (iCount > 0)
                        throw new Exception("已经审核不能删除");

                    sSQL = "delete _能源分配 where  会计期间 = '111111'";
                    sSQL = sSQL.Replace("111111", s会计期间);
                    iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    tran.Commit();

                    GetGrid();

                    if (iCou > 0)
                    {
                        MessageBox.Show("删除成功");
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

                if (gridView1.RowCount <= 0)
                {
                    throw new Exception("请设置数据后处理");
                }

                if (BaseFunction.ReturnDecimal(txt供电.Text.Trim()) != BaseFunction.ReturnDecimal(gridView1.Columns["供电金额"].SummaryItem.SummaryValue)
                    || BaseFunction.ReturnDecimal(txt供汽.Text.Trim()) != BaseFunction.ReturnDecimal(gridView1.Columns["供汽金额"].SummaryItem.SummaryValue)
                    || BaseFunction.ReturnDecimal(txt供水.Text.Trim()) != BaseFunction.ReturnDecimal(gridView1.Columns["供水金额"].SummaryItem.SummaryValue)
                    || BaseFunction.ReturnDecimal(txt开利机组冷水机组.Text.Trim()) != BaseFunction.ReturnDecimal(gridView1.Columns["开利机组冷水机组金额"].SummaryItem.SummaryValue)
                    )
                    throw new Exception("请重新计算后保存");



                if (100 != BaseFunction.ReturnDecimal(gridView1.Columns["供水分配率"].SummaryItem.SummaryValue)
                    && BaseFunction.ReturnDecimal(gridView1.Columns["供水分配率"].SummaryItem.SummaryValue) !=0)
                    throw new Exception("供水分配率设置不正确");

                if (100 != BaseFunction.ReturnDecimal(gridView1.Columns["供电分配率"].SummaryItem.SummaryValue)
                    && BaseFunction.ReturnDecimal(gridView1.Columns["供电分配率"].SummaryItem.SummaryValue) != 0)
                    throw new Exception("供电分配率设置不正确");

                if (100 != BaseFunction.ReturnDecimal(gridView1.Columns["供汽分配率"].SummaryItem.SummaryValue)
                    && BaseFunction.ReturnDecimal(gridView1.Columns["供汽分配率"].SummaryItem.SummaryValue) != 0)
                    throw new Exception("供汽分配率设置不正确");

                if (100 != BaseFunction.ReturnDecimal(gridView1.Columns["开利机组冷水机组分配率"].SummaryItem.SummaryValue)
                    && BaseFunction.ReturnDecimal(gridView1.Columns["开利机组冷水机组分配率"].SummaryItem.SummaryValue) != 0)
                    throw new Exception("开利机组冷水机组分配率设置不正确");

                string sErr = "";
                int iCou = 0;
                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string s会计期间 = lookUpEdit会计期间.EditValue.ToString().Trim();
                    if (s会计期间 == "")
                    {
                        lookUpEdit会计期间.Focus();
                        throw new Exception("会计期间不能为空");
                    }

                    string sSQL = "select count(1) from _能源分配 where 会计期间 = '111111' and isnull(审核人,'') <> ''";
                    sSQL = sSQL.Replace("111111", s会计期间);
                    int iCount = BaseFunction.ReturnInt(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                    if (iCount > 0)
                        throw new Exception("已经审核不能修改");

                    sSQL = "delete _能源分配 where 会计期间 = '111111'";
                    sSQL = sSQL.Replace("111111", s会计期间);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        Model._能源分配 model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._能源分配();
                        model.部门编码 = gridView1.GetRowCellValue(i, gridCol部门编码).ToString().Trim();
                        model.供电分配率 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol供电分配率), 2);
                        model.供电金额 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol供电金额), 2);
                        model.供水分配率 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol供水分配率), 2);
                        model.供水金额 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol供水金额), 2);
                        model.供汽分配率 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol供汽分配率), 2);
                        model.供汽金额 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol供汽金额), 2);
                        model.开利机组冷水机组分配率 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol开利机组冷水机组分配率), 2);
                        model.开利机组冷水机组金额 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol开利机组冷水机组金额), 2);
                        model.合计 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol合计), 2);
                        model.会计期间 = s会计期间;

                        model.制单人 = sUserName;
                        model.制单日期 = DateTime.Now;

                        DAL._能源分配 dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._能源分配();
                        sSQL = dal.Add(model);

                        iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    tran.Commit();

                    GetGrid();

                    if (iCou > 0)
                    {
                        MessageBox.Show("保存成功");
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


        private void GetGrid()
        {
            try
            {
                SetEnable(true);
                lAudit.Text = "";
                if (lookUpEdit会计期间.EditValue == null || lookUpEdit会计期间.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("请选择会计期间");
                }

                string sSQL = @"
select count(1) from dbo._能源分配 where 会计期间 = '111111'
";
                sSQL = sSQL.Replace("111111", lookUpEdit会计期间.EditValue.ToString());
                int iCou = BaseFunction.ReturnInt(DbHelperSQL.GetSingle(sSQL));
                if (iCou > 0)
                {
                    sSQL = @"
select b.cDepName as 部门,a.*,b.cDepCode
from _能源分配 a right join department b on b.cDepCode = a.部门编码 and a.会计期间 = '111111'
where b.bDepEnd = 1 and b.cDepName  not like '%停用%' and isnull(cDepNameEn,'') like '%NY%'
order by a.部门编码
";
                    sSQL = sSQL.Replace("111111", lookUpEdit会计期间.EditValue.ToString());
                    DataTable dt = DbHelperSQL.Query(sSQL);
                    gridControl1.DataSource = dt;

                    if (dt.Rows[0]["审核人"].ToString().Trim() != "")
                    {
                        lAudit.Text = "已审核";

                        SetEnable(false);
                    }

                    txt供电.Text = gridView1.Columns["供电金额"].SummaryItem.SummaryValue.ToString().Trim();
                    txt供水.Text = gridView1.Columns["供水金额"].SummaryItem.SummaryValue.ToString().Trim();
                    txt供汽.Text = gridView1.Columns["供汽金额"].SummaryItem.SummaryValue.ToString().Trim();
                    txt开利机组冷水机组.Text = gridView1.Columns["开利机组冷水机组金额"].SummaryItem.SummaryValue.ToString().Trim();
                }
                else
                {
                    sSQL = @"
select a.cDepName as 部门,a.cDepCode as 部门编码,a.cDepCode
    ,会计期间,供水分配率, 供水金额, 供电分配率, 供电金额, 供汽分配率, 供汽金额, 开利机组冷水机组分配率, 开利机组冷水机组金额, 合计 
    ,制单人, 制单日期, 审核人, 审核日期, 记账人, 记账日期
from department a left join dbo._能源分配 b on a.cDepCode = b.部门编码 and 会计期间 = '111111'
where isnull(a.bDepEnd,0) = 1 and a.cDepName  not like '%停用%'and isnull(cDepNameEn,'') like '%NY%'
order by a.cDepCode
";
                    sSQL = sSQL.Replace("111111", lookUpEdit会计期间.EditValue.ToString());
                    DataTable dt = DbHelperSQL.Query(sSQL);
                    gridControl1.DataSource = dt;

                    txt供电.Text = null;
                    txt供水.Text = null;
                    txt供汽.Text = null;
                    txt开利机组冷水机组.Text = null;
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        private void lookUpEditCostType_EditValueChanged(object sender, EventArgs e)
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

        private void btnAudit_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                string sErr = "";
                int iCou = 0;
                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {

                    string s会计期间 = lookUpEdit会计期间.EditValue.ToString().Trim();
                    if (s会计期间 == "")
                    {
                        lookUpEdit会计期间.Focus();
                        throw new Exception("会计期间不能为空");
                    }


                    string sSQL = "select count(1) from _能源分配 where 会计期间 = '111111' and isnull(审核人,'') <> ''";
                    sSQL = sSQL.Replace("111111", s会计期间);
                    int iCount = BaseFunction.ReturnInt(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                    if (iCount > 0)
                        throw new Exception("已经审核");

                    sSQL = "update _能源分配 set 审核人 = '" + sUserName + "' ,审核日期 = getdate() where 会计期间 = '111111'";
                    sSQL = sSQL.Replace("111111", s会计期间);
                    iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    tran.Commit();

                    GetGrid();

                    if (iCou > 0)
                    {
                        MessageBox.Show("审核成功");
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
                f.Text = "删除失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void btnUnAudit_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                string sErr = "";
                int iCou = 0;
                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {

                    string s会计期间 = lookUpEdit会计期间.EditValue.ToString().Trim();
                    if (s会计期间 == "")
                    {
                        lookUpEdit会计期间.Focus();
                        throw new Exception("会计期间不能为空");
                    }


                    string sSQL = "select count(1) from _能源分配 where 会计期间 = '111111' and isnull(审核人,'') = ''";
                    sSQL = sSQL.Replace("111111", s会计期间);
                    int iCount = BaseFunction.ReturnInt(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                    if (iCount > 0)
                        throw new Exception("尚未审核");

                    sSQL = "select count(1) from _能源分配 where 会计期间 = '111111' and isnull(记账人,'') <> ''";
                    sSQL = sSQL.Replace("111111", s会计期间);
                    iCount = BaseFunction.ReturnInt(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                    if (iCount > 0)
                        throw new Exception("已经记账");

                    sSQL = "update _能源分配 set 审核人 = null ,审核日期 = null where 会计期间 = '111111'";
                    sSQL = sSQL.Replace("111111", s会计期间);
                    iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    tran.Commit();

                    GetGrid();

                    if (iCou > 0)
                    {
                        MessageBox.Show("弃审成功");
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
                f.Text = "删除失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void btn计算_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle+=1;
                    gridView1.FocusedRowHandle-=1;
                }
                catch{}

                string sErr = "";

                #region 供水
                decimal d供水 = BaseFunction.ReturnDecimal(txt供水.Text.Trim());
    
                if (d供水 > 0)
                {
                    decimal d累计供水比例 = BaseFunction.ReturnDecimal(gridView1.Columns["供水分配率"].SummaryItem.SummaryValue);
                    if (d累计供水比例 == 100)
                    {
                        decimal d累计供水 = BaseFunction.ReturnDecimal(gridView1.Columns["供水金额"].SummaryItem.SummaryValue);
                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            decimal d比例 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol供水分配率), 4);
                            if (d比例 < 0)
                            {
                                sErr = sErr + "行 " + (i + 1).ToString() + "供水比例不能小于0\n";
                                continue;
                            }

                            d累计供水比例 = d累计供水比例 + d比例;

                            decimal d金额 = d供水 * d比例 / 100;

                            gridView1.SetRowCellValue(i, gridCol供水金额, BaseFunction.ReturnDecimal(d金额, 2).ToString().Trim());
                        }
                    }
                    else
                    {
                        sErr = sErr + "供水分配率必须是100\n";
                    }
                }
                #endregion

                #region 供电
                decimal d供电 = BaseFunction.ReturnDecimal(txt供电.Text.Trim());

                if (d供电 > 0)
                {
                    decimal d累计供电比例 = BaseFunction.ReturnDecimal(gridView1.Columns["供电分配率"].SummaryItem.SummaryValue);
                    if (d累计供电比例 == 100)
                    {
                        decimal d累计供电 = BaseFunction.ReturnDecimal(gridView1.Columns["供电金额"].SummaryItem.SummaryValue);
                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            decimal d比例 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol供电分配率), 4);
                            if (d比例 < 0)
                            {
                                sErr = sErr + "行 " + (i + 1).ToString() + "供电比例不能小于0\n";
                                continue;
                            }

                            d累计供电比例 = d累计供电比例 + d比例;

                            decimal d金额 = d供电 * d比例 / 100;

                            gridView1.SetRowCellValue(i, gridCol供电金额, BaseFunction.ReturnDecimal(d金额, 2).ToString().Trim());
                        }
                    }
                    else
                    {
                        sErr = sErr + "供电分配率必须是100\n";
                    }
                }
                #endregion

                #region 供汽
                decimal d供汽 = BaseFunction.ReturnDecimal(txt供汽.Text.Trim());

                if (d供汽 > 0)
                {
                    decimal d累计供汽比例 = BaseFunction.ReturnDecimal(gridView1.Columns["供汽分配率"].SummaryItem.SummaryValue);
                    if (d累计供汽比例 == 100)
                    {
                        decimal d累计供汽 = BaseFunction.ReturnDecimal(gridView1.Columns["供汽金额"].SummaryItem.SummaryValue);
                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            decimal d比例 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol供汽分配率), 4);
                            if (d比例 < 0)
                            {
                                sErr = sErr + "行 " + (i + 1).ToString() + "供汽比例不能小于0\n";
                                continue;
                            }

                            d累计供汽比例 = d累计供汽比例 + d比例;

                            decimal d金额 = d供汽 * d比例 / 100;

                            gridView1.SetRowCellValue(i, gridCol供汽金额, BaseFunction.ReturnDecimal(d金额, 2).ToString().Trim());
                        }
                    }
                    else
                    {
                        sErr = sErr + "供汽分配率必须是100\n";
                    }
                }
                #endregion

                #region 开利机组冷水机组
                decimal d开利机组冷水机组 = BaseFunction.ReturnDecimal(txt开利机组冷水机组.Text.Trim());

                if (d开利机组冷水机组 > 0)
                {
                    decimal d累计开利机组冷水机组比例 = BaseFunction.ReturnDecimal(gridView1.Columns["开利机组冷水机组分配率"].SummaryItem.SummaryValue);
                    if (d累计开利机组冷水机组比例 == 100)
                    {
                        decimal d累计开利机组冷水机组 = BaseFunction.ReturnDecimal(gridView1.Columns["开利机组冷水机组金额"].SummaryItem.SummaryValue);
                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            decimal d比例 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol开利机组冷水机组分配率), 4);
                            if (d比例 < 0)
                            {
                                sErr = sErr + "行 " + (i + 1).ToString() + "开利机组冷水机组比例不能小于0\n";
                                continue;
                            }

                            d累计开利机组冷水机组比例 = d累计开利机组冷水机组比例 + d比例;

                            decimal d金额 = d开利机组冷水机组 * d比例 / 100;

                            gridView1.SetRowCellValue(i, gridCol开利机组冷水机组金额, BaseFunction.ReturnDecimal(d金额, 2).ToString().Trim());
                        }
                    }
                    else
                    {
                        sErr = sErr + "开利机组冷水机组分配率必须是100\n";
                    }
                }
                #endregion

                if (sErr.Length > 0)
                {
                    throw new Exception(sErr);
                }
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btn刷新_Click(object sender, EventArgs e)
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

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column != gridCol合计)
                {
                    decimal d供水 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol供水金额));
                    decimal d供电 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol供电金额));
                    decimal d供汽 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol供汽金额));
                    decimal 开利机组冷水机组水 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol开利机组冷水机组金额));
                    gridView1.SetRowCellValue(e.RowHandle, gridCol合计, d供水 + d供电 + d供汽 + 开利机组冷水机组水);
                }

            }
            catch { }
        }

        private void lookUpEdit会计期间_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetGrid();
            }
            catch { }
        }

        private void SetEnable(bool b)
        {
            btnDel.Enabled = b;
            btn计算.Enabled = b;
            btnSave.Enabled = b;

            btnAudit.Enabled = b;
            btnUnAudit.Enabled = !b;

            txt供电.Enabled = b;
            txt供汽.Enabled = b;
            txt供水.Enabled = b;
            txt开利机组冷水机组.Enabled = b;

            gridView1.OptionsBehavior.Editable = b;
        }

        private void btnExcel_Click(object sender, EventArgs e)
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
