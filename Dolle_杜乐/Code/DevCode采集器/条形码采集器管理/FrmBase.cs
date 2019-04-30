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
        protected MobileBaseDLL.ClsSQLServerCommond clsSQLCommond = new MobileBaseDLL.ClsSQLServerCommond();
        protected MobileBaseDLL.ClsDES clsDES = MobileBaseDLL.ClsDES.Instance();
        protected MsgBox msgBox = new MsgBox();
        protected ClsU8 clsu8 = new ClsU8();


        public FrmBase()
        {
            InitializeComponent();
        }

        public long RetrunLong(object o)
        {
            long l = 0;
            try
            {
                l = Convert.ToInt64(o);
            }
            catch { }
            return l;
        }

        public int RetrunInt(object o)
        {
            int l = 0;
            try
            {
                l = Convert.ToInt32(o);
            }
            catch { }
            return l;
        }

        public decimal ReturnDecimal(object o, int i)
        {
            decimal d = 0;
            try
            {
                d = Convert.ToDecimal(o);
                d = decimal.Round(d, i);
            }
            catch { }
            return d;
        }

        public decimal ReturnDecimal(object o)
        {
            return ReturnDecimal(o, 6);
        }

    }
}