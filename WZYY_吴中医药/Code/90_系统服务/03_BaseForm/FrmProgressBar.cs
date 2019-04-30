using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 系统服务
{
    public partial class FrmProgressBar : Form
    {
        private static volatile FrmProgressBar frmProgressBar = null;
        private static object lockHelper = new object();
     
        public FrmProgressBar()
        {
            InitializeComponent();
        }

        public static FrmProgressBar Instance()
        {
            if (frmProgressBar == null)
            {
                lock (lockHelper)
                {
                    if (frmProgressBar == null)
                    {
                        frmProgressBar = new FrmProgressBar();
                    }
                }
            }

            return frmProgressBar;
        }

        private void FrmProgressBar_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
