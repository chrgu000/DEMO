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
    public partial class Frm杜乐公告供应商查看Edit : Form
    {
        FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
        FrameBaseFunction.ClsGetSQL clsGetSQL = FrameBaseFunction.ClsGetSQL.Instance();

        string sGuid = "";
        string sVenCode = "";

        string sType = "";
        public Frm杜乐公告供应商查看Edit(string s,string s2)
        {
            InitializeComponent();

            sGuid = s;
            sVenCode = s2;
        }

        #region 按钮模板

      
        /// <summary>
        /// 输出
        /// </summary>
        private void btnExport()
        {

        }

      
        #endregion


        private void Frm杜乐公告供应商查看Edit_Load(object sender, EventArgs e)
        {
            try
            {
                string sSQL = @"
select *
from UFDLImport..杜乐公告 a inner join UFDLImport..杜乐公告明细 b on a.GUID = b.GUID
where a.GUID = '111111' and 供应商编码 = '222222'
";
                sSQL = sSQL.Replace("111111", sGuid);
                sSQL = sSQL.Replace("222222", sVenCode);
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                txt阅读人.Text = dt.Rows[0]["阅读人"].ToString().Trim();
                txt制单人.Text = dt.Rows[0]["制单人"].ToString().Trim();
                txt主题.Text = dt.Rows[0]["标题"].ToString().Trim();
                richTextBox内容.Text = dt.Rows[0]["内容"].ToString().Trim();
                date阅读人.Text = dt.Rows[0]["阅读日期"].ToString().Trim();
                date制单日期.Text = dt.Rows[0]["制单日期"].ToString().Trim();
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


        private void btn发布_Click(object sender, EventArgs e)
        {
            try
            {

               
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

    }
}