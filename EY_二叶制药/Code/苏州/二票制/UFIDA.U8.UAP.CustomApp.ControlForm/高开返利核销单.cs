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
    public partial class 高开返利核销单 : UserControl
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

                SetEnable(true);
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }


        public 高开返利核销单()
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
select cCusCode,cCusName,cCusAbbName from Customer order by cCusCode
";
            DataTable dt = DbHelperSQL.Query(sSQL);
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);

            lookUpEditcCusCode.Properties.DataSource = dt;
            lookUpEditcCusName.Properties.DataSource = dt;
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
select * from [dbo].[_高开返利核销单] where cCode = '{0}' 
";
                    sSQL = string.Format(sSQL, txt单据号.Text.Trim());
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        throw new Exception("单据不存在");
                    }

                    DAL._高开返利核销单 dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._高开返利核销单();
                    sSQL = dal.Delete(txt单据号.Text.Trim());
                    iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    tran.Commit();

                    if (iCou > 0)
                    {
                        MessageBox.Show("删除成功");

                        btnLoad_Click(null, null);
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

                decimal d发票核销 = 0;
                for (int i = 0; i < gridView_发票.RowCount; i++)
                {
                    d发票核销 = d发票核销 + BaseFunction.ReturnDecimal(gridView_发票.GetRowCellValue(i, gridCol_HXMoney));
                }

                decimal d返利单核销 = 0;
                for (int i = 0; i < gridView返利单.RowCount; i++)
                {
                    d返利单核销 = d返利单核销 + BaseFunction.ReturnDecimal(gridView返利单.GetRowCellValue(i, gridColHXMoney));
                }
                if (d发票核销 != d返利单核销)
                {
                    throw new Exception("核销金额不正确");
                }


                int iCou = 0;
                string sErr返利单 = "";
                string sErr发票 = "";
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
select * from [dbo].[_高开返利核销单] where cCode = '{0}' 
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
delete [_高开返利核销单] where cCode = '{0}' 
";
                            sSQL = string.Format(sSQL, txt单据号.Text.Trim());
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                    }

                    sSQL = @"
select max(cCode) as cCodeMax from [dbo].[_高开返利核销单] where cCode like '{0}%'
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
                        decimal dUnMoney = BaseFunction.ReturnDecimal(gridView返利单.GetRowCellValue(i, gridColUnMoney));
                        decimal dHXMoney = BaseFunction.ReturnDecimal(gridView返利单.GetRowCellValue(i, gridColHXMoney));

                        if (dHXMoney == 0)
                        {
                            continue;
                        }

                        if (dHXMoney > dUnMoney)
                        {
                            sErr返利单 = sErr返利单 + "行" + (i + 1).ToString() + " 核销金额超额\n";
                            continue;
                        }

                        Model._高开返利核销单 model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._高开返利核销单();
                        model.cCode = sCode;
                        model.dtmDate = DateTime.Today;
                        model.dMoney = BaseFunction.ReturnDecimal(gridView返利单.GetRowCellValue(i, gridColHXMoney));
                        model.FLD_iID = BaseFunction.ReturnLong(gridView返利单.GetRowCellValue(i, gridColFLD_iID));
                        model.FLD_cCode = gridView返利单.GetRowCellValue(i, gridColcCode).ToString().Trim();
                        model.FLD_Money = model.dMoney;
                        model.createUid = sUserID;
                        model.dtmCreate = DateTime.Now;
                        model.GUID = sGuid;
                        model.Remark = txt备注.Text.Trim();

                        DAL._高开返利核销单 dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._高开返利核销单();
                        sSQL = dal.Add(model);
                        iCou += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    for (int i = 0; i < gridView_发票.RowCount; i++)
                    {
                        decimal dUnMoney = BaseFunction.ReturnDecimal(gridView_发票.GetRowCellValue(i, gridCol_UnMoney));
                        decimal dHXMoney = BaseFunction.ReturnDecimal(gridView_发票.GetRowCellValue(i, gridCol_HXMoney));

                        if (dHXMoney == 0)
                        {
                            continue;
                        }

                        if (dHXMoney > dUnMoney)
                        {
                            sErr发票 = sErr发票 + "行" + (i + 1).ToString() + " 核销金额超额\n";
                            continue;
                        }

                        Model._高开返利核销单 model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._高开返利核销单();
                        model.cCode = sCode;
                        model.dtmDate = DateTime.Today;
                        model.dMoney = BaseFunction.ReturnDecimal(gridView_发票.GetRowCellValue(i, gridCol_HXMoney));
                        model.FP_IDs = BaseFunction.ReturnLong(gridView_发票.GetRowCellValue(i, gridCol_FP_IDs));
                        model.FP_Code = gridView_发票.GetRowCellValue(i, gridCol_FPCode).ToString().Trim();
                        model.FP_Money = model.dMoney;
                        model.createUid = sUserID;
                        model.dtmCreate = DateTime.Now;
                        model.GUID = sGuid;
                        model.Remark = txt备注.Text.Trim();

                        DAL._高开返利核销单 dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._高开返利核销单();
                        sSQL = dal.Add(model);
                        iCou += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    string sErr = "";
                    if (sErr发票.Length > 0)
                    {
                        sErr = sErr + "发票:\n" + sErr发票;
                    }
                    if (sErr返利单.Length > 0)
                    {
                        sErr = sErr + "返利单:\n" + sErr返利单;
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

            gridControl返利单.DataSource = DBNull.Value;
        }

        private void SetEnable(bool b)
        {
            //groupBox1.Enabled = b;

            txt单据号.Enabled = false;
            dtm.Enabled = b;
            txt备注.Enabled = b;

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
                    throw new Exception("请选择客户");
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
            decimal d返利单未核销金额 = 0;
            decimal d发票未核销金额 = 0;

            string sErr = "";

            string sSQL = @"
select * 
from _TH_GET_FLD 
where 1=1
order by iID
";

            if (lookUpEditcCusCode.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and cCusCode = '" + lookUpEditcCusCode.EditValue.ToString().Trim() + "'");
            }
          

            DataTable dtFLD = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
            gridControl返利单.DataSource = dtFLD;

            for (int i = 0; i < dtFLD.Rows.Count; i++)
            {
                d返利单未核销金额 = d返利单未核销金额 + BaseFunction.ReturnDecimal(dtFLD.Rows[i]["UnMoney"]);
            }


            sSQL = @"
select *
from _TH_GET_PurBillVouch
where ISNULL(UnMoney,0) <> 0 
    AND 1=1 
order by FPDate,PBVID
";

            if (lookUpEditcCusCode.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and cCusCode = '" + lookUpEditcCusCode.EditValue.ToString().Trim() + "'");
            }

            DataTable dtFP = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
            gridControl_发票.DataSource = dtFP;

            for (int i = 0; i < dtFP.Rows.Count; i++)
            {
                d发票未核销金额 = d发票未核销金额 + BaseFunction.ReturnDecimal(dtFP.Rows[i]["UnMoney"]);
            }

            decimal d核销金额 = 0;

            if (d返利单未核销金额 > d发票未核销金额)
            {
                d核销金额 = d发票未核销金额;
            }
            else
            {
                d核销金额 = d返利单未核销金额;
            }
            txt核销金额.EditValue = d核销金额;

            for (int i = 0; i < gridView_发票.RowCount; i++)
            {
                if (d核销金额 <= 0)
                    break;

                decimal d未核销金额 = BaseFunction.ReturnDecimal(gridView_发票.GetRowCellValue(i, gridCol_UnMoney));
                if (d核销金额 >= d未核销金额)
                {
                    gridView_发票.SetRowCellValue(i, gridCol_HXMoney, d未核销金额);
                    d核销金额 = d核销金额 - d未核销金额;
                }
                else
                {
                    gridView_发票.SetRowCellValue(i, gridCol_HXMoney, d核销金额);
                    d核销金额 = 0;
                }
            }

            d核销金额 = BaseFunction.ReturnDecimal(txt核销金额.EditValue);
            for (int i = 0; i < gridView返利单.RowCount; i++)
            {
                if (d核销金额 <= 0)
                    break;

                decimal d未核销金额 = BaseFunction.ReturnDecimal(gridView返利单.GetRowCellValue(i, gridColUnMoney));
                if (d核销金额 >= d未核销金额)
                {
                    gridView返利单.SetRowCellValue(i, gridColHXMoney, d未核销金额);
                    d核销金额 = d核销金额 - d未核销金额;
                }
                else
                {
                    gridView返利单.SetRowCellValue(i, gridColHXMoney, d核销金额);
                    d核销金额 = 0;
                }
            }

            try
            {
                gridView返利单.FocusedRowHandle += 1;
                gridView_发票.FocusedRowHandle += 1;
            }
            catch { }
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
select * from [dbo].[_高开返利核销单] where cCode = '{0}' 
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
update [dbo].[_高开返利核销单] set [auditUid] = '{0}',[dtmAudit] = getdate()
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
select * from [dbo].[_高开返利核销单] where cCode = '{0}' 
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
update [dbo].[_高开返利核销单] set [auditUid] = null,[dtmAudit] = null
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

    }
}
