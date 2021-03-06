// 
// Generated by ActiveRecord Generator
// 
//
namespace PMMWS
{
    using Castle.ActiveRecord;
    using Castle.ActiveRecord.Queries;
  
    [ActiveRecord("[PMS_CM_Report]")]
    public class CMReport : ActiveRecordBase
    {
        
        private int _reportId;
        
        private string _machineName;
        
        private string _machineType;
        
        private string _sT;
        
        private string _cT;
        
        private string _mST;
        
        private string _mCT;
        
        private string _weekNum;
        
        private string _faultInfo;
        
        private string _scanId;
        
        private decimal _stopTime;
        
        private decimal _mTime;

        private string _faultType;

        private decimal _rate;

        private string _IsTotal;

        private string _weeks;

        private string _year;

        private int _orders;

        private int _week;

        [PrimaryKey(PrimaryKeyType.Native, "Report_Id")]
        public int ReportId
        {
            get
            {
                return this._reportId;
            }
            set
            {
                this._reportId = value;
            }
        }
        
        [Property(Column="Machine_Name")]
        public string MachineName
        {
            get
            {
                return this._machineName;
            }
            set
            {
                this._machineName = value;
            }
        }
        
        [Property(Column="Machine_Type")]
        public string MachineType
        {
            get
            {
                return this._machineType;
            }
            set
            {
                this._machineType = value;
            }
        }
        
        [Property()]
        public string ST
        {
            get
            {
                return this._sT;
            }
            set
            {
                this._sT = value;
            }
        }
        
        [Property()]
        public string CT
        {
            get
            {
                return this._cT;
            }
            set
            {
                this._cT = value;
            }
        }
        
        [Property()]
        public string MST
        {
            get
            {
                return this._mST;
            }
            set
            {
                this._mST = value;
            }
        }
        
        [Property()]
        public string MCT
        {
            get
            {
                return this._mCT;
            }
            set
            {
                this._mCT = value;
            }
        }
        
        [Property()]
        public string WeekNum
        {
            get
            {
                return this._weekNum;
            }
            set
            {
                this._weekNum = value;
            }
        }
        
        [Property(Column="Fault_Info")]
        public string FaultInfo
        {
            get
            {
                return this._faultInfo;
            }
            set
            {
                this._faultInfo = value;
            }
        }
        
        [Property(Column="Scan_Id")]
        public string ScanId
        {
            get
            {
                return this._scanId;
            }
            set
            {
                this._scanId = value;
            }
        }

        [Property()]
        public decimal Rate
        {
            get
            {
                return this._rate;
            }
            set
            {
                this._rate = value;
            }
        }
        [Property()]
        public string IsTotal
        {
            get
            {
                return this._IsTotal;
            }
            set
            {
                this._IsTotal = value;
            }
        }
        [Property()]
        public string Weeks
        {
            get
            {
                return this._weeks;
            }
            set
            {
                this._weeks = value;
            }
        }
        [Property()]
        public int Week
        {
            get
            {
                return this._week;
            }
            set
            {
                this._week = value;
            }
        }

        [Property()]
        public decimal StopTime
        {
            get
            {
                return this._stopTime;
            }
            set
            {
                this._stopTime = value;
            }
        }
        
        [Property()]
        public decimal MTime
        {
            get
            {
                return this._mTime;
            }
            set
            {
                this._mTime = value;
            }
        }


        [Property()]
        public string FaultType
        {
            get
            {
                return this._faultType;
            }
            set
            {
                this._faultType = value;
            }
        }

        [Property()]
        public string Year
        {
            get
            {
                return this._year;
            }
            set
            {
                this._year = value;
            }
        }

        [Property()]
        public int Orders
        {
            get
            {
                return this._orders;
            }
            set
            {
                this._orders = value;
            }
        }

        public static void DeleteAll()
        {
            ActiveRecordBase.DeleteAll(typeof(CMReport));
        }
        
        public static CMReport[] FindAll()
        {
            return ((CMReport[])(ActiveRecordBase.FindAll(typeof(CMReport))));
        }
        
        public static CMReport Find(int ReportId)
        {
            return ((CMReport)(ActiveRecordBase.FindByPrimaryKey(typeof(CMReport), ReportId)));
        }

        public static CMReport[] FindbyScanId(string ScanId)
        {
            SimpleQuery qe = new SimpleQuery(typeof(CMReport), @"from CMReport where Scan_Id = ? ", ScanId);
            CMReport[] CMReports = (CMReport[])ExecuteQuery(qe);
            return CMReports;
        }


        public static CMReport[] FindbyWeeksNum(string WeeksNum)
        {
            SimpleQuery qe = new SimpleQuery(typeof(CMReport), @"from CMReport where WeekNum = ?", WeeksNum);
            CMReport[] CMReports = (CMReport[])ExecuteQuery(qe);
            return CMReports;
        }
        public static CMReport[] FindbyTotalandYear(string Total, string Year)
        {
            SimpleQuery qe = new SimpleQuery(typeof(CMReport), @"from CMReport where IsTotal =? and Year =? order by Week", Total, Year);
            CMReport[] HPReports = (CMReport[])ExecuteQuery(qe);
            return HPReports;
        }

        public static CMReport[] FindbyTotal(string Total)
        {
            SimpleQuery qe = new SimpleQuery(typeof(CMReport), @"from CMReport where IsTotal =? order by Week", Total);
            CMReport[] CMReports = (CMReport[])ExecuteQuery(qe);
            return CMReports;
        }

        public static CMReport[] FindbyWeeksNumAndFaultInfo(string WeeksNum, string FaultInfo)
        {
            try
            {
                SimpleQuery qe = new SimpleQuery(typeof(CMReport), @"from CMReport where WeekNum = ? and Fault_Info =?", WeeksNum, FaultInfo);
                CMReport[] CMReports = (CMReport[])ExecuteQuery(qe);
                return CMReports;
            }
            catch
            {
                return null;
            }
        }
        public static CMReport[] FindbyWeeksNumAndFaultType(string WeeksNum, string FaultType)
        {
            try
            {
                SimpleQuery qe = new SimpleQuery(typeof(CMReport), @"from CMReport where WeekNum = ? and FaultType =?", WeeksNum, FaultType);
                CMReport[] CMReports = (CMReport[])ExecuteQuery(qe);
                return CMReports;
            }
            catch
            {
                return null;
            }
        }

        public static CMReport[] FindbyWeeksNumAndTotal(string WeeksNum, string Total,string FaultType)
        {
            SimpleQuery qe = new SimpleQuery(typeof(CMReport), @"from CMReport where WeekNum = ? and IsTotal =? and ( FaultType is null or FaultType != ? ) order by Orders", WeeksNum, Total,FaultType);
            CMReport[] CMReports = (CMReport[])ExecuteQuery(qe);
            return CMReports;
        }

        public static string[] FindbyDistinctQuery(string WeekNum)
        {

            SimpleQuery query = new SimpleQuery(typeof(CMReport), typeof(string), @"select distinct mareport.FaultType from CMReport mareport where WeekNum = ?", WeekNum);

            return (string[])ExecuteQuery(query);
        }
        public static CMReport[] FindbyWeeksNumAndTotalAndOrders(string WeeksNum, string Total, int orders)
        {
            SimpleQuery qe = new SimpleQuery(typeof(CMReport), @"from CMReport where WeekNum = ? and IsTotal =? and Orders =?", WeeksNum, Total, orders);
            CMReport[] CMReports = (CMReport[])ExecuteQuery(qe);
            return CMReports;
        }

        public static CMReport[] FindbyTotalandLastYear(string Total, string Year)
        {
            SimpleQuery qe = new SimpleQuery(typeof(CMReport), @"from CMReport where IsTotal =? and Year >=? order by Week", Total, Year);
            CMReport[] MAReports = (CMReport[])ExecuteQuery(qe);
            return MAReports;
        }
    }
}
