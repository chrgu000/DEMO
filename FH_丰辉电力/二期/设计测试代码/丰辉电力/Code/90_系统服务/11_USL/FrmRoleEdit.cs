using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 系统服务
{
    public partial class FrmRoleEdit : Form
    {
        protected ClsUseWebService clsWeb = new ClsUseWebService();
        系统服务.Model.ClsRoleInfoMod clsMod = new 系统服务.Model.ClsRoleInfoMod();
        string sState;
        public FrmRoleEdit(Color color)
        {
            InitializeComponent();

            this.BackColor = color;
            sState = "add";
        }

        public FrmRoleEdit(Color color, 系统服务.Model.ClsRoleInfoMod clsRoleMod)
        {
            InitializeComponent();

            this.BackColor = color;
            sState = "edit";
            clsMod = clsRoleMod;
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

                    clsWeb.ClsRoleEditBllAdd(txtRoleID.Text.Trim(), txtRoleText.Text.Trim(), txtReamrk.Text.Trim(), false, dtmCreate.DateTime, dt);

                    SetValue();
                    this.txtRoleID.Focus();

                    dt = clsWeb.ClsRoleEditQueryGetAllDt();
                    gridControl1.DataSource = dt;
                }
                if (sState == "edit")
                {
                    CheckData();
                    SetTxtToMod();
                    DataTable dt = (DataTable)gridControl1.DataSource;

                    clsWeb.ClsRoleEditBllUpdate(txtRoleID.Text.Trim(), txtRoleText.Text.Trim(), txtReamrk.Text.Trim(), false, dtmCreate.DateTime, dt);

                    this.Close();
                  
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("保存失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmRoleEdit_Load(object sender, EventArgs e)
        {
            DataTable dt;
            if (sState == "add")
            {
                SetValue();
                dt = clsWeb.ClsRoleEditQueryGetAllDt(); 
                gridControl1.DataSource = dt;
            }
            if (sState == "edit")
            {
                SetValue(clsMod);
                txtRoleID.Enabled = false;
                txtRoleText.Focus();

                dt = clsWeb.ClsRoleEditQueryGetUserRole(clsMod.vchrRoleID);
                gridControl1.DataSource = dt;
               
            }
        }

        private void SetValue()
        {
            this.txtRoleID.Text = "";
            this.txtRoleText.Text = "";
            this.txtReamrk.Text = "";
            this.dtmCreate.DateTime =DateTime.Parse(系统服务.ClsBaseDataInfo.sLogDate);
        }

        private void SetValue(系统服务.Model.ClsRoleInfoMod clsMod)
        {
            this.txtRoleID.Text = clsMod.vchrRoleID;
            this.txtRoleText.Text = clsMod.vchrRoleText;
            this.txtReamrk.Text = clsMod.vchrRemark;
            this.dtmCreate.DateTime = clsMod.dtmCreate;
        }
        /// <summary>
        /// 检查控件值
        /// </summary>
        /// <returns></returns>
        private void CheckData()
        {
            if (txtRoleID.Text.Trim() == string.Empty)
            {
                txtRoleID.Focus();
                throw new Exception("角色编号不能为空！");
            }
        }

        /// <summary>
        /// 设置控件值
        /// </summary>
        private void SetModToTxt()
        {
            //txtUid.Text = clsMod.vchrUid;
            //txtPwd.Text = clsMod.vchrPwd;
            //txtPwdRep.Text = clsMod.vchrPwd;
            //dtmCreate.DateTime = clsMod.dtmCreate;
            //dtmClose.DateTime = clsMod.dtmClose;
            //txtReamrk.Text = clsMod.vchrRemark;
        }

        /// <summary>
        /// 根据控件值填数据实体
        /// </summary>
        private void SetTxtToMod()
        {
            clsMod.vchrRoleID = txtRoleID.Text.Trim();
            clsMod.vchrRoleText = txtRoleText.Text.Trim();
            clsMod.vchrRemark = txtReamrk.Text.Trim();
            clsMod.bClosed = false;
            clsMod.dtmCreate = dtmCreate.DateTime;
        }


        //private void FrmUserEdit_Load(object sender, EventArgs e)
        //{
        //    DataTable dt;
        //    if (sState == "add")
        //    {
        //        SetValue();
        //        dt = clsQuery.GetAllDt();
        //        gridControl1.DataSource = dt;
        //    }
        //    if (sState == "edit")
        //    {
        //        //SetValue(clsMod);
        //        txtRoleID.Enabled = false;
        //        txtRoleText.Focus();

        //        //dt = clsQuery.GetUserRole(clsMod.vchrUid);
        //        //gridControl1.DataSource = dt;
        //    }
        //}

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
    }
}