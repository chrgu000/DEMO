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
    public partial class Frm图表筛选条件 : Form
    {
        public Frm图表筛选条件(string sConn)
        {
            InitializeComponent();

            DbHelperSQL.connectionString = sConn;
        }

        public string s班组;
        public string s检验工位;
        public string s测定项目;

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if ((lookUpEdit测定项目.EditValue == null || lookUpEdit测定项目.Text.Trim() == ""))
                {
                    throw new Exception("测定项目必选");
                }

                if (lookUpEdit班组.EditValue != null)
                {
                    s班组 = lookUpEdit班组.Text.Trim();
                }
                if (lookUpEdit检验工位.EditValue != null)
                {
                    s检验工位 = lookUpEdit检验工位.Text.Trim();
                }
                if (lookUpEdit测定项目.EditValue != null)
                {
                    s测定项目 = lookUpEdit测定项目.Text.Trim();
                }

              
                this.DialogResult = DialogResult.OK;
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void Frm图表筛选条件_Load(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "select distinct WorkGroup from [_WorkGroup] order by WorkGroup";
                DataTable dt = DbHelperSQL.Query(sSQL);
                DataRow dr = dt.NewRow();
                dt.Rows.InsertAt(dr, 0);
                lookUpEdit班组.Properties.DataSource = dt;

                sSQL = "select distinct 工作台 from [工作台测量] order by 工作台";
                dt = DbHelperSQL.Query(sSQL); 
                dr = dt.NewRow();
                dt.Rows.InsertAt(dr, 0);
                lookUpEdit检验工位.Properties.DataSource = dt;

                sSQL = "select distinct ProCode,ProName from [_CheckProject] order by ProCode";
                dt = DbHelperSQL.Query(sSQL);
                dr = dt.NewRow();
                dt.Rows.InsertAt(dr, 0);
                lookUpEdit测定项目.Properties.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
