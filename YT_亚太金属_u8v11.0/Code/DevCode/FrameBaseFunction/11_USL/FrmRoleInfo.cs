using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FrameBaseFunction
{
    public partial class FrmRoleInfo : FrameBaseFunction.FrmFromModel
    {
        public FrmRoleInfo()
        {
            InitializeComponent(); 
        }

        FrameBaseFunction.Model.ClsRoleInfoMod clsRoleMod = new FrameBaseFunction.Model.ClsRoleInfoMod();
        FrameBaseFunction.Query.ClsRoleInfoQuery clsQuery = new FrameBaseFunction.Query.ClsRoleInfoQuery();
      
        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "add":
                        btnAdd();
                        break;
                    case "edit":
                        btnEdit();
                        break;
                    case "close":
                        btnClose();
                        break;
                    case "open":
                        btnOpen();
                        break;
                    case "readd":
                        btnReAdd();
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

        private void btnReAdd()
        {
            string sRoleID = GetFocRoleID();

            DialogResult dRes = MessageBox.Show("确定启用角色： " + sRoleID + " 么？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (dRes == DialogResult.Yes)
            {
                FrameBaseFunction.Bll.ClsRoleInfoBll clsBll = new FrameBaseFunction.Bll.ClsRoleInfoBll();
                clsBll.UnDelete(sRoleID);
            }

            int iRow = GetFocRowID();
            GetGridView();
            gridView1.FocusedRowHandle = iRow;
        }

        private void GetGridView()
        {
            DataTable dt = clsQuery.GetAllDt();
            gridControl1.DataSource = dt;
        }

        private void btnAdd()
        {
            try
            {
                FrmRoleEdit frmEdit = new FrmRoleEdit(this.BackColor);
                frmEdit.ShowDialog();

                GetGridView();
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }


        private void SetMod(DataRow dr)
        {
            clsRoleMod.bClosed = Convert.ToBoolean(dr["bClosed"]);
            clsRoleMod.dtmCreate = Convert.ToDateTime(dr["dtmCreate"]);
            clsRoleMod.vchrRemark = dr["vchrRemark"].ToString();
            clsRoleMod.vchrRoleID = dr["vchrRoleID"].ToString();
            clsRoleMod.vchrRoleText = dr["vchrRoleText"].ToString();
        }

        private void btnEdit()
        {
            try
            {
                DataTable dt = (DataTable)gridControl1.DataSource;
                int iRow = GetFocRowID();
                SetMod(dt.Rows[iRow]);

                if (clsRoleMod.bClosed)
                    throw new Exception("已经关闭，不能修改！");

                FrmRoleEdit frmEdit = new FrmRoleEdit(this.BackColor, clsRoleMod);
                frmEdit.ShowDialog();

                iRow = GetFocRowID();
                GetGridView();
                gridView1.FocusedRowHandle = iRow;

            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        private void btnOpen()
        {
            string sRoleID = GetFocRoleID();

            DialogResult dRes = MessageBox.Show("确定打开角色： " + sRoleID + " 么？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (dRes == DialogResult.Yes)
            {
                FrameBaseFunction.Bll.ClsRoleInfoBll clsBll = new FrameBaseFunction.Bll.ClsRoleInfoBll();
                clsBll.UnDelete(sRoleID);
            }

            int iRow = GetFocRowID();
            GetGridView();
            gridView1.FocusedRowHandle = iRow;
        }

        private void btnClose()
        {
            string sRoleID = GetFocRoleID();

            DialogResult dRes = MessageBox.Show("确定关闭角色： " + sRoleID + " 么？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (dRes == DialogResult.Yes)
            {
                FrameBaseFunction.Bll.ClsRoleInfoBll clsBll = new FrameBaseFunction.Bll.ClsRoleInfoBll();
                clsBll.Delete(sRoleID);
            }

            int iRow = GetFocRowID();
            GetGridView();
            gridView1.FocusedRowHandle = iRow;
        }



        private string GetFocRoleID()
        {
            int iRow = 0;
            if (gridView1.RowCount > 1)
                iRow = gridView1.FocusedRowHandle;

            string sRoleID = gridView1.GetRowCellValue(iRow, colvchrRoleID).ToString().Trim();

            return sRoleID;
        }



        private int GetFocRowID()
        {
            int iRow = 0;
            if (gridView1.RowCount > 1)
                iRow = gridView1.FocusedRowHandle;

            return iRow;
        }

        /// <summary>
        /// 获得表格值
        /// </summary>
        private void GetGridInfo()
        {
            FrameBaseFunction.Query.ClsRoleInfoQuery clsQuery = new FrameBaseFunction.Query.ClsRoleInfoQuery();
            DataTable dt = clsQuery.GetAllDt();
            gridControl1.DataSource = dt;
        }

        private void FrmRoleInfo_Load(object sender, EventArgs e)
        {
            try
            {
                GetGridInfo();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败！ 原因如下：\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
    }
}