using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FrameBaseFunction;

namespace Base
{
    public partial class Frm杜乐耗材供应商Edit : Form
    {
        FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
        FrameBaseFunction.ClsGetSQL clsGetSQL = FrameBaseFunction.ClsGetSQL.Instance();

        string sVenCode = "";

        public Frm杜乐耗材供应商Edit()
        {
            InitializeComponent();
        }
        string sType = "";
        public Frm杜乐耗材供应商Edit(string s)
        {
            InitializeComponent();

            sVenCode = s;
        }

        private void SetValue()
        {
            string sSQL = @"
select cast(0 as bit) as 选择, *
from UFDLImport..VendorHC
where 1=1
order by cVenCode";

            sSQL = sSQL.Replace("1=1", "1=1 and cVenCode = '" + sVenCode + "'");
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt != null && dt.Rows.Count > 0)
            {
                txtcVencode.Text = dt.Rows[0]["cVencode"].ToString().Trim();
                txtcVenName.Text = dt.Rows[0]["cVenName"].ToString().Trim();
                txtcVenAbbName.Text = dt.Rows[0]["cVenAbbName"].ToString().Trim();
                txtAddress.Text = dt.Rows[0]["Address"].ToString().Trim();
                txtCreateUid.Text = dt.Rows[0]["CreateUid"].ToString().Trim();
                txtcVenPerson.Text = dt.Rows[0]["cVenPerson"].ToString().Trim();
                txtcVenPhone.Text = dt.Rows[0]["cVenPhone"].ToString().Trim();
                txtRemark1.Text = dt.Rows[0]["Remark1"].ToString().Trim();
                txtRemark2.Text = dt.Rows[0]["Remark2"].ToString().Trim();
                txtRemark3.Text = dt.Rows[0]["Remark3"].ToString().Trim();
                txtRemark4.Text = dt.Rows[0]["Remark4"].ToString().Trim();
                txtRemark5.Text = dt.Rows[0]["Remark5"].ToString().Trim();
                txtRemark6.Text = dt.Rows[0]["Remark6"].ToString().Trim();
                txtRemark7.Text = dt.Rows[0]["Remark7"].ToString().Trim();
                txtRemark8.Text = dt.Rows[0]["Remark8"].ToString().Trim();
                txtUpdateUid.Text = dt.Rows[0]["UpdateUid"].ToString().Trim();

                if (dt.Rows[0]["CreateDate"].ToString().Trim() != "")
                    dtmCreate.Text = dt.Rows[0]["CreateDate"].ToString().Trim();

                if (dt.Rows[0]["UpdateDate"].ToString().Trim() != "")
                    dtmUpdate.Text = dt.Rows[0]["UpdateDate"].ToString().Trim();
            }
        }

        private void SetNull()
        {
            txtcVencode.Text = "";
            txtcVenName.Text = "";
            txtcVenAbbName.Text = "";
            txtAddress.Text = "";
            txtCreateUid.Text = "";
            txtcVenPerson.Text = "";
            txtcVenPhone.Text = "";
            txtRemark1.Text = "";
            txtRemark2.Text = "";
            txtRemark3.Text = "";
            txtRemark4.Text = "";
            txtRemark5.Text = "";
            txtRemark6.Text = "";
            txtRemark7.Text = "";
            txtRemark8.Text = "";
            txtUpdateUid.Text = "";
            dtmCreate.Text = "";
            dtmUpdate.Text = "";
        }

        private void btn保存_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtcVencode.Text.Trim() == "")
                {
                    txtcVencode.Focus();
                    throw new Exception("供应商编码不能为空");
                }
                if (txtcVenName.Text.Trim() == "")
                {
                    txtcVenName.Focus();
                    throw new Exception("供应商名称不能为空");
                }

                string sSQL = "";
                if (sVenCode.Trim() != "")
                {
                    sSQL = "select count(1) from @u8.Vendor where cVenCode = '" + txtcVencode.Text.Trim() + "'";
                    int iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                    if (iCou > 0)
                        throw new Exception("供应商编码不能与U8重复");
                }

                ArrayList aList = new ArrayList();

                if (sVenCode.Trim() == "")
                {
                    sSQL = " INSERT INTO [UFDLImport].[dbo].[VendorHC]([cVenCode] ,[cVenName] ,[cVenAbbName] ,[Address] ,[cVenPerson] " +
                                        ",[cVenPhone],[Remark1] ,[Remark2] ,[Remark3] " +
                                       ",[Remark4],[Remark5] ,[Remark6] ,[Remark7] ,[Remark8]  ,[CreateUid] ,[CreateDate] ,[UpdateUid]  ,[UpdateDate]) " +
                                " VALUES " +
                                       "(N'" + txtcVencode.Text.Trim() + "'  ,N'" + txtcVenName.Text.Trim() + "'  ,N'" + txtcVenAbbName.Text.Trim() + "'  ,N'" + txtAddress.Text.Trim() + "' ,N'" + txtcVenPerson.Text.Trim() + "'" +
                                       ",N'" + txtcVenPhone.Text.Trim() + "' ,N'" + txtRemark1.Text.Trim() + "'  ,N'" + txtRemark2.Text.Trim() + "',N'" + txtRemark3.Text.Trim() + "',N'" + txtRemark4.Text.Trim() + "' " +
                                       ",N'" + txtRemark5.Text.Trim() + "' ,N'" + txtRemark6.Text.Trim() + "' ,N'" + txtRemark7.Text.Trim() + "'   ,N'" + txtRemark8.Text.Trim() + "'  ,N'" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "'  ,getdate()  ,null,null)  ";
                }
                else
                {
                    sSQL = @"
UPDATE [UFDLImport].[dbo].[VendorHC] " +
   "SET [cVenName] = N'" + txtcVenName.Text.Trim() + "' " +
   "   ,[cVenAbbName] =  N'" + txtcVenAbbName.Text.Trim() + "' " +
   "   ,[Address] =  N'" + txtAddress.Text.Trim() + "' " +
   "   ,[cVenPerson] =  N'" + txtcVenPerson.Text.Trim() + "' " +
   "   ,[cVenPhone] = N'" + txtcVenPhone.Text.Trim() + "' " +
   "   ,[Remark1] =  N'" + txtRemark1.Text.Trim() + "' " +
   "   ,[Remark2] =  N'" + txtRemark2.Text.Trim() + "' " +
   "   ,[Remark3] =  N'" + txtRemark3.Text.Trim() + "' " +
   "   ,[Remark4] =  N'" + txtRemark4.Text.Trim() + "' " +
   "   ,[Remark5] =  N'" + txtRemark5.Text.Trim() + "' " +
   "   ,[Remark6] =  N'" + txtRemark6.Text.Trim() + "' " +
   "   ,[Remark7] =  N'" + txtRemark7.Text.Trim() + "' " +
   "   ,[Remark8] =  N'" + txtRemark8.Text.Trim() + "' " +
   "   ,[UpdateUid] =  N'" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "' " +
   "   ,[UpdateDate] =  getdate() " +
"where cVenCode = N'" + sVenCode.Trim() + "'";
                }
                aList.Add(sSQL);

                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("保存成功");

                    SetEnable(false);
                    btn保存.Enabled = false;
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }



        private void btn退出_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void Frm杜乐耗材供应商Edit_Load(object sender, EventArgs e)
        {
            try
            {
                this.StartPosition = FormStartPosition.CenterParent;

                SetNull();

                if (sVenCode.Trim() != "")
                {
                    SetValue();
                }

                SetEnable(true);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }


        
        private void SetEnable(bool b)
        {
            if (sVenCode.Trim() != "")
                txtcVencode.Enabled = false;
            else
                txtcVencode.Enabled = b;

            txtcVenName.Enabled = b;
            txtcVenAbbName.Enabled = b;
            txtAddress.Enabled = b;
            txtCreateUid.Enabled = false;
            txtcVenPerson.Enabled = b;
            txtcVenPhone.Enabled = b;
            txtRemark1.Enabled = b;
            txtRemark2.Enabled = b;
            txtRemark3.Enabled = b;
            txtRemark4.Enabled = b;
            txtRemark5.Enabled = b;
            txtRemark6.Enabled = b;
            txtRemark7.Enabled = b;
            txtRemark8.Enabled = b;
            txtUpdateUid.Enabled = false;
            dtmCreate.Enabled = false;
            dtmUpdate.Enabled = false;
        }

        private void btnAddList_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtcVencode.Text.Trim() == "")
                {
                    txtcVencode.Focus();
                    throw new Exception("供应商编码不能为空");
                }
                if (txtcVenName.Text.Trim() == "")
                {
                    txtcVenName.Focus();
                    throw new Exception("供应商名称不能为空");
                }

                string sSQL = "";
                if (sVenCode.Trim() != "")
                {
                    sSQL = "select count(1) from @u8.Vendor where cVenCode = '" + txtcVencode.Text.Trim() + "'";
                    int iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                    if (iCou > 0)
                        throw new Exception("供应商编码不能与U8重复");
                }

                ArrayList aList = new ArrayList();

                if (sVenCode.Trim() == "")
                {
                    sSQL = " INSERT INTO [UFDLImport].[dbo].[VendorHC]([cVenCode] ,[cVenName] ,[cVenAbbName] ,[Address] ,[cVenPerson] " +
                                        ",[cVenPhone],[Remark1] ,[Remark2] ,[Remark3] " +
                                       ",[Remark4],[Remark5] ,[Remark6] ,[Remark7] ,[Remark8]  ,[CreateUid] ,[CreateDate] ,[UpdateUid]  ,[UpdateDate]) " +
                                " VALUES " +
                                       "(N'" + txtcVencode.Text.Trim() + "'  ,N'" + txtcVenName.Text.Trim() + "'  ,N'" + txtcVenAbbName.Text.Trim() + "'  ,N'" + txtAddress.Text.Trim() + "' ,N'" + txtcVenPerson.Text.Trim() + "'" +
                                       ",N'" + txtcVenPhone.Text.Trim() + "' ,N'" + txtRemark1.Text.Trim() + "'  ,N'" + txtRemark2.Text.Trim() + "',N'" + txtRemark3.Text.Trim() + "',N'" + txtRemark4.Text.Trim() + "' " +
                                       ",N'" + txtRemark5.Text.Trim() + "' ,N'" + txtRemark6.Text.Trim() + "' ,N'" + txtRemark7.Text.Trim() + "'   ,N'" + txtRemark8.Text.Trim() + "'  ,N'" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "'  ,getdate()  ,null,null)  ";

                    aList.Add(sSQL);
                }
               
                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("保存成功");

                    SetNull();
                    txtcVencode.Focus();
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}