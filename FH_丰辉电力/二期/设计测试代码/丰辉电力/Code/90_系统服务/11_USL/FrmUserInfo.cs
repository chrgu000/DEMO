using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 系统服务
{
    public partial class FrmUserInfo : 系统服务.FrmBaseInfo
    {
        public FrmUserInfo()
        {
            InitializeComponent();
        }

        系统服务.Model.ClsUserInfoMod clsUserMod = new 系统服务.Model.ClsUserInfoMod();
        
        系统服务.ClsDES clsDES = 系统服务.ClsDES.Instance();

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
                    case "import":
                        btnImport();
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

        private void btnImport()
        {
            throw new NotImplementedException();
        }

        private void btnImprot()
        {
            //string sSQL = "insert into dbo._UserInfo(vchrUid,vchrName,vchrPwd,vchrRemark,dtmCreate,dtmClose)select cUser_Id,cUser_Name,'999','','1900-01-01','2099-12-31' from UFSystem..UA_User where cUser_Id not in (select vchrUid from _UserInfo)";
            //clsSQL.ExecSql(sSQL);
            //GetGridView();
            //MessageBox.Show("同步U8账号成功，请进入系统设置权限！");
        }

        private void btnAdd()
        {
            try
            {
                FrmUserEdit frmEdit = new FrmUserEdit(this.BackColor);
                frmEdit.ShowDialog();

                GetGridView();
            }
            catch(Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        private void btnEdit()
        {
            try
            {
                DataTable dt = (DataTable)gridControl1.DataSource;
                int iRow = GetFocRowID();
                SetMod(dt.Rows[iRow]);

                FrmUserEdit frmEdit = new FrmUserEdit(this.BackColor, clsUserMod);
                frmEdit.ShowDialog();

                iRow = GetFocRowID();
                GetGridView();
                gridView1.FocusedRowHandle = iRow;

            }
            catch(Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        private void btnDel()
        {
            string sUserID = GetFocUserID();
            DialogResult dRes = MessageBox.Show("确定删除用户： " + sUserID + " 么？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (dRes == DialogResult.Yes)
            {
                clsWeb.ClsUserInfoBllDelete(sUserID);
            }

            int iRow = GetFocRowID();
            GetGridView();
            gridView1.FocusedRowHandle = iRow - 1;

        }


        
        private void FrmUserInfo_Load(object sender, EventArgs e)
        {
            try
            {
                GetGridView();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败！ 原因如下：\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetGridView()
        {
            //系统服务.Query.ClsUserInfoQuery clsQuery = new 系统服务.Query.ClsUserInfoQuery();
            DataTable dt = clsWeb.ClsUserInfoQueryGetAllDt();
            gridControl1.DataSource = dt;
        }

        private string GetFocUserID()
        {
            int iRow = 0;
            if (gridView1.RowCount > 1)
                iRow = gridView1.FocusedRowHandle;

            string sUerID = gridView1.GetRowCellValue(iRow, colvchrUid).ToString().Trim();

            return sUerID;
        }



        private int GetFocRowID()
        {
            int iRow = 0;
            if (gridView1.RowCount > 1)
                iRow = gridView1.FocusedRowHandle;

            return iRow;
        }

        private void SetMod(DataRow dr)
        {
            clsUserMod.vchrUid = dr["vchrUid"].ToString();
            clsUserMod.vchrName = dr["vchrName"].ToString();
            clsUserMod.vchrPwd =dr["vchrPwd"].ToString();
            clsUserMod.dtmCreate = Convert.ToDateTime(dr["dtmCreate"]);
            clsUserMod.dtmClose = Convert.ToDateTime(dr["dtmClose"]);
            clsUserMod.vchrRemark = dr["vchrRemark"].ToString();
        }

    }
}