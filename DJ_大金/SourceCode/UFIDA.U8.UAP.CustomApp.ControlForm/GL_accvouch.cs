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

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        bool b = BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColbChoose));
                        if (!b)
                            continue;

                        bool bUsed = BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColbUsed));
                        if (bUsed)
                            continue;

                        string sDate = gridView1.GetRowCellValue(i, gridColBLDAT).ToString().Trim();


                        DateTime dtmDate = BaseFunction.ReturnDate(sDate.Substring(0, 4) + "-" + sDate.Substring(4, 2) + "-" + sDate.Substring(6, 2));
                        if (dtmDate < Convert.ToDateTime("2018-01-01"))
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "日期不正确\n";
                            continue;
                        }

                        int iYear = dtmDate.Year;
                        int iMonth = dtmDate.Month;

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



                        int inid = 0;
                        int iCount = 0;

                        sSQL = @"select * from dsign where csign = '{0}'";
                        sSQL = string.Format(sSQL, "记");
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


                        #region 第一行

                        inid += 1;
                        Model.GL_accvouch model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.GL_accvouch();
                        model.iperiod = iMonth;

                        model.csign = scsign;
                        model.isignseq = BaseFunction.ReturnInt(dtdsign.Rows[0]["isignseq"]);


                        model.ino_id = ino_id;

                        iRow = 1;
                        model.inid = iRow;
                        model.dbill_date = dtmDate;
                        model.idoc = -1;
                        model.cbill = sUserName;
                        model.ibook = 0;
                        model.cdigest = gridView1.GetRowCellValue(i, gridColSGTXT).ToString().Trim(); ;

                        sSQL = @"
select b.* 
from [_科目对照] a
	inner join code b on a.会计科目 = b.ccode and b.iyear = {1}
where 对照科目 = '{0}'
";
                        sSQL = string.Format(sSQL, gridView1.GetRowCellValue(i, gridColNEWKO), iYear);
                        DataTable dtCode = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtCode != null && dtCode.Rows.Count == 1)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "会计科目不正确，请设置对照档案\n";
                            continue;
                        }

                        if (!BaseFunction.ReturnBool(dtCode.Rows[0]["bend"]))
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "会计科目不是末级科目，请设置对照档案\n";
                            continue;
                        }

                        model.ccode = dtCode.Rows[0]["会计科目"].ToString().Trim();


                        int NEWBS = BaseFunction.ReturnInt(gridView1.GetRowCellValue(i, gridColNEWBS).ToString().Trim());
                        //借方
                        if (NEWBS == 40)
                        {
                            model.md = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColWRBTR));
                            model.md_f = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColWRBTR));
                            model.nfrat = 1;
                            model.nd_s = 0;
                            model.nc_s = 0;
                        }
                        else
                        {
                            model.mc = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColWRBTR));
                            model.mc_f = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColWRBTR));
                            model.nfrat = 1;
                            model.nd_s = 0;
                            model.nc_s = 0;
                        }

                        bool bperson = BaseFunction.ReturnBool(dtCode.Rows[0]["bperson"]);
                        if (bperson)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "必须有人员\n";
                            continue;
                        }

                        bool bcus = BaseFunction.ReturnBool(dtCode.Rows[0]["bcus"]);
                        if (bcus)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "必须有客户\n";
                            continue;
                        }


                        bool bsup = BaseFunction.ReturnBool(dtCode.Rows[0]["bsup"]);
                        if (bsup)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "必须有供应商\n";
                            continue;
                        }


                        bool bdept = BaseFunction.ReturnBool(dtCode.Rows[0]["bdept"]);
                        if (bsup)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "必须有部门\n";
                            continue;
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

                        gridView1.SetRowCellValue(i, gridColbUsed, true);
                        #endregion

                        string XBLNR = gridView1.GetRowCellValue(i, gridColXBLNR).ToString().Trim();

                        for (int j = i + 1; j < gridView1.RowCount; j++)
                        {
                            string XBLNR_2 = gridView1.GetRowCellValue(j, gridColXBLNR).ToString().Trim();

                            if (XBLNR != XBLNR_2)
                                continue;

                            model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.GL_accvouch();
                            model.iperiod = iMonth;

                            model.csign = scsign;
                            model.isignseq = BaseFunction.ReturnInt(dtdsign.Rows[0]["isignseq"]);


                            model.ino_id = ino_id;

                            iRow += 1;
                            model.inid = iRow;
                            model.dbill_date = dtmDate;
                            model.idoc = -1;
                            model.cbill = sUserName;
                            model.ibook = 0;
                            model.cdigest = gridView1.GetRowCellValue(j, gridColSGTXT).ToString().Trim(); ;

                            sSQL = @"
select b.* 
from [_科目对照] a
	inner join code b on a.会计科目 = b.ccode and b.iyear = {1}
where 对照科目 = '{0}'
";
                            sSQL = string.Format(sSQL, gridView1.GetRowCellValue(j, gridColNEWKO), iYear);
                            dtCode = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dtCode != null && dtCode.Rows.Count == 1)
                            {
                                sErr = sErr + "行" + (j + 1).ToString() + "会计科目不正确，请设置对照档案\n";
                                continue;
                            }

                            if (!BaseFunction.ReturnBool(dtCode.Rows[0]["bend"]))
                            {
                                sErr = sErr + "行" + (j + 1).ToString() + "会计科目不是末级科目，请设置对照档案\n";
                                continue;
                            }

                            model.ccode = dtCode.Rows[0]["会计科目"].ToString().Trim();


                            NEWBS = BaseFunction.ReturnInt(gridView1.GetRowCellValue(j, gridColNEWBS).ToString().Trim());
                            //借方
                            if (NEWBS == 40)
                            {
                                model.md = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(j, gridColWRBTR));
                                model.md_f = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(j, gridColWRBTR));
                                model.nfrat = 1;
                                model.nd_s = 0;
                                model.nc_s = 0;
                            }
                            else
                            {
                                model.mc = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(j, gridColWRBTR));
                                model.mc_f = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(j, gridColWRBTR));
                                model.nfrat = 1;
                                model.nd_s = 0;
                                model.nc_s = 0;
                            }

                            bperson = BaseFunction.ReturnBool(dtCode.Rows[0]["bperson"]);
                            if (bperson)
                            {
                                sErr = sErr + "行" + (j + 1).ToString() + "必须有人员\n";
                                continue;
                            }

                            bcus = BaseFunction.ReturnBool(dtCode.Rows[0]["bcus"]);
                            if (bcus)
                            {
                                sErr = sErr + "行" + (j + 1).ToString() + "必须有客户\n";
                                continue;
                            }


                            bsup = BaseFunction.ReturnBool(dtCode.Rows[0]["bsup"]);
                            if (bsup)
                            {
                                sErr = sErr + "行" + (j + 1).ToString() + "必须有供应商\n";
                                continue;
                            }


                            bdept = BaseFunction.ReturnBool(dtCode.Rows[0]["bdept"]);
                            if (bsup)
                            {
                                sErr = sErr + "行" + (j + 1).ToString() + "必须有部门\n";
                                continue;
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

                            gridView1.SetRowCellValue(j, gridColbUsed, true);
                        }
                       

                    }
                    if (sErr.Length != 0)
                    {
                        throw new Exception(sErr);
                    }

                    tran.Commit();
                    MessageBox.Show("保存成功");
                    btnSel_Click(null, null);
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


        private void btnSel_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel|*.xls|Excel|*.xlsx|All File|*.*";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                string fName = openFileDialog.FileName;

                ClsExcel clsExcel = ClsExcel.Instance();

                string sSQL = @"
select *
from [Sheet1$]
";
                DataTable dt = clsExcel.ExcelToDT(fName, sSQL, true);

                DataColumn dc = new DataColumn();
                dc.ColumnName = "bChoose";
                dc.DataType = Type.GetType("System.Boolean");
                dc.DefaultValue = false;
                dt.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "bUsed";
                dc.DataType = Type.GetType("System.Boolean");
                dc.DefaultValue = false;
                dt.Columns.Add(dc);

                gridControl1.DataSource = dt;
            }
            catch (Exception ee)
            { 
                MessageBox.Show(ee.Message);
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

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == gridColbChoose)
                {
                    string XBLNR = gridView1.GetRowCellValue(e.RowHandle, gridColXBLNR).ToString().Trim();
                    bool bChoose = BaseFunction.ReturnBool(gridView1.GetRowCellValue(e.RowHandle, gridColbChoose));

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        string XBLNR_2 = gridView1.GetRowCellValue(i, gridColXBLNR).ToString().Trim();
                        bool bChoose_2 = BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColbChoose));

                        if (i == e.RowHandle)
                            continue;

                        if (XBLNR == XBLNR_2 && bChoose != bChoose_2)
                        {
                            gridView1.SetRowCellValue(i, gridColbChoose, bChoose);
                        }
                    }
                }
            }
            catch{}
        }
    }
}
