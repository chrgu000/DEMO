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
    public partial class Frm存货情况表查询 : Form
    {
        public Frm存货情况表查询()
        {
            InitializeComponent();

            存货情况表查询1.Conn = Config.ConnStr;
            存货情况表查询1.sUserName = "demo";
        }
    }
}
