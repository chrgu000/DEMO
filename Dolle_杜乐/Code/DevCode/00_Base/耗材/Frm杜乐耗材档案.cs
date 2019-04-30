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
    public partial class Frm���ֺĲĵ��� : FrameBaseFunction.Frm�б���ģ��
    {
        DataTable dtSel = new DataTable();
        int iPage = 0;
        ArrayList aList;
        string sSQL;

        public Frm���ֺĲĵ���()
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
                    sSQL = "select count(1) from UFDLImport..InventoryHC where cInvCode = '" + gridView1.GetRowCellValue(i, gridColcInvCode).ToString().Trim() + "' and isnull(bUserd,0) = 1";
                    int iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                    if (iCou > 0)
                    {
                        sErr = sErr + "�� " + (i + 1).ToString() + "�Ѿ�ʹ�ò���ɾ��\n";
                        continue;
                    }

                    sSQL = "delete UFDLImport..InventoryHC  where cInvCode = '" + gridView1.GetRowCellValue(i, gridColcInvCode).ToString().Trim() + "'";
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

            string scInvCode = gridView1.GetRowCellValue(iRow, gridColcInvCode).ToString().Trim();

            Frm���ֺĲĵ���Edit f = new Frm���ֺĲĵ���Edit(scInvCode);
            f.ShowDialog();

            btnSel();
        }

        private void btnAdd()
        {
            Frm���ֺĲĵ���Edit f = new Frm���ֺĲĵ���Edit();
            f.ShowDialog();

            btnSel();
        }

        private void btnSel()
        {
            setLookUp();

            SetTree();

            string sSQL = @"
SELECT     cInvCCode, cInvCName, cInvCCodeUp
FROM         UFDLImport..InvcodeClassHC
WHERE     cInvCCode NOT IN
                          (SELECT     cInvCCodeUp
                            FROM          UFDLImport..InvcodeClassHC AS a)
ORDER BY cInvCCode
";

            ItemLookUpEditcInvCCode.DataSource  = clsSQLCommond.ExecQuery(sSQL);

            int iFoc = 0;
            if (gridView1.FocusedRowHandle > 0)
                iFoc = gridView1.FocusedRowHandle;

            sSQL = @"
select cast(0 as bit) as ѡ��, * 
from UFDLImport..InventoryHC a
where 1=1 
order by a.cInvCode
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

                string scInvCode = gridView1.GetRowCellValue(iRow, gridColcInvCode).ToString().Trim();
                if (scInvCode != "")
                {
                    Frm���ֺĲĵ���Edit f = new Frm���ֺĲĵ���Edit(scInvCode);
                    f.ShowDialog();

                    btnSel();
                }
            }
            catch { }
        }

        private void treView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Node.Name.Trim() != null)
                {
                    string sCCode = e.Node.Name.Trim();

                    sSQL = @"
select cast(0 as bit) as ѡ��, * 
from UFDLImport..InventoryHC a
where 1=1 
order by a.cInvCode
";
                    sSQL = sSQL.Replace("1=1", "1=1 and cInvCCode like '" + sCCode + "%'");
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    gridControl1.DataSource = dt;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }


        DataTable dt = new DataTable();
        private void SetTree()
        {
            try
            {
                treView.Nodes.Clear();

                string sSQL = "SELECT * from UFDLImport..InvcodeClassHC order by cInvCCode";
                dt = clsSQLCommond.ExecQuery(sSQL);

                InitTree(treView.Nodes, "0");

            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="Nds"></param>
        /// <param name="parentId"></param>
        private void InitTree(TreeNodeCollection Nds, string parentId)
        {
            try
            {
                DataView dv = new DataView();
                TreeNode tmpNd;
                dv.Table = dt;
                dv.RowFilter = "cInvCCodeUp='" + parentId + "'";
                foreach (DataRowView drv in dv)
                {
                    tmpNd = new TreeNode();
                    tmpNd.Name = drv["cInvCCode"].ToString().Trim();
                    tmpNd.Text = drv["cInvCName"].ToString().Trim();
                    tmpNd.Tag = drv["cInvCCodeUp"].ToString().Trim();
                    Nds.Add(tmpNd);
                    InitTree(tmpNd.Nodes, tmpNd.Name);
                }
            }
            catch
            {
                throw new Exception("����������ʧ�ܣ�");
            }
        }

        private void setLookUp()
        {
            string sSQL = "select cVenCode,cVenName from UFDLImport..VendorHC order by cVenCode";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            ItemLookUpEditcVenCode.Properties.DataSource = dt;
            ItemLookUpEditcVenName.Properties.DataSource = dt;
        }
    }
}