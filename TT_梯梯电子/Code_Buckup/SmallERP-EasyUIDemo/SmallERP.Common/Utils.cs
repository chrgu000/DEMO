using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Xml.Serialization;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;
using ThoughtWorks.QRCode.Codec;
using System.Web.Security;
using SmallERP.Common.Enums;

namespace SmallERP.Common
{

    public class Utils
    {
        /// <summary>
        /// 将父类的值赋值到子类中
        /// </summary>
        /// <typeparam name="TParent"></typeparam>
        /// <typeparam name="TChild"></typeparam>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static TChild AutoCopy<TParent, TChild>(TParent parent) where TChild : TParent, new()
        {
            TChild child = new TChild();
            var ParentType = typeof(TParent);
            var Properties = ParentType.GetProperties();
            foreach (var Propertie in Properties)
            {
                //循环遍历属性
                if (Propertie.CanRead && Propertie.CanWrite)
                {
                    //进行属性拷贝
                    Propertie.SetValue(child, Propertie.GetValue(parent, null), null);
                }
            }
            return child;
        }

        /// <summary>
        /// 获取枚举描述
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetEnumDescription(Enum enumValue)
        {
            string str = enumValue.ToString();
            System.Reflection.FieldInfo field = enumValue.GetType().GetField(str);
            object[] objs = field.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
            if (objs == null || objs.Length == 0) return str;
            System.ComponentModel.DescriptionAttribute da = (System.ComponentModel.DescriptionAttribute)objs[0];
            return da.Description;
        }


        /// <summary>
        /// 时间戳转为C#格式时间
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime TimeStampToTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime); return dtStart.Add(toNow);
        }
        /// <summary>
        /// 上传图片地址前缀
        /// </summary>
        public static string UploadFileUrl = GetCurrentFullUrl() + "/upload/";

        /// <summary>
        /// 得到当前完整主机头[www.baidu.com]
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentFullHost()
        {
            HttpRequest request = System.Web.HttpContext.Current.Request;
            if (!request.Url.IsDefaultPort)
                return string.Format("{0}:{1}", request.Url.Host, request.Url.Port.ToString());

            return request.Url.Host;
        }

        /// <summary>
        /// 得到当前访问的路径[http://www.baidu.com]
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentFullUrl()
        {
            string logoutPath = GetCurrentFullHost();
            return "http://" + logoutPath;
        }

        /// <summary>
        /// 得到当前访问的路径[http://www.baidu.com?pIdx=2]
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentUrl()
        {
            return HttpContext.Current.Request.Url.ToString();
        }


        /// <summary>
        /// 获取应用配置的节点信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetAppSettingString(string key)
        {
            try
            {
                string value = ConfigurationManager.AppSettings[key];
                return value;
            }
            catch (System.NullReferenceException ex)
            {
                throw new Exception(string.Format("GetAppSettingString 配置文件中没有相应的节点存在！节点名称:{0} " + ex.Message, key));
            }
        }
        /// <summary>
        /// 生成GUID
        /// </summary>
        /// <returns></returns>
        public static Guid CreateGuid()
        {
            return System.Guid.NewGuid();
        }

        /// <summary>
        /// 获取客户端网络IP
        /// </summary>
        /// <returns></returns>
        public static string GetClientIP()
        {
            var clientIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            if (!String.IsNullOrEmpty(HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]))
            {
                clientIP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            }
            return clientIP;
        }

        ///// <summary> 
        ///// MD5加密字符串 
        ///// </summary> 
        ///// <param name="source">源字符串</param> 
        ///// <returns>加密后的字符串</returns> 
        //public static string MD5(string source)
        //{
        //    return FormsAuthentication.HashPasswordForStoringInConfigFile(source, "MD5");
        //}
        public static string MD5Encrypt(string strPwd)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                Byte[] bytePwd = Encoding.GetEncoding("gb2312").GetBytes(strPwd);
                Byte[] hashPwd = md5.ComputeHash(bytePwd);
                string encryptPwd = Encoding.ASCII.GetString(hashPwd);
                return encryptPwd;
            }
        }
        public static string MD5Encrypt32(string password)
        {
            string cl = password;
            string pwd = "";
            MD5 md5 = MD5.Create(); //实例化一个md5对像
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 
                pwd = pwd + s[i].ToString("X");
            }
            return pwd;
        }
        public static string MD5Encrypt64(string password)
        {
            string cl = password;
            //string pwd = "";
            MD5 md5 = MD5.Create(); //实例化一个md5对像
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            return Convert.ToBase64String(s);
        }
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="input">加密字符</param>
        /// <returns></returns>
        public static string CreateMd5Hash(string input)
        {
            var md5Hasher = new MD5CryptoServiceProvider();
            byte[] buf = Encoding.UTF8.GetBytes(input); //utf-8数据 
            byte[] data = md5Hasher.ComputeHash(buf);
            var sBuilder = new StringBuilder();
            for (var i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
        private const int saltLength = 4;
        #region 私有函数
        /// <summary>
        /// 将一个字符串哈希化
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static byte[] HashString(string str)
        {
            byte[] pwd = System.Text.Encoding.UTF8.GetBytes(str);

            SHA1 sha1 = SHA1.Create();
            byte[] saltedPassword = sha1.ComputeHash(pwd);
            return saltedPassword;
        }
        /// <param name="input">加密字符</param>
        /// <returns></returns>
        /// <summary>
        /// Cash Claim System创建用户的数据库密码
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string CreateDbPassword(string userPassword)
        {
            byte[] unsaltedPassword = HashString(userPassword);

            //Create a salt value
            byte[] saltValue = new byte[saltLength];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(saltValue);

            byte[] saltedPassword = CreateSaltedPassword(saltValue, unsaltedPassword);

            return Convert.ToBase64String(saltedPassword);

        }
        // create a salted password given the salt value
        private static byte[] CreateSaltedPassword(byte[] saltValue, byte[] unsaltedPassword)
        {
            // add the salt to the hash
            byte[] rawSalted = new byte[unsaltedPassword.Length + saltValue.Length];
            unsaltedPassword.CopyTo(rawSalted, 0);
            saltValue.CopyTo(rawSalted, unsaltedPassword.Length);

            //Create the salted hash			
            SHA1 sha1 = SHA1.Create();
            byte[] saltedPassword = sha1.ComputeHash(rawSalted);

            // add the salt value to the salted hash
            byte[] dbPassword = new byte[saltedPassword.Length + saltValue.Length];
            saltedPassword.CopyTo(dbPassword, 0);
            saltValue.CopyTo(dbPassword, saltedPassword.Length);

            return dbPassword;
        }
        #endregion

        /// <summary>
        /// 读取一个节点的内容
        /// </summary>
        /// <param name="strFileName">文件路径</param>
        /// <param name="node">节点路劲  例activity/ad_1 ||  activity</param>
        /// <returns></returns>
        public static string ReadXml(string strFileName, string node)
        {
            XmlDocument objXmlDoc = new XmlDocument();
            objXmlDoc.Load(HttpContext.Current.Server.MapPath(strFileName));
            StringBuilder sb = new StringBuilder();
            XmlNode objNode = objXmlDoc.SelectSingleNode(node);
            if (objNode == null)
            {
                return "-1";
            }
            else
            {
                foreach (XmlNode node1 in objNode.ChildNodes)
                {
                    sb.Append(node1.InnerText);
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="content">需要解码的内容</param>
        /// <returns></returns>
        public static string DeCode(string content)
        {
            return HttpUtility.HtmlDecode(content);
        }

        /// <summary>
        /// 编码
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string EnCode(string content)
        {
            return HttpUtility.HtmlEncode(content);
        }

        /// <summary>
        /// 生成一个随机数唯一标识
        /// </summary>
        /// <param name="minLenght">最小长度</param>
        /// <param name="maxLengh">最大长度</param>
        /// <returns></returns>
        public static string CreateRandNum(int minLenght, int maxLengh)
        {
            var rd = new Random(Guid.NewGuid().GetHashCode());
            return rd.Next(minLenght, maxLengh).ToString();
        }

        /// <summary>
        /// 将字符串数组组合成一个路径。
        /// </summary>
        /// <param name="paths">由路径的各部分构成的数组。</param>
        /// <returns>返回 包含合并的路径的字符串。</returns>
        public static string PathCombine(params string[] paths)
        {
            if (paths.Length <= 0) return string.Empty;
            return Path.Combine(paths);
        }

        /// <summary>
        /// 时间格式转换format参数格式： yyyy格式MM格式dd格式 HH:mm:ss  如（yyyy年MM月dd日）
        /// </summary>
        /// <param name="obj">时间</param>
        /// <param name="format">类型</param>
        /// <returns></returns>
        public static string FormatDate(object obj, string format)
        {
            try
            {
                var date = Convert.ToDateTime(obj);
                string rtdate = date.ToString(format, DateTimeFormatInfo.InvariantInfo);
                if (rtdate.Contains("0001-01-01") || rtdate.Contains("0001/1/1"))
                    return string.Empty;
                return rtdate;
            }
            catch { return ""; }
        }


        /// <summary>
        /// 将对象转换为日期时间类型
        /// </summary>
        /// <param name="value">要转换的字符串</param>
        /// <returns>转换后的DateTime类型结果</returns>
        public static DateTime ConvertToDateTime(string value)
        {
            return ConvertToDateTime(value, DateTime.Now);
        }


        /// <summary>
        /// 将对象转换为日期时间类型
        /// </summary>
        /// <param name="value">要转换的字符串</param>
        /// <param name="defaultValue">缺省值</param>
        /// <returns>转换后的DateTime类型结果</returns>
        public static DateTime ConvertToDateTime(string value, DateTime defaultValue)
        {
            if (!string.IsNullOrEmpty(value))
            {
                DateTime dateTime;
                if (DateTime.TryParse(value, out dateTime))
                    return dateTime;
            }
            return defaultValue;
        }

        /// <summary>
        /// 将对象转换为Decimal类型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的Decimal类型结果</returns>
        public static Decimal ConvertToDecimal(string expression)
        {
            decimal d = 0;
            if (string.IsNullOrEmpty(expression)) return d;
            if (decimal.TryParse(expression, out d))
                return d;
            return d;
        }

        /// <summary>
        /// 将对象转换为Int32类型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static int ObjectToInt(object expression)
        {
            return ObjectToInt(expression, 0);
        }

        /// <summary>
        /// 将对象转换为Int32类型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static int ObjectToInt(object expression, int defValue)
        {
            if (expression != null)
                return StrToInt(expression.ToString(), defValue);

            return defValue;
        }

        /// <summary>
        /// 将对象转换为Int32类型
        /// </summary>
        /// <param name="str">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static int StrToInt(string str, int defValue)
        {
            if (string.IsNullOrEmpty(str) || str.Trim().Length >= 11 || !Regex.IsMatch(str.Trim(), @"^([-]|[0-9])[0-9]*(\.\w*)?$"))
                return defValue;

            int rv;
            if (Int32.TryParse(str, out rv))
                return rv;

            return Convert.ToInt32(StrToFloat(str, defValue));
        }

        /// <summary>
        /// string型转换为float型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static float StrToFloat(string strValue, float defValue)
        {
            if ((strValue == null) || (strValue.Length > 10))
                return defValue;

            float intValue = defValue;
            if (strValue != null)
            {
                bool IsFloat = Regex.IsMatch(strValue, @"^([-]|[0-9])[0-9]*(\.\w*)?$");
                if (IsFloat)
                    float.TryParse(strValue, out intValue);
            }
            return intValue;
        }

        /// <summary>
        /// 返回字符串真实长度, 1个汉字长度为2
        /// </summary>
        /// <returns>字符长度</returns>
        public static int GetStringLength(string str)
        {
            return Encoding.Default.GetBytes(str).Length;
        }

        /// <summary>
        /// 删除字符串尾部的回车/换行/空格
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RTrim(string str)
        {
            for (int i = str.Length; i >= 0; i--)
            {
                if (str[i].Equals(" ") || str[i].Equals("\r") || str[i].Equals("\n"))
                {
                    str.Remove(i, 1);
                }
            }
            return str;
        }

        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="obj">检测字符</param>
        /// <param name="length">指定长度</param>
        /// <param name="defaultStr">省略代替字符串</param>
        /// <returns></returns>
        public static string subStr(object obj, int length, string defaultStr)
        {
            var str1 = obj.ToString();
            var n = str1.Length;
            if (n <= length)
            {
                return str1;
            }
            str1 = str1.Substring(0, length) + defaultStr;
            return str1;
        }


        /// <summary>
        /// 从字符串的指定位置截取指定长度的子字符串
        /// </summary>
        /// <param name="str">原字符串</param>
        /// <param name="startIndex">子字符串的起始位置</param>
        /// <param name="length">子字符串的长度</param>
        /// <returns>子字符串</returns>
        public static string CutString(string str, int startIndex, int length)
        {
            if (startIndex >= 0)
            {
                if (length < 0)
                {
                    length = length * -1;
                    if (startIndex - length < 0)
                    {
                        length = startIndex;
                        startIndex = 0;
                    }
                    else
                        startIndex = startIndex - length;
                }

                if (startIndex > str.Length)
                    return "";
            }
            else
            {
                if (length < 0)
                    return "";
                else
                {
                    if (length + startIndex > 0)
                    {
                        length = length + startIndex;
                        startIndex = 0;
                    }
                    else
                        return "";
                }
            }

            if (str.Length - startIndex < length)
                length = str.Length - startIndex;

            return str.Substring(startIndex, length);
        }

        /// <summary>
        /// 从字符串的指定位置开始截取到字符串结尾的了符串
        /// </summary>
        /// <param name="str">原字符串</param>
        /// <param name="startIndex">子字符串的起始位置</param>
        /// <returns>子字符串</returns>
        public static string CutString(string str, int startIndex)
        {
            return CutString(str, startIndex, str.Length);
        }


        /// <summary>
        /// 获得当前绝对路径
        /// </summary>
        /// <param name="strPath">指定的路径</param>
        /// <returns>绝对路径</returns>
        public static string GetMapPath(string strPath)
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(strPath);
            }
            else //非web程序引用
            {
                strPath = strPath.Replace("/", "\\");
                if (strPath.StartsWith("\\"))
                {
                    strPath = strPath.Substring(strPath.IndexOf('\\', 1)).TrimStart('\\');
                }
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetStreamReader(string path)
        {
            string str = string.Empty;
            while (File.Exists(path))
            {
                return GetStreamReader(path, string.Empty);
            }
            return str;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string GetStreamReader(string path, string encoding)
        {
            string str = string.Empty;
            StreamReader reader = null;
            try
            {
                if (encoding.Trim() != string.Empty)
                {
                    reader = new StreamReader(path, Encoding.GetEncoding(encoding));
                }
                else
                {
                    reader = new StreamReader(path, Encoding.UTF8);
                }
                str = reader.ReadToEnd();
            }
            catch
            {
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
            return str;
        }

        /// <summary>
        /// 保存文件、写文件流  (false是覆盖 true：追加)
        /// </summary>
        /// <param name="strContent">写入的文件内容</param>
        /// <param name="filePath">要保存的文件路径 注：不包括文件名 例如："~/Template/"</param>
        /// <param name="fileName">保存的文件名</param>
        /// <param name="isAppend">是否覆盖 还是追加 注：(false是覆盖 true：追加)</param>
        /// <returns>true 成功、false 失败</returns>
        public static bool WriteStream(string strContent, string filePath, string fileName, bool isAppend)
        {
            StreamWriter streamWriter = null;
            bool flag;
            try
            {
                string _path = HttpContext.Current.Server.MapPath(filePath);
                if (!Directory.Exists(_path))//判断是否存在
                {
                    Directory.CreateDirectory(_path);//创建新路径
                }
                streamWriter = new StreamWriter(_path + fileName, isAppend, Encoding.UTF8);
                streamWriter.Write(strContent);
                streamWriter.Flush();
                flag = true;
            }
            catch
            {
                flag = false;
            }
            finally
            {
                if (streamWriter != null) streamWriter.Close();
            }
            return flag;
        }

        /// <summary>
        /// 返回文件是否存在
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <returns>是否存在</returns>
        public static bool FileExists(string filename)
        {
            return System.IO.File.Exists(filename);
        }

        /// <summary>
        /// 以指定的ContentType输出指定文件文件
        /// </summary>
        /// <param name="filepath">文件路径</param>
        /// <param name="filename">输出的文件名</param>
        /// <param name="filetype">将文件输出时设置的ContentType</param>
        public static void ResponseFile(string filepath, string filename, string filetype)
        {
            Stream iStream = null;

            // 缓冲区为10k
            byte[] buffer = new Byte[10000];
            // 文件长度
            int length;
            // 需要读的数据长度
            long dataToRead;

            try
            {
                // 打开文件
                iStream = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                // 需要读的数据长度
                dataToRead = iStream.Length;

                HttpContext.Current.Response.ContentType = filetype;
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + Utils.UrlEncode(filename.Trim()).Replace("+", " "));

                while (dataToRead > 0)
                {
                    // 检查客户端是否还处于连接状态
                    if (HttpContext.Current.Response.IsClientConnected)
                    {
                        length = iStream.Read(buffer, 0, 10000);
                        HttpContext.Current.Response.OutputStream.Write(buffer, 0, length);
                        HttpContext.Current.Response.Flush();
                        buffer = new Byte[10000];
                        dataToRead = dataToRead - length;
                    }
                    else
                    {
                        // 如果不再连接则跳出死循环
                        dataToRead = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("Error : " + ex.Message);
            }
            finally
            {
                if (iStream != null)
                {
                    // 关闭文件
                    iStream.Close();
                }
            }
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 判断文件名是否为浏览器可以直接显示的图片文件名
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <returns>是否可以直接显示</returns>
        public static bool IsImgFilename(string filename)
        {
            filename = filename.Trim();
            if (filename.EndsWith(".") || filename.IndexOf(".") == -1)
                return false;

            string extname = filename.Substring(filename.LastIndexOf(".") + 1).ToLower();
            return (extname == "jpg" || extname == "jpeg" || extname == "png" || extname == "bmp" || extname == "gif");
        }

        /// <summary>
        /// 检测是否符合email格式
        /// </summary>
        /// <param name="strEmail">要判断的email字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsValidEmail(string strEmail)
        {
            return Regex.IsMatch(strEmail, @"^[\w\.]+([-]\w+)*@[A-Za-z0-9-_]+[\.][A-Za-z0-9-_]");
        }

        public static bool IsValidDoEmail(string strEmail)
        {
            return Regex.IsMatch(strEmail, @"^@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        /// <summary>
        /// 检测是否是正确的Url
        /// </summary>
        /// <param name="strUrl">要验证的Url</param>
        /// <returns>判断结果</returns>
        public static bool IsURL(string strUrl)
        {
            return Regex.IsMatch(strUrl, @"^(http|https)\://([a-zA-Z0-9\.\-]+(\:[a-zA-Z0-9\.&%\$\-]+)*@)*((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|localhost|([a-zA-Z0-9\-]+\.)*[a-zA-Z0-9\-]+\.(com|edu|gov|int|mil|net|org|biz|arpa|info|name|pro|aero|coop|museum|[a-zA-Z]{1,10}))(\:[0-9]+)*(/($|[a-zA-Z0-9\.\,\?\'\\\+&%\$#\=~_\-]+))*$");
        }

        public static string GetEmailHostName(string strEmail)
        {
            if (strEmail.IndexOf("@") < 0)
            {
                return "";
            }
            return strEmail.Substring(strEmail.LastIndexOf("@")).ToLower();
        }

        /// <summary>
        /// 检测是否有Sql危险字符
        /// </summary>
        /// <param name="str">要判断字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsSafeSqlString(string str)
        {
            return !Regex.IsMatch(str, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
        }

        /// <summary>
        /// 检测是否有危险的可能用于链接的字符串
        /// </summary>
        /// <param name="str">要判断字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsSafeUserInfoString(string str)
        {
            return !Regex.IsMatch(str, @"^\s*$|^c:\\con\\con$|[%,\*" + "\"" + @"\s\t\<\>\&]|游客|^Guest");
        }

        /// <summary>
        /// 清理字符串
        /// </summary>
        public static string CleanInput(string strIn)
        {
            return Regex.Replace(strIn.Trim(), @"[^\w\.@-]", "");
        }

        /// <summary>
        /// 返回URL中结尾的文件名
        /// </summary>		
        public static string GetFilename(string url)
        {
            if (url == null)
            {
                return "";
            }
            string[] strs1 = url.Split(new char[] { '/' });
            return strs1[strs1.Length - 1].Split(new char[] { '?' })[0];
        }

        /// <summary>
        /// 返回标准日期格式string
        /// </summary>
        public static string GetDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 返回指定日期格式
        /// </summary>
        public static string GetDate(string datetimestr, string replacestr)
        {
            if (datetimestr == null)
                return replacestr;

            if (datetimestr.Equals(""))
                return replacestr;

            try
            {
                datetimestr = Convert.ToDateTime(datetimestr).ToString("yyyy-MM-dd").Replace("1900-01-01", replacestr);
            }
            catch
            {
                return replacestr;
            }
            return datetimestr;
        }


        /// <summary>
        /// 返回标准时间格式string
        /// </summary>
        public static string GetTime()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }

        /// <summary>
        /// 返回标准时间格式string
        /// </summary>
        public static string GetDateTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 返回相对于当前时间的相对天数
        /// </summary>
        public static string GetDateTime(int relativeday)
        {
            return DateTime.Now.AddDays(relativeday).ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 返回标准时间格式string
        /// </summary>
        public static string GetDateTimeF()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fffffff");
        }

        /// <summary>
        /// 返回标准时间 
        /// </sumary>
        public static string GetStandardDateTime(string fDateTime, string formatStr)
        {
            if (fDateTime == "0000-0-0 0:00:00")
                return fDateTime;
            DateTime time = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            if (DateTime.TryParse(fDateTime, out time))
                return time.ToString(formatStr);
            else
                return "N/A";
        }

        /// <summary>
        /// 返回标准时间 yyyy-MM-dd HH:mm:ss
        /// </sumary>
        public static string GetStandardDateTime(string fDateTime)
        {
            return GetStandardDateTime(fDateTime, "yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 返回标准时间 yyyy-MM-dd
        /// </sumary>
        public static string GetStandardDate(string fDate)
        {
            return GetStandardDateTime(fDate, "yyyy-MM-dd");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool IsTime(string timeval)
        {
            return Regex.IsMatch(timeval, @"^((([0-1]?[0-9])|(2[0-3])):([0-5]?[0-9])(:[0-5]?[0-9])?)$");
        }

        /// <summary>
        /// 返回 HTML 字符串的编码结果
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>编码结果</returns>
        public static string HtmlEncode(string str)
        {
            return HttpUtility.HtmlEncode(str);
        }

        /// <summary>
        /// 返回 HTML 字符串的解码结果
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>解码结果</returns>
        public static string HtmlDecode(string str)
        {
            return HttpUtility.HtmlDecode(str);
        }

        /// <summary>
        /// 返回 URL 字符串的编码结果
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>编码结果</returns>
        public static string UrlEncode(string str)
        {
            return HttpUtility.UrlEncode(str);
        }

        /// <summary>
        /// 返回 URL 字符串的编码结果
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>编码结果</returns>
        public static string UrlEncode(string str, Encoding encode)
        {
            return HttpUtility.UrlEncode(str, encode);
        }

        /// <summary>
        /// 返回 URL 字符串的解码结果
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>解码结果</returns>
        public static string UrlDecode(string str)
        {
            return HttpUtility.UrlDecode(str);
        }

        /// <summary>
        /// 返回 URL 字符串的解码结果
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>解码结果</returns>
        public static string UrlDecode(string str, Encoding encode)
        {
            return HttpUtility.UrlDecode(str, encode);
        }

        /// <summary>
        /// 返回相差的秒数
        /// </summary>
        /// <param name="Time"></param>
        /// <param name="Sec"></param>
        /// <returns></returns>
        public static int StrDateDiffSeconds(string Time, int Sec)
        {
            TimeSpan ts = DateTime.Now - DateTime.Parse(Time).AddSeconds(Sec);
            if (ts.TotalSeconds > int.MaxValue)
                return int.MaxValue;

            else if (ts.TotalSeconds < int.MinValue)
                return int.MinValue;

            return (int)ts.TotalSeconds;
        }

        /// <summary>
        /// 返回相差的分钟数
        /// </summary>
        /// <param name="time"></param>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public static int StrDateDiffMinutes(string time, int minutes)
        {
            if (Utils.StrIsNullOrEmpty(time))
                return 1;

            TimeSpan ts = DateTime.Now - DateTime.Parse(time).AddMinutes(minutes);
            if (ts.TotalMinutes > int.MaxValue)
                return int.MaxValue;
            else if (ts.TotalMinutes < int.MinValue)
                return int.MinValue;

            return (int)ts.TotalMinutes;
        }

        /// <summary>
        /// 返回相差的小时数
        /// </summary>
        /// <param name="time"></param>
        /// <param name="hours"></param>
        /// <returns></returns>
        public static int StrDateDiffHours(string time, int hours)
        {
            if (Utils.StrIsNullOrEmpty(time))
                return 1;

            TimeSpan ts = DateTime.Now - DateTime.Parse(time).AddHours(hours);
            if (ts.TotalHours > int.MaxValue)
                return int.MaxValue;
            else if (ts.TotalHours < int.MinValue)
                return int.MinValue;

            return (int)ts.TotalHours;
        }

        /// <summary>
        /// 建立文件夹
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool CreateDir(string name)
        {
            return Utils.MakeSureDirectoryPathExists(name);
        }

        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns>创建是否成功</returns>
        [DllImport("dbgHelp", SetLastError = true)]
        private static extern bool MakeSureDirectoryPathExists(string name);



        /// <summary>
        /// 移除Html标记
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string RemoveHtml(string content)
        {
            return Regex.Replace(content, @"<[^>]*>", string.Empty, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 字段串是否为Null或为""(空)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool StrIsNullOrEmpty(string str)
        {
            if (str == null || str.Trim() == string.Empty)
                return true;

            return false;
        }


        /// <summary>
        /// 判断是否是空数据(null或DBNull)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNothing(object value)
        {
            return value == null || value == DBNull.Value;
        }

        /// <summary>
        /// 判断是否是整数
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsInteger(string value)
        {
            if (string.IsNullOrEmpty(value)) return false;
            if (value[0] != '-' && !char.IsDigit(value[0])) return false;

            int i;
            return int.TryParse(value, out i);
        }


        /// <summary>
        /// 转换字符串为整型值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ConverToInt32(string value)
        {
            int v;
            if (!int.TryParse(value, out v))
            {
                v = 0;
            }
            return v;
        }

        /// <summary>
        /// 转换字符串为decimal
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal ConverToDecimal(string value)
        {
            decimal v;
            if (!decimal.TryParse(value, out v))
            {
                v = 0;
            }
            return v;
        }

        /// <summary>
        /// 转换字符串为布尔值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ConverToBoolean(string value)
        {
            if (value == "1" || string.Equals(value, Boolean.TrueString, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 字符串如果操过指定长度则将超出的部分用指定字符串代替
        /// </summary>
        /// <param name="p_SrcString">要检查的字符串</param>
        /// <param name="p_Length">指定长度</param>
        /// <param name="p_TailString">用于替换的字符串</param>
        /// <returns>截取后的字符串</returns>
        public static string GetSubString(string p_SrcString, int p_Length, string p_TailString)
        {
            return GetSubString(p_SrcString, 0, p_Length, p_TailString);
        }

        /// <summary>
        /// 取指定长度的字符串
        /// </summary>
        /// <param name="p_SrcString">要检查的字符串</param>
        /// <param name="p_StartIndex">起始位置</param>
        /// <param name="p_Length">指定长度</param>
        /// <param name="p_TailString">用于替换的字符串</param>
        /// <returns>截取后的字符串</returns>
        public static string GetSubString(string p_SrcString, int p_StartIndex, int p_Length, string p_TailString)
        {
            string myResult = p_SrcString;

            Byte[] bComments = Encoding.UTF8.GetBytes(p_SrcString);
            foreach (char c in Encoding.UTF8.GetChars(bComments))
            {    //当是日文或韩文时(注:中文的范围:\u4e00 - \u9fa5, 日文在\u0800 - \u4e00, 韩文为\xAC00-\xD7A3)
                if ((c > '\u0800' && c < '\u4e00') || (c > '\xAC00' && c < '\xD7A3'))
                {
                    //if (System.Text.RegularExpressions.Regex.IsMatch(p_SrcString, "[\u0800-\u4e00]+") || System.Text.RegularExpressions.Regex.IsMatch(p_SrcString, "[\xAC00-\xD7A3]+"))
                    //当截取的起始位置超出字段串长度时
                    if (p_StartIndex >= p_SrcString.Length)
                        return "";
                    else
                        return p_SrcString.Substring(p_StartIndex,
                                                       ((p_Length + p_StartIndex) > p_SrcString.Length) ? (p_SrcString.Length - p_StartIndex) : p_Length);
                }
            }

            if (p_Length >= 0)
            {
                byte[] bsSrcString = Encoding.Default.GetBytes(p_SrcString);

                //当字符串长度大于起始位置
                if (bsSrcString.Length > p_StartIndex)
                {
                    int p_EndIndex = bsSrcString.Length;

                    //当要截取的长度在字符串的有效长度范围内
                    if (bsSrcString.Length > (p_StartIndex + p_Length))
                    {
                        p_EndIndex = p_Length + p_StartIndex;
                    }
                    else
                    {   //当不在有效范围内时,只取到字符串的结尾

                        p_Length = bsSrcString.Length - p_StartIndex;
                        p_TailString = "";
                    }

                    int nRealLength = p_Length;
                    int[] anResultFlag = new int[p_Length];
                    byte[] bsResult = null;

                    int nFlag = 0;
                    for (int i = p_StartIndex; i < p_EndIndex; i++)
                    {
                        if (bsSrcString[i] > 127)
                        {
                            nFlag++;
                            if (nFlag == 3)
                                nFlag = 1;
                        }
                        else
                            nFlag = 0;

                        anResultFlag[i] = nFlag;
                    }

                    if ((bsSrcString[p_EndIndex - 1] > 127) && (anResultFlag[p_Length - 1] == 1))
                        nRealLength = p_Length + 1;

                    bsResult = new byte[nRealLength];

                    Array.Copy(bsSrcString, p_StartIndex, bsResult, 0, nRealLength);

                    myResult = Encoding.Default.GetString(bsResult);
                    myResult = myResult + p_TailString;
                }
            }

            return myResult;
        }



        #region JSON

        /// <summary>
        /// 将JSON数组整合到一个JSON字符串里面
        /// </summary>
        /// <param name="jsons"></param>
        /// <returns></returns>
        public static string JsonCombine(params string[] jsons)
        {
            StringBuilder sb = new System.Text.StringBuilder("");
            if (jsons.Length > 0)
            {
                if (jsons.Length == 1)
                {
                    sb.Append(jsons[0]);
                }
                else
                {
                    sb.Append("[");
                    int i = 0;
                    foreach (string item in jsons)
                    {
                        if (i > 0)
                        {
                            sb.Append(",");
                        }
                        sb.Append(item);
                        i++;
                    }
                    sb.Append("]");
                }
            }
            return sb.ToString();
        }


        /// <summary>
        /// 将JSON数组整合到一个JSON字符串里面
        /// </summary>
        /// <param name="jsons"></param>
        /// <returns></returns>
        public static string JsonCombine(string jsonName, params string[] jsons)
        {
            if (jsons.Length == 0) return "0";
            StringBuilder sb = new System.Text.StringBuilder("");
            sb.Append("{\"" + jsonName + "\":{");
            if (jsons.Length > 0)
            {
                if (jsons.Length == 1)
                {
                    sb.Append(jsons[0]);
                }
                else
                {
                    //sb.Append("[");
                    int i = 0;
                    foreach (string item in jsons)
                    {
                        if (i > 0)
                        {
                            sb.Append(",");
                        }
                        sb.Append(item);
                        i++;
                    }
                    // sb.Append("]");
                }
            }
            sb.Append("}}");
            return sb.ToString();
        }

        /// <summary>
        /// Datatable转换json
        /// </summary>
        /// <param name="dt">Datatable</param>
        /// <returns></returns>
        public static string DataTableToJson(DataTable dt)
        {
            StringBuilder Json = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                Json.Append("[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Json.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        Json.Append("\"" + dt.Columns[j].ColumnName.ToString().Trim() + "\":\"" + dt.Rows[i][j].ToString().Trim() + "\"");
                        if (j < dt.Columns.Count - 1)
                        {
                            Json.Append(",");
                        }
                    }
                    Json.Append("}");
                    if (i < dt.Rows.Count - 1)
                    {
                        Json.Append(",");
                    }
                }
                Json.Append("]");
            }
            else
            {
                Json.Append("");
            }
            return Json.ToString();
        }

        /// <summary>
        /// Datatable转换json
        /// </summary>
        /// <param name="jsonName">Json数据的根元素名称</param>
        /// <param name="dt">Datatable</param>
        /// <returns></returns>
        public static string DataTableToJson(string jsonName, DataTable dt)
        {
            StringBuilder Json = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                Json.Append("{\"" + jsonName + "\":[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Json.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        Json.Append("\"" + dt.Columns[j].ColumnName.ToString().Trim() + "\":\"" + dt.Rows[i][j].ToString().Trim() + "\"");
                        if (j < dt.Columns.Count - 1)
                        {
                            Json.Append(",");
                        }
                    }
                    Json.Append("}");
                    if (i < dt.Rows.Count - 1)
                    {
                        Json.Append(",");
                    }
                }
                Json.Append("]}");
            }
            else
            {
                Json.Append("0");
            }
            return Json.ToString();
        }



        /// <summary>
        /// Json特符字符过滤，参见http://www.json.org/
        /// </summary>
        /// <param name="sourceStr">要过滤的源字符串</param>
        /// <returns>返回过滤的字符串</returns>
        public static string JsonCharFilter(string sourceStr)
        {
            sourceStr = sourceStr.Replace("\\", "\\\\");
            sourceStr = sourceStr.Replace("\b", "\\\b");
            sourceStr = sourceStr.Replace("\t", "\\\t");
            sourceStr = sourceStr.Replace("\n", "\\\n");
            sourceStr = sourceStr.Replace("\n", "\\\n");
            sourceStr = sourceStr.Replace("\f", "\\\f");
            sourceStr = sourceStr.Replace("\r", "\\\r");
            return sourceStr.Replace("\"", "\\\"");
        }

        /// <summary>
        /// 对象序列化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ObjectToJson(object obj)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(obj);
        }

        /// <summary>
        /// 对象序列化
        /// </summary>
        /// <param name="jsonName">指定JSON name</param>
        /// <param name="obj">数据源</param>
        /// <returns></returns>
        public static string ObjectToJson(string jsonName, object obj)
        {
            StringBuilder output = new StringBuilder();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string json = jss.Serialize(obj);
            if (string.IsNullOrEmpty(json)) return "0";
            output.Append("{");
            output.Append("\"" + jsonName + "\":");
            output.Append(json);
            output.Append("}");
            return output.ToString();
        }

        /// <summary>
        /// 对象反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T JsonToObject<T>(string json)
        {
            try
            {
                if (!string.IsNullOrEmpty(json))
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    return js.Deserialize<T>(json);
                }
                return default(T);
            }
            catch (Exception ex)
            {
                throw new Exception("X2Jason.JsonToObj(): " + ex.Message);
            }
        }

        /// <summary>
        /// 对象反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static List<T> JsonToObjectList<T>(string json)
        {
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                List<T> objList = js.Deserialize<List<T>>(json);
                return objList;
            }
            catch (Exception ex)
            {
                throw new Exception("X2Jason.JsonToObj(): " + ex.Message);
            }
        }

        #endregion JSON






        #region 绑定Tree
        /// <summary>
        /// 根据给定的有树形结构的DataTable创建出Tree结构的字符串
        /// </summary>
        /// <param name="dt">数据集合</param>
        /// <param name="idfield">id字段名称</param>
        /// <param name="parentField">parent字段名称</param>
        /// <param name="textField">显示的文本字段名称</param>
        /// <param name="sortField">排序字段名称</param>
        /// <param name="sortType">排序类型 asc/desc</param>
        /// <param name="isEncode">是否进行解码 true:解码 false:不解码</param>
        /// <param name="isAllField">是否输出全部的字段</param>
        /// <returns></returns>
        public static DataTable CreateTreeToDataTable(DataTable dt, string idfield, string parentField, string textField, string sortField, string sortType, bool isEncode, bool isAllField)
        {
            return CreateTreeToDataTable(dt, idfield, parentField, textField, sortField, sortType, "0", isEncode, isAllField, true, true);
        }

        /// <summary>
        /// 根据给定的有树形结构的DataTable创建出Tree结构的字符串
        /// </summary>
        /// <param name="dt">数据集合</param>
        /// <param name="idfield">id字段名称</param>
        /// <param name="parentField">parent字段名称</param>
        /// <param name="textField">显示的文本字段名称</param>
        /// <param name="sortField">排序字段名称</param>
        /// <param name="sortType">排序类型 asc/desc</param>
        /// <param name="isEncode">是否进行解码 true:解码 false:不解码</param>
        /// <param name="isAllField">是否输出全部的字段</param>
        /// <param name="isIconPrefix">图标是否含前缀</param>
        /// <returns></returns>
        public static DataTable CreateTreeToDataTable(DataTable dt, string idfield, string parentField, string textField, string sortField, string sortType, bool isEncode, bool isAllField, bool isIconPrefix)
        {
            return CreateTreeToDataTable(dt, idfield, parentField, textField, sortField, sortType, "0", isEncode, isAllField, isIconPrefix, true);
        }

        /// <summary>
        /// 根据给定的有树形结构的DataTable创建出Tree结构的字符串
        /// </summary>
        /// <param name="dt">数据集合</param>
        /// <param name="idfield">id字段名称</param>
        /// <param name="parentField">parent字段名称</param>
        /// <param name="textField">显示的文本字段名称</param>
        /// <param name="sortField">排序字段名称</param>
        /// <param name="sortType">排序类型 asc/desc</param>
        /// <param name="isEncode">是否进行解码 true:解码 false:不解码</param>
        /// <param name="isAllField">是否输出全部的字段</param>
        /// <param name="isIconPrefix">图标是否含前缀</param>
        /// <param name="isIconConcatName">图标是否与name字段拼接在一起</param>
        /// <returns></returns>
        public static DataTable CreateTreeToDataTable(DataTable dt, string idfield, string parentField, string textField, string sortField, string sortType, bool isEncode, bool isAllField, bool isIconPrefix, bool isIconConcatName)
        {
            return CreateTreeToDataTable(dt, idfield, parentField, textField, sortField, sortType, "0", isEncode, isAllField, isIconPrefix, isIconConcatName);
        }

        /// <summary>
        /// 根据给定的有树形结构的DataTable创建出Tree结构的字符串
        /// </summary>
        /// <param name="dt">数据集合</param>
        /// <param name="idfield">id字段名称</param>
        /// <param name="parentField">parent字段名称</param>
        /// <param name="textField">显示的文本字段名称</param>
        /// <param name="sortField">排序字段名称</param>
        /// <param name="sortType">排序类型 asc/desc</param>
        /// <param name="parentId">当前parentId的值</param>
        /// <param name="isEncode">是否进行解码 true:解码 false:不解码</param>
        /// <param name="isAllField">是否输出全部的字段</param>
        /// <param name="isIconPrefix">图标是否含前缀</param>
        /// <param name="isIconConcatName">图标是否与name字段拼接在一起</param>
        /// <returns></returns>
        public static DataTable CreateTreeToDataTable(DataTable dt, string idfield, string parentField, string textField, string sortField, string sortType, string parentId, bool isEncode, bool isAllField, bool isIconPrefix, bool isIconConcatName)
        {
            DataTable dtTree = new DataTable();
            if (isAllField)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    dtTree.Columns.Add(dc.ColumnName, dc.DataType);
                }
            }
            else
            {
                dtTree.Columns.Add(idfield, typeof(string));
                dtTree.Columns.Add(textField, typeof(string));
            }
            dtTree.Columns.Add("IconPrefix", typeof(string));

            CreateTreeToDataTable(dt, idfield, parentField, textField, sortField, sortType, 0, parentId, isEncode, isAllField, isIconPrefix, isIconConcatName, ref  dtTree);
            return dtTree;
        }


        /// <summary>
        /// 根据给定的有树形结构的DataTable创建出Tree结构的字符串，递归函数
        /// </summary>
        /// <param name="dt">数据集合</param>
        /// <param name="idfield">id字段名称</param>
        /// <param name="parentField">parent字段名称</param>
        /// <param name="textField">显示的文本字段名称</param>
        /// <param name="sortField">排序字段名称</param>
        /// <param name="sortType">排序类型 asc/desc</param>
        /// <param name="loopCount">递归深度</param>
        /// <param name="parentValue">当前parentId的值</param>
        /// <param name="isEncode">是否进行解码 true:解码 false:不解码</param>
        /// <param name="isAllField">是否输出全部的字段</param>
        /// <param name="isIconPrefix">图标是否含前缀</param>
        /// <param name="isIconConcatName">图标是否与name字段拼接在一起</param>
        /// <param name="dtTree">输入的Tree型DataTable</param>
        public static void CreateTreeToDataTable(DataTable dt, string idfield, string parentField, string textField, string sortField, string sortType, int loopCount, string parentValue, bool isEncode, bool isAllField, bool isIconPrefix, bool isIconConcatName, ref DataTable dtTree)
        {
            DataTable dataSource = dt.Copy();
            DataView dv = dataSource.DefaultView;
            dv.RowFilter = string.Format("{0}='{1}'", parentField, parentValue);
            if (!string.IsNullOrEmpty(sortField))
            {
                if (string.IsNullOrEmpty(sortType))
                    sortType = "asc";
                dv.Sort = string.Format("{0} {1}", sortField, sortType);
            }
            StringBuilder sbSpare = new StringBuilder("");
            if (loopCount > 0)
            {
                for (int i = 0; i < loopCount; i++)
                {
                    if (isEncode)
                        sbSpare.Append(HtmlEncode("&#160;&#160;&#160;&#160;&#160;&#160;"));
                    else
                        sbSpare.Append("&#160;&#160;&#160;&#160;&#160;&#160;");
                }
            }
            if (isIconPrefix)
                sbSpare.Append("|--");

            DataTable dtTemp = dv.ToTable();
            foreach (DataRow dr in dtTemp.Rows)
            {
                DataRow drTreeRow = dtTree.NewRow();
                if (isAllField)
                {
                    foreach (DataColumn dc in dtTemp.Columns)
                    {
                        if (dc.ColumnName == textField)
                        {
                            if (isIconConcatName)
                                drTreeRow[textField] = HtmlDecode(sbSpare.ToString()) + dr[textField];
                            else
                                drTreeRow[textField] = dr[textField];
                        }
                        else
                        {
                            drTreeRow[dc.ColumnName] = dr[dc.ColumnName];
                        }
                    }
                }
                else
                {
                    drTreeRow[idfield] = dr[idfield];
                    if (isIconConcatName)
                        drTreeRow[textField] = HtmlDecode(sbSpare.ToString()) + dr[textField];
                    else
                        drTreeRow[textField] = dr[textField];
                }
                drTreeRow["IconPrefix"] = HtmlDecode(sbSpare.ToString());

                dtTree.Rows.Add(drTreeRow);

                CreateTreeToDataTable(dt, idfield, parentField, textField, sortField, sortType, loopCount + 1, dr[idfield].ToString(), isEncode, isAllField, isIconPrefix, isIconConcatName, ref dtTree);
            }
        }



        /// <summary>
        /// 根据给定的有树形结构的DataTable创建出Tree结构的字符串
        /// </summary>
        /// <param name="dt">数据源</param>
        /// <param name="idfield">id字段名称</param>
        /// <param name="parentField">上级字段名称</param>
        /// <param name="textField">显示的文本字段名称</param>
        /// <param name="sortField">排序字段名称</param>
        /// <param name="sortType">排序类型：asc、desc</param>
        public static string CreateHtmlSelectTree(DataTable dt, string idfield, string parentField, string textField, string sortField, string sortType)
        {
            StringBuilder sb = new System.Text.StringBuilder("");
            CreateHtmlSelectTree(dt, idfield, parentField, textField, sortField, sortType, 0, "0", ref  sb);
            return sb.ToString();
        }

        /// <summary>
        /// 创建Tree的递归函数
        /// </summary>
        /// <param name="dt">数据源</param>
        /// <param name="idfield">id字段名称</param>
        /// <param name="parentField">上级字段名称</param>
        /// <param name="textField">显示的文本字段名称</param>
        /// <param name="sortField">排序字段名称</param>
        /// <param name="sortType">排序类型：asc、desc</param>
        /// <param name="loopCount">默认值为0</param>
        /// <param name="parentValue">默认值为0</param>
        /// <param name="sb">返回的Tree字符串</param>
        public static void CreateHtmlSelectTree(DataTable dt, string idfield, string parentField, string textField, string sortField, string sortType, int loopCount, string parentValue, ref StringBuilder sb)
        {
            DataTable dataSource = dt.Copy();
            DataView dv = dataSource.DefaultView;
            dv.RowFilter = string.Format("{0}='{1}'", parentField, parentValue);
            if (!string.IsNullOrEmpty(sortField))
            {
                if (string.IsNullOrEmpty(sortType))
                    sortType = "asc";
                dv.Sort = string.Format("{0} {1}", sortField, sortType);
            }
            StringBuilder sbSpare = new StringBuilder("");
            if (loopCount > 0)
            {
                for (int i = 0; i < loopCount; i++)
                {
                    sbSpare.Append("&#160;&#160;&#160;&#160;");
                }
            }
            sbSpare.Append("|--");

            foreach (DataRow dr in dv.ToTable().Rows)
            {
                sb.Append("<option value='" + dr[idfield] + "'>" + sbSpare.ToString() + dr[textField] + "</option>");
                CreateHtmlSelectTree(dt, idfield, parentField, textField, sortField, sortType, loopCount + 1, dr[idfield].ToString(), ref sb);
            }
        }
        #endregion 绑定Tree

        #region 绑定Ztree
        /// <summary>
        /// 组装Ztree字符串
        /// </summary>
        /// <param name="dt">数据源</param>
        /// <param name="idfield">id字段名称</param>
        /// <param name="parentField">parent id 字段名称</param>
        /// <param name="textField">显示的文本内容</param>
        /// <param name="sortField">排序字段名称</param>
        /// <param name="sortType">排序类型 asc|desc</param>
        /// <param name="loopCount">loop ++</param>
        /// <param name="parentValue">上级 值</param>
        /// <param name="sbZtree">ref ztree StringBuilder</param>
        public static void CreateZtree(DataTable dt, string idfield, string parentField, string textField, string sortField, string sortType, string parentValue, ref StringBuilder sbZtree)
        {
            CreateZtree(dt, idfield, parentField, textField, sortField, sortType, parentValue, string.Empty, string.Empty, ref sbZtree);
        }

        /// <summary>
        /// 组装Ztree字符串
        /// </summary>
        /// <param name="dt">数据源</param>
        /// <param name="idfield">id字段名称</param>
        /// <param name="parentField">parent id 字段名称</param>
        /// <param name="textField">显示的文本内容</param>
        /// <param name="sortField">排序字段名称</param>
        /// <param name="sortType">排序类型 asc|desc</param>
        /// <param name="loopCount">loop ++</param>
        /// <param name="parentValue">上级 值</param>
        /// <param name="url">链接sAddress</param>
        /// <param name="target">目标框架</param>
        /// <param name="sbZtree">ref ztree StringBuilder</param>
        public static void CreateZtree(DataTable dt, string idfield, string parentField, string textField, string sortField, string sortType, string parentValue, string url, string target, ref StringBuilder sbZtree)
        {
            CreateZtree(dt, idfield, parentField, textField, sortField, sortType, parentValue, url, target, string.Empty, ref sbZtree);
        }

        /// <summary>
        /// 组装Ztree字符串
        /// </summary>
        /// <param name="dt">数据源</param>
        /// <param name="idfield">id字段名称</param>
        /// <param name="parentField">parent id 字段名称</param>
        /// <param name="textField">显示的文本内容</param>
        /// <param name="sortField">排序字段名称</param>
        /// <param name="sortType">排序类型 asc|desc</param>
        /// <param name="loopCount">loop ++</param>
        /// <param name="parentValue">上级 值</param>
        /// <param name="url">链接sAddress</param>
        /// <param name="target">目标框架</param>
        /// <param name="icon">图标sAddress</param>
        /// <param name="sbZtree">ref ztree StringBuilder</param>
        public static void CreateZtree(DataTable dt, string idfield, string parentField, string textField, string sortField, string sortType, string parentValue, string url, string target, string icon, ref StringBuilder sbZtree)
        {
            CreateZtree(dt, idfield, parentField, textField, sortField, sortType, 0, parentValue, url, target, icon, ref sbZtree);
        }


        /// <summary>
        /// 组装Ztree字符串
        /// </summary>
        /// <param name="dt">数据源</param>
        /// <param name="idfield">id字段名称</param>
        /// <param name="parentField">parent id 字段名称</param>
        /// <param name="textField">显示的文本内容</param>
        /// <param name="sortField">排序字段名称</param>
        /// <param name="sortType">排序类型 asc|desc</param>
        /// <param name="loopCount">loop ++</param>
        /// <param name="parentValue">上级 值</param>
        /// <param name="url">链接sAddress</param>
        /// <param name="target">目标框架</param>
        /// <param name="icon">图标sAddress</param>
        /// <param name="sbZtree">ref ztree StringBuilder</param>
        public static void CreateZtree(DataTable dt, string idfield, string parentField, string textField, string sortField, string sortType, int loopCount, string parentValue, string url, string target, string icon, ref StringBuilder sbZtree)
        {
            DataTable dataSource = dt.Copy();
            DataView dv = dataSource.DefaultView;
            dv.RowFilter = string.Format("{0}='{1}'", parentField, parentValue);
            if (!string.IsNullOrEmpty(sortField))
            {
                if (string.IsNullOrEmpty(sortType))
                    sortType = "asc";
                dv.Sort = string.Format("{0} {1}", sortField, sortType);
            }
            DataTable dtTemp = dv.ToTable();
            foreach (DataRow dr in dtTemp.Rows)
            {
                if (loopCount > 0)
                {
                    sbZtree.Append(",");
                }
                sbZtree.Append("{ id: '" + dr[idfield] + "', pId: '" + dr[parentField] + "', name: \"" + dr[textField] + "\"");


                if (!string.IsNullOrEmpty(url))
                    sbZtree.AppendFormat(", url: '{0}'", dr[url]);

                if (!string.IsNullOrEmpty(target))
                    sbZtree.AppendFormat(", target: '{0}'", target);

                if (!string.IsNullOrEmpty(icon))
                    sbZtree.AppendFormat(", icon: '{0}'", dr[icon]);

                sbZtree.Append("}");

                loopCount += 1;
                CreateZtree(dt, idfield, parentField, textField, sortField, sortType, loopCount, dr[idfield].ToString(), url, target, icon, ref sbZtree);
            }
        }
        #endregion 绑定Ztree








        /// <summary>
        /// 比较两个控件时间的大小
        /// </summary>
        /// <param name="hi1">控件1</param>
        /// <param name="hi2">控件2</param>
        /// <param name="flag">flag=1比较的时间含时分秒；flag=2比较的时间不含时分秒</param>
        /// <returns>如果控件1的时间早于控件2的时间则返回true</returns>
        public static Boolean TimeCompare(HtmlInputText hi1, HtmlInputText hi2, int flag)
        {
            try
            {
                if (flag == 1)
                {
                    if (ConvertToDateTime(hi1.Value).ToString("yyyy-MM-dd").CompareTo(ConvertToDateTime(hi2.Value).ToString("yyyy-MM-dd")) < 0)
                    {
                        return true;
                    }
                    return false;
                }
                else if (flag == 2)
                {
                    if (ConvertToDateTime(hi1.Value).CompareTo(ConvertToDateTime(hi2.Value)) < 0)
                    {
                        return true;
                    }
                    return false;
                }
                else
                {
                    throw new Exception("传递的参数已溢出");
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }

        }




        /// <summary>
        /// 获取当前请求页面的pIdx参数值
        /// </summary>
        /// <returns></returns>
        public static int GetPagerIndex()
        {
            object obj = HttpContext.Current.Request["pIdx"];
            if (obj != null)
            {
                int pIdx = ConverToInt32(obj.ToString());
                if (pIdx < 1)
                    return 1;
                else
                    return pIdx;
            }
            return 1;
        }


        /// <summary>
        /// 判断当前路径是否是文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsFile(string path)
        {
            if (File.Exists(path))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 判断当前路径是否是目录
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 将查询字符串解析转换为名值集合.
        /// </summary>
        /// <param name="queryString"></param>
        /// <param name="encoding"></param>
        /// <param name="isEncoded"></param>
        /// <returns></returns>
        public static NameValueCollection GetQueryString(string queryString, Encoding encoding, bool isEncoded)
        {
            queryString = queryString.Replace("?", "");
            NameValueCollection result = new NameValueCollection(StringComparer.OrdinalIgnoreCase);
            if (!string.IsNullOrEmpty(queryString))
            {
                int count = queryString.Length;
                for (int i = 0; i < count; i++)
                {
                    int startIndex = i;
                    int index = -1;
                    while (i < count)
                    {
                        char item = queryString[i];
                        if (item == '=')
                        {
                            if (index < 0)
                            {
                                index = i;
                            }
                        }
                        else if (item == '&')
                        {
                            break;
                        }
                        i++;
                    }
                    string key = null;
                    string value = null;
                    if (index >= 0)
                    {
                        key = queryString.Substring(startIndex, index - startIndex);
                        value = queryString.Substring(index + 1, (i - index) - 1);
                    }
                    else
                    {
                        key = queryString.Substring(startIndex, i - startIndex);
                    }
                    if (isEncoded)
                    {
                        result[MyUrlDeCode(key, encoding)] = MyUrlDeCode(value, encoding);
                    }
                    else
                    {
                        result[key] = value;
                    }
                    if ((i == (count - 1)) && (queryString[i] == '&'))
                    {
                        result[key] = string.Empty;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 解码URL.
        /// </summary>
        /// <param name="encoding">null为自动选择编码</param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MyUrlDeCode(string str, Encoding encoding)
        {
            if (encoding == null)
            {
                Encoding utf8 = Encoding.UTF8;
                //首先用utf-8进行解码                     
                string code = HttpUtility.UrlDecode(str.ToUpper(), utf8);
                //将已经解码的字符再次进行编码.
                string encode = HttpUtility.UrlEncode(code, utf8).ToUpper();
                if (str == encode)
                    encoding = Encoding.UTF8;
                else
                    encoding = Encoding.GetEncoding("gb2312");
            }
            return HttpUtility.UrlDecode(str, encoding);
        }



        /// <summary>
        ///  反序列化一个对象
        /// </summary>
        /// <param name="type"></param>
        /// <param name="strObject"></param>
        /// <returns>序列化后的对象</returns>
        public static object Deserialize(Type type, string strObject)
        {
            using (XmlReader reader = XmlReader.Create(new StringReader(strObject)))
            {
                XmlSerializer serializer = new XmlSerializer(type);

                return serializer.Deserialize(reader);
            }
        }


        /// <summary>
        /// 验证是否为标准的手机号码
        /// </summary>
        /// <param name="phoneNo">待验证的手机号码</param>
        /// <returns>true:为正确的手机号码</returns>
        public static bool CheckIsMobilePhone(string phoneNo)
        {
            return Regex.IsMatch(phoneNo, @"^1[3|5|8|4|7][0-9]\d{4,8}$");
        }






        /// <summary>
        /// 获取POST过来的参数，并以“参数名=参数值”的形式组成数组
        /// </summary>
        /// <returns>request回来的信息组成的数组</returns>
        protected SortedDictionary<string, string> GetRequestPost()
        {
            System.Web.HttpContext.Current.Request.Form.ToString();

            int i = 0;
            SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
            NameValueCollection coll;
            //Load Form variables into NameValueCollection variable.
            coll = System.Web.HttpContext.Current.Request.Form;

            // Get names of all forms into a string array.
            String[] requestItem = coll.AllKeys;

            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], System.Web.HttpContext.Current.Request.Form[requestItem[i]]);
            }
            return sArray;
        }



        /// <summary>
        /// 获取GET过来的消息，并以“参数名=参数值”的形式组成数组
        /// </summary>
        /// <returns>request回来的信息组成的数组</returns>
        public SortedDictionary<string, string> GetRequestGet()
        {
            int i = 0;
            SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
            NameValueCollection coll;
            //Load Form variables into NameValueCollection variable.
            coll = System.Web.HttpContext.Current.Request.QueryString;

            // Get names of all forms into a string array.
            String[] requestItem = coll.AllKeys;

            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], System.Web.HttpContext.Current.Request.QueryString[requestItem[i]]);
            }
            return sArray;
        }


        #region Excel导出
        /// <summary>
        /// Excel导出
        /// </summary>
        /// <param name="excelCaption">导出的Caption集合</param>
        /// <param name="dt"></param>
        public static void ExcelExport(string[] excelCaption, DataTable dt)
        {

        }

        #endregion Excel导出


        /// <summary>
        /// 计较两个日期的差
        /// </summary>
        /// <param name="howtocompare">格式y-年,m-月,d-日,h-时,minute-分,second-秒</param>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <returns>返回差</returns>
        public static int DateDiff(string howtocompare, System.DateTime startDate, System.DateTime endDate)
        {
            double diff = 0;
            System.TimeSpan TS = new System.TimeSpan(endDate.Ticks - startDate.Ticks);

            switch (howtocompare.ToLower())
            {
                case "y":
                    diff = Convert.ToDouble(TS.TotalDays / 365);
                    break;
                case "m":
                    diff = Convert.ToDouble((TS.TotalDays / 365) * 12);
                    break;
                case "d":
                    diff = Convert.ToDouble(TS.TotalDays);
                    break;
                case "h":
                    diff = Convert.ToDouble(TS.TotalHours);
                    break;
                case "minute":
                    diff = Convert.ToDouble(TS.TotalMinutes);
                    break;
                case "second":
                    diff = Convert.ToDouble(TS.TotalSeconds);
                    break;
            }

            return (int)diff;
        }



        /// <summary>
        /// http 请求  Get
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <returns></returns>
        public static string HttpGetRequest(string url)
        {
            return HttpRequest(url, RequestType.GET, "");
        }

        /// <summary>
        /// http 请求  Get
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="param">请求参数</param>
        /// <returns></returns>
        public static string HttpPostRequest(string url, string param)
        {
            return HttpRequest(url, RequestType.POST, param);
        }

        /// <summary>
        /// http 请求  Get/Post
        /// </summary>
        /// <param name="url">请求路径</param>
        /// <param name="requestType">Get/Post</param>
        /// <param name="param">Post 请求参数</param>
        /// <returns></returns>
        private static string HttpRequest(string url, RequestType enumType, string param)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = enumType.ToString();

            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "*/*";
            request.Timeout = 15000;
            request.AllowAutoRedirect = false;

            StreamWriter requestStream = null;
            WebResponse response = null;
            string responseStr = null;

            try
            {
                if (enumType == RequestType.POST)
                {
                    requestStream = new StreamWriter(request.GetRequestStream());
                    requestStream.Write(param);
                    requestStream.Close();
                }
                response = request.GetResponse();
                if (response != null)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    responseStr = reader.ReadToEnd();
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                return string.Empty;
            }
            finally
            {
                request = null;
                requestStream = null;
                response = null;
            }
            return responseStr;
        }


        #region DES加解密
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="text">加密文本</param>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        public static string DESEncrypt(string text, string key)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.GetEncoding("UTF-8").GetBytes(text);
            byte[] a = ASCIIEncoding.ASCII.GetBytes(key);
            des.Key = ASCIIEncoding.ASCII.GetBytes(key);
            des.IV = ASCIIEncoding.ASCII.GetBytes(key);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);//将第一个参数转换为十六进制数,长度为2,不足前面补0
            }
            return ret.ToString();
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="cyphertext">解密文本</param>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        public static string DESDecrypt(string cyphertext, string key)
        {
            if (string.IsNullOrEmpty(cyphertext))
                return string.Empty;
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = new byte[cyphertext.Length / 2];
            for (int x = 0; x < cyphertext.Length / 2; x++)
            {
                int i = (Convert.ToInt32(cyphertext.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }
            des.Key = ASCIIEncoding.ASCII.GetBytes(key);
            des.IV = ASCIIEncoding.ASCII.GetBytes(key);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            return System.Text.Encoding.GetEncoding("UTF-8").GetString(ms.ToArray());
        }
        #endregion

        private const double EARTH_RADIUS = 6378.137;//地球半径
        private static double rad(double d)
        {
            return d * Math.PI / 180.0;
        }
        public static double GetDistance(double lat1, double lng1, double lat2, double lng2)
        {
            double radLat1 = rad(lat1);
            double radLat2 = rad(lat2);
            double a = radLat1 - radLat2;
            double b = rad(lng1) - rad(lng2);

            double s = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) +
             Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2)));
            s = s * EARTH_RADIUS;
            s = Math.Round(s * 10000) / 10000;
            return s;
        }


        /// <summary>
        /// 图片转换Base64
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray(); // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        /// <summary>
        /// 将c# DateTime时间格式转换为Unix时间戳格式
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns>long</returns>
        public static long ConvertDateTime2Long(System.DateTime time)
        {
            DateTime timeStamp = new DateTime(1970, 1, 1); //得到1970年的时间戳
            long a = (time.ToUniversalTime().Ticks - timeStamp.Ticks) / 10000000; //注意这里有时区问题，用now就要减掉8个小时
            return a;
        }

        /// <summary>  
        /// Base64加密  
        /// </summary>  
        /// <param name="Message"></param>  
        /// <returns></returns>  
        public static string Base64Code(string Message)
        {
            byte[] bytes = Encoding.Default.GetBytes(Message);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>  
        /// Base64解密  
        /// </summary>  
        /// <param name="Message"></param>  
        /// <returns></returns>  
        public static string Base64Decode(string Message)
        {
            byte[] bytes = Convert.FromBase64String(Message);
            return Encoding.Default.GetString(bytes);
        }


        #region 反序列化
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="xml">XML字符串</param>
        /// <returns></returns>
        public static T XMLDeserialize<T>(string xml)
        {
            try
            {
                using (StringReader sr = new StringReader(xml))
                {
                    XmlSerializer xmldes = new XmlSerializer(typeof(T));
                    return (T)xmldes.Deserialize(sr);
                }
            }
            catch (Exception e)
            {

                return default(T);
            }
        }
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type"></param>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static object XMLDeserialize(Type type, Stream stream)
        {
            XmlSerializer xmldes = new XmlSerializer(type);
            return xmldes.Deserialize(stream);
        }
        #endregion

        #region 序列化
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static string XMLSerializer(Type type, object obj)
        {
            MemoryStream Stream = new MemoryStream();
            XmlSerializer xml = new XmlSerializer(type);
            try
            {
                //序列化对象
                xml.Serialize(Stream, obj);
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            Stream.Position = 0;
            StreamReader sr = new StreamReader(Stream);
            string str = sr.ReadToEnd();

            sr.Dispose();
            Stream.Dispose();

            return str;
        }

        public static string parseXML(Dictionary<string, string> parameters)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<xml>");
            foreach (string k in parameters.Keys)
            {
                string v = (string)parameters[k];
                if (Regex.IsMatch(v, @"^[0-9.]$"))
                {

                    sb.Append("<" + k + ">" + v + "</" + k + ">");
                }
                else
                {
                    sb.Append("<" + k + "><![CDATA[" + v + "]]></" + k + ">");
                }

            }
            sb.Append("</xml>");
            return sb.ToString();
        }

        #endregion




        /// <summary>
        /// 输入一段文字，返回一张二维码的图片
        /// </summary>
        /// <param name="strData"></param>
        /// <returns></returns>
        public static Image GetCodeEncoder(string strData)
        {
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeScale = 6;
            qrCodeEncoder.QRCodeVersion = 6;
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
            Image image = qrCodeEncoder.Encode(strData);
            return image;
        }

        /// <summary>
        /// 获取制定长度随机字符串
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GetRandomStr(int length)
        {
            Random rd = new Random();
            string str = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                result.Append(str[rd.Next(str.Length)]);
            }
            return result.ToString();
        }


        /// <summary>
        /// 压缩多层目录
        /// </summary>
        /// <param name="strDirectory">The directory.</param>
        /// <param name="zipedFile">The ziped file.</param>
        public static void ZipFileDirectory(string strDirectory, string zipedFile)
        {
            using (System.IO.FileStream ZipFile = System.IO.File.Create(zipedFile))
            {
                using (ZipOutputStream s = new ZipOutputStream(ZipFile))
                {
                    ZipSetp(strDirectory, s, "");
                }
            }
        }

        /// <summary>
        /// 递归遍历目录
        /// </summary>
        /// <param name="strDirectory">The directory.</param>
        /// <param name="s">The ZipOutputStream Object.</param>
        /// <param name="parentPath">The parent path.</param>
        private static void ZipSetp(string strDirectory, ZipOutputStream s, string parentPath)
        {
            if (strDirectory[strDirectory.Length - 1] != Path.DirectorySeparatorChar)
            {
                strDirectory += Path.DirectorySeparatorChar;
            }
            Crc32 crc = new Crc32();

            string[] filenames = Directory.GetFileSystemEntries(strDirectory);

            foreach (string file in filenames)// 遍历所有的文件和目录
            {

                if (Directory.Exists(file))// 先当作目录处理如果存在这个目录就递归Copy该目录下面的文件
                {
                    string pPath = parentPath;
                    pPath += file.Substring(file.LastIndexOf("\\") + 1);
                    pPath += "\\";
                    ZipSetp(file, s, pPath);
                }

                else // 否则直接压缩文件
                {
                    //打开压缩文件
                    using (FileStream fs = File.OpenRead(file))
                    {

                        byte[] buffer = new byte[fs.Length];
                        fs.Read(buffer, 0, buffer.Length);

                        string fileName = parentPath + file.Substring(file.LastIndexOf("\\") + 1);
                        ZipEntry entry = new ZipEntry(fileName)
                        {
                            DateTime = DateTime.Now,
                            Size = fs.Length
                        };

                        fs.Close();

                        crc.Reset();
                        crc.Update(buffer);

                        entry.Crc = crc.Value;
                        s.PutNextEntry(entry);

                        s.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }

        /// <summary>
        /// 解压缩一个 zip 文件。
        /// </summary>
        /// <param name="zipedFile">The ziped file.</param>
        /// <param name="strDirectory">The STR directory.</param>
        /// <param name="password">zip 文件的密码。</param>
        /// <param name="overWrite">是否覆盖已存在的文件。</param>
        public void UnZip(string zipedFile, string strDirectory, string password, bool overWrite)
        {

            if (strDirectory == "")
                strDirectory = Directory.GetCurrentDirectory();
            if (!strDirectory.EndsWith("\\"))
                strDirectory = strDirectory + "\\";

            using (ZipInputStream s = new ZipInputStream(File.OpenRead(zipedFile)))
            {
                s.Password = password;
                ZipEntry theEntry;

                while ((theEntry = s.GetNextEntry()) != null)
                {
                    string directoryName = "";
                    string pathToZip = "";
                    pathToZip = theEntry.Name;

                    if (pathToZip != "")
                        directoryName = Path.GetDirectoryName(pathToZip) + "\\";

                    string fileName = Path.GetFileName(pathToZip);

                    Directory.CreateDirectory(strDirectory + directoryName);

                    if (fileName != "")
                    {
                        if ((File.Exists(strDirectory + directoryName + fileName) && overWrite) || (!File.Exists(strDirectory + directoryName + fileName)))
                        {
                            using (FileStream streamWriter = File.Create(strDirectory + directoryName + fileName))
                            {
                                int size = 2048;
                                byte[] data = new byte[2048];
                                while (true)
                                {
                                    size = s.Read(data, 0, data.Length);

                                    if (size > 0)
                                        streamWriter.Write(data, 0, size);
                                    else
                                        break;
                                }
                                streamWriter.Close();
                            }
                        }
                    }
                }

                s.Close();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static float DecimalToFloat(decimal p)
        {
            return float.Parse(p.ToString());
        }


        /// <summary>
        /// Unicode编码
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static string StringToUnicode(string text)
        {
            /*string dst = "";
            char[] src = p.ToCharArray();
            for (int i = 0; i < src.Length; i++)
            {
                byte[] bytes = Encoding.Unicode.GetBytes(src[i].ToString());
                string str = @"\u" + bytes[1].ToString("X2") + bytes[0].ToString("X2");
                dst += str;
            }
            return dst;*/

            string result = "";
            for (int i = 0; i < text.Length; i++)
            {
                if ((int)text[i] > 32 && (int)text[i] < 127)
                {
                    result += text[i].ToString();
                }
                else
                    result += string.Format("\\u{0:x4}", (int)text[i]);
            }
            return result;
        }

        /// <summary>
        /// Unicode编码转字符串
        /// </summary>
        /// <returns></returns>
        public static string UnicodeToString(string str)
        {/*
            string str = srcText;
            byte[] bytes = new byte[2];
            bytes[1] = byte.Parse(int.Parse(str.Substring(0, 2), NumberStyles.HexNumber).ToString());
            bytes[0] = byte.Parse(int.Parse(str.Substring(2), NumberStyles.HexNumber).ToString());
            return Encoding.Unicode.GetString(bytes);*/

            string outStr = "";
            if (!string.IsNullOrEmpty(str))
            {
                string[] strlist = str.Replace("/", "").Split('u');
                try
                {
                    for (int i = 1; i < strlist.Length; i++)
                    {
                        //将unicode字符转为10进制整数，然后转为char中文字符  
                        outStr += (char)int.Parse(strlist[i], System.Globalization.NumberStyles.HexNumber);
                    }
                }
                catch (FormatException ex)
                {
                    outStr = ex.Message;
                }
            }
            return outStr;
        }

        public static string EncryptPassword(string targetValue, string key)
        {
            if (string.IsNullOrEmpty(targetValue))
            {
                return string.Empty;
            }
            var returnValue = new StringBuilder();
            var des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.Default.GetBytes(targetValue);

            // 通过两次哈希密码设置对称算法的初始化向量   
            des.Key = Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile
                                            (FormsAuthentication.HashPasswordForStoringInConfigFile(key, "md5").
                                                Substring(0, 8), "sha1").Substring(0, 8));
            // 通过两次哈希密码设置算法的机密密钥
            des.IV = Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile
                                            (FormsAuthentication.HashPasswordForStoringInConfigFile(key, "md5")
                                                .Substring(0, 8), "md5").Substring(0, 8));
            var ms = new MemoryStream();
            var cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            foreach (byte b in ms.ToArray())
            {
                returnValue.AppendFormat("{0:X2}", b);
            }
            return returnValue.ToString();
        }

        // DES数据解密
        public static string DecryptPassword(string targetValue, string key)
        {
            if (string.IsNullOrEmpty(targetValue))
            {
                return string.Empty;
            }
            // 定义DES加密对象
            var des = new DESCryptoServiceProvider();
            int len = targetValue.Length / 2;
            var inputByteArray = new byte[len];
            int x, i;
            for (x = 0; x < len; x++)
            {
                i = Convert.ToInt32(targetValue.Substring(x * 2, 2), 16);
                inputByteArray[x] = (byte)i;
            }
            // 通过两次哈希密码设置对称算法的初始化向量   
            des.Key = Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile
                                                    (FormsAuthentication.HashPasswordForStoringInConfigFile(key, "md5").
                                                        Substring(0, 8), "sha1").Substring(0, 8));
            // 通过两次哈希密码设置算法的机密密钥   
            des.IV = Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile
                                                    (FormsAuthentication.HashPasswordForStoringInConfigFile(key, "md5")
                                                        .Substring(0, 8), "md5").Substring(0, 8));
            // 定义内存流
            var ms = new MemoryStream();
            // 定义加密流
            var cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Encoding.Default.GetString(ms.ToArray());
        }
    }
}
