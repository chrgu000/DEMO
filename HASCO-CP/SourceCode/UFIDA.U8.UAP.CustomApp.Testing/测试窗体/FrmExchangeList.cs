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
    public partial class FrmExchangeList : Form
    {
        public FrmExchangeList()
        {
            InitializeComponent();

            exchangeList1.Conn = Config.ConnStr;
            exchangeList1.sUserName = "demo1";
            exchangeList1.sUserID = "demo1";
            exchangeList1.sAccID = "888";
            exchangeList1.sLogDate = "2017-9-22";
        }
    }
}
