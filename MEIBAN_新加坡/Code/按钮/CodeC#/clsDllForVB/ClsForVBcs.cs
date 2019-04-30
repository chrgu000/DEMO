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
        string PrintBarCodeRD01(string s1, string s2, string s3, string s4, string s5, string s6);
        string PrintBarCodeRD08(string s1, string s2, string s3, string s4, string s5, string s6);
        string PrintBarCodeRD10(string s1, string s2, string s3, string s4, string s5, string s6);
    }


    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class ClsPrintBarCode : iClassForVB
    {
        public string PrintBarCodeRD01(string s1, string s2, string s3, string s4, string s5, string s6)
        {
            FrmPrintBarCodeRD01 frm = new FrmPrintBarCodeRD01(s1, s2, s3, s4, s5, s6);

            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return "成功";
            }
            else
            {
                return "失败";
            }
        }

        public string PrintBarCodeRD08(string s1, string s2, string s3, string s4, string s5, string s6)
        {
            FrmPrintBarCodeRD08 frm = new FrmPrintBarCodeRD08(s1, s2, s3, s4, s5, s6);

            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return "成功";
            }
            else
            {
                return "失败";
            }
        }

        public string PrintBarCodeRD10(string s1, string s2, string s3, string s4, string s5, string s6)
        {
            FrmPrintBarCodeRD10 frm = new FrmPrintBarCodeRD10(s1, s2, s3, s4, s5, s6);

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
