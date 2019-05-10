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
    public partial class 高开返利单 : UserControl
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
                SetNull();

                dtm.DateTime = BaseFunction.ReturnDate(sLogDate);

                dtm发票1.DateTime = BaseFunction.ReturnDate(BaseFunction.ReturnDate(sLogDate).ToString("yyyy-MM-01"));
                dtm发票2.DateTime = BaseFunction.ReturnDate(sLogDate);

                SetLookUp();

                if (s_Code != null && s_Code.Trim() != "")
                {
                    GetGrid(s_Code, Conn, sUserID, sUserName, sLogDate, sAccID);
                }

                if (txt单据号.Text.Trim() == "")
                {
                    SetEnable(true);
                }
                else
                {
                    SetEnable(false);

                    btnLoad.Enabled = false;
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }


        public 高开返利单()
        {
            InitializeComponent();
        }

        private void GetGrid(string sCode, string Conn, string sUserID, string sUserName, string sLogDate, string sAccID)
        {
            string sSQL = @"
select cast(0 as bit) as choose,*
from [_高开返利单]
where cCode = '{0}'
";
            sSQL = string.Format(sSQL, sCode);
            DataTable dt = DbHelperSQL.Query(sSQL);
            if (dt != null && dt.Rows.Count > 0)
            {
                gridControl1.DataSource = dt;

                txt单据号.Text = dt.Rows[0]["cCode"].ToString().Trim();
                dtm.DateTime = BaseFunction.ReturnDate(dt.Rows[0]["dtmDate"]);
                lookUpEdit_cPersonCode.EditValue = dt.Rows[0]["cPersonCode"].ToString().Trim();

                if (dt.Rows[0]["auditUid"].ToString().Trim() != "")
                {
                    SetEnable(false);
                }
                else
                {
                    SetEnable(true);
                }
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

        private void SetLookUp()
        {
            string sSQL = @"
select cPersonCode,cPersonName from Person order by cPersonCode
";
            DataTable dt = DbHelperSQL.Query(sSQL);
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);

            lookUpEditcPersonCode.Properties.DataSource = dt;
            lookUpEditcPersonName.Properties.DataSource = dt;
            lookUpEdit_cPersonCode.Properties.DataSource = dt;
            lookUpEdit_cPersonName.Properties.DataSource = dt;

            sSQL = @"
select cCusCode,cCusName,cCusAbbName from Customer order by cCusCode
";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);

            lookUpEditcCusCode.Properties.DataSource = dt;
            lookUpEditcCusName.Properties.DataSource = dt;

            sSQL = @"
select distinct a.DLS,cus.cCusName as DLSName
FROM [218.64.122.137].[UFDATA_008_2018].dbo.[_TH_GET_FLD]  a left join Customer cus on a.DLS = cus.cCusCode
order by a.DLS
";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditDLS.Properties.DataSource = dt;
            lookUpEditDLSName.Properties.DataSource = dt;
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
                    if (txt单据号.Text.Trim() == "")
                    {
                        throw new Exception("请选择单据");
                    }

                    string sSQL = @"
select * from [dbo].[_高开返利单] where cCode = '{0}' 
";
                    sSQL = string.Format(sSQL, txt单据号.Text.Trim());
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        throw new Exception("单据不存在");
                    }

                    if (dt.Rows[0]["auditUid"].ToString().Trim() != "")
                    {
                        throw new Exception("单据已经审核");
                    }

                    DAL._高开返利单 dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._高开返利单();
                    sSQL = dal.Delete(txt单据号.Text.Trim());
                    iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    tran.Commit();

                    if (iCou > 0)
                    {
                        MessageBox.Show("删除成功");

                        SetNull();
                        SetEnable(true);
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

                int iCou = 0;
                string sErr = "";
                string s_Guid = Guid.NewGuid().ToString();

                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    int iCode = 0;
                    string sSQL = "";
                    if (txt单据号.Text.Trim() != "")
                    {
                        sSQL = @"
select * from [dbo].[_高开返利单] where cCode = '{0}' 
";
                        sSQL = string.Format(sSQL, txt单据号.Text.Trim());
                        DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt == null || dt.Rows.Count == 0)
                        {
                            iCode = 0;
                        }
                        else
                        {
                            if (dt.Rows[0]["auditUid"].ToString().Trim() != "")
                            {
                                throw new Exception("单据已经审核");
                            }

                            sSQL = @"
delete [_高开返利单] where cCode = '{0}' 
";
                            sSQL = string.Format(sSQL, txt单据号.Text.Trim());
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                    }

                    sSQL = @"
select max(cCode) as cCodeMax from [dbo].[_高开返利单] where cCode like '{0}%'
";
                    sSQL = string.Format(sSQL, dtm.DateTime.ToString("yyyyMM"));
                    DataTable dtCode = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtCode == null || dtCode.Rows.Count == 0 || dtCode.Rows[0]["cCodeMax"].ToString().Trim() == "")
                    {
                        iCode = 1;
                    }
                    else
                    {
                        string sCodeTemp = dtCode.Rows[0]["cCodeMax"].ToString().Trim();
                        string stemp = sCodeTemp.Substring(6);
                        iCode = BaseFunction.ReturnInt(stemp) + 1;
                    }

                    string sCode = iCode.ToString().Trim();
                    sCode = dtm.DateTime.ToString("yyyyMM") + sCode.PadLeft(4, '0');

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (!BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridCol选择)))
                            continue;

                        bool bRed = BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColbRed));

                        decimal d发货单价 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol发货单价));
                        if (d发货单价 <= 0 && !bRed)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "发货单价不正确\n";
                            continue;
                        }

                        Model._高开返利单 mod = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._高开返利单();
                        mod.cCode = sCode;
                        mod.dtmDate = dtm.DateTime;
                        mod.FPIDs = BaseFunction.ReturnInt(gridView1.GetRowCellValue(i, gridCol发票表体ID));
                        mod.cSBVCode = gridView1.GetRowCellValue(i, gridCol发票号).ToString().Trim();
                        mod.dDate = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridCol发票日期));
                        mod.cPersonCode = gridView1.GetRowCellValue(i, gridColcPersonCode).ToString().Trim();
                        mod.cPersonName = gridView1.GetRowCellValue(i, gridColcPersonName).ToString().Trim();
                        //mod.cPersonCode = lookUpEditcPersonCode.EditValue.ToString().Trim();
                        //mod.cPersonName = lookUpEditcPersonName.Text.Trim();
                        mod.cDepCode = gridView1.GetRowCellValue(i, gridCol部门编号).ToString().Trim();
                        mod.cDepName = gridView1.GetRowCellValue(i, gridCol部门名称).ToString().Trim();
                        mod.cCusCode = gridView1.GetRowCellValue(i, gridCol客户编码).ToString().Trim();
                        mod.cCusName = gridView1.GetRowCellValue(i, gridCol客户名称).ToString().Trim();
                        mod.cCusAbbName = gridView1.GetRowCellValue(i, gridCol客户简称).ToString().Trim();
                        mod.cInvCode = gridView1.GetRowCellValue(i, gridCol存货编码).ToString().Trim();
                        mod.cInvName = gridView1.GetRowCellValue(i, gridCol存货名称).ToString().Trim();
                        mod.cInvStd = gridView1.GetRowCellValue(i, gridCol规格型号).ToString().Trim();
                        mod.iTaxUnitPrice = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol单价));
                        mod.iQuantity = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol数量));
                        mod.iSum = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol金额));
                        mod.cDLCode = gridView1.GetRowCellValue(i, gridCol发货单号).ToString().Trim();
                        mod.iTaxUnitPriceFH = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol发货单价));
                        mod.iTaxRateCJ = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol差价税率));
                        mod.iTaxCJ = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol差价税额));
                        mod.iMoneyFL = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol返利金额));
                        mod.createUid = sUserID;
                        mod.dtmCreate = BaseFunction.ReturnDate(sLogDate);
                        mod.Remark = txt备注.Text.Trim();
                        mod.DLS = gridView1.GetRowCellValue(i, gridCol代理商编码).ToString().Trim();
                        mod.DLSName = gridView1.GetRowCellValue(i, gridCol代理商).ToString().Trim();
                        mod.sGUID = s_Guid;

                        mod.bRed = BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColbRed));

                        DAL._高开返利单 dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._高开返利单();
                        sSQL = dal.Add(mod);
                        iCou += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                        txt单据号.Text = mod.cCode;
                        lookUpEdit_cPersonCode.EditValue = mod.cPersonCode;


                        //int iFoc = gridView1.FocusedRowHandle;
                        //GetGrid(tran);
                        //gridView1.FocusedRowHandle = iFoc;
                    }

                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr.Trim());
                    }

                    if (iCou > 0)
                    {
                        tran.Commit();

                        MessageBox.Show("保存成功\n单据号:" + sCode);

                        SetEnable(false);
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

        private void SetNull()
        {
            lookUpEditcCusCode.EditValue = DBNull.Value;
            lookUpEditcPersonCode.EditValue = DBNull.Value;

            txt单据号.EditValue = DBNull.Value;
            
            lookUpEdit_cPersonCode.EditValue = DBNull.Value;
            txt备注.EditValue = DBNull.Value;

            gridControl1.DataSource = DBNull.Value;
        }

        private void SetEnable(bool b)
        {
            //groupBox1.Enabled = b;

            txt单据号.Enabled = false;
            dtm.Enabled = b;
            lookUpEdit_cPersonCode.Enabled = false;
            lookUpEdit_cPersonName.Enabled = false;
            txt备注.Enabled = b;

            chkAll.Enabled = b;
            gridView1.OptionsBehavior.Editable = b;

            btnSave.Enabled = b;

            if (txt单据号.Text.Trim() == "")
            {
                btnAudit.Enabled = false;
                btnUnAudit.Enabled = false;
                btnDel.Enabled = false;
            }
            else
            {
                btnAudit.Enabled = true;
                btnUnAudit.Enabled = true;
                btnDel.Enabled = true;
            }
            btnLoad.Enabled = true;
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
                sa.FileName = "高开返利单";

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

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtm发票1.Text.Trim() == "" || dtm发票1.DateTime < Convert.ToDateTime("2017-01-01"))
                {
                    dtm发票1.Focus();
                    throw new Exception("请选择发票日期范围");
                }
                if (dtm发票2.Text.Trim() == "" || dtm发票2.DateTime < Convert.ToDateTime("2017-01-01") || dtm发票1.DateTime > dtm发票2.DateTime)
                {
                    dtm发票1.Focus();
                    throw new Exception("请选择发票日期范围");
                }
                txt单据号.Text = "";


                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    GetGrid(tran);

                    tran.Commit();

                    SetEnable(true);
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败:" + ee.Message);
            }
        }

        private void GetGrid(SqlTransaction tran)
        {
            string sErr = "";

            string sSQL = @"
select cast(0 as bit) as choose, * 
from [218.64.122.137].[UFDATA_008_2018].dbo.[_TH_GET_FLD]  
where 1=1
	and FPIDs not in (select [FPIDs] from [dbo].[_高开返利单])
order by FPIDs
";
            if (lookUpEditcPersonCode.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and cPersonCode = '" + lookUpEditcPersonCode.EditValue.ToString().Trim() + "'");
            }
            if (dtm发票1.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and dDate >= '" + dtm发票1.DateTime.ToString("yyyy-MM-dd") + "'");
            }
            if (dtm发票2.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and dDate < '" + dtm发票2.DateTime.AddDays(1).ToString("yyyy-MM-dd") + "'");
            }

            if (lookUpEditcCusCode.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and cCusCode = '" + lookUpEditcCusCode.EditValue.ToString().Trim() + "'");
            }
            if (lookUpEditDLS.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and DLS = '" + lookUpEditDLS.EditValue.ToString().Trim() + "'");
            }

            DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string sDLS = dt.Rows[i]["DLS"].ToString().Trim();
                string sInvCode = dt.Rows[i]["cInvCode"].ToString().Trim();
                decimal dQty = BaseFunction.ReturnDecimal(dt.Rows[i]["iQuantity"]);
                decimal diTaxUnitPrice = BaseFunction.ReturnDecimal(dt.Rows[i]["iTaxUnitPrice"]);
                decimal diSum = BaseFunction.ReturnDecimal(dt.Rows[i]["iSum"]);
                DateTime dDate = BaseFunction.ReturnDate(dt.Rows[i]["dDate"]);
                string sYWY = dt.Rows[i]["cPersonCode"].ToString().Trim();

                sSQL = @"
select * from _TH_GET_FHPrice
where ccuscode = '{0}' and cinvcode = '{1}' and ywy = '{4}'
    and case when isnull(fminquantity,0) >= 0 then isnull(fminquantity,0) else -1 * isnull(fminquantity,0) end < ABS ({2})
	and dstartdate < '{3}'
order by dstartdate desc,isnull(fminquantity,0) desc
";
                sSQL = string.Format(sSQL, sDLS, sInvCode, dQty, dDate.AddDays(1), sYWY);
                DataTable dtPrice = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                if (dtPrice == null || dtPrice.Rows.Count == 0)
                {
                    sErr = sErr + "行" + (i + 1).ToString() + " 请设置单价\n";
                    continue;
                }

                decimal diinvnowcost = BaseFunction.ReturnDecimal(dtPrice.Rows[0]["iinvnowcost"], 6);                    //单价
                decimal dCJSL = BaseFunction.ReturnDecimal(dtPrice.Rows[0]["cjsl"], 2);                                  //差价税率
                decimal diTaxCJ = BaseFunction.ReturnDecimal((diTaxUnitPrice - diinvnowcost) * dQty * dCJSL, 2);
                decimal diMoneyFL = BaseFunction.ReturnDecimal(diSum - diinvnowcost * dQty - diTaxCJ, 2);

                dt.Rows[i]["iTaxUnitPriceFH"] = diinvnowcost;
                dt.Rows[i]["iTaxRateCJ"] = dCJSL;
                dt.Rows[i]["iTaxCJ"] = diTaxCJ;
                dt.Rows[i]["iMoneyFL"] = diMoneyFL;

            }

            gridControl1.DataSource = dt;
        }

        private void lookUpEditcPersonCode_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditcPersonName.EditValue = lookUpEditcPersonCode.EditValue;
        }

        private void lookUpEditcPersonName_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditcPersonCode.EditValue = lookUpEditcPersonName.EditValue;
        }

        private void lookUpEditcCusCode_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditcCusName.EditValue = lookUpEditcCusCode.EditValue;
        }

        private void lookUpEditcCusName_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditcCusCode.EditValue = lookUpEditcCusName.EditValue;
        }

        private void lookUpEdit_cPersonCode_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEdit_cPersonName.EditValue = lookUpEdit_cPersonCode.EditValue;
        }

        private void lookUpEdit_cPersonName_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEdit_cPersonCode.EditValue = lookUpEdit_cPersonName.EditValue;
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
                    if (txt单据号.Text.Trim() == "")
                    {
                        throw new Exception("请选择单据");
                    }

                    string sSQL = @"
select * from [dbo].[_高开返利单] where cCode = '{0}' 
";
                    sSQL = string.Format(sSQL, txt单据号.Text.Trim());
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        throw new Exception("单据不存在");
                    }

                    if (dt.Rows[0]["auditUid"].ToString().Trim() != "")
                    {
                        throw new Exception("单据已经审核");
                    }

                    sSQL = @"
update [dbo].[_高开返利单] set [auditUid] = '{0}',[dtmAudit] = getdate()
where [cCode] = '{1}'
";
                    sSQL = string.Format(sSQL, sUserID, txt单据号.Text.Trim());
                    iCou = DbHelperSQL.ExecuteNonQuery(tran,CommandType.Text,sSQL);

                    tran.Commit();

                    if (iCou > 0)
                    {
                        MessageBox.Show("审核成功");
                        SetEnable(false);
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
                    if (txt单据号.Text.Trim() == "")
                    {
                        throw new Exception("请选择单据");
                    }

                    string sSQL = @"
select * from [dbo].[_高开返利单] where cCode = '{0}' 
";
                    sSQL = string.Format(sSQL, txt单据号.Text.Trim());
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        throw new Exception("单据不存在");
                    }

                    if (dt.Rows[0]["auditUid"].ToString().Trim() == "")
                    {
                        throw new Exception("单据未审核");
                    }

                    sSQL = @"
update [dbo].[_高开返利单] set [auditUid] = null,[dtmAudit] = null
where [cCode] = '{0}'
";
                    sSQL = string.Format(sSQL, txt单据号.Text.Trim());
                    iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    tran.Commit();

                    if (iCou > 0)
                    {
                        MessageBox.Show("弃审成功");
                        SetEnable(true);
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

        private void lookUpEditDLS_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditDLSName.EditValue = lookUpEditDLS.EditValue;
        }

        private void lookUpEditDLSName_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditDLS.EditValue = lookUpEditDLSName.EditValue;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                int iRow = gridView1.FocusedRowHandle;

                if (e.Column == gridCol差价税率)
                {
                    decimal diTaxUnitPrice = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol单价));
                    decimal dQty = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol数量), 6);
                    decimal diSum = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol金额));
                    decimal diinvnowcost = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol发货单价), 6);                    //单价
                    decimal dCJSL = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol差价税率), 2);                                  //差价税率

                    decimal diTaxCJ = BaseFunction.ReturnDecimal((diTaxUnitPrice - diinvnowcost) * dQty * dCJSL, 2);
                    decimal diMoneyFL = BaseFunction.ReturnDecimal(diSum - diinvnowcost * dQty - diTaxCJ, 2);

                    gridView1.SetRowCellValue(iRow, gridCol差价税额, diTaxCJ);
                    gridView1.SetRowCellValue(iRow, gridCol返利金额, diMoneyFL);
                }
            }
            catch(Exception ee) 
            {
            
            }
        }

    }
}
