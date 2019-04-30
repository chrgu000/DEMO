using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FrameBaseFunction;

namespace BasicInformation
{
    public partial class FrmStockOrderAuditGrade : FrameBaseFunction.Frm列表窗体模板
    {
        public FrmStockOrderAuditGrade()
        {
            InitializeComponent();
        }

        private void FrmStockOrderAuditGrade_Load(object sender, EventArgs e)
        {
            try
            {
                SetConEnable(true);

                GetVendorClass();
                //GetAuditGrade();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败！原因：" + ee.Message);
            }
        }

        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "save":
                        btnSave();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(sBtnText + " 失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave()
        {
            try
            {
                ArrayList aList = new ArrayList();

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "√")
                    {
                        string sSQL = "if exists(select * from UFDLImport..AuditGrade where cInvCode = '" + gridView1.GetRowCellValue(i, gridColcInvCode).ToString().Trim() + "' and accid = 200 and accyear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + " and AuditType = 1) " +
                                      "update UFDLImport..AuditGrade set AuditGrade = " + gridView1.GetRowCellValue(i, gridColAuditGrade).ToString().Trim() + " where  cInvCode = '" + gridView1.GetRowCellValue(i, gridColcInvCode).ToString().Trim() + "' and accid = 200 and accyear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + " and AuditType = 1 " +
                                "else " +
                                     "insert into UFDLImport..AuditGrade(AuditGrade,AuditType,cInvCode,AccID,AccYear)values " +
                                     "(" + gridView1.GetRowCellValue(i, gridColAuditGrade).ToString().Trim() + ",1,'" + gridView1.GetRowCellValue(i, gridColcInvCode).ToString().Trim() + "',200," + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + ")";
                        aList.Add(sSQL);
                    }
                }
                clsSQLCommond.ExecSqlTran(aList);

                MessageBox.Show("保存成功！");
            }
            catch (Exception ee)
            {
                throw new Exception("保存失败：  " + ee.Message);
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.RowCount < 1)
                    return;
                int iRow = 1;
                if (gridView1.RowCount == 1)
                    iRow = 1;
                else
                    iRow = gridView1.FocusedRowHandle;

                if (gridView1.GetRowCellValue(iRow, gridColbChoose).ToString().Trim() == "")
                {
                    gridView1.SetFocusedRowCellValue(gridColbChoose, "√");
                }
                else
                {
                    gridView1.SetFocusedRowCellValue(gridColbChoose, "");
                }
            }
            catch 
            { }

        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (gridView1.RowCount < 1)
                return;

            if (chkAll.Checked)
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridColbChoose, "√");
                }
            }
            else
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridColbChoose, "");
                }
            }
        }


        private void buttonEditGrade_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "√")
                    { 
                        gridView1.SetRowCellValue(i,gridColAuditGrade,buttonEditGrade.Text.Trim());
                    }
                }
            }
            catch ( Exception ee)
            {
                MessageBox.Show("设置物料等级失败！ " + ee.Message);
            }
        }

        private void GetVendorClass()
        {
            try
            {
                string sSQL = "select cInvCCode,cInvCName,iInvCGrade,bInvCEnd from @u8.InventoryClass order by cInvCCode,iInvCGrade";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);

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
                    }
                    else
                    {
                        int iGrade = Convert.ToInt32(dt.Rows[i]["iInvCGrade"]);
                        int iGradeParent = iGrade - 1;

                        foreach (TreeNode tn1 in treeView1.Nodes)
                        {
                            if (tn1.Level == iGradeParent - 1 && dt.Rows[i]["cInvCCode"].ToString().Trim().StartsWith(tn1.Tag.ToString().Trim()))
                            {

                                tn2 = new TreeNode();
                                tn2.Tag = dt.Rows[i]["cInvCCode"].ToString().Trim();
                                tn2.Text = dt.Rows[i]["cInvCCode"].ToString().Trim() + "  " + dt.Rows[i]["cInvCName"].ToString().Trim();
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

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                chkAll.Checked = false;

                string sSQL = "select '' as bChoose,I.cInvCode,i.cInvName,i.cInvStd,isnull(AuditGrade,2) as AuditGrade,I.cInvCCode from @u8.Inventory I left join UFDLImport..AuditGrade A  on A.cInvCode = I.cInvCode and AuditType =1 and accid = 200 and accyear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + " where I.cInvCCode like '" + e.Node.Tag.ToString().Trim() + "%'  ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                gridControl1.DataSource = dt;

                chkAll.Checked = true;
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得存货信息失败！ " + ee.Message);
            }
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

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}