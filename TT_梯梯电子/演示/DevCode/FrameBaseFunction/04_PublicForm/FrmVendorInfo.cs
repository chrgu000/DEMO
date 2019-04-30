using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FrameBaseFunction
{
    public partial class FrmVendorInfo : Form
    {
        FrameBaseFunction.ClsDataBase clsSQL = FrameBaseFunction.ClsDataBaseFactory.Instance();

        public string sVenCode = "";
        public string sVenName = "";
        bool b多选 = false;

        public FrmVendorInfo(string sVen)
        {
            InitializeComponent();

            txtVen.Text = sVen;
        }

        public FrmVendorInfo(string sVen,bool b是否多选)
        {
            InitializeComponent();

            txtVen.Text = sVen;

            b多选 = b是否多选;
        }

        private void FrmVenInfo_Load(object sender, EventArgs e)
        {
            try
            {
                chk全选.Checked = true;

                GetVendorClass();

                GetVen1();
                GetVen2();
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得供应商参照失败！  " + ee.Message);
            }
        }

        private void GetVen1()
        {
            chk全选.Checked = false;

            string sSQL = "select cast(0 as bit) as bChoose,cVenCode,cVenName,cVenAbbName from @u8.Vendor where 1=1 ";
            if (txtVen.Text.Trim() != string.Empty)
            {
                string[] sVen = txtVen.Text.Trim().Split(',');
                if (sVen.Length > 0)
                {
                    string s = "";
                    for (int i = 0; i < sVen.Length; i++)
                    {
                        if (s == "")
                        {
                            s = "'" + sVen[i] + "'";
                        }
                        else
                        {
                            s = s + ",'" + sVen[i] + "'";
                        }
                    }
                     sSQL = sSQL + " and cVenCode not in (" + s + ")";
                }
                else
                {
                    sSQL = sSQL + " and (cVenCode like '%" + txtVen.Text.Trim() + "%' or cVenName like '%" + txtVen.Text.Trim() + "%') ";
                }
            }

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

            sSQL = sSQL + " order by cVenCode,cVCCode";
            DataTable dt = clsSQL.ExecQuery(sSQL);
            gridControl1.DataSource = dt;
        }


        private void GetVen2()
        {
            chk全选.Checked = false;

            string sSQL2 = "select cast(0 as bit) as bChoose,cVenCode,cVenName,cVenAbbName from @u8.Vendor where 1=-1  ";
            if (txtVen.Text.Trim() != string.Empty)
            {
                string[] sVen = txtVen.Text.Trim().Split(',');
                if (sVen.Length > 0)
                {
                    string s = "";
                    for (int i = 0; i < sVen.Length; i++)
                    {
                        if (s == "")
                        {
                            s = "'" + sVen[i] + "'";
                        }
                        else
                        {
                            s = s + ",'" + sVen[i] + "'";
                        }
                    }
                    sSQL2 = sSQL2.Replace("1=-1", "1=1 and cVenCode in (" + s + ")");
                }
            }
            DataTable dt = clsSQL.ExecQuery(sSQL2);
            gridControl2.DataSource = dt;
        }

        private void GetVendorClass()
        {
            try
            {
                string sSQL = "select cVCCode,cVCName,iVCGrade,bVCEnd from @u8.VendorClass order by cVCCode";
                DataTable dt = clsSQL.ExecQuery(sSQL);

                TreeNode tn;
                TreeNode tn2;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dt.Rows[i]["iVCGrade"]) == 1)
                    {
                        tn = new TreeNode();
                        tn.Tag = dt.Rows[i]["cVCCode"].ToString().Trim();
                        tn.Text = dt.Rows[i]["cVCCode"].ToString().Trim() + "  " + dt.Rows[i]["cVCName"].ToString().Trim();
                        treeView1.Nodes.Add(tn);
                    }
                    else
                    {
                        int iGrade = Convert.ToInt32(dt.Rows[i]["iVCGrade"]);
                        int iGradeParent = iGrade - 1;

                        foreach (TreeNode tn1 in treeView1.Nodes)
                        {
                            if (tn1.Level == iGradeParent - 1 && dt.Rows[i]["cVCCode"].ToString().Trim().StartsWith(tn1.Tag.ToString().Trim()))
                            {

                                tn2 = new TreeNode();
                                tn2.Tag = dt.Rows[i]["cVCCode"].ToString().Trim();
                                tn2.Text = dt.Rows[i]["cVCCode"].ToString().Trim() + "  " + dt.Rows[i]["cVCName"].ToString().Trim();
                                tn1.Nodes.Add(tn2);
                            }
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                throw new Exception("获得供应商分类失败！  " + ee.Message);
            }
        }

        string sNodeInfo = "";
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e != null)
            {
                sNodeInfo = e.Node.Tag.ToString().Trim();
            }
            string sSQL = "select cast(0 as bit) as bChoose, * from @u8.Vendor where 1=1 ";
            if (sNodeInfo != "")
            {
                sSQL = sSQL + " and cVCCode like '" + sNodeInfo + "%' ";
            }
            if (txtVen.Text.Trim() != string.Empty)
            {
                sSQL = sSQL + " and (cVenCode like '%" + txtVen.Text.Trim() + "%' or cVenName like '%" + txtVen.Text.Trim() + "%') ";
            }
            if (radio1.Checked)
            {
                sSQL = sSQL + " and isnull(dEndDate,'2099-12-31') >= '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' ";
            }
            else
            {
                sSQL = sSQL + " and isnull(dEndDate,'2099-12-31') < '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' "; 
            }

            sSQL = sSQL + " order by cVenCode,cVCCode";
            DataTable dt = clsSQL.ExecQuery(sSQL);
            gridControl1.DataSource = dt;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (b多选)
                {
                    try
                    {
                        gridView2.FocusedRowHandle -= 1;
                        gridView2.FocusedRowHandle += 1;
                    }
                    catch { }

                    sVenCode = "";
                    sVenName = "";

                    for (int i = 0; i < gridView2.RowCount; i++)
                    {
                        if (sVenCode == "")
                        {
                            sVenCode = gridView2.GetRowCellValue(i, gridCol_供应商编码).ToString().Trim();
                            sVenName = gridView2.GetRowCellValue(i, gridCol_供应商名称).ToString().Trim();
                        }
                        else
                        {
                            sVenCode = sVenCode + "," + gridView2.GetRowCellValue(i, gridCol_供应商编码).ToString().Trim();
                            sVenName = sVenName + "," + gridView2.GetRowCellValue(i, gridCol_供应商名称).ToString().Trim();
                        }
                    }
                }
                else
                {
                    int iRow = 0;
                    if (gridView1.RowCount > 0)
                    {
                        iRow = gridView1.FocusedRowHandle;
                    }

                    sVenCode = gridView1.GetRowCellValue(iRow, gridColcVenCode).ToString().Trim();
                    sVenName = gridView1.GetRowCellValue(iRow, gridColcVenName).ToString().Trim();
                }

                DialogResult = DialogResult.OK;
            }
            catch (Exception ee)
            {
                MessageBox.Show("返回供应商信息失败！  " + ee.Message);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView1.RowCount > 0)
                {
                    iRow = gridView1.FocusedRowHandle;
                }

                if (b多选)
                {
                    string s_VenCode = gridView1.GetRowCellValue(iRow, gridColcVenCode).ToString().Trim();
                    string s_VenName = gridView1.GetRowCellValue(iRow, gridColcVenName).ToString().Trim();
                    string s_VenAbbName = gridView1.GetRowCellValue(iRow, gridColcVenName).ToString().Trim();

                    gridView1.DeleteRow(iRow);

                    gridView2.AddNewRow();
                    gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridCol_供应商编码, s_VenCode);
                    gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridCol_供应商名称, s_VenName);
                    gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridCol_供应商简称, s_VenAbbName);
                }
                else
                {
                    sVenCode = gridView1.GetRowCellValue(iRow, gridColcVenCode).ToString().Trim();
                    sVenName = gridView1.GetRowCellValue(iRow, gridColcVenName).ToString().Trim();
                    DialogResult = DialogResult.OK;
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show("返回供应商信息失败！  " + ee.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void radio1_CheckedChanged(object sender, EventArgs e)
        {
            if (radio1.Checked)
                treeView1_NodeMouseClick(null, null);
        }

        private void radio2_CheckedChanged(object sender, EventArgs e)
        {
            if (radio2.Checked)
                treeView1_NodeMouseClick(null, null);
        }

        private void btnSEL_Click(object sender, EventArgs e)
        {
            try
            {
                string sVen = txtVen.Text.Trim();
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    string s1 = gridView1.GetRowCellValue(i, gridColcVenCode).ToString().Trim();
                    string s2 = gridView1.GetRowCellValue(i, gridColcVenName).ToString().Trim();

                    if (s1.StartsWith(sVen) || s2.StartsWith(sVen))
                    {
                        gridView1.FocusedRowHandle = i;
                    }
                }
            }
            catch { }
        }

        private void chk全选_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    //gridView1.SetRowCellValue(i, gridColbChoose, chk全选.Checked);
                }
            }
            catch (Exception ee)
            {

            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //try
            //{
            //    if (!b多选)
            //    {
            //        gridView1.FocusedColumn = gridColcVenName;
            //        gridView1.FocusedColumn = gridColcVenCode;

            //        //bool bChoose = Convert.ToBoolean(gridView1.GetRowCellValue(e.RowHandle, gridColbChoose));
            //        //if (bChoose)
            //        //{
            //            for (int i = 0; i < gridView1.RowCount; i++)
            //            {
            //                if (i == e.RowHandle)
            //                    continue;

            //                gridView1.SetRowCellValue(i, gridColbChoose, false);
            //            }
            //    }
            //}
            //catch { }
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView2.RowCount > 0)
                {
                    iRow = gridView2.FocusedRowHandle;
                }

                if (b多选)
                {
                    string s_VenCode = gridView2.GetRowCellValue(iRow, gridCol_供应商编码).ToString().Trim();
                    string s_VenName = gridView2.GetRowCellValue(iRow, gridCol_供应商名称).ToString().Trim();
                    string s_VenAbbName = gridView2.GetRowCellValue(iRow, gridCol_供应商简称).ToString().Trim();

                    gridView1.AddNewRow();
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridColcVenCode, s_VenCode);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridColcVenName, s_VenName);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridColcVenName, s_VenAbbName);

                    gridView2.DeleteRow(iRow);
                }
                else
                {
                    sVenCode = gridView1.GetRowCellValue(iRow, gridColcVenCode).ToString().Trim();
                    sVenName = gridView1.GetRowCellValue(iRow, gridColcVenName).ToString().Trim();
                    DialogResult = DialogResult.OK;
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show("返回供应商信息失败！  " + ee.Message);
            }
        }
    }
}