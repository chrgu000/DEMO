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
    public partial class FormSa_BOMAll2 : Form
    {
        public FormSa_BOMAll2()
        {
            InitializeComponent();
            sa_BOMAll21.Conn = Config.ConnStr;
            sa_BOMAll21.sUserName = "demo";
        }
    }
}
