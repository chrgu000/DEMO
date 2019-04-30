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

    #region  SQL Server������ClsSQLServerCommond
    /// <summary>
    /// ���ݷ��ʻ�����(����SQLServer)
    /// </summary>
    public class ClsSQLServerCommond
    {

        TH.DBWebService.ClsDES clsDES = TH.DBWebService.ClsDES.Instance();

        public ClsSQLServerCommond() 
        {
           
        }
        /// <summary>
        /// ����������Ϣ
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
         ///ִ��SQL��䣬����Ӱ��ļ�¼��
         ///</summary>
         ///<param name="SQLString">SQL���</param>
         ///<returns>Ӱ��ļ�¼��</returns>
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
        /// ִ�ж���SQL��䣬ʵ�����ݿ�����
        /// </summary>
        /// <param name="SQLStringList">����SQL���</param>		
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
        /// ִ��һ�������ѯ�����䣬���ز�ѯ�����object����
        /// </summary>
        /// <param name="SQLString">�����ѯ������</param>
        /// <returns>��ѯ�����object��</returns>
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
        /// ִ��һ�������ѯ�����䣬���ز�ѯ�����object����
        /// </summary>
        /// <param name="SQLString">�����ѯ������</param>
        /// <param name="sDataBaseName">�ڶ����ݿ�����</param>
        /// <returns>��ѯ���</returns>
        public  object ExecGetScalar(string SQLString, string sDataBaseName)
        {

            if (sDataBaseName.Trim() == string.Empty)
                sDataBaseName = TH.DBWebService.ClsBaseDataInfo.sUFDataBaseName;

            SQLString = SQLString.Replace("@u8", sDataBaseName + ".dbo");
            return ExecGetScalar(SQLString);
        }

        /// <summary>
        /// ִ�в�ѯ��䣬����SqlDataReader
        /// </summary>
        /// <param name="strSQL">��ѯ���</param>
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
        /// ִ�в�ѯ��䣬����DataTable
        /// </summary>
        /// <param name="SQLString">��ѯ���</param>
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
        /// ִ�в�ѯ��䣬����DataTable
        /// </summary>
        /// <param name="SQLString">��ѯ���</param>
        /// <param name="sDataBaseName">�ڶ����ݿ�����</param>
        /// <returns>DataSet</returns>
        public  DataTable ExecQuery(string SQLString, string sDataBaseName)
        {
            if (sDataBaseName.Trim() == string.Empty)
                sDataBaseName = TH.DBWebService.ClsBaseDataInfo.sUFDataBaseName;

            SQLString = SQLString.Replace("@u8", sDataBaseName + ".dbo");
            return ExecQuery(SQLString);
        }

        /// <summary>
        /// ִ�в�ѯ��䣬����DataSet
        /// </summary>
        /// <param name="SQLString">��ѯ���</param>
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
        /// ִ�в�ѯ��䣬����DataSet
        /// </summary>
        /// <param name="SQLString">��ѯ���</param>
        /// <param name="sDataBaseName">�ڶ����ݿ�����</param>
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
        /// ִ�в�ѯ��䣬����DataSet
        /// </summary>
        /// <param name="SQLString">��ѯ���</param>
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
