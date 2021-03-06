using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace 系统服务
{
    public partial class FrmUserEdit : Form
    {
        string sState = "";
        //ClsBaseClass.Model.ClsUserInfoMod clsMod = new ClsBaseClass.Model.ClsUserInfoMod();
        //ClsBaseClass.Model.ClsUserRoleMod clsUserRoleMod = new ClsBaseClass.Model.ClsUserRoleMod();

        //ClsBaseClass.Query.ClsUserEditQuery clsQuery = new ClsBaseClass.Query.ClsUserEditQuery();
        //ClsBaseClass.Bll.ClsUserEditBll clsBll = new ClsBaseClass.Bll.ClsUserEditBll();
        //ClsBaseClass.ClsDES clsDES = ClsBaseClass.ClsDES.Instance();
        protected ClsUseWebService clsWeb = new ClsUseWebService();
        Model.ClsUserInfoMod clsMod = new Model.ClsUserInfoMod();
        Model.ClsUserRoleMod clsUserRoleMod = new Model.ClsUserRoleMod();
        ClsDES clsDES = ClsDES.Instance();
        public FrmUserEdit(Color color)
        {
            InitializeComponent();

            this.BackColor = color;
            sState = "add";
        }

        public FrmUserEdit(Color color, 系统服务.Model.ClsUserInfoMod clsUserMod)
        {
            InitializeComponent();

            this.BackColor = color;
            sState = "edit";
            clsMod = clsUserMod;
            clsMod.vchrPwd = clsDES.Decrypt(clsUserMod.vchrPwd.Trim());
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (sState == "add")
                {
                    CheckData();
                    SetTxtToMod();
                    DataTable dt = (DataTable)gridControl1.DataSource;


                    clsWeb.ClsUserEditBllAdd(txtUid.Text.Trim(), txtPwd.Text.Trim(), dtmCreate.DateTime, dtmClose.DateTime, txtReamrk.Text.Trim(), txtName.Text.Trim(), dt);
                    SetValue();
                    this.txtUid.Focus();
                    GetGridInfo();
                }
                if (sState == "edit")
                {
                    CheckData();
                    SetTxtToMod();
                    DataTable dt = (DataTable)gridControl1.DataSource;

                    clsWeb.ClsUserEditBllUpdate(txtUid.Text.Trim(), txtPwd.Text.Trim(), dtmCreate.DateTime, dtmClose.DateTime, txtReamrk.Text.Trim(), txtName.Text.Trim(), dt);

                    this.Close();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("保存失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 检查控件值
        /// </summary>
        /// <returns></returns>
        private void CheckData()
        {
            if (txtUid.Text.Trim() == string.Empty)
            {
                txtUid.Focus();
                throw new Exception("帐号不能为空！");
            }

            if (txtPwd.Text.Trim() != txtPwdRep.Text.Trim())
            {
                txtPwd.Focus();
                throw new Exception("两次密码必须一致！");
            }
        }

        /// <summary>
        /// 设置控件值
        /// </summary>
        private void SetModToTxt()
        {
            txtUid.Text = clsMod.vchrUid;
            txtPwd.Text = clsMod.vchrPwd;
            txtName.Text = clsMod.vchrName;
            txtPwdRep.Text = clsMod.vchrPwd;
            dtmCreate.DateTime = clsMod.dtmCreate;
            dtmClose.DateTime = clsMod.dtmClose;
            txtReamrk.Text = clsMod.vchrRemark;
        }

        /// <summary>
        /// 根据控件值填数据实体
        /// </summary>
        private void SetTxtToMod()
        {
            clsMod.vchrUid = txtUid.Text.Trim();
            clsMod.vchrPwd = txtPwd.Text.Trim();
            clsMod.dtmCreate = dtmCreate.DateTime;
            clsMod.dtmClose = dtmClose.DateTime;
            clsMod.vchrRemark = txtReamrk.Text.Trim();
            clsMod.vchrName = txtName.Text.Trim();
        }

       
        private void FrmUserEdit_Load(object sender, EventArgs e)
        {
            DataTable dt;
            if (sState == "add")
            {
                SetValue();
                dt = clsWeb.ClsUserEditQueryGetAllDt();
                gridControl1.DataSource = dt;
            }
            if (sState == "edit")
            {
                SetValue(clsMod);
                txtUid.Enabled = false;
                txtPwd.Focus();

                dt = clsWeb.ClsUserEditQueryGetUserRole(clsMod.vchrUid);
                gridControl1.DataSource = dt;
            }
        }

        /// <summary>
        /// 获得表格值
        /// </summary>
        private void GetGridInfo()
        {
            DataTable dt = clsWeb.ClsUserEditQueryGetAllDt();
            gridControl1.DataSource = dt;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount < 1)
                return;
            int iRow = 0;
            if (gridView1.RowCount > 1)
                iRow = gridView1.FocusedRowHandle;

            if (gridView1.GetRowCellValue(iRow, colbChoosed).ToString().Trim() == "")
                gridView1.SetRowCellValue(iRow, colbChoosed, "√");
            else
                gridView1.SetRowCellValue(iRow, colbChoosed, "");
            
        }


        private void SetValue()
        {
            this.txtUid.Text = "";
            this.txtPwd.Text = "";
            this.txtName.Text = "";
            this.txtPwdRep.Text = "";
            this.dtmCreate.DateTime = DateTime.Parse(系统服务.ClsBaseDataInfo.sLogDate);
            this.dtmClose.DateTime = Convert.ToDateTime("2099-12-31");
            this.txtReamrk.Text = "";
        }

        private void SetValue( 系统服务.Model.ClsUserInfoMod clsMod)
        {
            this.txtUid.Text = clsMod.vchrUid;
            this.txtName.Text = clsMod.vchrName;
            this.txtPwd.Text = clsMod.vchrPwd;
            this.txtPwdRep.Text = clsMod.vchrPwd;
            this.dtmCreate.DateTime = clsMod.dtmCreate;
            this.dtmClose.DateTime = clsMod.dtmClose;
            this.txtReamrk.Text = clsMod.vchrRemark;
        }
    }
}