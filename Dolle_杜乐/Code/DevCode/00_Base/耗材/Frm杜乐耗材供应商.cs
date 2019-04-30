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
    public partial class Frm���ֺĲĹ�Ӧ�� : FrameBaseFunction.Frm�б���ģ��
    {
        DataTable dtSel = new DataTable();
        int iPage = 0;
        ArrayList aList;
        string sSQL;

        public Frm���ֺĲĹ�Ӧ��()
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
                    case "edit":
                        btnEdit();
                        break;
                    default:
                        break;
                }

                sState = sBtnName.ToLower();
            }
            catch (Exception ee)
            {
                throw new Exception(sBtnText + " ʧ��! \n\nԭ��:\n  " + ee.Message);
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

            string sErr = "";
            ArrayList aList = new ArrayList();
            string sSQL = "";
            for (int i = gridView1.RowCount - 1; i >= 0; i--)
            {
                int iChoose = ReturnObjectToInt(gridView1.GetRowCellValue(i, gridColѡ��));

                if (iChoose == 1)
                {
                    sSQL = "select count(1) from UFDLImport..VendorHC where cVenCode = '" + gridView1.GetRowCellValue(i, gridColcVenCode).ToString().Trim() + "' and isnull(bUserd,0) = 1";
                    int iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                    if (iCou > 0)
                    {
                        sErr = sErr + "�� " + (i + 1).ToString() + "�Ѿ�ʹ�ò���ɾ��\n";
                        continue;
                    }

                    sSQL = "delete UFDLImport..VendorHC  where cVenCode = '" + gridView1.GetRowCellValue(i, gridColcVenCode).ToString().Trim() + "'";
                    aList.Add(sSQL);
                }
            }

            if (sErr.Length > 0)
            {
                throw new Exception( "ɾ��ʧ��! \n\nԭ��:\n  " + sErr.Trim());
            }

            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("ɾ���ɹ�");

                btnSel();
            }
        }

        private void btnEdit()
        {
            int iRow = 0;
            if (gridView1.FocusedRowHandle > 0)
                iRow = gridView1.FocusedRowHandle;

            string scVenCode = gridView1.GetRowCellValue(iRow, gridColcVenCode).ToString().Trim();

            Frm���ֺĲĹ�Ӧ��Edit f = new Frm���ֺĲĹ�Ӧ��Edit(scVenCode);
            f.ShowDialog();

            btnSel();
        }

        private void btnAdd()
        {
            Frm���ֺĲĹ�Ӧ��Edit f = new Frm���ֺĲĹ�Ӧ��Edit();
            f.ShowDialog();

            btnSel();
        }

        private void btnSel()
        {
            int iFoc = 0;
            if (gridView1.FocusedRowHandle > 0)
                iFoc = gridView1.FocusedRowHandle;

            string sSQL = @"
select cast(0 as bit) as ѡ��, * 
from UFDLImport..VendorHC a
where 1=1 
order by a.cVenCode
";
          
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;
            gridView1.FocusedRowHandle = iFoc;

        }

        #region ��ťģ��

      
        /// <summary>
        /// ���
        /// </summary>
        private void btnExport()
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
                sF.Filter = "Excel�ļ�(*.xls)|*.xls|�����ļ�(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridView1.ExportToXls(sF.FileName);
                    MessageBox.Show("����Excel�ɹ�\n\t·����" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

      
        #endregion






        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                btnSel();
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

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView1.FocusedRowHandle > 0)
                    iRow = gridView1.FocusedRowHandle;

                string scVenCode = gridView1.GetRowCellValue(iRow, gridColcVenCode).ToString().Trim();
                if (scVenCode != "")
                {
                    Frm���ֺĲĹ�Ӧ��Edit f = new Frm���ֺĲĹ�Ӧ��Edit(scVenCode);
                    f.ShowDialog();

                    btnSel();
                }
            }
            catch { }
        }

    }
}