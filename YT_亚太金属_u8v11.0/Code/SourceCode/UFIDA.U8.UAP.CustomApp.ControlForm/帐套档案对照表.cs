using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
//using UFIDA.U8.UAP.CustomApp.ControlForm.Business;
using DevExpress.XtraEditors;
using System.Xml;
using System.Data.SqlClient;
using TH.BaseClass;
using System.IO;


namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class ���׵������ձ� : UserControl
    {
        string sProPath = Application.StartupPath;

        string sPrintLayOutMod = Application.StartupPath + "\\print\\Model\\�������������ӡMod.dll";
        string sPrintLayOutUser = Application.StartupPath + "\\print\\User\\�������������ӡUser.dll";
        UFIDA.U8.UAP.CustomApp.ControlForm.RepBaseGrid Rep = new RepBaseGrid();

        string sState = "";

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        public ���׵������ձ�()
        {
            InitializeComponent();
        }


        private void ProjectManager_Load(object sender, EventArgs e)
        {
            try
            {
                btnRefresh_Click(null, null);
            }
            catch (Exception ee)
            {
                MessageBox.Show("��������ʧ�ܣ�" + ee.Message);
            }
        }
        
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            try
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
            catch { }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                string sSQL = @"
SELECT iID
      ,[��Դ����]
      ,[����]
      ,[��������]
      ,[���ձ���]
      ,[����]
      ,cast(0 as bit) as ѡ��
FROM [UFSystem].[dbo].[���׵������ձ�]
";
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                gridControl1.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show("��������ʧ��:" + ee.Message);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                //SaveFileDialog sF = new SaveFileDialog();
                //sF.DefaultExt = "xls";
                //sF.FileName = this.Text;
                //sF.Filter = "Excel�ļ�(*.xls)|*.xls|�����ļ�(*.*)|*.*";
                //DialogResult dRes = sF.ShowDialog();
                //if (DialogResult.OK == dRes)
                //{
                //    gridView1.ExportToXls(sF.FileName);
                //    MessageBox.Show("����Excel�ɹ�\n\t·����" + sF.FileName);
                //}
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }


        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                TH.BaseClass.ClsExcel clsExcel = TH.BaseClass.ClsExcel.Instance();

                OpenFileDialog oFile = new OpenFileDialog();
                oFile.Filter = "Excel�ļ�|*.xls|Excel�ļ�|*.xlsx";
                if (oFile.ShowDialog() == DialogResult.OK)
                {
                    string sFilePath = oFile.FileName;
                    string sSQL = "select * from [���׵������ձ�$]";

                    DataTable dt = clsExcel.ExcelToDT(sFilePath, sSQL, true);
                    DataColumn dc = new DataColumn();
                    dc.DataType = System.Type.GetType("System.Boolean");
                    dc.ColumnName = "ѡ��";
                    dt.Columns.Add(dc);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["ѡ��"] = true;
                    }
                    gridControl1.DataSource = dt;


                    if (dt == null || dt.Rows.Count < 1)
                        throw new Exception("���ص��ļ�û�����ݣ����ʵ�����");
                }
                else
                {
                    throw new Exception("ȡ������");
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.richTextBox1.Text = ee.Message;
                f.Text = "����ʧ��";
                f.ShowDialog();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                string sErr = "";
                string sSQL = "";

                int iFoc = 0;
                if (gridView1.FocusedRowHandle > 0)
                    iFoc = gridView1.FocusedRowHandle;

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //��������
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    for (int i = 0; i <  gridView1.RowCount; i++)
                    {
                        if (!SqlHelper.ReturnObjectToBool(gridView1.GetRowCellValue(i, gridColѡ��)))
                        {
                            continue;
                        }

                        string s��Դ���� = gridView1.GetRowCellValue(i,gridCol��Դ����).ToString().Trim() ;
                        if (s��Դ���� == "")
                        {
                            sErr = sErr + "��" + (i + 1).ToString().Trim() + "��Դ���ײ���Ϊ��";
                            continue;
                        }

                        string s���� = gridView1.GetRowCellValue(i, gridCol����).ToString().Trim();
                        if (s���� == "")
                        {
                            sErr = sErr + "��" + (i + 1).ToString().Trim() + "���벻��Ϊ��";
                            continue;
                        }

                        string s�������� = gridView1.GetRowCellValue(i, gridCol��������).ToString().Trim();
                        if (s�������� == "")
                        {
                            sErr = sErr + "��" + (i + 1).ToString().Trim() + "�������ײ���Ϊ��";
                            continue;
                        }
                        string s���ձ��� = gridView1.GetRowCellValue(i, gridCol���ձ���).ToString().Trim();
                        if (s���ձ��� == "")
                        {
                            sErr = sErr + "��" + (i + 1).ToString().Trim() + "���ձ��벻��Ϊ��";
                            continue;
                        }
                        string s���� = gridView1.GetRowCellValue(i, gridCol����).ToString().Trim();
                        if (s���� == "")
                        {
                            sErr = sErr + "��" + (i + 1).ToString().Trim() + "���Ͳ���Ϊ��";
                            continue;
                        }

                        sSQL = @"
if not exists(select * from [UFSystem].[dbo].[���׵������ձ�] where ��Դ���� = '111111' and ���� = '222222' and �������� = '333333' and ���� = '555555')
        insert into [UFSystem].[dbo].[���׵������ձ�](��Դ����,����,��������,���ձ���,����)
        values('111111','222222','333333','444444','555555')

else
        update [UFSystem].[dbo].[���׵������ձ�] set ���ձ��� = '444444'
         where ��Դ���� = '111111' and ���� = '222222' and �������� = '333333' and ���� = '555555'
";

                        sSQL = sSQL.Replace("111111", s��Դ����);
                        sSQL = sSQL.Replace("222222", s����);
                        sSQL = sSQL.Replace("333333", gridView1.GetRowCellValue(i, gridCol��������).ToString().Trim());
                        sSQL = sSQL.Replace("444444", gridView1.GetRowCellValue(i, gridCol���ձ���).ToString().Trim());
                        sSQL = sSQL.Replace("555555", gridView1.GetRowCellValue(i, gridCol����).ToString().Trim());
                      
                         SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }

                    tran.Commit();
                    MessageBox.Show("����ɹ�", "��ʾ");

                    btnRefresh_Click(null, null);
                    gridView1.FocusedRowHandle = iFoc;
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                DialogResult d = MessageBox.Show("ȷ��ɾ��ѡ������ô��", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (d != DialogResult.Yes)
                {
                    return;
                }


                int iFoc = 0;
                if (gridView1.FocusedRowHandle > 0)
                    iFoc = gridView1.FocusedRowHandle;

                string sSQL = "";

                DataTable dtGrid = (DataTable)gridControl1.DataSource;

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //��������
                SqlTransaction tran = conn.BeginTransaction();

                for (int i = 0; i < gridView1.RowCount;i++ )
                {
                    if (SqlHelper.ReturnObjectToBool(gridView1.GetRowCellValue(i, gridColѡ��)))
                    {
                        sSQL = "delete [UFSystem].[dbo].[���׵������ձ�] where iID = " + gridView1.GetRowCellValue(i, gridColiID);

                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                }

                tran.Commit();
                MessageBox.Show("ɾ���ɹ�", "��ʾ");

                btnRefresh_Click(null,null);
                gridView1.FocusedRowHandle = iFoc;
            }
            catch (Exception ee)
            {
                MessageBox.Show("ɾ��ʧ��:" + ee.Message);
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView1.FocusedRowHandle > 0)
                {
                    iRow = gridView1.FocusedRowHandle;
                }
                if (e.Column != gridColѡ��)
                {
                    gridView1.SetRowCellValue(iRow, gridColѡ��, true);
                }
            }
            catch { }
        }
    }
}