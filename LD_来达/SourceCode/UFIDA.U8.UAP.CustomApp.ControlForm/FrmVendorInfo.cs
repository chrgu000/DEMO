using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class FrmVendorInfo : Form
    {
        public string sVenCode = "";
        public string sVenName = "";
        public string sVenAbbName = "";
        public string streeid="";

        string sTreeNodeTag = "";

        public FrmVendorInfo(string sInv)
        {
            InitializeComponent();
            textVenNew.Text = sInv;

            sTreeNodeTag = "";
        }

        public FrmVendorInfo(string sInv, string treeid)
        {
            InitializeComponent();
            textVenNew.Text = sInv;
            streeid = treeid;
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                GetVenClass();

                if (textVenNew.Text.Trim() != "" || streeid != "")
                {
                    GetVendor();
                }

                treeView1.ExpandAll();
                GetVendor();
            }
            catch (Exception ee)
            {
                //MessageBox.Show("获得存货参照失败！  " + ee.Message);
            }
        }

        private void GetVendor()
        {
            try
            {
                string sSQL = @"
select cast(0 as bit) as ischk,*,cVenDefine7 as Brand 
from Vendor a left join  VendorClass b on a.cVCCode  =b.cVCCode   where 1=1 and isnull(cVenDefine3 ,'') = 'Y'
";
                if (textVenNew.Text.Trim() != string.Empty)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and (cVenCode like '%" + textVenNew.Text.Trim() + "%' or cVenName like '%" + textVenNew.Text.Trim() + "%' or cVenDefine7 like '%" + textVenNew.Text.Trim() + "%') ");
                }

                if (sTreeNodeTag != "")
                {
                    sSQL = sSQL.Replace("1=1", " 1=1 and b.cVCCode  like '" + sTreeNodeTag + "%'");
                    sSQL = sSQL.Replace("node0", "");
                }


                sSQL = sSQL + " order by cVenCode,a.cVCCode";
                DataTable dt = TH.BaseClass.DbHelperSQL.Query(sSQL);
                gridControl1.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败:" + ee.Message);
            }
        }

        private void GetVenClass()
        {
            try
            {
                string sSQL = "select cVCCode,cVCName,iVCGrade,bVCEnd from  VendorClass  order by cVCCode";
                DataTable dt = TH.BaseClass.DbHelperSQL.Query(sSQL);

                TreeNode tn = treeView1.Nodes[0]; 
                GetLev(tn, dt, 0);
            }
            catch (Exception ee)
            {
                throw new Exception("获得存货分类失败！  " + ee.Message);
            }
        }

        private void GetLev(TreeNode tn, DataTable dt,int cgrade)
        {
            try
            {
                cgrade = cgrade + 1;

                string sFi = "cVCCode like '" + tn.Tag.ToString().Trim() + "%' and iVCGrade='" + cgrade + "'";
                sFi = sFi.Replace("node0", "");
                DataRow[] dw = dt.Select(sFi);
                for (int i = 0; i < dw.Length; i++)
                {
                    TreeNode tn1 = new TreeNode();
                    tn1.Tag = dw[i]["cVCCode"].ToString().Trim();
                    tn1.Text = dw[i]["cVCCode"].ToString().Trim() + "  " + dw[i]["cVCName"].ToString().Trim();
                    tn.Nodes.Add(tn1);
                    if (dw[i]["cVCName"].ToString().Trim() == streeid)
                    {
                        tn.Expand();
                        tn.Checked = true;
                    }
                    GetLev(tn1, dt, cgrade);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("操作失败：" + ee.Message);
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                sTreeNodeTag = e.Node.Tag.ToString().Trim();
                GetVendor();
            }
            catch (Exception ee)
            {
                MessageBox.Show("操作失败：" + ee.Message);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView1.RowCount > 0)
                {
                    iRow = gridView1.FocusedRowHandle;
                }
                sVenCode="";sVenName="";sVenAbbName="";
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridColChk)) == true)
                    {
                        if (sVenCode == "")
                        {
                            sVenCode = gridView1.GetRowCellValue(i, gridColcVenCode).ToString().Trim();
                            if (gridView1.GetRowCellValue(i, gridColcVenName).ToString().Trim() != "")
                            {
                                sVenName = gridView1.GetRowCellValue(i, gridColcVenName).ToString().Trim();
                            }
                            else
                            {
                                sVenName = "Null";
                            }
                            if (gridView1.GetRowCellValue(i, gridColcVenAbbName).ToString().Trim() != "")
                            {
                                sVenAbbName = gridView1.GetRowCellValue(i, gridColcVenAbbName).ToString().Trim();
                            }
                            else
                            {
                                sVenAbbName = "Null";
                            }
                        }
                        else
                        {
                            sVenCode = sVenCode + "," + gridView1.GetRowCellValue(i, gridColcVenCode).ToString().Trim();
                            if (gridView1.GetRowCellValue(i, gridColcVenName).ToString().Trim() != "")
                            {
                                sVenName = sVenName + "," + gridView1.GetRowCellValue(i, gridColcVenName).ToString().Trim();
                            }
                            else
                            {
                                sVenName = sVenName + "," + "Null";
                            }
                            if (gridView1.GetRowCellValue(i, gridColcVenAbbName).ToString().Trim() != "")
                            {
                                sVenAbbName = sVenAbbName + "," + gridView1.GetRowCellValue(i, gridColcVenAbbName).ToString().Trim();
                            }
                            else
                            {
                                sVenAbbName = sVenAbbName + "," + "Null";
                            }
                        }
                    }
                }
                DialogResult = DialogResult.OK;
            }
            catch (Exception ee)
            {
                MessageBox.Show("返回存货信息失败！  " + ee.Message);
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

                sVenCode = gridView1.GetRowCellValue(iRow, gridColcVenCode).ToString().Trim();
                sVenName = gridView1.GetRowCellValue(iRow, gridColcVenName).ToString().Trim();
                sVenAbbName = gridView1.GetRowCellValue(iRow, gridColcVenAbbName).ToString().Trim();

                DialogResult = DialogResult.OK;
            }
            catch (Exception ee)
            {
                MessageBox.Show("返回存货信息失败！  " + ee.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ItemChk_CheckedChanged(object sender, EventArgs e)
        {
            int iRow = gridView1.FocusedRowHandle;
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (i == iRow)
                {
                    continue;
                }
                else
                {
                    gridView1.SetRowCellValue(i, gridColChk, false);
                }
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

        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                GetVendor();
            }
            catch { }
        }

        private void textVenNew_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    GetVendor();
                }
            }
            catch { }
        }
    }
}