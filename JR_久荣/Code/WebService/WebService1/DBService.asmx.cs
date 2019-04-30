using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.IO;
using System.Xml;
using ClsBaseClass;
using ClsU8;

namespace TH.DBWebService
{
    /// <summary>
    /// 基于U8V10.1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class DBWebService : System.Web.Services.WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public bool b登陆(string sUid, string sPwd)
        {
            bool obj = false;
            try
            {
                string sSQL = "select * from _UserInfo where vchrUid = '" + sUid + "' and vchrPwd = '" + sPwd + "'";
                DataTable dt = SqlHelper.ExecuteDataset(ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).Tables[0];

                if (dt != null && dt.Rows.Count > 0)
                {
                    obj = true;
                }
            }
            catch (Exception ee)
            {

            }
            return obj;
        }


        [WebMethod]
        public string s登陆(string sUid)
        {
            try
            {
                string sSQL = "select vchrName from _UserInfo where vchrUid = '" + sUid + "' ";
                DataTable dt = SqlHelper.ExecuteDataset(ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).Tables[0];

                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["vchrName"].ToString().Trim();
                }
            }
            catch (Exception ee)
            {

            }
            return "";
        }


        [WebMethod]
        public DateTime dtm当前服务器时间()
        {
            DateTime dToday = Convert.ToDateTime("1900-01-01");
            try
            {
                string sSQL = "select getdate()";
                dToday = Convert.ToDateTime( SqlHelper.ExecuteScalar(ClsBaseDataInfo.sConnString, CommandType.Text, sSQL));
            }
            catch (Exception ee)
            {

            }
            return dToday;
        }

        [WebMethod]
        public string dtInventory(string cInvCode)
        {
            Cls现品票登记 cls = new Cls现品票登记();
            return cls.dtInventory(cInvCode);
        }

        [WebMethod]
        public string sDoor(string iPF, string iPlace)
        {
            Cls现品票登记 cls = new Cls现品票登记();
            return cls.sDoor(iPF, iPlace);
        }


        [WebMethod]
        public string Save现品票登记(DataTable dt)
        {
            Cls现品票登记 cls = new Cls现品票登记();
            return cls.Save现品票登记(dt);
        }

        [WebMethod]
        public string dt发货计划(string sBarCode, string sQRCode, string iUsedAutoID)
        {
            Cls出库单 cls = new Cls出库单();
            return cls.dt发货计划(sBarCode, sQRCode, iUsedAutoID);
        }

        [WebMethod]
        public string chk发货计划(string sBarCode)
        {
            Cls出库单 cls = new Cls出库单();
            return cls.chk发货计划(sBarCode);
        }

        [WebMethod]
        public string Save出库单(DataTable dt)
        {
            Cls出库单 cls = new Cls出库单();
            return cls.Save出库单(dt);
        }

       
    }
}
