using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.Business
{
    public static class 规格化
    {
        public static decimal ReturnDecimal(object o)
        {
            decimal d = 0;
            try
            {
                d = decimal.Round(Convert.ToDecimal(o), 6);
            }
            catch { }
            return d;
        }
        public static decimal ReturnDecimal(object o, int iLength)
        {
            decimal d = 0;
            try
            {
                d = decimal.Round(Convert.ToDecimal(o), iLength);
            }
            catch { }
            return d;
        }


        public static int ReturnInt(object o)
        {
            int d = 0;
            try
            {
                d = Convert.ToInt32(o);
            }
            catch { }
            return d;
        }

        public static string ReturnDateTimeString(object o)
        {
            string d = "";
            try
            {
                if (Convert.ToDateTime(o) >= Convert.ToDateTime("1900-01-01"))
                {
                    d = Convert.ToDateTime(o).ToString("yyyy-MM-dd");
                }
            }
            catch { }
            return d;
        }

        public static double 零舍一入(double o)
        {
            double o1 = Math.Round(o, 4);
            double o2 = Math.Round(o + 0.00004, 4);
            if (o2 >= o1)
            {
                return Math.Round(o + 0.00004, 4);
            }
            else
            {
                return Math.Round(o, 4);
            }
            
        }
    }
}
