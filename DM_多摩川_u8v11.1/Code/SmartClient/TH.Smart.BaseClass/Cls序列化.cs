
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.Data;
using System.IO;

namespace TH.Smart.BaseClass
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

      //   /// <summary>
      ///// 序列化DataTable
      ///// </summary>
      ///// <param name="pDt">包含数据的DataTable</param>
      ///// <returns>序列化的DataTable</returns>
      //  private static string SerializeDataTableXml(DataTable pDt)
      //  {
      //      // 序列化DataTable
      //      StringBuilder s = new StringBuilder();
      //      XmlWriter writer = XmlWriter.Create(s);
      //      XmlSerializer serializer = new XmlSerializer(typeof(DataTable));
      //      serializer.Serialize(writer, pDt);
      //      writer.Close();

      //      return s.ToString();
      //  }


      //  /// <summary>
      //    /// 反序列化DataTable
      //    /// </summary>
      //    /// <param name="pXml">序列化的DataTable</param>
      //    /// <returns>DataTable</returns>
      //  public static DataTable DeserializeDataTable(string pXml)
      //  {
      //      StringReader strReader = new StringReader(pXml);
      //      XmlReader xmlReader = XmlReader.Create(strReader);
      //      XmlSerializer serializer = new XmlSerializer(typeof(DataTable));

      //      DataTable dt = serializer.Deserialize(xmlReader) as DataTable;

      //      return dt;
      //  }

      //  /// <summary>
      //  /// 获得对象序列化后的xml字符
      //  /// </summary>
      //  /// <param name="sourceObject"></param>
      //  /// <returns></returns>
      //  public static string SerializeObject2XML(object sourceObject)
      //  {
      //      StringBuilder xmlString = new StringBuilder(null);
      //      try
      //      {
      //          XmlSerializer serializer = new XmlSerializer(sourceObject.GetType());
      //          TextWriter myWriter = new StringWriter(xmlString);
      //          serializer.Serialize(myWriter, sourceObject);
      //      }
      //      catch (Exception excp)
      //      {
      //          throw excp;
      //      }
      //      return xmlString.ToString();
      //  }

      //  /// <summary>
      //  /// 对象序列化到xml文件
      //  /// </summary>
      //  /// <param name="sourceObject"></param>
      //  /// <param name="fileName"></param>
      //  public static void SerializeObject2XMLFile(object sourceObject, string fileName)
      //  {
      //      try
      //      {
      //          if (!Directory.Exists(Path.GetDirectoryName(fileName)))
      //              Directory.CreateDirectory(Path.GetDirectoryName(fileName));

      //          XmlSerializer serializer = new XmlSerializer(sourceObject.GetType());
      //          TextWriter myWriter = new StreamWriter(fileName);
      //          serializer.Serialize(myWriter, sourceObject);
      //          myWriter.Close();
      //      }
      //      catch (Exception excp)
      //      {
      //          throw excp;
      //      }
      //  }

      //  /// <summary>
      //  /// 把xml字符反序列化为对象
      //  /// </summary>
      //  /// <param name="sourceString"></param>
      //  /// <param name="sourceObect"></param>
      //  /// <returns></returns>
      //  public static object DeserializeXML2Object(string sourceString, object sourceObect)
      //  {
      //      TextReader reader = null;
      //      object result = null;
      //      try
      //      {
      //          reader = new StringReader(sourceString);
      //          XmlSerializer deserializer = new XmlSerializer(sourceObect.GetType());
      //          result = deserializer.Deserialize(reader);
      //      }
      //      catch (Exception excp)
      //      {
      //          throw excp;
      //      }
      //      finally
      //      {
      //          if (reader != null)
      //              reader.Close();
      //      }
      //      return result;
      //  }

      //  /// <summary>
      //  /// 把xml文件反序列化为对象
      //  /// </summary>
      //  /// <param name="fileName"></param>
      //  /// <param name="sourceObect"></param>
      //  /// <returns></returns>
      //  public static object DeserializeFromXMLFile2Object(string fileName, object sourceObect)
      //  {
      //      TextReader reader = null;
      //      object result = null;
      //      try
      //      {
      //          if (!File.Exists(fileName))
      //              return null;
      //          reader = new StreamReader(fileName);
      //          XmlSerializer deserializer = new XmlSerializer(sourceObect.GetType());
      //          result = deserializer.Deserialize(reader);
      //          reader.Close();
      //      }
      //      catch (Exception excp)
      //      {
      //          throw excp;
      //      }
      //      finally
      //      {
      //          if (reader != null)
      //              reader.Close();
      //      }
      //      return result;
      //  }
    }
}
