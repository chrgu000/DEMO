using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FrameBaseFunction;

namespace Warehouse
{
    public partial class Frm厂商进出库明细 : FrameBaseFunction.Frm列表窗体模板
    {
        public Frm厂商进出库明细()
        {
            InitializeComponent();

            txtVenCode.Enabled = false;
        }

        private void Frm厂商进出库明细_Load(object sender, EventArgs e)
        {
            try
            {
                dateEdit1.DateTime = DateTime.Today.AddMonths(-1);
                dateEdit2.DateTime = DateTime.Today;
                dateEdit1.Enabled = true;
                dateEdit2.Enabled = true;
                dateEdit1.Properties.ReadOnly = false;
                dateEdit2.Properties.ReadOnly = false;

                string sSQL = "select vendCode,cVenName from UFDLImport.._vendUid left join @u8.Vendor on @u8.Vendor.cVenCode = vendCode where uid = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "'  and accid = 200 and accyear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + " ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                txtVenCode.Properties.ReadOnly = false;
                if (FrameBaseFunction.ClsBaseDataInfo.sUid == "admin" || dt.Rows.Count == 0)
                {
                    txtVenCode.Enabled = true;
                }
                else
                {
                    if (dt.Rows[0]["vendCode"].ToString().Trim() == string.Empty)
                    {
                        txtVenCode.Enabled = true;
                    }
                    else
                    {
                        txtVenCode.Enabled = false;
                    }
                    txtVenCode.EditValue = dt.Rows[0]["vendCode"].ToString().Trim();
                    txtVenCode_Leave(null, null);
                }

                GetGridView();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败！\n\t原因：" + ee.Message);
            }
        }

        /// <summary>
        /// 获得供应商订货信息
        /// </summary>
        private void GetGridView()
        {
            try
            {
                if (txtVenCode.Text != null && txtVenCode.Text.Trim() != string.Empty)
                {
                    string sSQL = @"
SELECT *
FROM [DolleDatabase].[dbo].[_v_bzh_出入库明细]
where 厂商编码 = '111111' and 1=1
order by TaskID,厂商编码,日期,[物料编码]
";
                    sSQL = sSQL.Replace("111111", txtVenCode.Text.Trim());
                    if (dateEdit1.Text.Trim() != "")
                    {
                        sSQL = sSQL.Replace("1=1", "1=1 and 日期 >= '" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "' ");
                    }
                    if (dateEdit2.Text.Trim() != "")
                    {
                        sSQL = sSQL.Replace("1=1", "1=1 and 日期 < '" + dateEdit2.DateTime.AddDays(1).ToString("yyyy-MM-dd") + "' ");
                    }

                    gridControl1.DataSource = clsSQLCommond.ExecQuery(sSQL);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得供应商信息失败！\n\t原因：" + ee.Message);
            }
        }


        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "sel":
                        btnSEL();
                        break;
                   
                    case "export":
                        btnExport();
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

        private void btnExport()
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

                sa.ShowDialog();
                string sPath = sa.FileName;

                if (sPath.Trim() != string.Empty)
                {
                    gridView1.ExportToXls(sPath);
                }
            }
            catch (Exception ee)
            { 
                throw new Exception("导出Excel失败：" + ee.Message);
            }
        }

        private void btnSEL()
        {
            GetGridView();
        }

        private void lookUpVendor_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetGridView();
            }
            catch (Exception ee)
            {
                MessageBox.Show("查询失败！\n\t原因：" + ee.Message);
            }
        }

        private void txtVenCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmVenInfo fVen = new FrmVenInfo(txtVenCode.Text.Trim());
            if (DialogResult.OK == fVen.ShowDialog())
            {
                txtVenCode.Text = fVen.sVenCode;
                txtVenName.Text = fVen.sVenName;
            }
        }

     
        private DataTable GetVendor(string sVenCode)
        {
            try
            {
                string sSQL = "select cVenCode as iID,cVenName as iText from @u8.Vendor where cVenCode = '" + sVenCode + "' order by cVenCode";
                DataTable dt = clsGetSQL.GetLookUpEdit(sSQL);
                return dt;
            }
            catch
            {
                throw new Exception("获得供应商信息失败！");
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

        private void txtVenCode_Leave(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = GetVendor(txtVenCode.Text.Trim());
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtVenName.Text = dt.Rows[0]["iText"].ToString().Trim();
                    GetGridView();
                }
                else
                {
                    txtVenCode.Text = "";
                    txtVenName.Text = "";
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得供应商信息失败！ " + ee.Message);
            }
        }
    }
}