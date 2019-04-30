using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using ClsBaseClass;

namespace ClsU8
{
    public class Cls现品票登记
    {
        public string dtInventory(string cInvCode)
        {
            string s = "";

            try
            {
                string sSQL = sSQL = "select cInvName,cInvDefine1 from @u8.Inventory where cInvCode = '" + cInvCode + "'";
                sSQL = sSQL.Replace("@u8.", ClsBaseDataInfo.sUFDataBaseName + ".dbo.");
                DataTable dt = ClsBaseClass.SqlHelper.ExecuteDataset(ClsBaseClass.ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).Tables[0];
                s = ClsBaseClass.Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {

            }
            return s;
        }

        public string sDoor(string iPF, string iPlace)
        {
            string s = "";
            try
            {
                string sSQL = "select * from Gate where iPF = '" + iPF.Trim() + "' and iPlace ='" + iPlace.Trim().PadLeft(6, '0') + "'";
                DataTable dt = ClsBaseClass.SqlHelper.ExecuteDataset(ClsBaseClass.ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).Tables[0];
                s = ClsBaseClass.Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = "";
            }
            return s;
        }

        public string Save现品票登记(DataTable dtData)
        {
            string s = "";
            string sSQL = "";
            try
            {
                string sErr = "";

                if (dtData == null || dtData.Rows.Count < 1)
                    throw new Exception("没有需要保存的数据");

                SqlConnection conn = new SqlConnection(ClsBaseClass.ClsBaseDataInfo.sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    for (int i = 0; i < dtData.Rows.Count; i++)
                    {
                        string s存货编码 = dtData.Rows[i]["品番"].ToString().Trim();
                        string iSheDate = dtData.Rows[i]["纳入指示日期"].ToString().Trim().Substring(0,4)
                            + "-" + dtData.Rows[i]["纳入指示日期"].ToString().Trim().Substring(4, 2)
                            + "-" + dtData.Rows[i]["纳入指示日期"].ToString().Trim().Substring(6, 2);
                        sSQL = "select * from @u8.Inventory where cInvCode = '" + s存货编码 + "'";
                        sSQL = sSQL.Replace("@u8.", ClsBaseDataInfo.sUFDataBaseName + ".dbo.");
                        DataTable dt存货信息 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt存货信息 == null || dt存货信息.Rows.Count < 1)
                        {
                            sErr = sErr + "存货编码:" + s存货编码 + "获得存货信息失败\n";
                            continue;
                        }

                        //string cInvDefine1 = dt存货信息.Rows[0]["cInvDefine1"].ToString();
                        //if (cInvDefine1 == "")
                        //{
                        //    sErr = sErr + "存货编码:" + s存货编码 + "收容数必须设置,获得存货收容数信息失败\n";
                        //    continue;
                        //}

                        decimal iQty = decimal.Parse(dtData.Rows[i]["送货数量"].ToString());

                        Model.Registers model = new Model.Registers();
                        model.VenCode = dtData.Rows[i]["供应商"].ToString();
                        model.Door = dtData.Rows[i]["门号"].ToString();
                        model.InvCode = s存货编码;
                        model.iHZ = dtData.Rows[i]["箱种"].ToString();
                        model.iSheQty = ClsBaseDataInfo.ReturnObjectToDecimal((dtData.Rows[i]["收容数"]));
                        model.iBoxQty = ClsBaseDataInfo.ReturnObjectToInt((dtData.Rows[i]["箱数"]));
                        model.iQty = iQty;
                        model.OrderNo = dtData.Rows[i]["订单编号"].ToString();
                        model.dDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                        model.iSheDate = DateTime.Parse(iSheDate);
                        model.BarCode = dtData.Rows[i]["条形码"].ToString();
                        model.CreateUid = dtData.Rows[i]["登记人"].ToString();
                        model.CreateDate = DateTime.Now;

                        DAL.Registers dal = new DAL.Registers();
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, dal.Add(model));
                    }

                    if (sErr.Trim().Length > 0)
                    {
                        throw new Exception(sErr);
                    }

                    tran.Commit();
                    s = "生成成功";
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }
    }
}
