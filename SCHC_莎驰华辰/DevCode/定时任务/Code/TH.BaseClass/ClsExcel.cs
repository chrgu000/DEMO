using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Collections;
using System.Data.Odbc;
using System.IO;

namespace TH.BaseClass
{
    /// <summary>
    /// ��ȡExcel
    /// </summary>
    public class ClsExcel
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
        /// ��ȡExcelת��ΪDataSet
        /// </summary>
        /// <param name="Path">·��</param>
        /// <param name="arrList">��ȡExcel�Ĳ�ѯ���ArrayList; �磺select * from [Sheet1$]</param>
        /// <param name="bIsTitle">Excel��һ���Ƿ����</param>
        /// <returns>DataSet</returns>
        public DataSet ExcelToDS(string Path, ArrayList arrList,bool bIsTitle)
        {
            try
            {
                string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Path + ";" + "Extended Properties='Excel 8.0;IMEX=1;" ;
                if (bIsTitle)
                    strConn += "HDR=YES;'";
                else
                    strConn += "HDR=NO;'";

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
        /// ��ȡExcelת��ΪDataTable
        /// </summary>
        /// <param name="Path">·��</param>
        /// <param name="sSQL">��ȡExcel�Ĳ�ѯ��� �磺select * from [Sheet1$]</param>
        /// <param name="bIsTitle">Excel��һ���Ƿ����</param>
        /// <returns>DataTable</returns>
        public DataTable ExcelToDT(string Path, string sSQL, bool bIsTitle)
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


        /// <summary>
        /// ��csv��ʽ�ļ�����dataset
        /// </summary>
        /// <param name="filePath">�ļ�·��</param>
        /// <returns></returns>
        public DataTable CSVToDS(string filePath)
        {
            //string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";
            //strConn = strConn + Directory.GetParent(filePath);
            //strConn = strConn + ";Extended Properties='text;HDR=Yes;FMT=Delimited'";
            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Directory.GetParent(filePath) + ";Extended Properties='Text;FMT=Delimited(,);HDR=NO;IMEX=1';";
           string fileName = filePath.Replace(Directory.GetParent(filePath).ToString().Trim() + "\\", "");

            OleDbConnection con = new OleDbConnection(strConn);
            DataSet data = new DataSet();
            string sql = "select * from " + fileName;
            OleDbDataAdapter adp = new OleDbDataAdapter(sql, con);
            con.Open();
            adp.Fill(data, "csv");

            return data.Tables[0];
        }
    }
}
