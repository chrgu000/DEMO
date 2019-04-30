using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using System.Xml;
using System.Configuration;
using System.Runtime.InteropServices;

namespace PMMWS
{
    public class commandMethods
    {
        public static DataTable ConvertToDataTable<T>(IList<T> list)
        {
            if (list == null || list.Count <= 0)
            {
                return null;
            }

            DataTable dt = new DataTable();
            DataColumn column;
            DataRow row;

            System.Reflection.PropertyInfo[] myPropertyInfo = typeof(T).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            foreach (T t in list)
            {
                if (t == null)
                {
                    continue;
                }

                row = dt.NewRow();

                for (int i = 0, j = myPropertyInfo.Length; i < j; i++)
                {
                    System.Reflection.PropertyInfo pi = myPropertyInfo[i];

                    string name = pi.Name;

                    if (dt.Columns[name] == null)
                    {
                        column = new DataColumn(name, pi.PropertyType);
                        dt.Columns.Add(column);
                    }

                    row[name] = pi.GetValue(t, null);
                }

                dt.Rows.Add(row);
            }

            return dt;
        }

        public static DataTable ConvertToDataTablefromObject(Object obj)
        {
     
            DataTable dt = new DataTable();
            DataColumn column;
            DataRow row;

            Type T = obj.GetType();
            System.Reflection.PropertyInfo[] myPropertyInfo = T.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            return dt;
    
        }

        public static ArrayList AssblembyIList<T>(IList<T> list, ArrayList rslt)
        {
            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    rslt.Add(list[i]);
                }
            }
            return rslt;
        }

        public static DataTable MergeTable(DataTable dt, DataTable dt1)
        {
            if (dt != null)
            {
                dt1.Merge(dt);
            }
            return dt1;
        }

        public static DataTable UniteDataTable(DataTable dt1, DataTable dt2, string DTName)
        {
            DataTable dt3 = dt1.Clone();
            for (int i = 0; i < dt2.Columns.Count; i++)
            {
                dt3.Columns.Add(dt2.Columns[i].ColumnName);
            }
            object[] obj = new object[dt3.Columns.Count];

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                dt1.Rows[i].ItemArray.CopyTo(obj, 0);
                dt3.Rows.Add(obj);
            }

            if (dt1.Rows.Count >= dt2.Rows.Count)
            {
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    for (int j = 0; j < dt2.Columns.Count; j++)
                    {
                        dt3.Rows[i][j + dt1.Columns.Count] = dt2.Rows[i][j].ToString();
                    }
                }
            }
            else
            {
                DataRow dr3;
                for (int i = 0; i < dt2.Rows.Count - dt1.Rows.Count; i++)
                {
                    dr3 = dt3.NewRow();
                    dt3.Rows.Add(dr3);
                }
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    for (int j = 0; j < dt2.Columns.Count; j++)
                    {
                        dt3.Rows[i][j + dt1.Columns.Count] = dt2.Rows[i][j].ToString();
                    }
                }
            }
            dt3.TableName = DTName; //设置DT的名字
            return dt3;
        }

        public static DataTable ConvertZerotoYes(DataTable dt,string ColumnName)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][ColumnName].ToString() == "0")
                {
                    dt.Rows[i][ColumnName] = "否";
                }
                else if (dt.Rows[i][ColumnName].ToString() == "1")
                {
                    dt.Rows[i][ColumnName] = "是";
                }
            }
            return dt;
        }

        public static string TrimMechineName(string MechineName)
        {
            string type = null;
            
            string[] typenames = MechineName.Split('-');

            for (int i = 0; i < typenames.Length; i++)
            {
                type = type + typenames[i] + "_";
            }
            type = type.Substring(0, type.Length - 1);
            return type;
        }

        public static void ComputeCMTime(DateTime Monday, DateTime EndTime)
        {
            IList<CMOrder> maos = CMOrder.FindbyDateTime(Monday.ToString("yyyy-MM-dd"), EndTime.ToString("yyyy-MM-dd"));
            
            for (int i = 0; i < maos.Count; i++)
            {
                string sc = maos[i].OrderId.ToString();
                IList<CMReport> mrs = CMReport.FindbyScanId(sc);

                if (mrs.Count == 0)
                {
                    CMReport mr = new CMReport();
                    mr.MachineName = maos[i].MachineCode;

                    try
                    {
                        Machine ma = Machine.Find(maos[i].MachineCode);
                        mr.Orders = ma.Orders;
                    }
                    catch
                    { }

                    mr.MachineType = maos[i].MachineType;
                    mr.ST = maos[i].ST;
                    mr.CT = maos[i].CT;
                    mr.FaultInfo = maos[i].FaultInfo;
                    mr.FaultType = maos[i].FaultType;
                    mr.IsTotal = "3";
                    mr.Year = System.DateTime.Now.Year.ToString();
                    if (maos[i].CT != null && maos[i].CT != "")
                    {
                        mr.StopTime = Convert.ToDecimal((Convert.ToDateTime(mr.CT).Subtract(Convert.ToDateTime(mr.ST))).TotalHours);
                    }
                    mr.MCT = maos[i].MCT;
                    mr.MST = maos[i].MST;
                    try
                    {
                        if ((maos[i].MST != null) && (maos[i].MCT != null))
                        {
                            mr.MTime = Convert.ToDecimal((Convert.ToDateTime(mr.MCT).Subtract(Convert.ToDateTime(mr.MST))).TotalHours);
                        }
                    }
                    catch { };
                    mr.ScanId = maos[i].OrderId.ToString();
                    mr.WeekNum = Monday.ToString("yyyy-MM-dd");
                    mr.Create();
                }
                else
                {
                    for (int j = 0; j < mrs.Count; j++)
                    {
                        CMReport mr = CMReport.Find(mrs[j].ReportId);
                        mr.MachineName = maos[i].MachineCode;
                        mr.MachineType = maos[i].MachineType;
                        mr.ST = maos[i].ST;
                        mr.CT = maos[i].CT;
                        mr.FaultInfo = maos[i].FaultInfo;
                        mr.FaultType = maos[i].FaultType;
                        mr.IsTotal = "3";
                        mr.Year = System.DateTime.Now.Year.ToString();
                        try
                        {
                            Machine ma = Machine.Find(maos[i].MachineCode);
                            mr.Orders = ma.Orders;
                        }
                        catch
                        { }
                        if (maos[i].CT != null && maos[i].CT != "")
                        {
                            mr.StopTime = Convert.ToDecimal((Convert.ToDateTime(mr.CT).Subtract(Convert.ToDateTime(mr.ST))).TotalHours);
                        }
                        mr.MCT = maos[i].MCT;
                        mr.MST = maos[i].MST;
                        try
                        {
                            if ((maos[i].MST != null) && (maos[i].MCT != null))
                            {
                                mr.MTime = Convert.ToDecimal((Convert.ToDateTime(mr.MCT).Subtract(Convert.ToDateTime(mr.MST))).TotalHours);
                            }
                        }
                        catch
                        { }
                        mr.ScanId = maos[i].OrderId.ToString();
                        mr.WeekNum = Monday.ToString("yyyy-MM-dd");
                        mr.Update();
                    }
                }
            }

            //按Machine Orders 排序
            int[] orders = Machine.FindMachineOrders("复合材料");
            for (int i = 0; i < orders.Length; i++)
            {
                CMReport[] hprepors = CMReport.FindbyWeeksNumAndTotalAndOrders(Monday.ToString("yyyy-MM-dd"), "3", orders[i]);
                if (hprepors.Length == 0)
                {
                    CMReport sm = new CMReport();
                    sm.IsTotal = "3";
                    sm.Orders = orders[i];

                    string[] aa = Machine.FindMachineNameByOrders("复合材料", orders[i]);
                    sm.MachineName = aa[0];

                    sm.StopTime = 0;
                    sm.WeekNum = Monday.ToString("yyyy-MM-dd");
                    sm.Create();
                }
                else {
                    for (int j = 0; j < hprepors.Length; j++)
                    {
                        CMReport sm = hprepors[j];
                        string[] aa = Machine.FindMachineNameByOrders("复合材料", orders[i]);
                        sm.MachineName = aa[0];
                        sm.Update();
                    }
                }
            }

            string[] querys = CMReport.FindbyDistinctQuery(Monday.ToString("yyyy-MM-dd"));
            //计算总停机

            for (int i = 0; i < querys.Length; i++)
            {
                if (querys[i] != null)
                {
                    Decimal stopTime = Convert.ToDecimal(0);
                    Decimal Mtime = Convert.ToDecimal(0);

                    IList<CMReport> mrfs = CMReport.FindbyWeeksNumAndFaultType(Monday.ToString("yyyy-MM-dd"), querys[i]);
                    for (int j = 0; j < mrfs.Count; j++)
                    {
                        stopTime = mrfs[j].StopTime + stopTime;
                        Mtime = mrfs[j].MTime + Mtime;
                    }

                    string PieId = Monday.ToString("yyyy-MM-dd") + querys[i];

                    CMPOrder map = CMPOrder.Find(PieId);
                    if (map == null)
                    {
                        map = new CMPOrder();
                        map.PieId = PieId;
                        map.FaultId = querys[i];
                        map.StopTimeP = stopTime;
                        map.MTimeP = Mtime;
                        map.WeekNum = Monday.ToString("yyyy-MM-dd");
                        map.FaultType = querys[i];
                        map.Create();
                    }
                    else
                    {
                        map.StopTimeP = stopTime;
                        map.MTimeP = Mtime;
                        map.Update();
                    }
                }
             }
        }

        public static void ComputeHPTime(DateTime Monday, DateTime EndTime)
        {
            IList<HPOrder> maos = HPOrder.FindbyDateTime(Monday.ToString("yyyy-MM-dd"), EndTime.ToString("yyyy-MM-dd"));
            for (int i = 0; i < maos.Count; i++)
            {
                int sc = maos[i].OrderId;
                IList<HPReport> mrs = HPReport.FindbyScanId(sc.ToString());
                if (mrs.Count == 0)
                {
                    HPReport mr = new HPReport();
                    mr.MachineName = maos[i].MachineCode;
                    mr.MachineType = maos[i].MachineType;
                    mr.ST = maos[i].ST;
                    mr.CT = maos[i].CT;
                    mr.FaultInfo = maos[i].FaultInfo;
                    mr.FaultType = maos[i].FaultType;
                    mr.IsTotal = "3";
                    mr.Year = System.DateTime.Now.Year.ToString();
                        try
                        {
                            Machine ma = Machine.Find(maos[i].MachineCode);
                            mr.Orders = ma.Orders;
                        }
                        catch
                        { }
               

                    if (maos[i].CT != null && maos[i].CT != "")
                    {
                        mr.StopTime = Convert.ToDecimal((Convert.ToDateTime(mr.CT).Subtract(Convert.ToDateTime(mr.ST))).TotalHours);
                    }
                    mr.MCT = maos[i].MCT;
                    mr.MST = maos[i].MST;
                    try
                    {
                        if ((maos[i].MST != null) && (maos[i].MCT != null))
                        {
                            mr.MTime = Convert.ToDecimal((Convert.ToDateTime(mr.MCT).Subtract(Convert.ToDateTime(mr.MST))).TotalHours);
                        }
                    }
                    catch { }
                    mr.ScanId = maos[i].OrderId.ToString();
                    mr.WeekNum = Monday.ToString("yyyy-MM-dd");
                    mr.Create();
                }
                else
                {
                    for (int j = 0; j < mrs.Count; j++)
                    {
                        HPReport mr = HPReport.Find(mrs[j].ReportId);
                        mr.MachineName = maos[i].MachineCode;
                        mr.MachineType = maos[i].MachineType;
                        mr.ST = maos[i].ST;
                        mr.CT = maos[i].CT;
                        mr.FaultInfo = maos[i].FaultInfo;
                        mr.FaultType = maos[i].FaultType;
                        mr.IsTotal = "3";
                        mr.Year = System.DateTime.Now.Year.ToString();
                        try
                        {
                            Machine ma = Machine.Find(maos[i].MachineCode);
                            mr.Orders = ma.Orders;
                        }
                        catch
                        { }

                        try
                        {
                            if (maos[i].CT != null)
                            {
                                mr.StopTime = Convert.ToDecimal((Convert.ToDateTime(mr.CT).Subtract(Convert.ToDateTime(mr.ST))).TotalHours);
                            }
                        }
                        catch { }
                        mr.MCT = maos[i].MCT;
                        mr.MST = maos[i].MST;
                        if ((maos[i].MST != null) && (maos[i].MCT != null))
                        {
                            try
                            {
                                mr.MTime = Convert.ToDecimal((Convert.ToDateTime(mr.MCT).Subtract(Convert.ToDateTime(mr.MST))).TotalHours);
                            }
                            catch
                            { }
                        }

                        mr.ScanId = maos[i].OrderId.ToString();
                        mr.WeekNum = Monday.ToString("yyyy-MM-dd");
                        mr.Update();
                    }
                }
            }
            //按Machine Orders 排序
            int[] orders = Machine.FindMachineOrders("液压测试站");
            for (int i = 0; i < orders.Length; i++)
            {
                HPReport[] hprepors = HPReport.FindbyWeeksNumAndTotalAndOrders(Monday.ToString("yyyy-MM-dd"), "3", orders[i]);
                if (hprepors.Length == 0)
                {
                    HPReport sm = new HPReport();
                    sm.IsTotal = "3";
                    sm.Orders = orders[i];
                    sm.StopTime = 0;

                    string[] aa = Machine.FindMachineNameByOrders("液压测试站", orders[i]);
                    sm.MachineName = aa[0];

                    sm.WeekNum = Monday.ToString("yyyy-MM-dd");
                    sm.Create();
                }
                else
                {
                    for (int j = 0; j < hprepors.Length; j++)
                    {
                        HPReport sm = hprepors[j];
                        string[] aa = Machine.FindMachineNameByOrders("液压测试站", orders[i]);
                        sm.MachineName = aa[0];
                        sm.Update();
                    }
                }

            }



            string[] querys = HPReport.FindbyDistinctQuery(Monday.ToString("yyyy-MM-dd"));
            //计算总停机

            for (int i = 0; i < querys.Length; i++)
            {

                if (querys[i] != null)
                {
                    Decimal stopTime = Convert.ToDecimal(0);
                    Decimal Mtime = Convert.ToDecimal(0);

                    IList<HPReport> mrfs = HPReport.FindbyWeeksNumAndFaultType(Monday.ToString("yyyy-MM-dd"), querys[i]);
                    for (int j = 0; j < mrfs.Count; j++)
                    {
                        stopTime = mrfs[j].StopTime + stopTime;
                        Mtime = mrfs[j].MTime + Mtime;
                    }

                    string PieId = Monday.ToString("yyyy-MM-dd") + querys[i];

                    HPPOrder map = HPPOrder.Find(PieId);
                    if (map == null)
                    {
                        map = new HPPOrder();
                        map.PieId = PieId;
                        map.FaultId = querys[i];
                        map.StopTimeP = stopTime;
                        map.MTimeP = Mtime;
                        map.FaultType = querys[i];
                        map.WeekNum = Monday.ToString("yyyy-MM-dd");
                        map.Create();
                    }
                    else
                    {
                        map.StopTimeP = stopTime;
                        map.MTimeP = Mtime;
                        map.Update();
                    }
                }
            }
        }

        public static void ComputeSMTime(DateTime Monday, DateTime EndTime)
        {
            IList<SMOrder> maos = SMOrder.FindbyDateTime(Monday.ToString("yyyy-MM-dd"), EndTime.ToString("yyyy-MM-dd"));
            for (int i = 0; i < maos.Count; i++)
            {
                int sc = maos[i].OrderId;
                IList<SMReport> mrs = SMReport.FindbyScanId(sc.ToString());
                if (mrs.Count == 0)
                {
                    SMReport mr = new SMReport();
                    mr.MachineName = maos[i].MachineCode;
                    mr.MachineType = maos[i].MachineType;
                    mr.ST = maos[i].ST;
                    mr.CT = maos[i].CT;
                    mr.FaultInfo = maos[i].FaultInfo;
                    mr.FaultType = maos[i].FaultType;
                    mr.IsTotal = "3";
                    mr.Year = System.DateTime.Now.Year.ToString();
                    try
                    {
                        Machine ma = Machine.Find(maos[i].MachineCode);
                        mr.Orders = ma.Orders;
                    }
                    catch
                    { }

                    if (maos[i].CT != null && maos[i].CT != "")
                    {
                        mr.StopTime = Convert.ToDecimal((Convert.ToDateTime(mr.CT).Subtract(Convert.ToDateTime(mr.ST))).TotalHours);
                    }
                    mr.MCT = maos[i].MCT;
                    mr.MST = maos[i].MST;

                    try
                    {
                        if ((maos[i].MST != null) && (maos[i].MCT != null))
                        {
                            mr.MTime = Convert.ToDecimal((Convert.ToDateTime(mr.MCT).Subtract(Convert.ToDateTime(mr.MST))).TotalHours);
                        }
                    }
                    catch
                    { }

                    mr.ScanId = maos[i].OrderId.ToString();
                    mr.WeekNum = Monday.ToString("yyyy-MM-dd");
                    mr.Create();
                }
                else
                {
                    for (int j = 0; j < mrs.Count; j++)
                    {

                        SMReport mr = SMReport.Find(mrs[j].ReportId);
                        mr.MachineName = maos[i].MachineCode;
                        mr.MachineType = maos[i].MachineType;
                        mr.ST = maos[i].ST;
                        mr.CT = maos[i].CT;
                        mr.FaultInfo = maos[i].FaultInfo;
                        mr.FaultType = maos[i].FaultType;
                        mr.IsTotal = "3";
                        mr.Year = System.DateTime.Now.Year.ToString();
                        try
                        {
                            Machine ma = Machine.Find(maos[i].MachineCode);
                            mr.Orders = ma.Orders;
                        }
                        catch
                        { }

                        if (maos[i].CT != null && maos[i].CT != "")
                        {
                            mr.StopTime = Convert.ToDecimal((Convert.ToDateTime(mr.CT).Subtract(Convert.ToDateTime(mr.ST))).TotalHours);
                        }
                        mr.MCT = maos[i].MCT;
                        mr.MST = maos[i].MST;

                        try
                        {
                            if ((maos[i].MST != null) && (maos[i].MCT != null))
                            {
                                mr.MTime = Convert.ToDecimal((Convert.ToDateTime(mr.MCT).Subtract(Convert.ToDateTime(mr.MST))).TotalHours);
                            }
                        }
                        catch 
                        { }

                        mr.ScanId = maos[i].OrderId.ToString();
                        mr.WeekNum = Monday.ToString("yyyy-MM-dd");
                        mr.Update();
                    }
                }
            }

            //按Machine Orders 排序
            int[] orders = Machine.FindMachineOrders("钣金件");
            for (int i = 0; i < orders.Length; i++)
            {
                SMReport[] smrepors = SMReport.FindbyWeeksNumAndTotalAndOrders(Monday.ToString("yyyy-MM-dd"), "3", orders[i]);
                if (smrepors.Length == 0)
                {
                    SMReport sm = new SMReport();
                    sm.IsTotal = "3";
                    sm.Orders = orders[i];
                    sm.StopTime = 0;
                    string[] aa = Machine.FindMachineNameByOrders("钣金件", orders[i]);
                    sm.MachineName = aa[0];
                    sm.WeekNum = Monday.ToString("yyyy-MM-dd");
                    sm.Create();
                }

                else
                {
                    for (int j = 0; j < smrepors.Length; j++)
                    {
                        SMReport sm = smrepors[j];
                        string[] aa = Machine.FindMachineNameByOrders("钣金件", orders[i]);
                        sm.MachineName = aa[0];
                        sm.Update();
                    }
                }
            }


            string[] querys = SMReport.FindbyDistinctQuery(Monday.ToString("yyyy-MM-dd"));
            //计算总停机

            for (int i = 0; i < querys.Length; i++)
            {
                if (querys[i] != null)
                {
                    Decimal stopTime = Convert.ToDecimal(0);
                    Decimal Mtime = Convert.ToDecimal(0);

                    IList<SMReport> mrfs = SMReport.FindbyWeeksNumAndFaultType(Monday.ToString("yyyy-MM-dd"), querys[i]);
                    for (int j = 0; j < mrfs.Count; j++)
                    {
                        stopTime = mrfs[j].StopTime + stopTime;
                        Mtime = mrfs[j].MTime + Mtime;
                    }

                    string PieId = Monday.ToString("yyyy-MM-dd") + querys[i];

                    SMPOrder map = SMPOrder.Find(PieId);
                    if (map == null)
                    {
                        map = new SMPOrder();
                        map.PieId = PieId;
                        map.FaultId = querys[i];
                        map.StopTimeP = stopTime;
                        map.MTimeP = Mtime;
                        map.WeekNum = Monday.ToString("yyyy-MM-dd");
                        map.FaultType = querys[i];
                        map.Create();
                    }
                    else
                    {
                        map.StopTimeP = stopTime;
                        map.MTimeP = Mtime;
                        map.Update();
                    }
                }
            }
        }

        public static void ComputeTotalDownTime(string WeekNum)
        {
            IList<MAReport> maReport = MAReport.FindbyWeeksNumAndTotal(WeekNum,"3","非停机故障");
            IList<SMReport> smReport = SMReport.FindbyWeeksNumAndTotal(WeekNum,"3","非停机故障");
            IList<HPReport> hpReport = HPReport.FindbyWeeksNumAndTotal(WeekNum,"3","非停机故障");
            IList<CMReport> cmReport = CMReport.FindbyWeeksNumAndTotal(WeekNum,"3","非停机故障");

            decimal TotalDownTime = 0;
            decimal TotalDownTime1 = 0;
            decimal TotalDownTime2 = 0;
            decimal TotalDownTime3 = 0;

            for (int i = 0; i < maReport.Count; i++)
            {
                TotalDownTime = maReport[i].MTime + TotalDownTime;
            }

            for (int i = 0; i < smReport.Count; i++)
            {
                TotalDownTime1 = smReport[i].MTime + TotalDownTime;
            }

            for (int i = 0; i < hpReport.Count; i++)
            {
                TotalDownTime2 = hpReport[i].MTime + TotalDownTime;
            }

            for (int i = 0; i < cmReport.Count; i++)
            {
                TotalDownTime3 = cmReport[i].MTime + TotalDownTime;
            }

            TotalDownTime = TotalDownTime + TotalDownTime1 + TotalDownTime2 + TotalDownTime3;
            IList<MAReport> maReports = MAReport.FindbyWeeksNumAndTotal(WeekNum, "2","非停机故障");
            if (maReports.Count != 0)
            {
                MAReport ma = maReports[0];
                string weeks = ConfigurationSettings.AppSettings[WeekNum].ToString();
                ma.Weeks = weeks;
                ma.Week = Convert.ToInt32(weeks);
                //get A,B,C;
                int totalNum = Convert.ToInt32(ConfigurationSettings.AppSettings["MATotal"].ToString()) + Convert.ToInt32(ConfigurationSettings.AppSettings["SMTotal"].ToString()) + Convert.ToInt32(ConfigurationSettings.AppSettings["HPTotal"].ToString()) + Convert.ToInt32(ConfigurationSettings.AppSettings["CMTotal"].ToString());
                ma.WeekNum = WeekNum;
                ma.Rate = (totalNum - TotalDownTime) / totalNum;
                ma.Year = System.DateTime.Now.Year.ToString();
                ma.Save();
            }
            else
            {
                MAReport ma = new MAReport();
                ma.MachineName = "周利用率";
                ma.MachineType = "全设备";
                string weeks = ConfigurationSettings.AppSettings[WeekNum].ToString();
                ma.Weeks = weeks;
                ma.Week = Convert.ToInt32(weeks);
                //get A,B,C; 
                int totalNum = Convert.ToInt32(ConfigurationSettings.AppSettings["MATotal"].ToString()) + Convert.ToInt32(ConfigurationSettings.AppSettings["SMTotal"].ToString()) + Convert.ToInt32(ConfigurationSettings.AppSettings["HPTotal"].ToString()) + Convert.ToInt32(ConfigurationSettings.AppSettings["CMTotal"].ToString());
                ma.Rate = (totalNum - TotalDownTime) / totalNum;
                ma.WeekNum = WeekNum;
                ma.IsTotal = "2";
                ma.Year = System.DateTime.Now.Year.ToString();
                ma.Create();
            }
        }


        public static void ComputeMADownTime(string WeekNum)
        {
            IList<MAReport> maReport = MAReport.FindbyWeeksNumAndTotal(WeekNum,"3","非停机故障");
            
            decimal TotalDownTime = 0;
            
            for (int i = 0; i < maReport.Count; i++)
            {
                TotalDownTime = maReport[i].MTime + TotalDownTime;
            }

            // Report 
            IList<MAReport> maReports = MAReport.FindbyWeeksNumAndTotal(WeekNum, "1","非停机故障");

            if (maReports.Count != 0)
            {
                MAReport ma = maReports[0];
                string weeks = ConfigurationSettings.AppSettings[WeekNum].ToString();
                ma.Weeks = weeks;
                ma.Week = Convert.ToInt32(weeks);
                //get A,B,C;
                int totalNum = Convert.ToInt32 (ConfigurationSettings.AppSettings["MATotal"].ToString());
                ma.WeekNum = WeekNum; 
                ma.Rate = (totalNum - TotalDownTime)/totalNum;
                ma.Year = System.DateTime.Now.Year.ToString();
                ma.Save();
            }
            else
            {
                MAReport ma = new MAReport();
                ma.MachineName = "周利用率";
                ma.MachineType = "机加工";
                string weeks = ConfigurationSettings.AppSettings[WeekNum].ToString();
                ma.Weeks = weeks;
                ma.Week = Convert.ToInt32(weeks);
                ma.Year = System.DateTime.Now.Year.ToString();
                //get A,B,C; 
                int totalNum =  Convert.ToInt32(ConfigurationSettings.AppSettings["MATotal"].ToString());
                ma.Rate = (totalNum - TotalDownTime) / totalNum;
                ma.WeekNum = WeekNum; 
                ma.IsTotal = "1";
                ma.Create();
            }
        
        }

        public static void ComputeCMDownTime(string WeekNum)
        {
            IList<CMReport> cmReport = CMReport.FindbyWeeksNumAndTotal(WeekNum,"3","非停机故障");

            decimal TotalDownTime = 0;
            for (int i = 0; i < cmReport.Count; i++)
            {
                TotalDownTime = cmReport[i].MTime + TotalDownTime;
            }
            // Report 
            IList<CMReport> cmReports = CMReport.FindbyWeeksNumAndTotal(WeekNum, "1","非停机故障");
            if (cmReports.Count != 0)
            {
                CMReport ma = cmReports[0];

                string weeks = ConfigurationSettings.AppSettings[WeekNum].ToString();
                ma.Weeks = weeks;
                ma.Week = Convert.ToInt32(weeks);
                //get A,B,C;
                ma.WeekNum = WeekNum; 
                int totalNum = Convert.ToInt32(ConfigurationSettings.AppSettings["CMTotal"].ToString());
                ma.Year = System.DateTime.Now.Year.ToString();
                ma.Rate = (totalNum - TotalDownTime) / totalNum;
                ma.Save();
            }
            else
            {
                CMReport ma = new CMReport();
                ma.MachineName = "周利用率";
                ma.MachineType = "复合材料";
                string weeks = ConfigurationSettings.AppSettings[WeekNum].ToString();
                ma.Weeks = weeks;
                ma.Week = Convert.ToInt32(weeks);
                //get A,B,C; 
                ma.WeekNum = WeekNum; 
                int totalNum =  Convert.ToInt32(ConfigurationSettings.AppSettings["CMTotal"].ToString());
                ma.Rate = (totalNum - TotalDownTime) / totalNum;
                ma.Year = System.DateTime.Now.Year.ToString();
                ma.IsTotal = "1";
                ma.Create();
            }
        }

        public static void ComputeHPDownTime(string WeekNum)
        {
            IList<HPReport> hpReport = HPReport.FindbyWeeksNumAndTotal(WeekNum,"3","非停机故障");

            decimal TotalDownTime = 0;
            for (int i = 0; i < hpReport.Count; i++)
            {
                TotalDownTime = hpReport[i].MTime + TotalDownTime;
            }
            // Report 
            IList<HPReport> hpReports = HPReport.FindbyWeeksNumAndTotal(WeekNum, "1","非停机故障");
            if (hpReports.Count != 0)
            {
                HPReport ma = hpReports[0];

                string weeks = ConfigurationSettings.AppSettings[WeekNum].ToString();
                ma.Weeks = weeks;
                ma.Week = Convert.ToInt32(weeks);
                //get A,B,C;
                ma.WeekNum = WeekNum; 
                int totalNum = Convert.ToInt32(ConfigurationSettings.AppSettings["HPTotal"].ToString());
                ma.Year = System.DateTime.Now.Year.ToString();

                ma.Rate = (totalNum - TotalDownTime) / totalNum;
                ma.Save();
            }
            else
            {
                HPReport ma = new HPReport();
                ma.MachineName = "周利用率";
                ma.MachineType = "液压测试站";
                string weeks = ConfigurationSettings.AppSettings[WeekNum].ToString();
                ma.Weeks = weeks;
                ma.Week = Convert.ToInt32(weeks);
                //get A,B,C; 
                ma.WeekNum = WeekNum; 
                int totalNum = Convert.ToInt32(ConfigurationSettings.AppSettings["HPTotal"].ToString());
                ma.Rate = (totalNum - TotalDownTime) / totalNum;
                ma.IsTotal = "1";
                ma.Year = System.DateTime.Now.Year.ToString();
                ma.Create();
            }
        }

        public static void ComputeSMDownTime(string WeekNum)
        {
            IList<SMReport> sMReport = SMReport.FindbyWeeksNumAndTotal(WeekNum,"3","非停机故障");

            decimal TotalDownTime = 0;
            for (int i = 0; i < sMReport.Count; i++)
            {
                TotalDownTime = sMReport[i].MTime + TotalDownTime;
            }
            // Report 
            IList<SMReport> sMReports = SMReport.FindbyWeeksNumAndTotal(WeekNum, "1","非停机故障");
            if (sMReports.Count != 0)
            {
                SMReport ma = sMReports[0];

                string weeks = ConfigurationSettings.AppSettings[WeekNum].ToString();
                ma.Weeks = weeks;
                ma.Week = Convert.ToInt32(weeks);
                //get A,B,C;
                int totalNum = Convert.ToInt32(ConfigurationSettings.AppSettings["SMTotal"].ToString());
                ma.WeekNum = WeekNum;
                ma.Year = System.DateTime.Now.Year.ToString();
                ma.Rate = (totalNum - TotalDownTime) / totalNum;
                ma.Save();
            }
            else
            {
                SMReport ma = new SMReport();
                ma.MachineName = "周利用率";
                ma.MachineType = "钣金件";
                string weeks = ConfigurationSettings.AppSettings[WeekNum].ToString();
                ma.Weeks = weeks;
                ma.Week = Convert.ToInt32(weeks);
                //get A,B,C; 
                ma.WeekNum = WeekNum; 
                int totalNum = Convert.ToInt32(ConfigurationSettings.AppSettings["SMTotal"].ToString());
                ma.Rate = (totalNum - TotalDownTime) / totalNum;
                ma.IsTotal = "1";
                ma.Year = System.DateTime.Now.Year.ToString();
                ma.Create();
            }
        }


        public static void ComputeMASTime(DateTime Monday,DateTime EndTime)
        {
            IList<MAOrder> maos = MAOrder.FindbyDateTime(Monday.ToString("yyyy-MM-dd"), EndTime.ToString("yyyy-MM-dd"));
            
            for (int i = 0; i < maos.Count; i++)
            {
                int sc = maos[i].OrderId;

                IList<MAReport> mrs = MAReport.FindbyScanId(sc.ToString());

                if (mrs.Count == 0)
                {
                    MAReport mr = new MAReport();
                    mr.MachineName = maos[i].MachineCode;
                    mr.MachineType = maos[i].MachineType;
                    mr.ST = maos[i].ST;
                    mr.CT = maos[i].CT;
                    mr.FaultInfo = maos[i].FaultInfo;
                    mr.FaultType = maos[i].FaultType;
                    mr.IsTotal = "3";

                    mr.Year = System.DateTime.Now.Year.ToString();

                    if (maos[i].CT != null && maos[i].CT != "")
                    {
                        mr.StopTime = Convert.ToDecimal((Convert.ToDateTime(mr.CT).Subtract(Convert.ToDateTime(mr.ST))).TotalHours);
                    }
                    mr.MCT = maos[i].MCT;
                    mr.MST = maos[i].MST;

                    try
                    {
                        if ((maos[i].MST != null) && (maos[i].MCT != null))
                        {
                            mr.MTime = Convert.ToDecimal((Convert.ToDateTime(mr.MCT).Subtract(Convert.ToDateTime(mr.MST))).TotalHours);
                        }
                    }
                    catch
                    { }

                    mr.ScanId = maos[i].OrderId.ToString();
                    mr.WeekNum = Monday.ToString("yyyy-MM-dd");
                    mr.Create();
                }
                else
                {
                    for (int j = 0; j < mrs.Count ; j++)
                    {
                    	 
                    MAReport mr = MAReport.Find(mrs[j].ReportId);

                    mr.MachineName = maos[i].MachineCode;
                    mr.MachineType = maos[i].MachineType;
                    mr.ST = maos[i].ST;
                    mr.CT = maos[i].CT;
                    mr.FaultInfo = maos[i].FaultInfo;
                    mr.FaultType = maos[i].FaultType;
                    mr.IsTotal = "3";
                    mr.Year = System.DateTime.Now.Year.ToString();
                    if (maos[i].CT != null && maos[i].CT != "")
                    {
                        mr.StopTime = Convert.ToDecimal((Convert.ToDateTime(mr.CT).Subtract(Convert.ToDateTime(mr.ST))).TotalHours);
                    }
                    mr.MCT = maos[i].MCT;
                    mr.MST = maos[i].MST;

                    try
                    {
                        if ((maos[i].MST != null) && (maos[i].MCT != null))
                        {
                            mr.MTime = Convert.ToDecimal((Convert.ToDateTime(mr.MCT).Subtract(Convert.ToDateTime(mr.MST))).TotalHours);
                        }
                    }
                    catch { }
                    mr.ScanId = maos[i].OrderId.ToString();
                    mr.WeekNum = Monday.ToString("yyyy-MM-dd");
                    mr.Update(); 
                    
                    }
                }
            }

            string[] querys = MAReport.FindbyDistinctQuery(Monday.ToString("yyyy-MM-dd"));
            //计算总停机
       
            for (int i = 0; i < querys.Length; i++)
            {

                if (querys[i] != null)
                {
                    Decimal stopTime = Convert.ToDecimal(0);
                    Decimal Mtime = Convert.ToDecimal(0);

                    IList<MAReport> mrfs = MAReport.FindbyWeeksNumAndFaultType(Monday.ToString("yyyy-MM-dd"), querys[i]);
                    for (int j = 0; j < mrfs.Count; j++)
                    {
                        stopTime = mrfs[j].StopTime + stopTime;
                        Mtime = mrfs[j].MTime + Mtime;
                    }

                    string PieId = Monday.ToString("yyyy-MM-dd") + querys[i];

                    MAPOrder map = MAPOrder.Find(PieId);
                    if (map == null)
                    {
                        map = new MAPOrder();
                        map.PieId = PieId;
                        map.FaultId = querys[i];
                        map.StopTimeP = stopTime;
                        map.MTimeP = Mtime;
                        map.WeekNum = Monday.ToString("yyyy-MM-dd");
                        map.FaultType = querys[i];
                        map.Create();
                    }
                    else
                    {
                        map.StopTimeP = stopTime;
                        map.MTimeP = Mtime;
                        map.Update();
                    }
                }
            }
        }

        public static DateTime GetWeekTime(DateTime dt)
        {
            DateTime Monday;
            string dayofWeek;
            DateTime day;

            if (dt.ToString() == "0001/1/1 00:00:00")
            {
                dayofWeek = System.DateTime.Now.DayOfWeek.ToString();
                day = System.DateTime.Now.Date;
            }
            else
            {
                dayofWeek = dt.DayOfWeek.ToString();
                day = dt.Date;
            }

            //计算星期一
            TimeSpan sp = new TimeSpan();
            switch (dayofWeek)
            {
                case "Monday":
                    Monday = day;
                    break;
                case "Tuesday":
                    sp = new TimeSpan(24, 0, 0);
                    Monday = day - sp;
                    break;
                case "Wednesday":
                    sp = new TimeSpan(48, 0, 0);
                    Monday = day - sp;
                    break;
                case "Thursday":
                    sp = new TimeSpan(72, 0, 0);
                    Monday = day - sp;
                    break;
                case "Friday":
                    sp = new TimeSpan(96, 0, 0);
                    Monday = day - sp;
                    break;
                case "Saturday":
                    sp = new TimeSpan(120, 0, 0);
                    Monday = day - sp;
                    break;
                case "Sunday":
                    sp = new TimeSpan(144, 0, 0);
                    Monday = day - sp;
                    break;
                default:
                    Monday = day;
                    break;
            }
            return Monday;
        }

        public static int GetMonthLastDate(int year, int month)
        {
            DateTime lastDay = new DateTime(year, month, new System.Globalization.GregorianCalendar().GetDaysInMonth(year, month));
            int day = lastDay.Day;
            return day;
        }


        public static string GetEmailPMNotFinish(int MonthNum, string Year)
        {
            //IList<PMSPMPlan> pmsPMPlan = PMSPMPlan.FindMonthAndIsDown(MonthNum, Year);

            object[] arguments = new object[] { MonthNum, Year };

            DataTable dt = dBQuery.GetReflectionResultByDateTimes("PMMWS.PMSPMPlan", "FindMonthAndIsDown", arguments);

            string monthname = "Month" + MonthNum.ToString();

            string Contents = "<strong>本月未完成维护计划如下: P.Maintenances not finished in this month:</strong>";
            Contents = Contents.Replace("\n", "<br />") + "<br /> <br />";
            Contents += "<hr /><br />";
            Contents += " <table width = '800' border='1'>" + "<tr><td>";
            Contents += " <strong>设备名称MachineName</strong></td>";
            Contents += " <td><strong>设备型号MachineCode</strong></td>";
            Contents += "<td><strong>保养类型MaintType</strong></td>";
            Contents += "<td><strong>保养负责人M.Worker</strong></td>";
            Contents += "<td><strong>所需时间Duration</strong></td></tr>";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Contents += "<tr> <td>" + dt.Rows[i]["MachineName"] + "</td >";
                Contents += "<td>" + dt.Rows[i]["MachineType"] + "</td >";
                Contents += "<td>" + dt.Rows[i][monthname] + "</td>";
                Contents += "<td>" + dt.Rows[i]["Worker"] + "</td>";
                Contents += "<td>" + dt.Rows[i]["Duration"] + "</td></tr>";
            }
            Contents += "</table>";

            Contents += "<hr/><br/>";

            return Contents;
        }


        public static string GetEmailPMContents(int MonthNum, string Year)
        {
            string Month = "FMonth" + (MonthNum + 1).ToString();
            DataTable pmsPMPlan = dBQuery.GetReflectionResult("PMMWS.PMSPMPlan", Month, Year);

            string monthname = "Month" + (MonthNum + 1).ToString();

            string Contents = "<strong>下月设备维护计划如下: Maintenance plan in next month:</strong>";
            Contents = Contents.Replace("\n", "<br />") + "<br /> <br />";
            Contents += "<hr /><br />";
            Contents += " <table width = '800' border='1' >" + "<tr><td>";
            Contents += " <strong>设备名称Machine_Name</strong></td>";
            Contents += " <td><strong>设备型号Machine_Type</strong></td>";
            Contents += " <td><strong>保养类型Maint_Type</strong></td>";
            Contents += " <td><strong>月份Month</strong></td></tr>";

            for (int i = 0; i < pmsPMPlan.Rows.Count; i++)
            {
                Contents += "<tr><td>" + pmsPMPlan.Rows[i]["MachineName"].ToString() + "</td>";
                Contents += "<td>" + pmsPMPlan.Rows[i]["MachineType"].ToString() + "</td >";
                Contents += "<td>" + pmsPMPlan.Rows[i][monthname].ToString() + "</td> ";
                Contents += "<td>" + (MonthNum + 1).ToString() + "</td></tr>";

            }

            Contents += " </table>";
            Contents += "Comment-注释：Y：Year-年 H：Half-半年 Q：Quarter-三月 M：Month-月" + "<br />";

            Contents += "<strong>Please click the follow link to track the details: <a>http://TNWD07986:8081/PmPlan.aspx</a></strong>" + "<br />";

            Contents += "This mail is created by PMS automatically, please don't reply.";
            return Contents;


        }
        public static string GetCheckTime(IList<PMSPMBackup> bp)
        {
           // IList<PMSPMBackup> bp = PMSPMBackup.FindbyDatetime(dt1, dt2);
            string Contents = "<strong>特殊设备外检通知：Sepcial equipment checking notification:</strong>";
            Contents = Contents.Replace("\n", "<br />") + "<br /> <br />";
            Contents += "<hr /><br />";
            Contents += " <table width = '800' border='1' >" + "<tr><td>";
            Contents += " <strong>设备类型 Device_Type</strong></td>";
            Contents += " <td><strong>设备名称Device_Name</strong></td>";
            Contents += " <td><strong>测量/品种范围Contents</strong></td>";
            Contents += " <td><strong>下次外检日期CheckTime</strong></td>";
            Contents += " <td><strong>位置Position</strong></td></tr>";

            for (int i = 0; i < bp.Count; i++)
            {
                Contents += "<tr><td>" + bp[i].MachineType + "</td>";
                Contents += "<td>" + bp[i].MachineName + "</td >";
                Contents += "<td>" + bp[i].MeasureContents + "</td> ";
                Contents += "<td>" + bp[i].NextCheckTime + "</td>";
                Contents += "<td>" + bp[i].Position + "</td></tr>";
            }

            Contents += " </table>";
         
            Contents += "<strong>Please click the follow link to track the details: <a>http://TNWD07986:8081/EHSDeviceInfo.aspx</a></strong>" + "<br />";
            Contents += "This mail is created by PMS automatically, please don't reply.";
            return Contents;
        }


        public static string GetSafeQty(IList<PMSMPlan> sp)
        {
           
            string Contents = "<strong>如下备件库存以低于安全库存量：Numbers of spare parts are lower than safe stock: </strong>";
            Contents = Contents.Replace("\n", "<br />") + "<br /> <br />";
            Contents += "<hr /><br />";
            Contents += " <table width = '800' border='1' >" + "<tr><td>";
            Contents += " <strong>备件名称SP_Name</strong></td>";
            Contents += " <td><strong>备件描述Item_Description</strong></td>";
            Contents += " <td><strong>剩余库存量Qty</strong></td>";
            Contents += " <td><strong>安全库存量Safe_Qty</strong></td></tr>";

            for (int i = 0; i < sp.Count; i++)
            {
                Contents += "<tr><td>" + sp[i].SPName + "</td>";
                Contents += "<td>" + sp[i].ItemDescription + "</td >";
                Contents += "<td>" + sp[i].Qty + "</td> ";
                Contents += "<td>" + sp[i].SafeQty + "</td></tr>";
            }

            Contents += " </table>";
            Contents += "<strong>Please click the follow link to track the details: <a>http://TNWD07986:8081/SPInfo.aspx</a></strong>" + "<br />";
            Contents += "This mail is created by PMS automatically, please don't reply.";
            return Contents;
        }
    




        public static void WriteTotheXML(DateTime Monday)
        {
            XmlTextWriter writer = new XmlTextWriter(System.Web.HttpContext.Current.Server.MapPath("WeeksNum.xml"), null);
            writer.Formatting = Formatting.Indented;  //缩进格式
            writer.Indentation = 4;

            writer.WriteStartDocument();

            writer.WriteStartElement("WeeksNum");
            writer.WriteStartAttribute("id", null);

            writer.WriteString(Monday.ToString("yyyy-MM-dd"));

            writer.WriteEndAttribute();
            writer.WriteEndElement();

            writer.WriteEndDocument();
            writer.Flush();
            writer.Close();
        }
        
    
    }

}