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
    public partial class Frm采购设置 : Form
    {
        public Frm采购设置()
        {
            InitializeComponent();

            purchaseSet1.Conn = Config.ConnStr;
            purchaseSet1.sUserName = "demo";
            purchaseSet1.sUserID = "demo";
            purchaseSet1.sAccID = "999";
            purchaseSet1.sLogDate = "2016-5-3";
        }
    }
}
