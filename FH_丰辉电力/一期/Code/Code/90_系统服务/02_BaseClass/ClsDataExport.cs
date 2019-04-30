using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;

namespace 系统服务
{
    /// <summary>
    /// DataTable数据转换为字符串
    /// </summary>
    public class ClsDataExport
    {
        /// <summary>
        ///  DataTable数据转换为字符串
        /// </summary>
        /// <param name="dt">需要导出的DataTable数据</param>
        /// <param name="sPartition">数据间间隔</param>
        /// <returns></returns>
        public string sDataExport(DataTable dt, string sPartition)
        {
            string sData = "";

            for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
            {
                for (int iCol = 0; iCol < dt.Columns.Count; iCol++)
                {
                    sData = sData + dt.Rows[iRow][iCol].ToString().Trim() + sPartition;
                }
            }

            return sData;
        }
    }
}
