
using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.Data;
using System.IO;

namespace CheckUpdate
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
            if (pDt.TableName == "")
            {
                pDt.TableName = "Table1";
            }
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
    }
}
