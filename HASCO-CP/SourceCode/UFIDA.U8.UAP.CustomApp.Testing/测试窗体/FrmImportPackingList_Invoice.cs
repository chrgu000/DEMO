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
    public partial class FrmImportPackingList_Invoice : Form
    {
        public FrmImportPackingList_Invoice()
        {
            InitializeComponent();

            gL_accvouch1.Conn = Config.ConnStr;
            gL_accvouch1.sUserName = "demo1";
            gL_accvouch1.sUserID = "demo1";
            gL_accvouch1.sAccID = "888";
            gL_accvouch1.sLogDate = "2017-9-22";
        }
    }
}
