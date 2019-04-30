using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;

namespace ImportDLL
{
    public partial class Frm生产日报订单查询 :Form
    {
        TH.Model.Equipment Model = new TH.Model.Equipment();
        TH.DAL._GetBaseData DALGetBaseData = new TH.DAL._GetBaseData();
        TH.DAL.生产日报表 DAL = new TH.DAL.生产日报表();

        public string s生产订单序号 = "";
        public string s工艺路线顺序 = "";

        

        public Frm生产日报订单查询(string s工序,string s班组)
        {
            InitializeComponent();

            try
            {
                GetLookup();

                gridView1.OptionsBehavior.Editable = false;

                lookUpEdit工序.EditValue = s工序;
                lookUpEdit班组.EditValue = s班组;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

       
        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                btnSel_Click(null, null);
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
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

        private void GetGrid()
        {
            //int iFocRow = 0;
            //if (gridView1.FocusedRowHandle > 0)
            //    iFocRow = gridView1.FocusedRowHandle;

            //dtBingGrid = DAL.GetList("");
            //DataColumn dc = new DataColumn();
            //dc.ColumnName = "choose";
            //dc.DataType = System.Type.GetType("System.Boolean");
            //dc.DefaultValue = false;
            //dtBingGrid.Columns.Add(dc);

            //gridControl1.DataSource = dtBingGrid;
            //gridView1.AddNewRow();

            //gridView1.FocusedRowHandle = iFocRow;
            //chkAll.Checked = false;
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            //for (int i = 0; i < gridView1.RowCount; i++)
            //{
            //    gridView1.SetRowCellValue(i, gridCol选择, chkAll.Checked);
            //}
        }


        private void GetLookup()
        {
            dateEdit1.DateTime = BaseFunction.BaseFunction.ReturnDate(DateTime.Today.ToString("yyyy-MM-01"));
            dateEdit2.DateTime = BaseFunction.BaseFunction.ReturnDate(DateTime.Today.ToString("yyyy-MM-dd"));

            DataTable dt = DALGetBaseData.GetWorkGroupPeople("and 1=1");
            lookUpEdit班组.Properties.DataSource = dt;
            lookUpEdit班组.Enabled = false;

            dt = DALGetBaseData.GetWorkProcess("and 1=1");
            lookUpEdit工序.Properties.DataSource = dt;
            lookUpEdit工序.Enabled = false;

            dt = DALGetBaseData.GetProductPO("");
            lookUpEdit生产订单号1.Properties.DataSource = dt;
            lookUpEdit生产订单号2.Properties.DataSource = dt;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                s生产订单序号 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["生产订单序号"]).ToString().Trim();
                s工艺路线顺序 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["工艺路线顺序"]).ToString().Trim();

                this.DialogResult = DialogResult.OK;
            }
            catch { }
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            string sWhere = "1=1";
            if (lookUpEdit工序.Text.Trim() != "")
            {
                sWhere = sWhere + " and f.WorkProcessNo = '" + lookUpEdit工序.EditValue.ToString().Trim() + "'";
            }
            if (dateEdit1.Text.Trim() != "")
            {
                sWhere = sWhere + " and a.dDate >= '" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "'";
            }
            if (dateEdit2.Text.Trim() != "")
            {
                sWhere = sWhere + " and a.dDate < '" + dateEdit2.DateTime.AddDays(1).ToString("yyyy-MM-dd") + "'";
            }
            if (lookUpEdit生产订单号1.Text.Trim() != "")
            {
                sWhere = sWhere + " and a.cCode >=  '" + lookUpEdit生产订单号1.EditValue.ToString().Trim() + "'";
            }
            if (lookUpEdit生产订单号2.Text.Trim() != "")
            {
                sWhere = sWhere + " and a.cCode <=  '" + lookUpEdit生产订单号2.EditValue.ToString().Trim() + "'";
            }
            if (!chk包含已报工订单.Checked)
            {
                sWhere = sWhere + " and isnull(h.箱数,0) > isnull(i.报工箱数,0)";
            }
            if (!chk包含未登记中转箱订单.Checked)
            {
                sWhere = sWhere + " and isnull(h.箱数,0) > 0";
            }

            DataTable dt = DAL.GetWorkProcess(sWhere);
            gridControl1.DataSource = dt;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            btnOK_Click(null, null);
        }
    }
}
