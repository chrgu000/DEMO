using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.IO;
using System.Xml;
using ClsU8;
using ClsBaseClass;

namespace TH.DBWebService
{
    
    /// <summary>
    /// 
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class DBWebService : System.Web.Services.WebService
    {
        [WebMethod]
        public string AddPU_AppVouch(string sXML)
        {
            try
            {
                string sConn = System.Configuration.ConfigurationManager.ConnectionStrings["sConnString"].ConnectionString;
                int iStart = sConn.IndexOf("UFDATA_");
                int iYear = ClsBaseClass.ClsBaseDataInfo.ReturnObjectToInt(sConn.Substring(iStart + 11, 4));
                ClsBaseClass.ClsBaseDataInfo.sConnString = sConn;
                ClsBaseClass.ClsBaseDataInfo.sAccID = sConn.Substring(iStart + 7, 3);
                ClsBaseClass.ClsBaseDataInfo.sUFDataBaseName = sConn.Substring(iStart, 15);

                ClsU8.PU_AppVouch cls = new PU_AppVouch();
                return cls.AddPU_AppVouch(sXML);
            }
            catch (Exception ee)
            {
                return "Err:" + ee.Message;
            }
        }

        [WebMethod]
        public string AddMaterialAppVouch(string sXML)
        {
            try
            {
                string sConn = System.Configuration.ConfigurationManager.ConnectionStrings["sConnString"].ConnectionString;
                int iStart = sConn.IndexOf("UFDATA_");
                int iYear = ClsBaseClass.ClsBaseDataInfo.ReturnObjectToInt(sConn.Substring(iStart + 11, 4));
                ClsBaseClass.ClsBaseDataInfo.sConnString = sConn;
                ClsBaseClass.ClsBaseDataInfo.sAccID = sConn.Substring(iStart + 7, 3);
                ClsBaseClass.ClsBaseDataInfo.sUFDataBaseName = sConn.Substring(iStart, 15);

                ClsU8.MaterialAppVouch cls = new ClsU8.MaterialAppVouch();
                return cls.AddMaterialAppVouch(sXML);
            }
            catch (Exception ee)
            {
                return "Err:" + ee.Message;
            }
        }
    }
}
