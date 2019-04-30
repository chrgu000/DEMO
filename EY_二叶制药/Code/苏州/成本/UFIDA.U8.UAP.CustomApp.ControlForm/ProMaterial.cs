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
    public partial class ProMaterial : UserControl
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
                //SetBtnEnable(true);

                GetLookUp();

                SetNull();
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        public ProMaterial()
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
            string sSQL = @"
select a.cInvCode,a.cInvName,a.cInvStd,a.cCurrencyName ,b.cComUnitName 
from Inventory a left join ComputationUnit b on a.cComunitCode = b.cComunitCode 
order by a.cInvCode
";

            DataTable dt = DbHelperSQL.Query(sSQL);
            lookUpEditcInvName.Properties.DataSource = dt;
            lookUpEditcInvStd.Properties.DataSource = dt;
            lookUpEditcCurrencyName.Properties.DataSource = dt;
            ItemLookUpEditcCurrencyName.DataSource = dt;
            ItemLookUpEditcInvName.DataSource = dt;
            ItemLookUpEditcInvStd.DataSource = dt;
            ItemLookUpEditcComUnitName.DataSource = dt;


            sSQL = "select cDepCode,cDepName from Department where isnull(bDepEnd ,0) <> 0  and isnull(cDepProp,'') = '成本' order by cDepCode";
            dt = DbHelperSQL.Query(sSQL);
            lookUpEditcDepName.Properties.DataSource = dt;
            lookUpEditcDepCode.Properties.DataSource = dt;

            sSQL = "select distinct 会计期间 from  _ProMaterial order by 会计期间";
            dt = DbHelperSQL.Query(sSQL);
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
                DateTime sMax会计期间 =BaseFunction.ReturnDate( dt.Rows[dt.Rows.Count - 1]["会计期间"].ToString().Trim() + "-01");
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

        private void lookUpEditcInvName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                btnTxtInvCode.Text = lookUpEditcInvName.EditValue.ToString().Trim();
                lookUpEditcCurrencyName.EditValue = lookUpEditcInvName.EditValue;
                lookUpEditcInvStd.EditValue = lookUpEditcInvName.EditValue;
            }
            catch { }
        }

        private void lookUpEditcInvStd_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                btnTxtInvCode.Text = lookUpEditcInvName.EditValue.ToString().Trim();
                lookUpEditcCurrencyName.EditValue = lookUpEditcInvStd.EditValue;
                lookUpEditcInvName.EditValue = lookUpEditcInvStd.EditValue;
            }
            catch { }
        }

        private void lookUpEditcCurrencyName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                btnTxtInvCode.Text = lookUpEditcInvName.EditValue.ToString().Trim();
                lookUpEditcInvStd.EditValue = lookUpEditcCurrencyName.EditValue;
                lookUpEditcInvName.EditValue = lookUpEditcCurrencyName.EditValue;
            }
            catch { }
        }

        private void lookUpEditcDepCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEditcDepName.EditValue = lookUpEditcDepCode.EditValue;

                if (lookUpEditcDepCode.EditValue != null && (lookUpEditcDepCode.EditValue.ToString().Trim() == "0803" || lookUpEditcDepCode.EditValue.ToString().Trim() == "0808"))
                {
                    label15.Visible = true;
                    label14.Visible = true;

                    txtDGUTime.Visible = true;
                    txtDGTime.Visible = true;
                }
                else
                {
                    label15.Visible = false;
                    label14.Visible = false;

                    txtDGUTime.Visible = false;
                    txtDGTime.Visible = false;
                }

                if (lookUpEditcDepCode.EditValue != null && lookUpEditcDepName.EditValue != null && lookUpEditcInvName.EditValue != null && lookUpEditcInvName.EditValue != null && lookUpEdit会计期间.EditValue != null)
                {
                    GetGrid();
                }
            }
            catch { }
        }

        private void lookUpEditcDepName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEditcDepCode.EditValue = lookUpEditcDepName.EditValue;
            }
            catch { }
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

                DialogResult d = MessageBox.Show("确定删除当前单据？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (d != DialogResult.Yes)
                {
                    return;
                }

                int iCou = 0;
                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string s部门编码 = lookUpEditcDepCode.Text.Trim();
                    if (s部门编码 == "")
                    {
                        lookUpEditcDepCode.Focus();
                        throw new Exception("部门编码不能为空");
                    }

                    string s产品编码 = lookUpEditcInvName.EditValue.ToString().Trim();
                    if (s产品编码 == "")
                    {
                        lookUpEditcDepCode.Focus();
                        throw new Exception("产品编码不能为空");
                    }

                    string s产品名称 = lookUpEditcInvName.Text.Trim();
                    if (s产品名称 == "")
                    {
                        lookUpEditcDepCode.Focus();
                        throw new Exception("产品名称不能为空");
                    }

                    string s会计期间 = lookUpEdit会计期间.Text.Trim();
                    if (s会计期间 == "")
                    {
                        lookUpEditcDepCode.Focus();
                        throw new Exception("会计期间不能为空");
                    }


                    string sSQL = @"
select * 
from    _ProMaterial
where 1=1
ORDER BY iID
";
                    sSQL = sSQL.Replace("1=1", "1=1 and 会计期间 = '" + lookUpEdit会计期间.Text.Trim() + "' and 部门 = '" + s部门编码 + "' and 产品编码 = '" + s产品编码 + "' ");
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        throw new Exception("获得数据失败");
                    }

                    if (dt.Rows[0]["审核人"].ToString().Trim() != "")
                    {
                        throw new Exception("已经审核不能删除");
                    }

                    Model._ProMaterial model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._ProMaterial();
                    model.部门 = lookUpEditcDepCode.EditValue.ToString().Trim();
                    model.产品编码 = lookUpEditcInvName.EditValue.ToString().Trim();
                    model.会计期间 = lookUpEdit会计期间.EditValue.ToString().Trim();

                    UFIDA.U8.UAP.CustomApp.ControlForm.DAL._ProMaterial DAL = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._ProMaterial();
                    sSQL = DAL.Delete(model);
                    iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    tran.Commit();

                    MessageBox.Show("删除成功");

                    GetGrid();
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
                    string s部门编码 = lookUpEditcDepCode.Text.Trim();
                    if (s部门编码 == "")
                    {
                        lookUpEditcDepCode.Focus();
                        throw new Exception("部门编码不能为空");
                    }

                    string s产品编码 = lookUpEditcInvName.Text.Trim();
                    if (s产品编码 == "")
                    {
                        lookUpEditcDepCode.Focus();
                        throw new Exception("产品编码不能为空");
                    }

                    string s会计期间 = lookUpEdit会计期间.Text.Trim();
                    if (s会计期间 == "")
                    {
                        lookUpEditcDepCode.Focus();
                        throw new Exception("会计期间不能为空");
                    }

                    if (txtWorkTime.Text.Trim() == "")
                    {
                        txtWorkTime.Focus();
                        throw new Exception("产品工时不能为空");
                    }

                    decimal d工时 = BaseFunction.ReturnDecimal(txtWorkTime.Text.Trim());
                    if (d工时 < 0)
                    {
                        txtWorkTime.Focus();
                        throw new Exception("产品工时不能小于0");
                    }


                    string sSQL = @"
select * 
from    _ProMaterial
where 1=1
ORDER BY iID
";
                    sSQL = sSQL.Replace("1=1", "1=1 and 会计期间 = '" + lookUpEdit会计期间.Text.Trim() + "' and 部门 = '" + s部门编码 + "' and 产品编码 = '" + s产品编码 + "' ");
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt == null)
                    {
                        throw new Exception("获得数据失败");
                    }

                    if (dt.Rows.Count > 0 && dt.Rows[0]["审核人"].ToString().Trim() != "")
                    {
                        throw new Exception("已经审核不能修改");
                    }

                    Model._ProMaterial model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._ProMaterial();
                    model.部门 = lookUpEditcDepCode.EditValue.ToString().Trim();

                    string sInvCode = lookUpEditcInvName.EditValue.ToString().Trim();
                    sSQL = "select * from Inventory where cInvCode = '" + sInvCode + "'";
                    DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp == null || dtTemp.Rows.Count != 1)
                    {
                        sErr = sErr + " 产品存货编码不存在";
                    }
                    model.产品编码 = sInvCode;
                    model.会计期间 = lookUpEdit会计期间.EditValue.ToString().Trim();

                    UFIDA.U8.UAP.CustomApp.ControlForm.DAL._ProMaterial DAL = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._ProMaterial();
                    sSQL = DAL.Delete(model);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    bool b子件已登记 = false;
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (gridView1.GetRowCellValue(i, gridColcInvCode).ToString().Trim() == "")
                        {
                            continue;
                        }

                        model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._ProMaterial();
                        model.部门 = lookUpEditcDepCode.EditValue.ToString().Trim();
                        model.产品编码 = lookUpEditcInvName.EditValue.ToString().Trim();
                        model.会计期间 = lookUpEdit会计期间.EditValue.ToString().Trim();
                        model.工时 = BaseFunction.ReturnDecimal(txtWorkTime.Text.Trim(), 1);
                        model.未完工工时 = BaseFunction.ReturnDecimal(txtWorkTimeUn.Text.Trim(), 1);
                        model.冻干完工工时 = BaseFunction.ReturnDecimal(txtDGTime.Text.Trim(), 1);
                        model.冻干未完工工时 = BaseFunction.ReturnDecimal(txtDGUTime.Text.Trim(), 1);

                        string scInvCode = gridView1.GetRowCellValue(i, gridColcInvCode).ToString().Trim();
                        sSQL = "select * from Inventory where cInvCode = '" + scInvCode + "'";
                        dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtTemp == null || dtTemp.Rows.Count != 1)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + " 存货编码不存在";
                        }

                        model.存货编码 = scInvCode;
                        model.数量 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol数量), 6);
                        if (model.数量 == 0)
                        {
                            continue;
                        }

                        b子件已登记 = true;

                        model.制单人 = sUserID;
                        model.制单日期 = DateTime.Now;

                        sSQL = DAL.Add(model);
                        iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    }

                    if (!b子件已登记)
                    {
                        sErr = sErr + "数量必须不为0\n";
                    }

                    if (sErr != "")
                    {
                        throw new Exception(sErr);
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

        private void btnAudit_Click(object sender, EventArgs e)
        {
//            try
//            {
//                try
//                {
//                    gridView1.FocusedRowHandle -= 1;
//                    gridView1.FocusedRowHandle += 1;
//                }
//                catch { }

//                int iCou = 0;
//                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
//                conn.Open();
//                //启用事务
//                SqlTransaction tran = conn.BeginTransaction();
//                try
//                {
//                    string s部门编码 = lookUpEditcDepCode.Text.Trim();
//                    if (s部门编码 == "")
//                    {
//                        lookUpEditcDepCode.Focus();
//                        throw new Exception("部门编码不能为空");
//                    }

//                    string s产品编码 = lookUpEditcInvCode.Text.Trim();
//                    if (s产品编码 == "")
//                    {
//                        lookUpEditcDepCode.Focus();
//                        throw new Exception("产品编码不能为空");
//                    }

//                    string s会计期间 = lookUpEdit会计期间.Text.Trim();
//                    if (s会计期间 == "")
//                    {
//                        lookUpEditcDepCode.Focus();
//                        throw new Exception("会计期间不能为空");
//                    }


//                    string sSQL = @"
//select * 
//from    _ProMaterial
//where 1=1
//ORDER BY iID
//";
//                    sSQL = sSQL.Replace("1=1", "1=1 and 会计期间 = '" + lookUpEdit会计期间.Text.Trim() + "' and 部门 = '" + s部门编码 + "' and 产品编码 = '" + s产品编码 + "' ");
//                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
//                    if (dt == null || dt.Rows.Count == 0)
//                    {
//                        throw new Exception("获得数据失败");
//                    }

//                    if (dt.Rows[0]["审核人"].ToString().Trim() != "")
//                    {
//                        throw new Exception("已经审核");
//                    }

//                    Model._ProMaterial model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._ProMaterial();
//                    model.部门 = lookUpEditcDepCode.EditValue.ToString().Trim();
//                    model.产品编码 = lookUpEditcInvCode.EditValue.ToString().Trim();
//                    model.会计期间 = lookUpEdit会计期间.EditValue.ToString().Trim();

//                    UFIDA.U8.UAP.CustomApp.ControlForm.DAL._ProMaterial DAL = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._ProMaterial();
//                    sSQL = "update _ProMaterial set 审核人 = '" + sUserID + "',审核日期 = getdate() where 1=1";
//                    sSQL = sSQL.Replace("1=1", "1=1 and 会计期间 = '" + lookUpEdit会计期间.Text.Trim() + "' and 部门 = '" + s部门编码 + "' and 产品编码 = '" + s产品编码 + "' ");

//                    iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
//                    tran.Commit();

//                    GetGrid();
//                }
//                catch (Exception error)
//                {
//                    tran.Rollback();
//                    throw new Exception(error.Message);
//                }
//            }
//            catch (Exception ee)
//            {
//                FrmMsgBox f = new FrmMsgBox();
//                f.Text = "审核失败";
//                f.richTextBox1.Text = ee.Message;
//                f.ShowDialog();
//            }
        }

        private void btnUnAudit_Click(object sender, EventArgs e)
        {
//            try
//            {
//                try
//                {
//                    gridView1.FocusedRowHandle -= 1;
//                    gridView1.FocusedRowHandle += 1;
//                }
//                catch { }

//                int iCou = 0;
//                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
//                conn.Open();
//                //启用事务
//                SqlTransaction tran = conn.BeginTransaction();
//                try
//                {
//                    string s部门编码 = lookUpEditcDepCode.Text.Trim();
//                    if (s部门编码 == "")
//                    {
//                        lookUpEditcDepCode.Focus();
//                        throw new Exception("部门编码不能为空");
//                    }

//                    string s产品编码 = lookUpEditcInvCode.Text.Trim();
//                    if (s产品编码 == "")
//                    {
//                        lookUpEditcDepCode.Focus();
//                        throw new Exception("产品编码不能为空");
//                    }

//                    string s会计期间 = lookUpEdit会计期间.Text.Trim();
//                    if (s会计期间 == "")
//                    {
//                        lookUpEditcDepCode.Focus();
//                        throw new Exception("会计期间不能为空");
//                    }


//                    string sSQL = @"
//select * 
//from    _ProMaterial
//where 1=1
//ORDER BY iID
//";
//                    sSQL = sSQL.Replace("1=1", "1=1 and 会计期间 = '" + lookUpEdit会计期间.Text.Trim() + "' and 部门 = '" + s部门编码 + "' and 产品编码 = '" + s产品编码 + "' ");
//                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
//                    if (dt == null || dt.Rows.Count == 0)
//                    {
//                        throw new Exception("获得数据失败");
//                    }

//                    if (dt.Rows[0]["审核人"].ToString().Trim() == "")
//                    {
//                        throw new Exception("尚未审核");
//                    }

//                    Model._ProMaterial model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._ProMaterial();
//                    model.部门 = lookUpEditcDepCode.EditValue.ToString().Trim();
//                    model.产品编码 = lookUpEditcInvCode.EditValue.ToString().Trim();
//                    model.会计期间 = lookUpEdit会计期间.EditValue.ToString().Trim();

//                    UFIDA.U8.UAP.CustomApp.ControlForm.DAL._ProMaterial DAL = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._ProMaterial();
//                    sSQL = "update _ProMaterial set 审核人 = null,审核日期 = null where 1=1";
//                    sSQL = sSQL.Replace("1=1", "1=1 and 会计期间 = '" + lookUpEdit会计期间.Text.Trim() + "' and 部门 = '" + s部门编码 + "' and 产品编码 = '" + s产品编码 + "' ");

//                    iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
//                    tran.Commit();

//                    GetGrid();
//                }
//                catch (Exception error)
//                {
//                    tran.Rollback();
//                    throw new Exception(error.Message);
//                }
//            }
//            catch (Exception ee)
//            {
//                FrmMsgBox f = new FrmMsgBox();
//                f.Text = "弃审失败";
//                f.richTextBox1.Text = ee.Message;
//                f.ShowDialog();
//            }
        }

        private void SetNull()
        {
            lookUpEdit会计期间.EditValue = DateTime.Now.ToString("yyyy-MM");
            lookUpEditcDepCode.EditValue = DBNull.Value;
            lookUpEditcInvName.EditValue = DBNull.Value;

            string sSQL = "select * from dbo._ProMaterial where 1=-1 order by iID ";
            DataTable dt = DbHelperSQL.Query(sSQL);
            gridControl1.DataSource = dt;
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            gridView1.AddNewRow();
        }

        private void btnDelRow_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = gridView1.RowCount - 1; i >= 0; i--)
                {
                    if (gridView1.IsRowSelected(i))
                    {
                        gridView1.DeleteRow(i);
                    }
                }
            }
            catch { }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                SetNull();
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
                string sSQL = @"
if exists (select * from tempdb.dbo.sysobjects where id = object_id(N'tempdb..#a') and type='U')
	drop table #a


CREATE TABLE #a(
	[iID] [int] NULL,
	[会计期间] [varchar](50) NOT NULL,
	[部门] [varchar](50) NOT NULL,
	[产品编码] [varchar](100) NOT NULL,
	[存货编码] [varchar](100) NOT NULL,
	[工时] [decimal](18, 6) NULL,
	[未完工工时] [decimal](18, 6) NULL,
	[数量] [decimal](18, 6) NULL,
	[单价] [decimal](18, 6) NULL,
	[金额] [decimal](18, 6) NULL,
	[制单人] [varchar](100) NULL,
	[制单日期] [datetime] NULL,
	[审核人] [varchar](100) NULL,
	[审核日期] [datetime] NULL,
	[记账人] [varchar](100) NULL,
	[记账日期] [datetime] NULL,
    [冻干完工工时] [decimal](18, 6) NULL,
	[冻干未完工工时] [decimal](18, 6) NULL,
 )

insert into #a
select * 
from  _ProMaterial
where 1=1 and 会计期间 = '111111' and 产品编码 = '333333' and 部门 = '222222'

declare @iCou int
select  @iCou = count(1) from   _ProMaterial
where 1=1 and 会计期间 = '111111' and 产品编码 = '333333' and 部门 = '222222' and (isnull(审核人,'') <> '' or isnull(记账人,'') <> '')

if(@iCou = 0)
    insert into #a(会计期间, 部门, 产品编码, 存货编码, 数量)
    select '111111','222222',InvCode,cInvCode,cast(null as decimal(16,6)) from _getBom  
    where 1=1 and cInvCode not in (select 存货编码 from _ProMaterial where 会计期间 = '111111' and 产品编码 = '333333' and 部门 = '222222')
		and InvCode = '333333'


declare @iCou2 int
select @iCou2 = count(*) from  #a 

if(@iCou2 > 0)
    select * from #a order by  存货编码
else
    select distinct cast(null as int) as iID,cast(null as varchar(50)) as 会计期间, cast(null as varchar(50)) as 部门, a.产品编码, 存货编码
	    , cast(null as decimal(16,2)) as 工时, cast(null as decimal(16,2)) as 未完工工时
	    , cast(null as decimal(16,6)) as 数量,cast(null as decimal(16,6)) as 单价, cast(null as decimal(16,6)) as 金额
	    , cast(null as varchar(50)) as 制单人, cast(null as datetime) as 制单日期 
        , cast(null as varchar(50)) as 审核人, cast(null as datetime) as 审核日期
	    , cast(null as varchar(50)) as 记账人, cast(null as datetime) as 记账日期
	    ,cast(null as decimal(16,2)) as 冻干完工工时,cast(null as decimal(16,2)) as 冻干未完工工时
    from  _ProMaterial a
	    inner join
	    (
	    select max(会计期间) as 会计期间,产品编码 from _ProMaterial group by 产品编码 
	    ) b on a.会计期间 = b.会计期间 and a.产品编码 = b.产品编码
    where 1=1 and a.产品编码 = '333333' 
    order by a.产品编码
";
                sSQL = sSQL.Replace("111111", lookUpEdit会计期间.Text.Trim());
                sSQL = sSQL.Replace("222222", lookUpEditcDepCode.Text.Trim());
                sSQL = sSQL.Replace("333333", lookUpEditcInvName.EditValue.ToString().Trim());

                DataTable dt = DbHelperSQL.Query(sSQL);
                if (dt != null)
                {
                    gridControl1.DataSource = dt;

                    while (gridView1.RowCount < 10)
                    {
                        gridView1.AddNewRow();
                    }

                    gridView1.FocusedRowHandle = 0;

                }

                if (dt.Rows.Count > 0)
                {
                    txt制单人.Text = dt.Rows[0]["制单人"].ToString().Trim();

                    txtWorkTime.Text = BaseFunction.ReturnDecimal(dt.Rows[0]["工时"], 1).ToString().Trim();
                    txtWorkTimeUn.Text = BaseFunction.ReturnDecimal(dt.Rows[0]["未完工工时"], 1).ToString().Trim();
                    txtDGTime.Text = BaseFunction.ReturnDecimal(dt.Rows[0]["冻干完工工时"], 1).ToString().Trim();
                    txtDGUTime.Text = BaseFunction.ReturnDecimal(dt.Rows[0]["冻干未完工工时"], 1).ToString().Trim();

                   DateTime  dtm制单 = BaseFunction.ReturnDate(dt.Rows[0]["制单日期"]);
                   if (dtm制单 > BaseFunction.ReturnDate("2000-1-1"))
                    {
                        dtm制单日期.DateTime = dtm制单;
                    }
                    else
                    {
                        dtm制单日期.Text = "";
                    }


                    txt审核人 .Text = dt.Rows[0]["审核人"].ToString().Trim();

                    DateTime dtm审核 = BaseFunction.ReturnDate(dt.Rows[0]["审核日期"]);

                    if (dtm审核 > BaseFunction.ReturnDate("2000-1-1"))
                    {
                        dtm审核日期.DateTime = dtm审核;
                    }
                    else
                    {
                        dtm审核日期.Text = "";
                    }

                    if (txt审核人.Text.Trim() != "")
                    {
                        gridView1.OptionsBehavior.Editable = false;
                    }
                    else
                    {
                        gridView1.OptionsBehavior.Editable = true;
                    }
                }

                sSQL = @"
select *
from    _ProMaterial
where 1=1 and (isnull(审核人,'') <> '' or isnull(记账人,'') <> '')
ORDER BY iID
";
                sSQL = sSQL.Replace("1=1", "1=1 and 会计期间 = '" + lookUpEdit会计期间.Text.Trim() + "' and 部门 = '" + lookUpEditcDepCode.Text.Trim() + "'");
                DataTable dtTemp = DbHelperSQL.Query(sSQL);

                if (dtTemp != null && dtTemp.Rows.Count > 0)
                {
                    gridView1.OptionsBehavior.ReadOnly = true;
                }
                else
                {
                    gridView1.OptionsBehavior.Editable = true;
                    gridView1.OptionsBehavior.ReadOnly = false;
                    gridControl1.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        private void lookUpEdit会计期间_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (lookUpEditcDepCode.EditValue != null && lookUpEditcDepName.EditValue != null && lookUpEditcInvName.EditValue != null && lookUpEditcInvName.EditValue != null && lookUpEdit会计期间.EditValue != null)
                {
                    GetGrid();
                }
            }
            catch (Exception ee)
            { 
                
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (gridView1.RowCount <= 2)
                {
                    int i = e.RowHandle;
                    gridView1.AddNewRow();
                    gridView1.FocusedRowHandle = i;
                }
                else
                {
                    if (gridView1.FocusedColumn != gridColcInvCode && e.RowHandle == gridView1.RowCount - 1 && gridView1.GetRowCellValue(e.RowHandle, gridColcInvCode).ToString().Trim() != "")
                    {
                        int i = e.RowHandle;
                        gridView1.AddNewRow();
                        gridView1.FocusedRowHandle = i;
                    }
                }
            }
            catch { }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("刷新数据失败：" + ee.Message);
            }
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            try
            {
                FrmMaterialList frm = new FrmMaterialList();
                DialogResult d = frm.ShowDialog();
                if (d == DialogResult.OK)
                {
                    lookUpEdit会计期间.EditValue = frm.s会计期间;
                    lookUpEditcDepCode.EditValue = frm.s部门编码;
                    lookUpEditcInvName.EditValue = frm.s产品编码;

                    btnRefresh_Click(null, null);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnTxtInvCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                string sInvCode = btnTxtInvCode.Text.Trim();

                FrmInvInfo frm = new FrmInvInfo(sInvCode, false);
                DialogResult d = frm.ShowDialog();
                if (d == DialogResult.OK)
                {
                    btnTxtInvCode.Text = frm.sInvCode;
                    lookUpEditcInvName.EditValue = frm.sInvCode;
                }
                else
                {
                    btnTxtInvCode.Text = "";
                    lookUpEditcInvName.EditValue = DBNull.Value;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载存货档案失败:" + ee.Message);
            }
        }


        private void btnTxtInvCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (btnTxtInvCode.Text.Trim() != "")
                {
                    lookUpEditcInvName.EditValue = btnTxtInvCode.Text.Trim();

                    if (lookUpEditcInvName.Text.Trim() != "")
                    {
                        GetGrid();
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void ItemButtonEditcInvCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                gridView1.FocusedColumn = gridColcInvName;
                string sInvCode = gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, gridColcInvCode).ToString().Trim();

                gridView1.FocusedColumn = gridColcInvCode;

                FrmInvInfo frm = new FrmInvInfo(sInvCode, false);
                DialogResult d = frm.ShowDialog();
                if (d == DialogResult.OK)
                {
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridColcInvCode, frm.sInvCode);
                }
                else
                {
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载存货档案失败:" + ee.Message);
            }
        }

        private void btnTxtInvCode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F2)
                {
                    btnTxtInvCode_ButtonClick(null, null);
                }
            }
            catch { }
        }

        private void ItemButtonEditcInvCode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F2)
                {
                    ItemButtonEditcInvCode_ButtonClick(null, null);
                }
            }
            catch { }
        }

        private void btnLoadCL_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ee)
            { 
            
            }
        }
    }
}
