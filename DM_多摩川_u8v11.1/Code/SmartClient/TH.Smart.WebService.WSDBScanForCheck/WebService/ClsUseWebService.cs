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


        /// <summary>
        /// 权限判断
        /// </summary>
        /// <param name="sFormID"></param>
        /// <param name="sUserID"></param>
        /// <returns></returns>
        public string sCheckRight(string sFormID, string sUserID)
        {
            return ws.sCheckRight(sFormID, sUserID);
        }

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
        /// 获得条形码信息
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        public DataTable dtScanBarCode(string sBarCode)
        {
            string s = ws.dtScanBarCode(sBarCode);
            if (s.Length > 0)
            {
                DataTable dt = Cls序列化.DeserializeDataTable(s);
                return dt;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得条形码信息
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        public int iChkBarCodeUsed(string sType, string sCode, string BarCode, int RDType)
        {
            return ws.iChkBarCodeUsed(sType, sCode, BarCode, RDType);
        }

        /// <summary>
        /// 获得条形码信息
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        public DataTable dtRdCodeScan(string sBarCode)
        {
            string s = ws.dtRdCodeScan(sBarCode);
            if (s.Length > 0)
            {
                DataTable dt = Cls序列化.DeserializeDataTable(s);
                return dt;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得条形码是否使用过信息
        /// </summary>
        /// <returns></returns>
        public int iBarCodeUsed(string sBarCode, string sType)
        {
            int iCou = 0;
            try
            {
                iCou = ws.iBarCodeUsed(sBarCode, sType);
            }
            catch (Exception ee)
            {

            }
            return iCou;
        }

        /// <summary>
        /// 作废条形码
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        public string sBarCodeInvalid(DataTable dt)
        {
            return ws.sBarCodeInvalid(dt);
        }

        /// <summary>
        /// 条形码数量调整
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        public string sSaveBarCodeAdjust(string sBarCode, decimal dQty, decimal dQtyUse, string CreateUid)
        {
            return ws.sSaveBarCodeAdjust(sBarCode, dQty, dQtyUse, CreateUid);
        }


        /// <summary>
        /// 获得采购入库单信息
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        public DataTable dtRdrecord01(string sCode)
        {
            string s = ws.sRdrecord01(sCode);
            if (s.Length > 0)
            {
                DataTable dt = Cls序列化.DeserializeDataTable(s);
                return dt;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 保存采购入库单扫描数量
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        public string sSaveRdrecord01ChkQty(string sCode, DataTable dt, string sUid)
        {
            return ws.sSaveRdrecord01ChkQty(sCode, dt, sUid);
        }


        /// <summary>
        /// 计算条形码可用量
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        public decimal dBarCodeQty(string sBarCode)
        {
            return ws.dBarCodeQty(sBarCode);
        }


        /// <summary>
        /// 获得材料出库单信息
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        public DataTable dtRdrecord11(string sCode)
        {
            string s = ws.sRdrecord11(sCode);
            if (s.Length > 0)
            {
                DataTable dt = Cls序列化.DeserializeDataTable(s);
                return dt;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 获得其他出库单信息
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        public DataTable dtRdrecord09(string sCode)
        {
            string s = ws.sRdrecord09(sCode);
            if (s.Length > 0)
            {
                DataTable dt = Cls序列化.DeserializeDataTable(s);
                return dt;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得其他入库单信息
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        public DataTable dtRdrecord08(string sCode)
        {
            string s = ws.sRdrecord08(sCode);
            if (s.Length > 0)
            {
                DataTable dt = Cls序列化.DeserializeDataTable(s);
                return dt;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 保存材料出库单扫描数量
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        public string sSaveRdrecord11ChkQty(string sCode, DataTable dt, string sUid)
        {
            return ws.sSaveRdrecord11ChkQty(sCode, dt, sUid);
        }




        /// <summary>
        /// 保存其他入库单扫描数量
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        public string sSaveRdrecord08ChkQty(string sCode, DataTable dt, string sUid)
        {
            return ws.sSaveRdrecord08ChkQty(sCode, dt, sUid);
        }

        /// <summary>
        /// 保存其他出库单扫描数量
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        public string sSaveRdrecord09ChkQty(string sCode, DataTable dt, string sUid)
        {
            return ws.sSaveRdrecord09ChkQty(sCode, dt, sUid);
        }


        /// <summary>
        /// 获得调拨单信息
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        public DataTable dtTransVouchs(string sCode)
        {
            string s = ws.sTransVouch(sCode);
            if (s.Length > 0)
            {
                DataTable dt = Cls序列化.DeserializeDataTable(s);
                return dt;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 保存调拨单扫描数量
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        public string sSaveTransVouchsChkQty(string sCode, DataTable dt,string sUid)
        {
            return ws.sSaveTransVouchChkQty(sCode, dt, sUid);
        }


        /// <summary>
        /// 获得盘点单信息
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        public DataTable dtCheckVouch(string sCode)
        {
            string s = ws.sCheckVouch(sCode);
            if (s.Length > 0)
            {
                DataTable dt = Cls序列化.DeserializeDataTable(s);
                return dt;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 保存盘点单扫描数量
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        public string sSaveCheckVouchChkQty(string sCode, DataTable dt)
        {
            return ws.sSaveCheckVouchChkQty(sCode, dt);
        }


        /// <summary>
        /// 装箱
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        public string sSaveBox(string sCode, DataTable dt)
        {
            return ws.sSaveBox(sCode, dt);
        }



        /// <summary>
        /// 拆箱
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        public string sSaveUnBox(string sCode)
        {
            return ws.sSaveUnBox(sCode);
        }


        /// <summary>
        /// 获得箱码对应条形码信息
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        public DataTable dtSBoxBarCode(string sCode)
        {
            string s = ws.dtSBoxBarCode(sCode);
            if (s.Length > 0)
            {
                DataTable dt = Cls序列化.DeserializeDataTable(s);
                return dt;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 获得箱码对应存货信息
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        public DataTable dtSBoxInvCode(string sCode)
        {
            string s = ws.dtSBoxInvCode(sCode);
            if (s.Length > 0)
            {
                DataTable dt = Cls序列化.DeserializeDataTable(s);
                return dt;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得产成品入库单信息
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        public DataTable dtRdrecord10(string sCode)
        {
            string s = ws.sRdrecord10(sCode);
            if (s.Length > 0)
            {
                DataTable dt = Cls序列化.DeserializeDataTable(s);
                return dt;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 保存产成品入库单扫描数量
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        public string sSaveRdrecord10ChkQty(string sCode, DataTable dt, string sUid)
        {
            return ws.sSaveRdrecord10ChkQty(sCode, dt, sUid);
        }


        /// <summary>
        /// 获得发货库单信息
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        public DataTable dtDispatchList(string sCode)
        {
            string s = ws.sDispatchList(sCode);
            if (s.Length > 0)
            {
                DataTable dt = Cls序列化.DeserializeDataTable(s);
                return dt;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 保存发货库单扫描数量
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        public string sSaveDispatchListChkQty(string sCode, DataTable dt,string sUid)
        {
            return ws.sSaveDispatchListChkQty(sCode, dt, sUid);
        }



        /// <summary>
        /// 获得委外订单信息
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        public DataTable dtOMRdrecord01(string sCode, string sInvCode)
        {
            string s = ws.sOMRdrecord01(sCode, sInvCode);
            if (s.Length > 0)
            {
                DataTable dt = Cls序列化.DeserializeDataTable(s);
                return dt;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 标签调整后打印标签
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        public string PrintBarCodeAdjust(string sBarCode)
        {
            return ws.PrintBarCodeAdjust(sBarCode, TH.Smart.BaseClass.ClsBaseDataInfo.sPrintName);
        }

        /// <summary>
        /// 打印标签
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        public string PrintBarCodeQTY(string sBarCode, decimal dQty)
        {
            return ws.PrintBarCodeQTY(sBarCode, dQty, TH.Smart.BaseClass.ClsBaseDataInfo.sPrintName);
        }

        /// <summary>
        /// 打印第二张标签（相同条码，可用量 - 第一张标签数量）
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <param name="dQty"></param>
        /// <returns></returns>
        public string PrintBarCodeQTYSecond(string sBarCode, decimal dQty)
        {
            return ws.PrintBarCodeQTYSecond(sBarCode, dQty, TH.Smart.BaseClass.ClsBaseDataInfo.sPrintName);
        }
    }
}
