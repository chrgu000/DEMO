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
                string sSQL = "select * from SystemDB_YT.dbo._UserInfo where vchrUid = '" + sUid + "' and vchrPwd = '" + sPwd + "'";
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
                string sSQL = "select vchrName from SystemDB_YT.dbo._UserInfo where vchrUid = '" + sUid + "' ";
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




        #region U8基础档案


        [WebMethod]
        public string dt存货信息(string sInvCode)
        {
            ClsU8基础档案 cls = new ClsU8基础档案();
            return cls.dt存货信息(sInvCode);
        }

      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sWhCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string s货仓(string sWhCode)
        {
            ClsU8基础档案 cls = new ClsU8基础档案();
            return cls.s货仓(sWhCode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sWhCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string s货位(string sWhCode)
        {
            ClsU8基础档案 cls = new ClsU8基础档案();
            return cls.s货位(sWhCode);
        }

        [WebMethod]
        public string s仓库(string sWhCode)
        {
            ClsU8基础档案 cls = new ClsU8基础档案();
            return cls.s仓库(sWhCode);
        }

        [WebMethod]
        public decimal d货位现存量(string sInvCode, string sBatch, string sFree1, string sFree2, string sFree3, string sFree4, string sWhPos)
        {
            ClsU8基础档案 cls = new ClsU8基础档案();
            return cls.d货位现存量(sInvCode, sBatch, sFree1, sFree2, sFree3, sFree4, sWhPos);
        }

        [WebMethod]
        public decimal d仓库现存量(string sInvCode, string sBatch, string sFree1, string sFree2, string sFree3, string sFree4, string sWhCode)
        {
            ClsU8基础档案 cls = new ClsU8基础档案();
            return cls.d仓库现存量(sInvCode, sBatch, sFree1, sFree2, sFree3, sFree4, sWhCode);
        
        }

        [WebMethod]
        public string Chk货位是否存在(string sBarCode)
        {
            ClsU8基础档案 cls = new ClsU8基础档案();
            return cls.Chk货位是否存在(sBarCode);
        }

        #endregion

        #region 采购

        [WebMethod]
        public string Chk采购入库条码是否已经使用(string sBarCode)
        {
            Cls采购入库单 cls = new Cls采购入库单();
            return cls.Chk采购入库条码是否已经使用(sBarCode);
        }
        
        [WebMethod]
        public string Save采购入库单(DataTable dt)
        {
            Cls采购入库单 cls = new Cls采购入库单();
            return cls.Save采购入库单(dt);
        }

        [WebMethod]
        public string dt采购条码信息(string sBarCode, string sCode)
        {
            Cls采购订单 cls = new Cls采购订单();
            return cls.dt采购条码信息(sBarCode, sCode);
        }

        [WebMethod]
        public string dt到货单信息(string sCode)
        {
            Cls到货单 cls = new Cls到货单();
            return cls.dt到货单信息(sCode);
        }

        [WebMethod]
        public string dt到货单明细信息(string sCode,string sWhere)
        {
            Cls到货单 cls = new Cls到货单();
            return cls.dt到货单明细信息(sCode, sWhere);
        }

        [WebMethod]
        public string dt到货单明细信息2(string sCode, string sWhere)
        {
            Cls到货单 cls = new Cls到货单();
            return cls.dt到货单明细信息(sCode, sWhere);
        }

        [WebMethod]
        public string dt采购订单信息(string sCode)
        {
            Cls采购订单 cls = new Cls采购订单();
            return cls.dt采购订单信息(sCode);
        }

        #endregion


        #region 生产

        [WebMethod]
        public string dt生产订单信息(string sCode,string sRowNo)
        {
            Cls生产订单 cls = new Cls生产订单();
            return cls.dt生产订单信息(sCode, sRowNo);
        }

        [WebMethod]
        public string dt生产订单子件信息(string sCode, string sRowNo,string sInvcode)
        {
            Cls生产订单 cls = new Cls生产订单();
            return cls.dt生产订单子件信息(sCode, sRowNo, sInvcode);
        }

        #region 材料出库

        [WebMethod]
        public string dt材料出库条码信息(string sBarCode, string sCode, string sRowNO)
        {
            Cls材料出库单 cls = new Cls材料出库单();
            return cls.dt材料出库条码信息(sBarCode, sCode, sRowNO);
        }

        [WebMethod]
        public string Chk材料出库条码是否已经使用(string sBarCode)
        {
            Cls材料出库单 cls = new Cls材料出库单();
            return cls.Chk材料出库条码是否已经使用(sBarCode);
        }

        [WebMethod]
        public string Save材料出库单(DataTable dt,string iRowNo)
        {
            Cls材料出库单 cls = new Cls材料出库单();
            return cls.Save材料出库单(dt, iRowNo);
        }

        #endregion

        [WebMethod]
        public string Save产品入库单(DataTable dt)
        {
            Cls产品入库单 cls = new Cls产品入库单();
            return cls.Save产品入库单(dt);
        }

        [WebMethod]
        public string Chk产品入库条码是否已经使用(string sBarCode)
        {
            Cls产品入库单 cls = new Cls产品入库单();
            return cls.Chk产品入库条码是否已经使用(sBarCode);
        }

        [WebMethod]
        public string dt产品入库条码信息(string sBarCode)
        {
            Cls产品入库单 cls = new Cls产品入库单();
            return cls.dt产品入库条码信息(sBarCode);
        }
        #endregion

        
        [WebMethod]
        public string Chk销售出库条码是否已经使用(string sBarCode)
        {
            Cls销售出库单 cls = new Cls销售出库单();
            return cls.Chk销售出库条码是否已经使用(sBarCode);
        }

        [WebMethod]
        public string dt销售出库条码信息(string sBarCode, string sCode)
        {
            Cls销售出库单 cls = new Cls销售出库单();
            return cls.dt销售出库条码信息(sBarCode, sCode);
        }

        [WebMethod]
        public string dt销售订单信息(string sCode)
        {
            Cls销售订单 cls = new Cls销售订单();
            return cls.dt销售订单信息(sCode);
        }

        [WebMethod]
        public string dt销售订单明细信息(string sCode, string sWhere)
        {
            Cls销售订单 cls = new Cls销售订单();
            return cls.dt销售订单明细信息(sCode, sWhere);
        }

        [WebMethod]
        public string Save销售出库单(DataTable dt)
        {
            Cls销售发票 cls = new Cls销售发票();
            return cls.Save销售出库单(dt);
        }

        [WebMethod]
        public string dt发货单信息(string sCode)
        {
            Cls发货单 cls = new Cls发货单();
            return cls.dt发货单信息(sCode);
        }

        [WebMethod]
        public string dt盘点单信息(string sCode)
        {
            Cls盘点单 cls = new Cls盘点单();
            return cls.dt盘点单信息(sCode);
        }

        [WebMethod]
        public string dt盘点条码信息(string sBarCode, string sCode)
        {
            Cls盘点单 cls = new Cls盘点单();
            return cls.dt盘点条码信息(sBarCode, sCode);
        }


        [WebMethod]
        public string Save盘点数据(DataTable dt,string sCode)
        {
            Cls盘点单 cls = new Cls盘点单();
            return cls.Save盘点数据(dt, sCode);
        }

        [WebMethod]
        public string Save货位调整单(DataTable dt)
        {
            Cls货位调整单 cls = new Cls货位调整单();
            return cls.Save货位调整单(dt);
        }

        [WebMethod]
        public string dt存货条码信息(string sBarCode)
        {
            ClsU8基础档案 cls = new ClsU8基础档案();
            return cls.dt存货条码信息(sBarCode);
        }

    }
}
