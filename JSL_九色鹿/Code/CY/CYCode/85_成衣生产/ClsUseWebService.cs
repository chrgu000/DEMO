using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace 成衣生产
{
    public class ClsUseWebService
    {
        WebReference.DBWebService DBWebServiceFile = new 成衣生产.WebReference.DBWebService();

        public ClsUseWebService()
        {
            if (系统服务.ClsBaseDataInfo.sWebURL.Trim() != "")
                DBWebServiceFile.Url = 系统服务.ClsBaseDataInfo.sWebURL;
        }

        public string UploadFile(string iID, string sFolder, string fileName, byte[] fileContent)
        {
            return DBWebServiceFile.UploadFile(iID, sFolder, fileName, fileContent);
        }

        public byte[] DownloadFile(string filePath)
        {
            return DBWebServiceFile.DownloadFile(filePath);
        }


        public string sDelFolder(string iID, string sFolder)
        {
            return DBWebServiceFile.sDelFolder(iID, sFolder);
        }

        public string sFolder(string iID, string sFolder)
        {
            return DBWebServiceFile.sFolder(iID, sFolder);
        }

        public string GetFilesName(string filePath)
        {
            return DBWebServiceFile.GetFilesName(filePath);
        }
    
    }
}
