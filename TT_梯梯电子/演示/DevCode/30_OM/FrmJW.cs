using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FrameBaseFunction;

namespace OM
{
    public partial class FrmJW : FrameBaseFunction.Frm列表窗体模板
    {
        public FrmJW()
        {
            InitializeComponent();
        }

        private void FrmJW_Load(object sender, EventArgs e)
        {

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


        private void btnSel()
        {
            try
            {
                string sSQL = "select o.cCode as 委外订单号,o.dDate as 委外订单日期,os.cInvCode as 物料编码,i.cinvname as 物料名称,i.cInvStd as 规格型号,os.iQuantity 订单数量, isnull(os.cDefine32,'') as 缴库单号,r.dDate as 缴库日期,rs.cInvcode as 缴库编码,i2.cinvname as 缴库名称,i2.cInvStd as 缴库规格,rs.iQuantity as 缴库数量,isnull(rs.iQuantity,0)-isnull(os.iQuantity,0) as 缴库余量 " +
                              "from @u8.om_modetails os inner join @u8.om_momain o on  o.moid =  os.moid inner join @u8.Inventory i on  i.cinvcode =  os.cinvcode left join @u8.rdrecord01 r on r.cCode = rtrim(ltrim(os.cDefine32)) left join @u8.rdrecords01 rs on r.id = rs.id left join @u8.Inventory i2 on  i2.cinvcode =  rs.cInvcode " +
                              "order by o.cCode,os.cDefine32";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                gridControl1.DataSource = dt;
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnExport()
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.Filter = "Excel文件(*.xls)|*.xls|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridView1.ExportToXls(sF.FileName);
                    MessageBox.Show("导出Excel成功\n\t路径：" + sF.FileName);
                }
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
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
    }
}