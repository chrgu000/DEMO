﻿
using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.Data;
using System.IO;

namespace ClsBaseClass
{
    public class Cls序列化
    {
         /// <summary>
      /// 序列化DataTable
      /// </summary>
      /// <param name="pDt">包含数据的DataTable</param>
      /// <returns>序列化的DataTable</returns>
        public static string SerializeDataTableXml(DataTable pDt)
        {
            // 序列化DataTable
            StringBuilder s = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(s);
            XmlSerializer serializer = new XmlSerializer(typeof(DataTable));
            serializer.Serialize(writer, pDt);
            writer.Close();

            return s.ToString();
        }


        /// <summary>
          /// 反序列化DataTable
          /// </summary>
          /// <param name="pXml">序列化的DataTable</param>
          /// <returns>DataTable</returns>
        public static DataTable DeserializeDataTable(string pXml)
        {
            StringReader strReader = new StringReader(pXml);
            XmlReader xmlReader = XmlReader.Create(strReader);
            XmlSerializer serializer = new XmlSerializer(typeof(DataTable));

            DataTable dt = serializer.Deserialize(xmlReader) as DataTable;

            return dt;
        }

        /// <summary>
        /// 将xml字符串转换成DataSet
        /// </summary>
        /// <param name="xmlData"></param>
        /// <returns></returns>
        public static DataSet ConvertXMLToDataSet(string xmlData)
        {
            StringReader stream = null;
            XmlTextReader reader = null;
            try
            {
                DataSet xmlDS = new DataSet();
                stream = new StringReader(xmlData);
                reader = new XmlTextReader(stream);
                xmlDS.ReadXml(reader);
                return xmlDS;
            }
            catch (Exception ex)
            {
                string strTest = ex.Message;
                return null;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }  
    }
}
