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
            DBWebService.Url = "http://192.168.31.10/DBService.asmx";
            //DBWebService.Url = "http://192.168.1.8/webTT/DBService.asmx";
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

        public string Save采购入库单(DataTable dt)
        {
            return DBWebService.Save采购入库单(dt);
        }

        public DataTable dt存货信息(string sInvCode)
        {
            string s = DBWebService.dt存货信息(sInvCode);
            DataTable dt = Cls序列化.DeserializeDataTable(s);
            return dt;
        }

        public DataTable dt采购条码信息(string sBarCode, string sCode)
        {
            string s = DBWebService.dt采购条码信息(sBarCode, sCode);
            DataTable dt = Cls序列化.DeserializeDataTable(s);
            return dt;
        }

        public DataTable dt货仓(string sWhCode)
        {
            string s = DBWebService.s货仓(sWhCode);
            DataTable dt = Cls序列化.DeserializeDataTable(s);
            return dt;
        }

        public DataTable dt货位(string sWhCode)
        {
            string s = DBWebService.s货位(sWhCode);
            DataTable dt = Cls序列化.DeserializeDataTable(s);
            return dt;
        }

        public DataTable dt仓库(string sWhCode)
        {
            string s = DBWebService.s仓库(sWhCode);
            DataTable dt = Cls序列化.DeserializeDataTable(s);
            return dt;
        }

        public string Chk货位是否存在(string sBarCode)
        {
            return DBWebService.Chk货位是否存在(sBarCode);
        }

        public string Chk采购入库条码是否已经使用(string sBarCode)
        {
            return DBWebService.Chk采购入库条码是否已经使用(sBarCode);
        }

        public DataTable dt到货单信息(string sCode)
        {
            string s = DBWebService.dt到货单信息(sCode);
            DataTable dt = Cls序列化.DeserializeDataTable(s);
            return dt;
        }

        public DataTable dt到货单明细信息(string sCode, string sWhere)
        {
            string s = DBWebService.dt到货单明细信息(sCode, sWhere);
            DataTable dt = Cls序列化.DeserializeDataTable(s);
            return dt;
        }

        public DataTable dt采购订单信息(string sCode)
        {
            string s = DBWebService.dt采购订单信息(sCode);
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

        public DataTable dt生产订单子件未出库信息(string sCode, string sRowNo)
        {
            string s = DBWebService.dt生产订单子件未出库信息(sCode, sRowNo);
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


        public decimal d仓库现存量(string sInvCode, string sBatch, string sFree1, string sFree2, string sFree3, string sFree4, string sWhCode)
        {
            decimal d = DBWebService.d仓库现存量(sInvCode, sBatch, sFree1, sFree2, sFree3, sFree4, sWhCode);
            return d;
        }

        public decimal d货位现存量(string sInvCode, string sBatch, string sFree1, string sFree2, string sFree3, string sFree4, string sWhPos)
        {
            decimal d = DBWebService.d货位现存量(sInvCode, sBatch, sFree1, sFree2, sFree3, sFree4, sWhPos);
            return d;
        }

        public string Save材料出库单(DataTable dt, string iRowNo)
        {
            return DBWebService.Save材料出库单(dt, iRowNo);
        }

        public DataTable dt产品入库条码信息(string sBarCode)
        {
            string s = DBWebService.dt产品入库条码信息(sBarCode);
            DataTable dt = Cls序列化.DeserializeDataTable(s);
            return dt;
        }

        public DataTable dt销售出库条码信息(string sBarCode, string sCode)
        {
            string s = DBWebService.dt销售出库条码信息(sBarCode, sCode);
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

        public DataTable dt销售订单明细信息(string sCode, string sWhere)
        {
            string s = DBWebService.dt销售订单明细信息(sCode, sWhere);
            DataTable dt = Cls序列化.DeserializeDataTable(s);
            return dt;
        }


        public string Save销售出库单(DataTable dt)
        {
            return DBWebService.Save销售出库单(dt);
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

        public string Save货位调整单(DataTable dt)
        {
            return DBWebService.Save货位调整单(dt);
        }

        public DataTable dt存货条码信息(string sBarCode)
        {
            string s = DBWebService.dt存货条码信息(sBarCode);
            DataTable dt = Cls序列化.DeserializeDataTable(s);
            return dt;
        }
    }
}
