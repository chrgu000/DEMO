using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Xml;
using System.Data.SqlClient;
using UFIDA.U8.UAP.CustomApp.MetaData;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class Frm������Ŀ : UserControl
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

        public Frm������Ŀ()
        {
            InitializeComponent();
        }


        private void ProjectManager_Load(object sender, EventArgs e)
        {
            try
            {
                ϵͳ����.���.GetGridViewSet(gridView1);
                GetLookUp();
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("��������ʧ��");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetGrid();
        }

        private void GetGrid()
        {
            try
            {
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, "select *, 'edit' as iSave from _QC ").Tables[0];

                gridControl1.DataSource = dt;
                gridView1.FocusedRowHandle = 0;
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0)
                return;
            e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int iRow = 0;
            if (gridView1.FocusedRowHandle >= 0)
            {
                iRow = gridView1.FocusedRowHandle;
            }

            #region
            if (e.Column != gridColiSave && gridView1.GetRowCellDisplayText(iRow, gridColiSave).ToString().Trim() == "")
            {
                gridView1.SetRowCellValue(iRow, gridColiSave, "add");
            }
            if (e.Column != gridColiSave && gridView1.GetRowCellDisplayText(iRow, gridColiSave).ToString().Trim() == "edit")
            {
                gridView1.SetRowCellValue(iRow, gridColiSave, "update");
            }
            #endregion
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int iRow = 0;
            if (gridView1.FocusedRowHandle >= 0)
            {
                iRow = gridView1.FocusedRowHandle;
            }
            if (gridView1.GetRowCellDisplayText(iRow, gridColiSave).ToString().Trim() == "edit" || gridView1.GetRowCellDisplayText(iRow, gridColiSave).ToString().Trim() == "update")
            {
                gridColQCCode.OptionsColumn.AllowEdit = false;
            }
            else
            {
                gridColQCCode.OptionsColumn.AllowEdit = true;
            }
        }


        private void btnExcel_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    grvDetail.PostEditor();
            //    this.Validate();

            //    SaveFileDialog sa = new SaveFileDialog();
            //    sa.Filter = "Excel�ļ�2003|*.xls";
            //    sa.FileName = "ƾ֤";

            //    DialogResult d = sa.ShowDialog();
            //    if (d == DialogResult.OK)
            //    {
            //        string sPath = sa.FileName;

            //        if (sPath.Trim() != string.Empty)
            //        {
            //            grvDetail.ExportToXls(sPath);
            //            MessageBox.Show("�����б�ɹ���\n·����" + sPath);
            //        }
            //    }
            //    grvDetail.OptionsBehavior.Editable = false;
            //}
            //catch (Exception ee)
            //{
            //    MessageBox.Show("�����б�ʧ�ܣ�" + ee.Message);
            //}
        }

        private void GetLookUp()
        {
            try
            {
            }
            catch (Exception ee)
            {
                MessageBox.Show("��ò�����Ϣʧ�ܣ�" + ee.Message);
            }
        }

        private void GetTable(DataTable dt, string name)
        {
            DataRow dw = dt.NewRow();
            dw[0] = name;
            dt.Rows.Add(dw);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sErr = "";
            SqlConnection conn = new SqlConnection(Conn);
            conn.Open();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridColiSave).ToString().Trim() == "add" || gridView1.GetRowCellValue(i, gridColiSave).ToString().Trim() == "update")
                    {
                        if (gridView1.GetRowCellValue(i, gridColQCCode).ToString().Trim() != "" || gridView1.GetRowCellValue(i, gridColQCName).ToString().Trim() != "")
                        {
                            if (gridView1.GetRowCellValue(i, gridColQCCode).ToString().Trim() == "")
                            {
                                sErr = sErr + "��" + (i + 1) + "  " + gridColQCCode.Caption + "����Ϊ��\n";
                            }
                            if (gridView1.GetRowCellValue(i, gridColQCName).ToString().Trim() == "")
                            {
                                sErr = sErr + "��" + (i + 1) + "  " + gridColQCName.Caption + "����Ϊ��\n";
                            }

                            for (int j = 0; j < i; j++)
                            {
                                if (gridView1.GetRowCellValue(i, gridColQCCode).ToString().Trim() == (gridView1.GetRowCellValue(j, gridColQCCode).ToString().Trim()))
                                {
                                    sErr = sErr + "��" + (i + 1) + "  " + gridColQCCode.Caption + "�����ظ���\n";
                                    continue;
                                }
                                if (gridView1.GetRowCellValue(i, gridColQCName).ToString().Trim() == (gridView1.GetRowCellValue(j, gridColQCName).ToString().Trim()))
                                {
                                    sErr = sErr + "��" + (i + 1) + "  " + gridColQCName.Caption + "�����ظ���\n";
                                    continue;
                                }
                            }

                            DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, "select * from _QC with(nolock) where QCCode='" + gridView1.GetRowCellValue(i, gridColQCCode).ToString().Trim() + "'").Tables[0];
                            if (dt.Rows.Count > 0)
                            {
                                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, "update _QC set QCName='" + gridView1.GetRowCellValue(i, gridColQCName).ToString().Trim() + "',Remark='" + gridView1.GetRowCellValue(i, gridColRemark).ToString().Trim() + "' where QCCode='" + gridView1.GetRowCellValue(i, gridColQCCode).ToString().Trim() + "'");
                            }
                            else
                            {
                                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, "insert into _QC(QCCode,QCName,Remark) values('" + gridView1.GetRowCellValue(i, gridColQCCode).ToString().Trim() + "','" + gridView1.GetRowCellValue(i, gridColQCName).ToString().Trim() + "','" + gridView1.GetRowCellValue(i, gridColRemark).ToString().Trim() + "')");
                            }
                        }
                    }

                }

                if (sErr != "")
                {
                    throw new Exception(sErr);
                }                
                MessageBox.Show("����ɹ�");
                tran.Commit();
                GetGrid();
            }
            catch (Exception ee)
            {
                tran.Rollback();
                MessageBox.Show(ee.Message);
            }
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            gridView1.AddNewRow();
            gridView1.FocusedRowHandle = gridView1.RowCount - 1;
            gridView1.FocusedRowHandle = gridView1.RowCount - 2;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            string sErr = "";
            SqlConnection conn = new SqlConnection(Conn);
            conn.Open();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                DialogResult dr = MessageBox.Show("�Ƿ�ɾ��?", "ɾ����ʾ", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    for (int i = gridView1.RowCount - 1; i >= 0; i--)
                    {
                        if (gridView1.IsRowSelected(i))
                        {
                            DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, "select * from _QCcInvCode with(nolock) where QCCode='" + gridView1.GetRowCellValue(i, gridColQCCode).ToString().Trim() + "'").Tables[0];
                            if (dt.Rows.Count == 0)
                            {
                                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, "delete _QC where QCCode='" + gridView1.GetRowCellValue(i, gridColQCCode).ToString().Trim() + "'");
                            }
                            else
                            {
                                sErr = sErr + "��" + (i + 1) + gridView1.GetRowCellValue(i, gridColQCCode).ToString().Trim() + "��ʹ�ò���ɾ��\n";
                            }
                        }
                    }
                    if (sErr != "")
                    {
                        throw new Exception(sErr);
                    }
                    MessageBox.Show("ɾ���ɹ�");
                    tran.Commit();
                    GetGrid();
                }
            }
            catch (Exception ee)
            {
                tran.Rollback();
                MessageBox.Show(ee.Message);
            }
        }

        
    }
}