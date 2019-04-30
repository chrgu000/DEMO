using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using UFIDA.U8.UAP.CustomApp.MetaData;
using TH.BaseClass;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.Business
{
    public class Sa_CloseBillBLL
    {

        private static string _dataSourceStr = @"Select cast(0 as bit) as ischk,* 
From Ap_CloseBill a with (nolock) where 1=1 and a.cFlag='AR' Order By dVouchDate ASC,cVouchID ASC";

        private static string _dataSourceStr1 = @"Select * 
From Ap_CloseBills a with (nolock) where 1=1 ";

        public static DataTable GetFormsData1(string filter, string conn)
        {
            string sql = _dataSourceStr1.Replace("1=1", "1=1 " + filter);
            DataTable dtss = SqlHelper.ExecuteDataset(conn, CommandType.Text, sql).Tables[0];
            return dtss;
        }

        public static DataTable GetFormsData(string filter, string conn)
        {
            return Get(filter, conn).Copy();
        }

        public static DataTable Get(string filter, string conn)
        {
            string sql = _dataSourceStr.Replace("1=1", "1=1 " + filter);
            DataTable dtss = SqlHelper.ExecuteDataset(conn, CommandType.Text, sql).Tables[0];
            return dtss;
        }


    }
}