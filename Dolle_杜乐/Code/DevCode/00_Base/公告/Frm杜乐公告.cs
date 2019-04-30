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
    public partial class Frm杜乐公告 : FrameBaseFunction.Frm列表窗体模板
    {
        DataTable dtSel = new DataTable();
        int iPage = 0;
        ArrayList aList;
        string sSQL;

        public Frm杜乐公告()
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
                    case "add":
                        btnAdd();
                        break;
                    case "del":
                        btnDel();
                        break;
                    case "audit":
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
            chk全选.Checked = false;

            int iFoc = 0;
            if (gridView1.FocusedRowHandle > 0)
                iFoc = gridView1.FocusedRowHandle;

            string sSQL = @"
select cast(0 as bit) as 选择, *,cast(null as varchar(8000)) as 供应商编码,cast(null as varchar(8000)) as 供应商名称 
from UFDLImport..杜乐公告 a
where 1=1 
order by a.iID
";
            if (date1.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and 制单日期 >= '" + date1.DateTime.ToString("yyyy-MM-dd") + "' ");
            }
            if (date2.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and 制单日期 <= '" + date2.DateTime.ToString("yyyy-MM-dd") + "' ");
            }
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sSQL = "select *,b.cVenName as 供应商名称 from UFDLImport..杜乐公告明细 a inner join @u8.vendor b on a.供应商编码 = b.cVenCode where guid = '" + dt.Rows[i]["guid"].ToString().Trim() + "' order by a.iID";
                DataTable dtGrid = clsSQLCommond.ExecQuery(sSQL);
                string s供应商编码 = "";
                string s供应商名称 = "";
                for (int j = 0; j < dtGrid.Rows.Count; j++)
                {
                    if (s供应商编码 == "")
                    {
                        s供应商编码 = dtGrid.Rows[j]["供应商编码"].ToString().Trim();
                        s供应商名称 = dtGrid.Rows[j]["供应商名称"].ToString().Trim();
                    }
                    else
                    {
                        s供应商编码 = s供应商编码 + "," + dtGrid.Rows[j]["供应商编码"].ToString().Trim();
                        s供应商名称 = s供应商名称 + "," + dtGrid.Rows[j]["供应商名称"].ToString().Trim();
                    }
                }
                dt.Rows[i]["供应商编码"] = s供应商编码;
                dt.Rows[i]["供应商名称"] = s供应商名称;
            }
            gridControl1.DataSource = dt;
            gridView1.FocusedRowHandle = iFoc;

        }

        private void btnUnAudit()
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
                bool bChoose = ReturnObjectToBool(gridView1.GetRowCellValue(i, gridCol选择));
                if (!bChoose)
                    continue;

                if (gridView1.GetRowCellValue(i, gridCol发布人).ToString().Trim() == "")
                {
                    sErr = sErr + "行" + (i + 1).ToString() + "尚未发布\n";
                    continue;
                }

                string sSQL = "update UFDLImport..杜乐公告 set 发布人 = null,发布日期 = null where guid = '" + gridView1.GetRowCellValue(i, gridColGUID).ToString().Trim() + "'";
                aList.Add(sSQL);
            }
            if (sErr != "")
            {
                throw new Exception(sErr);
            }

            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("取消发布成功");
                btnSel();
            }
            else
            {
                MessageBox.Show("没有选择需要发布的数据");
            }
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
                bool bChoose = ReturnObjectToBool(gridView1.GetRowCellValue(i, gridCol选择));
                if (!bChoose)
                    continue;

                if (gridView1.GetRowCellValue(i, gridCol发布人).ToString().Trim() != "")
                {
                    sErr = sErr + "行" + (i + 1).ToString() + "已经发布\n";
                    continue;
                }

                string sSQL = "update UFDLImport..杜乐公告 set 发布人 = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "',发布日期 = getdate() where guid = '" + gridView1.GetRowCellValue(i, gridColGUID).ToString().Trim() + "'";
                aList.Add(sSQL);
            }
            if (sErr != "")
            {
                throw new Exception(sErr);
            }

            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("发布成功");
                btnSel();
            }
            else
            {
                MessageBox.Show("没有选择需要发布的数据");
            }
        }

        private void btnDel()
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
                if (!Convert.ToBoolean(gridView1.GetRowCellValue(i, gridCol选择)))
                {
                    continue;
                }

                if (gridView1.GetRowCellValue(i, gridCol发布人).ToString().Trim() != "")
                {
                    sErr = sErr + "行" + (i + 1).ToString() + "已经发布\n";
                    continue;
                }

                string sSQL = "delete UFDLImport..杜乐公告明细 where guid = '" + gridView1.GetRowCellValue(i, gridColGUID).ToString().Trim() + "'";
                aList.Add(sSQL);
                sSQL = "delete UFDLImport..杜乐公告 where guid = '" + gridView1.GetRowCellValue(i, gridColGUID).ToString().Trim() + "'";
                aList.Add(sSQL);
            }
            if (sErr != "")
            {
                throw new Exception(sErr);
            }

            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("删除成功");
                btnSel();
            }
            else
            {
                MessageBox.Show("没有选择需要发布的数据");
            }
        }

        private void btnSave()
        {
            throw new NotImplementedException();
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






        private void Frm杜乐公告_Load(object sender, EventArgs e)
        {
            try
            {
                date1.DateTime = DateTime.Today.AddMonths(-1);
                date2.DateTime = DateTime.Today;

                date1.Enabled = true;
                date1.Properties.ReadOnly = false;

                date2.Enabled = true;
                date2.Properties.ReadOnly = false;
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
                    Frm杜乐公告Edit f = new Frm杜乐公告Edit(sGuid);
                    f.ShowDialog();

                    btnSel();
                }
            }
            catch { }
        }
    }
}