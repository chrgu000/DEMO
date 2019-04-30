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
    public partial class Control左斜线 : UserControl
    {
        public Control左斜线()
        {
            InitializeComponent();
        }

        private void chkCheck_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void Control左斜线_Paint(object sender, PaintEventArgs e)
        {
            int h = this.Height;
            int w = this.Width;
            e.Graphics.DrawLine(new Pen(Color.Black, 2), new Point(w, 0), new Point(0, h));
        }

    }
}
