using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FrameBaseFunction
{
    public partial class FrmUserInfo : FrameBaseFunction.FrmFromModel
    {
        public FrmUserInfo()
        {
            InitializeComponent();
        }

        FrameBaseFunction.Model.ClsUserInfoMod clsUserMod = new FrameBaseFunction.Model.ClsUserInfoMod();
        FrameBaseFunction.Query.ClsUserInfoQuery clsQuery = new FrameBaseFunction.Query.ClsUserInfoQuery();
        FrameBaseFunction.ClsDES clsDES = FrameBaseFunction.ClsDES.Instance();

        FrameBaseFunction.ClsDataBase clsSQL = FrameBaseFunction.ClsDataBaseFactory.Instance();
        

        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "refresh":
                        btnRefresh();
                        break;
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

        private void btnRefresh()
        {
            int iFoc = 0;
            if (gridView1.FocusedRowHandle > 0)
                iFoc = gridView1.FocusedRowHandle;

            GetGridView();
            gridView1.FocusedRowHandle = iFoc;
        }

        private void btnImport()
        {
            string sSQL = "insert into dbo._UserInfo(vchrUid,vchrName,vchrPwd,vchrRemark,dtmCreate,dtmClose)select cUser_Id,cUser_Name,'648330026C010334E58049E4DCC69B77','',getdate(),'2099-12-31' from UFSystem..UA_User where cUser_Id not in (select vchrUid from _UserInfo)";
            int iRow = clsSQL.ExecSql(sSQL);
            GetGridView();
            MessageBox.Show("同步U8账号成功，请进入系统设置权限！\n同步账号数量" + iRow.ToString());
        }

        private void btnImprot()
        {
            string sSQL = "insert into dbo._UserInfo(vchrUid,vchrName,vchrPwd,vchrRemark,dtmCreate,dtmClose)select cUser_Id,cUser_Name,'999','','1900-01-01','2099-12-31' from UFSystem..UA_User where cUser_Id not in (select vchrUid from _UserInfo)";
            clsSQL.ExecSql(sSQL);
            GetGridView();
            MessageBox.Show("同步U8账号成功，请进入系统设置权限！");
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
                FrameBaseFunction.Bll.ClsUserInfoBll clsBll = new FrameBaseFunction.Bll.ClsUserInfoBll();
                clsBll.Delete(sUserID);
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
            DataTable dt = clsQuery.GetAllDt();
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