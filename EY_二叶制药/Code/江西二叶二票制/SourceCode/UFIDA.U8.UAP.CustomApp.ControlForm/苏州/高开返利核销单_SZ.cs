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
using DevExpress.XtraReports.UI;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class 高开返利核销单_SZ : UserControl
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

                SetLookUp();

                if (s_Code != null && s_Code.Trim() != "")
                {
                    GetGrid(s_Code, Conn, sUserID, sUserName, sLogDate, sAccID);
                }

                if (s_Code  == "" || s_Code == null)
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


        public 高开返利核销单_SZ()
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
            string sSQL = @"
select distinct DLS,DLSName from [_TH_GET_FLD_SZ] where isnull(DLS,'') <> '' order by DLS
";
            DataTable dt = DbHelperSQL.Query(sSQL);
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);

            lookUpEditcCusCode.Properties.DataSource = dt;
            lookUpEditcCusName.Properties.DataSource = dt;

            sSQL = @"select distinct 城市编码 from [dbo].[_发票_sap] order by 城市编码";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEdit区域.Properties.DataSource = dt;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView返利单.FocusedRowHandle -= 1;
                    gridView返利单.FocusedRowHandle += 1;
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
select * from [dbo].[_高开返利核销单_SZ] where cCode = '{0}' 
";
                    sSQL = string.Format(sSQL, txt单据号.Text.Trim());
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        throw new Exception("单据不存在");
                    }

                    DAL._高开返利核销单_SZ dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._高开返利核销单_SZ();
                    sSQL = dal.Delete(txt单据号.Text.Trim());
                    iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    tran.Commit();

                    if (iCou > 0)
                    {
                        MessageBox.Show("删除成功");

                        SetNull();
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
                    gridView返利单.FocusedRowHandle -= 1;
                    gridView返利单.FocusedRowHandle += 1;
                }
                catch { }

                if (txt开票金额.Text.Trim() == "" && BaseFunction.ReturnDecimal(txt开票金额.Text.Trim()) == 0)
                {
                    txt开票金额.Focus();
                    throw new Exception("请设置开票金额");
                }


                if (txt考核金额.Text.Trim() == "" && BaseFunction.ReturnDecimal(txt考核金额.Text.Trim()) == 0)
                {
                    txt考核金额.Focus();
                    throw new Exception("请设置考核金额");
                }

                if (txt费率.Text.Trim() == "" && BaseFunction.ReturnDecimal(txt费率.Text.Trim()) == 0)
                {
                    txt费率.Focus();
                    throw new Exception("请设置费率");
                }

                int iCou = 0;
                string sErr = "";
                string s_Guid = Guid.NewGuid().ToString();

                Guid sGuid = Guid.NewGuid();

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
select * from [dbo].[_高开返利核销单_SZ] where cCode = '{0}' 
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
delete [_高开返利核销单_SZ] where cCode = '{0}' 
";
                            sSQL = string.Format(sSQL, txt单据号.Text.Trim());
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                    }

                    sSQL = @"
select max(cCode) as cCodeMax from [dbo].[_高开返利核销单_SZ] where cCode like '{0}%'
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

                    for (int i = 0; i < gridView返利单.RowCount; i++)
                    {
                        if (!BaseFunction.ReturnBool(gridView返利单.GetRowCellValue(i, gridColbchoose)))
                        {
                            continue;
                        }

                        Model._高开返利核销单_SZ model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._高开返利核销单_SZ();
                        model.DLS = lookUpEditcCusCode.EditValue.ToString().Trim();
                        if (lookUpEdit区域.EditValue != null)
                        {
                            model.QY = lookUpEdit区域.EditValue.ToString().Trim();
                        }
                        model.cCode = sCode;
                        model.dtmDate = DateTime.Today;
                        model.dMoney_kh = BaseFunction.ReturnDecimal(txt考核金额.Text.Trim());
                        model.dMoney_fl = BaseFunction.ReturnDecimal(txt费率.Text.Trim());
                        model.dMoney_kp = BaseFunction.ReturnDecimal(txt开票金额.Text.Trim());


                        model.FLD_iID = BaseFunction.ReturnLong(gridView返利单.GetRowCellValue(i, gridColFLD_iID));


                        model.FLD_cCode = gridView返利单.GetRowCellValue(i, gridColcCode).ToString().Trim();
                        model.FLD_Money = model.dMoney_kh; BaseFunction.ReturnDecimal(gridView返利单.GetRowCellValue(i, gridCol返利金额));
                        model.createUid = sUserID;
                        model.dtmCreate = DateTime.Now;
                        model.GUID = sGuid;
                        model.DLS = gridView返利单.GetRowCellValue(i, gridCol代理商编码).ToString().Trim();
                        model.Remark = txt备注.Text.Trim();

                        DAL._高开返利核销单_SZ dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._高开返利核销单_SZ();
                        sSQL = dal.Add(model);
                        iCou += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    if (sErr.Length > 0)
                    {

                        throw new Exception(sErr);
                    }

                    if (iCou > 0)
                    {
                        tran.Commit();

                        MessageBox.Show("保存成功\n单据号:" + sCode);
                        txt单据号.Text = sCode;

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
            //lookUpEditcPersonCode.EditValue = DBNull.Value;

            txt单据号.EditValue = DBNull.Value;

            txt备注.EditValue = DBNull.Value;
            txt开票金额.EditValue = DBNull.Value;
            txt考核金额.EditValue = DBNull.Value;
            txt费率.EditValue = DBNull.Value;

            gridControl返利单.DataSource = DBNull.Value;
        }

        private void SetEnable(bool b)
        {
            //groupBox1.Enabled = b;

            txt单据号.Enabled = false;
            dtm.Enabled = b;
            txt备注.Enabled = b;
            txt开票金额.Enabled = b;
            txt考核金额.Enabled = b;
            txt费率.Enabled = b;

            gridView返利单.OptionsBehavior.Editable = b;

            btnSave.Enabled = b;

            if (txt单据号.Text.Trim() == "")
            {
                btnDel.Enabled = false;
            }
            else
            {
                btnDel.Enabled = true;
            }
            btnLoad.Enabled = true;
        }


        private void btnExcel_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    try
            //    {
            //        gridView发票.FocusedRowHandle -= 1;
            //    }
            //    catch { }

            //    SaveFileDialog sa = new SaveFileDialog();
            //    sa.Filter = "Excel文件2003|*.xls";
            //    sa.FileName = "高开返利单";

            //    sa.ShowDialog();
            //    string sPath = sa.FileName;

            //    if (sPath.Trim() != string.Empty)
            //    {
            //        gridView发票.ExportToXls(sPath);
            //        MessageBox.Show("导出列表成功！\n路径：" + sPath);
            //    }
            //}
            //catch (Exception ee)
            //{
            //    throw new Exception("导出列表失败：" + ee.Message);
            //}
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (lookUpEditcCusCode.Text.Trim() == "")
                {
                    lookUpEditcCusCode.Focus();
                    throw new Exception("请选择代理商");
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
            string sSQL = @"
select cast(0 as bit) as bchoose, * ,cCode as FL_Code
from _TH_GET_FLD_HX_SZ 
where 1=1 and iID not in (select [FLD_iID] from [dbo].[_高开返利核销单_SZ])
order by iID
";

            if (lookUpEditcCusCode.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and DLS = '" + lookUpEditcCusCode.EditValue.ToString().Trim() + "'");
            }
            if(lookUpEdit区域.Text.Trim() !="")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and 城市编码 = '" + lookUpEdit区域.EditValue.ToString().Trim() + "'");
            }
          

            DataTable dtFLD = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
            gridControl返利单.DataSource = dtFLD;
            gridView返利单.BestFitColumns();

        }



        private void GetGrid(string sCode, string Conn, string sUserID, string sUserName, string sLogDate, string sAccID)
        {
            string sSQL = @"
select cast(0 as bit) as bchoose,*,b.iSum as 金额,b.cCode as FL_Code
from [dbo].[_高开返利核销单_SZ] a 
	left join [dbo].[_高开返利单_SZ] b on a.FLD_iID = b.iID
where a.cCode = '{0}'
";
            sSQL = string.Format(sSQL, sCode);
            DataTable dt = DbHelperSQL.Query(sSQL);
            if (dt != null && dt.Rows.Count > 0)
            {
                gridControl返利单.DataSource = dt;
                gridView返利单.BestFitColumns();

                txt单据号.Text = dt.Rows[0]["cCode"].ToString().Trim();
                dtm.DateTime = BaseFunction.ReturnDate(dt.Rows[0]["dtmDate"]);

                lookUpEditcCusCode.EditValue = dt.Rows[0]["DLS"];
                lookUpEdit区域.EditValue = dt.Rows[0]["QY"];
                txt开票金额.EditValue = BaseFunction.ReturnDecimal(dt.Rows[0]["dMoney_kp"]);
                txt考核金额.EditValue = BaseFunction.ReturnDecimal(dt.Rows[0]["dMoney_kh"]);
                txt费率.EditValue = BaseFunction.ReturnDecimal(dt.Rows[0]["dMoney_fl"]);

                txt备注.EditValue = dt.Rows[0]["Remark"];

                //if (dt.Rows[0]["auditUid"].ToString().Trim() != "")
                //{
                //    SetEnable(false);
                //}
                //else
                //{
                //    SetEnable(true);
                //}
            }
        }

        private void lookUpEditcCusCode_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditcCusName.EditValue = lookUpEditcCusCode.EditValue;
        }

        private void lookUpEditcCusName_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditcCusCode.EditValue = lookUpEditcCusName.EditValue;
        }

        private void btnAudit_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView返利单.FocusedRowHandle -= 1;
                    gridView返利单.FocusedRowHandle += 1;
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
select * from [dbo].[_高开返利核销单_SZ] where cCode = '{0}' 
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
update [dbo].[_高开返利核销单_SZ] set [auditUid] = '{0}',[dtmAudit] = getdate()
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
                    gridView返利单.FocusedRowHandle -= 1;
                    gridView返利单.FocusedRowHandle += 1;
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
select * from [dbo].[_高开返利核销单_SZ] where cCode = '{0}' 
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
update [dbo].[_高开返利核销单_SZ] set [auditUid] = null,[dtmAudit] = null
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

        private void gridView返利单_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == gridColbchoose)
                {
                    decimal d考核金额 = 0;
                    decimal d开票金额 = 0;
                    for (int i = 0; i < gridView返利单.RowCount; i++)
                    {
                        if (BaseFunction.ReturnBool(gridView返利单.GetRowCellValue(i, gridColbchoose)))
                        {
                            d考核金额 += BaseFunction.ReturnDecimal(gridView返利单.GetRowCellValue(i, gridCol返利金额));
                            d开票金额 += BaseFunction.ReturnDecimal(gridView返利单.GetRowCellValue(i, gridCol发票金额));
                        }
                    }
                    txt考核金额.EditValue = d考核金额;
                    txt开票金额.EditValue = d开票金额;
                }
            }
            catch { }
        }


        string sPrintLayOutMod = Application.StartupPath + "\\UAP\\Runtime\\print\\PrintHXD.dll";

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt单据号.Text.Trim() == "")
                {
                    throw new Exception("请选择需要打印的单据");
                }

                string sSQL = @"
select cast(0 as bit) as bchoose,*,b.iSum as 金额
from [dbo].[_高开返利核销单_SZ] a 
	left join [dbo].[_高开返利单_SZ] b on a.FLD_iID = b.iID
where a.cCode = '{0}'
";
                sSQL = string.Format(sSQL, txt单据号.Text.Trim());
                
                DataTable dt = DbHelperSQL.Query(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("获取单据信息失败");
                }

                Rep = new RepBaseGrid();
                if (File.Exists(sPrintLayOutMod))
                {
                    Rep.LoadLayout(sPrintLayOutMod);
                }
                else
                {
                    MessageBox.Show("加载报表模板失败，请与管理员联系");
                    return;
                }
                Rep.dsPrint.Tables.Clear();
                Rep.dsPrint.Tables.Add(dt.Copy());
                Rep.dsPrint.Tables[0].TableName = "dtGrid";

                Rep.ShowPreview();
                Rep.PrintingSystem.ShowMarginsWarning = false;
               
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnPrintSet_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(sProPath + "\\print"))
                    Directory.CreateDirectory(sProPath + "\\print");

                if (File.Exists(sPrintLayOutMod))
                {
                    Rep.LoadLayout(sPrintLayOutMod);
                }

                Rep.ShowDesignerDialog();

                DialogResult d = MessageBox.Show("是否保存?模板调整将在下次打开窗体时体现\n是：保存打印模板\n", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (DialogResult.Yes == d)
                {
                    Rep.SaveLayoutToXml(sPrintLayOutMod);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "设置打印模板失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }
    }
}
