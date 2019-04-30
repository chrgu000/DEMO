using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace UFIDA.U8.UAP.CustomApp.Entrance
{
     public class Utils
    {
         public static string ConvertConn(string conn)
         {
             string[] connArr=conn.Split(';');

             for(int i=0;i<connArr .Length ;i++)
             {
                 if (connArr[i].ToUpper() == "PROVIDER=SQLOLEDB")
                 {
                     connArr[i] = "";
                 }
             }
             string result = string.Join(";", connArr); ;
             return result;
         }
    }
}
