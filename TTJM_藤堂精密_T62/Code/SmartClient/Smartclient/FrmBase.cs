using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Reflection;

namespace Smartclient
{
    public partial class FrmBase : Form
    {
        protected TH.Smart.BaseClass.ClsDES clsDES = TH.Smart.BaseClass.ClsDES.Instance();
        protected TH.Smart.WebService.ClsUseWebService clsWeb = new TH.Smart.WebService.ClsUseWebService();

        public static string sUserID = "";

        protected void MsgBox(string sTitle, string sMessage)
        {
            MsgBox msgBox = new MsgBox();
            msgBox.textBox1.Text = sMessage;
            msgBox.Text = sTitle;
            msgBox.Tag = sTitle;
            msgBox.WindowState = FormWindowState.Maximized;
            msgBox.ShowDialog();
        }

        public FrmBase()
        {
            InitializeComponent();
        }

        protected int ReturnInt(object o)
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

        protected long ReturnLong(object o)
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

        protected bool ReturnBool(object o)
        {
            bool b = false;
            try
            {
                b = Convert.ToBoolean(o);
                if (b)
                    return b;
            }
            catch
            { }

            try
            {
                int i = Convert.ToInt32(o);
                if (i == 1)
                {
                    b = true;
                    return b;
                }
            }
            catch
            { }

            try
            {
                string s = o.ToString().Trim().ToLower();
                if (s == "true")
                {
                    b = true;
                    return b;
                }
            }
            catch
            { }
            return b;
        }

        protected double ReturnDouble(object o)
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


        protected decimal ReturnDecimal(object o)
        {
            return ReturnDecimal(o, 6);
        }


        protected decimal ReturnDecimal(object o,int i)
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

        protected DateTime ReturnDatetime(object o)
        {
            DateTime l = Convert.ToDateTime("1900-1-1");
            try
            {
                l = Convert.ToDateTime(o);
            }
            catch
            { }
            return l;
        }

        protected decimal ReturnDatatableColSUM(DataTable dt, string sColName,string sColValue)
        {
            decimal d = 0;
            DataRow[] dr = dt.Select("sColName = '" + sColValue + "'");
            DataView dv = dt.DefaultView;
            dv.RowFilter = sColName + " '" + sColValue + "'";
            DataTable dtTemp = dv.Table;
            d = ReturnDecimal(dtTemp.Compute("sum(" + sColName + ")", ""), 6);
            return d;
        }
    }
}