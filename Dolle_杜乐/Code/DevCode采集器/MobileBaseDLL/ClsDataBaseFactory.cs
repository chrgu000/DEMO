using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


namespace MobileBaseDLL
{
    #region  SQL Server操作类ClsSQLServerCommond
    /// <summary>
    /// 数据访问基础类(基于SQLServer)
    /// </summary>
    public class ClsSQLServerCommond
    {
        public ClsSQLServerCommond() { }

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public  int ExecSql(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(MobileBaseDLL.ClsBaseDataInfo.sConnString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        SQLString = SQLString.Replace("@u8", MobileBaseDLL.ClsBaseDataInfo.sUFDataBaseName.Trim() + ".dbo");
                        cmd.CommandTimeout = 3600;
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        connection.Close();
                        throw new Exception(E.Message);
                    }
                }
            }
        }


        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>		
        public  int ExecSqlTran(ArrayList SQLStringList)
        {
            int iExecCou = 0;
            using (SqlConnection conn = new SqlConnection(MobileBaseDLL.ClsBaseDataInfo.sConnString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandTimeout = 3600;
                cmd.Connection = conn;
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                string strsql = "";
                try
                {
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        strsql = SQLStringList[n].ToString().Replace("@u8", MobileBaseDLL.ClsBaseDataInfo.sUFDataBaseName.Trim() + ".dbo");
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            iExecCou = iExecCou + cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    tx.Rollback();
                    throw new Exception(E.Message);
                }
                return iExecCou;
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public  object ExecGetScalar(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(MobileBaseDLL.ClsBaseDataInfo.sConnString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        SQLString = SQLString.Replace("@u8", MobileBaseDLL.ClsBaseDataInfo.sUFDataBaseName.Trim() + ".dbo");
                        connection.Open();
                        cmd.CommandText = SQLString;
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw new Exception(e.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataTable
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public  DataTable ExecQuery(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(MobileBaseDLL.ClsBaseDataInfo.sConnString))
            {
                DataSet ds = new DataSet();
                try
                {
                    SQLString = SQLString.Replace("@u8", MobileBaseDLL.ClsBaseDataInfo.sUFDataBaseName.Trim() + ".dbo");
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds.Tables[0];
            }
        }
    }
    #endregion 
}
