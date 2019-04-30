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
    public partial class Frm询价单结论公布sel : FrameBaseFunction.Frm列表窗体模板
    {
        DataTable dtSel = new DataTable();
        int iPage = 0;
        ArrayList aList;
        string sSQL;
        string sVenCode = "";

        public string sGuid;

        public Frm询价单结论公布sel(string sVen)
        {
            InitializeComponent();

            sVenCode = sVen;
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

            if (lookUpEditcVenCode.Text.Trim() == "")
            {
                throw new Exception("供应商设置错误");
            }

            string sSQL = @"
select cast(0 as bit) as 选择
    , a.iID, a.单据日期, a.制单人, a.制单日期, a.发布人, a.发布日期, a.标题, a.备注,  a.GUID
    ,b.供应商编码,c.cVenName as 供应商名称 ,b.审批结论,b.审批人,b.审批时间
    , CONVERT(varchar, 截止日期, 120) AS 截止日期
    , CONVERT(varchar, 终止询价日期, 120) as 终止询价日期, 终止人
from UFDLImport..询价单 a inner join UFDLImport..询价单供应商 b on a.GUID = b.GUID
	inner join @u8.Vendor c on b.供应商编码 = c.cVenCode
where 1=1 and b.供应商编码 = '1111'
    and isnull(a.发布人,'') <> ''
order by a.iID
";
            sSQL = sSQL.Replace("1111", lookUpEditcVenCode.EditValue.ToString().Trim());
            if (date1.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and 单据日期 >= '" + date1.DateTime.ToString("yyyy-MM-dd") + "' ");
            }
            if (date2.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and 单据日期 <= '" + date2.DateTime.ToString("yyyy-MM-dd") + "' ");
            }


            sSQL = sSQL.Replace("1=1", "1=1  and isnull(b.审批人,'') <> '' ");
            

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


        private void SetLookup()
        {
            string sSQL = "select cVenCode,cVenName from @u8.Vendor order by cVenCode";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            lookUpEditcVenCode.Properties.DataSource = dt;
            lookUpEditcVenCode.EditValue = sVenCode;


            sSQL = "select  vchrUid, vchrName from _UserInfo order by vchrUid";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEditUser.DataSource = dt;
        }



        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                date1.DateTime = DateTime.Today.AddMonths(-1);
                date2.DateTime = DateTime.Today;

                date1.Enabled = true;
                date1.Properties.ReadOnly = false;

                date2.Enabled = true;
                date2.Properties.ReadOnly = false;

                SetLookup();

                btnSel();

                this.WindowState = FormWindowState.Normal;
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void gridView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

                sGuid = gridView1.GetRowCellValue(iRow, gridColGUID).ToString().Trim();

                if (sGuid != "")
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("获得询价单失败");
                }
            }
            catch { }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            gridView1_DoubleClick(null, null);
        }
    }
}