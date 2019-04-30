using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BaseDllMobile;
using System.IO;
using System.Reflection;

namespace MobileBaseDLL
{
    public class ClsUseWebService
    {
        MobileBaseDLL.WebServerBarCode.DBWebService DBWebService = new MobileBaseDLL.WebServerBarCode.DBWebService();

        public ClsUseWebService()
        {
            DBWebService.Url = "http://222.92.148.148:18080/DBService.asmx";
            //DBWebService.Url = "http://192.168.30.222/webJR/DBService.asmx";
        }


        public DateTime dtm当前服务器时间()
        {
            return DBWebService.dtm当前服务器时间();
        }

        public bool b登陆(string sUserID, string sPwd)
        {
            bool b = false;

            b = DBWebService.b登陆(sUserID, sPwd);

            return b;
        }

        public string s登陆(string sUserID)
        {
            return DBWebService.s登陆(sUserID);
        }

        public DataTable dtInventory(string cInvCode)
        {
            string s = DBWebService.dtInventory(cInvCode);
            DataTable dt = Cls序列化.DeserializeDataTable(s);
            return dt;
        }

        public DataTable sDoor(string iPF, string iPlace)
        {
            string s = DBWebService.sDoor(iPF, iPlace);
            DataTable dt = Cls序列化.DeserializeDataTable(s);
            return dt;
        }

        public string Save现品票登记(DataTable dt)
        {
            return DBWebService.Save现品票登记(dt);
        }

        public DataTable dt发货计划(string sBarCode, string sQRCode, string iUsedAutoID)
        {
            string s = DBWebService.dt发货计划(sBarCode, sQRCode, iUsedAutoID);
            DataTable dt = Cls序列化.DeserializeDataTable(s);
            return dt;
        }

        public string Chk发货计划(string sBarCode)
        {
            return DBWebService.chk发货计划(sBarCode);
        }

        public string Save出库单(DataTable dt)
        {
            return DBWebService.Save出库单(dt);
        }
    }
}
