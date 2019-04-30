using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Purchase
{
    public partial class FrmImport : Form
    {

        DataTable dtExcel = new DataTable();

        public FrmImport(DataTable dt)
        {
            InitializeComponent();

            dtExcel = dt.Copy();
            this.Text = "导入失败列表";
        }

        private void FrmImport_Load(object sender, EventArgs e)
        {
            try
            {
                gridControl1.DataSource = dtExcel;
            }
            catch (Exception ee)
            {
                MessageBox.Show("显示失败！\n  "+ee.Message);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                }
                catch { }

                SaveFileDialog sa = new SaveFileDialog();
                sa.Filter = "Excel文件2003|*.xls";
                sa.FileName = "错误列表";

                sa.ShowDialog();
                string sPath = sa.FileName;

                if (sPath.Trim() != string.Empty)
                {
                    gridView1.ExportToXls(sPath);
                    MessageBox.Show("导出错误列表成功！\n路径：" + sPath);
                }
            }
            catch (Exception ee)
            {
                throw new Exception("导出错误列表失败：" + ee.Message);
            }

            this.Close();
        }
    }
}