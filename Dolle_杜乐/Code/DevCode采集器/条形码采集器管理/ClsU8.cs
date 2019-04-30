using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace BarCode
{
    public class ClsU8
    {
        MobileBaseDLL.ClsDES clsDES = MobileBaseDLL.ClsDES.Instance();
        MobileBaseDLL.ClsSQLServerCommond clsSQLCommond = new MobileBaseDLL.ClsSQLServerCommond();

     
        public string Get货位现存量(string cInvCode,string s货位 ,out decimal dQty,out decimal dNum)
        {
            DataTable dt;
            string sErr = "";
            dQty = 0;
            dNum = 0;
            try
            {
                string sSQL = "SELECT CS.cWhCode as 仓库编码,W.cWhName as 仓库, CS.cPosCode AS 货位编码, p.cPosName AS 货位, CS.cInvCode as 存货编码,i.cInvName as 存货名称 " +
                            "	, sum(case when bRdFlag = 0 then -1 * CS.iQuantity else CS.iQuantity end) as 现存数量 " +
                            "	, sum(case when bRdFlag = 0 then -1 * CS.iNum else CS.iNum end) as 现存件数 " +
                            " FROM @u8.Warehouse W with (nolock) RIGHT OUTER JOIN @u8.InvPosition CS  with (nolock) ON W.cWhCode = CS.cWhCode  " +
                            "	  LEFT OUTER JOIN @u8.Inventory I ON CS.cInvCode = I.cInvCode  " +
                            "	  LEFT JOIN @u8.Position p ON CS.cPosCode=p.cPosCode  " +
                             "WHERE I.cInvCode = N'" + cInvCode + "' and  CS.cPosCode = '" + s货位 + "' " +
                             "group by CS.cWhCode,W.cWhName, CS.cPosCode, p.cPosName, CS.cInvCode,i.cInvName";
                dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count < 1)
                {
                    sErr = "货位物料数量为0";
                }
                else
                {
                    dQty = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt.Rows[0]["现存数量"]);
                    dNum = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt.Rows[0]["现存件数"]);
                }
            }
            catch (Exception ee)
            {
                sErr = ee.Message;
            }
            return sErr;
        }

        /// <summary>
        /// 检查货位是否存在
        /// </summary>
        /// <param name="sWhCode"></param>
        /// <returns></returns>
        private int Chk货位管理(string sWhCode)
        {
            int i = -1;
            try
            {
                string sSQL = "select isnull(bWhPos,0) as bWhPos from @u8.Warehouse where cWhCode = '" + sWhCode + "'";
                i = MobileBaseDLL.ClsBaseDataInfo.ReturnBoolToInt(clsSQLCommond.ExecGetScalar(sSQL));
            }
            catch { }
            return i;
        }

        /// <summary>
        /// 检查物料，货位是否匹配
        /// </summary>
        /// <param name="s货位"></param>
        /// <param name="s物料"></param>
        /// <returns></returns>
        public int Chk货位物料(string s货位, string s物料)
        {
            int i = -1;
            try
            {
                string sSQL = "select distinct a.cPosition as 货位编码,b.cPosName as 货位,c.cWhCode as 仓库编码,c.cWhName as 仓库 from @u8.Inventory a inner join @u8.Position b on a.cPosition = b.cPosCode inner join @u8.Warehouse c on c.cWhCode = b.cWhCode " +
                              "where a.cinvcode = '" + s物料 + "' and b.cPosCode = '" + s货位 + "' ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                if (dt != null && dt.Rows.Count > 0)
                    i = dt.Rows.Count;
            }
            catch
            { }
            return i;
        }

        /// <summary>
        /// 检查货位是否存在，并返回仓库信息
        /// </summary>
        /// <param name="s货位"></param>
        /// <returns></returns>
        public DataTable Chk货位(string s货位)
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "货位编号";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "货位";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "仓库编码";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "仓库";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "返回信息";
            dt.Columns.Add(dc);

            try
            {
                string sSQL = "select a.cPosCode as 货位编码,a.cPosName as 货位,b.cWhCode as 仓库编码,b.cWhName as 仓库,cast(null as varchar(50)) as  返回信息 " +
                                "from @u8.Position a left join @u8.Warehouse  b on a.cWhCode = b.cWhCode " +
                                "where a.cPosCode = '" + s货位 + "' " +
                                "order by a.cWhCode,a.cPosCode";
                dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count < 1)
                {
                    throw new Exception("该货位不存在");
                }
            }
            catch
            {
                DataRow dr = dt.NewRow();
                dr["返回信息"] = "检查货位信息失败";
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public DataTable Get默认仓库(string sInvCode)
        {
            DataTable dt = null;
            try
            {
                string sSQL = "select a.cDefWareHouse as 仓库编码,b.cWhName as 仓库,isnull(b.bWhPos,0) as 是否货位管理 from @u8.Inventory a left join @u8.Warehouse b on a.cDefWareHouse = b.cWhCode where a.cInvCode = '" + sInvCode + "'";
                dt = clsSQLCommond.ExecQuery(sSQL);
            }
            catch { }
            return dt;

        }

        public DataTable Get默认货位(string sInvCode)
        {
            DataTable dt = null;
            try
            {
                string sSQL = "select cPosition,cDefWareHouse from @u8.Inventory where cInvCode = '" + sInvCode + "'";
                dt = clsSQLCommond.ExecQuery(sSQL);
            }
            catch { }
            return dt;

        }

        ///// <summary>
        ///// 获得默认入库货位
        ///// </summary>
        ///// <param name="sInvCode"></param>
        ///// <returns></returns>
        //public DataTable Get默认入库货位(string sInvCode)
        //{
        //    DataTable dt = new DataTable();
        //    DataColumn dc = new DataColumn();
        //    dc.ColumnName = "货位编号";
        //    dt.Columns.Add(dc);

        //    dc = new DataColumn();
        //    dc.ColumnName = "货位";
        //    dt.Columns.Add(dc);

        //    dc = new DataColumn();
        //    dc.ColumnName = "仓库编码";
        //    dt.Columns.Add(dc);

        //    dc = new DataColumn();
        //    dc.ColumnName = "仓库";
        //    dt.Columns.Add(dc);

        //    dc = new DataColumn();
        //    dc.ColumnName = "返回信息";
        //    dt.Columns.Add(dc);

        //    try
        //    {
        //        string sSQL = "select a.入库货位 as 货位编码,b.cPosName as 货位,c.cWhCode as 仓库编码,c.cWhName as 仓库,cast(null as varchar(50)) as  返回信息 " +
        //                        "from dbo.物料货位对照 a left join @u8.Position b on a.入库货位 = b.cPosCode " +
        //                        "	left join @u8.Warehouse c on c.cWhCode = b.cWhCode " +
        //                        "where 物料编码 = '" + sInvCode + "' " +
        //                        "order by iID";
        //        dt = clsSQLCommond.ExecQuery(sSQL);
        //        if (dt == null || dt.Rows.Count < 1)
        //        {
        //            throw new Exception("该物料未设置货位");
        //        }
        //    }
        //    catch (Exception ee)
        //    {
        //        DataRow dr = dt.NewRow();
        //        dr["返回信息"] = ee.Message;
        //        dt.Rows.Add(dr);
        //    }
        //    return dt;
        //}
    }
}
