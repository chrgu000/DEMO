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
using System.Runtime.InteropServices;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    
    public partial class hr_tm_OriCardData : UserControl
    {
        
        TH.BaseClass.GetBaseData getBaseData = new GetBaseData();
        
        string sProPath = Application.StartupPath;

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
                dateEdit1.DateTime = TH.BaseClass.BaseFunction.ReturnDate(TH.BaseClass.BaseFunction.ReturnDate(sLogDate).ToString("yyyy-MM-01"));
                dateEdit2.DateTime = TH.BaseClass.BaseFunction.ReturnDate(sLogDate);
                //btnDownLoad.Visible = false;
                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sSQL = "select * from Department ";
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    ItemLookUpEdit部门.DataSource = dt;
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
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        public hr_tm_OriCardData()
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

                if (radio全部.Checked)
                {
                    throw new Exception("请选择未导入，然后保存考勤数据");
                }

                string sErr = "";
                int iCou = 0;
                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sSQL = "select getdate()";
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    DateTime dNow = TH.BaseClass.BaseFunction.ReturnDate(dt.Rows[0][0]);

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (!Convert.ToBoolean(gridView1.GetRowCellValue(i, gridColiCheck)))
                            continue;

                        string dDate = TH.BaseClass.BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridCol打卡日期).ToString().Trim()).ToString("yyyy-MM-dd");
                        string dTime = gridView1.GetRowCellValue(i, gridCol打卡时间).ToString().Trim();
                        if (DateTime.Compare(TH.BaseClass.BaseFunction.ReturnDate(dDate), dateEdit1.DateTime) >= 0 && DateTime.Compare(TH.BaseClass.BaseFunction.ReturnDate(dDate), dateEdit2.DateTime) <= 0)
                        {
                            string Card = gridView1.GetRowCellValue(i, gridCol卡号).ToString();
                            string cPsn_Num = gridView1.GetRowCellValue(i, gridCol人员编码).ToString();
                            string cPsn_Name = gridView1.GetRowCellValue(i, gridCol姓名).ToString();
                            if (cPsn_Name == "")
                            {
                                sErr = sErr + "行" + (i + 1).ToString() + "未找到用友相关人员无法导入\n";
                                continue;
                            }
                            string JobNumber = gridView1.GetRowCellValue(i, gridCol工号).ToString();
                            string cDept_num = gridView1.GetRowCellValue(i, gridCol部门).ToString();
                            string chdefine1 = gridView1.GetRowCellValue(i, gridCol是否责任制员工).ToString();
                            string iID=gridView1.GetRowCellValue(i, gridColiID).ToString();
                            sSQL = "select * from hr_tm_OriCardData where vCardNo='" + Card + "' and dDateTime='" + TH.BaseClass.BaseFunction.ReturnDate(dDate + " " + dTime)+"'";//只导入范围内
                            DataTable dtkq = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dtkq.Rows.Count == 0)
                            {
                                TH.Model.hr_tm_OriCardData model = new TH.Model.hr_tm_OriCardData();
                                model.uRecordId = Guid.NewGuid();
                                model.cPsn_Num = gridView1.GetRowCellValue(i, gridCol人员编码).ToString().Trim();
                                model.vCardNo = gridView1.GetRowCellValue(i, gridCol卡号).ToString().Trim();
                                model.dDateTime = TH.BaseClass.BaseFunction.ReturnDate(dDate + " " + dTime);
                                model.bManual = false;
                                model.iFlag = 0;
                                
                                model.bEffect = 1;
                                model.bAuditFlag = true;
                                
                                model.JobNumber = gridView1.GetRowCellValue(i, gridCol工号).ToString().Trim();
                                model.cSource = "0";
                                model.vReason = "系统自动导入";

                                model.dAuditTime = dNow.ToString();
                                model.dSysTime = dNow;
                                model.cOptPsn_Num = "demo";
                                model.cAuditorNum = "demo";

                                TH.DAL.hr_tm_OriCardData dal = new TH.DAL.hr_tm_OriCardData();
                                sSQL = dal.Add(model);
                                iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                        }
                    }
                    if (sErr != "")
                    {
                        throw new Exception(sErr);
                    }

                    if (iCou > 0)
                    {
                        tran.Commit();

                        MessageBox.Show("保存成功" + iCou+"条");
                        //
                    }
                    else
                    {
                        throw new Exception("没有需要保存的数据");
                    }
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }
                GetGrid(false);
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "保存失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        //[DllImport("w_kqrec.dll")]
        //public static extern int _LANDOWNLOAD(string ipaddress);

        //[DllImport("w_kqrec.dll")]
        //public static extern int _LANREALDOWNLOAD(string ipaddress);

        //[DllImport("w_kqrec.dll")]
        //public static extern int _LANGETUSERCODE(string ipaddress);

        //[DllImport("w_kqrec.dll")]
        //public static extern int _LANDOWNLOADS(string ipaddress);


        //[DllImport("w_kqrec.dll")]
        //public static extern int _LANREALDOWNLOAD(string ipaddress);

        //[DllImport("W_Kqrec.DLL", CharSet = CharSet.Ansi, EntryPoint = "_LANDOWNLOADS")]
        //public extern static int _LANDOWNLOADS(string username);

        [DllImport("w_kqrec.dll")]
        public static extern int _LANBEGINTRAN(string ipaddress, int OpType, int aIsOver);

        private void GetGrid(bool b)
        {
            SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                if (radio未导入.Checked || radio未导入2.Checked)
                {
                    string sSQL = "select * from _IP";
                    DataTable dtip = DbHelperSQL.Query(sSQL);
                    for (int s = 0; s < dtip.Rows.Count; s++)
                    {
                        if (b == true)
                        {
                            int str = _LANBEGINTRAN(dtip.Rows[s]["IP"].ToString().Trim(), 1, 0);
                            int str2 = _LANDOWNLOADS(dtip.Rows[s]["IP"].ToString().Trim());//全部记录
                        }
                        else
                        {
                            
                            int str = _LANBEGINTRAN(dtip.Rows[s]["IP"].ToString().Trim(), 2, 0);
                            int str2 = _LANDOWNLOAD(dtip.Rows[s]["IP"].ToString().Trim());//脱机记录
                        }
                        sSQL = "select cPsn_Num,cPsn_Name,vCardNo,JobNumber ,cDept_num ,chdefine1 from hr_hi_person ";
                        DataTable dtper = DbHelperSQL.Query(sSQL);

                        sSQL = "select isnull(max(ID),0)+1 from _KQLIST";
                        DataTable dtmax = DbHelperSQL.Query(sSQL);
                        long iID = long.Parse(dtmax.Rows[0][0].ToString());
                        string sErr = "";
                        int iCou = 0;
                        string[] list = File.ReadAllLines("KQREC.txt");
                            //MessageBox.Show(list.Length.ToString());
                        if (list.Length == 0)
                        {
                            //throw new Exception("未获取到考勤数据");
                        }
                        DataTable dt = new DataTable();
                        dt.Columns.Add("人员编码");
                        dt.Columns.Add("考勤人员");
                        dt.Columns.Add("姓名");
                        dt.Columns.Add("考勤日期");
                        dt.Columns.Add("考勤时间");
                        dt.Columns.Add("卡号");
                        dt.Columns.Add("工号");
                        dt.Columns.Add("部门");
                        dt.Columns.Add("是否责任制员工");
                        for (int i = 0; i < list.Length; i++)
                        {
                            //DataRow dw = dt.NewRow();
                            string kq = list[i];
                            string kqrq = kq.Substring(15, 4) + "-" + kq.Substring(19, 2) + "-" + kq.Substring(21, 2);
                            string kqsj = kq.Substring(10, 5);
                            DateTime sdt;
                            if (!DateTime.TryParse(kqrq, out sdt))
                                continue;
                            if (sdt <= DateTime.Parse("2015-08-31"))
                                continue;
                            string vCardNo = kq.Substring(2, 8).Trim();
                            sSQL = "select * from _KQLIST with (nolock) where Card='" + vCardNo + "' and  convert(nvarchar(10),dDate,120)='" + kqrq + "' and dTime='" + kqsj + "'";
                            DataTable dtc = DbHelperSQL.Query(sSQL);
                            if (dtc.Rows.Count == 0)
                            {
                                DataRow[] dwper = dtper.Select("vCardNo='" + vCardNo + "'");
                                string cPsn_Num = "";
                                string JobNumber = "";
                                string cPsn_Name = "";
                                string cDept_num = "";
                                string chdefine1 = "";
                                if (dwper.Length > 0)
                                {
                                    cPsn_Num = dwper[0]["cPsn_Num"].ToString();
                                    JobNumber = dwper[0]["JobNumber"].ToString();
                                    cPsn_Name = dwper[0]["cPsn_Name"].ToString();
                                    cDept_num = dwper[0]["cDept_num"].ToString();
                                    chdefine1 = dwper[0]["chdefine1"].ToString();
                                    cPsn_Num = dwper[0]["cPsn_Num"].ToString();
                                }
                                sSQL = "insert into _KQLIST(dDate,dTime,Card,cPsn_Num,cPsn_Name,JobNumber,cDept_num,chdefine1) values('" + kqrq + "','" + kqsj + "','" + vCardNo + "'"
                                       + ",'" + cPsn_Num + "','" + cPsn_Name + "','" + JobNumber + "','" + cPsn_Num + "','" + chdefine1 + "')";
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                                iCou = iCou + 1;
                            }
                        }
                    }
                    tran.Commit();
                    sSQL = @"SELECT cast(0 as bit) as iChk,ID as iID,c.cPsn_Num as 人员编码, c.JobNumber as 考勤人员,c.cPsn_Name as 姓名,c.JobNumber as 工号,c.cDept_num as 部门,c.chdefine1 as 是否责任制员工
                    ,Card as 卡号,dDate as 考勤日期,dTime as 考勤时间 from _KQLIST a 
left join _Get刷卡签卡数据 b on a.Card=b.vCardNo and convert(nvarchar(10),a.dDate,120) =convert(nvarchar(10),b.dDateTime,120) and a.dTime=substring(convert(nvarchar(20),b.dDateTime,120),12,5) 
left join hr_hi_person c on a.Card=c.vCardNo where 1=1 and b.vCardNo is null and convert(nvarchar(10),a.dDate,120)>='2015-08-01'";// isnull(iSave,'')='' 
                    if (dateEdit1.EditValue != null && dateEdit1.EditValue.ToString() != "")
                    {
                        sSQL = sSQL + " and convert(nvarchar(10),dDate,120)>='" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "'";
                    }
                    if (dateEdit2.EditValue != null && dateEdit2.EditValue.ToString() != "")
                    {
                        sSQL = sSQL + " and convert(nvarchar(10),dDate,120)<='" + dateEdit2.DateTime.ToString("yyyy-MM-dd") + "'";
                    }
                    DataTable dtbind = DbHelperSQL.Query(sSQL);
                    if (buttonEdit1.Text.Trim() != "")
                    {
                        string sper = "," + buttonEdit1.Text.Trim() + ",";
                        for(int i=dtbind.Rows.Count-1;i>=0;i--)
                        {
                            if (sper.IndexOf("," + dtbind.Rows[i]["人员编码"].ToString().Trim() + ",") < 0)
                            {
                                dtbind.Rows.Remove(dtbind.Rows[i]);
                            }
                        }
                    }
                    gridControl1.DataSource = dtbind;
                    
                }
                else
                {
                    string sSQL = @"select cast(0 as bit) as iChk,a.cPsn_Num as 人员编码,cPsn_Name as 姓名,a.vCardNo as 卡号,a.JobNumber as 工号,cDept_num as 部门,chdefine1 as 是否责任制员工,
convert(nvarchar(10),dDateTime,120) as 考勤日期,
substring(convert(nvarchar(20),dDateTime,120),12,5) as 考勤时间
from _Get刷卡签卡数据 a left join hr_hi_person b on a.cPsn_Num=b.cPsn_Num where convert(nvarchar(10),dDateTime,120)>='2015-08-01' and 1=1
union all
SELECT cast(0 as bit) as iChk,c.cPsn_Num as 人员编码, c.cPsn_Name as 姓名,Card as 卡号,c.JobNumber as 工号 ,c.cDept_num as 部门,c.chdefine1 as 是否责任制员工,dDate as 考勤日期,dTime as 考勤时间 from _KQLIST a 
left join _Get刷卡签卡数据 b on a.Card=b.vCardNo and convert(nvarchar(10),a.dDate,120) =convert(nvarchar(10),b.dDateTime,120) and a.dTime=substring(convert(nvarchar(20),b.dDateTime,120),12,5) 
left join hr_hi_person c on a.Card=c.vCardNo where 1=1 and b.vCardNo is null and  convert(nvarchar(10),a.dDate,120)>='2015-08-01' and 2=2";
                    if (dateEdit1.EditValue.ToString() != "")
                    {
                        sSQL = sSQL.Replace("1=1", "1=1 and convert(nvarchar(10),dDateTime,120)>='" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "'");
                        sSQL = sSQL.Replace("2=2", "2=2 and convert(nvarchar(10),dDate,120)>='" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "'");
                    }
                    if (dateEdit2.EditValue.ToString() != "")
                    {
                        sSQL = sSQL.Replace("1=1", "1=1 and convert(nvarchar(10),dDateTime,120)<='" + dateEdit2.DateTime.ToString("yyyy-MM-dd") + "'");
                        sSQL = sSQL.Replace("2=2", "2=2 and convert(nvarchar(10),dDate,120)>='" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "'");
                    }
                    DataTable dtbind = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (buttonEdit1.Text.Trim() != "")
                    {
                        string sper = "," + buttonEdit1.Text.Trim() + ",";
                        for (int i = dtbind.Rows.Count - 1; i >= 0; i--)
                        {
                            if (sper.IndexOf("," + dtbind.Rows[i]["人员编码"].ToString().Trim() + ",") < 0)
                            {
                                dtbind.Rows.Remove(dtbind.Rows[i]);
                            }
                        }
                    }
                    gridControl1.DataSource = dtbind;
                }

                checkEdit1.Checked = true;
                checkEdit1_CheckedChanged(null, null);
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                GetGrid(false);
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                GetGrid(true);
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void btnExcel_Click_1(object sender, EventArgs e)
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
                MessageBox.Show(ee.Message);
            }
        }

        
        private void btnDownLoad_Click(object sender, EventArgs e)
        {
            try
            {
                int iCou = _LANDOWNLOADS("192.168.33.192");
            }

            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void radio未导入2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                GetGrid(false);
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                FrmPerson frm = new FrmPerson(buttonEdit1.Text.ToString(), Conn, true);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    buttonEdit1.EditValue = frm.sPerCode;
                    textEditper.EditValue = frm.sPerName;
                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                gridView1.SetRowCellValue(i, gridColiCheck, checkEdit1.Checked);
            }
            if (checkEdit1.Checked)
            {
                checkEdit1.Text = "反选";
            }
            else
            {
                checkEdit1.Text = "全选";
            }
        }

        [DllImport("W_Kqrec.DLL", CharSet = CharSet.Ansi, EntryPoint = "_LANREALINI")]
        public extern static int _LANREALINI(string username);


        [DllImport("W_Kqrec.DLL", CharSet = CharSet.Ansi, EntryPoint = "_LANREALDATA")]
        public extern static string _LANREALDATA(int Socket);

        [DllImport("w_kqrec.dll", CharSet = CharSet.Ansi, EntryPoint = "_LANDOWNLOADS")]
        public static extern int _LANDOWNLOADS(string ipaddress);


        [DllImport("w_kqrec.dll", CharSet = CharSet.Ansi, EntryPoint = "_LANDOWNLOAD")]
        public static extern int _LANDOWNLOAD(string ipaddress);

        [DllImport("w_kqrec.dll", CharSet = CharSet.Ansi, EntryPoint = "_LANBEGINTRAN")]
        public static extern int _LANBEGINTRAN(string ipaddress, string sType, int iOver);

        [DllImport("w_kqrec.dll", CharSet = CharSet.Ansi, EntryPoint = "_LANENDTRAN")]
        public static extern int _LANENDTRAN(int iSocket, string sType, int iOver);

        [DllImport("w_kqrec.dll", CharSet = CharSet.Ansi, EntryPoint = "_LANDOWNLOADSOCK")]
        public static extern int _LANDOWNLOADSOCK(string ipaddress, int iPort);

        [DllImport("w_kqrec.dll", CharSet = CharSet.Ansi, EntryPoint = "_LANTRANCARD")]
        public static extern int _LANTRANCARD(string ipaddress, int iPort);


        


        [DllImport("w_kqrec.dll", CharSet = CharSet.Ansi, EntryPoint = "_DOWNLOADS")]
        public static extern int _DOWNLOADS(string ipaddress, int iPort);


        [DllImport("w_kqrec.dll", CharSet = CharSet.Ansi, EntryPoint = "_FNPING")]
        public static extern int _FNPING(string ipaddress);



        [DllImport("w_kqrec.dll", CharSet = CharSet.Ansi, EntryPoint = "_LANDOWNALLDATA")]
        public static extern int _LANDOWNALLDATA(string ipaddress, int i);


        private void ceshiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //int iCou = _LANREALINI("192.168.33.192");
            //string sTxt = _LANREALDATA(iCou);

            int i = _LANDOWNLOADS("192.168.33.192");

            //int i0 = _LANBEGINTRAN("192.168.33.192", "2", 0);

            //int i2 = _LANDOWNALLDATA("192.168.33.192", 0);

            //int i3 = _LANDOWNALLDATA(i0, "2", 0);

            //int i2 = _FNPING("192.168.33.192");

            //int i3 = _LANDOWNLOADS("192.168.33.192");

            //int i4 = _LANDOWNLOAD("192.168.33.192");

            //i = _LANDOWNLOADSOCK("192.168.33.192", iCou);
        }

    }
}
