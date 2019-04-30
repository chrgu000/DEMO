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
    public partial class Frm杜乐公告供应商查看 : FrameBaseFunction.Frm列表窗体模板
    {
        DataTable dtSel = new DataTable();
        int iPage = 0;
        ArrayList aList;
        string sSQL;

        public Frm杜乐公告供应商查看()
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
                    case "save":
                        btnAudit();
                        break;
                    case "unaudit":
                        btnUnAudit();
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

        private void btnAdd()
        {
            Frm杜乐公告Edit f = new Frm杜乐公告Edit();
            f.ShowDialog();

            btnSel();
        }

        private void btnSel()
        {
            if (!b供应商)
                throw new Exception("请设定供应商");

            chk全选.Checked = false;

            int iFoc = 0;
            if (gridView1.FocusedRowHandle > 0)
                iFoc = gridView1.FocusedRowHandle;

            string sSQL = @"
select cast(0 as bit) as 选择, *
from UFDLImport..杜乐公告 a inner join UFDLImport..杜乐公告明细 b on a.guid = b.guid
where 1=1 and 供应商编码 = '111111' and isnull(a.发布人,'') <> ''
order by a.iID
";
            sSQL = sSQL.Replace("111111", l供应商编码.Text.Trim());
            if (radio未处理.Checked)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and isnull(阅读人,'') = ''");
            }

            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            gridControl1.DataSource = dt;
            gridView1.FocusedRowHandle = iFoc;

        }

        private void btnUnAudit()
        {
          
        }

        private void btnAudit()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }
            aList = new ArrayList();
            string sErr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridCol阅读人).ToString().Trim() != "")
                {
                    sErr = sErr + "行" + (i + 1).ToString() + "已经处理\n";
                    continue;
                }

                string sSQL = "update UFDLImport..杜乐公告明细 set 阅读人 = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "',阅读日期 = getdate() where guid = '" + gridView1.GetRowCellValue(i, gridColGUID).ToString().Trim() + "' and 供应商编码 = '" + l供应商编码.Text.Trim() + "'";
                aList.Add(sSQL);
            }
            if (sErr != "")
            {
                throw new Exception(sErr);
            }

            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("处理成功");
                btnSel();
            }
            else
            {
                MessageBox.Show("没有选择需要处理的数据");
            }
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




        bool b供应商 = false;

        private void Frm杜乐公告供应商查看_Load(object sender, EventArgs e)
        {
            try
            {
                date1.Enabled = true;
                date2.Enabled = true;
                date1.Properties.ReadOnly = false;
                date2.Properties.ReadOnly = false;


                string sSQL = "select vendCode,cVenName from UFDLImport.._vendUid inner join @u8.Vendor on @u8.Vendor.cVenCode = vendCode where uid = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "'  and accid = 200 and accyear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + " ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    b供应商 = false;
                }
                else
                {
                    b供应商 = true;
                    l供应商编码.Text = dt.Rows[0]["vendcode"].ToString().Trim();
                }

                date1.DateTime = DateTime.Today.AddMonths(-1);
                date2.DateTime = DateTime.Today;

                btnSel();

            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void gridView评审_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void chk全选_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridCol选择, chk全选.Checked);
                }
            }
            catch (Exception ee)
            { 
                
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView1.FocusedRowHandle > 0)
                    iRow = gridView1.FocusedRowHandle;

                string sGuid = gridView1.GetRowCellValue(iRow, gridColGUID).ToString().Trim();
                if (sGuid != "")
                {
                    Frm杜乐公告供应商查看Edit f = new Frm杜乐公告供应商查看Edit(sGuid, l供应商编码.Text.Trim());
                    f.ShowDialog();

                    sSQL = "update UFDLImport..杜乐公告明细 set 阅读人 = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "' , 阅读日期 = getdate() where guid = '" + sGuid + "' and 供应商编码 = '" + l供应商编码.Text.Trim() + "'";
                    clsSQLCommond.ExecSql(sSQL);

                    btnSel();
                }
            }
            catch { }
        }

        private void radio未处理_Click(object sender, EventArgs e)
        {
            btnSel();
        }
    }
}