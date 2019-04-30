using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using TH.Smart.BaseClass;

namespace TH.Smart.WebService
{
    public class ClsUseWebService
    {
        TH.Smart.WebService.WebReference.WsBarCode ws = new TH.Smart.WebService.WebReference.WsBarCode();

        public ClsUseWebService()
        {
            if (TH.Smart.BaseClass.ClsBaseDataInfo.sConnString != "")
                ws.Url = TH.Smart.BaseClass.ClsBaseDataInfo.sConnString;
        }

        /// <summary>
        /// Hello Word判断是否连接到WebService
        /// </summary>
        /// <returns></returns>
        public string HelloWork()
        {
            return ws.HelloWorld();
        }

        /// <summary>
        /// 获得服务器时间
        /// </summary>
        /// <returns></returns>
        public string sServerTime()
        {
            return ws.sServerTime();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sUserID"></param>
        /// <param name="sPwd"></param>
        /// <returns></returns>
        public string sLogin(string sUserID, string sPwd)
        {
            return ws.sLogin(sUserID, sPwd);
        }


        ///// <summary>
        ///// 权限判断
        ///// </summary>
        ///// <param name="sFormID"></param>
        ///// <param name="sUserID"></param>
        ///// <returns></returns>
        //public string sCheckRight(string sFormID, string sUserID)
        //{
        //    return ws.sCheckRight(sFormID, sUserID);
        //}

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="sUid"></param>
        /// <param name="sPwd"></param>
        /// <param name="sOldPwd"></param>
        /// <returns></returns>
        public string sUpdatePwd(string sUid, string sPwd, string sOldPwd)
        {
            return ws.sUpdatePwd(sUid, sPwd, sOldPwd);
        }

        /// <summary>
        /// 保存工序流转信息
        /// </summary>
        /// <param name="dtBarCode"></param>
        /// <param name="sUid"></param>
        /// <returns></returns>
        public string sSave工序流转(DataTable dtBarCode, string sUid,string sUfName)
        {
            return ws.sSave工序流转(dtBarCode, sUid, sUfName);
        }


        /// <summary>
        /// 保存产品入库
        /// </summary>
        /// <param name="dtBarCode"></param>
        /// <param name="sUid"></param>
        /// <returns></returns>
        public string sSave产品入库(DataTable dtBarCode, string sUid, string sUfName)
        {
            return ws.sSaveRD产品入库(dtBarCode, sUid, sUfName);
        }

        public DataTable s生产订单产品工序(string sWorkIDs)
        {
            string s = ws.s生产订单产品工序(sWorkIDs);
            if (s.Length > 2)
            {
                if (s.Substring(0, 2).ToLower() == "ok")
                {
                    DataTable dt = Cls序列化.DeserializeDataTable(s.Substring(2));
                    return dt;
                }
                else
                {
                    throw new Exception(s);
                }
            }
            else
            {
                throw new Exception("获得产品工序信息失败");
            }
        }


        public DataTable s标准工序()
        {
            string s = ws.s标准工序();
            if (s.Length > 2)
            {
                if (s.Substring(0, 2).ToLower() == "ok")
                {
                    DataTable dt = Cls序列化.DeserializeDataTable(s.Substring(2));
                    return dt;
                }
                else
                {
                    throw new Exception(s);
                }
            }
            else
            {
                throw new Exception("获得产品工序信息失败");
            }
        }

        public DataTable dtGetBarCode(string sBarCode, string sUfName)
        {
            string s = ws.dtGetBarCode(sBarCode, sUfName);
            if (s.Length > 2)
            {
                if (s.Substring(0, 2).ToLower() == "ok")
                {
                    DataTable dt = Cls序列化.DeserializeDataTable(s.Substring(2));
                    return dt;
                }
                else
                {
                    throw new Exception(s);
                }
            }
            else
            {
                throw new Exception("获得产品工序信息失败");
            }
        }

        public DataTable dtBarCode执行统计(string sBarCode, string sUfName)
        {
            string s = ws.dtBarCode执行统计(sBarCode, sUfName);
            if (s.Length > 2)
            {
                if (s.Substring(0, 2).ToLower() == "ok")
                {
                    DataTable dt = Cls序列化.DeserializeDataTable(s.Substring(2));
                    return dt;
                }
                else
                {
                    throw new Exception(s);
                }
            }
            else
            {
                throw new Exception("获得产品工序信息失败");
            }
        }

        public DataTable dtWorkIDs执行统计(string lWorkIDs, string sUfName)
        {
            string s = ws.dtWorkIDs执行统计(lWorkIDs, sUfName);
            if (s.Length > 2)
            {
                if (s.Substring(0, 2).ToLower() == "ok")
                {
                    DataTable dt = Cls序列化.DeserializeDataTable(s.Substring(2));
                    return dt;
                }
                else
                {
                    throw new Exception(s);
                }
            }
            else
            {
                throw new Exception("获得产品工序信息失败");
            }
        }

        public DataTable dt帐套()
        {
            string s = ws.dt帐套();
            if (s.Length > 2)
            {
                if (s.Substring(0, 2).ToLower() == "ok")
                {
                    DataTable dt = Cls序列化.DeserializeDataTable(s.Substring(2));
                    return dt;
                }
                else
                {
                    throw new Exception(s);
                }
            }
            else
            {
                throw new Exception("获得帐套信息失败");
            }
        }

        public DataTable dt入库类别(string sUfName)
        {
            string s = ws.dtrd_style(sUfName);
            if (s.Length > 2)
            {
                if (s.Substring(0, 2).ToLower() == "ok")
                {
                    DataTable dt = Cls序列化.DeserializeDataTable(s.Substring(2));
                    return dt;
                }
                else
                {
                    throw new Exception(s);
                }
            }
            else
            {
                throw new Exception("获得入库类别失败");
            }
        }

        public DataTable dt仓库(string sUfName)
        {
            string s = ws.dtWareHouse(sUfName);
            if (s.Length > 2)
            {
                if (s.Substring(0, 2).ToLower() == "ok")
                {
                    DataTable dt = Cls序列化.DeserializeDataTable(s.Substring(2));
                    return dt;
                }
                else
                {
                    throw new Exception(s);
                }
            }
            else
            {
                throw new Exception("获得仓库失败");
            }
        }
    }
}
