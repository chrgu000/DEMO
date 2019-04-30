using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FrameBaseFunction
{
    /// <summary>
    /// 数据访问基础类(基于XML)
    /// </summary>
    public class ClsXMLCommond
    {
        #region  

        /// <summary>
        /// 读取XML，返回DataTable
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <param name="sDataBaseName">U8数据库名称</param>
        /// <returns>DataSet</returns>
        public DataSet ExecQuery(string sPath)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(sPath);
            if (ds == null)
                return null;

            return ds;
        }

        #endregion
    }
}
