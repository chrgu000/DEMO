﻿using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace FrameBaseFunction
{

    #region  数据库操作基类ClsDataBase
    /// <summary>
    /// 数据访问基类
    /// </summary>
    public abstract class ClsDataBase
    {
        public virtual object ExecGetScalar(string sSQL) { return null; }
        public virtual int ExecSqlTran(ArrayList SQLStringList) { return -9999; }
        public virtual int ExecSql(string SQLString) { return -9999; }
        public virtual DataTable ExecQuery(string SQLString) { return null; }
        public virtual DataSet ExecQuery(ArrayList aList) { return null; }

        public virtual object ExecGetScalar(string sSQL, string sUFName) { return null; }
        public virtual void ExecSqlTran(ArrayList SQLStringList, string sDataBaseName) { }
        public virtual int ExecSql(string SQLString, string sDataBaseName) { return -9999; }
        public virtual DataTable ExecQuery(string SQLString, string sUFName) { return null; }
        public virtual DataSet ExecQuery(ArrayList aList, string sUFName) { return null; }
        public virtual SqlDataReader ExecuteReader(string strSQL) { return null; }

    }
    #endregion

    #region  数据库操作工厂ClsDataBaseFactory
    /// <summary>
    /// 数据访问工厂
    /// </summary>
    public class ClsDataBaseFactory
    {
        private static volatile ClsDataBase clsCommond = null;
        private static object lockHelper = new object();
        private ClsDataBaseFactory() { }
        public static ClsDataBase Instance()
        {
            if (clsCommond == null)
            {
                lock (lockHelper)
                {
                    if (clsCommond == null)
                    {
                        if (FrameBaseFunction.ClsBaseDataInfo.sDataBaseType.ToLower().Trim() == "sqlserver")
                            clsCommond = new FrameBaseFunction.ClsSQLServerCommond();
                        if (FrameBaseFunction.ClsBaseDataInfo.sDataBaseType.ToLower().Trim() == "webservice")
                            clsCommond = new FrameBaseFunction.ClsWebServerice();
                    }
                }
            }
            return clsCommond;
        }
    }
    #endregion

    #region  SQL Server操作类ClsSQLServerCommond
    /// <summary>
    /// 数据访问基础类(基于SQLServer)
    /// </summary>
    public class ClsSQLServerCommond : FrameBaseFunction.ClsDataBase
    {
        public ClsSQLServerCommond() { }

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public override int ExecSql(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        SQLString = SQLString.Replace("@u8", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Trim() + ".dbo");
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

        ///// <summary>
        ///// 执行SQL语句，返回影响的记录数
        ///// </summary>
        ///// <param name="SQLString">SQL语句</param>
        ///// <param name="sDataBaseName">第二数据库名称</param>
        ///// <returns>影响的记录数</returns>
        //public override int ExecSql(string SQLString, string sDataBaseName)
        //{
        //    if (sDataBaseName.Trim() == string.Empty)
        //        sDataBaseName = FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName;

        //    SQLString = SQLString.Replace("@U8", sDataBaseName + ".dbo");
        //    return ExecSql(SQLString);
        //}


        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>		
        public override int ExecSqlTran(ArrayList SQLStringList)
        {
            int iExecCou = 0;
            using (SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString))
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
                        strsql = SQLStringList[n].ToString().Replace("@u8", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Trim() + ".dbo");
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

        ///// <summary>
        ///// 执行多条SQL语句，实现数据库事务。
        ///// </summary>
        ///// <param name="SQLStringList">多条SQL语句</param>		
        //public override void ExecSqlTran(ArrayList SQLStringList)
        //{
        //    using (SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString))
        //    {
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandTimeout = 3600;
        //        cmd.Connection = conn;
        //        SqlTransaction tx = conn.BeginTransaction();
        //        cmd.Transaction = tx;
        //        string strsql = "";
        //        try
        //        {
        //            for (int n = 0; n < SQLStringList.Count; n++)
        //            {
        //                strsql = SQLStringList[n].ToString().Replace("@u8", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Trim() + ".dbo");
        //                if (strsql.Trim().Length > 1)
        //                {
        //                    cmd.CommandText = strsql;cmd.ExecuteNonQuery();
        //                }
        //            }
        //            tx.Commit();
        //        }
        //        catch (System.Data.SqlClient.SqlException E)
        //        {
        //            tx.Rollback();
        //            throw new Exception(E.Message);
        //        }
        //    }
        //}

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public override object ExecGetScalar(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        SQLString = SQLString.Replace("@u8", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Trim() + ".dbo");
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
        public override DataTable ExecQuery(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString))
            {
                DataSet ds = new DataSet();
                try
                {
                    SQLString = SQLString.Replace("@u8", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Trim() + ".dbo");
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

        ///// <summary>
        ///// 执行查询语句，返回DataTable
        ///// </summary>
        ///// <param name="SQLString">查询语句</param>
        ///// <param name="sDataBaseName">第二数据库名称</param>
        ///// <returns>DataSet</returns>
        //public override DataTable ExecQuery(string SQLString, string sDataBaseName)
        //{
        //    if (sDataBaseName.Trim() == string.Empty)
        //        sDataBaseName = FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName;

        //    SQLString = SQLString.Replace("@U8", sDataBaseName + ".dbo");
        //    return ExecQuery(SQLString);
        //}

        ///// <summary>
        ///// 执行查询语句，返回DataSet
        ///// </summary>
        ///// <param name="SQLString">查询语句</param>
        ///// <returns>DataSet</returns>
        //public override DataSet ExecQuery(ArrayList SQLString)
        //{
        //    using (SqlConnection connection = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString))
        //    {
        //        DataSet ds = new DataSet();
        //        try
        //        {
        //            connection.Open();

        //            for (int i = 0; i < SQLString.Count; i++)
        //            {
        //                SqlDataAdapter command = new SqlDataAdapter(SQLString[i].ToString(), connection);
        //                command.Fill(ds, "ds" + i.ToString());
        //            }
        //        }
        //        catch (System.Data.SqlClient.SqlException ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //        return ds;
        //    }
        //}

        ///// <summary>
        ///// 执行查询语句，返回DataSet
        ///// </summary>
        ///// <param name="SQLString">查询语句</param>
        ///// <param name="sDataBaseName">第二数据库名称</param>
        ///// <returns>DataSet</returns>
        //public override DataSet ExecQuery(ArrayList SQLString, string sDataBaseName)
        //{
        //    if (sDataBaseName.Trim() == string.Empty)
        //        sDataBaseName = FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName;

        //    ArrayList arrList = new ArrayList();
        //    for (int i = 0; i < SQLString.Count; i++)
        //    {
        //        arrList.Add(SQLString[i].ToString().Replace("@U8", sDataBaseName + ".dbo"));
        //    }
        //    return ExecQuery(arrList);
        //}
    }
    #endregion 

    #region  WebServerice操作
    public class ClsWebServerice : FrameBaseFunction.ClsDataBase
    {
        //ClsDES clsDES = ClsDES.Instance();
        //WebReferences.DBWebService DBService = new WebReferences.DBWebService();

        //public ClsWebServerice() 
        //{
        //    DBService.Url = FrameBaseFunction.ClsBaseDataInfo.sWebURL;
        //}

        ///// <summary>
        ///// 执行SQL语句，返回影响的记录数
        ///// </summary>
        ///// <param name="SQLString">SQL语句</param>
        ///// <returns>影响的记录数</returns>
        //public override int ExecSql(string SQLString)
        //{
        //    SQLString = SQLString.Replace("@u8", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Trim() + ".dbo");
        //    string sSQL = clsDES.Encrypt(SQLString);
        //    DBService.ExecSQL(sSQL);
        //    return 1;
        //}

        ///// <summary>
        ///// 执行查询语句，返回DataTable
        ///// </summary>
        ///// <param name="SQLString">查询语句</param>
        ///// <returns>DataSet</returns>
        //public override DataTable ExecQuery(string SQLString)
        //{
        //    SQLString = SQLString.Replace("@u8", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Trim() + ".dbo");
        //    string sSQL = clsDES.Encrypt(SQLString);
        //    DataSet ds = DBService.ExecQuery(sSQL);
        //    return ds.Tables[0];
        //}
        ///// <summary>
        ///// 执行多条SQL语句，实现数据库事务。
        ///// </summary>
        ///// <param name="SQLStringList">多条SQL语句</param>		
        //public override void ExecSqlTran(ArrayList SQLStringList)
        //{
        //    string s = "";
        //    for (int i = 0; i < SQLStringList.Count; i++)
        //    {
        //        s = s + SQLStringList[i].ToString().Replace("@u8", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Trim() + ".dbo").Trim() + "ヵ";
        //    }
        //    string sSQL = clsDES.Encrypt(s);
        //    DBService.ExecSqlTran(sSQL);
        //}

        //public override object ExecGetScalar(string SQLString)
        //{
        //    SQLString = SQLString.Replace("@u8", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Trim() + ".dbo");
        //    string sSQL = clsDES.Encrypt(SQLString);
        //    return DBService.ExecGetScalar(sSQL);
        //}
    }
    #endregion
}
