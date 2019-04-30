using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BaseDllMobile;

namespace MobileBaseDLL
{
    public class ClsUseWebService
    {
        MobileBaseDLL.WebServerBarCode.DBWebService DBWebService = new MobileBaseDLL.WebServerBarCode.DBWebService();

        public ClsUseWebService()
        {
            //DBWebService.Url = "http://192.168.1.2:18000/DBService.asmx";
            DBWebService.Url = "http://192.168.39.11/WebService1/DBService.asmx";
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

        public string Save采购入库单(DataTable dt)
        {
            return DBWebService.Save采购入库单(dt);
        }

        /// <summary>
        /// 保存货位，并确认可审核
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string Save采购入库单2(DataTable dt)
        {
            return DBWebService.Save采购入库单2(dt);
        }

        public DataTable dt存货信息(string sInvCode)
        {
            string s = DBWebService.dt存货信息(sInvCode);
            DataTable dt = Cls序列化.DeserializeDataTable(s);
            return dt;
        }

        public DataTable dt采购条码信息(string sBarCode)
        {
            string s = DBWebService.dt采购条码信息(sBarCode);
            DataTable dt = Cls序列化.DeserializeDataTable(s);
            return dt;
        }

        public DataTable dt货仓(string sWhCode)
        {
            string s = DBWebService.s货仓(sWhCode);
            DataTable dt = Cls序列化.DeserializeDataTable(s);
            return dt;
        }

        public string Chk采购入库条码是否已经使用(string sBarCode)
        {
            return DBWebService.Chk采购入库条码是否已经使用(sBarCode);
        }

        public DataTable dt采购订单信息(string sCode)
        {
            string s = DBWebService.dt采购订单信息(sCode);
            DataTable dt = Cls序列化.DeserializeDataTable(s);
            return dt;
        }

        public DataTable dt销售出库单信息(string sCode)
        {
            string s = DBWebService.dt销售出库单信息(sCode);
            DataTable dt = Cls序列化.DeserializeDataTable(s);
            return dt;
        }

        public DataTable dt采购入库单信息(string sCode)
        {
            string s = DBWebService.dt采购入库单信息(sCode);
            DataTable dt = Cls序列化.DeserializeDataTable(s);
            return dt;
        }


        public DataTable dt生产订单号信息(string sDid)
        {
            string s = DBWebService.dt生产订单号信息(sDid);
            DataTable dt = Cls序列化.DeserializeDataTable(s);
            return dt;
        }


        public DataTable dt生产订单信息(string sCode, string sRowNo)
        {
            string s = DBWebService.dt生产订单信息(sCode, sRowNo);
            DataTable dt = Cls序列化.DeserializeDataTable(s);
            return dt;
        }

        public DataTable dt生产订单子件信息(string sCode, string sRowNo,string sInvCode )
        {
            string s = DBWebService.dt生产订单子件信息(sCode, sRowNo,sInvCode);
            DataTable dt = Cls序列化.DeserializeDataTable(s);
            return dt;
        }

        public string Chk材料出库条码是否已经使用(string sBarCode)
        {
            return DBWebService.Chk材料出库条码是否已经使用(sBarCode);
        }


        public DataTable dt材料出库条码信息(string sBarCode, string sCode,string sRowNO)
        {
            string s = DBWebService.dt材料出库条码信息(sBarCode, sCode, sRowNO);
            DataTable dt = Cls序列化.DeserializeDataTable(s);
            return dt;
        }


        public decimal d仓库现存量(string sInvCode, string sBatch, string sFree1, string sWhCode)
        {
            decimal d = DBWebService.d仓库现存量(sInvCode, sBatch, sFree1, sWhCode);
            return d;
        }
        
        public decimal d货位现存量(string sInvCode, string sBatch, string sFree1, string sWhPos)
        {
            decimal d = DBWebService.d货位现存量(sInvCode, sBatch, sFree1, sWhPos);
            return d;
        }

        public string Save材料出库单(DataTable dt)
        {
            return DBWebService.Save材料出库单(dt);
        }

        public DataTable dt产品入库条码信息(string sBarCode)
        {
            string s = DBWebService.dt产品入库条码信息(sBarCode);
            DataTable dt = Cls序列化.DeserializeDataTable(s);
            return dt;
        }

        public DataTable dt销售出库条码信息(string sBarCode)
        {
            string s = DBWebService.dt销售出库条码信息(sBarCode);
            DataTable dt = Cls序列化.DeserializeDataTable(s);
            return dt;
        }

        public string Chk销售出库条码是否已经使用(string sBarCode)
        {
            return DBWebService.Chk销售出库条码是否已经使用(sBarCode);
        }

        public string Save产品入库单(DataTable dt)
        {
            return DBWebService.Save产品入库单(dt);
        }


        public string Chk产品入库条码是否已经使用(string sBarCode)
        {
            return DBWebService.Chk产品入库条码是否已经使用(sBarCode);
        }


        public DataTable dt销售订单信息(string sCode)
        {
            string s = DBWebService.dt销售订单信息(sCode);
            DataTable dt = Cls序列化.DeserializeDataTable(s);
            return dt;
        }

        public string Save销售出库单(DataTable dt)
        {
            return DBWebService.Save销售出库单(dt);
        }

        public string Save销售出库单2(DataTable dt)
        {
            return DBWebService.Save销售出库单2(dt);
        }

        public DataTable dt发货单信息(string sCode)
        {
            string s = DBWebService.dt发货单信息(sCode);
            DataTable dt = Cls序列化.DeserializeDataTable(s);
            return dt;
        }

        public DataTable dt盘点单信息(string sCode)
        {
            string s = DBWebService.dt盘点单信息(sCode);
            DataTable dt = Cls序列化.DeserializeDataTable(s);
            return dt;
        }

        public DataTable dt盘点条码信息(string sBarCode, string sCode)
        {
            string s = DBWebService.dt盘点条码信息(sBarCode, sCode);
            DataTable dt = Cls序列化.DeserializeDataTable(s);
            return dt;
        }

        public string Save盘点数据(DataTable dt,string sCode)
        {
            return DBWebService.Save盘点数据(dt, sCode);
        }
    }
}
