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
    public partial class FrockClamp : UserControl
    {
        TH.BaseClass.GetBaseData getBaseData = new GetBaseData();
        clsUserRigth clsUserRight = new clsUserRigth();
        
        string sProPath = Application.StartupPath;

        UFIDA.U8.UAP.CustomApp.ControlForm.RepBaseGrid Rep = new RepBaseGrid();

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        private void SetLookUp()
        {

        }



        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                DbHelperSQL.connectionString = Conn;

                GetGrid();
            }
            catch
            { 
            
            }
        }

        public FrockClamp()
        {
            InitializeComponent();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (!clsUserRight.chkRight(sUserID, 2090))
                    throw new Exception("没有权限");

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
                if (!clsUserRight.chkRight(sUserID, 2020))
                    throw new Exception("没有权限");

                string sErr = "";
                int iCount = 0;

                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }


                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {

                    string sSQL = "select getdate()";
                    DateTime dNow = BaseFunction.ReturnDate(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                    DateTime dNowDate = BaseFunction.ReturnDate(dNow.ToString("yyyy-MM-dd"));

                    int iRowCou = 0;
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (!BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColbChoose)))
                            continue;

                        if (gridView1.GetRowCellValue(i, gridColInvName).ToString().Trim() == "")
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "工装名称必须填写\n";
                            continue;
                        }
                        if (gridView1.GetRowCellValue(i, gridColLC).ToString().Trim() == "" && gridView1.GetRowCellValue(i, gridColTimes).ToString().Trim() == "")
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "使用寿命或者寿命次数必须至少填写一项\n";
                            continue;
                        }
                        if (gridView1.GetRowCellValue(i, gridColLC).ToString().Trim() != "" && BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridColLC)) < DateTime.Today)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "使用寿命必须超过今天\n";
                            continue;
                        }
                        if (gridView1.GetRowCellValue(i, gridColTimes).ToString().Trim() != "" && BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColTimes)) < 0)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "寿命次数必须不小于0\n";
                            continue;
                        }

                        sSQL = "select * from _FrockClamp where SerialNo = N'111111'";
                        sSQL = sSQL.Replace("111111", gridView1.GetRowCellValue(i, gridColSerialNo).ToString().Trim());
                        DataTable dtHav = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        if (gridView1.GetRowCellValue(i, gridColsState).ToString().Trim() == "add")
                        {
                            if (dtHav != null && dtHav.Rows.Count > 0)
                            {
                                sErr = sErr + "行" + (i + 1).ToString() + "已经存在\n";
                                continue;
                            }
                        }

                        if (dtHav != null && dtHav.Rows.Count > 0)
                        {
                            if (dtHav.Rows[0]["Auditer"].ToString().Trim() != "")
                            {
                                sErr = sErr + "行" + (i + 1).ToString() + "已经审核\n";
                                continue;
                            }
                            if (dtHav.Rows[0]["Closed"].ToString().Trim() != "")
                            {
                                sErr = sErr + "行" + (i + 1).ToString() + "已经关闭\n";
                                continue;
                            }
                        }

                        Model._FrockClamp model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._FrockClamp();
                        string sSerialNo = gridView1.GetRowCellValue(i, gridColSerialNo).ToString().Trim();
                        string sSerDate = dNowDate.ToString("yyMMdd");

                        if (sSerialNo == "")
                        {
                            long iSerialNo = 0;

                            sSQL = "select max(SerialNo) as SerialNo from [_FrockClamp] where SerialNo like '111111%'";
                            sSQL = sSQL.Replace("111111", sSerDate);
                            DataTable dtSerialNo = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dtSerialNo == null && dtSerialNo.Rows.Count == 0)
                            {
                                iSerialNo = 1;
                            }
                            else
                            {
                                string s = dtSerialNo.Rows[0]["SerialNo"].ToString().Trim();
                                if (s == "")
                                {
                                    s = "0";
                                }
                                if (s.Length > 6)
                                {
                                    iSerialNo = BaseFunction.ReturnLong(s.Substring(6));
                                }
                                else
                                {
                                    iSerialNo = BaseFunction.ReturnLong(s);
                                }
                                iSerialNo += 1;
                            }

                            sSerialNo = iSerialNo.ToString().Trim();
                            while (sSerialNo.Length < 4)
                            {
                                sSerialNo = "0" + sSerialNo;
                            }
                            sSerialNo = sSerDate + sSerialNo;
                        }

                        model.SerialNo = sSerialNo;
                        model.InvName = gridView1.GetRowCellValue(i, gridColInvName).ToString().Trim();
                        model.InvStd = gridView1.GetRowCellValue(i, gridColInvStd).ToString().Trim();

                        if (gridView1.GetRowCellValue(i, gridColTimes).ToString().Trim() != "")
                        {
                            model.Times = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColTimes));
                        }
                        if (gridView1.GetRowCellValue(i, gridColLC).ToString().Trim() != "")
                        {
                            model.LC = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridColLC));
                        }
                        model.Service = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColService));

                        if (gridView1.GetRowCellValue(i, gridColS1).ToString().Trim() != "")
                        {
                            model.S1 = gridView1.GetRowCellValue(i, gridColS1).ToString().Trim();
                        }
                        if (gridView1.GetRowCellValue(i, gridColS2).ToString().Trim() != "")
                        {
                            model.S2 = gridView1.GetRowCellValue(i, gridColS2).ToString().Trim();
                        }
                        if (gridView1.GetRowCellValue(i, gridColS3).ToString().Trim() != "")
                        {
                            model.S3 = gridView1.GetRowCellValue(i, gridColS3).ToString().Trim();
                        }
                        if (gridView1.GetRowCellValue(i, gridColS4).ToString().Trim() != "")
                        {
                            model.S4 = gridView1.GetRowCellValue(i, gridColS4).ToString().Trim();
                        }
                        if (gridView1.GetRowCellValue(i, gridColS5).ToString().Trim() != "")
                        {
                            model.S5 = gridView1.GetRowCellValue(i, gridColS5).ToString().Trim();
                        }
                        if (gridView1.GetRowCellValue(i, gridColS6).ToString().Trim() != "")
                        {
                            model.S6 = gridView1.GetRowCellValue(i, gridColS6).ToString().Trim();
                        }
                        if (gridView1.GetRowCellValue(i, gridColS7).ToString().Trim() != "")
                        {
                            model.S7 = gridView1.GetRowCellValue(i, gridColS7).ToString().Trim();
                        }
                        if (gridView1.GetRowCellValue(i, gridColS8).ToString().Trim() != "")
                        {
                            model.S8 = gridView1.GetRowCellValue(i, gridColS8).ToString().Trim();
                        }
                        if (gridView1.GetRowCellValue(i, gridColS9).ToString().Trim() != "")
                        {
                            model.S9 = gridView1.GetRowCellValue(i, gridColS9).ToString().Trim();
                        }

                        if (gridView1.GetRowCellValue(i, gridColD1).ToString().Trim() != "")
                        {
                            model.D1 = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColD1));
                        }
                        if (gridView1.GetRowCellValue(i, gridColD2).ToString().Trim() != "")
                        {
                            model.D2 = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColD2));
                        }
                        if (gridView1.GetRowCellValue(i, gridColD3).ToString().Trim() != "")
                        {
                            model.D3 = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColD3));
                        }
                        if (gridView1.GetRowCellValue(i, gridColD4).ToString().Trim() != "")
                        {
                            model.D4 = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColD4));
                        }
                        if (gridView1.GetRowCellValue(i, gridColD5).ToString().Trim() != "")
                        {
                            model.D5 = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColD5));
                        }
                        if (gridView1.GetRowCellValue(i, gridColD6).ToString().Trim() != "")
                        {
                            model.D6 = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColD6));
                        }
                        if (gridView1.GetRowCellValue(i, gridColD7).ToString().Trim() != "")
                        {
                            model.D7 = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColD7));
                        }
                        if (gridView1.GetRowCellValue(i, gridColD8).ToString().Trim() != "")
                        {
                            model.D8 = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColD8));
                        }
                        if (gridView1.GetRowCellValue(i, gridColD9).ToString().Trim() != "")
                        {
                            model.D9 = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColD9));
                        }
                        if (gridView1.GetRowCellValue(i, gridColDate1).ToString().Trim() != "")
                        {
                            model.Date1 = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridColDate1));
                        }
                        if (gridView1.GetRowCellValue(i, gridColDate2).ToString().Trim() != "")
                        {
                            model.Date2 = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridColDate2));
                        }
                        if (gridView1.GetRowCellValue(i, gridColDate3).ToString().Trim() != "")
                        {
                            model.Date3 = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridColDate3));
                        }
                        if (gridView1.GetRowCellValue(i, gridColDate4).ToString().Trim() != "")
                        {
                            model.Date4 = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridColDate4));
                        }
                        if (gridView1.GetRowCellValue(i, gridColDate5).ToString().Trim() != "")
                        {
                            model.Date5 = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridColDate5));
                        }
                        if (gridView1.GetRowCellValue(i, gridColDate6).ToString().Trim() != "")
                        {
                            model.Date6 = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridColDate6));
                        }
                        if (gridView1.GetRowCellValue(i, gridColDate7).ToString().Trim() != "")
                        {
                            model.Date7 = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridColDate7));
                        }
                        if (gridView1.GetRowCellValue(i, gridColDate8).ToString().Trim() != "")
                        {
                            model.Date8 = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridColDate8));
                        }
                        if (gridView1.GetRowCellValue(i, gridColDate9).ToString().Trim() != "")
                        {
                            model.Date9 = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridColDate9));
                        }

                        if (gridView1.GetRowCellValue(i, gridColsState).ToString().Trim() == "add")
                        {
                            model.Creater = sUserName;
                            model.CreaterDate = dNowDate;

                            DAL._FrockClamp dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._FrockClamp();
                            sSQL = dal.Add(model);
                            iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        if (gridView1.GetRowCellValue(i, gridColsState).ToString().Trim() == "edit")
                        {
                            model.Creater = gridView1.GetRowCellValue(i, gridColCreater).ToString().Trim();
                            model.CreaterDate = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridColCreaterDate));

                            model.Updater = sUserName;
                            model.UpdateDate = dNowDate;
                            DAL._FrockClamp dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._FrockClamp();
                            sSQL = dal.Update(model);
                            iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                    }

                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }

                    if (iCount > 0)
                    {
                        tran.Commit();
                        MessageBox.Show("OK\n");

                        GetGrid();
                    }
                    else
                    {
                        throw new Exception("no data");
                    }
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void GetGrid()
        {
            int iRow = gridView1.FocusedRowHandle;

            chkAll.Checked = false;

            string sSQL = @"
select iID,count(*) as 维修次数 into #a from _Maintenances group by iID
select cast(0 as bit) as bChoose,'sel' as sState
    , * ,b.维修次数 
from _FrockClamp a left join #a b on a.iID=b.iID
order by CreaterDate,a.iID,SerialNo
";
            DataTable dt = DbHelperSQL.Query(sSQL);
            gridControl1.DataSource = dt;
            gridView1.AddNewRow();

            gridView1.FocusedRowHandle = iRow;
        }

        private void btnSEL_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (!clsUserRight.chkRight(sUserID, 2010))
                    throw new Exception("没有权限");

                GetGrid();
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnAudit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!clsUserRight.chkRight(sUserID, 2040))
                    throw new Exception("没有权限");

                string sErr = "";
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }


                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    int iCou = 0;
                    string sSQL = "select getdate()";
                    DateTime dNow = BaseFunction.ReturnDate(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (!BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColbChoose)))
                            continue;

                        string sSerial = gridView1.GetRowCellValue(i, gridColSerialNo).ToString().Trim();
                        if (sSerial == "")
                            continue;

                        sSQL = "select * from _FrockClamp where SerialNo = N'111111'";
                        sSQL = sSQL.Replace("111111", gridView1.GetRowCellValue(i, gridColSerialNo).ToString().Trim());
                        DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt == null && dt.Rows.Count == 0)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "不存在\n";
                            continue;
                        }

                        if (dt.Rows[0]["Auditer"].ToString().Trim() != "")
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "已审核\n";
                            continue;
                        }

                        if (dt.Rows[0]["Closed"].ToString().Trim() != "")
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "已关闭\n";
                            continue;
                        }
                        if (BaseFunction.ReturnInt( dt.Rows[0]["iState"]) == 2 || BaseFunction.ReturnInt( dt.Rows[0]["iState"]) == 3)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "已经领用\n";
                            continue;
                        }

                        sSQL = "update _FrockClamp set Auditer = N'333333',AuditeDate = N'222222',iState = 1 where SerialNo = N'111111' ";
                        sSQL = sSQL.Replace("111111", sSerial);
                        sSQL = sSQL.Replace("333333", sUserName);
                        sSQL = sSQL.Replace("222222", dNow.ToString("yyyy-MM-dd"));
                        iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    if (sErr != "")
                    {
                        throw new Exception(sErr);
                    }

                    if (iCou > 0)
                    {
                        tran.Commit();
                        MessageBox.Show("OK\n");

                        GetGrid();
                    }
                    else
                    {
                        MessageBox.Show("no data");
                    }
                }
                catch(Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnUnAudit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!clsUserRight.chkRight(sUserID, 2050))
                    throw new Exception("没有权限");

                string sErr = "";
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }


                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    int iCou = 0;

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (!BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColbChoose)))
                            continue;

                        string sSerial = gridView1.GetRowCellValue(i, gridColSerialNo).ToString().Trim();
                        if (sSerial == "")
                            continue;

                        string sSQL = "select * from _FrockClamp where SerialNo = N'111111'";
                        sSQL = sSQL.Replace("111111", gridView1.GetRowCellValue(i, gridColSerialNo).ToString().Trim());
                        DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt == null && dt.Rows.Count == 0)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "不存在\n";
                            continue;
                        }

                        if (dt.Rows[0]["Auditer"].ToString().Trim() == "")
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "未审核\n";
                            continue;
                        }

                        if (dt.Rows[0]["Closed"].ToString().Trim() != "")
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "已关闭\n";
                            continue;
                        }
                        if (BaseFunction.ReturnInt(dt.Rows[0]["iState"]) == 2 || BaseFunction.ReturnInt(dt.Rows[0]["iState"]) == 3)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "已经领用\n";
                            continue;
                        }

                        sSQL = "update _FrockClamp set Auditer = null,AuditeDate = null,iState = 0 where SerialNo = N'111111' ";
                        sSQL = sSQL.Replace("111111", sSerial);
                        iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    if (sErr != "")
                    {
                        throw new Exception(sErr);
                    }
                    if (iCou > 0)
                    {
                        tran.Commit();
                        MessageBox.Show("OK\n");

                        GetGrid();
                    }
                    else
                    {
                        MessageBox.Show("no data");
                    }
                }
                catch(Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (!clsUserRight.chkRight(sUserID, 2070))
                    throw new Exception("没有权限");

                string sErr = "";
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }


                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    int iCou = 0;

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (!BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColbChoose)))
                            continue;

                        string sSerial = gridView1.GetRowCellValue(i, gridColSerialNo).ToString().Trim();
                        if (sSerial == "")
                            continue;

                        string sSQL = "select * from _FrockClamp where SerialNo = '111111'";
                        sSQL = sSQL.Replace("111111", gridView1.GetRowCellValue(i, gridColSerialNo).ToString().Trim());
                        DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt == null && dt.Rows.Count == 0)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "不存在\n";
                            continue;
                        }

                        if (dt.Rows[0]["Auditer"].ToString().Trim() == "")
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "未审核\n";
                            continue;
                        }

                        if (dt.Rows[0]["Closed"].ToString().Trim() == "")
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "未关闭\n";
                            continue;
                        }

                        sSQL = "update _FrockClamp set Closed = null,CloseDate = null,iState = 1 where SerialNo = N'111111' ";
                        sSQL = sSQL.Replace("111111", sSerial);
                        iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    if (sErr != "")
                    {
                        throw new Exception(sErr);
                    }

                    if (iCou > 0)
                    {
                        tran.Commit();
                        MessageBox.Show("OK\n");

                        GetGrid();
                    }
                    else
                    {
                        MessageBox.Show("no data");
                    }
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnClosed_Click(object sender, EventArgs e)
        {

            try
            {
                if (!clsUserRight.chkRight(sUserID, 2080))
                    throw new Exception("没有权限");

                string sErr = "";
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }


                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sSQL = "select getdate()";
                    DateTime dNow = BaseFunction.ReturnDate(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);

                    int iCou = 0;

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (!BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColbChoose)))
                            continue;

                        string sSerial = gridView1.GetRowCellValue(i, gridColSerialNo).ToString().Trim();
                        if (sSerial == "")
                            continue;

                        sSQL = "select * from _FrockClamp where SerialNo = N'111111'";
                        sSQL = sSQL.Replace("111111", gridView1.GetRowCellValue(i, gridColSerialNo).ToString().Trim());
                        DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt == null && dt.Rows.Count == 0)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "不存在\n";
                            continue;
                        }

                        if (dt.Rows[0]["Auditer"].ToString().Trim() == "")
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "未审核\n";
                            continue;
                        }

                        if (dt.Rows[0]["Closed"].ToString().Trim() != "")
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "已关闭\n";
                            continue;
                        }

                        sSQL = "update _FrockClamp set Closed = '333333',CloseDate = '222222',iState = 4 where SerialNo = N'111111' ";
                        sSQL = sSQL.Replace("111111", sSerial);
                        sSQL = sSQL.Replace("333333", sUserName);
                        sSQL = sSQL.Replace("222222", dNow.ToString("yyyy-MM-dd"));
                        iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }


                    if (sErr != "")
                    {
                        throw new Exception(sErr);
                    }

                    if (iCou > 0)
                    {
                        tran.Commit();
                        MessageBox.Show("OK\n");

                        GetGrid();
                    }
                    else
                    {
                        MessageBox.Show("no data");
                    }
                }
                catch(Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
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
                if (e.Column != gridColbChoose && gridView1.GetRowCellValue(e.RowHandle, gridColsState).ToString().Trim() == "")
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridColsState, "add");
                }

                if (e.Column != gridColbChoose && e.Column != gridColsState)
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridColbChoose, true);
                }

                if (e.Column != gridColSerialNo && gridView1.GetRowCellValue(e.RowHandle,gridColsState).ToString().Trim() == "")
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridColsState, "edit");
                }

                if (e.RowHandle == gridView1.RowCount - 1 && (e.Column == gridColSerialNo || e.Column == gridColInvName))
                {
                    int iRow = e.RowHandle;
                    gridView1.AddNewRow();

                    gridView1.FocusedRowHandle = iRow;
                }

            }
            catch { }
        }

        private void btnDEL_Click(object sender, EventArgs e)
        {
            try
            {
                if (!clsUserRight.chkRight(sUserID, 2030))
                    throw new Exception("没有权限");

                string sErr = "";
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }


                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    int iCou = 0;
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (!BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColbChoose)))
                            continue;

                        string sSerial = gridView1.GetRowCellValue(i, gridColSerialNo).ToString().Trim();
                        if (sSerial == "")
                            continue;

                        string sSQL = "select * from _FrockClamp where SerialNo = N'111111'";
                        sSQL = sSQL.Replace("111111", gridView1.GetRowCellValue(i, gridColSerialNo).ToString().Trim());
                        DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt == null && dt.Rows.Count == 0)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "不存在\n";
                            continue;
                        }

                        if (dt.Rows[0]["Auditer"].ToString().Trim() != "")
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "已审核\n";
                            continue;
                        }

                        sSQL = "delete _FrockClamp where SerialNo = N'111111' ";
                        sSQL = sSQL.Replace("111111", sSerial);
                        iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    if (sErr != "")
                    {
                        throw new Exception(sErr);
                    }

                    if (iCou > 0)
                    {
                        tran.Commit();
                        MessageBox.Show("OK\n");

                        GetGrid();
                    }
                    else
                    {
                        MessageBox.Show("no data");
                    }
                }
                catch(Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
            }
            catch(Exception ee) 
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnAlter_Click(object sender, EventArgs e)
        {
            try
            {
                if (!clsUserRight.chkRight(sUserID, 2060))
                    throw new Exception("没有权限");

                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                bool bChoose = false;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    bool b = BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColbChoose));
                    if (!b)
                        continue;

                    if (gridView1.GetRowCellValue(i, gridColSerialNo).ToString().Trim() == "")
                        continue;

                    bChoose = true;
                    string sSQL = "select * from _FrockClamp where SerialNo = N'111111'";
                    sSQL = sSQL.Replace("111111", gridView1.GetRowCellValue(i, gridColSerialNo).ToString().Trim());
                    DataTable dt = DbHelperSQL.Query(sSQL);
                    if (dt == null || dt.Rows.Count == 0)
                        throw new Exception("no data");

                    if (dt.Rows[0]["Auditer"].ToString().Trim() == "")
                    {
                        throw new Exception("尚未审核，可直接修改");
                    }

                    FrmFrockClampAlter frm = new FrmFrockClampAlter();
                    frm.txtSerialNo.Text = gridView1.GetRowCellValue(i, gridColSerialNo).ToString().Trim();
                    frm.txtInvName.Text = gridView1.GetRowCellValue(i, gridColInvName).ToString().Trim();
                    frm.txtInvStd.Text = gridView1.GetRowCellValue(i, gridColInvStd).ToString().Trim();

                    DateTime dDate = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridColLC));
                    if (dDate > BaseFunction.ReturnDate("2000-01-01"))
                    {
                        frm.dtm1.DateTime = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridColLC));
                    }

                    long lTimes = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColTimes));
                    if (lTimes != 0)
                    {
                        frm.txtTimes.Text = gridView1.GetRowCellValue(i, gridColTimes).ToString().Trim();
                    }
                    frm.ShowDialog();

                    if (frm.DialogResult == DialogResult.OK)
                    {
                        GetGrid();
                    }

                    break;
                }

                if (!bChoose)
                { 
                    throw  new Exception("no data");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                string sAudit = gridView1.GetRowCellValue(e.FocusedRowHandle, gridColAuditer).ToString().Trim();
                string sClose = gridView1.GetRowCellValue(e.FocusedRowHandle, gridColClosed).ToString().Trim();

                if (sAudit != "" || sClose != "")
                {
                    gridColSerialNo.OptionsColumn.AllowEdit = false;
                    gridColService.OptionsColumn.AllowEdit = false;
                    gridColTimes.OptionsColumn.AllowEdit = false;
                    gridColInvName.OptionsColumn.AllowEdit = false;
                    gridColInvStd.OptionsColumn.AllowEdit = false;
                    gridColLC.OptionsColumn.AllowEdit = false;
                }
                else
                {
                    if (gridView1.GetRowCellValue(e.FocusedRowHandle, gridColsState).ToString().Trim() == "sel")
                    {
                        gridColSerialNo.OptionsColumn.AllowEdit = false;
                    }
                    else
                    {
                        gridColSerialNo.OptionsColumn.AllowEdit = true;
                    }
                    gridColService.OptionsColumn.AllowEdit = true;
                    gridColTimes.OptionsColumn.AllowEdit = true;
                    gridColInvName.OptionsColumn.AllowEdit = true;
                    gridColInvStd.OptionsColumn.AllowEdit = true;
                    gridColLC.OptionsColumn.AllowEdit = true;
                }
            }
            catch { }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                { 
                    if(gridView1.GetRowCellValue(i,gridColSerialNo).ToString().Trim() == "")
                    {
                        continue;
                    }

                    gridView1.SetRowCellValue(i, gridColbChoose, chkAll.Checked);
                }
            }
            catch { }
        }

        private void ItemButtonEditInvName_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                gridView1.FocusedColumn = gridColInvStd;
                gridView1.FocusedColumn = gridColInvName;
                string sInvName = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColInvName).ToString().Trim();
                FrmInvInfo frm = new FrmInvInfo(sInvName, false);
                frm.ShowDialog();

                sInvName = frm.sInvName;
                string sInvStd = frm.sInvStd;

                if (sInvName != "")
                {
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridColInvName, sInvName);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridColInvStd, sInvStd);
                }
            }
            catch { }
        }

        private void ItemButtonEditInvName_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (gridView1.FocusedColumn == gridColInvName && e.KeyCode == Keys.F2)
                {
                    ItemButtonEditInvName_ButtonClick(null, null);
                }
            }
            catch { }
        }
    }
}
