using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using ClsBaseClass;

namespace ClsU8
{
    public class Cls生产订单
    {
      
        public string dt生产订单信息(string sCode,string sRowNo)
        {
            string s = "";

            try
            {
                string sSQL = "select * from mom_order a inner join mom_orderdetail b on a.moid = b.moid where a.mocode = '" + sCode.Trim() + "' and b.SortSeq = '" + sRowNo + "' ";
                DataTable dt = SqlHelper.ExecuteDataset(ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).Tables[0];
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string dt生产订单信息(string sDid)
        {
            string s = "";

            try
            {
                string sSQL = "select a.MoCode,b.SortSeq from mom_order a inner join mom_orderdetail b on a.moid = b.moid where b.MoDid = " + sDid.ToString() + "  and b.Status = 3";
                DataTable dt = SqlHelper.ExecuteDataset(ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).Tables[0];
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }


        public string dt生产订单子件信息(string sCode, string sRowNo,string sInvCode)
        {
            string s = "";

            try
            {
                string sSQL = "select * from mom_order a inner join mom_orderdetail b on a.moid = b.moid inner join mom_moallocate c on c.MoDId  = b.Modid where a.mocode = '" + sCode.Trim() + "' and b.SortSeq = '" + sRowNo + "' and c.InvCode = '" + sInvCode + "'";
                DataTable dt = SqlHelper.ExecuteDataset(ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).Tables[0];
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }
    }
}
