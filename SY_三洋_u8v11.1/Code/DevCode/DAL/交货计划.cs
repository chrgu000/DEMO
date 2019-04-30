using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using FrameBaseFunction;
using System.Collections;

namespace TH.DAL
{
     

    /// <summary>
    /// 数据访问类:交货计划
    /// </summary>
    public partial class 交货计划
    {
        /// <summary>
        /// 获得销售订单列表
        /// </summary>
        /// <param name="sWhere"></param>
        /// <returns></returns>
        public DataTable GetSoList(List<string> sWhere)
        {
            string sSQL = @"
select cast(0 as bit) as choose,a.cSoCode,CONVERT(varchar(100), a.dDate,111) AS dDate,a.cCusCode,c.cCusName,c.cCusAbbName ,b.iRowNo ,b.cInvCode,d.cInvName,d.cInvStd
	,cast(b.iQuantity as decimal(16,2)) as iQuantity,CONVERT(varchar(100),b.dPreDate,111) as dPreDate ,b.cMemo ,b.Autoid,b.iSOsID, e.cbdefine1 
    ,case when isnull(e.cbdefine2,'') = '' then CONVERT(varchar(100),b.dPreDate,111) else CONVERT(varchar(100),e.cbdefine2,111)  end as cbdefine2
    ,cast(g.完工数量 as decimal(16,2)) as 完工数量
from @u8.so_somain a inner join @u8.so_sodetails b on a.ID  = b.id
	left join @u8.Customer c on c.cCusCode = a.cCusCode
	left join @u8.Inventory d on d.cInvCode = b.cInvCode
    left join @u8.SO_SODetails_ExtraDefine e on e.iSOsID = b.iSOsID
	left join (select distinct 销售订单号,销售订单行号,关闭人 from [生产计划]) f on f.销售订单号 = a.cSoCode and f.销售订单行号 = b.iRowNo
    left join (
                    select a.评审单据号,a.销售订单号,a.销售订单行号,a.存货编码,a.数量
                        ,sum(c.完工数量) as 完工数量
                    from dbo.生产计划 a 
	                    inner join dbo.生产日计划 b on a.GUID = b.来源GUID
                        left join 生产日计划完工登记 c on c.生产日计划iID = b.iID
                    group by a.评审单据号,a.销售订单号,a.销售订单行号,a.存货编码,a.数量
               ) g on g.销售订单号 = a.cSoCode and g.销售订单行号 = b.iRowNo and b.cInvCode = g.存货编码
where 1=1
order by b.dPreDate,a.cSoCode,b.iRowNo
";
            for (int i = 0; i < sWhere.Count; i++)
            {
                string[] s = sWhere[i].Split('●');
                sSQL = sSQL.Replace(s[0],s[1]);
            }
            return DbHelperSQL.Query(sSQL);
        }

        public DataTable Get产品大类()
        {
            string sSQL = @"
select distinct cinvdefine4 as 产品大类 from @u8.Inventory order by cinvdefine4 
            ";
            return DbHelperSQL.Query(sSQL);
        }

        /// <summary>
        /// 获得年月
        /// </summary>
        /// <returns></returns>
        public DataTable GetYearMonth()
        {
            string sSQL = @"
            select distinct cast(year(dPreDate) as varchar(4))+ '-' + right('00' + cast(month(dPreDate) as varchar(2)),2) as sYearMonth
from @u8.so_sodetails
order by cast(year(dPreDate) as varchar(4))+ '-' + right('00' + cast(month(dPreDate) as varchar(2)),2)
            ";
            return DbHelperSQL.Query(sSQL);
        }

        /// <summary>
        /// 标记期初
        /// </summary>
        /// <param name="dtDetails"></param>
        /// <returns></returns>
        public int SaveQC(DataTable dtDetails)
        {
            int iCou = 0;
            SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                for (int i = 0; i < dtDetails.Rows.Count; i++)
                {

                    bool b = BaseFunction.BaseFunction.ReturnBool(dtDetails.Rows[i]["choose"]);
                    if (!b)
                        continue;

                    string sSQL = @"
if exists (select 1 from @u8.SO_SODetails_ExtraDefine Where  isosid= 111111)
    Update @u8.SO_SODetails_ExtraDefine Set cbdefine1 =3,cbdefine2 = '222222' Where  isosid= 111111
else
    Insert Into @u8.SO_SODetails_ExtraDefine(isosid,cbdefine1,cbdefine2) Values (111111,3,'222222')
";
                    sSQL = sSQL.Replace("111111", dtDetails.Rows[i]["iSOsID"].ToString().Trim());
                    sSQL = sSQL.Replace("222222", BaseFunction.BaseFunction.ReturnDate(dtDetails.Rows[i]["cbdefine2"].ToString().Trim()).ToString("yyyy-MM-dd"));
                    iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                }

                tran.Commit();
            }
            catch (Exception error)
            {
                tran.Rollback();
                throw new Exception(error.Message);
            }

            return iCou;
        }

        /// <summary>
        /// 撤销期初
        /// </summary>
        /// <param name="dtDetails"></param>
        /// <returns></returns>
        public int SaveUnQC(DataTable dtDetails)
        {
            int iCou = 0;
            SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                for (int i = 0; i < dtDetails.Rows.Count; i++)
                {

                    bool b = BaseFunction.BaseFunction.ReturnBool(dtDetails.Rows[i]["choose"]);
                    if (!b)
                        continue;

                    string sSQL = @"
if exists (select 1 from @u8.SO_SODetails_ExtraDefine Where  isosid= 111111)
    Update @u8.SO_SODetails_ExtraDefine Set cbdefine1 =0,cbdefine2 = null Where  isosid= 111111
else
    Insert Into @u8.SO_SODetails_ExtraDefine(isosid,cbdefine1) Values (111111,0)
";
                    sSQL = sSQL.Replace("111111", dtDetails.Rows[i]["iSOsID"].ToString().Trim());
                    iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }

                tran.Commit();
            }
            catch (Exception error)
            {
                tran.Rollback();
                throw new Exception(error.Message);
            }

            return iCou;
        }

        /// <summary>
        /// 标记排产
        /// </summary>
        /// <param name="dtDetails"></param>
        /// <returns></returns>
        public int SavePC(DataTable dtDetails)
        {
            int iCou = 0;
            SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                for (int i = 0; i < dtDetails.Rows.Count; i++)
                {

                    bool b = BaseFunction.BaseFunction.ReturnBool(dtDetails.Rows[i]["choose"]);
                    if (!b)
                        continue;

                    string sSQL = @"
if exists (select 1 from @u8.SO_SODetails_ExtraDefine Where  isosid= 111111)
    Update @u8.SO_SODetails_ExtraDefine Set cbdefine1 =1,cbdefine2 = '222222' Where  isosid= 111111
else
    Insert Into @u8.SO_SODetails_ExtraDefine(isosid,cbdefine1,cbdefine2) Values (111111,1,'222222')
";
                    sSQL = sSQL.Replace("111111", dtDetails.Rows[i]["iSOsID"].ToString().Trim());
                    sSQL = sSQL.Replace("222222", BaseFunction.BaseFunction.ReturnDate( dtDetails.Rows[i]["cbdefine2"].ToString().Trim()).ToString("yyyy-MM-dd"));
                    iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                }

                tran.Commit();
            }
            catch (Exception error)
            {
                tran.Rollback();
                throw new Exception(error.Message);
            }

            return iCou;
        }

        /// <summary>
        /// 撤销排产
        /// </summary>
        /// <param name="dtDetails"></param>
        /// <returns></returns>
        public int SaveUNPC(DataTable dtDetails)
        {
            string sErr = "";
            int iCou = 0;
            SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                for (int i = 0; i < dtDetails.Rows.Count; i++)
                {

                    bool b = BaseFunction.BaseFunction.ReturnBool(dtDetails.Rows[i]["choose"]);
                    if (!b)
                        continue;

                    string sSQL = "select * from dbo.订单评审 where 销售订单号 = '" + dtDetails.Rows[i]["cSoCode"].ToString().Trim() + "' and 行号 = '" + dtDetails.Rows[i]["iRowNo"].ToString().Trim() + "'";
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        sErr = sErr + "销售订单 " + dtDetails.Rows[i]["cSoCode"].ToString().Trim() + " 第" + dtDetails.Rows[i]["iRowNo"].ToString().Trim() + "行已经评审\n ";
                        continue;
                    }

                    sSQL = @"
if exists (select 1 from @u8.SO_SODetails_ExtraDefine Where  isosid= 111111)
    Update @u8.SO_SODetails_ExtraDefine Set cbdefine1 = 0 Where  isosid= 111111
else
    Insert Into @u8.SO_SODetails_ExtraDefine(isosid,cbdefine1) Values (111111,0)
";
                    sSQL = sSQL.Replace("111111", dtDetails.Rows[i]["iSOsID"].ToString().Trim());
                    iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                }

                if (sErr.Length > 0)
                {
                    throw new Exception(sErr);
                }

                tran.Commit();
            }
            catch (Exception error)
            {
                tran.Rollback();
                throw new Exception(error.Message);
            }

            return iCou;
        }

        /// <summary>
        /// 关闭排产
        /// </summary>
        /// <param name="dtDetails"></param>
        /// <returns></returns>
        public int SaveClosePC(DataTable dtDetails)
        {
            int iCou = 0;
            SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                for (int i = 0; i < dtDetails.Rows.Count; i++)
                {

                    bool b = BaseFunction.BaseFunction.ReturnBool(dtDetails.Rows[i]["choose"]);
                    if (!b)
                        continue;

                    string sSQL = @"
if exists (select 1 from @u8.SO_SODetails_ExtraDefine Where  isosid= 111111)
    Update @u8.SO_SODetails_ExtraDefine Set cbdefine1 = 2,cbdefine2 = null Where  isosid= 111111
else
    Insert Into @u8.SO_SODetails_ExtraDefine(isosid,cbdefine1,cbdefine2) Values (111111,2,null)
";
                    sSQL = sSQL.Replace("111111", dtDetails.Rows[i]["iSOsID"].ToString().Trim());
                    iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                }

                tran.Commit();
            }
            catch (Exception error)
            {
                tran.Rollback();
                throw new Exception(error.Message);
            }

            return iCou;
        }



        public DateTime Get服务器日期()
        {
            string sSQL = @"
select getdate()
            ";
            DataTable dt = DbHelperSQL.Query(sSQL);
            return Convert.ToDateTime(dt.Rows[0][0]);
        }
    }
}

