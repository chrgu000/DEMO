using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using UFIDA.U8.UAP.CustomApp.MetaData;
using System.Data.SqlClient;
using TH.BaseClass;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.Business
{
    public class InvCheckingBLL
    {
        public static string DataSql = @"
                                        select  cast('' as nvarchar(50)) as 序号 ,
                                                cast('' as nvarchar(50)) as 来源单据,
                                                cast('' as nvarchar(50)) as 单据号码 ,
                                                cast('' as nvarchar(50)) as 单据日期 ,
                                                cast('' as nvarchar(50)) as 制单人 ,
                                                cast('' as nvarchar(50)) as 存货编码 ,
                                                cast('' as nvarchar(50)) as 品名 ,
                                                cast('' as nvarchar(50)) as 规格 ,
                                                cast(0 as decimal(18, 2)) as 单据数量 ,
                                                cast('' as nvarchar(50)) as 仓库编码 ,
                                                cast('' as nvarchar(50)) as 批号 ,
                                                cast('' as nvarchar(50)) as 用料客户 ,
                                                cast('' as nvarchar(50)) as 料头责任人 ,
                                                cast('' as nvarchar(50)) as 变化宽幅 ,
                                                cast('' as nvarchar(50)) as 变化长度 ,
                                                cast('' as nvarchar(50)) as 计量单位 ,
                                                cast('' as nvarchar(50)) as 显示规格 ,
                                                cast('' as nvarchar(50)) as 显示数量,
                                                cast('' as nvarchar(50)) as 读取条形码,
                                                cast(0 as decimal(18, 2)) as 正常数量 ,
                                                cast(0 as decimal(18, 2)) as 不良数量 ,
                                                cast('' as nvarchar(50)) as 备注 ,
                                                cast('' as nvarchar(50)) as 状态 

                                        ";

//        public static string FilterSql = @"
//                                        select  [MakeName] 制单人 ,
//                                                [BillFormCode] 清点单号 ,
//                                                [BillDate] 导入日期 ,
//                                                [CheckerName] 清点人 ,
//                                                [CheckDate] 清点日期 ,
//                                                [CheckWareHouse] 仓库 ,
//                                                [BarCode] 条形码 ,
//                                                [来源单据] ,
//                                                [单据号码] ,
//                                                [序号] as 单据明细ID ,
//                                                [单据日期] ,
//                                                [制单人] ,
//                                                [存货编码] ,
//                                                [品名] ,
//                                                [规格] ,
//                                                [单据数量] ,
//                                                [仓库编码] ,
//                                                [批号] ,
//                                                [用料客户] ,
//                                                [料头责任人] ,
//                                                [变化宽幅] ,
//                                                [变化长度] ,
//                                                [计量单位] ,
//                                                [显示规格] ,
//                                                [显示数量] ,
//                                                [读取条形码] ,
//                                                [正常数量] ,
//                                                [不良数量],
//                                                [备注],
//                                                [状态]
//                                        from    [Addins_WHCheck] C
//                                                left join dbo.Addins_WHCheckDetail D on C.BillId = D.BillId
//                                        where   1=1
//
//                                        ";

        public static string FilterSql = @"
        select  [CheckerName] 清点人 ,
                CheckWareHouseName 清点仓库 ,
                [BarCode] 条形码 ,
                [来源单据] ,
                [单据号码] ,
                [序号] as 单据明细ID ,
                [单据日期] ,
                [制单人] ,
                [存货编码] ,
                [品名] ,
                [规格] ,
                [单据数量] ,
                [仓库编码] ,
                [批号] ,
                [用料客户] ,
                [料头责任人] ,
                [变化宽幅] ,
                [变化长度] ,
                [计量单位] ,
                [显示规格] ,
                [显示数量] ,
                [读取条形码] ,
                [正常数量] ,
                [不良数量] ,
                [备注] ,
                [状态]
        from    dbo.Addins_WHChekResult
        where   1=1
         ";
        internal static DataTable GetDataByBarCodes(List<CheckData> details, string conn, ref string errMsg)
        {
            DataTable dtTemp = SqlHelper.ExecuteDataset(conn, CommandType.Text, DataSql).Tables[0];
            DataTable dtResult = dtTemp.Clone();
            List<string> errmsgs = new List<string>();
            foreach (CheckData item in details)
            {


                string detailId = item.BarCode;

                string sql = "select * from dbo.Addins_WHLabel where DetailId ='{0}'";
                sql = string.Format(sql, detailId);
                DataTable dtBar = SqlHelper.ExecuteDataset(conn, CommandType.Text, sql).Tables[0];
                if (dtBar.Rows.Count == 0)
                {
                    errmsgs.Add("无法根据条码:" + item.BarCode + " 找到标签原始信息");
                    continue;
                }

                string sourceDetailId = dtBar.Rows[0]["SourceDetailId"].ToString();
                DataTable dtSource = null;

                string codeType = dtBar.Rows[0]["LabelType"].ToString();
                if (codeType == "到货标签") //来源于到货标签
                {
                    string filter = " and PU_ArrivalVouchs.Autoid=" + sourceDetailId;
                    dtSource = ArrivePrinterBLL.GetFormsData(filter, conn);
                    ;
                }

                if (codeType == "转换标签") //来源于到形态转换标签
                {
                    string filter = " and  AssemVouchs.Autoid=" + sourceDetailId;
                    dtSource = InvChangePrinterBLL.GetFormsData(filter, conn);

                }

                if (codeType == "入库标签") //来源于产品入库标签
                {
                    string filter = " and  mom_orderdetail.modid=" + sourceDetailId;
                    dtSource = InvWHInPrinterBLL.GetFormsData(filter, conn);

                }

                if (codeType == "库存标签") //来源于库存先存量标签
                {
                    string filter = " and  c.AutoID=" + sourceDetailId;
                    dtSource = InvStockPrinterBLL.GetFormsData(filter, conn);

                }

                if (dtSource == null)
                {
                    errmsgs.Add("无法根据条码:" + item.BarCode + " 找到标签类别");
                    continue;
                }
                if (dtSource.Rows.Count == 0)
                {
                    errmsgs.Add("无法根据条码:" + item.BarCode + " 找到对应存货信息");
                    continue;
                }
                DataRow newRow = dtResult.NewRow();
                foreach (DataColumn col in dtResult.Columns)
                {
                    if (dtSource.Columns.Contains(col.ColumnName))
                    {
                        newRow[col] = dtSource.Rows[0][col.ColumnName];
                    }
                }
                newRow["正常数量"] = item.CheckQty;
                newRow["不良数量"] = item.BadQty;
                newRow["读取条形码"] = item.BarCode;
                newRow["来源单据"] = codeType;
                newRow["状态"] = item.Status;
                dtResult.Rows.Add(newRow);

            }
            if (errmsgs.Count > 0)
            {
                errMsg = string.Join("\r\n", errmsgs.ToArray());
            }
            return dtResult;
        }

        internal static string SaveData(string maker, string checkDate, string checkName, string checkWareHouse, DataTable dtSource, string connStr)
        {
            string sql = @"
                insert into dbo.Addins_WHCheck 
                        ( BillId ,
                          MakeName ,
                          BillFormCode ,
                          BillDate ,
                          CheckerName ,
                          CheckDate ,
                          CheckWareHouse
                        )
                values  ( '{0}' , -- BillId - uniqueidentifier
                          N'{1}' , -- MakeName - nvarchar(50)
                          N'{2}' , -- BillFormCode - nvarchar(50)
                          getdate() , -- BillDate - datetime
                          N'{3}' , -- CheckerName - nvarchar(50)
                          '{4}' , -- CheckDate - datetime
                          N'{5}'  -- CheckWareHouse - nvarchar(50)
                        )
                ";
            string formCode = Utils.GetFormNumber("CHK", "Addins_WHCheck", "BillFormCode", Utils.GetServerTime(connStr), false, connStr);
            string billId = Guid.NewGuid().ToString();

            sql = string.Format(sql, billId, maker, formCode, checkName, checkDate, checkWareHouse);

            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                //表头
                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sql);

                int sortSeq = 1;
                foreach (DataRow row in dtSource.Rows)
                {
                    sql = @"
                        set nocount on 
                        insert into dbo.Addins_WHCheckDetail 
                                ( DetailId ,
                                  BillId ,
                                  SortSeq ,
                                  BarCode 
                                )
                        values  ( '{0}' , -- DetailId - uniqueidentifier
                                  '{1}' , -- BillId - uniqueidentifier
                                  {2} , -- SortSeq - int
                                  N'{3}'  -- BarCode - nvarchar(50)
                                )

                        delete  dbo.Addins_WHChekResult where BarCode ='{3}'

                        insert into dbo.Addins_WHChekResult 
                                ( DetailId ,
                                  SortSeq ,
                                  BarCode ,
                                  CheckerName,
                                  CheckWareHouseName
                                )
                        values  ( '{0}' , -- DetailId - uniqueidentifier
                                  {2} , -- SortSeq - int
                                  N'{3}',  -- BarCode - nvarchar(50)
                                  '{4}',
                                  '{5}'
                                )   

                        ";
                    string detailId = Guid.NewGuid().ToString();
                    string barCode = row["读取条形码"].ToString();
                    string checkQty = row["正常数量"].ToString();
                    string badQty = row["不良数量"].ToString();
                    sql = string.Format(sql, detailId, billId, sortSeq, barCode, checkName,checkWareHouse );
                    sortSeq++;
                    //表体明细
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sql);

                    sql = @"
                        update  dbo.Addins_WHCheckDetail
                        set     [序号] = '{0}' ,
                                [来源单据] = '{1}' ,
                                [单据号码] = '{2}' ,
                                [单据日期] = '{3}' ,
                                [制单人] = '{4}' ,
                                [存货编码] = '{5}' ,
                                [品名] = '{6}' ,
                                [规格] = '{7}' ,
                                [单据数量] = '{8}' ,
                                [仓库编码] = '{9}' ,
                                [批号] = '{10}' ,
                                [用料客户] = '{11}' ,
                                [料头责任人] = '{12}' ,
                                [变化宽幅] = '{13}' ,
                                [变化长度] = '{14}' ,
                                [计量单位] = '{15}' ,
                                [显示规格] = '{16}' ,
                                [显示数量] = '{17}' ,
                                --[读取条形码] = '{18}' ,
                                [正常数量] = '{19}',
                                [不良数量] = '{20}',
                                [状态]='{21}',
                                [备注]='{22}'
                        where DetailId='" + detailId + "'";

                    string sql2 = @"
                        update  dbo.Addins_WHChekResult
                        set     [序号] = '{0}' ,
                                [来源单据] = '{1}' ,
                                [单据号码] = '{2}' ,
                                [单据日期] = '{3}' ,
                                [制单人] = '{4}' ,
                                [存货编码] = '{5}' ,
                                [品名] = '{6}' ,
                                [规格] = '{7}' ,
                                [单据数量] = '{8}' ,
                                [仓库编码] = '{9}' ,
                                [批号] = '{10}' ,
                                [用料客户] = '{11}' ,
                                [料头责任人] = '{12}' ,
                                [变化宽幅] = '{13}' ,
                                [变化长度] = '{14}' ,
                                [计量单位] = '{15}' ,
                                [显示规格] = '{16}' ,
                                [显示数量] = '{17}' ,
                                --[读取条形码] = '{18}' ,
                                [正常数量] = '{19}',
                                [不良数量] = '{20}',
                                [状态]='{21}',
                                [备注]='{22}'
                        where DetailId='" + detailId + "'";

                    sql = string.Format(sql,
                        row["序号"].ToString(),
                        row["来源单据"].ToString(),
                        row["单据号码"].ToString(),
                        row["单据日期"].ToString(),
                        row["制单人"].ToString(),
                        row["存货编码"].ToString(),
                        row["品名"].ToString(),
                        row["规格"].ToString(),
                        row["单据数量"].ToString(),
                        row["仓库编码"].ToString(),
                        row["批号"].ToString(),
                        row["用料客户"].ToString(),
                        row["料头责任人"].ToString().Replace("'", ""),
                        row["变化宽幅"].ToString(),
                        row["变化长度"].ToString(),
                        row["计量单位"].ToString(),
                        row["显示规格"].ToString(),
                        row["显示数量"].ToString(),
                        "",
                        row["正常数量"].ToString(),
                        row["不良数量"].ToString(),
                        row["状态"].ToString(),
                        row["备注"].ToString()
                        );

                    sql2 = string.Format(sql2,
                    row["序号"].ToString(),
                    row["来源单据"].ToString(),
                    row["单据号码"].ToString(),
                    row["单据日期"].ToString(),
                    row["制单人"].ToString(),
                    row["存货编码"].ToString(),
                    row["品名"].ToString(),
                    row["规格"].ToString(),
                    row["单据数量"].ToString(),
                    row["仓库编码"].ToString(),
                    row["批号"].ToString(),
                    row["用料客户"].ToString(),
                    row["料头责任人"].ToString().Replace("'", ""),
                    row["变化宽幅"].ToString(),
                    row["变化长度"].ToString(),
                    row["计量单位"].ToString(),
                    row["显示规格"].ToString(),
                    row["显示数量"].ToString(),
                    "",
                    row["正常数量"].ToString(),
                    row["不良数量"].ToString(),
                    row["状态"].ToString(),
                    row["备注"].ToString()
                    );
                 
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sql);
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sql2);

                }
                tran.Commit();
                return formCode;
            }
            catch (Exception error)
            {
                tran.Rollback();
                throw new Exception(error.Message);
            }

        }

        internal static void Delete(string Conn, string formCode)
        {
            string sql = @"
                    set nocount on 
                    delete  dbo.Addins_WHCheckDetail
                    from    dbo.Addins_WHCheckDetail d
                            left join dbo.Addins_WHCheck C on d.BillId = C.BillId
                    where   C.BillFormCode = '{0}'

                    delete  dbo.Addins_WHCheck
                    where   BillFormCode = '{0}'";
            sql = string.Format(sql, formCode);
            SqlHelper.ExecuteNonQuery(Conn, CommandType.Text, sql);

        }

        internal static DataTable GetFormsData(string filter, string Conn)
        {
            string sql = FilterSql.Replace("1=1", "1=1 " + filter);
            return SqlHelper.ExecuteDataset(Conn, CommandType.Text, sql).Tables[0];
        }

        internal static bool CheckUser(string userName, string conn)
        {
            string sql = "select * from UFSystem .dbo .UA_User where cUser_Name ='{0}' ";
            sql = string.Format(sql, userName);
            DataTable dt = SqlHelper.ExecuteDataset(conn, CommandType.Text, sql).Tables[0];
            if (dt.Rows.Count == 0)
                return false;

            return true;
        }

        internal static bool ChecWareHouseName(string wareHouseName, string conn)
        {
            string sql = "select * from dbo.Warehouse where cWhName ='{0}' ";
            sql = string.Format(sql, wareHouseName);
            DataTable dt = SqlHelper.ExecuteDataset(conn, CommandType.Text, sql).Tables[0];
            if (dt.Rows.Count == 0)
                return false;

            return true;
        }


    }
}
