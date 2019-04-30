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
        public string UploadFile(string iID,string fileName, byte[] fileContent)
        {
            try
            {
                //要上传到webservice发布的服务器的D盘中Temp文件夹，且上传之后的文件名参数fileName
                string filePath = ClsBaseDataInfo.sWebUpload + iID;

                //方式1：
                //StreamWriter sw = new StreamWriter(filePath);
                //sw.Write(fileContent);
                //sw.Close();
                //方式2：
                FolderExists(filePath);
                string filenew = GetNewName(filePath);
                string fileex = Path.GetExtension(fileName);
                string filename = filenew + fileex;
                File.WriteAllBytes(filePath + "\\" + filename, fileContent);
                return filename;
            }
            catch
            {
                return "";
            }
        }

        public byte[] DownloadFile(string iID, string Att)
        {
            try
            {
                //要上传到webservice发布的服务器的D盘中Temp文件夹，且上传之后的文件名参数fileName
                string filePath = ClsBaseDataInfo.sWebUpload + iID;

                //方式1：
                //StreamWriter sw = new StreamWriter(filePath);
                //sw.Write(fileContent);
                //sw.Close();
                //方式2：
                string filenew = ClsBaseDataInfo.sWebUpload + iID;
                string[] filenames = Directory.GetFiles(filePath);
                for (int j = 0; j < filenames.Length; j++)
                {
                    string fn = Path.GetFileName(filenames[j]);
                    if (Att == fn)
                    {
                        FileStream file = new FileStream(filenames[j], FileMode.Open, FileAccess.Read);
                        byte[] bytes = new byte[file.Length];

                        //读取文件保存到字节流对象
                        file.Read(bytes, 0, bytes.Length);
                        return bytes;
                    }
                }
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
