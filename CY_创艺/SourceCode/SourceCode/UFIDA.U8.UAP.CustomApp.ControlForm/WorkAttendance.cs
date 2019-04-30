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
    public partial class WorkAttendance : UserControl
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

        DataTable dtHead = new DataTable();
        DataTable dtDetails = new DataTable();

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                DbHelperSQL.connectionString = Conn;

                GetLookUp();
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        public WorkAttendance()
        {
            InitializeComponent();
        }

        private void GetLookUp()
        {
            string sSQL = @"
select cDepCode,cDepName from Department order by cDepCode
            ";
            DataTable dt = DbHelperSQL.Query(sSQL);
            DataRow dw = dt.NewRow();
            dt.Rows.Add(dw);
            lookUpEdit部门.Properties.DataSource = dt;

            DataTable dtm = new DataTable();
            dtm.Columns.Add("iID",typeof(int));
            for (int i = 1; i <= 12; i++)
            {
                DataRow dw2 = dtm.NewRow();
                dw2[0] = i;
                dtm.Rows.Add(dw2);
            }
            lookUpEdit月份.Properties.DataSource = dtm;
            lookUpEdit月份.EditValue = DateTime.Now.Month;
            txt年度.EditValue = DateTime.Now.Year;

            //lookUpEdit月份.EditValue = 11;
            //txt年度.EditValue = 2015;
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {

        }


        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt年度.Text.Trim() == "")
                {
                    throw new Exception("请输入考勤年度");
                }
                if (lookUpEdit月份.Text.Trim() == "")
                {
                    throw new Exception("请输入考勤月份");
                }
                if (txt单据号.Text.Trim() == "")
                {
                    throw new Exception("请输入单据号");
                }
                if (lookUpEdit部门.Text.Trim() == "")
                {
                    throw new Exception("请输入部门");
                }
                
                string sErr = "";
                int iCou = 0;
                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
//                    string sSQL = @"
//SELECT * FROM GL_mend where iYPeriod = '111111' 
//";
//                    sSQL = sSQL.Replace("111111", dtm1.DateTime.ToString("yyyyMM"));
//                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
//                    if (BaseFunction.ReturnBool(dt.Rows[0]["bflag_ST"]))
//                    {
//                        throw new Exception("该月库存模块已经结账");
//                    }

                    string sSQL = @"select getdate()";
                    DateTime dNow = BaseFunction.ReturnDate(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);

                    DateTime t1;
                    DateTime t2;
                    sSQL = @"select * from UfSystem.dbo.UA_Period where iYear='" + txt年度.Text + "' and iId='" + lookUpEdit月份.EditValue.ToString() + "' ";
                    DataTable dtUA_Period = DbHelperSQL.Query(sSQL);
                    if (dtUA_Period.Rows.Count > 0)
                    {
                        t1 = DateTime.Parse(dtUA_Period.Rows[0]["dBegin"].ToString());
                        t2 = DateTime.Parse(dtUA_Period.Rows[0]["dEnd"].ToString());
                    }
                    else
                    {
                        throw new Exception("未设置考勤月份");
                    }
                    sSQL = "select * from hr_tm_ArrangingPlan where VoucherId='" + txt单据号.EditValue.ToString() + "' ";
                    DataTable dtchk = DbHelperSQL.Query(sSQL);
                    if (dtchk.Rows.Count > 0)
                    {
                        throw new Exception("单据号不可重复");
                    }

                    //sSQL = "select isnull(max(iRecordID),0)+1 from hr_tm_ArrangingPlan";
                    //DataTable dtmax = DbHelperSQL.Query(sSQL);
                    //int iID = int.Parse(dtmax.Rows[0][0].ToString());
                    
                    sSQL = "select   datepart(week,'" + t1 + "')";
                    DataTable dtpart = DbHelperSQL.Query(sSQL);
                    string weekOfYear = dtpart.Rows[0][0].ToString();

                    Model.hr_tm_ArrangingPlan model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.hr_tm_ArrangingPlan();
                    model.DeptCode = lookUpEdit部门.EditValue.ToString().Trim();
                    model.VoucherId = txt单据号.EditValue.ToString();
                    model.Year = txt年度.Text;
                    model.Week = lookUpEdit月份.EditValue.ToString();
                    sSQL = "select * from _DeptDuty where cDept_num='" + lookUpEdit部门.EditValue.ToString().Trim() + "'";
                    DataTable dtdept = DbHelperSQL.Query(sSQL);
                    string SelDutys = "";
                    for (int i = 0; i < dtdept.Rows.Count; i++)
                    {
                        if (SelDutys != "")
                        {
                            SelDutys = SelDutys + "/";
                        }
                        SelDutys = SelDutys + dtdept.Rows[i]["cDutyCode"].ToString();
                    }
                    if (SelDutys == "")
                    {
                        throw new Exception("排班部门未设置班次信息");
                    }
                    model.SelDutys = SelDutys;
                    model.HasChildDept = true;
                    model.BeginDate = t1.ToString("yyyy-MM-dd");
                    model.EndDate = t2.ToString("yyyy-MM-dd");
                    model.PeriodType = "2";
                    model.bAuditFlag = false;
                    model.cCreatorNum = sUserID;
                    model.cCreator = sUserName;
                    model.dCreatTime = dNow.ToString();
                    model.bLastFlag = false;
                    model.nStatus2 = -1.0M;
                    DAL.hr_tm_ArrangingPlan dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.hr_tm_ArrangingPlan();
                    sSQL = dal.Add(model);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    DataTable dtd = new DataTable();
                    dtd.Columns.Add("Date");
                    dtd.Columns.Add("DutyCode");
                    dtd.Columns.Add("vDutyName");
                    dtd.Columns.Add("DutyPepole");
                    dtd.Columns.Add("DutyPepoleNames");

                    //人员信息
                    sSQL = @"select cPsn_Num ,cPsn_Name,a.cDept_num,cDutyclass,b.vName,c.cCode,d.cDutys  from hr_hi_person a left join Team b on a.cDutyclass=b.cCode 
left join hr_tm_DutyClass c on a.cDutyclass=c.cCode left join hr_tm_RulesForShift d on c.rRulesForShift=d.cCode
where isnull(a.cDutyclass,'')!='' and a.cDept_num = '" + model.DeptCode + "'";
                    //sSQL = sSQL + " and cPsn_Num='00220'";
                    DataTable dtper = DbHelperSQL.Query(sSQL);
                    if (dtper.Rows.Count == 0)
                    {
                        throw new Exception("请设置部门员工");
                    }

                    sSQL = "select * from HR_TM_WorkCalendar where cDept_num = '" + model.DeptCode + "' order by ddate";//0 上班 1 休日 2 国假
                    DataTable dtcal = DbHelperSQL.Query(sSQL);
                    if (dtcal.Rows.Count == 0)
                    {
                        throw new Exception("请设置部门工作日历");
                    }

                    for (int i = 0; i < dtper.Rows.Count; i++)
                    {
                        string cPsn_Num = dtper.Rows[i]["cPsn_Num"].ToString();
                        string cPsn_Name = dtper.Rows[i]["cPsn_Name"].ToString();
                        //签卡刷卡数据
                        sSQL = @"select cPsn_Num,vCardNo ,dDateTime  from hr_tm_SignCardData where bAuditFlag =1 and 1=1 and dDateTime>='" + t1 + "'  and dDateTime<='" + t2 + "'"+
@" union all select cPsn_Num,vCardNo ,dDateTime from hr_tm_OriCardData where  bAuditFlag =1 and 1=1 and dDateTime>='" + t1 + "'  and dDateTime<='" + t2 + "' order by dDateTime ";
                        sSQL = sSQL.Replace("1=1", "1=1 and cPsn_Num='" + cPsn_Num + "'");

                        DataTable dtscan = DbHelperSQL.Query(sSQL);
                        
                        //循环日期进行排班
                        string ss = "";
                        for (DateTime t = t1; t <= t2; t = t.AddDays(1))
                        {
                            bool issb = true;
                            DataRow[] dwcal = dtcal.Select("dDate='" + t + "'");//上班
                            if (dwcal.Length == 1)
                            {
                                if (dwcal[0]["rDateProperty"].ToString() == "0")
                                {
                                    issb = true;
                                }
                                else
                                {
                                    issb = false;
                                }
                            }
                            else
                            {
                                string weekstr = DateTime.Now.DayOfWeek.ToString();
                                if (weekstr == "Saturday" && weekstr == "Sunday")
                                {
                                    issb = false;
                                }
                                else
                                {
                                    issb = true;
                                }
                            }
                            if (issb == false)
                                continue;

                            sSQL = @"SELECT  b.vDutyName,a.cDutyCode ,a.bOverDate as 是否跨天,convert(nvarchar(5),a.dDutyTime) as dDutyTime,b.iAllowLateTime,b.iAllowLeaveTime,convert(nvarchar(5),a.dOffTime) as dOffTime
,convert(datetime,convert(nvarchar(10),getdate(),120)+' '+dBeginTime ) as d1
,dateadd(mi,b.iAllowLateTime,convert(datetime,convert(nvarchar(10),getdate(),120)+' '+a.dDutyTime)) as d2
,case when a.bOverDate2=0 then convert(datetime,convert(nvarchar(10),getdate(),120)+' '+a.dOffTime) 
else convert(datetime,convert(nvarchar(10),dateadd(d,1,getdate()),120)+' '+a.dOffTime ) end as t1
,case when a.bOverDate2=0 then convert(datetime,convert(nvarchar(10),getdate(),120)+' '+a.dEndTime) 
else convert(datetime,convert(nvarchar(10),dateadd(d,1,getdate()),120)+' '+a.dEndTime )  end as t2 
FROM hr_tm_DutyPeriod a left join hr_tm_DutyBasic b on a.cDutyCode=b.cDutyCode  left join _DeptDuty c on a.cDutyCode=c.cDutyCode where c.cDept_num = '" + model.DeptCode + "' ";
                            sSQL = sSQL.Replace("getdate()", "'" + t.ToString("yyyy-MM-dd") + "'");
                            DataTable dtpb = DbHelperSQL.Query(sSQL);
                            bool b = false;
                            for (int s = 0; s < dtpb.Rows.Count; s++)
                            {
                                //判断是否有正常打卡时间
                                string s1 = "cPsn_Num='" + cPsn_Num + "' and dDateTime>= '" + dtpb.Rows[s]["d1"].ToString() + "' and dDateTime<='" + dtpb.Rows[s]["d2"].ToString() + "'";
                                string s2 = "cPsn_Num='" + cPsn_Num + "' and dDateTime>= '" + dtpb.Rows[s]["t1"].ToString() + "' and dDateTime<='" + dtpb.Rows[s]["t2"].ToString() + "'";
                                int isok1 = dtscan.Select(s1).Length;
                                int isok2 = dtscan.Select(s2).Length;
                                if (isok1 > 0 && isok2 > 0)
                                {
                                    sSQL = "select * from hr_tm_ArrangingPlanDetail with (nolock) where '/'+DutyPepole+'/' like '%/" + cPsn_Num + "/%' and Date='" + t.ToString("yyyy-MM-dd") + "'";
                                    DataTable dtc = DbHelperSQL.Query(sSQL);
                                    if (dtc.Rows.Count == 0)
                                    {
                                        DataRow dw = dtd.NewRow();
                                        dw["Date"] = t.ToString("yyyy-MM-dd");
                                        dw["DutyCode"] = dtpb.Rows[s]["cDutyCode"].ToString();
                                        dw["vDutyName"] = dtpb.Rows[s]["vDutyName"].ToString();
                                        dw["DutyPepole"] = cPsn_Num;
                                        dw["DutyPepoleNames"] = cPsn_Name;
                                        dtd.Rows.Add(dw);
                                        iCou = iCou + 1;
                                        b = true;
                                        continue;
                                    }
                                    else
                                    {
                                        sErr = sErr + "人员：" + cPsn_Num + "  " + cPsn_Name + "日期：" + t.ToString("yyyy-MM-dd") + "已有排班\n";
                                    }
                                }
                            }
                            //未找到正常打卡记录，判断加班单
                            if (b == false)
                            {
                                sSQL = @"select * from 
(
select cPsn_Num,dJbDate,bAuditFlag,dDutyTime,dOffTime,bOverDate,bOverDate2
,convert(datetime,convert(nvarchar(10),dateadd(d,bOverDate ,dJbDate),120)+' '+dDutyTime) as t1
,convert(datetime,convert(nvarchar(10),dateadd(d,bOverDate2,dJbDate),120)+' '+dOffTime)  as t2  from hr_tm_OverTimeresult 
where bAuditFlag=1 and dJbDate=getdate()  and cPsn_Num=111111
) a 
left join 
(
SELECT  b.vDutyName,a.cDutyCode ,a.bOverDate as 是否跨天,convert(nvarchar(5),a.dDutyTime) as dDutyTime,b.iAllowLateTime,b.iAllowLeaveTime,convert(nvarchar(5),a.dOffTime) as dOffTime
,dateadd(mi,b.iAllowLateTime,convert(datetime,convert(nvarchar(10),getdate(),120)+' '+a.dDutyTime)) as t1
,case when a.bOverDate2=0 then convert(datetime,convert(nvarchar(10),getdate(),120)+' '+a.dOffTime) 
else convert(datetime,convert(nvarchar(10),dateadd(d,1,getdate()),120)+' '+a.dOffTime ) end as t2
FROM hr_tm_DutyPeriod a left join hr_tm_DutyBasic b on a.cDutyCode=b.cDutyCode  left join _DeptDuty c on a.cDutyCode=c.cDutyCode  where c.cDept_num like '0801%'
) b on a.dDutyTime=b.dOffTime or a.dOffTime=b.dDutyTime";
                                sSQL = sSQL.Replace("getdate()", "'" + t.ToString("yyyy-MM-dd") + "'");
                                sSQL = sSQL.Replace("111111", "'" + cPsn_Num + "'");
                                sSQL = sSQL.Replace("222222", "'" + model.DeptCode + "'");
                                DataTable dtjb = DbHelperSQL.Query(sSQL);
                                //有加班单
                                if (dtjb.Rows.Count == 1)
                                {
                                    sSQL = "select * from hr_tm_ArrangingPlanDetail with (nolock) where '/'+DutyPepole+'/' like '%/" + cPsn_Num + "/%' and Date='" + t.ToString("yyyy-MM-dd") + "'";
                                    DataTable dtc = DbHelperSQL.Query(sSQL);
                                    if (dtc.Rows.Count == 0)
                                    {
                                        DataRow dw = dtd.NewRow();
                                        dw["Date"] = t.ToString("yyyy-MM-dd");
                                        dw["DutyCode"] = dtpb.Rows[0]["cDutyCode"].ToString();
                                        dw["vDutyName"] = dtpb.Rows[0]["vDutyName"].ToString();
                                        dw["DutyPepole"] = cPsn_Num;
                                        dw["DutyPepoleNames"] = cPsn_Name;
                                        dtd.Rows.Add(dw);
                                        iCou = iCou + 1;
                                        b = true;
                                        continue;
                                    }
                                    else
                                    {
                                        sErr = sErr + "人员：" + cPsn_Num + "  " + cPsn_Name + "日期：" + t.ToString("yyyy-MM-dd") + "已有排班\n";
                                    }
                                }
                                else if (dtjb.Rows.Count > 1)
                                {
                                    sErr = sErr + "人员：" + cPsn_Num + "  " + cPsn_Name + "日期：" + t.ToString("yyyy-MM-dd") + "有排班但无法判断是哪个班次,请人工进行判断\n";
                                }
                            }
                        }
                    }
                    
                    string SulDutys = "";
                    if (iCou > 0)
                    {
                        DataTable dtgroup = Group(dtd, new string[] { "Date", "DutyCode" });
                        for (int i = 0; i < dtgroup.Rows.Count; i++)
                        {
                            string DutyPepole = "";
                            string DutyPepoleNames = "";
                            DataRow[] dw = dtd.Select("Date='" + dtgroup.Rows[i]["Date"].ToString() + "' and DutyCode='" + dtgroup.Rows[i]["DutyCode"].ToString() + "'");
                            for (int j = 0; j < dw.Length; j++)
                            {
                                if (DutyPepole != "")
                                {
                                    DutyPepole = DutyPepole + "/";
                                }
                                DutyPepole = DutyPepole + dw[j]["DutyPepole"].ToString();

                                if (DutyPepoleNames != "")
                                {
                                    DutyPepoleNames = DutyPepoleNames + "/";
                                }
                                DutyPepoleNames = DutyPepoleNames + dw[j]["DutyPepoleNames"].ToString();
                            }

                            Model.hr_tm_ArrangingPlanDetail models = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.hr_tm_ArrangingPlanDetail();
                            models.VoucherID = model.VoucherId;
                            models.Date = dtgroup.Rows[i]["Date"].ToString();
                            models.DutyCode = dtgroup.Rows[i]["DutyCode"].ToString();
                            models.DutyPepole = DutyPepole;
                            models.DutyPepoleNames = DutyPepoleNames;
                            DAL.hr_tm_ArrangingPlanDetail dals = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.hr_tm_ArrangingPlanDetail();
                            sSQL = dals.Add(models);
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        }
                    }
                    
                    if (iCou > 0)
                    {
                        tran.Commit();
                        MessageBox.Show("保存成功。单据号:" + txt单据号.EditValue.ToString() + "\n" + sErr);
                        gridControl1.DataSource = dtd;
                    }
                    else
                    {
                        throw new Exception("没有需要保存的单据体" + "\n" + sErr);
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
                MessageBox.Show(ee.Message);
            }
        }

        #region 汇总(Group)Table得到Table
        /// <summary>
        /// 汇总(Group)Table得到Table
        /// </summary>
        /// <param name="dt">表名</param>
        /// <param name="ColumnName">字段名列表</param>
        /// <returns></returns>
        public static DataTable Group(DataTable dt, string[] ColumnName)
        {
            DataView dv = new DataView(dt);
            DataTable dtgroup = dv.ToTable(true, ColumnName);
            return dtgroup;
        }
        #endregion


        private void gridView1_CustomDrawRowIndicator_1(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }
    }
}
