using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FrameBaseFunction
{
    public partial class FrmServerPro : FrameBaseFunction.FrmBaseInfo
    {
        public FrmServerPro()
        {
            InitializeComponent();
        }

        private void FrmServerPro_Load(object sender, EventArgs e)
        {

        }
        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "open":
                        btnOpen();
                        break;
                    case "close":
                        btnClose();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(sBtnText + " 失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClose()
        {
            throw new NotImplementedException();
        }

        private void btnOpen()
        {
            throw new NotImplementedException();
        }
    }
}
