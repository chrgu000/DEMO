using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace BaseDllMobile
{
    public class ClsRetrunValue
    {
        public static int ReturnInt(object o)
        {
            int i = 0;
            try
            {
                i = Convert.ToInt32(o);
            }
            catch{}
            return i;

        }


        public static decimal ReturnDecimal(object o)
        {
            decimal d = 0;
            try
            {
               d = Convert.ToDecimal(o);
            }
            catch { }
            return d;

        }
    }
}
