using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 工程
{
    public partial class Control竖线 : UserControl
    {
        public Control竖线()
        {
            InitializeComponent();
        }

        private void chkCheck_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void Control竖线_Paint(object sender, PaintEventArgs e)
        {
            int y = this.Height;
            e.Graphics.DrawLine(new Pen(Color.Black, 2), new Point(10, 0), new Point(10, y));
        }

    }
}
