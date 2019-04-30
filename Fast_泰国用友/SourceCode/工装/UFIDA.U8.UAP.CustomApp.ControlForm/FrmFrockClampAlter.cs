using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TH.BaseClass;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class FrmFrockClampAlter : Form
    {
        public FrmFrockClampAlter()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if(dtm1.Text.Trim() != "" && dtm1.DateTime < DateTime.Today)
                {
                    MessageBox.Show("使用寿命不能小于当天");
                    return;
                }

                if(txtTimes.Text.Trim() != "" && BaseFunction.ReturnLong(txtTimes.Text.Trim())<0)
                {
                    MessageBox.Show("寿命次数不能小于0");
                    return;
                }

                if (dtm1.Text.Trim() == "" && txtTimes.Text.Trim() == "")
                {
                    MessageBox.Show("使用寿命与寿命次数至少填写一项");
                    return;
                }

                string sSQL = @"
update _FrockClamp set Times = 222222,LC = 333333 where [SerialNo] = N'111111'
";
                sSQL = sSQL.Replace("111111", txtSerialNo.Text.Trim());

                if (dtm1.DateTime > BaseFunction.ReturnDate("2000-01-01"))
                {
                    sSQL = sSQL.Replace("333333", "N'" + dtm1.DateTime.ToString("yyyy-MM-dd") + "'");
                }
                else
                {
                    sSQL = sSQL.Replace("333333", "null");
                }

                if (txtTimes.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("222222", BaseFunction.ReturnLong(txtTimes.Text.Trim()).ToString());
                }
                else
                {
                    sSQL = sSQL.Replace("222222", "Null");
                }
                DbHelperSQL.ExecuteSql(sSQL);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
