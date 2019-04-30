using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;

namespace ϵͳ����
{
    /// <summary>
    /// DataTable����ת��Ϊ�ַ���
    /// </summary>
    public class ClsDataExport
    {
        /// <summary>
        ///  DataTable����ת��Ϊ�ַ���
        /// </summary>
        /// <param name="dt">��Ҫ������DataTable����</param>
        /// <param name="sPartition">���ݼ���</param>
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
