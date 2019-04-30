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
using System.Data.SqlClient;

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
        ClsDES ClsDES = ClsDES.Instance();

        [WebMethod]
        public string UpdateSO_ScanStatus(string sSOCodeStatus)
        {
            string sReturn = "Err";

            try
            {
                if (DateTime.Now > Convert.ToDateTime("2019-06-30"))
                    return "Err";

                ClsU8.SO_SOMain cls = new SO_SOMain();

                SqlConnection conn = new SqlConnection(ClsBaseClass.ClsBaseDataInfo.sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    sReturn = ClsDES.Encrypt(cls.Update_SO_ScanStatus(tran, sSOCodeStatus));

                    if (sReturn.StartsWith("Err"))
                    {
                        throw new Exception(sReturn);
                    }
                    else
                    {
                        tran.Commit();
                    }
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                sReturn = ee.Message;
            }
            return sReturn;
        }

        [WebMethod]
        public string UpdatePO_ScanStatus(string sPOCodeStatus)
        {
            string sReturn = "Err";

            try
            {
                if (DateTime.Now > Convert.ToDateTime("2019-06-30"))
                    return "Err";

                ClsU8.PO_Pomain cls = new PO_Pomain();

                SqlConnection conn = new SqlConnection(ClsBaseClass.ClsBaseDataInfo.sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    sReturn = ClsDES.Encrypt(cls.Update_PO_ScanStatus(tran, sPOCodeStatus));

                    if (sReturn.StartsWith("Err"))
                    {
                        throw new Exception(sReturn);
                    }
                    else
                    {
                        tran.Commit();
                    }
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                sReturn = ee.Message;
            }
            return sReturn;

            //string sReturn = "Err";

            //try
            //{
            //    if (DateTime.Now > Convert.ToDateTime("2019-06-30"))
            //        return "Err";

            //    ClsU8.PO_Pomain cls = new PO_Pomain();

            //    SqlConnection conn = new SqlConnection(ClsBaseClass.ClsBaseDataInfo.sConnString);
            //    conn.Open();
            //    try
            //    {
            //        sReturn = ClsDES.Encrypt(cls.Update_PO_ScanStatus(sSOCode, sStatus));

            //        if (sReturn.StartsWith("Err"))
            //        {
            //            throw new Exception(sReturn);
            //        }

            //    }
            //    catch (Exception ee)
            //    {
            //        throw new Exception(ee.Message);
            //    }
            //}
            //catch (Exception ee)
            //{
            //    sReturn = ee.Message;
            //}

            //return sReturn;
        }
        [WebMethod]
        public string Add_DispatchList(string sdt)
        {
            string sReturn = "Err";

            try
            {
                if (DateTime.Now > Convert.ToDateTime("2019-06-30"))
                    return "Err";

                ClsU8.DispatchList cls = new DispatchList();

                SqlConnection conn = new SqlConnection(ClsBaseClass.ClsBaseDataInfo.sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    DataTable dt = Cls序列化.DeserializeDataTable(ClsDES.Decrypt(sdt));

                    sReturn = ClsDES.Encrypt(cls.Add_DispatchList(tran, dt));

                    if (sReturn.StartsWith("Err"))
                    {
                        throw new Exception(sReturn);
                    }
                    else
                    {
                        tran.Commit();
                    }
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
            }
             catch (Exception ee)
            {
                sReturn = ee.Message;
            }
            return sReturn;
        }

        [WebMethod]
        public string Add_Rdrecord01(string sdt)
        {
            string sReturn = "Err";

            try
            {
                if (DateTime.Now > Convert.ToDateTime("2019-06-30"))
                    return "Err";

                ClsU8.Rdrecord01 cls = new Rdrecord01();

                SqlConnection conn = new SqlConnection(ClsBaseClass.ClsBaseDataInfo.sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    DataTable dt = Cls序列化.DeserializeDataTable(ClsDES.Decrypt(sdt));

                    sReturn = ClsDES.Encrypt(cls.Add_Rdrecord01(tran, dt));

                    if (sReturn.StartsWith("Err"))
                    {
                        throw new Exception(sReturn);
                    }
                    else
                    {
                        tran.Commit();
                    }
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                sReturn = ee.Message;
            }
            return sReturn;
        }
    }
}
