using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using ClsBaseClass;
using System.IO;

namespace ClsU8
{
    public class UploadDownLoad
    {
        public string UploadFile(string iID,string sFolder,string fileName, byte[] fileContent)
        {
            try
            {
                //要上传到webservice发布的服务器的D盘中Temp文件夹，且上传之后的文件名参数fileName
                string filePath = ClsBaseDataInfo.sWebUpload + iID;

                FolderExists(ClsBaseDataInfo.sWebUpload + sFolder);

                FolderExists(ClsBaseDataInfo.sWebUpload + sFolder + "\\" + iID);

                string filename = ClsBaseDataInfo.sWebUpload + sFolder + "\\" + iID + "\\" + fileName;
                File.WriteAllBytes(filename, fileContent);
                return filename;
            }
            catch(Exception ee)
            {
                return "";
            }
        }

        public string sDelFolder(string iID, string sFolder)
        {
            try
            {
                string filePath = ClsBaseDataInfo.sWebUpload + sFolder + "\\" + iID;
                if (System.IO.Directory.Exists(filePath))
                {
                    foreach (string item in Directory.GetFiles(filePath))
                    {
                        File.Delete(item);
                    }
                }
                return filePath;
            }
            catch
            {
                return "";
            }

        }

        public string sFolder(string iID, string sFolder)
        {
            try
            {
                string filePath = ClsBaseDataInfo.sWebUpload + sFolder + "\\" + iID;
                return filePath;
            }
            catch
            {
                return "";
            }

        }

        public byte[] DownloadFile(string filePath)
        {
            try
            {
                FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                byte[] bytes = new byte[file.Length];

                //读取文件保存到字节流对象
                file.Read(bytes, 0, bytes.Length);
                return bytes;
            }
            catch
            {
            }
            return null;
        }

        public string GetNewName(string filePath)
        {
            int filenew = 0;
            string[] filenames = Directory.GetFiles(filePath);
            for (int j = 0; j < filenames.Length; j++)
            {
                int fn = ClsBaseDataInfo.ReturnObjectToInt(Path.GetFileNameWithoutExtension(filenames[j]));
                if (fn > filenew)
                {
                    filenew = fn;
                }
            }
            return (filenew + 1).ToString();
        }


        public string GetFilesName(string filePath)
        {
            string file = "";
            foreach (string item in Directory.GetFiles(filePath))
            {
                if (file != "")
                {
                    file = file + ",";
                }
                DirectoryInfo directoryinfo = new DirectoryInfo(item);
                string sFilePath = directoryinfo.FullName;
                file = file + sFilePath;
            }
            return file;
        }
        public bool FolderExists(string Folder)
        {
            if (System.IO.Directory.Exists(Folder) == false)
            {

                System.IO.Directory.CreateDirectory(Folder);
            }
            return true;
        }
    }
}
