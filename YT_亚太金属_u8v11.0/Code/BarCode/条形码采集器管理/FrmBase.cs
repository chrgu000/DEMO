using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BarCode
{
    public partial class FrmBase : Form
    {
        protected MobileBaseDLL.ClsUseWebService clsWeb = new MobileBaseDLL.ClsUseWebService();
        protected BaseDllMobile.ClsDES clsDES = BaseDllMobile.ClsDES.Instance();
        protected MsgBox msgBox = new MsgBox();
        public static string sUserID = "";
        public static string sUserName = "";

        public FrmBase()
        {
            InitializeComponent();
        }

        protected int ReturnObjectToInt(object o)
        {
            int l = 0;
            try
            {
                l = Convert.ToInt32(o);
            }
            catch
            { }
            return l;
        }

        protected long ReturnObjectToLong(object o)
        {
            long l = 0;
            try
            {
                l = Convert.ToInt64(o);
            }
            catch
            { }
            return l;
        }

        protected double ReturnObjectToDouble(object o)
        {
            double l = 0;
            try
            {
                l = Convert.ToDouble(o);
            }
            catch
            { }
            return l;
        }


        protected decimal ReturnObjectToDecimal(object o,int i)
        {
            decimal l = 0;
            try
            {
                l = Convert.ToDecimal(o);
                l = decimal.Round(l, i);
            }
            catch
            { }
            return l;
        }
    }
}