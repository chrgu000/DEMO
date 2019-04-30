using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 工程
{
    public partial class Frm工程登记_Add : Form
    {
        public string sWhere = "";
        public string dDate1 = "";
        public string dDate2 = "";
        public Frm工程登记_Add()
        {
           
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm工程登记_Add_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookUpEdit();

            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败：" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void SetLookUpEdit()
        {
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
                }
                else if (e.RowHandle < 0 && e.RowHandle > -1000)
                {
                    e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
                    e.Info.DisplayText = "G" + e.RowHandle.ToString();
                }
            }
        }

        private void btnEnsure_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt工程编号.EditValue != null)
                {
                    sWhere = sWhere + " and cCode like '%" + txt工程编号.EditValue.ToString().Trim() + "%'";
                }
                if (txt工程名称.EditValue != null)
                {
                    sWhere = sWhere + " and cCode like '%" + txt工程名称.EditValue.ToString().Trim() + "%'";
                }
                if (dateEdit单据日期1.EditValue != null)
                {
                    sWhere = sWhere + " and convert(varchar(10),dDate,120)>='" + DateTime.Parse(dateEdit单据日期1.EditValue.ToString().Trim()).ToString("yyyy-MM-dd") + "'";
                    dDate1 = DateTime.Parse(dateEdit单据日期1.EditValue.ToString().Trim()).ToString("yyyy-MM-dd");
                }
                if (dateEdit单据日期2.EditValue != null)
                {
                    sWhere = sWhere + " and convert(varchar(10),dDate,120)<='" + DateTime.Parse(dateEdit单据日期2.EditValue.ToString().Trim()).ToString("yyyy-MM-dd") + "'";
                    dDate2 = DateTime.Parse(dateEdit单据日期2.EditValue.ToString().Trim()).ToString("yyyy-MM-dd");
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            try
            {
                dateEdit单据日期1.EditValue = "";
                dateEdit单据日期2.EditValue = "";
                txt工程编号.EditValue = "";
                txt工程名称.EditValue = "";
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

    }
}
