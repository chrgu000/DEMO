// 
// Generated by ActiveRecord Generator
// 
//
namespace PMMWS
{
    using Castle.ActiveRecord;
    using Castle.ActiveRecord.Queries;
    
    [ActiveRecord("[PMS_MA_Report]")]
    public class MAReport : ActiveRecordBase
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

        private decimal _StopTime;

        private decimal _MTime;

        private decimal _rate;

        private string _IsTotal;

        private string _weeks;

        private string _faultType;

        private string _year;

        private string _orders;

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
        public decimal StopTime
        {
            get
            {
                return this._StopTime;
            }
            set
            {
                this._StopTime = value;
            }
        }
        [Property()]
        public decimal MTime
        {
            get
            {
                return this._MTime;
            }
            set
            {
                this._MTime = value;
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
        public string Orders
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
            ActiveRecordBase.DeleteAll(typeof(MAReport));
        }
        
        public static MAReport[] FindAll()
        {
            return ((MAReport[])(ActiveRecordBase.FindAll(typeof(MAReport))));
        }
        public static MAReport[] FindbyScanId(string ScanId)
        {
            SimpleQuery qe = new SimpleQuery(typeof(MAReport), @"from MAReport where Scan_Id = ? ", ScanId);
            MAReport[] MAReports = (MAReport[])ExecuteQuery(qe);
            return MAReports;
        }

        public static MAReport Find(int ReportId)
        {
            return ((MAReport)(ActiveRecordBase.FindByPrimaryKey(typeof(MAReport), ReportId)));
        }


        public static MAReport[] FindbyWeeksNum(string WeeksNum)
        {
            SimpleQuery qe = new SimpleQuery(typeof(MAReport), @"from MAReport where WeekNum = ?", WeeksNum);
            MAReport[] MAReports = (MAReport[])ExecuteQuery(qe);
            return MAReports;
        }

        public static MAReport[] FindbyWeeksNumAndFaultInfo(string WeeksNum,string FaultInfo)
        {
            SimpleQuery qe = new SimpleQuery(typeof(MAReport), @"from MAReport where WeekNum = ? and Fault_Info =?", WeeksNum, FaultInfo);
            MAReport[] MAReports = (MAReport[])ExecuteQuery(qe);
            return MAReports;
        }

        public static MAReport[] FindbyWeeksNumAndFaultType(string WeeksNum, string FaultType)
        {
            SimpleQuery qe = new SimpleQuery(typeof(MAReport), @"from MAReport where WeekNum = ? and FaultType =?", WeeksNum, FaultType);
            MAReport[] MAReports = (MAReport[])ExecuteQuery(qe);
            return MAReports;
        }


        public static MAReport[] FindbyWeeksNumAndTotal(string WeeksNum, string Total,string FaultType)
        {
            SimpleQuery qe = new SimpleQuery(typeof(MAReport), @"from MAReport where WeekNum = ? and IsTotal =? and ( FaultType is null or FaultType != ? )", WeeksNum, Total, FaultType);
            MAReport[] MAReports = (MAReport[])ExecuteQuery(qe);
            return MAReports;
        }


        public static MAReport[] FindbyTotal(string Total)
        {
            SimpleQuery qe = new SimpleQuery(typeof(MAReport), @"from MAReport where IsTotal =? order by Week", Total);
            MAReport[] MAReports = (MAReport[])ExecuteQuery(qe);
            return MAReports;
        }


        public static MAReport[] FindbyTotalandYear(string Total,string Year)
        {
            SimpleQuery qe = new SimpleQuery(typeof(MAReport), @"from MAReport where IsTotal =? and Year =? order by Week", Total,Year);
            MAReport[] MAReports = (MAReport[])ExecuteQuery(qe);
            return MAReports;
        }

        public static MAReport[] FindbyTotalandLastYear(string Total, string Year)
        {
            SimpleQuery qe = new SimpleQuery(typeof(MAReport), @"from MAReport where IsTotal =? and Year >=? order by Week", Total, Year);
            MAReport[] MAReports = (MAReport[])ExecuteQuery(qe);
            return MAReports;
        }


        public static string[] FindbyDistinctQuery(string WeekNum)
        {

            SimpleQuery query = new SimpleQuery(typeof(MAReport), typeof(string), @"select distinct mareport.FaultType from MAReport mareport where WeekNum = ?", WeekNum);
            return (string[])ExecuteQuery(query);
        }
       

    }
}
