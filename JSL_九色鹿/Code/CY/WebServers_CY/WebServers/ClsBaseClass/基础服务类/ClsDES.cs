using System;
using System.Security.Cryptography;
using System.IO;
using System.Text;


namespace TH.DBWebService
{

    /// <summary>
    /// �ַ����ӽ���
    /// </summary>
    public class ClsDES
    {

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
        /// ����,ʹ��Ĭ����Կ
        /// </summary>
        /// <param name="sKey">��Կ</param>
        /// <returns></returns>
        public string Encrypt(string pToEncrypt)
        {
            try
            {
                string sKey = TH.DBWebService.ClsBaseDataInfo.sKey;
                return Encrypt(pToEncrypt, sKey);
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="pToEncrypt">Ҫ�����ַ�</param>
        /// <param name="sKey">��Կ</param>
        /// <returns></returns>
        public string Encrypt(string pToEncrypt, string sKey)
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                //���ַ����ŵ�byte������  
                //ԭ��ʹ�õ�UTF8���룬�Ҹĳ�Unicode�����ˣ�����  
                byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
                //byte[]  inputByteArray=Encoding.Unicode.GetBytes(pToEncrypt);  

                //�������ܶ������Կ��ƫ����  
                //ԭ��ʹ��ASCIIEncoding.ASCII������GetBytes����  
                //ʹ�����������������Ӣ���ı�  
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
        /// ����,ʹ��Ĭ����Կ
        /// </summary>
        /// <param name="sKey">��Կ</param>
        /// <returns></returns>
        public string Decrypt(string pToDecrypt)
        {
            try
            {
                string sKey = TH.DBWebService.ClsBaseDataInfo.sKey;
                return Decrypt(pToDecrypt, sKey);

            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="pToDecrypt">Ҫ�����ַ�</param>
        /// <param name="sKey">��Կ</param>
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

                //�������ܶ������Կ��ƫ��������ֵ��Ҫ�������޸�  
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                //Flush  the  data  through  the  crypto  stream  into  the  memory  stream  
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                //Get  the  decrypted  data  back  from  the  memory  stream  
                //����StringBuild����CreateDecryptʹ�õ��������󣬱���ѽ��ܺ���ı����������  
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
