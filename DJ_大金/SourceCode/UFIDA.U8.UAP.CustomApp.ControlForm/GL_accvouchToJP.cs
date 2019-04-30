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
    public partial class GL_accvouchToJP : UserControl
    {        
        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        string sDataFrom = "ufdata_200_2018";
        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                iYear = BaseFunction.ReturnDate(sLogDate).Year;
                iMonth = BaseFunction.ReturnDate(sLogDate).Month;

                DbHelperSQL.connectionString = Conn;

                string sSQL = @"select * from _Code where cCode like 'ufdata_%'";
                DataTable dt = DbHelperSQL.Query(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("请设置来源数据库“_Code”");
                }
                sDataFrom = dt.Rows[0]["cCode"].ToString().Trim();
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        int iYear = 0;
        int iMonth = 0;

        public GL_accvouchToJP()
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

                    int iCount = 0;

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        bool b = BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColbChoose));
                        if (!b)
                            continue;

                        //int i_id_from = BaseFunction.ReturnInt(gridView1.GetRowCellValue(i, gridColi_id));

                        string scsign = gridView1.GetRowCellValue(i, gridColcsign).ToString().Trim();
                        int ino_id = BaseFunction.ReturnInt(gridView1.GetRowCellValue(i, gridColino_id));
                        sSQL = "select * from {4}..GL_accvouch where csign = '{0}' and ino_id = '{1}' and iyear = {2} and iPeriod = {3} ";
                        sSQL = string.Format(sSQL, scsign, ino_id, iYear, iMonth, sDataFrom);
                        DataTable dtGL_accvouch = DbHelperSQL.ExecuteDataset(tran,CommandType.Text,sSQL).Tables[0];

                        for (int j = 0; j < dtGL_accvouch.Rows.Count; j++)
                        {
                            //  , , , , , ccheck, cbook, ibook, ccashier, iflag, , 
                            //iBG_OverFlag, cBG_Auditor, dBG_AuditTime, cBG_AuditOpinion, bWH_BgFlag, ssxznum, CErrReason, BG_AuditRemark, 
                            //cBudgetBuffer, iBG_ControlResult, NCVouchID, daudit_date, RowGuid, cBankReconNo, , , wllqDate, 
                            //wllqPeriod, tvouchtime, cblueoutno_id, 

                            Model.GL_accvouch mod = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.GL_accvouch();
                            mod.iperiod = BaseFunction.ReturnInt(dtGL_accvouch.Rows[j]["iperiod"]);
                            mod.csign = dtGL_accvouch.Rows[j]["csign"].ToString().Trim();
                            mod.isignseq = BaseFunction.ReturnInt(dtGL_accvouch.Rows[j]["isignseq"]);
                            mod.ino_id = BaseFunction.ReturnInt(dtGL_accvouch.Rows[j]["ino_id"]);
                            mod.inid = BaseFunction.ReturnInt(dtGL_accvouch.Rows[j]["inid"]);
                            mod.dbill_date = BaseFunction.ReturnDate(dtGL_accvouch.Rows[j]["dbill_date"]);
                            mod.idoc = BaseFunction.ReturnInt(dtGL_accvouch.Rows[j]["idoc"]);
                            mod.cbill = dtGL_accvouch.Rows[j]["cbill"].ToString().Trim();
                            mod.ibook = 0;
                            mod.iflag = BaseFunction.ReturnInt(dtGL_accvouch.Rows[j]["iflag"]);
                            mod.ctext1 = dtGL_accvouch.Rows[j]["ctext1"].ToString().Trim();
                            mod.ctext2 = dtGL_accvouch.Rows[j]["ctext2"].ToString().Trim();
                            mod.cdigest = dtGL_accvouch.Rows[j]["cdigest"].ToString().Trim();
                            mod.ccode = dtGL_accvouch.Rows[j]["ccode"].ToString().Trim();

                            sSQL = @"
SELECT cast(0 as bit) as choose,b.iID
    ,a.ccode as 会计科目,a.ccode_name, b.对照科目,'edit' as iSave,b.Remark 
FROM code a LEFT JOIN [_科目对照] b ON a.ccode = b.会计科目
WHERE ISNULL(bend ,0) = 1 and a.iyear = {0} and b.对照科目 = '{1}'
ORDER BY a.ccode,b.iID
";
                            sSQL = string.Format(sSQL, iYear, mod.ccode);
                            DataTable dtCode = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dtCode == null || dtCode.Rows.Count == 0)
                            {
                                throw new Exception("请设置科目对照:" + mod.ccode);
                            }
                            mod.ccode = dtCode.Rows[0]["会计科目"].ToString().Trim();
                            mod.cexch_name = dtGL_accvouch.Rows[j]["cexch_name"].ToString().Trim();
                            mod.md = BaseFunction.ReturnDecimal(dtGL_accvouch.Rows[j]["md"]);
                            mod.mc = BaseFunction.ReturnDecimal(dtGL_accvouch.Rows[j]["mc"]);
                            mod.md_f = BaseFunction.ReturnDecimal(dtGL_accvouch.Rows[j]["md_f"]);
                            mod.mc_f = BaseFunction.ReturnDecimal(dtGL_accvouch.Rows[j]["mc_f"]);
                            mod.nfrat = BaseFunction.ReturnDecimal(dtGL_accvouch.Rows[j]["nfrat"]);
                            mod.nd_s = BaseFunction.ReturnDecimal(dtGL_accvouch.Rows[j]["nd_s"]);
                            mod.nc_s = BaseFunction.ReturnDecimal(dtGL_accvouch.Rows[j]["nc_s"]);
                            mod.csettle = dtGL_accvouch.Rows[j]["csettle"].ToString().Trim();
                            mod.cn_id = dtGL_accvouch.Rows[j]["cn_id"].ToString().Trim();
                            mod.dt_date = BaseFunction.ReturnDate(dtGL_accvouch.Rows[j]["dt_date"]);
                            mod.iyear = BaseFunction.ReturnInt(dtGL_accvouch.Rows[j]["iyear"]);
                            mod.iYPeriod = BaseFunction.ReturnInt(dtGL_accvouch.Rows[j]["iYPeriod"]);
                            mod.cDefine15 = BaseFunction.ReturnInt(dtGL_accvouch.Rows[j]["i_id"]);
                            mod.ccodeexch_equal = dtGL_accvouch.Rows[j]["ccodeexch_equal"].ToString().Trim();
                            mod.ccode_equal = dtGL_accvouch.Rows[j]["ccode_equal"].ToString().Trim();

                            //, , , , , , , , , , , , , , cdept_id, cperson_id, 
                            //ccus_id, csup_id, citem_id, citem_class, cname, , iflagbank, iflagPerson, bdelete, coutaccset, ioutyear, 
                            //coutsysname, coutsysver, doutbilldate, ioutperiod, coutsign, coutno_id, doutdate, coutbillsign, coutid, bvouchedit, 
                            //bvouchAddordele, bvouchmoneyhold, bvalueedit, bcodeedit, ccodecontrol, bPCSedit, bDeptedit, bItemedit, 
                            //bCusSupInput, cDefine1, cDefine2, cDefine3, cDefine4, cDefine5, cDefine6, cDefine7, cDefine8, cDefine9, cDefine10, 
                            //cDefine11, cDefine12, cDefine13, cDefine14, , cDefine16, dReceive, cWLDZFlag, dWLDZTime, bFlagOut, 



                            UFIDA.U8.UAP.CustomApp.ControlForm.DAL.GL_accvouch dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.GL_accvouch();
                            sSQL = dal.Add(mod);
                            iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        }

                        //                        sSQL = @"select * from dsign where csign = '{0}'";
                        //                        sSQL = string.Format(sSQL, "记");
                        //                        DataTable dtdsign = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        //                        if (dtdsign == null || dtdsign.Rows.Count == 0)
                        //                        {
                        //                            sErr = sErr + "凭证类别不正确\n";
                        //                        }

                        //                        if (ino_id == 0)
                        //                        {
                        //                            sSQL = @"
                        //select isnull(max(ino_id),0) as ino_id from GL_accvouch where csign = '{0}' and iyear = {1} and iperiod = {2}
                        //";
                        //                            sSQL = string.Format(sSQL, scsign, iYear, iMonth);
                        //                            DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        //                            if (dtTemp == null || dtTemp.Rows.Count == 0)
                        //                            {
                        //                                ino_id = 0;
                        //                            }
                        //                            else
                        //                            {
                        //                                ino_id = BaseFunction.ReturnInt(dtTemp.Rows[0]["ino_id"]);
                        //                            }
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
               string  sSQL = @"
select a.csign + '-' + RIGHT('0000' + cast(a.ino_id as varchar(4)),4) as csignid,a.csign, a.ino_id
	,max(a.cdigest) as cdigest,sum(a.[md]) as md,sum(a.[mc]) as mc
	,max(a.cbill) as cbill ,max(a.cbook) as cbook 
from {2}..GL_accvouch a left join GL_accvouch b on isnull(a.i_id,0) = isnull(b.cDefine15,0)
where a.iyear = {0} and a.iperiod = {1} and  isnull(b.cDefine15,0) = 0
group by a.csign ,a.ino_id 
order by a.csign,a.ino_id
";
                sSQL = string.Format(sSQL, iYear, iMonth, sDataFrom);
                DataTable dt = DbHelperSQL.Query(sSQL);

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

    }
}
