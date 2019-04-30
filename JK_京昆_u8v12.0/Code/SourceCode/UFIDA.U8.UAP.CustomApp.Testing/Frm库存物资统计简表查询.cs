using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Frm库存物资统计简表查询 : Form
    {
        public Frm库存物资统计简表查询()
        {
            InitializeComponent();

            库存物资统计简表查询1.Conn = Config.ConnStr;
            库存物资统计简表查询1.sUserName = "demo";
        }
    }
}
