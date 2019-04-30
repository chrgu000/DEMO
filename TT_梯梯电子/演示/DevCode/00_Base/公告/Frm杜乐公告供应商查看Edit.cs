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
    public partial class Frm���ֹ��湩Ӧ�̲鿴Edit : Form
    {
        FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
        FrameBaseFunction.ClsGetSQL clsGetSQL = FrameBaseFunction.ClsGetSQL.Instance();

        string sGuid = "";
        string sVenCode = "";

        string sType = "";
        public Frm���ֹ��湩Ӧ�̲鿴Edit(string s,string s2)
        {
            InitializeComponent();

            sGuid = s;
            sVenCode = s2;
        }

        #region ��ťģ��

      
        /// <summary>
        /// ���
        /// </summary>
        private void btnExport()
        {

        }

      
        #endregion


        private void Frm���ֹ��湩Ӧ�̲鿴Edit_Load(object sender, EventArgs e)
        {
            try
            {
                string sSQL = @"
select *
from UFDLImport..���ֹ��� a inner join UFDLImport..���ֹ�����ϸ b on a.GUID = b.GUID
where a.GUID = '111111' and ��Ӧ�̱��� = '222222'
";
                sSQL = sSQL.Replace("111111", sGuid);
                sSQL = sSQL.Replace("222222", sVenCode);
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                txt�Ķ���.Text = dt.Rows[0]["�Ķ���"].ToString().Trim();
                txt�Ƶ���.Text = dt.Rows[0]["�Ƶ���"].ToString().Trim();
                txt����.Text = dt.Rows[0]["����"].ToString().Trim();
                richTextBox����.Text = dt.Rows[0]["����"].ToString().Trim();
                date�Ķ���.Text = dt.Rows[0]["�Ķ�����"].ToString().Trim();
                date�Ƶ�����.Text = dt.Rows[0]["�Ƶ�����"].ToString().Trim();
            }
            catch (Exception ee)
            {
                MessageBox.Show("���ش���ʧ��\n" + ee.Message);
            }
        }

        private void gridView����_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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


        private void btn����_Click(object sender, EventArgs e)
        {
            try
            {

               
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

     

        private void btn�˳�_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

    }
}