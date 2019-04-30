using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace clsU8
{
    public partial class GetBaseData
    {

        /// <summary>
        /// 获得条形码
        /// </summary>
        /// <returns></returns>
        public string GetBarCode(DateTime dDate, long lMaxID)
        {
            string sBarCode = dDate.ToString("yyMMdd");

            string sMaxID = lMaxID.ToString().Trim();
            while (sMaxID.Length < 6)
            {
                sMaxID = "0" + sMaxID;
            }

            sBarCode = sBarCode + sMaxID;

            return sBarCode;
        }

        /// <summary>
        /// 获得箱码
        /// </summary>
        /// <returns></returns>
        public string GetBarCodeBox(DateTime dDate, long lMaxID)
        {
            string sBarCode ="X" + dDate.ToString("yyMMdd");

            string sMaxID = lMaxID.ToString().Trim();
            while (sMaxID.Length < 6)
            {
                sMaxID = "0" + sMaxID;
            }

            sBarCode = sBarCode + sMaxID;

            return sBarCode;
        }

        /// <summary>
        /// 获得序列号
        /// </summary>
        /// <returns></returns>
        public string GetSerialNO(string sMaxSerialNO, string sInvCode, int iRightLength)
        {
            string sSerialNO = "";

            if (sMaxSerialNO.Trim() == "")
            {
                sSerialNO = sInvCode + "SA00001";
            }
            else
            {
                string s1 = sMaxSerialNO.Substring(8, 1);
                long l = BaseFunction.ReturnLong(sMaxSerialNO.Substring(9));
                l += 1;

                double l2 = Math.Pow(10, (iRightLength));
                if (l == BaseFunction.ReturnLong(l2))
                {
                    byte[] array = new byte[1];   //定义一组数组array
                    array = System.Text.Encoding.ASCII.GetBytes(s1); //string转换的字母
                    int asciicode = (short)(array[0]);

                    asciicode += 1;

                    array[0] = (byte)asciicode; //ASCII码强制转换二进制
                    s1 = Convert.ToString(System.Text.Encoding.ASCII.GetString(array));

                    l = 1;
                }

                string sRight = l.ToString();
                while (sRight.Trim().Length < iRightLength)
                {
                    sRight = "0" + sRight.Trim();
                }
                sSerialNO = sInvCode + "S" + s1 + sRight;
            }


            return sSerialNO;
        }
    }
}
