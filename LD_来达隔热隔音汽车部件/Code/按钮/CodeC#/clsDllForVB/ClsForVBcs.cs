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
        string PrintPU_ArrivalVouch(string s1, string s2, string s3, string s4, string s5, string s6);
        string PrintDispatchList(string s1, string s2, string s3, string s4, string s5, string s6);
        string PrintWork1(string s1, string s2, string s3, string s4, string s5, string s6);
        string PrintWork2(string s1, string s2, string s3, string s4, string s5, string s6);
    }


    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class ClsPrintBarCode : iClassForVB
    {
        public string PrintPU_ArrivalVouch(string s1, string s2, string s3, string s4, string s5, string s6)
        {
            FrmPrintPU_ArrivalVouch frm = new FrmPrintPU_ArrivalVouch(s1, s2, s3, s4, s5, s6);

            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return "成功";
            }
            else
            {
                return "失败";
            }
        }

        public string PrintDispatchList(string s1, string s2, string s3, string s4, string s5, string s6)
        {
            FrmPrintDispatchList frm = new FrmPrintDispatchList(s1, s2, s3, s4, s5, s6);

            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return "成功";
            }
            else
            {
                return "失败";
            }
        }

        public string PrintWork1(string s1, string s2, string s3, string s4, string s5, string s6)
        {
            FrmPrintWork1 frm = new FrmPrintWork1(s1, s2, s3, s4, s5, s6);

            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return "成功";
            }
            else
            {
                return "失败";
            }
        }

        public string PrintWork2(string s1, string s2, string s3, string s4, string s5, string s6)
        {
            FrmPrintWork2 frm = new FrmPrintWork2(s1, s2, s3, s4, s5, s6);

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
