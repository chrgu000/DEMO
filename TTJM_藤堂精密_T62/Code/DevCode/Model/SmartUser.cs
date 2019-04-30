using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TH.Model
{
    public class SmartUser
    {
        private string _userid;
        private string _pwd;
        private DateTime? _enddate;
        /// <summary>
        /// 
        /// </summary>
        public string UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Pwd
        {
            set { _pwd = value; }
            get { return _pwd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? EndDate
        {
            set { _enddate = value; }
            get { return _enddate; }
        }
    }
}