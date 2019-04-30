using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 系统服务;

namespace 业务
{
    public partial class Frm检验图表筛选条件 : Form
    {
        public Frm检验图表筛选条件(string sConn)
        {
            InitializeComponent();

            DbHelperSQL.connectionString = sConn;
        }

        public string s班组;
        public string s检验工位;

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (lookUpEdit班组.EditValue == null || lookUpEdit班组.EditValue.ToString().Trim() == "")
                {
                    lookUpEdit班组.Focus();
                    MessageBox.Show("班组必选");
                    return;
                }
                s班组 = lookUpEdit班组.Text.Trim();

                if (lookUpEdit检验工位.EditValue == null || lookUpEdit检验工位.EditValue.ToString().Trim() == "")
                {
                    lookUpEdit检验工位.Focus();
                    MessageBox.Show("检验工位必选");
                    return;
                }
                s检验工位 = lookUpEdit检验工位.Text.Trim();

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "select distinct WorkGroup from [_WorkGroup] order by WorkGroup";
                DataTable dt = DbHelperSQL.Query(sSQL);
                DataRow dr = dt.NewRow();
                dt.Rows.InsertAt(dr, 0);
                lookUpEdit班组.Properties.DataSource = dt;

                sSQL = @"
select distinct 检验工位 as 工作台 from [发射器档案设置] order by 检验工位
";
                //select distinct 工作台 from [工作台测量] order by 工作台";
                
                dt = DbHelperSQL.Query(sSQL);
                dr = dt.NewRow();
                dt.Rows.InsertAt(dr, 0);
                lookUpEdit检验工位.Properties.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
