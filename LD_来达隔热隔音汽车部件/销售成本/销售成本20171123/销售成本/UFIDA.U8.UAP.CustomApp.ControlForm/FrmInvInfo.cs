using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class FrmInvInfo : Form
    {
        public string sInvCode = "";
        public string sInvName = "";
        public string sInvStd = "";
        public bool isAll = false;
        public string streeid="";
        public string Conn { get; set; }

        public FrmInvInfo(string sInv,string conn,bool sisAll)
        {
            Conn = conn;

            InitializeComponent();
            //textInvNew.Text = sInv;
            isAll = sisAll;
        }

        public FrmInvInfo(string sInv,string treeid, string conn, bool sisAll)
        {
            Conn = conn;

            InitializeComponent();
            //textInvNew.Text = sInv;
            isAll = sisAll;
            streeid = treeid;
        }

        private void FrmInvInfo_Load(object sender, EventArgs e)
        {
            try
            {
                checkBox1.Enabled = isAll;
                
                GetInvClass();

                if (textInvNew.Text.Trim() != "" || streeid!="")
                    GetInv();
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得存货参照失败！  " + ee.Message);
            }
        }

        private void GetInv()
        {
            try
            {
                string sSQL = "select cast(0 as bit) as ischk,* from Inventory a left join InventoryClass b on a.cInvCCode =b.cInvCCode  where 1=1";
                //if (textInvNew.Text.Trim() != string.Empty)
                //{
                //    sSQL = sSQL.Replace("1=1"," and (cInvCode like '%" + textInvNew.Text.Trim() + "%' or cInvName like '%" + textInvNew.Text.Trim() + "%' or 2=2) ");
                //}

                if (streeid != string.Empty)
                {
                    sSQL = sSQL.Replace("1=1"," 1=1 and b.cInvCName  like '%" + streeid + "%'");
                }


                sSQL = sSQL + " order by cInvCode,a.cInvCCode";
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                gridControl1.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败:" + ee.Message);
            }
        }

        private void GetInvClass()
        {
            try
            {
                string sSQL = "select cInvCCode,cInvCName,iInvCGrade,bInvCEnd from InventoryClass  order by cInvCCode";
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];

                TreeNode tn;
                TreeNode tn2;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dt.Rows[i]["iInvCGrade"]) == 1)
                    {
                        tn = new TreeNode();
                        tn.Tag = dt.Rows[i]["cInvCCode"].ToString().Trim();
                        tn.Text = dt.Rows[i]["cInvCCode"].ToString().Trim() + "  " + dt.Rows[i]["cInvCName"].ToString().Trim();
                        treeView1.Nodes.Add(tn);
                        if (dt.Rows[i]["cInvCName"].ToString().Trim() == streeid)
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
                throw new Exception("获得存货分类失败！  " + ee.Message);
            }
        }

        private void GetLev(TreeNode tn, DataTable dt)
        {
            try
            {
                DataRow[] dw = dt.Select("cInvCCode like '" + tn.Tag.ToString().Trim() + "%' and iInvCGrade='" + (1 + tn.Tag.ToString().Trim().Length / 2) + "'");
                for (int i = 0; i < dw.Length; i++)
                {
                    TreeNode tn1 = new TreeNode();
                    tn1.Tag = dw[i]["cInvCCode"].ToString().Trim();
                    tn1.Text = dw[i]["cInvCCode"].ToString().Trim() + "  " + dw[i]["cInvCName"].ToString().Trim();
                    tn.Nodes.Add(tn1);
                    if (dw[i]["cInvCName"].ToString().Trim() == streeid)
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
                string sSQL = "select cast(0 as bit) as ischk,* from Inventory where 1=1 "
               + " and (cInvCode like '" + e.Node.Tag.ToString().Trim() + "%' or cInvCCode like '" + e.Node.Tag.ToString().Trim() + "%')";
                if (textInvNew.Text.Trim() != string.Empty)
                {
                    sSQL = sSQL + " and (cInvCode like '%" + textInvNew.Text.Trim() + "%' or cInvName like '%" + textInvNew.Text.Trim() + "%') ";
                }

                sSQL = sSQL + " order by cInvCode,cInvCCode";
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
                sInvCode="";sInvName="";sInvStd="";
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridColChk)) == true)
                    {
                        if (sInvCode == "")
                        {
                            sInvCode = gridView1.GetRowCellValue(i, gridColcInvCode).ToString().Trim();
                            if (gridView1.GetRowCellValue(i, gridColcInvName).ToString().Trim() != "")
                            {
                                sInvName = gridView1.GetRowCellValue(i, gridColcInvName).ToString().Trim();
                            }
                            else
                            {
                                sInvName = "Null";
                            }
                            if (gridView1.GetRowCellValue(i, gridColcInvStd).ToString().Trim() != "")
                            {
                                sInvStd = gridView1.GetRowCellValue(i, gridColcInvStd).ToString().Trim();
                            }
                            else
                            {
                                sInvStd = "Null";
                            }
                        }
                        else
                        {
                            sInvCode = sInvCode + "," + gridView1.GetRowCellValue(i, gridColcInvCode).ToString().Trim();
                            if (gridView1.GetRowCellValue(i, gridColcInvName).ToString().Trim() != "")
                            {
                                sInvName = sInvName + "," + gridView1.GetRowCellValue(i, gridColcInvName).ToString().Trim();
                            }
                            else
                            {
                                sInvName = sInvName + "," + "Null";
                            }
                            if (gridView1.GetRowCellValue(i, gridColcInvStd).ToString().Trim() != "")
                            {
                                sInvStd = sInvStd + "," + gridView1.GetRowCellValue(i, gridColcInvStd).ToString().Trim();
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

                sInvCode = gridView1.GetRowCellValue(iRow, gridColcInvCode).ToString().Trim();
                sInvName = gridView1.GetRowCellValue(iRow, gridColcInvName).ToString().Trim();
                sInvStd = gridView1.GetRowCellValue(iRow, gridColcInvStd).ToString().Trim();

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

        private void textInvNew_EditValueChanged(object sender, EventArgs e)
        {
            if (textInvNew.Text.Trim() != "")
                GetInv();
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            GetChk(checkBox1.Checked);
        }

        private void GetChk(bool b)
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

        private void ItemChk_CheckedChanged(object sender, EventArgs e)
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
    }
}