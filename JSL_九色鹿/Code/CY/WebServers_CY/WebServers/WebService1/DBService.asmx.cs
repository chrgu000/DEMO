using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.IO;
using System.Xml;
using ClsU8;
using ClsBaseClass;

namespace TH.DBWebService
{
    
    /// <summary>
    /// 
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class DBWebService : System.Web.Services.WebService
    {
        ClsDES ClsDES = ClsDES.Instance();
        #region 自动更新文件
        [WebMethod]
        public string dtFileV()
        {
            string sSQL = @"
SELECT 
      [文件名称]
      ,[路径]
      ,[版本]
      ,[更新日期]
      ,[创建时间]
  FROM [XWSystemDB_FH].[dbo].[文件版本信息]
  order by iID
";
            ClsBaseClass.ClsDataBase clsSQL = ClsBaseClass.ClsDataBaseFactory.Instance();
            DataTable dt = clsSQL.ExecQuery(sSQL);
            return Cls序列化.SerializeDataTableXml(dt);
        }

        [WebMethod]
        public string dtDownFileVer(string sFileName)
        {
            string sSQL = @"
SELECT 
      [文件名称]
      ,[文件]
      ,[路径]
      ,[版本]
      ,[更新日期]
      ,[创建时间]
  FROM [XWSystemDB_FH].[dbo].[文件版本信息]
   where  [文件名称] = '111111'
  order by iID
";
            sSQL = sSQL.Replace("111111", sFileName);
            ClsBaseClass.ClsDataBase clsSQL = ClsBaseClass.ClsDataBaseFactory.Instance();
            DataTable dt = clsSQL.ExecQuery(sSQL);
            return Cls序列化.SerializeDataTableXml(dt);
        }
        #endregion


        [WebMethod]
        public string UploadFile(string iID,string sFolder, string fileName, byte[] fileContent)
        {
            UploadDownLoad cls = new UploadDownLoad();
            return (cls.UploadFile(iID,sFolder,fileName, fileContent));
        }

        [WebMethod]
        public string sDelFolder(string iID, string fileName)
        {
            UploadDownLoad cls = new UploadDownLoad();
            return cls.sDelFolder(iID, fileName);
        }

        [WebMethod]
        public string sFolder(string iID, string fileName)
        {
            UploadDownLoad cls = new UploadDownLoad();
            return cls.sFolder(iID, fileName);
        }

        [WebMethod]
        public byte[] DownloadFile(string filePath)
        {
            UploadDownLoad cls = new UploadDownLoad();
            return cls.DownloadFile(filePath);
        }

        [WebMethod]
        public string GetFilesName(string filePath)
        {
            UploadDownLoad cls = new UploadDownLoad();
            return cls.GetFilesName(filePath);
        }

    }
}
