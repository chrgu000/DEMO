﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace 系统服务
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
    }
}
