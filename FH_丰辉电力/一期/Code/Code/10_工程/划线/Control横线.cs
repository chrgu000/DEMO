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
    public partial class Control横线 : UserControl
    {
        public Control横线()
        {
            InitializeComponent();
        }

        private void chkCheck_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void Control横线_Paint(object sender, PaintEventArgs e)
        {
            int y = this.Width;
            e.Graphics.DrawLine(new Pen(Color.Black, 2), new Point(0, 10), new Point(y, 10));
        }

    }
}
