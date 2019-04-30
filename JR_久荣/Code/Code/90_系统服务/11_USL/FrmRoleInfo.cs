using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 系统服务
{
    public partial class FrmRoleInfo : 系统服务.FrmBaseInfo
    {
        public FrmRoleInfo()
        {
            InitializeComponent(); 
        }

        系统服务.Model.ClsRoleInfoMod clsRoleMod = new 系统服务.Model.ClsRoleInfoMod();
        系统服务.Query.ClsRoleInfoQuery clsQuery = new 系统服务.Query.ClsRoleInfoQuery();
      
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
                    case "del":
                        btnDel();
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

        private void btnDel()
        {
            int iRow = gridView1.FocusedRowHandle;
            if(iRow >=0)
            {
                string sRoleID = gridView1.GetRowCellValue(iRow, colvchrRoleID).ToString().Trim();
                if (sRoleID.ToLower() == "administrator" || sRoleID.ToLower() == "adminserver")
                {
                    throw new Exception("系统角色，不能删除");
                }

                string sSQL = "select count(*) from dbo._UserRoleInfo where vchrRoleID = '" + sRoleID + "'";
                long iCou = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                if (iCou > 0)
                {
                    throw new Exception("角色" + sRoleID + "已经使用，不能删除");
                }
                else
                {
                    sSQL = "delete _RoleInfo where vchrRoleID = '" + sRoleID + "'";
                    clsSQLCommond.ExecSql(sSQL);

                    GetGridView();
                    gridView1.FocusedRowHandle = iRow - 1;

                    throw new Exception("角色" + sRoleID + "已经删除");
                }
            }
        }

        private void btnReAdd()
        {
            string sRoleID = GetFocRoleID();

            DialogResult dRes = MessageBox.Show("确定启用角色： " + sRoleID + " 么？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (dRes == DialogResult.Yes)
            {
                系统服务.Bll.ClsRoleInfoBll clsBll = new 系统服务.Bll.ClsRoleInfoBll();
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
                系统服务.Bll.ClsRoleInfoBll clsBll = new 系统服务.Bll.ClsRoleInfoBll();
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
                系统服务.Bll.ClsRoleInfoBll clsBll = new 系统服务.Bll.ClsRoleInfoBll();
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
            系统服务.Query.ClsRoleInfoQuery clsQuery = new 系统服务.Query.ClsRoleInfoQuery();
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