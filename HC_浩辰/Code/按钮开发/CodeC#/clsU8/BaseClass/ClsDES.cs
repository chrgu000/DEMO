using  System;  
using  System.Security.Cryptography;  
using  System.IO;  
using  System.Text;


namespace clsU8
{

    /// <summary>
    /// 字符串加解密
    /// </summary>
    public class ClsDES
    {
        string sKey = "11111111";
        private static volatile ClsDES clsDES = null;
        private static object lockHelper = new object();
        private ClsDES() { }

        public static ClsDES Instance()
        {
            if (clsDES == null)
            {
                lock (lockHelper)
                {
                    if (clsDES == null)
                    {
                        clsDES = new ClsDES();
                    }
                }
            }

            return clsDES;
        }


        /// <summary>
        /// 加密,使用默认密钥
        /// </summary>
        /// <param name="sKey">密钥</param>
        /// <returns></returns>
        public string Encrypt(string pToEncrypt)
        {
            try
            {
                return Encrypt(pToEncrypt, sKey);
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="pToEncrypt">要加密字符</param>
        /// <param name="sKey">密钥</param>
        /// <returns></returns>
        public string Encrypt(string pToEncrypt, string sKey)
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                //把字符串放到byte数组中  
                //原来使用的UTF8编码，我改成Unicode编码了，不行  
                byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
                //byte[]  inputByteArray=Encoding.Unicode.GetBytes(pToEncrypt);  

                //建立加密对象的密钥和偏移量  
                //原文使用ASCIIEncoding.ASCII方法的GetBytes方法  
                //使得输入密码必须输入英文文本  
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                //Write  the  byte  array  into  the  crypto  stream  
                //(It  will  end  up  in  the  memory  stream)  
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                //Get  the  data  back  from  the  memory  stream,  and  into  a  string  
                StringBuilder ret = new StringBuilder();
                foreach (byte b in ms.ToArray())
                {
                    //Format  as  hex  
                    ret.AppendFormat("{0:X2}", b);
                }
                ret.ToString();
                return ret.ToString();

            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        /// <summary>
        /// 解密,使用默认密钥
        /// </summary>
        /// <param name="sKey">密钥</param>
        /// <returns></returns>
        public string Decrypt(string pToDecrypt)
        {
            try
            {
                return Decrypt(pToDecrypt, sKey);

            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="pToDecrypt">要解密字符</param>
        /// <param name="sKey">密钥</param>
        /// <returns></returns>
        public string Decrypt(string pToDecrypt, string sKey)
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();

                //Put  the  input  string  into  the  byte  array  
                byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
                for (int x = 0; x < pToDecrypt.Length / 2; x++)
                {
                    int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                    inputByteArray[x] = (byte)i;
                }

                //建立加密对象的密钥和偏移量，此值重要，不能修改  
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                //Flush  the  data  through  the  crypto  stream  into  the  memory  stream  
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                //Get  the  decrypted  data  back  from  the  memory  stream  
                //建立StringBuild对象，CreateDecrypt使用的是流对象，必须把解密后的文本变成流对象  
                StringBuilder ret = new StringBuilder();

                return System.Text.Encoding.Default.GetString(ms.ToArray());

            }
            
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }
    }
}
        