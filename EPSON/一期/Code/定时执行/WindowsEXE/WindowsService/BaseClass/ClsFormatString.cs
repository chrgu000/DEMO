using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoExe
{
    static public class ClsFormatString
    {
        static public string SetStringFormat(object o, int iLength)
        {
            string sTxt = "";
            if (o != null)
            {
                sTxt = o.ToString().Trim();
            }

            while (System.Text.Encoding.Default.GetBytes(sTxt).Length < iLength)
            {
                sTxt = sTxt + ' '.ToString();
            }


            return sTxt;
        }

        static public string SetStringFormat(object o, int iLength, char sValue)
        {
            string sTxt = "";
            if (o != null)
            {
                sTxt = o.ToString().Trim();
            }

            while (System.Text.Encoding.Default.GetBytes(sTxt).Length < iLength)
            {
                sTxt = sValue.ToString() + sTxt;
            }

            if (System.Text.Encoding.Default.GetBytes(sTxt).Length > iLength)
            {
                sTxt = sTxt.Substring(sTxt.Length - 8);
            }


            return sTxt;
        }
    }
}
