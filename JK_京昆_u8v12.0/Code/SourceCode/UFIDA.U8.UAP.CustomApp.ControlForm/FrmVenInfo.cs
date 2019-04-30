using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class FrmVenInfo : Form
    {
        public string cVenCode = "";
        public string cVenName = "";
        public string sInvStd = "";
        public bool isAll = false;
        public string streeid="";
        public string Conn { get; set; }

        public FrmVenInfo(string cVen,string conn,bool sisAll)
        {
            try
            {
                Conn = conn;

                InitializeComponent();
                //textInvNew.Text = sInv;
                isAll = sisAll;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        public FrmVenInfo(string cVen, string treeid, string conn, bool sisAll)
        {
            try
            {
                Conn = conn;

                InitializeComponent();
                //textInvNew.Text = sInv;
                isAll = sisAll;
                streeid = treeid;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void FrmVenInfo_Load(object sender, EventArgs e)
        {
            try
            {
                checkBox1.Enabled = isAll;
                
                GetVenClass();

                if (textVenNew.Text.Trim() != "" || streeid!="")
                    GetVen();
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得供应商参照失败！  " + ee.Message);
            }
        }

        private void GetVen()
        {
            try
            {
                string sSQL = "select cast(0 as bit) as ischk,* from Vendor a left join VendorClass b on a.cVCCode =b.cVCCode  where 1=1";
                if (textVenNew.Text.Trim() != string.Empty)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and (cVenCode  like '%" + textVenNew.Text.Trim() + "%' or cVenName  like '%" + textVenNew.Text.Trim() + "%') ");
                }

                if (treeView1.SelectedNode.Tag.ToString().Trim() != string.Empty)
                {
                    sSQL = sSQL.Replace("1=1", " 1=1 and b.cVCCode  like '%" + treeView1.SelectedNode.Tag.ToString().Trim() + "%'");
                }


                sSQL = sSQL + " order by cVenCode,a.cVCCode";
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
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
                string sSQL = "select cVCCode,cVCName ,iVCGrade,bVCEnd from VendorClass  order by cVCCode";
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];

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
                        if (dt.Rows[i]["cVCName"].ToString().Trim() == streeid)
                        {
                            tn.Expand();
                            tn.Checked = true;
                        }
                        GetLev(tn, dt);
                    }
                }
            }
            catch (Exception ee)
            {
                throw new Exception("获得供应商分类失败！  " + ee.Message);
            }
        }

        private void GetLev(TreeNode tn, DataTable dt)
        {
            try
            {
                DataRow[] dw = dt.Select("cVCCode like '" + tn.Tag.ToString().Trim() + "%' and iVCGrade='" + (1 + (tn.Tag.ToString().Trim().Length) / 2) + "'");
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
                    GetLev(tn1, dt);
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
                string sSQL = "select cast(0 as bit) as ischk,* from Vendor where 1=1 "
               + " and (cVenCode like '" + e.Node.Tag.ToString().Trim() + "%' or cVCCode like '" + e.Node.Tag.ToString().Trim() + "%')";
                if (textVenNew.Text.Trim() != string.Empty)
                {
                    sSQL = sSQL + " and (cVenCode like '%" + textVenNew.Text.Trim() + "%' or cVenName like '%" + textVenNew.Text.Trim() + "%') ";
                }

                sSQL = sSQL + " order by cVenCode,cVCCode";
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                gridControl1.DataSource = dt;
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
                cVenCode="";cVenName="";sInvStd="";
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridColChk)) == true)
                    {
                        if (cVenCode == "")
                        {
                            cVenCode = gridView1.GetRowCellValue(i, gridColcVenCode).ToString().Trim();
                            if (gridView1.GetRowCellValue(i, gridColcVenName).ToString().Trim() != "")
                            {
                                cVenName = gridView1.GetRowCellValue(i, gridColcVenName).ToString().Trim();
                            }
                            else
                            {
                                cVenName = "Null";
                            }
                            if (gridView1.GetRowCellValue(i, gridColcVenEnName).ToString().Trim() != "")
                            {
                                sInvStd = gridView1.GetRowCellValue(i, gridColcVenEnName).ToString().Trim();
                            }
                            else
                            {
                                sInvStd = "Null";
                            }
                        }
                        else
                        {
                            cVenCode = cVenCode + "," + gridView1.GetRowCellValue(i, gridColcVenCode).ToString().Trim();
                            if (gridView1.GetRowCellValue(i, gridColcVenName).ToString().Trim() != "")
                            {
                                cVenName = cVenName + "," + gridView1.GetRowCellValue(i, gridColcVenName).ToString().Trim();
                            }
                            else
                            {
                                cVenName = cVenName + "," + "Null";
                            }
                            if (gridView1.GetRowCellValue(i, gridColcVenEnName).ToString().Trim() != "")
                            {
                                sInvStd = sInvStd + "," + gridView1.GetRowCellValue(i, gridColcVenEnName).ToString().Trim();
                            }
                            else
                            {
                                sInvStd = sInvStd + "," + "Null";
                            }
                        }
                    }
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

                cVenCode = gridView1.GetRowCellValue(iRow, gridColcVenCode).ToString().Trim();
                cVenName = gridView1.GetRowCellValue(iRow, gridColcVenName).ToString().Trim();
                sInvStd = gridView1.GetRowCellValue(iRow, gridColcVenEnName).ToString().Trim();

                DialogResult = DialogResult.OK;
            }
            catch (Exception ee)
            {
                MessageBox.Show("返回供应商信息失败！  " + ee.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void textInvNew_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (textVenNew.Text.Trim() != "")
                    GetVen();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                GetChk(checkBox1.Checked);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void GetChk(bool b)
        {
            try
            {
                if (b == false)
                {
                    checkBox1.Text = "全选";
                }
                else
                {
                    checkBox1.Text = "全部取消";
                }
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridColChk, b);
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void ItemChk_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (isAll == false)
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

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}