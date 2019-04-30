using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BarCode
{
    public partial class Frm栈板 : FrmBase
    {
        public Frm栈板()
        {
            InitializeComponent();

          
        }

        private void Frm栈板_Load(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "select * from UFDLImport.._Code where vchrType = '1' order by vchrInfo";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                if (dt == null || dt.Rows.Count < 1)
                    throw new Exception("加载栈板档案失败");

                DataRow[] dr = dt.Select("vchrInfo = '栈板1'");
                if (dr.Length > 0)
                {
                    label栈板1.Text = dr[0]["vchrRemark"].ToString().Trim();
                }
                else
                {
                    label栈板1.Visible = false;
                    txt栈板1.Visible = false;
                }

                dr = dt.Select("vchrInfo = '栈板2'");
                if (dr.Length > 0)
                {
                    label栈板2.Text = dr[0]["vchrRemark"].ToString().Trim();
                }
                else
                {
                    label栈板2.Visible = false;
                    txt栈板2.Visible = false;
                }

                dr = dt.Select("vchrInfo = '栈板3'");
                if (dr.Length > 0)
                {
                    label栈板3.Text = dr[0]["vchrRemark"].ToString().Trim();
                }
                else
                {
                    label栈板3.Visible = false;
                    txt栈板3.Visible = false;
                }

                dr = dt.Select("vchrInfo = '栈板4'");
                if (dr.Length > 0)
                {
                    label栈板4.Text = dr[0]["vchrRemark"].ToString().Trim();
                }
                else
                {
                    label栈板4.Visible = false;
                    txt栈板4.Visible = false;
                }

                dr = dt.Select("vchrInfo = '栈板5'");
                if (dr.Length > 0)
                {
                    label栈板5.Text = dr[0]["vchrRemark"].ToString().Trim();
                }
                else
                {
                    label栈板5.Visible = false;
                    txt栈板5.Visible = false;
                }

                dr = dt.Select("vchrInfo = '栈板6'");
                if (dr.Length > 0)
                {
                    label栈板6.Text = dr[0]["vchrRemark"].ToString().Trim();
                }
                else
                {
                    label栈板6.Visible = false;
                    txt栈板6.Visible = false;
                }

                dr = dt.Select("vchrInfo = '栈板7'");
                if (dr.Length > 0)
                {
                    label栈板7.Text = dr[0]["vchrRemark"].ToString().Trim();
                }
                else
                {
                    label栈板7.Visible = false;
                    txt栈板7.Visible = false;
                }

                dr = dt.Select("vchrInfo = '栈板8'");
                if (dr.Length > 0)
                {
                    label栈板8.Text = dr[0]["vchrRemark"].ToString().Trim();
                }
                else
                {
                    label栈板8.Visible = false;
                    txt栈板8.Visible = false;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btn确定_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}