﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Frm现存产品标签打印 : Form
    {
        public Frm现存产品标签打印()
        {
            InitializeComponent();

            产品现存量标签打印1.Conn = Config.ConnStr;
            产品现存量标签打印1.sUserID = "demo";
            产品现存量标签打印1.sUserName = "demo";
        }
    }
}
