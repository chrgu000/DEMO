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
        string TH001(string s1, string s2, string s3, string s4, string s5, string s6);
        string TH002(string s1, string s2, string s3, string s4, string s5, string s6);
        string TH005(string s1, string s2, string s3, string s4, string s5, string s6);
    }


    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class ClsTH001 : iClassForVB
    {
        public string TH001(string s1, string s2, string s3, string s4, string s5,string s6)
        {
            Frm销售订单导入 frm = new Frm销售订单导入(s1, s2, s3, s4, s5, s6);

            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return "成功";
            }
            else
            {
                return "失败";
            }
        }
        public string TH002(string s1, string s2, string s3, string s4, string s5, string s6)
        {
            Frm产成品入库单导入 frm = new Frm产成品入库单导入(s1, s2, s3, s4, s5, s6);

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
            Frm采购订单导入 frm = new Frm采购订单导入(s1, s2, s3, s4, s5, s6);

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
            Frm采购入库单导入 frm = new Frm采购入库单导入(s1, s2, s3, s4, s5, s6);

            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return "成功";
            }
            else
            {
                return "失败";
            }
        }

        //销售订单导入--上海订单转苏州导入
        public string TH005(string s1, string s2, string s3, string s4, string s5, string s6)
        {
            Frm销售订单导入_上海 frm = new Frm销售订单导入_上海(s1, s2, s3, s4, s5, s6);

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
