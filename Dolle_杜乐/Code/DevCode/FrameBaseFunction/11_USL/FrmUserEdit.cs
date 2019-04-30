using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace FrameBaseFunction
{
    public partial class FrmUserEdit : Form
    {
        string sState = "";
        FrameBaseFunction.Model.ClsUserInfoMod clsMod = new FrameBaseFunction.Model.ClsUserInfoMod();
        FrameBaseFunction.Model.ClsUserRoleMod clsUserRoleMod = new FrameBaseFunction.Model.ClsUserRoleMod();
        
        FrameBaseFunction.Query.ClsUserEditQuery clsQuery = new FrameBaseFunction.Query.ClsUserEditQuery();
        FrameBaseFunction.Bll.ClsUserEditBll clsBll = new FrameBaseFunction.Bll.ClsUserEditBll();
        FrameBaseFunction.ClsDES clsDES = FrameBaseFunction.ClsDES.Instance();

        public FrmUserEdit(Color color)
        {
            InitializeComponent();

            this.BackColor = color;
            sState = "add";
        }

        public FrmUserEdit(Color color, FrameBaseFunction.Model.ClsUserInfoMod clsUserMod)
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


                    clsBll.Add(clsMod, dt);

                    SetValue();
                    this.txtUid.Focus();
                    GetGridInfo();
                }
                if (sState == "edit")
                {
                    CheckData();
                    SetTxtToMod();
                    DataTable dt = (DataTable)gridControl1.DataSource;

                    clsBll.Update(clsMod, dt);

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
                dt = clsQuery.GetAllDt();
                gridControl1.DataSource = dt;
            }
            if (sState == "edit")
            {
                SetValue(clsMod);
                txtUid.Enabled = false;
                txtPwd.Focus();

                dt = clsQuery.GetUserRole(clsMod.vchrUid);
                gridControl1.DataSource = dt;
            }
        }

        /// <summary>
        /// 获得表格值
        /// </summary>
        private void GetGridInfo()
        {
            DataTable dt = clsQuery.GetAllDt();
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
            this.dtmCreate.DateTime = DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate);
            this.dtmClose.DateTime = Convert.ToDateTime("2099-12-31");
            this.txtReamrk.Text = "";
        }

        private void SetValue( FrameBaseFunction.Model.ClsUserInfoMod clsMod)
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