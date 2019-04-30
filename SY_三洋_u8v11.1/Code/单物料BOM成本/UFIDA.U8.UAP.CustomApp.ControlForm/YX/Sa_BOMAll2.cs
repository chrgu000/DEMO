using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using UFIDA.U8.UAP.CustomApp.ControlForm.Business;
using DevExpress.XtraEditors;
using System.Xml;


namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class Sa_BOMAll2 : UserControl
    {

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        public Sa_BOMAll2()
        {
            InitializeComponent();
        }


        private void Sa_BOMAll2_Load(object sender, EventArgs e)
        {
            try
            {
                dateEdit1.Text = DateTime.Now.AddMonths(-3).ToString("yyyy-MM-dd");
                dateEdit2.Text = DateTime.Now.ToString("yyyy-MM-dd");
                dateEdit3.Text = DateTime.Now.AddMonths(-3).ToString("yyyy-MM-dd");
                dateEdit4.Text = DateTime.Now.ToString("yyyy-MM-dd");
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, "select cInvCName from InventoryClass").Tables[0];
                lookUp物料类别.Properties.DataSource = dt;


            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败:" + ee.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetGrid();
        }

        private void GetGrid()
        {
            try
            {
                //DataTable dt = Sa_BOMAllBLL2.GetFormsData(Conn);
                string _dataSourceStr6 = "select *,发票最高单价-最高进价 as 制造原价差异 from 产品原价分析汇总 where 1=1 ";

                string cinvcode1 = "";
                if (buttonEditInvName1.EditValue != null)
                {
                    cinvcode1 = buttonEditInvCode1.EditValue.ToString().Trim();
                }
                string cinvcode2 ="";
                if (buttonEditInvName2.EditValue != null)
                {
                    cinvcode2 = buttonEditInvCode2.EditValue.ToString().Trim();
                }
                string stype = "";
                if (lookUp物料类别.EditValue != null)
                {
                    stype = buttonEdit存货分类.EditValue.ToString().Trim();
                }
                if (cinvcode1 != "")
                {
                    _dataSourceStr6 = _dataSourceStr6 + " and 物料编码>='" + cinvcode1 + "'";
                }
                if (cinvcode2 != "")
                {
                    _dataSourceStr6 = _dataSourceStr6 + " and 物料编码<='" + cinvcode2 + "'";
                }
                if (stype != "")
                {
                    _dataSourceStr6 = _dataSourceStr6 + " and 物料类别编码 like '" + stype + "%'";
                }
                DataTable dts = SqlHelper.ExecuteDataset(Conn, CommandType.Text, _dataSourceStr6).Tables[0];
                gridControl1.DataSource = dts;
            }
            catch(Exception ee)
            {
                MessageBox.Show("查询数据失败:" +ee.Message , "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sa = new SaveFileDialog();
                sa.Filter = "Excel文件2003|*.xls";
                sa.FileName = Sa_BOMAllBLL.exlname;

                DialogResult d = sa.ShowDialog();
                if (d == DialogResult.OK)
                {
                    string sPath = sa.FileName;

                    if (sPath.Trim() != string.Empty)
                    {
                        gridControl1.ExportToXls(sPath);
                        MessageBox.Show("导出列表成功！\n路径：" + sPath);
                    }
                }
                
            }
            catch (Exception ee)
            {
                MessageBox.Show("导出列表失败：" + ee.Message);
            }
        }

        private void buttonEditInvCode1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                FrmInvInfo fInv = new FrmInvInfo(buttonEditInvCode1.Text, Conn, false);
                if (DialogResult.OK == fInv.ShowDialog())
                {
                    buttonEditInvCode1.Text = fInv.sInvCode;
                    buttonEditInvName1.Text = fInv.sInvName;
                    buttonEditInvStd1.Text = fInv.sInvStd;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEditInvCode2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                FrmInvInfo fInv = new FrmInvInfo(buttonEditInvCode2.Text, Conn,false);
                if (DialogResult.OK == fInv.ShowDialog())
                {
                    buttonEditInvCode2.Text = fInv.sInvCode;
                    buttonEditInvName2.Text = fInv.sInvName;
                    buttonEditInvStd2.Text = fInv.sInvStd;
                }
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }


        private void buttonEditInvCode1_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEditInvCode1.Text.Trim() != "")
            {
                string sSQL = "select cInvCode,cInvName,cInvStd from Inventory where cInvCode='" + buttonEditInvCode1.Text.Trim() + "'";
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    buttonEditInvName1.Text = dt.Rows[0]["cInvName"].ToString().Trim();
                    buttonEditInvStd1.Text = dt.Rows[0]["cInvStd"].ToString().Trim();
                }
            }
            else
            {
                buttonEditInvName1.EditValue = null;
                buttonEditInvStd1.EditValue = null;
            }
        }

        private void buttonEditInvCode1_Leave(object sender, EventArgs e)
        {
            if (buttonEditInvCode1.Text.Trim() == "")
                return;
            if (buttonEditInvCode1.Text.Trim() == "")
            {
                buttonEditInvCode1.Text = "";
                buttonEditInvCode1.Focus();
            }
        }

        private void buttonEditInvCode2_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEditInvCode2.Text.Trim() != "")
            {
                string sSQL = "select cInvCode,cInvName,cInvStd from Inventory where cInvCode='" + buttonEditInvCode2.Text.Trim() + "'";
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    buttonEditInvName2.Text = dt.Rows[0]["cInvName"].ToString().Trim();
                    buttonEditInvStd2.Text = dt.Rows[0]["cInvStd"].ToString().Trim();
                }
            }
            else
            {
                buttonEditInvName2.EditValue = null;
                buttonEditInvStd2.EditValue = null;
            }
        }

        private void buttonEditInvCode2_Leave(object sender, EventArgs e)
        {
            if (buttonEditInvCode2.Text.Trim() == "")
                return;
            if (buttonEditInvCode2.Text.Trim() == "")
            {
                buttonEditInvCode2.Text = "";
                buttonEditInvCode2.Focus();
            }
        }

        private void dateEdit4_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void gridView2_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            string mycolor = gridView1.GetRowCellDisplayText(e.RowHandle, gridColumn19).ToString().Trim();
            if (mycolor != string.Empty)
            {
                if (double.Parse(mycolor) > 0)
                {
                    e.Appearance.BackColor = Color.Blue;
                }
                if (double.Parse(mycolor) < 0)
                {
                    e.Appearance.BackColor = Color.Red;
                }

            }
        }

        private void buttonEdit存货分类_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit存货分类.Text.Trim() != "")
            {
                string sSQL = "select cInvCCode,cInvCName from InventoryClass where cInvCCode='" + buttonEdit存货分类.Text.Trim() + "'";
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    lookUp物料类别.EditValue = dt.Rows[0]["cInvCName"].ToString().Trim();
                }
            }
            else
            {
                lookUp物料类别.EditValue = null;
            }
        }

        private void buttonEdit存货分类_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                FrmInvClassInfo fInv = new FrmInvClassInfo(buttonEdit存货分类.Text, Conn);
                if (DialogResult.OK == fInv.ShowDialog())
                {
                    buttonEdit存货分类.Text = fInv.id;
                }
            }
            catch(Exception ee) 
            {
                MessageBox.Show(ee.Message);
            }
        }


    }
}