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

        /// <summary>
        /// 权限判断
        /// </summary>
        /// <param name="sUid"></param>
        /// <param name="sPwd"></param>
        /// <returns></returns>
        [WebMethod]
        public string sCheckRight(string sFormID, string sUserid)
        {
            string sReturn = "";
            try
            {
                string sSQL = "SELECT UserID,FormID FROM [_UserRight] where UserID = '" + sUserid + "' and FormID = '" + sFormID + "'";
                DataTable dt = DbHelperSQL.Query(sSQL);

                if (dt != null && dt.Rows.Count > 0)
                {
                    sReturn = "1";
                }
                else
                {
                    sReturn = "0";
                }

            }
            catch (Exception ee)
            {
                sReturn = "0";
            }
            return sReturn;
        }

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
        /// 根据条形码中对应生产订单信息获得对应产成品入库单单据号
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string dtRdCodeScan(string sBarCode)
        {
            string sReturn = "";
            try
            {
                TH.WebService.DAL.RdRecord10 DAL = new TH.WebService.DAL.RdRecord10();
                DataTable dt = DAL.dtRdCodeScan(sBarCode);

                if (dt != null && dt.Rows.Count >0)
                {
                    sReturn = Cls序列化.SerializeDataTableXml(dt);
                }

            }
            catch (Exception ee)
            {

            }
            return sReturn;
        }

        /// <summary>
        /// 获得条形码信息
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string dtScanBarCode(string sBarCode)
        {
            string sReturn = "";
            try
            {
                TH.WebService.DAL._BarCodeList DAL = new TH.WebService.DAL._BarCodeList();
                DataTable dt = DAL.dtScanBarCode(sBarCode);

                if (dt != null && dt.Rows.Count >0)
                {
                    sReturn = Cls序列化.SerializeDataTableXml(dt);
                }

            }
            catch (Exception ee)
            {

            }
            return sReturn;
        }

        /// <summary>
        /// 判断条形码是否已经使用过（多次保存单据，判断记录表里是否已经有该条码）
        /// </summary>
        /// <param name="sType"></param>
        /// <param name="ExsID"></param>
        /// <param name="BarCode"></param>
        /// <param name="RDType"></param>
        /// <returns></returns>
        [WebMethod]
        public int iChkBarCodeUsed(string sType, string sCode, string BarCode, int RDType)
        {
            TH.WebService.DAL._BarCodeList DAL = new TH.WebService.DAL._BarCodeList();
            int iCou = DAL.iChkBarCodeUsed(sType, sCode, BarCode, RDType);
            return iCou;
        }

        /// <summary>
        /// 获得条形码是否使用过信息
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        [WebMethod]
        public int iBarCodeUsed(string sBarCode, string sType)
        {
            int iCou = 0;
            try
            {
                TH.WebService.DAL._BarCodeList DAL = new TH.WebService.DAL._BarCodeList();
                iCou = DAL.iBarCodeUsed(sBarCode, sType);
            }
            catch (Exception ee)
            {

            }
            return iCou;
        }

        /// <summary>
        /// 条形码可用量计算
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        [WebMethod]
        public decimal dBarCodeQty(string sBarCode)
        {
            decimal d = 0;
            try
            {
                TH.WebService.DAL._BarCodeList DAL = new TH.WebService.DAL._BarCodeList();
                d = DAL.dBarCodeQty(sBarCode);
            }
            catch (Exception ee)
            {

            }
            return d;
        }

        /// <summary>
        /// 作废条形码
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string sBarCodeInvalid(DataTable  dt)
        {
            string sReturn = "";
            try
            {
                TH.WebService.DAL._BarCodeList DAL = new TH.WebService.DAL._BarCodeList();

                if (dt == null || dt.Rows.Count == 0)
                {
                    sReturn = "获得条形码列表失败";
                }
                else
                {
                    int iCou = DAL.iBarCodeInvalid(dt);

                    sReturn = "成功作废条形码：" + iCou.ToString() + "条";
                }
            }
            catch (Exception ee)
            {
                sReturn = ee.Message;
            }
            return sReturn;
        }

        /// <summary>
        /// 获得采购入库单数据列表
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string sRdrecord01(string sCode)
        {
            string sReturn = "";
            try
            {
                TH.WebService.DAL.RdRecord01 DAL = new TH.WebService.DAL.RdRecord01();
                DataTable dt = DAL.GetRdrecord01(sCode);

                if (dt != null && dt.Rows.Count > 0)
                {
                    sReturn = Cls序列化.SerializeDataTableXml(dt);
                }

            }
            catch (Exception ee)
            {

            }
            return sReturn;
        }


        /// <summary>
        /// 保存采购入库单扫描数量
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string sSaveRdrecord01ChkQty(string sCode, DataTable dtBarCode, string sUid)
        {
            string sReturn = "";
            try
            {
                TH.WebService.DAL.RdRecord01 DAL = new TH.WebService.DAL.RdRecord01();

                if (dtBarCode == null || dtBarCode.Rows.Count == 0)
                {
                    sReturn = "获得条形码列表失败";
                }
                else
                {
                    int iCou = DAL.iSaveRdrecord01ChkQty(sCode, dtBarCode,sUid);

                    sReturn = "成功保存条形码：" + dtBarCode.Rows.Count.ToString() + "条";
                }
            }
            catch (Exception ee)
            {
                sReturn = ee.Message;
            }
            return sReturn;
        }

        /// <summary>
        /// 获得其他出库单数据列表
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string sRdrecord09(string sCode)
        {
            string sReturn = "";
            try
            {
                TH.WebService.DAL.RdRecord09 DAL = new TH.WebService.DAL.RdRecord09();
                DataTable dt = DAL.GetRdrecord09(sCode);

                if (dt != null && dt.Rows.Count > 0)
                {
                    sReturn = Cls序列化.SerializeDataTableXml(dt);
                }

            }
            catch (Exception ee)
            {

            }
            return sReturn;
        }

        /// <summary>
        /// 保存其他出库单扫描数量
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string sSaveRdrecord09ChkQty(string sCode, DataTable dtBarCode, string sUid)
        {
            string sReturn = "";
            try
            {
                TH.WebService.DAL.RdRecord09 DAL = new TH.WebService.DAL.RdRecord09();

                if (dtBarCode == null || dtBarCode.Rows.Count == 0)
                {
                    sReturn = "获得条形码列表失败";
                }
                else
                {
                    int iCou = DAL.iSaveRdrecord09ChkQty(sCode, dtBarCode, sUid);

                    sReturn = "成功保存条形码：" + dtBarCode.Rows.Count.ToString() + "条";
                }
            }
            catch (Exception ee)
            {
                sReturn = ee.Message;
            }
            return sReturn;
        }

        /// <summary>
        /// 获得其他入库单数据列表
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string sRdrecord08(string sCode)
        {
            string sReturn = "";
            try
            {
                TH.WebService.DAL.RdRecord08 DAL = new TH.WebService.DAL.RdRecord08();
                DataTable dt = DAL.GetRdrecord08(sCode);

                if (dt != null && dt.Rows.Count > 0)
                {
                    sReturn = Cls序列化.SerializeDataTableXml(dt);
                }

            }
            catch (Exception ee)
            {

            }
            return sReturn;
        }

        /// <summary>
        /// 保存其他入库单扫描数量
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string sSaveRdrecord08ChkQty(string sCode, DataTable dtBarCode,string sUid)
        {
            string sReturn = "";
            try
            {
                TH.WebService.DAL.RdRecord08 DAL = new TH.WebService.DAL.RdRecord08();

                if (dtBarCode == null || dtBarCode.Rows.Count == 0)
                {
                    sReturn = "获得条形码列表失败";
                }
                else
                {
                    int iCou = DAL.iSaveRdrecord08ChkQty(sCode, dtBarCode, sUid);

                    sReturn = "成功保存条形码：" + dtBarCode.Rows.Count.ToString() + "条";
                }
            }
            catch (Exception ee)
            {
                sReturn = ee.Message;
            }
            return sReturn;
        }

        /// <summary>
        /// 获得材料出库单数据列表
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string sRdrecord11(string sCode)
        {
            string sReturn = "";
            try
            {
                TH.WebService.DAL.RdRecord11 DAL = new TH.WebService.DAL.RdRecord11();
                DataTable dt = DAL.GetRdrecord11(sCode);

                if (dt != null && dt.Rows.Count > 0)
                {
                    sReturn = Cls序列化.SerializeDataTableXml(dt);
                }

            }
            catch (Exception ee)
            {

            }
            return sReturn;
        }


        /// <summary>
        /// 保存材料出库单扫描数量
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string sSaveRdrecord11ChkQty(string sCode, DataTable dtBarCode, string sUid)
        {
            string sReturn = "";
            try
            {
                TH.WebService.DAL.RdRecord11 DAL = new TH.WebService.DAL.RdRecord11();

                if (dtBarCode == null || dtBarCode.Rows.Count == 0)
                {
                    sReturn = "获得条形码列表失败";
                }
                else
                {
                    int iCou = DAL.iSaveRdrecord11ChkQty(sCode, dtBarCode, sUid);

                    sReturn = "成功保存条形码：" + dtBarCode.Rows.Count.ToString() + "条";
                }
            }
            catch (Exception ee)
            {
                sReturn = ee.Message;
            }
            return sReturn;
        }


        /// <summary>
        /// 获得调拨单数据列表
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string sTransVouch(string sCode)
        {
            string sReturn = "";
            try
            {
                TH.WebService.DAL.TransVouch DAL = new TH.WebService.DAL.TransVouch();
                DataTable dt = DAL.GetTransVouch(sCode);

                if (dt != null && dt.Rows.Count > 0)
                {
                    sReturn = Cls序列化.SerializeDataTableXml(dt);
                }

            }
            catch (Exception ee)
            {

            }
            return sReturn;
        }


        /// <summary>
        /// 保存调拨单扫描数量
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string sSaveTransVouchChkQty(string sCode, DataTable dtBarCode,string sUid)
        {
            string sReturn = "";
            try
            {
                TH.WebService.DAL.TransVouch DAL = new TH.WebService.DAL.TransVouch();

                if (dtBarCode == null || dtBarCode.Rows.Count == 0)
                {
                    sReturn = "获得条形码列表失败";
                }
                else
                {
                    int iCou = DAL.iSaveGetTransVouchChkQty(sCode, dtBarCode, sUid);

                    sReturn = "成功保存条形码：" + dtBarCode.Rows.Count.ToString() + "条";
                }
            }
            catch (Exception ee)
            {
                sReturn = ee.Message;
            }
            return sReturn;
        }

        /// <summary>
        /// 获得盘点单数据列表
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string sCheckVouch(string sCode)
        {
            string sReturn = "";
            try
            {
                TH.WebService.DAL.CheckVouch DAL = new TH.WebService.DAL.CheckVouch();
                DataTable dt = DAL.GetCheckVouch(sCode);

                if (dt != null && dt.Rows.Count > 0)
                {
                    sReturn = Cls序列化.SerializeDataTableXml(dt);
                }

            }
            catch (Exception ee)
            {

            }
            return sReturn;
        }


        /// <summary>
        /// 保存盘点单扫描数量
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string sSaveCheckVouchChkQty(string sCode, DataTable dtBarCode)
        {
            string sReturn = "";
            try
            {
                TH.WebService.DAL.CheckVouch DAL = new TH.WebService.DAL.CheckVouch();

                if (dtBarCode == null || dtBarCode.Rows.Count == 0)
                {
                    sReturn = "获得条形码列表失败";
                }
                else
                {
                    int iCou = DAL.iSaveGetCheckVouchChkQty(sCode, dtBarCode);

                    sReturn = "成功保存条形码：" + dtBarCode.Rows.Count.ToString() + "条";
                }
            }
            catch (Exception ee)
            {
                sReturn = ee.Message;
            }
            return sReturn;
        }

        /// <summary>
        ///装箱
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string sSaveBox(string sCode, DataTable dtBarCode)
        {
            string sReturn = "";
            try
            {
                TH.WebService.DAL._BarCodeList DAL = new TH.WebService.DAL._BarCodeList();

                if (dtBarCode == null || dtBarCode.Rows.Count == 0)
                {
                    sReturn = "获得条形码列表失败";
                }
                else
                {
                    int iCou = DAL.iBarCodeBox(sCode, dtBarCode);

                    sReturn = "装箱成功：" + dtBarCode.Rows.Count.ToString() + "条";
                }
            }
            catch (Exception ee)
            {
                sReturn = ee.Message;
            }
            return sReturn;
        }


        /// <summary>
        ///拆箱
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string sSaveUnBox(string sCode)
        {
            string sReturn = "";
            try
            {
                TH.WebService.DAL._BarCodeList DAL = new TH.WebService.DAL._BarCodeList();

                int iCou = DAL.iBarCodeUnBox(sCode);

                sReturn = "拆箱成功：" + iCou.ToString() + "条";
            }
            catch (Exception ee)
            {
                sReturn = ee.Message;
            }
            return sReturn;
        }


        /// <summary>
        /// 获得箱码对应条形码信息
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string dtSBoxBarCode(string sBarCode)
        {
            string sReturn = "";
            try
            {
                TH.WebService.DAL._BarCodeList DAL = new TH.WebService.DAL._BarCodeList();
                DataTable dt = DAL.dtSBoxBarCode(sBarCode);

                if (dt != null && dt.Rows.Count > 0)
                {
                    sReturn = Cls序列化.SerializeDataTableXml(dt);
                }

            }
            catch (Exception ee)
            {

            }
            return sReturn;
        }

        /// <summary>
        /// 获得箱码对应存货信息
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string dtSBoxInvCode(string sBarCode)
        {
            string sReturn = "";
            try
            {
                TH.WebService.DAL._BarCodeList DAL = new TH.WebService.DAL._BarCodeList();
                DataTable dt = DAL.dtSBoxInvCode(sBarCode);

                if (dt != null && dt.Rows.Count > 0)
                {
                    sReturn = Cls序列化.SerializeDataTableXml(dt);
                }

            }
            catch (Exception ee)
            {

            }
            return sReturn;
        }



        /// <summary>
        /// 获得产成品入库单数据列表
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string sRdrecord10(string sCode)
        {
            string sReturn = "";
            try
            {
                TH.WebService.DAL.RdRecord10 DAL = new TH.WebService.DAL.RdRecord10();
                DataTable dt = DAL.GetRdrecord10(sCode);

                if (dt != null && dt.Rows.Count > 0)
                {
                    sReturn = Cls序列化.SerializeDataTableXml(dt);
                }

            }
            catch (Exception ee)
            {

            }
            return sReturn;
        }


        /// <summary>
        /// 保存产成品入库单扫描数量
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string sSaveRdrecord10ChkQty(string sCode, DataTable dtBarCode, string sUid)
        {
            string sReturn = "";
            try
            {
                TH.WebService.DAL.RdRecord10 DAL = new TH.WebService.DAL.RdRecord10();

                if (dtBarCode == null || dtBarCode.Rows.Count == 0)
                {
                    sReturn = "获得条形码列表失败";
                }
                else
                {
                    int iCou = DAL.iSaveRdrecord10ChkQty(sCode, dtBarCode, sUid);

                    sReturn = "成功保存条形码：" + dtBarCode.Rows.Count.ToString() + "条";
                }
            }
            catch (Exception ee)
            {
                sReturn = ee.Message;
            }
            return sReturn;
        }


        /// <summary>
        /// 获得发货单数据列表
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string sDispatchList(string sCode)
        {
            string sReturn = "";
            try
            {
                TH.WebService.DAL.DispatchList DAL = new TH.WebService.DAL.DispatchList();
                DataTable dt = DAL.GetDispatchList(sCode);

                if (dt != null && dt.Rows.Count > 0)
                {
                    sReturn = Cls序列化.SerializeDataTableXml(dt);
                }

            }
            catch (Exception ee)
            {

            }
            return sReturn;
        }


        /// <summary>
        /// 保存发货单扫描数量
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string sSaveDispatchListChkQty(string sCode, DataTable dtBarCode,string sUid)
        {
            string sReturn = "";
            try
            {
                TH.WebService.DAL.DispatchList DAL = new TH.WebService.DAL.DispatchList();

                if (dtBarCode == null || dtBarCode.Rows.Count == 0)
                {
                    sReturn = "获得条形码列表失败";
                }
                else
                {
                    int iCou = DAL.iSaveDispatchListChkQty(sCode, dtBarCode,sUid);

                    sReturn = "成功保存条形码：" + dtBarCode.Rows.Count.ToString() + "条";
                }
            }
            catch (Exception ee)
            {
                sReturn = ee.Message;
            }
            return sReturn;
        }


        /// <summary>
        /// 获得委外订单数据列表
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string sOMRdrecord01(string sCode,string sInvCode)
        {
            string sReturn = "";
            try
            {
                TH.WebService.DAL.RdRecord01 DAL = new TH.WebService.DAL.RdRecord01();
                DataTable dt = DAL.GetOMRdrecord01(sCode,sInvCode);

                if (dt != null && dt.Rows.Count > 0)
                {
                    sReturn = Cls序列化.SerializeDataTableXml(dt);
                }

            }
            catch (Exception ee)
            {

            }
            return sReturn;
        }



        /// <summary>
        /// 保存调整标签数量
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string sSaveBarCodeAdjust(string sBarCode, decimal dQty, decimal dQtyUse, string CreateUid)
        {
            string sReturn = "";
            try
            {
                TH.WebService.DAL._BarCodeRD DAL = new TH.WebService.DAL._BarCodeRD();


                int iCou = DAL.iSaveBarCodeAdjust(sBarCode, dQty,dQtyUse, CreateUid);

                sReturn = "成功调整条形码：" + sBarCode;
            }
            catch (Exception ee)
            {
                sReturn = ee.Message;
            }
            return sReturn;
        }


        /// <summary>
        /// 标签数量调整后打印标签数量
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string PrintBarCodeAdjust(string sBarCode, string sPrintName)
        {
            string sReturn = "";
            try
            {
                TH.WebService.DAL._BarCodeRD DAL = new TH.WebService.DAL._BarCodeRD();

                sReturn = DAL.PrintBarCodeAdjust(sBarCode, sPrintName);
            }
            catch (Exception ee)
            {
                sReturn = ee.Message;
            }
            return sReturn;
        }



        /// <summary>
        /// 打印标签数量
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string PrintBarCodeQTY(string sBarCode, decimal dQty, string sPrintName)
        {
            string sReturn = "";
            try
            {
                TH.WebService.DAL._BarCodeRD DAL = new TH.WebService.DAL._BarCodeRD();

                sReturn = DAL.PrintBarCodeQTY(sBarCode, dQty, sPrintName);
            }
            catch (Exception ee)
            {
                sReturn = ee.Message;
            }
            return sReturn;
        }


        /// <summary>
        /// 打印标签数量(第二张）
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        [WebMethod]
        public string PrintBarCodeQTYSecond(string sBarCode, decimal dQty, string sPrintName)
        {
            string sReturn = "";
            try
            {
                TH.WebService.DAL._BarCodeRD DAL = new TH.WebService.DAL._BarCodeRD();

                decimal dUseQty = dBarCodeQty(sBarCode);
                if (dUseQty > dQty)
                {
                    sReturn = sReturn + DAL.PrintBarCodeQTY(sBarCode, dUseQty - dQty, sPrintName);
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
