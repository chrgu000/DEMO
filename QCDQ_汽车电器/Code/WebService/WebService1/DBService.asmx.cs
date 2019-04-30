using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.IO;
using System.Xml;
using TH.BaseClass;
using ClsU8;
using System.Configuration;
using System.Data.SqlClient;

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
        public DBWebService()
        {
            TH.BaseClass.ClsBaseDataInfo.sConnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }


        /// <summary>
        /// 其他出库单
        /// </summary>
        /// <param name="sWhCode">仓库编码</param>
        /// <param name="sRdCode">出库类别</param>
        /// <param name="sDepCode">部门编码</param>
        /// <param name="sCreater">制单人</param>
        /// <param name="sDate">制单日期</param>
        /// <param name="sInvCode">存货编码</param>
        /// <param name="sQty">数量</param>
        /// <returns></returns>
        [WebMethod]
        public string sRdrecord09_Save(string sWhCode, string sRdCode, string sDepCode, string sCreater, string sDate, string sInvCode,string sBatch, string sQty)
        {
            string sReturn = "";

            try
            {
                string sAccID = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["sAccID"].ToString();

                SqlConnection conn = new SqlConnection(); 
                conn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
              
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    clsRdrecord09 cls = new clsRdrecord09();

                    DateTime dtm = Convert.ToDateTime(sDate);
                    sReturn = cls.sRdrecord09_Save(tran, sWhCode, sRdCode, sDepCode, sCreater, dtm, sInvCode, sBatch, sQty, sAccID);

                    if (sReturn == "")
                    {
                        tran.Commit();
                    }
                    else
                    {
                        throw new Exception(sReturn);
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

            if (sReturn == "")
            {
                sReturn = "OK：";
            }
            else
            {
                sReturn = "Err：" + sReturn;
            }
            return sReturn;
        }



         /// <summary>
         /// 产成品入库单
         /// </summary>
         /// <param name="sWOCode">生产订单号</param>
         /// <param name="sZJCode">检验单号</param>
         /// <param name="sWhCode">仓库编号</param>
         /// <param name="sRdCode">收发类别</param>
         /// <param name="sDepCode">部门编码</param>
         /// <param name="sCreater">制单人</param>
         /// <param name="sDate">制单日期</param>
         /// <param name="sInvCode">产品编码</param>
         /// <param name="sBatch">批次</param>
         /// <param name="sQty">数量</param>
         /// <returns></returns>
        [WebMethod]
        public string sRdrecord10_Save(string sWOCode,string sZJCode, string sWhCode, string sRdCode, string sDepCode, string sCreater, string sDate, string sInvCode,string sBatch, string sQty)
        {
            string sReturn = "";

            try
            {
                string sAccID = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["sAccID"].ToString();

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    clsRdrecord10 cls = new clsRdrecord10();

                    DateTime dtm = Convert.ToDateTime(sDate);
                    decimal dQty = BaseFunction.ReturnDecimal(sQty);
                    if (dQty <= 0)
                    {
                        throw new Exception("入库数量不能小于等于0");
                    }

                    sReturn = cls.sRdrecord10_Save(tran, sWOCode, sZJCode, sWhCode, sRdCode, sDepCode, sCreater, dtm, sInvCode, sBatch, dQty, sAccID);

                    if (sReturn == "")
                    {
                        tran.Commit();
                    }
                    else
                    {
                        throw new Exception(sReturn);
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

            if (sReturn == "")
            {
                sReturn = "OK：【生产订单号 " + sWOCode + "】";
            }
            else
            {
                sReturn = "Err：【生产订单号 " + sWOCode + "】" + sReturn;
            }
            return sReturn;
        }


        /// <summary>
        /// 采购入库单审核
        /// </summary>
        /// <param name="sCode">采购入库单号</param>
        /// <param name="sAuditer">审核人</param>
        /// <param name="sDate">审核日期</param>
        /// <returns></returns>
        [WebMethod]
        public string sRdrecord01_Audit(string sCode, string sAuditer, string sDate)
        {
            string sReturn = "";

            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    clsRdrecord01 cls = new clsRdrecord01();

                    DateTime dtm = Convert.ToDateTime(sDate);
                    sReturn = cls.sRdrecord01_Audit(tran, sCode, sAuditer, dtm);

                    if (sReturn == "")
                    {
                        tran.Commit();
                    }
                    else
                    {
                        throw new Exception(sReturn);
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

            if (sReturn == "")
            {
                sReturn = "OK：【" + sCode + "】";
            }
            else
            {
                sReturn = "Err：【" + sCode + "】" + sReturn;
            } 
            return sReturn;
        }


    }
}
