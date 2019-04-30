using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Collections;

namespace UFIDA.U8.UAP.CustomApp.MetaData
{
    /// <summary>
    /// 读取Excel
    /// </summary>
    public  class ClsExcel
    {

        private static volatile ClsExcel clsExcel = null;
        private static object lockHelper = new object();
        private ClsExcel() { }
        public static ClsExcel Instance()
        {
            if (clsExcel == null)
            {
                lock (lockHelper)
                {
                    if (clsExcel == null)
                    {
                        clsExcel = new ClsExcel();
                    }
                }
            }
            return clsExcel;
        }

        /// <summary>
        /// 读取Excel转换为DataSet
        /// </summary>
        /// <param name="Path">路径</param>
        /// <param name="arrList">读取Excel的查询语句ArrayList; 如：select * from [Sheet1$]</param>
        /// <param name="bIsTitle">Excel第一行是否标题</param>
        /// <returns>DataSet</returns>
        public static DataSet ExcelToDS(string Path, ArrayList arrList, bool bIsTitle)
        {
            try
            {
                string sHDR = "NO";
                if (bIsTitle)
                    sHDR = "YES";

                string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + Path + ";" + "Extended Properties='Excel 8.0;HDR=" + sHDR + ";IMEX=1;'";
           
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();

                string strExcel = "";
                OleDbDataAdapter myCommand = new OleDbDataAdapter(strExcel, strConn);
                DataSet ds = new DataSet(); 

                for (int i = 0; i < arrList.Count; i++)
                {
                    strExcel = arrList[i].ToString();
                    myCommand.SelectCommand.CommandText = strExcel;
                    myCommand.Fill(ds,"dt"+i.ToString());
                }

                conn.Close();

                if (ds == null || ds.Tables.Count < 1)
                    return null;
                else
                    return ds; 
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        /// <summary>
        /// 读取Excel转换为DataTable
        /// </summary>
        /// <param name="Path">路径</param>
        /// <param name="sSQL">读取Excel的查询语句 如：select * from [Sheet1$]</param>
        /// <param name="bIsTitle">Excel第一行是否标题</param>
        /// <returns>DataTable</returns>
        public static DataTable ExcelToDT(string Path, string sSQL, bool bIsTitle)
        {
            try
            {
                ArrayList arrList = new ArrayList();
                arrList.Add(sSQL);
                DataSet ds = ExcelToDS(Path, arrList, bIsTitle);

                if (ds == null || ds.Tables.Count < 1)
                    return null;
                else
                    return ds.Tables[0];
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

    }
}
