using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using clsU8;

namespace clsDllForVB
{

    [ComVisible(true)]
    public interface iClassForVB
    {
        string PrintMO(string s1, string s2, string s3, string s4, string s5, string s6);


        string PrintRd32(string s1, string s2, string s3, string s4, string s5, string s6);
    }


    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class ClsPrint : iClassForVB
    {
        public string PrintMO(string s1, string s2, string s3, string s4, string s5,string s6)
        {
            FrmPrintMO frm = new FrmPrintMO(s1, s2, s3, s4, s5, s6);

            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return "成功";
            }
            else
            {
                return "失败";
            }
        }

        public string PrintRd32(string s1, string s2, string s3, string s4, string s5, string s6)
        {
            FrmPrintRd32 frm = new FrmPrintRd32(s1, s2, s3, s4, s5, s6);

            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return "成功";
            }
            else
            {
                return "失败";
            }
        }
    }

}
