using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;

namespace 基础设置
{
    public partial class Frm代理商Edit : Form
    {
        系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
        系统服务.ClsGetSQL clsGetSQL = 系统服务.ClsGetSQL.Instance();

        string sVenCode = "";

        public DataTable dt地区;
        public DataTable dt部门;


        public Frm代理商Edit(string sVenCode)
        {
            InitializeComponent();

            this.sVenCode = sVenCode;

            txt代理商编码.Enabled = false;

        }

        public Frm代理商Edit()
        {
            InitializeComponent();

            txt代理商编码.Enabled = true;
        }


       
        private void Frm代理商Edit_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookUpEdit();

                SetTxtNull();

                if (sVenCode.Trim() != "")
                {
                    GetGrid(sVenCode);

                    txt代理商编码.Enabled = false;
                }
            }
            catch (Exception ee)
            {
                throw new Exception("加载窗体失败\n" + ee.Message);
            }
        }



        private void GetGrid(string sVenCode)
        {
            string sSQL = "select cast(D1 AS int) as 级次, *, 'edit' as iSave from dbo.代理商 where cVenCode = 'aaaaaaaa' order by cVenCode";
            sSQL = sSQL.Replace("aaaaaaaa", sVenCode);
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt == null || dt.Rows.Count == 0)
            {
                throw new Exception("加载代理商失败");
            }

            txt代理商编码.Text = dt.Rows[0]["cVenCode"].ToString().Trim();
            txt代理商名称.Text = dt.Rows[0]["cVenName"].ToString().Trim();
            txt代理商简称.Text = dt.Rows[0]["cVenAbbName"].ToString().Trim();
            txt联系人.Text = dt.Rows[0]["cVenPerson"].ToString().Trim();
            txt电话.Text = dt.Rows[0]["cVenPhone"].ToString().Trim();
            btnTxt部门.Text = dt.Rows[0]["cVenDepartment"].ToString().Trim();
            lookUpEdit分管部门.EditValue = dt.Rows[0]["cVenDepartment"];
            btnTxt地区编码.Text = dt.Rows[0]["cVenDCCode"].ToString().Trim();
            lookUpEdit地区.EditValue = dt.Rows[0]["cVenDCCode"];
            txt邮箱.Text = dt.Rows[0]["cVenEmail"].ToString().Trim();
            txt银行帐号.Text = dt.Rows[0]["cVenAccount"].ToString().Trim();
            txt开户行.Text = dt.Rows[0]["cVenBank"].ToString().Trim();
            txt手机.Text = dt.Rows[0]["s1"].ToString().Trim();
            txt身份证.Text = dt.Rows[0]["s2"].ToString().Trim();
            lookUpEdit上级代理.EditValue = dt.Rows[0]["s3"].ToString().Trim();

            int l = Convert.ToInt32(dt.Rows[0]["级次"]);
            lookUpEdit级次.Text = (l).ToString();

            txt代理商名称.Focus();
        }

        /// <summary>
        /// 下拉列表框
        /// </summary>
        private void SetLookUpEdit()
        {
            lookUpEdit分管部门.Properties.DataSource = dt部门;

            lookUpEdit地区.Properties.DataSource = dt地区;

            string sSQL = "select  cVenCode, cVenName, cVenAbbName from 代理商 order by cVenCode";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            lookUpEdit上级代理.Properties.DataSource = dt;

            sSQL = @"
SELECT   distinct iID
FROM      代理级次
ORDER BY iID ";
            dt = clsSQLCommond.ExecQuery(sSQL);
            lookUpEdit级次.Properties.DataSource = dt;
        }

     

        private void btnAddList_Click(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "select * from 代理商 where 1=-1";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                if (txt代理商编码.Text.Trim() == "")
                {
                    MessageBox.Show("代理商代码不能为空");
                    txt代理商编码.Focus();
                    return;
                }

                if (txt代理商名称.Text.Trim() == "")
                {
                    MessageBox.Show("代理商名称不能为空");
                    txt代理商名称.Focus();
                    return;
                }

                if (btnTxt部门.Text.Trim() != "" && lookUpEdit分管部门.Text.Trim() == "")
                {
                    MessageBox.Show("分管部门不正确");
                    btnTxt部门.Focus();
                    return;
                }
                if (btnTxt地区编码.Text.Trim() != "" && lookUpEdit地区.Text.Trim() == "")
                {
                    MessageBox.Show("地区编码不正确");
                    btnTxt地区编码.Focus();
                    return;
                }


                #region 生成table
                DataRow dr = dt.NewRow();
                dr["cVenCode"] = txt代理商编码.Text.Trim();
                dr["cVenName"] = txt代理商名称.Text.Trim();
                dr["cVenAbbName"] = txt代理商简称.Text.Trim();

                dr["cVenPerson"] = txt联系人.Text.Trim();
                dr["cVenPhone"] = txt电话.Text.Trim();
                dr["cVenDCCode"] = lookUpEdit地区.EditValue.ToString().Trim();
                dr["cVenDepartment"] = lookUpEdit分管部门.EditValue.ToString().Trim();
                dr["cVenEmail"] = txt邮箱.Text.Trim();

                //dr["cVenRegCode"] = gridView1.GetRowCellValue(i, gridColcVenRegCode).ToString().Trim();
                dr["cVenAccount"] = txt银行帐号.Text.Trim();
                dr["cVenBank"] = txt开户行.Text.Trim();
                dr["s1"] = txt身份证.Text.Trim();
                dr["s2"] = txt手机.Text.Trim(); 

                dt.Rows.Add(dr);
                #endregion

                if (sVenCode.Trim() != "")
                {
                    sSQL = clsGetSQL.GetUpdateSQL(系统服务.ClsBaseDataInfo.sDataBaseName, "代理商", dt, dt.Rows.Count - 1);

                }
                if (sVenCode.Trim() == "")
                {
                    sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, "代理商", dt, dt.Rows.Count - 1);
                }


                int iCou = clsSQLCommond.ExecSql(sSQL);
                if (iCou > 0)
                {
                    SetTxtNull();
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show("保存失败：" + ee.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "select * from 代理商 where 1=-1";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                if (txt代理商编码.Text.Trim() == "")
                {
                    MessageBox.Show("代理商代码不能为空");
                    txt代理商编码.Focus();
                    return;
                }

                if (txt代理商名称.Text.Trim() == "")
                {
                    MessageBox.Show("代理商名称不能为空");
                    txt代理商名称.Focus();
                    return;
                }

                if (btnTxt部门.Text.Trim() != "" && lookUpEdit分管部门.Text.Trim() == "")
                {
                    MessageBox.Show("分管部门不正确");
                    btnTxt部门.Focus();
                    return;
                }
                if (btnTxt地区编码.Text.Trim() != "" && lookUpEdit地区.Text.Trim() == "")
                {
                    MessageBox.Show("地区编码不正确");
                    btnTxt地区编码.Focus();
                    return;
                }
                if (btnTxt上级代理编码.Text.Trim() == txt代理商编码.Text.Trim())
                {
                    MessageBox.Show("上级代理不能与自己编码一样");
                    btnTxt上级代理编码.Focus();
                    return;
                }

                #region 生成table
                DataRow dr = dt.NewRow();
                dr["cVenCode"] = txt代理商编码.Text.Trim();
                dr["cVenName"] = txt代理商名称.Text.Trim();
                dr["cVenAbbName"] = txt代理商简称.Text.Trim();

                dr["cVenPerson"] = txt联系人.Text.Trim();
                dr["cVenPhone"] = txt电话.Text.Trim();
                dr["cVenDCCode"] = lookUpEdit地区.EditValue.ToString().Trim();
                dr["cVenDepartment"] = lookUpEdit分管部门.EditValue.ToString().Trim();
                dr["cVenEmail"] = txt邮箱.Text.Trim();

                //dr["cVenRegCode"] = gridView1.GetRowCellValue(i, gridColcVenRegCode).ToString().Trim();
                dr["cVenAccount"] = txt银行帐号.Text.Trim();
                dr["cVenBank"] = txt开户行.Text.Trim();
                dr["s1"] = txt手机.Text.Trim();
                dr["s2"] = txt身份证.Text.Trim();
                dr["s3"] = lookUpEdit上级代理.EditValue.ToString().Trim();

                if (lookUpEdit级次.Text.Trim() != "")
                {
                    dr["d1"] = Convert.ToInt32(lookUpEdit级次.Text.Trim());
                }


                dt.Rows.Add(dr);
                #endregion

                if (sVenCode.Trim() != "")
                {
                    sSQL = clsGetSQL.GetUpdateSQL(系统服务.ClsBaseDataInfo.sDataBaseName, "代理商", dt, dt.Rows.Count - 1);

                }
                if (sVenCode.Trim() == "")
                {
                    sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, "代理商", dt, dt.Rows.Count - 1);
                }


                int iCou = clsSQLCommond.ExecSql(sSQL);
                if (iCou > 0)
                {
                    this.DialogResult = DialogResult.OK;
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show("保存失败：" + ee.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnTxt部门_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            try
            {
                Frm参照 frm = new Frm参照(2);
                frm.txtSEL.Text = btnTxt部门.Text.Trim();
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    lookUpEdit分管部门.EditValue = frm.iID;
                }

            }
            catch (Exception ee)
            {
                throw new Exception("加载部门失败:" + ee.Message);
            }
        }

        private void btnTxt部门_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                btnTxt部门_ButtonClick(null, null);
            }
        }

        private void lookUpEdit分管部门_EditValueChanged(object sender, EventArgs e)
        {
            btnTxt部门.Text = lookUpEdit分管部门.EditValue.ToString().Trim();
        }

        private void btnTxt地区编码_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                Frm参照 frm = new Frm参照(6);
                frm.txtSEL.Text = btnTxt地区编码.Text.Trim();
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    lookUpEdit地区.EditValue = frm.iID;
                }

            }
            catch (Exception ee)
            {
                throw new Exception("加载地区信息失败:" + ee.Message);
            }
        }

        private void btnTxt地区编码_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                btnTxt地区编码_ButtonClick(null, null);
            }
        }

        private void lookUpEdit地区_EditValueChanged(object sender, EventArgs e)
        {
            btnTxt地区编码.Text = lookUpEdit地区.EditValue.ToString().Trim();
        }


        private void SetTxtNull()
        {
            txt代理商编码.Enabled = true;

            txt代理商编码.Text = "";
            txt代理商名称.Text = "";
            txt代理商简称.Text = "";
            txt联系人.Text = "";
            txt电话.Text = "";
            txt邮箱.Text = "";
            btnTxt地区编码.Text = "";
            lookUpEdit地区.EditValue = DBNull.Value;
            txt身份证.Text = "";
            txt手机.Text = "";
            btnTxt部门.Text = "";
            lookUpEdit分管部门.EditValue = DBNull.Value;
            txt开户行.Text = "";
            txt银行帐号.Text = "";
            lookUpEdit级次.EditValue = DBNull.Value;
            btnTxt上级代理编码.Text = "";
            lookUpEdit上级代理.EditValue = DBNull.Value;

            txt代理商编码.Focus();

        }

        private void btnTxt地区编码_Validated(object sender, EventArgs e)
        {
            lookUpEdit地区.EditValue = btnTxt地区编码.Text.Trim();
        }

        private void btnTxt部门_Validated(object sender, EventArgs e)
        {
            lookUpEdit分管部门.EditValue = btnTxt部门.Text.Trim();
        }

        private void txt手机_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnTxt上级代理编码_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                Frm参照 frm = new Frm参照(3);
                frm.txtSEL.Text = btnTxt上级代理编码.Text.Trim();
                frm.ShowDialog();

                btnTxt上级代理编码.Text = frm.iID;
                lookUpEdit上级代理.EditValue = frm.iID;

            }
            catch (Exception ee)
            {
                throw new Exception("加载地区信息失败:" + ee.Message);
            }
        }

        private void btnTxt上级代理编码_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F2)
                {
                    btnTxt上级代理编码_ButtonClick(null, null);
                }
                if (e.KeyCode == Keys.Enter)
                {
                    btnTxt上级代理编码_Leave(null, null);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("操作失败：" + ee.Message);
            }
        }

        private void btnTxt上级代理编码_Leave(object sender, EventArgs e)
        {
            lookUpEdit上级代理.EditValue = btnTxt上级代理编码.Text.Trim();

            if (lookUpEdit上级代理.EditValue != null && lookUpEdit上级代理.Text.Trim() != "")
            {
                SetLookUpEdit();
            }
        }

        private void lookUpEdit上级代理_EditValueChanged(object sender, EventArgs e)
        {
            btnTxt上级代理编码.Text = lookUpEdit上级代理.EditValue.ToString().Trim();
        }
    }
}
