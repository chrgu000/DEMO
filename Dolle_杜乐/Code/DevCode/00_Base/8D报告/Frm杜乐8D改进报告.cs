using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FrameBaseFunction;

namespace Base
{
    public partial class Frm杜乐8D改进报告 : FrameBaseFunction.Frm列表窗体模板
    {
        //TH.BaseClsInfo.ClsDataBase clsSQLCommond = TH.BaseClsInfo.ClsDataBaseFactory.Instance();
        //FrameBaseFunction.ClsGetSQL clsGetSQL = new FrameBaseFunction.ClsGetSQL();
  
        DataTable dtSel = new DataTable();
        int iPage = 0;
        ArrayList aList;
        string sSQL;

        public Frm杜乐8D改进报告()
        {
            InitializeComponent();
        }

        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {

                    case "sel":
                        btnSel();
                        break;
                  
                    default:
                        break;
                }

                sState = sBtnName.ToLower();
            }
            catch (Exception ee)
            {
                throw new Exception(sBtnText + " 失败! \n\n原因:\n  " + ee.Message);
            }
        }

        private void btnSel()
        {
            int iFoc = 0;
            if (gridView1.FocusedRowHandle > 0)
                iFoc = gridView1.FocusedRowHandle;

            string sSQL = @"
select cast(0 as bit) as 选择
    ,* 
from DolleDatabase.dbo._Bai_到货不良品处理流程 a
    left join UFDLImport.._8D报告 b on a.id = b.idhead 
    left join opendatasource('SQLOLEDB','server=192.168.1.10;uid=sa;pwd=bpm@PASSWORD;database=BPMDB').BPMDB.dbo.BPMInstTasks c on a.TaskId = c.TaskId 
where 是否提交8D改进报告 = '是' and 1=1 
    and c.state not in ('Deleted','Aborted') 
Order by id
";

            if (txtVenCode.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.厂商编码 = '" + txtVenCode.Text.Trim() + "'");
            }
            if (radio待处理.Checked)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and isnull(b.idHead,0) = 0");
            }
            if (radio已处理.Checked)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and ((isnull(b.idHead,0) <> 0 and isnull(审批人,'') = '') or (isnull(b.idHead,0) <> 0 and isnull(审批人,'') <> '' and isnull(状态,0) = 0 and isnull(再次提交,'') <> '' ))");
            }
            if (radio已批准.Checked)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and isnull(b.idHead,0) <> 0 and isnull(审批人,'') <> '' and isnull(状态,0) = 1");
            }
            if (radio已拒绝.Checked)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and isnull(b.idHead,0) <> 0 and isnull(审批人,'') <> '' and isnull(状态,0) = 0 and isnull(再次提交,'') = ''");
            }
          
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;
            gridView1.FocusedRowHandle = iFoc;

        }

        #region 按钮模板

      
        /// <summary>
        /// 输出
        /// </summary>
        private void btnExport()
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
                sF.Filter = "Excel文件(*.xls)|*.xls|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridView1.ExportToXls(sF.FileName);
                    MessageBox.Show("导出Excel成功\n\t路径：" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

      
        #endregion






        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                txtVenCode.Properties.ReadOnly = false;

                string sSQL = "select vendCode,cVenName from [UFDLImport].._vendUid left join @u8.Vendor on @u8.Vendor.cVenCode = vendCode where uid = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "'  and accid = 200 and accyear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + " ";
                DataTable dt =clsSQLCommond.ExecQuery(sSQL);

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
                    txtVenCode.Text = dt.Rows[0]["vendCode"].ToString().Trim();
                    txtVenCode_Leave(null, null);
                }  

                btnSel();
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

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView1.FocusedRowHandle > 0)
                    iRow = gridView1.FocusedRowHandle;

                long iID = ReturnObjectToLong(gridView1.GetRowCellValue(iRow, gridColiID));
                if (iID != 0)
                {
                    Frm杜乐8D改进报告Edit f = new Frm杜乐8D改进报告Edit(iID);
                    f.MdiParent = this.MdiParent;
                    f.Tag = f.Text;
                    f.Show();

                    btnSel();
                    gridView1.FocusedRowHandle = iRow;
                }
            }
            catch { }
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

        private void txtVenCode_Leave(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = GetVendor(txtVenCode.Text.Trim());
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtVenName.Text = dt.Rows[0]["iText"].ToString().Trim();
                    btnSel();
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


        private DataTable GetVendor(string sVenCode)
        {
            try
            {
                //FrameBaseFunction.ClsGetSQL clsGetSQL = new FrameBaseFunction.ClsGetSQL();
                string sSQL = "select cVenCode as iID,cVenName as iText from @u8.Vendor where cVenCode = '" + sVenCode + "' order by cVenCode";
                DataTable dt = clsGetSQL.GetLookUpEdit(sSQL);
                return dt;
            }
            catch
            {
                throw new Exception("获得供应商信息失败！");
            }
        }

        private void chk全选_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridCol选择, chk全选.Checked);
                }
            }
            catch { }
        }

        private void Frm杜乐8D改进报告_Activated(object sender, EventArgs e)
        {
            try
            {
                btnSel();
            }
            catch { }
        }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                btnSel();
            }
            catch { }
        }
    }
}