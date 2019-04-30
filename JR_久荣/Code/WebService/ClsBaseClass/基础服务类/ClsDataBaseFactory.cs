using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Xml;


namespace TH.DBWebService
{

    #region  SQL Server操作类ClsSQLServerCommond
    /// <summary>
    /// 数据访问基础类(基于SQLServer)
    /// </summary>
    public class ClsSQLServerCommond
    {

        TH.DBWebService.ClsDES clsDES = TH.DBWebService.ClsDES.Instance();

        public ClsSQLServerCommond() 
        {
           
        }
        /// <summary>
        /// 基础设置信息
        /// </summary>
        private void InitInfo()
        {

            string sPathConfig = AppDomain.CurrentDomain.BaseDirectory + @"bin\BaseInfo\App.dll";
            if (File.Exists(sPathConfig))
            {
                string sUid = clsDES.Decrypt(GetConfigValue(sPathConfig, "SQLUID"));
                string sPwd = clsDES.Decrypt(GetConfigValue(sPathConfig, "SQLPWD"));
                string sDataBaseInfo = clsDES.Decrypt(GetConfigValue(sPathConfig, "DataBaseInfo"));
                string sServer = clsDES.Decrypt(GetConfigValue(sPathConfig, "SQLSer"));
                TH.DBWebService.ClsBaseDataInfo.sConnString = "uid=" + sUid + ";pwd=" + sPwd + ";database=" + sDataBaseInfo + ";server=" + sServer + ";";
            }
        }

        ///
        /// Read confing
        /// </summary>
        /// <param name="path"></param>
        /// <param name="appKey"></param>
        /// <returns></returns>
        public string GetConfigValue(string path, string appKey)
        {
            XmlDocument xDoc = new XmlDocument();
            try
            {
                xDoc.Load(path);
                XmlNode xNode;
                XmlElement xElem;
                xNode = xDoc.SelectSingleNode("//appSettings");
                xElem = (XmlElement)xNode.SelectSingleNode("//add[@key='" + appKey + "']");
                if (xElem != null)
                    return xElem.GetAttribute("value");
                else
                    return "";
            }
            catch (Exception)
            {
                return "";
            }
        }
         ///<summary>
         ///执行SQL语句，返回影响的记录数
         ///</summary>
         ///<param name="SQLString">SQL语句</param>
         ///<returns>影响的记录数</returns>
        public  int ExecSql(string SQLString)
        {
            InitInfo();
            using (SqlConnection connection = new SqlConnection(TH.DBWebService.ClsBaseDataInfo.sConnString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
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
        public  void ExecSqlTran(ArrayList SQLStringList)
        {
            InitInfo();
            using (SqlConnection conn = new SqlConnection(TH.DBWebService.ClsBaseDataInfo.sConnString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandTimeout = 3600;
                cmd.Connection = conn;
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n].ToString();
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    tx.Rollback();
                    throw new Exception(E.Message);
                }
            }
        }

     
        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public  object ExecGetScalar(string SQLString)
        {
            InitInfo();
            using (SqlConnection connection = new SqlConnection(TH.DBWebService.ClsBaseDataInfo.sConnString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
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
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <param name="sDataBaseName">第二数据库名称</param>
        /// <returns>查询结果</returns>
        public  object ExecGetScalar(string SQLString, string sDataBaseName)
        {

            if (sDataBaseName.Trim() == string.Empty)
                sDataBaseName = TH.DBWebService.ClsBaseDataInfo.sUFDataBaseName;

            SQLString = SQLString.Replace("@u8", sDataBaseName + ".dbo");
            return ExecGetScalar(SQLString);
        }

        /// <summary>
        /// 执行查询语句，返回SqlDataReader
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>SqlDataReader</returns>
        public  SqlDataReader ExecuteReader(string strSQL)
        {
            InitInfo();
            SqlConnection connection = new SqlConnection(TH.DBWebService.ClsBaseDataInfo.sConnString);
            SqlCommand cmd = new SqlCommand(strSQL, connection);
            try
            {
                connection.Open();
                SqlDataReader myReader = cmd.ExecuteReader();
                return myReader;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }

        }

        /// <summary>
        /// 执行查询语句，返回DataTable
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public  DataTable ExecQuery(string SQLString)
        {
            InitInfo();
            using (SqlConnection connection = new SqlConnection(TH.DBWebService.ClsBaseDataInfo.sConnString))
            {
                DataSet ds = new DataSet();
                try
                {
                    string sDataBaseName = TH.DBWebService.ClsBaseDataInfo.sUFDataBaseName;
                    SQLString = SQLString.Replace("@u8", sDataBaseName + ".dbo");

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

        /// <summary>
        /// 执行查询语句，返回DataTable
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <param name="sDataBaseName">第二数据库名称</param>
        /// <returns>DataSet</returns>
        public  DataTable ExecQuery(string SQLString, string sDataBaseName)
        {
            if (sDataBaseName.Trim() == string.Empty)
                sDataBaseName = TH.DBWebService.ClsBaseDataInfo.sUFDataBaseName;

            SQLString = SQLString.Replace("@u8", sDataBaseName + ".dbo");
            return ExecQuery(SQLString);
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public  DataSet ExecQuery(ArrayList SQLString)
        {
            InitInfo();
            using (SqlConnection connection = new SqlConnection(TH.DBWebService.ClsBaseDataInfo.sConnString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();

                    for (int i = 0; i < SQLString.Count; i++)
                    {
                        SqlDataAdapter command = new SqlDataAdapter(SQLString[i].ToString(), connection);
                        command.Fill(ds, "ds" + i.ToString());
                    }
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <param name="sDataBaseName">第二数据库名称</param>
        /// <returns>DataSet</returns>
        public  DataSet ExecQuery(ArrayList SQLString, string sDataBaseName)
        {
            if (sDataBaseName.Trim() == string.Empty)
                sDataBaseName = TH.DBWebService.ClsBaseDataInfo.sUFDataBaseName;

            ArrayList arrList = new ArrayList();
            for (int i = 0; i < SQLString.Count; i++)
            {
                arrList.Add(SQLString[i].ToString().Replace("@u8", sDataBaseName + ".dbo"));
            }
            return ExecQuery(arrList);
        }



        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public DataSet ExecQueryDataSet(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(TH.DBWebService.ClsBaseDataInfo.sConnString))
            {
                DataSet ds = new DataSet();
                try
                {
                    SQLString = SQLString.Replace("@u8", TH.DBWebService.ClsBaseDataInfo.sUFDataBaseName.Trim() + ".dbo");
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }
    }
    #endregion
}
