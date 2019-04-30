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
    public partial class Frm杜乐公告Edit : Form
    {
        FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
        FrameBaseFunction.ClsGetSQL clsGetSQL = FrameBaseFunction.ClsGetSQL.Instance();

        string sGuid = "";
        public Frm杜乐公告Edit()
        {
            InitializeComponent();
        }
        string sType = "";
        public Frm杜乐公告Edit(string s)
        {
            InitializeComponent();

            sGuid = s;
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

        private void SetValue()
        {
            string sSQL = @"
select cast(0 as bit) as 选择, cVenCode as 供应商编码,cVenName as 供应商名称 
from @u8.Vendor  
where 1=1
order by cVenCode";

            if (radio采购.Checked)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and cVenDepart = '4'");
            }
            if (radio委外.Checked)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and cVenDepart = '905'");
            }
            if (radio未设置.Checked)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and isnull(cVenDepart,'') = ''");
            }
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;

            sSQL = @"
select * 
from UFDLImport..杜乐公告 a inner join UFDLImport..杜乐公告明细 b on a.GUID = b.GUID 
where a.GUID = '111111'
";
            sSQL = sSQL.Replace("111111", sGuid);
            dt = clsSQLCommond.ExecQuery(sSQL);

            txt主题.Text = dt.Rows[0]["标题"].ToString().Trim();
            richTextBox内容.Text = dt.Rows[0]["内容"].ToString().Trim();
            txt制单人.Text = dt.Rows[0]["制单人"].ToString().Trim();
            date制单日期.Text = dt.Rows[0]["制单日期"].ToString().Trim();
            txt发布人.Text = dt.Rows[0]["发布人"].ToString().Trim();
            date_发布日期.Text = dt.Rows[0]["发布日期"].ToString().Trim();

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string s供应商编码 = gridView1.GetRowCellValue(i, gridCol供应商编码).ToString().Trim();
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    string s供应商编码2 = dt.Rows[j]["供应商编码"].ToString().Trim();

                    if (s供应商编码 == s供应商编码2)
                    {
                        gridView1.SetRowCellValue(i, gridCol选择, true);
                        break;
                    }
                }
            }
        }

        private void SetNull()
        {
            radio全部.Checked = true;
            txt主题.Text = "";
            richTextBox内容.Text = "";
            date制单日期.Text = "";
            date_发布日期.Text = "";

            string sSQL = "select cast(0 as bit) as 选择, cVenCode as 供应商编码,cVenName as 供应商名称 from @u8.Vendor  order by cVenCode";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;
            txt主题.Focus();
        }

        private void Frm杜乐公告Edit_Load(object sender, EventArgs e)
        {
            try
            {
                if (sGuid == "")
                {
                    SetNull();
                }
                else
                {
                    SetValue();
                }
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

        private void btn保存_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                if (txt主题.Text.Trim() == "")
                {
                    txt主题.Focus();
                    throw new Exception("主题不能为空");
                }
                if (richTextBox内容.Text.Trim() == "")
                {
                    richTextBox内容.Focus();
                    throw new Exception("内容不能为空");
                }
                if (sGuid == "")
                {
                    sGuid = Guid.NewGuid().ToString();
                }

                string sSQL = "select count(1) from UFDLImport..杜乐公告 where guid = '" + sGuid + "' and isnull(发布人,'') <> ''";
                int iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                if (iCou > 0)
                    throw new Exception("已经发布不能修改");

                ArrayList aList = new ArrayList();
                sSQL = "delete UFDLImport..杜乐公告明细 where guid = '" + sGuid + "'";
                aList.Add(sSQL);

                bool b = false;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridCol选择)))
                    {
                        sSQL = "insert into UFDLImport..杜乐公告明细(供应商编码,guid)values('" + gridView1.GetRowCellValue(i, gridCol供应商编码).ToString().Trim() + "','" + sGuid + "')";
                        aList.Add(sSQL);
                        b = true;
                    }
                }

                if(!b)
                {
                    throw new Exception("请选择供应商");
                }

                sSQL = "select count(1) from UFDLImport..杜乐公告 where guid = '" + sGuid + "'";
                iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                if (iCou == 0)
                {
                    sSQL = "insert into UFDLImport..杜乐公告(标题,内容,制单人,制单日期,guid)values('" + txt主题.Text.Trim() + "','" + richTextBox内容.Text.Trim() + "','" + FrameBaseFunction.ClsBaseDataInfo.sUid + "','" + DateTime.Today.ToString("yyyy-MM-dd") + "','" + sGuid + "')";
                    aList.Add(sSQL);
                }
                else
                {
                    sSQL = "update UFDLImport..杜乐公告 set 标题 = '" + txt主题.Text.Trim() + "',内容 = '" + richTextBox内容.Text.Trim() + "',制单人 = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "',制单日期 = '" + DateTime.Today.ToString("yyyy-MM-dd") + "' where guid = '" + sGuid + "'";
                    aList.Add(sSQL);
                }

                if (aList.Count > 1)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("保存成功");

                    txt制单人.Text = FrameBaseFunction.ClsBaseDataInfo.sUid;
                    date制单日期.Text = DateTime.Today.ToString("yyyy-MM-dd");
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btn删除_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                string sSQL = "select count(1) from UFDLImport..杜乐公告 where guid = '" + sGuid + "' and isnull(发布人,'') <> ''";
                int iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                if (iCou > 0)
                    throw new Exception("已经发布不能删除");

                ArrayList aList = new ArrayList();
                sSQL = "delete UFDLImport..杜乐公告明细 where guid = '" + sGuid + "'";
                aList.Add(sSQL);
                sSQL = "delete UFDLImport..杜乐公告 where guid = '" + sGuid + "'";
                aList.Add(sSQL);
                clsSQLCommond.ExecSqlTran(aList);

                MessageBox.Show("删除成功");

                this.DialogResult = DialogResult.Yes;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btn发布_Click(object sender, EventArgs e)
        {
            try
            {

                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                if (txt发布人.Text.Trim() != "")
                {
                    MessageBox.Show("已经发布");
                    return;
                }

                btn保存_Click(null, null);
                string sSQL = "update UFDLImport..杜乐公告 set 发布人 = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "',发布日期 = '" + DateTime.Today.ToString("yyyy-MM-dd") + "' where guid = '" + sGuid + "'";

                clsSQLCommond.ExecSql(sSQL);
                MessageBox.Show("发布成功");

                txt发布人.Text = FrameBaseFunction.ClsBaseDataInfo.sUid;
                date_发布日期.Text = DateTime.Today.ToString("yyyy-MM-dd");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btn取消_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                if (txt制单人.Text.Trim() == "")
                {
                    MessageBox.Show("尚未保存");
                    return;
                }

                if (txt发布人.Text.Trim() == "")
                {
                    MessageBox.Show("尚未发布");
                    return;
                }

                string sSQL = "update UFDLImport..杜乐公告 set 发布人 = null,发布日期 = null where guid = '" + sGuid + "'";

                clsSQLCommond.ExecSql(sSQL);
                MessageBox.Show("取消发布成功");

                txt发布人.Text = "";
                date_发布日期.Text = "";
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btn退出_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }


        private void radio供应商_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                string sSQL = @"
select cast(0 as bit) as 选择, cVenCode as 供应商编码,cVenName as 供应商名称 
from @u8.Vendor  
where 1=1
order by cVenCode";

                if (radio采购.Checked)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and cVenDepart = '4'");
                }
                if (radio委外.Checked)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and cVenDepart = '905'");
                }
                if (radio未设置.Checked)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(cVenDepart,'') = ''");
                }
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                gridControl1.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载供应商失败\n" + ee.Message);
            }
        }

    }
}