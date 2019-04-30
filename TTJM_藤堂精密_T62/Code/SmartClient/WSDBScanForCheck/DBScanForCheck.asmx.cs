using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using TH.WebService.BaseClass;
using System.Data;
using System.Configuration;


namespace WSDBScanForCheck
{
    /// <summary>
    /// WsBarCode 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class WsBarCode : System.Web.Services.WebService
    {

        public WsBarCode()
        {
            TH.WebService.BaseClass.DbHelperSQL.connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string sServerTime()
        {
            string obj = DateTime.Today.ToString("yyyy-MM-dd");
            try
            {
                string sSQL = "select getdate()";
                DataTable dt = DbHelperSQL.Query(sSQL);

                obj = BaseFunction.ReturnDate(dt.Rows[0][0]).ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch (Exception ee)
            {

            }
            return obj;
        }

        ///// <summary>
        ///// 权限判断
        ///// </summary>
        ///// <param name="sUid"></param>
        ///// <param name="sPwd"></param>
        ///// <returns></returns>
        //[WebMethod]
        //public string sCheckRight(string sFormID, string sUserid)
        //{
        //    string sReturn = "";
        //    try
        //    {
        //        string sSQL = "SELECT UserID,FormID FROM [_UserRight] where UserID = '" + sUserid + "' and FormID = '" + sFormID + "'";
        //        DataTable dt = DbHelperSQL.Query(sSQL);

        //        if (dt != null && dt.Rows.Count > 0)
        //        {
        //            sReturn = "1";
        //        }
        //        else
        //        {
        //            sReturn = "0";
        //        }

        //    }
        //    catch (Exception ee)
        //    {
        //        sReturn = "0";
        //    }
        //    return sReturn;
        //}

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="sUid"></param>
        /// <param name="sPwd"></param>
        /// <returns></returns>
        [WebMethod]
        public string sLogin(string sUid, string sPwd)
        {
            string sReturn = "";
            try
            {
                string sSQL = "select * from dbo._User where [UserID] = '" + sUid + "' and [Pwd] = '" + sPwd + "' ";
                DataTable dt = DbHelperSQL.Query(sSQL);

                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception( "账号密码不匹配");
                }

                if (dt.Rows[0]["EndDate"].ToString().Trim() != "")
                {
                    DateTime dEndDate = Convert.ToDateTime(dt.Rows[0]["EndDate"]);
                    if (dEndDate <= Convert.ToDateTime(sServerTime()))
                    {
                        throw new Exception("账号已停用");
                    }
                }

            }
            catch (Exception ee)
            {
                sReturn = ee.Message;
            }
            return sReturn;
        }


       /// <summary>
       /// 修改密码
       /// </summary>
       /// <param name="sUid"></param>
       /// <param name="sPwd"></param>
       /// <param name="sOldPwd"></param>
       /// <returns></returns>
        [WebMethod]
        public string sUpdatePwd(string sUid, string sPwd,string sOldPwd)
        {
            string sReturn = "";
            try
            {
                string s = sLogin(sUid, sOldPwd);

                if (s == "")
                {
                    string sSQL = "update _User set Pwd = '" + sPwd + "' where UserID = '" + sUid + "'";
                    int iCou = DbHelperSQL.ExecuteSql(sSQL);

                    if (iCou > 0)
                    {
                        sReturn = "";
                    }
                }
                else
                {

                    sReturn = "账号、原密码不匹配，不能修改";
                }
            }
            catch (Exception ee)
            {

            }
            return sReturn;
        }

        /// <summary>
        /// 保存工序流转数据
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string sSave工序流转(DataTable dtBarCode, string sUid, string sUfName)
        {
            string sReturn = "";
            try
            {
                TH.DAL.工序流转 DAL = new TH.DAL.工序流转();

                int iCou = DAL.iSave(dtBarCode, sUid, sUfName);
                if (iCou > 0)
                {
                    sReturn = "OK";
                }
                else
                {
                    throw new Exception("没有需要保存的数据");
                }
            }
            catch (Exception ee)
            {
                sReturn = "sErr:" + ee.Message;
            }
            return sReturn;
        }

        /// <summary>
        /// 保存产品入库
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string sSaveRD产品入库(DataTable dtBarCode, string sUid, string sUfNAme)
        {
            string sReturn = "";
            try
            {
                TH.DAL.工序流转 DAL = new TH.DAL.工序流转();

                sReturn = DAL.iSaveRD产品入库(dtBarCode, sUid, sUfNAme);
            }
            catch (Exception ee)
            {
                sReturn = "sErr:" + ee.Message;
            }
            return sReturn;
        }

        /// <summary>
        /// 获得生产订单工序信息
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string s生产订单产品工序(string sWorkIDs)
        {
            string sReturn = "";
            try
            {
                TH.DAL.生产订单产品工序 DAL = new TH.DAL.生产订单产品工序();
                DataTable dt = DAL.dt生产订单产品工序(sWorkIDs);

                if (dt != null && dt.Rows.Count > 0)
                {
                    sReturn ="OK" + Cls序列化.SerializeDataTableXml(dt);
                }

            }
            catch (Exception ee)
            {
                sReturn = "sErr:" + ee.Message;
            }
            return sReturn;
        }

        /// <summary>
        /// 获得标准工序信息
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string s标准工序()
        {
            string sReturn = "";
            try
            {
                string sSQL = @"
select WorkProcessNo,WorkProcessName 
from WorkProcess
Order by WorkProcessNo
";

                DataTable dt = DbHelperSQL.Query(sSQL);

                if (dt != null && dt.Rows.Count > 0)
                {
                    sReturn = "OK" + Cls序列化.SerializeDataTableXml(dt);
                }

                if (dt != null && dt.Rows.Count > 0)
                {
                    sReturn = "OK" + Cls序列化.SerializeDataTableXml(dt);
                }

            }
            catch (Exception ee)
            {
                sReturn = "sErr:" + ee.Message;
            }
            return sReturn;
        }
               
        /// <summary>
        /// 获得条形码工序信息
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string dtGetBarCode(string sBarCode, string sUfName)
        {
            string sReturn = "";
            try
            {
                TH.DAL.工序流转 DAL = new TH.DAL.工序流转();
                DataTable dt = DAL.dtGetBarCode(sBarCode, sUfName);

                if (dt != null && dt.Rows.Count > 0)
                {
                    sReturn = "OK" + Cls序列化.SerializeDataTableXml(dt);
                }

            }
            catch (Exception ee)
            {
                sReturn = "sErr:" + ee.Message;
            }
            return sReturn;
        }

        /// <summary>
        /// 获得条形码执行情况
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string dtBarCode执行统计(string sBarCode, string sUfName)
        {
            string sReturn = "";
            try
            {
                TH.DAL.工序流转 DAL = new TH.DAL.工序流转();
                DataTable dt = DAL.dtBarCode执行统计(sBarCode, sUfName);

                if (dt != null && dt.Rows.Count > 0)
                {
                    sReturn = "OK" + Cls序列化.SerializeDataTableXml(dt);
                }

            }
            catch (Exception ee)
            {
                sReturn = "sErr:" + ee.Message;
            }
            return sReturn;
        }

        /// <summary>
        /// 获得生产订单执行情况
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string dtWorkIDs执行统计(string lWorkIDs, string sUfName)
        {
            string sReturn = "";
            try
            {
                TH.DAL.工序流转 DAL = new TH.DAL.工序流转();
                DataTable dt = DAL.dtWorkIDs执行统计(lWorkIDs, sUfName);

                if (dt != null && dt.Rows.Count > 0)
                {
                    sReturn = "OK" + Cls序列化.SerializeDataTableXml(dt);
                }

            }
            catch (Exception ee)
            {
                sReturn = "sErr:" + ee.Message;
            }
            return sReturn;
        }

        

        /// <summary>
        /// 获得帐套信息
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string dt帐套()
        {
            string sReturn = "";
            try
            {
                string sSQL = @"
SELECT DISTINCT A.cAcc_Id,'[' + A.cAcc_Id + ']' + A.cAcc_Name as vchrText 
FROM UFSystem.dbo.UA_Account A,UFSystem.dbo.UA_period P
WHERE A.cAcc_Id=P.cAcc_Id AND (P.bIsDelete=0 OR P.bIsDelete IS NULL)
ORDER BY A.cAcc_Id,vchrText
";
                DataTable dt = DbHelperSQL.Query(sSQL);

                if (dt != null && dt.Rows.Count > 0)
                {
                    sReturn = "OK" + Cls序列化.SerializeDataTableXml(dt);
                }

            }
            catch (Exception ee)
            {
                sReturn = "sErr:" + ee.Message;
            }
            return sReturn;
        }


        /// <summary>
        /// 获得仓库信息
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string dtWareHouse(string sUfName)
        {
            string sReturn = "";
            try
            {
                string sSQL = @"
select cWhCode ,cWhName from @u8.Warehouse order by cWhCode
";
                sSQL = sSQL.Replace("@u8", sUfName + ".");
                DataTable dt = DbHelperSQL.Query(sSQL);

                if (dt != null && dt.Rows.Count > 0)
                {
                    sReturn = "OK" + Cls序列化.SerializeDataTableXml(dt);
                }

            }
            catch (Exception ee)
            {
                sReturn = "sErr:" + ee.Message;
            }
            return sReturn;
        }

        /// <summary>
        /// 获得入库类别
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string dtrd_style(string sUfName)
        {
            string sReturn = "";
            try
            {
                string sSQL = @"
select cRdCode,cRdName from @u8.rd_style where bRdFlag = 1 and ISNULL(bRdEnd ,0) = 1 order by cRdCode
";
                sSQL = sSQL.Replace("@u8", sUfName + ".");
                DataTable dt = DbHelperSQL.Query(sSQL);

                if (dt != null && dt.Rows.Count > 0)
                {
                    sReturn = "OK" + Cls序列化.SerializeDataTableXml(dt);
                }

            }
            catch (Exception ee)
            {
                sReturn = "sErr:" + ee.Message;
            }
            return sReturn;
        }
    }
}
