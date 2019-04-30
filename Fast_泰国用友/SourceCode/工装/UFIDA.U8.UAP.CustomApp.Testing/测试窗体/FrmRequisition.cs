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
    public partial class FrmRequisition : Form
    {
        public FrmRequisition()
        {
            InitializeComponent();

            requisition1.Conn = Config.ConnStr;
            requisition1.sUserName = "demo";
            requisition1.sUserID = "demo";
            requisition1.sAccID = "200";
            requisition1.sLogDate = "2015-12-12";
        }
    }
}
