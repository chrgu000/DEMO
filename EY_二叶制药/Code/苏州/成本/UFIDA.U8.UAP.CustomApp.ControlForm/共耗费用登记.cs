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
    public partial class 共耗费用登记 : UserControl
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

        public 共耗费用登记()
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


                    string sSQL = "select count(1) from _共耗费用登记 where 会计期间 = '111111' and isnull(审核人,'') <> ''";
                    sSQL = sSQL.Replace("111111", s会计期间);
                    int iCount = BaseFunction.ReturnInt(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                    if (iCount > 0)
                        throw new Exception("已经审核不能删除");

                    sSQL = "delete _共耗费用登记 where  会计期间 = '111111'";
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


                    string sSQL = "select count(1) from _共耗费用登记 where 会计期间 = '111111' and isnull(审核人,'') <> ''";
                    sSQL = sSQL.Replace("111111", s会计期间);
                    int iCount = BaseFunction.ReturnInt(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                    if (iCount > 0)
                        throw new Exception("已经审核不能修改");

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        decimal d金额 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol金额), 2);
                        if (d金额 < 0)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "金额不能小于0\n";
                            continue;
                        }

                        Model._共耗费用登记 model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._共耗费用登记();
                        model.备注 = gridView1.GetRowCellValue(i, gridCol备注).ToString().Trim();
                        model.费用类型 = gridView1.GetRowCellValue(i, gridCol费用类型).ToString().Trim();
                        model.会计期间 = lookUpEdit会计期间.EditValue.ToString().Trim();
                        model.金额 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol金额), 2);

                        DAL._共耗费用登记 dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._共耗费用登记();

                        sSQL = "select * from _共耗费用登记 where 会计期间 = '111111' and isnull(费用类型,'') = '" + gridView1.GetRowCellValue(i,gridCol费用类型).ToString().Trim() + "'";
                        sSQL = sSQL.Replace("111111", s会计期间);
                        DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt == null || dt.Rows.Count == 0)
                        {
                            model.制单人 = sUserName;
                            model.制单日期 = DateTime.Now;
                            sSQL = dal.Add(model);
                        }
                        else
                        {
                            model.制单人 = gridView1.GetRowCellValue(i, gridCol制单人).ToString().Trim();
                            model.制单日期 = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridCol制单日期));
                            model.修改人 = sUserName;
                            model.修改日期 = DateTime.Now;
                            sSQL = dal.Update(model);
                        }
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
                if (lookUpEdit会计期间.EditValue == null || lookUpEdit会计期间.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("请选择会计期间");
                }

                string sSQL = "select * from _共耗费用登记 where 会计期间 = '111111' and isnull(审核人,'') <> ''";
                sSQL = sSQL.Replace("111111", lookUpEdit会计期间.EditValue.ToString());
                DataTable dt = DbHelperSQL.Query(sSQL);
                int iCou = dt.Rows.Count;

                if (iCou == 0)
                {
                    sSQL = @"
select a.sType as 费用类型, b.会计期间, b.金额, b.备注, b.制单人, b.制单日期, b.审核人, b.审核日期,b.修改人,b.修改日期,b.记账人,b.记账日期
from dbo._CostType a left join dbo._共耗费用登记 b on a.sType = b.费用类型 and b.会计期间 = '111111'
where a.iType = 1
order by b.费用类型
";
                }
                else
                { 
                    sSQL = @"
                    select b.费用类型, b.会计期间, b.金额, b.备注, b.制单人, b.制单日期, b.审核人, b.审核日期,b.修改人,b.修改日期,b.记账人,b.记账日期
from _共耗费用登记 b
where b.会计期间 = '111111'
order by b.费用类型
";
                }

                sSQL = sSQL.Replace("111111", lookUpEdit会计期间.EditValue.ToString());
                dt = DbHelperSQL.Query(sSQL);
                gridControl1.DataSource = dt;
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

                    string sSQL = "select count(1) from _共耗费用登记 where 会计期间 = '111111'";
                    sSQL = sSQL.Replace("111111", s会计期间);
                    int iCount = BaseFunction.ReturnInt(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                    if (iCount == 0)
                        throw new Exception("请先保存数据");

                    sSQL = "select count(1) from _共耗费用登记 where 会计期间 = '111111' and isnull(记账人,'') <> ''";
                    sSQL = sSQL.Replace("111111", s会计期间);
                    iCount = BaseFunction.ReturnInt(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                    if (iCount > 0)
                        throw new Exception("已经记账");

                    sSQL = "select count(1) from _共耗费用登记 where 会计期间 = '111111' and isnull(审核人,'') <> ''";
                    sSQL = sSQL.Replace("111111", s会计期间);
                    iCount = BaseFunction.ReturnInt(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                    if (iCount > 0)
                        throw new Exception("已经审核");

                    sSQL = "update _共耗费用登记 set 审核人 = '" + sUserName + "',审核日期 = getdate() where  会计期间 = '111111'";

                    sSQL = sSQL.Replace("111111", s会计期间);
                    iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                 

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
                f.Text = "审核失败";
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

                    string sSQL = "select count(1) from _共耗费用登记 where 会计期间 = '111111'";
                    sSQL = sSQL.Replace("111111", s会计期间);
                    int iCount = BaseFunction.ReturnInt(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                    if (iCount == 0)
                        throw new Exception("请先保存数据");


                    sSQL = "select count(1) from _共耗费用登记 where 会计期间 = '111111' and isnull(记账人,'') <> ''";
                    sSQL = sSQL.Replace("111111", s会计期间);
                    iCount = BaseFunction.ReturnInt(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                    if (iCount > 0)
                        throw new Exception("已经记账");


                    sSQL = "select count(1) from _共耗费用登记 where 会计期间 = '111111' and isnull(审核人,'') <> ''";
                    sSQL = sSQL.Replace("111111", s会计期间);
                    iCount = BaseFunction.ReturnInt(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                    if (iCount == 0)
                        throw new Exception("尚未审核不能弃审");

                    sSQL = "update _共耗费用登记 set 审核人 =null,审核日期 = null where  会计期间 = '111111'";

                    sSQL = sSQL.Replace("111111", s会计期间);
                    iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


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
                f.Text = "弃审失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }





    }
}
