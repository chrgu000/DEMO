using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TH.BaseClass;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.Business
{
    public  class CommonBLL
    {
        public  static  void  SetDataTalbeSel(DataTable dtSource, bool status)
        {
            foreach (DataRow row in dtSource.Rows)
            {
                row["IsSelected"] = status;
            }
        }

        public static void  SetDataTalbeFormStatus(DataTable dtSource, string formCode, bool status)
        {
            foreach (DataRow row in dtSource.Rows)
            {
                string checkformCode = row["单据号码"].ToString();
                if (checkformCode == formCode)
                {
                    row["IsSelected"] = status;
                }
            }
        }
    }
}
