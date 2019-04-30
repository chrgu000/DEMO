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
using TH.BaseClass;


namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class Sa_Certificate : UserControl
    {
        //public class CmbDataSource
        //{
        //    public string WareHouseCode;
        //    public string WareHouseName;
        //}

        //public class UserMsg
        //{
        //    public string UserCode;
        //    public string UserName;
        //}


        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        public Sa_Certificate()
        {
            InitializeComponent();
        }


        private void ProjectManager_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime nowday = DateTime.Now;
                dateCreate.DateTime = nowday.AddDays(1 - nowday.Day);
                dateCreate2.DateTime = dateCreate.DateTime.AddMonths(1).AddDays(-1);
                grdDetail.DataSource = Sa_CertificateBLL.GetFormsData2(GetFilterStr(), Conn);
            }
            catch (Exception ee)
            {
                MessageBox.Show("��������ʧ��");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //gridView1.OptionsBehavior.Editable = false;

            if (dateCreate.Text.Trim() == "")
            {
                MessageBox.Show("Ʊ�����ڲ���Ϊ��");
                dateCreate.Focus();
                return;
            }
            if (dateCreate2.Text.Trim() == "")
            {
                MessageBox.Show("Ʊ�����ڲ���Ϊ��");
                dateCreate2.Focus();
                return;
            }
            if (dateCreate2.DateTime < dateCreate.DateTime)
            {
                MessageBox.Show("Ʊ�����ڱ����С����");
                dateCreate.Focus();
                return;
            }


            DataTable dt = Sa_CertificateBLL.GetFormsData2(GetFilterStr(), Conn);
            grdDetail.DataSource = dt;
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("û���κ�����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string GetFilterStr()
        {
            List<string> filter = new List<string>();
            if (txtƱ�ݺ�.Text.Trim() != "")
                filter.Add(" and isnull(���۷�Ʊ��,'') " + cmbƱ�ݺ�.Text + " '" + (cmbƱ�ݺ�.Text == "like" ? "%" : "") + txtƱ�ݺ�.Text + (cmbƱ�ݺ�.Text == "like" ? "%" : "") + "'");


            if (txt�ڼ�.Text.Trim() != "")
                filter.Add(" and isnull(�ڼ�,'') " + cmb�ڼ�.Text + " '" + (cmb�ڼ�.Text == "like" ? "%" : "") + txt�ڼ�.Text + (cmb�ڼ�.Text == "like" ? "%" : "") + "'");

            filter.Add(" and Ʊ������>='" + dateCreate.DateTime.ToString("yyyy-MM-dd") + "' and Ʊ������<='" + dateCreate2.DateTime.ToString("yyyy-MM-dd") + "' ");

            return string.Join("\r\n", filter.ToArray());
        }

        private void grvDetail_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {

            if (e.RowHandle < 0)
                return;
            e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                gridView1.PostEditor();
                this.Validate();

                SaveFileDialog sa = new SaveFileDialog();
                sa.Filter = "Excel�ļ�2003|*.xls";
                sa.FileName = "���۷�Ʊ";

                string outstr = ",";
                bool b = false;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridColChk)) == true && outstr.IndexOf("," + gridView1.GetRowCellValue(i, gridCol���۷�Ʊ��).ToString().Trim() + ",") == -1)
                    {
                        outstr = outstr + gridView1.GetRowCellValue(i, gridCol���۷�Ʊ��).ToString().Trim() + ",";
                    }
                    if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridColChk)) == true && gridView1.GetRowCellValue(i, gridCol���۷�Ʊ��).ToString().Trim() == "")
                    {
                        b = true;
                    }
                }

                if (b != true)
                {
                    
                    if (outstr != ",")
                    {

                        DialogResult d = sa.ShowDialog();
                        if (d == DialogResult.OK)
                        {
                            string sPath = sa.FileName;

                            if (sPath.Trim() != string.Empty)
                            {
                                DataSet ds = Sa_CertificateBLL.GetFormsData(GetFilterStr(), Conn, outstr);
                                Xls.ToExcel(sPath, ds);
                                MessageBox.Show("�����б�ɹ���\n·����" + sPath);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("δѡ�з�Ʊ");
                    }
                }
                else
                {
                    MessageBox.Show("��Ʊ������Ϊ��");
                }
                //gridView1.OptionsBehavior.Editable = false;
            }
            catch (Exception ee)
            {
                MessageBox.Show("�����б�ʧ�ܣ�" + ee.Message);
            }
        }

        private void grvDetail_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {

            if (e.Column.Tag != null && e.Column.Tag.ToString() == "Input")
            {
                decimal curValue = gridView1.GetRowCellValue(e.RowHandle, e.Column) == null || gridView1.GetRowCellValue(e.RowHandle, e.Column).ToString() == "" ? 0 : decimal.Parse(gridView1.GetRowCellValue(e.RowHandle, e.Column).ToString());

                string oldFieldName = "�޸�ǰ����" + e.Column.FieldName;
                decimal oldValue = gridView1.GetRowCellValue(e.RowHandle, oldFieldName) == null || gridView1.GetRowCellValue(e.RowHandle, oldFieldName).ToString() == "" ? 0 : decimal.Parse(gridView1.GetRowCellValue(e.RowHandle, oldFieldName).ToString());



                string memoFieldName = "��ע" + e.Column.FieldName;
                string memoValue = gridView1.GetRowCellValue(e.RowHandle, memoFieldName) == null || gridView1.GetRowCellValue(e.RowHandle, memoFieldName).ToString() == "" ? "" : gridView1.GetRowCellValue(e.RowHandle, memoFieldName).ToString();

                if (curValue > 0 && oldValue > 0)
                {
                    if (curValue > oldValue)
                    {
                        e.Appearance.ForeColor = Color.Red;

                    }
                    else if (curValue < oldValue)
                    {
                        e.Appearance.ForeColor = Color.Blue;
                    }
                }

                if (memoValue != "")
                {
                    e.Appearance.BackColor = Color.LightGreen ;
                }
                else
                {
                    e.Appearance.BackColor = Color.White ;
                }
            }

        }

        private void grvDetail_DoubleClick(object sender, EventArgs e)
        {
        }

        private void ItemTextEditN2_DoubleClick(object sender, EventArgs e)
        {
            grvDetail_DoubleClick(null, null);
        }

        private void ItemTextEditN2_Enter(object sender, EventArgs e)
        {
            TextEdit item = sender as TextEdit;
            item.SelectAll();
            Application.DoEvents();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            GetChk(checkEdit1.Checked);
        }

        private void GetChk(bool b)
        {
            if (b == false)
            {
                checkEdit1.Text = "ȫѡ";
            }
            else
            {
                checkEdit1.Text = "ȫ��ȡ��";
            }
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                gridView1.SetRowCellValue(i, gridColChk, b);
            }

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int iRow = gridView1.FocusedRowHandle;
                bool b = Convert.ToBoolean(gridView1.GetRowCellValue(iRow, gridColChk));
                string s = gridView1.GetRowCellValue(iRow, gridCol���۷�Ʊ��).ToString().Trim();
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    string s2 = gridView1.GetRowCellValue(i, gridCol���۷�Ʊ��).ToString().Trim();
                    if (s == s2)
                    {
                        gridView1.SetRowCellValue(i, gridColChk, !b);
                    }
                }
            }
            catch
            { }
        }

    }
}