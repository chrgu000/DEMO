using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using clsU8;

namespace clsDllForVB
{

    [ComVisible(true)]
    public interface iClassForVB
    {
        string ShowQC01(string s1, string s2, string s3, string s4, string s5);
        string ShowQC10(string s1, string s2, string s3, string s4, string s5);
    }


    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class ClaPrintRdRecord : iClassForVB
    {
        public string ShowQC01(string s1,string s2,string s3,string s4,string s5)
        {
            Frm采购入库单检验 frm = new Frm采购入库单检验(s1, s2, s3, s4, s5);

            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return "成功";
            }
            else
            {
                return "失败";
            }
        }

        public string ShowQC10(string s1, string s2, string s3, string s4, string s5)
        {
            Frm产成品入库单检验 frm = new Frm产成品入库单检验(s1, s2, s3, s4, s5);

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
