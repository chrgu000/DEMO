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
using System.Collections;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class GL_accvouch : UserControl
    {        
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
                DbHelperSQL.connectionString = Conn;

                string sSQL = @"select distinct convert(varchar(7),[dDate],121) as Period from [dbo].[_GL_accvouch_FromERP] order by convert(varchar(7),[dDate],121) ";
                DataTable dt = DbHelperSQL.Query(sSQL);
                lookUpEditPeriod.Properties.DataSource = dt;
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        public GL_accvouch()
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
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                string sErr = "";

                if (gridView1.RowCount == 0)
                {
                    throw new Exception("请加载数据");
                }

                DataTable dtErr = new DataTable();
                DataColumn dc = new DataColumn();
                dc.ColumnName = "iID";
                dtErr.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "sErr";
                dtErr.Columns.Add(dc);

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sSQL = "SELECT * FROM dbo.GL_mend WHERE iyear = aaaaaa AND iperiod = bbbbbb";
                    sSQL = sSQL.Replace("aaaaaa", iYear.ToString());
                    sSQL = sSQL.Replace("bbbbbb", iMonth.ToString());
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        throw new Exception("获得模块状态失败");
                    }
                    if (BaseFunction.ReturnBool(dt.Rows[0]["bflag"]))
                    {
                        throw new Exception("总账已结账");
                    }

                    string scsign = "";
                    int ino_id = 0;
                    int iRow = 0;

                    sSQL = @"
select * from code where iyear = {0}
";
                    sSQL = string.Format(sSQL, iYear);
                    DataTable dtCode = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    int inid = 0;
                    int iCount = 0;

                    if (gridView1.GetRowCellValue(0, gridColcsign).ToString().Trim() != "")
                    {
                        scsign = gridView1.GetRowCellValue(0, gridColcsign).ToString().Trim();
                    }
                    else
                    {
                        scsign = "记";
                    }
                    sSQL = @"select * from dsign where csign = '{0}'";
                    sSQL = string.Format(sSQL, scsign);
                    DataTable dtdsign = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtdsign == null || dtdsign.Rows.Count == 0)
                    {
                        sErr = sErr + "凭证类别不正确\n";
                    }

                    if (ino_id == 0)
                    {
                        sSQL = @"
select isnull(max(ino_id),0) as ino_id from GL_accvouch where csign = '{0}' and iyear = {1} and iperiod = {2}
";
                        sSQL = string.Format(sSQL, scsign, iYear, iMonth);
                        DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtTemp == null || dtTemp.Rows.Count == 0)
                        {
                            ino_id = 0;
                        }
                        else
                        {
                            ino_id = BaseFunction.ReturnInt(dtTemp.Rows[0]["ino_id"]);
                        }
                    }

                    ino_id += 1;
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        bool b = BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColbChoose));
                        if (!b)
                            continue;

                        #region 第一行

                        inid += 1;
                        Model.GL_accvouch model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.GL_accvouch();
                        model.iperiod = iMonth;

                        model.csign = scsign;
                        model.isignseq = BaseFunction.ReturnInt(dtdsign.Rows[0]["isignseq"]);


                        model.ino_id = ino_id;

                        iRow += 1;
                        model.inid = iRow;
                        model.dbill_date = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridColdDate));
                        model.idoc = -1;
                        model.cbill = sUserName;
                        model.ibook = 0;
                        model.cdigest = gridView1.GetRowCellValue(i, gridColcdigest).ToString().Trim(); ;



                        model.ccode = gridView1.GetRowCellValue(i, gridColccode).ToString().Trim();

                        DataRow[] dr = dtCode.Select("ccode = '" + model.ccode + "'");

                        if (dr == null || dr.Length == 0)
                        {
                            string sErrInfo = "会计科目不正确";
                            DataRow drErr = dtErr.NewRow();
                            drErr["iID"] = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColiID));
                            drErr["sErr"] = sErrInfo;
                            dtErr.Rows.Add(drErr);

                            sErr = sErr + "行" + (i + 1).ToString() + "" + sErrInfo + "\n";
                            continue;
                        }

                        bool bend = BaseFunction.ReturnBool(dr[0]["bend"]);
                        if (!bend)
                        {

                            string sErrInfo = "会计科目不是末级";
                            DataRow drErr = dtErr.NewRow();
                            drErr["iID"] = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColiID));
                            drErr["sErr"] = sErrInfo;
                            dtErr.Rows.Add(drErr);


                            sErr = sErr + "行" + (i + 1).ToString() + "" + sErrInfo + "\n";
                            continue;
                        }

                        bool bproperty = BaseFunction.ReturnBool(dr[0]["bproperty"]);
                        //借方
                        if (bproperty)
                        {
                            model.md = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColmoney));
                            model.md_f = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColmoney));
                            model.nfrat = 1;
                            model.nd_s = 0;
                            model.nc_s = 0;
                        }
                        else
                        {
                            model.mc = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColmoney));
                            model.mc_f = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColmoney));
                            model.nfrat = 1;
                            model.nd_s = 0;
                            model.nc_s = 0;
                        }

                        bool bperson = BaseFunction.ReturnBool(dr[0]["bperson"]);
                        if (bperson)
                        {
                            string sPsn = gridView1.GetRowCellValue(i, gridColcPersonCode).ToString().Trim();
                            if (sPsn == "")
                            {
                                string sErrInfo = "必须有人员";
                                DataRow drErr = dtErr.NewRow();
                                drErr["iID"] = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColiID));
                                drErr["sErr"] = sErrInfo;
                                dtErr.Rows.Add(drErr);


                                sErr = sErr + "行" + (i + 1).ToString() + "" + sErrInfo + "\n";
                                continue;
                            }
                            sSQL = @"select * from View_Pserson where cPersoncode = '{0}' or cPersonname = '{0}'";
                            sSQL = string.Format(sSQL, sPsn);
                            DataTable dtPerson = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dtPerson == null || dtPerson.Rows.Count == 0)
                            {
                                string sErrInfo = "人员不正确";
                                DataRow drErr = dtErr.NewRow();
                                drErr["iID"] = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColiID));
                                drErr["sErr"] = sErrInfo;
                                dtErr.Rows.Add(drErr);


                                sErr = sErr + "行" + (i + 1).ToString() + "" + sErrInfo + "\n";
                                continue;
                            }
                            model.cperson_id = sPsn;
                        }


                        bool bcus = BaseFunction.ReturnBool(dr[0]["bcus"]);
                        if (bcus)
                        {
                            string sCuscode = gridView1.GetRowCellValue(i, gridColcCusCode).ToString().Trim();
                            if (sCuscode == "")
                            {
                                string sErrInfo = "必须有客户";
                                DataRow drErr = dtErr.NewRow();
                                drErr["iID"] = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColiID));
                                drErr["sErr"] = sErrInfo;
                                dtErr.Rows.Add(drErr);


                                sErr = sErr + "行" + (i + 1).ToString() + "" + sErrInfo + "\n";
                                continue;
                            }
                            sSQL = @"select * from View_Customer where cCusCode = '{0}' or cCusName = '{0}'";
                            sSQL = string.Format(sSQL, sCuscode);
                            DataTable dtCustomer = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dtCustomer == null || dtCustomer.Rows.Count == 0)
                            {
                                string sErrInfo = "客户不正确";
                                DataRow drErr = dtErr.NewRow();
                                drErr["iID"] = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColiID));
                                drErr["sErr"] = sErrInfo;
                                dtErr.Rows.Add(drErr);


                                sErr = sErr + "行" + (i + 1).ToString() + "" + sErrInfo + "\n";
                                continue;
                            }
                            model.ccus_id = sCuscode;
                        }


                        bool bsup = BaseFunction.ReturnBool(dr[0]["bsup"]);
                        if (bsup)
                        {
                            string sVencode = gridView1.GetRowCellValue(i, gridColcVenCode).ToString().Trim();
                            if (sVencode == "")
                            {
                                string sErrInfo = "必须有供应商";
                                DataRow drErr = dtErr.NewRow();
                                drErr["iID"] = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColiID));
                                drErr["sErr"] = sErrInfo;
                                dtErr.Rows.Add(drErr);

                                sErr = sErr + "行" + (i + 1).ToString() + "" + sErrInfo + "\n";
                                continue;
                            }
                            sSQL = @"select * from View_Vendor where CVenCode = '{0}' or cVenName = '{0}'";
                            sSQL = string.Format(sSQL, sVencode);
                            DataTable dtVendor = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dtVendor == null || dtVendor.Rows.Count == 0)
                            {
                                string sErrInfo = "供应商不正确";
                                DataRow drErr = dtErr.NewRow();
                                drErr["iID"] = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColiID));
                                drErr["sErr"] = sErrInfo;
                                dtErr.Rows.Add(drErr);

                                sErr = sErr + "行" + (i + 1).ToString() + "" + sErrInfo + "\n";
                                continue;
                            }
                            model.csup_id = sVencode;
                        }


                        bool bdept = BaseFunction.ReturnBool(dr[0]["bdept"]);
                        if (bsup)
                        {
                            string sdept = gridView1.GetRowCellValue(i, gridColcDepCode).ToString().Trim();
                            if (sdept == "")
                            {
                                string sErrInfo = "必须有部门";
                                DataRow drErr = dtErr.NewRow();
                                drErr["iID"] = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColiID));
                                drErr["sErr"] = sErrInfo;
                                dtErr.Rows.Add(drErr);

                                sErr = sErr + "行" + (i + 1).ToString() + "" + sErrInfo + "\n";
                                continue;
                            }
                            sSQL = @"select * from View_Department where cDepCode = '{0}' or cDepName = '{0}'";
                            sSQL = string.Format(sSQL, sdept);
                            DataTable dtDept = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dtDept == null || dtDept.Rows.Count == 0)
                            {
                                string sErrInfo = "部门不正确";
                                DataRow drErr = dtErr.NewRow();
                                drErr["iID"] = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColiID));
                                drErr["sErr"] = sErrInfo;
                                dtErr.Rows.Add(drErr);

                                sErr = sErr + "行" + (i + 1).ToString() + "" + sErrInfo + "\n";
                                continue;
                            }
                            model.cdept_id = sdept;
                        }


                        model.bdelete = false;
                        model.doutbilldate = model.dbill_date;
                        model.bvouchedit = true;
                        model.bvouchAddordele = false;
                        model.bvouchmoneyhold = false;
                        model.bvalueedit = true;
                        model.bcodeedit = true;
                        model.bPCSedit = true;
                        model.bDeptedit = true;
                        model.bItemedit = true;
                        model.bCusSupInput = false;
                        model.bFlagOut = false;
                        model.RowGuid = Guid.NewGuid().ToString();
                        model.iyear = iYear;
                        model.iYPeriod = iMonth;
                        model.tvouchtime = DateTime.Now;



                        DAL.GL_accvouch dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.GL_accvouch();
                        sSQL = dal.Add(model);
                        iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        #endregion

                        #region 第二行

                        inid += 1;
                        model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.GL_accvouch();
                        model.iperiod = iMonth;

                        model.csign = scsign;
                        model.isignseq = BaseFunction.ReturnInt(dtdsign.Rows[0]["isignseq"]);
                        model.ino_id = ino_id;

                        iRow += 1;
                        model.inid = iRow;
                        model.dbill_date = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridColdDate));
                        model.idoc = -1;
                        model.cbill = sUserName;
                        model.ibook = 0;
                        model.cdigest = gridView1.GetRowCellValue(i, gridColcdigest).ToString().Trim(); ;

                        model.ccode = gridView1.GetRowCellValue(i, gridColccode_equal).ToString().Trim();

                        dr = dtCode.Select("ccode = '" + model.ccode + "'");

                        if (dr == null || dr.Length == 0)
                        {
                            string sErrInfo = "会计科目不正确";
                            DataRow drErr = dtErr.NewRow();
                            drErr["iID"] = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColiID));
                            drErr["sErr"] = sErrInfo;
                            dtErr.Rows.Add(drErr);

                            sErr = sErr + "行" + (i + 1).ToString() + "" + sErrInfo + "\n";
                            continue;
                        }

                        bend = BaseFunction.ReturnBool(dr[0]["bend"]);
                        if (!bend)
                        {
                            string sErrInfo = "会计科目不是末级";
                            DataRow drErr = dtErr.NewRow();
                            drErr["iID"] = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColiID));
                            drErr["sErr"] = sErrInfo;
                            dtErr.Rows.Add(drErr);

                            sErr = sErr + "行" + (i + 1).ToString() + "" + sErrInfo + "\n";
                            continue;
                        }

                        //借方
                        if (!bproperty)
                        {
                            model.md = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColmoney));
                            model.md_f = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColmoney));
                            model.nfrat = 1;
                            model.nd_s = 0;
                            model.nc_s = 0;
                        }
                        else
                        {
                            model.mc = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColmoney));
                            model.mc_f = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColmoney));
                            model.nfrat = 1;
                            model.nd_s = 0;
                            model.nc_s = 0;
                        }

                        bperson = BaseFunction.ReturnBool(dr[0]["bperson"]);
                        if (bperson)
                        {
                            string sPsn = gridView1.GetRowCellValue(i, gridColcPersonCode).ToString().Trim();
                            if (sPsn == "")
                            {
                                string sErrInfo = "必须有人员";
                                DataRow drErr = dtErr.NewRow();
                                drErr["iID"] = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColiID));
                                drErr["sErr"] = sErrInfo;
                                dtErr.Rows.Add(drErr);

                                sErr = sErr + "行" + (i + 1).ToString() + "" + sErrInfo + "\n";
                                continue;
                            }
                            sSQL = @"select * from View_Pserson where cPersoncode = '{0}' or cPersonname = '{0}'";
                            sSQL = string.Format(sSQL, sPsn);
                            DataTable dtPerson = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dtPerson == null || dtPerson.Rows.Count == 0)
                            {
                                string sErrInfo = "人员不正确";
                                DataRow drErr = dtErr.NewRow();
                                drErr["iID"] = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColiID));
                                drErr["sErr"] = sErrInfo;
                                dtErr.Rows.Add(drErr);

                                sErr = sErr + "行" + (i + 1).ToString() + "" + sErrInfo + "\n";
                                continue;
                            }
                            model.cperson_id = sPsn;
                        }


                        bcus = BaseFunction.ReturnBool(dr[0]["bcus"]);
                        if (bcus)
                        {
                            string sCuscode = gridView1.GetRowCellValue(i, gridColcCusCode).ToString().Trim();
                            if (sCuscode == "")
                            {
                                string sErrInfo = "必须有客户";
                                DataRow drErr = dtErr.NewRow();
                                drErr["iID"] = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColiID));
                                drErr["sErr"] = sErrInfo;
                                dtErr.Rows.Add(drErr);

                                sErr = sErr + "行" + (i + 1).ToString() + "" + sErrInfo + "\n";
                                continue;
                            }
                            sSQL = @"select * from View_Customer where cCusCode = '{0}' or cCusName = '{0}'";
                            sSQL = string.Format(sSQL, sCuscode);
                            DataTable dtCustomer = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dtCustomer == null || dtCustomer.Rows.Count == 0)
                            {
                                string sErrInfo = "客户不正确";
                                DataRow drErr = dtErr.NewRow();
                                drErr["iID"] = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColiID));
                                drErr["sErr"] = sErrInfo;
                                dtErr.Rows.Add(drErr);

                                sErr = sErr + "行" + (i + 1).ToString() + "" + sErrInfo + "\n";
                                continue;
                            }
                            model.ccus_id = sCuscode;
                        }


                        bsup = BaseFunction.ReturnBool(dr[0]["bsup"]);
                        if (bsup)
                        {
                            string sVencode = gridView1.GetRowCellValue(i, gridColcVenCode).ToString().Trim();
                            if (sVencode == "")
                            {
                                string sErrInfo = "必须有供应商";
                                DataRow drErr = dtErr.NewRow();
                                drErr["iID"] = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColiID));
                                drErr["sErr"] = sErrInfo;
                                dtErr.Rows.Add(drErr);

                                sErr = sErr + "行" + (i + 1).ToString() + "" + sErrInfo + "\n";
                                continue;
                            }
                            sSQL = @"select * from View_Vendor where CVenCode = '{0}' or cVenName = '{0}'";
                            sSQL = string.Format(sSQL, sVencode);
                            DataTable dtVendor = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dtVendor == null || dtVendor.Rows.Count == 0)
                            {
                                string sErrInfo = "供应商不正确";
                                DataRow drErr = dtErr.NewRow();
                                drErr["iID"] = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColiID));
                                drErr["sErr"] = sErrInfo;
                                dtErr.Rows.Add(drErr);

                                sErr = sErr + "行" + (i + 1).ToString() + "" + sErrInfo + "\n";
                                continue;
                            }
                            model.csup_id = sVencode;
                        }


                        bdept = BaseFunction.ReturnBool(dr[0]["bdept"]);
                        if (bsup)
                        {
                            string sdept = gridView1.GetRowCellValue(i, gridColcDepCode).ToString().Trim();
                            if (sdept == "")
                            {
                                string sErrInfo = "必须有部门";
                                DataRow drErr = dtErr.NewRow();
                                drErr["iID"] = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColiID));
                                drErr["sErr"] = sErrInfo;
                                dtErr.Rows.Add(drErr);

                                sErr = sErr + "行" + (i + 1).ToString() + "" + sErrInfo + "\n";
                                continue;
                            }
                            sSQL = @"select * from View_Department where cDepCode = '{0}' or cDepName = '{0}'";
                            sSQL = string.Format(sSQL, sdept);
                            DataTable dtDept = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dtDept == null || dtDept.Rows.Count == 0)
                            {
                                string sErrInfo = "部门不正确";
                                DataRow drErr = dtErr.NewRow();
                                drErr["iID"] = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColiID));
                                drErr["sErr"] = sErrInfo;
                                dtErr.Rows.Add(drErr);

                                sErr = sErr + "行" + (i + 1).ToString() + "" + sErrInfo + "\n";
                                continue;
                            }
                            model.cdept_id = sdept;
                        }


                        model.bdelete = false;
                        model.doutbilldate = model.dbill_date;
                        model.bvouchedit = true;
                        model.bvouchAddordele = false;
                        model.bvouchmoneyhold = false;
                        model.bvalueedit = true;
                        model.bcodeedit = true;
                        model.bPCSedit = true;
                        model.bDeptedit = true;
                        model.bItemedit = true;
                        model.bCusSupInput = false;
                        model.bFlagOut = false;
                        model.RowGuid = Guid.NewGuid().ToString();
                        model.iyear = iYear;
                        model.iYPeriod = iMonth;
                        model.tvouchtime = DateTime.Now;

                        dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.GL_accvouch();
                        sSQL = dal.Add(model);
                        iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        #endregion

                        sSQL = @"
update _GL_accvouch_FromERP set sStatus = 1,User_Load = '{0}', dDate_Load = getdate()
    ,GL_accvouch_ino_id = '{1}', GL_accvouch_csign = '{2}'
where iID = {3}
";

                        sSQL = string.Format(sSQL, sUserName, ino_id, scsign, gridView1.GetRowCellValue(i, gridColiID).ToString().Trim());
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    if (sErr.Length > 0)
                    {
                        FrmMsgBox f = new FrmMsgBox();
                        f.Text = "存在错误数据，是否继续？";
                        f.richTextBox1.Text = sErr;
                        f.btnCancel.Text = "否";
                        f.btnOK.Text = "是";

                        if (f.ShowDialog() == DialogResult.OK)
                        {
                            for (int ii = 0; ii < dtErr.Rows.Count; ii++)
                            {
                                sSQL = @"
update _GL_accvouch_FromERP set [sStatus] = 2 ,sErrInfo = '{1}' where iID = {0}
";
                                sSQL = string.Format(sSQL, BaseFunction.ReturnLong(dtErr.Rows[ii]["iID"]), dtErr.Rows[ii]["sErr"].ToString().Trim());
                                iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                        }
                        else
                        {
                            throw new Exception(sErr);
                        }
                    }

                    if (iCount > 0)
                    {
                        tran.Commit();
                        MessageBox.Show("保存成功");
                        btnSel_Click(null, null);
                    }
                    else
                    {
                        throw new Exception("没有数据");
                    }
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "提示";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }


        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int iRow = gridView1.FocusedRowHandle;
                bool b = BaseFunction.ReturnBool(gridView1.GetRowCellValue(iRow, gridColbChoose));

                gridView1.SetRowCellValue(iRow, gridColbChoose, !b);

            }
            catch { }
        }

        int iYear = 0;
        int iMonth = 0;
        private void btnSel_Click(object sender, EventArgs e)
        {
            if (DateTime.Now > Convert.ToDateTime("2019-04-01"))
            {
                return;
            }

            try
            {
                if (lookUpEditPeriod.EditValue == null || lookUpEditPeriod.Text.Trim() == "")
                {
                    throw new Exception("请选择期间，如无法选择请通知导入业务数据");
                }

                iYear = BaseFunction.ReturnInt(lookUpEditPeriod.Text.Trim().Substring(0, 4));
                iMonth = BaseFunction.ReturnInt(lookUpEditPeriod.Text.Trim().Substring(5, 2));

                chkAll.Checked = false;

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {

                    string sSQL = @"
SELECT distinct cast(0 as bit) as bChoose, a.iID, a.dDate, a.csign, a.ino_id, a.cdigest
	, a.ccode,code.ccode_name
	, a.ccode_equal,code2.ccode_name as ccode_name2
	,a.[money], a.cexch_name, a.nfrat, a.Qty, a.cItem_id
	, a.cDepCode,dep.cDepName
    , a.cPersonCode ,p.cPersonName
	, a.cCusCode,cus.cCusName
	, a.cVenCode,v.cVenName
	, a.dtmCreate, a.sStatus, a.User_Load, a.dDate_Load,a.[GL_accvouch_ino_id],a.[GL_accvouch_csign]
FROM      _GL_accvouch_FromERP a
	left join code on code.ccode = a.ccode
	left join code code2 on a.ccode_equal = code2.ccode
	left join Person p on p.cPersonCode = a.cPersonCode 
	left join Customer cus on cus.ccuscode = a.ccuscode
	left join Vendor v on v.cVenCode = a.cVenCode
	left join Department dep on dep.cDepCode = a.cDepCode
where 1=1 and isnull(sStatus,0) = 0
order by a.dDate,a.iID
";
                    sSQL = sSQL.Replace("1=1", "1=1 and year(dDate) = " + iYear.ToString() + "");
                    sSQL = sSQL.Replace("1=1", "1=1 and month(dDate) = " + iMonth.ToString() + "");

                    if (txt摘要.Text.Trim() != "")
                    {
                        sSQL = sSQL.Replace("1=1", "1=1 and cdigest like '%" + txt摘要.Text.Trim() + "%'");
                    }
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    gridControl1.DataSource = dt;
                    tran.Commit();
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败，原因：" + ee.Message);
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridColbChoose, chkAll.Checked);
                }
            }
            catch (Exception ee)
            { }
        }
    }
}
