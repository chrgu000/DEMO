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
        string TH001(string s1, string s2, string s3, string s4, string s5,string s6);
    }


    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class ClsTH001 : iClassForVB
    {
        public string TH001(string s1, string s2, string s3, string s4, string s5, string s6)
        {
            //Frm销售订单导入 frm = new Frm销售订单导入(s1, s2, s3, s4, s5, s6);

            //if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    return "成功";
            //}
            //else
            //{
            //    return "失败";
            //}
            return null;
        }

        public string TH002(string s1, string s2, string s3, string s4, string s5, string s6)
        {
            Frm其他入库单 frm = new Frm其他入库单(s1, s2, s3, s4, s5, s6);

            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return "成功";
            }
            else
            {
                return "失败";
            }
        }

        public string TH003(string s1, string s2, string s3, string s4, string s5, string s6)
        {
            Frm收款单导入 frm = new Frm收款单导入(s1, s2, s3, s4, s5, s6);

            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return "成功";
            }
            else
            {
                return "失败";
            }
        }

        public string TH004(string s1, string s2, string s3, string s4, string s5, string s6)
        {
            Frm销售发票导出 frm = new Frm销售发票导出(s1, s2, s3, s4, s5, s6);

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
